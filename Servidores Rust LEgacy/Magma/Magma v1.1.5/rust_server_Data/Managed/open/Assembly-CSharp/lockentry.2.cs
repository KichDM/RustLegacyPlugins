using System;
using Rust;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class lockentry : global::ConsoleSystem
{
	// Token: 0x06002C5D RID: 11357 RVA: 0x000A735C File Offset: 0x000A555C
	public lockentry()
	{
	}

	// Token: 0x06002C5E RID: 11358 RVA: 0x000A7364 File Offset: 0x000A5564
	[global::ConsoleSystem.Admin]
	public static void changepassword(ref global::ConsoleSystem.Arg arg)
	{
		if (arg.Args.Length < 1)
		{
			return;
		}
		global::Character character = arg.playerCharacter();
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(character.eyesRay, ref raycastHit, 6f))
		{
			global::IDMain main = global::IDBase.GetMain(raycastHit.collider.gameObject);
			if (main == null)
			{
				return;
			}
			global::PasswordLockableObject component = main.GetComponent<global::PasswordLockableObject>();
			if (component == null)
			{
				return;
			}
			component.SetPassword(arg.Args[0]);
			global::Rust.Notice.Popup(arg.argUser.networkPlayer, "", "Password is now : " + arg.Args[0], 4f);
		}
	}

	// Token: 0x06002C5F RID: 11359 RVA: 0x000A7410 File Offset: 0x000A5610
	[global::ConsoleSystem.User]
	public static void passwordentry(ref global::ConsoleSystem.Arg arg)
	{
		if (arg.Args.Length < 2)
		{
			return;
		}
		bool flag = false;
		bool.TryParse(arg.Args[1], out flag);
		string text = arg.Args[0];
		if (text.Length != 4)
		{
			return;
		}
		foreach (char c in text)
		{
			if (!char.IsDigit(c))
			{
				return;
			}
		}
		global::Character character = arg.playerCharacter();
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(character.eyesRay, ref raycastHit, 5f, 0x100000))
		{
			global::IDMain main = global::IDBase.GetMain(raycastHit.collider.gameObject);
			if (main == null)
			{
				return;
			}
			global::PasswordLockableObject component = main.GetComponent<global::PasswordLockableObject>();
			if (component == null)
			{
				return;
			}
			if (flag)
			{
				global::DeployableObject component2 = main.GetComponent<global::DeployableObject>();
				if (component2 && component2.ownerID == arg.argUser.userID)
				{
					component.SetPassword(text);
					global::Rust.Notice.Popup(arg.argUser.networkPlayer, "", "Password is now : " + text, 4f);
				}
			}
			else if (component.CanCheckPasswordYet())
			{
				if (component.CheckPassword(text))
				{
					global::Rust.Notice.Popup(arg.argUser.networkPlayer, "", "You can now access this door!", 4f);
					component.AddUser(arg.argUser.userID);
				}
				else
				{
					global::Rust.Notice.Popup(arg.argUser.networkPlayer, "", "Incorrect password.", 4f);
					component.MarkFail();
				}
			}
			else
			{
				global::Rust.Notice.Popup(arg.argUser.networkPlayer, "", "Too fast! Try again later.", 4f);
			}
		}
	}
}
