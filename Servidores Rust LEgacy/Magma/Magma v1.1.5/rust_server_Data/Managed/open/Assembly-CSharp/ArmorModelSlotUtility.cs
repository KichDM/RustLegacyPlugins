using System;
using System.Collections.Generic;

// Token: 0x0200062E RID: 1582
public static class ArmorModelSlotUtility
{
	// Token: 0x0600323E RID: 12862 RVA: 0x000C0624 File Offset: 0x000BE824
	public static global::ArmorModelSlotMask ToMask(this global::ArmorModelSlot slot)
	{
		return (global::ArmorModelSlotMask)(1 << (int)slot & 0xF);
	}

	// Token: 0x0600323F RID: 12863 RVA: 0x000C0630 File Offset: 0x000BE830
	public static global::ArmorModelSlotMask ToNotMask(this global::ArmorModelSlot slot)
	{
		return (global::ArmorModelSlotMask)(~(1 << (int)slot) & 0xF);
	}

	// Token: 0x06003240 RID: 12864 RVA: 0x000C063C File Offset: 0x000BE83C
	public static bool Contains(this global::ArmorModelSlotMask slotMask, global::ArmorModelSlot slot)
	{
		return slot < (global::ArmorModelSlot)4 && (slotMask & (global::ArmorModelSlotMask)(1 << (int)slot)) != (global::ArmorModelSlotMask)0;
	}

	// Token: 0x06003241 RID: 12865 RVA: 0x000C0658 File Offset: 0x000BE858
	public static bool Contains(this global::ArmorModelSlot slot, global::ArmorModelSlotMask slotMask)
	{
		return slot < (global::ArmorModelSlot)4 && (slotMask & (global::ArmorModelSlotMask)(1 << (int)slot)) != (global::ArmorModelSlotMask)0;
	}

