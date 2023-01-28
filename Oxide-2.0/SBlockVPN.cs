// Reference: Newtonsoft.Json
using System;
using Oxide.Core.Plugins;
using System.Collections.Generic;
using UnityEngine;
using RustExtended;
using Oxide.Plugins;
using Newtonsoft.Json;
using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("SBlockVPN", "Sh1ne", "1.0.1")]
    class SBlockVPN : RustLegacyPlugin
    {
        // ключи для плагина брать на сайте https://iphub.info и вставить в поле X-Key
        List<string> GoodIP = new List<string>();
        List<string> BadIP = new List<string>();

        List<ulong> WhiteListedPlayers;

        void Init()
        {
            try
            {
                WhiteListedPlayers = Interface.Oxide.DataFileSystem.ReadObject<List<ulong>>("VPN_WhiteList");
            }
            catch
            {
                WhiteListedPlayers = new List<ulong>();
            }
        }

        void SavePluginData()
        {
            Interface.GetMod().DataFileSystem.WriteObject("VPN_WhiteList", WhiteListedPlayers);
        }

        [ChatCommand("ignorevpn")]
        void cmdIgnoreVpn(NetUser netUser, string command, string[] args)
        {
            if (!netUser.CanAdmin())
            {
                rust.SendChatMessage(netUser, "BlockVPN", "У вас нет прав для использования данной комманды!");
                return;
            }

            if (args.Length != 1)
            {
                rust.SendChatMessage(netUser, "BlockVPN", "Использование комманды: /ignorevpn \"ник игрока\"");
                return;
            }

            UserData userData = Users.Find(args[0]);
            if (userData == null)
            {
                rust.SendChatMessage(netUser, "BlockVPN", "Не удалось найти игрока с таким ником!");
                return;
            }

            WhiteListedPlayers.Add(userData.SteamID);
            SavePluginData();
        }

        void OnPlayerConnected(NetUser netUser)
        {
            if (netUser != null && netUser.playerClient != null)
            {
                string targetIp = netUser.networkPlayer.externalIP;

                if (netUser.CanAdmin() || GoodIP.Contains(targetIp) || WhiteListedPlayers.Contains(netUser.userID))
                {
                    return;
                }

                if (BadIP.Contains(targetIp))
                {
                    rust.SendChatMessage(netUser, "BlockVPN", "[color red]Обнаружен VPN/Proxy!");
                    netUser.Kick(NetError.Facepunch_Kick_RCON, true);
                    return;
                }

                var timeout = 200f;
                Dictionary<string, string> Headers = new Dictionary<string, string>()
                {
                    { "X-Key", "Njg3Mjp6UFAxYlpFMGRLcWEzbTJqbVJMRjM5Z2JvUndZdjAzTQ==" }
                };
                webrequest.EnqueueGet($"http://v2.api.iphub.info/ip/{targetIp}", (code, response) => GetCallback(code, response, netUser), this, Headers, timeout);
            }
        }

        void GetCallback(int code, string response, NetUser netUser)
        {
            if (response == null || code != 200)
            {
                Helper.LogChat("[ERROR] Cant get IP INFO response for player " + netUser.displayName + $" | Error code: {code}", true);
                return;
            }

            Dictionary<string, object> jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            string block = jsonresponse["block"].ToString();

            if (block == "1")
            {
                BadIP.Add(netUser.networkPlayer.externalIP);
                rust.SendChatMessage(netUser, "SBlockVPN", "Обнаружен VPN/Proxy!");
                Helper.LogChat($"[BlockVPN] Kicked player [{netUser.displayName}:{netUser.userID}] trying connect with VPN!", true);
                netUser.Kick(NetError.Facepunch_Kick_RCON, true);
            }
            else
            {
                GoodIP.Add(netUser.networkPlayer.externalIP);
            }
        }
    }
}