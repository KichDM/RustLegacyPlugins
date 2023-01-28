using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime
{
	// Token: 0x02000096 RID: 150
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class BufferedTokenStream : global::Antlr.Runtime.ITokenStream, global::Antlr.Runtime.IIntStream, global::Antlr.Runtime.ITokenStreamInformation
	{
		// Token: 0x060006B5 RID: 1717 RVA: 0x0002D1D0 File Offset: 0x0002B3D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BufferedTokenStream()
		{
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0002D1EC File Offset: 0x0002B3EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BufferedTokenStream(global::Antlr.Runtime.ITokenSource tokenSource)
		{
			this._tokenSource = tokenSource;
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0002D210 File Offset: 0x0002B410
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x0002D218 File Offset: 0x0002B418
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.ITokenSource TokenSource
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._tokenSource;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._tokenSource = value;
				this._tokens.Clear();
				this._p = -1;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0002D234 File Offset: 0x0002B434
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Index
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._p;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x0002D23C File Offset: 0x0002B43C
		// (set) Token: 0x060006BB RID: 1723 RVA: 0x0002D244 File Offset: 0x0002B444
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

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x0002D250 File Offset: 0x0002B450
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._tokens.Count;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0002D260 File Offset: 0x0002B460
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._tokenSource.SourceName;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x0002D270 File Offset: 0x0002B470
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken LastToken
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.LB(1);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0002D27C File Offset: 0x0002B47C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken LastRealToken
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				int num = 0;
				global::Antlr.Runtime.IToken token;
				do
				{
					num++;
					token = this.LB(num);
				}
				while (token != null && token.Line <= 0);
				return token;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x0002D2AC File Offset: 0x0002B4AC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int MaxLookBehind
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return int.MaxValue;
			}
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0002D2B4 File Offset: 0x0002B4B4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Mark()
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			this._lastMarker = this.Index;
			return this._lastMarker;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0002D2DC File Offset: 0x0002B4DC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Release(int marker)
		{
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0002D2E0 File Offset: 0x0002B4E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind(int marker)
		{
			this.Seek(marker);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0002D2EC File Offset: 0x0002B4EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind()
		{
			this.Seek(this._lastMarker);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0002D2FC File Offset: 0x0002B4FC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			this._p = 0;
			this._lastMarker = 0;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0002D30C File Offset: 0x0002B50C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Seek(int index)
		{
			this._p = index;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0002D318 File Offset: 0x0002B518
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Consume()
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			this._p++;
			this.Sync(this._p);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0002D348 File Offset: 0x0002B548
		protected virtual void Sync(int i)
		{
			int num = i - this._tokens.Count + 1;
			if (num > 0)
			{
				this.Fetch(num);
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0002D378 File Offset: 0x0002B578
		protected virtual void Fetch(int n)
		{
			for (int i = 0; i < n; i++)
			{
				global::Antlr.Runtime.IToken token = this.TokenSource.NextToken();
				token.TokenIndex = this._tokens.Count;
				this._tokens.Add(token);
				if (token.Type == -1)
				{
					return;
				}
			}
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0002D3D0 File Offset: 0x0002B5D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken Get(int i)
		{
			if (i < 0 || i >= this._tokens.Count)
			{
				throw new global::System.IndexOutOfRangeException(string.Concat(new object[]
				{
					"token index ",
					i,
					" out of range 0..",
					this._tokens.Count - 1
				}));
			}
			return this._tokens[i];
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0002D448 File Offset: 0x0002B648
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int LA(int i)
		{
			return this.LT(i).Type;
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0002D458 File Offset: 0x0002B658
		protected virtual global::Antlr.Runtime.IToken LB(int k)
		{
			if (this._p - k < 0)
			{
				return null;
			}
			return this._tokens[this._p - k];
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0002D480 File Offset: 0x0002B680
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken LT(int k)
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			if (k == 0)
			{
				return null;
			}
			if (k < 0)
			{
				return this.LB(-k);
			}
			int num = this._p + k - 1;
			this.Sync(num);
			if (num >= this._tokens.Count)
			{
				return this._tokens[this._tokens.Count - 1];
			}
			if (num > this.Range)
			{
				this.Range = num;
			}
			return this._tokens[this._p + k - 1];
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0002D520 File Offset: 0x0002B720
		protected virtual void Setup()
		{
			this.Sync(0);
			this._p = 0;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0002D530 File Offset: 0x0002B730
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> GetTokens()
		{
			return this._tokens;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0002D538 File Offset: 0x0002B738
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> GetTokens(int start, int stop)
		{
			return this.GetTokens(start, stop, null);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0002D544 File Offset: 0x0002B744
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> GetTokens(int start, int stop, global::Antlr.Runtime.BitSet types)
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			if (stop >= this._tokens.Count)
			{
				stop = this._tokens.Count - 1;
			}
			if (start < 0)
			{
				start = 0;
			}
			if (start > stop)
			{
				return null;
			}
			global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> list = new global::System.Collections.Generic.List<global::Antlr.Runtime.IToken>();
			for (int i = start; i <= stop; i++)
			{
				global::Antlr.Runtime.IToken token = this._tokens[i];
				if (types == null || types.Member(token.Type))
				{
					list.Add(token);
				}
			}
			if (list.Count == 0)
			{
				list = null;
			}
			return list;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0002D5E8 File Offset: 0x0002B7E8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> GetTokens(int start, int stop, global::System.Collections.Generic.IEnumerable<int> types)
		{
			return this.GetTokens(start, stop, new global::Antlr.Runtime.BitSet(types));
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0002D5F8 File Offset: 0x0002B7F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> GetTokens(int start, int stop, int ttype)
		{
			return this.GetTokens(start, stop, global::Antlr.Runtime.BitSet.Of(ttype));
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0002D608 File Offset: 0x0002B808
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			this.Fill();
			return this.ToString(0, this._tokens.Count - 1);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0002D648 File Offset: 0x0002B848
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(int start, int stop)
		{
			if (start < 0 || stop < 0)
			{
				return null;
			}
			if (this._p == -1)
			{
				this.Setup();
			}
			if (stop >= this._tokens.Count)
			{
				stop = this._tokens.Count - 1;
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			for (int i = start; i <= stop; i++)
			{
				global::Antlr.Runtime.IToken token = this._tokens[i];
				if (token.Type == -1)
				{
					break;
				}
				stringBuilder.Append(token.Text);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0002D6DC File Offset: 0x0002B8DC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop)
		{
			if (start != null && stop != null)
			{
				return this.ToString(start.TokenIndex, stop.TokenIndex);
			}
			return null;
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0002D700 File Offset: 0x0002B900
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Fill()
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			if (this._tokens[this._p].Type == -1)
			{
				return;
			}
			int num = this._p + 1;
			this.Sync(num);
			while (this._tokens[num].Type != -1)
			{
				num++;
				this.Sync(num);
			}
		}

		// Token: 0x0400035A RID: 858
		private global::Antlr.Runtime.ITokenSource _tokenSource;

		// Token: 0x0400035B RID: 859
		[global::System.CLSCompliant(false)]
		protected global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> _tokens = new global::System.Collections.Generic.List<global::Antlr.Runtime.IToken>(0x64);

		// Token: 0x0400035C RID: 860
		private int _lastMarker;

		// Token: 0x0400035D RID: 861
		[global::System.CLSCompliant(false)]
		protected int _p = -1;

		// Token: 0x0400035E RID: 862
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <Range>k__BackingField;
	}
}
