using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x02000071 RID: 113
	[global::System.Serializable]
	public class ContinueStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x0600058B RID: 1419 RVA: 0x00028D8C File Offset: 0x00026F8C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00028D98 File Offset: 0x00026F98
		public ContinueStatement()
		{
		}
	}
}
