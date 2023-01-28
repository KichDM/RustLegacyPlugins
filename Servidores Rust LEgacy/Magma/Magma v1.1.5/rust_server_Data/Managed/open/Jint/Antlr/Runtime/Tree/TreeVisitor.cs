using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000DA RID: 218
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeVisitor
	{
		// Token: 0x060009F5 RID: 2549 RVA: 0x00035210 File Offset: 0x00033410
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeVisitor(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			this.adaptor = adaptor;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00035220 File Offset: 0x00033420
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeVisitor() : this(new global::Antlr.Runtime.Tree.CommonTreeAdaptor())
		{
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00035230 File Offset: 0x00033430
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Visit(object t, global::Antlr.Runtime.Tree.ITreeVisitorAction action)
		{
			bool flag = this.adaptor.IsNil(t);
			if (action != null && !flag)
			{
				t = action.Pre(t);
			}
			for (int i = 0; i < this.adaptor.GetChildCount(t); i++)
			{
				object child = this.adaptor.GetChild(t, i);
				this.Visit(child, action);
			}
			if (action != null && !flag)
			{
				t = action.Post(t);
			}
			return t;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x000352AC File Offset: 0x000334AC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Visit(object t, global::System.Func<object, object> preAction, global::System.Func<object, object> postAction)
		{
			return this.Visit(t, new global::Antlr.Runtime.Tree.TreeVisitorAction(preAction, postAction));
		}

		// Token: 0x0400042B RID: 1067
		protected global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;
	}
}
