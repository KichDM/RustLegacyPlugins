using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public abstract class StateInterpolator<T> : global::StateInterpolator
{
	// Token: 0x060025D1 RID: 9681 RVA: 0x000908D0 File Offset: 0x0008EAD0
	protected StateInterpolator()
	{
	}

	// Token: 0x1700086C RID: 2156
	// (get) Token: 0x060025D2 RID: 9682 RVA: 0x000908D8 File Offset: 0x0008EAD8
	public int bufferCapacity
	{
		get
		{
			return this.tbuffer.Length;
		}
	}

	// Token: 0x060025D3 RID: 9683 RVA: 0x000908E4 File Offset: 0x0008EAE4
	protected void Awake()
	{
		this.tbuffer = new global::TimeStamped<T>[this._bufferCapacity];
		for (int i = 0; i < this._bufferCapacity; i++)
		{
			this.tbuffer[i].index = i;
		}
	}

	// Token: 0x1700086D RID: 2157
	// (get) Token: 0x060025D4 RID: 9684 RVA: 0x0009092C File Offset: 0x0008EB2C
	public new double storedDuration
	{
		get
		{
			return (this.len >= 2) ? (this.tbuffer[this.tbuffer[0].index].timeStamp - this.tbuffer[this.tbuffer[this.len - 1].index].timeStamp) : 0.0;
		}
	}

	// Token: 0x1700086E RID: 2158
	// (get) Token: 0x060025D5 RID: 9685 RVA: 0x000909A0 File Offset: 0x0008EBA0
	public new double oldestTimeStamp
	{
		get
		{
			return (this.len != 0) ? this.tbuffer[this.tbuffer[0].index].timeStamp : double.NegativeInfinity;
		}
	}

	// Token: 0x1700086F RID: 2159
	// (get) Token: 0x060025D6 RID: 9686 RVA: 0x000909E8 File Offset: 0x0008EBE8
	public new double newestTimeStamp
	{
		get
		{
			return (this.len != 0) ? this.tbuffer[this.tbuffer[this.len - 1].index].timeStamp : double.PositiveInfinity;
		}
	}

	// Token: 0x060025D7 RID: 9687 RVA: 0x00090A38 File Offset: 0x0008EC38
	public new void Clear()
	{
		if (this.len > 0)
		{
			if (global::ReferenceTypeHelper<T>.TreatAsReferenceHolder)
			{
				for (int i = 0; i < this.len; i++)
				{
					this.tbuffer[this.tbuffer[i].index].value = default(T);
				}
			}
			this.len = 0;
		}
	}

	// Token: 0x17000870 RID: 2160
	// (get) Token: 0x060025D8 RID: 9688 RVA: 0x00090AA4 File Offset: 0x0008ECA4
	protected sealed override double __newestTimeStamp
	{
		get
		{
			return this.newestTimeStamp;
		}
	}

	// Token: 0x17000871 RID: 2161
	// (get) Token: 0x060025D9 RID: 9689 RVA: 0x00090AAC File Offset: 0x0008ECAC
	protected sealed override double __oldestTimeStamp
	{
		get
		{
			return this.oldestTimeStamp;
		}
	}

	// Token: 0x17000872 RID: 2162
	// (get) Token: 0x060025DA RID: 9690 RVA: 0x00090AB4 File Offset: 0x0008ECB4
	protected sealed override double __storedDuration
	{
		get
		{
			return this.storedDuration;
		}
	}

	// Token: 0x060025DB RID: 9691 RVA: 0x00090ABC File Offset: 0x0008ECBC
	protected sealed override void __Clear()
	{
		this.Clear();
	}

	// Token: 0x060025DC RID: 9692 RVA: 0x00090AC4 File Offset: 0x0008ECC4
	public override void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		throw new global::System.NotImplementedException("The thing using this has not implemented a way to take pos, rot to " + typeof(T));
	}

	// Token: 0x060025DD RID: 9693 RVA: 0x00090AE0 File Offset: 0x0008ECE0
	protected void Push(ref T state, ref double timeStamp)
	{
		int num = this.tbuffer.Length;
		if (this.len < num)
		{
			for (int i = 0; i < this.len; i++)
			{
				int index = this.tbuffer[i].index;
				if (this.tbuffer[index].timeStamp < timeStamp)
				{
					for (int j = this.len; j > i; j--)
					{
						this.tbuffer[j].index = this.tbuffer[j - 1].index;
					}
					this.tbuffer[i].index = this.len;
					this.tbuffer[this.len++].Set(ref state, ref timeStamp);
					return;
				}
				if (this.tbuffer[index].timeStamp == timeStamp)
				{
					this.tbuffer[index].Set(ref state, ref timeStamp);
					return;
				}
			}
			this.tbuffer[this.len].index = this.len;
			this.tbuffer[this.len++].Set(ref state, ref timeStamp);
		}
		else
		{
			for (int k = 0; k < num; k++)
			{
				int index2 = this.tbuffer[k].index;
				if (this.tbuffer[index2].timeStamp < timeStamp)
				{
					int index3 = this.tbuffer[num - 1].index;
					for (int l = num - 1; l > k; l--)
					{
						this.tbuffer[l].index = this.tbuffer[l - 1].index;
					}
					this.tbuffer[k].index = index3;
					this.tbuffer[index3].Set(ref state, ref timeStamp);
					return;
				}
				if (this.tbuffer[index2].timeStamp == timeStamp)
				{
					this.tbuffer[index2].Set(ref state, ref timeStamp);
					return;
				}
			}
		}
	}

	// Token: 0x060025DE RID: 9694 RVA: 0x00090D1C File Offset: 0x0008EF1C
	public virtual void SetGoals(ref T state, ref double timeStamp)
	{
		this.Push(ref state, ref timeStamp);
	}

	// Token: 0x060025DF RID: 9695 RVA: 0x00090D28 File Offset: 0x0008EF28
	public void SetGoals(ref global::TimeStamped<T> state)
	{
		T value = state.value;
		double timeStamp = state.timeStamp;
		this.SetGoals(ref value, ref timeStamp);
	}

	// Token: 0x04001344 RID: 4932
	protected global::TimeStamped<T>[] tbuffer;
}
