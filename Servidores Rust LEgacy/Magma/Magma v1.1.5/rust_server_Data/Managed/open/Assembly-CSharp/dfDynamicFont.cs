using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200085A RID: 2138
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Dynamic Font")]
[global::UnityEngine.ExecuteInEditMode]
public class dfDynamicFont : global::dfFontBase
{
	// Token: 0x06004A0D RID: 18957 RVA: 0x001149C0 File Offset: 0x00112BC0
	public dfDynamicFont()
	{
	}

	// Token: 0x06004A0E RID: 18958 RVA: 0x001149D8 File Offset: 0x00112BD8
	// Note: this type is marked as 'beforefieldinit'.
	static dfDynamicFont()
	{
	}

	// Token: 0x17000DDD RID: 3549
	// (get) Token: 0x06004A0F RID: 18959 RVA: 0x001149F4 File Offset: 0x00112BF4
	// (set) Token: 0x06004A10 RID: 18960 RVA: 0x00114A18 File Offset: 0x00112C18
	public override global::UnityEngine.Material Material
	{
		get
		{
			this.material.mainTexture = this.baseFont.material.mainTexture;
			return this.material;
		}
		set
		{
			if (value != this.material)
			{
				this.material = value;
				global::dfGUIManager.RefreshAll(false);
			}
		}
	}

	// Token: 0x17000DDE RID: 3550
	// (get) Token: 0x06004A11 RID: 18961 RVA: 0x00114A38 File Offset: 0x00112C38
	public override global::UnityEngine.Texture Texture
	{
		get
		{
			return this.baseFont.material.mainTexture;
		}
	}

	// Token: 0x17000DDF RID: 3551
	// (get) Token: 0x06004A12 RID: 18962 RVA: 0x00114A4C File Offset: 0x00112C4C
	public override bool IsValid
	{
		get
		{
			return this.baseFont != null && this.Material != null && this.Texture != null;
		}
	}

	// Token: 0x17000DE0 RID: 3552
	// (get) Token: 0x06004A13 RID: 18963 RVA: 0x00114A8C File Offset: 0x00112C8C
	// (set) Token: 0x06004A14 RID: 18964 RVA: 0x00114A94 File Offset: 0x00112C94
	public override int FontSize
	{
		get
		{
			return this.baseFontSize;
		}
		set
		{
			if (value != this.baseFontSize)
			{
				this.baseFontSize = value;
				global::dfGUIManager.RefreshAll(false);
			}
		}
	}

	// Token: 0x17000DE1 RID: 3553
	// (get) Token: 0x06004A15 RID: 18965 RVA: 0x00114AB0 File Offset: 0x00112CB0
	// (set) Token: 0x06004A16 RID: 18966 RVA: 0x00114AB8 File Offset: 0x00112CB8
	public override int LineHeight
	{
		get
		{
			return this.lineHeight;
		}
		set
		{
			if (value != this.lineHeight)
			{
				this.lineHeight = value;
				global::dfGUIManager.RefreshAll(false);
			}
		}
	}

	// Token: 0x06004A17 RID: 18967 RVA: 0x00114AD4 File Offset: 0x00112CD4
	public override global::dfFontRendererBase ObtainRenderer()
	{
		return global::dfDynamicFont.DynamicFontRenderer.Obtain(this);
	}

	// Token: 0x17000DE2 RID: 3554
	// (get) Token: 0x06004A18 RID: 18968 RVA: 0x00114ADC File Offset: 0x00112CDC
	// (set) Token: 0x06004A19 RID: 18969 RVA: 0x00114AE4 File Offset: 0x00112CE4
	public global::UnityEngine.Font BaseFont
	{
		get
		{
			return this.baseFont;
		}
		set
		{
			if (value != this.baseFont)
			{
				this.baseFont = value;
				global::dfGUIManager.RefreshAll(false);
			}
		}
	}

	// Token: 0x17000DE3 RID: 3555
	// (get) Token: 0x06004A1A RID: 18970 RVA: 0x00114B04 File Offset: 0x00112D04
	// (set) Token: 0x06004A1B RID: 18971 RVA: 0x00114B0C File Offset: 0x00112D0C
	public int Baseline
	{
		get
		{
			return this.baseline;
		}
		set
		{
			if (value != this.baseline)
			{
				this.baseline = value;
				global::dfGUIManager.RefreshAll(false);
			}
		}
	}

	// Token: 0x17000DE4 RID: 3556
	// (get) Token: 0x06004A1C RID: 18972 RVA: 0x00114B28 File Offset: 0x00112D28
	public int Descent
	{
		get
		{
			return this.LineHeight - this.baseline;
		}
	}

	// Token: 0x06004A1D RID: 18973 RVA: 0x00114B38 File Offset: 0x00112D38
	public static global::dfDynamicFont FindByName(string name)
	{
		for (int i = 0; i < global::dfDynamicFont.loadedFonts.Count; i++)
		{
			if (string.Equals(global::dfDynamicFont.loadedFonts[i].name, name, global::System.StringComparison.InvariantCultureIgnoreCase))
			{
				return global::dfDynamicFont.loadedFonts[i];
			}
		}
		global::UnityEngine.GameObject gameObject = global::Resources.Load(name) as global::UnityEngine.GameObject;
		if (gameObject == null)
		{
			return null;
		}
		global::dfDynamicFont component = gameObject.GetComponent<global::dfDynamicFont>();
		if (component == null)
		{
			return null;
		}
		global::dfDynamicFont.loadedFonts.Add(component);
		return component;
	}

