using System;
using System.Collections.Generic;

namespace RustPP
{
	// Token: 0x0200005B RID: 91
	public class PList
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000D2DE File Offset: 0x0000B4DE
		public int Count
		{
			get
			{
				return this.players.Count;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000D2EB File Offset: 0x0000B4EB
		public global::RustPP.PList.Player[] Values
		{
			get
			{
				return this.players.ToArray();
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000D2F8 File Offset: 0x0000B4F8
		public global::System.Collections.Generic.List<global::RustPP.PList.Player> PlayerList
		{
			get
			{
				return this.players;
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000D300 File Offset: 0x0000B500
		public PList()
		{
			this.players = new global::System.Collections.Generic.List<global::RustPP.PList.Player>();
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000D313 File Offset: 0x0000B513
		public PList(global::System.Collections.Generic.List<global::RustPP.PList.Player> pl)
		{
			this.players = pl;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000D324 File Offset: 0x0000B524
		public global::RustPP.PList.Player Get(ulong uid)
		{
			foreach (global::RustPP.PList.Player player in this.players)
			{
				if (player.UserID == uid)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000D380 File Offset: 0x0000B580
		public void Add(ulong uid, string dname)
		{
			this.players.Add(new global::RustPP.PList.Player(uid, dname));
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000D394 File Offset: 0x0000B594
		public void Remove(ulong uid)
		{
			foreach (global::RustPP.PList.Player player in this.players)
			{
				if (player.UserID == uid)
				{
					this.players.Remove(player);
				}
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000D3F8 File Offset: 0x0000B5F8
		public bool Contains(ulong uid)
		{
			bool result = false;
			foreach (global::RustPP.PList.Player player in this.players)
			{
				if (player.UserID == uid)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x04000090 RID: 144
		private global::System.Collections.Generic.List<global::RustPP.PList.Player> players;

		// Token: 0x0200005C RID: 92
		[global::System.Serializable]
		public class Player
		{
			// Token: 0x17000064 RID: 100
			// (get) Token: 0x06000296 RID: 662 RVA: 0x0000D454 File Offset: 0x0000B654
			// (set) Token: 0x06000297 RID: 663 RVA: 0x0000D45C File Offset: 0x0000B65C
			public string DisplayName
			{
				get
				{
					return this.dname;
				}
				set
				{
					this.dname = value;
				}
			}

			// Token: 0x17000065 RID: 101
			// (get) Token: 0x06000298 RID: 664 RVA: 0x0000D465 File Offset: 0x0000B665
			// (set) Token: 0x06000299 RID: 665 RVA: 0x0000D46D File Offset: 0x0000B66D
			public ulong UserID
			{
				get
				{
					return this.uid;
				}
				set
				{
					this.uid = value;
				}
			}

			// Token: 0x0600029A RID: 666 RVA: 0x0000D476 File Offset: 0x0000B676
			public Player()
			{
			}

			// Token: 0x0600029B RID: 667 RVA: 0x0000D47E File Offset: 0x0000B67E
			public Player(ulong _uid, string _dname)
			{
				this.DisplayName = _dname;
				this.UserID = _uid;
			}

			// Token: 0x04000091 RID: 145
			private string dname;

			// Token: 0x04000092 RID: 146
			private ulong uid;
		}
	}
}
