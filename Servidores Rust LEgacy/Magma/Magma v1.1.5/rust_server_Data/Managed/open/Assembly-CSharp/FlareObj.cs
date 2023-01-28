using System;
using uLink;
using UnityEngine;

// Token: 0x020005CC RID: 1484
public sealed class FlareObj : global::RigidObj
{
	// Token: 0x06003084 RID: 12420 RVA: 0x000B8AF0 File Offset: 0x000B6CF0
	public FlareObj() : base(global::RigidObj.FeatureFlags.StreamInitialVelocity)
	{
	}

	// Token: 0x06003085 RID: 12421 RVA: 0x000B8AFC File Offset: 0x000B6CFC
	private new void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.lightInstance = (global::UnityEngine.Object.Instantiate(this.lightPrefab, base.transform.position + new global::UnityEngine.Vector3(0f, 0.1f, 0f), global::UnityEngine.Quaternion.identity) as global::UnityEngine.GameObject);
		this.lightInstance.transform.parent = base.transform;
		base.Invoke("DestroyTime", 90f);
		base.uLink_OnNetworkInstantiate(info);
	}

	// Token: 0x06003086 RID: 12422 RVA: 0x000B8B78 File Offset: 0x000B6D78
	protected override void OnDone()
	{
	}

	// Token: 0x06003087 RID: 12423 RVA: 0x000B8B7C File Offset: 0x000B6D7C
	protected override void OnHide()
	{
		if (this.lightInstance)
		{
			this.lightInstance.SetActive(false);
		}
		if (base.renderer)
		{
			base.renderer.enabled = false;
		}
	}

	// Token: 0x06003088 RID: 12424 RVA: 0x000B8BC4 File Offset: 0x000B6DC4
	protected override void OnShow()
	{
		if (this.lightInstance)
		{
			this.lightInstance.SetActive(true);
		}
		if (base.renderer)
		{
			base.renderer.enabled = true;
		}
	}

	// Token: 0x06003089 RID: 12425 RVA: 0x000B8C0C File Offset: 0x000B6E0C
	private void DestroyTime()
	{
		global::RigidObj.MakeDoneAndDestroy(this);
	}

	// Token: 0x04001A38 RID: 6712
	private global::UnityEngine.GameObject lightInstance;

	// Token: 0x04001A39 RID: 6713
	public global::UnityEngine.AudioClip StrikeSound;

	// Token: 0x04001A3A RID: 6714
	public global::UnityEngine.GameObject lightPrefab;
}
