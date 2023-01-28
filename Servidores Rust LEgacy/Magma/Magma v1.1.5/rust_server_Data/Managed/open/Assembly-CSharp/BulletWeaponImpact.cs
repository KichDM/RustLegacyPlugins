using System;
using UnityEngine;

// Token: 0x02000684 RID: 1668
public class BulletWeaponImpact : global::WeaponImpact
{
	// Token: 0x0600364B RID: 13899 RVA: 0x000CBC20 File Offset: 0x000C9E20
	public BulletWeaponImpact(global::BulletWeaponDataBlock dataBlock, global::IBulletWeaponItem item, global::ItemRepresentation itemRep, global::UnityEngine.Transform hitTransform, global::UnityEngine.Vector3 localHitPoint, global::UnityEngine.Vector3 localHitDirection) : base(dataBlock, item, itemRep)
	{
		this.hitTransform = hitTransform;
		this.hitPoint = localHitPoint;
		this.hitDirection = localHitDirection;
	}

	// Token: 0x0600364C RID: 13900 RVA: 0x000CBC44 File Offset: 0x000C9E44
	public BulletWeaponImpact(global::BulletWeaponDataBlock dataBlock, global::IBulletWeaponItem item, global::ItemRepresentation itemRep, global::UnityEngine.Vector3 worldHitPoint, global::UnityEngine.Vector3 worldHitDirection) : this(dataBlock, item, itemRep, null, worldHitPoint, worldHitDirection)
	{
	}

	// Token: 0x17000AF0 RID: 2800
	// (get) Token: 0x0600364D RID: 13901 RVA: 0x000CBC54 File Offset: 0x000C9E54
	public new global::BulletWeaponDataBlock dataBlock
	{
		get
		{
			return (global::BulletWeaponDataBlock)this.dataBlock;
		}
	}

	// Token: 0x17000AF1 RID: 2801
	// (get) Token: 0x0600364E RID: 13902 RVA: 0x000CBC64 File Offset: 0x000C9E64
	public new global::IBulletWeaponItem item
	{
		get
		{
			return this.item as global::IBulletWeaponItem;
		}
	}

	// Token: 0x17000AF2 RID: 2802
	// (get) Token: 0x0600364F RID: 13903 RVA: 0x000CBC74 File Offset: 0x000C9E74
	public global::UnityEngine.Vector3 localPoint
	{
		get
		{
			return (!this.hitTransform) ? default(global::UnityEngine.Vector3) : this.hitPoint;
		}
	}

	// Token: 0x17000AF3 RID: 2803
	// (get) Token: 0x06003650 RID: 13904 RVA: 0x000CBCA8 File Offset: 0x000C9EA8
	public global::UnityEngine.Vector3 worldPoint
	{
		get
		{
			return (!this.hitTransform) ? this.hitPoint : this.hitTransform.TransformPoint(this.hitPoint);
		}
	}

	// Token: 0x17000AF4 RID: 2804
	// (get) Token: 0x06003651 RID: 13905 RVA: 0x000CBCE4 File Offset: 0x000C9EE4
	public global::UnityEngine.Vector3 localDirection
	{
		get
		{
			return (!this.hitTransform) ? global::UnityEngine.Vector3.forward : this.hitDirection;
		}
	}

	// Token: 0x17000AF5 RID: 2805
	// (get) Token: 0x06003652 RID: 13906 RVA: 0x000CBD14 File Offset: 0x000C9F14
	public global::UnityEngine.Vector3 worldDirection
	{
		get
		{
			return (!this.hitTransform) ? this.hitDirection : this.hitTransform.TransformDirection(this.hitDirection);
		}
	}

	// Token: 0x04001D7A RID: 7546
	public readonly global::UnityEngine.Transform hitTransform;

	// Token: 0x04001D7B RID: 7547
	private global::UnityEngine.Vector3 hitPoint;

	// Token: 0x04001D7C RID: 7548
	private global::UnityEngine.Vector3 hitDirection;
}
