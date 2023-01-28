using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000715 RID: 1813
public sealed class Loadout : global::UnityEngine.ScriptableObject
{
	// Token: 0x06003D97 RID: 15767 RVA: 0x000D7E04 File Offset: 0x000D6004
	public Loadout()
	{
	}

	// Token: 0x06003D98 RID: 15768 RVA: 0x000D7E0C File Offset: 0x000D600C
	private static global::Loadout.Entry[] LoadEntryArray(global::Loadout.Entry[] array, global::Inventory.Slot.Kind kind)
	{
		array = (array ?? global::Loadout.Empty.EntryArray);
		for (int i = 0; i < array.Length; i++)
		{
			global::Loadout.Entry entry = array[i];
			entry.inferredSlotKind = kind;
			entry.inferredSlotOfKind = i;
		}
		return array;
	}

	// Token: 0x06003D99 RID: 15769 RVA: 0x000D7E50 File Offset: 0x000D6050
	private global::Loadout.Entry[][] GetEntryArrays()
	{
		return new global::Loadout.Entry[][]
		{
			global::Loadout.LoadEntryArray(this._inventory, global::Inventory.Slot.Kind.Default),
			global::Loadout.LoadEntryArray(this._belt, global::Inventory.Slot.Kind.Belt),
			global::Loadout.LoadEntryArray(this._wearable, global::Inventory.Slot.Kind.Armor)
		};
	}

	// Token: 0x06003D9A RID: 15770 RVA: 0x000D7E88 File Offset: 0x000D6088
	private static global::System.Collections.Generic.IEnumerable<global::Inventory.Addition> EnumerateAdditions(global::Loadout.Entry[][] arrays)
	{
		foreach (global::Loadout.Entry[] array in arrays)
		{
			foreach (global::Loadout.Entry entry in array)
			{
				global::Inventory.Addition current;
				if (entry.GetInventoryAddition(out current))
				{
					yield return current;
				}
			}
		}
		yield break;
	}

	// Token: 0x06003D9B RID: 15771 RVA: 0x000D7EB4 File Offset: 0x000D60B4
	private static global::System.Collections.Generic.IEnumerable<global::Loadout.Entry> EnumerateRequired(global::Loadout.Entry[][] arrays)
	{
		foreach (global::Loadout.Entry[] array in arrays)
		{
			foreach (global::Loadout.Entry entry in array)
			{
				if (entry.minimumRequirement)
				{
					yield return entry;
				}
			}
		}
		yield break;
	}

	// Token: 0x06003D9C RID: 15772 RVA: 0x000D7EE0 File Offset: 0x000D60E0
	private void GetAdditionArray(ref global::Inventory.Addition[] array, bool forceUpdate)
	{
		if (forceUpdate || array == null)
		{
			array = new global::System.Collections.Generic.List<global::Inventory.Addition>(global::Loadout.EnumerateAdditions(this.GetEntryArrays())).ToArray();
		}
	}

	// Token: 0x06003D9D RID: 15773 RVA: 0x000D7F14 File Offset: 0x000D6114
	private void GetMinimumRequirementArray(ref global::Loadout.Entry[] array, bool forceUpdate)
	{
		if (forceUpdate || array == null)
		{
			array = new global::System.Collections.Generic.List<global::Loadout.Entry>(global::Loadout.EnumerateRequired(this.GetEntryArrays())).ToArray();
		}
	}

	// Token: 0x17000BB9 RID: 3001
	// (get) Token: 0x06003D9E RID: 15774 RVA: 0x000D7F48 File Offset: 0x000D6148
	private global::Inventory.Addition[] emptyInventoryAdditions
	{
		get
		{
			this.GetAdditionArray(ref this._blankInventoryLoadout, false);
			return this._blankInventoryLoadout;
		}
	}

	// Token: 0x17000BBA RID: 3002
	// (get) Token: 0x06003D9F RID: 15775 RVA: 0x000D7F60 File Offset: 0x000D6160
	private global::Loadout.Entry[] minimumRequirements
	{
		get
		{
			this.GetMinimumRequirementArray(ref this._minimumRequirements, false);
			return this._minimumRequirements;
		}
	}

	// Token: 0x17000BBB RID: 3003
	// (get) Token: 0x06003DA0 RID: 15776 RVA: 0x000D7F78 File Offset: 0x000D6178
	public global::BlueprintDataBlock[] defaultBlueprints
	{
		get
		{
			return this._defaultBlueprints ?? global::Loadout.Empty.BlueprintArray;
		}
	}

