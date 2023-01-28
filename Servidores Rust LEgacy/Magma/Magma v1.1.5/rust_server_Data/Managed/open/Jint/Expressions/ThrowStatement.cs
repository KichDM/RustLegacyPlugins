using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000080 RID: 128
	[global::System.Serializable]
	public class ThrowStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x000291BC File Offset: 0x000273BC
		// (set) Token: 0x060005DF RID: 1503 RVA: 0x000291C4 File Offset: 0x000273C4
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

		// Token: 0x060005E0 RID: 1504 RVA: 0x000291D0 File Offset: 0x000273D0
		public ThrowStatement(global::Jint.Expressions.Expression expression)
		{
			this.Expression = expression;
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000291E0 File Offset: 0x000273E0
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002A9 RID: 681
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;
	}
}
