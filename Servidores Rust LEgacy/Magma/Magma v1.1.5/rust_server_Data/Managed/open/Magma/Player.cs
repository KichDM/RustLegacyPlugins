using System;
using Facepunch.Utility;
using Magma.Events;
using Rust;
using uLink;
using UnityEngine;

namespace Magma
{
	// Token: 0x0200002A RID: 42
	public class Player
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0000624C File Offset: 0x0000444C
		public Player(global::PlayerClient client)
		{
			this.ourPlayer = client;
			this.connectedAt = global::System.DateTime.UtcNow.Ticks;
			this.FixInventoryRef();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00006286 File Offset: 0x00004486
		public Player()
		{
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00006295 File Offset: 0x00004495
		public global::PlayerClient PlayerClient
		{
			get
			{
				return this.ourPlayer;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000185 RID: 389 RVA: 0x0000629D File Offset: 0x0000449D
		public global::Magma.PlayerInv Inventory
		{
			get
			{
				if (this.invError || this.justDied)
				{
					this.inv = new global::Magma.PlayerInv(this);
					this.invError = false;
					this.justDied = false;
				}
				return this.inv;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000062D0 File Offset: 0x000044D0
		private void Hooks_OnPlayerKilled(global::Magma.Events.DeathEvent de)
		{
			try
			{
				global::Magma.Player player = de.Victim as global::Magma.Player;
				if (player.GameID == this.GameID)
				{
					this.justDied = true;
				}
			}
			catch (global::System.Exception)
			{
				this.invError = true;
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006320 File Offset: 0x00004520
		public void FixInventoryRef()
		{
			global::Magma.Hooks.OnPlayerKilled += this.Hooks_OnPlayerKilled;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00006334 File Offset: 0x00004534
		public long TimeOnline
		{
			get
			{
				return (global::System.DateTime.UtcNow.Ticks - this.connectedAt) / 0x2710L;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000189 RID: 393 RVA: 0x0000635C File Offset: 0x0000455C
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00006370 File Offset: 0x00004570
		public float X
		{
			get
			{
				return this.ourPlayer.lastKnownPosition.x;
			}
			set
			{
				this.ourPlayer.transform.position.Set(value, this.Y, this.Z);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600018B RID: 395 RVA: 0x000063A2 File Offset: 0x000045A2
		// (set) Token: 0x0600018C RID: 396 RVA: 0x000063B4 File Offset: 0x000045B4
		public float Y
		{
			get
			{
				return this.ourPlayer.lastKnownPosition.y;
			}
			set
			{
				this.ourPlayer.transform.position.Set(this.X, value, this.Z);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000063E6 File Offset: 0x000045E6
		// (set) Token: 0x0600018E RID: 398 RVA: 0x000063F8 File Offset: 0x000045F8
		public float Z
		{
			get
			{
				return this.ourPlayer.lastKnownPosition.z;
			}
			set
			{
				this.ourPlayer.transform.position.Set(this.X, this.Y, value);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600018F RID: 399 RVA: 0x0000642A File Offset: 0x0000462A
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00006438 File Offset: 0x00004638
		public global::UnityEngine.Vector3 Location
		{
			get
			{
				return this.ourPlayer.lastKnownPosition;
			}
			set
			{
				this.ourPlayer.transform.position.Set(value.x, value.y, value.z);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00006472 File Offset: 0x00004672
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00006489 File Offset: 0x00004689
		public string Name
		{
			get
			{
				return this.ourPlayer.netUser.user.displayname_;
			}
			set
			{
				this.ourPlayer.netUser.user.displayname_ = value;
				this.ourPlayer.userName = this.ourPlayer.netUser.user.displayname_;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000193 RID: 403 RVA: 0x000064C4 File Offset: 0x000046C4
		public string SteamID
		{
			get
			{
				return this.ourPlayer.netUser.userID.ToString();
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000194 RID: 404 RVA: 0x000064E9 File Offset: 0x000046E9
		public string GameID
		{
			get
			{
				return this.ourPlayer.userID.ToString();
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000064FB File Offset: 0x000046FB
		public string IP
		{
			get
			{
				return this.ourPlayer.netPlayer.externalIP;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0000650D File Offset: 0x0000470D
		public int Ping
		{
			get
			{
				return this.ourPlayer.netPlayer.averagePing;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000651F File Offset: 0x0000471F
		public bool Admin
		{
			get
			{
				return this.ourPlayer.netUser.admin;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00006531 File Offset: 0x00004731
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00006543 File Offset: 0x00004743
		public float Health
		{
			get
			{
				return this.PlayerClient.controllable.health;
			}
			set
			{
				this.PlayerClient.controllable.takeDamage.health = value;
				this.PlayerClient.controllable.takeDamage.Heal(this.PlayerClient.controllable, 0f);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00006581 File Offset: 0x00004781
		// (set) Token: 0x0600019B RID: 411 RVA: 0x000065A2 File Offset: 0x000047A2
		public bool IsInjured
		{
			get
			{
				return this.PlayerClient.controllable.GetComponent<global::FallDamage>().GetLegInjury() != 0f;
			}
			set
			{
				this.PlayerClient.controllable.GetComponent<global::FallDamage>().SetLegInjury((float)global::System.Convert.ToInt32(value));
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600019C RID: 412 RVA: 0x000065C0 File Offset: 0x000047C0
		// (set) Token: 0x0600019D RID: 413 RVA: 0x000065D7 File Offset: 0x000047D7
		public bool IsBleeding
		{
			get
			{
				return this.PlayerClient.controllable.GetComponent<global::HumanBodyTakeDamage>().IsBleeding();
			}
			set
			{
				this.PlayerClient.controllable.GetComponent<global::HumanBodyTakeDamage>().SetBleedingLevel((float)global::System.Convert.ToInt32(value));
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000065F5 File Offset: 0x000047F5
		// (set) Token: 0x0600019F RID: 415 RVA: 0x0000660C File Offset: 0x0000480C
		public bool IsCold
		{
			get
			{
				return this.PlayerClient.controllable.GetComponent<global::Metabolism>().IsCold();
			}
			set
			{
				this.PlayerClient.controllable.GetComponent<global::Metabolism>().coreTemperature = (float)(value ? -0xA : 0xA);
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00006630 File Offset: 0x00004830
		public void Disconnect()
		{
			global::NetUser netUser = this.ourPlayer.netUser;
			if (netUser.connected && netUser != null)
			{
				netUser.Kick(global::NetError.NoError, true);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00006660 File Offset: 0x00004860
		public void Message(string arg)
		{
			string str = global::Facepunch.Utility.String.QuoteSafe(global::Magma.Server.GetServer().server_message_name);
			string str2 = global::Facepunch.Utility.String.QuoteSafe(arg);
			this.SendCommand("chat.add " + str + " " + str2);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000669B File Offset: 0x0000489B
		public void InventoryNotice(string arg)
		{
			global::Rust.Notice.Inventory(this.ourPlayer.netPlayer, arg);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000066B0 File Offset: 0x000048B0
		public void MessageFrom(string playername, string arg)
		{
			string str = global::Facepunch.Utility.String.QuoteSafe(playername);
			string str2 = global::Facepunch.Utility.String.QuoteSafe(arg);
			this.SendCommand("chat.add " + str + " " + str2);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000066E2 File Offset: 0x000048E2
		public void Notice(string arg)
		{
			global::Rust.Notice.Popup(this.PlayerClient.netPlayer, "!", arg, 4f);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000066FF File Offset: 0x000048FF
		public void Notice(string icon, string text, float duration = 4f)
		{
			global::Rust.Notice.Popup(this.PlayerClient.netPlayer, icon, text, duration);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00006714 File Offset: 0x00004914
		public void Kill()
		{
			global::TakeDamage.KillSelf(this.PlayerClient.controllable.character, null);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00006730 File Offset: 0x00004930
		public void TeleportTo(float x, float y, float z)
		{
			global::RustServerManagement rustServerManagement = global::RustServerManagement.Get();
			rustServerManagement.TeleportPlayerToWorld(this.PlayerClient.netPlayer, new global::UnityEngine.Vector3(x, y, z));
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000675D File Offset: 0x0000495D
		public void TeleportTo(global::Magma.Player p)
		{
			this.TeleportTo(p.X, p.Y, p.Z);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00006777 File Offset: 0x00004977
		public void SendCommand(string cmd)
		{
			global::ConsoleNetworker.SendClientCommand(this.PlayerClient.netPlayer, cmd);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000678C File Offset: 0x0000498C
		public global::Magma.Player Find(string search)
		{
			global::Magma.Player player = global::Magma.Player.FindBySteamID(search);
			if (player != null)
			{
				return player;
			}
			player = global::Magma.Player.FindByGameID(search);
			if (player != null)
			{
				return player;
			}
			player = global::Magma.Player.FindByName(search);
			if (player != null)
			{
				return player;
			}
			return null;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000067C0 File Offset: 0x000049C0
		public static global::Magma.Player FindBySteamID(string uid)
		{
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				if (player.SteamID == uid)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00006828 File Offset: 0x00004A28
		public static global::Magma.Player FindByGameID(string uid)
		{
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				if (player.GameID == uid)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00006890 File Offset: 0x00004A90
		public static global::Magma.Player FindByName(string name)
		{
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				if (player.Name == name)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000068F8 File Offset: 0x00004AF8
		public static global::Magma.Player FindByPlayerClient(global::PlayerClient pc)
		{
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				if (player.PlayerClient == pc)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00006960 File Offset: 0x00004B60
		public static global::Magma.Player FindByNetworkPlayer(global::uLink.NetworkPlayer np)
		{
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				if (player.ourPlayer.netPlayer == np)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x0400005B RID: 91
		private global::Magma.PlayerInv inv;

		// Token: 0x0400005C RID: 92
		private global::PlayerClient ourPlayer;

		// Token: 0x0400005D RID: 93
		private long connectedAt;

		// Token: 0x0400005E RID: 94
		private bool justDied = true;

		// Token: 0x0400005F RID: 95
		private bool invError;
	}
}
