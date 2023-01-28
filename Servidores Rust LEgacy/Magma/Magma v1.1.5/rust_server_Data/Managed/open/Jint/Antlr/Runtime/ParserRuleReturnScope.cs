using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000B5 RID: 181
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class ParserRuleReturnScope<TToken> : global::Antlr.Runtime.IRuleReturnScope<TToken>, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x00030B50 File Offset: 0x0002ED50
		// (set) Token: 0x06000842 RID: 2114 RVA: 0x00030B58 File Offset: 0x0002ED58
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TToken Start
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._start;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._start = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x00030B64 File Offset: 0x0002ED64
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x00030B6C File Offset: 0x0002ED6C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TToken Stop
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._stop;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._stop = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x00030B78 File Offset: 0x0002ED78
		object global::Antlr.Runtime.IRuleReturnScope.Start
		{
			get
			{
				return this.Start;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x00030B88 File Offset: 0x0002ED88
		object global::Antlr.Runtime.IRuleReturnScope.Stop
		{
			get
			{
				return this.Stop;
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00030B98 File Offset: 0x0002ED98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ParserRuleReturnScope()
		{
		}

		// Token: 0x040003A7 RID: 935
		private TToken _start;

		// Token: 0x040003A8 RID: 936
		private TToken _stop;
	}
}
