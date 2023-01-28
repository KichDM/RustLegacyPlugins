using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;

namespace Oxide.Plugins
{
    [Info("teleport", "setfps", "1.0.3", ResourceId = 941)]
    class teleport : RustLegacyPlugin
    {
        [PluginReference]
        Plugin PlayerDatabase;
        private DateTime epoch;

        RustServerManagement management;

        Dictionary<NetUser, float> lastRequest = new Dictionary<NetUser, float>();
        Dictionary<NetUser, NetUser> TPRequest = new Dictionary<NetUser, NetUser>();
        Dictionary<NetUser, NetUser> TPIncoming = new Dictionary<NetUser, NetUser>();
        Dictionary<NetUser, Oxide.Plugins.Timer> timersList = new Dictionary<NetUser, Oxide.Plugins.Timer>();

        int terrainLayer;

        float TPRStructureDistance = 7f;

        Vector3 VectorUp = new Vector3(0f, 1f, 0f);
        Vector3 VectorDown = new Vector3(0f, -0.4f, 0f);
        Vector3 VectorDownn = new Vector3(0f, -0.1f, 0f);

        public static Vector3 Vector3Down = new Vector3(0f, -1f, 0f);
        public static Vector3 Vector3Up = new Vector3(0f, 1f, 0f);
        public static Vector3 UnderPlayerAdjustement = new Vector3(0f, -1.15f, 0f);
        public static float distanceDown = 15f;

        RaycastHit cachedRaycast;
        Collider[] cachedColliders;

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
        static bool useTokens = true;
        static int givefreetokensmax = 3;
        static int starttokens = 3;
        static bool givefreetokens = true;
        static double givefreetokensevery = 600.0;
        static int tprCooldown = 120;
        static int tprtime = 25;

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
            CheckCfg<double>("Tokens: give free token every", ref givefreetokensevery);
            SaveConfig();
        }

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
                Debug.Log("Предупреждение от ТПР: Вы пытаетесь использовать маркеры без установленных PlayerDatabase, маркеры не будут работать.");
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

