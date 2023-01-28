using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200019C RID: 412
public static class EmptyArray<T>
{
	// Token: 0x06000C2C RID: 3116 RVA: 0x0002ECCC File Offset: 0x0002CECC
	// Note: this type is marked as 'beforefieldinit'.
	static EmptyArray()
	{
	}

	// Token: 0x1700033B RID: 827
	// (get) Token: 0x06000C2D RID: 3117 RVA: 0x0002ECF0 File Offset: 0x0002CEF0
	public static object defaultBoxedValue
	{
		get
		{
			return (!global::EmptyArray<T>.isByRef) ? global::EmptyArray<T>.DefaultBoxedValue.value : null;
		}
	}

	// Token: 0x1700033C RID: 828
	// (get) Token: 0x06000C2E RID: 3118 RVA: 0x0002ED08 File Offset: 0x0002CF08
	public static global::System.Collections.Generic.IEnumerator<T> emptyEnumerator
	{
		get
		{
			return global::EmptyArray<T>.EmptyEnumerator.singleton;
		}
	}

	// Token: 0x1700033D RID: 829
	// (get) Token: 0x06000C2F RID: 3119 RVA: 0x0002ED10 File Offset: 0x0002CF10
	public static global::System.Collections.Generic.IEnumerable<T> emptyEnumerable
	{
		get
		{
			return global::EmptyArray<T>.EmptyEnumerable.singleton;
		}
	}

	// Token: 0x04000814 RID: 2068
	public static readonly T[] array = new T[0];

	// Token: 0x04000815 RID: 2069
	public static readonly bool isByRef = typeof(T).IsByRef;

	// Token: 0x0200019D RID: 413
	private static class DefaultBoxedValue
	{
		// Token: 0x06000C30 RID: 3120 RVA: 0x0002ED18 File Offset: 0x0002CF18
		// Note: this type is marked as 'beforefieldinit'.
		static DefaultBoxedValue()
		{
		}

		// Token: 0x04000816 RID: 2070
		public static object value = default(T);
	}

	// Token: 0x0200019E RID: 414
	private class EmptyEnumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
	{
		// Token: 0x06000C31 RID: 3121 RVA: 0x0002ED38 File Offset: 0x0002CF38
		private EmptyEnumerator()
		{
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x0002ED40 File Offset: 0x0002CF40
		// Note: this type is marked as 'beforefieldinit'.
		static EmptyEnumerator()
		{
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x0002ED4C File Offset: 0x0002CF4C
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return global::EmptyArray<T>.defaultBoxedValue;
			}
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0002ED54 File Offset: 0x0002CF54
		public bool MoveNext()
		{
			return false;
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x0002ED58 File Offset: 0x0002CF58
		public T Current
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0002ED70 File Offset: 0x0002CF70
		public void Reset()
		{
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0002ED74 File Offset: 0x0002CF74
		public void Dispose()
		{
		}

		// Token: 0x04000817 RID: 2071
		public static global::System.Collections.Generic.IEnumerator<T> singleton = new global::EmptyArray<T>.EmptyEnumerator();
	}

	// Token: 0x0200019F RID: 415
	private class EmptyEnumerable : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>
	{
		// Token: 0x06000C38 RID: 3128 RVA: 0x0002ED78 File Offset: 0x0002CF78
		public EmptyEnumerable()
		{
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0002ED80 File Offset: 0x0002CF80
		// Note: this type is marked as 'beforefieldinit'.
		static EmptyEnumerable()
		{
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0002ED8C File Offset: 0x0002CF8C
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return global::EmptyArray<T>.EmptyEnumerator.singleton;
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0002ED94 File Offset: 0x0002CF94
		public global::System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			return global::EmptyArray<T>.EmptyEnumerator.singleton;
		}

		// Token: 0x04000818 RID: 2072
		public static global::System.Collections.Generic.IEnumerable<T> singleton = new global::EmptyArray<T>.EmptyEnumerable();
	}
}
