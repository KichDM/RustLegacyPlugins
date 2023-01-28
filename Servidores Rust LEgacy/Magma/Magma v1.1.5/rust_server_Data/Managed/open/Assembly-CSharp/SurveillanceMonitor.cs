using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020007B5 RID: 1973
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Renderer))]
public class SurveillanceMonitor : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041BA RID: 16826 RVA: 0x000ED32C File Offset: 0x000EB52C
	public SurveillanceMonitor()
	{
	}

	// Token: 0x060041BB RID: 16827 RVA: 0x000ED358 File Offset: 0x000EB558
	private void Awake()
	{
		this.renderer = base.renderer;
		this.originalSharedMaterials = this.renderer.sharedMaterials;
		if (this.materialIds == null || this.materialIds.Length == 0)
		{
			global::UnityEngine.Debug.LogWarning("Please, set the material ids for this SurveillanceMonitor. Assuming you meant to use id 0 only.", this);
			this.materialIds = new int[1];
		}
		global::System.Collections.Generic.HashSet<global::UnityEngine.Material> hashSet = new global::System.Collections.Generic.HashSet<global::UnityEngine.Material>();
		int num = 0;
		int[] array = new int[this.materialIds.Length];
		for (int i = 0; i < this.materialIds.Length; i++)
		{
			if (hashSet.Add(this.originalSharedMaterials[this.materialIds[i]]))
			{
				array[i] = i;
				num++;
			}
			else
			{
				for (int j = 0; j < i; j++)
				{
					if (this.originalSharedMaterials[this.materialIds[j]] == this.originalSharedMaterials[this.materialIds[i]])
					{
						array[i] = j;
					}
				}
			}
		}
		this.replacementMaterials = new global::UnityEngine.Material[num];
		this.activeSharedMaterials = (global::UnityEngine.Material[])this.originalSharedMaterials.Clone();
		for (int k = 0; k < this.materialIds.Length; k++)
		{
			global::UnityEngine.Material material;
			if (array[k] == k)
			{
				material = (this.replacementMaterials[k] = new global::UnityEngine.Material(this.originalSharedMaterials[this.materialIds[k]]));
			}
			else
			{
				material = this.replacementMaterials[this.materialIds[array[k]]];
			}
			this.activeSharedMaterials[this.materialIds[k]] = material;
		}
	}

	// Token: 0x060041BC RID: 16828 RVA: 0x000ED4E4 File Offset: 0x000EB6E4
	public void DropReference(global::UnityEngine.RenderTexture texture)
	{
		if (this.lastTexture == texture)
		{
			this.lastTexture = null;
		}
	}

	// Token: 0x060041BD RID: 16829 RVA: 0x000ED500 File Offset: 0x000EB700
	private void BindTexture(global::UnityEngine.Texture tex)
	{
		foreach (global::UnityEngine.Material material in this.replacementMaterials)
		{
			material.SetTexture(this.textureName, tex);
		}
	}

	// Token: 0x060041BE RID: 16830 RVA: 0x000ED53C File Offset: 0x000EB73C
	private void OnWillRenderObject()
	{
		if (this.surveillanceCamera)
		{
			global::UnityEngine.Camera current = global::UnityEngine.Camera.current;
			if (this.surveillanceCamera.camera == current)
			{
				return;
			}
			global::UnityEngine.Transform transform = current.transform;
			global::UnityEngine.Vector3 vector = base.transform.position - transform.position;
			float sqrMagnitude = vector.sqrMagnitude;
			global::UnityEngine.Texture texture;
			if (sqrMagnitude <= this.viewDistance * this.viewDistance && global::UnityEngine.Vector3.Dot(transform.forward, vector) > 0f && (texture = this.surveillanceCamera.Render()))
			{
				foreach (global::UnityEngine.Material material in this.replacementMaterials)
				{
					material.SetTexture(this.textureName, texture);
				}
				this.renderer.sharedMaterials = this.activeSharedMaterials;
			}
			else
			{
				this.renderer.sharedMaterials = this.originalSharedMaterials;
			}
		}
	}

	// Token: 0x0400225B RID: 8795
	[global::System.NonSerialized]
	public global::UnityEngine.Renderer renderer;

	// Token: 0x0400225C RID: 8796
	[global::UnityEngine.SerializeField]
	private int[] materialIds;

	// Token: 0x0400225D RID: 8797
	public string textureName = "_MainTex";

	// Token: 0x0400225E RID: 8798
	public float aspect = 1f;

	// Token: 0x0400225F RID: 8799
	public float viewDistance = 30f;

	// Token: 0x04002260 RID: 8800
	private global::UnityEngine.Texture lastTexture;

	// Token: 0x04002261 RID: 8801
	public global::SurveillanceCamera surveillanceCamera;

	// Token: 0x04002262 RID: 8802
	private global::UnityEngine.Material[] replacementMaterials;

	// Token: 0x04002263 RID: 8803
	private global::UnityEngine.Material[] originalSharedMaterials;

	// Token: 0x04002264 RID: 8804
	private global::UnityEngine.Material[] activeSharedMaterials;
}
