using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Antlr.Runtime.Debug;

namespace Antlr.Runtime
{
	// Token: 0x02000092 RID: 146
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public abstract class BaseRecognizer
	{
		// Token: 0x06000655 RID: 1621 RVA: 0x0002BBF4 File Offset: 0x00029DF4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BaseRecognizer() : this(new global::Antlr.Runtime.RecognizerSharedState())
		{
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0002BC04 File Offset: 0x00029E04
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BaseRecognizer(global::Antlr.Runtime.RecognizerSharedState state)
		{
			if (state == null)
			{
				state = new global::Antlr.Runtime.RecognizerSharedState();
			}
			this.state = state;
			this.InitDFAs();
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x0002BC28 File Offset: 0x00029E28
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x0002BC30 File Offset: 0x00029E30
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::System.IO.TextWriter TraceDestination
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.<TraceDestination>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.<TraceDestination>k__BackingField = value;
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0002BC3C File Offset: 0x00029E3C
		protected virtual void InitDFAs()
		{
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0002BC40 File Offset: 0x00029E40
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			if (this.state == null)
			{
				return;
			}
			this.state._fsp = -1;
			this.state.errorRecovery = false;
			this.state.lastErrorIndex = -1;
			this.state.failed = false;
			this.state.syntaxErrors = 0;
			this.state.backtracking = 0;
			int num = 0;
			while (this.state.ruleMemo != null && num < this.state.ruleMemo.Length)
			{
				this.state.ruleMemo[num] = null;
				num++;
			}
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0002BCE4 File Offset: 0x00029EE4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Match(global::Antlr.Runtime.IIntStream input, int ttype, global::Antlr.Runtime.BitSet follow)
		{
			object currentInputSymbol = this.GetCurrentInputSymbol(input);
			if (input.LA(1) == ttype)
			{
				input.Consume();
				this.state.errorRecovery = false;
				this.state.failed = false;
				return currentInputSymbol;
			}
			if (this.state.backtracking > 0)
			{
				this.state.failed = true;
				return currentInputSymbol;
			}
			return this.RecoverFromMismatchedToken(input, ttype, follow);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0002BD54 File Offset: 0x00029F54
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void MatchAny(global::Antlr.Runtime.IIntStream input)
		{
			this.state.errorRecovery = false;
			this.state.failed = false;
			input.Consume();
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0002BD74 File Offset: 0x00029F74
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool MismatchIsUnwantedToken(global::Antlr.Runtime.IIntStream input, int ttype)
		{
			return input.LA(2) == ttype;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0002BD80 File Offset: 0x00029F80
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool MismatchIsMissingToken(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.BitSet follow)
		{
			if (follow == null)
			{
				return false;
			}
			if (follow.Member(1))
			{
				global::Antlr.Runtime.BitSet a = this.ComputeContextSensitiveRuleFOLLOW();
				follow = follow.Or(a);
				if (this.state._fsp >= 0)
				{
					follow.Remove(1);
				}
			}
			return follow.Member(input.LA(1)) || follow.Member(1);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0002BDF0 File Offset: 0x00029FF0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ReportError(global::Antlr.Runtime.RecognitionException e)
		{
			if (this.state.errorRecovery)
			{
				return;
			}
			this.state.syntaxErrors++;
			this.state.errorRecovery = true;
			this.DisplayRecognitionError(this.TokenNames, e);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0002BE30 File Offset: 0x0002A030
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void DisplayRecognitionError(string[] tokenNames, global::Antlr.Runtime.RecognitionException e)
		{
			string errorHeader = this.GetErrorHeader(e);
			string errorMessage = this.GetErrorMessage(e, tokenNames);
			this.EmitErrorMessage(errorHeader + " " + errorMessage);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0002BE64 File Offset: 0x0002A064
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string GetErrorMessage(global::Antlr.Runtime.RecognitionException e, string[] tokenNames)
		{
			string result = e.Message;
			if (e is global::Antlr.Runtime.UnwantedTokenException)
			{
				global::Antlr.Runtime.UnwantedTokenException ex = (global::Antlr.Runtime.UnwantedTokenException)e;
				string str;
				if (ex.Expecting == -1)
				{
					str = "EndOfFile";
				}
				else
				{
					str = tokenNames[ex.Expecting];
				}
				result = "extraneous input " + this.GetTokenErrorDisplay(ex.UnexpectedToken) + " expecting " + str;
			}
			else if (e is global::Antlr.Runtime.MissingTokenException)
			{
				global::Antlr.Runtime.MissingTokenException ex2 = (global::Antlr.Runtime.MissingTokenException)e;
				string str2;
				if (ex2.Expecting == -1)
				{
					str2 = "EndOfFile";
				}
				else
				{
					str2 = tokenNames[ex2.Expecting];
				}
				result = "missing " + str2 + " at " + this.GetTokenErrorDisplay(e.Token);
			}
			else if (e is global::Antlr.Runtime.MismatchedTokenException)
			{
				global::Antlr.Runtime.MismatchedTokenException ex3 = (global::Antlr.Runtime.MismatchedTokenException)e;
				string str3;
				if (ex3.Expecting == -1)
				{
					str3 = "EndOfFile";
				}
				else
				{
					str3 = tokenNames[ex3.Expecting];
				}
				result = "mismatched input " + this.GetTokenErrorDisplay(e.Token) + " expecting " + str3;
			}
			else if (e is global::Antlr.Runtime.MismatchedTreeNodeException)
			{
				global::Antlr.Runtime.MismatchedTreeNodeException ex4 = (global::Antlr.Runtime.MismatchedTreeNodeException)e;
				string str4;
				if (ex4.Expecting == -1)
				{
					str4 = "EndOfFile";
				}
				else
				{
					str4 = tokenNames[ex4.Expecting];
				}
				string str5 = (ex4.Node != null) ? (ex4.Node.ToString() ?? string.Empty) : string.Empty;
				result = "mismatched tree node: " + str5 + " expecting " + str4;
			}
			else if (e is global::Antlr.Runtime.NoViableAltException)
			{
				result = "no viable alternative at input " + this.GetTokenErrorDisplay(e.Token);
			}
			else if (e is global::Antlr.Runtime.EarlyExitException)
			{
				result = "required (...)+ loop did not match anything at input " + this.GetTokenErrorDisplay(e.Token);
			}
			else if (e is global::Antlr.Runtime.MismatchedSetException)
			{
				global::Antlr.Runtime.MismatchedSetException ex5 = (global::Antlr.Runtime.MismatchedSetException)e;
				result = string.Concat(new object[]
				{
					"mismatched input ",
					this.GetTokenErrorDisplay(e.Token),
					" expecting set ",
					ex5.Expecting
				});
			}
			else if (e is global::Antlr.Runtime.MismatchedNotSetException)
			{
				global::Antlr.Runtime.MismatchedNotSetException ex6 = (global::Antlr.Runtime.MismatchedNotSetException)e;
				result = string.Concat(new object[]
				{
					"mismatched input ",
					this.GetTokenErrorDisplay(e.Token),
					" expecting set ",
					ex6.Expecting
				});
			}
			else if (e is global::Antlr.Runtime.FailedPredicateException)
			{
				global::Antlr.Runtime.FailedPredicateException ex7 = (global::Antlr.Runtime.FailedPredicateException)e;
				result = string.Concat(new string[]
				{
					"rule ",
					ex7.RuleName,
					" failed predicate: {",
					ex7.PredicateText,
					"}?"
				});
			}
			return result;
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0002C190 File Offset: 0x0002A390
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int NumberOfSyntaxErrors
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.state.syntaxErrors;
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0002C1A0 File Offset: 0x0002A3A0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string GetErrorHeader(global::Antlr.Runtime.RecognitionException e)
		{
			string text = this.SourceName ?? string.Empty;
			if (text.Length > 0)
			{
				text += ' ';
			}
			return string.Format("{0}line {1}:{2}", text, e.Line, e.CharPositionInLine + 1);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0002C204 File Offset: 0x0002A404
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string GetTokenErrorDisplay(global::Antlr.Runtime.IToken t)
		{
			string text = t.Text;
			if (text == null)
			{
				if (t.Type == -1)
				{
					text = "<EOF>";
				}
				else
				{
					text = "<" + t.Type + ">";
				}
			}
			text = global::System.Text.RegularExpressions.Regex.Replace(text, "\n", "\\\\n");
			text = global::System.Text.RegularExpressions.Regex.Replace(text, "\r", "\\\\r");
			text = global::System.Text.RegularExpressions.Regex.Replace(text, "\t", "\\\\t");
			return "'" + text + "'";
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0002C298 File Offset: 0x0002A498
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void EmitErrorMessage(string msg)
		{
			if (this.TraceDestination != null)
			{
				this.TraceDestination.WriteLine(msg);
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0002C2B4 File Offset: 0x0002A4B4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Recover(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.RecognitionException re)
		{
			if (this.state.lastErrorIndex == input.Index)
			{
				input.Consume();
			}
			this.state.lastErrorIndex = input.Index;
			global::Antlr.Runtime.BitSet set = this.ComputeErrorRecoverySet();
			this.BeginResync();
			this.ConsumeUntil(input, set);
			this.EndResync();
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0002C310 File Offset: 0x0002A510
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void BeginResync()
		{
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0002C314 File Offset: 0x0002A514
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void EndResync()
		{
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0002C318 File Offset: 0x0002A518
		protected virtual global::Antlr.Runtime.BitSet ComputeErrorRecoverySet()
		{
			return this.CombineFollows(false);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0002C324 File Offset: 0x0002A524
		protected virtual global::Antlr.Runtime.BitSet ComputeContextSensitiveRuleFOLLOW()
		{
			return this.CombineFollows(true);
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0002C330 File Offset: 0x0002A530
		protected virtual global::Antlr.Runtime.BitSet CombineFollows(bool exact)
		{
			int fsp = this.state._fsp;
			global::Antlr.Runtime.BitSet bitSet = new global::Antlr.Runtime.BitSet();
			for (int i = fsp; i >= 0; i--)
			{
				global::Antlr.Runtime.BitSet bitSet2 = this.state.following[i];
				bitSet.OrInPlace(bitSet2);
				if (exact)
				{
					if (!bitSet2.Member(1))
					{
						break;
					}
					if (i > 0)
					{
						bitSet.Remove(1);
					}
				}
			}
			return bitSet;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0002C39C File Offset: 0x0002A59C
		protected virtual object RecoverFromMismatchedToken(global::Antlr.Runtime.IIntStream input, int ttype, global::Antlr.Runtime.BitSet follow)
		{
			global::Antlr.Runtime.RecognitionException ex = null;
			if (this.MismatchIsUnwantedToken(input, ttype))
			{
				ex = new global::Antlr.Runtime.UnwantedTokenException(ttype, input, this.TokenNames);
				this.BeginResync();
				input.Consume();
				this.EndResync();
				this.ReportError(ex);
				object currentInputSymbol = this.GetCurrentInputSymbol(input);
				input.Consume();
				return currentInputSymbol;
			}
			if (this.MismatchIsMissingToken(input, follow))
			{
				object missingSymbol = this.GetMissingSymbol(input, ex, ttype, follow);
				ex = new global::Antlr.Runtime.MissingTokenException(ttype, input, missingSymbol);
				this.ReportError(ex);
				return missingSymbol;
			}
			ex = new global::Antlr.Runtime.MismatchedTokenException(ttype, input, this.TokenNames);
			throw ex;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0002C42C File Offset: 0x0002A62C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object RecoverFromMismatchedSet(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.RecognitionException e, global::Antlr.Runtime.BitSet follow)
		{
			if (this.MismatchIsMissingToken(input, follow))
			{
				this.ReportError(e);
				return this.GetMissingSymbol(input, e, 0, follow);
			}
			throw e;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0002C460 File Offset: 0x0002A660
		protected virtual object GetCurrentInputSymbol(global::Antlr.Runtime.IIntStream input)
		{
			return null;
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0002C464 File Offset: 0x0002A664
		protected virtual object GetMissingSymbol(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.RecognitionException e, int expectedTokenType, global::Antlr.Runtime.BitSet follow)
		{
			return null;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0002C468 File Offset: 0x0002A668
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ConsumeUntil(global::Antlr.Runtime.IIntStream input, int tokenType)
		{
			int num = input.LA(1);
			while (num != -1 && num != tokenType)
			{
				input.Consume();
				num = input.LA(1);
			}
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0002C4A0 File Offset: 0x0002A6A0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ConsumeUntil(global::Antlr.Runtime.IIntStream input, global::Antlr.Runtime.BitSet set)
		{
			int num = input.LA(1);
			while (num != -1 && !set.Member(num))
			{
				input.Consume();
				num = input.LA(1);
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0002C4DC File Offset: 0x0002A6DC
		protected void PushFollow(global::Antlr.Runtime.BitSet fset)
		{
			if (this.state._fsp + 1 >= this.state.following.Length)
			{
				global::System.Array.Resize<global::Antlr.Runtime.BitSet>(ref this.state.following, this.state.following.Length * 2);
			}
			this.state.following[++this.state._fsp] = fset;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0002C550 File Offset: 0x0002A750
		protected void PopFollow()
		{
			this.state._fsp--;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0002C568 File Offset: 0x0002A768
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<string> GetRuleInvocationStack()
		{
			return global::Antlr.Runtime.BaseRecognizer.GetRuleInvocationStack(new global::System.Diagnostics.StackTrace(true));
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0002C578 File Offset: 0x0002A778
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static global::System.Collections.Generic.IList<string> GetRuleInvocationStack(global::System.Diagnostics.StackTrace trace)
		{
			if (trace == null)
			{
				throw new global::System.ArgumentNullException("trace");
			}
			global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
			global::System.Diagnostics.StackFrame[] array = trace.GetFrames() ?? new global::System.Diagnostics.StackFrame[0];
			for (int i = array.Length - 1; i >= 0; i--)
			{
				global::System.Diagnostics.StackFrame stackFrame = array[i];
				global::System.Reflection.MethodBase method = stackFrame.GetMethod();
				global::Antlr.Runtime.GrammarRuleAttribute[] array2 = (global::Antlr.Runtime.GrammarRuleAttribute[])method.GetCustomAttributes(typeof(global::Antlr.Runtime.GrammarRuleAttribute), true);
				if (array2 != null && array2.Length > 0)
				{
					list.Add(array2[0].Name);
				}
			}
			return list;
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x0002C618 File Offset: 0x0002A818
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x0002C628 File Offset: 0x0002A828
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int BacktrackingLevel
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.state.backtracking;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.state.backtracking = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x0002C638 File Offset: 0x0002A838
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool Failed
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.state.failed;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0002C648 File Offset: 0x0002A848
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string[] TokenNames
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return null;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x0002C64C File Offset: 0x0002A84C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string GrammarFileName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return null;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600067B RID: 1659
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract string SourceName { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x0600067C RID: 1660 RVA: 0x0002C650 File Offset: 0x0002A850
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.List<string> ToStrings(global::System.Collections.Generic.ICollection<global::Antlr.Runtime.IToken> tokens)
		{
			if (tokens == null)
			{
				return null;
			}
			global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>(tokens.Count);
			foreach (global::Antlr.Runtime.IToken token in tokens)
			{
				list.Add(token.Text);
			}
			return list;
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0002C6BC File Offset: 0x0002A8BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetRuleMemoization(int ruleIndex, int ruleStartIndex)
		{
			if (this.state.ruleMemo[ruleIndex] == null)
			{
				this.state.ruleMemo[ruleIndex] = new global::System.Collections.Generic.Dictionary<int, int>();
			}
			int result;
			if (!this.state.ruleMemo[ruleIndex].TryGetValue(ruleStartIndex, out result))
			{
				return -1;
			}
			return result;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0002C71C File Offset: 0x0002A91C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool AlreadyParsedRule(global::Antlr.Runtime.IIntStream input, int ruleIndex)
		{
			int ruleMemoization = this.GetRuleMemoization(ruleIndex, input.Index);
			if (ruleMemoization == -1)
			{
				return false;
			}
			if (ruleMemoization == -2)
			{
				this.state.failed = true;
			}
			else
			{
				input.Seek(ruleMemoization + 1);
			}
			return true;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0002C768 File Offset: 0x0002A968
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Memoize(global::Antlr.Runtime.IIntStream input, int ruleIndex, int ruleStartIndex)
		{
			int value = this.state.failed ? -2 : (input.Index - 1);
			if (this.state.ruleMemo == null && this.TraceDestination != null)
			{
				this.TraceDestination.WriteLine("!!!!!!!!! memo array is null for " + this.GrammarFileName);
			}
			if (ruleIndex >= this.state.ruleMemo.Length && this.TraceDestination != null)
			{
				this.TraceDestination.WriteLine(string.Concat(new object[]
				{
					"!!!!!!!!! memo size is ",
					this.state.ruleMemo.Length,
					", but rule index is ",
					ruleIndex
				}));
			}
			if (this.state.ruleMemo[ruleIndex] != null)
			{
				this.state.ruleMemo[ruleIndex][ruleStartIndex] = value;
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0002C864 File Offset: 0x0002AA64
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetRuleMemoizationCacheSize()
		{
			int num = 0;
			int num2 = 0;
			while (this.state.ruleMemo != null && num2 < this.state.ruleMemo.Length)
			{
				global::System.Collections.Generic.IDictionary<int, int> dictionary = this.state.ruleMemo[num2];
				if (dictionary != null)
				{
					num += dictionary.Count;
				}
				num2++;
			}
			return num;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0002C8C4 File Offset: 0x0002AAC4
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceIn(string ruleName, int ruleIndex, object inputSymbol)
		{
			if (this.TraceDestination == null)
			{
				return;
			}
			this.TraceDestination.Write(string.Concat(new object[]
			{
				"enter ",
				ruleName,
				" ",
				inputSymbol
			}));
			if (this.state.backtracking > 0)
			{
				this.TraceDestination.Write(" backtracking=" + this.state.backtracking);
			}
			this.TraceDestination.WriteLine();
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0002C954 File Offset: 0x0002AB54
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceOut(string ruleName, int ruleIndex, object inputSymbol)
		{
			if (this.TraceDestination == null)
			{
				return;
			}
			this.TraceDestination.Write(string.Concat(new object[]
			{
				"exit ",
				ruleName,
				" ",
				inputSymbol
			}));
			if (this.state.backtracking > 0)
			{
				this.TraceDestination.Write(" backtracking=" + this.state.backtracking);
				if (this.state.failed)
				{
					this.TraceDestination.Write(" failed");
				}
				else
				{
					this.TraceDestination.Write(" succeeded");
				}
			}
			this.TraceDestination.WriteLine();
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x0002CA18 File Offset: 0x0002AC18
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Debug.IDebugEventListener DebugListener
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return null;
			}
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0002CA1C File Offset: 0x0002AC1C
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugEnterRule(string grammarFileName, string ruleName)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.EnterRule(grammarFileName, ruleName);
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0002CA44 File Offset: 0x0002AC44
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugExitRule(string grammarFileName, string ruleName)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.ExitRule(grammarFileName, ruleName);
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0002CA6C File Offset: 0x0002AC6C
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugEnterSubRule(int decisionNumber)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.EnterSubRule(decisionNumber);
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0002CA94 File Offset: 0x0002AC94
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugExitSubRule(int decisionNumber)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.ExitSubRule(decisionNumber);
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0002CABC File Offset: 0x0002ACBC
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugEnterAlt(int alt)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.EnterAlt(alt);
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0002CAE4 File Offset: 0x0002ACE4
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugEnterDecision(int decisionNumber, bool couldBacktrack)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.EnterDecision(decisionNumber, couldBacktrack);
			}
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0002CB0C File Offset: 0x0002AD0C
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugExitDecision(int decisionNumber)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.ExitDecision(decisionNumber);
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0002CB34 File Offset: 0x0002AD34
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugLocation(int line, int charPositionInLine)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.Location(line, charPositionInLine);
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0002CB5C File Offset: 0x0002AD5C
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugSemanticPredicate(bool result, string predicate)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.SemanticPredicate(result, predicate);
			}
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0002CB84 File Offset: 0x0002AD84
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugBeginBacktrack(int level)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.BeginBacktrack(level);
			}
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0002CBAC File Offset: 0x0002ADAC
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugEndBacktrack(int level, bool successful)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.EndBacktrack(level, successful);
			}
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0002CBD4 File Offset: 0x0002ADD4
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugRecognitionException(global::Antlr.Runtime.RecognitionException ex)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.DebugListener;
			if (debugListener != null)
			{
				debugListener.RecognitionException(ex);
			}
		}

		// Token: 0x0400034E RID: 846
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int MemoRuleFailed = -2;

		// Token: 0x0400034F RID: 847
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int MemoRuleUnknown = -1;

		// Token: 0x04000350 RID: 848
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int InitialFollowStackSize = 0x64;

		// Token: 0x04000351 RID: 849
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int DefaultTokenChannel = 0;

		// Token: 0x04000352 RID: 850
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Hidden = 0x63;

		// Token: 0x04000353 RID: 851
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const string NextTokenRuleName = "nextToken";

		// Token: 0x04000354 RID: 852
		protected internal global::Antlr.Runtime.RecognizerSharedState state;

		// Token: 0x04000355 RID: 853
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.IO.TextWriter <TraceDestination>k__BackingField;
	}
}
