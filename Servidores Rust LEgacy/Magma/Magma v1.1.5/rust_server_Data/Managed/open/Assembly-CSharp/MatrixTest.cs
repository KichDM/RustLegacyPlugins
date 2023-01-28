using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x020007BE RID: 1982
[global::UnityEngine.AddComponentMenu("Precision/Tests/Matrix Test")]
[global::UnityEngine.ExecuteInEditMode]
public class MatrixTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041D1 RID: 16849 RVA: 0x000EDFF4 File Offset: 0x000EC1F4
	public MatrixTest()
	{
	}

	// Token: 0x060041D2 RID: 16850 RVA: 0x000EE014 File Offset: 0x000EC214
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

	// Token: 0x060041D3 RID: 16851 RVA: 0x000EE048 File Offset: 0x000EC248
	private void Update()
	{
		global::UnityEngine.Matrix4x4 matrix4x;
		global::Facepunch.Precision.Matrix4x4G matrix4x4G;
		if (this.transforms != null && this.transforms.Length > 0)
		{
			if (this.revMul)
			{
				int i = this.transforms.Length - 1;
				matrix4x = this.transforms[i].unity;
				matrix4x4G = this.transforms[i].facep;
				for (i--; i >= 0; i--)
				{
					matrix4x = this.transforms[i].unity * matrix4x;
					matrix4x4G = this.MultG(this.transforms[i].facep, matrix4x4G);
				}
			}
			else
			{
				int j = 0;
				matrix4x = this.transforms[j].unity;
				matrix4x4G = this.transforms[j].facep;
				for (j++; j < this.transforms.Length; j++)
				{
					matrix4x *= this.transforms[j].unity;
					matrix4x4G = this.MultG(matrix4x4G, this.transforms[j].facep);
				}
			}
		}
		else
		{
			matrix4x = global::UnityEngine.Matrix4x4.identity;
			matrix4x4G = global::Facepunch.Precision.Matrix4x4G.identity;
		}
		if (this.projection)
		{
			matrix4x = this.projection.UnityMatrix * matrix4x;
			matrix4x4G = this.MultG(this.projection.GMatrix, matrix4x4G);
		}
		this.unity = matrix4x;
		this.facep = matrix4x4G;
	}

	// Token: 0x060041D4 RID: 16852 RVA: 0x000EE198 File Offset: 0x000EC398
	private void Awake()
	{
		this.contents = new global::UnityEngine.GUIContent[2, 4, 4];
		this.rects = new global::UnityEngine.Rect[2, 4, 4];
		float num = 20f;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				float num2 = 20f;
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

	// Token: 0x060041D5 RID: 16853 RVA: 0x000EE254 File Offset: 0x000EC454
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
		if (this.lastUnity != this.unity || this.projection != this.lastProjectionTest)
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					this.contents[num, i, j].text = this.unity[i, j].ToString("0.#####");
				}
			}
			num = 1;
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					this.contents[num, k, l].text = this.facep[k, l].ToString("0.#####");
				}
			}
			this.lastProjectionTest = this.projection;
			this.lastUnity = this.unity;
		}
		global::UnityEngine.GUIStyle textField = global::UnityEngine.GUI.skin.textField;
		for (int m = 0; m < 2; m++)
		{
			for (int n = 0; n < 4; n++)
			{
				for (int num2 = 0; num2 < 4; num2++)
				{
					this.DrawLabel(m, n, num2, textField);
				}
			}
		}
	}

	// Token: 0x060041D6 RID: 16854 RVA: 0x000EE3D4 File Offset: 0x000EC5D4
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

	// Token: 0x060041D7 RID: 16855 RVA: 0x000EE4B8 File Offset: 0x000EC6B8
	private void DrawLabel(int m, int col, int row, global::UnityEngine.GUIStyle style)
	{
		if (this.contents[m, col, row].text != this.contents[(m + 1) % 2, col, row].text)
		{
			global::UnityEngine.GUI.contentColor = this.RCCol(col, row);
		}
		else
		{
			global::UnityEngine.GUI.contentColor = global::UnityEngine.Color.white;
		}
		global::UnityEngine.GUI.Label(this.rects[m, col, row], this.contents[m, col, row], style);
	}

	// Token: 0x0400227F RID: 8831
	private const float cellWidth = 100f;

	// Token: 0x04002280 RID: 8832
	private const float cellHeight = 30f;

	// Token: 0x04002281 RID: 8833
	private const string formatFloat = "0.#####";

	// Token: 0x04002282 RID: 8834
	private global::UnityEngine.GUIContent[,,] contents;

	// Token: 0x04002283 RID: 8835
	private global::UnityEngine.Rect[,,] rects;

	// Token: 0x04002284 RID: 8836
	private global::UnityEngine.Matrix4x4 unity = global::UnityEngine.Matrix4x4.identity;

	// Token: 0x04002285 RID: 8837
	private global::UnityEngine.Matrix4x4 lastUnity;

	// Token: 0x04002286 RID: 8838
	private global::Facepunch.Precision.Matrix4x4G facep = global::Facepunch.Precision.Matrix4x4G.identity;

	// Token: 0x04002287 RID: 8839
	public global::MatrixTest.TRS[] transforms;

	// Token: 0x04002288 RID: 8840
	public bool revMul;

	// Token: 0x04002289 RID: 8841
	public bool revG;

	// Token: 0x0400228A RID: 8842
	public global::ProjectionTest projection;

	// Token: 0x0400228B RID: 8843
	private global::ProjectionTest lastProjectionTest;

	// Token: 0x020007BF RID: 1983
	[global::System.Serializable]
	public class TRS
	{
		// Token: 0x060041D8 RID: 16856 RVA: 0x000EE538 File Offset: 0x000EC738
		public TRS()
		{
			this.S = global::UnityEngine.Vector3.one;
		}

		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x060041D9 RID: 16857 RVA: 0x000EE54C File Offset: 0x000EC74C
		public global::UnityEngine.Quaternion R_unity
		{
			get
			{
				return global::UnityEngine.Quaternion.Euler(this.eulerR);
			}
		}

		// Token: 0x17000C15 RID: 3093
		// (get) Token: 0x060041DA RID: 16858 RVA: 0x000EE55C File Offset: 0x000EC75C
		public global::Facepunch.Precision.QuaternionG R_facep
		{
			get
			{
				global::Facepunch.Precision.Vector3G vector3G;
				vector3G..ctor(this.eulerR);
				global::Facepunch.Precision.QuaternionG result;
				global::Facepunch.Precision.QuaternionG.Euler(ref vector3G, ref result);
				return result;
			}
		}

		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x060041DB RID: 16859 RVA: 0x000EE580 File Offset: 0x000EC780
		public global::UnityEngine.Matrix4x4 unity
		{
			get
			{
				return global::UnityEngine.Matrix4x4.TRS(this.T, this.R_unity, this.S);
			}
		}

		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x060041DC RID: 16860 RVA: 0x000EE59C File Offset: 0x000EC79C
		public global::Facepunch.Precision.Matrix4x4G facep
		{
			get
			{
				global::Facepunch.Precision.Vector3G vector3G;
				vector3G..ctor(this.T);
				global::Facepunch.Precision.QuaternionG r_facep = this.R_facep;
				global::Facepunch.Precision.Vector3G vector3G2;
				vector3G2..ctor(this.S);
				global::Facepunch.Precision.Matrix4x4G result;
				global::Facepunch.Precision.Matrix4x4G.TRS(ref vector3G, ref r_facep, ref vector3G2, ref result);
				return result;
			}
		}

		// Token: 0x0400228C RID: 8844
		public global::UnityEngine.Vector3 T;

		// Token: 0x0400228D RID: 8845
		public global::UnityEngine.Vector3 eulerR;

		// Token: 0x0400228E RID: 8846
		public global::UnityEngine.Vector3 S;
	}
}
