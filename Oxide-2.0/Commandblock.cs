using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using DataStore = Oxide.Core.Interface;
using Oxide.Core.Configuration;

namespace Oxide.Plugins
{
    [Info("Commandblock", "PionixZ", 1.1)]
    [Description("Block some console commands")]

    class Commandblock : RustLegacyPlugin
    {
        static string SystemName = "Server";
        public static List<object> block = new List<object>() { "unbanall", "status", "rcon.password" };
        
        object OnRunCommand(ConsoleSystem.Arg arg, bool shouldAnswer)
        {
           
                if (arg == null) return null;
                if (arg.argUser == null) return null;
                string command;
                if (arg.Class != "global")
                {
                    command = arg.Class + "." + arg.Function;
                    if (!block.Contains(command)) return null;
                }
                else
                {
                    if (!block.Contains(arg.Function)) return null;
                }
                NetUser netuser = arg.argUser.connection.netUser;
                rust.SendChatMessage(netuser, SystemName, "[color yellow]Não foi possivel executar este comando.");
           
            return false;
        }
    }
}