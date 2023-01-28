using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Rust;
using Oxide;
using Oxide.Core;
using Facepunch;
using Facepunch.MeshBatch;
using Oxide.Core.Plugins;
using System.Reflection;

namespace Oxide.Plugins
{
    enum RewardsType{
       Primero,
       Segundo,
       Tercero,
       Cuarto,
	   Septimo,
	   Sexto
    }
    [Info("Rewards", "Daniel25A", 0.2)]
    [Description("Rewards Plugin for oxide")]
    class Rewards:RustLegacyPlugin
    {
        protected static String SystemName = "[Rewards]";
        static string Blue = "[color #0099FF]",
         Red = "[color #FF0000]",
         Pink = "[color #CC66FF]",
         Teal = "[color #00FFFF]",
         Green = "[color #009900]",
         Purple = "[color #6600CC]",
         White = "[color #FFFFFF]",
         Yellow = "[color #FFFF00]";
        protected static Dictionary<ulong, float> TiempoDeJugadoresEnElServer = new Dictionary<ulong, float>();
        void Loaded()
        {
            foreach (var x in rust.GetAllNetUsers())
            {
                if (TiempoDeJugadoresEnElServer.ContainsKey(x.userID) == false)
                    TiempoDeJugadoresEnElServer.Add(x.userID, 0);
            }
            CallTimer();
        }
        void CallTimer()
        {
            timer.Once(60f, () =>
            {
                foreach (var SPlayer in rust.GetAllNetUsers().ToList())
                {
                    if (TiempoDeJugadoresEnElServer.ContainsKey(SPlayer.userID) == false) continue;
                    TiempoDeJugadoresEnElServer[SPlayer.userID] += 1;
                    if (TiempoDeJugadoresEnElServer[SPlayer.userID] == 60)
                    {
                        GiveGiftToPlayer(SPlayer, RewardsType.Primero, TiempoDeJugadoresEnElServer[SPlayer.userID]);
                    }
                    if (TiempoDeJugadoresEnElServer[SPlayer.userID] == 1800)
                    {
                        GiveGiftToPlayer(SPlayer, RewardsType.Segundo, TiempoDeJugadoresEnElServer[SPlayer.userID]);
                    }
                    if (TiempoDeJugadoresEnElServer[SPlayer.userID] == 2400)
                    {
                        GiveGiftToPlayer(SPlayer, RewardsType.Tercero, TiempoDeJugadoresEnElServer[SPlayer.userID]);
                    }
                    if (TiempoDeJugadoresEnElServer[SPlayer.userID] == 3000)
                    {
                        GiveGiftToPlayer(SPlayer, RewardsType.Cuarto, TiempoDeJugadoresEnElServer[SPlayer.userID]);
                    }
                    if (TiempoDeJugadoresEnElServer[SPlayer.userID] == 3600)
                    {
                        GiveGiftToPlayer(SPlayer, RewardsType.Septimo, TiempoDeJugadoresEnElServer[SPlayer.userID]);
                    }
                    if (TiempoDeJugadoresEnElServer[SPlayer.userID] == 4200)
                    {
                        GiveGiftToPlayer(SPlayer, RewardsType.Sexto, TiempoDeJugadoresEnElServer[SPlayer.userID]);
                    }					
                }
                CallTimer();
            }
            );
        }
        void OnPlayerConnected(NetUser netUser)
        {
            if (TiempoDeJugadoresEnElServer.ContainsKey(netUser.userID) == false)
                TiempoDeJugadoresEnElServer.Add(netUser.userID, 0);
        }
        void OnPlayerDisconnected(uLink.NetworkPlayer networkPlayer)
        {
            NetUser PlayerDisconnect = networkPlayer.GetLocalData() as NetUser;
            if (TiempoDeJugadoresEnElServer.ContainsKey(PlayerDisconnect.userID) == true)
                TiempoDeJugadoresEnElServer.Remove(PlayerDisconnect.userID);
        }

