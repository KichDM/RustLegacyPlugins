using System;
using System.Collections.Generic;

// Token: 0x020008DE RID: 2270
[global::System.Serializable]
public class BMGlyph
{
	// Token: 0x06004DE0 RID: 19936 RVA: 0x0012AA0C File Offset: 0x00128C0C
	public BMGlyph()
	{
	}

	// Token: 0x06004DE1 RID: 19937 RVA: 0x0012AA14 File Offset: 0x00128C14
	public int GetKerning(int previousChar)
	{
		if (this.kerning != null)
		{
			int i = 0;
			int count = this.kerning.Count;
			while (i < count)
			{
				global::BMGlyph.Kerning kerning = this.kerning[i];
				if (kerning.previousChar == previousChar)
				{
					return kerning.amount;
				}
				i++;
			}
		}
		return 0;
	}

	// Token: 0x06004DE2 RID: 19938 RVA: 0x0012AA70 File Offset: 0x00128C70
	public void SetKerning(int previousChar, int amount)
	{
		if (this.kerning == null)
		{
			this.kerning = new global::System.Collections.Generic.List<global::BMGlyph.Kerning>();
		}
		for (int i = 0; i < this.kerning.Count; i++)
		{
			if (this.kerning[i].previousChar == previousChar)
			{
				global::BMGlyph.Kerning value = this.kerning[i];
				value.amount = amount;
				this.kerning[i] = value;
				return;
			}
		}
		global::BMGlyph.Kerning item = default(global::BMGlyph.Kerning);
		item.previousChar = previousChar;
		item.amount = amount;
		this.kerning.Add(item);
	}

	// Token: 0x06004DE3 RID: 19939 RVA: 0x0012AB10 File Offset: 0x00128D10
	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
		int num = this.x + this.width;
		int num2 = this.y + this.height;
		if (this.x < xMin)
		{
			int num3 = xMin - this.x;
			this.x += num3;
			this.width -= num3;
			this.offsetX += num3;
		}
		if (this.y < yMin)
		{
			int num4 = yMin - this.y;
			this.y += num4;
			this.height -= num4;
			this.offsetY += num4;
		}
		if (num > xMax)
		{
			this.width -= num - xMax;
		}
		if (num2 > yMax)
		{
			this.height -= num2 - yMax;
		}
	}

	// Token: 0x04002AE9 RID: 10985
	public int index;

	// Token: 0x04002AEA RID: 10986
	public int x;

	// Token: 0x04002AEB RID: 10987
	public int y;

	// Token: 0x04002AEC RID: 10988
	public int width;

	// Token: 0x04002AED RID: 10989
	public int height;

	// Token: 0x04002AEE RID: 10990
	public int offsetX;

	// Token: 0x04002AEF RID: 10991
	public int offsetY;

	// Token: 0x04002AF0 RID: 10992
	public int advance;

	// Token: 0x04002AF1 RID: 10993
	public int channel;

	// Token: 0x04002AF2 RID: 10994
	public global::System.Collections.Generic.List<global::BMGlyph.Kerning> kerning;

	// Token: 0x020008DF RID: 2271
	public struct Kerning
	{
		// Token: 0x04002AF3 RID: 10995
		public int previousChar;

		// Token: 0x04002AF4 RID: 10996
		public int amount;
	}
}
