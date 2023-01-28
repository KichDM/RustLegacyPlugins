using System;
using UnityEngine;

// Token: 0x020004BD RID: 1213
public static class VisGizmosUtility
{
	// Token: 0x06002A17 RID: 10775 RVA: 0x0009EDFC File Offset: 0x0009CFFC
	static VisGizmosUtility()
	{
		global::VisGizmosUtility.circleVerts = new global::UnityEngine.Vector3[0x1F];
		for (int i = 0; i < 0x1F; i++)
		{
			float num = 0.19634955f * (float)i;
			global::VisGizmosUtility.circleVerts[i].x = global::UnityEngine.Mathf.Cos(num);
			global::VisGizmosUtility.circleVerts[i].y = global::UnityEngine.Mathf.Sin(num);
		}
	}

	// Token: 0x06002A18 RID: 10776 RVA: 0x0009EEE8 File Offset: 0x0009D0E8
	public static void PushMatrix()
	{
		if (global::VisGizmosUtility.stackPos == global::VisGizmosUtility.matStack.Length)
		{
			global::System.Array.Resize<global::UnityEngine.Matrix4x4>(ref global::VisGizmosUtility.matStack, global::VisGizmosUtility.stackPos + 8);
		}
		global::VisGizmosUtility.matStack[global::VisGizmosUtility.stackPos++] = global::UnityEngine.Gizmos.matrix;
	}

	// Token: 0x06002A19 RID: 10777 RVA: 0x0009EF38 File Offset: 0x0009D138
	public static void PushMatrix(global::UnityEngine.Matrix4x4 mat)
	{
		global::VisGizmosUtility.PushMatrix();
		global::UnityEngine.Gizmos.matrix = mat;
	}

	// Token: 0x06002A1A RID: 10778 RVA: 0x0009EF48 File Offset: 0x0009D148
	public static void PushMatrixMul(global::UnityEngine.Matrix4x4 mat)
	{
		global::VisGizmosUtility.PushMatrix();
		global::UnityEngine.Gizmos.matrix = mat * global::VisGizmosUtility.matStack[global::VisGizmosUtility.stackPos - 1];
	}

	// Token: 0x06002A1B RID: 10779 RVA: 0x0009EF7C File Offset: 0x0009D17C
	public static void PushMatrixMul(global::UnityEngine.Matrix4x4 mat, out global::UnityEngine.Matrix4x4 res)
	{
		global::VisGizmosUtility.PushMatrix();
		global::UnityEngine.Gizmos.matrix = (res = mat * global::VisGizmosUtility.matStack[global::VisGizmosUtility.stackPos - 1]);
	}

	// Token: 0x06002A1C RID: 10780 RVA: 0x0009EFB8 File Offset: 0x0009D1B8
	public static void PopMatrix()
	{
		global::UnityEngine.Gizmos.matrix = global::VisGizmosUtility.matStack[--global::VisGizmosUtility.stackPos];
	}

	// Token: 0x06002A1D RID: 10781 RVA: 0x0009EFDC File Offset: 0x0009D1DC
	public static void PopMatrix(out global::UnityEngine.Matrix4x4 mat)
	{
		mat = global::VisGizmosUtility.matStack[--global::VisGizmosUtility.stackPos];
		global::UnityEngine.Gizmos.matrix = mat;
	}

	// Token: 0x06002A1E RID: 10782 RVA: 0x0009F00C File Offset: 0x0009D20C
	public static void ResetMatrixStack()
	{
		global::VisGizmosUtility.stackPos = 0;
	}

	// Token: 0x06002A1F RID: 10783 RVA: 0x0009F014 File Offset: 0x0009D214
	public static void DrawFlatCircle()
	{
		int num = 0x1E;
		int num2 = 0;
		do
		{
			global::UnityEngine.Gizmos.DrawLine(global::VisGizmosUtility.circleVerts[num], global::VisGizmosUtility.circleVerts[num2]);
			num = num2++;
		}
		while (num2 < global::VisGizmosUtility.circleVerts.Length);
	}

