using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public struct GFxActiveRenderTarget : global::System.IDisposable
{
	// Token: 0x060018D3 RID: 6355 RVA: 0x0006064C File Offset: 0x0005E84C
	public GFxActiveRenderTarget(global::UnityEngine.RenderTexture newTarget)
	{
		this.restore = global::UnityEngine.RenderTexture.active;
		global::UnityEngine.RenderTexture.active = newTarget;
		this.running = true;
	}

	// Token: 0x060018D4 RID: 6356 RVA: 0x00060668 File Offset: 0x0005E868
	public void Dispose()
	{
		if (this.running)
		{
			global::UnityEngine.RenderTexture.active = this.restore;
			this = default(global::GFxActiveRenderTarget);
		}
	}

	// Token: 0x04000E18 RID: 3608
	private readonly global::UnityEngine.RenderTexture restore;

	// Token: 0x04000E19 RID: 3609
	private readonly bool running;
}
