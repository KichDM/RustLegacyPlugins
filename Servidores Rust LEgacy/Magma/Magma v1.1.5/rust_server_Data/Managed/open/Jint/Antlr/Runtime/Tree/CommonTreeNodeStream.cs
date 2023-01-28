using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Antlr.Runtime.Misc;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C6 RID: 198
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class CommonTreeNodeStream : global::Antlr.Runtime.Misc.LookaheadStream<object>, global::Antlr.Runtime.Tree.ITreeNodeStream, global::Antlr.Runtime.IIntStream
	{
		// Token: 0x0600095D RID: 2397 RVA: 0x00033610 File Offset: 0x00031810
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTreeNodeStream(object tree) : this(new global::Antlr.Runtime.Tree.CommonTreeAdaptor(), tree)
		{
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00033620 File Offset: 0x00031820
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTreeNodeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, object tree)
		{
			this._root = tree;
			this._adaptor = adaptor;
			this._it = new global::Antlr.Runtime.Tree.TreeIterator(adaptor, this._root);
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x00033648 File Offset: 0x00031848
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.TokenStream == null)
				{
					return null;
				}
				return this.TokenStream.SourceName;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00033664 File Offset: 0x00031864
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x0003366C File Offset: 0x0003186C
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

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x00033678 File Offset: 0x00031878
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x00033680 File Offset: 0x00031880
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITreeAdaptor TreeAdaptor
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._adaptor;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._adaptor = value;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0003368C File Offset: 0x0003188C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object TreeSource
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._root;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x00033694 File Offset: 0x00031894
		// (set) Token: 0x06000966 RID: 2406 RVA: 0x00033698 File Offset: 0x00031898
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool UniqueNavigationNodes
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return false;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0003369C File Offset: 0x0003189C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			base.Clear();
			this._it.Reset();
			this._hasNilRoot = false;
			this._level = 0;
			if (this._calls != null)
			{
				this._calls.Clear();
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x000336D4 File Offset: 0x000318D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override object NextElement()
		{
			this._it.MoveNext();
			object obj = this._it.Current;
			if (obj == this._it.up)
			{
				this._level--;
				if (this._level == 0 && this._hasNilRoot)
				{
					this._it.MoveNext();
					return this._it.Current;
				}
			}
			else if (obj == this._it.down)
			{
				this._level++;
			}
			if (this._level == 0 && this.TreeAdaptor.IsNil(obj))
			{
				this._hasNilRoot = true;
				this._it.MoveNext();
				obj = this._it.Current;
				this._level++;
				this._it.MoveNext();
				obj = this._it.Current;
			}
			return obj;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x000337CC File Offset: 0x000319CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override bool IsEndOfFile(object o)
		{
			return this.TreeAdaptor.GetType(o) == -1;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x000337E0 File Offset: 0x000319E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int LA(int i)
		{
			return this.TreeAdaptor.GetType(this.LT(i));
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000337F4 File Offset: 0x000319F4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Push(int index)
		{
			if (this._calls == null)
			{
				this._calls = new global::System.Collections.Generic.Stack<int>();
			}
			this._calls.Push(this._p);
			this.Seek(index);
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00033824 File Offset: 0x00031A24
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Pop()
		{
			int num = this._calls.Pop();
			this.Seek(num);
			return num;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0003384C File Offset: 0x00031A4C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t)
		{
			if (parent != null)
			{
				this.TreeAdaptor.ReplaceChildren(parent, startChildIndex, stopChildIndex, t);
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00033864 File Offset: 0x00031A64
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(object start, object stop)
		{
			return "n/a";
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0003386C File Offset: 0x00031A6C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToTokenTypeString()
		{
			this.Reset();
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			object t = this.LT(1);
			for (int type = this.TreeAdaptor.GetType(t); type != -1; type = this.TreeAdaptor.GetType(t))
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(type);
				this.Consume();
				t = this.LT(1);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040003E7 RID: 999
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int DEFAULT_INITIAL_BUFFER_SIZE = 0x64;

		// Token: 0x040003E8 RID: 1000
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int INITIAL_CALL_STACK_SIZE = 0xA;

		// Token: 0x040003E9 RID: 1001
		private object _root;

		// Token: 0x040003EA RID: 1002
		protected global::Antlr.Runtime.ITokenStream tokens;

		// Token: 0x040003EB RID: 1003
		[global::System.NonSerialized]
		private global::Antlr.Runtime.Tree.ITreeAdaptor _adaptor;

		// Token: 0x040003EC RID: 1004
		private global::Antlr.Runtime.Tree.TreeIterator _it;

		// Token: 0x040003ED RID: 1005
		private global::System.Collections.Generic.Stack<int> _calls;

		// Token: 0x040003EE RID: 1006
		private bool _hasNilRoot;

		// Token: 0x040003EF RID: 1007
		private int _level;
	}
}
