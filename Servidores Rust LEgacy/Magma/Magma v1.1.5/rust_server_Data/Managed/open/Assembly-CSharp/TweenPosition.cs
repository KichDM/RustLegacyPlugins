using System;
using UnityEngine;

// Token: 0x02000911 RID: 2321
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Position")]
public class TweenPosition : global::UITweener
{
	// Token: 0x06004F78 RID: 20344 RVA: 0x00134BE8 File Offset: 0x00132DE8
	public TweenPosition()
	{
	}

	// Token: 0x17000EA4 RID: 3748
	// (get) Token: 0x06004F79 RID: 20345 RVA: 0x00134BF0 File Offset: 0x00132DF0
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

	// Token: 0x17000EA5 RID: 3749
	// (get) Token: 0x06004F7A RID: 20346 RVA: 0x00134C18 File Offset: 0x00132E18
	// (set) Token: 0x06004F7B RID: 20347 RVA: 0x00134C28 File Offset: 0x00132E28
	public global::UnityEngine.Vector3 position
	{
		get
		{
			return this.cachedTransform.localPosition;
		}
		set
		{
			this.cachedTransform.localPosition = value;
		}
	}

	// Token: 0x06004F7C RID: 20348 RVA: 0x00134C38 File Offset: 0x00132E38
	protected override void OnUpdate(float factor)
	{
		this.cachedTransform.localPosition = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x06004F7D RID: 20349 RVA: 0x00134C74 File Offset: 0x00132E74
	public static global::TweenPosition Begin(global::UnityEngine.GameObject go, float duration, global::UnityEngine.Vector3 pos)
	{
		global::TweenPosition tweenPosition = global::UITweener.Begin<global::TweenPosition>(go, duration);
		tweenPosition.from = tweenPosition.position;
		tweenPosition.to = pos;
		return tweenPosition;
	}

	// Token: 0x04002BF2 RID: 11250
	public global::UnityEngine.Vector3 from;

	// Token: 0x04002BF3 RID: 11251
	public global::UnityEngine.Vector3 to;

	// Token: 0x04002BF4 RID: 11252
	private global::UnityEngine.Transform mTrans;
}