	// Token: 0x06003DA1 RID: 15777 RVA: 0x000D7F8C File Offset: 0x000D618C
	public void ApplyTo(global::Inventory inventory)
	{
		if (inventory is global::PlayerInventory)
		{
			this.ApplyTo((global::PlayerInventory)inventory);
		}
		else if (inventory)
		{
			try
			{
				this.ApplyInventorySettings(inventory);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}
	}

	// Token: 0x06003DA2 RID: 15778 RVA: 0x000D7FF8 File Offset: 0x000D61F8
	public void ApplyTo(global::PlayerInventory inventory)
	{
		try
		{
			if (inventory)
			{
				foreach (global::BlueprintDataBlock blueprintDataBlock in this.defaultBlueprints)
				{
					if (blueprintDataBlock)
					{
						inventory.BindBlueprint(blueprintDataBlock);
					}
				}
				this.ApplyInventorySettings(inventory);
			}
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex, this);
		}
	}

	// Token: 0x06003DA3 RID: 15779 RVA: 0x000D8078 File Offset: 0x000D6278
	private void ApplyInventorySettings(global::Inventory inventory)
	{
		if (inventory.noOccupiedSlots)
		{
			global::Inventory.Addition[] emptyInventoryAdditions = this.emptyInventoryAdditions;
			for (int i = 0; i < emptyInventoryAdditions.Length; i++)
			{
				inventory.AddItem(ref emptyInventoryAdditions[i]);
			}
		}
		else
		{
			foreach (global::Loadout.Entry entry in this.minimumRequirements)
			{
				int num;
				if (!object.ReferenceEquals(inventory.FindItem(entry.item, out num), null))
				{
					if (entry.item.IsSplittable())
					{
						int useCount = entry.useCount;
						if (num < useCount)
						{
							inventory.AddItemAmount(entry.item, useCount - num);
						}
					}
				}
				else if (!inventory.noVacantSlots)
				{
					inventory.AddItemSomehow(entry.item, new global::Inventory.Slot.Kind?(entry.inferredSlotKind), entry.inferredSlotOfKind, entry.useCount);
				}
			}
		}
	}

	// Token: 0x04001F08 RID: 7944
	[global::UnityEngine.SerializeField]
	private global::Loadout.Entry[] _inventory;

	// Token: 0x04001F09 RID: 7945
	[global::UnityEngine.SerializeField]
	private global::Loadout.Entry[] _belt;

	// Token: 0x04001F0A RID: 7946
	[global::UnityEngine.SerializeField]
	private global::Loadout.Entry[] _wearable;

	// Token: 0x04001F0B RID: 7947
	[global::UnityEngine.SerializeField]
	private global::BlueprintDataBlock[] _defaultBlueprints;

	// Token: 0x04001F0C RID: 7948
	[global::System.NonSerialized]
	private global::Inventory.Addition[] _blankInventoryLoadout;

	// Token: 0x04001F0D RID: 7949
	[global::System.NonSerialized]
	private global::Loadout.Entry[] _minimumRequirements;

	// Token: 0x02000716 RID: 1814
	[global::System.Serializable]
	private class Entry
	{
		// Token: 0x06003DA4 RID: 15780 RVA: 0x000D8168 File Offset: 0x000D6368
		public Entry()
		{
		}

		// Token: 0x17000BBC RID: 3004
		// (get) Token: 0x06003DA5 RID: 15781 RVA: 0x000D8170 File Offset: 0x000D6370
		public bool allowed
		{
			get
			{
				return this.enabled && this.item && (!this.item.IsSplittable() || this._useCount > 0);
			}
		}

		// Token: 0x17000BBD RID: 3005
		// (get) Token: 0x06003DA6 RID: 15782 RVA: 0x000D81B8 File Offset: 0x000D63B8
		public bool forEmptyInventories
		{
			get
			{
				return !this._minimumRequirement && this.allowed;
			}
		}

		// Token: 0x17000BBE RID: 3006
		// (get) Token: 0x06003DA7 RID: 15783 RVA: 0x000D81D0 File Offset: 0x000D63D0
		public bool minimumRequirement
		{
			get
			{
				return this._minimumRequirement && this.allowed;
			}
		}

		// Token: 0x17000BBF RID: 3007
		// (get) Token: 0x06003DA8 RID: 15784 RVA: 0x000D81E8 File Offset: 0x000D63E8
		public int useCount
		{
			get
			{
				return (!this.allowed) ? 0 : ((this.item._maxUses >= this._useCount) ? ((int)((byte)this._useCount)) : this.item._maxUses);
			}
		}

