using System;
using UnityEngine;

// Token: 0x02000913 RID: 2323
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Scale")]
public class TweenScale : global::UITweener
{
	// Token: 0x06004F84 RID: 20356 RVA: 0x00134D5C File Offset: 0x00132F5C
	public TweenScale()
	{
	}

	// Token: 0x17000EA8 RID: 3752
	// (get) Token: 0x06004F85 RID: 20357 RVA: 0x00134D7C File Offset: 0x00132F7C
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

	// Token: 0x17000EA9 RID: 3753
	// (get) Token: 0x06004F86 RID: 20358 RVA: 0x00134DA4 File Offset: 0x00132FA4
	// (set) Token: 0x06004F87 RID: 20359 RVA: 0x00134DB4 File Offset: 0x00132FB4
	public global::UnityEngine.Vector3 scale
	{
		get
		{
			return this.cachedTransform.localScale;
		}
		set
		{
			this.cachedTransform.localScale = value;
		}
	}

	// Token: 0x06004F88 RID: 20360 RVA: 0x00134DC4 File Offset: 0x00132FC4
	protected override void OnUpdate(float factor)
	{
		this.cachedTransform.localScale = this.from * (1f - factor) + this.to * factor;
		if (this.updateTable)
		{
			if (this.mTable == null)
			{
				this.mTable = global::NGUITools.FindInParents<global::UITable>(base.gameObject);
				if (this.mTable == null)
				{
					this.updateTable = false;
					return;
				}
			}
			this.mTable.repositionNow = true;
		}
	}

	// Token: 0x06004F89 RID: 20361 RVA: 0x00134E54 File Offset: 0x00133054
	public static global::TweenScale Begin(global::UnityEngine.GameObject go, float duration, global::UnityEngine.Vector3 scale)
	{
		global::TweenScale tweenScale = global::UITweener.Begin<global::TweenScale>(go, duration);
		tweenScale.from = tweenScale.scale;
		tweenScale.to = scale;
		return tweenScale;
	}

	// Token: 0x04002BF8 RID: 11256
	public global::UnityEngine.Vector3 from = global::UnityEngine.Vector3.one;

	// Token: 0x04002BF9 RID: 11257
	public global::UnityEngine.Vector3 to = global::UnityEngine.Vector3.one;

	// Token: 0x04002BFA RID: 11258
	public bool updateTable;

	// Token: 0x04002BFB RID: 11259
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002BFC RID: 11260
	private global::UITable mTable;
}
