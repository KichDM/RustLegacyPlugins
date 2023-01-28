using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200018D RID: 397
public struct DisposeCallbackList<TOwner, TCallback> : global::System.IDisposable where TOwner : global::UnityEngine.Object where TCallback : class
{
	// Token: 0x06000B9A RID: 2970 RVA: 0x0002D0B4 File Offset: 0x0002B2B4
	public DisposeCallbackList(TOwner owner, global::DisposeCallbackList<TOwner, TCallback>.Function invoke)
	{
		if (invoke == null)
		{
			throw new global::System.ArgumentNullException("invoke");
		}
		this.function = invoke;
		this.list = null;
		this.destroyIndex = -1;
		this.count = 0;
		this.owner = owner;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x0002D0F8 File Offset: 0x0002B2F8
	private void Invoke(TCallback value)
	{
		try
		{
			this.function(this.owner, this.list[this.destroyIndex]);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(string.Format("There was a exception thrown while attempting to invoke '{0}' thru '{1}' via owner '{2}'. exception is below\r\n{3}", new object[]
			{
				value,
				this.function,
				this.owner,
				ex
			}), this.owner);
		}
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x0002D194 File Offset: 0x0002B394
	public bool Add(TCallback value)
	{
		if (this.list == null)
		{
			this.list = new global::System.Collections.Generic.List<TCallback>();
		}
		else
		{
			int num = this.list.IndexOf(value);
			if (num != -1)
			{
				if (this.destroyIndex < num && this.count - 1 != num)
				{
					this.list.RemoveAt(num);
					this.list.Add(value);
				}
				return false;
			}
		}
		this.list.Add(value);
		if (this.destroyIndex == this.count++)
		{
			this.Invoke(value);
			this.destroyIndex++;
		}
		return true;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0002D244 File Offset: 0x0002B444
	public bool Remove(TCallback value)
	{
		return this.destroyIndex == -1 && this.list != null && this.list.Remove(value);
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0002D27C File Offset: 0x0002B47C
	public void Dispose()
	{
		if (this.destroyIndex == -1)
		{
			while (++this.destroyIndex < this.count)
			{
				this.Invoke(this.list[this.destroyIndex]);
			}
		}
	}

	// Token: 0x17000326 RID: 806
	// (get) Token: 0x06000B9F RID: 2975 RVA: 0x0002D2D0 File Offset: 0x0002B4D0
	public static global::DisposeCallbackList<TOwner, TCallback> invalid
	{
		get
		{
			return default(global::DisposeCallbackList<TOwner, TCallback>);
		}
	}

	// Token: 0x040007EB RID: 2027
	private readonly global::DisposeCallbackList<TOwner, TCallback>.Function function;

	// Token: 0x040007EC RID: 2028
	private TOwner owner;

	// Token: 0x040007ED RID: 2029
	private global::System.Collections.Generic.List<TCallback> list;

	// Token: 0x040007EE RID: 2030
	private int destroyIndex;

	// Token: 0x040007EF RID: 2031
	private int count;

	// Token: 0x0200018E RID: 398
	// (Invoke) Token: 0x06000BA1 RID: 2977
	public delegate void Function(TOwner owner, TCallback callback);
}
