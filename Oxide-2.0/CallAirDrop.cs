using System.Collections.Generic;

using System;

using System.Reflection;

using System.Data;

using UnityEngine;

using RustExtended;

using Oxide.Core;

using Oxide.Core.Plugins;

using Oxide.Core.Configuration;

using Rust;



namespace Oxide.Plugins

{

    [Info("CallAirDrop", "Buratchuk(143)", "2.3.1")]

	[Description("Вызов дропа игроками за валюту + админ управление + уведомление")]

    class CallAirDrop : RustLegacyPlugin

    {

		[PluginReference]

        Plugin Location;

		// Plugin SRaidBlock;

        Vector3 cachedPos;

		string chatName = 	"Rust Dark";	//Префикс в чате

		int timeForCD = 	7200;		//Время перезарядки вызова самолета в секундах (3600 = 1 час)

		ulong mini = 		15000;		//Стоимость вызова в случайную точку на карте

		ulong map = 		7500;		//Стоимость вызова в случайную точку на карте

		ulong me = 			10000;		//Стоимость вызова себе

		ulong player = 		15000;		//Стоимость вызова по нику



		//Работа с файлами

		private const string PluginDataName = "CallAirDrop";

		

		void Loaded()

        {

			Core.Configuration.DynamicConfigFile CalledUser = Interface.GetMod().DataFileSystem.GetDatafile(PluginDataName);

			Core.Configuration.DynamicConfigFile CalledName = Interface.GetMod().DataFileSystem.GetDatafile(PluginDataName);

			if(CalledUser["CoolDown"] == null) {CalledUser["CoolDown"] = (Convert.ToInt32(DateTime.Now) - timeForCD).ToString();Puts("Set /air CoolDown = "+CalledUser["CoolDown"]);}

			if(CalledName["LastCall"] == null) {CalledName["LastCall"] = "XBOCT";Puts("Set /air Last Player Call = "+CalledName["LastCall"]);}

			SavePluginData();

        }

		

		void SavePluginData(){Interface.GetMod().DataFileSystem.SaveDatafile(PluginDataName);}

		

