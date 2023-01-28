using System;
using UnityEngine;

// Token: 0x02000708 RID: 1800
public abstract class StrikeGunItem<T> : global::BulletWeaponItem<T> where T : global::StrikeGunDataBlock
{
	// Token: 0x06003D16 RID: 15638 RVA: 0x000D6FBC File Offset: 0x000D51BC
	protected StrikeGunItem(T db) : base(db)
	{
	}

	// Token: 0x06003D17 RID: 15639 RVA: 0x000D6FC8 File Offset: 0x000D51C8
	public void ResetFiring()
	{
		this.actualFireTime = 0f;
		this.beganFiring = false;
	}

	// Token: 0x06003D18 RID: 15640 RVA: 0x000D6FDC File Offset: 0x000D51DC
	protected override void OnSetActive(bool isActive)
	{
		this.ResetFiring();
		base.OnSetActive(isActive);
	}

	// Token: 0x06003D19 RID: 15641 RVA: 0x000D6FEC File Offset: 0x000D51EC
	public virtual void CancelAttack(ref global::HumanController.InputSample sample)
	{
		if (this.beganFiring)
		{
			global::ViewModel viewModelInstance = base.viewModelInstance;
			T datablock = this.datablock;
			datablock.Local_CancelStrikes(base.viewModelInstance, base.itemRepresentation, this.iface as global::IStrikeGunItem, ref sample);
			base.nextPrimaryAttackTime = global::UnityEngine.Time.time + 1f;
			this.ResetFiring();
		}
	}

	// Token: 0x06003D1A RID: 15642 RVA: 0x000D7050 File Offset: 0x000D5250
	public override void PrimaryAttack(ref global::HumanController.InputSample sample)
	{
		if (!this.beganFiring)
		{
			int num = global::UnityEngine.Random.Range(1, this.datablock.strikeDurations.Length + 1);
			num = global::UnityEngine.Mathf.Clamp(num, 1, this.datablock.strikeDurations.Length);
			this.actualFireTime = global::UnityEngine.Time.time + this.datablock.strikeDurations[num - 1];
			T datablock = this.datablock;
			datablock.Local_BeginStrikes(num, base.viewModelInstance, base.itemRepresentation, this.iface as global::IStrikeGunItem, ref sample);
			this.beganFiring = true;
		}
	}

	// Token: 0x04001EE1 RID: 7905
	public bool beganFiring;

	// Token: 0x04001EE2 RID: 7906
	public float actualFireTime;
}
