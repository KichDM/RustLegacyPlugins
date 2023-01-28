using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D9 RID: 217
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class TreeRuleReturnScope<TTree> : global::Antlr.Runtime.IRuleReturnScope<TTree>, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x000351A8 File Offset: 0x000333A8
		// (set) Token: 0x060009F0 RID: 2544 RVA: 0x000351B0 File Offset: 0x000333B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TTree Start
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

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x000351BC File Offset: 0x000333BC
		object global::Antlr.Runtime.IRuleReturnScope.Start
		{
			get
			{
				return this.Start;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x000351CC File Offset: 0x000333CC
		TTree global::Antlr.Runtime.IRuleReturnScope<!0>.Stop
		{
			get
			{
				return default(TTree);
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x000351E8 File Offset: 0x000333E8
		object global::Antlr.Runtime.IRuleReturnScope.Stop
		{
			get
			{
				return default(TTree);
			}
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00035208 File Offset: 0x00033408
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeRuleReturnScope()
		{
		}

		// Token: 0x0400042A RID: 1066
		private TTree _start;
	}
}
