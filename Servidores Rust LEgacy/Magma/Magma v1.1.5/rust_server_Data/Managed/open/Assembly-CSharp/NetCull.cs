using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public static class NetCull
{
	// Token: 0x06002035 RID: 8245 RVA: 0x0007A84C File Offset: 0x00078A4C
	// Note: this type is marked as 'beforefieldinit'.
	static NetCull()
	{
	}

	// Token: 0x06002036 RID: 8246 RVA: 0x0007A884 File Offset: 0x00078A84
	public static void RPC(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		view.RPC(flags, messageName, rpcMode, new object[0]);
	}

	// Token: 0x06002037 RID: 8247 RVA: 0x0007A898 File Offset: 0x00078A98
	public static void RPC(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		view.RPC(flags, messageName, target, new object[0]);
	}

	// Token: 0x06002038 RID: 8248 RVA: 0x0007A8AC File Offset: 0x00078AAC
	public static void RPC(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		view.RPC(flags, messageName, targets, new object[0]);
	}

	// Token: 0x06002039 RID: 8249 RVA: 0x0007A8C0 File Offset: 0x00078AC0
	public static void RPC(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode)
	{
		view.RPC(messageName, rpcMode, new object[0]);
	}

	// Token: 0x0600203A RID: 8250 RVA: 0x0007A8D0 File Offset: 0x00078AD0
	public static void RPC(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target)
	{
		view.RPC(messageName, target, new object[0]);
	}

	// Token: 0x0600203B RID: 8251 RVA: 0x0007A8E0 File Offset: 0x00078AE0
	public static void RPC(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		view.RPC(messageName, targets, new object[0]);
	}

	// Token: 0x0600203C RID: 8252 RVA: 0x0007A8F0 File Offset: 0x00078AF0
	public static void RPC<P0>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		view.RPC<P0>(flags, messageName, rpcMode, p0);
	}

	// Token: 0x0600203D RID: 8253 RVA: 0x0007A900 File Offset: 0x00078B00
	public static void RPC<P0>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		view.RPC<P0>(flags, messageName, target, p0);
	}

	// Token: 0x0600203E RID: 8254 RVA: 0x0007A910 File Offset: 0x00078B10
	public static void RPC<P0>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		view.RPC<P0>(flags, messageName, targets, p0);
	}

	// Token: 0x0600203F RID: 8255 RVA: 0x0007A920 File Offset: 0x00078B20
	public static void RPC<P0>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		view.RPC<P0>(messageName, rpcMode, p0);
	}

	// Token: 0x06002040 RID: 8256 RVA: 0x0007A92C File Offset: 0x00078B2C
	public static void RPC<P0>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		view.RPC<P0>(messageName, target, p0);
	}

	// Token: 0x06002041 RID: 8257 RVA: 0x0007A938 File Offset: 0x00078B38
	public static void RPC<P0>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		view.RPC<P0>(messageName, targets, p0);
	}

	// Token: 0x06002042 RID: 8258 RVA: 0x0007A944 File Offset: 0x00078B44
	public static void RPC<P0, P1>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1
		});
	}

	// Token: 0x06002043 RID: 8259 RVA: 0x0007A974 File Offset: 0x00078B74
	public static void RPC<P0, P1>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1
		});
	}

	// Token: 0x06002044 RID: 8260 RVA: 0x0007A9A4 File Offset: 0x00078BA4
	public static void RPC<P0, P1>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1
		});
	}

	// Token: 0x06002045 RID: 8261 RVA: 0x0007A9D4 File Offset: 0x00078BD4
	public static void RPC<P0, P1>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1
		});
	}

	// Token: 0x06002046 RID: 8262 RVA: 0x0007A9F8 File Offset: 0x00078BF8
	public static void RPC<P0, P1>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1
		});
	}

	// Token: 0x06002047 RID: 8263 RVA: 0x0007AA1C File Offset: 0x00078C1C
	public static void RPC<P0, P1>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1
		});
	}

	// Token: 0x06002048 RID: 8264 RVA: 0x0007AA40 File Offset: 0x00078C40
	public static void RPC<P0, P1, P2>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2
		});
	}

	// Token: 0x06002049 RID: 8265 RVA: 0x0007AA7C File Offset: 0x00078C7C
	public static void RPC<P0, P1, P2>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2
		});
	}

	// Token: 0x0600204A RID: 8266 RVA: 0x0007AAB8 File Offset: 0x00078CB8
	public static void RPC<P0, P1, P2>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2
		});
	}

	// Token: 0x0600204B RID: 8267 RVA: 0x0007AAF4 File Offset: 0x00078CF4
	public static void RPC<P0, P1, P2>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2
		});
	}

	// Token: 0x0600204C RID: 8268 RVA: 0x0007AB24 File Offset: 0x00078D24
	public static void RPC<P0, P1, P2>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2
		});
	}

	// Token: 0x0600204D RID: 8269 RVA: 0x0007AB54 File Offset: 0x00078D54
	public static void RPC<P0, P1, P2>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2
		});
	}

	// Token: 0x0600204E RID: 8270 RVA: 0x0007AB84 File Offset: 0x00078D84
	public static void RPC<P0, P1, P2, P3>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3
		});
	}

	// Token: 0x0600204F RID: 8271 RVA: 0x0007ABC8 File Offset: 0x00078DC8
	public static void RPC<P0, P1, P2, P3>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3
		});
	}

	// Token: 0x06002050 RID: 8272 RVA: 0x0007AC0C File Offset: 0x00078E0C
	public static void RPC<P0, P1, P2, P3>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3
		});
	}

	// Token: 0x06002051 RID: 8273 RVA: 0x0007AC50 File Offset: 0x00078E50
	public static void RPC<P0, P1, P2, P3>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3
		});
	}

	// Token: 0x06002052 RID: 8274 RVA: 0x0007AC88 File Offset: 0x00078E88
	public static void RPC<P0, P1, P2, P3>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3
		});
	}

	// Token: 0x06002053 RID: 8275 RVA: 0x0007ACC0 File Offset: 0x00078EC0
	public static void RPC<P0, P1, P2, P3>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3
		});
	}

	// Token: 0x06002054 RID: 8276 RVA: 0x0007ACF8 File Offset: 0x00078EF8
	public static void RPC<P0, P1, P2, P3, P4>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4
		});
	}

	// Token: 0x06002055 RID: 8277 RVA: 0x0007AD48 File Offset: 0x00078F48
	public static void RPC<P0, P1, P2, P3, P4>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4
		});
	}

	// Token: 0x06002056 RID: 8278 RVA: 0x0007AD98 File Offset: 0x00078F98
	public static void RPC<P0, P1, P2, P3, P4>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4
		});
	}

	// Token: 0x06002057 RID: 8279 RVA: 0x0007ADE8 File Offset: 0x00078FE8
	public static void RPC<P0, P1, P2, P3, P4>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4
		});
	}

	// Token: 0x06002058 RID: 8280 RVA: 0x0007AE34 File Offset: 0x00079034
	public static void RPC<P0, P1, P2, P3, P4>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4
		});
	}

	// Token: 0x06002059 RID: 8281 RVA: 0x0007AE80 File Offset: 0x00079080
	public static void RPC<P0, P1, P2, P3, P4>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4
		});
	}

	// Token: 0x0600205A RID: 8282 RVA: 0x0007AECC File Offset: 0x000790CC
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5
		});
	}

	// Token: 0x0600205B RID: 8283 RVA: 0x0007AF24 File Offset: 0x00079124
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5
		});
	}

	// Token: 0x0600205C RID: 8284 RVA: 0x0007AF7C File Offset: 0x0007917C
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5
		});
	}

	// Token: 0x0600205D RID: 8285 RVA: 0x0007AFD4 File Offset: 0x000791D4
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5
		});
	}

	// Token: 0x0600205E RID: 8286 RVA: 0x0007B02C File Offset: 0x0007922C
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5
		});
	}

	// Token: 0x0600205F RID: 8287 RVA: 0x0007B084 File Offset: 0x00079284
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5
		});
	}

	// Token: 0x06002060 RID: 8288 RVA: 0x0007B0DC File Offset: 0x000792DC
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6
		});
	}

	// Token: 0x06002061 RID: 8289 RVA: 0x0007B140 File Offset: 0x00079340
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6
		});
	}

	// Token: 0x06002062 RID: 8290 RVA: 0x0007B1A4 File Offset: 0x000793A4
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6
		});
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x0007B208 File Offset: 0x00079408
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6
		});
	}

	// Token: 0x06002064 RID: 8292 RVA: 0x0007B268 File Offset: 0x00079468
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6
		});
	}

	// Token: 0x06002065 RID: 8293 RVA: 0x0007B2C8 File Offset: 0x000794C8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6
		});
	}

	// Token: 0x06002066 RID: 8294 RVA: 0x0007B328 File Offset: 0x00079528
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7
		});
	}

	// Token: 0x06002067 RID: 8295 RVA: 0x0007B394 File Offset: 0x00079594
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7
		});
	}

	// Token: 0x06002068 RID: 8296 RVA: 0x0007B400 File Offset: 0x00079600
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7
		});
	}

	// Token: 0x06002069 RID: 8297 RVA: 0x0007B46C File Offset: 0x0007966C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7
		});
	}

	// Token: 0x0600206A RID: 8298 RVA: 0x0007B4D8 File Offset: 0x000796D8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7
		});
	}

	// Token: 0x0600206B RID: 8299 RVA: 0x0007B544 File Offset: 0x00079744
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7
		});
	}

	// Token: 0x0600206C RID: 8300 RVA: 0x0007B5B0 File Offset: 0x000797B0
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8
		});
	}

	// Token: 0x0600206D RID: 8301 RVA: 0x0007B628 File Offset: 0x00079828
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8
		});
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x0007B6A0 File Offset: 0x000798A0
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8
		});
	}

	// Token: 0x0600206F RID: 8303 RVA: 0x0007B718 File Offset: 0x00079918
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8
		});
	}

	// Token: 0x06002070 RID: 8304 RVA: 0x0007B790 File Offset: 0x00079990
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8
		});
	}

	// Token: 0x06002071 RID: 8305 RVA: 0x0007B808 File Offset: 0x00079A08
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8
		});
	}

	// Token: 0x06002072 RID: 8306 RVA: 0x0007B880 File Offset: 0x00079A80
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9
		});
	}

	// Token: 0x06002073 RID: 8307 RVA: 0x0007B904 File Offset: 0x00079B04
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9
		});
	}

	// Token: 0x06002074 RID: 8308 RVA: 0x0007B988 File Offset: 0x00079B88
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9
		});
	}

	// Token: 0x06002075 RID: 8309 RVA: 0x0007BA0C File Offset: 0x00079C0C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9
		});
	}

	// Token: 0x06002076 RID: 8310 RVA: 0x0007BA8C File Offset: 0x00079C8C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9
		});
	}

	// Token: 0x06002077 RID: 8311 RVA: 0x0007BB0C File Offset: 0x00079D0C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9
		});
	}

	// Token: 0x06002078 RID: 8312 RVA: 0x0007BB8C File Offset: 0x00079D8C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10
		});
	}

	// Token: 0x06002079 RID: 8313 RVA: 0x0007BC1C File Offset: 0x00079E1C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10
		});
	}

	// Token: 0x0600207A RID: 8314 RVA: 0x0007BCAC File Offset: 0x00079EAC
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10
		});
	}

	// Token: 0x0600207B RID: 8315 RVA: 0x0007BD3C File Offset: 0x00079F3C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10
		});
	}

	// Token: 0x0600207C RID: 8316 RVA: 0x0007BDC8 File Offset: 0x00079FC8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10
		});
	}

	// Token: 0x0600207D RID: 8317 RVA: 0x0007BE54 File Offset: 0x0007A054
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10
		});
	}

	// Token: 0x0600207E RID: 8318 RVA: 0x0007BEE0 File Offset: 0x0007A0E0
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC(flags, messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10,
			p11
		});
	}

	// Token: 0x0600207F RID: 8319 RVA: 0x0007BF78 File Offset: 0x0007A178
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC(flags, messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10,
			p11
		});
	}

	// Token: 0x06002080 RID: 8320 RVA: 0x0007C010 File Offset: 0x0007A210
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::Facepunch.NetworkView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC(flags, messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10,
			p11
		});
	}

	// Token: 0x06002081 RID: 8321 RVA: 0x0007C0A8 File Offset: 0x0007A2A8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::Facepunch.NetworkView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC(messageName, rpcMode, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10,
			p11
		});
	}

	// Token: 0x06002082 RID: 8322 RVA: 0x0007C140 File Offset: 0x0007A340
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::Facepunch.NetworkView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC(messageName, target, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10,
			p11
		});
	}

	// Token: 0x06002083 RID: 8323 RVA: 0x0007C1D8 File Offset: 0x0007A3D8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::Facepunch.NetworkView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC(messageName, targets, new object[]
		{
			p0,
			p1,
			p2,
			p3,
			p4,
			p5,
			p6,
			p7,
			p8,
			p9,
			p10,
			p11
		});
	}

	// Token: 0x06002084 RID: 8324 RVA: 0x0007C270 File Offset: 0x0007A470
	public static void RPC(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		view.RPC(flags, messageName, rpcMode);
	}

	// Token: 0x06002085 RID: 8325 RVA: 0x0007C27C File Offset: 0x0007A47C
	public static void RPC(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		view.RPC(flags, messageName, target);
	}

	// Token: 0x06002086 RID: 8326 RVA: 0x0007C288 File Offset: 0x0007A488
	public static void RPC(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		view.RPC(flags, messageName, targets);
	}

	// Token: 0x06002087 RID: 8327 RVA: 0x0007C294 File Offset: 0x0007A494
	public static void RPC(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode)
	{
		view.RPC(messageName, rpcMode);
	}

	// Token: 0x06002088 RID: 8328 RVA: 0x0007C2A0 File Offset: 0x0007A4A0
	public static void RPC(global::NGCView view, string messageName, global::uLink.NetworkPlayer target)
	{
		view.RPC(messageName, target);
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x0007C2AC File Offset: 0x0007A4AC
	public static void RPC(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		view.RPC(messageName, targets);
	}

	// Token: 0x0600208A RID: 8330 RVA: 0x0007C2B8 File Offset: 0x0007A4B8
	public static void RPC<P0>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		view.RPC<P0>(flags, messageName, rpcMode, p0);
	}

	// Token: 0x0600208B RID: 8331 RVA: 0x0007C2C8 File Offset: 0x0007A4C8
	public static void RPC<P0>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		view.RPC<P0>(flags, messageName, target, p0);
	}

	// Token: 0x0600208C RID: 8332 RVA: 0x0007C2D8 File Offset: 0x0007A4D8
	public static void RPC<P0>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		view.RPC<P0>(flags, messageName, targets, p0);
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x0007C2E8 File Offset: 0x0007A4E8
	public static void RPC<P0>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		view.RPC<P0>(messageName, rpcMode, p0);
	}

	// Token: 0x0600208E RID: 8334 RVA: 0x0007C2F4 File Offset: 0x0007A4F4
	public static void RPC<P0>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		view.RPC<P0>(messageName, target, p0);
	}

	// Token: 0x0600208F RID: 8335 RVA: 0x0007C300 File Offset: 0x0007A500
	public static void RPC<P0>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		view.RPC<P0>(messageName, targets, p0);
	}

	// Token: 0x06002090 RID: 8336 RVA: 0x0007C30C File Offset: 0x0007A50C
	public static void RPC<P0, P1>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		view.RPC<P0, P1>(flags, messageName, rpcMode, p0, p1);
	}

	// Token: 0x06002091 RID: 8337 RVA: 0x0007C31C File Offset: 0x0007A51C
	public static void RPC<P0, P1>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		view.RPC<P0, P1>(flags, messageName, target, p0, p1);
	}

	// Token: 0x06002092 RID: 8338 RVA: 0x0007C32C File Offset: 0x0007A52C
	public static void RPC<P0, P1>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		view.RPC<P0, P1>(flags, messageName, targets, p0, p1);
	}

	// Token: 0x06002093 RID: 8339 RVA: 0x0007C33C File Offset: 0x0007A53C
	public static void RPC<P0, P1>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		view.RPC<P0, P1>(messageName, rpcMode, p0, p1);
	}

	// Token: 0x06002094 RID: 8340 RVA: 0x0007C34C File Offset: 0x0007A54C
	public static void RPC<P0, P1>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		view.RPC<P0, P1>(messageName, target, p0, p1);
	}

	// Token: 0x06002095 RID: 8341 RVA: 0x0007C35C File Offset: 0x0007A55C
	public static void RPC<P0, P1>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		view.RPC<P0, P1>(messageName, targets, p0, p1);
	}

	// Token: 0x06002096 RID: 8342 RVA: 0x0007C36C File Offset: 0x0007A56C
	public static void RPC<P0, P1, P2>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		view.RPC<P0, P1, P2>(flags, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x06002097 RID: 8343 RVA: 0x0007C380 File Offset: 0x0007A580
	public static void RPC<P0, P1, P2>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		view.RPC<P0, P1, P2>(flags, messageName, target, p0, p1, p2);
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x0007C394 File Offset: 0x0007A594
	public static void RPC<P0, P1, P2>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		view.RPC<P0, P1, P2>(flags, messageName, targets, p0, p1, p2);
	}

	// Token: 0x06002099 RID: 8345 RVA: 0x0007C3A8 File Offset: 0x0007A5A8
	public static void RPC<P0, P1, P2>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		view.RPC<P0, P1, P2>(messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x0600209A RID: 8346 RVA: 0x0007C3B8 File Offset: 0x0007A5B8
	public static void RPC<P0, P1, P2>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		view.RPC<P0, P1, P2>(messageName, target, p0, p1, p2);
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x0007C3C8 File Offset: 0x0007A5C8
	public static void RPC<P0, P1, P2>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		view.RPC<P0, P1, P2>(messageName, targets, p0, p1, p2);
	}

	// Token: 0x0600209C RID: 8348 RVA: 0x0007C3D8 File Offset: 0x0007A5D8
	public static void RPC<P0, P1, P2, P3>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC<P0, P1, P2, P3>(flags, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x0600209D RID: 8349 RVA: 0x0007C3F8 File Offset: 0x0007A5F8
	public static void RPC<P0, P1, P2, P3>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC<P0, P1, P2, P3>(flags, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x0600209E RID: 8350 RVA: 0x0007C418 File Offset: 0x0007A618
	public static void RPC<P0, P1, P2, P3>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC<P0, P1, P2, P3>(flags, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x0007C438 File Offset: 0x0007A638
	public static void RPC<P0, P1, P2, P3>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC<P0, P1, P2, P3>(messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060020A0 RID: 8352 RVA: 0x0007C44C File Offset: 0x0007A64C
	public static void RPC<P0, P1, P2, P3>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC<P0, P1, P2, P3>(messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060020A1 RID: 8353 RVA: 0x0007C460 File Offset: 0x0007A660
	public static void RPC<P0, P1, P2, P3>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		view.RPC<P0, P1, P2, P3>(messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060020A2 RID: 8354 RVA: 0x0007C474 File Offset: 0x0007A674
	public static void RPC<P0, P1, P2, P3, P4>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC<P0, P1, P2, P3, P4>(flags, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060020A3 RID: 8355 RVA: 0x0007C494 File Offset: 0x0007A694
	public static void RPC<P0, P1, P2, P3, P4>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC<P0, P1, P2, P3, P4>(flags, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060020A4 RID: 8356 RVA: 0x0007C4B4 File Offset: 0x0007A6B4
	public static void RPC<P0, P1, P2, P3, P4>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC<P0, P1, P2, P3, P4>(flags, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060020A5 RID: 8357 RVA: 0x0007C4D4 File Offset: 0x0007A6D4
	public static void RPC<P0, P1, P2, P3, P4>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC<P0, P1, P2, P3, P4>(messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060020A6 RID: 8358 RVA: 0x0007C4F4 File Offset: 0x0007A6F4
	public static void RPC<P0, P1, P2, P3, P4>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC<P0, P1, P2, P3, P4>(messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060020A7 RID: 8359 RVA: 0x0007C514 File Offset: 0x0007A714
	public static void RPC<P0, P1, P2, P3, P4>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		view.RPC<P0, P1, P2, P3, P4>(messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060020A8 RID: 8360 RVA: 0x0007C534 File Offset: 0x0007A734
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC<P0, P1, P2, P3, P4, P5>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060020A9 RID: 8361 RVA: 0x0007C558 File Offset: 0x0007A758
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC<P0, P1, P2, P3, P4, P5>(flags, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060020AA RID: 8362 RVA: 0x0007C57C File Offset: 0x0007A77C
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC<P0, P1, P2, P3, P4, P5>(flags, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060020AB RID: 8363 RVA: 0x0007C5A0 File Offset: 0x0007A7A0
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC<P0, P1, P2, P3, P4, P5>(messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060020AC RID: 8364 RVA: 0x0007C5C0 File Offset: 0x0007A7C0
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC<P0, P1, P2, P3, P4, P5>(messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060020AD RID: 8365 RVA: 0x0007C5E0 File Offset: 0x0007A7E0
	public static void RPC<P0, P1, P2, P3, P4, P5>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		view.RPC<P0, P1, P2, P3, P4, P5>(messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060020AE RID: 8366 RVA: 0x0007C600 File Offset: 0x0007A800
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060020AF RID: 8367 RVA: 0x0007C624 File Offset: 0x0007A824
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6>(flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060020B0 RID: 8368 RVA: 0x0007C648 File Offset: 0x0007A848
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6>(flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060020B1 RID: 8369 RVA: 0x0007C66C File Offset: 0x0007A86C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6>(messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060020B2 RID: 8370 RVA: 0x0007C690 File Offset: 0x0007A890
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6>(messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060020B3 RID: 8371 RVA: 0x0007C6B4 File Offset: 0x0007A8B4
	public static void RPC<P0, P1, P2, P3, P4, P5, P6>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6>(messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060020B4 RID: 8372 RVA: 0x0007C6D8 File Offset: 0x0007A8D8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060020B5 RID: 8373 RVA: 0x0007C700 File Offset: 0x0007A900
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060020B6 RID: 8374 RVA: 0x0007C728 File Offset: 0x0007A928
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060020B7 RID: 8375 RVA: 0x0007C750 File Offset: 0x0007A950
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060020B8 RID: 8376 RVA: 0x0007C774 File Offset: 0x0007A974
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060020B9 RID: 8377 RVA: 0x0007C798 File Offset: 0x0007A998
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060020BA RID: 8378 RVA: 0x0007C7BC File Offset: 0x0007A9BC
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x060020BB RID: 8379 RVA: 0x0007C7E4 File Offset: 0x0007A9E4
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x060020BC RID: 8380 RVA: 0x0007C80C File Offset: 0x0007AA0C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x060020BD RID: 8381 RVA: 0x0007C834 File Offset: 0x0007AA34
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x060020BE RID: 8382 RVA: 0x0007C85C File Offset: 0x0007AA5C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x060020BF RID: 8383 RVA: 0x0007C884 File Offset: 0x0007AA84
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x060020C0 RID: 8384 RVA: 0x0007C8AC File Offset: 0x0007AAAC
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x060020C1 RID: 8385 RVA: 0x0007C8D8 File Offset: 0x0007AAD8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x060020C2 RID: 8386 RVA: 0x0007C904 File Offset: 0x0007AB04
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x060020C3 RID: 8387 RVA: 0x0007C930 File Offset: 0x0007AB30
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x060020C4 RID: 8388 RVA: 0x0007C958 File Offset: 0x0007AB58
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x060020C5 RID: 8389 RVA: 0x0007C980 File Offset: 0x0007AB80
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x060020C6 RID: 8390 RVA: 0x0007C9A8 File Offset: 0x0007ABA8
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x060020C7 RID: 8391 RVA: 0x0007C9D4 File Offset: 0x0007ABD4
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x060020C8 RID: 8392 RVA: 0x0007CA00 File Offset: 0x0007AC00
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x060020C9 RID: 8393 RVA: 0x0007CA2C File Offset: 0x0007AC2C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x060020CA RID: 8394 RVA: 0x0007CA58 File Offset: 0x0007AC58
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x0007CA84 File Offset: 0x0007AC84
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x0007CAB0 File Offset: 0x0007ACB0
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x060020CD RID: 8397 RVA: 0x0007CAE0 File Offset: 0x0007ACE0
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x060020CE RID: 8398 RVA: 0x0007CB10 File Offset: 0x0007AD10
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NGCView view, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x060020CF RID: 8399 RVA: 0x0007CB40 File Offset: 0x0007AD40
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NGCView view, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x060020D0 RID: 8400 RVA: 0x0007CB6C File Offset: 0x0007AD6C
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NGCView view, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x0007CB98 File Offset: 0x0007AD98
	public static void RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NGCView view, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		view.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x060020D2 RID: 8402 RVA: 0x0007CBC4 File Offset: 0x0007ADC4
	public static bool RPC(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC(networkView, flags, messageName, rpcMode);
		return true;
	}

	// Token: 0x060020D3 RID: 8403 RVA: 0x0007CC08 File Offset: 0x0007AE08
	public static bool RPC(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC(networkView, flags, messageName, target);
		return true;
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x0007CC4C File Offset: 0x0007AE4C
	public static bool RPC(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC(networkView, flags, messageName, targets);
		return true;
	}

	// Token: 0x060020D5 RID: 8405 RVA: 0x0007CC90 File Offset: 0x0007AE90
	public static bool RPC(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC(networkView, messageName, rpcMode);
		return true;
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x0007CCD0 File Offset: 0x0007AED0
	public static bool RPC(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC(networkView, messageName, target);
		return true;
	}

	// Token: 0x060020D7 RID: 8407 RVA: 0x0007CD10 File Offset: 0x0007AF10
	public static bool RPC(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC(networkView, messageName, targets);
		return true;
	}

	// Token: 0x060020D8 RID: 8408 RVA: 0x0007CD50 File Offset: 0x0007AF50
	public static bool RPC<P0>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(networkView, flags, messageName, rpcMode, p0);
		return true;
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x0007CD94 File Offset: 0x0007AF94
	public static bool RPC<P0>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(networkView, flags, messageName, target, p0);
		return true;
	}

	// Token: 0x060020DA RID: 8410 RVA: 0x0007CDD8 File Offset: 0x0007AFD8
	public static bool RPC<P0>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(networkView, flags, messageName, targets, p0);
		return true;
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x0007CE1C File Offset: 0x0007B01C
	public static bool RPC<P0>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(networkView, messageName, rpcMode, p0);
		return true;
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x0007CE60 File Offset: 0x0007B060
	public static bool RPC<P0>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(networkView, messageName, target, p0);
		return true;
	}

	// Token: 0x060020DD RID: 8413 RVA: 0x0007CEA4 File Offset: 0x0007B0A4
	public static bool RPC<P0>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(networkView, messageName, targets, p0);
		return true;
	}

	// Token: 0x060020DE RID: 8414 RVA: 0x0007CEE8 File Offset: 0x0007B0E8
	public static bool RPC<P0, P1>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(networkView, flags, messageName, rpcMode, p0, p1);
		return true;
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x0007CF30 File Offset: 0x0007B130
	public static bool RPC<P0, P1>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(networkView, flags, messageName, target, p0, p1);
		return true;
	}

	// Token: 0x060020E0 RID: 8416 RVA: 0x0007CF78 File Offset: 0x0007B178
	public static bool RPC<P0, P1>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(networkView, flags, messageName, targets, p0, p1);
		return true;
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x0007CFC0 File Offset: 0x0007B1C0
	public static bool RPC<P0, P1>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(networkView, messageName, rpcMode, p0, p1);
		return true;
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x0007D004 File Offset: 0x0007B204
	public static bool RPC<P0, P1>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(networkView, messageName, target, p0, p1);
		return true;
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x0007D048 File Offset: 0x0007B248
	public static bool RPC<P0, P1>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(networkView, messageName, targets, p0, p1);
		return true;
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x0007D08C File Offset: 0x0007B28C
	public static bool RPC<P0, P1, P2>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(networkView, flags, messageName, rpcMode, p0, p1, p2);
		return true;
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x0007D0D4 File Offset: 0x0007B2D4
	public static bool RPC<P0, P1, P2>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(networkView, flags, messageName, target, p0, p1, p2);
		return true;
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x0007D11C File Offset: 0x0007B31C
	public static bool RPC<P0, P1, P2>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(networkView, flags, messageName, targets, p0, p1, p2);
		return true;
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x0007D164 File Offset: 0x0007B364
	public static bool RPC<P0, P1, P2>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(networkView, messageName, rpcMode, p0, p1, p2);
		return true;
	}

	// Token: 0x060020E8 RID: 8424 RVA: 0x0007D1AC File Offset: 0x0007B3AC
	public static bool RPC<P0, P1, P2>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(networkView, messageName, target, p0, p1, p2);
		return true;
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x0007D1F4 File Offset: 0x0007B3F4
	public static bool RPC<P0, P1, P2>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(networkView, messageName, targets, p0, p1, p2);
		return true;
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x0007D23C File Offset: 0x0007B43C
	public static bool RPC<P0, P1, P2, P3>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x0007D288 File Offset: 0x0007B488
	public static bool RPC<P0, P1, P2, P3>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(networkView, flags, messageName, target, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x0007D2D4 File Offset: 0x0007B4D4
	public static bool RPC<P0, P1, P2, P3>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(networkView, flags, messageName, targets, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x060020ED RID: 8429 RVA: 0x0007D320 File Offset: 0x0007B520
	public static bool RPC<P0, P1, P2, P3>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(networkView, messageName, rpcMode, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x0007D368 File Offset: 0x0007B568
	public static bool RPC<P0, P1, P2, P3>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(networkView, messageName, target, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x0007D3B0 File Offset: 0x0007B5B0
	public static bool RPC<P0, P1, P2, P3>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(networkView, messageName, targets, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x0007D3F8 File Offset: 0x0007B5F8
	public static bool RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x0007D444 File Offset: 0x0007B644
	public static bool RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(networkView, flags, messageName, target, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x0007D490 File Offset: 0x0007B690
	public static bool RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x0007D4DC File Offset: 0x0007B6DC
	public static bool RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x0007D528 File Offset: 0x0007B728
	public static bool RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(networkView, messageName, target, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x0007D574 File Offset: 0x0007B774
	public static bool RPC<P0, P1, P2, P3, P4>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(networkView, messageName, targets, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x0007D5C0 File Offset: 0x0007B7C0
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x0007D610 File Offset: 0x0007B810
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x0007D660 File Offset: 0x0007B860
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x0007D6B0 File Offset: 0x0007B8B0
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x0007D6FC File Offset: 0x0007B8FC
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(networkView, messageName, target, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x0007D748 File Offset: 0x0007B948
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x0007D794 File Offset: 0x0007B994
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x0007D7E4 File Offset: 0x0007B9E4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x0007D834 File Offset: 0x0007BA34
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x0007D884 File Offset: 0x0007BA84
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x0007D8D4 File Offset: 0x0007BAD4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(networkView, messageName, target, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x06002101 RID: 8449 RVA: 0x0007D924 File Offset: 0x0007BB24
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x0007D974 File Offset: 0x0007BB74
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002103 RID: 8451 RVA: 0x0007D9C8 File Offset: 0x0007BBC8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x0007DA1C File Offset: 0x0007BC1C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002105 RID: 8453 RVA: 0x0007DA70 File Offset: 0x0007BC70
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x0007DAC0 File Offset: 0x0007BCC0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(networkView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x0007DB10 File Offset: 0x0007BD10
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002108 RID: 8456 RVA: 0x0007DB60 File Offset: 0x0007BD60
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x0007DBB4 File Offset: 0x0007BDB4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600210A RID: 8458 RVA: 0x0007DC08 File Offset: 0x0007BE08
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x0007DC5C File Offset: 0x0007BE5C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x0007DCB0 File Offset: 0x0007BEB0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(networkView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600210D RID: 8461 RVA: 0x0007DD04 File Offset: 0x0007BF04
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x0007DD58 File Offset: 0x0007BF58
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x0007DDB0 File Offset: 0x0007BFB0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x0007DE08 File Offset: 0x0007C008
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x0007DE60 File Offset: 0x0007C060
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002112 RID: 8466 RVA: 0x0007DEB4 File Offset: 0x0007C0B4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(networkView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002113 RID: 8467 RVA: 0x0007DF08 File Offset: 0x0007C108
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x0007DF5C File Offset: 0x0007C15C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x0007DFB4 File Offset: 0x0007C1B4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002116 RID: 8470 RVA: 0x0007E00C File Offset: 0x0007C20C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x0007E064 File Offset: 0x0007C264
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x0007E0BC File Offset: 0x0007C2BC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(networkView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x0007E114 File Offset: 0x0007C314
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x0007E16C File Offset: 0x0007C36C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(networkView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600211B RID: 8475 RVA: 0x0007E1C8 File Offset: 0x0007C3C8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(networkView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x0007E224 File Offset: 0x0007C424
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkViewID viewID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(networkView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x0007E280 File Offset: 0x0007C480
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(networkView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600211E RID: 8478 RVA: 0x0007E2D8 File Offset: 0x0007C4D8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkViewID viewID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(networkView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x0007E330 File Offset: 0x0007C530
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::uLink.NetworkViewID viewID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (!networkView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No Network View with id {0} to send RPC \"{1}\"", viewID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(networkView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x0007E388 File Offset: 0x0007C588
	public static bool RPC(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC(ngcView, flags, messageName, rpcMode);
		return true;
	}

	// Token: 0x06002121 RID: 8481 RVA: 0x0007E3E8 File Offset: 0x0007C5E8
	public static bool RPC(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC((global::uLink.NetworkViewID)entID, flags, messageName, target);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC(ngcView, flags, messageName, target);
		return true;
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x0007E448 File Offset: 0x0007C648
	public static bool RPC(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC((global::uLink.NetworkViewID)entID, flags, messageName, targets);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC(ngcView, flags, messageName, targets);
		return true;
	}

	// Token: 0x06002123 RID: 8483 RVA: 0x0007E4A8 File Offset: 0x0007C6A8
	public static bool RPC(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC((global::uLink.NetworkViewID)entID, messageName, rpcMode);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC(ngcView, messageName, rpcMode);
		return true;
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x0007E504 File Offset: 0x0007C704
	public static bool RPC(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC((global::uLink.NetworkViewID)entID, messageName, target);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC(ngcView, messageName, target);
		return true;
	}

	// Token: 0x06002125 RID: 8485 RVA: 0x0007E560 File Offset: 0x0007C760
	public static bool RPC(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC((global::uLink.NetworkViewID)entID, messageName, targets);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC(ngcView, messageName, targets);
		return true;
	}

	// Token: 0x06002126 RID: 8486 RVA: 0x0007E5BC File Offset: 0x0007C7BC
	public static bool RPC<P0>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(ngcView, flags, messageName, rpcMode, p0);
		return true;
	}

	// Token: 0x06002127 RID: 8487 RVA: 0x0007E620 File Offset: 0x0007C820
	public static bool RPC<P0>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(ngcView, flags, messageName, target, p0);
		return true;
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x0007E684 File Offset: 0x0007C884
	public static bool RPC<P0>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(ngcView, flags, messageName, targets, p0);
		return true;
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x0007E6E8 File Offset: 0x0007C8E8
	public static bool RPC<P0>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(ngcView, messageName, rpcMode, p0);
		return true;
	}

	// Token: 0x0600212A RID: 8490 RVA: 0x0007E748 File Offset: 0x0007C948
	public static bool RPC<P0>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0>((global::uLink.NetworkViewID)entID, messageName, target, p0);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(ngcView, messageName, target, p0);
		return true;
	}

	// Token: 0x0600212B RID: 8491 RVA: 0x0007E7A8 File Offset: 0x0007C9A8
	public static bool RPC<P0>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0>((global::uLink.NetworkViewID)entID, messageName, targets, p0);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0>(ngcView, messageName, targets, p0);
		return true;
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x0007E808 File Offset: 0x0007CA08
	public static bool RPC<P0, P1>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(ngcView, flags, messageName, rpcMode, p0, p1);
		return true;
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x0007E870 File Offset: 0x0007CA70
	public static bool RPC<P0, P1>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(ngcView, flags, messageName, target, p0, p1);
		return true;
	}

	// Token: 0x0600212E RID: 8494 RVA: 0x0007E8D8 File Offset: 0x0007CAD8
	public static bool RPC<P0, P1>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(ngcView, flags, messageName, targets, p0, p1);
		return true;
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x0007E940 File Offset: 0x0007CB40
	public static bool RPC<P0, P1>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(ngcView, messageName, rpcMode, p0, p1);
		return true;
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x0007E9A4 File Offset: 0x0007CBA4
	public static bool RPC<P0, P1>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(ngcView, messageName, target, p0, p1);
		return true;
	}

	// Token: 0x06002131 RID: 8497 RVA: 0x0007EA08 File Offset: 0x0007CC08
	public static bool RPC<P0, P1>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1>(ngcView, messageName, targets, p0, p1);
		return true;
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x0007EA6C File Offset: 0x0007CC6C
	public static bool RPC<P0, P1, P2>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(ngcView, flags, messageName, rpcMode, p0, p1, p2);
		return true;
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x0007EAD8 File Offset: 0x0007CCD8
	public static bool RPC<P0, P1, P2>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(ngcView, flags, messageName, target, p0, p1, p2);
		return true;
	}

	// Token: 0x06002134 RID: 8500 RVA: 0x0007EB44 File Offset: 0x0007CD44
	public static bool RPC<P0, P1, P2>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(ngcView, flags, messageName, targets, p0, p1, p2);
		return true;
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x0007EBB0 File Offset: 0x0007CDB0
	public static bool RPC<P0, P1, P2>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(ngcView, messageName, rpcMode, p0, p1, p2);
		return true;
	}

	// Token: 0x06002136 RID: 8502 RVA: 0x0007EC18 File Offset: 0x0007CE18
	public static bool RPC<P0, P1, P2>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(ngcView, messageName, target, p0, p1, p2);
		return true;
	}

	// Token: 0x06002137 RID: 8503 RVA: 0x0007EC80 File Offset: 0x0007CE80
	public static bool RPC<P0, P1, P2>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2>(ngcView, messageName, targets, p0, p1, p2);
		return true;
	}

	// Token: 0x06002138 RID: 8504 RVA: 0x0007ECE8 File Offset: 0x0007CEE8
	public static bool RPC<P0, P1, P2, P3>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x0007ED58 File Offset: 0x0007CF58
	public static bool RPC<P0, P1, P2, P3>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(ngcView, flags, messageName, target, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x0007EDC8 File Offset: 0x0007CFC8
	public static bool RPC<P0, P1, P2, P3>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(ngcView, flags, messageName, targets, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x0007EE38 File Offset: 0x0007D038
	public static bool RPC<P0, P1, P2, P3>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(ngcView, messageName, rpcMode, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x0007EEA4 File Offset: 0x0007D0A4
	public static bool RPC<P0, P1, P2, P3>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(ngcView, messageName, target, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x0007EF10 File Offset: 0x0007D110
	public static bool RPC<P0, P1, P2, P3>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3>(ngcView, messageName, targets, p0, p1, p2, p3);
		return true;
	}

	// Token: 0x0600213E RID: 8510 RVA: 0x0007EF7C File Offset: 0x0007D17C
	public static bool RPC<P0, P1, P2, P3, P4>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x0600213F RID: 8511 RVA: 0x0007EFF0 File Offset: 0x0007D1F0
	public static bool RPC<P0, P1, P2, P3, P4>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x06002140 RID: 8512 RVA: 0x0007F064 File Offset: 0x0007D264
	public static bool RPC<P0, P1, P2, P3, P4>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x0007F0D8 File Offset: 0x0007D2D8
	public static bool RPC<P0, P1, P2, P3, P4>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x06002142 RID: 8514 RVA: 0x0007F148 File Offset: 0x0007D348
	public static bool RPC<P0, P1, P2, P3, P4>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(ngcView, messageName, target, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x06002143 RID: 8515 RVA: 0x0007F1B8 File Offset: 0x0007D3B8
	public static bool RPC<P0, P1, P2, P3, P4>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4>(ngcView, messageName, targets, p0, p1, p2, p3, p4);
		return true;
	}

	// Token: 0x06002144 RID: 8516 RVA: 0x0007F228 File Offset: 0x0007D428
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x06002145 RID: 8517 RVA: 0x0007F2A0 File Offset: 0x0007D4A0
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x06002146 RID: 8518 RVA: 0x0007F318 File Offset: 0x0007D518
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x0007F390 File Offset: 0x0007D590
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x06002148 RID: 8520 RVA: 0x0007F404 File Offset: 0x0007D604
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x06002149 RID: 8521 RVA: 0x0007F478 File Offset: 0x0007D678
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5);
		return true;
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x0007F4EC File Offset: 0x0007D6EC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x0007F568 File Offset: 0x0007D768
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x0007F5E4 File Offset: 0x0007D7E4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x0007F660 File Offset: 0x0007D860
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x0600214E RID: 8526 RVA: 0x0007F6D8 File Offset: 0x0007D8D8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5, p6);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x0007F750 File Offset: 0x0007D950
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
		return true;
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x0007F7C8 File Offset: 0x0007D9C8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002151 RID: 8529 RVA: 0x0007F848 File Offset: 0x0007DA48
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x0007F8C8 File Offset: 0x0007DAC8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x0007F948 File Offset: 0x0007DB48
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002154 RID: 8532 RVA: 0x0007F9C4 File Offset: 0x0007DBC4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002155 RID: 8533 RVA: 0x0007FA40 File Offset: 0x0007DC40
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
		return true;
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x0007FABC File Offset: 0x0007DCBC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x06002157 RID: 8535 RVA: 0x0007FB40 File Offset: 0x0007DD40
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x06002158 RID: 8536 RVA: 0x0007FBC4 File Offset: 0x0007DDC4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x06002159 RID: 8537 RVA: 0x0007FC48 File Offset: 0x0007DE48
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x0007FCC8 File Offset: 0x0007DEC8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x0007FD48 File Offset: 0x0007DF48
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		return true;
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x0007FDC8 File Offset: 0x0007DFC8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x0600215D RID: 8541 RVA: 0x0007FE50 File Offset: 0x0007E050
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x0600215E RID: 8542 RVA: 0x0007FED8 File Offset: 0x0007E0D8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x0600215F RID: 8543 RVA: 0x0007FF60 File Offset: 0x0007E160
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x0007FFE4 File Offset: 0x0007E1E4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002161 RID: 8545 RVA: 0x00080068 File Offset: 0x0007E268
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
		return true;
	}

	// Token: 0x06002162 RID: 8546 RVA: 0x000800EC File Offset: 0x0007E2EC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x00080178 File Offset: 0x0007E378
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002164 RID: 8548 RVA: 0x00080204 File Offset: 0x0007E404
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002165 RID: 8549 RVA: 0x00080290 File Offset: 0x0007E490
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002166 RID: 8550 RVA: 0x00080318 File Offset: 0x0007E518
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002167 RID: 8551 RVA: 0x000803A0 File Offset: 0x0007E5A0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		return true;
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x00080428 File Offset: 0x0007E628
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>((global::uLink.NetworkViewID)entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(ngcView, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x06002169 RID: 8553 RVA: 0x000804B8 File Offset: 0x0007E6B8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>((global::uLink.NetworkViewID)entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(ngcView, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600216A RID: 8554 RVA: 0x00080548 File Offset: 0x0007E748
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NetEntityID entID, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>((global::uLink.NetworkViewID)entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(ngcView, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600216B RID: 8555 RVA: 0x000805D8 File Offset: 0x0007E7D8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NetEntityID entID, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>((global::uLink.NetworkViewID)entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(ngcView, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600216C RID: 8556 RVA: 0x00080664 File Offset: 0x0007E864
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NetEntityID entID, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>((global::uLink.NetworkViewID)entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(ngcView, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600216D RID: 8557 RVA: 0x000806F0 File Offset: 0x0007E8F0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::NetEntityID entID, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		if (!entID.isNGC)
		{
			return global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>((global::uLink.NetworkViewID)entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}
		global::NGCView ngcView = entID.ngcView;
		if (!ngcView)
		{
			global::UnityEngine.Debug.LogError(string.Format("No NGC View with id {0} to send RPC \"{1}\"", entID, messageName));
			return false;
		}
		global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(ngcView, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		return true;
	}

	// Token: 0x0600216E RID: 8558 RVA: 0x0008077C File Offset: 0x0007E97C
	public static bool RPC(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, rpcMode);
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x000807A4 File Offset: 0x0007E9A4
	public static bool RPC(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, target);
	}

	// Token: 0x06002170 RID: 8560 RVA: 0x000807CC File Offset: 0x0007E9CC
	public static bool RPC(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, targets);
	}

	// Token: 0x06002171 RID: 8561 RVA: 0x000807F4 File Offset: 0x0007E9F4
	public static bool RPC(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC(entID, messageName, rpcMode);
	}

	// Token: 0x06002172 RID: 8562 RVA: 0x0008081C File Offset: 0x0007EA1C
	public static bool RPC(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC(entID, messageName, target);
	}

	// Token: 0x06002173 RID: 8563 RVA: 0x00080844 File Offset: 0x0007EA44
	public static bool RPC(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC(entID, messageName, targets);
	}

	// Token: 0x06002174 RID: 8564 RVA: 0x0008086C File Offset: 0x0007EA6C
	public static bool RPC(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, rpcMode);
	}

	// Token: 0x06002175 RID: 8565 RVA: 0x00080894 File Offset: 0x0007EA94
	public static bool RPC(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, target);
	}

	// Token: 0x06002176 RID: 8566 RVA: 0x000808BC File Offset: 0x0007EABC
	public static bool RPC(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, targets);
	}

	// Token: 0x06002177 RID: 8567 RVA: 0x000808E4 File Offset: 0x0007EAE4
	public static bool RPC(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC(entID, messageName, rpcMode);
	}

	// Token: 0x06002178 RID: 8568 RVA: 0x0008090C File Offset: 0x0007EB0C
	public static bool RPC(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC(entID, messageName, target);
	}

	// Token: 0x06002179 RID: 8569 RVA: 0x00080934 File Offset: 0x0007EB34
	public static bool RPC(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC(entID, messageName, targets);
	}

	// Token: 0x0600217A RID: 8570 RVA: 0x0008095C File Offset: 0x0007EB5C
	public static bool RPC(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, rpcMode);
	}

	// Token: 0x0600217B RID: 8571 RVA: 0x00080984 File Offset: 0x0007EB84
	public static bool RPC(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, target);
	}

	// Token: 0x0600217C RID: 8572 RVA: 0x000809AC File Offset: 0x0007EBAC
	public static bool RPC(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC(entID, flags, messageName, targets);
	}

	// Token: 0x0600217D RID: 8573 RVA: 0x000809D4 File Offset: 0x0007EBD4
	public static bool RPC(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC(entID, messageName, rpcMode);
	}

	// Token: 0x0600217E RID: 8574 RVA: 0x000809FC File Offset: 0x0007EBFC
	public static bool RPC(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC(entID, messageName, target);
	}

	// Token: 0x0600217F RID: 8575 RVA: 0x00080A24 File Offset: 0x0007EC24
	public static bool RPC(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC(entID, messageName, targets);
	}

	// Token: 0x06002180 RID: 8576 RVA: 0x00080A4C File Offset: 0x0007EC4C
	public static bool RPC<P0>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, rpcMode, p0);
	}

	// Token: 0x06002181 RID: 8577 RVA: 0x00080A74 File Offset: 0x0007EC74
	public static bool RPC<P0>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, target, p0);
	}

	// Token: 0x06002182 RID: 8578 RVA: 0x00080A9C File Offset: 0x0007EC9C
	public static bool RPC<P0>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, targets, p0);
	}

	// Token: 0x06002183 RID: 8579 RVA: 0x00080AC4 File Offset: 0x0007ECC4
	public static bool RPC<P0>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, rpcMode, p0);
	}

	// Token: 0x06002184 RID: 8580 RVA: 0x00080AEC File Offset: 0x0007ECEC
	public static bool RPC<P0>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, target, p0);
	}

	// Token: 0x06002185 RID: 8581 RVA: 0x00080B14 File Offset: 0x0007ED14
	public static bool RPC<P0>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, targets, p0);
	}

	// Token: 0x06002186 RID: 8582 RVA: 0x00080B3C File Offset: 0x0007ED3C
	public static bool RPC<P0>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, rpcMode, p0);
	}

	// Token: 0x06002187 RID: 8583 RVA: 0x00080B64 File Offset: 0x0007ED64
	public static bool RPC<P0>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, target, p0);
	}

	// Token: 0x06002188 RID: 8584 RVA: 0x00080B8C File Offset: 0x0007ED8C
	public static bool RPC<P0>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, targets, p0);
	}

	// Token: 0x06002189 RID: 8585 RVA: 0x00080BB4 File Offset: 0x0007EDB4
	public static bool RPC<P0>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, rpcMode, p0);
	}

	// Token: 0x0600218A RID: 8586 RVA: 0x00080BDC File Offset: 0x0007EDDC
	public static bool RPC<P0>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, target, p0);
	}

	// Token: 0x0600218B RID: 8587 RVA: 0x00080C04 File Offset: 0x0007EE04
	public static bool RPC<P0>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, targets, p0);
	}

	// Token: 0x0600218C RID: 8588 RVA: 0x00080C2C File Offset: 0x0007EE2C
	public static bool RPC<P0>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, rpcMode, p0);
	}

	// Token: 0x0600218D RID: 8589 RVA: 0x00080C54 File Offset: 0x0007EE54
	public static bool RPC<P0>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, target, p0);
	}

	// Token: 0x0600218E RID: 8590 RVA: 0x00080C7C File Offset: 0x0007EE7C
	public static bool RPC<P0>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0>(entID, flags, messageName, targets, p0);
	}

	// Token: 0x0600218F RID: 8591 RVA: 0x00080CA4 File Offset: 0x0007EEA4
	public static bool RPC<P0>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, rpcMode, p0);
	}

	// Token: 0x06002190 RID: 8592 RVA: 0x00080CCC File Offset: 0x0007EECC
	public static bool RPC<P0>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, target, p0);
	}

	// Token: 0x06002191 RID: 8593 RVA: 0x00080CF4 File Offset: 0x0007EEF4
	public static bool RPC<P0>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0>(entID, messageName, targets, p0);
	}

	// Token: 0x06002192 RID: 8594 RVA: 0x00080D1C File Offset: 0x0007EF1C
	public static bool RPC<P0, P1>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, rpcMode, p0, p1);
	}

	// Token: 0x06002193 RID: 8595 RVA: 0x00080D48 File Offset: 0x0007EF48
	public static bool RPC<P0, P1>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, target, p0, p1);
	}

	// Token: 0x06002194 RID: 8596 RVA: 0x00080D74 File Offset: 0x0007EF74
	public static bool RPC<P0, P1>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, targets, p0, p1);
	}

	// Token: 0x06002195 RID: 8597 RVA: 0x00080DA0 File Offset: 0x0007EFA0
	public static bool RPC<P0, P1>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, rpcMode, p0, p1);
	}

	// Token: 0x06002196 RID: 8598 RVA: 0x00080DC8 File Offset: 0x0007EFC8
	public static bool RPC<P0, P1>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, target, p0, p1);
	}

	// Token: 0x06002197 RID: 8599 RVA: 0x00080DF0 File Offset: 0x0007EFF0
	public static bool RPC<P0, P1>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, targets, p0, p1);
	}

	// Token: 0x06002198 RID: 8600 RVA: 0x00080E18 File Offset: 0x0007F018
	public static bool RPC<P0, P1>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, rpcMode, p0, p1);
	}

	// Token: 0x06002199 RID: 8601 RVA: 0x00080E44 File Offset: 0x0007F044
	public static bool RPC<P0, P1>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, target, p0, p1);
	}

	// Token: 0x0600219A RID: 8602 RVA: 0x00080E70 File Offset: 0x0007F070
	public static bool RPC<P0, P1>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, targets, p0, p1);
	}

	// Token: 0x0600219B RID: 8603 RVA: 0x00080E9C File Offset: 0x0007F09C
	public static bool RPC<P0, P1>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, rpcMode, p0, p1);
	}

	// Token: 0x0600219C RID: 8604 RVA: 0x00080EC4 File Offset: 0x0007F0C4
	public static bool RPC<P0, P1>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, target, p0, p1);
	}

	// Token: 0x0600219D RID: 8605 RVA: 0x00080EEC File Offset: 0x0007F0EC
	public static bool RPC<P0, P1>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, targets, p0, p1);
	}

	// Token: 0x0600219E RID: 8606 RVA: 0x00080F14 File Offset: 0x0007F114
	public static bool RPC<P0, P1>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, rpcMode, p0, p1);
	}

	// Token: 0x0600219F RID: 8607 RVA: 0x00080F40 File Offset: 0x0007F140
	public static bool RPC<P0, P1>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, target, p0, p1);
	}

	// Token: 0x060021A0 RID: 8608 RVA: 0x00080F6C File Offset: 0x0007F16C
	public static bool RPC<P0, P1>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, flags, messageName, targets, p0, p1);
	}

	// Token: 0x060021A1 RID: 8609 RVA: 0x00080F98 File Offset: 0x0007F198
	public static bool RPC<P0, P1>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, rpcMode, p0, p1);
	}

	// Token: 0x060021A2 RID: 8610 RVA: 0x00080FC0 File Offset: 0x0007F1C0
	public static bool RPC<P0, P1>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, target, p0, p1);
	}

	// Token: 0x060021A3 RID: 8611 RVA: 0x00080FE8 File Offset: 0x0007F1E8
	public static bool RPC<P0, P1>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1>(entID, messageName, targets, p0, p1);
	}

	// Token: 0x060021A4 RID: 8612 RVA: 0x00081010 File Offset: 0x0007F210
	public static bool RPC<P0, P1, P2>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x060021A5 RID: 8613 RVA: 0x0008103C File Offset: 0x0007F23C
	public static bool RPC<P0, P1, P2>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, target, p0, p1, p2);
	}

	// Token: 0x060021A6 RID: 8614 RVA: 0x00081068 File Offset: 0x0007F268
	public static bool RPC<P0, P1, P2>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, targets, p0, p1, p2);
	}

	// Token: 0x060021A7 RID: 8615 RVA: 0x00081094 File Offset: 0x0007F294
	public static bool RPC<P0, P1, P2>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x060021A8 RID: 8616 RVA: 0x000810C0 File Offset: 0x0007F2C0
	public static bool RPC<P0, P1, P2>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, target, p0, p1, p2);
	}

	// Token: 0x060021A9 RID: 8617 RVA: 0x000810EC File Offset: 0x0007F2EC
	public static bool RPC<P0, P1, P2>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, targets, p0, p1, p2);
	}

	// Token: 0x060021AA RID: 8618 RVA: 0x00081118 File Offset: 0x0007F318
	public static bool RPC<P0, P1, P2>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x060021AB RID: 8619 RVA: 0x00081144 File Offset: 0x0007F344
	public static bool RPC<P0, P1, P2>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, target, p0, p1, p2);
	}

	// Token: 0x060021AC RID: 8620 RVA: 0x00081170 File Offset: 0x0007F370
	public static bool RPC<P0, P1, P2>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, targets, p0, p1, p2);
	}

	// Token: 0x060021AD RID: 8621 RVA: 0x0008119C File Offset: 0x0007F39C
	public static bool RPC<P0, P1, P2>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x060021AE RID: 8622 RVA: 0x000811C8 File Offset: 0x0007F3C8
	public static bool RPC<P0, P1, P2>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, target, p0, p1, p2);
	}

	// Token: 0x060021AF RID: 8623 RVA: 0x000811F4 File Offset: 0x0007F3F4
	public static bool RPC<P0, P1, P2>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, targets, p0, p1, p2);
	}

	// Token: 0x060021B0 RID: 8624 RVA: 0x00081220 File Offset: 0x0007F420
	public static bool RPC<P0, P1, P2>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x060021B1 RID: 8625 RVA: 0x0008124C File Offset: 0x0007F44C
	public static bool RPC<P0, P1, P2>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, target, p0, p1, p2);
	}

	// Token: 0x060021B2 RID: 8626 RVA: 0x00081278 File Offset: 0x0007F478
	public static bool RPC<P0, P1, P2>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, flags, messageName, targets, p0, p1, p2);
	}

	// Token: 0x060021B3 RID: 8627 RVA: 0x000812A4 File Offset: 0x0007F4A4
	public static bool RPC<P0, P1, P2>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, rpcMode, p0, p1, p2);
	}

	// Token: 0x060021B4 RID: 8628 RVA: 0x000812D0 File Offset: 0x0007F4D0
	public static bool RPC<P0, P1, P2>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, target, p0, p1, p2);
	}

	// Token: 0x060021B5 RID: 8629 RVA: 0x000812FC File Offset: 0x0007F4FC
	public static bool RPC<P0, P1, P2>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2>(entID, messageName, targets, p0, p1, p2);
	}

	// Token: 0x060021B6 RID: 8630 RVA: 0x00081328 File Offset: 0x0007F528
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060021B7 RID: 8631 RVA: 0x00081358 File Offset: 0x0007F558
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060021B8 RID: 8632 RVA: 0x00081388 File Offset: 0x0007F588
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060021B9 RID: 8633 RVA: 0x000813B8 File Offset: 0x0007F5B8
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060021BA RID: 8634 RVA: 0x000813E4 File Offset: 0x0007F5E4
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060021BB RID: 8635 RVA: 0x00081410 File Offset: 0x0007F610
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060021BC RID: 8636 RVA: 0x0008143C File Offset: 0x0007F63C
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060021BD RID: 8637 RVA: 0x0008146C File Offset: 0x0007F66C
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060021BE RID: 8638 RVA: 0x0008149C File Offset: 0x0007F69C
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060021BF RID: 8639 RVA: 0x000814CC File Offset: 0x0007F6CC
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060021C0 RID: 8640 RVA: 0x000814F8 File Offset: 0x0007F6F8
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060021C1 RID: 8641 RVA: 0x00081524 File Offset: 0x0007F724
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060021C2 RID: 8642 RVA: 0x00081550 File Offset: 0x0007F750
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060021C3 RID: 8643 RVA: 0x00081580 File Offset: 0x0007F780
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060021C4 RID: 8644 RVA: 0x000815B0 File Offset: 0x0007F7B0
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, flags, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060021C5 RID: 8645 RVA: 0x000815E0 File Offset: 0x0007F7E0
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, rpcMode, p0, p1, p2, p3);
	}

	// Token: 0x060021C6 RID: 8646 RVA: 0x0008160C File Offset: 0x0007F80C
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, target, p0, p1, p2, p3);
	}

	// Token: 0x060021C7 RID: 8647 RVA: 0x00081638 File Offset: 0x0007F838
	public static bool RPC<P0, P1, P2, P3>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3>(entID, messageName, targets, p0, p1, p2, p3);
	}

	// Token: 0x060021C8 RID: 8648 RVA: 0x00081664 File Offset: 0x0007F864
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021C9 RID: 8649 RVA: 0x00081694 File Offset: 0x0007F894
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021CA RID: 8650 RVA: 0x000816C4 File Offset: 0x0007F8C4
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021CB RID: 8651 RVA: 0x000816F4 File Offset: 0x0007F8F4
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021CC RID: 8652 RVA: 0x00081724 File Offset: 0x0007F924
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021CD RID: 8653 RVA: 0x00081754 File Offset: 0x0007F954
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021CE RID: 8654 RVA: 0x00081784 File Offset: 0x0007F984
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021CF RID: 8655 RVA: 0x000817B4 File Offset: 0x0007F9B4
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D0 RID: 8656 RVA: 0x000817E4 File Offset: 0x0007F9E4
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D1 RID: 8657 RVA: 0x00081814 File Offset: 0x0007FA14
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D2 RID: 8658 RVA: 0x00081844 File Offset: 0x0007FA44
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D3 RID: 8659 RVA: 0x00081874 File Offset: 0x0007FA74
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D4 RID: 8660 RVA: 0x000818A4 File Offset: 0x0007FAA4
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D5 RID: 8661 RVA: 0x000818D4 File Offset: 0x0007FAD4
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D6 RID: 8662 RVA: 0x00081904 File Offset: 0x0007FB04
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, flags, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D7 RID: 8663 RVA: 0x00081934 File Offset: 0x0007FB34
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, rpcMode, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D8 RID: 8664 RVA: 0x00081964 File Offset: 0x0007FB64
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, target, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021D9 RID: 8665 RVA: 0x00081994 File Offset: 0x0007FB94
	public static bool RPC<P0, P1, P2, P3, P4>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4>(entID, messageName, targets, p0, p1, p2, p3, p4);
	}

	// Token: 0x060021DA RID: 8666 RVA: 0x000819C4 File Offset: 0x0007FBC4
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021DB RID: 8667 RVA: 0x000819F8 File Offset: 0x0007FBF8
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021DC RID: 8668 RVA: 0x00081A2C File Offset: 0x0007FC2C
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021DD RID: 8669 RVA: 0x00081A60 File Offset: 0x0007FC60
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021DE RID: 8670 RVA: 0x00081A90 File Offset: 0x0007FC90
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021DF RID: 8671 RVA: 0x00081AC0 File Offset: 0x0007FCC0
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E0 RID: 8672 RVA: 0x00081AF0 File Offset: 0x0007FCF0
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E1 RID: 8673 RVA: 0x00081B24 File Offset: 0x0007FD24
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E2 RID: 8674 RVA: 0x00081B58 File Offset: 0x0007FD58
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E3 RID: 8675 RVA: 0x00081B8C File Offset: 0x0007FD8C
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E4 RID: 8676 RVA: 0x00081BBC File Offset: 0x0007FDBC
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E5 RID: 8677 RVA: 0x00081BEC File Offset: 0x0007FDEC
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E6 RID: 8678 RVA: 0x00081C1C File Offset: 0x0007FE1C
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E7 RID: 8679 RVA: 0x00081C50 File Offset: 0x0007FE50
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E8 RID: 8680 RVA: 0x00081C84 File Offset: 0x0007FE84
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021E9 RID: 8681 RVA: 0x00081CB8 File Offset: 0x0007FEB8
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021EA RID: 8682 RVA: 0x00081CE8 File Offset: 0x0007FEE8
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, target, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021EB RID: 8683 RVA: 0x00081D18 File Offset: 0x0007FF18
	public static bool RPC<P0, P1, P2, P3, P4, P5>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5>(entID, messageName, targets, p0, p1, p2, p3, p4, p5);
	}

	// Token: 0x060021EC RID: 8684 RVA: 0x00081D48 File Offset: 0x0007FF48
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021ED RID: 8685 RVA: 0x00081D7C File Offset: 0x0007FF7C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021EE RID: 8686 RVA: 0x00081DB0 File Offset: 0x0007FFB0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021EF RID: 8687 RVA: 0x00081DE4 File Offset: 0x0007FFE4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F0 RID: 8688 RVA: 0x00081E18 File Offset: 0x00080018
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F1 RID: 8689 RVA: 0x00081E4C File Offset: 0x0008004C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F2 RID: 8690 RVA: 0x00081E80 File Offset: 0x00080080
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F3 RID: 8691 RVA: 0x00081EB4 File Offset: 0x000800B4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F4 RID: 8692 RVA: 0x00081EE8 File Offset: 0x000800E8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F5 RID: 8693 RVA: 0x00081F1C File Offset: 0x0008011C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F6 RID: 8694 RVA: 0x00081F50 File Offset: 0x00080150
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F7 RID: 8695 RVA: 0x00081F84 File Offset: 0x00080184
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F8 RID: 8696 RVA: 0x00081FB8 File Offset: 0x000801B8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021F9 RID: 8697 RVA: 0x00081FEC File Offset: 0x000801EC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021FA RID: 8698 RVA: 0x00082020 File Offset: 0x00080220
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021FB RID: 8699 RVA: 0x00082054 File Offset: 0x00080254
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021FC RID: 8700 RVA: 0x00082088 File Offset: 0x00080288
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021FD RID: 8701 RVA: 0x000820BC File Offset: 0x000802BC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6);
	}

	// Token: 0x060021FE RID: 8702 RVA: 0x000820F0 File Offset: 0x000802F0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x060021FF RID: 8703 RVA: 0x00082128 File Offset: 0x00080328
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002200 RID: 8704 RVA: 0x00082160 File Offset: 0x00080360
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002201 RID: 8705 RVA: 0x00082198 File Offset: 0x00080398
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002202 RID: 8706 RVA: 0x000821CC File Offset: 0x000803CC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002203 RID: 8707 RVA: 0x00082200 File Offset: 0x00080400
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002204 RID: 8708 RVA: 0x00082234 File Offset: 0x00080434
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002205 RID: 8709 RVA: 0x0008226C File Offset: 0x0008046C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002206 RID: 8710 RVA: 0x000822A4 File Offset: 0x000804A4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002207 RID: 8711 RVA: 0x000822DC File Offset: 0x000804DC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002208 RID: 8712 RVA: 0x00082310 File Offset: 0x00080510
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002209 RID: 8713 RVA: 0x00082344 File Offset: 0x00080544
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x0600220A RID: 8714 RVA: 0x00082378 File Offset: 0x00080578
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x0600220B RID: 8715 RVA: 0x000823B0 File Offset: 0x000805B0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x0600220C RID: 8716 RVA: 0x000823E8 File Offset: 0x000805E8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x0600220D RID: 8717 RVA: 0x00082420 File Offset: 0x00080620
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x0600220E RID: 8718 RVA: 0x00082454 File Offset: 0x00080654
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x0600220F RID: 8719 RVA: 0x00082488 File Offset: 0x00080688
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7);
	}

	// Token: 0x06002210 RID: 8720 RVA: 0x000824BC File Offset: 0x000806BC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002211 RID: 8721 RVA: 0x000824F4 File Offset: 0x000806F4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002212 RID: 8722 RVA: 0x0008252C File Offset: 0x0008072C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002213 RID: 8723 RVA: 0x00082564 File Offset: 0x00080764
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002214 RID: 8724 RVA: 0x0008259C File Offset: 0x0008079C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002215 RID: 8725 RVA: 0x000825D4 File Offset: 0x000807D4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002216 RID: 8726 RVA: 0x0008260C File Offset: 0x0008080C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002217 RID: 8727 RVA: 0x00082644 File Offset: 0x00080844
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002218 RID: 8728 RVA: 0x0008267C File Offset: 0x0008087C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002219 RID: 8729 RVA: 0x000826B4 File Offset: 0x000808B4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x0600221A RID: 8730 RVA: 0x000826EC File Offset: 0x000808EC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x0600221B RID: 8731 RVA: 0x00082724 File Offset: 0x00080924
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x0600221C RID: 8732 RVA: 0x0008275C File Offset: 0x0008095C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x0600221D RID: 8733 RVA: 0x00082794 File Offset: 0x00080994
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x0600221E RID: 8734 RVA: 0x000827CC File Offset: 0x000809CC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x0600221F RID: 8735 RVA: 0x00082804 File Offset: 0x00080A04
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002220 RID: 8736 RVA: 0x0008283C File Offset: 0x00080A3C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002221 RID: 8737 RVA: 0x00082874 File Offset: 0x00080A74
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	// Token: 0x06002222 RID: 8738 RVA: 0x000828AC File Offset: 0x00080AAC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002223 RID: 8739 RVA: 0x000828E8 File Offset: 0x00080AE8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002224 RID: 8740 RVA: 0x00082924 File Offset: 0x00080B24
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002225 RID: 8741 RVA: 0x00082960 File Offset: 0x00080B60
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002226 RID: 8742 RVA: 0x00082998 File Offset: 0x00080B98
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002227 RID: 8743 RVA: 0x000829D0 File Offset: 0x00080BD0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002228 RID: 8744 RVA: 0x00082A08 File Offset: 0x00080C08
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002229 RID: 8745 RVA: 0x00082A44 File Offset: 0x00080C44
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x0600222A RID: 8746 RVA: 0x00082A80 File Offset: 0x00080C80
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x0600222B RID: 8747 RVA: 0x00082ABC File Offset: 0x00080CBC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x0600222C RID: 8748 RVA: 0x00082AF4 File Offset: 0x00080CF4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x0600222D RID: 8749 RVA: 0x00082B2C File Offset: 0x00080D2C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x0600222E RID: 8750 RVA: 0x00082B64 File Offset: 0x00080D64
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x0600222F RID: 8751 RVA: 0x00082BA0 File Offset: 0x00080DA0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002230 RID: 8752 RVA: 0x00082BDC File Offset: 0x00080DDC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002231 RID: 8753 RVA: 0x00082C18 File Offset: 0x00080E18
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002232 RID: 8754 RVA: 0x00082C50 File Offset: 0x00080E50
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002233 RID: 8755 RVA: 0x00082C88 File Offset: 0x00080E88
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	}

	// Token: 0x06002234 RID: 8756 RVA: 0x00082CC0 File Offset: 0x00080EC0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002235 RID: 8757 RVA: 0x00082CFC File Offset: 0x00080EFC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002236 RID: 8758 RVA: 0x00082D38 File Offset: 0x00080F38
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002237 RID: 8759 RVA: 0x00082D74 File Offset: 0x00080F74
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002238 RID: 8760 RVA: 0x00082DB0 File Offset: 0x00080FB0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002239 RID: 8761 RVA: 0x00082DEC File Offset: 0x00080FEC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x0600223A RID: 8762 RVA: 0x00082E28 File Offset: 0x00081028
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x0600223B RID: 8763 RVA: 0x00082E64 File Offset: 0x00081064
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x0600223C RID: 8764 RVA: 0x00082EA0 File Offset: 0x000810A0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x0600223D RID: 8765 RVA: 0x00082EDC File Offset: 0x000810DC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x0600223E RID: 8766 RVA: 0x00082F18 File Offset: 0x00081118
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x0600223F RID: 8767 RVA: 0x00082F54 File Offset: 0x00081154
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002240 RID: 8768 RVA: 0x00082F90 File Offset: 0x00081190
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002241 RID: 8769 RVA: 0x00082FCC File Offset: 0x000811CC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002242 RID: 8770 RVA: 0x00083008 File Offset: 0x00081208
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002243 RID: 8771 RVA: 0x00083044 File Offset: 0x00081244
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002244 RID: 8772 RVA: 0x00083080 File Offset: 0x00081280
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002245 RID: 8773 RVA: 0x000830BC File Offset: 0x000812BC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	// Token: 0x06002246 RID: 8774 RVA: 0x000830F8 File Offset: 0x000812F8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002247 RID: 8775 RVA: 0x00083138 File Offset: 0x00081338
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002248 RID: 8776 RVA: 0x00083178 File Offset: 0x00081378
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.GameObject entity, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002249 RID: 8777 RVA: 0x000831B8 File Offset: 0x000813B8
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.GameObject entity, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x0600224A RID: 8778 RVA: 0x000831F4 File Offset: 0x000813F4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.GameObject entity, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x0600224B RID: 8779 RVA: 0x00083230 File Offset: 0x00081430
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.GameObject entity, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entity, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x0600224C RID: 8780 RVA: 0x0008326C File Offset: 0x0008146C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x0600224D RID: 8781 RVA: 0x000832AC File Offset: 0x000814AC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x0600224E RID: 8782 RVA: 0x000832EC File Offset: 0x000814EC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.MonoBehaviour entityScript, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x0600224F RID: 8783 RVA: 0x0008332C File Offset: 0x0008152C
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002250 RID: 8784 RVA: 0x00083368 File Offset: 0x00081568
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002251 RID: 8785 RVA: 0x000833A4 File Offset: 0x000815A4
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.MonoBehaviour entityScript, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityScript, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002252 RID: 8786 RVA: 0x000833E0 File Offset: 0x000815E0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002253 RID: 8787 RVA: 0x00083420 File Offset: 0x00081620
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002254 RID: 8788 RVA: 0x00083460 File Offset: 0x00081660
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.Component entityComponent, global::uLink.NetworkFlags flags, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, flags, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002255 RID: 8789 RVA: 0x000834A0 File Offset: 0x000816A0
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.RPCMode rpcMode, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, rpcMode, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002256 RID: 8790 RVA: 0x000834DC File Offset: 0x000816DC
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.Component entityComponent, string messageName, global::uLink.NetworkPlayer target, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, target, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x06002257 RID: 8791 RVA: 0x00083518 File Offset: 0x00081718
	public static bool RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(global::UnityEngine.Component entityComponent, string messageName, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NetEntityID entID;
		return (int)global::NetEntityID.Of(entityComponent, out entID) != 0 && global::NetCull.RPC<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(entID, messageName, targets, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
	}

	// Token: 0x170007E2 RID: 2018
	// (get) Token: 0x06002258 RID: 8792 RVA: 0x00083554 File Offset: 0x00081754
	// (set) Token: 0x06002259 RID: 8793 RVA: 0x00083568 File Offset: 0x00081768
	public static double allottedTransitTime
	{
		get
		{
			return global::NetCull.allottedTransitTimeInMillis * 0.001;
		}
		set
		{
			global::NetCull.allottedTransitTimeInMillis = (ulong)global::System.Math.Ceiling(value * 1000.0);
		}
	}

	// Token: 0x170007E3 RID: 2019
	// (get) Token: 0x0600225A RID: 8794 RVA: 0x00083580 File Offset: 0x00081780
	internal static global::NetCull.TimeRecord FrameTimestamp
	{
		get
		{
			if (!global::NetCull.Time.FrameTimestamp.HasValue)
			{
				global::NetCull.Time.FrameTimestamp = new global::NetCull.TimeRecord(global::NetCull.timeInMillis);
			}
			return global::NetCull.Time.FrameTimestamp;
		}
	}

	// Token: 0x0600225B RID: 8795 RVA: 0x000835C0 File Offset: 0x000817C0
	internal static ulong CalculateDeltaTimeFromTimeDeltaTime()
	{
		return (ulong)global::System.Math.Ceiling((double)global::UnityEngine.Time.deltaTime * 1000.0);
	}

	// Token: 0x0600225C RID: 8796 RVA: 0x000835D8 File Offset: 0x000817D8
	private static void ResetTimers()
	{
		global::NetCull.Time = default(global::NetCull.TimeRecords);
	}

	// Token: 0x170007E4 RID: 2020
	// (get) Token: 0x0600225D RID: 8797 RVA: 0x000835F4 File Offset: 0x000817F4
	public static ulong frameTimeInMillis
	{
		get
		{
			if (!global::NetCull.Time.FrameTimestamp.HasValue)
			{
				global::NetCull.Time.FrameTimestamp = new global::NetCull.TimeRecord(global::NetCull.timeInMillis);
			}
			return global::NetCull.Time.FrameTimestamp.Value;
		}
	}

	// Token: 0x170007E5 RID: 2021
	// (get) Token: 0x0600225E RID: 8798 RVA: 0x00083630 File Offset: 0x00081830
	public static double frameTime
	{
		get
		{
			return global::NetCull.frameTimeInMillis * 0.001;
		}
	}

	// Token: 0x170007E6 RID: 2022
	// (get) Token: 0x0600225F RID: 8799 RVA: 0x00083644 File Offset: 0x00081844
	public static ulong frameDurationInMillis
	{
		get
		{
			if (!global::NetCull.Time.FrameDuration.HasValue)
			{
				global::NetCull.Time.FrameDuration = new global::NetCull.TimeRecord(global::NetCull.CalculateDeltaTimeFromTimeDeltaTime());
			}
			return global::NetCull.Time.FrameDuration.Value;
		}
	}

	// Token: 0x170007E7 RID: 2023
	// (get) Token: 0x06002260 RID: 8800 RVA: 0x00083680 File Offset: 0x00081880
	public static double frameDuration
	{
		get
		{
			return global::NetCull.frameDurationInMillis * 0.001;
		}
	}

	// Token: 0x170007E8 RID: 2024
	// (get) Token: 0x06002261 RID: 8801 RVA: 0x00083694 File Offset: 0x00081894
	public static ulong overheadDurationInMillis
	{
		get
		{
			if (!global::NetCull.Time.OverheadDuration.HasValue)
			{
				return global::NetCull.frameDurationInMillis;
			}
			return global::NetCull.Time.OverheadDuration.Value;
		}
	}

	// Token: 0x170007E9 RID: 2025
	// (get) Token: 0x06002262 RID: 8802 RVA: 0x000836C0 File Offset: 0x000818C0
	public static double overheadDuration
	{
		get
		{
			return global::NetCull.overheadDurationInMillis * 0.001;
		}
	}

	// Token: 0x170007EA RID: 2026
	// (get) Token: 0x06002263 RID: 8803 RVA: 0x000836D4 File Offset: 0x000818D4
	public static ulong lowestSafeTimeInMillis
	{
		get
		{
			ulong frameTimeInMillis = global::NetCull.frameTimeInMillis;
			ulong frameDurationInMillis = global::NetCull.frameDurationInMillis;
			ulong num = global::NetCull.overheadDurationInMillis;
			if (global::NetCull.Time.Updating)
			{
				ulong timeInMillis = global::NetCull.timeInMillis;
				if (timeInMillis > global::NetCull.Time.PreUpdateTimestamp.Value)
				{
					ulong num2 = timeInMillis - global::NetCull.Time.PreUpdateTimestamp.Value;
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			ulong num3 = frameDurationInMillis + num;
			if (frameTimeInMillis <= num3)
			{
				return 0UL;
			}
			return frameTimeInMillis - num3;
		}
	}

	// Token: 0x170007EB RID: 2027
	// (get) Token: 0x06002264 RID: 8804 RVA: 0x00083750 File Offset: 0x00081950
	public static double lowestSafeTime
	{
		get
		{
			return global::NetCull.lowestSafeTimeInMillis * 0.001;
		}
	}

	// Token: 0x170007EC RID: 2028
	// (get) Token: 0x06002265 RID: 8805 RVA: 0x00083764 File Offset: 0x00081964
	public static ulong verificationMinimalTimeInMillis
	{
		get
		{
			ulong lowestSafeTimeInMillis = global::NetCull.lowestSafeTimeInMillis;
			if (lowestSafeTimeInMillis < global::NetCull.allottedTransitTimeInMillis)
			{
				return 0UL;
			}
			return lowestSafeTimeInMillis - global::NetCull.allottedTransitTimeInMillis;
		}
	}

	// Token: 0x170007ED RID: 2029
	// (get) Token: 0x06002266 RID: 8806 RVA: 0x0008378C File Offset: 0x0008198C
	public static double verificationMinimalTime
	{
		get
		{
			return global::NetCull.verificationMinimalTimeInMillis * 0.001;
		}
	}

	// Token: 0x170007EE RID: 2030
	// (get) Token: 0x06002267 RID: 8807 RVA: 0x000837A0 File Offset: 0x000819A0
	[global::System.Obsolete("Use ServerDuration.Reverification for reverification")]
	public static ulong reverificationTimeInMillis
	{
		get
		{
			ulong frameDurationInMillis = global::NetCull.frameDurationInMillis;
			ulong num = global::NetCull.overheadDurationInMillis;
			if (global::NetCull.Time.Updating)
			{
				ulong timeInMillis = global::NetCull.timeInMillis;
				if (timeInMillis > global::NetCull.Time.PreUpdateTimestamp.Value)
				{
					ulong num2 = timeInMillis - global::NetCull.Time.PreUpdateTimestamp.Value;
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			ulong num3 = frameDurationInMillis + num;
			return global::NetCull.timeInMillis + num3;
		}
	}

	// Token: 0x170007EF RID: 2031
	// (get) Token: 0x06002268 RID: 8808 RVA: 0x0008380C File Offset: 0x00081A0C
	[global::System.Obsolete("Use ServerDuration.Reverification for reverification")]
	public static double reverificationTime
	{
		get
		{
			return global::NetCull.reverificationTimeInMillis * 0.001;
		}
	}

	// Token: 0x06002269 RID: 8809 RVA: 0x00083820 File Offset: 0x00081A20
	private static void TimeMeasureStart()
	{
		ulong timeInMillis = global::NetCull.timeInMillis;
		ulong num2;
		if (!global::NetCull.Time.FrameTimestamp.HasValue)
		{
			ulong num = global::NetCull.CalculateDeltaTimeFromTimeDeltaTime();
			if (num < timeInMillis)
			{
				num2 = timeInMillis - num;
			}
			else
			{
				num2 = 0UL;
			}
		}
		else
		{
			num2 = global::NetCull.Time.FrameTimestamp.Value;
			if (num2 > timeInMillis)
			{
				num2 = timeInMillis;
			}
		}
		global::NetCull.Time.FrameDuration = new global::NetCull.TimeRecord(timeInMillis - num2);
		global::NetCull.Time.PostUpdateTimestamp = (global::NetCull.Time.PreUpdateTimestamp = (global::NetCull.Time.FrameTimestamp = new global::NetCull.TimeRecord(timeInMillis)));
		if (!global::NetCull.Time.OverheadDuration.HasValue)
		{
			global::NetCull.Time.OverheadDuration = global::NetCull.Time.FrameDuration;
		}
		global::NetCull.Time.Updating = true;
	}

	// Token: 0x0600226A RID: 8810 RVA: 0x000838F0 File Offset: 0x00081AF0
	private static void TimeMeasureStop()
	{
		if (global::NetCull.Time.Updating)
		{
			global::NetCull.Time.PostUpdateTimestamp = new global::NetCull.TimeRecord(global::NetCull.timeInMillis);
			global::NetCull.Time.Updating = false;
			ulong value;
			if (global::NetCull.Time.PreUpdateTimestamp.Value < global::NetCull.Time.PostUpdateTimestamp.Value)
			{
				value = global::NetCull.Time.PostUpdateTimestamp.Value - global::NetCull.Time.PreUpdateTimestamp.Value;
			}
			else
			{
				value = 0UL;
			}
			global::NetCull.Time.OverheadDuration = new global::NetCull.TimeRecord(value);
			global::NetUser.AdjustTimesWithNewMeasurement();
		}
	}

	// Token: 0x0600226B RID: 8811 RVA: 0x0008398C File Offset: 0x00081B8C
	[global::System.Diagnostics.Conditional("SERVER")]
	public static void VerifyRPC(ref global::uLink.NetworkMessageInfo info, bool skipOwnerCheck = false)
	{
		global::uLink.NetworkPlayer sender = info.sender;
		global::NetUser netUser = global::NetUser.Find(sender);
		if (!sender.isConnected || sender.isServer || netUser == null)
		{
			if (global::packet.loglevel > 0)
			{
				global::UnityEngine.Debug.Log(string.Format("packetdrop:{0} was not a valid sender", info.sender));
			}
			throw new global::NetCull.RPCVerificationSenderException(sender);
		}
		if (!skipOwnerCheck)
		{
			global::uLink.NetworkView networkView = info.networkView;
			global::uLink.NetworkPlayer owner;
			if (networkView && sender != (owner = networkView.owner))
			{
				throw new global::NetCull.RPCVerificationWrongSenderException(sender, owner);
			}
		}
		ulong num;
		if (netUser.GetDropVariables(out num))
		{
			if (num >= info.timestampInMillis)
			{
				if (global::packet.loglevel > 2)
				{
					global::UnityEngine.Debug.Log(string.Format("packetdrop:{0} dropping consecutive rpc [{1}<={2}]", netUser, info.timestampInMillis, num));
				}
				throw new global::NetCull.RPCVerificationDropException();
			}
			netUser.ClearDropVariables();
			if (global::packet.loglevel > 1)
			{
				global::UnityEngine.Debug.Log(string.Format("packetdrop:{0} sent first verfied time rpc [{1}>{2}]", netUser, info.timestampInMillis, num));
			}
		}
		if (!global::packet.verify)
		{
			return;
		}
		ulong verificationMinimalTimeInMillis = global::NetCull.verificationMinimalTimeInMillis;
		if (info.timestampInMillis < verificationMinimalTimeInMillis)
		{
			int num2 = netUser.SetDropVariables();
			if (global::packet.loglevel > 0)
			{
				netUser.GetDropVariables(out num);
				global::UnityEngine.Debug.Log(string.Format("packetdrop:{0} caught[{1}<{2}]. future rpcs ts'd <= {3} will drop", new object[]
				{
					netUser,
					info.timestampInMillis,
					verificationMinimalTimeInMillis,
					num
				}));
			}
			if (num2 >= global::packet.dropclockthresh && global::packet.dropclockthresh > 0)
			{
				netUser.ClearDropCount();
				try
				{
					global::ServerManagement.ResyncronizeClientClock(netUser.networkPlayer, 6f);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
				}
			}
			throw new global::NetCull.RPCVerificationLateException();
		}
	}

	// Token: 0x0600226C RID: 8812 RVA: 0x00083B94 File Offset: 0x00081D94
	public static global::UnityEngine.GameObject InstantiateClassic(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic, new global::uLink.NetworkViewID?(viewID), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600226D RID: 8813 RVA: 0x00083BD4 File Offset: 0x00081DD4
	public static global::UnityEngine.GameObject InstantiateClassic(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic, new global::uLink.NetworkViewID?(viewID), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600226E RID: 8814 RVA: 0x00083C14 File Offset: 0x00081E14
	public static T InstantiateClassic<T>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Classic, new global::uLink.NetworkViewID?(viewID), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x0600226F RID: 8815 RVA: 0x00083C54 File Offset: 0x00081E54
	public static global::UnityEngine.GameObject InstantiateClassic(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002270 RID: 8816 RVA: 0x00083C94 File Offset: 0x00081E94
	public static global::UnityEngine.GameObject InstantiateClassic(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002271 RID: 8817 RVA: 0x00083CD4 File Offset: 0x00081ED4
	public static T InstantiateClassic<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Classic, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002272 RID: 8818 RVA: 0x00083D14 File Offset: 0x00081F14
	public static global::UnityEngine.GameObject InstantiateClassic(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic, null, null, prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002273 RID: 8819 RVA: 0x00083D58 File Offset: 0x00081F58
	public static global::UnityEngine.GameObject InstantiateClassic(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic, null, null, prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002274 RID: 8820 RVA: 0x00083D9C File Offset: 0x00081F9C
	public static T InstantiateClassic<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Classic, null, null, prefab, position, rotation, new int?(group), global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002275 RID: 8821 RVA: 0x00083DE0 File Offset: 0x00081FE0
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic_Args, new global::uLink.NetworkViewID?(viewID), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002276 RID: 8822 RVA: 0x00083E1C File Offset: 0x0008201C
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic_Args, new global::uLink.NetworkViewID?(viewID), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002277 RID: 8823 RVA: 0x00083E58 File Offset: 0x00082058
	public static T InstantiateClassicWithArgs<T>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Classic_Args, new global::uLink.NetworkViewID?(viewID), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002278 RID: 8824 RVA: 0x00083E94 File Offset: 0x00082094
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002279 RID: 8825 RVA: 0x00083ED4 File Offset: 0x000820D4
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600227A RID: 8826 RVA: 0x00083F14 File Offset: 0x00082114
	public static T InstantiateClassicWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Classic_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(group), args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x0600227B RID: 8827 RVA: 0x00083F54 File Offset: 0x00082154
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic_Args, null, null, prefab, position, rotation, new int?(group), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600227C RID: 8828 RVA: 0x00083F94 File Offset: 0x00082194
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Classic_Args, null, null, prefab, position, rotation, new int?(group), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600227D RID: 8829 RVA: 0x00083FD4 File Offset: 0x000821D4
	public static T InstantiateClassicWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Classic_Args, null, null, prefab, position, rotation, new int?(group), args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x0600227E RID: 8830 RVA: 0x00084014 File Offset: 0x00082214
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs<TArg>(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg)
	{
		return global::NetCull.InstantiateClassicWithArgs(prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x0600227F RID: 8831 RVA: 0x0008403C File Offset: 0x0008223C
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs<TArg>(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg)
	{
		return global::NetCull.InstantiateClassicWithArgs(prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002280 RID: 8832 RVA: 0x00084064 File Offset: 0x00082264
	public static T InstantiateClassicWithArgs<T, TArg>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateClassicWithArgs<T>(prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002281 RID: 8833 RVA: 0x0008408C File Offset: 0x0008228C
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs<TArg>(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg)
	{
		return global::NetCull.InstantiateClassicWithArgs(owner, prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002282 RID: 8834 RVA: 0x000840B4 File Offset: 0x000822B4
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs<TArg>(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg)
	{
		return global::NetCull.InstantiateClassicWithArgs(owner, prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002283 RID: 8835 RVA: 0x000840DC File Offset: 0x000822DC
	public static T InstantiateClassicWithArgs<T, TArg>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateClassicWithArgs<T>(owner, prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002284 RID: 8836 RVA: 0x00084104 File Offset: 0x00082304
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg)
	{
		return global::NetCull.InstantiateClassicWithArgs(viewID, owner, prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002285 RID: 8837 RVA: 0x00084130 File Offset: 0x00082330
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg)
	{
		return global::NetCull.InstantiateClassicWithArgs(viewID, owner, prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002286 RID: 8838 RVA: 0x0008415C File Offset: 0x0008235C
	public static T InstantiateClassicWithArgs<T, TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateClassicWithArgs<T>(viewID, owner, prefab, position, rotation, group, new object[]
		{
			arg
		});
	}

	// Token: 0x06002287 RID: 8839 RVA: 0x00084188 File Offset: 0x00082388
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002288 RID: 8840 RVA: 0x00084194 File Offset: 0x00082394
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateClassicWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002289 RID: 8841 RVA: 0x000841A0 File Offset: 0x000823A0
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600228A RID: 8842 RVA: 0x000841AC File Offset: 0x000823AC
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600228B RID: 8843 RVA: 0x000841B8 File Offset: 0x000823B8
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateClassicWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600228C RID: 8844 RVA: 0x000841C4 File Offset: 0x000823C4
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600228D RID: 8845 RVA: 0x000841D0 File Offset: 0x000823D0
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600228E RID: 8846 RVA: 0x000841DC File Offset: 0x000823DC
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateClassicWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600228F RID: 8847 RVA: 0x000841E8 File Offset: 0x000823E8
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateClassicWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int group)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002290 RID: 8848 RVA: 0x000841F4 File Offset: 0x000823F4
	public static global::UnityEngine.GameObject InstantiateDynamic(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002291 RID: 8849 RVA: 0x00084238 File Offset: 0x00082438
	public static global::UnityEngine.GameObject InstantiateDynamic(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002292 RID: 8850 RVA: 0x0008427C File Offset: 0x0008247C
	public static T InstantiateDynamic<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Dynamic, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002293 RID: 8851 RVA: 0x000842C0 File Offset: 0x000824C0
	public static global::UnityEngine.GameObject InstantiateDynamic(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic, null, null, prefab, position, rotation, null, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002294 RID: 8852 RVA: 0x00084304 File Offset: 0x00082504
	public static global::UnityEngine.GameObject InstantiateDynamic(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic, null, null, prefab, position, rotation, null, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002295 RID: 8853 RVA: 0x00084348 File Offset: 0x00082548
	public static T InstantiateDynamic<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Dynamic, null, null, prefab, position, rotation, null, global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002296 RID: 8854 RVA: 0x0008438C File Offset: 0x0008258C
	public static global::UnityEngine.GameObject InstantiateDynamic(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002297 RID: 8855 RVA: 0x000843CC File Offset: 0x000825CC
	public static global::UnityEngine.GameObject InstantiateDynamic(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002298 RID: 8856 RVA: 0x0008440C File Offset: 0x0008260C
	public static T InstantiateDynamic<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Dynamic, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002299 RID: 8857 RVA: 0x0008444C File Offset: 0x0008264C
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600229A RID: 8858 RVA: 0x0008448C File Offset: 0x0008268C
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600229B RID: 8859 RVA: 0x000844CC File Offset: 0x000826CC
	public static T InstantiateDynamicWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Dynamic_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x0600229C RID: 8860 RVA: 0x0008450C File Offset: 0x0008270C
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600229D RID: 8861 RVA: 0x0008454C File Offset: 0x0008274C
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x0600229E RID: 8862 RVA: 0x0008458C File Offset: 0x0008278C
	public static T InstantiateDynamicWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Dynamic_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x0600229F RID: 8863 RVA: 0x000845CC File Offset: 0x000827CC
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic_Args, null, null, prefab, position, rotation, null, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022A0 RID: 8864 RVA: 0x00084610 File Offset: 0x00082810
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Dynamic_Args, null, null, prefab, position, rotation, null, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022A1 RID: 8865 RVA: 0x00084654 File Offset: 0x00082854
	public static T InstantiateDynamicWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Dynamic_Args, null, null, prefab, position, rotation, null, args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022A2 RID: 8866 RVA: 0x00084698 File Offset: 0x00082898
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs<TArg>(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateDynamicWithArgs(prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A3 RID: 8867 RVA: 0x000846B4 File Offset: 0x000828B4
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs<TArg>(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateDynamicWithArgs(prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A4 RID: 8868 RVA: 0x000846D0 File Offset: 0x000828D0
	public static T InstantiateDynamicWithArgs<T, TArg>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateDynamicWithArgs<T>(prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A5 RID: 8869 RVA: 0x000846EC File Offset: 0x000828EC
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs<TArg>(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateDynamicWithArgs(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A6 RID: 8870 RVA: 0x00084714 File Offset: 0x00082914
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs<TArg>(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateDynamicWithArgs(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A7 RID: 8871 RVA: 0x0008473C File Offset: 0x0008293C
	public static T InstantiateDynamicWithArgs<T, TArg>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateDynamicWithArgs<T>(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A8 RID: 8872 RVA: 0x00084764 File Offset: 0x00082964
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateDynamicWithArgs(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022A9 RID: 8873 RVA: 0x0008478C File Offset: 0x0008298C
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateDynamicWithArgs(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022AA RID: 8874 RVA: 0x000847B4 File Offset: 0x000829B4
	public static T InstantiateDynamicWithArgs<T, TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateDynamicWithArgs<T>(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022AB RID: 8875 RVA: 0x000847DC File Offset: 0x000829DC
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022AC RID: 8876 RVA: 0x000847E8 File Offset: 0x000829E8
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateDynamicWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022AD RID: 8877 RVA: 0x000847F4 File Offset: 0x000829F4
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022AE RID: 8878 RVA: 0x00084800 File Offset: 0x00082A00
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022AF RID: 8879 RVA: 0x0008480C File Offset: 0x00082A0C
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateDynamicWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022B0 RID: 8880 RVA: 0x00084818 File Offset: 0x00082A18
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022B1 RID: 8881 RVA: 0x00084824 File Offset: 0x00082A24
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022B2 RID: 8882 RVA: 0x00084830 File Offset: 0x00082A30
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateDynamicWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022B3 RID: 8883 RVA: 0x0008483C File Offset: 0x00082A3C
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateDynamicWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022B4 RID: 8884 RVA: 0x00084848 File Offset: 0x00082A48
	public static global::UnityEngine.GameObject InstantiatePiggyBack(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022B5 RID: 8885 RVA: 0x00084880 File Offset: 0x00082A80
	public static global::UnityEngine.GameObject InstantiatePiggyBack(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022B6 RID: 8886 RVA: 0x000848B8 File Offset: 0x00082AB8
	public static T InstantiatePiggyBack<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PiggyBack, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022B7 RID: 8887 RVA: 0x000848F0 File Offset: 0x00082AF0
	public static global::UnityEngine.GameObject InstantiatePiggyBack(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022B8 RID: 8888 RVA: 0x0008492C File Offset: 0x00082B2C
	public static global::UnityEngine.GameObject InstantiatePiggyBack(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022B9 RID: 8889 RVA: 0x00084968 File Offset: 0x00082B68
	public static T InstantiatePiggyBack<T>(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PiggyBack, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022BA RID: 8890 RVA: 0x000849A4 File Offset: 0x00082BA4
	public static global::UnityEngine.GameObject InstantiatePiggyBack(global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack, null, null, prefab, position, rotation, group, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022BB RID: 8891 RVA: 0x000849E0 File Offset: 0x00082BE0
	public static global::UnityEngine.GameObject InstantiatePiggyBack(global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack, null, null, prefab, position, rotation, group, global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022BC RID: 8892 RVA: 0x00084A1C File Offset: 0x00082C1C
	public static T InstantiatePiggyBack<T>(global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PiggyBack, null, null, prefab, position, rotation, group, global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022BD RID: 8893 RVA: 0x00084A58 File Offset: 0x00082C58
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022BE RID: 8894 RVA: 0x00084A90 File Offset: 0x00082C90
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022BF RID: 8895 RVA: 0x00084AC8 File Offset: 0x00082CC8
	public static T InstantiatePiggyBackWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PiggyBack_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022C0 RID: 8896 RVA: 0x00084B00 File Offset: 0x00082D00
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022C1 RID: 8897 RVA: 0x00084B38 File Offset: 0x00082D38
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022C2 RID: 8898 RVA: 0x00084B70 File Offset: 0x00082D70
	public static T InstantiatePiggyBackWithArgs<T>(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PiggyBack_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, group, args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022C3 RID: 8899 RVA: 0x00084BA8 File Offset: 0x00082DA8
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack_Args, null, null, prefab, position, rotation, group, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022C4 RID: 8900 RVA: 0x00084BE4 File Offset: 0x00082DE4
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PiggyBack_Args, null, null, prefab, position, rotation, group, args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022C5 RID: 8901 RVA: 0x00084C20 File Offset: 0x00082E20
	public static T InstantiatePiggyBackWithArgs<T>(global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PiggyBack_Args, null, null, prefab, position, rotation, group, args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022C6 RID: 8902 RVA: 0x00084C5C File Offset: 0x00082E5C
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs<TArg>(global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePiggyBackWithArgs(group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022C7 RID: 8903 RVA: 0x00084C84 File Offset: 0x00082E84
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs<TArg>(global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePiggyBackWithArgs(group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022C8 RID: 8904 RVA: 0x00084CAC File Offset: 0x00082EAC
	public static T InstantiatePiggyBackWithArgs<T, TArg>(global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiatePiggyBackWithArgs<T>(group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022C9 RID: 8905 RVA: 0x00084CD4 File Offset: 0x00082ED4
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs<TArg>(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePiggyBackWithArgs(owner, group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022CA RID: 8906 RVA: 0x00084CFC File Offset: 0x00082EFC
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs<TArg>(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePiggyBackWithArgs(owner, group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022CB RID: 8907 RVA: 0x00084D24 File Offset: 0x00082F24
	public static T InstantiatePiggyBackWithArgs<T, TArg>(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiatePiggyBackWithArgs<T>(owner, group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022CC RID: 8908 RVA: 0x00084D4C File Offset: 0x00082F4C
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePiggyBackWithArgs(viewID, owner, group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022CD RID: 8909 RVA: 0x00084D78 File Offset: 0x00082F78
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePiggyBackWithArgs(viewID, owner, group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022CE RID: 8910 RVA: 0x00084DA4 File Offset: 0x00082FA4
	public static T InstantiatePiggyBackWithArgs<T, TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiatePiggyBackWithArgs<T>(viewID, owner, group, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022CF RID: 8911 RVA: 0x00084DD0 File Offset: 0x00082FD0
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D0 RID: 8912 RVA: 0x00084DDC File Offset: 0x00082FDC
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiatePiggyBackWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D1 RID: 8913 RVA: 0x00084DE8 File Offset: 0x00082FE8
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D2 RID: 8914 RVA: 0x00084DF4 File Offset: 0x00082FF4
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D3 RID: 8915 RVA: 0x00084E00 File Offset: 0x00083000
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiatePiggyBackWithArgs<T>(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D4 RID: 8916 RVA: 0x00084E0C File Offset: 0x0008300C
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::uLink.NetworkPlayer owner, global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D5 RID: 8917 RVA: 0x00084E18 File Offset: 0x00083018
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::NetworkCullInfo group, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D6 RID: 8918 RVA: 0x00084E24 File Offset: 0x00083024
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiatePiggyBackWithArgs<T>(global::NetworkCullInfo group, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D7 RID: 8919 RVA: 0x00084E30 File Offset: 0x00083030
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePiggyBackWithArgs(global::NetworkCullInfo group, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022D8 RID: 8920 RVA: 0x00084E3C File Offset: 0x0008303C
	public static global::UnityEngine.GameObject InstantiatePlayerRoot(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022D9 RID: 8921 RVA: 0x00084E88 File Offset: 0x00083088
	public static global::UnityEngine.GameObject InstantiatePlayerRoot(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022DA RID: 8922 RVA: 0x00084ED4 File Offset: 0x000830D4
	public static T InstantiatePlayerRoot<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PlayerRoot, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		instantiateArgs.playerRoot = true;
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022DB RID: 8923 RVA: 0x00084F20 File Offset: 0x00083120
	public static global::UnityEngine.GameObject InstantiatePlayerRoot(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022DC RID: 8924 RVA: 0x00084F68 File Offset: 0x00083168
	public static global::UnityEngine.GameObject InstantiatePlayerRoot(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022DD RID: 8925 RVA: 0x00084FB0 File Offset: 0x000831B0
	public static T InstantiatePlayerRoot<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PlayerRoot, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, global::NetCull.noArgs);
		instantiateArgs.playerRoot = true;
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022DE RID: 8926 RVA: 0x00084FF8 File Offset: 0x000831F8
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022DF RID: 8927 RVA: 0x00085040 File Offset: 0x00083240
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022E0 RID: 8928 RVA: 0x00085088 File Offset: 0x00083288
	public static T InstantiatePlayerRootWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PlayerRoot_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		instantiateArgs.playerRoot = true;
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022E1 RID: 8929 RVA: 0x000850D0 File Offset: 0x000832D0
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022E2 RID: 8930 RVA: 0x00085118 File Offset: 0x00083318
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.PlayerRoot_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		instantiateArgs.playerRoot = true;
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022E3 RID: 8931 RVA: 0x00085160 File Offset: 0x00083360
	public static T InstantiatePlayerRootWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.PlayerRoot_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, null, args);
		instantiateArgs.playerRoot = true;
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022E4 RID: 8932 RVA: 0x000851A8 File Offset: 0x000833A8
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs<TArg>(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePlayerRootWithArgs(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022E5 RID: 8933 RVA: 0x000851D0 File Offset: 0x000833D0
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs<TArg>(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePlayerRootWithArgs(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022E6 RID: 8934 RVA: 0x000851F8 File Offset: 0x000833F8
	public static T InstantiatePlayerRootWithArgs<T, TArg>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiatePlayerRootWithArgs<T>(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022E7 RID: 8935 RVA: 0x00085220 File Offset: 0x00083420
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePlayerRootWithArgs(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022E8 RID: 8936 RVA: 0x00085248 File Offset: 0x00083448
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiatePlayerRootWithArgs(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022E9 RID: 8937 RVA: 0x00085270 File Offset: 0x00083470
	public static T InstantiatePlayerRootWithArgs<T, TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiatePlayerRootWithArgs<T>(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x060022EA RID: 8938 RVA: 0x00085298 File Offset: 0x00083498
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022EB RID: 8939 RVA: 0x000852A4 File Offset: 0x000834A4
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiatePlayerRootWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022EC RID: 8940 RVA: 0x000852B0 File Offset: 0x000834B0
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022ED RID: 8941 RVA: 0x000852BC File Offset: 0x000834BC
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022EE RID: 8942 RVA: 0x000852C8 File Offset: 0x000834C8
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiatePlayerRootWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022EF RID: 8943 RVA: 0x000852D4 File Offset: 0x000834D4
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022F0 RID: 8944 RVA: 0x000852E0 File Offset: 0x000834E0
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022F1 RID: 8945 RVA: 0x000852EC File Offset: 0x000834EC
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiatePlayerRootWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022F2 RID: 8946 RVA: 0x000852F8 File Offset: 0x000834F8
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiatePlayerRootWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x060022F3 RID: 8947 RVA: 0x00085304 File Offset: 0x00083504
	public static global::UnityEngine.GameObject InstantiateStatic(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022F4 RID: 8948 RVA: 0x00085348 File Offset: 0x00083548
	public static global::UnityEngine.GameObject InstantiateStatic(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022F5 RID: 8949 RVA: 0x0008538C File Offset: 0x0008358C
	public static T InstantiateStatic<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Static, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022F6 RID: 8950 RVA: 0x000853D0 File Offset: 0x000835D0
	public static global::UnityEngine.GameObject InstantiateStatic(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022F7 RID: 8951 RVA: 0x00085414 File Offset: 0x00083614
	public static global::UnityEngine.GameObject InstantiateStatic(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022F8 RID: 8952 RVA: 0x00085458 File Offset: 0x00083658
	public static T InstantiateStatic<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Static, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022F9 RID: 8953 RVA: 0x0008549C File Offset: 0x0008369C
	public static global::UnityEngine.GameObject InstantiateStatic(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static, null, null, prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022FA RID: 8954 RVA: 0x000854E4 File Offset: 0x000836E4
	public static global::UnityEngine.GameObject InstantiateStatic(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static, null, null, prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022FB RID: 8955 RVA: 0x0008552C File Offset: 0x0008372C
	public static T InstantiateStatic<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Static, null, null, prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), global::NetCull.noArgs);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022FC RID: 8956 RVA: 0x00085574 File Offset: 0x00083774
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022FD RID: 8957 RVA: 0x000855B4 File Offset: 0x000837B4
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x060022FE RID: 8958 RVA: 0x000855F4 File Offset: 0x000837F4
	public static T InstantiateStaticWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Static_Args, new global::uLink.NetworkViewID?(view), new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x060022FF RID: 8959 RVA: 0x00085634 File Offset: 0x00083834
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002300 RID: 8960 RVA: 0x00085678 File Offset: 0x00083878
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002301 RID: 8961 RVA: 0x000856BC File Offset: 0x000838BC
	public static T InstantiateStaticWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Static_Args, null, new global::uLink.NetworkPlayer?(owner), prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002302 RID: 8962 RVA: 0x00085700 File Offset: 0x00083900
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static_Args, null, null, prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002303 RID: 8963 RVA: 0x00085744 File Offset: 0x00083944
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args)
	{
		global::NetCull.InstantiateArgs instantiateArgs = new global::NetCull.InstantiateArgs(global::NetCullInstantiationCall.Static_Args, null, null, prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (global::UnityEngine.GameObject)global::NetCull.Instantiate(ref instantiateArgs);
	}

	// Token: 0x06002304 RID: 8964 RVA: 0x00085788 File Offset: 0x00083988
	public static T InstantiateStaticWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, params object[] args) where T : global::UnityEngine.Component
	{
		global::NetCull.InstantiateArgs<T> instantiateArgs = new global::NetCull.InstantiateArgs<T>(global::NetCullInstantiationCall.Static_Args, null, null, prefab, position, rotation, new int?(global::CullGrid.WorldGroupID(ref position)), args);
		return (T)((object)global::NetCull.Instantiate<T>(ref instantiateArgs));
	}

	// Token: 0x06002305 RID: 8965 RVA: 0x000857CC File Offset: 0x000839CC
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs<TArg>(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateStaticWithArgs(prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x06002306 RID: 8966 RVA: 0x000857E8 File Offset: 0x000839E8
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs<TArg>(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateStaticWithArgs(prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x06002307 RID: 8967 RVA: 0x00085804 File Offset: 0x00083A04
	public static T InstantiateStaticWithArgs<T, TArg>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateStaticWithArgs<T>(prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x06002308 RID: 8968 RVA: 0x00085820 File Offset: 0x00083A20
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs<TArg>(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateStaticWithArgs(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x06002309 RID: 8969 RVA: 0x00085848 File Offset: 0x00083A48
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs<TArg>(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateStaticWithArgs(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x0600230A RID: 8970 RVA: 0x00085870 File Offset: 0x00083A70
	public static T InstantiateStaticWithArgs<T, TArg>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateStaticWithArgs<T>(owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x0600230B RID: 8971 RVA: 0x00085898 File Offset: 0x00083A98
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateStaticWithArgs(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x0600230C RID: 8972 RVA: 0x000858C0 File Offset: 0x00083AC0
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs<TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg)
	{
		return global::NetCull.InstantiateStaticWithArgs(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x0600230D RID: 8973 RVA: 0x000858E8 File Offset: 0x00083AE8
	public static T InstantiateStaticWithArgs<T, TArg>(global::uLink.NetworkViewID viewID, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, TArg arg) where T : global::UnityEngine.Component
	{
		return global::NetCull.InstantiateStaticWithArgs<T>(viewID, owner, prefab, position, rotation, new object[]
		{
			arg
		});
	}

	// Token: 0x0600230E RID: 8974 RVA: 0x00085910 File Offset: 0x00083B10
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x0600230F RID: 8975 RVA: 0x0008591C File Offset: 0x00083B1C
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateStaticWithArgs<T>(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002310 RID: 8976 RVA: 0x00085928 File Offset: 0x00083B28
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkViewID view, global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002311 RID: 8977 RVA: 0x00085934 File Offset: 0x00083B34
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkPlayer owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002312 RID: 8978 RVA: 0x00085940 File Offset: 0x00083B40
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateStaticWithArgs<T>(global::uLink.NetworkPlayer owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002313 RID: 8979 RVA: 0x0008594C File Offset: 0x00083B4C
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::uLink.NetworkPlayer owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002314 RID: 8980 RVA: 0x00085958 File Offset: 0x00083B58
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002315 RID: 8981 RVA: 0x00085964 File Offset: 0x00083B64
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static T InstantiateStaticWithArgs<T>(T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation) where T : global::UnityEngine.Component
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002316 RID: 8982 RVA: 0x00085970 File Offset: 0x00083B70
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::UnityEngine.GameObject InstantiateStaticWithArgs(string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		throw new global::System.InvalidOperationException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06002317 RID: 8983 RVA: 0x0008597C File Offset: 0x00083B7C
	internal static global::UnityEngine.GameObject InstantiateHelper(global::NetCull.GroupMode groupMode, global::uLink.NetworkPlayer? owner, global::NetworkCullInfo piggy, string prefabName, ref global::UnityEngine.Vector3 position, ref global::UnityEngine.Quaternion rotation, bool anyArguments, object[] args)
	{
		bool flag = piggy;
		if ((groupMode & (global::NetCull.GroupMode)0x20) == (global::NetCull.GroupMode)0x20)
		{
			if (flag)
			{
				groupMode &= (global::NetCull.GroupMode)(-0x21);
			}
			else
			{
				groupMode = global::NetCull.GroupMode.Dynamic;
			}
		}
		if (flag && groupMode != global::NetCull.GroupMode.PiggyBack)
		{
			global::UnityEngine.Debug.LogWarning("You gave a piggy but didnt use it.");
		}
		global::uLink.NetworkPlayer owner2;
		bool flag2;
		if (owner != null)
		{
			if ((groupMode & (global::NetCull.GroupMode)0x40) == (global::NetCull.GroupMode)0x40)
			{
				groupMode &= (global::NetCull.GroupMode)(-0x41);
			}
			owner2 = owner.Value;
			flag2 = true;
		}
		else
		{
			if ((groupMode & (global::NetCull.GroupMode)0x40) == (global::NetCull.GroupMode)0x40)
			{
				groupMode = global::NetCull.GroupMode.Dynamic;
			}
			owner2 = global::uLink.NetworkPlayer.unassigned;
			flag2 = false;
		}
		global::NetCull.GroupMode groupMode2 = groupMode;
		switch (groupMode2)
		{
		case global::NetCull.GroupMode.Static:
			if (flag2)
			{
				if (anyArguments)
				{
					return global::NetCull.InstantiateStaticWithArgs(owner2, prefabName, position, rotation, args);
				}
				return global::NetCull.InstantiateStatic(owner2, prefabName, position, rotation);
			}
			else
			{
				if (anyArguments)
				{
					return global::NetCull.InstantiateStaticWithArgs(prefabName, position, rotation, args);
				}
				return global::NetCull.InstantiateStatic(prefabName, position, rotation);
			}
			break;
		case global::NetCull.GroupMode.Dynamic:
			if (flag2)
			{
				if (anyArguments)
				{
					return global::NetCull.InstantiateDynamicWithArgs(owner2, prefabName, position, rotation, args);
				}
				return global::NetCull.InstantiateDynamic(owner2, prefabName, position, rotation);
			}
			else
			{
				if (anyArguments)
				{
					return global::NetCull.InstantiateDynamicWithArgs(prefabName, position, rotation, args);
				}
				return global::NetCull.InstantiateDynamic(prefabName, position, rotation);
			}
			break;
		case global::NetCull.GroupMode.PlayerRoot:
			if (!flag2)
			{
				throw new global::System.ArgumentException("player was not defined with PlayerRoot");
			}
			if (anyArguments)
			{
				return global::NetCull.InstantiatePlayerRootWithArgs(owner2, prefabName, position, rotation, args);
			}
			return global::NetCull.InstantiatePlayerRoot(owner2, prefabName, position, rotation);
		default:
			if (groupMode2 != global::NetCull.GroupMode.PiggyBack)
			{
				throw new global::System.NotImplementedException();
			}
			if (!flag)
			{
				throw new global::System.ArgumentException("there was no piggy");
			}
			if (flag2)
			{
				if (anyArguments)
				{
					return global::NetCull.InstantiatePiggyBackWithArgs(owner2, piggy, prefabName, position, rotation, args);
				}
				return global::NetCull.InstantiatePiggyBack(owner2, piggy, prefabName, position, rotation);
			}
			else
			{
				if (anyArguments)
				{
					return global::NetCull.InstantiatePiggyBackWithArgs(piggy, prefabName, position, rotation, args);
				}
				return global::NetCull.InstantiatePiggyBack(piggy, prefabName, position, rotation);
			}
			break;
		}
	}

	// Token: 0x170007F0 RID: 2032
	// (get) Token: 0x06002318 RID: 8984 RVA: 0x00085BD4 File Offset: 0x00083DD4
	public static bool ForbidCulling
	{
		get
		{
			return !global::NetCull.allow_net_cull;
		}
	}

	// Token: 0x170007F1 RID: 2033
	// (get) Token: 0x06002319 RID: 8985 RVA: 0x00085BE0 File Offset: 0x00083DE0
	private static global::uLink.NetworkPlayer noOwnerValue
	{
		get
		{
			return global::uLink.Network.player;
		}
	}

	// Token: 0x0600231A RID: 8986 RVA: 0x00085BE8 File Offset: 0x00083DE8
	private static int FindGroupID(ref global::UnityEngine.Vector3 pos)
	{
		if (global::NetCull.allow_net_cull)
		{
			return global::CullGrid.WorldGroupID(ref pos);
		}
		return 0;
	}

	// Token: 0x0600231B RID: 8987 RVA: 0x00085BFC File Offset: 0x00083DFC
	private static void InstantiateGetGroups(global::NetworkCullInfo piggy, int? groupInput, ref global::UnityEngine.Vector3 position, out int group, out int useGroup)
	{
		useGroup = ((groupInput == null) ? ((!piggy) ? global::NetCull.FindGroupID(ref position) : piggy.setGroupID) : groupInput.Value);
		group = useGroup;
	}

	// Token: 0x170007F2 RID: 2034
	// (get) Token: 0x0600231C RID: 8988 RVA: 0x00085C48 File Offset: 0x00083E48
	public static bool isCurrentlyInstantiating
	{
		get
		{
			return global::NetCull.current_instantiating_count > 0;
		}
	}

	// Token: 0x170007F3 RID: 2035
	// (get) Token: 0x0600231D RID: 8989 RVA: 0x00085C54 File Offset: 0x00083E54
	public static global::NetCull.InstantiateArgs currentlyInstantiating
	{
		get
		{
			return global::NetCull.current_instantiating;
		}
	}

	// Token: 0x0600231E RID: 8990 RVA: 0x00085C5C File Offset: 0x00083E5C
	private static global::UnityEngine.Object Instantiate(ref global::NetCull.InstantiateArgs ia)
	{
		int num;
		int num2;
		global::NetCull.InstantiateGetGroups(ia.piggy, ia.group, ref ia.position, out num, out num2);
		if (ia.prefabType != 1 || ia.prefabName[0] != ';')
		{
			global::NetCull.PreInstantiate(ref ia, num, num2);
			global::NetCull.InstantiateArgs instantiateArgs = global::NetCull.current_instantiating;
			global::UnityEngine.Object instance;
			try
			{
				global::NetCull.current_instantiating_count++;
				global::NetCull.current_instantiating = ia;
				if (ia.view != null)
				{
					if (ia.owner != null)
					{
						switch (ia.prefabType)
						{
						case 1:
							instance = global::uLink.Network.Instantiate(ia.view.Value, ia.owner.Value, ia.prefabName, ia.prefabName, ia.prefabName, ia.position, ia.rotation, num, ia.args);
							break;
						case 2:
							instance = global::uLink.Network.Instantiate(ia.view.Value, ia.owner.Value, ia.prefabGameObject, ia.prefabGameObject, ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
							break;
						case 3:
							instance = global::uLink.Network.Instantiate<global::UnityEngine.Component>(ia.view.Value, ia.owner.Value, ia.prefabComponent, ia.prefabComponent, ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
							break;
						default:
							throw new global::System.ArgumentException("instantiate args invalid.", "ia");
						}
					}
					else
					{
						switch (ia.prefabType)
						{
						case 1:
							instance = global::uLink.Network.Instantiate(ia.view.Value, global::NetCull.noOwnerValue, ia.prefabName, ia.prefabName, ia.prefabName, ia.position, ia.rotation, num, ia.args);
							break;
						case 2:
							instance = global::uLink.Network.Instantiate(ia.view.Value, global::NetCull.noOwnerValue, ia.prefabGameObject, ia.prefabGameObject, ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
							break;
						case 3:
							instance = global::uLink.Network.Instantiate<global::UnityEngine.Component>(ia.view.Value, global::NetCull.noOwnerValue, ia.prefabComponent, ia.prefabComponent, ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
							break;
						default:
							throw new global::System.ArgumentException("instantiate args invalid.", "ia");
						}
					}
				}
				else if (ia.owner != null)
				{
					switch (ia.prefabType)
					{
					case 1:
						instance = global::uLink.Network.Instantiate(ia.owner.Value, ia.prefabName, ia.position, ia.rotation, num, ia.args);
						break;
					case 2:
						instance = global::uLink.Network.Instantiate(ia.owner.Value, ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
						break;
					case 3:
						instance = global::uLink.Network.Instantiate<global::UnityEngine.Component>(ia.owner.Value, ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
						break;
					default:
						throw new global::System.ArgumentException("instantiate args invalid.", "ia");
					}
				}
				else
				{
					switch (ia.prefabType)
					{
					case 1:
						instance = global::uLink.Network.Instantiate(ia.prefabName, ia.position, ia.rotation, num, ia.args);
						break;
					case 2:
						instance = global::uLink.Network.Instantiate(ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
						break;
					case 3:
						instance = global::uLink.Network.Instantiate<global::UnityEngine.Component>(ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
						break;
					default:
						throw new global::System.ArgumentException("instantiate args invalid.", "ia");
					}
				}
			}
			finally
			{
				global::NetCull.current_instantiating = instantiateArgs;
				global::NetCull.current_instantiating_count--;
			}
			return global::NetCull.Instantiated(instance, num, num2, ref ia);
		}
		global::NetCullInstantiationCall call = ia.call;
		if (call != global::NetCullInstantiationCall.Static && call != global::NetCullInstantiationCall.Static_Args)
		{
			global::UnityEngine.Debug.LogError("YOU CAN'T USE NGC WITH " + ia.call);
			return null;
		}
		return global::NGC.Instantiate(ref ia, num2);
	}

	// Token: 0x0600231F RID: 8991 RVA: 0x00086118 File Offset: 0x00084318
	private static global::UnityEngine.Object Instantiate<T>(ref global::NetCull.InstantiateArgs<T> ia) where T : global::UnityEngine.Component
	{
		int num;
		int setGroup;
		global::NetCull.InstantiateGetGroups(ia.piggy, ia.group, ref ia.position, out num, out setGroup);
		global::NetCull.InstantiateArgs instantiateArgs = (global::NetCull.InstantiateArgs)ia;
		global::NetCull.PreInstantiate(ref instantiateArgs, num, setGroup);
		global::NetCull.InstantiateArgs instantiateArgs2 = global::NetCull.current_instantiating;
		global::UnityEngine.Object instance;
		try
		{
			global::NetCull.current_instantiating_count++;
			global::NetCull.current_instantiating = instantiateArgs;
			if (ia.view != null)
			{
				if (ia.owner != null)
				{
					switch (ia.prefabType)
					{
					case 1:
						instance = global::uLink.Network.Instantiate(ia.view.Value, ia.owner.Value, ia.prefabName, ia.prefabName, ia.prefabName, ia.position, ia.rotation, num, ia.args);
						break;
					case 2:
						instance = global::uLink.Network.Instantiate(ia.view.Value, ia.owner.Value, ia.prefabGameObject, ia.prefabGameObject, ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
						break;
					case 3:
						instance = global::uLink.Network.Instantiate<T>(ia.view.Value, ia.owner.Value, ia.prefabComponent, ia.prefabComponent, ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
						break;
					default:
						throw new global::System.ArgumentException("instantiate args invalid.", "ia");
					}
				}
				else
				{
					switch (ia.prefabType)
					{
					case 1:
						instance = global::uLink.Network.Instantiate(ia.view.Value, global::NetCull.noOwnerValue, ia.prefabName, ia.prefabName, ia.prefabName, ia.position, ia.rotation, num, ia.args);
						break;
					case 2:
						instance = global::uLink.Network.Instantiate(ia.view.Value, global::NetCull.noOwnerValue, ia.prefabGameObject, ia.prefabGameObject, ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
						break;
					case 3:
						instance = global::uLink.Network.Instantiate<T>(ia.view.Value, global::NetCull.noOwnerValue, ia.prefabComponent, ia.prefabComponent, ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
						break;
					default:
						throw new global::System.ArgumentException("instantiate args invalid.", "ia");
					}
				}
			}
			else if (ia.owner != null)
			{
				switch (ia.prefabType)
				{
				case 1:
					instance = global::uLink.Network.Instantiate(ia.owner.Value, ia.prefabName, ia.position, ia.rotation, num, ia.args);
					break;
				case 2:
					instance = global::uLink.Network.Instantiate(ia.owner.Value, ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
					break;
				case 3:
					instance = global::uLink.Network.Instantiate<T>(ia.owner.Value, ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
					break;
				default:
					throw new global::System.ArgumentException("instantiate args invalid.", "ia");
				}
			}
			else
			{
				switch (ia.prefabType)
				{
				case 1:
					instance = global::uLink.Network.Instantiate(ia.prefabName, ia.position, ia.rotation, num, ia.args);
					break;
				case 2:
					instance = global::uLink.Network.Instantiate(ia.prefabGameObject, ia.position, ia.rotation, num, ia.args);
					break;
				case 3:
					instance = global::uLink.Network.Instantiate<T>(ia.prefabComponent, ia.position, ia.rotation, num, ia.args);
					break;
				default:
					throw new global::System.ArgumentException("instantiate args invalid.", "ia");
				}
			}
		}
		finally
		{
			global::NetCull.current_instantiating = instantiateArgs2;
			global::NetCull.current_instantiating_count--;
		}
		return global::NetCull.Instantiated(instance, num, setGroup, ref instantiateArgs);
	}

	// Token: 0x06002320 RID: 8992 RVA: 0x00086590 File Offset: 0x00084790
	public static bool GetNetworkView(global::UnityEngine.Object instance, out global::Facepunch.NetworkView view)
	{
		if (instance is global::UnityEngine.GameObject)
		{
			global::Facepunch.NetworkView networkView;
			view = (networkView = global::Facepunch.NetworkView.Get((global::UnityEngine.GameObject)instance));
			return networkView;
		}
		if (instance is global::UnityEngine.Component)
		{
			global::Facepunch.NetworkView networkView;
			view = (networkView = global::Facepunch.NetworkView.Get((global::UnityEngine.Component)instance));
			return networkView;
		}
		view = null;
		return false;
	}

	// Token: 0x170007F4 RID: 2036
	// (get) Token: 0x06002321 RID: 8993 RVA: 0x000865E4 File Offset: 0x000847E4
	private static int net_deniedcount
	{
		get
		{
			return global::NetCull.deniedInstantiateCount;
		}
	}

	// Token: 0x06002322 RID: 8994 RVA: 0x000865EC File Offset: 0x000847EC
	private static void PreInstantiate(ref global::NetCull.InstantiateArgs ia, int instantiatedGroup, int setGroup)
	{
		if (ia.group == null && !global::CullGrid.AreGroupsRegistered)
		{
			global::NetCull.deniedInstantiateCount++;
			throw new global::System.InvalidOperationException("Groups are not registered on the server!! You cannot instantiate " + ia);
		}
		if (ia.playerRoot && ia.owner != null && global::CullGrid.autoPrebindInInstantiate && global::CullGrid.IsCellGroupID(instantiatedGroup))
		{
			global::NetUser netUser = global::NetUser.Find(ia.owner.Value);
			if (netUser != null)
			{
				global::CullGrid.PrebindPlayerRootByGroupID(netUser, instantiatedGroup);
			}
		}
	}

	// Token: 0x06002323 RID: 8995 RVA: 0x0008668C File Offset: 0x0008488C
	private static global::UnityEngine.Object Instantiated(global::UnityEngine.Object instance, int instantiatedGroup, int setGroup, ref global::NetCull.InstantiateArgs ia)
	{
		if (ia.group != instantiatedGroup && global::CullGrid.IsCellGroupID(setGroup))
		{
			global::Facepunch.NetworkView view;
			if (global::NetCull.GetNetworkView(instance, out view))
			{
				global::NetworkCullInfo networkCullInfo = global::NetCull.RegisterCullInfo(view, ia.piggy, ia.piggy, ia.owner);
				if (ia.owner != null)
				{
					if (ia.playerRoot)
					{
						networkCullInfo.playerRoot = true;
						global::CullGrid.RegisterPlayerRootNetworkCullInfo(networkCullInfo);
					}
					else
					{
						networkCullInfo.playerRoot = false;
						global::CullGrid.RegisterPlayerNonRootNetworkCullInfo(networkCullInfo);
					}
				}
				try
				{
					networkCullInfo.OnInitialRegistrationComplete();
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex);
				}
			}
			else
			{
				global::UnityEngine.Debug.LogError("Could not get view, will not be dynamic group " + instance, instance);
			}
		}
		return instance;
	}

	// Token: 0x06002324 RID: 8996 RVA: 0x00086778 File Offset: 0x00084978
	private static global::NetworkCullInfo RegisterCullInfo(global::Facepunch.NetworkView view, global::NetworkCullInfo piggy, bool isRider, global::uLink.NetworkPlayer? owner)
	{
		global::NetworkCullInfo networkCullInfo = view.GetComponent<global::NetworkCullInfo>();
		if (networkCullInfo)
		{
			if (networkCullInfo.valid)
			{
				return networkCullInfo;
			}
		}
		else
		{
			networkCullInfo = view.gameObject.AddComponent<global::NetworkCullInfo>();
		}
		try
		{
			networkCullInfo.instantiating = true;
			if (owner != null)
			{
				networkCullInfo.user = global::NetUser.Find(owner.Value);
			}
			networkCullInfo.isUser = (owner != null && networkCullInfo.user != null);
			networkCullInfo.transform = view.transform;
			networkCullInfo.position = networkCullInfo.transform.position;
			networkCullInfo.initialGroupID = (networkCullInfo.workingGroupID = (networkCullInfo.lastWorkingGroupID = (networkCullInfo.setGroupID = view.group.id)));
			networkCullInfo.view = view;
			networkCullInfo.piggy = piggy;
			networkCullInfo.valid = true;
			if (isRider)
			{
				networkCullInfo.riding = true;
				networkCullInfo.piggy.AddBacker(networkCullInfo);
			}
			else
			{
				networkCullInfo.riding = false;
				global::NetCull.CullProcessor.RegisterMover(networkCullInfo);
			}
		}
		finally
		{
			networkCullInfo.instantiating = false;
		}
		return networkCullInfo;
	}

	// Token: 0x06002325 RID: 8997 RVA: 0x000868B4 File Offset: 0x00084AB4
	internal static void Unregister(global::NetworkCullInfo cullInfo)
	{
	}

	// Token: 0x06002326 RID: 8998 RVA: 0x000868B8 File Offset: 0x00084AB8
	private static void ListMovers()
	{
		global::NetCull.CullProcessor.ListMovers();
	}

	// Token: 0x06002327 RID: 8999 RVA: 0x000868C0 File Offset: 0x00084AC0
	private static void ReverseDestroyBackerList(ref global::System.Collections.Generic.HashSet<global::NetworkCullInfo>.Enumerator enumerator)
	{
		if (enumerator.MoveNext())
		{
			global::NetworkCullInfo networkCullInfo = enumerator.Current;
			global::NetCull.ReverseDestroyBackerList(ref enumerator);
			if (networkCullInfo && networkCullInfo.valid)
			{
				global::NetCull.ShutdownNetworkCullInfoAndDestroy(networkCullInfo, true, false);
			}
		}
	}

	// Token: 0x170007F5 RID: 2037
	// (get) Token: 0x06002328 RID: 9000 RVA: 0x00086904 File Offset: 0x00084B04
	// (set) Token: 0x06002329 RID: 9001 RVA: 0x0008690C File Offset: 0x00084B0C
	public static int minimumAllocatableViewIDs
	{
		get
		{
			return global::uLink.Network.minimumAllocatableViewIDs;
		}
		set
		{
			global::uLink.Network.minimumAllocatableViewIDs = value;
		}
	}

	// Token: 0x170007F6 RID: 2038
	// (get) Token: 0x0600232A RID: 9002 RVA: 0x00086914 File Offset: 0x00084B14
	// (set) Token: 0x0600232B RID: 9003 RVA: 0x0008691C File Offset: 0x00084B1C
	public static int maxManualViewIDs
	{
		get
		{
			return global::uLink.Network.maxManualViewIDs;
		}
		set
		{
			global::uLink.Network.maxManualViewIDs = value;
		}
	}

	// Token: 0x170007F7 RID: 2039
	// (get) Token: 0x0600232C RID: 9004 RVA: 0x00086924 File Offset: 0x00084B24
	// (set) Token: 0x0600232D RID: 9005 RVA: 0x0008692C File Offset: 0x00084B2C
	public static int minimumUsedViewIDs
	{
		get
		{
			return global::uLink.Network.minimumUsedViewIDs;
		}
		set
		{
			global::uLink.Network.minimumUsedViewIDs = value;
		}
	}

	// Token: 0x170007F8 RID: 2040
	// (get) Token: 0x0600232E RID: 9006 RVA: 0x00086934 File Offset: 0x00084B34
	public static int networkViewCount
	{
		get
		{
			return global::uLink.Network.networkViewCount;
		}
	}

	// Token: 0x170007F9 RID: 2041
	// (get) Token: 0x0600232F RID: 9007 RVA: 0x0008693C File Offset: 0x00084B3C
	// (set) Token: 0x06002330 RID: 9008 RVA: 0x00086944 File Offset: 0x00084B44
	public static int maxConnections
	{
		get
		{
			return global::uLink.Network.maxConnections;
		}
		set
		{
			global::uLink.Network.maxConnections = value;
		}
	}

	// Token: 0x170007FA RID: 2042
	// (get) Token: 0x06002331 RID: 9009 RVA: 0x0008694C File Offset: 0x00084B4C
	private static int net_connections
	{
		get
		{
			return global::uLink.Network.connections.Length;
		}
	}

	// Token: 0x06002332 RID: 9010 RVA: 0x00086958 File Offset: 0x00084B58
	private static void ShutdownNetworkCullInfoAndDestroy(global::NetworkCullInfo info)
	{
		global::NetCull.ShutdownNetworkCullInfoAndDestroy(info, false, true);
	}

	// Token: 0x06002333 RID: 9011 RVA: 0x00086964 File Offset: 0x00084B64
	private static void ShutdownNetworkCullInfoAndDestroy(global::NetworkCullInfo info, bool implicitDestroy, bool checkNull)
	{
		if ((!checkNull || info) && info.valid)
		{
			if (info.anyBackers)
			{
				global::System.Collections.Generic.HashSet<global::NetworkCullInfo>.Enumerator enumerator = info.backers.GetEnumerator();
				try
				{
					global::NetCull.ReverseDestroyBackerList(ref enumerator);
				}
				finally
				{
					enumerator.Dispose();
				}
			}
			if (!info.valid)
			{
				return;
			}
			if (info.view)
			{
				global::uLink.NetworkViewID viewID = info.view.viewID;
				if (viewID != global::uLink.NetworkViewID.unassigned)
				{
					global::NetCull.RemoveRPCs(info.view.viewID);
				}
			}
			global::uLink.Network.Destroy(info.gameObject);
		}
	}

	// Token: 0x06002334 RID: 9012 RVA: 0x00086A28 File Offset: 0x00084C28
	public static void Destroy(global::UnityEngine.GameObject go)
	{
		global::NGCView component = go.GetComponent<global::NGCView>();
		if (component)
		{
			global::NGC.DispatchNetDestroy(component);
			return;
		}
		global::NetInstance.PreServerDestroy(go);
		global::NetworkCullInfo info;
		if (global::NetworkCullInfo.Find(go, out info))
		{
			global::NetCull.ShutdownNetworkCullInfoAndDestroy(info);
			return;
		}
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Get(go);
		if (networkView)
		{
			global::NetCull.RemoveRPCs(networkView.viewID);
		}
		global::uLink.Network.Destroy(go);
	}

	// Token: 0x06002335 RID: 9013 RVA: 0x00086A8C File Offset: 0x00084C8C
	public static void Destroy(global::Facepunch.NetworkView view)
	{
		global::NetInstance.PreServerDestroy(view);
		global::NetworkCullInfo info;
		if (global::NetworkCullInfo.Find(view, out info))
		{
			global::NetCull.ShutdownNetworkCullInfoAndDestroy(info);
			return;
		}
		global::NetCull.RemoveRPCs(view.viewID);
		global::uLink.Network.Destroy(view);
	}

	// Token: 0x06002336 RID: 9014 RVA: 0x00086AC8 File Offset: 0x00084CC8
	public static void Destroy(global::uLink.NetworkViewID viewID)
	{
		global::NetInstance.PreServerDestroy(viewID);
		global::NetworkCullInfo info;
		if (global::NetworkCullInfo.Find(viewID, out info))
		{
			global::NetCull.ShutdownNetworkCullInfoAndDestroy(info);
			return;
		}
		global::NetCull.RemoveRPCs(viewID);
		global::uLink.Network.Destroy(viewID);
	}

	// Token: 0x06002337 RID: 9015 RVA: 0x00086AFC File Offset: 0x00084CFC
	public static void RemoveRPCs(global::uLink.NetworkViewID viewID)
	{
		global::uLink.Network.RemoveRPCs(viewID);
	}

	// Token: 0x06002338 RID: 9016 RVA: 0x00086B04 File Offset: 0x00084D04
	public static void RemoveRPCs(global::NetEntityID entID)
	{
		if (entID.isNGC)
		{
			global::NGC.InternalRemoveRPCs(entID.id);
		}
		else
		{
			global::uLink.Network.RemoveRPCs((global::uLink.NetworkViewID)entID);
		}
	}

	// Token: 0x06002339 RID: 9017 RVA: 0x00086B30 File Offset: 0x00084D30
	public static void RemoveRPCs(global::NGCView view)
	{
		if (view)
		{
			global::NGC.InternalRemoveRPCs(view);
		}
	}

	// Token: 0x0600233A RID: 9018 RVA: 0x00086B44 File Offset: 0x00084D44
	public static void RemoveRPCs(global::uLink.NetworkPlayer player)
	{
		global::uLink.Network.RemoveRPCs(player);
	}

	// Token: 0x0600233B RID: 9019 RVA: 0x00086B4C File Offset: 0x00084D4C
	public static void RemoveRPCs(global::uLink.NetworkPlayer player, global::uLink.NetworkGroup group)
	{
		global::uLink.Network.RemoveRPCs(player, group);
	}

	// Token: 0x0600233C RID: 9020 RVA: 0x00086B58 File Offset: 0x00084D58
	public static void RemoveRPCs(global::Facepunch.NetworkView view)
	{
		global::NetCull.RemoveRPCs(view.viewID);
	}

	// Token: 0x0600233D RID: 9021 RVA: 0x00086B68 File Offset: 0x00084D68
	public static void DestroyPlayerObjects(global::uLink.NetworkPlayer player)
	{
		global::NetCull.RemoveRPCs(player);
		global::uLink.Network.DestroyPlayerObjects(player);
	}

	// Token: 0x0600233E RID: 9022 RVA: 0x00086B78 File Offset: 0x00084D78
	public static void RemoveRPCsByName(global::Facepunch.NetworkView view, string rpcName)
	{
		global::NetCull.RemoveRPCsByName(view.viewID, rpcName);
	}

	// Token: 0x0600233F RID: 9023 RVA: 0x00086B88 File Offset: 0x00084D88
	public static void RemoveRPCsByName(global::uLink.NetworkViewID viewID, string rpcName)
	{
		global::uLink.Network.RemoveRPCsByName(viewID, rpcName);
	}

	// Token: 0x06002340 RID: 9024 RVA: 0x00086B94 File Offset: 0x00084D94
	public static void RemoveRPCsByName(global::NGCView view, string rpcName)
	{
		global::NGC.InternalRemoveRPCsByName(view, rpcName);
	}

	// Token: 0x06002341 RID: 9025 RVA: 0x00086BA0 File Offset: 0x00084DA0
	public static void RemoveRPCsByName(global::NetEntityID entID, string rpcName)
	{
		if (entID.isNGC)
		{
			global::NGC.InternalRemoveRPCsByName(entID.id, rpcName);
		}
		else
		{
			global::NetCull.RemoveRPCsByName((global::uLink.NetworkViewID)entID, rpcName);
		}
	}

	// Token: 0x170007FB RID: 2043
	// (get) Token: 0x06002342 RID: 9026 RVA: 0x00086BD8 File Offset: 0x00084DD8
	public static bool isClientRunning
	{
		get
		{
			return global::uLink.Network.isClient;
		}
	}

	// Token: 0x170007FC RID: 2044
	// (get) Token: 0x06002343 RID: 9027 RVA: 0x00086BE0 File Offset: 0x00084DE0
	public static bool isServerRunning
	{
		get
		{
			return global::uLink.Network.isServer;
		}
	}

	// Token: 0x170007FD RID: 2045
	// (get) Token: 0x06002344 RID: 9028 RVA: 0x00086BE8 File Offset: 0x00084DE8
	public static bool isNotRunning
	{
		get
		{
			return !global::uLink.Network.isClient && !global::uLink.Network.isServer;
		}
	}

	// Token: 0x170007FE RID: 2046
	// (get) Token: 0x06002345 RID: 9029 RVA: 0x00086C00 File Offset: 0x00084E00
	public static bool isRunning
	{
		get
		{
			return global::uLink.Network.isServer || global::uLink.Network.isClient;
		}
	}

	// Token: 0x170007FF RID: 2047
	// (get) Token: 0x06002346 RID: 9030 RVA: 0x00086C14 File Offset: 0x00084E14
	[global::System.Obsolete("Use #if CLIENT (unless your trying to check if the client is connected.. then use NetCull.isClientRunning")]
	public static bool isClient
	{
		get
		{
			return global::NetCull.isClientRunning;
		}
	}

	// Token: 0x17000800 RID: 2048
	// (get) Token: 0x06002347 RID: 9031 RVA: 0x00086C1C File Offset: 0x00084E1C
	[global::System.Obsolete("Use #if SERVER (unless your trying to check if the server is running.. then use NetCull.isServerRunning")]
	public static bool isServer
	{
		get
		{
			return global::NetCull.isServerRunning;
		}
	}

	// Token: 0x17000801 RID: 2049
	// (get) Token: 0x06002348 RID: 9032 RVA: 0x00086C24 File Offset: 0x00084E24
	public static global::uLink.NetworkPlayer player
	{
		get
		{
			return global::uLink.Network.player;
		}
	}

	// Token: 0x17000802 RID: 2050
	// (get) Token: 0x06002349 RID: 9033 RVA: 0x00086C2C File Offset: 0x00084E2C
	public static double time
	{
		get
		{
			return global::uLink.Network.time;
		}
	}

	// Token: 0x0600234A RID: 9034 RVA: 0x00086C34 File Offset: 0x00084E34
	[global::System.Obsolete("This is not obsolete, but if your using this in somewhere other than the grid cull code, you're likely ruining the grid culling code")]
	public static void SetGroupFlags(global::uLink.NetworkGroup group, global::uLink.NetworkGroupFlags flags)
	{
		global::uLink.Network.SetGroupFlags(group, flags);
	}

	// Token: 0x0600234B RID: 9035 RVA: 0x00086C40 File Offset: 0x00084E40
	[global::System.Obsolete("This is not obsolete, but if your using this in somewhere other than the grid cull code, you're likely ruining the grid culling code")]
	public static void AddPlayerToGroup(global::uLink.NetworkPlayer target, global::uLink.NetworkGroup group)
	{
		global::uLink.Network.AddPlayerToGroup(target, group);
	}

	// Token: 0x0600234C RID: 9036 RVA: 0x00086C4C File Offset: 0x00084E4C
	[global::System.Obsolete("This is not obsolete, but if your using this in somewhere other than the grid cull code, you're likely ruining the grid culling code")]
	public static void RemovePlayerFromGroup(global::uLink.NetworkPlayer target, global::uLink.NetworkGroup group)
	{
		global::uLink.Network.RemovePlayerFromGroup(target, group);
	}

	// Token: 0x17000803 RID: 2051
	// (get) Token: 0x0600234D RID: 9037 RVA: 0x00086C58 File Offset: 0x00084E58
	// (set) Token: 0x0600234E RID: 9038 RVA: 0x00086C60 File Offset: 0x00084E60
	public static float sendRate
	{
		get
		{
			return global::uLink.Network.sendRate;
		}
		set
		{
			global::uLink.Network.sendRate = value;
			global::NetCull.Send.Rate = global::uLink.Network.sendRate;
			global::NetCull.Send.Interval = 1.0 / (double)global::NetCull.Send.Rate;
			global::NetCull.Send.IntervalF = (float)global::NetCull.Send.Interval;
		}
	}

	// Token: 0x17000804 RID: 2052
	// (get) Token: 0x0600234F RID: 9039 RVA: 0x00086CA0 File Offset: 0x00084EA0
	public static double sendInterval
	{
		get
		{
			return global::NetCull.Send.Interval;
		}
	}

	// Token: 0x17000805 RID: 2053
	// (get) Token: 0x06002350 RID: 9040 RVA: 0x00086CA8 File Offset: 0x00084EA8
	public static float sendIntervalF
	{
		get
		{
			return global::NetCull.Send.IntervalF;
		}
	}

	// Token: 0x17000806 RID: 2054
	// (get) Token: 0x06002351 RID: 9041 RVA: 0x00086CB0 File Offset: 0x00084EB0
	public static ulong timeInMillis
	{
		get
		{
			return global::uLink.Network.timeInMillis;
		}
	}

	// Token: 0x17000807 RID: 2055
	// (get) Token: 0x06002352 RID: 9042 RVA: 0x00086CB8 File Offset: 0x00084EB8
	public static global::uLink.NetworkConfig config
	{
		get
		{
			return global::uLink.Network.config;
		}
	}

	// Token: 0x17000808 RID: 2056
	// (get) Token: 0x06002353 RID: 9043 RVA: 0x00086CC0 File Offset: 0x00084EC0
	public static global::uLink.NetworkPlayer[] connections
	{
		get
		{
			return global::uLink.Network.connections;
		}
	}

	// Token: 0x17000809 RID: 2057
	// (get) Token: 0x06002354 RID: 9044 RVA: 0x00086CC8 File Offset: 0x00084EC8
	public static global::uLink.NetworkStatus status
	{
		get
		{
			return global::uLink.Network.status;
		}
	}

	// Token: 0x1700080A RID: 2058
	// (get) Token: 0x06002355 RID: 9045 RVA: 0x00086CD0 File Offset: 0x00084ED0
	public static double localTime
	{
		get
		{
			return global::uLink.Network.localTime;
		}
	}

	// Token: 0x1700080B RID: 2059
	// (get) Token: 0x06002356 RID: 9046 RVA: 0x00086CD8 File Offset: 0x00084ED8
	public static ulong localTimeInMillis
	{
		get
		{
			return global::uLink.Network.localTimeInMillis;
		}
	}

	// Token: 0x1700080C RID: 2060
	// (get) Token: 0x06002357 RID: 9047 RVA: 0x00086CE0 File Offset: 0x00084EE0
	public static int listenPort
	{
		get
		{
			return global::uLink.Network.listenPort;
		}
	}

	// Token: 0x1700080D RID: 2061
	// (get) Token: 0x06002358 RID: 9048 RVA: 0x00086CE8 File Offset: 0x00084EE8
	public static global::uLink.BitStream approvalData
	{
		get
		{
			return global::uLink.Network.approvalData;
		}
	}

	// Token: 0x1700080E RID: 2062
	// (get) Token: 0x06002359 RID: 9049 RVA: 0x00086CF0 File Offset: 0x00084EF0
	// (set) Token: 0x0600235A RID: 9050 RVA: 0x00086CF8 File Offset: 0x00084EF8
	public static bool isMessageQueueRunning
	{
		get
		{
			return global::uLink.Network.isMessageQueueRunning;
		}
		set
		{
			global::uLink.Network.isMessageQueueRunning = value;
		}
	}

	// Token: 0x1700080F RID: 2063
	// (get) Token: 0x0600235B RID: 9051 RVA: 0x00086D00 File Offset: 0x00084F00
	// (set) Token: 0x0600235C RID: 9052 RVA: 0x00086D0C File Offset: 0x00084F0C
	public static global::NetError lastError
	{
		get
		{
			return global::uLink.Network.lastError.ToNetError();
		}
		set
		{
			global::uLink.Network.lastError = value._uLink();
		}
	}

	// Token: 0x0600235D RID: 9053 RVA: 0x00086D1C File Offset: 0x00084F1C
	public static void CloseConnection(global::uLink.NetworkPlayer target, bool sendDisconnectionNotification)
	{
		global::uLink.Network.CloseConnection(target, sendDisconnectionNotification, 3);
	}

	// Token: 0x0600235E RID: 9054 RVA: 0x00086D28 File Offset: 0x00084F28
	public static void ResynchronizeClock(double durationInSeconds)
	{
		global::uLink.Network.ResynchronizeClock(durationInSeconds);
	}

	// Token: 0x0600235F RID: 9055 RVA: 0x00086D30 File Offset: 0x00084F30
	[global::System.Obsolete("void NetCull.ResynchronizeClock(ulong) is deprecated, Bla bla bla don't use this", true)]
	public static void ResynchronizeClock(ulong intervalMillis)
	{
		global::uLink.Network.ResynchronizeClock(intervalMillis);
	}

	// Token: 0x06002360 RID: 9056 RVA: 0x00086D38 File Offset: 0x00084F38
	public static global::NetError InitializeServer(int maximumConnections, int listenPort)
	{
		return global::uLink.Network.InitializeServer(maximumConnections, listenPort).ToNetError();
	}

	// Token: 0x06002361 RID: 9057 RVA: 0x00086D48 File Offset: 0x00084F48
	public static void RegisterNetAutoPrefab(global::uLinkNetworkView viewPrefab)
	{
		if (viewPrefab)
		{
			string name = viewPrefab.name;
			try
			{
				global::NetCull.AutoPrefabs.all[name] = viewPrefab;
			}
			catch
			{
				global::UnityEngine.Debug.LogError("skipped duplicate prefab named " + name, viewPrefab);
				return;
			}
			global::uLink.NetworkInstantiator.AddPrefab(viewPrefab.gameObject);
		}
	}

	// Token: 0x06002362 RID: 9058 RVA: 0x00086DBC File Offset: 0x00084FBC
	public static bool Found(this global::NetCull.PrefabSearch search)
	{
		return (int)search != 0;
	}

	// Token: 0x06002363 RID: 9059 RVA: 0x00086DC8 File Offset: 0x00084FC8
	public static bool Missing(this global::NetCull.PrefabSearch search)
	{
		return (int)search == 0;
	}

	// Token: 0x06002364 RID: 9060 RVA: 0x00086DD0 File Offset: 0x00084FD0
	public static bool IsNGC(this global::NetCull.PrefabSearch search)
	{
		return (int)search == 1;
	}

	// Token: 0x06002365 RID: 9061 RVA: 0x00086DD8 File Offset: 0x00084FD8
	public static bool IsNet(this global::NetCull.PrefabSearch search)
	{
		return (int)search > 1;
	}

	// Token: 0x06002366 RID: 9062 RVA: 0x00086DE0 File Offset: 0x00084FE0
	public static bool IsNetMainPrefab(this global::NetCull.PrefabSearch search)
	{
		return (int)search == 2;
	}

	// Token: 0x06002367 RID: 9063 RVA: 0x00086DE8 File Offset: 0x00084FE8
	public static bool IsNetAutoPrefab(this global::NetCull.PrefabSearch search)
	{
		return (int)search == 3;
	}

	// Token: 0x06002368 RID: 9064 RVA: 0x00086DF0 File Offset: 0x00084FF0
	public static global::NetCull.PrefabSearch LoadPrefab(string prefabName, out global::UnityEngine.GameObject prefab)
	{
		if (string.IsNullOrEmpty(prefabName))
		{
			prefab = null;
			return global::NetCull.PrefabSearch.Missing;
		}
		if (prefabName.StartsWith(":"))
		{
			try
			{
				prefab = global::NetMainPrefab.Lookup<global::UnityEngine.GameObject>(prefabName);
				return (!prefab) ? global::NetCull.PrefabSearch.Missing : global::NetCull.PrefabSearch.NetMain;
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				prefab = null;
				return global::NetCull.PrefabSearch.Missing;
			}
		}
		if (prefabName.StartsWith(";"))
		{
			try
			{
				global::NGC.Prefab prefab2;
				if (!global::NGC.Prefab.Register.Find(prefabName, out prefab2))
				{
					prefab = null;
					return global::NetCull.PrefabSearch.Missing;
				}
				global::NGCView prefab3 = prefab2.prefab;
				if (prefab3)
				{
					prefab = prefab3.gameObject;
					return (!prefab) ? global::NetCull.PrefabSearch.Missing : global::NetCull.PrefabSearch.NGC;
				}
				prefab = null;
				return global::NetCull.PrefabSearch.Missing;
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2);
				prefab = null;
				return global::NetCull.PrefabSearch.Missing;
			}
		}
		global::NetCull.PrefabSearch result;
		try
		{
			global::uLinkNetworkView uLinkNetworkView;
			if (global::NetCull.AutoPrefabs.all.TryGetValue(prefabName, out uLinkNetworkView) && uLinkNetworkView)
			{
				global::UnityEngine.GameObject gameObject;
				prefab = (gameObject = uLinkNetworkView.gameObject);
				if (gameObject)
				{
					return global::NetCull.PrefabSearch.NetAuto;
				}
			}
			prefab = null;
			result = global::NetCull.PrefabSearch.Missing;
		}
		catch (global::System.Exception ex3)
		{
			global::UnityEngine.Debug.LogException(ex3);
			prefab = null;
			result = global::NetCull.PrefabSearch.Missing;
		}
		return result;
	}

	// Token: 0x06002369 RID: 9065 RVA: 0x00086F94 File Offset: 0x00085194
	public static global::UnityEngine.GameObject LoadPrefab(string prefabName)
	{
		global::UnityEngine.GameObject result;
		if ((int)global::NetCull.LoadPrefab(prefabName, out result) == 0)
		{
			throw new global::UnityEngine.MissingReferenceException(prefabName);
		}
		return result;
	}

	// Token: 0x0600236A RID: 9066 RVA: 0x00086FB8 File Offset: 0x000851B8
	public static global::NetCull.PrefabSearch LoadPrefabScript<T>(string prefabName, out T script) where T : global::UnityEngine.MonoBehaviour
	{
		global::UnityEngine.MonoBehaviour monoBehaviour;
		global::NetCull.PrefabSearch prefabSearch = global::NetCull.LoadPrefabView(prefabName, out monoBehaviour);
		if ((int)prefabSearch == 0)
		{
			script = (T)((object)null);
		}
		else if (monoBehaviour is T)
		{
			script = (T)((object)monoBehaviour);
		}
		else
		{
			script = monoBehaviour.GetComponent<T>();
			if (!script)
			{
				prefabSearch = global::NetCull.PrefabSearch.Missing;
			}
		}
		return prefabSearch;
	}

	// Token: 0x0600236B RID: 9067 RVA: 0x00087028 File Offset: 0x00085228
	public static T LoadPrefabScript<T>(string prefabName) where T : global::UnityEngine.MonoBehaviour
	{
		T result;
		if ((int)global::NetCull.LoadPrefabScript<T>(prefabName, out result) == 0)
		{
			throw new global::UnityEngine.MissingReferenceException(prefabName);
		}
		return result;
	}

	// Token: 0x0600236C RID: 9068 RVA: 0x0008704C File Offset: 0x0008524C
	public static global::NetCull.PrefabSearch LoadPrefabComponent<T>(string prefabName, out T component) where T : global::UnityEngine.Component
	{
		global::UnityEngine.MonoBehaviour monoBehaviour;
		global::NetCull.PrefabSearch prefabSearch = global::NetCull.LoadPrefabView(prefabName, out monoBehaviour);
		if ((int)prefabSearch == 0)
		{
			component = (T)((object)null);
		}
		else if (typeof(global::UnityEngine.MonoBehaviour).IsAssignableFrom(typeof(T)) && monoBehaviour is T)
		{
			component = (T)((object)monoBehaviour);
		}
		else
		{
			component = monoBehaviour.GetComponent<T>();
			if (!component)
			{
				prefabSearch = global::NetCull.PrefabSearch.Missing;
			}
		}
		return prefabSearch;
	}

	// Token: 0x0600236D RID: 9069 RVA: 0x000870D8 File Offset: 0x000852D8
	public static T LoadPrefabComponent<T>(string prefabName) where T : global::UnityEngine.Component
	{
		T result;
		if ((int)global::NetCull.LoadPrefabComponent<T>(prefabName, out result) == 0)
		{
			throw new global::UnityEngine.MissingReferenceException(prefabName);
		}
		return result;
	}

	// Token: 0x0600236E RID: 9070 RVA: 0x000870FC File Offset: 0x000852FC
	public static global::NetCull.PrefabSearch LoadPrefabView(string prefabName, out global::UnityEngine.MonoBehaviour prefabView)
	{
		if (string.IsNullOrEmpty(prefabName))
		{
			prefabView = null;
			return global::NetCull.PrefabSearch.Missing;
		}
		if (prefabName.StartsWith(":"))
		{
			try
			{
				prefabView = global::NetMainPrefab.Lookup<global::uLinkNetworkView>(prefabName);
				return (!prefabView) ? global::NetCull.PrefabSearch.Missing : global::NetCull.PrefabSearch.NetMain;
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				prefabView = null;
				return global::NetCull.PrefabSearch.Missing;
			}
		}
		if (prefabName.StartsWith(";"))
		{
			try
			{
				global::NGC.Prefab prefab;
				if (global::NGC.Prefab.Register.Find(prefabName, out prefab))
				{
					global::UnityEngine.MonoBehaviour prefab2;
					prefabView = (prefab2 = prefab.prefab);
					if (prefab2)
					{
						return global::NetCull.PrefabSearch.NGC;
					}
				}
				prefabView = null;
				return global::NetCull.PrefabSearch.Missing;
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2);
				prefabView = null;
				return global::NetCull.PrefabSearch.Missing;
			}
		}
		global::NetCull.PrefabSearch result;
		try
		{
			global::uLinkNetworkView uLinkNetworkView;
			if (!global::NetCull.AutoPrefabs.all.TryGetValue(prefabName, out uLinkNetworkView) || !uLinkNetworkView)
			{
				prefabView = uLinkNetworkView;
				result = global::NetCull.PrefabSearch.Missing;
			}
			else
			{
				prefabView = null;
				result = global::NetCull.PrefabSearch.NetAuto;
			}
		}
		catch (global::System.Exception ex3)
		{
			global::UnityEngine.Debug.LogException(ex3);
			prefabView = null;
			result = global::NetCull.PrefabSearch.Missing;
		}
		return result;
	}

	// Token: 0x0600236F RID: 9071 RVA: 0x0008726C File Offset: 0x0008546C
	public static global::UnityEngine.MonoBehaviour LoadPrefabView(string prefabName)
	{
		global::UnityEngine.MonoBehaviour result;
		if ((int)global::NetCull.LoadPrefabView(prefabName, out result) == 0)
		{
			throw new global::UnityEngine.MissingReferenceException(prefabName);
		}
		return result;
	}

	// Token: 0x06002370 RID: 9072 RVA: 0x00087290 File Offset: 0x00085490
	private static void OnPreUpdatePreCallbacks()
	{
		global::NetCull.TimeMeasureStart();
	}

	// Token: 0x06002371 RID: 9073 RVA: 0x00087298 File Offset: 0x00085498
	private static void OnPreUpdatePostCallbacks()
	{
	}

	// Token: 0x06002372 RID: 9074 RVA: 0x0008729C File Offset: 0x0008549C
	private static void OnPostUpdatePreCallbacks()
	{
	}

	// Token: 0x06002373 RID: 9075 RVA: 0x000872A0 File Offset: 0x000854A0
	private static void OnPostUpdatePostCallbacks()
	{
		global::NetCull.TimeMeasureStop();
	}

	// Token: 0x17000810 RID: 2064
	// (get) Token: 0x06002374 RID: 9076 RVA: 0x000872A8 File Offset: 0x000854A8
	// (set) Token: 0x06002375 RID: 9077 RVA: 0x000872B0 File Offset: 0x000854B0
	private static bool cull_process_alt
	{
		get
		{
			return global::NetCull.CullProcessor.cull_process_alt;
		}
		set
		{
			global::NetCull.CullProcessor.cull_process_alt = value;
		}
	}

	// Token: 0x0400114E RID: 4430
	internal const string kInvalidOverloadObsoleteMessage = "Using a instantiate function without providing at least one argument is illegal";

	// Token: 0x0400114F RID: 4431
	public const bool canDestroy = true;

	// Token: 0x04001150 RID: 4432
	public const bool canRemoveRPCs = true;

	// Token: 0x04001151 RID: 4433
	private const bool ensureCanDestroy = true;

	// Token: 0x04001152 RID: 4434
	private const bool ensureCanRemoveRPCs = true;

	// Token: 0x04001153 RID: 4435
	public const bool kServer = true;

	// Token: 0x04001154 RID: 4436
	public const bool kClient = false;

	// Token: 0x04001155 RID: 4437
	public static ulong allottedTransitTimeInMillis = 0x320UL;

	// Token: 0x04001156 RID: 4438
	internal static global::NetCull.TimeRecords Time;

	// Token: 0x04001157 RID: 4439
	private static bool allow_net_cull = true;

	// Token: 0x04001158 RID: 4440
	private static readonly object[] noArgs = new object[0];

	// Token: 0x04001159 RID: 4441
	private static global::NetCull.InstantiateArgs current_instantiating;

	// Token: 0x0400115A RID: 4442
	private static int current_instantiating_count;

	// Token: 0x0400115B RID: 4443
	private static int deniedInstantiateCount;

	// Token: 0x0400115C RID: 4444
	public static int MaxCullUpdatesPerFrame_Server = -1;

	// Token: 0x0400115D RID: 4445
	public static int MaxCullUpdatesPerFrame_Client = -1;

	// Token: 0x020003EE RID: 1006
	public static class Callbacks
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06002376 RID: 9078 RVA: 0x000872B8 File Offset: 0x000854B8
		// (remove) Token: 0x06002377 RID: 9079 RVA: 0x000872C8 File Offset: 0x000854C8
		public static event global::NetCull.UpdateFunctor beforeEveryUpdate
		{
			add
			{
				global::NetCull.Callbacks.PRE.DELEGATE.Add(value, false);
			}
			remove
			{
				if (global::NetCull.Callbacks.MADE_PRE)
				{
					global::NetCull.Callbacks.PRE.DELEGATE.Remove(value);
				}
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06002378 RID: 9080 RVA: 0x000872E0 File Offset: 0x000854E0
		// (remove) Token: 0x06002379 RID: 9081 RVA: 0x000872F0 File Offset: 0x000854F0
		public static event global::NetCull.UpdateFunctor beforeNextUpdate
		{
			add
			{
				global::NetCull.Callbacks.PRE.DELEGATE.Add(value, true);
			}
			remove
			{
				if (global::NetCull.Callbacks.MADE_PRE)
				{
					global::NetCull.Callbacks.PRE.DELEGATE.Remove(value);
				}
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600237A RID: 9082 RVA: 0x00087308 File Offset: 0x00085508
		// (remove) Token: 0x0600237B RID: 9083 RVA: 0x00087318 File Offset: 0x00085518
		public static event global::NetCull.UpdateFunctor afterEveryUpdate
		{
			add
			{
				global::NetCull.Callbacks.POST.DELEGATE.Add(value, false);
			}
			remove
			{
				if (global::NetCull.Callbacks.MADE_POST)
				{
					global::NetCull.Callbacks.POST.DELEGATE.Remove(value);
				}
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600237C RID: 9084 RVA: 0x00087330 File Offset: 0x00085530
		// (remove) Token: 0x0600237D RID: 9085 RVA: 0x00087340 File Offset: 0x00085540
		public static event global::NetCull.UpdateFunctor afterNextUpdate
		{
			add
			{
				global::NetCull.Callbacks.POST.DELEGATE.Add(value, true);
			}
			remove
			{
				if (global::NetCull.Callbacks.MADE_POST)
				{
					global::NetCull.Callbacks.POST.DELEGATE.Remove(value);
				}
			}
		}

		// Token: 0x0600237E RID: 9086 RVA: 0x00087358 File Offset: 0x00085558
		internal static void FirePreUpdate(global::NetPreUpdate preUpdate)
		{
			if (preUpdate != global::NetCull.Callbacks.netPreUpdate || !global::NetCull.Callbacks.Updating())
			{
				return;
			}
			global::NetCull.OnPreUpdatePreCallbacks();
			if (global::NetCull.Callbacks.MADE_PRE)
			{
				try
				{
					global::NetCull.Callbacks.PRE.DELEGATE.Invoke();
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex, preUpdate);
				}
			}
			global::NetCull.OnPreUpdatePostCallbacks();
		}

		// Token: 0x0600237F RID: 9087 RVA: 0x000873CC File Offset: 0x000855CC
		internal static void FirePostUpdate(global::NetPostUpdate postUpdate)
		{
			if (postUpdate != global::NetCull.Callbacks.netPostUpdate || !global::NetCull.Callbacks.Updating())
			{
				return;
			}
			global::NetCull.OnPostUpdatePreCallbacks();
			if (global::NetCull.Callbacks.MADE_POST)
			{
				try
				{
					global::NetCull.Callbacks.POST.DELEGATE.Invoke();
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex, postUpdate);
				}
			}
			global::NetCull.OnPostUpdatePostCallbacks();
		}

		// Token: 0x06002380 RID: 9088 RVA: 0x00087440 File Offset: 0x00085640
		private static bool Updating()
		{
			if (!global::NetCull.Callbacks.internalHelper)
			{
				global::UnityEngine.GameObject gameObject = global::UnityEngine.GameObject.Find("uLinkInternalHelper");
				if (!gameObject)
				{
					return false;
				}
				global::NetCull.Callbacks.internalHelper = gameObject.GetComponent<global::uLink.InternalHelper>();
				if (!global::NetCull.Callbacks.internalHelper)
				{
					return false;
				}
			}
			return global::NetCull.Callbacks.internalHelper.enabled;
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x0008749C File Offset: 0x0008569C
		private static void Replace<T>(ref T current, T replacement) where T : global::UnityEngine.MonoBehaviour
		{
			if (current == replacement)
			{
				return;
			}
			if (current)
			{
				global::UnityEngine.Debug.LogWarning(((!replacement) ? "Destroying " : "Replacing ") + typeof(T), current.gameObject);
				T t = current;
				global::NetCull.Callbacks.Resign<T>(ref current, current);
				if (t)
				{
					global::UnityEngine.Object.Destroy(t);
				}
				if (replacement)
				{
					global::UnityEngine.Debug.LogWarning("With " + typeof(T), replacement);
				}
			}
			current = replacement;
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x00087580 File Offset: 0x00085780
		private static void Resign<T>(ref T current, T resigning) where T : global::UnityEngine.MonoBehaviour
		{
			if (current == resigning)
			{
				current = (T)((object)null);
			}
		}

		// Token: 0x06002383 RID: 9091 RVA: 0x000875AC File Offset: 0x000857AC
		internal static void BindUpdater(global::NetPreUpdate netUpdate)
		{
			global::NetCull.Callbacks.Replace<global::NetPreUpdate>(ref global::NetCull.Callbacks.netPreUpdate, netUpdate);
		}

		// Token: 0x06002384 RID: 9092 RVA: 0x000875BC File Offset: 0x000857BC
		internal static void BindUpdater(global::NetPostUpdate netUpdate)
		{
			global::NetCull.Callbacks.Replace<global::NetPostUpdate>(ref global::NetCull.Callbacks.netPostUpdate, netUpdate);
		}

		// Token: 0x06002385 RID: 9093 RVA: 0x000875CC File Offset: 0x000857CC
		internal static void ResignUpdater(global::NetPreUpdate netUpdate)
		{
			global::NetCull.Callbacks.Resign<global::NetPreUpdate>(ref global::NetCull.Callbacks.netPreUpdate, netUpdate);
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x000875DC File Offset: 0x000857DC
		internal static void ResignUpdater(global::NetPostUpdate netUpdate)
		{
			global::NetCull.Callbacks.Resign<global::NetPostUpdate>(ref global::NetCull.Callbacks.netPostUpdate, netUpdate);
		}

		// Token: 0x0400115E RID: 4446
		private static bool MADE_PRE;

		// Token: 0x0400115F RID: 4447
		private static global::NetPreUpdate netPreUpdate;

		// Token: 0x04001160 RID: 4448
		private static bool MADE_POST;

		// Token: 0x04001161 RID: 4449
		private static global::NetPostUpdate netPostUpdate;

		// Token: 0x04001162 RID: 4450
		private static global::uLink.InternalHelper internalHelper;

		// Token: 0x020003EF RID: 1007
		private class UpdateDelegate
		{
			// Token: 0x06002387 RID: 9095 RVA: 0x000875EC File Offset: 0x000857EC
			public UpdateDelegate()
			{
			}

			// Token: 0x06002388 RID: 9096 RVA: 0x00087644 File Offset: 0x00085844
			public void Invoke()
			{
				if (this.guarded || (this.count = this.list.Count) == 0)
				{
					return;
				}
				this.iterPosition = -1;
				try
				{
					this.guarded = true;
					this.iterPosition = -1;
					this.invokation.AddRange(this.list);
					global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor> hashSet = (!this.onceSwap) ? this.once1 : this.once2;
					global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor> hashSet2 = (!this.onceSwap) ? this.once2 : this.once1;
					hashSet2.Clear();
					hashSet2.UnionWith(hashSet);
					this.onceSwap = !this.onceSwap;
					foreach (global::NetCull.UpdateFunctor item in hashSet)
					{
						if (this.hashSet.Remove(item))
						{
							this.list.Remove(item);
						}
					}
					hashSet.Clear();
					while (++this.iterPosition < this.count)
					{
						if (!this.skip.Remove(this.iterPosition))
						{
							global::NetCull.UpdateFunctor updateFunctor = this.invokation[this.iterPosition];
							try
							{
								updateFunctor();
							}
							catch (global::System.Exception ex)
							{
								global::UnityEngine.Object @object;
								try
								{
									@object = (updateFunctor.Target as global::UnityEngine.Object);
								}
								catch
								{
									@object = null;
								}
								global::UnityEngine.Debug.LogException(ex, @object);
							}
						}
					}
				}
				finally
				{
					try
					{
						this.invokation.Clear();
					}
					finally
					{
						this.guarded = false;
					}
				}
			}

			// Token: 0x06002389 RID: 9097 RVA: 0x0008786C File Offset: 0x00085A6C
			private bool HandleRemoval(global::NetCull.UpdateFunctor functor)
			{
				if (this.guarded)
				{
					int num = this.invokation.IndexOf(functor);
					if (num != -1)
					{
						this.invokation[num] = null;
						if (this.iterPosition < num)
						{
							this.skip.Add(num);
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600238A RID: 9098 RVA: 0x000878C4 File Offset: 0x00085AC4
			public bool Remove(global::NetCull.UpdateFunctor functor)
			{
				if (this.hashSet.Remove(functor))
				{
					this.list.Remove(functor);
					((!this.onceSwap) ? this.once1 : this.once2).Remove(functor);
					this.HandleRemoval(functor);
					return true;
				}
				return ((!this.onceSwap) ? this.once1 : this.once2).Remove(functor) && this.HandleRemoval(functor);
			}

			// Token: 0x0600238B RID: 9099 RVA: 0x0008794C File Offset: 0x00085B4C
			public bool Add(global::NetCull.UpdateFunctor functor, bool oneTimeOnly)
			{
				if (this.hashSet.Add(functor))
				{
					this.list.Add(functor);
					if (oneTimeOnly)
					{
						((!this.onceSwap) ? this.once1 : this.once2).Add(functor);
					}
					return true;
				}
				return false;
			}

			// Token: 0x04001163 RID: 4451
			private readonly global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor> hashSet = new global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor>();

			// Token: 0x04001164 RID: 4452
			private readonly global::System.Collections.Generic.List<global::NetCull.UpdateFunctor> list = new global::System.Collections.Generic.List<global::NetCull.UpdateFunctor>();

			// Token: 0x04001165 RID: 4453
			private readonly global::System.Collections.Generic.List<global::NetCull.UpdateFunctor> invokation = new global::System.Collections.Generic.List<global::NetCull.UpdateFunctor>();

			// Token: 0x04001166 RID: 4454
			private readonly global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor> once1 = new global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor>();

			// Token: 0x04001167 RID: 4455
			private readonly global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor> once2 = new global::System.Collections.Generic.HashSet<global::NetCull.UpdateFunctor>();

			// Token: 0x04001168 RID: 4456
			private readonly global::System.Collections.Generic.HashSet<int> skip = new global::System.Collections.Generic.HashSet<int>();

			// Token: 0x04001169 RID: 4457
			private int count;

			// Token: 0x0400116A RID: 4458
			private int iterPosition;

			// Token: 0x0400116B RID: 4459
			private bool guarded;

			// Token: 0x0400116C RID: 4460
			private bool onceSwap;
		}

		// Token: 0x020003F0 RID: 1008
		private static class PRE
		{
			// Token: 0x0600238C RID: 9100 RVA: 0x000879A4 File Offset: 0x00085BA4
			static PRE()
			{
				global::NetCull.Callbacks.MADE_PRE = true;
			}

			// Token: 0x0400116D RID: 4461
			public static readonly global::NetCull.Callbacks.UpdateDelegate DELEGATE = new global::NetCull.Callbacks.UpdateDelegate();
		}

		// Token: 0x020003F1 RID: 1009
		private static class POST
		{
			// Token: 0x0600238D RID: 9101 RVA: 0x000879B8 File Offset: 0x00085BB8
			static POST()
			{
				global::NetCull.Callbacks.MADE_POST = true;
			}

			// Token: 0x0400116E RID: 4462
			public static readonly global::NetCull.Callbacks.UpdateDelegate DELEGATE = new global::NetCull.Callbacks.UpdateDelegate();
		}
	}

	// Token: 0x020003F2 RID: 1010
	internal struct TimeRecord
	{
		// Token: 0x0600238E RID: 9102 RVA: 0x000879CC File Offset: 0x00085BCC
		public TimeRecord(ulong Value)
		{
			this.HasValue = true;
			this.Value = Value;
		}

		// Token: 0x0400116F RID: 4463
		public readonly bool HasValue;

		// Token: 0x04001170 RID: 4464
		public readonly ulong Value;
	}

	// Token: 0x020003F3 RID: 1011
	internal struct TimeRecords
	{
		// Token: 0x04001171 RID: 4465
		public global::NetCull.TimeRecord PreUpdateTimestamp;

		// Token: 0x04001172 RID: 4466
		public global::NetCull.TimeRecord PostUpdateTimestamp;

		// Token: 0x04001173 RID: 4467
		public global::NetCull.TimeRecord FrameTimestamp;

		// Token: 0x04001174 RID: 4468
		public global::NetCull.TimeRecord FrameDuration;

		// Token: 0x04001175 RID: 4469
		public global::NetCull.TimeRecord OverheadDuration;

		// Token: 0x04001176 RID: 4470
		public bool Updating;
	}

	// Token: 0x020003F4 RID: 1012
	[global::System.Serializable]
	public abstract class RPCVerificationException : global::System.Exception
	{
		// Token: 0x0600238F RID: 9103 RVA: 0x000879DC File Offset: 0x00085BDC
		internal RPCVerificationException()
		{
		}

		// Token: 0x06002390 RID: 9104 RVA: 0x000879E4 File Offset: 0x00085BE4
		internal RPCVerificationException(string message) : base(message)
		{
		}

		// Token: 0x06002391 RID: 9105 RVA: 0x000879F0 File Offset: 0x00085BF0
		internal RPCVerificationException(string message, global::System.Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06002392 RID: 9106 RVA: 0x000879FC File Offset: 0x00085BFC
		internal RPCVerificationException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}

	// Token: 0x020003F5 RID: 1013
	[global::System.Serializable]
	public class RPCVerificationDropException : global::NetCull.RPCVerificationException
	{
		// Token: 0x06002393 RID: 9107 RVA: 0x00087A08 File Offset: 0x00085C08
		internal RPCVerificationDropException()
		{
		}

		// Token: 0x06002394 RID: 9108 RVA: 0x00087A10 File Offset: 0x00085C10
		internal RPCVerificationDropException(string message) : base(message)
		{
		}

		// Token: 0x06002395 RID: 9109 RVA: 0x00087A1C File Offset: 0x00085C1C
		internal RPCVerificationDropException(string message, global::System.Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06002396 RID: 9110 RVA: 0x00087A28 File Offset: 0x00085C28
		internal RPCVerificationDropException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}

	// Token: 0x020003F6 RID: 1014
	[global::System.Serializable]
	public class RPCVerificationLateException : global::NetCull.RPCVerificationDropException
	{
		// Token: 0x06002397 RID: 9111 RVA: 0x00087A34 File Offset: 0x00085C34
		internal RPCVerificationLateException()
		{
		}

		// Token: 0x06002398 RID: 9112 RVA: 0x00087A3C File Offset: 0x00085C3C
		internal RPCVerificationLateException(string message) : base(message)
		{
		}

		// Token: 0x06002399 RID: 9113 RVA: 0x00087A48 File Offset: 0x00085C48
		internal RPCVerificationLateException(string message, global::System.Exception inner) : base(message, inner)
		{
		}

		// Token: 0x0600239A RID: 9114 RVA: 0x00087A54 File Offset: 0x00085C54
		internal RPCVerificationLateException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}

	// Token: 0x020003F7 RID: 1015
	[global::System.Serializable]
	public class RPCVerificationSenderException : global::NetCull.RPCVerificationException
	{
		// Token: 0x0600239B RID: 9115 RVA: 0x00087A60 File Offset: 0x00085C60
		internal RPCVerificationSenderException(global::uLink.NetworkPlayer Sender)
		{
			this.Sender = Sender;
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x00087A70 File Offset: 0x00085C70
		internal RPCVerificationSenderException(global::uLink.NetworkPlayer Sender, string message) : base(message)
		{
			this.Sender = Sender;
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x00087A80 File Offset: 0x00085C80
		internal RPCVerificationSenderException(global::uLink.NetworkPlayer Sender, string message, global::System.Exception inner) : base(message, inner)
		{
			this.Sender = Sender;
		}

		// Token: 0x0600239E RID: 9118 RVA: 0x00087A94 File Offset: 0x00085C94
		internal RPCVerificationSenderException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x04001177 RID: 4471
		public readonly global::uLink.NetworkPlayer Sender;
	}

	// Token: 0x020003F8 RID: 1016
	[global::System.Serializable]
	public class RPCVerificationWrongSenderException : global::NetCull.RPCVerificationSenderException
	{
		// Token: 0x0600239F RID: 9119 RVA: 0x00087AA0 File Offset: 0x00085CA0
		internal RPCVerificationWrongSenderException(global::uLink.NetworkPlayer Sender, global::uLink.NetworkPlayer Owner) : base(Sender)
		{
			this.Owner = Owner;
		}

		// Token: 0x060023A0 RID: 9120 RVA: 0x00087AB0 File Offset: 0x00085CB0
		internal RPCVerificationWrongSenderException(global::uLink.NetworkPlayer Sender, global::uLink.NetworkPlayer Owner, string message) : base(Sender, message)
		{
			this.Owner = Owner;
		}

		// Token: 0x060023A1 RID: 9121 RVA: 0x00087AC4 File Offset: 0x00085CC4
		internal RPCVerificationWrongSenderException(global::uLink.NetworkPlayer Sender, global::uLink.NetworkPlayer Owner, string message, global::System.Exception inner) : base(Sender, message, inner)
		{
			this.Owner = Owner;
		}

		// Token: 0x060023A2 RID: 9122 RVA: 0x00087AD8 File Offset: 0x00085CD8
		internal RPCVerificationWrongSenderException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x04001178 RID: 4472
		public readonly global::uLink.NetworkPlayer Owner;
	}

	// Token: 0x020003F9 RID: 1017
	public struct InstantiateArgs
	{
		// Token: 0x060023A3 RID: 9123 RVA: 0x00087AE4 File Offset: 0x00085CE4
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int? group, object[] args)
		{
			this.call = call;
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabName = prefab;
			this.prefabGameObject = null;
			this.prefabComponent = null;
			this.prefabType = 1;
			this.position = position;
			this.rotation = rotation;
			this.group = group;
			this.args = args;
			this.piggy = null;
			this.playerRoot = false;
		}

		// Token: 0x060023A4 RID: 9124 RVA: 0x00087B58 File Offset: 0x00085D58
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int? group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = null;
			this.prefabGameObject = prefab;
			this.prefabName = null;
			this.prefabType = 2;
			this.position = position;
			this.rotation = rotation;
			this.group = group;
			this.args = args;
			this.piggy = null;
			this.playerRoot = false;
		}

		// Token: 0x060023A5 RID: 9125 RVA: 0x00087BC8 File Offset: 0x00085DC8
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, global::UnityEngine.Component prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int? group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = prefab;
			this.prefabGameObject = null;
			this.prefabName = null;
			this.prefabType = 3;
			this.position = position;
			this.rotation = rotation;
			this.group = group;
			this.args = args;
			this.piggy = null;
			this.playerRoot = false;
		}

		// Token: 0x060023A6 RID: 9126 RVA: 0x00087C38 File Offset: 0x00085E38
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::NetworkCullInfo group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabName = prefab;
			this.prefabGameObject = null;
			this.prefabComponent = null;
			this.prefabType = 1;
			this.position = position;
			this.rotation = rotation;
			this.group = null;
			this.args = args;
			this.piggy = group;
			this.playerRoot = false;
		}

		// Token: 0x060023A7 RID: 9127 RVA: 0x00087CB0 File Offset: 0x00085EB0
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::NetworkCullInfo group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = null;
			this.prefabGameObject = prefab;
			this.prefabName = null;
			this.prefabType = 2;
			this.position = position;
			this.rotation = rotation;
			this.group = null;
			this.args = args;
			this.piggy = group;
			this.playerRoot = false;
		}

		// Token: 0x060023A8 RID: 9128 RVA: 0x00087D28 File Offset: 0x00085F28
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, global::UnityEngine.Component prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::NetworkCullInfo group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = prefab;
			this.prefabGameObject = null;
			this.prefabName = null;
			this.prefabType = 3;
			this.position = position;
			this.rotation = rotation;
			this.group = null;
			this.args = args;
			this.piggy = group;
			this.playerRoot = false;
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x060023A9 RID: 9129 RVA: 0x00087DA0 File Offset: 0x00085FA0
		public object prefab
		{
			get
			{
				switch (this.prefabType)
				{
				case 0:
					return null;
				case 1:
					return this.prefabName;
				case 2:
					return this.prefabGameObject;
				case 3:
					return this.prefabComponent;
				default:
					throw new global::System.InvalidOperationException();
				}
			}
		}

		// Token: 0x060023AA RID: 9130 RVA: 0x00087DEC File Offset: 0x00085FEC
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x00087E00 File Offset: 0x00086000
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060023AC RID: 9132 RVA: 0x00087E14 File Offset: 0x00086014
		public override string ToString()
		{
			return string.Format("[InstantiateArgs: prefab={0}]", this.prefab);
		}

		// Token: 0x04001179 RID: 4473
		public global::uLink.NetworkPlayer? owner;

		// Token: 0x0400117A RID: 4474
		public global::uLink.NetworkViewID? view;

		// Token: 0x0400117B RID: 4475
		public int? group;

		// Token: 0x0400117C RID: 4476
		public global::UnityEngine.Vector3 position;

		// Token: 0x0400117D RID: 4477
		public global::UnityEngine.Quaternion rotation;

		// Token: 0x0400117E RID: 4478
		public string prefabName;

		// Token: 0x0400117F RID: 4479
		public global::UnityEngine.GameObject prefabGameObject;

		// Token: 0x04001180 RID: 4480
		public global::UnityEngine.Component prefabComponent;

		// Token: 0x04001181 RID: 4481
		public int prefabType;

		// Token: 0x04001182 RID: 4482
		public object[] args;

		// Token: 0x04001183 RID: 4483
		public global::NetworkCullInfo piggy;

		// Token: 0x04001184 RID: 4484
		public global::NetCullInstantiationCall call;

		// Token: 0x04001185 RID: 4485
		public bool playerRoot;
	}

	// Token: 0x020003FA RID: 1018
	public struct InstantiateArgs<T> where T : global::UnityEngine.Component
	{
		// Token: 0x060023AD RID: 9133 RVA: 0x00087E28 File Offset: 0x00086028
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int? group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabName = prefab;
			this.prefabGameObject = null;
			this.prefabComponent = (T)((object)null);
			this.prefabType = 1;
			this.position = position;
			this.rotation = rotation;
			this.group = group;
			this.args = args;
			this.piggy = null;
			this.playerRoot = false;
		}

		// Token: 0x060023AE RID: 9134 RVA: 0x00087E9C File Offset: 0x0008609C
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int? group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = (T)((object)null);
			this.prefabGameObject = prefab;
			this.prefabName = null;
			this.prefabType = 2;
			this.position = position;
			this.rotation = rotation;
			this.group = group;
			this.args = args;
			this.piggy = null;
			this.playerRoot = false;
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x00087F10 File Offset: 0x00086110
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int? group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = prefab;
			this.prefabGameObject = null;
			this.prefabName = null;
			this.prefabType = 3;
			this.position = position;
			this.rotation = rotation;
			this.group = group;
			this.args = args;
			this.piggy = null;
			this.playerRoot = false;
		}

		// Token: 0x060023B0 RID: 9136 RVA: 0x00087F80 File Offset: 0x00086180
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, string prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::NetworkCullInfo group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabName = prefab;
			this.prefabGameObject = null;
			this.prefabComponent = (T)((object)null);
			this.prefabType = 1;
			this.position = position;
			this.rotation = rotation;
			this.group = null;
			this.args = args;
			this.piggy = group;
			this.playerRoot = false;
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x00087FFC File Offset: 0x000861FC
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::NetworkCullInfo group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = (T)((object)null);
			this.prefabGameObject = prefab;
			this.prefabName = null;
			this.prefabType = 2;
			this.position = position;
			this.rotation = rotation;
			this.group = null;
			this.args = args;
			this.piggy = group;
			this.playerRoot = false;
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x00088078 File Offset: 0x00086278
		public InstantiateArgs(global::NetCullInstantiationCall call, global::uLink.NetworkViewID? view, global::uLink.NetworkPlayer? owner, T prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::NetworkCullInfo group, object[] args)
		{
			this.call = call;
			this.view = view;
			this.owner = owner;
			this.prefabComponent = prefab;
			this.prefabGameObject = null;
			this.prefabName = null;
			this.prefabType = 3;
			this.position = position;
			this.rotation = rotation;
			this.group = null;
			this.args = args;
			this.piggy = group;
			this.playerRoot = false;
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x060023B3 RID: 9139 RVA: 0x000880F0 File Offset: 0x000862F0
		public object prefab
		{
			get
			{
				switch (this.prefabType)
				{
				case 0:
					return null;
				case 1:
					return this.prefabName;
				case 2:
					return this.prefabGameObject;
				case 3:
					return this.prefabComponent;
				default:
					throw new global::System.InvalidOperationException();
				}
			}
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x00088140 File Offset: 0x00086340
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060023B5 RID: 9141 RVA: 0x00088154 File Offset: 0x00086354
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x00088168 File Offset: 0x00086368
		public override string ToString()
		{
			return string.Format("[InstantiateArgs: prefab={0}]", this.prefab);
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x0008817C File Offset: 0x0008637C
		public static explicit operator global::NetCull.InstantiateArgs(global::NetCull.InstantiateArgs<T> self)
		{
			return new global::NetCull.InstantiateArgs
			{
				owner = self.owner,
				view = self.view,
				group = self.group,
				position = self.position,
				rotation = self.rotation,
				prefabName = self.prefabName,
				prefabGameObject = self.prefabGameObject,
				prefabComponent = self.prefabComponent,
				prefabType = self.prefabType,
				piggy = self.piggy,
				args = self.args,
				playerRoot = self.playerRoot
			};
		}

		// Token: 0x04001186 RID: 4486
		public global::uLink.NetworkPlayer? owner;

		// Token: 0x04001187 RID: 4487
		public global::uLink.NetworkViewID? view;

		// Token: 0x04001188 RID: 4488
		public int? group;

		// Token: 0x04001189 RID: 4489
		public global::UnityEngine.Vector3 position;

		// Token: 0x0400118A RID: 4490
		public global::UnityEngine.Quaternion rotation;

		// Token: 0x0400118B RID: 4491
		public string prefabName;

		// Token: 0x0400118C RID: 4492
		public global::UnityEngine.GameObject prefabGameObject;

		// Token: 0x0400118D RID: 4493
		public T prefabComponent;

		// Token: 0x0400118E RID: 4494
		public int prefabType;

		// Token: 0x0400118F RID: 4495
		public global::NetworkCullInfo piggy;

		// Token: 0x04001190 RID: 4496
		public object[] args;

		// Token: 0x04001191 RID: 4497
		public global::NetCullInstantiationCall call;

		// Token: 0x04001192 RID: 4498
		public bool playerRoot;
	}

	// Token: 0x020003FB RID: 1019
	internal enum GroupMode
	{
		// Token: 0x04001194 RID: 4500
		Static,
		// Token: 0x04001195 RID: 4501
		Dynamic,
		// Token: 0x04001196 RID: 4502
		PlayerRoot,
		// Token: 0x04001197 RID: 4503
		PlayerRootOrDynamic = 0x42,
		// Token: 0x04001198 RID: 4504
		PiggyBack,
		// Token: 0x04001199 RID: 4505
		PiggyBackOrDynamic = 0x63
	}

	// Token: 0x020003FC RID: 1020
	private static class Send
	{
		// Token: 0x060023B8 RID: 9144 RVA: 0x00088240 File Offset: 0x00086440
		static Send()
		{
		}

		// Token: 0x0400119A RID: 4506
		public static float Rate = global::uLink.Network.sendRate;

		// Token: 0x0400119B RID: 4507
		public static double Interval = 1.0 / (double)global::NetCull.sendRate;

		// Token: 0x0400119C RID: 4508
		public static float IntervalF = (float)global::NetCull.Send.Interval;
	}

	// Token: 0x020003FD RID: 1021
	private static class AutoPrefabs
	{
		// Token: 0x060023B9 RID: 9145 RVA: 0x00088278 File Offset: 0x00086478
		// Note: this type is marked as 'beforefieldinit'.
		static AutoPrefabs()
		{
		}

		// Token: 0x0400119D RID: 4509
		public static global::System.Collections.Generic.Dictionary<string, global::uLinkNetworkView> all = new global::System.Collections.Generic.Dictionary<string, global::uLinkNetworkView>();
	}

	// Token: 0x020003FE RID: 1022
	public enum PrefabSearch : sbyte
	{
		// Token: 0x0400119F RID: 4511
		Missing,
		// Token: 0x040011A0 RID: 4512
		NGC,
		// Token: 0x040011A1 RID: 4513
		NetMain,
		// Token: 0x040011A2 RID: 4514
		NetAuto
	}

	// Token: 0x020003FF RID: 1023
	internal static class CullProcessor
	{
		// Token: 0x060023BA RID: 9146 RVA: 0x00088284 File Offset: 0x00086484
		static CullProcessor()
		{
			global::NetCull.CullProcessor.server = new global::NetCull.CullProcessor.Let(0, 2, 4, 6, 1);
			global::NetCull.CullProcessor.client = new global::NetCull.CullProcessor.Let(1, 3, 5, 7, 2);
			global::NetCull.CullProcessor.cullPreUpdate = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PreUpdate);
			global::NetCull.CullProcessor.cullPostUpdate = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PostUpdate);
			global::NetCull.CullProcessor.cullPreUpdate_ClientOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PreUpdate_ClientOnly);
			global::NetCull.CullProcessor.cullPostUpdate_ClientOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PostUpdate_ClientOnly);
			global::NetCull.CullProcessor.cullPreUpdate_ServerOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PreUpdate_ServerOnly);
			global::NetCull.CullProcessor.cullPostUpdate_ServerOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PostUpdate_ServerOnly);
			global::NetCull.CullProcessor.cullPreUpdateAlt = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PreUpdateAlt);
			global::NetCull.CullProcessor.cullPostUpdateAlt = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PostUpdateAlt);
			global::NetCull.CullProcessor.cullPreUpdateAlt_ClientOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PreUpdateAlt_ClientOnly);
			global::NetCull.CullProcessor.cullPostUpdateAlt_ClientOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PostUpdateAlt_ClientOnly);
			global::NetCull.CullProcessor.cullPreUpdateAlt_ServerOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PreUpdateAlt_ServerOnly);
			global::NetCull.CullProcessor.cullPostUpdateAlt_ServerOnly = new global::NetCull.UpdateFunctor(global::NetCull.CullProcessor.CB_PostUpdateAlt_ServerOnly);
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x060023BB RID: 9147 RVA: 0x00088384 File Offset: 0x00086584
		// (set) Token: 0x060023BC RID: 9148 RVA: 0x0008838C File Offset: 0x0008658C
		internal static bool cull_process_alt
		{
			get
			{
				return global::NetCull.CullProcessor.MODE_ALT;
			}
			set
			{
				if (value != global::NetCull.CullProcessor.MODE_ALT)
				{
					global::NetCull.CullProcessor.pendingAltToggle = true;
					global::NetCull.CullProcessor.CheckCondition();
				}
			}
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x000883A4 File Offset: 0x000865A4
		internal static void NotifyQueuedSpawn()
		{
			global::NetCull.CullProcessor.theresAQueuedSpawn = true;
		}

		// Token: 0x060023BE RID: 9150 RVA: 0x000883AC File Offset: 0x000865AC
		public static bool RegisterMover(global::NetworkCullInfo mover)
		{
			global::NetCull.CullProcessor.Let let = (!mover.isUser) ? global::NetCull.CullProcessor.server : global::NetCull.CullProcessor.client;
			if (let.movers.Add(mover) == 1)
			{
				if (let.movers.size == 1)
				{
					global::NetCull.CullProcessor.CheckCondition();
				}
				return true;
			}
			return false;
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x00088400 File Offset: 0x00086600
		private static void CB_PreUpdate()
		{
			global::NetCull.CullProcessor.CB_PostUpdateAlt();
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x00088408 File Offset: 0x00086608
		private static void CB_PostUpdate()
		{
			global::NetCull.CullProcessor.CB_PreUpdateAlt();
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x00088410 File Offset: 0x00086610
		private static void CB_PreUpdateAlt()
		{
			bool flag = global::NetCull.CullProcessor.server_group_changes_pending = global::NetCull.CullProcessor.server.Process(true, global::NetCull.MaxCullUpdatesPerFrame_Server);
			if (global::NetCull.CullProcessor.player_group_changes_pending)
			{
				if (!global::CullGrid.pendingPlayerGroupChanges)
				{
					global::NetCull.CullProcessor.player_group_changes_pending = false;
				}
				else if (++global::NetCull.CullProcessor.half_frames_since_player_group_changes_pending == 3)
				{
					global::CullGrid.FlushPlayerGroupChanges();
				}
				flag = false;
			}
			if (flag)
			{
				if (global::NetCull.CullProcessor.server.Apply())
				{
					global::NetCull.CullProcessor.frames_since_server_group_apply = 0U;
					global::NetCull.CullProcessor.server_group_changes_pending = false;
				}
			}
			else
			{
				if (global::NetCull.CullProcessor.frames_since_client_group_apply > 1U && global::NetCull.CullProcessor.frames_since_server_group_apply > 1U && global::CullGrid.pendingPlayerGroupChanges)
				{
					global::CullGrid.FlushPlayerGroupChanges();
					global::NetCull.CullProcessor.half_frames_since_player_group_changes_pending = 3;
					global::NetCull.CullProcessor.player_group_changes_pending = true;
				}
				if (global::NetCull.CullProcessor.frames_since_server_group_apply < 0xFFFFFFFFU)
				{
					global::NetCull.CullProcessor.frames_since_server_group_apply += 1U;
				}
			}
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x000884E0 File Offset: 0x000866E0
		private static void CB_PostUpdateAlt()
		{
			bool flag = (global::NetCull.CullProcessor.client_group_changes_pending = global::NetCull.CullProcessor.client.Process(true, global::NetCull.MaxCullUpdatesPerFrame_Client)) && !global::NetCull.CullProcessor.player_group_changes_pending;
			if (flag)
			{
				if (global::NetCull.CullProcessor.client.Apply())
				{
					global::NetCull.CullProcessor.frames_since_client_group_apply = 0U;
					global::NetCull.CullProcessor.client_group_changes_pending = false;
				}
				if (global::CullGrid.pendingPlayerGroupChanges)
				{
					global::NetCull.CullProcessor.player_group_changes_pending = true;
					global::NetCull.CullProcessor.half_frames_since_player_group_changes_pending = 0;
				}
			}
			else if (global::NetCull.CullProcessor.player_group_changes_pending)
			{
				if (++global::NetCull.CullProcessor.half_frames_since_player_group_changes_pending == 4)
				{
					global::NetCull.CullProcessor.player_group_changes_pending = false;
				}
			}
			else if (global::NetCull.CullProcessor.frames_since_server_group_apply > 1U && global::NetCull.CullProcessor.frames_since_client_group_apply > 1U && global::CullGrid.pendingPlayerGroupChanges)
			{
				global::NetCull.CullProcessor.player_group_changes_pending = true;
				global::NetCull.CullProcessor.half_frames_since_player_group_changes_pending = 2;
			}
			if (global::NetCull.CullProcessor.frames_since_client_group_apply < 0xFFFFFFFFU)
			{
				global::NetCull.CullProcessor.frames_since_client_group_apply += 1U;
			}
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x000885BC File Offset: 0x000867BC
		private static void CB_PreUpdate_ClientOnly()
		{
			global::NetCull.CullProcessor.CB_PreUpdate();
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x000885C4 File Offset: 0x000867C4
		private static void CB_PostUpdate_ClientOnly()
		{
			global::NetCull.CullProcessor.CB_PostUpdate();
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x000885CC File Offset: 0x000867CC
		private static void CB_PreUpdate_ServerOnly()
		{
			global::NetCull.CullProcessor.CB_PreUpdate();
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x000885D4 File Offset: 0x000867D4
		private static void CB_PostUpdate_ServerOnly()
		{
			global::NetCull.CullProcessor.CB_PostUpdate();
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x000885DC File Offset: 0x000867DC
		private static void CB_PreUpdateAlt_ClientOnly()
		{
			global::NetCull.CullProcessor.CB_PreUpdateAlt();
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x000885E4 File Offset: 0x000867E4
		private static void CB_PostUpdateAlt_ClientOnly()
		{
			global::NetCull.CullProcessor.CB_PostUpdateAlt();
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x000885EC File Offset: 0x000867EC
		private static void CB_PreUpdateAlt_ServerOnly()
		{
			global::NetCull.CullProcessor.CB_PreUpdateAlt();
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x000885F4 File Offset: 0x000867F4
		private static void CB_PostUpdateAlt_ServerOnly()
		{
			global::NetCull.CullProcessor.CB_PostUpdateAlt();
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x000885FC File Offset: 0x000867FC
		internal static void CheckCondition()
		{
			int num;
			if (global::NetCull.CullProcessor.server.movers.size > 0)
			{
				if (global::NetCull.CullProcessor.client.movers.size > 0)
				{
					num = 3;
				}
				else
				{
					num = 1;
				}
			}
			else if (global::NetCull.CullProcessor.client.movers.size > 0)
			{
				num = 2;
			}
			else
			{
				num = 0;
			}
			if (num != global::NetCull.CullProcessor.RUNTIME || global::NetCull.CullProcessor.pendingAltToggle)
			{
				switch (global::NetCull.CullProcessor.RUNTIME)
				{
				case 1:
					global::NetCull.Callbacks.beforeEveryUpdate -= ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPreUpdate_ServerOnly : global::NetCull.CullProcessor.cullPreUpdateAlt_ServerOnly);
					global::NetCull.Callbacks.afterEveryUpdate -= ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPostUpdate_ServerOnly : global::NetCull.CullProcessor.cullPostUpdateAlt_ServerOnly);
					break;
				case 2:
					global::NetCull.Callbacks.beforeEveryUpdate -= ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPreUpdate_ClientOnly : global::NetCull.CullProcessor.cullPreUpdateAlt_ClientOnly);
					global::NetCull.Callbacks.afterEveryUpdate -= ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPostUpdate_ClientOnly : global::NetCull.CullProcessor.cullPostUpdateAlt_ClientOnly);
					break;
				case 3:
					global::NetCull.Callbacks.beforeEveryUpdate -= ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPreUpdate : global::NetCull.CullProcessor.cullPreUpdateAlt);
					global::NetCull.Callbacks.afterEveryUpdate -= ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPostUpdate : global::NetCull.CullProcessor.cullPostUpdateAlt);
					break;
				}
				if (global::NetCull.CullProcessor.pendingAltToggle)
				{
					global::NetCull.CullProcessor.MODE_ALT = !global::NetCull.CullProcessor.MODE_ALT;
					global::NetCull.CullProcessor.pendingAltToggle = false;
				}
				global::NetCull.CullProcessor.RUNTIME = num;
				switch (global::NetCull.CullProcessor.RUNTIME)
				{
				case 1:
					global::NetCull.Callbacks.beforeEveryUpdate += ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPreUpdate_ServerOnly : global::NetCull.CullProcessor.cullPreUpdateAlt_ServerOnly);
					global::NetCull.Callbacks.afterEveryUpdate += ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPostUpdate_ServerOnly : global::NetCull.CullProcessor.cullPostUpdateAlt_ServerOnly);
					break;
				case 2:
					global::NetCull.Callbacks.beforeEveryUpdate += ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPreUpdate_ClientOnly : global::NetCull.CullProcessor.cullPreUpdateAlt_ClientOnly);
					global::NetCull.Callbacks.afterEveryUpdate += ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPostUpdate_ClientOnly : global::NetCull.CullProcessor.cullPostUpdateAlt_ClientOnly);
					break;
				case 3:
					global::NetCull.Callbacks.beforeEveryUpdate += ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPreUpdate : global::NetCull.CullProcessor.cullPreUpdateAlt);
					global::NetCull.Callbacks.afterEveryUpdate += ((!global::NetCull.CullProcessor.MODE_ALT) ? global::NetCull.CullProcessor.cullPostUpdate : global::NetCull.CullProcessor.cullPostUpdateAlt);
					break;
				}
			}
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x00088868 File Offset: 0x00086A68
		internal static void ListMovers()
		{
			global::System.Text.StringBuilder stringBuilder = null;
			bool flag = false;
			if (global::NetCull.CullProcessor.server.movers.size > 0)
			{
				flag = true;
				stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.AppendFormat("{0} server movers:", global::NetCull.CullProcessor.server.movers.size);
				for (int i = 0; i < global::NetCull.CullProcessor.server.movers.size; i++)
				{
					stringBuilder.AppendFormat("{0}. {1}\r\n", i, global::NetCull.CullProcessor.server.movers.buffer[i]);
				}
			}
			if (global::NetCull.CullProcessor.client.movers.size > 0)
			{
				if (!flag)
				{
					stringBuilder = new global::System.Text.StringBuilder();
				}
				stringBuilder.AppendFormat("{0} client movers:", global::NetCull.CullProcessor.client.movers.size);
				for (int j = 0; j < global::NetCull.CullProcessor.client.movers.size; j++)
				{
					stringBuilder.AppendFormat("{0}. {1}\r\n", j, global::NetCull.CullProcessor.client.movers.buffer[j]);
				}
			}
		}

		// Token: 0x040011A3 RID: 4515
		private const int MODE_SERVER = 1;

		// Token: 0x040011A4 RID: 4516
		private const int MODE_NULL = 0;

		// Token: 0x040011A5 RID: 4517
		private const int MODE_CLIENT = 2;

		// Token: 0x040011A6 RID: 4518
		private const int MODE_DISPOSED = -1;

		// Token: 0x040011A7 RID: 4519
		private const byte INSERTED = 1;

		// Token: 0x040011A8 RID: 4520
		private const byte MOVED = 2;

		// Token: 0x040011A9 RID: 4521
		private const byte REMOVED = 4;

		// Token: 0x040011AA RID: 4522
		private const byte NO_EFFECT = 0;

		// Token: 0x040011AB RID: 4523
		private const int RUNTIME_SERVER_CLIENT = 3;

		// Token: 0x040011AC RID: 4524
		private const int RUNTIME_SERVER = 1;

		// Token: 0x040011AD RID: 4525
		private const int RUNTIME_CLIENT = 2;

		// Token: 0x040011AE RID: 4526
		private const int RUNTIME_OFF = 0;

		// Token: 0x040011AF RID: 4527
		private static int meat_iter;

		// Token: 0x040011B0 RID: 4528
		private static global::NetworkCullInfo meat;

		// Token: 0x040011B1 RID: 4529
		private static global::NetworkCullInfo meat_test_worth_cooking;

		// Token: 0x040011B2 RID: 4530
		private static bool theresAQueuedSpawn;

		// Token: 0x040011B3 RID: 4531
		private static readonly global::NetCull.CullProcessor.Let client;

		// Token: 0x040011B4 RID: 4532
		private static readonly global::NetCull.CullProcessor.Let server;

		// Token: 0x040011B5 RID: 4533
		private static readonly global::NetCull.UpdateFunctor cullPreUpdate;

		// Token: 0x040011B6 RID: 4534
		private static readonly global::NetCull.UpdateFunctor cullPreUpdate_ServerOnly;

		// Token: 0x040011B7 RID: 4535
		private static readonly global::NetCull.UpdateFunctor cullPreUpdate_ClientOnly;

		// Token: 0x040011B8 RID: 4536
		private static readonly global::NetCull.UpdateFunctor cullPreUpdateAlt;

		// Token: 0x040011B9 RID: 4537
		private static readonly global::NetCull.UpdateFunctor cullPreUpdateAlt_ServerOnly;

		// Token: 0x040011BA RID: 4538
		private static readonly global::NetCull.UpdateFunctor cullPreUpdateAlt_ClientOnly;

		// Token: 0x040011BB RID: 4539
		private static readonly global::NetCull.UpdateFunctor cullPostUpdate;

		// Token: 0x040011BC RID: 4540
		private static readonly global::NetCull.UpdateFunctor cullPostUpdate_ServerOnly;

		// Token: 0x040011BD RID: 4541
		private static readonly global::NetCull.UpdateFunctor cullPostUpdate_ClientOnly;

		// Token: 0x040011BE RID: 4542
		private static readonly global::NetCull.UpdateFunctor cullPostUpdateAlt;

		// Token: 0x040011BF RID: 4543
		private static readonly global::NetCull.UpdateFunctor cullPostUpdateAlt_ServerOnly;

		// Token: 0x040011C0 RID: 4544
		private static readonly global::NetCull.UpdateFunctor cullPostUpdateAlt_ClientOnly;

		// Token: 0x040011C1 RID: 4545
		private static bool MODE_ALT = true;

		// Token: 0x040011C2 RID: 4546
		private static bool server_group_changes_pending;

		// Token: 0x040011C3 RID: 4547
		private static bool client_group_changes_pending;

		// Token: 0x040011C4 RID: 4548
		private static bool player_group_changes_pending;

		// Token: 0x040011C5 RID: 4549
		private static int half_frames_since_player_group_changes_pending;

		// Token: 0x040011C6 RID: 4550
		private static uint frames_since_server_group_apply;

		// Token: 0x040011C7 RID: 4551
		private static uint frames_since_client_group_apply;

		// Token: 0x040011C8 RID: 4552
		private static int RUNTIME;

		// Token: 0x040011C9 RID: 4553
		private static bool pendingAltToggle;

		// Token: 0x02000400 RID: 1024
		private class Let
		{
			// Token: 0x060023CD RID: 9165 RVA: 0x00088980 File Offset: 0x00086B80
			public Let(int registry, int detect, int change, int apply, int mode)
			{
				this.movers = new global::NetworkCullInfo.List(registry);
				this.queuedToChange = new global::NetworkCullInfo.List(detect);
				this.change = new global::NetworkCullInfo.List(change);
				this.dish = new global::NetworkCullInfo.List(apply);
				this.oven = this.dish;
				this.mode = mode;
			}

			// Token: 0x060023CE RID: 9166 RVA: 0x000889D8 File Offset: 0x00086BD8
			private byte CheckMover()
			{
				global::NetworkCullInfo networkCullInfo = this.movers.buffer[this.movers.iterator];
				networkCullInfo.process_call = this.process_call;
				global::UnityEngine.Vector3 position = networkCullInfo.transform.position;
				byte result;
				if (position.x == networkCullInfo.position.x && position.z == networkCullInfo.position.z)
				{
					networkCullInfo.position.y = position.y;
					result = 0;
				}
				else
				{
					networkCullInfo.position.x = position.x;
					networkCullInfo.position.y = position.y;
					networkCullInfo.position.z = position.z;
					int num;
					if (!global::CullGrid.GroupIDContainsPoint(networkCullInfo.workingGroupID, ref position, out num))
					{
						networkCullInfo.lastWorkingGroupID = networkCullInfo.workingGroupID;
						networkCullInfo.workingGroupID = num;
						if (num == networkCullInfo.setGroupID)
						{
							result = this.queuedToChange.Remove(networkCullInfo);
						}
						else
						{
							result = this.queuedToChange.Add(networkCullInfo);
						}
					}
					else
					{
						result = 0;
					}
				}
				return result;
			}

			// Token: 0x060023CF RID: 9167 RVA: 0x00088AEC File Offset: 0x00086CEC
			private byte IterateMovers(int MaxCullUpdatesPerFrame)
			{
				byte b = 0;
				if (MaxCullUpdatesPerFrame != 0)
				{
					if (MaxCullUpdatesPerFrame >= 0 && this.movers.size > MaxCullUpdatesPerFrame)
					{
						if (this.movers.iterator >= this.movers.size)
						{
							this.movers.iterator = -1;
						}
						int num = 0;
						for (;;)
						{
							int num2 = num;
							while (++this.movers.iterator < this.movers.size)
							{
								b |= this.CheckMover();
								if (++num >= MaxCullUpdatesPerFrame)
								{
									return b;
								}
							}
							this.movers.iterator = -1;
							if (num2 == num)
							{
								return b;
							}
						}
						return b;
					}
					this.movers.iterator = -1;
					while (++this.movers.iterator < this.movers.size)
					{
						b |= this.CheckMover();
					}
				}
				return b;
			}

			// Token: 0x060023D0 RID: 9168 RVA: 0x00088BE0 File Offset: 0x00086DE0
			private byte ProcessMovers(int MaxCullUpdatesPerFrame)
			{
				if (this.movers.size == 0)
				{
					return this.pending_oper = 0;
				}
				byte b = this.IterateMovers(MaxCullUpdatesPerFrame);
				this.pending_oper |= b;
				return b;
			}

			// Token: 0x060023D1 RID: 9169 RVA: 0x00088C20 File Offset: 0x00086E20
			private static bool TestChange(global::NetworkCullInfo info)
			{
				return info.valid && info.workingGroupID != info.setGroupID && info.isConnected;
			}

			// Token: 0x060023D2 RID: 9170 RVA: 0x00088C48 File Offset: 0x00086E48
			private void AdvanceProcessFrame()
			{
				if (this.process_call == 0xFFFFFFFFFFFFFFFFUL)
				{
					this.process_call = 0UL;
				}
				else
				{
					this.process_call += 1UL;
				}
			}

			// Token: 0x060023D3 RID: 9171 RVA: 0x00088C74 File Offset: 0x00086E74
			public bool Process(bool advanceProcessFrame, int MaxCullUpdatesPerFrame)
			{
				if (advanceProcessFrame)
				{
					this.AdvanceProcessFrame();
				}
				this.ProcessMovers(MaxCullUpdatesPerFrame);
				if (this.pending_oper != 0)
				{
					if (this.queuedToChange.size == 0)
					{
						this.pending_oper = 0;
						return false;
					}
					for (int i = this.queuedToChange.size - 1; i >= 0; i--)
					{
						global::NetworkCullInfo info = this.queuedToChange.buffer[i];
						this.queuedToChange.RemoveAt(i);
						if (global::NetCull.CullProcessor.Let.TestChange(info))
						{
							this.change.Add(info);
							while (--i >= 0)
							{
								info = this.queuedToChange.buffer[i];
								this.queuedToChange.RemoveAt(i);
								if (global::NetCull.CullProcessor.Let.TestChange(info))
								{
									this.change.Add(info);
								}
								else
								{
									this.change.Remove(info);
								}
							}
						}
						else
						{
							this.change.Remove(info);
						}
					}
				}
				return this.change.size != 0;
			}

			// Token: 0x060023D4 RID: 9172 RVA: 0x00088D84 File Offset: 0x00086F84
			private void Apply_Step1_Preheat()
			{
				global::NetworkCullInfo.List.LockAutoRemove();
			}

			// Token: 0x060023D5 RID: 9173 RVA: 0x00088D8C File Offset: 0x00086F8C
			private void Apply_Step2_Pan()
			{
				global::NetworkCullInfo meat = global::NetCull.CullProcessor.meat;
				meat.setGroupID = meat.workingGroupID;
				if (meat.anyBackers)
				{
					meat.RunRiderCommand(global::NetworkCullInfo.RiderCommand.Copy);
					meat.OnGroupWillChange();
					meat.RunRiderCommand(global::NetworkCullInfo.RiderCommand.OnGroupWillChange);
				}
				else
				{
					meat.OnGroupWillChange();
				}
			}

			// Token: 0x060023D6 RID: 9174 RVA: 0x00088DD8 File Offset: 0x00086FD8
			private void Apply_Step3_Cook()
			{
				if (this.mode == 1)
				{
					for (int i = 0; i < this.oven.size; i++)
					{
						global::NetworkCullInfo networkCullInfo = this.oven.buffer[i];
						networkCullInfo.ApplyGroupChange();
						if (networkCullInfo.anyBackers)
						{
							networkCullInfo.RunRiderCommand(global::NetworkCullInfo.RiderCommand.ApplyGroupChange);
						}
					}
				}
				else if (this.mode == 2)
				{
					for (int j = 0; j < this.oven.size; j++)
					{
						global::NetworkCullInfo networkCullInfo2 = this.oven.buffer[j];
						if (networkCullInfo2.playerRoot)
						{
							global::NetUser user = networkCullInfo2.user;
							if (user.isConnectedClient && global::CullGrid.UpdatePlayerCenterFromPlayerRoot(networkCullInfo2))
							{
								networkCullInfo2.ApplyGroupChange();
								if (networkCullInfo2.anyBackers)
								{
									networkCullInfo2.RunRiderCommand(global::NetworkCullInfo.RiderCommand.ApplyGroupChange);
								}
								while (++j < this.oven.size)
								{
									networkCullInfo2 = this.oven.buffer[j];
									if (networkCullInfo2.playerRoot)
									{
										user = networkCullInfo2.user;
										if (user.isConnectedClient)
										{
											global::CullGrid.UpdatePlayerCenterFromPlayerRoot(networkCullInfo2);
										}
									}
									networkCullInfo2.ApplyGroupChange();
									if (networkCullInfo2.anyBackers)
									{
										networkCullInfo2.RunRiderCommand(global::NetworkCullInfo.RiderCommand.ApplyGroupChange);
									}
								}
								global::CullGrid.ApplyUpdatedPlayerCentersFromPlayerRoots();
								break;
							}
						}
						networkCullInfo2.ApplyGroupChange();
						if (networkCullInfo2.anyBackers)
						{
							networkCullInfo2.RunRiderCommand(global::NetworkCullInfo.RiderCommand.ApplyGroupChange);
						}
					}
				}
			}

			// Token: 0x060023D7 RID: 9175 RVA: 0x00088F38 File Offset: 0x00087138
			private void Apply_Step4_Unpan()
			{
				global::NetworkCullInfo meat = global::NetCull.CullProcessor.meat;
				meat.OnGroupChanged();
				if (meat.anyBackers)
				{
					meat.RunRiderCommand(global::NetworkCullInfo.RiderCommand.OnGroupChanged);
				}
			}

			// Token: 0x060023D8 RID: 9176 RVA: 0x00088F64 File Offset: 0x00087164
			private void Apply_Step5_Consume()
			{
				global::NetworkCullInfo.List.UnlockAutoRemove();
			}

			// Token: 0x060023D9 RID: 9177 RVA: 0x00088F6C File Offset: 0x0008716C
			private void _Proc_Apply_TestRottenMeatAndBake()
			{
				this.Apply_Step2_Pan();
				this.dish.Add(global::NetCull.CullProcessor.meat);
				if (--global::NetCull.CullProcessor.meat_iter >= 0)
				{
					for (;;)
					{
						global::NetCull.CullProcessor.meat_test_worth_cooking = this.change.buffer[global::NetCull.CullProcessor.meat_iter];
						this.change.RemoveAt(global::NetCull.CullProcessor.meat_iter);
						if (global::NetCull.CullProcessor.meat_test_worth_cooking.process_call == this.process_call || global::NetCull.CullProcessor.Let.TestChange(global::NetCull.CullProcessor.meat_test_worth_cooking))
						{
							break;
						}
						if (--global::NetCull.CullProcessor.meat_iter < 0)
						{
							goto IL_B6;
						}
					}
					global::NetworkCullInfo meat = global::NetCull.CullProcessor.meat;
					global::NetCull.CullProcessor.meat = global::NetCull.CullProcessor.meat_test_worth_cooking;
					global::NetCull.CullProcessor.meat_test_worth_cooking = null;
					this._Proc_Apply_TestRottenMeatAndBake();
					global::NetCull.CullProcessor.meat = meat;
					this.Apply_Step4_Unpan();
					return;
				}
				IL_B6:
				global::NetCull.CullProcessor.meat_test_worth_cooking = global::NetCull.CullProcessor.meat;
				global::NetCull.CullProcessor.meat = null;
				this.Apply_Step3_Cook();
				global::NetCull.CullProcessor.meat = global::NetCull.CullProcessor.meat_test_worth_cooking;
				global::NetCull.CullProcessor.meat_test_worth_cooking = null;
				this.Apply_Step4_Unpan();
			}

			// Token: 0x060023DA RID: 9178 RVA: 0x0008905C File Offset: 0x0008725C
			public bool Apply()
			{
				if ((global::NetCull.CullProcessor.meat_iter = this.change.size) > 0)
				{
					for (;;)
					{
						global::NetCull.CullProcessor.meat_test_worth_cooking = this.change.buffer[--global::NetCull.CullProcessor.meat_iter];
						this.change.RemoveAt(global::NetCull.CullProcessor.meat_iter);
						if (global::NetCull.CullProcessor.meat_test_worth_cooking.process_call == this.process_call || global::NetCull.CullProcessor.Let.TestChange(global::NetCull.CullProcessor.meat_test_worth_cooking))
						{
							break;
						}
						if (global::NetCull.CullProcessor.meat_iter <= 0)
						{
							return false;
						}
					}
					this.Apply_Step1_Preheat();
					global::NetCull.CullProcessor.meat = global::NetCull.CullProcessor.meat_test_worth_cooking;
					global::NetCull.CullProcessor.meat_test_worth_cooking = null;
					this._Proc_Apply_TestRottenMeatAndBake();
					global::NetCull.CullProcessor.meat = null;
					this.Apply_Step5_Consume();
					this.dish.Clear();
					global::NetCull.CullProcessor.meat_test_worth_cooking = null;
					return true;
				}
				return false;
			}

			// Token: 0x060023DB RID: 9179 RVA: 0x00089120 File Offset: 0x00087320
			public bool Apply(bool advance_process)
			{
				if (advance_process)
				{
					this.AdvanceProcessFrame();
				}
				return this.Apply();
			}

			// Token: 0x040011CA RID: 4554
			public readonly global::NetworkCullInfo.List movers;

			// Token: 0x040011CB RID: 4555
			public readonly global::NetworkCullInfo.List queuedToChange;

			// Token: 0x040011CC RID: 4556
			public readonly global::NetworkCullInfo.List change;

			// Token: 0x040011CD RID: 4557
			public readonly global::NetworkCullInfo.List dish;

			// Token: 0x040011CE RID: 4558
			public readonly global::NetworkCullInfo.List oven;

			// Token: 0x040011CF RID: 4559
			private byte pending_oper;

			// Token: 0x040011D0 RID: 4560
			public readonly int mode;

			// Token: 0x040011D1 RID: 4561
			private ulong process_call;
		}
	}

	// Token: 0x02000401 RID: 1025
	// (Invoke) Token: 0x060023DD RID: 9181
	public delegate void UpdateFunctor();
}
