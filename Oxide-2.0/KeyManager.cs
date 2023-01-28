using System;
using System.Collections.Generic;
using Oxide.Core;
using System.Globalization;

//Powered 

namespace Oxide.Plugins
{
    [Info("KeyManager", "Loading", 1.0)]
    class KeyManager : RustLegacyPlugin
    {
        static Timer timerCheckControllable;

        static string Prefixo = "server";
        static string Permissao = "keymanager.allow";

        static Dictionary<string, StoredData> KeysManager = new Dictionary<string, StoredData>();

        StoredData data;
        public class StoredData
        {
            public Dictionary<string, object[]> Dados = new Dictionary<string, object[]>();
        }
        private StoredData GetPlayerData(string ID)
        {
            if (!KeysManager.TryGetValue(ID, out data))
            {
                data = new StoredData();
                KeysManager.Add(ID, data);
            }
            return data;
        }
        void OnServerInitialized()
        {
            //Prefixo = Convert.ToString(GetConfigValue("Configurações", "Prefixo", Prefixo));
        }
        void SaveData() { Interface.Oxide.DataFileSystem.WriteObject("KeyManager", KeysManager); }
        void Loaded() { KeysManager = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<string, StoredData>>("KeyManager"); }
        //void Unload() { SaveData();  }

        void OnPlayerConnected(NetUser netuser)
        {
            string id = netuser.userID.ToString();
            if (KeysManager.TryGetValue(id, out data))
            {
                data = GetPlayerData(id);
                foreach (var pair in data.Dados)
                {
                    object[] Dados = data.Dados[pair.Key];

                    string final = Dados[4].ToString();
                    IFormatProvider culture = new CultureInfo("pt-BR"); //instancia o formato do brasil
                    DateTime inicio = DateTime.Now;
                    DateTime fim = DateTime.ParseExact(final, "dd/MM/yyyy HH:mm:ss", culture);
                    TimeSpan resultado = fim.Subtract(inicio);
                    if (resultado.Days < 0 || resultado.Hours < 0 || resultado.Seconds < 0)
                    {
                        rust.RunServerCommand(string.Format("oxide.revoke user {0} {1}", netuser.userID.ToString(), pair.Key));
                        data.Dados.Remove(pair.Key);
                        SaveData();
                        timerCheckControllable = timer.Repeat(1f, 0, () =>
                        {
                            if (netuser.playerClient == null) { timerCheckControllable.Destroy(); return; }
                            if (netuser.playerClient.rootControllable != null)
                            {
                                rust.Notice(netuser, string.Format("Sua permisão ({0}) encerrou!!", pair.Key), "!", 15);
                                timerCheckControllable.Destroy();
                            }
                        });
                    }
                }
            }
        }
        bool Acess(NetUser netuser)
        {
            string id = netuser.userID.ToString();
            if (netuser.CanAdmin()) return true;
            if (permission.UserHasPermission(id, Permissao)) return true;
            return false;
        }
        [ChatCommand("adddias")]
        void Cmdteste(NetUser netuser, string cmd, string[] args)
        {
            if (!Acess(netuser)) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color red]Voce nao pode usar este comando!"); return; }
            if (args.Length < 3) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color #006400]Use /adddias (nick) (permissao) (quantidade de Dias) "); return; }
            NetUser targetuser = rust.FindPlayer(args[0]);
            if (targetuser == null) { rust.SendChatMessage(netuser, Prefixo, string.Format("[color red]Player [color white]{0} [color red]não encontrado ou offiline!", args[0])); return; }
            int dias;
            if (!(Int32.TryParse(args[2], out dias))) { rust.SendChatMessage(netuser, Prefixo, "[color #006400]Algo deu errado, você esta usando numero nos [color white]dias?"); return; }
            if (!KeysManager.TryGetValue(targetuser.userID.ToString(), out data)) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color red]Não encontramos este player na data"); return; }
            data = GetPlayerData(targetuser.userID.ToString());
            if (!data.Dados.ContainsKey(args[1])) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color red]Esse player nao tem essa permisão"); return; }

            try
            {
                object[] dados = data.Dados[args[1]];  //instancia o nome da perm
                string dataatual = dados[4].ToString(); // instancia o dia que finaliza a perm
                IFormatProvider culture = new CultureInfo("pt-BR"); //instancia o formato do brasil
                DateTime dateVal = DateTime.ParseExact(dataatual, "dd/MM/yyyy HH:mm:ss", culture); // convert a string to DateTime
                DateTime Adicionado = dateVal.AddDays(dias); // adiciona os dias
                string add = Adicionado.ToString("dd/MM/yyyy HH:mm:ss"); // volta para string
                object[] teste = new object[] { dados[0], dados[1], dados[2], dados[3], add };
                data.Dados[args[1]] = teste;
                SaveData();
                rust.SendChatMessage(netuser, Prefixo, string.Format("[color red]Você add mais [color white]{0} [color red]dias da permisão [color white]{1} [color red]ao player [color white]{2} [color red]({3})", dias, args[1], targetuser.displayName, add));
                rust.SendChatMessage(targetuser, Prefixo, string.Format("[color #006400]O admin [color white]{0} [color #006400]add mais [color white]{1} [color #006400]da permisão [color white]{2} [color #006400]({3})", netuser.displayName, dias, args[1], add));
            }
            catch (Exception ex)
            {
                Puts("Erro: " + ex);
                rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color #006400]Algo deu errado :/");
            }

        }

        [ChatCommand("key")]
        void CmdCommand(NetUser netuser, string cmd, string[] args)
        {
            if (!Acess(netuser)) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color #006400]Voce nao pode usar este comando!"); return; }
            if (args.Length < 3) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color #006400]Use /key (nick) (permissao) (quantidade de Dias) "); return; }
            NetUser targetuser = rust.FindPlayer(args[0]);
            if (targetuser == null) { rust.SendChatMessage(netuser, Prefixo, string.Format("[color #006400]Player [color white]{0} [color #006400]não encontrado ou offiline!", args[0])); return; }
            string permisao = args[1];
            int dias;
            if (!(Int32.TryParse(args[2], out dias))) { rust.SendChatMessage(netuser, Prefixo, "[color red]Algo deu errado, você esta usando numero nos dias?"); return; }
            object Instancia = AddKeyManager(netuser, targetuser, permisao, dias);
            if (Instancia is bool)
            {
                rust.SendChatMessage(netuser, Prefixo, string.Format("[color #006400]Permisão [color white]{0} [color #006400]Adicionada ao player [color white]{1} [color #006400]por [color white]{2} [color #006400]Dias ({3})", permisao, targetuser.displayName, dias, DateTime.Now.AddDays(dias).ToString("dd/MM/yyyy HH:mm:ss")));
                rust.SendChatMessage(targetuser, Prefixo, string.Format("[color #006400]O admin [color white]{0} [color #006400]Adicionou uma permisão a você por [color white]{1} [color #006400]Dias ({2})", netuser.displayName, dias, DateTime.Now.AddDays(dias).ToString("dd/MM/yyyy HH:mm:ss")));
                return;
            }
            else if (Instancia is string)
            {
                rust.SendChatMessage(netuser, Prefixo, Instancia.ToString());
                return;
            }
            else
            {
                Puts("'-'");
            }
        }
        [ChatCommand("keymanager")]
        void CmdKmr(NetUser netuser, string cmd, string[] args)
        {
            if (!Acess(netuser)) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color red]Voce nao pode usar este comando!"); return; }
            if (args.Length < 2) { rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color #006400]Use /keymanager (nick) (permissao)"); return; }

            string id = string.Empty;
            if (args.Length == netuser.userID.ToString().Length) { id = args[0]; }
            else { NetUser targetuser = rust.FindPlayer(args[0]); id = targetuser.userID.ToString(); }

            string permisao = args[1];

            if (KeysManager.TryGetValue(id, out data))
            {
                data = GetPlayerData(id);
                if(data.Dados.ContainsKey(permisao))
                {
                    data.Dados.Remove(permisao);
                    rust.SendChatMessage(netuser, Prefixo, string.Format("[color #006400]Permisão [color white]{0} [color #006400]Removida da SteamId [color white]{1}", permisao, id));
                    SaveData();
                }
                else
                {
                    rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color white]Esse player nao tem essa permissao"); return;
                }

            }
            else
            {
                rust.SendChatMessage(netuser, Prefixo, "[color red][!] [color #006400]Nao encontramos esse player no banco de dados"); return;
            }



            
        }
        object AddKeyManager(NetUser netuser, NetUser targetuser, string permissao, int dias)
        {
            data = GetPlayerData(targetuser.userID.ToString());
            if (!permission.PermissionExists(permissao)) return "Permissao " + permissao + " não existe ou nao está registrada!";
            if (!data.Dados.ContainsKey(permissao))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string nows = now.ToString("dd/MM/yyyy HH:mm:ss");
                    DateTime end = now.AddDays(dias);
                    string ends = end.ToString("dd/MM/yyyy HH:mm:ss");
                    string nome = targetuser.displayName;
                    string Id = targetuser.userID.ToString();
                    string AP = netuser.displayName;
                    string ATE = nows;
                    string ACE = ends;
                    data.Dados.Add(permissao, new object[] { nome, Id, AP, ATE, ACE });
                    SaveData();
                    rust.RunServerCommand(string.Format("oxide.grant user {0} {1}", targetuser.userID.ToString(), permissao));
                    return true;
                }
                catch (Exception ex)
                {
                    Puts("Erro: " + ex);
                    return "Algo deu errado";
                }
            }
            else
            {
                return string.Format("[color #006400]O Player [color white]{0} [color #006400]Ja tem a permisão [color white]{1}. [color #006400]use /adddias ou /removekey", targetuser.displayName, permissao);

            }
        }

        object GetConfigValue(string category, string setting, object defaultValue)
        {
            var data = Config[category] as Dictionary<string, object>;
            object value;
            if (data == null)
            {
                data = new Dictionary<string, object>();
                Config[category] = data;
            }
            if (!data.TryGetValue(setting, out value))
            {
                value = defaultValue;
                data[setting] = value;
            }

            return value;
        }
        DateTime ConvertDate()
        {
            DateTime now = DateTime.Now;
            string data = now.ToString("dd/MM/yyyy HH:mm:ss");
            DateTime retorno = DateTime.Parse(data);
            return retorno;
        }
    }
}
