using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uLink;
using UnityEngine;

// Token: 0x020005CE RID: 1486
public class SignalGrenade : global::RigidObj
{
	// Token: 0x0600308D RID: 12429 RVA: 0x000B8C84 File Offset: 0x000B6E84
	public SignalGrenade() : base(global::RigidObj.FeatureFlags.StreamInitialVelocity | global::RigidObj.FeatureFlags.StreamOwnerViewID | global::RigidObj.FeatureFlags.ServerCollisions)
	{
	}

	// Token: 0x0600308E RID: 12430 RVA: 0x000B8C9C File Offset: 0x000B6E9C
	private new void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		base.uLink_OnNetworkInstantiate(info);
		global::ServerHelper.SetupForServer(base.gameObject);
		base.Invoke("TimeIsUp", this.fuseLength);
	}

	// Token: 0x0600308F RID: 12431 RVA: 0x000B8CCC File Offset: 0x000B6ECC
	private void TimeIsUp()
	{
		global::RigidObj.MakeDoneAndDestroy(this);
	}

	// Token: 0x06003090 RID: 12432 RVA: 0x000B8CD4 File Offset: 0x000B6ED4
	protected override void OnHide()
	{
		if (base.renderer)
		{
			base.renderer.enabled = false;
		}
	}

	// Token: 0x06003091 RID: 12433 RVA: 0x000B8CF4 File Offset: 0x000B6EF4
	protected override void OnShow()
	{
		if (base.renderer)
		{
			base.renderer.enabled = true;
		}
	}

	// Token: 0x06003092 RID: 12434 RVA: 0x000B8D14 File Offset: 0x000B6F14
	protected override void OnDone()
	{
		global::SupplyDropZone.CallAirDropAt(this.rigidbody.position + new global::UnityEngine.Vector3(global::UnityEngine.Random.Range(-20f, 20f), 75f, global::UnityEngine.Random.Range(-20f, 20f)));
	}

	// Token: 0x06003093 RID: 12435 RVA: 0x000B8D60 File Offset: 0x000B6F60
	protected override void OnServerCollisionEnter(global::UnityEngine.Collision collision)
	{
		if (global::UnityEngine.Time.time - this.lastBounceTime < 0.25f)
		{
			return;
		}
		this.lastBounceTime = global::UnityEngine.Time.time;
		if (collision.relativeVelocity.sqrMagnitude > 0.0225f)
		{
			base.networkView.RPC("ClientBounce", 1, new object[0]);
		}
	}

	// Token: 0x06003094 RID: 12436 RVA: 0x000B8DC0 File Offset: 0x000B6FC0
	[global::UnityEngine.RPC]
	private void ClientBounce(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06003095 RID: 12437 RVA: 0x000B8DC4 File Offset: 0x000B6FC4
	private void PlayClientBounce()
	{
		this.bounceSound.Play(this.rigidbody.position, 0.25f, global::UnityEngine.Random.Range(0.85f, 1.15f), 1f, 18f);
	}

	// Token: 0x06003096 RID: 12438 RVA: 0x000B8E08 File Offset: 0x000B7008
	protected override bool OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::SignalGrenade.<>f__switch$map9 == null)
			{
				global::SignalGrenade.<>f__switch$map9 = new global::System.Collections.Generic.Dictionary<string, int>(1)
				{
					{
						"bounce",
						0
					}
				};
			}
			int num;
			if (global::SignalGrenade.<>f__switch$map9.TryGetValue(tag, out num))
			{
				if (num == 0)
				{
					this.PlayClientBounce();
					return true;
				}
			}
		}
		return base.OnInterpTimedEvent();
	}

	// Token: 0x04001A3E RID: 6718
	private float fuseLength = 3f;

	// Token: 0x04001A3F RID: 6719
	public global::UnityEngine.GameObject explosionEffect;

	// Token: 0x04001A40 RID: 6720
	public global::UnityEngine.AudioClip bounceSound;

	// Token: 0x04001A41 RID: 6721
	private float lastBounceTime;

	// Token: 0x04001A42 RID: 6722
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map9;
}
