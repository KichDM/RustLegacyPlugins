using System;
using UnityEngine;

// Token: 0x02000843 RID: 2115
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Sprite/Tiled")]
[global::UnityEngine.ExecuteInEditMode]
public class dfTiledSprite : global::dfSprite
{
	// Token: 0x0600492F RID: 18735 RVA: 0x001115DC File Offset: 0x0010F7DC
	public dfTiledSprite()
	{
	}

	// Token: 0x06004930 RID: 18736 RVA: 0x001115FC File Offset: 0x0010F7FC
	// Note: this type is marked as 'beforefieldinit'.
	static dfTiledSprite()
	{
	}

	// Token: 0x17000DBC RID: 3516
	// (get) Token: 0x06004931 RID: 18737 RVA: 0x00111620 File Offset: 0x0010F820
	// (set) Token: 0x06004932 RID: 18738 RVA: 0x00111628 File Offset: 0x0010F828
	public global::UnityEngine.Vector2 TileScale
	{
		get
		{
			return this.tileScale;
		}
		set
		{
			if (global::UnityEngine.Vector2.Distance(value, this.tileScale) > 1E-45f)
			{
				this.tileScale = global::UnityEngine.Vector2.Max(global::UnityEngine.Vector2.one * 0.1f, value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DBD RID: 3517
	// (get) Token: 0x06004933 RID: 18739 RVA: 0x00111664 File Offset: 0x0010F864
	// (set) Token: 0x06004934 RID: 18740 RVA: 0x0011166C File Offset: 0x0010F86C
	public global::UnityEngine.Vector2 TileScroll
	{
		get
		{
			return this.tileScroll;
		}
		set
		{
			if (global::UnityEngine.Vector2.Distance(value, this.tileScroll) > 1E-45f)
			{
				this.tileScroll = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x06004935 RID: 18741 RVA: 0x00111694 File Offset: 0x0010F894
	protected override void OnRebuildRenderData()
	{
		if (base.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo spriteInfo = base.SpriteInfo;
		if (spriteInfo == null)
		{
			return;
		}
		this.renderData.Material = base.Atlas.Material;
		global::dfList<global::UnityEngine.Vector3> vertices = this.renderData.Vertices;
		global::dfList<global::UnityEngine.Vector2> uv = this.renderData.UV;
		global::dfList<global::UnityEngine.Color32> colors = this.renderData.Colors;
		global::dfList<int> triangles = this.renderData.Triangles;
		global::UnityEngine.Vector2[] spriteUV = this.buildQuadUV();
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.Scale(spriteInfo.sizeInPixels, this.tileScale);
		global::UnityEngine.Vector2 vector2;
		vector2..ctor(this.tileScroll.x % 1f, this.tileScroll.y % 1f);
		for (float num = -global::UnityEngine.Mathf.Abs(vector2.y * vector.y); num < this.size.y; num += vector.y)
		{
			for (float num2 = -global::UnityEngine.Mathf.Abs(vector2.x * vector.x); num2 < this.size.x; num2 += vector.x)
			{
				int count = vertices.Count;
				vertices.Add(new global::UnityEngine.Vector3(num2, -num));
				vertices.Add(new global::UnityEngine.Vector3(num2 + vector.x, -num));
				vertices.Add(new global::UnityEngine.Vector3(num2 + vector.x, -num + -vector.y));
				vertices.Add(new global::UnityEngine.Vector3(num2, -num + -vector.y));
				this.addQuadTriangles(triangles, count);
				this.addQuadUV(uv, spriteUV);
				this.addQuadColors(colors);
			}
		}
		this.clipQuads(vertices, uv);
		float num3 = base.PixelsToUnits();
		global::UnityEngine.Vector3 vector3 = this.pivot.TransformToUpperLeft(this.size);
		for (int i = 0; i < vertices.Count; i++)
		{
			vertices[i] = (vertices[i] + vector3) * num3;
		}
	}

	// Token: 0x06004936 RID: 18742 RVA: 0x001118A8 File Offset: 0x0010FAA8
	private void clipQuads(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<global::UnityEngine.Vector2> uv)
	{
		float num = 0f;
		float num2 = this.size.x;
		float num3 = -this.size.y;
		float num4 = 0f;
		if (this.fillAmount < 1f)
		{
			if (this.fillDirection == global::dfFillDirection.Horizontal)
			{
				if (!this.invertFill)
				{
					num2 = this.size.x * this.fillAmount;
				}
				else
				{
					num = this.size.x - this.size.x * this.fillAmount;
				}
			}
			else if (!this.invertFill)
			{
				num3 = -this.size.y * this.fillAmount;
			}
			else
			{
				num4 = -this.size.y * (1f - this.fillAmount);
			}
		}
		for (int i = 0; i < verts.Count; i += 4)
		{
			global::UnityEngine.Vector3 value = verts[i];
			global::UnityEngine.Vector3 value2 = verts[i + 1];
			global::UnityEngine.Vector3 value3 = verts[i + 2];
			global::UnityEngine.Vector3 value4 = verts[i + 3];
			float num5 = value2.x - value.x;
			float num6 = value.y - value4.y;
			if (value.x < num)
			{
				float num7 = (num - value.x) / num5;
				int index = i;
				value..ctor(global::UnityEngine.Mathf.Max(num, value.x), value.y, value.z);
				verts[index] = value;
				int index2 = i + 1;
				value2..ctor(global::UnityEngine.Mathf.Max(num, value2.x), value2.y, value2.z);
				verts[index2] = value2;
				int index3 = i + 2;
				value3..ctor(global::UnityEngine.Mathf.Max(num, value3.x), value3.y, value3.z);
				verts[index3] = value3;
				int index4 = i + 3;
				value4..ctor(global::UnityEngine.Mathf.Max(num, value4.x), value4.y, value4.z);
				verts[index4] = value4;
				float num8 = global::UnityEngine.Mathf.Lerp(uv[i].x, uv[i + 1].x, num7);
				uv[i] = new global::UnityEngine.Vector2(num8, uv[i].y);
				uv[i + 3] = new global::UnityEngine.Vector2(num8, uv[i + 3].y);
				num5 = value2.x - value.x;
			}
			if (value2.x > num2)
			{
				float num9 = 1f - (num2 - value2.x + num5) / num5;
				int index5 = i;
				value..ctor(global::UnityEngine.Mathf.Min(value.x, num2), value.y, value.z);
				verts[index5] = value;
				int index6 = i + 1;
				value2..ctor(global::UnityEngine.Mathf.Min(value2.x, num2), value2.y, value2.z);
				verts[index6] = value2;
				int index7 = i + 2;
				value3..ctor(global::UnityEngine.Mathf.Min(value3.x, num2), value3.y, value3.z);
				verts[index7] = value3;
				int index8 = i + 3;
				value4..ctor(global::UnityEngine.Mathf.Min(value4.x, num2), value4.y, value4.z);
				verts[index8] = value4;
				float num10 = global::UnityEngine.Mathf.Lerp(uv[i + 1].x, uv[i].x, num9);
				uv[i + 1] = new global::UnityEngine.Vector2(num10, uv[i + 1].y);
				uv[i + 2] = new global::UnityEngine.Vector2(num10, uv[i + 2].y);
				num5 = value2.x - value.x;
			}
			if (value4.y < num3)
			{
				float num11 = 1f - global::UnityEngine.Mathf.Abs(-num3 + value.y) / num6;
				int index9 = i;
				value..ctor(value.x, global::UnityEngine.Mathf.Max(value.y, num3), value2.z);
				verts[index9] = value;
				int index10 = i + 1;
				value2..ctor(value2.x, global::UnityEngine.Mathf.Max(value2.y, num3), value2.z);
				verts[index10] = value2;
				int index11 = i + 2;
				value3..ctor(value3.x, global::UnityEngine.Mathf.Max(value3.y, num3), value3.z);
				verts[index11] = value3;
				int index12 = i + 3;
				value4..ctor(value4.x, global::UnityEngine.Mathf.Max(value4.y, num3), value4.z);
				verts[index12] = value4;
				float num12 = global::UnityEngine.Mathf.Lerp(uv[i + 3].y, uv[i].y, num11);
				uv[i + 3] = new global::UnityEngine.Vector2(uv[i + 3].x, num12);
				uv[i + 2] = new global::UnityEngine.Vector2(uv[i + 2].x, num12);
				num6 = global::UnityEngine.Mathf.Abs(value4.y - value.y);
			}
			if (value.y > num4)
			{
				float num13 = global::UnityEngine.Mathf.Abs(num4 - value.y) / num6;
				int index13 = i;
				value..ctor(value.x, global::UnityEngine.Mathf.Min(num4, value.y), value.z);
				verts[index13] = value;
				int index14 = i + 1;
				value2..ctor(value2.x, global::UnityEngine.Mathf.Min(num4, value2.y), value2.z);
				verts[index14] = value2;
				int index15 = i + 2;
				value3..ctor(value3.x, global::UnityEngine.Mathf.Min(num4, value3.y), value3.z);
				verts[index15] = value3;
				int index16 = i + 3;
				value4..ctor(value4.x, global::UnityEngine.Mathf.Min(num4, value4.y), value4.z);
				verts[index16] = value4;
				float num14 = global::UnityEngine.Mathf.Lerp(uv[i].y, uv[i + 3].y, num13);
				uv[i] = new global::UnityEngine.Vector2(uv[i].x, num14);
				uv[i + 1] = new global::UnityEngine.Vector2(uv[i + 1].x, num14);
			}
		}
	}

	// Token: 0x06004937 RID: 18743 RVA: 0x00111F48 File Offset: 0x00110148
	private void addQuadTriangles(global::dfList<int> triangles, int baseIndex)
	{
		for (int i = 0; i < global::dfTiledSprite.quadTriangles.Length; i++)
		{
			triangles.Add(global::dfTiledSprite.quadTriangles[i] + baseIndex);
		}
	}

	// Token: 0x06004938 RID: 18744 RVA: 0x00111F7C File Offset: 0x0011017C
	private void addQuadColors(global::dfList<global::UnityEngine.Color32> colors)
	{
		colors.EnsureCapacity(colors.Count + 4);
		global::UnityEngine.Color32 item = base.ApplyOpacity((!base.IsEnabled) ? this.disabledColor : this.color);
		for (int i = 0; i < 4; i++)
		{
			colors.Add(item);
		}
	}

	// Token: 0x06004939 RID: 18745 RVA: 0x00111FD4 File Offset: 0x001101D4
	private void addQuadUV(global::dfList<global::UnityEngine.Vector2> uv, global::UnityEngine.Vector2[] spriteUV)
	{
		uv.AddRange(spriteUV);
	}

	// Token: 0x0600493A RID: 18746 RVA: 0x00111FE0 File Offset: 0x001101E0
	private global::UnityEngine.Vector2[] buildQuadUV()
	{
		global::dfAtlas.ItemInfo spriteInfo = base.SpriteInfo;
		global::UnityEngine.Rect region = spriteInfo.region;
		global::dfTiledSprite.quadUV[0] = new global::UnityEngine.Vector2(region.x, region.yMax);
		global::dfTiledSprite.quadUV[1] = new global::UnityEngine.Vector2(region.xMax, region.yMax);
		global::dfTiledSprite.quadUV[2] = new global::UnityEngine.Vector2(region.xMax, region.y);
		global::dfTiledSprite.quadUV[3] = new global::UnityEngine.Vector2(region.x, region.y);
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.zero;
		if (this.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
		{
			vector = global::dfTiledSprite.quadUV[1];
			global::dfTiledSprite.quadUV[1] = global::dfTiledSprite.quadUV[0];
			global::dfTiledSprite.quadUV[0] = vector;
			vector = global::dfTiledSprite.quadUV[3];
			global::dfTiledSprite.quadUV[3] = global::dfTiledSprite.quadUV[2];
			global::dfTiledSprite.quadUV[2] = vector;
		}
		if (this.flip.IsSet(global::dfSpriteFlip.FlipVertical))
		{
			vector = global::dfTiledSprite.quadUV[0];
			global::dfTiledSprite.quadUV[0] = global::dfTiledSprite.quadUV[3];
			global::dfTiledSprite.quadUV[3] = vector;
			vector = global::dfTiledSprite.quadUV[1];
			global::dfTiledSprite.quadUV[1] = global::dfTiledSprite.quadUV[2];
			global::dfTiledSprite.quadUV[2] = vector;
		}
		return global::dfTiledSprite.quadUV;
	}

	// Token: 0x0400270A RID: 9994
	private static int[] quadTriangles = new int[]
	{
		0,
		1,
		3,
		3,
		1,
		2
	};

	// Token: 0x0400270B RID: 9995
	private static global::UnityEngine.Vector2[] quadUV = new global::UnityEngine.Vector2[4];

	// Token: 0x0400270C RID: 9996
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 tileScale = global::UnityEngine.Vector2.one;

	// Token: 0x0400270D RID: 9997
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 tileScroll = global::UnityEngine.Vector2.zero;
}
