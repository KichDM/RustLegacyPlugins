using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D8 RID: 216
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeRewriter : global::Antlr.Runtime.Tree.TreeParser
	{
		// Token: 0x060009E2 RID: 2530 RVA: 0x00034F28 File Offset: 0x00033128
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeRewriter(global::Antlr.Runtime.Tree.ITreeNodeStream input) : this(input, new global::Antlr.Runtime.RecognizerSharedState())
		{
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00034F38 File Offset: 0x00033138
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeRewriter(global::Antlr.Runtime.Tree.ITreeNodeStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(input, state)
		{
			this.originalAdaptor = input.TreeAdaptor;
			this.originalTokenStream = input.TokenStream;
			this.topdown_func = (() => this.Topdown());
			this.bottomup_func = (() => this.Bottomup());
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00034FA4 File Offset: 0x000331A4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object ApplyOnce(object t, global::System.Func<global::Antlr.Runtime.IAstRuleReturnScope> whichRule)
		{
			if (t == null)
			{
				return null;
			}
			try
			{
				this.state = new global::Antlr.Runtime.RecognizerSharedState();
				this.input = new global::Antlr.Runtime.Tree.CommonTreeNodeStream(this.originalAdaptor, t);
				((global::Antlr.Runtime.Tree.CommonTreeNodeStream)this.input).TokenStream = this.originalTokenStream;
				this.BacktrackingLevel = 1;
				global::Antlr.Runtime.IAstRuleReturnScope astRuleReturnScope = whichRule();
				this.BacktrackingLevel = 0;
				if (this.Failed)
				{
					return t;
				}
				if (this.showTransformations && astRuleReturnScope != null && !t.Equals(astRuleReturnScope.Tree) && astRuleReturnScope.Tree != null)
				{
					this.ReportTransformation(t, astRuleReturnScope.Tree);
				}
				if (astRuleReturnScope != null && astRuleReturnScope.Tree != null)
				{
					return astRuleReturnScope.Tree;
				}
				return t;
			}
			catch (global::Antlr.Runtime.RecognitionException)
			{
			}
			return t;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0003508C File Offset: 0x0003328C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object ApplyRepeatedly(object t, global::System.Func<global::Antlr.Runtime.IAstRuleReturnScope> whichRule)
		{
			bool flag = true;
			while (flag)
			{
				object obj = this.ApplyOnce(t, whichRule);
				flag = !t.Equals(obj);
				t = obj;
			}
			return t;
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x000350C0 File Offset: 0x000332C0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Downup(object t)
		{
			return this.Downup(t, false);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x000350CC File Offset: 0x000332CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Downup(object t, bool showTransformations)
		{
			this.showTransformations = showTransformations;
			global::Antlr.Runtime.Tree.TreeVisitor treeVisitor = new global::Antlr.Runtime.Tree.TreeVisitor(new global::Antlr.Runtime.Tree.CommonTreeAdaptor());
			t = treeVisitor.Visit(t, (object o) => this.ApplyOnce(o, this.topdown_func), (object o) => this.ApplyRepeatedly(o, this.bottomup_func));
			return t;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00035114 File Offset: 0x00033314
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IAstRuleReturnScope Topdown()
		{
			return null;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00035118 File Offset: 0x00033318
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IAstRuleReturnScope Bottomup()
		{
			return null;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0003511C File Offset: 0x0003331C
		protected virtual void ReportTransformation(object oldTree, object newTree)
		{
			global::Antlr.Runtime.Tree.ITree tree = oldTree as global::Antlr.Runtime.Tree.ITree;
			global::Antlr.Runtime.Tree.ITree tree2 = newTree as global::Antlr.Runtime.Tree.ITree;
			string arg = (tree != null) ? tree.ToStringTree() : "??";
			string arg2 = (tree2 != null) ? tree2.ToStringTree() : "??";
			global::System.Console.WriteLine("{0} -> {1}", arg, arg2);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00035178 File Offset: 0x00033378
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Antlr.Runtime.IAstRuleReturnScope <.ctor>b__0()
		{
			return this.Topdown();
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00035180 File Offset: 0x00033380
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Antlr.Runtime.IAstRuleReturnScope <.ctor>b__1()
		{
			return this.Bottomup();
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00035188 File Offset: 0x00033388
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object <Downup>b__4(object o)
		{
			return this.ApplyOnce(o, this.topdown_func);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x00035198 File Offset: 0x00033398
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object <Downup>b__5(object o)
		{
			return this.ApplyRepeatedly(o, this.bottomup_func);
		}

		// Token: 0x04000425 RID: 1061
		protected bool showTransformations;

		// Token: 0x04000426 RID: 1062
		protected global::Antlr.Runtime.ITokenStream originalTokenStream;

		// Token: 0x04000427 RID: 1063
		protected global::Antlr.Runtime.Tree.ITreeAdaptor originalAdaptor;

		// Token: 0x04000428 RID: 1064
		private global::System.Func<global::Antlr.Runtime.IAstRuleReturnScope> topdown_func;

		// Token: 0x04000429 RID: 1065
		private global::System.Func<global::Antlr.Runtime.IAstRuleReturnScope> bottomup_func;
	}
}
