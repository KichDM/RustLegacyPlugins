using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000916 RID: 2326
public abstract class UITweener : global::IgnoreTimeScale
{
	// Token: 0x06004F93 RID: 20371 RVA: 0x001350A8 File Offset: 0x001332A8
	protected UITweener()
	{
	}

	// Token: 0x17000EAC RID: 3756
	// (get) Token: 0x06004F94 RID: 20372 RVA: 0x001350C8 File Offset: 0x001332C8
	public float amountPerDelta
	{
		get
		{
			if (this.mDuration != this.duration)
			{
				this.mDuration = this.duration;
				this.mAmountPerDelta = global::UnityEngine.Mathf.Abs((this.duration <= 0f) ? 1000f : (1f / this.duration));
			}
			return this.mAmountPerDelta;
		}
	}

	// Token: 0x17000EAD RID: 3757
	// (get) Token: 0x06004F95 RID: 20373 RVA: 0x0013512C File Offset: 0x0013332C
	public float factor
	{
		get
		{
			return this.mFactor;
		}
	}

	// Token: 0x17000EAE RID: 3758
	// (get) Token: 0x06004F96 RID: 20374 RVA: 0x00135134 File Offset: 0x00133334
	public global::AnimationOrTween.Direction direction
	{
		get
		{
			return (this.mAmountPerDelta >= 0f) ? global::AnimationOrTween.Direction.Forward : global::AnimationOrTween.Direction.Reverse;
		}
	}

	// Token: 0x06004F97 RID: 20375 RVA: 0x00135150 File Offset: 0x00133350
	private void Start()
	{
		this.mStartTime = global::UnityEngine.Time.time + this.delay;
		this.Update();
	}

