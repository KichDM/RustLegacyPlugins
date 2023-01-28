using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000B3 RID: 179
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class Parser : global::Antlr.Runtime.BaseRecognizer
	{
		// Token: 0x06000835 RID: 2101 RVA: 0x00030A38 File Offset: 0x0002EC38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public Parser(global::Antlr.Runtime.ITokenStream input)
		{
			this.TokenStream = input;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00030A48 File Offset: 0x0002EC48
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public Parser(global::Antlr.Runtime.ITokenStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(state)
		{
			this.input = input;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00030A58 File Offset: 0x0002EC58
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void Reset()
		{
			base.Reset();
			if (this.input != null)
			{
				this.input.Seek(0);
			}
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00030A78 File Offset: 0x0002EC78
		protected override object GetCurrentInputSymbol(global::Antlr.Runtime.IIntStream input)
		{
			return ((global::Antlr.Runtime.ITokenStream)input).LT(1);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x00030A88 File Offset: 0x0002EC88
		protected override object GetMissingSymbol(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.RecognitionException e, int expectedTokenType, global::Antlr.Runtime.BitSet follow)
		{
			string text;
			if (expectedTokenType == -1)
			{
				text = "<missing EOF>";
			}
			else
			{
				text = "<missing " + this.TokenNames[expectedTokenType] + ">";
			}
			global::Antlr.Runtime.CommonToken commonToken = new global::Antlr.Runtime.CommonToken(expectedTokenType, text);
			global::Antlr.Runtime.IToken token = ((global::Antlr.Runtime.ITokenStream)input).LT(1);
			if (token.Type == -1)
			{
				token = ((global::Antlr.Runtime.ITokenStream)input).LT(-1);
			}
			commonToken.Line = token.Line;
			commonToken.CharPositionInLine = token.CharPositionInLine;
			commonToken.Channel = 0;
			return commonToken;
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x00030B18 File Offset: 0x0002ED18
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x00030B20 File Offset: 0x0002ED20
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.ITokenStream TokenStream
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.input = null;
				this.Reset();
				this.input = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x00030B38 File Offset: 0x0002ED38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input.SourceName;
			}
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00030B48 File Offset: 0x0002ED48
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceIn(string ruleName, int ruleIndex)
		{
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00030B4C File Offset: 0x0002ED4C
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceOut(string ruleName, int ruleIndex)
		{
		}

		// Token: 0x040003A6 RID: 934
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.ITokenStream input;
	}
}
