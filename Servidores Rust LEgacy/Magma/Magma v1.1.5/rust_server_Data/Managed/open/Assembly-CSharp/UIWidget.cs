using System;
using System.Collections.Generic;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x02000905 RID: 2309
public abstract class UIWidget : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004F16 RID: 20246 RVA: 0x00133214 File Offset: 0x00131414
	protected UIWidget(global::UIWidget.WidgetFlags flags)
	{
		this.widgetFlags = flags;
	}

	// Token: 0x06004F17 RID: 20247 RVA: 0x00133254 File Offset: 0x00131454
	// Note: this type is marked as 'beforefieldinit'.
	static UIWidget()
	{
	}

	// Token: 0x06004F18 RID: 20248 RVA: 0x001332A4 File Offset: 0x001314A4
	public static void GlobalUpdate()
	{
		global::UIWidget.Global.WidgetUpdate();
	}

	// Token: 0x06004F19 RID: 20249 RVA: 0x001332AC File Offset: 0x001314AC
	public void MarkAsChangedForced()
	{
		this.MarkAsChanged();
		this.mForcedChanged = true;
	}

	// Token: 0x17000E8E RID: 3726
	// (get) Token: 0x06004F1A RID: 20250 RVA: 0x001332BC File Offset: 0x001314BC
	// (set) Token: 0x06004F1B RID: 20251 RVA: 0x001332C4 File Offset: 0x001314C4
	public bool alphaUnchecked
	{
		get
		{
			return this.mAlphaUnchecked;
		}
		set
		{
			if (value)
			{
				if (!this.mAlphaUnchecked)
				{
					this.mAlphaUnchecked = true;
					if (global::NGUITools.ZeroAlpha(this.mColor.a))
					{
						this.mChangedCall = true;
					}
				}
			}
			else if (this.mAlphaUnchecked)
			{
				this.mAlphaUnchecked = false;
				if (global::NGUITools.ZeroAlpha(this.mColor.a))
				{
					this.mChangedCall = true;
				}
			}
		}
	}

	// Token: 0x17000E8F RID: 3727
	// (get) Token: 0x06004F1C RID: 20252 RVA: 0x00133338 File Offset: 0x00131538
	public bool changesQueued
	{
		get
		{
			return this.mChangedCall || this.mForcedChanged;
		}
	}

	// Token: 0x06004F1D RID: 20253 RVA: 0x00133350 File Offset: 0x00131550
	protected void ChangedAuto()
	{
		this.mChangedCall = true;
	}

	// Token: 0x17000E90 RID: 3728
	// (get) Token: 0x06004F1E RID: 20254 RVA: 0x0013335C File Offset: 0x0013155C
	private global::UIGeometry mGeom
	{
		get
		{
			global::UIGeometry result;
			if ((result = this.__mGeom) == null)
			{
				result = (this.__mGeom = new global::UIGeometry());
			}
			return result;
		}
	}

	// Token: 0x17000E91 RID: 3729
	// (get) Token: 0x06004F1F RID: 20255 RVA: 0x00133384 File Offset: 0x00131584
	// (set) Token: 0x06004F20 RID: 20256 RVA: 0x0013338C File Offset: 0x0013158C
	public global::UnityEngine.Color color
	{
		get
		{
			return this.mColor;
		}
		set
		{
			if (this.mColor != value)
			{
				this.mColor = value;
				this.mChangedCall = true;
			}
		}
	}

	// Token: 0x17000E92 RID: 3730
	// (get) Token: 0x06004F21 RID: 20257 RVA: 0x001333B0 File Offset: 0x001315B0
	// (set) Token: 0x06004F22 RID: 20258 RVA: 0x001333C0 File Offset: 0x001315C0
	public float alpha
	{
		get
		{
			return this.mColor.a;
		}
		set
		{
			global::UnityEngine.Color color = this.mColor;
			color.a = value;
			this.color = color;
		}
	}

	// Token: 0x17000E93 RID: 3731
	// (get) Token: 0x06004F23 RID: 20259 RVA: 0x001333E4 File Offset: 0x001315E4
	// (set) Token: 0x06004F24 RID: 20260 RVA: 0x001333EC File Offset: 0x001315EC
	public global::UIWidget.Pivot pivot
	{
		get
		{
			return this.mPivot;
		}
		set
		{
			if (this.mPivot != value)
			{
				this.mPivot = value;
				this.mChangedCall = true;
			}
		}
	}

	// Token: 0x17000E94 RID: 3732
	// (get) Token: 0x06004F25 RID: 20261 RVA: 0x00133408 File Offset: 0x00131608
	// (set) Token: 0x06004F26 RID: 20262 RVA: 0x00133410 File Offset: 0x00131610
	public int depth
	{
		get
		{
			return this.mDepth;
		}
		set
		{
			if (this.mDepth != value)
			{
				this.mDepth = value;
				if (this.mPanel != null)
				{
					this.mPanel.MarkMaterialAsChanged(this.material, true);
				}
			}
		}
	}

	// Token: 0x17000E95 RID: 3733
	// (get) Token: 0x06004F27 RID: 20263 RVA: 0x00133454 File Offset: 0x00131654
	public global::UnityEngine.Transform cachedTransform
	{
		get
		{
			if (!this.gotCachedTransform)
			{
				this.mTrans = base.transform;
				this.gotCachedTransform = true;
			}
			return this.mTrans;
		}
	}

	// Token: 0x17000E96 RID: 3734
	// (get) Token: 0x06004F28 RID: 20264 RVA: 0x00133488 File Offset: 0x00131688
	// (set) Token: 0x06004F29 RID: 20265 RVA: 0x001334A8 File Offset: 0x001316A8
	public global::UIMaterial material
	{
		get
		{
			if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.CustomMaterialGet) == 4)
			{
				return this.customMaterial;
			}
			return this.baseMaterial;
		}
		set
		{
			if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.CustomMaterialSet) == 8)
			{
				this.customMaterial = value;
			}
			else
			{
				this.baseMaterial = value;
			}
		}
	}

	// Token: 0x17000E97 RID: 3735
	// (get) Token: 0x06004F2A RID: 20266 RVA: 0x001334D8 File Offset: 0x001316D8
	// (set) Token: 0x06004F2B RID: 20267 RVA: 0x001334E8 File Offset: 0x001316E8
	protected global::UIMaterial baseMaterial
	{
		get
		{
			return (global::UIMaterial)this.mMat;
		}
		set
		{
			global::UIMaterial uimaterial = (global::UIMaterial)this.mMat;
			if (uimaterial != value)
			{
				if (uimaterial != null && this.mPanel != null)
				{
					this.mPanel.RemoveWidget(this);
				}
				this.mPanel = null;
				this.mMat = (global::UnityEngine.Material)value;
				this.mTex = null;
				if (this.mMat != null)
				{
					this.CreatePanel();
				}
			}
		}
	}

	// Token: 0x06004F2C RID: 20268 RVA: 0x00133568 File Offset: 0x00131768
	public void ForceReloadMaterial()
	{
		if (this.mMat)
		{
			if (this.mPanel)
			{
				this.mPanel.RemoveWidget(this);
			}
			this.mPanel = null;
			this.mTex = null;
			if (this.mMat)
			{
				this.CreatePanel();
			}
		}
	}

	// Token: 0x17000E98 RID: 3736
	// (get) Token: 0x06004F2D RID: 20269 RVA: 0x001335C8 File Offset: 0x001317C8
	// (set) Token: 0x06004F2E RID: 20270 RVA: 0x001335D0 File Offset: 0x001317D0
	protected virtual global::UIMaterial customMaterial
	{
		get
		{
			throw new global::System.NotSupportedException();
		}
		set
		{
			throw new global::System.NotSupportedException();
		}
	}

	// Token: 0x17000E99 RID: 3737
	// (get) Token: 0x06004F2F RID: 20271 RVA: 0x001335D8 File Offset: 0x001317D8
	public global::UnityEngine.Texture mainTexture
	{
		get
		{
			if (!this.mTex)
			{
				global::UIMaterial material = this.material;
				if (material != null)
				{
					this.mTex = material.mainTexture;
				}
			}
			return this.mTex;
		}
	}

	// Token: 0x17000E9A RID: 3738
	// (get) Token: 0x06004F30 RID: 20272 RVA: 0x0013361C File Offset: 0x0013181C
	// (set) Token: 0x06004F31 RID: 20273 RVA: 0x0013363C File Offset: 0x0013183C
	public global::UIPanel panel
	{
		get
		{
			if (!this.mPanel)
			{
				this.CreatePanel();
			}
			return this.mPanel;
		}
		set
		{
			this.mPanel = value;
		}
	}

	// Token: 0x17000E9B RID: 3739
	// (get) Token: 0x06004F32 RID: 20274 RVA: 0x00133648 File Offset: 0x00131848
	// (set) Token: 0x06004F33 RID: 20275 RVA: 0x00133650 File Offset: 0x00131850
	public int visibleFlag
	{
		get
		{
			return this.mVisibleFlag;
		}
		set
		{
			this.mVisibleFlag = value;
		}
	}

	// Token: 0x06004F34 RID: 20276 RVA: 0x0013365C File Offset: 0x0013185C
	public static int CompareFunc(global::UIWidget left, global::UIWidget right)
	{
		if (left.mDepth > right.mDepth)
		{
			return 1;
		}
		if (left.mDepth < right.mDepth)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x06004F35 RID: 20277 RVA: 0x00133688 File Offset: 0x00131888
	public virtual void MarkAsChanged()
	{
		this.mChangedCall = true;
		if (this.mPanel != null && base.enabled && base.gameObject.activeInHierarchy && !global::UnityEngine.Application.isPlaying && this.material != null)
		{
			this.mPanel.AddWidget(this);
			this.CheckLayer();
		}
	}

	// Token: 0x06004F36 RID: 20278 RVA: 0x001336F8 File Offset: 0x001318F8
	private void CreatePanel()
	{
		if (!this.mPanel && base.enabled && base.gameObject.activeInHierarchy && this.material != null)
		{
			this.mPanel = global::UIPanel.Find(this.cachedTransform);
			if (this.mPanel != null)
			{
				this.CheckLayer();
				this.mPanel.AddWidget(this);
				this.mChangedCall = true;
			}
		}
	}

	// Token: 0x06004F37 RID: 20279 RVA: 0x0013377C File Offset: 0x0013197C
	private void CheckLayer()
	{
		if (this.mPanel != null && this.mPanel.gameObject.layer != base.gameObject.layer)
		{
			global::UnityEngine.Debug.LogWarning("You can't place widgets on a layer different than the UIPanel that manages them.\nIf you want to move widgets to a different layer, parent them to a new panel instead.", this);
			base.gameObject.layer = this.mPanel.gameObject.layer;
		}
	}

	// Token: 0x06004F38 RID: 20280 RVA: 0x001337E0 File Offset: 0x001319E0
	private void CheckParent()
	{
		if (this.mPanel != null)
		{
			bool flag = true;
			global::UnityEngine.Transform parent = this.cachedTransform.parent;
			while (parent != null)
			{
				if (parent == this.mPanel.cachedTransform)
				{
					break;
				}
				if (!this.mPanel.WatchesTransform(parent))
				{
					flag = false;
					break;
				}
				parent = parent.parent;
			}
			if (!flag)
			{
				if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.KeepsMaterial) != 0x40)
				{
					this.material = null;
				}
				this.mPanel = null;
				this.CreatePanel();
			}
		}
	}

	// Token: 0x06004F39 RID: 20281 RVA: 0x00133884 File Offset: 0x00131A84
	protected void Awake()
	{
		this.mPlayMode = global::UnityEngine.Application.isPlaying;
		global::UIWidget.Global.RegisterWidget(this);
	}

	// Token: 0x06004F3A RID: 20282 RVA: 0x00133898 File Offset: 0x00131A98
	private void OnEnable()
	{
		global::UIWidget.Global.WidgetEnabled(this);
		this.mChangedCall = true;
		if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.KeepsMaterial) != 0x40)
		{
			this.mMat = null;
			this.mTex = null;
		}
		if (this.mPanel != null && this.material != null)
		{
			this.mPanel.MarkMaterialAsChanged(this.material, false);
		}
	}

	// Token: 0x06004F3B RID: 20283 RVA: 0x00133908 File Offset: 0x00131B08
	private void Start()
	{
		this.OnStart();
		this.CreatePanel();
	}

	// Token: 0x06004F3C RID: 20284 RVA: 0x00133918 File Offset: 0x00131B18
	private void DefaultUpdate()
	{
		if (!this.mPanel)
		{
			this.CreatePanel();
		}
		global::UnityEngine.Vector3 localScale = this.cachedTransform.localScale;
		if (localScale.z != 1f)
		{
			localScale.z = 1f;
			this.mTrans.localScale = localScale;
		}
	}

	// Token: 0x06004F3D RID: 20285 RVA: 0x00133970 File Offset: 0x00131B70
	private void OnDisable()
	{
		global::UIWidget.Global.WidgetDisabled(this);
		if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.KeepsMaterial) != 0x40)
		{
			this.material = null;
		}
		else if (this.mPanel != null)
		{
			this.mPanel.RemoveWidget(this);
		}
		this.mPanel = null;
	}

	// Token: 0x06004F3E RID: 20286 RVA: 0x001339C4 File Offset: 0x00131BC4
	private void OnDestroy()
	{
		global::UIWidget.Global.UnregisterWidget(this);
		if (this.mPanel != null)
		{
			this.mPanel.RemoveWidget(this);
			this.mPanel = null;
		}
		this.__mGeom = null;
	}

	// Token: 0x06004F3F RID: 20287 RVA: 0x001339F8 File Offset: 0x00131BF8
	public bool UpdateGeometry(ref global::UnityEngine.Matrix4x4 worldToPanel, bool parentMoved, bool generateNormals)
	{
		if (!this.material)
		{
			return false;
		}
		global::UIGeometry mGeom = this.mGeom;
		if (this.OnUpdate() || this.mChangedCall || this.mForcedChanged)
		{
			this.mChangedCall = false;
			this.mForcedChanged = false;
			mGeom.Clear();
			if (this.mAlphaUnchecked || !global::NGUITools.ZeroAlpha(this.mColor.a))
			{
				this.OnFill(mGeom.meshBuffer);
			}
			if (mGeom.hasVertices)
			{
				global::UnityEngine.Vector2 vector;
				global::UnityEngine.Vector2 vector2;
				switch ((byte)(this.widgetFlags & (global::UIWidget.WidgetFlags.CustomPivotOffset | global::UIWidget.WidgetFlags.CustomRelativeSize)))
				{
				case 1:
					global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomPivotOffset;
					this.GetCustomVector2s(0, 1, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
					vector = global::UIWidget.tempVector2s[0];
					vector2.x = (vector2.y = 1f);
					break;
				case 2:
					global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomRelativeSize;
					this.GetCustomVector2s(0, 1, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
					vector2 = global::UIWidget.tempVector2s[0];
					vector = global::UIWidget.DefaultPivot(this.mPivot);
					break;
				case 3:
					global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomPivotOffset;
					global::UIWidget.tempWidgetFlags[1] = global::UIWidget.WidgetFlags.CustomRelativeSize;
					this.GetCustomVector2s(0, 2, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
					vector = global::UIWidget.tempVector2s[0];
					vector2 = global::UIWidget.tempVector2s[1];
					break;
				default:
					vector = global::UIWidget.DefaultPivot(this.mPivot);
					vector2.x = (vector2.y = 1f);
					break;
				}
				global::UnityEngine.Vector3 vector3;
				vector3.x = vector.x * vector2.x;
				vector3.y = vector.y * vector2.y;
				vector3.z = 0f;
				global::UnityEngine.Matrix4x4 matrix4x = worldToPanel * this.cachedTransform.localToWorldMatrix;
				mGeom.Apply(ref vector3, ref matrix4x);
			}
			return true;
		}
		if (mGeom.hasVertices && parentMoved)
		{
			global::UnityEngine.Matrix4x4 matrix4x2 = worldToPanel * this.cachedTransform.localToWorldMatrix;
			mGeom.Apply(ref matrix4x2);
		}
		return false;
	}

	// Token: 0x06004F40 RID: 20288 RVA: 0x00133C34 File Offset: 0x00131E34
	public void WriteToBuffers(global::NGUI.Meshing.MeshBuffer m)
	{
		this.mGeom.WriteToBuffers(m);
	}

	// Token: 0x06004F41 RID: 20289 RVA: 0x00133C44 File Offset: 0x00131E44
	public virtual void MakePixelPerfect()
	{
		global::UnityEngine.Vector3 localScale = this.cachedTransform.localScale;
		int num = global::UnityEngine.Mathf.RoundToInt(localScale.x);
		int num2 = global::UnityEngine.Mathf.RoundToInt(localScale.y);
		localScale.x = (float)num;
		localScale.y = (float)num2;
		localScale.z = 1f;
		global::UnityEngine.Vector3 localPosition = this.cachedTransform.localPosition;
		localPosition.z = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.z);
		if (num % 2 == 1 && (this.pivot == global::UIWidget.Pivot.Top || this.pivot == global::UIWidget.Pivot.Center || this.pivot == global::UIWidget.Pivot.Bottom))
		{
			localPosition.x = global::UnityEngine.Mathf.Floor(localPosition.x) + 0.5f;
		}
		else
		{
			localPosition.x = global::UnityEngine.Mathf.Round(localPosition.x);
		}
		if (num2 % 2 == 1 && (this.pivot == global::UIWidget.Pivot.Left || this.pivot == global::UIWidget.Pivot.Center || this.pivot == global::UIWidget.Pivot.Right))
		{
			localPosition.y = global::UnityEngine.Mathf.Ceil(localPosition.y) - 0.5f;
		}
		else
		{
			localPosition.y = global::UnityEngine.Mathf.Round(localPosition.y);
		}
		this.cachedTransform.localPosition = localPosition;
		this.cachedTransform.localScale = localScale;
	}

	// Token: 0x06004F42 RID: 20290 RVA: 0x00133D8C File Offset: 0x00131F8C
	protected static global::UnityEngine.Vector2 DefaultPivot(global::UIWidget.Pivot pivot)
	{
		global::UnityEngine.Vector2 result;
		switch (pivot)
		{
		case global::UIWidget.Pivot.TopLeft:
			result.x = 0f;
			result.y = 0f;
			break;
		case global::UIWidget.Pivot.Top:
			result.y = -0.5f;
			result.x = -1f;
			break;
		case global::UIWidget.Pivot.TopRight:
			result.y = 0f;
			result.x = -1f;
			break;
		case global::UIWidget.Pivot.Left:
			result.x = 0f;
			result.y = 0.5f;
			break;
		case global::UIWidget.Pivot.Center:
			result.x = -0.5f;
			result.y = 0.5f;
			break;
		case global::UIWidget.Pivot.Right:
			result.x = -1f;
			result.y = 0.5f;
			break;
		case global::UIWidget.Pivot.BottomLeft:
			result.x = 0f;
			result.y = 1f;
			break;
		case global::UIWidget.Pivot.Bottom:
			result.x = -0.5f;
			result.y = 1f;
			break;
		case global::UIWidget.Pivot.BottomRight:
			result.x = -1f;
			result.y = 1f;
			break;
		default:
			throw new global::System.NotImplementedException();
		}
		return result;
	}

	// Token: 0x17000E9C RID: 3740
	// (get) Token: 0x06004F43 RID: 20291 RVA: 0x00133ED8 File Offset: 0x001320D8
	public global::UnityEngine.Vector2 pivotOffset
	{
		get
		{
			if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.CustomPivotOffset) == 1)
			{
				global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomPivotOffset;
				this.GetCustomVector2s(0, 1, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
				return global::UIWidget.tempVector2s[0];
			}
			return global::UIWidget.DefaultPivot(this.mPivot);
		}
	}

	// Token: 0x17000E9D RID: 3741
	// (get) Token: 0x06004F44 RID: 20292 RVA: 0x00133F2C File Offset: 0x0013212C
	[global::System.Obsolete("Use 'relativeSize' instead")]
	public global::UnityEngine.Vector2 visibleSize
	{
		get
		{
			return this.relativeSize;
		}
	}

	// Token: 0x06004F45 RID: 20293 RVA: 0x00133F34 File Offset: 0x00132134
	protected virtual void GetCustomVector2s(int start, int end, global::UIWidget.WidgetFlags[] flags, global::UnityEngine.Vector2[] v)
	{
		throw new global::System.NotSupportedException("Only call base.GetCustomVector2s when its something not supported by your implementation, otherwise the custructor for your class is incorrect in its usage.");
	}

	// Token: 0x17000E9E RID: 3742
	// (get) Token: 0x06004F46 RID: 20294 RVA: 0x00133F40 File Offset: 0x00132140
	public global::UnityEngine.Vector2 relativeSize
	{
		get
		{
			if ((byte)(this.widgetFlags & global::UIWidget.WidgetFlags.CustomRelativeSize) == 2)
			{
				global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomRelativeSize;
				this.GetCustomVector2s(0, 1, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
				return global::UIWidget.tempVector2s[0];
			}
			return global::UnityEngine.Vector2.one;
		}
	}

	// Token: 0x17000E9F RID: 3743
	// (get) Token: 0x06004F47 RID: 20295 RVA: 0x00133F8C File Offset: 0x0013218C
	public bool keepMaterial
	{
		get
		{
			return (byte)(this.widgetFlags & global::UIWidget.WidgetFlags.KeepsMaterial) == 0x40;
		}
	}

	// Token: 0x06004F48 RID: 20296 RVA: 0x00133F9C File Offset: 0x0013219C
	protected virtual void OnStart()
	{
	}

	// Token: 0x06004F49 RID: 20297 RVA: 0x00133FA0 File Offset: 0x001321A0
	public virtual bool OnUpdate()
	{
		return false;
	}

	// Token: 0x06004F4A RID: 20298
	public abstract void OnFill(global::NGUI.Meshing.MeshBuffer m);

	// Token: 0x06004F4B RID: 20299 RVA: 0x00133FA4 File Offset: 0x001321A4
	public void GetPivotOffsetAndRelativeSize(out global::UnityEngine.Vector2 pivotOffset, out global::UnityEngine.Vector2 relativeSize)
	{
		switch ((byte)(this.widgetFlags & (global::UIWidget.WidgetFlags.CustomPivotOffset | global::UIWidget.WidgetFlags.CustomRelativeSize)))
		{
		case 1:
			global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomPivotOffset;
			this.GetCustomVector2s(0, 1, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
			pivotOffset = global::UIWidget.tempVector2s[0];
			relativeSize.x = (relativeSize.y = 1f);
			break;
		case 2:
			global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomRelativeSize;
			this.GetCustomVector2s(0, 1, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
			relativeSize = global::UIWidget.tempVector2s[0];
			pivotOffset = global::UIWidget.DefaultPivot(this.mPivot);
			break;
		case 3:
			global::UIWidget.tempWidgetFlags[0] = global::UIWidget.WidgetFlags.CustomPivotOffset;
			global::UIWidget.tempWidgetFlags[1] = global::UIWidget.WidgetFlags.CustomRelativeSize;
			this.GetCustomVector2s(0, 2, global::UIWidget.tempWidgetFlags, global::UIWidget.tempVector2s);
			pivotOffset = global::UIWidget.tempVector2s[0];
			relativeSize = global::UIWidget.tempVector2s[1];
			break;
		default:
			pivotOffset = global::UIWidget.DefaultPivot(this.mPivot);
			relativeSize.x = (relativeSize.y = 1f);
			break;
		}
	}

	// Token: 0x04002BAC RID: 11180
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material mMat;

	// Token: 0x04002BAD RID: 11181
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color mColor = global::UnityEngine.Color.white;

	// Token: 0x04002BAE RID: 11182
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIWidget.Pivot mPivot = global::UIWidget.Pivot.Center;

	// Token: 0x04002BAF RID: 11183
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mDepth;

	// Token: 0x04002BB0 RID: 11184
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mAlphaUnchecked;

	// Token: 0x04002BB1 RID: 11185
	[global::System.NonSerialized]
	private bool mForcedChanged;

	// Token: 0x04002BB2 RID: 11186
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002BB3 RID: 11187
	private global::UnityEngine.Texture mTex;

	// Token: 0x04002BB4 RID: 11188
	private global::UIPanel mPanel;

	// Token: 0x04002BB5 RID: 11189
	private bool mChangedCall = true;

	// Token: 0x04002BB6 RID: 11190
	protected bool mPlayMode = true;

	// Token: 0x04002BB7 RID: 11191
	private bool gotCachedTransform;

	// Token: 0x04002BB8 RID: 11192
	[global::System.NonSerialized]
	protected readonly global::UIWidget.WidgetFlags widgetFlags;

	// Token: 0x04002BB9 RID: 11193
	private global::UnityEngine.Vector3 mDiffPos;

	// Token: 0x04002BBA RID: 11194
	private global::UnityEngine.Quaternion mDiffRot;

	// Token: 0x04002BBB RID: 11195
	private global::UnityEngine.Vector3 mDiffScale;

	// Token: 0x04002BBC RID: 11196
	private int mVisibleFlag = -1;

	// Token: 0x04002BBD RID: 11197
	private int globalIndex = -1;

	// Token: 0x04002BBE RID: 11198
	private global::UIGeometry __mGeom;

	// Token: 0x04002BBF RID: 11199
	private static global::UnityEngine.Vector2[] tempVector2s = new global::UnityEngine.Vector2[]
	{
		default(global::UnityEngine.Vector2),
		default(global::UnityEngine.Vector2)
	};

	// Token: 0x04002BC0 RID: 11200
	private static global::UIWidget.WidgetFlags[] tempWidgetFlags = new global::UIWidget.WidgetFlags[2];

	// Token: 0x02000906 RID: 2310
	[global::System.Flags]
	protected enum WidgetFlags : byte
	{
		// Token: 0x04002BC2 RID: 11202
		CustomPivotOffset = 1,
		// Token: 0x04002BC3 RID: 11203
		CustomRelativeSize = 2,
		// Token: 0x04002BC4 RID: 11204
		CustomMaterialGet = 4,
		// Token: 0x04002BC5 RID: 11205
		CustomMaterialSet = 8,
		// Token: 0x04002BC6 RID: 11206
		CustomBorder = 0x10,
		// Token: 0x04002BC7 RID: 11207
		KeepsMaterial = 0x40,
		// Token: 0x04002BC8 RID: 11208
		Reserved = 0x80
	}

	// Token: 0x02000907 RID: 2311
	public enum Pivot
	{
		// Token: 0x04002BCA RID: 11210
		TopLeft,
		// Token: 0x04002BCB RID: 11211
		Top,
		// Token: 0x04002BCC RID: 11212
		TopRight,
		// Token: 0x04002BCD RID: 11213
		Left,
		// Token: 0x04002BCE RID: 11214
		Center,
		// Token: 0x04002BCF RID: 11215
		Right,
		// Token: 0x04002BD0 RID: 11216
		BottomLeft,
		// Token: 0x04002BD1 RID: 11217
		Bottom,
		// Token: 0x04002BD2 RID: 11218
		BottomRight
	}

	// Token: 0x02000908 RID: 2312
	private static class Global
	{
		// Token: 0x17000EA0 RID: 3744
		// (get) Token: 0x06004F4C RID: 20300 RVA: 0x001340E0 File Offset: 0x001322E0
		private static bool noGlobal
		{
			get
			{
				return !global::UnityEngine.Application.isPlaying;
			}
		}

		// Token: 0x06004F4D RID: 20301 RVA: 0x001340EC File Offset: 0x001322EC
		public static void RegisterWidget(global::UIWidget widget)
		{
			if (global::UIWidget.Global.noGlobal)
			{
				return;
			}
			global::UIGlobal.EnsureGlobal();
			if (widget.globalIndex == -1)
			{
				widget.globalIndex = global::UIWidget.Global.g.allWidgets.Count;
				global::UIWidget.Global.g.allWidgets.Add(widget);
			}
		}

		// Token: 0x06004F4E RID: 20302 RVA: 0x00134128 File Offset: 0x00132328
		public static void UnregisterWidget(global::UIWidget widget)
		{
			if (global::UIWidget.Global.noGlobal)
			{
				return;
			}
			if (widget.globalIndex != -1)
			{
				global::UIWidget.Global.g.allWidgets.RemoveAt(widget.globalIndex);
				int i = widget.globalIndex;
				int count = global::UIWidget.Global.g.allWidgets.Count;
				while (i < count)
				{
					global::UIWidget.Global.g.allWidgets[i].globalIndex = i;
					i++;
				}
				widget.globalIndex = -1;
			}
		}

		// Token: 0x06004F4F RID: 20303 RVA: 0x00134198 File Offset: 0x00132398
		public static void WidgetEnabled(global::UIWidget widget)
		{
			if (global::UIWidget.Global.noGlobal)
			{
				return;
			}
			global::UIWidget.Global.g.enabledWidgets.Add(widget);
		}

		// Token: 0x06004F50 RID: 20304 RVA: 0x001341B4 File Offset: 0x001323B4
		public static void WidgetDisabled(global::UIWidget widget)
		{
			if (global::UIWidget.Global.noGlobal)
			{
				return;
			}
			global::UIWidget.Global.g.enabledWidgets.Remove(widget);
		}

		// Token: 0x06004F51 RID: 20305 RVA: 0x001341D0 File Offset: 0x001323D0
		public static void WidgetUpdate()
		{
			if (global::UIWidget.Global.noGlobal)
			{
				return;
			}
			try
			{
				global::UIWidget.Global.g.enableWidgetsSwap.AddRange(global::UIWidget.Global.g.enabledWidgets);
				foreach (global::UIWidget uiwidget in global::UIWidget.Global.g.enableWidgetsSwap)
				{
					if (uiwidget && uiwidget.enabled)
					{
						uiwidget.DefaultUpdate();
					}
				}
			}
			finally
			{
				global::UIWidget.Global.g.enableWidgetsSwap.Clear();
			}
		}

		// Token: 0x02000909 RID: 2313
		public static class g
		{
			// Token: 0x06004F52 RID: 20306 RVA: 0x0013428C File Offset: 0x0013248C
			static g()
			{
				global::UIGlobal.EnsureGlobal();
			}

			// Token: 0x04002BD3 RID: 11219
			public static global::System.Collections.Generic.List<global::UIWidget> allWidgets = new global::System.Collections.Generic.List<global::UIWidget>();

			// Token: 0x04002BD4 RID: 11220
			public static global::System.Collections.Generic.HashSet<global::UIWidget> enabledWidgets = new global::System.Collections.Generic.HashSet<global::UIWidget>();

			// Token: 0x04002BD5 RID: 11221
			public static global::System.Collections.Generic.List<global::UIWidget> enableWidgetsSwap = new global::System.Collections.Generic.List<global::UIWidget>();
		}
	}
}