	// Token: 0x06002A20 RID: 10784 RVA: 0x0009F060 File Offset: 0x0009D260
	public static void DrawFlatCircle(float radius)
	{
		global::VisGizmosUtility.PushMatrixMul(global::UnityEngine.Matrix4x4.Scale(global::UnityEngine.Vector3.one * radius));
		global::VisGizmosUtility.DrawFlatCircle();
		global::VisGizmosUtility.PopMatrix();
	}

	// Token: 0x06002A21 RID: 10785 RVA: 0x0009F084 File Offset: 0x0009D284
	public static void DrawFlatCapEnd()
	{
		int num = 0x1E;
		int num2 = 0;
		do
		{
			global::UnityEngine.Gizmos.DrawLine(global::VisGizmosUtility.circleVerts[num], global::VisGizmosUtility.circleVerts[num2]);
			num = num2++;
		}
		while (num2 < 0x10);
	}

	// Token: 0x06002A22 RID: 10786 RVA: 0x0009F0CC File Offset: 0x0009D2CC
	public static void DrawFlatCapStart()
	{
		int num = 0;
		int num2 = 0x1E;
		do
		{
			global::UnityEngine.Gizmos.DrawLine(global::VisGizmosUtility.circleVerts[num], global::VisGizmosUtility.circleVerts[num2]);
			num = num2--;
		}
		while (num2 >= 0x10);
	}

	// Token: 0x06002A23 RID: 10787 RVA: 0x0009F114 File Offset: 0x0009D314
	public static void DrawFlatCapsule(float lengthOverRadius)
	{
		global::VisGizmosUtility.DrawFlatCapStart();
		global::UnityEngine.Gizmos.DrawLine(global::VisGizmosUtility.circleVerts[0x10], global::VisGizmosUtility.circleVerts[0x10] + new global::UnityEngine.Vector3(lengthOverRadius, 0f));
		global::VisGizmosUtility.PushMatrix();
		global::UnityEngine.Gizmos.matrix *= global::UnityEngine.Matrix4x4.TRS(new global::UnityEngine.Vector3(lengthOverRadius, 0f, 0f), global::UnityEngine.Quaternion.identity, global::UnityEngine.Vector3.one);
		global::VisGizmosUtility.DrawFlatCapEnd();
		global::UnityEngine.Gizmos.DrawLine(global::VisGizmosUtility.circleVerts[0], global::VisGizmosUtility.circleVerts[0] - new global::UnityEngine.Vector3(lengthOverRadius, 0f));
		global::VisGizmosUtility.PopMatrix();
	}

	// Token: 0x06002A24 RID: 10788 RVA: 0x0009F1D0 File Offset: 0x0009D3D0
	public static void DrawCircle(global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 axis, float radius)
	{
		global::VisGizmosUtility.PushMatrix();
		global::UnityEngine.Gizmos.matrix = global::UnityEngine.Matrix4x4.TRS(origin, global::UnityEngine.Quaternion.LookRotation(axis), new global::UnityEngine.Vector3(radius, radius, 1f)) * global::UnityEngine.Gizmos.matrix;
		global::VisGizmosUtility.DrawFlatCircle();
		global::VisGizmosUtility.PopMatrix();
	}

	// Token: 0x06002A25 RID: 10789 RVA: 0x0009F214 File Offset: 0x0009D414
	private static void MagicForward(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b, out global::UnityEngine.Vector3 up, out global::UnityEngine.Vector3 forward)
	{
		global::UnityEngine.Vector3 vector = a - b;
		vector.Normalize();
		if (vector.y * vector.y > 0.8f)
		{
			up = global::UnityEngine.Vector3.Cross(vector, global::UnityEngine.Vector3.forward);
			forward = global::UnityEngine.Vector3.Cross(vector, up);
		}
		else
		{
			forward = global::UnityEngine.Vector3.Cross(vector, global::UnityEngine.Vector3.up);
			up = global::UnityEngine.Vector3.Cross(vector, forward);
		}
		up.Normalize();
		forward.Normalize();
	}

