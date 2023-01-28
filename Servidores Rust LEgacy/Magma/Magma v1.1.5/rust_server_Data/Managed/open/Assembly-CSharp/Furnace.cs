using System;
using System.Collections.Generic;

// Token: 0x02000043 RID: 67
public class Furnace : global::FireBarrel
{
	// Token: 0x06000266 RID: 614 RVA: 0x0000CBE0 File Offset: 0x0000ADE0
	public Furnace()
	{
	}

	// Token: 0x06000267 RID: 615 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
	protected override float GetCookDuration()
	{
		return 30f;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x0000CBF0 File Offset: 0x0000ADF0
	public override void ConsumeFuel()
	{
		global::IFlammableItem flammableItem = base.FindFuel();
		if (flammableItem == null)
		{
			base.SetOn(false);
		}
		else
		{
			int num = 2;
			bool flag;
			if (flammableItem.Consume(ref num))
			{
				flag = true;
				flammableItem.inventory.RemoveItem(flammableItem.slot);
			}
			else
			{
				flag = false;
			}
			this._inventory.AddItemAmount(ref global::FireBarrel.DefaultItems.byProduct, 5);
			global::EnvDecay.RefreshRadialDecay(base.transform.position, global::FireBarrel.decayResetRange);
			global::System.Collections.Generic.List<global::ICookableItem> list = new global::System.Collections.Generic.List<global::ICookableItem>(this._inventory.FindItems<global::ICookableItem>());
			global::System.Collections.Generic.HashSet<global::ItemDataBlock> hashSet = null;
			foreach (global::ICookableItem cookableItem in list)
			{
				int num2;
				global::ItemDataBlock itemDataBlock;
				int num3;
				int num4;
				int num5;
				if (cookableItem != null && cookableItem.GetCookableInfo(out num2, out itemDataBlock, out num3, out num4, out num5) && (num3 <= 0 || itemDataBlock) && cookableItem.uses >= num2 && this.myTemp >= num4)
				{
					if (num3 > 0)
					{
						if (hashSet == null)
						{
							hashSet = new global::System.Collections.Generic.HashSet<global::ItemDataBlock>();
							hashSet.Add(itemDataBlock);
						}
						else if (!hashSet.Add(itemDataBlock))
						{
							continue;
						}
					}
					if (cookableItem.Consume(ref num2))
					{
						this._inventory.RemoveItem(cookableItem.slot);
					}
					if (num3 > 0)
					{
						if (this.myTemp >= num5)
						{
							this._inventory.AddItemAmount(ref global::FireBarrel.DefaultItems.byProduct, num3);
						}
						else
						{
							this._inventory.AddItem(itemDataBlock, global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, true, global::Inventory.Slot.KindFlags.Belt), num3);
						}
					}
				}
			}
			if (flag && !this.HasFuel())
			{
				base.SetOn(false);
			}
			base.DecayTouch();
		}
	}
}
