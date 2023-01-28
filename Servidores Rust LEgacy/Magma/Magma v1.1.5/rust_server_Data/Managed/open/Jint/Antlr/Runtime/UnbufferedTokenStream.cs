using System;
using System.Runtime.InteropServices;
using Antlr.Runtime.Misc;

namespace Antlr.Runtime
{
	// Token: 0x020000DC RID: 220
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class UnbufferedTokenStream : global::Antlr.Runtime.Misc.LookaheadStream<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.ITokenStream, global::Antlr.Runtime.IIntStream
	{
		// Token: 0x06000A10 RID: 2576 RVA: 0x00035800 File Offset: 0x00033A00
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnbufferedTokenStream(global::Antlr.Runtime.ITokenSource tokenSource)
		{
			this.tokenSource = tokenSource;
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x00035810 File Offset: 0x00033A10
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.ITokenSource TokenSource
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.tokenSource;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000A12 RID: 2578 RVA: 0x00035818 File Offset: 0x00033A18
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.TokenSource.SourceName;
			}
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00035828 File Offset: 0x00033A28
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.IToken NextElement()
		{
			global::Antlr.Runtime.IToken token = this.tokenSource.NextToken();
			token.TokenIndex = this.tokenIndex++;
			return token;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00035860 File Offset: 0x00033A60
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override bool IsEndOfFile(global::Antlr.Runtime.IToken o)
		{
			return o.Type == -1;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0003586C File Offset: 0x00033A6C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IToken Get(int i)
		{
			throw new global::System.NotSupportedException("Absolute token indexes are meaningless in an unbuffered stream");
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00035878 File Offset: 0x00033A78
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int LA(int i)
		{
			return this.LT(i).Type;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00035888 File Offset: 0x00033A88
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string ToString(int start, int stop)
		{
			return "n/a";
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00035890 File Offset: 0x00033A90
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string ToString(global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop)
		{
			return "n/a";
		}

		// Token: 0x0400042E RID: 1070
		[global::System.CLSCompliant(false)]
		protected global::Antlr.Runtime.ITokenSource tokenSource;

		// Token: 0x0400042F RID: 1071
		protected int tokenIndex;

		// Token: 0x04000430 RID: 1072
		protected int channel;
	}
}
