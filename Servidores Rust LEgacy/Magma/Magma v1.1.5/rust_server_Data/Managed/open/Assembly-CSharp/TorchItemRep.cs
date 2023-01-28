using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000723 RID: 1827
public class TorchItemRep : global::ItemRepresentation
{
	// Token: 0x06003DEB RID: 15851 RVA: 0x000D9094 File Offset: 0x000D7294
	public TorchItemRep()
	{
	}

	// Token: 0x06003DEC RID: 15852 RVA: 0x000D909C File Offset: 0x000D729C
	private void KillLight()
	{
		if (this._myLight)
		{
			global::UnityEngine.Object.Destroy(this._myLight);
			this._myLight = null;
		}
	}

	// Token: 0x06003DED RID: 15853 RVA: 0x000D90CC File Offset: 0x000D72CC
	protected new void OnDestroy()
	{
		this.KillLight();
		base.OnDestroy();
	}

	// Token: 0x06003DEE RID: 15854 RVA: 0x000D90DC File Offset: 0x000D72DC
	protected new void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		base.uLink_OnNetworkInstantiate(info);
		this.OnStatus(false);
	}

	// Token: 0x06003DEF RID: 15855 RVA: 0x000D90EC File Offset: 0x000D72EC
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

	// Token: 0x06003DF0 RID: 15856 RVA: 0x000D9124 File Offset: 0x000D7324
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

	// Token: 0x06003DF1 RID: 15857 RVA: 0x000D9178 File Offset: 0x000D7378
	public void RepIgnite()
	{
		if (!this.lit)
		{
			this.ServerRPC_Status(true);
		}
	}

	// Token: 0x06003DF2 RID: 15858 RVA: 0x000D918C File Offset: 0x000D738C
	public void RepExtinguish()
	{
		if (this.lit)
		{
			this.ServerRPC_Status(false);
		}
	}

	// Token: 0x04001F4A RID: 8010
	private const bool defaultLit = false;

	// Token: 0x04001F4B RID: 8011
	public global::UnityEngine.GameObject _myLight;

	// Token: 0x04001F4C RID: 8012
	public global::UnityEngine.GameObject _myLightPrefab;

	// Token: 0x04001F4D RID: 8013
	public global::UnityEngine.AudioClip StrikeSound;

	// Token: 0x04001F4E RID: 8014
	private bool lit;
}
