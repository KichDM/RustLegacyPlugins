using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;
using Magma;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000432 RID: 1074
[global::UnityEngine.RequireComponent(typeof(global::uLinkNetworkView))]
public class ServerManagement : global::Facepunch.MonoBehaviour
{
	// Token: 0x0600255D RID: 9565 RVA: 0x0008ED60 File Offset: 0x0008CF60
	public ServerManagement() : this(new global::System.Collections.Generic.List<global::PlayerClient>())
	{
	}

	// Token: 0x0600255E RID: 9566 RVA: 0x0008ED70 File Offset: 0x0008CF70
	private ServerManagement(global::System.Collections.Generic.List<global::PlayerClient> pcList)
	{
		this.lockedPlayerClientList = new global::LockedList<global::PlayerClient>(pcList);
		this._playerClientList = pcList;
	}

	// Token: 0x0600255F RID: 9567 RVA: 0x0008EDA4 File Offset: 0x0008CFA4
	// Note: this type is marked as 'beforefieldinit'.
	static ServerManagement()
	{
	}

	// Token: 0x06002560 RID: 9568 RVA: 0x0008EDA8 File Offset: 0x0008CFA8
	public static global::ServerManagement Get()
	{
		return global::ServerManagement._serverMan;
	}

	// Token: 0x06002561 RID: 9569 RVA: 0x0008EDB0 File Offset: 0x0008CFB0
	public virtual void AddPlayerSpawn(global::UnityEngine.GameObject spawn)
	{
	}

	// Token: 0x06002562 RID: 9570 RVA: 0x0008EDB4 File Offset: 0x0008CFB4
	public virtual void RemovePlayerSpawn(global::UnityEngine.GameObject spawn)
	{
	}

	// Token: 0x06002563 RID: 9571 RVA: 0x0008EDB8 File Offset: 0x0008CFB8
	protected virtual void OnServerWillDestroy(ref global::ServerManagement.PreServerDestroyArgs obj)
	{
	}

	// Token: 0x06002564 RID: 9572 RVA: 0x0008EDBC File Offset: 0x0008CFBC
	internal void ServerWillDestroyMain(global::IDMain main, global::NetEntityID entityID, global::NetEntityID.Kind viewKind, global::UnityEngine.MonoBehaviour view)
	{
		global::ServerManagement.PreServerDestroyArgs preServerDestroyArgs = new global::ServerManagement.PreServerDestroyArgs(main, view, entityID, viewKind);
		try
		{
			this.OnServerWillDestroy(ref preServerDestroyArgs);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
		}
	}

