using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x020008B3 RID: 2227
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Play Animation")]
public class UIButtonPlayAnimation : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CE6 RID: 19686 RVA: 0x00123F10 File Offset: 0x00122110
	public UIButtonPlayAnimation()
	{
	}

	// Token: 0x06004CE7 RID: 19687 RVA: 0x00123F20 File Offset: 0x00122120
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06004CE8 RID: 19688 RVA: 0x00123F2C File Offset: 0x0012212C
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004CE9 RID: 19689 RVA: 0x00123F58 File Offset: 0x00122158
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

	// Token: 0x06004CEA RID: 19690 RVA: 0x00123FB0 File Offset: 0x001221B0
	private void OnPress(bool isPressed)
	{
		if (base.enabled && (this.trigger == global::AnimationOrTween.Trigger.OnPress || (this.trigger == global::AnimationOrTween.Trigger.OnPressTrue && isPressed) || (this.trigger == global::AnimationOrTween.Trigger.OnPressFalse && !isPressed)))
		{
			this.Play(isPressed);
		}
	}

	// Token: 0x06004CEB RID: 19691 RVA: 0x00124000 File Offset: 0x00122200
	private void OnClick()
	{
		if (base.enabled && this.trigger == global::AnimationOrTween.Trigger.OnClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06004CEC RID: 19692 RVA: 0x00124020 File Offset: 0x00122220
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == global::AnimationOrTween.Trigger.OnDoubleClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06004CED RID: 19693 RVA: 0x00124044 File Offset: 0x00122244
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (this.trigger == global::AnimationOrTween.Trigger.OnSelect || (this.trigger == global::AnimationOrTween.Trigger.OnSelectTrue && isSelected) || (this.trigger == global::AnimationOrTween.Trigger.OnSelectFalse && !isSelected)))
		{
			this.Play(true);
		}
	}

	// Token: 0x06004CEE RID: 19694 RVA: 0x00124098 File Offset: 0x00122298
	private void OnActivate(bool isActive)
	{
		if (base.enabled && (this.trigger == global::AnimationOrTween.Trigger.OnActivate || (this.trigger == global::AnimationOrTween.Trigger.OnActivateTrue && isActive) || (this.trigger == global::AnimationOrTween.Trigger.OnActivateFalse && !isActive)))
		{
			this.Play(isActive);
		}
	}

	// Token: 0x06004CEF RID: 19695 RVA: 0x001240E8 File Offset: 0x001222E8
	private void Play(bool forward)
	{
		if (this.target == null)
		{
			this.target = base.GetComponentInChildren<global::UnityEngine.Animation>();
		}
		if (this.target != null)
		{
			if (this.clearSelection && global::UICamera.selectedObject == base.gameObject)
			{
				global::UICamera.selectedObject = null;
			}
			int num = (int)(-(int)this.playDirection);
			global::AnimationOrTween.Direction direction = (global::AnimationOrTween.Direction)((!forward) ? num : ((int)this.playDirection));
			global::ActiveAnimation activeAnimation = global::ActiveAnimation.Play(this.target, this.clipName, direction, this.ifDisabledOnPlay, this.disableWhenFinished);
			if (this.resetOnPlay)
			{
				activeAnimation.Reset();
			}
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				activeAnimation.eventReceiver = this.eventReceiver;
				activeAnimation.callWhenFinished = this.callWhenFinished;
			}
		}
	}

	// Token: 0x040029BB RID: 10683
	public global::UnityEngine.Animation target;

	// Token: 0x040029BC RID: 10684
	public string clipName;

	// Token: 0x040029BD RID: 10685
	public global::AnimationOrTween.Trigger trigger;

	// Token: 0x040029BE RID: 10686
	public global::AnimationOrTween.Direction playDirection = global::AnimationOrTween.Direction.Forward;

	// Token: 0x040029BF RID: 10687
	public bool resetOnPlay;

	// Token: 0x040029C0 RID: 10688
	public bool clearSelection;

	// Token: 0x040029C1 RID: 10689
	public global::AnimationOrTween.EnableCondition ifDisabledOnPlay;

	// Token: 0x040029C2 RID: 10690
	public global::AnimationOrTween.DisableCondition disableWhenFinished;

	// Token: 0x040029C3 RID: 10691
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x040029C4 RID: 10692
	public string callWhenFinished;

	// Token: 0x040029C5 RID: 10693
	private bool mStarted;

	// Token: 0x040029C6 RID: 10694
	private bool mHighlighted;
}
