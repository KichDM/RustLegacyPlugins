// Reference: Oxide.Ext.RustLegacy
// Reference: Facepunch.ID
// Reference: Google.ProtocolBuffers

using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using RustProto;

namespace Oxide.Plugins
{
    [Info("AntiCheat", "Reneb", "2.0.0")]
    class AntiCheat1 : RustLegacyPlugin
    {
        static Hash<PlayerClient, float> autoLoot = new Hash<PlayerClient, float>();
        public static Core.Configuration.DynamicConfigFile ACData;
        private static FieldInfo getblueprints;
        private static FieldInfo getlooters;
        public static Vector3 Vector3Down = new Vector3(0f,-1f,0f);
        public static Vector3 UnderPlayerAdjustement = new Vector3(0f, -1.15f, 0f);
        public static float distanceDown = 10f;
        public static RaycastHit cachedRaycast;
        public static int groundsLayer = LayerMask.GetMask(new string[] {  LayerMask.LayerToName(10), "Terrain" });
        // CONFIG SHIT
        


        public class PlayerHandler : MonoBehaviour
        {
            public float timeleft;
            public float lastTick;
            public float currentTick;
            public float deltaTime;
            public Vector3 lastPosition;
            public PlayerClient playerclient;
            public Character character;
            public string userid;
            public float distance3D;
            public float distanceHeight;
            public bool lastSprint = false;

            public float lastSpeed = Time.realtimeSinceStartup;
            public int speednum = 0;


            public float lastWalkSpeed = Time.realtimeSinceStartup;
            public int walkspeednum = 0;


            public float lastJump = Time.realtimeSinceStartup;
            public int jumpnum = 0;


            public float lastFly = Time.realtimeSinceStartup;
            public int flynum = 0;


