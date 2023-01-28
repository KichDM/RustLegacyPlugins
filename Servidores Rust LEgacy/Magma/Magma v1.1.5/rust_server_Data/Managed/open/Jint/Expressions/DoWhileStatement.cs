using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000075 RID: 117
	[global::System.Serializable]
	public class DoWhileStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00028DEC File Offset: 0x00026FEC
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x00028DF4 File Offset: 0x00026FF4
		public global::Jint.Expressions.Expression Condition
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Condition>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Condition>k__BackingField = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x00028E00 File Offset: 0x00027000
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x00028E08 File Offset: 0x00027008
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

		// Token: 0x06000598 RID: 1432 RVA: 0x00028E14 File Offset: 0x00027014
		public DoWhileStatement(global::Jint.Expressions.Expression condition, global::Jint.Expressions.Statement statement)
		{
			this.Condition = condition;
			this.Statement = statement;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00028E2C File Offset: 0x0002702C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000291 RID: 657
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Condition>k__BackingField;

		// Token: 0x04000292 RID: 658
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
