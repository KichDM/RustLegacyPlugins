using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000763 RID: 1891
public class teleport : global::ConsoleSystem
{
	// Token: 0x06003EFB RID: 16123 RVA: 0x000E06E4 File Offset: 0x000DE8E4
	public teleport()
	{
	}

	// Token: 0x06003EFC RID: 16124 RVA: 0x000E06EC File Offset: 0x000DE8EC
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Teleport one player to another. if only one player is entered then the calling player will be fromName and entered will be destName", "string fromName, string destName")]
	public static void toplayer(ref global::ConsoleSystem.Arg arg)
	{
		global::RustServerManagement rustServerManagement = global::RustServerManagement.Get();
		if (!rustServerManagement)
		{
			return;
		}
		int num = 0;
		string text;
		string text2;
		if (arg.HasArgs(2))
		{
			text = arg.Args[0];
			text2 = arg.Args[1];
			using (global::System.Collections.Generic.IEnumerator<global::PlayerClient> enumerator = global::PlayerClient.FindAllWithString(text).GetEnumerator())
			{
				bool flag = false;
				while (!flag && enumerator.MoveNext())
				{
					int num2 = 0;
					foreach (global::PlayerClient playerClient in global::PlayerClient.FindAllWithString(text2))
					{
						if (rustServerManagement.TeleportPlayerToPlayer(enumerator.Current.netPlayer, playerClient.netPlayer))
						{
							num2++;
							if (!enumerator.MoveNext())
							{
								flag = true;
								break;
							}
						}
					}
					if (num2 == 0)
					{
						break;
					}
					num += num2;
				}
			}
		}
		else
		{
			if (!arg.HasArgs(1))
			{
				arg.ReplyWith("invalid args");
				return;
			}
			text2 = arg.Args[0];
			if (arg.argUser == null)
			{
				arg.ReplyWith("with 1 argument the arg.argUser was null ( 2 are required when calling from server console )");
				return;
			}
			text = ((!arg.argUser.user.HasDisplayname) ? null : arg.argUser.user.Displayname);
			global::PlayerClient playerClient2 = arg.argUser.playerClient;
			if (playerClient2)
			{
				text = (text ?? playerClient2.userName);
				foreach (global::PlayerClient playerClient3 in global::PlayerClient.FindAllWithString(text2))
				{
					if (rustServerManagement.TeleportPlayerToPlayer(playerClient2.netPlayer, playerClient3.netPlayer))
					{
						num = 1;
						break;
					}
				}
			}
		}
		arg.ReplyWith(string.Format("moved {0} player(s) named \"{1}\" to other players with name \"{2}\"", num, text, text2));
	}

	// Token: 0x06003EFD RID: 16125 RVA: 0x000E0954 File Offset: 0x000DEB54
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Teleport player to a point in world space", "string fromName, float x, float y, float z")]
	public static void topos(ref global::ConsoleSystem.Arg arg)
	{
		global::RustServerManagement rustServerManagement = global::RustServerManagement.Get();
		if (!rustServerManagement || !arg.HasArgs(4))
		{
			return;
		}
		string partialNameOrIDInt = arg.Args[0];
		global::UnityEngine.Vector3 worldPoint;
		worldPoint..ctor(arg.GetFloat(1, 0f), arg.GetFloat(2, 0f), arg.GetFloat(3, 0f));
		if (worldPoint.magnitude == 0f)
		{
			return;
		}
		foreach (global::PlayerClient playerClient in global::PlayerClient.FindAllWithString(partialNameOrIDInt))
		{
			rustServerManagement.TeleportPlayerToWorld(playerClient.netPlayer, worldPoint);
		}
	}
}
