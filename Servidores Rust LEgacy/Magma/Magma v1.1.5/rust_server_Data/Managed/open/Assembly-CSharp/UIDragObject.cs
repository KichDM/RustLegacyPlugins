using System;
using UnityEngine;

// Token: 0x020008BD RID: 2237
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Drag Object")]
public class UIDragObject : global::IgnoreTimeScale
{
	// Token: 0x06004D1D RID: 19741 RVA: 0x00124FD8 File Offset: 0x001231D8
	public UIDragObject()
	{
	}

	// Token: 0x17000E56 RID: 3670
	// (get) Token: 0x06004D1E RID: 19742 RVA: 0x00125014 File Offset: 0x00123214
	public static global::UnityEngine.RectOffset screenBorder
	{
		get
		{
			return new global::UnityEngine.RectOffset(0, -0x40, 0, 0);
		}
	}

	// Token: 0x06004D1F RID: 19743 RVA: 0x00125020 File Offset: 0x00123220
	private void FindPanel()
	{
		this.mPanel = ((!(this.target != null)) ? null : global::UIPanel.Find(this.target.transform, false));
		if (this.mPanel == null)
		{
			this.restrictWithinPanel = false;
		}
	}

	// Token: 0x06004D20 RID: 19744 RVA: 0x00125074 File Offset: 0x00123274
	private void OnPress(bool pressed)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.target != null)
		{
			this.mPressed = pressed;
			if (pressed)
			{
				if ((this.restrictWithinPanel || this.restrictToScreen) && this.mPanel == null)
				{
					this.FindPanel();
				}
				if (this.restrictWithinPanel)
				{
					this.mBounds = global::NGUIMath.CalculateRelativeWidgetBounds(this.mPanel.cachedTransform, this.target);
				}
				if (this.restrictToScreen)
				{
					global::UICamera uicamera = global::UICamera.FindCameraForLayer(base.gameObject.layer);
					global::UnityEngine.Rect rect = global::UIDragObject.screenBorder.Add(uicamera.camera.pixelRect);
					this.mBounds = global::AABBox.CenterAndSize(rect.center, new global::UnityEngine.Vector3(rect.width, rect.height, 0f));
				}
				this.mMomentum = global::UnityEngine.Vector3.zero;
				this.mScroll = 0f;
				global::SpringPosition component = this.target.GetComponent<global::SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
				this.mLastPos = global::UICamera.lastHit.point;
				global::UnityEngine.Transform transform = global::UICamera.currentCamera.transform;
				this.mPlane = new global::UnityEngine.Plane(((!(this.mPanel != null)) ? transform.rotation : this.mPanel.cachedTransform.rotation) * global::UnityEngine.Vector3.back, this.mLastPos);
			}
			else if (this.restrictWithinPanel && this.mPanel.clipping != global::UIDrawCall.Clipping.None && this.dragEffect == global::UIDragObject.DragEffect.MomentumAndSpring)
			{
				this.mPanel.ConstrainTargetToBounds(this.target, ref this.mBounds, false);
			}
		}
	}

	// Token: 0x06004D21 RID: 19745 RVA: 0x0012524C File Offset: 0x0012344C
	private void OnDrag(global::UnityEngine.Vector2 delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.target != null)
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
					vector = this.target.InverseTransformDirection(vector);
					vector.Scale(this.scale);
					vector = this.target.TransformDirection(vector);
				}
				this.mMomentum = global::UnityEngine.Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				if (this.restrictWithinPanel)
				{
					global::UnityEngine.Vector3 localPosition = this.target.localPosition;
					this.target.position += vector;
					this.mBounds.center = this.mBounds.center + (this.target.localPosition - localPosition);
					if (this.dragEffect != global::UIDragObject.DragEffect.MomentumAndSpring && this.mPanel.clipping != global::UIDrawCall.Clipping.None && this.mPanel.ConstrainTargetToBounds(this.target, ref this.mBounds, true))
					{
						this.mMomentum = global::UnityEngine.Vector3.zero;
						this.mScroll = 0f;
					}
				}
				else if (this.restrictToScreen)
				{
					this.target.position += vector;
					global::UnityEngine.Vector2 vector2;
					if (this.sizeParent)
					{
						vector2 = this.sizeParent.transform.localScale;
					}
					else
					{
						vector2 = global::NGUIMath.CalculateRelativeWidgetBounds(this.target).size;
					}
					global::UnityEngine.Rect rect = global::UIDragObject.screenBorder.Add(new global::UnityEngine.Rect(0f, (float)(-(float)global::UnityEngine.Screen.height), (float)global::UnityEngine.Screen.width, (float)global::UnityEngine.Screen.height));
					global::UnityEngine.Vector3 localPosition2 = this.target.localPosition;
					bool flag = true;
					if (localPosition2.x + vector2.x > rect.xMax)
					{
						localPosition2.x = rect.xMax - vector2.x;
					}
					else if (localPosition2.x < rect.xMin)
					{
						localPosition2.x = rect.xMin;
					}
					else
					{
						flag = false;
					}
					bool flag2 = true;
					if (localPosition2.y > rect.yMax)
					{
						localPosition2.y = rect.yMax;
					}
					else if (localPosition2.y - vector2.y < rect.yMin)
					{
						localPosition2.y = rect.yMin + vector2.y;
					}
					else
					{
						flag2 = false;
					}
					if (flag || flag2)
					{
						this.target.localPosition = localPosition2;
					}
				}
			}
		}
	}

	// Token: 0x06004D22 RID: 19746 RVA: 0x0012558C File Offset: 0x0012378C
	private void LateUpdate()
	{
		float deltaTime = base.UpdateRealTimeDelta();
		if (this.target == null)
		{
			return;
		}
		if (this.mPressed)
		{
			global::SpringPosition component = this.target.GetComponent<global::SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			this.mScroll = 0f;
		}
		else
		{
			this.mMomentum += this.scale * (-this.mScroll * 0.05f);
			this.mScroll = global::NGUIMath.SpringLerp(this.mScroll, 0f, 20f, deltaTime);
			if (this.mMomentum.magnitude > 0.0001f)
			{
				if (this.mPanel == null)
				{
					this.FindPanel();
				}
				if (this.mPanel != null)
				{
					this.target.position += global::NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
					if (this.restrictWithinPanel && this.mPanel.clipping != global::UIDrawCall.Clipping.None)
					{
						this.mBounds = global::NGUIMath.CalculateRelativeWidgetBounds(this.mPanel.cachedTransform, this.target);
						if (!this.mPanel.ConstrainTargetToBounds(this.target, ref this.mBounds, this.dragEffect == global::UIDragObject.DragEffect.None))
						{
							global::SpringPosition component2 = this.target.GetComponent<global::SpringPosition>();
							if (component2 != null)
							{
								component2.enabled = false;
							}
						}
					}
					return;
				}
			}
			else
			{
				this.mScroll = 0f;
			}
		}
		global::NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
	}

	// Token: 0x06004D23 RID: 19747 RVA: 0x00125734 File Offset: 0x00123934
	private void OnScroll(float delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			if (global::UnityEngine.Mathf.Sign(this.mScroll) != global::UnityEngine.Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x04002A00 RID: 10752
	public global::UnityEngine.Transform target;

	// Token: 0x04002A01 RID: 10753
	public global::UnityEngine.Transform sizeParent;

	// Token: 0x04002A02 RID: 10754
	public global::UnityEngine.Vector3 scale = global::UnityEngine.Vector3.one;

	// Token: 0x04002A03 RID: 10755
	public float scrollWheelFactor;

	// Token: 0x04002A04 RID: 10756
	public bool restrictWithinPanel;

	// Token: 0x04002A05 RID: 10757
	public bool restrictToScreen;

	// Token: 0x04002A06 RID: 10758
	public global::UIDragObject.DragEffect dragEffect = global::UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x04002A07 RID: 10759
	public float momentumAmount = 35f;

	// Token: 0x04002A08 RID: 10760
	private global::UnityEngine.Plane mPlane;

	// Token: 0x04002A09 RID: 10761
	private global::UnityEngine.Vector3 mLastPos;

	// Token: 0x04002A0A RID: 10762
	private global::UIPanel mPanel;

	// Token: 0x04002A0B RID: 10763
	private bool mPressed;

	// Token: 0x04002A0C RID: 10764
	private global::UnityEngine.Vector3 mMomentum = global::UnityEngine.Vector3.zero;

	// Token: 0x04002A0D RID: 10765
	private float mScroll;

	// Token: 0x04002A0E RID: 10766
	private global::AABBox mBounds;

	// Token: 0x020008BE RID: 2238
	public enum DragEffect
	{
		// Token: 0x04002A10 RID: 10768
		None,
		// Token: 0x04002A11 RID: 10769
		Momentum,
		// Token: 0x04002A12 RID: 10770
		MomentumAndSpring
	}
}
