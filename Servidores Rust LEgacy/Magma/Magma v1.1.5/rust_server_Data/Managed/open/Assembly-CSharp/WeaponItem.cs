using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000712 RID: 1810
public abstract class WeaponItem<T> : global::HeldItem<T> where T : global::WeaponDataBlock
{
	// Token: 0x06003D6D RID: 15725 RVA: 0x000D7A48 File Offset: 0x000D5C48
	protected WeaponItem(T db) : base(db)
	{
	}

	// Token: 0x17000BB0 RID: 2992
	// (get) Token: 0x06003D6E RID: 15726 RVA: 0x000D7A54 File Offset: 0x000D5C54
	// (set) Token: 0x06003D6F RID: 15727 RVA: 0x000D7A5C File Offset: 0x000D5C5C
	public float nextPrimaryAttackTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<nextPrimaryAttackTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<nextPrimaryAttackTime>k__BackingField = value;
		}
	}

	// Token: 0x17000BB1 RID: 2993
	// (get) Token: 0x06003D70 RID: 15728 RVA: 0x000D7A68 File Offset: 0x000D5C68
	// (set) Token: 0x06003D71 RID: 15729 RVA: 0x000D7A70 File Offset: 0x000D5C70
	public float nextSecondaryAttackTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<nextSecondaryAttackTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<nextSecondaryAttackTime>k__BackingField = value;
		}
	}

	// Token: 0x17000BB2 RID: 2994
	// (get) Token: 0x06003D72 RID: 15730 RVA: 0x000D7A7C File Offset: 0x000D5C7C
	// (set) Token: 0x06003D73 RID: 15731 RVA: 0x000D7A84 File Offset: 0x000D5C84
	public float deployFinishedTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<deployFinishedTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<deployFinishedTime>k__BackingField = value;
		}
	}

	// Token: 0x17000BB3 RID: 2995
	// (get) Token: 0x06003D74 RID: 15732 RVA: 0x000D7A90 File Offset: 0x000D5C90
	// (set) Token: 0x06003D75 RID: 15733 RVA: 0x000D7A98 File Offset: 0x000D5C98
	public double lastPrimaryMessageTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<lastPrimaryMessageTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<lastPrimaryMessageTime>k__BackingField = value;
		}
	}

	// Token: 0x06003D76 RID: 15734 RVA: 0x000D7AA4 File Offset: 0x000D5CA4
	public bool ValidatePrimaryMessageTime(double timestamp)
	{
		double num = timestamp - this.lastPrimaryMessageTime;
		if (num < (double)(this.datablock.fireRate * 0.95f))
		{
			return false;
		}
		if (timestamp > global::NetCull.time + 3.0)
		{
			return false;
		}
		this.lastPrimaryMessageTime = timestamp;
		return true;
	}

	// Token: 0x17000BB4 RID: 2996
	// (get) Token: 0x06003D77 RID: 15735 RVA: 0x000D7AF8 File Offset: 0x000D5CF8
	public virtual int possibleReloadCount
	{
		get
		{
			return 0x3E7;
		}
	}

	// Token: 0x17000BB5 RID: 2997
	// (get) Token: 0x06003D78 RID: 15736 RVA: 0x000D7B00 File Offset: 0x000D5D00
	public virtual bool canPrimaryAttack
	{
		get
		{
			return global::UnityEngine.Time.time >= this.nextPrimaryAttackTime;
		}
	}

	// Token: 0x17000BB6 RID: 2998
	// (get) Token: 0x06003D79 RID: 15737 RVA: 0x000D7B14 File Offset: 0x000D5D14
	public virtual bool canSecondaryAttack
	{
		get
		{
			return global::UnityEngine.Time.time >= this.nextSecondaryAttackTime;
		}
	}

	// Token: 0x17000BB7 RID: 2999
	// (get) Token: 0x06003D7A RID: 15738 RVA: 0x000D7B28 File Offset: 0x000D5D28
	public virtual bool canReload
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06003D7B RID: 15739 RVA: 0x000D7B2C File Offset: 0x000D5D2C
	public virtual void Reload(ref global::HumanController.InputSample sample)
	{
	}

	// Token: 0x06003D7C RID: 15740 RVA: 0x000D7B30 File Offset: 0x000D5D30
	public virtual void PrimaryAttack(ref global::HumanController.InputSample sample)
	{
		this.nextPrimaryAttackTime = global::UnityEngine.Time.time + 1f;
		global::UnityEngine.Debug.Log("Primary Attack!");
	}

	// Token: 0x06003D7D RID: 15741 RVA: 0x000D7B50 File Offset: 0x000D5D50
	public virtual void SecondaryAttack(ref global::HumanController.InputSample sample)
	{
		this.nextSecondaryAttackTime = global::UnityEngine.Time.time + 1f;
		global::UnityEngine.Debug.Log("Secondary Attack!");
	}

	// Token: 0x17000BB8 RID: 3000
	// (get) Token: 0x06003D7E RID: 15742 RVA: 0x000D7B70 File Offset: 0x000D5D70
	public virtual bool deployed
	{
		get
		{
			return global::UnityEngine.Time.time > this.deployFinishedTime;
		}
	}

	// Token: 0x06003D7F RID: 15743 RVA: 0x000D7B80 File Offset: 0x000D5D80
	protected override bool CanAim()
	{
		return this.deployed && base.CanAim();
	}

	// Token: 0x06003D80 RID: 15744 RVA: 0x000D7B98 File Offset: 0x000D5D98
	protected override void OnSetActive(bool isActive)
	{
		float deployLength = this.datablock.deployLength;
		this.deployFinishedTime = global::UnityEngine.Time.time + deployLength;
		if (this.deployFinishedTime > this.nextPrimaryAttackTime)
		{
			float deployFinishedTime = this.deployFinishedTime;
			this.nextPrimaryAttackTime = deployFinishedTime;
			this.nextSecondaryAttackTime = deployFinishedTime;
		}
		base.OnSetActive(isActive);
	}

	// Token: 0x04001EF6 RID: 7926
	protected bool lastFrameAttack;

	// Token: 0x04001EF7 RID: 7927
	private bool wasSprinting;

	// Token: 0x04001EF8 RID: 7928
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <nextPrimaryAttackTime>k__BackingField;

	// Token: 0x04001EF9 RID: 7929
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <nextSecondaryAttackTime>k__BackingField;

	// Token: 0x04001EFA RID: 7930
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <deployFinishedTime>k__BackingField;

	// Token: 0x04001EFB RID: 7931
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private double <lastPrimaryMessageTime>k__BackingField;
}
