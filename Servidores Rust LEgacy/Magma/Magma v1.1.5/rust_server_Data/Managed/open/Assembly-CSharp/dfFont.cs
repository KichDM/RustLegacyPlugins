using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

// Token: 0x020007FE RID: 2046
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Font Definition")]
public class dfFont : global::dfFontBase
{
	// Token: 0x0600445D RID: 17501 RVA: 0x000F97F8 File Offset: 0x000F79F8
	public dfFont()
	{
	}

	// Token: 0x17000C9F RID: 3231
	// (get) Token: 0x0600445E RID: 17502 RVA: 0x000F9824 File Offset: 0x000F7A24
	public global::System.Collections.Generic.List<global::dfFont.GlyphDefinition> Glyphs
	{
		get
		{
			return this.glyphs;
		}
	}

	// Token: 0x17000CA0 RID: 3232
	// (get) Token: 0x0600445F RID: 17503 RVA: 0x000F982C File Offset: 0x000F7A2C
	public global::System.Collections.Generic.List<global::dfFont.GlyphKerning> KerningInfo
	{
		get
		{
			return this.kerning;
		}
	}

	// Token: 0x17000CA1 RID: 3233
	// (get) Token: 0x06004460 RID: 17504 RVA: 0x000F9834 File Offset: 0x000F7A34
	// (set) Token: 0x06004461 RID: 17505 RVA: 0x000F983C File Offset: 0x000F7A3C
	public global::dfAtlas Atlas
	{
		get
		{
			return this.atlas;
		}
		set
		{
			if (value != this.atlas)
			{
				this.atlas = value;
				this.glyphMap = null;
			}
		}
	}

	// Token: 0x17000CA2 RID: 3234
	// (get) Token: 0x06004462 RID: 17506 RVA: 0x000F9860 File Offset: 0x000F7A60
	// (set) Token: 0x06004463 RID: 17507 RVA: 0x000F9870 File Offset: 0x000F7A70
	public override global::UnityEngine.Material Material
	{
		get
		{
			return this.Atlas.Material;
		}
		set
		{
			throw new global::System.InvalidOperationException();
		}
	}

	// Token: 0x17000CA3 RID: 3235
	// (get) Token: 0x06004464 RID: 17508 RVA: 0x000F9878 File Offset: 0x000F7A78
	public override global::UnityEngine.Texture Texture
	{
		get
		{
			return this.Atlas.Texture;
		}
	}

	// Token: 0x17000CA4 RID: 3236
	// (get) Token: 0x06004465 RID: 17509 RVA: 0x000F9888 File Offset: 0x000F7A88
	// (set) Token: 0x06004466 RID: 17510 RVA: 0x000F9890 File Offset: 0x000F7A90
	public string Sprite
	{
		get
		{
			return this.sprite;
		}
		set
		{
			if (value != this.sprite)
			{
				this.sprite = value;
				this.glyphMap = null;
			}
		}
	}

	// Token: 0x17000CA5 RID: 3237
	// (get) Token: 0x06004467 RID: 17511 RVA: 0x000F98B4 File Offset: 0x000F7AB4
	public override bool IsValid
	{
		get
		{
			return !(this.Atlas == null) && !(this.Atlas[this.Sprite] == null);
		}
	}

	// Token: 0x17000CA6 RID: 3238
	// (get) Token: 0x06004468 RID: 17512 RVA: 0x000F98F4 File Offset: 0x000F7AF4
	public string FontFace
	{
		get
		{
			return this.face;
		}
	}

	// Token: 0x17000CA7 RID: 3239
	// (get) Token: 0x06004469 RID: 17513 RVA: 0x000F98FC File Offset: 0x000F7AFC
	// (set) Token: 0x0600446A RID: 17514 RVA: 0x000F9904 File Offset: 0x000F7B04
	public override int FontSize
	{
		get
		{
			return this.size;
		}
		set
		{
			throw new global::System.InvalidOperationException();
		}
	}

	// Token: 0x17000CA8 RID: 3240
	// (get) Token: 0x0600446B RID: 17515 RVA: 0x000F990C File Offset: 0x000F7B0C
	// (set) Token: 0x0600446C RID: 17516 RVA: 0x000F9914 File Offset: 0x000F7B14
	public override int LineHeight
	{
		get
		{
			return this.lineHeight;
		}
		set
		{
			throw new global::System.InvalidOperationException();
		}
	}

	// Token: 0x17000CA9 RID: 3241
	// (get) Token: 0x0600446D RID: 17517 RVA: 0x000F991C File Offset: 0x000F7B1C
	public bool Bold
	{
		get
		{
			return this.bold;
		}
	}

	// Token: 0x17000CAA RID: 3242
	// (get) Token: 0x0600446E RID: 17518 RVA: 0x000F9924 File Offset: 0x000F7B24
	public bool Italic
	{
		get
		{
			return this.italic;
		}
	}

	// Token: 0x17000CAB RID: 3243
	// (get) Token: 0x0600446F RID: 17519 RVA: 0x000F992C File Offset: 0x000F7B2C
	public int[] Padding
	{
		get
		{
			return this.padding;
		}
	}

	// Token: 0x17000CAC RID: 3244
	// (get) Token: 0x06004470 RID: 17520 RVA: 0x000F9934 File Offset: 0x000F7B34
	public int[] Spacing
	{
		get
		{
			return this.spacing;
		}
	}

	// Token: 0x17000CAD RID: 3245
	// (get) Token: 0x06004471 RID: 17521 RVA: 0x000F993C File Offset: 0x000F7B3C
	public int Outline
	{
		get
		{
			return this.outline;
		}
	}

	// Token: 0x17000CAE RID: 3246
	// (get) Token: 0x06004472 RID: 17522 RVA: 0x000F9944 File Offset: 0x000F7B44
	public int Count
	{
		get
		{
			return this.glyphs.Count;
		}
	}

