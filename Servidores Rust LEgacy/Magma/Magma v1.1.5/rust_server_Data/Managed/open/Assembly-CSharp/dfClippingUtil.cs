using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020007DA RID: 2010
public class dfClippingUtil
{
	// Token: 0x060042AB RID: 17067 RVA: 0x000F22D0 File Offset: 0x000F04D0
	public dfClippingUtil()
	{
	}

	// Token: 0x060042AC RID: 17068 RVA: 0x000F22D8 File Offset: 0x000F04D8
	static dfClippingUtil()
	{
	}

	// Token: 0x060042AD RID: 17069 RVA: 0x000F2304 File Offset: 0x000F0504
	public static void Clip(global::System.Collections.Generic.IList<global::UnityEngine.Plane> planes, global::dfRenderData source, global::dfRenderData dest)
	{
		dest.EnsureCapacity(dest.Vertices.Count + source.Vertices.Count);
		for (int i = 0; i < source.Triangles.Count; i += 3)
		{
			for (int j = 0; j < 3; j++)
			{
				int index = source.Triangles[i + j];
				global::dfClippingUtil.clipSource[0].corner[j] = source.Transform.MultiplyPoint(source.Vertices[index]);
				global::dfClippingUtil.clipSource[0].uv[j] = source.UV[index];
				global::dfClippingUtil.clipSource[0].color[j] = source.Colors[index];
			}
			int num = 1;
			for (int k = 0; k < planes.Count; k++)
			{
				num = global::dfClippingUtil.clipToPlane(planes[k], global::dfClippingUtil.clipSource, global::dfClippingUtil.clipDest, num);
				global::dfClippingUtil.ClipTriangle[] array = global::dfClippingUtil.clipSource;
				global::dfClippingUtil.clipSource = global::dfClippingUtil.clipDest;
				global::dfClippingUtil.clipDest = array;
			}
			for (int l = 0; l < num; l++)
			{
				global::dfClippingUtil.clipSource[l].CopyTo(dest);
			}
		}
	}

