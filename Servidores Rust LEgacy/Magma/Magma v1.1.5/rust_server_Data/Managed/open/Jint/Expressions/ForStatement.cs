using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000078 RID: 120
	[global::System.Serializable]
	public class ForStatement : global::Jint.Expressions.Statement, global::Jint.Expressions.IForStatement
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00028EB8 File Offset: 0x000270B8
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x00028EC0 File Offset: 0x000270C0
		public global::Jint.Expressions.Statement InitialisationStatement
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<InitialisationStatement>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<InitialisationStatement>k__BackingField = value;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00028ECC File Offset: 0x000270CC
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x00028ED4 File Offset: 0x000270D4
		public global::Jint.Expressions.Statement ConditionExpression
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<ConditionExpression>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<ConditionExpression>k__BackingField = value;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x00028EE0 File Offset: 0x000270E0
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00028EE8 File Offset: 0x000270E8
		public global::Jint.Expressions.Statement IncrementExpression
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<IncrementExpression>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<IncrementExpression>k__BackingField = value;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00028EF4 File Offset: 0x000270F4
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x00028EFC File Offset: 0x000270FC
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

		// Token: 0x060005AE RID: 1454 RVA: 0x00028F08 File Offset: 0x00027108
		public ForStatement()
		{
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00028F10 File Offset: 0x00027110
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000297 RID: 663
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <InitialisationStatement>k__BackingField;

		// Token: 0x04000298 RID: 664
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <ConditionExpression>k__BackingField;

		// Token: 0x04000299 RID: 665
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <IncrementExpression>k__BackingField;

		// Token: 0x0400029A RID: 666
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