	// Token: 0x06004473 RID: 17523 RVA: 0x000F9954 File Offset: 0x000F7B54
	public void OnEnable()
	{
		this.glyphMap = null;
	}

	// Token: 0x06004474 RID: 17524 RVA: 0x000F9960 File Offset: 0x000F7B60
	public override global::dfFontRendererBase ObtainRenderer()
	{
		return global::dfFont.BitmappedFontRenderer.Obtain(this);
	}

	// Token: 0x06004475 RID: 17525 RVA: 0x000F9968 File Offset: 0x000F7B68
	public void AddKerning(int first, int second, int amount)
	{
		this.kerning.Add(new global::dfFont.GlyphKerning
		{
			first = first,
			second = second,
			amount = amount
		});
	}

	// Token: 0x06004476 RID: 17526 RVA: 0x000F999C File Offset: 0x000F7B9C
	public int GetKerning(char previousChar, char currentChar)
	{
		int result;
		try
		{
			if (this.kerningMap == null)
			{
				this.buildKerningMap();
			}
			global::dfFont.GlyphKerningList glyphKerningList = null;
			if (!this.kerningMap.TryGetValue((int)previousChar, out glyphKerningList))
			{
				result = 0;
			}
			else
			{
				result = glyphKerningList.GetKerning((int)previousChar, (int)currentChar);
			}
		}
		finally
		{
		}
		return result;
	}

	// Token: 0x06004477 RID: 17527 RVA: 0x000F9A08 File Offset: 0x000F7C08
	private void buildKerningMap()
	{
		global::System.Collections.Generic.Dictionary<int, global::dfFont.GlyphKerningList> dictionary = this.kerningMap = new global::System.Collections.Generic.Dictionary<int, global::dfFont.GlyphKerningList>();
		for (int i = 0; i < this.kerning.Count; i++)
		{
			global::dfFont.GlyphKerning glyphKerning = this.kerning[i];
			if (!dictionary.ContainsKey(glyphKerning.first))
			{
				dictionary[glyphKerning.first] = new global::dfFont.GlyphKerningList();
			}
			global::dfFont.GlyphKerningList glyphKerningList = dictionary[glyphKerning.first];
			glyphKerningList.Add(glyphKerning);
		}
	}

	// Token: 0x06004478 RID: 17528 RVA: 0x000F9A88 File Offset: 0x000F7C88
	public global::dfFont.GlyphDefinition GetGlyph(char id)
	{
		if (this.glyphMap == null)
		{
			this.glyphMap = new global::System.Collections.Generic.Dictionary<int, global::dfFont.GlyphDefinition>();
			for (int i = 0; i < this.glyphs.Count; i++)
			{
				global::dfFont.GlyphDefinition glyphDefinition = this.glyphs[i];
				this.glyphMap[glyphDefinition.id] = glyphDefinition;
			}
		}
		global::dfFont.GlyphDefinition result = null;
		this.glyphMap.TryGetValue((int)id, out result);
		return result;
	}

	// Token: 0x04002474 RID: 9332
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002475 RID: 9333
	[global::UnityEngine.SerializeField]
	protected string sprite;

	// Token: 0x04002476 RID: 9334
	[global::UnityEngine.SerializeField]
	protected string face = string.Empty;

	// Token: 0x04002477 RID: 9335
	[global::UnityEngine.SerializeField]
	protected int size;

	// Token: 0x04002478 RID: 9336
	[global::UnityEngine.SerializeField]
	protected bool bold;

	// Token: 0x04002479 RID: 9337
	[global::UnityEngine.SerializeField]
	protected bool italic;

	// Token: 0x0400247A RID: 9338
	[global::UnityEngine.SerializeField]
	protected string charset;

	// Token: 0x0400247B RID: 9339
	[global::UnityEngine.SerializeField]
	protected int stretchH;

	// Token: 0x0400247C RID: 9340
	[global::UnityEngine.SerializeField]
	protected bool smooth;

	// Token: 0x0400247D RID: 9341
	[global::UnityEngine.SerializeField]
	protected int aa;

	// Token: 0x0400247E RID: 9342
	[global::UnityEngine.SerializeField]
	protected int[] padding;

	// Token: 0x0400247F RID: 9343
	[global::UnityEngine.SerializeField]
	protected int[] spacing;

	// Token: 0x04002480 RID: 9344
	[global::UnityEngine.SerializeField]
	protected int outline;

	// Token: 0x04002481 RID: 9345
	[global::UnityEngine.SerializeField]
	protected int lineHeight;

	// Token: 0x04002482 RID: 9346
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::dfFont.GlyphDefinition> glyphs = new global::System.Collections.Generic.List<global::dfFont.GlyphDefinition>();

	// Token: 0x04002483 RID: 9347
	[global::UnityEngine.SerializeField]
	protected global::System.Collections.Generic.List<global::dfFont.GlyphKerning> kerning = new global::System.Collections.Generic.List<global::dfFont.GlyphKerning>();

	// Token: 0x04002484 RID: 9348
	private global::System.Collections.Generic.Dictionary<int, global::dfFont.GlyphDefinition> glyphMap;

	// Token: 0x04002485 RID: 9349
	private global::System.Collections.Generic.Dictionary<int, global::dfFont.GlyphKerningList> kerningMap;

	// Token: 0x020007FF RID: 2047
	private class GlyphKerningList
	{
		// Token: 0x06004479 RID: 17529 RVA: 0x000F9AF8 File Offset: 0x000F7CF8
		public GlyphKerningList()
		{
		}

		// Token: 0x0600447A RID: 17530 RVA: 0x000F9B0C File Offset: 0x000F7D0C
		public void Add(global::dfFont.GlyphKerning kerning)
		{
			this.list[kerning.second] = kerning.amount;
		}