	// Token: 0x06004F98 RID: 20376 RVA: 0x0013516C File Offset: 0x0013336C
	private void Update()
	{
		if (global::UnityEngine.Time.time < this.mStartTime)
		{
			return;
		}
		float num = base.UpdateRealTimeDelta();
		this.mFactor += this.amountPerDelta * num;
		if (this.style == global::UITweener.Style.Loop)
		{
			if (this.mFactor > 1f)
			{
				this.mFactor -= global::UnityEngine.Mathf.Floor(this.mFactor);
			}
		}
		else if (this.style == global::UITweener.Style.PingPong)
		{
			if (this.mFactor > 1f)
			{
				this.mFactor = 1f - (this.mFactor - global::UnityEngine.Mathf.Floor(this.mFactor));
				this.mAmountPerDelta = -this.mAmountPerDelta;
			}
			else if (this.mFactor < 0f)
			{
				this.mFactor = -this.mFactor;
				this.mFactor -= global::UnityEngine.Mathf.Floor(this.mFactor);
				this.mAmountPerDelta = -this.mAmountPerDelta;
			}
		}
		float num2 = global::UnityEngine.Mathf.Clamp01(this.mFactor);
		if (this.method == global::UITweener.Method.EaseIn)
		{
			num2 = 1f - global::UnityEngine.Mathf.Sin(1.5707964f * (1f - num2));
			if (this.steeperCurves)
			{
				num2 *= num2;
			}
		}
		else if (this.method == global::UITweener.Method.EaseOut)
		{
			num2 = global::UnityEngine.Mathf.Sin(1.5707964f * num2);
			if (this.steeperCurves)
			{
				num2 = 1f - num2;
				num2 = 1f - num2 * num2;
			}
		}
		else if (this.method == global::UITweener.Method.EaseInOut)
		{
			num2 -= global::UnityEngine.Mathf.Sin(num2 * 6.2831855f) / 6.2831855f;
			if (this.steeperCurves)
			{
				num2 = num2 * 2f - 1f;
				float num3 = global::UnityEngine.Mathf.Sign(num2);
				num2 = 1f - global::UnityEngine.Mathf.Abs(num2);
				num2 = 1f - num2 * num2;
				num2 = num3 * num2 * 0.5f + 0.5f;
			}
		}
		this.OnUpdate(num2);
		if (this.style == global::UITweener.Style.Once && (this.mFactor > 1f || this.mFactor < 0f))
		{
			this.mFactor = global::UnityEngine.Mathf.Clamp01(this.mFactor);
			if (string.IsNullOrEmpty(this.callWhenFinished))
			{
				base.enabled = false;
			}
			else
			{
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, this, 1);
				}
				if ((this.mFactor == 1f && this.mAmountPerDelta > 0f) || (this.mFactor == 0f && this.mAmountPerDelta < 0f))
				{
					base.enabled = false;
				}
			}
		}
	}

	// Token: 0x06004F99 RID: 20377 RVA: 0x00135430 File Offset: 0x00133630
	public void Play(bool forward)
	{
		this.mAmountPerDelta = global::UnityEngine.Mathf.Abs(this.amountPerDelta);
		if (!forward)
		{
			this.mAmountPerDelta = -this.mAmountPerDelta;
		}
		base.enabled = true;
	}

	// Token: 0x06004F9A RID: 20378 RVA: 0x00135460 File Offset: 0x00133660
	[global::System.Obsolete("Use Tweener.Play instead")]
	public void Animate(bool forward)
	{
		this.Play(forward);
	}

	// Token: 0x06004F9B RID: 20379 RVA: 0x0013546C File Offset: 0x0013366C
	public void Reset()
	{
		this.mFactor = ((this.mAmountPerDelta >= 0f) ? 0f : 1f);
	}

	// Token: 0x06004F9C RID: 20380 RVA: 0x00135494 File Offset: 0x00133694
	public void Toggle()
	{
		if (this.mFactor > 0f)
		{
			this.mAmountPerDelta = -this.amountPerDelta;
		}
		else
		{
			this.mAmountPerDelta = global::UnityEngine.Mathf.Abs(this.amountPerDelta);
		}
		base.enabled = true;
	}

	// Token: 0x06004F9D RID: 20381
	protected abstract void OnUpdate(float factor);

	// Token: 0x06004F9E RID: 20382 RVA: 0x001354DC File Offset: 0x001336DC
	public static T Begin<T>(global::UnityEngine.GameObject go, float duration) where T : global::UITweener
	{
		T t = go.GetComponent<T>();
		if (t == null)
		{
			t = go.AddComponent<T>();
		}
		t.duration = duration;
		t.mFactor = 0f;
		t.style = global::UITweener.Style.Once;
		t.enabled = true;
		return t;
	}

	// Token: 0x04002C03 RID: 11267
	public global::UITweener.Method method;

	// Token: 0x04002C04 RID: 11268
	public global::UITweener.Style style;

	// Token: 0x04002C05 RID: 11269
	public float delay;

	// Token: 0x04002C06 RID: 11270
	public float duration = 1f;

	// Token: 0x04002C07 RID: 11271
	public bool steeperCurves;

	// Token: 0x04002C08 RID: 11272
	public int tweenGroup;

	// Token: 0x04002C09 RID: 11273
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x04002C0A RID: 11274
	public string callWhenFinished;

	// Token: 0x04002C0B RID: 11275
	private float mStartTime;

	// Token: 0x04002C0C RID: 11276
	private float mDuration;

	// Token: 0x04002C0D RID: 11277
	private float mAmountPerDelta = 1f;

	// Token: 0x04002C0E RID: 11278
	private float mFactor;

	// Token: 0x02000917 RID: 2327
	public enum Method
	{
		// Token: 0x04002C10 RID: 11280
		Linear,
		// Token: 0x04002C11 RID: 11281
		EaseIn,
		// Token: 0x04002C12 RID: 11282
		EaseOut,
		// Token: 0x04002C13 RID: 11283
		EaseInOut
	}

	// Token: 0x02000918 RID: 2328
	public enum Style
	{
		// Token: 0x04002C15 RID: 11285
		Once,
		// Token: 0x04002C16 RID: 11286
		Loop,
		// Token: 0x04002C17 RID: 11287
		PingPong
	}
}
