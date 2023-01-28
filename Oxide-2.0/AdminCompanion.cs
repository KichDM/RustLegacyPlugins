// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
//
// Reference: Newtonsoft.Json
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using System.Data;
using System.Net;
// Reference: Facepunch.Cursor

using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;

using Oxide.Core;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rust;
using InventoryExtensions;
using Facepunch.Cursor;
using Facepunch.Cursor.Internal;

namespace Oxide.Plugins
{
    [Info("AdminCompanion - Mega Moon & PINK Update", "copper", "2.1.5")]
    class AdminCompanion : RustLegacyPlugin
    {
        public static string SystemName = "Server";
        public static Dictionary<string, string> DefaultKeys = MenuKeyBinds();
        public static Dictionary<NetUser, NetUser> NetUsers5 = new Dictionary<NetUser, NetUser>();
        public static Dictionary<string, int> Tempo = new Dictionary<string, int>();
        public static Dictionary<string, string> DefaultTriggers = TrigersMSG();
        public static Dictionary<string, string> DefaultObjects1 = Keys();
        private static List<string> testando = new List<string>();
        private static List<string> testado = new List<string>();

        

        public static Dictionary<string, string> BadNameKick = BadNameKickInit();

    

        public static Dictionary<string, string> MenuKeyBinds()
        {
            var newdict = new Dictionary<string, string>();
            newdict.Add("F2", "F2");
            newdict.Add("F3", "F3");
            newdict.Add("F4", "F4");
            newdict.Add("F5", "F5");
            newdict.Add("F6", "F6");
            newdict.Add("F7", "F7");
            newdict.Add("F8", "F8");
            newdict.Add("F9", "F9");
            newdict.Add("F10", "F10");
            newdict.Add("F11", "F11");
            newdict.Add("F12", "F12");
            newdict.Add("Mouse2", "Mouse2");
            newdict.Add("Home", "Home");
            newdict.Add("Insert", "Insert");

            return newdict;
        }

        [PluginReference]
        private Plugin PlayerDatabase;

        //Método CheatPunch financiado pelo proxolin

        static Dictionary<string, string> Keys()
        {
            var newdict = new Dictionary<string, string>();
           //newdict.Add("Keypad1","NumPad 1");
           //newdict.Add("Keypad0","Numpad 0");
            newdict.Add("g", "G");
            return newdict;
        }
        static Dictionary<string, string> BadNameKickInit()
        {
            var newdict = new Dictionary<string, string>();
            //newdict.Add("admin", "Você não tem permissão para se conectar com esse nick");
            //newdict.Add("mod", "Você não tem permissão para se conectar com esse nick");
            //newdict.Add("owner", "Você não tem permissão para se conectar com esse nick");
            //newdict.Add("gdsfsefsd", "Você não tem permissão para se conectar com esse nick");
            //newdict.Add("dono", "Você não tem permissão para se conectar com esse nick");
            return newdict;
        }
        public static Dictionary<string, string> TrigersMSG()
        {
            var newdict = new Dictionary<string, string>();
            //newdict.Add("hack", "Hola, Sospechas De un Hack? /report <nome> Que el Será Testeado Por Mi !");
            //newdict.Add("cheat", "Hola, Sospechas De un Hack? /report <nome> Que el Será Testeado Por Mi !");
            //newdict.Add("hacks", "Hola, Sospechas De un Hack? /report <nome> Que el Será Testeado Por Mi !");
            //newdict.Add("love,comp", "AdminCompanion: Agradece por su ayuda");
            return newdict;
        }
        public static string ReceiveDictionaries(CompanionCheck player, bool Criterior = false)
        {
            string ToReturn = "FinishedTest";
            if (Criterior)
            {
                foreach (KeyValuePair<string, string> pair in DefaultKeys)
                {
                    if (player.MenuDictionaries.ContainsKey(pair.Key))
                        continue;
                    else
                        ToReturn = pair.Key;
                }
                return ToReturn;
            }
            foreach (KeyValuePair<string, string> pair in DefaultObjects1)
            {
                if (player.TestDictionaries.ContainsKey(pair.Value))
                    continue;
                else
                    ToReturn = pair.Value;
            }
            return ToReturn;
        }
        public static string ReceiveDictionaries2(CompanionCheck player, bool Criterior = false)
        {
            string ToReturn = "FinishedTest";
            if (Criterior)
            {
                foreach (KeyValuePair<string, string> pair in DefaultKeys)
                {
                    if (player.MenuDictionaries.ContainsKey(pair.Key))
                        continue;
                    else
                        ToReturn = pair.Key;
                }
                return ToReturn;
            }
            foreach (KeyValuePair<string, string> pair in DefaultObjects1)
            {
                if (player.TestDictionaries.ContainsKey(pair.Key))
                    continue;
                else
                    ToReturn = pair.Key;
            }
            return ToReturn;
        }
        private static Core.Configuration.DynamicConfigFile Ipban;

        public static RaycastHit cachedRaycast;
        public static RaycastHit2 cachedRaycast2;
        public static PlayerClient cachedPlayer;
        public static string cachedModelname;
        public static string cachedObjectname;
        public static float cachedDistance;
        public static Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance;
        public static Collider cachedCollider;
        public static bool cachedBoolean;
        public bool hasrefreshedplugin;
        public static float gg;
        string cachedReason;
        string cachedName;
        public static GameObject Load;
        public static int numberofbansdizzy;
        public static int reportnum;
        public static int numberofbansjacked;
        public static int numberofbanssteven;
        public static int numberofbansnorecoil;
        public static int numberofbansnofalldamage;
        public static int numberofcheckevade;
        public static int numberofspeedjumpban;
        public static int NumberOfAspectDetections;
        public static bool shouldsendstatisticstoadminonconnect = false;
        NetUser cachedUser;
        string cachedSteamid;

        public Type BanType;
        public FieldInfo steamid;
        public FieldInfo username;
        public FieldInfo reason;
        public FieldInfo bannedUsers;
        static int terrainLayerr;

        Vector3 VectorUp = new Vector3(0f, 1f, 0f);
        Vector3 VectorDown = new Vector3(0f, -0.4f, 0f);
        Vector3 VectorDownn = new Vector3(0f, -0.1f, 0f);

        public static Vector3 Vector3Down = new Vector3(0f, -1f, 0f);
        public static Vector3 Vector3Down2 = new Vector3(0f, -3f, 0f);
        public static Vector3 Vector3Up = new Vector3(0f, 1f, 0f);
        public static Vector3 UnderPlayerAdjustement = new Vector3(0f, -1.15f, 0f);
        public static Vector3 UnderPlayerAdjustement2 = new Vector3(0f, -1.16f, 0f);
        public static RustServerManagement management2;
        public static Vector3 vectorup2 = new Vector3(0f, 1f, 0f);
        public static int terrainLayer;

        public static float distanceDown = 10f;
        public static RaycastHit cachedRaycasttt;
        private static Dictionary<string, ItemDataBlock> displaynameToDataBlock = new Dictionary<string, ItemDataBlock>();
        public Dictionary<string, string> hascalled = new Dictionary<string, string>();
        public static string laststring;
        public static bool finishedcheck1;
        public static bool finishedcheck2;
        public static bool finishedcheck3;
        public static JsonSerializerSettings jsonsettings;
        private static Core.Configuration.DynamicConfigFile Data;
        private static Core.Configuration.DynamicConfigFile Data3;
        private static Core.Configuration.DynamicConfigFile Data5;
        private static Core.Configuration.DynamicConfigFile Datablock;
        private static Core.Configuration.DynamicConfigFile Info;
        private static Core.Configuration.DynamicConfigFile DataStore;
        public static RaycastHit cachedRaycastttt;

        public static Dictionary<string, object> GetPlayerdata(string userid)
        {
            if (Data == null)
            {
                LoadData();
                if (Data == null)
                {
                    ConsoleSystem.Run("oxide.reload AdminCompanion");
                    return new Dictionary<string, object>();
                }

            }
            if (Data[userid] == null)
                Data[userid] = new Dictionary<string, object>();
            return Data[userid] as Dictionary<string, object>;
        }

        Dictionary<string, object> GetPlayerdata4(string userid)
        {

            if (Data5[userid] == null)
                Data5[userid] = new Dictionary<string, object>();
            return Data5[userid] as Dictionary<string, object>;

        }

        Dictionary<ulong, object> GetPlayerdata2(string userid)
        {

            if (Data3[userid] == null)
                Data3[userid] = new Dictionary<ulong, object>();
            return Data3[userid] as Dictionary<ulong, object>;

        }

 
        static Dictionary<string, ItemDataBlock> Getdatablock(string userid)
        {
            if (Datablock == null)
                LoadData();
            if (Datablock[userid] == null)
                Datablock[userid] = new Dictionary<string, ItemDataBlock>();
            return Datablock[userid] as Dictionary<string, ItemDataBlock>;
        }
        Dictionary<string, object> GetPlayeinfo(string userid)
        {
            if (Info == null)
                LoadData();
            if (Info[userid] == null)
                Info[userid] = new Dictionary<string, object>();
            return Info[userid] as Dictionary<string, object>;
        }
        static Dictionary<string, object> Getplayerdatastore(string userid)
        {
            if (DataStore == null)
                LoadData();
            if (DataStore[userid] == null)
                DataStore[userid] = new Dictionary<string, object>();
            return DataStore[userid] as Dictionary<string, object>;
        }
        public static void BanPlayer(NetUser netuser, string reason, string ip)
        {
            var ping = netuser.playerClient.netUser.networkPlayer.averagePing;
            Debug.Log(netuser.displayName + "-" + netuser.playerClient.userID.ToString() + " por " + reason + " Ping<" + ping + ">");
            ulong playerid;
            if (!ulong.TryParse(netuser.playerClient.userID.ToString(), out playerid))
            {
                return;
            }


            ipban2(netuser.playerClient, reason, ip);
            if (!BanList.Contains(playerid))
            {
                BanList.Add(playerid, netuser.displayName, reason + "IP " + ip + " Ping<" + ping + ">");
                BanList.Save();
            }
            var cachedUser = netuser;
            if (cachedUser != null)
            {
                cachedUser.Kick(NetError.ConnectionBanned, true);
            }

        }


        public static void LoadData() {
            
                Data5 = Interface.GetMod().DataFileSystem.GetDatafile("PlayerKickado");
                Data = Interface.GetMod().DataFileSystem.GetDatafile("AIAdmin(pl)"); Info = Interface.GetMod().DataFileSystem.GetDatafile("AdminCompanion(Reports.pl)"); DataStore = Interface.GetMod().DataFileSystem.GetDatafile("AdminCompanion(DataStore(pl))"); Ipban = Interface.GetMod().DataFileSystem.GetDatafile("Blacklist(ip)"); Datablock = Interface.GetMod().DataFileSystem.GetDatafile("AdminCompanion(Datablock(pl))");
            
        }

        void SaveData() {
            
                Interface.GetMod().DataFileSystem.SaveDatafile("PlayerKickado");
                Interface.GetMod().DataFileSystem.SaveDatafile("AIAdmin(pl)"); Interface.GetMod().DataFileSystem.SaveDatafile("AdminCompanion(DataStore(pl))"); Interface.GetMod().DataFileSystem.SaveDatafile("AdminCompanion(Datablock(pl))");
                Interface.GetMod().DataFileSystem.SaveDatafile("AntiCheat");
            
        }
        void Unload()
        {
           

                if (!falldamageenabled)
                    ConsoleSystem.Run("falldamage.enabled false", false);
                SaveData();
                var objects = GameObject.FindObjectsOfType(typeof(CompanionCheck));
                var objects1 = GameObject.FindObjectsOfType(typeof(CompanionCheck2));
                var objects2 = GameObject.FindObjectsOfType(typeof(CompanionCheckflagcheck));

                SaveData();
                var objects3 = GameObject.FindObjectsOfType(typeof(PlayerHandler));
                if (objects != null)
                    foreach (var gameObj3 in objects)
                        GameObject.Destroy(gameObj3);

                if (objects != null)
                    foreach (var gameObj in objects)
                    {
                        GameObject.Destroy(gameObj);
                    }
                if (objects1 != null)
                    foreach (var gameObj in objects)
                    {
                        GameObject.Destroy(gameObj);
                    }
                if (objects2 != null)
                    foreach (var gameObj2 in objects)
                    {
                        GameObject.Destroy(gameObj2);
                    }
            
        }
        public bool timerallowed;

        public bool ischecking = false;

        public static bool shouldlogwhoputstuffin = false;
        public static bool shoulddoipban = true;
        public static bool shouldbepinglienient = true;
        public static object pinglimitbeforeignore = 400;
        public static bool shouldbanforidle = true;
        public static object idletimetillban = 300f;
        public static object numberoffakecallslmit = 5;
        public static bool shouldchecknorecoil = true;
        public static bool shouldcheckjacked = true;
        public static bool shouldchecksteven = true;
        public static bool shouldcheckdizzy = true;
        public static bool shouldcheckjumpspeed = true;
        public static bool shouldcheckhackmenu = true;
        public static bool shouldchecknofall = true;
        public static bool shouldcheckforspeedjump = true;
        public static bool shoulduseplayerdatabase = false;
        public static bool shouldogwhotakestuffout = true;
        public static bool shouldlogfurnace = true;
        public static bool shouldbanforitmingjumps = true;
        public static string icon = "☢";
        public static object duration = 10.0f;
        public static object numberofvotes = 3.0f;
        public static object idletimetillautoseectlanguage = 60f;
        public static object numberoftimedjumpdettectionsbeforeban = 5;
        public static object numberofpercentagevtoesbeforecheck = 50;
        public static int maxammoutnoflanguagerefreshbeforeignore = 3;
        public static bool shouldbanifplayerdcduringtest = true;
        public static bool shouldresetdetectionwhenplayerdisconnects = true;
        public static bool shouldcheckonce = true;
        public static bool shouldcheckplayeroncewhenconnect = false;
        public static bool shouldcheckplayerwhenfirstconnect = false;
        public static bool shouldsendprobablybanevadetoadmin = true;
        public static bool shouldkicknoname = true;
        public static bool ShouldKickBadName = true;
        public static bool allowlanguagerefresh = true;
        public static bool shouldcheckplayerswithpermisions = true;
        public static bool shoulduseenglishdictionaryonly = true;
        public static bool shouldautoselectlagnuageifplayeridl = true;
        public static bool shouldcheckmultinofall = true;
        public static bool falldamageenabled = true;
        public static bool shouldallowtestresetifdisconnected = true;
        public static bool smartcheck = true;
        public static object menuscreenflag = 128;
        public static object crouchdetetctionsecondflagcheck = 6145;
        public static bool shouldignore = true;
        public static object HackMenuDetectionstillban = 3;
        public static string NoRecoilWeapon = "M4";
        public static string Email = "paulofsa98@gmail.com";
        int timereport = 3600;
        static int timereport2 = 3600;
        void LoadDefaultConfig() { }

        private void CheckCfg<T>(string Key, ref T var)
        {
            if (Config[Key] is T)
                var = (T)Config[Key];
            else
                Config[Key] = var;
        }
        public static object NumberOfPassesTillMinus = 2f;
        public static Dictionary<string, object> DeaultObjects = Defaultobject();
        public static Dictionary<string, object> DefaultObjectsEnabled = Defaultobject();
        public static Dictionary<string, object> BlackListedCharacters = CharactersInit();
        public static Dictionary<string, object> BlackListedNames = BlackListedNamesInit();
        static Dictionary<string, object> Defaultobject()
        {
            var newdict = new Dictionary<string, object>();
            newdict.Add("Porfavor escreva algo em seu idioma para continue o /lang LanguageCode", true);
            newdict.Add("Por favor escriba algo en su lengua materna para continuar o tipo /lang languagecode", true);
            newdict.Add("bitte etwas in Ihrer Muttersprache eingeben , um fortzufahren oder Typ /lang Sprachcode", true);
            newdict.Add("Devam veya yazın /lang languageCode için ana dilinde bir şeyler yazın lütfen", true);
            return newdict;
        }
        static Dictionary<string, object> CharactersInit()
        {
            var newdict = new Dictionary<string, object>();
            newdict.Add("l3", true);
            return newdict;
        }
        static Dictionary<string, object> BlackListedNamesInit()
        {
            var newdict = new Dictionary<string, object>();
            newdict.Add("ProGamer", true);
            return newdict;
        }
        public static void InitObJ()
        {
            
                DefaultObjectsEnabled.Clear();
                int count = 0;
                foreach (KeyValuePair<string, object> pair in DeaultObjects)
                {
                    if ((bool)pair.Value)
                    {
                        count++;
                        if (!DefaultObjectsEnabled.ContainsKey(count.ToString()))
                        {
                            DefaultObjectsEnabled.Add(count.ToString(), pair.Key);
                            continue;
                        }
                    }
                }
           
        }
        public static bool ShouldDetectChat = true;
        public static object NumberOfWhentupsTTillPass = 3;

        public static object TimerTillUngod = 20f;
        public static object SpeedJumpPassesTillPass = 4f;
        public static bool ShouldDegradeJumpDetection = true;
        public static object SpeedJumpTesttillfail = 3f;
        public static bool ShouldDisreGardIfKickedForViolation = true;
        public static bool RunTestOnBlacklistedNames = true;
        public static bool ShouldRunTestIfNameContainsBlckListedCharacters = true;
        public static bool ShouldTestPlayerIfNameIsNumber = true;
        public static bool ShouldOnlyCheckPlayerWithBadNameOnce = true;
        public static bool ShouldAllowCheckIfPlayerWithBadNameReconnect = false;
        public static bool ShouldBroadCastPlayerJumpSpeed = false;
        public static bool ShouldDoSmartJumpChect = true;
        public static bool ShouldDoAveragePingSpeedJumpCheck = true;
        const string Permissao = "reportvip";
        const string Permissao2 = "reportvip2";
        const string Permissao3 = "reportvip3";
        const string permissionDono = "dono_chat";
        const string permissionSubDono = "subdono_chat";
        const string permissionAdmin = "admin_chat";
        void Init()
        {
            CheckCfg<object>("ConFig: Ping Exceção se o jogador ping é greathan ou = para valor ignorar-", ref pinglimitbeforeignore);
            CheckCfg<object>("ConFig: Crouch Detcetion Exploit", ref crouchdetetctionsecondflagcheck);
            CheckCfg<object>("ConFig: Tela de menu A opção Flag-when é pressionada", ref menuscreenflag);
            CheckCfg<object>("ConFig: Hack Menu Detecções até a proibição ", ref HackMenuDetectionstillban);
            CheckCfg<object>("ConFig: Número de passagens a serem removidas se Timed Jump for detectado ", ref NumberOfPassesTillMinus);
            CheckCfg<object>("ConFig: Número de subidas até a passagem ", ref NumberOfWhentupsTTillPass);
            CheckCfg<object>("ConFig: Timer-Till UnGod ", ref TimerTillUngod);
            CheckCfg<object>("ConFig: O salto de velocidade passa até a passagem - (DevCheck) ", ref SpeedJumpPassesTillPass);
            CheckCfg<object>("ConFig: A proibição da lavagem da velocidade de detecção de salto  - (DevCheck) ", ref SpeedJumpTesttillfail);
            CheckCfg<object>("ConFig: Duração da mensagem", ref duration);
            CheckCfg<object>("ConFig: Número de percentagens de votos antes da verificação ", ref numberofpercentagevtoesbeforecheck);
            CheckCfg<object>("ConFig: Tempo ocioso até a proibição - ", ref idletimetillban);
            CheckCfg<object>("ConFig: Tempo de inatividade até selecionar automaticamente idioma inglês", ref idletimetillautoseectlanguage);
            CheckCfg<object>("ConFig: Número de detecção de falso idioma antes de ignorar", ref numberoffakecallslmit);
            CheckCfg<object>("ConFig: Número de detecções de salto temporizado antes de banir os jogadores DB-JumpCheck", ref numberoftimedjumpdettectionsbeforeban);
            CheckCfg<string>("Messages: Ícone para Mensagem novo ícone ", ref icon);
            CheckCfg<string>("Messages: Arma para verificar Sem Recoil para testar Recoil do Jogador", ref NoRecoilWeapon);
            CheckCfg<string>("Messages: Insira um e-mail válido para ativar o potencial completo da api", ref Email);
            CheckCfg<bool>("Bool: Deve fazer ping exceção", ref shouldbepinglienient);
            CheckCfg<bool>("Bool: Deve permitir Smart Jump verificar?", ref ShouldDoSmartJumpChect);
            CheckCfg<bool>("Bool: Deve verificar o ping para verificação de salto de velocidade?", ref ShouldDoAveragePingSpeedJumpCheck);
            CheckCfg<bool>("Bool: Deve verificar o jogador com mau nome uma vez?", ref ShouldOnlyCheckPlayerWithBadNameOnce);
            CheckCfg<bool>("Bool: Deve executar o teste se o nome estiver em BlackList", ref ShouldRunTestIfNameContainsBlckListedCharacters);
            CheckCfg<bool>("Bool: Deve verificar o jogador com Bad Name reconectar se <deve verificar o jogador com nome ruim uma vez> ativado", ref ShouldAllowCheckIfPlayerWithBadNameReconnect);
            CheckCfg<bool>("Bool: Deve fazer ping exceção", ref RunTestOnBlacklistedNames);
            CheckCfg<bool>("Bool: Deve BroadCast Player salto velocidade - (Dev Check)", ref ShouldBroadCastPlayerJumpSpeed);
            CheckCfg<bool>("Bool: Deve fazer ping exceção", ref ShouldRunTestIfNameContainsBlckListedCharacters);
            CheckCfg<bool>("Bool: Deveria fazer ip ban", ref shoulddoipban);
            CheckCfg<bool>("Bool: Deve verificar Jacked", ref shouldcheckjacked);
            CheckCfg<bool>("Bool: Deve ignorar a proibição se chutado por violação?", ref ShouldDisreGardIfKickedForViolation);

            CheckCfg<bool>("Bool: Deve ignorar o jogador se idioma falso detectado", ref shouldignore);
            CheckCfg<bool>("Bool: Deve verificar o jogador se name for Number?", ref ShouldTestPlayerIfNameIsNumber);


            CheckCfg<bool>("Bool: Deve verificar o sistema inteligente (verifique os jogadores cujos nomes estão no banlist etc ....)", ref smartcheck);
            CheckCfg<bool>("Bool: Deve verificar o bate-papo", ref ShouldDetectChat);
            CheckCfg<bool>("Bool: Deve revolver a detecção de salto de tempo para passagem", ref ShouldDegradeJumpDetection);

            CheckCfg<bool>("Bool: Deve proibir para ocioso?", ref shouldbanforidle);

            CheckCfg<int>("Messages: Quantidade máxima de reinicialização de idioma antes de ignorar ", ref maxammoutnoflanguagerefreshbeforeignore);
            CheckCfg<bool>("Bool: Deve verificar se há salto de velocidade? ", ref shouldcheckjumpspeed);
            CheckCfg<bool>("Bool: Deve verificar jogadores com permissões em conectar?", ref shouldcheckplayerswithpermisions);
            CheckCfg<bool>("Bool: Permitir a atualização de idioma? ", ref allowlanguagerefresh);
            CheckCfg<bool>("Bool: Deve chutar noname ?? ", ref shouldkicknoname);
            CheckCfg<bool>("Bool: Deve enviar provavelmente ban fugir ao bate-papo? ", ref shouldsendprobablybanevadetoadmin);
            CheckCfg<bool>("Bool: Deve checkplayer uma vez? Isto irá verificar o jogador uma vez quando ele / ela se conecta a menos que votechecked ou força controlada ", ref shouldcheckplayeroncewhenconnect);
            CheckCfg<bool>("Bool: Deve checkplayer quando primeira conexão? ", ref shouldcheckplayerwhenfirstconnect);
            CheckCfg<bool>("Bool: Shouldcheck uma vez quando votado? ", ref shouldcheckonce);
            CheckCfg<bool>("Bool: Deve redefinir a detecção quando o leitor desconecta? ", ref shouldresetdetectionwhenplayerdisconnects);
            CheckCfg<bool>("Bool: Deve proibir jogador dc durante o teste? ", ref shouldbanifplayerdcduringtest);
            CheckCfg<bool>("Bool: Deve verificar se não há queda? ", ref shouldchecknofall);

            CheckCfg<bool>("Bool: Deve verificar para hack menu? ", ref shouldcheckhackmenu);
            CheckCfg<bool>("Bool: Shouldcheck para não recoil? ", ref shouldchecknorecoil);
            CheckCfg<bool>("Bool: Deve proibir para o salto do sincronismo? (Custom)", ref shouldbanforitmingjumps);
            CheckCfg<bool>("Bool: Deve usar somente o dicionário inglês? ", ref shoulduseenglishdictionaryonly);
            CheckCfg<bool>("Bool: Deve selecionar automaticamente o idioma inglês se o player estiver ocioso? ", ref shouldautoselectlagnuageifplayeridl);
            CheckCfg<bool>("Bool: Deve enviar estatísticas para admins / mods em conectar? ", ref shouldsendstatisticstoadminonconnect);
            CheckCfg<bool>("Bool: Check multi nofall este é um método para detectar stevens assim chamado não detectado nenhum corte hack você terá que especificar se o seu servidor tem nofall habilitado ou não", ref shouldcheckmultinofall);
            CheckCfg<bool>("Bool: Você tem falldamage habilitado em seu servidor? - DerpMethod", ref falldamageenabled);
            CheckCfg<bool>("Bool: Deve permitir a reinicialização do relatório se desconectado do servidor?", ref shouldallowtestresetifdisconnected);
            CheckCfg<bool>("Bool: Deve chutar jogadores com Bad Name?", ref ShouldKickBadName);
            CheckCfg<Dictionary<string, string>>("Teclas para teste você pode adicionar ou remover chaves !!!", ref DefaultKeys);
            CheckCfg<Dictionary<string, string>>("Chaves padrão a serem aplicadas à verificação de aspecto do PlayerClients Você pode adicionar ou remover chaves", ref DefaultObjects1);
            CheckCfg<Dictionary<string, string>>("Nomes errados / Personagens para chutar", ref BadNameKick);
            CheckCfg<Dictionary<string, object>>("BlackListed Characters ", ref BlackListedCharacters);
            CheckCfg<Dictionary<string, object>>("BlackListed Names ", ref BlackListedNames);


            CheckCfg<bool>("Settings: Permanent Check", ref permanent);
            CheckCfg<bool>("Settings: Broadcast Detections to Admins", ref broadcastAdmins);
            CheckCfg<bool>("Settings: Broadcast Bans to Players", ref broadcastPlayers);
            CheckCfgFloat("Settings: Check Time (seconds)", ref timetocheck);
            CheckCfg<bool>("Settings: Punish by Ban", ref punishByBan);
            CheckCfg<bool>("Settings: Punish by Kick", ref punishByKick);
            CheckCfg<bool>("SpeedHack: activated", ref antiSpeedHack);
            CheckCfgFloat("SpeedHack: Minimum Speed (m/s)", ref speedMinDistance);
            CheckCfgFloat("SpeedHack: Maximum Speed (m/s)", ref speedMaxDistance);
            CheckCfgFloat("SpeedHack: Max Height difference allowed (m/s)", ref speedDropIgnore);
            CheckCfgFloat("SpeedHack: Detections needed in a row before Punishment", ref speedDetectionForPunish);
            CheckCfg<bool>("SpeedHack: Punish", ref speedPunish);
            CheckCfg<bool>("WalkSpeedHack: activated", ref antiWalkSpeedhack);
            CheckCfgFloat("WalkSpeedHack: Minimum Speed (m/s)", ref walkspeedMinDistance);
            CheckCfgFloat("WalkSpeedHack: Maximum Speed (m/s)", ref walkspeedMaxDistance);
            CheckCfgFloat("WalkSpeedHack: Max Height difference allowed (m/s)", ref walkspeedDropIgnore);
            CheckCfgFloat("WalkSpeedHack: Detections needed in a row before Punishment", ref walkspeedDetectionForPunish);
            CheckCfg<bool>("WalkSpeedHack: Punish", ref walkspeedPunish);
            CheckCfg<bool>("SuperJump: activated", ref antiSuperJump);
            CheckCfgFloat("SuperJump: Minimum Height (m/s)", ref jumpMinHeight);
            CheckCfgFloat("SuperJump: Maximum Distance before ignore (m/s)", ref jumpMaxDistance);
            CheckCfgFloat("SuperJump: Detections needed before punishment", ref jumpDetectionsNeed);
            CheckCfgFloat("SuperJump: Time before the superjump detections gets reseted", ref jumpDetectionsReset);
            CheckCfg<bool>("SuperJump: Punish", ref jumpPunish);
            CheckCfg<bool>("FlyHack: activated", ref antiFlyhack);
            CheckCfgFloat("FlyHack: Max Drop Speed before ignoring (m/s)", ref flyhackMaxDropSpeed);
            CheckCfgFloat("FlyHack: Detections needed before punishment", ref flyhackDetectionsForPunish);
            CheckCfg<bool>("FlyHack: Punish", ref flyhackPunish);
            CheckCfg<bool>("BlueprintUnlocker: activated", ref antiBlueprintUnlocker);
            CheckCfg<bool>("BlueprintUnlocker: Punish", ref blueprintunlockerPunish);
            CheckCfg<bool>("Autoloot: activated", ref antiAutoloot);
            CheckCfg<bool>("Autoloot: Punish", ref autolootPunish);
            CheckCfg<bool>("AntiMassRadiation: activated", ref antiMassRadiation);
            CheckCfg<bool>("OverKill: activated", ref antiOverKill);
            CheckCfg<bool>("OverKill: Punish ", ref overkillPunish);
            CheckCfg<Dictionary<string, object>>("OverKill: Max Distances", ref overkillDictionary);
            CheckCfgFloat("OverKill: Reset Timer ", ref overkillResetTimer);
            CheckCfgFloat("OverKill: Detections before punish", ref overkillDetectionForPunish);
            CheckCfg<bool>("Wallhack: activated", ref antiWallhack);
            CheckCfg<bool>("Wallhack: Punish ", ref wallhackPunish);
            CheckCfg<bool>("CeilingHack: activated", ref antiCeilingHack);
            CheckCfg<bool>("CeilingHack: Punish ", ref ceilinghackPunish);
            CheckCfg<bool>("Sleeping Bag Hack: activated", ref antiSleepingBagHack);
            CheckCfg<bool>("Sleeping Bag Hack: Punish ", ref sleepingbaghackPunish);
            CheckCfg<bool>("NoRecoil: activated", ref antiNoRecoil);
            CheckCfg<bool>("NoRecoil: Punish ", ref norecoilPunish);
            CheckCfgFloat("NoRecoil: Min Distance For Check ", ref norecoilDistance);
            CheckCfg<int>("NoRecoil: Punish Min Kills", ref norecoilPunishMinKills);
            CheckCfg<int>("NoRecoil: Punish Min Ratio in %", ref norecoilPunishMinRatio);

            CheckCfg<bool>("AutoGather: activated", ref antiAutoGather);
            CheckCfg<bool>("AutoGather: Punish ", ref autogatherPunish);

            CheckCfg<string>("Messages: No Access", ref noAccess);
            CheckCfg<string>("Messages: No player found", ref noPlayerFound);
            CheckCfg<string>("Messages: Player being checked", ref checkingPlayer);
            CheckCfg<string>("Messages: All players being checked", ref checkingAllPlayers);
            CheckCfg<string>("Messages: Data Reseted", ref DataReset);

            permission.RegisterPermission(Permissao, this);
            permission.RegisterPermission(Permissao2, this);
            permission.RegisterPermission(Permissao3, this);
            permission.RegisterPermission(permissionDono, this);
            permission.RegisterPermission(permissionSubDono, this);
            permission.RegisterPermission(permissionAdmin, this);
            SaveConfig();
        }
        public static bool BadName(string Name)
        {
            if (ShouldRunTestIfNameContainsBlckListedCharacters)
                foreach (KeyValuePair<string, object> pair in BlackListedCharacters)
                    if (Name.ToLower().Contains(pair.Key.ToLower()))
                        return true;
            if (RunTestOnBlacklistedNames)
                foreach (KeyValuePair<string, object> pair in BlackListedNames)
                    if (Name.ToLower() == pair.Key.ToLower())
                        return true;
            float t = 0f;
            if (ShouldTestPlayerIfNameIsNumber)
                if (float.TryParse(Name, out t))
                    return true;
            return false;


        }