	// Token: 0x06002A26 RID: 10790 RVA: 0x0009F2A0 File Offset: 0x0009D4A0
	private static global::UnityEngine.Quaternion MagicFlat(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		global::VisGizmosUtility.MagicForward(a, b, out vector, out vector2);
		return global::UnityEngine.Quaternion.LookRotation(vector2, vector);
	}

	// Token: 0x06002A27 RID: 10791 RVA: 0x0009F2C0 File Offset: 0x0009D4C0
	public static void DrawCapsule(global::UnityEngine.Vector3 capA, global::UnityEngine.Vector3 capB, float radius)
	{
		if (radius == 0f)
		{
			global::UnityEngine.Gizmos.DrawLine(capA, capB);
		}
		else
		{
			float num = global::UnityEngine.Vector3.Distance(capA, capB);
			if (num == 0f)
			{
				global::VisGizmosUtility.DrawSphere(capA, radius);
			}
			else
			{
				global::VisGizmosUtility.PushMatrix();
				global::UnityEngine.Matrix4x4 matrix4x = global::UnityEngine.Matrix4x4.TRS(capA, global::VisGizmosUtility.MagicFlat(capA, capB), new global::UnityEngine.Vector3(radius, radius, radius)) * global::UnityEngine.Gizmos.matrix;
				global::UnityEngine.Gizmos.matrix = matrix4x;
				float lengthOverRadius = num / radius;
				global::VisGizmosUtility.DrawFlatCapsule(lengthOverRadius);
				global::UnityEngine.Gizmos.matrix = global::VisGizmosUtility.ninetyZ * matrix4x;
				global::VisGizmosUtility.DrawFlatCapsule(lengthOverRadius);
				global::UnityEngine.Gizmos.matrix = global::VisGizmosUtility.ninetyY * global::UnityEngine.Gizmos.matrix;
				global::VisGizmosUtility.DrawFlatCircle();
				global::UnityEngine.Gizmos.matrix = global::VisGizmosUtility.ninetyY * matrix4x;
				global::VisGizmosUtility.DrawFlatCircle();
				global::VisGizmosUtility.PopMatrix();
			}
		}
	}

	// Token: 0x06002A28 RID: 10792 RVA: 0x0009F384 File Offset: 0x0009D584
	public static void DrawSphere(global::UnityEngine.Vector3 center, float radius, global::UnityEngine.Quaternion rotation)
	{
		global::VisGizmosUtility.PushMatrix();
		global::UnityEngine.Matrix4x4 matrix4x = global::UnityEngine.Matrix4x4.TRS(center, rotation, new global::UnityEngine.Vector3(radius, radius, radius)) * global::UnityEngine.Gizmos.matrix;
		global::UnityEngine.Gizmos.matrix = matrix4x;
		global::VisGizmosUtility.DrawFlatCircle();
		global::UnityEngine.Gizmos.matrix = global::VisGizmosUtility.ninetyX * matrix4x;
		global::VisGizmosUtility.DrawFlatCircle();
		global::UnityEngine.Gizmos.matrix = global::VisGizmosUtility.ninetyY * matrix4x;
		global::VisGizmosUtility.DrawFlatCircle();
		global::VisGizmosUtility.PopMatrix();
	}

	// Token: 0x06002A29 RID: 10793 RVA: 0x0009F3EC File Offset: 0x0009D5EC
	public static void DrawSphere(global::UnityEngine.Vector3 center, float radius, global::UnityEngine.Vector3 forward)
	{
		global::VisGizmosUtility.DrawSphere(center, radius, global::UnityEngine.Quaternion.LookRotation(forward));
	}

	// Token: 0x06002A2A RID: 10794 RVA: 0x0009F3FC File Offset: 0x0009D5FC
	public static void DrawSphere(global::UnityEngine.Vector3 center, float radius)
	{
		global::VisGizmosUtility.DrawSphere(center, radius, global::UnityEngine.Quaternion.identity);
	}

