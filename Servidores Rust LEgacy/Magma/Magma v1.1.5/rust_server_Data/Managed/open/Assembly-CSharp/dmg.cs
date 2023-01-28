using System;

// Token: 0x0200018C RID: 396
public class dmg : global::ConsoleSystem
{
	// Token: 0x06000B97 RID: 2967 RVA: 0x0002CF7C File Offset: 0x0002B17C
	public dmg()
	{
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x0002CF84 File Offset: 0x0002B184
	// Note: this type is marked as 'beforefieldinit'.
	static dmg()
	{
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0002CF88 File Offset: 0x0002B188
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Set all admins to be god true/false", "")]
	public static void godmode(ref global::ConsoleSystem.Arg arg)
	{
		if (!arg.HasArgs(1))
		{
			arg.ReplyWith("No valid arguments");
			return;
		}
		bool flag = false;
		int num = 0;
		if (bool.TryParse(arg.Args[0], out flag))
		{
			global::dmg.godadmins = flag;
			foreach (global::PlayerClient playerClient in global::PlayerClient.All)
			{
				global::NetUser netUser;
				if (global::NetUser.Find(playerClient, out netUser) && netUser.CanAdmin() && playerClient.controllable != null)
				{
					global::TakeDamage component = playerClient.controllable.GetComponent<global::TakeDamage>();
					if (component)
					{
						component.SetGodMode(flag);
						num++;
					}
				}
			}
			arg.ReplyWith(string.Concat(new object[]
			{
				"Set ",
				num,
				" Admins godmode to : ",
				flag
			}));
		}
		else
		{
			arg.ReplyWith("Could not parse bool");
		}
	}

	// Token: 0x040007EA RID: 2026
	public static bool godadmins;
}
