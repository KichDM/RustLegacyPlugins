using System.Collections.Generic;

using System.Linq;

using Newtonsoft.Json;

using Oxide.Core;

using Oxide.Core.Plugins;

using RustExtended;

using UnityEngine;

using Random = Oxide.Core.Random;

// ReSharper disable StringLiteralTypo


namespace Oxide.Plugins

{

	[Info("Ivent", "Kazzooom", "0.1.2")]

	[Description("Ivent Sistem")]



	class Ivent : RustLegacyPlugin{





		// Configurations plugin.

		static bool teleports				= true;

		static float TimeTeleport			= 5f;

		static float TimeAntiSpawnKill		= 5f;

		static string chatTag				= "Rust Dark";

		// Permissoes admin vip.

		//const string permiTeleportAdmin		= "warp.admin";

		//const string permTeleportDellay		= "warp.delay";



		//Names locations.

		static Dictionary<string, object[]> NamesLocations = GetNamesLocations();

		static Dictionary<string, object[]> GetNamesLocations(){

			var dict = new Dictionary<string, object[]>();

   dict.Add("pvp", new object[] { 4256.94, 414.36, -1518.01 });

			return dict;

		}





		string GetMessage(string key, string steamid = null) => lang.GetMessage(key, this, steamid);

		void LoadDefaultMessages(){

			var message = new Dictionary<string, string>{

				{"NoPermission", "[color red]Ты не Тех.Администратор."},

				{"NoFoundTeleport", "Варпа [color red]{0} [color clear] не существует!"},

				{"NoFoundTeleport2", "ВАРП [color red]{0} [color clear] НЕ СУЩЕСТВУЕТ!"},

				{"NoFoundTeleport3", "Варп {0} Не существует! Используйте варпы из списка"},

				{"HelpsAdmins", "==================== [color lime]Меню админа [color clear]===================="},

				{"HelpsAdmins1", "Используйте /warps chattag => изменить названия Тега чата."},

				{"HelpsAdmins2", "Используйте /warps onof => Вкл/Выкл систему варпов."},

				{"HelpsAdmins3", "Используйте /warps add (название) => Добавить точку варпа."},

				{"HelpsAdmins4", "Используйте /warps remove (название) => Удалить точку варпа."},

				{"HelpsAdmins5", "Используйте /warps clear => Удалить все точки варпов."},

				{"HelpsAdmins6", "===================================================="},

				{"AdminTeleport", "Вы изменили название Тега чата на {0}!"},

				{"AdminTeleport1", "[color red]{0} [color clear] Выключена система варпов."},

				{"AdminTeleport2", "[color red]{0} [color clear] Включена система варпов."},

				{"AdminTeleport3", "Точка варпа {0} была добавлена."},

				{"AdminTeleport4", "Точка варпа {0} была удалена."},

				{"AdminTeleport5", "Все варпы были удалены!"},

				{"HelpLocationsNames", "☛☛☛ [color orange] Список варпов [color clear] ☚☚☚"},

				{"HelpLocationsNames1", "Используйте /w [color orange]\"[color cyan]{0}[color orange]\""},

				{"HelpLocationsNames2", "==========================="},

				{"Teleport", "Система варпов [color red]выключена администратором[color clear]."},

				{"Teleport1", "Вы будете перемещены в {0} через {1} секунд!"},

				{"Teleport2", "Вас переместило в {0} ✔"}

			};

			lang.RegisterMessages(message, this);

		}





		void Init(){

			CheckCfg<string>("Settings: Chat Tag", ref chatTag);

			CheckCfg<bool>("Settings: Teleports", ref teleports);

			CheckCfg<float>("Settings: Time Teleport", ref TimeTeleport);

			CheckCfg<float>("Settings: Time AntiSpawnKill", ref TimeAntiSpawnKill);

			CheckCfg<Dictionary<string, object[]>>("Settings: Names Locations", ref NamesLocations);

			//permission.RegisterPermission(permiTeleportAdmin, this);

			//permission.RegisterPermission(permTeleportDellay, this);

			LoadDefaultMessages();

			SaveConfig();

		}





		protected override void LoadDefaultConfig(){}

		private void CheckCfg<T>(string Key, ref T var){

			if(Config[Key] is T)

				var = (T)Config[Key];

			else

				Config[Key] = var;

		}





		bool AcessAdmin(NetUser netuser){

			if(netuser.CanAdmin())return true; 

			//if(permission.UserHasPermission(netuser.userID.ToString(), permiTeleportAdmin))return true;

			return false;

		}





		bool AcessDellay(NetUser netuser){

			if(netuser.CanAdmin())return true;

			//if(permission.UserHasPermission(netuser.userID.ToString(), permiTeleportAdmin))return true;

			//if(permission.UserHasPermission(netuser.userID.ToString(), permTeleportDellay))return true;

			return false;

		}