        void GiveGiftToPlayer(NetUser Player,RewardsType GiftType,float TimePlaying)
        {
            switch (GiftType)
            {
                case RewardsType.Primero:
                    timer.Once(5f, () =>
                    {
                        rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDIO REGALOS 20 Seg -------");
                        timer.Once(10f, () =>
                        {
                            rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDO REGALOS 10 Seg  50% -------");
                            timer.Once(10f, () =>
                            {
                                rust.SendChatMessage(Player, SystemName, Green + "------- REGALOS CARGADOS   100% -------");
                                timer.Once(15f, () =>
                                {
                                    rust.SendChatMessage(Player, SystemName, Yellow + "------- REGALO DE RECOMPENSAS -------");
                                    rust.SendChatMessage(Player, SystemName, String.Format(White + "Hey" + Red + " {0} " + Green + "Gracias por jugar en nuestro servidor :)", Player.displayName));
                                    rust.SendChatMessage(Player, SystemName, String.Format("{0}Nuestro sistema te da cualquier item para jugar {1}{2} Minutos {3} en el servidor <3", White, Yellow, TimePlaying, Red));
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Pipe Shotgun"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Large Medkit"), 5);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Handmade Shell"), 30);									
                                    rust.SendChatMessage(Player, SystemName, Red + "[color cyan]------- [color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color cyan]-------");
                                });
                            });
                        });
                     });
            