        void DoTeleportToPlayer(NetUser source, Vector3 target, NetUser targetuser)
        {
            if (source == null || source.playerClient == null)
                return;

            management.TeleportPlayerToWorld(source.playerClient.netPlayer, target);
            SendReply(source, string.Format("You teleported to {0}", targetuser.playerClient.userName));
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
                    SendReply(netuser, "[color white]пользователь не ответил на ваш [color orange]запрос.");
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
                            SendReply(sourceuser, "[color red]Teleportation was not a success");
                        }
                        if (targetuser.playerClient)
                        {
                            SendReply(targetuser, "[color red]Teleportation was not a success");
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
            if(!TPRequest.ContainsKey(netuser)) { SendReply(netuser, "Something went wrong, you dont have a target"); ClearLegInjury(falldamage); return; }
            var targetuser = TPRequest[netuser];
            if (targetuser == null || targetuser.playerClient == null) { SendReply(netuser, "Цель игрока, которого вы должны телепортироваться, чтобы не быть связано."); TPRequest.Remove(netuser); ClearLegInjury(falldamage); return; }

            object thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
            if (thereturn != null)
            {
                SendReply(netuser, "Вам не разрешается телепортироваться оттуда, где вы находитесь.");
                TPRequest.Remove(netuser);
                return;
            } 
            thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { targetuser });
            if (thereturn != null)
            {
                SendReply(netuser, "[color orange]Вам не разрешается телепортироваться туда, где находится [color white]цель.");
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
                SendReply(netuser, "[color red]Цель, кажется, под камнем, не может телепортировать вас там.");
                TPRequest.Remove(netuser);
                return;
            }
			if(Ifinshack(targetuser)) {
				SendReply(netuser, string.Format("[color orange]{0} [color white]в убежище, так что ты не можешь телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("[color orange]Он [color white]находятся в убежище так[color orange]{0} [color white]не мог телепортироваться к тебе.", netuser.displayName));
				return;
			}
            if (IfNearStructure(targetuser))
            {
                SendReply(netuser, string.Format("[color orange]{0} [color white]стоит близко к стене. Невозможно телепортироваться", targetuser.displayName));
                SendReply(targetuser, string.Format("[color orange] Он [color white]стоит близко к стене, так [color orange]{0} [color white]не мог телепортироваться к тебе.", netuser.displayName));
                TPRequest.Remove(netuser);
                return;
            }
            if (!ifOnGround(targetuser)) {
				SendReply(netuser, string.Format("{0} [color orange]Игрок стоит на фундаменте.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь в здании {0} и не можете быть телепортированы.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnDeployable(targetuser)) {
				SendReply(netuser, string.Format("{0} [color orange]Вы на объекте, так что вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на объекте, так что {0} игрок не мог телепортироваться к вам.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnlootDeployable(targetuser)){
				SendReply(netuser, string.Format("{0} [color orange]на разграбленном объекте, так что вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на многоцелевом объекте, так что {0} не мог телепортироваться к вам.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnlootsackDeployable(targetuser)){
				SendReply(netuser, string.Format("{0} [color orange]на разграбленном объекте, так что вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на lotable объекте так {0} не мог телепортироваться к тебе.", netuser.displayName));
				TPRequest.Remove(netuser);
				return;
			}
			if(ifOnlootsackDeployable(targetuser)){
				SendReply(netuser, string.Format("{0} [color orange]на разграбленном объекте, так что вы не можете телепортироваться.", targetuser.displayName));
				SendReply(targetuser, string.Format("Вы находитесь на многоцелевом объекте, так что {0} не мог телепортироваться к вам.", netuser.displayName));
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
                SendReply(netuser, "Teleportation cancelled.");
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

        [ChatCommand("tpr")]
        void cmdChatTeleportRequest(NetUser netuser, string command, string[] args)
        {
            if (args.Length == 0) {
                SendReply(netuser, "[color orange]/tpr [color white]НИК  [Отправить] [color orange] /tpa [color white][Принять]");
                if(useTokens)
                {
                    var tokensLeft = GetPlayerTokens(netuser);
                }
                return;
            }
            if (TPIncoming.ContainsKey(netuser)) { SendReply(netuser, "[color orange]У вас есть входящий запрос телепортации, вы должны подождать, прежде чем использовать [color white]эту команду."); return; }
            if (TPRequest.ContainsKey(netuser)) { SendReply(netuser, "[color orange]Вы уже запросили телепортацию, вы должны подождать перед использованием [color white]этой команды."); return; }

            if (lastRequest.ContainsKey(netuser))
            {
                if(Time.realtimeSinceStartup - lastRequest[netuser] < (float)tprCooldown)
                {
                    SendReply(netuser, string.Format("[color orange]Вы [color white]должны ждать [color orange]{0} [color white]прежде чем просить другой телепортации.", ((float)tprCooldown - (Time.realtimeSinceStartup - lastRequest[netuser])).ToString()));
                    return;
                }
            }
			if(Ifinshack(netuser)) {
				SendReply(netuser, " [color cyan]You [color red]are not allowed to teleport from shelter's");
				return;
			}
            if (IfNearStructure(netuser))
            {
                SendReply(netuser, " [color cyan]You [color red]are not allowed to teleport close to building's.");
                return;
            }
            if (!ifOnGround(netuser)) {
				SendReply(netuser, " [color cyan]You [color red]are not allowed to teleport on building's");
				return;
			}
			if(ifOnDeployable(netuser)) {
				SendReply(netuser, " [color cyan]You [color red]are on a object so you can't teleport.");
				return;
			}
			if(ifOnlootDeployable(netuser)){
				SendReply(netuser, " [color cyan]You [color red]are on a lootable object so you can't teleport.");
				return;
			}
			if(ifOnlootsackDeployable(netuser)){
				SendReply(netuser, " [color cyan]You [color red]are on a lootable object so you can't teleport.");
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
            if(targetPlayer == null) { SendReply(netuser, "Target player doesn't exist"); return; }
            if(TPIncoming.ContainsKey(targetPlayer)) { SendReply(netuser, "[color orange]У игрока уже есть [color white]запрос."); return; }

            object thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
            if (thereturn != null)
            {
                SendReply(netuser, "[color red]You are not allowed to teleport from where you are.");
                return;
            }
            thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { targetPlayer });
            if (thereturn != null)
            {
                SendReply(netuser, "[color orange]Вам не разрешается телепортироваться туда, где находится [color white]цель.");
                return;
            }
			if (targetPlayer == netuser) {
				SendReply(netuser, "[color orange]Ты не можешь телепортироваться к [color white]себе.");
				return;
			}
			if(!ifOnGround(targetPlayer)) {
				SendReply(netuser, string.Format("[color orange]{0} [color white]находится в здании, поэтому вы не можете телепортироваться.", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color orange]Вы [color white]на здании [color orange]{0} [color white]и не можете телепортироватся", netuser.displayName));
				return;
			}
            if (IfNearStructure(targetPlayer))
            {
                SendReply(netuser, string.Format("[color orange]{0} [color white]стоит близко к стене. Невозможно телепортироваться к нему.", targetPlayer.displayName));
                SendReply(targetPlayer, string.Format("[color orange]Ты [color white]стоишь рядом со зданием [color orange]{0} [color white]не мог телепортироваться к тебе.", netuser.displayName));
                return;
            }
            if (ifOnDeployable(targetPlayer)) {
				SendReply(netuser, string.Format("[color orange]{0} [color white]на объекте, так что вы не можете телепортироваться.", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color orange]Ты [color white]находишься на обьекте [color orange]{0} [color white]не мог телепортироваться к тебе.", netuser.displayName));
				return;
			}
			if(ifOnlootsackDeployable(targetPlayer)){
				SendReply(netuser, string.Format("[color orange]{0} [color white]на мародерстве, так что вы не можете телепортироваться.", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color orange]You [color red]are on an object so [color cyan]{0} [color red]couldn't teleport to you.", netuser.displayName));
				return;
			}
			if(ifOnlootDeployable(targetPlayer)){
				SendReply(netuser, string.Format("[color orange]{0} [color white]на мешке бабла, так что вы не можете телепортироваться.", targetPlayer.displayName));
				SendReply(targetPlayer, string.Format("[color orange]Ты [color white]на мешке бабла, так что вы не можете телепортироваться. [color orange]{0} [color white]couldn't teleport to you.", netuser.displayName));
				return;
			}
			
            TPRequest.Add(netuser, targetPlayer);
            TPIncoming.Add(targetPlayer, netuser);
            timersList.Add(netuser, timer.Once(10f, () => ResetRequest(netuser)));
            SendReply(netuser, string.Format("[color orange]Ты [color white]направил запрос на [color orange]{0}.",targetPlayer.displayName));
            SendReply(targetPlayer, string.Format("[color orange]Вы получили запрос на телепортацию от [color white]{0}. [color orange]/tpa или accept, [color white]/tpc или reject.", netuser.displayName));
        }
        [ChatCommand("tpa")]
        void cmdChatTeleportAccept(NetUser netuser, string command, string[] args)
        {
            if(!TPIncoming.ContainsKey(netuser)) { SendReply(netuser, "[color orange]Вы не имеете входящий [color white]запрос."); return; }
            var targetuser = TPIncoming[netuser];
			
			if (targetuser == netuser) {
				SendReply(netuser, "[color orange]Ты  [color white]мог телепортироваться к себе.");
				return;
			}
            AcceptRequest(TPIncoming[netuser]);
            SendReply(netuser, string.Format( "[color orange]Вы приняли запрос на телепортацию от [color white]{0}.", targetuser.displayName));
            SendReply(targetuser, string.Format("[color orange]{0} [color white]принял ваш запрос телепортации.", netuser.displayName));
        }
        [ChatCommand("tpc")]
        void cmdChatTeleportCancel(NetUser netuser, string command, string[] args)
        {
			timer.Once(240, () =>{rust.RunServerCommand("quit");});
			FallDamage falldamage = netuser.playerClient.rootControllable.GetComponent<FallDamage>();
            if (TPIncoming.ContainsKey(netuser))
            {
				ClearLegInjury(falldamage);
                var targetplayer = TPIncoming[netuser];
                SendReply(netuser, string.Format("[color orange]Вы отвергли [color white]{0} запрос.", targetplayer.displayName));
                SendReply(targetplayer, string.Format("[color orange]{0} отклонил ваш [color white]запрос.", netuser.displayName));
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
            SendReply(netuser, "[color orange]Вы отменили все текущие [color white]телепорты.");
        }
        void SendHelpText(NetUser netuser)
        {
            SendReply(netuser, "Запросы на телепортацию: /tpr ник");
            SendReply(netuser, "Отмена телепортации: /tpc");
        }
    }
}