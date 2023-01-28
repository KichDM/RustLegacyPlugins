using System;
using System.CodeDom.Compiler;
using Antlr.Runtime;

// Token: 0x02000023 RID: 35
[global::System.CLSCompliant(false)]
[global::System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3.1.7705")]
public class ES3Lexer : global::Antlr.Runtime.Lexer
{
	// Token: 0x06000122 RID: 290 RVA: 0x000077FC File Offset: 0x000059FC
	private bool AreRegularExpressionsEnabled()
	{
		if (this.last == null)
		{
			return true;
		}
		int type = this.last.Type;
		if (type <= 0x4F)
		{
			if (type <= 0x36)
			{
				if (type != 0x2C && type != 0x36)
				{
					return true;
				}
			}
			else if (type != 0x44 && type != 0x4F)
			{
				return true;
			}
		}
		else if (type <= 0x72)
		{
			if (type != 0x6C && type != 0x72)
			{
				return true;
			}
		}
		else
		{
			switch (type)
			{
			case 0x7E:
			case 0x80:
				break;
			case 0x7F:
				return true;
			default:
				switch (type)
				{
				case 0x96:
				case 0x98:
					break;
				case 0x97:
					return true;
				default:
					if (type != 0x9C)
					{
						return true;
					}
					break;
				}
				break;
			}
		}
		return false;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x000078B8 File Offset: 0x00005AB8
	private void ConsumeIdentifierUnicodeStart()
	{
		int num = this.input.LA(1);
		if (this.IsIdentifierStartUnicode(num))
		{
			this.MatchAny();
			for (;;)
			{
				num = this.input.LA(1);
				if (num != 0x24 && (num < 0x30 || num > 0x39) && (num < 0x41 || num > 0x5A) && (num != 0x5C && num != 0x5F && (num < 0x61 || num > 0x7A)) && !this.IsIdentifierPartUnicode(num))
				{
					break;
				}
				this.mIdentifierPart();
			}
			return;
		}
		throw new global::Antlr.Runtime.NoViableAltException();
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00007958 File Offset: 0x00005B58
	private bool IsIdentifierPartUnicode(int ch)
	{
		return char.IsLetterOrDigit((char)ch);
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00007964 File Offset: 0x00005B64
	private bool IsIdentifierStartUnicode(int ch)
	{
		return char.IsLetter((char)ch);
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00007970 File Offset: 0x00005B70
	public override global::Antlr.Runtime.IToken NextToken()
	{
		global::Antlr.Runtime.IToken token = base.NextToken();
		if (token.Channel == 0)
		{
			this.last = token;
		}
		return token;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0000799C File Offset: 0x00005B9C
	public ES3Lexer()
	{
	}

	// Token: 0x06000128 RID: 296 RVA: 0x000079A4 File Offset: 0x00005BA4
	public ES3Lexer(global::Antlr.Runtime.ICharStream input) : this(input, new global::Antlr.Runtime.RecognizerSharedState())
	{
	}

	// Token: 0x06000129 RID: 297 RVA: 0x000079B4 File Offset: 0x00005BB4
	public ES3Lexer(global::Antlr.Runtime.ICharStream input, global::Antlr.Runtime.RecognizerSharedState state) : base(input, state)
	{
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x0600012A RID: 298 RVA: 0x000079C0 File Offset: 0x00005BC0
	public override string GrammarFileName
	{
		get
		{
			return "C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g";
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x000079C8 File Offset: 0x00005BC8
	[global::Antlr.Runtime.GrammarRule("ABSTRACT")]
	private void mABSTRACT()
	{
		int type = 4;
		int channel = 0;
		this.Match("abstract");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00007A00 File Offset: 0x00005C00
	[global::Antlr.Runtime.GrammarRule("ADD")]
	private void mADD()
	{
		int type = 5;
		int channel = 0;
		this.Match(0x2B);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00007A38 File Offset: 0x00005C38
	[global::Antlr.Runtime.GrammarRule("ADDASS")]
	private void mADDASS()
	{
		int type = 6;
		int channel = 0;
		this.Match("+=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00007A70 File Offset: 0x00005C70
	[global::Antlr.Runtime.GrammarRule("AND")]
	private void mAND()
	{
		int type = 7;
		int channel = 0;
		this.Match(0x26);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00007AA8 File Offset: 0x00005CA8
	[global::Antlr.Runtime.GrammarRule("ANDASS")]
	private void mANDASS()
	{
		int type = 8;
		int channel = 0;
		this.Match("&=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00007AE0 File Offset: 0x00005CE0
	[global::Antlr.Runtime.GrammarRule("ASSIGN")]
	private void mASSIGN()
	{
		int type = 0xB;
		int channel = 0;
		this.Match(0x3D);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00007B18 File Offset: 0x00005D18
	[global::Antlr.Runtime.GrammarRule("BOOLEAN")]
	private void mBOOLEAN()
	{
		int type = 0xD;
		int channel = 0;
		this.Match("boolean");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00007B54 File Offset: 0x00005D54
	[global::Antlr.Runtime.GrammarRule("BREAK")]
	private void mBREAK()
	{
		int type = 0xE;
		int channel = 0;
		this.Match("break");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00007B90 File Offset: 0x00005D90
	[global::Antlr.Runtime.GrammarRule("BYTE")]
	private void mBYTE()
	{
		int type = 0x12;
		int channel = 0;
		this.Match("byte");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00007BCC File Offset: 0x00005DCC
	[global::Antlr.Runtime.GrammarRule("CASE")]
	private void mCASE()
	{
		int type = 0x15;
		int channel = 0;
		this.Match("case");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00007C08 File Offset: 0x00005E08
	[global::Antlr.Runtime.GrammarRule("CATCH")]
	private void mCATCH()
	{
		int type = 0x16;
		int channel = 0;
		this.Match("catch");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x00007C44 File Offset: 0x00005E44
	[global::Antlr.Runtime.GrammarRule("CHAR")]
	private void mCHAR()
	{
		int type = 0x18;
		int channel = 0;
		this.Match("char");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00007C80 File Offset: 0x00005E80
	[global::Antlr.Runtime.GrammarRule("CLASS")]
	private void mCLASS()
	{
		int type = 0x19;
		int channel = 0;
		this.Match("class");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00007CBC File Offset: 0x00005EBC
	[global::Antlr.Runtime.GrammarRule("COLON")]
	private void mCOLON()
	{
		int type = 0x1A;
		int channel = 0;
		this.Match(0x3A);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00007CF4 File Offset: 0x00005EF4
	[global::Antlr.Runtime.GrammarRule("COMMA")]
	private void mCOMMA()
	{
		int type = 0x1B;
		int channel = 0;
		this.Match(0x2C);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00007D2C File Offset: 0x00005F2C
	[global::Antlr.Runtime.GrammarRule("CONST")]
	private void mCONST()
	{
		int type = 0x1C;
		int channel = 0;
		this.Match("const");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00007D68 File Offset: 0x00005F68
	[global::Antlr.Runtime.GrammarRule("CONTINUE")]
	private void mCONTINUE()
	{
		int type = 0x1D;
		int channel = 0;
		this.Match("continue");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00007DA4 File Offset: 0x00005FA4
	[global::Antlr.Runtime.GrammarRule("DEBUGGER")]
	private void mDEBUGGER()
	{
		int type = 0x20;
		int channel = 0;
		this.Match("debugger");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00007DE0 File Offset: 0x00005FE0
	[global::Antlr.Runtime.GrammarRule("DEC")]
	private void mDEC()
	{
		int type = 0x21;
		int channel = 0;
		this.Match("--");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600013E RID: 318 RVA: 0x00007E1C File Offset: 0x0000601C
	[global::Antlr.Runtime.GrammarRule("DEFAULT")]
	private void mDEFAULT()
	{
		int type = 0x22;
		int channel = 0;
		this.Match("default");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00007E58 File Offset: 0x00006058
	[global::Antlr.Runtime.GrammarRule("DELETE")]
	private void mDELETE()
	{
		int type = 0x23;
		int channel = 0;
		this.Match("delete");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00007E94 File Offset: 0x00006094
	[global::Antlr.Runtime.GrammarRule("DIV")]
	private void mDIV()
	{
		int type = 0x24;
		int channel = 0;
		this.Match(0x2F);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00007ECC File Offset: 0x000060CC
	[global::Antlr.Runtime.GrammarRule("DIVASS")]
	private void mDIVASS()
	{
		int type = 0x25;
		int channel = 0;
		this.Match("/=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00007F08 File Offset: 0x00006108
	[global::Antlr.Runtime.GrammarRule("DO")]
	private void mDO()
	{
		int type = 0x26;
		int channel = 0;
		this.Match("do");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00007F44 File Offset: 0x00006144
	[global::Antlr.Runtime.GrammarRule("DOT")]
	private void mDOT()
	{
		int type = 0x27;
		int channel = 0;
		this.Match(0x2E);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00007F7C File Offset: 0x0000617C
	[global::Antlr.Runtime.GrammarRule("DOUBLE")]
	private void mDOUBLE()
	{
		int type = 0x28;
		int channel = 0;
		this.Match("double");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00007FB8 File Offset: 0x000061B8
	[global::Antlr.Runtime.GrammarRule("ELSE")]
	private void mELSE()
	{
		int type = 0x2D;
		int channel = 0;
		this.Match("else");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00007FF4 File Offset: 0x000061F4
	[global::Antlr.Runtime.GrammarRule("ENUM")]
	private void mENUM()
	{
		int type = 0x2E;
		int channel = 0;
		this.Match("enum");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00008030 File Offset: 0x00006230
	[global::Antlr.Runtime.GrammarRule("EQ")]
	private void mEQ()
	{
		int type = 0x30;
		int channel = 0;
		this.Match("==");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0000806C File Offset: 0x0000626C
	[global::Antlr.Runtime.GrammarRule("EXPORT")]
	private void mEXPORT()
	{
		int type = 0x31;
		int channel = 0;
		this.Match("export");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000080A8 File Offset: 0x000062A8
	[global::Antlr.Runtime.GrammarRule("EXTENDS")]
	private void mEXTENDS()
	{
		int type = 0x33;
		int channel = 0;
		this.Match("extends");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x000080E4 File Offset: 0x000062E4
	[global::Antlr.Runtime.GrammarRule("FALSE")]
	private void mFALSE()
	{
		int type = 0x36;
		int channel = 0;
		this.Match("false");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00008120 File Offset: 0x00006320
	[global::Antlr.Runtime.GrammarRule("FINAL")]
	private void mFINAL()
	{
		int type = 0x38;
		int channel = 0;
		this.Match("final");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0000815C File Offset: 0x0000635C
	[global::Antlr.Runtime.GrammarRule("FINALLY")]
	private void mFINALLY()
	{
		int type = 0x39;
		int channel = 0;
		this.Match("finally");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00008198 File Offset: 0x00006398
	[global::Antlr.Runtime.GrammarRule("FLOAT")]
	private void mFLOAT()
	{
		int type = 0x3A;
		int channel = 0;
		this.Match("float");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x000081D4 File Offset: 0x000063D4
	[global::Antlr.Runtime.GrammarRule("FOR")]
	private void mFOR()
	{
		int type = 0x3B;
		int channel = 0;
		this.Match("for");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00008210 File Offset: 0x00006410
	[global::Antlr.Runtime.GrammarRule("FUNCTION")]
	private void mFUNCTION()
	{
		int type = 0x3E;
		int channel = 0;
		this.Match("function");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x0000824C File Offset: 0x0000644C
	[global::Antlr.Runtime.GrammarRule("GOTO")]
	private void mGOTO()
	{
		int type = 0x3F;
		int channel = 0;
		this.Match("goto");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00008288 File Offset: 0x00006488
	[global::Antlr.Runtime.GrammarRule("GT")]
	private void mGT()
	{
		int type = 0x40;
		int channel = 0;
		this.Match(0x3E);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000152 RID: 338 RVA: 0x000082C0 File Offset: 0x000064C0
	[global::Antlr.Runtime.GrammarRule("GTE")]
	private void mGTE()
	{
		int type = 0x41;
		int channel = 0;
		this.Match(">=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x000082FC File Offset: 0x000064FC
	[global::Antlr.Runtime.GrammarRule("IF")]
	private void mIF()
	{
		int type = 0x45;
		int channel = 0;
		this.Match("if");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00008338 File Offset: 0x00006538
	[global::Antlr.Runtime.GrammarRule("IMPLEMENTS")]
	private void mIMPLEMENTS()
	{
		int type = 0x46;
		int channel = 0;
		this.Match("implements");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000155 RID: 341 RVA: 0x00008374 File Offset: 0x00006574
	[global::Antlr.Runtime.GrammarRule("IMPORT")]
	private void mIMPORT()
	{
		int type = 0x47;
		int channel = 0;
		this.Match("import");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000156 RID: 342 RVA: 0x000083B0 File Offset: 0x000065B0
	[global::Antlr.Runtime.GrammarRule("IN")]
	private void mIN()
	{
		int type = 0x48;
		int channel = 0;
		this.Match("in");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x000083EC File Offset: 0x000065EC
	[global::Antlr.Runtime.GrammarRule("INC")]
	private void mINC()
	{
		int type = 0x49;
		int channel = 0;
		this.Match("++");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00008428 File Offset: 0x00006628
	[global::Antlr.Runtime.GrammarRule("INSTANCEOF")]
	private void mINSTANCEOF()
	{
		int type = 0x4A;
		int channel = 0;
		this.Match("instanceof");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00008464 File Offset: 0x00006664
	[global::Antlr.Runtime.GrammarRule("INT")]
	private void mINT()
	{
		int type = 0x4B;
		int channel = 0;
		this.Match("int");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x000084A0 File Offset: 0x000066A0
	[global::Antlr.Runtime.GrammarRule("INTERFACE")]
	private void mINTERFACE()
	{
		int type = 0x4C;
		int channel = 0;
		this.Match("interface");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x000084DC File Offset: 0x000066DC
	[global::Antlr.Runtime.GrammarRule("INV")]
	private void mINV()
	{
		int type = 0x4D;
		int channel = 0;
		this.Match(0x7E);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00008514 File Offset: 0x00006714
	[global::Antlr.Runtime.GrammarRule("LAND")]
	private void mLAND()
	{
		int type = 0x54;
		int channel = 0;
		this.Match("&&");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00008550 File Offset: 0x00006750
	[global::Antlr.Runtime.GrammarRule("LBRACE")]
	private void mLBRACE()
	{
		int type = 0x55;
		int channel = 0;
		this.Match(0x7B);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00008588 File Offset: 0x00006788
	[global::Antlr.Runtime.GrammarRule("LBRACK")]
	private void mLBRACK()
	{
		int type = 0x56;
		int channel = 0;
		this.Match(0x5B);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600015F RID: 351 RVA: 0x000085C0 File Offset: 0x000067C0
	[global::Antlr.Runtime.GrammarRule("LONG")]
	private void mLONG()
	{
		int type = 0x58;
		int channel = 0;
		this.Match("long");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x000085FC File Offset: 0x000067FC
	[global::Antlr.Runtime.GrammarRule("LOR")]
	private void mLOR()
	{
		int type = 0x59;
		int channel = 0;
		this.Match("||");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00008638 File Offset: 0x00006838
	[global::Antlr.Runtime.GrammarRule("LPAREN")]
	private void mLPAREN()
	{
		int type = 0x5A;
		int channel = 0;
		this.Match(0x28);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00008670 File Offset: 0x00006870
	[global::Antlr.Runtime.GrammarRule("LT")]
	private void mLT()
	{
		int type = 0x5C;
		int channel = 0;
		this.Match(0x3C);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x000086A8 File Offset: 0x000068A8
	[global::Antlr.Runtime.GrammarRule("LTE")]
	private void mLTE()
	{
		int type = 0x5D;
		int channel = 0;
		this.Match("<=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x000086E4 File Offset: 0x000068E4
	[global::Antlr.Runtime.GrammarRule("MOD")]
	private void mMOD()
	{
		int type = 0x5F;
		int channel = 0;
		this.Match(0x25);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0000871C File Offset: 0x0000691C
	[global::Antlr.Runtime.GrammarRule("MODASS")]
	private void mMODASS()
	{
		int type = 0x60;
		int channel = 0;
		this.Match("%=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000166 RID: 358 RVA: 0x00008758 File Offset: 0x00006958
	[global::Antlr.Runtime.GrammarRule("MUL")]
	private void mMUL()
	{
		int type = 0x61;
		int channel = 0;
		this.Match(0x2A);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00008790 File Offset: 0x00006990
	[global::Antlr.Runtime.GrammarRule("MULASS")]
	private void mMULASS()
	{
		int type = 0x62;
		int channel = 0;
		this.Match("*=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x000087CC File Offset: 0x000069CC
	[global::Antlr.Runtime.GrammarRule("NATIVE")]
	private void mNATIVE()
	{
		int type = 0x65;
		int channel = 0;
		this.Match("native");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00008808 File Offset: 0x00006A08
	[global::Antlr.Runtime.GrammarRule("NEQ")]
	private void mNEQ()
	{
		int type = 0x68;
		int channel = 0;
		this.Match("!=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00008844 File Offset: 0x00006A44
	[global::Antlr.Runtime.GrammarRule("NEW")]
	private void mNEW()
	{
		int type = 0x69;
		int channel = 0;
		this.Match("new");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00008880 File Offset: 0x00006A80
	[global::Antlr.Runtime.GrammarRule("NOT")]
	private void mNOT()
	{
		int type = 0x6A;
		int channel = 0;
		this.Match(0x21);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x000088B8 File Offset: 0x00006AB8
	[global::Antlr.Runtime.GrammarRule("NSAME")]
	private void mNSAME()
	{
		int type = 0x6B;
		int channel = 0;
		this.Match("!==");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600016D RID: 365 RVA: 0x000088F4 File Offset: 0x00006AF4
	[global::Antlr.Runtime.GrammarRule("NULL")]
	private void mNULL()
	{
		int type = 0x6C;
		int channel = 0;
		this.Match("null");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00008930 File Offset: 0x00006B30
	[global::Antlr.Runtime.GrammarRule("OR")]
	private void mOR()
	{
		int type = 0x6E;
		int channel = 0;
		this.Match(0x7C);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00008968 File Offset: 0x00006B68
	[global::Antlr.Runtime.GrammarRule("ORASS")]
	private void mORASS()
	{
		int type = 0x6F;
		int channel = 0;
		this.Match("|=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x000089A4 File Offset: 0x00006BA4
	[global::Antlr.Runtime.GrammarRule("PACKAGE")]
	private void mPACKAGE()
	{
		int type = 0x73;
		int channel = 0;
		this.Match("package");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000171 RID: 369 RVA: 0x000089E0 File Offset: 0x00006BE0
	[global::Antlr.Runtime.GrammarRule("PRIVATE")]
	private void mPRIVATE()
	{
		int type = 0x78;
		int channel = 0;
		this.Match("private");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000172 RID: 370 RVA: 0x00008A1C File Offset: 0x00006C1C
	[global::Antlr.Runtime.GrammarRule("PROTECTED")]
	private void mPROTECTED()
	{
		int type = 0x79;
		int channel = 0;
		this.Match("protected");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00008A58 File Offset: 0x00006C58
	[global::Antlr.Runtime.GrammarRule("PUBLIC")]
	private void mPUBLIC()
	{
		int type = 0x7B;
		int channel = 0;
		this.Match("public");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00008A94 File Offset: 0x00006C94
	[global::Antlr.Runtime.GrammarRule("QUE")]
	private void mQUE()
	{
		int type = 0x7C;
		int channel = 0;
		this.Match(0x3F);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00008ACC File Offset: 0x00006CCC
	[global::Antlr.Runtime.GrammarRule("RBRACE")]
	private void mRBRACE()
	{
		int type = 0x7D;
		int channel = 0;
		this.Match(0x7D);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00008B04 File Offset: 0x00006D04
	[global::Antlr.Runtime.GrammarRule("RBRACK")]
	private void mRBRACK()
	{
		int type = 0x7E;
		int channel = 0;
		this.Match(0x5D);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00008B3C File Offset: 0x00006D3C
	[global::Antlr.Runtime.GrammarRule("RETURN")]
	private void mRETURN()
	{
		int type = 0x7F;
		int channel = 0;
		this.Match("return");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00008B78 File Offset: 0x00006D78
	[global::Antlr.Runtime.GrammarRule("RPAREN")]
	private void mRPAREN()
	{
		int type = 0x80;
		int channel = 0;
		this.Match(0x29);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00008BB4 File Offset: 0x00006DB4
	[global::Antlr.Runtime.GrammarRule("SAME")]
	private void mSAME()
	{
		int type = 0x84;
		int channel = 0;
		this.Match("===");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00008BF0 File Offset: 0x00006DF0
	[global::Antlr.Runtime.GrammarRule("SEMIC")]
	private void mSEMIC()
	{
		int type = 0x85;
		int channel = 0;
		this.Match(0x3B);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00008C2C File Offset: 0x00006E2C
	[global::Antlr.Runtime.GrammarRule("SHL")]
	private void mSHL()
	{
		int type = 0x86;
		int channel = 0;
		this.Match("<<");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00008C68 File Offset: 0x00006E68
	[global::Antlr.Runtime.GrammarRule("SHLASS")]
	private void mSHLASS()
	{
		int type = 0x87;
		int channel = 0;
		this.Match("<<=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00008CA4 File Offset: 0x00006EA4
	[global::Antlr.Runtime.GrammarRule("SHORT")]
	private void mSHORT()
	{
		int type = 0x88;
		int channel = 0;
		this.Match("short");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00008CE0 File Offset: 0x00006EE0
	[global::Antlr.Runtime.GrammarRule("SHR")]
	private void mSHR()
	{
		int type = 0x89;
		int channel = 0;
		this.Match(">>");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00008D1C File Offset: 0x00006F1C
	[global::Antlr.Runtime.GrammarRule("SHRASS")]
	private void mSHRASS()
	{
		int type = 0x8A;
		int channel = 0;
		this.Match(">>=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00008D58 File Offset: 0x00006F58
	[global::Antlr.Runtime.GrammarRule("SHU")]
	private void mSHU()
	{
		int type = 0x8B;
		int channel = 0;
		this.Match(">>>");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00008D94 File Offset: 0x00006F94
	[global::Antlr.Runtime.GrammarRule("SHUASS")]
	private void mSHUASS()
	{
		int type = 0x8C;
		int channel = 0;
		this.Match(">>>=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00008DD0 File Offset: 0x00006FD0
	[global::Antlr.Runtime.GrammarRule("STATIC")]
	private void mSTATIC()
	{
		int type = 0x8F;
		int channel = 0;
		this.Match("static");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00008E0C File Offset: 0x0000700C
	[global::Antlr.Runtime.GrammarRule("SUB")]
	private void mSUB()
	{
		int type = 0x90;
		int channel = 0;
		this.Match(0x2D);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00008E48 File Offset: 0x00007048
	[global::Antlr.Runtime.GrammarRule("SUBASS")]
	private void mSUBASS()
	{
		int type = 0x91;
		int channel = 0;
		this.Match("-=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00008E84 File Offset: 0x00007084
	[global::Antlr.Runtime.GrammarRule("SUPER")]
	private void mSUPER()
	{
		int type = 0x92;
		int channel = 0;
		this.Match("super");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00008EC0 File Offset: 0x000070C0
	[global::Antlr.Runtime.GrammarRule("SWITCH")]
	private void mSWITCH()
	{
		int type = 0x93;
		int channel = 0;
		this.Match("switch");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00008EFC File Offset: 0x000070FC
	[global::Antlr.Runtime.GrammarRule("SYNCHRONIZED")]
	private void mSYNCHRONIZED()
	{
		int type = 0x94;
		int channel = 0;
		this.Match("synchronized");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00008F38 File Offset: 0x00007138
	[global::Antlr.Runtime.GrammarRule("THIS")]
	private void mTHIS()
	{
		int type = 0x98;
		int channel = 0;
		this.Match("this");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00008F74 File Offset: 0x00007174
	[global::Antlr.Runtime.GrammarRule("THROW")]
	private void mTHROW()
	{
		int type = 0x99;
		int channel = 0;
		this.Match("throw");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00008FB0 File Offset: 0x000071B0
	[global::Antlr.Runtime.GrammarRule("THROWS")]
	private void mTHROWS()
	{
		int type = 0x9A;
		int channel = 0;
		this.Match("throws");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00008FEC File Offset: 0x000071EC
	[global::Antlr.Runtime.GrammarRule("TRANSIENT")]
	private void mTRANSIENT()
	{
		int type = 0x9B;
		int channel = 0;
		this.Match("transient");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00009028 File Offset: 0x00007228
	[global::Antlr.Runtime.GrammarRule("TRUE")]
	private void mTRUE()
	{
		int type = 0x9C;
		int channel = 0;
		this.Match("true");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00009064 File Offset: 0x00007264
	[global::Antlr.Runtime.GrammarRule("TRY")]
	private void mTRY()
	{
		int type = 0x9D;
		int channel = 0;
		this.Match("try");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x000090A0 File Offset: 0x000072A0
	[global::Antlr.Runtime.GrammarRule("TYPEOF")]
	private void mTYPEOF()
	{
		int type = 0x9E;
		int channel = 0;
		this.Match("typeof");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x000090DC File Offset: 0x000072DC
	[global::Antlr.Runtime.GrammarRule("VAR")]
	private void mVAR()
	{
		int type = 0xA1;
		int channel = 0;
		this.Match("var");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00009118 File Offset: 0x00007318
	[global::Antlr.Runtime.GrammarRule("VOID")]
	private void mVOID()
	{
		int type = 0xA2;
		int channel = 0;
		this.Match("void");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00009154 File Offset: 0x00007354
	[global::Antlr.Runtime.GrammarRule("VOLATILE")]
	private void mVOLATILE()
	{
		int type = 0xA3;
		int channel = 0;
		this.Match("volatile");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00009190 File Offset: 0x00007390
	[global::Antlr.Runtime.GrammarRule("WHILE")]
	private void mWHILE()
	{
		int type = 0xA5;
		int channel = 0;
		this.Match("while");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000193 RID: 403 RVA: 0x000091CC File Offset: 0x000073CC
	[global::Antlr.Runtime.GrammarRule("WITH")]
	private void mWITH()
	{
		int type = 0xA6;
		int channel = 0;
		this.Match("with");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00009208 File Offset: 0x00007408
	[global::Antlr.Runtime.GrammarRule("XOR")]
	private void mXOR()
	{
		int type = 0xA8;
		int channel = 0;
		this.Match(0x5E);
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00009244 File Offset: 0x00007444
	[global::Antlr.Runtime.GrammarRule("XORASS")]
	private void mXORASS()
	{
		int type = 0xA9;
		int channel = 0;
		this.Match("^=");
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x06000196 RID: 406 RVA: 0x00009280 File Offset: 0x00007480
	[global::Antlr.Runtime.GrammarRule("BSLASH")]
	private void mBSLASH()
	{
		this.Match(0x5C);
	}

	// Token: 0x06000197 RID: 407 RVA: 0x0000928C File Offset: 0x0000748C
	[global::Antlr.Runtime.GrammarRule("DQUOTE")]
	private void mDQUOTE()
	{
		this.Match(0x22);
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00009298 File Offset: 0x00007498
	[global::Antlr.Runtime.GrammarRule("SQUOTE")]
	private void mSQUOTE()
	{
		this.Match(0x27);
	}

	// Token: 0x06000199 RID: 409 RVA: 0x000092A4 File Offset: 0x000074A4
	[global::Antlr.Runtime.GrammarRule("TAB")]
	private void mTAB()
	{
		this.Match(9);
	}

	// Token: 0x0600019A RID: 410 RVA: 0x000092B0 File Offset: 0x000074B0
	[global::Antlr.Runtime.GrammarRule("VT")]
	private void mVT()
	{
		this.Match(0xB);
	}

	// Token: 0x0600019B RID: 411 RVA: 0x000092BC File Offset: 0x000074BC
	[global::Antlr.Runtime.GrammarRule("FF")]
	private void mFF()
	{
		this.Match(0xC);
	}

	// Token: 0x0600019C RID: 412 RVA: 0x000092C8 File Offset: 0x000074C8
	[global::Antlr.Runtime.GrammarRule("SP")]
	private void mSP()
	{
		this.Match(0x20);
	}

	// Token: 0x0600019D RID: 413 RVA: 0x000092D4 File Offset: 0x000074D4
	[global::Antlr.Runtime.GrammarRule("NBSP")]
	private void mNBSP()
	{
		this.Match(0xA0);
	}

	// Token: 0x0600019E RID: 414 RVA: 0x000092E4 File Offset: 0x000074E4
	[global::Antlr.Runtime.GrammarRule("USP")]
	private void mUSP()
	{
		if (this.input.LA(1) == 0x1680 || this.input.LA(1) == 0x180E || (this.input.LA(1) >= 0x2000 && this.input.LA(1) <= 0x200A) || this.input.LA(1) == 0x202F || this.input.LA(1) == 0x205F || this.input.LA(1) == 0x3000)
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x0600019F RID: 415 RVA: 0x000093B8 File Offset: 0x000075B8
	[global::Antlr.Runtime.GrammarRule("WhiteSpace")]
	private void mWhiteSpace()
	{
		int type = 0xA7;
		int num = 0;
		for (;;)
		{
			int num2 = 2;
			int num3 = this.input.LA(1);
			if (num3 == 9 || (num3 >= 0xB && num3 <= 0xC) || (num3 == 0x20 || num3 == 0xA0 || num3 == 0x1680 || num3 == 0x180E || (num3 >= 0x2000 && num3 <= 0x200A)) || num3 == 0x202F || num3 == 0x205F || num3 == 0x3000)
			{
				num2 = 1;
			}
			int num4 = num2;
			if (num4 != 1)
			{
				break;
			}
			this.input.Consume();
			num++;
		}
		if (num < 1)
		{
			global::Antlr.Runtime.EarlyExitException ex = new global::Antlr.Runtime.EarlyExitException(1, this.input);
			throw ex;
		}
		int channel = 0x63;
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x000094C0 File Offset: 0x000076C0
	[global::Antlr.Runtime.GrammarRule("LF")]
	private void mLF()
	{
		this.Match(0xA);
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x000094CC File Offset: 0x000076CC
	[global::Antlr.Runtime.GrammarRule("CR")]
	private void mCR()
	{
		this.Match(0xD);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x000094D8 File Offset: 0x000076D8
	[global::Antlr.Runtime.GrammarRule("LS")]
	private void mLS()
	{
		this.Match(0x2028);
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x000094E8 File Offset: 0x000076E8
	[global::Antlr.Runtime.GrammarRule("PS")]
	private void mPS()
	{
		this.Match(0x2029);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x000094F8 File Offset: 0x000076F8
	[global::Antlr.Runtime.GrammarRule("LineTerminator")]
	private void mLineTerminator()
	{
		if (this.input.LA(1) == 0xA || this.input.LA(1) == 0xD || (this.input.LA(1) >= 0x2028 && this.input.LA(1) <= 0x2029))
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00009584 File Offset: 0x00007784
	[global::Antlr.Runtime.GrammarRule("EOL")]
	private void mEOL()
	{
		int type = 0x2F;
		int num = this.input.LA(1);
		int num2;
		if (num != 0xA)
		{
			if (num != 0xD)
			{
				switch (num)
				{
				case 0x2028:
					num2 = 3;
					break;
				case 0x2029:
					num2 = 4;
					break;
				default:
				{
					global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 2, 0, this.input);
					throw ex;
				}
				}
			}
			else
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = 2;
		}
		switch (num2)
		{
		case 1:
			this.mCR();
			this.mLF();
			break;
		case 2:
			this.mLF();
			break;
		case 3:
			this.mLS();
			break;
		case 4:
			this.mPS();
			break;
		}
		int channel = 0x63;
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00009670 File Offset: 0x00007870
	[global::Antlr.Runtime.GrammarRule("MultiLineComment")]
	private void mMultiLineComment()
	{
		int type = 0x63;
		this.Match("/*");
		for (;;)
		{
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x2A)
			{
				int num3 = this.input.LA(2);
				if (num3 == 0x2F)
				{
					num = 2;
				}
				else if ((num3 >= 0 && num3 <= 0x2E) || (num3 >= 0x30 && num3 <= 0xFFFF))
				{
					num = 1;
				}
			}
			else if ((num2 >= 0 && num2 <= 0x29) || (num2 >= 0x2B && num2 <= 0xFFFF))
			{
				num = 1;
			}
			int num4 = num;
			if (num4 != 1)
			{
				break;
			}
			this.MatchAny();
		}
		this.Match("*/");
		int channel = 0x63;
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00009754 File Offset: 0x00007954
	[global::Antlr.Runtime.GrammarRule("SingleLineComment")]
	private void mSingleLineComment()
	{
		int type = 0x95;
		this.Match("//");
		for (;;)
		{
			int num = 2;
			int num2 = this.input.LA(1);
			if ((num2 >= 0 && num2 <= 9) || (num2 >= 0xB && num2 <= 0xC) || (num2 >= 0xE && num2 <= 0x2027) || (num2 >= 0x202A && num2 <= 0xFFFF))
			{
				num = 1;
			}
			int num3 = num;
			if (num3 != 1)
			{
				break;
			}
			this.input.Consume();
		}
		int channel = 0x63;
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00009804 File Offset: 0x00007A04
	[global::Antlr.Runtime.GrammarRule("IdentifierStartASCII")]
	private void mIdentifierStartASCII()
	{
		int num;
		switch (this.input.LA(1))
		{
		case 0x24:
			num = 3;
			goto IL_1B1;
		case 0x41:
		case 0x42:
		case 0x43:
		case 0x44:
		case 0x45:
		case 0x46:
		case 0x47:
		case 0x48:
		case 0x49:
		case 0x4A:
		case 0x4B:
		case 0x4C:
		case 0x4D:
		case 0x4E:
		case 0x4F:
		case 0x50:
		case 0x51:
		case 0x52:
		case 0x53:
		case 0x54:
		case 0x55:
		case 0x56:
		case 0x57:
		case 0x58:
		case 0x59:
		case 0x5A:
			num = 2;
			goto IL_1B1;
		case 0x5C:
			num = 5;
			goto IL_1B1;
		case 0x5F:
			num = 4;
			goto IL_1B1;
		case 0x61:
		case 0x62:
		case 0x63:
		case 0x64:
		case 0x65:
		case 0x66:
		case 0x67:
		case 0x68:
		case 0x69:
		case 0x6A:
		case 0x6B:
		case 0x6C:
		case 0x6D:
		case 0x6E:
		case 0x6F:
		case 0x70:
		case 0x71:
		case 0x72:
		case 0x73:
		case 0x74:
		case 0x75:
		case 0x76:
		case 0x77:
		case 0x78:
		case 0x79:
		case 0x7A:
			num = 1;
			goto IL_1B1;
		}
		global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 5, 0, this.input);
		throw ex;
		IL_1B1:
		switch (num)
		{
		case 1:
			this.MatchRange(0x61, 0x7A);
			break;
		case 2:
			this.MatchRange(0x41, 0x5A);
			break;
		case 3:
			this.Match(0x24);
			break;
		case 4:
			this.Match(0x5F);
			break;
		case 5:
			this.mBSLASH();
			this.Match(0x75);
			this.mHexDigit();
			this.mHexDigit();
			this.mHexDigit();
			this.mHexDigit();
			break;
		}
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00009A48 File Offset: 0x00007C48
	[global::Antlr.Runtime.GrammarRule("IdentifierPart")]
	private void mIdentifierPart()
	{
		int num;
		switch (this.input.LA(1))
		{
		case 0x24:
		case 0x41:
		case 0x42:
		case 0x43:
		case 0x44:
		case 0x45:
		case 0x46:
		case 0x47:
		case 0x48:
		case 0x49:
		case 0x4A:
		case 0x4B:
		case 0x4C:
		case 0x4D:
		case 0x4E:
		case 0x4F:
		case 0x50:
		case 0x51:
		case 0x52:
		case 0x53:
		case 0x54:
		case 0x55:
		case 0x56:
		case 0x57:
		case 0x58:
		case 0x59:
		case 0x5A:
		case 0x5C:
		case 0x5F:
		case 0x61:
		case 0x62:
		case 0x63:
		case 0x64:
		case 0x65:
		case 0x66:
		case 0x67:
		case 0x68:
		case 0x69:
		case 0x6A:
		case 0x6B:
		case 0x6C:
		case 0x6D:
		case 0x6E:
		case 0x6F:
		case 0x70:
		case 0x71:
		case 0x72:
		case 0x73:
		case 0x74:
		case 0x75:
		case 0x76:
		case 0x77:
		case 0x78:
		case 0x79:
		case 0x7A:
			num = 2;
			goto IL_189;
		case 0x30:
		case 0x31:
		case 0x32:
		case 0x33:
		case 0x34:
		case 0x35:
		case 0x36:
		case 0x37:
		case 0x38:
		case 0x39:
			num = 1;
			goto IL_189;
		}
		num = 3;
		IL_189:
		switch (num)
		{
		case 1:
			this.mDecimalDigit();
			break;
		case 2:
			this.mIdentifierStartASCII();
			break;
		case 3:
			if (!this.IsIdentifierPartUnicode(this.input.LA(1)))
			{
				throw new global::Antlr.Runtime.FailedPredicateException(this.input, "IdentifierPart", " IsIdentifierPartUnicode(input.LA(1)) ");
			}
			this.MatchAny();
			break;
		}
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00009C48 File Offset: 0x00007E48
	[global::Antlr.Runtime.GrammarRule("IdentifierNameASCIIStart")]
	private void mIdentifierNameASCIIStart()
	{
		this.mIdentifierStartASCII();
		for (;;)
		{
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 0x24 || (num2 >= 0x30 && num2 <= 0x39) || (num2 >= 0x41 && num2 <= 0x5A) || num2 == 0x5C || num2 == 0x5F || (num2 >= 0x61 && num2 <= 0x7A))
			{
				num = 1;
			}
			else if (this.IsIdentifierPartUnicode(this.input.LA(1)))
			{
				num = 1;
			}
			int num3 = num;
			if (num3 != 1)
			{
				break;
			}
			this.mIdentifierPart();
		}
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00009CEC File Offset: 0x00007EEC
	[global::Antlr.Runtime.GrammarRule("Identifier")]
	private void mIdentifier()
	{
		int type = 0x4F;
		int channel = 0;
		int num = this.input.LA(1);
		int num2;
		if (num == 0x24 || (num >= 0x41 && num <= 0x5A) || num == 0x5C || num == 0x5F || (num >= 0x61 && num <= 0x7A))
		{
			num2 = 1;
		}
		else
		{
			num2 = 2;
		}
		switch (num2)
		{
		case 1:
			this.mIdentifierNameASCIIStart();
			break;
		case 2:
			this.ConsumeIdentifierUnicodeStart();
			break;
		}
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001AC RID: 428 RVA: 0x00009D94 File Offset: 0x00007F94
	[global::Antlr.Runtime.GrammarRule("DecimalDigit")]
	private void mDecimalDigit()
	{
		if (this.input.LA(1) >= 0x30 && this.input.LA(1) <= 0x39)
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00009DF4 File Offset: 0x00007FF4
	[global::Antlr.Runtime.GrammarRule("HexDigit")]
	private void mHexDigit()
	{
		if ((this.input.LA(1) >= 0x30 && this.input.LA(1) <= 0x39) || (this.input.LA(1) >= 0x41 && this.input.LA(1) <= 0x46) || (this.input.LA(1) >= 0x61 && this.input.LA(1) <= 0x66))
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00009EA0 File Offset: 0x000080A0
	[global::Antlr.Runtime.GrammarRule("OctalDigit")]
	private void mOctalDigit()
	{
		if (this.input.LA(1) >= 0x30 && this.input.LA(1) <= 0x37)
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00009F00 File Offset: 0x00008100
	[global::Antlr.Runtime.GrammarRule("ExponentPart")]
	private void mExponentPart()
	{
		if (this.input.LA(1) != 0x45 && this.input.LA(1) != 0x65)
		{
			global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
		}
		this.input.Consume();
		int num = 2;
		int num2 = this.input.LA(1);
		if (num2 == 0x2B || num2 == 0x2D)
		{
			num = 1;
		}
		int num3 = num;
		if (num3 == 1)
		{
			this.input.Consume();
		}
		int num4 = 0;
		for (;;)
		{
			int num5 = 2;
			int num6 = this.input.LA(1);
			if (num6 >= 0x30 && num6 <= 0x39)
			{
				num5 = 1;
			}
			int num7 = num5;
			if (num7 != 1)
			{
				break;
			}
			this.input.Consume();
			num4++;
		}
		if (num4 < 1)
		{
			global::Antlr.Runtime.EarlyExitException ex2 = new global::Antlr.Runtime.EarlyExitException(0xA, this.input);
			throw ex2;
		}
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00009FFC File Offset: 0x000081FC
	[global::Antlr.Runtime.GrammarRule("DecimalIntegerLiteral")]
	private void mDecimalIntegerLiteral()
	{
		int num = this.input.LA(1);
		int num2;
		if (num == 0x30)
		{
			num2 = 1;
		}
		else
		{
			if (num < 0x31 || num > 0x39)
			{
				global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0xC, 0, this.input);
				throw ex;
			}
			num2 = 2;
		}
		switch (num2)
		{
		case 1:
			this.Match(0x30);
			break;
		case 2:
			this.MatchRange(0x31, 0x39);
			for (;;)
			{
				int num3 = 2;
				int num4 = this.input.LA(1);
				if (num4 >= 0x30 && num4 <= 0x39)
				{
					num3 = 1;
				}
				int num5 = num3;
				if (num5 != 1)
				{
					break;
				}
				this.input.Consume();
			}
			break;
		}
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0000A0C8 File Offset: 0x000082C8
	[global::Antlr.Runtime.GrammarRule("DecimalLiteral")]
	private void mDecimalLiteral()
	{
		int type = 0x2C;
		int channel = 0;
		int num = 3;
		try
		{
			num = this.dfa18.Predict(this.input);
		}
		catch (global::Antlr.Runtime.NoViableAltException)
		{
			throw;
		}
		switch (num)
		{
		case 1:
		{
			this.mDecimalIntegerLiteral();
			this.Match(0x2E);
			for (;;)
			{
				int num2 = 2;
				int num3 = this.input.LA(1);
				if (num3 >= 0x30 && num3 <= 0x39)
				{
					num2 = 1;
				}
				int num4 = num2;
				if (num4 != 1)
				{
					break;
				}
				this.input.Consume();
			}
			int num5 = 2;
			int num6 = this.input.LA(1);
			if (num6 == 0x45 || num6 == 0x65)
			{
				num5 = 1;
			}
			int num7 = num5;
			if (num7 == 1)
			{
				this.mExponentPart();
			}
			break;
		}
		case 2:
		{
			this.Match(0x2E);
			int num8 = 0;
			for (;;)
			{
				int num9 = 2;
				int num10 = this.input.LA(1);
				if (num10 >= 0x30 && num10 <= 0x39)
				{
					num9 = 1;
				}
				int num11 = num9;
				if (num11 != 1)
				{
					break;
				}
				this.input.Consume();
				num8++;
			}
			if (num8 < 1)
			{
				global::Antlr.Runtime.EarlyExitException ex = new global::Antlr.Runtime.EarlyExitException(0xF, this.input);
				throw ex;
			}
			int num12 = 2;
			int num13 = this.input.LA(1);
			if (num13 == 0x45 || num13 == 0x65)
			{
				num12 = 1;
			}
			int num14 = num12;
			if (num14 == 1)
			{
				this.mExponentPart();
			}
			break;
		}
		case 3:
		{
			this.mDecimalIntegerLiteral();
			int num15 = 2;
			int num16 = this.input.LA(1);
			if (num16 == 0x45 || num16 == 0x65)
			{
				num15 = 1;
			}
			int num17 = num15;
			if (num17 == 1)
			{
				this.mExponentPart();
			}
			break;
		}
		}
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x0000A2B0 File Offset: 0x000084B0
	[global::Antlr.Runtime.GrammarRule("OctalIntegerLiteral")]
	private void mOctalIntegerLiteral()
	{
		int type = 0x72;
		int channel = 0;
		this.Match(0x30);
		int num = 0;
		for (;;)
		{
			int num2 = 2;
			int num3 = this.input.LA(1);
			if (num3 >= 0x30 && num3 <= 0x37)
			{
				num2 = 1;
			}
			int num4 = num2;
			if (num4 != 1)
			{
				break;
			}
			this.input.Consume();
			num++;
		}
		if (num < 1)
		{
			global::Antlr.Runtime.EarlyExitException ex = new global::Antlr.Runtime.EarlyExitException(0x13, this.input);
			throw ex;
		}
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0000A348 File Offset: 0x00008548
	[global::Antlr.Runtime.GrammarRule("HexIntegerLiteral")]
	private void mHexIntegerLiteral()
	{
		int type = 0x44;
		int channel = 0;
		int num = this.input.LA(1);
		if (num != 0x30)
		{
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x14, 0, this.input);
			throw ex;
		}
		int num2 = this.input.LA(2);
		int num3;
		if (num2 == 0x78)
		{
			num3 = 1;
		}
		else
		{
			if (num2 != 0x58)
			{
				global::Antlr.Runtime.NoViableAltException ex2 = new global::Antlr.Runtime.NoViableAltException("", 0x14, 1, this.input);
				throw ex2;
			}
			num3 = 2;
		}
		switch (num3)
		{
		case 1:
			this.Match("0x");
			break;
		case 2:
			this.Match("0X");
			break;
		}
		int num4 = 0;
		for (;;)
		{
			int num5 = 2;
			int num6 = this.input.LA(1);
			if ((num6 >= 0x30 && num6 <= 0x39) || (num6 >= 0x41 && num6 <= 0x46) || (num6 >= 0x61 && num6 <= 0x66))
			{
				num5 = 1;
			}
			int num7 = num5;
			if (num7 != 1)
			{
				break;
			}
			this.input.Consume();
			num4++;
		}
		if (num4 < 1)
		{
			global::Antlr.Runtime.EarlyExitException ex3 = new global::Antlr.Runtime.EarlyExitException(0x15, this.input);
			throw ex3;
		}
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x0000A4B0 File Offset: 0x000086B0
	[global::Antlr.Runtime.GrammarRule("CharacterEscapeSequence")]
	private void mCharacterEscapeSequence()
	{
		if ((this.input.LA(1) >= 0 && this.input.LA(1) <= 9) || (this.input.LA(1) >= 0xB && this.input.LA(1) <= 0xC) || (this.input.LA(1) >= 0xE && this.input.LA(1) <= 0x2F) || (this.input.LA(1) >= 0x3A && this.input.LA(1) <= 0x74) || (this.input.LA(1) >= 0x76 && this.input.LA(1) <= 0x77) || (this.input.LA(1) >= 0x79 && this.input.LA(1) <= 0x2027) || (this.input.LA(1) >= 0x202A && this.input.LA(1) <= 0xFFFF))
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0000A5FC File Offset: 0x000087FC
	[global::Antlr.Runtime.GrammarRule("ZeroToThree")]
	private void mZeroToThree()
	{
		if (this.input.LA(1) >= 0x30 && this.input.LA(1) <= 0x33)
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0000A65C File Offset: 0x0000885C
	[global::Antlr.Runtime.GrammarRule("OctalEscapeSequence")]
	private void mOctalEscapeSequence()
	{
		int num = this.input.LA(1);
		int num4;
		if (num >= 0x30 && num <= 0x33)
		{
			int num2 = this.input.LA(2);
			if (num2 >= 0x30 && num2 <= 0x37)
			{
				int num3 = this.input.LA(3);
				if (num3 >= 0x30 && num3 <= 0x37)
				{
					num4 = 4;
				}
				else
				{
					num4 = 2;
				}
			}
			else
			{
				num4 = 1;
			}
		}
		else
		{
			if (num < 0x34 || num > 0x37)
			{
				global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x16, 0, this.input);
				throw ex;
			}
			int num5 = this.input.LA(2);
			if (num5 >= 0x30 && num5 <= 0x37)
			{
				num4 = 3;
			}
			else
			{
				num4 = 1;
			}
		}
		switch (num4)
		{
		case 1:
			this.mOctalDigit();
			break;
		case 2:
			this.mZeroToThree();
			this.mOctalDigit();
			break;
		case 3:
			this.MatchRange(0x34, 0x37);
			this.mOctalDigit();
			break;
		case 4:
			this.mZeroToThree();
			this.mOctalDigit();
			this.mOctalDigit();
			break;
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0000A798 File Offset: 0x00008998
	[global::Antlr.Runtime.GrammarRule("HexEscapeSequence")]
	private void mHexEscapeSequence()
	{
		this.Match(0x78);
		this.mHexDigit();
		this.mHexDigit();
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0000A7B0 File Offset: 0x000089B0
	[global::Antlr.Runtime.GrammarRule("UnicodeEscapeSequence")]
	private void mUnicodeEscapeSequence()
	{
		this.Match(0x75);
		this.mHexDigit();
		this.mHexDigit();
		this.mHexDigit();
		this.mHexDigit();
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0000A7E4 File Offset: 0x000089E4
	[global::Antlr.Runtime.GrammarRule("EscapeSequence")]
	private void mEscapeSequence()
	{
		this.mBSLASH();
		int num = this.input.LA(1);
		int num2;
		if ((num >= 0 && num <= 9) || (num >= 0xB && num <= 0xC) || (num >= 0xE && num <= 0x2F) || (num >= 0x3A && num <= 0x74) || (num >= 0x76 && num <= 0x77) || (num >= 0x79 && num <= 0x2027) || (num >= 0x202A && num <= 0xFFFF))
		{
			num2 = 1;
		}
		else if (num >= 0x30 && num <= 0x37)
		{
			num2 = 2;
		}
		else if (num == 0x78)
		{
			num2 = 3;
		}
		else if (num == 0x75)
		{
			num2 = 4;
		}
		else
		{
			if (num != 0xA && num != 0xD)
			{
				global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x18, 0, this.input);
				throw ex;
			}
			num2 = 5;
		}
		switch (num2)
		{
		case 1:
			this.mCharacterEscapeSequence();
			break;
		case 2:
			this.mOctalEscapeSequence();
			break;
		case 3:
			this.mHexEscapeSequence();
			break;
		case 4:
			this.mUnicodeEscapeSequence();
			break;
		case 5:
		{
			int num3 = 2;
			int num4 = this.input.LA(1);
			if (num4 == 0xD)
			{
				num3 = 1;
			}
			int num5 = num3;
			if (num5 == 1)
			{
				this.input.Consume();
			}
			this.mLF();
			break;
		}
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0000A974 File Offset: 0x00008B74
	[global::Antlr.Runtime.GrammarRule("StringLiteral")]
	private void mStringLiteral()
	{
		int type = 0x96;
		int channel = 0;
		int num = this.input.LA(1);
		int num2;
		if (num == 0x27)
		{
			num2 = 1;
		}
		else
		{
			if (num != 0x22)
			{
				global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x1B, 0, this.input);
				throw ex;
			}
			num2 = 2;
		}
		switch (num2)
		{
		case 1:
			this.mSQUOTE();
			for (;;)
			{
				int num3 = 3;
				int num4 = this.input.LA(1);
				if ((num4 >= 0 && num4 <= 9) || (num4 >= 0xB && num4 <= 0xC) || (num4 >= 0xE && num4 <= 0x26) || (num4 >= 0x28 && num4 <= 0x5B) || (num4 >= 0x5D && num4 <= 0x2027) || (num4 >= 0x202A && num4 <= 0xFFFF))
				{
					num3 = 1;
				}
				else if (num4 == 0x5C)
				{
					num3 = 2;
				}
				switch (num3)
				{
				case 1:
					this.input.Consume();
					continue;
				case 2:
					this.mEscapeSequence();
					continue;
				}
				break;
			}
			this.mSQUOTE();
			break;
		case 2:
			this.mDQUOTE();
			for (;;)
			{
				int num5 = 3;
				int num6 = this.input.LA(1);
				if ((num6 >= 0 && num6 <= 9) || (num6 >= 0xB && num6 <= 0xC) || (num6 >= 0xE && num6 <= 0x21) || (num6 >= 0x23 && num6 <= 0x5B) || (num6 >= 0x5D && num6 <= 0x2027) || (num6 >= 0x202A && num6 <= 0xFFFF))
				{
					num5 = 1;
				}
				else if (num6 == 0x5C)
				{
					num5 = 2;
				}
				switch (num5)
				{
				case 1:
					this.input.Consume();
					continue;
				case 2:
					this.mEscapeSequence();
					continue;
				}
				break;
			}
			this.mDQUOTE();
			break;
		}
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0000ABBC File Offset: 0x00008DBC
	[global::Antlr.Runtime.GrammarRule("BackslashSequence")]
	private void mBackslashSequence()
	{
		this.mBSLASH();
		if ((this.input.LA(1) >= 0 && this.input.LA(1) <= 9) || (this.input.LA(1) >= 0xB && this.input.LA(1) <= 0xC) || (this.input.LA(1) >= 0xE && this.input.LA(1) <= 0x2027) || (this.input.LA(1) >= 0x202A && this.input.LA(1) <= 0xFFFF))
		{
			this.input.Consume();
			return;
		}
		global::Antlr.Runtime.MismatchedSetException ex = new global::Antlr.Runtime.MismatchedSetException(null, this.input);
		this.Recover(ex);
		throw ex;
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0000AC9C File Offset: 0x00008E9C
	[global::Antlr.Runtime.GrammarRule("RegularExpressionFirstChar")]
	private void mRegularExpressionFirstChar()
	{
		int num = this.input.LA(1);
		int num2;
		if ((num >= 0 && num <= 9) || (num >= 0xB && num <= 0xC) || (num >= 0xE && num <= 0x29) || (num >= 0x2B && num <= 0x2E) || (num >= 0x30 && num <= 0x5B) || (num >= 0x5D && num <= 0x2027) || (num >= 0x202A && num <= 0xFFFF))
		{
			num2 = 1;
		}
		else
		{
			if (num != 0x5C)
			{
				global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x1C, 0, this.input);
				throw ex;
			}
			num2 = 2;
		}
		switch (num2)
		{
		case 1:
			this.input.Consume();
			break;
		case 2:
			this.mBackslashSequence();
			break;
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0000AD90 File Offset: 0x00008F90
	[global::Antlr.Runtime.GrammarRule("RegularExpressionChar")]
	private void mRegularExpressionChar()
	{
		int num = this.input.LA(1);
		int num2;
		if ((num >= 0 && num <= 9) || (num >= 0xB && num <= 0xC) || (num >= 0xE && num <= 0x2E) || (num >= 0x30 && num <= 0x5B) || (num >= 0x5D && num <= 0x2027) || (num >= 0x202A && num <= 0xFFFF))
		{
			num2 = 1;
		}
		else
		{
			if (num != 0x5C)
			{
				global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException("", 0x1D, 0, this.input);
				throw ex;
			}
			num2 = 2;
		}
		switch (num2)
		{
		case 1:
			this.input.Consume();
			break;
		case 2:
			this.mBackslashSequence();
			break;
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000AE74 File Offset: 0x00009074
	[global::Antlr.Runtime.GrammarRule("RegularExpressionLiteral")]
	private void mRegularExpressionLiteral()
	{
		int type = 0x83;
		int channel = 0;
		if (!this.AreRegularExpressionsEnabled())
		{
			throw new global::Antlr.Runtime.FailedPredicateException(this.input, "RegularExpressionLiteral", " AreRegularExpressionsEnabled() ");
		}
		this.mDIV();
		this.mRegularExpressionFirstChar();
		for (;;)
		{
			int num = 2;
			int num2 = this.input.LA(1);
			if ((num2 >= 0 && num2 <= 9) || (num2 >= 0xB && num2 <= 0xC) || (num2 >= 0xE && num2 <= 0x2E) || (num2 >= 0x30 && num2 <= 0x2027) || (num2 >= 0x202A && num2 <= 0xFFFF))
			{
				num = 1;
			}
			int num3 = num;
			if (num3 != 1)
			{
				break;
			}
			this.mRegularExpressionChar();
		}
		this.mDIV();
		for (;;)
		{
			int num4 = 2;
			int num5 = this.input.LA(1);
			if (num5 == 0x24 || (num5 >= 0x30 && num5 <= 0x39) || (num5 >= 0x41 && num5 <= 0x5A) || num5 == 0x5C || num5 == 0x5F || (num5 >= 0x61 && num5 <= 0x7A))
			{
				num4 = 1;
			}
			else if (this.IsIdentifierPartUnicode(this.input.LA(1)))
			{
				num4 = 1;
			}
			int num6 = num4;
			if (num6 != 1)
			{
				break;
			}
			this.mIdentifierPart();
		}
		this.state.type = type;
		this.state.channel = channel;
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000AFF0 File Offset: 0x000091F0
	public override void mTokens()
	{
		int num = 0x75;
		try
		{
			num = this.dfa32.Predict(this.input);
		}
		catch (global::Antlr.Runtime.NoViableAltException)
		{
			throw;
		}
		switch (num)
		{
		case 1:
			this.mABSTRACT();
			return;
		case 2:
			this.mADD();
			return;
		case 3:
			this.mADDASS();
			return;
		case 4:
			this.mAND();
			return;
		case 5:
			this.mANDASS();
			return;
		case 6:
			this.mASSIGN();
			return;
		case 7:
			this.mBOOLEAN();
			return;
		case 8:
			this.mBREAK();
			return;
		case 9:
			this.mBYTE();
			return;
		case 0xA:
			this.mCASE();
			return;
		case 0xB:
			this.mCATCH();
			return;
		case 0xC:
			this.mCHAR();
			return;
		case 0xD:
			this.mCLASS();
			return;
		case 0xE:
			this.mCOLON();
			return;
		case 0xF:
			this.mCOMMA();
			return;
		case 0x10:
			this.mCONST();
			return;
		case 0x11:
			this.mCONTINUE();
			return;
		case 0x12:
			this.mDEBUGGER();
			return;
		case 0x13:
			this.mDEC();
			return;
		case 0x14:
			this.mDEFAULT();
			return;
		case 0x15:
			this.mDELETE();
			return;
		case 0x16:
			this.mDIV();
			return;
		case 0x17:
			this.mDIVASS();
			return;
		case 0x18:
			this.mDO();
			return;
		case 0x19:
			this.mDOT();
			return;
		case 0x1A:
			this.mDOUBLE();
			return;
		case 0x1B:
			this.mELSE();
			return;
		case 0x1C:
			this.mENUM();
			return;
		case 0x1D:
			this.mEQ();
			return;
		case 0x1E:
			this.mEXPORT();
			return;
		case 0x1F:
			this.mEXTENDS();
			return;
		case 0x20:
			this.mFALSE();
			return;
		case 0x21:
			this.mFINAL();
			return;
		case 0x22:
			this.mFINALLY();
			return;
		case 0x23:
			this.mFLOAT();
			return;
		case 0x24:
			this.mFOR();
			return;
		case 0x25:
			this.mFUNCTION();
			return;
		case 0x26:
			this.mGOTO();
			return;
		case 0x27:
			this.mGT();
			return;
		case 0x28:
			this.mGTE();
			return;
		case 0x29:
			this.mIF();
			return;
		case 0x2A:
			this.mIMPLEMENTS();
			return;
		case 0x2B:
			this.mIMPORT();
			return;
		case 0x2C:
			this.mIN();
			return;
		case 0x2D:
			this.mINC();
			return;
		case 0x2E:
			this.mINSTANCEOF();
			return;
		case 0x2F:
			this.mINT();
			return;
		case 0x30:
			this.mINTERFACE();
			return;
		case 0x31:
			this.mINV();
			return;
		case 0x32:
			this.mLAND();
			return;
		case 0x33:
			this.mLBRACE();
			return;
		case 0x34:
			this.mLBRACK();
			return;
		case 0x35:
			this.mLONG();
			return;
		case 0x36:
			this.mLOR();
			return;
		case 0x37:
			this.mLPAREN();
			return;
		case 0x38:
			this.mLT();
			return;
		case 0x39:
			this.mLTE();
			return;
		case 0x3A:
			this.mMOD();
			return;
		case 0x3B:
			this.mMODASS();
			return;
		case 0x3C:
			this.mMUL();
			return;
		case 0x3D:
			this.mMULASS();
			return;
		case 0x3E:
			this.mNATIVE();
			return;
		case 0x3F:
			this.mNEQ();
			return;
		case 0x40:
			this.mNEW();
			return;
		case 0x41:
			this.mNOT();
			return;
		case 0x42:
			this.mNSAME();
			return;
		case 0x43:
			this.mNULL();
			return;
		case 0x44:
			this.mOR();
			return;
		case 0x45:
			this.mORASS();
			return;
		case 0x46:
			this.mPACKAGE();
			return;
		case 0x47:
			this.mPRIVATE();
			return;
		case 0x48:
			this.mPROTECTED();
			return;
		case 0x49:
			this.mPUBLIC();
			return;
		case 0x4A:
			this.mQUE();
			return;
		case 0x4B:
			this.mRBRACE();
			return;
		case 0x4C:
			this.mRBRACK();
			return;
		case 0x4D:
			this.mRETURN();
			return;
		case 0x4E:
			this.mRPAREN();
			return;
		case 0x4F:
			this.mSAME();
			return;
		case 0x50:
			this.mSEMIC();
			return;
		case 0x51:
			this.mSHL();
			return;
		case 0x52:
			this.mSHLASS();
			return;
		case 0x53:
			this.mSHORT();
			return;
		case 0x54:
			this.mSHR();
			return;
		case 0x55:
			this.mSHRASS();
			return;
		case 0x56:
			this.mSHU();
			return;
		case 0x57:
			this.mSHUASS();
			return;
		case 0x58:
			this.mSTATIC();
			return;
		case 0x59:
			this.mSUB();
			return;
		case 0x5A:
			this.mSUBASS();
			return;
		case 0x5B:
			this.mSUPER();
			return;
		case 0x5C:
			this.mSWITCH();
			return;
		case 0x5D:
			this.mSYNCHRONIZED();
			return;
		case 0x5E:
			this.mTHIS();
			return;
		case 0x5F:
			this.mTHROW();
			return;
		case 0x60:
			this.mTHROWS();
			return;
		case 0x61:
			this.mTRANSIENT();
			return;
		case 0x62:
			this.mTRUE();
			return;
		case 0x63:
			this.mTRY();
			return;
		case 0x64:
			this.mTYPEOF();
			return;
		case 0x65:
			this.mVAR();
			return;
		case 0x66:
			this.mVOID();
			return;
		case 0x67:
			this.mVOLATILE();
			return;
		case 0x68:
			this.mWHILE();
			return;
		case 0x69:
			this.mWITH();
			return;
		case 0x6A:
			this.mXOR();
			return;
		case 0x6B:
			this.mXORASS();
			return;
		case 0x6C:
			this.mWhiteSpace();
			return;
		case 0x6D:
			this.mEOL();
			return;
		case 0x6E:
			this.mMultiLineComment();
			return;
		case 0x6F:
			this.mSingleLineComment();
			return;
		case 0x70:
			this.mIdentifier();
			return;
		case 0x71:
			this.mDecimalLiteral();
			return;
		case 0x72:
			this.mOctalIntegerLiteral();
			return;
		case 0x73:
			this.mHexIntegerLiteral();
			return;
		case 0x74:
			this.mStringLiteral();
			return;
		case 0x75:
			this.mRegularExpressionLiteral();
			return;
		default:
			return;
		}
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0000B53C File Offset: 0x0000973C
	protected override void InitDFAs()
	{
		base.InitDFAs();
		this.dfa18 = new global::ES3Lexer.DFA18(this);
		this.dfa32 = new global::ES3Lexer.DFA32(this, new global::Antlr.Runtime.SpecialStateTransitionHandler(this.SpecialStateTransition32));
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000B568 File Offset: 0x00009768
	private int SpecialStateTransition32(global::Antlr.Runtime.DFA dfa, int s, global::Antlr.Runtime.IIntStream _input)
	{
		int stateNumber = s;
		switch (s)
		{
		case 0:
		{
			int num = _input.LA(1);
			int index = _input.Index;
			_input.Rewind();
			s = -1;
			if (num == 0x3D)
			{
				s = 0x44;
			}
			else if (num == 0x2A)
			{
				s = 0x45;
			}
			else if (num == 0x2F)
			{
				s = 0x46;
			}
			else if (((num >= 0 && num <= 9) || (num >= 0xB && num <= 0xC) || (num >= 0xE && num <= 0x29) || (num >= 0x2B && num <= 0x2E) || (num >= 0x30 && num <= 0x3C) || (num >= 0x3E && num <= 0x2027) || (num >= 0x202A && num <= 0xFFFF)) && this.AreRegularExpressionsEnabled())
			{
				s = 0x48;
			}
			else
			{
				s = 0x47;
			}
			_input.Seek(index);
			if (s >= 0)
			{
				return s;
			}
			break;
		}
		case 1:
		{
			int num2 = _input.LA(1);
			int index2 = _input.Index;
			_input.Rewind();
			s = -1;
			if (((num2 >= 0 && num2 <= 9) || (num2 >= 0xB && num2 <= 0xC) || (num2 >= 0xE && num2 <= 0x2027) || (num2 >= 0x202A && num2 <= 0xFFFF)) && this.AreRegularExpressionsEnabled())
			{
				s = 0x48;
			}
			else
			{
				s = 0x8D;
			}
			_input.Seek(index2);
			if (s >= 0)
			{
				return s;
			}
			break;
		}
		}
		global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException(dfa.Description, 0x20, stateNumber, _input);
		dfa.Error(ex);
		throw ex;
	}

	// Token: 0x04000068 RID: 104
	public const int EOF = -1;

	// Token: 0x04000069 RID: 105
	public const int ABSTRACT = 4;

	// Token: 0x0400006A RID: 106
	public const int ADD = 5;

	// Token: 0x0400006B RID: 107
	public const int ADDASS = 6;

	// Token: 0x0400006C RID: 108
	public const int AND = 7;

	// Token: 0x0400006D RID: 109
	public const int ANDASS = 8;

	// Token: 0x0400006E RID: 110
	public const int ARGS = 9;

	// Token: 0x0400006F RID: 111
	public const int ARRAY = 0xA;

	// Token: 0x04000070 RID: 112
	public const int ASSIGN = 0xB;

	// Token: 0x04000071 RID: 113
	public const int BLOCK = 0xC;

	// Token: 0x04000072 RID: 114
	public const int BOOLEAN = 0xD;

	// Token: 0x04000073 RID: 115
	public const int BREAK = 0xE;

	// Token: 0x04000074 RID: 116
	public const int BSLASH = 0xF;

	// Token: 0x04000075 RID: 117
	public const int BYFIELD = 0x10;

	// Token: 0x04000076 RID: 118
	public const int BYINDEX = 0x11;

	// Token: 0x04000077 RID: 119
	public const int BYTE = 0x12;

	// Token: 0x04000078 RID: 120
	public const int BackslashSequence = 0x13;

	// Token: 0x04000079 RID: 121
	public const int CALL = 0x14;

	// Token: 0x0400007A RID: 122
	public const int CASE = 0x15;

	// Token: 0x0400007B RID: 123
	public const int CATCH = 0x16;

	// Token: 0x0400007C RID: 124
	public const int CEXPR = 0x17;

	// Token: 0x0400007D RID: 125
	public const int CHAR = 0x18;

	// Token: 0x0400007E RID: 126
	public const int CLASS = 0x19;

	// Token: 0x0400007F RID: 127
	public const int COLON = 0x1A;

	// Token: 0x04000080 RID: 128
	public const int COMMA = 0x1B;

	// Token: 0x04000081 RID: 129
	public const int CONST = 0x1C;

	// Token: 0x04000082 RID: 130
	public const int CONTINUE = 0x1D;

	// Token: 0x04000083 RID: 131
	public const int CR = 0x1E;

	// Token: 0x04000084 RID: 132
	public const int CharacterEscapeSequence = 0x1F;

	// Token: 0x04000085 RID: 133
	public const int DEBUGGER = 0x20;

	// Token: 0x04000086 RID: 134
	public const int DEC = 0x21;

	// Token: 0x04000087 RID: 135
	public const int DEFAULT = 0x22;

	// Token: 0x04000088 RID: 136
	public const int DELETE = 0x23;

	// Token: 0x04000089 RID: 137
	public const int DIV = 0x24;

	// Token: 0x0400008A RID: 138
	public const int DIVASS = 0x25;

	// Token: 0x0400008B RID: 139
	public const int DO = 0x26;

	// Token: 0x0400008C RID: 140
	public const int DOT = 0x27;

	// Token: 0x0400008D RID: 141
	public const int DOUBLE = 0x28;

	// Token: 0x0400008E RID: 142
	public const int DQUOTE = 0x29;

	// Token: 0x0400008F RID: 143
	public const int DecimalDigit = 0x2A;

	// Token: 0x04000090 RID: 144
	public const int DecimalIntegerLiteral = 0x2B;

	// Token: 0x04000091 RID: 145
	public const int DecimalLiteral = 0x2C;

	// Token: 0x04000092 RID: 146
	public const int ELSE = 0x2D;

	// Token: 0x04000093 RID: 147
	public const int ENUM = 0x2E;

	// Token: 0x04000094 RID: 148
	public const int EOL = 0x2F;

	// Token: 0x04000095 RID: 149
	public const int EQ = 0x30;

	// Token: 0x04000096 RID: 150
	public const int EXPORT = 0x31;

	// Token: 0x04000097 RID: 151
	public const int EXPR = 0x32;

	// Token: 0x04000098 RID: 152
	public const int EXTENDS = 0x33;

	// Token: 0x04000099 RID: 153
	public const int EscapeSequence = 0x34;

	// Token: 0x0400009A RID: 154
	public const int ExponentPart = 0x35;

	// Token: 0x0400009B RID: 155
	public const int FALSE = 0x36;

	// Token: 0x0400009C RID: 156
	public const int FF = 0x37;

	// Token: 0x0400009D RID: 157
	public const int FINAL = 0x38;

	// Token: 0x0400009E RID: 158
	public const int FINALLY = 0x39;

	// Token: 0x0400009F RID: 159
	public const int FLOAT = 0x3A;

	// Token: 0x040000A0 RID: 160
	public const int FOR = 0x3B;

	// Token: 0x040000A1 RID: 161
	public const int FORITER = 0x3C;

	// Token: 0x040000A2 RID: 162
	public const int FORSTEP = 0x3D;

	// Token: 0x040000A3 RID: 163
	public const int FUNCTION = 0x3E;

	// Token: 0x040000A4 RID: 164
	public const int GOTO = 0x3F;

	// Token: 0x040000A5 RID: 165
	public const int GT = 0x40;

	// Token: 0x040000A6 RID: 166
	public const int GTE = 0x41;

	// Token: 0x040000A7 RID: 167
	public const int HexDigit = 0x42;

	// Token: 0x040000A8 RID: 168
	public const int HexEscapeSequence = 0x43;

	// Token: 0x040000A9 RID: 169
	public const int HexIntegerLiteral = 0x44;

	// Token: 0x040000AA RID: 170
	public const int IF = 0x45;

	// Token: 0x040000AB RID: 171
	public const int IMPLEMENTS = 0x46;

	// Token: 0x040000AC RID: 172
	public const int IMPORT = 0x47;

	// Token: 0x040000AD RID: 173
	public const int IN = 0x48;

	// Token: 0x040000AE RID: 174
	public const int INC = 0x49;

	// Token: 0x040000AF RID: 175
	public const int INSTANCEOF = 0x4A;

	// Token: 0x040000B0 RID: 176
	public const int INT = 0x4B;

	// Token: 0x040000B1 RID: 177
	public const int INTERFACE = 0x4C;

	// Token: 0x040000B2 RID: 178
	public const int INV = 0x4D;

	// Token: 0x040000B3 RID: 179
	public const int ITEM = 0x4E;

	// Token: 0x040000B4 RID: 180
	public const int Identifier = 0x4F;

	// Token: 0x040000B5 RID: 181
	public const int IdentifierNameASCIIStart = 0x50;

	// Token: 0x040000B6 RID: 182
	public const int IdentifierPart = 0x51;

	// Token: 0x040000B7 RID: 183
	public const int IdentifierStartASCII = 0x52;

	// Token: 0x040000B8 RID: 184
	public const int LABELLED = 0x53;

	// Token: 0x040000B9 RID: 185
	public const int LAND = 0x54;

	// Token: 0x040000BA RID: 186
	public const int LBRACE = 0x55;

	// Token: 0x040000BB RID: 187
	public const int LBRACK = 0x56;

	// Token: 0x040000BC RID: 188
	public const int LF = 0x57;

	// Token: 0x040000BD RID: 189
	public const int LONG = 0x58;

	// Token: 0x040000BE RID: 190
	public const int LOR = 0x59;

	// Token: 0x040000BF RID: 191
	public const int LPAREN = 0x5A;

	// Token: 0x040000C0 RID: 192
	public const int LS = 0x5B;

	// Token: 0x040000C1 RID: 193
	public const int LT = 0x5C;

	// Token: 0x040000C2 RID: 194
	public const int LTE = 0x5D;

	// Token: 0x040000C3 RID: 195
	public const int LineTerminator = 0x5E;

	// Token: 0x040000C4 RID: 196
	public const int MOD = 0x5F;

	// Token: 0x040000C5 RID: 197
	public const int MODASS = 0x60;

	// Token: 0x040000C6 RID: 198
	public const int MUL = 0x61;

	// Token: 0x040000C7 RID: 199
	public const int MULASS = 0x62;

	// Token: 0x040000C8 RID: 200
	public const int MultiLineComment = 0x63;

	// Token: 0x040000C9 RID: 201
	public const int NAMEDVALUE = 0x64;

	// Token: 0x040000CA RID: 202
	public const int NATIVE = 0x65;

	// Token: 0x040000CB RID: 203
	public const int NBSP = 0x66;

	// Token: 0x040000CC RID: 204
	public const int NEG = 0x67;

	// Token: 0x040000CD RID: 205
	public const int NEQ = 0x68;

	// Token: 0x040000CE RID: 206
	public const int NEW = 0x69;

	// Token: 0x040000CF RID: 207
	public const int NOT = 0x6A;

	// Token: 0x040000D0 RID: 208
	public const int NSAME = 0x6B;

	// Token: 0x040000D1 RID: 209
	public const int NULL = 0x6C;

	// Token: 0x040000D2 RID: 210
	public const int OBJECT = 0x6D;

	// Token: 0x040000D3 RID: 211
	public const int OR = 0x6E;

	// Token: 0x040000D4 RID: 212
	public const int ORASS = 0x6F;

	// Token: 0x040000D5 RID: 213
	public const int OctalDigit = 0x70;

	// Token: 0x040000D6 RID: 214
	public const int OctalEscapeSequence = 0x71;

	// Token: 0x040000D7 RID: 215
	public const int OctalIntegerLiteral = 0x72;

	// Token: 0x040000D8 RID: 216
	public const int PACKAGE = 0x73;

	// Token: 0x040000D9 RID: 217
	public const int PAREXPR = 0x74;

	// Token: 0x040000DA RID: 218
	public const int PDEC = 0x75;

	// Token: 0x040000DB RID: 219
	public const int PINC = 0x76;

	// Token: 0x040000DC RID: 220
	public const int POS = 0x77;

	// Token: 0x040000DD RID: 221
	public const int PRIVATE = 0x78;

	// Token: 0x040000DE RID: 222
	public const int PROTECTED = 0x79;

	// Token: 0x040000DF RID: 223
	public const int PS = 0x7A;

	// Token: 0x040000E0 RID: 224
	public const int PUBLIC = 0x7B;

	// Token: 0x040000E1 RID: 225
	public const int QUE = 0x7C;

	// Token: 0x040000E2 RID: 226
	public const int RBRACE = 0x7D;

	// Token: 0x040000E3 RID: 227
	public const int RBRACK = 0x7E;

	// Token: 0x040000E4 RID: 228
	public const int RETURN = 0x7F;

	// Token: 0x040000E5 RID: 229
	public const int RPAREN = 0x80;

	// Token: 0x040000E6 RID: 230
	public const int RegularExpressionChar = 0x81;

	// Token: 0x040000E7 RID: 231
	public const int RegularExpressionFirstChar = 0x82;

	// Token: 0x040000E8 RID: 232
	public const int RegularExpressionLiteral = 0x83;

	// Token: 0x040000E9 RID: 233
	public const int SAME = 0x84;

	// Token: 0x040000EA RID: 234
	public const int SEMIC = 0x85;

	// Token: 0x040000EB RID: 235
	public const int SHL = 0x86;

	// Token: 0x040000EC RID: 236
	public const int SHLASS = 0x87;

	// Token: 0x040000ED RID: 237
	public const int SHORT = 0x88;

	// Token: 0x040000EE RID: 238
	public const int SHR = 0x89;

	// Token: 0x040000EF RID: 239
	public const int SHRASS = 0x8A;

	// Token: 0x040000F0 RID: 240
	public const int SHU = 0x8B;

	// Token: 0x040000F1 RID: 241
	public const int SHUASS = 0x8C;

	// Token: 0x040000F2 RID: 242
	public const int SP = 0x8D;

	// Token: 0x040000F3 RID: 243
	public const int SQUOTE = 0x8E;

	// Token: 0x040000F4 RID: 244
	public const int STATIC = 0x8F;

	// Token: 0x040000F5 RID: 245
	public const int SUB = 0x90;

	// Token: 0x040000F6 RID: 246
	public const int SUBASS = 0x91;

	// Token: 0x040000F7 RID: 247
	public const int SUPER = 0x92;

	// Token: 0x040000F8 RID: 248
	public const int SWITCH = 0x93;

	// Token: 0x040000F9 RID: 249
	public const int SYNCHRONIZED = 0x94;

	// Token: 0x040000FA RID: 250
	public const int SingleLineComment = 0x95;

	// Token: 0x040000FB RID: 251
	public const int StringLiteral = 0x96;

	// Token: 0x040000FC RID: 252
	public const int TAB = 0x97;

	// Token: 0x040000FD RID: 253
	public const int THIS = 0x98;

	// Token: 0x040000FE RID: 254
	public const int THROW = 0x99;

	// Token: 0x040000FF RID: 255
	public const int THROWS = 0x9A;

	// Token: 0x04000100 RID: 256
	public const int TRANSIENT = 0x9B;

	// Token: 0x04000101 RID: 257
	public const int TRUE = 0x9C;

	// Token: 0x04000102 RID: 258
	public const int TRY = 0x9D;

	// Token: 0x04000103 RID: 259
	public const int TYPEOF = 0x9E;

	// Token: 0x04000104 RID: 260
	public const int USP = 0x9F;

	// Token: 0x04000105 RID: 261
	public const int UnicodeEscapeSequence = 0xA0;

	// Token: 0x04000106 RID: 262
	public const int VAR = 0xA1;

	// Token: 0x04000107 RID: 263
	public const int VOID = 0xA2;

	// Token: 0x04000108 RID: 264
	public const int VOLATILE = 0xA3;

	// Token: 0x04000109 RID: 265
	public const int VT = 0xA4;

	// Token: 0x0400010A RID: 266
	public const int WHILE = 0xA5;

	// Token: 0x0400010B RID: 267
	public const int WITH = 0xA6;

	// Token: 0x0400010C RID: 268
	public const int WhiteSpace = 0xA7;

	// Token: 0x0400010D RID: 269
	public const int XOR = 0xA8;

	// Token: 0x0400010E RID: 270
	public const int XORASS = 0xA9;

	// Token: 0x0400010F RID: 271
	public const int ZeroToThree = 0xAA;

	// Token: 0x04000110 RID: 272
	private global::Antlr.Runtime.IToken last;

	// Token: 0x04000111 RID: 273
	private global::ES3Lexer.DFA18 dfa18;

	// Token: 0x04000112 RID: 274
	private global::ES3Lexer.DFA32 dfa32;

	// Token: 0x020000EA RID: 234
	private class DFA18 : global::Antlr.Runtime.DFA
	{
		// Token: 0x06000A59 RID: 2649 RVA: 0x000364E4 File Offset: 0x000346E4
		static DFA18()
		{
			int num = global::ES3Lexer.DFA18.DFA18_transitionS.Length;
			global::ES3Lexer.DFA18.DFA18_transition = new short[num][];
			for (int i = 0; i < num; i++)
			{
				global::ES3Lexer.DFA18.DFA18_transition[i] = global::Antlr.Runtime.DFA.UnpackEncodedString(global::ES3Lexer.DFA18.DFA18_transitionS[i]);
			}
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x000365F0 File Offset: 0x000347F0
		public DFA18(global::Antlr.Runtime.BaseRecognizer recognizer)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 0x12;
			this.eot = global::ES3Lexer.DFA18.DFA18_eot;
			this.eof = global::ES3Lexer.DFA18.DFA18_eof;
			this.min = global::ES3Lexer.DFA18.DFA18_min;
			this.max = global::ES3Lexer.DFA18.DFA18_max;
			this.accept = global::ES3Lexer.DFA18.DFA18_accept;
			this.special = global::ES3Lexer.DFA18.DFA18_special;
			this.transition = global::ES3Lexer.DFA18.DFA18_transition;
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x00036664 File Offset: 0x00034864
		public override string Description
		{
			get
			{
				return "889:1: DecimalLiteral : ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | DecimalIntegerLiteral ( ExponentPart )? );";
			}
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0003666C File Offset: 0x0003486C
		public override void Error(global::Antlr.Runtime.NoViableAltException nvae)
		{
		}

		// Token: 0x0400045F RID: 1119
		private const string DFA18_eotS = "\u0001￿\u0002\u0004\u0003￿\u0001\u0004";

		// Token: 0x04000460 RID: 1120
		private const string DFA18_eofS = "\a￿";

		// Token: 0x04000461 RID: 1121
		private const string DFA18_minS = "\u0003.\u0003￿\u0001.";

		// Token: 0x04000462 RID: 1122
		private const string DFA18_maxS = "\u00019\u0001.\u00019\u0003￿\u00019";

		// Token: 0x04000463 RID: 1123
		private const string DFA18_acceptS = "\u0003￿\u0001\u0002\u0001\u0003\u0001\u0001\u0001￿";

		// Token: 0x04000464 RID: 1124
		private const string DFA18_specialS = "\a￿}>";

		// Token: 0x04000465 RID: 1125
		private static readonly string[] DFA18_transitionS = new string[]
		{
			"\u0001\u0003\u0001￿\u0001\u0001\t\u0002",
			"\u0001\u0005",
			"\u0001\u0005\u0001￿\n\u0006",
			"",
			"",
			"",
			"\u0001\u0005\u0001￿\n\u0006"
		};

		// Token: 0x04000466 RID: 1126
		private static readonly short[] DFA18_eot = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0001￿\u0002\u0004\u0003￿\u0001\u0004");

		// Token: 0x04000467 RID: 1127
		private static readonly short[] DFA18_eof = global::Antlr.Runtime.DFA.UnpackEncodedString("\a￿");

		// Token: 0x04000468 RID: 1128
		private static readonly char[] DFA18_min = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0003.\u0003￿\u0001.");

		// Token: 0x04000469 RID: 1129
		private static readonly char[] DFA18_max = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u00019\u0001.\u00019\u0003￿\u00019");

		// Token: 0x0400046A RID: 1130
		private static readonly short[] DFA18_accept = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0003￿\u0001\u0002\u0001\u0003\u0001\u0001\u0001￿");

		// Token: 0x0400046B RID: 1131
		private static readonly short[] DFA18_special = global::Antlr.Runtime.DFA.UnpackEncodedString("\a￿}>");

		// Token: 0x0400046C RID: 1132
		private static readonly short[][] DFA18_transition;
	}

	// Token: 0x020000EB RID: 235
	private class DFA32 : global::Antlr.Runtime.DFA
	{
		// Token: 0x06000A5D RID: 2653 RVA: 0x00036670 File Offset: 0x00034870
		static DFA32()
		{
			int num = global::ES3Lexer.DFA32.DFA32_transitionS.Length;
			global::ES3Lexer.DFA32.DFA32_transition = new short[num][];
			for (int i = 0; i < num; i++)
			{
				global::ES3Lexer.DFA32.DFA32_transition[i] = global::Antlr.Runtime.DFA.UnpackEncodedString(global::ES3Lexer.DFA32.DFA32_transitionS[i]);
			}
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00037EA0 File Offset: 0x000360A0
		public DFA32(global::Antlr.Runtime.BaseRecognizer recognizer, global::Antlr.Runtime.SpecialStateTransitionHandler specialStateTransition) : base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 0x20;
			this.eot = global::ES3Lexer.DFA32.DFA32_eot;
			this.eof = global::ES3Lexer.DFA32.DFA32_eof;
			this.min = global::ES3Lexer.DFA32.DFA32_min;
			this.max = global::ES3Lexer.DFA32.DFA32_max;
			this.accept = global::ES3Lexer.DFA32.DFA32_accept;
			this.special = global::ES3Lexer.DFA32.DFA32_special;
			this.transition = global::ES3Lexer.DFA32.DFA32_transition;
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x00037F14 File Offset: 0x00036114
		public override string Description
		{
			get
			{
				return "1:1: Tokens : ( ABSTRACT | ADD | ADDASS | AND | ANDASS | ASSIGN | BOOLEAN | BREAK | BYTE | CASE | CATCH | CHAR | CLASS | COLON | COMMA | CONST | CONTINUE | DEBUGGER | DEC | DEFAULT | DELETE | DIV | DIVASS | DO | DOT | DOUBLE | ELSE | ENUM | EQ | EXPORT | EXTENDS | FALSE | FINAL | FINALLY | FLOAT | FOR | FUNCTION | GOTO | GT | GTE | IF | IMPLEMENTS | IMPORT | IN | INC | INSTANCEOF | INT | INTERFACE | INV | LAND | LBRACE | LBRACK | LONG | LOR | LPAREN | LT | LTE | MOD | MODASS | MUL | MULASS | NATIVE | NEQ | NEW | NOT | NSAME | NULL | OR | ORASS | PACKAGE | PRIVATE | PROTECTED | PUBLIC | QUE | RBRACE | RBRACK | RETURN | RPAREN | SAME | SEMIC | SHL | SHLASS | SHORT | SHR | SHRASS | SHU | SHUASS | STATIC | SUB | SUBASS | SUPER | SWITCH | SYNCHRONIZED | THIS | THROW | THROWS | TRANSIENT | TRUE | TRY | TYPEOF | VAR | VOID | VOLATILE | WHILE | WITH | XOR | XORASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral );";
			}
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00037F1C File Offset: 0x0003611C
		public override void Error(global::Antlr.Runtime.NoViableAltException nvae)
		{
		}

		// Token: 0x0400046D RID: 1133
		private const string DFA32_eotS = "\u0002+\u00012\u00015\u00017\u0002+\u0002￿\u0001+\u0001C\u0001G\u0001I\u0003+\u0001U\u0001+\u0003￿\u0001+\u0001\\\u0001￿\u0001_\u0001a\u0001c\u0001+\u0001h\u0001+\u0003￿\u0001+\u0002￿\u0004+\u0001z\u0003￿\u0001-\u0002￿\u0001+\u0006￿\u0001\u007f\u0001￿\b+\u0001\u008c\u0003￿\u0001\u008d\u0005￿\t+\u0001￿\u0001\u009a\u0001￿\u0001\u009b\u0001+\u0001\u009f\u0001+\u0004￿\u0001¢\u0005￿\u0003+\u0001§\u0001￿\u0010+\u0004￿\u0001+\u0002￿\f+\u0002￿\a+\u0001Ò\u0002+\u0001￿\u0001Ö\u0002￿\u0002+\u0001Û\u0001￿\u0001+\u0002￿\u0001+\u0001Þ\u0001+\u0002￿\u000e+\u0001î\u0001+\u0001ð\a+\u0001ø\u0001ù\u0001+\u0001û\a+\u0001ă\u0001Ą\u0005+\u0001￿\u0001+\u0001ċ\u0002￿\u0004+\u0001￿\u0001Đ\u0001+\u0001￿\u0001Ē\n+\u0001ĝ\u0002+\u0001Ġ\u0001￿\u0001+\u0001￿\u0001Ģ\u0002+\u0001ĥ\u0002+\u0001Ĩ\u0002￿\u0001ĩ\u0001￿\u0001Ī\u0001ī\u0005+\u0002￿\u0002+\u0001ĳ\u0001ĵ\u0001Ķ\u0001+\u0001￿\u0004+\u0001￿\u0001+\u0001￿\u0005+\u0001ł\u0001+\u0001ń\u0002+\u0001￿\u0001ň\u0001+\u0001￿\u0001+\u0001￿\u0001+\u0001Ō\u0001￿\u0002+\u0004￿\u0003+\u0001Œ\u0001œ\u0001Ŕ\u0001+\u0001￿\u0001+\u0002￿\u0002+\u0001ř\u0002+\u0001Ŝ\u0003+\u0001Š\u0001š\u0001￿\u0001Ţ\u0001￿\u0001ţ\u0001+\u0001ť\u0001￿\u0001+\u0001ŧ\u0001+\u0001￿\u0001+\u0001Ū\u0002+\u0001ŭ\u0003￿\u0001Ů\u0001ů\u0002+\u0001￿\u0002+\u0001￿\u0001Ŵ\u0001ŵ\u0001+\u0004￿\u0001+\u0001￿\u0001+\u0001￿\u0001+\u0001ź\u0001￿\u0001Ż\u0001ż\u0003￿\u0001Ž\u0003+\u0002￿\u0003+\u0001Ƅ\u0004￿\u0002+\u0001Ƈ\u0001ƈ\u0001+\u0001Ɗ\u0001￿\u0001Ƌ\u0001ƌ\u0002￿\u0001+\u0003￿\u0001+\u0001Ə\u0001￿";

		// Token: 0x0400046E RID: 1134
		private const string DFA32_eofS = "Ɛ￿";

		// Token: 0x0400046F RID: 1135
		private const string DFA32_minS = "\u0001\t\u0001b\u0001+\u0001&\u0001=\u0001o\u0001a\u0002￿\u0001e\u0001-\u0001\0\u00010\u0001l\u0001a\u0001o\u0001=\u0001f\u0003￿\u0001o\u0001=\u0001￿\u0001<\u0002=\u0001a\u0001=\u0001a\u0003￿\u0001e\u0002￿\u0002h\u0001a\u0001h\u0001=\u0003￿\u00010\u0002￿\u0001s\u0006￿\u0001=\u0001￿\u0001o\u0001e\u0001t\u0001s\u0002a\u0001n\u0001b\u0001$\u0003￿\u0001\0\u0005￿\u0001s\u0001u\u0001p\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001￿\u0001=\u0001￿\u0001$\u0001p\u0001$\u0001n\u0004￿\u0001=\u0005￿\u0001t\u0001w\u0001l\u0001=\u0001￿\u0001c\u0001i\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001i\u0001a\u0001p\u0001r\u0002i\u0001t\u0004￿\u0001t\u0002￿\u0001l\u0001a\u0002e\u0001c\u0001r\u0002s\u0001u\u0001a\u0001e\u0001b\u0002￿\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001$\u0001c\u0001o\u0001￿\u0001=\u0002￿\u0001l\u0001t\u0001$\u0001￿\u0001g\u0002￿\u0001i\u0001$\u0001l\u0002￿\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001$\u0001e\u0001$\u0001d\u0001a\u0001l\u0001h\u0001r\u0001e\u0001k\u0002$\u0001h\u0001$\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002$\u0001r\u0001n\u0001e\u0001l\u0001t\u0001￿\u0001t\u0001$\u0002￿\u0001e\u0001r\u0001a\u0001r\u0001￿\u0001$\u0001v\u0001￿\u0001$\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001$\u0001w\u0001s\u0001$\u0001￿\u0001o\u0001￿\u0001$\u0001t\u0001e\u0001$\u0002a\u0001$\u0002￿\u0001$\u0001￿\u0002$\u0001n\u0001g\u0001l\u0002e\u0002￿\u0001t\u0001d\u0003$\u0001i\u0001￿\u0001m\u0001t\u0001n\u0001f\u0001￿\u0001e\u0001￿\u0001g\u0001t\u0002c\u0001n\u0001$\u0001c\u0001$\u0001h\u0001r\u0001￿\u0001$\u0001i\u0001￿\u0001f\u0001￿\u0001i\u0001$\u0001￿\u0001c\u0001n\u0004￿\u0001u\u0001e\u0001t\u0003$\u0001s\u0001￿\u0001y\u0002￿\u0001o\u0001e\u0001$\u0001c\u0001a\u0001$\u0002e\u0001t\u0002$\u0001￿\u0001$\u0001￿\u0001$\u0001o\u0001$\u0001￿\u0001e\u0001$\u0001l\u0001￿\u0001t\u0001$\u0001e\u0001r\u0001$\u0003￿\u0002$\u0002n\u0001￿\u0001e\u0001c\u0001￿\u0002$\u0001e\u0004￿\u0001n\u0001￿\u0001n\u0001￿\u0001e\u0001$\u0001￿\u0002$\u0003￿\u0001$\u0001t\u0001o\u0001e\u0002￿\u0001d\u0001i\u0001t\u0001$\u0004￿\u0001s\u0001f\u0002$\u0001z\u0001$\u0001￿\u0002$\u0002￿\u0001e\u0003￿\u0001d\u0001$\u0001￿";

		// Token: 0x04000470 RID: 1136
		private const string DFA32_maxS = "\u0001\u3000\u0001b\u0003=\u0001y\u0001o\u0002￿\u0001o\u0001=\u0001￿\u00019\u0001x\u0001u\u0001o\u0001>\u0001n\u0003￿\u0001o\u0001|\u0001￿\u0003=\u0001u\u0001=\u0001u\u0003￿\u0001e\u0002￿\u0002y\u0001o\u0001i\u0001=\u0003￿\u0001x\u0002￿\u0001s\u0006￿\u0001=\u0001￿\u0001o\u0001e\u0002t\u0002a\u0001n\u0001l\u0001z\u0003￿\u0001￿\u0005￿\u0001s\u0001u\u0001t\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001￿\u0001>\u0001￿\u0001z\u0001p\u0001z\u0001n\u0004￿\u0001=\u0005￿\u0001t\u0001w\u0001l\u0001=\u0001￿\u0001c\u0001o\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001r\u0001y\u0001p\u0001r\u0001l\u0001i\u0001t\u0004￿\u0001t\u0002￿\u0001l\u0001a\u0002e\u0001c\u0001r\u0001s\u0001t\u0001u\u0001a\u0001e\u0001b\u0002￿\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001z\u0001c\u0001o\u0001￿\u0001=\u0002￿\u0001o\u0001t\u0001z\u0001￿\u0001g\u0002￿\u0001i\u0001z\u0001l\u0002￿\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001z\u0001e\u0001z\u0001d\u0001a\u0001l\u0001h\u0001r\u0001e\u0001k\u0002z\u0001h\u0001z\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002z\u0001r\u0001n\u0001e\u0001l\u0001t\u0001￿\u0001t\u0001z\u0002￿\u0001e\u0001r\u0001a\u0001r\u0001￿\u0001z\u0001v\u0001￿\u0001z\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001z\u0001w\u0001s\u0001z\u0001￿\u0001o\u0001￿\u0001z\u0001t\u0001e\u0001z\u0002a\u0001z\u0002￿\u0001z\u0001￿\u0002z\u0001n\u0001g\u0001l\u0002e\u0002￿\u0001t\u0001d\u0003z\u0001i\u0001￿\u0001m\u0001t\u0001n\u0001f\u0001￿\u0001e\u0001￿\u0001g\u0001t\u0002c\u0001n\u0001z\u0001c\u0001z\u0001h\u0001r\u0001￿\u0001z\u0001i\u0001￿\u0001f\u0001￿\u0001i\u0001z\u0001￿\u0001c\u0001n\u0004￿\u0001u\u0001e\u0001t\u0003z\u0001s\u0001￿\u0001y\u0002￿\u0001o\u0001e\u0001z\u0001c\u0001a\u0001z\u0002e\u0001t\u0002z\u0001￿\u0001z\u0001￿\u0001z\u0001o\u0001z\u0001￿\u0001e\u0001z\u0001l\u0001￿\u0001t\u0001z\u0001e\u0001r\u0001z\u0003￿\u0002z\u0002n\u0001￿\u0001e\u0001c\u0001￿\u0002z\u0001e\u0004￿\u0001n\u0001￿\u0001n\u0001￿\u0001e\u0001z\u0001￿\u0002z\u0003￿\u0001z\u0001t\u0001o\u0001e\u0002￿\u0001d\u0001i\u0001t\u0001z\u0004￿\u0001s\u0001f\u0004z\u0001￿\u0002z\u0002￿\u0001e\u0003￿\u0001d\u0001z\u0001￿";

		// Token: 0x04000471 RID: 1137
		private const string DFA32_acceptS = "\a￿\u0001\u000e\u0001\u000f\t￿\u00011\u00013\u00014\u0002￿\u00017\u0006￿\u0001J\u0001K\u0001L\u0001￿\u0001N\u0001P\u0005￿\u0001l\u0001m\u0001p\u0001￿\u0001q\u0001t\u0001￿\u0001\u0003\u0001-\u0001\u0002\u0001\u0005\u00012\u0001\u0004\u0001￿\u0001\u0006\t￿\u0001\u0013\u0001Z\u0001Y\u0001￿\u0001n\u0001o\u0001\u0016\u0001u\u0001\u0019\t￿\u0001(\u0001￿\u0001'\u0004￿\u00016\u0001E\u0001D\u00019\u0001￿\u00018\u0001;\u0001:\u0001=\u0001<\u0004￿\u0001A\u0010￿\u0001k\u0001j\u0001s\u0001r\u0001￿\u0001O\u0001\u001d\f￿\u0001\u0018\u0001\u0017\n￿\u0001U\u0001￿\u0001T\u0001)\u0003￿\u0001,\u0001￿\u0001R\u0001Q\u0003￿\u0001B\u0001?*￿\u0001$\u0002￿\u0001W\u0001V\u0004￿\u0001/\u0002￿\u0001@\u000f￿\u0001c\u0001￿\u0001e\a￿\u0001\t\u0001\n\u0001￿\u0001\f\a￿\u0001\u001b\u0001\u001c\u0006￿\u0001&\u0004￿\u00015\u0001￿\u0001C\n￿\u0001^\u0002￿\u0001b\u0001￿\u0001f\u0002￿\u0001i\u0002￿\u0001\b\u0001\v\u0001\r\u0001\u0010\a￿\u0001 \u0001￿\u0001!\u0001#\v￿\u0001S\u0001￿\u0001[\u0003￿\u0001_\u0003￿\u0001h\u0005￿\u0001\u0015\u0001\u001a\u0001\u001e\u0004￿\u0001+\u0002￿\u0001>\u0003￿\u0001I\u0001M\u0001X\u0001\\\u0001￿\u0001`\u0001￿\u0001d\u0002￿\u0001\a\u0002￿\u0001\u0014\u0001\u001f\u0001\"\u0004￿\u0001F\u0001G\u0004￿\u0001\u0001\u0001\u0011\u0001\u0012\u0001%\u0006￿\u0001g\u0002￿\u00010\u0001H\u0001￿\u0001a\u0001*\u0001.\u0002￿\u0001]";

		// Token: 0x04000472 RID: 1138
		private const string DFA32_specialS = "\v￿\u0001\08￿\u0001\u0001ŋ￿}>";

		// Token: 0x04000473 RID: 1139
		private static readonly string[] DFA32_transitionS = new string[]
		{
			"\u0001)\u0001*\u0002)\u0001*\u0012￿\u0001)\u0001\u001c\u0001.\u0002￿\u0001\u0019\u0001\u0003\u0001.\u0001\u0017\u0001\"\u0001\u001a\u0001\u0002\u0001\b\u0001\n\u0001\f\u0001\v\u0001,\t-\u0001\a\u0001#\u0001\u0018\u0001\u0004\u0001\u0010\u0001\u001e\u001b￿\u0001\u0014\u0001￿\u0001 \u0001(\u0002￿\u0001\u0001\u0001\u0005\u0001\u0006\u0001\t\u0001\r\u0001\u000e\u0001\u000f\u0001￿\u0001\u0011\u0002￿\u0001\u0015\u0001￿\u0001\u001b\u0001￿\u0001\u001d\u0001￿\u0001!\u0001$\u0001%\u0001￿\u0001&\u0001'\u0003￿\u0001\u0013\u0001\u0016\u0001\u001f\u0001\u0012!￿\u0001)ᗟ￿\u0001)ƍ￿\u0001)߱￿\v)\u001d￿\u0002*\u0005￿\u0001)/￿\u0001)ྠ￿\u0001)",
			"\u0001/",
			"\u00011\u0011￿\u00010",
			"\u00014\u0016￿\u00013",
			"\u00016",
			"\u00018\u0002￿\u00019\u0006￿\u0001:",
			"\u0001;\u0006￿\u0001<\u0003￿\u0001=\u0002￿\u0001>",
			"",
			"",
			"\u0001?\t￿\u0001@",
			"\u0001A\u000f￿\u0001B",
			"\nH\u0001￿\u0002H\u0001￿\u001cH\u0001E\u0004H\u0001F\rH\u0001DῪH\u0002￿\udfd6H",
			"\n-",
			"\u0001J\u0001￿\u0001K\t￿\u0001L",
			"\u0001M\a￿\u0001N\u0002￿\u0001O\u0002￿\u0001P\u0005￿\u0001Q",
			"\u0001R",
			"\u0001S\u0001T",
			"\u0001V\u0006￿\u0001W\u0001X",
			"",
			"",
			"",
			"\u0001Y",
			"\u0001[>￿\u0001Z",
			"",
			"\u0001^\u0001]",
			"\u0001`",
			"\u0001b",
			"\u0001d\u0003￿\u0001e\u000f￿\u0001f",
			"\u0001g",
			"\u0001i\u0010￿\u0001j\u0002￿\u0001k",
			"",
			"",
			"",
			"\u0001l",
			"",
			"",
			"\u0001m\v￿\u0001n\u0001o\u0001￿\u0001p\u0001￿\u0001q",
			"\u0001r\t￿\u0001s\u0006￿\u0001t",
			"\u0001u\r￿\u0001v",
			"\u0001w\u0001x",
			"\u0001y",
			"",
			"",
			"",
			"\b| ￿\u0001{\u001f￿\u0001{",
			"",
			"",
			"\u0001}",
			"",
			"",
			"",
			"",
			"",
			"",
			"\u0001~",
			"",
			"\u0001\u0080",
			"\u0001\u0081",
			"\u0001\u0082",
			"\u0001\u0083\u0001\u0084",
			"\u0001\u0085",
			"\u0001\u0086",
			"\u0001\u0087",
			"\u0001\u0088\u0003￿\u0001\u0089\u0005￿\u0001\u008a",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u0014+\u0001\u008b\u0005+",
			"",
			"",
			"",
			"\nH\u0001￿\u0002H\u0001￿‚H\u0002￿\udfd6H",
			"",
			"",
			"",
			"",
			"",
			"\u0001\u008e",
			"\u0001\u008f",
			"\u0001\u0090\u0003￿\u0001\u0091",
			"\u0001\u0092",
			"\u0001\u0093",
			"\u0001\u0094",
			"\u0001\u0095",
			"\u0001\u0096",
			"\u0001\u0097",
			"",
			"\u0001\u0098\u0001\u0099",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001\u009c",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u0012+\u0001\u009d\u0001\u009e\u0006+",
			"\u0001\u00a0",
			"",
			"",
			"",
			"",
			"\u0001¡",
			"",
			"",
			"",
			"",
			"",
			"\u0001£",
			"\u0001¤",
			"\u0001¥",
			"\u0001¦",
			"",
			"\u0001¨",
			"\u0001©\u0005￿\u0001ª",
			"\u0001«",
			"\u0001¬",
			"\u0001­",
			"\u0001®",
			"\u0001¯",
			"\u0001°",
			"\u0001±",
			"\u0001²\b￿\u0001³",
			"\u0001´\u0013￿\u0001µ\u0003￿\u0001¶",
			"\u0001·",
			"\u0001¸",
			"\u0001¹\u0002￿\u0001º",
			"\u0001»",
			"\u0001¼",
			"",
			"",
			"",
			"",
			"\u0001½",
			"",
			"",
			"\u0001¾",
			"\u0001¿",
			"\u0001À",
			"\u0001Á",
			"\u0001Â",
			"\u0001Ã",
			"\u0001Ä",
			"\u0001Å\u0001Æ",
			"\u0001Ç",
			"\u0001È",
			"\u0001É",
			"\u0001Ê",
			"",
			"",
			"\u0001Ë",
			"\u0001Ì",
			"\u0001Í",
			"\u0001Î",
			"\u0001Ï",
			"\u0001Ð",
			"\u0001Ñ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ó",
			"\u0001Ô",
			"",
			"\u0001Õ",
			"",
			"",
			"\u0001×\u0002￿\u0001Ø",
			"\u0001Ù",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u0004+\u0001Ú\u0015+",
			"",
			"\u0001Ü",
			"",
			"",
			"\u0001Ý",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ß",
			"",
			"",
			"\u0001à",
			"\u0001á",
			"\u0001â",
			"\u0001ã",
			"\u0001ä",
			"\u0001å",
			"\u0001æ",
			"\u0001ç",
			"\u0001è",
			"\u0001é",
			"\u0001ê",
			"\u0001ë",
			"\u0001ì",
			"\u0001í",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ï",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ñ",
			"\u0001ò",
			"\u0001ó",
			"\u0001ô",
			"\u0001õ",
			"\u0001ö",
			"\u0001÷",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ú",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ü",
			"\u0001ý",
			"\u0001þ",
			"\u0001ÿ",
			"\u0001Ā",
			"\u0001ā",
			"\u0001Ă",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ą",
			"\u0001Ć",
			"\u0001ć",
			"\u0001Ĉ",
			"\u0001ĉ",
			"",
			"\u0001Ċ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"",
			"\u0001Č",
			"\u0001č",
			"\u0001Ď",
			"\u0001ď",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001đ",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ē",
			"\u0001Ĕ",
			"\u0001ĕ",
			"\u0001Ė",
			"\u0001ė",
			"\u0001Ę",
			"\u0001ę",
			"\u0001Ě",
			"\u0001ě",
			"\u0001Ĝ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ğ",
			"\u0001ğ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001ġ",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ģ",
			"\u0001Ĥ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ħ",
			"\u0001ħ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ĭ",
			"\u0001ĭ",
			"\u0001Į",
			"\u0001į",
			"\u0001İ",
			"",
			"",
			"\u0001ı",
			"\u0001Ĳ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\v+\u0001Ĵ\u000e+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ķ",
			"",
			"\u0001ĸ",
			"\u0001Ĺ",
			"\u0001ĺ",
			"\u0001Ļ",
			"",
			"\u0001ļ",
			"",
			"\u0001Ľ",
			"\u0001ľ",
			"\u0001Ŀ",
			"\u0001ŀ",
			"\u0001Ł",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ń",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ņ",
			"\u0001ņ",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u0012+\u0001Ň\a+",
			"\u0001ŉ",
			"",
			"\u0001Ŋ",
			"",
			"\u0001ŋ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001ō",
			"\u0001Ŏ",
			"",
			"",
			"",
			"",
			"\u0001ŏ",
			"\u0001Ő",
			"\u0001ő",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ŕ",
			"",
			"\u0001Ŗ",
			"",
			"",
			"\u0001ŗ",
			"\u0001Ř",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ś",
			"\u0001ś",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ŝ",
			"\u0001Ş",
			"\u0001ş",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ť",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001Ŧ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ũ",
			"",
			"\u0001ũ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ū",
			"\u0001Ŭ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ű",
			"\u0001ű",
			"",
			"\u0001Ų",
			"\u0001ų",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ŷ",
			"",
			"",
			"",
			"",
			"\u0001ŷ",
			"",
			"\u0001Ÿ",
			"",
			"\u0001Ź",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001ž",
			"\u0001ſ",
			"\u0001ƀ",
			"",
			"",
			"\u0001Ɓ",
			"\u0001Ƃ",
			"\u0001ƃ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"",
			"",
			"",
			"\u0001ƅ",
			"\u0001Ɔ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001Ɖ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			"",
			"",
			"\u0001ƍ",
			"",
			"",
			"",
			"\u0001Ǝ",
			"\u0001+\v￿\n+\a￿\u001a+\u0001￿\u0001+\u0002￿\u0001+\u0001￿\u001a+",
			""
		};

		// Token: 0x04000474 RID: 1140
		private static readonly short[] DFA32_eot = global::Antlr.Runtime.DFA.UnpackEncodedString("\u0002+\u00012\u00015\u00017\u0002+\u0002￿\u0001+\u0001C\u0001G\u0001I\u0003+\u0001U\u0001+\u0003￿\u0001+\u0001\\\u0001￿\u0001_\u0001a\u0001c\u0001+\u0001h\u0001+\u0003￿\u0001+\u0002￿\u0004+\u0001z\u0003￿\u0001-\u0002￿\u0001+\u0006￿\u0001\u007f\u0001￿\b+\u0001\u008c\u0003￿\u0001\u008d\u0005￿\t+\u0001￿\u0001\u009a\u0001￿\u0001\u009b\u0001+\u0001\u009f\u0001+\u0004￿\u0001¢\u0005￿\u0003+\u0001§\u0001￿\u0010+\u0004￿\u0001+\u0002￿\f+\u0002￿\a+\u0001Ò\u0002+\u0001￿\u0001Ö\u0002￿\u0002+\u0001Û\u0001￿\u0001+\u0002￿\u0001+\u0001Þ\u0001+\u0002￿\u000e+\u0001î\u0001+\u0001ð\a+\u0001ø\u0001ù\u0001+\u0001û\a+\u0001ă\u0001Ą\u0005+\u0001￿\u0001+\u0001ċ\u0002￿\u0004+\u0001￿\u0001Đ\u0001+\u0001￿\u0001Ē\n+\u0001ĝ\u0002+\u0001Ġ\u0001￿\u0001+\u0001￿\u0001Ģ\u0002+\u0001ĥ\u0002+\u0001Ĩ\u0002￿\u0001ĩ\u0001￿\u0001Ī\u0001ī\u0005+\u0002￿\u0002+\u0001ĳ\u0001ĵ\u0001Ķ\u0001+\u0001￿\u0004+\u0001￿\u0001+\u0001￿\u0005+\u0001ł\u0001+\u0001ń\u0002+\u0001￿\u0001ň\u0001+\u0001￿\u0001+\u0001￿\u0001+\u0001Ō\u0001￿\u0002+\u0004￿\u0003+\u0001Œ\u0001œ\u0001Ŕ\u0001+\u0001￿\u0001+\u0002￿\u0002+\u0001ř\u0002+\u0001Ŝ\u0003+\u0001Š\u0001š\u0001￿\u0001Ţ\u0001￿\u0001ţ\u0001+\u0001ť\u0001￿\u0001+\u0001ŧ\u0001+\u0001￿\u0001+\u0001Ū\u0002+\u0001ŭ\u0003￿\u0001Ů\u0001ů\u0002+\u0001￿\u0002+\u0001￿\u0001Ŵ\u0001ŵ\u0001+\u0004￿\u0001+\u0001￿\u0001+\u0001￿\u0001+\u0001ź\u0001￿\u0001Ż\u0001ż\u0003￿\u0001Ž\u0003+\u0002￿\u0003+\u0001Ƅ\u0004￿\u0002+\u0001Ƈ\u0001ƈ\u0001+\u0001Ɗ\u0001￿\u0001Ƌ\u0001ƌ\u0002￿\u0001+\u0003￿\u0001+\u0001Ə\u0001￿");

		// Token: 0x04000475 RID: 1141
		private static readonly short[] DFA32_eof = global::Antlr.Runtime.DFA.UnpackEncodedString("Ɛ￿");

		// Token: 0x04000476 RID: 1142
		private static readonly char[] DFA32_min = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001\t\u0001b\u0001+\u0001&\u0001=\u0001o\u0001a\u0002￿\u0001e\u0001-\u0001\0\u00010\u0001l\u0001a\u0001o\u0001=\u0001f\u0003￿\u0001o\u0001=\u0001￿\u0001<\u0002=\u0001a\u0001=\u0001a\u0003￿\u0001e\u0002￿\u0002h\u0001a\u0001h\u0001=\u0003￿\u00010\u0002￿\u0001s\u0006￿\u0001=\u0001￿\u0001o\u0001e\u0001t\u0001s\u0002a\u0001n\u0001b\u0001$\u0003￿\u0001\0\u0005￿\u0001s\u0001u\u0001p\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001￿\u0001=\u0001￿\u0001$\u0001p\u0001$\u0001n\u0004￿\u0001=\u0005￿\u0001t\u0001w\u0001l\u0001=\u0001￿\u0001c\u0001i\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001i\u0001a\u0001p\u0001r\u0002i\u0001t\u0004￿\u0001t\u0002￿\u0001l\u0001a\u0002e\u0001c\u0001r\u0002s\u0001u\u0001a\u0001e\u0001b\u0002￿\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001$\u0001c\u0001o\u0001￿\u0001=\u0002￿\u0001l\u0001t\u0001$\u0001￿\u0001g\u0002￿\u0001i\u0001$\u0001l\u0002￿\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001$\u0001e\u0001$\u0001d\u0001a\u0001l\u0001h\u0001r\u0001e\u0001k\u0002$\u0001h\u0001$\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002$\u0001r\u0001n\u0001e\u0001l\u0001t\u0001￿\u0001t\u0001$\u0002￿\u0001e\u0001r\u0001a\u0001r\u0001￿\u0001$\u0001v\u0001￿\u0001$\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001$\u0001w\u0001s\u0001$\u0001￿\u0001o\u0001￿\u0001$\u0001t\u0001e\u0001$\u0002a\u0001$\u0002￿\u0001$\u0001￿\u0002$\u0001n\u0001g\u0001l\u0002e\u0002￿\u0001t\u0001d\u0003$\u0001i\u0001￿\u0001m\u0001t\u0001n\u0001f\u0001￿\u0001e\u0001￿\u0001g\u0001t\u0002c\u0001n\u0001$\u0001c\u0001$\u0001h\u0001r\u0001￿\u0001$\u0001i\u0001￿\u0001f\u0001￿\u0001i\u0001$\u0001￿\u0001c\u0001n\u0004￿\u0001u\u0001e\u0001t\u0003$\u0001s\u0001￿\u0001y\u0002￿\u0001o\u0001e\u0001$\u0001c\u0001a\u0001$\u0002e\u0001t\u0002$\u0001￿\u0001$\u0001￿\u0001$\u0001o\u0001$\u0001￿\u0001e\u0001$\u0001l\u0001￿\u0001t\u0001$\u0001e\u0001r\u0001$\u0003￿\u0002$\u0002n\u0001￿\u0001e\u0001c\u0001￿\u0002$\u0001e\u0004￿\u0001n\u0001￿\u0001n\u0001￿\u0001e\u0001$\u0001￿\u0002$\u0003￿\u0001$\u0001t\u0001o\u0001e\u0002￿\u0001d\u0001i\u0001t\u0001$\u0004￿\u0001s\u0001f\u0002$\u0001z\u0001$\u0001￿\u0002$\u0002￿\u0001e\u0003￿\u0001d\u0001$\u0001￿");

		// Token: 0x04000477 RID: 1143
		private static readonly char[] DFA32_max = global::Antlr.Runtime.DFA.UnpackEncodedStringToUnsignedChars("\u0001\u3000\u0001b\u0003=\u0001y\u0001o\u0002￿\u0001o\u0001=\u0001￿\u00019\u0001x\u0001u\u0001o\u0001>\u0001n\u0003￿\u0001o\u0001|\u0001￿\u0003=\u0001u\u0001=\u0001u\u0003￿\u0001e\u0002￿\u0002y\u0001o\u0001i\u0001=\u0003￿\u0001x\u0002￿\u0001s\u0006￿\u0001=\u0001￿\u0001o\u0001e\u0002t\u0002a\u0001n\u0001l\u0001z\u0003￿\u0001￿\u0005￿\u0001s\u0001u\u0001t\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001￿\u0001>\u0001￿\u0001z\u0001p\u0001z\u0001n\u0004￿\u0001=\u0005￿\u0001t\u0001w\u0001l\u0001=\u0001￿\u0001c\u0001o\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001r\u0001y\u0001p\u0001r\u0001l\u0001i\u0001t\u0004￿\u0001t\u0002￿\u0001l\u0001a\u0002e\u0001c\u0001r\u0001s\u0001t\u0001u\u0001a\u0001e\u0001b\u0002￿\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001z\u0001c\u0001o\u0001￿\u0001=\u0002￿\u0001o\u0001t\u0001z\u0001￿\u0001g\u0002￿\u0001i\u0001z\u0001l\u0002￿\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001z\u0001e\u0001z\u0001d\u0001a\u0001l\u0001h\u0001r\u0001e\u0001k\u0002z\u0001h\u0001z\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002z\u0001r\u0001n\u0001e\u0001l\u0001t\u0001￿\u0001t\u0001z\u0002￿\u0001e\u0001r\u0001a\u0001r\u0001￿\u0001z\u0001v\u0001￿\u0001z\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001z\u0001w\u0001s\u0001z\u0001￿\u0001o\u0001￿\u0001z\u0001t\u0001e\u0001z\u0002a\u0001z\u0002￿\u0001z\u0001￿\u0002z\u0001n\u0001g\u0001l\u0002e\u0002￿\u0001t\u0001d\u0003z\u0001i\u0001￿\u0001m\u0001t\u0001n\u0001f\u0001￿\u0001e\u0001￿\u0001g\u0001t\u0002c\u0001n\u0001z\u0001c\u0001z\u0001h\u0001r\u0001￿\u0001z\u0001i\u0001￿\u0001f\u0001￿\u0001i\u0001z\u0001￿\u0001c\u0001n\u0004￿\u0001u\u0001e\u0001t\u0003z\u0001s\u0001￿\u0001y\u0002￿\u0001o\u0001e\u0001z\u0001c\u0001a\u0001z\u0002e\u0001t\u0002z\u0001￿\u0001z\u0001￿\u0001z\u0001o\u0001z\u0001￿\u0001e\u0001z\u0001l\u0001￿\u0001t\u0001z\u0001e\u0001r\u0001z\u0003￿\u0002z\u0002n\u0001￿\u0001e\u0001c\u0001￿\u0002z\u0001e\u0004￿\u0001n\u0001￿\u0001n\u0001￿\u0001e\u0001z\u0001￿\u0002z\u0003￿\u0001z\u0001t\u0001o\u0001e\u0002￿\u0001d\u0001i\u0001t\u0001z\u0004￿\u0001s\u0001f\u0004z\u0001￿\u0002z\u0002￿\u0001e\u0003￿\u0001d\u0001z\u0001￿");

		// Token: 0x04000478 RID: 1144
		private static readonly short[] DFA32_accept = global::Antlr.Runtime.DFA.UnpackEncodedString("\a￿\u0001\u000e\u0001\u000f\t￿\u00011\u00013\u00014\u0002￿\u00017\u0006￿\u0001J\u0001K\u0001L\u0001￿\u0001N\u0001P\u0005￿\u0001l\u0001m\u0001p\u0001￿\u0001q\u0001t\u0001￿\u0001\u0003\u0001-\u0001\u0002\u0001\u0005\u00012\u0001\u0004\u0001￿\u0001\u0006\t￿\u0001\u0013\u0001Z\u0001Y\u0001￿\u0001n\u0001o\u0001\u0016\u0001u\u0001\u0019\t￿\u0001(\u0001￿\u0001'\u0004￿\u00016\u0001E\u0001D\u00019\u0001￿\u00018\u0001;\u0001:\u0001=\u0001<\u0004￿\u0001A\u0010￿\u0001k\u0001j\u0001s\u0001r\u0001￿\u0001O\u0001\u001d\f￿\u0001\u0018\u0001\u0017\n￿\u0001U\u0001￿\u0001T\u0001)\u0003￿\u0001,\u0001￿\u0001R\u0001Q\u0003￿\u0001B\u0001?*￿\u0001$\u0002￿\u0001W\u0001V\u0004￿\u0001/\u0002￿\u0001@\u000f￿\u0001c\u0001￿\u0001e\a￿\u0001\t\u0001\n\u0001￿\u0001\f\a￿\u0001\u001b\u0001\u001c\u0006￿\u0001&\u0004￿\u00015\u0001￿\u0001C\n￿\u0001^\u0002￿\u0001b\u0001￿\u0001f\u0002￿\u0001i\u0002￿\u0001\b\u0001\v\u0001\r\u0001\u0010\a￿\u0001 \u0001￿\u0001!\u0001#\v￿\u0001S\u0001￿\u0001[\u0003￿\u0001_\u0003￿\u0001h\u0005￿\u0001\u0015\u0001\u001a\u0001\u001e\u0004￿\u0001+\u0002￿\u0001>\u0003￿\u0001I\u0001M\u0001X\u0001\\\u0001￿\u0001`\u0001￿\u0001d\u0002￿\u0001\a\u0002￿\u0001\u0014\u0001\u001f\u0001\"\u0004￿\u0001F\u0001G\u0004￿\u0001\u0001\u0001\u0011\u0001\u0012\u0001%\u0006￿\u0001g\u0002￿\u00010\u0001H\u0001￿\u0001a\u0001*\u0001.\u0002￿\u0001]");

		// Token: 0x04000479 RID: 1145
		private static readonly short[] DFA32_special = global::Antlr.Runtime.DFA.UnpackEncodedString("\v￿\u0001\08￿\u0001\u0001ŋ￿}>");

		// Token: 0x0400047A RID: 1146
		private static readonly short[][] DFA32_transition;
	}
}
