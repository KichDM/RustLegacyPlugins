using System;
using UnityEngine;

// Token: 0x020002EF RID: 751
[global::UnityEngine.RequireComponent(typeof(global::CCDesc))]
public sealed class CCHitDispatch : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x00063BD0 File Offset: 0x00061DD0
	public CCHitDispatch()
	{
	}

	// Token: 0x1400000C RID: 12
	// (add) Token: 0x060019C3 RID: 6595 RVA: 0x00063BD8 File Offset: 0x00061DD8
	// (remove) Token: 0x060019C4 RID: 6596 RVA: 0x00063C00 File Offset: 0x00061E00
	public event global::CCDesc.HitFilter OnHit
	{
		add
		{
			global::CCDesc.HitManager hits = this.Hits;
			if (!object.ReferenceEquals(hits, null))
			{
				hits.OnHit += value;
			}
		}
		remove
		{
			global::CCDesc.HitManager hits = this.Hits;
			if (!object.ReferenceEquals(hits, null))
			{
				hits.OnHit -= value;
			}
		}
	}

	// Token: 0x17000724 RID: 1828
	// (get) Token: 0x060019C5 RID: 6597 RVA: 0x00063C28 File Offset: 0x00061E28
	public global::CCDesc.HitManager Hits
	{
		get
		{
			if (!this.didSetup)
			{
				this.DoSetup();
			}
			return this.hitManager;
		}
	}

	// Token: 0x17000725 RID: 1829
	// (get) Token: 0x060019C6 RID: 6598 RVA: 0x00063C44 File Offset: 0x00061E44
	public global::CCDesc CCDesc
	{
		get
		{
			if (!global::UnityEngine.Application.isPlaying)
			{
				return (!this.ccdesc) ? base.GetComponent<global::CCDesc>() : this.ccdesc;
			}
			if (!this.didSetup)
			{
				this.DoSetup();
			}
			return this.ccdesc;
		}
	}

	// Token: 0x060019C7 RID: 6599 RVA: 0x00063C94 File Offset: 0x00061E94
	private void DoSetup()
	{
		if (!this.didSetup)
		{
			if (!global::UnityEngine.Application.isPlaying)
			{
				return;
			}
			this.didSetup = true;
			(this.ccdesc = base.GetComponent<global::CCDesc>()).AssignedHitManager = (this.hitManager = new global::CCDesc.HitManager());
		}
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x00063CE0 File Offset: 0x00061EE0
	private void OnDestroy()
	{
		if (this.didSetup && !object.ReferenceEquals(this.hitManager, null))
		{
			global::CCDesc.HitManager hitManager = this.hitManager;
			this.hitManager = null;
			if (this.ccdesc)
			{
				this.ccdesc.AssignedHitManager = null;
			}
			hitManager.Dispose();
		}
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x00063D3C File Offset: 0x00061F3C
	private void OnControllerColliderHit(global::UnityEngine.ControllerColliderHit hit)
	{
		global::CCDesc.HitManager hits = this.Hits;
		if (!object.ReferenceEquals(hits, null))
		{
			hits.Push(hit);
		}
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x00063D64 File Offset: 0x00061F64
	public static global::CCHitDispatch GetHitDispatch(global::CCDesc CCDesc)
	{
		if (!CCDesc)
		{
			return null;
		}
		if (!object.ReferenceEquals(CCDesc.AssignedHitManager, null))
		{
			return CCDesc.GetComponent<global::CCHitDispatch>();
		}
		global::CCHitDispatch component = CCDesc.GetComponent<global::CCHitDispatch>();
		if (component)
		{
			return component;
		}
		return CCDesc.gameObject.AddComponent<global::CCHitDispatch>();
	}

	// Token: 0x04000E9B RID: 3739
	[global::System.NonSerialized]
	private global::CCDesc ccdesc;

	// Token: 0x04000E9C RID: 3740
	[global::System.NonSerialized]
	private global::CCDesc.HitManager hitManager;

	// Token: 0x04000E9D RID: 3741
	[global::System.NonSerialized]
	private bool didSetup;
}
