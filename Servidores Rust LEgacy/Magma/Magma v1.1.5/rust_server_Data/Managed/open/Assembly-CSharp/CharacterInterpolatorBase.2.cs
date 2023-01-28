using System;
using UnityEngine;

// Token: 0x02000132 RID: 306
public abstract class CharacterInterpolatorBase<T> : global::CharacterInterpolatorBase
{
	// Token: 0x0600078A RID: 1930 RVA: 0x00020BE4 File Offset: 0x0001EDE4
	protected CharacterInterpolatorBase() : this(false, global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake | global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake)
	{
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x00020BF0 File Offset: 0x0001EDF0
	protected CharacterInterpolatorBase(bool customPusher) : this(customPusher, global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake | global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake)
	{
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x00020BFC File Offset: 0x0001EDFC
	protected CharacterInterpolatorBase(global::IDLocalCharacterAddon.AddonFlags addonFlags) : this(false, addonFlags)
	{
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x00020C08 File Offset: 0x0001EE08
	protected CharacterInterpolatorBase(bool customPusher, global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags | (global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake | global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake))
	{
		this.customPusher = customPusher;
	}

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x0600078E RID: 1934 RVA: 0x00020C1C File Offset: 0x0001EE1C
	public int bufferCapacity
	{
		get
		{
			return this.tbuffer.Length;
		}
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x00020C28 File Offset: 0x0001EE28
	protected override void OnAddonPostAwake()
	{
		this.tbuffer = new global::TimeStamped<T>[(this._bufferCapacity > 0) ? this._bufferCapacity : 0x20];
		this._bufferCapacity = this.tbuffer.Length;
		for (int i = 0; i < this._bufferCapacity; i++)
		{
			this.tbuffer[i].index = i;
		}
	}

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x06000790 RID: 1936 RVA: 0x00020C90 File Offset: 0x0001EE90
	public new double storedDuration
	{
		get
		{
			return (this.len >= 2) ? (this.tbuffer[this.tbuffer[0].index].timeStamp - this.tbuffer[this.tbuffer[this.len - 1].index].timeStamp) : 0.0;
		}
	}

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x06000791 RID: 1937 RVA: 0x00020D04 File Offset: 0x0001EF04
	public new double oldestTimeStamp
	{
		get
		{
			return (this.len != 0) ? this.tbuffer[this.tbuffer[0].index].timeStamp : double.NegativeInfinity;
		}
	}

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x06000792 RID: 1938 RVA: 0x00020D4C File Offset: 0x0001EF4C
	public new double newestTimeStamp
	{
		get
		{
			return (this.len != 0) ? this.tbuffer[this.tbuffer[this.len - 1].index].timeStamp : double.PositiveInfinity;
		}
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x00020D9C File Offset: 0x0001EF9C
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

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x06000794 RID: 1940 RVA: 0x00020E08 File Offset: 0x0001F008
	protected sealed override double __newestTimeStamp
	{
		get
		{
			return this.newestTimeStamp;
		}
	}

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x06000795 RID: 1941 RVA: 0x00020E10 File Offset: 0x0001F010
	protected sealed override double __oldestTimeStamp
	{
		get
		{
			return this.oldestTimeStamp;
		}
	}

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x06000796 RID: 1942 RVA: 0x00020E18 File Offset: 0x0001F018
	protected sealed override double __storedDuration
	{
		get
		{
			return this.storedDuration;
		}
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x00020E20 File Offset: 0x0001F020
	protected sealed override void __Clear()
	{
		this.Clear();
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x00020E28 File Offset: 0x0001F028
	public override void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		throw new global::System.NotImplementedException("The thing using this has not implemented a way to take pos, rot to " + typeof(T));
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x00020E44 File Offset: 0x0001F044
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

	// Token: 0x0600079A RID: 1946 RVA: 0x00021080 File Offset: 0x0001F280
	protected virtual bool CustomPusher(ref T state, ref double timeStamp)
	{
		throw new global::System.NotImplementedException();
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x00021088 File Offset: 0x0001F288
	public void SetGoals(ref T state, ref double timeStamp)
	{
		if (this.customPusher)
		{
			double num = timeStamp;
			T t = state;
			if (this.CustomPusher(ref t, ref num))
			{
				this.Push(ref t, ref num);
			}
		}
		else
		{
			this.Push(ref state, ref timeStamp);
		}
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x000210D0 File Offset: 0x0001F2D0
	public void SetGoals(ref global::TimeStamped<T> state)
	{
		double timeStamp = state.timeStamp;
		T value = state.value;
		this.SetGoals(ref value, ref timeStamp);
	}

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x0600079D RID: 1949 RVA: 0x000210F8 File Offset: 0x0001F2F8
	public new global::CharacterInterpolatorBase interpolator
	{
		get
		{
			return this;
		}
	}

	// Token: 0x04000600 RID: 1536
	private const global::IDLocalCharacterAddon.AddonFlags kRequiredAddonFlags = global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake | global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake;

	// Token: 0x04000601 RID: 1537
	[global::System.NonSerialized]
	protected global::TimeStamped<T>[] tbuffer;

	// Token: 0x04000602 RID: 1538
	private readonly bool customPusher;
}
