using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x0200094B RID: 2379
public static class UITextMarkupUtility
{
	// Token: 0x060050CA RID: 20682 RVA: 0x0013CA58 File Offset: 0x0013AC58
	public static void SortMarkup(this global::System.Collections.Generic.List<global::UITextMarkup> list)
	{
		list.Sort(delegate(global::UITextMarkup x, global::UITextMarkup y)
		{
			int num = x.index.CompareTo(y.index);
			int result;
			if (num == 0)
			{
				byte mod = (byte)x.mod;
				result = mod.CompareTo((byte)y.mod);
			}
			else
			{
				result = num;
			}
			return result;
		});
	}

	// Token: 0x060050CB RID: 20683 RVA: 0x0013CA80 File Offset: 0x0013AC80
	public static string MarkUp(this global::System.Collections.Generic.List<global::UITextMarkup> list, string input)
	{
		int count;
		if (list == null || (count = list.Count) == 0)
		{
			return input;
		}
		int index = list[0].index;
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(input, 0, index, input.Length + count);
		int num = 0;
		global::UITextMarkup uitextMarkup = list[num];
		for (int i = uitextMarkup.index; i < input.Length; i++)
		{
			char c = input[i];
			if (i == uitextMarkup.index)
			{
				do
				{
					switch (uitextMarkup.mod)
					{
					case global::UITextMod.End:
						i = input.Length + 1;
						c = '\0';
						break;
					case global::UITextMod.Removed:
						c = '\0';
						break;
					case global::UITextMod.Replaced:
						stringBuilder.Append(uitextMarkup.value);
						c = '\0';
						break;
					case global::UITextMod.Added:
						stringBuilder.Append(uitextMarkup.value);
						break;
					}
					if (++num == count)
					{
						if (i < input.Length)
						{
							goto Block_4;
						}
					}
					else
					{
						uitextMarkup = list[num];
					}
				}
				while (uitextMarkup.index == i);
				IL_161:
				if (c != '\0')
				{
					stringBuilder.Append(c);
				}
				goto IL_186;
				Block_4:
				if (c != '\0')
				{
					stringBuilder.Append(input, i, input.Length - i);
				}
				else
				{
					if (++i >= input.Length)
					{
						goto IL_161;
					}
					stringBuilder.Append(input, i, input.Length - i);
				}
				i = input.Length + 1;
				goto IL_161;
			}
			if (c != '\0')
			{
				stringBuilder.Append(c);
			}
			IL_186:;
		}
		while (++num < count)
		{
			switch (uitextMarkup.mod)
			{
			case global::UITextMod.End:
				continue;
			case global::UITextMod.Added:
				stringBuilder.Append(uitextMarkup.value);
				continue;
			}
			global::UnityEngine.Debug.Log("Unsupported end markup " + uitextMarkup);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060050CC RID: 20684 RVA: 0x0013CC94 File Offset: 0x0013AE94
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static int <SortMarkup>m__34(global::UITextMarkup x, global::UITextMarkup y)
	{
		int num = x.index.CompareTo(y.index);
		int result;
		if (num == 0)
		{
			byte mod = (byte)x.mod;
			result = mod.CompareTo((byte)y.mod);
		}
		else
		{
			result = num;
		}
		return result;
	}

	// Token: 0x04002D85 RID: 11653
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Comparison<global::UITextMarkup> <>f__am$cache0;
}
