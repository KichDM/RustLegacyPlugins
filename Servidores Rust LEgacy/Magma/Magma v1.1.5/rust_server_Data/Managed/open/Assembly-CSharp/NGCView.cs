using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using uLink;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public sealed class NGCView : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001F7F RID: 8063 RVA: 0x00078A28 File Offset: 0x00076C28
	public NGCView()
	{
	}

	// Token: 0x1400000F RID: 15
	// (add) Token: 0x06001F80 RID: 8064 RVA: 0x00078A30 File Offset: 0x00076C30
	// (remove) Token: 0x06001F81 RID: 8065 RVA: 0x00078A6C File Offset: 0x00076C6C
	public event global::NGC.EventCallback OnPreDestroy
	{
		add
		{
			if (this.preDestroying)
			{
				value(this);
			}
			else
			{
				this.onPreDestroy = (global::NGC.EventCallback)global::System.Delegate.Combine(this.onPreDestroy, value);
			}
		}
		remove
		{
			this.onPreDestroy = (global::NGC.EventCallback)global::System.Delegate.Remove(this.onPreDestroy, value);
		}
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x00078A88 File Offset: 0x00076C88
	public void RPC<P0, P1>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		this.RPC<P0, P1>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1>(p0, p1));
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x00078A9C File Offset: 0x00076C9C
	public void RPC<P0, P1>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001F84 RID: 8068 RVA: 0x00078AC8 File Offset: 0x00076CC8
	public void RPC<P0, P1>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		this.RPC<P0, P1>(flags, messageName, target, global::NGC.BlockArgs<P0, P1>(p0, p1));
	}

	// Token: 0x06001F85 RID: 8069 RVA: 0x00078ADC File Offset: 0x00076CDC
	public void RPC<P0, P1>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x00078B08 File Offset: 0x00076D08
	public void RPC<P0, P1>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		this.RPC<P0, P1>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1>(p0, p1));
	}

	// Token: 0x06001F87 RID: 8071 RVA: 0x00078B1C File Offset: 0x00076D1C
	public void RPC<P0, P1>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x00078B48 File Offset: 0x00076D48
	public void RPC<P0, P1>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		this.RPC<P0, P1>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1>(p0, p1));
	}

	// Token: 0x06001F89 RID: 8073 RVA: 0x00078B5C File Offset: 0x00076D5C
	public void RPC<P0, P1>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x00078B88 File Offset: 0x00076D88
	public void RPC<P0, P1>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		this.RPC<P0, P1>(messageName, target, global::NGC.BlockArgs<P0, P1>(p0, p1));
	}

	// Token: 0x06001F8B RID: 8075 RVA: 0x00078B9C File Offset: 0x00076D9C
	public void RPC<P0, P1>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x00078BC8 File Offset: 0x00076DC8
	public void RPC<P0, P1>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		this.RPC<P0, P1>(messageName, targets, global::NGC.BlockArgs<P0, P1>(p0, p1));
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x00078BDC File Offset: 0x00076DDC
	public void RPC<P0, P1>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x00078C08 File Offset: 0x00076E08
	public void RPC<P0, P1, P2>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		this.RPC<P0, P1, P2>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2>(p0, p1, p2));
	}

	// Token: 0x06001F8F RID: 8079 RVA: 0x00078C20 File Offset: 0x00076E20
	public void RPC<P0, P1, P2>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001F90 RID: 8080 RVA: 0x00078C4C File Offset: 0x00076E4C
	public void RPC<P0, P1, P2>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		this.RPC<P0, P1, P2>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2>(p0, p1, p2));
	}

	// Token: 0x06001F91 RID: 8081 RVA: 0x00078C64 File Offset: 0x00076E64
	public void RPC<P0, P1, P2>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001F92 RID: 8082 RVA: 0x00078C90 File Offset: 0x00076E90
	public void RPC<P0, P1, P2>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		this.RPC<P0, P1, P2>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2>(p0, p1, p2));
	}

	// Token: 0x06001F93 RID: 8083 RVA: 0x00078CA8 File Offset: 0x00076EA8
	public void RPC<P0, P1, P2>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001F94 RID: 8084 RVA: 0x00078CD4 File Offset: 0x00076ED4
	public void RPC<P0, P1, P2>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		this.RPC<P0, P1, P2>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2>(p0, p1, p2));
	}

	// Token: 0x06001F95 RID: 8085 RVA: 0x00078CE8 File Offset: 0x00076EE8
	public void RPC<P0, P1, P2>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x00078D14 File Offset: 0x00076F14
	public void RPC<P0, P1, P2>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		this.RPC<P0, P1, P2>(messageName, target, global::NGC.BlockArgs<P0, P1, P2>(p0, p1, p2));
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x00078D28 File Offset: 0x00076F28
	public void RPC<P0, P1, P2>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x00078D54 File Offset: 0x00076F54
	public void RPC<P0, P1, P2>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		this.RPC<P0, P1, P2>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2>(p0, p1, p2));
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x00078D68 File Offset: 0x00076F68
	public void RPC<P0, P1, P2>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001F9A RID: 8090 RVA: 0x00078D94 File Offset: 0x00076F94
	public void RPC<P0, P1, P2, P3>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		this.RPC<P0, P1, P2, P3>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3>(p0, p1, p2, p3));
	}

	// Token: 0x06001F9B RID: 8091 RVA: 0x00078DB8 File Offset: 0x00076FB8
	public void RPC<P0, P1, P2, P3>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001F9C RID: 8092 RVA: 0x00078DE4 File Offset: 0x00076FE4
	public void RPC<P0, P1, P2, P3>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		this.RPC<P0, P1, P2, P3>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3>(p0, p1, p2, p3));
	}

	// Token: 0x06001F9D RID: 8093 RVA: 0x00078E08 File Offset: 0x00077008
	public void RPC<P0, P1, P2, P3>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001F9E RID: 8094 RVA: 0x00078E34 File Offset: 0x00077034
	public void RPC<P0, P1, P2, P3>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		this.RPC<P0, P1, P2, P3>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3>(p0, p1, p2, p3));
	}

	// Token: 0x06001F9F RID: 8095 RVA: 0x00078E58 File Offset: 0x00077058
	public void RPC<P0, P1, P2, P3>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x00078E84 File Offset: 0x00077084
	public void RPC<P0, P1, P2, P3>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		this.RPC<P0, P1, P2, P3>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3>(p0, p1, p2, p3));
	}

	// Token: 0x06001FA1 RID: 8097 RVA: 0x00078E9C File Offset: 0x0007709C
	public void RPC<P0, P1, P2, P3>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FA2 RID: 8098 RVA: 0x00078EC8 File Offset: 0x000770C8
	public void RPC<P0, P1, P2, P3>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		this.RPC<P0, P1, P2, P3>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3>(p0, p1, p2, p3));
	}

	// Token: 0x06001FA3 RID: 8099 RVA: 0x00078EE0 File Offset: 0x000770E0
	public void RPC<P0, P1, P2, P3>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FA4 RID: 8100 RVA: 0x00078F0C File Offset: 0x0007710C
	public void RPC<P0, P1, P2, P3>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		this.RPC<P0, P1, P2, P3>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3>(p0, p1, p2, p3));
	}

	// Token: 0x06001FA5 RID: 8101 RVA: 0x00078F24 File Offset: 0x00077124
	public void RPC<P0, P1, P2, P3>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FA6 RID: 8102 RVA: 0x00078F50 File Offset: 0x00077150
	public void RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		this.RPC<P0, P1, P2, P3, P4>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4>(p0, p1, p2, p3, p4));
	}

	// Token: 0x06001FA7 RID: 8103 RVA: 0x00078F78 File Offset: 0x00077178
	public void RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x00078FA4 File Offset: 0x000771A4
	public void RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		this.RPC<P0, P1, P2, P3, P4>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4>(p0, p1, p2, p3, p4));
	}

	// Token: 0x06001FA9 RID: 8105 RVA: 0x00078FCC File Offset: 0x000771CC
	public void RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x00078FF8 File Offset: 0x000771F8
	public void RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		this.RPC<P0, P1, P2, P3, P4>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4>(p0, p1, p2, p3, p4));
	}

	// Token: 0x06001FAB RID: 8107 RVA: 0x00079020 File Offset: 0x00077220
	public void RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FAC RID: 8108 RVA: 0x0007904C File Offset: 0x0007724C
	public void RPC<P0, P1, P2, P3, P4>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		this.RPC<P0, P1, P2, P3, P4>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4>(p0, p1, p2, p3, p4));
	}

	// Token: 0x06001FAD RID: 8109 RVA: 0x00079070 File Offset: 0x00077270
	public void RPC<P0, P1, P2, P3, P4>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FAE RID: 8110 RVA: 0x0007909C File Offset: 0x0007729C
	public void RPC<P0, P1, P2, P3, P4>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		this.RPC<P0, P1, P2, P3, P4>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4>(p0, p1, p2, p3, p4));
	}

	// Token: 0x06001FAF RID: 8111 RVA: 0x000790C0 File Offset: 0x000772C0
	public void RPC<P0, P1, P2, P3, P4>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FB0 RID: 8112 RVA: 0x000790EC File Offset: 0x000772EC
	public void RPC<P0, P1, P2, P3, P4>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		this.RPC<P0, P1, P2, P3, P4>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4>(p0, p1, p2, p3, p4));
	}

	// Token: 0x06001FB1 RID: 8113 RVA: 0x00079110 File Offset: 0x00077310
	public void RPC<P0, P1, P2, P3, P4>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x0007913C File Offset: 0x0007733C
	public void RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		this.RPC<P0, P1, P2, P3, P4, P5>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5>(p0, p1, p2, p3, p4, p5));
	}

	// Token: 0x06001FB3 RID: 8115 RVA: 0x00079164 File Offset: 0x00077364
	public void RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FB4 RID: 8116 RVA: 0x00079190 File Offset: 0x00077390
	public void RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		this.RPC<P0, P1, P2, P3, P4, P5>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5>(p0, p1, p2, p3, p4, p5));
	}

	// Token: 0x06001FB5 RID: 8117 RVA: 0x000791B8 File Offset: 0x000773B8
	public void RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FB6 RID: 8118 RVA: 0x000791E4 File Offset: 0x000773E4
	public void RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		this.RPC<P0, P1, P2, P3, P4, P5>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5>(p0, p1, p2, p3, p4, p5));
	}

	// Token: 0x06001FB7 RID: 8119 RVA: 0x0007920C File Offset: 0x0007740C
	public void RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x00079238 File Offset: 0x00077438
	public void RPC<P0, P1, P2, P3, P4, P5>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		this.RPC<P0, P1, P2, P3, P4, P5>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5>(p0, p1, p2, p3, p4, p5));
	}

	// Token: 0x06001FB9 RID: 8121 RVA: 0x00079260 File Offset: 0x00077460
	public void RPC<P0, P1, P2, P3, P4, P5>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x0007928C File Offset: 0x0007748C
	public void RPC<P0, P1, P2, P3, P4, P5>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		this.RPC<P0, P1, P2, P3, P4, P5>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5>(p0, p1, p2, p3, p4, p5));
	}

	// Token: 0x06001FBB RID: 8123 RVA: 0x000792B4 File Offset: 0x000774B4
	public void RPC<P0, P1, P2, P3, P4, P5>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FBC RID: 8124 RVA: 0x000792E0 File Offset: 0x000774E0
	public void RPC<P0, P1, P2, P3, P4, P5>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		this.RPC<P0, P1, P2, P3, P4, P5>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5>(p0, p1, p2, p3, p4, p5));
	}

	// Token: 0x06001FBD RID: 8125 RVA: 0x00079308 File Offset: 0x00077508
	public void RPC<P0, P1, P2, P3, P4, P5>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FBE RID: 8126 RVA: 0x00079334 File Offset: 0x00077534
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6>(p0, p1, p2, p3, p4, p5, p6));
	}

	// Token: 0x06001FBF RID: 8127 RVA: 0x00079360 File Offset: 0x00077560
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x0007938C File Offset: 0x0007758C
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6>(p0, p1, p2, p3, p4, p5, p6));
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x000793B8 File Offset: 0x000775B8
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FC2 RID: 8130 RVA: 0x000793E4 File Offset: 0x000775E4
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6>(p0, p1, p2, p3, p4, p5, p6));
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x00079410 File Offset: 0x00077610
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FC4 RID: 8132 RVA: 0x0007943C File Offset: 0x0007763C
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6>(p0, p1, p2, p3, p4, p5, p6));
	}

	// Token: 0x06001FC5 RID: 8133 RVA: 0x00079464 File Offset: 0x00077664
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FC6 RID: 8134 RVA: 0x00079490 File Offset: 0x00077690
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6>(p0, p1, p2, p3, p4, p5, p6));
	}

	// Token: 0x06001FC7 RID: 8135 RVA: 0x000794B8 File Offset: 0x000776B8
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FC8 RID: 8136 RVA: 0x000794E4 File Offset: 0x000776E4
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6>(p0, p1, p2, p3, p4, p5, p6));
	}

	// Token: 0x06001FC9 RID: 8137 RVA: 0x0007950C File Offset: 0x0007770C
	public void RPC<P0, P1, P2, P3, P4, P5, P6>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x00079538 File Offset: 0x00077738
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(p0, p1, p2, p3, p4, p5, p6, p7));
	}

	// Token: 0x06001FCB RID: 8139 RVA: 0x00079564 File Offset: 0x00077764
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FCC RID: 8140 RVA: 0x00079590 File Offset: 0x00077790
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(p0, p1, p2, p3, p4, p5, p6, p7));
	}

	// Token: 0x06001FCD RID: 8141 RVA: 0x000795BC File Offset: 0x000777BC
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FCE RID: 8142 RVA: 0x000795E8 File Offset: 0x000777E8
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(p0, p1, p2, p3, p4, p5, p6, p7));
	}

	// Token: 0x06001FCF RID: 8143 RVA: 0x00079614 File Offset: 0x00077814
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x00079640 File Offset: 0x00077840
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(p0, p1, p2, p3, p4, p5, p6, p7));
	}

	// Token: 0x06001FD1 RID: 8145 RVA: 0x0007966C File Offset: 0x0007786C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FD2 RID: 8146 RVA: 0x00079698 File Offset: 0x00077898
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(p0, p1, p2, p3, p4, p5, p6, p7));
	}

	// Token: 0x06001FD3 RID: 8147 RVA: 0x000796C4 File Offset: 0x000778C4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FD4 RID: 8148 RVA: 0x000796F0 File Offset: 0x000778F0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(p0, p1, p2, p3, p4, p5, p6, p7));
	}

	// Token: 0x06001FD5 RID: 8149 RVA: 0x0007971C File Offset: 0x0007791C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FD6 RID: 8150 RVA: 0x00079748 File Offset: 0x00077948
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(p0, p1, p2, p3, p4, p5, p6, p7, p8));
	}

	// Token: 0x06001FD7 RID: 8151 RVA: 0x00079778 File Offset: 0x00077978
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FD8 RID: 8152 RVA: 0x000797A4 File Offset: 0x000779A4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(p0, p1, p2, p3, p4, p5, p6, p7, p8));
	}

	// Token: 0x06001FD9 RID: 8153 RVA: 0x000797D4 File Offset: 0x000779D4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FDA RID: 8154 RVA: 0x00079800 File Offset: 0x00077A00
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(p0, p1, p2, p3, p4, p5, p6, p7, p8));
	}

	// Token: 0x06001FDB RID: 8155 RVA: 0x00079830 File Offset: 0x00077A30
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FDC RID: 8156 RVA: 0x0007985C File Offset: 0x00077A5C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(p0, p1, p2, p3, p4, p5, p6, p7, p8));
	}

	// Token: 0x06001FDD RID: 8157 RVA: 0x00079888 File Offset: 0x00077A88
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FDE RID: 8158 RVA: 0x000798B4 File Offset: 0x00077AB4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(p0, p1, p2, p3, p4, p5, p6, p7, p8));
	}

	// Token: 0x06001FDF RID: 8159 RVA: 0x000798E0 File Offset: 0x00077AE0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FE0 RID: 8160 RVA: 0x0007990C File Offset: 0x00077B0C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(p0, p1, p2, p3, p4, p5, p6, p7, p8));
	}

	// Token: 0x06001FE1 RID: 8161 RVA: 0x00079938 File Offset: 0x00077B38
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FE2 RID: 8162 RVA: 0x00079964 File Offset: 0x00077B64
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	// Token: 0x06001FE3 RID: 8163 RVA: 0x00079994 File Offset: 0x00077B94
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FE4 RID: 8164 RVA: 0x000799C0 File Offset: 0x00077BC0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	// Token: 0x06001FE5 RID: 8165 RVA: 0x000799F0 File Offset: 0x00077BF0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FE6 RID: 8166 RVA: 0x00079A1C File Offset: 0x00077C1C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	// Token: 0x06001FE7 RID: 8167 RVA: 0x00079A4C File Offset: 0x00077C4C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FE8 RID: 8168 RVA: 0x00079A78 File Offset: 0x00077C78
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	// Token: 0x06001FE9 RID: 8169 RVA: 0x00079AA8 File Offset: 0x00077CA8
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x00079AD4 File Offset: 0x00077CD4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	// Token: 0x06001FEB RID: 8171 RVA: 0x00079B04 File Offset: 0x00077D04
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FEC RID: 8172 RVA: 0x00079B30 File Offset: 0x00077D30
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	// Token: 0x06001FED RID: 8173 RVA: 0x00079B60 File Offset: 0x00077D60
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FEE RID: 8174 RVA: 0x00079B8C File Offset: 0x00077D8C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	// Token: 0x06001FEF RID: 8175 RVA: 0x00079BC0 File Offset: 0x00077DC0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FF0 RID: 8176 RVA: 0x00079BEC File Offset: 0x00077DEC
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	// Token: 0x06001FF1 RID: 8177 RVA: 0x00079C20 File Offset: 0x00077E20
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FF2 RID: 8178 RVA: 0x00079C4C File Offset: 0x00077E4C
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	// Token: 0x06001FF3 RID: 8179 RVA: 0x00079C80 File Offset: 0x00077E80
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06001FF4 RID: 8180 RVA: 0x00079CAC File Offset: 0x00077EAC
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	// Token: 0x06001FF5 RID: 8181 RVA: 0x00079CDC File Offset: 0x00077EDC
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FF6 RID: 8182 RVA: 0x00079D08 File Offset: 0x00077F08
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	// Token: 0x06001FF7 RID: 8183 RVA: 0x00079D38 File Offset: 0x00077F38
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06001FF8 RID: 8184 RVA: 0x00079D64 File Offset: 0x00077F64
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	// Token: 0x06001FF9 RID: 8185 RVA: 0x00079D94 File Offset: 0x00077F94
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06001FFA RID: 8186 RVA: 0x00079DC0 File Offset: 0x00077FC0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(flags, messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	// Token: 0x06001FFB RID: 8187 RVA: 0x00079DF4 File Offset: 0x00077FF4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, rpcMode, bitStream);
	}

	// Token: 0x06001FFC RID: 8188 RVA: 0x00079E20 File Offset: 0x00078020
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(flags, messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	// Token: 0x06001FFD RID: 8189 RVA: 0x00079E54 File Offset: 0x00078054
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, target, bitStream);
	}

	// Token: 0x06001FFE RID: 8190 RVA: 0x00079E80 File Offset: 0x00078080
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(flags, messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	// Token: 0x06001FFF RID: 8191 RVA: 0x00079EB4 File Offset: 0x000780B4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(block, new object[0]);
		this.RPC_Stream(flags, messageName, targets, bitStream);
	}

	// Token: 0x06002000 RID: 8192 RVA: 0x00079EE0 File Offset: 0x000780E0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(messageName, rpcMode, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	// Token: 0x06002001 RID: 8193 RVA: 0x00079F14 File Offset: 0x00078114
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(string messageName, global::uLink.RPCMode rpcMode, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, rpcMode, bitStream);
	}

	// Token: 0x06002002 RID: 8194 RVA: 0x00079F40 File Offset: 0x00078140
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(messageName, target, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	// Token: 0x06002003 RID: 8195 RVA: 0x00079F74 File Offset: 0x00078174
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(string messageName, global::uLink.NetworkPlayer target, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, target, bitStream);
	}

	// Token: 0x06002004 RID: 8196 RVA: 0x00079FA0 File Offset: 0x000781A0
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		this.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(messageName, targets, global::NGC.BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	// Token: 0x06002005 RID: 8197 RVA: 0x00079FD4 File Offset: 0x000781D4
	public void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(block, new object[0]);
		this.RPC_Stream(messageName, targets, bitStream);
	}

	// Token: 0x06002006 RID: 8198 RVA: 0x0007A000 File Offset: 0x00078200
	internal string GetBufferedCallRPCName(int messageIndex)
	{
		string result;
		if (this.allCalls == null)
		{
			this.allCalls = new global::System.Collections.Generic.Dictionary<int, string>();
		}
		else if (this.allCalls.TryGetValue(messageIndex, out result))
		{
			return result;
		}
		result = (this.allCalls[messageIndex] = this.callRPCName + "_" + messageIndex.ToString("x"));
		return result;
	}

	// Token: 0x06002007 RID: 8199 RVA: 0x0007A068 File Offset: 0x00078268
	internal void DidBufferedRPCCall(int messageIndex)
	{
		if (this.bufferedMessages == null)
		{
			this.bufferedMessages = new global::System.Collections.Generic.HashSet<int>();
		}
		this.bufferedMessages.Add(messageIndex);
	}

	// Token: 0x06002008 RID: 8200 RVA: 0x0007A090 File Offset: 0x00078290
	internal global::System.Collections.Generic.IEnumerable<string> AllRPCNamesUsed()
	{
		yield return this.removeRPCName;
		if (this.allCalls != null)
		{
			foreach (string call in this.allCalls.Values)
			{
				yield return call;
			}
		}
		yield return this.addRPCName;
		yield break;
	}

	// Token: 0x170007DC RID: 2012
	// (get) Token: 0x06002009 RID: 8201 RVA: 0x0007A0B4 File Offset: 0x000782B4
	internal int id
	{
		get
		{
			if (this.innerID <= 0 || !this.outer)
			{
				return 0;
			}
			return global::NGC.PackID((int)this.outer.groupNumber, (int)this.innerID);
		}
	}

	// Token: 0x170007DD RID: 2013
	// (get) Token: 0x0600200A RID: 8202 RVA: 0x0007A0F8 File Offset: 0x000782F8
	public global::NetEntityID entityID
	{
		get
		{
			return new global::NetEntityID(this);
		}
	}

	// Token: 0x170007DE RID: 2014
	// (get) Token: 0x0600200B RID: 8203 RVA: 0x0007A100 File Offset: 0x00078300
	public global::UnityEngine.Vector3 creationPosition
	{
		get
		{
			return this.spawnPosition;
		}
	}

	// Token: 0x170007DF RID: 2015
	// (get) Token: 0x0600200C RID: 8204 RVA: 0x0007A108 File Offset: 0x00078308
	public global::UnityEngine.Quaternion creationRotation
	{
		get
		{
			return this.spawnRotation;
		}
	}

	// Token: 0x0600200D RID: 8205 RVA: 0x0007A110 File Offset: 0x00078310
	internal void PostInstantiate()
	{
		base.BroadcastMessage("NGC_OnInstantiate", this, 1);
	}

	// Token: 0x0600200E RID: 8206 RVA: 0x0007A120 File Offset: 0x00078320
	internal void PreDestroy()
	{
		if (!this.preDestroying)
		{
			this.preDestroying = true;
			if (this.onPreDestroy != null)
			{
				global::NGC.EventCallback eventCallback = this.onPreDestroy;
				this.onPreDestroy = null;
				try
				{
					eventCallback(this);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
				}
			}
		}
	}

	// Token: 0x0600200F RID: 8207 RVA: 0x0007A18C File Offset: 0x0007838C
	private global::NGC EnsureCall()
	{
		return this.outer;
	}

	// Token: 0x06002010 RID: 8208 RVA: 0x0007A194 File Offset: 0x00078394
	public void RPC(global::uLink.NetworkFlags flags, string message, global::uLink.RPCMode mode)
	{
		this.EnsureCall().NGCViewRPC(flags, mode, this, this.prefab.MessageIndex(message), null, 0, 0);
	}

	// Token: 0x06002011 RID: 8209 RVA: 0x0007A1C0 File Offset: 0x000783C0
	public void RPC(global::uLink.NetworkFlags flags, string message, global::uLink.NetworkPlayer target)
	{
		this.EnsureCall().NGCViewRPC(flags, target, this, this.prefab.MessageIndex(message), null, 0, 0);
	}

	// Token: 0x06002012 RID: 8210 RVA: 0x0007A1EC File Offset: 0x000783EC
	public void RPC(global::uLink.NetworkFlags flags, string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target)
	{
		this.EnsureCall().NGCViewRPC(flags, target, this, this.prefab.MessageIndex(message), null, 0, 0);
	}

	// Token: 0x06002013 RID: 8211 RVA: 0x0007A218 File Offset: 0x00078418
	public void RPC(string message, global::uLink.RPCMode mode)
	{
		this.EnsureCall().NGCViewRPC(mode, this, this.prefab.MessageIndex(message), null, 0, 0);
	}

	// Token: 0x06002014 RID: 8212 RVA: 0x0007A244 File Offset: 0x00078444
	public void RPC(string message, global::uLink.NetworkPlayer target)
	{
		this.EnsureCall().NGCViewRPC(target, this, this.prefab.MessageIndex(message), null, 0, 0);
	}

	// Token: 0x06002015 RID: 8213 RVA: 0x0007A270 File Offset: 0x00078470
	public void RPC(string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target)
	{
		this.EnsureCall().NGCViewRPC(target, this, this.prefab.MessageIndex(message), null, 0, 0);
	}

	// Token: 0x06002016 RID: 8214 RVA: 0x0007A29C File Offset: 0x0007849C
	public void RPC_Bytes(global::uLink.NetworkFlags flags, string message, global::uLink.RPCMode mode, byte[] data)
	{
		this.EnsureCall().NGCViewRPC(flags, mode, this, this.prefab.MessageIndex(message), data, 0, (data != null) ? data.Length : 0);
	}

	// Token: 0x06002017 RID: 8215 RVA: 0x0007A2D8 File Offset: 0x000784D8
	public void RPC_Bytes(global::uLink.NetworkFlags flags, string message, global::uLink.NetworkPlayer target, byte[] data)
	{
		this.EnsureCall().NGCViewRPC(flags, target, this, this.prefab.MessageIndex(message), data, 0, (data != null) ? data.Length : 0);
	}

	// Token: 0x06002018 RID: 8216 RVA: 0x0007A314 File Offset: 0x00078514
	public void RPC_Bytes(global::uLink.NetworkFlags flags, string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target, byte[] data)
	{
		this.EnsureCall().NGCViewRPC(flags, target, this, this.prefab.MessageIndex(message), data, 0, (data != null) ? data.Length : 0);
	}

	// Token: 0x06002019 RID: 8217 RVA: 0x0007A350 File Offset: 0x00078550
	public void RPC_Bytes(string message, global::uLink.RPCMode mode, byte[] data)
	{
		this.EnsureCall().NGCViewRPC(mode, this, this.prefab.MessageIndex(message), data, 0, (data != null) ? data.Length : 0);
	}

	// Token: 0x0600201A RID: 8218 RVA: 0x0007A388 File Offset: 0x00078588
	public void RPC_Bytes(string message, global::uLink.NetworkPlayer target, byte[] data)
	{
		this.EnsureCall().NGCViewRPC(target, this, this.prefab.MessageIndex(message), data, 0, (data != null) ? data.Length : 0);
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x0007A3C0 File Offset: 0x000785C0
	public void RPC_Bytes(string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target, byte[] data)
	{
		this.EnsureCall().NGCViewRPC(target, this, this.prefab.MessageIndex(message), data, 0, (data != null) ? data.Length : 0);
	}

	// Token: 0x0600201C RID: 8220 RVA: 0x0007A3F8 File Offset: 0x000785F8
	public void RPC_Stream(global::uLink.NetworkFlags flags, string message, global::uLink.RPCMode mode, global::uLink.BitStream data)
	{
		this.RPC_Bytes(flags, message, mode, data.GetDataByteArray());
	}

	// Token: 0x0600201D RID: 8221 RVA: 0x0007A40C File Offset: 0x0007860C
	public void RPC_Stream(global::uLink.NetworkFlags flags, string message, global::uLink.NetworkPlayer target, global::uLink.BitStream data)
	{
		this.RPC_Bytes(flags, message, target, data.GetDataByteArray());
	}

	// Token: 0x0600201E RID: 8222 RVA: 0x0007A420 File Offset: 0x00078620
	public void RPC_Stream(global::uLink.NetworkFlags flags, string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target, global::uLink.BitStream data)
	{
		this.RPC_Bytes(flags, message, target, data.GetDataByteArray());
	}

	// Token: 0x0600201F RID: 8223 RVA: 0x0007A434 File Offset: 0x00078634
	public void RPC_Stream(string message, global::uLink.RPCMode mode, global::uLink.BitStream data)
	{
		this.RPC_Bytes(message, mode, data.GetDataByteArray());
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x0007A444 File Offset: 0x00078644
	public void RPC_Stream(string message, global::uLink.NetworkPlayer target, global::uLink.BitStream data)
	{
		this.RPC_Bytes(message, target, data.GetDataByteArray());
	}

	// Token: 0x06002021 RID: 8225 RVA: 0x0007A454 File Offset: 0x00078654
	public void RPC_Stream(string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target, global::uLink.BitStream data)
	{
		this.RPC_Bytes(message, target, data.GetDataByteArray());
	}

	// Token: 0x06002022 RID: 8226 RVA: 0x0007A464 File Offset: 0x00078664
	private static global::uLink.BitStream ToStream<T>(T arg)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<T>(arg, new object[0]);
		return bitStream;
	}

	// Token: 0x06002023 RID: 8227 RVA: 0x0007A488 File Offset: 0x00078688
	public void RPC<T>(global::uLink.NetworkFlags flags, string message, global::uLink.RPCMode mode, T arg)
	{
		this.RPC_Stream(flags, message, mode, global::NGCView.ToStream<T>(arg));
	}

	// Token: 0x06002024 RID: 8228 RVA: 0x0007A49C File Offset: 0x0007869C
	public void RPC<T>(global::uLink.NetworkFlags flags, string message, global::uLink.NetworkPlayer target, T arg)
	{
		this.RPC_Stream(flags, message, target, global::NGCView.ToStream<T>(arg));
	}

	// Token: 0x06002025 RID: 8229 RVA: 0x0007A4B0 File Offset: 0x000786B0
	public void RPC<T>(global::uLink.NetworkFlags flags, string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target, T arg)
	{
		this.RPC_Stream(flags, message, target, global::NGCView.ToStream<T>(arg));
	}

	// Token: 0x06002026 RID: 8230 RVA: 0x0007A4C4 File Offset: 0x000786C4
	public void RPC<T>(string message, global::uLink.RPCMode mode, T arg)
	{
		this.RPC_Stream(message, mode, global::NGCView.ToStream<T>(arg));
	}

	// Token: 0x06002027 RID: 8231 RVA: 0x0007A4D4 File Offset: 0x000786D4
	public void RPC<T>(string message, global::uLink.NetworkPlayer target, T arg)
	{
		this.RPC_Stream(message, target, global::NGCView.ToStream<T>(arg));
	}

	// Token: 0x06002028 RID: 8232 RVA: 0x0007A4E4 File Offset: 0x000786E4
	public void RPC<T>(string message, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> target, T arg)
	{
		this.RPC_Stream(message, target, global::NGCView.ToStream<T>(arg));
	}

	// Token: 0x06002029 RID: 8233 RVA: 0x0007A4F4 File Offset: 0x000786F4
	public bool IsRPCBuffered(string messageName)
	{
		if (this.bufferedMessages != null && this.bufferedMessages.Count > 0)
		{
			int item = this.prefab.MessageIndex(messageName);
			if (this.bufferedMessages.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600202A RID: 8234 RVA: 0x0007A540 File Offset: 0x00078740
	public bool RemoveRPCs()
	{
		if (this.bufferedMessages != null && this.bufferedMessages.Count > 0)
		{
			foreach (int key in this.bufferedMessages)
			{
				global::NetCull.RemoveRPCsByName(this.outer.networkViewID, this.allCalls[key]);
			}
			this.bufferedMessages.Clear();
			return true;
		}
		return false;
	}

	// Token: 0x0600202B RID: 8235 RVA: 0x0007A5E8 File Offset: 0x000787E8
	public bool RemoveRPCs(string messageName)
	{
		if (this.bufferedMessages != null && this.bufferedMessages.Count > 0)
		{
			int num = this.prefab.MessageIndex(messageName);
			if (this.bufferedMessages.Remove(num))
			{
				global::NetCull.RemoveRPCsByName(this.outer.networkViewID, this.allCalls[num]);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600202C RID: 8236 RVA: 0x0007A650 File Offset: 0x00078850
	public static global::NGCView Find(int id)
	{
		return global::NGC.Find(id);
	}

	// Token: 0x04001138 RID: 4408
	[global::System.NonSerialized]
	public global::NGC.Prefab prefab;

	// Token: 0x04001139 RID: 4409
	[global::System.NonSerialized]
	public global::NGC outer;

	// Token: 0x0400113A RID: 4410
	[global::System.NonSerialized]
	public ushort innerID;

	// Token: 0x0400113B RID: 4411
	[global::System.NonSerialized]
	internal string addRPCName;

	// Token: 0x0400113C RID: 4412
	[global::System.NonSerialized]
	internal string callRPCName;

	// Token: 0x0400113D RID: 4413
	[global::System.NonSerialized]
	internal string removeRPCName;

	// Token: 0x0400113E RID: 4414
	[global::System.NonSerialized]
	internal bool _net_destroying;

	// Token: 0x0400113F RID: 4415
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Dictionary<int, string> allCalls;

	// Token: 0x04001140 RID: 4416
	[global::System.NonSerialized]
	private global::System.Collections.Generic.HashSet<int> bufferedMessages;

	// Token: 0x04001141 RID: 4417
	[global::System.NonSerialized]
	public global::uLink.NetworkMessageInfo creation;

	// Token: 0x04001142 RID: 4418
	[global::System.NonSerialized]
	public global::uLink.BitStream initialData;

	// Token: 0x04001143 RID: 4419
	[global::UnityEngine.SerializeField]
	internal global::UnityEngine.MonoBehaviour[] scripts;

	// Token: 0x04001144 RID: 4420
	[global::System.NonSerialized]
	internal global::NGC.Prefab.Installation.Instance install;

	// Token: 0x04001145 RID: 4421
	[global::System.NonSerialized]
	internal global::UnityEngine.Vector3 spawnPosition;

	// Token: 0x04001146 RID: 4422
	[global::System.NonSerialized]
	internal global::UnityEngine.Quaternion spawnRotation;

	// Token: 0x04001147 RID: 4423
	[global::System.NonSerialized]
	private global::NGC.EventCallback onPreDestroy;

	// Token: 0x04001148 RID: 4424
	[global::System.NonSerialized]
	private bool preDestroying;

	// Token: 0x020003EC RID: 1004
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <AllRPCNamesUsed>c__Iterator37 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.Generic.IEnumerator<string>
	{
		// Token: 0x0600202D RID: 8237 RVA: 0x0007A658 File Offset: 0x00078858
		public <AllRPCNamesUsed>c__Iterator37()
		{
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x0600202E RID: 8238 RVA: 0x0007A660 File Offset: 0x00078860
		string global::System.Collections.Generic.IEnumerator<string>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x0600202F RID: 8239 RVA: 0x0007A668 File Offset: 0x00078868
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x0007A670 File Offset: 0x00078870
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<string>.GetEnumerator();
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x0007A678 File Offset: 0x00078878
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::NGCView.<AllRPCNamesUsed>c__Iterator37 <AllRPCNamesUsed>c__Iterator = new global::NGCView.<AllRPCNamesUsed>c__Iterator37();
			<AllRPCNamesUsed>c__Iterator.<>f__this = this;
			return <AllRPCNamesUsed>c__Iterator;
		}

		// Token: 0x06002032 RID: 8242 RVA: 0x0007A6AC File Offset: 0x000788AC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				this.$current = this.removeRPCName;
				this.$PC = 1;
				return true;
			case 1U:
				if (this.allCalls == null)
				{
					goto IL_DC;
				}
				enumerator = this.allCalls.Values.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 2U:
				break;
			case 3U:
				this.$PC = -1;
				return false;
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
					call = enumerator.Current;
					this.$current = call;
					this.$PC = 2;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			IL_DC:
			this.$current = this.addRPCName;
			this.$PC = 3;
			return true;
		}

		// Token: 0x06002033 RID: 8243 RVA: 0x0007A7DC File Offset: 0x000789DC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 2U:
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

		// Token: 0x06002034 RID: 8244 RVA: 0x0007A844 File Offset: 0x00078A44
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001149 RID: 4425
		internal global::System.Collections.Generic.Dictionary<int, string>.ValueCollection.Enumerator <$s_340>__0;

		// Token: 0x0400114A RID: 4426
		internal string <call>__1;

		// Token: 0x0400114B RID: 4427
		internal int $PC;

		// Token: 0x0400114C RID: 4428
		internal string $current;

		// Token: 0x0400114D RID: 4429
		internal global::NGCView <>f__this;
	}
}
