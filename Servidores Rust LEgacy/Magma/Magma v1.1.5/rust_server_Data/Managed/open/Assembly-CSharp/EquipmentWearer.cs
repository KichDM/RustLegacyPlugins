using System;
using uLink;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class EquipmentWearer : global::IDLocalCharacter
{
	// Token: 0x0600037C RID: 892 RVA: 0x000109F8 File Offset: 0x0000EBF8
	public EquipmentWearer()
	{
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x0600037D RID: 893 RVA: 0x00010A00 File Offset: 0x0000EC00
	public new global::ProtectionTakeDamage takeDamage
	{
		get
		{
			if (!this._protectionTakeDamage.cached)
			{
				this._protectionTakeDamage = (base.takeDamage as global::ProtectionTakeDamage);
			}
			return this._protectionTakeDamage.value;
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x0600037E RID: 894 RVA: 0x00010A34 File Offset: 0x0000EC34
	public global::InventoryHolder inventoryHolder
	{
		get
		{
			if (!this._inventoryHolder.cached)
			{
				this._inventoryHolder = base.GetLocal<global::InventoryHolder>();
			}
			return this._inventoryHolder.value;
		}
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00010A70 File Offset: 0x0000EC70
	public void EquipmentUpdate()
	{
		this.CalculateArmor();
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00010A78 File Offset: 0x0000EC78
	public void CalculateArmor()
	{
		global::InventoryHolder inventoryHolder = this.inventoryHolder;
		global::ProtectionTakeDamage takeDamage = this.takeDamage;
		if (inventoryHolder && takeDamage)
		{
			global::DamageTypeList damageTypeList = new global::DamageTypeList();
			for (int i = 0x24; i < 0x28; i++)
			{
				global::IInventoryItem inventoryItem;
				global::ArmorDataBlock armorDataBlock;
				if (inventoryHolder.inventory.GetItem(i, out inventoryItem) && (armorDataBlock = (inventoryItem.datablock as global::ArmorDataBlock)))
				{
					armorDataBlock.AddToDamageTypeList(damageTypeList);
				}
			}
			if (takeDamage)
			{
				takeDamage.SetArmorValues(damageTypeList);
			}
			this.SendArmorValues();
		}
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00010B14 File Offset: 0x0000ED14
	public void SendArmorValues()
	{
		global::ProtectionTakeDamage takeDamage = this.takeDamage;
		if (takeDamage)
		{
			global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
			for (int i = 0; i < 6; i++)
			{
				bitStream.WriteSingle(takeDamage.GetArmorValue(i));
			}
			base.networkView.RPC<byte[]>("ArmorData", 3, bitStream.GetDataByteArray());
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00010B70 File Offset: 0x0000ED70
	[global::UnityEngine.RPC]
	protected void ArmorData(byte[] data)
	{
	}

	// Token: 0x04000310 RID: 784
	[global::System.NonSerialized]
	private global::CacheRef<global::ProtectionTakeDamage> _protectionTakeDamage;

	// Token: 0x04000311 RID: 785
	[global::System.NonSerialized]
	private global::CacheRef<global::InventoryHolder> _inventoryHolder;
}
