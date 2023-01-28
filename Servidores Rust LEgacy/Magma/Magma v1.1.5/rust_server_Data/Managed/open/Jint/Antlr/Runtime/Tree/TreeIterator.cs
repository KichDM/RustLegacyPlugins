using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D5 RID: 213
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeIterator : global::System.Collections.Generic.IEnumerator<object>, global::System.IDisposable, global::System.Collections.IEnumerator
	{
		// Token: 0x060009D4 RID: 2516 RVA: 0x000346C4 File Offset: 0x000328C4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeIterator(object tree) : this(new global::Antlr.Runtime.Tree.CommonTreeAdaptor(), tree)
		{
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000346D4 File Offset: 0x000328D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeIterator(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, object tree)
		{
			this.adaptor = adaptor;
			this.tree = tree;
			this.root = tree;
			this.nodes = new global::System.Collections.Generic.Queue<object>();
			this.down = adaptor.Create(2, "DOWN");
			this.up = adaptor.Create(3, "UP");
			this.eof = adaptor.Create(-1, "EOF");
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x00034748 File Offset: 0x00032948
		// (set) Token: 0x060009D7 RID: 2519 RVA: 0x00034750 File Offset: 0x00032950
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Current
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.<Current>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<Current>k__BackingField = value;
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0003475C File Offset: 0x0003295C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Dispose()
		{
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00034760 File Offset: 0x00032960
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool MoveNext()
		{
			if (this.firstTime)
			{
				this.firstTime = false;
				if (this.adaptor.GetChildCount(this.tree) == 0)
				{
					this.nodes.Enqueue(this.eof);
				}
				this.Current = this.tree;
			}
			else if (this.nodes != null && this.nodes.Count > 0)
			{
				this.Current = this.nodes.Dequeue();
			}
			else if (this.tree == null)
			{
				this.Current = this.eof;
			}
			else if (this.adaptor.GetChildCount(this.tree) > 0)
			{
				this.tree = this.adaptor.GetChild(this.tree, 0);
				this.nodes.Enqueue(this.tree);
				this.Current = this.down;
			}
			else
			{
				object parent = this.adaptor.GetParent(this.tree);
				while (parent != null && this.adaptor.GetChildIndex(this.tree) + 1 >= this.adaptor.GetChildCount(parent))
				{
					this.nodes.Enqueue(this.up);
					this.tree = parent;
					parent = this.adaptor.GetParent(this.tree);
				}
				if (parent == null)
				{
					this.tree = null;
					this.nodes.Enqueue(this.eof);
					this.Current = this.nodes.Dequeue();
				}
				else
				{
					int i = this.adaptor.GetChildIndex(this.tree) + 1;
					this.tree = this.adaptor.GetChild(parent, i);
					this.nodes.Enqueue(this.tree);
					this.Current = this.nodes.Dequeue();
				}
			}
			return this.Current != this.eof;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00034950 File Offset: 0x00032B50
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Reset()
		{
			this.firstTime = true;
			this.tree = this.root;
			this.nodes.Clear();
		}

		// Token: 0x0400040B RID: 1035
		protected global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;

		// Token: 0x0400040C RID: 1036
		protected object root;

		// Token: 0x0400040D RID: 1037
		protected object tree;

		// Token: 0x0400040E RID: 1038
		protected bool firstTime = true;

		// Token: 0x0400040F RID: 1039
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object up;

		// Token: 0x04000410 RID: 1040
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object down;

		// Token: 0x04000411 RID: 1041
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object eof;

		// Token: 0x04000412 RID: 1042
		protected global::System.Collections.Generic.Queue<object> nodes;

		// Token: 0x04000413 RID: 1043
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object <Current>k__BackingField;
	}
}
