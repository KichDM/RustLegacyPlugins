using System;
using UnityEngine;

// Token: 0x02000912 RID: 2322
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Rotation")]
public class TweenRotation : global::UITweener
{
	// Token: 0x06004F7E RID: 20350 RVA: 0x00134CA0 File Offset: 0x00132EA0
	public TweenRotation()
	{
	}

	// Token: 0x17000EA6 RID: 3750
	// (get) Token: 0x06004F7F RID: 20351 RVA: 0x00134CA8 File Offset: 0x00132EA8
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

	// Token: 0x17000EA7 RID: 3751
	// (get) Token: 0x06004F80 RID: 20352 RVA: 0x00134CD0 File Offset: 0x00132ED0
	// (set) Token: 0x06004F81 RID: 20353 RVA: 0x00134CE0 File Offset: 0x00132EE0
	public global::UnityEngine.Quaternion rotation
	{
		get
		{
			return this.cachedTransform.localRotation;
		}
		set
		{
			this.cachedTransform.localRotation = value;
		}
	}

	// Token: 0x06004F82 RID: 20354 RVA: 0x00134CF0 File Offset: 0x00132EF0
	protected override void OnUpdate(float factor)
	{
		this.cachedTransform.localRotation = global::UnityEngine.Quaternion.Slerp(global::UnityEngine.Quaternion.Euler(this.from), global::UnityEngine.Quaternion.Euler(this.to), factor);
	}

	// Token: 0x06004F83 RID: 20355 RVA: 0x00134D24 File Offset: 0x00132F24
	public static global::TweenRotation Begin(global::UnityEngine.GameObject go, float duration, global::UnityEngine.Quaternion rot)
	{
		global::TweenRotation tweenRotation = global::UITweener.Begin<global::TweenRotation>(go, duration);
		tweenRotation.from = tweenRotation.rotation.eulerAngles;
		tweenRotation.to = rot.eulerAngles;
		return tweenRotation;
	}

	// Token: 0x04002BF5 RID: 11253
	public global::UnityEngine.Vector3 from;

	// Token: 0x04002BF6 RID: 11254
	public global::UnityEngine.Vector3 to;

	// Token: 0x04002BF7 RID: 11255
	private global::UnityEngine.Transform mTrans;
}
