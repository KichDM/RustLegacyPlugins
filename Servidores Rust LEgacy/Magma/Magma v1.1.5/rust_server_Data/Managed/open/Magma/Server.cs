using System;
using System.Collections.Generic;

namespace Magma
{
	// Token: 0x0200002C RID: 44
	public class Server
	{
		// Token: 0x060001CE RID: 462 RVA: 0x00007020 File Offset: 0x00005220
		public Server()
		{
			this.players = new global::System.Collections.Generic.List<global::Magma.Player>();
			this._serverStructs = new global::StructureMaster();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000705F File Offset: 0x0000525F
		public static global::Magma.Server GetServer()
		{
			if (global::Magma.Server.server == null)
			{
				global::Magma.Server.server = new global::Magma.Server();
			}
			return global::Magma.Server.server;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00007078 File Offset: 0x00005278
		public void Broadcast(string arg)
		{
			foreach (global::Magma.Player player in this.Players)
			{
				player.Message(arg);
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000070CC File Offset: 0x000052CC
		public void BroadcastFrom(string name, string arg)
		{
			foreach (global::Magma.Player player in this.Players)
			{
				player.MessageFrom(name, arg);
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00007120 File Offset: 0x00005320
		public void BroadcastNotice(string s)
		{
			foreach (global::Magma.Player player in this.Players)
			{
				player.Notice(s);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00007174 File Offset: 0x00005374
		public global::System.Collections.Generic.List<string> ChatHistoryMessages
		{
			get
			{
				return global::Magma.Data.GetData().chat_history;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00007180 File Offset: 0x00005380
		public global::System.Collections.Generic.List<string> ChatHistoryUsers
		{
			get
			{
				return global::Magma.Data.GetData().chat_history_username;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0000718C File Offset: 0x0000538C
		public global::System.Collections.Generic.List<global::Magma.Player> Players
		{
			get
			{
				return this.players;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00007194 File Offset: 0x00005394
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x0000719C File Offset: 0x0000539C
		public global::Magma.ItemsBlocks Items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x000071A5 File Offset: 0x000053A5
		public global::StructureMaster ServerStructures
		{
			get
			{
				return this._serverStructs;
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000071B0 File Offset: 0x000053B0
		public global::Magma.Player FindPlayer(string s)
		{
			global::Magma.Player player = global::Magma.Player.FindBySteamID(s);
			if (player != null)
			{
				return player;
			}
			player = global::Magma.Player.FindByGameID(s);
			if (player != null)
			{
				return player;
			}
			player = global::Magma.Player.FindByName(s);
			if (player != null)
			{
				return player;
			}
			return null;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000071E2 File Offset: 0x000053E2
		public void Save()
		{
			global::AvatarSaveProc.SaveAll();
			global::ServerSaveManager.AutoSave();
		}

		// Token: 0x04000065 RID: 101
		public string server_message_name = "Magma";

		// Token: 0x04000066 RID: 102
		public global::Magma.Util util = new global::Magma.Util();

		// Token: 0x04000067 RID: 103
		public global::Magma.Data data = new global::Magma.Data();

		// Token: 0x04000068 RID: 104
		private static global::Magma.Server server;

		// Token: 0x04000069 RID: 105
		private global::System.Collections.Generic.List<global::Magma.Player> players;

		// Token: 0x0400006A RID: 106
		private global::Magma.ItemsBlocks _items;

		// Token: 0x0400006B RID: 107
		private global::StructureMaster _serverStructs;
	}
}
