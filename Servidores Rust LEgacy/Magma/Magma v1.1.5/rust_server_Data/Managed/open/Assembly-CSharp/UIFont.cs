using System;
using System.Collections.Generic;
using System.Text;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x0200094C RID: 2380
[global::UnityEngine.AddComponentMenu("NGUI/UI/Font")]
[global::UnityEngine.ExecuteInEditMode]
public class UIFont : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060050CD RID: 20685 RVA: 0x0013CCD8 File Offset: 0x0013AED8
	public UIFont()
	{
	}

	// Token: 0x060050CE RID: 20686 RVA: 0x0013CD18 File Offset: 0x0013AF18
	// Note: this type is marked as 'beforefieldinit'.
	static UIFont()
	{
	}

	// Token: 0x17000F04 RID: 3844
	// (get) Token: 0x060050CF RID: 20687 RVA: 0x0013CD5C File Offset: 0x0013AF5C
	public global::BMFont bmFont
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mFont : this.mReplacement.bmFont;
		}
	}

	// Token: 0x17000F05 RID: 3845
	// (get) Token: 0x060050D0 RID: 20688 RVA: 0x0013CD88 File Offset: 0x0013AF88
	public int texWidth
	{
		get
		{
			return (!(this.mReplacement != null)) ? ((this.mFont == null) ? 1 : this.mFont.texWidth) : this.mReplacement.texWidth;
		}
	}

	// Token: 0x17000F06 RID: 3846
	// (get) Token: 0x060050D1 RID: 20689 RVA: 0x0013CDC8 File Offset: 0x0013AFC8
	public int texHeight
	{
		get
		{
			return (!(this.mReplacement != null)) ? ((this.mFont == null) ? 1 : this.mFont.texHeight) : this.mReplacement.texHeight;
		}
	}

	// Token: 0x17000F07 RID: 3847
	// (get) Token: 0x060050D2 RID: 20690 RVA: 0x0013CE08 File Offset: 0x0013B008
	// (set) Token: 0x060050D3 RID: 20691 RVA: 0x0013CE34 File Offset: 0x0013B034
	public global::UIAtlas atlas
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mAtlas : this.mReplacement.atlas;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.atlas = value;
			}
			else if (this.mAtlas != value)
			{
				if (value == null)
				{
					if (this.mAtlas != null)
					{
						this.mMat = this.mAtlas.spriteMaterial;
					}
					if (this.sprite != null)
					{
						this.mUVRect = this.uvRect;
					}
				}
				this.mAtlas = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000F08 RID: 3848
	// (get) Token: 0x060050D4 RID: 20692 RVA: 0x0013CEC8 File Offset: 0x0013B0C8
	// (set) Token: 0x060050D5 RID: 20693 RVA: 0x0013CF1C File Offset: 0x0013B11C
	public global::UnityEngine.Material material
	{
		get
		{
			if (this.mReplacement != null)
			{
				return this.mReplacement.material;
			}
			return (!(this.mAtlas != null)) ? this.mMat : this.mAtlas.spriteMaterial;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.material = value;
			}
			else if (this.mAtlas == null && this.mMat != value)
			{
				this.mMat = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000F09 RID: 3849
	// (get) Token: 0x060050D6 RID: 20694 RVA: 0x0013CF7C File Offset: 0x0013B17C
	public global::UnityEngine.Texture2D texture
	{
		get
		{
			if (this.mReplacement != null)
			{
				return this.mReplacement.texture;
			}
			global::UnityEngine.Material material = this.material;
			return (!(material != null)) ? null : (material.mainTexture as global::UnityEngine.Texture2D);
		}
	}

	// Token: 0x17000F0A RID: 3850
	// (get) Token: 0x060050D7 RID: 20695 RVA: 0x0013CFCC File Offset: 0x0013B1CC
	// (set) Token: 0x060050D8 RID: 20696 RVA: 0x0013D140 File Offset: 0x0013B340
	public global::UnityEngine.Rect uvRect
	{
		get
		{
			if (this.mReplacement != null)
			{
				return this.mReplacement.uvRect;
			}
			if (this.mAtlas != null && this.mSprite == null && this.sprite != null)
			{
				global::UnityEngine.Texture texture = this.mAtlas.texture;
				if (texture != null)
				{
					this.mUVRect = this.mSprite.outer;
					if (this.mAtlas.coordinates == global::UIAtlas.Coordinates.Pixels)
					{
						this.mUVRect = global::NGUIMath.ConvertToTexCoords(this.mUVRect, texture.width, texture.height);
					}
					if (this.mSprite.hasPadding)
					{
						global::UnityEngine.Rect rect = this.mUVRect;
						this.mUVRect.xMin = rect.xMin - this.mSprite.paddingLeft * rect.width;
						this.mUVRect.yMin = rect.yMin - this.mSprite.paddingBottom * rect.height;
						this.mUVRect.xMax = rect.xMax + this.mSprite.paddingRight * rect.width;
						this.mUVRect.yMax = rect.yMax + this.mSprite.paddingTop * rect.height;
					}
					if (this.mSprite.hasPadding)
					{
						this.Trim();
					}
				}
			}
			return this.mUVRect;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.uvRect = value;
			}
			else if (this.sprite == null && this.mUVRect != value)
			{
				this.mUVRect = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000F0B RID: 3851
	// (get) Token: 0x060050D9 RID: 20697 RVA: 0x0013D198 File Offset: 0x0013B398
	// (set) Token: 0x060050DA RID: 20698 RVA: 0x0013D1D4 File Offset: 0x0013B3D4
	public string spriteName
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mFont.spriteName : this.mReplacement.spriteName;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.spriteName = value;
			}
			else if (this.mFont.spriteName != value)
			{
				this.mFont.spriteName = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000F0C RID: 3852
	// (get) Token: 0x060050DB RID: 20699 RVA: 0x0013D22C File Offset: 0x0013B42C
	// (set) Token: 0x060050DC RID: 20700 RVA: 0x0013D258 File Offset: 0x0013B458
	public int horizontalSpacing
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mSpacingX : this.mReplacement.horizontalSpacing;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.horizontalSpacing = value;
			}
			else if (this.mSpacingX != value)
			{
				this.mSpacingX = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000F0D RID: 3853
	// (get) Token: 0x060050DD RID: 20701 RVA: 0x0013D298 File Offset: 0x0013B498
	// (set) Token: 0x060050DE RID: 20702 RVA: 0x0013D2C4 File Offset: 0x0013B4C4
	public int verticalSpacing
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mSpacingY : this.mReplacement.verticalSpacing;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.verticalSpacing = value;
			}
			else if (this.mSpacingY != value)
			{
				this.mSpacingY = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000F0E RID: 3854
	// (get) Token: 0x060050DF RID: 20703 RVA: 0x0013D304 File Offset: 0x0013B504
	public int size
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mFont.charSize : this.mReplacement.size;
		}
	}

	// Token: 0x17000F0F RID: 3855
	// (get) Token: 0x060050E0 RID: 20704 RVA: 0x0013D340 File Offset: 0x0013B540
	public global::UIAtlas.Sprite sprite
	{
		get
		{
			if (this.mReplacement != null)
			{
				return this.mReplacement.sprite;
			}
			if (!this.mSpriteSet)
			{
				this.mSprite = null;
			}
			if (this.mSprite == null && this.mAtlas != null && !string.IsNullOrEmpty(this.mFont.spriteName))
			{
				this.mSprite = this.mAtlas.GetSprite(this.mFont.spriteName);
				if (this.mSprite == null)
				{
					this.mSprite = this.mAtlas.GetSprite(base.name);
				}
				this.mSpriteSet = true;
				if (this.mSprite == null)
				{
					global::UnityEngine.Debug.LogError("Can't find the sprite '" + this.mFont.spriteName + "' in UIAtlas on " + global::NGUITools.GetHierarchy(this.mAtlas.gameObject));
					this.mFont.spriteName = null;
				}
			}
			return this.mSprite;
		}
	}

	// Token: 0x17000F10 RID: 3856
	// (get) Token: 0x060050E1 RID: 20705 RVA: 0x0013D440 File Offset: 0x0013B640
	// (set) Token: 0x060050E2 RID: 20706 RVA: 0x0013D448 File Offset: 0x0013B648
	public global::UIFont replacement
	{
		get
		{
			return this.mReplacement;
		}
		set
		{
			global::UIFont uifont = value;
			if (uifont == this)
			{
				uifont = null;
			}
			if (this.mReplacement != uifont)
			{
				if (uifont != null && uifont.replacement == this)
				{
					uifont.replacement = null;
				}
				if (this.mReplacement != null)
				{
					this.MarkAsDirty();
				}
				this.mReplacement = uifont;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x060050E3 RID: 20707 RVA: 0x0013D4C0 File Offset: 0x0013B6C0
	private void Trim()
	{
		global::UnityEngine.Texture texture = this.mAtlas.texture;
		if (texture != null && this.mSprite != null)
		{
			global::UnityEngine.Rect rect = global::NGUIMath.ConvertToPixels(this.mUVRect, this.texture.width, this.texture.height, true);
			global::UnityEngine.Rect rect2 = (this.mAtlas.coordinates != global::UIAtlas.Coordinates.TexCoords) ? this.mSprite.outer : global::NGUIMath.ConvertToPixels(this.mSprite.outer, texture.width, texture.height, true);
			int xMin = global::UnityEngine.Mathf.RoundToInt(rect2.xMin - rect.xMin);
			int yMin = global::UnityEngine.Mathf.RoundToInt(rect2.yMin - rect.yMin);
			int xMax = global::UnityEngine.Mathf.RoundToInt(rect2.xMax - rect.xMin);
			int yMax = global::UnityEngine.Mathf.RoundToInt(rect2.yMax - rect.yMin);
			this.mFont.Trim(xMin, yMin, xMax, yMax);
		}
	}

	// Token: 0x060050E4 RID: 20708 RVA: 0x0013D5BC File Offset: 0x0013B7BC
	private bool References(global::UIFont font)
	{
		return !(font == null) && (font == this || (this.mReplacement != null && this.mReplacement.References(font)));
	}

	// Token: 0x060050E5 RID: 20709 RVA: 0x0013D608 File Offset: 0x0013B808
	public static bool CheckIfRelated(global::UIFont a, global::UIFont b)
	{
		return !(a == null) && !(b == null) && (a == b || a.References(b) || b.References(a));
	}

	// Token: 0x060050E6 RID: 20710 RVA: 0x0013D654 File Offset: 0x0013B854
	public void MarkAsDirty()
	{
		this.mSprite = null;
		global::UILabel[] array = global::NGUITools.FindActive<global::UILabel>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			global::UILabel uilabel = array[i];
			if (uilabel.enabled && uilabel.gameObject.activeInHierarchy && global::UIFont.CheckIfRelated(this, uilabel.font))
			{
				global::UIFont font = uilabel.font;
				uilabel.font = null;
				uilabel.font = font;
			}
			i++;
		}
	}

	// Token: 0x060050E7 RID: 20711 RVA: 0x0013D6CC File Offset: 0x0013B8CC
	public global::UnityEngine.Vector2 CalculatePrintedSize(string text, bool encoding, global::UIFont.SymbolStyle symbolStyle)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.CalculatePrintedSize(text, encoding, symbolStyle);
		}
		global::UnityEngine.Vector2 zero = global::UnityEngine.Vector2.zero;
		if (this.mFont != null && this.mFont.isValid && !string.IsNullOrEmpty(text))
		{
			if (encoding)
			{
				text = global::NGUITools.StripSymbols(text);
			}
			int length = text.Length;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = this.mFont.charSize + this.mSpacingY;
			for (int i = 0; i < length; i++)
			{
				char c = text[i];
				global::BMSymbol bmsymbol;
				global::BMGlyph bmglyph;
				if (c == '\n')
				{
					if (num2 > num)
					{
						num = num2;
					}
					num2 = 0;
					num3 += num5;
					num4 = 0;
				}
				else if (c < ' ')
				{
					num4 = 0;
				}
				else if (this.mFont.MatchSymbol(text, i, length, out bmsymbol))
				{
					num2 += this.mSpacingX + bmsymbol.width;
					i += bmsymbol.sequence.Length - 1;
					num4 = 0;
				}
				else if (this.mFont.GetGlyph((int)c, out bmglyph))
				{
					num2 += this.mSpacingX + ((num4 == 0) ? bmglyph.advance : (bmglyph.advance + bmglyph.GetKerning(num4)));
					num4 = (int)c;
				}
			}
			float num6 = (this.mFont.charSize <= 0) ? 1f : (1f / (float)this.mFont.charSize);
			zero.x = num6 * (float)((num2 <= num) ? num : num2);
			zero.y = num6 * (float)(num3 + num5);
		}
		return zero;
	}

	// Token: 0x060050E8 RID: 20712 RVA: 0x0013D898 File Offset: 0x0013BA98
	private static global::UITextMod EndLine(ref global::System.Text.StringBuilder s)
	{
		int num = s.Length - 1;
		if (num > 0 && s[num] == ' ')
		{
			s[num] = '\n';
			return global::UITextMod.Replaced;
		}
		s.Append('\n');
		return global::UITextMod.Added;
	}

	// Token: 0x17000F11 RID: 3857
	// (get) Token: 0x060050E9 RID: 20713 RVA: 0x0013D8DC File Offset: 0x0013BADC
	public static global::System.Collections.Generic.List<global::UITextMarkup> tempMarkup
	{
		get
		{
			global::System.Collections.Generic.List<global::UITextMarkup> result;
			if ((result = global::UIFont._tempMarkup) == null)
			{
				result = (global::UIFont._tempMarkup = new global::System.Collections.Generic.List<global::UITextMarkup>());
			}
			return result;
		}
	}

	// Token: 0x060050EA RID: 20714 RVA: 0x0013D8F8 File Offset: 0x0013BAF8
	public string WrapText(global::System.Collections.Generic.List<global::UITextMarkup> markups, string text, float maxWidth, int maxLineCount, bool encoding, global::UIFont.SymbolStyle symbolStyle)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.WrapText(markups, text, maxWidth, maxLineCount, encoding, symbolStyle);
		}
		markups = (markups ?? global::UIFont.tempMarkup);
		markups.Clear();
		int num = global::UnityEngine.Mathf.RoundToInt(maxWidth * (float)this.size);
		if (num < 1)
		{
			return text;
		}
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		int length = text.Length;
		int num2 = num;
		int num3 = 0;
		int num4 = 0;
		int i = 0;
		bool flag = true;
		bool flag2 = maxLineCount != 1;
		int num5 = 1;
		global::BMSymbol bmsymbol = null;
		int num6 = 0;
		while (i < length)
		{
			char c = text[i];
			if (num3 == 0x5C && c == 'n')
			{
				if (num4 < i - 1)
				{
					stringBuilder.Append(text.Substring(num4, i - (num4 + 2)));
				}
				else
				{
					stringBuilder.Append(c);
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				markups.Add(new global::UITextMarkup
				{
					index = i - 1,
					mod = global::UITextMod.Removed
				});
				markups.Add(new global::UITextMarkup
				{
					index = i,
					mod = global::UITextMod.Replaced,
					value = '\n'
				});
				num4 = i + 1;
				c = '\n';
			}
			if (c == '\n')
			{
				if (!flag2 || num5 == maxLineCount)
				{
					markups.Add(new global::UITextMarkup
					{
						index = i
					});
					break;
				}
				num2 = num;
				if (num4 < i)
				{
					stringBuilder.Append(text.Substring(num4, i - num4 + 1));
				}
				else
				{
					stringBuilder.Append(c);
				}
				flag = true;
				num5++;
				num4 = i + 1;
				num3 = 0;
			}
			else
			{
				if (c == ' ' && num3 != 0x20 && num4 < i)
				{
					stringBuilder.Append(text.Substring(num4, i - num4 + 1));
					flag = false;
					num4 = i + 1;
					num3 = (int)c;
				}
				if (encoding && c == '[' && i + 2 < length)
				{
					if (text[i + 2] == ']')
					{
						if (text[i + 1] == '-')
						{
							if (num6 == 0)
							{
								markups.Add(new global::UITextMarkup
								{
									index = i,
									mod = global::UITextMod.Removed
								});
								markups.Add(new global::UITextMarkup
								{
									index = i + 1,
									mod = global::UITextMod.Removed
								});
								markups.Add(new global::UITextMarkup
								{
									index = i + 2,
									mod = global::UITextMod.Removed
								});
								i += 2;
								goto IL_8B0;
							}
						}
						else if (text[i + 1] == '»')
						{
							if (num6++ == 0)
							{
								markups.Add(new global::UITextMarkup
								{
									index = i,
									mod = global::UITextMod.Removed
								});
								markups.Add(new global::UITextMarkup
								{
									index = i + 1,
									mod = global::UITextMod.Removed
								});
								markups.Add(new global::UITextMarkup
								{
									index = i + 2,
									mod = global::UITextMod.Removed
								});
								i += 2;
								goto IL_8B0;
							}
						}
						else if (text[i + 1] == '«' && --num6 == 0)
						{
							markups.Add(new global::UITextMarkup
							{
								index = i,
								mod = global::UITextMod.Removed
							});
							markups.Add(new global::UITextMarkup
							{
								index = i + 1,
								mod = global::UITextMod.Removed
							});
							markups.Add(new global::UITextMarkup
							{
								index = i + 2,
								mod = global::UITextMod.Removed
							});
							i += 2;
							goto IL_8B0;
						}
					}
					else if (i + 7 < length && text[i + 7] == ']' && num6 == 0)
					{
						markups.Add(new global::UITextMarkup
						{
							index = i,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 1,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 2,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 3,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 4,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 5,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 6,
							mod = global::UITextMod.Removed
						});
						markups.Add(new global::UITextMarkup
						{
							index = i + 7,
							mod = global::UITextMod.Removed
						});
						i += 7;
						goto IL_8B0;
					}
				}
				bool flag3 = encoding && symbolStyle != global::UIFont.SymbolStyle.None && this.mFont.MatchSymbol(text, i, length, out bmsymbol);
				int num7;
				if (flag3)
				{
					num7 = this.mSpacingX + bmsymbol.width;
				}
				else
				{
					global::BMGlyph bmglyph;
					if (!this.mFont.GetGlyph((int)c, out bmglyph))
					{
						markups.Add(new global::UITextMarkup
						{
							index = i,
							mod = global::UITextMod.Removed
						});
						goto IL_8B0;
					}
					num7 = this.mSpacingX + ((num3 == 0) ? bmglyph.advance : (bmglyph.advance + bmglyph.GetKerning(num3)));
				}
				num2 -= num7;
				if (num2 < 0)
				{
					if (flag || !flag2 || num5 == maxLineCount)
					{
						stringBuilder.Append(text.Substring(num4, global::UnityEngine.Mathf.Max(0, i - num4)));
						if (!flag2 || num5 == maxLineCount)
						{
							num4 = i;
							markups.Add(new global::UITextMarkup
							{
								index = i
							});
							break;
						}
						global::UITextMod uitextMod = global::UIFont.EndLine(ref stringBuilder);
						if (uitextMod != global::UITextMod.Replaced)
						{
							if (uitextMod == global::UITextMod.Added)
							{
								markups.Add(new global::UITextMarkup
								{
									index = i,
									mod = global::UITextMod.Added
								});
							}
						}
						else
						{
							markups.Add(new global::UITextMarkup
							{
								index = i,
								mod = global::UITextMod.Replaced,
								value = '\n'
							});
						}
						flag = true;
						num5++;
						if (c == ' ')
						{
							num4 = i + 1;
							num2 = num;
							markups.Add(new global::UITextMarkup
							{
								index = i,
								mod = global::UITextMod.Removed
							});
						}
						else
						{
							num4 = i;
							num2 = num - num7;
						}
						num3 = 0;
					}
					else
					{
						while (num4 < length && text[num4] == ' ')
						{
							markups.Add(new global::UITextMarkup
							{
								index = num4,
								mod = global::UITextMod.Removed
							});
							num4++;
						}
						flag = true;
						num2 = num;
						i = num4 - 1;
						int count = markups.Count;
						for (int j = count - 1; j >= 0; j--)
						{
							if (markups[j].index < i)
							{
								break;
							}
							markups.RemoveAt(j);
						}
						num3 = 0;
						if (!flag2 || num5 == maxLineCount)
						{
							markups.Add(new global::UITextMarkup
							{
								index = i
							});
							break;
						}
						num5++;
						global::UITextMod uitextMod = global::UIFont.EndLine(ref stringBuilder);
						if (uitextMod != global::UITextMod.Replaced)
						{
							if (uitextMod == global::UITextMod.Added)
							{
								markups.Add(new global::UITextMarkup
								{
									index = i,
									mod = global::UITextMod.Added
								});
							}
						}
						else
						{
							markups.Add(new global::UITextMarkup
							{
								index = i,
								mod = global::UITextMod.Replaced,
								value = '\n'
							});
						}
						goto IL_8B0;
					}
				}
				else
				{
					num3 = (int)c;
				}
				if (flag3)
				{
					for (int k = 0; k < bmsymbol.sequence.Length; k++)
					{
						markups.Add(new global::UITextMarkup
						{
							index = i + k,
							mod = global::UITextMod.Removed
						});
					}
					i += bmsymbol.sequence.Length - 1;
					num3 = 0;
				}
			}
			IL_8B0:
			i++;
		}
		if (num4 < i)
		{
			stringBuilder.Append(text.Substring(num4, i - num4));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060050EB RID: 20715 RVA: 0x0013E1E8 File Offset: 0x0013C3E8
	public string WrapText(global::System.Collections.Generic.List<global::UITextMarkup> markups, string text, float maxWidth, int maxLineCount, bool encoding)
	{
		return this.WrapText(markups, text, maxWidth, maxLineCount, encoding, global::UIFont.SymbolStyle.None);
	}

	// Token: 0x060050EC RID: 20716 RVA: 0x0013E1F8 File Offset: 0x0013C3F8
	public string WrapText(global::System.Collections.Generic.List<global::UITextMarkup> markups, string text, float maxWidth, int maxLineCount)
	{
		return this.WrapText(markups, text, maxWidth, maxLineCount, false, global::UIFont.SymbolStyle.None);
	}

	// Token: 0x060050ED RID: 20717 RVA: 0x0013E208 File Offset: 0x0013C408
	private void MangleSort(int len)
	{
		global::UIFont.mangleSort.SetLineSizing((double)this.bmFont.charSize, (double)this.verticalSpacing);
		global::System.Array.Sort<global::UnityEngine.Vector3, int>(global::UIFont.manglePoints, global::UIFont.mangleIndices, 0, len, global::UIFont.mangleSort);
	}

	// Token: 0x060050EE RID: 20718 RVA: 0x0013E248 File Offset: 0x0013C448
	private int FillMangle(global::UnityEngine.Vector2[] points, int pointsOffset, global::UITextPosition[] positions, int positionsOffset, int len)
	{
		if (positions == null || points == null)
		{
			return 0;
		}
		if (points.Length - pointsOffset < len || positions.Length - positionsOffset < len)
		{
			throw new global::System.ArgumentOutOfRangeException();
		}
		if (len > global::UIFont.mangleIndices.Length)
		{
			global::System.Array.Resize<global::UnityEngine.Vector3>(ref global::UIFont.manglePoints, len);
			global::System.Array.Resize<int>(ref global::UIFont.mangleIndices, len);
			global::System.Array.Resize<global::UITextPosition>(ref global::UIFont.manglePositions, len);
		}
		for (int i = 0; i < len; i++)
		{
			global::UIFont.manglePoints[i].x = points[i + pointsOffset].x;
			global::UIFont.manglePoints[i].y = points[i + pointsOffset].y;
			global::UIFont.manglePoints[i].z = 0f;
			global::UIFont.mangleIndices[i] = i;
		}
		return len;
	}

	// Token: 0x060050EF RID: 20719 RVA: 0x0013E324 File Offset: 0x0013C524
	private int FillMangle(global::UnityEngine.Vector3[] points, int pointsOffset, global::UITextPosition[] positions, int positionsOffset, int len)
	{
		if (points == null)
		{
			throw new global::System.ArgumentNullException("null array", "points");
		}
		if (points.Length - pointsOffset < len)
		{
			throw new global::System.ArgumentException("not large enough", "points");
		}
		if (positions != null && positions.Length - positionsOffset < len)
		{
			throw new global::System.ArgumentException("not large enough", "positions");
		}
		if (len > global::UIFont.mangleIndices.Length)
		{
			global::System.Array.Resize<global::UnityEngine.Vector3>(ref global::UIFont.manglePoints, len);
			global::System.Array.Resize<int>(ref global::UIFont.mangleIndices, len);
			global::System.Array.Resize<global::UITextPosition>(ref global::UIFont.manglePositions, len);
		}
		for (int i = 0; i < len; i++)
		{
			global::UIFont.manglePoints[i] = points[i + pointsOffset];
			global::UIFont.mangleIndices[i] = i;
		}
		return len;
	}

	// Token: 0x060050F0 RID: 20720 RVA: 0x0013E3F4 File Offset: 0x0013C5F4
	private int ProcessShared(int len, ref global::UITextPosition[] positions, string text)
	{
		if (this.mFont.charSize > 0)
		{
			for (int i = 0; i < len; i++)
			{
				global::UnityEngine.Vector3[] array = global::UIFont.manglePoints;
				int num = i;
				array[num].x = array[num].x * (float)this.mFont.charSize;
				global::UnityEngine.Vector3[] array2 = global::UIFont.manglePoints;
				int num2 = i;
				array2[num2].y = array2[num2].y * (float)this.mFont.charSize;
			}
		}
		this.MangleSort(len);
		len = this.ProcessPlacement(len, text);
		if (len > 0)
		{
			if (positions == null)
			{
				positions = new global::UITextPosition[len];
			}
			for (int j = 0; j < len; j++)
			{
				positions[global::UIFont.mangleIndices[j]] = global::UIFont.manglePositions[j];
			}
		}
		return len;
	}

	// Token: 0x060050F1 RID: 20721 RVA: 0x0013E4C8 File Offset: 0x0013C6C8
	[global::System.Obsolete("You must specify some point", true)]
	public global::UITextPosition[] CalculatePlacement(string text)
	{
		return global::UIFont.empty;
	}

	// Token: 0x060050F2 RID: 20722 RVA: 0x0013E4D0 File Offset: 0x0013C6D0
	private int CalculatePlacement(global::UnityEngine.Vector2[] points, ref global::UITextPosition[] positions, string text)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.CalculatePlacement(points, positions, text);
		}
		int num = this.FillMangle(points, 0, positions, 0, global::UnityEngine.Mathf.Min(points.Length, positions.Length));
		if (num > 0)
		{
			return this.ProcessShared(num, ref positions, text);
		}
		return num;
	}

	// Token: 0x060050F3 RID: 20723 RVA: 0x0013E528 File Offset: 0x0013C728
	public int CalculatePlacement(global::UnityEngine.Vector2[] points, global::UITextPosition[] positions, string text)
	{
		if (positions == null)
		{
			throw new global::System.ArgumentNullException("positions");
		}
		return this.CalculatePlacement(points, ref positions, text, base.transform);
	}

	// Token: 0x060050F4 RID: 20724 RVA: 0x0013E54C File Offset: 0x0013C74C
	public global::UITextPosition CalculatePlacement(string text, global::UnityEngine.Vector2 point)
	{
		global::UnityEngine.Vector2[] points = new global::UnityEngine.Vector2[]
		{
			point
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		this.CalculatePlacement(points, array, text);
		return array[0];
	}

	// Token: 0x060050F5 RID: 20725 RVA: 0x0013E5A0 File Offset: 0x0013C7A0
	public global::UITextPosition[] CalculatePlacement(string text, params global::UnityEngine.Vector2[] points)
	{
		global::UITextPosition[] array = null;
		return (this.CalculatePlacement(points, ref array, text) <= 0) ? global::UIFont.empty : array;
	}

	// Token: 0x060050F6 RID: 20726 RVA: 0x0013E5CC File Offset: 0x0013C7CC
	private int CalculatePlacement(global::UnityEngine.Vector3[] points, ref global::UITextPosition[] positions, string text)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.CalculatePlacement(points, positions, text);
		}
		int num = this.FillMangle(points, 0, positions, 0, global::UnityEngine.Mathf.Min(points.Length, positions.Length));
		if (num > 0)
		{
			return this.ProcessShared(num, ref positions, text);
		}
		return num;
	}

	// Token: 0x060050F7 RID: 20727 RVA: 0x0013E624 File Offset: 0x0013C824
	public int CalculatePlacement(global::UnityEngine.Vector3[] points, global::UITextPosition[] positions, string text)
	{
		if (positions == null)
		{
			throw new global::System.ArgumentNullException("positions");
		}
		return this.CalculatePlacement(points, ref positions, text, base.transform);
	}

	// Token: 0x060050F8 RID: 20728 RVA: 0x0013E648 File Offset: 0x0013C848
	public global::UITextPosition[] CalculatePlacement(string text, params global::UnityEngine.Vector3[] points)
	{
		global::UITextPosition[] array = null;
		return (this.CalculatePlacement(points, ref array, text) <= 0) ? global::UIFont.empty : array;
	}

	// Token: 0x060050F9 RID: 20729 RVA: 0x0013E674 File Offset: 0x0013C874
	private int CalculatePlacement(global::UnityEngine.Vector3[] points, ref global::UITextPosition[] positions, string text, global::UnityEngine.Matrix4x4 transform)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.CalculatePlacement(points, positions, text);
		}
		int num = this.FillMangle(points, 0, positions, 0, points.Length);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				global::UIFont.manglePoints[i] = transform.MultiplyPoint(global::UIFont.manglePoints[i]);
			}
			return this.ProcessShared(num, ref positions, text);
		}
		return num;
	}

	// Token: 0x060050FA RID: 20730 RVA: 0x0013E6FC File Offset: 0x0013C8FC
	public int CalculatePlacement(global::UnityEngine.Vector3[] points, global::UITextPosition[] positions, string text, global::UnityEngine.Matrix4x4 transform)
	{
		if (positions == null)
		{
			throw new global::System.ArgumentNullException("positions");
		}
		return this.CalculatePlacement(points, ref positions, text, transform);
	}

	// Token: 0x060050FB RID: 20731 RVA: 0x0013E71C File Offset: 0x0013C91C
	public global::UITextPosition CalculatePlacement(string text, global::UnityEngine.Matrix4x4 transform, global::UnityEngine.Vector3 point)
	{
		global::UnityEngine.Vector3[] points = new global::UnityEngine.Vector3[]
		{
			point
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		this.CalculatePlacement(points, array, text, transform);
		return array[0];
	}

	// Token: 0x060050FC RID: 20732 RVA: 0x0013E770 File Offset: 0x0013C970
	public global::UITextPosition[] CalculatePlacement(string text, global::UnityEngine.Matrix4x4 transform, params global::UnityEngine.Vector3[] points)
	{
		global::UITextPosition[] array = null;
		if (points == null)
		{
			return null;
		}
		if (points.Length == 0)
		{
			return global::UIFont.empty;
		}
		return (this.CalculatePlacement(points, ref array, text, transform) <= 0) ? global::UIFont.empty : array;
	}

	// Token: 0x060050FD RID: 20733 RVA: 0x0013E7B4 File Offset: 0x0013C9B4
	private int CalculatePlacement(global::UnityEngine.Vector2[] points, ref global::UITextPosition[] positions, string text, global::UnityEngine.Matrix4x4 transform)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.CalculatePlacement(points, positions, text);
		}
		int num = this.FillMangle(points, 0, positions, 0, global::UnityEngine.Mathf.Min(points.Length, positions.Length));
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				global::UIFont.manglePoints[i] = transform.MultiplyPoint(global::UIFont.manglePoints[i]);
			}
			return this.ProcessShared(num, ref positions, text);
		}
		return num;
	}

	// Token: 0x060050FE RID: 20734 RVA: 0x0013E848 File Offset: 0x0013CA48
	public int CalculatePlacement(global::UnityEngine.Vector2[] points, global::UITextPosition[] positions, string text, global::UnityEngine.Matrix4x4 transform)
	{
		if (positions == null)
		{
			throw new global::System.ArgumentNullException("positions");
		}
		return this.CalculatePlacement(points, ref positions, text, transform);
	}

	// Token: 0x060050FF RID: 20735 RVA: 0x0013E868 File Offset: 0x0013CA68
	public global::UITextPosition[] CalculatePlacement(string text, global::UnityEngine.Matrix4x4 transform, params global::UnityEngine.Vector2[] points)
	{
		global::UITextPosition[] array = null;
		if (points == null)
		{
			return null;
		}
		if (points.Length == 0)
		{
			return global::UIFont.empty;
		}
		return (this.CalculatePlacement(points, ref array, text, transform) <= 0) ? global::UIFont.empty : array;
	}

	// Token: 0x06005100 RID: 20736 RVA: 0x0013E8AC File Offset: 0x0013CAAC
	private int CalculatePlacement(global::UnityEngine.Vector3[] points, ref global::UITextPosition[] positions, string text, global::UnityEngine.Transform self)
	{
		if (!self)
		{
			return this.CalculatePlacement(points, positions, text);
		}
		return this.CalculatePlacement(points, positions, text, self.worldToLocalMatrix);
	}

	// Token: 0x06005101 RID: 20737 RVA: 0x0013E8E4 File Offset: 0x0013CAE4
	public int CalculatePlacement(global::UnityEngine.Vector3[] points, global::UITextPosition[] positions, string text, global::UnityEngine.Transform self)
	{
		if (positions == null)
		{
			throw new global::System.ArgumentNullException("positions");
		}
		return this.CalculatePlacement(points, ref positions, text, base.transform);
	}

	// Token: 0x06005102 RID: 20738 RVA: 0x0013E908 File Offset: 0x0013CB08
	private int CalculatePlacement(global::UnityEngine.Vector2[] points, ref global::UITextPosition[] positions, string text, global::UnityEngine.Transform self)
	{
		if (!self)
		{
			return this.CalculatePlacement(points, positions, text);
		}
		return this.CalculatePlacement(points, positions, text, self.worldToLocalMatrix);
	}

	// Token: 0x06005103 RID: 20739 RVA: 0x0013E940 File Offset: 0x0013CB40
	public int CalculatePlacement(global::UnityEngine.Vector2[] points, global::UITextPosition[] positions, string text, global::UnityEngine.Transform self)
	{
		if (positions == null)
		{
			throw new global::System.ArgumentNullException("positions");
		}
		return this.CalculatePlacement(points, ref positions, text, base.transform);
	}

	// Token: 0x06005104 RID: 20740 RVA: 0x0013E964 File Offset: 0x0013CB64
	public global::UITextPosition CalculatePlacement(string text, global::UnityEngine.Transform self, global::UnityEngine.Vector2 point)
	{
		global::UnityEngine.Vector2[] points = new global::UnityEngine.Vector2[]
		{
			point
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		this.CalculatePlacement(points, array, text, self);
		return array[0];
	}

	// Token: 0x06005105 RID: 20741 RVA: 0x0013E9B8 File Offset: 0x0013CBB8
	public global::UITextPosition[] CalculatePlacement(string text, global::UnityEngine.Transform self, params global::UnityEngine.Vector2[] points)
	{
		global::UITextPosition[] array = null;
		if (points == null)
		{
			return null;
		}
		if (points.Length == 0)
		{
			return global::UIFont.empty;
		}
		return (this.CalculatePlacement(points, ref array, text, self) <= 0) ? global::UIFont.empty : array;
	}

	// Token: 0x06005106 RID: 20742 RVA: 0x0013E9FC File Offset: 0x0013CBFC
	public global::UITextPosition CalculatePlacement(string text, global::UnityEngine.Vector3 point)
	{
		global::UnityEngine.Vector3[] points = new global::UnityEngine.Vector3[]
		{
			point
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		this.CalculatePlacement(points, array, text);
		return array[0];
	}

	// Token: 0x06005107 RID: 20743 RVA: 0x0013EA50 File Offset: 0x0013CC50
	public global::UITextPosition CalculatePlacement(string text, global::UnityEngine.Matrix4x4 transform, global::UnityEngine.Vector2 point)
	{
		global::UnityEngine.Vector2[] points = new global::UnityEngine.Vector2[]
		{
			point
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		this.CalculatePlacement(points, array, text, transform);
		return array[0];
	}

	// Token: 0x06005108 RID: 20744 RVA: 0x0013EAA4 File Offset: 0x0013CCA4
	public global::UITextPosition CalculatePlacement(string text, global::UnityEngine.Transform self, global::UnityEngine.Vector3 point)
	{
		global::UnityEngine.Vector3[] points = new global::UnityEngine.Vector3[]
		{
			point
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		this.CalculatePlacement(points, array, text, self);
		return array[0];
	}

	// Token: 0x06005109 RID: 20745 RVA: 0x0013EAF8 File Offset: 0x0013CCF8
	public global::UITextPosition[] CalculatePlacement(string text, global::UnityEngine.Transform self, params global::UnityEngine.Vector3[] points)
	{
		global::UITextPosition[] array = null;
		if (points == null)
		{
			return null;
		}
		if (points.Length == 0)
		{
			return global::UIFont.empty;
		}
		return (this.CalculatePlacement(points, ref array, text, self) <= 0) ? global::UIFont.empty : array;
	}

	// Token: 0x0600510A RID: 20746 RVA: 0x0013EB3C File Offset: 0x0013CD3C
	private int ProcessPlacement(int count, string text)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.ProcessPlacement(count, text);
		}
		int i = 0;
		if (global::UIFont.manglePoints[global::UIFont.mangleIndices[i]].y < 0f)
		{
			do
			{
				global::UIFont.manglePositions[i] = new global::UITextPosition(global::UITextRegion.Before);
			}
			while (++i < count && global::UIFont.manglePoints[global::UIFont.mangleIndices[i]].y < 0f);
			if (i >= count)
			{
				return count;
			}
		}
		int length = text.Length;
		int num = this.verticalSpacing + this.bmFont.charSize;
		if (length == 0)
		{
			while (global::UIFont.manglePoints[global::UIFont.mangleIndices[i]].y <= (float)num)
			{
				if (global::UIFont.manglePoints[global::UIFont.mangleIndices[i]].x < 0f)
				{
					global::UIFont.manglePositions[i] = new global::UITextPosition(global::UITextRegion.Pre);
				}
				else
				{
					global::UIFont.manglePositions[i] = new global::UITextPosition(global::UITextRegion.Past);
				}
				if (++i >= count)
				{
					return count;
				}
			}
			while (i < count)
			{
				global::UIFont.manglePositions[i++] = new global::UITextPosition(global::UITextRegion.End);
			}
			return count;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = -1;
		int num7 = 0;
		int column = 0;
		bool flag = false;
		bool flag2 = false;
		IL_389:
		while (i < count)
		{
			global::UnityEngine.Vector3 vector = global::UIFont.manglePoints[global::UIFont.mangleIndices[i]];
			int num8 = global::UnityEngine.Mathf.FloorToInt(vector.y);
			int num9 = num8 / num;
			IL_19E:
			while (!flag2)
			{
				if (num9 > num2)
				{
					flag = false;
					for (;;)
					{
						while (text[num4] != '\n')
						{
							if (++num4 >= length)
							{
								goto Block_12;
							}
							num3++;
						}
						num2++;
						num3 = 0;
						column = 0;
						num6 = num4;
						num4 = (num5 = num4 + 1);
						num7 = 0;
						if (num9 <= num2)
						{
							goto Block_14;
						}
					}
					Block_12:
					flag2 = true;
					continue;
					Block_14:
					goto IL_389;
				}
				if (vector.x < 0f)
				{
					global::UIFont.manglePositions[i++] = new global::UITextPosition(num2, 0, num5, global::UITextRegion.Pre);
					goto IL_389;
				}
				if (flag)
				{
					global::UIFont.manglePositions[i++] = new global::UITextPosition(num2, column, num6, global::UITextRegion.Past);
					goto IL_389;
				}
				while ((float)num7 < vector.x)
				{
					if (num4 >= length)
					{
						flag2 = true;
						goto IL_19E;
					}
					int num10 = (int)text[num4];
					if (num10 == 0xA)
					{
						num6 = num4;
						num4 = (num5 = num4 + 1);
						column = num3;
						num3 = 0;
						flag = true;
						goto IL_19E;
					}
					global::BMGlyph bmglyph;
					if (this.mFont.GetGlyph(num10, out bmglyph))
					{
						if (num6 >= num5)
						{
							num7 += bmglyph.GetKerning((int)text[num6]);
						}
						num7 += this.mSpacingX + bmglyph.advance;
					}
					num6 = num4++;
					column = num3++;
				}
				global::UIFont.manglePositions[i++] = new global::UITextPosition(num2, column, num6, global::UITextRegion.Inside);
				goto IL_389;
			}
			if (num9 == num2)
			{
				global::UIFont.manglePositions[i++] = new global::UITextPosition(num2, num3, num4, global::UITextRegion.Past);
			}
			else
			{
				while (i < count)
				{
					global::UIFont.manglePositions[i++] = new global::UITextPosition(num2, num3, num4, global::UITextRegion.End);
				}
			}
		}
		if (i < count)
		{
			global::UnityEngine.Debug.LogError(" skipped " + (count - i));
		}
		return count;
	}

	// Token: 0x0600510B RID: 20747 RVA: 0x0013EEF8 File Offset: 0x0013D0F8
	private void Align(ref global::UIFont.PrintContext ctx)
	{
		if (this.mFont.charSize > 0)
		{
			int num;
			switch (ctx.alignment)
			{
			case global::UIFont.Alignment.Left:
				num = 0;
				break;
			case global::UIFont.Alignment.Center:
				num = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.RoundToInt((float)(ctx.lineWidth - ctx.x) * 0.5f));
				break;
			case global::UIFont.Alignment.Right:
				num = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.RoundToInt((float)(ctx.lineWidth - ctx.x)));
				break;
			case global::UIFont.Alignment.LeftOverflowRight:
				num = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.RoundToInt((float)(ctx.x - ctx.lineWidth)));
				break;
			default:
				throw new global::System.NotImplementedException();
			}
			if (num == 0)
			{
				return;
			}
			float num2 = (float)((double)num / (double)this.mFont.charSize);
			for (int i = ctx.indexOffset; i < ctx.m.vSize; i++)
			{
				global::NGUI.Meshing.Vertex[] v = ctx.m.v;
				int num3 = i;
				v[num3].x = v[num3].x + num2;
			}
		}
	}

	// Token: 0x0600510C RID: 20748 RVA: 0x0013F000 File Offset: 0x0013D200
	public void Print(string text, global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m, bool encoding, global::UIFont.SymbolStyle symbolStyle, global::UIFont.Alignment alignment, int lineWidth)
	{
		global::UITextSelection uitextSelection = default(global::UITextSelection);
		this.Print(text, color, m, encoding, symbolStyle, alignment, lineWidth, ref uitextSelection, '\0', color, global::UnityEngine.Color.clear, '\0', -1f);
	}

	// Token: 0x0600510D RID: 20749 RVA: 0x0013F038 File Offset: 0x0013D238
	public void Print(string text, global::UnityEngine.Color normalColor, global::NGUI.Meshing.MeshBuffer m, bool encoding, global::UIFont.SymbolStyle symbolStyle, global::UIFont.Alignment alignment, int lineWidth, ref global::UITextSelection selection, char carratChar, global::UnityEngine.Color highlightTextColor, global::UnityEngine.Color highlightBarColor, char highlightChar, float highlightSplit)
	{
		if (this.mReplacement != null)
		{
			this.mReplacement.Print(text, normalColor, m, encoding, symbolStyle, alignment, lineWidth, ref selection, carratChar, highlightTextColor, highlightBarColor, highlightChar, highlightSplit);
		}
		else if (this.mFont != null && text != null)
		{
			if (!this.mFont.isValid)
			{
				global::UnityEngine.Debug.LogError("Attempting to print using an invalid font!");
				return;
			}
			int num = 0;
			this.mColors.Clear();
			this.mColors.Add(normalColor);
			global::UIFont.PrintContext printContext;
			printContext.m = m;
			printContext.lineWidth = lineWidth;
			printContext.alignment = alignment;
			printContext.scale.x = ((this.mFont.charSize <= 0) ? 1f : (1f / (float)this.mFont.charSize));
			printContext.scale.y = printContext.scale.x;
			printContext.normalColor = normalColor;
			printContext.indexOffset = printContext.m.vSize;
			printContext.maxX = 0;
			printContext.x = 0;
			printContext.y = 0;
			printContext.prev = 0;
			printContext.lineHeight = this.mFont.charSize + this.mSpacingY;
			printContext.v0 = default(global::UnityEngine.Vector3);
			printContext.v1 = default(global::UnityEngine.Vector3);
			printContext.u0 = default(global::UnityEngine.Vector2);
			printContext.u1 = default(global::UnityEngine.Vector2);
			printContext.invX = this.uvRect.width / (float)this.mFont.texWidth;
			printContext.invY = this.uvRect.height / (float)this.mFont.texHeight;
			printContext.textLength = text.Length;
			printContext.nonHighlightColor = normalColor;
			printContext.carratChar = carratChar;
			if (printContext.carratChar == '\0')
			{
				printContext.carratIndex = -1;
				printContext.carratGlyph = null;
			}
			else if ((printContext.carratIndex = selection.carratIndex) == -1)
			{
				printContext.carratGlyph = null;
				printContext.carratChar = '\0';
			}
			else if (!this.mFont.GetGlyph((int)carratChar, out printContext.carratGlyph))
			{
				printContext.carratIndex = -1;
			}
			printContext.highlightChar = highlightChar;
			printContext.highlightBarColor = highlightBarColor;
			printContext.highlightTextColor = highlightTextColor;
			printContext.highlightSplit = highlightSplit;
			printContext.highlightBarDraw = (printContext.highlightChar != '\0' && printContext.highlightSplit >= 0f && printContext.highlightSplit <= 1f && highlightBarColor.a > 0f);
			if (!printContext.highlightBarDraw && printContext.highlightTextColor == printContext.normalColor)
			{
				printContext.highlight = global::UIHighlight.invalid;
				printContext.highlightGlyph = null;
			}
			else if (!selection.GetHighlight(out printContext.highlight))
			{
				printContext.highlightGlyph = null;
				printContext.highlightBarDraw = false;
			}
			else if ((printContext.highlightChar != printContext.carratChar) ? (!this.mFont.GetGlyph((int)printContext.highlightChar, out printContext.highlightGlyph)) : ((printContext.highlightGlyph = printContext.carratGlyph) == null))
			{
				printContext.highlight = global::UIHighlight.invalid;
			}
			printContext.j = 0;
			printContext.previousX = 0;
			printContext.isLineEnd = false;
			printContext.highlightVertex = -1;
			printContext.glyph = null;
			printContext.c = '\0';
			printContext.skipSymbols = (!encoding || symbolStyle == global::UIFont.SymbolStyle.None);
			printContext.printChar = false;
			printContext.printColor = normalColor;
			printContext.symbol = null;
			printContext.text = text;
			printContext.i = 0;
			while (printContext.i < printContext.textLength)
			{
				printContext.c = printContext.text[printContext.i];
				if (printContext.c == '\n')
				{
					printContext.isLineEnd = true;
					goto IL_B6F;
				}
				if (printContext.c >= ' ')
				{
					if (encoding && printContext.c == '[')
					{
						int num2 = global::NGUITools.ParseSymbol(text, printContext.i, this.mColors, ref num);
						if (num2 > 0)
						{
							printContext.nonHighlightColor = this.mColors[this.mColors.Count - 1];
							printContext.i += num2 - 1;
							goto IL_E19;
						}
					}
					if (printContext.skipSymbols || !this.mFont.MatchSymbol(printContext.text, printContext.i, printContext.textLength, out printContext.symbol))
					{
						if (!this.mFont.GetGlyph((int)printContext.c, out printContext.glyph))
						{
							goto IL_B6F;
						}
						bool flag = printContext.prev != 0;
						if (flag)
						{
							printContext.previousX = printContext.x;
							printContext.x += printContext.glyph.GetKerning(printContext.prev);
						}
						if (printContext.c == ' ')
						{
							if (!flag)
							{
								printContext.previousX = printContext.x;
							}
							printContext.x += this.mSpacingX + printContext.glyph.advance;
							printContext.prev = (int)printContext.c;
							goto IL_B6F;
						}
						printContext.v0.x = printContext.scale.x * (float)(printContext.x + printContext.glyph.offsetX);
						printContext.v0.y = -printContext.scale.y * (float)(printContext.y + printContext.glyph.offsetY);
						printContext.v1.x = printContext.v0.x + printContext.scale.x * (float)printContext.glyph.width;
						printContext.v1.y = printContext.v0.y - printContext.scale.y * (float)printContext.glyph.height;
						printContext.u0.x = this.mUVRect.xMin + printContext.invX * (float)printContext.glyph.x;
						printContext.u0.y = this.mUVRect.yMax - printContext.invY * (float)printContext.glyph.y;
						printContext.u1.x = printContext.u0.x + printContext.invX * (float)printContext.glyph.width;
						printContext.u1.y = printContext.u0.y - printContext.invY * (float)printContext.glyph.height;
						if (!flag)
						{
							printContext.previousX = printContext.x;
						}
						printContext.x += this.mSpacingX + printContext.glyph.advance;
						printContext.prev = (int)printContext.c;
						if (printContext.glyph.channel == 0 || printContext.glyph.channel == 0xF)
						{
							printContext.printColor = ((printContext.highlight.b.i <= printContext.j || printContext.highlight.a.i > printContext.j) ? printContext.nonHighlightColor : printContext.highlightTextColor);
						}
						else
						{
							global::UnityEngine.Color color = (printContext.highlight.b.i <= printContext.j || printContext.highlight.a.i > printContext.j) ? printContext.nonHighlightColor : printContext.highlightTextColor;
							color *= 0.49f;
							switch (printContext.glyph.channel)
							{
							case 1:
								color.b += 0.51f;
								break;
							case 2:
								color.g += 0.51f;
								break;
							case 4:
								color.r += 0.51f;
								break;
							case 8:
								color.a += 0.51f;
								break;
							}
							printContext.printColor = color;
						}
					}
					else
					{
						printContext.v0.x = printContext.scale.x * (float)printContext.x;
						printContext.v0.y = -printContext.scale.y * (float)printContext.y;
						printContext.v1.x = printContext.v0.x + printContext.scale.x * (float)printContext.symbol.width;
						printContext.v1.y = printContext.v0.y - printContext.scale.y * (float)printContext.symbol.height;
						printContext.u0.x = this.mUVRect.xMin + printContext.invX * (float)printContext.symbol.x;
						printContext.u0.y = this.mUVRect.yMax - printContext.invY * (float)printContext.symbol.y;
						printContext.u1.x = printContext.u0.x + printContext.invX * (float)printContext.symbol.width;
						printContext.u1.y = printContext.u0.y - printContext.invY * (float)printContext.symbol.height;
						printContext.previousX = printContext.x;
						printContext.x += this.mSpacingX + printContext.symbol.width;
						printContext.i += printContext.symbol.sequence.Length - 1;
						printContext.prev = 0;
						if (symbolStyle == global::UIFont.SymbolStyle.Colored)
						{
							printContext.printColor = ((printContext.highlight.b.i <= printContext.j || printContext.highlight.a.i > printContext.j) ? printContext.nonHighlightColor : printContext.highlightTextColor);
						}
						else
						{
							printContext.printColor = ((printContext.highlight.b.i <= printContext.j || printContext.highlight.a.i > printContext.j) ? new global::UnityEngine.Color(1f, 1f, 1f, printContext.nonHighlightColor.a) : printContext.highlightTextColor);
						}
					}
					printContext.printChar = true;
					goto IL_B6F;
				}
				printContext.prev = 0;
				IL_E19:
				printContext.i++;
				continue;
				IL_B6F:
				if (printContext.highlight.b.i == printContext.j)
				{
					if (printContext.printChar)
					{
						printContext.m.FastQuad(printContext.v0, printContext.v1, printContext.u0, printContext.u1, printContext.printColor);
						printContext.printChar = false;
					}
					if (printContext.highlightBarDraw)
					{
						this.PutHighlightEnd(ref printContext);
					}
				}
				else if (printContext.highlight.a.i == printContext.j)
				{
					if (printContext.highlightBarDraw)
					{
						this.PutHighlightStart(ref printContext);
					}
					if (printContext.printChar)
					{
						printContext.m.FastQuad(printContext.v0, printContext.v1, printContext.u0, printContext.u1, printContext.printColor);
						printContext.printChar = false;
					}
				}
				else if (printContext.carratIndex == printContext.j)
				{
					if (printContext.printChar)
					{
						printContext.m.FastQuad(printContext.v0, printContext.v1, printContext.u0, printContext.u1, printContext.printColor);
						printContext.printChar = false;
					}
					this.DrawCarat(ref printContext);
				}
				else if (printContext.printChar)
				{
					printContext.m.FastQuad(printContext.v0, printContext.v1, printContext.u0, printContext.u1, printContext.printColor);
					printContext.printChar = false;
				}
				printContext.j++;
				if (!printContext.isLineEnd)
				{
					goto IL_E19;
				}
				printContext.isLineEnd = false;
				if (printContext.x > printContext.maxX)
				{
					printContext.maxX = printContext.x;
				}
				bool flag2 = printContext.highlightBarDraw && printContext.highlightVertex != -1;
				if (flag2)
				{
					this.PutHighlightEnd(ref printContext);
				}
				if (printContext.indexOffset < printContext.m.vSize)
				{
					this.Align(ref printContext);
					printContext.indexOffset = printContext.m.vSize;
				}
				printContext.previousX = printContext.x;
				printContext.x = 0;
				printContext.y += printContext.lineHeight;
				printContext.prev = 0;
				if (flag2)
				{
					this.PutHighlightStart(ref printContext);
					goto IL_E19;
				}
				goto IL_E19;
			}
			printContext.previousX = printContext.x;
			if (printContext.highlightVertex != -1)
			{
				this.PutHighlightEnd(ref printContext);
			}
			else if (printContext.j == printContext.carratIndex)
			{
				this.DrawCarat(ref printContext);
			}
			if (printContext.indexOffset < printContext.m.vSize)
			{
				this.Align(ref printContext);
				printContext.indexOffset = printContext.m.vSize;
			}
		}
	}

	// Token: 0x0600510E RID: 20750 RVA: 0x0013FEF8 File Offset: 0x0013E0F8
	private void PutHighlightStart(ref global::UIFont.PrintContext ctx)
	{
		if (ctx.highlightVertex != -1)
		{
			this.PutHighlightEnd(ref ctx);
		}
		float num = ctx.scale.x * ((float)ctx.highlightGlyph.width * ctx.highlightSplit);
		global::UnityEngine.Vector2 xy;
		xy.x = ctx.scale.x * (float)(ctx.previousX + ctx.highlightGlyph.offsetX) - num;
		xy.y = -ctx.scale.y * (float)(ctx.y + ctx.highlightGlyph.offsetY);
		global::UnityEngine.Vector2 xy2;
		xy2.x = xy.x + num;
		float num2 = xy2.x - xy.x;
		xy.x += num2;
		xy2.x += num2;
		xy2.y = xy.y - ctx.scale.y * (float)ctx.highlightGlyph.height;
		global::UnityEngine.Vector2 uv;
		uv.x = this.mUVRect.xMin + ctx.invX * (float)ctx.highlightGlyph.x;
		uv.y = this.mUVRect.yMax - ctx.invY * (float)ctx.highlightGlyph.y;
		global::UnityEngine.Vector2 uv2;
		uv2.x = uv.x + ctx.invX * (float)ctx.highlightGlyph.width * ctx.highlightSplit;
		uv2.y = uv.y - ctx.invY * (float)ctx.highlightGlyph.height;
		ctx.m.FastQuad(xy, xy2, uv, uv2, ctx.highlightBarColor);
		ctx.highlightVertex = ctx.m.FastQuad(new global::UnityEngine.Vector2(xy2.x, xy.y), xy2, new global::UnityEngine.Vector2(uv2.x, uv.y), uv2, ctx.highlightBarColor);
		float x = xy2.x;
		xy2.x = xy.x + ctx.scale.x * (float)ctx.highlightGlyph.width;
		xy.x = x;
		x = uv2.x;
		uv2.x = uv.x + ctx.invX * (float)ctx.highlightGlyph.width;
		uv.x = x;
		ctx.m.FastQuad(xy, xy2, uv, uv2, ctx.highlightBarColor);
	}

	// Token: 0x0600510F RID: 20751 RVA: 0x00140164 File Offset: 0x0013E364
	private void PutHighlightEnd(ref global::UIFont.PrintContext ctx)
	{
		if (ctx.highlightVertex == -1)
		{
			return;
		}
		float num = ctx.scale.x * (float)(ctx.previousX + ctx.highlightGlyph.offsetX) - ctx.m.v[ctx.highlightVertex].x;
		if (num > 0f)
		{
			global::NGUI.Meshing.Vertex[] v = ctx.m.v;
			int highlightVertex = ctx.highlightVertex;
			v[highlightVertex].x = v[highlightVertex].x + num;
			global::NGUI.Meshing.Vertex[] v2 = ctx.m.v;
			int num2 = ctx.highlightVertex + 1;
			v2[num2].x = v2[num2].x + num;
			global::NGUI.Meshing.Vertex[] v3 = ctx.m.v;
			int num3 = ctx.highlightVertex + 4;
			v3[num3].x = v3[num3].x + num;
			global::NGUI.Meshing.Vertex[] v4 = ctx.m.v;
			int num4 = ctx.highlightVertex + 4 + 1;
			v4[num4].x = v4[num4].x + num;
			global::NGUI.Meshing.Vertex[] v5 = ctx.m.v;
			int num5 = ctx.highlightVertex + 4 + 2;
			v5[num5].x = v5[num5].x + num;
			global::NGUI.Meshing.Vertex[] v6 = ctx.m.v;
			int num6 = ctx.highlightVertex + 4 + 3;
			v6[num6].x = v6[num6].x + num;
		}
		ctx.highlightVertex = -1;
	}

	// Token: 0x06005110 RID: 20752 RVA: 0x001402B0 File Offset: 0x0013E4B0
	private void DrawCarat(ref global::UIFont.PrintContext ctx)
	{
		global::UnityEngine.Vector2 xy;
		xy.x = ctx.scale.x * (float)(ctx.previousX + ctx.carratGlyph.offsetX);
		xy.y = -ctx.scale.y * (float)(ctx.y + ctx.carratGlyph.offsetY);
		global::UnityEngine.Vector2 xy2;
		xy2.x = xy.x + ctx.scale.x * (float)ctx.carratGlyph.width;
		xy2.y = xy.y - ctx.scale.y * (float)ctx.carratGlyph.height;
		global::UnityEngine.Vector2 uv;
		uv.x = this.mUVRect.xMin + ctx.invX * (float)ctx.carratGlyph.x;
		uv.y = this.mUVRect.yMax - ctx.invY * (float)ctx.carratGlyph.y;
		global::UnityEngine.Vector2 uv2;
		uv2.x = uv.x + ctx.invX * (float)ctx.carratGlyph.width;
		uv2.y = uv.y - ctx.invY * (float)ctx.carratGlyph.height;
		ctx.m.FastQuad(xy, xy2, uv, uv2, ctx.normalColor);
	}

	// Token: 0x04002D86 RID: 11654
	private const int mangleStartSize = 8;

	// Token: 0x04002D87 RID: 11655
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material mMat;

	// Token: 0x04002D88 RID: 11656
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Rect mUVRect = new global::UnityEngine.Rect(0f, 0f, 1f, 1f);

	// Token: 0x04002D89 RID: 11657
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::BMFont mFont = new global::BMFont();

	// Token: 0x04002D8A RID: 11658
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mSpacingX;

	// Token: 0x04002D8B RID: 11659
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mSpacingY;

	// Token: 0x04002D8C RID: 11660
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIAtlas mAtlas;

	// Token: 0x04002D8D RID: 11661
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIFont mReplacement;

	// Token: 0x04002D8E RID: 11662
	private global::UIAtlas.Sprite mSprite;

	// Token: 0x04002D8F RID: 11663
	private bool mSpriteSet;

	// Token: 0x04002D90 RID: 11664
	private global::System.Collections.Generic.List<global::UnityEngine.Color> mColors = new global::System.Collections.Generic.List<global::UnityEngine.Color>();

	// Token: 0x04002D91 RID: 11665
	private static global::System.Collections.Generic.List<global::UITextMarkup> _tempMarkup;

	// Token: 0x04002D92 RID: 11666
	private static global::UnityEngine.Vector3[] manglePoints = new global::UnityEngine.Vector3[8];

	// Token: 0x04002D93 RID: 11667
	private static int[] mangleIndices = new int[8];

	// Token: 0x04002D94 RID: 11668
	private static global::UITextPosition[] manglePositions = new global::UITextPosition[8];

	// Token: 0x04002D95 RID: 11669
	private static readonly global::UIFont.MangleSorter mangleSort = new global::UIFont.MangleSorter();

	// Token: 0x04002D96 RID: 11670
	private static readonly global::UITextPosition[] empty = new global::UITextPosition[0];

	// Token: 0x0200094D RID: 2381
	public enum Alignment
	{
		// Token: 0x04002D98 RID: 11672
		Left,
		// Token: 0x04002D99 RID: 11673
		Center,
		// Token: 0x04002D9A RID: 11674
		Right,
		// Token: 0x04002D9B RID: 11675
		LeftOverflowRight
	}

	// Token: 0x0200094E RID: 2382
	public enum SymbolStyle
	{
		// Token: 0x04002D9D RID: 11677
		None,
		// Token: 0x04002D9E RID: 11678
		Uncolored,
		// Token: 0x04002D9F RID: 11679
		Colored
	}

	// Token: 0x0200094F RID: 2383
	private class MangleSorter : global::System.Collections.Generic.Comparer<global::UnityEngine.Vector3>
	{
		// Token: 0x06005111 RID: 20753 RVA: 0x00140400 File Offset: 0x0013E600
		public MangleSorter()
		{
		}

		// Token: 0x06005112 RID: 20754 RVA: 0x00140434 File Offset: 0x0013E634
		public void SetLineSizing(double height, double spacing)
		{
			if (height == 0.0)
			{
				if (spacing == 0.0)
				{
					this.noLineSize = true;
				}
				else
				{
					this.lineHeight = spacing;
					this.noVSpacing = true;
					this.noLineSize = false;
				}
			}
			else
			{
				this.lineHeight = height;
				if (spacing == 0.0)
				{
					this.noVSpacing = true;
					this.noLineSize = false;
				}
				else if (spacing == -height)
				{
					this.noLineSize = true;
					this.noVSpacing = true;
				}
				else
				{
					this.vSpacing = spacing;
					this.noLineSize = false;
					this.noVSpacing = false;
				}
			}
		}

		// Token: 0x06005113 RID: 20755 RVA: 0x001404E0 File Offset: 0x0013E6E0
		public override int Compare(global::UnityEngine.Vector3 x, global::UnityEngine.Vector3 y)
		{
			int num3;
			if (!this.noLineSize)
			{
				double num = (double)x.y / this.lineHeight;
				double num2 = (double)y.y / this.lineHeight;
				if (!this.noVSpacing)
				{
					if (num >= 1.0 || num <= -1.0)
					{
						num = ((double)x.y - this.lineHeight) / (this.lineHeight + this.vSpacing);
					}
					if (num2 >= 1.0 || num2 <= -1.0)
					{
						num2 = ((double)y.y - this.lineHeight) / (this.lineHeight + this.vSpacing);
					}
				}
				if (num < 0.0)
				{
					num = -global::System.Math.Ceiling(-num);
				}
				else
				{
					num = global::System.Math.Floor(num);
				}
				if (num2 < 0.0)
				{
					num2 = -global::System.Math.Ceiling(-num2);
				}
				else
				{
					num2 = global::System.Math.Floor(num2);
				}
				num3 = num.CompareTo(num2);
			}
			else
			{
				num3 = x.y.CompareTo(y.y);
			}
			if (num3 == 0)
			{
				num3 = x.x.CompareTo(y.x);
				if (num3 == 0)
				{
					num3 = x.z.CompareTo(y.z);
				}
			}
			return num3;
		}

		// Token: 0x04002DA0 RID: 11680
		public double lineHeight = 12.0;

		// Token: 0x04002DA1 RID: 11681
		public double vSpacing = 12.0;

		// Token: 0x04002DA2 RID: 11682
		private bool noLineSize;

		// Token: 0x04002DA3 RID: 11683
		private bool noVSpacing;
	}

	// Token: 0x02000950 RID: 2384
	private struct PrintContext
	{
		// Token: 0x04002DA4 RID: 11684
		public global::NGUI.Meshing.MeshBuffer m;

		// Token: 0x04002DA5 RID: 11685
		public global::BMGlyph glyph;

		// Token: 0x04002DA6 RID: 11686
		public global::BMGlyph highlightGlyph;

		// Token: 0x04002DA7 RID: 11687
		public global::BMGlyph carratGlyph;

		// Token: 0x04002DA8 RID: 11688
		public global::BMSymbol symbol;

		// Token: 0x04002DA9 RID: 11689
		public string text;

		// Token: 0x04002DAA RID: 11690
		public global::UIHighlight highlight;

		// Token: 0x04002DAB RID: 11691
		public global::UnityEngine.Color printColor;

		// Token: 0x04002DAC RID: 11692
		public global::UnityEngine.Color nonHighlightColor;

		// Token: 0x04002DAD RID: 11693
		public global::UnityEngine.Color normalColor;

		// Token: 0x04002DAE RID: 11694
		public global::UnityEngine.Color highlightTextColor;

		// Token: 0x04002DAF RID: 11695
		public global::UnityEngine.Color highlightBarColor;

		// Token: 0x04002DB0 RID: 11696
		public global::UnityEngine.Vector3 v0;

		// Token: 0x04002DB1 RID: 11697
		public global::UnityEngine.Vector3 v1;

		// Token: 0x04002DB2 RID: 11698
		public global::UnityEngine.Vector2 u0;

		// Token: 0x04002DB3 RID: 11699
		public global::UnityEngine.Vector2 u1;

		// Token: 0x04002DB4 RID: 11700
		public global::UnityEngine.Vector2 scale;

		// Token: 0x04002DB5 RID: 11701
		public float invX;

		// Token: 0x04002DB6 RID: 11702
		public float invY;

		// Token: 0x04002DB7 RID: 11703
		public float highlightSplit;

		// Token: 0x04002DB8 RID: 11704
		public int x;

		// Token: 0x04002DB9 RID: 11705
		public int maxX;

		// Token: 0x04002DBA RID: 11706
		public int previousX;

		// Token: 0x04002DBB RID: 11707
		public int y;

		// Token: 0x04002DBC RID: 11708
		public int highlightVertex;

		// Token: 0x04002DBD RID: 11709
		public int prev;

		// Token: 0x04002DBE RID: 11710
		public int lineHeight;

		// Token: 0x04002DBF RID: 11711
		public int lineWidth;

		// Token: 0x04002DC0 RID: 11712
		public int indexOffset;

		// Token: 0x04002DC1 RID: 11713
		public int textLength;

		// Token: 0x04002DC2 RID: 11714
		public int i;

		// Token: 0x04002DC3 RID: 11715
		public int carratIndex;

		// Token: 0x04002DC4 RID: 11716
		public int j;

		// Token: 0x04002DC5 RID: 11717
		public global::UIFont.Alignment alignment;

		// Token: 0x04002DC6 RID: 11718
		public char carratChar;

		// Token: 0x04002DC7 RID: 11719
		public char highlightChar;

		// Token: 0x04002DC8 RID: 11720
		public char c;

		// Token: 0x04002DC9 RID: 11721
		public bool highlightBarDraw;

		// Token: 0x04002DCA RID: 11722
		public bool isLineEnd;

		// Token: 0x04002DCB RID: 11723
		public bool skipSymbols;

		// Token: 0x04002DCC RID: 11724
		public bool printChar;
	}
}
