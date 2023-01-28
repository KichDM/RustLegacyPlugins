using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x0200007B RID: 123
	[global::System.Serializable]
	public class Program : global::Jint.Expressions.BlockStatement
	{
		// Token: 0x060005C0 RID: 1472 RVA: 0x00028FC8 File Offset: 0x000271C8
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00028FD4 File Offset: 0x000271D4
		public Program()
		{
		}
	}
}
