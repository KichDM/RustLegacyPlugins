using System;
using System.Collections.Generic;

// Token: 0x02000826 RID: 2086
public class dfMarkupTokenizer
{
	// Token: 0x060046D4 RID: 18132 RVA: 0x001048A0 File Offset: 0x00102AA0
	public dfMarkupTokenizer()
	{
	}

	// Token: 0x060046D5 RID: 18133 RVA: 0x001048B4 File Offset: 0x00102AB4
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupTokenizer()
	{
	}

	// Token: 0x060046D6 RID: 18134 RVA: 0x001048E4 File Offset: 0x00102AE4
	public static global::System.Collections.Generic.List<global::dfMarkupToken> Tokenize(string source)
	{
		if (global::dfMarkupTokenizer.singleton == null)
		{
			global::dfMarkupTokenizer.singleton = new global::dfMarkupTokenizer();
		}
		return global::dfMarkupTokenizer.singleton.tokenize(source);
	}

	// Token: 0x060046D7 RID: 18135 RVA: 0x00104908 File Offset: 0x00102B08
	private global::System.Collections.Generic.List<global::dfMarkupToken> tokenize(string source)
	{
		this.reset();
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

	// Token: 0x060046D8 RID: 18136 RVA: 0x001049C0 File Offset: 0x00102BC0
	private void reset()
	{
		global::dfMarkupToken.Reset();
		global::dfMarkupTokenAttribute.Reset();
		this.tokens.Clear();
	}

	// Token: 0x060046D9 RID: 18137 RVA: 0x001049D8 File Offset: 0x00102BD8
	private bool AtTagPosition()
	{
		if (this.Peek(0) != '[')
		{
			return false;
		}
		char c = this.Peek(1);
		if (c == '/')
		{
			return char.IsLetter(this.Peek(2)) && this.isValidTag(this.index + 2, true);
		}
		return char.IsLetter(c) && this.isValidTag(this.index + 1, false);
	}

	// Token: 0x060046DA RID: 18138 RVA: 0x00104A44 File Offset: 0x00102C44
	private bool isValidTag(int index, bool endTag)
	{
		for (int i = 0; i < global::dfMarkupTokenizer.validTags.Count; i++)
		{
			string text = global::dfMarkupTokenizer.validTags[i];
			bool flag = true;
			int num = 0;
			while (num < text.Length - 1 && num + index < this.source.Length - 1)
			{
				if (!endTag && this.source[num + index] == ' ')
				{
					break;
				}
				if (this.source[num + index] == ']')
				{
					break;
				}
				if (char.ToLowerInvariant(text[num]) != char.ToLowerInvariant(this.source[num + index]))
				{
					flag = false;
					break;
				}
				num++;
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060046DB RID: 18139 RVA: 0x00104B18 File Offset: 0x00102D18
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

	// Token: 0x060046DC RID: 18140 RVA: 0x00104BA8 File Offset: 0x00102DA8
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

	// Token: 0x060046DD RID: 18141 RVA: 0x00104C18 File Offset: 0x00102E18
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

	// Token: 0x060046DE RID: 18142 RVA: 0x00104CB0 File Offset: 0x00102EB0
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

	// Token: 0x060046DF RID: 18143 RVA: 0x00104D20 File Offset: 0x00102F20
	private global::dfMarkupToken parseTag()
	{
		if (this.Peek(0) != '[')
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
		if (this.index < this.source.Length && this.Peek(0) != ']')
		{
			c = this.Peek(0);
			if (char.IsWhiteSpace(c))
			{
				this.parseWhitespace();
			}
			int startIndex2 = this.index;
			int num2 = this.index;
			if (this.Peek(0) == '"')
			{
				global::dfMarkupToken dfMarkupToken2 = this.parseQuotedString();
				dfMarkupToken.AddAttribute(dfMarkupToken2, dfMarkupToken2);
			}
			else
			{
				while (this.index < this.source.Length && this.Advance(1) != ']')
				{
					num2++;
				}
				global::dfMarkupToken dfMarkupToken3 = global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Text, startIndex2, num2);
				dfMarkupToken.AddAttribute(dfMarkupToken3, dfMarkupToken3);
			}
		}
		if (this.Peek(0) == ']')
		{
			this.Advance(1);
		}
		return dfMarkupToken;
	}

	// Token: 0x060046E0 RID: 18144 RVA: 0x00104E94 File Offset: 0x00103094
	private global::dfMarkupToken parseAttributeValue()
	{
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length)
		{
			char c = this.Advance(1);
			if (c == ']' || char.IsWhiteSpace(c))
			{
				break;
			}
			num++;
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.Text, startIndex, num);
	}

	// Token: 0x060046E1 RID: 18145 RVA: 0x00104F00 File Offset: 0x00103100
	private global::dfMarkupToken parseEndTag()
	{
		this.Advance(2);
		int startIndex = this.index;
		int num = this.index;
		while (this.index < this.source.Length && char.IsLetterOrDigit(this.Advance(1)))
		{
			num++;
		}
		if (this.Peek(0) == ']')
		{
			this.Advance(1);
		}
		return global::dfMarkupToken.Obtain(this.source, global::dfMarkupTokenType.EndTag, startIndex, num);
	}

	// Token: 0x060046E2 RID: 18146 RVA: 0x00104F7C File Offset: 0x0010317C
	private char Peek(int offset = 0)
	{
		if (this.index + offset > this.source.Length - 1)
		{
			return '\0';
		}
		return this.source[this.index + offset];
	}

	// Token: 0x060046E3 RID: 18147 RVA: 0x00104FB0 File Offset: 0x001031B0
	private char Advance(int amount = 1)
	{
		this.index += amount;
		return this.Peek(0);
	}

	// Token: 0x04002638 RID: 9784
	private static global::dfMarkupTokenizer singleton;

	// Token: 0x04002639 RID: 9785
	private static global::System.Collections.Generic.List<string> validTags = new global::System.Collections.Generic.List<string>
	{
		"color",
		"sprite"
	};

	// Token: 0x0400263A RID: 9786
	private global::System.Collections.Generic.List<global::dfMarkupToken> tokens = new global::System.Collections.Generic.List<global::dfMarkupToken>();

	// Token: 0x0400263B RID: 9787
	private string source;

	// Token: 0x0400263C RID: 9788
	private int index;
}
