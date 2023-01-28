using System;
using System.Collections.Generic;
using uLink;
using UnityEngine;

// Token: 0x0200042A RID: 1066
[global::UnityEngine.RequireComponent(typeof(global::uLinkNetworkView))]
public class PlayerClient : global::IDMain
{
	// Token: 0x0600250E RID: 9486 RVA: 0x0008DB78 File Offset: 0x0008BD78
	public PlayerClient() : base(0)
	{
	}

	// Token: 0x0600250F RID: 9487 RVA: 0x0008DB8C File Offset: 0x0008BD8C
	public static global::PlayerClient GetLocalPlayer()
	{
		return global::PlayerClient.localPlayerClient;
	}

	// Token: 0x1700084E RID: 2126
	// (get) Token: 0x06002510 RID: 9488 RVA: 0x0008DB94 File Offset: 0x0008BD94
	public global::Controllable controllable
	{
		get
		{
			return this._controllable;
		}
	}

	// Token: 0x1700084F RID: 2127
	// (get) Token: 0x06002511 RID: 9489 RVA: 0x0008DB9C File Offset: 0x0008BD9C
	public global::NetUser netUser
	{
		get
		{
			return global::NetUser.Find(this.netPlayer);
		}
	}

	// Token: 0x17000850 RID: 2128
	// (get) Token: 0x06002512 RID: 9490 RVA: 0x0008DBAC File Offset: 0x0008BDAC
	public double instantiationTimeStamp
	{
		get
		{
			return this.instantiationinfo.timestamp;
		}
	}

	// Token: 0x17000851 RID: 2129
	// (get) Token: 0x06002513 RID: 9491 RVA: 0x0008DBBC File Offset: 0x0008BDBC
	public global::Controllable rootControllable
	{
		get
		{
			return this._controllable;
		}
	}

	// Token: 0x17000852 RID: 2130
	// (get) Token: 0x06002514 RID: 9492 RVA: 0x0008DBC4 File Offset: 0x0008BDC4
	public global::Controllable topControllable
	{
		get
		{
			return this._controllable;
		}
	}

	// Token: 0x17000853 RID: 2131
	// (get) Token: 0x06002515 RID: 9493 RVA: 0x0008DBCC File Offset: 0x0008BDCC
	public bool local
	{
		get
		{
			return global::PlayerClient.localPlayerClient && global::PlayerClient.localPlayerClient == this;
		}
	}

	// Token: 0x06002516 RID: 9494 RVA: 0x0008DBEC File Offset: 0x0008BDEC
	private void Awake()
	{
		global::uLink.NetworkPlayer unassigned = global::uLink.NetworkPlayer.unassigned;
		this._playerID = unassigned.id;
	}

