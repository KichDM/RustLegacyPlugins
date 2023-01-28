using System;
using uLink;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class SupplyCrate : global::IDMain, global::IInterpTimedEventReceiver
{
	// Token: 0x06000310 RID: 784 RVA: 0x0000EE14 File Offset: 0x0000D014
	public SupplyCrate() : this(0)
	{
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0000EE20 File Offset: 0x0000D020
	protected SupplyCrate(global::IDFlags idFlags) : base(idFlags)
	{
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0000EE30 File Offset: 0x0000D030
	void global::IInterpTimedEventReceiver.OnInterpTimedEvent()
	{
		if (global::InterpTimedEvent.Tag == "LAND")
		{
			this.LandShared();
		}
		else
		{
			global::InterpTimedEvent.MarkUnhandled();
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0000EE64 File Offset: 0x0000D064
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.lootableObject.accessLocked = true;
		base.InvokeRepeating("DoNetwork", global::NetCull.sendIntervalF, global::NetCull.sendIntervalF);
		this._interp.running = false;
		global::ServerHelper.SetupForServer(base.gameObject);
	}

	// Token: 0x06000314 RID: 788 RVA: 0x0000EEAC File Offset: 0x0000D0AC
	public void FixedUpdate()
	{
		if (!this._landing)
		{
			base.rigidbody.AddForceAtPosition(global::UnityEngine.Vector3.up * 10f * global::UnityEngine.Time.deltaTime, base.transform.position + new global::UnityEngine.Vector3(0f, 1f, 0f));
		}
		else if (base.rigidbody.IsSleeping())
		{
			this.GoStatic();
			this.DoLand();
			base.enabled = false;
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0000EF34 File Offset: 0x0000D134
	public void DoNetwork()
	{
		base.networkView.RPC("GetNetworkUpdate", this.updateRPCMode, new object[]
		{
			base.transform.position,
			base.transform.rotation
		});
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0000EF84 File Offset: 0x0000D184
	public void OnCollisionEnter(global::UnityEngine.Collision collision)
	{
		if (!this._landing)
		{
			this._landing = true;
			if (this.bubbleWrap)
			{
				foreach (global::UnityEngine.Collider collider in this.bubbleWrap.GetComponentsInChildren<global::UnityEngine.Collider>())
				{
					if (collider.isTrigger)
					{
						collider.enabled = false;
					}
				}
			}
		}
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0000EFEC File Offset: 0x0000D1EC
	public void DoLand()
	{
		this.LandShared();
		base.networkView.RPC("Landed", 5, new object[0]);
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0000F018 File Offset: 0x0000D218
	public void GoStatic()
	{
		base.CancelInvoke("DoNetwork");
		base.rigidbody.isKinematic = true;
		this.updateRPCMode = 5;
		this.DoNetwork();
		base.rigidbody.detectCollisions = false;
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0000F058 File Offset: 0x0000D258
	private void LandShared()
	{
		this._landed = true;
		if (this.lootableObject)
		{
			this.lootableObject.accessLocked = false;
		}
		global::UnityEngine.Object.Destroy(this.bubbleWrap);
	}

	// Token: 0x0600031A RID: 794 RVA: 0x0000F094 File Offset: 0x0000D294
	[global::UnityEngine.RPC]
	protected void GetNetworkUpdate(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x0600031B RID: 795 RVA: 0x0000F098 File Offset: 0x0000D298
	[global::UnityEngine.RPC]
	public void Landed(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x040002D4 RID: 724
	public global::RigidbodyInterpolator _interp;

	// Token: 0x040002D5 RID: 725
	protected bool _landed;

	// Token: 0x040002D6 RID: 726
	protected bool _landing;

	// Token: 0x040002D7 RID: 727
	protected global::uLink.RPCMode updateRPCMode = 1;

	// Token: 0x040002D8 RID: 728
	public global::SupplyParachute chute;

	// Token: 0x040002D9 RID: 729
	public global::UnityEngine.GameObject landedEffect;

	// Token: 0x040002DA RID: 730
	public global::LootableObject lootableObject;

	// Token: 0x040002DB RID: 731
	public global::UnityEngine.GameObject bubbleWrap;
}
