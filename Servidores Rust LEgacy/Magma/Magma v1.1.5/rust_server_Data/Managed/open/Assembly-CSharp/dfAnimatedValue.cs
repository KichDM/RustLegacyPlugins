using System;
using UnityEngine;

// Token: 0x02000886 RID: 2182
public abstract class dfAnimatedValue<T> where T : struct
{
	// Token: 0x06004B65 RID: 19301 RVA: 0x0011BD98 File Offset: 0x00119F98
	protected internal dfAnimatedValue(T StartValue, T EndValue, float Time) : this()
	{
		this.startValue = StartValue;
		this.endValue = EndValue;
		this.animLength = Time;
	}

	// Token: 0x06004B66 RID: 19302 RVA: 0x0011BDB8 File Offset: 0x00119FB8
	protected internal dfAnimatedValue()
	{
		this.startTime = global::UnityEngine.Time.realtimeSinceStartup;
		this.easingFunction = global::dfEasingFunctions.GetFunction(this.easingType);
	}

	// Token: 0x17000E15 RID: 3605
	// (get) Token: 0x06004B67 RID: 19303 RVA: 0x0011BDE8 File Offset: 0x00119FE8
	public bool IsDone
	{
		get
		{
			return global::UnityEngine.Time.realtimeSinceStartup - this.startTime >= this.Length;
		}
	}

	// Token: 0x17000E16 RID: 3606
	// (get) Token: 0x06004B68 RID: 19304 RVA: 0x0011BE04 File Offset: 0x0011A004
	// (set) Token: 0x06004B69 RID: 19305 RVA: 0x0011BE0C File Offset: 0x0011A00C
	public float Length
	{
		get
		{
			return this.animLength;
		}
		set
		{
			this.animLength = value;
			this.startTime = global::UnityEngine.Time.realtimeSinceStartup;
		}
	}

	// Token: 0x17000E17 RID: 3607
	// (get) Token: 0x06004B6A RID: 19306 RVA: 0x0011BE20 File Offset: 0x0011A020
	// (set) Token: 0x06004B6B RID: 19307 RVA: 0x0011BE28 File Offset: 0x0011A028
	public T StartValue
	{
		get
		{
			return this.startValue;
		}
		set
		{
			this.startValue = value;
			this.startTime = global::UnityEngine.Time.realtimeSinceStartup;
		}
	}

	// Token: 0x17000E18 RID: 3608
	// (get) Token: 0x06004B6C RID: 19308 RVA: 0x0011BE3C File Offset: 0x0011A03C
	// (set) Token: 0x06004B6D RID: 19309 RVA: 0x0011BE44 File Offset: 0x0011A044
	public T EndValue
	{
		get
		{
			return this.endValue;
		}
		set
		{
			this.endValue = value;
			this.startTime = global::UnityEngine.Time.realtimeSinceStartup;
		}
	}

	// Token: 0x17000E19 RID: 3609
	// (get) Token: 0x06004B6E RID: 19310 RVA: 0x0011BE58 File Offset: 0x0011A058
	public T Value
	{
		get
		{
			float num = global::UnityEngine.Time.realtimeSinceStartup - this.startTime;
			if (num >= this.animLength)
			{
				return this.endValue;
			}
			float time = global::UnityEngine.Mathf.Clamp01(num / this.animLength);
			time = this.easingFunction(0f, 1f, time);
			return this.Lerp(this.startValue, this.endValue, time);
		}
	}

	// Token: 0x17000E1A RID: 3610
	// (get) Token: 0x06004B6F RID: 19311 RVA: 0x0011BEC0 File Offset: 0x0011A0C0
	// (set) Token: 0x06004B70 RID: 19312 RVA: 0x0011BEC8 File Offset: 0x0011A0C8
	public global::dfEasingType EasingType
	{
		get
		{
			return this.easingType;
		}
		set
		{
			this.easingType = value;
			this.easingFunction = global::dfEasingFunctions.GetFunction(this.easingType);
		}
	}

	// Token: 0x06004B71 RID: 19313
	protected abstract T Lerp(T startValue, T endValue, float time);

	// Token: 0x06004B72 RID: 19314 RVA: 0x0011BEE4 File Offset: 0x0011A0E4
	public static implicit operator T(global::dfAnimatedValue<T> animated)
	{
		return animated.Value;
	}

	// Token: 0x04002810 RID: 10256
	private T startValue;

	// Token: 0x04002811 RID: 10257
	private T endValue;

	// Token: 0x04002812 RID: 10258
	private float animLength = 1f;

	// Token: 0x04002813 RID: 10259
	private float startTime;

	// Token: 0x04002814 RID: 10260
	private global::dfEasingType easingType;

	// Token: 0x04002815 RID: 10261
	private global::dfEasingFunctions.EasingFunction easingFunction;
}
