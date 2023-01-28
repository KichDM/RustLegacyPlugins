using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000076 RID: 118
	[global::System.Serializable]
	public class ExpressionStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x00028E38 File Offset: 0x00027038
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00028E40 File Offset: 0x00027040
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

		// Token: 0x0600059C RID: 1436 RVA: 0x00028E4C File Offset: 0x0002704C
		public ExpressionStatement(global::Jint.Expressions.Expression expression)
		{
			this.Expression = expression;
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00028E5C File Offset: 0x0002705C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000293 RID: 659
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;
	}
}
