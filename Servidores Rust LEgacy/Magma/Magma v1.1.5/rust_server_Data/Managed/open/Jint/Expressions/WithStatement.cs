using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200002E RID: 46
	[global::System.Serializable]
	public class WithStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0001B88C File Offset: 0x00019A8C
		// (set) Token: 0x0600026C RID: 620 RVA: 0x0001B894 File Offset: 0x00019A94
		public global::Jint.Expressions.Statement Statement
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Statement>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Statement>k__BackingField = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600026D RID: 621 RVA: 0x0001B8A0 File Offset: 0x00019AA0
		// (set) Token: 0x0600026E RID: 622 RVA: 0x0001B8A8 File Offset: 0x00019AA8
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

		// Token: 0x0600026F RID: 623 RVA: 0x0001B8B4 File Offset: 0x00019AB4
		public WithStatement(global::Jint.Expressions.Expression expression, global::Jint.Expressions.Statement statement)
		{
			this.Statement = statement;
			this.Expression = expression;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0001B8CC File Offset: 0x00019ACC
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040001D6 RID: 470
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;

		// Token: 0x040001D7 RID: 471
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;
	}
}
