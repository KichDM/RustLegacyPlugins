using System;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using System.Collections.Generic;
using RustProto;
using System.Linq;

namespace Oxide.Plugins
{
    [Info("Curar", "PionixZ e PINK", 0.1)]
    class Curar : RustLegacyPlugin
    {
        string chatPrefix = "✯NovaLand✯";
        static float curartime = 300;
        int time = 5;
        public float nextcurar;
        bool OnCooldown = true;
        const string Permissao = "curarvip";
        const string Permissao2 = "curarvip2";
        const string Permissao3 = "curarvip3";

        class StoredData
        {
            public Dictionary<ulong, float> cantele = new Dictionary<ulong, float>();
        }

        void Loaded()
        {
           
                storedData = Interface.GetMod().DataFileSystem.ReadObject<StoredData>("Curar");
           
        }

        void Init()
        {
            
                permission.RegisterPermission(Permissao, this);
                permission.RegisterPermission(Permissao2, this);
                permission.RegisterPermission(Permissao3, this);
            
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

        StoredData storedData;

        [ChatCommand("curar")]
        void cmdCurar(NetUser netuser, string command, string[] args)
        {
            
                FallDamage falldamage = netuser.playerClient.rootControllable.GetComponent<FallDamage>();
                ulong steamid = netuser.userID;

                float curartimes = curartime;
                if (hasAccess(netuser))
                    curartimes = 30;
                else if (hasAccess2(netuser))
                    curartimes = 120;
                else if (hasAccess3(netuser))
                    curartimes = 180;
                else
                    curartimes = curartime;

                int timess = time;
                if (hasAccess(netuser))
                    timess = 0;
                else if (hasAccess2(netuser))
                    timess = 0;
                else if (hasAccess3(netuser))
                    timess = 0;
                else
                    timess = time;


                if (OnCooldown == true)
                {
                    if (storedData.cantele.TryGetValue(steamid, out nextcurar))
                    {
                        if (Time.realtimeSinceStartup >= nextcurar)
                        {
                           
                            storedData.cantele[steamid] = Time.realtimeSinceStartup + curartimes;
                        }
                        else
                        {
                            int nexttele = Convert.ToInt32(nextcurar - Time.realtimeSinceStartup);
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
                            rust.SendChatMessage(netuser, chatPrefix, string.Format("[color yellow]Aguarde " + tempo + secondorminute + " para utilizar este comando novamente."));
                            return;
                        }
                    }
                    else
                    {
                       
                        storedData.cantele.Add(steamid, Time.realtimeSinceStartup + curartimes);
                    }
                }

                rust.SendChatMessage(netuser, chatPrefix, "[color green]Suas fraturas estão sendo curadas.");

                if (falldamage.GetLegInjury() > 0)
                {
                    timer.Once(timess, () =>
                    {
                        try
                        {
                            falldamage.ClearInjury();
                        }
                        catch
                        {

                        }
                    });
                }
           
        }
    }
}