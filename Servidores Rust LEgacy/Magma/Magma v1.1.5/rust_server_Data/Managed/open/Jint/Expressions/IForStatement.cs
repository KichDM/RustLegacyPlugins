using System;

namespace Jint.Expressions
{
	// Token: 0x02000047 RID: 71
	public interface IForStatement
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600035E RID: 862
		// (set) Token: 0x0600035F RID: 863
		global::Jint.Expressions.Statement InitialisationStatement { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000360 RID: 864
		// (set) Token: 0x06000361 RID: 865
		global::Jint.Expressions.Statement Statement { get; set; }
	}
}
