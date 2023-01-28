using System;
using UnityEngine;

// Token: 0x020005C2 RID: 1474
public class DisplayRenderBounds : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003069 RID: 12393 RVA: 0x000B85C8 File Offset: 0x000B67C8
	public DisplayRenderBounds()
	{
	}

	// Token: 0x0600306A RID: 12394 RVA: 0x000B85D0 File Offset: 0x000B67D0
	private void OnDrawGizmos()
	{
		global::UnityEngine.Renderer renderer = base.renderer;
		if (renderer)
		{
			global::UnityEngine.Bounds bounds = renderer.bounds;
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
			global::UnityEngine.Gizmos.DrawWireCube(bounds.center, bounds.size);
			if (renderer is global::UnityEngine.SkinnedMeshRenderer)
			{
				global::UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer = renderer as global::UnityEngine.SkinnedMeshRenderer;
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
				global::UnityEngine.Gizmos.matrix = skinnedMeshRenderer.localToWorldMatrix;
				bounds = skinnedMeshRenderer.localBounds;
				global::UnityEngine.Gizmos.DrawWireCube(bounds.center, bounds.size);
			}
			else
			{
				global::UnityEngine.MeshFilter component = base.GetComponent<global::UnityEngine.MeshFilter>();
				if (component)
				{
					global::UnityEngine.Mesh sharedMesh = component.sharedMesh;
					if (sharedMesh)
					{
						global::UnityEngine.Gizmos.color = global::UnityEngine.Color.magenta;
						global::UnityEngine.Gizmos.matrix = base.transform.localToWorldMatrix;
						bounds = sharedMesh.bounds;
						global::UnityEngine.Gizmos.DrawWireCube(bounds.center, bounds.size);
					}
				}
			}
		}
	}
}
