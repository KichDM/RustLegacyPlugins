using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Facepunch.Utility;
using LitJson;
using Rust;
using Rust.Steam;
using uLink;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class ClientConnection
{
	// Token: 0x06001AF7 RID: 6903 RVA: 0x0006A8B0 File Offset: 0x00068AB0
	public ClientConnection()
	{
	}

	// Token: 0x06001AF8 RID: 6904 RVA: 0x0006A8D0 File Offset: 0x00068AD0
	public bool ReadConnectionData(global::uLink.BitStream stream)
	{
		try
		{
			this.Protocol = stream.ReadInt32();
			this.ConnectionMode = (int)stream.ReadByte();
			if (this.ConnectionMode != 2)
			{
				return false;
			}
			this.UserID = stream.ReadUInt64();
			this.UserName = stream.ReadString();
			this.SteamTicket = stream.ReadBytes();
		}
		catch (global::System.Exception ex)
		{
			return false;
		}
		return true;
	}

	// Token: 0x06001AF9 RID: 6905 RVA: 0x0006A964 File Offset: 0x00068B64
	public global::System.Collections.IEnumerator AuthorisationRoutine(global::uLink.NetworkPlayerApproval approval)
	{
		if (this.ConnectionMode == 2)
		{
			global::System.Collections.IEnumerator e = this.DoSteamAuthorisation(approval);
			while (e.MoveNext())
			{
				object obj = e.Current;
				yield return obj;
			}
			if (approval.status == 3)
			{
				yield break;
			}
		}
		if (global::Rust.Steam.Server.Official || global::Facepunch.Utility.CommandLine.HasSwitch("-cheatpunch"))
		{
			global::System.Collections.IEnumerator e2 = this.DoUserPersistence(approval);
			while (e2.MoveNext())
			{
				object obj2 = e2.Current;
				yield return obj2;
			}
			if (approval.status == 3)
			{
				yield break;
			}
		}
		if (global::Rust.Steam.Server.SteamGroup > 0UL)
		{
			global::System.Collections.IEnumerator e3 = this.DoSteamGroupTest(approval, global::Rust.Steam.Server.SteamGroup);
			while (e3.MoveNext())
			{
				object obj3 = e3.Current;
				yield return obj3;
			}
			if (approval.status == 3)
			{
				yield break;
			}
		}
		global::uLink.BitStream bs = new global::uLink.BitStream(false);
		bs.WriteString(global::Rust.Globals.currentLevel);
		bs.WriteSingle(global::NetCull.sendRate);
		bs.WriteString(global::server.hostname);
		bs.WriteBoolean(global::Rust.Steam.Server.Modded);
		bs.WriteBoolean(global::Rust.Steam.Server.Official);
		bs.WriteUInt64(global::Rust.Steam.Server.SteamID);
		bs.WriteUInt32(global::Rust.Steam.Server.IPAddress);
		bs.WriteInt32(global::server.port);
		approval.localData = this;
		approval.Approve(new object[]
		{
			bs.GetDataByteArray()
		});
		yield break;
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x0006A990 File Offset: 0x00068B90
	public global::System.Collections.IEnumerator DoSteamAuthorisation(global::uLink.NetworkPlayerApproval approval)
	{
		this.AuthStatus = string.Empty;
		if (!global::Rust.Steam.Server.StartUserAuth(this.UserID, this.SteamTicket))
		{
			this.DenyAccess(approval, "Steam auth denied user", global::NetError.Facepunch_Connector_Cancelled);
			yield break;
		}
		for (int i = 0; i < 0xA; i++)
		{
			if (this.AuthStatus.Length > 0)
			{
				break;
			}
			yield return new global::UnityEngine.WaitForSeconds(1f);
		}
		if (this.AuthStatus.Length == 0)
		{
			this.DenyAccess(approval, "Steam auth timed out", global::NetError.Facepunch_Connector_AuthTimeout);
			yield break;
		}
		if (this.AuthStatus != "ok")
		{
			global::ConsoleSystem.Print(string.Concat(new string[]
			{
				"Auth failed: Steam auth responded with '",
				this.AuthStatus,
				"' - ",
				this.UserName,
				" (",
				this.UserID.ToString(),
				")"
			}), false);
			if (this.AuthStatus == "vac")
			{
				approval.Deny(0x9A);
			}
			else if (this.AuthStatus == "cancelled")
			{
				approval.Deny(0x96);
			}
			else if (this.AuthStatus == "old")
			{
				approval.Deny(0x9C);
			}
			else if (this.AuthStatus == "expired")
			{
				approval.Deny(0x9F);
			}
			else if (this.AuthStatus == "invalid")
			{
				approval.Deny(0x9E);
			}
			else if (this.AuthStatus == "noconnect")
			{
				approval.Deny(0x9D);
			}
			else if (this.AuthStatus == "loggedin")
			{
				approval.Deny(0xA0);
			}
			else
			{
				approval.Deny(0x95);
			}
			global::ConnectionAcceptor.CloseConnection(this);
			global::Rust.Steam.Server.OnUserLeave(this.UserID);
			yield break;
		}
		yield break;
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x0006A9BC File Offset: 0x00068BBC
	public global::System.Collections.IEnumerator DoUserPersistence(global::uLink.NetworkPlayerApproval approval)
	{
		global::UnityEngine.WWWForm form = new global::UnityEngine.WWWForm();
		form.AddField("userid", this.UserID.ToString());
		global::UnityEngine.WWW request = new global::UnityEngine.WWW("http://api.playrust.com/user/info/", form);
		yield return request;
		if (!string.IsNullOrEmpty(request.error))
		{
			this.DenyAccess(approval, "got an error response from api", global::NetError.Facepunch_API_Failure);
			yield break;
		}
		if (string.IsNullOrEmpty(request.text))
		{
			this.DenyAccess(approval, "got a empty response from api", global::NetError.Facepunch_API_Failure);
			yield break;
		}
		string user_status = string.Empty;
		string ban_reason = string.Empty;
		try
		{
			global::LitJson.JsonData json = global::LitJson.JsonMapper.ToObject(request.text);
			string status = (string)json["status"];
			if (status != "ok")
			{
				throw new global::System.Exception("status is '" + status + "'");
			}
			global::LitJson.JsonData data = json["data"];
			user_status = (string)data["status"];
			if (user_status == "banned")
			{
				ban_reason = (string)data["ban_reason"];
			}
		}
		catch (global::System.Exception ex)
		{
			global::System.Exception e = ex;
			this.DenyAccess(approval, "Invalid JSON response from API (" + e.Message + ")", global::NetError.Facepunch_API_Failure);
			yield break;
		}
		if (user_status == "banned")
		{
			this.DenyAccess(approval, "User is banned by API [" + ban_reason + "]", global::NetError.Facepunch_Kick_Ban);
			yield break;
		}
		yield break;
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x0006A9E8 File Offset: 0x00068BE8
	public global::System.Collections.IEnumerator DoSteamGroupTest(global::uLink.NetworkPlayerApproval approval, ulong groupid)
	{
		if (!global::Rust.Steam.Server.SteamServer_UserGroupStatus(this.UserID, groupid))
		{
			this.DenyAccess(approval, "Couldn't check whether user is in Steam Group!", global::NetError.Facepunch_Whitelist_Failure);
			yield break;
		}
		yield return new global::UnityEngine.WaitForSeconds(0.3f);
		for (int i = 0; i < 0xA; i++)
		{
			if (this.steamGroupID == groupid)
			{
				break;
			}
			yield return new global::UnityEngine.WaitForSeconds(1f);
		}
		if (this.steamGroupID != groupid)
		{
			this.DenyAccess(approval, "Couldn't check whether user is in Steam Group (timeout)", global::NetError.Facepunch_Whitelist_Failure);
			yield break;
		}
		if (this.steamGroupStatus == "member")
		{
			yield break;
		}
		if (this.steamGroupStatus == "officer")
		{
			yield break;
		}
		this.DenyAccess(approval, "not in whitelist", global::NetError.Facepunch_Whitelist_Failure);
		yield break;
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x0006AA20 File Offset: 0x00068C20
	public void DenyAccess(global::uLink.NetworkPlayerApproval approval, string strReason, global::NetError errornum)
	{
		global::ConsoleSystem.Print(string.Concat(new string[]
		{
			"Auth failed: ",
			strReason,
			" - ",
			this.UserName,
			" (",
			this.UserID.ToString(),
			")"
		}), false);
		approval.Deny(errornum);
		global::ConnectionAcceptor.CloseConnection(this);
		global::Rust.Steam.Server.OnUserLeave(this.UserID);
	}

	// Token: 0x04000FAB RID: 4011
	public int Protocol;

	// Token: 0x04000FAC RID: 4012
	public int ConnectionMode;

	// Token: 0x04000FAD RID: 4013
	public ulong UserID;

	// Token: 0x04000FAE RID: 4014
	public string UserName;

	// Token: 0x04000FAF RID: 4015
	public byte[] SteamTicket;

	// Token: 0x04000FB0 RID: 4016
	public string AuthStatus = string.Empty;

	// Token: 0x04000FB1 RID: 4017
	public ulong steamGroupID;

	// Token: 0x04000FB2 RID: 4018
	public string steamGroupStatus = string.Empty;

	// Token: 0x04000FB3 RID: 4019
	public global::uLink.NetworkPlayerApproval playerApproval;

	// Token: 0x04000FB4 RID: 4020
	public global::NetUser netUser;

	// Token: 0x02000322 RID: 802
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <AuthorisationRoutine>c__Iterator32 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06001AFE RID: 6910 RVA: 0x0006AA94 File Offset: 0x00068C94
		public <AuthorisationRoutine>c__Iterator32()
		{
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06001AFF RID: 6911 RVA: 0x0006AA9C File Offset: 0x00068C9C
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06001B00 RID: 6912 RVA: 0x0006AAA4 File Offset: 0x00068CA4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x0006AAAC File Offset: 0x00068CAC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (this.ConnectionMode != 2)
				{
					goto IL_99;
				}
				e = base.DoSteamAuthorisation(approval);
				break;
			case 1U:
				break;
			case 2U:
				IL_EB:
				if (e2.MoveNext())
				{
					this.$current = e2.Current;
					this.$PC = 2;
					return true;
				}
				if (approval.status == 3)
				{
					return false;
				}
				goto IL_111;
			case 3U:
				IL_15B:
				if (e3.MoveNext())
				{
					this.$current = e3.Current;
					this.$PC = 3;
					return true;
				}
				if (approval.status == 3)
				{
					return false;
				}
				goto IL_181;
			default:
				return false;
			}
			if (e.MoveNext())
			{
				this.$current = e.Current;
				this.$PC = 1;
				return true;
			}
			if (approval.status == 3)
			{
				return false;
			}
			IL_99:
			if (global::Rust.Steam.Server.Official || global::Facepunch.Utility.CommandLine.HasSwitch("-cheatpunch"))
			{
				e2 = base.DoUserPersistence(approval);
				goto IL_EB;
			}
			IL_111:
			if (global::Rust.Steam.Server.SteamGroup > 0UL)
			{
				e3 = base.DoSteamGroupTest(approval, global::Rust.Steam.Server.SteamGroup);
				goto IL_15B;
			}
			IL_181:
			bs = new global::uLink.BitStream(false);
			bs.WriteString(global::Rust.Globals.currentLevel);
			bs.WriteSingle(global::NetCull.sendRate);
			bs.WriteString(global::server.hostname);
			bs.WriteBoolean(global::Rust.Steam.Server.Modded);
			bs.WriteBoolean(global::Rust.Steam.Server.Official);
			bs.WriteUInt64(global::Rust.Steam.Server.SteamID);
			bs.WriteUInt32(global::Rust.Steam.Server.IPAddress);
			bs.WriteInt32(global::server.port);
			approval.localData = this;
			approval.Approve(new object[]
			{
				bs.GetDataByteArray()
			});
			this.$PC = -1;
			return false;
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x0006AD04 File Offset: 0x00068F04
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x0006AD10 File Offset: 0x00068F10
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000FB5 RID: 4021
		internal global::uLink.NetworkPlayerApproval approval;

		// Token: 0x04000FB6 RID: 4022
		internal global::System.Collections.IEnumerator <e>__0;

		// Token: 0x04000FB7 RID: 4023
		internal global::System.Collections.IEnumerator <e>__1;

		// Token: 0x04000FB8 RID: 4024
		internal global::System.Collections.IEnumerator <e>__2;

		// Token: 0x04000FB9 RID: 4025
		internal global::uLink.BitStream <bs>__3;

		// Token: 0x04000FBA RID: 4026
		internal int $PC;

		// Token: 0x04000FBB RID: 4027
		internal object $current;

		// Token: 0x04000FBC RID: 4028
		internal global::uLink.NetworkPlayerApproval <$>approval;

		// Token: 0x04000FBD RID: 4029
		internal global::ClientConnection <>f__this;
	}

	// Token: 0x02000323 RID: 803
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoSteamAuthorisation>c__Iterator33 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06001B04 RID: 6916 RVA: 0x0006AD18 File Offset: 0x00068F18
		public <DoSteamAuthorisation>c__Iterator33()
		{
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06001B05 RID: 6917 RVA: 0x0006AD20 File Offset: 0x00068F20
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06001B06 RID: 6918 RVA: 0x0006AD28 File Offset: 0x00068F28
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x0006AD30 File Offset: 0x00068F30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.AuthStatus = string.Empty;
				if (!global::Rust.Steam.Server.StartUserAuth(this.UserID, this.SteamTicket))
				{
					base.DenyAccess(approval, "Steam auth denied user", global::NetError.Facepunch_Connector_Cancelled);
					return false;
				}
				i = 0;
				break;
			case 1U:
				i++;
				break;
			default:
				return false;
			}
			if (i < 0xA)
			{
				if (this.AuthStatus.Length <= 0)
				{
					this.$current = new global::UnityEngine.WaitForSeconds(1f);
					this.$PC = 1;
					return true;
				}
			}
			if (this.AuthStatus.Length == 0)
			{
				base.DenyAccess(approval, "Steam auth timed out", global::NetError.Facepunch_Connector_AuthTimeout);
			}
			else if (this.AuthStatus != "ok")
			{
				global::ConsoleSystem.Print(string.Concat(new string[]
				{
					"Auth failed: Steam auth responded with '",
					this.AuthStatus,
					"' - ",
					this.UserName,
					" (",
					this.UserID.ToString(),
					")"
				}), false);
				if (this.AuthStatus == "vac")
				{
					approval.Deny(0x9A);
				}
				else if (this.AuthStatus == "cancelled")
				{
					approval.Deny(0x96);
				}
				else if (this.AuthStatus == "old")
				{
					approval.Deny(0x9C);
				}
				else if (this.AuthStatus == "expired")
				{
					approval.Deny(0x9F);
				}
				else if (this.AuthStatus == "invalid")
				{
					approval.Deny(0x9E);
				}
				else if (this.AuthStatus == "noconnect")
				{
					approval.Deny(0x9D);
				}
				else if (this.AuthStatus == "loggedin")
				{
					approval.Deny(0xA0);
				}
				else
				{
					approval.Deny(0x95);
				}
				global::ConnectionAcceptor.CloseConnection(this);
				global::Rust.Steam.Server.OnUserLeave(this.UserID);
			}
			else
			{
				this.$PC = -1;
			}
			return false;
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x0006B040 File Offset: 0x00069240
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x0006B04C File Offset: 0x0006924C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000FBE RID: 4030
		internal global::uLink.NetworkPlayerApproval approval;

		// Token: 0x04000FBF RID: 4031
		internal int <i>__0;

		// Token: 0x04000FC0 RID: 4032
		internal int $PC;

		// Token: 0x04000FC1 RID: 4033
		internal object $current;

		// Token: 0x04000FC2 RID: 4034
		internal global::uLink.NetworkPlayerApproval <$>approval;

		// Token: 0x04000FC3 RID: 4035
		internal global::ClientConnection <>f__this;
	}

	// Token: 0x02000324 RID: 804
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoUserPersistence>c__Iterator34 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06001B0A RID: 6922 RVA: 0x0006B054 File Offset: 0x00069254
		public <DoUserPersistence>c__Iterator34()
		{
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06001B0B RID: 6923 RVA: 0x0006B05C File Offset: 0x0006925C
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06001B0C RID: 6924 RVA: 0x0006B064 File Offset: 0x00069264
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x0006B06C File Offset: 0x0006926C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				form = new global::UnityEngine.WWWForm();
				form.AddField("userid", this.UserID.ToString());
				request = new global::UnityEngine.WWW("http://api.playrust.com/user/info/", form);
				this.$current = request;
				this.$PC = 1;
				return true;
			case 1U:
				if (!string.IsNullOrEmpty(request.error))
				{
					base.DenyAccess(approval, "got an error response from api", global::NetError.Facepunch_API_Failure);
				}
				else if (string.IsNullOrEmpty(request.text))
				{
					base.DenyAccess(approval, "got a empty response from api", global::NetError.Facepunch_API_Failure);
				}
				else
				{
					user_status = string.Empty;
					ban_reason = string.Empty;
					try
					{
						json = global::LitJson.JsonMapper.ToObject(request.text);
						status = (string)json["status"];
						if (status != "ok")
						{
							throw new global::System.Exception("status is '" + status + "'");
						}
						data = json["data"];
						user_status = (string)data["status"];
						if (user_status == "banned")
						{
							ban_reason = (string)data["ban_reason"];
						}
					}
					catch (global::System.Exception ex)
					{
						e = ex;
						base.DenyAccess(approval, "Invalid JSON response from API (" + e.Message + ")", global::NetError.Facepunch_API_Failure);
						break;
					}
					if (user_status == "banned")
					{
						base.DenyAccess(approval, "User is banned by API [" + ban_reason + "]", global::NetError.Facepunch_Kick_Ban);
					}
					else
					{
						this.$PC = -1;
					}
				}
				break;
			}
			return false;
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x0006B2EC File Offset: 0x000694EC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x0006B2F8 File Offset: 0x000694F8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000FC4 RID: 4036
		internal global::UnityEngine.WWWForm <form>__0;

		// Token: 0x04000FC5 RID: 4037
		internal global::UnityEngine.WWW <request>__1;

		// Token: 0x04000FC6 RID: 4038
		internal global::uLink.NetworkPlayerApproval approval;

		// Token: 0x04000FC7 RID: 4039
		internal string <user_status>__2;

		// Token: 0x04000FC8 RID: 4040
		internal string <ban_reason>__3;

		// Token: 0x04000FC9 RID: 4041
		internal global::LitJson.JsonData <json>__4;

		// Token: 0x04000FCA RID: 4042
		internal string <status>__5;

		// Token: 0x04000FCB RID: 4043
		internal global::LitJson.JsonData <data>__6;

		// Token: 0x04000FCC RID: 4044
		internal global::System.Exception <e>__7;

		// Token: 0x04000FCD RID: 4045
		internal int $PC;

		// Token: 0x04000FCE RID: 4046
		internal object $current;

		// Token: 0x04000FCF RID: 4047
		internal global::uLink.NetworkPlayerApproval <$>approval;

		// Token: 0x04000FD0 RID: 4048
		internal global::ClientConnection <>f__this;
	}

	// Token: 0x02000325 RID: 805
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoSteamGroupTest>c__Iterator35 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06001B10 RID: 6928 RVA: 0x0006B300 File Offset: 0x00069500
		public <DoSteamGroupTest>c__Iterator35()
		{
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06001B11 RID: 6929 RVA: 0x0006B308 File Offset: 0x00069508
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06001B12 RID: 6930 RVA: 0x0006B310 File Offset: 0x00069510
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x0006B318 File Offset: 0x00069518
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (!global::Rust.Steam.Server.SteamServer_UserGroupStatus(this.UserID, groupid))
				{
					base.DenyAccess(approval, "Couldn't check whether user is in Steam Group!", global::NetError.Facepunch_Whitelist_Failure);
					return false;
				}
				this.$current = new global::UnityEngine.WaitForSeconds(0.3f);
				this.$PC = 1;
				return true;
			case 1U:
				i = 0;
				break;
			case 2U:
				i++;
				break;
			default:
				return false;
			}
			if (i < 0xA)
			{
				if (this.steamGroupID != groupid)
				{
					this.$current = new global::UnityEngine.WaitForSeconds(1f);
					this.$PC = 2;
					return true;
				}
			}
			if (this.steamGroupID != groupid)
			{
				base.DenyAccess(approval, "Couldn't check whether user is in Steam Group (timeout)", global::NetError.Facepunch_Whitelist_Failure);
			}
			else if (!(this.steamGroupStatus == "member"))
			{
				if (!(this.steamGroupStatus == "officer"))
				{
					base.DenyAccess(approval, "not in whitelist", global::NetError.Facepunch_Whitelist_Failure);
				}
			}
			return false;
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x0006B4A0 File Offset: 0x000696A0
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x0006B4AC File Offset: 0x000696AC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000FD1 RID: 4049
		internal ulong groupid;

		// Token: 0x04000FD2 RID: 4050
		internal global::uLink.NetworkPlayerApproval approval;

		// Token: 0x04000FD3 RID: 4051
		internal int <i>__0;

		// Token: 0x04000FD4 RID: 4052
		internal int $PC;

		// Token: 0x04000FD5 RID: 4053
		internal object $current;

		// Token: 0x04000FD6 RID: 4054
		internal ulong <$>groupid;

		// Token: 0x04000FD7 RID: 4055
		internal global::uLink.NetworkPlayerApproval <$>approval;

		// Token: 0x04000FD8 RID: 4056
		internal global::ClientConnection <>f__this;
	}
}
