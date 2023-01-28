using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
[global::UnityEngine.AddComponentMenu("GFxPostProcessor/Transparent")]
[global::UnityEngine.RequireComponent(typeof(global::GFxCameraDepthTextureControl))]
public sealed class GFxPostProcessorTransparent : global::GFxPostProcessor
{
	// Token: 0x060018C8 RID: 6344 RVA: 0x000604F4 File Offset: 0x0005E6F4
	public GFxPostProcessorTransparent() : base(global::GFxPostProcessor.Kind.Transparent)
	{
	}

	// Token: 0x060018C9 RID: 6345 RVA: 0x00060500 File Offset: 0x0005E700
	public void OnRenderImage(global::UnityEngine.RenderTexture source, global::UnityEngine.RenderTexture destination)
	{
		base.DoRenderImage(source, destination);
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x0006050C File Offset: 0x0005E70C
	private new void Reset()
	{
		base.Reset();
	}
}
