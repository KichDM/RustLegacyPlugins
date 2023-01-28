using System;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x02000963 RID: 2403
[global::UnityEngine.AddComponentMenu("NGUI/UI/Sprite (Basic)")]
[global::UnityEngine.ExecuteInEditMode]
public class UISprite : global::UIWidget
{
	// Token: 0x060051FC RID: 20988 RVA: 0x0014F790 File Offset: 0x0014D990
	public UISprite() : base(global::UIWidget.WidgetFlags.CustomPivotOffset | global::UIWidget.WidgetFlags.CustomMaterialGet)
	{
	}

	// Token: 0x060051FD RID: 20989 RVA: 0x0014F7A4 File Offset: 0x0014D9A4
	protected UISprite(global::UIWidget.WidgetFlags additionalFlags) : base(global::UIWidget.WidgetFlags.CustomPivotOffset | global::UIWidget.WidgetFlags.CustomMaterialGet | additionalFlags)
	{
	}

	// Token: 0x17000F5A RID: 3930
	// (get) Token: 0x060051FE RID: 20990 RVA: 0x0014F7BC File Offset: 0x0014D9BC
	public global::UnityEngine.Rect outerUV
	{
		get
		{
			this.UpdateUVs(false);
			return this.mOuterUV;
		}
	}

	// Token: 0x17000F5B RID: 3931
	// (get) Token: 0x060051FF RID: 20991 RVA: 0x0014F7CC File Offset: 0x0014D9CC
	// (set) Token: 0x06005200 RID: 20992 RVA: 0x0014F7D4 File Offset: 0x0014D9D4
	public global::UIAtlas atlas
	{
		get
		{
			return this.mAtlas;
		}
		set
		{
			if (this.mAtlas != value)
			{
				this.mAtlas = value;
				this.mSpriteSet = false;
				this.mSprite = null;
				this.material = ((!(this.mAtlas != null)) ? null : ((global::UIMaterial)this.mAtlas.spriteMaterial));
				if (string.IsNullOrEmpty(this.mSpriteName) && this.mAtlas != null && this.mAtlas.spriteList.Count > 0)
				{
					this.sprite = this.mAtlas.spriteList[0];
					this.mSpriteName = this.mSprite.name;
				}
				if (!string.IsNullOrEmpty(this.mSpriteName))
				{
					string spriteName = this.mSpriteName;
					this.mSpriteName = string.Empty;
					this.spriteName = spriteName;
					base.ChangedAuto();
					this.UpdateUVs(true);
				}
			}
		}
	}

