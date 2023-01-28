using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustExtended;
using UnityEngine;

namespace Oxide.Plugins
{
    // Start writing: 10/04/2020

    [Info("SRaidBlock", "Sh1ne", "1.0.0")]
    class SRaidBlock : RustLegacyPlugin
    {
        const float RaidBlockTime = 300f;
        const float RaidBlockDistance = 150f;
        
        // Remember: Always check if attributes equals to blockedcommands
        readonly string[] BlockedCommands = new string[] { "clan", "home", "tp", "buy", "sell", "destroy" };

        // Remember: Block commands manually in needed plugin
        readonly string[] BlockedPluginCommands = new string[] { "w", "tpr" };

        readonly string ChatName = "RaidBlock";
        readonly float RaidBlockDistanceMagnitude = RaidBlockDistance * RaidBlockDistance;

        Dictionary<ulong, DateTime> players = new Dictionary<ulong, DateTime>();

        /* Use it by oxide CallHook to prevent plugin commands */
        private bool IsPlayerBlocked(ulong userID)
        {
            return GetPlayerBlockRemainTime(userID).HasValue;
        }

        void OnKilled(TakeDamage damage, DamageEvent evt)
        {
            if (damage != null && (damage is StructureComponentTakeDamage || damage is ProtectionTakeDamage) && evt.damageTypes == DamageTypeFlags.damage_explosion)
            {
                foreach (var playerClient in PlayerClient.All)
                {
                    if (playerClient?.hasLastKnownPosition == true)
                    {
                        if (Vector3.Distance(damage.transform.position, playerClient.lastKnownPosition) < RaidBlockDistance)
                        {
                            if (!players.ContainsKey(playerClient.userID))
                            {
                                players.Add(playerClient.userID, DateTime.Now);
							rust.SendChatMessage(NetUser.FindByUserID(playerClient.userID), ChatName, $"[COLOR #FFFF00]Вам заблокированы команды [COLOR #FFFFFF]/{String.Join(", /", BlockedCommands.Concat(BlockedPluginCommands).ToArray())} [COLOR #FFFF00]на [COLOR #FFFFFF]{RaidBlockTime} [COLLEGE R #FFFFFF]секунд");
                            }
                            else
                            {
                                if (DateTime.Now - players[playerClient.userID] >= TimeSpan.FromSeconds(RaidBlockTime))
                                {
                                    rust.SendChatMessage(NetUser.FindByUserID(playerClient.userID), ChatName, $"[COLOR#FFFF00]Вам заблокированы команды [COLOR #FFFFFF]/{String.Join(", /", BlockedCommands.Concat(BlockedPluginCommands).ToArray())} [COLOR #FFFF00]на [COLOR #FFFFFF]{RaidBlockTime} [COLOR #FFFF00]секунд");
                                }
                                players[playerClient.userID] = DateTime.Now;
                            }
                        }
                    }
                }
            }
        }

        private void RunCommand(NetUser netUser, string command, string[] args)
        {
            UserData userData = Users.GetBySteamID(netUser.userID);
            if (userData == null) return;

            string argsStr = args.Length > 0 ? args.Select(s => "\"" + s + "\"").Aggregate((a, b) => a + " " + b) : "";
            string fullCommand = "/" + command + " " + argsStr;            

            NetUser User = netUser;
            string Command = command;
            string[] Args = Facepunch.Utility.String.SplitQuotesStrings(argsStr.Trim());

            switch (command)
            {
                case "kit": Commands.Kit(User, userData, Command, Args); break;
                case "clan": Commands.Clan(User, userData, Command, Args); break;               
                case "home": Commands.Home(User, userData, Command, Args); break;
                case "tp": Commands.Teleport(User, userData, Command, Args); break;
                case "destroy": Commands.Destroy(User, userData, Command, Args); break;
                case "transfer": Commands.Transfer(User, userData, Command, Args); break;
                case "buy": case "sell":
                    if (Economy.Enabled) Economy.RunCommand(User, userData, Command, Args);
                    break;
            }
        }

        private TimeSpan? GetPlayerBlockRemainTime(ulong userID)
        {            
            if (players.ContainsKey(userID))
            {
                TimeSpan span = DateTime.Now - players[userID];
                if (span >= TimeSpan.FromSeconds(RaidBlockTime))
                {
                    players.Remove(userID);
                    return null;
                }

                TimeSpan timeLeft = TimeSpan.FromSeconds(RaidBlockTime) - span;
                return timeLeft;
            }
            return null;
        }

        private void CommandHandler(NetUser netUser, string command, string[] args)
        {
            TimeSpan? timeLeft = GetPlayerBlockRemainTime(netUser.userID);
            if (timeLeft.HasValue)
            {
                rust.SendChatMessage(netUser, ChatName, $"[COLOR#FF0000]Команда заблокирована Рейд-Блоком. Комманда будет доступна через {(int)timeLeft.Value.TotalSeconds} секунд");
            }
            else
            {
                RunCommand(netUser, command, args);
            }
        }

        bool? OnRunCommand(ConsoleSystem.Arg arg, bool reply)
        {
            string command = arg.Args[0].Replace("/", "");

            if (BlockedPluginCommands.Contains(command))
            {
                CommandHandler(arg.argUser, arg.Args[0], arg.Args);
            }
            
            return null;            
        }

        /* Blocked Commands */

        [ChatCommand("clan")]
        void cmdClan(NetUser netUser, string command, string[] args) => CommandHandler(netUser, command, args);

        [ChatCommand("home")]
        void cmdHome(NetUser netUser, string command, string[] args) => CommandHandler(netUser, command, args);

        [ChatCommand("tp")]
        void cmdTp(NetUser netUser, string command, string[] args) => CommandHandler(netUser, command, args);

        [ChatCommand("buy")]
        void cmdBuy(NetUser netUser, string command, string[] args) => CommandHandler(netUser, command, args);

        [ChatCommand("sell")]
        void cmdSell(NetUser netUser, string command, string[] args) => CommandHandler(netUser, command, args);

        [ChatCommand("destroy")]
        void cmdDestroy(NetUser netUser, string command, string[] args) => CommandHandler(netUser, command, args);
    }
}