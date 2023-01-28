using System;
using UnityEngine;

// Token: 0x020008C1 RID: 2241
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Draggable Panel")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UIPanel))]
public class UIDraggablePanel : global::IgnoreTimeScale
{
	// Token: 0x06004D35 RID: 19765 RVA: 0x00125EAC File Offset: 0x001240AC
	public UIDraggablePanel()
	{
	}

	// Token: 0x1400006E RID: 110
	// (add) Token: 0x06004D36 RID: 19766 RVA: 0x00125F18 File Offset: 0x00124118
	// (remove) Token: 0x06004D37 RID: 19767 RVA: 0x00125F34 File Offset: 0x00124134
	public event global::UIDraggablePanel.CalculatedNextChangeCallback onNextChangeCallback
	{
		add
		{
			this.calculatedNextChangeCallback = (global::UIDraggablePanel.CalculatedNextChangeCallback)global::System.Delegate.Combine(this.calculatedNextChangeCallback, value);
		}
		remove
		{
			this.calculatedNextChangeCallback = (global::UIDraggablePanel.CalculatedNextChangeCallback)global::System.Delegate.Remove(this.calculatedNextChangeCallback, value);
		}
	}

	// Token: 0x17000E58 RID: 3672
	// (get) Token: 0x06004D38 RID: 19768 RVA: 0x00125F50 File Offset: 0x00124150
	// (set) Token: 0x06004D39 RID: 19769 RVA: 0x00125F58 File Offset: 0x00124158
	public bool calculateBoundsEveryChange
	{
		get
		{
			return this._calculateBoundsEveryChange;
		}
		set
		{
			if (value)
			{
				if (!this._calculateBoundsEveryChange)
				{
					this.CalculateBoundsIfNeeded();
					this._calculateBoundsEveryChange = true;
				}
			}
			else
			{
				this._calculateBoundsEveryChange = false;
			}
		}
	}

	// Token: 0x17000E59 RID: 3673
	// (get) Token: 0x06004D3A RID: 19770 RVA: 0x00125F88 File Offset: 0x00124188
	public bool panelMayNeedBoundsCalculated
	{
		get
		{
			return this._panelMayNeedBoundCalculation;
		}
	}

	// Token: 0x17000E5A RID: 3674
	// (set) Token: 0x06004D3B RID: 19771 RVA: 0x00125F90 File Offset: 0x00124190
	public bool calculateNextChange
	{
		set
		{
			if (value)
			{
				this._calculateNextChange = true;
			}
		}
	}

	// Token: 0x17000E5B RID: 3675
	// (get) Token: 0x06004D3C RID: 19772 RVA: 0x00125FA0 File Offset: 0x001241A0
	public global::AABBox bounds
	{
		get
		{
			if (!this.mCalculatedBounds)
			{
				this.mCalculatedBounds = true;
				this.mBounds = global::NGUIMath.CalculateRelativeWidgetBounds(this.mTrans, this.mTrans);
			}
			return this.mBounds;
		}
	}

	// Token: 0x17000E5C RID: 3676
	// (get) Token: 0x06004D3D RID: 19773 RVA: 0x00125FD4 File Offset: 0x001241D4
	public bool shouldMoveHorizontally
	{
		get
		{
			float num = this.bounds.size.x;
			if (this.mPanel.clipping == global::UIDrawCall.Clipping.SoftClip)
			{
				num += this.mPanel.clipSoftness.x * 2f;
			}
			return num > this.mPanel.clipRange.z;
		}
	}

	// Token: 0x17000E5D RID: 3677
	// (get) Token: 0x06004D3E RID: 19774 RVA: 0x0012603C File Offset: 0x0012423C
	public bool shouldMoveVertically
	{
		get
		{
			float num = this.bounds.size.y;
			if (this.mPanel.clipping == global::UIDrawCall.Clipping.SoftClip)
			{
				num += this.mPanel.clipSoftness.y * 2f;
			}
			return num > this.mPanel.clipRange.w;
		}
	}

