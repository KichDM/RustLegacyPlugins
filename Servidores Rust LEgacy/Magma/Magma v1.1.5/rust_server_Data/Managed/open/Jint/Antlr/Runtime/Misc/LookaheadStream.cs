using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Misc
{
	// Token: 0x020000AB RID: 171
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public abstract class LookaheadStream<T> : global::Antlr.Runtime.Misc.FastQueue<T> where T : class
	{
		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x0002FE38 File Offset: 0x0002E038
		// (set) Token: 0x060007D9 RID: 2009 RVA: 0x0002FE40 File Offset: 0x0002E040
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public T EndOfFile
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._eof;
			}
			protected set
			{
				this._eof = value;
			}
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0002FE4C File Offset: 0x0002E04C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void Clear()
		{
			base.Clear();
			this._currentElementIndex = 0;
			this._p = 0;
			this._previousElement = default(T);
		}

		// Token: 0x060007DB RID: 2011
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract T NextElement();

		// Token: 0x060007DC RID: 2012
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract bool IsEndOfFile(T o);

		// Token: 0x060007DD RID: 2013 RVA: 0x0002FE70 File Offset: 0x0002E070
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override T Dequeue()
		{
			T result = this[0];
			this._p++;
			if (this._p == this._data.Count && this._markDepth == 0)
			{
				this.Clear();
			}
			return result;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0002FEC0 File Offset: 0x0002E0C0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Consume()
		{
			this.SyncAhead(1);
			this._previousElement = this.Dequeue();
			this._currentElementIndex++;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0002FEE4 File Offset: 0x0002E0E4
		protected virtual void SyncAhead(int need)
		{
			int num = this._p + need - 1 - this._data.Count + 1;
			if (num > 0)
			{
				this.Fill(num);
			}
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0002FF1C File Offset: 0x0002E11C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Fill(int n)
		{
			for (int i = 0; i < n; i++)
			{
				T t = this.NextElement();
				if (this.IsEndOfFile(t))
				{
					this._eof = t;
				}
				this._data.Add(t);
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0002FF64 File Offset: 0x0002E164
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				throw new global::System.NotSupportedException("streams are of unknown size");
			}
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002FF70 File Offset: 0x0002E170
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual T LT(int k)
		{
			if (k == 0)
			{
				return default(T);
			}
			if (k < 0)
			{
				return this.LB(-k);
			}
			this.SyncAhead(k);
			if (this._p + k - 1 > this._data.Count)
			{
				return this._eof;
			}
			return this[k - 1];
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0002FFD4 File Offset: 0x0002E1D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Index
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._currentElementIndex;
			}
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0002FFDC File Offset: 0x0002E1DC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Mark()
		{
			this._markDepth++;
			this._lastMarker = this._p;
			return this._lastMarker;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00030000 File Offset: 0x0002E200
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Release(int marker)
		{
			this._markDepth--;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00030010 File Offset: 0x0002E210
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind(int marker)
		{
			this.Seek(marker);
			this.Release(marker);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00030020 File Offset: 0x0002E220
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind()
		{
			this.Seek(this._lastMarker);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00030030 File Offset: 0x0002E230
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Seek(int index)
		{
			this._p = index;
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0003003C File Offset: 0x0002E23C
		protected virtual T LB(int k)
		{
			if (k == 1)
			{
				return this._previousElement;
			}
			throw new global::System.ArgumentException("can't look backwards more than one token in this stream");
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00030058 File Offset: 0x0002E258
		protected LookaheadStream()
		{
		}

		// Token: 0x04000397 RID: 919
		private int _currentElementIndex;

		// Token: 0x04000398 RID: 920
		private T _previousElement;

		// Token: 0x04000399 RID: 921
		private T _eof = default(T);

		// Token: 0x0400039A RID: 922
		private int _lastMarker;

		// Token: 0x0400039B RID: 923
		private int _markDepth;
	}
}
