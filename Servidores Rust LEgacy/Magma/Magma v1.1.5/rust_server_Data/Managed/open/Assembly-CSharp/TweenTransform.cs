using System;
using UnityEngine;

// Token: 0x02000914 RID: 2324
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Transform")]
public class TweenTransform : global::UITweener
{
	// Token: 0x06004F8A RID: 20362 RVA: 0x00134E80 File Offset: 0x00133080
	public TweenTransform()
	{
	}

	// Token: 0x06004F8B RID: 20363 RVA: 0x00134E88 File Offset: 0x00133088
	protected override void OnUpdate(float factor)
	{
		if (this.from != null && this.to != null)
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			this.mTrans.position = this.from.position * (1f - factor) + this.to.position * factor;
			this.mTrans.localScale = this.from.localScale * (1f - factor) + this.to.localScale * factor;
			this.mTrans.rotation = global::UnityEngine.Quaternion.Slerp(this.from.rotation, this.to.rotation, factor);
		}
	}

	// Token: 0x06004F8C RID: 20364 RVA: 0x00134F6C File Offset: 0x0013316C
	public static global::TweenTransform Begin(global::UnityEngine.GameObject go, float duration, global::UnityEngine.Transform from, global::UnityEngine.Transform to)
	{
		global::TweenTransform tweenTransform = global::UITweener.Begin<global::TweenTransform>(go, duration);
		tweenTransform.from = from;
		tweenTransform.to = to;
		return tweenTransform;
	}

	// Token: 0x04002BFD RID: 11261
	public global::UnityEngine.Transform from;

	// Token: 0x04002BFE RID: 11262
	public global::UnityEngine.Transform to;

	// Token: 0x04002BFF RID: 11263
	private global::UnityEngine.Transform mTrans;
}
