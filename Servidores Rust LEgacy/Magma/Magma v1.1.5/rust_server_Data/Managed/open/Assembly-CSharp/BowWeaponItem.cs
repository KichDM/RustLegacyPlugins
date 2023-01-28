using System;
using UnityEngine;

// Token: 0x020006E0 RID: 1760
public abstract class BowWeaponItem<T> : global::WeaponItem<T> where T : global::BowWeaponDataBlock
{
	// Token: 0x06003C0A RID: 15370 RVA: 0x000D4F6C File Offset: 0x000D316C
	protected BowWeaponItem(T db) : base(db)
	{
	}

	// Token: 0x17000B42 RID: 2882
	// (get) Token: 0x06003C0B RID: 15371 RVA: 0x000D4F80 File Offset: 0x000D3180
	public override bool canPrimaryAttack
	{
		get
		{
			return global::UnityEngine.Time.time >= base.nextPrimaryAttackTime;
		}
	}

	// Token: 0x17000B43 RID: 2883
	// (get) Token: 0x06003C0C RID: 15372 RVA: 0x000D4F94 File Offset: 0x000D3194
	public override bool canReload
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06003C0D RID: 15373 RVA: 0x000D4F98 File Offset: 0x000D3198
	protected override bool CanAim()
	{
		return !this.IsReloading() && base.CanAim();
	}

	// Token: 0x06003C0E RID: 15374 RVA: 0x000D4FB0 File Offset: 0x000D31B0
	public virtual bool IsReloading()
	{
		return false;
	}

	// Token: 0x17000B44 RID: 2884
	// (get) Token: 0x06003C0F RID: 15375 RVA: 0x000D4FB4 File Offset: 0x000D31B4
	// (set) Token: 0x06003C10 RID: 15376 RVA: 0x000D4FBC File Offset: 0x000D31BC
	public int currentArrowID
	{
		get
		{
			return this._currentArrowID;
		}
		set
		{
			this._currentArrowID = value;
		}
	}

	// Token: 0x17000B45 RID: 2885
	// (get) Token: 0x06003C11 RID: 15377 RVA: 0x000D4FC8 File Offset: 0x000D31C8
	// (set) Token: 0x06003C12 RID: 15378 RVA: 0x000D4FD0 File Offset: 0x000D31D0
	public bool arrowDrawn
	{
		get
		{
			return this._arrowDrawn;
		}
		set
		{
			this._arrowDrawn = value;
		}
	}

	// Token: 0x17000B46 RID: 2886
	// (get) Token: 0x06003C13 RID: 15379 RVA: 0x000D4FDC File Offset: 0x000D31DC
	// (set) Token: 0x06003C14 RID: 15380 RVA: 0x000D4FE4 File Offset: 0x000D31E4
	public bool tired
	{
		get
		{
			return this._tired;
		}
		set
		{
			this._tired = value;
		}
	}

	// Token: 0x17000B47 RID: 2887
	// (get) Token: 0x06003C15 RID: 15381 RVA: 0x000D4FF0 File Offset: 0x000D31F0
	// (set) Token: 0x06003C16 RID: 15382 RVA: 0x000D4FF8 File Offset: 0x000D31F8
	public float completeDrawTime
	{
		get
		{
			return this._completeDrawTime;
		}
		set
		{
			this._completeDrawTime = value;
		}
	}

	// Token: 0x06003C17 RID: 15383 RVA: 0x000D5004 File Offset: 0x000D3204
	public int GenerateArrowID()
	{
		return global::UnityEngine.Random.Range(1, 0xFFFF);
	}

	// Token: 0x06003C18 RID: 15384 RVA: 0x000D5014 File Offset: 0x000D3214
	public void ClearArrowID()
	{
		this.currentArrowID = 0;
	}

	// Token: 0x06003C19 RID: 15385 RVA: 0x000D5020 File Offset: 0x000D3220
	public bool IsArrowDrawn()
	{
		return this.arrowDrawn;
	}

