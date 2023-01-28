using System;
using UnityEngine;

// Token: 0x0200083C RID: 2108
public static class RectExtensions
{
	// Token: 0x0600484F RID: 18511 RVA: 0x0010D064 File Offset: 0x0010B264
	public static global::UnityEngine.RectOffset ConstrainPadding(this global::UnityEngine.RectOffset borders)
	{
		if (borders == null)
		{
			return new global::UnityEngine.RectOffset();
		}
		borders.left = global::UnityEngine.Mathf.Max(0, borders.left);
		borders.right = global::UnityEngine.Mathf.Max(0, borders.right);
		borders.top = global::UnityEngine.Mathf.Max(0, borders.top);
		borders.bottom = global::UnityEngine.Mathf.Max(0, borders.bottom);
		return borders;
	}

	// Token: 0x06004850 RID: 18512 RVA: 0x0010D0C8 File Offset: 0x0010B2C8
	public static bool IsEmpty(this global::UnityEngine.Rect rect)
	{
		return rect.xMin == rect.xMax || rect.yMin == rect.yMax;
	}

	// Token: 0x06004851 RID: 18513 RVA: 0x0010D0FC File Offset: 0x0010B2FC
	public static global::UnityEngine.Rect Intersection(this global::UnityEngine.Rect a, global::UnityEngine.Rect b)
	{
		if (!a.Intersects(b))
		{
			return default(global::UnityEngine.Rect);
		}
		float num = global::UnityEngine.Mathf.Max(a.xMin, b.xMin);
		float num2 = global::UnityEngine.Mathf.Min(a.xMax, b.xMax);
		float num3 = global::UnityEngine.Mathf.Max(a.yMin, b.yMin);
		float num4 = global::UnityEngine.Mathf.Min(a.yMax, b.yMax);
		return global::UnityEngine.Rect.MinMaxRect(num, num4, num2, num3);
	}

	// Token: 0x06004852 RID: 18514 RVA: 0x0010D17C File Offset: 0x0010B37C
	public static global::UnityEngine.Rect Union(this global::UnityEngine.Rect a, global::UnityEngine.Rect b)
	{
		float num = global::UnityEngine.Mathf.Min(a.xMin, b.xMin);
		float num2 = global::UnityEngine.Mathf.Max(a.xMax, b.xMax);
		float num3 = global::UnityEngine.Mathf.Min(a.yMin, b.yMin);
		float num4 = global::UnityEngine.Mathf.Max(a.yMax, b.yMax);
		return global::UnityEngine.Rect.MinMaxRect(num, num3, num2, num4);
	}

	// Token: 0x06004853 RID: 18515 RVA: 0x0010D1E4 File Offset: 0x0010B3E4
	public static bool Contains(this global::UnityEngine.Rect rect, global::UnityEngine.Rect other)
	{
		bool flag = rect.x <= other.x;
		bool flag2 = rect.x + rect.width >= other.x + other.width;
		bool flag3 = rect.yMin <= other.yMin;
		bool flag4 = rect.y + rect.height >= other.y + other.height;
		return flag && flag2 && flag3 && flag4;
	}

	// Token: 0x06004854 RID: 18516 RVA: 0x0010D278 File Offset: 0x0010B478
	public static bool Intersects(this global::UnityEngine.Rect rect, global::UnityEngine.Rect other)
	{
		bool flag = rect.xMax < other.xMin || rect.yMax < other.xMin || rect.xMin > other.xMax || rect.yMin > other.yMax;
		return !flag;
	}

	// Token: 0x06004855 RID: 18517 RVA: 0x0010D2D8 File Offset: 0x0010B4D8
	public static global::UnityEngine.Rect RoundToInt(this global::UnityEngine.Rect rect)
	{
		return new global::UnityEngine.Rect((float)global::UnityEngine.Mathf.RoundToInt(rect.x), (float)global::UnityEngine.Mathf.RoundToInt(rect.y), (float)global::UnityEngine.Mathf.RoundToInt(rect.width), (float)global::UnityEngine.Mathf.RoundToInt(rect.height));
	}

	// Token: 0x06004856 RID: 18518 RVA: 0x0010D320 File Offset: 0x0010B520
	public static string Debug(this global::UnityEngine.Rect rect)
	{
		return string.Format("[{0},{1},{2},{3}]", new object[]
		{
			rect.xMin,
			rect.yMin,
			rect.xMax,
			rect.yMax
		});
	}
}
