using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x02000072 RID: 114
	[global::System.Serializable]
	public class BreakStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x0600058D RID: 1421 RVA: 0x00028DA0 File Offset: 0x00026FA0
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00028DAC File Offset: 0x00026FAC
		public BreakStatement()
		{
		}
	}
}
