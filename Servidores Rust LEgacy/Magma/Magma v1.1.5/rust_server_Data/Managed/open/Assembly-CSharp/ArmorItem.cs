using System;

// Token: 0x020006D4 RID: 1748
public abstract class ArmorItem<T> : global::EquipmentItem<T> where T : global::ArmorDataBlock
{
	// Token: 0x06003BD0 RID: 15312 RVA: 0x000D4A4C File Offset: 0x000D2C4C
	protected ArmorItem(T db) : base(db)
	{
	}

	// Token: 0x06003BD1 RID: 15313 RVA: 0x000D4A58 File Offset: 0x000D2C58
	public override void OnMovedTo(global::Inventory toInv, int toSlot)
	{
		base.OnMovedTo(toInv, toSlot);
		this.ArmorUpdate(toInv, toSlot);
	}

	// Token: 0x06003BD2 RID: 15314 RVA: 0x000D4A6C File Offset: 0x000D2C6C
	public override void OnAddedTo(global::Inventory newInventory, int targetSlot)
	{
		base.OnAddedTo(newInventory, targetSlot);
		this.ArmorUpdate(newInventory, targetSlot);
	}

	// Token: 0x06003BD3 RID: 15315 RVA: 0x000D4A80 File Offset: 0x000D2C80
	public virtual void ArmorUpdate(global::Inventory belongInv, int belongSlot)
	{
	}

	// Token: 0x06003BD4 RID: 15316 RVA: 0x000D4A84 File Offset: 0x000D2C84
	public override bool CanMoveToSlot(global::Inventory toinv, int toslot)
	{
		if (base.IsBroken())
		{
			global::PlayerInventory playerInventory = toinv as global::PlayerInventory;
			if (playerInventory != null && global::PlayerInventory.IsEquipmentSlot(toslot))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06003BD5 RID: 15317 RVA: 0x000D4AC0 File Offset: 0x000D2CC0
	public override void ConditionChanged(float oldCondition)
	{
		if (base.condition <= 0f)
		{
			int num = -1;
			for (int i = 0; i < 0x1E; i++)
			{
				if (base.inventory.IsSlotFree(i))
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				base.inventory.MoveItemAtSlotToEmptySlot(base.inventory, base.slot, num);
			}
		}
		base.ConditionChanged(oldCondition);
	}
}
