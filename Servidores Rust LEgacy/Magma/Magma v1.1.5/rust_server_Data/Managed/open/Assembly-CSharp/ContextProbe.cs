using System;

// Token: 0x020000AD RID: 173
public sealed class ContextProbe : global::IDLocalCharacterAddon
{
	// Token: 0x0600036A RID: 874 RVA: 0x00010574 File Offset: 0x0000E774
	public ContextProbe() : this(global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake | global::IDLocalCharacterAddon.AddonFlags.FireOnWillRemoveAddon)
	{
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00010580 File Offset: 0x0000E780
	private ContextProbe(global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags)
	{
	}

	// Token: 0x04000309 RID: 777
	private const global::IDLocalCharacterAddon.AddonFlags ContextProbeAddonFlags = global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake | global::IDLocalCharacterAddon.AddonFlags.FireOnWillRemoveAddon;
}
