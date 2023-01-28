using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class GFxImageEffect_OpaqueCapture : global::GFxImageEffect
{
	// Token: 0x060018A0 RID: 6304 RVA: 0x0005EAE8 File Offset: 0x0005CCE8
	public GFxImageEffect_OpaqueCapture()
	{
	}

	// Token: 0x060018A1 RID: 6305 RVA: 0x0005EB08 File Offset: 0x0005CD08
	private bool CheckResources()
	{
		bool flag = false;
		if (!this.blitCopyShader)
		{
			this.blitCopyShader = global::UnityEngine.Shader.Find("Hidden/BlitCopy");
		}
		return global::GFxImageEffect.OK(base.CheckShaderAndCreateMaterial(this.blitCopyShader, ref this.blitCopy), ref flag);
	}

	// Token: 0x060018A2 RID: 6306 RVA: 0x0005EB58 File Offset: 0x0005CD58
	protected override void Configure()
	{
		this.supported = false;
		if ((byte)(this.processor.kind & global::GFxPostProcessor.Kind.Opaque) != 4)
		{
			this.noSupportReason = string.Format("Processor's kind is {0}. OpaqueCapture requires a Opaque kind", this.processor.kind);
			this.supported = false;
			return;
		}
		if (!base.Support(global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTarget))
		{
			this.supported = false;
			return;
		}
		if (!this.CheckResources())
		{
			this.supported = false;
			this.noSupportReason = "Could not verify resources";
			return;
		}
		if (!base.Support(global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals))
		{
			this.supported = false;
			return;
		}
		this.supported = true;
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x0005EBFC File Offset: 0x0005CDFC
	protected override void DeConfigure()
	{
		this.blitCopy = null;
		this.ReleaseResources();
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x0005EC0C File Offset: 0x0005CE0C
	private void ReleaseResources()
	{
		if (this.captureRT)
		{
			global::UnityEngine.Object.DestroyImmediate(this.captureRT);
		}
		this.captureRT = null;
		this.w = (this.h = -1);
	}

	// Token: 0x170006B4 RID: 1716
	// (get) Token: 0x060018A5 RID: 6309 RVA: 0x0005EC4C File Offset: 0x0005CE4C
	public override bool allow
	{
		get
		{
			return true;
		}
	}

	// Token: 0x060018A6 RID: 6310 RVA: 0x0005EC50 File Offset: 0x0005CE50
	protected override bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		int width = src.width;
		int height = src.height;
		int depth = src.depth;
		global::UnityEngine.RenderTextureFormat format = src.format;
		bool flag;
		if (width != this.w || height != this.h || depth != this.d || format != this.fmt)
		{
			this.ReleaseResources();
			this.captureRT = new global::UnityEngine.RenderTexture(width, height, depth, format)
			{
				hideFlags = 4
			};
			if (!this.captureRT.Create() && !this.captureRT.IsCreated())
			{
				this.ReleaseResources();
				return false;
			}
			flag = true;
			this.w = width;
			this.h = height;
			this.d = depth;
			this.fmt = format;
		}
		else
		{
			flag = false;
		}
		using (new global::GFxActiveRenderTarget(this.captureRT))
		{
			using (new global::GFxBufferTargets(this.captureRT.colorBuffer, this.captureRT.depthBuffer))
			{
				if (!flag)
				{
					global::UnityEngine.GL.Clear(true, true, global::UnityEngine.Color.black, 0f);
				}
				global::UnityEngine.Graphics.Blit(src, this.captureRT, this.blitCopy, 0);
			}
		}
		if (flag)
		{
			this.captureRT.SetGlobalShaderProperty("_OpaqueFrame");
		}
		global::UnityEngine.Graphics.Blit(src, dst);
		return true;
	}

	// Token: 0x04000DAA RID: 3498
	public const bool opaqueCaptureOn = true;

	// Token: 0x04000DAB RID: 3499
	[global::System.NonSerialized]
	private global::UnityEngine.RenderTexture captureRT;

	// Token: 0x04000DAC RID: 3500
	[global::System.NonSerialized]
	private int w = -1;

	// Token: 0x04000DAD RID: 3501
	[global::System.NonSerialized]
	private int h = -1;

	// Token: 0x04000DAE RID: 3502
	[global::System.NonSerialized]
	private int d = -1;

	// Token: 0x04000DAF RID: 3503
	[global::System.NonSerialized]
	private global::UnityEngine.RenderTextureFormat fmt;

	// Token: 0x04000DB0 RID: 3504
	[global::System.NonSerialized]
	private global::UnityEngine.Material blitCopy;

	// Token: 0x04000DB1 RID: 3505
	[global::System.NonSerialized]
	private global::UnityEngine.Shader blitCopyShader;
}