		// Token: 0x0600447B RID: 17531 RVA: 0x000F9B28 File Offset: 0x000F7D28
		public int GetKerning(int firstCharacter, int secondCharacter)
		{
			int result = 0;
			this.list.TryGetValue(secondCharacter, out result);
			return result;
		}

		// Token: 0x04002486 RID: 9350
		private global::System.Collections.Generic.Dictionary<int, int> list = new global::System.Collections.Generic.Dictionary<int, int>();
	}

	// Token: 0x02000800 RID: 2048
	[global::System.Serializable]
	public class GlyphKerning : global::System.IComparable<global::dfFont.GlyphKerning>
	{
		// Token: 0x0600447C RID: 17532 RVA: 0x000F9B48 File Offset: 0x000F7D48
		public GlyphKerning()
		{
		}

		// Token: 0x0600447D RID: 17533 RVA: 0x000F9B50 File Offset: 0x000F7D50
		public int CompareTo(global::dfFont.GlyphKerning other)
		{
			if (this.first == other.first)
			{
				return this.second.CompareTo(other.second);
			}
			return this.first.CompareTo(other.first);
		}

		// Token: 0x04002487 RID: 9351
		public int first;

		// Token: 0x04002488 RID: 9352
		public int second;

		// Token: 0x04002489 RID: 9353
		public int amount;
	}

	// Token: 0x02000801 RID: 2049
	[global::System.Serializable]
	public class GlyphDefinition : global::System.IComparable<global::dfFont.GlyphDefinition>
	{
		// Token: 0x0600447E RID: 17534 RVA: 0x000F9B94 File Offset: 0x000F7D94
		public GlyphDefinition()
		{
		}

		// Token: 0x0600447F RID: 17535 RVA: 0x000F9B9C File Offset: 0x000F7D9C
		public int CompareTo(global::dfFont.GlyphDefinition other)
		{
			return this.id.CompareTo(other.id);
		}

		// Token: 0x0400248A RID: 9354
		[global::UnityEngine.SerializeField]
		public int id;

		// Token: 0x0400248B RID: 9355
		[global::UnityEngine.SerializeField]
		public int x;

		// Token: 0x0400248C RID: 9356
		[global::UnityEngine.SerializeField]
		public int y;

		// Token: 0x0400248D RID: 9357
		[global::UnityEngine.SerializeField]
		public int width;

		// Token: 0x0400248E RID: 9358
		[global::UnityEngine.SerializeField]
		public int height;

		// Token: 0x0400248F RID: 9359
		[global::UnityEngine.SerializeField]
		public int xoffset;

		// Token: 0x04002490 RID: 9360
		[global::UnityEngine.SerializeField]
		public int yoffset;

		// Token: 0x04002491 RID: 9361
		[global::UnityEngine.SerializeField]
		public int xadvance;

		// Token: 0x04002492 RID: 9362
		[global::UnityEngine.SerializeField]
		public bool rotated;
	}

	// Token: 0x02000802 RID: 2050
	public class BitmappedFontRenderer : global::dfFontRendererBase
	{
		// Token: 0x06004480 RID: 17536 RVA: 0x000F9BB0 File Offset: 0x000F7DB0
		internal BitmappedFontRenderer()
		{
		}

		// Token: 0x06004481 RID: 17537 RVA: 0x000F9BB8 File Offset: 0x000F7DB8
		// Note: this type is marked as 'beforefieldinit'.
		static BitmappedFontRenderer()
		{
		}

		// Token: 0x17000CAF RID: 3247
		// (get) Token: 0x06004482 RID: 17538 RVA: 0x000F9C68 File Offset: 0x000F7E68
		public int LineCount
		{
			get
			{
				return this.lines.Count;
			}
		}

		// Token: 0x06004483 RID: 17539 RVA: 0x000F9C78 File Offset: 0x000F7E78
		public static global::dfFontRendererBase Obtain(global::dfFont font)
		{
			global::dfFont.BitmappedFontRenderer bitmappedFontRenderer = (global::dfFont.BitmappedFontRenderer.objectPool.Count <= 0) ? new global::dfFont.BitmappedFontRenderer() : global::dfFont.BitmappedFontRenderer.objectPool.Dequeue();
			bitmappedFontRenderer.Reset();
			bitmappedFontRenderer.Font = font;
			return bitmappedFontRenderer;
		}

		// Token: 0x06004484 RID: 17540 RVA: 0x000F9CB8 File Offset: 0x000F7EB8
		public override void Release()
		{
			this.Reset();
			this.tokens = null;
			if (this.lines != null)
			{
				this.lines.Release();
				this.lines = null;
			}
			global::dfFont.LineRenderInfo.ResetPool();
			base.BottomColor = null;
			global::dfFont.BitmappedFontRenderer.objectPool.Enqueue(this);
		}

		// Token: 0x06004485 RID: 17541 RVA: 0x000F9D10 File Offset: 0x000F7F10
		public override float[] GetCharacterWidths(string text)
		{
			float num = 0f;
			return this.GetCharacterWidths(text, 0, text.Length - 1, out num);
		}

		// Token: 0x06004486 RID: 17542 RVA: 0x000F9D38 File Offset: 0x000F7F38
		public float[] GetCharacterWidths(string text, int startIndex, int endIndex, out float totalWidth)
		{
			totalWidth = 0f;
			global::dfFont dfFont = (global::dfFont)base.Font;
			float[] array = new float[text.Length];
			float num = base.TextScale * base.PixelRatio;
			float num2 = (float)base.CharacterSpacing * num;
			for (int i = startIndex; i <= endIndex; i++)
			{
				global::dfFont.GlyphDefinition glyph = dfFont.GetGlyph(text[i]);
				if (glyph != null)
				{
					if (i > 0)
					{
						array[i - 1] += num2;
						totalWidth += num2;
					}
					float num3 = (float)glyph.xadvance * num;
					array[i] = num3;
					totalWidth += num3;
				}
			}
			return array;
		}

