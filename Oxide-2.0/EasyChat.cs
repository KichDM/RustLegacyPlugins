using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using System.Linq;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using Oxide.Core.Libraries; 

namespace Oxide.Plugins  
{
    [Info("CHAT", "PionixZ & PINK", "0.1.0")]
    class EasyChat : RustLegacyPlugin
    {
        private bool debug = false;


        static string SystemName = "Server";
        private bool Changed;
        private string oprefix;
        private string omsgcolor;
        private string ogpermission;

        private Core.Configuration.DynamicConfigFile Data;

        List<string> AntiFloodList = new List<string>();
        static Dictionary<NetUser, int> AntiFlood = new Dictionary<NetUser, int>();

        public static List<object> cores = new List<object>() { "color", "COLOR", "Color", "cOlor", "coLor", "colOr", "coloR", "COlor", "cOLor", "coLOr", "colOR", "CoLor", "cOlOr", "coLoR", "ColoR", "COLor", "cOLOr", "coLOR", "CoLoR", "COLOr", "cOLOR" };
        public static List<object> nomes = new List<object>() { "\\", ".connect", "28015", "macaco", "vai tomar no cu", "fdp", "arrombado", "filho da puta", "puta", "vtnc", "lixo", "idiota", "otario", "vsf", "vai se fuder", "maldito", "porra"};

        bool hasAccess(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }

        //CONFIG

        protected override void LoadDefaultConfig()
        {
            
                Config.Clear();
                LoadVariables();
            
        }

        private void CheckCfg<T>(string Key, ref T var)
        {

                if (Config[Key] is T)
                    var = (T)Config[Key];
                else
                    Config[Key] = var;
            
        }

        object GetConfig(string menu, string datavalue, object defaultValue)
        {

                var data = Config[menu] as Dictionary<string, object>;
                if (data == null)
                {
                    data = new Dictionary<string, object>();
                    Config[menu] = data;
                    Changed = true;
                }
                object value;
                if (!data.TryGetValue(datavalue, out value))
                {
                    value = defaultValue;
                    data[datavalue] = value;
                    Changed = true;
                }
                return value;
           
        }

        //PERMISSÕES

        void Loaded()
        {
            
                if (!permission.PermissionExists("canmute")) permission.RegisterPermission("canmute", this);
                if (!permission.PermissionExists("canafk")) permission.RegisterPermission("canafk", this);
                if (!permission.PermissionExists("canchat")) permission.RegisterPermission("canchat", this);
                if (!permission.PermissionExists("canstaff")) permission.RegisterPermission("canstaff", this);
                if (!permission.PermissionExists("canpopup")) permission.RegisterPermission("canpm", this);
                LogMessagesPM = Interface.Oxide.DataFileSystem.ReadObject<List<string>>("PMSystem_Log");

                foreach (var group in Config)
                {
                    string gname = group.Key.ToString();

                    if (!permission.PermissionExists(Config[gname, "Permission"].ToString())) permission.RegisterPermission(Config[gname, "Permission"].ToString(), this);
                    if (debug == true) { Puts("Registered " + Config[gname, "Permission"].ToString()); }
                }

                LoadData();
                LoadVariables();
           
        }

        //TAGS

