using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x02000094 RID: 148
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITokenStream : global::Antlr.Runtime.IIntStream
	{
		// Token: 0x060006AC RID: 1708
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.IToken LT(int k);

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060006AD RID: 1709
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Range { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x060006AE RID: 1710
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.IToken Get(int i);

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060006AF RID: 1711
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.ITokenSource TokenSource { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x060006B0 RID: 1712
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string ToString(int start, int stop);

		// Token: 0x060006B1 RID: 1713
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string ToString(global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop);
	}
}
