using System;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("Server Information Donate", "Max", "1.0.0")]
    public class Donate : RustLegacyPlugin
    {

        #region Configuration Data
        // Do not modify these values, to configure this plugin edit
        // 'ServerInfo.json' in your server's config folder.
        // <drive>:\...\oxide\config\

        bool configChanged;
        bool configCreated;

        // Plugin settings
        string defaultChatPrefix = "Lucky Rust♛";

        string chatPrefix;

        // Broadcaster settings
        bool defaultBroadcasterEnabled = true;
        List<object> defaultBroadcasts = new List<object> { "[COLOR#A0000F]➩[COLOR#FFFF00] Сервер [COLOR#FFFFFF]Lucky Rust♛ [COLOR#FFFF00]EXTENDET [COLOR#FFFF00]Наша группа ВК: [COLOR#FFFFFF]vk.com/lucky_rusts", "[COLOR#A0000F]➩[COLOR#FFFF00] Цены на Ранги: команда [COLOR#FFFFFF]/donate" };
        int defaultBroadcastInterval = 150;
        bool defaultShowChatPrefixB = true;

        bool broadcasterEnabled;
        List<string> broadcasts = new List<string>();
        int broadcastInterval;
        bool showChatPrefixB;

        // Donate settings
        bool defaultDonateEnabled = true;
        List<object> defaultDonate = new List<object> { "[COLOR#A0000F]➩[COLOR#FFFF00] 1. Rank VIP [COLOR#FFFFFF]100р", "[COLOR#A0000F]➩[COLOR#FFFF00] 2. Rank KILLER [COLOR#FFFFFF]200р", "[COLOR#A0000F]➩[COLOR#FFFF00] 3. Rank BOSS [COLOR#FFFFFF]350р", "[COLOR#A0000F]➩[COLOR#FFFF00] 4. Rank ROBOT [COLOR#FFFFFF]500р", "[COLOR#A0000F]➩[COLOR#FFFF00] 5. Rank ADMIN [COLOR#FFFFFF]850р", "[COLOR#A0000F]➩[COLOR#FFFF00] 6. Rank BATYA [COLOR#FFFFFF]1000р", "[COLOR#A0000F]➩[COLOR#FFFF00] 7. Подробности в группе: [COLOR#FFFFFF]vk.com/lucky_rusts" };
        bool defaultShowChatPrefixR = true;

        bool donateEnabled;
        List<string> donate = new List<string>();
        bool showChatPrefixR;

        #endregion

        Random random = new Random();

        int previouslyBroadcastedMessage = -1;

        void Loaded()
        {
            LoadConfigData();

            if (broadcasterEnabled)
                timer.Repeat(broadcastInterval, 0, () => BroadcastMessage());

            if (donateEnabled)
                cmd.AddChatCommand("donate", this, "ShowDonate");
        }

        protected override void LoadDefaultConfig()
        {
            configCreated = true;
            Warning("New configuration file created.");
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

        void ShowDonate(NetUser player, string cmd, string[] args)
        {
            foreach (var rule in donate)
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

            // Broadcaster settings
            broadcasterEnabled = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "Enabled", defaultBroadcasterEnabled));
            var tempbroadcasts = GetConfigValue("BroadCasterSettings", "BroadcastMessages", defaultBroadcasts) as List<object>;
            broadcastInterval = Convert.ToInt16(GetConfigValue("BroadcasterSettings", "Interval", defaultBroadcastInterval));
            showChatPrefixB = Convert.ToBoolean(GetConfigValue("BroadcasterSettings", "ShowChatPrefix", defaultShowChatPrefixB));

            // Donate settings
            donateEnabled = Convert.ToBoolean(GetConfigValue("DonateSettings", "Enabled", defaultDonateEnabled));
            var tempdonate = GetConfigValue("DonateSettings", "Donate", defaultDonate);
            showChatPrefixR = Convert.ToBoolean(GetConfigValue("DonateSettings", "ShowChatPrefix", defaultShowChatPrefixR));

            // Handle broadcaster & donate lists
            broadcasts.Clear();
            foreach (var str in tempbroadcasts)
                broadcasts.Add(str.ToString());

            donate.Clear();
            foreach (var str in tempdonate as List<object>)
                donate.Add(str.ToString());

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
