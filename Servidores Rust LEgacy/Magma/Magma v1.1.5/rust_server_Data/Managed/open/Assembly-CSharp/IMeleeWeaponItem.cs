using System;

// Token: 0x02000701 RID: 1793
public interface IMeleeWeaponItem : global::IHeldItem, global::IInventoryItem, global::IWeaponItem
{
	// Token: 0x17000B8D RID: 2957
	// (get) Token: 0x06003D00 RID: 15616
	// (set) Token: 0x06003D01 RID: 15617
	float queuedSwingAttackTime { get; set; }

	// Token: 0x06003D02 RID: 15618
	void QueueMidSwing(float time);

	// Token: 0x17000B8E RID: 2958
	// (get) Token: 0x06003D03 RID: 15619
	// (set) Token: 0x06003D04 RID: 15620
	float queuedSwingSoundTime { get; set; }

	// Token: 0x06003D05 RID: 15621
	void QueueSwingSound(float time);
}
