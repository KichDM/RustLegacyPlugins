using System;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using DataStore = Oxide.Core.Interface;
using Oxide.Core.Configuration;
using System.Data;

namespace Oxide.Plugins
{
    [Info("Anuncio", "PionixZ e PINK", "0.2.0")]
    class Anuncio : RustLegacyPlugin
    {
        #region Configuration Data

        bool configChanged;
        bool configCreated;

        string chatprefix = "✯NovaLand✯";


        bool defaultLog = true;

        bool watcherEnabled;
        bool showChatPrefixW;
        bool log;

        bool defaultBroadcasterEnabled = true;
        List<object> defaultBroadcasts = new List<object> { "[color red]➤  [color white]Em caso de cheaters utilize [color cyan]/report", "[color red]➤  [color white]Nosso servidor possui diversos comandos - [color cyan]/comandos", "[color red]➤  [color white]Para adquirir seu vip acesse - [color cyan]em desenvolvimento", "[color red]➤  [color white]O uso do [color cyan]discord[color white] é obrigatório em nosso servidor.", "[color red]➤  [color white]Vagas disponiveis na staff - [color cyan]/contato", "[color red]➤  [color white]Leia as [color cyan]regras[color white] do servidor para que tenha uma boa jogabilidade.", "[color red]➤  [color white]Acesse o discord do servidor - [color cyan]discord.gg/zjTBChqhYj", "[color red]➤  [color white]Utilize [color cyan]/vip[color white][color white] para ver os beneficios de ser um jogador vip."};
        int defaultBroadcastInterval = 60;
        bool defaultShowChatPrefixB = true;

        bool broadcasterEnabled;
        List<string> broadcasts = new List<string>();
        int broadcastInterval;
        bool showChatPrefixB;

        #endregion

        Random random = new Random();

        int previouslyBroadcastedMessage = -1;

        void Loaded()
        {

                LoadConfigData();

                if (broadcasterEnabled)
                    timer.Repeat(broadcastInterval, 0, () => BroadcastMessage());
           

        }


        protected override void LoadDefaultConfig()
        {
           
                configCreated = true;
                Warning("Nova configuração criada.");
           
        }

        void BroadcastMessage()
        {
            
                int randomMessage = random.Next(broadcasts.Count);
                while (randomMessage == previouslyBroadcastedMessage)
                    randomMessage = random.Next(broadcasts.Count);

                previouslyBroadcastedMessage = randomMessage;
                var message = broadcasts[randomMessage];

                if (showChatPrefixB)
                    BroadcastMessage(chatprefix, message);
                else
                    BroadcastMessage(message);
            
        }

        void Log(string msg) => Puts($"{Title} : {msg}");

        void Warning(string msg) => PrintWarning($"{Title} : {msg}");

        string QuoteSafe(string str) => "\"" + str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' }) + "\"";

        void SendMessage(NetUser netUser, string name, string message = null)
        {
            
                if (message == null)
                {
                    message = name;
                    name = "\\n\\n\\n";
                }

                ConsoleNetworker.SendClientCommand(netUser.networkPlayer, $"chat.add {QuoteSafe(name)} {QuoteSafe(message)}");
            
        }

        void BroadcastMessage(string name, string message = null)
        {
            
                if (message == null)
                {
                    message = name;
                    name = "\\n\\n\\n";
                }
                ConsoleNetworker.Broadcast($"chat.add {QuoteSafe(name)} {QuoteSafe(message)}");
            
        }

        void LoadConfigData()
        {
           
                log = Convert.ToBoolean(GetConfigValue("ConnectionSettings", "Log", defaultLog));
                showChatPrefixB = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "ShowChatPrefix", defaultShowChatPrefixB));

                broadcasterEnabled = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "Enabled", defaultBroadcasterEnabled));
                var tempbroadcasts = GetConfigValue("BroadCasterSettings", "BroadcastMessages", defaultBroadcasts) as List<object>;
                broadcastInterval = Convert.ToInt16(GetConfigValue("BroadcasterSettings", "Interval", defaultBroadcastInterval));
                showChatPrefixB = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "ShowChatPrefix", defaultShowChatPrefixB));

                broadcasts.Clear();
                foreach (var str in tempbroadcasts)
                    broadcasts.Add(str.ToString());


                if (configChanged)
                {
                    Warning("Configuração atualizada");
                    SaveConfig();
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
                    configChanged = true;
                }
                if (!data.TryGetValue(setting, out value))
                {
                    value = defaultValue;
                    data[setting] = value;
                    configChanged = true;
                }

                return value;
           
        }
    }
}