		// Token: 0x06004487 RID: 17543 RVA: 0x000F9DEC File Offset: 0x000F7FEC
		public override global::UnityEngine.Vector2 MeasureString(string text)
		{
			this.tokenize(text);
			global::dfList<global::dfFont.LineRenderInfo> dfList = this.calculateLinebreaks();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < dfList.Count; i++)
			{
				num = global::UnityEngine.Mathf.Max((int)dfList[i].lineWidth, num);
				num2 += (int)dfList[i].lineHeight;
			}
			return new global::UnityEngine.Vector2((float)num, (float)num2) * base.TextScale;
		}

		// Token: 0x06004488 RID: 17544 RVA: 0x000F9E5C File Offset: 0x000F805C
		public override void Render(string text, global::dfRenderData destination)
		{
			global::dfFont.BitmappedFontRenderer.textColors.Clear();
			global::dfFont.BitmappedFontRenderer.textColors.Push(global::UnityEngine.Color.white);
			this.tokenize(text);
			global::dfList<global::dfFont.LineRenderInfo> dfList = this.calculateLinebreaks();
			int num = 0;
			int num2 = 0;
			global::UnityEngine.Vector3 vectorOffset = base.VectorOffset;
			float num3 = base.TextScale * base.PixelRatio;
			for (int i = 0; i < dfList.Count; i++)
			{
				global::dfFont.LineRenderInfo lineRenderInfo = dfList[i];
				int count = destination.Vertices.Count;
				this.renderLine(dfList[i], global::dfFont.BitmappedFontRenderer.textColors, vectorOffset, destination);
				vectorOffset.y -= (float)base.Font.LineHeight * num3;
				num = global::UnityEngine.Mathf.Max((int)lineRenderInfo.lineWidth, num);
				num2 += (int)lineRenderInfo.lineHeight;
				if (lineRenderInfo.lineWidth * base.TextScale > base.MaxSize.x)
				{
					this.clipRight(destination, count);
				}
				if ((float)num2 * base.TextScale > base.MaxSize.y)
				{
					this.clipBottom(destination, count);
				}
			}
			base.RenderedSize = new global::UnityEngine.Vector2(global::UnityEngine.Mathf.Min(base.MaxSize.x, (float)num), global::UnityEngine.Mathf.Min(base.MaxSize.y, (float)num2)) * base.TextScale;
		}

		// Token: 0x06004489 RID: 17545 RVA: 0x000F9FC4 File Offset: 0x000F81C4
		private void renderLine(global::dfFont.LineRenderInfo line, global::System.Collections.Generic.Stack<global::UnityEngine.Color32> colors, global::UnityEngine.Vector3 position, global::dfRenderData destination)
		{
			float num = base.TextScale * base.PixelRatio;
			position.x += (float)this.calculateLineAlignment(line) * num;
			for (int i = line.startOffset; i <= line.endOffset; i++)
			{
				global::dfMarkupToken dfMarkupToken = this.tokens[i];
				global::dfMarkupTokenType tokenType = dfMarkupToken.TokenType;
				if (tokenType == global::dfMarkupTokenType.Text)
				{
					this.renderText(dfMarkupToken, colors.Peek(), position, destination);
				}
				else if (tokenType == global::dfMarkupTokenType.StartTag)
				{
					if (dfMarkupToken.Matches("sprite"))
					{
						this.renderSprite(dfMarkupToken, colors.Peek(), position, destination);
					}
					else if (dfMarkupToken.Matches("color"))
					{
						colors.Push(this.parseColor(dfMarkupToken));
					}
				}
				else if (tokenType == global::dfMarkupTokenType.EndTag && dfMarkupToken.Matches("color") && colors.Count > 1)
				{
					colors.Pop();
				}
				position.x += (float)dfMarkupToken.Width * num;
			}
		}