	// Token: 0x06004A1E RID: 18974 RVA: 0x00114BC4 File Offset: 0x00112DC4
	public global::UnityEngine.Vector2 MeasureText(string text, int size, global::UnityEngine.FontStyle style)
	{
		global::UnityEngine.CharacterInfo[] array = this.RequestCharacters(text, size, style);
		float num = (float)size / (float)this.FontSize;
		int num2 = global::UnityEngine.Mathf.CeilToInt((float)this.Baseline * num);
		global::UnityEngine.Vector2 result;
		result..ctor(0f, (float)num2);
		for (int i = 0; i < text.Length; i++)
		{
			global::UnityEngine.CharacterInfo characterInfo = array[i];
			float num3 = global::UnityEngine.Mathf.Ceil(characterInfo.vert.x + characterInfo.vert.width);
			if (text[i] == ' ')
			{
				num3 = global::UnityEngine.Mathf.Ceil(characterInfo.width * 1.25f);
			}
			else if (text[i] == '\t')
			{
				num3 += (float)(size * 4);
			}
			result.x += num3;
		}
		return result;
	}

	// Token: 0x06004A1F RID: 18975 RVA: 0x00114CA0 File Offset: 0x00112EA0
	public global::UnityEngine.CharacterInfo[] RequestCharacters(string text, int size, global::UnityEngine.FontStyle style)
	{
		if (this.baseFont == null)
		{
			throw new global::System.NullReferenceException("Base Font not assigned: " + base.name);
		}
		this.ensureGlyphBufferCapacity(size);
		if (!global::dfDynamicFont.loadedFonts.Contains(this))
		{
			global::UnityEngine.Font font = this.baseFont;
			font.textureRebuildCallback = (global::UnityEngine.Font.FontTextureRebuildCallback)global::System.Delegate.Combine(font.textureRebuildCallback, new global::UnityEngine.Font.FontTextureRebuildCallback(this.onFontAtlasRebuilt));
			global::dfDynamicFont.loadedFonts.Add(this);
		}
		this.baseFont.RequestCharactersInTexture(text, size, style);
		this.getGlyphData(global::dfDynamicFont.glyphBuffer, text, size, style);
		return global::dfDynamicFont.glyphBuffer;
	}

	// Token: 0x06004A20 RID: 18976 RVA: 0x00114D40 File Offset: 0x00112F40
	private void onFontAtlasRebuilt()
	{
		this.wasFontAtlasRebuilt = true;
		this.OnFontChanged();
	}

	// Token: 0x06004A21 RID: 18977 RVA: 0x00114D50 File Offset: 0x00112F50
	private void OnFontChanged()
	{
		try
		{
			if (!this.invalidatingDependentControls)
			{
				global::dfGUIManager.RenderCallback callback = null;
				callback = delegate(global::dfGUIManager manager)
				{
					global::dfGUIManager.AfterRender -= callback;
					this.invalidatingDependentControls = true;
					try
					{
						if (this.wasFontAtlasRebuilt)
						{
						}
						global::System.Collections.Generic.List<global::dfControl> list = (from global::dfControl x in 
							from x in global::UnityEngine.Object.FindObjectsOfType(typeof(global::dfControl))
							where x is global::IDFMultiRender
							select x
						orderby x.RenderOrder
						select x).ToList<global::dfControl>();
						for (int i = 0; i < list.Count; i++)
						{
							list[i].Invalidate();
						}
						if (this.wasFontAtlasRebuilt)
						{
							manager.Render();
						}
					}
					finally
					{
						this.wasFontAtlasRebuilt = false;
						this.invalidatingDependentControls = false;
					}
				};
				global::dfGUIManager.AfterRender += callback;
			}
		}
		finally
		{
		}
	}

	// Token: 0x06004A22 RID: 18978 RVA: 0x00114DC0 File Offset: 0x00112FC0
	private void ensureGlyphBufferCapacity(int size)
	{
		int i = global::dfDynamicFont.glyphBuffer.Length;
		if (size < i)
		{
			return;
		}
		while (i < size)
		{
			i += 0x400;
		}
		global::dfDynamicFont.glyphBuffer = new global::UnityEngine.CharacterInfo[i];
	}

