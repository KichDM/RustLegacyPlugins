using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime.Misc
{
	// Token: 0x020000AA RID: 170
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class FastQueue<T>
	{
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x0002FC88 File Offset: 0x0002DE88
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._data.Count - this._p;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0002FC9C File Offset: 0x0002DE9C
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x0002FCA4 File Offset: 0x0002DEA4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Range
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.<Range>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			protected set
			{
				this.<Range>k__BackingField = value;
			}
		}

		// Token: 0x17000187 RID: 391
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual T this[int i]
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				int num = this._p + i;
				if (num >= this._data.Count)
				{
					throw new global::System.ArgumentException(string.Format("queue index {0} > last index {1}", num, this._data.Count - 1));
				}
				if (num < 0)
				{
					throw new global::System.ArgumentException(string.Format("queue index {0} < 0", num));
				}
				if (num > this.Range)
				{
					this.Range = num;
				}
				return this._data[num];
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0002FD40 File Offset: 0x0002DF40
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual T Dequeue()
		{
			if (this.Count == 0)
			{
				throw new global::System.InvalidOperationException();
			}
			T result = this[0];
			this._p++;
			if (this._p == this._data.Count)
			{
				this.Clear();
			}
			return result;
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0002FD98 File Offset: 0x0002DF98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Enqueue(T o)
		{
			this._data.Add(o);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0002FDA8 File Offset: 0x0002DFA8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual T Peek()
		{
			return this[0];
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0002FDB4 File Offset: 0x0002DFB4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Clear()
		{
			this._p = 0;
			this._data.Clear();
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0002FDC8 File Offset: 0x0002DFC8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			int count = this.Count;
			for (int i = 0; i < count; i++)
			{
				stringBuilder.Append(this[i]);
				if (i + 1 < count)
				{
					stringBuilder.Append(" ");
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0002FE24 File Offset: 0x0002E024
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FastQueue()
		{
		}

		// Token: 0x04000394 RID: 916
		internal global::System.Collections.Generic.List<T> _data = new global::System.Collections.Generic.List<T>();

		// Token: 0x04000395 RID: 917
		internal int _p;

		// Token: 0x04000396 RID: 918
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <Range>k__BackingField;
	}
}
