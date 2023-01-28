using System;
using UnityEngine;

// Token: 0x020002C9 RID: 713
[global::UnityEngine.AddComponentMenu("GFxPostProcessor/Opaque")]
[global::UnityEngine.ImageEffectOpaque]
[global::UnityEngine.RequireComponent(typeof(global::GFxCameraDepthTextureControl))]
public sealed class GFxPostProcessorOpaque : global::GFxPostProcessor
{
	// Token: 0x060018C2 RID: 6338 RVA: 0x000604B4 File Offset: 0x0005E6B4
	public GFxPostProcessorOpaque() : base(global::GFxPostProcessor.Kind.Opaque)
	{
	}

	// Token: 0x060018C3 RID: 6339 RVA: 0x000604C0 File Offset: 0x0005E6C0
	[global::UnityEngine.ImageEffectOpaque]
	public void OnRenderImage(global::UnityEngine.RenderTexture source, global::UnityEngine.RenderTexture destination)
	{
		base.DoRenderImage(source, destination);
	}

	// Token: 0x060018C4 RID: 6340 RVA: 0x000604CC File Offset: 0x0005E6CC
	private new void Reset()
	{
		base.Reset();
	}
}
