using Oxide.Core;
using Oxide.Core.Plugins;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using RustProto;

/* BROUGHT TO YOU BY        
,.   ,.         .  .        `.---     .              . 
`|  / ,-. ,-. . |  |  ,-.    |__  . , |- ,-. ,-. ,-. |-
 | /  ,-| | | | |  |  ,-|   ,|     X  |  |   ,-| |   | 
 `'   `-^ ' ' ' `' `' `-^   `^--- ' ` `' '   `-^ `-' `'
 ~PrincessRadPants and Swuave
*/
namespace Oxide.Plugins
{


    [Info("ANTI CHEATER", "CONTRASTED", "1.0.0")]
    public class VENoRecoilTest : RustLegacyPlugin
    {
        void Loaded()
        {
            //Add permissions
            if (!permission.PermissionExists("anticheater")) permission.RegisterPermission("anticheater", this);
            if (!permission.PermissionExists("all")) permission.RegisterPermission("all", this);
        }

        //Returns if player has access
        bool hasAccess(NetUser netuser)
        {
            if (netuser.CanAdmin()) { return true; }
            else if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "anticheater"))
            {
                return true;
            }
            else if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "all"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void TestUser(NetUser targetuser)
        {
            rust.RunClientCommand(targetuser, "config.save");
            rust.RunClientCommand(targetuser, "input.mousespeed 999");
			rust.RunClientCommand(targetuser, "input.bind Left I I"); 
			rust.RunClientCommand(targetuser, "input.bind Right I I");
			rust.RunClientCommand(targetuser, "input.bind Up I I");
			rust.RunClientCommand(targetuser, "input.bind AltFire I I");
			rust.RunClientCommand(targetuser, "input.bind Down I I");
			rust.RunClientCommand(targetuser, "config.save");
        }
        void EndTest(NetUser targetuser)
        {
            rust.RunClientCommand(targetuser, "config.load");
			rust.RunClientCommand(targetuser, "input.mousespeed 5");
			rust.RunClientCommand(targetuser, "input.bind Left A None"); 
			rust.RunClientCommand(targetuser, "input.bind Right D None");
			rust.RunClientCommand(targetuser, "input.bind Up W None");
			rust.RunClientCommand(targetuser, "input.bind Down S None");
			rust.RunClientCommand(targetuser, "input.bind AltFire Mouse1 None");
        }

        //Chat Command
        [ChatCommand("pon")]
        void cmdRecoilTest(NetUser netuser, string command, string[] args)
        {
            //Make sure player has access to use command
            if (!hasAccess(netuser))
            {
                SendReply(netuser, "АНТИ ПИДОР ACTIVATED");
            }
            else if (args.Length != 1)
            {
                SendReply(netuser, "Syntax: /anticheater <playername>");
            }
            else
            {
                NetUser targetuser = rust.FindPlayer(args[0]);
                if (targetuser != null)
                {
                    TestUser(targetuser);
                }
            }
        }
        [ChatCommand("poff")]
        void cmdTestEnd(NetUser netuser, string command, string[] args)
        {
            //Make sure player has access to use command
            if (!hasAccess(netuser))
            {
                SendReply(netuser, "You do not have permission to use this command");
            }
            else if (args.Length != 1)
            {
                SendReply(netuser, "Syntax: /testend <playername>");
            }
            else
            {
                NetUser targetuser = rust.FindPlayer(args[0]);
                if (targetuser != null)
                {
                    EndTest(targetuser);
                }
            }
        }
    }
}