                    break;
                case RewardsType.Segundo:
                    timer.Once(5f, () =>
                    {
                        rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDIO REGALOS 20 Seg -------");
                        timer.Once(10f, () =>
                        {
                            rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDO REGALOS 10 Seg  50% -------");
                            timer.Once(10f, () =>
                            {
                                rust.SendChatMessage(Player, SystemName, Green + "------- REGALOS CARGADOS   100% -------");
                                timer.Once(15f, () =>
                                {
                                    rust.SendChatMessage(Player, SystemName, Yellow + "------- REGALO DE RECOMPENSAS -------");
                                    rust.SendChatMessage(Player, SystemName, String.Format(White + "Hey" + Red + " {0} " + Green + "Gracias por jugar en nuestro servidor :)", Player.displayName));
                                    rust.SendChatMessage(Player, SystemName, String.Format("{0}Nuestro sistema te da cualquier item para jugar {1}{2} Minutos {3} en el servidor <3", White, Yellow, TimePlaying, Red));
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("MP5A4"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("9mm Ammo"), 150);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Large Medkit"), 10);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Leather Vest"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Leather Pants"), 1);									
                                    rust.SendChatMessage(Player, SystemName, Red + "[color cyan]------- [[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color cyan]-------");
                                });
                            });
                        });
                     });
                    break;
                case RewardsType.Tercero:
                    timer.Once(5f, () =>
                    {
                        rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDIO REGALOS 20 Seg -------");
                        timer.Once(10f, () =>
                        {
                            rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDO REGALOS 10 Seg  50% -------");
                            timer.Once(10f, () =>
                            {
                                rust.SendChatMessage(Player, SystemName, Green + "------- REGALOS CARGADOS   100% -------");
                                timer.Once(15f, () =>
                                {
                                    rust.SendChatMessage(Player, SystemName, Yellow + "------- REGALO DE RECOMPENSAS -------");
                                    rust.SendChatMessage(Player, SystemName, String.Format(White + "Hey" + Red + " {0} " + Green + "Gracias por jugar en nuestro servidor :)", Player.displayName));
                                    rust.SendChatMessage(Player, SystemName, String.Format("{0}Nuestro sistema te da cualquier item para jugar {1}{2} Minutos {3} en el servidor <3", White, Yellow, TimePlaying, Red));
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Shotgun"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Shotgun Shells"), 100);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Large Medkit"), 10);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Leather Boots"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Leather Helmet"), 1);									
                                    rust.SendChatMessage(Player, SystemName, Red + "[color cyan]------- [color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』  [color cyan]-------");
                                });
                            });
                        });
                     });
                    break;
                 case RewardsType.Cuarto:
                    timer.Once(5f, () =>
                    {
                        rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDIO REGALOS 20 Seg -------");
                        timer.Once(10f, () =>
                        {
                            rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDO REGALOS 10 Seg  50% -------");
                            timer.Once(10f, () =>
                            {
                                rust.SendChatMessage(Player, SystemName, Green + "------- REGALOS CARGADOS   100% -------");
                                timer.Once(15f, () =>
                                {
                                    rust.SendChatMessage(Player, SystemName, Yellow + "------- REGALO DE RECOMPENSAS -------");
                                    rust.SendChatMessage(Player, SystemName, String.Format(White + "Hey" + Red + " {0} " + Green + "Gracias por jugar en nuestro servidor :)", Player.displayName));
                                    rust.SendChatMessage(Player, SystemName, String.Format("{0}Nuestro sistema te da cualquier item para jugar {1}{2} Minutos {3} en el servidor <3", White, Yellow, TimePlaying, Red));
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("M4"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("556 Ammo"), 200);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Large Medkit"), 10);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Kevlar Vest"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Kevlar Pants"), 1);									
                                    rust.SendChatMessage(Player, SystemName, Red + "[color cyan]-------[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color cyan]-------");
                                });
                            });
                        });
                     });
                    break;
                 case RewardsType.Septimo:
                    timer.Once(5f, () =>
                    {
                        rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDIO REGALOS 20 Seg -------");
                        timer.Once(10f, () =>
                        {
                            rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDO REGALOS 10 Seg  50% -------");
                            timer.Once(10f, () =>
                            {
                                rust.SendChatMessage(Player, SystemName, Green + "------- REGALOS CARGADOS   100% -------");
                                timer.Once(15f, () =>
                                {
                                    rust.SendChatMessage(Player, SystemName, Yellow + "------- REGALO DE RECOMPENSAS -------");
                                    rust.SendChatMessage(Player, SystemName, String.Format(White + "Hey" + Red + " {0} " + Green + "Gracias por jugar en nuestro servidor :)", Player.displayName));
                                    rust.SendChatMessage(Player, SystemName, String.Format("{0}Nuestro sistema te da cualquier item para jugar {1}{2} Minutos {3} en el servidor <3", White, Yellow, TimePlaying, Red));
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Bolt Action Rifle"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("556 Ammo"), 150);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Large Medkit"), 10);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Kevlar Boots"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Kevlar Helmet"), 1);								
                                    rust.SendChatMessage(Player, SystemName, Red + "[color cyan]-------[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color cyan]-------");
                                });
                            });
                        });
                     });
                    break;		
	                 case RewardsType.Sexto:
                    timer.Once(5f, () =>
                    {
                        rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDIO REGALOS 20 Seg -------");
                        timer.Once(10f, () =>
                        {
                            rust.SendChatMessage(Player, SystemName, Green + "------- CARGANDO REGALOS 10 Seg  50% -------");
                            timer.Once(10f, () =>
                            {
                                rust.SendChatMessage(Player, SystemName, Green + "------- REGALOS CARGADOS   100% -------");
                                timer.Once(10f, () =>
                                {
                                    rust.SendChatMessage(Player, SystemName, Yellow + "------- REGALO DE RECOMPENSAS -------");
                                    rust.SendChatMessage(Player, SystemName, String.Format(White + "Hey" + Red + " {0} " + Green + "Gracias por jugar en nuestro servidor :)", Player.displayName));
                                    rust.SendChatMessage(Player, SystemName, String.Format("{0}Nuestro sistema te da cualquier item para jugar {1}{2} Minutos {3} en el servidor <3", White, Yellow, TimePlaying, Red));
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Bolt Action Rifle"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Supply Signal"), 1);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("F1 Grenade"), 10);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Gunpowder"), 200);
                                    Player.playerClient.rootControllable.GetComponent<Inventory>().AddItemAmount(DatablockDictionary.GetByName("Low Quality Metal"), 200);								
                                    rust.SendChatMessage(Player, SystemName, Red + "[color cyan]-------[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color cyan]-------");
                                });
                            });
                        });
                     });
                    break;
            }
        }
    }
}