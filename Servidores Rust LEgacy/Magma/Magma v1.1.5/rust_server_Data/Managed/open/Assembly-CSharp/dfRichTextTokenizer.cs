using System;
using System.Collections.Generic;

// Token: 0x02000825 RID: 2085
public class dfRichTextTokenizer
{
	// Token: 0x060046C7 RID: 18119 RVA: 0x0010429C File Offset: 0x0010249C
	public dfRichTextTokenizer()
	{
	}

	// Token: 0x060046C8 RID: 18120 RVA: 0x001042B0 File Offset: 0x001024B0
	public static global::System.Collections.Generic.List<global::dfMarkupToken> Tokenize(string source)
	{
		if (global::dfRichTextTokenizer.singleton == null)
		{
			global::dfRichTextTokenizer.singleton = new global::dfRichTextTokenizer();
		}
		return global::dfRichTextTokenizer.singleton.tokenize(source);
	}

	// Token: 0x060046C9 RID: 18121 RVA: 0x001042D4 File Offset: 0x001024D4
	private global::System.Collections.Generic.List<global::dfMarkupToken> tokenize(string source)
	{
		global::dfMarkupToken.Reset();
		global::dfMarkupTokenAttribute.Reset();
		this.tokens.Clear();
		this.source = source;
		this.index = 0;
		while (this.index < source.Length)
		{
			char c = this.Peek(0);
			if (this.AtTagPosition())
			{
				global::dfMarkupToken dfMarkupToken = this.parseTag();
				if (dfMarkupToken != null)
				{
					this.tokens.Add(dfMarkupToken);
				}
			}
			else
			{
				global::dfMarkupToken dfMarkupToken2 = null;
				if (char.IsWhiteSpace(c))
				{
					if (c != '\r')
					{
						dfMarkupToken2 = this.parseWhitespace();
					}
				}
				else
				{
					dfMarkupToken2 = this.parseNonWhitespace();
				}
				if (dfMarkupToken2 == null)
				{
					this.Advance(1);
				}
				else
				{
					this.tokens.Add(dfMarkupToken2);
				}
			}
		}
		return this.tokens;
	}

	// Token: 0x060046CA RID: 18122 RVA: 0x00104398 File Offset: 0x00102598
	private bool AtTagPosition()
	{
		if (this.Peek(0) != '<')
		{
			return false;
		}
		char c = this.Peek(1);
		if (c == '/')
		{
			return char.IsLetter(this.Peek(2));
		}
		return char.IsLetter(c);
	}

