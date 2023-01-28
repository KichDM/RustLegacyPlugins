using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x02000099 RID: 153
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface IToken
	{
		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060006D9 RID: 1753
		// (set) Token: 0x060006DA RID: 1754
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string Text { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060006DB RID: 1755
		// (set) Token: 0x060006DC RID: 1756
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Type { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060006DD RID: 1757
		// (set) Token: 0x060006DE RID: 1758
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Line { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060006DF RID: 1759
		// (set) Token: 0x060006E0 RID: 1760
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int CharPositionInLine { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060006E1 RID: 1761
		// (set) Token: 0x060006E2 RID: 1762
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Channel { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060006E3 RID: 1763
		// (set) Token: 0x060006E4 RID: 1764
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int StartIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060006E5 RID: 1765
		// (set) Token: 0x060006E6 RID: 1766
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int StopIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060006E7 RID: 1767
		// (set) Token: 0x060006E8 RID: 1768
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int TokenIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060006E9 RID: 1769
		// (set) Token: 0x060006EA RID: 1770
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.ICharStream InputStream { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }
	}
}
