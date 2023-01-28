/*---------------------------------------------------\
Плагин               :  Daily                        |
Автор                :  Unkown (vk.com/jacksonspain)|
Дата создания        :  27.03.2018                   |
Последнее обновление :  10.04.2018                   |
----------------------------------------------------*/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Oxide.Core;
using RustExtended;
using Oxide.Core.Configuration;

namespace Oxide.Plugins
{
    [Info("Daily", "Freezak", "1.0.0")]
    public class Daily : RustLegacyPlugin
    {
		private Core.Configuration.DynamicConfigFile Data;
		
		// Конфиг
		string chatName = "Ежедневная система";
		string color1 = "[COLOR #ffffff]";
		string color2 = "[COLOR #00ffff]";
		int uberrank = 3;
		////////////////////////////////////
		
		string filename;
		
		bool configChanged = false;
		
		void Init()
		{
			Puts("------------------------------------------------------");
			Puts("Плагин \"Daily\" запущен!");
			Puts("Плагин               :  Daily");
			Puts("Автор                :  Unkown (vk.com/jacksonspain)");
			Puts("Дата создания        :  27.03.2018");
			Puts("Последнее обновление :  21.04.2018");
			Puts("------------------------------------------------------");
		}
		
		void giveitem(NetUser netuser, string name, int count)
        {

            ItemDataBlock ItemOut2 = DatablockDictionary.GetByName(name);
            RustExtended.Helper.GiveItem(netuser.playerClient, ItemOut2, Convert.ToInt32(count));
           
        }
		
		int getUnixDate(){
			return (int)(DateTime.Today - new DateTime(1970, 1, 1)).TotalSeconds;
		}
		
		void execCMD(string Command){
			rust.RunServerCommand(Command);
		}
		
		void OnPlayerConnected(NetUser netuser)
		{
			checkDaily(netuser);
		}
		
		void checkDaily(NetUser netuser){
			string id = netuser.userID.ToString();
			int unixToday = getUnixDate();
			
			filename = string.Format("user-{0}", id);
			Core.Configuration.DynamicConfigFile ConfigurationData = Interface.GetMod().DataFileSystem.GetDatafile(filename);
			
			if(ConfigurationData["d1"] == null && ConfigurationData["d2"] == null && ConfigurationData["d3"] == null && ConfigurationData["d4"] == null && ConfigurationData["d5"] == null && ConfigurationData["d6"] == null && ConfigurationData["d7"] == null && ConfigurationData["ld"] == null && ConfigurationData["nt"] == null)
			{
				int nextTime2 = unixToday + 86400;
				ConfigurationData.Clear();
				ConfigurationData["d1"] = 1;
				ConfigurationData["d2"] = 0;
				ConfigurationData["d3"] = 0;
				ConfigurationData["d4"] = 0;
				ConfigurationData["d5"] = 0;
				ConfigurationData["d6"] = 0;
				ConfigurationData["d7"] = 0;
				ConfigurationData["ld"] = 1;               //last day
				ConfigurationData["nt"] = nextTime2;       //next time
				configChanged = true;
            }
			else{
				string lds = ConfigurationData["ld"].ToString();
				int ldi = Convert.ToInt32(lds);
				string nts = ConfigurationData["nt"].ToString();
				int nexttime = Convert.ToInt32(nts);
					
				string d1s = ConfigurationData["d1"].ToString();
				int d1i = Convert.ToInt32(d1s);
				string d2s = ConfigurationData["d2"].ToString();
				int d2i = Convert.ToInt32(d2s);
				string d3s = ConfigurationData["d3"].ToString();
				int d3i = Convert.ToInt32(d3s);
				string d4s = ConfigurationData["d4"].ToString();
				int d4i = Convert.ToInt32(d4s);
				string d5s = ConfigurationData["d5"].ToString();
				int d5i = Convert.ToInt32(d5s);
				string d6s = ConfigurationData["d6"].ToString();
				int d6i = Convert.ToInt32(d6s);
				string d7s = ConfigurationData["d7"].ToString();
				int d7i = Convert.ToInt32(d7s);
				
				if(nexttime == unixToday){
					if(ldi > 7 || ldi < 1) Puts("Скажи Антону, что он проебался. Условие: (id > 7 || id < 1)");
					UserData userData = Users.GetBySteamID(netuser.userID);
					switch(ldi){
						case 1:
							d2i++;
							ldi++;
							break;
						case 2:
							d3i++;
							ldi++;
							break;
						case 3:
							d4i++;
							ldi++;
							break;
						case 4:
							d5i++;
							ldi++;
							break;
						case 5:
							d6i++;
							ldi++;
							break;
						case 6:
							d7i++;
							ldi++;
							break;
						case 7:
							if(ConfigurationData["lr"] != null){
								execCMD("serv.users " + userData.Username + " rank " + uberrank);
								ConfigurationData["lr"] = null;
							}
							d1i++;
							ldi = 1;
							break;
					}
					nexttime = unixToday + 86400;
					ConfigurationData.Clear();
					ConfigurationData["d1"] = d1i;
					ConfigurationData["d2"] = d2i;
					ConfigurationData["d3"] = d3i;
					ConfigurationData["d4"] = d4i;
					ConfigurationData["d5"] = d5i;
					ConfigurationData["d6"] = d6i;
					ConfigurationData["d7"] = d7i;
					ConfigurationData["ld"] = ldi;
					ConfigurationData["nt"] = nexttime;
					configChanged = true;
				}
				else{
					if(unixToday > nexttime){
						ldi = 1;
						d1i++;
						nexttime = unixToday + 86400;
					}
				}
			}
			if (configChanged)
            {
				Interface.GetMod().DataFileSystem.SaveDatafile(filename);
				configChanged = false;
            }
		}
		
