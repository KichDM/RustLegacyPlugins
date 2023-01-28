using System;
using UnityEngine;

// Token: 0x0200089F RID: 2207
public class SurfaceScript : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004C5E RID: 19550 RVA: 0x00120BB8 File Offset: 0x0011EDB8
	public SurfaceScript()
	{
	}

	// Token: 0x06004C5F RID: 19551 RVA: 0x00120BC0 File Offset: 0x0011EDC0
	private void Start()
	{
		global::UnityEngine.Material material;
		if (base.transform.parent.GetComponent<global::MarkerScript>().objectScript.materialType == 0)
		{
			material = (global::UnityEngine.Material)global::UnityEngine.Object.Instantiate(global::UnityEngine.Resources.Load("surfaceMaterial", typeof(global::UnityEngine.Material)));
		}
		else
		{
			material = (global::UnityEngine.Material)global::UnityEngine.Object.Instantiate(global::UnityEngine.Resources.Load("surfaceAlphaMaterial", typeof(global::UnityEngine.Material)));
		}
		material.color.a = base.transform.parent.GetComponent<global::MarkerScript>().objectScript.surfaceOpacity;
		base.gameObject.renderer.sharedMaterial = material;
	}
}
