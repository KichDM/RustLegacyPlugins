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
using Facepunch;
using uLink;
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
using Oxide.Core.Libraries;
using System.Linq;
using System.Text;
using uLink;
using Facepunch;
using Rust;
using InventoryExtensions;
using Facepunch.Cursor;
using Facepunch.Cursor.Internal;

namespace Oxide.Plugins
{
    [Info("Oz-ServerTest | Testeador de players", "Creador por Cooper | Editado por RiToz", "1.0")]
    class ServerTest : RustLegacyPlugin
    {
        public static string SystemName = "ServerTest";
        public static Dictionary<string, string> DefaultKeys = MenuKeyBinds();
        public static Dictionary<NetUser, NetUser> NetUsers5 = new Dictionary<NetUser, NetUser>();
        public static Dictionary<string, int> Tempo = new Dictionary<string, int>();
        public static Dictionary<string, string> DefaultTriggers = TrigersMSG();
        public static Dictionary<string, string> DefaultObjects1 = Keys();

        public static Dictionary<string, string> BadNameKick = BadNameKickInit();

        public static Dictionary<string, string> MenuKeyBinds()
        {
            var newdict = new Dictionary<string, string>();			
			newdict.Add("Insert", "Insert");
            newdict.Add("F2", "F2");
            newdict.Add("F5", "F5");
            newdict.Add("F4", "F4");
            newdict.Add("F3", "F3");
			newdict.Add("F6", "F6");
			newdict.Add("F7", "F7");
			newdict.Add("F8", "F8");
			newdict.Add("F9", "F9");
			newdict.Add("F10", "F10");
			newdict.Add("F11", "F11");
			newdict.Add("F12", "F12");
			newdict.Add("Mouse2", "Ruedita");

            return newdict;
        }

        //Método CheatPunch financiado pelo proxolin
		//def On_PlayerConnected(self, Player):

        static Dictionary<string, string> Keys()
        {
            var newdict = new Dictionary<string, string>();
            //newdict.Add("Keypad1","NumPad 1");
            //	newdict.Add("Keypad0","Numpad 0");
            newdict.Add("g", "G");
            return newdict;
        }
        static Dictionary<string, string> BadNameKickInit()
        {
            var newdict = new Dictionary<string, string>();
            newdict.Add("Admin", "Usted no tiene permiso para conectarse con ese nick");
            newdict.Add("Mod", "Usted no tiene permiso para conectarse con ese nick");
            newdict.Add("Diamante", "Usted no tiene permiso para conectarse con ese nick");
            newdict.Add("Hope", "Usted no tiene permiso para conectarse con ese nick");
            newdict.Add("dueño", "Usted no tiene permiso para conectarse con ese nick");
            return newdict;
        }
        public static Dictionary<string, string> TrigersMSG()
        {
            var newdict = new Dictionary<string, string>();
            newdict.Add("hack", "Crees que alguien es hack? /report (nombre) y el sera testeado por el servidor !");
            newdict.Add("cheat", "Crees que alguien es hack? /report (nombre) y el sera testeado por el servidor !");
            newdict.Add("hacks", "Crees que alguien es hack? /report (nombre) y el sera testeado por el servidor !");
			newdict.Add("hacker", "Crees que alguien es hack? /report (nombre) y el sera testeado por el servidor !");
            newdict.Add("amor", "ServerTest: Gracias");
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
        public static bool shouldsendstatisticstoadminonconnect = true;
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
                    ConsoleSystem.Run("oxide.reload ServerTest");
                    return new Dictionary<string, object>();
                }

            }
            if (Data[userid] == null)
                Data[userid] = new Dictionary<string, object>();
            return Data[userid] as Dictionary<string, object>;
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


        public static void LoadData() { Data = Interface.GetMod().DataFileSystem.GetDatafile("AIAdmin(pl)"); Info = Interface.GetMod().DataFileSystem.GetDatafile("ServerTest(Reports.pl)"); DataStore = Interface.GetMod().DataFileSystem.GetDatafile("ServerTest(DataStore(pl))"); Ipban = Interface.GetMod().DataFileSystem.GetDatafile("Blacklist(ip)"); Datablock = Interface.GetMod().DataFileSystem.GetDatafile("ServerTest(Datablock(pl))"); }

