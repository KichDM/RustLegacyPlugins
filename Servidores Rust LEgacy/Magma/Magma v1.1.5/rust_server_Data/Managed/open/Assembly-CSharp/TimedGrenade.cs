using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x020005D3 RID: 1491
public class TimedGrenade : global::RigidObj
{
	// Token: 0x060030A6 RID: 12454 RVA: 0x000B90E4 File Offset: 0x000B72E4
	public TimedGrenade() : base(global::RigidObj.FeatureFlags.StreamInitialVelocity | global::RigidObj.FeatureFlags.StreamOwnerViewID | global::RigidObj.FeatureFlags.ServerCollisions)
	{
	}

	// Token: 0x060030A7 RID: 12455 RVA: 0x000B9120 File Offset: 0x000B7320
	private new void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		base.uLink_OnNetworkInstantiate(info);
		global::ServerHelper.SetupForServer(base.gameObject);
		base.Invoke("TimeIsUp", this.fuseLength);
		if (!this.myOwner)
		{
			global::Facepunch.NetworkView ownerView = base.ownerView;
			if (ownerView)
			{
				this.myOwner = ownerView.idMain;
			}
		}
	}

	// Token: 0x060030A8 RID: 12456 RVA: 0x000B9180 File Offset: 0x000B7380
	private void TimeIsUp()
	{
		global::RigidObj.MakeDoneAndDestroy(this);
	}

	// Token: 0x060030A9 RID: 12457 RVA: 0x000B9188 File Offset: 0x000B7388
	protected override void OnHide()
	{
		if (base.renderer)
		{
			base.renderer.enabled = false;
		}
	}

	// Token: 0x060030AA RID: 12458 RVA: 0x000B91A8 File Offset: 0x000B73A8
	protected override void OnShow()
	{
		if (base.renderer)
		{
			base.renderer.enabled = true;
		}
	}

	// Token: 0x060030AB RID: 12459 RVA: 0x000B91C8 File Offset: 0x000B73C8
	protected override void OnDone()
	{
		base.collider.enabled = false;
		global::UnityEngine.Vector3 point = this.rigidbody.position + new global::UnityEngine.Vector3(0f, 0.3f, 0f);
		foreach (global::ExplosionHelper.Surface surface in global::ExplosionHelper.OverlapExplosionUnique(point, this.explosionRadius, 0x10360401, -1, this))
		{
			float num = (1f - global::UnityEngine.Mathf.Clamp01(surface.work.distanceToCenter / this.explosionRadius)) * this.damage;
			if (surface.blocked)
			{
				num *= 0.1f;
			}
			if (num > 0.0001f)
			{
				global::TakeDamage.Hurt(this, surface.idBase, new global::DamageTypeList(0f, 0f, 0f, num, 0f, 0f), null);
			}
		}
	}

	// Token: 0x060030AC RID: 12460 RVA: 0x000B92C4 File Offset: 0x000B74C4
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

	// Token: 0x060030AD RID: 12461 RVA: 0x000B9324 File Offset: 0x000B7524
	[global::UnityEngine.RPC]
	private void ClientBounce(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x060030AE RID: 12462 RVA: 0x000B9328 File Offset: 0x000B7528
	private void PlayClientBounce()
	{
		this.bounceSound.Play(this.rigidbody.position, 0.25f, global::UnityEngine.Random.Range(0.85f, 1.15f), 1f, 18f);
	}

	// Token: 0x060030AF RID: 12463 RVA: 0x000B936C File Offset: 0x000B756C
	protected override bool OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::TimedGrenade.<>f__switch$mapA == null)
			{
				global::TimedGrenade.<>f__switch$mapA = new global::System.Collections.Generic.Dictionary<string, int>(1)
				{
					{
						"bounce",
						0
					}
				};
			}
			int num;
			if (global::TimedGrenade.<>f__switch$mapA.TryGetValue(tag, out num))
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

	// Token: 0x04001A4D RID: 6733
	private float fuseLength = 3f;

	// Token: 0x04001A4E RID: 6734
	public global::UnityEngine.GameObject explosionEffect;

	// Token: 0x04001A4F RID: 6735
	public float explosionRadius = 30f;

	// Token: 0x04001A50 RID: 6736
	public float damage = 200f;

	// Token: 0x04001A51 RID: 6737
	public global::IDMain myOwner;

	// Token: 0x04001A52 RID: 6738
	public global::UnityEngine.AudioClip bounceSound;

	// Token: 0x04001A53 RID: 6739
	private float lastBounceTime;

	// Token: 0x04001A54 RID: 6740
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$mapA;
}
