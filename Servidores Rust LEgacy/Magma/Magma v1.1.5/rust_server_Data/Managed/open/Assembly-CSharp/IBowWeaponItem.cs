using System;

// Token: 0x020006DF RID: 1759
public interface IBowWeaponItem : global::IHeldItem, global::IInventoryItem, global::IWeaponItem
{
	// Token: 0x17000B3E RID: 2878
	// (get) Token: 0x06003BFE RID: 15358
	// (set) Token: 0x06003BFF RID: 15359
	bool arrowDrawn { get; set; }

	// Token: 0x17000B3F RID: 2879
	// (get) Token: 0x06003C00 RID: 15360
	// (set) Token: 0x06003C01 RID: 15361
	bool tired { get; set; }

	// Token: 0x17000B40 RID: 2880
	// (get) Token: 0x06003C02 RID: 15362
	// (set) Token: 0x06003C03 RID: 15363
	float completeDrawTime { get; set; }

	// Token: 0x17000B41 RID: 2881
	// (get) Token: 0x06003C04 RID: 15364
	// (set) Token: 0x06003C05 RID: 15365
	int currentArrowID { get; set; }

	// Token: 0x06003C06 RID: 15366
	global::IInventoryItem FindAmmo();

	// Token: 0x06003C07 RID: 15367
	bool AnyArrowInFlight();

	// Token: 0x06003C08 RID: 15368
	void AddArrowInFlight();

	// Token: 0x06003C09 RID: 15369
	void RemoveArrowInFlight();
}
