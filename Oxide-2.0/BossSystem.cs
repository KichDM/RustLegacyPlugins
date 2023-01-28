using System;
using System.Linq;
using Oxide.Core;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using RustExtended;
#pragma warning disable 0618

namespace Oxide.Plugins
{

	[Info("BossSystem", "Freezak & Mixxe73", "2.2.0")]
	class BossSystem : RustLegacyPlugin
	{
		public static string PermissionNotAllowed = "{color_main}У вас нет прав для использование данной команды!";
		public static string Tag = "Авто-Инвент";
		////////////////////////////////////
		int minHealthNPC = 2800;
		int maxHealthNPC = 3000;
		
        int minPayment = 5800; 
		int maxPayment = 8500;
		////////////////////////////////////
        float KDTime = 360000000000f;
		float InvTime = 24000000000f;
		/////////////////////////////////////
		int Payment; //Запись приза
		int HealthNPC; //Запись хп НПС
		bool ER = false;
		bool SpawnNPS = false;
		////////////////////////////////////
		string color_main = "[COLOR #FFFFFF]";
        string color_double = "[COLOR #C8FE2E]";
		////////////////////////////////////
		public static Transform position;
		public static GameObject go;
		public static TakeDamage damage;

		List<TakeDamage> takeDmg = new List<TakeDamage>();

		void Loaded()
		{
			if (!permission.PermissionExists("bosssystem.canboss")) permission.RegisterPermission("bosssystem.canboss", this);
			
			timer.Repeat(KDTime, 0, () =>
            {			
                timer.Once(InvTime, () =>
                {
                    if (ER)
                    {
                        Broadcast.MessageAll($"{color_main}Инвент {color_double}<Босс-Мутант> {color_main}окончен.Причина: {color_double}время вышло", Tag);
						Broadcast.MessageAll($"{color_main}Следующий инвент через {color_double}{KDTime - InvTime} секунд", Tag);
                        ER = false;
                    }
                });

                StartEventBoss();
            });
		}
		
		void KilledNPC()
		{
			
		}
		
		void StartEventBoss()
        {
			ER = true;
			//SpawnPrefab//
			go = NetCull.InstantiateDynamic(":mutant_wolf", new Vector3(6742.57f, 332.84f, -4345.28f), Quaternion.identity);
			HealthNPC = Core.Random.Range(minHealthNPC, maxHealthNPC);
			//Message//
			string text = $"{color_main}На карте появился сильный и злобный мутант";
			string text2 = $"{color_main}Примерное местонахождение: {color_double}Ангар";
			string text3 = $"{color_main}Количество жизней:{color_double}{HealthNPC}HP";
				Broadcast.MessageAll(text, Tag);
				Broadcast.MessageAll(text2, Tag);
				Broadcast.MessageAll(text3, Tag);
			//Pos//
			position = go.GetComponent<Transform>();
			//Damage//
			damage = go.GetComponent<TakeDamage>();
			takeDmg.Add(damage);
			///////////////////////////////////////////////////////////////////////////////////////
			damage._maxHealth = (float)HealthNPC;
			damage._health = damage._maxHealth;
			Payment = Core.Random.Range(minPayment, maxPayment);
        }

		bool hasAccess(NetUser netuser, string permissionname)
		{
			if (netuser.CanAdmin()) return true;
			return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
		}

		public static string NiceName(string input)
		{
			input = input.Replace("_A", "").Replace("A(Clone)", "").Replace("(Clone)", "");
			MatchCollection Matchs = new Regex("([A-Z]*[^A-Z_]+)", RegexOptions.Compiled).Matches(input);
			string[] Result = new string[Matchs.Count];
			for (int i = 0; i < Result.Length; i++) Result[i] = Matchs[i].Groups[0].Value.Trim();
			return String.Join(" ", Result);
		}

		void OnKilled(TakeDamage damage, DamageEvent evt)
		{
			PlayerClient killer = evt.attacker.client;

			var ai = evt.victim.character?.GetComponent<TakeDamage>();

			if (ai != null && takeDmg.Contains(ai))
			{
				takeDmg.Remove(ai);
				//AirDrop - DropSpawn - addmoney//
				var boss_ai = NetCull.InstantiateStatic("SupplyCrate", new Vector3(position.transform.position.x, position.transform.position.y + 180f, position.transform.position.z), Quaternion.identity);
				ulong payment = (ulong) Payment;					
                    Economy.Get(killer.userID).Balance += payment;
				//Message//
				rust.SendChatMessage(killer.netUser, Tag, $"{color_main}Поздравляем тебя! Приз: {color_double}Аир-Дроп (Посмотри вверх)");
				rust.SendChatMessage(killer.netUser, Tag, $"{color_main}Твоя выйгрыш составляет: {color_double}{Payment}");	
				string text = $"{color_main}Победителем инвента {color_double}<Босс-Мутант> {color_main}становится {color_double}{killer.netUser.displayName}";
				string text2 = $"{color_main}Его заработок составил {color_double}{Payment}";
				string text3 = $"{color_main}У вас есть шанс отобрадь у него главный приз - {color_double}Аир-Дроп";
				Broadcast.MessageAll(text, Tag);
				Broadcast.MessageAll(text2, Tag);
				Broadcast.MessageAll(text3, Tag);
				//////////////////////////////////////////////////////////////////////////////////
				ER = false;
				rust.Notice(killer.netUser, "Твой подарочек летик к тебе ツ ", "↑", 5f);
			}
		}

		[ChatCommand("deagleeeeeee123123812397ckkckkkfkkfkkf")]
		void cmdCharacter(NetUser netuser, string command, string[] args)
		{
			if (!hasAccess(netuser, "bosssystem.canboss") && netuser.CanAdmin()) { SendReply(netuser, PermissionNotAllowed); return; }
			//SpawnPrefab//
			go = NetCull.InstantiateDynamic(":mutant_wolf", new Vector3(6742.57f, 332.84f, -4345.28f), Quaternion.identity);
			//Message//
			HealthNPC = Core.Random.Range(minHealthNPC, maxHealthNPC);
			string text = $"{color_main}На карте появился сильный и злобный мутант";
			string text2 = $"{color_main}Примерное местонахождение: {color_double}Ангар";
			string text3 = $"{color_main}Количество жизней:{color_double}{HealthNPC}HP";
				Broadcast.MessageAll(text, Tag);
				Broadcast.MessageAll(text2, Tag);
				Broadcast.MessageAll(text3, Tag);
			//Pos//
			position = go.GetComponent<Transform>();
			//Damage//
			damage = go.GetComponent<TakeDamage>();
			takeDmg.Add(damage);
			///////////////////////////////////////////////////////////////////////////////////////
			ER = true;
			damage._maxHealth = (float)HealthNPC;
			damage._health = damage._maxHealth;
			Payment = Core.Random.Range(minPayment, maxPayment);
		}


	}
}