        Dictionary<string, object> getipban5(string userid)
        {

            if (Ipban[userid] == null)
                Ipban[userid] = new Dictionary<string, object>();
            return Ipban[userid] as Dictionary<string, object>;

        }

        public static Dictionary<string, object> Getipban(string userid)
        {
            if (Ipban == null)
                LoadData();
            if (Ipban[userid] == null)
                Ipban[userid] = new Dictionary<string, object>();
            return Ipban[userid] as Dictionary<string, object>;
        }
        public static void ipban(CompanionCheck player, string reason)
        {
            
                if (shoulddoipban)
                {
                    var ip = player.MyIp;
                    var name = player.playerclient.userName;
                    var GetPlayerdata = Getipban("Blacklist(ip)");
                    if (!GetPlayerdata.ContainsKey(ip))
                        GetPlayerdata.Add(ip, name + " Reason : " + reason);
                    Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)");

                }
           
        }

        public static void ipban2(PlayerClient player, string reason, string ip2 = null)
        {
           
                if (shoulddoipban)
                {
                    var ip = player.netUser.networkPlayer.externalIP.ToString();
                    if (ip2 != null)
                        ip = ip2;
                    var name = player.userName;
                    var GetPlayerdata = Getipban("Blacklist(ip)");
                    if (GetPlayerdata != null)
                        if (!GetPlayerdata.ContainsKey(ip))
                            GetPlayerdata.Add(ip, name + " Reason : " + reason);
                    Interface.GetMod().DataFileSystem.SaveDatafile("Blacklist(ip)");
                }
            
        }
        void Start()
        {
            
                LoadData();
                timer.Once(5.1f, () => CheckGameObject());
                SaveData();
                cleardatastore();
                if (!permission.PermissionExists("cantest")) permission.RegisterPermission("cantest", this);
                if (!permission.PermissionExists("AdminCompanion.adminname")) permission.RegisterPermission("AdminCompanion.adminname", this);
                if (!permission.PermissionExists("cankick")) permission.RegisterPermission("cankick", this);
                terrainLayer = LayerMask.GetMask(new string[] { "Terrain" });
                management2 = RustServerManagement.Get();
                InitializeTable();
                BanType = typeof(BanList).GetNestedType("Ban", BindingFlags.Instance | BindingFlags.NonPublic);
                steamid = BanType.GetField("steamid");
                username = BanType.GetField("username");
                reason = BanType.GetField("reason");

                bannedUsers = typeof(BanList).GetField("bannedUsers", (BindingFlags.Static | BindingFlags.NonPublic));
           
        }

        // GAMBIARRA FEITA POR: VICTORS (SÓ COLOCO MEU NOME EM GAMBIARRA)

        //VARIAVEL DE KICK
        public static string kickMessage = "{1} [color red]foi kickado do servidor﹣  {2}";
        static bool broadcastKick = true;
        public static bool preventadminkick = true;
        public static bool shouldpreventkickonself = true;

        //VARIAVEL PRA IDENTIFICAR QUE O USUARIO FOI KICKADO!
        public static bool playerkickado = false;

        void cmdKick(string userid, string name, string reason)
        {
            
                cachedUser = rust.FindPlayer(userid);
                if (cachedUser != null)
                {
                   
                    ulong playerid = Convert.ToUInt64(userid);

                   
                    cachedUser.Kick(NetError.Facepunch_Kick_RCON, true);
                   

                }
           
        }

