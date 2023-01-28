using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
public class FPGrassDisplacementRadius : global::FPGrassDisplacementObject
{
	// Token: 0x06000273 RID: 627 RVA: 0x0000CE58 File Offset: 0x0000B058
	public FPGrassDisplacementRadius()
	{
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0000CE60 File Offset: 0x0000B060
	public override void Initialize()
	{
		this.startScale = this.myTransform.localScale;
		this.myTransform.localScale = global::UnityEngine.Vector3.zero;
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0000CE84 File Offset: 0x0000B084
	public override void UpdateDepression()
	{
		if (global::UnityEngine.Mathf.Approximately(this.currentDepressionPercent, this.targetDepressionPercent))
		{
			return;
		}
		float currentDepressionPercent = global::UnityEngine.Mathf.Lerp(this.currentDepressionPercent, this.targetDepressionPercent, global::UnityEngine.Time.deltaTime * 5f);
		this.currentDepressionPercent = currentDepressionPercent;
		this.myTransform.localScale = this.startScale * this.currentDepressionPercent;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x0000CEE8 File Offset: 0x0000B0E8
	public override void DetachAndDestroy()
	{
		base.transform.parent = null;
		base.SetOn(false);
		global::UnityEngine.Object.Destroy(base.gameObject, 1f);
	}

	// Token: 0x040001A0 RID: 416
	private global::UnityEngine.Vector3 startScale;
}
