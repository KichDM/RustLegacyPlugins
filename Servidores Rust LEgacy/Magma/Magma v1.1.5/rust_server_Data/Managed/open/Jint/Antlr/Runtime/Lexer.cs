using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000A9 RID: 169
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public abstract class Lexer : global::Antlr.Runtime.BaseRecognizer, global::Antlr.Runtime.ITokenSource
	{
		// Token: 0x060007B1 RID: 1969 RVA: 0x0002F40C File Offset: 0x0002D60C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public Lexer()
		{
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0002F414 File Offset: 0x0002D614
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public Lexer(global::Antlr.Runtime.ICharStream input)
		{
			this.input = input;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0002F424 File Offset: 0x0002D624
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public Lexer(global::Antlr.Runtime.ICharStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(state)
		{
			this.input = input;
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0002F434 File Offset: 0x0002D634
		// (set) Token: 0x060007B5 RID: 1973 RVA: 0x0002F48C File Offset: 0x0002D68C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string Text
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.state.text != null)
				{
					return this.state.text;
				}
				return this.input.Substring(this.state.tokenStartCharIndex, this.CharIndex - this.state.tokenStartCharIndex);
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.state.text = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x0002F49C File Offset: 0x0002D69C
		// (set) Token: 0x060007B7 RID: 1975 RVA: 0x0002F4AC File Offset: 0x0002D6AC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Line
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input.Line;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.input.Line = value;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x0002F4BC File Offset: 0x0002D6BC
		// (set) Token: 0x060007B9 RID: 1977 RVA: 0x0002F4CC File Offset: 0x0002D6CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int CharPositionInLine
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input.CharPositionInLine;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.input.CharPositionInLine = value;
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0002F4DC File Offset: 0x0002D6DC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void Reset()
		{
			base.Reset();
			if (this.input != null)
			{
				this.input.Seek(0);
			}
			if (this.state == null)
			{
				return;
			}
			this.state.token = null;
			this.state.type = 0;
			this.state.channel = 0;
			this.state.tokenStartCharIndex = -1;
			this.state.tokenStartCharPositionInLine = -1;
			this.state.tokenStartLine = -1;
			this.state.text = null;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0002F56C File Offset: 0x0002D76C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken NextToken()
		{
			for (;;)
			{
				this.state.token = null;
				this.state.channel = 0;
				this.state.tokenStartCharIndex = this.input.Index;
				this.state.tokenStartCharPositionInLine = this.input.CharPositionInLine;
				this.state.tokenStartLine = this.input.Line;
				this.state.text = null;
				if (this.input.LA(1) == -1)
				{
					break;
				}
				global::Antlr.Runtime.IToken token;
				try
				{
					this.mTokens();
					if (this.state.token == null)
					{
						this.Emit();
					}
					else if (this.state.token == global::Antlr.Runtime.Tokens.Skip)
					{
						continue;
					}
					token = this.state.token;
				}
				catch (global::Antlr.Runtime.NoViableAltException ex)
				{
					this.ReportError(ex);
					this.Recover(ex);
					continue;
				}
				catch (global::Antlr.Runtime.RecognitionException e)
				{
					this.ReportError(e);
					continue;
				}
				return token;
			}
			return new global::Antlr.Runtime.CommonToken(this.input, -1, 0, this.input.Index, this.input.Index)
			{
				Line = this.Line,
				CharPositionInLine = this.CharPositionInLine
			};
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0002F6BC File Offset: 0x0002D8BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Skip()
		{
			this.state.token = global::Antlr.Runtime.Tokens.Skip;
		}

		// Token: 0x060007BD RID: 1981
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract void mTokens();

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x0002F6D0 File Offset: 0x0002D8D0
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x0002F6D8 File Offset: 0x0002D8D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.ICharStream CharStream
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x0002F6F0 File Offset: 0x0002D8F0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input.SourceName;
			}
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0002F700 File Offset: 0x0002D900
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Emit(global::Antlr.Runtime.IToken token)
		{
			this.state.token = token;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0002F710 File Offset: 0x0002D910
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken Emit()
		{
			global::Antlr.Runtime.IToken token = new global::Antlr.Runtime.CommonToken(this.input, this.state.type, this.state.channel, this.state.tokenStartCharIndex, this.CharIndex - 1);
			token.Line = this.state.tokenStartLine;
			token.Text = this.state.text;
			token.CharPositionInLine = this.state.tokenStartCharPositionInLine;
			this.Emit(token);
			return token;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0002F794 File Offset: 0x0002D994
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Match(string s)
		{
			int i = 0;
			while (i < s.Length)
			{
				if (this.input.LA(1) != (int)s[i])
				{
					if (this.state.backtracking > 0)
					{
						this.state.failed = true;
						return;
					}
					global::Antlr.Runtime.MismatchedTokenException ex = new global::Antlr.Runtime.MismatchedTokenException((int)s[i], this.input, this.TokenNames);
					this.Recover(ex);
					throw ex;
				}
				else
				{
					i++;
					this.input.Consume();
					this.state.failed = false;
				}
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0002F828 File Offset: 0x0002DA28
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void MatchAny()
		{
			this.input.Consume();
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0002F838 File Offset: 0x0002DA38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Match(int c)
		{
			if (this.input.LA(1) == c)
			{
				this.input.Consume();
				this.state.failed = false;
				return;
			}
			if (this.state.backtracking > 0)
			{
				this.state.failed = true;
				return;
			}
			global::Antlr.Runtime.MismatchedTokenException ex = new global::Antlr.Runtime.MismatchedTokenException(c, this.input, this.TokenNames);
			this.Recover(ex);
			throw ex;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0002F8AC File Offset: 0x0002DAAC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void MatchRange(int a, int b)
		{
			if (this.input.LA(1) >= a && this.input.LA(1) <= b)
			{
				this.input.Consume();
				this.state.failed = false;
				return;
			}
			if (this.state.backtracking > 0)
			{
				this.state.failed = true;
				return;
			}
			global::Antlr.Runtime.MismatchedRangeException ex = new global::Antlr.Runtime.MismatchedRangeException(a, b, this.input);
			this.Recover(ex);
			throw ex;
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0002F930 File Offset: 0x0002DB30
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int CharIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input.Index;
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0002F940 File Offset: 0x0002DB40
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void ReportError(global::Antlr.Runtime.RecognitionException e)
		{
			this.DisplayRecognitionError(this.TokenNames, e);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0002F950 File Offset: 0x0002DB50
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string GetErrorMessage(global::Antlr.Runtime.RecognitionException e, string[] tokenNames)
		{
			string result;
			if (e is global::Antlr.Runtime.MismatchedTokenException)
			{
				global::Antlr.Runtime.MismatchedTokenException ex = (global::Antlr.Runtime.MismatchedTokenException)e;
				result = "mismatched character " + this.GetCharErrorDisplay(e.Character) + " expecting " + this.GetCharErrorDisplay(ex.Expecting);
			}
			else if (e is global::Antlr.Runtime.NoViableAltException)
			{
				global::Antlr.Runtime.NoViableAltException ex2 = (global::Antlr.Runtime.NoViableAltException)e;
				result = "no viable alternative at character " + this.GetCharErrorDisplay(e.Character);
			}
			else if (e is global::Antlr.Runtime.EarlyExitException)
			{
				global::Antlr.Runtime.EarlyExitException ex3 = (global::Antlr.Runtime.EarlyExitException)e;
				result = "required (...)+ loop did not match anything at character " + this.GetCharErrorDisplay(e.Character);
			}
			else if (e is global::Antlr.Runtime.MismatchedNotSetException)
			{
				global::Antlr.Runtime.MismatchedNotSetException ex4 = (global::Antlr.Runtime.MismatchedNotSetException)e;
				result = string.Concat(new object[]
				{
					"mismatched character ",
					this.GetCharErrorDisplay(e.Character),
					" expecting set ",
					ex4.Expecting
				});
			}
			else if (e is global::Antlr.Runtime.MismatchedSetException)
			{
				global::Antlr.Runtime.MismatchedSetException ex5 = (global::Antlr.Runtime.MismatchedSetException)e;
				result = string.Concat(new object[]
				{
					"mismatched character ",
					this.GetCharErrorDisplay(e.Character),
					" expecting set ",
					ex5.Expecting
				});
			}
			else if (e is global::Antlr.Runtime.MismatchedRangeException)
			{
				global::Antlr.Runtime.MismatchedRangeException ex6 = (global::Antlr.Runtime.MismatchedRangeException)e;
				result = string.Concat(new string[]
				{
					"mismatched character ",
					this.GetCharErrorDisplay(e.Character),
					" expecting set ",
					this.GetCharErrorDisplay(ex6.A),
					"..",
					this.GetCharErrorDisplay(ex6.B)
				});
			}
			else
			{
				result = base.GetErrorMessage(e, tokenNames);
			}
			return result;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0002FB38 File Offset: 0x0002DD38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string GetCharErrorDisplay(int c)
		{
			string str = ((char)c).ToString();
			if (c != -1)
			{
				switch (c)
				{
				case 9:
					str = "\\t";
					break;
				case 0xA:
					str = "\\n";
					break;
				case 0xD:
					str = "\\r";
					break;
				}
			}
			else
			{
				str = "<EOF>";
			}
			return "'" + str + "'";
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0002FBB8 File Offset: 0x0002DDB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Recover(global::Antlr.Runtime.RecognitionException re)
		{
			this.input.Consume();
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0002FBC8 File Offset: 0x0002DDC8
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceIn(string ruleName, int ruleIndex)
		{
			string.Concat(new object[]
			{
				(char)this.input.LT(1),
				" line=",
				this.Line,
				":",
				this.CharPositionInLine
			});
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0002FC28 File Offset: 0x0002DE28
		[global::System.Diagnostics.Conditional("ANTLR_TRACE")]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void TraceOut(string ruleName, int ruleIndex)
		{
			string.Concat(new object[]
			{
				(char)this.input.LT(1),
				" line=",
				this.Line,
				":",
				this.CharPositionInLine
			});
		}

		// Token: 0x04000393 RID: 915
		protected global::Antlr.Runtime.ICharStream input;
	}
}
