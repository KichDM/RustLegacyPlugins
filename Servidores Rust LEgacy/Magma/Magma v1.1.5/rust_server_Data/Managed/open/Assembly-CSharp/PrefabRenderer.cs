using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000770 RID: 1904
public sealed class PrefabRenderer : global::System.IDisposable
{
	// Token: 0x06003F38 RID: 16184 RVA: 0x000E15A0 File Offset: 0x000DF7A0
	private PrefabRenderer(int prefabId)
	{
		this.prefabId = prefabId;
		global::PrefabRenderer.Runtime.Register[this.prefabId] = new global::System.WeakReference(this);
	}

	// Token: 0x17000BE4 RID: 3044
	// (get) Token: 0x06003F39 RID: 16185 RVA: 0x000E15C8 File Offset: 0x000DF7C8
	public int materialCount
	{
		get
		{
			return this.originalMaterials.Length;
		}
	}

	// Token: 0x06003F3A RID: 16186 RVA: 0x000E15D4 File Offset: 0x000DF7D4
	public global::UnityEngine.Material GetMaterial(int index)
	{
		return this.originalMaterials[index];
	}

	// Token: 0x06003F3B RID: 16187 RVA: 0x000E15E0 File Offset: 0x000DF7E0
	public global::UnityEngine.Material[] GetMaterialArrayCopy()
	{
		return (global::UnityEngine.Material[])this.originalMaterials.Clone();
	}