	// Token: 0x06002565 RID: 9573 RVA: 0x0008EE0C File Offset: 0x0008D00C
	protected void Awake()
	{
		global::ServerManagement._serverMan = this;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06002566 RID: 9574 RVA: 0x0008EE20 File Offset: 0x0008D020
	protected internal virtual global::PlayerClient CreatePlayerClientForUser(global::NetUser User)
	{
		global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateClassicWithArgs(User.networkPlayer, ":client", global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.identity, 0, new object[]
		{
			User.user.Userid,
			User.user.Displayname
		});
		global::PlayerClient component = gameObject.GetComponent<global::PlayerClient>();
		if (!component)
		{
			global::NetCull.Destroy(gameObject);
		}
		else
		{
			this._playerClientList.Add(component);
		}
		return component;
	}

	// Token: 0x06002567 RID: 9575 RVA: 0x0008EE9C File Offset: 0x0008D09C
	protected internal virtual void EraseCharactersForClient(global::PlayerClient Client, bool HasUser, global::NetUser User)
	{
		global::Controllable controllable = Client.controllable;
		if (controllable)
		{
			global::Character character = controllable.character;
			if (HasUser)
			{
				try
				{
					this.SaveAvatar(character);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
				}
			}
			if (character)
			{
				this.ShutdownAvatar(character);
				global::Character.DestroyCharacter(character);
			}
		}
		this.RemovePlayerClientFromList(Client);
	}

	// Token: 0x06002568 RID: 9576 RVA: 0x0008EF1C File Offset: 0x0008D11C
	public void LocalClientPoliteReady()
	{
		global::UnityEngine.Debug.Log("LocalClientPoliteReady rpcing...");
		base.networkView.RPC("ClientFirstReady", 0, new object[0]);
	}

	// Token: 0x06002569 RID: 9577 RVA: 0x0008EF40 File Offset: 0x0008D140
	public virtual void GetCampSpawnForPlayer(global::PlayerClient playerFor, out global::UnityEngine.Vector3 spawnPos, out global::UnityEngine.Quaternion spawnRot)
	{
		global::UnityEngine.Debug.Log("SERVERMANAGEMENT::GetCampSpawn <-- bad");
		global::SpawnManager.GetRandomSpawn(out spawnPos, out spawnRot);
	}

	// Token: 0x0600256A RID: 9578 RVA: 0x0008EF54 File Offset: 0x0008D154
	public global::Character SpawnPlayer(global::PlayerClient playerFor, bool useCamp, global::RustProto.Avatar avatar = null)
	{
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.zero;
		global::UnityEngine.Quaternion identity = global::UnityEngine.Quaternion.identity;
		if (avatar != null && avatar.HasPos && avatar.HasAng)
		{
			vector..ctor(avatar.Pos.X, avatar.Pos.Y, avatar.Pos.Z);
			identity..ctor(avatar.Ang.X, avatar.Ang.Y, avatar.Ang.Z, avatar.Ang.W);
			if (float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.y))
			{
				global::UnityEngine.Debug.LogWarning("SpawnPlayer: position was NAN!");
				global::UnityEngine.Debug.LogWarning("Was spawning from avatar position!!");
				global::SpawnManager.GetRandomSpawn(out vector, out identity);
			}
		}
		else if (useCamp)
		{
			this.GetCampSpawnForPlayer(playerFor, out vector, out identity);
			if (float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.y))
			{
				global::UnityEngine.Debug.LogWarning("SpawnPlayer: position was NAN!!!");
				global::UnityEngine.Debug.LogWarning("Was spawning from camp!!!!!");
				global::SpawnManager.GetRandomSpawn(out vector, out identity);
			}
		}
		else
		{
			global::SpawnManager.GetRandomSpawn(out vector, out identity);
			if (float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.y))
			{
				global::UnityEngine.Debug.LogWarning("SpawnPlayer: position was NAN!!!");
				global::UnityEngine.Debug.LogWarning("Was spawning from RANDOM SPAWN!!!!!");
				vector = global::UnityEngine.Vector3.zero;
			}
		}
		global::NetUser netUser;
		if (!global::NetUser.Find(playerFor, out netUser))
		{
			global::UnityEngine.Debug.LogWarning("No NetUser for client", playerFor);
		}
		netUser.truthDetector.NoteTeleported(vector, 0.0);
		vector = global::Magma.Hooks.PlayerSpawning(playerFor, vector, useCamp);
		global::Character character = global::Character.SummonCharacter(netUser.networkPlayer, this.defaultPlayerControllableKey, vector, identity);
		if (character)
		{
			this.LoadAvatar(character);
			playerFor.lastKnownPosition = character.eyesOrigin;
			playerFor.hasLastKnownPosition = true;
			global::Magma.Hooks.PlayerSpawned(playerFor, vector, useCamp);
		}
		return character;
	}

	// Token: 0x0600256B RID: 9579 RVA: 0x0008F174 File Offset: 0x0008D374
	[global::UnityEngine.RPC]
	protected void RequestRespawn(bool campRequest, global::uLink.NetworkMessageInfo info)
	{
		global::PlayerClient playerClient;
		if (!this.GetPlayerClient(info.sender, out playerClient))
		{
			global::UnityEngine.Debug.LogError("No player client for sender " + info.sender, this);
			return;
		}
		bool flag = true;
		if (playerClient.controllable)
		{
			global::TakeDamage component = playerClient.controllable.idMain.GetComponent<global::TakeDamage>();
			if (component && component.alive)
			{
				flag = false;
			}
		}
		if (flag)
		{
			global::NetUser netUser = global::NetUser.Find(info.sender);
			if (object.ReferenceEquals(netUser, null))
			{
				global::UnityEngine.Debug.LogWarning("Cannot respawn " + playerClient.name + " because theres no NetUser for sender yet.", playerClient);
				flag = false;
			}
			else if (!netUser.joinedGameWithCharacter)
			{
				global::UnityEngine.Debug.LogWarning("Cannot respawn " + netUser + " because the user has not completed its connection yet ( by making a character )", playerClient);
				flag = false;
			}
		}
		if (flag)
		{
			global::Character character = this.SpawnPlayer(playerClient, campRequest, null);
		}
	}

	// Token: 0x0600256C RID: 9580 RVA: 0x0008F260 File Offset: 0x0008D460
	[global::UnityEngine.RPC]
	protected void ClientFirstReady(global::uLink.NetworkMessageInfo info)
	{
		global::NetUser netUser = global::NetUser.Find(info.sender);
		global::PlayerClient playerClient = netUser.playerClient;
		if (playerClient.firstReady)
		{
			global::UnityEngine.Debug.Log("player client already invoked first ready? perhaps this is a hack attempt?? " + playerClient);
			return;
		}
		playerClient.firstReady = true;
		this.ConnectUserToGame(netUser);
	}

	// Token: 0x0600256D RID: 9581 RVA: 0x0008F2AC File Offset: 0x0008D4AC
	protected virtual void ConnectUserToGame(global::NetUser user)
	{
		user.InitializeClientToServer();
	}

	// Token: 0x0600256E RID: 9582 RVA: 0x0008F2B4 File Offset: 0x0008D4B4
	public virtual void UpdateConnectingUserAvatar(global::NetUser user, ref global::RustProto.Avatar avatar)
	{
	}

	// Token: 0x0600256F RID: 9583 RVA: 0x0008F2B8 File Offset: 0x0008D4B8
	protected virtual void LoadAvatar(global::Character forCharacter)
	{
	}

	// Token: 0x06002570 RID: 9584 RVA: 0x0008F2BC File Offset: 0x0008D4BC
	protected virtual void SaveAvatar(global::Character forCharacter)
	{
	}

	// Token: 0x06002571 RID: 9585 RVA: 0x0008F2C0 File Offset: 0x0008D4C0
	protected virtual void ClearAvatar(global::Character forCharacter)
	{
	}

	// Token: 0x06002572 RID: 9586 RVA: 0x0008F2C4 File Offset: 0x0008D4C4
	protected virtual void ShutdownAvatar(global::Character forCharacter)
	{
	}

	// Token: 0x06002573 RID: 9587 RVA: 0x0008F2C8 File Offset: 0x0008D4C8
	private void AddPlayerClientToList(global::PlayerClient pc)
	{
		this._playerClientList.Add(pc);
	}

	// Token: 0x06002574 RID: 9588 RVA: 0x0008F2D8 File Offset: 0x0008D4D8
	private void RemovePlayerClientFromList(global::PlayerClient pc)
	{
		this._playerClientList.Remove(pc);
	}

	// Token: 0x06002575 RID: 9589 RVA: 0x0008F2E8 File Offset: 0x0008D4E8
	private void RemovePlayerClientFromListByNetworkPlayer(global::uLink.NetworkPlayer np)
	{
		global::PlayerClient pc;
		if (this.GetPlayerClient(np, out pc))
		{
			this.RemovePlayerClientFromList(pc);
		}
		else
		{
			global::UnityEngine.Debug.Log("Error, could not find PC for NP");
		}
	}

	// Token: 0x06002576 RID: 9590 RVA: 0x0008F31C File Offset: 0x0008D51C
	public bool GetPlayerClient(global::UnityEngine.GameObject go, out global::PlayerClient playerClient)
	{
		foreach (global::PlayerClient playerClient2 in this._playerClientList)
		{
			if (playerClient2.controllable && playerClient2.controllable.gameObject == go)
			{
				playerClient = playerClient2;
				return true;
			}
		}
		playerClient = null;
		return false;
	}

	// Token: 0x06002577 RID: 9591 RVA: 0x0008F3B4 File Offset: 0x0008D5B4
	public bool GetPlayerClient(global::uLink.NetworkPlayer player, out global::PlayerClient playerClient)
	{
		foreach (global::PlayerClient playerClient2 in this._playerClientList)
		{
			if (playerClient2.netPlayer == player)
			{
				playerClient = playerClient2;
				return true;
			}
		}
		playerClient = null;
		return false;
	}

	// Token: 0x06002578 RID: 9592 RVA: 0x0008F434 File Offset: 0x0008D634
	[global::System.Obsolete("You should be using PlayerClient.FindAllWithString")]
	internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> FindPlayerClientsByString(string name)
	{
		int iFound = 0;
		ulong iUserID = 0UL;
		if (ulong.TryParse(name, out iUserID))
		{
			foreach (global::PlayerClient client in this._playerClientList)
			{
				if (client.userID == iUserID)
				{
					yield return client;
					iFound++;
					break;
				}
			}
			if (iFound > 0)
			{
				yield break;
			}
		}
		foreach (global::PlayerClient client2 in this._playerClientList)
		{
			if (string.Equals(client2.userName, name, global::System.StringComparison.InvariantCultureIgnoreCase))
			{
				yield return client2;
				iFound++;
			}
		}
		if (iFound > 0)
		{
			yield break;
		}
		foreach (global::PlayerClient client3 in this._playerClientList)
		{
			if (client3.userName.StartsWith(name, global::System.StringComparison.InvariantCultureIgnoreCase))
			{
				yield return client3;
			}
		}
		yield break;
	}

	// Token: 0x06002579 RID: 9593 RVA: 0x0008F468 File Offset: 0x0008D668
	[global::System.Obsolete("You should be using PlayerClient.FindAllWithName")]
	internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> FindPlayerClientsByName(string name, global::System.StringComparison comparison)
	{
		foreach (global::PlayerClient client in this._playerClientList)
		{
			if (string.Equals(client.userName, name, comparison))
			{
				yield return client;
			}
		}
		yield break;
	}

	// Token: 0x0600257A RID: 9594 RVA: 0x0008F4A8 File Offset: 0x0008D6A8
	public static global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> GetNetworkPlayersByName(string name)
	{
		return global::ServerManagement.GetNetworkPlayersByName(name, global::System.StringComparison.InvariantCultureIgnoreCase);
	}

	// Token: 0x0600257B RID: 9595 RVA: 0x0008F4B4 File Offset: 0x0008D6B4
	public static global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> GetNetworkPlayersByName(string name, global::System.StringComparison comparison)
	{
		global::ServerManagement svm = global::ServerManagement.Get();
		if (svm)
		{
			foreach (global::PlayerClient pc in svm.FindPlayerClientsByName(name, comparison))
			{
				yield return pc.netPlayer;
			}
		}
		yield break;
	}

	// Token: 0x0600257C RID: 9596 RVA: 0x0008F4EC File Offset: 0x0008D6EC
	public static global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> GetNetworkPlayersByString(string partialNameOrIntID)
	{
		global::ServerManagement svm = global::ServerManagement.Get();
		if (svm)
		{
			foreach (global::PlayerClient pc in svm.FindPlayerClientsByString(partialNameOrIntID))
			{
				yield return pc.netPlayer;
			}
		}
		yield break;
	}

	// Token: 0x0600257D RID: 9597 RVA: 0x0008F518 File Offset: 0x0008D718
	public global::uLink.RPCMode GetNetworkPlayersInSameZone(global::PlayerClient client)
	{
		return 1;
	}

	// Token: 0x0600257E RID: 9598 RVA: 0x0008F51C File Offset: 0x0008D71C
	public global::uLink.RPCMode GetNetworkPlayersInGroup(string group)
	{
		return 1;
	}

	// Token: 0x0600257F RID: 9599 RVA: 0x0008F520 File Offset: 0x0008D720
	protected static bool GetOrigin(global::uLink.NetworkPlayer player, bool eyes, out global::UnityEngine.Vector3 origin)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		global::PlayerClient playerClient;
		if (serverManagement && serverManagement.GetPlayerClient(player, out playerClient))
		{
			global::Controllable controllable = playerClient.controllable;
			if (controllable)
			{
				global::Character component = controllable.GetComponent<global::Character>();
				global::UnityEngine.Transform transform;
				if (component)
				{
					transform = ((!eyes || !component.eyesTransformReadOnly) ? component.transform : component.eyesTransformReadOnly);
				}
				else
				{
					transform = controllable.transform;
				}
				origin = transform.position;
				return true;
			}
		}
		origin = default(global::UnityEngine.Vector3);
		return false;
	}

	// Token: 0x06002580 RID: 9600 RVA: 0x0008F5C8 File Offset: 0x0008D7C8
	[global::UnityEngine.RPC]
	protected void UnstickMove(global::UnityEngine.Vector3 point)
	{
	}

	// Token: 0x06002581 RID: 9601 RVA: 0x0008F5CC File Offset: 0x0008D7CC
	[global::UnityEngine.RPC]
	protected void KP(int err)
	{
	}

	// Token: 0x06002582 RID: 9602 RVA: 0x0008F5D0 File Offset: 0x0008D7D0
	[global::UnityEngine.RPC]
	protected void RS(float duration)
	{
	}

	// Token: 0x06002583 RID: 9603 RVA: 0x0008F5D4 File Offset: 0x0008D7D4
	public static bool ResyncronizeClientClock(global::uLink.NetworkPlayer player, float duration = 6f)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (serverManagement && player.isConnected && player.isClient)
		{
			serverManagement.networkView.RPC<float>("RS", player, duration);
			return true;
		}
		return false;
	}

	// Token: 0x06002584 RID: 9604 RVA: 0x0008F620 File Offset: 0x0008D820
	protected void OnDestroy()
	{
		if (global::ServerManagement._serverMan == this)
		{
			global::ServerManagement._serverMan = null;
		}
	}

	// Token: 0x06002585 RID: 9605 RVA: 0x0008F638 File Offset: 0x0008D838
	public virtual void TeleportPlayer(global::uLink.NetworkPlayer move, global::UnityEngine.Vector3 worldPoint)
	{
	}

	// Token: 0x06002586 RID: 9606 RVA: 0x0008F63C File Offset: 0x0008D83C
	public virtual void OnUserConnected(global::NetUser User)
	{
		global::GameEvent.DoPlayerConnected(User.playerClient);
	}

	// Token: 0x04001304 RID: 4868
	[global::UnityEngine.SerializeField]
	protected string defaultPlayerControllableKey = ":player_soldier";

	// Token: 0x04001305 RID: 4869
	private static global::ServerManagement _serverMan;

	// Token: 0x04001306 RID: 4870
	[global::System.NonSerialized]
	protected readonly global::System.Collections.Generic.List<global::PlayerClient> _playerClientList;

	// Token: 0x04001307 RID: 4871
	[global::System.NonSerialized]
	[global::System.Obsolete("Use PlayerClient.All")]
	internal readonly global::LockedList<global::PlayerClient> lockedPlayerClientList;

	// Token: 0x04001308 RID: 4872
	private bool hasUnstickPosition;

	// Token: 0x04001309 RID: 4873
	private global::UnityEngine.Transform unstickTransform;

	// Token: 0x0400130A RID: 4874
	private global::UnityEngine.Vector3 nextUnstickPosition;

	// Token: 0x0400130B RID: 4875
	protected bool blockFutureConnections;

	// Token: 0x02000433 RID: 1075
	protected struct PreServerDestroyArgs
	{
		// Token: 0x06002587 RID: 9607 RVA: 0x0008F64C File Offset: 0x0008D84C
		internal PreServerDestroyArgs(global::IDMain main, global::UnityEngine.MonoBehaviour view, global::NetEntityID id, global::NetEntityID.Kind kind)
		{
			this.instance = main;
			this.view = view;
			this.entityID = id;
			this.viewKind = kind;
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06002588 RID: 9608 RVA: 0x0008F66C File Offset: 0x0008D86C
		public global::Facepunch.NetworkView networkView
		{
			get
			{
				if ((int)this.viewKind == 1)
				{
					return (global::Facepunch.NetworkView)this.view;
				}
				return null;
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06002589 RID: 9609 RVA: 0x0008F688 File Offset: 0x0008D888
		public global::NGCView ngcView
		{
			get
			{
				if ((int)this.viewKind == -1)
				{
					return (global::NGCView)this.view;
				}
				return null;
			}
		}

		// Token: 0x0600258A RID: 9610 RVA: 0x0008F6A4 File Offset: 0x0008D8A4
		public bool Main<TMain>(out TMain main) where TMain : global::IDMain
		{
			if (this.instance && this.instance is TMain)
			{
				main = (TMain)((object)this.instance);
				return true;
			}
			main = (TMain)((object)null);
			return false;
		}

		// Token: 0x0600258B RID: 9611 RVA: 0x0008F6F4 File Offset: 0x0008D8F4
		public TMain Main<TMain>() where TMain : global::IDMain
		{
			TMain tmain;
			return (!this.Main<TMain>(out tmain)) ? ((TMain)((object)null)) : tmain;
		}

		// Token: 0x0600258C RID: 9612 RVA: 0x0008F71C File Offset: 0x0008D91C
		public bool Local<TLocal>(out TLocal local) where TLocal : global::IDLocal
		{
			if (this.instance)
			{
				return local = this.instance.GetLocal<TLocal>();
			}
			local = (TLocal)((object)null);
			return false;
		}

		// Token: 0x0600258D RID: 9613 RVA: 0x0008F768 File Offset: 0x0008D968
		public TLocal Local<TLocal>() where TLocal : global::IDLocal
		{
			TLocal tlocal;
			return (!this.Local<TLocal>(out tlocal)) ? ((TLocal)((object)null)) : tlocal;
		}

		// Token: 0x0600258E RID: 9614 RVA: 0x0008F790 File Offset: 0x0008D990
		public bool Remote<TRemote>(out TRemote remote) where TRemote : global::IDRemote
		{
			if (this.instance)
			{
				return remote = this.instance.GetRemote<TRemote>();
			}
			remote = (TRemote)((object)null);
			return false;
		}

		// Token: 0x0600258F RID: 9615 RVA: 0x0008F7DC File Offset: 0x0008D9DC
		public TRemote Remote<TRemote>() where TRemote : global::IDRemote
		{
			TRemote tremote;
			return (!this.Remote<TRemote>(out tremote)) ? ((TRemote)((object)null)) : tremote;
		}

		// Token: 0x06002590 RID: 9616 RVA: 0x0008F804 File Offset: 0x0008DA04
		public bool Is<T>() where T : class
		{
			return this.instance && this.instance is T;
		}

		// Token: 0x0400130C RID: 4876
		public readonly global::IDMain instance;

		// Token: 0x0400130D RID: 4877
		public readonly global::UnityEngine.MonoBehaviour view;

		// Token: 0x0400130E RID: 4878
		public readonly global::NetEntityID entityID;

		// Token: 0x0400130F RID: 4879
		public readonly global::NetEntityID.Kind viewKind;
	}

	// Token: 0x02000434 RID: 1076
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <FindPlayerClientsByString>c__Iterator38 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::PlayerClient>, global::System.Collections.Generic.IEnumerator<global::PlayerClient>
	{
		// Token: 0x06002591 RID: 9617 RVA: 0x0008F828 File Offset: 0x0008DA28
		public <FindPlayerClientsByString>c__Iterator38()
		{
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06002592 RID: 9618 RVA: 0x0008F830 File Offset: 0x0008DA30
		global::PlayerClient global::System.Collections.Generic.IEnumerator<global::PlayerClient>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06002593 RID: 9619 RVA: 0x0008F838 File Offset: 0x0008DA38
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002594 RID: 9620 RVA: 0x0008F840 File Offset: 0x0008DA40
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<PlayerClient>.GetEnumerator();
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x0008F848 File Offset: 0x0008DA48
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::PlayerClient> global::System.Collections.Generic.IEnumerable<global::PlayerClient>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ServerManagement.<FindPlayerClientsByString>c__Iterator38 <FindPlayerClientsByString>c__Iterator = new global::ServerManagement.<FindPlayerClientsByString>c__Iterator38();
			<FindPlayerClientsByString>c__Iterator.<>f__this = this;
			<FindPlayerClientsByString>c__Iterator.name = name;
			return <FindPlayerClientsByString>c__Iterator;
		}

		// Token: 0x06002596 RID: 9622 RVA: 0x0008F888 File Offset: 0x0008DA88
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				iFound = 0;
				iUserID = 0UL;
				if (!ulong.TryParse(name, out iUserID))
				{
					goto IL_109;
				}
				enumerator = this._playerClientList.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			case 2U:
				Block_5:
				try
				{
					switch (num)
					{
					case 2U:
						iFound++;
						break;
					}
					while (enumerator2.MoveNext())
					{
						client2 = enumerator2.Current;
						if (string.Equals(client2.userName, name, global::System.StringComparison.InvariantCultureIgnoreCase))
						{
							this.$current = client2;
							this.$PC = 2;
							flag = true;
							return true;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((global::System.IDisposable)enumerator2).Dispose();
					}
				}
				if (iFound > 0)
				{
					return false;
				}
				enumerator3 = this._playerClientList.GetEnumerator();
				num = 0xFFFFFFFDU;
				goto Block_7;
			case 3U:
				goto IL_1E1;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1U:
					iFound++;
					break;
				default:
					while (enumerator.MoveNext())
					{
						client = enumerator.Current;
						if (client.userID == iUserID)
						{
							this.$current = client;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
					break;
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			if (iFound > 0)
			{
				return false;
			}
			IL_109:
			enumerator2 = this._playerClientList.GetEnumerator();
			num = 0xFFFFFFFDU;
			goto Block_5;
			Block_7:
			try
			{
				IL_1E1:
				switch (num)
				{
				}
				while (enumerator3.MoveNext())
				{
					client3 = enumerator3.Current;
					if (client3.userName.StartsWith(name, global::System.StringComparison.InvariantCultureIgnoreCase))
					{
						this.$current = client3;
						this.$PC = 3;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator3).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06002597 RID: 9623 RVA: 0x0008FB50 File Offset: 0x0008DD50
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			case 2U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator2).Dispose();
				}
				break;
			case 3U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x06002598 RID: 9624 RVA: 0x0008FC20 File Offset: 0x0008DE20
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001310 RID: 4880
		internal int <iFound>__0;

		// Token: 0x04001311 RID: 4881
		internal ulong <iUserID>__1;

		// Token: 0x04001312 RID: 4882
		internal string name;

		// Token: 0x04001313 RID: 4883
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_356>__2;

		// Token: 0x04001314 RID: 4884
		internal global::PlayerClient <client>__3;

		// Token: 0x04001315 RID: 4885
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_357>__4;

		// Token: 0x04001316 RID: 4886
		internal global::PlayerClient <client>__5;

		// Token: 0x04001317 RID: 4887
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_358>__6;

		// Token: 0x04001318 RID: 4888
		internal global::PlayerClient <client>__7;

		// Token: 0x04001319 RID: 4889
		internal int $PC;

		// Token: 0x0400131A RID: 4890
		internal global::PlayerClient $current;

		// Token: 0x0400131B RID: 4891
		internal string <$>name;

		// Token: 0x0400131C RID: 4892
		internal global::ServerManagement <>f__this;
	}

	// Token: 0x02000435 RID: 1077
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <FindPlayerClientsByName>c__Iterator39 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::PlayerClient>, global::System.Collections.Generic.IEnumerator<global::PlayerClient>
	{
		// Token: 0x06002599 RID: 9625 RVA: 0x0008FC28 File Offset: 0x0008DE28
		public <FindPlayerClientsByName>c__Iterator39()
		{
		}

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x0600259A RID: 9626 RVA: 0x0008FC30 File Offset: 0x0008DE30
		global::PlayerClient global::System.Collections.Generic.IEnumerator<global::PlayerClient>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x0600259B RID: 9627 RVA: 0x0008FC38 File Offset: 0x0008DE38
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600259C RID: 9628 RVA: 0x0008FC40 File Offset: 0x0008DE40
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<PlayerClient>.GetEnumerator();
		}

		// Token: 0x0600259D RID: 9629 RVA: 0x0008FC48 File Offset: 0x0008DE48
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::PlayerClient> global::System.Collections.Generic.IEnumerable<global::PlayerClient>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ServerManagement.<FindPlayerClientsByName>c__Iterator39 <FindPlayerClientsByName>c__Iterator = new global::ServerManagement.<FindPlayerClientsByName>c__Iterator39();
			<FindPlayerClientsByName>c__Iterator.<>f__this = this;
			<FindPlayerClientsByName>c__Iterator.name = name;
			<FindPlayerClientsByName>c__Iterator.comparison = comparison;
			return <FindPlayerClientsByName>c__Iterator;
		}

		// Token: 0x0600259E RID: 9630 RVA: 0x0008FC94 File Offset: 0x0008DE94
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = this._playerClientList.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					client = enumerator.Current;
					if (string.Equals(client.userName, name, comparison))
					{
						this.$current = client;
						this.$PC = 1;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x0600259F RID: 9631 RVA: 0x0008FD94 File Offset: 0x0008DF94
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060025A0 RID: 9632 RVA: 0x0008FDF4 File Offset: 0x0008DFF4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400131D RID: 4893
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_359>__0;

		// Token: 0x0400131E RID: 4894
		internal global::PlayerClient <client>__1;

		// Token: 0x0400131F RID: 4895
		internal string name;

		// Token: 0x04001320 RID: 4896
		internal global::System.StringComparison comparison;

		// Token: 0x04001321 RID: 4897
		internal int $PC;

		// Token: 0x04001322 RID: 4898
		internal global::PlayerClient $current;

		// Token: 0x04001323 RID: 4899
		internal string <$>name;

		// Token: 0x04001324 RID: 4900
		internal global::System.StringComparison <$>comparison;

		// Token: 0x04001325 RID: 4901
		internal global::ServerManagement <>f__this;
	}

	// Token: 0x02000436 RID: 1078
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <GetNetworkPlayersByName>c__Iterator3A : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer>, global::System.Collections.Generic.IEnumerator<global::uLink.NetworkPlayer>
	{
		// Token: 0x060025A1 RID: 9633 RVA: 0x0008FDFC File Offset: 0x0008DFFC
		public <GetNetworkPlayersByName>c__Iterator3A()
		{
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x060025A2 RID: 9634 RVA: 0x0008FE04 File Offset: 0x0008E004
		global::uLink.NetworkPlayer global::System.Collections.Generic.IEnumerator<global::uLink.NetworkPlayer>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x060025A3 RID: 9635 RVA: 0x0008FE0C File Offset: 0x0008E00C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060025A4 RID: 9636 RVA: 0x0008FE1C File Offset: 0x0008E01C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<uLink.NetworkPlayer>.GetEnumerator();
		}

		// Token: 0x060025A5 RID: 9637 RVA: 0x0008FE24 File Offset: 0x0008E024
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::uLink.NetworkPlayer> global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ServerManagement.<GetNetworkPlayersByName>c__Iterator3A <GetNetworkPlayersByName>c__Iterator3A = new global::ServerManagement.<GetNetworkPlayersByName>c__Iterator3A();
			<GetNetworkPlayersByName>c__Iterator3A.name = name;
			<GetNetworkPlayersByName>c__Iterator3A.comparison = comparison;
			return <GetNetworkPlayersByName>c__Iterator3A;
		}

		// Token: 0x060025A6 RID: 9638 RVA: 0x0008FE64 File Offset: 0x0008E064
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				svm = global::ServerManagement.Get();
				if (!svm)
				{
					goto IL_D2;
				}
				enumerator = svm.FindPlayerClientsByName(name, comparison).GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					this.$current = pc.netPlayer;
					this.$PC = 1;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			IL_D2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x060025A7 RID: 9639 RVA: 0x0008FF6C File Offset: 0x0008E16C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060025A8 RID: 9640 RVA: 0x0008FFD0 File Offset: 0x0008E1D0
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001326 RID: 4902
		internal global::ServerManagement <svm>__0;

		// Token: 0x04001327 RID: 4903
		internal string name;

		// Token: 0x04001328 RID: 4904
		internal global::System.StringComparison comparison;

		// Token: 0x04001329 RID: 4905
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_360>__1;

		// Token: 0x0400132A RID: 4906
		internal global::PlayerClient <pc>__2;

		// Token: 0x0400132B RID: 4907
		internal int $PC;

		// Token: 0x0400132C RID: 4908
		internal global::uLink.NetworkPlayer $current;

		// Token: 0x0400132D RID: 4909
		internal string <$>name;

		// Token: 0x0400132E RID: 4910
		internal global::System.StringComparison <$>comparison;
	}

	// Token: 0x02000437 RID: 1079
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <GetNetworkPlayersByString>c__Iterator3B : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer>, global::System.Collections.Generic.IEnumerator<global::uLink.NetworkPlayer>
	{
		// Token: 0x060025A9 RID: 9641 RVA: 0x0008FFD8 File Offset: 0x0008E1D8
		public <GetNetworkPlayersByString>c__Iterator3B()
		{
		}

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x060025AA RID: 9642 RVA: 0x0008FFE0 File Offset: 0x0008E1E0
		global::uLink.NetworkPlayer global::System.Collections.Generic.IEnumerator<global::uLink.NetworkPlayer>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x060025AB RID: 9643 RVA: 0x0008FFE8 File Offset: 0x0008E1E8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060025AC RID: 9644 RVA: 0x0008FFF8 File Offset: 0x0008E1F8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<uLink.NetworkPlayer>.GetEnumerator();
		}

		// Token: 0x060025AD RID: 9645 RVA: 0x00090000 File Offset: 0x0008E200
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::uLink.NetworkPlayer> global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ServerManagement.<GetNetworkPlayersByString>c__Iterator3B <GetNetworkPlayersByString>c__Iterator3B = new global::ServerManagement.<GetNetworkPlayersByString>c__Iterator3B();
			<GetNetworkPlayersByString>c__Iterator3B.partialNameOrIntID = partialNameOrIntID;
			return <GetNetworkPlayersByString>c__Iterator3B;
		}

		// Token: 0x060025AE RID: 9646 RVA: 0x00090034 File Offset: 0x0008E234
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				svm = global::ServerManagement.Get();
				if (!svm)
				{
					goto IL_CC;
				}
				enumerator = svm.FindPlayerClientsByString(partialNameOrIntID).GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					this.$current = pc.netPlayer;
					this.$PC = 1;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			IL_CC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x060025AF RID: 9647 RVA: 0x00090138 File Offset: 0x0008E338
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060025B0 RID: 9648 RVA: 0x0009019C File Offset: 0x0008E39C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400132F RID: 4911
		internal global::ServerManagement <svm>__0;

		// Token: 0x04001330 RID: 4912
		internal string partialNameOrIntID;

		// Token: 0x04001331 RID: 4913
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_361>__1;

		// Token: 0x04001332 RID: 4914
		internal global::PlayerClient <pc>__2;

		// Token: 0x04001333 RID: 4915
		internal int $PC;

		// Token: 0x04001334 RID: 4916
		internal global::uLink.NetworkPlayer $current;

		// Token: 0x04001335 RID: 4917
		internal string <$>partialNameOrIntID;
	}
}