		private void HelpsAdmins(NetUser netuser){

			string ID = netuser.userID.ToString();

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins", ID));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins1", ID));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins2", ID));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins3", ID));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins4", ID));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins5", ID));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins6", ID));

		}





		void HelpLocationsNames(NetUser netuser){

			string ID = netuser.userID.ToString();

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpLocationsNames", ID));

			foreach(var pair in NamesLocations)

			rust.SendChatMessage(netuser, chatTag, string.Format(GetMessage("HelpLocationsNames1", ID), pair.Key));

			rust.SendChatMessage(netuser, chatTag, GetMessage("HelpLocationsNames2", ID));

		}





		void TeleportPlayer(NetUser netuser, Vector3 location){

			var management = RustServerManagement.Get();

			management.TeleportPlayerToWorld(netuser.playerClient.netPlayer, location);

		}





		void GodMode(NetUser netuser, bool set){ 

			if(set)

			netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);

			else

			netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false); 

		}





		[ChatCommand("ivent")]

		void cmdTeleport(NetUser netuser, string command, string[] args){

			string ID = netuser.userID.ToString();

			if(!teleports && !AcessAdmin(netuser)){rust.SendChatMessage(netuser, chatTag, GetMessage("Warp", ID)); return;}

			if(args.Length == 0){ HelpLocationsNames(netuser); return;}

			string nameLocation = args[0].ToString().ToLower();

			if(NamesLocations.ContainsKey(nameLocation)){

				object[] objectLocation = NamesLocations[nameLocation];

				if(objectLocation.Length < 2)return;

				Vector3 location = new Vector3((float)objectLocation[0], (float)objectLocation[1], (float)objectLocation[2]);

				if(!AcessDellay(netuser)){

					rust.Notice(netuser, string.Format(GetMessage("Teleport1", ID), nameLocation, TimeTeleport));

					timer.Once(TimeTeleport, ()=>{

						if(netuser.playerClient == null)return;

						TeleportPlayer(netuser, location);

						GodMode(netuser, true);

						timer.Once(TimeAntiSpawnKill, () =>{

							if(netuser.playerClient == null)return;

							GodMode(netuser, false); 

						});

					});



				}



				else{

					rust.Notice(netuser, string.Format(GetMessage("Teleport2", ID), nameLocation));

					TeleportPlayer(netuser, location);

					GodMode(netuser, true);

					timer.Once(TimeAntiSpawnKill, () =>{

						if(netuser.playerClient == null)return;

						GodMode(netuser, false); 

					});

				}

			}

			else

			rust.Notice(netuser, string.Format(GetMessage("NoFoundTeleport3", ID), nameLocation, TimeTeleport));

			rust.SendChatMessage(netuser, string.Format(GetMessage("NoFoundTeleport2", ID), nameLocation, TimeTeleport));

			HelpLocationsNames(netuser);

		}







		[ChatCommand("ivents")]

		void cmdAdminTeleport(NetUser netuser, string command, string[] args){

			string ID = netuser.userID.ToString();

			string nameLocation = string.Empty;

			if(!AcessAdmin(netuser)) { rust.SendChatMessage(netuser, chatTag, GetMessage("NoPermission", ID)); return; }

			if(args.Length == 0) { HelpsAdmins(netuser); return; }

			switch(args[0].ToLower()){

				case "chattag":

					if (args.Length < 2) { rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins1", ID)); return; }

					chatTag = args[1].ToString();

					Config["Settings: Chat Tag"] = chatTag;

					rust.Notice(netuser, string.Format(GetMessage("AdminTeleport", ID), chatTag));

					break;

				case "onof":

					if(teleports){

						teleports = false;

						rust.BroadcastChat(chatTag, string.Format(GetMessage("AdminTeleport1", ID), netuser.displayName));

					}

					else{

						teleports = true;

						rust.BroadcastChat(chatTag, string.Format(GetMessage("AdminTeleport2", ID), netuser.displayName));

					}

					Config["Settings: Teleports"] = teleports;

					break;

				case "add":

					if(args.Length < 2) { rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins3", ID)); return; }

					nameLocation = args[1].ToString().ToLower();

					Vector3 location = netuser.playerClient.lastKnownPosition;

					if(NamesLocations.ContainsKey(nameLocation))

					NamesLocations.Remove(nameLocation);

					NamesLocations.Add(nameLocation, new object[] {location.x, location.y, location.z} );

					rust.Notice(netuser, string.Format(GetMessage("AdminTeleport3", ID), nameLocation));

					Config["Settings: Names Locations"] = NamesLocations;

					break;

				case "remove":

					if(args.Length < 2) { rust.SendChatMessage(netuser, chatTag, GetMessage("HelpsAdmins4", ID)); return; }

					nameLocation = args[1].ToString().ToLower();

					if(NamesLocations.ContainsKey(nameLocation)){

						NamesLocations.Remove(nameLocation);

						rust.Notice(netuser, string.Format(GetMessage("AdminTeleport4", ID), nameLocation));

						Config["Settings: Names Locations"] = NamesLocations;

					}

					else

					rust.SendChatMessage(netuser, chatTag, string.Format(GetMessage("NoFoundTeleport", ID), nameLocation));

					break;

				case "clear":

					NamesLocations.Clear();

					rust.Notice(netuser, GetMessage("AdminTeleport5", ID));

					Config["Settings: Names Locations"] = NamesLocations;

					break;

				default:{

					HelpsAdmins(netuser);

					break;

				}

			}

			SaveConfig();

		}

	}

}