	// Token: 0x06002517 RID: 9495 RVA: 0x0008DC0C File Offset: 0x0008BE0C
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.netPlayer = info.networkView.owner;
		global::uLink.BitStream initialData = info.networkView.initialData;
		this.userID = initialData.ReadUInt64();
		this.userName = initialData.ReadString();
		base.name = string.Concat(new string[]
		{
			"Player ",
			this.userName,
			" (",
			this.userID.ToString(),
			")"
		});
		this.instantiationinfo = info;
		this._playerID = this.netPlayer.id;
		global::PlayerClient.g.playerIDDict[this._playerID] = this;
		base.enabled = false;
	}

	// Token: 0x06002518 RID: 9496 RVA: 0x0008DCC0 File Offset: 0x0008BEC0
	private void OnDisable()
	{
		if (this.local && !base.destroying && !global::NetInstance.IsCurrentlyDestroying(this))
		{
			global::UnityEngine.Debug.LogWarning("The local player got disabled", this);
		}
	}

	// Token: 0x06002519 RID: 9497 RVA: 0x0008DCFC File Offset: 0x0008BEFC
	private void OnEnable()
	{
		if (!this.local)
		{
			global::UnityEngine.Debug.LogWarning("Something tried to enable a non local player.. setting enabled to false", this);
			base.enabled = false;
		}
	}

	// Token: 0x0600251A RID: 9498 RVA: 0x0008DD1C File Offset: 0x0008BF1C
	protected void OnDestroy()
	{
		try
		{
			global::uLink.NetworkPlayer unassigned = global::uLink.NetworkPlayer.unassigned;
			int id = unassigned.id;
			if (this._playerID != id)
			{
				try
				{
					global::PlayerClient objA = global::PlayerClient.g.playerIDDict[this._playerID];
					if (object.ReferenceEquals(objA, this))
					{
						global::PlayerClient.g.playerIDDict.Remove(this._playerID);
					}
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex, this);
				}
				finally
				{
					this._playerID = id;
				}
			}
		}
		finally
		{
			base.OnDestroy();
		}
	}

	// Token: 0x0600251B RID: 9499 RVA: 0x0008DDE4 File Offset: 0x0008BFE4
	internal void OnRootControllableEntered(global::Controllable controllable)
	{
		if (this._controllable)
		{
			global::UnityEngine.Debug.LogWarning("There was a controllable for player client already", this);
		}
		this._controllable = controllable;
	}

	// Token: 0x0600251C RID: 9500 RVA: 0x0008DE14 File Offset: 0x0008C014
	internal void OnRootControllableExited(global::Controllable controllable)
	{
		if (this._controllable != controllable)
		{
			global::UnityEngine.Debug.LogWarning("The controllable exited did not match that of the existing value", this);
		}
		else
		{
			this._controllable = null;
		}
	}

	// Token: 0x0600251D RID: 9501 RVA: 0x0008DE4C File Offset: 0x0008C04C
	public static bool Find(global::uLink.NetworkPlayer player, out global::PlayerClient pc)
	{
		int id = player.id;
		int num = id;
		global::uLink.NetworkPlayer unassigned = global::uLink.NetworkPlayer.unassigned;
		if (num == unassigned.id || player == global::uLink.NetworkPlayer.server)
		{
			pc = null;
			return false;
		}
		return global::PlayerClient.g.playerIDDict.TryGetValue(id, out pc);
	}

	// Token: 0x0600251E RID: 9502 RVA: 0x0008DE98 File Offset: 0x0008C098
	public static bool Find(global::uLink.NetworkPlayer player, out global::PlayerClient pc, bool throwIfNotFound)
	{
		if (!throwIfNotFound)
		{
			return global::PlayerClient.Find(player, out pc);
		}
		if (!global::PlayerClient.Find(player, out pc))
		{
			throw new global::System.ArgumentException("There was no PlayerClient for that player", "player");
		}
		return true;
	}

	// Token: 0x0600251F RID: 9503 RVA: 0x0008DEC8 File Offset: 0x0008C0C8
	public static global::System.Collections.Generic.IEnumerable<global::PlayerClient> FindAllWithName(string name, global::System.StringComparison comparison)
	{
		global::ServerManagement serverManagement;
		if (!string.IsNullOrEmpty(name) && (serverManagement = global::ServerManagement.Get()))
		{
			return serverManagement.FindPlayerClientsByName(name, comparison);
		}
		return global::EmptyArray<global::PlayerClient>.emptyEnumerable;
	}

	// Token: 0x06002520 RID: 9504 RVA: 0x0008DF00 File Offset: 0x0008C100
	public static global::System.Collections.Generic.IEnumerable<global::PlayerClient> FindAllWithName(string name)
	{
		return global::PlayerClient.FindAllWithName(name, global::System.StringComparison.InvariantCultureIgnoreCase);
	}

	// Token: 0x06002521 RID: 9505 RVA: 0x0008DF0C File Offset: 0x0008C10C
	public static global::System.Collections.Generic.IEnumerable<global::PlayerClient> FindAllWithString(string partialNameOrIDInt)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (serverManagement == null)
		{
			return global::EmptyArray<global::PlayerClient>.emptyEnumerable;
		}
		if (!string.IsNullOrEmpty(partialNameOrIDInt))
		{
			return serverManagement.FindPlayerClientsByString(partialNameOrIDInt);
		}
		return global::EmptyArray<global::PlayerClient>.emptyEnumerable;
	}

	// Token: 0x06002522 RID: 9506 RVA: 0x0008DF4C File Offset: 0x0008C14C
	public static bool FindByUserID(ulong userID, out global::PlayerClient client)
	{
		if (userID == 0UL)
		{
			client = null;
			return false;
		}
		global::NetUser netUser;
		if (global::NetUser.Find(userID, out netUser))
		{
			client = netUser.playerClient;
			return client;
		}
		client = null;
		return false;
	}

	// Token: 0x17000854 RID: 2132
	// (get) Token: 0x06002523 RID: 9507 RVA: 0x0008DF88 File Offset: 0x0008C188
	public static global::LockedList<global::PlayerClient> All
	{
		get
		{
			global::ServerManagement serverManagement = global::ServerManagement.Get();
			if (serverManagement)
			{
				return serverManagement.lockedPlayerClientList;
			}
			return global::LockedList<global::PlayerClient>.Empty;
		}
	}

	// Token: 0x040012D5 RID: 4821
	private const ulong kAutoReclockInitialDelay = 0x1F40UL;

	// Token: 0x040012D6 RID: 4822
	private const ulong kAutoReclockInterval = 0x668A0UL;

	// Token: 0x040012D7 RID: 4823
	private const ulong kAutoReclockMS_Base = 0xBB8UL;

	// Token: 0x040012D8 RID: 4824
	private const ulong kAutoReclockMS_AddMax = 0x1F4UL;

	// Token: 0x040012D9 RID: 4825
	public static global::PlayerClient localPlayerClient;

	// Token: 0x040012DA RID: 4826
	private global::Controllable _controllable;

	// Token: 0x040012DB RID: 4827
	public global::uLink.NetworkPlayer netPlayer;

	// Token: 0x040012DC RID: 4828
	[global::System.NonSerialized]
	public bool hasLastKnownPosition;

	// Token: 0x040012DD RID: 4829
	[global::System.NonSerialized]
	public global::UnityEngine.Vector3 lastKnownPosition;

	// Token: 0x040012DE RID: 4830
	private global::uLink.NetworkMessageInfo instantiationinfo;

	// Token: 0x040012DF RID: 4831
	private int _playerID;

	// Token: 0x040012E0 RID: 4832
	public ulong userID;

	// Token: 0x040012E1 RID: 4833
	public string userName;

	// Token: 0x040012E2 RID: 4834
	[global::System.NonSerialized]
	public bool firstReady;

	// Token: 0x040012E3 RID: 4835
	private int lastInputFrame = int.MinValue;

	// Token: 0x040012E4 RID: 4836
	private ulong nextAutoReclockTime;

	// Token: 0x0200042B RID: 1067
	private static class g
	{
		// Token: 0x06002524 RID: 9508 RVA: 0x0008DFB4 File Offset: 0x0008C1B4
		// Note: this type is marked as 'beforefieldinit'.
		static g()
		{
		}

		// Token: 0x040012E5 RID: 4837
		public static global::System.Collections.Generic.Dictionary<int, global::PlayerClient> playerIDDict = new global::System.Collections.Generic.Dictionary<int, global::PlayerClient>();
	}
}
