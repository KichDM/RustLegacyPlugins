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
    [Info("TPR", "Reneb", "1.0.2", ResourceId = 941)]
    class TPR : RustLegacyPlugin
    {
        [PluginReference]
        Plugin PlayerDatabase;
        /////////////////////////////
        // FIELDS
        /////////////////////////////
        private DateTime epoch;

        RustServerManagement management;

        Dictionary<NetUser,float> lastRequest = new Dictionary<NetUser, float>();
        Dictionary<NetUser, NetUser> TPRequest = new Dictionary<NetUser, NetUser>();
        Dictionary<NetUser, NetUser> TPIncoming = new Dictionary<NetUser, NetUser>();
        Dictionary<NetUser, Oxide.Plugins.Timer> timersList = new Dictionary<NetUser, Oxide.Plugins.Timer>();

        int terrainLayer;

        Vector3 VectorUp = new Vector3(0f, 1f, 0f);
        Vector3 VectorDown = new Vector3(0f, -0.4f, 0f);

        RaycastHit cachedRaycast;
        Collider[] cachedColliders;
        /////////////////////////////
        // Config Management
        /////////////////////////////

        static string notAllowed = "You are not allowed to use this command.";
        static bool cancelOnHurt = true;
        static bool useTokens = true;
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
        void OnServerSave()
        {
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

        void DoTeleportToPlayer(NetUser source, Vector3 target, NetUser targetuser)
        {
            if (source == null || source.playerClient == null)
                return;
            management.TeleportPlayerToWorld(source.playerClient.netPlayer, target);
            SendReply(source, string.Format("Você teletransportado para {0}", targetuser.playerClient.userName));
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
                    SendReply(netuser, "Usuário de destino não respondeu ao seu pedido");
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
                            SendReply(sourceuser, "Teleportation was not a success");
                        }
                        if (targetuser.playerClient)
                        {
                            SendReply(targetuser, "Teleportation was not a success");
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
            if (netuser == null || netuser.playerClient == null) return;
            if(!TPRequest.ContainsKey(netuser)) { SendReply(netuser, "Something went wrong, you dont have a target"); return; }
            var targetuser = TPRequest[netuser];
            if (targetuser == null || targetuser.playerClient == null) { SendReply(netuser, "The target player that you were supposed to teleport to doesn't seem to be connected."); TPRequest.Remove(netuser); return; }

            object thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
            if (thereturn != null)
            {
                SendReply(netuser, "Você não tem permissão para se teletransportar de onde você está.");
                TPRequest.Remove(netuser);
                return;
            } 
            thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { targetuser });
            if (thereturn != null)
            {
                SendReply(netuser, "Você não tem permissão para se teletransportar de onde você está.");
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
                SendReply(netuser, "O alvo parece estar sob uma rocha, não pode se teletransportar você lá.");
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
            FallDamage falldamage = netuser.playerClient.rootControllable.GetComponent<FallDamage>();
            falldamage.SetLegInjury(1f);
            DoTeleportToPlayer(netuser, fixedpos, targetuser);
            timer.Repeat( 2, 2, () => DoTeleportToPlayer(netuser, fixedpos, targetuser));
            timer.Once(4f, () => ClearLegInjury(falldamage));
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
        void OnHurt(TakeDamage takedamage, DamageEvent damage)
        {
            if (!cancelOnHurt) return;
            if (damage.victim.client == null) return;
            if (damage.attacker.client == null) return;
            if (damage.amount < 5f) return;
            NetUser netuser = damage.victim.client.netUser;
            if (TPRequest.ContainsKey(netuser))
            {
                SendReply(netuser, "Teleportation cancelled.");
                ResetRequest(netuser);
            }
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
                SendReply(netuser, "/tpr PLAYER => Para ir ate um jogador");
                if(useTokens)
                {
                    var tokensLeft = GetPlayerTokens(netuser);
                    SendReply(netuser, string.Format("Você tem {0} fichas pra usar",tokensLeft.ToString()));
                }
                return;
            }
            if (TPIncoming.ContainsKey(netuser)) { SendReply(netuser, "Você tem um pedido de teletransporte de entrada , você deve esperar antes de usar este comando."); return; }
            if (TPRequest.ContainsKey(netuser)) { SendReply(netuser, "Você já solicitaram um teletransporte , você deve esperar antes de usar este comando."); return; }

            if (lastRequest.ContainsKey(netuser))
            {
                if(Time.realtimeSinceStartup - lastRequest[netuser] < (float)tprCooldown)
                {
                    SendReply(netuser, string.Format("Você deve esperar {0}s antes de solicitar outro teletransporte .", ((float)tprCooldown - (Time.realtimeSinceStartup - lastRequest[netuser])).ToString()));
                    return;
                }
            }
            if(useTokens)
            {
                var tokensLeft = GetPlayerTokens(netuser);
                if(tokensLeft < 1)
                {
                    SendReply(netuser, "Você não tem  mais fichas, deixou de se teletransportar");
                    return;
                }
            }
           
            
            NetUser targetPlayer = rust.FindPlayer(args[0]);
            if(targetPlayer == null) { SendReply(netuser, "Target player doesn't exist"); return; }
            if(TPIncoming.ContainsKey(targetPlayer)) { SendReply(netuser, "O jogador alvo já tem um pedido pendente."); return; }

            object thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
            if (thereturn != null)
            {
                SendReply(netuser, "Você não tem permissão para se teletransportar de onde você está.");
                return;
            }
            thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { targetPlayer });
            if (thereturn != null)
            {
                SendReply(netuser, "Você não tem permissão para se teletransportar de onde você está.");
                return;
            }

            TPRequest.Add(netuser, targetPlayer);
            TPIncoming.Add(targetPlayer, netuser);
            timersList.Add(netuser, timer.Once(10f, () => ResetRequest(netuser)));
            SendReply(netuser, string.Format("Você enviou um pedido para {0}.",targetPlayer.displayName));
            SendReply(targetPlayer, string.Format("[color green]Você recebeu um pedido de teletransporte [color yellow][ {0} ]. [color green]/tpa para aceitar, /tpc pra negar.", netuser.displayName));
        }
        [ChatCommand("tpa")]
        void cmdChatTeleportAccept(NetUser netuser, string command, string[] args)
        {
            if(!TPIncoming.ContainsKey(netuser)) { SendReply(netuser, "Você não tem qualquer solicitação de entrada ."); return; }
            var targetuser = TPIncoming[netuser];
            AcceptRequest(TPIncoming[netuser]);
            SendReply(netuser, string.Format( "Você aceitou o pedido de teletransporte {0}.", targetuser.displayName));
            SendReply(targetuser, string.Format("{0} aceitou o seu pedido de teletransporte .", netuser.displayName));
        }
        [ChatCommand("tpc")]
        void cmdChatTeleportCancel(NetUser netuser, string command, string[] args)
        {
            if (TPIncoming.ContainsKey(netuser))
            {
                var targetplayer = TPIncoming[netuser];
                SendReply(netuser, string.Format("Você rejeitou {0}'s pedido.", targetplayer.displayName));
                SendReply(targetplayer, string.Format("{0} rejeitou o seu pedido.", netuser.displayName));
                TPIncoming.Remove(netuser);
                if (timersList.ContainsKey(targetplayer))
                {
                    timersList[targetplayer].Destroy();
                    timersList.Remove(targetplayer);
                }
                TPRequest.Remove(targetplayer);
                return;
            }
            ResetRequest(netuser);
            SendReply(netuser, "Você cancelou todos os teletransportes atuais.");
        }
        void SendHelpText(NetUser netuser)
        {
            SendReply(netuser, "Teleportation Requests: /tpr PLAYERNAME");
            SendReply(netuser, "Teleportation Cancel: /tpc");
        }
    }
}