using System;
using System.Collections.Generic;

// Token: 0x0200018B RID: 395
public static class DamageTypeNames
{
	// Token: 0x06000B91 RID: 2961 RVA: 0x0002CD04 File Offset: 0x0002AF04
	static DamageTypeNames()
	{
		global::DamageTypeNames.Strings = new string[6];
		global::DamageTypeNames.Values = new global::System.Collections.Generic.Dictionary<string, global::DamageTypeIndex>(6);
		for (global::DamageTypeIndex damageTypeIndex = global::DamageTypeIndex.damage_generic; damageTypeIndex < global::DamageTypeIndex.damage_last; damageTypeIndex++)
		{
			global::DamageTypeNames.Values.Add(global::DamageTypeNames.Strings[(int)damageTypeIndex] = damageTypeIndex.ToString().Substring("damage_".Length), damageTypeIndex);
		}
		uint num = 0x3FU;
		global::DamageTypeNames.Mask = (global::DamageTypeFlags)num;
		global::DamageTypeNames.Flags = new string[num];
		global::DamageTypeNames.Flags[0] = "none";
		for (uint num2 = 1U; num2 < num; num2 += 1U)
		{
			uint num3 = num2;
			int i = 0;
			while (i < 6)
			{
				if ((num2 & 1U << i) == 1U << i)
				{
					string str = global::DamageTypeNames.Strings[i];
					if ((num3 &= ~(1U << i)) == 0U)
					{
						break;
					}
					while ((long)(++i) < 6L)
					{
						if ((num2 & 1U << i) == 1U << i)
						{
							str = str + "|" + global::DamageTypeNames.Strings[i];
							num3 &= ~(1U << i);
							if (num3 == 0U)
							{
								break;
							}
						}
					}
					break;
				}
				else
				{
					i++;
				}
			}
		}
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x0002CE5C File Offset: 0x0002B05C
	public static bool Convert(string name, out global::DamageTypeIndex index)
	{
		return global::DamageTypeNames.Values.TryGetValue(name, out index);
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x0002CE6C File Offset: 0x0002B06C
	public static bool Convert(string[] names, out global::DamageTypeFlags flags)
	{
		for (int i = 0; i < names.Length; i++)
		{
			global::DamageTypeIndex damageTypeIndex;
			if (global::DamageTypeNames.Values.TryGetValue(names[i], out damageTypeIndex))
			{
				flags = (global::DamageTypeFlags)(1 << (int)damageTypeIndex);
				while (++i < names.Length)
				{
					if (global::DamageTypeNames.Values.TryGetValue(names[i], out damageTypeIndex))
					{
						flags |= (global::DamageTypeFlags)(1 << (int)damageTypeIndex);
					}
				}
				return true;
			}
		}
		flags = (global::DamageTypeFlags)0;
		return false;
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x0002CEE0 File Offset: 0x0002B0E0
	public static bool Convert(string name, out global::DamageTypeFlags flags)
	{
		global::DamageTypeIndex damageTypeIndex;
		if (global::DamageTypeNames.Values.TryGetValue(name, out damageTypeIndex))
		{
			flags = (global::DamageTypeFlags)(1 << (int)damageTypeIndex);
			return true;
		}
		if (name.Length == 0 || name == "none")
		{
			flags = (global::DamageTypeFlags)0;
			return true;
		}
		return global::DamageTypeNames.Convert(name.Split(global::DamageTypeNames.SplitCharacters, global::System.StringSplitOptions.RemoveEmptyEntries), out flags);
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x0002CF3C File Offset: 0x0002B13C
	public static bool Convert(global::DamageTypeIndex index, out global::DamageTypeFlags flags)
	{
		flags = (global::DamageTypeFlags)(1 << (int)index);
		return (flags & global::DamageTypeNames.Mask) == flags;
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x0002CF54 File Offset: 0x0002B154
	public static bool Convert(global::DamageTypeIndex index, out string name)
	{
		if (index == global::DamageTypeIndex.damage_generic || (index > global::DamageTypeIndex.damage_generic && index < global::DamageTypeIndex.damage_last))
		{
			name = global::DamageTypeNames.Strings[(int)index];
			return true;
		}
		name = null;
		return false;
	}

	// Token: 0x040007E5 RID: 2021
	private static readonly string[] Strings;

	// Token: 0x040007E6 RID: 2022
	private static readonly string[] Flags;

	// Token: 0x040007E7 RID: 2023
	private static readonly global::System.Collections.Generic.Dictionary<string, global::DamageTypeIndex> Values;

	// Token: 0x040007E8 RID: 2024
	private static readonly global::DamageTypeFlags Mask;

	// Token: 0x040007E9 RID: 2025
	private static readonly char[] SplitCharacters = new char[]
	{
		'|'
	};
}