	// Token: 0x060046CB RID: 18123 RVA: 0x001043E8 File Offset: 0x001025E8
	private global::dfMarkupToken parseQuotedString()
	{
		char c = this.Peek(0);
		if (c != '"' && c != '\'')
		{
			return null;
		}
		this.Advance(1);
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length && this.Advance(1) != c)
		{
			num++;
		}
		if (this.Peek(0) == c)
		{
			this.Advance(1);
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Text, startIndex, num);
	}

	// Token: 0x060046CC RID: 18124 RVA: 0x00104478 File Offset: 0x00102678
	private global::dfMarkupToken parseNonWhitespace()
	{
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length)
		{
			char c = this.Advance(1);
			if (char.IsWhiteSpace(c) || this.AtTagPosition())
			{
				break;
			}
			num++;
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Text, startIndex, num);
	}

	// Token: 0x060046CD RID: 18125 RVA: 0x001044E8 File Offset: 0x001026E8
	private global::dfMarkupToken parseWhitespace()
	{
		int num = this.index;
		int num2 = this.index;
		if (this.Peek(0) == '\n')
		{
			this.Advance(1);
			return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Newline, num, num);
		}
		while (this.index < this.source.Length)
		{
			char c = this.Advance(1);
			if (c == '\n' || c == '\r' || !char.IsWhiteSpace(c))
			{
				break;
			}
			num2++;
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Whitespace, num, num2);
	}

	// Token: 0x060046CE RID: 18126 RVA: 0x00104580 File Offset: 0x00102780
	private global::dfMarkupToken parseWord()
	{
		if (!char.IsLetter(this.Peek(0)))
		{
			return null;
		}
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length && char.IsLetter(this.Advance(1)))
		{
			num++;
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Text, startIndex, num);
	}

	// Token: 0x060046CF RID: 18127 RVA: 0x001045F0 File Offset: 0x001027F0
	private global::dfMarkupToken parseTag()
	{
		if (this.Peek(0) != '<')
		{
			return null;
		}
		char c = this.Peek(1);
		if (c == '/')
		{
			return this.parseEndTag();
		}
		this.Advance(1);
		c = this.Peek(0);
		if (!char.IsLetterOrDigit(c))
		{
			return null;
		}
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length && char.IsLetterOrDigit(this.Advance(1)))
		{
			num++;
		}
		global::dfMarkupToken dfMarkupToken = global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.StartTag, startIndex, num);
		while (this.index < this.source.Length && this.Peek(0) != '>')
		{
			c = this.Peek(0);
			if (char.IsWhiteSpace(c))
			{
				this.parseWhitespace();
			}
			else
			{
				global::dfMarkupToken dfMarkupToken2 = this.parseWord();
				if (dfMarkupToken2 == null)
				{
					this.Advance(1);
				}
				else
				{
					c = this.Peek(0);
					if (c != '=')
					{
						dfMarkupToken.AddAttribute(dfMarkupToken2, dfMarkupToken2);
					}
					else
					{
						c = this.Advance(1);
						global::dfMarkupToken dfMarkupToken3;
						if (c == '"' || c == '\'')
						{
							dfMarkupToken3 = this.parseQuotedString();
						}
						else
						{
							dfMarkupToken3 = this.parseAttributeValue();
						}
						dfMarkupToken.AddAttribute(dfMarkupToken2, dfMarkupToken3 ?? dfMarkupToken2);
					}
				}
			}
		}
		if (this.Peek(0) == '>')
		{
			this.Advance(1);
		}
		return dfMarkupToken;
	}

	// Token: 0x060046D0 RID: 18128 RVA: 0x0010476C File Offset: 0x0010296C
	private global::dfMarkupToken parseAttributeValue()
	{
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length)
		{
			char c = this.Advance(1);
			if (c == '>' || char.IsWhiteSpace(c))
			{
				break;
			}
			num++;
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Text, startIndex, num);
	}

	// Token: 0x060046D1 RID: 18129 RVA: 0x001047D8 File Offset: 0x001029D8
	private global::dfMarkupToken parseEndTag()
	{
		this.Advance(2);
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length && char.IsLetterOrDigit(this.Advance(1)))
		{
			num++;
		}
		if (this.Peek(0) == '>')
		{
			this.Advance(1);
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.EndTag, startIndex, num);
	}

	// Token: 0x060046D2 RID: 18130 RVA: 0x00104854 File Offset: 0x00102A54
	private char Peek(int offset = 0)
	{
		if (this.index + offset > this.source.Length - 1)
		{
			return '\0';
		}
		return this.source[this.index + offset];
	}

	// Token: 0x060046D3 RID: 18131 RVA: 0x00104888 File Offset: 0x00102A88
	private char Advance(int amount = 1)
	{
		this.index += amount;
		return this.Peek(0);
	}

	// Token: 0x04002634 RID: 9780
	private static global::dfRichTextTokenizer singleton;

	// Token: 0x04002635 RID: 9781
	private global::System.Collections.Generic.List<global::dfMarkupToken> tokens = new global::System.Collections.Generic.List<global::dfMarkupToken>();

	// Token: 0x04002636 RID: 9782
	private string source;

	// Token: 0x04002637 RID: 9783
	private int index;
}
