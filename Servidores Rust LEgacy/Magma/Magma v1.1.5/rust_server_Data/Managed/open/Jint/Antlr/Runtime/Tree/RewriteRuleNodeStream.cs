using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000CF RID: 207
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RewriteRuleNodeStream : global::Antlr.Runtime.Tree.RewriteRuleElementStream
	{
		// Token: 0x060009AA RID: 2474 RVA: 0x00034168 File Offset: 0x00032368
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleNodeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription) : base(adaptor, elementDescription)
		{
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00034174 File Offset: 0x00032374
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleNodeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, object oneElement) : base(adaptor, elementDescription, oneElement)
		{
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x00034180 File Offset: 0x00032380
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleNodeStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, global::System.Collections.IList elements) : base(adaptor, elementDescription, elements)
		{
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0003418C File Offset: 0x0003238C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object NextNode()
		{
			return this.NextCore();
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00034194 File Offset: 0x00032394
		protected override object ToTree(object el)
		{
			return this.adaptor.DupNode(el);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000341A4 File Offset: 0x000323A4
		protected override object Dup(object el)
		{
			throw new global::System.NotSupportedException("dup can't be called for a node stream.");
		}
	}
}