		[ChatCommand("Daily")]
		void cmdDaily(NetUser netuser, string command, string[] args)
		{
			checkDaily(netuser);
			string id = netuser.userID.ToString();
			filename = string.Format("user-{0}", id);
			Core.Configuration.DynamicConfigFile ConfigurationData = Interface.GetMod().DataFileSystem.GetDatafile(filename);
			string lds = ConfigurationData["ld"].ToString();
			int ld = Convert.ToInt32(lds);
			string nts = ConfigurationData["nt"].ToString();
			int nexttime = Convert.ToInt32(nts);
			string d1s = ConfigurationData["d1"].ToString();
			int d1i = Convert.ToInt32(d1s);
			string d2s = ConfigurationData["d2"].ToString();
			int d2i = Convert.ToInt32(d2s);
			string d3s = ConfigurationData["d3"].ToString();
			int d3i = Convert.ToInt32(d3s);
			string d4s = ConfigurationData["d4"].ToString();
			int d4i = Convert.ToInt32(d4s);
			string d5s = ConfigurationData["d5"].ToString();
			int d5i = Convert.ToInt32(d5s);
			string d6s = ConfigurationData["d6"].ToString();
			int d6i = Convert.ToInt32(d6s);
			string d7s = ConfigurationData["d7"].ToString();
			int d7i = Convert.ToInt32(d7s);
			if(args.Length == 0){
				string cd1 = "[color #ff0000]";
				if(d1i > 0) cd1 = "[color #00ff00]";
				
				string cd2 = "[color #ff0000]";
				if(d2i > 0)cd2 = "[color #00ff00]";
				
				string cd3 = "[color #ff0000]";
				if(d3i > 0)cd3 = "[color #00ff00]";
				
				string cd4 = "[color #ff0000]";
				if(d4i > 0)cd4 = "[color #00ff00]";
				
				string cd5 = "[color #ff0000]";
				if(d5i > 0)cd5 = "[color #00ff00]";
				
				string cd6 = "[color #ff0000]";
				if(d6i > 0)cd6 = "[color #00ff00]";
				
				string cd7 = "[color #ff0000]";
				if(d7i > 0)cd7 = "[color #00ff00]";
				
				rust.SendChatMessage(netuser, chatName, color2 + "День 1: " + color1 + "1000 дерева и $1000 " + cd1 +"(Доступно: " + d1s + ")");
				rust.SendChatMessage(netuser, chatName, color2 + "День 2: " + color1 + "1000 метала и $2000 " + cd2 +"(Доступно: " + d2s + ")");
				rust.SendChatMessage(netuser, chatName, color2 + "День 3: " + color1 + "1000 серы   и $3000 " + cd3 +"(Доступно: " + d3s + ")");
				rust.SendChatMessage(netuser, chatName, color2 + "День 4: " + color1 + "1000 пороха и $4000 " + cd4 +"(Доступно: " + d4s + ")");
				rust.SendChatMessage(netuser, chatName, color2 + "День 5: " + color1 + "1 C4 и $5000 " + cd5 +"(Доступно: " + d5s + ")");
				rust.SendChatMessage(netuser, chatName, color2 + "День 6: " + color1 + "2 C4 и $6000 " + cd6 +"(Доступно: " + d6s + ")");
				rust.SendChatMessage(netuser, chatName, color2 + "День 7: " + color1 + "Привилегия UBER до конца дня " + cd7 +"(Доступно: " + d7s + ")");
				rust.SendChatMessage(netuser, chatName, color1 + "Что бы получить бонус используйне " + color2 + "/daily [номер]" + color1 + ".");
				rust.SendChatMessage(netuser, chatName, color1 + "Данный плагин полностью пренадлежит " + color2 + "vk.com/familyrustl" + color1 + ".");
			}
			if(args.Length == 1){
				int day = args[0].ToInt32();
				if(day < 1 || day > 7){
					rust.SendChatMessage(netuser, chatName, color1 + "Неверный номер дня.");
				}
				else{
					bool nodays = false;
					switch(day){
						case 1:
							if(d1i > 0){
								giveitem(netuser, "Wood", 1000);
								RustExtended.Economy.BalanceAdd(netuser.userID, 1000);
								rust.SendChatMessage(netuser, chatName, color1 + "Вы получили " + color2 + "1000 дерева" + color1 + " и " + color2 + "$1000" + color1 + ".");
								d1i--;
							}
							else nodays = true;
							break;
						case 2:
							if(d2i > 0){
								giveitem(netuser, "Metal Fragments", 1000);
								RustExtended.Economy.BalanceAdd(netuser.userID, 2000);
								rust.SendChatMessage(netuser, chatName, color1 + "Вы получили " + color2 + "1000 метала" + color1 + " и " + color2 + "$2000" + color1 + ".");
								d2i--;
							}
							else nodays = true;
							break;
						case 3:
							if(d3i > 0){
								giveitem(netuser, "Sulfur", 1000);
								RustExtended.Economy.BalanceAdd(netuser.userID, 3000);
								rust.SendChatMessage(netuser, chatName, color1 + "Вы получили " + color2 + "1000 серы" + color1 + " и " + color2 + "$3000" + color1 + ".");
								d3i--;
							}
							else nodays = true;
							break;
						case 4:
							if(d4i > 0){
								giveitem(netuser, "Gunpowder", 1000);
								RustExtended.Economy.BalanceAdd(netuser.userID, 4000);
								rust.SendChatMessage(netuser, chatName, color1 + "Вы получили " + color2 + "1000 пороха" + color1 + " и " + color2 + "$4000" + color1 + ".");
								d4i--;
							}
							else nodays = true;
							break;
						case 5:
							if(d5i > 0){
								giveitem(netuser, "Explosive Charge", 1);
								RustExtended.Economy.BalanceAdd(netuser.userID, 5000);
								rust.SendChatMessage(netuser, chatName, color1 + "Вы получили " + color2 + "1 С4" + color1 + " и " + color2 + "$5000" + color1 + ".");
								d5i--;
							}
							else nodays = true;
							break;
						case 6:
							if(d6i > 0){
								giveitem(netuser, "Explosive Charge", 2);
								RustExtended.Economy.BalanceAdd(netuser.userID, 6000);
								rust.SendChatMessage(netuser, chatName, color1 + "Вы получили " + color2 + "2 С4" + color1 + " и " + color2 + "$6000" + color1 + ".");
								d6i--;
							}
							else nodays = true;
							break;
						case 7:
							if(d7i > 0){
								UserData userData = Users.GetBySteamID(netuser.userID);
								int rank = userData.Rank;
								if(rank < uberrank){
									execCMD("serv.users " + userData.Username + " rank " + uberrank);
									ConfigurationData["lr"] = rank;
									d7i--;
								}
								else{
									rust.SendChatMessage(netuser, chatName, color1 + "Ваша привилегия и так " + color2 + "UBER " + color1 + "или выше.");
								}
							}
							else nodays = true;
							break;
					}
					if(nodays) rust.SendChatMessage(netuser, chatName, color1 + "Вам недоступен этот бонус!");
					else{
						ConfigurationData.Clear();
						ConfigurationData["ld"] = ld;
						ConfigurationData["nt"] = nexttime;
						ConfigurationData["d1"] = d1i;
						ConfigurationData["d2"] = d2i;
						ConfigurationData["d3"] = d3i;
						ConfigurationData["d4"] = d4i;
						ConfigurationData["d5"] = d5i;
						ConfigurationData["d6"] = d6i;
						ConfigurationData["d7"] = d7i;
						Interface.GetMod().DataFileSystem.SaveDatafile(filename);
					}
				}
			}
			if(args.Length > 1){
				rust.SendChatMessage(netuser, chatName, color1 + "Вы неверно ввели команду. Используйте " + color2 + "/daily " + color1 + "для просмотра информации.");
			}
		}
		
		protected override void LoadDefaultConfig(){}
	}
}
/*
--------------------------------------------------------------------------------------------— 
Человек пишет команду /daily И выскакивает тест с описанием 
1 день 1000 дерева и 1000 баланса 
2 День 1000 металлlи 2000 баланса 
3 День 1000 Сульфура и 3000 баланса 
4 день 1000 Пороха и 4000 баланса 
5 День С4 1шт и 5000 
6 День с4 2шт и 6000 
7 День Привилегия UBER 1дн 
Вы можете забрать "И тут то что он может взять" 
Что бы забрать воспользуйтесь командой /daily "Номер" 
----------------------------------------------------------------------------------------------

День 1: 1000 дерева и $1000 (Недоступно)
День 1: 1000 дерева и $1000 (Доступно)
День 1: 1000 дерева и $1000 (Доступно: 2)

*/