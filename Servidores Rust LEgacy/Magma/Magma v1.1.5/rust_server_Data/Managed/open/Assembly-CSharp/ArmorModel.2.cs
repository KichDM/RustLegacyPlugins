using System;
using UnityEngine;

// Token: 0x0200061E RID: 1566
public abstract class ArmorModel<TArmorModel> : global::ArmorModel where TArmorModel : global::ArmorModel<TArmorModel>, new()
{
	// Token: 0x060031C6 RID: 12742 RVA: 0x000BF130 File Offset: 0x000BD330
	internal ArmorModel(global::ArmorModelSlot slot) : base(slot)
	{
	}

	// Token: 0x17000A5F RID: 2655
	// (get) Token: 0x060031C7 RID: 12743 RVA: 0x000BF13C File Offset: 0x000BD33C
	public new TArmorModel censoredModel
	{
		get
		{
			return this.censored;
		}
	}

	// Token: 0x17000A60 RID: 2656
	// (get) Token: 0x060031C8 RID: 12744 RVA: 0x000BF144 File Offset: 0x000BD344
	public new bool hasCensoredModel
	{
		get
		{
			return this.censored;
		}
	}

	// Token: 0x17000A61 RID: 2657
	// (get) Token: 0x060031C9 RID: 12745 RVA: 0x000BF158 File Offset: 0x000BD358
	protected sealed override global::ArmorModel _censored
	{
		get
		{
			return this.censored;
		}
	}

	// Token: 0x04001BD5 RID: 7125
	[global::UnityEngine.SerializeField]
	protected TArmorModel censored;
}
