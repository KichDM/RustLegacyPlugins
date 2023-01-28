using System.Collections.Generic;

/*

EDITION MADE BY
.----           ---,---  .----
| __    |    |     |     |___
|   |   |    |     |     |
`^--'   `----^     |     `^---
By: ~Gute

*/

namespace Oxide.Plugins
{
	[Info("AdvGod", "Gute", "2.0.0")]
    [Description("You can give god mode for a player.")]
	public class AdvGod : RustLegacyPlugin
	{
		static string permissionCanGod;
		static string permissionCanUngod;

		static bool commandGod;
		static bool commandUngod;

		void Init()
		{
			SetupConfig();
			SetupLang();
			SetupChatCommands();
			SetupPermissions();
			return;
		}

		void SetupLang()
		{
			var messages = new Dictionary<string, string>
			{
				{"ChatPrefix", "AdvGod"},
				{"NoPermission", "[color red]Você não tem permissão para usa esse comando."},
				{"NonExistent", "[color #51C94E]Nenhum jogador encontrado com esse nome."},
				{"GodReply", "You gave god mode for -[Color Yellow]"},
				{"GodMessage", "You got godmode by -[Color Cyan]"},
				{"UngodReply", "You shot of godmode -[Color Yellow]"},
				{"UngodMessage", "He was removed given by godmode -[Color Cyan]"},
				{"SyntaxGod", "[color #51C94E]Syntax: [color #EEBE62]Use [color #51C94E]/god 'user'"},
				{"SyntaxUngod", "[color #51C94E]Syntax: [color #EEBE62]Use [color #51C94E]/ungod 'user'"}
			};
			lang.RegisterMessages(messages, this);
			return;
		}

		void SetupPermissions()
		{
			permission.RegisterPermission(permissionCanGod, this);
			permission.RegisterPermission(permissionCanUngod, this);
			return;
		}

		void SetupChatCommands()
		{
			if (commandGod)
			cmd.AddChatCommand("dog", this, "cmdGod");

			if (commandUngod)
			cmd.AddChatCommand("ungod", this, "cmdUngod");
		}

		protected override void LoadDefaultConfig()
		{
			Config["Settings"] = new Dictionary<string, object>
			{
				{"permissionCanGod", "cangod"},
				{"permissionCanUngod", "canungod"},

				{"commandGod", true},
				{"commandUngod", true}
			};
		}

		void SetupConfig()
		{
			permissionCanGod = Config.Get<string>("Settings", "permissionCanGod");
			permissionCanUngod = Config.Get<string>("Settings", "permissionCanUngod");

			commandGod = Config.Get<bool>("Settings", "commandGod");
			commandUngod = Config.Get<bool>("Settings", "commandUngod");
		}

		void cmdGod(NetUser netUser, string command, string[] args)
		{
			if (!(netUser.CanAdmin() || permission.UserHasPermission(netUser.userID.ToString(), permissionCanGod)))
		{
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("NoPermission", this));
			return;
		}
			if (args.Length == 0)
		{
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("SyntaxGod", this));
			return;
		}
			NetUser targetUser = rust.FindPlayer(args[0]);
			if (targetUser == null)
		{
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("NonExistent", this));
			return;
		}
			targetUser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(true);
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("GodReply", this) + "[color orange] " + targetUser.displayName);
			rust.SendChatMessage(targetUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("GodMessage", this) + "[color orange] " + netUser.displayName);
		}

		void cmdUngod(NetUser netUser, string command, string[] args)
		{
			if (!(netUser.CanAdmin() || permission.UserHasPermission(netUser.userID.ToString(), permissionCanUngod)))
		{
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("NoPermission", this));
			return;
		}
			if (args.Length == 0)
		{
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("SyntaxUngod", this));
			return;
		}
			NetUser targetUser = rust.FindPlayer(args[0]);
			if (targetUser == null)
		{
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("NonExistent", this));
			return;
		}
			targetUser.playerClient.rootControllable.rootCharacter.takeDamage.SetGodMode(false);
			rust.SendChatMessage(netUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("UngodReply", this) + "[color orange] " + targetUser.displayName);
			rust.SendChatMessage(targetUser, lang.GetMessage("ChatPrefix", this), lang.GetMessage("UngodMessage", this) + "[color orange] " + netUser.displayName);
		}
	}
}