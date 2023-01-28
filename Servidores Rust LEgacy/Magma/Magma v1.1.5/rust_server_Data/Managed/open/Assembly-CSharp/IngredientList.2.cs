using System;
using Facepunch.Hash;

// Token: 0x0200066D RID: 1645
public sealed class IngredientList<DB> : global::IngredientList, global::System.IEquatable<global::IngredientList<DB>> where DB : global::Datablock, global::System.IComparable<DB>
{
	// Token: 0x0600344B RID: 13387 RVA: 0x000C884C File Offset: 0x000C6A4C
	public IngredientList(DB[] unsorted)
	{
		this.unsorted = (unsorted ?? new DB[0]);
		if (unsorted.Length > 0xFF)
		{
			throw new global::System.ArgumentException("items in list cannot exceed 255");
		}
		this.sorted = null;
		this.lastToString = null;
	}

	// Token: 0x17000AE3 RID: 2787
	// (get) Token: 0x0600344C RID: 13388 RVA: 0x000C889C File Offset: 0x000C6A9C
	public DB[] ordered
	{
		get
		{
			if (this.needReSort)
			{
				this.ReSort();
			}
			return this.sorted;
		}
	}

	// Token: 0x17000AE4 RID: 2788
	// (get) Token: 0x0600344D RID: 13389 RVA: 0x000C88B8 File Offset: 0x000C6AB8
	private bool needReSort
	{
		get
		{
			return this.sorted == null || this.sorted.Length != this.unsorted.Length;
		}
	}

	// Token: 0x0600344E RID: 13390 RVA: 0x000C88E0 File Offset: 0x000C6AE0
	private void ReSort()
	{
		int num = this.unsorted.Length;
		global::System.Array.Resize<DB>(ref this.sorted, num);
		global::System.Array.Copy(this.unsorted, this.sorted, num);
		if (num > 0xFF)
		{
			throw new global::System.InvalidOperationException("There can't be more than 255 ingredients per blueprint");
		}
		global::System.Array.Sort<DB>(this.sorted);
	}

	// Token: 0x0600344F RID: 13391 RVA: 0x000C8938 File Offset: 0x000C6B38
	public global::IngredientList<DB> EnsureContents(DB[] original)
	{
		if (this.unsorted != original)
		{
			this.sorted = null;
			this.lastToString = null;
			this.madeHashCode = false;
			this.unsorted = original;
		}
		return this;
	}

	// Token: 0x17000AE5 RID: 2789
	// (get) Token: 0x06003450 RID: 13392 RVA: 0x000C8964 File Offset: 0x000C6B64
	public uint hashCode
	{
		get
		{
			DB[] ordered;
			if (!this.madeHashCode)
			{
				ordered = this.ordered;
			}
			else
			{
				if (!this.needReSort)
				{
					return this.hash;
				}
				this.ReSort();
				ordered = this.sorted;
			}
			int num = ordered.Length;
			if (num > global::IngredientList.tempHash.Length)
			{
				global::System.Array.Resize<int>(ref global::IngredientList.tempHash, num);
			}
			for (int i = 0; i < num; i++)
			{
				global::IngredientList.tempHash[i] = ordered[i].uniqueID;
			}
			this.hash = global::Facepunch.Hash.MurmurHash2.UINT(global::IngredientList.tempHash, num, 0xF00DFEEDU);
			this.madeHashCode = true;
			return this.hash;
		}
	}

	// Token: 0x06003451 RID: 13393 RVA: 0x000C8A18 File Offset: 0x000C6C18
	public override int GetHashCode()
	{
		return (int)this.hashCode;
	}

	// Token: 0x06003452 RID: 13394 RVA: 0x000C8A20 File Offset: 0x000C6C20
	public override bool Equals(object obj)
	{
		return obj is global::IngredientList<DB> && this.Equals((global::IngredientList<DB>)obj);
	}

	// Token: 0x06003453 RID: 13395 RVA: 0x000C8A3C File Offset: 0x000C6C3C
	private static string Combine(DB[] dbs)
	{
		string[] array = new string[dbs.Length];
		for (int i = 0; i < dbs.Length; i++)
		{
			array[i] = global::System.Convert.ToString(dbs[i]);
		}
		return string.Join(",", array);
	}

	// Token: 0x17000AE6 RID: 2790
	// (get) Token: 0x06003454 RID: 13396 RVA: 0x000C8A8C File Offset: 0x000C6C8C
	public string text
	{
		get
		{
			string result;
			if ((result = this.lastToString) == null)
			{
				result = (this.lastToString = global::IngredientList<DB>.Combine(this.ordered));
			}
			return result;
		}
	}

	// Token: 0x06003455 RID: 13397 RVA: 0x000C8ABC File Offset: 0x000C6CBC
	public override string ToString()
	{
		return string.Format("[IngredientList<{0}>[{1}]{2:X}:{3}]", new object[]
		{
			typeof(DB).Name,
			this.unsorted.Length,
			this.hashCode,
			this.text
		});
	}

	// Token: 0x06003456 RID: 13398 RVA: 0x000C8B14 File Offset: 0x000C6D14
	public bool Equals(global::IngredientList<DB> other)
	{
		if (object.ReferenceEquals(other, this))
		{
			return true;
		}
		if (other != null && this.unsorted.Length == other.unsorted.Length && this.hashCode == other.hashCode)
		{
			DB[] array = this.sorted;
			DB[] array2 = other.sorted;
			int i = 0;
			int num = array.Length;
			while (i < num)
			{
				if (array[i] != array2[i])
				{
					return false;
				}
				if (--num <= i)
				{
					break;
				}
				if (array[num] != array2[num])
				{
					return false;
				}
				i++;
			}
			return true;
		}
		return false;
	}

	// Token: 0x04001D2D RID: 7469
	public DB[] unsorted;

	// Token: 0x04001D2E RID: 7470
	private DB[] sorted;

	// Token: 0x04001D2F RID: 7471
	private bool madeHashCode;

	// Token: 0x04001D30 RID: 7472
	private uint hash;

	// Token: 0x04001D31 RID: 7473
	private string lastToString;
}
