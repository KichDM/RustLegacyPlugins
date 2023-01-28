using System;
using System.Collections;
using UnityEngine;

// Token: 0x020009B4 RID: 2484
[global::UnityEngine.AddComponentMenu("Mesh/Combine Children")]
public class CombineChildren : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005358 RID: 21336 RVA: 0x0015E3E0 File Offset: 0x0015C5E0
	public CombineChildren()
	{
	}

	// Token: 0x06005359 RID: 21337 RVA: 0x0015E3F8 File Offset: 0x0015C5F8
	public void DoCombine()
	{
		global::UnityEngine.Component[] componentsInChildren = base.GetComponentsInChildren(typeof(global::UnityEngine.MeshFilter));
		global::UnityEngine.Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
		global::System.Collections.Hashtable hashtable = new global::System.Collections.Hashtable();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			global::UnityEngine.MeshFilter meshFilter = (global::UnityEngine.MeshFilter)componentsInChildren[i];
			global::UnityEngine.Renderer renderer = componentsInChildren[i].renderer;
			global::MeshCombineUtility.MeshInstance meshInstance = default(global::MeshCombineUtility.MeshInstance);
			meshInstance.mesh = meshFilter.sharedMesh;
			if (renderer != null && renderer.enabled && meshInstance.mesh != null)
			{
				meshInstance.transform = worldToLocalMatrix * meshFilter.transform.localToWorldMatrix;
				global::UnityEngine.Material[] sharedMaterials = renderer.sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					meshInstance.subMeshIndex = global::System.Math.Min(j, meshInstance.mesh.subMeshCount - 1);
					global::System.Collections.ArrayList arrayList = (global::System.Collections.ArrayList)hashtable[sharedMaterials[j]];
					if (arrayList != null)
					{
						arrayList.Add(meshInstance);
					}
					else
					{
						arrayList = new global::System.Collections.ArrayList();
						arrayList.Add(meshInstance);
						hashtable.Add(sharedMaterials[j], arrayList);
					}
				}
				renderer.enabled = false;
			}
		}
		foreach (object obj in hashtable)
		{
			global::System.Collections.DictionaryEntry dictionaryEntry = (global::System.Collections.DictionaryEntry)obj;
			global::System.Collections.ArrayList arrayList2 = (global::System.Collections.ArrayList)dictionaryEntry.Value;
			global::MeshCombineUtility.MeshInstance[] combines = (global::MeshCombineUtility.MeshInstance[])arrayList2.ToArray(typeof(global::MeshCombineUtility.MeshInstance));
			if (hashtable.Count == 1)
			{
				if (base.GetComponent(typeof(global::UnityEngine.MeshFilter)) == null)
				{
					base.gameObject.AddComponent(typeof(global::UnityEngine.MeshFilter));
				}
				if (!base.GetComponent("MeshRenderer"))
				{
					base.gameObject.AddComponent("MeshRenderer");
				}
				global::UnityEngine.MeshFilter meshFilter2 = (global::UnityEngine.MeshFilter)base.GetComponent(typeof(global::UnityEngine.MeshFilter));
				meshFilter2.mesh = global::MeshCombineUtility.Combine(combines, this.generateTriangleStrips);
				base.renderer.material = (global::UnityEngine.Material)dictionaryEntry.Key;
				base.renderer.enabled = true;
			}
			else
			{
				global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("Combined mesh");
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = global::UnityEngine.Vector3.one;
				gameObject.transform.localRotation = global::UnityEngine.Quaternion.identity;
				gameObject.transform.localPosition = global::UnityEngine.Vector3.zero;
				gameObject.AddComponent(typeof(global::UnityEngine.MeshFilter));
				gameObject.AddComponent("MeshRenderer");
				gameObject.renderer.material = (global::UnityEngine.Material)dictionaryEntry.Key;
				global::UnityEngine.MeshFilter meshFilter3 = (global::UnityEngine.MeshFilter)gameObject.GetComponent(typeof(global::UnityEngine.MeshFilter));
				meshFilter3.mesh = global::MeshCombineUtility.Combine(combines, this.generateTriangleStrips);
			}
		}
	}

	// Token: 0x0600535A RID: 21338 RVA: 0x0015E730 File Offset: 0x0015C930
	private void Start()
	{
		if (this.combineOnStart)
		{
			this.DoCombine();
		}
	}

	// Token: 0x040030E5 RID: 12517
	public bool generateTriangleStrips = true;

	// Token: 0x040030E6 RID: 12518
	public bool combineOnStart = true;
}
