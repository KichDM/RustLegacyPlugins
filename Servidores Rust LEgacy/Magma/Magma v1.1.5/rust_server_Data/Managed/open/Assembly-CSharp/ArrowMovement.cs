using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
public class ArrowMovement : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000263 RID: 611 RVA: 0x0000CB5C File Offset: 0x0000AD5C
	public ArrowMovement()
	{
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0000CB9C File Offset: 0x0000AD9C
	private void Start()
	{
		this.spawnTime = global::UnityEngine.Time.time;
		this.lastUpdateTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06000265 RID: 613 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
	public void Init(float arrowSpeed, global::ItemRepresentation itemRep, global::IBowWeaponItem itemInstance, bool firedLocal)
	{
		this.speedPerSec = arrowSpeed;
		if (itemRep != null && itemInstance != null)
		{
			this._myBow = itemRep;
			this._myItemInstance = itemInstance;
		}
	}

	// Token: 0x04000191 RID: 401
	public bool impacted;

	// Token: 0x04000192 RID: 402
	public float speedPerSec = 80f;

	// Token: 0x04000193 RID: 403
	public float maxRange = 1000f;

	// Token: 0x04000194 RID: 404
	private float maxLifeTime = 4f;

	// Token: 0x04000195 RID: 405
	public float lastUpdateTime;

	// Token: 0x04000196 RID: 406
	public float spawnTime;

	// Token: 0x04000197 RID: 407
	private int layerMask = 0x183E1411;

	// Token: 0x04000198 RID: 408
	private float distance;

	// Token: 0x04000199 RID: 409
	public float dropDegreesPerSec = 5f;

	// Token: 0x0400019A RID: 410
	private bool reported;

	// Token: 0x0400019B RID: 411
	public global::ItemRepresentation _myBow;

	// Token: 0x0400019C RID: 412
	public global::IBowWeaponItem _myItemInstance;
}
