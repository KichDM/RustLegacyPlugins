using System;
using UnityEngine;

// Token: 0x020007B4 RID: 1972
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class SurveillanceCamera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041B5 RID: 16821 RVA: 0x000ED1C4 File Offset: 0x000EB3C4
	public SurveillanceCamera()
	{
	}

	// Token: 0x060041B6 RID: 16822 RVA: 0x000ED1CC File Offset: 0x000EB3CC
	private void Awake()
	{
		this.camera = base.camera;
		this.camera.enabled = false;
		base.enabled = false;
	}

	// Token: 0x060041B7 RID: 16823 RVA: 0x000ED1F0 File Offset: 0x000EB3F0
	public global::UnityEngine.RenderTexture Render()
	{
		int frameCount = global::UnityEngine.Time.frameCount;
		if (this.lastFrameRendered == frameCount)
		{
			return this.boundTarget;
		}
		bool flag = this.lastFrameRendered != frameCount - 1;
		this.lastFrameRendered = global::UnityEngine.Time.frameCount;
		if (flag && !this.boundTarget)
		{
			this.boundTarget = global::UnityEngine.RenderTexture.GetTemporary(0x200, 0x200, 0x18, 4);
			base.enabled = true;
			this.camera.targetTexture = this.boundTarget;
			this.camera.ResetAspect();
		}
		this.camera.Render();
		return this.boundTarget;
	}

	// Token: 0x060041B8 RID: 16824 RVA: 0x000ED294 File Offset: 0x000EB494
	private void OnDestroy()
	{
		if (this.boundTarget)
		{
			if (this.camera)
			{
				this.camera.targetTexture = null;
			}
			global::UnityEngine.RenderTexture.ReleaseTemporary(this.boundTarget);
			this.boundTarget = null;
		}
	}

	// Token: 0x060041B9 RID: 16825 RVA: 0x000ED2E0 File Offset: 0x000EB4E0
	private void LateUpdate()
	{
		int num = global::UnityEngine.Mathf.Abs(this.lastFrameRendered - global::UnityEngine.Time.frameCount);
		if (num > 3)
		{
			this.camera.targetTexture = null;
			global::UnityEngine.RenderTexture.ReleaseTemporary(this.boundTarget);
			this.boundTarget = null;
			base.enabled = false;
		}
	}

	// Token: 0x04002252 RID: 8786
	public const int kWidth = 0x200;

	// Token: 0x04002253 RID: 8787
	public const int kHeight = 0x200;

	// Token: 0x04002254 RID: 8788
	public const int kDepth = 0x18;

	// Token: 0x04002255 RID: 8789
	public const global::UnityEngine.RenderTextureFormat kFormat = 4;

	// Token: 0x04002256 RID: 8790
	public const float kAspect = 1f;

	// Token: 0x04002257 RID: 8791
	private const int kRetireFrameCount = 3;

	// Token: 0x04002258 RID: 8792
	public global::UnityEngine.Camera camera;

	// Token: 0x04002259 RID: 8793
	private int lastFrameRendered;

	// Token: 0x0400225A RID: 8794
	private global::UnityEngine.RenderTexture boundTarget;
}
