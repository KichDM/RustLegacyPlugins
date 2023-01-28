
using System;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("Server Information Announcer", "Mughisi", "1.0.0")]
    public class Announcer : RustLegacyPlugin
    {

        #region Configuration Data
        // Do not modify these values, to configure this plugin edit
        // 'ServerInfo.json' in your server's config folder.
        // <drive>:\...\oxide\config\

        bool configChanged;
        bool configCreated;

        // Plugin settings
        string defaultChatPrefix = "Информация";

        string chatPrefix;

        // Join/Leave watcher settings
        bool defaultWatcherEnabled = true;
        bool defaultShowChatPrefixW = true;
        bool defaultLog = true;

        bool watcherEnabled;
        bool showChatPrefixW;
        bool log;

        // Broadcaster settings
        bool defaultBroadcasterEnabled = true;
        List<object> defaultBroadcasts = new List<object> { "[color#FF3300]Команды сервера [color#CCFF33] /mod [color#9900FF]✇", "[color#FF3300]Команды сервера[color#66CCFF]/stats , [color#FF66CC]/w [color#9900FF]✇","[color#FF3300]/unfriend[color#CCFF33] ник [color#9900FF]Удалить друга с PvE"};
        int defaultBroadcastInterval = 30;
        bool defaultShowChatPrefixB = true;

        bool broadcasterEnabled;
        List<string> broadcasts = new List<string>();
        int broadcastInterval;
        bool showChatPrefixB;

        // Rules settings
        bool defaultRulesEnabled = true;
        List<object> defaultRules = new List<object> { "[COLOR#1AEF38]➭  [COLOR#FFCC66]Донат сервера [COLOR#1AEF38] ✉ ", "[COLOR#FFFFFF]Vip[COLOR#1AEF38] 50 [COLOR#FFCC66]- рублей [COLOR#1AEF38] х15[COLOR#FFCC66]дней", "[COLOR#FFFFFF]Lord[COLOR#1AEF38] 150 [COLOR#FFCC66]- рублей [COLOR#1AEF38] х30[COLOR#FFCC66]дней","[COLOR#FFFFFF]BOSS[COLOR#1AEF38] 250 [COLOR#FFCC66]- рублей [COLOR#1AEF38] х30[COLOR#FFCC66]дней","[COLOR#FFFFFF]Модер[COLOR#1AEF38] 100 [COLOR#FFCC66]- рублей [COLOR#1AEF38] х30[COLOR#FFCC66]дней","[COLOR#FFFFFF]Админ[COLOR#1AEF38] 350 [COLOR#FFCC66]- рублей [COLOR#1AEF38] х30[COLOR#FFCC66]дней" };
        bool defaultShowChatPrefixR = true;

        bool rulesEnabled;
        List<string> rules = new List<string>();
        bool showChatPrefixR;

        // Plugin messages
        string defaultJoined = "[color#CCFF33]На сервере стоят приватные плагины,для хорошей игры";
        string defaultLeft = "[color#CCFF33]Приглашайте друзей к нам на [color#FFFFFF][Сервер]";

        string joined;
        string left;

        #endregion

        Random random = new Random();

        int previouslyBroadcastedMessage = -1;

        void Loaded()
        {
            LoadConfigData();

            if (broadcasterEnabled)
                timer.Repeat(broadcastInterval, 0, () => BroadcastMessage());

            if (rulesEnabled)
                cmd.AddChatCommand("rules42152415", this, "ShowRules42152415");
        }

        protected override void LoadDefaultConfig()
        {
            configCreated = true;
            Warning("New configuration file created.");
        }

        private void OnPlayerConnected(NetUser player)
        {
            if (!watcherEnabled) return;
            var message = string.Format(joined, player.displayName);

            if (log)
                Log(message);

            if (showChatPrefixW)
                BroadcastMessage(chatPrefix, message);
            else
                BroadcastMessage(message);
        }

        private void OnPlayerDisconnected(uLink.NetworkPlayer player)
        {
            if (!watcherEnabled) return;
            var netUser = player.GetLocalData<NetUser>();
            var message = string.Format(left, netUser.displayName);

            if (log)
                Log(message);

            if (showChatPrefixW)
                BroadcastMessage(chatPrefix, message);
            else
                BroadcastMessage(message);
        }

        void BroadcastMessage()
        {
            int randomMessage = random.Next(broadcasts.Count);
            while (randomMessage == previouslyBroadcastedMessage)
                randomMessage = random.Next(broadcasts.Count);

            previouslyBroadcastedMessage = randomMessage;
            var message = broadcasts[randomMessage];

            if (showChatPrefixB)
                 BroadcastMessage(chatPrefix, message);
            else
                BroadcastMessage(message);
        }

        void ShowRules(NetUser player, string cmd, string[] args)
        {
            foreach (var rule in rules)
            {
                var message = rule;

                if (showChatPrefixR)
                    SendMessage(player, chatPrefix, message);
                else
                    SendMessage(player, message);
            }
        }

        void Log(string msg) => Puts($"{Title} : {msg}");

        void Warning(string msg) => PrintWarning($"{Title} : {msg}");

        string QuoteSafe(string str) => "\"" + str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' }) + "\"";

        void SendMessage(NetUser netUser, string name, string message = null)
        {
            if (message == null)
            {
                message = name;
                name = "Server";
            }

            ConsoleNetworker.SendClientCommand(netUser.networkPlayer, $"chat.add {QuoteSafe(name)} {QuoteSafe(message)}");
        }

        void BroadcastMessage(string name, string message = null)
        {
            if (message == null)
            {
                message = name;
                name = "Server";
            }
            ConsoleNetworker.Broadcast($"chat.add {QuoteSafe(name)} {QuoteSafe(message)}");
        }

        void LoadConfigData()
        {
            // Plugin settings
            chatPrefix = Convert.ToString(GetConfigValue("Settings", "ChatPrefix", defaultChatPrefix));

            // Join/Leave watcher settings
            watcherEnabled = Convert.ToBoolean(GetConfigValue("ConnectionSettings", "Enabled", defaultWatcherEnabled));
            showChatPrefixW = Convert.ToBoolean(GetConfigValue("ConnectionSettings", "ShowChatPrefix", defaultShowChatPrefixW));
            log = Convert.ToBoolean(GetConfigValue("ConnectionSettings", "Log", defaultLog));

            // Broadcaster settings
            broadcasterEnabled = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "Enabled", defaultBroadcasterEnabled));
            var tempbroadcasts = GetConfigValue("BroadCasterSettings", "BroadcastMessages", defaultBroadcasts) as List<object>;
            broadcastInterval = Convert.ToInt16(GetConfigValue("BroadcasterSettings", "Interval", defaultBroadcastInterval));
            showChatPrefixB = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "ShowChatPrefix", defaultShowChatPrefixB));

            // Rules settings
            rulesEnabled = Convert.ToBoolean(GetConfigValue("RulesSettings", "Enabled", defaultRulesEnabled));
            var temprules = GetConfigValue("RulesSettings", "Rules", defaultRules);
            showChatPrefixR = Convert.ToBoolean(GetConfigValue("RulesSettings", "ShowChatPrefix", defaultShowChatPrefixR));

            // Plugin messages
            joined = Convert.ToString(GetConfigValue("Messages", "PlayerJoined", defaultJoined));
            left = Convert.ToString(GetConfigValue("Messages", "PlayerLeft", defaultLeft));

            // Handle broadcaster & rules lists
            broadcasts.Clear();
            foreach (var str in tempbroadcasts)
                broadcasts.Add(str.ToString());

            rules.Clear();
            foreach (var str in temprules as List<object>)
                rules.Add(str.ToString());

            if (configChanged)
            {
                Warning("The configuration file was updated!");
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
