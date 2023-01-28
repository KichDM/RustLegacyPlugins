using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x02000095 RID: 149
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITokenStreamInformation
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060006B2 RID: 1714
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.IToken LastToken { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060006B3 RID: 1715
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.IToken LastRealToken { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060006B4 RID: 1716
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int MaxLookBehind { [global::System.Runtime.InteropServices.ComVisible(false)] get; }
	}
}
