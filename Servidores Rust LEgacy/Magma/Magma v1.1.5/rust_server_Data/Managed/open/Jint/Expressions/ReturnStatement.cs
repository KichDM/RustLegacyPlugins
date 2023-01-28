using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200007C RID: 124
	[global::System.Serializable]
	public class ReturnStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00028FDC File Offset: 0x000271DC
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00028FE4 File Offset: 0x000271E4
		public global::Jint.Expressions.Expression Expression
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Expression>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Expression>k__BackingField = value;
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00028FF0 File Offset: 0x000271F0
		public ReturnStatement()
		{
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00028FF8 File Offset: 0x000271F8
		public ReturnStatement(global::Jint.Expressions.Expression expression)
		{
			this.Expression = expression;
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00029008 File Offset: 0x00027208
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002A1 RID: 673
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;
	}
}
