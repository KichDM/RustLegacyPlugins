using System;
using System.Collections.Generic;

// Token: 0x020001AE RID: 430
public sealed class TempList<T> : global::System.Collections.Generic.List<T>, global::System.IDisposable
{
	// Token: 0x06000C97 RID: 3223 RVA: 0x0003000C File Offset: 0x0002E20C
	private TempList()
	{
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x00030014 File Offset: 0x0002E214
	private TempList(global::System.Collections.Generic.IEnumerable<T> enumerable) : base(enumerable)
	{
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x00030020 File Offset: 0x0002E220
	private void Activate()
	{
		if (!this.active)
		{
			if (this.inDump)
			{
				throw new global::System.InvalidOperationException();
			}
			if (global::TempList<T>.activeCount == 0)
			{
				global::TempList<T>.firstActive = this;
				global::TempList<T>.lastActive = this;
				this.p = (this.n = false);
				this.prev = (this.next = null);
			}
			else if (global::TempList<T>.activeCount == 1)
			{
				global::TempList<T>.lastActive = this;
				this.p = true;
				this.n = false;
				this.prev = global::TempList<T>.firstActive;
				this.next = null;
				global::TempList<T>.firstActive.n = true;
				global::TempList<T>.firstActive.next = this;
			}
			else
			{
				this.p = true;
				this.n = false;
				this.prev = global::TempList<T>.lastActive;
				global::TempList<T>.lastActive.n = true;
				global::TempList<T>.lastActive.next = this;
				global::TempList<T>.lastActive = this;
				this.next = null;
			}
			global::TempList<T>.activeCount++;
			this.active = true;
		}
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x00030120 File Offset: 0x0002E320
	private void Deactivate()
	{
		if (this.active)
		{
			if (this.inDump)
			{
				throw new global::System.InvalidOperationException();
			}
			if (global::TempList<T>.lastActive == this)
			{
				if (global::TempList<T>.firstActive != this)
				{
					global::TempList<T>.lastActive = this.prev;
					this.prev.n = false;
					this.prev.next = null;
				}
				else
				{
					global::TempList<T>.lastActive = null;
					global::TempList<T>.firstActive = null;
				}
			}
			else if (global::TempList<T>.firstActive == this)
			{
				this.next.p = false;
				this.next.prev = null;
				global::TempList<T>.firstActive = this.next;
			}
			else
			{
				this.prev.next = this.next;
				this.next.prev = this.prev;
			}
			this.prev = null;
			this.next = null;
			this.p = false;
			this.n = false;
			this.active = false;
			global::TempList<T>.activeCount--;
		}
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0003021C File Offset: 0x0002E41C
	private void Bin()
	{
		if (!this.inDump)
		{
			if (this.active)
			{
				throw new global::System.InvalidOperationException();
			}
			this.next = global::TempList<T>.dump;
			int num = global::TempList<T>.dumpCount;
			global::TempList<T>.dumpCount = num + 1;
			if (num != 0)
			{
				global::TempList<T>.dump.prev = this;
			}
			global::TempList<T>.dump = this;
			this.inDump = true;
			this.Clear();
		}
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x00030280 File Offset: 0x0002E480
	private static bool Resurrect(out global::TempList<T> twl)
	{
		if (global::TempList<T>.dumpCount != 0)
		{
			twl = global::TempList<T>.dump;
			global::TempList<T>.dump = ((--global::TempList<T>.dumpCount != 0) ? twl.prev : null);
			twl.inDump = false;
			twl.prev = null;
			return true;
		}
		twl = null;
		return false;
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x000302D8 File Offset: 0x0002E4D8
	public static global::TempList<T> New()
	{
		global::TempList<T> result;
		if (global::TempList<T>.Resurrect(out result))
		{
			return result;
		}
		return new global::TempList<T>();
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x000302F8 File Offset: 0x0002E4F8
	public static global::TempList<T> New(global::System.Collections.Generic.IEnumerable<T> windows)
	{
		global::TempList<T> tempList;
		if (global::TempList<T>.Resurrect(out tempList))
		{
			tempList.AddRange(windows);
			return tempList;
		}
		return new global::TempList<T>(windows);
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x00030320 File Offset: 0x0002E520
	public void Dispose()
	{
		this.Deactivate();
		this.Bin();
	}

	// Token: 0x0400083D RID: 2109
	private static global::TempList<T> dump;

	// Token: 0x0400083E RID: 2110
	private static int dumpCount;

	// Token: 0x0400083F RID: 2111
	private static global::TempList<T> lastActive;

	// Token: 0x04000840 RID: 2112
	private static global::TempList<T> firstActive;

	// Token: 0x04000841 RID: 2113
	private static int activeCount;

	// Token: 0x04000842 RID: 2114
	private global::TempList<T> prev;

	// Token: 0x04000843 RID: 2115
	private global::TempList<T> next;

	// Token: 0x04000844 RID: 2116
	private bool inDump;

	// Token: 0x04000845 RID: 2117
	private bool active;

	// Token: 0x04000846 RID: 2118
	private bool p;

	// Token: 0x04000847 RID: 2119
	private bool n;
}
