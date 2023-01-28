using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Magma;

namespace RustPP.Permissions
{
	// Token: 0x0200005A RID: 90
	[global::System.Serializable]
	public class Administrator
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000CED4 File Offset: 0x0000B0D4
		// (set) Token: 0x06000279 RID: 633 RVA: 0x0000CEDC File Offset: 0x0000B0DC
		public string DisplayName
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600027A RID: 634 RVA: 0x0000CEE5 File Offset: 0x0000B0E5
		// (set) Token: 0x0600027B RID: 635 RVA: 0x0000CEED File Offset: 0x0000B0ED
		public ulong UserID
		{
			get
			{
				return this._userid;
			}
			set
			{
				this._userid = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600027C RID: 636 RVA: 0x0000CEF6 File Offset: 0x0000B0F6
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000CEFE File Offset: 0x0000B0FE
		public global::System.Collections.Generic.List<string> Flags
		{
			get
			{
				return this._flags;
			}
			set
			{
				this._flags = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000CF07 File Offset: 0x0000B107
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000CF0E File Offset: 0x0000B10E
		[global::System.Xml.Serialization.XmlIgnore]
		public static global::System.Collections.Generic.List<global::RustPP.Permissions.Administrator> AdminList
		{
			get
			{
				return global::RustPP.Permissions.Administrator.admins;
			}
			set
			{
				global::RustPP.Permissions.Administrator.admins = value;
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000CF16 File Offset: 0x0000B116
		public Administrator()
		{
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000CF1E File Offset: 0x0000B11E
		public Administrator(ulong userID, string name)
		{
			this._userid = userID;
			this._name = name;
			this._flags = new global::System.Collections.Generic.List<string>();
			global::RustPP.Permissions.Administrator.AddFlagsToList(this._flags, global::RustPP.Core.config.GetSetting("Settings", "default_admin_flags"));
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000CF5E File Offset: 0x0000B15E
		public Administrator(ulong userID, string name, string flags)
		{
			this._userid = userID;
			this._name = name;
			this._flags = new global::System.Collections.Generic.List<string>();
			global::RustPP.Permissions.Administrator.AddFlagsToList(this._flags, flags);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000CF8C File Offset: 0x0000B18C
		public static bool IsAdmin(ulong uid)
		{
			foreach (global::RustPP.Permissions.Administrator administrator in global::RustPP.Permissions.Administrator.admins)
			{
				if (uid == administrator.UserID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000CFE8 File Offset: 0x0000B1E8
		public static void AddAdmin(global::RustPP.Permissions.Administrator admin)
		{
			global::RustPP.Permissions.Administrator.admins.Add(admin);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000CFF5 File Offset: 0x0000B1F5
		public static void DeleteAdmin(ulong admin)
		{
			global::RustPP.Permissions.Administrator.admins.Remove(global::RustPP.Permissions.Administrator.GetAdmin(admin));
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000D008 File Offset: 0x0000B208
		public static global::RustPP.Permissions.Administrator GetAdmin(ulong userID)
		{
			foreach (global::RustPP.Permissions.Administrator administrator in global::RustPP.Permissions.Administrator.admins)
			{
				if (userID == administrator.UserID)
				{
					return administrator;
				}
			}
			return null;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000D064 File Offset: 0x0000B264
		public static void NotifyAdmins(string msg)
		{
			foreach (global::RustPP.Permissions.Administrator administrator in global::RustPP.Permissions.Administrator.admins)
			{
				try
				{
					global::NetUser netUser = global::NetUser.FindByUserID(administrator.UserID);
					if (netUser != null)
					{
						global::Magma.Util.sayUser(netUser.networkPlayer, "Admins", msg);
					}
				}
				catch (global::System.Exception)
				{
				}
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000D0E0 File Offset: 0x0000B2E0
		private static void AddFlagsToList(global::System.Collections.Generic.List<string> l, string str)
		{
			foreach (string text in str.Split(new char[]
			{
				'|'
			}))
			{
				if (!l.Contains(text.ToLower()))
				{
					l.Add(text);
				}
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000D128 File Offset: 0x0000B328
		public static bool IsValidFlag(string flag)
		{
			bool result = false;
			foreach (string text in global::RustPP.Permissions.Administrator.PermissionsFlags)
			{
				if (text.ToLower() == flag.ToLower())
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000D168 File Offset: 0x0000B368
		public static string GetProperName(string flag)
		{
			foreach (string text in global::RustPP.Permissions.Administrator.PermissionsFlags)
			{
				if (text.ToLower() == flag.ToLower())
				{
					return text;
				}
			}
			return "";
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000D1C4 File Offset: 0x0000B3C4
		public bool HasPermission(string perm)
		{
			return this.Flags.FindIndex((string x) => x.Equals(perm, global::System.StringComparison.OrdinalIgnoreCase)) != -1;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000D1FC File Offset: 0x0000B3FC
		// Note: this type is marked as 'beforefieldinit'.
		static Administrator()
		{
		}

		// Token: 0x0400008B RID: 139
		public static string[] PermissionsFlags = new string[]
		{
			"CanMute",
			"CanUnmute",
			"CanWhiteList",
			"CanKill",
			"CanKick",
			"CanBan",
			"CanUnban",
			"CanTeleport",
			"CanLoadout",
			"CanAnnounce",
			"CanSpawnItem",
			"CanGiveItem",
			"CanReload",
			"CanSaveAll",
			"CanAddAdmin",
			"CanDeleteAdmin",
			"CanGetFlags",
			"CanAddFlags",
			"CanUnflag",
			"CanInstaKO",
			"CanGodMode",
			"RCON"
		};

		// Token: 0x0400008C RID: 140
		[global::System.Xml.Serialization.XmlIgnore]
		private static global::System.Collections.Generic.List<global::RustPP.Permissions.Administrator> admins = new global::System.Collections.Generic.List<global::RustPP.Permissions.Administrator>();

		// Token: 0x0400008D RID: 141
		private string _name;

		// Token: 0x0400008E RID: 142
		private ulong _userid;

		// Token: 0x0400008F RID: 143
		private global::System.Collections.Generic.List<string> _flags;

		// Token: 0x02000066 RID: 102
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass1
		{
			// Token: 0x06000318 RID: 792 RVA: 0x0000D1AB File Offset: 0x0000B3AB
			public <>c__DisplayClass1()
			{
			}

			// Token: 0x06000319 RID: 793 RVA: 0x0000D1B3 File Offset: 0x0000B3B3
			public bool <HasPermission>b__0(string x)
			{
				return x.Equals(this.perm, global::System.StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040000A7 RID: 167
			public string perm;
		}
	}
}
