using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x020007C1 RID: 1985
[global::UnityEngine.AddComponentMenu("Precision/Tests/Projection Test")]
[global::UnityEngine.ExecuteInEditMode]
public class ProjectionTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041E0 RID: 16864 RVA: 0x000EE81C File Offset: 0x000ECA1C
	public ProjectionTest()
	{
	}

	// Token: 0x17000C18 RID: 3096
	// (get) Token: 0x060041E1 RID: 16865 RVA: 0x000EE874 File Offset: 0x000ECA74
	public global::UnityEngine.Matrix4x4 UnityMatrix
	{
		get
		{
			return this.unity;
		}
	}

	// Token: 0x17000C19 RID: 3097
	// (get) Token: 0x060041E2 RID: 16866 RVA: 0x000EE87C File Offset: 0x000ECA7C
	public global::Facepunch.Precision.Matrix4x4G GMatrix
	{
		get
		{
			return this.facep;
		}
	}

	// Token: 0x17000C1A RID: 3098
	// (get) Token: 0x060041E3 RID: 16867 RVA: 0x000EE884 File Offset: 0x000ECA84
	public global::UnityEngine.Matrix4x4 UnityMatrixCasted
	{
		get
		{
			return this.unity2;
		}
	}

	// Token: 0x060041E4 RID: 16868 RVA: 0x000EE88C File Offset: 0x000ECA8C
	private global::Facepunch.Precision.Matrix4x4G MultG(global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		global::Facepunch.Precision.Matrix4x4G result;
		if (this.revG)
		{
			global::Facepunch.Precision.Matrix4x4G.Mult(ref b, ref a, ref result);
		}
		else
		{
			global::Facepunch.Precision.Matrix4x4G.Mult(ref a, ref b, ref result);
		}
		return result;
	}

	// Token: 0x060041E5 RID: 16869 RVA: 0x000EE8C0 File Offset: 0x000ECAC0
	private void Update()
	{
		double num = (this.aspect <= 0f) ? ((double)global::UnityEngine.Screen.height / (double)global::UnityEngine.Screen.width) : ((double)this.aspect);
		this.unity = global::UnityEngine.Matrix4x4.Perspective(this.fov, (float)num, this.near, this.far);
		double num2 = (double)this.fov;
		double num3 = (double)this.near;
		double num4 = (double)this.far;
		global::Facepunch.Precision.Matrix4x4G.Perspective(ref num2, ref num, ref num3, ref num4, ref this.facep);
		this.unity2 = this.facep.f;
	}

	// Token: 0x060041E6 RID: 16870 RVA: 0x000EE954 File Offset: 0x000ECB54
	private void Awake()
	{
		this.contents = new global::UnityEngine.GUIContent[3, 4, 4];
		this.rects = new global::UnityEngine.Rect[3, 4, 4];
		float num = 20f;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				float num2 = 600f;
				for (int k = 0; k < 4; k++)
				{
					this.contents[i, j, k] = new global::UnityEngine.GUIContent();
					this.rects[i, j, k] = new global::UnityEngine.Rect(num2, num, 100f, 30f);
					num2 += 102f;
				}
				num += 32f;
			}
			num += 10f;
		}
	}

	// Token: 0x060041E7 RID: 16871 RVA: 0x000EEA10 File Offset: 0x000ECC10
	private void OnGUI()
	{
		if (global::UnityEngine.Event.current.type != 7)
		{
			return;
		}
		if (this.contents == null)
		{
			this.Awake();
		}
		if (this.lastUnity != this.unity)
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					this.contents[num, i, j].text = this.unity[i, j].ToString();
				}
			}
			num = 1;
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					this.contents[num, k, l].text = this.facep[k, l].ToString();
				}
			}
			num = 2;
			for (int m = 0; m < 4; m++)
			{
				for (int n = 0; n < 4; n++)
				{
					this.contents[num, m, n].text = this.unity2[m, n].ToString();
				}
			}
			this.lastUnity = this.unity;
		}
		global::UnityEngine.GUIStyle textField = global::UnityEngine.GUI.skin.textField;
		for (int num2 = 0; num2 < 3; num2++)
		{
			for (int num3 = 0; num3 < 4; num3++)
			{
				for (int num4 = 0; num4 < 4; num4++)
				{
					this.DrawLabel(num2, num3, num4, textField);
				}
			}
		}
	}

	// Token: 0x060041E8 RID: 16872 RVA: 0x000EEBBC File Offset: 0x000ECDBC
	private global::UnityEngine.Color RCCol(int col, int row)
	{
		global::UnityEngine.Color result;
		switch (row | col % 2 << 2)
		{
		case 0:
			result = global::UnityEngine.Color.red;
			break;
		case 1:
			result = global::UnityEngine.Color.green;
			break;
		case 2:
			result = global::UnityEngine.Color.blue;
			break;
		case 3:
			result = global::UnityEngine.Color.magenta;
			break;
		case 4:
			result = global::UnityEngine.Color.cyan;
			break;
		case 5:
			result = global::UnityEngine.Color.yellow;
			break;
		case 6:
			result = global::UnityEngine.Color.gray;
			break;
		case 7:
			result = global::UnityEngine.Color.black;
			break;
		default:
			result = global::UnityEngine.Color.clear;
			break;
		}
		if (col >= 2)
		{
			result.r += 0.25f;
			result.g += 0.25f;
			result.b += 0.25f;
		}
		return result;
	}

	// Token: 0x060041E9 RID: 16873 RVA: 0x000EECA0 File Offset: 0x000ECEA0
	private void DrawLabel(int m, int col, int row, global::UnityEngine.GUIStyle style)
	{
		if (this.contents[m, col, row].text != this.contents[0, col, row].text)
		{
			global::UnityEngine.GUI.contentColor = this.RCCol(col, row);
		}
		else
		{
			global::UnityEngine.GUI.contentColor = global::UnityEngine.Color.white;
		}
		global::UnityEngine.GUI.Label(this.rects[m, col, row], this.contents[m, col, row], style);
	}

	// Token: 0x04002294 RID: 8852
	private const float cellWidth = 100f;

	// Token: 0x04002295 RID: 8853
	private const float cellHeight = 30f;

	// Token: 0x04002296 RID: 8854
	private global::UnityEngine.GUIContent[,,] contents;

	// Token: 0x04002297 RID: 8855
	private global::UnityEngine.Rect[,,] rects;

	// Token: 0x04002298 RID: 8856
	private global::UnityEngine.Matrix4x4 unity = global::UnityEngine.Matrix4x4.identity;

	// Token: 0x04002299 RID: 8857
	private global::UnityEngine.Matrix4x4 lastUnity;

	// Token: 0x0400229A RID: 8858
	private global::Facepunch.Precision.Matrix4x4G facep = global::Facepunch.Precision.Matrix4x4G.identity;

	// Token: 0x0400229B RID: 8859
	private global::UnityEngine.Matrix4x4 unity2;

	// Token: 0x0400229C RID: 8860
	public float near = 1f;

	// Token: 0x0400229D RID: 8861
	public float aspect = -1f;

	// Token: 0x0400229E RID: 8862
	public float far = 1000f;

	// Token: 0x0400229F RID: 8863
	public float fov = 60f;

	// Token: 0x040022A0 RID: 8864
	public bool revMul;

	// Token: 0x040022A1 RID: 8865
	public bool revG;
}
