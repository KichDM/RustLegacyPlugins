/* черти которые пиздят плагин,идите нахуй!!!
Я ебусь с ним уже 6-ой час и блять тупо сосите если будете его сливать
Вы не люди */

using System.Collections.Generic;
using System;
using System.Text;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using RustExtended;
using System.Text.RegularExpressions;

#pragma warning disable 0618

namespace Oxide.Plugins
{
    [Info("M73UniverseYouTuber", "Mixxe73", "1.4.1")]
	[Description("Я люблю сервер The Universe of Rust ♥")]
    class M73UniverseYouTuber : RustLegacyPlugin 
	{
		/* Ранг который будет выдаваться игроку */
		int SubscribeRank = 2;
		
		/* Сколько $ будет платить ютуберу(партнеру) */
		ulong PartnerPay = 399;
		
		/* Стим ид ютубера(партнера) которому будут отправляться деньги */
		ulong PartnerSteamID = 76561197960538894;
		
		/* Отображаемый ранг в чате */
		string SubscribeName = "Подписота";
		
		/* Тэг плагина */
		string Tag = "Бонус от Мирного";


									/* Вещи который будут выдаваться */
        static object[][] equipment = new object[][]
        {
            //            Тип ячейки инвентаря          Название предмета       Количество
            //           [Belt, Armor, Default]                 -                 1-250

            new object[]{ Inventory.Slot.Kind.Default,     "Revolver",                 1   },
            new object[]{ Inventory.Slot.Kind.Default,     "9mm Ammo",             100  },
            new object[]{ Inventory.Slot.Kind.Default,     "Large Medkit",         5   },
			new object[]{ Inventory.Slot.Kind.Default,     "Wood",         250   },
			new object[]{ Inventory.Slot.Kind.Default,     "Sulfur",         125   },
			new object[]{ Inventory.Slot.Kind.Default,     "Metal Fragments",         125   },
			new object[]{ Inventory.Slot.Kind.Default,     "Sulfur",         125   },
			new object[]{ Inventory.Slot.Kind.Default,     "Low Grade Fuel",         12   },
			new object[]{ Inventory.Slot.Kind.Default,     "Low Quality Metal",         10   }
        };

		/* Не трогать!!! Требуется для вып. комманд сервера
		(Есть возсожность сделать без execCMD, но придется переписывать выдачу ранга пользователю)		*/
		void execCMD(string Command){
			rust.RunServerCommand(Command);
		}
	
		[ChatCommand("mirnyy")]
		void SubscribeCommand(NetUser netUser, string message)
		{
		UserData userData = Users.GetBySteamID(netUser.userID); //Записываем стим ид
							int rank = userData.Rank; //Записываем ранг		
								if(rank < SubscribeRank){
									rust.SendChatMessage(netUser, Tag, $"Поздравляем тебя! Ты стал обладателем привилегии <{SubscribeName}>");
									rust.SendChatMessage(netUser, Tag, "Советуем вам заглянуть в инвентарь ツ");
									rust.SendChatMessage(netUser, Tag, "Не забывай поставить лайкосик под стрим!");	
									//ВЫДАЧА РАНГА
									execCMD("serv.users " + netUser.userID + " rank " + SubscribeRank);
									
									//ВЫДАЧА ВЕЩЕЙ
						var inv = netUser.playerClient.controllable.controller.character.GetComponent<PlayerInventory>();
								foreach (object[] arr in equipment)
								{
									if (arr == null || arr.Length != 3) continue;
									ItemDataBlock item = DatablockDictionary.GetByName((string)arr[1]);
									Inventory.Slot.Preference slot = Inventory.Slot.Preference.Define((Inventory.Slot.Kind)arr[0]);
									Helper.GiveItem(inv, item, slot, (int)arr[2], -1);
									// UPD (08.05.2020): Понял что лучше сделать через void, но пока что работает и ладно.Нужно будет подлатать это)       
								}
								
					//выдача бонуса партнеру
						RustExtended.Economy.BalanceAdd(PartnerSteamID, PartnerPay); //выдача денег партнеру
								}
								else{
									rust.SendChatMessage(netUser, Tag, "К сожадению мы не можем выдать вам привилегию(");	
									rust.SendChatMessage(netUser, Tag,$"Ваша привилегия и так <{SubscribeName}> или выше.");
								}	
		}
	}
}