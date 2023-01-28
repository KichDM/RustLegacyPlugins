using System;
using UnityEngine;

// Token: 0x020008EA RID: 2282
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Spring Panel")]
[global::UnityEngine.RequireComponent(typeof(global::UIPanel))]
public class SpringPanel : global::IgnoreTimeScale
{
	// Token: 0x06004E5C RID: 20060 RVA: 0x0012DA34 File Offset: 0x0012BC34
	public SpringPanel()
	{
	}

	// Token: 0x06004E5D RID: 20061 RVA: 0x0012DA54 File Offset: 0x0012BC54
	private void Start()
	{
		this.mPanel = base.GetComponent<global::UIPanel>();
		this.mDrag = base.GetComponent<global::UIDraggablePanel>();
		this.mTrans = base.transform;
	}

	// Token: 0x06004E5E RID: 20062 RVA: 0x0012DA88 File Offset: 0x0012BC88
	private void Update()
	{
		float deltaTime = base.UpdateRealTimeDelta();
		if (this.mThreshold == 0f)
		{
			this.mThreshold = (this.target - this.mTrans.localPosition).magnitude * 0.005f;
		}
		global::UnityEngine.Vector3 localPosition = this.mTrans.localPosition;
		this.mTrans.localPosition = global::NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
		global::UnityEngine.Vector3 vector = this.mTrans.localPosition - localPosition;
		global::UnityEngine.Vector4 clipRange = this.mPanel.clipRange;
		clipRange.x -= vector.x;
		clipRange.y -= vector.y;
		this.mPanel.clipRange = clipRange;
		if (this.mDrag != null)
		{
			this.mDrag.UpdateScrollbars(false);
		}
		if (this.mThreshold >= (this.target - this.mTrans.localPosition).magnitude)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06004E5F RID: 20063 RVA: 0x0012DBB0 File Offset: 0x0012BDB0
	public static global::SpringPanel Begin(global::UnityEngine.GameObject go, global::UnityEngine.Vector3 pos, float strength)
	{
		global::SpringPanel springPanel = go.GetComponent<global::SpringPanel>();
		if (springPanel == null)
		{
			springPanel = go.AddComponent<global::SpringPanel>();
		}
		springPanel.target = pos;
		springPanel.strength = strength;
		if (!springPanel.enabled)
		{
			springPanel.mThreshold = 0f;
			springPanel.enabled = true;
		}
		return springPanel;
	}

	// Token: 0x04002B1D RID: 11037
	public global::UnityEngine.Vector3 target = global::UnityEngine.Vector3.zero;

	// Token: 0x04002B1E RID: 11038
	public float strength = 10f;

	// Token: 0x04002B1F RID: 11039
	private global::UIPanel mPanel;

	// Token: 0x04002B20 RID: 11040
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002B21 RID: 11041
	private float mThreshold;

	// Token: 0x04002B22 RID: 11042
	private global::UIDraggablePanel mDrag;
}
