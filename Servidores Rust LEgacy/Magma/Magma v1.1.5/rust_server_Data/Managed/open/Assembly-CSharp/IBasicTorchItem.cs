using System;
using UnityEngine;

// Token: 0x020006D9 RID: 1753
public interface IBasicTorchItem : global::IHeldItem, global::IInventoryItem
{
	// Token: 0x17000B39 RID: 2873
	// (get) Token: 0x06003BEA RID: 15338
	// (set) Token: 0x06003BEB RID: 15339
	bool isLit { get; set; }

	// Token: 0x06003BEC RID: 15340
	void Ignite();

	// Token: 0x06003BED RID: 15341
	void Extinguish();

	// Token: 0x17000B3A RID: 2874
	// (get) Token: 0x06003BEE RID: 15342
	// (set) Token: 0x06003BEF RID: 15343
	global::UnityEngine.GameObject light { get; set; }
}
