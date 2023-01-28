using System;
using System.Text.RegularExpressions;

namespace Jint.Native
{
	// Token: 0x0200005C RID: 92
	[global::System.Serializable]
	public class JsRegExp : global::Jint.Native.JsObject
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00025A84 File Offset: 0x00023C84
		public bool IsGlobal
		{
			get
			{
				return this["global"].ToBoolean();
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00025A98 File Offset: 0x00023C98
		public bool IsIgnoreCase
		{
			get
			{
				return (this.options & global::System.Text.RegularExpressions.RegexOptions.IgnoreCase) == global::System.Text.RegularExpressions.RegexOptions.IgnoreCase;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00025AA8 File Offset: 0x00023CA8
		public bool IsMultiline
		{
			get
			{
				return (this.options & global::System.Text.RegularExpressions.RegexOptions.Multiline) == global::System.Text.RegularExpressions.RegexOptions.Multiline;
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00025AB8 File Offset: 0x00023CB8
		public JsRegExp(global::Jint.Native.JsObject prototype) : base(prototype)
		{
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00025AC4 File Offset: 0x00023CC4
		public JsRegExp(string pattern, global::Jint.Native.JsObject prototype) : this(pattern, false, false, false, prototype)
		{
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00025AD4 File Offset: 0x00023CD4
		public JsRegExp(string pattern, bool g, bool i, bool m, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.options = global::System.Text.RegularExpressions.RegexOptions.ECMAScript;
			if (m)
			{
				this.options |= global::System.Text.RegularExpressions.RegexOptions.Multiline;
			}
			if (i)
			{
				this.options |= global::System.Text.RegularExpressions.RegexOptions.IgnoreCase;
			}
			this.pattern = pattern;
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x00025B28 File Offset: 0x00023D28
		public string Pattern
		{
			get
			{
				return this.pattern;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x00025B30 File Offset: 0x00023D30
		public global::System.Text.RegularExpressions.Regex Regex
		{
			get
			{
				return new global::System.Text.RegularExpressions.Regex(this.pattern, this.options);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00025B44 File Offset: 0x00023D44
		public global::System.Text.RegularExpressions.RegexOptions Options
		{
			get
			{
				return this.options;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00025B4C File Offset: 0x00023D4C
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00025B50 File Offset: 0x00023D50
		public override object Value
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00025B54 File Offset: 0x00023D54
		public override string ToSource()
		{
			return "/" + this.pattern.ToString() + "/";
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00025B70 File Offset: 0x00023D70
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"/",
				this.pattern.ToString(),
				"/",
				this.IsGlobal ? "g" : string.Empty,
				this.IsIgnoreCase ? "i" : string.Empty,
				this.IsMultiline ? "m" : string.Empty
			});
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00025C10 File Offset: 0x00023E10
		public override string Class
		{
			get
			{
				return "RegExp";
			}
		}

		// Token: 0x04000224 RID: 548
		private string pattern;

		// Token: 0x04000225 RID: 549
		private global::System.Text.RegularExpressions.RegexOptions options;
	}
}
