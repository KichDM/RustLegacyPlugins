using System;

// Token: 0x020006ED RID: 1773
public interface IHeldItem : global::IInventoryItem
{
	// Token: 0x17000B53 RID: 2899
	// (get) Token: 0x06003C51 RID: 15441
	global::ViewModel viewModelInstance { get; }

	// Token: 0x17000B54 RID: 2900
	// (get) Token: 0x06003C52 RID: 15442
	// (set) Token: 0x06003C53 RID: 15443
	global::ItemRepresentation itemRepresentation { get; set; }

	// Token: 0x17000B55 RID: 2901
	// (get) Token: 0x06003C54 RID: 15444
	bool canActivate { get; }

	// Token: 0x17000B56 RID: 2902
	// (get) Token: 0x06003C55 RID: 15445
	bool canDeactivate { get; }

	// Token: 0x17000B57 RID: 2903
	// (get) Token: 0x06003C56 RID: 15446
	global::ItemModFlags modFlags { get; }

	// Token: 0x17000B58 RID: 2904
	// (get) Token: 0x06003C57 RID: 15447
	global::ItemModDataBlock[] itemMods { get; }

	// Token: 0x17000B59 RID: 2905
	// (get) Token: 0x06003C58 RID: 15448
	int totalModSlots { get; }

	// Token: 0x17000B5A RID: 2906
	// (get) Token: 0x06003C59 RID: 15449
	int usedModSlots { get; }

	// Token: 0x17000B5B RID: 2907
	// (get) Token: 0x06003C5A RID: 15450
	int freeModSlots { get; }

	// Token: 0x06003C5B RID: 15451
	void SetTotalModSlotCount(int count);

	// Token: 0x06003C5C RID: 15452
	void SetUsedModSlotCount(int count);

	// Token: 0x06003C5D RID: 15453
	void AddMod(global::ItemModDataBlock mod);

	// Token: 0x06003C5E RID: 15454
	int FindMod(global::ItemModDataBlock mod);

	// Token: 0x06003C5F RID: 15455
	void OnActivate();

	// Token: 0x06003C60 RID: 15456
	void OnDeactivate();

	// Token: 0x06003C61 RID: 15457
	void ServerFrame();
}
