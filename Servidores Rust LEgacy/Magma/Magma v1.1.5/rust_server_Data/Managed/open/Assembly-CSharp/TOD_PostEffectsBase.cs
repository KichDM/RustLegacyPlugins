using System;
using UnityEngine;

// Token: 0x02000997 RID: 2455
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public abstract class TOD_PostEffectsBase : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060052E0 RID: 21216 RVA: 0x00159AF0 File Offset: 0x00157CF0
	protected TOD_PostEffectsBase()
	{
	}

	// Token: 0x060052E1 RID: 21217
	protected abstract bool CheckResources();

	// Token: 0x060052E2 RID: 21218 RVA: 0x00159B00 File Offset: 0x00157D00
	protected global::UnityEngine.Material CheckShaderAndCreateMaterial(global::UnityEngine.Shader shader, global::UnityEngine.Material material)
	{
		if (!shader)
		{
			global::UnityEngine.Debug.Log("Missing shader in " + this.ToString());
			base.enabled = false;
			return null;
		}
		if (shader.isSupported && material && material.shader == shader)
		{
			return material;
		}
		if (!shader.isSupported)
		{
			this.NotSupported();
			global::UnityEngine.Debug.LogError(string.Concat(new string[]
			{
				"The shader ",
				shader.ToString(),
				" on effect ",
				this.ToString(),
				" is not supported on this platform!"
			}));
			return null;
		}
		material = new global::UnityEngine.Material(shader);
		material.hideFlags = 4;
		return (!material) ? null : material;
	}

	// Token: 0x060052E3 RID: 21219 RVA: 0x00159BD0 File Offset: 0x00157DD0
	protected global::UnityEngine.Material CreateMaterial(global::UnityEngine.Shader shader, global::UnityEngine.Material material)
	{
		if (!shader)
		{
			global::UnityEngine.Debug.Log("Missing shader in " + this.ToString());
			return null;
		}
		if (material && material.shader == shader && shader.isSupported)
		{
			return material;
		}
		if (!shader.isSupported)
		{
			return null;
		}
		material = new global::UnityEngine.Material(shader);
		material.hideFlags = 4;
		return (!material) ? null : material;
	}

	// Token: 0x060052E4 RID: 21220 RVA: 0x00159C58 File Offset: 0x00157E58
	protected void OnEnable()
	{
		this.isSupported = true;
	}

	// Token: 0x060052E5 RID: 21221 RVA: 0x00159C64 File Offset: 0x00157E64
	protected void Start()
	{
		this.CheckResources();
	}

	// Token: 0x060052E6 RID: 21222 RVA: 0x00159C70 File Offset: 0x00157E70
	protected bool CheckSupport(bool needDepth)
	{
		this.isSupported = true;
		if (!global::UnityEngine.SystemInfo.supportsImageEffects || !global::UnityEngine.SystemInfo.supportsRenderTextures)
		{
			this.NotSupported();
			return false;
		}
		if (needDepth && !global::UnityEngine.SystemInfo.SupportsRenderTextureFormat(1))
		{
			this.NotSupported();
			return false;
		}
		if (needDepth)
		{
			base.camera.depthTextureMode |= 1;
		}
		return true;
	}

	// Token: 0x060052E7 RID: 21223 RVA: 0x00159CD4 File Offset: 0x00157ED4
	protected bool CheckSupport(bool needDepth, bool needHdr)
	{
		if (!this.CheckSupport(needDepth))
		{
			return false;
		}
		if (needHdr && !global::UnityEngine.SystemInfo.SupportsRenderTextureFormat(2))
		{
			this.NotSupported();
			return false;
		}
		return true;
	}

	// Token: 0x060052E8 RID: 21224 RVA: 0x00159D0C File Offset: 0x00157F0C
	protected void ReportAutoDisable()
	{
		global::UnityEngine.Debug.LogWarning("The image effect " + this.ToString() + " has been disabled as it's not supported on the current platform.");
	}

	// Token: 0x060052E9 RID: 21225 RVA: 0x00159D28 File Offset: 0x00157F28
	protected void NotSupported()
	{
		base.enabled = false;
		this.isSupported = false;
	}

	// Token: 0x060052EA RID: 21226 RVA: 0x00159D38 File Offset: 0x00157F38
	protected void DrawBorder(global::UnityEngine.RenderTexture dest, global::UnityEngine.Material material)
	{
		global::UnityEngine.RenderTexture.active = dest;
		bool flag = true;
		global::UnityEngine.GL.PushMatrix();
		global::UnityEngine.GL.LoadOrtho();
		for (int i = 0; i < material.passCount; i++)
		{
			material.SetPass(i);
			float num;
			float num2;
			if (flag)
			{
				num = 1f;
				num2 = 0f;
			}
			else
			{
				num = 0f;
				num2 = 1f;
			}
			float num3 = 0f;
			float num4 = 0f + 1f / ((float)dest.width * 1f);
			float num5 = 0f;
			float num6 = 1f;
			global::UnityEngine.GL.Begin(7);
			global::UnityEngine.GL.TexCoord2(0f, num);
			global::UnityEngine.GL.Vertex3(num3, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num);
			global::UnityEngine.GL.Vertex3(num4, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num2);
			global::UnityEngine.GL.Vertex3(num4, num6, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num2);
			global::UnityEngine.GL.Vertex3(num3, num6, 0.1f);
			num3 = 1f - 1f / ((float)dest.width * 1f);
			num4 = 1f;
			num5 = 0f;
			num6 = 1f;
			global::UnityEngine.GL.TexCoord2(0f, num);
			global::UnityEngine.GL.Vertex3(num3, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num);
			global::UnityEngine.GL.Vertex3(num4, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num2);
			global::UnityEngine.GL.Vertex3(num4, num6, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num2);
			global::UnityEngine.GL.Vertex3(num3, num6, 0.1f);
			num3 = 0f;
			num4 = 1f;
			num5 = 0f;
			num6 = 0f + 1f / ((float)dest.height * 1f);
			global::UnityEngine.GL.TexCoord2(0f, num);
			global::UnityEngine.GL.Vertex3(num3, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num);
			global::UnityEngine.GL.Vertex3(num4, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num2);
			global::UnityEngine.GL.Vertex3(num4, num6, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num2);
			global::UnityEngine.GL.Vertex3(num3, num6, 0.1f);
			num3 = 0f;
			num4 = 1f;
			num5 = 1f - 1f / ((float)dest.height * 1f);
			num6 = 1f;
			global::UnityEngine.GL.TexCoord2(0f, num);
			global::UnityEngine.GL.Vertex3(num3, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num);
			global::UnityEngine.GL.Vertex3(num4, num5, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num2);
			global::UnityEngine.GL.Vertex3(num4, num6, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num2);
			global::UnityEngine.GL.Vertex3(num3, num6, 0.1f);
			global::UnityEngine.GL.End();
		}
		global::UnityEngine.GL.PopMatrix();
	}

	// Token: 0x04003017 RID: 12311
	protected bool isSupported = true;
}
