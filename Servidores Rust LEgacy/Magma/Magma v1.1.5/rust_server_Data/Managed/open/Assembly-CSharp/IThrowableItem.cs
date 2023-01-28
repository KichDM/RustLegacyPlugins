using System;

// Token: 0x0200070B RID: 1803
public interface IThrowableItem : global::IHeldItem, global::IInventoryItem, global::IWeaponItem
{
	// Token: 0x06003D22 RID: 15650
	void BeginHoldingBack();

	// Token: 0x06003D23 RID: 15651
	void EndHoldingBack();

	// Token: 0x17000B92 RID: 2962
	// (get) Token: 0x06003D24 RID: 15652
	float heldThrowStrength { get; }

	// Token: 0x17000B93 RID: 2963
	// (get) Token: 0x06003D25 RID: 15653
	// (set) Token: 0x06003D26 RID: 15654
	float holdingStartTime { get; set; }

	// Token: 0x17000B94 RID: 2964
	// (get) Token: 0x06003D27 RID: 15655
	// (set) Token: 0x06003D28 RID: 15656
	bool holdingBack { get; set; }

	// Token: 0x17000B95 RID: 2965
	// (get) Token: 0x06003D29 RID: 15657
	// (set) Token: 0x06003D2A RID: 15658
	float minReleaseTime { get; set; }
}
