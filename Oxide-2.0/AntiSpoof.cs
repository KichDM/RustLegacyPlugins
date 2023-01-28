using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core;
using System.Threading;
using Oxide.Core.Plugins;
using RustExtended;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("AntiSpoof", "Romanchik34", "1.0.0")]

    class AntiSpoof : RustLegacyPlugin
    {
        int minRank = 15; // Минимальный ранг для использования /excludeip
        string chatname = "AntiSpoof";

        class Response
        {
            public string status;
            public string city;
        }
        #region Data
        class Data
        {
            public Dictionary<ulong, string> logins = new Dictionary<ulong, string>();
            public List<string> excludedIp = new List<string>();
        }
        Data data;
        void Loaded() { LoadData(); }
        void OnServerSave() { SaveData(); }
        void LoadData() { data = Interface.GetMod().DataFileSystem.ReadObject<Data>("AntiSpoofData"); }
        void SaveData() { Interface.GetMod().DataFileSystem.WriteObject("AntiSpoofData", data); }
        #endregion
        void OnUserApprove(ClientConnection connection, uLink.NetworkPlayerApproval approval, ConnectionAcceptor acceptor)
        {
            if (data.excludedIp.Contains(approval.ipAddress))
                return;
            Response objects;
            webrequest.EnqueueGet("http://ip-api.com/json/" + approval.ipAddress, (code, response) =>
            {
                if (response == null || code != 200)
                {
                    Helper.Log($"[AntiSpoof] Failed to check IP ({approval.ipAddress}), Player: [{connection.UserName}:{connection.UserID}] | Response is null", true);
                    return;
                }
                objects = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(response);
                if (objects.status == null || objects.status != "success")
                {
                    connection.netUser.Kick(NetError.NoError, true);
                    Helper.Log($"[AntiSpoof] Failed to check IP ({approval.ipAddress}), Player: [{connection.UserName}:{connection.UserID}]", true);
                    return;
                }
                if (!data.logins.ContainsKey(connection.UserID))
                {
                    data.logins.Add(connection.UserID, objects.city.ToString());
                    return;
                }
                if (objects.city != data.logins[connection.UserID])
                {
                    UserData user = Users.GetBySteamID(connection.UserID);
                    connection.netUser.Kick(NetError.Facepunch_Connector_VAC_Banned, true);
                    Debug.Log($"[AntiSpoof] Попытка зайти в аккаунт {connection.UserName} под другим IP (Старый: {data.logins[connection.UserID]}, новый: {approval.ipAddress})");
                    return;
                }
            }, this);
        }
        [ChatCommand("excludeip")] // /excludeip IP - разрешить игроку доступ несмотря на блок
        void CMD_Exclude(NetUser netuser, string command, string[] args)
        {
            UserData me = Users.GetBySteamID(netuser.userID);
            if (me.Rank < minRank)
            {
                rust.SendChatMessage(netuser, chatname, "[color red]Вы не можете использовать эту команду");
                return;
            }
            if (args.Length == 0)
            {
                rust.SendChatMessage(netuser, chatname, "[color red]Вы не вписали IP");
                return;
            }
            string ip = args[0];
            if (data.excludedIp.Contains(ip))
            {
                data.excludedIp.Remove(ip);
                rust.SendChatMessage(netuser, chatname, $"[color green]Вы удалили {ip} из исключений");
                return;
            }
            else
            {
                data.excludedIp.Add(ip);
                rust.SendChatMessage(netuser, chatname, $"[color green]Вы добавили {ip} в исключения");
                return;
            }
        }
    }
}