		void HelpAirCalls(NetUser netuser, DateTime curenttime, DateTime lastusertime){

			rust.SendChatMessage(netuser, chatName, "[color #1AEF38]✈[color #FFFFFF]Вызов [COLOR#FFFF00]Самолета с лутом:");

			rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air mini [color #FFFFFF]Тихой дроп, самолета нету - [color #DAA520]Цена: "+mini+" [color #FF0000]NEW");

			rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air map [color #FFFFFF]Вызвать самолет в случайное место - [color #DAA520]Цена: "+map);

			rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air call [color #FFFFFF]Вызвать себе самолет - [color #DAA520]Цена: "+me);

			rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air [ник] [color #FFFFFF]Вызвать игроку самолет -[color #DAA520]Цена: "+player);

			if(netuser.CanAdmin()){

				rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air cancel [color #FFFFFF]Отменить летящие самолеты [color #00FF00]([color #FF0000]Администратор[color #00FF00])");

				rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air destroy [color #FFFFFF]Уничтожить все дропы [color #00FF00]([color #FF0000]Администратор[color #00FF00])");

				rust.SendChatMessage(netuser, chatName, "[COLOR#FFFF00]➤ [COLOR#4682B4]/air wipe [color #FFFFFF]Сбросить перезарядку [color #00FF00]([color #FF0000]Администратор[color #00FF00])");

			}

			if(curenttime > lastusertime) {

				rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Перезарядки [color #1AEF38]нет [color #FFFFFF]можно [color #1AEF38]вызвать снабжение✈");

			} else {

				int amount = (int)(lastusertime - DateTime.Now).TotalSeconds;

				int min = amount / 60;

				int sec = amount - min * 60;

				string timeString = "";

				if(min > 0){timeString = " " + min.ToString() + " мин. " + sec.ToString() + " сек.";}

				else{timeString = " " + sec.ToString() + " сек.";}

				rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Перезарядка [color #FF0000]есть [color #FFFFFF]ждать еще: [color #1AEF38]"+timeString);

			}

			return;

		}

		

		void OnAirdrop(Vector3 targetposition)

		{

            string location = string.Empty;

            if(Location != null)

            {

                location = Location.Call("FindLocationName", targetposition) as string;

                if(location != null)

                {

                    location = " около " + location;

                }

            }

			foreach(PlayerClient player in PlayerClient.All)

			{

				var direction = GetDirection(targetposition, player.lastKnownPosition);

				var currentmessage = "Дроп примерно в "+Math.Ceiling(Math.Abs(Vector3.Distance(targetposition, player.lastKnownPosition))).ToString()+" метров"+direction+" от вас"+location;

				Notice.Popup(player.netPlayer, "✈", "Внимание: " + currentmessage, 20);

			}

		}

		

        string GetDirection(Vector3 targetposition, Vector3 playerposition)

        {

            if (Vector3.Distance(targetposition, playerposition) < 10) return string.Empty;

            string northsouth;

            string westeast;

            string direction = string.Empty;

            if (playerposition.x < targetposition.x)

                northsouth = " на Юг";

            else

                northsouth = " на Север";

            if (playerposition.z < targetposition.z)

                westeast = " на Восток";

            else

                westeast = " на Запад";

            var diffx = Math.Abs(playerposition.x - targetposition.x);

            var diffz = Math.Abs(playerposition.z - targetposition.z);

            if (diffx / diffz <= 0.5) direction = westeast;

            if (diffx / diffz > 0.5 && diffx / diffz < 1.5) direction = northsouth + "-" + westeast;

            if (diffx / diffz >= 1.5) direction = northsouth;

            return direction;

        }

		

        [ChatCommand("drop")] //Команда вызова

        void cmdCallAirDrop(NetUser netuser, string command, string[] args)

        {

			// if (SRaidBlock?.CallHook("IsPlayerBlocked", netuser.userID) is bool && (bool)SRaidBlock?.CallHook("IsPlayerBlocked", netuser.userID)) return;

			Core.Configuration.DynamicConfigFile CalledUser = Interface.GetMod().DataFileSystem.GetDatafile(PluginDataName);

			Core.Configuration.DynamicConfigFile CalledName = Interface.GetMod().DataFileSystem.GetDatafile(PluginDataName);

			DateTime curenttime = DateTime.Now;

			DateTime lastusertime = DateTime.Parse(CalledUser["CoolDown"].ToString());

			ulong money = RustExtended.Economy.GetBalance(netuser.userID);

			// Проверяем аргументы

			if(args.Length == 0){HelpAirCalls(netuser, curenttime, lastusertime);}

			if(args.Length == 1)

			{

				if(curenttime > lastusertime)

				{

					if (args[0].ToString() == "map")// Случайную точку

					{

						 if (money < map)

						{

							ulong ost = map - money;

							rust.SendChatMessage(netuser, chatName, "[color #8B4513]Вам не хватает: [color #F5DEB3]"+ost+"[color #8B4513]. У вас: [color #F5DEB3]"+money);

							Puts(netuser.displayName + " Попытался вызвать случайный дроп. Не хватает: "+ost+" Р. Денег всего: "+money+" Р.");

							return;

						} else {

							 RustExtended.Economy.BalanceSub(netuser.userID, map);

							rust.SendChatMessage(netuser, chatName, "[COLOR#FFFFFF]Смотрите в оба, [COLOR#1AEF38]самолет уже летит!");

							SupplyDropZone.CallAirDrop();

							Puts(netuser.displayName + " Вызвал дроп в случайную точку. Денег осталось: " +money);

							lastusertime = DateTime.Now.AddSeconds(timeForCD);

							string timeleft = lastusertime.ToString();

							CalledUser["CoolDown"] = timeleft;

							CalledName["LastCall"] = netuser.displayName.ToString();

							SavePluginData();

							Puts("Дроп вызван, новая дата записана: "+timeleft);

							return;

						}

					}



					if (args[0].ToString() == "call")// Вызвать себе

					{

						if (money < me)

						{

							ulong ost = me - money;

							rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Вам [color #FF0000]не хватает: [color #1AEF38]"+ost+"[color #FFFFFF]. У вас: [color #1AEF38]" +money);

							Puts(netuser.displayName + " [color #FFFFFF]Попытался вызвать дроп себе.[color #FF0000] Не хватает:[color #1AEF38] "+ost+".[color #FFFFFF] Денег всего:[color #1AEF38]"+ money);

							return;

						} else {

							RustExtended.Economy.BalanceSub(netuser.userID, me);

							cachedPos = netuser.playerClient.lastKnownPosition;

							if(cachedPos != default(Vector3))

							{

								SupplyDropZone.CallAirDropAt(cachedPos);

								rust.SendChatMessage(netuser, chatName, "[color #1AEF38]✈[color #FFFFFF]Самолет уже вылетел [color #1AEF38]ожидайте на месте!");

								Puts(netuser.displayName + " Вызвал себе дроп. Денег осталось: "+money);

								lastusertime = DateTime.Now.AddSeconds(timeForCD);

								string timeleft = lastusertime.ToString();

								CalledUser["CoolDown"] = timeleft;

								CalledName["LastCall"] = netuser.displayName.ToString();

								SavePluginData();

								Puts("Дроп вызван, новая дата записана: "+timeleft);

								return;

							}

						}

					}

					

					if (args[0].ToString() == "mini")// Мини дроп

					{

						if (money < mini)

						{

							ulong ost = mini - money;

							rust.SendChatMessage(netuser, chatName, "[color #8B4513]Вам не хватает: [color #F5DEB3]"+ost+"[color #8B4513]. У вас: [color #F5DEB3]" +money);

							Puts(netuser.displayName + " Попытался вызвать дроп себе. Не хватает: "+ost+". Денег всего:"+ money);

							return;

						} else {

							RustExtended.Economy.BalanceSub(netuser.userID, mini);

							cachedPos = netuser.playerClient.lastKnownPosition;

							if(cachedPos != default(Vector3))

							{

								SupplyDropZone.CallAirDropAt(cachedPos);

								Vector3 dropPosition = cachedPos + new Vector3(UnityEngine.Random.Range(-5f, 5f), RustExtended.Core.AirdropHeight, UnityEngine.Random.Range(-5f, 5f));

								UnityEngine.GameObject supplyCrate = NetCull.InstantiateClassic("SupplyCrate", dropPosition, Quaternion.Euler(new Vector3(0f, UnityEngine.Random.Range(0f, 360f), 0f)), 0);

								supplyCrate.rigidbody.centerOfMass = new Vector3(0f, -1.5f, 0f);



								rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Дроп уже над головой [color #1AEF38]самолет не нужен!");

								Puts(netuser.displayName + " [color #FFFFFF]Вызвал себе[color #1AEF38] Мини-Дроп.[color #FFFFFF] Денег осталось [color #1AEF38] "+money);

								lastusertime = DateTime.Now.AddSeconds(timeForCD/2);

								string timeleft = lastusertime.ToString();

								CalledUser["CoolDown"] = timeleft;

								CalledName["LastCall"] = netuser.displayName.ToString();

								SavePluginData();

								Puts("Дроп вызван, новая дата записана: "+timeleft);

								return;

							}

						}

					}



					if (money < player)// Вызвать игроку

					{

						ulong ost = player - money;

						rust.SendChatMessage(netuser, "[color #8B4513]Вам не хватает: [color #FF6347]"+ost+ "[color #8B4513]. У вас: [color #FF6347]"+money);

						Puts(netuser.displayName + "Попытался вызвать дроп себе. Не хватает: "+ost+". Денег всего: "+money);

						return;

					} else {

						NetUser targetuser = rust.FindPlayer(args[0]);

						UserData userData = Users.GetBySteamID(targetuser.playerClient.userID);

						if (userData.Zone != null && userData.Zone.Flags.Has(ZoneFlags.events))

						{

							rust.SendChatMessage(netuser, "[color red]Игрок на евенте и не момжет принять снабжение!");

						} else {

							RustExtended.Economy.BalanceSub(netuser.userID,player);

							if (targetuser != null)

							{

								cachedPos = targetuser.playerClient.lastKnownPosition;

								if(cachedPos != default(Vector3))

								{

									SupplyDropZone.CallAirDropAt(cachedPos);

									rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Вы вызвали снабжение для [color #1AEF38] Игрока"+targetuser.playerClient.userName.ToString());

									rust.SendChatMessage(targetuser, chatName, "[color #FFFFFF]Похоже у вас сегодня праздник, игрок [color #1AEF38]"+netuser.playerClient.userName.ToString()+" [color #FFFFFF]вызвал вам снабжение!");

									Puts(netuser.displayName + " Вызвал дроп для "+targetuser+". Денег осталось: "+money);

									lastusertime = DateTime.Now.AddSeconds(timeForCD);

									string timeleft = lastusertime.ToString();

									CalledUser["CoolDown"] = timeleft;

									CalledName["LastCall"] = netuser.displayName.ToString();

									SavePluginData();

									Puts("Дроп вызван, новая дата записана: "+timeleft);

									return;

								}

							} else {

								rust.SendChatMessage(netuser, "[color #FFFFFF]В игре такого игрока нет!");//Неверный аргумент

								return;

							}

						}

					}

				} else {

					int amount = (int)(lastusertime - DateTime.Now).TotalSeconds;

					int min = amount / 60;

					int sec = amount - min * 60;

					string timeString = "";

					if(min > 0){timeString = " "+min.ToString()+" мин. "+sec.ToString()+" сек.";}

					else{timeString = " "+sec.ToString()+" сек.";}

					rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Снабжение[color #FF0000] не готово,[color #FFFFFF] ожидайте еще: [color #1AEF38]"+timeString);

					Puts(netuser.displayName + " [COLOR#FFFFFF]Попытался вызвать дроп. Но вызов на[COLOR#FF0000] перезарядке,[COLOR#1AEF38] ждать еще: "+timeString+"; Последнее использование было: "+lastusertime+"; Игроком: "+CalledName["LastCall"]);

				}

				if(netuser.CanAdmin())

				{

					if(args[0].ToString() == "wipe")

					{

						lastusertime = DateTime.Now;

						rust.SendChatMessage(netuser, chatName, "[COLOR#FFFFFF]Перезарядка[COLOR#1AEF38] сброшена!");

						Puts("Админ:[COLOR#1AEF38] "+netuser.displayName + "[COLOR#FFFFFF] обнулил перезарядку дропа: "+lastusertime);

						string timeleft = lastusertime.ToString();

						CalledUser["CoolDown"] = timeleft;

						CalledName["LastCall"] = netuser.displayName.ToString();

						SavePluginData();

						return;

					}

					if(args[0].ToString() == "cancel")

					{

						int planenumber = 0;

						foreach(SupplyDropPlane plane in UnityEngine.Resources.FindObjectsOfTypeAll<SupplyDropPlane>())

						{

							if(plane.gameObject.name == "C130") continue;

							planenumber++;

							plane.NetDestroy();

						}

						rust.SendChatMessage(netuser, chatName, planenumber.ToString()+" самолётов [COLOR#FF0000] отменено...");

						return;

					}

					if(args[0].ToString() == "destroy")

					{

						int cratenumber = 0; 

						foreach(SupplyCrate crate in UnityEngine.Resources.FindObjectsOfTypeAll<SupplyCrate>())

						{

							if(crate.gameObject.name == "SupplyCrate") continue;

							cratenumber++;

							NetCull.Destroy(crate.gameObject);

						}

						rust.SendChatMessage(netuser, chatName, cratenumber.ToString()+" ящиков было уничтожено...");

						return;

					}

				} else {rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Эта команда для вас[COLOR#FF0000] не доступна!");return;}

			}

			if(args.Length > 1){rust.SendChatMessage(netuser, chatName, "[color #FFFFFF]Что-то [COLOR#FF0000]не правильно[color #FFFFFF] написал.");}

		}

    }

}