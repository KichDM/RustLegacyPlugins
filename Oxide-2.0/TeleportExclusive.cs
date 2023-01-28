using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using Oxide.Core.Libraries.Covalence;
using Newtonsoft.Json;
using System.Text;
using uLink;


namespace Oxide.Plugins
{
    [Info("TeleportExclusive", "PionixZ", "2.0.0")]
    [Description("Teleports To Usines")]

    class TeleportExclusive : RustLegacyPlugin
    {

        [PluginReference]
        Plugin AdminControl;

        [PluginReference]
        Plugin MoneySystem;

        RustServerManagement management;

        class StoredData
        {
            public Dictionary<ulong, float> cantele = new Dictionary<ulong, float>();
            public Dictionary<ulong, OldPosInfo> UltPos = new Dictionary<ulong, OldPosInfo>();
        }

        Vector3 position;

        class OldPosInfo
        {
            public float OldX;
            public float OldY;
            public float OldZ;

            public OldPosInfo(float x, float y, float z)
            {
                OldX = x;
                OldY = y;
                OldZ = z;
            }

            public OldPosInfo()
            {
            }
        }

        StoredData storedData;

        void Loaded()
        {
           
                storedData = Interface.GetMod().DataFileSystem.ReadObject<StoredData>("Teleporter");
            
        }

        void BreakLegs(PlayerClient player)
        {
            
                if (player == null) return;
                if (player.controllable == null) return;
                player.controllable.GetComponent<FallDamage>().AddLegInjury(1);
            

        }
        void UnbreakLegs(PlayerClient player)
        {
            
                if (player == null) return;
                if (player.controllable == null) return;
                player.controllable.GetComponent<FallDamage>().ClearInjury();
            
        }

        static string chatTag = "Server";
        static float TimeTeleportPlayers = 100;
        int teleportplayer = 10;
		bool OnCooldown = true;
	    public float nextteletime;
        static List<string> OnTeleportPlayers = new List<string>();
        const string Permissao = "teleportvip";
        const string Permissao2 = "teleportvip2";
        const string Permissao3 = "teleportvip3";


        string GetMessage(string key, string steamid = null) => lang.GetMessage(key, this, steamid);

        void Init()
        {
            
                permission.RegisterPermission(Permissao, this);
                permission.RegisterPermission(Permissao2, this);
                permission.RegisterPermission(Permissao3, this);
                SaveConfig();
            
        }

