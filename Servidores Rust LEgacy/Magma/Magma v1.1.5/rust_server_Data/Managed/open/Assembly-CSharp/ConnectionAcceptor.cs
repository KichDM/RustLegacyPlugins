using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Magma;
using Rust.Steam;
using uLink;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class ConnectionAcceptor : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001B16 RID: 6934 RVA: 0x0006B4B4 File Offset: 0x000696B4
	public ConnectionAcceptor()
	{
	}

	// Token: 0x06001B17 RID: 6935 RVA: 0x0006B4C8 File Offset: 0x000696C8
	// Note: this type is marked as 'beforefieldinit'.
	static ConnectionAcceptor()
	{
	}

	// Token: 0x06001B18 RID: 6936 RVA: 0x0006B4CC File Offset: 0x000696CC
	public void Start()
	{
		global::ConnectionAcceptor.Singleton = this;
	}

	// Token: 0x06001B19 RID: 6937 RVA: 0x0006B4D4 File Offset: 0x000696D4
	public bool IsConnected(ulong iSteamID)
	{
		return this.m_Connections.Any((global::ClientConnection item) => item.UserID == iSteamID);
	}

	// Token: 0x06001B1A RID: 6938 RVA: 0x0006B508 File Offset: 0x00069708
	public static void CloseConnection(global::ClientConnection connection)
	{
		if (global::ConnectionAcceptor.Singleton == null)
		{
			return;
		}
		global::ConnectionAcceptor.Singleton.m_Connections.Remove(connection);
	}

	// Token: 0x06001B1B RID: 6939 RVA: 0x0006B538 File Offset: 0x00069738
	public void uLink_OnPlayerApproval(global::uLink.NetworkPlayerApproval approval)
	{
		if (this.m_Connections.Count >= global::server.maxplayers)
		{
			approval.Deny(0x11);
			return;
		}
		global::ClientConnection clientConnection = new global::ClientConnection();
		if (!clientConnection.ReadConnectionData(approval.loginData))
		{
			approval.Deny(-3);
			return;
		}
		if (clientConnection.Protocol != 0x42D)
		{
			global::UnityEngine.Debug.Log("Denying entry to client with invalid protocol version (" + approval.ipAddress + ")");
			approval.Deny(0x40);
			return;
		}
		if (global::BanList.Contains(clientConnection.UserID))
		{
			global::UnityEngine.Debug.Log("Rejecting client (" + clientConnection.UserID.ToString() + "in banlist)");
			approval.Deny(0x15);
			return;
		}
		if (this.IsConnected(clientConnection.UserID))
		{
			global::UnityEngine.Debug.Log("Denying entry to " + clientConnection.UserID.ToString() + " because they're already connected");
			approval.Deny(-1);
			return;
		}
		this.m_Connections.Add(clientConnection);
		base.StartCoroutine(clientConnection.AuthorisationRoutine(approval));
		approval.Wait();
	}

	// Token: 0x06001B1C RID: 6940 RVA: 0x0006B648 File Offset: 0x00069848
	public void uLink_OnPlayerConnected(global::uLink.NetworkPlayer player)
	{
		global::ClientConnection clientConnection = player.localData as global::ClientConnection;
		if (clientConnection == null)
		{
			global::NetCull.CloseConnection(player, true);
			return;
		}
		global::NetUser netUser = new global::NetUser(player);
		netUser.DoSetup();
		netUser.connection = clientConnection;
		netUser.playerClient = global::ServerManagement.Get().CreatePlayerClientForUser(netUser);
		global::ServerManagement.Get().OnUserConnected(netUser);
		global::ConsoleSystem.Print(string.Concat(new string[]
		{
			"User Connected: ",
			netUser.displayName,
			" (",
			netUser.userID.ToString(),
			")"
		}), false);
		global::Rust.Steam.Server.OnPlayerCountChanged();
	}

	// Token: 0x06001B1D RID: 6941 RVA: 0x0006B6E8 File Offset: 0x000698E8
	public static void OnSteamOnUserGroup(ulong userID, ulong usergroupID, string status)
	{
		if (!global::ConnectionAcceptor.Singleton)
		{
			return;
		}
		global::ClientConnection clientConnection = global::ConnectionAcceptor.Singleton.m_Connections.Find((global::ClientConnection item) => item.UserID == userID);
		if (clientConnection == null)
		{
			return;
		}
		clientConnection.steamGroupID = usergroupID;
		clientConnection.steamGroupStatus = status;
	}

	// Token: 0x06001B1E RID: 6942 RVA: 0x0006B744 File Offset: 0x00069944
	public static void OnSteamAuthorization(ulong userID, string status)
	{
		if (!global::ConnectionAcceptor.Singleton)
		{
			return;
		}
		global::ClientConnection clientConnection = global::ConnectionAcceptor.Singleton.m_Connections.Find((global::ClientConnection item) => item.UserID == userID);
		if (clientConnection == null)
		{
			return;
		}
		clientConnection.AuthStatus = status;
		if (status != "ok" && clientConnection.netUser != null)
		{
			if (status == "ok")
			{
				global::UnityEngine.Debug.Log("That's odd. Got an 'ok' auth for already authed player " + userID.ToString());
				return;
			}
			if (status == "vac")
			{
				global::ConsoleSystem.Print(string.Concat(new string[]
				{
					"Kicking ",
					clientConnection.netUser.displayName,
					" (",
					userID.ToString(),
					") - they have been banned by VAC"
				}), false);
				clientConnection.netUser.Kick(global::NetError.Facepunch_Connector_VAC_Banned, true);
				return;
			}
			if (status == "loggedin")
			{
				global::ConsoleSystem.Print(string.Concat(new string[]
				{
					"Kicking ",
					clientConnection.netUser.displayName,
					" (",
					userID.ToString(),
					") - they have logged in elsewhere"
				}), false);
				clientConnection.netUser.Kick(global::NetError.Facepunch_Connector_ConnectedElsewhere, true);
				return;
			}
			if (status == "cancelled")
			{
				global::ConsoleSystem.Print(string.Concat(new string[]
				{
					"Kicking ",
					clientConnection.netUser.displayName,
					" (",
					userID.ToString(),
					") - their ticket was cancelled"
				}), false);
				clientConnection.netUser.Kick(global::NetError.Facepunch_Connector_ConnectedElsewhere, true);
				return;
			}
			if (status == "noconnect")
			{
				global::ConsoleSystem.Print(string.Concat(new string[]
				{
					"Kicking ",
					clientConnection.netUser.displayName,
					" (",
					userID.ToString(),
					") - they're not connected to Steam"
				}), false);
				clientConnection.netUser.Kick(global::NetError.Facepunch_Connector_ConnectedElsewhere, true);
				return;
			}
			global::ConsoleSystem.Print(string.Concat(new string[]
			{
				"Kicking ",
				clientConnection.netUser.displayName,
				" (",
				userID.ToString(),
				") - ",
				status
			}), false);
			clientConnection.netUser.Kick(global::NetError.Facepunch_Connector_Expired, true);
		}
	}

	// Token: 0x06001B1F RID: 6943 RVA: 0x0006B9DC File Offset: 0x00069BDC
	public void uLink_OnPlayerDisconnected(global::uLink.NetworkPlayer player)
	{
		object localData = player.GetLocalData();
		if (localData is global::NetUser)
		{
			global::NetUser netUser = (global::NetUser)localData;
			global::PlayerClient playerClient = netUser.playerClient;
			netUser.connection.netUser = null;
			this.m_Connections.Remove(netUser.connection);
			try
			{
				if (playerClient != null)
				{
					global::ServerManagement.Get().EraseCharactersForClient(playerClient, true, netUser);
				}
				global::NetCull.DestroyPlayerObjects(player);
				global::CullGrid.ClearPlayerCulling(netUser);
				global::Magma.Hooks.PlayerDisconnect(netUser);
				global::NetCull.RemoveRPCs(player);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
				global::UnityEngine.Debug.Log("DO NOT IGNORE THE ERROR ABOVE. THESE THINGS SHOULD NOT BE FAILING. EVER.");
			}
			global::ConsoleSystem.Print("User Disconnected: " + netUser.displayName, false);
			global::Rust.Steam.Server.OnUserLeave(netUser.connection.UserID);
			try
			{
				netUser.Dispose();
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2, this);
				global::UnityEngine.Debug.Log("DO NOT IGNORE THE ERROR ABOVE. THESE THINGS SHOULD NOT BE FAILING. EVER.");
			}
		}
		else if (localData is global::ClientConnection)
		{
			global::ClientConnection item = (global::ClientConnection)localData;
			this.m_Connections.Remove(item);
			global::ConsoleSystem.Print("User Disconnected: (unconnected " + player.ipAddress + ")", false);
		}
		player.SetLocalData(null);
		global::Rust.Steam.Server.OnPlayerCountChanged();
	}

	// Token: 0x04000FD9 RID: 4057
	[global::System.NonSerialized]
	public global::System.Collections.Generic.List<global::ClientConnection> m_Connections = new global::System.Collections.Generic.List<global::ClientConnection>();

	// Token: 0x04000FDA RID: 4058
	private static global::ConnectionAcceptor Singleton;

	// Token: 0x02000327 RID: 807
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <IsConnected>c__AnonStorey61
	{
		// Token: 0x06001B20 RID: 6944 RVA: 0x0006BB2C File Offset: 0x00069D2C
		public <IsConnected>c__AnonStorey61()
		{
		}

		// Token: 0x06001B21 RID: 6945 RVA: 0x0006BB34 File Offset: 0x00069D34
		internal bool <>m__10(global::ClientConnection item)
		{
			return item.UserID == this.iSteamID;
		}

		// Token: 0x04000FDB RID: 4059
		internal ulong iSteamID;
	}

	// Token: 0x02000328 RID: 808
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <OnSteamOnUserGroup>c__AnonStorey62
	{
		// Token: 0x06001B22 RID: 6946 RVA: 0x0006BB44 File Offset: 0x00069D44
		public <OnSteamOnUserGroup>c__AnonStorey62()
		{
		}

		// Token: 0x06001B23 RID: 6947 RVA: 0x0006BB4C File Offset: 0x00069D4C
		internal bool <>m__11(global::ClientConnection item)
		{
			return item.UserID == this.userID;
		}

		// Token: 0x04000FDC RID: 4060
		internal ulong userID;
	}

	// Token: 0x02000329 RID: 809
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <OnSteamAuthorization>c__AnonStorey63
	{
		// Token: 0x06001B24 RID: 6948 RVA: 0x0006BB5C File Offset: 0x00069D5C
		public <OnSteamAuthorization>c__AnonStorey63()
		{
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x0006BB64 File Offset: 0x00069D64
		internal bool <>m__12(global::ClientConnection item)
		{
			return item.UserID == this.userID;
		}

		// Token: 0x04000FDD RID: 4061
		internal ulong userID;
	}
}
