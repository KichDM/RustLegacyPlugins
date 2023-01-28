using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Facepunch.Utility;
using UnityEngine;

// Token: 0x0200031D RID: 797
public static class BanList
{
	// Token: 0x06001AEA RID: 6890 RVA: 0x0006A444 File Offset: 0x00068644
	// Note: this type is marked as 'beforefieldinit'.
	static BanList()
	{
	}

	// Token: 0x06001AEB RID: 6891 RVA: 0x0006A450 File Offset: 0x00068650
	public static void Add(ulong iUID, string strName = "unknown", string strReason = "")
	{
		if (global::BanList.Contains(iUID))
		{
			return;
		}
		global::BanList.Ban item = default(global::BanList.Ban);
		item.steamid = iUID;
		item.username = strName;
		item.reason = strReason;
		global::BanList.bannedUsers.Add(item);
	}

	// Token: 0x06001AEC RID: 6892 RVA: 0x0006A494 File Offset: 0x00068694
	public static bool Remove(ulong iUID)
	{
		if (!global::BanList.Contains(iUID))
		{
			return false;
		}
		int index = global::BanList.bannedUsers.FindIndex((global::BanList.Ban x) => x.steamid == iUID);
		global::BanList.bannedUsers.RemoveAt(index);
		return true;
	}

	// Token: 0x06001AED RID: 6893 RVA: 0x0006A4E4 File Offset: 0x000686E4
	public static bool Contains(ulong iUID)
	{
		int num = global::BanList.bannedUsers.FindIndex((global::BanList.Ban x) => x.steamid == iUID);
		return num >= 0;
	}

	// Token: 0x06001AEE RID: 6894 RVA: 0x0006A51C File Offset: 0x0006871C
	public static void Save()
	{
		string text = string.Empty;
		if (!global::System.IO.Directory.Exists(global::server.datadir + "cfg"))
		{
			global::System.IO.Directory.CreateDirectory(global::server.datadir + "cfg");
		}
		foreach (global::BanList.Ban ban in global::BanList.bannedUsers)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"banid ",
				ban.steamid.ToString(),
				" ",
				global::Facepunch.Utility.String.QuoteSafe(ban.username),
				" ",
				global::Facepunch.Utility.String.QuoteSafe(ban.reason),
				"\r\n"
			});
		}
		global::System.IO.File.WriteAllText(global::server.datadir + "cfg/bans.cfg", text);
	}

	// Token: 0x06001AEF RID: 6895 RVA: 0x0006A624 File Offset: 0x00068824
	public static void Load()
	{
		global::BanList.Clear();
		if (!global::System.IO.File.Exists(global::server.datadir + "cfg/bans.cfg"))
		{
			return;
		}
		string text = global::System.IO.File.ReadAllText(global::server.datadir + "cfg/bans.cfg");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		global::UnityEngine.Debug.Log("Running " + global::server.datadir + "cfg/bans.cfg");
		global::ConsoleSystem.RunFile(text);
	}

	// Token: 0x06001AF0 RID: 6896 RVA: 0x0006A690 File Offset: 0x00068890
	public static void Clear()
	{
		global::BanList.bannedUsers.Clear();
	}

	// Token: 0x06001AF1 RID: 6897 RVA: 0x0006A69C File Offset: 0x0006889C
	public static string BanListString(bool bHeader = false)
	{
		string text = string.Empty;
		if (bHeader)
		{
			if (global::BanList.bannedUsers.Count == 0)
			{
				return "ID filter list: empty\n";
			}
			if (global::BanList.bannedUsers.Count == 1)
			{
				text = "ID filter list: 1 entry\n";
			}
			else
			{
				text = "ID filter list: " + global::BanList.bannedUsers.Count.ToString() + " entries\n";
			}
		}
		int num = 1;
		foreach (global::BanList.Ban ban in global::BanList.bannedUsers)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				num.ToString(),
				" ",
				ban.steamid.ToString(),
				" : permanent\n"
			});
			num++;
		}
		return text;
	}

	// Token: 0x06001AF2 RID: 6898 RVA: 0x0006A7A0 File Offset: 0x000689A0
	public static string BanListStringEx()
	{
		string text = string.Empty;
		int num = 1;
		foreach (global::BanList.Ban ban in global::BanList.bannedUsers)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				num.ToString(),
				" ",
				ban.steamid.ToString(),
				" ",
				global::Facepunch.Utility.String.QuoteSafe(ban.username),
				" ",
				global::Facepunch.Utility.String.QuoteSafe(ban.reason),
				"\n"
			});
			num++;
		}
		return text;
	}

	// Token: 0x04000FA5 RID: 4005
	private static global::System.Collections.Generic.List<global::BanList.Ban> bannedUsers = new global::System.Collections.Generic.List<global::BanList.Ban>();

	// Token: 0x0200031E RID: 798
	private struct Ban
	{
		// Token: 0x04000FA6 RID: 4006
		public ulong steamid;

		// Token: 0x04000FA7 RID: 4007
		public string username;

		// Token: 0x04000FA8 RID: 4008
		public string reason;
	}

	// Token: 0x0200031F RID: 799
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Remove>c__AnonStorey5F
	{
		// Token: 0x06001AF3 RID: 6899 RVA: 0x0006A878 File Offset: 0x00068A78
		public <Remove>c__AnonStorey5F()
		{
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x0006A880 File Offset: 0x00068A80
		internal bool <>m__E(global::BanList.Ban x)
		{
			return x.steamid == this.iUID;
		}

		// Token: 0x04000FA9 RID: 4009
		internal ulong iUID;
	}

	// Token: 0x02000320 RID: 800
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Contains>c__AnonStorey60
	{
		// Token: 0x06001AF5 RID: 6901 RVA: 0x0006A894 File Offset: 0x00068A94
		public <Contains>c__AnonStorey60()
		{
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x0006A89C File Offset: 0x00068A9C
		internal bool <>m__F(global::BanList.Ban x)
		{
			return x.steamid == this.iUID;
		}

		// Token: 0x04000FAA RID: 4010
		internal ulong iUID;
	}
}
