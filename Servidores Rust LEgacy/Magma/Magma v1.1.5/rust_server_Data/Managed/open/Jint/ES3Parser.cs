using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Jint.Debugger;
using Jint.Expressions;

// Token: 0x02000024 RID: 36
[global::System.CLSCompliant(false)]
[global::System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3.1.7705")]
public class ES3Parser : global::Antlr.Runtime.Parser
{
	// Token: 0x060001C2 RID: 450 RVA: 0x0000B730 File Offset: 0x00009930
	public ES3Parser(global::Antlr.Runtime.ITokenStream input) : this(input, new global::Antlr.Runtime.RecognizerSharedState())
	{
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0000B740 File Offset: 0x00009940
	public ES3Parser(global::Antlr.Runtime.ITokenStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(input, state)
	{
		global::Antlr.Runtime.Tree.ITreeAdaptor treeAdaptor = null;
		this.TreeAdaptor = (treeAdaptor ?? new global::Antlr.Runtime.Tree.CommonTreeAdaptor());
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000B77C File Offset: 0x0000997C
	// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000B784 File Offset: 0x00009984
	public global::Antlr.Runtime.Tree.ITreeAdaptor TreeAdaptor
	{
		get
		{
			return this.adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000B790 File Offset: 0x00009990
	public override string[] TokenNames
	{
		get
		{
			return global::ES3Parser.tokenNames;
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000B798 File Offset: 0x00009998
	public override string GrammarFileName
	{
		get
		{
			return "C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g";
		}
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000B7A0 File Offset: 0x000099A0
	private bool IsLeftHandSideAssign(global::Jint.Expressions.Expression lhs, object[] cached)
	{
		if (cached[0] != null)
		{
			return global::System.Convert.ToBoolean(cached[0]);
		}
		bool flag;
		if (global::ES3Parser.IsLeftHandSideExpression(lhs))
		{
			int num = this.input.LA(1);
			if (num <= 0x62)
			{
				if (num <= 0xB)
				{
					switch (num)
					{
					case 6:
					case 8:
						break;
					case 7:
						goto IL_D4;
					default:
						if (num != 0xB)
						{
							goto IL_D4;
						}
						break;
					}
				}
				else if (num != 0x25)
				{
					switch (num)
					{
					case 0x60:
					case 0x62:
						break;
					case 0x61:
						goto IL_D4;
					default:
						goto IL_D4;
					}
				}
			}
			else if (num <= 0x87)
			{
				if (num != 0x6F && num != 0x87)
				{
					goto IL_D4;
				}
			}
			else
			{
				switch (num)
				{
				case 0x8A:
				case 0x8C:
					break;
				case 0x8B:
					goto IL_D4;
				default:
					if (num != 0x91 && num != 0xA9)
					{
						goto IL_D4;
					}
					break;
				}
			}
			flag = true;
			goto IL_DD;
			IL_D4:
			flag = false;
		}
		else
		{
			flag = false;
		}
		IL_DD:
		cached[0] = flag;
		return flag;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000B898 File Offset: 0x00009A98
	private static bool IsLeftHandSideExpression(global::Jint.Expressions.Expression lhs)
	{
		return lhs == null || lhs is global::Jint.Expressions.Identifier || lhs is global::Jint.Expressions.PropertyExpression || lhs is global::Jint.Expressions.MemberExpression;
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0000B8C4 File Offset: 0x00009AC4
	private bool IsLeftHandSideIn(global::Jint.Expressions.Expression lhs, object[] cached)
	{
		if (cached[0] != null)
		{
			return global::System.Convert.ToBoolean(cached[0]);
		}
		bool flag = global::ES3Parser.IsLeftHandSideExpression(lhs) && this.input.LA(1) == 0x48;
		cached[0] = flag;
		return flag;
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0000B914 File Offset: 0x00009B14
	private void PromoteEOL(global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken> rule)
	{
		global::Antlr.Runtime.IToken token = this.input.LT(1);
		int type = token.Type;
		if (type != 0x85 && type != -1 && type != 0x7D && type != 0x2F && type != 0x63)
		{
			int i = token.TokenIndex - 1;
			while (i > 0)
			{
				token = this.input.Get(i);
				if (token.Channel == 0)
				{
					return;
				}
				if (token.Type == 0x2F || (token.Type == 0x63 && (token.Text.EndsWith("\r") || token.Text.EndsWith("\n"))))
				{
					token.Channel = 0;
					this.input.Seek(token.TokenIndex);
					if (rule != null)
					{
						rule.Start = token;
						return;
					}
					break;
				}
				else
				{
					i--;
				}
			}
		}
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000BA00 File Offset: 0x00009C00
	private string extractRegExpPattern(string text)
	{
		return text.Substring(1, text.LastIndexOf('/') - 1);
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000BA14 File Offset: 0x00009C14
	private string extractRegExpOption(string text)
	{
		if (text[text.Length - 1] != '/')
		{
			return text.Substring(text.LastIndexOf('/') + 1);
		}
		return string.Empty;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000BA44 File Offset: 0x00009C44
	private string extractString(string text)
	{
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(text.Length);
		int num = 1;
		int num2;
		while ((num2 = text.IndexOf('\\', num)) != -1)
		{
			stringBuilder.Append(text.Substring(num, num2 - num));
			char c = text[num2 + 1];
			char c2 = c;
			if (c2 <= '9')
			{
				if (c2 <= '\r')
				{
					if (c2 != '\n')
					{
						if (c2 != '\r')
						{
							goto IL_299;
						}
						if (text[num2 + 2] == '\n')
						{
							num2 += 3;
						}
					}
					else
					{
						num2 += 2;
					}
				}
				else if (c2 != '"')
				{
					switch (c2)
					{
					case '\'':
						stringBuilder.Append('\'');
						num2 += 2;
						break;
					case '(':
					case ')':
					case '*':
					case '+':
					case ',':
					case '-':
					case '.':
					case '/':
						goto IL_299;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					{
						string value = text.Substring(num2 + 1, 3);
						char value2 = global::ES3Parser.Latin1.GetChars(new byte[]
						{
							global::System.Convert.ToByte(value, 8)
						})[0];
						stringBuilder.Append(value2);
						num2 += 4;
						break;
					}
					default:
						goto IL_299;
					}
				}
				else
				{
					stringBuilder.Append('"');
					num2 += 2;
				}
			}
			else if (c2 <= 'b')
			{
				if (c2 != '\\')
				{
					if (c2 != 'b')
					{
						goto IL_299;
					}
					stringBuilder.Append('\b');
					num2 += 2;
				}
				else
				{
					stringBuilder.Append('\\');
					num2 += 2;
				}
			}
			else if (c2 != 'f')
			{
				switch (c2)
				{
				case 'n':
					stringBuilder.Append('\n');
					num2 += 2;
					break;
				case 'o':
				case 'p':
				case 'q':
				case 's':
				case 'w':
					goto IL_299;
				case 'r':
					stringBuilder.Append('\r');
					num2 += 2;
					break;
				case 't':
					stringBuilder.Append('\t');
					num2 += 2;
					break;
				case 'u':
				{
					char value3 = global::System.Convert.ToChar(int.Parse(text.Substring(num2 + 2, 4), global::System.Globalization.NumberStyles.AllowHexSpecifier));
					stringBuilder.Append(value3);
					num2 += 6;
					break;
				}
				case 'v':
					stringBuilder.Append('\v');
					num2 += 2;
					break;
				case 'x':
				{
					string value4 = text.Substring(num2 + 2, 2);
					char value5 = global::ES3Parser.Latin1.GetChars(new byte[]
					{
						global::System.Convert.ToByte(value4, 0x10)
					})[0];
					stringBuilder.Append(value5);
					num2 += 4;
					break;
				}
				default:
					goto IL_299;
				}
			}
			else
			{
				stringBuilder.Append('\f');
				num2 += 2;
			}
			IL_2A5:
			num = num2;
			continue;
			IL_299:
			stringBuilder.Append(c);
			num2 += 2;
			goto IL_2A5;
		}
		if (stringBuilder.Length == 0)
		{
			return text.Substring(1, text.Length - 2);
		}
		stringBuilder.Append(text.Substring(num, text.Length - num - 1));
		return stringBuilder.ToString();
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x060001CF RID: 463 RVA: 0x0000BD48 File Offset: 0x00009F48
	// (set) Token: 0x060001D0 RID: 464 RVA: 0x0000BD50 File Offset: 0x00009F50
	public global::System.Collections.Generic.List<string> Errors
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Errors>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Errors>k__BackingField = value;
		}
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x0000BD5C File Offset: 0x00009F5C
	public override void DisplayRecognitionError(string[] tokenNames, global::Antlr.Runtime.RecognitionException e)
	{
		base.DisplayRecognitionError(tokenNames, e);
		if (this.Errors == null)
		{
			this.Errors = new global::System.Collections.Generic.List<string>();
		}
		string errorHeader = this.GetErrorHeader(e);
		string errorMessage = this.GetErrorMessage(e, tokenNames);
		this.Errors.Add(errorMessage + " at " + errorHeader);
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000BDB4 File Offset: 0x00009FB4
	// (set) Token: 0x060001D3 RID: 467 RVA: 0x0000BDBC File Offset: 0x00009FBC
	public bool DebugMode
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<DebugMode>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<DebugMode>k__BackingField = value;
		}
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0000BDC8 File Offset: 0x00009FC8
	private global::Jint.Debugger.SourceCodeDescriptor ExtractSourceCode(global::Antlr.Runtime.CommonToken start, global::Antlr.Runtime.CommonToken stop)
	{
		if (!this.DebugMode)
		{
			return new global::Jint.Debugger.SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
		}
		global::Jint.Debugger.SourceCodeDescriptor result;
		try
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			for (int i = start.Line - 1; i <= stop.Line - 1; i++)
			{
				int num = 0;
				int num2 = this.script[i].Length;
				if (i == start.Line - 1)
				{
					num = start.CharPositionInLine;
				}
				if (i == stop.Line - 1)
				{
					num2 = stop.CharPositionInLine;
				}
				int length = num2 - num;
				stringBuilder.Append(this.script[i].Substring(num, length)).Append(global::System.Environment.NewLine);
			}
			result = new global::Jint.Debugger.SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, stringBuilder.ToString());
		}
		catch
		{
			result = new global::Jint.Debugger.SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
		}
		return result;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
	public global::Jint.Expressions.AssignmentOperator ResolveAssignmentOperator(string op)
	{
		switch (op)
		{
		case "=":
			return global::Jint.Expressions.AssignmentOperator.Assign;
		case "+=":
			return global::Jint.Expressions.AssignmentOperator.Add;
		case "-=":
			return global::Jint.Expressions.AssignmentOperator.Substract;
		case "*=":
			return global::Jint.Expressions.AssignmentOperator.Multiply;
		case "%=":
			return global::Jint.Expressions.AssignmentOperator.Modulo;
		case "<<=":
			return global::Jint.Expressions.AssignmentOperator.ShiftLeft;
		case ">>=":
			return global::Jint.Expressions.AssignmentOperator.ShiftRight;
		case ">>>=":
			return global::Jint.Expressions.AssignmentOperator.UnsignedRightShift;
		case "&=":
			return global::Jint.Expressions.AssignmentOperator.And;
		case "|=":
			return global::Jint.Expressions.AssignmentOperator.Or;
		case "^=":
			return global::Jint.Expressions.AssignmentOperator.XOr;
		case "/=":
			return global::Jint.Expressions.AssignmentOperator.Divide;
		}
		throw new global::System.NotSupportedException("Invalid assignment operator: " + op);
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0000C034 File Offset: 0x0000A234
	[global::Antlr.Runtime.GrammarRule("token")]
	private global::ES3Parser.token_return token()
	{
		global::ES3Parser.token_return token_return = new global::ES3Parser.token_return(this);
		token_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num;
			switch (this.input.LA(1))
			{
			case 4:
			case 0xD:
			case 0xE:
			case 0x12:
			case 0x15:
			case 0x16:
			case 0x18:
			case 0x19:
			case 0x1C:
			case 0x1D:
			case 0x20:
			case 0x22:
			case 0x23:
			case 0x26:
			case 0x28:
			case 0x2D:
			case 0x2E:
			case 0x31:
			case 0x33:
			case 0x36:
			case 0x38:
			case 0x39:
			case 0x3A:
			case 0x3B:
			case 0x3E:
			case 0x3F:
			case 0x45:
			case 0x46:
			case 0x47:
			case 0x48:
			case 0x4A:
			case 0x4B:
			case 0x4C:
			case 0x58:
			case 0x65:
			case 0x69:
			case 0x6C:
			case 0x73:
			case 0x78:
			case 0x79:
			case 0x7B:
			case 0x7F:
			case 0x88:
			case 0x8F:
			case 0x92:
			case 0x93:
			case 0x94:
			case 0x98:
			case 0x99:
			case 0x9A:
			case 0x9B:
			case 0x9C:
			case 0x9D:
			case 0x9E:
			case 0xA1:
			case 0xA2:
			case 0xA3:
			case 0xA5:
			case 0xA6:
				num = 1;
				goto IL_324;
			case 5:
			case 6:
			case 7:
			case 8:
			case 0xB:
			case 0x1A:
			case 0x1B:
			case 0x21:
			case 0x24:
			case 0x25:
			case 0x27:
			case 0x30:
			case 0x40:
			case 0x41:
			case 0x49:
			case 0x4D:
			case 0x54:
			case 0x55:
			case 0x56:
			case 0x59:
			case 0x5A:
			case 0x5C:
			case 0x5D:
			case 0x5F:
			case 0x60:
			case 0x61:
			case 0x62:
			case 0x68:
			case 0x6A:
			case 0x6B:
			case 0x6E:
			case 0x6F:
			case 0x7C:
			case 0x7D:
			case 0x7E:
			case 0x80:
			case 0x84:
			case 0x85:
			case 0x86:
			case 0x87:
			case 0x89:
			case 0x8A:
			case 0x8B:
			case 0x8C:
			case 0x90:
			case 0x91:
			case 0xA8:
			case 0xA9:
				num = 3;
				goto IL_324;
			case 0x2C:
			case 0x44:
			case 0x72:
				num = 4;
				goto IL_324;
			case 0x4F:
				num = 2;
				goto IL_324;
			case 0x96:
				num = 5;
				goto IL_324;
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 1, 0, this.input);
			throw ex;
			IL_324:
			switch (num)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._reservedWord_in_token1748);
				global::ES3Parser.reservedWord_return reservedWord_return = this.reservedWord();
				base.PopFollow();
				this.adaptor.AddChild(obj, reservedWord_return.Tree);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_token1753);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._punctuator_in_token1758);
				global::ES3Parser.punctuator_return punctuator_return = this.punctuator();
				base.PopFollow();
				this.adaptor.AddChild(obj, punctuator_return.Tree);
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._numericLiteral_in_token1763);
				global::ES3Parser.numericLiteral_return numericLiteral_return = this.numericLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, numericLiteral_return.Tree);
				break;
			}
			case 5:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x96, global::ES3Parser.Follow._StringLiteral_in_token1768);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				break;
			}
			}
			token_return.Stop = this.input.LT(-1);
			token_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(token_return.Tree, token_return.Start, token_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			token_return.Tree = this.adaptor.ErrorNode(this.input, token_return.Start, this.input.LT(-1), ex2);
		}
		return token_return;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0000C578 File Offset: 0x0000A778
	[global::Antlr.Runtime.GrammarRule("reservedWord")]
	private global::ES3Parser.reservedWord_return reservedWord()
	{
		global::ES3Parser.reservedWord_return reservedWord_return = new global::ES3Parser.reservedWord_return(this);
		reservedWord_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x65)
			{
				if (num <= 0x23)
				{
					if (num == 4)
					{
						goto IL_25D;
					}
					switch (num)
					{
					case 0xD:
					case 0x12:
					case 0x18:
					case 0x19:
					case 0x1C:
					case 0x20:
						goto IL_25D;
					case 0xE:
					case 0x15:
					case 0x16:
					case 0x1D:
					case 0x22:
					case 0x23:
						break;
					case 0xF:
					case 0x10:
					case 0x11:
					case 0x13:
					case 0x14:
					case 0x17:
					case 0x1A:
					case 0x1B:
					case 0x1E:
					case 0x1F:
					case 0x21:
						goto IL_275;
					default:
						goto IL_275;
					}
				}
				else
				{
					switch (num)
					{
					case 0x26:
					case 0x2D:
					case 0x39:
					case 0x3B:
					case 0x3E:
					case 0x45:
					case 0x48:
					case 0x4A:
						break;
					case 0x27:
					case 0x29:
					case 0x2A:
					case 0x2B:
					case 0x2C:
					case 0x2F:
					case 0x30:
					case 0x32:
					case 0x34:
					case 0x35:
					case 0x37:
					case 0x3C:
					case 0x3D:
					case 0x40:
					case 0x41:
					case 0x42:
					case 0x43:
					case 0x44:
					case 0x49:
						goto IL_275;
					case 0x28:
					case 0x2E:
					case 0x31:
					case 0x33:
					case 0x38:
					case 0x3A:
					case 0x3F:
					case 0x46:
					case 0x47:
					case 0x4B:
					case 0x4C:
						goto IL_25D;
					case 0x36:
						goto IL_26D;
					default:
						if (num != 0x58 && num != 0x65)
						{
							goto IL_275;
						}
						goto IL_25D;
					}
				}
			}
			else if (num <= 0x73)
			{
				if (num != 0x69)
				{
					if (num == 0x6C)
					{
						num2 = 3;
						goto IL_28C;
					}
					if (num != 0x73)
					{
						goto IL_275;
					}
					goto IL_25D;
				}
			}
			else
			{
				switch (num)
				{
				case 0x78:
				case 0x79:
				case 0x7B:
					goto IL_25D;
				case 0x7A:
					goto IL_275;
				default:
					if (num != 0x7F)
					{
						switch (num)
						{
						case 0x88:
						case 0x8F:
						case 0x92:
						case 0x94:
						case 0x9A:
						case 0x9B:
						case 0xA3:
							goto IL_25D;
						case 0x89:
						case 0x8A:
						case 0x8B:
						case 0x8C:
						case 0x8D:
						case 0x8E:
						case 0x90:
						case 0x91:
						case 0x95:
						case 0x96:
						case 0x97:
						case 0x9F:
						case 0xA0:
						case 0xA4:
							goto IL_275;
						case 0x93:
						case 0x98:
						case 0x99:
						case 0x9D:
						case 0x9E:
						case 0xA1:
						case 0xA2:
						case 0xA5:
						case 0xA6:
							break;
						case 0x9C:
							goto IL_26D;
						default:
							goto IL_275;
						}
					}
					break;
				}
			}
			num2 = 1;
			goto IL_28C;
			IL_25D:
			num2 = 2;
			goto IL_28C;
			IL_26D:
			num2 = 4;
			goto IL_28C;
			IL_275:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 2, 0, this.input);
			throw ex;
			IL_28C:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._keyword_in_reservedWord1781);
				global::ES3Parser.keyword_return keyword_return = this.keyword();
				base.PopFollow();
				this.adaptor.AddChild(obj, keyword_return.Tree);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._futureReservedWord_in_reservedWord1786);
				global::ES3Parser.futureReservedWord_return futureReservedWord_return = this.futureReservedWord();
				base.PopFollow();
				this.adaptor.AddChild(obj, futureReservedWord_return.Tree);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6C, global::ES3Parser.Follow._NULL_in_reservedWord1791);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._booleanLiteral_in_reservedWord1796);
				global::ES3Parser.booleanLiteral_return booleanLiteral_return = this.booleanLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, booleanLiteral_return.Tree);
				break;
			}
			}
			reservedWord_return.Stop = this.input.LT(-1);
			reservedWord_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(reservedWord_return.Tree, reservedWord_return.Start, reservedWord_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			reservedWord_return.Tree = this.adaptor.ErrorNode(this.input, reservedWord_return.Start, this.input.LT(-1), ex2);
		}
		return reservedWord_return;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000C9D4 File Offset: 0x0000ABD4
	[global::Antlr.Runtime.GrammarRule("keyword")]
	private global::ES3Parser.keyword_return keyword()
	{
		global::ES3Parser.keyword_return keyword_return = new global::ES3Parser.keyword_return(this);
		keyword_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = this.input.LT(1);
			if (this.input.LA(1) != 0xE && (this.input.LA(1) < 0x15 || this.input.LA(1) > 0x16) && (this.input.LA(1) != 0x1D && (this.input.LA(1) < 0x22 || this.input.LA(1) > 0x23)) && (this.input.LA(1) != 0x26 && this.input.LA(1) != 0x2D && this.input.LA(1) != 0x39 && this.input.LA(1) != 0x3B && this.input.LA(1) != 0x3E && this.input.LA(1) != 0x45 && this.input.LA(1) != 0x48 && this.input.LA(1) != 0x4A && this.input.LA(1) != 0x69 && this.input.LA(1) != 0x7F && this.input.LA(1) != 0x93 && (this.input.LA(1) < 0x98 || this.input.LA(1) > 0x99)) && (this.input.LA(1) < 0x9D || this.input.LA(1) > 0x9E) && (this.input.LA(1) < 0xA1 || this.input.LA(1) > 0xA2) && (this.input.LA(1) < 0xA5 || this.input.LA(1) > 0xA6))
			{
				global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
				throw ex;
			}
			this.input.Consume();
			this.adaptor.AddChild(obj, this.adaptor.Create(payload));
			this.state.errorRecovery = false;
			keyword_return.Stop = this.input.LT(-1);
			keyword_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(keyword_return.Tree, keyword_return.Start, keyword_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			keyword_return.Tree = this.adaptor.ErrorNode(this.input, keyword_return.Start, this.input.LT(-1), ex2);
		}
		return keyword_return;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000CCFC File Offset: 0x0000AEFC
	[global::Antlr.Runtime.GrammarRule("futureReservedWord")]
	private global::ES3Parser.futureReservedWord_return futureReservedWord()
	{
		global::ES3Parser.futureReservedWord_return futureReservedWord_return = new global::ES3Parser.futureReservedWord_return(this);
		futureReservedWord_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = this.input.LT(1);
			if (this.input.LA(1) != 4 && this.input.LA(1) != 0xD && this.input.LA(1) != 0x12 && (this.input.LA(1) < 0x18 || this.input.LA(1) > 0x19) && (this.input.LA(1) != 0x1C && this.input.LA(1) != 0x20 && this.input.LA(1) != 0x28 && this.input.LA(1) != 0x2E && this.input.LA(1) != 0x31 && this.input.LA(1) != 0x33 && this.input.LA(1) != 0x38 && this.input.LA(1) != 0x3A && this.input.LA(1) != 0x3F && (this.input.LA(1) < 0x46 || this.input.LA(1) > 0x47)) && (this.input.LA(1) < 0x4B || this.input.LA(1) > 0x4C) && (this.input.LA(1) != 0x58 && this.input.LA(1) != 0x65 && this.input.LA(1) != 0x73 && (this.input.LA(1) < 0x78 || this.input.LA(1) > 0x79)) && (this.input.LA(1) != 0x7B && this.input.LA(1) != 0x88 && this.input.LA(1) != 0x8F && this.input.LA(1) != 0x92 && this.input.LA(1) != 0x94 && (this.input.LA(1) < 0x9A || this.input.LA(1) > 0x9B)) && this.input.LA(1) != 0xA3)
			{
				global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
				throw ex;
			}
			this.input.Consume();
			this.adaptor.AddChild(obj, this.adaptor.Create(payload));
			this.state.errorRecovery = false;
			futureReservedWord_return.Stop = this.input.LT(-1);
			futureReservedWord_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(futureReservedWord_return.Tree, futureReservedWord_return.Start, futureReservedWord_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			futureReservedWord_return.Tree = this.adaptor.ErrorNode(this.input, futureReservedWord_return.Start, this.input.LT(-1), ex2);
		}
		return futureReservedWord_return;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0000D090 File Offset: 0x0000B290
	[global::Antlr.Runtime.GrammarRule("punctuator")]
	private global::ES3Parser.punctuator_return punctuator()
	{
		global::ES3Parser.punctuator_return punctuator_return = new global::ES3Parser.punctuator_return(this);
		punctuator_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = this.input.LT(1);
			if ((this.input.LA(1) < 5 || this.input.LA(1) > 8) && (this.input.LA(1) != 0xB && (this.input.LA(1) < 0x1A || this.input.LA(1) > 0x1B)) && (this.input.LA(1) != 0x21 && (this.input.LA(1) < 0x24 || this.input.LA(1) > 0x25)) && (this.input.LA(1) != 0x27 && this.input.LA(1) != 0x30 && (this.input.LA(1) < 0x40 || this.input.LA(1) > 0x41)) && (this.input.LA(1) != 0x49 && this.input.LA(1) != 0x4D && (this.input.LA(1) < 0x54 || this.input.LA(1) > 0x56)) && (this.input.LA(1) < 0x59 || this.input.LA(1) > 0x5A) && (this.input.LA(1) < 0x5C || this.input.LA(1) > 0x5D) && (this.input.LA(1) < 0x5F || this.input.LA(1) > 0x62) && (this.input.LA(1) != 0x68 && (this.input.LA(1) < 0x6A || this.input.LA(1) > 0x6B)) && (this.input.LA(1) < 0x6E || this.input.LA(1) > 0x6F) && (this.input.LA(1) < 0x7C || this.input.LA(1) > 0x7E) && (this.input.LA(1) != 0x80 && (this.input.LA(1) < 0x84 || this.input.LA(1) > 0x87)) && (this.input.LA(1) < 0x89 || this.input.LA(1) > 0x8C) && (this.input.LA(1) < 0x90 || this.input.LA(1) > 0x91) && (this.input.LA(1) < 0xA8 || this.input.LA(1) > 0xA9))
			{
				global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
				throw ex;
			}
			this.input.Consume();
			this.adaptor.AddChild(obj, this.adaptor.Create(payload));
			this.state.errorRecovery = false;
			punctuator_return.Stop = this.input.LT(-1);
			punctuator_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(punctuator_return.Tree, punctuator_return.Start, punctuator_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			punctuator_return.Tree = this.adaptor.ErrorNode(this.input, punctuator_return.Start, this.input.LT(-1), ex2);
		}
		return punctuator_return;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000D4AC File Offset: 0x0000B6AC
	[global::Antlr.Runtime.GrammarRule("literal")]
	private global::ES3Parser.literal_return literal()
	{
		global::ES3Parser.literal_return literal_return = new global::ES3Parser.literal_return(this);
		literal_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x6C)
			{
				if (num <= 0x36)
				{
					if (num == 0x2C)
					{
						goto IL_D5;
					}
					if (num != 0x36)
					{
						goto IL_ED;
					}
				}
				else
				{
					if (num == 0x44)
					{
						goto IL_D5;
					}
					if (num != 0x6C)
					{
						goto IL_ED;
					}
					num2 = 1;
					goto IL_104;
				}
			}
			else if (num <= 0x83)
			{
				if (num == 0x72)
				{
					goto IL_D5;
				}
				if (num != 0x83)
				{
					goto IL_ED;
				}
				num2 = 5;
				goto IL_104;
			}
			else
			{
				if (num == 0x96)
				{
					num2 = 4;
					goto IL_104;
				}
				if (num != 0x9C)
				{
					goto IL_ED;
				}
			}
			num2 = 2;
			goto IL_104;
			IL_D5:
			num2 = 3;
			goto IL_104;
			IL_ED:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 3, 0, this.input);
			throw ex;
			IL_104:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6C, global::ES3Parser.Follow._NULL_in_literal2483);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				literal_return.value = new global::Jint.Expressions.Identifier(token.Text);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._booleanLiteral_in_literal2492);
				global::ES3Parser.booleanLiteral_return booleanLiteral_return = this.booleanLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, booleanLiteral_return.Tree);
				literal_return.value = new global::Jint.Expressions.ValueExpression(booleanLiteral_return.value, global::System.TypeCode.Boolean);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._numericLiteral_in_literal2501);
				global::ES3Parser.numericLiteral_return numericLiteral_return = this.numericLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, numericLiteral_return.Tree);
				literal_return.value = new global::Jint.Expressions.ValueExpression(numericLiteral_return.value, global::System.TypeCode.Double);
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x96, global::ES3Parser.Follow._StringLiteral_in_literal2510);
				object child2 = this.adaptor.Create(token2);
				this.adaptor.AddChild(obj, child2);
				literal_return.value = new global::Jint.Expressions.ValueExpression(this.extractString(token2.Text), global::System.TypeCode.String);
				break;
			}
			case 5:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x83, global::ES3Parser.Follow._RegularExpressionLiteral_in_literal2520);
				object child3 = this.adaptor.Create(token3);
				this.adaptor.AddChild(obj, child3);
				literal_return.value = new global::Jint.Expressions.RegexpExpression(this.extractRegExpPattern(token3.Text), this.extractRegExpOption(token3.Text));
				break;
			}
			}
			literal_return.Stop = this.input.LT(-1);
			literal_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(literal_return.Tree, literal_return.Start, literal_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			literal_return.Tree = this.adaptor.ErrorNode(this.input, literal_return.Start, this.input.LT(-1), ex2);
		}
		return literal_return;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000D860 File Offset: 0x0000BA60
	[global::Antlr.Runtime.GrammarRule("booleanLiteral")]
	private global::ES3Parser.booleanLiteral_return booleanLiteral()
	{
		global::ES3Parser.booleanLiteral_return booleanLiteral_return = new global::ES3Parser.booleanLiteral_return(this);
		booleanLiteral_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num == 0x9C)
			{
				num2 = 1;
			}
			else
			{
				if (num != 0x36)
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 4, 0, this.input);
					throw ex;
				}
				num2 = 2;
			}
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x9C, global::ES3Parser.Follow._TRUE_in_booleanLiteral2537);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				booleanLiteral_return.value = true;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x36, global::ES3Parser.Follow._FALSE_in_booleanLiteral2544);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				booleanLiteral_return.value = false;
				break;
			}
			}
			booleanLiteral_return.Stop = this.input.LT(-1);
			booleanLiteral_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(booleanLiteral_return.Tree, booleanLiteral_return.Start, booleanLiteral_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			booleanLiteral_return.Tree = this.adaptor.ErrorNode(this.input, booleanLiteral_return.Start, this.input.LT(-1), ex2);
		}
		return booleanLiteral_return;
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0000DA3C File Offset: 0x0000BC3C
	[global::Antlr.Runtime.GrammarRule("numericLiteral")]
	private global::ES3Parser.numericLiteral_return numericLiteral()
	{
		global::ES3Parser.numericLiteral_return numericLiteral_return = new global::ES3Parser.numericLiteral_return(this);
		numericLiteral_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num != 0x2C)
			{
				if (num != 0x44)
				{
					if (num != 0x72)
					{
						global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 5, 0, this.input);
						throw ex;
					}
					num2 = 2;
				}
				else
				{
					num2 = 3;
				}
			}
			else
			{
				num2 = 1;
			}
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x2C, global::ES3Parser.Follow._DecimalLiteral_in_numericLiteral2755);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				numericLiteral_return.value = double.Parse(token.Text, global::System.Globalization.NumberStyles.Float, global::ES3Parser.numberFormatInfo);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x72, global::ES3Parser.Follow._OctalIntegerLiteral_in_numericLiteral2764);
				object child2 = this.adaptor.Create(token2);
				this.adaptor.AddChild(obj, child2);
				numericLiteral_return.value = (double)global::System.Convert.ToInt64(token2.Text, 8);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x44, global::ES3Parser.Follow._HexIntegerLiteral_in_numericLiteral2773);
				object child3 = this.adaptor.Create(token3);
				this.adaptor.AddChild(obj, child3);
				numericLiteral_return.value = (double)global::System.Convert.ToInt64(token3.Text, 0x10);
				break;
			}
			}
			numericLiteral_return.Stop = this.input.LT(-1);
			numericLiteral_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(numericLiteral_return.Tree, numericLiteral_return.Start, numericLiteral_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			numericLiteral_return.Tree = this.adaptor.ErrorNode(this.input, numericLiteral_return.Start, this.input.LT(-1), ex2);
		}
		return numericLiteral_return;
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0000DCB0 File Offset: 0x0000BEB0
	[global::Antlr.Runtime.GrammarRule("primaryExpression")]
	private global::ES3Parser.primaryExpression_return primaryExpression()
	{
		global::ES3Parser.primaryExpression_return primaryExpression_return = new global::ES3Parser.primaryExpression_return(this);
		primaryExpression_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x56)
			{
				if (num <= 0x36)
				{
					if (num != 0x2C && num != 0x36)
					{
						goto IL_12F;
					}
				}
				else if (num != 0x44)
				{
					if (num == 0x4F)
					{
						num2 = 2;
						goto IL_146;
					}
					switch (num)
					{
					case 0x55:
						num2 = 5;
						goto IL_146;
					case 0x56:
						num2 = 4;
						goto IL_146;
					default:
						goto IL_12F;
					}
				}
			}
			else if (num <= 0x72)
			{
				if (num == 0x5A)
				{
					num2 = 6;
					goto IL_146;
				}
				if (num != 0x6C && num != 0x72)
				{
					goto IL_12F;
				}
			}
			else if (num != 0x83)
			{
				switch (num)
				{
				case 0x96:
					break;
				case 0x97:
					goto IL_12F;
				case 0x98:
					num2 = 1;
					goto IL_146;
				default:
					if (num != 0x9C)
					{
						goto IL_12F;
					}
					break;
				}
			}
			num2 = 3;
			goto IL_146;
			IL_12F:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 6, 0, this.input);
			throw ex;
			IL_146:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x98, global::ES3Parser.Follow._THIS_in_primaryExpression3175);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				primaryExpression_return.value = new global::Jint.Expressions.Identifier(token.Text);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_primaryExpression3184);
				object child2 = this.adaptor.Create(token2);
				this.adaptor.AddChild(obj, child2);
				primaryExpression_return.value = new global::Jint.Expressions.Identifier(token2.Text);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._literal_in_primaryExpression3193);
				global::ES3Parser.literal_return literal_return = this.literal();
				base.PopFollow();
				this.adaptor.AddChild(obj, literal_return.Tree);
				primaryExpression_return.value = literal_return.value;
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._arrayLiteral_in_primaryExpression3202);
				global::ES3Parser.arrayLiteral_return arrayLiteral_return = this.arrayLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, arrayLiteral_return.Tree);
				primaryExpression_return.value = arrayLiteral_return.value;
				break;
			}
			case 5:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._objectLiteral_in_primaryExpression3211);
				global::ES3Parser.objectLiteral_return objectLiteral_return = this.objectLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, objectLiteral_return.Tree);
				primaryExpression_return.value = objectLiteral_return.value;
				break;
			}
			case 6:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_primaryExpression3220);
				object child3 = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child3);
				base.PushFollow(global::ES3Parser.Follow._expression_in_primaryExpression3224);
				global::ES3Parser.expression_return expression_return = this.expression();
				base.PopFollow();
				this.adaptor.AddChild(obj, expression_return.Tree);
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_primaryExpression3227);
				object child4 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child4);
				primaryExpression_return.value = expression_return.value;
				this._newExpressionIsUnary = (expression_return.value is global::Jint.Expressions.NewExpression);
				break;
			}
			}
			primaryExpression_return.Stop = this.input.LT(-1);
			primaryExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(primaryExpression_return.Tree, primaryExpression_return.Start, primaryExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			primaryExpression_return.Tree = this.adaptor.ErrorNode(this.input, primaryExpression_return.Start, this.input.LT(-1), ex2);
		}
		return primaryExpression_return;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0000E134 File Offset: 0x0000C334
	[global::Antlr.Runtime.GrammarRule("arrayLiteral")]
	private global::ES3Parser.arrayLiteral_return arrayLiteral()
	{
		global::ES3Parser.arrayLiteral_return arrayLiteral_return = new global::ES3Parser.arrayLiteral_return(this);
		arrayLiteral_return.Start = this.input.LT(1);
		arrayLiteral_return.value = new global::Jint.Expressions.ArrayDeclaration();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x56, global::ES3Parser.Follow._LBRACK_in_arrayLiteral3253);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 5 || num2 == 0x1B || num2 == 0x21 || num2 == 0x23 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3E || num2 == 0x44 || num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || num2 == 0x6C || num2 == 0x72 || num2 == 0x83 || num2 == 0x90 || num2 == 0x96 || num2 == 0x98 || num2 == 0x9C || num2 == 0x9E || num2 == 0xA2)
			{
				num = 1;
			}
			else if (num2 == 0x7E)
			{
				this.input.LA(2);
				if (this.input.LA(1) == 0x1B || this.input.LA(1) == 0x7E)
				{
					num = 1;
				}
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._arrayItem_in_arrayLiteral3259);
				global::ES3Parser.arrayItem_return arrayItem_return = this.arrayItem();
				base.PopFollow();
				this.adaptor.AddChild(obj, arrayItem_return.Tree);
				if (arrayItem_return.value != null)
				{
					arrayLiteral_return.value.Parameters.Add(arrayItem_return.value);
				}
				for (;;)
				{
					int num4 = 2;
					int num5 = this.input.LA(1);
					if (num5 == 0x1B)
					{
						num4 = 1;
					}
					int num6 = num4;
					if (num6 != 1)
					{
						break;
					}
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_arrayLiteral3265);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					base.PushFollow(global::ES3Parser.Follow._arrayItem_in_arrayLiteral3269);
					global::ES3Parser.arrayItem_return arrayItem_return2 = this.arrayItem();
					base.PopFollow();
					this.adaptor.AddChild(obj, arrayItem_return2.Tree);
					if (arrayItem_return2.value != null)
					{
						arrayLiteral_return.value.Parameters.Add(arrayItem_return2.value);
					}
				}
			}
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7E, global::ES3Parser.Follow._RBRACK_in_arrayLiteral3279);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			arrayLiteral_return.Stop = this.input.LT(-1);
			arrayLiteral_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(arrayLiteral_return.Tree, arrayLiteral_return.Start, arrayLiteral_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			arrayLiteral_return.Tree = this.adaptor.ErrorNode(this.input, arrayLiteral_return.Start, this.input.LT(-1), ex);
		}
		return arrayLiteral_return;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0000E4FC File Offset: 0x0000C6FC
	[global::Antlr.Runtime.GrammarRule("arrayItem")]
	private global::ES3Parser.arrayItem_return arrayItem()
	{
		global::ES3Parser.arrayItem_return arrayItem_return = new global::ES3Parser.arrayItem_return(this);
		arrayItem_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x4F)
			{
				if (num <= 0x2C)
				{
					if (num <= 0x1B)
					{
						if (num != 5)
						{
							if (num != 0x1B)
							{
								goto IL_25E;
							}
							this.input.LA(2);
							if (this.input.LA(1) == 0x1B)
							{
								num2 = 2;
								goto IL_276;
							}
							if (this.input.LA(1) == 0x7E)
							{
								num2 = 3;
								goto IL_276;
							}
							global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 9, 2, this.input);
							throw ex;
						}
					}
					else
					{
						switch (num)
						{
						case 0x21:
						case 0x23:
							break;
						case 0x22:
							goto IL_25E;
						default:
							if (num != 0x2C)
							{
								goto IL_25E;
							}
							break;
						}
					}
				}
				else if (num <= 0x3E)
				{
					if (num != 0x36 && num != 0x3E)
					{
						goto IL_25E;
					}
				}
				else if (num != 0x44 && num != 0x49)
				{
					switch (num)
					{
					case 0x4D:
					case 0x4F:
						break;
					case 0x4E:
						goto IL_25E;
					default:
						goto IL_25E;
					}
				}
			}
			else if (num <= 0x7E)
			{
				if (num <= 0x5A)
				{
					switch (num)
					{
					case 0x55:
					case 0x56:
						break;
					default:
						if (num != 0x5A)
						{
							goto IL_25E;
						}
						break;
					}
				}
				else
				{
					switch (num)
					{
					case 0x69:
					case 0x6A:
					case 0x6C:
						break;
					case 0x6B:
						goto IL_25E;
					default:
						if (num != 0x72)
						{
							if (num != 0x7E)
							{
								goto IL_25E;
							}
							this.input.LA(2);
							if (this.input.LA(1) == 0x1B)
							{
								num2 = 2;
								goto IL_276;
							}
							if (this.input.LA(1) == 0x7E)
							{
								num2 = 3;
								goto IL_276;
							}
							global::Antlr.Runtime.NoViableAltException ex2 = new global::Antlr.Runtime.NoViableAltException("", 9, 3, this.input);
							throw ex2;
						}
						break;
					}
				}
			}
			else if (num <= 0x90)
			{
				if (num != 0x83 && num != 0x90)
				{
					goto IL_25E;
				}
			}
			else
			{
				switch (num)
				{
				case 0x96:
				case 0x98:
					break;
				case 0x97:
					goto IL_25E;
				default:
					switch (num)
					{
					case 0x9C:
					case 0x9E:
						break;
					case 0x9D:
						goto IL_25E;
					default:
						if (num != 0xA2)
						{
							goto IL_25E;
						}
						break;
					}
					break;
				}
			}
			num2 = 1;
			goto IL_276;
			IL_25E:
			global::Antlr.Runtime.NoViableAltException ex3 = new global::Antlr.Runtime.NoViableAltException("", 9, 0, this.input);
			throw ex3;
			IL_276:
			switch (num2)
			{
			case 1:
			{
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_arrayItem3300);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
				arrayItem_return.value = assignmentExpression_return.value;
				break;
			}
			case 2:
				if (this.input.LA(1) != 0x1B)
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "arrayItem", " input.LA(1) == COMMA ");
				}
				arrayItem_return.value = new global::Jint.Expressions.Identifier("undefined");
				break;
			case 3:
				if (this.input.LA(1) != 0x7E)
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "arrayItem", " input.LA(1) == RBRACK ");
				}
				arrayItem_return.value = null;
				break;
			}
			arrayItem_return.Stop = this.input.LT(-1);
			arrayItem_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(arrayItem_return.Tree, arrayItem_return.Start, arrayItem_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex4)
		{
			this.ReportError(ex4);
			this.Recover(this.input, ex4);
			arrayItem_return.Tree = this.adaptor.ErrorNode(this.input, arrayItem_return.Start, this.input.LT(-1), ex4);
		}
		return arrayItem_return;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0000E8F0 File Offset: 0x0000CAF0
	[global::Antlr.Runtime.GrammarRule("objectLiteral")]
	private global::ES3Parser.objectLiteral_return objectLiteral()
	{
		global::ES3Parser.objectLiteral_return objectLiteral_return = new global::ES3Parser.objectLiteral_return(this);
		objectLiteral_return.Start = this.input.LT(1);
		objectLiteral_return.value = new global::Jint.Expressions.JsonExpression();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x55, global::ES3Parser.Follow._LBRACE_in_objectLiteral3341);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x2C || num2 == 0x44 || num2 == 0x4F || num2 == 0x72 || num2 == 0x96)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._propertyAssignment_in_objectLiteral3347);
				global::ES3Parser.propertyAssignment_return propertyAssignment_return = this.propertyAssignment();
				base.PopFollow();
				this.adaptor.AddChild(obj, propertyAssignment_return.Tree);
				objectLiteral_return.value.Push(propertyAssignment_return.value);
				for (;;)
				{
					int num4 = 2;
					int num5 = this.input.LA(1);
					if (num5 == 0x1B)
					{
						num4 = 1;
					}
					int num6 = num4;
					if (num6 != 1)
					{
						break;
					}
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_objectLiteral3354);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					base.PushFollow(global::ES3Parser.Follow._propertyAssignment_in_objectLiteral3358);
					global::ES3Parser.propertyAssignment_return propertyAssignment_return2 = this.propertyAssignment();
					base.PopFollow();
					this.adaptor.AddChild(obj, propertyAssignment_return2.Tree);
					objectLiteral_return.value.Push(propertyAssignment_return2.value);
				}
			}
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7D, global::ES3Parser.Follow._RBRACE_in_objectLiteral3368);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			objectLiteral_return.Stop = this.input.LT(-1);
			objectLiteral_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(objectLiteral_return.Tree, objectLiteral_return.Start, objectLiteral_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			objectLiteral_return.Tree = this.adaptor.ErrorNode(this.input, objectLiteral_return.Start, this.input.LT(-1), ex);
		}
		return objectLiteral_return;
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0000EB8C File Offset: 0x0000CD8C
	[global::Antlr.Runtime.GrammarRule("propertyAssignment")]
	private global::ES3Parser.propertyAssignment_return propertyAssignment()
	{
		global::ES3Parser.propertyAssignment_return propertyAssignment_return = new global::ES3Parser.propertyAssignment_return(this);
		propertyAssignment_return.Start = this.input.LT(1);
		object obj = null;
		propertyAssignment_return.value = new global::Jint.Expressions.PropertyDeclarationExpression();
		global::Jint.Expressions.FunctionExpression functionExpression = new global::Jint.Expressions.FunctionExpression();
		try
		{
			int num = this.input.LA(1);
			int num3;
			if (num == 0x4F)
			{
				int num2 = this.input.LA(2);
				if (num2 == 0x2C || num2 == 0x44 || num2 == 0x4F || num2 == 0x72 || num2 == 0x96)
				{
					num3 = 1;
				}
				else
				{
					if (num2 != 0x1A)
					{
						global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0xD, 1, this.input);
						throw ex;
					}
					num3 = 2;
				}
			}
			else
			{
				if (num != 0x2C && num != 0x44 && num != 0x72 && num != 0x96)
				{
					global::Antlr.Runtime.NoViableAltException ex2 = new global::Antlr.Runtime.NoViableAltException("", 0xD, 0, this.input);
					throw ex2;
				}
				num3 = 2;
			}
			switch (num3)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._accessor_in_propertyAssignment3391);
				global::ES3Parser.accessor_return accessor_return = this.accessor();
				base.PopFollow();
				this.adaptor.AddChild(obj, accessor_return.Tree);
				propertyAssignment_return.value.Mode = accessor_return.value;
				propertyAssignment_return.value.Expression = functionExpression;
				base.PushFollow(global::ES3Parser.Follow._propertyName_in_propertyAssignment3399);
				global::ES3Parser.propertyName_return propertyName_return = this.propertyName();
				base.PopFollow();
				this.adaptor.AddChild(obj, propertyName_return.Tree);
				propertyAssignment_return.value.Name = (functionExpression.Name = propertyName_return.value);
				int num4 = 2;
				int num5 = this.input.LA(1);
				if (num5 == 0x5A)
				{
					num4 = 1;
				}
				int num6 = num4;
				if (num6 == 1)
				{
					base.PushFollow(global::ES3Parser.Follow._formalParameterList_in_propertyAssignment3406);
					global::ES3Parser.formalParameterList_return formalParameterList_return = this.formalParameterList();
					base.PopFollow();
					this.adaptor.AddChild(obj, formalParameterList_return.Tree);
					functionExpression.Parameters.AddRange(formalParameterList_return.value);
				}
				base.PushFollow(global::ES3Parser.Follow._functionBody_in_propertyAssignment3414);
				global::ES3Parser.functionBody_return functionBody_return = this.functionBody();
				base.PopFollow();
				this.adaptor.AddChild(obj, functionBody_return.Tree);
				functionExpression.Statement = functionBody_return.value;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._propertyName_in_propertyAssignment3424);
				global::ES3Parser.propertyName_return propertyName_return2 = this.propertyName();
				base.PopFollow();
				this.adaptor.AddChild(obj, propertyName_return2.Tree);
				propertyAssignment_return.value.Name = propertyName_return2.value;
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1A, global::ES3Parser.Follow._COLON_in_propertyAssignment3428);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_propertyAssignment3432);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
				propertyAssignment_return.value.Expression = assignmentExpression_return.value;
				break;
			}
			}
			propertyAssignment_return.Stop = this.input.LT(-1);
			propertyAssignment_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(propertyAssignment_return.Tree, propertyAssignment_return.Start, propertyAssignment_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex3)
		{
			this.ReportError(ex3);
			this.Recover(this.input, ex3);
			propertyAssignment_return.Tree = this.adaptor.ErrorNode(this.input, propertyAssignment_return.Start, this.input.LT(-1), ex3);
		}
		return propertyAssignment_return;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0000EF74 File Offset: 0x0000D174
	[global::Antlr.Runtime.GrammarRule("accessor")]
	private global::ES3Parser.accessor_return accessor()
	{
		global::ES3Parser.accessor_return accessor_return = new global::ES3Parser.accessor_return(this);
		accessor_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_accessor3452);
			object child = this.adaptor.Create(token);
			this.adaptor.AddChild(obj, child);
			if (!(token.Text == "get") && !(token.Text == "set"))
			{
				throw new global::Antlr.Runtime.FailedPredicateException(this.input, "accessor", " ex1.Text==\"get\" || ex1.Text==\"set\" ");
			}
			if (token.Text == "get")
			{
				accessor_return.value = global::Jint.Expressions.PropertyExpressionType.Get;
			}
			if (token.Text == "set")
			{
				accessor_return.value = global::Jint.Expressions.PropertyExpressionType.Set;
			}
			accessor_return.Stop = this.input.LT(-1);
			accessor_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(accessor_return.Tree, accessor_return.Start, accessor_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			accessor_return.Tree = this.adaptor.ErrorNode(this.input, accessor_return.Start, this.input.LT(-1), ex);
		}
		return accessor_return;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
	[global::Antlr.Runtime.GrammarRule("propertyName")]
	private global::ES3Parser.propertyName_return propertyName()
	{
		global::ES3Parser.propertyName_return propertyName_return = new global::ES3Parser.propertyName_return(this);
		propertyName_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x44)
			{
				if (num != 0x2C && num != 0x44)
				{
					goto IL_94;
				}
			}
			else
			{
				if (num == 0x4F)
				{
					num2 = 1;
					goto IL_AC;
				}
				if (num != 0x72)
				{
					if (num != 0x96)
					{
						goto IL_94;
					}
					num2 = 2;
					goto IL_AC;
				}
			}
			num2 = 3;
			goto IL_AC;
			IL_94:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0xE, 0, this.input);
			throw ex;
			IL_AC:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_propertyName3474);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				propertyName_return.value = token.Text;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x96, global::ES3Parser.Follow._StringLiteral_in_propertyName3483);
				object child2 = this.adaptor.Create(token2);
				this.adaptor.AddChild(obj, child2);
				propertyName_return.value = this.extractString(token2.Text);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._numericLiteral_in_propertyName3492);
				global::ES3Parser.numericLiteral_return numericLiteral_return = this.numericLiteral();
				base.PopFollow();
				this.adaptor.AddChild(obj, numericLiteral_return.Tree);
				propertyName_return.value = numericLiteral_return.value.ToString();
				break;
			}
			}
			propertyName_return.Stop = this.input.LT(-1);
			propertyName_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(propertyName_return.Tree, propertyName_return.Start, propertyName_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			propertyName_return.Tree = this.adaptor.ErrorNode(this.input, propertyName_return.Start, this.input.LT(-1), ex2);
		}
		return propertyName_return;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0000F374 File Offset: 0x0000D574
	[global::Antlr.Runtime.GrammarRule("memberExpression")]
	private global::ES3Parser.memberExpression_return memberExpression()
	{
		global::ES3Parser.memberExpression_return memberExpression_return = new global::ES3Parser.memberExpression_return(this);
		memberExpression_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x56)
			{
				if (num <= 0x3E)
				{
					if (num != 0x2C && num != 0x36)
					{
						if (num != 0x3E)
						{
							goto IL_11A;
						}
						num2 = 2;
						goto IL_132;
					}
				}
				else if (num != 0x44 && num != 0x4F)
				{
					switch (num)
					{
					case 0x55:
					case 0x56:
						break;
					default:
						goto IL_11A;
					}
				}
			}
			else if (num <= 0x6C)
			{
				if (num != 0x5A)
				{
					if (num == 0x69)
					{
						num2 = 3;
						goto IL_132;
					}
					if (num != 0x6C)
					{
						goto IL_11A;
					}
				}
			}
			else if (num <= 0x83)
			{
				if (num != 0x72 && num != 0x83)
				{
					goto IL_11A;
				}
			}
			else
			{
				switch (num)
				{
				case 0x96:
				case 0x98:
					break;
				case 0x97:
					goto IL_11A;
				default:
					if (num != 0x9C)
					{
						goto IL_11A;
					}
					break;
				}
			}
			num2 = 1;
			goto IL_132;
			IL_11A:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0xF, 0, this.input);
			throw ex;
			IL_132:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._primaryExpression_in_memberExpression3518);
				global::ES3Parser.primaryExpression_return primaryExpression_return = this.primaryExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, primaryExpression_return.Tree);
				memberExpression_return.value = primaryExpression_return.value;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._functionExpression_in_memberExpression3527);
				global::ES3Parser.functionExpression_return functionExpression_return = this.functionExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, functionExpression_return.Tree);
				memberExpression_return.value = functionExpression_return.value;
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._newExpression_in_memberExpression3536);
				global::ES3Parser.newExpression_return newExpression_return = this.newExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, newExpression_return.Tree);
				memberExpression_return.value = newExpression_return.value;
				break;
			}
			}
			memberExpression_return.Stop = this.input.LT(-1);
			memberExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(memberExpression_return.Tree, memberExpression_return.Start, memberExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			memberExpression_return.Tree = this.adaptor.ErrorNode(this.input, memberExpression_return.Start, this.input.LT(-1), ex2);
		}
		return memberExpression_return;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000F650 File Offset: 0x0000D850
	[global::Antlr.Runtime.GrammarRule("newExpression")]
	private global::ES3Parser.newExpression_return newExpression()
	{
		global::ES3Parser.newExpression_return newExpression_return = new global::ES3Parser.newExpression_return(this);
		newExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x69, global::ES3Parser.Follow._NEW_in_newExpression3553);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			base.PushFollow(global::ES3Parser.Follow._memberExpression_in_newExpression3558);
			global::ES3Parser.memberExpression_return memberExpression_return = this.memberExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, memberExpression_return.Tree);
			newExpression_return.value = new global::Jint.Expressions.NewExpression(memberExpression_return.value);
			newExpression_return.Stop = this.input.LT(-1);
			newExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(newExpression_return.Tree, newExpression_return.Start, newExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			newExpression_return.Tree = this.adaptor.ErrorNode(this.input, newExpression_return.Start, this.input.LT(-1), ex);
		}
		return newExpression_return;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000F79C File Offset: 0x0000D99C
	[global::Antlr.Runtime.GrammarRule("arguments")]
	private global::ES3Parser.arguments_return arguments()
	{
		global::ES3Parser.arguments_return arguments_return = new global::ES3Parser.arguments_return(this);
		arguments_return.Start = this.input.LT(1);
		arguments_return.value = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_arguments3581);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 5 || num2 == 0x21 || num2 == 0x23 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3E || num2 == 0x44 || num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || num2 == 0x6C || num2 == 0x72 || num2 == 0x83 || num2 == 0x90 || num2 == 0x96 || num2 == 0x98 || num2 == 0x9C || num2 == 0x9E || num2 == 0xA2)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_arguments3587);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
				arguments_return.value.Add(assignmentExpression_return.value);
				for (;;)
				{
					int num4 = 2;
					int num5 = this.input.LA(1);
					if (num5 == 0x1B)
					{
						num4 = 1;
					}
					int num6 = num4;
					if (num6 != 1)
					{
						break;
					}
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_arguments3593);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_arguments3597);
					global::ES3Parser.assignmentExpression_return assignmentExpression_return2 = this.assignmentExpression();
					base.PopFollow();
					this.adaptor.AddChild(obj, assignmentExpression_return2.Tree);
					arguments_return.value.Add(assignmentExpression_return2.value);
				}
			}
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_arguments3606);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			arguments_return.Stop = this.input.LT(-1);
			arguments_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(arguments_return.Tree, arguments_return.Start, arguments_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			arguments_return.Tree = this.adaptor.ErrorNode(this.input, arguments_return.Start, this.input.LT(-1), ex);
		}
		return arguments_return;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0000FAF8 File Offset: 0x0000DCF8
	[global::Antlr.Runtime.GrammarRule("generics")]
	private global::ES3Parser.generics_return generics()
	{
		global::ES3Parser.generics_return generics_return = new global::ES3Parser.generics_return(this);
		generics_return.Start = this.input.LT(1);
		generics_return.value = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x55, global::ES3Parser.Follow._LBRACE_in_generics3628);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 5 || num2 == 0x21 || num2 == 0x23 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3E || num2 == 0x44 || num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || num2 == 0x6C || num2 == 0x72 || num2 == 0x83 || num2 == 0x90 || num2 == 0x96 || num2 == 0x98 || num2 == 0x9C || num2 == 0x9E || num2 == 0xA2)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_generics3634);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
				generics_return.value.Add(assignmentExpression_return.value);
				for (;;)
				{
					int num4 = 2;
					int num5 = this.input.LA(1);
					if (num5 == 0x1B)
					{
						num4 = 1;
					}
					int num6 = num4;
					if (num6 != 1)
					{
						break;
					}
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_generics3640);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_generics3644);
					global::ES3Parser.assignmentExpression_return assignmentExpression_return2 = this.assignmentExpression();
					base.PopFollow();
					this.adaptor.AddChild(obj, assignmentExpression_return2.Tree);
					generics_return.value.Add(assignmentExpression_return2.value);
				}
			}
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7D, global::ES3Parser.Follow._RBRACE_in_generics3653);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			generics_return.Stop = this.input.LT(-1);
			generics_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(generics_return.Tree, generics_return.Start, generics_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			generics_return.Tree = this.adaptor.ErrorNode(this.input, generics_return.Start, this.input.LT(-1), ex);
		}
		return generics_return;
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000FE50 File Offset: 0x0000E050
	[global::Antlr.Runtime.GrammarRule("leftHandSideExpression")]
	private global::ES3Parser.leftHandSideExpression_return leftHandSideExpression()
	{
		global::ES3Parser.leftHandSideExpression_return leftHandSideExpression_return = new global::ES3Parser.leftHandSideExpression_return(this);
		leftHandSideExpression_return.Start = this.input.LT(1);
		global::System.Collections.Generic.List<global::Jint.Expressions.Expression> generics = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._memberExpression_in_leftHandSideExpression3689);
			global::ES3Parser.memberExpression_return memberExpression_return = this.memberExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, memberExpression_return.Tree);
			leftHandSideExpression_return.value = memberExpression_return.value;
			for (;;)
			{
				int num = 4;
				int num2 = this.input.LA(1);
				if (num2 != 0x27)
				{
					switch (num2)
					{
					case 0x55:
						break;
					case 0x56:
						num = 2;
						goto IL_D1;
					default:
						if (num2 != 0x5A)
						{
							goto IL_D1;
						}
						break;
					}
					num = 1;
				}
				else
				{
					num = 3;
				}
				IL_D1:
				switch (num)
				{
				case 1:
				{
					int num3 = 2;
					int num4 = this.input.LA(1);
					if (num4 == 0x55)
					{
						num3 = 1;
					}
					int num5 = num3;
					if (num5 == 1)
					{
						base.PushFollow(global::ES3Parser.Follow._generics_in_leftHandSideExpression3705);
						global::ES3Parser.generics_return generics_return = this.generics();
						base.PopFollow();
						this.adaptor.AddChild(obj, generics_return.Tree);
						generics = generics_return.value;
					}
					base.PushFollow(global::ES3Parser.Follow._arguments_in_leftHandSideExpression3714);
					global::ES3Parser.arguments_return arguments_return = this.arguments();
					base.PopFollow();
					this.adaptor.AddChild(obj, arguments_return.Tree);
					if (leftHandSideExpression_return.value is global::Jint.Expressions.NewExpression && !this._newExpressionIsUnary)
					{
						((global::Jint.Expressions.NewExpression)leftHandSideExpression_return.value).Generics = generics;
						((global::Jint.Expressions.NewExpression)leftHandSideExpression_return.value).Arguments = arguments_return.value;
						leftHandSideExpression_return.value = new global::Jint.Expressions.MemberExpression(leftHandSideExpression_return.value, null);
						continue;
					}
					leftHandSideExpression_return.value = new global::Jint.Expressions.MemberExpression(new global::Jint.Expressions.MethodCall(arguments_return.value)
					{
						Generics = generics
					}, leftHandSideExpression_return.value);
					continue;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x56, global::ES3Parser.Follow._LBRACK_in_leftHandSideExpression3725);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					base.PushFollow(global::ES3Parser.Follow._expression_in_leftHandSideExpression3729);
					global::ES3Parser.expression_return expression_return = this.expression();
					base.PopFollow();
					this.adaptor.AddChild(obj, expression_return.Tree);
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7E, global::ES3Parser.Follow._RBRACK_in_leftHandSideExpression3731);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					leftHandSideExpression_return.value = new global::Jint.Expressions.MemberExpression(new global::Jint.Expressions.Indexer(expression_return.value), leftHandSideExpression_return.value);
					continue;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x27, global::ES3Parser.Follow._DOT_in_leftHandSideExpression3744);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_leftHandSideExpression3748);
					object child4 = this.adaptor.Create(token);
					this.adaptor.AddChild(obj, child4);
					if (leftHandSideExpression_return.value is global::Jint.Expressions.NewExpression && !this._newExpressionIsUnary)
					{
						((global::Jint.Expressions.NewExpression)leftHandSideExpression_return.value).Expression = new global::Jint.Expressions.MemberExpression(new global::Jint.Expressions.PropertyExpression(token.Text), ((global::Jint.Expressions.NewExpression)leftHandSideExpression_return.value).Expression);
						continue;
					}
					leftHandSideExpression_return.value = new global::Jint.Expressions.MemberExpression(new global::Jint.Expressions.PropertyExpression(token.Text), leftHandSideExpression_return.value);
					continue;
				}
				}
				break;
			}
			leftHandSideExpression_return.Stop = this.input.LT(-1);
			leftHandSideExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(leftHandSideExpression_return.Tree, leftHandSideExpression_return.Start, leftHandSideExpression_return.Stop);
			leftHandSideExpression_return.value.Source = this.ExtractSourceCode((global::Antlr.Runtime.CommonToken)leftHandSideExpression_return.Start, (global::Antlr.Runtime.CommonToken)leftHandSideExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			leftHandSideExpression_return.Tree = this.adaptor.ErrorNode(this.input, leftHandSideExpression_return.Start, this.input.LT(-1), ex);
		}
		return leftHandSideExpression_return;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x000102CC File Offset: 0x0000E4CC
	[global::Antlr.Runtime.GrammarRule("postfixExpression")]
	private global::ES3Parser.postfixExpression_return postfixExpression()
	{
		global::ES3Parser.postfixExpression_return postfixExpression_return = new global::ES3Parser.postfixExpression_return(this);
		postfixExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._leftHandSideExpression_in_postfixExpression3782);
			global::ES3Parser.leftHandSideExpression_return leftHandSideExpression_return = this.leftHandSideExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, leftHandSideExpression_return.Tree);
			postfixExpression_return.value = leftHandSideExpression_return.value;
			if (this.input.LA(1) == 0x49 || this.input.LA(1) == 0x21)
			{
				this.PromoteEOL(null);
			}
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x21 || num2 == 0x49)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._postfixOperator_in_postfixExpression3790);
				global::ES3Parser.postfixOperator_return postfixOperator_return = this.postfixOperator();
				base.PopFollow();
				obj = this.adaptor.BecomeRoot(postfixOperator_return.Tree, obj);
				postfixExpression_return.value = new global::Jint.Expressions.UnaryExpression(postfixOperator_return.value, postfixExpression_return.value);
			}
			postfixExpression_return.Stop = this.input.LT(-1);
			postfixExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(postfixExpression_return.Tree, postfixExpression_return.Start, postfixExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			postfixExpression_return.Tree = this.adaptor.ErrorNode(this.input, postfixExpression_return.Start, this.input.LT(-1), ex);
		}
		return postfixExpression_return;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00010488 File Offset: 0x0000E688
	[global::Antlr.Runtime.GrammarRule("postfixOperator")]
	private global::ES3Parser.postfixOperator_return postfixOperator()
	{
		global::ES3Parser.postfixOperator_return postfixOperator_return = new global::ES3Parser.postfixOperator_return(this);
		postfixOperator_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num == 0x49)
			{
				num2 = 1;
			}
			else
			{
				if (num != 0x21)
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x17, 0, this.input);
					throw ex;
				}
				num2 = 2;
			}
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x49, global::ES3Parser.Follow._INC_in_postfixOperator3813);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				token.Type = 0x76;
				postfixOperator_return.value = global::Jint.Expressions.UnaryExpressionType.PostfixPlusPlus;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x21, global::ES3Parser.Follow._DEC_in_postfixOperator3822);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				token.Type = 0x75;
				postfixOperator_return.value = global::Jint.Expressions.UnaryExpressionType.PostfixMinusMinus;
				break;
			}
			}
			postfixOperator_return.Stop = this.input.LT(-1);
			postfixOperator_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(postfixOperator_return.Tree, postfixOperator_return.Start, postfixOperator_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			postfixOperator_return.Tree = this.adaptor.ErrorNode(this.input, postfixOperator_return.Start, this.input.LT(-1), ex2);
		}
		return postfixOperator_return;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00010668 File Offset: 0x0000E868
	[global::Antlr.Runtime.GrammarRule("unaryExpression")]
	private global::ES3Parser.unaryExpression_return unaryExpression()
	{
		global::ES3Parser.unaryExpression_return unaryExpression_return = new global::ES3Parser.unaryExpression_return(this);
		unaryExpression_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num == 0x2C || num == 0x36 || num == 0x3E || num == 0x44 || num == 0x4F || (num >= 0x55 && num <= 0x56) || num == 0x5A || num == 0x69 || num == 0x6C || num == 0x72 || num == 0x83 || num == 0x96 || num == 0x98 || num == 0x9C)
			{
				num2 = 1;
			}
			else
			{
				if (num != 5 && num != 0x21 && num != 0x23 && num != 0x49 && num != 0x4D && num != 0x6A && num != 0x90 && num != 0x9E && num != 0xA2)
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x18, 0, this.input);
					throw ex;
				}
				num2 = 2;
			}
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._postfixExpression_in_unaryExpression3845);
				global::ES3Parser.postfixExpression_return postfixExpression_return = this.postfixExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, postfixExpression_return.Tree);
				unaryExpression_return.value = postfixExpression_return.value;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._unaryOperator_in_unaryExpression3854);
				global::ES3Parser.unaryOperator_return unaryOperator_return = this.unaryOperator();
				base.PopFollow();
				obj = this.adaptor.BecomeRoot(unaryOperator_return.Tree, obj);
				base.PushFollow(global::ES3Parser.Follow._unaryExpression_in_unaryExpression3859);
				global::ES3Parser.unaryExpression_return unaryExpression_return2 = this.unaryExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, unaryExpression_return2.Tree);
				unaryExpression_return.value = new global::Jint.Expressions.UnaryExpression(unaryOperator_return.value, unaryExpression_return2.value);
				break;
			}
			}
			unaryExpression_return.Stop = this.input.LT(-1);
			unaryExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(unaryExpression_return.Tree, unaryExpression_return.Start, unaryExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			unaryExpression_return.Tree = this.adaptor.ErrorNode(this.input, unaryExpression_return.Start, this.input.LT(-1), ex2);
		}
		return unaryExpression_return;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00010944 File Offset: 0x0000EB44
	[global::Antlr.Runtime.GrammarRule("unaryOperator")]
	private global::ES3Parser.unaryOperator_return unaryOperator()
	{
		global::ES3Parser.unaryOperator_return unaryOperator_return = new global::ES3Parser.unaryOperator_return(this);
		unaryOperator_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x4D)
			{
				if (num <= 0x23)
				{
					if (num == 5)
					{
						num2 = 6;
						goto IL_14B;
					}
					switch (num)
					{
					case 0x21:
						num2 = 5;
						goto IL_14B;
					case 0x23:
						num2 = 1;
						goto IL_14B;
					}
				}
				else
				{
					if (num == 0x49)
					{
						num2 = 4;
						goto IL_14B;
					}
					if (num == 0x4D)
					{
						num2 = 8;
						goto IL_14B;
					}
				}
			}
			else if (num <= 0x90)
			{
				if (num == 0x6A)
				{
					num2 = 9;
					goto IL_14B;
				}
				if (num == 0x90)
				{
					num2 = 7;
					goto IL_14B;
				}
			}
			else
			{
				if (num == 0x9E)
				{
					num2 = 3;
					goto IL_14B;
				}
				if (num == 0xA2)
				{
					num2 = 2;
					goto IL_14B;
				}
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x19, 0, this.input);
			throw ex;
			IL_14B:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x23, global::ES3Parser.Follow._DELETE_in_unaryOperator3877);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.Delete;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA2, global::ES3Parser.Follow._VOID_in_unaryOperator3884);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.Void;
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x9E, global::ES3Parser.Follow._TYPEOF_in_unaryOperator3891);
				object child3 = this.adaptor.Create(payload3);
				this.adaptor.AddChild(obj, child3);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.TypeOf;
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x49, global::ES3Parser.Follow._INC_in_unaryOperator3898);
				object child4 = this.adaptor.Create(payload4);
				this.adaptor.AddChild(obj, child4);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.PrefixPlusPlus;
				break;
			}
			case 5:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload5 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x21, global::ES3Parser.Follow._DEC_in_unaryOperator3905);
				object child5 = this.adaptor.Create(payload5);
				this.adaptor.AddChild(obj, child5);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.PrefixMinusMinus;
				break;
			}
			case 6:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 5, global::ES3Parser.Follow._ADD_in_unaryOperator3914);
				object child6 = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child6);
				token.Type = 0x77;
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.Positive;
				break;
			}
			case 7:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x90, global::ES3Parser.Follow._SUB_in_unaryOperator3923);
				object child6 = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child6);
				token.Type = 0x67;
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.Negate;
				break;
			}
			case 8:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload6 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4D, global::ES3Parser.Follow._INV_in_unaryOperator3930);
				object child7 = this.adaptor.Create(payload6);
				this.adaptor.AddChild(obj, child7);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.Inv;
				break;
			}
			case 9:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload7 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6A, global::ES3Parser.Follow._NOT_in_unaryOperator3937);
				object child8 = this.adaptor.Create(payload7);
				this.adaptor.AddChild(obj, child8);
				unaryOperator_return.value = global::Jint.Expressions.UnaryExpressionType.Not;
				break;
			}
			}
			unaryOperator_return.Stop = this.input.LT(-1);
			unaryOperator_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(unaryOperator_return.Tree, unaryOperator_return.Start, unaryOperator_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			unaryOperator_return.Tree = this.adaptor.ErrorNode(this.input, unaryOperator_return.Start, this.input.LT(-1), ex2);
		}
		return unaryOperator_return;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00010E54 File Offset: 0x0000F054
	[global::Antlr.Runtime.GrammarRule("multiplicativeExpression")]
	private global::ES3Parser.multiplicativeExpression_return multiplicativeExpression()
	{
		global::ES3Parser.multiplicativeExpression_return multiplicativeExpression_return = new global::ES3Parser.multiplicativeExpression_return(this);
		multiplicativeExpression_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._unaryExpression_in_multiplicativeExpression3965);
			global::ES3Parser.unaryExpression_return unaryExpression_return = this.unaryExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, unaryExpression_return.Tree);
			multiplicativeExpression_return.value = unaryExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x24 || num2 == 0x5F || num2 == 0x61)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_23A;
				}
				int num4 = this.input.LA(1);
				int num5;
				if (num4 != 0x24)
				{
					switch (num4)
					{
					case 0x5F:
						num5 = 3;
						goto IL_11A;
					case 0x61:
						num5 = 1;
						goto IL_11A;
					}
					break;
				}
				num5 = 2;
				IL_11A:
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x61, global::ES3Parser.Follow._MUL_in_multiplicativeExpression3976);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.Times;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x24, global::ES3Parser.Follow._DIV_in_multiplicativeExpression3985);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.Div;
					break;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5F, global::ES3Parser.Follow._MOD_in_multiplicativeExpression3993);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					type = global::Jint.Expressions.BinaryExpressionType.Modulo;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._unaryExpression_in_multiplicativeExpression4004);
				global::ES3Parser.unaryExpression_return unaryExpression_return2 = this.unaryExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, unaryExpression_return2.Tree);
				multiplicativeExpression_return.value = new global::Jint.Expressions.BinaryExpression(type, multiplicativeExpression_return.value, unaryExpression_return2.value);
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x1A, 0, this.input);
			throw ex;
			IL_23A:
			multiplicativeExpression_return.Stop = this.input.LT(-1);
			multiplicativeExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(multiplicativeExpression_return.Tree, multiplicativeExpression_return.Start, multiplicativeExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			multiplicativeExpression_return.Tree = this.adaptor.ErrorNode(this.input, multiplicativeExpression_return.Start, this.input.LT(-1), ex2);
		}
		return multiplicativeExpression_return;
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00011148 File Offset: 0x0000F348
	[global::Antlr.Runtime.GrammarRule("additiveExpression")]
	private global::ES3Parser.additiveExpression_return additiveExpression()
	{
		global::ES3Parser.additiveExpression_return additiveExpression_return = new global::ES3Parser.additiveExpression_return(this);
		additiveExpression_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._multiplicativeExpression_in_additiveExpression4034);
			global::ES3Parser.multiplicativeExpression_return multiplicativeExpression_return = this.multiplicativeExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, multiplicativeExpression_return.Tree);
			additiveExpression_return.value = multiplicativeExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 5 || num2 == 0x90)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_1D2;
				}
				int num4 = this.input.LA(1);
				int num5;
				if (num4 == 5)
				{
					num5 = 1;
				}
				else
				{
					if (num4 != 0x90)
					{
						break;
					}
					num5 = 2;
				}
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 5, global::ES3Parser.Follow._ADD_in_additiveExpression4045);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.Plus;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x90, global::ES3Parser.Follow._SUB_in_additiveExpression4053);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.Minus;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._multiplicativeExpression_in_additiveExpression4064);
				global::ES3Parser.multiplicativeExpression_return multiplicativeExpression_return2 = this.multiplicativeExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, multiplicativeExpression_return2.Tree);
				additiveExpression_return.value = new global::Jint.Expressions.BinaryExpression(type, additiveExpression_return.value, multiplicativeExpression_return2.value);
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x1C, 0, this.input);
			throw ex;
			IL_1D2:
			additiveExpression_return.Stop = this.input.LT(-1);
			additiveExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(additiveExpression_return.Tree, additiveExpression_return.Start, additiveExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			additiveExpression_return.Tree = this.adaptor.ErrorNode(this.input, additiveExpression_return.Start, this.input.LT(-1), ex2);
		}
		return additiveExpression_return;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x000113D4 File Offset: 0x0000F5D4
	[global::Antlr.Runtime.GrammarRule("shiftExpression")]
	private global::ES3Parser.shiftExpression_return shiftExpression()
	{
		global::ES3Parser.shiftExpression_return shiftExpression_return = new global::ES3Parser.shiftExpression_return(this);
		shiftExpression_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._additiveExpression_in_shiftExpression4095);
			global::ES3Parser.additiveExpression_return additiveExpression_return = this.additiveExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, additiveExpression_return.Tree);
			shiftExpression_return.value = additiveExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x86 || num2 == 0x89 || num2 == 0x8B)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_252;
				}
				int num4 = this.input.LA(1);
				int num5;
				if (num4 != 0x86)
				{
					switch (num4)
					{
					case 0x89:
						num5 = 2;
						goto IL_129;
					case 0x8B:
						num5 = 3;
						goto IL_129;
					}
					break;
				}
				num5 = 1;
				IL_129:
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x86, global::ES3Parser.Follow._SHL_in_shiftExpression4106);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.LeftShift;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x89, global::ES3Parser.Follow._SHR_in_shiftExpression4114);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.RightShift;
					break;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x8B, global::ES3Parser.Follow._SHU_in_shiftExpression4122);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					type = global::Jint.Expressions.BinaryExpressionType.UnsignedRightShift;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._additiveExpression_in_shiftExpression4133);
				global::ES3Parser.additiveExpression_return additiveExpression_return2 = this.additiveExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, additiveExpression_return2.Tree);
				shiftExpression_return.value = new global::Jint.Expressions.BinaryExpression(type, shiftExpression_return.value, additiveExpression_return2.value);
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x1E, 0, this.input);
			throw ex;
			IL_252:
			shiftExpression_return.Stop = this.input.LT(-1);
			shiftExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(shiftExpression_return.Tree, shiftExpression_return.Start, shiftExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			shiftExpression_return.Tree = this.adaptor.ErrorNode(this.input, shiftExpression_return.Start, this.input.LT(-1), ex2);
		}
		return shiftExpression_return;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x000116E0 File Offset: 0x0000F8E0
	[global::Antlr.Runtime.GrammarRule("relationalExpression")]
	private global::ES3Parser.relationalExpression_return relationalExpression()
	{
		global::ES3Parser.relationalExpression_return relationalExpression_return = new global::ES3Parser.relationalExpression_return(this);
		relationalExpression_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._shiftExpression_in_relationalExpression4164);
			global::ES3Parser.shiftExpression_return shiftExpression_return = this.shiftExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, shiftExpression_return.Tree);
			relationalExpression_return.value = shiftExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if ((num2 >= 0x40 && num2 <= 0x41) || num2 == 0x48 || num2 == 0x4A || (num2 >= 0x5C && num2 <= 0x5D))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_362;
				}
				int num4 = this.input.LA(1);
				int num5;
				switch (num4)
				{
				case 0x40:
					num5 = 2;
					break;
				case 0x41:
					num5 = 4;
					break;
				default:
					switch (num4)
					{
					case 0x48:
						num5 = 6;
						break;
					case 0x49:
						goto IL_162;
					case 0x4A:
						num5 = 5;
						break;
					default:
						switch (num4)
						{
						case 0x5C:
							num5 = 1;
							goto IL_17A;
						case 0x5D:
							num5 = 3;
							goto IL_17A;
						}
						goto Block_10;
					}
					break;
				}
				IL_17A:
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5C, global::ES3Parser.Follow._LT_in_relationalExpression4175);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.Lesser;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x40, global::ES3Parser.Follow._GT_in_relationalExpression4183);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.Greater;
					break;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5D, global::ES3Parser.Follow._LTE_in_relationalExpression4191);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					type = global::Jint.Expressions.BinaryExpressionType.LesserOrEqual;
					break;
				}
				case 4:
				{
					global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x41, global::ES3Parser.Follow._GTE_in_relationalExpression4199);
					object child4 = this.adaptor.Create(payload4);
					this.adaptor.AddChild(obj, child4);
					type = global::Jint.Expressions.BinaryExpressionType.GreaterOrEqual;
					break;
				}
				case 5:
				{
					global::Antlr.Runtime.IToken payload5 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4A, global::ES3Parser.Follow._INSTANCEOF_in_relationalExpression4207);
					object child5 = this.adaptor.Create(payload5);
					this.adaptor.AddChild(obj, child5);
					type = global::Jint.Expressions.BinaryExpressionType.InstanceOf;
					break;
				}
				case 6:
				{
					global::Antlr.Runtime.IToken payload6 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x48, global::ES3Parser.Follow._IN_in_relationalExpression4215);
					object child6 = this.adaptor.Create(payload6);
					this.adaptor.AddChild(obj, child6);
					type = global::Jint.Expressions.BinaryExpressionType.In;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._shiftExpression_in_relationalExpression4226);
				global::ES3Parser.shiftExpression_return shiftExpression_return2 = this.shiftExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, shiftExpression_return2.Tree);
				relationalExpression_return.value = new global::Jint.Expressions.BinaryExpression(type, relationalExpression_return.value, shiftExpression_return2.value);
			}
			Block_10:
			IL_162:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x20, 0, this.input);
			throw ex;
			IL_362:
			relationalExpression_return.Stop = this.input.LT(-1);
			relationalExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(relationalExpression_return.Tree, relationalExpression_return.Start, relationalExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			relationalExpression_return.Tree = this.adaptor.ErrorNode(this.input, relationalExpression_return.Start, this.input.LT(-1), ex2);
		}
		return relationalExpression_return;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00011AFC File Offset: 0x0000FCFC
	[global::Antlr.Runtime.GrammarRule("relationalExpressionNoIn")]
	private global::ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn()
	{
		global::ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn_return = new global::ES3Parser.relationalExpressionNoIn_return(this);
		relationalExpressionNoIn_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._shiftExpression_in_relationalExpressionNoIn4252);
			global::ES3Parser.shiftExpression_return shiftExpression_return = this.shiftExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, shiftExpression_return.Tree);
			relationalExpressionNoIn_return.value = shiftExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if ((num2 >= 0x40 && num2 <= 0x41) || num2 == 0x4A || (num2 >= 0x5C && num2 <= 0x5D))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_2FA;
				}
				int num4 = this.input.LA(1);
				int num5;
				switch (num4)
				{
				case 0x40:
					num5 = 2;
					break;
				case 0x41:
					num5 = 4;
					break;
				default:
					if (num4 != 0x4A)
					{
						switch (num4)
						{
						case 0x5C:
							num5 = 1;
							goto IL_156;
						case 0x5D:
							num5 = 3;
							goto IL_156;
						}
						goto Block_9;
					}
					num5 = 5;
					break;
				}
				IL_156:
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5C, global::ES3Parser.Follow._LT_in_relationalExpressionNoIn4263);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.Lesser;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x40, global::ES3Parser.Follow._GT_in_relationalExpressionNoIn4271);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.Greater;
					break;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5D, global::ES3Parser.Follow._LTE_in_relationalExpressionNoIn4279);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					type = global::Jint.Expressions.BinaryExpressionType.LesserOrEqual;
					break;
				}
				case 4:
				{
					global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x41, global::ES3Parser.Follow._GTE_in_relationalExpressionNoIn4287);
					object child4 = this.adaptor.Create(payload4);
					this.adaptor.AddChild(obj, child4);
					type = global::Jint.Expressions.BinaryExpressionType.GreaterOrEqual;
					break;
				}
				case 5:
				{
					global::Antlr.Runtime.IToken payload5 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4A, global::ES3Parser.Follow._INSTANCEOF_in_relationalExpressionNoIn4295);
					object child5 = this.adaptor.Create(payload5);
					this.adaptor.AddChild(obj, child5);
					type = global::Jint.Expressions.BinaryExpressionType.InstanceOf;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._shiftExpression_in_relationalExpressionNoIn4307);
				global::ES3Parser.shiftExpression_return shiftExpression_return2 = this.shiftExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, shiftExpression_return2.Tree);
				relationalExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(type, relationalExpressionNoIn_return.value, shiftExpression_return2.value);
			}
			Block_9:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x22, 0, this.input);
			throw ex;
			IL_2FA:
			relationalExpressionNoIn_return.Stop = this.input.LT(-1);
			relationalExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(relationalExpressionNoIn_return.Tree, relationalExpressionNoIn_return.Start, relationalExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			relationalExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, relationalExpressionNoIn_return.Start, this.input.LT(-1), ex2);
		}
		return relationalExpressionNoIn_return;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00011EB0 File Offset: 0x000100B0
	[global::Antlr.Runtime.GrammarRule("equalityExpression")]
	private global::ES3Parser.equalityExpression_return equalityExpression()
	{
		global::ES3Parser.equalityExpression_return equalityExpression_return = new global::ES3Parser.equalityExpression_return(this);
		equalityExpression_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._relationalExpression_in_equalityExpression4338);
			global::ES3Parser.relationalExpression_return relationalExpression_return = this.relationalExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, relationalExpression_return.Tree);
			equalityExpression_return.value = relationalExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x30 || num2 == 0x68 || num2 == 0x6B || num2 == 0x84)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_2AF;
				}
				int num4 = this.input.LA(1);
				int num5;
				if (num4 <= 0x68)
				{
					if (num4 != 0x30)
					{
						if (num4 != 0x68)
						{
							break;
						}
						num5 = 2;
					}
					else
					{
						num5 = 1;
					}
				}
				else if (num4 != 0x6B)
				{
					if (num4 != 0x84)
					{
						break;
					}
					num5 = 3;
				}
				else
				{
					num5 = 4;
				}
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x30, global::ES3Parser.Follow._EQ_in_equalityExpression4349);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.Equal;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x68, global::ES3Parser.Follow._NEQ_in_equalityExpression4357);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.NotEqual;
					break;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x84, global::ES3Parser.Follow._SAME_in_equalityExpression4365);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					type = global::Jint.Expressions.BinaryExpressionType.Same;
					break;
				}
				case 4:
				{
					global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6B, global::ES3Parser.Follow._NSAME_in_equalityExpression4373);
					object child4 = this.adaptor.Create(payload4);
					this.adaptor.AddChild(obj, child4);
					type = global::Jint.Expressions.BinaryExpressionType.NotSame;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._relationalExpression_in_equalityExpression4384);
				global::ES3Parser.relationalExpression_return relationalExpression_return2 = this.relationalExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, relationalExpression_return2.Tree);
				equalityExpression_return.value = new global::Jint.Expressions.BinaryExpression(type, equalityExpression_return.value, relationalExpression_return2.value);
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x24, 0, this.input);
			throw ex;
			IL_2AF:
			equalityExpression_return.Stop = this.input.LT(-1);
			equalityExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(equalityExpression_return.Tree, equalityExpression_return.Start, equalityExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			equalityExpression_return.Tree = this.adaptor.ErrorNode(this.input, equalityExpression_return.Start, this.input.LT(-1), ex2);
		}
		return equalityExpression_return;
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00012218 File Offset: 0x00010418
	[global::Antlr.Runtime.GrammarRule("equalityExpressionNoIn")]
	private global::ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn()
	{
		global::ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn_return = new global::ES3Parser.equalityExpressionNoIn_return(this);
		equalityExpressionNoIn_return.Start = this.input.LT(1);
		global::Jint.Expressions.BinaryExpressionType type = global::Jint.Expressions.BinaryExpressionType.Unknown;
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4410);
			global::ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn_return = this.relationalExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, relationalExpressionNoIn_return.Tree);
			equalityExpressionNoIn_return.value = relationalExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x30 || num2 == 0x68 || num2 == 0x6B || num2 == 0x84)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					goto IL_2AF;
				}
				int num4 = this.input.LA(1);
				int num5;
				if (num4 <= 0x68)
				{
					if (num4 != 0x30)
					{
						if (num4 != 0x68)
						{
							break;
						}
						num5 = 2;
					}
					else
					{
						num5 = 1;
					}
				}
				else if (num4 != 0x6B)
				{
					if (num4 != 0x84)
					{
						break;
					}
					num5 = 3;
				}
				else
				{
					num5 = 4;
				}
				switch (num5)
				{
				case 1:
				{
					global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x30, global::ES3Parser.Follow._EQ_in_equalityExpressionNoIn4421);
					object child = this.adaptor.Create(payload);
					this.adaptor.AddChild(obj, child);
					type = global::Jint.Expressions.BinaryExpressionType.Equal;
					break;
				}
				case 2:
				{
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x68, global::ES3Parser.Follow._NEQ_in_equalityExpressionNoIn4429);
					object child2 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child2);
					type = global::Jint.Expressions.BinaryExpressionType.NotEqual;
					break;
				}
				case 3:
				{
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x84, global::ES3Parser.Follow._SAME_in_equalityExpressionNoIn4437);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					type = global::Jint.Expressions.BinaryExpressionType.Same;
					break;
				}
				case 4:
				{
					global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6B, global::ES3Parser.Follow._NSAME_in_equalityExpressionNoIn4445);
					object child4 = this.adaptor.Create(payload4);
					this.adaptor.AddChild(obj, child4);
					type = global::Jint.Expressions.BinaryExpressionType.NotSame;
					break;
				}
				}
				base.PushFollow(global::ES3Parser.Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4456);
				global::ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn_return2 = this.relationalExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, relationalExpressionNoIn_return2.Tree);
				equalityExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(type, equalityExpressionNoIn_return.value, relationalExpressionNoIn_return2.value);
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x26, 0, this.input);
			throw ex;
			IL_2AF:
			equalityExpressionNoIn_return.Stop = this.input.LT(-1);
			equalityExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(equalityExpressionNoIn_return.Tree, equalityExpressionNoIn_return.Start, equalityExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			equalityExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, equalityExpressionNoIn_return.Start, this.input.LT(-1), ex2);
		}
		return equalityExpressionNoIn_return;
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00012580 File Offset: 0x00010780
	[global::Antlr.Runtime.GrammarRule("bitwiseANDExpression")]
	private global::ES3Parser.bitwiseANDExpression_return bitwiseANDExpression()
	{
		global::ES3Parser.bitwiseANDExpression_return bitwiseANDExpression_return = new global::ES3Parser.bitwiseANDExpression_return(this);
		bitwiseANDExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._equalityExpression_in_bitwiseANDExpression4483);
			global::ES3Parser.equalityExpression_return equalityExpression_return = this.equalityExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, equalityExpression_return.Tree);
			bitwiseANDExpression_return.value = equalityExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 7)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 7, global::ES3Parser.Follow._AND_in_bitwiseANDExpression4489);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._equalityExpression_in_bitwiseANDExpression4494);
				global::ES3Parser.equalityExpression_return equalityExpression_return2 = this.equalityExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, equalityExpression_return2.Tree);
				bitwiseANDExpression_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseAnd, bitwiseANDExpression_return.value, equalityExpression_return2.value);
			}
			bitwiseANDExpression_return.Stop = this.input.LT(-1);
			bitwiseANDExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(bitwiseANDExpression_return.Tree, bitwiseANDExpression_return.Start, bitwiseANDExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			bitwiseANDExpression_return.Tree = this.adaptor.ErrorNode(this.input, bitwiseANDExpression_return.Start, this.input.LT(-1), ex);
		}
		return bitwiseANDExpression_return;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00012748 File Offset: 0x00010948
	[global::Antlr.Runtime.GrammarRule("bitwiseANDExpressionNoIn")]
	private global::ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn()
	{
		global::ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn_return = new global::ES3Parser.bitwiseANDExpressionNoIn_return(this);
		bitwiseANDExpressionNoIn_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4515);
			global::ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn_return = this.equalityExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, equalityExpressionNoIn_return.Tree);
			bitwiseANDExpressionNoIn_return.value = equalityExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 7)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 7, global::ES3Parser.Follow._AND_in_bitwiseANDExpressionNoIn4521);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4526);
				global::ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn_return2 = this.equalityExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, equalityExpressionNoIn_return2.Tree);
				bitwiseANDExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseAnd, bitwiseANDExpressionNoIn_return.value, equalityExpressionNoIn_return2.value);
			}
			bitwiseANDExpressionNoIn_return.Stop = this.input.LT(-1);
			bitwiseANDExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(bitwiseANDExpressionNoIn_return.Tree, bitwiseANDExpressionNoIn_return.Start, bitwiseANDExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			bitwiseANDExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, bitwiseANDExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return bitwiseANDExpressionNoIn_return;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00012910 File Offset: 0x00010B10
	[global::Antlr.Runtime.GrammarRule("bitwiseXORExpression")]
	private global::ES3Parser.bitwiseXORExpression_return bitwiseXORExpression()
	{
		global::ES3Parser.bitwiseXORExpression_return bitwiseXORExpression_return = new global::ES3Parser.bitwiseXORExpression_return(this);
		bitwiseXORExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._bitwiseANDExpression_in_bitwiseXORExpression4549);
			global::ES3Parser.bitwiseANDExpression_return bitwiseANDExpression_return = this.bitwiseANDExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, bitwiseANDExpression_return.Tree);
			bitwiseXORExpression_return.value = bitwiseANDExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0xA8)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA8, global::ES3Parser.Follow._XOR_in_bitwiseXORExpression4555);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._bitwiseANDExpression_in_bitwiseXORExpression4560);
				global::ES3Parser.bitwiseANDExpression_return bitwiseANDExpression_return2 = this.bitwiseANDExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, bitwiseANDExpression_return2.Tree);
				bitwiseXORExpression_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseXOr, bitwiseXORExpression_return.value, bitwiseANDExpression_return2.value);
			}
			bitwiseXORExpression_return.Stop = this.input.LT(-1);
			bitwiseXORExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(bitwiseXORExpression_return.Tree, bitwiseXORExpression_return.Start, bitwiseXORExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			bitwiseXORExpression_return.Tree = this.adaptor.ErrorNode(this.input, bitwiseXORExpression_return.Start, this.input.LT(-1), ex);
		}
		return bitwiseXORExpression_return;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00012AE0 File Offset: 0x00010CE0
	[global::Antlr.Runtime.GrammarRule("bitwiseXORExpressionNoIn")]
	private global::ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn()
	{
		global::ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn_return = new global::ES3Parser.bitwiseXORExpressionNoIn_return(this);
		bitwiseXORExpressionNoIn_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4583);
			global::ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn_return = this.bitwiseANDExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, bitwiseANDExpressionNoIn_return.Tree);
			bitwiseXORExpressionNoIn_return.value = bitwiseANDExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0xA8)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA8, global::ES3Parser.Follow._XOR_in_bitwiseXORExpressionNoIn4589);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4594);
				global::ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn_return2 = this.bitwiseANDExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, bitwiseANDExpressionNoIn_return2.Tree);
				bitwiseXORExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseXOr, bitwiseXORExpressionNoIn_return.value, bitwiseANDExpressionNoIn_return2.value);
			}
			bitwiseXORExpressionNoIn_return.Stop = this.input.LT(-1);
			bitwiseXORExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(bitwiseXORExpressionNoIn_return.Tree, bitwiseXORExpressionNoIn_return.Start, bitwiseXORExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			bitwiseXORExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, bitwiseXORExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return bitwiseXORExpressionNoIn_return;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00012CB0 File Offset: 0x00010EB0
	[global::Antlr.Runtime.GrammarRule("bitwiseORExpression")]
	private global::ES3Parser.bitwiseORExpression_return bitwiseORExpression()
	{
		global::ES3Parser.bitwiseORExpression_return bitwiseORExpression_return = new global::ES3Parser.bitwiseORExpression_return(this);
		bitwiseORExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._bitwiseXORExpression_in_bitwiseORExpression4616);
			global::ES3Parser.bitwiseXORExpression_return bitwiseXORExpression_return = this.bitwiseXORExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, bitwiseXORExpression_return.Tree);
			bitwiseORExpression_return.value = bitwiseXORExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x6E)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6E, global::ES3Parser.Follow._OR_in_bitwiseORExpression4622);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._bitwiseXORExpression_in_bitwiseORExpression4627);
				global::ES3Parser.bitwiseXORExpression_return bitwiseXORExpression_return2 = this.bitwiseXORExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, bitwiseXORExpression_return2.Tree);
				bitwiseORExpression_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseOr, bitwiseORExpression_return.value, bitwiseXORExpression_return2.value);
			}
			bitwiseORExpression_return.Stop = this.input.LT(-1);
			bitwiseORExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(bitwiseORExpression_return.Tree, bitwiseORExpression_return.Start, bitwiseORExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			bitwiseORExpression_return.Tree = this.adaptor.ErrorNode(this.input, bitwiseORExpression_return.Start, this.input.LT(-1), ex);
		}
		return bitwiseORExpression_return;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00012E7C File Offset: 0x0001107C
	[global::Antlr.Runtime.GrammarRule("bitwiseORExpressionNoIn")]
	private global::ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn()
	{
		global::ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn_return = new global::ES3Parser.bitwiseORExpressionNoIn_return(this);
		bitwiseORExpressionNoIn_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4649);
			global::ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn_return = this.bitwiseXORExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, bitwiseXORExpressionNoIn_return.Tree);
			bitwiseORExpressionNoIn_return.value = bitwiseXORExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x6E)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x6E, global::ES3Parser.Follow._OR_in_bitwiseORExpressionNoIn4655);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4660);
				global::ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn_return2 = this.bitwiseXORExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, bitwiseXORExpressionNoIn_return2.Tree);
				bitwiseORExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseOr, bitwiseORExpressionNoIn_return.value, bitwiseXORExpressionNoIn_return2.value);
			}
			bitwiseORExpressionNoIn_return.Stop = this.input.LT(-1);
			bitwiseORExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(bitwiseORExpressionNoIn_return.Tree, bitwiseORExpressionNoIn_return.Start, bitwiseORExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			bitwiseORExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, bitwiseORExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return bitwiseORExpressionNoIn_return;
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00013048 File Offset: 0x00011248
	[global::Antlr.Runtime.GrammarRule("logicalANDExpression")]
	private global::ES3Parser.logicalANDExpression_return logicalANDExpression()
	{
		global::ES3Parser.logicalANDExpression_return logicalANDExpression_return = new global::ES3Parser.logicalANDExpression_return(this);
		logicalANDExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._bitwiseORExpression_in_logicalANDExpression4686);
			global::ES3Parser.bitwiseORExpression_return bitwiseORExpression_return = this.bitwiseORExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, bitwiseORExpression_return.Tree);
			logicalANDExpression_return.value = bitwiseORExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x54)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x54, global::ES3Parser.Follow._LAND_in_logicalANDExpression4692);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._bitwiseORExpression_in_logicalANDExpression4697);
				global::ES3Parser.bitwiseORExpression_return bitwiseORExpression_return2 = this.bitwiseORExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, bitwiseORExpression_return2.Tree);
				logicalANDExpression_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.And, logicalANDExpression_return.value, bitwiseORExpression_return2.value);
			}
			logicalANDExpression_return.Stop = this.input.LT(-1);
			logicalANDExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(logicalANDExpression_return.Tree, logicalANDExpression_return.Start, logicalANDExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			logicalANDExpression_return.Tree = this.adaptor.ErrorNode(this.input, logicalANDExpression_return.Start, this.input.LT(-1), ex);
		}
		return logicalANDExpression_return;
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00013210 File Offset: 0x00011410
	[global::Antlr.Runtime.GrammarRule("logicalANDExpressionNoIn")]
	private global::ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn()
	{
		global::ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn_return = new global::ES3Parser.logicalANDExpressionNoIn_return(this);
		logicalANDExpressionNoIn_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4718);
			global::ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn_return = this.bitwiseORExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, bitwiseORExpressionNoIn_return.Tree);
			logicalANDExpressionNoIn_return.value = bitwiseORExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x54)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x54, global::ES3Parser.Follow._LAND_in_logicalANDExpressionNoIn4724);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4729);
				global::ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn_return2 = this.bitwiseORExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, bitwiseORExpressionNoIn_return2.Tree);
				logicalANDExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.And, logicalANDExpressionNoIn_return.value, bitwiseORExpressionNoIn_return2.value);
			}
			logicalANDExpressionNoIn_return.Stop = this.input.LT(-1);
			logicalANDExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(logicalANDExpressionNoIn_return.Tree, logicalANDExpressionNoIn_return.Start, logicalANDExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			logicalANDExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, logicalANDExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return logicalANDExpressionNoIn_return;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x000133D8 File Offset: 0x000115D8
	[global::Antlr.Runtime.GrammarRule("logicalORExpression")]
	private global::ES3Parser.logicalORExpression_return logicalORExpression()
	{
		global::ES3Parser.logicalORExpression_return logicalORExpression_return = new global::ES3Parser.logicalORExpression_return(this);
		logicalORExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._logicalANDExpression_in_logicalORExpression4751);
			global::ES3Parser.logicalANDExpression_return logicalANDExpression_return = this.logicalANDExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, logicalANDExpression_return.Tree);
			logicalORExpression_return.value = logicalANDExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x59)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x59, global::ES3Parser.Follow._LOR_in_logicalORExpression4757);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._logicalANDExpression_in_logicalORExpression4762);
				global::ES3Parser.logicalANDExpression_return logicalANDExpression_return2 = this.logicalANDExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, logicalANDExpression_return2.Tree);
				logicalORExpression_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Or, logicalORExpression_return.value, logicalANDExpression_return2.value);
			}
			logicalORExpression_return.Stop = this.input.LT(-1);
			logicalORExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(logicalORExpression_return.Tree, logicalORExpression_return.Start, logicalORExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			logicalORExpression_return.Tree = this.adaptor.ErrorNode(this.input, logicalORExpression_return.Start, this.input.LT(-1), ex);
		}
		return logicalORExpression_return;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x000135A0 File Offset: 0x000117A0
	[global::Antlr.Runtime.GrammarRule("logicalORExpressionNoIn")]
	private global::ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn()
	{
		global::ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn_return = new global::ES3Parser.logicalORExpressionNoIn_return(this);
		logicalORExpressionNoIn_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4784);
			global::ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn_return = this.logicalANDExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, logicalANDExpressionNoIn_return.Tree);
			logicalORExpressionNoIn_return.value = logicalANDExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x59)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x59, global::ES3Parser.Follow._LOR_in_logicalORExpressionNoIn4790);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4795);
				global::ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn_return2 = this.logicalANDExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, logicalANDExpressionNoIn_return2.Tree);
				logicalORExpressionNoIn_return.value = new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Or, logicalORExpressionNoIn_return.value, logicalANDExpressionNoIn_return2.value);
			}
			logicalORExpressionNoIn_return.Stop = this.input.LT(-1);
			logicalORExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(logicalORExpressionNoIn_return.Tree, logicalORExpressionNoIn_return.Start, logicalORExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			logicalORExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, logicalORExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return logicalORExpressionNoIn_return;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00013768 File Offset: 0x00011968
	[global::Antlr.Runtime.GrammarRule("conditionalExpression")]
	private global::ES3Parser.conditionalExpression_return conditionalExpression()
	{
		global::ES3Parser.conditionalExpression_return conditionalExpression_return = new global::ES3Parser.conditionalExpression_return(this);
		conditionalExpression_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._logicalORExpression_in_conditionalExpression4822);
			global::ES3Parser.logicalORExpression_return logicalORExpression_return = this.logicalORExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, logicalORExpression_return.Tree);
			conditionalExpression_return.value = logicalORExpression_return.value;
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x7C)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7C, global::ES3Parser.Follow._QUE_in_conditionalExpression4828);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_conditionalExpression4833);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1A, global::ES3Parser.Follow._COLON_in_conditionalExpression4835);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_conditionalExpression4840);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return2 = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return2.Tree);
				conditionalExpression_return.value = new global::Jint.Expressions.TernaryExpression(logicalORExpression_return.value, assignmentExpression_return.value, assignmentExpression_return2.value);
			}
			conditionalExpression_return.Stop = this.input.LT(-1);
			conditionalExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(conditionalExpression_return.Tree, conditionalExpression_return.Start, conditionalExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			conditionalExpression_return.Tree = this.adaptor.ErrorNode(this.input, conditionalExpression_return.Start, this.input.LT(-1), ex);
		}
		return conditionalExpression_return;
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0001397C File Offset: 0x00011B7C
	[global::Antlr.Runtime.GrammarRule("conditionalExpressionNoIn")]
	private global::ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn()
	{
		global::ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn_return = new global::ES3Parser.conditionalExpressionNoIn_return(this);
		conditionalExpressionNoIn_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._logicalORExpressionNoIn_in_conditionalExpressionNoIn4861);
			global::ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn_return = this.logicalORExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, logicalORExpressionNoIn_return.Tree);
			conditionalExpressionNoIn_return.value = logicalORExpressionNoIn_return.value;
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x7C)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7C, global::ES3Parser.Follow._QUE_in_conditionalExpressionNoIn4867);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn4872);
				global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return = this.assignmentExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpressionNoIn_return.Tree);
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1A, global::ES3Parser.Follow._COLON_in_conditionalExpressionNoIn4874);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn4879);
				global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return2 = this.assignmentExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpressionNoIn_return2.Tree);
				conditionalExpressionNoIn_return.value = new global::Jint.Expressions.TernaryExpression(logicalORExpressionNoIn_return.value, assignmentExpressionNoIn_return.value, assignmentExpressionNoIn_return2.value);
			}
			conditionalExpressionNoIn_return.Stop = this.input.LT(-1);
			conditionalExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(conditionalExpressionNoIn_return.Tree, conditionalExpressionNoIn_return.Start, conditionalExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			conditionalExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, conditionalExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return conditionalExpressionNoIn_return;
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00013B90 File Offset: 0x00011D90
	[global::Antlr.Runtime.GrammarRule("assignmentExpression")]
	private global::ES3Parser.assignmentExpression_return assignmentExpression()
	{
		global::ES3Parser.assignmentExpression_return assignmentExpression_return = new global::ES3Parser.assignmentExpression_return(this);
		assignmentExpression_return.Start = this.input.LT(1);
		object[] cached = new object[1];
		global::Jint.Expressions.AssignmentExpression assignmentExpression = new global::Jint.Expressions.AssignmentExpression();
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._conditionalExpression_in_assignmentExpression4912);
			global::ES3Parser.conditionalExpression_return conditionalExpression_return = this.conditionalExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, conditionalExpression_return.Tree);
			assignmentExpression_return.value = (assignmentExpression.Left = conditionalExpression_return.value);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 6 || num2 == 8 || num2 == 0xB || num2 == 0x25 || num2 == 0x60 || num2 == 0x62 || num2 == 0x6F || num2 == 0x87 || num2 == 0x8A || num2 == 0x8C || num2 == 0x91 || num2 == 0xA9)
			{
				this.input.LA(2);
				if (this.IsLeftHandSideAssign(conditionalExpression_return.value, cached))
				{
					num = 1;
				}
			}
			int num3 = num;
			if (num3 == 1)
			{
				if (!this.IsLeftHandSideAssign(conditionalExpression_return.value, cached))
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "assignmentExpression", " IsLeftHandSideAssign(lhs.value, isLhs) ");
				}
				base.PushFollow(global::ES3Parser.Follow._assignmentOperator_in_assignmentExpression4924);
				global::ES3Parser.assignmentOperator_return assignmentOperator_return = this.assignmentOperator();
				base.PopFollow();
				obj = this.adaptor.BecomeRoot(assignmentOperator_return.Tree, obj);
				assignmentExpression.AssignmentOperator = this.ResolveAssignmentOperator((assignmentOperator_return != null) ? this.input.ToString(assignmentOperator_return.Start, assignmentOperator_return.Stop) : null);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_assignmentExpression4931);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return2 = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return2.Tree);
				assignmentExpression.Right = assignmentExpression_return2.value;
				assignmentExpression_return.value = assignmentExpression;
			}
			assignmentExpression_return.Stop = this.input.LT(-1);
			assignmentExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(assignmentExpression_return.Tree, assignmentExpression_return.Start, assignmentExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			assignmentExpression_return.Tree = this.adaptor.ErrorNode(this.input, assignmentExpression_return.Start, this.input.LT(-1), ex);
		}
		return assignmentExpression_return;
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00013E48 File Offset: 0x00012048
	[global::Antlr.Runtime.GrammarRule("assignmentOperator")]
	private global::ES3Parser.assignmentOperator_return assignmentOperator()
	{
		global::ES3Parser.assignmentOperator_return assignmentOperator_return = new global::ES3Parser.assignmentOperator_return(this);
		assignmentOperator_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = this.input.LT(1);
			if (this.input.LA(1) != 6 && this.input.LA(1) != 8 && this.input.LA(1) != 0xB && this.input.LA(1) != 0x25 && this.input.LA(1) != 0x60 && this.input.LA(1) != 0x62 && this.input.LA(1) != 0x6F && this.input.LA(1) != 0x87 && this.input.LA(1) != 0x8A && this.input.LA(1) != 0x8C && this.input.LA(1) != 0x91 && this.input.LA(1) != 0xA9)
			{
				global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
				throw ex;
			}
			this.input.Consume();
			this.adaptor.AddChild(obj, this.adaptor.Create(payload));
			this.state.errorRecovery = false;
			assignmentOperator_return.Stop = this.input.LT(-1);
			assignmentOperator_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(assignmentOperator_return.Tree, assignmentOperator_return.Start, assignmentOperator_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			assignmentOperator_return.Tree = this.adaptor.ErrorNode(this.input, assignmentOperator_return.Start, this.input.LT(-1), ex2);
		}
		return assignmentOperator_return;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0001406C File Offset: 0x0001226C
	[global::Antlr.Runtime.GrammarRule("assignmentExpressionNoIn")]
	private global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn()
	{
		global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return = new global::ES3Parser.assignmentExpressionNoIn_return(this);
		assignmentExpressionNoIn_return.Start = this.input.LT(1);
		object[] cached = new object[1];
		global::Jint.Expressions.AssignmentExpression assignmentExpression = new global::Jint.Expressions.AssignmentExpression();
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._conditionalExpressionNoIn_in_assignmentExpressionNoIn5026);
			global::ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn_return = this.conditionalExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, conditionalExpressionNoIn_return.Tree);
			assignmentExpression.Left = (assignmentExpressionNoIn_return.value = ((conditionalExpressionNoIn_return != null) ? conditionalExpressionNoIn_return.value : null));
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 6 || num2 == 8 || num2 == 0xB || num2 == 0x25 || num2 == 0x60 || num2 == 0x62 || num2 == 0x6F || num2 == 0x87 || num2 == 0x8A || num2 == 0x8C || num2 == 0x91 || num2 == 0xA9)
			{
				this.input.LA(2);
				if (this.IsLeftHandSideAssign(conditionalExpressionNoIn_return.value, cached))
				{
					num = 1;
				}
			}
			int num3 = num;
			if (num3 == 1)
			{
				if (!this.IsLeftHandSideAssign(conditionalExpressionNoIn_return.value, cached))
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "assignmentExpressionNoIn", " IsLeftHandSideAssign(lhs.value, isLhs) ");
				}
				base.PushFollow(global::ES3Parser.Follow._assignmentOperator_in_assignmentExpressionNoIn5038);
				global::ES3Parser.assignmentOperator_return assignmentOperator_return = this.assignmentOperator();
				base.PopFollow();
				obj = this.adaptor.BecomeRoot(assignmentOperator_return.Tree, obj);
				assignmentExpression.AssignmentOperator = this.ResolveAssignmentOperator((assignmentOperator_return != null) ? this.input.ToString(assignmentOperator_return.Start, assignmentOperator_return.Stop) : null);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpressionNoIn_in_assignmentExpressionNoIn5045);
				global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return2 = this.assignmentExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpressionNoIn_return2.Tree);
				assignmentExpression.Right = assignmentExpressionNoIn_return2.value;
				assignmentExpressionNoIn_return.value = assignmentExpression;
			}
			assignmentExpressionNoIn_return.Stop = this.input.LT(-1);
			assignmentExpressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(assignmentExpressionNoIn_return.Tree, assignmentExpressionNoIn_return.Start, assignmentExpressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			assignmentExpressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, assignmentExpressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return assignmentExpressionNoIn_return;
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00014330 File Offset: 0x00012530
	[global::Antlr.Runtime.GrammarRule("expression")]
	private global::ES3Parser.expression_return expression()
	{
		global::ES3Parser.expression_return expression_return = new global::ES3Parser.expression_return(this);
		expression_return.Start = this.input.LT(1);
		global::Jint.Expressions.CommaOperatorStatement commaOperatorStatement = new global::Jint.Expressions.CommaOperatorStatement();
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_expression5077);
			global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
			base.PopFollow();
			this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
			expression_return.value = assignmentExpression_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x1B)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_expression5083);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				if (commaOperatorStatement.Statements.Count == 0)
				{
					commaOperatorStatement.Statements.Add(expression_return.value);
					expression_return.value = commaOperatorStatement;
				}
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_expression5089);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return2 = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return2.Tree);
				commaOperatorStatement.Statements.Add(assignmentExpression_return2.value);
			}
			expression_return.Stop = this.input.LT(-1);
			expression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(expression_return.Tree, expression_return.Start, expression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			expression_return.Tree = this.adaptor.ErrorNode(this.input, expression_return.Start, this.input.LT(-1), ex);
		}
		return expression_return;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x00014524 File Offset: 0x00012724
	[global::Antlr.Runtime.GrammarRule("expressionNoIn")]
	private global::ES3Parser.expressionNoIn_return expressionNoIn()
	{
		global::ES3Parser.expressionNoIn_return expressionNoIn_return = new global::ES3Parser.expressionNoIn_return(this);
		expressionNoIn_return.Start = this.input.LT(1);
		global::Jint.Expressions.CommaOperatorStatement commaOperatorStatement = new global::Jint.Expressions.CommaOperatorStatement();
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._assignmentExpressionNoIn_in_expressionNoIn5117);
			global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return = this.assignmentExpressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, assignmentExpressionNoIn_return.Tree);
			expressionNoIn_return.value = assignmentExpressionNoIn_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x1B)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_expressionNoIn5123);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				if (commaOperatorStatement.Statements.Count == 0)
				{
					commaOperatorStatement.Statements.Add(expressionNoIn_return.value);
					expressionNoIn_return.value = commaOperatorStatement;
				}
				base.PushFollow(global::ES3Parser.Follow._assignmentExpressionNoIn_in_expressionNoIn5129);
				global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return2 = this.assignmentExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpressionNoIn_return2.Tree);
				commaOperatorStatement.Statements.Add(assignmentExpressionNoIn_return2.value);
			}
			expressionNoIn_return.Stop = this.input.LT(-1);
			expressionNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(expressionNoIn_return.Tree, expressionNoIn_return.Start, expressionNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			expressionNoIn_return.Tree = this.adaptor.ErrorNode(this.input, expressionNoIn_return.Start, this.input.LT(-1), ex);
		}
		return expressionNoIn_return;
	}

	// Token: 0x06000206 RID: 518 RVA: 0x00014718 File Offset: 0x00012918
	[global::Antlr.Runtime.GrammarRule("semic")]
	private global::ES3Parser.semic_return semic()
	{
		global::ES3Parser.semic_return semic_return = new global::ES3Parser.semic_return(this);
		semic_return.Start = this.input.LT(1);
		object obj = null;
		int marker = this.input.Mark();
		this.PromoteEOL(semic_return);
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x2F)
			{
				if (num == -1)
				{
					num2 = 2;
					goto IL_D9;
				}
				if (num == 0x2F)
				{
					num2 = 4;
					goto IL_D9;
				}
			}
			else
			{
				if (num == 0x63)
				{
					num2 = 5;
					goto IL_D9;
				}
				if (num == 0x7D)
				{
					num2 = 3;
					goto IL_D9;
				}
				if (num == 0x85)
				{
					num2 = 1;
					goto IL_D9;
				}
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x38, 0, this.input);
			throw ex;
			IL_D9:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_semic5163);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, -1, global::ES3Parser.Follow._EOF_in_semic5168);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7D, global::ES3Parser.Follow._RBRACE_in_semic5173);
				object child3 = this.adaptor.Create(payload3);
				this.adaptor.AddChild(obj, child3);
				this.input.Rewind(marker);
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x2F, global::ES3Parser.Follow._EOL_in_semic5180);
				object child4 = this.adaptor.Create(payload4);
				this.adaptor.AddChild(obj, child4);
				break;
			}
			case 5:
			{
				obj = this.adaptor.Nil();
				global::Antlr.Runtime.IToken payload5 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x63, global::ES3Parser.Follow._MultiLineComment_in_semic5184);
				object child5 = this.adaptor.Create(payload5);
				this.adaptor.AddChild(obj, child5);
				break;
			}
			}
			semic_return.Stop = this.input.LT(-1);
			semic_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(semic_return.Tree, semic_return.Start, semic_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			semic_return.Tree = this.adaptor.ErrorNode(this.input, semic_return.Start, this.input.LT(-1), ex2);
		}
		return semic_return;
	}

	// Token: 0x06000207 RID: 519 RVA: 0x00014A40 File Offset: 0x00012C40
	[global::Antlr.Runtime.GrammarRule("statement")]
	private global::ES3Parser.statement_return statement()
	{
		global::ES3Parser.statement_return statement_return = new global::ES3Parser.statement_return(this);
		statement_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = 3;
			try
			{
				num = this.dfa57.Predict(this.input);
			}
			catch (global::Antlr.Runtime.NoViableAltException)
			{
				throw;
			}
			switch (num)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				if (this.input.LA(1) != 0x55)
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "statement", " input.LA(1) == LBRACE ");
				}
				base.PushFollow(global::ES3Parser.Follow._block_in_statement5218);
				global::ES3Parser.block_return block_return = this.block();
				base.PopFollow();
				this.adaptor.AddChild(obj, block_return.Tree);
				statement_return.value = ((block_return != null) ? block_return.value : null);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				if (this.input.LA(1) != 0x3E)
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "statement", " input.LA(1) == FUNCTION ");
				}
				base.PushFollow(global::ES3Parser.Follow._functionDeclaration_in_statement5229);
				global::ES3Parser.functionDeclaration_return functionDeclaration_return = this.functionDeclaration();
				base.PopFollow();
				this.adaptor.AddChild(obj, functionDeclaration_return.Tree);
				statement_return.value = functionDeclaration_return.value;
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._statementTail_in_statement5236);
				global::ES3Parser.statementTail_return statementTail_return = this.statementTail();
				base.PopFollow();
				this.adaptor.AddChild(obj, statementTail_return.Tree);
				statement_return.value = ((statementTail_return != null) ? statementTail_return.value : null);
				break;
			}
			}
			statement_return.Stop = this.input.LT(-1);
			statement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(statement_return.Tree, statement_return.Start, statement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			statement_return.Tree = this.adaptor.ErrorNode(this.input, statement_return.Start, this.input.LT(-1), ex);
		}
		return statement_return;
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00014CAC File Offset: 0x00012EAC
	[global::Antlr.Runtime.GrammarRule("statementTail")]
	private global::ES3Parser.statementTail_return statementTail()
	{
		global::ES3Parser.statementTail_return statementTail_return = new global::ES3Parser.statementTail_return(this);
		statementTail_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = 0xD;
			try
			{
				num = this.dfa58.Predict(this.input);
			}
			catch (global::Antlr.Runtime.NoViableAltException)
			{
				throw;
			}
			switch (num)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._variableStatement_in_statementTail5259);
				global::ES3Parser.variableStatement_return variableStatement_return = this.variableStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, variableStatement_return.Tree);
				statementTail_return.value = ((variableStatement_return != null) ? variableStatement_return.value : null);
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._emptyStatement_in_statementTail5266);
				global::ES3Parser.emptyStatement_return emptyStatement_return = this.emptyStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, emptyStatement_return.Tree);
				statementTail_return.value = ((emptyStatement_return != null) ? emptyStatement_return.value : null);
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._expressionStatement_in_statementTail5273);
				global::ES3Parser.expressionStatement_return expressionStatement_return = this.expressionStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, expressionStatement_return.Tree);
				statementTail_return.value = ((expressionStatement_return != null) ? expressionStatement_return.value : null);
				break;
			}
			case 4:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._ifStatement_in_statementTail5280);
				global::ES3Parser.ifStatement_return ifStatement_return = this.ifStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, ifStatement_return.Tree);
				statementTail_return.value = ((ifStatement_return != null) ? ifStatement_return.value : null);
				break;
			}
			case 5:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._iterationStatement_in_statementTail5287);
				global::ES3Parser.iterationStatement_return iterationStatement_return = this.iterationStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, iterationStatement_return.Tree);
				statementTail_return.value = ((iterationStatement_return != null) ? iterationStatement_return.value : null);
				break;
			}
			case 6:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._continueStatement_in_statementTail5294);
				global::ES3Parser.continueStatement_return continueStatement_return = this.continueStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, continueStatement_return.Tree);
				statementTail_return.value = ((continueStatement_return != null) ? continueStatement_return.value : null);
				break;
			}
			case 7:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._breakStatement_in_statementTail5301);
				global::ES3Parser.breakStatement_return breakStatement_return = this.breakStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, breakStatement_return.Tree);
				statementTail_return.value = ((breakStatement_return != null) ? breakStatement_return.value : null);
				break;
			}
			case 8:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._returnStatement_in_statementTail5308);
				global::ES3Parser.returnStatement_return returnStatement_return = this.returnStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, returnStatement_return.Tree);
				statementTail_return.value = ((returnStatement_return != null) ? returnStatement_return.value : null);
				break;
			}
			case 9:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._withStatement_in_statementTail5315);
				global::ES3Parser.withStatement_return withStatement_return = this.withStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, withStatement_return.Tree);
				statementTail_return.value = ((withStatement_return != null) ? withStatement_return.value : null);
				break;
			}
			case 0xA:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._labelledStatement_in_statementTail5322);
				global::ES3Parser.labelledStatement_return labelledStatement_return = this.labelledStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, labelledStatement_return.Tree);
				statementTail_return.value = ((labelledStatement_return != null) ? labelledStatement_return.value : null);
				break;
			}
			case 0xB:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._switchStatement_in_statementTail5329);
				global::ES3Parser.switchStatement_return switchStatement_return = this.switchStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, switchStatement_return.Tree);
				statementTail_return.value = ((switchStatement_return != null) ? switchStatement_return.value : null);
				break;
			}
			case 0xC:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._throwStatement_in_statementTail5336);
				global::ES3Parser.throwStatement_return throwStatement_return = this.throwStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, throwStatement_return.Tree);
				statementTail_return.value = ((throwStatement_return != null) ? throwStatement_return.value : null);
				break;
			}
			case 0xD:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._tryStatement_in_statementTail5343);
				global::ES3Parser.tryStatement_return tryStatement_return = this.tryStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, tryStatement_return.Tree);
				statementTail_return.value = ((tryStatement_return != null) ? tryStatement_return.value : null);
				break;
			}
			}
			statementTail_return.Stop = this.input.LT(-1);
			statementTail_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(statementTail_return.Tree, statementTail_return.Start, statementTail_return.Stop);
			if (!(statementTail_return.value is global::Jint.Expressions.ForStatement) && !(statementTail_return.value is global::Jint.Expressions.BlockStatement) && !(statementTail_return.value is global::Jint.Expressions.WhileStatement) && !(statementTail_return.value is global::Jint.Expressions.DoWhileStatement) && !(statementTail_return.value is global::Jint.Expressions.SwitchStatement) && !(statementTail_return.value is global::Jint.Expressions.TryStatement) && !(statementTail_return.value is global::Jint.Expressions.IfStatement))
			{
				statementTail_return.value.Source = this.ExtractSourceCode((global::Antlr.Runtime.CommonToken)statementTail_return.Start, (global::Antlr.Runtime.CommonToken)statementTail_return.Stop);
			}
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			statementTail_return.Tree = this.adaptor.ErrorNode(this.input, statementTail_return.Start, this.input.LT(-1), ex);
		}
		return statementTail_return;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00015318 File Offset: 0x00013518
	[global::Antlr.Runtime.GrammarRule("block")]
	private global::ES3Parser.block_return block()
	{
		global::ES3Parser.block_return block_return = new global::ES3Parser.block_return(this);
		block_return.Start = this.input.LT(1);
		block_return.value = new global::Jint.Expressions.BlockStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x55, global::ES3Parser.Follow._LBRACE_in_block5373);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 5 || num2 == 0xE || num2 == 0x1D || num2 == 0x21 || num2 == 0x23 || num2 == 0x26 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3B || num2 == 0x3E || (num2 >= 0x44 && num2 <= 0x45) || (num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56)) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || (num2 == 0x6C || num2 == 0x72 || num2 == 0x7F || num2 == 0x83 || num2 == 0x85 || num2 == 0x90 || num2 == 0x93 || num2 == 0x96 || (num2 >= 0x98 && num2 <= 0x99)) || (num2 >= 0x9C && num2 <= 0x9E) || (num2 >= 0xA1 && num2 <= 0xA2) || (num2 >= 0xA5 && num2 <= 0xA6))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				base.PushFollow(global::ES3Parser.Follow._statement_in_block5376);
				global::ES3Parser.statement_return statement_return = this.statement();
				base.PopFollow();
				this.adaptor.AddChild(obj, statement_return.Tree);
				block_return.value.Statements.AddLast((statement_return != null) ? statement_return.value : null);
			}
			global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7D, global::ES3Parser.Follow._RBRACE_in_block5382);
			object child2 = this.adaptor.Create(payload2);
			this.adaptor.AddChild(obj, child2);
			block_return.Stop = this.input.LT(-1);
			block_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(block_return.Tree, block_return.Start, block_return.Stop);
			block_return.value.Source = this.ExtractSourceCode((global::Antlr.Runtime.CommonToken)block_return.Start, (global::Antlr.Runtime.CommonToken)block_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			block_return.Tree = this.adaptor.ErrorNode(this.input, block_return.Start, this.input.LT(-1), ex);
		}
		return block_return;
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00015680 File Offset: 0x00013880
	[global::Antlr.Runtime.GrammarRule("variableStatement")]
	private global::ES3Parser.variableStatement_return variableStatement()
	{
		global::ES3Parser.variableStatement_return variableStatement_return = new global::ES3Parser.variableStatement_return(this);
		variableStatement_return.Start = this.input.LT(1);
		global::Jint.Expressions.CommaOperatorStatement commaOperatorStatement = new global::Jint.Expressions.CommaOperatorStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA1, global::ES3Parser.Follow._VAR_in_variableStatement5412);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			base.PushFollow(global::ES3Parser.Follow._variableDeclaration_in_variableStatement5416);
			global::ES3Parser.variableDeclaration_return variableDeclaration_return = this.variableDeclaration();
			base.PopFollow();
			this.adaptor.AddChild(obj, variableDeclaration_return.Tree);
			variableDeclaration_return.value.Global = false;
			variableStatement_return.value = variableDeclaration_return.value;
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 0x1B)
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_variableStatement5422);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				if (commaOperatorStatement.Statements.Count == 0)
				{
					commaOperatorStatement.Statements.Add(variableStatement_return.value);
					variableStatement_return.value = commaOperatorStatement;
				}
				base.PushFollow(global::ES3Parser.Follow._variableDeclaration_in_variableStatement5428);
				global::ES3Parser.variableDeclaration_return variableDeclaration_return2 = this.variableDeclaration();
				base.PopFollow();
				this.adaptor.AddChild(obj, variableDeclaration_return2.Tree);
				commaOperatorStatement.Statements.Add(variableDeclaration_return2.value);
				variableDeclaration_return2.value.Global = false;
			}
			base.PushFollow(global::ES3Parser.Follow._semic_in_variableStatement5436);
			global::ES3Parser.semic_return semic_return = this.semic();
			base.PopFollow();
			this.adaptor.AddChild(obj, semic_return.Tree);
			variableStatement_return.Stop = this.input.LT(-1);
			variableStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(variableStatement_return.Tree, variableStatement_return.Start, variableStatement_return.Stop);
			if (commaOperatorStatement.Statements.Count > 0)
			{
				using (global::System.Collections.Generic.List<global::Jint.Expressions.Statement>.Enumerator enumerator = commaOperatorStatement.Statements.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						global::Jint.Expressions.Statement statement = enumerator.Current;
						global::Jint.Expressions.VariableDeclarationStatement variableDeclarationStatement = new global::Jint.Expressions.VariableDeclarationStatement();
						variableDeclarationStatement.Global = false;
						variableDeclarationStatement.Identifier = ((global::Jint.Expressions.VariableDeclarationStatement)statement).Identifier;
						this._currentBody.AddFirst(variableDeclarationStatement);
					}
					goto IL_2B0;
				}
			}
			global::Jint.Expressions.VariableDeclarationStatement variableDeclarationStatement2 = new global::Jint.Expressions.VariableDeclarationStatement();
			variableDeclarationStatement2.Global = false;
			variableDeclarationStatement2.Identifier = variableDeclaration_return.value.Identifier;
			this._currentBody.AddFirst(variableDeclarationStatement2);
			IL_2B0:;
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			variableStatement_return.Tree = this.adaptor.ErrorNode(this.input, variableStatement_return.Start, this.input.LT(-1), ex);
		}
		return variableStatement_return;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x000159C0 File Offset: 0x00013BC0
	[global::Antlr.Runtime.GrammarRule("variableDeclaration")]
	private global::ES3Parser.variableDeclaration_return variableDeclaration()
	{
		global::ES3Parser.variableDeclaration_return variableDeclaration_return = new global::ES3Parser.variableDeclaration_return(this);
		variableDeclaration_return.Start = this.input.LT(1);
		variableDeclaration_return.value = new global::Jint.Expressions.VariableDeclarationStatement();
		variableDeclaration_return.value.Global = true;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_variableDeclaration5460);
			object child = this.adaptor.Create(token);
			this.adaptor.AddChild(obj, child);
			variableDeclaration_return.value.Identifier = token.Text;
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0xB)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xB, global::ES3Parser.Follow._ASSIGN_in_variableDeclaration5466);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpression_in_variableDeclaration5471);
				global::ES3Parser.assignmentExpression_return assignmentExpression_return = this.assignmentExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpression_return.Tree);
				variableDeclaration_return.value.Expression = assignmentExpression_return.value;
			}
			variableDeclaration_return.Stop = this.input.LT(-1);
			variableDeclaration_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(variableDeclaration_return.Tree, variableDeclaration_return.Start, variableDeclaration_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			variableDeclaration_return.Tree = this.adaptor.ErrorNode(this.input, variableDeclaration_return.Start, this.input.LT(-1), ex);
		}
		return variableDeclaration_return;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00015BA8 File Offset: 0x00013DA8
	[global::Antlr.Runtime.GrammarRule("variableDeclarationNoIn")]
	private global::ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn()
	{
		global::ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn_return = new global::ES3Parser.variableDeclarationNoIn_return(this);
		variableDeclarationNoIn_return.Start = this.input.LT(1);
		variableDeclarationNoIn_return.value = new global::Jint.Expressions.VariableDeclarationStatement();
		variableDeclarationNoIn_return.value.Global = true;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_variableDeclarationNoIn5499);
			object child = this.adaptor.Create(token);
			this.adaptor.AddChild(obj, child);
			variableDeclarationNoIn_return.value.Identifier = token.Text;
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0xB)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xB, global::ES3Parser.Follow._ASSIGN_in_variableDeclarationNoIn5505);
				object newRoot = this.adaptor.Create(payload);
				obj = this.adaptor.BecomeRoot(newRoot, obj);
				base.PushFollow(global::ES3Parser.Follow._assignmentExpressionNoIn_in_variableDeclarationNoIn5510);
				global::ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn_return = this.assignmentExpressionNoIn();
				base.PopFollow();
				this.adaptor.AddChild(obj, assignmentExpressionNoIn_return.Tree);
				variableDeclarationNoIn_return.value.Expression = assignmentExpressionNoIn_return.value;
			}
			variableDeclarationNoIn_return.Stop = this.input.LT(-1);
			variableDeclarationNoIn_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(variableDeclarationNoIn_return.Tree, variableDeclarationNoIn_return.Start, variableDeclarationNoIn_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			variableDeclarationNoIn_return.Tree = this.adaptor.ErrorNode(this.input, variableDeclarationNoIn_return.Start, this.input.LT(-1), ex);
		}
		return variableDeclarationNoIn_return;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00015D90 File Offset: 0x00013F90
	[global::Antlr.Runtime.GrammarRule("emptyStatement")]
	private global::ES3Parser.emptyStatement_return emptyStatement()
	{
		global::ES3Parser.emptyStatement_return emptyStatement_return = new global::ES3Parser.emptyStatement_return(this);
		emptyStatement_return.Start = this.input.LT(1);
		try
		{
			object root = this.adaptor.Nil();
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_emptyStatement5535);
			emptyStatement_return.value = new global::Jint.Expressions.EmptyStatement();
			emptyStatement_return.Stop = this.input.LT(-1);
			emptyStatement_return.Tree = this.adaptor.RulePostProcessing(root);
			this.adaptor.SetTokenBoundaries(emptyStatement_return.Tree, emptyStatement_return.Start, emptyStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			emptyStatement_return.Tree = this.adaptor.ErrorNode(this.input, emptyStatement_return.Start, this.input.LT(-1), ex);
		}
		return emptyStatement_return;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00015E88 File Offset: 0x00014088
	[global::Antlr.Runtime.GrammarRule("expressionStatement")]
	private global::ES3Parser.expressionStatement_return expressionStatement()
	{
		global::ES3Parser.expressionStatement_return expressionStatement_return = new global::ES3Parser.expressionStatement_return(this);
		expressionStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._expression_in_expressionStatement5560);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			base.PushFollow(global::ES3Parser.Follow._semic_in_expressionStatement5562);
			this.semic();
			base.PopFollow();
			expressionStatement_return.value = new global::Jint.Expressions.ExpressionStatement((expression_return != null) ? expression_return.value : null);
			expressionStatement_return.Stop = this.input.LT(-1);
			expressionStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(expressionStatement_return.Tree, expressionStatement_return.Start, expressionStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			expressionStatement_return.Tree = this.adaptor.ErrorNode(this.input, expressionStatement_return.Start, this.input.LT(-1), ex);
		}
		return expressionStatement_return;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00015FB8 File Offset: 0x000141B8
	[global::Antlr.Runtime.GrammarRule("ifStatement")]
	private global::ES3Parser.ifStatement_return ifStatement()
	{
		global::ES3Parser.ifStatement_return ifStatement_return = new global::ES3Parser.ifStatement_return(this);
		ifStatement_return.Start = this.input.LT(1);
		global::Jint.Expressions.IfStatement ifStatement = new global::Jint.Expressions.IfStatement();
		ifStatement_return.value = ifStatement;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x45, global::ES3Parser.Follow._IF_in_ifStatement5591);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_ifStatement5593);
			object child2 = this.adaptor.Create(payload2);
			this.adaptor.AddChild(obj, child2);
			base.PushFollow(global::ES3Parser.Follow._expression_in_ifStatement5595);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			ifStatement.Expression = ((expression_return != null) ? expression_return.value : null);
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_ifStatement5599);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			base.PushFollow(global::ES3Parser.Follow._statement_in_ifStatement5603);
			global::ES3Parser.statement_return statement_return = this.statement();
			base.PopFollow();
			this.adaptor.AddChild(obj, statement_return.Tree);
			ifStatement.Then = ((statement_return != null) ? statement_return.value : null);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x2D)
			{
				this.input.LA(2);
				if (this.input.LA(1) == 0x2D)
				{
					num = 1;
				}
			}
			int num3 = num;
			if (num3 == 1)
			{
				if (this.input.LA(1) != 0x2D)
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "ifStatement", " input.LA(1) == ELSE ");
				}
				global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x2D, global::ES3Parser.Follow._ELSE_in_ifStatement5611);
				object child4 = this.adaptor.Create(payload4);
				this.adaptor.AddChild(obj, child4);
				base.PushFollow(global::ES3Parser.Follow._statement_in_ifStatement5615);
				global::ES3Parser.statement_return statement_return2 = this.statement();
				base.PopFollow();
				this.adaptor.AddChild(obj, statement_return2.Tree);
				ifStatement.Else = ((statement_return2 != null) ? statement_return2.value : null);
			}
			ifStatement_return.Stop = this.input.LT(-1);
			ifStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(ifStatement_return.Tree, ifStatement_return.Start, ifStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			ifStatement_return.Tree = this.adaptor.ErrorNode(this.input, ifStatement_return.Start, this.input.LT(-1), ex);
		}
		return ifStatement_return;
	}

	// Token: 0x06000210 RID: 528 RVA: 0x000162E8 File Offset: 0x000144E8
	[global::Antlr.Runtime.GrammarRule("iterationStatement")]
	private global::ES3Parser.iterationStatement_return iterationStatement()
	{
		global::ES3Parser.iterationStatement_return iterationStatement_return = new global::ES3Parser.iterationStatement_return(this);
		iterationStatement_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num != 0x26)
			{
				if (num != 0x3B)
				{
					if (num != 0xA5)
					{
						global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x40, 0, this.input);
						throw ex;
					}
					num2 = 2;
				}
				else
				{
					num2 = 3;
				}
			}
			else
			{
				num2 = 1;
			}
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._doStatement_in_iterationStatement5645);
				global::ES3Parser.doStatement_return doStatement_return = this.doStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, doStatement_return.Tree);
				iterationStatement_return.value = doStatement_return.value;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._whileStatement_in_iterationStatement5654);
				global::ES3Parser.whileStatement_return whileStatement_return = this.whileStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, whileStatement_return.Tree);
				iterationStatement_return.value = whileStatement_return.value;
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._forStatement_in_iterationStatement5664);
				global::ES3Parser.forStatement_return forStatement_return = this.forStatement();
				base.PopFollow();
				this.adaptor.AddChild(obj, forStatement_return.Tree);
				iterationStatement_return.value = (global::Jint.Expressions.Statement)forStatement_return.value;
				break;
			}
			}
			iterationStatement_return.Stop = this.input.LT(-1);
			iterationStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(iterationStatement_return.Tree, iterationStatement_return.Start, iterationStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			iterationStatement_return.Tree = this.adaptor.ErrorNode(this.input, iterationStatement_return.Start, this.input.LT(-1), ex2);
		}
		return iterationStatement_return;
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0001651C File Offset: 0x0001471C
	[global::Antlr.Runtime.GrammarRule("doStatement")]
	private global::ES3Parser.doStatement_return doStatement()
	{
		global::ES3Parser.doStatement_return doStatement_return = new global::ES3Parser.doStatement_return(this);
		doStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x26, global::ES3Parser.Follow._DO_in_doStatement5683);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			base.PushFollow(global::ES3Parser.Follow._statement_in_doStatement5685);
			global::ES3Parser.statement_return statement_return = this.statement();
			base.PopFollow();
			this.adaptor.AddChild(obj, statement_return.Tree);
			global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA5, global::ES3Parser.Follow._WHILE_in_doStatement5687);
			object child2 = this.adaptor.Create(payload2);
			this.adaptor.AddChild(obj, child2);
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_doStatement5689);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			base.PushFollow(global::ES3Parser.Follow._expression_in_doStatement5691);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_doStatement5693);
			object child4 = this.adaptor.Create(payload4);
			this.adaptor.AddChild(obj, child4);
			base.PushFollow(global::ES3Parser.Follow._semic_in_doStatement5695);
			global::ES3Parser.semic_return semic_return = this.semic();
			base.PopFollow();
			this.adaptor.AddChild(obj, semic_return.Tree);
			doStatement_return.value = new global::Jint.Expressions.DoWhileStatement((expression_return != null) ? expression_return.value : null, (statement_return != null) ? statement_return.value : null);
			doStatement_return.Stop = this.input.LT(-1);
			doStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(doStatement_return.Tree, doStatement_return.Start, doStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			doStatement_return.Tree = this.adaptor.ErrorNode(this.input, doStatement_return.Start, this.input.LT(-1), ex);
		}
		return doStatement_return;
	}

	// Token: 0x06000212 RID: 530 RVA: 0x000167B0 File Offset: 0x000149B0
	[global::Antlr.Runtime.GrammarRule("whileStatement")]
	private global::ES3Parser.whileStatement_return whileStatement()
	{
		global::ES3Parser.whileStatement_return whileStatement_return = new global::ES3Parser.whileStatement_return(this);
		whileStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA5, global::ES3Parser.Follow._WHILE_in_whileStatement5715);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_whileStatement5718);
			base.PushFollow(global::ES3Parser.Follow._expression_in_whileStatement5721);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_whileStatement5723);
			base.PushFollow(global::ES3Parser.Follow._statement_in_whileStatement5726);
			global::ES3Parser.statement_return statement_return = this.statement();
			base.PopFollow();
			this.adaptor.AddChild(obj, statement_return.Tree);
			whileStatement_return.value = new global::Jint.Expressions.WhileStatement((expression_return != null) ? expression_return.value : null, (statement_return != null) ? statement_return.value : null);
			whileStatement_return.Stop = this.input.LT(-1);
			whileStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(whileStatement_return.Tree, whileStatement_return.Start, whileStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			whileStatement_return.Tree = this.adaptor.ErrorNode(this.input, whileStatement_return.Start, this.input.LT(-1), ex);
		}
		return whileStatement_return;
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00016990 File Offset: 0x00014B90
	[global::Antlr.Runtime.GrammarRule("forStatement")]
	private global::ES3Parser.forStatement_return forStatement()
	{
		global::ES3Parser.forStatement_return forStatement_return = new global::ES3Parser.forStatement_return(this);
		forStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x3B, global::ES3Parser.Follow._FOR_in_forStatement5745);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_forStatement5748);
			base.PushFollow(global::ES3Parser.Follow._forControl_in_forStatement5753);
			global::ES3Parser.forControl_return forControl_return = this.forControl();
			base.PopFollow();
			this.adaptor.AddChild(obj, forControl_return.Tree);
			forStatement_return.value = forControl_return.value;
			global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_forStatement5758);
			base.PushFollow(global::ES3Parser.Follow._statement_in_forStatement5763);
			global::ES3Parser.statement_return statement_return = this.statement();
			base.PopFollow();
			this.adaptor.AddChild(obj, statement_return.Tree);
			forStatement_return.value.Statement = statement_return.value;
			forStatement_return.Stop = this.input.LT(-1);
			forStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(forStatement_return.Tree, forStatement_return.Start, forStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			forStatement_return.Tree = this.adaptor.ErrorNode(this.input, forStatement_return.Start, this.input.LT(-1), ex);
		}
		return forStatement_return;
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00016B58 File Offset: 0x00014D58
	[global::Antlr.Runtime.GrammarRule("forControl")]
	private global::ES3Parser.forControl_return forControl()
	{
		global::ES3Parser.forControl_return forControl_return = new global::ES3Parser.forControl_return(this);
		forControl_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = this.input.LA(1);
			int num2;
			if (num <= 0x4F)
			{
				if (num <= 0x36)
				{
					if (num <= 0x23)
					{
						if (num != 5)
						{
							switch (num)
							{
							case 0x21:
							case 0x23:
								break;
							case 0x22:
								goto IL_1BB;
							default:
								goto IL_1BB;
							}
						}
					}
					else if (num != 0x2C && num != 0x36)
					{
						goto IL_1BB;
					}
				}
				else if (num <= 0x44)
				{
					if (num != 0x3E && num != 0x44)
					{
						goto IL_1BB;
					}
				}
				else if (num != 0x49)
				{
					switch (num)
					{
					case 0x4D:
					case 0x4F:
						break;
					case 0x4E:
						goto IL_1BB;
					default:
						goto IL_1BB;
					}
				}
			}
			else if (num <= 0x72)
			{
				if (num <= 0x5A)
				{
					switch (num)
					{
					case 0x55:
					case 0x56:
						break;
					default:
						if (num != 0x5A)
						{
							goto IL_1BB;
						}
						break;
					}
				}
				else
				{
					switch (num)
					{
					case 0x69:
					case 0x6A:
					case 0x6C:
						break;
					case 0x6B:
						goto IL_1BB;
					default:
						if (num != 0x72)
						{
							goto IL_1BB;
						}
						break;
					}
				}
			}
			else if (num <= 0x90)
			{
				switch (num)
				{
				case 0x83:
					break;
				case 0x84:
					goto IL_1BB;
				case 0x85:
					num2 = 3;
					goto IL_1D3;
				default:
					if (num != 0x90)
					{
						goto IL_1BB;
					}
					break;
				}
			}
			else
			{
				switch (num)
				{
				case 0x96:
				case 0x98:
					break;
				case 0x97:
					goto IL_1BB;
				default:
					switch (num)
					{
					case 0x9C:
					case 0x9E:
					case 0xA2:
						break;
					case 0x9D:
					case 0x9F:
					case 0xA0:
						goto IL_1BB;
					case 0xA1:
						num2 = 1;
						goto IL_1D3;
					default:
						goto IL_1BB;
					}
					break;
				}
			}
			num2 = 2;
			goto IL_1D3;
			IL_1BB:
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x41, 0, this.input);
			throw ex;
			IL_1D3:
			switch (num2)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._forControlVar_in_forControl5782);
				global::ES3Parser.forControlVar_return forControlVar_return = this.forControlVar();
				base.PopFollow();
				this.adaptor.AddChild(obj, forControlVar_return.Tree);
				forControl_return.value = forControlVar_return.value;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._forControlExpression_in_forControl5791);
				global::ES3Parser.forControlExpression_return forControlExpression_return = this.forControlExpression();
				base.PopFollow();
				this.adaptor.AddChild(obj, forControlExpression_return.Tree);
				forControl_return.value = forControlExpression_return.value;
				break;
			}
			case 3:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._forControlSemic_in_forControl5800);
				global::ES3Parser.forControlSemic_return forControlSemic_return = this.forControlSemic();
				base.PopFollow();
				this.adaptor.AddChild(obj, forControlSemic_return.Tree);
				forControl_return.value = forControlSemic_return.value;
				break;
			}
			}
			forControl_return.Stop = this.input.LT(-1);
			forControl_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(forControl_return.Tree, forControl_return.Start, forControl_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			forControl_return.Tree = this.adaptor.ErrorNode(this.input, forControl_return.Start, this.input.LT(-1), ex2);
		}
		return forControl_return;
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00016ED4 File Offset: 0x000150D4
	[global::Antlr.Runtime.GrammarRule("forControlVar")]
	private global::ES3Parser.forControlVar_return forControlVar()
	{
		global::ES3Parser.forControlVar_return forControlVar_return = new global::ES3Parser.forControlVar_return(this);
		forControlVar_return.Start = this.input.LT(1);
		global::Jint.Expressions.ForStatement forStatement = new global::Jint.Expressions.ForStatement();
		global::Jint.Expressions.ForEachInStatement forEachInStatement = new global::Jint.Expressions.ForEachInStatement();
		global::Jint.Expressions.CommaOperatorStatement commaOperatorStatement = new global::Jint.Expressions.CommaOperatorStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA1, global::ES3Parser.Follow._VAR_in_forControlVar5828);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			base.PushFollow(global::ES3Parser.Follow._variableDeclarationNoIn_in_forControlVar5832);
			global::ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn_return = this.variableDeclarationNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, variableDeclarationNoIn_return.Tree);
			forEachInStatement.InitialisationStatement = (forStatement.InitialisationStatement = variableDeclarationNoIn_return.value);
			variableDeclarationNoIn_return.value.Global = false;
			int num = this.input.LA(1);
			int num2;
			if (num == 0x48)
			{
				num2 = 1;
			}
			else
			{
				if (num != 0x1B && num != 0x85)
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x45, 0, this.input);
					throw ex;
				}
				num2 = 2;
			}
			switch (num2)
			{
			case 1:
			{
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x48, global::ES3Parser.Follow._IN_in_forControlVar5846);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				base.PushFollow(global::ES3Parser.Follow._expression_in_forControlVar5850);
				global::ES3Parser.expression_return expression_return = this.expression();
				base.PopFollow();
				this.adaptor.AddChild(obj, expression_return.Tree);
				forControlVar_return.value = forEachInStatement;
				forEachInStatement.Expression = ((expression_return != null) ? expression_return.value : null);
				break;
			}
			case 2:
			{
				for (;;)
				{
					int num3 = 2;
					int num4 = this.input.LA(1);
					if (num4 == 0x1B)
					{
						num3 = 1;
					}
					int num5 = num3;
					if (num5 != 1)
					{
						break;
					}
					global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_forControlVar5875);
					object child3 = this.adaptor.Create(payload3);
					this.adaptor.AddChild(obj, child3);
					if (commaOperatorStatement.Statements.Count == 0)
					{
						forEachInStatement.InitialisationStatement = (forStatement.InitialisationStatement = commaOperatorStatement);
						commaOperatorStatement.Statements.Add(variableDeclarationNoIn_return.value);
					}
					base.PushFollow(global::ES3Parser.Follow._variableDeclarationNoIn_in_forControlVar5881);
					global::ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn_return2 = this.variableDeclarationNoIn();
					base.PopFollow();
					this.adaptor.AddChild(obj, variableDeclarationNoIn_return2.Tree);
					variableDeclarationNoIn_return2.value.Global = false;
					commaOperatorStatement.Statements.Add(variableDeclarationNoIn_return2.value);
				}
				global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_forControlVar5892);
				object child4 = this.adaptor.Create(payload4);
				this.adaptor.AddChild(obj, child4);
				int num6 = 2;
				int num7 = this.input.LA(1);
				if (num7 == 5 || num7 == 0x21 || num7 == 0x23 || num7 == 0x2C || num7 == 0x36 || num7 == 0x3E || num7 == 0x44 || num7 == 0x49 || num7 == 0x4D || num7 == 0x4F || (num7 >= 0x55 && num7 <= 0x56) || (num7 == 0x5A || (num7 >= 0x69 && num7 <= 0x6A)) || num7 == 0x6C || num7 == 0x72 || num7 == 0x83 || num7 == 0x90 || num7 == 0x96 || num7 == 0x98 || num7 == 0x9C || num7 == 0x9E || num7 == 0xA2)
				{
					num6 = 1;
				}
				int num8 = num6;
				if (num8 == 1)
				{
					base.PushFollow(global::ES3Parser.Follow._expression_in_forControlVar5898);
					global::ES3Parser.expression_return expression_return2 = this.expression();
					base.PopFollow();
					this.adaptor.AddChild(obj, expression_return2.Tree);
					forStatement.ConditionExpression = ((expression_return2 != null) ? expression_return2.value : null);
				}
				global::Antlr.Runtime.IToken payload5 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_forControlVar5906);
				object child5 = this.adaptor.Create(payload5);
				this.adaptor.AddChild(obj, child5);
				int num9 = 2;
				int num10 = this.input.LA(1);
				if (num10 == 5 || num10 == 0x21 || num10 == 0x23 || num10 == 0x2C || num10 == 0x36 || num10 == 0x3E || num10 == 0x44 || num10 == 0x49 || num10 == 0x4D || num10 == 0x4F || (num10 >= 0x55 && num10 <= 0x56) || (num10 == 0x5A || (num10 >= 0x69 && num10 <= 0x6A)) || num10 == 0x6C || num10 == 0x72 || num10 == 0x83 || num10 == 0x90 || num10 == 0x96 || num10 == 0x98 || num10 == 0x9C || num10 == 0x9E || num10 == 0xA2)
				{
					num9 = 1;
				}
				int num11 = num9;
				if (num11 == 1)
				{
					base.PushFollow(global::ES3Parser.Follow._expression_in_forControlVar5911);
					global::ES3Parser.expression_return expression_return3 = this.expression();
					base.PopFollow();
					this.adaptor.AddChild(obj, expression_return3.Tree);
					forStatement.IncrementExpression = ((expression_return3 != null) ? expression_return3.value : null);
				}
				forControlVar_return.value = forStatement;
				break;
			}
			}
			forControlVar_return.Stop = this.input.LT(-1);
			forControlVar_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(forControlVar_return.Tree, forControlVar_return.Start, forControlVar_return.Stop);
			if (commaOperatorStatement.Statements.Count > 0)
			{
				using (global::System.Collections.Generic.List<global::Jint.Expressions.Statement>.Enumerator enumerator = commaOperatorStatement.Statements.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						global::Jint.Expressions.Statement statement = enumerator.Current;
						global::Jint.Expressions.VariableDeclarationStatement variableDeclarationStatement = new global::Jint.Expressions.VariableDeclarationStatement();
						variableDeclarationStatement.Global = false;
						variableDeclarationStatement.Identifier = ((global::Jint.Expressions.VariableDeclarationStatement)statement).Identifier;
						this._currentBody.AddFirst(variableDeclarationStatement);
					}
					goto IL_6E3;
				}
			}
			global::Jint.Expressions.VariableDeclarationStatement variableDeclarationStatement2 = new global::Jint.Expressions.VariableDeclarationStatement();
			variableDeclarationStatement2.Global = false;
			variableDeclarationStatement2.Identifier = variableDeclarationNoIn_return.value.Identifier;
			this._currentBody.AddFirst(variableDeclarationStatement2);
			IL_6E3:;
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			forControlVar_return.Tree = this.adaptor.ErrorNode(this.input, forControlVar_return.Start, this.input.LT(-1), ex2);
		}
		return forControlVar_return;
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00017648 File Offset: 0x00015848
	[global::Antlr.Runtime.GrammarRule("forControlExpression")]
	private global::ES3Parser.forControlExpression_return forControlExpression()
	{
		global::ES3Parser.forControlExpression_return forControlExpression_return = new global::ES3Parser.forControlExpression_return(this);
		forControlExpression_return.Start = this.input.LT(1);
		global::Jint.Expressions.ForStatement forStatement = new global::Jint.Expressions.ForStatement();
		global::Jint.Expressions.ForEachInStatement forEachInStatement = new global::Jint.Expressions.ForEachInStatement();
		object[] cached = new object[1];
		try
		{
			object obj = this.adaptor.Nil();
			base.PushFollow(global::ES3Parser.Follow._expressionNoIn_in_forControlExpression5950);
			global::ES3Parser.expressionNoIn_return expressionNoIn_return = this.expressionNoIn();
			base.PopFollow();
			this.adaptor.AddChild(obj, expressionNoIn_return.Tree);
			forEachInStatement.InitialisationStatement = (forStatement.InitialisationStatement = expressionNoIn_return.value);
			int num = this.input.LA(1);
			int num2;
			if (num == 0x48)
			{
				num2 = 1;
			}
			else
			{
				if (num != 0x85)
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x48, 0, this.input);
					throw ex;
				}
				num2 = 2;
			}
			switch (num2)
			{
			case 1:
			{
				if (!this.IsLeftHandSideIn(expressionNoIn_return.value, cached))
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "forControlExpression", " IsLeftHandSideIn(ex1.value, isLhs) ");
				}
				global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x48, global::ES3Parser.Follow._IN_in_forControlExpression5967);
				object child = this.adaptor.Create(payload);
				this.adaptor.AddChild(obj, child);
				base.PushFollow(global::ES3Parser.Follow._expression_in_forControlExpression5971);
				global::ES3Parser.expression_return expression_return = this.expression();
				base.PopFollow();
				this.adaptor.AddChild(obj, expression_return.Tree);
				forControlExpression_return.value = forEachInStatement;
				forEachInStatement.Expression = expression_return.value;
				break;
			}
			case 2:
			{
				global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_forControlExpression5994);
				object child2 = this.adaptor.Create(payload2);
				this.adaptor.AddChild(obj, child2);
				int num3 = 2;
				int num4 = this.input.LA(1);
				if (num4 == 5 || num4 == 0x21 || num4 == 0x23 || num4 == 0x2C || num4 == 0x36 || num4 == 0x3E || num4 == 0x44 || num4 == 0x49 || num4 == 0x4D || num4 == 0x4F || (num4 >= 0x55 && num4 <= 0x56) || (num4 == 0x5A || (num4 >= 0x69 && num4 <= 0x6A)) || num4 == 0x6C || num4 == 0x72 || num4 == 0x83 || num4 == 0x90 || num4 == 0x96 || num4 == 0x98 || num4 == 0x9C || num4 == 0x9E || num4 == 0xA2)
				{
					num3 = 1;
				}
				int num5 = num3;
				if (num5 == 1)
				{
					base.PushFollow(global::ES3Parser.Follow._expression_in_forControlExpression6000);
					global::ES3Parser.expression_return expression_return = this.expression();
					base.PopFollow();
					this.adaptor.AddChild(obj, expression_return.Tree);
					forStatement.ConditionExpression = expression_return.value;
				}
				global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_forControlExpression6008);
				object child3 = this.adaptor.Create(payload3);
				this.adaptor.AddChild(obj, child3);
				int num6 = 2;
				int num7 = this.input.LA(1);
				if (num7 == 5 || num7 == 0x21 || num7 == 0x23 || num7 == 0x2C || num7 == 0x36 || num7 == 0x3E || num7 == 0x44 || num7 == 0x49 || num7 == 0x4D || num7 == 0x4F || (num7 >= 0x55 && num7 <= 0x56) || (num7 == 0x5A || (num7 >= 0x69 && num7 <= 0x6A)) || num7 == 0x6C || num7 == 0x72 || num7 == 0x83 || num7 == 0x90 || num7 == 0x96 || num7 == 0x98 || num7 == 0x9C || num7 == 0x9E || num7 == 0xA2)
				{
					num6 = 1;
				}
				int num8 = num6;
				if (num8 == 1)
				{
					base.PushFollow(global::ES3Parser.Follow._expression_in_forControlExpression6013);
					global::ES3Parser.expression_return expression_return2 = this.expression();
					base.PopFollow();
					this.adaptor.AddChild(obj, expression_return2.Tree);
					forStatement.IncrementExpression = expression_return2.value;
				}
				forControlExpression_return.value = forStatement;
				break;
			}
			}
			forControlExpression_return.Stop = this.input.LT(-1);
			forControlExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(forControlExpression_return.Tree, forControlExpression_return.Start, forControlExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			forControlExpression_return.Tree = this.adaptor.ErrorNode(this.input, forControlExpression_return.Start, this.input.LT(-1), ex2);
		}
		return forControlExpression_return;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00017BB0 File Offset: 0x00015DB0
	[global::Antlr.Runtime.GrammarRule("forControlSemic")]
	private global::ES3Parser.forControlSemic_return forControlSemic()
	{
		global::ES3Parser.forControlSemic_return forControlSemic_return = new global::ES3Parser.forControlSemic_return(this);
		forControlSemic_return.Start = this.input.LT(1);
		forControlSemic_return.value = new global::Jint.Expressions.ForStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_forControlSemic6049);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 5 || num2 == 0x21 || num2 == 0x23 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3E || num2 == 0x44 || num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || num2 == 0x6C || num2 == 0x72 || num2 == 0x83 || num2 == 0x90 || num2 == 0x96 || num2 == 0x98 || num2 == 0x9C || num2 == 0x9E || num2 == 0xA2)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._expression_in_forControlSemic6055);
				global::ES3Parser.expression_return expression_return = this.expression();
				base.PopFollow();
				this.adaptor.AddChild(obj, expression_return.Tree);
				forControlSemic_return.value.ConditionExpression = expression_return.value;
			}
			global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x85, global::ES3Parser.Follow._SEMIC_in_forControlSemic6063);
			object child2 = this.adaptor.Create(payload2);
			this.adaptor.AddChild(obj, child2);
			int num4 = 2;
			int num5 = this.input.LA(1);
			if (num5 == 5 || num5 == 0x21 || num5 == 0x23 || num5 == 0x2C || num5 == 0x36 || num5 == 0x3E || num5 == 0x44 || num5 == 0x49 || num5 == 0x4D || num5 == 0x4F || (num5 >= 0x55 && num5 <= 0x56) || (num5 == 0x5A || (num5 >= 0x69 && num5 <= 0x6A)) || num5 == 0x6C || num5 == 0x72 || num5 == 0x83 || num5 == 0x90 || num5 == 0x96 || num5 == 0x98 || num5 == 0x9C || num5 == 0x9E || num5 == 0xA2)
			{
				num4 = 1;
			}
			int num6 = num4;
			if (num6 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._expression_in_forControlSemic6068);
				global::ES3Parser.expression_return expression_return2 = this.expression();
				base.PopFollow();
				this.adaptor.AddChild(obj, expression_return2.Tree);
				forControlSemic_return.value.IncrementExpression = expression_return2.value;
			}
			forControlSemic_return.Stop = this.input.LT(-1);
			forControlSemic_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(forControlSemic_return.Tree, forControlSemic_return.Start, forControlSemic_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			forControlSemic_return.Tree = this.adaptor.ErrorNode(this.input, forControlSemic_return.Start, this.input.LT(-1), ex);
		}
		return forControlSemic_return;
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00017FB0 File Offset: 0x000161B0
	[global::Antlr.Runtime.GrammarRule("continueStatement")]
	private global::ES3Parser.continueStatement_return continueStatement()
	{
		global::ES3Parser.continueStatement_return continueStatement_return = new global::ES3Parser.continueStatement_return(this);
		continueStatement_return.Start = this.input.LT(1);
		string label = string.Empty;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1D, global::ES3Parser.Follow._CONTINUE_in_continueStatement6102);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			if (this.input.LA(1) == 0x4F)
			{
				this.PromoteEOL(null);
			}
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x4F)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_continueStatement6110);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				label = token.Text;
			}
			base.PushFollow(global::ES3Parser.Follow._semic_in_continueStatement6117);
			this.semic();
			base.PopFollow();
			continueStatement_return.value = new global::Jint.Expressions.ContinueStatement
			{
				Label = label
			};
			continueStatement_return.Stop = this.input.LT(-1);
			continueStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(continueStatement_return.Tree, continueStatement_return.Start, continueStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			continueStatement_return.Tree = this.adaptor.ErrorNode(this.input, continueStatement_return.Start, this.input.LT(-1), ex);
		}
		return continueStatement_return;
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00018188 File Offset: 0x00016388
	[global::Antlr.Runtime.GrammarRule("breakStatement")]
	private global::ES3Parser.breakStatement_return breakStatement()
	{
		global::ES3Parser.breakStatement_return breakStatement_return = new global::ES3Parser.breakStatement_return(this);
		breakStatement_return.Start = this.input.LT(1);
		string label = string.Empty;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xE, global::ES3Parser.Follow._BREAK_in_breakStatement6147);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			if (this.input.LA(1) == 0x4F)
			{
				this.PromoteEOL(null);
			}
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x4F)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_breakStatement6155);
				object child = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child);
				label = token.Text;
			}
			base.PushFollow(global::ES3Parser.Follow._semic_in_breakStatement6162);
			this.semic();
			base.PopFollow();
			breakStatement_return.value = new global::Jint.Expressions.BreakStatement
			{
				Label = label
			};
			breakStatement_return.Stop = this.input.LT(-1);
			breakStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(breakStatement_return.Tree, breakStatement_return.Start, breakStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			breakStatement_return.Tree = this.adaptor.ErrorNode(this.input, breakStatement_return.Start, this.input.LT(-1), ex);
		}
		return breakStatement_return;
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00018360 File Offset: 0x00016560
	[global::Antlr.Runtime.GrammarRule("returnStatement")]
	private global::ES3Parser.returnStatement_return returnStatement()
	{
		global::ES3Parser.returnStatement_return returnStatement_return = new global::ES3Parser.returnStatement_return(this);
		returnStatement_return.Start = this.input.LT(1);
		returnStatement_return.value = new global::Jint.Expressions.ReturnStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7F, global::ES3Parser.Follow._RETURN_in_returnStatement6192);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			this.PromoteEOL(null);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 5 || num2 == 0x21 || num2 == 0x23 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3E || num2 == 0x44 || num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || num2 == 0x6C || num2 == 0x72 || num2 == 0x83 || num2 == 0x90 || num2 == 0x96 || num2 == 0x98 || num2 == 0x9C || num2 == 0x9E || num2 == 0xA2)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				base.PushFollow(global::ES3Parser.Follow._expression_in_returnStatement6200);
				global::ES3Parser.expression_return expression_return = this.expression();
				base.PopFollow();
				this.adaptor.AddChild(obj, expression_return.Tree);
				returnStatement_return.value.Expression = expression_return.value;
			}
			base.PushFollow(global::ES3Parser.Follow._semic_in_returnStatement6206);
			this.semic();
			base.PopFollow();
			returnStatement_return.Stop = this.input.LT(-1);
			returnStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(returnStatement_return.Tree, returnStatement_return.Start, returnStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			returnStatement_return.Tree = this.adaptor.ErrorNode(this.input, returnStatement_return.Start, this.input.LT(-1), ex);
		}
		return returnStatement_return;
	}

	// Token: 0x0600021B RID: 539 RVA: 0x000185F0 File Offset: 0x000167F0
	[global::Antlr.Runtime.GrammarRule("withStatement")]
	private global::ES3Parser.withStatement_return withStatement()
	{
		global::ES3Parser.withStatement_return withStatement_return = new global::ES3Parser.withStatement_return(this);
		withStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0xA6, global::ES3Parser.Follow._WITH_in_withStatement6227);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_withStatement6230);
			base.PushFollow(global::ES3Parser.Follow._expression_in_withStatement6235);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_withStatement6237);
			base.PushFollow(global::ES3Parser.Follow._statement_in_withStatement6242);
			global::ES3Parser.statement_return statement_return = this.statement();
			base.PopFollow();
			this.adaptor.AddChild(obj, statement_return.Tree);
			withStatement_return.value = new global::Jint.Expressions.WithStatement(expression_return.value, statement_return.value);
			withStatement_return.Stop = this.input.LT(-1);
			withStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(withStatement_return.Tree, withStatement_return.Start, withStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			withStatement_return.Tree = this.adaptor.ErrorNode(this.input, withStatement_return.Start, this.input.LT(-1), ex);
		}
		return withStatement_return;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x000187B8 File Offset: 0x000169B8
	[global::Antlr.Runtime.GrammarRule("switchStatement")]
	private global::ES3Parser.switchStatement_return switchStatement()
	{
		global::ES3Parser.switchStatement_return switchStatement_return = new global::ES3Parser.switchStatement_return(this);
		switchStatement_return.Start = this.input.LT(1);
		global::Jint.Expressions.SwitchStatement switchStatement = new global::Jint.Expressions.SwitchStatement();
		switchStatement_return.value = switchStatement;
		int num = 0;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x93, global::ES3Parser.Follow._SWITCH_in_switchStatement6269);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_switchStatement6271);
			object child2 = this.adaptor.Create(payload2);
			this.adaptor.AddChild(obj, child2);
			base.PushFollow(global::ES3Parser.Follow._expression_in_switchStatement6273);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			switchStatement.Expression = ((expression_return != null) ? expression_return.value : null);
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_switchStatement6277);
			object child3 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child3);
			global::Antlr.Runtime.IToken payload4 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x55, global::ES3Parser.Follow._LBRACE_in_switchStatement6282);
			object child4 = this.adaptor.Create(payload4);
			this.adaptor.AddChild(obj, child4);
			for (;;)
			{
				int num2 = 3;
				int num3 = this.input.LA(1);
				if (num3 == 0x22 && num == 0)
				{
					num2 = 1;
				}
				else if (num3 == 0x15)
				{
					num2 = 2;
				}
				switch (num2)
				{
				case 1:
				{
					if (num != 0)
					{
						goto Block_8;
					}
					base.PushFollow(global::ES3Parser.Follow._defaultClause_in_switchStatement6289);
					global::ES3Parser.defaultClause_return defaultClause_return = this.defaultClause();
					base.PopFollow();
					this.adaptor.AddChild(obj, defaultClause_return.Tree);
					num++;
					switchStatement.DefaultStatements = ((defaultClause_return != null) ? defaultClause_return.value : null);
					continue;
				}
				case 2:
				{
					base.PushFollow(global::ES3Parser.Follow._caseClause_in_switchStatement6295);
					global::ES3Parser.caseClause_return caseClause_return = this.caseClause();
					base.PopFollow();
					this.adaptor.AddChild(obj, caseClause_return.Tree);
					switchStatement.CaseClauses.Add((caseClause_return != null) ? caseClause_return.value : null);
					continue;
				}
				}
				break;
			}
			global::Antlr.Runtime.IToken payload5 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7D, global::ES3Parser.Follow._RBRACE_in_switchStatement6302);
			object child5 = this.adaptor.Create(payload5);
			this.adaptor.AddChild(obj, child5);
			switchStatement_return.Stop = this.input.LT(-1);
			switchStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(switchStatement_return.Tree, switchStatement_return.Start, switchStatement_return.Stop);
			return switchStatement_return;
			Block_8:
			throw new global::Antlr.Runtime.FailedPredicateException(this.input, "switchStatement", " defaultClauseCount == 0 ");
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			switchStatement_return.Tree = this.adaptor.ErrorNode(this.input, switchStatement_return.Start, this.input.LT(-1), ex);
		}
		return switchStatement_return;
	}

	// Token: 0x0600021D RID: 541 RVA: 0x00018B3C File Offset: 0x00016D3C
	[global::Antlr.Runtime.GrammarRule("caseClause")]
	private global::ES3Parser.caseClause_return caseClause()
	{
		global::ES3Parser.caseClause_return caseClause_return = new global::ES3Parser.caseClause_return(this);
		caseClause_return.Start = this.input.LT(1);
		caseClause_return.value = new global::Jint.Expressions.CaseClause();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x15, global::ES3Parser.Follow._CASE_in_caseClause6325);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			base.PushFollow(global::ES3Parser.Follow._expression_in_caseClause6328);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			caseClause_return.value.Expression = ((expression_return != null) ? expression_return.value : null);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1A, global::ES3Parser.Follow._COLON_in_caseClause6332);
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 5 || num2 == 0xE || num2 == 0x1D || num2 == 0x21 || num2 == 0x23 || num2 == 0x26 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3B || num2 == 0x3E || (num2 >= 0x44 && num2 <= 0x45) || (num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56)) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || (num2 == 0x6C || num2 == 0x72 || num2 == 0x7F || num2 == 0x83 || num2 == 0x85 || num2 == 0x90 || num2 == 0x93 || num2 == 0x96 || (num2 >= 0x98 && num2 <= 0x99)) || (num2 >= 0x9C && num2 <= 0x9E) || (num2 >= 0xA1 && num2 <= 0xA2) || (num2 >= 0xA5 && num2 <= 0xA6))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				base.PushFollow(global::ES3Parser.Follow._statement_in_caseClause6336);
				global::ES3Parser.statement_return statement_return = this.statement();
				base.PopFollow();
				this.adaptor.AddChild(obj, statement_return.Tree);
				caseClause_return.value.Statements.Statements.AddLast((statement_return != null) ? statement_return.value : null);
			}
			caseClause_return.Stop = this.input.LT(-1);
			caseClause_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(caseClause_return.Tree, caseClause_return.Start, caseClause_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			caseClause_return.Tree = this.adaptor.ErrorNode(this.input, caseClause_return.Start, this.input.LT(-1), ex);
		}
		return caseClause_return;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x00018EAC File Offset: 0x000170AC
	[global::Antlr.Runtime.GrammarRule("defaultClause")]
	private global::ES3Parser.defaultClause_return defaultClause()
	{
		global::ES3Parser.defaultClause_return defaultClause_return = new global::ES3Parser.defaultClause_return(this);
		defaultClause_return.Start = this.input.LT(1);
		defaultClause_return.value = new global::Jint.Expressions.BlockStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x22, global::ES3Parser.Follow._DEFAULT_in_defaultClause6361);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1A, global::ES3Parser.Follow._COLON_in_defaultClause6364);
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 5 || num2 == 0xE || num2 == 0x1D || num2 == 0x21 || num2 == 0x23 || num2 == 0x26 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3B || num2 == 0x3E || (num2 >= 0x44 && num2 <= 0x45) || (num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56)) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || (num2 == 0x6C || num2 == 0x72 || num2 == 0x7F || num2 == 0x83 || num2 == 0x85 || num2 == 0x90 || num2 == 0x93 || num2 == 0x96 || (num2 >= 0x98 && num2 <= 0x99)) || (num2 >= 0x9C && num2 <= 0x9E) || (num2 >= 0xA1 && num2 <= 0xA2) || (num2 >= 0xA5 && num2 <= 0xA6))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				base.PushFollow(global::ES3Parser.Follow._statement_in_defaultClause6368);
				global::ES3Parser.statement_return statement_return = this.statement();
				base.PopFollow();
				this.adaptor.AddChild(obj, statement_return.Tree);
				defaultClause_return.value.Statements.AddLast((statement_return != null) ? statement_return.value : null);
			}
			defaultClause_return.Stop = this.input.LT(-1);
			defaultClause_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(defaultClause_return.Tree, defaultClause_return.Start, defaultClause_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			defaultClause_return.Tree = this.adaptor.ErrorNode(this.input, defaultClause_return.Start, this.input.LT(-1), ex);
		}
		return defaultClause_return;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x000191C8 File Offset: 0x000173C8
	[global::Antlr.Runtime.GrammarRule("labelledStatement")]
	private global::ES3Parser.labelledStatement_return labelledStatement()
	{
		global::ES3Parser.labelledStatement_return labelledStatement_return = new global::ES3Parser.labelledStatement_return(this);
		labelledStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_labelledStatement6395);
			object child = this.adaptor.Create(token);
			this.adaptor.AddChild(obj, child);
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1A, global::ES3Parser.Follow._COLON_in_labelledStatement6397);
			object child2 = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child2);
			base.PushFollow(global::ES3Parser.Follow._statement_in_labelledStatement6401);
			global::ES3Parser.statement_return statement_return = this.statement();
			base.PopFollow();
			this.adaptor.AddChild(obj, statement_return.Tree);
			labelledStatement_return.value = statement_return.value;
			labelledStatement_return.value.Label = token.Text;
			labelledStatement_return.Stop = this.input.LT(-1);
			labelledStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(labelledStatement_return.Tree, labelledStatement_return.Start, labelledStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			labelledStatement_return.Tree = this.adaptor.ErrorNode(this.input, labelledStatement_return.Start, this.input.LT(-1), ex);
		}
		return labelledStatement_return;
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00019368 File Offset: 0x00017568
	[global::Antlr.Runtime.GrammarRule("throwStatement")]
	private global::ES3Parser.throwStatement_return throwStatement()
	{
		global::ES3Parser.throwStatement_return throwStatement_return = new global::ES3Parser.throwStatement_return(this);
		throwStatement_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x99, global::ES3Parser.Follow._THROW_in_throwStatement6427);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			this.PromoteEOL(null);
			base.PushFollow(global::ES3Parser.Follow._expression_in_throwStatement6434);
			global::ES3Parser.expression_return expression_return = this.expression();
			base.PopFollow();
			this.adaptor.AddChild(obj, expression_return.Tree);
			throwStatement_return.value = new global::Jint.Expressions.ThrowStatement(expression_return.value);
			base.PushFollow(global::ES3Parser.Follow._semic_in_throwStatement6438);
			this.semic();
			base.PopFollow();
			throwStatement_return.Stop = this.input.LT(-1);
			throwStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(throwStatement_return.Tree, throwStatement_return.Start, throwStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			throwStatement_return.Tree = this.adaptor.ErrorNode(this.input, throwStatement_return.Start, this.input.LT(-1), ex);
		}
		return throwStatement_return;
	}

	// Token: 0x06000221 RID: 545 RVA: 0x000194D8 File Offset: 0x000176D8
	[global::Antlr.Runtime.GrammarRule("tryStatement")]
	private global::ES3Parser.tryStatement_return tryStatement()
	{
		global::ES3Parser.tryStatement_return tryStatement_return = new global::ES3Parser.tryStatement_return(this);
		tryStatement_return.Start = this.input.LT(1);
		tryStatement_return.value = new global::Jint.Expressions.TryStatement();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x9D, global::ES3Parser.Follow._TRY_in_tryStatement6463);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			base.PushFollow(global::ES3Parser.Follow._block_in_tryStatement6468);
			global::ES3Parser.block_return block_return = this.block();
			base.PopFollow();
			this.adaptor.AddChild(obj, block_return.Tree);
			tryStatement_return.value.Statement = block_return.value;
			int num = this.input.LA(1);
			int num2;
			if (num == 0x16)
			{
				num2 = 1;
			}
			else
			{
				if (num != 0x39)
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x52, 0, this.input);
					throw ex;
				}
				num2 = 2;
			}
			switch (num2)
			{
			case 1:
			{
				base.PushFollow(global::ES3Parser.Follow._catchClause_in_tryStatement6477);
				global::ES3Parser.catchClause_return catchClause_return = this.catchClause();
				base.PopFollow();
				this.adaptor.AddChild(obj, catchClause_return.Tree);
				tryStatement_return.value.Catch = catchClause_return.value;
				int num3 = 2;
				int num4 = this.input.LA(1);
				if (num4 == 0x39)
				{
					num3 = 1;
				}
				int num5 = num3;
				if (num5 == 1)
				{
					base.PushFollow(global::ES3Parser.Follow._finallyClause_in_tryStatement6484);
					global::ES3Parser.finallyClause_return finallyClause_return = this.finallyClause();
					base.PopFollow();
					this.adaptor.AddChild(obj, finallyClause_return.Tree);
					tryStatement_return.value.Finally = finallyClause_return.value;
				}
				break;
			}
			case 2:
			{
				base.PushFollow(global::ES3Parser.Follow._finallyClause_in_tryStatement6494);
				global::ES3Parser.finallyClause_return finallyClause_return2 = this.finallyClause();
				base.PopFollow();
				this.adaptor.AddChild(obj, finallyClause_return2.Tree);
				tryStatement_return.value.Finally = finallyClause_return2.value;
				break;
			}
			}
			tryStatement_return.Stop = this.input.LT(-1);
			tryStatement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(tryStatement_return.Tree, tryStatement_return.Start, tryStatement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex2)
		{
			this.ReportError(ex2);
			this.Recover(this.input, ex2);
			tryStatement_return.Tree = this.adaptor.ErrorNode(this.input, tryStatement_return.Start, this.input.LT(-1), ex2);
		}
		return tryStatement_return;
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00019794 File Offset: 0x00017994
	[global::Antlr.Runtime.GrammarRule("catchClause")]
	private global::ES3Parser.catchClause_return catchClause()
	{
		global::ES3Parser.catchClause_return catchClause_return = new global::ES3Parser.catchClause_return(this);
		catchClause_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x16, global::ES3Parser.Follow._CATCH_in_catchClause6514);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_catchClause6517);
			global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_catchClause6522);
			object child = this.adaptor.Create(token2);
			this.adaptor.AddChild(obj, child);
			global::Antlr.Runtime.IToken token3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_catchClause6524);
			base.PushFollow(global::ES3Parser.Follow._block_in_catchClause6527);
			global::ES3Parser.block_return block_return = this.block();
			base.PopFollow();
			this.adaptor.AddChild(obj, block_return.Tree);
			catchClause_return.value = new global::Jint.Expressions.CatchClause((token2 != null) ? token2.Text : null, (block_return != null) ? block_return.value : null);
			catchClause_return.Stop = this.input.LT(-1);
			catchClause_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(catchClause_return.Tree, catchClause_return.Start, catchClause_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			catchClause_return.Tree = this.adaptor.ErrorNode(this.input, catchClause_return.Start, this.input.LT(-1), ex);
		}
		return catchClause_return;
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00019980 File Offset: 0x00017B80
	[global::Antlr.Runtime.GrammarRule("finallyClause")]
	private global::ES3Parser.finallyClause_return finallyClause()
	{
		global::ES3Parser.finallyClause_return finallyClause_return = new global::ES3Parser.finallyClause_return(this);
		finallyClause_return.Start = this.input.LT(1);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x39, global::ES3Parser.Follow._FINALLY_in_finallyClause6545);
			object newRoot = this.adaptor.Create(payload);
			obj = this.adaptor.BecomeRoot(newRoot, obj);
			base.PushFollow(global::ES3Parser.Follow._block_in_finallyClause6548);
			global::ES3Parser.block_return block_return = this.block();
			base.PopFollow();
			this.adaptor.AddChild(obj, block_return.Tree);
			finallyClause_return.value = new global::Jint.Expressions.FinallyClause((block_return != null) ? block_return.value : null);
			finallyClause_return.Stop = this.input.LT(-1);
			finallyClause_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(finallyClause_return.Tree, finallyClause_return.Start, finallyClause_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			finallyClause_return.Tree = this.adaptor.ErrorNode(this.input, finallyClause_return.Start, this.input.LT(-1), ex);
		}
		return finallyClause_return;
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00019AD8 File Offset: 0x00017CD8
	[global::Antlr.Runtime.GrammarRule("functionDeclaration")]
	private global::ES3Parser.functionDeclaration_return functionDeclaration()
	{
		global::ES3Parser.functionDeclaration_return functionDeclaration_return = new global::ES3Parser.functionDeclaration_return(this);
		functionDeclaration_return.Start = this.input.LT(1);
		global::Jint.Expressions.FunctionDeclarationStatement functionDeclarationStatement = new global::Jint.Expressions.FunctionDeclarationStatement();
		functionDeclaration_return.value = new global::Jint.Expressions.EmptyStatement();
		this._currentBody.AddFirst(functionDeclarationStatement);
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x3E, global::ES3Parser.Follow._FUNCTION_in_functionDeclaration6580);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_functionDeclaration6585);
			object child2 = this.adaptor.Create(token);
			this.adaptor.AddChild(obj, child2);
			functionDeclarationStatement.Name = token.Text;
			base.PushFollow(global::ES3Parser.Follow._formalParameterList_in_functionDeclaration6595);
			global::ES3Parser.formalParameterList_return formalParameterList_return = this.formalParameterList();
			base.PopFollow();
			this.adaptor.AddChild(obj, formalParameterList_return.Tree);
			functionDeclarationStatement.Parameters.AddRange(formalParameterList_return.value);
			base.PushFollow(global::ES3Parser.Follow._functionBody_in_functionDeclaration6604);
			global::ES3Parser.functionBody_return functionBody_return = this.functionBody();
			base.PopFollow();
			this.adaptor.AddChild(obj, functionBody_return.Tree);
			functionDeclarationStatement.Statement = functionBody_return.value;
			functionDeclaration_return.Stop = this.input.LT(-1);
			functionDeclaration_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(functionDeclaration_return.Tree, functionDeclaration_return.Start, functionDeclaration_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			functionDeclaration_return.Tree = this.adaptor.ErrorNode(this.input, functionDeclaration_return.Start, this.input.LT(-1), ex);
		}
		return functionDeclaration_return;
	}

	// Token: 0x06000225 RID: 549 RVA: 0x00019CD8 File Offset: 0x00017ED8
	[global::Antlr.Runtime.GrammarRule("functionExpression")]
	private global::ES3Parser.functionExpression_return functionExpression()
	{
		global::ES3Parser.functionExpression_return functionExpression_return = new global::ES3Parser.functionExpression_return(this);
		functionExpression_return.Start = this.input.LT(1);
		functionExpression_return.value = new global::Jint.Expressions.FunctionExpression();
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x3E, global::ES3Parser.Follow._FUNCTION_in_functionExpression6631);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x4F)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_functionExpression6636);
				object child2 = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child2);
				functionExpression_return.value.Name = token.Text;
			}
			base.PushFollow(global::ES3Parser.Follow._formalParameterList_in_functionExpression6643);
			global::ES3Parser.formalParameterList_return formalParameterList_return = this.formalParameterList();
			base.PopFollow();
			this.adaptor.AddChild(obj, formalParameterList_return.Tree);
			functionExpression_return.value.Parameters.AddRange((formalParameterList_return != null) ? formalParameterList_return.value : null);
			base.PushFollow(global::ES3Parser.Follow._functionBody_in_functionExpression6647);
			global::ES3Parser.functionBody_return functionBody_return = this.functionBody();
			base.PopFollow();
			this.adaptor.AddChild(obj, functionBody_return.Tree);
			functionExpression_return.value.Statement = ((functionBody_return != null) ? functionBody_return.value : null);
			functionExpression_return.Stop = this.input.LT(-1);
			functionExpression_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(functionExpression_return.Tree, functionExpression_return.Start, functionExpression_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			functionExpression_return.Tree = this.adaptor.ErrorNode(this.input, functionExpression_return.Start, this.input.LT(-1), ex);
		}
		return functionExpression_return;
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00019F14 File Offset: 0x00018114
	[global::Antlr.Runtime.GrammarRule("formalParameterList")]
	private global::ES3Parser.formalParameterList_return formalParameterList()
	{
		global::ES3Parser.formalParameterList_return formalParameterList_return = new global::ES3Parser.formalParameterList_return(this);
		formalParameterList_return.Start = this.input.LT(1);
		global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
		formalParameterList_return.value = list;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x5A, global::ES3Parser.Follow._LPAREN_in_formalParameterList6672);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x4F)
			{
				num = 1;
			}
			int num3 = num;
			if (num3 == 1)
			{
				global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_formalParameterList6678);
				object child2 = this.adaptor.Create(token);
				this.adaptor.AddChild(obj, child2);
				list.Add((token != null) ? token.Text : null);
				for (;;)
				{
					int num4 = 2;
					int num5 = this.input.LA(1);
					if (num5 == 0x1B)
					{
						num4 = 1;
					}
					int num6 = num4;
					if (num6 != 1)
					{
						break;
					}
					global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x1B, global::ES3Parser.Follow._COMMA_in_formalParameterList6684);
					object child3 = this.adaptor.Create(payload2);
					this.adaptor.AddChild(obj, child3);
					global::Antlr.Runtime.IToken token2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x4F, global::ES3Parser.Follow._Identifier_in_formalParameterList6688);
					object child4 = this.adaptor.Create(token2);
					this.adaptor.AddChild(obj, child4);
					list.Add((token2 != null) ? token2.Text : null);
				}
			}
			global::Antlr.Runtime.IToken payload3 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x80, global::ES3Parser.Follow._RPAREN_in_formalParameterList6699);
			object child5 = this.adaptor.Create(payload3);
			this.adaptor.AddChild(obj, child5);
			formalParameterList_return.Stop = this.input.LT(-1);
			formalParameterList_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(formalParameterList_return.Tree, formalParameterList_return.Start, formalParameterList_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			formalParameterList_return.Tree = this.adaptor.ErrorNode(this.input, formalParameterList_return.Start, this.input.LT(-1), ex);
		}
		return formalParameterList_return;
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0001A1BC File Offset: 0x000183BC
	[global::Antlr.Runtime.GrammarRule("functionBody")]
	private global::ES3Parser.functionBody_return functionBody()
	{
		global::ES3Parser.functionBody_return functionBody_return = new global::ES3Parser.functionBody_return(this);
		functionBody_return.Start = this.input.LT(1);
		global::Jint.Expressions.BlockStatement blockStatement = new global::Jint.Expressions.BlockStatement();
		global::System.Collections.Generic.LinkedList<global::Jint.Expressions.Statement> currentBody = this._currentBody;
		this._currentBody = blockStatement.Statements;
		functionBody_return.value = blockStatement;
		try
		{
			object obj = this.adaptor.Nil();
			global::Antlr.Runtime.IToken payload = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x55, global::ES3Parser.Follow._LBRACE_in_functionBody6726);
			object child = this.adaptor.Create(payload);
			this.adaptor.AddChild(obj, child);
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 5 || num2 == 0xE || num2 == 0x1D || num2 == 0x21 || num2 == 0x23 || num2 == 0x26 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3B || num2 == 0x3E || (num2 >= 0x44 && num2 <= 0x45) || (num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56)) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || (num2 == 0x6C || num2 == 0x72 || num2 == 0x7F || num2 == 0x83 || num2 == 0x85 || num2 == 0x90 || num2 == 0x93 || num2 == 0x96 || (num2 >= 0x98 && num2 <= 0x99)) || (num2 >= 0x9C && num2 <= 0x9E) || (num2 >= 0xA1 && num2 <= 0xA2) || (num2 >= 0xA5 && num2 <= 0xA6))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				base.PushFollow(global::ES3Parser.Follow._sourceElement_in_functionBody6729);
				global::ES3Parser.sourceElement_return sourceElement_return = this.sourceElement();
				base.PopFollow();
				this.adaptor.AddChild(obj, sourceElement_return.Tree);
				blockStatement.Statements.AddLast((sourceElement_return != null) ? sourceElement_return.value : null);
			}
			global::Antlr.Runtime.IToken payload2 = (global::Antlr.Runtime.IToken)this.Match(this.input, 0x7D, global::ES3Parser.Follow._RBRACE_in_functionBody6736);
			object child2 = this.adaptor.Create(payload2);
			this.adaptor.AddChild(obj, child2);
			functionBody_return.Stop = this.input.LT(-1);
			functionBody_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(functionBody_return.Tree, functionBody_return.Start, functionBody_return.Stop);
			this._currentBody = currentBody;
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			functionBody_return.Tree = this.adaptor.ErrorNode(this.input, functionBody_return.Start, this.input.LT(-1), ex);
		}
		return functionBody_return;
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0001A51C File Offset: 0x0001871C
	[global::Antlr.Runtime.GrammarRule("program")]
	public global::ES3Parser.program_return program()
	{
		global::ES3Parser.program_return program_return = new global::ES3Parser.program_return(this);
		program_return.Start = this.input.LT(1);
		this.script = this.input.ToString().Split(new char[]
		{
			'\n'
		});
		global::Jint.Expressions.Program program = new global::Jint.Expressions.Program();
		this._currentBody = program.Statements;
		try
		{
			object obj = this.adaptor.Nil();
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if (num2 == 5 || num2 == 0xE || num2 == 0x1D || num2 == 0x21 || num2 == 0x23 || num2 == 0x26 || num2 == 0x2C || num2 == 0x36 || num2 == 0x3B || num2 == 0x3E || (num2 >= 0x44 && num2 <= 0x45) || (num2 == 0x49 || num2 == 0x4D || num2 == 0x4F || (num2 >= 0x55 && num2 <= 0x56)) || (num2 == 0x5A || (num2 >= 0x69 && num2 <= 0x6A)) || (num2 == 0x6C || num2 == 0x72 || num2 == 0x7F || num2 == 0x83 || num2 == 0x85 || num2 == 0x90 || num2 == 0x93 || num2 == 0x96 || (num2 >= 0x98 && num2 <= 0x99)) || (num2 >= 0x9C && num2 <= 0x9E) || (num2 >= 0xA1 && num2 <= 0xA2) || (num2 >= 0xA5 && num2 <= 0xA6))
				{
					num = 1;
				}
				int num3 = num;
				if (num3 != 1)
				{
					break;
				}
				base.PushFollow(global::ES3Parser.Follow._sourceElement_in_program6765);
				global::ES3Parser.sourceElement_return sourceElement_return = this.sourceElement();
				base.PopFollow();
				this.adaptor.AddChild(obj, sourceElement_return.Tree);
				program.Statements.AddLast(sourceElement_return.value);
			}
			program_return.value = program;
			program_return.Stop = this.input.LT(-1);
			program_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(program_return.Tree, program_return.Start, program_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			program_return.Tree = this.adaptor.ErrorNode(this.input, program_return.Start, this.input.LT(-1), ex);
		}
		return program_return;
	}

	// Token: 0x06000229 RID: 553 RVA: 0x0001A808 File Offset: 0x00018A08
	[global::Antlr.Runtime.GrammarRule("sourceElement")]
	private global::ES3Parser.sourceElement_return sourceElement()
	{
		global::ES3Parser.sourceElement_return sourceElement_return = new global::ES3Parser.sourceElement_return(this);
		sourceElement_return.Start = this.input.LT(1);
		object obj = null;
		try
		{
			int num = 2;
			try
			{
				num = this.dfa88.Predict(this.input);
			}
			catch (global::Antlr.Runtime.NoViableAltException)
			{
				throw;
			}
			switch (num)
			{
			case 1:
			{
				obj = this.adaptor.Nil();
				if (this.input.LA(1) != 0x3E)
				{
					throw new global::Antlr.Runtime.FailedPredicateException(this.input, "sourceElement", " input.LA(1) == FUNCTION ");
				}
				base.PushFollow(global::ES3Parser.Follow._functionDeclaration_in_sourceElement6806);
				global::ES3Parser.functionDeclaration_return functionDeclaration_return = this.functionDeclaration();
				base.PopFollow();
				this.adaptor.AddChild(obj, functionDeclaration_return.Tree);
				sourceElement_return.value = functionDeclaration_return.value;
				break;
			}
			case 2:
			{
				obj = this.adaptor.Nil();
				base.PushFollow(global::ES3Parser.Follow._statement_in_sourceElement6815);
				global::ES3Parser.statement_return statement_return = this.statement();
				base.PopFollow();
				this.adaptor.AddChild(obj, statement_return.Tree);
				sourceElement_return.value = statement_return.value;
				break;
			}
			}
			sourceElement_return.Stop = this.input.LT(-1);
			sourceElement_return.Tree = this.adaptor.RulePostProcessing(obj);
			this.adaptor.SetTokenBoundaries(sourceElement_return.Tree, sourceElement_return.Start, sourceElement_return.Stop);
		}
		catch (global::Antlr.Runtime.RecognitionException ex)
		{
			this.ReportError(ex);
			this.Recover(this.input, ex);
			sourceElement_return.Tree = this.adaptor.ErrorNode(this.input, sourceElement_return.Start, this.input.LT(-1), ex);
		}
		return sourceElement_return;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0001A9E4 File Offset: 0x00018BE4
	protected override void InitDFAs()
	{
		base.InitDFAs();
		this.dfa57 = new global::ES3Parser.DFA57(this, new global::Antlr.Runtime.SpecialStateTransitionHandler(this.SpecialStateTransition57));
		this.dfa58 = new global::ES3Parser.DFA58(this);
		this.dfa88 = new global::ES3Parser.DFA88(this, new global::Antlr.Runtime.SpecialStateTransitionHandler(this.SpecialStateTransition88));
	}

	// Token: 0x0600022B RID: 555 RVA: 0x0001AA38 File Offset: 0x00018C38
	private int SpecialStateTransition57(global::Antlr.Runtime.DFA dfa, int s, global::Antlr.Runtime.IIntStream _input)
	{
		global::Antlr.Runtime.ITokenStream tokenStream = (global::Antlr.Runtime.ITokenStream)_input;
		int stateNumber = s;
		switch (s)
		{
		case 0:
		{
			tokenStream.LA(1);
			int index = tokenStream.Index;
			tokenStream.Rewind();
			s = -1;
			if (tokenStream.LA(1) == 0x55)
			{
				s = 0x26;
			}
			else
			{
				s = 3;
			}
			tokenStream.Seek(index);
			if (s >= 0)
			{
				return s;
			}
			break;
		}
		case 1:
		{
			tokenStream.LA(1);
			int index2 = tokenStream.Index;
			tokenStream.Rewind();
			s = -1;
			if (tokenStream.LA(1) == 0x3E)
			{
				s = 0x27;
			}
			else
			{
				s = 3;
			}
			tokenStream.Seek(index2);
			if (s >= 0)
			{
				return s;
			}
			break;
		}
		}
		global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException(dfa.Description, 0x39, stateNumber, tokenStream);
		dfa.Error(ex);
		throw ex;
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0001AB08 File Offset: 0x00018D08
	private int SpecialStateTransition88(global::Antlr.Runtime.DFA dfa, int s, global::Antlr.Runtime.IIntStream _input)
	{
		global::Antlr.Runtime.ITokenStream tokenStream = (global::Antlr.Runtime.ITokenStream)_input;
		int stateNumber = s;
		int num = s;
		if (num == 0)
		{
			tokenStream.LA(1);
			int index = tokenStream.Index;
			tokenStream.Rewind();
			s = -1;
			if (tokenStream.LA(1) == 0x3E)
			{
				s = 0x26;
			}
			else
			{
				s = 2;
			}
			tokenStream.Seek(index);
			if (s >= 0)
			{
				return s;
			}
		}
		global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException(dfa.Description, 0x58, stateNumber, tokenStream);
		dfa.Error(ex);
		throw ex;
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0001AB88 File Offset: 0x00018D88
	// Note: this type is marked as 'beforefieldinit'.
	static ES3Parser()
	{
	}

	// Token: 0x04000113 RID: 275
	public const int EOF = -1;

	// Token: 0x04000114 RID: 276
	public const int ABSTRACT = 4;

	// Token: 0x04000115 RID: 277
	public const int ADD = 5;

	// Token: 0x04000116 RID: 278
	public const int ADDASS = 6;

	// Token: 0x04000117 RID: 279
	public const int AND = 7;

	// Token: 0x04000118 RID: 280
	public const int ANDASS = 8;

	// Token: 0x04000119 RID: 281
	public const int ARGS = 9;

	// Token: 0x0400011A RID: 282
	public const int ARRAY = 0xA;

	// Token: 0x0400011B RID: 283
	public const int ASSIGN = 0xB;

	// Token: 0x0400011C RID: 284
	public const int BLOCK = 0xC;

	// Token: 0x0400011D RID: 285
	public const int BOOLEAN = 0xD;

	// Token: 0x0400011E RID: 286
	public const int BREAK = 0xE;

	// Token: 0x0400011F RID: 287
	public const int BSLASH = 0xF;

	// Token: 0x04000120 RID: 288
	public const int BYFIELD = 0x10;

	// Token: 0x04000121 RID: 289
	public const int BYINDEX = 0x11;

	// Token: 0x04000122 RID: 290
	public const int BYTE = 0x12;

	// Token: 0x04000123 RID: 291
	public const int BackslashSequence = 0x13;

	// Token: 0x04000124 RID: 292
	public const int CALL = 0x14;

	// Token: 0x04000125 RID: 293
	public const int CASE = 0x15;

	// Token: 0x04000126 RID: 294
	public const int CATCH = 0x16;

	// Token: 0x04000127 RID: 295
	public const int CEXPR = 0x17;

	// Token: 0x04000128 RID: 296
	public const int CHAR = 0x18;

	// Token: 0x04000129 RID: 297
	public const int CLASS = 0x19;

	// Token: 0x0400012A RID: 298
	public const int COLON = 0x1A;

	// Token: 0x0400012B RID: 299
	public const int COMMA = 0x1B;

	// Token: 0x0400012C RID: 300
	public const int CONST = 0x1C;

	// Token: 0x0400012D RID: 301
	public const int CONTINUE = 0x1D;

	// Token: 0x0400012E RID: 302
	public const int CR = 0x1E;

	// Token: 0x0400012F RID: 303
	public const int CharacterEscapeSequence = 0x1F;

	// Token: 0x04000130 RID: 304
	public const int DEBUGGER = 0x20;

	// Token: 0x04000131 RID: 305
	public const int DEC = 0x21;

	// Token: 0x04000132 RID: 306
	public const int DEFAULT = 0x22;

	// Token: 0x04000133 RID: 307
	public const int DELETE = 0x23;

	// Token: 0x04000134 RID: 308
	public const int DIV = 0x24;

	// Token: 0x04000135 RID: 309
	public const int DIVASS = 0x25;

	// Token: 0x04000136 RID: 310
	public const int DO = 0x26;

	// Token: 0x04000137 RID: 311
	public const int DOT = 0x27;

	// Token: 0x04000138 RID: 312
	public const int DOUBLE = 0x28;

	// Token: 0x04000139 RID: 313
	public const int DQUOTE = 0x29;

	// Token: 0x0400013A RID: 314
	public const int DecimalDigit = 0x2A;

	// Token: 0x0400013B RID: 315
	public const int DecimalIntegerLiteral = 0x2B;

	// Token: 0x0400013C RID: 316
	public const int DecimalLiteral = 0x2C;

	// Token: 0x0400013D RID: 317
	public const int ELSE = 0x2D;

	// Token: 0x0400013E RID: 318
	public const int ENUM = 0x2E;

	// Token: 0x0400013F RID: 319
	public const int EOL = 0x2F;

	// Token: 0x04000140 RID: 320
	public const int EQ = 0x30;

	// Token: 0x04000141 RID: 321
	public const int EXPORT = 0x31;

	// Token: 0x04000142 RID: 322
	public const int EXPR = 0x32;

	// Token: 0x04000143 RID: 323
	public const int EXTENDS = 0x33;

	// Token: 0x04000144 RID: 324
	public const int EscapeSequence = 0x34;

	// Token: 0x04000145 RID: 325
	public const int ExponentPart = 0x35;

	// Token: 0x04000146 RID: 326
	public const int FALSE = 0x36;

	// Token: 0x04000147 RID: 327
	public const int FF = 0x37;

	// Token: 0x04000148 RID: 328
	public const int FINAL = 0x38;

	// Token: 0x04000149 RID: 329
	public const int FINALLY = 0x39;

	// Token: 0x0400014A RID: 330
	public const int FLOAT = 0x3A;

	// Token: 0x0400014B RID: 331
	public const int FOR = 0x3B;

	// Token: 0x0400014C RID: 332
	public const int FORITER = 0x3C;

	// Token: 0x0400014D RID: 333
	public const int FORSTEP = 0x3D;

	// Token: 0x0400014E RID: 334
	public const int FUNCTION = 0x3E;

	// Token: 0x0400014F RID: 335
	public const int GOTO = 0x3F;

	// Token: 0x04000150 RID: 336
	public const int GT = 0x40;

	// Token: 0x04000151 RID: 337
	public const int GTE = 0x41;

	// Token: 0x04000152 RID: 338
	public const int HexDigit = 0x42;

	// Token: 0x04000153 RID: 339
	public const int HexEscapeSequence = 0x43;

	// Token: 0x04000154 RID: 340
	public const int HexIntegerLiteral = 0x44;

	// Token: 0x04000155 RID: 341
	public const int IF = 0x45;

	// Token: 0x04000156 RID: 342
	public const int IMPLEMENTS = 0x46;

	// Token: 0x04000157 RID: 343
	public const int IMPORT = 0x47;

	// Token: 0x04000158 RID: 344
	public const int IN = 0x48;

	// Token: 0x04000159 RID: 345
	public const int INC = 0x49;

	// Token: 0x0400015A RID: 346
	public const int INSTANCEOF = 0x4A;

	// Token: 0x0400015B RID: 347
	public const int INT = 0x4B;

	// Token: 0x0400015C RID: 348
	public const int INTERFACE = 0x4C;

	// Token: 0x0400015D RID: 349
	public const int INV = 0x4D;

	// Token: 0x0400015E RID: 350
	public const int ITEM = 0x4E;

	// Token: 0x0400015F RID: 351
	public const int Identifier = 0x4F;

	// Token: 0x04000160 RID: 352
	public const int IdentifierNameASCIIStart = 0x50;

	// Token: 0x04000161 RID: 353
	public const int IdentifierPart = 0x51;

	// Token: 0x04000162 RID: 354
	public const int IdentifierStartASCII = 0x52;

	// Token: 0x04000163 RID: 355
	public const int LABELLED = 0x53;

	// Token: 0x04000164 RID: 356
	public const int LAND = 0x54;

	// Token: 0x04000165 RID: 357
	public const int LBRACE = 0x55;

	// Token: 0x04000166 RID: 358
	public const int LBRACK = 0x56;

	// Token: 0x04000167 RID: 359
	public const int LF = 0x57;

	// Token: 0x04000168 RID: 360
	public const int LONG = 0x58;

	// Token: 0x04000169 RID: 361
	public const int LOR = 0x59;

	// Token: 0x0400016A RID: 362
	public const int LPAREN = 0x5A;

	// Token: 0x0400016B RID: 363
	public const int LS = 0x5B;

	// Token: 0x0400016C RID: 364
	public const int LT = 0x5C;

	// Token: 0x0400016D RID: 365
	public const int LTE = 0x5D;

	// Token: 0x0400016E RID: 366
	public const int LineTerminator = 0x5E;

	// Token: 0x0400016F RID: 367
	public const int MOD = 0x5F;

	// Token: 0x04000170 RID: 368
	public const int MODASS = 0x60;

	// Token: 0x04000171 RID: 369
	public const int MUL = 0x61;

	// Token: 0x04000172 RID: 370
	public const int MULASS = 0x62;

	// Token: 0x04000173 RID: 371
	public const int MultiLineComment = 0x63;

	// Token: 0x04000174 RID: 372
	public const int NAMEDVALUE = 0x64;

	// Token: 0x04000175 RID: 373
	public const int NATIVE = 0x65;

	// Token: 0x04000176 RID: 374
	public const int NBSP = 0x66;

	// Token: 0x04000177 RID: 375
	public const int NEG = 0x67;

	// Token: 0x04000178 RID: 376
	public const int NEQ = 0x68;

	// Token: 0x04000179 RID: 377
	public const int NEW = 0x69;

	// Token: 0x0400017A RID: 378
	public const int NOT = 0x6A;

	// Token: 0x0400017B RID: 379
	public const int NSAME = 0x6B;

	// Token: 0x0400017C RID: 380
	public const int NULL = 0x6C;

	// Token: 0x0400017D RID: 381
	public const int OBJECT = 0x6D;

	// Token: 0x0400017E RID: 382
	public const int OR = 0x6E;

	// Token: 0x0400017F RID: 383
	public const int ORASS = 0x6F;

	// Token: 0x04000180 RID: 384
	public const int OctalDigit = 0x70;

	// Token: 0x04000181 RID: 385
	public const int OctalEscapeSequence = 0x71;

	// Token: 0x04000182 RID: 386
	public const int OctalIntegerLiteral = 0x72;

	// Token: 0x04000183 RID: 387
	public const int PACKAGE = 0x73;

	// Token: 0x04000184 RID: 388
	public const int PAREXPR = 0x74;

	// Token: 0x04000185 RID: 389
	public const int PDEC = 0x75;

	// Token: 0x04000186 RID: 390
	public const int PINC = 0x76;

	// Token: 0x04000187 RID: 391
	public const int POS = 0x77;

	// Token: 0x04000188 RID: 392
	public const int PRIVATE = 0x78;

	// Token: 0x04000189 RID: 393
	public const int PROTECTED = 0x79;

	// Token: 0x0400018A RID: 394
	public const int PS = 0x7A;

	// Token: 0x0400018B RID: 395
	public const int PUBLIC = 0x7B;

	// Token: 0x0400018C RID: 396
	public const int QUE = 0x7C;

	// Token: 0x0400018D RID: 397
	public const int RBRACE = 0x7D;

	// Token: 0x0400018E RID: 398
	public const int RBRACK = 0x7E;

	// Token: 0x0400018F RID: 399
	public const int RETURN = 0x7F;

	// Token: 0x04000190 RID: 400
	public const int RPAREN = 0x80;

	// Token: 0x04000191 RID: 401
	public const int RegularExpressionChar = 0x81;

	// Token: 0x04000192 RID: 402
	public const int RegularExpressionFirstChar = 0x82;

	// Token: 0x04000193 RID: 403
	public const int RegularExpressionLiteral = 0x83;

	// Token: 0x04000194 RID: 404
	public const int SAME = 0x84;

	// Token: 0x04000195 RID: 405
	public const int SEMIC = 0x85;

	// Token: 0x04000196 RID: 406
	public const int SHL = 0x86;

	// Token: 0x04000197 RID: 407
	public const int SHLASS = 0x87;

	// Token: 0x04000198 RID: 408
	public const int SHORT = 0x88;

	// Token: 0x04000199 RID: 409
	public const int SHR = 0x89;

	// Token: 0x0400019A RID: 410
	public const int SHRASS = 0x8A;

	// Token: 0x0400019B RID: 411
	public const int SHU = 0x8B;

	// Token: 0x0400019C RID: 412
	public const int SHUASS = 0x8C;

	// Token: 0x0400019D RID: 413
	public const int SP = 0x8D;

	// Token: 0x0400019E RID: 414
	public const int SQUOTE = 0x8E;

	// Token: 0x0400019F RID: 415
	public const int STATIC = 0x8F;

	// Token: 0x040001A0 RID: 416
	public const int SUB = 0x90;

	// Token: 0x040001A1 RID: 417
	public const int SUBASS = 0x91;

	// Token: 0x040001A2 RID: 418
	public const int SUPER = 0x92;

	// Token: 0x040001A3 RID: 419
	public const int SWITCH = 0x93;

	// Token: 0x040001A4 RID: 420
	public const int SYNCHRONIZED = 0x94;

	// Token: 0x040001A5 RID: 421
	public const int SingleLineComment = 0x95;

	// Token: 0x040001A6 RID: 422
	public const int StringLiteral = 0x96;

	// Token: 0x040001A7 RID: 423
	public const int TAB = 0x97;

	// Token: 0x040001A8 RID: 424
	public const int THIS = 0x98;

	// Token: 0x040001A9 RID: 425
	public const int THROW = 0x99;

	// Token: 0x040001AA RID: 426
	public const int THROWS = 0x9A;

	// Token: 0x040001AB RID: 427
	public const int TRANSIENT = 0x9B;

	// Token: 0x040001AC RID: 428
	public const int TRUE = 0x9C;

	// Token: 0x040001AD RID: 429
	public const int TRY = 0x9D;

	// Token: 0x040001AE RID: 430
	public const int TYPEOF = 0x9E;

	// Token: 0x040001AF RID: 431
	public const int USP = 0x9F;

	// Token: 0x040001B0 RID: 432
	public const int UnicodeEscapeSequence = 0xA0;

	// Token: 0x040001B1 RID: 433
	public const int VAR = 0xA1;

	// Token: 0x040001B2 RID: 434
	public const int VOID = 0xA2;

	// Token: 0x040001B3 RID: 435
	public const int VOLATILE = 0xA3;

	// Token: 0x040001B4 RID: 436
	public const int VT = 0xA4;

	// Token: 0x040001B5 RID: 437
	public const int WHILE = 0xA5;

	// Token: 0x040001B6 RID: 438
	public const int WITH = 0xA6;

	// Token: 0x040001B7 RID: 439
	public const int WhiteSpace = 0xA7;

	// Token: 0x040001B8 RID: 440
	public const int XOR = 0xA8;

	// Token: 0x040001B9 RID: 441
	public const int XORASS = 0xA9;

	// Token: 0x040001BA RID: 442
	public const int ZeroToThree = 0xAA;

	// Token: 0x040001BB RID: 443
	private const char BS = '\\';

	// Token: 0x040001BC RID: 444
	internal static readonly string[] tokenNames = new string[]
	{
		"<invalid>",
		"<EOR>",
		"<DOWN>",
		"<UP>",
		"ABSTRACT",
		"ADD",
		"ADDASS",
		"AND",
		"ANDASS",
		"ARGS",
		"ARRAY",
		"ASSIGN",
		"BLOCK",
		"BOOLEAN",
		"BREAK",
		"BSLASH",
		"BYFIELD",
		"BYINDEX",
		"BYTE",
		"BackslashSequence",
		"CALL",
		"CASE",
		"CATCH",
		"CEXPR",
		"CHAR",
		"CLASS",
		"COLON",
		"COMMA",
		"CONST",
		"CONTINUE",
		"CR",
		"CharacterEscapeSequence",
		"DEBUGGER",
		"DEC",
		"DEFAULT",
		"DELETE",
		"DIV",
		"DIVASS",
		"DO",
		"DOT",
		"DOUBLE",
		"DQUOTE",
		"DecimalDigit",
		"DecimalIntegerLiteral",
		"DecimalLiteral",
		"ELSE",
		"ENUM",
		"EOL",
		"EQ",
		"EXPORT",
		"EXPR",
		"EXTENDS",
		"EscapeSequence",
		"ExponentPart",
		"FALSE",
		"FF",
		"FINAL",
		"FINALLY",
		"FLOAT",
		"FOR",
		"FORITER",
		"FORSTEP",
		"FUNCTION",
		"GOTO",
		"GT",
		"GTE",
		"HexDigit",
		"HexEscapeSequence",
		"HexIntegerLiteral",
		"IF",
		"IMPLEMENTS",
		"IMPORT",
		"IN",
		"INC",
		"INSTANCEOF",
		"INT",
		"INTERFACE",
		"INV",
		"ITEM",
		"Identifier",
		"IdentifierNameASCIIStart",
		"IdentifierPart",
		"IdentifierStartASCII",
		"LABELLED",
		"LAND",
		"LBRACE",
		"LBRACK",
		"LF",
		"LONG",
		"LOR",
		"LPAREN",
		"LS",
		"LT",
		"LTE",
		"LineTerminator",
		"MOD",
		"MODASS",
		"MUL",
		"MULASS",
		"MultiLineComment",
		"NAMEDVALUE",
		"NATIVE",
		"NBSP",
		"NEG",
		"NEQ",
		"NEW",
		"NOT",
		"NSAME",
		"NULL",
		"OBJECT",
		"OR",
		"ORASS",
		"OctalDigit",
		"OctalEscapeSequence",
		"OctalIntegerLiteral",
		"PACKAGE",
		"PAREXPR",
		"PDEC",
		"PINC",
		"POS",
		"PRIVATE",
		"PROTECTED",
		"PS",
		"PUBLIC",
		"QUE",
		"RBRACE",
		"RBRACK",
		"RETURN",
		"RPAREN",
		"RegularExpressionChar",
		"RegularExpressionFirstChar",
		"RegularExpressionLiteral",
		"SAME",
		"SEMIC",
		"SHL",
		"SHLASS",
		"SHORT",
		"SHR",
		"SHRASS",
		"SHU",
		"SHUASS",
		"SP",
		"SQUOTE",
		"STATIC",
		"SUB",
		"SUBASS",
		"SUPER",
		"SWITCH",
		"SYNCHRONIZED",
		"SingleLineComment",
		"StringLiteral",
		"TAB",
		"THIS",
		"THROW",
		"THROWS",
		"TRANSIENT",
		"TRUE",
		"TRY",
		"TYPEOF",
		"USP",
		"UnicodeEscapeSequence",
		"VAR",
		"VOID",
		"VOLATILE",
		"VT",
		"WHILE",
		"WITH",
		"WhiteSpace",
		"XOR",
		"XORASS",
		"ZeroToThree"
	};

	// Token: 0x040001BD RID: 445
	private global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;

	// Token: 0x040001BE RID: 446
	private global::System.Collections.Generic.LinkedList<global::Jint.Expressions.Statement> _currentBody;

	// Token: 0x040001BF RID: 447
	private bool _newExpressionIsUnary;

	// Token: 0x040001C0 RID: 448
	private static global::System.Globalization.NumberFormatInfo numberFormatInfo = new global::System.Globalization.NumberFormatInfo();

	// Token: 0x040001C1 RID: 449
	private static global::System.Text.Encoding Latin1 = global::System.Text.Encoding.GetEncoding("iso-8859-1");

	// Token: 0x040001C2 RID: 450
	private string[] script = new string[0];

	// Token: 0x040001C3 RID: 451
	private global::ES3Parser.DFA57 dfa57;

	// Token: 0x040001C4 RID: 452
	private global::ES3Parser.DFA58 dfa58;

	// Token: 0x040001C5 RID: 453
	private global::ES3Parser.DFA88 dfa88;

	// Token: 0x040001C6 RID: 454
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::System.Collections.Generic.List<string> <Errors>k__BackingField;

	// Token: 0x040001C7 RID: 455
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <DebugMode>k__BackingField;

	// Token: 0x020000EC RID: 236
	private sealed class token_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x00037F20 File Offset: 0x00036120
		// (set) Token: 0x06000A62 RID: 2658 RVA: 0x00037F28 File Offset: 0x00036128
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00037F34 File Offset: 0x00036134
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00037F3C File Offset: 0x0003613C
		public token_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400047B RID: 1147
		private object _tree;
	}

	// Token: 0x020000ED RID: 237
	private sealed class reservedWord_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00037F44 File Offset: 0x00036144
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00037F4C File Offset: 0x0003614C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00037F58 File Offset: 0x00036158
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00037F60 File Offset: 0x00036160
		public reservedWord_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400047C RID: 1148
		private object _tree;
	}

	// Token: 0x020000EE RID: 238
	private sealed class keyword_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00037F68 File Offset: 0x00036168
		// (set) Token: 0x06000A6A RID: 2666 RVA: 0x00037F70 File Offset: 0x00036170
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00037F7C File Offset: 0x0003617C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00037F84 File Offset: 0x00036184
		public keyword_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400047D RID: 1149
		private object _tree;
	}

	// Token: 0x020000EF RID: 239
	private sealed class futureReservedWord_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x00037F8C File Offset: 0x0003618C
		// (set) Token: 0x06000A6E RID: 2670 RVA: 0x00037F94 File Offset: 0x00036194
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00037FA0 File Offset: 0x000361A0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00037FA8 File Offset: 0x000361A8
		public futureReservedWord_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400047E RID: 1150
		private object _tree;
	}

	// Token: 0x020000F0 RID: 240
	private sealed class punctuator_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x00037FB0 File Offset: 0x000361B0
		// (set) Token: 0x06000A72 RID: 2674 RVA: 0x00037FB8 File Offset: 0x000361B8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x00037FC4 File Offset: 0x000361C4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00037FCC File Offset: 0x000361CC
		public punctuator_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400047F RID: 1151
		private object _tree;
	}

	// Token: 0x020000F1 RID: 241
	private sealed class literal_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x00037FD4 File Offset: 0x000361D4
		// (set) Token: 0x06000A76 RID: 2678 RVA: 0x00037FDC File Offset: 0x000361DC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00037FE8 File Offset: 0x000361E8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00037FF0 File Offset: 0x000361F0
		public literal_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000480 RID: 1152
		public global::Jint.Expressions.Expression value;

		// Token: 0x04000481 RID: 1153
		private object _tree;
	}

	// Token: 0x020000F2 RID: 242
	private sealed class booleanLiteral_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x00037FF8 File Offset: 0x000361F8
		// (set) Token: 0x06000A7A RID: 2682 RVA: 0x00038000 File Offset: 0x00036200
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0003800C File Offset: 0x0003620C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00038014 File Offset: 0x00036214
		public booleanLiteral_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000482 RID: 1154
		public bool value;

		// Token: 0x04000483 RID: 1155
		private object _tree;
	}

	// Token: 0x020000F3 RID: 243
	private sealed class numericLiteral_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0003801C File Offset: 0x0003621C
		// (set) Token: 0x06000A7E RID: 2686 RVA: 0x00038024 File Offset: 0x00036224
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x00038030 File Offset: 0x00036230
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00038038 File Offset: 0x00036238
		public numericLiteral_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000484 RID: 1156
		public double value;

		// Token: 0x04000485 RID: 1157
		private object _tree;
	}

	// Token: 0x020000F4 RID: 244
	private sealed class primaryExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00038040 File Offset: 0x00036240
		// (set) Token: 0x06000A82 RID: 2690 RVA: 0x00038048 File Offset: 0x00036248
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00038054 File Offset: 0x00036254
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0003805C File Offset: 0x0003625C
		public primaryExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000486 RID: 1158
		public global::Jint.Expressions.Expression value;

		// Token: 0x04000487 RID: 1159
		private object _tree;
	}

	// Token: 0x020000F5 RID: 245
	private sealed class arrayLiteral_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000A85 RID: 2693 RVA: 0x00038064 File Offset: 0x00036264
		// (set) Token: 0x06000A86 RID: 2694 RVA: 0x0003806C File Offset: 0x0003626C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x00038078 File Offset: 0x00036278
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x00038080 File Offset: 0x00036280
		public arrayLiteral_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000488 RID: 1160
		public global::Jint.Expressions.ArrayDeclaration value;

		// Token: 0x04000489 RID: 1161
		private object _tree;
	}

	// Token: 0x020000F6 RID: 246
	private sealed class arrayItem_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x00038088 File Offset: 0x00036288
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x00038090 File Offset: 0x00036290
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0003809C File Offset: 0x0003629C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x000380A4 File Offset: 0x000362A4
		public arrayItem_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400048A RID: 1162
		public global::Jint.Expressions.Statement value;

		// Token: 0x0400048B RID: 1163
		private object _tree;
	}

	// Token: 0x020000F7 RID: 247
	private sealed class objectLiteral_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x000380AC File Offset: 0x000362AC
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x000380B4 File Offset: 0x000362B4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x000380C0 File Offset: 0x000362C0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x000380C8 File Offset: 0x000362C8
		public objectLiteral_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400048C RID: 1164
		public global::Jint.Expressions.JsonExpression value;

		// Token: 0x0400048D RID: 1165
		private object _tree;
	}

	// Token: 0x020000F8 RID: 248
	private sealed class propertyAssignment_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x000380D0 File Offset: 0x000362D0
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x000380D8 File Offset: 0x000362D8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x000380E4 File Offset: 0x000362E4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x000380EC File Offset: 0x000362EC
		public propertyAssignment_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400048E RID: 1166
		public global::Jint.Expressions.PropertyDeclarationExpression value;

		// Token: 0x0400048F RID: 1167
		private object _tree;
	}

	// Token: 0x020000F9 RID: 249
	private sealed class accessor_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x000380F4 File Offset: 0x000362F4
		// (set) Token: 0x06000A96 RID: 2710 RVA: 0x000380FC File Offset: 0x000362FC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x00038108 File Offset: 0x00036308
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00038110 File Offset: 0x00036310
		public accessor_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000490 RID: 1168
		public global::Jint.Expressions.PropertyExpressionType value;

		// Token: 0x04000491 RID: 1169
		private object _tree;
	}

	// Token: 0x020000FA RID: 250
	private sealed class propertyName_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00038118 File Offset: 0x00036318
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x00038120 File Offset: 0x00036320
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x0003812C File Offset: 0x0003632C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00038134 File Offset: 0x00036334
		public propertyName_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000492 RID: 1170
		public string value;

		// Token: 0x04000493 RID: 1171
		private object _tree;
	}

	// Token: 0x020000FB RID: 251
	private sealed class memberExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x0003813C File Offset: 0x0003633C
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x00038144 File Offset: 0x00036344
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00038150 File Offset: 0x00036350
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00038158 File Offset: 0x00036358
		public memberExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000494 RID: 1172
		public global::Jint.Expressions.Expression value;

		// Token: 0x04000495 RID: 1173
		private object _tree;
	}

	// Token: 0x020000FC RID: 252
	private sealed class newExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x00038160 File Offset: 0x00036360
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x00038168 File Offset: 0x00036368
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x00038174 File Offset: 0x00036374
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0003817C File Offset: 0x0003637C
		public newExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000496 RID: 1174
		public global::Jint.Expressions.NewExpression value;

		// Token: 0x04000497 RID: 1175
		private object _tree;
	}

	// Token: 0x020000FD RID: 253
	private sealed class arguments_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x00038184 File Offset: 0x00036384
		// (set) Token: 0x06000AA6 RID: 2726 RVA: 0x0003818C File Offset: 0x0003638C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x00038198 File Offset: 0x00036398
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x000381A0 File Offset: 0x000363A0
		public arguments_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000498 RID: 1176
		public global::System.Collections.Generic.List<global::Jint.Expressions.Expression> value;

		// Token: 0x04000499 RID: 1177
		private object _tree;
	}

	// Token: 0x020000FE RID: 254
	private sealed class generics_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x000381A8 File Offset: 0x000363A8
		// (set) Token: 0x06000AAA RID: 2730 RVA: 0x000381B0 File Offset: 0x000363B0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000AAB RID: 2731 RVA: 0x000381BC File Offset: 0x000363BC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x000381C4 File Offset: 0x000363C4
		public generics_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400049A RID: 1178
		public global::System.Collections.Generic.List<global::Jint.Expressions.Expression> value;

		// Token: 0x0400049B RID: 1179
		private object _tree;
	}

	// Token: 0x020000FF RID: 255
	private sealed class leftHandSideExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000AAD RID: 2733 RVA: 0x000381CC File Offset: 0x000363CC
		// (set) Token: 0x06000AAE RID: 2734 RVA: 0x000381D4 File Offset: 0x000363D4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000AAF RID: 2735 RVA: 0x000381E0 File Offset: 0x000363E0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x000381E8 File Offset: 0x000363E8
		public leftHandSideExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400049C RID: 1180
		public global::Jint.Expressions.Expression value;

		// Token: 0x0400049D RID: 1181
		private object _tree;
	}

	// Token: 0x02000100 RID: 256
	private sealed class postfixExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x000381F0 File Offset: 0x000363F0
		// (set) Token: 0x06000AB2 RID: 2738 RVA: 0x000381F8 File Offset: 0x000363F8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x00038204 File Offset: 0x00036404
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0003820C File Offset: 0x0003640C
		public postfixExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400049E RID: 1182
		public global::Jint.Expressions.Expression value;

		// Token: 0x0400049F RID: 1183
		private object _tree;
	}

	// Token: 0x02000101 RID: 257
	private sealed class postfixOperator_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x00038214 File Offset: 0x00036414
		// (set) Token: 0x06000AB6 RID: 2742 RVA: 0x0003821C File Offset: 0x0003641C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x00038228 File Offset: 0x00036428
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00038230 File Offset: 0x00036430
		public postfixOperator_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004A0 RID: 1184
		public global::Jint.Expressions.UnaryExpressionType value;

		// Token: 0x040004A1 RID: 1185
		private object _tree;
	}

	// Token: 0x02000102 RID: 258
	private sealed class unaryExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x00038238 File Offset: 0x00036438
		// (set) Token: 0x06000ABA RID: 2746 RVA: 0x00038240 File Offset: 0x00036440
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0003824C File Offset: 0x0003644C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00038254 File Offset: 0x00036454
		public unaryExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004A2 RID: 1186
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004A3 RID: 1187
		private object _tree;
	}

	// Token: 0x02000103 RID: 259
	private sealed class unaryOperator_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0003825C File Offset: 0x0003645C
		// (set) Token: 0x06000ABE RID: 2750 RVA: 0x00038264 File Offset: 0x00036464
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000ABF RID: 2751 RVA: 0x00038270 File Offset: 0x00036470
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00038278 File Offset: 0x00036478
		public unaryOperator_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004A4 RID: 1188
		public global::Jint.Expressions.UnaryExpressionType value;

		// Token: 0x040004A5 RID: 1189
		private object _tree;
	}

	// Token: 0x02000104 RID: 260
	private sealed class multiplicativeExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x00038280 File Offset: 0x00036480
		// (set) Token: 0x06000AC2 RID: 2754 RVA: 0x00038288 File Offset: 0x00036488
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x00038294 File Offset: 0x00036494
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0003829C File Offset: 0x0003649C
		public multiplicativeExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004A6 RID: 1190
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004A7 RID: 1191
		private object _tree;
	}

	// Token: 0x02000105 RID: 261
	private sealed class additiveExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x000382A4 File Offset: 0x000364A4
		// (set) Token: 0x06000AC6 RID: 2758 RVA: 0x000382AC File Offset: 0x000364AC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x000382B8 File Offset: 0x000364B8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x000382C0 File Offset: 0x000364C0
		public additiveExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004A8 RID: 1192
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004A9 RID: 1193
		private object _tree;
	}

	// Token: 0x02000106 RID: 262
	private sealed class shiftExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x000382C8 File Offset: 0x000364C8
		// (set) Token: 0x06000ACA RID: 2762 RVA: 0x000382D0 File Offset: 0x000364D0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x000382DC File Offset: 0x000364DC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x000382E4 File Offset: 0x000364E4
		public shiftExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004AA RID: 1194
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004AB RID: 1195
		private object _tree;
	}

	// Token: 0x02000107 RID: 263
	private sealed class relationalExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x000382EC File Offset: 0x000364EC
		// (set) Token: 0x06000ACE RID: 2766 RVA: 0x000382F4 File Offset: 0x000364F4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x00038300 File Offset: 0x00036500
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00038308 File Offset: 0x00036508
		public relationalExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004AC RID: 1196
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004AD RID: 1197
		private object _tree;
	}

	// Token: 0x02000108 RID: 264
	private sealed class relationalExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x00038310 File Offset: 0x00036510
		// (set) Token: 0x06000AD2 RID: 2770 RVA: 0x00038318 File Offset: 0x00036518
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x00038324 File Offset: 0x00036524
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0003832C File Offset: 0x0003652C
		public relationalExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004AE RID: 1198
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004AF RID: 1199
		private object _tree;
	}

	// Token: 0x02000109 RID: 265
	private sealed class equalityExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x00038334 File Offset: 0x00036534
		// (set) Token: 0x06000AD6 RID: 2774 RVA: 0x0003833C File Offset: 0x0003653C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x00038348 File Offset: 0x00036548
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x00038350 File Offset: 0x00036550
		public equalityExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004B0 RID: 1200
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004B1 RID: 1201
		private object _tree;
	}

	// Token: 0x0200010A RID: 266
	private sealed class equalityExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x00038358 File Offset: 0x00036558
		// (set) Token: 0x06000ADA RID: 2778 RVA: 0x00038360 File Offset: 0x00036560
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x0003836C File Offset: 0x0003656C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00038374 File Offset: 0x00036574
		public equalityExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004B2 RID: 1202
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004B3 RID: 1203
		private object _tree;
	}

	// Token: 0x0200010B RID: 267
	private sealed class bitwiseANDExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x0003837C File Offset: 0x0003657C
		// (set) Token: 0x06000ADE RID: 2782 RVA: 0x00038384 File Offset: 0x00036584
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x00038390 File Offset: 0x00036590
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00038398 File Offset: 0x00036598
		public bitwiseANDExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004B4 RID: 1204
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004B5 RID: 1205
		private object _tree;
	}

	// Token: 0x0200010C RID: 268
	private sealed class bitwiseANDExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x000383A0 File Offset: 0x000365A0
		// (set) Token: 0x06000AE2 RID: 2786 RVA: 0x000383A8 File Offset: 0x000365A8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x000383B4 File Offset: 0x000365B4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x000383BC File Offset: 0x000365BC
		public bitwiseANDExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004B6 RID: 1206
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004B7 RID: 1207
		private object _tree;
	}

	// Token: 0x0200010D RID: 269
	private sealed class bitwiseXORExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x000383C4 File Offset: 0x000365C4
		// (set) Token: 0x06000AE6 RID: 2790 RVA: 0x000383CC File Offset: 0x000365CC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x000383D8 File Offset: 0x000365D8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x000383E0 File Offset: 0x000365E0
		public bitwiseXORExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004B8 RID: 1208
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004B9 RID: 1209
		private object _tree;
	}

	// Token: 0x0200010E RID: 270
	private sealed class bitwiseXORExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x000383E8 File Offset: 0x000365E8
		// (set) Token: 0x06000AEA RID: 2794 RVA: 0x000383F0 File Offset: 0x000365F0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000AEB RID: 2795 RVA: 0x000383FC File Offset: 0x000365FC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x00038404 File Offset: 0x00036604
		public bitwiseXORExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004BA RID: 1210
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004BB RID: 1211
		private object _tree;
	}

	// Token: 0x0200010F RID: 271
	private sealed class bitwiseORExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000AED RID: 2797 RVA: 0x0003840C File Offset: 0x0003660C
		// (set) Token: 0x06000AEE RID: 2798 RVA: 0x00038414 File Offset: 0x00036614
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000AEF RID: 2799 RVA: 0x00038420 File Offset: 0x00036620
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00038428 File Offset: 0x00036628
		public bitwiseORExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004BC RID: 1212
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004BD RID: 1213
		private object _tree;
	}

	// Token: 0x02000110 RID: 272
	private sealed class bitwiseORExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x00038430 File Offset: 0x00036630
		// (set) Token: 0x06000AF2 RID: 2802 RVA: 0x00038438 File Offset: 0x00036638
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x00038444 File Offset: 0x00036644
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0003844C File Offset: 0x0003664C
		public bitwiseORExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004BE RID: 1214
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004BF RID: 1215
		private object _tree;
	}

	// Token: 0x02000111 RID: 273
	private sealed class logicalANDExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x00038454 File Offset: 0x00036654
		// (set) Token: 0x06000AF6 RID: 2806 RVA: 0x0003845C File Offset: 0x0003665C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x00038468 File Offset: 0x00036668
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00038470 File Offset: 0x00036670
		public logicalANDExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004C0 RID: 1216
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004C1 RID: 1217
		private object _tree;
	}

	// Token: 0x02000112 RID: 274
	private sealed class logicalANDExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00038478 File Offset: 0x00036678
		// (set) Token: 0x06000AFA RID: 2810 RVA: 0x00038480 File Offset: 0x00036680
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000AFB RID: 2811 RVA: 0x0003848C File Offset: 0x0003668C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00038494 File Offset: 0x00036694
		public logicalANDExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004C2 RID: 1218
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004C3 RID: 1219
		private object _tree;
	}

	// Token: 0x02000113 RID: 275
	private sealed class logicalORExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x0003849C File Offset: 0x0003669C
		// (set) Token: 0x06000AFE RID: 2814 RVA: 0x000384A4 File Offset: 0x000366A4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x000384B0 File Offset: 0x000366B0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x000384B8 File Offset: 0x000366B8
		public logicalORExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004C4 RID: 1220
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004C5 RID: 1221
		private object _tree;
	}

	// Token: 0x02000114 RID: 276
	private sealed class logicalORExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x000384C0 File Offset: 0x000366C0
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x000384C8 File Offset: 0x000366C8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x000384D4 File Offset: 0x000366D4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000384DC File Offset: 0x000366DC
		public logicalORExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004C6 RID: 1222
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004C7 RID: 1223
		private object _tree;
	}

	// Token: 0x02000115 RID: 277
	private sealed class conditionalExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x000384E4 File Offset: 0x000366E4
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x000384EC File Offset: 0x000366EC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x000384F8 File Offset: 0x000366F8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00038500 File Offset: 0x00036700
		public conditionalExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004C8 RID: 1224
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004C9 RID: 1225
		private object _tree;
	}

	// Token: 0x02000116 RID: 278
	private sealed class conditionalExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x00038508 File Offset: 0x00036708
		// (set) Token: 0x06000B0A RID: 2826 RVA: 0x00038510 File Offset: 0x00036710
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0003851C File Offset: 0x0003671C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00038524 File Offset: 0x00036724
		public conditionalExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004CA RID: 1226
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004CB RID: 1227
		private object _tree;
	}

	// Token: 0x02000117 RID: 279
	private sealed class assignmentExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x0003852C File Offset: 0x0003672C
		// (set) Token: 0x06000B0E RID: 2830 RVA: 0x00038534 File Offset: 0x00036734
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000B0F RID: 2831 RVA: 0x00038540 File Offset: 0x00036740
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00038548 File Offset: 0x00036748
		public assignmentExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004CC RID: 1228
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004CD RID: 1229
		private object _tree;
	}

	// Token: 0x02000118 RID: 280
	private sealed class assignmentOperator_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000B11 RID: 2833 RVA: 0x00038550 File Offset: 0x00036750
		// (set) Token: 0x06000B12 RID: 2834 RVA: 0x00038558 File Offset: 0x00036758
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00038564 File Offset: 0x00036764
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0003856C File Offset: 0x0003676C
		public assignmentOperator_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004CE RID: 1230
		private object _tree;
	}

	// Token: 0x02000119 RID: 281
	private sealed class assignmentExpressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00038574 File Offset: 0x00036774
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x0003857C File Offset: 0x0003677C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x00038588 File Offset: 0x00036788
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x00038590 File Offset: 0x00036790
		public assignmentExpressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004CF RID: 1231
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004D0 RID: 1232
		private object _tree;
	}

	// Token: 0x0200011A RID: 282
	private sealed class expression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x00038598 File Offset: 0x00036798
		// (set) Token: 0x06000B1A RID: 2842 RVA: 0x000385A0 File Offset: 0x000367A0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x000385AC File Offset: 0x000367AC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x000385B4 File Offset: 0x000367B4
		public expression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004D1 RID: 1233
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004D2 RID: 1234
		private object _tree;
	}

	// Token: 0x0200011B RID: 283
	private sealed class expressionNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x000385BC File Offset: 0x000367BC
		// (set) Token: 0x06000B1E RID: 2846 RVA: 0x000385C4 File Offset: 0x000367C4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x000385D0 File Offset: 0x000367D0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x000385D8 File Offset: 0x000367D8
		public expressionNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004D3 RID: 1235
		public global::Jint.Expressions.Expression value;

		// Token: 0x040004D4 RID: 1236
		private object _tree;
	}

	// Token: 0x0200011C RID: 284
	private sealed class semic_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x000385E0 File Offset: 0x000367E0
		// (set) Token: 0x06000B22 RID: 2850 RVA: 0x000385E8 File Offset: 0x000367E8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x000385F4 File Offset: 0x000367F4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x000385FC File Offset: 0x000367FC
		public semic_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004D5 RID: 1237
		private object _tree;
	}

	// Token: 0x0200011D RID: 285
	private sealed class statement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000B25 RID: 2853 RVA: 0x00038604 File Offset: 0x00036804
		// (set) Token: 0x06000B26 RID: 2854 RVA: 0x0003860C File Offset: 0x0003680C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000B27 RID: 2855 RVA: 0x00038618 File Offset: 0x00036818
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00038620 File Offset: 0x00036820
		public statement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004D6 RID: 1238
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004D7 RID: 1239
		private object _tree;
	}

	// Token: 0x0200011E RID: 286
	private sealed class statementTail_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x00038628 File Offset: 0x00036828
		// (set) Token: 0x06000B2A RID: 2858 RVA: 0x00038630 File Offset: 0x00036830
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000B2B RID: 2859 RVA: 0x0003863C File Offset: 0x0003683C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x00038644 File Offset: 0x00036844
		public statementTail_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004D8 RID: 1240
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004D9 RID: 1241
		private object _tree;
	}

	// Token: 0x0200011F RID: 287
	private sealed class block_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000B2D RID: 2861 RVA: 0x0003864C File Offset: 0x0003684C
		// (set) Token: 0x06000B2E RID: 2862 RVA: 0x00038654 File Offset: 0x00036854
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x00038660 File Offset: 0x00036860
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00038668 File Offset: 0x00036868
		public block_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004DA RID: 1242
		public global::Jint.Expressions.BlockStatement value;

		// Token: 0x040004DB RID: 1243
		private object _tree;
	}

	// Token: 0x02000120 RID: 288
	private sealed class variableStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x00038670 File Offset: 0x00036870
		// (set) Token: 0x06000B32 RID: 2866 RVA: 0x00038678 File Offset: 0x00036878
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x00038684 File Offset: 0x00036884
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0003868C File Offset: 0x0003688C
		public variableStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004DC RID: 1244
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004DD RID: 1245
		private object _tree;
	}

	// Token: 0x02000121 RID: 289
	private sealed class variableDeclaration_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x00038694 File Offset: 0x00036894
		// (set) Token: 0x06000B36 RID: 2870 RVA: 0x0003869C File Offset: 0x0003689C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x000386A8 File Offset: 0x000368A8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x000386B0 File Offset: 0x000368B0
		public variableDeclaration_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004DE RID: 1246
		public global::Jint.Expressions.VariableDeclarationStatement value;

		// Token: 0x040004DF RID: 1247
		private object _tree;
	}

	// Token: 0x02000122 RID: 290
	private sealed class variableDeclarationNoIn_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x000386B8 File Offset: 0x000368B8
		// (set) Token: 0x06000B3A RID: 2874 RVA: 0x000386C0 File Offset: 0x000368C0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x000386CC File Offset: 0x000368CC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x000386D4 File Offset: 0x000368D4
		public variableDeclarationNoIn_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004E0 RID: 1248
		public global::Jint.Expressions.VariableDeclarationStatement value;

		// Token: 0x040004E1 RID: 1249
		private object _tree;
	}

	// Token: 0x02000123 RID: 291
	private sealed class emptyStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x000386DC File Offset: 0x000368DC
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x000386E4 File Offset: 0x000368E4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x000386F0 File Offset: 0x000368F0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x000386F8 File Offset: 0x000368F8
		public emptyStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004E2 RID: 1250
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004E3 RID: 1251
		private object _tree;
	}

	// Token: 0x02000124 RID: 292
	private sealed class expressionStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x00038700 File Offset: 0x00036900
		// (set) Token: 0x06000B42 RID: 2882 RVA: 0x00038708 File Offset: 0x00036908
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x00038714 File Offset: 0x00036914
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0003871C File Offset: 0x0003691C
		public expressionStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004E4 RID: 1252
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004E5 RID: 1253
		private object _tree;
	}

	// Token: 0x02000125 RID: 293
	private sealed class ifStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x00038724 File Offset: 0x00036924
		// (set) Token: 0x06000B46 RID: 2886 RVA: 0x0003872C File Offset: 0x0003692C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x00038738 File Offset: 0x00036938
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00038740 File Offset: 0x00036940
		public ifStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004E6 RID: 1254
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004E7 RID: 1255
		private object _tree;
	}

	// Token: 0x02000126 RID: 294
	private sealed class iterationStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x00038748 File Offset: 0x00036948
		// (set) Token: 0x06000B4A RID: 2890 RVA: 0x00038750 File Offset: 0x00036950
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x0003875C File Offset: 0x0003695C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00038764 File Offset: 0x00036964
		public iterationStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004E8 RID: 1256
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004E9 RID: 1257
		private object _tree;
	}

	// Token: 0x02000127 RID: 295
	private sealed class doStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0003876C File Offset: 0x0003696C
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x00038774 File Offset: 0x00036974
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x00038780 File Offset: 0x00036980
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00038788 File Offset: 0x00036988
		public doStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004EA RID: 1258
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004EB RID: 1259
		private object _tree;
	}

	// Token: 0x02000128 RID: 296
	private sealed class whileStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00038790 File Offset: 0x00036990
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x00038798 File Offset: 0x00036998
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x000387A4 File Offset: 0x000369A4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x000387AC File Offset: 0x000369AC
		public whileStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004EC RID: 1260
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004ED RID: 1261
		private object _tree;
	}

	// Token: 0x02000129 RID: 297
	private sealed class forStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x000387B4 File Offset: 0x000369B4
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x000387BC File Offset: 0x000369BC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x000387C8 File Offset: 0x000369C8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x000387D0 File Offset: 0x000369D0
		public forStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004EE RID: 1262
		public global::Jint.Expressions.IForStatement value;

		// Token: 0x040004EF RID: 1263
		private object _tree;
	}

	// Token: 0x0200012A RID: 298
	private sealed class forControl_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x000387D8 File Offset: 0x000369D8
		// (set) Token: 0x06000B5A RID: 2906 RVA: 0x000387E0 File Offset: 0x000369E0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x000387EC File Offset: 0x000369EC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x000387F4 File Offset: 0x000369F4
		public forControl_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004F0 RID: 1264
		public global::Jint.Expressions.IForStatement value;

		// Token: 0x040004F1 RID: 1265
		private object _tree;
	}

	// Token: 0x0200012B RID: 299
	private sealed class forControlVar_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x000387FC File Offset: 0x000369FC
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x00038804 File Offset: 0x00036A04
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00038810 File Offset: 0x00036A10
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00038818 File Offset: 0x00036A18
		public forControlVar_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004F2 RID: 1266
		public global::Jint.Expressions.IForStatement value;

		// Token: 0x040004F3 RID: 1267
		private object _tree;
	}

	// Token: 0x0200012C RID: 300
	private sealed class forControlExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00038820 File Offset: 0x00036A20
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00038828 File Offset: 0x00036A28
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x00038834 File Offset: 0x00036A34
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0003883C File Offset: 0x00036A3C
		public forControlExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004F4 RID: 1268
		public global::Jint.Expressions.IForStatement value;

		// Token: 0x040004F5 RID: 1269
		private object _tree;
	}

	// Token: 0x0200012D RID: 301
	private sealed class forControlSemic_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x00038844 File Offset: 0x00036A44
		// (set) Token: 0x06000B66 RID: 2918 RVA: 0x0003884C File Offset: 0x00036A4C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x00038858 File Offset: 0x00036A58
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x00038860 File Offset: 0x00036A60
		public forControlSemic_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004F6 RID: 1270
		public global::Jint.Expressions.ForStatement value;

		// Token: 0x040004F7 RID: 1271
		private object _tree;
	}

	// Token: 0x0200012E RID: 302
	private sealed class continueStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00038868 File Offset: 0x00036A68
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x00038870 File Offset: 0x00036A70
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x0003887C File Offset: 0x00036A7C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00038884 File Offset: 0x00036A84
		public continueStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004F8 RID: 1272
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004F9 RID: 1273
		private object _tree;
	}

	// Token: 0x0200012F RID: 303
	private sealed class breakStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000B6D RID: 2925 RVA: 0x0003888C File Offset: 0x00036A8C
		// (set) Token: 0x06000B6E RID: 2926 RVA: 0x00038894 File Offset: 0x00036A94
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x000388A0 File Offset: 0x00036AA0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x000388A8 File Offset: 0x00036AA8
		public breakStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004FA RID: 1274
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004FB RID: 1275
		private object _tree;
	}

	// Token: 0x02000130 RID: 304
	private sealed class returnStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x000388B0 File Offset: 0x00036AB0
		// (set) Token: 0x06000B72 RID: 2930 RVA: 0x000388B8 File Offset: 0x00036AB8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x000388C4 File Offset: 0x00036AC4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x000388CC File Offset: 0x00036ACC
		public returnStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004FC RID: 1276
		public global::Jint.Expressions.ReturnStatement value;

		// Token: 0x040004FD RID: 1277
		private object _tree;
	}

	// Token: 0x02000131 RID: 305
	private sealed class withStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x000388D4 File Offset: 0x00036AD4
		// (set) Token: 0x06000B76 RID: 2934 RVA: 0x000388DC File Offset: 0x00036ADC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x000388E8 File Offset: 0x00036AE8
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x000388F0 File Offset: 0x00036AF0
		public withStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x040004FE RID: 1278
		public global::Jint.Expressions.Statement value;

		// Token: 0x040004FF RID: 1279
		private object _tree;
	}

	// Token: 0x02000132 RID: 306
	private sealed class switchStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x000388F8 File Offset: 0x00036AF8
		// (set) Token: 0x06000B7A RID: 2938 RVA: 0x00038900 File Offset: 0x00036B00
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x0003890C File Offset: 0x00036B0C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x00038914 File Offset: 0x00036B14
		public switchStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000500 RID: 1280
		public global::Jint.Expressions.Statement value;

		// Token: 0x04000501 RID: 1281
		private object _tree;
	}

	// Token: 0x02000133 RID: 307
	private sealed class caseClause_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x0003891C File Offset: 0x00036B1C
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x00038924 File Offset: 0x00036B24
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x00038930 File Offset: 0x00036B30
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00038938 File Offset: 0x00036B38
		public caseClause_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000502 RID: 1282
		public global::Jint.Expressions.CaseClause value;

		// Token: 0x04000503 RID: 1283
		private object _tree;
	}

	// Token: 0x02000134 RID: 308
	private sealed class defaultClause_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x00038940 File Offset: 0x00036B40
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x00038948 File Offset: 0x00036B48
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x00038954 File Offset: 0x00036B54
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0003895C File Offset: 0x00036B5C
		public defaultClause_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000504 RID: 1284
		public global::Jint.Expressions.BlockStatement value;

		// Token: 0x04000505 RID: 1285
		private object _tree;
	}

	// Token: 0x02000135 RID: 309
	private sealed class labelledStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x00038964 File Offset: 0x00036B64
		// (set) Token: 0x06000B86 RID: 2950 RVA: 0x0003896C File Offset: 0x00036B6C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000B87 RID: 2951 RVA: 0x00038978 File Offset: 0x00036B78
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x00038980 File Offset: 0x00036B80
		public labelledStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000506 RID: 1286
		public global::Jint.Expressions.Statement value;

		// Token: 0x04000507 RID: 1287
		private object _tree;
	}

	// Token: 0x02000136 RID: 310
	private sealed class throwStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x00038988 File Offset: 0x00036B88
		// (set) Token: 0x06000B8A RID: 2954 RVA: 0x00038990 File Offset: 0x00036B90
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0003899C File Offset: 0x00036B9C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x000389A4 File Offset: 0x00036BA4
		public throwStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000508 RID: 1288
		public global::Jint.Expressions.Statement value;

		// Token: 0x04000509 RID: 1289
		private object _tree;
	}

	// Token: 0x02000137 RID: 311
	private sealed class tryStatement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x000389AC File Offset: 0x00036BAC
		// (set) Token: 0x06000B8E RID: 2958 RVA: 0x000389B4 File Offset: 0x00036BB4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x000389C0 File Offset: 0x00036BC0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x000389C8 File Offset: 0x00036BC8
		public tryStatement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400050A RID: 1290
		public global::Jint.Expressions.TryStatement value;

		// Token: 0x0400050B RID: 1291
		private object _tree;
	}

	// Token: 0x02000138 RID: 312
	private sealed class catchClause_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x000389D0 File Offset: 0x00036BD0
		// (set) Token: 0x06000B92 RID: 2962 RVA: 0x000389D8 File Offset: 0x00036BD8
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x000389E4 File Offset: 0x00036BE4
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x000389EC File Offset: 0x00036BEC
		public catchClause_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400050C RID: 1292
		public global::Jint.Expressions.CatchClause value;

		// Token: 0x0400050D RID: 1293
		private object _tree;
	}

	// Token: 0x02000139 RID: 313
	private sealed class finallyClause_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x000389F4 File Offset: 0x00036BF4
		// (set) Token: 0x06000B96 RID: 2966 RVA: 0x000389FC File Offset: 0x00036BFC
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x00038A08 File Offset: 0x00036C08
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00038A10 File Offset: 0x00036C10
		public finallyClause_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400050E RID: 1294
		public global::Jint.Expressions.FinallyClause value;

		// Token: 0x0400050F RID: 1295
		private object _tree;
	}

	// Token: 0x0200013A RID: 314
	private sealed class functionDeclaration_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00038A18 File Offset: 0x00036C18
		// (set) Token: 0x06000B9A RID: 2970 RVA: 0x00038A20 File Offset: 0x00036C20
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x00038A2C File Offset: 0x00036C2C
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x00038A34 File Offset: 0x00036C34
		public functionDeclaration_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000510 RID: 1296
		public global::Jint.Expressions.Statement value;

		// Token: 0x04000511 RID: 1297
		private object _tree;
	}

	// Token: 0x0200013B RID: 315
	private sealed class functionExpression_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x00038A3C File Offset: 0x00036C3C
		// (set) Token: 0x06000B9E RID: 2974 RVA: 0x00038A44 File Offset: 0x00036C44
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00038A50 File Offset: 0x00036C50
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00038A58 File Offset: 0x00036C58
		public functionExpression_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000512 RID: 1298
		public global::Jint.Expressions.FunctionExpression value;

		// Token: 0x04000513 RID: 1299
		private object _tree;
	}

	// Token: 0x0200013C RID: 316
	private sealed class formalParameterList_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x00038A60 File Offset: 0x00036C60
		// (set) Token: 0x06000BA2 RID: 2978 RVA: 0x00038A68 File Offset: 0x00036C68
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x00038A74 File Offset: 0x00036C74
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00038A7C File Offset: 0x00036C7C
		public formalParameterList_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000514 RID: 1300
		public global::System.Collections.Generic.List<string> value;

		// Token: 0x04000515 RID: 1301
		private object _tree;
	}

	// Token: 0x0200013D RID: 317
	private sealed class functionBody_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x00038A84 File Offset: 0x00036C84
		// (set) Token: 0x06000BA6 RID: 2982 RVA: 0x00038A8C File Offset: 0x00036C8C
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x00038A98 File Offset: 0x00036C98
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00038AA0 File Offset: 0x00036CA0
		public functionBody_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000516 RID: 1302
		public global::Jint.Expressions.BlockStatement value;

		// Token: 0x04000517 RID: 1303
		private object _tree;
	}

	// Token: 0x0200013E RID: 318
	public sealed class program_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x00038AA8 File Offset: 0x00036CA8
		// (set) Token: 0x06000BAA RID: 2986 RVA: 0x00038AB0 File Offset: 0x00036CB0
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x00038ABC File Offset: 0x00036CBC
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00038AC4 File Offset: 0x00036CC4
		public program_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x04000518 RID: 1304
		public global::Jint.Expressions.Program value;

		// Token: 0x04000519 RID: 1305
		private object _tree;
	}

	// Token: 0x0200013F RID: 319
	private sealed class sourceElement_return : global::Antlr.Runtime.ParserRuleReturnScope<global::Antlr.Runtime.IToken>, global::Antlr.Runtime.IAstRuleReturnScope<object>, global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x00038ACC File Offset: 0x00036CCC
		// (set) Token: 0x06000BAE RID: 2990 RVA: 0x00038AD4 File Offset: 0x00036CD4
		public object Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x00038AE0 File Offset: 0x00036CE0
		object global::Antlr.Runtime.IAstRuleReturnScope.Tree
		{
			get
			{
				return this.Tree;
			}
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x00038AE8 File Offset: 0x00036CE8
		public sourceElement_return(global::ES3Parser grammar)
		{
		}

		// Token: 0x0400051A RID: 1306
		public global::Jint.Expressions.Statement value;

		// Token: 0x0400051B RID: 1307
		private object _tree;
	}

	// Token: 0x02000140 RID: 320
	private class DFA57 : global::Antlr.Runtime.DFA
	{
		// Token: 0x06000BB1 RID: 2993 RVA: 0x00038AF0 File Offset: 0x00036CF0
		static DFA57()
		{
			int num = global::ES3Parser.DFA57.DFA57_transitionS.Length;
			global::ES3Parser.DFA57.DFA57_transition = new short[num][];
			for (int i = 0; i < num; i++)
			{
				global::ES3Parser.DFA57.DFA57_transition[i] = global::Antlr.Runtime.DFA.UnpackEncodedString(global::ES3Parser.DFA57.DFA57_transitionS[i]);
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x00038DA8 File Offset: 0x00036FA8
		public DFA57(global::Antlr.Runtime.BaseRecognizer recognizer, global::Antlr.Runtime.SpecialStateTransitionHandler specialStateTransition) : base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 0x39;
			this.eot = global::ES3Parser.DFA57.DFA57_eot;
			this.eof = global::ES3Parser.DFA57.DFA57_eof;
			this.min = global::ES3Parser.DFA57.DFA57_min;
			this.max = global::ES3Parser.DFA57.DFA57_max;
			this.accept = global::ES3Parser.DFA57.DFA57_accept;
			this.special = global::ES3Parser.DFA57.DFA57_special;
			this.transition = global::ES3Parser.DFA57.DFA57_transition;
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x00038E1C File Offset: 0x0003701C
		public override string Description
		{
			get
			{
				return "1420:1: statement returns [Statement value] options {k=1; } : ({...}? block |{...}?func= functionDeclaration | statementTail );";
			}
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00038E24 File Offset: 0x00037024
		public override void Error(global::Antlr.Runtime.NoViableAltException nvae)
		{
		}

		// Token: 0x0400051C RID: 1308
		private const string DFA57_eotS = "(￿";

		// Token: 0x0400051D RID: 1309
		private const string DFA57_eofS = "(￿";

		// Token: 0x0400051E RID: 1310
		private const string DFA57_minS = "\u0001\u0005\u0002\0%￿";

		// Token: 0x0400051F RID: 1311
		private const string DFA57_maxS = "\u0001¦\u0002\0%￿";

		// Token: 0x04000520 RID: 1312
		private const string DFA57_acceptS = "\u0003￿\u0001\u0003\"￿\u0001\u0001\u0001\u0002";

		// Token: 0x04000521 RID: 1313
		private const string DFA57_specialS = "\u0001￿\u0001\0\u0001\u0001%￿}>";

		// Token: 0x04000522 RID: 1314
		private static readonly string[] DFA57_transitionS = new string[]
		{
			"\u0001\u0003\b￿\u0001\u0003\u000e￿\u0001\u0003\u0003￿\u0001\u0003\u0001￿\u0001\u0003\u0002￿\u0001\u0003\u0005￿\u0001\u0003\t￿\u0001\u0003\u0004￿\u0001\u0003\u0002￿\u0001\u0002\u0005￿\u0002\u0003\u0003￿\u0001\u0003\u0003￿\u0001\u0003\u0001￿\u0001\u0003\u0005￿\u0001\u0001\u0001\u0003\u0003￿\u0001\u0003\u000e￿\u0002\u0003\u0001￿\u0001\u0003\u0005￿\u0001\u0003\f￿\u0001\u0003\u0003￿\u0001\u0003\u0001￿\u0001\u0003\n￿\u0001\u0003\u0002￿\u0001\u0003\u0002￿\u0001\u0003\u0001￿\u0002\u0003\u0002￿\u0003\u0003\u0002￿\u0002\u0003\u0002￿\u0002\u0003",
			"\u0001￿",
			"\u0001￿",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		// Token: 0x04000523 RID: 1315
		private static readonly short[] DFA57_eot = global::Antlr.Runtime.DFA.UnpackEncodedString("(￿");

		// Token: 0x04000524 RID: 1316
		private static readonly short[] DFA57_eof = global::Antlr.Runtime.DFA.UnpackEncodedString("(￿");

		// Token: 0x04000525 RID: 1317
		private static readonly char[] DFA57_min = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001\u0005\u0002\0%￿");

		// Token: 0x04000526 RID: 1318
		private static readonly char[] DFA57_max = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001¦\u0002\0%￿");

		// Token: 0x04000527 RID: 1319
		private static readonly short[] DFA57_accept = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0003￿\u0001\u0003\"￿\u0001\u0001\u0001\u0002");

		// Token: 0x04000528 RID: 1320
		private static readonly short[] DFA57_special = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0001￿\u0001\0\u0001\u0001%￿}>");

		// Token: 0x04000529 RID: 1321
		private static readonly short[][] DFA57_transition;
	}

	// Token: 0x02000141 RID: 321
	private class DFA58 : global::Antlr.Runtime.DFA
	{
		// Token: 0x06000BB5 RID: 2997 RVA: 0x00038E28 File Offset: 0x00037028
		static DFA58()
		{
			int num = global::ES3Parser.DFA58.DFA58_transitionS.Length;
			global::ES3Parser.DFA58.DFA58_transition = new short[num][];
			for (int i = 0; i < num; i++)
			{
				global::ES3Parser.DFA58.DFA58_transition[i] = global::Antlr.Runtime.DFA.UnpackEncodedString(global::ES3Parser.DFA58.DFA58_transitionS[i]);
			}
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00038F98 File Offset: 0x00037198
		public DFA58(global::Antlr.Runtime.BaseRecognizer recognizer)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 0x3A;
			this.eot = global::ES3Parser.DFA58.DFA58_eot;
			this.eof = global::ES3Parser.DFA58.DFA58_eof;
			this.min = global::ES3Parser.DFA58.DFA58_min;
			this.max = global::ES3Parser.DFA58.DFA58_max;
			this.accept = global::ES3Parser.DFA58.DFA58_accept;
			this.special = global::ES3Parser.DFA58.DFA58_special;
			this.transition = global::ES3Parser.DFA58.DFA58_transition;
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x0003900C File Offset: 0x0003720C
		public override string Description
		{
			get
			{
				return "1431:1: statementTail returns [Statement value] : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );";
			}
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x00039014 File Offset: 0x00037214
		public override void Error(global::Antlr.Runtime.NoViableAltException nvae)
		{
		}

		// Token: 0x0400052A RID: 1322
		private const string DFA58_eotS = "\u000f￿";

		// Token: 0x0400052B RID: 1323
		private const string DFA58_eofS = "\u0004￿\u0001\u0003\n￿";

		// Token: 0x0400052C RID: 1324
		private const string DFA58_minS = "\u0001\u0005\u0003￿\u0001\u0005\n￿";

		// Token: 0x0400052D RID: 1325
		private const string DFA58_maxS = "\u0001¦\u0003￿\u0001©\n￿";

		// Token: 0x0400052E RID: 1326
		private const string DFA58_acceptS = "\u0001￿\u0001\u0001\u0001\u0002\u0001\u0003\u0001￿\u0001\u0004\u0001\u0005\u0001\u0006\u0001\a\u0001\b\u0001\t\u0001\v\u0001\f\u0001\r\u0001\n";

		// Token: 0x0400052F RID: 1327
		private const string DFA58_specialS = "\u000f￿}>";

		// Token: 0x04000530 RID: 1328
		private static readonly string[] DFA58_transitionS = new string[]
		{
			"\u0001\u0003\b￿\u0001\b\u000e￿\u0001\a\u0003￿\u0001\u0003\u0001￿\u0001\u0003\u0002￿\u0001\u0006\u0005￿\u0001\u0003\t￿\u0001\u0003\u0004￿\u0001\u0006\u0002￿\u0001\u0003\u0005￿\u0001\u0003\u0001\u0005\u0003￿\u0001\u0003\u0003￿\u0001\u0003\u0001￿\u0001\u0004\u0005￿\u0002\u0003\u0003￿\u0001\u0003\u000e￿\u0002\u0003\u0001￿\u0001\u0003\u0005￿\u0001\u0003\f￿\u0001\t\u0003￿\u0001\u0003\u0001￿\u0001\u0002\n￿\u0001\u0003\u0002￿\u0001\v\u0002￿\u0001\u0003\u0001￿\u0001\u0003\u0001\f\u0002￿\u0001\u0003\u0001\r\u0001\u0003\u0002￿\u0001\u0001\u0001\u0003\u0002￿\u0001\u0006\u0001\n",
			"",
			"",
			"",
			"\u0004\u0003\u0002￿\u0001\u0003\u000e￿\u0001\u000e\u0001\u0003\u0005￿\u0001\u0003\u0002￿\u0002\u0003\u0001￿\u0001\u0003\a￿\u0002\u0003\u000f￿\u0002\u0003\u0006￿\u0003\u0003\t￿\u0003\u0003\u0002￿\u0002\u0003\u0001￿\u0002\u0003\u0001￿\u0005\u0003\u0004￿\u0001\u0003\u0002￿\u0001\u0003\u0002￿\u0002\u0003\f￿\u0002\u0003\u0006￿\u0004\u0003\u0001￿\u0004\u0003\u0003￿\u0002\u0003\u0016￿\u0002\u0003",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		// Token: 0x04000531 RID: 1329
		private static readonly short[] DFA58_eot = global::Antlr.Runtime.DFA.UnpackEncodedString("\u000f￿");

		// Token: 0x04000532 RID: 1330
		private static readonly short[] DFA58_eof = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0004￿\u0001\u0003\n￿");

		// Token: 0x04000533 RID: 1331
		private static readonly char[] DFA58_min = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001\u0005\u0003￿\u0001\u0005\n￿");

		// Token: 0x04000534 RID: 1332
		private static readonly char[] DFA58_max = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001¦\u0003￿\u0001©\n￿");

		// Token: 0x04000535 RID: 1333
		private static readonly short[] DFA58_accept = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0001￿\u0001\u0001\u0001\u0002\u0001\u0003\u0001￿\u0001\u0004\u0001\u0005\u0001\u0006\u0001\a\u0001\b\u0001\t\u0001\v\u0001\f\u0001\r\u0001\n");

		// Token: 0x04000536 RID: 1334
		private static readonly short[] DFA58_special = global::Antlr.Runtime.DFA.UnpackEncodedString("\u000f￿}>");

		// Token: 0x04000537 RID: 1335
		private static readonly short[][] DFA58_transition;
	}

	// Token: 0x02000142 RID: 322
	private class DFA88 : global::Antlr.Runtime.DFA
	{
		// Token: 0x06000BB9 RID: 3001 RVA: 0x00039018 File Offset: 0x00037218
		static DFA88()
		{
			int num = global::ES3Parser.DFA88.DFA88_transitionS.Length;
			global::ES3Parser.DFA88.DFA88_transition = new short[num][];
			for (int i = 0; i < num; i++)
			{
				global::ES3Parser.DFA88.DFA88_transition[i] = global::Antlr.Runtime.DFA.UnpackEncodedString(global::ES3Parser.DFA88.DFA88_transitionS[i]);
			}
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x000392C0 File Offset: 0x000374C0
		public DFA88(global::Antlr.Runtime.BaseRecognizer recognizer, global::Antlr.Runtime.SpecialStateTransitionHandler specialStateTransition) : base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 0x58;
			this.eot = global::ES3Parser.DFA88.DFA88_eot;
			this.eof = global::ES3Parser.DFA88.DFA88_eof;
			this.min = global::ES3Parser.DFA88.DFA88_min;
			this.max = global::ES3Parser.DFA88.DFA88_max;
			this.accept = global::ES3Parser.DFA88.DFA88_accept;
			this.special = global::ES3Parser.DFA88.DFA88_special;
			this.transition = global::ES3Parser.DFA88.DFA88_transition;
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x00039334 File Offset: 0x00037534
		public override string Description
		{
			get
			{
				return "1909:1: sourceElement returns [Statement value] options {k=1; } : ({...}?func= functionDeclaration |stat= statement );";
			}
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0003933C File Offset: 0x0003753C
		public override void Error(global::Antlr.Runtime.NoViableAltException nvae)
		{
		}

		// Token: 0x04000538 RID: 1336
		private const string DFA88_eotS = "'￿";

		// Token: 0x04000539 RID: 1337
		private const string DFA88_eofS = "'￿";

		// Token: 0x0400053A RID: 1338
		private const string DFA88_minS = "\u0001\u0005\u0001\0%￿";

		// Token: 0x0400053B RID: 1339
		private const string DFA88_maxS = "\u0001¦\u0001\0%￿";

		// Token: 0x0400053C RID: 1340
		private const string DFA88_acceptS = "\u0002￿\u0001\u0002#￿\u0001\u0001";

		// Token: 0x0400053D RID: 1341
		private const string DFA88_specialS = "\u0001￿\u0001\0%￿}>";

		// Token: 0x0400053E RID: 1342
		private static readonly string[] DFA88_transitionS = new string[]
		{
			"\u0001\u0002\b￿\u0001\u0002\u000e￿\u0001\u0002\u0003￿\u0001\u0002\u0001￿\u0001\u0002\u0002￿\u0001\u0002\u0005￿\u0001\u0002\t￿\u0001\u0002\u0004￿\u0001\u0002\u0002￿\u0001\u0001\u0005￿\u0002\u0002\u0003￿\u0001\u0002\u0003￿\u0001\u0002\u0001￿\u0001\u0002\u0005￿\u0002\u0002\u0003￿\u0001\u0002\u000e￿\u0002\u0002\u0001￿\u0001\u0002\u0005￿\u0001\u0002\f￿\u0001\u0002\u0003￿\u0001\u0002\u0001￿\u0001\u0002\n￿\u0001\u0002\u0002￿\u0001\u0002\u0002￿\u0001\u0002\u0001￿\u0002\u0002\u0002￿\u0003\u0002\u0002￿\u0002\u0002\u0002￿\u0002\u0002",
			"\u0001￿",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		// Token: 0x0400053F RID: 1343
		private static readonly short[] DFA88_eot = global::Antlr.Runtime.DFA.UnpackEncodedString("'￿");

		// Token: 0x04000540 RID: 1344
		private static readonly short[] DFA88_eof = global::Antlr.Runtime.DFA.UnpackEncodedString("'￿");

		// Token: 0x04000541 RID: 1345
		private static readonly char[] DFA88_min = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001\u0005\u0001\0%￿");

		// Token: 0x04000542 RID: 1346
		private static readonly char[] DFA88_max = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001¦\u0001\0%￿");

		// Token: 0x04000543 RID: 1347
		private static readonly short[] DFA88_accept = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0002￿\u0001\u0002#￿\u0001\u0001");

		// Token: 0x04000544 RID: 1348
		private static readonly short[] DFA88_special = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0001￿\u0001\0%￿}>");

		// Token: 0x04000545 RID: 1349
		private static readonly short[][] DFA88_transition;
	}

	// Token: 0x02000143 RID: 323
	private static class Follow
	{
		// Token: 0x06000BBD RID: 3005 RVA: 0x00039340 File Offset: 0x00037540
		// Note: this type is marked as 'beforefieldinit'.
		static Follow()
		{
		}

		// Token: 0x04000546 RID: 1350
		public static readonly global::Antlr.Runtime.BitSet _reservedWord_in_token1748 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000547 RID: 1351
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_token1753 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000548 RID: 1352
		public static readonly global::Antlr.Runtime.BitSet _punctuator_in_token1758 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000549 RID: 1353
		public static readonly global::Antlr.Runtime.BitSet _numericLiteral_in_token1763 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400054A RID: 1354
		public static readonly global::Antlr.Runtime.BitSet _StringLiteral_in_token1768 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400054B RID: 1355
		public static readonly global::Antlr.Runtime.BitSet _keyword_in_reservedWord1781 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400054C RID: 1356
		public static readonly global::Antlr.Runtime.BitSet _futureReservedWord_in_reservedWord1786 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400054D RID: 1357
		public static readonly global::Antlr.Runtime.BitSet _NULL_in_reservedWord1791 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400054E RID: 1358
		public static readonly global::Antlr.Runtime.BitSet _booleanLiteral_in_reservedWord1796 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400054F RID: 1359
		public static readonly global::Antlr.Runtime.BitSet _set_in_keyword1810 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000550 RID: 1360
		public static readonly global::Antlr.Runtime.BitSet _set_in_futureReservedWord1945 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000551 RID: 1361
		public static readonly global::Antlr.Runtime.BitSet _set_in_punctuator2225 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000552 RID: 1362
		public static readonly global::Antlr.Runtime.BitSet _NULL_in_literal2483 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000553 RID: 1363
		public static readonly global::Antlr.Runtime.BitSet _booleanLiteral_in_literal2492 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000554 RID: 1364
		public static readonly global::Antlr.Runtime.BitSet _numericLiteral_in_literal2501 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000555 RID: 1365
		public static readonly global::Antlr.Runtime.BitSet _StringLiteral_in_literal2510 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000556 RID: 1366
		public static readonly global::Antlr.Runtime.BitSet _RegularExpressionLiteral_in_literal2520 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000557 RID: 1367
		public static readonly global::Antlr.Runtime.BitSet _TRUE_in_booleanLiteral2537 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000558 RID: 1368
		public static readonly global::Antlr.Runtime.BitSet _FALSE_in_booleanLiteral2544 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000559 RID: 1369
		public static readonly global::Antlr.Runtime.BitSet _DecimalLiteral_in_numericLiteral2755 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400055A RID: 1370
		public static readonly global::Antlr.Runtime.BitSet _OctalIntegerLiteral_in_numericLiteral2764 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400055B RID: 1371
		public static readonly global::Antlr.Runtime.BitSet _HexIntegerLiteral_in_numericLiteral2773 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400055C RID: 1372
		public static readonly global::Antlr.Runtime.BitSet _THIS_in_primaryExpression3175 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400055D RID: 1373
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_primaryExpression3184 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400055E RID: 1374
		public static readonly global::Antlr.Runtime.BitSet _literal_in_primaryExpression3193 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400055F RID: 1375
		public static readonly global::Antlr.Runtime.BitSet _arrayLiteral_in_primaryExpression3202 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000560 RID: 1376
		public static readonly global::Antlr.Runtime.BitSet _objectLiteral_in_primaryExpression3211 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000561 RID: 1377
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_primaryExpression3220 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000562 RID: 1378
		public static readonly global::Antlr.Runtime.BitSet _expression_in_primaryExpression3224 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000563 RID: 1379
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_primaryExpression3227 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000564 RID: 1380
		public static readonly global::Antlr.Runtime.BitSet _LBRACK_in_arrayLiteral3253 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A08000020UL,
			0x400416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000565 RID: 1381
		public static readonly global::Antlr.Runtime.BitSet _arrayItem_in_arrayLiteral3259 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x4000000000000000UL
		});

		// Token: 0x04000566 RID: 1382
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_arrayLiteral3265 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A08000020UL,
			0x400416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000567 RID: 1383
		public static readonly global::Antlr.Runtime.BitSet _arrayItem_in_arrayLiteral3269 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x4000000000000000UL
		});

		// Token: 0x04000568 RID: 1384
		public static readonly global::Antlr.Runtime.BitSet _RBRACK_in_arrayLiteral3279 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000569 RID: 1385
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_arrayItem3300 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400056A RID: 1386
		public static readonly global::Antlr.Runtime.BitSet _LBRACE_in_objectLiteral3341 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x100000000000UL,
			0x2004000000008010UL,
			0x400000UL
		});

		// Token: 0x0400056B RID: 1387
		public static readonly global::Antlr.Runtime.BitSet _propertyAssignment_in_objectLiteral3347 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x2000000000000000UL
		});

		// Token: 0x0400056C RID: 1388
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_objectLiteral3354 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x100000000000UL,
			0x4000000008010UL,
			0x400000UL
		});

		// Token: 0x0400056D RID: 1389
		public static readonly global::Antlr.Runtime.BitSet _propertyAssignment_in_objectLiteral3358 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x2000000000000000UL
		});

		// Token: 0x0400056E RID: 1390
		public static readonly global::Antlr.Runtime.BitSet _RBRACE_in_objectLiteral3368 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400056F RID: 1391
		public static readonly global::Antlr.Runtime.BitSet _accessor_in_propertyAssignment3391 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x100000000000UL,
			0x4000000008010UL,
			0x400000UL
		});

		// Token: 0x04000570 RID: 1392
		public static readonly global::Antlr.Runtime.BitSet _propertyName_in_propertyAssignment3399 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4200000UL
		});

		// Token: 0x04000571 RID: 1393
		public static readonly global::Antlr.Runtime.BitSet _formalParameterList_in_propertyAssignment3406 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4200000UL
		});

		// Token: 0x04000572 RID: 1394
		public static readonly global::Antlr.Runtime.BitSet _functionBody_in_propertyAssignment3414 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000573 RID: 1395
		public static readonly global::Antlr.Runtime.BitSet _propertyName_in_propertyAssignment3424 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4000000UL
		});

		// Token: 0x04000574 RID: 1396
		public static readonly global::Antlr.Runtime.BitSet _COLON_in_propertyAssignment3428 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000575 RID: 1397
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_propertyAssignment3432 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000576 RID: 1398
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_accessor3452 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000577 RID: 1399
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_propertyName3474 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000578 RID: 1400
		public static readonly global::Antlr.Runtime.BitSet _StringLiteral_in_propertyName3483 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000579 RID: 1401
		public static readonly global::Antlr.Runtime.BitSet _numericLiteral_in_propertyName3492 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400057A RID: 1402
		public static readonly global::Antlr.Runtime.BitSet _primaryExpression_in_memberExpression3518 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400057B RID: 1403
		public static readonly global::Antlr.Runtime.BitSet _functionExpression_in_memberExpression3527 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400057C RID: 1404
		public static readonly global::Antlr.Runtime.BitSet _newExpression_in_memberExpression3536 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400057D RID: 1405
		public static readonly global::Antlr.Runtime.BitSet _NEW_in_newExpression3553 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100000000000UL,
			0x4120004608010UL,
			0x11400008UL
		});

		// Token: 0x0400057E RID: 1406
		public static readonly global::Antlr.Runtime.BitSet _memberExpression_in_newExpression3558 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400057F RID: 1407
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_arguments3581 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410009UL
		});

		// Token: 0x04000580 RID: 1408
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_arguments3587 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0UL,
			1UL
		});

		// Token: 0x04000581 RID: 1409
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_arguments3593 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000582 RID: 1410
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_arguments3597 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0UL,
			1UL
		});

		// Token: 0x04000583 RID: 1411
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_arguments3606 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000584 RID: 1412
		public static readonly global::Antlr.Runtime.BitSet _LBRACE_in_generics3628 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x200416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000585 RID: 1413
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_generics3634 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x2000000000000000UL
		});

		// Token: 0x04000586 RID: 1414
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_generics3640 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000587 RID: 1415
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_generics3644 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x2000000000000000UL
		});

		// Token: 0x04000588 RID: 1416
		public static readonly global::Antlr.Runtime.BitSet _RBRACE_in_generics3653 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000589 RID: 1417
		public static readonly global::Antlr.Runtime.BitSet _memberExpression_in_leftHandSideExpression3689 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000002UL,
			0x4600000UL
		});

		// Token: 0x0400058A RID: 1418
		public static readonly global::Antlr.Runtime.BitSet _generics_in_leftHandSideExpression3705 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4200000UL
		});

		// Token: 0x0400058B RID: 1419
		public static readonly global::Antlr.Runtime.BitSet _arguments_in_leftHandSideExpression3714 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000002UL,
			0x4600000UL
		});

		// Token: 0x0400058C RID: 1420
		public static readonly global::Antlr.Runtime.BitSet _LBRACK_in_leftHandSideExpression3725 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x0400058D RID: 1421
		public static readonly global::Antlr.Runtime.BitSet _expression_in_leftHandSideExpression3729 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000000000000UL
		});

		// Token: 0x0400058E RID: 1422
		public static readonly global::Antlr.Runtime.BitSet _RBRACK_in_leftHandSideExpression3731 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000002UL,
			0x4600000UL
		});

		// Token: 0x0400058F RID: 1423
		public static readonly global::Antlr.Runtime.BitSet _DOT_in_leftHandSideExpression3744 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000590 RID: 1424
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_leftHandSideExpression3748 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000002UL,
			0x4600000UL
		});

		// Token: 0x04000591 RID: 1425
		public static readonly global::Antlr.Runtime.BitSet _leftHandSideExpression_in_postfixExpression3782 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x200000002UL,
			0x200UL
		});

		// Token: 0x04000592 RID: 1426
		public static readonly global::Antlr.Runtime.BitSet _postfixOperator_in_postfixExpression3790 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000593 RID: 1427
		public static readonly global::Antlr.Runtime.BitSet _INC_in_postfixOperator3813 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000594 RID: 1428
		public static readonly global::Antlr.Runtime.BitSet _DEC_in_postfixOperator3822 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000595 RID: 1429
		public static readonly global::Antlr.Runtime.BitSet _postfixExpression_in_unaryExpression3845 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000596 RID: 1430
		public static readonly global::Antlr.Runtime.BitSet _unaryOperator_in_unaryExpression3854 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000597 RID: 1431
		public static readonly global::Antlr.Runtime.BitSet _unaryExpression_in_unaryExpression3859 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000598 RID: 1432
		public static readonly global::Antlr.Runtime.BitSet _DELETE_in_unaryOperator3877 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000599 RID: 1433
		public static readonly global::Antlr.Runtime.BitSet _VOID_in_unaryOperator3884 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400059A RID: 1434
		public static readonly global::Antlr.Runtime.BitSet _TYPEOF_in_unaryOperator3891 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400059B RID: 1435
		public static readonly global::Antlr.Runtime.BitSet _INC_in_unaryOperator3898 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400059C RID: 1436
		public static readonly global::Antlr.Runtime.BitSet _DEC_in_unaryOperator3905 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400059D RID: 1437
		public static readonly global::Antlr.Runtime.BitSet _ADD_in_unaryOperator3914 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400059E RID: 1438
		public static readonly global::Antlr.Runtime.BitSet _SUB_in_unaryOperator3923 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400059F RID: 1439
		public static readonly global::Antlr.Runtime.BitSet _INV_in_unaryOperator3930 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005A0 RID: 1440
		public static readonly global::Antlr.Runtime.BitSet _NOT_in_unaryOperator3937 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005A1 RID: 1441
		public static readonly global::Antlr.Runtime.BitSet _unaryExpression_in_multiplicativeExpression3965 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x1000000002UL,
			0x280000000UL
		});

		// Token: 0x040005A2 RID: 1442
		public static readonly global::Antlr.Runtime.BitSet _MUL_in_multiplicativeExpression3976 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005A3 RID: 1443
		public static readonly global::Antlr.Runtime.BitSet _DIV_in_multiplicativeExpression3985 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005A4 RID: 1444
		public static readonly global::Antlr.Runtime.BitSet _MOD_in_multiplicativeExpression3993 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005A5 RID: 1445
		public static readonly global::Antlr.Runtime.BitSet _unaryExpression_in_multiplicativeExpression4004 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x1000000002UL,
			0x280000000UL
		});

		// Token: 0x040005A6 RID: 1446
		public static readonly global::Antlr.Runtime.BitSet _multiplicativeExpression_in_additiveExpression4034 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x22UL,
			0UL,
			0x10000UL
		});

		// Token: 0x040005A7 RID: 1447
		public static readonly global::Antlr.Runtime.BitSet _ADD_in_additiveExpression4045 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005A8 RID: 1448
		public static readonly global::Antlr.Runtime.BitSet _SUB_in_additiveExpression4053 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005A9 RID: 1449
		public static readonly global::Antlr.Runtime.BitSet _multiplicativeExpression_in_additiveExpression4064 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x22UL,
			0UL,
			0x10000UL
		});

		// Token: 0x040005AA RID: 1450
		public static readonly global::Antlr.Runtime.BitSet _additiveExpression_in_shiftExpression4095 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0UL,
			0xA40UL
		});

		// Token: 0x040005AB RID: 1451
		public static readonly global::Antlr.Runtime.BitSet _SHL_in_shiftExpression4106 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005AC RID: 1452
		public static readonly global::Antlr.Runtime.BitSet _SHR_in_shiftExpression4114 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005AD RID: 1453
		public static readonly global::Antlr.Runtime.BitSet _SHU_in_shiftExpression4122 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005AE RID: 1454
		public static readonly global::Antlr.Runtime.BitSet _additiveExpression_in_shiftExpression4133 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0UL,
			0xA40UL
		});

		// Token: 0x040005AF RID: 1455
		public static readonly global::Antlr.Runtime.BitSet _shiftExpression_in_relationalExpression4164 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x30000503UL
		});

		// Token: 0x040005B0 RID: 1456
		public static readonly global::Antlr.Runtime.BitSet _LT_in_relationalExpression4175 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B1 RID: 1457
		public static readonly global::Antlr.Runtime.BitSet _GT_in_relationalExpression4183 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B2 RID: 1458
		public static readonly global::Antlr.Runtime.BitSet _LTE_in_relationalExpression4191 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B3 RID: 1459
		public static readonly global::Antlr.Runtime.BitSet _GTE_in_relationalExpression4199 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B4 RID: 1460
		public static readonly global::Antlr.Runtime.BitSet _INSTANCEOF_in_relationalExpression4207 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B5 RID: 1461
		public static readonly global::Antlr.Runtime.BitSet _IN_in_relationalExpression4215 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B6 RID: 1462
		public static readonly global::Antlr.Runtime.BitSet _shiftExpression_in_relationalExpression4226 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x30000503UL
		});

		// Token: 0x040005B7 RID: 1463
		public static readonly global::Antlr.Runtime.BitSet _shiftExpression_in_relationalExpressionNoIn4252 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x30000403UL
		});

		// Token: 0x040005B8 RID: 1464
		public static readonly global::Antlr.Runtime.BitSet _LT_in_relationalExpressionNoIn4263 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005B9 RID: 1465
		public static readonly global::Antlr.Runtime.BitSet _GT_in_relationalExpressionNoIn4271 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005BA RID: 1466
		public static readonly global::Antlr.Runtime.BitSet _LTE_in_relationalExpressionNoIn4279 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005BB RID: 1467
		public static readonly global::Antlr.Runtime.BitSet _GTE_in_relationalExpressionNoIn4287 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005BC RID: 1468
		public static readonly global::Antlr.Runtime.BitSet _INSTANCEOF_in_relationalExpressionNoIn4295 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005BD RID: 1469
		public static readonly global::Antlr.Runtime.BitSet _shiftExpression_in_relationalExpressionNoIn4307 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x30000403UL
		});

		// Token: 0x040005BE RID: 1470
		public static readonly global::Antlr.Runtime.BitSet _relationalExpression_in_equalityExpression4338 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x1000000000002UL,
			0x90000000000UL,
			0x10UL
		});

		// Token: 0x040005BF RID: 1471
		public static readonly global::Antlr.Runtime.BitSet _EQ_in_equalityExpression4349 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C0 RID: 1472
		public static readonly global::Antlr.Runtime.BitSet _NEQ_in_equalityExpression4357 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C1 RID: 1473
		public static readonly global::Antlr.Runtime.BitSet _SAME_in_equalityExpression4365 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C2 RID: 1474
		public static readonly global::Antlr.Runtime.BitSet _NSAME_in_equalityExpression4373 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C3 RID: 1475
		public static readonly global::Antlr.Runtime.BitSet _relationalExpression_in_equalityExpression4384 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x1000000000002UL,
			0x90000000000UL,
			0x10UL
		});

		// Token: 0x040005C4 RID: 1476
		public static readonly global::Antlr.Runtime.BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4410 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x1000000000002UL,
			0x90000000000UL,
			0x10UL
		});

		// Token: 0x040005C5 RID: 1477
		public static readonly global::Antlr.Runtime.BitSet _EQ_in_equalityExpressionNoIn4421 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C6 RID: 1478
		public static readonly global::Antlr.Runtime.BitSet _NEQ_in_equalityExpressionNoIn4429 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C7 RID: 1479
		public static readonly global::Antlr.Runtime.BitSet _SAME_in_equalityExpressionNoIn4437 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C8 RID: 1480
		public static readonly global::Antlr.Runtime.BitSet _NSAME_in_equalityExpressionNoIn4445 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005C9 RID: 1481
		public static readonly global::Antlr.Runtime.BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4456 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x1000000000002UL,
			0x90000000000UL,
			0x10UL
		});

		// Token: 0x040005CA RID: 1482
		public static readonly global::Antlr.Runtime.BitSet _equalityExpression_in_bitwiseANDExpression4483 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x82UL
		});

		// Token: 0x040005CB RID: 1483
		public static readonly global::Antlr.Runtime.BitSet _AND_in_bitwiseANDExpression4489 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005CC RID: 1484
		public static readonly global::Antlr.Runtime.BitSet _equalityExpression_in_bitwiseANDExpression4494 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x82UL
		});

		// Token: 0x040005CD RID: 1485
		public static readonly global::Antlr.Runtime.BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4515 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x82UL
		});

		// Token: 0x040005CE RID: 1486
		public static readonly global::Antlr.Runtime.BitSet _AND_in_bitwiseANDExpressionNoIn4521 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005CF RID: 1487
		public static readonly global::Antlr.Runtime.BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4526 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x82UL
		});

		// Token: 0x040005D0 RID: 1488
		public static readonly global::Antlr.Runtime.BitSet _bitwiseANDExpression_in_bitwiseXORExpression4549 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0UL,
			0x10000000000UL
		});

		// Token: 0x040005D1 RID: 1489
		public static readonly global::Antlr.Runtime.BitSet _XOR_in_bitwiseXORExpression4555 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005D2 RID: 1490
		public static readonly global::Antlr.Runtime.BitSet _bitwiseANDExpression_in_bitwiseXORExpression4560 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0UL,
			0x10000000000UL
		});

		// Token: 0x040005D3 RID: 1491
		public static readonly global::Antlr.Runtime.BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4583 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0UL,
			0x10000000000UL
		});

		// Token: 0x040005D4 RID: 1492
		public static readonly global::Antlr.Runtime.BitSet _XOR_in_bitwiseXORExpressionNoIn4589 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005D5 RID: 1493
		public static readonly global::Antlr.Runtime.BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4594 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0UL,
			0x10000000000UL
		});

		// Token: 0x040005D6 RID: 1494
		public static readonly global::Antlr.Runtime.BitSet _bitwiseXORExpression_in_bitwiseORExpression4616 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x400000000000UL
		});

		// Token: 0x040005D7 RID: 1495
		public static readonly global::Antlr.Runtime.BitSet _OR_in_bitwiseORExpression4622 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005D8 RID: 1496
		public static readonly global::Antlr.Runtime.BitSet _bitwiseXORExpression_in_bitwiseORExpression4627 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x400000000000UL
		});

		// Token: 0x040005D9 RID: 1497
		public static readonly global::Antlr.Runtime.BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4649 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x400000000000UL
		});

		// Token: 0x040005DA RID: 1498
		public static readonly global::Antlr.Runtime.BitSet _OR_in_bitwiseORExpressionNoIn4655 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005DB RID: 1499
		public static readonly global::Antlr.Runtime.BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4660 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x400000000000UL
		});

		// Token: 0x040005DC RID: 1500
		public static readonly global::Antlr.Runtime.BitSet _bitwiseORExpression_in_logicalANDExpression4686 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x100000UL
		});

		// Token: 0x040005DD RID: 1501
		public static readonly global::Antlr.Runtime.BitSet _LAND_in_logicalANDExpression4692 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005DE RID: 1502
		public static readonly global::Antlr.Runtime.BitSet _bitwiseORExpression_in_logicalANDExpression4697 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x100000UL
		});

		// Token: 0x040005DF RID: 1503
		public static readonly global::Antlr.Runtime.BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4718 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x100000UL
		});

		// Token: 0x040005E0 RID: 1504
		public static readonly global::Antlr.Runtime.BitSet _LAND_in_logicalANDExpressionNoIn4724 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005E1 RID: 1505
		public static readonly global::Antlr.Runtime.BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4729 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x100000UL
		});

		// Token: 0x040005E2 RID: 1506
		public static readonly global::Antlr.Runtime.BitSet _logicalANDExpression_in_logicalORExpression4751 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x2000000UL
		});

		// Token: 0x040005E3 RID: 1507
		public static readonly global::Antlr.Runtime.BitSet _LOR_in_logicalORExpression4757 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005E4 RID: 1508
		public static readonly global::Antlr.Runtime.BitSet _logicalANDExpression_in_logicalORExpression4762 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x2000000UL
		});

		// Token: 0x040005E5 RID: 1509
		public static readonly global::Antlr.Runtime.BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4784 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x2000000UL
		});

		// Token: 0x040005E6 RID: 1510
		public static readonly global::Antlr.Runtime.BitSet _LOR_in_logicalORExpressionNoIn4790 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005E7 RID: 1511
		public static readonly global::Antlr.Runtime.BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4795 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x2000000UL
		});

		// Token: 0x040005E8 RID: 1512
		public static readonly global::Antlr.Runtime.BitSet _logicalORExpression_in_conditionalExpression4822 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x1000000000000000UL
		});

		// Token: 0x040005E9 RID: 1513
		public static readonly global::Antlr.Runtime.BitSet _QUE_in_conditionalExpression4828 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005EA RID: 1514
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_conditionalExpression4833 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4000000UL
		});

		// Token: 0x040005EB RID: 1515
		public static readonly global::Antlr.Runtime.BitSet _COLON_in_conditionalExpression4835 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005EC RID: 1516
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_conditionalExpression4840 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005ED RID: 1517
		public static readonly global::Antlr.Runtime.BitSet _logicalORExpressionNoIn_in_conditionalExpressionNoIn4861 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL,
			0x1000000000000000UL
		});

		// Token: 0x040005EE RID: 1518
		public static readonly global::Antlr.Runtime.BitSet _QUE_in_conditionalExpressionNoIn4867 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005EF RID: 1519
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn4872 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4000000UL
		});

		// Token: 0x040005F0 RID: 1520
		public static readonly global::Antlr.Runtime.BitSet _COLON_in_conditionalExpressionNoIn4874 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005F1 RID: 1521
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn4879 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005F2 RID: 1522
		public static readonly global::Antlr.Runtime.BitSet _conditionalExpression_in_assignmentExpression4912 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x2000000942UL,
			0x800500000000UL,
			0x20000021480UL
		});

		// Token: 0x040005F3 RID: 1523
		public static readonly global::Antlr.Runtime.BitSet _assignmentOperator_in_assignmentExpression4924 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005F4 RID: 1524
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_assignmentExpression4931 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005F5 RID: 1525
		public static readonly global::Antlr.Runtime.BitSet _set_in_assignmentOperator4946 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005F6 RID: 1526
		public static readonly global::Antlr.Runtime.BitSet _conditionalExpressionNoIn_in_assignmentExpressionNoIn5026 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x2000000942UL,
			0x800500000000UL,
			0x20000021480UL
		});

		// Token: 0x040005F7 RID: 1527
		public static readonly global::Antlr.Runtime.BitSet _assignmentOperator_in_assignmentExpressionNoIn5038 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005F8 RID: 1528
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpressionNoIn_in_assignmentExpressionNoIn5045 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040005F9 RID: 1529
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_expression5077 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000002UL
		});

		// Token: 0x040005FA RID: 1530
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_expression5083 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005FB RID: 1531
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_expression5089 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000002UL
		});

		// Token: 0x040005FC RID: 1532
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpressionNoIn_in_expressionNoIn5117 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000002UL
		});

		// Token: 0x040005FD RID: 1533
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_expressionNoIn5123 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x040005FE RID: 1534
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpressionNoIn_in_expressionNoIn5129 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000002UL
		});

		// Token: 0x040005FF RID: 1535
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_semic5163 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000600 RID: 1536
		public static readonly global::Antlr.Runtime.BitSet _EOF_in_semic5168 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000601 RID: 1537
		public static readonly global::Antlr.Runtime.BitSet _RBRACE_in_semic5173 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000602 RID: 1538
		public static readonly global::Antlr.Runtime.BitSet _EOL_in_semic5180 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000603 RID: 1539
		public static readonly global::Antlr.Runtime.BitSet _MultiLineComment_in_semic5184 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000604 RID: 1540
		public static readonly global::Antlr.Runtime.BitSet _block_in_statement5218 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000605 RID: 1541
		public static readonly global::Antlr.Runtime.BitSet _functionDeclaration_in_statement5229 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000606 RID: 1542
		public static readonly global::Antlr.Runtime.BitSet _statementTail_in_statement5236 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000607 RID: 1543
		public static readonly global::Antlr.Runtime.BitSet _variableStatement_in_statementTail5259 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000608 RID: 1544
		public static readonly global::Antlr.Runtime.BitSet _emptyStatement_in_statementTail5266 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000609 RID: 1545
		public static readonly global::Antlr.Runtime.BitSet _expressionStatement_in_statementTail5273 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400060A RID: 1546
		public static readonly global::Antlr.Runtime.BitSet _ifStatement_in_statementTail5280 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400060B RID: 1547
		public static readonly global::Antlr.Runtime.BitSet _iterationStatement_in_statementTail5287 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400060C RID: 1548
		public static readonly global::Antlr.Runtime.BitSet _continueStatement_in_statementTail5294 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400060D RID: 1549
		public static readonly global::Antlr.Runtime.BitSet _breakStatement_in_statementTail5301 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400060E RID: 1550
		public static readonly global::Antlr.Runtime.BitSet _returnStatement_in_statementTail5308 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400060F RID: 1551
		public static readonly global::Antlr.Runtime.BitSet _withStatement_in_statementTail5315 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000610 RID: 1552
		public static readonly global::Antlr.Runtime.BitSet _labelledStatement_in_statementTail5322 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000611 RID: 1553
		public static readonly global::Antlr.Runtime.BitSet _switchStatement_in_statementTail5329 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000612 RID: 1554
		public static readonly global::Antlr.Runtime.BitSet _throwStatement_in_statementTail5336 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000613 RID: 1555
		public static readonly global::Antlr.Runtime.BitSet _tryStatement_in_statementTail5343 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000614 RID: 1556
		public static readonly global::Antlr.Runtime.BitSet _LBRACE_in_block5373 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0xA00416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000615 RID: 1557
		public static readonly global::Antlr.Runtime.BitSet _statement_in_block5376 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0xA00416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000616 RID: 1558
		public static readonly global::Antlr.Runtime.BitSet _RBRACE_in_block5382 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000617 RID: 1559
		public static readonly global::Antlr.Runtime.BitSet _VAR_in_variableStatement5412 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000618 RID: 1560
		public static readonly global::Antlr.Runtime.BitSet _variableDeclaration_in_variableStatement5416 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x04000619 RID: 1561
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_variableStatement5422 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x0400061A RID: 1562
		public static readonly global::Antlr.Runtime.BitSet _variableDeclaration_in_variableStatement5428 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x0400061B RID: 1563
		public static readonly global::Antlr.Runtime.BitSet _semic_in_variableStatement5436 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400061C RID: 1564
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_variableDeclaration5460 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x802UL
		});

		// Token: 0x0400061D RID: 1565
		public static readonly global::Antlr.Runtime.BitSet _ASSIGN_in_variableDeclaration5466 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x0400061E RID: 1566
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpression_in_variableDeclaration5471 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400061F RID: 1567
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_variableDeclarationNoIn5499 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x802UL
		});

		// Token: 0x04000620 RID: 1568
		public static readonly global::Antlr.Runtime.BitSet _ASSIGN_in_variableDeclarationNoIn5505 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000621 RID: 1569
		public static readonly global::Antlr.Runtime.BitSet _assignmentExpressionNoIn_in_variableDeclarationNoIn5510 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000622 RID: 1570
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_emptyStatement5535 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000623 RID: 1571
		public static readonly global::Antlr.Runtime.BitSet _expression_in_expressionStatement5560 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x04000624 RID: 1572
		public static readonly global::Antlr.Runtime.BitSet _semic_in_expressionStatement5562 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000625 RID: 1573
		public static readonly global::Antlr.Runtime.BitSet _IF_in_ifStatement5591 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000626 RID: 1574
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_ifStatement5593 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000627 RID: 1575
		public static readonly global::Antlr.Runtime.BitSet _expression_in_ifStatement5595 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000628 RID: 1576
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_ifStatement5599 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000629 RID: 1577
		public static readonly global::Antlr.Runtime.BitSet _statement_in_ifStatement5603 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x200000000002UL
		});

		// Token: 0x0400062A RID: 1578
		public static readonly global::Antlr.Runtime.BitSet _ELSE_in_ifStatement5611 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x0400062B RID: 1579
		public static readonly global::Antlr.Runtime.BitSet _statement_in_ifStatement5615 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400062C RID: 1580
		public static readonly global::Antlr.Runtime.BitSet _doStatement_in_iterationStatement5645 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400062D RID: 1581
		public static readonly global::Antlr.Runtime.BitSet _whileStatement_in_iterationStatement5654 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400062E RID: 1582
		public static readonly global::Antlr.Runtime.BitSet _forStatement_in_iterationStatement5664 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400062F RID: 1583
		public static readonly global::Antlr.Runtime.BitSet _DO_in_doStatement5683 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000630 RID: 1584
		public static readonly global::Antlr.Runtime.BitSet _statement_in_doStatement5685 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			0x2000000000UL
		});

		// Token: 0x04000631 RID: 1585
		public static readonly global::Antlr.Runtime.BitSet _WHILE_in_doStatement5687 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000632 RID: 1586
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_doStatement5689 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000633 RID: 1587
		public static readonly global::Antlr.Runtime.BitSet _expression_in_doStatement5691 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000634 RID: 1588
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_doStatement5693 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x04000635 RID: 1589
		public static readonly global::Antlr.Runtime.BitSet _semic_in_doStatement5695 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000636 RID: 1590
		public static readonly global::Antlr.Runtime.BitSet _WHILE_in_whileStatement5715 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000637 RID: 1591
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_whileStatement5718 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000638 RID: 1592
		public static readonly global::Antlr.Runtime.BitSet _expression_in_whileStatement5721 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000639 RID: 1593
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_whileStatement5723 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x0400063A RID: 1594
		public static readonly global::Antlr.Runtime.BitSet _statement_in_whileStatement5726 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400063B RID: 1595
		public static readonly global::Antlr.Runtime.BitSet _FOR_in_forStatement5745 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x0400063C RID: 1596
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_forStatement5748 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x651410028UL
		});

		// Token: 0x0400063D RID: 1597
		public static readonly global::Antlr.Runtime.BitSet _forControl_in_forStatement5753 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x0400063E RID: 1598
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_forStatement5758 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x0400063F RID: 1599
		public static readonly global::Antlr.Runtime.BitSet _statement_in_forStatement5763 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000640 RID: 1600
		public static readonly global::Antlr.Runtime.BitSet _forControlVar_in_forControl5782 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000641 RID: 1601
		public static readonly global::Antlr.Runtime.BitSet _forControlExpression_in_forControl5791 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000642 RID: 1602
		public static readonly global::Antlr.Runtime.BitSet _forControlSemic_in_forControl5800 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000643 RID: 1603
		public static readonly global::Antlr.Runtime.BitSet _VAR_in_forControlVar5828 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000644 RID: 1604
		public static readonly global::Antlr.Runtime.BitSet _variableDeclarationNoIn_in_forControlVar5832 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0x100UL,
			0x20UL
		});

		// Token: 0x04000645 RID: 1605
		public static readonly global::Antlr.Runtime.BitSet _IN_in_forControlVar5846 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000646 RID: 1606
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlVar5850 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000647 RID: 1607
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_forControlVar5875 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000648 RID: 1608
		public static readonly global::Antlr.Runtime.BitSet _variableDeclarationNoIn_in_forControlVar5881 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0UL,
			0x20UL
		});

		// Token: 0x04000649 RID: 1609
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_forControlVar5892 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410028UL
		});

		// Token: 0x0400064A RID: 1610
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlVar5898 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			0x20UL
		});

		// Token: 0x0400064B RID: 1611
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_forControlVar5906 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000022UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x0400064C RID: 1612
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlVar5911 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400064D RID: 1613
		public static readonly global::Antlr.Runtime.BitSet _expressionNoIn_in_forControlExpression5950 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x100UL,
			0x20UL
		});

		// Token: 0x0400064E RID: 1614
		public static readonly global::Antlr.Runtime.BitSet _IN_in_forControlExpression5967 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x0400064F RID: 1615
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlExpression5971 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000650 RID: 1616
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_forControlExpression5994 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410028UL
		});

		// Token: 0x04000651 RID: 1617
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlExpression6000 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			0x20UL
		});

		// Token: 0x04000652 RID: 1618
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_forControlExpression6008 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000022UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000653 RID: 1619
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlExpression6013 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000654 RID: 1620
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_forControlSemic6049 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410028UL
		});

		// Token: 0x04000655 RID: 1621
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlSemic6055 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			0x20UL
		});

		// Token: 0x04000656 RID: 1622
		public static readonly global::Antlr.Runtime.BitSet _SEMIC_in_forControlSemic6063 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000022UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000657 RID: 1623
		public static readonly global::Antlr.Runtime.BitSet _expression_in_forControlSemic6068 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000658 RID: 1624
		public static readonly global::Antlr.Runtime.BitSet _CONTINUE_in_continueStatement6102 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800008000UL,
			0x20UL
		});

		// Token: 0x04000659 RID: 1625
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_continueStatement6110 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x0400065A RID: 1626
		public static readonly global::Antlr.Runtime.BitSet _semic_in_continueStatement6117 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400065B RID: 1627
		public static readonly global::Antlr.Runtime.BitSet _BREAK_in_breakStatement6147 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800008000UL,
			0x20UL
		});

		// Token: 0x0400065C RID: 1628
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_breakStatement6155 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x0400065D RID: 1629
		public static readonly global::Antlr.Runtime.BitSet _semic_in_breakStatement6162 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400065E RID: 1630
		public static readonly global::Antlr.Runtime.BitSet _RETURN_in_returnStatement6192 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040900A08000020UL,
			0x200416080460A210UL,
			0x451410028UL
		});

		// Token: 0x0400065F RID: 1631
		public static readonly global::Antlr.Runtime.BitSet _expression_in_returnStatement6200 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x04000660 RID: 1632
		public static readonly global::Antlr.Runtime.BitSet _semic_in_returnStatement6206 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000661 RID: 1633
		public static readonly global::Antlr.Runtime.BitSet _WITH_in_withStatement6227 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000662 RID: 1634
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_withStatement6230 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000663 RID: 1635
		public static readonly global::Antlr.Runtime.BitSet _expression_in_withStatement6235 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000664 RID: 1636
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_withStatement6237 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000665 RID: 1637
		public static readonly global::Antlr.Runtime.BitSet _statement_in_withStatement6242 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000666 RID: 1638
		public static readonly global::Antlr.Runtime.BitSet _SWITCH_in_switchStatement6269 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000667 RID: 1639
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_switchStatement6271 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000668 RID: 1640
		public static readonly global::Antlr.Runtime.BitSet _expression_in_switchStatement6273 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000669 RID: 1641
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_switchStatement6277 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x200000UL
		});

		// Token: 0x0400066A RID: 1642
		public static readonly global::Antlr.Runtime.BitSet _LBRACE_in_switchStatement6282 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x400200000UL,
			0x2000000000000000UL
		});

		// Token: 0x0400066B RID: 1643
		public static readonly global::Antlr.Runtime.BitSet _defaultClause_in_switchStatement6289 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x400200000UL,
			0x2000000000000000UL
		});

		// Token: 0x0400066C RID: 1644
		public static readonly global::Antlr.Runtime.BitSet _caseClause_in_switchStatement6295 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x400200000UL,
			0x2000000000000000UL
		});

		// Token: 0x0400066D RID: 1645
		public static readonly global::Antlr.Runtime.BitSet _RBRACE_in_switchStatement6302 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400066E RID: 1646
		public static readonly global::Antlr.Runtime.BitSet _CASE_in_caseClause6325 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x0400066F RID: 1647
		public static readonly global::Antlr.Runtime.BitSet _expression_in_caseClause6328 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4000000UL
		});

		// Token: 0x04000670 RID: 1648
		public static readonly global::Antlr.Runtime.BitSet _COLON_in_caseClause6332 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004022UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000671 RID: 1649
		public static readonly global::Antlr.Runtime.BitSet _statement_in_caseClause6336 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004022UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000672 RID: 1650
		public static readonly global::Antlr.Runtime.BitSet _DEFAULT_in_defaultClause6361 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4000000UL
		});

		// Token: 0x04000673 RID: 1651
		public static readonly global::Antlr.Runtime.BitSet _COLON_in_defaultClause6364 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004022UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000674 RID: 1652
		public static readonly global::Antlr.Runtime.BitSet _statement_in_defaultClause6368 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004022UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000675 RID: 1653
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_labelledStatement6395 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4000000UL
		});

		// Token: 0x04000676 RID: 1654
		public static readonly global::Antlr.Runtime.BitSet _COLON_in_labelledStatement6397 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000677 RID: 1655
		public static readonly global::Antlr.Runtime.BitSet _statement_in_labelledStatement6401 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000678 RID: 1656
		public static readonly global::Antlr.Runtime.BitSet _THROW_in_throwStatement6427 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4040100A00000020UL,
			0x416000460A210UL,
			0x451410008UL
		});

		// Token: 0x04000679 RID: 1657
		public static readonly global::Antlr.Runtime.BitSet _expression_in_throwStatement6434 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x800008000000UL,
			0x2000000800000000UL,
			0x20UL
		});

		// Token: 0x0400067A RID: 1658
		public static readonly global::Antlr.Runtime.BitSet _semic_in_throwStatement6438 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400067B RID: 1659
		public static readonly global::Antlr.Runtime.BitSet _TRY_in_tryStatement6463 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x200000UL
		});

		// Token: 0x0400067C RID: 1660
		public static readonly global::Antlr.Runtime.BitSet _block_in_tryStatement6468 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x200000000400000UL
		});

		// Token: 0x0400067D RID: 1661
		public static readonly global::Antlr.Runtime.BitSet _catchClause_in_tryStatement6477 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x200000000400002UL
		});

		// Token: 0x0400067E RID: 1662
		public static readonly global::Antlr.Runtime.BitSet _finallyClause_in_tryStatement6484 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400067F RID: 1663
		public static readonly global::Antlr.Runtime.BitSet _finallyClause_in_tryStatement6494 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000680 RID: 1664
		public static readonly global::Antlr.Runtime.BitSet _CATCH_in_catchClause6514 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000681 RID: 1665
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_catchClause6517 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000682 RID: 1666
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_catchClause6522 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0UL,
			1UL
		});

		// Token: 0x04000683 RID: 1667
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_catchClause6524 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x200000UL
		});

		// Token: 0x04000684 RID: 1668
		public static readonly global::Antlr.Runtime.BitSet _block_in_catchClause6527 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000685 RID: 1669
		public static readonly global::Antlr.Runtime.BitSet _FINALLY_in_finallyClause6545 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x200000UL
		});

		// Token: 0x04000686 RID: 1670
		public static readonly global::Antlr.Runtime.BitSet _block_in_finallyClause6548 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000687 RID: 1671
		public static readonly global::Antlr.Runtime.BitSet _FUNCTION_in_functionDeclaration6580 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000688 RID: 1672
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_functionDeclaration6585 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x04000689 RID: 1673
		public static readonly global::Antlr.Runtime.BitSet _formalParameterList_in_functionDeclaration6595 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4200000UL
		});

		// Token: 0x0400068A RID: 1674
		public static readonly global::Antlr.Runtime.BitSet _functionBody_in_functionDeclaration6604 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400068B RID: 1675
		public static readonly global::Antlr.Runtime.BitSet _FUNCTION_in_functionExpression6631 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4008000UL
		});

		// Token: 0x0400068C RID: 1676
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_functionExpression6636 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4000000UL
		});

		// Token: 0x0400068D RID: 1677
		public static readonly global::Antlr.Runtime.BitSet _formalParameterList_in_functionExpression6643 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x4200000UL
		});

		// Token: 0x0400068E RID: 1678
		public static readonly global::Antlr.Runtime.BitSet _functionBody_in_functionExpression6647 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400068F RID: 1679
		public static readonly global::Antlr.Runtime.BitSet _LPAREN_in_formalParameterList6672 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL,
			1UL
		});

		// Token: 0x04000690 RID: 1680
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_formalParameterList6678 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0UL,
			1UL
		});

		// Token: 0x04000691 RID: 1681
		public static readonly global::Antlr.Runtime.BitSet _COMMA_in_formalParameterList6684 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0UL,
			0x8000UL
		});

		// Token: 0x04000692 RID: 1682
		public static readonly global::Antlr.Runtime.BitSet _Identifier_in_formalParameterList6688 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x8000000UL,
			0UL,
			1UL
		});

		// Token: 0x04000693 RID: 1683
		public static readonly global::Antlr.Runtime.BitSet _RPAREN_in_formalParameterList6699 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000694 RID: 1684
		public static readonly global::Antlr.Runtime.BitSet _LBRACE_in_functionBody6726 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0xA00416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000695 RID: 1685
		public static readonly global::Antlr.Runtime.BitSet _sourceElement_in_functionBody6729 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004020UL,
			0xA00416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000696 RID: 1686
		public static readonly global::Antlr.Runtime.BitSet _RBRACE_in_functionBody6736 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000697 RID: 1687
		public static readonly global::Antlr.Runtime.BitSet _sourceElement_in_program6765 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			0x4840104A20004022UL,
			0x800416000460A230UL,
			0x6673490028UL
		});

		// Token: 0x04000698 RID: 1688
		public static readonly global::Antlr.Runtime.BitSet _functionDeclaration_in_sourceElement6806 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000699 RID: 1689
		public static readonly global::Antlr.Runtime.BitSet _statement_in_sourceElement6815 = new global::Antlr.Runtime.BitSet(new ulong[]
		{
			2UL
		});
	}
}