        bool hasAccess(NetUser netUser)
        {
            if (permission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao)) return true;
            return false;
        }
        bool hasAccess2(NetUser netUser)
        {
            if (permission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao2)) return true;
            return false;
        }
        bool hasAccess3(NetUser netUser)
        {
            if (permission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao3)) return true;
            return false;
        }


        void OnPlayerConnected(NetUser netuser)
        {
            
                string ID = netuser.userID.ToString();
                if (OnTeleportPlayers.Contains(ID))
                {
                    OnTeleportPlayers.Remove(ID);
                    return;
                }
            
        }

        private void OnPlayerDisconnected(uLink.NetworkPlayer player)
        {
            var netuser = player.GetLocalData<NetUser>();
            

                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);

            
        }

        [ChatCommand("t")]
        void cmdTList(NetUser netuser, string command, string[] args)
        {
            
                rust.SendChatMessage(netuser, chatTag, "━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] TELEPORTES [color red]◥[color clear]━━━━━━━━━━━━━━━━━━");
                rust.SendChatMessage(netuser, chatTag, "[color red]➤  [color clear]/small  -  [color white]PVP [color green][ON]");
                rust.SendChatMessage(netuser, chatTag, "[color red]➤  [color clear]/vale  -  [color white]PVP [color green][ON]");
                rust.SendChatMessage(netuser, chatTag, "[color red]➤  [color clear]/hangar  -  [color white]PVP [color green][ON]");
                rust.SendChatMessage(netuser, chatTag, "[color red]➤  [color clear]/factory  -  [color white]PVP [color green][ON]");
                rust.SendChatMessage(netuser, chatTag, "[color red]➤  [color clear]/big  -  [color white]PVP [color green][ON]");
                rust.SendChatMessage(netuser, chatTag, "[color red]➤  [color clear]/hvale  -  [color white]PVP [color green][ON]");
                rust.SendChatMessage(netuser, chatTag, "━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] TELEPORTES [color red]◥[color clear]━━━━━━━━━━━━━━━━━━");
            
        }

        [ChatCommand("small")]
        void Small(NetUser netuser, string command)
        {
            
                ulong steamid = netuser.userID;
                string nome = netuser.displayName;

                int teleportplayerr = teleportplayer;
                if (hasAccess(netuser))
                    teleportplayerr = 5;
                else if (hasAccess2(netuser))
                    teleportplayerr = 7;
                else if (hasAccess3(netuser))
                    teleportplayerr = 8;
                else
                    teleportplayerr = teleportplayer;

                float TimeTeleportPlayerss = TimeTeleportPlayers;
                if (hasAccess(netuser))
                    TimeTeleportPlayerss = 30;
                else if (hasAccess2(netuser))
                    TimeTeleportPlayerss = 45;
                else if (hasAccess3(netuser))
                    TimeTeleportPlayerss = 60;
                else
                    TimeTeleportPlayerss = TimeTeleportPlayers;


                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextteletime))
                    {
                        if (Time.realtimeSinceStartup >= nextteletime)
                        {
  
                           
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + TimeTeleportPlayerss;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
                            string secondorminute = "";
                            string tempo = "";

                            if (nexttele <= 60)
                            {
                                secondorminute = "s";
                            }
                            if (nexttele > 60)
                            {
                                secondorminute = "m";
                            }
                            if (nexttele < 60)
                            {
                                tempo = nexttele.ToString();
                            }
                            if (nexttele >= 60)
                            {
                                tempo = "1";
                            }
                            if (nexttele >= 120)
                            {
                                tempo = "2";
                            }
                            if (nexttele >= 180)
                            {
                                tempo = "3";
                            }
                            if (nexttele >= 240)
                            {
                                tempo = "4";
                            }
                            if (nexttele >= 300)
                            {
                                tempo = "5";
                            }
                            rust.SendChatMessage(netuser, chatTag, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                        
                        
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + TimeTeleportPlayerss);
                        goto Finish;
                    }
                }
            Finish:

                if (storedData.UltPos.ContainsKey(steamid) | !storedData.UltPos.ContainsKey(steamid))
                {
                    storedData.UltPos.Remove(steamid);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                    var cachedVector3 = netuser.playerClient.lastKnownPosition;
                    float x = cachedVector3.x;
                    float y = cachedVector3.y;
                    float z = cachedVector3.z;
                    var oldinfo = new OldPosInfo(x, y, z);
                    storedData.UltPos.Add(steamid, oldinfo);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                }

                var random = new System.Random();
                var localizaciones = new List<string>{
           "5913 391 -3495",
           "6074 377 -3545",
           "6100 380 -3555",
           "6053 386 -3583",
           "6044 377 -3589",
           "6077 381 -3655",
           "6044 377 -3589",
           "5935 388 -3509",
           "6128 385 -3415",
           "6218 380 -3568"};
                int index = random.Next(localizaciones.Count);
                rust.Notice(netuser, "Você sera levado para a small em " + teleportplayerr + "s");
                timer.Once(teleportplayerr, () =>
                {
                   
                        var thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
                        if (thereturn != null)
                        {
                            return;
                        }
                        netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        rust.BroadcastChat(chatTag, string.Format("[color red][ ! ] [color white]O jogador [color red]{0}[color white] foi para a [color red]small[color white], utilizando [color cyan]/small", netuser.displayName));
                        rust.RunServerCommand("teleport.topos " + steamid + " " + localizaciones[index]);
                        rust.Notice(netuser, "Você tem 5 segundos de imortalidade");
                        
                        timer.Once(5f, () =>
                        {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                rust.Notice(netuser, "Sua imortabilidade acabou");
                           
                        });
                    
                });
                return;
            
        }
		
		[ChatCommand("big")]
        void big(NetUser netuser, string command)
        {
           
                ulong steamid = netuser.userID;
                string nome = netuser.displayName;

                int teleportplayerr = teleportplayer;
                if (hasAccess(netuser))
                    teleportplayerr = 5;
                else if (hasAccess2(netuser))
                    teleportplayerr = 7;
                else if (hasAccess3(netuser))
                    teleportplayerr = 8;
                else
                    teleportplayerr = teleportplayer;

                float TimeTeleportPlayerss = TimeTeleportPlayers;
                if (hasAccess(netuser))
                    TimeTeleportPlayerss = 30;
                else if (hasAccess2(netuser))
                    TimeTeleportPlayerss = 45;
                else if (hasAccess3(netuser))
                    TimeTeleportPlayerss = 60;
                else
                    TimeTeleportPlayerss = TimeTeleportPlayers;

                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextteletime))
                    {
                        if (Time.realtimeSinceStartup >= nextteletime)
                        {
                            
                            
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + TimeTeleportPlayerss;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
                            string secondorminute = "";
                            string tempo = "";

                            if (nexttele <= 60)
                            {
                                secondorminute = "s";
                            }
                            if (nexttele > 60)
                            {
                                secondorminute = "m";
                            }
                            if (nexttele < 60)
                            {
                                tempo = nexttele.ToString();
                            }
                            if (nexttele >= 60)
                            {
                                tempo = "1";
                            }
                            if (nexttele >= 120)
                            {
                                tempo = "2";
                            }
                            if (nexttele >= 180)
                            {
                                tempo = "3";
                            }
                            if (nexttele >= 240)
                            {
                                tempo = "4";
                            }
                            if (nexttele >= 300)
                            {
                                tempo = "5";
                            }
                            rust.SendChatMessage(netuser, chatTag, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                       
                        
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + TimeTeleportPlayerss);
                        goto Finish;
                    }
                }
            Finish:
                if (storedData.UltPos.ContainsKey(steamid) | !storedData.UltPos.ContainsKey(steamid))
                {
                    storedData.UltPos.Remove(steamid);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                    var cachedVector3 = netuser.playerClient.lastKnownPosition;
                    float x = cachedVector3.x;
                    float y = cachedVector3.y;
                    float z = cachedVector3.z;
                    var oldinfo = new OldPosInfo(x, y, z);
                    storedData.UltPos.Add(steamid, oldinfo);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                }

                var random = new System.Random();
                var localizaciones = new List<string>{
           "5085 376 -4838",
           "5084 376 -4773",
           "5225 372 -4675",
           "5138 382 -4692",
           "5240 360 -5006",
           "5144 363 -4935",
           "5225 365 -4883",
           "5300 361 -4934",
           "5294 369 -4731"};
                int index = random.Next(localizaciones.Count);
                rust.Notice(netuser, "Você sera levado para a big em " + teleportplayerr + "s");
                timer.Once(teleportplayerr, () =>
                {
                    
                        var thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
                        if (thereturn != null)
                        {
                            return;
                        }
                        netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        rust.BroadcastChat(chatTag, string.Format("[color red][ ! ] [color white]O jogador [color red]{0}[color white] foi para a [color red]big[color white], utilizando [color cyan]/big", netuser.displayName));
                        rust.Notice(netuser, "Você tem 5 segundos de imortalidade");
                        rust.RunServerCommand("teleport.topos " + steamid + " " + localizaciones[index]);
                        
                        timer.Once(5f, () =>
                        {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                rust.Notice(netuser, "Sua imortabilidade acabou");
                            
                        });
                    
                });
                return;
            
        }
		
		[ChatCommand("hvale")]
        void hvale(NetUser netuser, string command)
        {
           
                ulong steamid = netuser.userID;
                string nome = netuser.displayName;

                int teleportplayerr = teleportplayer;
                if (hasAccess(netuser))
                    teleportplayerr = 5;
                else if (hasAccess2(netuser))
                    teleportplayerr = 7;
                else if (hasAccess3(netuser))
                    teleportplayerr = 8;
                else
                    teleportplayerr = teleportplayer;

                float TimeTeleportPlayerss = TimeTeleportPlayers;
                if (hasAccess(netuser))
                    TimeTeleportPlayerss = 30;
                else if (hasAccess2(netuser))
                    TimeTeleportPlayerss = 45;
                else if (hasAccess3(netuser))
                    TimeTeleportPlayerss = 60;
                else
                    TimeTeleportPlayerss = TimeTeleportPlayers;

                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextteletime))
                    {
                        if (Time.realtimeSinceStartup >= nextteletime)
                        {
                           
                            
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + TimeTeleportPlayerss;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
                            string secondorminute = "";
                            string tempo = "";

                            if (nexttele <= 60)
                            {
                                secondorminute = "s";
                            }
                            if (nexttele > 60)
                            {
                                secondorminute = "m";
                            }
                            if (nexttele < 60)
                            {
                                tempo = nexttele.ToString();
                            }
                            if (nexttele >= 60)
                            {
                                tempo = "1";
                            }
                            if (nexttele >= 120)
                            {
                                tempo = "2";
                            }
                            if (nexttele >= 180)
                            {
                                tempo = "3";
                            }
                            if (nexttele >= 240)
                            {
                                tempo = "4";
                            }
                            if (nexttele >= 300)
                            {
                                tempo = "5";
                            }
                            rust.SendChatMessage(netuser, chatTag, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                        
                        
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + TimeTeleportPlayerss);
                        goto Finish;
                    }
                }
            Finish:
                if (storedData.UltPos.ContainsKey(steamid) | !storedData.UltPos.ContainsKey(steamid))
                {
                    storedData.UltPos.Remove(steamid);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                    var cachedVector3 = netuser.playerClient.lastKnownPosition;
                    float x = cachedVector3.x;
                    float y = cachedVector3.y;
                    float z = cachedVector3.z;
                    var oldinfo = new OldPosInfo(x, y, z);
                    storedData.UltPos.Add(steamid, oldinfo);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                }

                var random = new System.Random();
                var localizaciones = new List<string>{
           "5984 396 -2046",
           "5930 387 -2177",
           "5978 401 -2134",
           "5563 406 -2176",
           "5870 389 -2223",
           "6160 391 -2056",
           "5614 400 -2252"};
                int index = random.Next(localizaciones.Count);
                rust.Notice(netuser, "Você sera levado para o hvale em " + teleportplayerr + "s");
                timer.Once(teleportplayerr, () =>
                {
                   
                        var thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
                        if (thereturn != null)
                        {
                            return;
                        }
                        netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        rust.BroadcastChat(chatTag, string.Format("[color red][ ! ] [color white]O jogador [color red]{0}[color white] foi para o [color red]hvale[color white], utilizando [color cyan]/hvale", netuser.displayName));
                        rust.Notice(netuser, "Você tem 5 segundos de imortalidade");
                        rust.RunServerCommand("teleport.topos " + steamid + " " + localizaciones[index]);
                        
                        timer.Once(5f, () =>
                        {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                rust.Notice(netuser, "Sua imortabilidade acabou");
                           
                        });
                   
                });
                return;
        }
		
	    [ChatCommand("vale")]
        void vale(NetUser netuser, string command)
        {
            
                ulong steamid = netuser.userID;
                string nome = netuser.displayName;

                int teleportplayerr = teleportplayer;
                if (hasAccess(netuser))
                    teleportplayerr = 5;
                else if (hasAccess2(netuser))
                    teleportplayerr = 7;
                else if (hasAccess3(netuser))
                    teleportplayerr = 8;
                else
                    teleportplayerr = teleportplayer;

                float TimeTeleportPlayerss = TimeTeleportPlayers;
                if (hasAccess(netuser))
                    TimeTeleportPlayerss = 30;
                else if (hasAccess2(netuser))
                    TimeTeleportPlayerss = 45;
                else if (hasAccess3(netuser))
                    TimeTeleportPlayerss = 60;
                else
                    TimeTeleportPlayerss = TimeTeleportPlayers;

                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextteletime))
                    {
                        if (Time.realtimeSinceStartup >= nextteletime)
                        {
                           
                           
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + TimeTeleportPlayerss;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
                            string secondorminute = "";
                            string tempo = "";

                            if (nexttele <= 60)
                            {
                                secondorminute = "s";
                            }
                            if (nexttele > 60)
                            {
                                secondorminute = "m";
                            }
                            if (nexttele < 60)
                            {
                                tempo = nexttele.ToString();
                            }
                            if (nexttele >= 60)
                            {
                                tempo = "1";
                            }
                            if (nexttele >= 120)
                            {
                                tempo = "2";
                            }
                            if (nexttele >= 180)
                            {
                                tempo = "3";
                            }
                            if (nexttele >= 240)
                            {
                                tempo = "4";
                            }
                            if (nexttele >= 300)
                            {
                                tempo = "5";
                            }
                            rust.SendChatMessage(netuser, chatTag, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                        
                       
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + TimeTeleportPlayerss);
                        goto Finish;
                    }
                }
            Finish:
                if (storedData.UltPos.ContainsKey(steamid) | !storedData.UltPos.ContainsKey(steamid))
                {
                    storedData.UltPos.Remove(steamid);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                    var cachedVector3 = netuser.playerClient.lastKnownPosition;
                    float x = cachedVector3.x;
                    float y = cachedVector3.y;
                    float z = cachedVector3.z;
                    var oldinfo = new OldPosInfo(x, y, z);
                    storedData.UltPos.Add(steamid, oldinfo);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                }

                var random = new System.Random();
                var localizaciones = new List<string>{
           "4776 445 -3689",
           "4473 476 -3793",
           "4628 464 -3709",
           "4738 445 -3723",
           "4591 469 -3734",
           "4738 445 -3723",
           "4694 447 -3735",
           "4567 462 -3770",
           "4473 476 -3793",
           "4817 442 -3671",
           "4639 446 -3856",
           "4847 430 -3903",
           "4858 430 -3704"};
                int index = random.Next(localizaciones.Count);
                rust.Notice(netuser, "Você sera levado para o vale em " + teleportplayerr + "s");
                timer.Once(teleportplayerr, () =>
                {
   
                        var thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
                        if (thereturn != null)
                        {
                            return;
                        }
                        netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        rust.BroadcastChat(chatTag, string.Format("[color red][ ! ] [color white]O jogador [color red]{0}[color white] foi para o [color red]vale[color white], utilizando [color cyan]/vale", netuser.displayName));
                        rust.Notice(netuser, "Você tem 5 segundos de imortalidade");
                        rust.RunServerCommand("teleport.topos " + steamid + " " + localizaciones[index]);
                        
                        timer.Once(5f, () =>
                        {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                rust.Notice(netuser, "Sua imortabilidade acabou");
                            
                        });
 
                });
                return;

        }
		
	    [ChatCommand("factory")]
        void factory(NetUser netuser, string command)
        {
           
                ulong steamid = netuser.userID;
                string nome = netuser.displayName;
                int teleportplayerr = teleportplayer;
                if (hasAccess(netuser))
                    teleportplayerr = 5;
                else if (hasAccess2(netuser))
                    teleportplayerr = 7;
                else if (hasAccess3(netuser))
                    teleportplayerr = 8;
                else
                    teleportplayerr = teleportplayer;

                float TimeTeleportPlayerss = TimeTeleportPlayers;
                if (hasAccess(netuser))
                    TimeTeleportPlayerss = 30;
                else if (hasAccess2(netuser))
                    TimeTeleportPlayerss = 45;
                else if (hasAccess3(netuser))
                    TimeTeleportPlayerss = 60;
                else
                    TimeTeleportPlayerss = TimeTeleportPlayers;

                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextteletime))
                    {
                        if (Time.realtimeSinceStartup >= nextteletime)
                        {
                           
                            
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + TimeTeleportPlayerss;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
                            string secondorminute = "";
                            string tempo = "";

                            if (nexttele <= 60)
                            {
                                secondorminute = "s";
                            }
                            if (nexttele > 60)
                            {
                                secondorminute = "m";
                            }
                            if (nexttele < 60)
                            {
                                tempo = nexttele.ToString();
                            }
                            if (nexttele >= 60)
                            {
                                tempo = "1";
                            }
                            if (nexttele >= 120)
                            {
                                tempo = "2";
                            }
                            if (nexttele >= 180)
                            {
                                tempo = "3";
                            }
                            if (nexttele >= 240)
                            {
                                tempo = "4";
                            }
                            if (nexttele >= 300)
                            {
                                tempo = "5";
                            }
                            rust.SendChatMessage(netuser, chatTag, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                        
                        
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + TimeTeleportPlayerss);
                        goto Finish;
                    }
                }
            Finish:
                if (storedData.UltPos.ContainsKey(steamid) | !storedData.UltPos.ContainsKey(steamid))
                {
                    storedData.UltPos.Remove(steamid);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                    var cachedVector3 = netuser.playerClient.lastKnownPosition;
                    float x = cachedVector3.x;
                    float y = cachedVector3.y;
                    float z = cachedVector3.z;
                    var oldinfo = new OldPosInfo(x, y, z);
                    storedData.UltPos.Add(steamid, oldinfo);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                }

                var random = new System.Random();
                var localizaciones = new List<string>{
           "6306 360 -4647",
           "6474 362 -4513",
           "6401 358 -4441",
           "6474 362 -4513",
           "6344 365 -4408",
           "6255 355 -4509",
           "6472 360 -4586"};
                int index = random.Next(localizaciones.Count);
                rust.Notice(netuser, "Você sera levado para a factory em " + teleportplayerr + "s");
                timer.Once(teleportplayerr, () =>
                {
   
                        var thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
                        if (thereturn != null)
                        {
                            return;
                        }
                        netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        rust.BroadcastChat(chatTag, string.Format("[color red][ ! ] [color white]O jogador [color red]{0}[color white] foi para a [color red]factory[color white], utilizando [color cyan]/factory", netuser.displayName));
                        rust.Notice(netuser, "Você tem 5 segundos de imortalidade");
                        rust.RunServerCommand("teleport.topos " + steamid + " " + localizaciones[index]);
                        
                        timer.Once(5f, () =>
                        {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                rust.Notice(netuser, "Sua imortabilidade acabou");
                            
                        });
       
                });
                return;
  
        }
		
        [ChatCommand("hangar")]
        void hangar(NetUser netuser, string command)
        {

                ulong steamid = netuser.userID;
                string nome = netuser.displayName;

                int teleportplayerr = teleportplayer;
                if (hasAccess(netuser))
                    teleportplayerr = 5;
                else if (hasAccess2(netuser))
                    teleportplayerr = 7;
                else if (hasAccess3(netuser))
                    teleportplayerr = 8;
                else
                    teleportplayerr = teleportplayer;

                float TimeTeleportPlayerss = TimeTeleportPlayers;
                if (hasAccess(netuser))
                    TimeTeleportPlayerss = 30;
                else if (hasAccess2(netuser))
                    TimeTeleportPlayerss = 45;
                else if (hasAccess3(netuser))
                    TimeTeleportPlayerss = 60;
                else
                    TimeTeleportPlayerss = TimeTeleportPlayers;

                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextteletime))
                    {
                        if (Time.realtimeSinceStartup >= nextteletime)
                        {
                            
                            
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + TimeTeleportPlayerss;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextteletime - Time.realtimeSinceStartup);
                            string secondorminute = "";
                            string tempo = "";

                            if (nexttele <= 60)
                            {
                                secondorminute = "s";
                            }
                            if (nexttele > 60)
                            {
                                secondorminute = "m";
                            }
                            if (nexttele < 60)
                            {
                                tempo = nexttele.ToString();
                            }
                            if (nexttele >= 60)
                            {
                                tempo = "1";
                            }
                            if (nexttele >= 120)
                            {
                                tempo = "2";
                            }
                            if (nexttele >= 180)
                            {
                                tempo = "3";
                            }
                            if (nexttele >= 240)
                            {
                                tempo = "4";
                            }
                            if (nexttele >= 300)
                            {
                                tempo = "5";
                            }
                            rust.SendChatMessage(netuser, chatTag, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                        
                        
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + TimeTeleportPlayerss);
                        goto Finish;
                    }
                }
            Finish:
                if (storedData.UltPos.ContainsKey(steamid) | !storedData.UltPos.ContainsKey(steamid))
                {
                    storedData.UltPos.Remove(steamid);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                    var cachedVector3 = netuser.playerClient.lastKnownPosition;
                    float x = cachedVector3.x;
                    float y = cachedVector3.y;
                    float z = cachedVector3.z;
                    var oldinfo = new OldPosInfo(x, y, z);
                    storedData.UltPos.Add(steamid, oldinfo);
                    Interface.GetMod().DataFileSystem.WriteObject("", storedData);
                }

                var random = new System.Random();
                var localizaciones = new List<string>{
           "6548 359 -4332",
           "6817 342 -4207",
           "6762 330 -4379",
           "6616 356 -4192",
           "6634 351 -4313",
           "6695 343 -4355",
           "6642 353 -4236"};
                int index = random.Next(localizaciones.Count);
                rust.Notice(netuser, "Você sera levado para o hangar em " + teleportplayerr + "s");
                timer.Once(teleportplayerr, () =>
                {
                   
                        var thereturn = Interface.GetMod().CallHook("canTeleport", new object[] { netuser });
                        if (thereturn != null)
                        {
                            return;
                        }
                        netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        rust.BroadcastChat(chatTag, string.Format("[color red][ ! ] [color white]O jogador [color red]{0}[color white] foi para o [color red]hangar[color white], utilizando [color cyan]/hangar", netuser.displayName));
                        rust.Notice(netuser, "Você tem 5 segundos de imortalidade");
                        rust.RunServerCommand("teleport.topos " + steamid + " " + localizaciones[index]);
              
                        timer.Once(5f, () =>
                     {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                rust.Notice(netuser, "Sua imortabilidade acabou");
                            
                        });
                    
                });
                return;
            
        }

    }
}