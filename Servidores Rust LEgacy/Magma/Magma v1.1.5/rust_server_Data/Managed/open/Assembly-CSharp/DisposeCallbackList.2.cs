using System;
using UnityEngine;

// Token: 0x0200018F RID: 399
public struct DisposeCallbackList<TCallback> : global::System.IDisposable where TCallback : class
{
	// Token: 0x06000BA4 RID: 2980 RVA: 0x0002D2E8 File Offset: 0x0002B4E8
	public DisposeCallbackList(global::DisposeCallbackList<global::UnityEngine.Object, TCallback>.Function invoke)
	{
		this.def = new global::DisposeCallbackList<global::UnityEngine.Object, TCallback>(null, invoke);
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x0002D2F8 File Offset: 0x0002B4F8
	public bool Add(TCallback callback)
	{
		return this.def.Add(callback);
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0002D308 File Offset: 0x0002B508
	public bool Remove(TCallback callback)
	{
		return this.def.Remove(callback);
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0002D318 File Offset: 0x0002B518
	public void Dispose()
	{
		this.def.Dispose();
	}

	// Token: 0x17000327 RID: 807
	// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x0002D328 File Offset: 0x0002B528
	public static global::DisposeCallbackList<TCallback> invalid
	{
		get
		{
			return default(global::DisposeCallbackList<TCallback>);
		}
	}

	// Token: 0x040007F0 RID: 2032
	private global::DisposeCallbackList<global::UnityEngine.Object, TCallback> def;
}
