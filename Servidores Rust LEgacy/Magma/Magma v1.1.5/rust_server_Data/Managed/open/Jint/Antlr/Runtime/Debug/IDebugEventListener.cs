using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Debug
{
	// Token: 0x0200009D RID: 157
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface IDebugEventListener
	{
		// Token: 0x06000727 RID: 1831
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Initialize();

		// Token: 0x06000728 RID: 1832
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void EnterRule(string grammarFileName, string ruleName);

		// Token: 0x06000729 RID: 1833
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void EnterAlt(int alt);

		// Token: 0x0600072A RID: 1834
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ExitRule(string grammarFileName, string ruleName);

		// Token: 0x0600072B RID: 1835
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void EnterSubRule(int decisionNumber);

		// Token: 0x0600072C RID: 1836
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ExitSubRule(int decisionNumber);

		// Token: 0x0600072D RID: 1837
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void EnterDecision(int decisionNumber, bool couldBacktrack);

		// Token: 0x0600072E RID: 1838
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ExitDecision(int decisionNumber);

		// Token: 0x0600072F RID: 1839
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ConsumeToken(global::Antlr.Runtime.IToken t);

		// Token: 0x06000730 RID: 1840
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ConsumeHiddenToken(global::Antlr.Runtime.IToken t);

		// Token: 0x06000731 RID: 1841
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void LT(int i, global::Antlr.Runtime.IToken t);

		// Token: 0x06000732 RID: 1842
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Mark(int marker);

		// Token: 0x06000733 RID: 1843
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Rewind(int marker);

		// Token: 0x06000734 RID: 1844
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Rewind();

		// Token: 0x06000735 RID: 1845
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void BeginBacktrack(int level);

		// Token: 0x06000736 RID: 1846
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void EndBacktrack(int level, bool successful);

		// Token: 0x06000737 RID: 1847
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Location(int line, int pos);

		// Token: 0x06000738 RID: 1848
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void RecognitionException(global::Antlr.Runtime.RecognitionException e);

		// Token: 0x06000739 RID: 1849
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void BeginResync();

		// Token: 0x0600073A RID: 1850
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void EndResync();

		// Token: 0x0600073B RID: 1851
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SemanticPredicate(bool result, string predicate);

		// Token: 0x0600073C RID: 1852
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Commence();

		// Token: 0x0600073D RID: 1853
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Terminate();

		// Token: 0x0600073E RID: 1854
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ConsumeNode(object t);

		// Token: 0x0600073F RID: 1855
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void LT(int i, object t);

		// Token: 0x06000740 RID: 1856
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void NilNode(object t);

		// Token: 0x06000741 RID: 1857
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ErrorNode(object t);

		// Token: 0x06000742 RID: 1858
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void CreateNode(object t);

		// Token: 0x06000743 RID: 1859
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void CreateNode(object node, global::Antlr.Runtime.IToken token);

		// Token: 0x06000744 RID: 1860
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void BecomeRoot(object newRoot, object oldRoot);

		// Token: 0x06000745 RID: 1861
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void AddChild(object root, object child);

		// Token: 0x06000746 RID: 1862
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetTokenBoundaries(object t, int tokenStartIndex, int tokenStopIndex);
	}
}
