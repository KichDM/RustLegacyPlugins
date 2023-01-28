using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000860 RID: 2144
public class dfMarkupBoxSprite : global::dfMarkupBox
{
	// Token: 0x06004A66 RID: 19046 RVA: 0x00117858 File Offset: 0x00115A58
	public dfMarkupBoxSprite(global::dfMarkupElement element, global::dfMarkupDisplayType display, global::dfMarkupStyle style) : base(element, display, style)
	{
	}

	// Token: 0x06004A67 RID: 19047 RVA: 0x00117870 File Offset: 0x00115A70
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupBoxSprite()
	{
	}

	// Token: 0x17000DEE RID: 3566
	// (get) Token: 0x06004A68 RID: 19048 RVA: 0x00117888 File Offset: 0x00115A88
	// (set) Token: 0x06004A69 RID: 19049 RVA: 0x00117890 File Offset: 0x00115A90
	public global::dfAtlas Atlas
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Atlas>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Atlas>k__BackingField = value;
		}
	}

	// Token: 0x17000DEF RID: 3567
	// (get) Token: 0x06004A6A RID: 19050 RVA: 0x0011789C File Offset: 0x00115A9C
	// (set) Token: 0x06004A6B RID: 19051 RVA: 0x001178A4 File Offset: 0x00115AA4
	public string Source
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Source>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Source>k__BackingField = value;
		}
	}

	// Token: 0x06004A6C RID: 19052 RVA: 0x001178B0 File Offset: 0x00115AB0
	internal void LoadImage(global::dfAtlas atlas, string source)
	{
		global::dfAtlas.ItemInfo itemInfo = atlas[source];
		if (itemInfo == null)
		{
			throw new global::System.InvalidOperationException("Sprite does not exist in atlas: " + source);
		}
		this.Atlas = atlas;
		this.Source = source;
		this.Size = itemInfo.sizeInPixels;
		this.Baseline = (int)this.Size.y;
	}

	// Token: 0x06004A6D RID: 19053 RVA: 0x00117910 File Offset: 0x00115B10
	protected override global::dfRenderData OnRebuildRenderData()
	{
		this.renderData.Clear();
		if (this.Atlas != null && this.Atlas[this.Source] != null)
		{
			global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
			{
				atlas = this.Atlas,
				spriteInfo = this.Atlas[this.Source],
				pixelsToUnits = 1f,
				size = this.Size,
				color = this.Style.Color,
				fillAmount = 1f
			};
			global::dfSlicedSprite.renderSprite(this.renderData, options);
			this.renderData.Material = this.Atlas.Material;
			this.renderData.Transform = global::UnityEngine.Matrix4x4.identity;
		}
		return this.renderData;
	}

	// Token: 0x06004A6E RID: 19054 RVA: 0x001179FC File Offset: 0x00115BFC
	private static void addTriangleIndices(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<int> triangles)
	{
		int count = verts.Count;
		int[] triangle_INDICES = global::dfMarkupBoxSprite.TRIANGLE_INDICES;
		for (int i = 0; i < triangle_INDICES.Length; i++)
		{
			triangles.Add(count + triangle_INDICES[i]);
		}
	}

	// Token: 0x0400279F RID: 10143
	private static int[] TRIANGLE_INDICES = new int[]
	{
		0,
		1,
		2,
		0,
		2,
		3
	};

	// Token: 0x040027A0 RID: 10144
	private global::dfRenderData renderData = new global::dfRenderData(0x20);

	// Token: 0x040027A1 RID: 10145
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfAtlas <Atlas>k__BackingField;

	// Token: 0x040027A2 RID: 10146
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Source>k__BackingField;
}
