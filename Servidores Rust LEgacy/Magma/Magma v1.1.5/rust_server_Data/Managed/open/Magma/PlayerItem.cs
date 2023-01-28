using System;

namespace Magma
{
	// Token: 0x02000010 RID: 16
	public class PlayerItem
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000346F File Offset: 0x0000166F
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000348B File Offset: 0x0000168B
		public string Name
		{
			get
			{
				if (!this.IsEmpty())
				{
					return this.InventoryItem.datablock.name;
				}
				return null;
			}
			set
			{
				this.InventoryItem.datablock.name = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600008E RID: 142 RVA: 0x0000349E File Offset: 0x0000169E
		public int Slot
		{
			get
			{
				if (!this.IsEmpty())
				{
					return this.InventoryItem.slot;
				}
				return -1;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000034B5 File Offset: 0x000016B5
		// (set) Token: 0x06000090 RID: 144 RVA: 0x000034BD File Offset: 0x000016BD
		public int Quantity
		{
			get
			{
				return this.UsesLeft;
			}
			set
			{
				this.UsesLeft = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000034C6 File Offset: 0x000016C6
		// (set) Token: 0x06000092 RID: 146 RVA: 0x000034DD File Offset: 0x000016DD
		public int UsesLeft
		{
			get
			{
				if (!this.IsEmpty())
				{
					return this.InventoryItem.uses;
				}
				return -1;
			}
			set
			{
				this.InventoryItem.SetUses(value);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000034EB File Offset: 0x000016EB
		// (set) Token: 0x06000094 RID: 148 RVA: 0x000034F3 File Offset: 0x000016F3
		public global::IInventoryItem InventoryItem
		{
			get
			{
				return this.GetItemRef();
			}
			set
			{
				this.InventoryItem = value;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000034FC File Offset: 0x000016FC
		public PlayerItem()
		{
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003504 File Offset: 0x00001704
		public PlayerItem(ref global::Inventory inv, int slot)
		{
			this.internalInv = inv;
			this.internalSlot = slot;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000351C File Offset: 0x0000171C
		private global::IInventoryItem GetItemRef()
		{
			global::IInventoryItem result;
			this.internalInv.GetItem(this.internalSlot, out result);
			return result;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000353E File Offset: 0x0000173E
		public void Consume(int qty)
		{
			if (this.IsEmpty())
			{
				return;
			}
			this.InventoryItem.Consume(ref qty);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003557 File Offset: 0x00001757
		public bool TryStack(global::Magma.PlayerItem pi)
		{
			return !this.IsEmpty() && !pi.IsEmpty() && this.InventoryItem.TryStack(pi.InventoryItem) != global::InventoryItem.MergeResult.Failed;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003581 File Offset: 0x00001781
		public bool TryCombine(global::Magma.PlayerItem pi)
		{
			return !this.IsEmpty() && !pi.IsEmpty() && this.InventoryItem.TryCombine(pi.InventoryItem) != global::InventoryItem.MergeResult.Failed;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000035AB File Offset: 0x000017AB
		public void Drop()
		{
			global::DropHelper.DropItem(this.internalInv, this.Slot);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000035BE File Offset: 0x000017BE
		public bool IsEmpty()
		{
			return this.InventoryItem == null;
		}

		// Token: 0x04000024 RID: 36
		private int internalSlot;

		// Token: 0x04000025 RID: 37
		private global::Inventory internalInv;
	}
}