            void Awake()
            {
                lastTick = Time.realtimeSinceStartup;
                enabled = false;
            }
			public void StartCheck()
            {
                this.playerclient = GetComponent<PlayerClient>();
                this.userid = this.playerclient.userID.ToString();
                if (playerclient.controllable == null) return;
                this.character = playerclient.controllable.GetComponent<Character>();
                this.lastPosition = this.playerclient.lastKnownPosition;
                enabled = true;
            }
            void FixedUpdate()
            {
                if (Time.realtimeSinceStartup - lastTick >= 1)
                {
                    currentTick = Time.realtimeSinceStartup;
                    deltaTime = currentTick - lastTick;
                    distance3D = Vector3.Distance(playerclient.lastKnownPosition, lastPosition) / deltaTime;
                    distanceHeight = (playerclient.lastKnownPosition.y - lastPosition.y) / deltaTime;
                    checkPlayer(this);
                    lastPosition = playerclient.lastKnownPosition;
                    lastTick = currentTick;
                    if (!permanent)
                    {
                        this.timeleft--;
                        if (this.timeleft < 0f) EndDetection(this);
                    }
                }
            }
            void OnDestroy()
            {
               ACData[this.userid] = this.timeleft.ToString();
            }
        }
		static void EndDetection(PlayerHandler player)
        { 
            GameObject.Destroy(player);
        }   
        static bool RayDown(Vector3 position)
        {
            if (Physics.Raycast(position + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, distanceDown)) { if (cachedRaycast.distance > 4f) return true; }
            return false;
        }
        public static void checkPlayer(PlayerHandler player)
        {
            if (antiSpeedHack)
                checkSpeedhack(player);
			if(antiWalkSpeedhack)
                checkWalkSpeedhack(player);
            if (antiSuperJump)
                checkSuperjumphack(player);
        }
        public static void checkSuperjumphack(PlayerHandler player)
        {
			if(player.distanceHeight < jumpMinHeight) { return; }
            if (player.distance3D > jumpMaxDistance) { return; }
            if (RayDown(player.playerclient.lastKnownPosition)) return;
            if (player.currentTick - player.lastJump > jumpDetectionsReset) player.jumpnum = 0;
            player.lastJump = player.currentTick;
            player.jumpnum++;
            AntiCheatBroadcastAdmins(string.Format("{0} - SuperJump ({1}m/s)", player.playerclient.userName, player.distanceHeight.ToString()));
            if (player.jumpnum < jumpDetectionsNeed) return;
            Punish(player.playerclient, string.Format("SuperJump ({0}m/s)", player.distanceHeight.ToString()));
        } 
		public static void checkWalkSpeedhack(PlayerHandler player)
        {
            if (player.character.stateFlags.sprint) { player.lastSprint = true; player.walkspeednum = 0; return; }
            if (player.distanceHeight < -walkspeedDropIgnore) { player.walkspeednum = 0; return; }
            if (player.distance3D < walkspeedMinDistance) { player.walkspeednum = 0; return; }
            if (!player.character.stateFlags.grounded) { player.lastSprint = true; player.walkspeednum = 0; return; }
			if (player.lastSprint) { player.lastSprint = false; player.walkspeednum = 0; return; }
            if (player.lastWalkSpeed != player.lastTick) player.walkspeednum = 0;
            player.walkspeednum++;
            player.lastWalkSpeed = player.currentTick;
            AntiCheatBroadcastAdmins(string.Format("{0} - Walkspeed ({1}m/s)", player.playerclient.userName, player.distance3D.ToString()));
            if (player.walkspeednum < walkspeedDetectionForPunish) return;
            Punish(player.playerclient, string.Format("Walkspeed ({0}m/s)", player.distance3D.ToString()));
        }
        public static void checkSpeedhack(PlayerHandler player)
        {
            if (player.distanceHeight < -speedDropIgnore) { player.speednum = 0; return; }
			if(player.distance3D < speedMinDistance) { player.speednum = 0; return; }
            if (player.lastSpeed != player.lastTick) player.speednum = 0;
            player.speednum++;
            player.lastSpeed = player.currentTick;
            AntiCheatBroadcastAdmins(string.Format("{0} - Speedhack ({1}m/s)", player.playerclient.userName, player.distance3D.ToString()));
            if (player.speednum < speedDetectionForPunish) return;
            Punish(player.playerclient, string.Format("Speedhack ({0}m/s)", player.distance3D.ToString()));
        }
		float GetPlayerData(PlayerClient player)
        {
            if (ACData[player.userID.ToString()] == null) ACData[player.userID.ToString()] = timetocheck.ToString();
            return Convert.ToSingle(ACData[player.userID.ToString()]);
        }
		  
