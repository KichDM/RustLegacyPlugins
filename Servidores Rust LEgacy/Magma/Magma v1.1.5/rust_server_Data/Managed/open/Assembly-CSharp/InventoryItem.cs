using System;
using System.Runtime.CompilerServices;
using InventoryExtensions;
using Rust;
using uLink;
using UnityEngine;

// Token: 0x020006F2 RID: 1778
public abstract class InventoryItem
{
	// Token: 0x06003CAE RID: 15534 RVA: 0x000D5DD8 File Offset: 0x000D3FD8
	internal InventoryItem(global::ItemDataBlock datablock)
	{
		this.maxUses = datablock._maxUses;
		this.datablockUniqueID = datablock.uniqueID;
		this.iface = (this as global::IInventoryItem);
	}

	// Token: 0x17000B77 RID: 2935
	// (get) Token: 0x06003CAF RID: 15535 RVA: 0x000D5E10 File Offset: 0x000D4010
	// (set) Token: 0x06003CB0 RID: 15536 RVA: 0x000D5E18 File Offset: 0x000D4018
	public float maxcondition
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<maxcondition>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<maxcondition>k__BackingField = value;
		}
	}

	// Token: 0x17000B78 RID: 2936
	// (get) Token: 0x06003CB1 RID: 15537 RVA: 0x000D5E24 File Offset: 0x000D4024
	// (set) Token: 0x06003CB2 RID: 15538 RVA: 0x000D5E2C File Offset: 0x000D402C
	public float condition
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<condition>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<condition>k__BackingField = value;
		}
	}

	// Token: 0x17000B79 RID: 2937
	// (get) Token: 0x06003CB3 RID: 15539 RVA: 0x000D5E38 File Offset: 0x000D4038
	// (set) Token: 0x06003CB4 RID: 15540 RVA: 0x000D5E40 File Offset: 0x000D4040
	public int slot
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<slot>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<slot>k__BackingField = value;
		}
	}

	// Token: 0x17000B7A RID: 2938
	// (get) Token: 0x06003CB5 RID: 15541 RVA: 0x000D5E4C File Offset: 0x000D404C
	// (set) Token: 0x06003CB6 RID: 15542 RVA: 0x000D5E54 File Offset: 0x000D4054
	public int uses
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<uses>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<uses>k__BackingField = value;
		}
	}

	// Token: 0x17000B7B RID: 2939
	// (get) Token: 0x06003CB7 RID: 15543 RVA: 0x000D5E60 File Offset: 0x000D4060
	// (set) Token: 0x06003CB8 RID: 15544 RVA: 0x000D5E68 File Offset: 0x000D4068
	public global::Inventory inventory
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<inventory>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<inventory>k__BackingField = value;
		}
	}

	// Token: 0x17000B7C RID: 2940
	// (get) Token: 0x06003CB9 RID: 15545 RVA: 0x000D5E74 File Offset: 0x000D4074
	public bool dirty
	{
		get
		{
			return this.inventory && this.inventory.IsSlotDirty(this.slot);
		}
	}

	// Token: 0x17000B7D RID: 2941
	// (get) Token: 0x06003CBA RID: 15546 RVA: 0x000D5EA8 File Offset: 0x000D40A8
	// (set) Token: 0x06003CBB RID: 15547 RVA: 0x000D5EB0 File Offset: 0x000D40B0
	public float lastUseTime
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<lastUseTime>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<lastUseTime>k__BackingField = value;
		}
	}

	// Token: 0x17000B7E RID: 2942
	// (get) Token: 0x06003CBC RID: 15548
	public abstract string toolTip { get; }

	// Token: 0x17000B7F RID: 2943
	// (get) Token: 0x06003CBD RID: 15549 RVA: 0x000D5EBC File Offset: 0x000D40BC
	public bool isInLocalInventory
	{
		get
		{
			global::Inventory inventory = this.inventory;
			global::Character character;
			return inventory && (character = (inventory.idMain as global::Character)) && character.localPlayerControlled;
		}
	}

	// Token: 0x17000B80 RID: 2944
	// (get) Token: 0x06003CBE RID: 15550 RVA: 0x000D5EFC File Offset: 0x000D40FC
	public global::IDMain idMain
	{
		get
		{
			global::Inventory inventory = this.inventory;
			return (!inventory) ? null : inventory.idMain;
		}
	}

	// Token: 0x17000B81 RID: 2945
	// (get) Token: 0x06003CBF RID: 15551 RVA: 0x000D5F28 File Offset: 0x000D4128
	public global::Character character
	{
		get
		{
			global::Inventory inventory = this.inventory;
			return (!inventory) ? null : (inventory.idMain as global::Character);
		}
	}

	// Token: 0x17000B82 RID: 2946
	// (get) Token: 0x06003CC0 RID: 15552 RVA: 0x000D5F58 File Offset: 0x000D4158
	public global::Controller controller
	{
		get
		{
			global::Inventory inventory = this.inventory;
			global::Character character;
			return (!inventory || !(character = (inventory.idMain as global::Character))) ? null : character.controller;
		}
	}

	// Token: 0x17000B83 RID: 2947
	// (get) Token: 0x06003CC1 RID: 15553 RVA: 0x000D5F9C File Offset: 0x000D419C
	public global::Controllable controllable
	{
		get
		{
			global::Inventory inventory = this.inventory;
			global::Character character;
			return (!inventory || !(character = (inventory.idMain as global::Character))) ? null : character.controllable;
		}
	}

	// Token: 0x17000B84 RID: 2948
	// (get) Token: 0x06003CC2 RID: 15554 RVA: 0x000D5FE0 File Offset: 0x000D41E0
	public bool active
	{
		get
		{
			global::Inventory inventory = this.inventory;
			return inventory && inventory.activeItem == this;
		}
	}

	// Token: 0x06003CC3 RID: 15555 RVA: 0x000D600C File Offset: 0x000D420C
	public int AddUses(int count)
	{
		int uses;
		if (count <= 0 || (uses = this.uses) == this.maxUses)
		{
			return 0;
		}
		int uses2;
		if ((uses2 = uses + count) >= this.maxUses)
		{
			this.uses = this.maxUses;
			this.MarkDirty();
			return this.maxUses - uses;
		}
		this.uses = uses2;
		this.MarkDirty();
		return count;
	}

	// Token: 0x06003CC4 RID: 15556 RVA: 0x000D6070 File Offset: 0x000D4270
	public void SetUses(int count)
	{
		int uses = this.uses;
		if (count < 0 || count > this.maxUses)
		{
			count = this.maxUses;
		}
		if (count != uses)
		{
			this.uses = count;
			this.MarkDirty();
		}
	}

	// Token: 0x06003CC5 RID: 15557 RVA: 0x000D60B4 File Offset: 0x000D42B4
	public bool Consume(ref int numWant)
	{
		int uses = this.uses;
		if (uses == 0)
		{
			return true;
		}
		if (numWant == 0)
		{
			return false;
		}
		if (uses <= numWant)
		{
			numWant -= uses;
			this.uses = 0;
			this.MarkDirty();
			return true;
		}
		this.uses = uses - numWant;
		numWant = 0;
		this.MarkDirty();
		return false;
	}

	// Token: 0x06003CC6 RID: 15558 RVA: 0x000D610C File Offset: 0x000D430C
	public void SetCondition(float newcondition)
	{
		float condition = this.condition;
		this.condition = global::UnityEngine.Mathf.Clamp(newcondition, 0f, this.maxcondition);
		this.ConditionChanged(condition);
		this.MarkDirty();
	}

	// Token: 0x06003CC7 RID: 15559 RVA: 0x000D6148 File Offset: 0x000D4348
	public void SetMaxCondition(float newmaxcondition)
	{
		float maxcondition = this.maxcondition;
		this.maxcondition = global::UnityEngine.Mathf.Clamp(newmaxcondition, 0.01f, 1f);
		this.MaxConditionChanged(maxcondition);
		this.MarkDirty();
	}

	// Token: 0x06003CC8 RID: 15560 RVA: 0x000D6180 File Offset: 0x000D4380
	public float GetConditionForBreak()
	{
		return 0f;
	}

	// Token: 0x06003CC9 RID: 15561 RVA: 0x000D6188 File Offset: 0x000D4388
	public virtual void ConditionChanged(float oldCondition)
	{
		if (this.maxcondition < 0.15f && this.condition < oldCondition)
		{
			float num = global::UnityEngine.Random.Range(0f, 1f);
			float num2 = (this.maxcondition > 0.05f) ? 0.5f : 0f;
			if (num > num2)
			{
				global::Rust.Notice.Popup(this.inventory.networkViewOwner, "", "Item completely destroyed.", 4f);
				this.inventory.RemoveItem(this);
			}
		}
	}

	// Token: 0x06003CCA RID: 15562 RVA: 0x000D6214 File Offset: 0x000D4414
	public virtual bool CanMoveToSlot(global::Inventory toinv, int toslot)
	{
		return true;
	}

	// Token: 0x06003CCB RID: 15563 RVA: 0x000D6218 File Offset: 0x000D4418
	public virtual void MaxConditionChanged(float oldCondition)
	{
	}

	// Token: 0x06003CCC RID: 15564 RVA: 0x000D621C File Offset: 0x000D441C
	public virtual string GetConditionString()
	{
		if (!this.datablock.doesLoseCondition)
		{
			return string.Empty;
		}
		if (this.condition > 1f)
		{
			return "Artifact";
		}
		if (this.condition >= 0.8f)
		{
			return "Perfect";
		}
		if (this.condition >= 0.6f)
		{
			return "Quality";
		}
		if (this.condition >= 0.5f)
		{
			return string.Empty;
		}
		if (this.condition >= 0.4f)
		{
			return "Shoddy";
		}
		if ((double)this.condition > 0.0)
		{
			return "Bad";
		}
		if (this.IsBroken())
		{
			return "Broken";
		}
		return "ERROR";
	}

	// Token: 0x06003CCD RID: 15565 RVA: 0x000D62E0 File Offset: 0x000D44E0
	public float GetConditionPercent()
	{
		return this.condition / this.maxcondition;
	}

	// Token: 0x06003CCE RID: 15566 RVA: 0x000D62F0 File Offset: 0x000D44F0
	public bool IsDamaged()
	{
		return this.maxcondition - this.condition > 0.001f;
	}

	// Token: 0x06003CCF RID: 15567 RVA: 0x000D6308 File Offset: 0x000D4508
	public bool IsBroken()
	{
		return this.condition <= this.GetConditionForBreak();
	}

	// Token: 0x06003CD0 RID: 15568 RVA: 0x000D631C File Offset: 0x000D451C
	public void BreakIntoPieces()
	{
	}

	// Token: 0x06003CD1 RID: 15569 RVA: 0x000D6320 File Offset: 0x000D4520
	public bool TryConditionLoss(float probability, float percentLoss)
	{
		if (!this.datablock.doesLoseCondition)
		{
			return false;
		}
		float num = global::UnityEngine.Random.Range(0f, 1f);
		if (probability >= num)
		{
			float condition = this.condition;
			this.SetCondition(this.condition - percentLoss * global::conditionloss.damagemultiplier);
			return true;
		}
		return false;
	}

	// Token: 0x17000B85 RID: 2949
	// (get) Token: 0x06003CD2 RID: 15570
	protected abstract global::ItemDataBlock __infrastructure_db { get; }

	// Token: 0x17000B86 RID: 2950
	// (get) Token: 0x06003CD3 RID: 15571 RVA: 0x000D6374 File Offset: 0x000D4574
	public global::ItemDataBlock datablock
	{
		get
		{
			return this.__infrastructure_db;
		}
	}

	// Token: 0x06003CD4 RID: 15572 RVA: 0x000D637C File Offset: 0x000D457C
	public bool MarkDirty()
	{
		global::Inventory inventory = this.inventory;
		return inventory && inventory.MarkSlotDirty(this.slot);
	}

	// Token: 0x06003CD5 RID: 15573
	protected abstract void OnBitStreamWrite(global::uLink.BitStream stream);

	// Token: 0x06003CD6 RID: 15574
	protected abstract void OnBitStreamRead(global::uLink.BitStream stream);

	// Token: 0x06003CD7 RID: 15575
	public abstract void OnBeltUse();

	// Token: 0x06003CD8 RID: 15576
	public abstract void OnMovedTo(global::Inventory inv, int slot);

	// Token: 0x06003CD9 RID: 15577 RVA: 0x000D63AC File Offset: 0x000D45AC
	public virtual void OnAddedTo(global::Inventory inv, int slot)
	{
		this.inventory = inv;
		this.slot = slot;
	}

	// Token: 0x06003CDA RID: 15578
	public abstract global::InventoryItem.MergeResult TryStack(global::IInventoryItem other);

	// Token: 0x06003CDB RID: 15579
	public abstract global::InventoryItem.MergeResult TryCombine(global::IInventoryItem other);

	// Token: 0x06003CDC RID: 15580
	public abstract global::InventoryItem.MenuItemResult OnMenuOption(global::InventoryItem.MenuItem option);

	// Token: 0x06003CDD RID: 15581
	public abstract void FireClientSideItemEvent(global::InventoryItem.ItemEvent itemEvent);

	// Token: 0x06003CDE RID: 15582 RVA: 0x000D63BC File Offset: 0x000D45BC
	public void Serialize(global::uLink.BitStream stream)
	{
		this.OnBitStreamWrite(stream);
	}

	// Token: 0x06003CDF RID: 15583 RVA: 0x000D63C8 File Offset: 0x000D45C8
	public void Deserialize(global::uLink.BitStream stream)
	{
		this.OnBitStreamRead(stream);
	}

	// Token: 0x06003CE0 RID: 15584 RVA: 0x000D63D4 File Offset: 0x000D45D4
	protected static void SerializeSharedProperties(global::uLink.BitStream stream, global::InventoryItem item, global::ItemDataBlock db)
	{
		stream.WriteInvInt(item.uses);
		if (item.datablock.DoesLoseCondition())
		{
			stream.WriteSingle(item.condition);
			stream.WriteSingle(item.maxcondition);
		}
	}

	// Token: 0x06003CE1 RID: 15585 RVA: 0x000D6418 File Offset: 0x000D4618
	protected static void DeserializeSharedProperties(global::uLink.BitStream stream, global::InventoryItem item, global::ItemDataBlock db)
	{
		item.uses = stream.ReadInvInt();
		if (item.datablock.DoesLoseCondition())
		{
			item.condition = stream.ReadSingle();
			item.maxcondition = stream.ReadSingle();
		}
	}

	// Token: 0x04001EB4 RID: 7860
	public const int MAX_SUPPORTED_ITEM_MODS = 5;

	// Token: 0x04001EB5 RID: 7861
	public readonly global::IInventoryItem iface;

	// Token: 0x04001EB6 RID: 7862
	public readonly int maxUses;

	// Token: 0x04001EB7 RID: 7863
	public readonly int datablockUniqueID;

	// Token: 0x04001EB8 RID: 7864
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <maxcondition>k__BackingField;

	// Token: 0x04001EB9 RID: 7865
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <condition>k__BackingField;

	// Token: 0x04001EBA RID: 7866
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <slot>k__BackingField;

	// Token: 0x04001EBB RID: 7867
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <uses>k__BackingField;

	// Token: 0x04001EBC RID: 7868
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::Inventory <inventory>k__BackingField;

	// Token: 0x04001EBD RID: 7869
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <lastUseTime>k__BackingField;

	// Token: 0x020006F3 RID: 1779
	public enum MergeResult
	{
		// Token: 0x04001EBF RID: 7871
		Failed,
		// Token: 0x04001EC0 RID: 7872
		Merged,
		// Token: 0x04001EC1 RID: 7873
		Combined
	}

	// Token: 0x020006F4 RID: 1780
	public enum ItemEvent
	{
		// Token: 0x04001EC3 RID: 7875
		None,
		// Token: 0x04001EC4 RID: 7876
		Equipped,
		// Token: 0x04001EC5 RID: 7877
		UnEquipped,
		// Token: 0x04001EC6 RID: 7878
		Combined,
		// Token: 0x04001EC7 RID: 7879
		Used
	}

	// Token: 0x020006F5 RID: 1781
	public enum MenuItem : byte
	{
		// Token: 0x04001EC9 RID: 7881
		Info = 1,
		// Token: 0x04001ECA RID: 7882
		Status,
		// Token: 0x04001ECB RID: 7883
		Use,
		// Token: 0x04001ECC RID: 7884
		Study,
		// Token: 0x04001ECD RID: 7885
		Split,
		// Token: 0x04001ECE RID: 7886
		Eat,
		// Token: 0x04001ECF RID: 7887
		Drink,
		// Token: 0x04001ED0 RID: 7888
		Consume,
		// Token: 0x04001ED1 RID: 7889
		Unload
	}

	// Token: 0x020006F6 RID: 1782
	public enum MenuItemResult : byte
	{
		// Token: 0x04001ED3 RID: 7891
		DoneOnServer = 1,
		// Token: 0x04001ED4 RID: 7892
		DoneOnServerNotYetClient,
		// Token: 0x04001ED5 RID: 7893
		DoneOnClient,
		// Token: 0x04001ED6 RID: 7894
		Complete,
		// Token: 0x04001ED7 RID: 7895
		Unhandled = 0
	}
}
