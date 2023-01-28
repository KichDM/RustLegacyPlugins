using System;
using RustProto;
using uLink;

// Token: 0x020006F1 RID: 1777
public interface IInventoryItem
{
	// Token: 0x17000B67 RID: 2919
	// (get) Token: 0x06003C88 RID: 15496
	global::ItemDataBlock datablock { get; }

	// Token: 0x17000B68 RID: 2920
	// (get) Token: 0x06003C89 RID: 15497
	int slot { get; }

	// Token: 0x17000B69 RID: 2921
	// (get) Token: 0x06003C8A RID: 15498
	float condition { get; }

	// Token: 0x17000B6A RID: 2922
	// (get) Token: 0x06003C8B RID: 15499
	float maxcondition { get; }

	// Token: 0x06003C8C RID: 15500
	bool IsDamaged();

	// Token: 0x06003C8D RID: 15501
	bool IsBroken();

	// Token: 0x06003C8E RID: 15502
	float GetConditionPercent();

	// Token: 0x17000B6B RID: 2923
	// (get) Token: 0x06003C8F RID: 15503
	int uses { get; }

	// Token: 0x17000B6C RID: 2924
	// (get) Token: 0x06003C90 RID: 15504
	global::Inventory inventory { get; }

	// Token: 0x17000B6D RID: 2925
	// (get) Token: 0x06003C91 RID: 15505
	bool dirty { get; }

	// Token: 0x17000B6E RID: 2926
	// (get) Token: 0x06003C92 RID: 15506
	// (set) Token: 0x06003C93 RID: 15507
	float lastUseTime { get; set; }

	// Token: 0x17000B6F RID: 2927
	// (get) Token: 0x06003C94 RID: 15508
	bool isInLocalInventory { get; }

	// Token: 0x17000B70 RID: 2928
	// (get) Token: 0x06003C95 RID: 15509
	global::IDMain idMain { get; }

	// Token: 0x17000B71 RID: 2929
	// (get) Token: 0x06003C96 RID: 15510
	global::Character character { get; }

	// Token: 0x17000B72 RID: 2930
	// (get) Token: 0x06003C97 RID: 15511
	global::Controller controller { get; }

	// Token: 0x17000B73 RID: 2931
	// (get) Token: 0x06003C98 RID: 15512
	global::Controllable controllable { get; }

	// Token: 0x17000B74 RID: 2932
	// (get) Token: 0x06003C99 RID: 15513
	bool active { get; }

	// Token: 0x17000B75 RID: 2933
	// (get) Token: 0x06003C9A RID: 15514
	string toolTip { get; }

	// Token: 0x06003C9B RID: 15515
	int AddUses(int count);

	// Token: 0x06003C9C RID: 15516
	void SetUses(int count);

	// Token: 0x06003C9D RID: 15517
	void SetCondition(float condition);

	// Token: 0x06003C9E RID: 15518
	void SetMaxCondition(float condition);

	// Token: 0x06003C9F RID: 15519
	bool Consume(ref int count);

	// Token: 0x06003CA0 RID: 15520
	bool TryConditionLoss(float probability, float percentLoss);

	// Token: 0x06003CA1 RID: 15521
	void Serialize(global::uLink.BitStream stream);

	// Token: 0x06003CA2 RID: 15522
	void Deserialize(global::uLink.BitStream stream);

	// Token: 0x06003CA3 RID: 15523
	void OnMovedTo(global::Inventory inv, int slot);

	// Token: 0x06003CA4 RID: 15524
	void OnAddedTo(global::Inventory inv, int slot);

	// Token: 0x06003CA5 RID: 15525
	global::InventoryItem.MenuItemResult OnMenuOption(global::InventoryItem.MenuItem option);

	// Token: 0x17000B76 RID: 2934
	// (get) Token: 0x06003CA6 RID: 15526
	bool doNotSave { get; }

	// Token: 0x06003CA7 RID: 15527
	bool MarkDirty();

	// Token: 0x06003CA8 RID: 15528
	void OnBeltUse();

	// Token: 0x06003CA9 RID: 15529
	global::InventoryItem.MergeResult TryStack(global::IInventoryItem other);

	// Token: 0x06003CAA RID: 15530
	global::InventoryItem.MergeResult TryCombine(global::IInventoryItem other);

	// Token: 0x06003CAB RID: 15531
	void FireClientSideItemEvent(global::InventoryItem.ItemEvent itemEvent);

	// Token: 0x06003CAC RID: 15532
	bool Save(ref global::RustProto.Item.Builder proto);

	// Token: 0x06003CAD RID: 15533
	bool Load(ref global::RustProto.Item item);
}
