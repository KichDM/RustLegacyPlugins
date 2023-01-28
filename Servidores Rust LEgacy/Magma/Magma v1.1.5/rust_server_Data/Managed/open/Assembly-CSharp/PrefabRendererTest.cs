using System;
using System.Text;
using UnityEngine;

// Token: 0x02000773 RID: 1907
[global::UnityEngine.ExecuteInEditMode]
public class PrefabRendererTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003F45 RID: 16197 RVA: 0x000E1DA8 File Offset: 0x000DFFA8
	public PrefabRendererTest()
	{
	}

	// Token: 0x06003F46 RID: 16198 RVA: 0x000E1DB0 File Offset: 0x000DFFB0
	[global::UnityEngine.ContextMenu("Refresh")]
	private void RefreshRenderer()
	{
		if (this.renderer != null)
		{
			this.renderer.Refresh();
		}
	}

	// Token: 0x06003F47 RID: 16199 RVA: 0x000E1DC8 File Offset: 0x000DFFC8
	[global::UnityEngine.ContextMenu("Print info")]
	private void PrintINfo()
	{
		if (this.renderer == null)
		{
			global::UnityEngine.Debug.Log("No Renderer", this);
		}
		else
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			foreach (global::UnityEngine.Material material in this.renderer.GetMaterialArrayCopy())
			{
				stringBuilder.AppendLine(material.ToString());
			}
			global::UnityEngine.Debug.Log(stringBuilder, this);
		}
	}

	// Token: 0x06003F48 RID: 16200 RVA: 0x000E1E30 File Offset: 0x000E0030
	[global::UnityEngine.ContextMenu("List Materials")]
	private void ListMaterials()
	{
		if (this.renderer == null)
		{
			return;
		}
		int materialCount = this.renderer.materialCount;
		for (int i = 0; i < materialCount; i++)
		{
			global::UnityEngine.Debug.Log(this.renderer.GetMaterial(i), this.renderer.GetMaterial(i));
		}
	}

	// Token: 0x06003F49 RID: 16201 RVA: 0x000E1E84 File Offset: 0x000E0084
	[global::UnityEngine.ContextMenu("Refresh material overrides")]
	private void ApplyOverrides()
	{
		if (this.renderer == null)
		{
			return;
		}
		this.overrideMaterials = this.renderer.GetMaterialArrayCopy();
		if (this.overrideMaterials.Length == 0 || this.materialKeys == null || this.materialValues == null)
		{
			return;
		}
		int num = global::UnityEngine.Mathf.Min(this.overrideMaterials.Length, global::UnityEngine.Mathf.Min(this.materialKeys.Length, this.materialValues.Length));
		for (int i = 0; i < num; i++)
		{
			int num2 = global::System.Array.IndexOf<global::UnityEngine.Material>(this.materialKeys, this.overrideMaterials[i]);
			if (num2 != -1 && num2 < this.materialValues.Length)
			{
				this.overrideMaterials[i] = this.materialValues[num2];
			}
		}
	}

	// Token: 0x06003F4A RID: 16202 RVA: 0x000E1F48 File Offset: 0x000E0148
	private void Update()
	{
		if (this.prefabRendering != this.prefab || !this.oi)
		{
			if (this.prefabRendering)
			{
				this.renderer = null;
			}
			if (this.prefab)
			{
				this.renderer = global::PrefabRenderer.GetOrCreateRender(this.prefab);
			}
			this.prefabRendering = this.prefab;
			this.oi = true;
			this.ApplyOverrides();
		}
		if (this.renderer == null)
		{
			global::UnityEngine.Debug.Log("None", this);
			return;
		}
		this.renderer.Render(null, base.transform.localToWorldMatrix, null, this.overrideMaterials);
	}

	// Token: 0x0400209C RID: 8348
	public global::UnityEngine.GameObject prefab;

	// Token: 0x0400209D RID: 8349
	public global::UnityEngine.Material[] materialKeys;

	// Token: 0x0400209E RID: 8350
	public global::UnityEngine.Material[] materialValues;

	// Token: 0x0400209F RID: 8351
	[global::System.NonSerialized]
	private global::PrefabRenderer renderer;

	// Token: 0x040020A0 RID: 8352
	[global::System.NonSerialized]
	private global::UnityEngine.GameObject prefabRendering;

	// Token: 0x040020A1 RID: 8353
	[global::System.NonSerialized]
	private global::UnityEngine.Material[] oldMaterialKeys;

	// Token: 0x040020A2 RID: 8354
	[global::System.NonSerialized]
	private global::UnityEngine.Material[] oldMaterialValues;

	// Token: 0x040020A3 RID: 8355
	[global::System.NonSerialized]
	private bool oi;

	// Token: 0x040020A4 RID: 8356
	[global::System.NonSerialized]
	private global::UnityEngine.Material[] overrideMaterials;
}
