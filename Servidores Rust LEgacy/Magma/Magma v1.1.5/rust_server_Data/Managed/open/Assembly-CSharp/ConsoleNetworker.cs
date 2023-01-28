using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class ConsoleNetworker : global::Facepunch.MonoBehaviour
{
	// Token: 0x06002C29 RID: 11305 RVA: 0x000A6460 File Offset: 0x000A4660
	public ConsoleNetworker()
	{
	}

	// Token: 0x06002C2A RID: 11306 RVA: 0x000A6468 File Offset: 0x000A4668
	private void Awake()
	{
		global::ConsoleNetworker.singleton = this;
	}

	// Token: 0x06002C2B RID: 11307 RVA: 0x000A6470 File Offset: 0x000A4670
	public static void Broadcast(string cmd)
	{
		if (!global::ConsoleNetworker.singleton)
		{
			return;
		}
		global::ConsoleNetworker.singleton.networkView.RPC<string>("CL_ConsoleCommand", 1, cmd);
	}

	// Token: 0x06002C2C RID: 11308 RVA: 0x000A64A4 File Offset: 0x000A46A4
	public static void SendClientCommand(global::uLink.NetworkPlayer player, string cmd)
	{
		if (!global::ConsoleNetworker.singleton)
		{
			return;
		}
		global::ConsoleNetworker.singleton.networkView.RPC<string>("CL_ConsoleCommand", player, cmd);
	}

	// Token: 0x06002C2D RID: 11309 RVA: 0x000A64D8 File Offset: 0x000A46D8
	[global::UnityEngine.RPC]
	public void SV_RunConsoleCommand(string cmd, global::uLink.NetworkMessageInfo info)
	{
		global::NetUser user = global::NetUser.Find(info.sender);
		string text;
		if (!global::ConsoleSystem.RunCommand_Serverside(cmd, user, out text))
		{
			return;
		}
		if (text == string.Empty)
		{
			return;
		}
		base.networkView.RPC<string>("CL_ConsoleMessage", info.sender, text);
	}

	// Token: 0x06002C2E RID: 11310 RVA: 0x000A6528 File Offset: 0x000A4728
	[global::UnityEngine.RPC]
	public void CL_ConsoleMessage(string message, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002C2F RID: 11311 RVA: 0x000A652C File Offset: 0x000A472C
	[global::UnityEngine.RPC]
	public void CL_ConsoleCommand(string message, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x04001671 RID: 5745
	public static global::ConsoleNetworker singleton;
}
