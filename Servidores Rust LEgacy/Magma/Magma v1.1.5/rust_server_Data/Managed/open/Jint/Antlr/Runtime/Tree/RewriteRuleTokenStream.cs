using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D1 RID: 209
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RewriteRuleTokenStream : global::Antlr.Runtime.Tree.RewriteRuleElementStream
	{
		// Token: 0x060009B5 RID: 2485 RVA: 0x00034278 File Offset: 0x00032478
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleTokenStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription) : base(adaptor, elementDescription)
		{
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00034284 File Offset: 0x00032484
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleTokenStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, object oneElement) : base(adaptor, elementDescription, oneElement)
		{
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x00034290 File Offset: 0x00032490
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleTokenStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, global::System.Collections.IList elements) : base(adaptor, elementDescription, elements)
		{
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x0003429C File Offset: 0x0003249C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object NextNode()
		{
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.NextCore();
			return this.adaptor.Create(payload);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x000342C8 File Offset: 0x000324C8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken NextToken()
		{
			return (global::Antlr.Runtime.IToken)this.NextCore();
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x000342D8 File Offset: 0x000324D8
		protected override object ToTree(object el)
		{
			return el;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x000342DC File Offset: 0x000324DC
		protected override object Dup(object el)
		{
			throw new global::System.NotSupportedException("dup can't be called for a token stream.");
		}
	}
}
