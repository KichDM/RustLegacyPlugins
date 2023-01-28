using System;
using System.Collections.Generic;
using uLink;
using UnityEngine;

// Token: 0x02000402 RID: 1026
[global::UnityEngine.AddComponentMenu("")]
internal sealed class NGCInternalView : global::uLinkNetworkView
{
	// Token: 0x060023E0 RID: 9184 RVA: 0x00089134 File Offset: 0x00087334
	public NGCInternalView()
	{
	}

	// Token: 0x060023E1 RID: 9185 RVA: 0x0008913C File Offset: 0x0008733C
	internal global::NGC GetNGC()
	{
		return this.ngc;
	}

	// Token: 0x060023E2 RID: 9186 RVA: 0x00089144 File Offset: 0x00087344
	private void Awake()
	{
		this.ngc = base.GetComponent<global::NGC>();
		this.ngc.networkView = this;
		try
		{
			this.observed = this.ngc;
			this.rpcReceiver = 1;
			this.stateSynchronization = 0;
			this.securable = 0;
		}
		finally
		{
			try
			{
				base.Awake();
			}
			finally
			{
				this.ngc.networkViewID = base.viewID;
			}
		}
	}

	// Token: 0x060023E3 RID: 9187 RVA: 0x000891E4 File Offset: 0x000873E4
	protected override bool OnRPC(string rpcName, global::uLink.BitStream stream, global::uLink.NetworkMessageInfo info)
	{
		char c = rpcName[0];
		string text;
		if (!global::NGCInternalView.Hack.actionToRPCName.TryGetValue(c, out text))
		{
			text = (global::NGCInternalView.Hack.actionToRPCName[c] = "NGC:" + c);
		}
		return base.OnRPC(text, stream, info);
	}

	// Token: 0x040011D2 RID: 4562
	[global::System.NonSerialized]
	private global::NGC ngc;

	// Token: 0x02000403 RID: 1027
	private static class Hack
	{
		// Token: 0x060023E4 RID: 9188 RVA: 0x00089234 File Offset: 0x00087434
		// Note: this type is marked as 'beforefieldinit'.
		static Hack()
		{
		}

		// Token: 0x040011D3 RID: 4563
		public static global::System.Collections.Generic.Dictionary<char, string> actionToRPCName = new global::System.Collections.Generic.Dictionary<char, string>();
	}
}
