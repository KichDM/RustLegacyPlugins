using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000842 RID: 2114
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Sprite/Texture")]
[global::UnityEngine.ExecuteInEditMode]
public class dfTextureSprite : global::dfControl
{
	// Token: 0x06004915 RID: 18709 RVA: 0x00110DCC File Offset: 0x0010EFCC
	public dfTextureSprite()
	{
	}

	// Token: 0x06004916 RID: 18710 RVA: 0x00110DE0 File Offset: 0x0010EFE0
	// Note: this type is marked as 'beforefieldinit'.
	static dfTextureSprite()
	{
	}

	// Token: 0x14000059 RID: 89
	// (add) Token: 0x06004917 RID: 18711 RVA: 0x00110DF8 File Offset: 0x0010EFF8
	// (remove) Token: 0x06004918 RID: 18712 RVA: 0x00110E14 File Offset: 0x0010F014
	public event global::PropertyChangedEventHandler<global::UnityEngine.Texture2D> TextureChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TextureChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Texture2D>)global::System.Delegate.Combine(this.TextureChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TextureChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Texture2D>)global::System.Delegate.Remove(this.TextureChanged, value);
		}
	}

	// Token: 0x17000DB5 RID: 3509
	// (get) Token: 0x06004919 RID: 18713 RVA: 0x00110E30 File Offset: 0x0010F030
	// (set) Token: 0x0600491A RID: 18714 RVA: 0x00110E38 File Offset: 0x0010F038
	public global::UnityEngine.Texture2D Texture
	{
		get
		{
			return this.texture;
		}
		set
		{
			if (value != this.texture)
			{
				this.texture = value;
				this.Invalidate();
				if (value != null && this.size.sqrMagnitude <= 1E-45f)
				{
					this.size = new global::UnityEngine.Vector2((float)value.width, (float)value.height);
				}
				this.OnTextureChanged(value);
			}
		}
	}

	// Token: 0x17000DB6 RID: 3510
	// (get) Token: 0x0600491B RID: 18715 RVA: 0x00110EA4 File Offset: 0x0010F0A4
	// (set) Token: 0x0600491C RID: 18716 RVA: 0x00110EAC File Offset: 0x0010F0AC
	public global::UnityEngine.Material Material
	{
		get
		{
			return this.material;
		}
		set
		{
			if (value != this.material)
			{
				this.disposeCreatedMaterial();
				this.renderMaterial = null;
				this.material = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DB7 RID: 3511
	// (get) Token: 0x0600491D RID: 18717 RVA: 0x00110EDC File Offset: 0x0010F0DC
	// (set) Token: 0x0600491E RID: 18718 RVA: 0x00110EE4 File Offset: 0x0010F0E4
	public global::dfSpriteFlip Flip
	{
		get
		{
			return this.flip;
		}
		set
		{
			if (value != this.flip)
			{
				this.flip = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DB8 RID: 3512
	// (get) Token: 0x0600491F RID: 18719 RVA: 0x00110F00 File Offset: 0x0010F100
	// (set) Token: 0x06004920 RID: 18720 RVA: 0x00110F08 File Offset: 0x0010F108
	public global::dfFillDirection FillDirection
	{
		get
		{
			return this.fillDirection;
		}
		set
		{
			if (value != this.fillDirection)
			{
				this.fillDirection = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DB9 RID: 3513
	// (get) Token: 0x06004921 RID: 18721 RVA: 0x00110F24 File Offset: 0x0010F124
	// (set) Token: 0x06004922 RID: 18722 RVA: 0x00110F2C File Offset: 0x0010F12C
	public float FillAmount
	{
		get
		{
			return this.fillAmount;
		}
		set
		{
			if (!global::UnityEngine.Mathf.Approximately(value, this.fillAmount))
			{
				this.fillAmount = global::UnityEngine.Mathf.Max(0f, global::UnityEngine.Mathf.Min(1f, value));
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DBA RID: 3514
	// (get) Token: 0x06004923 RID: 18723 RVA: 0x00110F6C File Offset: 0x0010F16C
	// (set) Token: 0x06004924 RID: 18724 RVA: 0x00110F74 File Offset: 0x0010F174
	public bool InvertFill
	{
		get
		{
			return this.invertFill;
		}
		set
		{
			if (value != this.invertFill)
			{
				this.invertFill = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DBB RID: 3515
	// (get) Token: 0x06004925 RID: 18725 RVA: 0x00110F90 File Offset: 0x0010F190
	public global::UnityEngine.Material RenderMaterial
	{
		get
		{
			return this.renderMaterial;
		}
	}

	// Token: 0x06004926 RID: 18726 RVA: 0x00110F98 File Offset: 0x0010F198
	public override void OnEnable()
	{
		base.OnEnable();
		this.renderMaterial = null;
	}

	// Token: 0x06004927 RID: 18727 RVA: 0x00110FA8 File Offset: 0x0010F1A8
	public override void OnDestroy()
	{
		base.OnDestroy();
		if (this.renderMaterial != null)
		{
			global::UnityEngine.Object.DestroyImmediate(this.renderMaterial);
			this.renderMaterial = null;
		}
	}

	// Token: 0x06004928 RID: 18728 RVA: 0x00110FD4 File Offset: 0x0010F1D4
	public override void OnDisable()
	{
		base.OnDisable();
		this.disposeCreatedMaterial();
		if (global::UnityEngine.Application.isPlaying && this.renderMaterial != null)
		{
			global::UnityEngine.Object.DestroyImmediate(this.renderMaterial);
			this.renderMaterial = null;
		}
	}

	// Token: 0x06004929 RID: 18729 RVA: 0x0011101C File Offset: 0x0010F21C
	protected override void OnRebuildRenderData()
	{
		base.OnRebuildRenderData();
		if (this.texture == null)
		{
			return;
		}
		this.ensureMaterial();
		if (this.material == null)
		{
			return;
		}
		if (this.renderMaterial == null)
		{
			this.renderMaterial = new global::UnityEngine.Material(this.material)
			{
				hideFlags = 4,
				name = this.material.name + " (copy)"
			};
		}
		this.renderMaterial.mainTexture = this.texture;
		this.renderData.Material = this.renderMaterial;
		float num = base.PixelsToUnits();
		float num2 = 0f;
		float num3 = 0f;
		float num4 = this.size.x * num;
		float num5 = -this.size.y * num;
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(this.size).RoundToInt() * num;
		this.renderData.Vertices.Add(new global::UnityEngine.Vector3(num2, num3, 0f) + vector);
		this.renderData.Vertices.Add(new global::UnityEngine.Vector3(num4, num3, 0f) + vector);
		this.renderData.Vertices.Add(new global::UnityEngine.Vector3(num4, num5, 0f) + vector);
		this.renderData.Vertices.Add(new global::UnityEngine.Vector3(num2, num5, 0f) + vector);
		this.renderData.Triangles.AddRange(global::dfTextureSprite.TRIANGLE_INDICES);
		this.rebuildUV(this.renderData);
		global::UnityEngine.Color32 item = base.ApplyOpacity(this.color);
		this.renderData.Colors.Add(item);
		this.renderData.Colors.Add(item);
		this.renderData.Colors.Add(item);
		this.renderData.Colors.Add(item);
		if (this.fillAmount < 1f)
		{
			this.doFill(this.renderData);
		}
	}

	// Token: 0x0600492A RID: 18730 RVA: 0x00111238 File Offset: 0x0010F438
	private void disposeCreatedMaterial()
	{
		if (this.createdRuntimeMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.material);
			this.material = null;
			this.createdRuntimeMaterial = false;
		}
	}

	// Token: 0x0600492B RID: 18731 RVA: 0x0011126C File Offset: 0x0010F46C
	private void rebuildUV(global::dfRenderData renderData)
	{
		global::dfList<global::UnityEngine.Vector2> uv = renderData.UV;
		uv.Add(new global::UnityEngine.Vector2(0f, 1f));
		uv.Add(new global::UnityEngine.Vector2(1f, 1f));
		uv.Add(new global::UnityEngine.Vector2(1f, 0f));
		uv.Add(new global::UnityEngine.Vector2(0f, 0f));
		global::UnityEngine.Vector2 value = global::UnityEngine.Vector2.zero;
		if (this.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
		{
			value = uv[1];
			uv[1] = uv[0];
			uv[0] = value;
			value = uv[3];
			uv[3] = uv[2];
			uv[2] = value;
		}
		if (this.flip.IsSet(global::dfSpriteFlip.FlipVertical))
		{
			value = uv[0];
			uv[0] = uv[3];
			uv[3] = value;
			value = uv[1];
			uv[1] = uv[2];
			uv[2] = value;
		}
	}

	// Token: 0x0600492C RID: 18732 RVA: 0x00111374 File Offset: 0x0010F574
	private void doFill(global::dfRenderData renderData)
	{
		global::dfList<global::UnityEngine.Vector3> vertices = renderData.Vertices;
		global::dfList<global::UnityEngine.Vector2> uv = renderData.UV;
		int index = 0;
		int index2 = 1;
		int index3 = 3;
		int index4 = 2;
		if (this.invertFill)
		{
			if (this.fillDirection == global::dfFillDirection.Horizontal)
			{
				index = 1;
				index2 = 0;
				index3 = 2;
				index4 = 3;
			}
			else
			{
				index = 3;
				index2 = 2;
				index3 = 0;
				index4 = 1;
			}
		}
		if (this.fillDirection == global::dfFillDirection.Horizontal)
		{
			vertices[index2] = global::UnityEngine.Vector3.Lerp(vertices[index2], vertices[index], 1f - this.fillAmount);
			vertices[index4] = global::UnityEngine.Vector3.Lerp(vertices[index4], vertices[index3], 1f - this.fillAmount);
			uv[index2] = global::UnityEngine.Vector2.Lerp(uv[index2], uv[index], 1f - this.fillAmount);
			uv[index4] = global::UnityEngine.Vector2.Lerp(uv[index4], uv[index3], 1f - this.fillAmount);
		}
		else
		{
			vertices[index3] = global::UnityEngine.Vector3.Lerp(vertices[index3], vertices[index], 1f - this.fillAmount);
			vertices[index4] = global::UnityEngine.Vector3.Lerp(vertices[index4], vertices[index2], 1f - this.fillAmount);
			uv[index3] = global::UnityEngine.Vector2.Lerp(uv[index3], uv[index], 1f - this.fillAmount);
			uv[index4] = global::UnityEngine.Vector2.Lerp(uv[index4], uv[index2], 1f - this.fillAmount);
		}
	}

	// Token: 0x0600492D RID: 18733 RVA: 0x00111518 File Offset: 0x0010F718
	protected internal virtual void OnTextureChanged(global::UnityEngine.Texture2D value)
	{
		base.SignalHierarchy("OnTextureChanged", new object[]
		{
			value
		});
		if (this.TextureChanged != null)
		{
			this.TextureChanged(this, value);
		}
	}

	// Token: 0x0600492E RID: 18734 RVA: 0x00111554 File Offset: 0x0010F754
	private void ensureMaterial()
	{
		if (this.material != null || this.texture == null)
		{
			return;
		}
		global::UnityEngine.Shader shader = global::UnityEngine.Shader.Find("Daikon Forge/Default UI Shader");
		if (shader == null)
		{
			global::UnityEngine.Debug.LogError("Failed to find default shader");
			return;
		}
		this.material = new global::UnityEngine.Material(shader)
		{
			name = "Default Texture Shader",
			hideFlags = 4,
			mainTexture = this.texture
		};
		this.createdRuntimeMaterial = true;
	}

	// Token: 0x04002700 RID: 9984
	private static int[] TRIANGLE_INDICES = new int[]
	{
		0,
		1,
		3,
		3,
		1,
		2
	};

	// Token: 0x04002701 RID: 9985
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Texture2D texture;

	// Token: 0x04002702 RID: 9986
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Material material;

	// Token: 0x04002703 RID: 9987
	[global::UnityEngine.SerializeField]
	protected global::dfSpriteFlip flip;

	// Token: 0x04002704 RID: 9988
	[global::UnityEngine.SerializeField]
	protected global::dfFillDirection fillDirection;

	// Token: 0x04002705 RID: 9989
	[global::UnityEngine.SerializeField]
	protected float fillAmount = 1f;

	// Token: 0x04002706 RID: 9990
	[global::UnityEngine.SerializeField]
	protected bool invertFill;

	// Token: 0x04002707 RID: 9991
	private bool createdRuntimeMaterial;

	// Token: 0x04002708 RID: 9992
	private global::UnityEngine.Material renderMaterial;

	// Token: 0x04002709 RID: 9993
	private global::PropertyChangedEventHandler<global::UnityEngine.Texture2D> TextureChanged;
}
