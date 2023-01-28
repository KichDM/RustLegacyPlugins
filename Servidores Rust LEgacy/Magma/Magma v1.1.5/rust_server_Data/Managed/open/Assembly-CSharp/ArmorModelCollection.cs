using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200061F RID: 1567
[global::System.Serializable]
public class ArmorModelCollection : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ArmorModel>, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>
{
	// Token: 0x060031CA RID: 12746 RVA: 0x000BF168 File Offset: 0x000BD368
	public ArmorModelCollection()
	{
	}

	// Token: 0x060031CB RID: 12747 RVA: 0x000BF170 File Offset: 0x000BD370
	public ArmorModelCollection(global::ArmorModelMemberMap map) : this()
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = map[armorModelSlot];
		}
	}

	// Token: 0x060031CC RID: 12748 RVA: 0x000BF1A4 File Offset: 0x000BD3A4
	public ArmorModelCollection(global::ArmorModelMemberMap<global::ArmorModel> map)
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = map[armorModelSlot];
		}
	}

	// Token: 0x060031CD RID: 12749 RVA: 0x000BF1D8 File Offset: 0x000BD3D8
	global::System.Collections.Generic.IEnumerator<global::ArmorModel> global::System.Collections.Generic.IEnumerable<global::ArmorModel>.GetEnumerator()
	{
		return new global::ArmorModelCollection.Enumerator(this);
	}

	// Token: 0x060031CE RID: 12750 RVA: 0x000BF1E8 File Offset: 0x000BD3E8
	global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>.GetEnumerator()
	{
		return new global::ArmorModelCollection.Enumerator(this);
	}

	// Token: 0x060031CF RID: 12751 RVA: 0x000BF1F8 File Offset: 0x000BD3F8
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return new global::ArmorModelCollection.Enumerator(this);
	}

	// Token: 0x060031D0 RID: 12752 RVA: 0x000BF208 File Offset: 0x000BD408
	public T GetArmorModel<T>() where T : global::ArmorModel, new()
	{
		return (T)((object)this[global::ArmorModelSlotUtility.GetArmorModelSlotForClass<T>()]);
	}

	// Token: 0x060031D1 RID: 12753 RVA: 0x000BF21C File Offset: 0x000BD41C
	public void SetArmorModel<T>(T armorModel) where T : global::ArmorModel, new()
	{
		this[global::ArmorModelSlotUtility.GetArmorModelSlotForClass<T>()] = armorModel;
	}

	// Token: 0x060031D2 RID: 12754 RVA: 0x000BF230 File Offset: 0x000BD430
	public global::ArmorModel GetArmorModel(global::ArmorModelSlot slot)
	{
		return this[slot];
	}

	// Token: 0x060031D3 RID: 12755 RVA: 0x000BF23C File Offset: 0x000BD43C
	public global::ArmorModelCollection.Enumerator GetEnumerator()
	{
		return new global::ArmorModelCollection.Enumerator(this);
	}

	// Token: 0x060031D4 RID: 12756 RVA: 0x000BF244 File Offset: 0x000BD444
	public int CopyTo(global::ArmorModel[] array, int offset, int maxCount)
	{
		int num = (maxCount >= 4) ? 4 : maxCount;
		for (int i = 0; i < 4; i++)
		{
			array[offset++] = this[(global::ArmorModelSlot)i];
		}
		return offset;
	}

	// Token: 0x060031D5 RID: 12757 RVA: 0x000BF284 File Offset: 0x000BD484
	public void CopyFrom(global::ArmorModel[] array, int offset)
	{
		for (int i = 0; i < 4; i++)
		{
			this[(global::ArmorModelSlot)i] = array[offset++];
		}
	}

	// Token: 0x060031D6 RID: 12758 RVA: 0x000BF2B4 File Offset: 0x000BD4B4
	public global::ArmorModelMemberMap ToMemberMap()
	{
		global::ArmorModelMemberMap result = default(global::ArmorModelMemberMap);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			result[armorModelSlot] = this[armorModelSlot];
		}
		return result;
	}

	// Token: 0x17000A62 RID: 2658
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

	// Token: 0x04001BD6 RID: 7126
	public global::ArmorModelFeet feet;

	// Token: 0x04001BD7 RID: 7127
	public global::ArmorModelLegs legs;

	// Token: 0x04001BD8 RID: 7128
	public global::ArmorModelTorso torso;

	// Token: 0x04001BD9 RID: 7129
	public global::ArmorModelHead head;

	// Token: 0x02000620 RID: 1568
	public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::ArmorModel>, global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, global::ArmorModel>>
	{
		// Token: 0x060031D9 RID: 12761 RVA: 0x000BF3AC File Offset: 0x000BD5AC
		internal Enumerator(global::ArmorModelCollection collection)
		{
			this.collection = collection;
			this.index = -1;
		}

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x060031DA RID: 12762 RVA: 0x000BF3BC File Offset: 0x000BD5BC
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

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x060031DB RID: 12763 RVA: 0x000BF408 File Offset: 0x000BD608
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x060031DC RID: 12764 RVA: 0x000BF410 File Offset: 0x000BD610
		public global::ArmorModel Current
		{
			get
			{
				return (this.index <= 0 || this.index >= 4) ? null : this.collection[(global::ArmorModelSlot)this.index];
			}
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x000BF450 File Offset: 0x000BD650
		public bool MoveNext()
		{
			return ++this.index < 4;
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x000BF474 File Offset: 0x000BD674
		public void Reset()
		{
			this.index = -1;
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x000BF480 File Offset: 0x000BD680
		public void Dispose()
		{
			this = default(global::ArmorModelCollection.Enumerator);
		}

		// Token: 0x04001BDA RID: 7130
		private global::ArmorModelCollection collection;

		// Token: 0x04001BDB RID: 7131
		private int index;
	}
}
