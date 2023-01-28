using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200003E RID: 62
	internal class KillCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000226 RID: 550 RVA: 0x000098FC File Offset: 0x00007AFC
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			global::PlayerClient playerClient = null;
			foreach (global::PlayerClient playerClient2 in global::PlayerClient.All)
			{
				if (playerClient2.netUser.displayName.ToLower() == text.ToLower())
				{
					playerClient = playerClient2;
				}
			}
			if (playerClient == null)
			{
				return;
			}
			try
			{
				global::Character character;
				global::Character.FindByUser(playerClient.userID, out character);
				global::IDBase victim = character;
				global::TakeDamage.Kill(Arguments.argUser.playerClient, victim, null);
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You killed " + playerClient.netUser.displayName);
				global::Magma.Util.sayUser(playerClient.netPlayer, Arguments.argUser.displayName + " killed you with his admin power.");
			}
			catch (global::System.Exception)
			{
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00009A20 File Offset: 0x00007C20
		public KillCommand()
		{
		}
	}
}
