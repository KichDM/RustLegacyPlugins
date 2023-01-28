using System;
using UnityEngine;

// Token: 0x0200070F RID: 1807
public interface ITorchItem : global::IHeldItem, global::IInventoryItem, global::IThrowableItem, global::IWeaponItem
{
	// Token: 0x17000B9E RID: 2974
	// (get) Token: 0x06003D43 RID: 15683
	bool isLit { get; }

	// Token: 0x17000B9F RID: 2975
	// (get) Token: 0x06003D44 RID: 15684
	// (set) Token: 0x06003D45 RID: 15685
	float realThrowTime { get; set; }

	// Token: 0x17000BA0 RID: 2976
	// (get) Token: 0x06003D46 RID: 15686
	// (set) Token: 0x06003D47 RID: 15687
	float realIgniteTime { get; set; }

	// Token: 0x17000BA1 RID: 2977
	// (get) Token: 0x06003D48 RID: 15688
	// (set) Token: 0x06003D49 RID: 15689
	float forceSecondaryTime { get; set; }

	// Token: 0x17000BA2 RID: 2978
	// (get) Token: 0x06003D4A RID: 15690
	// (set) Token: 0x06003D4B RID: 15691
	global::UnityEngine.GameObject light { get; set; }

	// Token: 0x06003D4C RID: 15692
	void Ignite();

	// Token: 0x06003D4D RID: 15693
	void Extinguish();
}