	// Token: 0x06003F3C RID: 16188 RVA: 0x000E15F4 File Offset: 0x000DF7F4
	protected override void Finalize()
	{
		try
		{
			if (!this.disposed)
			{
				this.disposed = true;
				object @lock = global::PrefabRenderer.Runtime.Lock;
				lock (@lock)
				{
					global::PrefabRenderer.Runtime.Register.Remove(this.prefabId);
				}
			}
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06003F3D RID: 16189 RVA: 0x000E167C File Offset: 0x000DF87C
	public void Dispose()
	{
		if (!this.disposed)
		{
			this.disposed = true;
			global::System.GC.SuppressFinalize(this);
			object @lock = global::PrefabRenderer.Runtime.Lock;
			lock (@lock)
			{
				global::PrefabRenderer.Runtime.Register.Remove(this.prefabId);
			}
		}
	}

	// Token: 0x06003F3E RID: 16190 RVA: 0x000E16E8 File Offset: 0x000DF8E8
	public static global::PrefabRenderer GetOrCreateRender(global::UnityEngine.GameObject prefab)
	{
		if (!prefab)
		{
			return null;
		}
		while (prefab.transform.parent)
		{
			prefab = prefab.transform.parent.gameObject;
		}
		int instanceID = prefab.GetInstanceID();
		object @lock = global::PrefabRenderer.Runtime.Lock;
		global::PrefabRenderer prefabRenderer;
		bool flag;
		lock (@lock)
		{
			global::System.WeakReference weakReference;
			if (global::PrefabRenderer.Runtime.Register.TryGetValue(instanceID, out weakReference))
			{
				prefabRenderer = (global::PrefabRenderer)weakReference.Target;
			}
			else
			{
				prefabRenderer = null;
			}
			flag = (prefabRenderer != null);
			if (!flag)
			{
				prefabRenderer = new global::PrefabRenderer(instanceID);
			}
		}
		if (!flag)
		{
			prefabRenderer.prefab = prefab;
			prefabRenderer.Refresh();
		}
		return prefabRenderer;
	}

	// Token: 0x06003F3F RID: 16191 RVA: 0x000E17B8 File Offset: 0x000DF9B8
	private static void DoNotCareResize<T>(ref T[] array, int size)
	{
		if (array == null || array.Length != size)
		{
			array = new T[size];
		}
	}

	// Token: 0x06003F40 RID: 16192 RVA: 0x000E17D4 File Offset: 0x000DF9D4
	public void Refresh()
	{
		global::UnityEngine.Transform transform = this.prefab.transform;
		global::System.Collections.Generic.HashSet<global::UnityEngine.Material> hashSet = new global::System.Collections.Generic.HashSet<global::UnityEngine.Material>();
		global::System.Collections.Generic.HashSet<global::UnityEngine.Mesh> hashSet2 = new global::System.Collections.Generic.HashSet<global::UnityEngine.Mesh>();
		global::System.Collections.Generic.List<global::UnityEngine.Material[]> list = new global::System.Collections.Generic.List<global::UnityEngine.Material[]>();
		global::System.Collections.Generic.List<global::UnityEngine.Mesh> list2 = new global::System.Collections.Generic.List<global::UnityEngine.Mesh>();
		int num = 0;
		global::UnityEngine.Renderer[] componentsInChildren = this.prefab.GetComponentsInChildren<global::UnityEngine.Renderer>(true);
		int num2 = 0;
		foreach (global::UnityEngine.Renderer renderer in componentsInChildren)
		{
			if (renderer && renderer.enabled && !renderer.name.EndsWith("-lod", global::System.StringComparison.InvariantCultureIgnoreCase) && !renderer.name.EndsWith("_LOD_LOWEST", global::System.StringComparison.InvariantCultureIgnoreCase))
			{
				if (renderer is global::UnityEngine.MeshRenderer)
				{
					componentsInChildren[num2++] = renderer;
					global::UnityEngine.Mesh sharedMesh = renderer.GetComponent<global::UnityEngine.MeshFilter>().sharedMesh;
					if (sharedMesh && hashSet2.Add(sharedMesh))
					{
						num++;
					}
					list2.Add(sharedMesh);
				}
				else
				{
					if (!(renderer is global::UnityEngine.SkinnedMeshRenderer))
					{
						goto IL_15B;
					}
					componentsInChildren[num2++] = renderer;
					global::UnityEngine.Mesh sharedMesh2 = ((global::UnityEngine.SkinnedMeshRenderer)renderer).sharedMesh;
					if (sharedMesh2 && hashSet2.Add(sharedMesh2))
					{
						num++;
					}
					list2.Add(sharedMesh2);
				}
				global::UnityEngine.Material[] sharedMaterials = renderer.sharedMaterials;
				list.Add(sharedMaterials);
				hashSet.UnionWith(sharedMaterials);
			}
			IL_15B:;
		}
		for (int j = num2; j < componentsInChildren.Length; j++)
		{
			componentsInChildren[j] = null;
		}
		int count = hashSet.Count;
		int num3 = (count % 0x20 <= 0) ? (count / 0x20) : (count / 0x20 + 1);
		global::PrefabRenderer.DoNotCareResize<int>(ref this.skipBits, num3);
		for (int k = 0; k < num3; k++)
		{
			this.skipBits[k] = 0;
		}
		global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, int> dictionary = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, int>(count);
		global::System.Collections.Generic.Dictionary<global::UnityEngine.Mesh, int> dictionary2 = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Mesh, int>(num);
		global::PrefabRenderer.DoNotCareResize<global::UnityEngine.Material>(ref this.originalMaterials, count);
		int num4 = 0;
		foreach (global::UnityEngine.Material material in hashSet)
		{
			if (material.GetTag("IgnorePrefabRenderer", false, "False") == "True")
			{
				this.skipBits[num4 / 0x20] |= 1 << num4 % 0x20;
			}
			this.originalMaterials[num4] = material;
			dictionary[material] = num4++;
		}
		global::PrefabRenderer.DoNotCareResize<global::UnityEngine.Mesh>(ref this.originalMeshes, num);
		int num5 = 0;
		foreach (global::UnityEngine.Mesh mesh in hashSet2)
		{
			this.originalMeshes[num5] = mesh;
			dictionary2[mesh] = num5++;
		}
		global::PrefabRenderer.DoNotCareResize<global::PrefabRenderer.MeshRender>(ref this.meshes, num2);
		for (int l = 0; l < num2; l++)
		{
			global::UnityEngine.Renderer renderer2 = componentsInChildren[l];
			global::UnityEngine.Material[] array = list[l];
			int[] array2 = new int[array.Length];
			for (int m = 0; m < array.Length; m++)
			{
				array2[m] = dictionary[array[m]];
			}
			this.meshes[l].Set(dictionary2[list2[l]], array2, renderer2.transform.localToWorldMatrix * transform.worldToLocalMatrix, renderer2.gameObject.layer, renderer2.castShadows, renderer2.receiveShadows);
		}
	}

	// Token: 0x06003F41 RID: 16193 RVA: 0x000E1BC8 File Offset: 0x000DFDC8
	public void Render(global::UnityEngine.Camera camera, global::UnityEngine.Matrix4x4 world, global::UnityEngine.MaterialPropertyBlock props, global::UnityEngine.Material[] overrideMaterials)
	{
		global::UnityEngine.Material[] array = overrideMaterials ?? this.originalMaterials;
		foreach (global::PrefabRenderer.MeshRender meshRender in this.meshes)
		{
			global::UnityEngine.Mesh mesh = this.originalMeshes[meshRender.mesh];
			int num = 0;
			foreach (int num2 in meshRender.materials)
			{
				if ((this.skipBits[num2 / 0x20] & 1 << num2 % 0x20) == 0)
				{
					global::UnityEngine.Material material = array[num2];
					global::UnityEngine.Graphics.DrawMesh(mesh, world, material, meshRender.layer, camera, num++, props, meshRender.castShadows, meshRender.receiveShadows);
				}
			}
		}
	}

	// Token: 0x06003F42 RID: 16194 RVA: 0x000E1C98 File Offset: 0x000DFE98
	public void RenderOneMaterial(global::UnityEngine.Camera camera, global::UnityEngine.Matrix4x4 world, global::UnityEngine.MaterialPropertyBlock props, global::UnityEngine.Material overrideMaterial)
	{
		if (!overrideMaterial)
		{
			return;
		}
		foreach (global::PrefabRenderer.MeshRender meshRender in this.meshes)
		{
			global::UnityEngine.Mesh mesh = this.originalMeshes[meshRender.mesh];
			int num = 0;
			for (int j = 0; j < meshRender.materials.Length; j++)
			{
				int num2 = meshRender.materials[j];
				if ((this.skipBits[num2 / 0x20] & 1 << num2 % 0x20) == 0)
				{
					global::UnityEngine.Graphics.DrawMesh(mesh, world, overrideMaterial, meshRender.layer, camera, num++, props, meshRender.castShadows, meshRender.receiveShadows);
				}
			}
		}
	}

	// Token: 0x0400208D RID: 8333
	private global::UnityEngine.Material[] originalMaterials;

	// Token: 0x0400208E RID: 8334
	private global::UnityEngine.Mesh[] originalMeshes;

	// Token: 0x0400208F RID: 8335
	private global::PrefabRenderer.MeshRender[] meshes;

	// Token: 0x04002090 RID: 8336
	private int[] skipBits;

	// Token: 0x04002091 RID: 8337
	private global::UnityEngine.GameObject prefab;

	// Token: 0x04002092 RID: 8338
	private bool disposed;

	// Token: 0x04002093 RID: 8339
	private readonly int prefabId;

	// Token: 0x02000771 RID: 1905
	private static class Runtime
	{
		// Token: 0x06003F43 RID: 16195 RVA: 0x000E1D60 File Offset: 0x000DFF60
		// Note: this type is marked as 'beforefieldinit'.
		static Runtime()
		{
		}

		// Token: 0x04002094 RID: 8340
		public static object Lock = new object();

		// Token: 0x04002095 RID: 8341
		public static global::System.Collections.Generic.Dictionary<int, global::System.WeakReference> Register = new global::System.Collections.Generic.Dictionary<int, global::System.WeakReference>();
	}

	// Token: 0x02000772 RID: 1906
	private struct MeshRender
	{
		// Token: 0x06003F44 RID: 16196 RVA: 0x000E1D78 File Offset: 0x000DFF78
		public void Set(int mesh, int[] materials, global::UnityEngine.Matrix4x4 transform, int layer, bool castShadows, bool receiveShadows)
		{
			this.mesh = mesh;
			this.materials = materials;
			this.transform = transform;
			this.layer = layer;
			this.castShadows = castShadows;
			this.receiveShadows = receiveShadows;
		}

		// Token: 0x04002096 RID: 8342
		public int mesh;

		// Token: 0x04002097 RID: 8343
		public global::UnityEngine.Matrix4x4 transform;

		// Token: 0x04002098 RID: 8344
		public int[] materials;

		// Token: 0x04002099 RID: 8345
		public int layer;

		// Token: 0x0400209A RID: 8346
		public bool castShadows;

		// Token: 0x0400209B RID: 8347
		public bool receiveShadows;
	}
}
