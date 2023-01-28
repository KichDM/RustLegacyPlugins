using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Newtonsoft.Json;
using RustProto;

namespace Oxide.Plugins
{
    [Info("AdminPunishment", "PINK", "0.1.0")]
    class AdminPunishment : RustLegacyPlugin
    {
        NetUser cachedUser;
        string cachedSteamid;
        string cachedReason;
        string cachedName;

        public Type BanType;
        public FieldInfo steamid;
        public FieldInfo username;
        public FieldInfo reason;
        public FieldInfo bannedUsers;

        [PluginReference]
        private Plugin PlayerDatabase;

        public string SystemName = "Server";

        private Core.Configuration.DynamicConfigFile Data;
        private Core.Configuration.DynamicConfigFile Info;
        private Core.Configuration.DynamicConfigFile Wl;
        void LoadData() 
        {
            
                Data = Interface.GetMod().DataFileSystem.GetDatafile("Blacklist(ip)"); Info = Interface.GetMod().DataFileSystem.GetDatafile("Blacklist(ip.pl)"); Wl = Interface.GetMod().DataFileSystem.GetDatafile("Blacklist(ip.wl)");
            
        }
        void SaveData() 
        {
           
                Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)"); Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip.pl)"); Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip.wl)");
            
        }
        void Unload() 
        {
            
                SaveData();
            
        }

        private string QuoteSafe(string str) => "\"" + str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' }) + "\"";
        private static string QuoteSafeStatic(string str) => "\"" + str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' }) + "\"";
        
        void OnServerSave()
        {
            
                if (shouldsaveonserversave)
                {
                    SaveData();
                }
           
        }
        
        void Loaded()
        {
            
                LoadData();
                if (!permission.PermissionExists("canban")) permission.RegisterPermission("canban", this);
                if (!permission.PermissionExists("canunban")) permission.RegisterPermission("canunban", this);

                BanType = typeof(BanList).GetNestedType("Ban", BindingFlags.Instance | BindingFlags.NonPublic);
                steamid = BanType.GetField("steamid");
                username = BanType.GetField("username");
                reason = BanType.GetField("reason");

                bannedUsers = typeof(BanList).GetField("bannedUsers", (BindingFlags.Static | BindingFlags.NonPublic));
           
        }

        public static bool preventadminban = true;
        public static bool shouldsaveonserversave = false;
        public static bool shouldallowwhitelist = false;
        public static bool shouldcapframes = false;
        public static bool shouldrebindknownhackkey = false;
        public static bool shouldlogall = false;
        static int capedamount = 1;

        void LoadDefaultConfig() { }

        private void CheckCfg<T>(string Key, ref T var)
        {
  
                if (Config[Key] is T)
                    var = (T)Config[Key];
                else
                    Config[Key] = var;
  
        }

        void Broadcast(string message)
        {
           
                ConsoleNetworker.Broadcast("chat.add " + SystemName + " " + Facepunch.Utility.String.QuoteSafe(message));
            
        }

        void dounbanip(NetUser netuser, string targetid, string targetname)
        {
           
                var playerdata = GetPlayerdata("Blacklist(ip)");
                if (playerdata.ContainsKey(targetid))
                {
                    playerdata.Remove(targetid);
                    rust.SendChatMessage(netuser, SystemName, targetname);
                    return;
                }
                rust.SendChatMessage(netuser, SystemName, "este jogador nao esta presente na banlist" + " " + targetname);
           
        }

        Dictionary<string, object> GetPlayerWl(string userid)
        {

                if (Wl[userid] == null)
                    Wl[userid] = new Dictionary<string, object>();
                return Wl[userid] as Dictionary<string, object>;

        }

        Dictionary<string, object> GetPlayerdata(string userid)
        {

                if (Data[userid] == null)
                    Data[userid] = new Dictionary<string, object>();
                return Data[userid] as Dictionary<string, object>;

        }

        Dictionary<string, object> GetPlayerinfo(string userid)
        {
 
                if (Info[userid] == null)
                    Info[userid] = new Dictionary<string, object>();
                return Info[userid] as Dictionary<string, object>;
 
        }

        bool hasAccess(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "canbanimunity")) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "canban")) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "canunban")) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }

        [ChatCommand("ban")]
        private void BanComand(NetUser netuser, string command, string[] args)
        {
            
                if (!hasAccess(netuser, "canban")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe o nickname do jogador que deseja banir."); return; }

                NetUser targetuser = rust.FindPlayer(args[0]);

                if (args.Length >= 1)
                {
                    string motivo = "Nenhum motivo informado";
                    if (args.Length == 2)
                    {
                        motivo = args[1];
                    }


                    cmdBan(args[0], motivo, netuser.displayName, netuser.playerClient.userID.ToString());
                }
            
        }

        [ChatCommand("unban")]
        private void UnbanCommand(NetUser netuser, string command, string[] args)
        {
           
                if (!hasAccess(netuser, "canunban")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe o steamID do jogador que deseja desbanir."); return; }

                if (args[0].Length < 17)
                {
                    SendMessage(netuser, "[color yellow]Informe um steamID válido."); return;
                    return;
                }

                if (args[0].Length > 17)
                {
                    SendMessage(netuser, "[color yellow]Informe um steamID válido."); return;
                    return;
                }

                if (args.Length >= 1 && args[0].Length == 17)
                {
                    cmdUnban(netuser, args[0]);
                    return;
                }

                if (netuser != null)
                {
                    SendMessage(netuser, "[color yellow]Informe o steamID do jogador que deseja desbanir."); return;
                }
            
        }

        void OnPlayerConnected(NetUser netuser)
        {
           
                var playerdata = GetPlayerdata("Blacklist(ip)");
                var Whitelist = GetPlayerWl("Blacklist(ip.wl)");
                var targetid = netuser.networkPlayer.externalIP;
                var targetuserid = netuser.playerClient.userID.ToString();
                var targetname = netuser.displayName;
                if (shouldrebindknownhackkey)
                {
                    rust.RunClientCommand(netuser, "input.bind Chat Return q");
                    rust.RunClientCommand(netuser, "input.bind Inventory Tab LeftAlt");
                }
                if (shouldlogall)
                {
                    var playerlog = GetPlayerinfo(targetname);
                    if (playerlog.ContainsKey("id"))
                    {
                        playerlog.Remove("id");
                        playerlog.Remove("name");
                        playerlog.Remove("ip");
                    }
                    playerlog.Add("id", targetuserid);
                    playerlog.Add("name", targetname);
                    playerlog.Add("ip", targetid);
                }
                if (Whitelist.ContainsKey(targetuserid)) return;
                ulong playerid = Convert.ToUInt64(targetid);
                if (playerdata.ContainsKey(targetid))
                {
                    if (shouldcapframes)
                    {
                        rust.RunClientCommand(netuser, "render.frames " + capedamount);
                        rust.RunClientCommand(netuser, "config.save");
                    }

                    if (shouldlogall) return;
                    if (shouldallowwhitelist)
                    {
                        var playerlog = GetPlayerinfo(targetname);
                        if (playerlog.ContainsKey("id"))
                        {
                            playerlog.Remove("id");
                            playerlog.Remove("name");
                            playerlog.Remove("ip");
                        }
                        playerlog.Add("id", targetuserid);
                        playerlog.Add("name", targetname);
                        playerlog.Add("ip", targetid);
                    }
                }
           
        }

        private void cmdBan(string targetId, string motivo, string agenteName, string idAgente)
        {
           
                var BlackListIP = GetPlayerdata("Blacklist(ip)");
                string targetNome = "";
                string cachedReason = "";
                string targetIp = "";
                NetUser targetuser = rust.FindPlayer(targetId);
                NetUser netuser = rust.FindPlayer(idAgente);

                if (targetuser == netuser)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não pode banir a si mesmo."); return;
                }

            if (targetuser == null && targetId.Length == 17)
            {

                targetNome = PlayerDatabase?.Call("GetPlayerData", targetId, "name").ToString();
                targetIp = PlayerDatabase?.Call("GetPlayerData", targetId, "ip").ToString();
                cachedReason = motivo + " ( autor do banimento - " + agenteName + " ) IP: " + targetIp;
                if (BanList.Contains(Convert.ToUInt64(targetId)) && BlackListIP.ContainsKey(targetIp))
                {
                    SendMessage(netuser, "[color white]Este jogador ja foi banido.");
                    return;
                }
                EnviarDiscord2(targetId, motivo, agenteName);
                Broadcast(targetNome + " [color orange] foi banido do servidor ( [color white]" + agenteName + "[color orange] )");
            }


                else if (targetuser != null)
                {
                    targetNome = targetuser.displayName;
                    targetIp = targetuser.networkPlayer.externalIP;
                    targetId = targetuser.playerClient.userID.ToString();
                    cachedReason = motivo + " ( pelo - " + agenteName + " ) IP:" + targetIp;
                }
                else
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador."); return;
                }

                if (targetNome != null)
                {
                    ulong playerid = Convert.ToUInt64(targetId);

                    var playerdata = GetPlayerdata("Blacklist(ip)");


                    if (BanList.Contains(Convert.ToUInt64(targetId)) && BlackListIP.ContainsKey(targetIp))
                    {
                        SendMessage(netuser, "[color white]Este jogador ja foi banido.");
                        return;
                    }

                    if (targetId != null && BanList.Contains(Convert.ToUInt64(targetId)))
                    {
                        playerdata.Add(targetIp, targetNome + " " + "(id:" + targetId + " )" + "(by: " + agenteName + ")" + " (staff: " + idAgente + " )" + "Reason: " + motivo);
                        Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)");
                        return;
                    }

                    if (targetIp != null && BlackListIP.ContainsKey(targetIp))
                    {
                        BanList.Add(playerid, targetNome, cachedReason);
                        BanList.Save();
                        return;
                    }

                    BanList.Add(playerid, targetNome, cachedReason);
                    BanList.Save();

                    playerdata.Add(targetIp, targetNome + " " + "(id:" + targetId + " )" + "(by: " + agenteName + ")" + " (staff: " + idAgente + " )" + "Reason: " + motivo);
                    Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)");


                    rust.RunClientCommand(targetuser, "config.save");
                    rust.RunClientCommand(targetuser, "input.bind Up F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Down F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Left F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Right F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Fire F4 None");
                    rust.RunClientCommand(targetuser, "input.bind AltFire F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Sprint F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Duck F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Jump F4 None");
                    rust.RunClientCommand(targetuser, "input.bind Inventory 7 None");
                    rust.RunClientCommand(targetuser, "config.save");

                    EnviarDiscord(targetNome, motivo, agenteName, targetId);
                    targetuser.Kick(NetError.ConnectionBanned, true);
                    Broadcast(targetNome + " [color orange] foi banido do servidor ( [color white]" + agenteName + "[color orange] )");
                }
           
        }

         private void cmdUnban(NetUser netuser, string targetId)
        {
           
                var playerdata = GetPlayerdata("Blacklist(ip)");
                var targetNome_P = PlayerDatabase?.Call("GetPlayerData", targetId, "name");
                var targetIp_P = PlayerDatabase?.Call("GetPlayerData", targetId, "ip");
                string targetNome = "";
                string targetIp = "";

                if (targetNome_P != null)
                {
                    targetNome = targetNome_P.ToString();
                }
                else
                {
                    SendMessage(netuser, "[color yellow]Este steamID não está registrado em nosso servidor."); return;
                }

                if (targetIp_P != null)
                {
                    targetIp = targetIp_P.ToString();
                }
                else
                {
                    SendMessage(netuser, "[color yellow]Este steamID não está registrado em nosso servidor."); return;
                }

                if (targetId != null && BanList.Contains(Convert.ToUInt64(targetId)))
                {
                    BanList.Remove(Convert.ToUInt64(targetId));
                    BanList.Save();

                    if (netuser != null)
                    {
                        SendMessage(netuser, "[color yellow]ID[color white] " + targetId + "  [color yellow]foi desbanido com sucesso.");
                    }
                }
                else
                {
                    if (netuser != null)
                    {
                        SendMessage(netuser, "[color yellow]Não foi possivel encontrar este ID na BanList.");
                    }
                    else
                    {

                    }
                }
                if (targetIp != null && playerdata.ContainsKey(targetIp))
                {
                    playerdata.Remove(targetIp);
                    Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)");
                    if (netuser != null)
                    {
                        SendMessage(netuser, "[color yellow]IP Desbanido com sucesso.");
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (netuser != null)
                    {
                        SendMessage(netuser, "[color yellow]Não foi possivel encontrar este IP na BanList.");
                    }
                }
           
        }

        void EnviarDiscord2(string targetId, string motivo, string agenteName)
        {
           
                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetId, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetId, "ip").ToString();
                string payloadJson = JsonConvert.SerializeObject(new DisoverPls()
                {
                    MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {1} \nID: {3} \nMotivo: {2} \nAutor: {4} \n\nAtenciosamente equipe NovaLand```", targetNome, targetIp, motivo, targetId, agenteName)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CordSupport, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
           
        }

        void EnviarDiscord(string targetId, string motivo, string agenteName, string idAgente)
        {
           
                NetUser targetuser = rust.FindPlayer(targetId);
                string targetNome = "";
                string cachedReason = "";
                string targetIp = "";
                targetNome = targetuser.displayName;
                targetIp = targetuser.networkPlayer.externalIP;
                targetId = targetuser.playerClient.userID.ToString();
                string payloadJson = JsonConvert.SerializeObject(new DisoverPls()
                {
                    MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {4} \nID: {3} \nMotivo: {2} \nAutor: {1} \n\nAtenciosamente equipe NovaLand```", targetNome, agenteName, motivo, targetId, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CordSupport, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
           
        }
        public void NotStuctBack(int code, string responde) { }
        class DisoverPls
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CordSupport = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        void SendMessage(NetUser netUser, string message)
        {
            
                ConsoleNetworker.SendClientCommand(netUser.networkPlayer, $"chat.add {QuoteSafe(SystemName)} {QuoteSafe(message)}");
           
        }
    }
}