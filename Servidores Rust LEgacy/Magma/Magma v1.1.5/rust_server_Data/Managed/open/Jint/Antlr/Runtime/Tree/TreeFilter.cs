using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D4 RID: 212
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeFilter : global::Antlr.Runtime.Tree.TreeParser
	{
		// Token: 0x060009CC RID: 2508 RVA: 0x000345A0 File Offset: 0x000327A0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeFilter(global::Antlr.Runtime.Tree.ITreeNodeStream input) : this(input, new global::Antlr.Runtime.RecognizerSharedState())
		{
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x000345B0 File Offset: 0x000327B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeFilter(global::Antlr.Runtime.Tree.ITreeNodeStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(input, state)
		{
			this.originalAdaptor = input.TreeAdaptor;
			this.originalTokenStream = input.TokenStream;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x000345D4 File Offset: 0x000327D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ApplyOnce(object t, global::System.Action whichRule)
		{
			if (t == null)
			{
				return;
			}
			try
			{
				this.state = new global::Antlr.Runtime.RecognizerSharedState();
				this.input = new global::Antlr.Runtime.Tree.CommonTreeNodeStream(this.originalAdaptor, t);
				((global::Antlr.Runtime.Tree.CommonTreeNodeStream)this.input).TokenStream = this.originalTokenStream;
				this.BacktrackingLevel = 1;
				whichRule();
				this.BacktrackingLevel = 0;
			}
			catch (global::Antlr.Runtime.RecognitionException)
			{
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0003464C File Offset: 0x0003284C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Downup(object t)
		{
			global::Antlr.Runtime.Tree.TreeVisitor treeVisitor = new global::Antlr.Runtime.Tree.TreeVisitor(new global::Antlr.Runtime.Tree.CommonTreeAdaptor());
			global::System.Func<object, object> preAction = delegate(object o)
			{
				this.ApplyOnce(o, new global::System.Action(this.Topdown));
				return o;
			};
			global::System.Func<object, object> postAction = delegate(object o)
			{
				this.ApplyOnce(o, new global::System.Action(this.Bottomup));
				return o;
			};
			treeVisitor.Visit(t, preAction, postAction);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0003468C File Offset: 0x0003288C
		protected virtual void Topdown()
		{
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00034690 File Offset: 0x00032890
		protected virtual void Bottomup()
		{
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00034694 File Offset: 0x00032894
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object <Downup>b__0(object o)
		{
			this.ApplyOnce(o, new global::System.Action(this.Topdown));
			return o;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x000346AC File Offset: 0x000328AC
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object <Downup>b__1(object o)
		{
			this.ApplyOnce(o, new global::System.Action(this.Bottomup));
			return o;
		}

		// Token: 0x04000409 RID: 1033
		protected global::Antlr.Runtime.ITokenStream originalTokenStream;

		// Token: 0x0400040A RID: 1034
		protected global::Antlr.Runtime.Tree.ITreeAdaptor originalAdaptor;
	}
}
