using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Rust.Steam
{
	// Token: 0x02000267 RID: 615
	public static class Server
	{
		// Token: 0x06001583 RID: 5507 RVA: 0x00048B30 File Offset: 0x00046D30
		// Note: this type is marked as 'beforefieldinit'.
		static Server()
		{
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x00048B34 File Offset: 0x00046D34
		public static void Init()
		{
			if (!global::Rust.Steam.Server.Steam_ServerStartup(global::NetCull.listenPort, 0x42D))
			{
				global::UnityEngine.Application.Quit();
				return;
			}
			global::Rust.Steam.Server.funcUserAuth funcUserAuth = new global::Rust.Steam.Server.funcUserAuth(global::Rust.Steam.Server.OnUserAuth);
			global::Rust.Steam.Server.UserAuthGC = global::System.Runtime.InteropServices.GCHandle.Alloc(funcUserAuth);
			global::Rust.Steam.Server.SteamServer_SetCallback_UserAuth(funcUserAuth);
			global::Rust.Steam.Server.funcUserGroup funcUserGroup = new global::Rust.Steam.Server.funcUserGroup(global::Rust.Steam.Server.OnUserGroup);
			global::Rust.Steam.Server.UserGroupGC = global::System.Runtime.InteropServices.GCHandle.Alloc(funcUserGroup);
			global::Rust.Steam.Server.SteamServer_SetCallback_UserGroup(funcUserGroup);
			global::Rust.Steam.Server.SteamID = global::Rust.Steam.Server.SteamServer_GetSteamID();
			global::Rust.Steam.Server.IPAddress = global::Rust.Steam.Server.SteamServer_GetPublicIP();
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x00048BAC File Offset: 0x00046DAC
		public static void Shutdown()
		{
			global::Rust.Steam.Server.Steam_ServerShutdown();
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x00048BB4 File Offset: 0x00046DB4
		public static void OnUserAuth(ulong iUserID, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string strStatus)
		{
			global::ConnectionAcceptor.OnSteamAuthorization(iUserID, strStatus);
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x00048BC0 File Offset: 0x00046DC0
		public static void OnUserGroup(ulong iUserID, ulong iGroupID, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string strStatus)
		{
			global::ConnectionAcceptor.OnSteamOnUserGroup(iUserID, iGroupID, strStatus);
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x00048BCC File Offset: 0x00046DCC
		public unsafe static bool StartUserAuth(ulong iUserID, byte[] data)
		{
			fixed (byte* value = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				global::System.IntPtr pData = (global::System.IntPtr)((void*)value);
				global::System.IntPtr ptr = global::Rust.Steam.Server.SteamServer_BeginAuthSession(pData, data.Length, iUserID);
				string text = global::System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr);
				if (text == "ok")
				{
					return true;
				}
				global::UnityEngine.Debug.Log("Auth Error: " + text);
			}
			return false;
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x00048C38 File Offset: 0x00046E38
		public static void OnUserLeave(ulong iUserID)
		{
			global::Rust.Steam.Server.SteamServer_UserLeave(iUserID);
			global::Rust.Steam.Server.OnPlayerCountChanged();
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x00048C48 File Offset: 0x00046E48
		public static void UpdateServerTitle()
		{
			string hostname = global::server.hostname;
			global::Rust.Steam.Server.SetTitleOfConsole(global::NetCull.connections.Length.ToString() + " | " + hostname);
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x00048C7C File Offset: 0x00046E7C
		public static void OnPlayerCountChanged()
		{
			global::Rust.Steam.Server.Steam_UpdateServer(global::NetCull.maxConnections, global::NetCull.connections.Length, global::server.hostname, global::server.map, global::Rust.Steam.Server.GetTags());
			global::Rust.Steam.Server.UpdateServerTitle();
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x00048CB0 File Offset: 0x00046EB0
		public static string GetTags()
		{
			string text = "rust";
			if (global::Rust.Steam.Server.Modded)
			{
				text += ",modded";
			}
			if (global::Rust.Steam.Server.Official)
			{
				text += ",official";
			}
			if (global::Rust.Steam.Server.SteamGroup != 0UL)
			{
				text = text + ",sg:" + global::Rust.Steam.Server.SteamGroup.ToString("X");
			}
			return text;
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x00048D18 File Offset: 0x00046F18
		public static void SetModded()
		{
			global::Rust.Steam.Server.Modded = true;
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x00048D20 File Offset: 0x00046F20
		public static void SetOfficial()
		{
			global::Rust.Steam.Server.Official = true;
		}

		// Token: 0x0600158F RID: 5519
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern global::System.IntPtr SteamServer_BeginAuthSession(global::System.IntPtr pData, int iDataSize, ulong iUserID);

		// Token: 0x06001590 RID: 5520
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern bool SteamServer_UserGroupStatus(ulong iUserID, ulong iGroupID);

		// Token: 0x06001591 RID: 5521
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern void SteamServer_UserLeave(ulong iUserID);

		// Token: 0x06001592 RID: 5522
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern void SteamServer_SetCallback_UserAuth(global::Rust.Steam.Server.funcUserAuth fnc);

		// Token: 0x06001593 RID: 5523
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern void SteamServer_SetCallback_UserGroup(global::Rust.Steam.Server.funcUserGroup fnc);

		// Token: 0x06001594 RID: 5524
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern bool Steam_ServerStartup(int port, int protocol);

		// Token: 0x06001595 RID: 5525
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern void Steam_ServerShutdown();

		// Token: 0x06001596 RID: 5526
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern void SetTitleOfConsole(string log);

		// Token: 0x06001597 RID: 5527
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern void Steam_UpdateServer(int maxplayers, int icurrentplayers, string strServerName, string strMapName, string strTags);

		// Token: 0x06001598 RID: 5528
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern ulong SteamServer_GetSteamID();

		// Token: 0x06001599 RID: 5529
		[global::System.Runtime.InteropServices.DllImport("librust")]
		public static extern uint SteamServer_GetPublicIP();

		// Token: 0x04000B43 RID: 2883
		public static global::System.Runtime.InteropServices.GCHandle UserAuthGC;

		// Token: 0x04000B44 RID: 2884
		public static global::System.Runtime.InteropServices.GCHandle UserGroupGC;

		// Token: 0x04000B45 RID: 2885
		public static bool Modded;

		// Token: 0x04000B46 RID: 2886
		public static bool Official;

		// Token: 0x04000B47 RID: 2887
		public static ulong SteamID;

		// Token: 0x04000B48 RID: 2888
		public static uint IPAddress;

		// Token: 0x04000B49 RID: 2889
		public static ulong SteamGroup;

		// Token: 0x02000268 RID: 616
		// (Invoke) Token: 0x0600159B RID: 5531
		public delegate void funcUserAuth(ulong iUserID, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string strStatus);

		// Token: 0x02000269 RID: 617
		// (Invoke) Token: 0x0600159F RID: 5535
		public delegate void funcUserGroup(ulong iUserID, ulong iGroupID, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string strStatus);
	}
}
