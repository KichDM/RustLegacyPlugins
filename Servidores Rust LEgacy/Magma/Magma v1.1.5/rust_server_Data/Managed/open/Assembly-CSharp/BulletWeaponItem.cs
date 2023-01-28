using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020006E2 RID: 1762
public abstract class BulletWeaponItem<T> : global::WeaponItem<T> where T : global::BulletWeaponDataBlock
{
	// Token: 0x06003C2E RID: 15406 RVA: 0x000D51C0 File Offset: 0x000D33C0
	protected BulletWeaponItem(T db) : base(db)
	{
	}

	// Token: 0x17000B4C RID: 2892
	// (get) Token: 0x06003C2F RID: 15407 RVA: 0x000D51D4 File Offset: 0x000D33D4
	// (set) Token: 0x06003C30 RID: 15408 RVA: 0x000D51DC File Offset: 0x000D33DC
	public global::MagazineDataBlock clipType
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<clipType>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected set
		{
			this.<clipType>k__BackingField = value;
		}
	}

	// Token: 0x17000B4D RID: 2893
	// (get) Token: 0x06003C31 RID: 15409 RVA: 0x000D51E8 File Offset: 0x000D33E8
	// (set) Token: 0x06003C32 RID: 15410 RVA: 0x000D51F0 File Offset: 0x000D33F0
	public int cachedCasings
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<cachedCasings>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<cachedCasings>k__BackingField = value;
		}
	}

	// Token: 0x17000B4E RID: 2894
	// (get) Token: 0x06003C33 RID: 15411 RVA: 0x000D51FC File Offset: 0x000D33FC
	// (set) Token: 0x06003C34 RID: 15412 RVA: 0x000D5204 File Offset: 0x000D3404
	public float nextCasingsTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<nextCasingsTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<nextCasingsTime>k__BackingField = value;
		}
	}

	// Token: 0x17000B4F RID: 2895
	// (get) Token: 0x06003C35 RID: 15413 RVA: 0x000D5210 File Offset: 0x000D3410
	// (set) Token: 0x06003C36 RID: 15414 RVA: 0x000D5218 File Offset: 0x000D3418
	public int clipAmmo
	{
		get
		{
			return base.uses;
		}
		set
		{
			base.SetUses(value);
		}
	}

	// Token: 0x17000B50 RID: 2896
	// (get) Token: 0x06003C37 RID: 15415 RVA: 0x000D5224 File Offset: 0x000D3424
	public override bool canPrimaryAttack
	{
		get
		{
			return base.canPrimaryAttack && this.clipAmmo > 0;
		}
	}

	// Token: 0x17000B51 RID: 2897
	// (get) Token: 0x06003C38 RID: 15416 RVA: 0x000D5240 File Offset: 0x000D3440
	public override bool canReload
	{
		get
		{
			if (base.nextPrimaryAttackTime <= global::UnityEngine.Time.time && this.clipAmmo < this.datablock.maxClipAmmo)
			{
				global::IInventoryItem inventoryItem = base.inventory.FindItem(this.datablock.ammoType);
				if (inventoryItem != null && inventoryItem.uses > 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x06003C39 RID: 15417 RVA: 0x000D52AC File Offset: 0x000D34AC
	protected override bool CanAim()
	{
		return !this.IsReloading() && base.CanAim() && global::UnityEngine.Time.time > this.nextAimTime;
	}

	// Token: 0x06003C3A RID: 15418 RVA: 0x000D52E0 File Offset: 0x000D34E0
	public virtual bool IsReloading()
	{
		return this.reloadStartTime != -1f && global::UnityEngine.Time.time < this.reloadStartTime + this.datablock.reloadDuration;
	}

	// Token: 0x06003C3B RID: 15419 RVA: 0x000D5314 File Offset: 0x000D3514
	public override void Reload(ref global::HumanController.InputSample sample)
	{
		T datablock = this.datablock;
		datablock.Local_Reload(base.viewModelInstance, base.itemRepresentation, this.iface as global::IBulletWeaponItem, ref sample);
		this.ActualReload();
	}

	// Token: 0x06003C3C RID: 15420 RVA: 0x000D5354 File Offset: 0x000D3554
	public virtual void CacheReloads()
	{
		this.cachedNumReloads = 0;
	}

	// Token: 0x17000B52 RID: 2898
	// (get) Token: 0x06003C3D RID: 15421 RVA: 0x000D5360 File Offset: 0x000D3560
	public override int possibleReloadCount
	{
		get
		{
			return this.cachedNumReloads;
		}
	}

	// Token: 0x06003C3E RID: 15422 RVA: 0x000D5368 File Offset: 0x000D3568
	public virtual void ActualReload_COD()
	{
		this.reloadStartTime = global::UnityEngine.Time.time;
		base.nextPrimaryAttackTime = global::UnityEngine.Time.time + this.datablock.reloadDuration;
		global::Inventory inventory = base.inventory;
		int i = base.uses;
		int maxClipAmmo = this.datablock.maxClipAmmo;
		if (i == maxClipAmmo)
		{
			return;
		}
		int num = maxClipAmmo - i;
		int num2 = 0;
		while (i < maxClipAmmo)
		{
			global::IInventoryItem inventoryItem = inventory.FindItem(this.datablock.ammoType);
			if (inventoryItem == null)
			{
				break;
			}
			int num3 = num;
			if (inventoryItem.Consume(ref num))
			{
				inventory.RemoveItem(inventoryItem.slot);
			}
			num2 += num3 - num;
			if (num == 0)
			{
				break;
			}
		}
		if (num2 > 0)
		{
			base.AddUses(num2);
		}
	}

	// Token: 0x06003C3F RID: 15423 RVA: 0x000D5440 File Offset: 0x000D3640
	public virtual void ActualReload()
	{
		this.ActualReload_COD();
	}

	// Token: 0x06003C40 RID: 15424 RVA: 0x000D5448 File Offset: 0x000D3648
	protected override bool CanSetActivate(bool value)
	{
		return base.CanSetActivate(value) && (value || base.nextPrimaryAttackTime <= global::UnityEngine.Time.time);
	}

	// Token: 0x06003C41 RID: 15425 RVA: 0x000D5480 File Offset: 0x000D3680
	public override void ServerFrame()
	{
		base.ServerFrame();
		if (this.cachedCasings > 0 && global::UnityEngine.Time.time >= this.nextCasingsTime)
		{
			global::Inventory inventory = base.inventory;
			inventory.AddItemAmount(this.datablock.ammoType.spentCasingType, this.cachedCasings);
			this.cachedCasings = 0;
			this.nextCasingsTime = global::UnityEngine.Time.time + 5f;
		}
	}

	// Token: 0x06003C42 RID: 15426 RVA: 0x000D54F0 File Offset: 0x000D36F0
	public override void PrimaryAttack(ref global::HumanController.InputSample sample)
	{
		base.nextPrimaryAttackTime = global::UnityEngine.Time.time + this.datablock.fireRate;
		if (this.datablock.NoAimingAfterShot)
		{
			this.nextAimTime = global::UnityEngine.Time.time + this.datablock.fireRate;
		}
		global::ViewModel viewModelInstance = base.viewModelInstance;
		T datablock = this.datablock;
		datablock.Local_FireWeapon(viewModelInstance, base.itemRepresentation, this.iface as global::IBulletWeaponItem, ref sample);
	}

	// Token: 0x04001EA7 RID: 7847
	private float reloadStartTime = -1f;

	// Token: 0x04001EA8 RID: 7848
	private int cachedNumReloads;

	// Token: 0x04001EA9 RID: 7849
	public float nextAimTime;

	// Token: 0x04001EAA RID: 7850
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::MagazineDataBlock <clipType>k__BackingField;

	// Token: 0x04001EAB RID: 7851
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <cachedCasings>k__BackingField;

	// Token: 0x04001EAC RID: 7852
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <nextCasingsTime>k__BackingField;
}