		NetUser GetLooter(Inventory inventory)
        {
            foreach (uLink.NetworkPlayer netplayer in (HashSet<uLink.NetworkPlayer>)getlooters.GetValue(inventory))
            {
                return (NetUser)netplayer.GetLocalData();
            }
            return null;
        }
		void OnItemRemoved(Inventory inventory, int slot, IInventoryItem item )
        {
            if (!antiAutoloot) return;
            if (inventory.name != "SupplyCrate(Clone)") return;
            NetUser looter = GetLooter(inventory);
            if (looter == null) return;
            if (looter.playerClient == null) return;
            if (Vector3.Distance(inventory.transform.position,looter.playerClient.lastKnownPosition) > 10f)
            {
                if(autoLoot[looter.playerClient] != null)
                {
					if(Time.realtimeSinceStartup - autoLoot[looter.playerClient] < 1f)
                    {
                        Punish(looter.playerClient, string.Format("AutoLoot ({0}m)", Vector3.Distance(inventory.transform.position, looter.playerClient.lastKnownPosition).ToString()));
                    }
                }
                AntiCheatBroadcastAdmins(string.Format("{0} - AutoLoot ({1}m)", looter.playerClient.userName, Vector3.Distance(inventory.transform.position, looter.playerClient.lastKnownPosition).ToString()));
                autoLoot[looter.playerClient] = Time.realtimeSinceStartup;
            }
        }
        void OnItemCraft(CraftingInventory inventory, BlueprintDataBlock bp, int amount, ulong starttime)
        {
            if (!antiBlueprintUnlocker) return;
            var inv = inventory.GetComponent<PlayerInventory>();
            var blueprints = (List<BlueprintDataBlock>)getblueprints.GetValue(inv);
            if (blueprints.Contains(bp)) return;
            Punish(inventory.GetComponent<Controllable>().playerClient, string.Format("BlueprintUnlocker ({0})", bp.resultItem.name.ToString()));
        }
        object ModifyDamage(TakeDamage takedamage, DamageEvent damage)
        {
            if (takedamage.GetComponent<Controllable>() == null) return null;
            if (damage.victim.character == null) return null;
            if (damage.damageTypes == 0 || damage.damageTypes == DamageTypeFlags.damage_radiation)
            {
                if (float.IsInfinity(damage.amount)) return null;
                if (damage.amount > 12f) { AntiCheatBroadcastAdmins(string.Format("{0} is receiving too much damage from the radiation, ignoring the damage", takedamage.GetComponent<Controllable>().playerClient.userName.ToString())); damage.amount = 0f; return damage; }
            }
            return null;
        }
		void OnPlayerSpawn(PlayerClient player, bool useCamp, RustProto.Avatar avatar)
        {
            PlayerHandler phandler = player.GetComponent<PlayerHandler>();
            if (phandler == null) { phandler = player.gameObject.AddComponent<PlayerHandler>(); phandler.timeleft = GetPlayerData(player);  }
            timer.Once(0.1f, () => phandler.StartCheck());
        } 
        void SaveData()
        {
            Interface.GetMod().DataFileSystem.SaveDatafile("AntiCheat");
        }
        void OnServerInitialized()
        {
            ACData = Interface.GetMod().DataFileSystem.GetDatafile("AntiCheat");
            getblueprints = typeof(PlayerInventory).GetField("_boundBPs", (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic));
            getlooters = typeof(Inventory).GetField("_netListeners", (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic));
            PlayerHandler phandler;
            foreach (PlayerClient player in PlayerClient.All)
            {
                phandler = player.gameObject.AddComponent<PlayerHandler>();
                phandler.timeleft = GetPlayerData(player);
                phandler.StartCheck();
            }
        }
		void OnServerSave()
        {
            SaveData();
        } 
        void Unload()
        {
            SaveData();
            var objects = GameObject.FindObjectsOfType(typeof(PlayerHandler));
            if (objects != null)
                foreach (var gameObj in objects)
                    GameObject.Destroy(gameObj);
        }
        static void AntiCheatBan(ulong userid, string name, string reason)
        {
                BanList.Add(userid, name, reason);
                BanList.Save();
        }

        static void Punish(PlayerClient player, string reason)
        {
            if (punishByBan)
            {
                AntiCheatBan(player.userID, player.userName, reason);
                Interface.CallHook("cmdBan", false, new string[] { player.netPlayer.externalIP.ToString(), reason });
                Debug.Log(string.Format("{0} {1} was auto banned for {2}", player.userID.ToString(), player.userName.ToString(), reason));
            }
            AntiCheatBroadcast(string.Format("[color #FFD630] {0} [color red]tried to cheat on this server!", player.userName.ToString()));
            if(punishByKick || punishByBan)
            {
                player.netUser.Kick(NetError.Facepunch_Kick_Violation, true);
                Debug.Log(string.Format("{0} {1} was auto kicked for {2}", player.userID.ToString(), player.userName.ToString(), reason));
            }
        }
        static void AntiCheatBroadcast(string message) { if (!broadcastPlayers) return; ConsoleNetworker.Broadcast("chat.add AntiCheat \"" + message + "\""); }
		 
        static void AntiCheatBroadcastAdmins(string message)
        {
            if (!broadcastAdmins) return;
            foreach (PlayerClient player in PlayerClient.All)
            {
				if(player.netUser.CanAdmin())
					ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add AntiCheat \"" + message + "\"");
            }
        }