        void LoadVariables()
        {
            try
            {
                //DONO
                oprefix = Convert.ToString(GetConfig("9999", "Prefix", "〔 DONO 〕  "));
                omsgcolor = Convert.ToString(GetConfig("9999", "MessageColor", "[color yellow]★  [color cyan]"));
                ogpermission = Convert.ToString(GetConfig("9999", "Permission", "dono_chat"));
                //SUB-DONO
                oprefix = Convert.ToString(GetConfig("999", "Prefix", "〔 SUB-DONO 〕  "));
                omsgcolor = Convert.ToString(GetConfig("999", "MessageColor", "[color yellow]★  [color cyan]"));
                ogpermission = Convert.ToString(GetConfig("999", "Permission", "subdono_chat"));
                //ADMIN
                oprefix = Convert.ToString(GetConfig("99", "Prefix", "〔 ADMIN 〕  "));
                omsgcolor = Convert.ToString(GetConfig("99", "MessageColor", "[color yellow]★  [color cyan]"));
                ogpermission = Convert.ToString(GetConfig("99", "Permission", "admin_chat"));
                //sMOD
                oprefix = Convert.ToString(GetConfig("9", "Prefix", "〔 SMOD 〕  "));
                omsgcolor = Convert.ToString(GetConfig("9", "MessageColor", "[color yellow]★  [color cyan]"));
                ogpermission = Convert.ToString(GetConfig("9", "Permission", "smod_chat"));
                //MOD
                oprefix = Convert.ToString(GetConfig("8", "Prefix", "〔 MOD 〕  "));
                omsgcolor = Convert.ToString(GetConfig("8", "MessageColor", "[color yellow]★  [color cyan]"));
                ogpermission = Convert.ToString(GetConfig("8", "Permission", "mod_chat"));
                //GST
                oprefix = Convert.ToString(GetConfig("777", "Prefix", "〔 G2 〕  "));
                omsgcolor = Convert.ToString(GetConfig("777", "MessageColor", "[color red]"));
                ogpermission = Convert.ToString(GetConfig("777", "Permission", "g2_chat"));
                //V
                oprefix = Convert.ToString(GetConfig("7777777", "Prefix", "〔 V 〕  "));
                omsgcolor = Convert.ToString(GetConfig("7777777", "MessageColor", "[color #ed6234]"));
                ogpermission = Convert.ToString(GetConfig("7777777", "Permission", "v_chat"));
                //X
                oprefix = Convert.ToString(GetConfig("777777777", "Prefix", "〔 X 〕  "));
                omsgcolor = Convert.ToString(GetConfig("777777777", "MessageColor", "[color #78bae7]"));
                ogpermission = Convert.ToString(GetConfig("777777777", "Permission", "X_chat"));
                //NXG
                oprefix = Convert.ToString(GetConfig("7777", "Prefix", "〔 XITER 〕  "));
                omsgcolor = Convert.ToString(GetConfig("7777", "MessageColor", "[color #DC143C]"));
                ogpermission = Convert.ToString(GetConfig("7777", "Permission", "xiter_chat"));
                //BOPE
                oprefix = Convert.ToString(GetConfig("77", "Prefix", "〔 Raid_157 〕  "));
                omsgcolor = Convert.ToString(GetConfig("77", "MessageColor", "[color #008000]"));
                ogpermission = Convert.ToString(GetConfig("77", "Permission", "raid_chat"));
                //MITO
                oprefix = Convert.ToString(GetConfig("7", "Prefix", "〔 MITO 〕  "));
                omsgcolor = Convert.ToString(GetConfig("7", "MessageColor", "[color red]"));
                ogpermission = Convert.ToString(GetConfig("7", "Permission", "mito_chat"));
                //GST
                oprefix = Convert.ToString(GetConfig("66", "Prefix", "〔 REI 〕  "));
                omsgcolor = Convert.ToString(GetConfig("66", "MessageColor", "[color #ff6f9c]"));
                ogpermission = Convert.ToString(GetConfig("66", "Permission", "rei_chat"));
                //FERRO
                oprefix = Convert.ToString(GetConfig("6", "Prefix", "〔 FERRO 〕  "));
                omsgcolor = Convert.ToString(GetConfig("6", "MessageColor", "[color #808080]"));
                ogpermission = Convert.ToString(GetConfig("6", "Permission", "ferro_chat"));
                //PEDRA
                oprefix = Convert.ToString(GetConfig("55", "Prefix", "〔 PK 〕  "));
                omsgcolor = Convert.ToString(GetConfig("55", "MessageColor", "[color #255064]"));
                ogpermission = Convert.ToString(GetConfig("55", "Permission", "pk_chat"));
                //PEDRA
                oprefix = Convert.ToString(GetConfig("5", "Prefix", "〔 PEDRA 〕  "));
                omsgcolor = Convert.ToString(GetConfig("5", "MessageColor", "[color #255064]"));
                ogpermission = Convert.ToString(GetConfig("5", "Permission", "pedra_chat"));
                //MADEIRA
                oprefix = Convert.ToString(GetConfig("4", "Prefix", "〔 MADEIRA 〕  "));
                omsgcolor = Convert.ToString(GetConfig("4", "MessageColor", "[color #b09d41]"));
                ogpermission = Convert.ToString(GetConfig("4", "Permission", "madeira_chat"));
                //YOUTUBER
                oprefix = Convert.ToString(GetConfig("3", "Prefix", "〔 YouTuber 〕  "));
                omsgcolor = Convert.ToString(GetConfig("3", "MessageColor", "[color #FA8072]"));
                ogpermission = Convert.ToString(GetConfig("3", "Permission", "yt_chat"));
                //DIVULGADOR
                oprefix = Convert.ToString(GetConfig("2", "Prefix", "〔 Divulgador 〕  "));
                omsgcolor = Convert.ToString(GetConfig("2", "MessageColor", "[color yellow]"));
                ogpermission = Convert.ToString(GetConfig("2", "Permission", "dv_chat"));
                //Chorao
                oprefix = Convert.ToString(GetConfig("111", "Prefix", "〔 Limpo 〕  "));
                omsgcolor = Convert.ToString(GetConfig("111", "MessageColor", ""));
                ogpermission = Convert.ToString(GetConfig("111", "Permission", "limpo_chat"));
                //Chorao
                oprefix = Convert.ToString(GetConfig("11", "Prefix", "〔 Chorao 〕  "));
                omsgcolor = Convert.ToString(GetConfig("11", "MessageColor", ""));
                ogpermission = Convert.ToString(GetConfig("11", "Permission", "chorao_chat"));
                //verificado
                oprefix = Convert.ToString(GetConfig("1", "Prefix", "〔 ✔ 〕  "));
                omsgcolor = Convert.ToString(GetConfig("1", "MessageColor", ""));
                ogpermission = Convert.ToString(GetConfig("1", "Permission", "verificado_chat"));

                if (Changed)
                {
                    SaveConfig();
                    Changed = false;
                }
            }
            catch (Exception)
            {

            }

        }

