using System;

// Token: 0x020006D5 RID: 1749
public interface IBandageItem : global::IHeldItem, global::IInventoryItem
{
	// Token: 0x17000B33 RID: 2867
	// (get) Token: 0x06003BD6 RID: 15318
	// (set) Token: 0x06003BD7 RID: 15319
	float bandageStartTime { get; set; }

	// Token: 0x17000B34 RID: 2868
	// (get) Token: 0x06003BD8 RID: 15320
	// (set) Token: 0x06003BD9 RID: 15321
	bool lastFramePrimary { get; set; }

	// Token: 0x17000B35 RID: 2869
	// (get) Token: 0x06003BDA RID: 15322
	// (set) Token: 0x06003BDB RID: 15323
	float lastBandageTime { get; set; }
}
