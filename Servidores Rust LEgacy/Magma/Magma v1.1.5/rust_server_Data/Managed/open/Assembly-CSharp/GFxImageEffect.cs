using System;
using System.Collections.Generic;
using Facepunch.Build;
using UnityEngine;

// Token: 0x020002A3 RID: 675
[global::Facepunch.Build.UniqueBundleScriptableObject]
public abstract class GFxImageEffect : global::UnityEngine.ScriptableObject
{
	// Token: 0x060017DE RID: 6110 RVA: 0x00059C70 File Offset: 0x00057E70
	protected GFxImageEffect()
	{
	}

	// Token: 0x17000685 RID: 1669
	// (get) Token: 0x060017DF RID: 6111 RVA: 0x00059C78 File Offset: 0x00057E78
	public bool instance
	{
		get
		{
			return this.isInstance;
		}
	}

	// Token: 0x17000686 RID: 1670
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x00059C80 File Offset: 0x00057E80
	public global::GFxImageEffect @base
	{
		get
		{
			return (!this.isInstance) ? null : this.prefab;
		}
	}

	// Token: 0x17000687 RID: 1671
	// (get) Token: 0x060017E1 RID: 6113 RVA: 0x00059C9C File Offset: 0x00057E9C
	protected global::UnityEngine.Camera camera
	{
		get
		{
			return (!this.isInstance || !this.processor) ? null : this.processor.camera;
		}
	}

	// Token: 0x060017E2 RID: 6114 RVA: 0x00059CD8 File Offset: 0x00057ED8
	internal global::GFxImageEffect Summon(global::GFxPostProcessor processor)
	{
		if (!processor)
		{
			throw new global::System.ArgumentNullException("processor");
		}
		if (this.isInstance)
		{
			throw new global::System.InvalidOperationException("this is a instance not a prefab");
		}
		global::GFxImageEffect gfxImageEffect = (global::GFxImageEffect)global::UnityEngine.Object.Instantiate(this);
		gfxImageEffect.isInstance = true;
		gfxImageEffect.prefab = this;
		gfxImageEffect.processor = processor;
		gfxImageEffect.Configure();
		if (!this.supported)
		{
			this.TurnOffDepthTextureMode();
		}
		return gfxImageEffect;
	}

