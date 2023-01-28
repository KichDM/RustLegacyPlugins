using System;

// Token: 0x020007A1 RID: 1953
public class Ragdoll : global::Character
{
	// Token: 0x0600410D RID: 16653 RVA: 0x000E9964 File Offset: 0x000E7B64
	public Ragdoll() : this(0)
	{
	}

	// Token: 0x0600410E RID: 16654 RVA: 0x000E9970 File Offset: 0x000E7B70
	protected Ragdoll(global::IDFlags flags) : base(flags)
	{
	}

	// Token: 0x0600410F RID: 16655 RVA: 0x000E997C File Offset: 0x000E7B7C
	protected new void Awake()
	{
		base.LoadTraitMapNonNetworked();
		base.Awake();
	}

	// Token: 0x040021E4 RID: 8676
	[global::System.NonSerialized]
	public global::IDMain sourceMain;
}
