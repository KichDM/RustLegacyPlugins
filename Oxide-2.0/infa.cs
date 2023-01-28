using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;

#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("Infa ", "KoT", "0.0.6")]
    class Infa  : RustLegacyPlugin 
	 
	{
  
	[ChatCommand("kitranks")]
			void kitranks(NetUser netuser, string command, string[] args)
			{				
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Привилегия [COLOR#1AEF38]VIP [COLOR#FFFFFF](80 руб[COLOR#1AEF38]/[COLOR#FFFFFF]7дн) (170 руб[COLOR#1AEF38]/[COLOR#FFFFFF]30дн) ");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit vip [COLOR#1AEF38](3 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit farm [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit gunV [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit help [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Привилегия [COLOR#1AEF38]Lord [COLOR#FFFFFF](130 руб[COLOR#1AEF38]/[COLOR#FFFFFF]7дн) (290 руб[COLOR#1AEF38]/[COLOR#FFFFFF]30дн) "); 
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit lord [COLOR#1AEF38](4 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit res [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit air [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit gunL [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit help [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit pipe [COLOR#1AEF38](1 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Привилегия [COLOR#1AEF38]BOSS [COLOR#FFFFFF](250 руб[COLOR#1AEF38]/[COLOR#FFFFFF]10 дн) (500 руб[COLOR#1AEF38]/[COLOR#FFFFFF]30дн) "); 
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /[ Наборы | Донат ] лорда,кроме /kit lord,/kit gunL [COLOR#1AEF38]");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit boss [COLOR#1AEF38](6 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit ammo [COLOR#1AEF38](12 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit boom [COLOR#1AEF38](24 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] /kit gunB [COLOR#1AEF38](3 час)");
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Привилегия [COLOR#1AEF38]WILD [COLOR#FFFFFF](1000 руб[COLOR#1AEF38]/[COLOR#FFFFFF]30 дн)"); 
	rust.SendChatMessage(netuser, "[ Наборы | Донат ]", "[COLOR#FFFFFF] О доступных китах можно узнать в группе в обсуждении Донат [COLOR#1AEF38]");
			}
			[ChatCommand("kits")]
			void kits(NetUser netuser, string command, string[] args)
			{				
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#FFFFFF]/[COLOR#1AEF38]Kit Starter [color#00ffff][color#00ffff]-> [COLOR#FFFFFF]набор новичка [COLOR#1AEF38](30 мин)"); 
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Hatchet [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Cloth одежда [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Hunting Bow [COLOR#1AEF38]1шт [COLOR#FFFFFF]и Arrow [COLOR#1AEF38]30шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Camp Fire [COLOR#1AEF38]2шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Small Medkit [COLOR#1AEF38]3шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#FFFFFF]/[COLOR#1AEF38]Kit Home [color#00ffff]-> [COLOR#FFFFFF]набор для дома [COLOR#1AEF38](24 час)"); 
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Дом [COLOR#1AEF38] 1х1");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Bed [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Metal Door [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Workbench [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Furnace [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Camp Fire [COLOR#1AEF38]2шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Large Wood Storage [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#FFFFFF]/[COLOR#1AEF38]Kit Bonus [color#00ffff]-> [COLOR#FFFFFF]бонус набор [COLOR#1AEF38](24 час)"); 
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Pick Axe [COLOR#1AEF38]1шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Pipe Shotgun [COLOR#1AEF38]1шт [COLOR#FFFFFF]и Handmade Shell [COLOR#1AEF38]30шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Small Medkit [COLOR#1AEF38]5шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#1AEF38]➭ [COLOR#FFFFFF]Cooked Chicken Breast [COLOR#1AEF38]5шт");
	rust.SendChatMessage(netuser, "[ Наборы ]", "[COLOR#FFFFFF] /[COLOR#1AEF38]KitRanks [color#00ffff]-> [COLOR#FFFFFF]Узнать наборы и стоимость привилегий ");
			}			
			[ChatCommand("ob")]
			void ob(NetUser netuser, string command, string[] args)
			{				
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#33FFED]➭  [COLOR#FFFFFF]Охота за листовками [COLOR#33FFED] ✉ "); 
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#FFFFFF]/[COLOR#33FFED]obm [COLOR#FFFFFF]- Metal Fragments [COLOR#33FFED]x50 [COLOR#FFFFFF]= [COLOR#33FFED]10 [COLOR#FFFFFF]Paper");
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#FFFFFF]/[COLOR#33FFED]obp [COLOR#FFFFFF]- P250 [COLOR#33FFED]x1 [COLOR#FFFFFF]и 9mm Ammo [COLOR#33FFED]x30 [COLOR#FFFFFF]= [COLOR#33FFED]20 [COLOR#FFFFFF]Paper");
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#FFFFFF]/[COLOR#33FFED]obmp [COLOR#FFFFFF]- MP5A4 [COLOR#33FFED]x1 [COLOR#FFFFFF]и 9mm Ammo [COLOR#33FFED]x50 [COLOR#FFFFFF]= [COLOR#33FFED]40 [COLOR#FFFFFF]Paper");
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#FFFFFF]/[COLOR#33FFED]obm4 [COLOR#FFFFFF]-M4 [COLOR#33FFED]x[COLOR#FFFFFF]1 [COLOR#FFFFFF]и 556 Ammo [COLOR#33FFED]x50 [COLOR#FFFFFF]= [COLOR#33FFED][COLOR#FFFFFF]60 Paper");
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#FFFFFF]/[COLOR#33FFED]obb [COLOR#FFFFFF]- Bolt Action Rifle [COLOR#33FFED]x1 [COLOR#FFFFFF]и 556 Ammo [COLOR#33FFED]x50 [COLOR#FFFFFF]= [COLOR#33FFED]80 [COLOR#FFFFFF]Paper "); 
	rust.SendChatMessage(netuser, "[ Обмен ]", "[COLOR#FFFFFF]/[COLOR#33FFED]obc4 [COLOR#FFFFFF]- Exposive Charge [COLOR#33FFED]x5 [COLOR#FFFFFF]= [COLOR#33FFED]150 [COLOR#FFFFFF]Paper");
			}			
			[ChatCommand("rules")]
			void rules(NetUser netuser, string command, string[] args)
			{				
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#33FFED]➭  [COLOR#FFFFFF]Основные [ Правила ],которые нужно соблюдать,чтобы не получить бан  [COLOR#33FFED]✓"); 
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#33FFED]1.5 [COLOR#FFFFFF]Запрещено закрывать проход в дом.Допускается баррикада 1-2шт. [COLOR#33FFED]Наказание[COLOR#FFFFFF]: бан 1-5ч");
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#33FFED]1.6 [COLOR#FFFFFF]Запрещено засыпать под фундаментом. [COLOR#33FFED]Наказание[COLOR#FFFFFF]: удаление слипера");
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#33FFED]1.8 [COLOR#FFFFFF]Запрещено сидеть в печке,в животных,ломать кровати багом. Наказание[COLOR#FFFFFF]: бан 3-24ч");
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#33FFED]1.9 [COLOR#FFFFFF]Запрещено набирать участников в клан багом. [COLOR#33FFED]Наказание[COLOR#FFFFFF]: Расформирование клана.");
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#FFFFFF]Запомнить! Игрок,не заходивший в игру 3 и более дней теряет свое имущество.");
	rust.SendChatMessage(netuser, "[ Правила ]", "[COLOR#33FFED]Предупреждайте администратора [COLOR#FFFFFF]✐");	
			}
			
}
}
