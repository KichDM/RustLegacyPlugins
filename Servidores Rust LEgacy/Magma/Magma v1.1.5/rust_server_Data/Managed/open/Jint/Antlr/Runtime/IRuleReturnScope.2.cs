using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000B4 RID: 180
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface IRuleReturnScope<TLabel> : global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600083F RID: 2111
		[global::System.Runtime.InteropServices.ComVisible(false)]
		TLabel Start { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000840 RID: 2112
		[global::System.Runtime.InteropServices.ComVisible(false)]
		TLabel Stop { [global::System.Runtime.InteropServices.ComVisible(false)] get; }
	}
}
