using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x020007C2 RID: 1986
[global::UnityEngine.AddComponentMenu("Precision/Tests/Quaternion Test")]
[global::UnityEngine.ExecuteInEditMode]
public class QuaternionTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041EA RID: 16874 RVA: 0x000EED1C File Offset: 0x000ECF1C
	public QuaternionTest()
	{
	}

	// Token: 0x060041EB RID: 16875 RVA: 0x000EED3C File Offset: 0x000ECF3C
	private void Update()
	{
		if (this.R == null || this.R.Length == 0)
		{
			this.unity = global::UnityEngine.Quaternion.identity;
			this.facep = global::Facepunch.Precision.QuaternionG.identity;
		}
		else if (this.revMul)
		{
			int i = this.R.Length - 1;
			this.unity = global::UnityEngine.Quaternion.Euler(this.R[i]);
			global::Facepunch.Precision.Vector3G vector3G;
			vector3G..ctor(this.R[i]);
			global::Facepunch.Precision.QuaternionG.Euler(ref vector3G, ref this.facep);
			for (i--; i >= 0; i--)
			{
				this.unity = global::UnityEngine.Quaternion.Euler(this.R[i]) * this.unity;
				vector3G.f = this.R[i];
				global::Facepunch.Precision.QuaternionG quaternionG;
				global::Facepunch.Precision.QuaternionG.Euler(ref vector3G, ref quaternionG);
				global::Facepunch.Precision.QuaternionG.Mult(ref quaternionG, ref this.facep, ref this.facep);
			}
		}
		else
		{
			int j = 0;
			this.unity = global::UnityEngine.Quaternion.Euler(this.R[j]);
			global::Facepunch.Precision.Vector3G vector3G2;
			vector3G2..ctor(this.R[j]);
			global::Facepunch.Precision.QuaternionG.Euler(ref vector3G2, ref this.facep);
			for (j++; j < this.R.Length; j++)
			{
				this.unity *= global::UnityEngine.Quaternion.Euler(this.R[j]);
				vector3G2.f = this.R[j];
				global::Facepunch.Precision.QuaternionG quaternionG2;
				global::Facepunch.Precision.QuaternionG.Euler(ref vector3G2, ref quaternionG2);
				global::Facepunch.Precision.QuaternionG quaternionG3 = this.facep;
				global::Facepunch.Precision.QuaternionG.Mult(ref quaternionG3, ref quaternionG2, ref this.facep);
			}
		}
	}

	// Token: 0x060041EC RID: 16876 RVA: 0x000EEF04 File Offset: 0x000ED104
	private void Awake()
	{
		this.contents = new global::UnityEngine.GUIContent[3, 4];
		this.rects = new global::UnityEngine.Rect[3, 4];
		float num = 400f;
		for (int i = 0; i < 3; i++)
		{
			float num2 = 20f;
			for (int j = 0; j < 4; j++)
			{
				this.contents[i, j] = new global::UnityEngine.GUIContent();
				this.rects[i, j] = new global::UnityEngine.Rect(num2, num, 100f, 30f);
				num2 += 102f;
			}
			num += 32f;
		}
		this.contents[2, 0].text = "Degrees:";
	}

	// Token: 0x060041ED RID: 16877 RVA: 0x000EEFB4 File Offset: 0x000ED1B4
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
		if (this.lastUnity != this.unity || this.nonHomogenous != this.nonHomogenousWas)
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				this.contents[num, i].text = this.unity[i].ToString("0.######");
			}
			num = 1;
			for (int j = 0; j < 4; j++)
			{
				this.contents[num, j].text = this.facep[j].ToString("0.######");
			}
			num = 2;
			global::Facepunch.Precision.Vector3G vector3G;
			if (this.nonHomogenous)
			{
				global::Facepunch.Precision.QuaternionG.ToEulerNonHomogenious(ref this.facep, ref vector3G);
			}
			else
			{
				global::Facepunch.Precision.QuaternionG.ToEuler(ref this.facep, ref vector3G);
			}
			for (int k = 1; k < 4; k++)
			{
				this.contents[num, k].text = vector3G[k - 1].ToString("0.######");
			}
			this.nonHomogenousWas = this.nonHomogenous;
			this.lastUnity = this.unity;
		}
		global::UnityEngine.GUIStyle textField = global::UnityEngine.GUI.skin.textField;
		for (int l = 0; l < 3; l++)
		{
			for (int m = 0; m < 4; m++)
			{
				global::UnityEngine.GUI.Label(this.rects[l, m], this.contents[l, m], textField);
			}
		}
	}

	// Token: 0x040022A2 RID: 8866
	private const float cellWidth = 100f;

	// Token: 0x040022A3 RID: 8867
	private const float cellHeight = 30f;

	// Token: 0x040022A4 RID: 8868
	private const string formatFloat = "0.######";

	// Token: 0x040022A5 RID: 8869
	private global::UnityEngine.GUIContent[,] contents;

	// Token: 0x040022A6 RID: 8870
	private global::UnityEngine.Rect[,] rects;

	// Token: 0x040022A7 RID: 8871
	private global::UnityEngine.Quaternion unity = global::UnityEngine.Quaternion.identity;

	// Token: 0x040022A8 RID: 8872
	private global::UnityEngine.Quaternion lastUnity;

	// Token: 0x040022A9 RID: 8873
	private global::Facepunch.Precision.QuaternionG facep = global::Facepunch.Precision.QuaternionG.identity;

	// Token: 0x040022AA RID: 8874
	public global::UnityEngine.Vector3[] R;

	// Token: 0x040022AB RID: 8875
	public bool revMul;

	// Token: 0x040022AC RID: 8876
	public bool nonHomogenous;

	// Token: 0x040022AD RID: 8877
	private bool nonHomogenousWas;
}
