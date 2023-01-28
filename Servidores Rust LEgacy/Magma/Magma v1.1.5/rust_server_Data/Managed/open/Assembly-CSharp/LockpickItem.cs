using System;
using Rust;
using UnityEngine;

// Token: 0x020006FE RID: 1790
public abstract class LockpickItem<T> : global::InventoryItem<T> where T : global::LockpickItemDataBlock
{
	// Token: 0x06003CFA RID: 15610 RVA: 0x000D6A30 File Offset: 0x000D4C30
	protected LockpickItem(T db) : base(db)
	{
	}

	// Token: 0x06003CFB RID: 15611 RVA: 0x000D6A3C File Offset: 0x000D4C3C
	public override void OnBeltUse()
	{
		global::UnityEngine.RaycastHit raycastHit;
		bool flag = global::UnityEngine.Physics.Raycast(this.iface.character.eyesRay, ref raycastHit, 5f);
		if (flag)
		{
			global::IDBase idbase = global::IDBase.Get(raycastHit.collider);
			if (!idbase)
			{
				return;
			}
			global::LockableObject component = idbase.GetComponent<global::LockableObject>();
			if (component != null && component.IsPickable())
			{
				if (component.PickAttempt(this.datablock.pickingAbility))
				{
					global::Rust.Notice.Popup(this.iface.inventory.networkViewOwner, "", "Lock has been picked!", 4f);
					this.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Used);
				}
				else
				{
					global::Rust.Notice.Popup(this.iface.inventory.networkViewOwner, "", "Lockpicking FAILED", 4f);
					this.FireClientSideItemEvent(global::InventoryItem.ItemEvent.UnEquipped);
				}
				int num = 1;
				if (base.Consume(ref num))
				{
					base.inventory.RemoveItem(base.slot);
				}
			}
			else
			{
				global::Rust.Notice.Popup(this.iface.inventory.networkViewOwner, "", "You can't lockpick this.", 4f);
			}
		}
		else
		{
			global::Rust.Notice.Popup(this.iface.inventory.networkViewOwner, "", "Aim at a locked object.", 4f);
		}
	}
}
