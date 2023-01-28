using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public abstract class StateInterpolator : global::BaseStateInterpolator
{
	// Token: 0x060025C8 RID: 9672 RVA: 0x000908A0 File Offset: 0x0008EAA0
	protected StateInterpolator()
	{
	}

	// Token: 0x17000866 RID: 2150
	// (get) Token: 0x060025C9 RID: 9673
	protected abstract double __storedDuration { get; }

	// Token: 0x17000867 RID: 2151
	// (get) Token: 0x060025CA RID: 9674
	protected abstract double __oldestTimeStamp { get; }

	// Token: 0x17000868 RID: 2152
	// (get) Token: 0x060025CB RID: 9675
	protected abstract double __newestTimeStamp { get; }

	// Token: 0x060025CC RID: 9676
	protected abstract void __Clear();

	// Token: 0x17000869 RID: 2153
	// (get) Token: 0x060025CD RID: 9677 RVA: 0x000908B0 File Offset: 0x0008EAB0
	public double storedDuration
	{
		get
		{
			return this.__storedDuration;
		}
	}

	// Token: 0x1700086A RID: 2154
	// (get) Token: 0x060025CE RID: 9678 RVA: 0x000908B8 File Offset: 0x0008EAB8
	public double oldestTimeStamp
	{
		get
		{
			return this.__oldestTimeStamp;
		}
	}

	// Token: 0x1700086B RID: 2155
	// (get) Token: 0x060025CF RID: 9679 RVA: 0x000908C0 File Offset: 0x0008EAC0
	public double newestTimeStamp
	{
		get
		{
			return this.__newestTimeStamp;
		}
	}

	// Token: 0x060025D0 RID: 9680 RVA: 0x000908C8 File Offset: 0x0008EAC8
	public void Clear()
	{
		this.__Clear();
	}

	// Token: 0x04001342 RID: 4930
	[global::UnityEngine.SerializeField]
	protected int _bufferCapacity = 0x20;

	// Token: 0x04001343 RID: 4931
	protected int len;
}
