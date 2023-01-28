using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008DC RID: 2268
[global::System.Serializable]
public class BMFont
{
	// Token: 0x06004DC7 RID: 19911 RVA: 0x0012A320 File Offset: 0x00128520
	public BMFont()
	{
	}

	// Token: 0x17000E6E RID: 3694
	// (get) Token: 0x06004DC8 RID: 19912 RVA: 0x0012A340 File Offset: 0x00128540
	public bool isValid
	{
		get
		{
			return this.mSaved.Count > 0 || this.LegacyCheck();
		}
	}

	// Token: 0x17000E6F RID: 3695
	// (get) Token: 0x06004DC9 RID: 19913 RVA: 0x0012A35C File Offset: 0x0012855C
	// (set) Token: 0x06004DCA RID: 19914 RVA: 0x0012A364 File Offset: 0x00128564
	public int charSize
	{
		get
		{
			return this.mSize;
		}
		set
		{
			this.mSize = value;
		}
	}

	// Token: 0x17000E70 RID: 3696
	// (get) Token: 0x06004DCB RID: 19915 RVA: 0x0012A370 File Offset: 0x00128570
	// (set) Token: 0x06004DCC RID: 19916 RVA: 0x0012A378 File Offset: 0x00128578
	public int baseOffset
	{
		get
		{
			return this.mBase;
		}
		set
		{
			this.mBase = value;
		}
	}

	// Token: 0x17000E71 RID: 3697
	// (get) Token: 0x06004DCD RID: 19917 RVA: 0x0012A384 File Offset: 0x00128584
	// (set) Token: 0x06004DCE RID: 19918 RVA: 0x0012A38C File Offset: 0x0012858C
	public int texWidth
	{
		get
		{
			return this.mWidth;
		}
		set
		{
			this.mWidth = value;
		}
	}

	// Token: 0x17000E72 RID: 3698
	// (get) Token: 0x06004DCF RID: 19919 RVA: 0x0012A398 File Offset: 0x00128598
	// (set) Token: 0x06004DD0 RID: 19920 RVA: 0x0012A3A0 File Offset: 0x001285A0
	public int texHeight
	{
		get
		{
			return this.mHeight;
		}
		set
		{
			this.mHeight = value;
		}
	}

	// Token: 0x17000E73 RID: 3699
	// (get) Token: 0x06004DD1 RID: 19921 RVA: 0x0012A3AC File Offset: 0x001285AC
	public int glyphCount
	{
		get
		{
			return (!this.isValid) ? 0 : this.mSaved.Count;
		}
	}

