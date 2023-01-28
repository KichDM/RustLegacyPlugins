using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public static class Gizmos2
{
	// Token: 0x1700099E RID: 2462
	// (get) Token: 0x06002BCA RID: 11210 RVA: 0x000A42A0 File Offset: 0x000A24A0
	// (set) Token: 0x06002BCB RID: 11211 RVA: 0x000A42A8 File Offset: 0x000A24A8
	public static global::UnityEngine.Color color
	{
		get
		{
			return global::UnityEngine.Gizmos.color;
		}
		set
		{
			global::UnityEngine.Gizmos.color = value;
		}
	}

	// Token: 0x1700099F RID: 2463
	// (get) Token: 0x06002BCC RID: 11212 RVA: 0x000A42B0 File Offset: 0x000A24B0
	// (set) Token: 0x06002BCD RID: 11213 RVA: 0x000A42B8 File Offset: 0x000A24B8
	public static global::UnityEngine.Matrix4x4 matrix
	{
		get
		{
			return global::UnityEngine.Gizmos.matrix;
		}
		set
		{
			global::UnityEngine.Gizmos.matrix = value;
		}
	}

	// Token: 0x06002BCE RID: 11214 RVA: 0x000A42C0 File Offset: 0x000A24C0
	public static void DrawRay(global::UnityEngine.Ray r)
	{
		global::UnityEngine.Gizmos.DrawRay(r);
	}

	// Token: 0x06002BCF RID: 11215 RVA: 0x000A42C8 File Offset: 0x000A24C8
	public static void DrawRay(global::UnityEngine.Vector3 from, global::UnityEngine.Vector3 direction)
	{
		global::UnityEngine.Gizmos.DrawRay(from, direction);
	}

	// Token: 0x06002BD0 RID: 11216 RVA: 0x000A42D4 File Offset: 0x000A24D4
	public static void DrawLine(global::UnityEngine.Vector3 from, global::UnityEngine.Vector3 to)
	{
		global::UnityEngine.Gizmos.DrawLine(from, to);
	}

	// Token: 0x06002BD1 RID: 11217 RVA: 0x000A42E0 File Offset: 0x000A24E0
	public static void DrawWireSphere(global::UnityEngine.Vector3 center, float radius)
	{
		global::UnityEngine.Gizmos.DrawWireSphere(center, radius);
	}

	// Token: 0x06002BD2 RID: 11218 RVA: 0x000A42EC File Offset: 0x000A24EC
	public static void DrawSphere(global::UnityEngine.Vector3 center, float radius)
	{
		global::UnityEngine.Gizmos.DrawSphere(center, radius);
	}

	// Token: 0x06002BD3 RID: 11219 RVA: 0x000A42F8 File Offset: 0x000A24F8
	public static void DrawWireCube(global::UnityEngine.Vector3 center, global::UnityEngine.Vector3 size)
	{
		global::UnityEngine.Gizmos.DrawWireCube(center, size);
	}

	// Token: 0x06002BD4 RID: 11220 RVA: 0x000A4304 File Offset: 0x000A2504
	public static void DrawCube(global::UnityEngine.Vector3 center, global::UnityEngine.Vector3 size)
	{
		global::UnityEngine.Gizmos.DrawCube(center, size);
	}

	// Token: 0x06002BD5 RID: 11221 RVA: 0x000A4310 File Offset: 0x000A2510
	public static void DrawIcon(global::UnityEngine.Vector3 center, string name, bool allowScaling)
	{
		global::UnityEngine.Gizmos.DrawIcon(center, name, allowScaling);
	}

	// Token: 0x06002BD6 RID: 11222 RVA: 0x000A431C File Offset: 0x000A251C
	public static void DrawIcon(global::UnityEngine.Vector3 center, string name)
	{
		global::UnityEngine.Gizmos.DrawIcon(center, name);
	}

	// Token: 0x06002BD7 RID: 11223 RVA: 0x000A4328 File Offset: 0x000A2528
	public static void DrawGUITexture(global::UnityEngine.Rect screenRect, global::UnityEngine.Texture texture)
	{
		global::UnityEngine.Gizmos.DrawGUITexture(screenRect, texture);
	}

	// Token: 0x06002BD8 RID: 11224 RVA: 0x000A4334 File Offset: 0x000A2534
	public static void DrawGUITexture(global::UnityEngine.Rect screenRect, global::UnityEngine.Texture texture, global::UnityEngine.Material mat)
	{
		global::UnityEngine.Gizmos.DrawGUITexture(screenRect, texture, mat);
	}

	// Token: 0x06002BD9 RID: 11225 RVA: 0x000A4340 File Offset: 0x000A2540
	public static void DrawGUITexture(global::UnityEngine.Rect screenRect, global::UnityEngine.Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, global::UnityEngine.Material mat)
	{
		global::Gizmos2.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat);
	}

	// Token: 0x06002BDA RID: 11226 RVA: 0x000A4354 File Offset: 0x000A2554
	public static void DrawGUITexture(global::UnityEngine.Rect screenRect, global::UnityEngine.Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
	{
		global::Gizmos2.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder);
	}

	// Token: 0x06002BDB RID: 11227 RVA: 0x000A4364 File Offset: 0x000A2564
	public static void DrawFrustum(global::UnityEngine.Vector3 center, float fov, float maxRange, float minRange, float aspect)
	{
		global::UnityEngine.Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect);
	}

	// Token: 0x06002BDC RID: 11228 RVA: 0x000A4374 File Offset: 0x000A2574
	public static void DrawWireCapsule(global::UnityEngine.Vector3 center, float radius, float height, int axis)
	{
		int num = axis % 3;
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		global::UnityEngine.Vector3 vector3;
		switch (num + 2)
		{
		case 0:
		case 3:
			vector = global::UnityEngine.Vector3.up;
			vector2 = global::UnityEngine.Vector3.forward;
			vector3 = global::UnityEngine.Vector3.right;
			break;
		case 1:
		case 4:
			vector = global::UnityEngine.Vector3.forward;
			vector2 = global::UnityEngine.Vector3.right;
			vector3 = global::UnityEngine.Vector3.up;
			break;
		case 2:
			vector = global::UnityEngine.Vector3.right;
			vector2 = global::UnityEngine.Vector3.up;
			vector3 = global::UnityEngine.Vector3.forward;
			break;
		default:
			return;
		}
		global::UnityEngine.Vector3 vector4 = global::UnityEngine.Vector3.one - vector2 * 2f;
		global::UnityEngine.Vector3 vector5 = global::UnityEngine.Vector3.one - vector3 * 2f;
		if (radius * 2f >= height)
		{
			global::UnityEngine.Gizmos.DrawWireSphere(center, radius);
		}
		else
		{
			global::UnityEngine.Vector3 vector6 = center + vector * ((height - radius * 2f) / 2f);
			global::UnityEngine.Vector3 vector7 = center - vector * ((height - radius * 2f) / 2f);
			global::UnityEngine.Gizmos.DrawLine(vector6 + vector2 * radius, vector7 + vector2 * radius);
			global::UnityEngine.Gizmos.DrawLine(vector6 + vector3 * radius, vector7 + vector3 * radius);
			global::UnityEngine.Gizmos.DrawLine(vector6 - vector2 * radius, vector7 - vector2 * radius);
			global::UnityEngine.Gizmos.DrawLine(vector6 - vector3 * radius, vector7 - vector3 * radius);
			for (int i = 0; i < 6; i++)
			{
				float num2 = (float)i / 12f * 3.1415927f;
				float num3 = ((float)i + 1f) / 12f * 3.1415927f;
				float num4 = global::UnityEngine.Mathf.Cos(num2) * radius;
				float num5 = global::UnityEngine.Mathf.Sin(num2) * radius;
				float num6 = global::UnityEngine.Mathf.Cos(num3) * radius;
				float num7 = global::UnityEngine.Mathf.Sin(num3) * radius;
				global::UnityEngine.Vector3 vector8 = vector * num5 + vector2 * num4;
				global::UnityEngine.Vector3 vector9 = vector * num7 + vector2 * num6;
				global::UnityEngine.Vector3 vector10 = vector * num5 + vector3 * num4;
				global::UnityEngine.Vector3 vector11 = vector * num7 + vector3 * num6;
				global::UnityEngine.Vector3 vector12 = vector2 * num5 + vector3 * num4;
				global::UnityEngine.Vector3 vector13 = vector2 * num7 + vector3 * num6;
				global::UnityEngine.Gizmos.DrawLine(vector6 + vector8, vector6 + vector9);
				global::UnityEngine.Gizmos.DrawLine(vector6 + vector10, vector6 + vector11);
				global::UnityEngine.Gizmos.DrawLine(vector7 - vector8, vector7 - vector9);
				global::UnityEngine.Gizmos.DrawLine(vector7 - vector10, vector7 - vector11);
				global::UnityEngine.Gizmos.DrawLine(vector6 + vector12, vector6 + vector13);
				global::UnityEngine.Gizmos.DrawLine(vector6 - vector12, vector6 - vector13);
				global::UnityEngine.Gizmos.DrawLine(vector7 + vector12, vector7 + vector13);
				global::UnityEngine.Gizmos.DrawLine(vector7 - vector12, vector7 - vector13);
				vector8 = global::UnityEngine.Vector3.Scale(vector8, vector4);
				vector9 = global::UnityEngine.Vector3.Scale(vector9, vector4);
				vector10 = global::UnityEngine.Vector3.Scale(vector10, vector5);
				vector11 = global::UnityEngine.Vector3.Scale(vector11, vector5);
				vector12 = global::UnityEngine.Vector3.Scale(vector12, vector4);
				vector13 = global::UnityEngine.Vector3.Scale(vector13, vector4);
				global::UnityEngine.Gizmos.DrawLine(vector6 + vector8, vector6 + vector9);
				global::UnityEngine.Gizmos.DrawLine(vector6 + vector10, vector6 + vector11);
				global::UnityEngine.Gizmos.DrawLine(vector7 - vector8, vector7 - vector9);
				global::UnityEngine.Gizmos.DrawLine(vector7 - vector10, vector7 - vector11);
				global::UnityEngine.Gizmos.DrawLine(vector6 + vector12, vector6 + vector13);
				global::UnityEngine.Gizmos.DrawLine(vector6 - vector12, vector6 - vector13);
				global::UnityEngine.Gizmos.DrawLine(vector7 + vector12, vector7 + vector13);
				global::UnityEngine.Gizmos.DrawLine(vector7 - vector12, vector7 - vector13);
			}
		}
	}
}
