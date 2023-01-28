using System;
using UnityEngine;

// Token: 0x020008B5 RID: 2229
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Scale")]
public class UIButtonScale : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CF7 RID: 19703 RVA: 0x001243C4 File Offset: 0x001225C4
	public UIButtonScale()
	{
	}

	// Token: 0x06004CF8 RID: 19704 RVA: 0x00124418 File Offset: 0x00122618
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06004CF9 RID: 19705 RVA: 0x00124424 File Offset: 0x00122624
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004CFA RID: 19706 RVA: 0x00124450 File Offset: 0x00122650
	private void OnDisable()
	{
		if (this.tweenTarget != null)
		{
			global::TweenScale component = this.tweenTarget.GetComponent<global::TweenScale>();
			if (component != null)
			{
				component.scale = this.mScale;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06004CFB RID: 19707 RVA: 0x0012449C File Offset: 0x0012269C
	private void Init()
	{
		this.mInitDone = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.transform;
		}
		this.mScale = this.tweenTarget.localScale;
	}

	// Token: 0x06004CFC RID: 19708 RVA: 0x001244D4 File Offset: 0x001226D4
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenScale.Begin(this.tweenTarget.gameObject, this.duration, (!isPressed) ? ((!global::UICamera.IsHighlighted(base.gameObject)) ? this.mScale : global::UnityEngine.Vector3.Scale(this.mScale, this.hover)) : global::UnityEngine.Vector3.Scale(this.mScale, this.pressed)).method = global::UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06004CFD RID: 19709 RVA: 0x00124564 File Offset: 0x00122764
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenScale.Begin(this.tweenTarget.gameObject, this.duration, (!isOver) ? this.mScale : global::UnityEngine.Vector3.Scale(this.mScale, this.hover)).method = global::UITweener.Method.EaseInOut;
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x040029CF RID: 10703
	public global::UnityEngine.Transform tweenTarget;

	// Token: 0x040029D0 RID: 10704
	public global::UnityEngine.Vector3 hover = new global::UnityEngine.Vector3(1.1f, 1.1f, 1.1f);

	// Token: 0x040029D1 RID: 10705
	public global::UnityEngine.Vector3 pressed = new global::UnityEngine.Vector3(1.05f, 1.05f, 1.05f);

	// Token: 0x040029D2 RID: 10706
	public float duration = 0.2f;

	// Token: 0x040029D3 RID: 10707
	private global::UnityEngine.Vector3 mScale;

	// Token: 0x040029D4 RID: 10708
	private bool mInitDone;

	// Token: 0x040029D5 RID: 10709
	private bool mStarted;

	// Token: 0x040029D6 RID: 10710
	private bool mHighlighted;
}