        //SISTEMA CHAT GLOBAL ON/OFF

        bool globalmute = false;

        [ChatCommand("chat")]
        void cmdChat(NetUser netuser, string command, string[] args)
        {
            
                if (!hasAccess(netuser, "canchat")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe uma das opções entre ON e OFF."); return; }

                switch (args[0].ToLower())
                {
                    case "off":

                        if (globalmute == true)
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]O chat global já foi desativado.");
                            return;
                        }

                        globalmute = true;
                        rust.BroadcastChat(SystemName, "[color green]O jogador[color white] " + netuser.displayName + " [color green]desativou chat global.");

                        break;
                    case "on":

                        if (globalmute == false)
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]O chat global já foi ativo.");
                            return;
                        }

                        globalmute = false;
                        rust.BroadcastChat(SystemName, "[color green]O jogador[color white] " + netuser.displayName + " [color green]ativou chat global.");

                        break;
                    default:
                        {
                            break;
                        }
                }
           
        }

        //SISTEMA DE MUTE E UNMUTE

        static Dictionary<string, int> mutado = new Dictionary<string, int>();

        [ChatCommand("mute")]
        void cmdmute(NetUser netuser, string command, string[] args)
        {
           
                if (!hasAccess(netuser, "canmute")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe um nickname de um jogador e um numero em minutos."); return; }

                NetUser targetuser = rust.FindPlayer(args[0]);

                if (targetuser == netuser)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não pode mutar a si mesmo.");
                    return;
                }

                if (args.Length == 1)
                {
                    if (targetuser == null) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador."); return; }

                    var SteamId = targetuser.playerClient.userID.ToString();

                    if (mutado.ContainsKey(SteamId)) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador já está mutado."); return; }

                    mutado.Add(SteamId, 1);

                    rust.BroadcastChat(SystemName, string.Format(targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  5 minutos  [color yellow])"));

                    timer.Once(300, () =>
                    {
                        if (mutado.ContainsKey(SteamId))
                        {
                            mutado.Remove(SteamId);
                            rust.SendChatMessage(targetuser, SystemName, "[color green]Você foi desmutado automaticamente.");
                            return;
                        }
                    });
                }
                else
                {
                    int correcao;

                    if (!(Int32.TryParse(args[1], out correcao))) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe um numero em minutos."); return; }

                    int tempo = Convert.ToInt32(args[1]);
                    int tempo1 = tempo * 60;

                    if (targetuser == null) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador."); return; }
                    if (tempo1 >= 86401) { rust.SendChatMessage(netuser, SystemName, "[color yellow]O numero informado não esta dentro do limite de 24 horas."); return; }

                    var SteamId = targetuser.playerClient.userID.ToString();

                    if (mutado.ContainsKey(SteamId)) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador já está mutado."); return; }

                    mutado.Add(SteamId, 1);
                    var ts = TimeSpan.FromSeconds(tempo1);

                    int tempview = ts.Minutes;
                    int tempview2 = 0;

                    string HoursOrMinutes = "";
                    string HoursOrMinutes2 = "";
                    string E = "";
                    string Mensagem = "";

                    if (tempo1 >= 59)
                    {
                        HoursOrMinutes = " minuto";
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + "  [color yellow])";
                    }

                    if (tempo1 > 119)
                    {
                        HoursOrMinutes = "minutos";
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + "  [color yellow])";
                    }

                    if (tempo1 >= 3600)
                    {
                        HoursOrMinutes = " hora";
                        HoursOrMinutes2 = "";
                        tempview = ts.Hours;
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + "  [color yellow])";
                    }

                    if (tempo1 >= 3659)
                    {
                        HoursOrMinutes = " hora";
                        E = "e";
                        HoursOrMinutes2 = " minuto";
                        tempview = ts.Hours;
                        tempview2 = ts.Minutes;
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + " " + E + " " + tempview2 + " " + HoursOrMinutes2 + "  [color yellow])";
                    }

                    if (tempo1 >= 3719)
                    {
                        HoursOrMinutes = " hora";
                        E = "e";
                        HoursOrMinutes2 = " minutos";
                        tempview = ts.Hours;
                        tempview2 = ts.Minutes;
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + " " + E + " " + tempview2 + " " + HoursOrMinutes2 + "  [color yellow])";
                    }

                    if (tempo1 >= 7200)
                    {
                        HoursOrMinutes = "horas";
                        HoursOrMinutes2 = "";
                        tempview = ts.Hours;
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + "  [color yellow])";
                    }

                    if (tempo1 >= 7259)
                    {
                        HoursOrMinutes = "horas";
                        HoursOrMinutes2 = " minuto";
                        tempview = ts.Hours;
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + " " + E + " " + tempview2 + " " + HoursOrMinutes2 + "  [color yellow])";
                    }

                    if (tempo1 >= 7319)
                    {
                        HoursOrMinutes = "horas";
                        HoursOrMinutes2 = "minutos";
                        tempview = ts.Hours;
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  " + tempview + " " + HoursOrMinutes + " " + E + " " + tempview2 + " " + HoursOrMinutes2 + "  [color yellow])";
                    }

                    if (tempo1 >= 86400)
                    {
                        HoursOrMinutes = "horas";
                        Mensagem = targetuser.displayName + " [color yellow]foi mutado por[color white] " + netuser.displayName + "  [color yellow]([color white]  24 " + HoursOrMinutes + "  [color yellow])";
                    }

                    rust.BroadcastChat(SystemName, string.Format(Mensagem));

                    timer.Once(tempo1, () =>
                    {
                        if (mutado.ContainsKey(SteamId))
                        {
                            mutado.Remove(SteamId);
                            rust.SendChatMessage(targetuser, SystemName, "[color green]Você foi desmutado automaticamente.");
                            return;
                        }
                    });
                }
           
        }

        [ChatCommand("unmute")]
        void cmdunmute(NetUser netuser, string command, string[] args)
        {
           
                if (!hasAccess(netuser, "canmute")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe um nickname de um jogador."); return; }

                NetUser targetuser = rust.FindPlayer(args[0]);

                if (targetuser == null) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador."); return; }

                var idtargetuser = targetuser.playerClient.userID.ToString();

                if (!mutado.ContainsKey(idtargetuser)) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador não está mutado."); return; }
                if (mutado.ContainsKey(idtargetuser))
                {
                    mutado.Remove(idtargetuser);
                    rust.SendChatMessage(netuser, SystemName, "[color green]O jogador[color white] " + targetuser.displayName + " [color green]foi desmutado por você com sucesso.");
                    rust.SendChatMessage(targetuser, SystemName, "[color green]O jogador[color white] " + netuser.displayName + " [color green]desmutou você com sucesso.");
                    return;
                }
           
        }

        //SISTEMA DE AFK

        Dictionary<string, object> GetPlayerdata(string userid)
        {
   
                if (Data[userid] == null)
                    Data[userid] = new Dictionary<string, object>();
                return Data[userid] as Dictionary<string, object>;

        }

        bool isAfk(string userid)
        {
  
                if (Data[userid] == null) return false;
                return (Data[userid] as Dictionary<string, object>).ContainsKey(userid);
           
        }

        void LoadData() {
            
                Data = Interface.GetMod().DataFileSystem.GetDatafile("AFKLIST");
            
        }
        void SaveData() {
            
                Interface.GetMod().DataFileSystem.SaveDatafile("AFKLIST");
                Interface.Oxide.DataFileSystem.WriteObject("PMSystem_Log", LogMessagesPM);
           
        }

        [ChatCommand("afk")]
        void AfkAdmins(NetUser netuser, string cmd, string[] args)
        {
           
                if (!hasAccess(netuser, "canafk")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }

                var id = netuser.userID.ToString();
                var playerdata = GetPlayerdata(id);
                if (playerdata.ContainsKey(id))
                {
                    rust.BroadcastChat(SystemName, string.Format("[color green]O jogador [color white]{0} [color green]retornou do modo ocioso.", netuser.displayName));
                    playerdata.Remove(id);
                    SaveData();
                }
                else
                {
                    rust.BroadcastChat(SystemName, string.Format("[color green]O jogador [color white]{0} [color green]entrou no modo ocioso.", netuser.displayName));
                    playerdata.Add(id, id);
                    SaveData();
                }
           
        }

        //OnPlayerChat

        bool OnPlayerChat(NetUser netuser, string message)
        {
           
                string name = rust.QuoteSafe(netuser.displayName);
                string namee = netuser.displayName;
                string msg = rust.QuoteSafe(message);
                int antifloodmaximo = 3;
                var SteamId = netuser.playerClient.userID.ToString();
                int at = 4;
                int flood = AntiFlood.Count;

                if (globalmute)
                {
                    if (!hasAccess(netuser, "canstaff")) { rust.SendChatMessage(netuser, SystemName, "[color red]O chat global foi desativado."); return true; }
                }

                foreach (string value in cores)
                {
                    if (message.Contains(value))
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color red]Palavra bloqueada encontrada.");
                        return true;
                    }
                }

                foreach (string value in nomes)
                {
                    if (msg.Contains(value))
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color red]Palavra bloqueada encontrada.");
                        return true;
                    }
                }

                if (mutado.ContainsKey(SteamId))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color red]Você está mutado.");
                    return true;
                }

                foreach (var group in Config)
                {
                    string gname = group.Key;
                    if (permission.UserHasPermission(netuser.userID.ToString(), Config[gname, "Permission"].ToString()))
                    {
                        name = rust.QuoteSafe(Config[gname, "Prefix"].ToString() + netuser.displayName);
                        msg = rust.QuoteSafe(Config[gname, "MessageColor"].ToString() + message);
                    }
                }



                if (AntiFloodList.Contains(SteamId))
                {
                    if (AntiFloodList.Count == 4f)
                    {
                        timer.Once(0, () =>
                        {
                            AntiFloodList.Clear();
                            mutado.Add(SteamId, 1);

                            rust.BroadcastChat(SystemName, string.Format(netuser.displayName + " [color yellow]foi mutado por[color white] Anti-Flood  [color yellow]([color white]  5 minutos  [color yellow])"));

                            timer.Once(300, () =>
                            {
                                if (mutado.ContainsKey(SteamId))
                                {
                                    mutado.Remove(SteamId);
                                    rust.SendChatMessage(netuser, SystemName, "[color green]Você foi desmutado automaticamente.");
                                    return;
                                }
                            });
                        });
                    }
                }

                AntiFloodList.Add(SteamId);
                timer.Once(3, () => { AntiFloodList.Clear(); });


                Puts(namee + ": " + message);
                ConsoleNetworker.Broadcast(string.Concat("chat.add ", name, " ", msg));
                netuser.NoteChatted();
            
            return false;
        }

        bool useShare = true;

        KeyValuePair<string, string> participants = new KeyValuePair<string, string>();
        List<string> history = new List<string>(5);

        static DateTime time = DateTime.Now;
        static List<string> LogMessagesPM = new List<string>();

        public static Dictionary<string, string> uplayer = new Dictionary<string, string>();
        public static List<EasyChat> PM = new List<EasyChat>();

        void Init()
        {
           
                permission.RegisterPermission(Permissao, this);
           
        }

        public EasyChat Find(string sender, string target) => PM.Find(x => (x.participants.Key == sender && x.participants.Value == target) || (x.participants.Key == target && x.participants.Value == sender));

        public EasyChat FindOrCreate(string sender, string target)
        {
 
                EasyChat msg = Find(sender, target);
                if (msg == null)
                {
                    msg = new EasyChat();
                    msg.participants = new KeyValuePair<string, string>(sender, target);
                    PM.Add(msg);
                }
                return msg;
           
        }

        bool AdminAFk(NetUser pm)
        {

                if (useShare)
                {
                    var share = this?.Call("isAfk", pm.userID.ToString(), pm.userID.ToString());
                    if (share is bool) return (bool)share;
                }
           
            return false;
        }

        bool AccessAdmin(NetUser netuser) { if (netuser.CanAdmin()) return true; return false; }

        bool hasAccess(NetUser netuser)
        {
            if (netuser.CanAdmin())
                return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), "canpm");
        }

        const string Permissao = "canpm";

        [ChatCommand("pm")]
        void cmdSendPm(NetUser netuser, string command, string[] args)
        {
           
                var SteamId = netuser.playerClient.userID.ToString();

                if (args.Length == 0)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe um nickname e uma mensagem.");
                    return;
                }

                if (mutado.ContainsKey(SteamId))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color red]Você está mutado.");
                    return;
                }


                string id1 = netuser.userID.ToString();
                NetUser procurar = rust.FindPlayer(args[0]);

                if (procurar == null)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador.");
                    return;
                }

                args[0] = null; if (netuser == procurar)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não pode enviar uma mensagem privada para si mesmo.");
                    return;
                }

                if (AdminAFk(procurar))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador está no modo ocioso e não pode receber pm.");
                    return;
                }

                string mensagem = StringArray(args);
                if (mensagem.Length == 0 || mensagem == null)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe a mensagem que deseja enviar.");
                    return;
                }

                EnviarPm(netuser, procurar, mensagem);
            
        }

        void EnviarPm(NetUser netuser, NetUser procurar, string mensagem)
        {
           
                string msg2 = rust.QuoteSafe(mensagem);
                var Id = netuser.userID.ToString();
                var Id1 = procurar.userID.ToString();
                var netusers = PlayerClient.All.Select(pc => pc.netUser).ToList();
                string alert = string.Format("{0} - {1} para {2}: [color #ff69b4]{3}", time, netuser.displayName, procurar.displayName, mensagem);
                string alert2 = string.Format("[PM] {1} para {2}: {3}", time, netuser.displayName, procurar.displayName, mensagem);

                foreach (string value in nomes)
                {
                    if (msg2.Contains(value))
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color red]Palavra bloqueada encontrada.");
                        return;
                    }
                }

                rust.SendChatMessage(netuser, "PM para " + procurar.displayName, "[color #ff00ff]" + mensagem);
                rust.SendChatMessage(procurar, "PM de " + netuser.displayName, "[color #ff00ff]" + mensagem);

                LogMessagesPM.Add(alert);
                Puts(alert2);

                for (int i = 0; i < netusers.Count; i++)
                {
                    if (hasAccess(netusers[i]))
                    {
                        rust.SendConsoleMessage(netusers[i], alert);
                    }
                }

                uplayer[Id] = Id1;
                uplayer[Id1] = Id;

                var msg = FindOrCreate(netuser.userID.ToString(), procurar.userID.ToString());
                msg.history.Add(string.Format("{0} para {1}: {2}", netuser.displayName, procurar.displayName, mensagem));

                if (msg.history.Count == 6)

                    msg.history.Remove(msg.history.First());
                SaveData();
           

        }

        [ChatCommand("r")]
        void cmdResposta(NetUser netuser, string cmd, string[] args)
        {
            
                string steamid;
                var SteamId = netuser.playerClient.userID.ToString();
                var Id = netuser.userID.ToString();
                string msg = string.Join(" ", args);

                if (args.Length == 0)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe a mensagem que deseja enviar.");
                    return;
                }

                if (uplayer.TryGetValue(netuser.userID.ToString(), out steamid))
                {
                    NetUser procurar = rust.FindPlayer(steamid);
                    if (procurar == null)
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador.");
                        return;
                    }

                    if (mutado.ContainsKey(SteamId))
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color red]Você está mutado.");
                        return;
                    }

                    var id1 = procurar.userID.ToString();
                    EnviarPm(netuser, procurar, msg);
                }
                else
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem mensagens privadas recentes.");
                    return;
                }
           
        }

        static string StringArray(string[] array)
        {

                string result = string.Join(" ", array.Where(item => !string.IsNullOrEmpty(item)).ToArray());
                return result;
            
        }
    }
}