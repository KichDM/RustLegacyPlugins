using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000710 RID: 1808
public abstract class TorchItem<T> : global::ThrowableItem<T> where T : global::TorchItemDataBlock
{
	// Token: 0x06003D4E RID: 15694 RVA: 0x000D7914 File Offset: 0x000D5B14
	protected TorchItem(T db) : base(db)
	{
	}

	// Token: 0x17000BA3 RID: 2979
	// (get) Token: 0x06003D4F RID: 15695 RVA: 0x000D7920 File Offset: 0x000D5B20
	// (set) Token: 0x06003D50 RID: 15696 RVA: 0x000D7928 File Offset: 0x000D5B28
	public bool isLit
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<isLit>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected set
		{
			this.<isLit>k__BackingField = value;
		}
	}

	// Token: 0x17000BA4 RID: 2980
	// (get) Token: 0x06003D51 RID: 15697 RVA: 0x000D7934 File Offset: 0x000D5B34
	// (set) Token: 0x06003D52 RID: 15698 RVA: 0x000D793C File Offset: 0x000D5B3C
	public float realThrowTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<realThrowTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<realThrowTime>k__BackingField = value;
		}
	}

	// Token: 0x17000BA5 RID: 2981
	// (get) Token: 0x06003D53 RID: 15699 RVA: 0x000D7948 File Offset: 0x000D5B48
	// (set) Token: 0x06003D54 RID: 15700 RVA: 0x000D7950 File Offset: 0x000D5B50
	public float realIgniteTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<realIgniteTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<realIgniteTime>k__BackingField = value;
		}
	}

	// Token: 0x17000BA6 RID: 2982
	// (get) Token: 0x06003D55 RID: 15701 RVA: 0x000D795C File Offset: 0x000D5B5C
	// (set) Token: 0x06003D56 RID: 15702 RVA: 0x000D7964 File Offset: 0x000D5B64
	public float forceSecondaryTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<forceSecondaryTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<forceSecondaryTime>k__BackingField = value;
		}
	}

	// Token: 0x17000BA7 RID: 2983
	// (get) Token: 0x06003D57 RID: 15703 RVA: 0x000D7970 File Offset: 0x000D5B70
	// (set) Token: 0x06003D58 RID: 15704 RVA: 0x000D7978 File Offset: 0x000D5B78
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

	// Token: 0x06003D59 RID: 15705 RVA: 0x000D7984 File Offset: 0x000D5B84
	public bool IsIgnited()
	{
		return this.isLit;
	}

	// Token: 0x06003D5A RID: 15706 RVA: 0x000D798C File Offset: 0x000D5B8C
	public void Ignite()
	{
		this.isLit = true;
	}

	// Token: 0x06003D5B RID: 15707 RVA: 0x000D7998 File Offset: 0x000D5B98
	protected override void OnSetActive(bool isActive)
	{
		base.OnSetActive(isActive);
		if (!isActive)
		{
			this.OnHolstered();
		}
	}

	// Token: 0x06003D5C RID: 15708 RVA: 0x000D79B0 File Offset: 0x000D5BB0
	public virtual void OnHolstered()
	{
		if (this.isLit)
		{
			this.Extinguish();
			this.realThrowTime = 0f;
			this.realIgniteTime = 0f;
			this.forceSecondaryTime = 0f;
			int num = 1;
			if (base.Consume(ref num))
			{
				base.inventory.RemoveItem(base.slot);
			}
		}
	}

	// Token: 0x06003D5D RID: 15709 RVA: 0x000D7A10 File Offset: 0x000D5C10
	public void Extinguish()
	{
		this.isLit = false;
		if (this.light)
		{
			global::UnityEngine.Object.Destroy(this.light);
			this.light = null;
		}
	}

	// Token: 0x04001EF1 RID: 7921
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <isLit>k__BackingField;

	// Token: 0x04001EF2 RID: 7922
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <realThrowTime>k__BackingField;

	// Token: 0x04001EF3 RID: 7923
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <realIgniteTime>k__BackingField;

	// Token: 0x04001EF4 RID: 7924
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <forceSecondaryTime>k__BackingField;

	// Token: 0x04001EF5 RID: 7925
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.GameObject <light>k__BackingField;
}
