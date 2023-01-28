using System;
using UnityEngine;

// Token: 0x02000702 RID: 1794
public abstract class MeleeWeaponItem<T> : global::WeaponItem<T> where T : global::MeleeWeaponDataBlock
{
	// Token: 0x06003D06 RID: 15622 RVA: 0x000D6C54 File Offset: 0x000D4E54
	protected MeleeWeaponItem(T db) : base(db)
	{
	}

	// Token: 0x17000B8F RID: 2959
	// (get) Token: 0x06003D07 RID: 15623 RVA: 0x000D6C74 File Offset: 0x000D4E74
	// (set) Token: 0x06003D08 RID: 15624 RVA: 0x000D6C7C File Offset: 0x000D4E7C
	public float queuedSwingAttackTime
	{
		get
		{
			return this._queuedSwingAttackTime;
		}
		set
		{
			this._queuedSwingAttackTime = value;
		}
	}

	// Token: 0x17000B90 RID: 2960
	// (get) Token: 0x06003D09 RID: 15625 RVA: 0x000D6C88 File Offset: 0x000D4E88
	// (set) Token: 0x06003D0A RID: 15626 RVA: 0x000D6C90 File Offset: 0x000D4E90
	public float queuedSwingSoundTime
	{
		get
		{
			return this._queuedSwingSoundTime;
		}
		set
		{
			this._queuedSwingSoundTime = value;
		}
	}

	// Token: 0x06003D0B RID: 15627 RVA: 0x000D6C9C File Offset: 0x000D4E9C
	public override void PrimaryAttack(ref global::HumanController.InputSample sample)
	{
		float num = this.datablock.fireRate;
		global::Metabolism local = base.inventory.GetLocal<global::Metabolism>();
		if (local && local.GetCalorieLevel() <= 0f)
		{
			num = this.datablock.fireRate * 2f;
		}
		float num2 = global::UnityEngine.Time.time + num;
		base.nextSecondaryAttackTime = num2;
		base.nextPrimaryAttackTime = num2;
		T datablock = this.datablock;
		datablock.Local_FireWeapon(base.viewModelInstance, base.itemRepresentation, this.iface as global::IMeleeWeaponItem, ref sample);
	}

	// Token: 0x06003D0C RID: 15628 RVA: 0x000D6D3C File Offset: 0x000D4F3C
	public override void SecondaryAttack(ref global::HumanController.InputSample sample)
	{
		float num = global::UnityEngine.Time.time + this.datablock.fireRate;
		base.nextPrimaryAttackTime = num;
		base.nextSecondaryAttackTime = num;
	}

	// Token: 0x06003D0D RID: 15629 RVA: 0x000D6D70 File Offset: 0x000D4F70
	public virtual void QueueMidSwing(float time)
	{
		this.queuedSwingAttackTime = time;
	}

	// Token: 0x06003D0E RID: 15630 RVA: 0x000D6D7C File Offset: 0x000D4F7C
	public virtual void QueueSwingSound(float time)
	{
		this.queuedSwingSoundTime = time;
	}

	// Token: 0x06003D0F RID: 15631 RVA: 0x000D6D88 File Offset: 0x000D4F88
	protected override bool CanSetActivate(bool wantsTrue)
	{
		return base.CanSetActivate(wantsTrue) && (wantsTrue || base.nextPrimaryAttackTime <= global::UnityEngine.Time.time);
	}

	// Token: 0x04001EDE RID: 7902
	private float _queuedSwingAttackTime = -1f;

	// Token: 0x04001EDF RID: 7903
	private float _queuedSwingSoundTime = -1f;
}
