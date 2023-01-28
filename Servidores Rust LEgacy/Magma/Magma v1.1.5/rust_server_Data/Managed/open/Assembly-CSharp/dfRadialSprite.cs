using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200082B RID: 2091
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Sprite/Radial")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfRadialSprite : global::dfSprite
{
	// Token: 0x0600472A RID: 18218 RVA: 0x0010669C File Offset: 0x0010489C
	public dfRadialSprite()
	{
	}

	// Token: 0x0600472B RID: 18219 RVA: 0x001066AC File Offset: 0x001048AC
	// Note: this type is marked as 'beforefieldinit'.
	static dfRadialSprite()
	{
	}

	// Token: 0x17000D47 RID: 3399
	// (get) Token: 0x0600472C RID: 18220 RVA: 0x001067C4 File Offset: 0x001049C4
	// (set) Token: 0x0600472D RID: 18221 RVA: 0x001067CC File Offset: 0x001049CC
	public global::dfPivotPoint FillOrigin
	{
		get
		{
			return this.fillOrigin;
		}
		set
		{
			if (value != this.fillOrigin)
			{
				this.fillOrigin = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x0600472E RID: 18222 RVA: 0x001067E8 File Offset: 0x001049E8
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
		global::System.Collections.Generic.List<global::UnityEngine.Vector3> list = null;
		global::System.Collections.Generic.List<int> list2 = null;
		global::System.Collections.Generic.List<global::UnityEngine.Vector2> list3 = null;
		this.buildMeshData(ref list, ref list2, ref list3);
		global::UnityEngine.Color32[] list4 = this.buildColors(list.Count);
		this.renderData.Vertices.AddRange(list);
		this.renderData.Triangles.AddRange(list2);
		this.renderData.UV.AddRange(list3);
		this.renderData.Colors.AddRange(list4);
	}

	// Token: 0x0600472F RID: 18223 RVA: 0x00106898 File Offset: 0x00104A98
	private void buildMeshData(ref global::System.Collections.Generic.List<global::UnityEngine.Vector3> verts, ref global::System.Collections.Generic.List<int> indices, ref global::System.Collections.Generic.List<global::UnityEngine.Vector2> uv)
	{
		global::System.Collections.Generic.List<global::UnityEngine.Vector3> list;
		verts = (list = new global::System.Collections.Generic.List<global::UnityEngine.Vector3>());
		global::System.Collections.Generic.List<global::UnityEngine.Vector3> list2 = list;
		verts.AddRange(global::dfRadialSprite.baseVerts);
		int num;
		int index;
		switch (this.fillOrigin)
		{
		case global::dfPivotPoint.TopLeft:
			num = 4;
			index = 5;
			list2.RemoveAt(6);
			list2.RemoveAt(0);
			break;
		case global::dfPivotPoint.TopCenter:
			num = 6;
			index = 0;
			break;
		case global::dfPivotPoint.TopRight:
			num = 4;
			index = 0;
			list2.RemoveAt(2);
			list2.RemoveAt(0);
			break;
		case global::dfPivotPoint.MiddleLeft:
			num = 6;
			index = 6;
			break;
		case global::dfPivotPoint.MiddleCenter:
			num = 8;
			list2.Add(list2[0]);
			list2.Insert(0, global::UnityEngine.Vector3.zero);
			index = 0;
			break;
		case global::dfPivotPoint.MiddleRight:
			num = 6;
			index = 2;
			break;
		case global::dfPivotPoint.BottomLeft:
			num = 4;
			index = 4;
			list2.RemoveAt(6);
			list2.RemoveAt(4);
			break;
		case global::dfPivotPoint.BottomCenter:
			num = 6;
			index = 4;
			break;
		case global::dfPivotPoint.BottomRight:
			num = 4;
			index = 2;
			list2.RemoveAt(4);
			list2.RemoveAt(2);
			break;
		default:
			throw new global::System.NotImplementedException();
		}
		this.makeFirst(list2, index);
		global::System.Collections.Generic.List<int> list3;
		indices = (list3 = this.buildTriangles(list2));
		global::System.Collections.Generic.List<int> list4 = list3;
		float num2 = 1f / (float)num;
		float num3 = this.fillAmount.Quantize(num2);
		int num4 = global::UnityEngine.Mathf.CeilToInt(num3 / num2) + 1;
		for (int i = num4; i < num; i++)
		{
			if (this.invertFill)
			{
				list4.RemoveRange(0, 3);
			}
			else
			{
				list2.RemoveAt(list2.Count - 1);
				list4.RemoveRange(list4.Count - 3, 3);
			}
		}
		if (this.fillAmount < 1f)
		{
			int index2 = list4[(!this.invertFill) ? (list4.Count - 2) : 2];
			int index3 = list4[(!this.invertFill) ? (list4.Count - 1) : 1];
			float num5 = (base.FillAmount - num3) / num2;
			list2[index3] = global::UnityEngine.Vector3.Lerp(list2[index2], list2[index3], num5);
		}
		uv = this.buildUV(list2);
		float num6 = base.PixelsToUnits();
		global::UnityEngine.Vector2 vector = num6 * this.size;
		global::UnityEngine.Vector3 vector2 = this.pivot.TransformToCenter(this.size) * num6;
		for (int j = 0; j < list2.Count; j++)
		{
			list2[j] = global::UnityEngine.Vector3.Scale(list2[j], vector) + vector2;
		}
	}

	// Token: 0x06004730 RID: 18224 RVA: 0x00106B24 File Offset: 0x00104D24
	private void makeFirst(global::System.Collections.Generic.List<global::UnityEngine.Vector3> list, int index)
	{
		if (index == 0)
		{
			return;
		}
		global::System.Collections.Generic.List<global::UnityEngine.Vector3> range = list.GetRange(index, list.Count - index);
		list.RemoveRange(index, list.Count - index);
		list.InsertRange(0, range);
	}

	// Token: 0x06004731 RID: 18225 RVA: 0x00106B60 File Offset: 0x00104D60
	private global::System.Collections.Generic.List<int> buildTriangles(global::System.Collections.Generic.List<global::UnityEngine.Vector3> verts)
	{
		global::System.Collections.Generic.List<int> list = new global::System.Collections.Generic.List<int>();
		int count = verts.Count;
		for (int i = 1; i < count - 1; i++)
		{
			list.Add(0);
			list.Add(i);
			list.Add(i + 1);
		}
		return list;
	}

	// Token: 0x06004732 RID: 18226 RVA: 0x00106BA8 File Offset: 0x00104DA8
	private global::System.Collections.Generic.List<global::UnityEngine.Vector2> buildUV(global::System.Collections.Generic.List<global::UnityEngine.Vector3> verts)
	{
		global::dfAtlas.ItemInfo spriteInfo = base.SpriteInfo;
		if (spriteInfo == null)
		{
			return null;
		}
		global::UnityEngine.Rect region = spriteInfo.region;
		if (this.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
		{
			region..ctor(region.xMax, region.y, -region.width, region.height);
		}
		if (this.flip.IsSet(global::dfSpriteFlip.FlipVertical))
		{
			region..ctor(region.x, region.yMax, region.width, -region.height);
		}
		global::UnityEngine.Vector2 vector;
		vector..ctor(region.x, region.y);
		global::UnityEngine.Vector2 vector2;
		vector2..ctor(0.5f, 0.5f);
		global::UnityEngine.Vector2 vector3;
		vector3..ctor(region.width, region.height);
		global::System.Collections.Generic.List<global::UnityEngine.Vector2> list = new global::System.Collections.Generic.List<global::UnityEngine.Vector2>(verts.Count);
		for (int i = 0; i < verts.Count; i++)
		{
			global::UnityEngine.Vector2 vector4 = verts[i] + vector2;
			list.Add(global::UnityEngine.Vector2.Scale(vector4, vector3) + vector);
		}
		return list;
	}

	// Token: 0x06004733 RID: 18227 RVA: 0x00106CCC File Offset: 0x00104ECC
	private global::UnityEngine.Color32[] buildColors(int vertCount)
	{
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? this.disabledColor : this.color);
		global::UnityEngine.Color32[] array = new global::UnityEngine.Color32[vertCount];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = color;
		}
		return array;
	}

	// Token: 0x04002653 RID: 9811
	private static global::UnityEngine.Vector3[] baseVerts = new global::UnityEngine.Vector3[]
	{
		new global::UnityEngine.Vector3(0f, 0.5f, 0f),
		new global::UnityEngine.Vector3(0.5f, 0.5f, 0f),
		new global::UnityEngine.Vector3(0.5f, 0f, 0f),
		new global::UnityEngine.Vector3(0.5f, -0.5f, 0f),
		new global::UnityEngine.Vector3(0f, -0.5f, 0f),
		new global::UnityEngine.Vector3(-0.5f, -0.5f, 0f),
		new global::UnityEngine.Vector3(-0.5f, 0f, 0f),
		new global::UnityEngine.Vector3(-0.5f, 0.5f, 0f)
	};

	// Token: 0x04002654 RID: 9812
	[global::UnityEngine.SerializeField]
	protected global::dfPivotPoint fillOrigin = global::dfPivotPoint.MiddleCenter;
}
