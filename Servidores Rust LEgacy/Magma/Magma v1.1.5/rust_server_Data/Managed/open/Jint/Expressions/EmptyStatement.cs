using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x02000074 RID: 116
	[global::System.Serializable]
	public class EmptyStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x06000592 RID: 1426 RVA: 0x00028DD8 File Offset: 0x00026FD8
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00028DE4 File Offset: 0x00026FE4
		public EmptyStatement()
		{
		}
	}
}
