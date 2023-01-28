using System;
using UnityEngine;

// Token: 0x020001E9 RID: 489
public struct CacheRef<T> where T : global::UnityEngine.Object
{
	// Token: 0x06000D9F RID: 3487 RVA: 0x000351EC File Offset: 0x000333EC
	private CacheRef(T value)
	{
		this.value = value;
		this.existed = value;
		this.cached = true;
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x00035210 File Offset: 0x00033410
	public bool alive
	{
		get
		{
			return this.existed && (this.existed = this.value);
		}
	}

	// Token: 0x06000DA1 RID: 3489 RVA: 0x00035244 File Offset: 0x00033444
	public bool Get(out T value)
	{
		value = this.value;
		return this.cached && this.existed && (this.existed = value);
	}

	// Token: 0x06000DA2 RID: 3490 RVA: 0x00035290 File Offset: 0x00033490
	public static implicit operator global::CacheRef<T>(T value)
	{
		return new global::CacheRef<T>(value);
	}

	// Token: 0x0400089E RID: 2206
	[global::System.NonSerialized]
	public T value;

	// Token: 0x0400089F RID: 2207
	[global::System.NonSerialized]
	public readonly bool cached;

	// Token: 0x040008A0 RID: 2208
	[global::System.NonSerialized]
	private bool existed;
}
