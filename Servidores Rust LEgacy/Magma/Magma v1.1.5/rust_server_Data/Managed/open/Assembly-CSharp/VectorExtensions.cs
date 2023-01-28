using System;
using UnityEngine;

// Token: 0x0200083B RID: 2107
public static class VectorExtensions
{
	// Token: 0x06004845 RID: 18501 RVA: 0x0010CE6C File Offset: 0x0010B06C
	public static global::UnityEngine.Vector2 Scale(this global::UnityEngine.Vector2 vector, float x, float y)
	{
		return new global::UnityEngine.Vector2(vector.x * x, vector.y * y);
	}

	// Token: 0x06004846 RID: 18502 RVA: 0x0010CE88 File Offset: 0x0010B088
	public static global::UnityEngine.Vector3 Scale(this global::UnityEngine.Vector3 vector, float x, float y, float z)
	{
		return new global::UnityEngine.Vector3(vector.x * x, vector.y * y, vector.z * z);
	}

	// Token: 0x06004847 RID: 18503 RVA: 0x0010CEB8 File Offset: 0x0010B0B8
	public static global::UnityEngine.Vector3 FloorToInt(this global::UnityEngine.Vector3 vector)
	{
		return new global::UnityEngine.Vector3((float)global::UnityEngine.Mathf.FloorToInt(vector.x), (float)global::UnityEngine.Mathf.FloorToInt(vector.y), (float)global::UnityEngine.Mathf.FloorToInt(vector.z));
	}

	// Token: 0x06004848 RID: 18504 RVA: 0x0010CEF4 File Offset: 0x0010B0F4
	public static global::UnityEngine.Vector3 CeilToInt(this global::UnityEngine.Vector3 vector)
	{
		return new global::UnityEngine.Vector3((float)global::UnityEngine.Mathf.CeilToInt(vector.x), (float)global::UnityEngine.Mathf.CeilToInt(vector.y), (float)global::UnityEngine.Mathf.CeilToInt(vector.z));
	}

	// Token: 0x06004849 RID: 18505 RVA: 0x0010CF30 File Offset: 0x0010B130
	public static global::UnityEngine.Vector2 FloorToInt(this global::UnityEngine.Vector2 vector)
	{
		return new global::UnityEngine.Vector2((float)global::UnityEngine.Mathf.FloorToInt(vector.x), (float)global::UnityEngine.Mathf.FloorToInt(vector.y));
	}

	// Token: 0x0600484A RID: 18506 RVA: 0x0010CF54 File Offset: 0x0010B154
	public static global::UnityEngine.Vector2 CeilToInt(this global::UnityEngine.Vector2 vector)
	{
		return new global::UnityEngine.Vector2((float)global::UnityEngine.Mathf.CeilToInt(vector.x), (float)global::UnityEngine.Mathf.CeilToInt(vector.y));
	}

	// Token: 0x0600484B RID: 18507 RVA: 0x0010CF78 File Offset: 0x0010B178
	public static global::UnityEngine.Vector3 RoundToInt(this global::UnityEngine.Vector3 vector)
	{
		return new global::UnityEngine.Vector3((float)global::UnityEngine.Mathf.RoundToInt(vector.x), (float)global::UnityEngine.Mathf.RoundToInt(vector.y), (float)global::UnityEngine.Mathf.RoundToInt(vector.z));
	}

	// Token: 0x0600484C RID: 18508 RVA: 0x0010CFB4 File Offset: 0x0010B1B4
	public static global::UnityEngine.Vector2 RoundToInt(this global::UnityEngine.Vector2 vector)
	{
		return new global::UnityEngine.Vector2((float)global::UnityEngine.Mathf.RoundToInt(vector.x), (float)global::UnityEngine.Mathf.RoundToInt(vector.y));
	}

	// Token: 0x0600484D RID: 18509 RVA: 0x0010CFD8 File Offset: 0x0010B1D8
	public static global::UnityEngine.Vector2 Quantize(this global::UnityEngine.Vector2 vector, float discreteValue)
	{
		vector.x = (float)global::UnityEngine.Mathf.RoundToInt(vector.x / discreteValue) * discreteValue;
		vector.y = (float)global::UnityEngine.Mathf.RoundToInt(vector.y / discreteValue) * discreteValue;
		return vector;
	}

	// Token: 0x0600484E RID: 18510 RVA: 0x0010D00C File Offset: 0x0010B20C
	public static global::UnityEngine.Vector3 Quantize(this global::UnityEngine.Vector3 vector, float discreteValue)
	{
		vector.x = (float)global::UnityEngine.Mathf.RoundToInt(vector.x / discreteValue) * discreteValue;
		vector.y = (float)global::UnityEngine.Mathf.RoundToInt(vector.y / discreteValue) * discreteValue;
		vector.z = (float)global::UnityEngine.Mathf.RoundToInt(vector.z / discreteValue) * discreteValue;
		return vector;
	}
}
