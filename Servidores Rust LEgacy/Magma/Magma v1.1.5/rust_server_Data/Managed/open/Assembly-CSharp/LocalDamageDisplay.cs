using System;

// Token: 0x020005B8 RID: 1464
public class LocalDamageDisplay : global::IDLocalCharacterAddon
{
	// Token: 0x06003023 RID: 12323 RVA: 0x000B7718 File Offset: 0x000B5918
	public LocalDamageDisplay() : this(global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake)
	{
	}

	// Token: 0x06003024 RID: 12324 RVA: 0x000B7724 File Offset: 0x000B5924
	protected LocalDamageDisplay(global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags | global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake)
	{
	}

	// Token: 0x06003025 RID: 12325 RVA: 0x000B7730 File Offset: 0x000B5930
	protected override void OnAddonAwake()
	{
	}

	// Token: 0x040019DC RID: 6620
	protected const global::IDLocalCharacterAddon.AddonFlags kRequiredAddonFlags = global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake;
}