        bool hasPermission(NetUser netuser) { return netuser.CanAdmin(); }


        public static bool permanent = true;
        public static float timetocheck = 3600f;
        public static bool punishByBan = true;
        public static bool punishByKick = true;
        public static bool broadcastAdmins = true;
        public static bool broadcastPlayers = true;

        public static bool antiSpeedHack = false;
        public static float speedMinDistance = 11000f;
        public static float speedMaxDistance = 25000f;
        public static float speedDropIgnore = 80000f;
        public static float speedDetectionForPunish = 30000;

        public static bool antiWalkSpeedhack = false;
        public static float walkspeedMinDistance = 50000f;
        public static float walkspeedMaxDistance = 15000f
        public static float walkspeedDropIgnore = 800000f;
        public static float walkspeedDetectionForPunish = 300000;

        public static bool antiSuperJump = false;
        public static float jumpMinHeight = 400f;
        public static float jumpMaxDistance = 250f;
        public static float jumpDetectionsNeed = 200f;
        public static float jumpDetectionsReset = 300f;

        public static bool antiBlueprintUnlocker = true;

        public static bool antiAutoloot = true;

        public static bool antiMassRadiation = true;

		void LoadDefaultConfig() { }

        private void CheckCfg<T>(string Key, ref T var)
        {
            if (Config[Key] is T)
                var = (T)Config[Key];
            else
                Config[Key] = var;
        }

        void Init()
        {
            CheckCfg<bool>("Settings: Permanent Check", ref permanent);
            CheckCfg<bool>("Settings: Broadcast Detections to Admins", ref broadcastAdmins);
            CheckCfg<bool>("Settings: Broadcast Bans to Players", ref broadcastPlayers);
            CheckCfg<float>("Settings: Check Time (seconds)", ref timetocheck);
            CheckCfg<bool>("Settings: Punish by Ban", ref punishByBan);
            CheckCfg<bool>("Settings: Punish by Kick", ref punishByKick);
            CheckCfg<bool>("SpeedHack: activated", ref antiSpeedHack);
            CheckCfg<float>("SpeedHack: Minimum Speed (m/s)", ref speedMinDistance);
            CheckCfg<float>("SpeedHack: Maximum Speed (m/s)", ref speedMaxDistance);
            CheckCfg<float>("SpeedHack: Max Height difference allowed (m/s)", ref speedDropIgnore);
            CheckCfg<float>("SpeedHack: Detections needed in a row before Punishment", ref speedDetectionForPunish);
            CheckCfg<bool>("WalkSpeedHack: activated", ref antiWalkSpeedhack);
            CheckCfg<float>("WalkSpeedHack: Minimum Speed (m/s)", ref walkspeedMinDistance);
            CheckCfg<float>("WalkSpeedHack: Maximum Speed (m/s)", ref walkspeedMaxDistance);
            CheckCfg<float>("WalkSpeedHack: Max Height difference allowed (m/s)", ref walkspeedDropIgnore);
            CheckCfg<float>("WalkSpeedHack: Detections needed in a row before Punishment", ref walkspeedDetectionForPunish);
            CheckCfg<bool>("SuperJump: activated", ref antiSuperJump);
            CheckCfg<float>("SuperJump: Minimum Height (m/s)", ref jumpMinHeight);
            CheckCfg<float>("SuperJump: Maximum Distance before ignore (m/s)", ref jumpMaxDistance);
            CheckCfg<float>("SuperJump: Detections needed before punishment", ref jumpDetectionsNeed);
            CheckCfg<float>("SuperJump: Time before the superjump detections gets reseted", ref jumpDetectionsReset);
            CheckCfg<bool>("BlueprintUnlocker: activated", ref antiBlueprintUnlocker);
            CheckCfg<bool>("Autoloot: activated", ref antiAutoloot);
            CheckCfg<bool>("AntiMassRadiation: activated", ref antiMassRadiation);
            SaveConfig();
        }
    }
}
