using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C5 RID: 197
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class CommonTreeAdaptor : global::Antlr.Runtime.Tree.BaseTreeAdaptor
	{
		// Token: 0x06000958 RID: 2392 RVA: 0x000335D0 File Offset: 0x000317D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override object Create(global::Antlr.Runtime.IToken payload)
		{
			return new global::Antlr.Runtime.Tree.CommonTree(payload);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000335D8 File Offset: 0x000317D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.IToken CreateToken(int tokenType, string text)
		{
			return new global::Antlr.Runtime.CommonToken(tokenType, text);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x000335E4 File Offset: 0x000317E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.IToken CreateToken(global::Antlr.Runtime.IToken fromToken)
		{
			return new global::Antlr.Runtime.CommonToken(fromToken);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x000335EC File Offset: 0x000317EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.IToken GetToken(object t)
		{
			if (t is global::Antlr.Runtime.Tree.CommonTree)
			{
				return ((global::Antlr.Runtime.Tree.CommonTree)t).Token;
			}
			return null;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00033608 File Offset: 0x00031808
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTreeAdaptor()
		{
		}
	}
}
