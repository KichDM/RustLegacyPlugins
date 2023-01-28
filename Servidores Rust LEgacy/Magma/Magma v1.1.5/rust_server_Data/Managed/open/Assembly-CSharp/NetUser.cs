using System;
using System.Collections.Generic;
using POSIX;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x0200040B RID: 1035
public sealed class NetUser : global::System.IDisposable
{
	// Token: 0x060023F6 RID: 9206 RVA: 0x00089878 File Offset: 0x00087A78
	internal NetUser(global::uLink.NetworkPlayer NetworkPlayer)
	{
		global::ClientConnection clientConnection = NetworkPlayer.localData as global::ClientConnection;
		clientConnection.netUser = this;
		this.truthDetector = new global::TruthDetector();
		global::RustProto.User.Builder builder = new global::RustProto.User.Builder();
		builder.SetDisplayname(clientConnection.UserName);
		builder.SetUserid(clientConnection.UserID);
		builder.SetUsergroup(global::RustProto.User.Types.UserGroup.REGULAR);
		this.user = builder.Build();
		this.networkPlayer = NetworkPlayer;
	}

	// Token: 0x060023F7 RID: 9207 RVA: 0x000898F0 File Offset: 0x00087AF0
	internal static void AdjustTimesWithNewMeasurement()
	{
		global::NetUser.DropUtil.Cycle();
	}

	// Token: 0x060023F8 RID: 9208 RVA: 0x000898F8 File Offset: 0x00087AF8
	internal bool GetDropVariables(out ulong droppingPacketsVerifyTime)
	{
		if (this.droppingPackets)
		{
			droppingPacketsVerifyTime = this.droppingPacketsVerifyTime.endTime;
			return true;
		}
		droppingPacketsVerifyTime = 0UL;
		return false;
	}

	// Token: 0x060023F9 RID: 9209 RVA: 0x0008991C File Offset: 0x00087B1C
	internal void ClearDropCount()
	{
		this.droppingCountUnFixed = 0;
	}

	// Token: 0x060023FA RID: 9210 RVA: 0x00089928 File Offset: 0x00087B28
	internal int SetDropVariables()
	{
		this.droppingPackets = true;
		this.droppingPacketsVerifyTime = global::ServerDuration.Now;
		if (!this.droppingPacketsVerifyTime.final)
		{
			global::NetUser.DropUtil.AddUnfinal(this);
		}
		return ++this.droppingCountUnFixed;
	}

	// Token: 0x060023FB RID: 9211 RVA: 0x00089970 File Offset: 0x00087B70
	internal void ClearDropVariables()
	{
		this.droppingPackets = false;
	}

	// Token: 0x060023FC RID: 9212 RVA: 0x0008997C File Offset: 0x00087B7C
	public static void Cleanup()
	{
		int num = global::NetUser.Registry.CountUnloaded();
		if (num > 0)
		{
			global::System.Console.WriteLine("{0} stale net users", num);
		}
	}

	// Token: 0x1700081C RID: 2076
	// (get) Token: 0x060023FD RID: 9213 RVA: 0x000899A8 File Offset: 0x00087BA8
	public ulong userID
	{
		get
		{
			return this.user.Userid;
		}
	}

	// Token: 0x1700081D RID: 2077
	// (get) Token: 0x060023FE RID: 9214 RVA: 0x000899B8 File Offset: 0x00087BB8
	public string displayName
	{
		get
		{
			return this.user.Displayname;
		}
	}

	// Token: 0x1700081E RID: 2078
	// (get) Token: 0x060023FF RID: 9215 RVA: 0x000899C8 File Offset: 0x00087BC8
	public bool disposed
	{
		get
		{
			return this.did_dispose;
		}
	}

	// Token: 0x1700081F RID: 2079
	// (get) Token: 0x06002400 RID: 9216 RVA: 0x000899D0 File Offset: 0x00087BD0
	public bool connected
	{
		get
		{
			return this.did_connect && !this.did_disconnect;
		}
	}

	// Token: 0x17000820 RID: 2080
	// (get) Token: 0x06002401 RID: 9217 RVA: 0x000899EC File Offset: 0x00087BEC
	public bool joinedGameWithCharacter
	{
		get
		{
			return this.did_join;
		}
	}

	// Token: 0x17000821 RID: 2081
	// (get) Token: 0x06002402 RID: 9218 RVA: 0x000899F4 File Offset: 0x00087BF4
	[global::System.Obsolete("this is not set up well")]
	public bool isConnectedClient
	{
		get
		{
			return this.networkPlayer.isConnected && this.networkPlayer.isClient;
		}
	}

