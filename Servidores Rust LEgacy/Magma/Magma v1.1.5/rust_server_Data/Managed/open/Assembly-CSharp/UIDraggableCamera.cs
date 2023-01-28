using System;
using UnityEngine;

// Token: 0x020008C0 RID: 2240
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Draggable Camera")]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class UIDraggableCamera : global::IgnoreTimeScale
{
	// Token: 0x06004D2A RID: 19754 RVA: 0x00125914 File Offset: 0x00123B14
	public UIDraggableCamera()
	{
	}

	// Token: 0x17000E57 RID: 3671
	// (get) Token: 0x06004D2B RID: 19755 RVA: 0x00125950 File Offset: 0x00123B50
	// (set) Token: 0x06004D2C RID: 19756 RVA: 0x00125958 File Offset: 0x00123B58
	public global::UnityEngine.Vector2 currentMomentum
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

	// Token: 0x06004D2D RID: 19757 RVA: 0x00125964 File Offset: 0x00123B64
	private void Awake()
	{
		this.mCam = base.camera;
		this.mTrans = base.transform;
		if (this.rootForBounds == null)
		{
			global::UnityEngine.Debug.LogError(global::NGUITools.GetHierarchy(base.gameObject) + " needs the 'Root For Bounds' parameter to be set", this);
			base.enabled = false;
		}
	}

	// Token: 0x06004D2E RID: 19758 RVA: 0x001259BC File Offset: 0x00123BBC
	private void Start()
	{
		this.mRoot = global::NGUITools.FindInParents<global::UIRoot>(base.gameObject);
	}

	// Token: 0x06004D2F RID: 19759 RVA: 0x001259D0 File Offset: 0x00123BD0
	private global::UnityEngine.Vector3 CalculateConstrainOffset()
	{
		if (this.rootForBounds == null || this.rootForBounds.childCount == 0)
		{
			return global::UnityEngine.Vector3.zero;
		}
		global::UnityEngine.Vector3 vector;
		vector..ctor(this.mCam.rect.xMin * (float)global::UnityEngine.Screen.width, this.mCam.rect.yMin * (float)global::UnityEngine.Screen.height, 0f);
		global::UnityEngine.Vector3 vector2;
		vector2..ctor(this.mCam.rect.xMax * (float)global::UnityEngine.Screen.width, this.mCam.rect.yMax * (float)global::UnityEngine.Screen.height, 0f);
		vector = this.mCam.ScreenToWorldPoint(vector);
		vector2 = this.mCam.ScreenToWorldPoint(vector2);
		global::UnityEngine.Vector2 minRect;
		minRect..ctor(this.mBounds.min.x, this.mBounds.min.y);
		global::UnityEngine.Vector2 maxRect;
		maxRect..ctor(this.mBounds.max.x, this.mBounds.max.y);
		return global::NGUIMath.ConstrainRect(minRect, maxRect, vector, vector2);
	}

	// Token: 0x06004D30 RID: 19760 RVA: 0x00125B18 File Offset: 0x00123D18
	public bool ConstrainToBounds(bool immediate)
	{
		if (this.mTrans != null && this.rootForBounds != null)
		{
			global::UnityEngine.Vector3 vector = this.CalculateConstrainOffset();
			if (vector.magnitude > 0f)
			{
				if (immediate)
				{
					this.mTrans.position -= vector;
				}
				else
				{
					global::SpringPosition springPosition = global::SpringPosition.Begin(base.gameObject, this.mTrans.position - vector, 13f);
					springPosition.ignoreTimeScale = true;
					springPosition.worldSpace = true;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004D31 RID: 19761 RVA: 0x00125BB4 File Offset: 0x00123DB4
	public void Press(bool isPressed)
	{
		if (this.rootForBounds != null)
		{
			this.mPressed = isPressed;
			if (isPressed)
			{
				this.mBounds = global::NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
				this.mMomentum = global::UnityEngine.Vector2.zero;
				this.mScroll = 0f;
				global::SpringPosition component = base.GetComponent<global::SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else if (this.dragEffect == global::UIDragObject.DragEffect.MomentumAndSpring)
			{
				this.ConstrainToBounds(false);
			}
		}
	}

	// Token: 0x06004D32 RID: 19762 RVA: 0x00125C3C File Offset: 0x00123E3C
	public void Drag(global::UnityEngine.Vector2 delta)
	{
		global::UICamera.currentTouch.clickNotification = global::UICamera.ClickNotification.BasedOnDelta;
		if (this.mRoot != null && !this.mRoot.automatic)
		{
			delta *= (float)this.mRoot.manualHeight / (float)global::UnityEngine.Screen.height;
		}
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.Scale(delta, -this.scale);
		this.mTrans.localPosition += vector;
		this.mMomentum = global::UnityEngine.Vector2.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
		if (this.dragEffect != global::UIDragObject.DragEffect.MomentumAndSpring && this.ConstrainToBounds(true))
		{
			this.mMomentum = global::UnityEngine.Vector2.zero;
			this.mScroll = 0f;
		}
	}

	// Token: 0x06004D33 RID: 19763 RVA: 0x00125D20 File Offset: 0x00123F20
	public void Scroll(float delta)
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

	// Token: 0x06004D34 RID: 19764 RVA: 0x00125D80 File Offset: 0x00123F80
	private void Update()
	{
		float deltaTime = base.UpdateRealTimeDelta();
		if (this.mPressed)
		{
			global::SpringPosition component = base.GetComponent<global::SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			this.mScroll = 0f;
		}
		else
		{
			this.mMomentum += this.scale * (this.mScroll * 20f);
			this.mScroll = global::NGUIMath.SpringLerp(this.mScroll, 0f, 20f, deltaTime);
			if (this.mMomentum.magnitude > 0.01f)
			{
				this.mTrans.localPosition += global::NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
				this.mBounds = global::NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
				if (!this.ConstrainToBounds(this.dragEffect == global::UIDragObject.DragEffect.None))
				{
					global::SpringPosition component2 = base.GetComponent<global::SpringPosition>();
					if (component2 != null)
					{
						component2.enabled = false;
					}
				}
				return;
			}
			this.mScroll = 0f;
		}
		global::NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
	}

	// Token: 0x04002A15 RID: 10773
	public global::UnityEngine.Transform rootForBounds;

	// Token: 0x04002A16 RID: 10774
	public global::UnityEngine.Vector2 scale = global::UnityEngine.Vector2.one;

	// Token: 0x04002A17 RID: 10775
	public float scrollWheelFactor;

	// Token: 0x04002A18 RID: 10776
	public global::UIDragObject.DragEffect dragEffect = global::UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x04002A19 RID: 10777
	public float momentumAmount = 35f;

	// Token: 0x04002A1A RID: 10778
	private global::UnityEngine.Camera mCam;

	// Token: 0x04002A1B RID: 10779
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002A1C RID: 10780
	private bool mPressed;

	// Token: 0x04002A1D RID: 10781
	private global::UnityEngine.Vector2 mMomentum = global::UnityEngine.Vector2.zero;

	// Token: 0x04002A1E RID: 10782
	private global::AABBox mBounds;

	// Token: 0x04002A1F RID: 10783
	private float mScroll;

	// Token: 0x04002A20 RID: 10784
	private global::UIRoot mRoot;
}
