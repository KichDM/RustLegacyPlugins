using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using DataStore = Oxide.Core.Interface;
using Oxide.Core.Configuration;
using System.Text;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using UnityEngine;



using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{
    [Info("Connecting", "PionixZ", "0.1.0")]
    class Connecting : RustLegacyPlugin
    {

        // VARIAVEIS QUE PRECISAM SER ALTERADAS;
        public static string iphubkey = "X-Key: MTE3MDc6alhueUNoYmxzbzQwa1pONUFMN09TYktMdm9kVUlPc2I="; //PEGA A KEY NO SITE IPHUBKEY
        string SystemName = "Server";

        // NÃO MECHER;
        private string QuoteSafe(string str) => "\"" + str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' }) + "\"";

        [PluginReference]
        private Plugin PlayerDatabase;

        StoredData storedData;
        StoredData2 storedData2;
        StoredData3 storedData3;
        StoredData4 storedData4;
 
        

        class StoredData
        {
            public Dictionary<string, int> IpVerificado = new Dictionary<string, int>();
        }

        class StoredData2
        {
            public List<string> VpnDetectada = new List<string>();
        }

        class StoredData3
        {
            public List<ulong> PlayerKickadoVPN = new List<ulong>();
        }

        class StoredData4
        {
            public List<ulong> PlayerKickadoProtection = new List<ulong>();
        }

        

        private string DataFileName = "Connecting";
       

        private Core.Configuration.DynamicConfigFile Data;
        private Core.Configuration.DynamicConfigFile Data4;
        private Core.Configuration.DynamicConfigFile Info;
        void LoadData() {
            
                Data = Interface.GetMod().DataFileSystem.GetDatafile("PlayerKickado");
                Data4 = Interface.GetMod().DataFileSystem.GetDatafile("PlayerKickado");
                Data = Interface.GetMod().DataFileSystem.GetDatafile("Blacklist(ip)");
           
        }
        void SaveData() {
           
                Interface.GetMod().DataFileSystem.SaveDatafile("PlayerKickado");
                Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)");
           
        }
        void Unload() {
            
                SaveData();
            
        }

        List<object> countryList;


        private void CheckCfg<T>(string Key, ref T var)
        {
            if (Config[Key] is T)
                var = (T)Config[Key];
            else
                Config[Key] = var;
        }

        void Init()
        {
            LoadDefaultConfig();
        }

        void Loaded()
        {
            try
            {
                storedData = Interface.GetMod().DataFileSystem.ReadObject<StoredData>("Verificado");
                storedData2 = Interface.GetMod().DataFileSystem.ReadObject<StoredData2>("VpnDetect");
                storedData3 = Interface.GetMod().DataFileSystem.ReadObject<StoredData3>("KickadoVPN");
                storedData4 = Interface.GetMod().DataFileSystem.ReadObject<StoredData4>("KickadoProtection");
                LoadData();
                StartedHandler();
            }
            catch (Exception)
            {

            }
        }

        protected override void LoadDefaultConfig()
        {
            Config["CountryList"] = countryList = GetConfig("CountryList", new List<object> { "BR", "PT" });
            SaveConfig();
        }

        public static bool antivpn = false;
        public static bool blacklist = false;
        public static bool serverprotection = false;
        public static bool ShouldDisreGardIfKickedForViolation = true;
        static string cargo = "Player";
        static string usarvpn = "Não";
        static string KitFerro = "Não";
        static string KitPedra = "Não";
        static string KitMadeira = "Não";
        static string KitSMod = "Não";
        static string KitMod = "Não";
        static string KitYT = "Não";
        static string KitMito = "Não";
        static string KitDV = "Não";

        void LoadDefaultMessages()
        {
            try
            {
                var message = new Dictionary<string, string>
                {//
                };
                lang.RegisterMessages(message, this);
            }
            catch (Exception)
            {

            }
        }

        Dictionary<string, object> GetPlayerdata(string userid)
        {

                if (Data[userid] == null)
                    Data[userid] = new Dictionary<string, object>();
                return Data[userid] as Dictionary<string, object>;
 
        }

        Dictionary<string, object> GetPlayerdata4(string userid)
        {

            if (Data4[userid] == null)
                Data4[userid] = new Dictionary<string, object>();
            return Data4[userid] as Dictionary<string, object>;

        }

        Dictionary<ulong, object> GetPlayerdata3(string userid)
        {

            if (Info[userid] == null)
                Info[userid] = new Dictionary<ulong, object>();
            return Info[userid] as Dictionary<ulong, object>;

        }

        private DynamicConfigFile _Data;

        static int minNick = 3;

        // Caracter Filter
        static bool CaracterBlock = true;

        // Name Filter
        static bool NameBlock = true;

        // Small Nick
        static bool KickSmallNick = true;

        // Sem Nick
        static bool SemNickBlock = true;

        const string permissionDono = "dono_chat";
        const string permissionSubDono = "subdono_chat";
        const string permissionAdmin = "admin_chat";
        const string permissionsMod = "smod_chat";
        const string permissionMod = "mod_chat";
        const string permissionYoutuber = "yt_chat";
        const string permissionFerro = "ferro_chat";
        const string permissionPedra = "pedra_chat";
        const string permissionMadeira = "madeira_chat";
        const string permissionDivulgador = "dv_chat";
        const string permissionKitFerro = "ferro_kit";
        const string permissionKitMadeira = "madeira_kit";
        const string permissionKitPedra = "pedra_kit";
        const string permissionKitMito = "mito_kit";
        const string permissionKitSmod = "smod_kit";
        const string permissionKitMod = "mod_kit";
        const string permissionKitDv = "dv_kit";
        const string permissionKitYt = "yt_kit";
        const string permissionUsarVPN = "canvpn";
        public static bool mostrarquandoadmentrar = true;

        public static List<object> nomes = new List<object>() { "oxide", "server", "console", "✯NovaLand✯rust", "dono", "admin", "nitroux1", "lumaemu" };
        public static List<object> caracteres = new List<object>() {"´", "'", "`", "~", ",", "<", ">", ";", ":", "/", "{", "}", "color","+", "=", "@", "$", "!", "#", "%", "^", "&", "*", "(", ")", "?", "-", "/" };

        public static List<object> semnick = new List<object>() { "\\", "\\n" };

        string GetMessage(string key, string Id = null) => lang.GetMessage(key, this, Id);

        void OnServerInitialized()
        {
            try
            {
                permission.RegisterPermission(permissionDono, this);
                permission.RegisterPermission(permissionSubDono, this);
                permission.RegisterPermission(permissionAdmin, this);
                permission.RegisterPermission(permissionsMod, this);
                permission.RegisterPermission(permissionMod, this);
                permission.RegisterPermission(permissionYoutuber, this);
                permission.RegisterPermission(permissionUsarVPN, this);
            }
            catch (Exception)
            {

            }
        }

        private void StartedHandler()
        {
            try
            {
                _Data = DataStore.GetMod().DataFileSystem.GetDatafile(DataFileName);
            }
            catch (Exception)
            {

            }
        }
        void SaveAllData()
        {
            try
            {
                DataStore.GetMod().DataFileSystem.SaveDatafile(DataFileName);
            }
            catch (Exception)
            {

            }
        }
        void OnServerSave() => SaveAllData();

        bool Dono(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionDono)) return true;
            return false;
        }

        bool SubDono(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionSubDono)) return true;
            return false;
        }

        bool Admin(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionAdmin)) return true;
            return false;
        }

        bool sMod(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionsMod)) return true;
            return false;
        }

        bool Mod(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionMod)) return true;
            return false;
        }

        bool YouTuber(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionYoutuber)) return true;
            return false;
        }

        bool Ferro(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionFerro)) return true;
            return false;
        }

        bool Pedra(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionPedra)) return true;
            return false;
        }

        bool Madeira(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionMadeira)) return true;
            return false;
        }

        bool Divulgador(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionDivulgador)) return true;
            return false;
        }

        bool KitVipFerro(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitFerro)) return true;
            return false;
        }

        bool KitVipPedra(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitPedra)) return true;
            return false;
        }

        bool KitVipMadeira(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitMadeira)) return true;
            return false;
        }

        bool KitSmoderador(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitSmod)) return true;
            return false;
        }

        bool KitModerador(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitMod)) return true;
            return false;
        }

        bool KitYouTuber(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitYt)) return true;
            return false;
        }

        bool KitDoMito(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitMito)) return true;
            return false;
        }

        bool KitDivulgador(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionKitDv)) return true;
            return false;
        }

        bool UsarVPN(NetUser netuser)
        {
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionUsarVPN)) return true;
            return false;
        }


        T GetConfig<T>(string name, T value) => Config[name] == null ? value : (T)Convert.ChangeType(Config[name], typeof(T));

        static bool IsLocalIp(string ipAddress)
        {
            var split = ipAddress.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            var ip = new[] { int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]) };
            return ip[0] == 10 || ip[0] == 127 || (ip[0] == 192 && ip[1] == 168) || (ip[0] == 172 && (ip[1] >= 16 && ip[1] <= 31));
        }

        private void OnPlayerDisconnected(uLink.NetworkPlayer player)
        {
            
                var playerdata = GetPlayerdata("Blacklist(ip)");
                var playerdata3 = GetPlayerdata4("PlayerKickado");
                var netuser = player.GetLocalData<NetUser>();
                var ID = netuser.userID.ToString();
                string targetNome = PlayerDatabase?.Call("GetPlayerData", ID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", ID, "ip").ToString();
                string targetIDD = PlayerDatabase?.Call("GetPlayerData", ID, "steamid").ToString();
                var targetid = netuser.networkPlayer.externalIP;
                PlayerClient player2 = ((NetUser)player.GetLocalData()).playerClient;

                ulong playerid = Convert.ToUInt64(ID);

                EnviarDiscord5(netuser, ID);
                timer.Once(0.1f, () =>
                {
                   
               
                        rust.BroadcastChat(SystemName, string.Format("[color white]{0}[color #363636]【 [color red]✖[color #363636] 】[color white]", netuser.displayName));
                   
                });
            
         
        }

        

        private void OnPlayerConnected(NetUser netuser)
        {
            
                var playerdata = GetPlayerdata("Blacklist(ip)");
                var targetid = netuser.networkPlayer.externalIP;
                var Name = netuser.displayName.ToString();
                Detector detector;
                string ip = netuser.networkPlayer.ipAddress;
                var SteamID = netuser.userID.ToString();
                var ID = netuser.userID.ToString();
                bool AlreadyMessageShowing = false;

                ulong playerid = Convert.ToUInt64(SteamID);

                if (playerdata.ContainsKey(targetid))
                {
                    CBANIP(netuser);
                    timer.Once(5f, () =>
                    {
                        rust.RunClientCommand(netuser, $"deathscreen.reason \"[color red]Você foi banido do servidor\"");
                        rust.RunClientCommand(netuser, "deathscreen.show");
                        rust.BroadcastChat(SystemName, Name + "  [color red]foi banido do servidor﹣  [color red]( [color white]IP-BanList [color red])");
                        BanList.Add(playerid, Name, "IP na BanList");
                        BanList.Save();
                        blacklist = true;
                        BANIP(netuser);
                        netuser.Kick(NetError.ConnectionBanned, true);
                        blacklist = false;
                    });
                    return;
                }


                if (Dono(netuser))
                {
                    timer.Once(0.1f, () =>
                    {
                        try
                        {
                            rust.BroadcastChat(SystemName, string.Format("[color white]{0}[color #363636]【 [color yellow]✯[color #363636] 】[color white]", netuser.displayName));
                            EnviarDiscord4(netuser);
                        }
                        catch (Exception)
                        {
                        }
                    });

                    if (_Data[SteamID] == null)
                    {
                        _Data[SteamID] = false;
                        SaveAllData();
                        return;
                    }

                    AlreadyMessageShowing = (bool)(_Data[SteamID]);
                    if (!AlreadyMessageShowing)
                    {
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seja bem vindo ao [color cyan]✯NovaLand✯Rust"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Acesse nosso discord - [color cyan]discord.gg/zjTBChqhYj"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seu fps foi automaticamente melhorado - [color cyan](caso queira reverter utilize /fps)"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Leia as regras para não ser punido - [color cyan]/regras"));
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    }
                    return;
                }

                if (SubDono(netuser))
                {
                    timer.Once(0.1f, () =>
                    {
                        try
                        {
                            rust.BroadcastChat(SystemName, string.Format("[color white]{0}[color #363636]【 [color #4169E1]✔[color #363636] 】[color white]", netuser.displayName));
                            EnviarDiscord4(netuser);
                        }
                        catch (Exception)
                        {

                        }
                    });

                    if (_Data[SteamID] == null)
                    {
                        _Data[SteamID] = false;
                        SaveAllData();
                        return;
                    }

                    AlreadyMessageShowing = (bool)(_Data[SteamID]);
                    if (!AlreadyMessageShowing)
                    {
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seja bem vindo ao [color cyan]✯NovaLand✯Rust"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Acesse nosso discord - [color cyan]discord.gg/zjTBChqhYj"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seu fps foi automaticamente melhorado - [color cyan](caso queira reverter utilize /fps)"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Leia as regras para não ser punido - [color cyan]/regras"));
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    }
                    return;
                }

                if (Admin(netuser))
                {
                    timer.Once(0.1f, () =>
                    {
                        try
                        {
                            rust.BroadcastChat(SystemName, string.Format("[color white]{0}[color #363636]【 [color #4169E1]✔[color #363636] 】[color white]", netuser.displayName));
                            EnviarDiscord4(netuser);
                        }
                        catch (Exception)
                        {

                        }
                    });

                    if (_Data[SteamID] == null)
                    {
                        _Data[SteamID] = false;
                        SaveAllData();
                        return;
                    }

                    AlreadyMessageShowing = (bool)(_Data[SteamID]);
                    if (!AlreadyMessageShowing)
                    {
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seja bem vindo ao [color cyan]✯NovaLand✯Rust"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Acesse nosso discord - [color cyan]discord.gg/zjTBChqhYj"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seu fps foi automaticamente melhorado - [color cyan](caso queira reverter utilize /fps)"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Leia as regras para não ser punido - [color cyan]/regras"));
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    }
                    return;
                }

                if (UsarVPN(netuser))
                {
                    timer.Once(0.1f, () =>
                    {
                        try
                        {
                            rust.BroadcastChat(SystemName, string.Format("[color white]{0}[color #363636]【 [color #4169E1]✔[color #363636] 】[color white]", netuser.displayName));
                            EnviarDiscord(netuser);
                        }
                        catch (Exception)
                        {

                        }
                    });

                    if (_Data[SteamID] == null)
                    {
                        _Data[SteamID] = false;
                        SaveAllData();
                        return;
                    }

                    AlreadyMessageShowing = (bool)(_Data[SteamID]);
                    if (!AlreadyMessageShowing)
                    {
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seja bem vindo ao [color cyan]✯NovaLand✯Rust"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Acesse nosso discord - [color cyan]discord.gg/zjTBChqhYj"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seu fps foi automaticamente melhorado - [color cyan](caso queira reverter utilize /fps)"));
                        rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Leia as regras para não ser punido - [color cyan]/regras"));
                        rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    }
                    return;
                }

                if (storedData2.VpnDetectada.Contains(ip))
                {
                    timer.Once(5f, () =>
                    {
                        try
                        {
                            storedData3.PlayerKickadoVPN.Add(playerid);
                            rust.BroadcastChat(SystemName, netuser.displayName + "  [color red]foi kickado do servidor﹣  [color red]( [color white]Uso de VPN [color red])");
                            EnviarDiscord2(netuser);
                            netuser.Kick(NetError.Facepunch_Kick_RCON, true);
                            storedData3.PlayerKickadoVPN.Remove(playerid);
                        }
                        catch (Exception)
                        {

                        }
                    });
                    return;
                }

                timer.Once(0.1f, () =>
                {
                    try
                    {
                        rust.BroadcastChat(SystemName, string.Format("[color white]{0}[color #363636]【 [color #4169E1]✔[color #363636] 】[color white]", netuser.displayName));
                        EnviarDiscord(netuser);
                    }
                    catch (Exception)
                    {

                    }
                });


                if (_Data[SteamID] == null)
                {
                    _Data[SteamID] = false;
                    SaveAllData();
                    return;
                }

                AlreadyMessageShowing = (bool)(_Data[SteamID]);
                if (!AlreadyMessageShowing)
                {
                    rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seja bem vindo ao [color cyan]✯NovaLand✯Rust"));
                    rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Acesse nosso discord - [color cyan]discord.gg/zjTBChqhYj"));
                    rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Seu fps foi automaticamente melhorado - [color cyan](caso queira reverter utilize /fps)"));
                    rust.SendChatMessage(netuser, SystemName, ("[color red]➤  [color white]Leia as regras para não ser punido - [color cyan]/regras"));
                    rust.SendChatMessage(netuser, SystemName, ("[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                }
 
        }

        void EnviarDiscord(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new DisoverPls()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {3} \nIP: {2}  \nID: {1} \nVPN: {4} \n\nKits - Jogador \n\nFerro: {5}        Pedra: {6} \nMadeira: {7}      SMOD: {8} \nMOD: {9}          YT: {10} \nMito: {11}         DV: {12} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, sender.networkPlayer.externalIP, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CordSupport, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            { 
                
            }
        }
        public void NotStuctBack(int code, string responde) { }
        class DisoverPls
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CordSupport = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void EnviarDiscord2(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new DisoverPls2()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {3} \nIP: {2}  \nID: {1} \nVPN: Detectado \n\nKits - Jogador \n\nFerro: {5}        Pedra: {6} \nMadeira: {7}      SMOD: {8} \nMOD: {9}          YT: {10} \nMito: {11}         DV: {12} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, sender.networkPlayer.externalIP, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CordSupport2, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        public void NotStuctBack2(int code, string responde) { }
        class DisoverPls2
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CordSupport2 = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void EnviarDiscord4(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;


                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new DisoverPls4()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {3} \nIP: -  \nID: {1} \nVPN: {4} \n\nKits - Jogador \n\nFerro: {5}        Pedra: {6} \nMadeira: {7}      SMOD: {8} \nMOD: {9}          YT: {10} \nMito: {11}         DV: {12} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, sender.networkPlayer.externalIP, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CordSupport4, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        public void NotStuctBack4(int code, string responde) { }
        class DisoverPls4
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CordSupport4 = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void EnviarDiscord5(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;


                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new DisoverPls5()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Disconnect-Server  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CordSupport5, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        public void NotStuctBack5(int code, string responde) { }
        class DisoverPls5
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CordSupport5 = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";

        void BANIP(NetUser netuser)
        {
            try
            {
                string targetNome = "";
                string cachedReason = "";
                string targetIp = "";
                targetNome = netuser.displayName;
                string targetId = netuser.playerClient.userID.ToString();
                string ip = netuser.networkPlayer.ipAddress;
                string payloadJson = JsonConvert.SerializeObject(new Banipl()
                {
                    MessageText = string.Format("```\nBANIDO - ✯NovaLand✯Rust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: IP-BanList \nAutor: AntiCheat \n\nAtenciosamente equipe ✯NovaLand✯```", targetNome, targetId, ip)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(banipd, payloadJson, (code, response) => banipp(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        public void banipp(int code, string responde) { }
        class Banipl
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string banipd = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";


        void Violation(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new ViolationS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Violation  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(ViolationChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class ViolationS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string ViolationChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";


        void BlackListDiscord(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new BlackListS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: IP-BanList  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(BlackListChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class BlackListS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string BlackListChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";

        void VPNDISCORD(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new VPNS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nVPN: Detectado  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(VPNChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class VPNS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string VPNChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";


        void ServerProtectionDiscord(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new ServerProtectionChannelS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: ServerProtection  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(ServerProtectionChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class ServerProtectionChannelS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string ServerProtectionChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";

        void CServerProtectionDiscord(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new CCCServerProtectionChannelS()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: ServerProtection  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, sender.networkPlayer.externalIP)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CCServerProtectionChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CCCServerProtectionChannelS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CCServerProtectionChannel = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void CSEMNICK(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new CCCSEMNICK()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Sem Nick  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, sender.networkPlayer.externalIP)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CCSEMNICK, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CCCSEMNICK
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CCSEMNICK = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void CCHARACTER(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new CCCCHARACTER()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Character Block  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, sender.networkPlayer.externalIP)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CCCHARACTER, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CCCCHARACTER
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CCCHARACTER = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void CNICKBLOCK(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new CCCNICKBLOCK()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Nick Block  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, sender.networkPlayer.externalIP)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CCNICKBLOCK, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CCCNICKBLOCK
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CCNICKBLOCK = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void CSMALLNICK(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new CCCSMALLNICK()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Nick Pequeno  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, sender.networkPlayer.externalIP)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CCSMALLNICK, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CCCSMALLNICK
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CCSMALLNICK = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";

        void CBANIP(NetUser sender)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string payloadJson = JsonConvert.SerializeObject(new CCCBANIP()
                {
                    MessageText = string.Format("```\nCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: IP-BanList  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, sender.networkPlayer.externalIP)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CCBANIP, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CCCBANIP
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CCBANIP = "https://discord.com/api/webhooks/901125301864661043/fgG7HlqQcc4avQxk0odQnt3Y2NISIUr69GxkvNEnaeaHQNZ28uSZVJdmXNH1YmmFyVK_";


        void SemNickDiscord(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new SemNickChannelS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Sem Nick  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(SemNickChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class SemNickChannelS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string SemNickChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";

        void CharacterBlockDiscord(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new CaracterBlockChannelS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Character Block  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(CaracterBlockChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class CaracterBlockChannelS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CaracterBlockChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";

        void NickBlockDiscord(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new NickBlockDiscordChannelS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Nick Block  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(NickBlockDiscordChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class NickBlockDiscordChannelS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string NickBlockDiscordChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";

        void SmallNickDiscord(NetUser sender, string targetID)
        {
            try
            {
                string Cargoss = cargo;
                if (Dono(sender))
                    Cargoss = "Dono";
                else if (SubDono(sender))
                    Cargoss = "SubDono";
                else if (Admin(sender))
                    Cargoss = "Admin";
                else if (sMod(sender))
                    Cargoss = "sMod";
                else if (Mod(sender))
                    Cargoss = "Mod";
                else if (Ferro(sender))
                    Cargoss = "VIP";
                else if (Pedra(sender))
                    Cargoss = "VIP";
                else if (Madeira(sender))
                    Cargoss = "VIP";
                else if (YouTuber(sender))
                    Cargoss = "YouTuber";
                else if (Divulgador(sender))
                    Cargoss = "Divulgador";
                else
                    Cargoss = cargo;

                string KitFerroo = KitFerro;
                if (sender.CanAdmin())
                    KitFerroo = "Sim";
                else if (KitVipFerro(sender))
                    KitFerroo = "Sim";
                else
                    KitFerroo = KitFerro;

                string KitPedraa = KitPedra;
                if (sender.CanAdmin())
                    KitPedraa = "Sim";
                else if (KitVipPedra(sender))
                    KitPedraa = "Sim";
                else
                    KitPedraa = KitPedra;

                string KitMadeiraa = KitMadeira;
                if (sender.CanAdmin())
                    KitMadeiraa = "Sim";
                else if (KitVipMadeira(sender))
                    KitMadeiraa = "Sim";
                else
                    KitMadeiraa = KitMadeira;

                string KitSModa = KitSMod;
                if (sender.CanAdmin())
                    KitSModa = "Sim";
                else if (KitSmoderador(sender))
                    KitSModa = "Sim";
                else
                    KitSModa = KitSMod;

                string KitModa = KitMod;
                if (sender.CanAdmin())
                    KitModa = "Sim";
                else if (KitModerador(sender))
                    KitModa = "Sim";
                else
                    KitModa = KitMod;

                string KitYTY = KitYT;
                if (sender.CanAdmin())
                    KitYTY = "Sim";
                else if (KitYouTuber(sender))
                    KitYTY = "Sim";
                else
                    KitYTY = KitYT;

                string KitMitoo = KitMito;
                if (sender.CanAdmin())
                    KitMitoo = "Sim";
                else if (KitDoMito(sender))
                    KitMitoo = "Sim";
                else
                    KitMitoo = KitMito;

                string KitDVV = KitDV;
                if (sender.CanAdmin())
                    KitDVV = "Sim";
                else if (KitDivulgador(sender))
                    KitDVV = "Sim";
                else
                    KitDVV = KitDV;

                string UsarVPNN = usarvpn;
                if (Dono(sender))
                    UsarVPNN = "Liberado";
                else if (SubDono(sender))
                    UsarVPNN = "Liberado";
                else if (Admin(sender))
                    UsarVPNN = "Liberado";
                else if (UsarVPN(sender))
                    UsarVPNN = "Liberado";
                else
                    UsarVPNN = usarvpn;

                string targetNome = PlayerDatabase?.Call("GetPlayerData", targetID, "name").ToString();
                string targetIp = PlayerDatabase?.Call("GetPlayerData", targetID, "ip").ToString();

                string payloadJson = JsonConvert.SerializeObject(new SmallNickChannelS()
                {
                    MessageText = string.Format("```\nDISCONNECT - ✯NovaLand✯Rust \n\nNick: {0} \nCargo: {2} \nIP: {12}  \nID: {1} \nMotivo: Small Nick  \n\nKits - Jogador \n\nFerro: {4}        Pedra: {5} \nMadeira: {6}      SMOD: {7} \nMOD: {8}          YT: {9} \nMito: {10}         DV: {11} \n\nAtenciosamente equipe ✯NovaLand✯```", sender.displayName, sender.userID, Cargoss, UsarVPNN, KitFerroo, KitPedraa, KitMadeiraa, KitSModa, KitModa, KitYTY, KitMitoo, KitDVV, targetIp)
                }); ;
                Dictionary<string, string> plicksl = new Dictionary<string, string>();
                plicksl.Add("Content-Type", "application/json");
                webrequest.EnqueuePost(SmallNickChannel, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
            }
            catch (Exception)
            {

            }
        }
        class SmallNickChannelS
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string SmallNickChannel = "https://discord.com/api/webhooks/901125372819673149/Z74g0gvPF169JGv5ZuPqB-JP1E4IGgUGomkuQKnMymu1fxliiqXVYYfqIOCFeTEs0c9h";



        string Lang(string key, string id = null, params object[] args) => string.Format(lang.GetMessage(key, this, id), args);
    }

// CLASSE QUE PEGA AS INFORMAÇÕES;
public class Detector
    {
        public int block
        {
            get;
            set;
        }
    }
}