	// Token: 0x06003242 RID: 12866 RVA: 0x000C0674 File Offset: 0x000BE874
	public static global::ArmorModelSlot[] ToArray(this global::ArmorModelSlotMask slotMask)
	{
		global::ArmorModelSlot[] array = global::ArmorModelSlotUtility.Mask2SlotArray.FlagToSlotArray[(int)(slotMask & (global::ArmorModelSlotMask.Feet | global::ArmorModelSlotMask.Legs | global::ArmorModelSlotMask.Torso | global::ArmorModelSlotMask.Head))];
		global::ArmorModelSlot[] array2 = new global::ArmorModelSlot[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i];
		}
		return array2;
	}

	// Token: 0x06003243 RID: 12867 RVA: 0x000C06B0 File Offset: 0x000BE8B0
	public static global::ArmorModelSlot[] EnumerateSlots(this global::ArmorModelSlotMask slotMask)
	{
		return global::ArmorModelSlotUtility.Mask2SlotArray.FlagToSlotArray[(int)(slotMask & (global::ArmorModelSlotMask.Feet | global::ArmorModelSlotMask.Legs | global::ArmorModelSlotMask.Torso | global::ArmorModelSlotMask.Head))];
	}

	// Token: 0x06003244 RID: 12868 RVA: 0x000C06BC File Offset: 0x000BE8BC
	public static int GetMaskedSlotCount(this global::ArmorModelSlotMask slotMask)
	{
		uint num = (uint)(slotMask & (global::ArmorModelSlotMask.Feet | global::ArmorModelSlotMask.Legs | global::ArmorModelSlotMask.Torso | global::ArmorModelSlotMask.Head));
		int num2 = 0;
		while (num != 0U)
		{
			num2++;
			num &= num - 1U;
		}
		return num2;
	}

	// Token: 0x06003245 RID: 12869 RVA: 0x000C06E8 File Offset: 0x000BE8E8
	public static int GetUnmaskedSlotCount(this global::ArmorModelSlotMask slotMask)
	{
		uint num = (uint)(~slotMask & (global::ArmorModelSlotMask.Feet | global::ArmorModelSlotMask.Legs | global::ArmorModelSlotMask.Torso | global::ArmorModelSlotMask.Head));
		int num2 = 0;
		while (num != 0U)
		{
			num2++;
			num &= num - 1U;
		}
		return num2;
	}

	// Token: 0x06003246 RID: 12870 RVA: 0x000C0714 File Offset: 0x000BE914
	public static int GetMaskedSlotCount(this global::ArmorModelSlot slot)
	{
		return (slot >= (global::ArmorModelSlot)4) ? 0 : 1;
	}

	// Token: 0x06003247 RID: 12871 RVA: 0x000C0724 File Offset: 0x000BE924
	public static int GetUnmaskedSlotCount(this global::ArmorModelSlot slot)
	{
		return (slot >= (global::ArmorModelSlot)4) ? 4 : 3;
	}

	// Token: 0x06003248 RID: 12872 RVA: 0x000C0734 File Offset: 0x000BE934
	public static string GetRendererName(this global::ArmorModelSlot slot)
	{
		return (slot >= (global::ArmorModelSlot)4) ? "Armor Renderer" : global::ArmorModelSlotUtility.RendererNames.Array[(int)slot];
	}

	// Token: 0x06003249 RID: 12873 RVA: 0x000C0750 File Offset: 0x000BE950
	public static global::System.Type GetArmorModelType(this global::ArmorModelSlot slot)
	{
		return (slot >= (global::ArmorModelSlot)4) ? null : global::ArmorModelSlotUtility.ClassToArmorModelSlot.ArmorModelSlotToType[slot];
	}

	// Token: 0x0600324A RID: 12874 RVA: 0x000C076C File Offset: 0x000BE96C
	public static global::ArmorModelSlot GetArmorModelSlotForClass<T>() where T : global::ArmorModel, new()
	{
		return global::ArmorModelSlotUtility.ClassToArmorModelSlot<T>.ArmorModelSlot;
	}

	// Token: 0x04001BFC RID: 7164
	public const int Count = 4;

	// Token: 0x04001BFD RID: 7165
	public const global::ArmorModelSlotMask All = global::ArmorModelSlotMask.Feet | global::ArmorModelSlotMask.Legs | global::ArmorModelSlotMask.Torso | global::ArmorModelSlotMask.Head;

	// Token: 0x04001BFE RID: 7166
	public const global::ArmorModelSlot Last = global::ArmorModelSlot.Head;

	// Token: 0x04001BFF RID: 7167
	public const global::ArmorModelSlot First = global::ArmorModelSlot.Feet;

	// Token: 0x04001C00 RID: 7168
	public const global::ArmorModelSlotMask None = (global::ArmorModelSlotMask)0;

	// Token: 0x04001C01 RID: 7169
	public const global::ArmorModelSlot Begin = global::ArmorModelSlot.Feet;

	// Token: 0x04001C02 RID: 7170
	public const global::ArmorModelSlot End = (global::ArmorModelSlot)4;

	// Token: 0x0200062F RID: 1583
	private static class RendererNames
	{
		// Token: 0x0600324B RID: 12875 RVA: 0x000C0774 File Offset: 0x000BE974
		static RendererNames()
		{
			for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
			{
				global::ArmorModelSlotUtility.RendererNames.Array[(int)armorModelSlot] = string.Format("{0} Renderer", armorModelSlot);
			}
		}

		// Token: 0x04001C03 RID: 7171
		public static readonly string[] Array = new string[4];
	}

	// Token: 0x02000630 RID: 1584
	private static class Mask2SlotArray
	{
		// Token: 0x0600324C RID: 12876 RVA: 0x000C07B8 File Offset: 0x000BE9B8
		static Mask2SlotArray()
		{
			for (int i = 0; i <= 0xF; i++)
			{
				int num = 0;
				for (int j = 0; j < 4; j++)
				{
					if ((i & 1 << j) == 1 << j)
					{
						num++;
					}
				}
				global::ArmorModelSlotUtility.Mask2SlotArray.FlagToSlotArray[i] = new global::ArmorModelSlot[num];
				int num2 = 0;
				for (int k = 0; k < 4; k++)
				{
					if ((i & 1 << k) == 1 << k)
					{
						global::ArmorModelSlotUtility.Mask2SlotArray.FlagToSlotArray[i][num2++] = (global::ArmorModelSlot)k;
					}
				}
			}
		}

		// Token: 0x04001C04 RID: 7172
		public static readonly global::ArmorModelSlot[][] FlagToSlotArray = new global::ArmorModelSlot[0x10][];
	}

	// Token: 0x02000631 RID: 1585
	private static class ClassToArmorModelSlot
	{
		// Token: 0x0600324D RID: 12877 RVA: 0x000C085C File Offset: 0x000BEA5C
		static ClassToArmorModelSlot()
		{
			global::System.Collections.Generic.List<global::System.Type> list = new global::System.Collections.Generic.List<global::System.Type>();
			foreach (global::System.Type type in typeof(global::ArmorModelSlotUtility.ClassToArmorModelSlot).Assembly.GetTypes())
			{
				if (type.IsSubclassOf(typeof(global::ArmorModel)) && !type.IsAbstract && type.IsDefined(typeof(global::ArmorModelSlotClassAttribute), false))
				{
					list.Add(type);
				}
			}
			global::ArmorModelSlotUtility.ClassToArmorModelSlot.ArmorModelSlotToType = new global::System.Collections.Generic.Dictionary<global::ArmorModelSlot, global::System.Type>(list.Count);
			foreach (global::System.Type type2 in list)
			{
				global::ArmorModelSlotClassAttribute armorModelSlotClassAttribute = (global::ArmorModelSlotClassAttribute)global::System.Attribute.GetCustomAttribute(type2, typeof(global::ArmorModelSlotClassAttribute));
				global::ArmorModelSlotUtility.ClassToArmorModelSlot.ArmorModelSlotToType.Add(armorModelSlotClassAttribute.ArmorModelSlot, type2);
			}
		}

		// Token: 0x04001C05 RID: 7173
		public static readonly global::System.Collections.Generic.Dictionary<global::ArmorModelSlot, global::System.Type> ArmorModelSlotToType;
	}

	// Token: 0x02000632 RID: 1586
	private static class ClassToArmorModelSlot<T> where T : global::ArmorModel, new()
	{
		// Token: 0x0600324E RID: 12878 RVA: 0x000C0964 File Offset: 0x000BEB64
		static ClassToArmorModelSlot()
		{
		}

		// Token: 0x04001C06 RID: 7174
		public static readonly global::ArmorModelSlot ArmorModelSlot = ((global::ArmorModelSlotClassAttribute)global::System.Attribute.GetCustomAttribute(typeof(T), typeof(global::ArmorModelSlotClassAttribute))).ArmorModelSlot;
	}
}
