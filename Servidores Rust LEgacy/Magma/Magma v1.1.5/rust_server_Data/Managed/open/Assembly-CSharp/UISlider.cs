using System;
using UnityEngine;

// Token: 0x020008D1 RID: 2257
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Slider")]
[global::UnityEngine.ExecuteInEditMode]
public class UISlider : global::IgnoreTimeScale
{
	// Token: 0x06004DA5 RID: 19877 RVA: 0x00129154 File Offset: 0x00127354
	public UISlider()
	{
	}

	// Token: 0x17000E6D RID: 3693
	// (get) Token: 0x06004DA6 RID: 19878 RVA: 0x00129194 File Offset: 0x00127394
	// (set) Token: 0x06004DA7 RID: 19879 RVA: 0x0012919C File Offset: 0x0012739C
	public float sliderValue
	{
		get
		{
			return this.mStepValue;
		}
		set
		{
			this.Set(value, false);
		}
	}

	// Token: 0x06004DA8 RID: 19880 RVA: 0x001291A8 File Offset: 0x001273A8
	private void Init()
	{
		this.mInitDone = true;
		if (this.foreground != null)
		{
			this.mFGWidget = this.foreground.GetComponent<global::UIWidget>();
			this.mFGFilled = ((!(this.mFGWidget != null)) ? null : (this.mFGWidget as global::UIFilledSprite));
			this.mFGTrans = this.foreground.transform;
			if (this.fullSize == global::UnityEngine.Vector2.zero)
			{
				this.fullSize = this.foreground.localScale;
			}
		}
		else if (this.mCol != null)
		{
			if (this.fullSize == global::UnityEngine.Vector2.zero)
			{
				this.fullSize = this.mCol.size;
			}
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("UISlider expected to find a foreground object or a box collider to work with", this);
		}
	}

	// Token: 0x06004DA9 RID: 19881 RVA: 0x00129294 File Offset: 0x00127494
	private void Awake()
	{
		this.mTrans = base.transform;
		this.mCol = (base.collider as global::UnityEngine.BoxCollider);
	}

	// Token: 0x06004DAA RID: 19882 RVA: 0x001292B4 File Offset: 0x001274B4
	private void Start()
	{
		this.Init();
		if (global::UnityEngine.Application.isPlaying && this.thumb != null && global::NGUITools.HasMeansOfClicking(this.thumb))
		{
			global::UIEventListener uieventListener = global::UIEventListener.Get(this.thumb.gameObject);
			global::UIEventListener uieventListener2 = uieventListener;
			uieventListener2.onPress = (global::UIEventListener.BoolDelegate)global::System.Delegate.Combine(uieventListener2.onPress, new global::UIEventListener.BoolDelegate(this.OnPressThumb));
			global::UIEventListener uieventListener3 = uieventListener;
			uieventListener3.onDrag = (global::UIEventListener.VectorDelegate)global::System.Delegate.Combine(uieventListener3.onDrag, new global::UIEventListener.VectorDelegate(this.OnDragThumb));
		}
		this.Set(this.rawValue, true);
	}

	// Token: 0x06004DAB RID: 19883 RVA: 0x00129354 File Offset: 0x00127554
	private void OnPress(bool pressed)
	{
		if (pressed)
		{
			this.UpdateDrag();
		}
	}

	// Token: 0x06004DAC RID: 19884 RVA: 0x00129364 File Offset: 0x00127564
	private void OnDrag(global::UnityEngine.Vector2 delta)
	{
		this.UpdateDrag();
	}

	// Token: 0x06004DAD RID: 19885 RVA: 0x0012936C File Offset: 0x0012756C
	private void OnPressThumb(global::UnityEngine.GameObject go, bool pressed)
	{
		if (pressed)
		{
			this.UpdateDrag();
		}
	}

	// Token: 0x06004DAE RID: 19886 RVA: 0x0012937C File Offset: 0x0012757C
	private void OnDragThumb(global::UnityEngine.GameObject go, global::UnityEngine.Vector2 delta)
	{
		this.UpdateDrag();
	}

	// Token: 0x06004DAF RID: 19887 RVA: 0x00129384 File Offset: 0x00127584
	private void OnKey(global::UnityEngine.KeyCode key)
	{
		float num = ((float)this.numberOfSteps <= 1f) ? 0.125f : (1f / (float)(this.numberOfSteps - 1));
		if (this.direction == global::UISlider.Direction.Horizontal)
		{
			if (key == 0x114)
			{
				this.Set(this.rawValue - num, false);
			}
			else if (key == 0x113)
			{
				this.Set(this.rawValue + num, false);
			}
		}
		else if (key == 0x112)
		{
			this.Set(this.rawValue - num, false);
		}
		else if (key == 0x111)
		{
			this.Set(this.rawValue + num, false);
		}
	}

