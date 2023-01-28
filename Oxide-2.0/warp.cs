using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using RustExtended;
 
namespace Oxide.Plugins
{
    [Info("Warp", "Repack", 0.5, ResourceId = 1434)] 
    [Description("Create warp points for players (Modded)")]
    class Warp: RustLegacyPlugin 
    { 
		public bool Changed;
		public int cooldown;
		public int warpbacktimer;
		public bool enablecooldown;
		public string backtolastloc;
		public string warplist;
		public string therealreadyis;
		public string warpadded;
		public string youhavetowait;
		public string youhaveteleportedto;
		public string teleportingto;
		public string youhaveremoved;
			
		object GetConfig(string menu, string datavalue, object defaultValue)
        {
            var data = Config[menu] as Dictionary<string, object>;
            if (data == null)
            {
                data = new Dictionary<string, object>();
                Config[menu] = data;
                Changed = true;
            }
            object value;
            if (!data.TryGetValue(datavalue, out value))
            {
                value = defaultValue;
                data[datavalue] = value;
                Changed = true;
            }
            return value;  
        } 
		
		void LoadVariables() 
		{
			warpbacktimer = Convert.ToInt32(GetConfig("Settings", "WarpBackTimer", 5));
			cooldown = Convert.ToInt32(GetConfig("Settings", "Cooldown", 120));
			enablecooldown = Convert.ToBoolean(GetConfig("Settings", "EnableCooldown", false));
			backtolastloc = Convert.ToString(GetConfig("Messages", "TELEPORTED_TO_LAST_LOCATION", "Вы телепортировались обратно в свое последнее место!"));
			warplist = Convert.ToString(GetConfig("Messages", "WARP_LIST", "Warp ID: [color cyan]{2}[color white] Название варпа: [color cyan]{0}[color white] Разрешение:[color orange] {1} [color white] Макс. Исп.: [color lime]{3}[color white]"));
			therealreadyis = Convert.ToString(GetConfig("Messages", "WARP_EXISTS", "Данный варп уже существует!"));
			warpadded = Convert.ToString(GetConfig("Messages", "WARP_ADDED", "Warp добавлен с именем Warp: [color cyan]{0}[color white]"));
			youhavetowait = Convert.ToString(GetConfig("Messages", "COOLDOWN_MESSAGE", "Вам придется подождать [color cyan]{0}[color white] секунд для повторной телепортации."));
			youhaveteleportedto = Convert.ToString(GetConfig("Messages", "TELEPORTED_TO", "Вы телепортировались  [color cyan]{0}[color white]"));
			teleportingto = Convert.ToString(GetConfig("Messages", "TELEPORTING_IN_TO", "Телепортация в [color orange]{0}[color white] секунд в [color cyan]{1}[color white]"));
			youhaveremoved = Convert.ToString(GetConfig("Messages", "WARP_REMOVED", "Вы удалили варп [color cyan]{0}[color white]"));
			
			if (Changed)
			{ 
				SaveConfig();
				Changed = false;
			
			}	
		}
		
		protected override void LoadDefaultConfig()
		{
			Puts("Creating a new configuration file!");
			Config.Clear();
			LoadVariables();
		}
		
			class StoredData
			{
				public List<WarpInfo> WarpInfo = new List<WarpInfo>{};
				public Dictionary<ulong, float> cantele = new Dictionary<ulong, float>();
				public Dictionary<ulong, OldPosInfo> lastposition = new Dictionary<ulong, OldPosInfo>();
				public Dictionary<ulong, Dictionary<string, int>> maxuses = new Dictionary<ulong, Dictionary<string, int>>();
				
			} 
			
			class OldPosInfo
			{
				public float OldX;
				public float OldY;
				public float OldZ;
				
				public OldPosInfo(float x, float y, float z)
				{
					OldX = x;
					OldY = y; 
					OldZ = z;
				}
				
				public OldPosInfo()
				{
				}
			}
			class WarpInfo
			{
				public string WarpName;
				public int WarpId;
                public int WarpCosts;
                public float WarpX;
				public float WarpY; 
				public float WarpZ; 
				public string WarpPermissionGroup;
				public int WarpTimer;
				public int WarpMaxUses;
				public string WarpCreatorName;
				public int RandomRange;
				
				public WarpInfo(string name, NetUser player, int timerp, string permissionp, int warpnum, int randomr, int maxusess, int costs)
				{
					var cachedVector3 = player.playerClient.lastKnownPosition;
					WarpName =  name; 
					WarpId = warpnum;
					WarpX = cachedVector3.x; 
					WarpMaxUses = maxusess;
					WarpY = cachedVector3.y;
					WarpZ = cachedVector3.z;
					WarpCreatorName = player.displayName;
					WarpTimer = timerp;
					WarpPermissionGroup = permissionp;
					RandomRange = randomr;
                    WarpCosts = costs;
				}
				
