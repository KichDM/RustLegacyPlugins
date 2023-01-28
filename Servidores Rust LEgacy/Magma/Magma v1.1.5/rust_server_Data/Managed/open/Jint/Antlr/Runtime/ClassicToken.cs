using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x0200009A RID: 154
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class ClassicToken : global::Antlr.Runtime.IToken
	{
		// Token: 0x060006EB RID: 1771 RVA: 0x0002D77C File Offset: 0x0002B97C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ClassicToken(int type)
		{
			this.type = type;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0002D78C File Offset: 0x0002B98C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ClassicToken(global::Antlr.Runtime.IToken oldToken)
		{
			this.text = oldToken.Text;
			this.type = oldToken.Type;
			this.line = oldToken.Line;
			this.charPositionInLine = oldToken.CharPositionInLine;
			this.channel = oldToken.Channel;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0002D7E0 File Offset: 0x0002B9E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ClassicToken(int type, string text)
		{
			this.type = type;
			this.text = text;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0002D7F8 File Offset: 0x0002B9F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ClassicToken(int type, string text, int channel)
		{
			this.type = type;
			this.text = text;
			this.channel = channel;
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x0002D818 File Offset: 0x0002BA18
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x0002D820 File Offset: 0x0002BA20
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string Text
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.text;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.text = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0002D82C File Offset: 0x0002BA2C
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x0002D834 File Offset: 0x0002BA34
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Type
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.type;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.type = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0002D840 File Offset: 0x0002BA40
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x0002D848 File Offset: 0x0002BA48
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Line
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.line;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.line = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x0002D854 File Offset: 0x0002BA54
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x0002D85C File Offset: 0x0002BA5C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int CharPositionInLine
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.charPositionInLine;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.charPositionInLine = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x0002D868 File Offset: 0x0002BA68
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x0002D870 File Offset: 0x0002BA70
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Channel
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.channel;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.channel = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x0002D87C File Offset: 0x0002BA7C
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x0002D880 File Offset: 0x0002BA80
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int StartIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return -1;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x0002D884 File Offset: 0x0002BA84
		// (set) Token: 0x060006FC RID: 1788 RVA: 0x0002D888 File Offset: 0x0002BA88
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int StopIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return -1;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x0002D88C File Offset: 0x0002BA8C
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x0002D894 File Offset: 0x0002BA94
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int TokenIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.index;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.index = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x0002D8A0 File Offset: 0x0002BAA0
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x0002D8A4 File Offset: 0x0002BAA4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.ICharStream InputStream
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return null;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0002D8A8 File Offset: 0x0002BAA8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			string text = "";
			if (this.channel > 0)
			{
				text = ",channel=" + this.channel;
			}
			string text2 = this.Text;
			if (text2 != null)
			{
				text2 = text2.Replace("\n", "\\\\n");
				text2 = text2.Replace("\r", "\\\\r");
				text2 = text2.Replace("\t", "\\\\t");
			}
			else
			{
				text2 = "<no text>";
			}
			return string.Concat(new object[]
			{
				"[@",
				this.TokenIndex,
				",'",
				text2,
				"',<",
				this.type,
				">",
				text,
				",",
				this.line,
				":",
				this.CharPositionInLine,
				"]"
			});
		}

		// Token: 0x04000363 RID: 867
		private string text;

		// Token: 0x04000364 RID: 868
		private int type;

		// Token: 0x04000365 RID: 869
		private int line;

		// Token: 0x04000366 RID: 870
		private int charPositionInLine;

		// Token: 0x04000367 RID: 871
		private int channel;

		// Token: 0x04000368 RID: 872
		private int index;
	}
}
