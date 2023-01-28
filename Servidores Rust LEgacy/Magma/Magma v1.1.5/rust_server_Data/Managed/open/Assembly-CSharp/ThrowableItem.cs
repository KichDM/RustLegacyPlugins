using System;
using UnityEngine;

// Token: 0x0200070C RID: 1804
public abstract class ThrowableItem<T> : global::WeaponItem<T> where T : global::ThrowableItemDataBlock
{
	// Token: 0x06003D2B RID: 15659 RVA: 0x000D76E0 File Offset: 0x000D58E0
	protected ThrowableItem(T db) : base(db)
	{
	}

	// Token: 0x17000B96 RID: 2966
	// (get) Token: 0x06003D2C RID: 15660 RVA: 0x000D76F4 File Offset: 0x000D58F4
	// (set) Token: 0x06003D2D RID: 15661 RVA: 0x000D76FC File Offset: 0x000D58FC
	public float holdingStartTime
	{
		get
		{
			return this._holdingStartTime;
		}
		set
		{
			this._holdingStartTime = value;
		}
	}

	// Token: 0x17000B97 RID: 2967
	// (get) Token: 0x06003D2E RID: 15662 RVA: 0x000D7708 File Offset: 0x000D5908
	// (set) Token: 0x06003D2F RID: 15663 RVA: 0x000D7710 File Offset: 0x000D5910
	public bool holdingBack
	{
		get
		{
			return this._holdingBack;
		}
		set
		{
			this._holdingBack = value;
		}
	}

	// Token: 0x17000B98 RID: 2968
	// (get) Token: 0x06003D30 RID: 15664 RVA: 0x000D771C File Offset: 0x000D591C
	// (set) Token: 0x06003D31 RID: 15665 RVA: 0x000D7724 File Offset: 0x000D5924
	public float minReleaseTime
	{
		get
		{
			return this._minReleaseTime;
		}
		set
		{
			this._minReleaseTime = value;
		}
	}

	// Token: 0x06003D32 RID: 15666 RVA: 0x000D7730 File Offset: 0x000D5930
	public override void PrimaryAttack(ref global::HumanController.InputSample sample)
	{
		base.nextPrimaryAttackTime = global::UnityEngine.Time.time + this.datablock.fireRate;
		T datablock = this.datablock;
		datablock.PrimaryAttack(base.viewModelInstance, base.itemRepresentation, this.iface as global::IThrowableItem, ref sample);
	}

	// Token: 0x06003D33 RID: 15667 RVA: 0x000D7788 File Offset: 0x000D5988
	public override void SecondaryAttack(ref global::HumanController.InputSample sample)
	{
		base.nextSecondaryAttackTime = global::UnityEngine.Time.time + this.datablock.fireRateSecondary;
		T datablock = this.datablock;
		datablock.SecondaryAttack(base.viewModelInstance, base.itemRepresentation, this.iface as global::IThrowableItem, ref sample);
	}

	// Token: 0x06003D34 RID: 15668 RVA: 0x000D77E0 File Offset: 0x000D59E0
	public virtual void BeginHoldingBack()
	{
		this.holdingStartTime = global::UnityEngine.Time.time;
		this.holdingBack = true;
	}

	// Token: 0x06003D35 RID: 15669 RVA: 0x000D77F4 File Offset: 0x000D59F4
	public virtual void EndHoldingBack()
	{
		this.holdingBack = false;
		this.holdingStartTime = 0f;
	}

	// Token: 0x06003D36 RID: 15670 RVA: 0x000D7808 File Offset: 0x000D5A08
	protected override void OnSetActive(bool isActive)
	{
		this.EndHoldingBack();
		base.OnSetActive(isActive);
	}

	// Token: 0x17000B99 RID: 2969
	// (get) Token: 0x06003D37 RID: 15671 RVA: 0x000D7818 File Offset: 0x000D5A18
	public virtual float heldThrowStrength
	{
		get
		{
			float num = global::UnityEngine.Time.time - this.holdingStartTime;
			return global::UnityEngine.Mathf.Clamp(num * this.datablock.throwStrengthPerSec, this.datablock.throwStrengthMin, this.datablock.throwStrengthMin);
		}
	}

	// Token: 0x04001EEE RID: 7918
	private float _holdingStartTime;

	// Token: 0x04001EEF RID: 7919
	private bool _holdingBack;

	// Token: 0x04001EF0 RID: 7920
	private float _minReleaseTime = 1.25f;
}
