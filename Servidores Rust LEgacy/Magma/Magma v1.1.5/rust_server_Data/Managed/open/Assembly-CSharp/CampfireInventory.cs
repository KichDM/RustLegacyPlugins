using System;
using RustProto;
using uLink;

// Token: 0x02000636 RID: 1590
public class CampfireInventory : global::Inventory, global::IServerSaveable, global::FixedSizeInventory
{
	// Token: 0x06003256 RID: 12886 RVA: 0x000C0A94 File Offset: 0x000BEC94
	public CampfireInventory()
	{
	}

	// Token: 0x17000A78 RID: 2680
	// (get) Token: 0x06003257 RID: 12887 RVA: 0x000C0A9C File Offset: 0x000BEC9C
	public int fixedSlotCount
	{
		get
		{
			return 8;
		}
	}

	// Token: 0x06003258 RID: 12888 RVA: 0x000C0AA0 File Offset: 0x000BECA0
	private void NGC_OnInstantiate(global::NGCView view)
	{
		base.InitializeThisFixedSizeInventory();
	}

	// Token: 0x06003259 RID: 12889 RVA: 0x000C0AAC File Offset: 0x000BECAC
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		base.InitializeThisFixedSizeInventory();
	}

	// Token: 0x0600325A RID: 12890 RVA: 0x000C0AB8 File Offset: 0x000BECB8
	protected override void ConfigureSlots(int totalCount, ref global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range> ranges, ref global::Inventory.SlotFlags[] flags)
	{
		global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range> kindDictionary = default(global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range>);
		kindDictionary[global::Inventory.Slot.Kind.Belt] = new global::Inventory.Slot.Range(0, 3);
		kindDictionary[global::Inventory.Slot.Kind.Default] = new global::Inventory.Slot.Range(3, totalCount - 3);
		ranges = kindDictionary;
		global::Inventory.SlotFlags[] array = new global::Inventory.SlotFlags[totalCount];
		for (int i = 0; i < 3; i++)
		{
			array[i] |= global::Inventory.SlotFlags.Cooked;
		}
		for (int j = 3; j < 6; j++)
		{
			array[j] |= global::Inventory.SlotFlags.Raw;
		}
		array[6] |= global::Inventory.SlotFlags.FuelBasic;
		array[7] |= global::Inventory.SlotFlags.Debris;
		flags = array;
	}

	// Token: 0x0600325B RID: 12891 RVA: 0x000C0B64 File Offset: 0x000BED64
	protected override bool CheckSlotFlags(global::Inventory.SlotFlags itemSlotFlags, global::Inventory.SlotFlags slotFlags)
	{
		return (itemSlotFlags & slotFlags) != (global::Inventory.SlotFlags)0;
	}

	// Token: 0x0600325C RID: 12892 RVA: 0x000C0B70 File Offset: 0x000BED70
	virtual void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		base.WriteObjectSave(ref saveobj);
	}

	// Token: 0x0600325D RID: 12893 RVA: 0x000C0B7C File Offset: 0x000BED7C
	virtual void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		base.ReadObjectSave(ref saveobj);
	}
}
