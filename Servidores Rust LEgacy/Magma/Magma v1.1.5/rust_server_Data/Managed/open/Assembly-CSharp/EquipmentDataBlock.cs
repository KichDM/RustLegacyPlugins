using System;
using RustProto;
using uLink;

// Token: 0x02000690 RID: 1680
public class EquipmentDataBlock : global::ItemDataBlock
{
	// Token: 0x060036E9 RID: 14057 RVA: 0x000CD170 File Offset: 0x000CB370
	public EquipmentDataBlock()
	{
	}

	// Token: 0x060036EA RID: 14058 RVA: 0x000CD178 File Offset: 0x000CB378
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::EquipmentDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060036EB RID: 14059 RVA: 0x000CD180 File Offset: 0x000CB380
	public virtual void OnEquipped(global::IEquipmentItem item)
	{
	}

	// Token: 0x060036EC RID: 14060 RVA: 0x000CD184 File Offset: 0x000CB384
	public virtual void OnUnEquipped(global::IEquipmentItem item)
	{
	}

	// Token: 0x02000691 RID: 1681
	private sealed class ITEM_TYPE : global::EquipmentItem<global::EquipmentDataBlock>, global::IEquipmentItem, global::IInventoryItem
	{
		// Token: 0x060036ED RID: 14061 RVA: 0x000CD188 File Offset: 0x000CB388
		public ITEM_TYPE(global::EquipmentDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x060036EE RID: 14062 RVA: 0x000CD194 File Offset: 0x000CB394
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060036EF RID: 14063 RVA: 0x000CD19C File Offset: 0x000CB39C
		void OnUnEquipped()
		{
			base.OnUnEquipped();
		}

		// Token: 0x060036F0 RID: 14064 RVA: 0x000CD1A4 File Offset: 0x000CB3A4
		void OnEquipped()
		{
			base.OnEquipped();
		}

		// Token: 0x060036F1 RID: 14065 RVA: 0x000CD1AC File Offset: 0x000CB3AC
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060036F2 RID: 14066 RVA: 0x000CD1B4 File Offset: 0x000CB3B4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060036F3 RID: 14067 RVA: 0x000CD1BC File Offset: 0x000CB3BC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060036F4 RID: 14068 RVA: 0x000CD1C4 File Offset: 0x000CB3C4
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060036F5 RID: 14069 RVA: 0x000CD1D0 File Offset: 0x000CB3D0
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060036F6 RID: 14070 RVA: 0x000CD1DC File Offset: 0x000CB3DC
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060036F7 RID: 14071 RVA: 0x000CD1E8 File Offset: 0x000CB3E8
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060036F8 RID: 14072 RVA: 0x000CD1F4 File Offset: 0x000CB3F4
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060036F9 RID: 14073 RVA: 0x000CD200 File Offset: 0x000CB400
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060036FA RID: 14074 RVA: 0x000CD20C File Offset: 0x000CB40C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060036FB RID: 14075 RVA: 0x000CD218 File Offset: 0x000CB418
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060036FC RID: 14076 RVA: 0x000CD224 File Offset: 0x000CB424
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060036FD RID: 14077 RVA: 0x000CD22C File Offset: 0x000CB42C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060036FE RID: 14078 RVA: 0x000CD238 File Offset: 0x000CB438
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060036FF RID: 14079 RVA: 0x000CD244 File Offset: 0x000CB444
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003700 RID: 14080 RVA: 0x000CD24C File Offset: 0x000CB44C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003701 RID: 14081 RVA: 0x000CD254 File Offset: 0x000CB454
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003702 RID: 14082 RVA: 0x000CD25C File Offset: 0x000CB45C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003703 RID: 14083 RVA: 0x000CD264 File Offset: 0x000CB464
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003704 RID: 14084 RVA: 0x000CD26C File Offset: 0x000CB46C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003705 RID: 14085 RVA: 0x000CD274 File Offset: 0x000CB474
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003706 RID: 14086 RVA: 0x000CD27C File Offset: 0x000CB47C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003707 RID: 14087 RVA: 0x000CD288 File Offset: 0x000CB488
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003708 RID: 14088 RVA: 0x000CD290 File Offset: 0x000CB490
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003709 RID: 14089 RVA: 0x000CD298 File Offset: 0x000CB498
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600370A RID: 14090 RVA: 0x000CD2A0 File Offset: 0x000CB4A0
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600370B RID: 14091 RVA: 0x000CD2A8 File Offset: 0x000CB4A8
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600370C RID: 14092 RVA: 0x000CD2B0 File Offset: 0x000CB4B0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600370D RID: 14093 RVA: 0x000CD2B8 File Offset: 0x000CB4B8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