        [ChatCommand("kick")]
        void cmdChatKick(NetUser netuser, string command, string[] args)
        {
           
                if (!hasAccess(netuser, "cankick")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length == 0) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe o nickname de um jogador."); return; }
                cachedSteamid = string.Empty;
                cachedName = string.Empty;
                NetUser targetuser = rust.FindPlayer(args[0]);
                if (targetuser != null)
                {
                    cachedSteamid = targetuser.playerClient.userID.ToString();
                    cachedName = targetuser.playerClient.userName.ToString();
                }
                else
                {
                    if (args[0].Length != 17) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador."); return; }
                    cachedSteamid = args[0];
                }
                if (shouldpreventkickonself)
                {
                    if (targetuser == netuser)
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não pode kickar a si mesmo.");
                        return;
                    }
                }
                if (preventadminkick)
            {
                    if (hasimmunity(targetuser, "kickimunity")) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para kickar um administrador."); return; }
                }
                var steamid = targetuser.playerClient.userID.ToString();
                var ID = targetuser.userID.ToString();
                cachedReason = string.Empty;
                if (args.Length > 1)
                {
                    if (cachedName == string.Empty)
                    {
                        cachedName = args[1];
                        if (args.Length > 2) cachedReason = args[2];
                    }
                    else
                        cachedReason = args[1];
                }
                cachedReason += "[color red]( " + "[color white]" + netuser.displayName + " [color red])";
                if (!broadcastKick) ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "Server " + Facepunch.Utility.String.QuoteSafe(string.Format(kickMessage, cachedSteamid, cachedName, cachedReason)));
                else AdminCompanionBroadcastplayerr(string.Format(kickMessage, cachedSteamid, cachedName, cachedReason));
                var GetPlayerdata = GetPlayerdata4("PlayerKickado");
                ulong playerid = Convert.ToUInt64(steamid);
                GetPlayerdata.Add(cachedSteamid, "kickado");
                testando.Remove(steamid);
                Interface.CallHook("cmdKick", cachedSteamid, cachedName, cachedReason);
                GetPlayerdata.Remove(cachedSteamid);



            
        }

        bool hasimmunity(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "ipbanimunity")) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }

        bool reportimmunity(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "reportimunity")) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }

        public static Oxide.Core.Libraries.Permission Spermission = GetLibrary<Oxide.Core.Libraries.Permission>();

        bool hasAccess(NetUser netuser, string Name = "cantest")
        {
            if (netuser.CanAdmin())
                return true;

            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), Name);
        }

        bool hasAccess2(NetUser netUser)
        {
            if (permission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao)) return true;
            return false;
        }
        bool hasAccess3(NetUser netUser)
        {
            if (permission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao2)) return true;
            return false;
        }
        bool hasAccess4(NetUser netUser)
        {
            if (permission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao3)) return true;
            return false;
        }

        static bool hasAccess5(NetUser netUser)
        {
            if (Spermission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao)) return true;
            return false;
        }
        static bool hasAccess6(NetUser netUser)
        {
            if (Spermission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao2)) return true;
            return false;
        }
        static bool hasAccess7(NetUser netUser)
        {
            if (Spermission.UserHasPermission(netUser.playerClient.userID.ToString(), Permissao3)) return true;
            return false;
        }

        static bool AnticheatImuunity(NetUser netuser)
        {
            if (Spermission.UserHasPermission(netuser.playerClient.userID.ToString(), "canimmunityanticheat")) return true;
            return false;
        }

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

        public static void refreshrecoiltest(CompanionCheck player)
        {
           
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.bind Fire c c");
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.mousespeed 0");
                return;
            
        }
        NetUser FindTargetPlayer(string Target)
        {
            foreach (PlayerClient player in PlayerClient.All)
            {
                if (player.userName == Target || player.userID.ToString() == Target)
                    return player.netUser;
            }
            foreach (PlayerClient player in PlayerClient.All)
            {
                if (player.userName.ToLower() == Target.ToLower())
                    return player.netUser;
            }
            foreach (PlayerClient player in PlayerClient.All)
            {
                if (player.userName.ToLower().Contains(Target.ToLower()))
                    return player.netUser;
            }
            return null;
        }
        [ChatCommand("report")]
        void cmdChatProdwholootedd(NetUser netuser, string command, string[] args)
        {
            
                if (args.Length == 0)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe o nickname de um jogador.");
                    return;
                }

                int _timeinterval = timereport;
                if (hasAccess2(netuser))
                    _timeinterval = 43200;
                else if (hasAccess3(netuser))
                    _timeinterval = 28800;
                else if (hasAccess4(netuser))
                    _timeinterval = 14400;
                else
                    _timeinterval = timereport;

                cachedName = string.Empty;
                cachedReason = string.Empty;
                if (args.Length > 1)
                {
                    if (cachedName == string.Empty)
                    {
                        cachedName = args[1];
                        if (args.Length > 2)
                        {
                            cachedReason = args[2];
                        }
                        else
                        {
                            cachedReason = args[1];
                        }
                    }
                }
                cachedReason += "(" + netuser.displayName + ")";
                NetUser targetuser = FindTargetPlayer(args[0]);
                if (targetuser == null)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador.");
                    return;
                }

                var SteamId = targetuser.playerClient.userID.ToString();
                var newdata = GetPlayeinfo(targetuser.playerClient.userID.ToString());
                var newdata2 = GetPlayeinfo("Reporteddata");


                if (targetuser == netuser)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não pode reportar a si mesmo.");
                    return;
                }

                if (!netuser.CanAdmin())
                {
                    if (!Dono(netuser))
                    {
                        if (Dono(targetuser))
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para reportar um administrador.");
                            return;
                        }

                        if (!SubDono(netuser))
                        {
                            if (SubDono(targetuser))
                            {
                                rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para reportar um administrador.");
                                return;
                            }
                            if (Admin(targetuser))
                            {
                                rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para reportar um administrador.");
                                return;
                            }
                        }
                    }
                }

                if (newdata.ContainsKey(netuser.playerClient.userID.ToString()))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você já reportou este jogador.");
                    return;
                }

                if (testando.Contains(SteamId))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador já está sendo testado no momento.");
                    return;
                }

                var haschecked = Getplayerdatastore("Server(haschecked)");
                if (shouldcheckonce)
                {
                    if (hasAccess2(targetuser))
                    {
                        if (testado.Contains(SteamId))
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador é [VIP] e já foi reportado a menos de 12 horas.");
                            return;
                        }
                    }
                    else if (hasAccess3(targetuser))
                    {
                        if (testado.Contains(SteamId))
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador é [VIP] e já foi reportado a menos de 8 horas.");
                            return;
                        }
                    }
                    else if (hasAccess4(targetuser))
                    {
                        if (testado.Contains(SteamId))
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador é [VIP] e já foi reportado a menos de 4 horas.");
                            return;
                        }
                    }
                    else if (testado.Contains(SteamId))
                    {
                        rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador já foi reportado a menos de 1 hora.");
                        return;
                    }
                }
                if (!newdata.ContainsKey("Reportspl"))
                {
                    reportnum++;
                    newdata.Add("Reportspl", 1f);
                    timer.Once(180f, () => newdata.Remove("Reportspl".ToString()));
                    string UserData = netuser.playerClient.userID.ToString();
                    if (!newdata.ContainsKey(UserData))
                    {
                        timer.Once(180f, () => newdata.Remove(UserData));
                        newdata.Add(netuser.playerClient.userID.ToString(), cachedReason);
                    }
                    var text = Convert.ToSingle(newdata["Reportspl"]);
                    if (text >= int.Parse(numberofvotes.ToString()))
                    {
                        AdminCompanionBroadcastplayerr(targetuser.displayName + " [color yellow]está sendo testado.");
                        //targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                        if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                        timer.Once(0.3f, () => phandler.StartCheck());
                        rust.Notice(targetuser, "Você foi enviado para o teste AntiHack.");
                        targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        testando.Add(SteamId);
                        haschecked.Add(targetuser.playerClient.userID.ToString(), targetuser.displayName);
                        if (!newdata.ContainsKey("numberoftimeschecked"))
                        {
                            newdata.Add("numberoftimeschecked", 1);
                        }
                        if (!newdata.ContainsKey(netuser.playerClient.userID.ToString()))
                        {
                            timer.Once(300f, () => newdata.Remove(UserData));
                            newdata.Add(netuser.playerClient.userID.ToString(), cachedReason);

                        }
                        var datecheckadd = Convert.ToSingle(newdata["numberoftimeschecked"]);
                        datecheckadd++;
                    }
                    rust.SendChatMessage(netuser, SystemName, "[color white]Você reportou [color green]" + targetuser.displayName + "[color white] com sucesso.");
                    rust.SendChatMessage(netuser, SystemName, "[color white]Ele precisa de um total de  [color red](" + "1" + "[color #CD0000]/[color red]" + numberofvotes + "）");
                    Debug.Log("[Console] "+ netuser.displayName + " votou para testar o usuario " + targetuser.displayName + ", ele precisa de um total de " + "1" + "/" + numberofvotes);
                    return;
                    var tallyy2 = PlayerClient.All.Count;
                    var newdatacount2 = Convert.ToSingle(newdata["Reportspl"]);
                    var enhanced2 = (tallyy2 / newdatacount2 * 100);
                    var percentageleftt = (50 - enhanced2);

                    if (percentageleftt <= 0)
                    {
                        //targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                        if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                        timer.Once(0.3f, () => phandler.StartCheck());
                        //rust.SendChatMessage(netuser, "Server", targetuser.displayName + " [color yellow]está sendo testado.");
                        targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        testando.Add(SteamId);
                        haschecked.Add(targetuser.playerClient.userID.ToString(), targetuser.displayName);
                        if (!newdata.ContainsKey("numberoftimeschecked"))
                        {
                            newdata.Add("numberoftimeschecked", 1);//
                            return;
                        }
                        if (!newdata2.ContainsKey(netuser.playerClient.userID.ToString()))
                        {
                            newdata2.Add(netuser.playerClient.userID.ToString(), cachedReason);

                        }
                        var datecheckadd = Convert.ToSingle(newdata["numberoftimeschecked"]);
                        datecheckadd++;
                        return;
                    }
                    rust.SendChatMessage(netuser, SystemName, "[color white]Você reportou [color green]" + targetuser.displayName + "[color white] com sucesso.");
                    rust.SendChatMessage(netuser, SystemName, "[color white]Ele precisa de um total de  [color red](" + "1" + "[color #CD0000]/[color red]" + numberofvotes + "）");
                    return;
                }
                if (newdata.ContainsKey(netuser.playerClient.userID.ToString()))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você já reportou este jogador");
                    return;
                }
                if (!newdata.ContainsKey(netuser.playerClient.userID.ToString()))
                {
                    newdata.Add(netuser.playerClient.userID.ToString(), cachedReason);
                    string totake = netuser.playerClient.userID.ToString();
                    timer.Once(180f, () => newdata.Remove(totake));
                }
                var newdatacount = Convert.ToSingle(newdata["Reportspl"]);
                newdata.Remove("Reportspl");
                var update = (newdatacount + 1f);
                newdata.Add("Reportspl", update);
                if (update >= int.Parse(numberofvotes.ToString()))
                {
                    if (targetuser.playerClient.controllable == null || targetuser.playerClient.controllable.health <= 0)
                    {
                        if (!NetUsers5.ContainsKey(targetuser))
                            NetUsers5.Add(targetuser, netuser);
                        AdminCompanionBroadcastplayerr(targetuser.displayName + " [color yellow]está sendo testado.");
                        reportnum++;
                        return;
                    }
                    AdminCompanionBroadcastplayerr(targetuser.displayName + " [color yellow]está sendo testado.");
                    rust.Notice(targetuser, targetuser.displayName + "Você foi enviado para o teste AntiHack.");
                    targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                    testando.Add(SteamId);
                    CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                    timer.Once(0.3f, () => phandler.StartCheck());
                    //rust.SendChatMessage(netuser, "Server", targetuser.displayName + " [color yellow]está sendo testado.");
                    haschecked.Add(targetuser.playerClient.userID.ToString(), targetuser.displayName);
                }
                reportnum++;
                rust.SendChatMessage(netuser, SystemName, "[color white]Você reportou [color green]" + targetuser.displayName + "[color white] com sucesso.");
                rust.SendChatMessage(netuser, SystemName, "[color white]Ele precisa de um total de  [color red](" + update + "[color #CD0000]/[color red]" + numberofvotes + "）");
                Debug.Log("[Console] " + netuser.displayName + " votou para testar o usuario " + targetuser.displayName + ", ele precisa de um total de " + update + "/" + numberofvotes);
                return;

                var tally = update;
                var tally2 = PlayerClient.All.Count;
                var enhanced = (tally / tally2 * 100);
                var percentageleft = (50 - enhanced);
                if (percentageleft <= 0)
                {
                    CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                    timer.Once(0.3f, () => phandler.StartCheck());
                    //rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " [color yellow]está sendo testado.");
                    targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                    testando.Add(SteamId);
                    return;
                }


                if (!newdata2.ContainsKey(netuser.playerClient.userID.ToString()))
                {
                    newdata2.Add(netuser.playerClient.userID.ToString(), cachedReason);

                }
                gg++;
                newdata.Remove("Reportspl");
                newdata.Add("Reportspl", update);
                newdata.Add(netuser.playerClient.userID.ToString(), cachedReason);
                if (enhanced <= int.Parse(numberofpercentagevtoesbeforecheck.ToString()))
                    rust.SendChatMessage(netuser, SystemName, "[color white]Você reportou [color green]" + targetuser.displayName + "[color white] com sucesso.");
                rust.SendChatMessage(netuser, SystemName, "[color white]Ele precisa de um total de  [color red](" + "1" + "[color #CD0000]/[color red]" + numberofvotes + "）");
                if (enhanced >= int.Parse(numberofpercentagevtoesbeforecheck.ToString()))
                {
                    if (targetuser.playerClient.controllable == null || targetuser.playerClient.controllable.health <= 0)
                    {
                        if (!NetUsers5.ContainsKey(targetuser))
                            NetUsers5.Add(targetuser, netuser);
                        AdminCompanionBroadcastplayerr(targetuser.displayName + " [color yellow]está sendo testado.");
                        targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        testando.Add(SteamId);
                        reportnum++;
                        return;
                    }
                    CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                    timer.Once(0.3f, () => phandler.StartCheck());
                    //rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " [color yellow]está sendo testado.");
                    return;
                }
                rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador");
                return;
           
        }
        public void friedchicken(NetUser netuser, string x, int bl)
        {
           
                int count = 0;
                int newcount = (bl + 20);
                var serp = Getplayerdatastore(x);
                foreach (KeyValuePair<string, object> pair in serp)
                {

                    count++;
                    int count3 = count;
                    if (count >= newcount)
                        break;
                    if (count >= newcount)
                        return;
                    rust.SendChatMessage(netuser, SystemName, "Value " + pair.Value.ToString() + " Key " + pair.Key.ToString());
                }
            
        }
        [ChatCommand("test")]
        void cmdChatProdwholooted(NetUser netuser, string command, string[] args)
        {
            
                var ID = netuser.userID.ToString();
                if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }
                if (args.Length != 1)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Informe o nickname de um jogador.");
                    return;
                }
                NetUser targetuser = FindTargetPlayer(args[0]);
                if (targetuser == null)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel encontrar este jogador.");
                    return;
                }
                if (targetuser == netuser)
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não pode enviar a si mesmo para o teste.");
                    return;
                }

                if (!netuser.CanAdmin())
                {
                    if (!Dono(netuser))
                    {
                        if (Dono(targetuser))
                        {
                            rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para reportar um administrador.");
                            return;
                        }

                        if (!SubDono(netuser))
                        {
                            if (SubDono(targetuser))
                            {
                                rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para reportar um administrador.");
                                return;
                            }
                            if (Admin(targetuser))
                            {
                                rust.SendChatMessage(netuser, SystemName, "[color yellow]Você não tem permissão para reportar um administrador.");
                                return;
                            }
                        }
                    }
                }

                var steamid = targetuser.playerClient.userID.ToString();
                var newdata = GetPlayeinfo(targetuser.playerClient.userID.ToString());

                if (testando.Contains(steamid))
                {
                    rust.SendChatMessage(netuser, SystemName, "[color yellow]Este jogador já está sendo testado no momento.");
                    return;
                }

                if (targetuser.playerClient.controllable == null || targetuser.playerClient.controllable.health <= 0)
                {
                    if (!NetUsers5.ContainsKey(targetuser))
                        NetUsers5.Add(targetuser, netuser);
                    AdminCompanionBroadcastplayerr("[color yellow]" + netuser.displayName + " [color white]enviou o jogador [color red]" + targetuser.displayName + " [color white]para o teste.");
                    targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                    testando.Add(steamid);
                    return;
                }
                //.Log("2");

                AdminCompanionBroadcastplayerr("[color yellow]" + netuser.displayName + " [color white]enviou o jogador [color red]" + targetuser.displayName + " [color white]para o teste.");
                rust.Notice(targetuser, "Você foi enviado para o teste AntiHack.");
                targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                testando.Add(steamid);
                //targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                if (phandler == null)
                    ConsoleSystem.Run("oxide.reload AdminCompanion");
                timer.Once(0.3f, () => phandler.StartCheck());
                //.Log("3");
                //.Log("4");
           
        }

        public bool namehasbeenbannedalready(string name)
        {
            
                var bannedusers = bannedUsers.GetValue(null);
                MethodInfo Enumerator = bannedusers.GetType().GetMethod("GetEnumerator");
                var myEnum = Enumerator.Invoke(bannedusers, new object[0]);
                MethodInfo MoveNext = myEnum.GetType().GetMethod("MoveNext");
                MethodInfo GetCurrent = myEnum.GetType().GetMethod("get_Current");
                string unbantarget = string.Empty;
                string unbanname = string.Empty;
                while ((bool)MoveNext.Invoke(myEnum, new object[0]))
                {
                    var bannedUser = GetCurrent.Invoke(myEnum, new object[0]);
                    if (name == steamid.GetValue(bannedUser).ToString() || name == username.GetValue(bannedUser).ToString())
                    {
                        unbantarget = steamid.GetValue(bannedUser).ToString();
                        unbanname = username.GetValue(bannedUser).ToString();
                        return true;
                    }
                }
            return false;
        }
        void forceenddettection(NetUser netuser)
        {

        }
        bool ShouldKick(NetUser netuser, string Name)
        {
            if (hasAccess(netuser, "AdminCompanion.adminname"))
                return false;
            foreach (KeyValuePair<string, string> pair in BadNameKick)
            {
                if (Name.ToLower().Contains(pair.Key.ToLower()))
                {
                    Debug.Log(Name + " connectou com nome inadequando e foi kickado");
                    if (pair.Value.Length > 1)
                        rust.SendChatMessage(netuser, SystemName, pair.Value);
                    return true;
                }
            }
            return false;

        }
        void OnPlayerConnected(NetUser netuser)
        {
            
                var ID = netuser.userID.ToString();
                if (!testado.Contains(ID))
                {
                    ConsoleSystem.Run("revoke user " + ID + " verificado_chat");
                }

                if (antiCeilingHack)
                    netuser.playerClient.gameObject.AddComponent<CeilingHackHandler>();

                if (Tempo.ContainsKey(netuser.playerClient.userID.ToString()))
                {
                    Tempo.Remove(netuser.playerClient.userID.ToString());
                    return;
                }

                if (management2 == null || Data == null)
                {
                    LoadData();
                    if (Data == null)
                    {
                        ConsoleSystem.Run("oxide.reload AdminCompanion", false);
                        return;
                    }
                    //OnServerInitialized();
                    //Started = true;
                    //

                }
           
        }
        void helpercheck(PlayerClient player)
        {
           
                Debug.Log(player.controllable.npcName);
           
        }
        public static void CreateEntity(CompanionCheck player, NetUser netuser, bool Checking = false)
        {
           
                Debug.Log(netuser.playerClient.transform.rotation);
                float toadd = 50f;
                if (Checking)
                {
                    toadd = 0f;
                    PasteBuilding(netuser.playerClient.lastKnownPosition, netuser.playerClient.transform.rotation, netuser.playerClient.transform.position, netuser.playerClient.transform.rotation.x, 1f, netuser, player);
                    return;
                }
                Vector3 NewLoc = new Vector3(netuser.playerClient.transform.position.x, netuser.playerClient.transform.position.y + toadd, netuser.playerClient.transform.position.z);
                PasteBuilding(netuser.playerClient.lastKnownPosition, netuser.playerClient.transform.rotation, NewLoc, netuser.playerClient.transform.rotation.x, 1f, netuser, player);
           
        }
        Vector3 VectorDown5 = new Vector3(0f, -0.4f, 0f);
        public static void PasteBuilding(Vector3 OriginalLoc, UnityEngine.Quaternion OrinalQuaternion, Vector3 targetPoint, float targetRot, float heightAdjustment, NetUser netuser, CompanionCheck player)
        {
            
                Vector3 OriginRotation = new Vector3(0f, targetRot, 0f);
                UnityEngine.Quaternion OriginRot = UnityEngine.Quaternion.EulerRotation(OriginRotation);
                StructureMaster themaster = null;
                if (netuser != null)
                {

                    string prefabname = ";struct_metal_ceiling";
                    UnityEngine.Quaternion newAngles = UnityEngine.Quaternion.EulerRotation((new Vector3(OrinalQuaternion.x, OrinalQuaternion.y, OrinalQuaternion.z)) + OriginRotation);
                    Vector3 TempPos = OriginRot * OriginalLoc;
                    Vector3 NewPos = TempPos + targetPoint;
                    if (themaster == null)
                    {
                        themaster = NetCull.InstantiateClassic<StructureMaster>(Facepunch.Bundling.Load<StructureMaster>("content/structures/StructureMasterPrefab"), NewPos, newAngles, 0);
                        themaster.SetupCreator(netuser.playerClient.controllable);
                    }
                    StructureComponent block = SpawnStructure(prefabname, NewPos, newAngles);
                    if (block != null)
                    {
                        themaster.AddStructureComponent(block);
                        player.PlayerEntity = block.gameObject;
                        player.CurrentCVector = NewPos;
                        block.GetComponent<TakeDamage>().SetGodMode(true);
                        CompanionCheck phandler = netuser.playerClient.GetComponent<CompanionCheck>();
                        if (phandler != null)
                        {
                            phandler.Block = block;
                        }

                    }
                }
            

        }
        public static Facepunch.MeshBatch.MeshBatchInstance ok(Vector3 Location)
        {
            Vector3 tryobject = new Vector3(0f, -5.2f, 0f);
            Vector3 tryobject2 = new Vector3(0f, 1.20f, 0f);
            Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance2 = null;
            if (!MeshBatchPhysics.Raycast(Location + tryobject, tryobject2, out cachedRaycast, out cachedBoolean, out cachedhitInstance2))
            {
                return cachedhitInstance2;
            }
            return cachedhitInstance2;
        }
        public static bool HasOBJ(Vector3 pos, bool CeilingCheck = true)
        {
            RaycastHit cachedRaycastt;
            if (!MeshBatchPhysics.Raycast(pos + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
            {
                Debug.Log(cachedRaycast + " " + cachedhitInstance);
                var raycastid2 = cachedRaycast.collider.gameObject.transform.position;
                Debug.Log(raycastid2);
                if (raycastid2 == null)
                    return false;
                if (!MeshBatchPhysics.Raycast(raycastid2 + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
                    return false;
            }
            Facepunch.MeshBatch.MeshBatchInstance cachedhitInstance2;
            bool cachedBoolean2;
            if (cachedhitInstance == null)
            {
                var raycastid = cachedRaycast.collider.gameObject.transform.position;
                cachedhitInstance = ok(raycastid);
                Debug.Log(cachedhitInstance);
                if (cachedhitInstance == null)
                {
                    return false;

                }



            }
            Debug.Log(cachedhitInstance);
            return false;
            if (CeilingCheck)
                if (!cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.ToLower().Contains("ceiling"))
                {
                    var raycastid2 = cachedRaycast.collider.gameObject.transform.position;
                    if (raycastid2 == null)
                        return false;
                    if (!MeshBatchPhysics.Raycast(raycastid2 + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
                        return false;
                    if (CeilingCheck)
                    {
                        if (!cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.ToLower().Contains("ceiling"))
                        {
                            return false;
                        }
                    }
                }
                else if (!cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.ToLower().Contains("ceiling"))
                {
                    var raycastid = cachedRaycast.collider.gameObject.transform.position;
                    if (raycastid == null)
                        return false;
                    if (!MeshBatchPhysics.Raycast(raycastid + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
                        return false;
                    if (CeilingCheck)
                    {
                        if (!cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.ToLower().Contains("ceiling"))
                        {
                            return false;
                        }
                    }
                }
            return true;
        }

        public static void CheckAspect(CompanionCheck player)
        {
           
                NetUser netuser = player.playerclient.netUser;
                string BeingReplaced = ReceiveDictionaries(player);
                string Convert = ReceiveDictionaries2(player);
                if (player.TestDictionaries.Count / 2 == DefaultKeys.Count || Convert == "FinishedTest")
                {
                    player.AspectCheck = true;
                    undofixplayerhp(player);
                    return;
                }

                if (!player.playerclient.controllable.stateFlags.grounded)
                    return;
                if (player.playerclient.controllable.stateFlags.lostFocus)
                {
                    Resettestt(player.playerclient, Convert);
                }

                if (!player.HasCreatedEntity)
                {
                    bool ADDVariables = false;
                    if (player.WhentUp > 0)
                    {
                        //player.FirstUP++;
                        ADDVariables = true;
                    }

                    CreateEntity(player, player.playerclient.netUser, ADDVariables);
                    player.HasCreatedEntity = true;
                }
                if (player.WhentUp < int.Parse(NumberOfWhentupsTTillPass.ToString()))
                {
                    TeleportToPos2(netuser, player.PlayerEntity.transform.position.x, player.PlayerEntity.transform.position.y + 5f, player.PlayerEntity.transform.position.z);
                    //player.WhentUp = true;
                    player.WhentUp++;
                    //player.HasCreatedEntity = false;
                    return;

                }
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.bind Down " + Convert + " " + Convert);
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.bind Jump " + "None" + " " + "None");
                //Debug.Log(Convert);
                if (player.playerclient.controllable.stateFlags.grounded)
                    if (!player.HasGotMyCeiling)
                    {
                        var distance = player.PlayerEntity.transform.position.y - player.playerclient.lastKnownPosition.y;
                        Debug.Log(distance + " - " + player.PlayerEntity.transform.position.y + " " + player.playerclient.lastKnownPosition.y);
                        float Distance = Vector3.Distance(player.PlayerEntity.transform.position, player.playerclient.lastKnownPosition);
                        if (Distance > 10 && player.PlayerEntity.transform.position.y > player.playerclient.lastKnownPosition.y + 8f && player.playerclient.controllable.stateFlags.grounded)
                        {
                            if (!player.FirstFallDetection)
                            {
                                player.FirstFallDetection = true;
                                return;
                            }
                            AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]Test[color red] )");
                            Aspect2(player);
                            BanPlayer(player.playerclient.netUser, player.IP, "-    (Aspect-Hack)    -");
                            NumberOfAspectDetections++;
                            return;
                        }
                        else
                            player.HasGotMyCeiling = true;
                        /*if (MeshBatchPhysics.Raycast(player.playerclient.lastKnownPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
                        {
                            if(cachedRaycast.collider.gameObject.name.ToLower().Contains("terrain")){
                                if(!player.FirstTerrainDetect)
                                {
                                    player.FirstTerrainDetect = true;
                                    return;
                                }
                                AdminCompanionBroadcastplayer(player.playerclient.userName + " Has been banned for using cheats Level(3.0)");
                                BanPlayer(player.playerclient.netUser,player.playerclient.userID.ToString(), player.playerclient.userName, "Aspect Hack-method " + cachedRaycast.collider.gameObject.name);
                                NumberOfAspectDetections++;
                                return;
                            }
                            else if (MeshBatchPhysics.Raycast(cachedRaycast.collider.gameObject.transform.position + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
                            {

                                    if(cachedRaycast2.collider.gameObject.name.ToLower().Contains("terrain")){

                                        if(!player.FirstTerrainDetect)
                                         {
                                             player.FirstTerrainDetect = true;
                                             return;
                                         }
                                        AdminCompanionBroadcastplayer(player.playerclient.userName + " Has been banned for using cheats Level(3.0)");
                                        BanPlayer(player.playerclient.netUser,player.playerclient.userID.ToString(), player.playerclient.userName, "Aspect Hack-method " + cachedRaycast2.collider.gameObject.name);
                                        GameObject.Destroy(player);
                                        NumberOfAspectDetections++;
                                        return;
                                    }
                                    else
                                    {
                                        player.HasGotMyCeiling = true;
                                        return;
                                    }
                            }
                            else
                            {
                                player.HasGotMyCeiling = true;
                                return;
                            }

                        }*/
                    }
                /*if(player.PlayerEntity.transform.position.y  > player.playerclient.transform.position.y && !player.NoLongerChecking && player.playerclient.controllable.stateFlags.grounded)
                {
                    BanPlayer(player.playerclient.netUser,player.playerclient.userID.ToString(), player.playerclient.userName, "Aspect Hack-method " + player.PlayerEntity.transform.position.y );
                }*/
                if (player.distance3D == 0)
                {
                    var language = Getplayerdatastore(player.language);
                    if (!language.ContainsKey("F2testmsg"))
                        return;


                    var holdf2msg = language["F2testmsg"].ToString();
                    if (!holdf2msg.Contains("F2"))
                        if (language.ContainsKey("F2TestTurk"))
                            holdf2msg = language["F2TestTurk"].ToString();
                        else
                        {
                            holdf2msg = "[color#A9A9A9]Pressione e segure[color white]﹣  " + "[color cyan]F2";

                        }
                    int pFrom = holdf2msg.IndexOf("F2");
                    var result2 = holdf2msg.Remove(pFrom, 2);
                    var AspectMessage = result2.Insert(pFrom, BeingReplaced);
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + AspectMessage.ToString() + "\"");
                    if (!player.playerclient.controllable.stateFlags.grounded)
                    {
                        if (!player.firstdetectionsaspect)
                        {
                            player.firstdetectionsaspect = true;
                            return;
                        }
                        AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]Test[color red] )");
                        Aspect2(player);
                        BanPlayer(player.playerclient.netUser, player.IP, "-    (Aspect-Hack)    -");
                        NumberOfAspectDetections++;
                        return;
                    }

                }
                else
                {
                    player.NoLongerChecking = true;
                }
                if (!MeshBatchPhysics.Raycast(player.playerclient.lastKnownPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { return; }
                var objectname = cachedRaycast.collider.gameObject.name;
                if (objectname.ToLower() == "terrain" && player.playerclient.controllable.stateFlags.grounded)
                {
                    if (player.TestDictionaries.Count / 2 == DefaultKeys.Count || Convert == "FinishedTest")
                    {
                        player.AspectCheck = true;
                        undofixplayerhp(player);
                        Resettestt(player.playerclient, "Meta Null");
                    }
                    else
                    {
                        player.firstdetectionsaspect = false;
                        player.NoLongerChecking = false;
                        player.HasCreatedEntity = false;
                        player.WhentUp = 0;
                        player.FirstFallDetection = false;
                        player.HasGotMyCeiling = false;
                        if (!player.TestDictionaries.ContainsKey(Convert))
                            player.TestDictionaries.Add(Convert, BeingReplaced);
                        if (!player.TestDictionaries.ContainsKey(BeingReplaced))
                            player.TestDictionaries.Add(BeingReplaced, Convert);
                    }
                    return;
                }


            
        }

        public static StructureComponent SpawnStructure(string prefab, Vector3 pos, UnityEngine.Quaternion angle)
        {
            StructureComponent build = NetCull.InstantiateStatic(prefab, pos, angle).GetComponent<StructureComponent>();
            if (build == null) return null;
            return build;
        }
        public static void UnGod(PlayerClient player)
        {
            
                player.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
           
        }
        public static RaycastHit SearchForFloor(PlayerClient player, float DistanceDown = -5f)
        {
            RaycastHit Hit;
            Facepunch.MeshBatch.MeshBatchInstance Instance = null;
            Vector3 Down = new Vector3(player.lastKnownPosition.x, player.lastKnownPosition.y + DistanceDown, player.lastKnownPosition.z);
            Vector3 ModDown = new Vector3(player.lastKnownPosition.x, player.lastKnownPosition.y - 1.2f, player.lastKnownPosition.z);
            if (Physics.Linecast(ModDown, Down, out Hit))
            {
            }
            return Hit;
        }

        public class CompanionCheck2 : UnityEngine.MonoBehaviour
        {
            public string normstring;
            public int inttimetally;
            public int numberoffakecalls;

            public int savedweaponnumber;
            public bool hasgotengivenitem;
            public bool detectionended;
            public bool hasrefreshedinventorysettings;
            public bool secoonddetect;
            public bool thrddetect;
            public float fallcount;
            public float n;
            public bool FirstSpeedJumpDetection = false;
            public float s;
            public float h;
            public float nr;
            public Vector3 point;
            public bool hasdoneheal;
            public GameObject Load;
            public float lasty2;
            public float lastjump;
            public double playerjumpspeed = 0.0;
            public string laststring2 = "F2";
            public string language;
            public bool wasinmenu;
            public bool diddolastjump;
            public bool isinjumptest;
            public bool playerhaslang2;
            public bool hasselectedlanguage;
            public bool finishedspeedjumpptest;
            public float timeleft;
            public float lastTick;
            public float currentTick;
            public float deltaTime;
            public float component2distance;
            public Component componenthit2;
            public Vector3 lastPosition;
            public Vector3 headlocation2;
            public BulletWeaponDataBlock lastbulletitem;
            public float headlocation3;
            public float headlocationangle2;
            public float headlocationangle1;
            public float checkrotaionx;
            public float totaleularanglesCompanionCheck;
            public Vector3 lastPosition2;
            public PlayerClient playerclient;
            public Character character;
            public float LowestValue = 99999999999999999999999999f;
            public Inventory inventory;
            public string userid;
            public float distance3D;
            public float distance3D2;
            public float distanceHeight;
            public bool finishedstevencheck;
            public bool finishedjackedcheck;
            public bool finisheddizzycheck;
            public bool firstcheckstate;
            public int count;
            public int wasinmenucount;
            public float currentFloorHeight;
            public bool hasSearchedForFloor = false;
            public float lastSpeed = UnityEngine.Time.realtimeSinceStartup;
            public int speednum = 0;
            public bool firstdetect = false;

            public float lastWalkSpeed = UnityEngine.Time.realtimeSinceStartup;
            public int walkspeednum = 0;
            public bool lastSprint = false;

            public float lastJump = UnityEngine.Time.realtimeSinceStartup;
            public int jumpnum = 0;


            public float lastFly = UnityEngine.Time.realtimeSinceStartup;
            public int flynum = 0;

            public int noRecoilDetections = 0;
            public int noRecoilKills = 0;

            public float lastWoodCount = 0;

            void Awake()
            {
                
                    lastTick = UnityEngine.Time.realtimeSinceStartup;
                    enabled = false;
               
            }
            public void StartCheck()
            {
               
                    this.playerclient = GetComponent<PlayerClient>();
                    if (playerclient == null)
                        GameObject.Destroy(this);
                    if (playerclient.netUser == null)
                        GameObject.Destroy(this);
                    this.userid = this.playerclient.userID.ToString();
                    if (playerclient.controllable == null) return;
                    this.character = playerclient.controllable.GetComponent<Character>();
                    this.lastPosition = this.playerclient.lastKnownPosition;
                    enabled = true;
                    Debug.Log("Got data");
                    FixedUpdate();
               
            }
            void FixedUpdate()
            {
               
                    if (this == null || playerclient == null || playerclient.netUser == null || this.playerclient.controllable == null)
                    {
                        return;
                    }


                    if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 0.00000000000000000000000000000001)
                    {

                        checkplayer2(this);
                        currentTick = UnityEngine.Time.realtimeSinceStartup;
                        deltaTime = currentTick - lastTick;
                        distance3D = Vector3.Distance(playerclient.lastKnownPosition, lastPosition);
                        distanceHeight = (playerclient.lastKnownPosition.y - lastPosition.y) / deltaTime;

                        lastPosition = playerclient.lastKnownPosition;
                        lastTick = currentTick;
                        this.hasSearchedForFloor = false;
                    }
                
            }
            public static void checkplayer2(CompanionCheck2 player)
            {
               
                    if (player.playerclient.controllable == null)
                        return;
                    var distance3D = player.distance3D;
                    if (player.playerclient.controllable.stateFlags.grounded)
                        if (player.playerclient.controllable.stateFlags.lostFocus)
                        {
                            if (player.character.stateFlags.sprint)
                            {

                                return;
                            }
                            if (!player.character.stateFlags.movement)
                            {

                            }
                            if (distance3D >= 0.3119704)
                                return;
                            if (distance3D != null)
                            {
                                if (distance3D < 0.1102388)
                                    return;
                                if (distance3D == 0)
                                    return;
                                else
                                {

                                    AdminCompanionBroadcastplayerr(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]HackMenu-Test[color red] )");
                                    Aspect3(player);
                                    CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                                    if (phandler == null) { phandler = player.playerclient.gameObject.AddComponent<CompanionCheck>(); player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true); }
                                    phandler.StartCheck();
                                    var hascheckedd3menu = GetPlayerdata("smartchecked(Menu)");
                                    if (!hascheckedd3menu.ContainsKey(player.playerclient.userID.ToString()))
                                        hascheckedd3menu.Add(player.playerclient.userID.ToString(), true);
                                    GameObject.Destroy(player);
                                    return;
                                    //BanPlayer(player.playerclient.netUser,player.IP, "AntiHackMenu");
                                    return;
                                }
                            }

                            return;

                        }
                    if (player.firstdetect)
                    {
                        if (distance3D != 0)
                        {
                            player.firstdetect = false;
                        }
                    }
                
            }

        }

        public static bool shouldcheckhackmenuLog = false;
        void OnPlayerSpawn(PlayerClient player, bool useCamp, RustProto.Avatar avatar)
        {
            

                if (hasPermission(player.netUser)) return;
                PlayerHandler phandlera = player.GetComponent<PlayerHandler>();
                if (phandlera == null) { phandlera = player.gameObject.AddComponent<PlayerHandler>(); phandlera.timeleft = GetPlayerData(player); }
                timer.Once(0.1f, () =>
                {
                    
                        phandlera.StartCheck();
                    
                });

                var hascheckedd = GetPlayerdata("smartchecked(pl)");
                var Tester = GetPlayerdata("SuspectPlayersTested(log.pl)");
                var BadNameDataStore = GetPlayerdata("SuspectNames(log.pl)");

                if (BadNameDataStore.ContainsKey(player.userID.ToString()))
                {
                    if (ShouldOnlyCheckPlayerWithBadNameOnce)
                    {
                        if (!Tester.ContainsKey(player.userID.ToString()))
                        {
                            Tester.Add(player.userID.ToString(), player.userName);
                            BadNameDataStore.Remove(player.userID.ToString());
                            CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                            if (phandler == null) { AdminCompanionpublicbroadcast(player.userName + " Conectado com um nome incorreto como resultado um teste será exigido"); phandler = player.gameObject.AddComponent<CompanionCheck>(); timer.Once(0.69f, () => phandler.StartCheck()); }

                        }
                    }
                    else
                    {
                        BadNameDataStore.Remove(player.userID.ToString());
                        CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                        if (phandler == null) { phandler = player.gameObject.AddComponent<CompanionCheck>(); timer.Once(0.69f, () => phandler.StartCheck()); }
                    }
                }

                if (hascheckedd == null)
                {
                    ConsoleSystem.Run("oxide.reload AdminCompanion", false);
                    return;
                }
                if (NetUsers5.ContainsKey(player.netUser))
                {
                    CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = player.gameObject.AddComponent<CompanionCheck>(); timer.Once(0.69f, () => phandler.StartCheck()); }
                    NetUsers5.Remove(player.netUser);
                    return;
                }
                if (smartcheck)
                {

                    var hascheckeddd = GetPlayerdata("smartchecked(log.pl)");
                    var hascheckedd3menu = GetPlayerdata("smartchecked(Menu)");
                    if (shouldcheckhackmenuLog)
                        if (!hascheckedd3menu.ContainsKey(player.userID.ToString()))
                        {
                            CompanionCheck2 phandler = player.GetComponent<CompanionCheck2>();
                            if (phandler == null) { phandler = player.gameObject.AddComponent<CompanionCheck2>(); timer.Once(0.69f, () => phandler.StartCheck()); }
                        }
                    if (!hascheckeddd.ContainsKey(player.userID.ToString()))
                        if (hascheckedd.ContainsKey(player.userID.ToString()))
                        {

                            CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                            if (phandler == null) { phandler = player.gameObject.AddComponent<CompanionCheck>(); timer.Once(0.69f, () => phandler.StartCheck()); }

                            if (!hascheckeddd.ContainsKey(player.userID.ToString()))
                                hascheckeddd.Add(player.userID.ToString(), true);
                            return;
                        }
                }
                if (!shouldcheckplayeroncewhenconnect)
                    return;
                var haschecked = GetPlayerdata("hasscheckedAuto(pl)");
                if (!haschecked.ContainsKey(player.userID.ToString()))
                    if (shouldcheckplayeroncewhenconnect)
                    {
                        CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                        if (phandler == null) { phandler = player.gameObject.AddComponent<CompanionCheck>(); }
                        timer.Once(0.3f, () => phandler.StartCheck());

                        if (!haschecked.ContainsKey(player.userID.ToString()))
                            haschecked.Add(player.userID.ToString(), true);
                        return;
                    }
                var firstpass = GetPlayerdata("firstpass");
                if (firstpass.ContainsKey(player.userID.ToString()))
                    if (!shouldcheckplayeroncewhenconnect)
                        if (firstpass.ContainsKey(player.userID.ToString()))
                        {
                            CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                            if (phandler == null) { phandler = player.gameObject.AddComponent<CompanionCheck>(); }
                            timer.Once(0.3f, () => phandler.StartCheck());
                            firstpass.Remove(player.userID.ToString());
                            return;
                        }
                return;
            
        }
        public static void AdminCompanionpublicbroadcast(string message)
        {
   
                var hasacess = GetPlayerdata("Flags(pl)");
                foreach (PlayerClient player in PlayerClient.All)
                {
                    if (player.netUser.CanAdmin() || hasacess.ContainsKey(player.userID.ToString()))
                        ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Server \"" + message + "\"");
                }
           
        }

        static void AdminCompanionBroadcastplayer(string message)
        {
            
                foreach (PlayerClient player in PlayerClient.All)
                {
                    ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Server \"" + message + "\"");
                }
            
        }
        public static void AdminCompanionBroadcastplayerr(string message)
        {
            
                foreach (PlayerClient player in PlayerClient.All)
                {
                    ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Server \"" + message + "\"");
                }
            
        }
        public static void CheckGameObject()
        {
           
                if (Data == null)
                    ConsoleSystem.Run("oxide.reload AdminCompanion");
           
        }
        static void tpback(CompanionCheck player)
        {
            
                ConsoleNetworker.SendClientCommand(player.playerclient.netUser.networkPlayer, "config.load");
                {
                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                }
                NetUser netuser = player.playerclient.netUser;
                if (!player.hastpbackfirst)
                {
                    TeleportToPos2(netuser, player.firstx1, player.firsty1, player.firstz1);
                    player.hastpbackfirst = true;
                    return;
                }
                if (!player.hastpbacksecond)
                {
                    TeleportToPos2(netuser, player.firstx1, player.firsty1, player.firstz1);
                    STimer.Once(10.00f, () =>
                    {
                        
                            player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                        
                        });
                    player.hastpbacksecond = true;
                    returnsettings(player.playerclient.netUser);
                    //GodCharacter compadd = player.playerclient.gameObject.AddComponent(GodCharacter);
                    //compadd.StartCheck();
                    GameObject.Destroy(player);
                }
            
        }
        public static void DoReturnSetttings(PlayerClient player)
        {
            
                ConsoleNetworker.SendClientCommand(player.netPlayer, "config.load");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "config.save");
           
        }
        static void EndDetection(CompanionCheck player)
        {
           
                if (player.Block != null)
                {
                    player.Block.GetComponent<TakeDamage>().SetGodMode(false);
                    TakeDamage.KillSelf(player.Block);
                    player.Block = null;
                }
                returnallsetting(player);
                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                NetUser netuser = player.playerclient.netUser;
                var SteamId = netuser.playerClient.userID.ToString();
                DoReturnSetttings(player.playerclient);
                testando.Remove(SteamId);
                STimer.Once(0.32f, () =>
                {
                   
                        DoReturnSetttings(player.playerclient);
                   
                    });

                if (player.hasloc2)
                    tpback(player);
           
        }
        void Endflagcheck(CompanionCheckflagcheck player)
        {
            
                GameObject.Destroy(player);
            
        }
        static void Resettest(CompanionCheck player)
        {
           
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.bind Up F2 F2");
            
        }
        static void removeui(CompanionCheck player)
        {
            
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "gameui.hide");
            
        }
        static void Resettestt(PlayerClient player, string lastcheckstring)
        {
            
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Down " + lastcheckstring + " " + lastcheckstring);
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Left " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Right " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Up " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Duck " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Jump " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Fire " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Inventory " + "None" + " " + "None");
           
        }
        static void Resettestt2(PlayerClient player, string lastcheckstring)
        {
            
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Down " + lastcheckstring + " " + lastcheckstring);
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Left " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Right " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Up " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Duck " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Fire " + "None" + " " + "None");
                ConsoleNetworker.SendClientCommand(player.netPlayer, "input.bind Inventory " + "None" + " " + "None");
           
        }
        public static Oxide.Game.RustLegacy.Libraries.RustLegacy srust = GetLibrary<Oxide.Game.RustLegacy.Libraries.RustLegacy>();
        public static void checkplayer(CompanionCheck player)
        {
           
                if (UnityEngine.Time.realtimeSinceStartup - player.LastTick2 >= 1)
                    player.h++;
                if (UnityEngine.Time.realtimeSinceStartup - player.LastTick2 >= 1)
                {
                    player.LastTick2 = UnityEngine.Time.realtimeSinceStartup;
                    player.CanSendMessage = true;
                }
                var distance3d3 = Math.Floor(Vector3.Distance(player.playerclient.lastKnownPosition, player.lastPosition));
                if (player.HackMenuNextEvent)
                {

                    if (distance3d3 > 0)
                    {
                        Debug.Log("hack detectado " + player.playerclient.userName + " moveu " + distance3d3 + " m/s");
                        player.HackMenuDetections++;
                        player.HackMenuNextEvent = false;
                        return;
                    }
                    else
                        player.HackMenuNextEvent = false;
                }

                string BeingReplaced = ReceiveDictionaries(player, true);
                string Convert = ReceiveDictionaries2(player, true);
                if (!shouldcheckhackmenu)
                {

                    AdminCompanionBroadcastplayer(player.playerclient.userName + " Foi eliminado deste plug-in");
                    undofixplayerhp(player);
                    returnsettings(player.playerclient.netUser);
                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                    EndDetection(player);
                    return;
                }
                var crouchjumpexploitdetection = player.playerclient.controllable.stateFlags.flags;

                if (shouldbanforidle)
                    if (player.h >= int.Parse(idletimetillban.ToString()))
                    {
                        if (shoulddoipban)
                            ipban(player, "-    (Ociosidade durante o teste)    -");
                        player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                        Afk(player);
                        AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]Afk-Test[color red] )");
                        BanPlayer(player.playerclient.netUser, player.IP, "-    (Ociosidade durante o teste)    -");
                        return;
                    }

                if (player.didteleport)
                {
                    Resettestt(player.playerclient, Convert);
                    if (player.playertestdelaycount <= 1)
                    {

                        player.playertestdelaycount++;
                        return;
                    }
                    player.didteleport = false;
                    return;
                }
                var check = player.playerclient.controllable.stateFlags.flags;
                if (!player.playerclient.controllable.stateFlags.grounded)
                    return;
                if (check == null)
                    return;
                if (player.count <= 2)
                {
                    player.count++;
                    Resettestt(player.playerclient, Convert);
                    return;
                }

                NetUser netuser = player.playerclient.netUser;
                var pitch = player.playerclient.controllable.eyesPitch;
                var datastore2 = Getplayerdatastore("AdminCompanion(Lang.Log)");
                if (!player.playerhaslang2)
                    return;


                if (!player.hasresettest)
                {
                    Resettestt(player.playerclient, Convert);
                    player.hasresettest = true;
                    return;
                }
                var language = Getplayerdatastore(player.language);
                var location1 = player.playerclient.lastKnownPosition;
                var distance3D = player.distance3D;

                if (!language.ContainsKey("F2testmsg"))
                {
                }

                if (!language.ContainsKey("donotdcmessage"))
                {
                }


                string holdf2msg = "[color#A9A9A9]Pressione e segure[color white]﹣  [color cyan]F2";
                if (language.ContainsKey("F2testmsg"))
                    holdf2msg = language["F2testmsg"].ToString();
                if (!holdf2msg.Contains("F2"))
                    if (language.ContainsKey("F2TestTurk"))
                        holdf2msg = language["F2TestTurk"].ToString();
                if (!holdf2msg.Contains("F2"))
                    holdf2msg = "[color#A9A9A9]Pressione e segure[color white]﹣  [color cyan]F2";
                int pFrom = holdf2msg.IndexOf("F2");
                var result2 = holdf2msg.Remove(pFrom, 2);
                var inserttest = result2.Insert(pFrom, "ins/insert");
                var stevencheck = result2.Insert(pFrom, "F5");
                var disconnectmsg = language["donotdcmessage"].ToString();
                var completedmsg = language["Completedmsg"].ToString();
                holdf2msg = result2.Insert(pFrom, BeingReplaced);
                Resettestt(player.playerclient, Convert);
                if (player.MenuDictionaries.Count / 2 >= DefaultKeys.Count || Convert == "FinishedTest")
                {
                    var location2 = player.lastPosition;
                    var ID = netuser.userID.ToString();

                    player.laststring2 = "insert";
                    player.finisheddizzycheck = true;
                    player.hasresettest = false;
                    player.h = 0f;
                    player.count++;

                    int _timeinterval = timereport2;
                    if (hasAccess5(netuser))
                        _timeinterval = 43200;
                    else if (hasAccess6(netuser))
                        _timeinterval = 28800;
                    else if (hasAccess7(netuser))
                        _timeinterval = 14400;
                    else
                        _timeinterval = timereport2;

                    if (!player.hassentmessages)
                    {
                        if (testando.Contains(ID))
                        {
                            testando.Remove(ID);
                        }
                        if (!testado.Contains(ID))
                        {

                            testado.Add(ID);
                            if (hasAccess5(netuser))
                            {
                                STimer.Once(_timeinterval, () =>
                                {
                                   
                                        testado.Remove(ID);
                                        ConsoleSystem.Run("revoke user " + ID + " verificado_chat");
                                   
                                });
                            }
                            else if (hasAccess6(netuser))
                            {
                                STimer.Once(_timeinterval, () =>
                                {
                                   
                                        testado.Remove(ID);
                                        ConsoleSystem.Run("revoke user " + ID + " verificado_chat");
                                   
                                });
                            }
                            else if (hasAccess7(netuser))
                            {
                                STimer.Once(_timeinterval, () =>
                                {
                                    
                                        testado.Remove(ID);
                                        ConsoleSystem.Run("revoke user " + ID + " verificado_chat");
                                    
                                });
                            }
                            else
                            {
                                STimer.Once(_timeinterval, () =>
                                {
                                   
                                        testado.Remove(ID);
                                        ConsoleSystem.Run("revoke user " + ID + " verificado_chat");
                                   
                                });
                                }
                        }
                            ConsoleSystem.Run("grant user " + ID + " verificado_chat");
                        AdminCompanionBroadcastplayer("[color #0077FF]" + player.playerclient.userName + " [color #DBDBDB]passou no teste com sucesso e ganhou a tag verificado.");
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "[color #DBDBDB]Obrigado pela sua cooperação [/color] \"");
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "notice.popup \"" + "✔ \"" + "✔ \"" + "Você tem 10 segundos de imortalidade \"");
                        STimer.Once(_timeinterval, () =>
                        {
                           
                                ConsoleSystem.Run("revoke user " + ID + " verificado_chat");
                           
                        });
                        player.hassentmessages = true;
                        return;
                    }
                    returnsettings(player.playerclient.netUser);
                    undofixplayerhp(player);
                    EndDetection(player);
                    return;
                }
                if (player.wasinmenu)
                {
                    player.wasinmenucount++;
                    if (player.wasinmenucount >= 3)
                    {
                        player.wasinmenu = false;
                        player.wasinmenucount = 0;
                    }
                    Resettestt(player.playerclient, Convert);
                }

                if (!player.finisheddizzycheck)
                {
                    player.laststring2 = "F2";
                    if (player.playerclient.controllable.stateFlags.lostFocus)
                    {
                        Resettestt(player.playerclient, Convert);
                    }

                    if (distance3D.ToString() == "0")
                    {
                        if (player.CanSendMessage)
                        {
                            ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + holdf2msg + "\"");
                            player.CanSendMessage = false;
                        }
                        return;
                    }
                    if (distance3D <= 2.77777)
                    {


                        if (player.playerclient.controllable.stateFlags.lostFocus)
                        {
                            player.HackMenuNextEvent = true;
                            if (player.HackMenuDetections >= 2)
                            {
                                if (shoulddoipban)
                                    ipban(player, "-    (HackMenu - Level 1)    -");
                                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]HackMenu-Test[color red] )");
                                Aspect(player);
                                BanPlayer(player.playerclient.netUser, player.IP, "-    (HackMenu - Level 1)    -");
                                numberofbansdizzy++;
                                player.enabled = false;
                                GameObject.Destroy(player);

                                return;
                            }
                            else
                                return;
                        }
                        if (distance3D.ToString().Contains("-"))
                        {
                            if (player.CanSendMessage)
                            {
                                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + holdf2msg + "\"");
                                player.CanSendMessage = false;
                            }
                            return;
                        }
                    }


                    if (distance3D <= 2.77777)
                        return;

                    if (!player.playerclient.controllable.stateFlags.movement)
                        return;
                    if (!player.MenuDictionaries.ContainsKey(Convert))
                        player.MenuDictionaries.Add(Convert, BeingReplaced);
                    if (!player.MenuDictionaries.ContainsKey(BeingReplaced))
                        player.MenuDictionaries.Add(BeingReplaced, Convert);
                    //Debug.Log("At State 1");				
                    if (player.MenuDictionaries.Count / 2 >= DefaultKeys.Count || Convert == "FinishedTest")
                    { }
                    else
                    {
                        player.count = 0;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "[color yellow]Verificando os dados do PlayerClient..." + "\"");
                        return;
                    }
                    var location2 = player.lastPosition;

                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "[color yellow]Verificando os dados do PlayerClient..." + "\"");
                    player.laststring2 = "insert";
                    player.finisheddizzycheck = true;
                    player.hasresettest = false;
                    player.h = 0f;
                    player.count++;

                    return;

                }

                if (!player.hassentmessages)
                {

                    AdminCompanionBroadcastplayer(player.playerclient.userName + " Foi cancelado com um total de " + player.HackMenuDetections + " detecções");
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "Obrigado pela compreenção " + player.playerclient.userName + "\"");
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + completedmsg + " " + player.playerclient.userName + "\"");
                    player.hassentmessages = true;
                    return;
                }
                returnsettings(player.playerclient.netUser);
                undofixplayerhp(player);
                EndDetection(player);
            

        }
        public static void clearalldata(CompanionCheck player)
        {
            
                DataStore[player.playerclient.userID.ToString()] = null;
           
        }
        public static object returnsettings(NetUser player)
        {
            
                ConsoleNetworker.SendClientCommand(player.networkPlayer, "config.load");
            
            return true;
        }
        public static bool hasplayerlanguage(CompanionCheck player)
        {
            
                var data = Getplayerdatastore("AdminCompanion(Lang.Log)");
                if (data.ContainsKey(player.playerclient.userID.ToString()))
                    return true;
            return false;
            
        }
        public static void returnallsetting(CompanionCheck playerr)
        {
            
                if (falldamageenabled)
                    return;
                if (!falldamageenabled)
                {
                    ConsoleSystem.Run("falldamage.enabled false", false);
                }
                return;
                foreach (PlayerClient player in PlayerClient.All)
                {
                    if (player.userID != playerr.playerclient.userID)
                    {
                        if (player.rootControllable == null)
                            return;
                        FallDamage falldamage = player.rootControllable.GetComponent<FallDamage>();
                        falldamage.enabled = false;
                    }
                }
            
        }
        public static void dosettings(CompanionCheck playerr)
        {
            
                ConsoleSystem.Run("falldamage.enabled true", false);
                if (falldamageenabled)
                    return;
                return;
                foreach (PlayerClient player in PlayerClient.All)
                {
                    if (player.userID != playerr.playerclient.userID)
                    {
                        if (player.rootControllable == null)
                            return;
                        FallDamage falldamage = player.rootControllable.GetComponent<FallDamage>();
                        falldamage.enabled = false;
                    }
                }
           
        }
        public static void hassetfallimpact(CompanionCheck playerr)
        {
            
                foreach (PlayerClient player in PlayerClient.All)
                {
                    if (player.userID != playerr.playerclient.userID)
                    {
                        FallDamage falldamage = player.rootControllable.GetComponent<FallDamage>();
                        falldamage.enabled = false;
                    }
                }
            
        }
        public static void setserversettings(CompanionCheck player)
        {

        }
        public static void Snappycheck(CompanionCheck player)
        {

        }
        public static void checkplayerjumpspeed(CompanionCheck player)
        {
            

                var crouchjumpexploitdetection = player.playerclient.controllable.stateFlags.flags;
                if (player.AwaitingGround)
                {
                    if (!player.playerclient.controllable.stateFlags.grounded)
                        return;
                    player.AwaitingGround = false;
                }
                if (!shouldcheckjumpspeed)
                {

                    player.passedjumptest = true;
                    return;
                }
                if (!player.hasressetjsettings)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "config.load");
                    Resettestt2(player.playerclient, player.laststring2);
                    player.hasressetjsettings = true;
                }

                if (!player.autolanguage)
                    if (!Issober2(player))
                    {
                        Debug.Log("Server: Deu ruim teste encerrado sem finalizar " + player.playerclient.userName.ToString());
                        EndDetection(player);
                        return;
                    }
                if (player.crouchdelayactivated)
                {
                    player.crouchdelay++;
                    if (player.crouchdelay >= 3f)
                    {
                        player.crouchdelay = 0f;
                        player.crouchdelayactivated = false;
                    }
                    player.didjump = true;
                    return;
                }
                var language = Getplayerdatastore(player.language);
                var jumptest = language["speedjumptestmsg"].ToString();
                if (crouchjumpexploitdetection == int.Parse(menuscreenflag.ToString()))
                {
                    player.messagetally8++;
                    if (player.messagetally8 > 75f)
                    {
                        player.messagetally8 = 0f;
                        Resettestt2(player.playerclient, player.laststring2);
                    }
                    return;
                }

                if (!language.ContainsKey("donotcrouchmsg"))
                {
                    return;
                }
                var crouchmsg = language["donotcrouchmsg"].ToString();
                if (crouchjumpexploitdetection == int.Parse(crouchdetetctionsecondflagcheck.ToString()) || crouchjumpexploitdetection == 6209)
                {
                    player.messagetally4++;
                    if (player.messagetally4 >= 15f)
                    {
                        player.messagetally4 = 0f;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + " " + crouchmsg + "\"");
                    }
                    player.crouchdelayactivated = true;
                    return;
                }

                if (player.messagetally == 0f)
                {
                    player.shouldsendmessagetally = true;
                }


                if (!language.ContainsKey("speedjumptestmsg"))
                {
                    return;
                }

                if (true)
                {

                    //if(player.didjump)

                    player.messagetally5++;
                    if (player.messagetally5 >= 60f)
                    {
                        player.messagetally5 = 0f;
                        player.s++;
                        if (shouldbanforidle)
                            if (player.s >= int.Parse(idletimetillban.ToString()))
                            {
                                if (shoulddoipban)
                                    ipban(player, "-    (Ociosidade durante o teste)    -");
                                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                Afk(player);
                                AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]Afk-Test[color red] )");
                                BanPlayer(player.playerclient.netUser, player.IP, "-    (Ociosidade durante o teste)    -");
                                return;
                            }
                    }
                    if (player.playerclient.controllable.stateFlags.grounded)
                    {
                        player.messagetally++;
                        if (player.messagetally >= 60f)
                        {

                            player.messagetally = 0f;
                            ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + " " + jumptest + "\"");
                        }
                        //if(!player.didjump){

                        //}
                        //return;
                    }
                    //Debug.Log("Air");
                    if (!player.AirBorn)
                    {
                        //Debug.Log("Not");
                        if (player.playerclient.controllable.stateFlags.grounded)
                        {
                            //Debug.Log("Yes  123123 " + player.playerjumpspeed);
                            //	player.didjump =  false;

                            player.playerjumpspeed++;
                            //Debug.Log(player.playerjumpspeed);
                            return;

                        }
                        player.AirBorn = true;
                        return;
                    }

                    player.didjump = true;
                    player.AwaitingGround = true;
                    if (ShouldBroadCastPlayerJumpSpeed)
                        AdminCompanionpublicbroadcast(player.playerclient.userName + " Atualmente tem uma JumpSpeed de " + player.playerjumpspeed);
                    if (player.playerjumpspeed < 31 && player.playerjumpspeed > 3)
                    {
                        if (ShouldDoAveragePingSpeedJumpCheck)
                            if (shouldbepinglienient)
                            {
                                var ping = player.playerclient.netUser.networkPlayer.averagePing;
                                var ping2 = player.playerclient.netUser.networkPlayer.lastPing;
                                if (ping >= int.Parse(pinglimitbeforeignore.ToString()) || ping2 >= int.Parse(pinglimitbeforeignore.ToString()))
                                {
                                    player.AwaitingGround = true;
                                    player.didjump = true;
                                    return;
                                }
                            }
                        if (!player.firsttimedjumpdetection)
                        {
                            player.firsttimedjumpdetection = true;
                            player.didjump = true;
                            return;
                        }

                        player.speedJumpPassesBeforePass--;
                        player.AlowSmartEnd = false;
                        player.LastGood = 0;
                        player.SpeedJumpDetections++;
                        if (player.SpeedJumpDetections < float.Parse(SpeedJumpTesttillfail.ToString()))
                        {
                            Debug.Log("Speed Jump " + player.SpeedJumpDetections + " - " + float.Parse(SpeedJumpTesttillfail.ToString()));
                            //player.FirstSpeedJumpDetection = true;
                            player.didjump = true;
                            return;
                        }

                        if (shoulddoipban)
                            ipban(player, "-    (SpeedJump - Level 1)    -");
                        player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                        AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]SpeedJump-Test[color red] )");
                        SpeedJump(player);
                        BanPlayer(player.playerclient.netUser, player.IP, "-    (SpeedJump - Level 1)    -");
                        numberofspeedjumpban++;
                        return;
                    }


                    if (player.playerjumpspeed > 63 && player.playerjumpspeed < 200)
                    {

                        if (!player.firsttimedjumpdetection)
                        {
                            player.firsttimedjumpdetection = true;
                            player.didjump = true;
                            return;
                        }
                        player.speedJumpPassesBeforePass--;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "[color red]Você será banido se não seguir as instruções" + "\"");
                        if (ShouldDegradeJumpDetection)
                        {
                            player.speedJumpPassesBeforePass = -float.Parse(NumberOfPassesTillMinus.ToString());
                        }
                        if (shouldbanforitmingjumps)
                        {
                            var ping = player.playerclient.netUser.networkPlayer.averagePing;
                            if (ping != null)
                                if (ping >= int.Parse(pinglimitbeforeignore.ToString()))
                                {
                                    player.AwaitingGround = true;
                                    player.didjump = true;
                                    return;
                                }
                            player.timedjumpdettections++;
                            if (player.timedjumpdettections >= int.Parse(numberoftimedjumpdettectionsbeforeban.ToString()))
                            {

                                if (!player.firstjump)
                                {
                                    if (shoulddoipban)
                                        ipban(player, "-    (SpeedJump - Level 2)    -");
                                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                    AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]SpeedJump-Test[color red] )");
                                    SpeedJump(player);
                                    BanPlayer(player.playerclient.netUser, player.IP, "-    (SpeedJump - Level 2)    -");
                                    return;
                                }
                                if (!player.firstjump)
                                {
                                    player.didjump = true;
                                    player.firstjump = true;
                                    player.AwaitingGround = true;
                                    return;
                                }
                            }
                        }

                    }
                    if (player.playerjumpspeed > 48 && player.playerjumpspeed <= 62)
                    {
                        player.speedJumpPassesBeforePass++;
                        player.SpeedJumpDetections--;
                        if (ShouldDoSmartJumpChect)
                        {
                            if (player.AlowSmartEnd)
                            {
                                if (player.LastGood < 3)
                                    player.LastGood++;
                                else
                                {
                                    //AdminCompanionpublicbroadcast(player.playerclient.userName + " [color green]passou no primeiro teste com sucesso ");
                                    player.passedjumptest = true;
                                    return;
                                }
                            }
                            if (!player.AlowSmartEnd)
                            {
                                player.LastGood++;
                                if (player.LastGood >= 2)
                                {
                                    player.AlowSmartEnd = true;
                                }
                            }
                        }
                        if (player.speedJumpPassesBeforePass < float.Parse(SpeedJumpPassesTillPass.ToString()))
                        {
                            //	player.firstpass = true;
                            return;
                        }
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "Determinamos que você não está usando um modificador de salto ccmotor" + "\"");
                        //AdminCompanionpublicbroadcast(player.playerclient.userName + " [color green]passou no primeiro teste com sucesso ");
                        player.passedjumptest = true;
                        player.didjump = true;
                        player.AwaitingGround = true;
                        return;
                    }
                }
            
        }
        public static void undofixplayerhp(CompanionCheck source)
        {
            
                if (source == null || source.playerclient == null) return;
                if (source == null || source.playerclient.controllable == null) return;
                FallDamage falldamage = source.playerclient.rootControllable.GetComponent<FallDamage>();
                var testc = source.playerclient.rootControllable.GetComponent<HumanBodyTakeDamage>();
                CompanionCheck phandler = source.playerclient.GetComponent<CompanionCheck>();
                phandler.hasdoneheal = true;
                if (testc == null)
                {
                }
                testc.Bandage(1000.0f);
                falldamage.ClearInjury();
            


        }
        public static bool Issober(CompanionCheck player)
        {
           
                var datastore = Getplayerdatastore(player.playerclient.userID.ToString());
                if (!datastore.ContainsKey("Language"))
                    return false;
                if (datastore["Language"] == null)
                    return false;

                if (!datastore.ContainsKey("Language"))
                    return true;
            return true;
           
        }
        public static bool Issober2(CompanionCheck player)
        {
           
                var datastore = Getplayerdatastore(player.playerclient.userID.ToString());
                var dataplus = datastore["Language"].ToString();
                var data3 = Getplayerdatastore(dataplus);
                if (!data3.ContainsKey("F2testmsg"))
                    return false;
                if (DataStore[dataplus] == null)
                    return false;
            return true;
           
        }
        public static void doenglishdic()
        {
            
                var defaultenglishlanguage = Getplayerdatastore("en");
                if (!defaultenglishlanguage.ContainsKey("speedjumptestmsg"))
                {
                    defaultenglishlanguage.Add("F2testmsg", "[color#A9A9A9]Pressione e segure[color white]﹣  [color cyan]F2");
                    defaultenglishlanguage.Add("speedjumptestmsg", "[color red]Salte o mais rapido possivel");
                    defaultenglishlanguage.Add("norecoiltestmsg", "[color red]Equipe a arma no seu primeiro slot");
                    defaultenglishlanguage.Add("nospreadtestmsg", "[color red]Equipe a arma e atire nessa parede");
                    defaultenglishlanguage.Add("Completedmsg", "Obrigado por sua cooperação, você completou todos os testes");
                    defaultenglishlanguage.Add("donotcrouchmsg", "[color red]Por favor não se agache durante este teste");
                    defaultenglishlanguage.Add("donotdcmessage", "[color red]Por favor não desconecte durante este teste");
                    defaultenglishlanguage.Add("Dorecoiltest", "[color#A9A9A9]Pressione e segure[color white]﹣  [color cyan]C");
                }
           
        }
        public static void GetLanguage(CompanionCheck player)
        {
            
                var datastore = Getplayerdatastore(player.playerclient.userID.ToString());
                var check = player.playerclient.controllable.stateFlags.flags;
                if (!player.isininventory)
                    if (check != null)
                    {
                        if (player.playerclient.controllable.stateFlags.lostFocus)
                        {
                            if (!player.hasreceild2)
                            {
                                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "config.load");
                                player.hasreceild2 = true;
                            }
                            return;
                        }
                        if (!player.hasreceildcheck)
                        {
                            Resettestt2(player.playerclient, player.laststring2);
                            player.hasreceildcheck = true;
                        }
                        player.isininventory = true;
                    }
                if (check == null)
                    return;
                if (check == int.Parse(menuscreenflag.ToString()))
                {
                    player.messagetally7++;
                    if (player.messagetally7 > 75f)
                    {
                        Resettestt2(player.playerclient, player.laststring2);
                        player.messagetally7 = 0f;
                    }
                    return;
                }
                if (shoulduseenglishdictionaryonly)
                {
                    doenglishdic();
                    player.autolanguage = true;
                    player.language = "en";
                    player.hasselectedlanguage = true;
                    player.forcefinish = true;
                    player.playerhaslang2 = true;
                    return;
                }
                if (!player.hasselectedlanguage)
                {
                    player.messagetally3++;
                    if (player.messagetally3 >= 60f)
                    {
                        player.messagetally3 = 0f;
                        Resettestt2(player.playerclient, player.laststring2);
                        player.inttimetally++;
                        if (player.inttimetally >= 30)
                        {
                            doenglishdic();
                            player.autolanguage = true;
                            player.language = "en";
                            player.hasselectedlanguage = true;
                            player.forcefinish = true;
                            player.playerhaslang2 = true;
                            return;
                        }
                    }
                }
                var datastore2 = Getplayerdatastore("AdminCompanion(Lang.Log)");
                if (datastore2.ContainsKey(player.playerclient.userID.ToString()))
                {
                    foreach (KeyValuePair<string, object> pair in datastore2)
                        if (pair.Value.ToString() == player.playerclient.userID.ToString() || pair.Key.ToString() == player.playerclient.userID.ToString() || pair.Value.ToString().ToLower() == player.playerclient.userID.ToString() || pair.Key.ToString().ToLower() == player.playerclient.userID.ToString() || pair.Value.ToString().ToLower().Contains(player.playerclient.userID.ToString()) || pair.Key.ToString().ToLower().Contains(player.playerclient.userID.ToString()))
                        {
                            var uid = pair.Value.ToString();
                            player.language = uid;
                            var datastore3 = Getplayerdatastore(uid);
                            if (!datastore3.ContainsKey("Completedmsg"))
                                return;
                            player.playerhaslang2 = true;
                        }
                }
                if (datastore2.ContainsKey(player.playerclient.userID.ToString()))
                {
                    foreach (KeyValuePair<string, object> pair in datastore2)
                        if (pair.Value.ToString() == player.playerclient.userID.ToString() || pair.Key.ToString() == player.playerclient.userID.ToString() || pair.Value.ToString().ToLower() == player.playerclient.userID.ToString() || pair.Key.ToString().ToLower() == player.playerclient.userID.ToString() || pair.Value.ToString().ToLower().Contains(player.playerclient.userID.ToString()) || pair.Key.ToString().ToLower().Contains(player.playerclient.userID.ToString()))
                        {
                            var uid = pair.Value.ToString();
                            player.language = uid;
                            player.playerhaslang2 = true;
                            return;
                        }
                }
                if (!player.hasselectedlanguage)
                {
                    player.messagetally2++;
                    if (player.messagetally2 >= 60f)
                    {
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "[color red]Por favor escreva Portugues, ingles, ETC" + "\"");
                        player.messagetally2 = 0f;
                    }
                    return;
                }
                if (!player.playerhaslang2)
                {
                    foreach (KeyValuePair<string, object> pair in datastore2)
                        if (pair.Value.ToString() == player.playerclient.userID.ToString() || pair.Key.ToString() == player.playerclient.userID.ToString() || pair.Value.ToString().ToLower() == player.playerclient.userID.ToString() || pair.Key.ToString().ToLower() == player.playerclient.userID.ToString() || pair.Value.ToString().ToLower().Contains(player.playerclient.userID.ToString()) || pair.Key.ToString().ToLower().Contains(player.playerclient.userID.ToString()))
                        {
                            var uid = pair.Value.ToString();
                            player.language = uid;
                            player.playerhaslang2 = true;
                            return;
                        }
                }
           
        }
        public class CompanionCheckflagcheck : UnityEngine.MonoBehaviour
        {
            public PlayerClient playerclient;
            public string userid;
            public Character character;
            public float lastTick;
            public float currentTick;
            public float LastXF = 0f;


            void Awake()
            {
               
                    lastTick = UnityEngine.Time.realtimeSinceStartup;
                    enabled = false;
                
            }
            public void StartCheck()
            {
               
                    this.playerclient = GetComponent<PlayerClient>();
                    this.userid = this.playerclient.userID.ToString();
                    if (playerclient.controllable == null) return;
                    this.character = playerclient.controllable.GetComponent<Character>();
                    enabled = true;

                    FixedUpdate();
                
            }
            void FixedUpdate()
            {
                
                    if (!this || playerclient == null || playerclient.netUser == null || this.playerclient.controllable == null)
                    {
                        return;
                    }

                    if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 0.32f)
                    {
                        currentTick = UnityEngine.Time.realtimeSinceStartup;
                        lastTick = currentTick;
                        var characterstate = this.playerclient.controllable.stateFlags.flags;
                        var try4 = (playerclient.controllable.rootCharacter.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").rotation.y + playerclient.controllable.rootCharacter.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").rotation.y).ToString();

                        //Debug.Log(this.playerclient.GetComponent<HeadBob>());
                        ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add Server \"" + "Seu estado de caractere atual é " + (float.Parse(try4) - LastXF) + "\"");
                        ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add Server \"" + "Seu estado de caractere atual é " + characterstate + "\"");
                        //Debug.Log(this.playerclient.lastKnownPosition + " " + playerclient.controllable.rootCharacter.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").position);
                        //ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add Server \"" + "Your current character state is " + playerclient.controllablustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").x + " " + this.playerclient.transform.position.x + \"");
                        LastXF = float.Parse(try4);

                    }
               
            }
        }
        public class GodCharacter : UnityEngine.MonoBehaviour
        {
            public PlayerClient playerclient;
            public string userid;
            public Character character;
            public float lastTick;
            public float currentTick;
            int count = 0;


            void Awake()
            {
               
                    lastTick = UnityEngine.Time.realtimeSinceStartup;
                    enabled = false;

                
            }
            public void StartCheck()
            {
                
                    this.playerclient = GetComponent<PlayerClient>();
                    this.userid = this.playerclient.userID.ToString();
                    if (playerclient.controllable == null) return;
                    this.character = playerclient.controllable.GetComponent<Character>();
                    enabled = true;

                    FixedUpdate();
               
            }
            void OnDestroy()
            {
                
                    if (this.playerclient.rootControllable != null)
                        this.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
               
            }
            void FixedUpdate()
            {
               
                    if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 1)
                    {

                        if (this == null || playerclient == null || playerclient.netUser == null || this.playerclient.controllable == null)
                        {
                            return;
                        }

                        count++;
                        if (count > 10)
                        {
                            if (playerclient.netUser == null)
                                GameObject.Destroy(this);

                            if (playerclient.rootControllable != null)
                            {
                                playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                GameObject.Destroy(this);
                                return;
                            }
                        }
                        currentTick = UnityEngine.Time.realtimeSinceStartup;
                        lastTick = currentTick;
                        //var characterstate = this.playerclient.controllable.stateFlags.flags;
                        //ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add Server \"" + "Your current character state is " + characterstate + "\"");
                    }
                
            }
        }
        public static Oxide.Core.Libraries.Timer STimer = GetLibrary<Oxide.Core.Libraries.Timer>();
        public static string ParseLanguage(string Suspect)
        {
            var language = Getplayerdatastore(Suspect);
            if (language.ContainsKey("F2testmsg") && language.ContainsKey("speedjumptestmsg") && language.ContainsKey("nospreadtestmsg") && language.ContainsKey("Dorecoiltest") && language.ContainsKey("donotdcmessage") && language.ContainsKey("norecoiltestmsg")) { }
            else
            {
                language.Clear();
                return "en";
            }
            var F2test = language["F2testmsg"].ToString();
            if (!F2test.ToString().Contains("F2"))
            {
                if (language.ContainsKey("F2TestTurk"))
                {
                    F2test = language["F2TestTurk"].ToString();
                    language.Remove("F2testmsg");
                    language.Add("F2testmsg", F2test);
                }

                if (!F2test.ToString().Contains("F2"))
                {
                    language.Clear();
                    return "en";
                }
            }
            return Suspect;
        }
        public class CompanionCheck : UnityEngine.MonoBehaviour
        {
            public StructureComponent Block = null;
            public float LastGood = 0f;
            public bool CanSendMessage = true;
            public float SpeedJumpDetections = 0f;
            public float speedJumpPassesBeforePass = 0f;
            public float NFDET = 0f;
            public string LastStringToGet = "1";
            public string LangPair = "1";
            public int FirstUP = 0;
            public string IP = null;
            public bool hasparselang = false;
            public Dictionary<string, string> TestDictionaries = new Dictionary<string, string>();
            public Dictionary<string, string> MenuDictionaries = new Dictionary<string, string>();
            public bool FirstFallDetection;
            public bool HasGotMyCeiling;
            public Vector3 CurrentCVector;
            public bool FirstTerrainDetect;
            public bool firstdetectionsaspect = false;
            public bool NoLongerChecking;
            public int DetectionsAspect = 0;
            public GameObject PlayerEntity = null;
            public int WhentUp;
            public bool AspectCheck = false;
            public bool HasCreatedEntity;
            public bool FirstSpeedJumpDetection = false;
            public bool hasloc2;
            public bool hastpbackfirst;
            public bool hastpbacksecond;
            public int HackMenuDetections = 0;
            public bool hassentmessages;
            public bool hasreceild2;
            public float firstz1;
            public float firstx1;
            public float firsty1;
            public bool hasreceildcheck;
            public bool hasfinishedthrdexcepion;
            public IInventoryItem lastinventoryitem;
            public bool hasremoveditem;
            public bool hasceildcheck;
            public bool hasfinisheddizzy2;
            public bool hasfinishedsteven2;
            public bool hasfinishedjacked2;
            public bool nofallexception;
            public bool hasressetjsettings;
            public bool autolanguage;
            public bool isininventory;
            public string newstring;
            public string newstring2;
            public string newstring3;
            public string newstring4;
            public string newstring5;
            public string newstring6;
            public string newstring7;
            public string newstring8;
            public int intt = 30;
            public string normstring;
            public int inttimetally;
            public int numberoffakecalls;
            public int savedweaponnumber;
            public bool hasgotengivenitem;
            public bool detectionended;
            public bool hasrefreshedinventorysettings;
            public bool secoonddetect;
            public bool thrddetect;
            public float fallcount;
            public bool firstdetect;
            public float n;
            public float s;
            public float h;
            public float nr;
            public Vector3 point;
            public bool hasdoneheal;
            public GameObject Load;
            public float firstx;
            public bool hasteleportedtosafety;
            public bool didteleportback;
            public bool crouchdelayactivated;
            public bool isreturningsettings;
            public bool firsttimedjumpdetection;
            public float crouchdelay;
            public string whatsyourlanguage;
            public bool playerhasremovednulllang;
            public int playertestdelaycount;
            public float lasthealth;
            public float firsty;
            public int count3;
            public int timedjumpdettections = 0;
            public float idletimecount;
            public float firstz;
            public bool hasresettest;
            public bool didteleport;
            public bool forcefinish;
            public bool firstjump;
            public int secondselect = 0;
            public bool firstnofalldetection;
            public bool firsttime;
            public bool isfirstcheck;
            public bool firstpasseular;
            public bool hascompletednofallcheck;
            public bool passednorecoiltest;
            public bool firstgetclimpammo;
            public bool hasgivenammo;
            public string lastclipammo;
            public string lasteularangles;
            public InventoryItem lastdatablock;
            public bool datablocknull;
            public ItemDataBlock lastdatablock2;
            public ItemDataBlock lastdatablock3;
            public bool hasgivenweapon;
            public bool hasremoveddefaultitem;
            public bool didjump = true;
            public bool hasselecteddatablock;
            public bool hastakenoutweapon;
            public bool firstpass;
            public bool shouldsendmessagetally;
            public bool passedjumptest;
            public float lasty;
            public float messagetally = 0f;
            public float messagetally2 = 0f;
            public float messagetally3 = 0f;
            public float messagetally4 = 0f;
            public float messagetally5 = 0f;
            public float messagetally6 = 0f;
            public float messagetally7 = 0f;
            public float messagetally8 = 0f;
            public float lasty2;
            public float lastjump;
            public double playerjumpspeed = 0.0;
            public string laststring2 = "F2";
            public string language;
            public bool wasinmenu;
            public bool diddolastjump;
            public bool isinjumptest;
            public bool playerhaslang2;
            public bool hasselectedlanguage;
            public bool finishedspeedjumpptest;
            public float timeleft;
            public float lastTick;
            public float currentTick;
            public float deltaTime;
            public float component2distance;
            public Component componenthit2;
            public Vector3 lastPosition;
            public Vector3 headlocation2;
            public BulletWeaponDataBlock lastbulletitem;
            public float headlocation3;
            public float headlocationangle2;
            public float headlocationangle1;
            public float checkrotaionx;
            public float totaleularanglesCompanionCheck;
            public Vector3 lastPosition2;
            public PlayerClient playerclient;
            public Character character;
            public Inventory inventory;
            public string userid;
            public bool HasGot2 = false;
            public float distance3D;
            public float distance3D2;
            public string MyIp = null;
            public float distanceHeight;
            public bool finishedstevencheck;
            public bool finishedjackedcheck;
            public bool finisheddizzycheck;
            public bool firstcheckstate;
            public int count;
            public int wasinmenucount;
            public float currentFloorHeight;
            public bool hasSearchedForFloor = false;
            public float lastSpeed = UnityEngine.Time.realtimeSinceStartup;
            public int speednum = 0;

            public float lastWalkSpeed = UnityEngine.Time.realtimeSinceStartup;
            public int walkspeednum = 0;
            public bool lastSprint = false;

            public float lastJump = UnityEngine.Time.realtimeSinceStartup;
            public int jumpnum = 0;


            public float lastFly = UnityEngine.Time.realtimeSinceStartup;
            public int flynum = 0;

            public int noRecoilDetections = 0;
            public int noRecoilKills = 0;

            public float lastWoodCount = 0;

            void Awake()
            {
                
                    lastTick = UnityEngine.Time.realtimeSinceStartup;
                    enabled = false;
                    this.playerclient = GetComponent<PlayerClient>();
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "config.load");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "config.save");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "input.bind Inventory None None");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "input.bind Down F2 F2");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "input.bind Left " + "None" + " " + "None");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "input.bind Up " + "None" + " " + "None");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "input.bind Duck " + "None" + " " + "None");
               
            }
            void OnDestroy()
            {
                
                    if (this != null && this.playerclient && this.playerclient.netUser != null && this.playerclient.netUser.connected)
                    {
                        if (!this.playerclient.netUser.disposed)
                        {
                            ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "config.load");
                            ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "config.save");
                        }

                        //this.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                        if (this.Block != null)
                        {
                            //this.Block.GetComponent<TakeDamage>().SetGodMode(false);
                            this.Block.GetComponent<TakeDamage>().SetGodMode(false);
                            TakeDamage.KillSelf(this.Block);
                            this.Block = null;
                        }
                        EndDetection(this);
                        EndDetection(this);
                    }

                    //EndDetection(this);
               
            }
            public bool DOTeleportfailsafe = false;
            public void StartCheck()
            {
                
                    /*if(!hasparselang)
                    {
                        language = ParseLanguage(language);
                        hasparselang = true;
                    }*/
                    //.Log("5");

                    if (this.playerclient == null)
                        GameObject.Destroy(this);
                    if (this.playerclient.netUser.disposed)
                        GameObject.Destroy(this);

                    //.Log("6");

                    if (MyIp == null)
                        MyIp = playerclient.netUser.networkPlayer.externalIP.ToString();
                    //.Log("7");
                    if (IP == null)
                        IP = MyIp;
                    //.Log("8");
                    this.userid = this.playerclient.userID.ToString();
                    //.Log("9");
                    if (playerclient.controllable == null) return;
                    //.Log("10");
                    this.character = playerclient.controllable.GetComponent<Character>();
                    //.Log("11");
                    this.lastPosition = this.playerclient.lastKnownPosition;
                    //.Log("12");
                    enabled = true;
                    //.Log("13");
                    FixedUpdate();
                    //.Log("14");
               
            }
            public bool AwaitingGround = true;
            public bool SecondCheck = false;
            public bool AlowSmartEnd = true;
            public float timetogo = 0f;
            public bool AlowGo = true;
            public float TimetodoFailSafe = 0f;
            bool Init = false;
            public bool HackMenuNextEvent = false;
            public float LastTick2 = 0f;
            public bool AirBorn = false;
            void FixedUpdate()
            {
                
                    if (!this || playerclient == null || playerclient.netUser == null || this.playerclient.controllable == null)
                    {
                        return;
                    }

                    if (this.playerclient.lastKnownPosition == new Vector3(0.0f, 0.0f, 0.0f) || this.playerclient.controllable == null)
                    {

                        AlowGo = false;
                        this.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        return;

                    }
                    if (!Init)
                    {
                        this.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                        Init = true;
                        return;
                    }
                    if (!AlowGo)
                    {
                        timetogo++;
                        if (timetogo < 300f)
                            return;
                        else
                            AlowGo = true;
                    }

                    //.Log("15");
                    if (!this.hasteleportedtosafety)
                    {
                        //.Log("16");
                        doteleporttosafety(this);
                        return;
                    }
                    if (!DOTeleportfailsafe)
                    {
                        var loc = Getplayerdatastore("SafeZone");
                        Vector3 GetVector = new Vector3(0.0f, 389.0f, 0.0f);
                        if (loc.ContainsKey("x"))
                        {
                            var safex = Convert.ToSingle(loc["x"]);
                            var safey = Convert.ToSingle(loc["y"]);
                            var safez = Convert.ToSingle(loc["z"]);
                            GetVector = new Vector3(safex, safey, safez);
                        }
                        if (Vector3.Distance(GetVector, this.playerclient.lastKnownPosition) > 30f)
                        {
                            doteleporttosafety(this, false);
                        }
                        else
                            DOTeleportfailsafe = true;
                        return;
                    }
                    //.Log("17");

                    if (!this.hascompletednofallcheck && !this.passednorecoiltest)
                    {
                        if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 1)
                        {

                            if (!this.hascompletednofallcheck)
                                checknofall(this);
                            currentTick = UnityEngine.Time.realtimeSinceStartup;
                            deltaTime = currentTick - lastTick;
                            distance3D = Vector3.Distance(playerclient.lastKnownPosition, lastPosition) / deltaTime;
                            distanceHeight = (playerclient.lastKnownPosition.y - lastPosition.y) / deltaTime;
                            lastPosition = playerclient.lastKnownPosition;
                            lastTick = currentTick;
                            this.hasSearchedForFloor = false;
                        }
                        return;
                    }
                    if (this.passednorecoiltest)
                    {
                        if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 1)
                        {
                            checkplayer(this);
                            currentTick = UnityEngine.Time.realtimeSinceStartup;
                            deltaTime = currentTick - lastTick;
                            distance3D = Vector3.Distance(playerclient.lastKnownPosition, lastPosition);
                            distanceHeight = (playerclient.lastKnownPosition.y - lastPosition.y);
                            lastPosition = playerclient.lastKnownPosition;
                            lastTick = currentTick;
                            this.hasSearchedForFloor = false;
                        }
                        return;
                    }
                    if (!this.playerhaslang2)
                    {
                        GetLanguage(this);
                    }
                    if (!this.playerhaslang2)
                    {
                        return;
                    }
                    if (!this.passedjumptest)
                    {
                        if (AirBorn && playerclient.controllable.stateFlags.grounded)
                        {
                            this.playerjumpspeed = 0;
                            AirBorn = false;
                        }
                        else
                            checkplayerjumpspeed(this);

                    }
                    if (this.passedjumptest)
                    {
                        if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 1 && !this.passednorecoiltest)
                        {
                            if (!this.AspectCheck)
                                CheckAspect(this);
                            if (this.AspectCheck)
                            {

                                if (!this.hascompletednofallcheck)
                                    checknofall(this);
                                if (this.hascompletednofallcheck)
                                    if (!this.passednorecoiltest)
                                        norecoilcheck(this);

                            }



                            currentTick = UnityEngine.Time.realtimeSinceStartup;
                            deltaTime = currentTick - lastTick;
                            distance3D = Vector3.Distance(playerclient.lastKnownPosition, lastPosition) / deltaTime;
                            distanceHeight = (playerclient.lastKnownPosition.y - lastPosition.y) / deltaTime;
                            lastPosition = playerclient.lastKnownPosition;
                            lastTick = currentTick;
                            this.hasSearchedForFloor = false;
                        }
                    }

               
            }
        }

        static void doteleporttosafety(CompanionCheck player, bool ShouldSaveLoc = true)
        {
            
                NetUser netuser = player.playerclient.netUser;
                //.Log("19");
                if (!ShouldSaveLoc)
                {
                    if (player.TimetodoFailSafe < 100)
                    {
                        player.TimetodoFailSafe++;
                        return;
                    }

                }
                if (ShouldSaveLoc)
                    if (!player.hasloc2)
                    {
                        player.firstx1 = player.playerclient.lastKnownPosition.x;
                        player.firsty1 = player.playerclient.lastKnownPosition.y;
                        player.firstz1 = player.playerclient.lastKnownPosition.z;
                        player.hasloc2 = true;
                    }
                //.Log("20");
                var loc = Getplayerdatastore("SafeZone");
                //.Log("21");
                if (!loc.ContainsKey("x"))
                {
                    //.Log("22");
                    //Resettestt2(player.playerclient, player.laststring2);
                    //.Log("23");
                    TeleportToPos2(netuser, 0.0f, 389.1f, 0.0f);
                    player.hasteleportedtosafety = true;
                    //.Log("24");
                    //STimer.Once(1f, () => 
                    //{
                    
                    // FinalSafety(netuser, player);
                   
                    //   });
                    //.Log("25");
                    return;
                }
                var safex = Convert.ToSingle(loc["x"]);
                var safey = Convert.ToSingle(loc["y"]);
                var safez = Convert.ToSingle(loc["z"]);
                TeleportToPos2(netuser, safex, safey, safez);
                player.hasteleportedtosafety = true;
                //STimer.Once(1f, () => 
                //{
               
                // FinalSafety(netuser, player);
                // }
                
                //    });
                return;
            

        }
        public static void CompleteVoid(CompanionCheck player)
        {
            
                player.hasteleportedtosafety = true;
            
        }
        public static void FinalSafety(NetUser netuser, CompanionCheck player)
        {
            
                var loc = Getplayerdatastore("SafeZone");
                if (!loc.ContainsKey("x"))
                {
                    TeleportToPos2(netuser, 0.0f, 389.1f, 0.0f);
                    player.hasteleportedtosafety = true;
                    //STimer.Once(1f, () => 
                    // {
                   
                    //     CompleteVoid(player);
               
                  
                    //     });
                    return;
                }
                var safex = Convert.ToSingle(loc["x"]);
                var safey = Convert.ToSingle(loc["y"]);
                var safez = Convert.ToSingle(loc["z"]);
                player.hasteleportedtosafety = true;
                TeleportToPos2(netuser, safex, safey, safez);

                //STimer.Once(3f, () => 
                //{
                
                //       CompleteVoid(player);
               
                //     });
           
        }
        static void TeleportToPos2(NetUser source, float x, float y, float z)
        {
           
                //.Log("25");
                if (Physics.Raycast(new Vector3(x, -1000f, z), vectorup2, out cachedRaycasttt, Mathf.Infinity, terrainLayer))
                {
                    if (cachedRaycasttt.point.y > y) y = cachedRaycasttt.point.y;
                    //.Log("26");
                }
                //.Log("27");
                management2.TeleportPlayerToWorld(source.playerClient.netPlayer, new Vector3(x, y, z));
                //.Log("28");
           
        }
        static bool CompanionCheckHasGround(CompanionCheck player)
        {
            
                if (!player.hasSearchedForFloor)
                {
                    if (Physics.Raycast(player.playerclient.lastKnownPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycasttt, distanceDown))
                        player.currentFloorHeight = cachedRaycasttt.distance;
                    else
                        player.currentFloorHeight = 10f;
                }
                player.hasSearchedForFloor = true;
                if (player.currentFloorHeight < 4f) return true;

            return false;
           
        }
        static void checknofall2(CompanionCheck player)
        {
           
                dosettings(player);
                player.lasthealth = player.playerclient.controllable.health;

                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                var time = UnityEngine.Time.realtimeSinceStartup;
                player.didteleport = true;
                if (player.firsttime != true)
                {
                    var firstx = player.playerclient.lastKnownPosition.x;
                    var firsty = player.playerclient.lastKnownPosition.y;
                    var firstz = player.playerclient.lastKnownPosition.z;
                    player.firstx = firstx;
                    player.firsty = firsty;
                    player.firstz = firstz;
                    player.firsttime = true;
                }
                NetUser netuser = player.playerclient.netUser;
                TeleportToPos2(netuser, 0.0f, 60000f, 0.0f);
            
        }
        static bool IsOnSupport(CompanionCheck player)
        {
            
                foreach (Collider collider in Physics.OverlapSphere(player.playerclient.lastKnownPosition, 5f))
                {
                    if (collider.GetComponent<UnityEngine.MeshCollider>())
                        return true;
                }
            return false;
           
        }

        public static void checknofall(CompanionCheck player)
        {
           
                if (!player.HasGot2)
                {
                    player.hasteleportedtosafety = false;
                    player.HasGot2 = true;
                    return;
                }
                if (!shouldchecknofall)
                {

                    player.hascompletednofallcheck = true;
                    return;
                }

                NetUser netuser = player.playerclient.netUser;
                var enhancedcheck = player.lastPosition.y;
                var newcheckdistance = (enhancedcheck - player.playerclient.lastKnownPosition.y);
                var ulongcheck2 = (Math.Abs(newcheckdistance));
                var ulongcheck = (Math.Abs(player.distanceHeight));
                if (!player.isfirstcheck)
                {
                    ConsoleSystem.Run("falldamage.enabled true", true);
                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                    if (shouldcheckmultinofall)
                    {
                        dosettings(player);
                    }

                    checknofall2(player);
                    player.isfirstcheck = true;
                    return;
                }

                // if(CompanionCheckHasGround(player) && player.didteleportback == false) return;
                // if(IsOnSupport(player) && player.didteleportback == false) return;

                var distanceenhanced2 = (Math.Abs(newcheckdistance));
                /*
                if(distanceenhanced2 < 20)
                {
                    player.count3++;
                }
                */
                var time = UnityEngine.Time.realtimeSinceStartup;

                var distanceenhanced = (Math.Abs(player.distanceHeight));
                /*
                if(!player.playerclient.controllable.stateFlags.grounded)
                if(ulongcheck < 20 && !player.playerclient.controllable.stateFlags.grounded)
                {
                    if(!player.firstnofalldetection)
                    {
                        player.firstnofalldetection = true;
                        return;
                    }
                    if(!player.nofallexception)
                    {
                        player.nofallexception = true;
                        return;
                    }
                    if(shoulddoipban)
                        ipban(player, "AdminCompanion(No Fall Damage)");
                        player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                    AdminCompanionBroadcastplayer(player.playerclient.userName + " Has been Banned from the server for using NoFallDamage");
                    BanPlayer(player.playerclient.netUser,player.playerclient.userID.ToString(), player.playerclient.userName, "AdminCompanion(No Fall Damage)");
                    numberofbansnofalldamage++;
                    return;
                    checknofall2(player);
                    player.count++;
                    return;
                }
                */

                if (!player.didteleportback)
                {
                    TeleportToPos2(netuser, player.firstx, player.firsty, player.firstz);
                    player.didteleportback = true;
                }

                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                // if(player.firsttime == true && ulongcheck <= 90 && player.didteleportback == true)
                if (player.isfirstcheck == true && player.didteleportback == true)
                {
                    player.count3 = 0;

                    if (shouldcheckmultinofall)
                    {
                        if (!player.playerclient.rootControllable.stateFlags.grounded)
                            return;
                        FallDamage falldamage = player.playerclient.rootControllable.GetComponent<FallDamage>();
                        RaycastHit Floor = SearchForFloor(player.playerclient);
                        if (player.playerclient.controllable.stateFlags.grounded && Floor.collider != null)
                            if (falldamage.GetLegInjury() == 0)
                            {
                                if (player.lasthealth == player.playerclient.controllable.health)
                                {
                                    if (!player.firstdetect)
                                    {
                                        player.firstnofalldetection = false;
                                        player.didteleportback = false;
                                        checknofall2(player);
                                        player.firstdetect = true;

                                        return;
                                    }
                                    if (player.NFDET <= 5)
                                    {
                                        player.NFDET++;
                                        player.firstnofalldetection = false;
                                        player.didteleportback = false;
                                        checknofall2(player);
                                        player.secoonddetect = true;
                                        player.fallcount = 0;

                                        player.thrddetect = true;
                                        ConsoleSystem.Run("falldamage.enabled true", true);
                                        return;
                                    }
                                    if (shoulddoipban)
                                        ipban(player, "-    (NoFallDamage - Level 1)    -");
                                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                    AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]NoFall-Test[color red] )");
                                    Nofall(player);
                                    BanPlayer(player.playerclient.netUser, player.IP, "-    (NoFallDamage - Level 1)    -");
                                    numberofbansnofalldamage++;
                                    if (falldamageenabled)
                                    {
                                        returnallsetting(player);
                                    }
                                    return;
                                }
                                else
                                {

                                    Resettestt(player.playerclient, player.laststring2);
                                    player.hascompletednofallcheck = true;
                                    undofixplayerhp(player);
                                    returnallsetting(player);
                                }
                            }
                        Resettestt(player.playerclient, player.laststring2);
                        player.hascompletednofallcheck = true;
                        undofixplayerhp(player);
                        returnallsetting(player);
                        return;
                    }
                }
                return;
                var thisposition = player.playerclient.lastKnownPosition.y;
                foreach (PlayerClient playerr in PlayerClient.All)
                {
                    if (player != playerr)
                    {
                        var client = playerr.controllable;
                        player.playerclient.controllable.RelativeControlTo(client);

                    }
                }
                return;
                /* var datatest = player.playerclient.instantiationTimeStamp;
                 var character = player.playerclient.controllable.CreateCCMotor();
                 Debug.Log(datatest);
                 return;
                 player.playerclient.controllable.ccmotor.minTimeBetweenJumps = 0.55f;
                 var character3 = player.playerclient.controllable.ccmotor.minTimeBetweenJumps;
                 Debug.Log(character3);
                 return;
                 Debug.Log(character);*/
            
        }
        void cleardatastore()
        {
           
                int count = 0;
                foreach (KeyValuePair<string, object> pair in Info)
                {
                    var currenttable = pair.Value as Dictionary<string, object>;
                    count++;
                    currenttable.Clear();
                }
                Debug.Log(count + " Objetos de dados eliminados !!!");
           
        }
        bool Started = false;
        void StartAll()
        {
           
                //Started = true;

                terrainLayer = LayerMask.GetMask(new string[] { "Terrain" });
                management2 = RustServerManagement.Get();
                InitializeTable();
                BanType = typeof(BanList).GetNestedType("Ban", BindingFlags.Instance | BindingFlags.NonPublic);
                steamid = BanType.GetField("steamid");
                username = BanType.GetField("username");
                reason = BanType.GetField("reason");
                LoadData();
                SaveData();
                cleardatastore();
                management2 = RustServerManagement.Get();
                Start();
           
        }




        void OnServerInitialized()
        {
            

                permission.RegisterPermission(permissionDono, this);
                permission.RegisterPermission(permissionSubDono, this);
                permission.RegisterPermission(permissionAdmin, this);

                LoadData();
                if (!Started)
                    timer.Once(1f, () => StartAll());

                ACData = Interface.GetMod().DataFileSystem.GetDatafile("AntiCheat");
                getblueprints = typeof(PlayerInventory).GetField("_boundBPs", (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic));
                getlooters = typeof(Inventory).GetField("_netListeners", (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic));
                wooddata = DatablockDictionary.GetByName("Wood");
                PlayerHandler phandler;
                foreach (PlayerClient player in PlayerClient.All)
                {
                    if (hasPermission(player.netUser)) continue;
                    phandler = player.gameObject.AddComponent<PlayerHandler>();
                    phandler.timeleft = GetPlayerData(player);
                    phandler.StartCheck();
                }

           
        }
        public static InventoryItem GetCurrentEquippedItem(Character controller)
        {
            Inventory component = controller.GetComponent<Inventory>();
            if ((object)component != (object)null && component.activeItem != null && (object)component.activeItem.datablock != (object)null)
                return (InventoryItem)component.activeItem;
            return (InventoryItem)null;
        }
        public static InventoryItem getfirstitem(Character controller)
        {
            Inventory component = controller.GetComponent<Inventory>();
            if ((object)component != (object)null && component.firstItem != null && (object)component.firstItem.datablock != (object)null)
                return (InventoryItem)component.firstItem;
            return (InventoryItem)null;
        }
        public object GiveItem(Inventory inventory, string itemname, int amount, Inventory.Slot.Preference pref)
        {
           
                itemname = itemname.ToLower();
                if (!displaynameToDataBlock.ContainsKey(itemname)) return false;
                ItemDataBlock datablock = displaynameToDataBlock[itemname];
                inventory.AddItemAmount(displaynameToDataBlock[itemname], amount, pref);
           
            return true;
        }
        private void InitializeTable()
        {
            
                displaynameToDataBlock.Clear();
                foreach (ItemDataBlock itemdef in DatablockDictionary.All)
                {
                    displaynameToDataBlock.Add(itemdef.name.ToString().ToLower(), itemdef);
                }
            
        }
        public static void norecoilcheck(CompanionCheck player)
        {
            
                if (!shouldchecknorecoil)
                {
                    player.passednorecoiltest = true;
                    return;
                }

                player.nr++;
                if (shouldbanforidle)
                    if (player.nr >= int.Parse(idletimetillban.ToString()))
                    {
                        if (shoulddoipban)
                            ipban(player, "-    (Ociosidade durante o teste)    -");
                        player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                        Afk(player);
                        AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]Afk-Test[color red] )");
                        BanPlayer(player.playerclient.netUser, player.IP, "-    (Ociosidade durante o teste)    -");
                        return;
                    }
                if (!player.hasrefreshedinventorysettings)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "config.load");
                    player.hasrefreshedinventorysettings = true;
                    return;
                }
                if (!player.hasceildcheck) ;
                {
                    Resettestt2(player.playerclient, player.laststring2);
                    player.hasceildcheck = true;
                }
                var check = player.playerclient.controllable.stateFlags.flags;
                if (check == null)
                    return;
                if (player.playerclient.controllable == null)
                    return;
                var eulerangles3 = new Angle2(89.9f, 9.2f);
                var eulerangles = (Angle2)player.playerclient.controllable.eyesAngles;
                if (eulerangles == eulerangles3)
                    return;
                refreshrecoiltest(player);
                if (check == int.Parse(menuscreenflag.ToString()))
                {
                    Resettestt2(player.playerclient, player.laststring2);
                    return;
                }
                var language = Getplayerdatastore(player.language);
                if (!language.ContainsKey("Dorecoiltest"))
                {
                    return;
                }
                if (!language.ContainsKey("norecoiltestmsg"))
                {
                    return;
                }
                var dorecoiltest = language["Dorecoiltest"].ToString();
                var norecoilcheckmsg = language["norecoiltestmsg"].ToString();
                Inventory inventory = player.playerclient.controllable.GetComponent<PlayerInventory>();
                var inv = player.playerclient.rootControllable.idMain.GetComponent<Inventory>();
                var firstitem = getfirstitem(player.playerclient.controllable.GetComponent<Character>());
                Inventory.Slot.Preference pref2 = Inventory.Slot.Preference.Define(Inventory.Slot.Kind.Belt, false, Inventory.Slot.KindFlags.Belt);
                IInventoryItem item2 = null;
                var ppt = inv.GetItem(30, out item2);
                //Facepunch.NetworkView networkView = inv.networkView;
                //NetworkCullInfo info;
                //NetworkCullInfo.Find((uLink.NetworkView) networkView, out info);
                //ItemRepresentation itemRep = NetCull.InstantiatePiggyBackWithArgs<ItemRepresentation>(networkView.owner, info, test3.itemRepresentation.datablock._itemRepPrefab, networkView.transform.position, networkView.transform.rotation, new object[2]);
                //Facepunch.NetworkView networkView = inventory.networkView;
                //NetworkCullInfo info;
                //NetworkCullInfo.Find((uLink.NetworkView) networkView, out info);
                // ItemRepresentation itemRep = NetCull.InstantiatePiggyBackWithArgs<ItemRepresentation>(networkView.owner, info, test3.itemRepresentation.datablock._itemRepPrefab, networkView.transform.position, networkView.transform.rotation, new object[2]);
                //  new uLink.NetworkViewID?(test3.itemRepresentation.networkView.viewID)

                //IHeldItem heldItem = inventory.activeItem as IHeldItem;
                //heldItem.inventory.SetActiveItemManually(0, itemRep, new uLink.NetworkViewID?(test3.itemRepresentation.networkView.viewID));
                //heldItem.OnActivate();
                if (!player.hasremoveddefaultitem)
                {
                    if (item2 != null)
                    {
                        player.datablocknull = true;
                        player.lastdatablock3 = item2.datablock;
                        player.lastinventoryitem = item2;
                        inventory.RemoveItem(30);
                        player.hasremoveddefaultitem = true;
                        return;
                    }
                    player.hasremoveddefaultitem = true;
                }
                if (!player.hasgivenweapon)
                {
                    inv.AddItemAmount(displaynameToDataBlock[NoRecoilWeapon.ToLower()], 1, pref2);
                    player.hasgivenweapon = true;
                    return;
                }
                var getcahcedbuletitem = GetCurrentEquippedItem(player.playerclient.controllable.GetComponent<Character>());
                if (item2 != null)
                {
                    var test3 = item2 as BulletWeaponItem<BulletWeaponDataBlock>;
                    if (test3 != null)
                        if (!player.hastakenoutweapon)
                        {
                            if (player.secondselect <= 3)
                            {
                                player.secondselect++;
                                inv.SetActiveItemManually(30, test3.itemRepresentation);
                                return;
                            }
                            inv.DeactivateItem();
                            player.hastakenoutweapon = true;
                            return;
                        }
                }
                InventoryItem item;
                if (!player.hasgotengivenitem)
                {
                    var p = inventory.FindItem(NoRecoilWeapon);
                    if (p == null)
                    {
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + "Aviso não conseguiu encontrar arma" + "\"");
                        return;
                    }
                    player.hasgotengivenitem = true;
                    player.savedweaponnumber = p.slot;
                    player.lastdatablock2 = p.datablock;
                    return;
                    if (firstitem == null)
                        return;
                    if (firstitem != null)
                    {

                        player.lastdatablock2 = firstitem.datablock;
                        player.hasgotengivenitem = true;
                        return;
                    }
                }
                if (!player.hastakenoutweapon)
                {
                    player.hastakenoutweapon = true;
                    return;
                }
                if (getcahcedbuletitem == null)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + norecoilcheckmsg + "\"");
                    return;
                }
                getcahcedbuletitem.FireClientSideItemEvent(InventoryItem.ItemEvent.Used);
                if (getcahcedbuletitem.slot != 30 || getcahcedbuletitem.datablock != displaynameToDataBlock[NoRecoilWeapon.ToLower()])
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + norecoilcheckmsg + "\"");
                    return;
                }
                var g = getcahcedbuletitem.slot;
                if (g == null)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + norecoilcheckmsg + "\"");
                    return;
                }

                var test4 = inventory._activeItem as BulletWeaponItem<BulletWeaponDataBlock>;
                if (!player.hasgivenammo)
                    if (test4 != null)
                        if (test4.clipAmmo <= 1)
                        {

                            Resettestt(player.playerclient, player.laststring2);
                            player.hasgivenammo = true;
                            test4.clipAmmo = 1000;
                            return;
                            player.lastclipammo = test4.clipAmmo.ToString();
                            player.lasteularangles = eulerangles.ToString();
                            test4.clipAmmo = 1000;
                            return;
                        }
                if (!player.firstpasseular)
                {
                    player.lasteularangles = eulerangles.ToString();
                    player.firstpasseular = true;
                    return;
                }
                if (!player.firstgetclimpammo)
                    if (test4.clipAmmo.ToString() != player.lastclipammo)
                    {
                        player.lastclipammo = test4.clipAmmo.ToString();
                        player.firstgetclimpammo = true;
                        return;
                    }
                if (test4.clipAmmo.ToString() != player.lastclipammo)
                {
                    if (player.lasteularangles == eulerangles.ToString())
                    {
                        player.noRecoilDetections++;
                        if (player.noRecoilDetections >= 2)
                        {
                            if (shoulddoipban)
                                ipban(player, "-    (NoRecoil - Level 1)    -");
                            player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                            AdminCompanionBroadcastplayer(player.playerclient.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]NoRecoil-Test[color red] )");
                            NoRecoil(player);
                            BanPlayer(player.playerclient.netUser, player.playerclient.netUser.networkPlayer.externalIP.ToString(), "-    (NoRecoil - Level 1)    -");
                            numberofbansnorecoil++;
                            return;
                        }
                    }
                }

                if (test4.clipAmmo.ToString() == player.lastclipammo)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add Server \"" + dorecoiltest + "\"");
                }
                if (test4.clipAmmo.ToString() != player.lastclipammo)
                    if (player.lasteularangles != eulerangles.ToString())
                    {
                        inventory.RemoveItem(g);
                        if (player.datablocknull)
                        {

                            Inventory.Slot.Preference pref3 = Inventory.Slot.Preference.Define(Inventory.Slot.Kind.Belt, false, Inventory.Slot.KindFlags.Belt);
                            inv.AddItemAmount(player.lastdatablock3, 1, pref3);
                            IInventoryItem item3 = null;
                            var ppt2 = inv.GetItem(30, out item3);
                            if (item3 is BulletWeaponItem<BulletWeaponDataBlock>)
                            {

                                var finecheck1 = (item3 as BulletWeaponItem<BulletWeaponDataBlock>);
                                var finecheck2 = (player.lastinventoryitem as BulletWeaponItem<BulletWeaponDataBlock>);
                                var cd = ((IHeldItem)item3);
                                var cd2 = ((IHeldItem)player.lastinventoryitem);
                                cd.SetTotalModSlotCount(cd2.totalModSlots);
                                item3 = player.lastinventoryitem;
                                var count = cd2.itemMods.Length - 1;
                                int i = 0;
                                while (i < count)
                                {
                                    var itemmod = cd2.itemMods[i];
                                    cd.AddMod(itemmod);
                                    i++;
                                }
                                finecheck1.SetCondition(finecheck2.condition);
                                finecheck1.clipAmmo = finecheck2.clipAmmo;
                                item3.AddUses(player.lastinventoryitem.uses);

                            }
                        }
                        player.passednorecoiltest = true;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "config.load");
                        Resettestt(player.playerclient, player.laststring2);
                        return;
                    }
                player.lastclipammo = test4.clipAmmo.ToString();
                return;
                /*
                ItemDataBlock datablock = displaynameToDataBlock["p250"];
                var activeitem = inventory._activeItem;
                Inventory.Slot.Preference pref = Inventory.Slot.Preference.Define(Inventory.Slot.Kind.Armor,false,Inventory.Slot.KindFlags.Belt);
                if(displaynameToDataBlock["m4"] == null)
                {
                    return;
                }
                inv.AddItemAmount(displaynameToDataBlock["mp5a4"], 2, pref);
                inventory.AddItemAmount(displaynameToDataBlock["arrow"], 5, pref);
                var test5 = displaynameToDataBlock["arrow"];
                var test2 = displaynameToDataBlock["arrow"];
                if (getcahcedbuletitem != null && getcahcedbuletitem is BulletWeaponItem<BulletWeaponDataBlock>)
                {

                    var test = getcahcedbuletitem as BulletWeaponItem<BulletWeaponDataBlock>;
                    if(test == null)
                        return;
                    inventory.SetActiveItemManually(1, test.itemRepresentation);
                    test.datablock.maxClipAmmo = 1000;


                    test.itemRepresentation.Action(3, uLink.RPCMode.Owner);
                    test.datablock.recoilPitchMin = 0.0f;
                    test.datablock.recoilPitchMax = 0.0f;
                    test.datablock.recoilYawMin = 0.0f;
                    test.datablock.recoilYawMax = 0.0f;
                    test.datablock.aimSway = 0.0f;
                    test.datablock.aimSwaySpeed = 0.0f;
                    test.itemRepresentation.Action(3, uLink.RPCMode.Server);
                    test.itemRepresentation.Action(1, uLink.RPCMode.Server);
                    if (test.clipAmmo <= 100)
                        test.itemRepresentation.Action(3, uLink.RPCMode.Server);
                }
                if(getcahcedbuletitem.isInLocalInventory)
                {
                }
                */
            
        }
        public bool Getplayerthroughmessage(NetUser netuser, string message)
        {
            return true;
        }
        public bool checklogforplayer(NetUser netUser, string message)
        {
           
                var realtime = UnityEngine.Time.realtimeSinceStartup;
                SendReply(netUser, "No log de jogadores");
                var displayNamesas = PlayerClient.All.Select(pc => pc.netUser.displayName).ToList();
                var displayNames = message.ToList();
                displayNamesas.Sort();
                StringBuilder sb = new StringBuilder(0 + 25);
                int totalPlayersAdded = 0;
                for (int i = 0; i < displayNames.Count; i++)
                {
                    if (totalPlayersAdded < 1 && (sb.Length + displayNamesas[i].Length) < 1)
                    {
                        sb.Append(displayNames[i]);
                        totalPlayersAdded += 1;
                    }
                    if (totalPlayersAdded == 1)
                    {
                        rust.SendChatMessage(netUser, "chatname", sb.ToString().TrimEnd(' ', ','));
                        sb.Length = 0;
                        totalPlayersAdded = 0;
                    }
                    else if ((sb.Length + displayNamesas[i].Length) >= 0)
                    {
                        rust.SendChatMessage(netUser, "chatname", sb.ToString().TrimEnd(' ', ','));
                        sb.Length = 0;
                        totalPlayersAdded = 1;
                        sb.Append(displayNamesas[i]);
                        sb.Append(", ");
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                }
                if (sb.Length > 0)
                {
                    rust.SendChatMessage(netUser, sb.ToString().TrimEnd(' ', ','));
                    return true;
                }

            return false;
          
        }
        object canTeleport(NetUser netuser)
        {
            
                CompanionCheck phandler = netuser.playerClient.GetComponent<CompanionCheck>();
                if (phandler == null)
                    return null;
           
            return "Você não pode se teletransportar daqui";
        }
        void OnPlayerDisconnected(uLink.NetworkPlayer netplayer)
        {
            
                var netuser = netplayer.GetLocalData<NetUser>();
                var ID = netuser.userID.ToString();
                var Name = netuser.displayName;
                string targetIDD = PlayerDatabase?.Call("GetPlayerData", ID, "steamid").ToString();
                PlayerClient player = ((NetUser)netplayer.GetLocalData()).playerClient;

                var vrum = GetPlayerdata4("PlayerKickado");

                ulong playerid = Convert.ToUInt64(ID);




                if (testando.Contains(ID))
                {
                    testando.Remove(ID);
                }

                if (player == null)
                    return;

                if (ShouldAllowCheckIfPlayerWithBadNameReconnect)
                {
                    var Tester = GetPlayerdata("SuspectPlayersTested(log.pl)");
                    if (Tester.ContainsKey(player.userID.ToString()))
                        Tester.Remove(player.userID.ToString());
                }

                CompanionCheck phandler = player.GetComponent<CompanionCheck>();
                if (vrum.ContainsKey(targetIDD))
                {
                    return;
                }
                if (phandler == null)
                    return;
                if (phandler != null)
                {
                    if (!falldamageenabled)
                        ConsoleSystem.Run("falldamage.enabled false", false);
                    GameObject.Destroy(phandler);
                }

                if (shouldbanifplayerdcduringtest)
                {
                    if (ShouldDisreGardIfKickedForViolation)
                    {
                        var Reason = player.netUser.truthDetector.NoteMoved(ref player.lastKnownPosition, player.controllable.eyesAngles, 20.0);
                        if (Reason.ToString() != "None")
                        {
                            var targetNome = PlayerDatabase?.Call("GetPlayerData", ID, "name").ToString();
                            var targetIp = PlayerDatabase?.Call("GetPlayerData", ID, "ip").ToString();
                            Disconnect(phandler, ID);
                            BanList.Add(player.userID, player.userName, "-    (Disconnect durante o teste)    -");
                            BanList.Save();
                            ipban2(netuser.playerClient, Name + " -    (Disconnect durante o teste)    -", targetIp);
                            return;
                        }

                    }
                    if (true)
                    {
                        if (shouldbepinglienient)
                        {
                            var ping = player.netUser.networkPlayer.averagePing;
                            if (ping != null)
                                if (ping >= int.Parse(pinglimitbeforeignore.ToString()))
                                    return;
                        }

                        numberofcheckevade++;
                        if (!BanList.Contains(player.userID))
                        {


                            AdminCompanionBroadcastplayerr(player.userName + " [color red]foi banido por uso de cheat [color red] -  ( [color white]Disconnect-Test[color red] )");
                            Disconnect(phandler, ID);
                        }
                        if (!BanList.Contains(player.userID))
                        {
                            var targetNome = PlayerDatabase?.Call("GetPlayerData", ID, "name").ToString();
                            var targetIp = PlayerDatabase?.Call("GetPlayerData", ID, "ip").ToString();
                            BanList.Add(player.userID, player.userName, "-    (Disconnect durante o teste)    -");
                            BanList.Save();
                            ipban2(netuser.playerClient, Name + " -    (Disconnect durante o teste)    -", targetIp);
                            return;
                        }
                    }


                }
            
        }
        public static string MessageToSendHelp(string VarChar)
        {

            foreach (KeyValuePair<string, string> pair in DefaultTriggers)
            {
                if (pair.Key.ToLower().Contains(","))
                {
                    string TOTAL = pair.Key.ToLower() + "*";
                    int pFrom = TOTAL.IndexOf(",");
                    int pTo = TOTAL.LastIndexOf("*");
                    string result = TOTAL.Substring(pFrom, pTo - pFrom);

                    if (result.Contains(","))
                    {

                        var indexFinal = result.IndexOf(",");
                        result = result.Remove(indexFinal, 1);
                    }


                    string TOTAL2 = "* " + pair.Key.ToLower();
                    int pFrom2 = TOTAL2.LastIndexOf(",");
                    int pTo2 = TOTAL2.IndexOf("*");

                    string result2 = TOTAL2.Substring(pTo2, pFrom2 - pTo2);

                    if (result2.Contains(","))
                    {

                        var indexFinal2 = result2.IndexOf(",");
                        result2 = result2.Remove(indexFinal2, 1);
                    }
                    if (result2.Contains("*"))
                    {

                        var indexFinal23 = result2.IndexOf("*");
                        result2 = result2.Remove(indexFinal23, 1);
                    }
                    if (result.Contains(","))
                    {
                        var indexFinal234 = result.IndexOf(",");
                        result = result.Remove(indexFinal234, 1);
                    }


                    if (VarChar.ToLower().Contains(result2.ToLower()) && VarChar.ToLower().Contains(result.ToLower()))
                        return pair.Value;
                }
                if (VarChar.ToLower().Contains(pair.Key.ToLower()))
                    return pair.Value;
            }
            return null;
        }
        public static string ServerIP = "198.27.86.106";
        object OnPlayerChat(NetUser netuser, string message)
        {
            var MessageResult = MessageToSendHelp(message);
            if (MessageResult != null)
            {
                if (!hascalled.ContainsKey(netuser.playerClient.userID.ToString()))
                {
                    var message23 = MessageResult;
                    rust.Notice(netuser, message23, icon, float.Parse(duration.ToString()));
                    hascalled.Add(netuser.playerClient.userID.ToString(), "1");
                    return null;
                }

                var totalhascalled = Convert.ToSingle(hascalled[netuser.playerClient.userID.ToString()]);
                var newtotal = totalhascalled + 1f;
                if (newtotal > 3)
                    return null;
                hascalled.Remove(netuser.playerClient.userID.ToString());
                hascalled.Add(netuser.playerClient.userID.ToString(), newtotal.ToString());
                totalhascalled++;
                if (float.Parse(totalhascalled.ToString()) <= 5f)
                {
                    var message2 = MessageResult;
                    rust.Notice(netuser, message2, icon, float.Parse(duration.ToString()));
                }
            }

            CompanionCheck phandler = netuser.playerClient.GetComponent<CompanionCheck>();
            if (shouldignore)
                if (phandler != null)
                    if (!phandler.hasselectedlanguage)
                        if (phandler.numberoffakecalls >= int.Parse(numberoffakecallslmit.ToString()))
                        {
                            SendReply(netuser, "Não vai mais tomar entrada de você você terá que usar o meu dicionário Inglês");
                            var data = Getplayerdatastore(netuser.playerClient.userID.ToString());
                            if (!data.ContainsKey("Language"))
                                data.Add("Language", "en");
                            phandler.forcefinish = true;
                            phandler.hasselectedlanguage = true;
                            return null;
                        }
            if (phandler != null)
                if (!phandler.hasselectedlanguage)
                {
                    if (!ShouldDetectChat)
                    {
                        SendReply(netuser, "Desculpe se me disseram para não detectar idiomas, use o idioma / lang - em vez disso!!!");
                        return null;
                    }

                    return null;
                }

            return null;

        }

        void IOnRecieveNetwork()
        {
            
                float now = Interface.Oxide.Now;
           
        }

        object OnDeny()
        {
            return false;
        }
        /////////////////////////
        // FIELDS
        /////////////////////////

        static Hash<PlayerClient, float> autoLoot = new Hash<PlayerClient, float>();

        static Hash<PlayerClient, float> wallhackLogs = new Hash<PlayerClient, float>();

        public static Core.Configuration.DynamicConfigFile ACData;
        private static FieldInfo getblueprints;
        private static FieldInfo getlooters;
        public static int groundsLayer = LayerMask.GetMask(new string[] { LayerMask.LayerToName(10), "Terrain" });
        public static ItemDataBlock wooddata;

        public static Vector3 Vector3ABitLeft = new Vector3(-0.03f, 0f, -0.03f);
        public static Vector3 Vector3ABitRight = new Vector3(0.03f, 0f, 0.03f);
        public static Vector3 Vector3NoChange = new Vector3(0f, 0f, 0f);

        /////////////////////////
        // CACHED FIELDS
        /////////////////////////
        public static Vector3 cachedvector3;
        public static WeaponImpact cachedWeapon;
        public static BulletWeaponImpact cachedBulletWeapon;
        public static OverKillHandler cachedOverkill;
        public static int cachedInt;
        string chatprefix = "✯NovaLand✯";
        /////////////////////////
        // Config Management
        /////////////////////////
        public static bool permanent = true;
        public static float timetocheck = 3600f;
        public static bool punishByBan = true;
        public static bool punishByKick = true;
        public static bool broadcastAdmins = true;
        public static bool broadcastPlayers = true;

        int checkarplayer = 20;

        public static bool antiSpeedHack = true;
        public static float speedMinDistance = 11f;
        public static float speedMaxDistance = 25f;
        public static float speedDropIgnore = 8f;
        public static float speedDetectionForPunish = 3;
        public static bool speedPunish = true;

        public static bool antiWalkSpeedhack = true;
        public static float walkspeedMinDistance = 6f;
        public static float walkspeedMaxDistance = 15f;
        public static float walkspeedDropIgnore = 8f;
        public static float walkspeedDetectionForPunish = 3;
        public static bool walkspeedPunish = true;

        public static bool antiSuperJump = true;
        public static float jumpMinHeight = 5f;
        public static float jumpMaxDistance = 25f;
        public static float jumpDetectionsNeed = 2f;
        public static float jumpDetectionsReset = 300f;
        public static bool jumpPunish = true;

        object cachedValue;
        string hurted = "";
        string hurtedId = "";
        string killerId = "";
        string UNKNOWN = "UNKNOWN";
        string killer = "";

        public static bool antiBlueprintUnlocker = true;
        public static bool blueprintunlockerPunish = true;

        public static bool antiAutoloot = true;
        public static bool autolootPunish = true;

        public static bool AntiSilentAim = true;
        public static bool AntiSilentAimPunish = true;
        public static bool AntiSilentAimBow = true;

        public static bool antiSleepingBagHack = true;
        public static bool sleepingbaghackPunish = true;

        public static bool antiOverKill = true;
        public static bool overkillPunish = true;
        public static Dictionary<string, object> overkillDictionary = GetWeaponsMaxDistance();
        public static float overkillResetTimer = 600f;
        public static float overkillDetectionForPunish = 2f;

        public static bool antiMassRadiation = true;

        public static bool antiNoRecoil = true;
        public static float norecoilDistance = 40f;
        public static bool norecoilPunish = false;
        public static int norecoilPunishMinKills = 2;
        public static int norecoilPunishMinRatio = 33;

        public static bool antiWallhack = true;
        public static bool wallhackPunish = true;
        public static int WallHackDetectionForPunish = 3;

        public static bool antiAutoGather = true;
        public static bool autogatherPunish = true;

        public static bool antiCeilingHack = true;
        public static bool ceilinghackPunish = true;

        public static bool antiFlyhack = true;
        public static float flyhackMaxDropSpeed = 5f;
        public static float flyhackDetectionsForPunish = 2;
        public static bool flyhackPunish = true;

        public static string playerHackDetectionBroadcast = "[color white]{0} [color red]foi banido por uso de cheat [color red] -  ( [color white]{1}[color red] )";
        public static string noAccess = "AntiCheat: Voce nao tem acesso a este comando";
        public static string noPlayerFound = "AntiCheat: Nenhum player encontrado com este nome";
        public static string checkingPlayer = "AntiCheat: {0} esta agora a ser verificado";
        public static string checkingAllPlayers = "AntiCheat: Verificacao de todos os players";
        public static string DataReset = "AntiCheat: Dados resetados, players serao fiscalizados!";

        private void CheckCfgFloat(string Key, ref float var)
        {

            if (Config[Key] != null)
                var = Convert.ToSingle(Config[Key]);
            else
                Config[Key] = var;
        }

        static Dictionary<string, object> GetWeaponsMaxDistance()
        {
            var newdict = new Dictionary<string, object>();
            newdict.Add("9mm Pistol", 150f);
            newdict.Add("Hunting Bow", 90f);
            newdict.Add("Pipe Shotgun", 100f);
            newdict.Add("HandCannon", 50f);
            newdict.Add("Revolver", 150f);
            newdict.Add("Hatchet", 12f);
            newdict.Add("Stone Hatchet", 13f);
            newdict.Add("Rock", 11f);
            newdict.Add("M4", 250f);
            newdict.Add("MP5A4", 250f);
            newdict.Add("P250", 250f);
            newdict.Add("Shotgun", 100f);
            newdict.Add("Bolt Action Rifle", 400f);
            newdict.Add("Pick Axe", 11f);
            return newdict;
        }


        /////////////////////////
        // PlayerHandler
        // Handles the player checks
        /////////////////////////

        public class PlayerHandler : MonoBehaviour
        {
            public float timeleft;
            public float lastTick;
            public float currentTick;
            public float deltaTime;
            public Vector3 lastPosition;
            public PlayerClient playerclient;
            public Character character;
            public Inventory inventory;
            public string userid;
            public float distance3D;
            public float distanceHeight;

            public float currentFloorHeight;
            public bool hasSearchedForFloor = false;

            public float lastSpeed = Time.realtimeSinceStartup;
            public int speednum = 0;


            public float lastWalkSpeed = Time.realtimeSinceStartup;
            public int walkspeednum = 0;
            public bool lastSprint = false;

            public float lastJump = Time.realtimeSinceStartup;
            public int jumpnum = 0;


            public float lastFly = Time.realtimeSinceStartup;
            public int flynum = 0;

            public int noRecoilDetections = 0;
            public int noRecoilKills = 0;

            public float lastWoodCount = 0;

            void Awake()
            {
                lastTick = Time.realtimeSinceStartup;
                enabled = false;
            }
            public void StartCheck()
            {
                this.playerclient = GetComponent<PlayerClient>();
                this.userid = this.playerclient.userID.ToString();
                if (playerclient.controllable == null) return;
                this.character = playerclient.controllable.GetComponent<Character>();
                this.lastPosition = this.playerclient.lastKnownPosition;
                enabled = true;
            }
            void FixedUpdate()
            {
               
                    if (Time.realtimeSinceStartup - lastTick >= 1)
                    {
                        currentTick = Time.realtimeSinceStartup;
                        deltaTime = currentTick - lastTick;
                        distance3D = Vector3.Distance(playerclient.lastKnownPosition, lastPosition) / deltaTime;
                        distanceHeight = (playerclient.lastKnownPosition.y - lastPosition.y) / deltaTime;
                        checkPlayer(this);
                        lastPosition = playerclient.lastKnownPosition;
                        lastTick = currentTick;
                        if (!permanent)
                        {
                            if (this.timeleft <= 0f) EndDetection(this);
                            this.timeleft--;
                        }
                        this.hasSearchedForFloor = false;
                    }
                
            }
            public Inventory GetInventory()
            {
                if (this.inventory == null) this.inventory = playerclient.rootControllable.idMain.GetComponent<Inventory>();
                return this.inventory;
            }
            public Character GetCharacter()
            {
                if (this.character == null) this.character = playerclient.rootControllable.idMain.GetComponent<Character>();
                return this.character;
            }
            void OnDestroy()
            {
                
                    ACData[this.userid] = this.timeleft.ToString();
                
            }
        }

        /////////////////////////
        // CeilingHackHandler
        // Handles the ceiling hack checks, it should be much better then the old 1.18 version
        /////////////////////////
        public class CeilingHackHandler : MonoBehaviour
        {
            public Vector3 lastPosition;
            public PlayerClient playerclient;
            public float lastTick;
            public Vector3 cachedceiling;
            public bool checkingNewPos;

            void Awake()
            {
                
                    this.lastTick = Time.realtimeSinceStartup;
                    this.checkingNewPos = false;
                    this.playerclient = GetComponent<PlayerClient>();
                    this.lastPosition = this.playerclient.lastKnownPosition;
                    enabled = true;
               
            }

            void FixedUpdate()
            {
              
                    lastPosition = this.playerclient.lastKnownPosition;
                    if (!checkingNewPos)
                    {
                        this.lastTick = Time.realtimeSinceStartup;
                        if (lastPosition == default(Vector3)) return;
                        if (!MeshBatchPhysics.Raycast(lastPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) { DestroyCeilingHandler(this); return; }
                        if (cachedhitInstance == null) { DestroyCeilingHandler(this); return; }
                        if (!cachedhitInstance.graphicalModel.ToString().Contains("ceiling")) { DestroyCeilingHandler(this); return; }
                        cachedceiling = cachedRaycast.point;
                        checkingNewPos = true;
                    }
                    else
                    {
                        if (Time.realtimeSinceStartup - this.lastTick < 1f) return;
                        if (MeshBatchPhysics.Raycast(lastPosition, Vector3Up, out cachedRaycast, out cachedBoolean, out cachedhitInstance))
                        {
                            cachedvector3 = cachedceiling - cachedRaycast.point;
                            if (cachedvector3.y > 0.6f)
                            {
                                cachedvector3 = cachedceiling - lastPosition;
                                if (cachedvector3.y > 1.5f && Math.Abs(cachedvector3.x) < 0.1f && Math.Abs(cachedvector3.z) < 0.1f)
                                {
                                    AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  CeilingHack ({1})", playerclient.userID.ToString(), playerclient.userName.ToString(), cachedvector3.y.ToString(), cachedceiling.ToString(), lastPosition.ToString()));
                                    if (ceilinghackPunish) Punish(playerclient, string.Format("CeilingHack", cachedvector3.y.ToString()));
                                }
                            }
                        }
                        DestroyCeilingHandler(this);
                    }
               
            }
        }

        public static void BanPlayer(NetUser netuser, string reason = "Unkown", bool IPBan = false)
        {
            var ping = netuser.playerClient.netUser.networkPlayer.averagePing;

            netuser.Kick(NetError.ConnectionBanned, true);
            BanList.Add(netuser.userID, netuser.displayName, "SilentAim");
            BanList.Save();
        }

        public static Dictionary<NetUser, object> HealPl = new Dictionary<NetUser, object>();
        public static Dictionary<NetUser, float> NetUserSilentAimDetections = new Dictionary<NetUser, float>();
        static void DestroyCeilingHandler(CeilingHackHandler ceilinghandler)
        {
            
                GameObject.Destroy(ceilinghandler);
            
        }


        public class NoRecoilHandler : MonoBehaviour
        {
            public int Kills = 0;
            public int NoRecoils = 0;
            public Character character;
            public PlayerClient playerClient;

            void Awake()
            {
                enabled = false;
                this.playerClient = GetComponent<PlayerClient>();
            }
            public Character GetCharacter()
            {
                if (this.character == null) this.playerClient.controllable.GetComponent<Character>();
                return this.character;
            }
        }

        public class OverKillHandler : MonoBehaviour
        {
            public float lastOverkill = Time.realtimeSinceStartup;
            public float number = 0f;

            void Awake()
            {
                enabled = false;
            }
        }
        /////////////////////////
        // Oxide Hooks
        /////////////////////////

        /////////////////////////
        //  Loaded()
        // Called when the plugin is loaded
        /////////////////////////
        void Loaded()
        {
           
                permission.RegisterPermission("cananticheat", this);
                permission.RegisterPermission("canimmunityanticheat", this);
                permission.RegisterPermission("anticheatbroadcast", this);
                LoadData();

                timer.Repeat(checkarplayer, 0, () =>
                {
                   
                        foreach (PlayerClient player in PlayerClient.All)
                        {
                            CheckPlayer(player, false);
                        }
                    
                });
           
        }
        /////////////////////////
        //  Loaded()
        // Called when the server was initialized (when people can start joining)
        /////////////////////////
        /////////////////////////
        // OnServerSave()
        // Called when the server saves
        // Perfect to save data here!
        /////////////////////////
        void OnServerSave()
        {
            
                SaveData();
            
        }

        /////////////////////////
        // Unload()
        // Called when the plugin gets unloaded or reloaded
        /////////////////////////


        /////////////////////////
        // OnItemRemoved(Inventory inventory, int slot, IInventoryItem item)
        // Called when an item was removed from a none player inventory
        /////////////////////////
        /*void OnItemRemoved(Inventory inventory, int slot, IInventoryItem item)
        {
            if (antiAutoloot && inventory.name == "SupplyCrate(Clone)") { CheckSupplyCrateLoot(inventory); return; }

        }*/

        /////////////////////////
        // OnItemCraft(CraftingInventory inventory, BlueprintDataBlock bp, int amount, ulong starttime)
        // Called when a player starts crafting an object
        /////////////////////////
        void OnItemCraft(CraftingInventory inventory, BlueprintDataBlock bp, int amount, ulong starttime)
        {
            
                if (!antiBlueprintUnlocker) return;
                var inv = inventory.GetComponent<PlayerInventory>();
                var blueprints = (List<BlueprintDataBlock>)getblueprints.GetValue(inv);
                if (blueprints.Contains(bp)) return;
                NetUser netuser = inventory.GetComponent<Controllable>().playerClient.netUser;
                if (blueprintunlockerPunish) Punish(inventory.GetComponent<Controllable>().playerClient, string.Format("BlueprintUnlocker ", bp.resultItem.name.ToString()));
            
        }

        /////////////////////////
        // ModifyDamage(TakeDamage takedamage, DamageEvent damage)
        // Called when any damage was made
        /////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="takedamage"></param>
        /// <param name="damage"></param>
        /// <returns></returns>
        /// 

        public static void UngodPlayer(NetUser netuser)
        {
            
                if (HealPl.ContainsKey(netuser))
                    HealPl.Remove(netuser);
                if (netuser == null || netuser.disposed)
                    return;
                if (netuser.playerClient.controllable == null)
                    return;

                var VictimCharacter = netuser.playerClient.rootControllable.rootCharacter;
                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                VictimCharacter.takeDamage.maxHealth = 100f;
                VictimCharacter.takeDamage.health = 100f;
            
        }

        public static void Heal(NetUser netuser)
        {
            
                if (netuser == null)
                    return;
                if (netuser.disposed)
                    return;
                if (netuser.playerClient == null)
                    return;
                if (netuser.playerClient.controllable == null || netuser.playerClient.controllable.health < 1)
                    return;
                //local hp = -100
                Character VictimCharacter = netuser.playerClient.rootControllable.rootCharacter;
                VictimCharacter.takeDamage.maxHealth = 100f;
                VictimCharacter.takeDamage.health = 100f;
                HumanBodyTakeDamage testc = netuser.playerClient.rootControllable.GetComponent<HumanBodyTakeDamage>();
                testc.SetBleedingLevel(0f);
                if (netuser.playerClient.rootControllable == null)
                    return;
                if (HealPl.ContainsKey(netuser))
                    return;
                ///float toMode = 0.35f;
                //if(HealPl.ContainsKey(netuser))
                //	toMode = HealPl[netuser];

                HealPl.Add(netuser, 1f);
                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                UngodPlayer(netuser);

                FallDamage falldamage = netuser.playerClient.rootControllable.GetComponent<FallDamage>();
                //PlayerHandler phandler = source.playerclient.GetComponent<PlayerHandler>();
                //phandler.hasdoneheal = true;
                if (testc == null)
                {
                }
                //testc.Bandage( 1000.0f );
                //falldamage.ClearInjury();



                //char.takeDamage.maxHealth = 100

            

        }

        [PluginReference]
        Plugin FriendsDatabase;

        object CancelDamage(DamageEvent damage)
        {
            
                damage.amount = 0f;
                damage.status = LifeStatus.IsAlive;
                if (FriendsDatabase != null)
                {
                    if (damage.attacker.client && damage.victim.client)
                    {
                        PlayerClient attacker = damage.attacker.client;
                        PlayerClient Victim = damage.victim.client;

                        var Friend = FriendsDatabase.CallHook("isFriend", Victim.userID.ToString(), attacker.userID.ToString());
                        Heal(Victim.netUser);
                        if (Friend is bool && (bool)Friend)
                        {

                            return null;
                        }
                    }
                }
                return damage;
           
        }

        object CanceDamage(DamageEvent damage)
        {
           
                damage.amount = 0f;
                damage.status = LifeStatus.IsAlive;
                return damage;
           
        }

        void RemoveSilentAimBowDetections(NetUser netuser)
        {
            
                if (netuser == null || netuser.disposed)
                    return;

                if (NetUserSilentAimDetections.ContainsKey(netuser))
                    NetUserSilentAimDetections.Remove(netuser);
           
        }
        object ModifyDamage(TakeDamage takedamage, ref DamageEvent damage)
        {
            

                killerId = damage.attacker.client?.netUser.userID.ToString() ?? UNKNOWN;
                killer = damage.attacker.client?.netUser.displayName ?? UNKNOWN;
                NetUser killeruser = damage.attacker.client?.netUser ?? null;
                NetUser hurteduser = damage.victim.client?.netUser ?? null;
                hurted = damage.victim.client?.netUser.displayName ?? UNKNOWN;
                hurtedId = damage.victim.client?.netUser.userID.ToString() ?? UNKNOWN;
                cachedValue = Interface.CallHook("isFriend", killerId, hurtedId);

                /*if (antiMassRadiation && (damage.damageTypes == 0 || damage.damageTypes == DamageTypeFlags.damage_radiation) )
                {
                    if (takedamage.GetComponent<Controllable>() == null) return null;
                    if (damage.victim.character == null) return null;
                    if (float.IsInfinity(damage.amount)) return null;
                    if (damage.amount > 12f) { AntiCheatBroadcastAdmins(string.Format("{0} is receiving too much damage from the radiation, ignoring the damage", takedamage.GetComponent<Controllable>().playerClient.userName.ToString())); damage.amount = 0f; return damage; }
                }
                else */

                if ((damage.extraData is BulletWeaponImpact))
                {
                    NetUser ParentUser = damage.attacker.client.netUser;
                    var bullet2 = damage.extraData as BulletWeaponImpact;
                    float Distance34 = Vector3.Distance(bullet2.worldPoint, damage.victim.id.transform.position);
                    if (damage.victim.character)
                        if (Distance34 > 20)
                        {
                            AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  SilentAimbot ({1})", damage.attacker.client.userName, Distance34));
                            //broad(damage.attacker.client.netUser.displayName + " Has been banned for using SilentAim ");
                            if (AntiSilentAimPunish)
                            {
                                Punish(damage.attacker.client, "SilentAimbot");

                            }
                            return CanceDamage(damage);
                        }
                }

                if (cachedValue is bool && (bool)cachedValue)
                {
                    rust.InventoryNotice(killeruser, hurted + " é seu amigo!");
                    return CanceDamage(damage);
                }

                if (antiWallhack)
                {
                    if (killeruser.CanAdmin())
                    {
                        return true;
                    }

                    if (AnticheatImuunity(killeruser))
                    {
                        return true;
                    }

                    if (damage.status != LifeStatus.WasKilled) return null;
                    if (!(damage.extraData is BulletWeaponImpact)) return null;
                    cachedBulletWeapon = damage.extraData as BulletWeaponImpact;
                    cachedWeapon = damage.extraData as WeaponImpact;
                    if (!MeshBatchPhysics.Linecast(damage.attacker.character.eyesOrigin, cachedBulletWeapon.worldPoint, out cachedRaycast, out cachedBoolean, out cachedhitInstance)) return null;
                    if (cachedhitInstance == null) return null;
                    cachedCollider = cachedhitInstance.physicalColliderReferenceOnly;
                    if (cachedCollider == null) return null;
                    if (!(cachedCollider.gameObject.name.Contains("Wall") || cachedCollider.gameObject.name.Contains("Ceiling"))) return null;
                    //Debug.Log(string.Format("Wallhack detectado em {0} em: {1} to: {2}", damage.attacker.client.userName, damage.attacker.character.eyesOrigin.ToString(), cachedBulletWeapon.worldPoint.ToString()));
                    AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  Wallhack {2}", damage.attacker.client.userName, cachedWeapon.dataBlock.name, damage.attacker.character.eyesOrigin.ToString(), cachedBulletWeapon.worldPoint.ToString()));
                    damage.status = LifeStatus.IsAlive;
                    damage.amount = 0f;
                    takedamage.SetGodMode(false);
                    takedamage.health = 10f;
                    if (takedamage.GetComponent<HumanBodyTakeDamage>() != null) takedamage.GetComponent<HumanBodyTakeDamage>().SetBleedingLevel(0f);
                    if (wallhackPunish)
                    {
                        if (wallhackLogs[damage.attacker.client] == null) wallhackLogs[damage.attacker.client] = Time.realtimeSinceStartup;
                        if ((wallhackLogs[damage.attacker.client] - Time.realtimeSinceStartup) > 3) wallhackLogs[damage.attacker.client] = Time.realtimeSinceStartup;

     
                            string nome = killeruser.displayName;
                            string steamid = killeruser.userID.ToString();
                            CompanionCheck phandler = damage.attacker.client.GetComponent<CompanionCheck>();
                            if (phandler == null) { phandler = damage.attacker.client.gameObject.AddComponent<CompanionCheck>(); }
                            if (phandler == null)
                                ConsoleSystem.Run("oxide.reload AdminCompanion");
                            if (!testando.Contains(steamid))
                                    {
                                        testando.Add(steamid);
                                        AdminCompanionBroadcastplayerr("[color white]O jogador [color orange]" + nome + " [color white]foi enviado para o teste ( [color cyan]Automatico [color white])");
                                        STimer.Once(0.3f, () =>
                                        {
                                           
                                                killeruser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                                                phandler.StartCheck();
                                            
                                        });

                                    }
                    }
                    return damage;
                }

            return null;
          
        }
        /////////////////////////
        // OnPlayerSpawn(PlayerClient player, bool useCamp, RustProto.Avatar avatar)
        // Called when a player spawns (after connection or after death)
        /////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="useCamp"></param>
        /// <param name="avatar"></param>
        /// 


        void SilentAimCheck(NetUser netuser, int ammo, int Detection = 0)
        {
            
                Debug.Log("Attack ? " + netuser.playerClient.controllable.stateFlags.attack2);
                if (netuser.playerClient.controllable.stateFlags.attack == false)
                {
                    int D = Detection + 1;
                    if (Detection < 12)
                    {
                        timer.Once(0.01f, () => SilentAimCheck(netuser, D));
                    }
                }
           

        }

        /////////////////////////
        // OnPlayerConnected(NetUser netuser)
        // Called when a player connects
        /////////////////////////

        /////////////////////////
        // OnPlayerConnected(NetUser netuser)
        // Called when a player connects
        /////////////////////////
        ///
        void CheckOverKill(TakeDamage takedamage, DamageEvent damage)
        {
            
                NetUser killeruser = damage.attacker.client?.netUser ?? null;
                if (!(damage.extraData is WeaponImpact)) return;
                cachedWeapon = damage.extraData as WeaponImpact;
                if (cachedWeapon.dataBlock == null) return;
                if (!overkillDictionary.ContainsKey(cachedWeapon.dataBlock.name)) return;
                if (damage.victim.networkView == null) return;
                if (Vector3.Distance(damage.attacker.networkView.position, damage.victim.networkView.position) < Convert.ToSingle(overkillDictionary[cachedWeapon.dataBlock.name])) return;
                cachedOverkill = damage.attacker.client.GetComponent<OverKillHandler>();
                if (cachedOverkill == null) cachedOverkill = damage.attacker.client.gameObject.AddComponent<OverKillHandler>();
                if (Time.realtimeSinceStartup - cachedOverkill.lastOverkill > overkillResetTimer) cachedOverkill.number = 0f;
                cachedOverkill.lastOverkill = Time.realtimeSinceStartup;
                cachedOverkill.number++;
                AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  OverKill ({1} - {2}m)", damage.attacker.client.userName, cachedWeapon.dataBlock.name, Math.Floor(Vector3.Distance(damage.attacker.networkView.position, damage.victim.networkView.position)).ToString()));
                if (overkillPunish && cachedOverkill.number >= overkillDetectionForPunish)
                    Punish(damage.attacker.client, string.Format("OverKill", cachedWeapon.dataBlock.name, Math.Floor(Vector3.Distance(damage.attacker.networkView.position, damage.victim.networkView.position)).ToString()));
           
        }
        void CheckSilenceKill(TakeDamage takedamage, DamageEvent damage)
        {
           
                if (damage.victim.networkView == null) return;

                if (!(damage.extraData is WeaponImpact)) return;
                cachedWeapon = damage.extraData as WeaponImpact;
                if (cachedWeapon.dataBlock == null) return;
                if (Physics2.Raycast2(damage.attacker.client.controllable.GetComponent<Character>().eyesRay, out cachedRaycast2, 250f, 406721553))
                {
                    var componenthit = (cachedRaycast2.remoteBodyPart == null) ? ((Component)cachedRaycast2.collider) : ((Component)cachedRaycast2.remoteBodyPart);
                    Debug.Log(componenthit.ToString());
                    Debug.Log(cachedRaycast2.distance.ToString());
                    return;
                }
                Debug.Log("NO HIT");
            
        }
        void CheckNoRecoil(TakeDamage takedamage, DamageEvent damage)
        {
            
                if (damage.victim.networkView == null) return;
                if (damage.damageTypes != DamageTypeFlags.damage_bullet) return;
                if (Vector3.Distance(damage.attacker.networkView.position, damage.victim.networkView.position) < norecoilDistance) return;
                NoRecoilHandler norecoilhandler = damage.attacker.client.GetComponent<NoRecoilHandler>();
                if (norecoilhandler == null) norecoilhandler = damage.attacker.client.gameObject.AddComponent<NoRecoilHandler>();
                norecoilhandler.Kills++;
                Character character = damage.attacker.character;
                norecoilhandler.character = character;
                var eyeangles = (Angle2)character.eyesAngles;
                timer.Once(0.3f, () =>
                {
                   
                        CheckNewAngles(norecoilhandler, eyeangles, Time.realtimeSinceStartup);
                   
                });
            
        }
        void CheckNewAngles(NoRecoilHandler norecoilhandler, Angle2 oldAngles, float lasttimestamp)
        {
            
                Character character = norecoilhandler.GetCharacter();
                NetUser netuser = norecoilhandler.playerClient.netUser;
                if (netuser.CanAdmin())
                {
                    return;
                }
                if (AnticheatImuunity(netuser))
                {
                    return;
                }

                if (character == null) return;
                if ((lasttimestamp - Time.realtimeSinceStartup) > 0.5f) return;
                if (oldAngles != character.eyesAngles) return;
                norecoilhandler.NoRecoils++;
                AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  NoRecoil ({1} detections - {2} kills)", norecoilhandler.playerClient.userName, norecoilhandler.NoRecoils.ToString(), norecoilhandler.Kills.ToString()));
                if (!norecoilPunish) return;
                if (norecoilhandler.Kills < norecoilPunishMinKills) return;
                if (norecoilhandler.NoRecoils / norecoilhandler.Kills < norecoilPunishMinRatio / 100) return;


                    string nome = netuser.displayName;
                    string steamid = netuser.userID.ToString();
                    CompanionCheck phandler = norecoilhandler.playerClient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = norecoilhandler.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                    if (phandler == null)
                        ConsoleSystem.Run("oxide.reload AdminCompanion");

                    if (!testando.Contains(steamid))
                    {
                        testando.Add(steamid);
                        AdminCompanionBroadcastplayerr("[color white]O jogador [color orange]" + nome + " [color white]foi enviado para o teste ( [color cyan]Automatico [color white])");
                        STimer.Once(0.3f, () =>
                        {
                           
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                                phandler.StartCheck();
                            
                        });

                }
            
        }

        void OnKilled(TakeDamage takedamage, DamageEvent damage)
        {
            
                if (antiOverKill)
                {
                    CheckOverKill(takedamage, damage);
                }
                if (antiNoRecoil)
                {
                    CheckNoRecoil(takedamage, damage);
                }
           
           
        }

        void OnItemDeployedByPlayer(DeployableObject component, IDeployableItem item)
        {
           
                if (!antiSleepingBagHack) return;
                if (component.gameObject.name == "SleepingBagA(Clone)" || component.gameObject.name == "SingleBed(Clone)")
                {
                    if (!item.character) return;
                    if (!(MeshBatchPhysics.Linecast(item.character.eyesOrigin, component.transform.position, out cachedRaycast, out cachedBoolean, out cachedhitInstance))) return;
                    if (cachedhitInstance == null && cachedRaycast.collider.gameObject.name != "MetalDoor(Clone)") return;
                    if (Vector3.Distance(item.character.eyesOrigin, component.transform.position) > 9f) return;
                    if (component.transform.position.y - item.character.eyesOrigin.y > 1f) return;
                    AntiCheatBroadcastAdmins(string.Format("{0} tried to spawn a {1} @ {2} from {3}", item.character.playerClient.userName, component.gameObject.name.Replace("(Clone)", ""), component.transform.position.ToString(), item.character.eyesOrigin.ToString()));
                    AntiCheatBroadcastAdmins(string.Format("{0} was on the way", (cachedhitInstance == null) ? "Metal Door" : cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.Replace("(Clone)", "")));
                    Puts(string.Format("{0} tried to spawn a {1} @ {2} from {3} threw {4}", item.character.playerClient.userName, component.gameObject.name.Replace("(Clone)", ""), component.transform.position.ToString(), item.character.eyesOrigin.ToString(), (cachedhitInstance == null) ? "Metal Door" : cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.Replace("(Clone)", "")));
                    NetCull.Destroy(component.gameObject);
                    if (sleepingbaghackPunish)
                        Punish(item.character.playerClient, string.Format("SleepHack ", (cachedhitInstance == null) ? "Metal Door" : cachedhitInstance.physicalColliderReferenceOnly.gameObject.name.Replace("(Clone)", "")));

                }
           
        }

        //////////////////////////////////
        // AntiCheat Handler functions //
        /////////////////////////////////


        /*NetUser GetLooter(Inventory inventory)
        {
            foreach (uLink.NetworkPlayer netplayer in (HashSet<uLink.NetworkPlayer>)getlooters.GetValue(inventory))
            {
                return (NetUser)netplayer.GetLocalData();
            }
            return null;
        }*/
        static void EndDetection(PlayerHandler player)
        {
           
                GameObject.Destroy(player);
            
        }
        static bool PlayerHandlerHasGround(PlayerHandler player)
        {
            if (!player.hasSearchedForFloor)
            {
                if (Physics.Raycast(player.playerclient.lastKnownPosition + UnderPlayerAdjustement, Vector3Down, out cachedRaycast, distanceDown))
                    player.currentFloorHeight = cachedRaycast.distance;
                else
                    player.currentFloorHeight = 10f;
            }
            player.hasSearchedForFloor = true;
            if (player.currentFloorHeight < 4f) return true;
            return false;
        }
        static bool IsOnSupport(PlayerHandler player)
        {
            foreach (Collider collider in Physics.OverlapSphere(player.playerclient.lastKnownPosition, 5f))
            {
                if (collider.GetComponent<UnityEngine.MeshCollider>())
                    return true;
            }
            return false;
        }
        public static void checkPlayer(PlayerHandler player)
        {
            
                NetUser netuser = player.playerclient.netUser;
                if (netuser.CanAdmin())
                {
                    return;
                }
                if (AnticheatImuunity(netuser))
                {
                    return;
                }

                if (antiSpeedHack)
                    checkSpeedhack(player);
                //if(antiWalkSpeedhack)
                //    checkWalkSpeedhack(player);
                if (antiSuperJump)
                    checkSuperjumphack(player);
                if (antiFlyhack)
                    checkAntiflyhack(player);
                //if (antiAutoGather)
                // checkAutoGather(player);
           
            
        }
        public static void checkAutoGather(PlayerHandler player)
        {
           
                Inventory inv = player.GetInventory();
                if (inv.activeItem == null) return;
                inv.FindItem(wooddata, out cachedInt);
                Debug.Log(cachedInt.ToString());
                if (Physics.Raycast(player.GetCharacter().eyesRay, out cachedRaycast))
                    Debug.Log(cachedRaycast.collider.ToString());
           
        }
        public static void checkAntiflyhack(PlayerHandler player)
        {
            

                NetUser netuser = player.playerclient.netUser;

                if (netuser.CanAdmin())
                {
                    return;
                }
                if (AnticheatImuunity(netuser))
                {
                    return;
                }

                if (player.distance3D == 0f) { player.flynum = 0; return; }
                if (PlayerHandlerHasGround(player)) { player.flynum = 0; return; }
                if (player.distanceHeight < -flyhackMaxDropSpeed) { player.flynum = 0; return; }
                if (IsOnSupport(player)) { player.flynum = 0; return; }
                if (player.lastFly != player.lastTick) { player.flynum = 0; player.lastFly = player.currentTick; return; }
                player.flynum++;
                player.lastFly = player.currentTick;
                AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  Flyhack ({1}m/s)", player.playerclient.userName, player.distance3D.ToString()));
                if (player.flynum < flyhackDetectionsForPunish) return;



             
                    string nome = netuser.displayName;
                    string steamid = netuser.userID.ToString();
                    CompanionCheck phandler = player.playerclient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = player.playerclient.gameObject.AddComponent<CompanionCheck>(); }
                    if (phandler == null)
                        ConsoleSystem.Run("oxide.reload AdminCompanion");

                    if (!testando.Contains(steamid))
                    {
                        testando.Add(steamid);
                        AdminCompanionBroadcastplayerr("[color white]O jogador [color orange]" + nome + " [color white]foi enviado para o teste ( [color cyan]Automatico [color white])");
                        STimer.Once(0.3f, () =>
                        {
                            
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                                phandler.StartCheck();
                           
                        });
                    }
            
        }
        public static void checkSuperjumphack(PlayerHandler player)
        {
       
                NetUser netuser = player.playerclient.netUser;

                if (AnticheatImuunity(netuser))
                {
                    return;
                }

                if (netuser.CanAdmin())
                {
                    return;
                }

                if (player.distanceHeight < jumpMinHeight) { return; }
            if (player.distance3D > jumpMaxDistance) { return; }
            if (PlayerHandlerHasGround(player)) return;
            if (player.currentTick - player.lastJump > jumpDetectionsReset) player.jumpnum = 0;
            player.lastJump = player.currentTick;
            player.jumpnum++;
            AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  SuperJump ({1}m/s)", player.playerclient.userName, player.distanceHeight.ToString()));
            if (player.jumpnum < jumpDetectionsNeed) return;

            if (jumpPunish)
            {
                    

                    string nome = netuser.displayName;
                    string steamid = netuser.userID.ToString();
                    CompanionCheck phandler = player.playerclient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = player.playerclient.gameObject.AddComponent<CompanionCheck>(); }
                    if (phandler == null)
                        ConsoleSystem.Run("oxide.reload AdminCompanion");

                    if (!testando.Contains(steamid))
                    {
                        testando.Add(steamid);
                        AdminCompanionBroadcastplayerr("[color white]O jogador [color orange]" + nome + " [color white]foi enviado para o teste ( [color cyan]Automatico [color white])");
                        STimer.Once(0.3f, () =>
                        {
                           
                                netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                                phandler.StartCheck();
         
                          
                        });

                    }
            }
        
        }
        /*public static void checkWalkSpeedhack(PlayerHandler player)
        {
        
            if (player.character.stateFlags.sprint) { player.lastSprint = true; player.walkspeednum = 0; return; }
            if (player.distanceHeight < -walkspeedDropIgnore) { player.walkspeednum = 0; return; }
            if (player.distance3D < walkspeedMinDistance) { player.walkspeednum = 0; return; }
            if (!player.character.stateFlags.grounded) { player.lastSprint = true; player.walkspeednum = 0; return; }
            if (player.lastSprint) { player.lastSprint = false; player.walkspeednum = 0; return; }
            if (player.lastWalkSpeed != player.lastTick) { player.walkspeednum = 0; player.lastWalkSpeed = player.currentTick; return; }
            
            player.walkspeednum++;
            player.lastWalkSpeed = player.currentTick;
            AntiCheatBroadcastAdmins(string.Format("{0} - rWalkspeed ({1}m/s)", player.playerclient.userName, player.distance3D.ToString()));
            if (player.walkspeednum < walkspeedDetectionForPunish) return;
            if (walkspeedPunish) Punish(player.playerclient, string.Format("rWalkspeed ({0}m/s)", player.distance3D.ToString()));
        
        }*/
        public static void checkSpeedhack(PlayerHandler player)
        {
            
                NetUser netuser = player.playerclient.netUser;

                if (netuser.CanAdmin())
                {
                    return;
                }
                if (AnticheatImuunity(netuser))
                {
                    return;
                }

                if (Math.Abs(player.distanceHeight) > speedDropIgnore) { player.speednum = 0; return; }
                if (player.distance3D < speedMinDistance) { player.speednum = 0; return; }
                if (player.lastSpeed != player.lastTick) { player.speednum = 0; player.lastSpeed = player.currentTick; return; }
                player.speednum++;
                player.lastSpeed = player.currentTick;
                AntiCheatBroadcastAdmins(string.Format("[color red]{0}﹣  Speedhack ({1}m/s)", player.playerclient.userName, player.distance3D.ToString()));
                if (player.speednum < speedDetectionForPunish) return;
                if (speedPunish)
                {

                        

                        string nome = netuser.displayName;
                        string steamid = netuser.userID.ToString();
                        CompanionCheck phandler = player.playerclient.GetComponent<CompanionCheck>();
                        if (phandler == null) { phandler = player.playerclient.gameObject.AddComponent<CompanionCheck>(); }
                        if (phandler == null)
                            ConsoleSystem.Run("oxide.reload AdminCompanion");
                        if (!testando.Contains(steamid))
                                    {
                                        testando.Add(steamid);
                                        AdminCompanionBroadcastplayerr("[color white]O jogador [color orange]" + nome + " [color white]foi enviado para o teste ( [color cyan]Automatico [color white])");
                    STimer.Once(0.3f, () =>
                    {
                       
                            netuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                            phandler.StartCheck();
                       
                    });

            }
                                }
    
           
        }
        /*void CheckSupplyCrateLoot(Inventory inventory)
        {
        
            NetUser looter = GetLooter(inventory);
            if (looter == null) return;
            if (looter.playerClient == null) return;
            if (Vector3.Distance(inventory.transform.position, looter.playerClient.lastKnownPosition) > 10f)
            {
                if (autoLoot[looter.playerClient] != null)
                    if (Time.realtimeSinceStartup - autoLoot[looter.playerClient] < 1f)
                        if(autolootPunish)
                            Punish(looter.playerClient, string.Format("rAutoLoot ({0}m)", Vector3.Distance(inventory.transform.position, looter.playerClient.lastKnownPosition).ToString()));
                AntiCheatBroadcastAdmins(string.Format("{0} - rAutoLoot ({1}m)", looter.playerClient.userName, Vector3.Distance(inventory.transform.position, looter.playerClient.lastKnownPosition).ToString()));
                autoLoot[looter.playerClient] = Time.realtimeSinceStartup;
            }
        
        }*/

        static void AntiCheatBan(ulong userid, string name, string reason)
        {
            
                BanList.Add(userid, name, reason);
                BanList.Save();

        }
        static void Punish(PlayerClient player, string reason)
        {
           
                if (player.netUser.CanAdmin())
                {
                    //Debug.Log(string.Format("Ignore {0} porque e o admin admin.", player.userName));
                    if (player.GetComponent<PlayerHandler>() != null) GameObject.Destroy(player.GetComponent<PlayerHandler>());
                    return;
                }
                if (Spermission.UserHasPermission(player.userID.ToString(), "canimmunityanticheat"))
                {
                    //Debug.Log(string.Format("Ignore {0} porque e o admin admin.",player.userName));
                    if (player.GetComponent<PlayerHandler>() != null) GameObject.Destroy(player.GetComponent<PlayerHandler>());
                    return;
                }
                NetUser netuser = player.netUser;
                ulong userid = player.userID;
                string username = player.userName;
                string ip = netuser.networkPlayer.externalIP;
                if (punishByBan)
                {
                    AntiCheatBan(userid, username, reason);
                    ipban2(player, reason, ip);
                    Interface.CallHook("cmdBan", userid.ToString(), username, reason);
                    //Debug.Log(string.Format("[color white]{1} [color red]foi banido por {2} [color red]([color white]AntiCheat[color red])", userid.ToString(), username, reason));
                }
                PunishDiscord(player, reason);
                AntiCheatBroadcast(string.Format(playerHackDetectionBroadcast, username.ToString(), reason));
                if (punishByKick || punishByBan)
                {
                    if (player != null && player.netUser != null)
                        player.netUser.Kick(NetError.Facepunch_Kick_Violation, true);
                    //Debug.Log(string.Format("{1} foi kickado por {2}", userid.ToString(), username.ToString(), reason));
                }
            
        }
        static void AntiCheatBroadcast(string message)
        {
            
                if (!broadcastPlayers) return; ConsoleNetworker.Broadcast("chat.add Server \"" + message + "\"");
            
        }

        static void AntiCheatBroadcastAdmins(string message)
        {
            
                if (!broadcastAdmins) return;
                foreach (PlayerClient player in PlayerClient.All)
                {
                    if (player.netUser.CanAdmin())
                    {
                        ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Server \"" + message + "\"");
                        return;
                    }
                    if (Spermission.UserHasPermission(player.userID.ToString(), "anticheatbroadcast"))
                    {
                        ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Server \"" + message + "\"");
                        return;
                    }
                }
          
        }


        /////////////////////////
        // Data Management
        /////////////////////////
        float GetPlayerData(PlayerClient player)
        {
            if (ACData[player.userID.ToString()] == null) ACData[player.userID.ToString()] = timetocheck.ToString();
            if (hasPermission(player.netUser)) ACData[player.userID.ToString()] = "0.0";
            return Convert.ToSingle(ACData[player.userID.ToString()]);
        }

        /////////////////////////
        // Random functions
        /////////////////////////
        bool hasPermission(NetUser netuser)
        {
            if (netuser.CanAdmin()) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), "cananticheat");
        }

        static bool hasPermission2(NetUser netuser)
        {
            if (netuser.CanAdmin()) return true;
            return Spermission.UserHasPermission(netuser.playerClient.userID.ToString(), "cananticheat2");
        }

        void CheckPlayer(PlayerClient player, bool forceAdmin)
        {
            
                PlayerHandler phandler = player.GetComponent<PlayerHandler>();
                if (phandler == null) phandler = player.gameObject.AddComponent<PlayerHandler>();
                if (!forceAdmin && hasPermission(player.netUser)) phandler.timeleft = 0f;
                else phandler.timeleft = timetocheck;
                timer.Once(0.1f, () =>
                {
                    
                        phandler.StartCheck();
                   
                });
           
        }
        PlayerClient FindPlayer(string name)
        {
            foreach (PlayerClient player in PlayerClient.All)
            {
                if (player.userName == name || player.userID.ToString() == name) return player;
            }
            return null;
        }

        /////////////////////////
        // Console Commands
        /////////////////////////
        [ConsoleCommand("ac.check")]
        void cmdConsoleCheck(ConsoleSystem.Arg arg)
        {
            
                if ((arg.Args == null) || (arg.Args != null && arg.Args.Length == 0)) { SendReply(arg, "ac.check \"Name/SteamID\""); return; }
                if (arg.argUser != null && !hasPermission(arg.argUser)) { SendReply(arg, noAccess); return; }
                cachedPlayer = FindPlayer(arg.ArgsStr);
                if (cachedPlayer == null) { SendReply(arg, noPlayerFound); return; }
                CheckPlayer(cachedPlayer, true);
                SendReply(arg, checkingPlayer, cachedPlayer.userName);
           
        }

        [ConsoleCommand("ac.checkall")]
        void cmdConsoleCheckAll(ConsoleSystem.Arg arg)
        {
           
                if (arg.argUser != null && !hasPermission(arg.argUser)) { SendReply(arg, noAccess); return; }
                foreach (PlayerClient player in PlayerClient.All)
                {
                    CheckPlayer(player, false);
                }
                SendReply(arg, checkingAllPlayers);
           
        }

        [ConsoleCommand("ac.reset")]
        void cmdConsoleReset(ConsoleSystem.Arg arg)
        {
            
                if (arg.argUser != null && !hasPermission(arg.argUser)) { SendReply(arg, noAccess); return; }
                ACData.Clear();
                SaveData();
                foreach (PlayerClient player in PlayerClient.All)
                {
                    CheckPlayer(player, false);
                }
                SendReply(arg, DataReset);
            
        }

        public static Oxide.Core.Libraries.WebRequests swebrequest = GetLibrary<Oxide.Core.Libraries.WebRequests>();
        public static void NotStuctBack2(int code, string responde) { }

        static void PunishDiscord(PlayerClient player, string reason)
        {
            NetUser netuser = player.netUser;
            ulong userid = player.userID;
            string username = player.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls3()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {3} \nID: {1} \nMotivo: {2} \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, reason, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport3, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls3
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport3 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void Aspect(CompanionCheck player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls4()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: HackMenu-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport4, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls4
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport4 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void NoRecoil(CompanionCheck player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls5()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: NoRecoil-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport5, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls5
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport5 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void Aspect2(CompanionCheck player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls6()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \n IP: {2} \nID: {1} \nMotivo: Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport6, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls6
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport6 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void Aspect3(CompanionCheck2 player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls9()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: HackMenu-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport9, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls9
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport9 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void Nofall(CompanionCheck player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls7()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: NoFall-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport7, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls7
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport7 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void SpeedJump(CompanionCheck player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls8()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: SpeedJump-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport8, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls8
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport8 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        static void Afk(CompanionCheck player)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls10()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: Afk-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, ip)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport10, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls10
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport10 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

        void Disconnect(CompanionCheck player, string targeID)
        {
            NetUser netuser = player.playerclient.netUser;
            ulong id = netuser.userID;
            ulong userid = player.playerclient.userID;
            string username = player.playerclient.userName;
            string ip = netuser.networkPlayer.externalIP;
            string targetNome = PlayerDatabase?.Call("GetPlayerData", targeID, "name").ToString();
            string targetIp = PlayerDatabase?.Call("GetPlayerData", targeID, "ip").ToString();
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls11()
            {
                MessageText = string.Format("```\nBANIDO - NovaLandRust \n\nNick: {0} \nIP: {2} \nID: {1} \nMotivo: Disconnect-Test \nAutor: AntiCheat \n\nAtenciosamente equipe NovaLand```", username, userid, targetIp)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            swebrequest.EnqueuePost(CordSupport11, payloadJson, (code, response) => NotStuctBack2(code, response), new AdminCompanion(), plicksl);
        }
        class DisoverPls11
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        static string CordSupport11 = "https://discord.com/api/webhooks/901125056015511593/uSAlQ3-UgfQ2UaHhFDEFwtqZxvo_6-HvW-R1bzuzE8WoeK3rGtJ2axKDbfzCZDB2R2kb";

    }
}