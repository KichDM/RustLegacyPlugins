using System;
using System.Text.RegularExpressions;

// Token: 0x0200086A RID: 2154
public struct dfMarkupBorders
{
	// Token: 0x06004AB2 RID: 19122 RVA: 0x00118F00 File Offset: 0x00117100
	public dfMarkupBorders(int left, int right, int top, int bottom)
	{
		this.left = left;
		this.top = top;
		this.right = right;
		this.bottom = bottom;
	}

	// Token: 0x17000DFA RID: 3578
	// (get) Token: 0x06004AB3 RID: 19123 RVA: 0x00118F20 File Offset: 0x00117120
	public int horizontal
	{
		get
		{
			return this.left + this.right;
		}
	}

	// Token: 0x17000DFB RID: 3579
	// (get) Token: 0x06004AB4 RID: 19124 RVA: 0x00118F30 File Offset: 0x00117130
	public int vertical
	{
		get
		{
			return this.top + this.bottom;
		}
	}

	// Token: 0x06004AB5 RID: 19125 RVA: 0x00118F40 File Offset: 0x00117140
	public static global::dfMarkupBorders Parse(string value)
	{
		global::dfMarkupBorders result = default(global::dfMarkupBorders);
		value = global::System.Text.RegularExpressions.Regex.Replace(value, "\\s+", " ");
		string[] array = value.Split(new char[]
		{
			' '
		});
		if (array.Length == 1)
		{
			int num = global::dfMarkupStyle.ParseSize(value, 0);
			result.left = (result.right = num);
			result.top = (result.bottom = num);
		}
		else if (array.Length == 2)
		{
			int num2 = global::dfMarkupStyle.ParseSize(array[0], 0);
			result.top = (result.bottom = num2);
			int num3 = global::dfMarkupStyle.ParseSize(array[1], 0);
			result.left = (result.right = num3);
		}
		else if (array.Length == 3)
		{
			int num4 = global::dfMarkupStyle.ParseSize(array[0], 0);
			result.top = num4;
			int num5 = global::dfMarkupStyle.ParseSize(array[1], 0);
			result.left = (result.right = num5);
			int num6 = global::dfMarkupStyle.ParseSize(array[2], 0);
			result.bottom = num6;
		}
		else if (array.Length == 4)
		{
			int num7 = global::dfMarkupStyle.ParseSize(array[0], 0);
			result.top = num7;
			int num8 = global::dfMarkupStyle.ParseSize(array[1], 0);
			result.right = num8;
			int num9 = global::dfMarkupStyle.ParseSize(array[2], 0);
			result.bottom = num9;
			int num10 = global::dfMarkupStyle.ParseSize(array[3], 0);
			result.left = num10;
		}
		return result;
	}

	// Token: 0x06004AB6 RID: 19126 RVA: 0x001190B4 File Offset: 0x001172B4
	public override string ToString()
	{
		return string.Format("[T:{0},R:{1},L:{2},B:{3}]", new object[]
		{
			this.top,
			this.right,
			this.left,
			this.bottom
		});
	}

	// Token: 0x040027C2 RID: 10178
	public int left;

	// Token: 0x040027C3 RID: 10179
	public int top;

	// Token: 0x040027C4 RID: 10180
	public int right;

	// Token: 0x040027C5 RID: 10181
	public int bottom;
}
