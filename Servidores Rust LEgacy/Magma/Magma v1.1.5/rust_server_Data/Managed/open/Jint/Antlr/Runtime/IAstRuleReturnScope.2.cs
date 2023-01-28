using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000A6 RID: 166
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface IAstRuleReturnScope<TAstLabel> : global::Antlr.Runtime.IAstRuleReturnScope, global::Antlr.Runtime.IRuleReturnScope
	{
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600078A RID: 1930
		[global::System.Runtime.InteropServices.ComVisible(false)]
		TAstLabel Tree { [global::System.Runtime.InteropServices.ComVisible(false)] get; }
	}
}