	// Token: 0x060042AE RID: 17070 RVA: 0x000F2468 File Offset: 0x000F0668
	private static int clipToPlane(global::UnityEngine.Plane plane, global::dfClippingUtil.ClipTriangle[] source, global::dfClippingUtil.ClipTriangle[] dest, int count)
	{
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			num += global::dfClippingUtil.clipToPlane(plane, source[i], dest, num);
		}
		return num;
	}

	// Token: 0x060042AF RID: 17071 RVA: 0x000F24A4 File Offset: 0x000F06A4
	private static int clipToPlane(global::UnityEngine.Plane plane, global::dfClippingUtil.ClipTriangle triangle, global::dfClippingUtil.ClipTriangle[] dest, int destIndex)
	{
		global::UnityEngine.Vector3[] corner = triangle.corner;
		int num = 0;
		int num2 = 0;
		global::UnityEngine.Vector3 normal = plane.normal;
		float distance = plane.distance;
		for (int i = 0; i < 3; i++)
		{
			if (global::UnityEngine.Vector3.Dot(normal, corner[i]) + distance > 0f)
			{
				global::dfClippingUtil.inside[num++] = i;
			}
			else
			{
				num2 = i;
			}
		}
		if (num == 3)
		{
			triangle.CopyTo(dest[destIndex]);
			return 1;
		}
		if (num == 0)
		{
			return 0;
		}
		if (num == 1)
		{
			int num3 = global::dfClippingUtil.inside[0];
			int num4 = (num3 + 1) % 3;
			int num5 = (num3 + 2) % 3;
			global::UnityEngine.Vector3 vector = corner[num3];
			global::UnityEngine.Vector3 vector2 = corner[num4];
			global::UnityEngine.Vector3 vector3 = corner[num5];
			global::UnityEngine.Vector2 vector4 = triangle.uv[num3];
			global::UnityEngine.Vector2 vector5 = triangle.uv[num4];
			global::UnityEngine.Vector2 vector6 = triangle.uv[num5];
			global::UnityEngine.Color32 color = triangle.color[num3];
			global::UnityEngine.Color32 color2 = triangle.color[num4];
			global::UnityEngine.Color32 color3 = triangle.color[num5];
			float num6 = 0f;
			global::UnityEngine.Vector3 vector7 = vector2 - vector;
			global::UnityEngine.Ray ray;
			ray..ctor(vector, vector7.normalized);
			plane.Raycast(ray, ref num6);
			float num7 = num6 / vector7.magnitude;
			global::UnityEngine.Vector3 vector8 = ray.origin + ray.direction * num6;
			global::UnityEngine.Vector2 vector9 = global::UnityEngine.Vector2.Lerp(vector4, vector5, num7);
			global::UnityEngine.Color color4 = global::UnityEngine.Color.Lerp(color, color2, num7);
			vector7 = vector3 - vector;
			ray..ctor(vector, vector7.normalized);
			plane.Raycast(ray, ref num6);
			num7 = num6 / vector7.magnitude;
			global::UnityEngine.Vector3 vector10 = ray.origin + ray.direction * num6;
			global::UnityEngine.Vector2 vector11 = global::UnityEngine.Vector2.Lerp(vector4, vector6, num7);
			global::UnityEngine.Color color5 = global::UnityEngine.Color.Lerp(color, color3, num7);
			dest[destIndex].corner[0] = vector;
			dest[destIndex].corner[1] = vector8;
			dest[destIndex].corner[2] = vector10;
			dest[destIndex].uv[0] = vector4;
			dest[destIndex].uv[1] = vector9;
			dest[destIndex].uv[2] = vector11;
			dest[destIndex].color[0] = color;
			dest[destIndex].color[1] = color4;
			dest[destIndex].color[2] = color5;
			return 1;
		}
		int num8 = num2;
		int num9 = (num8 + 1) % 3;
		int num10 = (num8 + 2) % 3;
		global::UnityEngine.Vector3 vector12 = corner[num8];
		global::UnityEngine.Vector3 vector13 = corner[num9];
		global::UnityEngine.Vector3 vector14 = corner[num10];
		global::UnityEngine.Vector2 vector15 = triangle.uv[num8];
		global::UnityEngine.Vector2 vector16 = triangle.uv[num9];
		global::UnityEngine.Vector2 vector17 = triangle.uv[num10];
		global::UnityEngine.Color32 color6 = triangle.color[num8];
		global::UnityEngine.Color32 color7 = triangle.color[num9];
		global::UnityEngine.Color32 color8 = triangle.color[num10];
		global::UnityEngine.Vector3 vector18 = vector13 - vector12;
		global::UnityEngine.Ray ray2;
		ray2..ctor(vector12, vector18.normalized);
		float num11 = 0f;
		plane.Raycast(ray2, ref num11);
		float num12 = num11 / vector18.magnitude;
		global::UnityEngine.Vector3 vector19 = ray2.origin + ray2.direction * num11;
		global::UnityEngine.Vector2 vector20 = global::UnityEngine.Vector2.Lerp(vector15, vector16, num12);
		global::UnityEngine.Color color9 = global::UnityEngine.Color.Lerp(color6, color7, num12);
		vector18 = vector14 - vector12;
		ray2..ctor(vector12, vector18.normalized);
		plane.Raycast(ray2, ref num11);
		num12 = num11 / vector18.magnitude;
		global::UnityEngine.Vector3 vector21 = ray2.origin + ray2.direction * num11;
		global::UnityEngine.Vector2 vector22 = global::UnityEngine.Vector2.Lerp(vector15, vector17, num12);
		global::UnityEngine.Color color10 = global::UnityEngine.Color.Lerp(color6, color8, num12);
		dest[destIndex].corner[0] = vector19;
		dest[destIndex].corner[1] = vector13;
		dest[destIndex].corner[2] = vector21;
		dest[destIndex].uv[0] = vector20;
		dest[destIndex].uv[1] = vector16;
		dest[destIndex].uv[2] = vector22;
		dest[destIndex].color[0] = color9;
		dest[destIndex].color[1] = color7;
		dest[destIndex].color[2] = color10;
		destIndex++;
		dest[destIndex].corner[0] = vector21;
		dest[destIndex].corner[1] = vector13;
		dest[destIndex].corner[2] = vector14;
		dest[destIndex].uv[0] = vector22;
		dest[destIndex].uv[1] = vector16;
		dest[destIndex].uv[2] = vector17;
		dest[destIndex].color[0] = color10;
		dest[destIndex].color[1] = color7;
		dest[destIndex].color[2] = color8;
		return 2;
	}

	// Token: 0x060042B0 RID: 17072 RVA: 0x000F2B64 File Offset: 0x000F0D64
	private static global::dfClippingUtil.ClipTriangle[] initClipBuffer(int size)
	{
		global::dfClippingUtil.ClipTriangle[] array = new global::dfClippingUtil.ClipTriangle[size];
		for (int i = 0; i < size; i++)
		{
			array[i].corner = new global::UnityEngine.Vector3[3];
			array[i].uv = new global::UnityEngine.Vector2[3];
			array[i].color = new global::UnityEngine.Color32[3];
		}
		return array;
	}

	// Token: 0x0400239D RID: 9117
	private static int[] inside = new int[3];

	// Token: 0x0400239E RID: 9118
	private static global::dfClippingUtil.ClipTriangle[] clipSource = global::dfClippingUtil.initClipBuffer(0x400);

	// Token: 0x0400239F RID: 9119
	private static global::dfClippingUtil.ClipTriangle[] clipDest = global::dfClippingUtil.initClipBuffer(0x400);

	// Token: 0x020007DB RID: 2011
	protected struct ClipTriangle
	{
		// Token: 0x060042B1 RID: 17073 RVA: 0x000F2BC4 File Offset: 0x000F0DC4
		public void CopyTo(global::dfClippingUtil.ClipTriangle target)
		{
			global::System.Array.Copy(this.corner, target.corner, 3);
			global::System.Array.Copy(this.uv, target.uv, 3);
			global::System.Array.Copy(this.color, target.color, 3);
		}

		// Token: 0x060042B2 RID: 17074 RVA: 0x000F2C00 File Offset: 0x000F0E00
		public void CopyTo(global::dfRenderData buffer)
		{
			int count = buffer.Vertices.Count;
			buffer.Vertices.AddRange(this.corner);
			buffer.UV.AddRange(this.uv);
			buffer.Colors.AddRange(this.color);
			buffer.Triangles.Add(count);
			buffer.Triangles.Add(count + 1);
			buffer.Triangles.Add(count + 2);
		}

		// Token: 0x040023A0 RID: 9120
		public global::UnityEngine.Vector3[] corner;

		// Token: 0x040023A1 RID: 9121
		public global::UnityEngine.Vector2[] uv;

		// Token: 0x040023A2 RID: 9122
		public global::UnityEngine.Color32[] color;
	}
}
