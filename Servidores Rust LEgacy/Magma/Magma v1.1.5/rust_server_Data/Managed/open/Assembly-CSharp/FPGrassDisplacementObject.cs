using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class FPGrassDisplacementObject : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600026B RID: 619 RVA: 0x0000CDF0 File Offset: 0x0000AFF0
	public FPGrassDisplacementObject()
	{
	}

	// Token: 0x0600026C RID: 620 RVA: 0x0000CE04 File Offset: 0x0000B004
	public void Awake()
	{
		this.myTransform = base.transform;
		this.Initialize();
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0000CE18 File Offset: 0x0000B018
	public virtual void Initialize()
	{
	}

	// Token: 0x0600026E RID: 622 RVA: 0x0000CE1C File Offset: 0x0000B01C
	public void SetDepressionAmount(float percent)
	{
		this.targetDepressionPercent = percent;
	}

	// Token: 0x0600026F RID: 623 RVA: 0x0000CE28 File Offset: 0x0000B028
	public void SetOn(bool on)
	{
		this.targetDepressionPercent = ((!on) ? 0f : 1f);
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0000CE48 File Offset: 0x0000B048
	public void Update()
	{
		this.UpdateDepression();
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0000CE50 File Offset: 0x0000B050
	public virtual void UpdateDepression()
	{
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0000CE54 File Offset: 0x0000B054
	public virtual void DetachAndDestroy()
	{
	}

	// Token: 0x0400019D RID: 413
	protected global::UnityEngine.Transform myTransform;

	// Token: 0x0400019E RID: 414
	protected float currentDepressionPercent;

	// Token: 0x0400019F RID: 415
	protected float targetDepressionPercent = 1f;
}
