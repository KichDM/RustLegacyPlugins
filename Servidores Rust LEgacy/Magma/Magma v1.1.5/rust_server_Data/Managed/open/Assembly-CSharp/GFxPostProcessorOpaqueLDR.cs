using System;
using UnityEngine;

// Token: 0x020002CA RID: 714
[global::UnityEngine.AddComponentMenu("GFxPostProcessor/Opaque LDR")]
[global::UnityEngine.ImageEffectOpaque]
[global::UnityEngine.ImageEffectTransformsToLDR]
[global::UnityEngine.RequireComponent(typeof(global::GFxCameraDepthTextureControl))]
public sealed class GFxPostProcessorOpaqueLDR : global::GFxPostProcessor
{
	// Token: 0x060018C5 RID: 6341 RVA: 0x000604D4 File Offset: 0x0005E6D4
	public GFxPostProcessorOpaqueLDR() : base(global::GFxPostProcessor.Kind.OpaqueLDR)
	{
	}

	// Token: 0x060018C6 RID: 6342 RVA: 0x000604E0 File Offset: 0x0005E6E0
	[global::UnityEngine.ImageEffectOpaque]
	[global::UnityEngine.ImageEffectTransformsToLDR]
	public void OnRenderImage(global::UnityEngine.RenderTexture source, global::UnityEngine.RenderTexture destination)
	{
		base.DoRenderImage(source, destination);
	}

	// Token: 0x060018C7 RID: 6343 RVA: 0x000604EC File Offset: 0x0005E6EC
	private new void Reset()
	{
		base.Reset();
	}
}
