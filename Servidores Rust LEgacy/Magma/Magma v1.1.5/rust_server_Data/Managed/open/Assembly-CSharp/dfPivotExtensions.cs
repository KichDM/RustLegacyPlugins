using System;
using UnityEngine;

// Token: 0x020007F6 RID: 2038
public static class dfPivotExtensions
{
	// Token: 0x0600441F RID: 17439 RVA: 0x000F90CC File Offset: 0x000F72CC
	public static global::UnityEngine.Vector3 TransformToCenter(this global::dfPivotPoint pivot, global::UnityEngine.Vector2 size)
	{
		switch (pivot)
		{
		case global::dfPivotPoint.TopLeft:
			return new global::UnityEngine.Vector2(0.5f * size.x, 0.5f * -size.y);
		case global::dfPivotPoint.TopCenter:
			return new global::UnityEngine.Vector2(0f, 0.5f * -size.y);
		case global::dfPivotPoint.TopRight:
			return new global::UnityEngine.Vector2(0.5f * -size.x, 0.5f * -size.y);
		case global::dfPivotPoint.MiddleLeft:
			return new global::UnityEngine.Vector2(0.5f * size.x, 0f);
		case global::dfPivotPoint.MiddleCenter:
			return new global::UnityEngine.Vector2(0f, 0f);
		case global::dfPivotPoint.MiddleRight:
			return new global::UnityEngine.Vector2(0.5f * -size.x, 0f);
		case global::dfPivotPoint.BottomLeft:
			return new global::UnityEngine.Vector2(0.5f * size.x, 0.5f * size.y);
		case global::dfPivotPoint.BottomCenter:
			return new global::UnityEngine.Vector2(0f, 0.5f * size.y);
		case global::dfPivotPoint.BottomRight:
			return new global::UnityEngine.Vector2(0.5f * -size.x, 0.5f * size.y);
		default:
			throw new global::System.Exception(string.Concat(new object[]
			{
				"Unhandled ",
				pivot.GetType().Name,
				" value: ",
				pivot
			}));
		}
	}

	// Token: 0x06004420 RID: 17440 RVA: 0x000F926C File Offset: 0x000F746C
	public static global::UnityEngine.Vector3 UpperLeftToTransform(this global::dfPivotPoint pivot, global::UnityEngine.Vector2 size)
	{
		return pivot.TransformToUpperLeft(size).Scale(-1f, -1f, 1f);
	}

	// Token: 0x06004421 RID: 17441 RVA: 0x000F928C File Offset: 0x000F748C
	public static global::UnityEngine.Vector3 TransformToUpperLeft(this global::dfPivotPoint pivot, global::UnityEngine.Vector2 size)
	{
		switch (pivot)
		{
		case global::dfPivotPoint.TopLeft:
			return new global::UnityEngine.Vector2(0f, 0f);
		case global::dfPivotPoint.TopCenter:
			return new global::UnityEngine.Vector2(0.5f * -size.x, 0f);
		case global::dfPivotPoint.TopRight:
			return new global::UnityEngine.Vector2(-size.x, 0f);
		case global::dfPivotPoint.MiddleLeft:
			return new global::UnityEngine.Vector2(0f, 0.5f * size.y);
		case global::dfPivotPoint.MiddleCenter:
			return new global::UnityEngine.Vector2(0.5f * -size.x, 0.5f * size.y);
		case global::dfPivotPoint.MiddleRight:
			return new global::UnityEngine.Vector2(-size.x, 0.5f * size.y);
		case global::dfPivotPoint.BottomLeft:
			return new global::UnityEngine.Vector2(0f, size.y);
		case global::dfPivotPoint.BottomCenter:
			return new global::UnityEngine.Vector2(0.5f * -size.x, size.y);
		case global::dfPivotPoint.BottomRight:
			return new global::UnityEngine.Vector2(-size.x, size.y);
		default:
			throw new global::System.Exception(string.Concat(new object[]
			{
				"Unhandled ",
				pivot.GetType().Name,
				" value: ",
				pivot
			}));
		}
	}
}
