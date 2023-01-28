using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

// Token: 0x0200086E RID: 2158
public struct dfMarkupStyle
{
	// Token: 0x06004AB7 RID: 19127 RVA: 0x0011910C File Offset: 0x0011730C
	public dfMarkupStyle(global::dfDynamicFont Font, int FontSize, global::UnityEngine.FontStyle FontStyle)
	{
		this.Host = null;
		this.Atlas = null;
		this.Font = Font;
		this.FontSize = FontSize;
		this.FontStyle = FontStyle;
		this.Align = global::dfMarkupTextAlign.Left;
		this.VerticalAlign = global::dfMarkupVerticalAlign.Baseline;
		this.Color = global::UnityEngine.Color.white;
		this.BackgroundColor = global::UnityEngine.Color.clear;
		this.TextDecoration = global::dfMarkupTextDecoration.None;
		this.PreserveWhitespace = false;
		this.Preformatted = false;
		this.WordSpacing = 0;
		this.CharacterSpacing = 0;
		this.lineHeight = 0;
		this.Opacity = 1f;
	}

	// Token: 0x06004AB8 RID: 19128 RVA: 0x00119198 File Offset: 0x00117398
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupStyle()
	{
	}

	// Token: 0x17000DFC RID: 3580
	// (get) Token: 0x06004AB9 RID: 19129 RVA: 0x00119348 File Offset: 0x00117548
	// (set) Token: 0x06004ABA RID: 19130 RVA: 0x00119374 File Offset: 0x00117574
	public int LineHeight
	{
		get
		{
			if (this.lineHeight == 0)
			{
				return global::UnityEngine.Mathf.CeilToInt((float)this.FontSize);
			}
			return global::UnityEngine.Mathf.Max(this.FontSize, this.lineHeight);
		}
		set
		{
			this.lineHeight = value;
		}
	}

	// Token: 0x06004ABB RID: 19131 RVA: 0x00119380 File Offset: 0x00117580
	public static global::dfMarkupTextDecoration ParseTextDecoration(string value)
	{
		if (value == "underline")
		{
			return global::dfMarkupTextDecoration.Underline;
		}
		if (value == "overline")
		{
			return global::dfMarkupTextDecoration.Overline;
		}
		if (value == "line-through")
		{
			return global::dfMarkupTextDecoration.LineThrough;
		}
		return global::dfMarkupTextDecoration.None;
	}

	// Token: 0x06004ABC RID: 19132 RVA: 0x001193BC File Offset: 0x001175BC
	public static global::dfMarkupVerticalAlign ParseVerticalAlignment(string value)
	{
		if (value == "top")
		{
			return global::dfMarkupVerticalAlign.Top;
		}
		if (value == "center" || value == "middle")
		{
			return global::dfMarkupVerticalAlign.Middle;
		}
		if (value == "bottom")
		{
			return global::dfMarkupVerticalAlign.Bottom;
		}
		return global::dfMarkupVerticalAlign.Baseline;
	}

	// Token: 0x06004ABD RID: 19133 RVA: 0x00119410 File Offset: 0x00117610
	public static global::dfMarkupTextAlign ParseTextAlignment(string value)
	{
		if (value == "right")
		{
			return global::dfMarkupTextAlign.Right;
		}
		if (value == "center")
		{
			return global::dfMarkupTextAlign.Center;
		}
		if (value == "justify")
		{
			return global::dfMarkupTextAlign.Justify;
		}
		return global::dfMarkupTextAlign.Left;
	}

	// Token: 0x06004ABE RID: 19134 RVA: 0x0011944C File Offset: 0x0011764C
	public static global::UnityEngine.FontStyle ParseFontStyle(string value, global::UnityEngine.FontStyle baseStyle)
	{
		if (value == "normal")
		{
			return 0;
		}
		if (value == "bold")
		{
			if (baseStyle == null)
			{
				return 1;
			}
			if (baseStyle == 2)
			{
				return 3;
			}
		}
		else if (value == "italic")
		{
			if (baseStyle == null)
			{
				return 2;
			}
			if (baseStyle == 1)
			{
				return 3;
			}
		}
		return baseStyle;
	}

	// Token: 0x06004ABF RID: 19135 RVA: 0x001194B4 File Offset: 0x001176B4
	public static int ParseSize(string value, int baseValue)
	{
		int num;
		if (value.Length > 1 && value.EndsWith("%") && int.TryParse(value.TrimEnd(new char[]
		{
			'%'
		}), out num))
		{
			return (int)((float)baseValue * ((float)num / 100f));
		}
		if (value.EndsWith("px"))
		{
			value = value.Substring(0, value.Length - 2);
		}
		int result;
		if (int.TryParse(value, out result))
		{
			return result;
		}
		return baseValue;
	}

