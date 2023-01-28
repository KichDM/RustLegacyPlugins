using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D3 RID: 211
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeParser : global::Antlr.Runtime.BaseRecognizer
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x000342FC File Offset: 0x000324FC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeParser(global::Antlr.Runtime.Tree.ITreeNodeStream input)
		{
			this.SetTreeNodeStream(input);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0003430C File Offset: 0x0003250C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeParser(global::Antlr.Runtime.Tree.ITreeNodeStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(state)
		{
			this.SetTreeNodeStream(input);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0003431C File Offset: 0x0003251C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void Reset()
		{
			base.Reset();
			if (this.input != null)
			{
				this.input.Seek(0);
			}
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0003433C File Offset: 0x0003253C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetTreeNodeStream(global::Antlr.Runtime.Tree.ITreeNodeStream input)
		{
			this.input = input;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00034348 File Offset: 0x00032548
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITreeNodeStream GetTreeNodeStream()
		{
			return this.input;
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00034350 File Offset: 0x00032550
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input.SourceName;
			}
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00034360 File Offset: 0x00032560
		protected override object GetCurrentInputSymbol(global::Antlr.Runtime.IIntStream input)
		{
			return ((global::Antlr.Runtime.Tree.ITreeNodeStream)input).LT(1);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00034370 File Offset: 0x00032570
		protected override object GetMissingSymbol(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.RecognitionException e, int expectedTokenType, global::Antlr.Runtime.BitSet follow)
		{
			string text = "<missing " + this.TokenNames[expectedTokenType] + ">";
			global::Antlr.Runtime.Tree.ITreeAdaptor treeAdaptor = ((global::Antlr.Runtime.Tree.ITreeNodeStream)e.Input).TreeAdaptor;
			return treeAdaptor.Create(new global::Antlr.Runtime.CommonToken(expectedTokenType, text));
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x000343BC File Offset: 0x000325BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void MatchAny(global::Antlr.Runtime.IIntStream ignore)
		{
			this.state.errorRecovery = false;
			this.state.failed = false;
			this.input.Consume();
			int num = this.input.LA(1);
			if (num == 2)
			{
				this.input.Consume();
				int i = 1;
				while (i > 0)
				{
					switch (this.input.LA(1))
					{
					case -1:
						return;
					case 2:
						i++;
						break;
					case 3:
						i--;
						break;
					}
					this.input.Consume();
				}
			}
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00034468 File Offset: 0x00032668
		protected override object RecoverFromMismatchedToken(global::Antlr.Runtime.IIntStream input, int ttype, global::Antlr.Runtime.BitSet follow)
		{
			throw new global::Antlr.Runtime.MismatchedTreeNodeException(ttype, (global::Antlr.Runtime.Tree.ITreeNodeStream)input);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00034478 File Offset: 0x00032678
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string GetErrorHeader(global::Antlr.Runtime.RecognitionException e)
		{
			return string.Concat(new object[]
			{
				this.GrammarFileName,
				": node from ",
				e.ApproximateLineInfo ? "after " : "",
				"line ",
				e.Line,
				":",
				e.CharPositionInLine
			});
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x000344F0 File Offset: 0x000326F0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string GetErrorMessage(global::Antlr.Runtime.RecognitionException e, string[] tokenNames)
		{
			if (this != null)
			{
				global::Antlr.Runtime.Tree.ITreeAdaptor treeAdaptor = ((global::Antlr.Runtime.Tree.ITreeNodeStream)e.Input).TreeAdaptor;
				e.Token = treeAdaptor.GetToken(e.Node);
				if (e.Token == null)
				{
					e.Token = new global::Antlr.Runtime.CommonToken(treeAdaptor.GetType(e.Node), treeAdaptor.GetText(e.Node));
				}
			}
			return base.GetErrorMessage(e, tokenNames);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x00034560 File Offset: 0x00032760
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceIn(string ruleName, int ruleIndex)
		{
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00034564 File Offset: 0x00032764
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceOut(string ruleName, int ruleIndex)
		{
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x00034568 File Offset: 0x00032768
		// Note: this type is marked as 'beforefieldinit'.
		static TreeParser()
		{
		}

		// Token: 0x04000402 RID: 1026
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int DOWN = 2;

		// Token: 0x04000403 RID: 1027
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int UP = 3;

		// Token: 0x04000404 RID: 1028
		private static string dotdot = ".*[^.]\\.\\.[^.].*";

		// Token: 0x04000405 RID: 1029
		private static string doubleEtc = ".*\\.\\.\\.\\s+\\.\\.\\..*";

		// Token: 0x04000406 RID: 1030
		private static global::System.Text.RegularExpressions.Regex dotdotPattern = new global::System.Text.RegularExpressions.Regex(global::Antlr.Runtime.Tree.TreeParser.dotdot, global::System.Text.RegularExpressions.RegexOptions.Compiled);

		// Token: 0x04000407 RID: 1031
		private static global::System.Text.RegularExpressions.Regex doubleEtcPattern = new global::System.Text.RegularExpressions.Regex(global::Antlr.Runtime.Tree.TreeParser.doubleEtc, global::System.Text.RegularExpressions.RegexOptions.Compiled);

		// Token: 0x04000408 RID: 1032
		protected global::Antlr.Runtime.Tree.ITreeNodeStream input;
	}
}