	// Token: 0x06004A23 RID: 18979 RVA: 0x00114DFC File Offset: 0x00112FFC
	private void getGlyphData(global::UnityEngine.CharacterInfo[] result, string text, int size, global::UnityEngine.FontStyle style)
	{
		if (text.Length > global::dfDynamicFont.glyphBuffer.Length)
		{
			global::dfDynamicFont.glyphBuffer = new global::UnityEngine.CharacterInfo[text.Length + 0x200];
		}
		for (int i = 0; i < text.Length; i++)
		{
			if (!this.baseFont.GetCharacterInfo(text[i], ref result[i], size, style))
			{
				int num = i;
				global::UnityEngine.CharacterInfo characterInfo = default(global::UnityEngine.CharacterInfo);
				characterInfo.index = -1;
				characterInfo.size = size;
				characterInfo.style = style;
				characterInfo.width = (float)size * 0.25f;
				result[num] = characterInfo;
			}
		}
	}

	// Token: 0x04002766 RID: 10086
	private static global::System.Collections.Generic.List<global::dfDynamicFont> loadedFonts = new global::System.Collections.Generic.List<global::dfDynamicFont>();

	// Token: 0x04002767 RID: 10087
	private static global::UnityEngine.CharacterInfo[] glyphBuffer = new global::UnityEngine.CharacterInfo[0x400];

	// Token: 0x04002768 RID: 10088
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Font baseFont;

	// Token: 0x04002769 RID: 10089
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material material;

	// Token: 0x0400276A RID: 10090
	[global::UnityEngine.SerializeField]
	private int baseFontSize = -1;

	// Token: 0x0400276B RID: 10091
	[global::UnityEngine.SerializeField]
	private int baseline = -1;

	// Token: 0x0400276C RID: 10092
	[global::UnityEngine.SerializeField]
	private int lineHeight;

	// Token: 0x0400276D RID: 10093
	private bool invalidatingDependentControls;

	// Token: 0x0400276E RID: 10094
	private bool wasFontAtlasRebuilt;

	// Token: 0x0200085B RID: 2139
	public class DynamicFontRenderer : global::dfFontRendererBase
	{
		// Token: 0x06004A24 RID: 18980 RVA: 0x00114EA8 File Offset: 0x001130A8
		internal DynamicFontRenderer()
		{
		}

		// Token: 0x06004A25 RID: 18981 RVA: 0x00114EB0 File Offset: 0x001130B0
		// Note: this type is marked as 'beforefieldinit'.
		static DynamicFontRenderer()
		{
		}

		// Token: 0x17000DE5 RID: 3557
		// (get) Token: 0x06004A26 RID: 18982 RVA: 0x00114F60 File Offset: 0x00113160
		public int LineCount
		{
			get
			{
				return this.lines.Count;
			}
		}