	// Token: 0x06004AC0 RID: 19136 RVA: 0x00119538 File Offset: 0x00117738
	public static global::UnityEngine.Color ParseColor(string color, global::UnityEngine.Color defaultColor)
	{
		global::UnityEngine.Color result = defaultColor;
		global::UnityEngine.Color color3;
		if (color.StartsWith("#"))
		{
			uint color2 = 0U;
			if (uint.TryParse(color.Substring(1), global::System.Globalization.NumberStyles.HexNumber, null, out color2))
			{
				result = global::dfMarkupStyle.UIntToColor(color2);
			}
			else
			{
				result = global::UnityEngine.Color.red;
			}
		}
		else if (global::dfMarkupStyle.namedColors.TryGetValue(color.ToLowerInvariant(), out color3))
		{
			result = color3;
		}
		return result;
	}

	// Token: 0x06004AC1 RID: 19137 RVA: 0x001195A8 File Offset: 0x001177A8
	private static global::UnityEngine.Color32 UIntToColor(uint color)
	{
		byte b = (byte)(color >> 0x10);
		byte b2 = (byte)(color >> 8);
		byte b3 = (byte)color;
		return new global::UnityEngine.Color32(b, b2, b3, byte.MaxValue);
	}

	// Token: 0x040027D6 RID: 10198
	private static global::System.Collections.Generic.Dictionary<string, global::UnityEngine.Color> namedColors = new global::System.Collections.Generic.Dictionary<string, global::UnityEngine.Color>
	{
		{
			"aqua",
			global::dfMarkupStyle.UIntToColor(0xFFFFU)
		},
		{
			"black",
			global::UnityEngine.Color.black
		},
		{
			"blue",
			global::UnityEngine.Color.blue
		},
		{
			"cyan",
			global::UnityEngine.Color.cyan
		},
		{
			"fuchsia",
			global::dfMarkupStyle.UIntToColor(0xFF00FFU)
		},
		{
			"gray",
			global::UnityEngine.Color.gray
		},
		{
			"green",
			global::UnityEngine.Color.green
		},
		{
			"lime",
			global::dfMarkupStyle.UIntToColor(0xFF00U)
		},
		{
			"magenta",
			global::UnityEngine.Color.magenta
		},
		{
			"maroon",
			global::dfMarkupStyle.UIntToColor(0x800000U)
		},
		{
			"navy",
			global::dfMarkupStyle.UIntToColor(0x80U)
		},
		{
			"olive",
			global::dfMarkupStyle.UIntToColor(0x808000U)
		},
		{
			"orange",
			global::dfMarkupStyle.UIntToColor(0xFFA500U)
		},
		{
			"purple",
			global::dfMarkupStyle.UIntToColor(0x800080U)
		},
		{
			"red",
			global::UnityEngine.Color.red
		},
		{
			"silver",
			global::dfMarkupStyle.UIntToColor(0xC0C0C0U)
		},
		{
			"teal",
			global::dfMarkupStyle.UIntToColor(0x8080U)
		},
		{
			"white",
			global::UnityEngine.Color.white
		},
		{
			"yellow",
			global::UnityEngine.Color.yellow
		}
	};

	// Token: 0x040027D7 RID: 10199
	public global::dfRichTextLabel Host;

	// Token: 0x040027D8 RID: 10200
	public global::dfAtlas Atlas;

	// Token: 0x040027D9 RID: 10201
	public global::dfDynamicFont Font;

	// Token: 0x040027DA RID: 10202
	public int FontSize;

	// Token: 0x040027DB RID: 10203
	public global::UnityEngine.FontStyle FontStyle;

	// Token: 0x040027DC RID: 10204
	public global::dfMarkupTextDecoration TextDecoration;

	// Token: 0x040027DD RID: 10205
	public global::dfMarkupTextAlign Align;

	// Token: 0x040027DE RID: 10206
	public global::dfMarkupVerticalAlign VerticalAlign;

	// Token: 0x040027DF RID: 10207
	public global::UnityEngine.Color Color;

	// Token: 0x040027E0 RID: 10208
	public global::UnityEngine.Color BackgroundColor;

	// Token: 0x040027E1 RID: 10209
	public float Opacity;

	// Token: 0x040027E2 RID: 10210
	public bool PreserveWhitespace;

	// Token: 0x040027E3 RID: 10211
	public bool Preformatted;

	// Token: 0x040027E4 RID: 10212
	public int WordSpacing;

	// Token: 0x040027E5 RID: 10213
	public int CharacterSpacing;

	// Token: 0x040027E6 RID: 10214
	private int lineHeight;
}