	// Token: 0x17000E74 RID: 3700
	// (get) Token: 0x06004DD2 RID: 19922 RVA: 0x0012A3CC File Offset: 0x001285CC
	// (set) Token: 0x06004DD3 RID: 19923 RVA: 0x0012A3D4 File Offset: 0x001285D4
	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			this.mSpriteName = value;
		}
	}

	// Token: 0x17000E75 RID: 3701
	// (get) Token: 0x06004DD4 RID: 19924 RVA: 0x0012A3E0 File Offset: 0x001285E0
	public global::System.Collections.Generic.List<global::BMSymbol> symbols
	{
		get
		{
			return this.mSymbols;
		}
	}

	// Token: 0x06004DD5 RID: 19925 RVA: 0x0012A3E8 File Offset: 0x001285E8
	public bool LegacyCheck()
	{
		if (this.mGlyphs != null && this.mGlyphs.Length > 0)
		{
			int i = 0;
			int num = this.mGlyphs.Length;
			while (i < num)
			{
				global::BMGlyph bmglyph = this.mGlyphs[i];
				if (bmglyph != null)
				{
					bmglyph.index = i;
					this.mSaved.Add(bmglyph);
					while (++i < num)
					{
						if (bmglyph != null)
						{
							bmglyph.index = i;
							this.mSaved.Add(bmglyph);
						}
					}
					this.mGlyphs = null;
					return true;
				}
				i++;
			}
			this.mGlyphs = null;
			return false;
		}
		return false;
	}

	// Token: 0x06004DD6 RID: 19926 RVA: 0x0012A488 File Offset: 0x00128688
	private int GetArraySize(int index)
	{
		if (index < 0x100)
		{
			return 0x100;
		}
		if (index < 0x10000)
		{
			return 0x10000;
		}
		if (index < 0x40000)
		{
			return 0x40000;
		}
		return 0;
	}

	// Token: 0x06004DD7 RID: 19927 RVA: 0x0012A4CC File Offset: 0x001286CC
	private static global::System.Collections.Generic.Dictionary<int, global::BMGlyph> CreateGlyphDictionary()
	{
		return new global::System.Collections.Generic.Dictionary<int, global::BMGlyph>();
	}

	// Token: 0x06004DD8 RID: 19928 RVA: 0x0012A4D4 File Offset: 0x001286D4
	private static global::System.Collections.Generic.Dictionary<int, global::BMGlyph> CreateGlyphDictionary(int cap)
	{
		return new global::System.Collections.Generic.Dictionary<int, global::BMGlyph>(cap);
	}

	// Token: 0x06004DD9 RID: 19929 RVA: 0x0012A4DC File Offset: 0x001286DC
	public global::BMFont.GetOrCreateGlyphResult GetOrCreateGlyph(int index, out global::BMGlyph glyph)
	{
		if (!this.mDictMade)
		{
			this.mDictMade = true;
			this.mDictAny = true;
			int count = this.mSaved.Count;
			if (count == 0 && this.LegacyCheck())
			{
				count = this.mSaved.Count;
			}
			if (count > 0)
			{
				this.mDict = global::BMFont.CreateGlyphDictionary(count + 1);
				for (int i = count - 1; i >= 0; i--)
				{
					global::BMGlyph bmglyph = this.mSaved[i];
					this.mDict.Add(bmglyph.index, bmglyph);
					if (bmglyph.index == index)
					{
						glyph = bmglyph;
						while (--i >= 0)
						{
							bmglyph = this.mSaved[i];
							this.mDict.Add(bmglyph.index, bmglyph);
						}
						return global::BMFont.GetOrCreateGlyphResult.Found;
					}
				}
			}
			else
			{
				this.mDict = global::BMFont.CreateGlyphDictionary();
			}
		}
		else if (this.mDictAny)
		{
			if (this.mDict.TryGetValue(index, out glyph))
			{
				return global::BMFont.GetOrCreateGlyphResult.Found;
			}
		}
		else
		{
			this.mDict = global::BMFont.CreateGlyphDictionary();
			this.mDictAny = true;
		}
		glyph = new global::BMGlyph
		{
			index = index
		};
		this.mDict.Add(index, glyph);
		return global::BMFont.GetOrCreateGlyphResult.Created;
	}

	// Token: 0x06004DDA RID: 19930 RVA: 0x0012A620 File Offset: 0x00128820
	public bool GetGlyph(int index, out global::BMGlyph glyph)
	{
		if (!this.mDictMade)
		{
			this.mDictMade = true;
			int count = this.mSaved.Count;
			if (count == 0 && this.LegacyCheck())
			{
				count = this.mSaved.Count;
			}
			this.mDictAny = (count > 0);
			if (this.mDictAny)
			{
				this.mDict = global::BMFont.CreateGlyphDictionary(count);
				for (int i = count - 1; i >= 0; i--)
				{
					global::BMGlyph bmglyph = this.mSaved[i];
					this.mDict.Add(bmglyph.index, bmglyph);
					if (bmglyph.index == index)
					{
						glyph = bmglyph;
						while (--i >= 0)
						{
							bmglyph = this.mSaved[i];
							this.mDict.Add(bmglyph.index, bmglyph);
						}
						return true;
					}
				}
			}
		}
		else if (this.mDictAny)
		{
			return this.mDict.TryGetValue(index, out glyph);
		}
		glyph = null;
		return false;
	}

	// Token: 0x06004DDB RID: 19931 RVA: 0x0012A720 File Offset: 0x00128920
	public bool ContainsGlyph(int index)
	{
		if (!this.mDictMade)
		{
			this.mDictMade = true;
			int count = this.mSaved.Count;
			if (count == 0 && this.LegacyCheck())
			{
				count = this.mSaved.Count;
			}
			this.mDictAny = (count > 0);
			if (this.mDictAny)
			{
				this.mDict = global::BMFont.CreateGlyphDictionary(count);
				for (int i = count - 1; i >= 0; i--)
				{
					global::BMGlyph bmglyph = this.mSaved[i];
					this.mDict.Add(bmglyph.index, bmglyph);
					if (bmglyph.index == index)
					{
						while (--i >= 0)
						{
							bmglyph = this.mSaved[i];
							this.mDict.Add(bmglyph.index, bmglyph);
						}
						return true;
					}
				}
			}
		}
		else if (this.mDictAny && this.mDict.ContainsKey(index))
		{
			return true;
		}
		return false;
	}

	// Token: 0x06004DDC RID: 19932 RVA: 0x0012A820 File Offset: 0x00128A20
	public global::BMSymbol GetSymbol(string sequence, bool createIfMissing)
	{
		int i = 0;
		int count = this.mSymbols.Count;
		while (i < count)
		{
			global::BMSymbol bmsymbol = this.mSymbols[i];
			if (bmsymbol.sequence == sequence)
			{
				return bmsymbol;
			}
			i++;
		}
		if (createIfMissing)
		{
			global::BMSymbol bmsymbol2 = new global::BMSymbol();
			bmsymbol2.sequence = sequence;
			this.mSymbols.Add(bmsymbol2);
			return bmsymbol2;
		}
		return null;
	}

	// Token: 0x06004DDD RID: 19933 RVA: 0x0012A890 File Offset: 0x00128A90
	public bool MatchSymbol(string text, int offset, int textLength, out global::BMSymbol symbol)
	{
		int count = this.mSymbols.Count;
		if (count > 0)
		{
			textLength -= offset;
			if (textLength > 0)
			{
				for (int i = 0; i < count; i++)
				{
					global::BMSymbol bmsymbol = this.mSymbols[i];
					int length = bmsymbol.sequence.Length;
					if (length != 0 && textLength >= length)
					{
						if (string.Compare(bmsymbol.sequence, 0, text, offset, length) == 0)
						{
							symbol = bmsymbol;
							if (length < textLength && ++i < count)
							{
								int num = length;
								do
								{
									bmsymbol = this.mSymbols[i];
									length = bmsymbol.sequence.Length;
									if (textLength >= length && length > num)
									{
										if (string.Compare(bmsymbol.sequence, 0, text, offset, length) == 0)
										{
											num = length;
											symbol = bmsymbol;
										}
									}
								}
								while (++i < count);
							}
							return true;
						}
					}
				}
			}
		}
		symbol = null;
		return false;
	}

	// Token: 0x06004DDE RID: 19934 RVA: 0x0012A980 File Offset: 0x00128B80
	public void Clear()
	{
		this.mGlyphs = null;
		this.mDict = null;
		this.mDictAny = (this.mDictMade = false);
		this.mSaved.Clear();
	}

	// Token: 0x06004DDF RID: 19935 RVA: 0x0012A9B8 File Offset: 0x00128BB8
	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
		if (this.isValid)
		{
			int i = 0;
			int count = this.mSaved.Count;
			while (i < count)
			{
				global::BMGlyph bmglyph = this.mSaved[i];
				if (bmglyph != null)
				{
					bmglyph.Trim(xMin, yMin, xMax, yMax);
				}
				i++;
			}
		}
	}

	// Token: 0x04002ADA RID: 10970
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::BMGlyph[] mGlyphs;

	// Token: 0x04002ADB RID: 10971
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mSize;

	// Token: 0x04002ADC RID: 10972
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mBase;

	// Token: 0x04002ADD RID: 10973
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mWidth;

	// Token: 0x04002ADE RID: 10974
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mHeight;

	// Token: 0x04002ADF RID: 10975
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string mSpriteName;

	// Token: 0x04002AE0 RID: 10976
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::BMGlyph> mSaved = new global::System.Collections.Generic.List<global::BMGlyph>();

	// Token: 0x04002AE1 RID: 10977
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::BMSymbol> mSymbols = new global::System.Collections.Generic.List<global::BMSymbol>();

	// Token: 0x04002AE2 RID: 10978
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Dictionary<int, global::BMGlyph> mDict;

	// Token: 0x04002AE3 RID: 10979
	[global::System.NonSerialized]
	private bool mDictMade;

	// Token: 0x04002AE4 RID: 10980
	[global::System.NonSerialized]
	private bool mDictAny;

	// Token: 0x020008DD RID: 2269
	public enum GetOrCreateGlyphResult : sbyte
	{
		// Token: 0x04002AE6 RID: 10982
		Found = -1,
		// Token: 0x04002AE7 RID: 10983
		Failed,
		// Token: 0x04002AE8 RID: 10984
		Created
	}
}
