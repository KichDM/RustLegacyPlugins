using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Token: 0x02000862 RID: 2146
public class dfMarkupBoxText : global::dfMarkupBox
{
	// Token: 0x06004A77 RID: 19063 RVA: 0x00117D70 File Offset: 0x00115F70
	public dfMarkupBoxText(global::dfMarkupElement element, global::dfMarkupDisplayType display, global::dfMarkupStyle style) : base(element, display, style)
	{
	}

	// Token: 0x06004A78 RID: 19064 RVA: 0x00117D88 File Offset: 0x00115F88
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupBoxText()
	{
	}

	// Token: 0x17000DF1 RID: 3569
	// (get) Token: 0x06004A79 RID: 19065 RVA: 0x00117DBC File Offset: 0x00115FBC
	// (set) Token: 0x06004A7A RID: 19066 RVA: 0x00117DC4 File Offset: 0x00115FC4
	public string Text
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Text>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Text>k__BackingField = value;
		}
	}

	// Token: 0x17000DF2 RID: 3570
	// (get) Token: 0x06004A7B RID: 19067 RVA: 0x00117DD0 File Offset: 0x00115FD0
	public bool IsWhitespace
	{
		get
		{
			return this.isWhitespace;
		}
	}

	// Token: 0x06004A7C RID: 19068 RVA: 0x00117DD8 File Offset: 0x00115FD8
	public static global::dfMarkupBoxText Obtain(global::dfMarkupElement element, global::dfMarkupDisplayType display, global::dfMarkupStyle style)
	{
		if (global::dfMarkupBoxText.objectPool.Count > 0)
		{
			global::dfMarkupBoxText dfMarkupBoxText = global::dfMarkupBoxText.objectPool.Dequeue();
			dfMarkupBoxText.Element = element;
			dfMarkupBoxText.Display = display;
			dfMarkupBoxText.Style = style;
			dfMarkupBoxText.Position = global::UnityEngine.Vector2.zero;
			dfMarkupBoxText.Size = global::UnityEngine.Vector2.zero;
			dfMarkupBoxText.Baseline = (int)((float)style.FontSize * 1.1f);
			dfMarkupBoxText.Margins = default(global::dfMarkupBorders);
			dfMarkupBoxText.Padding = default(global::dfMarkupBorders);
			return dfMarkupBoxText;
		}
		return new global::dfMarkupBoxText(element, display, style);
	}

	// Token: 0x06004A7D RID: 19069 RVA: 0x00117E68 File Offset: 0x00116068
	public override void Release()
	{
		base.Release();
		this.Text = string.Empty;
		this.renderData.Clear();
		global::dfMarkupBoxText.objectPool.Enqueue(this);
	}

	// Token: 0x06004A7E RID: 19070 RVA: 0x00117E9C File Offset: 0x0011609C
	internal void SetText(string text)
	{
		this.Text = text;
		if (this.Style.Font == null)
		{
			return;
		}
		this.isWhitespace = global::dfMarkupBoxText.whitespacePattern.IsMatch(this.Text);
		string text2 = (!this.Style.PreserveWhitespace && this.isWhitespace) ? " " : this.Text;
		global::UnityEngine.CharacterInfo[] array = this.Style.Font.RequestCharacters(text2, this.Style.FontSize, this.Style.FontStyle);
		int fontSize = this.Style.FontSize;
		global::UnityEngine.Vector2 size;
		size..ctor(0f, (float)this.Style.LineHeight);
		for (int i = 0; i < text2.Length; i++)
		{
			global::UnityEngine.CharacterInfo characterInfo = array[i];
			float num = characterInfo.vert.x + characterInfo.vert.width;
			if (text2[i] == ' ')
			{
				num = global::UnityEngine.Mathf.Max(num, (float)fontSize * 0.33f);
			}
			else if (text2[i] == '\t')
			{
				num += (float)(fontSize * 3);
			}
			size.x += num;
		}
		this.Size = size;
		global::dfDynamicFont font = this.Style.Font;
		float num2 = (float)fontSize / (float)font.FontSize;
		this.Baseline = global::UnityEngine.Mathf.CeilToInt((float)font.Baseline * num2);
	}

	// Token: 0x06004A7F RID: 19071 RVA: 0x00118020 File Offset: 0x00116220
	protected override global::dfRenderData OnRebuildRenderData()
	{
		this.renderData.Clear();
		if (this.Style.Font == null)
		{
			return null;
		}
		if (this.Style.TextDecoration == global::dfMarkupTextDecoration.Underline)
		{
			this.renderUnderline();
		}
		this.renderText(this.Text);
		return this.renderData;
	}

	// Token: 0x06004A80 RID: 19072 RVA: 0x0011807C File Offset: 0x0011627C
	private void renderUnderline()
	{
	}

	// Token: 0x06004A81 RID: 19073 RVA: 0x00118080 File Offset: 0x00116280
	private void renderText(string text)
	{
		global::dfDynamicFont font = this.Style.Font;
		int fontSize = this.Style.FontSize;
		global::UnityEngine.FontStyle fontStyle = this.Style.FontStyle;
		global::dfList<global::UnityEngine.Vector3> vertices = this.renderData.Vertices;
		global::dfList<int> triangles = this.renderData.Triangles;
		global::dfList<global::UnityEngine.Vector2> uv = this.renderData.UV;
		global::dfList<global::UnityEngine.Color32> colors = this.renderData.Colors;
		float num = (float)fontSize / (float)font.FontSize;
		float num2 = (float)font.Descent * num;
		float num3 = 0f;
		global::UnityEngine.CharacterInfo[] array = font.RequestCharacters(text, fontSize, fontStyle);
		this.renderData.Material = font.Material;
		for (int i = 0; i < text.Length; i++)
		{
			global::UnityEngine.CharacterInfo characterInfo = array[i];
			global::dfMarkupBoxText.addTriangleIndices(vertices, triangles);
			float num4 = (float)font.FontSize + characterInfo.vert.y - (float)fontSize + num2;
			float num5 = num3 + characterInfo.vert.x;
			float num6 = num4;
			float num7 = num5 + characterInfo.vert.width;
			float num8 = num6 + characterInfo.vert.height;
			global::UnityEngine.Vector3 item;
			item..ctor(num5, num6);
			global::UnityEngine.Vector3 item2;
			item2..ctor(num7, num6);
			global::UnityEngine.Vector3 item3;
			item3..ctor(num7, num8);
			global::UnityEngine.Vector3 item4;
			item4..ctor(num5, num8);
			vertices.Add(item);
			vertices.Add(item2);
			vertices.Add(item3);
			vertices.Add(item4);
			global::UnityEngine.Color color = this.Style.Color;
			colors.Add(color);
			colors.Add(color);
			colors.Add(color);
			colors.Add(color);
			global::UnityEngine.Rect uv2 = characterInfo.uv;
			float x = uv2.x;
			float num9 = uv2.y + uv2.height;
			float num10 = x + uv2.width;
			float y = uv2.y;
			if (characterInfo.flipped)
			{
				uv.Add(new global::UnityEngine.Vector2(num10, y));
				uv.Add(new global::UnityEngine.Vector2(num10, num9));
				uv.Add(new global::UnityEngine.Vector2(x, num9));
				uv.Add(new global::UnityEngine.Vector2(x, y));
			}
			else
			{
				uv.Add(new global::UnityEngine.Vector2(x, num9));
				uv.Add(new global::UnityEngine.Vector2(num10, num9));
				uv.Add(new global::UnityEngine.Vector2(num10, y));
				uv.Add(new global::UnityEngine.Vector2(x, y));
			}
			num3 += (float)global::UnityEngine.Mathf.CeilToInt(characterInfo.vert.x + characterInfo.vert.width);
		}
	}

	// Token: 0x06004A82 RID: 19074 RVA: 0x00118324 File Offset: 0x00116524
	private static void addTriangleIndices(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<int> triangles)
	{
		int count = verts.Count;
		int[] triangle_INDICES = global::dfMarkupBoxText.TRIANGLE_INDICES;
		for (int i = 0; i < triangle_INDICES.Length; i++)
		{
			triangles.Add(count + triangle_INDICES[i]);
		}
	}

	// Token: 0x040027A7 RID: 10151
	private static int[] TRIANGLE_INDICES = new int[]
	{
		0,
		1,
		2,
		0,
		2,
		3
	};

	// Token: 0x040027A8 RID: 10152
	private static global::System.Collections.Generic.Queue<global::dfMarkupBoxText> objectPool = new global::System.Collections.Generic.Queue<global::dfMarkupBoxText>();

	// Token: 0x040027A9 RID: 10153
	private static global::System.Text.RegularExpressions.Regex whitespacePattern = new global::System.Text.RegularExpressions.Regex("\\s+");

	// Token: 0x040027AA RID: 10154
	private global::dfRenderData renderData = new global::dfRenderData(0x20);

	// Token: 0x040027AB RID: 10155
	private bool isWhitespace;

	// Token: 0x040027AC RID: 10156
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Text>k__BackingField;
}