        void SaveData() { Interface.GetMod().DataFileSystem.SaveDatafile("AIAdmin(pl)"); Interface.GetMod().DataFileSystem.SaveDatafile("ServerTest(DataStore(pl))"); Interface.GetMod().DataFileSystem.SaveDatafile("ServerTest(Datablock(pl))"); }
        void Unload()
        {

            if (!falldamageenabled)
                ConsoleSystem.Run("falldamage.enabled false", false);
            SaveData();
            var objects = GameObject.FindObjectsOfType(typeof(CompanionCheck));
            var objects1 = GameObject.FindObjectsOfType(typeof(CompanionCheck2));
            var objects2 = GameObject.FindObjectsOfType(typeof(CompanionCheckflagcheck));
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
        public static object idletimetillban = 900f;
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
        public static bool shoulduseenglishdictionaryonly = false;
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
            newdict.Add("Porfavor escriba algo en su idioma o use /lang LanguageCode", true);
            newdict.Add("Porfavor escriba algo en su idioma o use /lang languagecode", true);
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
        public static bool ShouldBroadCastPlayerJumpSpeed = true;
        public static bool ShouldDoSmartJumpChect = true;
        public static bool ShouldDoAveragePingSpeedJumpCheck = true;
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
            CheckCfg<object>("ConFig: Quantidade máxima de votos necessária antes do check", ref numberofvotes);
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
            }
        }
        void Start()
        {

            LoadData();
            timer.Once(5.1f, () => CheckGameObject());
            SaveData();
            cleardatastore();
            if (!permission.PermissionExists("ServerTest")) permission.RegisterPermission("ServerTest", this);
            if (!permission.PermissionExists("ServerTest")) permission.RegisterPermission("ServerTest", this);
            terrainLayer = LayerMask.GetMask(new string[] { "Terrain" });
            management2 = RustServerManagement.Get();
            InitializeTable();
            BanType = typeof(BanList).GetNestedType("Ban", BindingFlags.Instance | BindingFlags.NonPublic);
            steamid = BanType.GetField("steamid");
            username = BanType.GetField("username");
            reason = BanType.GetField("reason");

            bannedUsers = typeof(BanList).GetField("bannedUsers", (BindingFlags.Static | BindingFlags.NonPublic));
        }
        bool hasAccess(NetUser netuser, string Name = "ServerTest")
        {
            if (netuser.CanAdmin())
                return true;

            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), Name);
        }
        public static void refreshrecoiltest(CompanionCheck player)
        {
            ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.bind Fire c c");
            ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "input.mousespeed 0");
            return;
        }
        [ChatCommand("airefresh")]//
        void cmdChatrefreshalllanguage(NetUser netuser, string command, string[] args)
        {
            if (hasAccess(netuser))
                if (args.Length == 1)
                {
                    NetUser targetuser = FindTargetPlayer(args[0]);
                    if (targetuser == null)
                    {
                        rust.SendChatMessage(netuser, SystemName, "Ningun jugador encontrado con ese Nombre");
                        return;
                    }
                    var datastore3 = Getplayerdatastore(targetuser.playerClient.userID.ToString());
                    if (datastore3.ContainsKey("Language"))
                    {
                        datastore3.Remove("Language");
                        rust.SendChatMessage(netuser, SystemName, "Usted removio el idioma anteriormente para " + targetuser.displayName);
                        return;
                    }
                    rust.SendChatMessage(netuser, SystemName, "A Linguagem para " + targetuser.displayName + " Já foi removido");
                    return;
                }
            if (!allowlanguagerefresh)
            {
                rust.SendChatMessage(netuser, SystemName, "Este comando está desativado");
                return;
            }
            var datastore = GetPlayeinfo(netuser.playerClient.userID.ToString());
            if (!datastore.ContainsKey("RefreshCount"))
            {
                datastore.Add("RefreshCount", 1);
            }
            var currentdatastore = Convert.ToSingle(datastore["RefreshCount"]);
            if (currentdatastore >= maxammoutnoflanguagerefreshbeforeignore)
            {
                rust.SendChatMessage(netuser, SystemName, "No puedes usar este comando");
                return;
            }
            CompanionCheck phandler = netuser.playerClient.GetComponent<CompanionCheck>();
            if (phandler != null)
            {
                rust.SendChatMessage(netuser, SystemName, "No puedes actualizar el idioma mientras estas siendo testeado");
                return;
            }
            currentdatastore++;
            var datastore2 = Getplayerdatastore(netuser.playerClient.userID.ToString());
            if (datastore2.ContainsKey("Language"))
            {
                datastore2.Remove("Language");
                rust.SendChatMessage(netuser, SystemName, "El idioma selecionado anteriormente fue eliminado");
                return;
            }
            rust.SendChatMessage(netuser, SystemName, "El idioma selecionado anteriormente fue eliminado");
            return;
        }
        [ConsoleCommand("aicheck")]
        void aicheck(ConsoleSystem.Arg arg)
        {
            if (arg.argUser != null && !hasAccess(arg.argUser)) { SendReply(arg, "No access"); return; }
            if (arg.Args.Length != 1)
            {
                SendReply(arg, SystemName + " " + "use /echeck playername");
            }
            NetUser targetuser = rust.FindPlayer(arg.Args[0]);
            if (targetuser == null)
            {
                SendReply(arg, SystemName + " " + "Ningun jugador encontrado con ese Nombre " + arg.Args[0]);
                return;
            }
            CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
            if (phandler == null)
            {
                phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>();
                timer.Once(0.1f, () => phandler.StartCheck());
                Debug.Log(SystemName + " " + "El test fue activado en " + targetuser.displayName);
                ServerTestBroadcastplayer("[color green]" + targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO");
            }
            else
                Debug.Log(string.Format("{0}: {1} Esta siendo testeado", SystemName, targetuser.displayName));

        }
        [ConsoleCommand("echeck")]
        void aicheckend(ConsoleSystem.Arg arg)
        {
            if (arg.argUser != null && !hasAccess(arg.argUser)) { SendReply(arg, "No access"); return; }
            if (arg.Args.Length != 1)
            {
                SendReply(arg, SystemName + " " + "[color orange]Use: /echeck playername ");
            }
            NetUser targetuser = rust.FindPlayer(arg.Args[0]);
            if (targetuser == null)
            {
                SendReply(arg, SystemName + " " + "Ningun jugador con ese Nombre " + arg.Args[0]);
                return;
            }
            CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
            if (phandler != null)
            {
                GameObject.Destroy(phandler);
                SendReply(arg, string.Format("{0}: Teste de encerramento da força {1} ", SystemName, targetuser.displayName));
            }
            else
                SendReply(arg, string.Format("{0}: Nenhum componente encontrado em {1}", SystemName, targetuser.displayName));

        }
        [ChatCommand("aipromote")]
        void cmdChatpromotepl(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No tienes permiso para usar este comando"); return; }
            if (args.Length != 1)
            {
                rust.SendChatMessage(netuser, SystemName, "[color orange]/report playername ");
                return;
            }
            var hasacess = GetPlayerdata("Flags(pl)");
            NetUser targetuser = FindTargetPlayer(args[0]);
            if (hasacess.ContainsKey(targetuser.userID.ToString()))
            {
                rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Fue adicionado a la lista de asociados del ServerTest");
                return;
            }
            hasacess.Add(targetuser.userID.ToString(), true);
            return;
        }
        [ChatCommand("aidemote")]
        void cmdChatdemotepl(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]Usted no puede usar este comando"); return; }
            if (args.Length != 1)
            {
                rust.SendChatMessage(netuser, SystemName, "[color orange]Use: /aidemote playername ");
                return;
            }
            var hasacess = GetPlayerdata("Flags(pl)");
            NetUser targetuser = FindTargetPlayer(args[0]);
            if (!hasacess.ContainsKey(targetuser.userID.ToString()))
            {
                rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Fue removido de la lista de complementos");
                return;
            }
            rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Fue removido de la lista de complementos");
            hasacess.Remove(targetuser.userID.ToString());
            return;
        }
        [ChatCommand("aiforceremovelang")]
        void cmdChatforcermeovedictionary(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No tienes permiso para usar este comando"); return; }
            if (args.Length != 1)
            {
                rust.SendChatMessage(netuser, SystemName, "[color orange]Use: /aiforceremovelang language prefix");
                return;
            }
            if (DataStore[args[0].ToString()] == null)
            {
                rust.SendChatMessage(netuser, SystemName, "Diccionario eliminado para " + args[0].ToString());
                return;
            }
            DataStore[args[0].ToString()] = null;
            SaveData();
            rust.SendChatMessage(netuser, SystemName, "Diccionario eliminado para " + args[0].ToString());
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
                rust.SendChatMessage(netuser, SystemName, "[color orange]Use: /report playername");
                return;
            }

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
                rust.SendChatMessage(netuser, SystemName, "Ningun jugador encontrado con ese Nombre");
                return;
            }
            if (Tempo.ContainsKey(targetuser.playerClient.userID.ToString()))

            {
                rust.SendChatMessage(netuser, SystemName, "Este jugador fue reportado hace menos de un minuto, deberas esperar para reportar a este jugador!");
            }
            if (!Tempo.ContainsKey(targetuser.playerClient.userID.ToString()))

            {
                Tempo.Add(targetuser.playerClient.userID.ToString(), 1);
                timer.Once(60f, () => {
                    if (targetuser.playerClient.userID.ToString() != null)
                    {
                        Tempo.Remove(targetuser.playerClient.userID.ToString());
                    }
                });
            }
            var haschecked = Getplayerdatastore("ServerTest(haschecked)");
            if (shouldcheckonce)
            {
                if (haschecked.ContainsKey(targetuser.playerClient.userID.ToString()))
                {
                    rust.SendChatMessage(netuser, SystemName, "Lamento que me disseram para não verificar os jogadores duas vezes");
                    return;
                }
            }
            var newdata = GetPlayeinfo(targetuser.playerClient.userID.ToString());
            var newdata2 = GetPlayeinfo("Reporteddata");
            if (newdata.ContainsKey(netuser.playerClient.userID.ToString()))
            {
                rust.SendChatMessage(netuser, SystemName, "Usted voto para conferir" + targetuser.playerClient.userName);

                return;

            }

            if (!newdata.ContainsKey("Reportspl"))
            {
                reportnum++;
                newdata.Add("Reportspl", 1f);
                timer.Once(300f, () => newdata.Remove("Reportspl".ToString()));
                string UserData = netuser.playerClient.userID.ToString();
                if (!newdata.ContainsKey(UserData))
                {
                    timer.Once(300f, () => newdata.Remove(UserData));
                    newdata.Add(netuser.playerClient.userID.ToString(), cachedReason);
                }
                var text = Convert.ToSingle(newdata["Reportspl"]);
                if (text >= int.Parse(numberofvotes.ToString()))
                {
                    ServerTestBroadcastplayerr(targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO");
                    //targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                    CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                    if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                    timer.Once(0.3f, () => phandler.StartCheck());
                    rust.SendChatMessage(netuser, "ServerTest", targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO");
                    rust.Notice(targetuser, targetuser.displayName + " Estas siendo testeado para ver si tienes HACKS");
                    rust.SendChatMessage(netuser, SystemName, "Este jugador sera verificado en breve");
                    rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Será verificado en breve");
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
                rust.SendChatMessage(netuser, SystemName, "[color green]HECHO! Reportaste [color white]" + targetuser.displayName + "[color green] con suceso!  El precisa un total de votos de [/color] [" + 1 + "/" + numberofvotes + "]");
                Debug.Log(netuser.displayName + " Votado para ser testeado " + targetuser.displayName + " El precisa un total de " + "1" + "/" + numberofvotes);
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
                    rust.SendChatMessage(netuser, "☢ServerTest☢", targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO");
                    rust.SendChatMessage(netuser, SystemName, "Este jugador sera verificado en breve");
                    rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Será verificado em breve");
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
                rust.SendChatMessage(netuser, SystemName, "Votaste para verificar " + targetuser.displayName + " El para verificar precisa un total de " + percentageleftt.ToString() + "% Mas votos");
                return;
            }
            if (newdata.ContainsKey(netuser.playerClient.userID.ToString()))
            {
                rust.SendChatMessage(netuser, SystemName, "Votaste para conferir " + targetuser.playerClient.userName);
                return;
            }
            if (!newdata.ContainsKey(netuser.playerClient.userID.ToString()))
            {
                newdata.Add(netuser.playerClient.userID.ToString(), cachedReason);
                string totake = netuser.playerClient.userID.ToString();
                timer.Once(300f, () => newdata.Remove(totake));
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
                    rust.SendChatMessage(netuser, SystemName, "Este jogadores controláveis é muito baixo, como resultado, vou testá-lo quando ele Respawn");
                    ServerTestBroadcastplayerr(targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                    reportnum++;
                    return;
                }
                ServerTestBroadcastplayerr(targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                rust.Notice(targetuser, targetuser.displayName + " Estas siendo testeado para ver si tienes hacks");
                CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                timer.Once(0.3f, () => phandler.StartCheck());
                rust.SendChatMessage(netuser, "☢ServerTest☢", targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                rust.SendChatMessage(netuser, SystemName, "Este jugador sera verificado en breve");
                rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Será verificado en breve");
                haschecked.Add(targetuser.playerClient.userID.ToString(), targetuser.displayName);
            }
            reportnum++;
            rust.SendChatMessage(netuser, SystemName, "Votaste para verificar " + targetuser.displayName + " El precisa de un total de " + update + "/" + numberofvotes);
            Debug.Log(netuser.displayName + " Votado para ser testeado " + targetuser.displayName + " El precisa de un total de " + update + "/" + numberofvotes);
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
                rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " Sera verificado en breve");
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
                rust.SendChatMessage(netuser, SystemName, "Você votou para verificar " + targetuser.displayName + "Há um total de " + enhanced.ToString() + "Quem votou nas necessidades " + percentageleft.ToString() + "%");
            if (enhanced >= int.Parse(numberofpercentagevtoesbeforecheck.ToString()))
            {
                if (targetuser.playerClient.controllable == null || targetuser.playerClient.controllable.health <= 0)
                {
                    if (!NetUsers5.ContainsKey(targetuser))
                        NetUsers5.Add(targetuser, netuser);
                    rust.SendChatMessage(netuser, SystemName, "Este jugador esta muero sera testeado cuando este vivo");
                    ServerTestBroadcastplayerr(targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                    reportnum++;
                    return;
                }
                CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
                if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
                timer.Once(0.3f, () => phandler.StartCheck());
                rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                rust.SendChatMessage(netuser, SystemName, "Este jugador sera verificado en breve");
                return;
            }
            rust.SendChatMessage(netuser, SystemName, "Ningun jugador encontrado con ese Nombre");
            return;
        }
        [ChatCommand("reports")]
        void cmdChatviewreports(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No puedes usar este comando"); return; }
            var totalnumberofbans = (numberofbansdizzy + numberofbansjacked + numberofbanssteven + numberofcheckevade + numberofbansnorecoil + numberofbansnofalldamage + NumberOfAspectDetections + numberofspeedjumpban);
            rust.SendChatMessage(netuser, SystemName, "Bievenido de vuelta :) Baneado hoy: " + numberofbansdizzy + " Dizzy/A3mon Users " + numberofbansjacked + " JackeD users " + numberofbanssteven + " Steven Hack Users ");
            rust.SendChatMessage(netuser, SystemName, "Bievenido de vuelta :) " + numberofbansnofalldamage + " Número de usuários daños nofall " + numberofbansnorecoil + " No Recoil Users " + numberofcheckevade + " Número de Check evadidos");
            rust.SendChatMessage(netuser, SystemName, "Número total de bans " + totalnumberofbans + " Número de prohibiciones de aspecto " + NumberOfAspectDetections + " Reports " + reportnum);
            rust.SendChatMessage(netuser, SystemName, "Bievenido de vuelta :) " + numberofspeedjumpban + " Número de prohibición de salto de velocidad ");
        }
        [ChatCommand("aivr")]
        void cmdChatGetdata(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No puedes usar este comando"); return; }
            var hascheckedd3menu = GetPlayerdata("smartchecked(Menu)");
            hascheckedd3menu.Clear();
            return;
            int count = 0;
            int bl = 1;
            if (args.Length > 0) int.TryParse(args[0], out bl);
            var newcount = (bl + 20);
            foreach (KeyValuePair<string, object> pair in Info)
            {

                count++;
                if (count < bl)
                    continue;
                int count3 = count;
                if (count >= newcount)
                    break;
                if (count >= newcount)
                    return;
                friedchicken(netuser, pair.Key.ToString(), bl);
            }
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
        [ChatCommand("tirar")]
        void cmdChatendcheck(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No tienes permiso para usar este comando"); return; }
            if (args.Length != 1)
            {
                rust.SendChatMessage(netuser, SystemName, "[color orange]Use: /tirar playername ");
                return;
            }
            NetUser targetuser = FindTargetPlayer(args[0]);
            if (targetuser == null)
            {
                rust.SendChatMessage(netuser, SystemName, "Ningun jugador encontrado con ese Nombre");
                return;
            }
            CompanionCheck phandler = targetuser.playerClient.gameObject.GetComponent<CompanionCheck>();
            if (phandler != null)
            {
                if (phandler.playerclient.rootControllable != null)
                    phandler.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
                EndDetection(phandler);
                timer.Once(3f, () => EndDetection(phandler));
                rust.SendChatMessage(netuser, SystemName, "Test finalizado en " + targetuser.displayName);
                return;
            }
            rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " No esta siendo testeado en este momento");
        }
        [ChatCommand("aiflagcheck")]
        void cmdChatgetflagcheck(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No puedes usar este comando"); return; }
            CompanionCheckflagcheck phandler = netuser.playerClient.GetComponent<CompanionCheckflagcheck>();
            if (phandler == null) { phandler = netuser.playerClient.gameObject.AddComponent<CompanionCheckflagcheck>(); rust.SendChatMessage(netuser, SystemName, "Suas bandeiras estão sendo verificadas"); phandler.StartCheck(); return; }
            Endflagcheck(phandler);
            rust.SendChatMessage(netuser, SystemName, "Suas bandeiras não estão mais sendo verificadas");
            return;

        }
        [ChatCommand("test")]
        void cmdChatProdwholooted(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]No tienes permiso para usar este comando"); return; }
            if (args.Length != 1)
            {
                rust.SendChatMessage(netuser, SystemName, "[color orange]Use: /test playername");
                return;
            }
            NetUser targetuser = FindTargetPlayer(args[0]);
            if (targetuser == null)
            {
                rust.SendChatMessage(netuser, SystemName, "player nao encontrado");
                return;
            }
            if (targetuser.playerClient.controllable == null || targetuser.playerClient.controllable.health <= 0)
            {
                if (!NetUsers5.ContainsKey(targetuser))
                    NetUsers5.Add(targetuser, netuser);
                rust.SendChatMessage(netuser, SystemName, "esse player parece esta morto, vou testa-lo quando repawnar");
                ServerTestBroadcastplayerr(targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
                return;
            }
            //.Log("2");

            ServerTestBroadcastplayerr(targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");
            rust.Notice(targetuser, targetuser.displayName + " Estas siendo testeado para ver si tienes hacks");
            //targetuser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
            CompanionCheck phandler = targetuser.playerClient.GetComponent<CompanionCheck>();
            if (phandler == null) { phandler = targetuser.playerClient.gameObject.AddComponent<CompanionCheck>(); }
            if (phandler == null)
                ConsoleSystem.Run("oxide.reload ServerTest");
            timer.Once(0.3f, () => phandler.StartCheck());
            //.Log("3");
            rust.SendChatMessage(netuser, SystemName, targetuser.displayName + " [color orange]Esta siendo testeado - [color red] No se desconecte durante el test o sera BANEADO !");

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
            if (hasAccess(netuser, "ServerTest"))
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
            if (Tempo.ContainsKey(netuser.playerClient.userID.ToString()))
            {
                Tempo.Remove(netuser.playerClient.userID.ToString());
                return;
            }
            if (ShouldKickBadName)
                if (ShouldKick(netuser, netuser.displayName))
                {

                    netuser.Kick(NetError.Facepunch_Kick_RCON, false);
                    return;
                }


            if (management2 == null || Data == null)
            {
                LoadData();
                if (Data == null)
                {
                    ConsoleSystem.Run("oxide.reload ServerTest", false);
                    return;
                }
                //OnServerInitialized();
                //Started = true;
                //

            }

            var firstpass = GetPlayerdata("firstpass");
            if (firstpass == null)
                return;
            if (netuser == null)
                return;
            if (netuser.playerClient == null)
                return;
            var isnull = netuser.playerClient.netPlayer;
            if (isnull == null)
                return;
            if (BadName(netuser.displayName))
            {
                Debug.Log(netuser.displayName + " Conectado com um nome incorreto, um teste adicional pode ser necessário");

                var BadNameDataStore = GetPlayerdata("SuspectNames(log.pl)");
                if (!BadNameDataStore.ContainsKey(netuser.playerClient.ToString()))
                    BadNameDataStore.Add(netuser.playerClient.userID.ToString(), netuser.displayName);
            }
            if (smartcheck)
            {
                if (shouldcheckhackmenuLog)
                {
                    ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Up w Insert");
                    ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Down s F2");
                    ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F5");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a Mouse2/ruedita del mouse");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F6");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F7");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F8");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F9");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F10");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F11");
					ConsoleNetworker.SendClientCommand(netuser.playerClient.netPlayer, "input.bind Left a F12");
					
                }
            }
            if (shouldsendstatisticstoadminonconnect)
            {
                if (hasAccess(netuser))
                {
                    var totalnumberofbans = (numberofbansdizzy + numberofbansjacked + numberofbanssteven + numberofcheckevade + numberofbansnorecoil + numberofbansnofalldamage);
                    rust.SendChatMessage(netuser, SystemName, "Bem-Vindo de volta :) Hoje eu bani " + numberofbansdizzy + "  usarios deDizzy/A3mon " + numberofbansjacked + " usuarios de JackeD  " + numberofbanssteven + " Usuarios de Steven  ");
                    rust.SendChatMessage(netuser, SystemName, "Bem-Vindo de volta :) " + numberofbansnofalldamage + " usuarios com nofall damage  " + numberofbansnorecoil + " usuarios com No Recoil  " + numberofcheckevade + " usuarios que tentou enganar o teste");
                    rust.SendChatMessage(netuser, SystemName, "Bem-Vindo de volta :) " + numberofspeedjumpban + " usuarios que parecia estar com hack  " + NumberOfAspectDetections + " usuarios com speed jump, total de bans: " + totalnumberofbans + " Reports " + reportnum);
                    if (!shouldcheckplayerswithpermisions)
                        return;
                }
            }
            if (shouldsendprobablybanevadetoadmin)
            {
                if (shouldkicknoname)
                {
                    if (netuser.displayName.ToString() == "" || netuser.displayName.ToString() == " ")
                    {
                        netuser.Kick(NetError.Facepunch_Kick_RCON, true);
                        return;
                    }
                    if (netuser.displayName == "DerpTeamNoob" || netuser.displayName == "LumaEmu") { }
                    else
                    if (namehasbeenbannedalready(netuser.displayName.ToString()))
                    {
                        if (smartcheck)
                        {
                            var hascheckeddd = GetPlayerdata("smartchecked(log.pl)");
                            var hascheckedd = GetPlayerdata("smartchecked(pl)");
                            if (!hascheckeddd.ContainsKey(netuser.playerClient.userID.ToString()))
                                if (!hascheckedd.ContainsKey(netuser.playerClient.userID.ToString()))
                                {
                                    hascheckedd.Add(netuser.playerClient.userID.ToString(), true);
                                    ServerTestpublicbroadcast("O nome " + netuser.displayName + "  Foi proibido já vou testá-lo quando ele log em");
                                }
                        }
                        if (!smartcheck)
                            ServerTestpublicbroadcast("o nome " + netuser.displayName + " Já [color red]Foi banido, mas está usando um juiz de conta diferente por si mesmo");
                    }
                }
            }
            if (!shouldcheckplayerwhenfirstconnect)
                return;

            if (!firstpass.ContainsKey(netuser.playerClient.userID.ToString()))
                firstpass.Add(netuser.playerClient.userID.ToString(), true);
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

                string prefabname = ";struct_wood_ceiling";
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
                removeui(player);

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
                        ServerTestBroadcastplayer(player.playerclient.userName + " [color red][color red][color red]Fue baneado del servidor por hacks Nivel(3.0)");
                        BanPlayer(player.playerclient.netUser, player.IP, "Aspect Hack-method Player Y-Axis" + player.playerclient.lastKnownPosition.y + " -  Entity Y " + player.PlayerEntity.transform.position.y);
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
                            ServerTestBroadcastplayer(player.playerclient.userName + " Has been banned for using cheats Level(3.0)");
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
                                    ServerTestBroadcastplayer(player.playerclient.userName + " Has been banned for using cheats Level(3.0)");
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
                        holdf2msg = "[color red][ ! ] [color#A9A9A9]Pressione e segure [color cyan]F2";

                    }
                int pFrom = holdf2msg.IndexOf("F2");
                var result2 = holdf2msg.Remove(pFrom, 2);
                var AspectMessage = result2.Insert(pFrom, BeingReplaced);
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + AspectMessage.ToString() + "\"");
                if (!player.playerclient.controllable.stateFlags.grounded)
                {
                    if (!player.firstdetectionsaspect)
                    {
                        player.firstdetectionsaspect = true;
                        return;
                    }
                    ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Fue baneado del servidor por hacks Nivel(3.5)");
                    BanPlayer(player.playerclient.netUser, player.IP, "Aspecto Hack");
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

                                ServerTestBroadcastplayerr(player.playerclient.userName + " [color red]Might be using Cheats - [color orange]I will check him to make sure!");
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
                        if (phandler == null) { ServerTestpublicbroadcast(player.userName + " Conectado com um nome incorreto como resultado um teste será exigido"); phandler = player.gameObject.AddComponent<CompanionCheck>(); timer.Once(0.69f, () => phandler.StartCheck()); }

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
                ConsoleSystem.Run("oxide.reload ServerTest", false);
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
        public static void ServerTestpublicbroadcast(string message)
        {
            var hasacess = GetPlayerdata("Flags(pl)");
            foreach (PlayerClient player in PlayerClient.All)
            {
                if (player.netUser.CanAdmin() || hasacess.ContainsKey(player.userID.ToString()))
                    ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add ☢ServerTest☢ \"" + message + "\"");
            }
        }

        static void ServerTestBroadcastplayer(string message)
        {
            foreach (PlayerClient player in PlayerClient.All)
            {
                ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add ☢ServerTest☢ \"" + message + "\"");
            }
        }
        public static void ServerTestBroadcastplayerr(string message)
        {
            foreach (PlayerClient player in PlayerClient.All)
            {
                ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add ☢ServerTest☢ \"" + message + "\"");
            }
        }
        public static void CheckGameObject()
        {
            if (Data == null)
                ConsoleSystem.Run("oxide.reload ServerTest");
        }
        static void tpback(CompanionCheck player)
        {
            ConsoleNetworker.SendClientCommand(player.playerclient.netUser.networkPlayer, "config.load");
            player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
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
                //player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                player.hastpbacksecond = true;
                returnsettings(player.playerclient.netUser);
                //GodCharacter compadd = player.playerclient.gameObject.AddComponent(GodCharacter);
                //compadd.StartCheck();
                STimer.Once(float.Parse(TimerTillUngod.ToString()), () => UnGod(player.playerclient));
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
            DoReturnSetttings(player.playerclient);
            STimer.Once(0.32f, () => DoReturnSetttings(player.playerclient));

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
        [ChatCommand("searchforclient")]
        void cmdChatsendhelptexts(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { return; }
            string Target = netuser.playerClient.netPlayer.id.ToString();
            if (args.Length >= 1)
                Target = args[0];
            foreach (PlayerClient player in PlayerClient.All)
                if (player.netPlayer.id.ToString() == Target)
                    SendReply(netuser, string.Format("{0} para {1}", player.userName, player.netPlayer.id.ToString()));

        }
        [ChatCommand("aihelp")]
        void cmdChatsendhelptext(NetUser netuser, string command, string[] args)
        {
            SendReply(netuser, "Atualizar Idioma: use /airefresh Para atualizar o idioma selecionado");
            SendReply(netuser, "Relatório Hacker: use /report Nome do jogador para relatar um jogador Número total de votos necessários antes do check ser " + numberofvotes.ToString());
            if (!hasAccess(netuser)) { return; }
            SendReply(netuser, "Jogador de rebaixar: Use /aidemote playername para remover um jogador da lista de acompanhantes (sinalizador necessário)");
            SendReply(netuser, "Sinalizadores de Flagcheck (usados para configuração): Digite /aiflagcheck e /aiflagcheck novamente para desativá-lo");
            SendReply(netuser, "SafeZone: Type /aisafezone Para definir uma safezone para os jogadores a serem testados");
            SendReply(netuser, "Promover Player: digite /aipromote playername para adicionar um jogador à lista de Companion (flag needed)");
            SendReply(netuser, "Verificação de Força: Digite /check para forçar a seleção de um jogador (flag needed)");
            SendReply(netuser, "Para exibir relatórios: digite /reports para forçar a seleção de um jogador (sinalizador necessário)");
            SendReply(netuser, "Verificação de fim de força: Digite /dismiss para forçar a verificação final de um jogador (sinalizador necessário)");
            SendReply(netuser, "Remover idioma: Type /aiforceremovelang Para remover um dicionário de idioma (flag needed)");
            SendReply(netuser, "Comando do Console: Digite - aicheck Nome do Jogador Para forçar a verificação de um jogador através do console (flag needed)");
            SendReply(netuser, "Comando do Console: digite - echeck PlayerName Para forçar a verificação final em um player através do console (flag needed)");
        }
        void SendHelpText(NetUser netuser)
        {
            SendReply(netuser, "ServerTest : use /aihelp Obter ajuda sobre o plugin");
        }
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

                ServerTestBroadcastplayer(player.playerclient.userName + " Foi eliminado deste plug-in");
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
                        ipban(player, "☢ServerTest☢(Max Amount of Idle Time Reached)");
                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                    ServerTestBroadcastplayer(player.playerclient.userName + " [color red][color red]Foi banido do servidor para ocioso durante o teste");
                    BanPlayer(player.playerclient.netUser, player.IP, "☢ServerTest☢(Max Amount of Idle Time Reached)");
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
            var datastore2 = Getplayerdatastore("ServerTest(Lang.Log)");
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


            string holdf2msg = "[color red][ ! ] [color#A9A9A9]Pressione e segure [color cyan]F2";
            if (language.ContainsKey("F2testmsg"))
                holdf2msg = language["F2testmsg"].ToString();
            if (!holdf2msg.Contains("F2"))
                if (language.ContainsKey("F2TestTurk"))
                    holdf2msg = language["F2TestTurk"].ToString();
            if (!holdf2msg.Contains("F2"))
                holdf2msg = "[color red][ ! ] [color#A9A9A9]Pressione e segure [color cyan]F2";
            int pFrom = holdf2msg.IndexOf("F2");
            var result2 = holdf2msg.Remove(pFrom, 2);
            var inserttest = result2.Insert(pFrom, "ins/insert");
            var stevencheck = result2.Insert(pFrom, "F5");
            var disconnectmsg = language["donotdcmessage"].ToString();
            var completedmsg = language["Completedmsg"].ToString();
            holdf2msg = result2.Insert(pFrom, BeingReplaced);
            if (check == int.Parse(menuscreenflag.ToString()))
            {
                removeui(player);
            }
            if (player.MenuDictionaries.Count / 2 >= DefaultKeys.Count || Convert == "FinishedTest")
            {
                var location2 = player.lastPosition;


                player.laststring2 = "insert";
                player.finisheddizzycheck = true;
                player.hasresettest = false;
                player.h = 0f;
                player.count++;
                if (!player.hassentmessages)
                {
                    STimer.Once(float.Parse(TimerTillUngod.ToString()) + 10f, () => UnGod(player.playerclient));
                    ServerTestBroadcastplayer("[color red][ ! ][color #0077FF] " + player.playerclient.userName + " [color #DBDBDB]Paso el test y esta [color #0077FF]LIMPIO[color #DBDBDB] de [color red]HACKS [color #DBDBDB]!");
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "[color #DBDBDB]Gracias por su cooperacion [/color]" + player.playerclient.userName + "\"");
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + completedmsg + " " + player.playerclient.userName + "\"");
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
                    removeui(player);
                    Resettestt(player.playerclient, Convert);
                }

                if (distance3D.ToString() == "0")
                {
                    if (player.CanSendMessage)
                    {
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + holdf2msg + "\"");
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
                                ipban(player, "ServerTest(HackMenu)<" + Convert + ">");
                            player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                            ServerTestBroadcastplayer(player.playerclient.userName + " Fue baneado del servidor por hacks (Nivel 3)");
                            BanPlayer(player.playerclient.netUser, player.IP, "ServerTest(HackMenu)<" + Convert + ">");
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
                            ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + holdf2msg + "\"");
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
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Verificando os dados do PlayerClient......" + "\"");
                    return;
                }
                var location2 = player.lastPosition;

                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "verificando PlayerClient......" + "\"");
                player.laststring2 = "insert";
                player.finisheddizzycheck = true;
                player.hasresettest = false;
                player.h = 0f;
                player.count++;

                return;

            }

            if (!player.hassentmessages)
            {

                ServerTestBroadcastplayer(player.playerclient.userName + " Foi cancelado com um total de " + player.HackMenuDetections + " detecções");
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Obrigado pela compreenção " + player.playerclient.userName + "\"");
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + completedmsg + " " + player.playerclient.userName + "\"");
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
            var data = Getplayerdatastore("ServerTest(Lang.Log)");
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
                    Debug.Log("ServerTest: Deu ruim teste encerrado sem finalizar " + player.playerclient.userName.ToString());
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
                    removeui(player);
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
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + " " + crouchmsg + "\"");
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
                                ipban(player, "☢ServerTest☢(Quantidade de tempo de inatividade atingido)");
                            player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                            ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Foi banido do servidor por estar ocioso durante o teste");
                            BanPlayer(player.playerclient.netUser, player.IP, "☢ServerTest☢(Quantidade máxima de tempo de inatividade atingido)");
                            return;
                        }
                }
                if (player.playerclient.controllable.stateFlags.grounded)
                {
                    player.messagetally++;
                    if (player.messagetally >= 60f)
                    {

                        player.messagetally = 0f;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + " " + jumptest + "\"");
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
                    ServerTestpublicbroadcast(player.playerclient.userName + " Atualmente tem uma JumpSpeed de " + player.playerjumpspeed);
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
                        ipban(player, "ServerTest(Speed Jump)");
                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                    ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Fue baneado del servidor por hacks (Nivel 2.5)");
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "speed jump detectado" + "\"");
                    BanPlayer(player.playerclient.netUser, player.IP, "ServerTest(Speed Jump)<" + player.playerjumpspeed + ">");
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
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Vou bani-lo para saltos de tempo " + "\"");
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
                                    ipban(player, "ServerTest(Saltos de sincronização " + player.playerjumpspeed.ToString() + ")");
                                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Fue baneado del servidor por hacks (Nivel 2)");
                                BanPlayer(player.playerclient.netUser, player.IP, "ServerTest(Timing Jumps " + player.playerjumpspeed.ToString() + ")");
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
                                ServerTestpublicbroadcast(player.playerclient.userName + " Foi eliminado do primeiro teste com um " + player.playerjumpspeed.ToString());
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
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Determinamos que você não está usando um modificador de salto ccmotor" + "\"");
                    ServerTestpublicbroadcast(player.playerclient.userName + " Foi eliminado do primeiro teste com um " + player.playerjumpspeed.ToString());
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
            return false;
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
                defaultenglishlanguage.Add("F2testmsg", "[color red][ ! ] [color#A9A9A9]Pressione e segure [color cyan]F2");
                defaultenglishlanguage.Add("speedjumptestmsg", "[color red]Salte o mais rapido que puder");
                defaultenglishlanguage.Add("norecoiltestmsg", "[color red]Por favor, equipe a arma que te dei[/color](Aperte 1)");
                defaultenglishlanguage.Add("nospreadtestmsg", "[color red]equipe a arma e atire nessa parede");
                defaultenglishlanguage.Add("Completedmsg", "Obrigado por sua cooperação, você completou todos os testes");
                defaultenglishlanguage.Add("donotcrouchmsg", "[color red]Por favor não se agache durante este teste");
                defaultenglishlanguage.Add("donotdcmessage", "[color red]Por favor não desconecte durante este teste");
                defaultenglishlanguage.Add("Dorecoiltest", "[color red][ ! ] [color#A9A9A9]Pressione e segure [color cyan]C");
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
                    removeui(player);
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
                if (datastore.ContainsKey("Language"))
                {
                    var langg = datastore["Language"].ToString();
                    var signature = Getplayerdatastore(langg);
                    if (!signature.ContainsKey("F2testmsg") || !signature.ContainsKey("speedjumptestmsg") || !signature.ContainsKey("nospreadtestmsg") || !signature.ContainsKey("Dorecoiltest") || !signature.ContainsKey("donotdcmessage") || !signature.ContainsKey("norecoiltestmsg"))
                    {
                        DataStore[langg] = null;
                        if (datastore.ContainsKey("Language"))
                            datastore.Remove("Language");
                        return;
                    }
                    if (signature["F2testmsg"].ToString().Contains("INVALID"))
                    {
                        DataStore[langg] = null;
                        if (datastore.ContainsKey("Language"))
                            datastore.Remove("Language");
                        return;
                    }
                    player.language = ParseLanguage(langg);
                    player.hasselectedlanguage = true;
                    player.forcefinish = true;
                }
                player.messagetally2++;
                if (player.messagetally2 >= 60f)
                    if (!datastore.ContainsKey("Language"))
                    {
                        var crouchjumpexploitdetection = player.playerclient.controllable.stateFlags.flags;
                        player.messagetally2 = 0f;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "[color red]Diga algo en el chat para indicar su idioma " + player.playerclient.userName + "\"");
                        return;
                    }
                if (!Issober(player))
                {
                    if (player.messagetally2 >= 60f)
                    {

                        player.messagetally2 = 0f;
                        player.language = "en";
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "[color red]El test va a empezar" + "\"");
                    }
                    return;
                }
                if (!datastore.ContainsKey("Language"))
                {
                    player.messagetally++;
                    if (player.messagetally2 >= 60f)
                    {
                        player.messagetally2 = 0f;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "[color red]Diga algo en el chat para indicar su idioma" + "\"");
                        return;
                    }
                    return;
                }
                player.hasselectedlanguage = true;
                return;
            }
            if (!datastore.ContainsKey("Language"))
            {
                player.messagetally++;
                if (player.messagetally2 >= 60f)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Umm ... Algo anda mal lo intentare corregir:)" + "\"");
                    player.messagetally2 = 0f;

                }
                player.hasselectedlanguage = false;
                return;
            }
            var lang = datastore["Language"].ToString();
            if (!player.forcefinish)
            {
                player.messagetally2++;
                if (player.messagetally2 >= 60f)
                    if (!datastore.ContainsKey("Language"))
                    {
                        player.hasselectedlanguage = false;
                        ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Aviso você nunca deve ver isso pedir um administrador para testar se você ver isso novamente" + "\"");
                        player.messagetally2 = 0f;
                        return;
                    }
                if (DataStore[lang] == null)
                {
                    datastore.Remove("Language");
                    return;
                }
                var failsafe = Getplayerdatastore(lang);
                if (!Issober2(player))
                {
                    return;
                }
                if (!failsafe.ContainsKey("F2testmsg"))
                {
                    DataStore[lang] = null;
                    datastore.Remove("Language");
                    return;
                }
                player.language = lang;
                player.playerhaslang2 = true;
                player.forcefinish = true;
                return;

            }
            if (!Issober2(player))
            {
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Umm ... Algo anda mal lo intentare corregir" + "\"");
                datastore.Remove("Language");

                player.forcefinish = false;
                player.hasselectedlanguage = false;
                Debug.Log("ServerTest : Alguma coisa deu errado você terá que redefinir seu idioma desculpe pela inconveniência");
                return;
            }
            player.language = datastore["Language"].ToString();
            player.playerhaslang2 = true;
            return;
            if (player.forcefinish)
            {
                player.messagetally2++;
                if (player.messagetally2 >= 60f)
                    if (shouldautoselectlagnuageifplayeridl)
                    {
                        player.idletimecount++;
                        if (player.idletimecount >= int.Parse(idletimetillautoseectlanguage.ToString()))
                        {
                            player.language = "en";
                            player.playerhaslang2 = true;
                            return;
                        }
                    }
                if (player.messagetally >= 60f)
                {
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Diga algo en el chat para indicar su idioma" + "\"");
                    player.messagetally = 0f;
                }
            }
            return;
            var datastore2 = Getplayerdatastore("ServerTest(Lang.Log)");
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
                    var crouchjumpexploitdetection = player.playerclient.controllable.stateFlags.flags;
                    player.messagetally2 = 0f;
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add  ServerTest \"" + "[color red]Diga algo en el chat para indicar su idioma " + player.playerclient.userName + "\"");
                    return;
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
        [ChatCommand("aisafezone")]
        void cmdChatsavezone(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, SystemName, "[color orange]Usted no puede usar este comando"); return; }
            var loc = Getplayerdatastore("SafeZone");
            if (loc.ContainsKey("x"))
            {
                DataStore["SafeZone"] = null;
                rust.SendChatMessage(netuser, SystemName, "Removiste la Zona del Test actual");
                return;
            }
            loc.Add("x", netuser.playerClient.lastKnownPosition.x);
            loc.Add("y", netuser.playerClient.lastKnownPosition.y);
            loc.Add("z", netuser.playerClient.lastKnownPosition.z);
            rust.SendChatMessage(netuser, SystemName, "Você adicionou sua localização atual como um TestZone");
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
                if (UnityEngine.Time.realtimeSinceStartup - lastTick >= 0.32f)
                {
                    currentTick = UnityEngine.Time.realtimeSinceStartup;
                    lastTick = currentTick;
                    var characterstate = this.playerclient.controllable.stateFlags.flags;
                    var try4 = (playerclient.controllable.rootCharacter.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").rotation.y + playerclient.controllable.rootCharacter.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").rotation.y).ToString();

                    //Debug.Log(this.playerclient.GetComponent<HeadBob>());
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add  ☢ServerTest☢ \"" + "Seu estado de caractere atual é " + (float.Parse(try4) - LastXF) + "\"");
                    ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Seu estado de caractere atual é " + characterstate + "\"");
                    //Debug.Log(this.playerclient.lastKnownPosition + " " + playerclient.controllable.rootCharacter.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").position);
                    //ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Your current character state is " + playerclient.controllablustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1").x + " " + this.playerclient.transform.position.x + \"");
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
                    //ConsoleNetworker.SendClientCommand(this.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Your current character state is " + characterstate + "\"");
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
                //STimer.Once(1f, () => FinalSafety(netuser,player));
                //.Log("25");
                return;
            }
            var safex = Convert.ToSingle(loc["x"]);
            var safey = Convert.ToSingle(loc["y"]);
            var safez = Convert.ToSingle(loc["z"]);
            TeleportToPos2(netuser, safex, safey, safez);
            player.hasteleportedtosafety = true;
            //STimer.Once(1f, () => FinalSafety(netuser,player));
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
                //STimer.Once(1f, () => CompleteVoid(player));
                return;
            }
            var safex = Convert.ToSingle(loc["x"]);
            var safey = Convert.ToSingle(loc["y"]);
            var safez = Convert.ToSingle(loc["z"]);
            player.hasteleportedtosafety = true;
            TeleportToPos2(netuser, safex, safey, safez);

            //STimer.Once(3f, () => CompleteVoid(player));
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
					ipban(player, "ServerTest(No Fall Damage)");
					player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
				ServerTestBroadcastplayer(player.playerclient.userName + " Has been Banned from the server for using NoFallDamage");
				BanPlayer(player.playerclient.netUser,player.playerclient.userID.ToString(), player.playerclient.userName, "ServerTest(No Fall Damage)");
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
                                    ipban(player, "☢ServerTest☢(Nofall-multihack detection)");
                                player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                                ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Fue baneado del servidor por hacks (Nivel 1)");
                                BanPlayer(player.playerclient.netUser, player.IP, "☢ServerTest☢(Nofall-multihack detection)");
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
            LoadData();
            if (!Started)
                timer.Once(1f, () => StartAll());


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
                        ipban(player, "ServerTest(Tempo de inatividade atingido)");
                    player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                    ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Foi banido do servidor por estar ocioso durante o teste");
                    BanPlayer(player.playerclient.netUser, player.IP, "Quantidade máxima de ServerTest (tempo de inatividade atingido)");
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
                removeui(player);
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
                    ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + "Aviso não conseguiu encontrar arma" + "\"");
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
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + norecoilcheckmsg + "\"");
                return;
            }
            getcahcedbuletitem.FireClientSideItemEvent(InventoryItem.ItemEvent.Used);
            if (getcahcedbuletitem.slot != 30 || getcahcedbuletitem.datablock != displaynameToDataBlock[NoRecoilWeapon.ToLower()])
            {
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + norecoilcheckmsg + "\"");
                return;
            }
            var g = getcahcedbuletitem.slot;
            if (g == null)
            {
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + norecoilcheckmsg + "\"");
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
                            ipban(player, "ServerTest(no recoil)");
                        player.playerclient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
                        ServerTestBroadcastplayer(player.playerclient.userName + " [color red]Fue baneado del servidor por hacks (Nivel 2)");
                        BanPlayer(player.playerclient.netUser, player.playerclient.netUser.networkPlayer.externalIP.ToString(), "ServerTest(no recoil)");
                        numberofbansnorecoil++;
                        return;
                    }
                }
            }

            if (test4.clipAmmo.ToString() == player.lastclipammo)
            {
                ConsoleNetworker.SendClientCommand(player.playerclient.netPlayer, "chat.add ☢ServerTest☢ \"" + dorecoiltest + "\"");
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
            return true;
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
            PlayerClient player = ((NetUser)netplayer.GetLocalData()).playerClient;
            if (ShouldAllowCheckIfPlayerWithBadNameReconnect)
            {
                var Tester = GetPlayerdata("SuspectPlayersTested(log.pl)");
                if (Tester.ContainsKey(player.userID.ToString()))
                    Tester.Remove(player.userID.ToString());
            }

            CompanionCheck phandler = player.GetComponent<CompanionCheck>();
            var haschecked = Getplayerdatastore("ServerTest(haschecked)");
            if (haschecked == null)
            {
                return;
            }
            if (haschecked.ContainsKey(player.userID.ToString()))
            {
                Debug.Log("Removido Jogador verificado " + player.userName);
                haschecked.Remove(player.userID.ToString());
            }
            if (phandler == null)
                return;
            if (phandler != null)
            {
                if (!falldamageenabled)
                    ConsoleSystem.Run("falldamage.enabled false", false);
                GameObject.Destroy(phandler);
            }
            if (hasAccess(player.netUser))
                return;

            if (shouldbanifplayerdcduringtest)
            {
                if (ShouldDisreGardIfKickedForViolation)
                {
                    var Reason = player.netUser.truthDetector.NoteMoved(ref player.lastKnownPosition, player.controllable.eyesAngles, 20.0);
                    if (Reason.ToString() != "None")
                    {
                        Debug.Log(player.userName + " Desconectado do Servidor como um Resultado de Lag - Não Punir Dado");
                        ServerTestpublicbroadcast(player.userName + " Desconectado do Servidor como um Resultado de Lag - Não Punir Dado");
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
                        ServerTestBroadcastplayerr(player.userName + " [color red]Foi proibido para Evadir Cheque");
                    if (!BanList.Contains(player.userID))
                    {
                        BanList.Add(player.userID, player.userName, "ServerTest(Disconnectduringtest)");
                        ipban(phandler, "ServerTest(Disconnect During Test)");
                    }

                    return;
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
            if (message.Contains("net.connect") && !message.Contains(ServerIP) || message.Contains(":2") && !message.Contains(ServerIP))
            {
                netuser.Kick(NetError.Facepunch_Kick_RCON, true);
                return false;
            }
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

                    GetcountryBytext(netuser, message.ToString());
                    return null;
                }

            return null;

        }

        void IOnRecieveNetwork()
        {
            float now = Interface.Oxide.Now;
        }
        void dolanguage(NetUser netuser, string language)
        {

            var languagee = Getplayerdatastore(language);
            var data = Getplayerdatastore(netuser.playerClient.userID.ToString());
            CompanionCheck phandler = netuser.playerClient.GetComponent<CompanionCheck>();

            if (languagee.ContainsKey("F2testmsg") && languagee.ContainsKey("speedjumptestmsg") && languagee.ContainsKey("nospreadtestmsg") && languagee.ContainsKey("Dorecoiltest") && languagee.ContainsKey("donotdcmessage") && languagee.ContainsKey("norecoiltestmsg"))
            {
                if (!data.ContainsKey("Language"))
                    data.Add("Language", language);
                phandler.forcefinish = true;
                phandler.hasselectedlanguage = true;
                return;
            }
            var url1turk = "http://mymemory.translated.net/api/get?q=press%20and%20hold%20the%20key%27F2%27&langpair=en|" + language + "&de=" + Email;

            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url1turk, (code, response) =>
            {

                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                if (jsonresponse2 == null)
                {
                    data.Clear();
                    languagee.Clear();
                    phandler.hasselectedlanguage = false;
                    return;
                }
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22 == null)
                    return;
                if (playervpn22.ToString().Contains("INVALID") || playervpn22.ToString().Contains("EXAMPLE") || !playervpn22.ToString().Contains("F2"))
                {
                    if (shouldignore)
                        phandler.numberoffakecalls++;
                    return;
                }
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("F2TestTurk"))
                    languagee.Add("F2TestTurk", playervpn22);

            }, this);
            var url1 = string.Format("http://mymemory.translated.net/api/get?q=thank%20you%20now%20press%20and%20hold%20F2%20on%20your%20keyboard%20please&langpair=en|" + language + "&de=" + Email);
            var url2 = string.Format("http://mymemory.translated.net/api/get?q=jump speed please&langpair=en|" + language + "&de=" + Email);
            var url3 = string.Format("http://mymemory.translated.net/api/get?q=do not move and take out the weapon i have placed in your inventory and shoot please&langpair=en|" + language + "&de=" + Email);
            var url4 = string.Format("http://mymemory.translated.net/api/get?q=do not move and take out your weapon and [color red]Press and Hold C on your keyboard&langpair=en|" + language + "&de=" + Email);
            var url5 = string.Format("http://mymemory.translated.net/api/get?q=please do not disconnect during this test &langpair=en|" + language + "&de=" + Email);
            var url6 = string.Format("http://mymemory.translated.net/api/get?q=Shoot the weapon by pressing c&langpair=en|" + language + "&de=" + Email);
            var url7 = string.Format("http://mymemory.translated.net/api/get?q=Thank you, you have finished all test completely&langpair=en|" + language + "&de=" + Email);
            var url8 = string.Format("http://mymemory.translated.net/api/get?q=Please do not crouch during this test&langpair=en|" + language + "&de=" + Email);
            var url9 = string.Format("https://translate.google.com.jm/?rlz=1C1PRFE_enJM668JM669&um=1&ie=UTF-8&hl=en&client=tw-ob#en/" + language + "/:thank%20you%20now%20press%20and%20hold%20F2%20on%20your%20keyboard%20please:");

            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url1, (code, response) =>
            {

                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                if (jsonresponse2 == null)
                    return;
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString().Contains("INVALID") || playervpn22.ToString().Contains("EXAMPLE") || !playervpn22.ToString().Contains("F2"))
                {
                    if (shouldignore)
                        phandler.numberoffakecalls++;
                    return;
                }
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("F2testmsg"))
                    languagee.Add("F2testmsg", playervpn22);

            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url2, (code, response) =>
            {
                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                if (jsonresponse2 == null)
                    return;
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("speedjumptestmsg"))
                    languagee.Add("speedjumptestmsg", playervpn22);
            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url3, (code, response) =>
            {
                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                if (jsonresponse2 == null)
                    return;
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("norecoiltestmsg"))
                    languagee.Add("norecoiltestmsg", playervpn22);
            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url4, (code, response) =>
            {
                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                if (jsonresponse2 == null)
                    return;
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("nospreadtestmsg"))
                    languagee.Add("nospreadtestmsg", playervpn22);
            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url5, (code, response) =>
            {

                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("donotdcmessage"))
                    languagee.Add("donotdcmessage", playervpn22);
            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url6, (code, response) =>
            {

                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("Dorecoiltest"))
                    languagee.Add("Dorecoiltest", playervpn22);
            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url7, (code, response) =>
            {

                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("Completedmsg"))
                    languagee.Add("Completedmsg", playervpn22);
            }, this);
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url8, (code, response) =>
            {

                var jsonresponse2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                var playervpnn2 = (jsonresponse2["responseData"]);
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(playervpnn2.ToString(), jsonsettings);
                var playervpn22 = (jsonresponse["translatedText"].ToString());
                if (playervpn22.ToString() == "null")
                {

                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.forcefinish = true;
                    phandler.hasselectedlanguage = true;
                    return;
                }
                if (!languagee.ContainsKey("donotcrouchmsg"))
                    languagee.Add("donotcrouchmsg", playervpn22);
                if (!data.ContainsKey("Language"))
                    data.Add("Language", language);
                phandler.forcefinish = true;
                phandler.hasselectedlanguage = true;
                if (!languagee.ContainsKey("F2testmsg"))
                    languagee.Add("F2testmsg", playervpn22);
            }, this);
            if (!data.ContainsKey(netuser.playerClient.userID.ToString()))
                data.Add(netuser.playerClient.userID.ToString(), language);
            phandler.hasselectedlanguage = true;


        }
        void GetcountryBytext(NetUser netuser, string Message)
        {
            CompanionCheck phandler = netuser.playerClient.GetComponent<CompanionCheck>();
            var url = string.Format("http://ws.detectlanguage.com/0.2/detect?q[]=" + Message + "&key=deac07df56b667691b986848135f58c4");
            Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url, (code, response) =>
            {

                var testb = response.ToString();
                int pFrom = testb.IndexOf("language");
                int pTo = testb.LastIndexOf("isReliable");
                string result = testb.Substring(pFrom, pTo - pFrom);
                var index2 = result.IndexOf("language");
                var result2 = result.Remove(index2, 10);
                var index3 = result2.IndexOf(",");
                var result3 = result2.Remove(index3, 2);
                var index4 = result3.IndexOf('"');
                var result4 = result3.Remove(index4, 1);
                var index5 = result4.IndexOf('"');
                var result5 = result4.Remove(index5, 1);
                var data = Getplayerdatastore(netuser.playerClient.userID.ToString());
                if (phandler.LangPair == "1" || phandler.LangPair != result5)
                {
                    phandler.LangPair = result5;
                    return;
                }
                phandler.detectionended = false;
                if (result5.ToString() == "en")
                {
                    var defaultenglishlanguage = Getplayerdatastore("en");
                    if (!defaultenglishlanguage.ContainsKey("speedjumptestmsg"))
                    {
                        defaultenglishlanguage.Add("F2testmsg", "[color red]Please Hold F2");
                        defaultenglishlanguage.Add("speedjumptestmsg", "[color red]Jump fast please");
                        defaultenglishlanguage.Add("norecoiltestmsg", "[color red]Please take out the weapon we have placed in your inventory");
                        defaultenglishlanguage.Add("nospreadtestmsg", "take out your weapon and shoot that wall");
                        defaultenglishlanguage.Add("Completedmsg", "Thank you for your cooperation you have completed all test's ");
                        defaultenglishlanguage.Add("donotcrouchmsg", "[color red]Please do not crouch during this test");
                        defaultenglishlanguage.Add("donotdcmessage", "[color red]Please do not Disconnect during this test");
                        defaultenglishlanguage.Add("Dorecoiltest", "[color red]Please press and Hold c");
                    }
                    if (!data.ContainsKey("Language"))
                        data.Add("Language", "en");
                    phandler.hasselectedlanguage = true;
                    phandler.forcefinish = true;
                    return;
                }

                SendReply(netuser, result5);
                if (data.ContainsKey("Language"))
                {
                    phandler.hasselectedlanguage = true;
                    phandler.forcefinish = true;
                    return;
                }

                dolanguage(netuser, result5);
                return;
                var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
                var playervpn = (jsonresponse["confidence:"].ToString());
                SendReply(netuser, playervpn);
            }, this);
        }
    }

}