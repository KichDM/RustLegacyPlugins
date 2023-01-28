using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200056B RID: 1387
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.SkinnedMeshRenderer))]
public class BoundHack : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EEF RID: 12015 RVA: 0x000B2ED4 File Offset: 0x000B10D4
	public BoundHack()
	{
	}

	// Token: 0x06002EF0 RID: 12016 RVA: 0x000B2EDC File Offset: 0x000B10DC
	private void Awake()
	{
		this.renderer = (base.renderer as global::UnityEngine.SkinnedMeshRenderer);
		if (global::BoundHack.renders == null)
		{
			global::BoundHack.renders = new global::System.Collections.Generic.HashSet<global::BoundHack>();
		}
		global::BoundHack.renders.Add(this);
	}

	// Token: 0x06002EF1 RID: 12017 RVA: 0x000B2F10 File Offset: 0x000B1110
	private void OnDestroy()
	{
		if (global::BoundHack.renders != null)
		{
			global::BoundHack.renders.Remove(this);
		}
	}

	// Token: 0x06002EF2 RID: 12018 RVA: 0x000B2F28 File Offset: 0x000B1128
	public static void Achieve(global::UnityEngine.Vector3 centroid)
	{
		if (global::BoundHack.renders != null)
		{
			foreach (global::BoundHack boundHack in global::BoundHack.renders)
			{
				boundHack.renderer.localBounds = new global::UnityEngine.Bounds(((!boundHack.rootbone) ? boundHack.transform : boundHack.rootbone).InverseTransformPoint(centroid), new global::UnityEngine.Vector3(100f, 100f, 100f));
			}
		}
	}

	// Token: 0x06002EF3 RID: 12019 RVA: 0x000B2FDC File Offset: 0x000B11DC
	private void OnDrawGizmosSelected()
	{
		if (base.renderer)
		{
			global::UnityEngine.Gizmos.DrawWireCube(base.renderer.bounds.center, base.renderer.bounds.size);
		}
		if (this.rootbone && this.renderer)
		{
			global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.8f, 0.8f, 1f, 0.1f);
			global::UnityEngine.Gizmos.matrix = this.rootbone.localToWorldMatrix;
			global::UnityEngine.Gizmos.DrawCube(this.renderer.localBounds.center, this.renderer.localBounds.size);
		}
	}

	// Token: 0x0400188A RID: 6282
	private static global::System.Collections.Generic.HashSet<global::BoundHack> renders;

	// Token: 0x0400188B RID: 6283
	private global::UnityEngine.SkinnedMeshRenderer renderer;

	// Token: 0x0400188C RID: 6284
	public global::UnityEngine.Transform rootbone;
}
