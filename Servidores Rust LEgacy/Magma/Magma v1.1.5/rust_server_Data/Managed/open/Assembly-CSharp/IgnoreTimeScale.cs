using System;
using UnityEngine;

// Token: 0x020008E2 RID: 2274
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Ignore TimeScale Behaviour")]
public class IgnoreTimeScale : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004DEB RID: 19947 RVA: 0x0012AD78 File Offset: 0x00128F78
	public IgnoreTimeScale()
	{
	}

	// Token: 0x17000E77 RID: 3703
	// (get) Token: 0x06004DEC RID: 19948 RVA: 0x0012AD80 File Offset: 0x00128F80
	public float realTimeDelta
	{
		get
		{
			return this.mTimeDelta;
		}
	}

	// Token: 0x06004DED RID: 19949 RVA: 0x0012AD88 File Offset: 0x00128F88
	private void OnEnable()
	{
		this.mTimeStarted = true;
		this.mTimeDelta = 0f;
		this.mTimeStart = global::UnityEngine.Time.realtimeSinceStartup;
	}

	// Token: 0x06004DEE RID: 19950 RVA: 0x0012ADA8 File Offset: 0x00128FA8
	protected float UpdateRealTimeDelta()
	{
		if (this.mTimeStarted)
		{
			float realtimeSinceStartup = global::UnityEngine.Time.realtimeSinceStartup;
			float num = realtimeSinceStartup - this.mTimeStart;
			this.mActual += global::UnityEngine.Mathf.Max(0f, num);
			this.mTimeDelta = 0.001f * global::UnityEngine.Mathf.Round(this.mActual * 1000f);
			this.mActual -= this.mTimeDelta;
			this.mTimeStart = realtimeSinceStartup;
		}
		else
		{
			this.mTimeStarted = true;
			this.mTimeStart = global::UnityEngine.Time.realtimeSinceStartup;
			this.mTimeDelta = 0f;
		}
		return this.mTimeDelta;
	}

	// Token: 0x04002AFC RID: 11004
	private float mTimeStart;

	// Token: 0x04002AFD RID: 11005
	private float mTimeDelta;

	// Token: 0x04002AFE RID: 11006
	private float mActual;

	// Token: 0x04002AFF RID: 11007
	private bool mTimeStarted;
}