	// Token: 0x06002A2B RID: 10795 RVA: 0x0009F40C File Offset: 0x0009D60C
	public static void DrawCapsule(global::UnityEngine.Vector3 center, float length, float radius, global::UnityEngine.Vector3 heading)
	{
		length = global::UnityEngine.Mathf.Max(length - radius * 2f, 0f);
		if (length == 0f)
		{
			global::VisGizmosUtility.DrawSphere(center, radius, heading);
		}
		heading.Normalize();
		length /= 2f;
		global::VisGizmosUtility.DrawCapsule(center - heading * length, center + heading * length, radius);
	}

	// Token: 0x06002A2C RID: 10796 RVA: 0x0009F474 File Offset: 0x0009D674
	public static void DrawAngle(global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 heading, global::UnityEngine.Vector3 axis, float angle, float radius)
	{
		global::VisGizmosUtility.PushMatrix();
		if (angle < 0f)
		{
			axis = -axis;
			angle = -angle;
		}
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.Cross(axis, heading);
		global::UnityEngine.Gizmos.matrix = global::UnityEngine.Matrix4x4.TRS(origin, global::UnityEngine.Quaternion.LookRotation(axis, vector), new global::UnityEngine.Vector3(radius, radius, 1f)) * global::UnityEngine.Gizmos.matrix;
		global::UnityEngine.Vector3 vector2 = global::UnityEngine.Vector3.zero;
		if (angle == 0f)
		{
			global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, new global::UnityEngine.Vector3(0f, 1f, 0f));
		}
		else if (angle < 360f)
		{
			int num = 0;
			float num2 = 0f;
			global::UnityEngine.Vector3 vector3;
			do
			{
				vector3 = global::VisGizmosUtility.circleVerts[num++];
				global::UnityEngine.Gizmos.DrawLine(vector2, vector3);
				vector2 = vector3;
				num2 += 11.25f;
			}
			while (num2 < angle);
			if (num2 != angle)
			{
				global::UnityEngine.Vector3 vector4 = vector2;
				vector3..ctor(global::UnityEngine.Mathf.Cos(angle * 0.017453292f), global::UnityEngine.Mathf.Sin(angle * 0.017453292f));
				global::UnityEngine.Gizmos.DrawLine(vector4, vector3);
				vector2 = vector3;
			}
			global::UnityEngine.Gizmos.DrawLine(vector2, global::UnityEngine.Vector3.zero);
		}
		global::VisGizmosUtility.PopMatrix();
	}

	// Token: 0x06002A2D RID: 10797 RVA: 0x0009F588 File Offset: 0x0009D788
	public static void DrawDotCone(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 forward, float length, float arc)
	{
		global::VisGizmosUtility.DrawDotCone(position, forward, length, arc, 0f);
	}

	// Token: 0x06002A2E RID: 10798 RVA: 0x0009F598 File Offset: 0x0009D798
	public static void DrawDotCone(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 forward, float length, float arc, float back)
	{
		if (arc == 1f)
		{
			global::UnityEngine.Gizmos.DrawLine(position, position + forward * length);
		}
		else
		{
			float num = global::UnityEngine.Mathf.Ceil(length);
			if (num != 0f)
			{
				float num2 = global::UnityEngine.Mathf.Acos(arc);
				int num3 = global::UnityEngine.Mathf.Abs((int)num);
				float num4 = length / num;
				float num5 = num4 * num2;
				int i;
				float num6;
				float num7;
				if (back == 0f)
				{
					num = num4;
					i = 1;
					num6 = num5;
					num7 = 0f;
				}
				else
				{
					num = 0f;
					i = 0;
					num6 = num2 * back;
					num7 = num6;
				}
				global::UnityEngine.Matrix4x4 matrix4x;
				global::VisGizmosUtility.PushMatrixMul(global::UnityEngine.Matrix4x4.TRS(position, global::UnityEngine.Quaternion.LookRotation(forward), global::UnityEngine.Vector3.one), out matrix4x);
				global::UnityEngine.Vector3 vector;
				vector..ctor(num7, 0f, 0f);
				global::UnityEngine.Vector3 vector2;
				vector2..ctor(num7 + num2 * length, 0f, length);
				global::UnityEngine.Gizmos.DrawLine(vector, vector2);
				vector.x = -vector.x;
				vector2.x = -vector2.x;
				global::UnityEngine.Gizmos.DrawLine(vector, vector2);
				vector.y = vector.x;
				vector.x = 0f;
				vector2.y = vector2.x;
				vector2.x = 0f;
				global::UnityEngine.Gizmos.DrawLine(vector, vector2);
				vector.y = -vector.y;
				vector2.y = -vector2.y;
				global::UnityEngine.Gizmos.DrawLine(vector, vector2);
				while (i <= num3)
				{
					global::UnityEngine.Gizmos.matrix = matrix4x * global::UnityEngine.Matrix4x4.TRS(new global::UnityEngine.Vector3(0f, 0f, num), global::UnityEngine.Quaternion.identity, new global::UnityEngine.Vector3(num6, num6, 1f));
					global::VisGizmosUtility.DrawFlatCircle();
					i++;
					num += num4;
					num6 += num5;
				}
				global::VisGizmosUtility.PopMatrix();
			}
		}
	}

	// Token: 0x06002A2F RID: 10799 RVA: 0x0009F754 File Offset: 0x0009D954
	public static void DrawDotArc(global::UnityEngine.Vector3 position, global::UnityEngine.Transform transform, float length, float arc, float back)
	{
		global::UnityEngine.Vector3 forward = transform.forward;
		global::VisGizmosUtility.DrawDotCone(position, forward, arc * length, arc, back);
		float num = global::UnityEngine.Mathf.Acos(arc) * 57.29578f;
		global::UnityEngine.Vector3 up = transform.up;
		global::UnityEngine.Vector3 right = transform.right;
		global::VisGizmosUtility.DrawAngle(position, forward, up, num, length);
		global::VisGizmosUtility.DrawAngle(position, forward, up, -num, length);
		global::VisGizmosUtility.DrawAngle(position, forward, right, num, length);
		global::VisGizmosUtility.DrawAngle(position, forward, right, -num, length);
	}

	// Token: 0x0400151B RID: 5403
	private const int numCircleVerts = 0x20;

	// Token: 0x0400151C RID: 5404
	private const int lengthCircleVerts = 0x1F;

	// Token: 0x0400151D RID: 5405
	private const float degreePerCircleVert = 11.25f;

	// Token: 0x0400151E RID: 5406
	private const float radPerCircleVert = 0.19634955f;

	// Token: 0x0400151F RID: 5407
	private const int halveCircleIndex = 0x10;

	// Token: 0x04001520 RID: 5408
	private static global::UnityEngine.Matrix4x4[] matStack = new global::UnityEngine.Matrix4x4[8];

	// Token: 0x04001521 RID: 5409
	private static int stackPos = 0;

	// Token: 0x04001522 RID: 5410
	private static global::UnityEngine.Vector3[] circleVerts;

	// Token: 0x04001523 RID: 5411
	private static readonly global::UnityEngine.Matrix4x4 ninetyX = global::UnityEngine.Matrix4x4.TRS(global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.Euler(90f, 0f, 0f), global::UnityEngine.Vector3.one);

	// Token: 0x04001524 RID: 5412
	private static readonly global::UnityEngine.Matrix4x4 ninetyY = global::UnityEngine.Matrix4x4.TRS(global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.Euler(0f, 90f, 0f), global::UnityEngine.Vector3.one);

	// Token: 0x04001525 RID: 5413
	private static readonly global::UnityEngine.Matrix4x4 ninetyZ = global::UnityEngine.Matrix4x4.TRS(global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.Euler(0f, 0f, 90f), global::UnityEngine.Vector3.one);
}
