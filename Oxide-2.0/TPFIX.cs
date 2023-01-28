// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("TPFIX", "Atamg", "1.0.3", ResourceId = 941)]
    class TPFIX : RustLegacyPlugin
    {
        [PluginReference]
        Plugin PlayerDatabase;
        /////////////////////////////
        // FIELDS
        /////////////////////////////
        private DateTime epoch;

        RustServerManagement management;

        Dictionary<NetUser, float> lastRequest = new Dictionary<NetUser, float>();
        Dictionary<NetUser, NetUser> TPRequest = new Dictionary<NetUser, NetUser>();
        Dictionary<NetUser, NetUser> TPIncoming = new Dictionary<NetUser, NetUser>();
        Dictionary<NetUser, Oxide.Plugins.Timer> timersList = new Dictionary<NetUser, Oxide.Plugins.Timer>();

        int terrainLayer;

        float TPRStructureDistance = 15f;

        Vector3 cachedPos;
        Vector3 vectorup = new Vector3(0f, 1f, 0f);
        Vector3 VectorUp = new Vector3(0f, 1f, 0f);
        Vector3 VectorDown = new Vector3(0f, -0.4f, 0f);
        Vector3 VectorDownn = new Vector3(0f, -0.1f, 0f);

        public static Vector3 Vector3Down = new Vector3(0f, -1f, 0f);
        public static Vector3 Vector3Up = new Vector3(0f, 1f, 0f);
        public static Vector3 UnderPlayerAdjustement = new Vector3(0f, -1.15f, 0f);
        public static float distanceDown = 10f;

        RaycastHit cachedRaycast;
        Collider[] cachedColliders;
        /////////////////////////////
        // Config Management
        /////////////////////////////
 bool hasAccess(NetUser player)
        {
            if (!player.CanAdmin())
            {
           
                return false;
            }
            return true;
        }
        
       
        bool ifOnGround(NetUser netusery)
        {

            PlayerClient playerclient = netusery.playerClient;
            Vector3 lastPosition = playerclient.lastKnownPosition;


            Collider cachedCollider;
            bool cachedBoolean;
            Vector3 cachedvector3;
            RaycastHit cachedRaycast;
            Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance;


            if (lastPosition == default(Vector3)) return true;
            if (!MeshBatchPhysics.Raycast(lastPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { return true; }
            if (cachedhitInstance == null) { return true; }
            if (cachedhitInstance.graphicalModel.ToString() == null) {
                //Put(cachedhitInstance.graphicalModel.ToString());
                return true;
            }

            return false;
        }

        bool ifOnDeployable(NetUser userx) {

            PlayerClient playerclient = userx.playerClient;
            Vector3 lastPosition = playerclient.lastKnownPosition;


            Collider cachedCollider;
            bool cachedBoolean;
            Vector3 cachedvector3;
            RaycastHit cachedRaycast;
            Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance;
            DeployableObject cachedDeployable;

            if (lastPosition == default(Vector3)) return false;
            if (!MeshBatchPhysics.Raycast(lastPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { return false; }
            if (cachedhitInstance == null)
            {
                cachedDeployable = cachedRaycast.collider.GetComponent<DeployableObject>();
                if (cachedDeployable != null)
                {
                    return true;
                }
                return false;
            }
            if (cachedhitInstance.graphicalModel.ToString() == null) {
                //Put(cachedhitInstance.graphicalModel.ToString());
                return false;
            }

            return false;
        }
        bool ifOnlootDeployable(NetUser userx) {

            PlayerClient playerclient = userx.playerClient;
            Vector3 lastPosition = playerclient.lastKnownPosition;


            Collider cachedCollider;
            bool cachedBoolean;
            Vector3 cachedvector3;
            RaycastHit cachedRaycast;
            Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance;
            DeployableObject cachedDeployable;

            if (lastPosition == default(Vector3)) return false;
            if (!MeshBatchPhysics.Raycast(lastPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { return false; }
            if (cachedhitInstance == null)
            {
                var cachedLootableObject = cachedRaycast.collider.GetComponent<LootableObject>();
                if (cachedLootableObject != null)
                {
                    return true;
                }
                return false;
            }
            if (cachedhitInstance.graphicalModel.ToString() == null) {
                //Put(cachedhitInstance.graphicalModel.ToString());
                return false;
            }

            return false;
        }
        bool ifOnlootsackDeployable(NetUser userx) {

            PlayerClient playerclient = userx.playerClient;
            Vector3 lastPosition = playerclient.lastKnownPosition;

            Collider cachedCollider;
            bool cachedBoolean;
            Vector3 cachedvector3;
            RaycastHit cachedRaycast;
            Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance;
            DeployableObject cachedDeployable;

            if (lastPosition == default(Vector3)) return false;
            if (!MeshBatchPhysics.Raycast(lastPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { return false; }
            if (cachedhitInstance == null)
            {
                var cachedsack = "GenericItemPickup(Clone)";
                var cachedLootableObject = cachedRaycast.collider.gameObject.name;
                if (cachedLootableObject == cachedsack)
                {
                    return true;
                }
                return false;
            }
            var cachedsack2 = "GenericItemPickup(clone)";
            if (cachedhitInstance.graphicalModel.ToString() == cachedsack2)
                return true;
            if (cachedhitInstance.graphicalModel.ToString().Contains(cachedsack2)) return true;
            if (cachedhitInstance.graphicalModel.ToString() == null) {
                Debug.Log(cachedhitInstance.graphicalModel.ToString());
                return false;
            }

            return false;
        }

        StructureComponent GetClosestStructure(UnityEngine.Object[] structObjs, Vector3 pos)
        {
            StructureComponent theComponent = null;
            float minDistance = Mathf.Infinity;
			
			for(int i = 0; i < structObjs.Length; i++)
            {
				StructureComponent component = (StructureComponent)structObjs[i];
				
                float distance = Vector3.Distance(component.transform.position, pos);
                if (distance < minDistance)
                {
                    theComponent = component;
                    minDistance = distance;
                }
            }
            return theComponent;
        }

        bool IfNearStructure(NetUser userx)
        {
            PlayerClient playerclient = userx.playerClient;
            Vector3 lastPosition = playerclient.lastKnownPosition;
            UnityEngine.Object[] structObjs = Resources.FindObjectsOfTypeAll(typeof(StructureComponent));

            if (Vector3.Distance(GetClosestStructure(structObjs, lastPosition).transform.position, lastPosition) < TPRStructureDistance)
            {
                return true;
            }
            return false;
        }

        bool Ifinshack(NetUser userx)
		{
            PlayerClient playerclient = userx.playerClient;
			Vector3 lastPosition = playerclient.lastKnownPosition;
			Collider cachedCollider;
			bool cachedBoolean;
			Vector3 cachedvector3;
			RaycastHit cachedRaycast;
			Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance;
			DeployableObject cachedDeployable;
			if (lastPosition == default(Vector3)) return false;
			if (!MeshBatchPhysics.Raycast(lastPosition + UnderPlayerAdjustement, Vector3Up, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { return false; }
			if (cachedhitInstance == null) 
			{
				var cachedsack = "Wood_Shelter(Clone)";
				var cachedLootableObject = cachedRaycast.collider.gameObject.name;
				if (cachedLootableObject == cachedsack)
				{
					return true;
				}
				return false;
			}
			var cachedsack2 = "Wood_Shelter(Clone)";
			if(cachedhitInstance.graphicalModel.ToString() == cachedsack2)
				return true;
			if (cachedhitInstance.graphicalModel.ToString().Contains(cachedsack2)) return true;
			if (cachedhitInstance.graphicalModel.ToString() == null)
			{
				Debug.Log(cachedhitInstance.graphicalModel.ToString());
				return false;
			}
			return false;
		}
        static string notAllowed = "Вы не можете использовать эту команду.";
        static bool cancelOnHurt = true;
        static bool useTokens = false;
        static int givefreetokensmax = 3;
        static int starttokens = 3;
        static bool givefreetokens = true;
        static double givefreetokensevery = 600.0;
        static int tprCooldown = 60;
        static int tprtime = 10;

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
            CheckCfg<bool>("Settings: Cancel teleportation if player is hurt", ref cancelOnHurt);
            CheckCfg<int>("Settings: Cooldown before being able to use TPR again", ref tprCooldown);
            CheckCfg<int>("Settings: TPR Teleportation delay", ref tprtime);
            CheckCfg<bool>("Tokens: activated", ref useTokens);
            CheckCfg<bool>("Tokens: give free tokens", ref givefreetokens);
            CheckCfg<double>("Tokens: give free token every", ref givefreetokensevery);
            CheckCfg<int>("Tokens: give free tokens max", ref givefreetokensmax);
            CheckCfg<int>("Tokens: start tokens", ref starttokens);
            SaveConfig();
        }


        /////////////////////////////
        // Oxide Hooks
        /////////////////////////////

        void Loaded()
        {
            epoch = new System.DateTime(1970, 1, 1);
            terrainLayer = LayerMask.GetMask(new string[] { "Static" });
        }
        void OnServerInitialized()
        {
            management = RustServerManagement.Get();
            if(useTokens && PlayerDatabase==null)
            {
                Debug.Log("WARNING from TPR: You are trying to use the tokens without PlayerDatabase installed, tokens will not work.");
                useTokens = false;
            }
        }
        void Unload()
        {
            foreach (KeyValuePair<NetUser, Oxide.Plugins.Timer> pair in timersList)
            {
                pair.Value.Destroy();
            }
            timersList.Clear();
        }  
        void OnPlayerDisconnect(uLink.NetworkPlayer netplayer)
        {
            NetUser netuser = (NetUser)netplayer.GetLocalData();
            ResetRequest(netuser);
        }
        /////////////////////////////
        // External Plugin Functions
        /////////////////////////////
        object AddTeleportTokens(string userid, int number = 1)
        {
            if(useTokens)
            {
                var tokensLeft = GetPlayerTokensByID(userid) + number;
                PlayerDatabase.Call("SetPlayerData", userid.ToString(), "tokens", tokensLeft);
                return tokensLeft;
            }
            return null;
        }
        object RemoveTeleportTokens(string userid, int number = 1)
        {
            if (useTokens)
            {
                var tokensLeft = GetPlayerTokensByID(userid) - number;
                PlayerDatabase.Call("SetPlayerData", userid.ToString(), "tokens", tokensLeft);
                return tokensLeft;
            }
            return null;
        }
        object GetTeleportTokens(string userid)
        {
            if (useTokens)
            {
                return GetPlayerTokensByID(userid);
            }
            return null;
        }
        object SetTeleportTokens(string userid, int number)
        {
            if (useTokens)
            {
                var tokensLeft = GetPlayerTokensByID(userid);
                PlayerDatabase.Call("SetPlayerData", userid.ToString(), "tokens", number);
                return tokensLeft;
            }
            return null;
        }

        /////////////////////////////
        // Teleportation Functions
        /////////////////////////////
   void DoTeleportToPlayer2(NetUser source, NetUser target)
        {
            management.TeleportPlayerToPlayer(source.playerClient.netPlayer, target.playerClient.netPlayer);
            SendReply(source, string.Format("You teleported to {0}", target.playerClient.userName));
        }
        void TeleportToPos(NetUser source, float x, float y, float z)
        {
            if (Physics.Raycast(new Vector3(x, -1000f, z), vectorup, out cachedRaycast, Mathf.Infinity, terrainLayer))
            {
                if (cachedRaycast.point.y > y) y = cachedRaycast.point.y;
            }
            management.TeleportPlayerToWorld(source.playerClient.netPlayer, new Vector3(x, y, z));
            SendReply(source, string.Format("You teleported to {0} {1} {2}", x.ToString(), y.ToString(), z.ToString()));
        }
        
         void DoTeleportToPlayer3(NetUser source, Vector3 target)
        {
            if (source == null || source.playerClient == null)
                return;
            
            rust.RunClientCommand(source, "input.bind Duck None None");
            rust.RunClientCommand(source, "input.bind Jump None None");
            rust.RunClientCommand(source, "input.bind Fire None None");
            rust.RunClientCommand(source, "input.bind AltFire None None");
            rust.RunClientCommand(source, "input.bind Up None None");
            rust.RunClientCommand(source, "input.bind Down None None");
            rust.RunClientCommand(source, "input.bind Left None None");
            rust.RunClientCommand(source, "input.bind Right None None");
            rust.RunClientCommand(source, "input.bind Flashlight None None");
            source.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
            timer.Once(0.5f, () =>
			{
              Vector3 lastKnownPosition = source.playerClient.lastKnownPosition;
               if (Vector3.Distance(lastKnownPosition, target) < 10f)
               {
					management.TeleportPlayerToWorld(source.playerClient.netPlayer, target);

					SendReply(source, string.Format("Вы были заморожены на 5 секунд!", source.playerClient.userName));
            
					timer.Once(1.0f, () =>
					{
					management.TeleportPlayerToWorld(source.playerClient.netPlayer, target);
					}
				);
				timer.Once(6.5f, () =>
				{
				source.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
				rust.RunClientCommand(source, "config.load");
				});
            
                } else {
					source.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
					rust.RunClientCommand(source, "config.load");
                }
           
                
            });
           
            
        }
        
        void DoTeleportToPlayer(NetUser source, Vector3 target, NetUser targetuser)
        {
            if (source == null || source.playerClient == null)
                return;
            management.TeleportPlayerToWorld(source.playerClient.netPlayer, target);
            rust.RunClientCommand(source, "input.bind Duck None None");
            rust.RunClientCommand(source, "input.bind Jump None None");
            rust.RunClientCommand(source, "input.bind Fire None None");
            rust.RunClientCommand(source, "input.bind AltFire None None");
            rust.RunClientCommand(source, "input.bind Up None None");
            rust.RunClientCommand(source, "input.bind Down None None");
            rust.RunClientCommand(source, "input.bind Left None None");
            rust.RunClientCommand(source, "input.bind Right None None");
            rust.RunClientCommand(source, "input.bind Flashlight None None");
            source.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
            SendReply(source, string.Format("Вы были заморожены на 5 секунд!", targetuser.playerClient.userName));
			 timer.Once(1.0f, () =>
			{
            management.TeleportPlayerToWorld(source.playerClient.netPlayer, target);
			});
			timer.Once(4.0f, () =>
			{
            source.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
        	rust.RunClientCommand(source, "config.load");
			});
            SendReply(source, string.Format("Вы были телепортированы к {0}", targetuser.playerClient.userName));
        }
        void ResetRequest(NetUser netuser)
        {
            if (timersList.ContainsKey(netuser))
            {
                timersList[netuser].Destroy();
                timersList.Remove(netuser);
            }
            if (TPRequest.ContainsKey(netuser))
            {
                var targetuser = TPRequest[netuser];
                if (TPIncoming.ContainsKey(targetuser))
                {
                    TPIncoming.Remove(targetuser);
                    SendReply(netuser, "[color #009D91]Не успел принять телепорт, повторите попытку.");
                }
                TPRequest.Remove(netuser);
            }
            foreach (KeyValuePair<NetUser, NetUser> pair in TPRequest)
            {
                if (pair.Value == netuser)
                {
                    var sourceuser = pair.Key;
                    if (TPRequest.ContainsKey(sourceuser))
                    {
                        var targetuser = TPRequest[sourceuser];
                        if (TPIncoming.ContainsKey(targetuser))
                            TPIncoming.Remove(targetuser);
                        timer.Once(0.01f, () => TPRequest.Remove(sourceuser));
                        if (timersList.ContainsKey(sourceuser))
                        {
                            timersList[sourceuser].Destroy();
                            timersList.Remove(sourceuser);
                        }
                        if(sourceuser.playerClient)
                        {
                            SendReply(sourceuser, "[color #009D91]Телепортация не была успешной");
                        }
                        if (targetuser.playerClient)
                        {
                            SendReply(targetuser, "[color #009D91]Телепортация не была успешной");
                        }
                    }
                }
            }
        }
        void AcceptRequest(NetUser netuser)
        {
            if (timersList.ContainsKey(netuser))
            {
                timersList[netuser].Destroy();
                timersList.Remove(netuser);
            }
            if (TPRequest.ContainsKey(netuser))
            {
                var targetuser = TPRequest[netuser];
                if (TPIncoming.ContainsKey(targetuser))
                    TPIncoming.Remove(targetuser);
                timersList.Add(netuser, timer.Once((float)tprtime, () => DoTeleportation(netuser)));
            }
        }
        void DoTeleportation(NetUser netuser)
        {
            if (netuser == null || netuser.playerClient == null)
			{
				return;
			}
			FallDamage falldamage = netuser.playerClient.rootControllable.GetComponent<FallDamage>();
            if(!TPRequest.ContainsKey(netuser)) { SendReply(netuser, "Что-то пошло не так, у вас нет цели"); ClearLegInjury(falldamage); return; }
            var targetuser = TPRequest[netuser];
            if (targetuser == null || targetuser.playerClient == null) { SendReply(netuser, "Целевой игрок, которого вы должны были телепортировать, похоже, не подключен."); TPRequest.Remove(netuser); ClearLegInjury(falldamage); return; }

            object thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
            if (thereturn != null)
            {
                SendReply(netuser, "Вам запрещено телепортироваться туда, где вы находитесь.");
                TPRequest.Remove(netuser);
                return;
            } 
            thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { targetuser });
            if (thereturn != null)
            {
                SendReply(netuser, "Вы не можете телепортироваться туда, где цель.");
                TPRequest.Remove(netuser);
                return;
            }
            foreach(Collider collider in UnityEngine.Physics.OverlapSphere(targetuser.playerClient.lastKnownPosition, 0.5f, terrainLayer))
            {
                if(Physics.Raycast(targetuser.playerClient.lastKnownPosition, VectorDown, out cachedRaycast, 1f, terrainLayer))
                {
                    if (cachedRaycast.collider == collider)
                    {
                        break;
                    }
                }
                SendReply(netuser, "[color #009D91]Цель, кажется, находится под скалой, не может телепортировать вас туда.");
                TPRequest.Remove(netuser);
                return;
            }
			if(Ifinshack(targetuser)) {
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится в убежище, поэтому вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("[color #009D91]Вы [color #009D91]находятся в укрытии, поэтому  [color #D9AE04]{0} [color #009D91]не может телепортироваться к вам.", netuser.displayName));
				return;
			}
            if (IfNearStructure(targetuser))
            {
                SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Стоит близко к стене. Невозможно телепортироваться.", targetuser.displayName));
                SendReply(targetuser, string.Format("[color #009D91]Вы [color #009D91]стояли близко к стене, поэтому [color #D9AE04]{0} [color #009D91]не мог телепортироваться к вам.", netuser.displayName));
                TPRequest.Remove(netuser);
                return;
            }
            if (!ifOnGround(targetuser)) {
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на здании, поэтому вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь в здании, поэтому {0} не смог телепортироваться к вам.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnDeployable(targetuser)) {
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на объекте, поэтому вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на объекте, поэтому {0} не может телепортироваться к вам.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnlootDeployable(targetuser)){
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на съемном объекте, поэтому вы не можете телепортироваться..", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на большом объекте, поэтому {0} не может телепортироваться к вам.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnlootsackDeployable(targetuser)){
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на съемном объекте, поэтому вы не можете телепортироваться..", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на большом объекте, поэтому {0} не может телепортироваться к вам.", netuser.displayName));
			TPRequest.Remove(netuser);
				return;
			}
			if(ifOnlootsackDeployable(targetuser)){
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на съемном объекте, поэтому вы не можете телепортироваться..", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на большом объекте, поэтому {0} не может телепортироваться к вам.", netuser.displayName));
			TPRequest.Remove(netuser);
				return;
			}
            if (lastRequest.ContainsKey(netuser)) lastRequest.Remove(netuser);
            lastRequest.Add(netuser, Time.realtimeSinceStartup);
            if(useTokens)
            {
                var tokensLeft = GetPlayerTokens(netuser) - 1;
                PlayerDatabase.Call("SetPlayerData", netuser.playerClient.userID.ToString(), "tokens", tokensLeft);
            }
            var fixedpos = targetuser.playerClient.lastKnownPosition;
            DoTeleportToPlayer(netuser, fixedpos, targetuser);
			if (timersList.ContainsKey(netuser))
            {
                timersList[netuser].Destroy();
                timersList.Remove(netuser);
            }
            TPRequest.Remove(netuser);
        }
        void ClearLegInjury(FallDamage falldamage)
        {
            if (falldamage == null) return;
            falldamage.ClearInjury();
        }
        void OnKilled(TakeDamage takedamage, DamageEvent damage)
        {
            if (damage.victim.client == null) return;
            NetUser netuser = damage.victim.client.netUser;
            if (TPRequest.ContainsKey(netuser))
            {
                SendReply(netuser, "Телепортация отменена");
            }
            ResetRequest(netuser);
        }
        double CurrentTime()
        {
            return System.DateTime.UtcNow.Subtract(epoch).TotalSeconds;
        }
        int GetPlayerTokensByID(string userid)
        {
            var datatokens = PlayerDatabase.Call("GetPlayerData", userid.ToString(), "tokens");
            if (datatokens == null)
            {
                
                PlayerDatabase.Call("SetPlayerData", userid.ToString(), "tokens", starttokens);
                PlayerDatabase.Call("SetPlayerData", userid.ToString(), "lasttokens", CurrentTime());
                return starttokens;
            }
            int realtokens = Convert.ToInt32(datatokens);
            if (realtokens < givefreetokensmax)
            {
                var lasttokens = Convert.ToDouble(PlayerDatabase.Call("GetPlayerData", userid.ToString(), "lasttokens"));
                var tokenstogive = (CurrentTime() - lasttokens) / givefreetokensevery;
                if (tokenstogive >= 1)
                {
                    realtokens += Convert.ToInt32(tokenstogive);
                    if (realtokens > givefreetokensmax)
                        realtokens = givefreetokensmax;
                    PlayerDatabase.Call("SetPlayerData", userid.ToString(), "tokens", realtokens);
                    PlayerDatabase.Call("SetPlayerData", userid.ToString(), "lasttokens", CurrentTime());
                }
            }
            return realtokens;
        }
        int GetPlayerTokens(NetUser netuser)
        {
            return GetPlayerTokensByID(netuser.playerClient.userID.ToString());
        }

        [ChatCommand("home")]
        void cmdHome(NetUser Sender, string Command, string[] Args)
        {  
        UserData userData = Users.GetBySteamID(Sender.userID);
     List<Vector3> playerSpawns;
    Vector3 lastKnownPosition;
    int result = -1;
    if (((Args != null) && (Args.Length != 0)) && ((Sender != null) && Sender.admin))
    {
        UserData data = Users.Find(Args[0]);
        if (data == null)
        {
            Broadcast.Notice(Sender, "✘", RustExtended.Config.GetMessage("Command.PlayerNoFound", Sender, Args[0]), 5f, 0f);
        }
        else
        {
            lastKnownPosition = Sender.playerClient.lastKnownPosition;
            playerSpawns = Helper.GetPlayerSpawns(data.SteamID, false);
            if (playerSpawns.Count == 0)
            {
                Broadcast.Notice(Sender, "✘", "Player \"" + data.Username + "\" not have a camp.", 5f, 0f);
            }
            else
            {
                if ((Args.Length > 1) && int.TryParse(Args[1], out result))
                {
                    result--;
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result >= playerSpawns.Count)
                    {
                        result = playerSpawns.Count - 1;
                    }
                }
                else
                {
                    for (int i = 0; i < playerSpawns.Count; i++)
                    {
                        if (Vector3.Distance(lastKnownPosition, playerSpawns[i]) < 3f)
                        {
                            result = ++i;
                        }
                    }
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result >= playerSpawns.Count)
                    {
                        result = 0;
                    }
                }
                Broadcast.Notice(Sender, "☢", string.Concat(new object[] { "You moved on \"", data.Username, "\" home spawn ", result + 1, " of ", playerSpawns.Count }), 5f, 0f);
               	string filename4 = string.Format("{0}", playerSpawns[result].ToString());
			
               UnityEngine.Debug.Log(filename4);
                Helper.TeleportTo(Sender, playerSpawns[result]);
            }
        }
    }
    else
    {
        lastKnownPosition = Sender.playerClient.lastKnownPosition;
        playerSpawns = Helper.GetPlayerSpawns(Sender.playerClient, true);
        if (playerSpawns.Count == 0)
        {
            Broadcast.Notice(Sender, "✘", RustExtended.Config.GetMessage("Command.Home.NoCamp", Sender, ""), 5f, 0f);
        }
        else
        {
            int num4;
            for (int j = 0; j < playerSpawns.Count; j++)
            {
                if (Vector3.Distance(lastKnownPosition, playerSpawns[j]) < 3f)
                {
                    result = j++;
                }
            }
            if (((Args != null) && (Args.Length != 0)) && Args[0].Equals("LIST", StringComparison.OrdinalIgnoreCase))
            {
                string[] messages = RustExtended.Config.GetMessages("Command.Home.List", Sender);
                for (num4 = 0; num4 < messages.Length; num4++)
                {
                    string text = messages[num4];
                    if (text.Contains("%HOME.NUM%") || text.Contains("%HOME.POSITION%"))
                    {
                        for (int k = 0; k < playerSpawns.Count; k++)
                        {
                            int num6 = k + 1;
                            Broadcast.Message(Sender, text.Replace("%HOME.NUM%", num6.ToString()).Replace("%HOME.POSITION%", playerSpawns[k].AsString()), null, 0f);
                        }
                    }
                    else
                    {
                        Broadcast.Message(Sender, Helper.ReplaceVariables(Sender, text, null, "").Replace("%HOME.COUNT%", playerSpawns.Count.ToString()), null, 0f);
                    }
                }
            }
            else
            {
                if (RustExtended.Core.CommandHomeOutdoorsOnly)
                {
                    Collider[] colliderArray = Physics.OverlapSphere(Sender.playerClient.controllable.character.transform.position, 1f, 0x10360401);
                    for (num4 = 0; num4 < colliderArray.Length; num4++)
                    {
                        IDMain main = IDBase.GetMain(colliderArray[num4]);
                        if (main != null)
                        {
                            StructureMaster component = main.GetComponent<StructureMaster>();
                            if ((component != null) && (component.ownerID != Sender.userID))
                            {
                                UserData bySteamID = Users.GetBySteamID(component.ownerID);
                                if ((bySteamID == null) || !bySteamID.HasShared(Sender.userID))
                                {
                                    Broadcast.Notice(Sender, "☢", RustExtended.Config.GetMessage("Command.Home.NotHere", Sender, null), 5f, 0f);
                                    return;
                                }
                            }
                        }
                    }
                }
                Countdown countdown = Users.CountdownList(userData.SteamID).Find(F => F.Command == Command);
                  Users.CountdownRemove(userData.SteamID, countdown);
                if (countdown != null)
                {
                  //  Users.CountdownRemove(userData.SteamID, countdown);
                    if (!countdown.Expired)
                    {
                        TimeSpan span = TimeSpan.FromSeconds(countdown.TimeLeft);
                        if (span.TotalHours >= 1.0)
                        {
                            Broadcast.Notice(Sender, "✘", RustExtended.Config.GetMessage("Command.Home.Countdown", Sender, null).Replace("%TIME%", $"{span.Hours:F0}:{span.Minutes:D2}:{span.Seconds:D2}"), 5f, 0f);
                            return;
                        }
                        if (span.TotalMinutes >= 1.0)
                        {
                            Broadcast.Notice(Sender, "✘", RustExtended.Config.GetMessage("Command.Home.Countdown", Sender, null).Replace("%TIME%", $"{span.Minutes}:{span.Seconds:D2}"), 5f, 0f);
                            return;
                        }
                        Broadcast.Notice(Sender, "✘", RustExtended.Config.GetMessage("Command.Home.Countdown", Sender, null).Replace("%TIME%", $"{span.Seconds}"), 5f, 0f);
                        return;
                    }
                    
                    Users.CountdownRemove(userData.SteamID, countdown);
                }
                EventTimer item = Events.Timer.Find(E => (E.Sender == Sender) && (E.Command == Command));
                if ((item != null) && (item.TimeLeft > 0.0))
                {
                    Broadcast.Notice(Sender, "☢", RustExtended.Config.GetMessage("Command.Home.Wait", Sender, null).Replace("%TIME%", item.TimeLeft.ToString()), 5f, 0f);
                }
                else
                {
                    if (item != null)
                    {
                        item.Dispose();
                        Events.Timer.Remove(item);
                    }
                    if (((Args != null) && (Args.Length != 0)) && int.TryParse(Args[0], out result))
                    {
                        result--;
                    }
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result >= playerSpawns.Count)
                    {
                        result = playerSpawns.Count - 1;
                    }
                    if (Economy.Enabled && (RustExtended.Core.CommandHomePayment > 0L))
                    {
                        string newValue = RustExtended.Core.CommandHomePayment.ToString("N0") + Economy.CurrencySign;
                        if (Economy.Get(userData.SteamID).Balance < RustExtended.Core.CommandHomePayment)
                        {
                            Broadcast.Notice(Sender, "☢", RustExtended.Config.GetMessage("Command.Home.NoEnoughCurrency", Sender, null).Replace("%PRICE%", newValue), 5f, 0f);
                            return;
                        }
                    }
                    			
                    
                    item = Events.TimeEvent_HomeWarp(Sender, Command, (double) RustExtended.Core.CommandHomeTimewait, playerSpawns[result]);
                   float newValue2 = Convert.ToSingle(RustExtended.Core.CommandHomeTimewait);
                  // 	string filename4 = string.Format("{0},{1}", playerSpawns[result].ToString(), newValue2.ToString());
			
              // UnityEngine.Debug.Log(filename4);
                 timer.Once(newValue2, () =>
			{
         DoTeleportToPlayer3(Sender, playerSpawns[result]);
			});
                   if ((item != null) && (item.TimeLeft > 0.0))
                    {
                        Broadcast.Notice(Sender, "☢", RustExtended.Config.GetMessage("Command.Home.Start", Sender, "").Replace("%TIME%", item.TimeLeft.ToString()), 5f, 0f);
                    }
                }
            }
        }
    }
}
        
        
        
        
        [ChatCommand("tp")]
        void cmdChatTeleportRequest(NetUser netuser, string command, string[] args)
        {
            
            if(hasAccess(netuser))
			{   
        if (args.Length == 0) {

            SendReply(netuser, "/tp PLAYERNAME => teleport to a player");
            SendReply(netuser, "/tp PLAYERNAME PLAYERNAME => teleport the first player to the second player");
            SendReply(netuser, "/tp X Z => Teleport to the coordinates X & Z");
            SendReply(netuser, "/tp PLAYERNAME X Z => Teleport a source player to the coordinates X & Z");
            SendReply(netuser, "/tp X Y Z => Teleport yourself to the coordinates X Y Z ");
            SendReply(netuser, "/tp PLAYERNAME X Y Z => Teleport a source player to the coordinates X Y Z");
          return;
          }

            // Teleport self to a player
            else if (args.Length == 1)
            {
                NetUser targetuser = rust.FindPlayer(args[0]);
                if (targetuser != null)
                {
                   
                    DoTeleportToPlayer2(netuser, targetuser);
                    return;
                }

                SendReply(netuser, "The target player or location doesn't seem to exist");
                return;
            }

            // Teleport to a player to another player, or teleport self to positions
            else if (args.Length == 2)
            {
                NetUser sourcePlayer = rust.FindPlayer(args[0]);
                if (sourcePlayer != null)
                {
                    NetUser targetPlayer = rust.FindPlayer(args[1]);
                    if (targetPlayer != null)
                    {
                        DoTeleportToPlayer2(sourcePlayer, targetPlayer);
                        SendReply(netuser, string.Format("You successfully teleport {0} to {1}", sourcePlayer.playerClient.userName, targetPlayer.playerClient.userName));
                        return;
                    }
                   
                    SendReply(netuser, "Couldn't find the destination player");
                    return;
                }
                float x;
                float z;
                if (float.TryParse(args[0], out x) && float.TryParse(args[1], out z))
                {
                   
                    TeleportToPos(netuser, x, -1000f, z);
                    return;
                }
                SendReply(netuser, "Couldn't find the player to teleport");
                return;
            }

            // Teleport player to positions, or teleport self to positions
            else if (args.Length == 3)
            {
                float x;
                float z;
                NetUser sourcePlayer = rust.FindPlayer(args[0]);
                if (sourcePlayer != null)
                {
                    if (float.TryParse(args[1], out x) && float.TryParse(args[2], out z))
                    {
                        TeleportToPos(sourcePlayer, x, -1000f, z);
                        return;
                    }
                    SendReply(netuser, string.Format("Trying to teleport {0} to wrong coordinates: {1} {2}", sourcePlayer.playerClient.userName, args[1], args[2]));
                    return;
                }
                float y;
                if (float.TryParse(args[0], out x) && float.TryParse(args[1], out y) && float.TryParse(args[2], out z))
                {
                   
                    TeleportToPos(netuser, x, y, z);
                    return;
                }
                SendReply(netuser, string.Format("Couldn't teleport with there arguments: {0} {1} {2}", args[0], args[1], args[2]));
                return;
            }

            // Teleport player to positions
            else if (args.Length == 4)
            {
                float x;
                float y;
                float z;
                NetUser sourcePlayer = rust.FindPlayer(args[0]);
                if (sourcePlayer == null)
                {
                    SendReply(netuser, string.Format("{0} doesn't exist", args[0]));
                    return;
                }
                if (float.TryParse(args[1], out x) && float.TryParse(args[2], out y) && float.TryParse(args[3], out z))
                {
                    TeleportToPos(sourcePlayer, x, y, z);
                    return;
                }
                SendReply(netuser, string.Format("Wrong coordinates: {0} {1} {2}", args[1], args[2], args[3]));
                return;
            }
            }
			else
			{
            if (args.Length == 0) {
                SendReply(netuser, "Используйте: /tp Nick, для телепортаеции к игроку");
                if(useTokens)
                {
                    var tokensLeft = GetPlayerTokens(netuser);
                    SendReply(netuser, string.Format("You have {0} tokens left",tokensLeft.ToString()));
                }
                return;
            }
            if (TPIncoming.ContainsKey(netuser)) { SendReply(netuser, "[color #009D91]У вас есть входящий запрос телепортации, вы должны подождать, прежде чем использовать эту команду.."); return; }
            if (TPRequest.ContainsKey(netuser)) { SendReply(netuser, "[color #009D91]Вы уже запросили телепортацию, вы должны подождать, прежде чем использовать эту команду."); return; }

            if (lastRequest.ContainsKey(netuser))
            {
                if(Time.realtimeSinceStartup - lastRequest[netuser] < (float)tprCooldown)
                {
                    SendReply(netuser, string.Format("[color #009D91]Вы [color #009D91]должны ждать [color #D9AE04]{0}[color #009D91]s перед запросом другой телепортации..", ((float)tprCooldown - (Time.realtimeSinceStartup - lastRequest[netuser])).ToString()));
                    return;
                }
            }
			if(Ifinshack(netuser)) {
				SendReply(netuser, " [color #009D91]Вы не можете телепортироваться из [color #D9AE04]shelter's");
				return;
			}
            if (IfNearStructure(netuser))
            {
                SendReply(netuser, " [color #009D91]Вы не можете телепортироваться, так как близко к зданию");
                return;
            }
            if (!ifOnGround(netuser)) {
				SendReply(netuser, " [color #009D91]Вы не можете телепортироваться из постройки");
				return;
			}
			if(ifOnDeployable(netuser)) {
				SendReply(netuser, " [color #009D91]Вы находитесь на объекте, поэтому вы не можете телепортироваться.");
				return;
			}
			if(ifOnlootDeployable(netuser)){
					SendReply(netuser, " [color #009D91]Вы находитесь на объекте, поэтому вы не можете телепортироваться.");
				return;
			}
			if(ifOnlootsackDeployable(netuser)){
				SendReply(netuser, " [color #009D91]Вы находитесь на объекте, поэтому вы не можете телепортироваться.");
				return;
			}
			
            if(useTokens)
            {
                var tokensLeft = GetPlayerTokens(netuser);
                if(tokensLeft < 1)
                {
                    SendReply(netuser, " You don't have any more tokens left to teleport");
                    return;
                }
            }
           
            NetUser targetPlayer = rust.FindPlayer(args[0]);
            if(targetPlayer == null) { SendReply(netuser, "Игрок не найден"); return; }
            if(TPIncoming.ContainsKey(targetPlayer)) { SendReply(netuser, "[color red]У целевого игрока уже есть ожидающий запрос."); return; }

            object thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
            if (thereturn != null)
            {
                SendReply(netuser, "[color #009D91]Вам запрещено телепортироваться туда, где вы находитесь.");
                return;
            }
            thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { targetPlayer });
            if (thereturn != null)
            {
                SendReply(netuser, "[color #009D91]Вы не можете телепортироваться туда, где цель.");
                return;
            }
			if (targetPlayer == netuser) {
				SendReply(netuser, "[color #009D91]Вы не можете телепортироваться к себе.");
				return;
			}
			if(!ifOnGround(targetPlayer)) {
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на здании, поэтому вы не можете телепортироваться.", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color #009D91]Вы находятся на здании, поэтому [color #D9AE04]{0} [color #009D91]не может телепортироваться к вам", netuser.displayName));
				return;
			}
            if (IfNearStructure(targetPlayer))
            {
                SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91] стоит близко к стене. Невозможно телепортироваться к нему..", targetPlayer.displayName));
                SendReply(targetPlayer, string.Format("[color #009D91]Вы стояли рядом с зданием [color #D9AE04]{0} [color #009D91] не могли телепортироваться к вам.", netuser.displayName));
                return;
            }
            if (ifOnDeployable(targetPlayer)) {
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на объекте, поэтому вы не можете телепортироваться..", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color #009D91]Вы находятся на объекте, поэтому[color #D9AE04]{0} [color #009D91]Не мог телепортироваться к вам.", netuser.displayName));
				return;
			}
			if(ifOnlootsackDeployable(targetPlayer)){
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на съемном объекте, поэтому вы не можете телепортироваться..", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color #009D91]Вы находятся на объекте, поэтому[color #D9AE04]{0} [color #009D91]Не мог телепортироваться к вам.", netuser.displayName));
				return;
			}
			if(ifOnlootDeployable(targetPlayer)){
				SendReply(netuser, string.Format("[color #D9AE04]{0} [color #009D91]Находится на съемном объекте, поэтому вы не можете телепортироваться..", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color #009D91]Вы находятся на объекте, поэтому[color #D9AE04]{0} [color #009D91]Не мог телепортироваться к вам.", netuser.displayName));
				return;
			}
			
            TPRequest.Add(netuser, targetPlayer);
            TPIncoming.Add(targetPlayer, netuser);
            timersList.Add(netuser, timer.Once(10f, () => ResetRequest(netuser)));
            SendReply(netuser, string.Format("[color #009D91]Вы отправили запрос на телепорт игроку [color #D9AE04]{0}.",targetPlayer.displayName));
            SendReply(targetPlayer, string.Format("[color #009D91]Что бы принятять телепорт напишите: [color #D9AE04]{0}[color #009D91]. [color #D9AE04]/accept [color #009D91]или для отмены [color #D9AE04]/noaccept .", netuser.displayName));
        }
        }
        [ChatCommand("accept")]
        void cmdChatTeleportAccept(NetUser netuser, string command, string[] args)
        {
            if(!TPIncoming.ContainsKey(netuser)) { SendReply(netuser, "[color #009D91]У вас нет входящего запроса."); return; }
            var targetuser = TPIncoming[netuser];
			
			if (targetuser == netuser) {
				SendReply(netuser, "[color #009D91]Вы [color #009D91]не можете телепортироваться к себе.");
				return;
			}
            AcceptRequest(TPIncoming[netuser]);
            SendReply(netuser, string.Format( "[color #009D91]Вы приняли запрос телепортации от [color #D9AE04]{0}.", targetuser.displayName));
            SendReply(targetuser, string.Format("[color #D9AE04]{0} [color #009D91]принял вашу заявку на телепорт.", netuser.displayName));
        }
        [ChatCommand("noaccept")]
        void cmdChatTeleportCancel(NetUser netuser, string command, string[] args)
        {
			FallDamage falldamage = netuser.playerClient.rootControllable.GetComponent<FallDamage>();
            if (TPIncoming.ContainsKey(netuser))
            {
				ClearLegInjury(falldamage);
                var targetplayer = TPIncoming[netuser];
                SendReply(netuser, string.Format("[color #009D91]Вы отказались от телепорта [color #D9AE04]{0}", targetplayer.displayName));
                SendReply(targetplayer, string.Format("{0} Отклонил ваш запрос.", netuser.displayName));
                TPIncoming.Remove(netuser);
                if (timersList.ContainsKey(targetplayer))
                {
                    timersList[targetplayer].Destroy();
                    timersList.Remove(targetplayer);
                }
                TPRequest.Remove(targetplayer);
                return;
            }
			ClearLegInjury(falldamage);
            ResetRequest(netuser);
            SendReply(netuser, "[color #009D91]Вы отменили все текущие телепортации.");
        }
        void SendHelpText(NetUser netuser)
        {
            SendReply(netuser, "Teleportation Requests: /noaccept PLAYERNAME");
            SendReply(netuser, "Teleportation Cancel: /tpc");
        }
    }
}