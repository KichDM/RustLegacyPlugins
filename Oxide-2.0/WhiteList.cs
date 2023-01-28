using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;

namespace Oxide.Plugins
{
    [Info("Whitelist", "TrecTar", "0.0.1")]

    class WhiteList : RustLegacyPlugin
    {
        static string Chattag = "WhiteList";
        string mensaje = "Para entrar al servidor debes estar en la [color cyan]whitelist[color white], para entrar en ella, debes entrar al [color orange]discord.           [color green]https://discord.gg/ux5G26nA4g";

        bool Acesso(NetUser netUser)
        {
            if (netUser.CanAdmin())
            { 
                return
                true;
            }

            if(permission.UserHasPermission(netUser.playerClient.userID.ToString(), "wl")) return true;
            return false;
        }

        bool AdminAcces(NetUser netuser)
        {
            if (netuser.CanAdmin())
            {
                return
                true;
            }

            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "wladmin")) return true;
            return false;
        }

        void OnServerInitialized()
        {
            permission.RegisterPermission("wl", this);
			permission.RegisterPermission("wladmin", this);
        }

        void OnPlayerConnected(NetUser netUser)
        {
            if (!Acesso(netUser))
            {
                foreach (NetUser todos in rust.GetAllNetUsers())
                {
                    rust.SendChatMessage(todos, Chattag, string.Format("{0}[color red] entro al servidor sin estar en el registro.", netUser.displayName));
                }

                timer.Once(30f, () =>
                {
                    //Aviso Chat
                    rust.SendChatMessage(netUser, Chattag, "Tu no estas en la [color orange]whitelist.");
                    rust.SendChatMessage(netUser, Chattag, "[color cyan]Para ingresar en ella, ingresa al discord del servidor.");
                });

                timer.Once(60f, () =>
                {
                    //Aviso DeathScreen
                    rust.RunClientCommand(netUser, "deathscreen.reason " + '"' + mensaje + '"');
                    rust.RunClientCommand(netUser, "deathscreen.show");

                    //Kick
                    netUser.Kick(NetError.Facepunch_Kick_RCON, true);

                    //Consola
                    Puts($"{netUser.displayName} fue kickeado por no estar en la whitelist.");
                    return;
                });
            }

            if (Acesso(netUser))
            {
                Puts($"{netUser.displayName} esta registrado en la whitelist.");
            }
        }

        [ChatCommand("add")]
        void cmdAddWL(NetUser netuser, string command, string[] args)
        {
            NetUser targetuser = rust.FindPlayer(args[0]);
            string permiso = "wl";

            if (!AdminAcces(netuser))
            {
                rust.SendChatMessage(netuser, Chattag, "[color orange]No tienes permisos para usar este comando");
                return;
            }

            if (targetuser == null)
            {
                rust.SendChatMessage(netuser, Chattag, "[color orange]Jugador no encontrado");
                return;
            }

            rust.RunServerCommand("oxide.grant user " + targetuser.playerClient.userID.ToString() + " " + permiso);
			
			rust.SendChatMessage(targetuser, Chattag, "[color yellow]Seras kickeado en 5 segundos, ingresa de nuevo al servidor.");
			timer.Once(5f, () =>
            {
                 targetuser.Kick(NetError.Facepunch_Kick_RCON, true);
            });
			
			foreach (NetUser todos in rust.GetAllNetUsers())
            {
                 rust.SendChatMessage(todos, Chattag, string.Format("{0}[color green] fue agregado a la whitelist por [color white]{1}",targetuser.displayName, netuser.displayName));
				 rust.SendChatMessage(todos, Chattag, "[color yellow] Sera kickeado en un momento.");
            }
            return;
        }

        [ChatCommand("del")]
        void cmdDeleteWL(NetUser netuser, string command, string[] args)
        {
            NetUser targetuser = rust.FindPlayer(args[0]);
            string permiso = "wl";

            if (!AdminAcces(netuser))
            {
                rust.SendChatMessage(netuser, Chattag, "[color orange]No tienes permisos para usar este comando.");
                return;
            }

            if (targetuser == null)
            {
                rust.SendChatMessage(netuser, Chattag, "[color orange]Jugador no encontrado.");
                return;
            }

            rust.RunServerCommand("oxide.revoke user " + targetuser.playerClient.userID.ToString() + " " + permiso);
			
			rust.SendChatMessage(targetuser, Chattag, "[color yellow] Seras kickeado en 5 segundos, hasta pronto.");
			timer.Once(5f, () =>
            {
                 targetuser.Kick(NetError.Facepunch_Kick_RCON, true);
            });
			
			foreach (NetUser todos in rust.GetAllNetUsers())
            {
                 rust.SendChatMessage(todos, Chattag, string.Format("{0}[color red] fue removido de la whitelist por [color white]{1}",targetuser.displayName, netuser.displayName));
				 rust.SendChatMessage(todos, Chattag, "[color yellow] Sera kickeado en un momento.");
            }
            return;
        }
    }
}