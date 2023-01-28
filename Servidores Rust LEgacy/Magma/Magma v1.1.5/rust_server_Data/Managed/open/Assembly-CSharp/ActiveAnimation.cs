using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x020008D7 RID: 2263
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Active Animation")]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Animation))]
public class ActiveAnimation : global::IgnoreTimeScale
{
	// Token: 0x06004DC0 RID: 19904 RVA: 0x00129EBC File Offset: 0x001280BC
	public ActiveAnimation()
	{
	}

	// Token: 0x06004DC1 RID: 19905 RVA: 0x00129EC4 File Offset: 0x001280C4
	public void Reset()
	{
		if (this.mAnim != null)
		{
			foreach (object obj in this.mAnim)
			{
				global::UnityEngine.AnimationState animationState = (global::UnityEngine.AnimationState)obj;
				if (this.mLastDirection == global::AnimationOrTween.Direction.Reverse)
				{
					animationState.time = animationState.length;
				}
				else if (this.mLastDirection == global::AnimationOrTween.Direction.Forward)
				{
					animationState.time = 0f;
				}
			}
		}
	}

	// Token: 0x06004DC2 RID: 19906 RVA: 0x00129F74 File Offset: 0x00128174
	private void Update()
	{
		float num = base.UpdateRealTimeDelta();
		if (num == 0f)
		{
			return;
		}
		if (this.mAnim != null)
		{
			bool flag = false;
			foreach (object obj in this.mAnim)
			{
				global::UnityEngine.AnimationState animationState = (global::UnityEngine.AnimationState)obj;
				float num2 = animationState.speed * num;
				animationState.time += num2;
				if (num2 < 0f)
				{
					if (animationState.time > 0f)
					{
						flag = true;
					}
					else
					{
						animationState.time = 0f;
					}
				}
				else if (animationState.time < animationState.length)
				{
					flag = true;
				}
				else
				{
					animationState.time = animationState.length;
				}
			}
			this.mAnim.enabled = true;
			this.mAnim.Sample();
			this.mAnim.enabled = false;
			if (flag)
			{
				return;
			}
			if (this.mNotify)
			{
				this.mNotify = false;
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, this, 1);
				}
				if (this.mDisableDirection != global::AnimationOrTween.Direction.Toggle && this.mLastDirection == this.mDisableDirection)
				{
					global::NGUITools.SetActive(base.gameObject, false);
				}
			}
		}
		base.enabled = false;
	}

	// Token: 0x06004DC3 RID: 19907 RVA: 0x0012A114 File Offset: 0x00128314
	private void Play(string clipName, global::AnimationOrTween.Direction playDirection)
	{
		if (this.mAnim != null)
		{
			this.mAnim.enabled = false;
			if (playDirection == global::AnimationOrTween.Direction.Toggle)
			{
				playDirection = ((this.mLastDirection == global::AnimationOrTween.Direction.Forward) ? global::AnimationOrTween.Direction.Reverse : global::AnimationOrTween.Direction.Forward);
			}
			bool flag = string.IsNullOrEmpty(clipName);
			if (flag)
			{
				if (!this.mAnim.isPlaying)
				{
					this.mAnim.Play();
				}
			}
			else if (!this.mAnim.IsPlaying(clipName))
			{
				this.mAnim.Play(clipName);
			}
			foreach (object obj in this.mAnim)
			{
				global::UnityEngine.AnimationState animationState = (global::UnityEngine.AnimationState)obj;
				if (string.IsNullOrEmpty(clipName) || animationState.name == clipName)
				{
					float num = global::UnityEngine.Mathf.Abs(animationState.speed);
					animationState.speed = num * (float)playDirection;
					if (playDirection == global::AnimationOrTween.Direction.Reverse && animationState.time == 0f)
					{
						animationState.time = animationState.length;
					}
					else if (playDirection == global::AnimationOrTween.Direction.Forward && animationState.time == animationState.length)
					{
						animationState.time = 0f;
					}
				}
			}
			this.mLastDirection = playDirection;
			this.mNotify = true;
		}
	}

	// Token: 0x06004DC4 RID: 19908 RVA: 0x0012A290 File Offset: 0x00128490
	public static global::ActiveAnimation Play(global::UnityEngine.Animation anim, string clipName, global::AnimationOrTween.Direction playDirection, global::AnimationOrTween.EnableCondition enableBeforePlay, global::AnimationOrTween.DisableCondition disableCondition)
	{
		if (!anim.gameObject.activeInHierarchy)
		{
			if (enableBeforePlay != global::AnimationOrTween.EnableCondition.EnableThenPlay)
			{
				return null;
			}
			global::NGUITools.SetActive(anim.gameObject, true);
		}
		global::ActiveAnimation activeAnimation = anim.GetComponent<global::ActiveAnimation>();
		if (activeAnimation != null)
		{
			activeAnimation.enabled = true;
		}
		else
		{
			activeAnimation = anim.gameObject.AddComponent<global::ActiveAnimation>();
		}
		activeAnimation.mAnim = anim;
		activeAnimation.mDisableDirection = (global::AnimationOrTween.Direction)disableCondition;
		activeAnimation.Play(clipName, playDirection);
		return activeAnimation;
	}

	// Token: 0x06004DC5 RID: 19909 RVA: 0x0012A308 File Offset: 0x00128508
	public static global::ActiveAnimation Play(global::UnityEngine.Animation anim, string clipName, global::AnimationOrTween.Direction playDirection)
	{
		return global::ActiveAnimation.Play(anim, clipName, playDirection, global::AnimationOrTween.EnableCondition.DoNothing, global::AnimationOrTween.DisableCondition.DoNotDisable);
	}

	// Token: 0x06004DC6 RID: 19910 RVA: 0x0012A314 File Offset: 0x00128514
	public static global::ActiveAnimation Play(global::UnityEngine.Animation anim, global::AnimationOrTween.Direction playDirection)
	{
		return global::ActiveAnimation.Play(anim, null, playDirection, global::AnimationOrTween.EnableCondition.DoNothing, global::AnimationOrTween.DisableCondition.DoNotDisable);
	}

	// Token: 0x04002ABA RID: 10938
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x04002ABB RID: 10939
	public string callWhenFinished;

	// Token: 0x04002ABC RID: 10940
	private global::UnityEngine.Animation mAnim;

	// Token: 0x04002ABD RID: 10941
	private global::AnimationOrTween.Direction mLastDirection;

	// Token: 0x04002ABE RID: 10942
	private global::AnimationOrTween.Direction mDisableDirection;

	// Token: 0x04002ABF RID: 10943
	private bool mNotify;
}
