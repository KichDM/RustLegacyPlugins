using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
[global::UnityEngine.AddComponentMenu("GFxPostProcessor/Transparent LDR")]
[global::UnityEngine.ImageEffectTransformsToLDR]
[global::UnityEngine.RequireComponent(typeof(global::GFxCameraDepthTextureControl))]
public sealed class GFxPostProcessorTransparentLDR : global::GFxPostProcessor
{
	// Token: 0x060018CB RID: 6347 RVA: 0x00060514 File Offset: 0x0005E714
	public GFxPostProcessorTransparentLDR() : base(global::GFxPostProcessor.Kind.TransparentLDR)
	{
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x00060520 File Offset: 0x0005E720
	[global::UnityEngine.ImageEffectTransformsToLDR]
	public void OnRenderImage(global::UnityEngine.RenderTexture source, global::UnityEngine.RenderTexture destination)
	{
		base.DoRenderImage(source, destination);
	}

	// Token: 0x060018CD RID: 6349 RVA: 0x0006052C File Offset: 0x0005E72C
	private new void Reset()
	{
		base.Reset();
	}
}
