using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

// Token: 0x02000866 RID: 2150
public class dfMarkupString : global::dfMarkupElement
{
	// Token: 0x06004A92 RID: 19090 RVA: 0x00118570 File Offset: 0x00116770
	public dfMarkupString(string text)
	{
		this.Text = this.processWhitespace(global::dfMarkupEntity.Replace(text));
		this.isWhitespace = global::dfMarkupString.whitespacePattern.IsMatch(this.Text);
	}

	// Token: 0x06004A93 RID: 19091 RVA: 0x001185AC File Offset: 0x001167AC
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupString()
	{
	}

	// Token: 0x17000DF6 RID: 3574
	// (get) Token: 0x06004A94 RID: 19092 RVA: 0x001185D4 File Offset: 0x001167D4
	// (set) Token: 0x06004A95 RID: 19093 RVA: 0x001185DC File Offset: 0x001167DC
	public string Text
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Text>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Text>k__BackingField = value;
		}
	}

	// Token: 0x17000DF7 RID: 3575
	// (get) Token: 0x06004A96 RID: 19094 RVA: 0x001185E8 File Offset: 0x001167E8
	public bool IsWhitespace
	{
		get
		{
			return this.isWhitespace;
		}
	}

	// Token: 0x06004A97 RID: 19095 RVA: 0x001185F0 File Offset: 0x001167F0
	public override string ToString()
	{
		return this.Text;
	}

	// Token: 0x06004A98 RID: 19096 RVA: 0x001185F8 File Offset: 0x001167F8
	internal global::dfMarkupElement SplitWords()
	{
		global::dfMarkupTagSpan dfMarkupTagSpan = global::dfMarkupTagSpan.Obtain();
		int i = 0;
		int num = 0;
		int length = this.Text.Length;
		while (i < length)
		{
			while (i < length && !char.IsWhiteSpace(this.Text[i]))
			{
				i++;
			}
			if (i > num)
			{
				dfMarkupTagSpan.AddChildNode(global::dfMarkupString.Obtain(this.Text.Substring(num, i - num)));
				num = i;
			}
			while (i < length && this.Text[i] != '\n' && char.IsWhiteSpace(this.Text[i]))
			{
				i++;
			}
			if (i > num)
			{
				dfMarkupTagSpan.AddChildNode(global::dfMarkupString.Obtain(this.Text.Substring(num, i - num)));
				num = i;
			}
			if (i < length && this.Text[i] == '\n')
			{
				dfMarkupTagSpan.AddChildNode(global::dfMarkupString.Obtain("\n"));
				i = (num = i + 1);
			}
		}
		return dfMarkupTagSpan;
	}

	// Token: 0x06004A99 RID: 19097 RVA: 0x00118700 File Offset: 0x00116900
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		if (style.Font == null)
		{
			return;
		}
		string text = (!style.PreserveWhitespace && this.isWhitespace) ? " " : this.Text;
		global::dfMarkupBoxText dfMarkupBoxText = global::dfMarkupBoxText.Obtain(this, global::dfMarkupDisplayType.inline, style);
		dfMarkupBoxText.SetText(text);
		container.AddChild(dfMarkupBoxText);
	}

	// Token: 0x06004A9A RID: 19098 RVA: 0x00118760 File Offset: 0x00116960
	internal static global::dfMarkupString Obtain(string text)
	{
		if (global::dfMarkupString.objectPool.Count > 0)
		{
			global::dfMarkupString dfMarkupString = global::dfMarkupString.objectPool.Dequeue();
			dfMarkupString.Text = global::dfMarkupEntity.Replace(text);
			dfMarkupString.isWhitespace = global::dfMarkupString.whitespacePattern.IsMatch(dfMarkupString.Text);
			return dfMarkupString;
		}
		return new global::dfMarkupString(text);
	}

	// Token: 0x06004A9B RID: 19099 RVA: 0x001187B4 File Offset: 0x001169B4
	internal override void Release()
	{
		base.Release();
		global::dfMarkupString.objectPool.Enqueue(this);
	}

	// Token: 0x06004A9C RID: 19100 RVA: 0x001187C8 File Offset: 0x001169C8
	private string processWhitespace(string text)
	{
		global::dfMarkupString.buffer.Length = 0;
		global::dfMarkupString.buffer.Append(text);
		global::dfMarkupString.buffer.Replace("\r\n", "\n");
		global::dfMarkupString.buffer.Replace("\r", "\n");
		global::dfMarkupString.buffer.Replace("\t", "    ");
		return global::dfMarkupString.buffer.ToString();
	}

	// Token: 0x040027B4 RID: 10164
	private static global::System.Text.StringBuilder buffer = new global::System.Text.StringBuilder();

	// Token: 0x040027B5 RID: 10165
	private static global::System.Text.RegularExpressions.Regex whitespacePattern = new global::System.Text.RegularExpressions.Regex("\\s+");

	// Token: 0x040027B6 RID: 10166
	private static global::System.Collections.Generic.Queue<global::dfMarkupString> objectPool = new global::System.Collections.Generic.Queue<global::dfMarkupString>();

	// Token: 0x040027B7 RID: 10167
	private bool isWhitespace;

	// Token: 0x040027B8 RID: 10168
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <Text>k__BackingField;
}
