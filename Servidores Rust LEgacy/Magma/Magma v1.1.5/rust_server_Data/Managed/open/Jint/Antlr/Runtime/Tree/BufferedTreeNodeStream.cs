using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C2 RID: 194
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class BufferedTreeNodeStream : global::Antlr.Runtime.Tree.ITreeNodeStream, global::Antlr.Runtime.IIntStream, global::Antlr.Runtime.ITokenStreamInformation
	{
		// Token: 0x06000911 RID: 2321 RVA: 0x000327CC File Offset: 0x000309CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BufferedTreeNodeStream(object tree) : this(new global::Antlr.Runtime.Tree.CommonTreeAdaptor(), tree)
		{
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x000327DC File Offset: 0x000309DC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BufferedTreeNodeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, object tree) : this(adaptor, tree, 0x64)
		{
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x000327E8 File Offset: 0x000309E8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BufferedTreeNodeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, object tree, int initialBufferSize)
		{
			this.root = tree;
			this.adaptor = adaptor;
			this.nodes = new global::System.Collections.Generic.List<object>(initialBufferSize);
			this.down = adaptor.Create(2, "DOWN");
			this.up = adaptor.Create(3, "UP");
			this.eof = adaptor.Create(-1, "EOF");
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x00032858 File Offset: 0x00030A58
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.p == -1)
				{
					throw new global::System.InvalidOperationException("Cannot determine the Count before the buffer is filled.");
				}
				return this.nodes.Count;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x0003287C File Offset: 0x00030A7C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object TreeSource
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.root;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x00032884 File Offset: 0x00030A84
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.TokenStream.SourceName;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x00032894 File Offset: 0x00030A94
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x0003289C File Offset: 0x00030A9C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.ITokenStream TokenStream
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.tokens;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.tokens = value;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x000328A8 File Offset: 0x00030AA8
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x000328B0 File Offset: 0x00030AB0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITreeAdaptor TreeAdaptor
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.adaptor;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.adaptor = value;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x000328BC File Offset: 0x00030ABC
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x000328C4 File Offset: 0x00030AC4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool UniqueNavigationNodes
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.uniqueNavigationNodes;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.uniqueNavigationNodes = value;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x000328D0 File Offset: 0x00030AD0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken LastToken
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.TreeAdaptor.GetToken(this.LB(1));
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x000328E4 File Offset: 0x00030AE4
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
					token = this.TreeAdaptor.GetToken(this.LB(num));
				}
				while (token != null && token.Line <= 0);
				return token;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00032920 File Offset: 0x00030B20
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int MaxLookBehind
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return int.MaxValue;
			}
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00032928 File Offset: 0x00030B28
		protected virtual void FillBuffer()
		{
			this.FillBuffer(this.root);
			this.p = 0;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00032940 File Offset: 0x00030B40
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void FillBuffer(object t)
		{
			bool flag = this.adaptor.IsNil(t);
			if (!flag)
			{
				this.nodes.Add(t);
			}
			int childCount = this.adaptor.GetChildCount(t);
			if (!flag && childCount > 0)
			{
				this.AddNavigationNode(2);
			}
			for (int i = 0; i < childCount; i++)
			{
				object child = this.adaptor.GetChild(t, i);
				this.FillBuffer(child);
			}
			if (!flag && childCount > 0)
			{
				this.AddNavigationNode(3);
			}
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x000329CC File Offset: 0x00030BCC
		protected virtual int GetNodeIndex(object node)
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			for (int i = 0; i < this.nodes.Count; i++)
			{
				object obj = this.nodes[i];
				if (obj == node)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00032A20 File Offset: 0x00030C20
		protected virtual void AddNavigationNode(int ttype)
		{
			object value;
			if (ttype == 2)
			{
				if (this.UniqueNavigationNodes)
				{
					value = this.adaptor.Create(2, "DOWN");
				}
				else
				{
					value = this.down;
				}
			}
			else if (this.UniqueNavigationNodes)
			{
				value = this.adaptor.Create(3, "UP");
			}
			else
			{
				value = this.up;
			}
			this.nodes.Add(value);
		}

		// Token: 0x170001C1 RID: 449
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object this[int i]
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.p == -1)
				{
					throw new global::System.InvalidOperationException("Cannot get the node at index i before the buffer is filled.");
				}
				return this.nodes[i];
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00032AC8 File Offset: 0x00030CC8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object LT(int k)
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
			if (this.p + k - 1 >= this.nodes.Count)
			{
				return this.eof;
			}
			return this.nodes[this.p + k - 1];
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00032B3C File Offset: 0x00030D3C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object GetCurrentSymbol()
		{
			return this.LT(1);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00032B48 File Offset: 0x00030D48
		protected virtual object LB(int k)
		{
			if (k == 0)
			{
				return null;
			}
			if (this.p - k < 0)
			{
				return null;
			}
			return this.nodes[this.p - k];
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00032B78 File Offset: 0x00030D78
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Consume()
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			this.p++;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00032B9C File Offset: 0x00030D9C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int LA(int i)
		{
			return this.adaptor.GetType(this.LT(i));
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00032BB0 File Offset: 0x00030DB0
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

		// Token: 0x0600092B RID: 2347 RVA: 0x00032BD8 File Offset: 0x00030DD8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Release(int marker)
		{
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x00032BDC File Offset: 0x00030DDC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Index
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.p;
			}
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00032BE4 File Offset: 0x00030DE4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind(int marker)
		{
			this.Seek(marker);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00032BF0 File Offset: 0x00030DF0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rewind()
		{
			this.Seek(this.lastMarker);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00032C00 File Offset: 0x00030E00
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Seek(int index)
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			this.p = index;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00032C1C File Offset: 0x00030E1C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Push(int index)
		{
			if (this.calls == null)
			{
				this.calls = new global::System.Collections.Generic.Stack<int>();
			}
			this.calls.Push(this.p);
			this.Seek(index);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00032C4C File Offset: 0x00030E4C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Pop()
		{
			int num = this.calls.Pop();
			this.Seek(num);
			return num;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00032C74 File Offset: 0x00030E74
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			this.p = 0;
			this.lastMarker = 0;
			if (this.calls != null)
			{
				this.calls.Clear();
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00032C9C File Offset: 0x00030E9C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IEnumerator<object> Iterator()
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			return new global::Antlr.Runtime.Tree.BufferedTreeNodeStream.StreamIterator(this);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00032CB8 File Offset: 0x00030EB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t)
		{
			if (parent != null)
			{
				this.adaptor.ReplaceChildren(parent, startChildIndex, stopChildIndex, t);
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00032CD0 File Offset: 0x00030ED0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToTokenTypeString()
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			for (int i = 0; i < this.nodes.Count; i++)
			{
				object t = this.nodes[i];
				stringBuilder.Append(" ");
				stringBuilder.Append(this.adaptor.GetType(t));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00032D44 File Offset: 0x00030F44
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToTokenString(int start, int stop)
		{
			if (this.p == -1)
			{
				this.FillBuffer();
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			int num = start;
			while (num < this.nodes.Count && num <= stop)
			{
				object t = this.nodes[num];
				stringBuilder.Append(" ");
				stringBuilder.Append(this.adaptor.GetToken(t));
				num++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00032DC0 File Offset: 0x00030FC0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(object start, object stop)
		{
			global::System.Console.Out.WriteLine("toString");
			if (start == null || stop == null)
			{
				return null;
			}
			if (this.p == -1)
			{
				throw new global::System.InvalidOperationException("Buffer is not yet filled.");
			}
			if (start is global::Antlr.Runtime.Tree.CommonTree)
			{
				global::System.Console.Out.Write("toString: " + ((global::Antlr.Runtime.Tree.CommonTree)start).Token + ", ");
			}
			else
			{
				global::System.Console.Out.WriteLine(start);
			}
			if (stop is global::Antlr.Runtime.Tree.CommonTree)
			{
				global::System.Console.Out.WriteLine(((global::Antlr.Runtime.Tree.CommonTree)stop).Token);
			}
			else
			{
				global::System.Console.Out.WriteLine(stop);
			}
			if (this.tokens != null)
			{
				int tokenStartIndex = this.adaptor.GetTokenStartIndex(start);
				int stop2 = this.adaptor.GetTokenStopIndex(stop);
				if (this.adaptor.GetType(stop) == 3)
				{
					stop2 = this.adaptor.GetTokenStopIndex(start);
				}
				else if (this.adaptor.GetType(stop) == -1)
				{
					stop2 = this.Count - 2;
				}
				return this.tokens.ToString(tokenStartIndex, stop2);
			}
			int i;
			for (i = 0; i < this.nodes.Count; i++)
			{
				object obj = this.nodes[i];
				if (obj == start)
				{
					break;
				}
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			for (object obj = this.nodes[i]; obj != stop; obj = this.nodes[i])
			{
				string text = this.adaptor.GetText(obj);
				if (text == null)
				{
					text = " " + this.adaptor.GetType(obj).ToString();
				}
				stringBuilder.Append(text);
				i++;
			}
			string text2 = this.adaptor.GetText(stop);
			if (text2 == null)
			{
				text2 = " " + this.adaptor.GetType(stop).ToString();
			}
			stringBuilder.Append(text2);
			return stringBuilder.ToString();
		}

		// Token: 0x040003D1 RID: 977
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int DEFAULT_INITIAL_BUFFER_SIZE = 0x64;

		// Token: 0x040003D2 RID: 978
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int INITIAL_CALL_STACK_SIZE = 0xA;

		// Token: 0x040003D3 RID: 979
		protected object down;

		// Token: 0x040003D4 RID: 980
		protected object up;

		// Token: 0x040003D5 RID: 981
		protected object eof;

		// Token: 0x040003D6 RID: 982
		protected global::System.Collections.IList nodes;

		// Token: 0x040003D7 RID: 983
		protected object root;

		// Token: 0x040003D8 RID: 984
		protected global::Antlr.Runtime.ITokenStream tokens;

		// Token: 0x040003D9 RID: 985
		private global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;

		// Token: 0x040003DA RID: 986
		private bool uniqueNavigationNodes;

		// Token: 0x040003DB RID: 987
		protected int p = -1;

		// Token: 0x040003DC RID: 988
		protected int lastMarker;

		// Token: 0x040003DD RID: 989
		protected global::System.Collections.Generic.Stack<int> calls;

		// Token: 0x0200015C RID: 348
		protected sealed class StreamIterator : global::System.Collections.Generic.IEnumerator<object>, global::System.IDisposable, global::System.Collections.IEnumerator
		{
			// Token: 0x06000C19 RID: 3097 RVA: 0x0003CBF8 File Offset: 0x0003ADF8
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public StreamIterator(global::Antlr.Runtime.Tree.BufferedTreeNodeStream outer)
			{
				this._outer = outer;
				this._index = -1;
			}

			// Token: 0x170002AC RID: 684
			// (get) Token: 0x06000C1A RID: 3098 RVA: 0x0003CC10 File Offset: 0x0003AE10
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object Current
			{
				[global::System.Runtime.InteropServices.ComVisible(false)]
				get
				{
					if (this._index < this._outer.nodes.Count)
					{
						return this._outer.nodes[this._index];
					}
					return this._outer.eof;
				}
			}

			// Token: 0x06000C1B RID: 3099 RVA: 0x0003CC50 File Offset: 0x0003AE50
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public void Dispose()
			{
			}

			// Token: 0x06000C1C RID: 3100 RVA: 0x0003CC54 File Offset: 0x0003AE54
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public bool MoveNext()
			{
				if (this._index < this._outer.nodes.Count)
				{
					this._index++;
				}
				return this._index < this._outer.nodes.Count;
			}

			// Token: 0x06000C1D RID: 3101 RVA: 0x0003CCA8 File Offset: 0x0003AEA8
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public void Reset()
			{
				this._index = -1;
			}

			// Token: 0x040006E9 RID: 1769
			private global::Antlr.Runtime.Tree.BufferedTreeNodeStream _outer;

			// Token: 0x040006EA RID: 1770
			private int _index;
		}
	}
}
