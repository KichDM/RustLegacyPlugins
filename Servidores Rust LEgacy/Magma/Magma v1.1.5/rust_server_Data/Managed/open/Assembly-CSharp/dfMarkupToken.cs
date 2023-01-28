using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000823 RID: 2083
public class dfMarkupToken
{
	// Token: 0x060046A9 RID: 18089 RVA: 0x00103F4C File Offset: 0x0010214C
	protected dfMarkupToken()
	{
	}

	// Token: 0x060046AA RID: 18090 RVA: 0x00103F54 File Offset: 0x00102154
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupToken()
	{
	}

	// Token: 0x060046AB RID: 18091 RVA: 0x00103F68 File Offset: 0x00102168
	public static void Reset()
	{
		global::dfMarkupToken.poolIndex = 0;
	}

	// Token: 0x060046AC RID: 18092 RVA: 0x00103F70 File Offset: 0x00102170
	public static global::dfMarkupToken Obtain(string source, global::dfMarkupTokenType type, int startIndex, int endIndex)
	{
		if (global::dfMarkupToken.poolIndex >= global::dfMarkupToken.pool.Count - 1)
		{
			global::dfMarkupToken.pool.Add(new global::dfMarkupToken());
		}
		global::dfMarkupToken dfMarkupToken = global::dfMarkupToken.pool[global::dfMarkupToken.poolIndex++];
		dfMarkupToken.Source = source;
		dfMarkupToken.TokenType = type;
		dfMarkupToken.value = null;
		dfMarkupToken.StartOffset = startIndex;
		dfMarkupToken.EndOffset = endIndex;
		dfMarkupToken.AttributeCount = 0;
		dfMarkupToken.startAttributeIndex = 0;
		dfMarkupToken.Width = 0;
		dfMarkupToken.Height = 0;
		return dfMarkupToken;
	}