	// Token: 0x06004DB0 RID: 19888 RVA: 0x00129440 File Offset: 0x00127640
	private void UpdateDrag()
	{
		if (this.mCol == null || global::UICamera.currentCamera == null || !global::UICamera.IsPressing)
		{
			return;
		}
		global::UICamera.currentTouch.clickNotification = global::UICamera.ClickNotification.None;
		global::UnityEngine.Ray ray = global::UICamera.currentCamera.ScreenPointToRay(global::UICamera.currentTouch.pos);
		global::UnityEngine.Plane plane;
		plane..ctor(this.mTrans.rotation * global::UnityEngine.Vector3.back, this.mTrans.position);
		float num;
		if (!plane.Raycast(ray, ref num))
		{
			return;
		}
		global::UnityEngine.Vector3 vector = this.mTrans.localPosition + this.mCol.center - this.mCol.size * 0.5f;
		global::UnityEngine.Vector3 vector2 = this.mTrans.localPosition - vector;
		global::UnityEngine.Vector3 vector3 = this.mTrans.InverseTransformPoint(ray.GetPoint(num));
		global::UnityEngine.Vector3 vector4 = vector3 + vector2;
		this.Set((this.direction != global::UISlider.Direction.Horizontal) ? (vector4.y / this.mCol.size.y) : (vector4.x / this.mCol.size.x), false);
	}

	// Token: 0x06004DB1 RID: 19889 RVA: 0x00129590 File Offset: 0x00127790
	private void Set(float input, bool force)
	{
		if (!this.mInitDone)
		{
			this.Init();
		}
		float num = global::UnityEngine.Mathf.Clamp01(input);
		if (num < 0.001f)
		{
			num = 0f;
		}
		this.rawValue = num;
		if (this.numberOfSteps > 1)
		{
			num = global::UnityEngine.Mathf.Round(num * (float)(this.numberOfSteps - 1)) / (float)(this.numberOfSteps - 1);
		}
		if (force || this.mStepValue != num)
		{
			this.mStepValue = num;
			global::UnityEngine.Vector3 localScale = this.fullSize;
			if (this.direction == global::UISlider.Direction.Horizontal)
			{
				localScale.x *= this.mStepValue;
			}
			else
			{
				localScale.y *= this.mStepValue;
			}
			if (this.mFGFilled != null)
			{
				this.mFGFilled.fillAmount = this.mStepValue;
			}
			else if (this.foreground != null)
			{
				this.mFGTrans.localScale = localScale;
				if (this.mFGWidget != null)
				{
					if (num > 0.001f)
					{
						this.mFGWidget.enabled = true;
						this.mFGWidget.MarkAsChanged();
					}
					else
					{
						this.mFGWidget.enabled = false;
					}
				}
			}
			if (this.thumb != null)
			{
				global::UnityEngine.Vector3 localPosition = this.thumb.localPosition;
				if (this.mFGFilled != null)
				{
					if (this.mFGFilled.fillDirection == global::UIFilledSprite.FillDirection.Horizontal)
					{
						localPosition.x = ((!this.mFGFilled.invert) ? localScale.x : (this.fullSize.x - localScale.x));
					}
					else if (this.mFGFilled.fillDirection == global::UIFilledSprite.FillDirection.Vertical)
					{
						localPosition.y = ((!this.mFGFilled.invert) ? localScale.y : (this.fullSize.y - localScale.y));
					}
				}
				else if (this.direction == global::UISlider.Direction.Horizontal)
				{
					localPosition.x = localScale.x;
				}
				else
				{
					localPosition.y = localScale.y;
				}
				this.thumb.localPosition = localPosition;
			}
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName) && global::UnityEngine.Application.isPlaying)
			{
				global::UISlider.current = this;
				this.eventReceiver.SendMessage(this.functionName, this.mStepValue, 1);
				global::UISlider.current = null;
			}
		}
	}

	// Token: 0x06004DB2 RID: 19890 RVA: 0x0012982C File Offset: 0x00127A2C
	public void ForceUpdate()
	{
		this.Set(this.rawValue, true);
	}

	// Token: 0x04002A96 RID: 10902
	public static global::UISlider current;

	// Token: 0x04002A97 RID: 10903
	public global::UnityEngine.Transform foreground;

	// Token: 0x04002A98 RID: 10904
	public global::UnityEngine.Transform thumb;

	// Token: 0x04002A99 RID: 10905
	public global::UISlider.Direction direction;

	// Token: 0x04002A9A RID: 10906
	public global::UnityEngine.Vector2 fullSize = global::UnityEngine.Vector2.zero;

	// Token: 0x04002A9B RID: 10907
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x04002A9C RID: 10908
	public string functionName = "OnSliderChange";

	// Token: 0x04002A9D RID: 10909
	public int numberOfSteps;

	// Token: 0x04002A9E RID: 10910
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float rawValue = 1f;

	// Token: 0x04002A9F RID: 10911
	private float mStepValue = 1f;

	// Token: 0x04002AA0 RID: 10912
	private global::UnityEngine.BoxCollider mCol;

	// Token: 0x04002AA1 RID: 10913
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002AA2 RID: 10914
	private global::UnityEngine.Transform mFGTrans;

	// Token: 0x04002AA3 RID: 10915
	private global::UIWidget mFGWidget;

	// Token: 0x04002AA4 RID: 10916
	private global::UIFilledSprite mFGFilled;

	// Token: 0x04002AA5 RID: 10917
	private bool mInitDone;

	// Token: 0x020008D2 RID: 2258
	public enum Direction
	{
		// Token: 0x04002AA7 RID: 10919
		Horizontal,
		// Token: 0x04002AA8 RID: 10920
		Vertical
	}
}
