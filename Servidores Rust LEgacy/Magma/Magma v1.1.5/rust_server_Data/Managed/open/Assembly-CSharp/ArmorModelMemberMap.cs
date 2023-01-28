using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000623 RID: 1571
[global::System.Serializable]
public struct ArmorModelMemberMap : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ArmorModel>, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>
{
	// Token: 0x060031F5 RID: 12789 RVA: 0x000BF7FC File Offset: 0x000BD9FC
	public ArmorModelMemberMap(global::ArmorModelMemberMap<global::ArmorModel> map)
	{
		this = default(global::ArmorModelMemberMap);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = map[armorModelSlot];
		}
	}

	// Token: 0x060031F6 RID: 12790 RVA: 0x000BF83C File Offset: 0x000BDA3C
	global::System.Collections.Generic.IEnumerator<global::ArmorModel> global::System.Collections.Generic.IEnumerable<global::ArmorModel>.GetEnumerator()
	{
		return new global::ArmorModelMemberMap.Enumerator(this);
	}

	// Token: 0x060031F7 RID: 12791 RVA: 0x000BF850 File Offset: 0x000BDA50
	global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>.GetEnumerator()
	{
		return new global::ArmorModelMemberMap.Enumerator(this);
	}

	// Token: 0x060031F8 RID: 12792 RVA: 0x000BF864 File Offset: 0x000BDA64
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return new global::ArmorModelMemberMap.Enumerator(this);
	}

	// Token: 0x060031F9 RID: 12793 RVA: 0x000BF878 File Offset: 0x000BDA78
	public T GetArmorModel<T>() where T : global::ArmorModel, new()
	{
		return (T)((object)this[global::ArmorModelSlotUtility.GetArmorModelSlotForClass<T>()]);
	}

	// Token: 0x060031FA RID: 12794 RVA: 0x000BF88C File Offset: 0x000BDA8C
	public void SetArmorModel<T>(T armorModel) where T : global::ArmorModel, new()
	{
		this[global::ArmorModelSlotUtility.GetArmorModelSlotForClass<T>()] = armorModel;
	}

	// Token: 0x060031FB RID: 12795 RVA: 0x000BF8A0 File Offset: 0x000BDAA0
	public global::ArmorModel GetArmorModel(global::ArmorModelSlot slot)
	{
		return this[slot];
	}

	// Token: 0x060031FC RID: 12796 RVA: 0x000BF8AC File Offset: 0x000BDAAC
	public global::ArmorModelMemberMap.Enumerator GetEnumerator()
	{
		return new global::ArmorModelMemberMap.Enumerator(this);
	}

	// Token: 0x060031FD RID: 12797 RVA: 0x000BF8BC File Offset: 0x000BDABC
	public global::ArmorModelMemberMap<global::ArmorModel> ToGenericArmorModelMap()
	{
		global::ArmorModelMemberMap<global::ArmorModel> result = default(global::ArmorModelMemberMap<global::ArmorModel>);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			result[armorModelSlot] = this[armorModelSlot];
		}
		return result;
	}

	// Token: 0x060031FE RID: 12798 RVA: 0x000BF8F8 File Offset: 0x000BDAF8
	public int CopyTo(global::ArmorModel[] array, int offset, int maxCount)
	{
		int num = (maxCount >= 4) ? 4 : maxCount;
		for (int i = 0; i < 4; i++)
		{
			array[offset++] = this[(global::ArmorModelSlot)i];
		}
		return offset;
	}

	// Token: 0x060031FF RID: 12799 RVA: 0x000BF938 File Offset: 0x000BDB38
	public void CopyFrom(global::ArmorModel[] array, int offset)
	{
		for (int i = 0; i < 4; i++)
		{
			this[(global::ArmorModelSlot)i] = array[offset++];
		}
	}

	// Token: 0x17000A6A RID: 2666
	public global::ArmorModel this[global::ArmorModelSlot slot]
	{
		get
		{
			switch (slot)
			{
			case global::ArmorModelSlot.Feet:
				return this.feet;
			case global::ArmorModelSlot.Legs:
				return this.legs;
			case global::ArmorModelSlot.Torso:
				return this.torso;
			case global::ArmorModelSlot.Head:
				return this.head;
			default:
				return null;
			}
		}
		set
		{
			switch (slot)
			{
			case global::ArmorModelSlot.Feet:
				this.feet = (global::ArmorModelFeet)value;
				break;
			case global::ArmorModelSlot.Legs:
				this.legs = (global::ArmorModelLegs)value;
				break;
			case global::ArmorModelSlot.Torso:
				this.torso = (global::ArmorModelTorso)value;
				break;
			case global::ArmorModelSlot.Head:
				this.head = (global::ArmorModelHead)value;
				break;
			}
		}
	}

	// Token: 0x06003202 RID: 12802 RVA: 0x000BFA24 File Offset: 0x000BDC24
	public static explicit operator global::ArmorModelMemberMap(global::ArmorModelMemberMap<global::ArmorModel> generic)
	{
		global::ArmorModelMemberMap result = default(global::ArmorModelMemberMap);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			result[armorModelSlot] = generic[armorModelSlot];
		}
		return result;
	}

	// Token: 0x06003203 RID: 12803 RVA: 0x000BFA60 File Offset: 0x000BDC60
	public static implicit operator global::ArmorModelMemberMap<global::ArmorModel>(global::ArmorModelMemberMap self)
	{
		global::ArmorModelMemberMap<global::ArmorModel> result = default(global::ArmorModelMemberMap<global::ArmorModel>);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			result[armorModelSlot] = self[armorModelSlot];
		}
		return result;
	}

	// Token: 0x04001BE2 RID: 7138
	public global::ArmorModelFeet feet;

	// Token: 0x04001BE3 RID: 7139
	public global::ArmorModelLegs legs;

	// Token: 0x04001BE4 RID: 7140
	public global::ArmorModelTorso torso;

	// Token: 0x04001BE5 RID: 7141
	public global::ArmorModelHead head;

	// Token: 0x02000624 RID: 1572
	public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::ArmorModel>, global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>
	{
		// Token: 0x06003204 RID: 12804 RVA: 0x000BFA9C File Offset: 0x000BDC9C
		internal Enumerator(global::ArmorModelMemberMap collection)
		{
			this.collection = collection;
			this.index = -1;
		}

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x06003205 RID: 12805 RVA: 0x000BFAAC File Offset: 0x000BDCAC
		global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel> global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>.Current
		{
			get
			{
				if (this.index > 0 && this.index < 4)
				{
					return new global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>((global::ArmorModelSlot)this.index, this.collection[(global::ArmorModelSlot)this.index]);
				}
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x06003206 RID: 12806 RVA: 0x000BFAF8 File Offset: 0x000BDCF8
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x06003207 RID: 12807 RVA: 0x000BFB00 File Offset: 0x000BDD00
		public global::ArmorModel Current
		{
			get
			{
				return (this.index <= 0 || this.index >= 4) ? null : this.collection[(global::ArmorModelSlot)this.index];
			}
		}

		// Token: 0x06003208 RID: 12808 RVA: 0x000BFB40 File Offset: 0x000BDD40
		public bool MoveNext()
		{
			return ++this.index < 4;
		}

		// Token: 0x06003209 RID: 12809 RVA: 0x000BFB64 File Offset: 0x000BDD64
		public void Reset()
		{
			this.index = -1;
		}

		// Token: 0x0600320A RID: 12810 RVA: 0x000BFB70 File Offset: 0x000BDD70
		public void Dispose()
		{
			this = default(global::ArmorModelMemberMap.Enumerator);
		}

		// Token: 0x04001BE6 RID: 7142
		private global::ArmorModelMemberMap collection;

		// Token: 0x04001BE7 RID: 7143
		private int index;
	}
}