	// Token: 0x17000D2B RID: 3371
	// (get) Token: 0x060046AD RID: 18093 RVA: 0x00103FFC File Offset: 0x001021FC
	// (set) Token: 0x060046AE RID: 18094 RVA: 0x00104004 File Offset: 0x00102204
	public int AttributeCount
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<AttributeCount>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<AttributeCount>k__BackingField = value;
		}
	}

	// Token: 0x17000D2C RID: 3372
	// (get) Token: 0x060046AF RID: 18095 RVA: 0x00104010 File Offset: 0x00102210
	// (set) Token: 0x060046B0 RID: 18096 RVA: 0x00104018 File Offset: 0x00102218
	public global::dfMarkupTokenType TokenType
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TokenType>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<TokenType>k__BackingField = value;
		}
	}

	// Token: 0x17000D2D RID: 3373
	// (get) Token: 0x060046B1 RID: 18097 RVA: 0x00104024 File Offset: 0x00102224
	// (set) Token: 0x060046B2 RID: 18098 RVA: 0x0010402C File Offset: 0x0010222C
	public string Source
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Source>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Source>k__BackingField = value;
		}
	}

	// Token: 0x17000D2E RID: 3374
	// (get) Token: 0x060046B3 RID: 18099 RVA: 0x00104038 File Offset: 0x00102238
	// (set) Token: 0x060046B4 RID: 18100 RVA: 0x00104040 File Offset: 0x00102240
	public int StartOffset
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<StartOffset>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<StartOffset>k__BackingField = value;
		}
	}

	// Token: 0x17000D2F RID: 3375
	// (get) Token: 0x060046B5 RID: 18101 RVA: 0x0010404C File Offset: 0x0010224C
	// (set) Token: 0x060046B6 RID: 18102 RVA: 0x00104054 File Offset: 0x00102254
	public int EndOffset
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<EndOffset>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<EndOffset>k__BackingField = value;
		}
	}

	// Token: 0x17000D30 RID: 3376
	// (get) Token: 0x060046B7 RID: 18103 RVA: 0x00104060 File Offset: 0x00102260
	// (set) Token: 0x060046B8 RID: 18104 RVA: 0x00104068 File Offset: 0x00102268
	public int Width
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Width>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		internal set
		{
			this.<Width>k__BackingField = value;
		}
	}

	// Token: 0x17000D31 RID: 3377
	// (get) Token: 0x060046B9 RID: 18105 RVA: 0x00104074 File Offset: 0x00102274
	// (set) Token: 0x060046BA RID: 18106 RVA: 0x0010407C File Offset: 0x0010227C
	public int Height
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Height>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Height>k__BackingField = value;
		}
	}

	// Token: 0x17000D32 RID: 3378
	// (get) Token: 0x060046BB RID: 18107 RVA: 0x00104088 File Offset: 0x00102288
	public int Length
	{
		get
		{
			return this.EndOffset - this.StartOffset + 1;
		}
	}

	// Token: 0x17000D33 RID: 3379
	// (get) Token: 0x060046BC RID: 18108 RVA: 0x0010409C File Offset: 0x0010229C
	public string Value
	{
		get
		{
			if (this.value == null)
			{
				int length = global::System.Math.Min(this.EndOffset - this.StartOffset + 1, this.Source.Length - this.StartOffset);
				this.value = this.Source.Substring(this.StartOffset, length);
			}
			return this.value;
		}
	}

	// Token: 0x17000D34 RID: 3380
	public char this[int index]
	{
		get
		{
			if (index < 0 || this.StartOffset + index > this.Source.Length - 1)
			{
				return '\0';
			}
			return this.Source[this.StartOffset + index];
		}
	}

	// Token: 0x060046BE RID: 18110 RVA: 0x00104140 File Offset: 0x00102340
	public bool Matches(string text)
	{
		if (this.Length != text.Length)
		{
			return false;
		}
		int length = text.Length;
		for (int i = 0; i < length; i++)
		{
			if (char.ToLowerInvariant(text[i]) != char.ToLowerInvariant(this[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060046BF RID: 18111 RVA: 0x0010419C File Offset: 0x0010239C
	internal void AddAttribute(global::dfMarkupToken key, global::dfMarkupToken value)
	{
		global::dfMarkupTokenAttribute dfMarkupTokenAttribute = global::dfMarkupTokenAttribute.Obtain(key, value);
		if (this.AttributeCount == 0)
		{
			this.startAttributeIndex = dfMarkupTokenAttribute.Index;
		}
		this.AttributeCount++;
	}

	// Token: 0x060046C0 RID: 18112 RVA: 0x001041D8 File Offset: 0x001023D8
	public global::dfMarkupTokenAttribute GetAttribute(int index)
	{
		if (index < this.AttributeCount)
		{
			return global::dfMarkupTokenAttribute.GetAttribute(this.startAttributeIndex + index);
		}
		return null;
	}

	// Token: 0x060046C1 RID: 18113 RVA: 0x001041F8 File Offset: 0x001023F8
	public override string ToString()
	{
		return base.ToString();
	}

	// Token: 0x04002624 RID: 9764
	private static global::System.Collections.Generic.List<global::dfMarkupToken> pool = new global::System.Collections.Generic.List<global::dfMarkupToken>();

	// Token: 0x04002625 RID: 9765
	private static int poolIndex = 0;

	// Token: 0x04002626 RID: 9766
	private string value;

	// Token: 0x04002627 RID: 9767
	private int startAttributeIndex;

	// Token: 0x04002628 RID: 9768
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <AttributeCount>k__BackingField;

	// Token: 0x04002629 RID: 9769
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfMarkupTokenType <TokenType>k__BackingField;

	// Token: 0x0400262A RID: 9770
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Source>k__BackingField;

	// Token: 0x0400262B RID: 9771
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <StartOffset>k__BackingField;

	// Token: 0x0400262C RID: 9772
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <EndOffset>k__BackingField;

	// Token: 0x0400262D RID: 9773
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <Width>k__BackingField;

	// Token: 0x0400262E RID: 9774
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <Height>k__BackingField;
}