	// Token: 0x17000F5C RID: 3932
	// (get) Token: 0x06005201 RID: 20993 RVA: 0x0014F8CC File Offset: 0x0014DACC
	// (set) Token: 0x06005202 RID: 20994 RVA: 0x0014F8D4 File Offset: 0x0014DAD4
	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (string.IsNullOrEmpty(this.mSpriteName))
				{
					return;
				}
				this.mSpriteName = string.Empty;
				this.mSprite = null;
				base.ChangedAuto();
			}
			else if (this.mSpriteName != value)
			{
				this.mSpriteName = value;
				this.mSprite = null;
				base.ChangedAuto();
				if (this.mSprite != null)
				{
					this.UpdateUVs(true);
				}
			}
		}
	}

	// Token: 0x17000F5D RID: 3933
	// (get) Token: 0x06005203 RID: 20995 RVA: 0x0014F954 File Offset: 0x0014DB54
	// (set) Token: 0x06005204 RID: 20996 RVA: 0x0014FA28 File Offset: 0x0014DC28
	public global::UIAtlas.Sprite sprite
	{
		get
		{
			if (!this.mSpriteSet)
			{
				this.mSprite = null;
			}
			if (this.mSprite == null && this.mAtlas != null)
			{
				if (!string.IsNullOrEmpty(this.mSpriteName))
				{
					this.sprite = this.mAtlas.GetSprite(this.mSpriteName);
				}
				if (this.mSprite == null && this.mAtlas.spriteList.Count > 0)
				{
					this.sprite = this.mAtlas.spriteList[0];
					this.mSpriteName = this.mSprite.name;
				}
				if (this.mSprite != null)
				{
					this.material = (global::UIMaterial)this.mAtlas.spriteMaterial;
				}
			}
			return this.mSprite;
		}
		set
		{
			this.mSprite = value;
			this.mSpriteSet = true;
			this.material = ((this.mSprite == null || !(this.mAtlas != null)) ? null : ((global::UIMaterial)this.mAtlas.spriteMaterial));
		}
	}

	// Token: 0x17000F5E RID: 3934
	// (get) Token: 0x06005205 RID: 20997 RVA: 0x0014FA7C File Offset: 0x0014DC7C
	public new global::UnityEngine.Vector2 pivotOffset
	{
		get
		{
			global::UnityEngine.Vector2 zero = global::UnityEngine.Vector2.zero;
			if (this.sprite != null)
			{
				global::UIWidget.Pivot pivot = base.pivot;
				if (pivot == global::UIWidget.Pivot.Top || pivot == global::UIWidget.Pivot.Center || pivot == global::UIWidget.Pivot.Bottom)
				{
					zero.x = (-1f - this.mSprite.paddingRight + this.mSprite.paddingLeft) * 0.5f;
				}
				else if (pivot == global::UIWidget.Pivot.TopRight || pivot == global::UIWidget.Pivot.Right || pivot == global::UIWidget.Pivot.BottomRight)
				{
					zero.x = -1f - this.mSprite.paddingRight;
				}
				else
				{
					zero.x = this.mSprite.paddingLeft;
				}
				if (pivot == global::UIWidget.Pivot.Left || pivot == global::UIWidget.Pivot.Center || pivot == global::UIWidget.Pivot.Right)
				{
					zero.y = (1f + this.mSprite.paddingBottom - this.mSprite.paddingTop) * 0.5f;
				}
				else if (pivot == global::UIWidget.Pivot.BottomLeft || pivot == global::UIWidget.Pivot.Bottom || pivot == global::UIWidget.Pivot.BottomRight)
				{
					zero.y = 1f + this.mSprite.paddingBottom;
				}
				else
				{
					zero.y = -this.mSprite.paddingTop;
				}
			}
			return zero;
		}
	}

	// Token: 0x17000F5F RID: 3935
	// (get) Token: 0x06005206 RID: 20998 RVA: 0x0014FBB4 File Offset: 0x0014DDB4
	// (set) Token: 0x06005207 RID: 20999 RVA: 0x0014FC20 File Offset: 0x0014DE20
	public new global::UIMaterial material
	{
		get
		{
			global::UIMaterial uimaterial = base.baseMaterial;
			if (uimaterial == null)
			{
				uimaterial = ((!(this.mAtlas != null)) ? null : ((global::UIMaterial)this.mAtlas.spriteMaterial));
				this.mSprite = null;
				base.baseMaterial = uimaterial;
				if (uimaterial != null)
				{
					this.UpdateUVs(true);
				}
			}
			return uimaterial;
		}
		set
		{
			base.material = value;
		}
	}

	// Token: 0x17000F60 RID: 3936
	// (get) Token: 0x06005208 RID: 21000 RVA: 0x0014FC2C File Offset: 0x0014DE2C
	protected override global::UIMaterial customMaterial
	{
		get
		{
			return this.material;
		}
	}

	// Token: 0x17000F61 RID: 3937
	// (get) Token: 0x06005209 RID: 21001 RVA: 0x0014FC34 File Offset: 0x0014DE34
	public global::UnityEngine.Vector4 border
	{
		get
		{
			if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.CustomBorder) == 0x10)
			{
				return this.customBorder;
			}
			return global::UnityEngine.Vector4.zero;
		}
	}

	// Token: 0x17000F62 RID: 3938
	// (get) Token: 0x0600520A RID: 21002 RVA: 0x0014FC54 File Offset: 0x0014DE54
	protected virtual global::UnityEngine.Vector4 customBorder
	{
		get
		{
			throw new global::System.NotSupportedException();
		}
	}

	// Token: 0x0600520B RID: 21003 RVA: 0x0014FC5C File Offset: 0x0014DE5C
	public virtual void UpdateUVs(bool force)
	{
		if (this.sprite != null && (force || this.mOuter != this.mSprite.outer))
		{
			global::UnityEngine.Texture mainTexture = base.mainTexture;
			if (mainTexture != null)
			{
				this.mOuter = this.mSprite.outer;
				this.mOuterUV = this.mOuter;
				if (this.mAtlas.coordinates == global::UIAtlas.Coordinates.Pixels)
				{
					this.mOuterUV = global::NGUIMath.ConvertToTexCoords(this.mOuterUV, mainTexture.width, mainTexture.height);
				}
				base.ChangedAuto();
			}
		}
	}

	// Token: 0x0600520C RID: 21004 RVA: 0x0014FCF8 File Offset: 0x0014DEF8
	public override void MakePixelPerfect()
	{
		if (this.sprite == null)
		{
			return;
		}
		global::UnityEngine.Texture mainTexture = base.mainTexture;
		global::UnityEngine.Vector3 localScale = base.cachedTransform.localScale;
		if (mainTexture != null)
		{
			global::UnityEngine.Rect rect = global::NGUIMath.ConvertToPixels(this.outerUV, mainTexture.width, mainTexture.height, true);
			float pixelSize = this.atlas.pixelSize;
			localScale.x = (float)global::UnityEngine.Mathf.RoundToInt(rect.width * pixelSize);
			localScale.y = (float)global::UnityEngine.Mathf.RoundToInt(rect.height * pixelSize);
			localScale.z = 1f;
			base.cachedTransform.localScale = localScale;
		}
		int num = global::UnityEngine.Mathf.RoundToInt(localScale.x * (1f + this.mSprite.paddingLeft + this.mSprite.paddingRight));
		int num2 = global::UnityEngine.Mathf.RoundToInt(localScale.y * (1f + this.mSprite.paddingTop + this.mSprite.paddingBottom));
		global::UnityEngine.Vector3 localPosition = base.cachedTransform.localPosition;
		localPosition.z = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.z);
		if (num % 2 == 1 && (base.pivot == global::UIWidget.Pivot.Top || base.pivot == global::UIWidget.Pivot.Center || base.pivot == global::UIWidget.Pivot.Bottom))
		{
			localPosition.x = global::UnityEngine.Mathf.Floor(localPosition.x) + 0.5f;
		}
		else
		{
			localPosition.x = global::UnityEngine.Mathf.Round(localPosition.x);
		}
		if (num2 % 2 == 1 && (base.pivot == global::UIWidget.Pivot.Left || base.pivot == global::UIWidget.Pivot.Center || base.pivot == global::UIWidget.Pivot.Right))
		{
			localPosition.y = global::UnityEngine.Mathf.Ceil(localPosition.y) - 0.5f;
		}
		else
		{
			localPosition.y = global::UnityEngine.Mathf.Round(localPosition.y);
		}
		base.cachedTransform.localPosition = localPosition;
	}

	// Token: 0x0600520D RID: 21005 RVA: 0x0014FEE0 File Offset: 0x0014E0E0
	protected override void OnStart()
	{
		if (this.mAtlas != null)
		{
			this.UpdateUVs(true);
		}
	}

	// Token: 0x0600520E RID: 21006 RVA: 0x0014FEFC File Offset: 0x0014E0FC
	public override bool OnUpdate()
	{
		if (this.mLastName != this.mSpriteName)
		{
			this.mSprite = null;
			base.ChangedAuto();
			this.mLastName = this.mSpriteName;
			this.UpdateUVs(false);
			return true;
		}
		this.UpdateUVs(false);
		return false;
	}

	// Token: 0x0600520F RID: 21007 RVA: 0x0014FF4C File Offset: 0x0014E14C
	public override void OnFill(global::NGUI.Meshing.MeshBuffer m)
	{
		m.FastQuad(this.mOuterUV, base.color);
	}

	// Token: 0x06005210 RID: 21008 RVA: 0x0014FF64 File Offset: 0x0014E164
	protected override void GetCustomVector2s(int start, int end, global::UIWidget.WidgetFlags[] flags, global::UnityEngine.Vector2[] v)
	{
		for (int i = start; i < end; i++)
		{
			if (flags[i] == global::UIWidget.WidgetFlags.CustomPivotOffset)
			{
				v[i] = this.pivotOffset;
			}
			else
			{
				base.GetCustomVector2s(i, i + 1, flags, v);
			}
		}
	}

	// Token: 0x04002E5F RID: 11871
	private const global::UIWidget.WidgetFlags kRequiredFlags = global::UIWidget.WidgetFlags.CustomPivotOffset | global::UIWidget.WidgetFlags.CustomMaterialGet;

	// Token: 0x04002E60 RID: 11872
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIAtlas mAtlas;

	// Token: 0x04002E61 RID: 11873
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string mSpriteName;

	// Token: 0x04002E62 RID: 11874
	protected global::UIAtlas.Sprite mSprite;

	// Token: 0x04002E63 RID: 11875
	protected global::UnityEngine.Rect mOuter;

	// Token: 0x04002E64 RID: 11876
	protected global::UnityEngine.Rect mOuterUV;

	// Token: 0x04002E65 RID: 11877
	private bool mSpriteSet;

	// Token: 0x04002E66 RID: 11878
	private string mLastName = string.Empty;
}
