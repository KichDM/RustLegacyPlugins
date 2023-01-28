using System;
using NGUI.Meshing;
using NGUI.Structures;
using UnityEngine;

// Token: 0x02000951 RID: 2385
public class UIGeometricSprite : global::UISprite
{
	// Token: 0x06005114 RID: 20756 RVA: 0x0014063C File Offset: 0x0013E83C
	protected UIGeometricSprite(global::UIWidget.WidgetFlags additionalFlags) : base(additionalFlags)
	{
	}

	// Token: 0x17000F12 RID: 3858
	// (get) Token: 0x06005115 RID: 20757 RVA: 0x00140658 File Offset: 0x0013E858
	public global::UnityEngine.Rect innerUV
	{
		get
		{
			this.UpdateUVs(false);
			return this.mInnerUV;
		}
	}

	// Token: 0x17000F13 RID: 3859
	// (get) Token: 0x06005116 RID: 20758 RVA: 0x00140668 File Offset: 0x0013E868
	// (set) Token: 0x06005117 RID: 20759 RVA: 0x00140670 File Offset: 0x0013E870
	public bool fillCenter
	{
		get
		{
			return this.mFillCenter;
		}
		set
		{
			if (this.mFillCenter != value)
			{
				this.mFillCenter = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x06005118 RID: 20760 RVA: 0x0014068C File Offset: 0x0013E88C
	public override void UpdateUVs(bool force)
	{
		if (base.cachedTransform.localScale != this.mScale)
		{
			this.mScale = base.cachedTransform.localScale;
			base.ChangedAuto();
		}
		if (base.sprite != null && (force || this.mInner != this.mSprite.inner || this.mOuter != this.mSprite.outer))
		{
			global::UnityEngine.Texture mainTexture = base.mainTexture;
			if (mainTexture != null)
			{
				this.mInner = this.mSprite.inner;
				this.mOuter = this.mSprite.outer;
				this.mInnerUV = this.mInner;
				this.mOuterUV = this.mOuter;
				if (base.atlas.coordinates == global::UIAtlas.Coordinates.Pixels)
				{
					this.mOuterUV = global::NGUIMath.ConvertToTexCoords(this.mOuterUV, mainTexture.width, mainTexture.height);
					this.mInnerUV = global::NGUIMath.ConvertToTexCoords(this.mInnerUV, mainTexture.width, mainTexture.height);
				}
			}
		}
	}

	// Token: 0x06005119 RID: 20761 RVA: 0x001407AC File Offset: 0x0013E9AC
	public override void MakePixelPerfect()
	{
		global::UnityEngine.Vector3 localPosition = base.cachedTransform.localPosition;
		localPosition.x = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.x);
		localPosition.y = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.y);
		localPosition.z = (float)global::UnityEngine.Mathf.RoundToInt(localPosition.z);
		base.cachedTransform.localPosition = localPosition;
		global::UnityEngine.Vector3 localScale = base.cachedTransform.localScale;
		localScale.x = (float)(global::UnityEngine.Mathf.RoundToInt(localScale.x * 0.5f) << 1);
		localScale.y = (float)(global::UnityEngine.Mathf.RoundToInt(localScale.y * 0.5f) << 1);
		localScale.z = 1f;
		base.cachedTransform.localScale = localScale;
	}

	// Token: 0x0600511A RID: 20762 RVA: 0x0014086C File Offset: 0x0013EA6C
	public override void OnFill(global::NGUI.Meshing.MeshBuffer m)
	{
		if (this.mOuterUV == this.mInnerUV)
		{
			base.OnFill(m);
			return;
		}
		global::NGUI.Structures.float3 @float = default(global::NGUI.Structures.float3);
		@float.xyz = base.cachedTransform.localScale;
		global::UnityEngine.Vector4 vector;
		vector.x = this.mOuterUV.xMin;
		vector.y = this.mInnerUV.xMin;
		vector.z = this.mInnerUV.xMax;
		vector.w = this.mOuterUV.xMax;
		global::UnityEngine.Vector4 vector2;
		vector2.x = this.mOuterUV.yMin;
		vector2.y = this.mInnerUV.yMin;
		vector2.z = this.mInnerUV.yMax;
		vector2.w = this.mOuterUV.yMax;
		global::NGUI.Structures.NineRectangle nineRectangle;
		global::NGUI.Structures.NineRectangle nineRectangle2;
		global::NGUI.Structures.NineRectangle.Calculate(base.pivot, base.atlas.pixelSize, base.mainTexture, ref vector, ref vector2, ref @float.xy, out nineRectangle, out nineRectangle2);
		global::UnityEngine.Color color = base.color;
		if (this.mFillCenter)
		{
			global::NGUI.Structures.NineRectangle.Fill9(ref nineRectangle, ref nineRectangle2, ref color, m);
		}
		else
		{
			global::NGUI.Structures.NineRectangle.Fill8(ref nineRectangle, ref nineRectangle2, ref color, m);
		}
	}

	// Token: 0x04002DCD RID: 11725
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mFillCenter = true;

	// Token: 0x04002DCE RID: 11726
	protected global::UnityEngine.Rect mInner;

	// Token: 0x04002DCF RID: 11727
	protected global::UnityEngine.Rect mInnerUV;

	// Token: 0x04002DD0 RID: 11728
	protected global::UnityEngine.Vector3 mScale = global::UnityEngine.Vector3.one;
}