	// Token: 0x060017E3 RID: 6115 RVA: 0x00059D4C File Offset: 0x00057F4C
	internal void Shutdown(ref global::GFxImageEffect reference)
	{
		if (!this.isInstance)
		{
			throw new global::System.InvalidOperationException("you may not call this on the prefab");
		}
		if (!reference)
		{
			return;
		}
		if (reference != this)
		{
			throw new global::System.ArgumentException("reference is not this", "reference");
		}
		try
		{
			this.DeConfigure();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
		if (this.instanceMaterials != null)
		{
			foreach (global::UnityEngine.Material material in this.instanceMaterials)
			{
				try
				{
					global::UnityEngine.Object.DestroyImmediate(material);
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogError(ex2, this);
				}
			}
			this.instanceMaterials.Clear();
			this.instanceMaterials = null;
		}
		if (this.depthTextureModeHold != null)
		{
			try
			{
				this.depthTextureModeHold.Dispose();
			}
			catch (global::System.Exception ex3)
			{
				global::UnityEngine.Debug.LogError(ex3, this);
			}
			finally
			{
				this.depthTextureModeHold = null;
			}
		}
		try
		{
			global::UnityEngine.Object.Destroy(reference);
		}
		catch (global::System.Exception ex4)
		{
			global::UnityEngine.Debug.LogError(ex4);
		}
		finally
		{
			reference = null;
		}
	}

	// Token: 0x17000688 RID: 1672
	// (get) Token: 0x060017E4 RID: 6116
	public abstract bool allow { get; }

	// Token: 0x060017E5 RID: 6117
	protected abstract void Configure();

	// Token: 0x060017E6 RID: 6118
	protected abstract bool Blit(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst);

	// Token: 0x060017E7 RID: 6119
	protected abstract void DeConfigure();

	// Token: 0x060017E8 RID: 6120 RVA: 0x00059F18 File Offset: 0x00058118
	internal bool Apply(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dst)
	{
		return this.Blit(src, dst);
	}

	// Token: 0x060017E9 RID: 6121 RVA: 0x00059F30 File Offset: 0x00058130
	protected bool Support(global::GFxImageEffect.Caps.Required required)
	{
		return this.Support(global::GFxImageEffect.Caps.Define(required));
	}

	// Token: 0x060017EA RID: 6122 RVA: 0x00059F40 File Offset: 0x00058140
	protected bool Support(global::GFxImageEffect.Caps.Required required, global::GFxImageEffect.Caps.ShaderModelVersion shaderModelVersion)
	{
		return this.Support(global::GFxImageEffect.Caps.Define(required, shaderModelVersion));
	}

	// Token: 0x060017EB RID: 6123 RVA: 0x00059F50 File Offset: 0x00058150
	protected bool Support(global::GFxImageEffect.Caps.Required required, global::GFxImageEffect.Caps.ShaderModelVersion shaderModelVersion, global::GFxImageEffect.Caps.Actions actions)
	{
		return this.Support(global::GFxImageEffect.Caps.Define(required, shaderModelVersion, actions));
	}

	// Token: 0x060017EC RID: 6124 RVA: 0x00059F60 File Offset: 0x00058160
	protected bool Support(global::GFxImageEffect.Caps.Required required, global::GFxImageEffect.Caps.Actions actions, global::GFxImageEffect.Caps.ShaderModelVersion shaderModelVersion)
	{
		return this.Support(global::GFxImageEffect.Caps.Define(required, shaderModelVersion, actions));
	}

	// Token: 0x060017ED RID: 6125 RVA: 0x00059F70 File Offset: 0x00058170
	protected bool Support(global::GFxImageEffect.Caps.Required required, global::GFxImageEffect.Caps.Actions actions)
	{
		return this.Support(global::GFxImageEffect.Caps.Define(required, actions));
	}

	// Token: 0x060017EE RID: 6126 RVA: 0x00059F80 File Offset: 0x00058180
	protected bool Support(global::GFxImageEffect.Caps.Actions actions)
	{
		global::GFxImageEffect.Caps.Actions actions2 = actions & global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals;
		bool flag;
		if (actions2 != global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_Depth)
		{
			if (actions2 != global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals)
			{
				this.TurnOffDepthTextureMode();
				flag = false;
			}
			else
			{
				flag = this.processor.depthTextureControl.Want(2, ref this.depthTextureModeHold);
			}
		}
		else
		{
			flag = this.processor.depthTextureControl.Want(1, ref this.depthTextureModeHold);
		}
		if (flag)
		{
			actions &= (global::GFxImageEffect.Caps.Actions)(-0x601);
		}
		if (actions == (global::GFxImageEffect.Caps.Actions)0)
		{
			return true;
		}
		this.TurnOffDepthTextureMode();
		this.noSupportReason = string.Format("Could not satisfy actions {0}", actions);
		return false;
	}

	// Token: 0x060017EF RID: 6127 RVA: 0x0005A02C File Offset: 0x0005822C
	protected bool Support(global::GFxImageEffect.Caps.Bits caps)
	{
		global::GFxImageEffect.Caps.Actions actions;
		if (global::GFxImageEffect.Caps.Info.CheckSupport(caps, out actions, ref this.noSupportReason))
		{
			return this.Support(actions);
		}
		this.TurnOffDepthTextureMode();
		return false;
	}

	// Token: 0x060017F0 RID: 6128 RVA: 0x0005A05C File Offset: 0x0005825C
	private void TurnOffDepthTextureMode()
	{
		if (this.depthTextureModeHold != null)
		{
			this.depthTextureModeHold.Dispose();
			this.depthTextureModeHold = null;
		}
	}

	// Token: 0x060017F1 RID: 6129 RVA: 0x0005A07C File Offset: 0x0005827C
	private global::GFxImageEffect.MaterialCheckResult RemoveMaterial(ref global::UnityEngine.Material material)
	{
		if (this.instanceMaterials == null || !this.instanceMaterials.Remove(material))
		{
			return global::GFxImageEffect.MaterialCheckResult.Fail;
		}
		material = null;
		return global::GFxImageEffect.MaterialCheckResult.FailDestroyed;
	}

	// Token: 0x060017F2 RID: 6130 RVA: 0x0005A0A4 File Offset: 0x000582A4
	private void CloneMaterial(ref global::UnityEngine.Material material)
	{
		global::UnityEngine.Material material2 = new global::UnityEngine.Material(material)
		{
			hideFlags = 4
		};
		material = material2;
	}

	// Token: 0x060017F3 RID: 6131 RVA: 0x0005A0C8 File Offset: 0x000582C8
	private global::GFxImageEffect.MaterialCheckResult AddMaterial(ref global::UnityEngine.Material material)
	{
		if (this.instanceMaterials == null)
		{
			this.CloneMaterial(ref material);
			this.instanceMaterials = new global::System.Collections.Generic.HashSet<global::UnityEngine.Material>();
			this.instanceMaterials.Add(material);
			return global::GFxImageEffect.MaterialCheckResult.SuccessCreated;
		}
		if (this.instanceMaterials.Contains(material))
		{
			return global::GFxImageEffect.MaterialCheckResult.Success;
		}
		this.CloneMaterial(ref material);
		return (!this.instanceMaterials.Add(material)) ? global::GFxImageEffect.MaterialCheckResult.Success : global::GFxImageEffect.MaterialCheckResult.SuccessCreated;
	}

	// Token: 0x060017F4 RID: 6132 RVA: 0x0005A138 File Offset: 0x00058338
	private global::GFxImageEffect.MaterialCheckResult CreateMaterial(global::UnityEngine.Shader shader, ref global::UnityEngine.Material material)
	{
		material = new global::UnityEngine.Material(shader)
		{
			hideFlags = 4
		};
		if (this.instanceMaterials == null)
		{
			this.instanceMaterials = new global::System.Collections.Generic.HashSet<global::UnityEngine.Material>();
			this.instanceMaterials.Add(material);
			return global::GFxImageEffect.MaterialCheckResult.SuccessCreated;
		}
		if (this.instanceMaterials.Add(material))
		{
			return global::GFxImageEffect.MaterialCheckResult.SuccessCreated;
		}
		return global::GFxImageEffect.MaterialCheckResult.Success;
	}

	// Token: 0x060017F5 RID: 6133 RVA: 0x0005A194 File Offset: 0x00058394
	protected static bool OK(global::GFxImageEffect.MaterialCheckResult result)
	{
		return (byte)(result & global::GFxImageEffect.MaterialCheckResult.Success) == 4;
	}

	// Token: 0x060017F6 RID: 6134 RVA: 0x0005A1A0 File Offset: 0x000583A0
	protected static bool OK(global::GFxImageEffect.MaterialCheckResult result, ref bool anyCreated)
	{
		if (!anyCreated && (byte)(result & (global::GFxImageEffect.MaterialCheckResult)2) == 2)
		{
			anyCreated = true;
		}
		return (byte)(result & global::GFxImageEffect.MaterialCheckResult.Success) == 4;
	}

	// Token: 0x060017F7 RID: 6135 RVA: 0x0005A1C0 File Offset: 0x000583C0
	protected global::GFxImageEffect.MaterialCheckResult CheckShaderAndCreateMaterial(global::UnityEngine.Shader s, ref global::UnityEngine.Material material)
	{
		if (!s)
		{
			global::UnityEngine.Debug.LogError("Missing shader in " + this.ToString());
			return this.RemoveMaterial(ref material);
		}
		if (!s.isSupported)
		{
			global::UnityEngine.Debug.LogError(string.Concat(new string[]
			{
				"The shader ",
				s.ToString(),
				" on effect ",
				this.ToString(),
				" is not supported on this platform!"
			}));
			return this.RemoveMaterial(ref material);
		}
		if (!material)
		{
			return this.CreateMaterial(s, ref material);
		}
		if (material.shader == s)
		{
			return this.AddMaterial(ref material);
		}
		return this.RemoveMaterial(ref material) | this.CreateMaterial(s, ref material);
	}

	// Token: 0x060017F8 RID: 6136 RVA: 0x0005A284 File Offset: 0x00058484
	protected void DrawBorder(global::UnityEngine.RenderTexture dest, global::UnityEngine.Material material)
	{
		global::UnityEngine.RenderTexture.active = dest;
		bool flag = true;
		global::UnityEngine.GL.PushMatrix();
		global::UnityEngine.GL.LoadOrtho();
		int width = dest.width;
		int height = dest.height;
		float num = 1f / ((float)width * 1f);
		float num2 = 1f / ((float)height * 1f);
		float num3;
		float num4;
		if (flag)
		{
			num3 = 1f;
			num4 = 0f;
		}
		else
		{
			num3 = 0f;
			num4 = 1f;
		}
		int i = 0;
		int passCount = material.passCount;
		while (i < passCount)
		{
			material.SetPass(i);
			float num5 = 0f;
			float num6 = 0f + num;
			float num7 = 0f;
			float num8 = 1f;
			global::UnityEngine.GL.Begin(7);
			global::UnityEngine.GL.TexCoord2(0f, num3);
			global::UnityEngine.GL.Vertex3(num5, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num3);
			global::UnityEngine.GL.Vertex3(num6, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num4);
			global::UnityEngine.GL.Vertex3(num6, num8, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num4);
			global::UnityEngine.GL.Vertex3(num5, num8, 0.1f);
			num5 = 1f - num;
			num6 = 1f;
			num7 = 0f;
			num8 = 1f;
			global::UnityEngine.GL.TexCoord2(0f, num3);
			global::UnityEngine.GL.Vertex3(num5, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num3);
			global::UnityEngine.GL.Vertex3(num6, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num4);
			global::UnityEngine.GL.Vertex3(num6, num8, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num4);
			global::UnityEngine.GL.Vertex3(num5, num8, 0.1f);
			num5 = 0f;
			num6 = 1f;
			num7 = 0f;
			num8 = 0f + num2;
			global::UnityEngine.GL.TexCoord2(0f, num3);
			global::UnityEngine.GL.Vertex3(num5, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num3);
			global::UnityEngine.GL.Vertex3(num6, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num4);
			global::UnityEngine.GL.Vertex3(num6, num8, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num4);
			global::UnityEngine.GL.Vertex3(num5, num8, 0.1f);
			num5 = 0f;
			num6 = 1f;
			num7 = 1f - num2;
			num8 = 1f;
			global::UnityEngine.GL.TexCoord2(0f, num3);
			global::UnityEngine.GL.Vertex3(num5, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num3);
			global::UnityEngine.GL.Vertex3(num6, num7, 0.1f);
			global::UnityEngine.GL.TexCoord2(1f, num4);
			global::UnityEngine.GL.Vertex3(num6, num8, 0.1f);
			global::UnityEngine.GL.TexCoord2(0f, num4);
			global::UnityEngine.GL.Vertex3(num5, num8, 0.1f);
			global::UnityEngine.GL.End();
			i++;
		}
		global::UnityEngine.GL.PopMatrix();
	}

	// Token: 0x04000C9E RID: 3230
	private const global::GFxImageEffect.MaterialCheckResult kMCR_NotInside = global::GFxImageEffect.MaterialCheckResult.Fail;

	// Token: 0x04000C9F RID: 3231
	private const global::GFxImageEffect.MaterialCheckResult kMCR_Removed = global::GFxImageEffect.MaterialCheckResult.FailDestroyed;

	// Token: 0x04000CA0 RID: 3232
	private const global::GFxImageEffect.MaterialCheckResult kMCR_Created = (global::GFxImageEffect.MaterialCheckResult)2;

	// Token: 0x04000CA1 RID: 3233
	private const global::GFxImageEffect.MaterialCheckResult kMCR_Success = global::GFxImageEffect.MaterialCheckResult.Success;

	// Token: 0x04000CA2 RID: 3234
	[global::System.NonSerialized]
	private bool isInstance;

	// Token: 0x04000CA3 RID: 3235
	[global::System.NonSerialized]
	protected global::GFxImageEffect prefab;

	// Token: 0x04000CA4 RID: 3236
	[global::System.NonSerialized]
	protected global::GFxPostProcessor processor;

	// Token: 0x04000CA5 RID: 3237
	[global::System.NonSerialized]
	protected global::System.Collections.Generic.HashSet<global::UnityEngine.Material> instanceMaterials;

	// Token: 0x04000CA6 RID: 3238
	[global::System.NonSerialized]
	internal bool supported;

	// Token: 0x04000CA7 RID: 3239
	[global::System.NonSerialized]
	private global::GFxCameraDepthTextureControl.Hold depthTextureModeHold;

	// Token: 0x04000CA8 RID: 3240
	[global::System.NonSerialized]
	public string noSupportReason;

	// Token: 0x020002A4 RID: 676
	protected static class Caps
	{
		// Token: 0x060017F9 RID: 6137 RVA: 0x0005A524 File Offset: 0x00058724
		static Caps()
		{
			global::GFxImageEffect.Caps.EnsureEnumWithinRange(typeof(global::GFxImageEffect.Caps.Required), 0, 5, 0x1F);
			global::GFxImageEffect.Caps.EnsureEnumWithinRange(typeof(global::GFxImageEffect.Caps.ShaderModelVersion), 5, 4, 0x1E0);
			global::GFxImageEffect.Caps.EnsureEnumWithinRange(typeof(global::GFxImageEffect.Caps.Actions), 9, 2, 0x600);
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0005A574 File Offset: 0x00058774
		public static global::GFxImageEffect.Caps.ShaderModelVersion ShaderModelVersionNumber(int majorMinor)
		{
			return global::GFxImageEffect.Caps.ShaderModelVersionNumber(majorMinor / 0xA, majorMinor % 0xA);
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x0005A584 File Offset: 0x00058784
		public static global::GFxImageEffect.Caps.ShaderModelVersion ShaderModelVersionNumber(int major, int minor)
		{
			major = ((major <= 0) ? 0 : major);
			minor = ((minor <= 0) ? 0 : minor);
			switch (major)
			{
			case 0:
				return (minor == 0) ? global::GFxImageEffect.Caps.ShaderModelVersion.NotRequired : global::GFxImageEffect.Caps.ShaderModelVersion.Exists;
			case 1:
				switch (minor)
				{
				case 0:
					return global::GFxImageEffect.Caps.ShaderModelVersion.v1_0;
				case 1:
				case 2:
					return global::GFxImageEffect.Caps.ShaderModelVersion.v1_1;
				case 3:
					return global::GFxImageEffect.Caps.ShaderModelVersion.v1_3;
				default:
					return global::GFxImageEffect.Caps.ShaderModelVersion.v1_4;
				}
				break;
			case 2:
			{
				int num = minor;
				if (num == 0)
				{
					return global::GFxImageEffect.Caps.ShaderModelVersion.v2_0;
				}
				if (num != 1)
				{
					return global::GFxImageEffect.Caps.ShaderModelVersion.v2_0b;
				}
				return global::GFxImageEffect.Caps.ShaderModelVersion.v2_0a;
			}
			case 3:
				return global::GFxImageEffect.Caps.ShaderModelVersion.v3_0;
			case 4:
				return (minor != 0) ? global::GFxImageEffect.Caps.ShaderModelVersion.v4_1 : global::GFxImageEffect.Caps.ShaderModelVersion.v4_0;
			case 5:
				return global::GFxImageEffect.Caps.ShaderModelVersion.v5_0;
			default:
				return global::GFxImageEffect.Caps.ShaderModelVersion.vNewer;
			}
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0005A664 File Offset: 0x00058864
		public static int ShaderModelVersionNumber(global::GFxImageEffect.Caps.ShaderModelVersion version)
		{
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.NotRequired)
			{
				return 0;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.Exists)
			{
				return 1;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v1_0)
			{
				return 0xA;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v1_1)
			{
				return 0xB;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v1_3)
			{
				return 0xD;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v1_4)
			{
				return 0xE;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v2_0)
			{
				return 0x14;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v2_0a)
			{
				return 0x15;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v2_0b)
			{
				return 0x16;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v3_0)
			{
				return 0x1E;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v4_0)
			{
				return 0x28;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v4_1)
			{
				return 0x29;
			}
			if (version == global::GFxImageEffect.Caps.ShaderModelVersion.v5_0)
			{
				return 0x32;
			}
			if (version != global::GFxImageEffect.Caps.ShaderModelVersion.vNewer)
			{
				throw new global::System.ArgumentOutOfRangeException("version");
			}
			return 0x33;
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x0005A738 File Offset: 0x00058938
		private static void EnsureEnumWithinRange(global::System.Type enumType, int bitStart, int bitCount, int mask)
		{
			foreach (object obj in global::System.Enum.GetValues(enumType))
			{
				long num = global::System.Convert.ToInt64(obj);
				if ((num & (long)mask) != num)
				{
					throw new global::System.InvalidProgramException(string.Format("{0}.{1} [ VALUE {2:X8} WITH BITWISE AND MASK {3:X8} EQUALS {4:X8} NOT THE VALUE {2:X8} ] -- OUT OF RANGE ENUM VALUE", new object[]
					{
						enumType.FullName,
						obj,
						num,
						mask,
						num & (long)mask
					}));
				}
			}
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x0005A7F0 File Offset: 0x000589F0
		public static global::GFxImageEffect.Caps.Bits Define(global::GFxImageEffect.Caps.Required requirements, global::GFxImageEffect.Caps.ShaderModelVersion minimumShaderModelVersion, global::GFxImageEffect.Caps.Actions actions)
		{
			return (global::GFxImageEffect.Caps.Bits)(((requirements & (global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth | global::GFxImageEffect.Caps.Required.ComputeShaders)) | (global::GFxImageEffect.Caps.Required)(minimumShaderModelVersion & (global::GFxImageEffect.Caps.ShaderModelVersion)0x1E0) | (global::GFxImageEffect.Caps.Required)(actions & global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals)) & (global::GFxImageEffect.Caps.Required)0x7FF);
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x0005A80C File Offset: 0x00058A0C
		public static global::GFxImageEffect.Caps.Bits Define(global::GFxImageEffect.Caps.Required requirements, global::GFxImageEffect.Caps.Actions actions, global::GFxImageEffect.Caps.ShaderModelVersion minimumShaderModelVersion)
		{
			return (global::GFxImageEffect.Caps.Bits)(((requirements & (global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth | global::GFxImageEffect.Caps.Required.ComputeShaders)) | (global::GFxImageEffect.Caps.Required)(minimumShaderModelVersion & (global::GFxImageEffect.Caps.ShaderModelVersion)0x1E0) | (global::GFxImageEffect.Caps.Required)(actions & global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals)) & (global::GFxImageEffect.Caps.Required)0x7FF);
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0005A828 File Offset: 0x00058A28
		public static global::GFxImageEffect.Caps.Bits Define(global::GFxImageEffect.Caps.Required requirements, global::GFxImageEffect.Caps.ShaderModelVersion minimumShaderModelVersion)
		{
			return (global::GFxImageEffect.Caps.Bits)(((requirements & (global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth | global::GFxImageEffect.Caps.Required.ComputeShaders)) | (global::GFxImageEffect.Caps.Required)(minimumShaderModelVersion & (global::GFxImageEffect.Caps.ShaderModelVersion)0x1E0)) & (global::GFxImageEffect.Caps.Required)0x7FF);
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x0005A83C File Offset: 0x00058A3C
		public static global::GFxImageEffect.Caps.Bits Define(global::GFxImageEffect.Caps.Required requirements, global::GFxImageEffect.Caps.Actions actions)
		{
			return (global::GFxImageEffect.Caps.Bits)(((requirements & (global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth | global::GFxImageEffect.Caps.Required.ComputeShaders)) | (global::GFxImageEffect.Caps.Required)(actions & global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals)) & (global::GFxImageEffect.Caps.Required)0x7FF);
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0005A850 File Offset: 0x00058A50
		public static global::GFxImageEffect.Caps.Bits Define(global::GFxImageEffect.Caps.Required requirements)
		{
			return (global::GFxImageEffect.Caps.Bits)(requirements & (global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth | global::GFxImageEffect.Caps.Required.ComputeShaders) & (global::GFxImageEffect.Caps.Required)0x7FF);
		}

		// Token: 0x04000CA9 RID: 3241
		private const int kSupportBitStart = 0;

		// Token: 0x04000CAA RID: 3242
		private const int kSupportBitCount = 5;

		// Token: 0x04000CAB RID: 3243
		private const int kShaderModelBitStart = 5;

		// Token: 0x04000CAC RID: 3244
		private const int kShaderModelBitCount = 4;

		// Token: 0x04000CAD RID: 3245
		private const int kRequestBitStart = 9;

		// Token: 0x04000CAE RID: 3246
		private const int kRequestBitCount = 2;

		// Token: 0x04000CAF RID: 3247
		private const global::GFxImageEffect.Caps.Bits kBits_Required = (global::GFxImageEffect.Caps.Bits)0x1F;

		// Token: 0x04000CB0 RID: 3248
		private const global::GFxImageEffect.Caps.Bits kBits_ShaderModelVersion = (global::GFxImageEffect.Caps.Bits)0x1E0;

		// Token: 0x04000CB1 RID: 3249
		private const global::GFxImageEffect.Caps.Bits kBits_Actions = (global::GFxImageEffect.Caps.Bits)0x600;

		// Token: 0x04000CB2 RID: 3250
		private const global::GFxImageEffect.Caps.Required kMask_Required = global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTargetHDR | global::GFxImageEffect.Caps.Required.RenderTarget | global::GFxImageEffect.Caps.Required.RenderTargetDepth | global::GFxImageEffect.Caps.Required.ComputeShaders;

		// Token: 0x04000CB3 RID: 3251
		private const global::GFxImageEffect.Caps.ShaderModelVersion kMask_ShaderModelVersion = (global::GFxImageEffect.Caps.ShaderModelVersion)0x1E0;

		// Token: 0x04000CB4 RID: 3252
		private const global::GFxImageEffect.Caps.Actions kMask_Actions = global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals;

		// Token: 0x04000CB5 RID: 3253
		public const global::GFxImageEffect.Caps.Actions kCameraDepthTextureModeActionsMask = global::GFxImageEffect.Caps.Actions.Let_Camera_DepthTextureMode_DepthNormals;

		// Token: 0x04000CB6 RID: 3254
		private const global::GFxImageEffect.Caps.Bits kBits_Mask = (global::GFxImageEffect.Caps.Bits)0x7FF;

		// Token: 0x04000CB7 RID: 3255
		public const global::GFxImageEffect.Caps.Required kRequired = global::GFxImageEffect.Caps.Required.ImageEffects | global::GFxImageEffect.Caps.Required.RenderTarget;

		// Token: 0x04000CB8 RID: 3256
		public const global::GFxImageEffect.Caps.Bits kDefaultCaps = (global::GFxImageEffect.Caps.Bits)5;

		// Token: 0x020002A5 RID: 677
		[global::System.Flags]
		public enum Required
		{
			// Token: 0x04000CBA RID: 3258
			ImageEffects = 1,
			// Token: 0x04000CBB RID: 3259
			RenderTargetHDR = 2,
			// Token: 0x04000CBC RID: 3260
			RenderTarget = 4,
			// Token: 0x04000CBD RID: 3261
			RenderTargetDepth = 8,
			// Token: 0x04000CBE RID: 3262
			ComputeShaders = 0x10
		}

		// Token: 0x020002A6 RID: 678
		public enum ShaderModelVersion
		{
			// Token: 0x04000CC0 RID: 3264
			NotRequired,
			// Token: 0x04000CC1 RID: 3265
			Exists = 0x20,
			// Token: 0x04000CC2 RID: 3266
			v1_0 = 0x40,
			// Token: 0x04000CC3 RID: 3267
			v1_1 = 0x60,
			// Token: 0x04000CC4 RID: 3268
			v1_3 = 0x80,
			// Token: 0x04000CC5 RID: 3269
			v1_4 = 0xA0,
			// Token: 0x04000CC6 RID: 3270
			v2_0 = 0xC0,
			// Token: 0x04000CC7 RID: 3271
			v2_0a = 0xE0,
			// Token: 0x04000CC8 RID: 3272
			v2_0b = 0x100,
			// Token: 0x04000CC9 RID: 3273
			v3_0 = 0x120,
			// Token: 0x04000CCA RID: 3274
			v4_0 = 0x140,
			// Token: 0x04000CCB RID: 3275
			v4_1 = 0x160,
			// Token: 0x04000CCC RID: 3276
			v5_0 = 0x180,
			// Token: 0x04000CCD RID: 3277
			vNewer = 0x1A0
		}

		// Token: 0x020002A7 RID: 679
		[global::System.Flags]
		public enum Actions
		{
			// Token: 0x04000CCF RID: 3279
			Let_Camera_DepthTextureMode_Depth = 0x200,
			// Token: 0x04000CD0 RID: 3280
			Let_Camera_DepthTextureMode_DepthNormals = 0x600
		}

		// Token: 0x020002A8 RID: 680
		public enum Bits
		{

		}

		// Token: 0x020002A9 RID: 681
		public static class Info
		{
			// Token: 0x06001803 RID: 6147 RVA: 0x0005A85C File Offset: 0x00058A5C
			static Info()
			{
				global::GFxImageEffect.Caps.Info.supportsDirectX10 = (global::GFxImageEffect.Caps.Info.shaderModelVersion >= global::GFxImageEffect.Caps.ShaderModelVersion.v4_0);
				global::GFxImageEffect.Caps.Info.supportsDirectX11 = (global::GFxImageEffect.Caps.Info.supportsComputeShaders && global::GFxImageEffect.Caps.Info.shaderModelVersion >= global::GFxImageEffect.Caps.ShaderModelVersion.v5_0);
				global::GFxImageEffect.Caps.Info.availableRequirements = (((!global::GFxImageEffect.Caps.Info.supportsHDRTextures) ? ((global::GFxImageEffect.Caps.Required)0) : global::GFxImageEffect.Caps.Required.RenderTargetHDR) | ((!global::GFxImageEffect.Caps.Info.supportsImageEffects) ? ((global::GFxImageEffect.Caps.Required)0) : global::GFxImageEffect.Caps.Required.ImageEffects) | ((!global::GFxImageEffect.Caps.Info.supportsRenderTextures) ? ((global::GFxImageEffect.Caps.Required)0) : global::GFxImageEffect.Caps.Required.RenderTarget) | ((!global::GFxImageEffect.Caps.Info.supportsDepth) ? ((global::GFxImageEffect.Caps.Required)0) : global::GFxImageEffect.Caps.Required.RenderTargetDepth) | ((!global::GFxImageEffect.Caps.Info.supportsComputeShaders) ? ((global::GFxImageEffect.Caps.Required)0) : global::GFxImageEffect.Caps.Required.ComputeShaders));
			}

			// Token: 0x06001804 RID: 6148 RVA: 0x0005A940 File Offset: 0x00058B40
			public static bool CheckSupport(global::GFxImageEffect.Caps.Bits bits, out global::GFxImageEffect.Caps.Actions actions, ref string failString)
			{
				actions = (global::GFxImageEffect.Caps.Actions)(bits & (global::GFxImageEffect.Caps.Bits)0x600);
				global::GFxImageEffect.Caps.ShaderModelVersion shaderModelVersion = (global::GFxImageEffect.Caps.ShaderModelVersion)(bits & (global::GFxImageEffect.Caps.Bits)0x1E0);
				if (global::GFxImageEffect.Caps.Info.shaderModelVersion < shaderModelVersion)
				{
					failString = string.Format("Shader model is {0}, wanted {1}", global::GFxImageEffect.Caps.Info.shaderModelVersion, shaderModelVersion);
					return false;
				}
				global::GFxImageEffect.Caps.Required required = (global::GFxImageEffect.Caps.Required)(bits & (global::GFxImageEffect.Caps.Bits)0x1F);
				global::GFxImageEffect.Caps.Required required2 = required & global::GFxImageEffect.Caps.Info.availableRequirements;
				if (required2 == required)
				{
					return true;
				}
				failString = string.Format("The requirements {0} are not supported", required & ~required2);
				return false;
			}

			// Token: 0x06001805 RID: 6149 RVA: 0x0005A9B4 File Offset: 0x00058BB4
			public static bool CheckSupport(global::GFxImageEffect.Caps.Bits bits, out global::GFxImageEffect.Caps.Actions actions)
			{
				actions = (global::GFxImageEffect.Caps.Actions)(bits & (global::GFxImageEffect.Caps.Bits)0x600);
				if (global::GFxImageEffect.Caps.Info.shaderModelVersion < (global::GFxImageEffect.Caps.ShaderModelVersion)(bits & (global::GFxImageEffect.Caps.Bits)0x1E0))
				{
					return false;
				}
				global::GFxImageEffect.Caps.Required required = (global::GFxImageEffect.Caps.Required)(bits & (global::GFxImageEffect.Caps.Bits)0x1F);
				return (required & global::GFxImageEffect.Caps.Info.availableRequirements) == required;
			}

			// Token: 0x04000CD2 RID: 3282
			public static readonly bool supportsHDRTextures = global::UnityEngine.SystemInfo.SupportsRenderTextureFormat(2);

			// Token: 0x04000CD3 RID: 3283
			public static readonly bool supportsImageEffects = global::UnityEngine.SystemInfo.supportsImageEffects;

			// Token: 0x04000CD4 RID: 3284
			public static readonly bool supportsRenderTextures = global::UnityEngine.SystemInfo.supportsRenderTextures;

			// Token: 0x04000CD5 RID: 3285
			public static readonly bool supportsDepth = global::UnityEngine.SystemInfo.SupportsRenderTextureFormat(1);

			// Token: 0x04000CD6 RID: 3286
			public static readonly bool supportsComputeShaders = global::UnityEngine.SystemInfo.supportsComputeShaders;

			// Token: 0x04000CD7 RID: 3287
			public static readonly bool supportsDirectX10;

			// Token: 0x04000CD8 RID: 3288
			public static readonly bool supportsDirectX11;

			// Token: 0x04000CD9 RID: 3289
			public static readonly global::GFxImageEffect.Caps.ShaderModelVersion shaderModelVersion = global::GFxImageEffect.Caps.ShaderModelVersionNumber(global::UnityEngine.SystemInfo.graphicsShaderLevel);

			// Token: 0x04000CDA RID: 3290
			public static readonly global::GFxImageEffect.Caps.Required availableRequirements;
		}
	}

	// Token: 0x020002AA RID: 682
	protected struct MatVarFloat
	{
		// Token: 0x06001806 RID: 6150 RVA: 0x0005A9EC File Offset: 0x00058BEC
		public MatVarFloat(string name)
		{
			this.name = name;
			this.flags = 0;
			this._value = (this._setValue = 0f);
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x0005AA1C File Offset: 0x00058C1C
		public MatVarFloat(string name, float defaultValue)
		{
			this.name = name;
			this.flags = 2;
			this._setValue = defaultValue;
			this._value = defaultValue;
		}

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06001808 RID: 6152 RVA: 0x0005AA48 File Offset: 0x00058C48
		public bool dirty
		{
			get
			{
				return (this.flags & 1) != 1;
			}
		}

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06001809 RID: 6153 RVA: 0x0005AA58 File Offset: 0x00058C58
		// (set) Token: 0x0600180A RID: 6154 RVA: 0x0005AA60 File Offset: 0x00058C60
		public float value
		{
			get
			{
				return this._value;
			}
			set
			{
				if ((this.flags & 4) == 4)
				{
					if ((this.flags & 1) == 1)
					{
						if (this._value != value)
						{
							this.flags &= 6;
							this._value = value;
						}
					}
					else
					{
						this._value = value;
						if (this._value == this._setValue)
						{
							this.flags |= 1;
						}
						else
						{
							this.flags &= 6;
						}
					}
				}
				else
				{
					this._value = value;
				}
				this.flags |= 2;
			}
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0005AB08 File Offset: 0x00058D08
		public void ForceBind(global::UnityEngine.Material material)
		{
			if ((this.flags & 2) == 2)
			{
				material.SetFloat(this.name, this._value);
			}
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x0005AB38 File Offset: 0x00058D38
		public void Bind(global::UnityEngine.Material material)
		{
			if ((this.flags & 4) == 4)
			{
				if ((this.flags & 1) != 1)
				{
					material.SetFloat(this.name, this._value);
					this._setValue = this.value;
					this.flags |= 1;
				}
			}
			else if ((this.flags & 2) == 2)
			{
				material.SetFloat(this.name, this.value);
				this.flags |= 5;
				this._setValue = this._value;
			}
		}

		// Token: 0x1700068B RID: 1675
		public float this[global::UnityEngine.Material material]
		{
			set
			{
				this.value = value;
				this.Bind(material);
			}
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x0005ABE0 File Offset: 0x00058DE0
		public void Shutdown()
		{
			this = default(global::GFxImageEffect.MatVarFloat);
		}

		// Token: 0x04000CDB RID: 3291
		private const byte kClean = 1;

		// Token: 0x04000CDC RID: 3292
		private const byte kSetOnce = 2;

		// Token: 0x04000CDD RID: 3293
		private const byte kOnce = 4;

		// Token: 0x04000CDE RID: 3294
		private const byte kAllFlags = 7;

		// Token: 0x04000CDF RID: 3295
		private const byte kDirty = 6;

		// Token: 0x04000CE0 RID: 3296
		private string name;

		// Token: 0x04000CE1 RID: 3297
		private float _value;

		// Token: 0x04000CE2 RID: 3298
		private float _setValue;

		// Token: 0x04000CE3 RID: 3299
		private byte flags;
	}

	// Token: 0x020002AB RID: 683
	protected struct MatVarTexture
	{
		// Token: 0x0600180F RID: 6159 RVA: 0x0005ABFC File Offset: 0x00058DFC
		public MatVarTexture(string name)
		{
			this.name = name;
			this.flags = 0;
			this._value = (this._setValue = null);
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x0005AC28 File Offset: 0x00058E28
		public MatVarTexture(string name, global::UnityEngine.Texture defaultValue)
		{
			this.name = name;
			this.flags = 2;
			this._setValue = defaultValue;
			this._value = defaultValue;
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001811 RID: 6161 RVA: 0x0005AC54 File Offset: 0x00058E54
		public bool dirty
		{
			get
			{
				return (this.flags & 1) != 1;
			}
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06001812 RID: 6162 RVA: 0x0005AC64 File Offset: 0x00058E64
		// (set) Token: 0x06001813 RID: 6163 RVA: 0x0005AC6C File Offset: 0x00058E6C
		public global::UnityEngine.Texture value
		{
			get
			{
				return this._value;
			}
			set
			{
				if ((this.flags & 4) == 4)
				{
					if ((this.flags & 1) == 1)
					{
						if (this._value != value)
						{
							this.flags &= 6;
							this._value = value;
						}
					}
					else
					{
						this._value = value;
						if (this._value == this._setValue)
						{
							this.flags |= 1;
						}
						else
						{
							this.flags &= 6;
						}
					}
				}
				else
				{
					this._value = value;
				}
				this.flags |= 2;
			}
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x0005AD1C File Offset: 0x00058F1C
		public void ForceBind(global::UnityEngine.Material material)
		{
			if ((this.flags & 2) == 2)
			{
				material.SetTexture(this.name, this._value);
			}
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x0005AD4C File Offset: 0x00058F4C
		public void Bind(global::UnityEngine.Material material)
		{
			if ((this.flags & 4) == 4)
			{
				if ((this.flags & 1) != 1)
				{
					material.SetTexture(this.name, this._value);
					this._setValue = this.value;
					this.flags |= 1;
				}
			}
			else if ((this.flags & 2) == 2)
			{
				material.SetTexture(this.name, this.value);
				this.flags |= 5;
				this._setValue = this._value;
			}
		}

		// Token: 0x1700068E RID: 1678
		public global::UnityEngine.Texture this[global::UnityEngine.Material material]
		{
			set
			{
				this.value = value;
				this.Bind(material);
			}
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x0005ADF4 File Offset: 0x00058FF4
		public void Shutdown()
		{
			this = default(global::GFxImageEffect.MatVarTexture);
		}

		// Token: 0x04000CE4 RID: 3300
		private const byte kClean = 1;

		// Token: 0x04000CE5 RID: 3301
		private const byte kSetOnce = 2;

		// Token: 0x04000CE6 RID: 3302
		private const byte kOnce = 4;

		// Token: 0x04000CE7 RID: 3303
		private const byte kAllFlags = 7;

		// Token: 0x04000CE8 RID: 3304
		private const byte kDirty = 6;

		// Token: 0x04000CE9 RID: 3305
		private string name;

		// Token: 0x04000CEA RID: 3306
		private global::UnityEngine.Texture _value;

		// Token: 0x04000CEB RID: 3307
		private global::UnityEngine.Texture _setValue;

		// Token: 0x04000CEC RID: 3308
		private byte flags;
	}

	// Token: 0x020002AC RID: 684
	protected struct MatVarVector
	{
		// Token: 0x06001818 RID: 6168 RVA: 0x0005AE10 File Offset: 0x00059010
		public MatVarVector(string name)
		{
			this.name = name;
			this.once = false;
			this.flags = 0;
			this._value = (this._setValue = default(global::UnityEngine.Vector4));
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x0005AE4C File Offset: 0x0005904C
		public MatVarVector(string name, global::UnityEngine.Vector4 defaultValue)
		{
			this.name = name;
			this.once = false;
			this.flags = 0xF0;
			this._value.x = (this._setValue.x = defaultValue.x);
			this._value.y = (this._setValue.y = defaultValue.y);
			this._value.z = (this._setValue.z = defaultValue.z);
			this._value.w = (this._setValue.w = defaultValue.w);
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x0005AEF4 File Offset: 0x000590F4
		public MatVarVector(string name, global::UnityEngine.Color defaultValue)
		{
			this.name = name;
			this.once = false;
			this.flags = 0xF0;
			this._value.x = (this._setValue.x = defaultValue.r);
			this._value.y = (this._setValue.y = defaultValue.g);
			this._value.z = (this._setValue.z = defaultValue.b);
			this._value.w = (this._setValue.w = defaultValue.a);
		}

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x0600181B RID: 6171 RVA: 0x0005AF9C File Offset: 0x0005919C
		public bool dirty
		{
			get
			{
				return (this.flags & 0xF) != 0xF;
			}
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x0600181C RID: 6172 RVA: 0x0005AFB0 File Offset: 0x000591B0
		// (set) Token: 0x0600181D RID: 6173 RVA: 0x0005AFB8 File Offset: 0x000591B8
		public float r
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x0600181E RID: 6174 RVA: 0x0005AFC4 File Offset: 0x000591C4
		// (set) Token: 0x0600181F RID: 6175 RVA: 0x0005AFCC File Offset: 0x000591CC
		public float g
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06001820 RID: 6176 RVA: 0x0005AFD8 File Offset: 0x000591D8
		// (set) Token: 0x06001821 RID: 6177 RVA: 0x0005AFE0 File Offset: 0x000591E0
		public float b
		{
			get
			{
				return this.z;
			}
			set
			{
				this.z = value;
			}
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06001822 RID: 6178 RVA: 0x0005AFEC File Offset: 0x000591EC
		// (set) Token: 0x06001823 RID: 6179 RVA: 0x0005AFF4 File Offset: 0x000591F4
		public float a
		{
			get
			{
				return this.w;
			}
			set
			{
				this.w = value;
			}
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06001824 RID: 6180 RVA: 0x0005B000 File Offset: 0x00059200
		// (set) Token: 0x06001825 RID: 6181 RVA: 0x0005B058 File Offset: 0x00059258
		public global::UnityEngine.Color color
		{
			get
			{
				global::UnityEngine.Color result;
				result.r = this._value.x;
				result.g = this._value.y;
				result.b = this._value.z;
				result.a = this._value.w;
				return result;
			}
			set
			{
				global::UnityEngine.Vector4 value2;
				value2.x = value.r;
				value2.y = value.g;
				value2.z = value.b;
				value2.w = value.a;
				this.value = value2;
			}
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06001826 RID: 6182 RVA: 0x0005B0A4 File Offset: 0x000592A4
		// (set) Token: 0x06001827 RID: 6183 RVA: 0x0005B0B4 File Offset: 0x000592B4
		public float x
		{
			get
			{
				return this._value.x;
			}
			set
			{
				if (this.once)
				{
					if ((this.flags & 1) == 1)
					{
						if (this._value.x != value)
						{
							this._value.x = value;
							this.flags &= 0xFE;
						}
					}
					else
					{
						this._value.x = value;
						if (this._value.x == this._setValue.x)
						{
							this.flags |= 1;
						}
						else
						{
							this.flags &= 0xFE;
						}
					}
				}
				else
				{
					this._value.x = value;
				}
				this.flags |= 0x10;
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06001828 RID: 6184 RVA: 0x0005B180 File Offset: 0x00059380
		// (set) Token: 0x06001829 RID: 6185 RVA: 0x0005B190 File Offset: 0x00059390
		public float y
		{
			get
			{
				return this._value.y;
			}
			set
			{
				if (this.once)
				{
					if ((this.flags & 2) == 2)
					{
						if (this._value.y != value)
						{
							this._value.y = value;
							this.flags &= 0xFD;
						}
					}
					else
					{
						this._value.y = value;
						if (this._value.y == this._setValue.y)
						{
							this.flags |= 2;
						}
						else
						{
							this.flags &= 0xFD;
						}
					}
				}
				else
				{
					this._value.y = value;
				}
				this.flags |= 0x20;
			}
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x0600182A RID: 6186 RVA: 0x0005B25C File Offset: 0x0005945C
		// (set) Token: 0x0600182B RID: 6187 RVA: 0x0005B26C File Offset: 0x0005946C
		public float z
		{
			get
			{
				return this._value.z;
			}
			set
			{
				if (this.once)
				{
					if ((this.flags & 4) == 4)
					{
						if (this._value.z != value)
						{
							this._value.z = value;
							this.flags &= 0xFB;
						}
					}
					else
					{
						this._value.z = value;
						if (this._value.z == this._setValue.z)
						{
							this.flags |= 4;
						}
						else
						{
							this.flags &= 0xFB;
						}
					}
				}
				else
				{
					this._value.z = value;
				}
				this.flags |= 0x40;
			}
		}

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x0600182C RID: 6188 RVA: 0x0005B338 File Offset: 0x00059538
		// (set) Token: 0x0600182D RID: 6189 RVA: 0x0005B348 File Offset: 0x00059548
		public float w
		{
			get
			{
				return this._value.w;
			}
			set
			{
				if (this.once)
				{
					if ((this.flags & 8) == 8)
					{
						if (this._value.w != value)
						{
							this._value.w = value;
							this.flags &= 0xF7;
						}
					}
					else
					{
						this._value.w = value;
						if (this._value.w == this._setValue.w)
						{
							this.flags |= 8;
						}
						else
						{
							this.flags &= 0xF7;
						}
					}
				}
				else
				{
					this._value.w = value;
				}
				this.flags |= 0x80;
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x0600182E RID: 6190 RVA: 0x0005B418 File Offset: 0x00059618
		// (set) Token: 0x0600182F RID: 6191 RVA: 0x0005B420 File Offset: 0x00059620
		public global::UnityEngine.Vector4 value
		{
			get
			{
				return this._value;
			}
			set
			{
				if (this.once)
				{
					if ((this.flags & 1) == 1)
					{
						if (this._value.x != value.x)
						{
							this._value.x = value.x;
							this.flags &= 0xFE;
						}
					}
					else
					{
						this._value.x = value.x;
						if (this._value.x == this._setValue.x)
						{
							this.flags |= 1;
						}
						else
						{
							this.flags &= 0xFE;
						}
					}
					if ((this.flags & 2) == 2)
					{
						if (this._value.y != value.y)
						{
							this._value.y = value.y;
							this.flags &= 0xFD;
						}
					}
					else
					{
						this._value.y = value.y;
						if (this._value.y == this._setValue.y)
						{
							this.flags |= 2;
						}
						else
						{
							this.flags &= 0xFD;
						}
					}
					if ((this.flags & 4) == 4)
					{
						if (this._value.z != value.z)
						{
							this._value.z = value.z;
							this.flags &= 0xFB;
						}
					}
					else
					{
						this._value.z = value.z;
						if (this._value.z == this._setValue.z)
						{
							this.flags |= 4;
						}
						else
						{
							this.flags &= 0xFB;
						}
					}
					if ((this.flags & 8) == 8)
					{
						if (this._value.w != value.w)
						{
							this._value.w = value.w;
							this.flags &= 0xF7;
						}
					}
					else
					{
						this._value.w = value.w;
						if (this._value.w == this._setValue.w)
						{
							this.flags |= 8;
						}
						else
						{
							this.flags &= 0xF7;
						}
					}
				}
				else
				{
					this._value = value;
				}
				this.flags |= 0xF0;
			}
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x0005B6E4 File Offset: 0x000598E4
		public void ForceBind(global::UnityEngine.Material material)
		{
			int num = (int)(this.flags & 0xF0);
			int num2 = num;
			if (num2 != 0)
			{
				if (num2 != 0xF0)
				{
					global::UnityEngine.Vector4 vector = material.GetVector(this.name);
					if ((this.flags & 0x10) != 0x10)
					{
						this._value.x = vector.x;
					}
					if ((this.flags & 0x20) != 0x20)
					{
						this._value.y = vector.y;
					}
					if ((this.flags & 0x40) != 0x40)
					{
						this._value.z = vector.z;
					}
					if ((this.flags & 0x80) != 0x80)
					{
						this._value.w = vector.w;
					}
					this.flags |= 0xF0;
				}
				material.SetVector(this.name, this._value);
				return;
			}
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x0005B7E4 File Offset: 0x000599E4
		public void Read(global::UnityEngine.Material material)
		{
			this._value = material.GetVector(this.name);
			this._setValue.x = this._value.x;
			this._setValue.y = this._value.y;
			this._setValue.z = this._value.z;
			this._setValue.w = this._value.w;
			this.flags |= byte.MaxValue;
			this.once = true;
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x0005B878 File Offset: 0x00059A78
		public void Bind(global::UnityEngine.Material material)
		{
			if (this.once)
			{
				if ((this.flags & 0xF) != 0xF)
				{
					material.SetVector(this.name, this._value);
					this._setValue.x = this._value.x;
					this._setValue.y = this._value.y;
					this._setValue.z = this._value.z;
					this._setValue.w = this._value.w;
					this.flags |= 0xF;
				}
			}
			else
			{
				int num = (int)(this.flags & 0xF0);
				int num2 = num;
				if (num2 == 0)
				{
					return;
				}
				if (num2 != 0xF0)
				{
					global::UnityEngine.Vector4 vector = material.GetVector(this.name);
					if ((this.flags & 0x10) != 0x10)
					{
						this._value.x = vector.x;
					}
					if ((this.flags & 0x20) != 0x20)
					{
						this._value.y = vector.y;
					}
					if ((this.flags & 0x40) != 0x40)
					{
						this._value.z = vector.z;
					}
					if ((this.flags & 0x80) != 0x80)
					{
						this._value.w = vector.w;
					}
					this.flags |= 0xF0;
				}
				material.SetVector(this.name, this.value);
				this.once = true;
				this.flags |= 0xF;
				this._setValue = this._value;
			}
		}

		// Token: 0x1700069A RID: 1690
		public global::UnityEngine.Vector4 this[global::UnityEngine.Material material]
		{
			set
			{
				this.value = value;
				this.Bind(material);
			}
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x0005BA44 File Offset: 0x00059C44
		public void Shutdown()
		{
			this = default(global::GFxImageEffect.MatVarVector);
		}

		// Token: 0x04000CED RID: 3309
		private const byte kCleanX = 1;

		// Token: 0x04000CEE RID: 3310
		private const byte kCleanY = 2;

		// Token: 0x04000CEF RID: 3311
		private const byte kCleanZ = 4;

		// Token: 0x04000CF0 RID: 3312
		private const byte kCleanW = 8;

		// Token: 0x04000CF1 RID: 3313
		private const byte kSetOnceX = 0x10;

		// Token: 0x04000CF2 RID: 3314
		private const byte kSetOnceY = 0x20;

		// Token: 0x04000CF3 RID: 3315
		private const byte kSetOnceZ = 0x40;

		// Token: 0x04000CF4 RID: 3316
		private const byte kSetOnceW = 0x80;

		// Token: 0x04000CF5 RID: 3317
		private const byte kClean = 0xF;

		// Token: 0x04000CF6 RID: 3318
		private const byte kSetOnce = 0xF0;

		// Token: 0x04000CF7 RID: 3319
		private const byte kAllFlags = 0xFF;

		// Token: 0x04000CF8 RID: 3320
		private const byte kDirtyX = 0xFE;

		// Token: 0x04000CF9 RID: 3321
		private const byte kDirtyY = 0xFD;

		// Token: 0x04000CFA RID: 3322
		private const byte kDirtyZ = 0xFB;

		// Token: 0x04000CFB RID: 3323
		private const byte kDirtyW = 0xF7;

		// Token: 0x04000CFC RID: 3324
		private const byte kDirty = 0xF0;

		// Token: 0x04000CFD RID: 3325
		private string name;

		// Token: 0x04000CFE RID: 3326
		private global::UnityEngine.Vector4 _value;

		// Token: 0x04000CFF RID: 3327
		private global::UnityEngine.Vector4 _setValue;

		// Token: 0x04000D00 RID: 3328
		private bool once;

		// Token: 0x04000D01 RID: 3329
		private byte flags;
	}

	// Token: 0x020002AD RID: 685
	protected enum MaterialCheckResult : byte
	{
		// Token: 0x04000D03 RID: 3331
		FailDestroyed = 1,
		// Token: 0x04000D04 RID: 3332
		Fail = 0,
		// Token: 0x04000D05 RID: 3333
		Success = 4,
		// Token: 0x04000D06 RID: 3334
		SuccessCreated = 6,
		// Token: 0x04000D07 RID: 3335
		SuccessRecreated
	}

	// Token: 0x020002AE RID: 686
	public struct Scratch : global::System.IDisposable
	{
		// Token: 0x06001835 RID: 6197 RVA: 0x0005BA60 File Offset: 0x00059C60
		private Scratch(global::UnityEngine.RenderTexture target)
		{
			this.target = target;
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x0005BA6C File Offset: 0x00059C6C
		public Scratch(int width, int height)
		{
			this = new global::GFxImageEffect.Scratch(global::UnityEngine.RenderTexture.GetTemporary(width, height));
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x0005BA7C File Offset: 0x00059C7C
		public Scratch(int width, int height, int depthBuffer)
		{
			this = new global::GFxImageEffect.Scratch(global::UnityEngine.RenderTexture.GetTemporary(width, height, depthBuffer));
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x0005BA8C File Offset: 0x00059C8C
		public Scratch(int width, int height, int depthBuffer, global::UnityEngine.RenderTextureFormat format)
		{
			this = new global::GFxImageEffect.Scratch(global::UnityEngine.RenderTexture.GetTemporary(width, height, depthBuffer, format));
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x0005BAA0 File Offset: 0x00059CA0
		public Scratch(int width, int height, int depthBuffer, global::UnityEngine.RenderTextureFormat format, global::UnityEngine.RenderTextureReadWrite readWrite)
		{
			this = new global::GFxImageEffect.Scratch(global::UnityEngine.RenderTexture.GetTemporary(width, height, depthBuffer, format, readWrite));
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x0005BAB4 File Offset: 0x00059CB4
		public void Dispose()
		{
			global::UnityEngine.RenderTexture.ReleaseTemporary(this.target);
			this.target = null;
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x0005BAC8 File Offset: 0x00059CC8
		public static void Swap(ref global::GFxImageEffect.Scratch a, ref global::GFxImageEffect.Scratch b)
		{
			global::UnityEngine.RenderTexture renderTexture = b.target;
			b.target = a.target;
			a.target = renderTexture;
		}

		// Token: 0x04000D08 RID: 3336
		public global::UnityEngine.RenderTexture target;
	}
}