		// Token: 0x0600448A RID: 17546 RVA: 0x000FA0D4 File Offset: 0x000F82D4
		private void renderText(global::dfMarkupToken token, global::UnityEngine.Color32 color, global::UnityEngine.Vector3 position, global::dfRenderData destination)
		{
			try
			{
				global::dfList<global::UnityEngine.Vector3> vertices = destination.Vertices;
				global::dfList<int> triangles = destination.Triangles;
				global::dfList<global::UnityEngine.Color32> colors = destination.Colors;
				global::dfList<global::UnityEngine.Vector2> uv = destination.UV;
				global::dfFont dfFont = (global::dfFont)base.Font;
				global::dfAtlas.ItemInfo itemInfo = dfFont.Atlas[dfFont.sprite];
				global::UnityEngine.Texture texture = dfFont.Texture;
				float num = 1f / (float)texture.width;
				float num2 = 1f / (float)texture.height;
				float num3 = num * 0.125f;
				float num4 = num2 * 0.125f;
				float num5 = base.TextScale * base.PixelRatio;
				char previousChar = '\0';
				global::UnityEngine.Color32 color2 = this.applyOpacity(this.multiplyColors(color, base.DefaultColor));
				global::UnityEngine.Color32 item = color2;
				if (base.BottomColor != null)
				{
					item = this.applyOpacity(this.multiplyColors(color, base.BottomColor.Value));
				}
				int i = 0;
				while (i < token.Length)
				{
					char c = token[i];
					if (c != '\0')
					{
						global::dfFont.GlyphDefinition glyph = dfFont.GetGlyph(c);
						if (glyph != null)
						{
							int kerning = dfFont.GetKerning(previousChar, c);
							float num6 = position.x + (float)(glyph.xoffset + kerning) * num5;
							float num7 = position.y - (float)glyph.yoffset * num5;
							float num8 = (float)glyph.width * num5;
							float num9 = (float)glyph.height * num5;
							float num10 = num6 + num8;
							float num11 = num7 - num9;
							global::UnityEngine.Vector3 vector;
							vector..ctor(num6, num7);
							global::UnityEngine.Vector3 vector2;
							vector2..ctor(num10, num7);
							global::UnityEngine.Vector3 vector3;
							vector3..ctor(num10, num11);
							global::UnityEngine.Vector3 vector4;
							vector4..ctor(num6, num11);
							float num12 = itemInfo.region.x + (float)glyph.x * num - num3;
							float num13 = itemInfo.region.yMax - (float)glyph.y * num2 - num4;
							float num14 = num12 + (float)glyph.width * num - num3;
							float num15 = num13 - (float)glyph.height * num2 + num4;
							if (base.Shadow)
							{
								global::dfFont.BitmappedFontRenderer.addTriangleIndices(vertices, triangles);
								global::UnityEngine.Vector3 vector5 = base.ShadowOffset * num5;
								vertices.Add(vector + vector5);
								vertices.Add(vector2 + vector5);
								vertices.Add(vector3 + vector5);
								vertices.Add(vector4 + vector5);
								global::UnityEngine.Color32 item2 = this.applyOpacity(base.ShadowColor);
								colors.Add(item2);
								colors.Add(item2);
								colors.Add(item2);
								colors.Add(item2);
								uv.Add(new global::UnityEngine.Vector2(num12, num13));
								uv.Add(new global::UnityEngine.Vector2(num14, num13));
								uv.Add(new global::UnityEngine.Vector2(num14, num15));
								uv.Add(new global::UnityEngine.Vector2(num12, num15));
							}
							if (base.Outline)
							{
								for (int j = 0; j < global::dfFont.BitmappedFontRenderer.OUTLINE_OFFSETS.Length; j++)
								{
									global::dfFont.BitmappedFontRenderer.addTriangleIndices(vertices, triangles);
									global::UnityEngine.Vector3 vector6 = global::dfFont.BitmappedFontRenderer.OUTLINE_OFFSETS[j] * (float)base.OutlineSize * num5;
									vertices.Add(vector + vector6);
									vertices.Add(vector2 + vector6);
									vertices.Add(vector3 + vector6);
									vertices.Add(vector4 + vector6);
									global::UnityEngine.Color32 item3 = this.applyOpacity(base.OutlineColor);
									colors.Add(item3);
									colors.Add(item3);
									colors.Add(item3);
									colors.Add(item3);
									uv.Add(new global::UnityEngine.Vector2(num12, num13));
									uv.Add(new global::UnityEngine.Vector2(num14, num13));
									uv.Add(new global::UnityEngine.Vector2(num14, num15));
									uv.Add(new global::UnityEngine.Vector2(num12, num15));
								}
							}
							global::dfFont.BitmappedFontRenderer.addTriangleIndices(vertices, triangles);
							vertices.Add(vector);
							vertices.Add(vector2);
							vertices.Add(vector3);
							vertices.Add(vector4);
							colors.Add(color2);
							colors.Add(color2);
							colors.Add(item);
							colors.Add(item);
							uv.Add(new global::UnityEngine.Vector2(num12, num13));
							uv.Add(new global::UnityEngine.Vector2(num14, num13));
							uv.Add(new global::UnityEngine.Vector2(num14, num15));
							uv.Add(new global::UnityEngine.Vector2(num12, num15));
							position.x += (float)(glyph.xadvance + kerning + base.CharacterSpacing) * num5;
						}
					}
					i++;
					previousChar = c;
				}
			}
			finally
			{
			}
		}

		// Token: 0x0600448B RID: 17547 RVA: 0x000FA5AC File Offset: 0x000F87AC
		private void renderSprite(global::dfMarkupToken token, global::UnityEngine.Color32 color, global::UnityEngine.Vector3 position, global::dfRenderData destination)
		{
			try
			{
				global::dfList<global::UnityEngine.Vector3> vertices = destination.Vertices;
				global::dfList<int> triangles = destination.Triangles;
				global::dfList<global::UnityEngine.Color32> colors = destination.Colors;
				global::dfList<global::UnityEngine.Vector2> uv = destination.UV;
				global::dfFont dfFont = (global::dfFont)base.Font;
				string value = token.GetAttribute(0).Value.Value;
				global::dfAtlas.ItemInfo itemInfo = dfFont.Atlas[value];
				if (!(itemInfo == null))
				{
					float num = (float)token.Height * base.TextScale * base.PixelRatio;
					float num2 = (float)token.Width * base.TextScale * base.PixelRatio;
					float x = position.x;
					float y = position.y;
					int count = vertices.Count;
					vertices.Add(new global::UnityEngine.Vector3(x, y));
					vertices.Add(new global::UnityEngine.Vector3(x + num2, y));
					vertices.Add(new global::UnityEngine.Vector3(x + num2, y - num));
					vertices.Add(new global::UnityEngine.Vector3(x, y - num));
					triangles.Add(count);
					triangles.Add(count + 1);
					triangles.Add(count + 3);
					triangles.Add(count + 3);
					triangles.Add(count + 1);
					triangles.Add(count + 2);
					global::UnityEngine.Color32 item = (!base.ColorizeSymbols) ? this.applyOpacity(base.DefaultColor) : this.applyOpacity(color);
					colors.Add(item);
					colors.Add(item);
					colors.Add(item);
					colors.Add(item);
					global::UnityEngine.Rect region = itemInfo.region;
					uv.Add(new global::UnityEngine.Vector2(region.x, region.yMax));
					uv.Add(new global::UnityEngine.Vector2(region.xMax, region.yMax));
					uv.Add(new global::UnityEngine.Vector2(region.xMax, region.y));
					uv.Add(new global::UnityEngine.Vector2(region.x, region.y));
				}
			}
			finally
			{
			}
		}

