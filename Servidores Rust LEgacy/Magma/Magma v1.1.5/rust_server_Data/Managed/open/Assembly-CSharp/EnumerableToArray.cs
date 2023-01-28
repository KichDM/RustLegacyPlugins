using System;
using System.Collections.Generic;

// Token: 0x020001A0 RID: 416
public static class EnumerableToArray
{
	// Token: 0x06000C3C RID: 3132 RVA: 0x0002ED9C File Offset: 0x0002CF9C
	public static T[] ToArray<T>(this T[] array)
	{
		int num = array.Length;
		if (num == 0)
		{
			return global::EmptyArray<T>.array;
		}
		T[] array2 = new T[num];
		global::System.Array.Copy(array, array2, num);
		return array2;
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x0002EDCC File Offset: 0x0002CFCC
	public static T[] ToArray<T>(this global::System.Collections.Generic.IEnumerable<T> enumerable)
	{
		if (enumerable is global::System.Collections.Generic.ICollection<T>)
		{
			global::System.Collections.Generic.ICollection<T> collection = (global::System.Collections.Generic.ICollection<T>)enumerable;
			T[] array = new T[collection.Count];
			collection.CopyTo(array, 0);
			return array;
		}
		T[] array2;
		using (global::System.Collections.Generic.IEnumerator<T> enumerator = enumerable.GetEnumerator())
		{
			global::EnumerableToArray.EnumeratorToArray<T> enumeratorToArray = new global::EnumerableToArray.EnumeratorToArray<T>(enumerator);
			array2 = enumeratorToArray.array;
		}
		return array2;
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x0002EE50 File Offset: 0x0002D050
	public static T[] ToArray<T>(this global::System.Collections.Generic.ICollection<T> collection)
	{
		T[] array = new T[collection.Count];
		collection.CopyTo(array, 0);
		return array;
	}

	// Token: 0x020001A1 RID: 417
	private struct EnumeratorToArray<T>
	{
		// Token: 0x06000C3F RID: 3135 RVA: 0x0002EE74 File Offset: 0x0002D074
		public EnumeratorToArray(global::System.Collections.Generic.IEnumerator<T> enumerator)
		{
			this.array = null;
			this.enumerator = enumerator;
			this.len = 0;
			if (enumerator.MoveNext())
			{
				this.Fill();
			}
			else
			{
				this.array = global::EmptyArray<T>.array;
			}
			this.enumerator = null;
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x0002EEB4 File Offset: 0x0002D0B4
		private void Fill()
		{
			int num = this.len++;
			T t = this.enumerator.Current;
			if (this.enumerator.MoveNext())
			{
				this.Fill();
			}
			else
			{
				this.array = new T[this.len];
			}
			this.array[num] = t;
		}

		// Token: 0x04000819 RID: 2073
		public T[] array;

		// Token: 0x0400081A RID: 2074
		private global::System.Collections.Generic.IEnumerator<T> enumerator;

		// Token: 0x0400081B RID: 2075
		private int len;
	}
}
