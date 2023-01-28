using System;

// Token: 0x0200062C RID: 1580
[global::System.AttributeUsage(global::System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ArmorModelSlotClassAttribute : global::System.Attribute
{
	// Token: 0x0600323D RID: 12861 RVA: 0x000C0614 File Offset: 0x000BE814
	public ArmorModelSlotClassAttribute(global::ArmorModelSlot slot)
	{
		this.ArmorModelSlot = slot;
	}

	// Token: 0x04001BF6 RID: 7158
	public readonly global::ArmorModelSlot ArmorModelSlot;
}