		// Token: 0x06003DA9 RID: 15785 RVA: 0x000D8234 File Offset: 0x000D6434
		public bool GetInventoryAddition(out global::Inventory.Addition addition)
		{
			if (this.allowed)
			{
				addition = default(global::Inventory.Addition);
				global::Inventory.Addition addition2 = addition;
				addition2.Ident = (global::Datablock.Ident)this.item;
				addition2.SlotPreference = global::Inventory.Slot.Preference.Define(this.inferredSlotKind, this.inferredSlotOfKind);
				addition2.UsesQuantity = this.useCount;
				addition = addition2;
				return true;
			}
			addition = default(global::Inventory.Addition);
			return false;
		}

		// Token: 0x04001F0E RID: 7950
		[global::UnityEngine.SerializeField]
		private bool enabled;

		// Token: 0x04001F0F RID: 7951
		public global::ItemDataBlock item;

		// Token: 0x04001F10 RID: 7952
		[global::UnityEngine.SerializeField]
		private int _useCount;

		// Token: 0x04001F11 RID: 7953
		[global::UnityEngine.SerializeField]
		private bool _minimumRequirement;

		// Token: 0x04001F12 RID: 7954
		[global::System.NonSerialized]
		internal global::Inventory.Slot.Kind inferredSlotKind;

		// Token: 0x04001F13 RID: 7955
		[global::System.NonSerialized]
		internal int inferredSlotOfKind;
	}

	// Token: 0x02000717 RID: 1815
	private static class Empty
	{
		// Token: 0x06003DAA RID: 15786 RVA: 0x000D82B0 File Offset: 0x000D64B0
		// Note: this type is marked as 'beforefieldinit'.
		static Empty()
		{
		}

		// Token: 0x04001F14 RID: 7956
		public static readonly global::Loadout.Entry[] EntryArray = new global::Loadout.Entry[0];

		// Token: 0x04001F15 RID: 7957
		public static readonly global::BlueprintDataBlock[] BlueprintArray = new global::BlueprintDataBlock[0];
	}

	// Token: 0x02000718 RID: 1816
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <EnumerateAdditions>c__Iterator4B : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Inventory.Addition>, global::System.Collections.Generic.IEnumerator<global::Inventory.Addition>
	{
		// Token: 0x06003DAB RID: 15787 RVA: 0x000D82C8 File Offset: 0x000D64C8
		public <EnumerateAdditions>c__Iterator4B()
		{
		}

		// Token: 0x17000BC0 RID: 3008
		// (get) Token: 0x06003DAC RID: 15788 RVA: 0x000D82D0 File Offset: 0x000D64D0
		global::Inventory.Addition global::System.Collections.Generic.IEnumerator<global::Inventory.Addition>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BC1 RID: 3009
		// (get) Token: 0x06003DAD RID: 15789 RVA: 0x000D82D8 File Offset: 0x000D64D8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003DAE RID: 15790 RVA: 0x000D82E8 File Offset: 0x000D64E8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Inventory.Addition>.GetEnumerator();
		}

