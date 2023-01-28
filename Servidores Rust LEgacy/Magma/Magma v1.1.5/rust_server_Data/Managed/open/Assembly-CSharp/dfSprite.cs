using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000835 RID: 2101
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Sprite/Basic")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfSprite : global::dfControl
{
	// Token: 0x0600481F RID: 18463 RVA: 0x0010C350 File Offset: 0x0010A550
	public dfSprite()
	{
	}

	// Token: 0x06004820 RID: 18464 RVA: 0x0010C364 File Offset: 0x0010A564
	// Note: this type is marked as 'beforefieldinit'.
	static dfSprite()
	{
	}

	// Token: 0x14000051 RID: 81
	// (add) Token: 0x06004821 RID: 18465 RVA: 0x0010C37C File Offset: 0x0010A57C
	// (remove) Token: 0x06004822 RID: 18466 RVA: 0x0010C398 File Offset: 0x0010A598
	public event global::PropertyChangedEventHandler<string> SpriteNameChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.SpriteNameChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Combine(this.SpriteNameChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.SpriteNameChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Remove(this.SpriteNameChanged, value);
		}
	}

	// Token: 0x17000D85 RID: 3461
	// (get) Token: 0x06004823 RID: 18467 RVA: 0x0010C3B4 File Offset: 0x0010A5B4
	// (set) Token: 0x06004824 RID: 18468 RVA: 0x0010C3FC File Offset: 0x0010A5FC
	public global::dfAtlas Atlas
	{
		get
		{
			if (this.atlas == null)
			{
				global::dfGUIManager manager = base.GetManager();
				if (manager != null)
				{
					return this.atlas = manager.DefaultAtlas;
				}
			}
			return this.atlas;
		}
		set
		{
			if (!global::dfAtlas.Equals(value, this.atlas))
			{
				this.atlas = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D86 RID: 3462
	// (get) Token: 0x06004825 RID: 18469 RVA: 0x0010C41C File Offset: 0x0010A61C
	// (set) Token: 0x06004826 RID: 18470 RVA: 0x0010C424 File Offset: 0x0010A624
	public string SpriteName
	{
		get
		{
			return this.spriteName;
		}
		set
		{
			value = base.getLocalizedValue(value);
			if (value != this.spriteName)
			{
				this.spriteName = value;
				if (!global::UnityEngine.Application.isPlaying)
				{
					global::dfAtlas.ItemInfo spriteInfo = this.SpriteInfo;
					if (this.size == global::UnityEngine.Vector2.zero && spriteInfo != null)
					{
						this.size = spriteInfo.sizeInPixels;
						this.updateCollider();
					}
				}
				this.Invalidate();
				this.OnSpriteNameChanged(value);
			}
		}
	}

	// Token: 0x17000D87 RID: 3463
	// (get) Token: 0x06004827 RID: 18471 RVA: 0x0010C4A4 File Offset: 0x0010A6A4
	public global::dfAtlas.ItemInfo SpriteInfo
	{
		get
		{
			if (this.Atlas == null)
			{
				return null;
			}
			return this.Atlas[this.spriteName];
		}
	}

	// Token: 0x17000D88 RID: 3464
	// (get) Token: 0x06004828 RID: 18472 RVA: 0x0010C4DC File Offset: 0x0010A6DC
	// (set) Token: 0x06004829 RID: 18473 RVA: 0x0010C4E4 File Offset: 0x0010A6E4
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

	// Token: 0x17000D89 RID: 3465
	// (get) Token: 0x0600482A RID: 18474 RVA: 0x0010C500 File Offset: 0x0010A700
	// (set) Token: 0x0600482B RID: 18475 RVA: 0x0010C508 File Offset: 0x0010A708
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

	// Token: 0x17000D8A RID: 3466
	// (get) Token: 0x0600482C RID: 18476 RVA: 0x0010C524 File Offset: 0x0010A724
	// (set) Token: 0x0600482D RID: 18477 RVA: 0x0010C52C File Offset: 0x0010A72C
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

	// Token: 0x17000D8B RID: 3467
	// (get) Token: 0x0600482E RID: 18478 RVA: 0x0010C56C File Offset: 0x0010A76C
	// (set) Token: 0x0600482F RID: 18479 RVA: 0x0010C574 File Offset: 0x0010A774
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

	// Token: 0x06004830 RID: 18480 RVA: 0x0010C590 File Offset: 0x0010A790
	protected internal override void OnLocalize()
	{
		base.OnLocalize();
		this.SpriteName = base.getLocalizedValue(this.spriteName);
	}

	// Token: 0x06004831 RID: 18481 RVA: 0x0010C5AC File Offset: 0x0010A7AC
	protected internal virtual void OnSpriteNameChanged(string value)
	{
		base.Signal("OnSpriteNameChanged", new object[]
		{
			value
		});
		if (this.SpriteNameChanged != null)
		{
			this.SpriteNameChanged(this, value);
		}
	}

	// Token: 0x06004832 RID: 18482 RVA: 0x0010C5E8 File Offset: 0x0010A7E8
	public override global::UnityEngine.Vector2 CalculateMinimumSize()
	{
		global::dfAtlas.ItemInfo spriteInfo = this.SpriteInfo;
		if (spriteInfo == null)
		{
			return global::UnityEngine.Vector2.zero;
		}
		global::UnityEngine.RectOffset border = spriteInfo.border;
		if (border != null && border.horizontal > 0 && border.vertical > 0)
		{
			return global::UnityEngine.Vector2.Max(base.CalculateMinimumSize(), new global::UnityEngine.Vector2((float)border.horizontal, (float)border.vertical));
		}
		return base.CalculateMinimumSize();
	}

	// Token: 0x06004833 RID: 18483 RVA: 0x0010C658 File Offset: 0x0010A858
	protected override void OnRebuildRenderData()
	{
		if (!(this.Atlas != null) || !(this.Atlas.Material != null) || !base.IsVisible)
		{
			return;
		}
		if (this.SpriteInfo == null)
		{
			return;
		}
		this.renderData.Material = this.Atlas.Material;
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? this.disabledColor : this.color);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.Atlas,
			color = color,
			fillAmount = this.fillAmount,
			fillDirection = this.fillDirection,
			flip = this.flip,
			invertFill = this.invertFill,
			offset = this.pivot.TransformToUpperLeft(base.Size),
			pixelsToUnits = base.PixelsToUnits(),
			size = base.Size,
			spriteInfo = this.SpriteInfo
		};
		global::dfSprite.renderSprite(this.renderData, options);
	}

	// Token: 0x06004834 RID: 18484 RVA: 0x0010C788 File Offset: 0x0010A988
	internal static void renderSprite(global::dfRenderData data, global::dfSprite.RenderOptions options)
	{
		options.baseIndex = data.Vertices.Count;
		global::dfSprite.rebuildTriangles(data, options);
		global::dfSprite.rebuildVertices(data, options);
		global::dfSprite.rebuildUV(data, options);
		global::dfSprite.rebuildColors(data, options);
		if (options.fillAmount > -1f && options.fillAmount < 1f)
		{
			global::dfSprite.doFill(data, options);
		}
	}

	// Token: 0x06004835 RID: 18485 RVA: 0x0010C7EC File Offset: 0x0010A9EC
	private static void rebuildTriangles(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		int baseIndex = options.baseIndex;
		global::dfList<int> triangles = renderData.Triangles;
		triangles.EnsureCapacity(triangles.Count + global::dfSprite.TRIANGLE_INDICES.Length);
		for (int i = 0; i < global::dfSprite.TRIANGLE_INDICES.Length; i++)
		{
			triangles.Add(baseIndex + global::dfSprite.TRIANGLE_INDICES[i]);
		}
	}

	// Token: 0x06004836 RID: 18486 RVA: 0x0010C844 File Offset: 0x0010AA44
	private static void rebuildVertices(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		global::dfList<global::UnityEngine.Vector3> vertices = renderData.Vertices;
		int baseIndex = options.baseIndex;
		float num = 0f;
		float num2 = 0f;
		float num3 = global::UnityEngine.Mathf.Ceil(options.size.x);
		float num4 = global::UnityEngine.Mathf.Ceil(-options.size.y);
		vertices.Add(new global::UnityEngine.Vector3(num, num2, 0f) * options.pixelsToUnits);
		vertices.Add(new global::UnityEngine.Vector3(num3, num2, 0f) * options.pixelsToUnits);
		vertices.Add(new global::UnityEngine.Vector3(num3, num4, 0f) * options.pixelsToUnits);
		vertices.Add(new global::UnityEngine.Vector3(num, num4, 0f) * options.pixelsToUnits);
		global::UnityEngine.Vector3 vector = options.offset.RoundToInt() * options.pixelsToUnits;
		for (int i = 0; i < 4; i++)
		{
			vertices[baseIndex + i] = (vertices[baseIndex + i] + vector).Quantize(options.pixelsToUnits);
		}
	}

	// Token: 0x06004837 RID: 18487 RVA: 0x0010C968 File Offset: 0x0010AB68
	private static void rebuildColors(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		global::dfList<global::UnityEngine.Color32> colors = renderData.Colors;
		colors.Add(options.color);
		colors.Add(options.color);
		colors.Add(options.color);
		colors.Add(options.color);
	}

	// Token: 0x06004838 RID: 18488 RVA: 0x0010C9B0 File Offset: 0x0010ABB0
	private static void rebuildUV(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		global::UnityEngine.Rect region = options.spriteInfo.region;
		global::dfList<global::UnityEngine.Vector2> uv = renderData.UV;
		uv.Add(new global::UnityEngine.Vector2(region.x, region.yMax));
		uv.Add(new global::UnityEngine.Vector2(region.xMax, region.yMax));
		uv.Add(new global::UnityEngine.Vector2(region.xMax, region.y));
		uv.Add(new global::UnityEngine.Vector2(region.x, region.y));
		global::UnityEngine.Vector2 value = global::UnityEngine.Vector2.zero;
		if (options.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
		{
			value = uv[1];
			uv[1] = uv[0];
			uv[0] = value;
			value = uv[3];
			uv[3] = uv[2];
			uv[2] = value;
		}
		if (options.flip.IsSet(global::dfSpriteFlip.FlipVertical))
		{
			value = uv[0];
			uv[0] = uv[3];
			uv[3] = value;
			value = uv[1];
			uv[1] = uv[2];
			uv[2] = value;
		}
	}

	// Token: 0x06004839 RID: 18489 RVA: 0x0010CAD8 File Offset: 0x0010ACD8
	private static void doFill(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		int baseIndex = options.baseIndex;
		global::dfList<global::UnityEngine.Vector3> vertices = renderData.Vertices;
		global::dfList<global::UnityEngine.Vector2> uv = renderData.UV;
		int index = baseIndex;
		int index2 = baseIndex + 1;
		int index3 = baseIndex + 3;
		int index4 = baseIndex + 2;
		if (options.invertFill)
		{
			if (options.fillDirection == global::dfFillDirection.Horizontal)
			{
				index = baseIndex + 1;
				index2 = baseIndex;
				index3 = baseIndex + 2;
				index4 = baseIndex + 3;
			}
			else
			{
				index = baseIndex + 3;
				index2 = baseIndex + 2;
				index3 = baseIndex;
				index4 = baseIndex + 1;
			}
		}
		if (options.fillDirection == global::dfFillDirection.Horizontal)
		{
			vertices[index2] = global::UnityEngine.Vector3.Lerp(vertices[index2], vertices[index], 1f - options.fillAmount);
			vertices[index4] = global::UnityEngine.Vector3.Lerp(vertices[index4], vertices[index3], 1f - options.fillAmount);
			uv[index2] = global::UnityEngine.Vector2.Lerp(uv[index2], uv[index], 1f - options.fillAmount);
			uv[index4] = global::UnityEngine.Vector2.Lerp(uv[index4], uv[index3], 1f - options.fillAmount);
		}
		else
		{
			vertices[index3] = global::UnityEngine.Vector3.Lerp(vertices[index3], vertices[index], 1f - options.fillAmount);
			vertices[index4] = global::UnityEngine.Vector3.Lerp(vertices[index4], vertices[index2], 1f - options.fillAmount);
			uv[index3] = global::UnityEngine.Vector2.Lerp(uv[index3], uv[index], 1f - options.fillAmount);
			uv[index4] = global::UnityEngine.Vector2.Lerp(uv[index4], uv[index2], 1f - options.fillAmount);
		}
	}

	// Token: 0x0600483A RID: 18490 RVA: 0x0010CCA8 File Offset: 0x0010AEA8
	public override string ToString()
	{
		if (!string.IsNullOrEmpty(this.spriteName))
		{
			return string.Format("{0} ({1})", base.name, this.spriteName);
		}
		return base.ToString();
	}

	// Token: 0x040026AE RID: 9902
	private static int[] TRIANGLE_INDICES = new int[]
	{
		0,
		1,
		3,
		3,
		1,
		2
	};

	// Token: 0x040026AF RID: 9903
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x040026B0 RID: 9904
	[global::UnityEngine.SerializeField]
	protected string spriteName;

	// Token: 0x040026B1 RID: 9905
	[global::UnityEngine.SerializeField]
	protected global::dfSpriteFlip flip;

	// Token: 0x040026B2 RID: 9906
	[global::UnityEngine.SerializeField]
	protected global::dfFillDirection fillDirection;

	// Token: 0x040026B3 RID: 9907
	[global::UnityEngine.SerializeField]
	protected float fillAmount = 1f;

	// Token: 0x040026B4 RID: 9908
	[global::UnityEngine.SerializeField]
	protected bool invertFill;

	// Token: 0x040026B5 RID: 9909
	private global::PropertyChangedEventHandler<string> SpriteNameChanged;

	// Token: 0x02000836 RID: 2102
	internal struct RenderOptions
	{
		// Token: 0x040026B6 RID: 9910
		public global::dfAtlas atlas;

		// Token: 0x040026B7 RID: 9911
		public global::dfAtlas.ItemInfo spriteInfo;

		// Token: 0x040026B8 RID: 9912
		public global::UnityEngine.Color32 color;

		// Token: 0x040026B9 RID: 9913
		public float pixelsToUnits;

		// Token: 0x040026BA RID: 9914
		public global::UnityEngine.Vector2 size;

		// Token: 0x040026BB RID: 9915
		public global::dfSpriteFlip flip;

		// Token: 0x040026BC RID: 9916
		public bool invertFill;

		// Token: 0x040026BD RID: 9917
		public global::dfFillDirection fillDirection;

		// Token: 0x040026BE RID: 9918
		public float fillAmount;

		// Token: 0x040026BF RID: 9919
		public global::UnityEngine.Vector3 offset;

		// Token: 0x040026C0 RID: 9920
		public int baseIndex;
	}
}
