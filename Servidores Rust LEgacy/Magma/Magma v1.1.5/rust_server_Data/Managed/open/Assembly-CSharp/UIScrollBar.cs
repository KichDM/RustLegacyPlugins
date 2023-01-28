using System;
using UnityEngine;

// Token: 0x020008CE RID: 2254
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Scroll Bar")]
[global::UnityEngine.ExecuteInEditMode]
public class UIScrollBar : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D87 RID: 19847 RVA: 0x0012873C File Offset: 0x0012693C
	public UIScrollBar()
	{
	}

	// Token: 0x17000E64 RID: 3684
	// (get) Token: 0x06004D88 RID: 19848 RVA: 0x0012875C File Offset: 0x0012695C
	public global::UnityEngine.Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x17000E65 RID: 3685
	// (get) Token: 0x06004D89 RID: 19849 RVA: 0x00128784 File Offset: 0x00126984
	public global::UnityEngine.Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
			}
			return this.mCam;
		}
	}

	// Token: 0x17000E66 RID: 3686
	// (get) Token: 0x06004D8A RID: 19850 RVA: 0x001287B4 File Offset: 0x001269B4
	// (set) Token: 0x06004D8B RID: 19851 RVA: 0x001287BC File Offset: 0x001269BC
	public global::UISprite background
	{
		get
		{
			return this.mBG;
		}
		set
		{
			if (this.mBG != value)
			{
				this.mBG = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x17000E67 RID: 3687
	// (get) Token: 0x06004D8C RID: 19852 RVA: 0x001287E0 File Offset: 0x001269E0
	// (set) Token: 0x06004D8D RID: 19853 RVA: 0x001287E8 File Offset: 0x001269E8
	public global::UISprite foreground
	{
		get
		{
			return this.mFG;
		}
		set
		{
			if (this.mFG != value)
			{
				this.mFG = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x17000E68 RID: 3688
	// (get) Token: 0x06004D8E RID: 19854 RVA: 0x0012880C File Offset: 0x00126A0C
	// (set) Token: 0x06004D8F RID: 19855 RVA: 0x00128814 File Offset: 0x00126A14
	public global::UIScrollBar.Direction direction
	{
		get
		{
			return this.mDir;
		}
		set
		{
			if (this.mDir != value)
			{
				this.mDir = value;
				this.mIsDirty = true;
				if (this.mBG != null)
				{
					global::UnityEngine.Transform cachedTransform = this.mBG.cachedTransform;
					global::UnityEngine.Vector3 localScale = cachedTransform.localScale;
					if ((this.mDir == global::UIScrollBar.Direction.Vertical && localScale.x > localScale.y) || (this.mDir == global::UIScrollBar.Direction.Horizontal && localScale.x < localScale.y))
					{
						float x = localScale.x;
						localScale.x = localScale.y;
						localScale.y = x;
						cachedTransform.localScale = localScale;
						this.ForceUpdate();
						if (this.mBG.collider != null)
						{
							global::NGUITools.AddWidgetHotSpot(this.mBG.gameObject);
						}
						if (this.mFG.collider != null)
						{
							global::NGUITools.AddWidgetHotSpot(this.mFG.gameObject);
						}
					}
				}
			}
		}
	}

	// Token: 0x17000E69 RID: 3689
	// (get) Token: 0x06004D90 RID: 19856 RVA: 0x00128918 File Offset: 0x00126B18
	// (set) Token: 0x06004D91 RID: 19857 RVA: 0x00128920 File Offset: 0x00126B20
	public bool inverted
	{
		get
		{
			return this.mInverted;
		}
		set
		{
			if (this.mInverted != value)
			{
				this.mInverted = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x17000E6A RID: 3690
	// (get) Token: 0x06004D92 RID: 19858 RVA: 0x0012893C File Offset: 0x00126B3C
	// (set) Token: 0x06004D93 RID: 19859 RVA: 0x00128944 File Offset: 0x00126B44
	public float scrollValue
	{
		get
		{
			return this.mScroll;
		}
		set
		{
			float num = global::UnityEngine.Mathf.Clamp01(value);
			if (this.mScroll != num)
			{
				this.mScroll = num;
				this.mIsDirty = true;
				if (this.onChange != null)
				{
					this.onChange(this);
				}
			}
		}
	}

	// Token: 0x17000E6B RID: 3691
	// (get) Token: 0x06004D94 RID: 19860 RVA: 0x0012898C File Offset: 0x00126B8C
	// (set) Token: 0x06004D95 RID: 19861 RVA: 0x00128994 File Offset: 0x00126B94
	public float barSize
	{
		get
		{
			return this.mSize;
		}
		set
		{
			float num = global::UnityEngine.Mathf.Clamp01(value);
			if (this.mSize != num)
			{
				this.mSize = num;
				this.mIsDirty = true;
				if (this.onChange != null)
				{
					this.onChange(this);
				}
			}
		}
	}

	// Token: 0x17000E6C RID: 3692
	// (get) Token: 0x06004D96 RID: 19862 RVA: 0x001289DC File Offset: 0x00126BDC
	// (set) Token: 0x06004D97 RID: 19863 RVA: 0x00128A28 File Offset: 0x00126C28
	public float alpha
	{
		get
		{
			if (this.mFG != null)
			{
				return this.mFG.alpha;
			}
			if (this.mBG != null)
			{
				return this.mBG.alpha;
			}
			return 0f;
		}
		set
		{
			if (this.mFG != null)
			{
				this.mFG.alpha = value;
				this.mFG.gameObject.SetActive(!global::NGUITools.ZeroAlpha(this.mFG.alpha));
			}
			if (this.mBG != null)
			{
				this.mBG.alpha = value;
				this.mBG.gameObject.SetActive(!global::NGUITools.ZeroAlpha(this.mFG.alpha));
			}
		}
	}

	// Token: 0x06004D98 RID: 19864 RVA: 0x00128AB8 File Offset: 0x00126CB8
	private void CenterOnPos(global::UnityEngine.Vector2 localPos)
	{
		if (this.mBG == null || this.mFG == null)
		{
			return;
		}
		global::AABBox aabbox = global::NGUIMath.CalculateRelativeInnerBounds(this.cachedTransform, this.mBG);
		global::AABBox aabbox2 = global::NGUIMath.CalculateRelativeInnerBounds(this.cachedTransform, this.mFG);
		if (this.mDir == global::UIScrollBar.Direction.Horizontal)
		{
			float num = aabbox.size.x - aabbox2.size.x;
			float num2 = num * 0.5f;
			float num3 = aabbox.center.x - num2;
			float num4 = (num <= 0f) ? 0f : ((localPos.x - num3) / num);
			this.scrollValue = ((!this.mInverted) ? num4 : (1f - num4));
		}
		else
		{
			float num5 = aabbox.size.y - aabbox2.size.y;
			float num6 = num5 * 0.5f;
			float num7 = aabbox.center.y - num6;
			float num8 = (num5 <= 0f) ? 0f : (1f - (localPos.y - num7) / num5);
			this.scrollValue = ((!this.mInverted) ? num8 : (1f - num8));
		}
	}

	// Token: 0x06004D99 RID: 19865 RVA: 0x00128C2C File Offset: 0x00126E2C
	private void Reposition(global::UnityEngine.Vector2 screenPos)
	{
		global::UnityEngine.Transform cachedTransform = this.cachedTransform;
		global::UnityEngine.Plane plane;
		plane..ctor(cachedTransform.rotation * global::UnityEngine.Vector3.back, cachedTransform.position);
		global::UnityEngine.Ray ray = this.cachedCamera.ScreenPointToRay(screenPos);
		float num;
		if (!plane.Raycast(ray, ref num))
		{
			return;
		}
		this.CenterOnPos(cachedTransform.InverseTransformPoint(ray.GetPoint(num)));
	}

	// Token: 0x06004D9A RID: 19866 RVA: 0x00128C98 File Offset: 0x00126E98
	private void OnPressBackground(global::UnityEngine.GameObject go, bool isPressed)
	{
		this.mCam = global::UICamera.currentCamera;
		this.Reposition(global::UICamera.lastTouchPosition);
	}

	// Token: 0x06004D9B RID: 19867 RVA: 0x00128CB0 File Offset: 0x00126EB0
	private void OnDragBackground(global::UnityEngine.GameObject go, global::UnityEngine.Vector2 delta)
	{
		this.mCam = global::UICamera.currentCamera;
		this.Reposition(global::UICamera.lastTouchPosition);
	}

	// Token: 0x06004D9C RID: 19868 RVA: 0x00128CC8 File Offset: 0x00126EC8
	private void OnPressForeground(global::UnityEngine.GameObject go, bool isPressed)
	{
		if (isPressed)
		{
			this.mCam = global::UICamera.currentCamera;
			global::AABBox aabbox = global::NGUIMath.CalculateAbsoluteWidgetBounds(this.mFG.cachedTransform);
			this.mScreenPos = this.mCam.WorldToScreenPoint(aabbox.center);
		}
	}

	// Token: 0x06004D9D RID: 19869 RVA: 0x00128D14 File Offset: 0x00126F14
	private void OnDragForeground(global::UnityEngine.GameObject go, global::UnityEngine.Vector2 delta)
	{
		this.mCam = global::UICamera.currentCamera;
		this.Reposition(this.mScreenPos + global::UICamera.currentTouch.totalDelta);
	}

	// Token: 0x06004D9E RID: 19870 RVA: 0x00128D48 File Offset: 0x00126F48
	private void Start()
	{
		if (this.background != null && global::NGUITools.HasMeansOfClicking(this.background))
		{
			global::UIEventListener uieventListener = global::UIEventListener.Get(this.background.gameObject);
			global::UIEventListener uieventListener2 = uieventListener;
			uieventListener2.onPress = (global::UIEventListener.BoolDelegate)global::System.Delegate.Combine(uieventListener2.onPress, new global::UIEventListener.BoolDelegate(this.OnPressBackground));
			global::UIEventListener uieventListener3 = uieventListener;
			uieventListener3.onDrag = (global::UIEventListener.VectorDelegate)global::System.Delegate.Combine(uieventListener3.onDrag, new global::UIEventListener.VectorDelegate(this.OnDragBackground));
		}
		if (this.foreground != null && global::NGUITools.HasMeansOfClicking(this.foreground))
		{
			global::UIEventListener uieventListener4 = global::UIEventListener.Get(this.foreground.gameObject);
			global::UIEventListener uieventListener5 = uieventListener4;
			uieventListener5.onPress = (global::UIEventListener.BoolDelegate)global::System.Delegate.Combine(uieventListener5.onPress, new global::UIEventListener.BoolDelegate(this.OnPressForeground));
			global::UIEventListener uieventListener6 = uieventListener4;
			uieventListener6.onDrag = (global::UIEventListener.VectorDelegate)global::System.Delegate.Combine(uieventListener6.onDrag, new global::UIEventListener.VectorDelegate(this.OnDragForeground));
		}
		this.ForceUpdate();
	}

	// Token: 0x06004D9F RID: 19871 RVA: 0x00128E48 File Offset: 0x00127048
	private void Update()
	{
		if (this.mIsDirty)
		{
			this.ForceUpdate();
		}
	}

	// Token: 0x06004DA0 RID: 19872 RVA: 0x00128E5C File Offset: 0x0012705C
	public void ForceUpdate()
	{
		this.mIsDirty = false;
		if (this.mBG != null && this.mFG != null)
		{
			this.mSize = global::UnityEngine.Mathf.Clamp01(this.mSize);
			this.mScroll = global::UnityEngine.Mathf.Clamp01(this.mScroll);
			global::UnityEngine.Vector4 border = this.mBG.border;
			global::UnityEngine.Vector4 border2 = this.mFG.border;
			global::UnityEngine.Vector2 vector;
			vector..ctor(global::UnityEngine.Mathf.Max(0f, this.mBG.cachedTransform.localScale.x - border.x - border.z), global::UnityEngine.Mathf.Max(0f, this.mBG.cachedTransform.localScale.y - border.y - border.w));
			float num = (!this.mInverted) ? this.mScroll : (1f - this.mScroll);
			if (this.mDir == global::UIScrollBar.Direction.Horizontal)
			{
				global::UnityEngine.Vector2 vector2;
				vector2..ctor(vector.x * this.mSize, vector.y);
				this.mFG.pivot = global::UIWidget.Pivot.Left;
				this.mBG.pivot = global::UIWidget.Pivot.Left;
				this.mBG.cachedTransform.localPosition = global::UnityEngine.Vector3.zero;
				this.mFG.cachedTransform.localPosition = new global::UnityEngine.Vector3(border.x - border2.x + (vector.x - vector2.x) * num, 0f, 0f);
				this.mFG.cachedTransform.localScale = new global::UnityEngine.Vector3(vector2.x + border2.x + border2.z, vector2.y + border2.y + border2.w, 1f);
				if (num < 0.999f && num > 0.001f)
				{
					this.mFG.MakePixelPerfect();
				}
			}
			else
			{
				global::UnityEngine.Vector2 vector3;
				vector3..ctor(vector.x, vector.y * this.mSize);
				this.mFG.pivot = global::UIWidget.Pivot.Top;
				this.mBG.pivot = global::UIWidget.Pivot.Top;
				this.mBG.cachedTransform.localPosition = global::UnityEngine.Vector3.zero;
				this.mFG.cachedTransform.localPosition = new global::UnityEngine.Vector3(0f, -border.y + border2.y - (vector.y - vector3.y) * num, 0f);
				this.mFG.cachedTransform.localScale = new global::UnityEngine.Vector3(vector3.x + border2.x + border2.z, vector3.y + border2.y + border2.w, 1f);
				if (num < 0.999f && num > 0.001f)
				{
					this.mFG.MakePixelPerfect();
				}
			}
		}
	}

	// Token: 0x04002A88 RID: 10888
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UISprite mBG;

	// Token: 0x04002A89 RID: 10889
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UISprite mFG;

	// Token: 0x04002A8A RID: 10890
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIScrollBar.Direction mDir;

	// Token: 0x04002A8B RID: 10891
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mInverted;

	// Token: 0x04002A8C RID: 10892
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float mScroll;

	// Token: 0x04002A8D RID: 10893
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float mSize = 1f;

	// Token: 0x04002A8E RID: 10894
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002A8F RID: 10895
	private bool mIsDirty;

	// Token: 0x04002A90 RID: 10896
	private global::UnityEngine.Camera mCam;

	// Token: 0x04002A91 RID: 10897
	private global::UnityEngine.Vector2 mScreenPos = global::UnityEngine.Vector2.zero;

	// Token: 0x04002A92 RID: 10898
	public global::UIScrollBar.OnScrollBarChange onChange;

	// Token: 0x020008CF RID: 2255
	public enum Direction
	{
		// Token: 0x04002A94 RID: 10900
		Horizontal,
		// Token: 0x04002A95 RID: 10901
		Vertical
	}

	// Token: 0x020008D0 RID: 2256
	// (Invoke) Token: 0x06004DA2 RID: 19874
	public delegate void OnScrollBarChange(global::UIScrollBar sb);
}
