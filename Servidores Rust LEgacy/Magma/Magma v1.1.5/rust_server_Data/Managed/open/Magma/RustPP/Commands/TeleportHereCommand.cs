using System;
using System.Collections.Generic;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000050 RID: 80
	public class TeleportHereCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0000AF80 File Offset: 0x00009180
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (ChatArguments == null)
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Teleport Usage:   /tphere \"playerName\"");
				return;
			}
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			if (text != "")
			{
				if (text.ToLower() == "all")
				{
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						Arguments.Args = new string[]
						{
							playerClient.netUser.displayName,
							Arguments.argUser.displayName
						};
						global::teleport.toplayer(ref Arguments);
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have teleported all players to your location");
				}
				global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
				list.Add("TargetToHere");
				foreach (global::PlayerClient playerClient2 in global::PlayerClient.All)
				{
					if (playerClient2.netUser.displayName.ToLower().Contains(text.ToLower()))
					{
						if (playerClient2.netUser.displayName.ToLower() == text.ToLower())
						{
							Arguments.Args = new string[]
							{
								playerClient2.netUser.displayName,
								Arguments.argUser.displayName
							};
							global::teleport.toplayer(ref Arguments);
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have teleported " + playerClient2.netUser.displayName + " to your location");
							return;
						}
						list.Add(playerClient2.netUser.displayName);
					}
				}
				if (list.Count > 1)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, (list.Count - 1).ToString() + " Player" + ((list.Count - 1 > 1) ? "s" : "") + " were found :");
					for (int j = 1; j < list.Count; j++)
					{
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, j + " - " + list[j]);
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "0 - Cancel");
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Please enter the number matching the player you were looking for.");
					global::RustPP.Commands.TeleportToCommand teleportToCommand = global::RustPP.Commands.ChatCommand.GetCommand("tpto") as global::RustPP.Commands.TeleportToCommand;
					teleportToCommand.GetTPWaitList().Add(Arguments.argUser.userID, list);
					return;
				}
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
				return;
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Teleport Usage:   /tphere \"playerName\"");
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000B2AC File Offset: 0x000094AC
		public TeleportHereCommand()
		{
		}
	}
}
