using System;
using UnityEngine;

// Token: 0x020005C8 RID: 1480
[global::UnityEngine.ExecuteInEditMode]
public class CompassRenderProxy : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003079 RID: 12409 RVA: 0x000B8848 File Offset: 0x000B6A48
	public CompassRenderProxy()
	{
	}

	// Token: 0x0600307A RID: 12410 RVA: 0x000B8888 File Offset: 0x000B6A88
	private void OnBecameVisible()
	{
		base.enabled = true;
		this.BindFrame();
	}

	// Token: 0x0600307B RID: 12411 RVA: 0x000B8898 File Offset: 0x000B6A98
	private void OnBecameInvisible()
	{
		base.enabled = false;
	}

	// Token: 0x0600307C RID: 12412 RVA: 0x000B88A4 File Offset: 0x000B6AA4
	private void BindFrame()
	{
		if (this.propBlock != null)
		{
			this.propBlock.Clear();
		}
		else
		{
			this.propBlock = new global::UnityEngine.MaterialPropertyBlock();
		}
		global::UnityEngine.Vector2 vector = base.transform.worldToLocalMatrix.MultiplyVector(this.north);
		vector.Normalize();
		global::UnityEngine.Vector2 vector2;
		vector2..ctor(-vector.y, vector.x);
		vector2 *= this.scalar;
		vector *= this.scalar;
		if (this.bindNorth)
		{
			this.propBlock.AddVector(global::CompassRenderProxy.g.kPropLensUp, vector);
		}
		if (this.bindWest)
		{
			this.propBlock.AddVector(global::CompassRenderProxy.g.kPropLensRight, vector2);
		}
		if (this.bindForward)
		{
			this.propBlock.AddVector(global::CompassRenderProxy.g.kPropLensDir, this.forward);
		}
		base.renderer.SetPropertyBlock(this.propBlock);
	}

	// Token: 0x0600307D RID: 12413 RVA: 0x000B89A8 File Offset: 0x000B6BA8
	private void LateUpdate()
	{
		this.BindFrame();
	}

	// Token: 0x04001A29 RID: 6697
	public float scalar = 0.7f;

	// Token: 0x04001A2A RID: 6698
	public global::UnityEngine.Vector3 north = global::UnityEngine.Vector3.up;

	// Token: 0x04001A2B RID: 6699
	public global::UnityEngine.Vector3 forward = global::UnityEngine.Vector3.forward;

	// Token: 0x04001A2C RID: 6700
	public float back = 0.3f;

	// Token: 0x04001A2D RID: 6701
	public bool bindNorth;

	// Token: 0x04001A2E RID: 6702
	public bool bindWest;

	// Token: 0x04001A2F RID: 6703
	public bool bindForward;

	// Token: 0x04001A30 RID: 6704
	private global::UnityEngine.MaterialPropertyBlock propBlock;

	// Token: 0x020005C9 RID: 1481
	private static class g
	{
		// Token: 0x0600307E RID: 12414 RVA: 0x000B89B0 File Offset: 0x000B6BB0
		static g()
		{
		}

		// Token: 0x04001A31 RID: 6705
		public static readonly int kPropLensRight = global::UnityEngine.Shader.PropertyToID("_LensRight");

		// Token: 0x04001A32 RID: 6706
		public static readonly int kPropLensUp = global::UnityEngine.Shader.PropertyToID("_LensUp");

		// Token: 0x04001A33 RID: 6707
		public static readonly int kPropLensDir = global::UnityEngine.Shader.PropertyToID("_LensForward");
	}
}
