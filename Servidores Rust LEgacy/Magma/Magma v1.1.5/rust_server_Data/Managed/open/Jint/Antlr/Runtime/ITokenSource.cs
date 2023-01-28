using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000A7 RID: 167
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITokenSource
	{
		// Token: 0x0600078B RID: 1931
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.IToken NextToken();

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600078C RID: 1932
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string SourceName { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600078D RID: 1933
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string[] TokenNames { [global::System.Runtime.InteropServices.ComVisible(false)] get; }
	}
}
