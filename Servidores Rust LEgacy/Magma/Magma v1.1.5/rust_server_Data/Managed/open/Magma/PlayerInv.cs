using System;

namespace Magma
{
	// Token: 0x0200002B RID: 43
	public class PlayerInv
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000069CC File Offset: 0x00004BCC
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x000069D4 File Offset: 0x00004BD4
		public global::Inventory InternalInventory
		{
			get
			{
				return this._inv;
			}
			set
			{
				this._inv = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x000069DD File Offset: 0x00004BDD
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x000069E5 File Offset: 0x00004BE5
		public global::Magma.PlayerItem[] ArmorItems
		{
			get
			{
				return this._armorItems;
			}
			set
			{
				this._armorItems = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x000069EE File Offset: 0x00004BEE
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x000069F6 File Offset: 0x00004BF6
		public global::Magma.PlayerItem[] Items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x000069FF File Offset: 0x00004BFF
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00006A07 File Offset: 0x00004C07
		public global::Magma.PlayerItem[] BarItems
		{
			get
			{
				return this._barItems;
			}
			set
			{
				this._barItems = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00006A10 File Offset: 0x00004C10
		public int FreeSlots
		{
			get
			{
				return this.GetFreeSlots();
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00006A18 File Offset: 0x00004C18
		public PlayerInv(global::Magma.Player player)
		{
			this.player = player;
			this._inv = player.PlayerClient.controllable.GetComponent<global::Inventory>();
			this.InitItems();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00006A44 File Offset: 0x00004C44
		private void InitItems()
		{
			this.Items = new global::Magma.PlayerItem[0x1E];
			this.ArmorItems = new global::Magma.PlayerItem[4];
			this.BarItems = new global::Magma.PlayerItem[6];
			for (int i = 0; i < this._inv.slotCount; i++)
			{
				if (i < 0x1E)
				{
					this.Items[i] = new global::Magma.PlayerItem(ref this._inv, i);
				}
				else if (i < 0x24)
				{
					this.BarItems[i - 0x1E] = new global::Magma.PlayerItem(ref this._inv, i);
				}
				else if (i < 0x28)
				{
					this.ArmorItems[i - 0x24] = new global::Magma.PlayerItem(ref this._inv, i);
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00006AE1 File Offset: 0x00004CE1
		public void AddItem(string name)
		{
			this.AddItem(name, 1);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00006AEC File Offset: 0x00004CEC
		public void AddItem(string name, int amount)
		{
			string[] args = new string[]
			{
				name,
				amount.ToString()
			};
			global::ConsoleSystem.Arg arg = new global::ConsoleSystem.Arg("");
			arg.Args = args;
			arg.SetUser(this.player.PlayerClient.netUser);
			global::inv.give(ref arg);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00006B3F File Offset: 0x00004D3F
		public void AddItemTo(string name, int slot)
		{
			this.AddItemTo(name, slot, 1);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00006B4C File Offset: 0x00004D4C
		public void AddItemTo(string name, int slot, int amount)
		{
			global::ItemDataBlock byName = global::DatablockDictionary.GetByName(name);
			if (byName != null)
			{
				global::Inventory.Slot.Kind value = global::Inventory.Slot.Kind.Default;
				if (slot > 0x1D && slot < 0x24)
				{
					value = global::Inventory.Slot.Kind.Belt;
				}
				else if (slot >= 0x24 && slot < 0x28)
				{
					value = global::Inventory.Slot.Kind.Armor;
				}
				this._inv.AddItemSomehow(byName, new global::Inventory.Slot.Kind?(value), slot, amount);
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00006B9A File Offset: 0x00004D9A
		public void MoveItem(int s1, int s2)
		{
			this._inv.MoveItemAtSlotToEmptySlot(this._inv, s1, s2);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00006BB0 File Offset: 0x00004DB0
		public void RemoveItem(global::Magma.PlayerItem pi)
		{
			foreach (global::Magma.PlayerItem playerItem in this.Items)
			{
				if (playerItem == pi)
				{
					this._inv.RemoveItem(pi.InventoryItem);
					return;
				}
			}
			foreach (global::Magma.PlayerItem playerItem2 in this.ArmorItems)
			{
				if (playerItem2 == pi)
				{
					this._inv.RemoveItem(pi.InventoryItem);
					return;
				}
			}
			foreach (global::Magma.PlayerItem playerItem3 in this.BarItems)
			{
				if (playerItem3 == pi)
				{
					this._inv.RemoveItem(pi.InventoryItem);
					break;
				}
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00006C65 File Offset: 0x00004E65
		public bool HasItem(string name)
		{
			return this.HasItem(name, 1);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00006C70 File Offset: 0x00004E70
		public bool HasItem(string name, int number)
		{
			int num = 0;
			foreach (global::Magma.PlayerItem playerItem in this.Items)
			{
				if (playerItem.Name == name)
				{
					if (playerItem.UsesLeft >= number)
					{
						return true;
					}
					num += playerItem.UsesLeft;
				}
			}
			foreach (global::Magma.PlayerItem playerItem2 in this.BarItems)
			{
				if (playerItem2.Name == name)
				{
					if (playerItem2.UsesLeft >= number)
					{
						return true;
					}
					num += playerItem2.UsesLeft;
				}
			}
			foreach (global::Magma.PlayerItem playerItem3 in this.ArmorItems)
			{
				if (playerItem3.Name == name)
				{
					if (playerItem3.UsesLeft >= number)
					{
						return true;
					}
					num += playerItem3.UsesLeft;
				}
			}
			return num >= number;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00006D60 File Offset: 0x00004F60
		public void RemoveItem(string name, int number)
		{
			int num = number;
			foreach (global::Magma.PlayerItem playerItem in this.Items)
			{
				if (playerItem.Name == name)
				{
					if (playerItem.UsesLeft > num)
					{
						playerItem.Consume(num);
						num = 0;
						break;
					}
					num -= playerItem.UsesLeft;
					if (num < 0)
					{
						num = 0;
					}
					this._inv.RemoveItem(playerItem.Slot);
					if (num == 0)
					{
						break;
					}
				}
			}
			if (num == 0)
			{
				return;
			}
			foreach (global::Magma.PlayerItem playerItem2 in this.ArmorItems)
			{
				if (playerItem2.Name == name)
				{
					if (playerItem2.UsesLeft > num)
					{
						playerItem2.Consume(num);
						num = 0;
						break;
					}
					num -= playerItem2.UsesLeft;
					if (num < 0)
					{
						num = 0;
					}
					this._inv.RemoveItem(playerItem2.Slot);
					if (num == 0)
					{
						break;
					}
				}
			}
			if (num == 0)
			{
				return;
			}
			foreach (global::Magma.PlayerItem playerItem3 in this.BarItems)
			{
				if (playerItem3.Name == name)
				{
					if (playerItem3.UsesLeft > num)
					{
						playerItem3.Consume(num);
						return;
					}
					num -= playerItem3.UsesLeft;
					if (num < 0)
					{
						num = 0;
					}
					this._inv.RemoveItem(playerItem3.Slot);
					if (num == 0)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00006EAC File Offset: 0x000050AC
		public void RemoveItemAll(string name)
		{
			this.RemoveItem(name, 0x1869F);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00006EBA File Offset: 0x000050BA
		public void RemoveItem(int slot)
		{
			this._inv.RemoveItem(slot);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00006ECC File Offset: 0x000050CC
		public void Clear()
		{
			foreach (global::Magma.PlayerItem playerItem in this.Items)
			{
				this._inv.RemoveItem(playerItem.InventoryItem);
			}
			foreach (global::Magma.PlayerItem playerItem2 in this.BarItems)
			{
				this._inv.RemoveItem(playerItem2.InventoryItem);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00006F38 File Offset: 0x00005138
		public void ClearArmor()
		{
			foreach (global::Magma.PlayerItem playerItem in this.ArmorItems)
			{
				this._inv.RemoveItem(playerItem.InventoryItem);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00006F70 File Offset: 0x00005170
		public void ClearBar()
		{
			foreach (global::Magma.PlayerItem playerItem in this.BarItems)
			{
				this._inv.RemoveItem(playerItem.InventoryItem);
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00006FA8 File Offset: 0x000051A8
		public void ClearAll()
		{
			this._inv.Clear();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00006FB5 File Offset: 0x000051B5
		public void DropItem(global::Magma.PlayerItem pi)
		{
			global::DropHelper.DropItem(this.InternalInventory, pi.Slot);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00006FC8 File Offset: 0x000051C8
		public void DropItem(int slot)
		{
			global::DropHelper.DropItem(this.InternalInventory, slot);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00006FD6 File Offset: 0x000051D6
		public void DropAll()
		{
			global::DropHelper.DropInventoryContents(this.InternalInventory);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00006FE4 File Offset: 0x000051E4
		private int GetFreeSlots()
		{
			int num = 0;
			for (int i = 0; i < this._inv.slotCount - 4; i++)
			{
				if (this._inv.IsSlotFree(i))
				{
					num++;
				}
			}
			return num + 1;
		}

		// Token: 0x04000060 RID: 96
		private global::Magma.Player player;

		// Token: 0x04000061 RID: 97
		private global::Inventory _inv;

		// Token: 0x04000062 RID: 98
		private global::Magma.PlayerItem[] _armorItems;

		// Token: 0x04000063 RID: 99
		private global::Magma.PlayerItem[] _items;

		// Token: 0x04000064 RID: 100
		private global::Magma.PlayerItem[] _barItems;
	}
}
