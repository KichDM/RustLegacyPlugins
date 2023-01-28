using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020006DA RID: 1754
public abstract class BasicTorchItem<T> : global::HeldItem<T> where T : global::BasicTorchItemDataBlock
{
	// Token: 0x06003BF0 RID: 15344 RVA: 0x000D4D98 File Offset: 0x000D2F98
	protected BasicTorchItem(T db) : base(db)
	{
	}

	// Token: 0x17000B3B RID: 2875
	// (get) Token: 0x06003BF1 RID: 15345 RVA: 0x000D4DAC File Offset: 0x000D2FAC
	// (set) Token: 0x06003BF2 RID: 15346 RVA: 0x000D4DB4 File Offset: 0x000D2FB4
	public bool isLit
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<isLit>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<isLit>k__BackingField = value;
		}
	}

	// Token: 0x06003BF3 RID: 15347 RVA: 0x000D4DC0 File Offset: 0x000D2FC0
	public void Ignite()
	{
		this.isLit = true;
	}

	// Token: 0x17000B3C RID: 2876
	// (get) Token: 0x06003BF4 RID: 15348 RVA: 0x000D4DCC File Offset: 0x000D2FCC
	// (set) Token: 0x06003BF5 RID: 15349 RVA: 0x000D4DD4 File Offset: 0x000D2FD4
	public global::UnityEngine.GameObject light
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<light>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<light>k__BackingField = value;
		}
	}

	// Token: 0x06003BF6 RID: 15350 RVA: 0x000D4DE0 File Offset: 0x000D2FE0
	public virtual void Extinguish()
	{
		this.isLit = false;
		if (this.light)
		{
			global::UnityEngine.Object.Destroy(this.light);
			this.light = null;
		}
	}

	// Token: 0x06003BF7 RID: 15351 RVA: 0x000D4E18 File Offset: 0x000D3018
	protected override void OnSetActive(bool isActive)
	{
		if (isActive)
		{
			this.lastTickTime = global::UnityEngine.Time.time;
			this.consumeAmount += 1f;
		}
		base.OnSetActive(isActive);
	}

	// Token: 0x06003BF8 RID: 15352 RVA: 0x000D4E50 File Offset: 0x000D3050
	public override void ServerFrame()
	{
		float num = global::UnityEngine.Time.time - this.lastTickTime;
		this.lastTickTime = global::UnityEngine.Time.time;
		this.consumeAmount += num;
		if (this.consumeAmount >= 1f)
		{
			int num2 = global::UnityEngine.Mathf.FloorToInt(this.consumeAmount);
			this.consumeAmount -= (float)num2;
			if (base.Consume(ref num2))
			{
				base.inventory.RemoveItem(base.slot);
			}
		}
	}

	// Token: 0x04001E9D RID: 7837
	private float lastTickTime = -1f;

	// Token: 0x04001E9E RID: 7838
	private float consumeAmount;

	// Token: 0x04001E9F RID: 7839
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <isLit>k__BackingField;

	// Token: 0x04001EA0 RID: 7840
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.GameObject <light>k__BackingField;
}
