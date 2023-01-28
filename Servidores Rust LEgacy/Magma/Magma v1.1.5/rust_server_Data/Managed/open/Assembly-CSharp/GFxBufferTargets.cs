using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public struct GFxBufferTargets : global::System.IDisposable
{
	// Token: 0x060018CE RID: 6350 RVA: 0x00060534 File Offset: 0x0005E734
	public GFxBufferTargets(global::UnityEngine.RenderBuffer color, global::UnityEngine.RenderBuffer depth)
	{
		this.restoreColor = global::UnityEngine.Graphics.activeColorBuffer;
		this.restoreDepth = global::UnityEngine.Graphics.activeDepthBuffer;
		global::UnityEngine.Graphics.SetRenderTarget(color, depth);
		this.running = true;
	}

	// Token: 0x060018CF RID: 6351 RVA: 0x00060568 File Offset: 0x0005E768
	public GFxBufferTargets(global::UnityEngine.RenderTexture texture)
	{
		this.restoreColor = global::UnityEngine.Graphics.activeColorBuffer;
		this.restoreDepth = global::UnityEngine.Graphics.activeDepthBuffer;
		global::UnityEngine.Graphics.SetRenderTarget(texture);
		this.running = true;
	}

	// Token: 0x060018D0 RID: 6352 RVA: 0x00060590 File Offset: 0x0005E790
	public GFxBufferTargets(global::UnityEngine.RenderBuffer[] colors, global::UnityEngine.RenderBuffer depth)
	{
		this.restoreColor = global::UnityEngine.Graphics.activeColorBuffer;
		this.restoreDepth = global::UnityEngine.Graphics.activeDepthBuffer;
		global::UnityEngine.Graphics.SetRenderTarget(colors, depth);
		this.running = true;
	}

	// Token: 0x060018D1 RID: 6353 RVA: 0x000605C4 File Offset: 0x0005E7C4
	public GFxBufferTargets(global::UnityEngine.RenderBuffer? color, global::UnityEngine.RenderBuffer? depth)
	{
		this = new global::GFxBufferTargets((color == null) ? global::UnityEngine.Graphics.activeColorBuffer : color.Value, (depth == null) ? global::UnityEngine.Graphics.activeDepthBuffer : depth.Value);
	}

	// Token: 0x060018D2 RID: 6354 RVA: 0x00060614 File Offset: 0x0005E814
	public void Dispose()
	{
		if (this.running)
		{
			global::UnityEngine.Graphics.SetRenderTarget(this.restoreColor, this.restoreDepth);
			this = default(global::GFxBufferTargets);
		}
	}

	// Token: 0x04000E15 RID: 3605
	private readonly global::UnityEngine.RenderBuffer restoreColor;

	// Token: 0x04000E16 RID: 3606
	private readonly global::UnityEngine.RenderBuffer restoreDepth;

	// Token: 0x04000E17 RID: 3607
	private readonly bool running;
}
