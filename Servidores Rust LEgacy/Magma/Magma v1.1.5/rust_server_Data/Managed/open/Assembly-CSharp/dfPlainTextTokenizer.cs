using System;
using System.Collections.Generic;

// Token: 0x02000827 RID: 2087
public class dfPlainTextTokenizer
{
	// Token: 0x060046E4 RID: 18148 RVA: 0x00104FC8 File Offset: 0x001031C8
	public dfPlainTextTokenizer()
	{
	}

	// Token: 0x060046E5 RID: 18149 RVA: 0x00104FDC File Offset: 0x001031DC
	public static global::System.Collections.Generic.List<global::dfMarkupToken> Tokenize(string source)
	{
		if (global::dfPlainTextTokenizer.singleton == null)
		{
			global::dfPlainTextTokenizer.singleton = new global::dfPlainTextTokenizer();
		}
		return global::dfPlainTextTokenizer.singleton.tokenize(source);
	}

	// Token: 0x060046E6 RID: 18150 RVA: 0x00105000 File Offset: 0x00103200
	private global::System.Collections.Generic.List<global::dfMarkupToken> tokenize(string source)
	{
		global::dfMarkupToken.Reset();
		global::dfMarkupTokenAttribute.Reset();
		this.tokens.Clear();
		int i = 0;
		int num = 0;
		int length = source.Length;
		while (i < length)
		{
			if (source[i] == '\r')
			{
				i++;
				num = i;
			}
			else
			{
				while (i < length && !char.IsWhiteSpace(source[i]))
				{
					i++;
				}
				if (i > num)
				{
					this.tokens.Add(global::dfMarkupToken.Obtain(source, global::dfMarkupTokenType.Text, num, i - 1));
					num = i;
				}
				if (i < length && source[i] == '\n')
				{
					this.tokens.Add(global::dfMarkupToken.Obtain(source, global::dfMarkupTokenType.Newline, i, i));
					i++;
					num = i;
				}
				while (i < length && source[i] != '\n' && source[i] != '\r' && char.IsWhiteSpace(source[i]))
				{
					i++;
				}
				if (i > num)
				{
					this.tokens.Add(global::dfMarkupToken.Obtain(source, global::dfMarkupTokenType.Whitespace, num, i - 1));
					num = i;
				}
			}
		}
		return this.tokens;
	}

	// Token: 0x0400263D RID: 9789
	private static global::dfPlainTextTokenizer singleton;

	// Token: 0x0400263E RID: 9790
	private global::System.Collections.Generic.List<global::dfMarkupToken> tokens = new global::System.Collections.Generic.List<global::dfMarkupToken>();
}
