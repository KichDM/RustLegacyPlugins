using System;
using UnityEngine;

// Token: 0x020008B4 RID: 2228
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CF0 RID: 19696 RVA: 0x001241D0 File Offset: 0x001223D0
	public UIButtonRotation()
	{
	}

	// Token: 0x06004CF1 RID: 19697 RVA: 0x001241FC File Offset: 0x001223FC
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06004CF2 RID: 19698 RVA: 0x00124208 File Offset: 0x00122408
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004CF3 RID: 19699 RVA: 0x00124234 File Offset: 0x00122434
	private void OnDisable()
	{
		if (this.tweenTarget != null)
		{
			global::TweenRotation component = this.tweenTarget.GetComponent<global::TweenRotation>();
			if (component != null)
			{
				component.rotation = this.mRot;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06004CF4 RID: 19700 RVA: 0x00124280 File Offset: 0x00122480
	private void Init()
	{
		this.mInitDone = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.transform;
		}
		this.mRot = this.tweenTarget.localRotation;
	}

	// Token: 0x06004CF5 RID: 19701 RVA: 0x001242B8 File Offset: 0x001224B8
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, (!isPressed) ? ((!global::UICamera.IsHighlighted(base.gameObject)) ? this.mRot : (this.mRot * global::UnityEngine.Quaternion.Euler(this.hover))) : (this.mRot * global::UnityEngine.Quaternion.Euler(this.pressed))).method = global::UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06004CF6 RID: 19702 RVA: 0x00124350 File Offset: 0x00122550
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, (!isOver) ? this.mRot : (this.mRot * global::UnityEngine.Quaternion.Euler(this.hover))).method = global::UITweener.Method.EaseInOut;
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x040029C7 RID: 10695
	public global::UnityEngine.Transform tweenTarget;

	// Token: 0x040029C8 RID: 10696
	public global::UnityEngine.Vector3 hover = global::UnityEngine.Vector3.zero;

	// Token: 0x040029C9 RID: 10697
	public global::UnityEngine.Vector3 pressed = global::UnityEngine.Vector3.zero;

	// Token: 0x040029CA RID: 10698
	public float duration = 0.2f;

	// Token: 0x040029CB RID: 10699
	private global::UnityEngine.Quaternion mRot;

	// Token: 0x040029CC RID: 10700
	private bool mInitDone;

	// Token: 0x040029CD RID: 10701
	private bool mStarted;

	// Token: 0x040029CE RID: 10702
	private bool mHighlighted;
}
