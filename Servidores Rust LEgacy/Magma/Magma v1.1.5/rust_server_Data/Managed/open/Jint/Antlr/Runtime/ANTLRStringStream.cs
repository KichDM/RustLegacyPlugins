using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x0200008E RID: 142
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class ANTLRStringStream : global::Antlr.Runtime.ICharStream, global::Antlr.Runtime.IIntStream
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x0002B6BC File Offset: 0x000298BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRStringStream(string input) : this(input, null)
		{
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0002B6C8 File Offset: 0x000298C8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRStringStream(string input, string sourceName) : this(input.ToCharArray(), input.Length, sourceName)
		{
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0002B6EC File Offset: 0x000298EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRStringStream(char[] data, int numberOfActualCharsInArray) : this(data, numberOfActualCharsInArray, null)
		{
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0002B6F8 File Offset: 0x000298F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRStringStream(char[] data, int numberOfActualCharsInArray, string sourceName)
		{
			this.line = 1;
			base..ctor();
			if (data == null)
			{
				throw new global::System.ArgumentNullException("data");
			}
			if (numberOfActualCharsInArray < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (numberOfActualCharsInArray > data.Length)
			{
				throw new global::System.ArgumentException();
			}
			this.data = data;
			this.n = numberOfActualCharsInArray;
			this.name = sourceName;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0002B758 File Offset: 0x00029958
		protected ANTLRStringStream()
		{
			this.line = 1;
			base..ctor();
			this.data = new char[0];
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x0002B774 File Offset: 0x00029974
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Index
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.p;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x0002B77C File Offset: 0x0002997C
		// (set) Token: 0x06000637 RID: 1591 RVA: 0x0002B784 File Offset: 0x00029984
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Line
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.line;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.line = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x0002B790 File Offset: 0x00029990
		// (set) Token: 0x06000639 RID: 1593 RVA: 0x0002B798 File Offset: 0x00029998
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int CharPositionInLine
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.charPositionInLine;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.charPositionInLine = value;
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0002B7A4 File Offset: 0x000299A4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			this.p = 0;
			this.line = 1;
			this.charPositionInLine = 0;
			this.markDepth = 0;
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0002B7C4 File Offset: 0x000299C4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Consume()
		{
			if (this.p < this.n)
			{
				this.charPositionInLine++;
				if (this.data[this.p] == '\n')
				{
					this.line++;
					this.charPositionInLine = 0;
				}
				this.p++;
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0002B82C File Offset: 0x00029A2C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int LA(int i)
		{
			if (i == 0)
			{
				return 0;
			}
			if (i < 0)
			{
				i++;
				if (this.p + i - 1 < 0)
				{
					return -1;
				}
			}
			if (this.p + i - 1 >= this.n)
			{
				return -1;
			}
			return (int)this.data[this.p + i - 1];
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0002B88C File Offset: 0x00029A8C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int LT(int i)
		{
			return this.LA(i);
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0002B898 File Offset: 0x00029A98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.n;
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0002B8A0 File Offset: 0x00029AA0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Mark()
		{
			if (this.markers == null)
			{
				this.markers = new global::System.Collections.Generic.List<global::Antlr.Runtime.CharStreamState>();
				this.markers.Add(null);
			}
			this.markDepth++;
			global::Antlr.Runtime.CharStreamState charStreamState;
			if (this.markDepth >= this.markers.Count)
			{
				charStreamState = new global::Antlr.Runtime.CharStreamState();
				this.markers.Add(charStreamState);
			}
			else
			{
				charStreamState = this.markers[this.markDepth];
			}
			charStreamState.p = this.p;
			charStreamState.line = this.line;
			charStreamState.charPositionInLine = this.charPositionInLine;
			this.lastMarker = this.markDepth;
			return this.markDepth;
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0002B958 File Offset: 0x00029B58
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind(int m)
		{
			if (m < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			global::Antlr.Runtime.CharStreamState charStreamState = this.markers[m];
			this.Seek(charStreamState.p);
			this.line = charStreamState.line;
			this.charPositionInLine = charStreamState.charPositionInLine;
			this.Release(m);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0002B9B0 File Offset: 0x00029BB0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind()
		{
			this.Rewind(this.lastMarker);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0002B9C0 File Offset: 0x00029BC0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Release(int marker)
		{
			this.markDepth = marker;
			this.markDepth--;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0002B9D8 File Offset: 0x00029BD8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Seek(int index)
		{
			if (index <= this.p)
			{
				this.p = index;
				return;
			}
			while (this.p < index)
			{
				this.Consume();
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0002BA00 File Offset: 0x00029C00
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string Substring(int start, int length)
		{
			if (start < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (length < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (start + length > this.data.Length)
			{
				throw new global::System.ArgumentException();
			}
			if (length == 0)
			{
				return string.Empty;
			}
			return new string(this.data, start, length);
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0002BA5C File Offset: 0x00029C5C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.name;
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0002BA64 File Offset: 0x00029C64
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return new string(this.data);
		}

		// Token: 0x04000342 RID: 834
		protected char[] data;

		// Token: 0x04000343 RID: 835
		protected int n;

		// Token: 0x04000344 RID: 836
		protected int p;

		// Token: 0x04000345 RID: 837
		private int line;

		// Token: 0x04000346 RID: 838
		private int charPositionInLine;

		// Token: 0x04000347 RID: 839
		protected int markDepth;

		// Token: 0x04000348 RID: 840
		protected global::System.Collections.Generic.IList<global::Antlr.Runtime.CharStreamState> markers;

		// Token: 0x04000349 RID: 841
		protected int lastMarker;

		// Token: 0x0400034A RID: 842
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string name;
	}
}
