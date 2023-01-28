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
    [Info("Tempo", "PionixZ", "1.0.0")]
    class Tempo : RustLegacyPlugin
    {
        /////////////////////////////
        // FIELDS
        /////////////////////////////

        bool pluginActivated = true;
        Plugins.Timer plugintimer;
        float cachedTime;
        float cachedDelta;
        float cachedCurrentTime;
        float cachedDaytime;
        float cachedNighttime;
        /////////////////////////////
        // Config Management
        /////////////////////////////

        string prefixo = "Server";
        public static int dayTimeSeconds = 2700;
        public static int nightTimeSeconds = 900;
        public static int dayTime = 7;
        public static int nightTime = 19;
        public static int startTime = 12;
        public static bool freezeTime = true;


        void Init()
        {
            SaveConfig();
        }


        /////////////////////////////
        // Oxide Hooks
        ///////////////////////////// 

        void Loaded()
        {
           
                if (!permission.PermissionExists("cantime")) permission.RegisterPermission("cantime", this);
                if (!permission.PermissionExists("all")) permission.RegisterPermission("all", this);
            
        }
        void OnServerSave()
        {
        }
        void OnServerInitialized()
        {
            
                InitiateTime(true);
            
        }
        void Unload()
        {
            
                plugintimer.Destroy();
           
        } 
        void InitiateTime(bool settime)
        {
            
                if (plugintimer != null) plugintimer.Destroy();
                env.daylength = 999999999f;
                env.nightlength = 99999999f;
                if (settime) EnvironmentControlCenter.Singleton.SetTime(Convert.ToSingle(startTime));
                cachedDaytime = Convert.ToSingle(dayTime);
                cachedNighttime = Convert.ToSingle(nightTime);
                if (cachedDaytime < 1f) cachedDaytime = 1f;
                if (cachedNighttime < 1f) cachedNighttime = 1f;
                plugintimer = timer.Repeat(1f, 0, () => CheckTime());
            
        }
        void CheckTime()
        {
            
                if (freezeTime) return;
                cachedTime = EnvironmentControlCenter.Singleton.GetTime();
                if (cachedTime >= cachedDaytime && cachedTime < cachedNighttime)
                {
                    cachedDelta = cachedTime + (1f / dayTimeSeconds) * (cachedNighttime - cachedDaytime);
                    EnvironmentControlCenter.Singleton.SetTime((float)cachedDelta);
                }
                else
                {
                    cachedDelta = cachedTime + (1f / nightTimeSeconds) * (cachedDaytime + 24f - cachedNighttime);
                    EnvironmentControlCenter.Singleton.SetTime((float)cachedDelta);
                }
            
        }
        bool hasAccess(NetUser netuser)
        {
            if (netuser.CanAdmin()) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "cantime")) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), "all");
        }
        [ChatCommand("time")]
        void cmdChatTime(NetUser netuser, string command, string[] args)
        {
            

                if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, prefixo, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0)
                {
                    rust.SendChatMessage(netuser, prefixo, "[color cyan]Use [color white]/time <tempo> - [color cyan]para setar o tempo.");
                    return;
                }
                switch (args[0].ToLower())
                {
                    case "freeze":
                        if (freezeTime)
                        {
                            freezeTime = false;
                            rust.SendChatMessage(netuser, prefixo, "[[color red]✖[color clear]]  Tempo foi destravado com sucesso.");
                        }
                        else
                        {
                            freezeTime = true;
                            rust.SendChatMessage(netuser, prefixo, "[[color green]✔[color clear]]   Tempo travado com sucesso.");
                        }
                        break;
                    default:
                        float newtime = 12f;
                        if (float.TryParse(args[0], out newtime))
                        {
                            EnvironmentControlCenter.Singleton.SetTime(newtime);
                            return;
                        }
                        rust.SendChatMessage(netuser, prefixo, "[color cyan]Use [color white]/time <tempo> - [color cyan]para setar o tempo.");
                        rust.SendChatMessage(netuser, prefixo, "[color cyan]Use [color white]/time freeze - [color cyan]para travar o tempo.");
                        return;
                        break;
                }
                SaveConfig();
                InitiateTime(false);
           
        }

    }
}