				public WarpInfo()
				{ 
				}
			}
			
			StoredData storedData;
			
			void Loaded()
			{
				storedData = Interface.GetMod().DataFileSystem.ReadObject<StoredData>("WarpSystem"); 
				//if (!permission.PermissionExists("warp.admin")) permission.RegisterPermission("warp.admin", this);
				//if (!permission.PermissionExists("canback")) permission.RegisterPermission("canback", this);
				LoadVariables();
				foreach(WarpInfo info in storedData.WarpInfo)
				{
						if(!permission.GroupExists(info.WarpPermissionGroup)) permission.CreateGroup(info.WarpPermissionGroup, "", 0);
						cmd.AddChatCommand(info.WarpId.ToString(), this, "");
						cmd.AddChatCommand(info.WarpName, this, "");
				} 
			}
			
			int GetNewId()
			{
				
				int id = 0;
				foreach(WarpInfo info in storedData.WarpInfo)
				{
					id = Math.Max(0, info.WarpId);
				}
				return id + 1;
			}
			int GetRandomId(NetUser player)
			{
				int randomid = 0;
				foreach(WarpInfo info in storedData.WarpInfo)
				{
					if(permission.UserHasGroup(player.userID.ToString(), info.WarpPermissionGroup) || info.WarpPermissionGroup == "all")
					{
						randomid = UnityEngine.Random.Range(0, Math.Max(0, info.WarpId));
					}
				}
				return randomid + 1;
			}

