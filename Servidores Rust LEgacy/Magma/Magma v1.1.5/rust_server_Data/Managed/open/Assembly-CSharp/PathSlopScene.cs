using System;
using UnityEngine;

// Token: 0x0200076E RID: 1902
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshFilter), typeof(global::UnityEngine.MeshRenderer))]
public class PathSlopScene : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003F31 RID: 16177 RVA: 0x000E140C File Offset: 0x000DF60C
	public PathSlopScene()
	{
	}

	// Token: 0x17000BE1 RID: 3041
	// (get) Token: 0x06003F32 RID: 16178 RVA: 0x000E1444 File Offset: 0x000DF644
	public global::UnityEngine.MeshFilter filter
	{
		get
		{
			return base.GetComponent<global::UnityEngine.MeshFilter>();
		}
	}

	// Token: 0x17000BE2 RID: 3042
	// (get) Token: 0x06003F33 RID: 16179 RVA: 0x000E144C File Offset: 0x000DF64C
	public global::UnityEngine.MeshRenderer renderer
	{
		get
		{
			return (global::UnityEngine.MeshRenderer)base.renderer;
		}
	}

	// Token: 0x17000BE3 RID: 3043
	// (get) Token: 0x06003F34 RID: 16180 RVA: 0x000E145C File Offset: 0x000DF65C
	public static global::PathSlopScene current
	{
		get
		{
			return null;
		}
	}

	// Token: 0x04002085 RID: 8325
	public global::UnityEngine.Vector4[] sloppymess;

	// Token: 0x04002086 RID: 8326
	public float initialWidth = 1f;

	// Token: 0x04002087 RID: 8327
	public float areaGrid = 8f;

	// Token: 0x04002088 RID: 8328
	public float pushup = 0.05f;

	// Token: 0x04002089 RID: 8329
	public global::UnityEngine.LayerMask layerMask = 1;
}