	// Token: 0x06003C1A RID: 15386 RVA: 0x000D5028 File Offset: 0x000D3228
	public bool IsArrowDrawing()
	{
		return this.completeDrawTime != -1f;
	}

	// Token: 0x06003C1B RID: 15387 RVA: 0x000D503C File Offset: 0x000D323C
	public void MakeReadyIn(float delay)
	{
		base.nextPrimaryAttackTime = global::UnityEngine.Time.time + delay;
		this.tired = false;
		this.arrowDrawn = false;
		this.completeDrawTime = -1f;
	}

	// Token: 0x06003C1C RID: 15388 RVA: 0x000D5070 File Offset: 0x000D3270
	public bool IsArrowDrawingOrDrawn()
	{
		return this.IsArrowDrawn() || this.IsArrowDrawing();
	}

	// Token: 0x06003C1D RID: 15389 RVA: 0x000D5088 File Offset: 0x000D3288
	public bool AnyArrowInFlight()
	{
		return this.arrowsInFlight > 0;
	}

	// Token: 0x06003C1E RID: 15390 RVA: 0x000D5094 File Offset: 0x000D3294
	public void AddArrowInFlight()
	{
		this.arrowsInFlight++;
		this.lastArrowFiredTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06003C1F RID: 15391 RVA: 0x000D50B0 File Offset: 0x000D32B0
	public void RemoveArrowInFlight()
	{
		this.arrowsInFlight--;
		if (this.arrowsInFlight <= 0)
		{
			this.arrowsInFlight = 0;
		}
	}

	// Token: 0x06003C20 RID: 15392 RVA: 0x000D50D4 File Offset: 0x000D32D4
	public void ClearFlightArrows()
	{
		this.arrowsInFlight = 0;
	}

	// Token: 0x06003C21 RID: 15393 RVA: 0x000D50E0 File Offset: 0x000D32E0
	public override void ServerFrame()
	{
		base.ServerFrame();
		if (this.AnyArrowInFlight() && global::UnityEngine.Time.time > this.lastArrowFiredTime + 6f)
		{
			this.ClearFlightArrows();
		}
	}

	// Token: 0x06003C22 RID: 15394 RVA: 0x000D511C File Offset: 0x000D331C
	protected override void OnSetActive(bool isActive)
	{
		if (!isActive)
		{
			this.MakeReadyIn(2f);
		}
		else
		{
			this.ClearFlightArrows();
		}
		base.OnSetActive(isActive);
	}

	// Token: 0x06003C23 RID: 15395 RVA: 0x000D5144 File Offset: 0x000D3344
	protected override bool CanSetActivate(bool value)
	{
		return (value || !this.AnyArrowInFlight()) && base.CanSetActivate(value) && (value || base.nextPrimaryAttackTime <= global::UnityEngine.Time.time);
	}

	// Token: 0x06003C24 RID: 15396 RVA: 0x000D518C File Offset: 0x000D338C
	public global::ItemDataBlock GetDesiredArrow()
	{
		return this.datablock.defaultAmmo;
	}

	// Token: 0x06003C25 RID: 15397 RVA: 0x000D51A0 File Offset: 0x000D33A0
	public global::IInventoryItem FindAmmo()
	{
		return base.inventory.FindItem(this.GetDesiredArrow());
	}

	// Token: 0x04001EA1 RID: 7841
	private bool _arrowDrawn;

	// Token: 0x04001EA2 RID: 7842
	private bool _tired;

	// Token: 0x04001EA3 RID: 7843
	private float _completeDrawTime = -1f;

	// Token: 0x04001EA4 RID: 7844
	private int _currentArrowID;

	// Token: 0x04001EA5 RID: 7845
	private int arrowsInFlight;

	// Token: 0x04001EA6 RID: 7846
	private float lastArrowFiredTime;
}