		// Token: 0x0600448C RID: 17548 RVA: 0x000FA7BC File Offset: 0x000F89BC
		private global::UnityEngine.Color32 parseColor(global::dfMarkupToken token)
		{
			global::UnityEngine.Color color = global::UnityEngine.Color.white;
			if (token.AttributeCount == 1)
			{
				string value = token.GetAttribute(0).Value.Value;
				if (value.Length == 7 && value[0] == '#')
				{
					uint num = 0U;
					uint.TryParse(value.Substring(1), global::System.Globalization.NumberStyles.HexNumber, null, out num);
					color = this.UIntToColor(num | 0xFF000000U);
				}
				else
				{
					color = global::dfMarkupStyle.ParseColor(value, base.DefaultColor);
				}
			}
			return this.applyOpacity(color);
		}

		// Token: 0x0600448D RID: 17549 RVA: 0x000FA854 File Offset: 0x000F8A54
		private global::UnityEngine.Color32 UIntToColor(uint color)
		{
			byte b = (byte)(color >> 0x18);
			byte b2 = (byte)(color >> 0x10);
			byte b3 = (byte)(color >> 8);
			byte b4 = (byte)color;
			return new global::UnityEngine.Color32(b2, b3, b4, b);
		}

		// Token: 0x0600448E RID: 17550 RVA: 0x000FA880 File Offset: 0x000F8A80
		private global::dfList<global::dfFont.LineRenderInfo> calculateLinebreaks()
		{
			global::dfList<global::dfFont.LineRenderInfo> result;
			try
			{
				if (this.lines != null)
				{
					result = this.lines;
				}
				else
				{
					this.lines = global::dfList<global::dfFont.LineRenderInfo>.Obtain();
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					float num5 = (float)base.Font.LineHeight * base.TextScale;
					while (num3 < this.tokens.Count && (float)this.lines.Count * num5 < base.MaxSize.y)
					{
						global::dfMarkupToken dfMarkupToken = this.tokens[num3];
						global::dfMarkupTokenType tokenType = dfMarkupToken.TokenType;
						if (tokenType == global::dfMarkupTokenType.Newline)
						{
							this.lines.Add(global::dfFont.LineRenderInfo.Obtain(num2, num3));
							num = (num2 = ++num3);
							num4 = 0;
						}
						else
						{
							int num6 = global::UnityEngine.Mathf.CeilToInt((float)dfMarkupToken.Width * base.TextScale);
							bool flag = base.WordWrap && num > num2 && (tokenType == global::dfMarkupTokenType.Text || (tokenType == global::dfMarkupTokenType.StartTag && dfMarkupToken.Matches("sprite")));
							if (flag && (float)(num4 + num6) >= base.MaxSize.x)
							{
								if (num > num2)
								{
									this.lines.Add(global::dfFont.LineRenderInfo.Obtain(num2, num - 1));
									num3 = (num2 = ++num);
									num4 = 0;
								}
								else
								{
									this.lines.Add(global::dfFont.LineRenderInfo.Obtain(num2, num - 1));
									num = (num2 = ++num3);
									num4 = 0;
								}
							}
							else
							{
								if (tokenType == global::dfMarkupTokenType.Whitespace)
								{
									num = num3;
								}
								num4 += num6;
								num3++;
							}
						}
					}
					if (num2 < this.tokens.Count)
					{
						this.lines.Add(global::dfFont.LineRenderInfo.Obtain(num2, this.tokens.Count - 1));
					}
					for (int i = 0; i < this.lines.Count; i++)
					{
						this.calculateLineSize(this.lines[i]);
					}
					result = this.lines;
				}
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x0600448F RID: 17551 RVA: 0x000FAAA8 File Offset: 0x000F8CA8
		private int calculateLineAlignment(global::dfFont.LineRenderInfo line)
		{
			float lineWidth = line.lineWidth;
			if (base.TextAlign == null || lineWidth == 0f)
			{
				return 0;
			}
			int num;
			if (base.TextAlign == 2)
			{
				num = global::UnityEngine.Mathf.FloorToInt(base.MaxSize.x / base.TextScale - lineWidth);
			}
			else
			{
				num = global::UnityEngine.Mathf.FloorToInt((base.MaxSize.x / base.TextScale - lineWidth) * 0.5f);
			}
			return global::UnityEngine.Mathf.Max(0, num);
		}

		// Token: 0x06004490 RID: 17552 RVA: 0x000FAB30 File Offset: 0x000F8D30
		private void calculateLineSize(global::dfFont.LineRenderInfo line)
		{
			line.lineHeight = (float)base.Font.LineHeight;
			int num = 0;
			for (int i = line.startOffset; i <= line.endOffset; i++)
			{
				num += this.tokens[i].Width;
			}
			line.lineWidth = (float)num;
		}

		// Token: 0x06004491 RID: 17553 RVA: 0x000FAB8C File Offset: 0x000F8D8C
		private global::System.Collections.Generic.List<global::dfMarkupToken> tokenize(string text)
		{
			global::System.Collections.Generic.List<global::dfMarkupToken> result;
			try
			{
				if (this.tokens != null && this.tokens.Count > 0 && this.tokens[0].Source == text)
				{
					result = this.tokens;
				}
				else
				{
					if (base.ProcessMarkup)
					{
						this.tokens = global::dfMarkupTokenizer.Tokenize(text);
					}
					else
					{
						this.tokens = global::dfPlainTextTokenizer.Tokenize(text);
					}
					for (int i = 0; i < this.tokens.Count; i++)
					{
						this.calculateTokenRenderSize(this.tokens[i]);
					}
					result = this.tokens;
				}
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x06004492 RID: 17554 RVA: 0x000FAC64 File Offset: 0x000F8E64
		private void calculateTokenRenderSize(global::dfMarkupToken token)
		{
			try
			{
				global::dfFont dfFont = (global::dfFont)base.Font;
				int num = 0;
				char previousChar = '\0';
				bool flag = token.TokenType == global::dfMarkupTokenType.Whitespace || token.TokenType == global::dfMarkupTokenType.Text;
				if (flag)
				{
					int i = 0;
					while (i < token.Length)
					{
						char c = token[i];
						if (c == '\t')
						{
							num += base.TabSize;
						}
						else
						{
							global::dfFont.GlyphDefinition glyph = dfFont.GetGlyph(c);
							if (glyph != null)
							{
								if (i > 0)
								{
									num += dfFont.GetKerning(previousChar, c);
									num += base.CharacterSpacing;
								}
								num += glyph.xadvance;
							}
						}
						i++;
						previousChar = c;
					}
				}
				else if (token.TokenType == global::dfMarkupTokenType.StartTag && token.Matches("sprite"))
				{
					if (token.AttributeCount < 1)
					{
						throw new global::System.Exception("Missing sprite name in markup");
					}
					global::UnityEngine.Texture texture = dfFont.Texture;
					int lineHeight = dfFont.LineHeight;
					string value = token.GetAttribute(0).Value.Value;
					global::dfAtlas.ItemInfo itemInfo = dfFont.atlas[value];
					if (itemInfo != null)
					{
						float num2 = itemInfo.region.width * (float)texture.width / (itemInfo.region.height * (float)texture.height);
						num = global::UnityEngine.Mathf.CeilToInt((float)lineHeight * num2);
					}
				}
				token.Height = base.Font.LineHeight;
				token.Width = num;
			}
			finally
			{
			}
		}

		// Token: 0x06004493 RID: 17555 RVA: 0x000FAE08 File Offset: 0x000F9008
		private float getTabStop(float position)
		{
			float num = base.PixelRatio * base.TextScale;
			if (base.TabStops != null && base.TabStops.Count > 0)
			{
				for (int i = 0; i < base.TabStops.Count; i++)
				{
					if ((float)base.TabStops[i] * num > position)
					{
						return (float)base.TabStops[i] * num;
					}
				}
			}
			if (base.TabSize > 0)
			{
				return position + (float)base.TabSize * num;
			}
			return position + (float)(base.Font.FontSize * 4) * num;
		}

		// Token: 0x06004494 RID: 17556 RVA: 0x000FAEAC File Offset: 0x000F90AC
		private void clipRight(global::dfRenderData destination, int startIndex)
		{
			float num = base.VectorOffset.x + base.MaxSize.x * base.PixelRatio;
			global::dfList<global::UnityEngine.Vector3> vertices = destination.Vertices;
			global::dfList<global::UnityEngine.Vector2> uv = destination.UV;
			for (int i = startIndex; i < vertices.Count; i += 4)
			{
				global::UnityEngine.Vector3 value = vertices[i];
				global::UnityEngine.Vector3 value2 = vertices[i + 1];
				global::UnityEngine.Vector3 value3 = vertices[i + 2];
				global::UnityEngine.Vector3 value4 = vertices[i + 3];
				float num2 = value2.x - value.x;
				if (value2.x > num)
				{
					float num3 = 1f - (num - value2.x + num2) / num2;
					global::dfList<global::UnityEngine.Vector3> dfList = vertices;
					int index = i;
					value..ctor(global::UnityEngine.Mathf.Min(value.x, num), value.y, value.z);
					dfList[index] = value;
					global::dfList<global::UnityEngine.Vector3> dfList2 = vertices;
					int index2 = i + 1;
					value2..ctor(global::UnityEngine.Mathf.Min(value2.x, num), value2.y, value2.z);
					dfList2[index2] = value2;
					global::dfList<global::UnityEngine.Vector3> dfList3 = vertices;
					int index3 = i + 2;
					value3..ctor(global::UnityEngine.Mathf.Min(value3.x, num), value3.y, value3.z);
					dfList3[index3] = value3;
					global::dfList<global::UnityEngine.Vector3> dfList4 = vertices;
					int index4 = i + 3;
					value4..ctor(global::UnityEngine.Mathf.Min(value4.x, num), value4.y, value4.z);
					dfList4[index4] = value4;
					float num4 = global::UnityEngine.Mathf.Lerp(uv[i + 1].x, uv[i].x, num3);
					uv[i + 1] = new global::UnityEngine.Vector2(num4, uv[i + 1].y);
					uv[i + 2] = new global::UnityEngine.Vector2(num4, uv[i + 2].y);
					num2 = value2.x - value.x;
				}
			}
		}

		// Token: 0x06004495 RID: 17557 RVA: 0x000FB098 File Offset: 0x000F9298
		private void clipBottom(global::dfRenderData destination, int startIndex)
		{
			float num = base.VectorOffset.y - base.MaxSize.y * base.PixelRatio;
			global::dfList<global::UnityEngine.Vector3> vertices = destination.Vertices;
			global::dfList<global::UnityEngine.Vector2> uv = destination.UV;
			global::dfList<global::UnityEngine.Color32> colors = destination.Colors;
			for (int i = startIndex; i < vertices.Count; i += 4)
			{
				global::UnityEngine.Vector3 value = vertices[i];
				global::UnityEngine.Vector3 value2 = vertices[i + 1];
				global::UnityEngine.Vector3 value3 = vertices[i + 2];
				global::UnityEngine.Vector3 value4 = vertices[i + 3];
				float num2 = value.y - value4.y;
				if (value4.y <= num)
				{
					float num3 = 1f - global::UnityEngine.Mathf.Abs(-num + value.y) / num2;
					global::dfList<global::UnityEngine.Vector3> dfList = vertices;
					int index = i;
					value..ctor(value.x, global::UnityEngine.Mathf.Max(value.y, num), value2.z);
					dfList[index] = value;
					global::dfList<global::UnityEngine.Vector3> dfList2 = vertices;
					int index2 = i + 1;
					value2..ctor(value2.x, global::UnityEngine.Mathf.Max(value2.y, num), value2.z);
					dfList2[index2] = value2;
					global::dfList<global::UnityEngine.Vector3> dfList3 = vertices;
					int index3 = i + 2;
					value3..ctor(value3.x, global::UnityEngine.Mathf.Max(value3.y, num), value3.z);
					dfList3[index3] = value3;
					global::dfList<global::UnityEngine.Vector3> dfList4 = vertices;
					int index4 = i + 3;
					value4..ctor(value4.x, global::UnityEngine.Mathf.Max(value4.y, num), value4.z);
					dfList4[index4] = value4;
					float num4 = global::UnityEngine.Mathf.Lerp(uv[i + 3].y, uv[i].y, num3);
					uv[i + 3] = new global::UnityEngine.Vector2(uv[i + 3].x, num4);
					uv[i + 2] = new global::UnityEngine.Vector2(uv[i + 2].x, num4);
					global::UnityEngine.Color color = global::UnityEngine.Color.Lerp(colors[i + 3], colors[i], num3);
					colors[i + 3] = color;
					colors[i + 2] = color;
				}
			}
		}

		// Token: 0x06004496 RID: 17558 RVA: 0x000FB2D4 File Offset: 0x000F94D4
		private global::UnityEngine.Color32 applyOpacity(global::UnityEngine.Color32 color)
		{
			color.a = (byte)(base.Opacity * 255f);
			return color;
		}

		// Token: 0x06004497 RID: 17559 RVA: 0x000FB2EC File Offset: 0x000F94EC
		private static void addTriangleIndices(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<int> triangles)
		{
			int count = verts.Count;
			int[] triangle_INDICES = global::dfFont.BitmappedFontRenderer.TRIANGLE_INDICES;
			for (int i = 0; i < triangle_INDICES.Length; i++)
			{
				triangles.Add(count + triangle_INDICES[i]);
			}
		}

		// Token: 0x06004498 RID: 17560 RVA: 0x000FB328 File Offset: 0x000F9528
		private global::UnityEngine.Color multiplyColors(global::UnityEngine.Color lhs, global::UnityEngine.Color rhs)
		{
			return new global::UnityEngine.Color(lhs.r * rhs.r, lhs.g * rhs.g, lhs.b * rhs.b, lhs.a * rhs.a);
		}

		// Token: 0x06004499 RID: 17561 RVA: 0x000FB378 File Offset: 0x000F9578
		private global::dfFont.LineRenderInfo fitSingleLine()
		{
			return global::dfFont.LineRenderInfo.Obtain(0, 0);
		}

		// Token: 0x04002493 RID: 9363
		private static global::System.Collections.Generic.Queue<global::dfFont.BitmappedFontRenderer> objectPool = new global::System.Collections.Generic.Queue<global::dfFont.BitmappedFontRenderer>();

		// Token: 0x04002494 RID: 9364
		private static global::UnityEngine.Vector2[] OUTLINE_OFFSETS = new global::UnityEngine.Vector2[]
		{
			new global::UnityEngine.Vector2(-1f, -1f),
			new global::UnityEngine.Vector2(-1f, 1f),
			new global::UnityEngine.Vector2(1f, -1f),
			new global::UnityEngine.Vector2(1f, 1f)
		};

		// Token: 0x04002495 RID: 9365
		private static int[] TRIANGLE_INDICES = new int[]
		{
			0,
			1,
			3,
			3,
			1,
			2
		};

		// Token: 0x04002496 RID: 9366
		private static global::System.Collections.Generic.Stack<global::UnityEngine.Color32> textColors = new global::System.Collections.Generic.Stack<global::UnityEngine.Color32>();

		// Token: 0x04002497 RID: 9367
		private global::dfList<global::dfFont.LineRenderInfo> lines;

		// Token: 0x04002498 RID: 9368
		private global::System.Collections.Generic.List<global::dfMarkupToken> tokens;
	}

	// Token: 0x02000803 RID: 2051
	private class LineRenderInfo
	{
		// Token: 0x0600449A RID: 17562 RVA: 0x000FB390 File Offset: 0x000F9590
		private LineRenderInfo()
		{
		}

		// Token: 0x0600449B RID: 17563 RVA: 0x000FB398 File Offset: 0x000F9598
		// Note: this type is marked as 'beforefieldinit'.
		static LineRenderInfo()
		{
		}

		// Token: 0x17000CB0 RID: 3248
		// (get) Token: 0x0600449C RID: 17564 RVA: 0x000FB3AC File Offset: 0x000F95AC
		public int length
		{
			get
			{
				return this.endOffset - this.startOffset + 1;
			}
		}

		// Token: 0x0600449D RID: 17565 RVA: 0x000FB3C0 File Offset: 0x000F95C0
		public static void ResetPool()
		{
			global::dfFont.LineRenderInfo.poolIndex = 0;
		}

		// Token: 0x0600449E RID: 17566 RVA: 0x000FB3C8 File Offset: 0x000F95C8
		public static global::dfFont.LineRenderInfo Obtain(int start, int end)
		{
			if (global::dfFont.LineRenderInfo.poolIndex >= global::dfFont.LineRenderInfo.pool.Count - 1)
			{
				global::dfFont.LineRenderInfo.pool.Add(new global::dfFont.LineRenderInfo());
			}
			global::dfFont.LineRenderInfo lineRenderInfo = global::dfFont.LineRenderInfo.pool[global::dfFont.LineRenderInfo.poolIndex++];
			lineRenderInfo.startOffset = start;
			lineRenderInfo.endOffset = end;
			lineRenderInfo.lineHeight = 0f;
			return lineRenderInfo;
		}

		// Token: 0x04002499 RID: 9369
		public int startOffset;

		// Token: 0x0400249A RID: 9370
		public int endOffset;

		// Token: 0x0400249B RID: 9371
		public float lineWidth;

		// Token: 0x0400249C RID: 9372
		public float lineHeight;

		// Token: 0x0400249D RID: 9373
		private static global::dfList<global::dfFont.LineRenderInfo> pool = new global::dfList<global::dfFont.LineRenderInfo>();

		// Token: 0x0400249E RID: 9374
		private static int poolIndex = 0;
	}
}