	// Token: 0x06002403 RID: 9219 RVA: 0x00089A28 File Offset: 0x00087C28
	internal void DoSetup()
	{
		global::NetUser.Registry.Add(this);
		this.did_connect = true;
		this.networkPlayer.SetLocalData(this);
		this.truthDetector.Init(this);
		this.connectTime = global::POSIX.Time.NowStamp;
	}

	// Token: 0x06002404 RID: 9220 RVA: 0x00089A6C File Offset: 0x00087C6C
	public int SecondsConnected()
	{
		return global::POSIX.Time.ElapsedStampSince(this.connectTime);
	}

	// Token: 0x06002405 RID: 9221 RVA: 0x00089A7C File Offset: 0x00087C7C
	public void SetAdmin(bool isAdmin)
	{
		this.admin = isAdmin;
	}

	// Token: 0x06002406 RID: 9222 RVA: 0x00089A88 File Offset: 0x00087C88
	public bool CanAdmin()
	{
		return this.admin;
	}

	// Token: 0x06002407 RID: 9223 RVA: 0x00089A90 File Offset: 0x00087C90
	public bool Kick(global::NetError reason, bool sendNotification)
	{
		if (this.did_disconnect)
		{
			return false;
		}
		this.did_disconnect = true;
		if (reason != global::NetError.NoError)
		{
			try
			{
				global::ServerManagement serverManagement = global::ServerManagement.Get();
				if (serverManagement)
				{
					serverManagement.networkView.RPC<int>("KP", this.networkPlayer, (int)reason);
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
		}
		global::NetCull.CloseConnection(this.networkPlayer, sendNotification);
		return true;
	}

	// Token: 0x06002408 RID: 9224 RVA: 0x00089B1C File Offset: 0x00087D1C
	public bool Kick(global::NetError reason, bool sendNotification, bool simulateImmediateDisconnect)
	{
		return this.Kick(reason, sendNotification);
	}

	// Token: 0x06002409 RID: 9225 RVA: 0x00089B34 File Offset: 0x00087D34
	internal bool OnConnectionCanceled(global::NetError error)
	{
		return this.Kick(error, false, true);
	}

	// Token: 0x0600240A RID: 9226 RVA: 0x00089B40 File Offset: 0x00087D40
	public void Ban()
	{
		global::ConsoleSystem.Run("banid " + this.user.Userid.ToString(), false);
	}

	// Token: 0x0600240B RID: 9227 RVA: 0x00089B74 File Offset: 0x00087D74
	public static bool IsUserConnected(ulong iUserID)
	{
		global::NetUser netUser = global::NetUser.Registry.FindUserID(iUserID);
		return netUser != null && netUser.did_connect && !netUser.did_disconnect;
	}

	// Token: 0x0600240C RID: 9228 RVA: 0x00089BA8 File Offset: 0x00087DA8
	public void Dispose()
	{
		try
		{
			if (!this.did_dispose)
			{
				global::NetUser.Registry.Remove(this);
				this.did_disconnect = this.did_connect;
				this.playerClient = null;
				this.did_dispose = true;
			}
		}
		finally
		{
		}
	}

	// Token: 0x0600240D RID: 9229 RVA: 0x00089C08 File Offset: 0x00087E08
	public static global::NetUser Find(global::uLink.NetworkPlayer player)
	{
		return player.GetLocalData() as global::NetUser;
	}

	// Token: 0x0600240E RID: 9230 RVA: 0x00089C18 File Offset: 0x00087E18
	public static bool Find(global::PlayerClient client, out global::NetUser user)
	{
		user = global::NetUser.Find(client.netPlayer);
		return user != null;
	}

	// Token: 0x0600240F RID: 9231 RVA: 0x00089C30 File Offset: 0x00087E30
	public static bool Find(ulong userID_OfLoadedUser, out global::NetUser user)
	{
		return global::NetUser.Registry.FindLoadedUserWithID(userID_OfLoadedUser, out user);
	}

	// Token: 0x06002410 RID: 9232 RVA: 0x00089C3C File Offset: 0x00087E3C
	public static global::NetUser FindByUserID(ulong userid)
	{
		global::NetUser result = null;
		global::NetUser.Registry.FindLoadedUserWithID(userid, out result);
		return result;
	}

	// Token: 0x06002411 RID: 9233 RVA: 0x00089C58 File Offset: 0x00087E58
	public static bool Find(global::UnityEngine.GameObject gameObject, out global::NetUser user)
	{
		return global::NetUser.Find(gameObject.GetComponent<global::uLink.NetworkView>(), out user);
	}

	// Token: 0x06002412 RID: 9234 RVA: 0x00089C68 File Offset: 0x00087E68
	public static bool Find(global::uLink.NetworkView view, out global::NetUser user)
	{
		if (!view)
		{
			user = null;
			return false;
		}
		global::UnityEngine.Component observed = view.observed;
		if (observed == view || !global::NetUser.Find(observed, out user))
		{
			user = global::NetUser.Find(view.owner);
			return user != null;
		}
		return true;
	}

	// Token: 0x06002413 RID: 9235 RVA: 0x00089CBC File Offset: 0x00087EBC
	public static bool Find(global::UnityEngine.Component component, out global::NetUser user)
	{
		if (component is global::PlayerClient)
		{
			return global::NetUser.Find((global::PlayerClient)component, out user);
		}
		if (component is global::Controllable)
		{
			return global::NetUser.Find((global::Controllable)component, out user);
		}
		if (component is global::Controller)
		{
			return global::NetUser.Find(((global::Controller)component).controllable, out user);
		}
		user = null;
		return false;
	}

	// Token: 0x06002414 RID: 9236 RVA: 0x00089D1C File Offset: 0x00087F1C
	public override string ToString()
	{
		if (this.did_dispose)
		{
			return string.Format("[NetUser|disposed]", new object[0]);
		}
		return string.Format("[NetUser|{0}|{1}|{2}]", this.user.Displayname, this.user.Userid, this.networkPlayer.id);
	}

	// Token: 0x06002415 RID: 9237 RVA: 0x00089D80 File Offset: 0x00087F80
	internal void InitializeClientToServer()
	{
		global::RustProto.Avatar objB = this.LoadAvatar();
		global::ServerManagement.Get().UpdateConnectingUserAvatar(this, ref this.avatar);
		if (!object.ReferenceEquals(this.avatar, objB))
		{
			this.SaveAvatar();
		}
		global::Character character = global::ServerManagement.Get().SpawnPlayer(this.playerClient, false, this.avatar);
		if (character)
		{
			this.did_join = true;
		}
	}

	// Token: 0x06002416 RID: 9238 RVA: 0x00089DE8 File Offset: 0x00087FE8
	private void SaveAvatar()
	{
		if (object.ReferenceEquals(this.avatar, null))
		{
			this.avatar = global::ClusterServer.LoadAvatar(this.userID);
		}
		else
		{
			global::ClusterServer.SaveAvatar(this.userID, ref this.avatar);
		}
	}

	// Token: 0x06002417 RID: 9239 RVA: 0x00089E30 File Offset: 0x00088030
	public void SaveAvatar(global::RustProto.Avatar new_avatar)
	{
		if (object.ReferenceEquals(new_avatar, this.avatar) || object.ReferenceEquals(new_avatar, null))
		{
			return;
		}
		this.avatar = new_avatar;
		this.SaveAvatar();
	}

	// Token: 0x06002418 RID: 9240 RVA: 0x00089E60 File Offset: 0x00088060
	public global::RustProto.Avatar LoadAvatar()
	{
		global::RustProto.Avatar result;
		if ((result = this.avatar) == null)
		{
			result = (this.avatar = global::ClusterServer.LoadAvatar(this.userID));
		}
		return result;
	}

	// Token: 0x06002419 RID: 9241 RVA: 0x00089E90 File Offset: 0x00088090
	public static void SaveAvatar(ulong userID, ref global::RustProto.Avatar new_avatar)
	{
		global::NetUser netUser;
		if (global::NetUser.Find(userID, out netUser))
		{
			netUser.SaveAvatar(new_avatar);
		}
		else
		{
			global::ClusterServer.SaveAvatar(userID, ref new_avatar);
		}
	}

	// Token: 0x0600241A RID: 9242 RVA: 0x00089EC0 File Offset: 0x000880C0
	public static global::RustProto.Avatar LoadAvatar(ulong userID)
	{
		global::NetUser netUser;
		if (global::NetUser.Find(userID, out netUser))
		{
			return netUser.LoadAvatar();
		}
		return global::ClusterServer.LoadAvatar(userID);
	}

	// Token: 0x0600241B RID: 9243 RVA: 0x00089EE8 File Offset: 0x000880E8
	public bool CanChat()
	{
		return global::UnityEngine.Time.time - this.fLastChat > 1f;
	}

	// Token: 0x0600241C RID: 9244 RVA: 0x00089F00 File Offset: 0x00088100
	public void NoteChatted()
	{
		this.fLastChat = global::UnityEngine.Time.time;
	}

	// Token: 0x040011EA RID: 4586
	private bool droppingPackets;

	// Token: 0x040011EB RID: 4587
	private int droppingCountUnFixed;

	// Token: 0x040011EC RID: 4588
	private global::ServerDuration droppingPacketsVerifyTime;

	// Token: 0x040011ED RID: 4589
	public readonly global::uLink.NetworkPlayer networkPlayer = global::uLink.NetworkPlayer.unassigned;

	// Token: 0x040011EE RID: 4590
	public readonly global::RustProto.User user;

	// Token: 0x040011EF RID: 4591
	private global::RustProto.Avatar avatar;

	// Token: 0x040011F0 RID: 4592
	public bool admin;

	// Token: 0x040011F1 RID: 4593
	private bool did_connect;

	// Token: 0x040011F2 RID: 4594
	private bool did_disconnect;

	// Token: 0x040011F3 RID: 4595
	private bool did_dispose;

	// Token: 0x040011F4 RID: 4596
	private bool did_join;

	// Token: 0x040011F5 RID: 4597
	internal bool simulatedDisconnect;

	// Token: 0x040011F6 RID: 4598
	internal global::PlayerCullInfo cullinfo;

	// Token: 0x040011F7 RID: 4599
	public global::PlayerClient playerClient;

	// Token: 0x040011F8 RID: 4600
	public readonly global::TruthDetector truthDetector;

	// Token: 0x040011F9 RID: 4601
	public global::ClientConnection connection;

	// Token: 0x040011FA RID: 4602
	public int connectTime;

	// Token: 0x040011FB RID: 4603
	private float fLastChat;

	// Token: 0x0200040C RID: 1036
	private static class DropUtil
	{
		// Token: 0x0600241D RID: 9245 RVA: 0x00089F10 File Offset: 0x00088110
		// Note: this type is marked as 'beforefieldinit'.
		static DropUtil()
		{
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x00089F28 File Offset: 0x00088128
		public static void AddUnfinal(global::NetUser user)
		{
			((!global::NetUser.DropUtil.swap) ? global::NetUser.DropUtil.set1 : global::NetUser.DropUtil.set2).Add(user);
			global::NetUser.DropUtil.any = true;
		}

		// Token: 0x0600241F RID: 9247 RVA: 0x00089F5C File Offset: 0x0008815C
		public static void Cycle()
		{
			if (!global::NetUser.DropUtil.any)
			{
				return;
			}
			global::NetUser.DropUtil.any = false;
			global::NetUser.DropUtil.swap = !global::NetUser.DropUtil.swap;
			global::System.Collections.Generic.HashSet<global::NetUser> hashSet = (!global::NetUser.DropUtil.swap) ? global::NetUser.DropUtil.set2 : global::NetUser.DropUtil.set1;
			try
			{
				foreach (global::NetUser netUser in hashSet)
				{
					if (!netUser.did_dispose && netUser.droppingPackets && !netUser.droppingPacketsVerifyTime.final)
					{
						ulong num = 0UL;
						if (global::packet.loglevel > 3)
						{
							num = netUser.droppingPacketsVerifyTime.endTime;
						}
						netUser.droppingPacketsVerifyTime.MakeFinal();
						if (global::packet.loglevel > 3)
						{
							ulong endTime = netUser.droppingPacketsVerifyTime.endTime;
							if (endTime > num)
							{
								global::UnityEngine.Debug.Log(string.Concat(new object[]
								{
									"packetdrop: added server overhead to ",
									netUser,
									" of ",
									endTime - num,
									"ms"
								}));
							}
						}
					}
				}
			}
			finally
			{
				hashSet.Clear();
			}
		}

		// Token: 0x040011FC RID: 4604
		private static readonly global::System.Collections.Generic.HashSet<global::NetUser> set1 = new global::System.Collections.Generic.HashSet<global::NetUser>();

		// Token: 0x040011FD RID: 4605
		private static readonly global::System.Collections.Generic.HashSet<global::NetUser> set2 = new global::System.Collections.Generic.HashSet<global::NetUser>();

		// Token: 0x040011FE RID: 4606
		private static bool swap;

		// Token: 0x040011FF RID: 4607
		private static bool any;
	}

	// Token: 0x0200040D RID: 1037
	private static class Registry
	{
		// Token: 0x06002420 RID: 9248 RVA: 0x0008A0BC File Offset: 0x000882BC
		// Note: this type is marked as 'beforefieldinit'.
		static Registry()
		{
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x0008A0F0 File Offset: 0x000882F0
		public static bool FindLoadedUserWithID(ulong id, out global::NetUser user)
		{
			return global::NetUser.Registry.loadedUsers.TryGetValue(id, out user);
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x0008A100 File Offset: 0x00088300
		public static global::NetUser FindUserID(ulong iUserID)
		{
			global::NetUser netUser;
			return (!global::NetUser.Registry.FindLoadedUserWithID(iUserID, out netUser)) ? null : netUser;
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x0008A124 File Offset: 0x00088324
		public static bool Add(global::NetUser user)
		{
			ulong userid = user.user.Userid;
			global::NetUser objA;
			if (global::NetUser.Registry.loadedUsers.TryGetValue(userid, out objA))
			{
				if (object.ReferenceEquals(objA, user))
				{
					return false;
				}
				global::UnityEngine.Debug.LogWarning("Emergency drop of user because of reconnect on same id");
				global::UnityEngine.Debug.LogWarning("If this has happened something has seriously gone wrong.");
				global::UnityEngine.Debug.LogWarning("Please contact Garry");
			}
			global::NetUser.Registry.loadedUsers.Add(userid, user);
			return true;
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x0008A190 File Offset: 0x00088390
		public static bool Remove(global::NetUser user)
		{
			ulong userid = user.user.Userid;
			global::NetUser objA;
			if (global::NetUser.Registry.loadedUsers.TryGetValue(userid, out objA) && object.ReferenceEquals(objA, user) && global::NetUser.Registry.loadedUsers.Remove(userid))
			{
				global::NetUser.Registry.WeakList weakList;
				if (!global::NetUser.Registry.unloadedUsers.TryGetValue(userid, out weakList))
				{
					weakList = new global::NetUser.Registry.WeakList(4);
					global::NetUser.Registry.unloadedUsers[userid] = weakList;
					global::NetUser.Registry.unloaded.Add(weakList);
				}
				weakList.Add(new global::System.WeakReference(user));
				global::NetUser.Registry.countUnloaded++;
				return true;
			}
			return false;
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x0008A224 File Offset: 0x00088424
		public static int CountUnloaded()
		{
			if (global::NetUser.Registry.countUnloaded > 0)
			{
				int count = global::NetUser.Registry.unloaded.Count;
				for (int i = count - 1; i >= 0; i--)
				{
					global::NetUser.Registry.WeakList weakList = global::NetUser.Registry.unloaded[i];
					int count2 = weakList.Count;
					for (int j = 0; j < count2; j++)
					{
						if (!weakList[j].IsAlive)
						{
							int num = j;
							while (++j < count2)
							{
								if (weakList[j].IsAlive)
								{
									weakList[num++] = weakList[j];
								}
							}
							int num2 = count2 - num;
							if (num > 0)
							{
								if (num2 == 1)
								{
									weakList.RemoveAt(num);
								}
								else
								{
									weakList.RemoveRange(num, num2);
								}
							}
							else
							{
								global::NetUser.Registry.unloaded.RemoveAt(i);
								global::NetUser.Registry.unloadedUsers.Remove(weakList.UserID);
							}
							global::NetUser.Registry.countUnloaded -= num2;
						}
					}
				}
			}
			return global::NetUser.Registry.countUnloaded;
		}

		// Token: 0x04001200 RID: 4608
		private static readonly global::System.Collections.Generic.Dictionary<ulong, global::NetUser> loadedUsers = new global::System.Collections.Generic.Dictionary<ulong, global::NetUser>();

		// Token: 0x04001201 RID: 4609
		private static readonly global::System.Collections.Generic.Dictionary<ulong, global::NetUser.Registry.WeakList> unloadedUsers = new global::System.Collections.Generic.Dictionary<ulong, global::NetUser.Registry.WeakList>();

		// Token: 0x04001202 RID: 4610
		private static readonly global::System.Collections.Generic.List<global::NetUser.Registry.WeakList> unloaded = new global::System.Collections.Generic.List<global::NetUser.Registry.WeakList>();

		// Token: 0x04001203 RID: 4611
		private static int countUnloaded = 0;

		// Token: 0x0200040E RID: 1038
		private class WeakList : global::System.Collections.Generic.List<global::System.WeakReference>
		{
			// Token: 0x06002426 RID: 9254 RVA: 0x0008A334 File Offset: 0x00088534
			public WeakList(int cap) : base(cap)
			{
			}

			// Token: 0x04001204 RID: 4612
			public readonly ulong UserID;
		}
	}
}