            bool CanTeleport(NetUser Sender)
            {
                Collider[] array = Physics.OverlapSphere(Sender.playerClient.controllable.character.transform.position, 1f, 271975425);
                for (int k = 0; k < array.Length; k++)
                {
                    IDMain main = IDBase.GetMain(array[k]);
                    if (!(main == null))
                    {
                        StructureMaster component = main.GetComponent<StructureMaster>();
                        if (!(component == null) && component.ownerID != Sender.userID)
                        {
                            UserData bySteamID = Users.GetBySteamID(component.ownerID);
                            if (bySteamID == null || !bySteamID.HasShared(Sender.userID))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }

			[ChatCommand("w")]
			void cmdWarp(NetUser player, string cmdd, string[] args)
			{  
				if(args.Length == 0)
				{ 
					if(player.admin)
					{
						SendReply(player, "[color red][color white] /w list");
						SendReply(player, "[color white] /w <ID или || WarpName>");
					}
					else
					{
						SendReply(player, "[color white] /w list");
						SendReply(player, "[color white] /w <ID или || WarpName>");
					}
					return;
				}
				ulong steamId = player.userID;
				float nextteletime;
				switch(args[0])
				{
					case "limit":
					SendReply(player, "[color cyan]Установленный лимит варпа[color white]");

					if (storedData.cantele.TryGetValue(steamId, out nextteletime))
					{ 
						int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
						if(nexttele <= 0)
						{
							nexttele = 0;
						}
						SendReply(player, $"Вы можете снова воспользоваться варпом через {nexttele.ToString()} секунд");
					}
					SendReply(player, $"Warp Cooldown: [color orange]{cooldown.ToString()}[color white]");
					SendReply(player, $"Warp Cooldown Enabled: [color orange]{enablecooldown.ToString()}[color white]");
					SendReply(player, "[color cyan]*************[color white]");
					break;
					case "back":
					if(permission.UserHasPermission(player.userID.ToString(), "canback"))
					{
						SendReply(player, "Вы телепортировались обратно за {0} секунд.", warpbacktimer.ToString());
						timer.Once(warpbacktimer, () => {
						ForcePlayerPos(player, new Vector3(storedData.lastposition[steamId].OldX, storedData.lastposition[steamId].OldY, storedData.lastposition[steamId].OldZ)); 
						SendReply(player, backtolastloc);
						storedData.lastposition.Remove(steamId);
						Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
						});
					}
					break;
					
					/*case "random":
					player.SendConsoleCommand($"chat.say \"/w to {GetRandomId(player).ToString()}\" ");
					break;*/
					
					case "all":
					if(!player.admin)
					{
						SendReply(player, "Вы не имеете прав на использование этой команды!");
						return; 
					}
					if(args.Length == 2)
					{
						foreach(PlayerClient current in PlayerClient.All)
						{
							foreach(WarpInfo info in storedData.WarpInfo)
							{
								if(info.WarpName.ToString().ToLower() == args[1].ToString().ToLower() || info.WarpId.ToString() == args[1].ToString())
								{
									var management = RustServerManagement.Get(); 
									management.TeleportPlayerToWorld(current.netPlayer, new Vector3(info.WarpX, info.WarpY, info.WarpZ));
									PrintToChat("Все игроки телепортированы [color cyan]" + info.WarpName + "[color white] Админом [color orange]" + player.displayName + "[color white]");
								
								}
							}
						}
					}
					else
					{
						SendReply(player, "[color cyan]Телепортация всех игроков[color white]: \n /w all <WarpName, WarpId>");
						return;
					}
					break;
					case "wipe":
					if(!player.admin)
					{
						SendReply(player, "Вы не имеете прав на использование этой команды!");
						return;
					}
						storedData.WarpInfo.Clear();
						storedData.cantele.Clear();
						Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
					SendReply(player, "Вы удалили все варпы!");
					break;
					
					case "list":
						//SendReply(player, "[color cyan]********************[color red]Доступные варпы:[color cyan]***********************[color white]");
						string maxusesrem;
						foreach(WarpInfo info in storedData.WarpInfo)
						{
							if(permission.UserHasGroup(steamId.ToString(), info.WarpPermissionGroup) || info.WarpPermissionGroup == "all")
							{

								if(info.WarpMaxUses == 0)
								{
									maxusesrem = "[color lime]Безлимит[color white]";
								}
								else if(!storedData.maxuses.ContainsKey(steamId))
								{
									maxusesrem = info.WarpMaxUses.ToString();
								}
								else
								maxusesrem = storedData.maxuses[steamId][info.WarpName].ToString();
								
								SendReply(player, warplist.ToString(), info.WarpName, info.WarpPermissionGroup, info.WarpId, maxusesrem.ToString());
								//SendReply(player, "[color cyan]***********************************************************[color white]");
							}
							
						}
						
						//SendReply(player, "[color cyan]***********[color Yellow]Команда для варпа [color red]/w to Название варпа[color cyan]***********[color white]");
						//SendReply(player, "[color cyan]***********************************************************[color white]");
					break;
					 
					case "add":
					
					if(!player.admin)
					{
						SendReply(player, "Вы не имеете прав на использование этой команды!");
						return;
					}
					if(args.Length != 7)
					{
						SendReply(player, "/w <add> <WarpName> <WarpTimer> <WarpRange> <WarpMaxUses> <WarpPermissionGroup> <Цена>");
						return;
					}   
					foreach(WarpInfo info in storedData.WarpInfo)
					{ 
						if(args[1].ToString().ToLower() == info.WarpName.ToString().ToLower())
						{
							SendReply(player, therealreadyis.ToString());
							return;
						}
					} 
					string permissionp = args[5];
					string name = args[1];
					int warpnum;
					int timerp = Convert.ToInt32(args[2]); 
					int randomr = Convert.ToInt32(args[3]);
					int maxusess = Convert.ToInt32(args[4]);
                    int costs = Convert.ToInt32(args[6]);
                    if (storedData.WarpInfo == null)
					{
						warpnum = 1;
					}
					else
					{
						warpnum = GetNewId();
					}
					var data = new WarpInfo(name, player, timerp, permissionp, warpnum, randomr, maxusess, costs);
					storedData.WarpInfo.Add(data);
					SendReply(player, warpadded, name.ToString());
					Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
					if(!permission.GroupExists(args[5])) permission.CreateGroup(args[5], "", 0);
					cmd.AddChatCommand(name.ToString(), this, "");
					cmd.AddChatCommand(warpnum.ToString(), this, "");
					break;			
					case "help":
					if(player.admin)
					{
						SendReply(player, "[color white] /w list");
						SendReply(player, "[color white] /w <ID или || WarpName>");
					}
					else
					{
						SendReply(player, "[color white] /w list");
						SendReply(player, "[color white] /w <ID или || WarpName>");
					}
					break;
					case "remove":
					if(!player.admin)
					{
						SendReply(player, "Вы не имеете прав на использование этой команды!");
						return;
					}
					if(args.Length != 2) 
					{
						SendReply(player, "/w remove <WarpName>");
						return;
					}
					foreach(WarpInfo info in storedData.WarpInfo)
					{
						if(info.WarpName.ToString() == args[1].ToString())
						{
							storedData.WarpInfo.Remove(info);
							SendReply(player, youhaveremoved, info.WarpName);
							Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
							break;
						}
					}
					break;
					//case "to":
					//break;
					
				}
				if (args[0] != "remove" && args[0] != "add" && args[0] != "help" && args[0] != "" && args[0] != "list" && args[0] != "limit" && args[0] != "wipe")
				{
					if(args.Length != 1)
					{
						SendReply(player, "/w <WarpName> || /warplist");
						return;
					}
					bool wasWarp = false;
					foreach(WarpInfo info in storedData.WarpInfo)
					{ 
						if(info.WarpName.ToString().ToLower() == args[0].ToString().ToLower() || info.WarpId.ToString() == args[0].ToString())
						{
							wasWarp = true;
							if(info.WarpPermissionGroup == "all" || permission.UserHasGroup(steamId.ToString(), info.WarpPermissionGroup))
							{
                                if (!CanTeleport(player) && !player.admin)
                                {
                                    SendReply(player, $"[COLOR # FF0000]Вы не можете телепортироваться находясь в чужом доме!");
                                    return;
                                }

                                if (Int32.Parse(Economy.GetBalance(player.userID).ToString()) < info.WarpCosts)
                                {
                                    SendReply(player, $"[COLOR # FFFFFF]Вам не хватает [COLOR # 00FF00]{info.WarpCosts - Int32.Parse(Economy.GetBalance(player.userID).ToString())}$ [COLOR # FFFFFF]для телепортации!");
                                    return;
                                }

                                if (info.WarpMaxUses > 0)
								{
                                    if (!storedData.maxuses.ContainsKey(steamId))
									{
										storedData.maxuses.Add(
										steamId,
										new Dictionary<string, int>{
											{info.WarpName, 1}
										}
									);
									}

									if(storedData.maxuses[steamId][info.WarpName] == 5)
									{
										SendReply(player, "Вы использовали весь лимит на этот варп!");
										return;
									}

									if(storedData.maxuses.ContainsKey(steamId))
									{
										storedData.maxuses[steamId][info.WarpName] = storedData.maxuses[steamId][info.WarpName] + 1;
									}
								}
                           

                                if (enablecooldown == true) 
								{
									if (storedData.cantele.TryGetValue(steamId, out nextteletime))
									{  
										if(Time.realtimeSinceStartup >= nextteletime)
										{
											
											storedData.cantele[steamId] = Time.realtimeSinceStartup + cooldown;
											Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
											goto Finish;
										} 
										else
										{
											int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
											SendReply(player, youhavetowait, nexttele.ToString());
											return;
										}
									}
									else
									{
										storedData.cantele.Add(steamId, Time.realtimeSinceStartup + cooldown);
										Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
										goto Finish;
									}
								}

								Finish: 
								if(storedData.lastposition.ContainsKey(steamId) |! storedData.lastposition.ContainsKey(steamId))
								{
									storedData.lastposition.Remove(steamId);
									Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
									var cachedVector3 = player.playerClient.lastKnownPosition;
									float x = cachedVector3.x; 
									float y = cachedVector3.y;
									float z = cachedVector3.z;
									var oldinfo = new OldPosInfo(x, y, z);
									storedData.lastposition.Add(steamId, oldinfo);
									Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
									
								}

                                SendReply(player, teleportingto,info.WarpTimer, info.WarpName);
								timer.Once(info.WarpTimer, () => { 
								int posx = UnityEngine.Random.Range(Convert.ToInt32(info.WarpX), info.RandomRange);
								int posz = UnityEngine.Random.Range(Convert.ToInt32(info.WarpZ), info.RandomRange);
								if(info.RandomRange == 0)
								{
									ForcePlayerPos(player, new Vector3(info.WarpX, info.WarpY, info.WarpZ));
								}
								else
									ForcePlayerPos(player, new Vector3(posx, info.WarpY, posz)); 
									SendReply(player, youhaveteleportedto, info.WarpName);
                                    Economy.BalanceSub(player.userID, ulong.Parse(info.WarpCosts.ToString()));

                                    if (info.WarpCosts != 0)
                                     SendReply(player, $"[COLOR # ffffff]Вы заплатили [COLOR # 00FF00]{info.WarpCosts.ToString()}$ [COLOR # ffffff]за телепорт на варп.");
                                });												 
							}
							else
							{
								SendReply(player, "Вам не разрешено использовать этот варп!");
								return; 
							}
						}
					}
					if (!wasWarp)
					{
						SendReply(player, "Варп не найден!");
					}
				}
			}
			void Unloaded() 
			{
				storedData.cantele.Clear();
				Interface.GetMod().DataFileSystem.WriteObject("WarpSystem", storedData);
			}
			
			void ForcePlayerPos(NetUser player, Vector3 xyz)
			{
				var management = RustServerManagement.Get(); 
				management.TeleportPlayerToWorld(player.playerClient.netPlayer, xyz);
			}
	}
}