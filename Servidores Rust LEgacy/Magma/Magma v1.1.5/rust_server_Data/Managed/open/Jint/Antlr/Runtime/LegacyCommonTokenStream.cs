using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime
{
	// Token: 0x020000A8 RID: 168
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class LegacyCommonTokenStream : global::Antlr.Runtime.ITokenStream, global::Antlr.Runtime.IIntStream
	{
		// Token: 0x0600078E RID: 1934 RVA: 0x0002EDC4 File Offset: 0x0002CFC4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public LegacyCommonTokenStream()
		{
			this.tokens = new global::System.Collections.Generic.List<global::Antlr.Runtime.IToken>(0x1F4);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0002EDE4 File Offset: 0x0002CFE4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public LegacyCommonTokenStream(global::Antlr.Runtime.ITokenSource tokenSource) : this()
		{
			this._tokenSource = tokenSource;
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0002EDF4 File Offset: 0x0002CFF4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public LegacyCommonTokenStream(global::Antlr.Runtime.ITokenSource tokenSource, int channel) : this(tokenSource)
		{
			this.channel = channel;
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x0002EE04 File Offset: 0x0002D004
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Index
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.p;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0002EE0C File Offset: 0x0002D00C
		// (set) Token: 0x06000793 RID: 1939 RVA: 0x0002EE14 File Offset: 0x0002D014
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

		// Token: 0x06000794 RID: 1940 RVA: 0x0002EE20 File Offset: 0x0002D020
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetTokenSource(global::Antlr.Runtime.ITokenSource tokenSource)
		{
			this._tokenSource = tokenSource;
			this.tokens.Clear();
			this.p = -1;
			this.channel = 0;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0002EE44 File Offset: 0x0002D044
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void FillBuffer()
		{
			if (this.p != -1)
			{
				return;
			}
			int num = 0;
			global::Antlr.Runtime.IToken token = this._tokenSource.NextToken();
			while (token != null && token.Type != -1)
			{
				bool flag = false;
				int num2;
				if (this.channelOverrideMap != null && this.channelOverrideMap.TryGetValue(token.Type, out num2))
				{
					token.Channel = num2;
				}
				if (this.discardSet != null && this.discardSet.Contains(token.Type))
				{
					flag = true;
				}
				else if (this.discardOffChannelTokens && token.Channel != this.channel)
				{
					flag = true;
				}
				if (!flag)
				{
					token.TokenIndex = num;
					this.tokens.Add(token);
					num++;
				}
				token = this._tokenSource.NextToken();
			}
			this.p = 0;
			this.p = this.SkipOffTokenChannels(this.p);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0002EF3C File Offset: 0x0002D13C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Consume()
		{
			if (this.p < this.tokens.Count)
			{
				this.p++;
				this.p = this.SkipOffTokenChannels(this.p);
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0002EF74 File Offset: 0x0002D174
		protected virtual int SkipOffTokenChannels(int i)
		{
			int count = this.tokens.Count;
			while (i < count && this.tokens[i].Channel != this.channel)
			{
				i++;
			}
			return i;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0002EFBC File Offset: 0x0002D1BC
		protected virtual int SkipOffTokenChannelsReverse(int i)
		{
			while (i >= 0 && this.tokens[i].Channel != this.channel)
			{
				i--;
			}
			return i;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0002EFEC File Offset: 0x0002D1EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetTokenTypeChannel(int ttype, int channel)
		{
			if (this.channelOverrideMap == null)
			{
				this.channelOverrideMap = new global::System.Collections.Generic.Dictionary<int, int>();
			}
			this.channelOverrideMap[ttype] = channel;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0002F014 File Offset: 0x0002D214
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void DiscardTokenType(int ttype)
		{
			if (this.discardSet == null)
			{
				this.discardSet = new global::System.Collections.Generic.HashSet<int>();
			}
			this.discardSet.Add(ttype);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0002F03C File Offset: 0x0002D23C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetDiscardOffChannelTokens(bool discardOffChannelTokens)
		{
			this.discardOffChannelTokens = discardOffChannelTokens;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0002F048 File Offset: 0x0002D248
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.IToken> GetTokens()
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			return this.tokens;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0002F064 File Offset: 0x0002D264
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.IToken> GetTokens(int start, int stop)
		{
			return this.GetTokens(start, stop, null);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0002F070 File Offset: 0x0002D270
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.IToken> GetTokens(int start, int stop, global::Antlr.Runtime.BitSet types)
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			if (stop >= this.tokens.Count)
			{
				stop = this.tokens.Count - 1;
			}
			if (start < 0)
			{
				start = 0;
			}
			if (start > stop)
			{
				return null;
			}
			global::System.Collections.Generic.IList<global::Antlr.Runtime.IToken> list = new global::System.Collections.Generic.List<global::Antlr.Runtime.IToken>();
			for (int i = start; i <= stop; i++)
			{
				global::Antlr.Runtime.IToken token = this.tokens[i];
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

		// Token: 0x0600079F RID: 1951 RVA: 0x0002F114 File Offset: 0x0002D314
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.IToken> GetTokens(int start, int stop, global::System.Collections.Generic.IList<int> types)
		{
			return this.GetTokens(start, stop, new global::Antlr.Runtime.BitSet(types));
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0002F124 File Offset: 0x0002D324
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.IToken> GetTokens(int start, int stop, int ttype)
		{
			return this.GetTokens(start, stop, global::Antlr.Runtime.BitSet.Of(ttype));
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0002F134 File Offset: 0x0002D334
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken LT(int k)
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			if (k == 0)
			{
				return null;
			}
			if (k < 0)
			{
				return this.LB(-k);
			}
			if (this.p + k - 1 >= this.tokens.Count)
			{
				return this.tokens[this.tokens.Count - 1];
			}
			int num = this.p;
			for (int i = 1; i < k; i++)
			{
				num = this.SkipOffTokenChannels(num + 1);
			}
			if (num >= this.tokens.Count)
			{
				return this.tokens[this.tokens.Count - 1];
			}
			if (num > this.Range)
			{
				this.Range = num;
			}
			return this.tokens[num];
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0002F20C File Offset: 0x0002D40C
		protected virtual global::Antlr.Runtime.IToken LB(int k)
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			if (k == 0)
			{
				return null;
			}
			if (this.p - k < 0)
			{
				return null;
			}
			int num = this.p;
			for (int i = 1; i <= k; i++)
			{
				num = this.SkipOffTokenChannelsReverse(num - 1);
			}
			if (num < 0)
			{
				return null;
			}
			return this.tokens[num];
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0002F27C File Offset: 0x0002D47C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken Get(int i)
		{
			return this.tokens[i];
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0002F28C File Offset: 0x0002D48C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int LA(int i)
		{
			return this.LT(i).Type;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0002F29C File Offset: 0x0002D49C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Mark()
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			this.lastMarker = this.Index;
			return this.lastMarker;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0002F2C4 File Offset: 0x0002D4C4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Release(int marker)
		{
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x0002F2C8 File Offset: 0x0002D4C8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.tokens.Count;
			}
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0002F2D8 File Offset: 0x0002D4D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind(int marker)
		{
			this.Seek(marker);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0002F2E4 File Offset: 0x0002D4E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind()
		{
			this.Seek(this.lastMarker);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0002F2F4 File Offset: 0x0002D4F4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			this.p = 0;
			this.lastMarker = 0;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0002F304 File Offset: 0x0002D504
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Seek(int index)
		{
			this.p = index;
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x0002F310 File Offset: 0x0002D510
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.ITokenSource TokenSource
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._tokenSource;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x0002F318 File Offset: 0x0002D518
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.TokenSource.SourceName;
			}
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0002F328 File Offset: 0x0002D528
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (this.p == -1)
			{
				throw new global::System.InvalidOperationException("Buffer is not yet filled.");
			}
			return this.ToString(0, this.tokens.Count - 1);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0002F358 File Offset: 0x0002D558
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(int start, int stop)
		{
			if (start < 0 || stop < 0)
			{
				return null;
			}
			if (this.p == -1)
			{
				throw new global::System.InvalidOperationException("Buffer is not yet filled.");
			}
			if (stop >= this.tokens.Count)
			{
				stop = this.tokens.Count - 1;
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			for (int i = start; i <= stop; i++)
			{
				global::Antlr.Runtime.IToken token = this.tokens[i];
				stringBuilder.Append(token.Text);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0002F3E8 File Offset: 0x0002D5E8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop)
		{
			if (start != null && stop != null)
			{
				return this.ToString(start.TokenIndex, stop.TokenIndex);
			}
			return null;
		}

		// Token: 0x0400038A RID: 906
		[global::System.NonSerialized]
		private global::Antlr.Runtime.ITokenSource _tokenSource;

		// Token: 0x0400038B RID: 907
		protected global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> tokens;

		// Token: 0x0400038C RID: 908
		protected global::System.Collections.Generic.IDictionary<int, int> channelOverrideMap;

		// Token: 0x0400038D RID: 909
		protected global::System.Collections.Generic.HashSet<int> discardSet;

		// Token: 0x0400038E RID: 910
		protected int channel;

		// Token: 0x0400038F RID: 911
		protected bool discardOffChannelTokens;

		// Token: 0x04000390 RID: 912
		protected int lastMarker;

		// Token: 0x04000391 RID: 913
		protected int p = -1;

		// Token: 0x04000392 RID: 914
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <Range>k__BackingField;
	}
}