		// Token: 0x17000DE6 RID: 3558
		// (get) Token: 0x06004A27 RID: 18983 RVA: 0x00114F70 File Offset: 0x00113170
		// (set) Token: 0x06004A28 RID: 18984 RVA: 0x00114F78 File Offset: 0x00113178
		public global::dfAtlas SpriteAtlas
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<SpriteAtlas>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<SpriteAtlas>k__BackingField = value;
			}
		}

		// Token: 0x17000DE7 RID: 3559
		// (get) Token: 0x06004A29 RID: 18985 RVA: 0x00114F84 File Offset: 0x00113184
		// (set) Token: 0x06004A2A RID: 18986 RVA: 0x00114F8C File Offset: 0x0011318C
		public global::dfRenderData SpriteBuffer
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<SpriteBuffer>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<SpriteBuffer>k__BackingField = value;
			}
		}

		// Token: 0x06004A2B RID: 18987 RVA: 0x00114F98 File Offset: 0x00113198
		public static global::dfFontRendererBase Obtain(global::dfDynamicFont font)
		{
			global::dfDynamicFont.DynamicFontRenderer dynamicFontRenderer = (global::dfDynamicFont.DynamicFontRenderer.objectPool.Count <= 0) ? new global::dfDynamicFont.DynamicFontRenderer() : global::dfDynamicFont.DynamicFontRenderer.objectPool.Dequeue();
			dynamicFontRenderer.Reset();
			dynamicFontRenderer.Font = font;
			return dynamicFontRenderer;
		}

		// Token: 0x06004A2C RID: 18988 RVA: 0x00114FD8 File Offset: 0x001131D8
		public override void Release()
		{
			this.Reset();
			this.tokens = null;
			if (this.lines != null)
			{
				this.lines.Release();
				this.lines = null;
			}
			global::dfDynamicFont.LineRenderInfo.ResetPool();
			base.BottomColor = null;
			global::dfDynamicFont.DynamicFontRenderer.objectPool.Enqueue(this);
		}

		// Token: 0x06004A2D RID: 18989 RVA: 0x00115030 File Offset: 0x00113230
		public override float[] GetCharacterWidths(string text)
		{
			float num = 0f;
			return this.GetCharacterWidths(text, 0, text.Length - 1, out num);
		}

		// Token: 0x06004A2E RID: 18990 RVA: 0x00115058 File Offset: 0x00113258
		public float[] GetCharacterWidths(string text, int startIndex, int endIndex, out float totalWidth)
		{
			totalWidth = 0f;
			global::dfDynamicFont dfDynamicFont = (global::dfDynamicFont)base.Font;
			int size = global::UnityEngine.Mathf.CeilToInt((float)dfDynamicFont.FontSize * base.TextScale);
			global::UnityEngine.CharacterInfo[] array = dfDynamicFont.RequestCharacters(text, size, 0);
			float[] array2 = new float[text.Length];
			float num = 0f;
			float num2 = 0f;
			int i = startIndex;
			while (i <= endIndex)
			{
				global::UnityEngine.CharacterInfo characterInfo = array[i];
				if (text[i] == '\t')
				{
					num2 += (float)base.TabSize;
				}
				else if (text[i] == ' ')
				{
					num2 += characterInfo.width;
				}
				else
				{
					num2 += characterInfo.vert.x + characterInfo.vert.width;
				}
				array2[i] = (num2 - num) * base.PixelRatio;
				i++;
				num = num2;
			}
			return array2;
		}

		// Token: 0x06004A2F RID: 18991 RVA: 0x0011514C File Offset: 0x0011334C
		public override global::UnityEngine.Vector2 MeasureString(string text)
		{
			this.tokenize(text);
			global::dfList<global::dfDynamicFont.LineRenderInfo> dfList = this.calculateLinebreaks();
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < dfList.Count; i++)
			{
				num = global::UnityEngine.Mathf.Max(dfList[i].lineWidth, num);
				num2 += dfList[i].lineHeight;
			}
			global::UnityEngine.Vector2 result;
			result..ctor(num, num2);
			return result;
		}

		// Token: 0x06004A30 RID: 18992 RVA: 0x001151B8 File Offset: 0x001133B8
		public override void Render(string text, global::dfRenderData destination)
		{
			global::dfDynamicFont.DynamicFontRenderer.textColors.Clear();
			global::dfDynamicFont.DynamicFontRenderer.textColors.Push(global::UnityEngine.Color.white);
			this.tokenize(text);
			global::dfList<global::dfDynamicFont.LineRenderInfo> dfList = this.calculateLinebreaks();
			int num = 0;
			int num2 = 0;
			global::UnityEngine.Vector3 position = (base.VectorOffset / base.PixelRatio).CeilToInt();
			for (int i = 0; i < dfList.Count; i++)
			{
				global::dfDynamicFont.LineRenderInfo lineRenderInfo = dfList[i];
				int count = destination.Vertices.Count;
				int startIndex = (this.SpriteBuffer == null) ? 0 : this.SpriteBuffer.Vertices.Count;
				this.renderLine(dfList[i], global::dfDynamicFont.DynamicFontRenderer.textColors, position, destination);
				position.y -= lineRenderInfo.lineHeight;
				num = global::UnityEngine.Mathf.Max((int)lineRenderInfo.lineWidth, num);
				num2 += global::UnityEngine.Mathf.CeilToInt(lineRenderInfo.lineHeight);
				if (lineRenderInfo.lineWidth > base.MaxSize.x)
				{
					this.clipRight(destination, count);
					this.clipRight(this.SpriteBuffer, startIndex);
				}
				this.clipBottom(destination, count);
				this.clipBottom(this.SpriteBuffer, startIndex);
			}
			base.RenderedSize = new global::UnityEngine.Vector2(global::UnityEngine.Mathf.Min(base.MaxSize.x, (float)num), global::UnityEngine.Mathf.Min(base.MaxSize.y, (float)num2)) * base.TextScale;
		}

		// Token: 0x06004A31 RID: 18993 RVA: 0x00115338 File Offset: 0x00113538
		private void renderLine(global::dfDynamicFont.LineRenderInfo line, global::System.Collections.Generic.Stack<global::UnityEngine.Color32> colors, global::UnityEngine.Vector3 position, global::dfRenderData destination)
		{
			position.x += (float)this.calculateLineAlignment(line);
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
					if (dfMarkupToken.Matches("sprite") && this.SpriteAtlas != null && this.SpriteBuffer != null)
					{
						this.renderSprite(dfMarkupToken, colors.Peek(), position, this.SpriteBuffer);
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
				position.x += (float)dfMarkupToken.Width;
			}
		}

		// Token: 0x06004A32 RID: 18994 RVA: 0x00115454 File Offset: 0x00113654
		private void renderText(global::dfMarkupToken token, global::UnityEngine.Color32 color, global::UnityEngine.Vector3 position, global::dfRenderData renderData)
		{
			try
			{
				global::dfDynamicFont dfDynamicFont = (global::dfDynamicFont)base.Font;
				int num = global::UnityEngine.Mathf.CeilToInt((float)dfDynamicFont.FontSize * base.TextScale);
				global::UnityEngine.FontStyle style = 0;
				int descent = dfDynamicFont.Descent;
				global::dfList<global::UnityEngine.Vector3> vertices = renderData.Vertices;
				global::dfList<int> triangles = renderData.Triangles;
				global::dfList<global::UnityEngine.Vector2> uv = renderData.UV;
				global::dfList<global::UnityEngine.Color32> colors = renderData.Colors;
				string value = token.Value;
				float num2 = position.x;
				float y = position.y;
				global::UnityEngine.CharacterInfo[] array = dfDynamicFont.RequestCharacters(value, num, style);
				renderData.Material = dfDynamicFont.Material;
				global::UnityEngine.Color32 color2 = this.applyOpacity(this.multiplyColors(color, base.DefaultColor));
				global::UnityEngine.Color32 item = color2;
				if (base.BottomColor != null)
				{
					item = this.applyOpacity(this.multiplyColors(color, base.BottomColor.Value));
				}
				for (int i = 0; i < value.Length; i++)
				{
					if (i > 0)
					{
						num2 += (float)base.CharacterSpacing * base.TextScale;
					}
					global::UnityEngine.CharacterInfo glyph = array[i];
					float num3 = (float)dfDynamicFont.FontSize + glyph.vert.y - (float)num + (float)descent;
					float num4 = num2 + glyph.vert.x;
					float num5 = y + num3;
					float num6 = num4 + glyph.vert.width;
					float num7 = num5 + glyph.vert.height;
					global::UnityEngine.Vector3 vector = new global::UnityEngine.Vector3(num4, num5) * base.PixelRatio;
					global::UnityEngine.Vector3 vector2 = new global::UnityEngine.Vector3(num6, num5) * base.PixelRatio;
					global::UnityEngine.Vector3 vector3 = new global::UnityEngine.Vector3(num6, num7) * base.PixelRatio;
					global::UnityEngine.Vector3 vector4 = new global::UnityEngine.Vector3(num4, num7) * base.PixelRatio;
					if (base.Shadow)
					{
						global::dfDynamicFont.DynamicFontRenderer.addTriangleIndices(vertices, triangles);
						global::UnityEngine.Vector3 vector5 = base.ShadowOffset * base.PixelRatio;
						vertices.Add(vector + vector5);
						vertices.Add(vector2 + vector5);
						vertices.Add(vector3 + vector5);
						vertices.Add(vector4 + vector5);
						global::UnityEngine.Color32 item2 = this.applyOpacity(base.ShadowColor);
						colors.Add(item2);
						colors.Add(item2);
						colors.Add(item2);
						colors.Add(item2);
						global::dfDynamicFont.DynamicFontRenderer.addUVCoords(uv, glyph);
					}
					if (base.Outline)
					{
						for (int j = 0; j < global::dfDynamicFont.DynamicFontRenderer.OUTLINE_OFFSETS.Length; j++)
						{
							global::dfDynamicFont.DynamicFontRenderer.addTriangleIndices(vertices, triangles);
							global::UnityEngine.Vector3 vector6 = global::dfDynamicFont.DynamicFontRenderer.OUTLINE_OFFSETS[j] * (float)base.OutlineSize * base.PixelRatio;
							vertices.Add(vector + vector6);
							vertices.Add(vector2 + vector6);
							vertices.Add(vector3 + vector6);
							vertices.Add(vector4 + vector6);
							global::UnityEngine.Color32 item3 = this.applyOpacity(base.OutlineColor);
							colors.Add(item3);
							colors.Add(item3);
							colors.Add(item3);
							colors.Add(item3);
							global::dfDynamicFont.DynamicFontRenderer.addUVCoords(uv, glyph);
						}
					}
					global::dfDynamicFont.DynamicFontRenderer.addTriangleIndices(vertices, triangles);
					vertices.Add(vector);
					vertices.Add(vector2);
					vertices.Add(vector3);
					vertices.Add(vector4);
					colors.Add(color2);
					colors.Add(color2);
					colors.Add(item);
					colors.Add(item);
					global::dfDynamicFont.DynamicFontRenderer.addUVCoords(uv, glyph);
					num2 += (float)global::UnityEngine.Mathf.CeilToInt(glyph.vert.x + glyph.vert.width);
				}
			}
			finally
			{
			}
		}

		// Token: 0x06004A33 RID: 18995 RVA: 0x00115860 File Offset: 0x00113A60
		private static void addUVCoords(global::dfList<global::UnityEngine.Vector2> uvs, global::UnityEngine.CharacterInfo glyph)
		{
			global::UnityEngine.Rect uv = glyph.uv;
			float x = uv.x;
			float num = uv.y + uv.height;
			float num2 = x + uv.width;
			float y = uv.y;
			if (glyph.flipped)
			{
				uvs.Add(new global::UnityEngine.Vector2(num2, y));
				uvs.Add(new global::UnityEngine.Vector2(num2, num));
				uvs.Add(new global::UnityEngine.Vector2(x, num));
				uvs.Add(new global::UnityEngine.Vector2(x, y));
			}
			else
			{
				uvs.Add(new global::UnityEngine.Vector2(x, num));
				uvs.Add(new global::UnityEngine.Vector2(num2, num));
				uvs.Add(new global::UnityEngine.Vector2(num2, y));
				uvs.Add(new global::UnityEngine.Vector2(x, y));
			}
		}

		// Token: 0x06004A34 RID: 18996 RVA: 0x00115920 File Offset: 0x00113B20
		private void renderSprite(global::dfMarkupToken token, global::UnityEngine.Color32 color, global::UnityEngine.Vector3 position, global::dfRenderData destination)
		{
			try
			{
				string value = token.GetAttribute(0).Value.Value;
				global::dfAtlas.ItemInfo itemInfo = this.SpriteAtlas[value];
				if (!(itemInfo == null))
				{
					global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
					{
						atlas = this.SpriteAtlas,
						color = color,
						fillAmount = 1f,
						offset = position,
						pixelsToUnits = base.PixelRatio,
						size = new global::UnityEngine.Vector2((float)token.Width, (float)token.Height),
						spriteInfo = itemInfo
					};
					global::dfSprite.renderSprite(this.SpriteBuffer, options);
				}
			}
			finally
			{
			}
		}

		// Token: 0x06004A35 RID: 18997 RVA: 0x001159F0 File Offset: 0x00113BF0
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

		// Token: 0x06004A36 RID: 18998 RVA: 0x00115A88 File Offset: 0x00113C88
		private global::UnityEngine.Color32 UIntToColor(uint color)
		{
			byte b = (byte)(color >> 0x18);
			byte b2 = (byte)(color >> 0x10);
			byte b3 = (byte)(color >> 8);
			byte b4 = (byte)color;
			return new global::UnityEngine.Color32(b2, b3, b4, b);
		}

		// Token: 0x06004A37 RID: 18999 RVA: 0x00115AB4 File Offset: 0x00113CB4
		private global::dfList<global::dfDynamicFont.LineRenderInfo> calculateLinebreaks()
		{
			global::dfList<global::dfDynamicFont.LineRenderInfo> result;
			try
			{
				if (this.lines != null)
				{
					result = this.lines;
				}
				else
				{
					this.lines = global::dfList<global::dfDynamicFont.LineRenderInfo>.Obtain();
					global::dfDynamicFont dfDynamicFont = (global::dfDynamicFont)base.Font;
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					float num5 = (float)dfDynamicFont.Baseline * base.TextScale;
					while (num3 < this.tokens.Count && (float)this.lines.Count * num5 <= base.MaxSize.y + num5)
					{
						global::dfMarkupToken dfMarkupToken = this.tokens[num3];
						global::dfMarkupTokenType tokenType = dfMarkupToken.TokenType;
						if (tokenType == global::dfMarkupTokenType.Newline)
						{
							this.lines.Add(global::dfDynamicFont.LineRenderInfo.Obtain(num2, num3));
							num = (num2 = ++num3);
							num4 = 0;
						}
						else
						{
							int num6 = global::UnityEngine.Mathf.CeilToInt((float)dfMarkupToken.Width);
							bool flag = base.WordWrap && num > num2 && (tokenType == global::dfMarkupTokenType.Text || (tokenType == global::dfMarkupTokenType.StartTag && dfMarkupToken.Matches("sprite")));
							if (flag && (float)(num4 + num6) >= base.MaxSize.x)
							{
								if (num > num2)
								{
									this.lines.Add(global::dfDynamicFont.LineRenderInfo.Obtain(num2, num - 1));
									num3 = (num2 = ++num);
									num4 = 0;
								}
								else
								{
									this.lines.Add(global::dfDynamicFont.LineRenderInfo.Obtain(num2, num - 1));
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
						this.lines.Add(global::dfDynamicFont.LineRenderInfo.Obtain(num2, this.tokens.Count - 1));
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

		// Token: 0x06004A38 RID: 19000 RVA: 0x00115CE8 File Offset: 0x00113EE8
		private int calculateLineAlignment(global::dfDynamicFont.LineRenderInfo line)
		{
			float lineWidth = line.lineWidth;
			if (base.TextAlign == null || lineWidth < 1f)
			{
				return 0;
			}
			float num;
			if (base.TextAlign == 2)
			{
				num = base.MaxSize.x - lineWidth;
			}
			else
			{
				num = (base.MaxSize.x - lineWidth) * 0.5f;
			}
			return global::UnityEngine.Mathf.CeilToInt(global::UnityEngine.Mathf.Max(0f, num));
		}

		// Token: 0x06004A39 RID: 19001 RVA: 0x00115D64 File Offset: 0x00113F64
		private void calculateLineSize(global::dfDynamicFont.LineRenderInfo line)
		{
			global::dfDynamicFont dfDynamicFont = (global::dfDynamicFont)base.Font;
			line.lineHeight = (float)dfDynamicFont.Baseline * base.TextScale;
			int num = 0;
			for (int i = line.startOffset; i <= line.endOffset; i++)
			{
				num += this.tokens[i].Width;
			}
			line.lineWidth = (float)num;
		}

		// Token: 0x06004A3A RID: 19002 RVA: 0x00115DCC File Offset: 0x00113FCC
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

		// Token: 0x06004A3B RID: 19003 RVA: 0x00115EA4 File Offset: 0x001140A4
		private void calculateTokenRenderSize(global::dfMarkupToken token)
		{
			try
			{
				int num = 0;
				bool flag = token.TokenType == global::dfMarkupTokenType.Whitespace || token.TokenType == global::dfMarkupTokenType.Text;
				global::dfDynamicFont dfDynamicFont = (global::dfDynamicFont)base.Font;
				if (flag)
				{
					int size = global::UnityEngine.Mathf.CeilToInt((float)dfDynamicFont.FontSize * base.TextScale);
					global::UnityEngine.CharacterInfo[] array = dfDynamicFont.RequestCharacters(token.Value, size, 0);
					for (int i = 0; i < token.Length; i++)
					{
						char c = token[i];
						if (c == '\t')
						{
							num += base.TabSize;
						}
						else
						{
							global::UnityEngine.CharacterInfo characterInfo = array[i];
							num += ((c == ' ') ? global::UnityEngine.Mathf.CeilToInt(characterInfo.width) : global::UnityEngine.Mathf.CeilToInt(characterInfo.vert.x + characterInfo.vert.width));
							if (i > 0)
							{
								num += global::UnityEngine.Mathf.CeilToInt((float)base.CharacterSpacing * base.TextScale);
							}
						}
					}
					token.Height = base.Font.LineHeight;
					token.Width = num;
				}
				else if (token.TokenType == global::dfMarkupTokenType.StartTag && token.Matches("sprite") && this.SpriteAtlas != null && token.AttributeCount == 1)
				{
					global::UnityEngine.Texture2D texture = this.SpriteAtlas.Texture;
					float num2 = (float)dfDynamicFont.Baseline * base.TextScale;
					string value = token.GetAttribute(0).Value.Value;
					global::dfAtlas.ItemInfo itemInfo = this.SpriteAtlas[value];
					if (itemInfo != null)
					{
						float num3 = itemInfo.region.width * (float)texture.width / (itemInfo.region.height * (float)texture.height);
						num = global::UnityEngine.Mathf.CeilToInt(num2 * num3);
					}
					token.Height = global::UnityEngine.Mathf.CeilToInt(num2);
					token.Width = num;
				}
			}
			finally
			{
			}
		}

		// Token: 0x06004A3C RID: 19004 RVA: 0x001160B8 File Offset: 0x001142B8
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

		// Token: 0x06004A3D RID: 19005 RVA: 0x0011615C File Offset: 0x0011435C
		private void clipRight(global::dfRenderData destination, int startIndex)
		{
			if (destination == null)
			{
				return;
			}
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

		// Token: 0x06004A3E RID: 19006 RVA: 0x00116350 File Offset: 0x00114550
		private void clipBottom(global::dfRenderData destination, int startIndex)
		{
			if (destination == null)
			{
				return;
			}
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
					uv[i + 3] = global::UnityEngine.Vector2.Lerp(uv[i + 3], uv[i], num3);
					uv[i + 2] = global::UnityEngine.Vector2.Lerp(uv[i + 2], uv[i + 1], num3);
					global::UnityEngine.Color color = global::UnityEngine.Color.Lerp(colors[i + 3], colors[i], num3);
					colors[i + 3] = color;
					colors[i + 2] = color;
				}
			}
		}

		// Token: 0x06004A3F RID: 19007 RVA: 0x00116568 File Offset: 0x00114768
		private global::UnityEngine.Color32 applyOpacity(global::UnityEngine.Color32 color)
		{
			color.a = (byte)(base.Opacity * 255f);
			return color;
		}

		// Token: 0x06004A40 RID: 19008 RVA: 0x00116580 File Offset: 0x00114780
		private static void addTriangleIndices(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<int> triangles)
		{
			int count = verts.Count;
			int[] triangle_INDICES = global::dfDynamicFont.DynamicFontRenderer.TRIANGLE_INDICES;
			for (int i = 0; i < triangle_INDICES.Length; i++)
			{
				triangles.Add(count + triangle_INDICES[i]);
			}
		}

		// Token: 0x06004A41 RID: 19009 RVA: 0x001165BC File Offset: 0x001147BC
		private global::UnityEngine.Color multiplyColors(global::UnityEngine.Color lhs, global::UnityEngine.Color rhs)
		{
			return new global::UnityEngine.Color(lhs.r * rhs.r, lhs.g * rhs.g, lhs.b * rhs.b, lhs.a * rhs.a);
		}

		// Token: 0x0400276F RID: 10095
		private static global::System.Collections.Generic.Queue<global::dfDynamicFont.DynamicFontRenderer> objectPool = new global::System.Collections.Generic.Queue<global::dfDynamicFont.DynamicFontRenderer>();

		// Token: 0x04002770 RID: 10096
		private static global::UnityEngine.Vector2[] OUTLINE_OFFSETS = new global::UnityEngine.Vector2[]
		{
			new global::UnityEngine.Vector2(-1f, -1f),
			new global::UnityEngine.Vector2(-1f, 1f),
			new global::UnityEngine.Vector2(1f, -1f),
			new global::UnityEngine.Vector2(1f, 1f)
		};

		// Token: 0x04002771 RID: 10097
		private static int[] TRIANGLE_INDICES = new int[]
		{
			0,
			1,
			3,
			3,
			1,
			2
		};

		// Token: 0x04002772 RID: 10098
		private static global::System.Collections.Generic.Stack<global::UnityEngine.Color32> textColors = new global::System.Collections.Generic.Stack<global::UnityEngine.Color32>();

		// Token: 0x04002773 RID: 10099
		private global::dfList<global::dfDynamicFont.LineRenderInfo> lines;

		// Token: 0x04002774 RID: 10100
		private global::System.Collections.Generic.List<global::dfMarkupToken> tokens;

		// Token: 0x04002775 RID: 10101
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::dfAtlas <SpriteAtlas>k__BackingField;

		// Token: 0x04002776 RID: 10102
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::dfRenderData <SpriteBuffer>k__BackingField;
	}

	// Token: 0x0200085C RID: 2140
	private class LineRenderInfo
	{
		// Token: 0x06004A42 RID: 19010 RVA: 0x0011660C File Offset: 0x0011480C
		private LineRenderInfo()
		{
		}

		// Token: 0x06004A43 RID: 19011 RVA: 0x00116614 File Offset: 0x00114814
		// Note: this type is marked as 'beforefieldinit'.
		static LineRenderInfo()
		{
		}

		// Token: 0x17000DE8 RID: 3560
		// (get) Token: 0x06004A44 RID: 19012 RVA: 0x00116628 File Offset: 0x00114828
		public int length
		{
			get
			{
				return this.endOffset - this.startOffset + 1;
			}
		}

		// Token: 0x06004A45 RID: 19013 RVA: 0x0011663C File Offset: 0x0011483C
		public static void ResetPool()
		{
			global::dfDynamicFont.LineRenderInfo.poolIndex = 0;
		}

		// Token: 0x06004A46 RID: 19014 RVA: 0x00116644 File Offset: 0x00114844
		public static global::dfDynamicFont.LineRenderInfo Obtain(int start, int end)
		{
			if (global::dfDynamicFont.LineRenderInfo.poolIndex >= global::dfDynamicFont.LineRenderInfo.pool.Count - 1)
			{
				global::dfDynamicFont.LineRenderInfo.pool.Add(new global::dfDynamicFont.LineRenderInfo());
			}
			global::dfDynamicFont.LineRenderInfo lineRenderInfo = global::dfDynamicFont.LineRenderInfo.pool[global::dfDynamicFont.LineRenderInfo.poolIndex++];
			lineRenderInfo.startOffset = start;
			lineRenderInfo.endOffset = end;
			lineRenderInfo.lineHeight = 0f;
			return lineRenderInfo;
		}

		// Token: 0x04002777 RID: 10103
		public int startOffset;

		// Token: 0x04002778 RID: 10104
		public int endOffset;

		// Token: 0x04002779 RID: 10105
		public float lineWidth;

		// Token: 0x0400277A RID: 10106
		public float lineHeight;

		// Token: 0x0400277B RID: 10107
		private static global::dfList<global::dfDynamicFont.LineRenderInfo> pool = new global::dfList<global::dfDynamicFont.LineRenderInfo>();

		// Token: 0x0400277C RID: 10108
		private static int poolIndex = 0;
	}

	// Token: 0x0200085D RID: 2141
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <OnFontChanged>c__AnonStorey70
	{
		// Token: 0x06004A47 RID: 19015 RVA: 0x001166A8 File Offset: 0x001148A8
		public <OnFontChanged>c__AnonStorey70()
		{
		}

		// Token: 0x06004A48 RID: 19016 RVA: 0x001166B0 File Offset: 0x001148B0
		internal void <>m__2E(global::dfGUIManager manager)
		{
			global::dfGUIManager.AfterRender -= this.callback;
			this.<>f__this.invalidatingDependentControls = true;
			try
			{
				if (this.<>f__this.wasFontAtlasRebuilt)
				{
				}
				global::System.Collections.Generic.List<global::dfControl> list = (from global::dfControl x in 
					from x in global::UnityEngine.Object.FindObjectsOfType(typeof(global::dfControl))
					where x is global::IDFMultiRender
					select x
				orderby x.RenderOrder
				select x).ToList<global::dfControl>();
				for (int i = 0; i < list.Count; i++)
				{
					list[i].Invalidate();
				}
				if (this.<>f__this.wasFontAtlasRebuilt)
				{
					manager.Render();
				}
			}
			finally
			{
				this.<>f__this.wasFontAtlasRebuilt = false;
				this.<>f__this.invalidatingDependentControls = false;
			}
		}

		// Token: 0x06004A49 RID: 19017 RVA: 0x001167B8 File Offset: 0x001149B8
		private static bool <>m__2F(global::UnityEngine.Object x)
		{
			return x is global::IDFMultiRender;
		}

		// Token: 0x06004A4A RID: 19018 RVA: 0x001167C4 File Offset: 0x001149C4
		private static int <>m__30(global::dfControl x)
		{
			return x.RenderOrder;
		}

		// Token: 0x0400277D RID: 10109
		internal global::dfGUIManager.RenderCallback callback;

		// Token: 0x0400277E RID: 10110
		internal global::dfDynamicFont <>f__this;

		// Token: 0x0400277F RID: 10111
		private static global::System.Func<global::UnityEngine.Object, bool> <>f__am$cache2;

		// Token: 0x04002780 RID: 10112
		private static global::System.Func<global::dfControl, int> <>f__am$cache3;
	}
}
