using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000086 RID: 134
	[global::System.Serializable]
	public class WhileStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x00029334 File Offset: 0x00027534
		// (set) Token: 0x06000600 RID: 1536 RVA: 0x0002933C File Offset: 0x0002753C
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

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x00029348 File Offset: 0x00027548
		// (set) Token: 0x06000602 RID: 1538 RVA: 0x00029350 File Offset: 0x00027550
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

		// Token: 0x06000603 RID: 1539 RVA: 0x0002935C File Offset: 0x0002755C
		public WhileStatement(global::Jint.Expressions.Expression condition, global::Jint.Expressions.Statement statement)
		{
			this.Condition = condition;
			this.Statement = statement;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00029374 File Offset: 0x00027574
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002C2 RID: 706
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Condition>k__BackingField;

		// Token: 0x040002C3 RID: 707
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
