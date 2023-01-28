using System;
using UnityEngine;

// Token: 0x020008B2 RID: 2226
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CDF RID: 19679 RVA: 0x00123D20 File Offset: 0x00121F20
	public UIButtonOffset()
	{
	}

	// Token: 0x06004CE0 RID: 19680 RVA: 0x00123D54 File Offset: 0x00121F54
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06004CE1 RID: 19681 RVA: 0x00123D60 File Offset: 0x00121F60
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004CE2 RID: 19682 RVA: 0x00123D8C File Offset: 0x00121F8C
	private void OnDisable()
	{
		if (this.tweenTarget != null)
		{
			global::TweenPosition component = this.tweenTarget.GetComponent<global::TweenPosition>();
			if (component != null)
			{
				component.position = this.mPos;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06004CE3 RID: 19683 RVA: 0x00123DD8 File Offset: 0x00121FD8
	private void Init()
	{
		this.mInitDone = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.transform;
		}
		this.mPos = this.tweenTarget.localPosition;
	}

	// Token: 0x06004CE4 RID: 19684 RVA: 0x00123E10 File Offset: 0x00122010
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, (!isPressed) ? ((!global::UICamera.IsHighlighted(base.gameObject)) ? this.mPos : (this.mPos + this.hover)) : (this.mPos + this.pressed)).method = global::UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06004CE5 RID: 19685 RVA: 0x00123EA0 File Offset: 0x001220A0
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, (!isOver) ? this.mPos : (this.mPos + this.hover)).method = global::UITweener.Method.EaseInOut;
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x040029B3 RID: 10675
	public global::UnityEngine.Transform tweenTarget;

	// Token: 0x040029B4 RID: 10676
	public global::UnityEngine.Vector3 hover = global::UnityEngine.Vector3.zero;

	// Token: 0x040029B5 RID: 10677
	public global::UnityEngine.Vector3 pressed = new global::UnityEngine.Vector3(2f, -2f);

	// Token: 0x040029B6 RID: 10678
	public float duration = 0.2f;

	// Token: 0x040029B7 RID: 10679
	private global::UnityEngine.Vector3 mPos;

	// Token: 0x040029B8 RID: 10680
	private bool mInitDone;

	// Token: 0x040029B9 RID: 10681
	private bool mStarted;

	// Token: 0x040029BA RID: 10682
	private bool mHighlighted;
}