	// Token: 0x17000E5E RID: 3678
	// (get) Token: 0x06004D3F RID: 19775 RVA: 0x001260A4 File Offset: 0x001242A4
	private bool shouldMove
	{
		get
		{
			if (!this.disableDragIfFits)
			{
				return true;
			}
			if (this.mPanel == null)
			{
				this.mPanel = base.GetComponent<global::UIPanel>();
			}
			global::UnityEngine.Vector4 clipRange = this.mPanel.clipRange;
			global::AABBox bounds = this.bounds;
			float num = clipRange.z * 0.5f;
			float num2 = clipRange.w * 0.5f;
			if (!global::UnityEngine.Mathf.Approximately(this.scale.x, 0f))
			{
				if (bounds.min.x < clipRange.x - num)
				{
					return true;
				}
				if (bounds.max.x > clipRange.x + num)
				{
					return true;
				}
			}
			if (!global::UnityEngine.Mathf.Approximately(this.scale.y, 0f))
			{
				if (bounds.min.y < clipRange.y - num2)
				{
					return true;
				}
				if (bounds.max.y > clipRange.y + num2)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x17000E5F RID: 3679
	// (get) Token: 0x06004D40 RID: 19776 RVA: 0x001261C0 File Offset: 0x001243C0
	// (set) Token: 0x06004D41 RID: 19777 RVA: 0x001261C8 File Offset: 0x001243C8
	public global::UnityEngine.Vector3 currentMomentum
	{
		get
		{
			return this.mMomentum;
		}
		set
		{
			this.mMomentum = value;
		}
	}

	// Token: 0x06004D42 RID: 19778 RVA: 0x001261D4 File Offset: 0x001243D4
	private void Awake()
	{
		this.mTrans = base.transform;
		this.mPanel = base.GetComponent<global::UIPanel>();
	}

	// Token: 0x06004D43 RID: 19779 RVA: 0x001261F0 File Offset: 0x001243F0
	private void Start()
	{
		if (this.mStartedManually)
		{
			return;
		}
		this.UpdateScrollbars(true);
		if (this.horizontalScrollBar != null)
		{
			global::UIScrollBar uiscrollBar = this.horizontalScrollBar;
			uiscrollBar.onChange = (global::UIScrollBar.OnScrollBarChange)global::System.Delegate.Combine(uiscrollBar.onChange, new global::UIScrollBar.OnScrollBarChange(this.OnHorizontalBar));
			this.horizontalScrollBar.alpha = ((this.showScrollBars != global::UIDraggablePanel.ShowCondition.Always && !this.shouldMoveHorizontally) ? 0f : 1f);
		}
		if (this.verticalScrollBar != null)
		{
			global::UIScrollBar uiscrollBar2 = this.verticalScrollBar;
			uiscrollBar2.onChange = (global::UIScrollBar.OnScrollBarChange)global::System.Delegate.Combine(uiscrollBar2.onChange, new global::UIScrollBar.OnScrollBarChange(this.OnVerticalBar));
			this.verticalScrollBar.alpha = ((this.showScrollBars != global::UIDraggablePanel.ShowCondition.Always && !this.shouldMoveVertically) ? 0f : 1f);
		}
		this.mStartedAutomatically = true;
	}

	// Token: 0x06004D44 RID: 19780 RVA: 0x001262E8 File Offset: 0x001244E8
	public bool ManualStart()
	{
		if (!this.mStartedManually)
		{
			if (!this.mStartedAutomatically)
			{
				this.Start();
				this.mStartedManually = true;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004D45 RID: 19781 RVA: 0x00126318 File Offset: 0x00124518
	public void RestrictWithinBounds(bool instant)
	{
		global::UnityEngine.Vector3 vector = this.mPanel.CalculateConstrainOffset(this.bounds.min, this.bounds.max);
		if (vector.magnitude > 0.001f)
		{
			if (!instant && this.dragEffect == global::UIDraggablePanel.DragEffect.MomentumAndSpring)
			{
				global::SpringPanel.Begin(this.mPanel.gameObject, this.mTrans.localPosition + vector, 13f);
			}
			else
			{
				this.MoveRelative(vector);
				this.mMomentum = global::UnityEngine.Vector3.zero;
				this.mScroll = 0f;
			}
		}
		else
		{
			this.DisableSpring();
		}
	}

	// Token: 0x06004D46 RID: 19782 RVA: 0x001263D0 File Offset: 0x001245D0
	public void DisableSpring()
	{
		global::SpringPanel component = base.GetComponent<global::SpringPanel>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	// Token: 0x06004D47 RID: 19783 RVA: 0x001263F8 File Offset: 0x001245F8
	public void UpdateScrollbars(bool recalculateBounds)
	{
		if (this.mPanel == null)
		{
			return;
		}
		if (this.horizontalScrollBar != null || this.verticalScrollBar != null)
		{
			if (recalculateBounds)
			{
				this.mCalculatedBounds = false;
				this._panelMayNeedBoundCalculation = false;
				this.mShouldMove = this.shouldMove;
			}
			if (this.horizontalScrollBar != null)
			{
				global::AABBox bounds = this.bounds;
				global::UnityEngine.Vector3 size = bounds.size;
				if (size.x > 0f)
				{
					global::UnityEngine.Vector4 clipRange = this.mPanel.clipRange;
					float num = clipRange.z * 0.5f;
					float num2 = clipRange.x - num - bounds.min.x;
					float num3 = bounds.max.x - num - clipRange.x;
					if (this.mPanel.clipping == global::UIDrawCall.Clipping.SoftClip)
					{
						num2 += this.mPanel.clipSoftness.x;
						num3 -= this.mPanel.clipSoftness.x;
					}
					num2 = global::UnityEngine.Mathf.Clamp01(num2 / size.x);
					num3 = global::UnityEngine.Mathf.Clamp01(num3 / size.x);
					float num4 = num2 + num3;
					this.mIgnoreCallbacks = true;
					this.horizontalScrollBar.barSize = 1f - num4;
					this.horizontalScrollBar.scrollValue = ((num4 <= 0.001f) ? 0f : (num2 / num4));
					this.mIgnoreCallbacks = false;
				}
			}
			if (this.verticalScrollBar != null)
			{
				global::AABBox bounds2 = this.bounds;
				global::UnityEngine.Vector3 size2 = bounds2.size;
				if (size2.y > 0f)
				{
					global::UnityEngine.Vector4 clipRange2 = this.mPanel.clipRange;
					float num5 = clipRange2.w * 0.5f;
					float num6 = clipRange2.y - num5 - bounds2.min.y;
					float num7 = bounds2.max.y - num5 - clipRange2.y;
					if (this.mPanel.clipping == global::UIDrawCall.Clipping.SoftClip)
					{
						num6 += this.mPanel.clipSoftness.y;
						num7 -= this.mPanel.clipSoftness.y;
					}
					num6 = global::UnityEngine.Mathf.Clamp01(num6 / size2.y);
					num7 = global::UnityEngine.Mathf.Clamp01(num7 / size2.y);
					float num8 = num6 + num7;
					this.mIgnoreCallbacks = true;
					this.verticalScrollBar.barSize = 1f - num8;
					this.verticalScrollBar.scrollValue = ((num8 <= 0.001f) ? 0f : (1f - num6 / num8));
					this.mIgnoreCallbacks = false;
				}
			}
		}
		else if (recalculateBounds)
		{
			this.mCalculatedBounds = false;
			this._panelMayNeedBoundCalculation = false;
		}
	}

	// Token: 0x06004D48 RID: 19784 RVA: 0x001266EC File Offset: 0x001248EC
	public void SetDragAmount(float x, float y, bool updateScrollbars)
	{
		this.DisableSpring();
		global::AABBox bounds = this.bounds;
		if (bounds.min.x == bounds.max.x || bounds.min.y == bounds.max.x)
		{
			return;
		}
		global::UnityEngine.Vector4 clipRange = this.mPanel.clipRange;
		float num = clipRange.z * 0.5f;
		float num2 = clipRange.w * 0.5f;
		float num3 = bounds.min.x + num;
		float num4 = bounds.max.x - num;
		float num5 = bounds.min.y + num2;
		float num6 = bounds.max.y - num2;
		if (this.mPanel.clipping == global::UIDrawCall.Clipping.SoftClip)
		{
			num3 -= this.mPanel.clipSoftness.x;
			num4 += this.mPanel.clipSoftness.x;
			num5 -= this.mPanel.clipSoftness.y;
			num6 += this.mPanel.clipSoftness.y;
		}
		float num7 = global::UnityEngine.Mathf.Lerp(num3, num4, x);
		float num8 = global::UnityEngine.Mathf.Lerp(num6, num5, y);
		if (!updateScrollbars)
		{
			global::UnityEngine.Vector3 localPosition = this.mTrans.localPosition;
			if (this.scale.x != 0f)
			{
				localPosition.x += clipRange.x - num7;
			}
			if (this.scale.y != 0f)
			{
				localPosition.y += clipRange.y - num8;
			}
			this.mTrans.localPosition = localPosition;
		}
		clipRange.x = num7;
		clipRange.y = num8;
		this.mPanel.clipRange = clipRange;
		if (updateScrollbars)
		{
			this.UpdateScrollbars(false);
		}
	}

	// Token: 0x06004D49 RID: 19785 RVA: 0x001268FC File Offset: 0x00124AFC
	public void ResetPosition()
	{
		this.mCalculatedBounds = false;
		this.SetDragAmount(this.relativePositionOnReset.x, this.relativePositionOnReset.y, false);
		this.SetDragAmount(this.relativePositionOnReset.x, this.relativePositionOnReset.y, true);
	}

	// Token: 0x06004D4A RID: 19786 RVA: 0x0012694C File Offset: 0x00124B4C
	private void OnHorizontalBar(global::UIScrollBar sb)
	{
		if (!this.mIgnoreCallbacks)
		{
			float x = (!(this.horizontalScrollBar != null)) ? 0f : this.horizontalScrollBar.scrollValue;
			float y = (!(this.verticalScrollBar != null)) ? 0f : this.verticalScrollBar.scrollValue;
			this.SetDragAmount(x, y, false);
		}
	}

	// Token: 0x06004D4B RID: 19787 RVA: 0x001269BC File Offset: 0x00124BBC
	private void OnVerticalBar(global::UIScrollBar sb)
	{
		if (!this.mIgnoreCallbacks)
		{
			float x = (!(this.horizontalScrollBar != null)) ? 0f : this.horizontalScrollBar.scrollValue;
			float y = (!(this.verticalScrollBar != null)) ? 0f : this.verticalScrollBar.scrollValue;
			this.SetDragAmount(x, y, false);
		}
	}

	// Token: 0x06004D4C RID: 19788 RVA: 0x00126A2C File Offset: 0x00124C2C
	private void MoveRelative(global::UnityEngine.Vector3 relative)
	{
		this.mTrans.localPosition += relative;
		global::UnityEngine.Vector4 clipRange = this.mPanel.clipRange;
		clipRange.x -= relative.x;
		clipRange.y -= relative.y;
		this.mPanel.clipRange = clipRange;
		this.UpdateScrollbars(false);
	}

	// Token: 0x06004D4D RID: 19789 RVA: 0x00126A9C File Offset: 0x00124C9C
	private void MoveAbsolute(global::UnityEngine.Vector3 absolute)
	{
		global::UnityEngine.Vector3 vector = this.mTrans.InverseTransformPoint(absolute);
		global::UnityEngine.Vector3 vector2 = this.mTrans.InverseTransformPoint(global::UnityEngine.Vector3.zero);
		this.MoveRelative(vector - vector2);
	}

	// Token: 0x06004D4E RID: 19790 RVA: 0x00126AD4 File Offset: 0x00124CD4
	public void Press(bool pressed)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			this.mTouches += ((!pressed) ? -1 : 1);
			this.mCalculatedBounds = false;
			this.mShouldMove = this.shouldMove;
			if (!this.mShouldMove)
			{
				return;
			}
			this.mPressed = pressed;
			if (pressed)
			{
				this.mMomentum = global::UnityEngine.Vector3.zero;
				this.mScroll = 0f;
				this.DisableSpring();
				this.mLastPos = global::UICamera.lastHit.point;
				this.mPlane = new global::UnityEngine.Plane(this.mTrans.rotation * global::UnityEngine.Vector3.back, this.mLastPos);
			}
			else if (this.restrictWithinPanel && this.mPanel.clipping != global::UIDrawCall.Clipping.None && this.dragEffect == global::UIDraggablePanel.DragEffect.MomentumAndSpring)
			{
				this.RestrictWithinBounds(false);
			}
		}
	}

	// Token: 0x06004D4F RID: 19791 RVA: 0x00126BC8 File Offset: 0x00124DC8
	public void Drag(global::UnityEngine.Vector2 delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.mShouldMove)
		{
			global::UICamera.currentTouch.clickNotification = global::UICamera.ClickNotification.BasedOnDelta;
			global::UnityEngine.Ray ray = global::UICamera.currentCamera.ScreenPointToRay(global::UICamera.currentTouch.pos);
			float num = 0f;
			if (this.mPlane.Raycast(ray, ref num))
			{
				global::UnityEngine.Vector3 point = ray.GetPoint(num);
				global::UnityEngine.Vector3 vector = point - this.mLastPos;
				this.mLastPos = point;
				if (vector.x != 0f || vector.y != 0f)
				{
					vector = this.mTrans.InverseTransformDirection(vector);
					vector.Scale(this.scale);
					vector = this.mTrans.TransformDirection(vector);
				}
				this.mMomentum = global::UnityEngine.Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				this.MoveAbsolute(vector);
				if (this.restrictWithinPanel && this.mPanel.clipping != global::UIDrawCall.Clipping.None && this.dragEffect != global::UIDraggablePanel.DragEffect.MomentumAndSpring)
				{
					this.RestrictWithinBounds(false);
				}
			}
		}
	}

	// Token: 0x06004D50 RID: 19792 RVA: 0x00126D08 File Offset: 0x00124F08
	public void Scroll(float delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			this.mShouldMove = this.shouldMove;
			if (global::UnityEngine.Mathf.Sign(this.mScroll) != global::UnityEngine.Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x06004D51 RID: 19793 RVA: 0x00126D74 File Offset: 0x00124F74
	private void OnPanelChanged()
	{
		if (this._calculateNextChange)
		{
			this._calculateNextChange = false;
			this.UpdateScrollbars(true);
			if (this.calculatedNextChangeCallback != null)
			{
				global::UIDraggablePanel.CalculatedNextChangeCallback calculatedNextChangeCallback = this.calculatedNextChangeCallback;
				this.calculatedNextChangeCallback = null;
				calculatedNextChangeCallback();
			}
		}
		else if (!global::UnityEngine.Application.isPlaying || this._calculateBoundsEveryChange)
		{
			this.UpdateScrollbars(true);
		}
		else
		{
			this._panelMayNeedBoundCalculation = true;
		}
	}

	// Token: 0x06004D52 RID: 19794 RVA: 0x00126DE8 File Offset: 0x00124FE8
	public bool CalculateBoundsIfNeeded()
	{
		if (this._panelMayNeedBoundCalculation)
		{
			this.UpdateScrollbars(true);
			return !this._panelMayNeedBoundCalculation;
		}
		return false;
	}

	// Token: 0x06004D53 RID: 19795 RVA: 0x00126E08 File Offset: 0x00125008
	private void LateUpdate()
	{
		if (!this.mPanel.enabled)
		{
			this.mMomentum = global::UnityEngine.Vector3.zero;
			return;
		}
		if (this.mPanel.changedLastFrame)
		{
			this.OnPanelChanged();
		}
		if (this.repositionClipping)
		{
			this.repositionClipping = false;
			this.mCalculatedBounds = false;
			this.SetDragAmount(this.relativePositionOnReset.x, this.relativePositionOnReset.y, true);
		}
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		float num = base.UpdateRealTimeDelta();
		if (this.showScrollBars != global::UIDraggablePanel.ShowCondition.Always)
		{
			bool flag = false;
			bool flag2 = false;
			if (this.showScrollBars != global::UIDraggablePanel.ShowCondition.WhenDragging || this.mTouches > 0)
			{
				flag = this.shouldMoveVertically;
				flag2 = this.shouldMoveHorizontally;
			}
			if (this.verticalScrollBar)
			{
				float num2 = this.verticalScrollBar.alpha;
				num2 += ((!flag) ? (-num * 3f) : (num * 6f));
				num2 = global::UnityEngine.Mathf.Clamp01(num2);
				if (this.verticalScrollBar.alpha != num2)
				{
					this.verticalScrollBar.alpha = num2;
				}
			}
			if (this.horizontalScrollBar)
			{
				float num3 = this.horizontalScrollBar.alpha;
				num3 += ((!flag2) ? (-num * 3f) : (num * 6f));
				num3 = global::UnityEngine.Mathf.Clamp01(num3);
				if (this.horizontalScrollBar.alpha != num3)
				{
					this.horizontalScrollBar.alpha = num3;
				}
			}
		}
		if (this.mShouldMove && !this.mPressed)
		{
			this.mMomentum += this.scale * (-this.mScroll * 0.05f);
			if (this.mMomentum.magnitude > 0.0001f)
			{
				this.mScroll = global::NGUIMath.SpringLerp(this.mScroll, 0f, 20f, num);
				global::UnityEngine.Vector3 absolute = global::NGUIMath.SpringDampen(ref this.mMomentum, 9f, num);
				this.MoveAbsolute(absolute);
				if ((this.restrictWithinPanel || this.restrictWithinPanelWithScroll) && this.mPanel.clipping != global::UIDrawCall.Clipping.None)
				{
					this.RestrictWithinBounds(false);
				}
				return;
			}
			this.mScroll = 0f;
		}
		else
		{
			this.mScroll = 0f;
		}
		global::NGUIMath.SpringDampen(ref this.mMomentum, 9f, num);
	}

	// Token: 0x06004D54 RID: 19796 RVA: 0x0012706C File Offset: 0x0012526C
	private void OnHoverScroll(float y)
	{
		if (this.respondHoverScroll)
		{
			this.Scroll(y);
		}
	}

	// Token: 0x04002A21 RID: 10785
	public bool restrictWithinPanel = true;

	// Token: 0x04002A22 RID: 10786
	public bool restrictWithinPanelWithScroll = true;

	// Token: 0x04002A23 RID: 10787
	public bool disableDragIfFits;

	// Token: 0x04002A24 RID: 10788
	public global::UIDraggablePanel.DragEffect dragEffect = global::UIDraggablePanel.DragEffect.MomentumAndSpring;

	// Token: 0x04002A25 RID: 10789
	public global::UnityEngine.Vector3 scale = global::UnityEngine.Vector3.one;

	// Token: 0x04002A26 RID: 10790
	public float scrollWheelFactor;

	// Token: 0x04002A27 RID: 10791
	public float momentumAmount = 35f;

	// Token: 0x04002A28 RID: 10792
	public global::UnityEngine.Vector2 relativePositionOnReset = global::UnityEngine.Vector2.zero;

	// Token: 0x04002A29 RID: 10793
	public bool repositionClipping;

	// Token: 0x04002A2A RID: 10794
	public global::UIScrollBar horizontalScrollBar;

	// Token: 0x04002A2B RID: 10795
	public global::UIScrollBar verticalScrollBar;

	// Token: 0x04002A2C RID: 10796
	public global::UIDraggablePanel.ShowCondition showScrollBars = global::UIDraggablePanel.ShowCondition.OnlyIfNeeded;

	// Token: 0x04002A2D RID: 10797
	[global::UnityEngine.SerializeField]
	private bool _calculateBoundsEveryChange = true;

	// Token: 0x04002A2E RID: 10798
	private bool _panelMayNeedBoundCalculation;

	// Token: 0x04002A2F RID: 10799
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002A30 RID: 10800
	private global::UIPanel mPanel;

	// Token: 0x04002A31 RID: 10801
	private global::UnityEngine.Plane mPlane;

	// Token: 0x04002A32 RID: 10802
	private global::UnityEngine.Vector3 mLastPos;

	// Token: 0x04002A33 RID: 10803
	private bool mPressed;

	// Token: 0x04002A34 RID: 10804
	private global::UnityEngine.Vector3 mMomentum = global::UnityEngine.Vector3.zero;

	// Token: 0x04002A35 RID: 10805
	private float mScroll;

	// Token: 0x04002A36 RID: 10806
	private global::AABBox mBounds;

	// Token: 0x04002A37 RID: 10807
	private bool mCalculatedBounds;

	// Token: 0x04002A38 RID: 10808
	private bool mShouldMove;

	// Token: 0x04002A39 RID: 10809
	private bool mIgnoreCallbacks;

	// Token: 0x04002A3A RID: 10810
	private bool mStartedManually;

	// Token: 0x04002A3B RID: 10811
	private bool mStartedAutomatically;

	// Token: 0x04002A3C RID: 10812
	private int mTouches;

	// Token: 0x04002A3D RID: 10813
	private bool _calculateNextChange;

	// Token: 0x04002A3E RID: 10814
	public bool respondHoverScroll = true;

	// Token: 0x04002A3F RID: 10815
	private global::UIDraggablePanel.CalculatedNextChangeCallback calculatedNextChangeCallback;

	// Token: 0x020008C2 RID: 2242
	public enum DragEffect
	{
		// Token: 0x04002A41 RID: 10817
		None,
		// Token: 0x04002A42 RID: 10818
		Momentum,
		// Token: 0x04002A43 RID: 10819
		MomentumAndSpring
	}

	// Token: 0x020008C3 RID: 2243
	public enum ShowCondition
	{
		// Token: 0x04002A45 RID: 10821
		Always,
		// Token: 0x04002A46 RID: 10822
		OnlyIfNeeded,
		// Token: 0x04002A47 RID: 10823
		WhenDragging
	}

	// Token: 0x020008C4 RID: 2244
	// (Invoke) Token: 0x06004D56 RID: 19798
	public delegate void CalculatedNextChangeCallback();
}