		// Token: 0x06003DAF RID: 15791 RVA: 0x000D82F0 File Offset: 0x000D64F0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Inventory.Addition> global::System.Collections.Generic.IEnumerable<global::Inventory.Addition>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Loadout.<EnumerateAdditions>c__Iterator4B <EnumerateAdditions>c__Iterator4B = new global::Loadout.<EnumerateAdditions>c__Iterator4B();
			<EnumerateAdditions>c__Iterator4B.arrays = arrays;
			return <EnumerateAdditions>c__Iterator4B;
		}

		// Token: 0x06003DB0 RID: 15792 RVA: 0x000D8324 File Offset: 0x000D6524
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			global::Loadout.Entry[][] array3;
			switch (num)
			{
			case 0U:
				array3 = arrays;
				i = 0;
				goto IL_D4;
			case 1U:
				IL_A5:
				j++;
				break;
			default:
				return false;
			}
			IL_B3:
			if (j >= array2.Length)
			{
				i++;
			}
			else
			{
				entry = array2[j];
				if (entry.GetInventoryAddition(out current))
				{
					this.$current = current;
					this.$PC = 1;
					return true;
				}
				goto IL_A5;
			}
			IL_D4:
			if (i < array3.Length)
			{
				array = array3[i];
				array2 = array;
				j = 0;
				goto IL_B3;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003DB1 RID: 15793 RVA: 0x000D8424 File Offset: 0x000D6624
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003DB2 RID: 15794 RVA: 0x000D8430 File Offset: 0x000D6630
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001F16 RID: 7958
		internal global::Loadout.Entry[][] arrays;

		// Token: 0x04001F17 RID: 7959
		internal global::Loadout.Entry[][] <$s_522>__0;

		// Token: 0x04001F18 RID: 7960
		internal int <$s_523>__1;

		// Token: 0x04001F19 RID: 7961
		internal global::Loadout.Entry[] <array>__2;

		// Token: 0x04001F1A RID: 7962
		internal global::Loadout.Entry[] <$s_524>__3;

		// Token: 0x04001F1B RID: 7963
		internal int <$s_525>__4;

		// Token: 0x04001F1C RID: 7964
		internal global::Loadout.Entry <entry>__5;

		// Token: 0x04001F1D RID: 7965
		internal global::Inventory.Addition <current>__6;

		// Token: 0x04001F1E RID: 7966
		internal int $PC;

		// Token: 0x04001F1F RID: 7967
		internal global::Inventory.Addition $current;

		// Token: 0x04001F20 RID: 7968
		internal global::Loadout.Entry[][] <$>arrays;
	}

	// Token: 0x02000719 RID: 1817
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <EnumerateRequired>c__Iterator4C : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Loadout.Entry>, global::System.Collections.Generic.IEnumerator<global::Loadout.Entry>
	{
		// Token: 0x06003DB3 RID: 15795 RVA: 0x000D8438 File Offset: 0x000D6638
		public <EnumerateRequired>c__Iterator4C()
		{
		}

		// Token: 0x17000BC2 RID: 3010
		// (get) Token: 0x06003DB4 RID: 15796 RVA: 0x000D8440 File Offset: 0x000D6640
		global::Loadout.Entry global::System.Collections.Generic.IEnumerator<global::Loadout.Entry>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BC3 RID: 3011
		// (get) Token: 0x06003DB5 RID: 15797 RVA: 0x000D8448 File Offset: 0x000D6648
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003DB6 RID: 15798 RVA: 0x000D8450 File Offset: 0x000D6650
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Loadout.Entry>.GetEnumerator();
		}

		// Token: 0x06003DB7 RID: 15799 RVA: 0x000D8458 File Offset: 0x000D6658
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Loadout.Entry> global::System.Collections.Generic.IEnumerable<global::Loadout.Entry>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Loadout.<EnumerateRequired>c__Iterator4C <EnumerateRequired>c__Iterator4C = new global::Loadout.<EnumerateRequired>c__Iterator4C();
			<EnumerateRequired>c__Iterator4C.arrays = arrays;
			return <EnumerateRequired>c__Iterator4C;
		}

		// Token: 0x06003DB8 RID: 15800 RVA: 0x000D848C File Offset: 0x000D668C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			global::Loadout.Entry[][] array3;
			switch (num)
			{
			case 0U:
				array3 = arrays;
				i = 0;
				goto IL_CE;
			case 1U:
				IL_9F:
				j++;
				break;
			default:
				return false;
			}
			IL_AD:
			if (j >= array2.Length)
			{
				i++;
			}
			else
			{
				entry = array2[j];
				if (entry.minimumRequirement)
				{
					this.$current = entry;
					this.$PC = 1;
					return true;
				}
				goto IL_9F;
			}
			IL_CE:
			if (i < array3.Length)
			{
				array = array3[i];
				array2 = array;
				j = 0;
				goto IL_AD;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003DB9 RID: 15801 RVA: 0x000D8588 File Offset: 0x000D6788
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003DBA RID: 15802 RVA: 0x000D8594 File Offset: 0x000D6794
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001F21 RID: 7969
		internal global::Loadout.Entry[][] arrays;

		// Token: 0x04001F22 RID: 7970
		internal global::Loadout.Entry[][] <$s_526>__0;

		// Token: 0x04001F23 RID: 7971
		internal int <$s_527>__1;

		// Token: 0x04001F24 RID: 7972
		internal global::Loadout.Entry[] <array>__2;

		// Token: 0x04001F25 RID: 7973
		internal global::Loadout.Entry[] <$s_528>__3;

		// Token: 0x04001F26 RID: 7974
		internal int <$s_529>__4;

		// Token: 0x04001F27 RID: 7975
		internal global::Loadout.Entry <entry>__5;

		// Token: 0x04001F28 RID: 7976
		internal int $PC;

		// Token: 0x04001F29 RID: 7977
		internal global::Loadout.Entry $current;

		// Token: 0x04001F2A RID: 7978
		internal global::Loadout.Entry[][] <$>arrays;
	}
}
