using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Antlr.Runtime
{
	// Token: 0x0200009B RID: 155
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class CommonToken : global::Antlr.Runtime.IToken
	{
		// Token: 0x06000702 RID: 1794 RVA: 0x0002D9B8 File Offset: 0x0002BBB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonToken()
		{
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0002D9D0 File Offset: 0x0002BBD0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonToken(int type)
		{
			this.type = type;
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0002D9F0 File Offset: 0x0002BBF0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonToken(global::Antlr.Runtime.ICharStream input, int type, int channel, int start, int stop)
		{
			this.input = input;
			this.type = type;
			this.channel = channel;
			this.start = start;
			this.stop = stop;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0002DA2C File Offset: 0x0002BC2C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonToken(int type, string text)
		{
			this.type = type;
			this.channel = 0;
			this.text = text;
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0002DA58 File Offset: 0x0002BC58
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonToken(global::Antlr.Runtime.IToken oldToken)
		{
			this.text = oldToken.Text;
			this.type = oldToken.Type;
			this.line = oldToken.Line;
			this.index = oldToken.TokenIndex;
			this.charPositionInLine = oldToken.CharPositionInLine;
			this.channel = oldToken.Channel;
			this.input = oldToken.InputStream;
			if (oldToken is global::Antlr.Runtime.CommonToken)
			{
				this.start = ((global::Antlr.Runtime.CommonToken)oldToken).start;
				this.stop = ((global::Antlr.Runtime.CommonToken)oldToken).stop;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0002DB00 File Offset: 0x0002BD00
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x0002DB98 File Offset: 0x0002BD98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string Text
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.text != null)
				{
					return this.text;
				}
				if (this.input == null)
				{
					return null;
				}
				if (this.start < this.input.Count && this.stop < this.input.Count)
				{
					this.text = this.input.Substring(this.start, this.stop - this.start + 1);
				}
				else
				{
					this.text = "<EOF>";
				}
				return this.text;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.text = value;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x0002DBA4 File Offset: 0x0002BDA4
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x0002DBAC File Offset: 0x0002BDAC
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

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x0002DBB8 File Offset: 0x0002BDB8
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x0002DBC0 File Offset: 0x0002BDC0
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

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x0002DBCC File Offset: 0x0002BDCC
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x0002DBD4 File Offset: 0x0002BDD4
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

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x0002DBE0 File Offset: 0x0002BDE0
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x0002DBE8 File Offset: 0x0002BDE8
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

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x0002DBF4 File Offset: 0x0002BDF4
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x0002DBFC File Offset: 0x0002BDFC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int StartIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.start;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.start = value;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x0002DC08 File Offset: 0x0002BE08
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x0002DC10 File Offset: 0x0002BE10
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int StopIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.stop;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.stop = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x0002DC1C File Offset: 0x0002BE1C
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x0002DC24 File Offset: 0x0002BE24
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

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x0002DC30 File Offset: 0x0002BE30
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x0002DC38 File Offset: 0x0002BE38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.ICharStream InputStream
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.input;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.input = value;
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0002DC44 File Offset: 0x0002BE44
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
				text2 = global::System.Text.RegularExpressions.Regex.Replace(text2, "\n", "\\\\n");
				text2 = global::System.Text.RegularExpressions.Regex.Replace(text2, "\r", "\\\\r");
				text2 = global::System.Text.RegularExpressions.Regex.Replace(text2, "\t", "\\\\t");
			}
			else
			{
				text2 = "<no text>";
			}
			return string.Concat(new object[]
			{
				"[@",
				this.TokenIndex,
				",",
				this.start,
				":",
				this.stop,
				"='",
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

		// Token: 0x0600071A RID: 1818 RVA: 0x0002DD84 File Offset: 0x0002BF84
		[global::System.Runtime.Serialization.OnSerializing]
		internal void OnSerializing(global::System.Runtime.Serialization.StreamingContext context)
		{
			if (this.text == null)
			{
				this.text = this.Text;
			}
		}

		// Token: 0x04000369 RID: 873
		private int type;

		// Token: 0x0400036A RID: 874
		private int line;

		// Token: 0x0400036B RID: 875
		private int charPositionInLine = -1;

		// Token: 0x0400036C RID: 876
		private int channel;

		// Token: 0x0400036D RID: 877
		[global::System.NonSerialized]
		private global::Antlr.Runtime.ICharStream input;

		// Token: 0x0400036E RID: 878
		private string text;

		// Token: 0x0400036F RID: 879
		private int index = -1;

		// Token: 0x04000370 RID: 880
		private int start;

		// Token: 0x04000371 RID: 881
		private int stop;
	}
}
