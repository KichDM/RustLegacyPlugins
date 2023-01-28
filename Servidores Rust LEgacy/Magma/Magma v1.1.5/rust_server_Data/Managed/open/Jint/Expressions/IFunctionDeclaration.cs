using System;
using System.Collections.Generic;

namespace Jint.Expressions
{
	// Token: 0x0200002B RID: 43
	public interface IFunctionDeclaration
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600025D RID: 605
		// (set) Token: 0x0600025E RID: 606
		string Name { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600025F RID: 607
		// (set) Token: 0x06000260 RID: 608
		global::System.Collections.Generic.List<string> Parameters { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000261 RID: 609
		// (set) Token: 0x06000262 RID: 610
		global::Jint.Expressions.Statement Statement { get; set; }
	}
}
