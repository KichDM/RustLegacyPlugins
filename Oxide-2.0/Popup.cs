using System;
using System.Collections.Generic;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Popup", "PINK", "0.1.0")]

    class Popup : RustLegacyPlugin
    {
        RustServerManagement serverManagement;

        string SystemName = "Server";
        static bool commandPopup;

        void OnServerInitialized()
        {
            try
            {
                SetupConfig();
                SetupChatCommands();

                serverManagement = RustServerManagement.Get();
                return;
            }
            catch (Exception)
            {

            }
        }

        void SetupConfig()
        {
            try
            {
                commandPopup = Config.Get<bool>("Settings", "commandPopup");
            }
            catch (Exception)
            {

            }
        }

        void Loaded()
        {
            try
            {
                if (!permission.PermissionExists("canpopup")) permission.RegisterPermission("canpopup", this);
            }
            catch (Exception)
            {

            }
        }

        protected override void LoadDefaultConfig()
        {
            Config["Settings"] = new Dictionary<string, object>
            {
                {"commandPopup", true},
            };
        }

        void SetupChatCommands()
        {
            try
            {
                if (commandPopup)
                    cmd.AddChatCommand("popup", this, "cmdPopup");
            }
            catch (Exception)
            {

            }
        }

        bool hasAccess(NetUser netuser)
        {
            if (netuser.CanAdmin())
                return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), "canpopup");
        }

        void cmdPopup(NetUser netUser, string command, string[] args)
        {
            try
            {
                ulong netUserID = netUser.userID;

                if (!hasAccess(netUser)) { rust.SendChatMessage(netUser, SystemName, "[color yellow]Você não tem permissão para usar este comando."); return; }

                if (args.Length == 0 || args == null)
                {
                    rust.SendChatMessage(netUser, SystemName, "[color yellow]Informe a mensagem que deseja enviar.");
                    return;
                }

                string message = "";

                foreach (string arg in args)
                {
                    message = message + " " + arg;
                }

                foreach (NetUser _netUser in rust.GetAllNetUsers())
                {
                    rust.Notice(_netUser, message, "✯");
                }

                Puts($"{netUser.displayName} {lang.GetMessage("enviou uma mensagem:", this)} {message}");

                return;
            }
            catch (Exception)
            {

            }
        }
    }
}