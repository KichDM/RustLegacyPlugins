using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000635 RID: 1589
public class BasicTorchItemRep : global::ItemRepresentation
{
	// Token: 0x06003250 RID: 12880 RVA: 0x000C09A8 File Offset: 0x000BEBA8
	public BasicTorchItemRep()
	{
	}

	// Token: 0x06003251 RID: 12881 RVA: 0x000C09B0 File Offset: 0x000BEBB0
	public void RepIgnite()
	{
		if (!this.lit)
		{
			this.ServerRPC_Status(true);
		}
	}

	// Token: 0x06003252 RID: 12882 RVA: 0x000C09C4 File Offset: 0x000BEBC4
	public void RepExtinguish()
	{
		if (this.lit)
		{
			this.ServerRPC_Status(false);
		}
	}

	// Token: 0x06003253 RID: 12883 RVA: 0x000C09D8 File Offset: 0x000BEBD8
	[global::UnityEngine.RPC]
	protected void OnStatus(bool on)
	{
		if (on != this.lit)
		{
			if (on)
			{
				this.RepIgnite();
			}
			else
			{
				this.RepExtinguish();
			}
			this.lit = on;
		}
	}

	// Token: 0x06003254 RID: 12884 RVA: 0x000C0A10 File Offset: 0x000BEC10
	private void ServerRPC_Status(bool lit)
	{
		global::Facepunch.NetworkView networkView = base.networkView;
		global::uLink.RPCMode rpcmode;
		if (!lit)
		{
			if (this.lit)
			{
				global::NetCull.RemoveRPCsByName(networkView.viewID, "OnStatus");
			}
			rpcmode = 9;
		}
		else
		{
			rpcmode = 0xD;
		}
		networkView.RPC<bool>("OnStatus", rpcmode, lit);
		this.lit = lit;
	}

	// Token: 0x06003255 RID: 12885 RVA: 0x000C0A64 File Offset: 0x000BEC64
	private void KillLight()
	{
		if (this._myLight)
		{
			global::UnityEngine.Object.Destroy(this._myLight);
			this._myLight = null;
		}
	}

	// Token: 0x04001C0C RID: 7180
	private const bool defaultLit = false;

	// Token: 0x04001C0D RID: 7181
	public global::UnityEngine.GameObject _myLight;

	// Token: 0x04001C0E RID: 7182
	public global::UnityEngine.GameObject _myLightPrefab;

	// Token: 0x04001C0F RID: 7183
	private bool lit;
}
