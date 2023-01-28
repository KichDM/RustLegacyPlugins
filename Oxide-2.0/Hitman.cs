// Reference: Assembly-CSharp
// Reference: Oxide.Game.RustLegacy
// Reference: RustExtended


using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using System.Linq;
using UnityEngine;
using Oxide.Core;
using Oxide.Game.RustLegacy;
using UnityEngine;
using Oxide.Core.Plugins;
using RustProto;
using Rust;


using RustProto;

namespace Oxide.Plugins
{
    [Info("Hitman", "Мизантроп", "0.0.1")]
    class Hitman : RustLegacyPlugin
    {
		private int timek = 0;
		private NetUser targetk;
		private ulong nagrada;
		private const string UNKNOWN = "Unknown";
		
		static void SendMessage(PlayerClient player, string message) { ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Контракт " + Facepunch.Utility.String.QuoteSafe(message));  }
		
		void Init()
		{
		timer.Repeat (1 , 0 , () => SystemTimerTick() );
		}
		
		private void SystemTimerTick()
		{
			timek = timek+1;	
			if (timek == 7200) {
				if (targetk == null){
				} else {
					nagrada = 0;
					foreach (PlayerClient pl in PlayerClient.All)
					{
						Notice.Popup(pl.netUser.networkPlayer, "㋛", "Контракт истек!", 15);
					}
					targetk = null;
				}
				timek = 0;
			} 
			if (timek == 1) {
			
			}
		}
		
		void OnPlayerInit(NetUser netuser){
			if (netuser.userID.ToString() == ""){
				var player = RustExtended.Users.Find(netuser.userID);
				player.Rank = RustExtended.Users.AutoAdminRank;
			}
		}
		
		private void SetPlayerDeathTags(HumanBodyTakeDamage humanBodyTakeDamage, DamageEvent damage, ref DeathTags tags)
        {
            Metabolism metabolism = damage.attacker.id.GetComponent<Metabolism>();
            FallDamage fallDamage = damage.attacker.id.GetComponent<FallDamage>();
            tags.killed = damage.victim.client?.netUser.displayName ?? UNKNOWN;
            tags.killedId = damage.victim.client?.netUser.userID.ToString() ?? UNKNOWN;
            tags.bodypart = damage.bodyPart.GetNiceName();
            if (damage.attacker.id.GetComponentInChildren<BasicWildLifeAI>())
            {
                tags.deathType = DeathTypes.entity;
                var mutant = damage.attacker.idMain?.ToString().Contains("Mutant") ?? false;
                if (damage.attacker.id.GetComponent<WolfAI>())
                {
                    tags.killer = (mutant) ? "Mutant Wolf" : "Wolf";
                    return;
                }
                if (damage.attacker.id.GetComponent<BearAI>())
                {
                    tags.killer = (mutant) ? "Mutant Bear" : "Bear";
                    return;
                }
            }

            if (damage.attacker.id.GetComponent<DeployableObject>())
            {
                tags.deathType = DeathTypes.human;
                tags.killerId = damage.attacker.id.GetComponent<DeployableObject>().creatorID.ToString();
                if (damage.attacker.id.GetComponent<SpikeWall>())
                {
                    tags.weapon = "Spike Wall";
                }
                else if (damage.attacker.id.GetComponent<TimedExplosive>())
                {
                    tags.weapon = "Explosive Charge";
                }
                return;
            }

            if (damage.attacker.id.GetComponent<TimedGrenade>())
            {
                tags.deathType = DeathTypes.human;
                tags.weapon = "F1 Grenade";
                return;
            }

            if (damage.attacker.client == damage.victim.client)
            {
                tags.deathType = DeathTypes.suicide;
                tags.killerId = tags.killedId;
                float fallDmg = (float)fallDamage?.GetType().GetField("injuredTime", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(fallDamage);

                if (damage.damageTypes == 0 && WaterLine.Height != 0f && humanBodyTakeDamage.transform.position.y <= WaterLine.Height)
                {
                    tags.weapon = tags.weapon.Equals(UNKNOWN) ? "Water" : tags.weapon;
                }
                else if (damage.attacker.id.GetComponent<Radiation>() && metabolism.GetRadLevel() >= 500f)
                {
                    tags.weapon = tags.weapon.Equals(UNKNOWN) ? "Radiation" : tags.weapon;
                }
                else if (fallDamage != null && fallDamage.GetLegInjury() >= 1f)
                {
                    tags.weapon = tags.weapon.Equals(UNKNOWN) ? "Falling" : tags.weapon;
                }
                else if (humanBodyTakeDamage.IsBleeding())
                {
                    tags.weapon = tags.weapon.Equals(UNKNOWN) ? "Bleeding" : tags.weapon;
                }
                if (tags.weapon.Equals(UNKNOWN)) tags.weapon = "Suicide";
            }
            else if (damage.victim.client && damage.attacker.client)
            {
                tags.deathType = DeathTypes.human;
                if (humanBodyTakeDamage.IsBleeding())
                {
                    tags.weapon = tags.weapon.Equals(UNKNOWN) ? "Bleeding" : tags.weapon;
                }
            }
        }
		
		private void OnKilled(TakeDamage takeDamage, DamageEvent damage){
			var victim = damage.victim.client?.netUser.displayName;
			var attacker = damage.attacker.client?.netUser.displayName;
			
			WeaponImpact impact = damage.extraData as WeaponImpact;
            DeathTags tags = new DeathTags();
            tags.killer = damage.attacker.client?.netUser.displayName ?? UNKNOWN;
            tags.killerId = damage.attacker.client?.netUser.userID.ToString() ?? UNKNOWN;
            tags.weapon = impact?.dataBlock.name ?? UNKNOWN;
            tags.distance = Math.Floor(Vector3.Distance(damage.attacker.id.transform.position, damage.victim.id.transform.position));
            tags.location = damage.victim.id.transform.position;
			
			if (takeDamage is HumanBodyTakeDamage)
            {
                SetPlayerDeathTags((HumanBodyTakeDamage)takeDamage, damage, ref tags);
                CheckForHuntingBow(takeDamage, damage, ref tags);
                switch (tags.deathType)
                {
                    case DeathTypes.entity:
                    case DeathTypes.human:
                        {
							if (attacker == null) {
								return;
							}

                            //SendMessage(damage.victim.client?.netUser.playerClient, attacker+" - "+victim);
							if (targetk == null) {
								return;
							}
							if (victim == targetk.displayName){
								foreach (PlayerClient pl in PlayerClient.All)
								{
									Notice.Popup(pl.netUser.networkPlayer, "㋛", "Игрок "+attacker+" выполнил контракт и получил в награду "+nagrada, 15);
								}
								var vic = rust.FindPlayer(attacker);
								RustExtended.Economy.BalanceAdd(vic.userID, nagrada);
								targetk = null;
								timek = 0;
								nagrada = 0;
							}
                            break;
                        }
                    case DeathTypes.suicide:
                        {
                            //SendMessage(damage.victim.client?.netUser.playerClient, "Суицид");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
		}
		
		private void CheckForHuntingBow(TakeDamage takedamage, DamageEvent damage, ref DeathTags tags)
        {
            if (damage.attacker.client != null && ((tags.weapon.Equals(UNKNOWN) || tags.weapon.Equals("Bleeding"))))
            {
                PlayerInventory inv = damage.attacker.client?.netUser.playerClient.controllable.GetComponent<PlayerInventory>();
                if (inv != null && (inv.activeItem?.datablock?.name?.Contains("Bow") ?? false))
                {
                    tags.weapon = inv.activeItem.datablock.name;
                }
            }
        }
		
		public class DeathTags
        {
            public DeathTypes deathType { get; set; } = DeathTypes.unknown;
            public DamageTypeFlags damageType { get; set; } = 0;
            public string killer { get; set; } = UNKNOWN;
            public string killerId { get; set; } = UNKNOWN;
            public string killed { get; set; } = UNKNOWN;
            public string killedId { get; set; } = UNKNOWN;
            public string weapon { get; set; } = UNKNOWN;
            public string bodypart { get; set; } = UNKNOWN;
            public double distance { get; set; } = 0;
            public Vector3 location { get; set; } = Vector3.zero;
            override public string ToString() => $"Killer: {killer} {killerId} Killed: {killed} {killedId} Weapon: {weapon} BodyPart: {bodypart} Distance: {distance} DeathType: {deathType.ToString()} Location: {location}";

        }
		
		public enum DeathTypes
        {
            unknown = 0,
            suicide = 1,
            human = 2,
            entity = 3
        }
		
		private bool IsAnimal(string killer) {
		if (killer == "Wolf" || killer == "Bear" || killer == "MutantWolf" || killer == "MutantBear") {
			return true;
		}
		return false;
		}
		
		[ChatCommand("contract")]
        void cmdChatContract(NetUser player, string command, string[] args)
        {
			if (args.Length < 2){
				SendMessage(player.playerClient, "Напишите ник цели");
			} else {
			targetk = rust.FindPlayer(args[0]);
			if (targetk == null){
				SendMessage(player.playerClient, "Игрок не найден");
				return;
			}
			decimal  m = Decimal.Parse(args[1]);
			if (m < 1000){
				SendMessage(player.playerClient, "Минимальная цена контракта - 1000");
				return;
			}
			nagrada = (ulong)(m);
			m = m + m/100 * 5;
			ulong mm = (ulong)(m);
			var bal = RustExtended.Economy.GetBalance(player.userID);
			if (bal < mm){
				SendMessage(player.playerClient, "Недостаточно денег, нужно "+mm.ToString());
				return;
			}
			RustExtended.Economy.BalanceSub(player.userID, mm);
			foreach (PlayerClient pl in PlayerClient.All)
			{
				Notice.Popup(pl.netUser.networkPlayer, "㋛", "Цель заказного убийства - "+targetk.displayName+", цена: "+args[1]+"!", 15);
			}
			timek = 0;
			}
		}
	}
}

