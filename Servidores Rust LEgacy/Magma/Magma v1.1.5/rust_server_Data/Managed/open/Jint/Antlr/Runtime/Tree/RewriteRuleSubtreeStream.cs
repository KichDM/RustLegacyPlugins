using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D0 RID: 208
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RewriteRuleSubtreeStream : global::Antlr.Runtime.Tree.RewriteRuleElementStream
	{
		// Token: 0x060009B0 RID: 2480 RVA: 0x000341B0 File Offset: 0x000323B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleSubtreeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription) : base(adaptor, elementDescription)
		{
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x000341BC File Offset: 0x000323BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleSubtreeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, object oneElement) : base(adaptor, elementDescription, oneElement)
		{
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x000341C8 File Offset: 0x000323C8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleSubtreeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, global::System.Collections.IList elements) : base(adaptor, elementDescription, elements)
		{
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x000341D4 File Offset: 0x000323D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object NextNode()
		{
			int count = this.Count;
			if (this.dirty || (this.cursor >= count && count == 1))
			{
				object treeNode = this.NextCore();
				return this.adaptor.DupNode(treeNode);
			}
			object obj = this.NextCore();
			while (this.adaptor.IsNil(obj) && this.adaptor.GetChildCount(obj) == 1)
			{
				obj = this.adaptor.GetChild(obj, 0);
			}
			return this.adaptor.DupNode(obj);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00034268 File Offset: 0x00032468
		protected override object Dup(object el)
		{
			return this.adaptor.DupTree(el);
		}
	}
}
