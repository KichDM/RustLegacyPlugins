using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x020008B8 RID: 2232
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Tween")]
public class UIButtonTween : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D02 RID: 19714 RVA: 0x001246D8 File Offset: 0x001228D8
	public UIButtonTween()
	{
	}

	// Token: 0x06004D03 RID: 19715 RVA: 0x001246E8 File Offset: 0x001228E8
	private void Start()
	{
		this.mStarted = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
	}

	// Token: 0x06004D04 RID: 19716 RVA: 0x0012471C File Offset: 0x0012291C
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004D05 RID: 19717 RVA: 0x00124748 File Offset: 0x00122948
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (this.trigger == global::AnimationOrTween.Trigger.OnHover || (this.trigger == global::AnimationOrTween.Trigger.OnHoverTrue && isOver) || (this.trigger == global::AnimationOrTween.Trigger.OnHoverFalse && !isOver))
			{
				this.Play(isOver);
			}
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x06004D06 RID: 19718 RVA: 0x001247A0 File Offset: 0x001229A0
	private void OnPress(bool isPressed)
	{
		if (base.enabled && (this.trigger == global::AnimationOrTween.Trigger.OnPress || (this.trigger == global::AnimationOrTween.Trigger.OnPressTrue && isPressed) || (this.trigger == global::AnimationOrTween.Trigger.OnPressFalse && !isPressed)))
		{
			this.Play(isPressed);
		}
	}

	// Token: 0x06004D07 RID: 19719 RVA: 0x001247F0 File Offset: 0x001229F0
	private void OnClick()
	{
		if (base.enabled && this.trigger == global::AnimationOrTween.Trigger.OnClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06004D08 RID: 19720 RVA: 0x00124810 File Offset: 0x00122A10
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == global::AnimationOrTween.Trigger.OnDoubleClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06004D09 RID: 19721 RVA: 0x00124834 File Offset: 0x00122A34
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (this.trigger == global::AnimationOrTween.Trigger.OnSelect || (this.trigger == global::AnimationOrTween.Trigger.OnSelectTrue && isSelected) || (this.trigger == global::AnimationOrTween.Trigger.OnSelectFalse && !isSelected)))
		{
			this.Play(true);
		}
	}

	// Token: 0x06004D0A RID: 19722 RVA: 0x00124888 File Offset: 0x00122A88
	private void OnActivate(bool isActive)
	{
		if (base.enabled && (this.trigger == global::AnimationOrTween.Trigger.OnActivate || (this.trigger == global::AnimationOrTween.Trigger.OnActivateTrue && isActive) || (this.trigger == global::AnimationOrTween.Trigger.OnActivateFalse && !isActive)))
		{
			this.Play(isActive);
		}
	}

	// Token: 0x06004D0B RID: 19723 RVA: 0x001248D8 File Offset: 0x00122AD8
	private void Update()
	{
		if (this.disableWhenFinished != global::AnimationOrTween.DisableCondition.DoNotDisable && this.mTweens != null)
		{
			bool flag = true;
			bool flag2 = true;
			int i = 0;
			int num = this.mTweens.Length;
			while (i < num)
			{
				global::UITweener uitweener = this.mTweens[i];
				if (uitweener.enabled)
				{
					flag = false;
					break;
				}
				if (uitweener.direction != (global::AnimationOrTween.Direction)this.disableWhenFinished)
				{
					flag2 = false;
				}
				i++;
			}
			if (flag)
			{
				if (flag2)
				{
					global::NGUITools.SetActive(this.tweenTarget, false);
				}
				this.mTweens = null;
			}
		}
	}

	// Token: 0x06004D0C RID: 19724 RVA: 0x0012496C File Offset: 0x00122B6C
	public void Play(bool forward)
	{
		global::UnityEngine.GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			if (this.ifDisabledOnPlay != global::AnimationOrTween.EnableCondition.EnableThenPlay)
			{
				return;
			}
			global::NGUITools.SetActive(gameObject, true);
		}
		this.mTweens = ((!this.includeChildren) ? gameObject.GetComponents<global::UITweener>() : gameObject.GetComponentsInChildren<global::UITweener>());
		if (this.mTweens.Length == 0)
		{
			if (this.disableWhenFinished != global::AnimationOrTween.DisableCondition.DoNotDisable)
			{
				global::NGUITools.SetActive(this.tweenTarget, false);
			}
		}
		else
		{
			bool flag = false;
			if (this.playDirection == global::AnimationOrTween.Direction.Reverse)
			{
				forward = !forward;
			}
			int i = 0;
			int num = this.mTweens.Length;
			while (i < num)
			{
				global::UITweener uitweener = this.mTweens[i];
				if (uitweener.tweenGroup == this.tweenGroup)
				{
					if (!flag && !gameObject.activeInHierarchy)
					{
						flag = true;
						global::NGUITools.SetActive(gameObject, true);
					}
					if (this.playDirection == global::AnimationOrTween.Direction.Toggle)
					{
						uitweener.Toggle();
					}
					else
					{
						uitweener.Play(forward);
					}
					if (this.resetOnPlay)
					{
						uitweener.Reset();
					}
					if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
					{
						uitweener.eventReceiver = this.eventReceiver;
						uitweener.callWhenFinished = this.callWhenFinished;
					}
				}
				i++;
			}
		}
	}

	// Token: 0x040029E1 RID: 10721
	public global::UnityEngine.GameObject tweenTarget;

	// Token: 0x040029E2 RID: 10722
	public int tweenGroup;

	// Token: 0x040029E3 RID: 10723
	public global::AnimationOrTween.Trigger trigger;

	// Token: 0x040029E4 RID: 10724
	public global::AnimationOrTween.Direction playDirection = global::AnimationOrTween.Direction.Forward;

	// Token: 0x040029E5 RID: 10725
	public bool resetOnPlay;

	// Token: 0x040029E6 RID: 10726
	public global::AnimationOrTween.EnableCondition ifDisabledOnPlay;

	// Token: 0x040029E7 RID: 10727
	public global::AnimationOrTween.DisableCondition disableWhenFinished;

	// Token: 0x040029E8 RID: 10728
	public bool includeChildren;

	// Token: 0x040029E9 RID: 10729
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x040029EA RID: 10730
	public string callWhenFinished;

	// Token: 0x040029EB RID: 10731
	private global::UITweener[] mTweens;

	// Token: 0x040029EC RID: 10732
	private bool mStarted;

	// Token: 0x040029ED RID: 10733
	private bool mHighlighted;
}
