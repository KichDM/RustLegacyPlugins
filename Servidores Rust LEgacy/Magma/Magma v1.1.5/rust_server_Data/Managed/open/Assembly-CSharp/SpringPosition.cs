using System;
using UnityEngine;

// Token: 0x0200090F RID: 2319
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Spring Position")]
public class SpringPosition : global::IgnoreTimeScale
{
	// Token: 0x06004F6E RID: 20334 RVA: 0x00134800 File Offset: 0x00132A00
	public SpringPosition()
	{
	}

	// Token: 0x06004F6F RID: 20335 RVA: 0x00134820 File Offset: 0x00132A20
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x06004F70 RID: 20336 RVA: 0x00134830 File Offset: 0x00132A30
	private void Update()
	{
		float deltaTime = (!this.ignoreTimeScale) ? global::UnityEngine.Time.deltaTime : base.UpdateRealTimeDelta();
		if (this.worldSpace)
		{
			if (this.mThreshold == 0f)
			{
				this.mThreshold = (this.target - this.mTrans.position).magnitude * 0.001f;
			}
			this.mTrans.position = global::NGUIMath.SpringLerp(this.mTrans.position, this.target, this.strength, deltaTime);
			if (this.mThreshold >= (this.target - this.mTrans.position).magnitude)
			{
				this.mTrans.position = this.target;
				base.enabled = false;
			}
		}
		else
		{
			if (this.mThreshold == 0f)
			{
				this.mThreshold = (this.target - this.mTrans.localPosition).magnitude * 0.001f;
			}
			this.mTrans.localPosition = global::NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
			if (this.mThreshold >= (this.target - this.mTrans.localPosition).magnitude)
			{
				this.mTrans.localPosition = this.target;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06004F71 RID: 20337 RVA: 0x001349B0 File Offset: 0x00132BB0
	public static global::SpringPosition Begin(global::UnityEngine.GameObject go, global::UnityEngine.Vector3 pos, float strength)
	{
		global::SpringPosition springPosition = go.GetComponent<global::SpringPosition>();
		if (springPosition == null)
		{
			springPosition = go.AddComponent<global::SpringPosition>();
		}
		springPosition.target = pos;
		springPosition.strength = strength;
		if (!springPosition.enabled)
		{
			springPosition.mThreshold = 0f;
			springPosition.enabled = true;
		}
		return springPosition;
	}

	// Token: 0x04002BE5 RID: 11237
	public global::UnityEngine.Vector3 target = global::UnityEngine.Vector3.zero;

	// Token: 0x04002BE6 RID: 11238
	public float strength = 10f;

	// Token: 0x04002BE7 RID: 11239
	public bool worldSpace;

	// Token: 0x04002BE8 RID: 11240
	public bool ignoreTimeScale;

	// Token: 0x04002BE9 RID: 11241
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002BEA RID: 11242
	private float mThreshold;
}
