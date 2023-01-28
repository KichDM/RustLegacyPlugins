using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200006E RID: 110
	[global::System.Serializable]
	public class AssignmentExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00028CFC File Offset: 0x00026EFC
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x00028D04 File Offset: 0x00026F04
		public global::Jint.Expressions.Expression Left
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Left>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Left>k__BackingField = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x00028D10 File Offset: 0x00026F10
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x00028D18 File Offset: 0x00026F18
		public global::Jint.Expressions.Expression Right
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Right>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Right>k__BackingField = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x00028D24 File Offset: 0x00026F24
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x00028D2C File Offset: 0x00026F2C
		public global::Jint.Expressions.AssignmentOperator AssignmentOperator
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<AssignmentOperator>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<AssignmentOperator>k__BackingField = value;
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00028D38 File Offset: 0x00026F38
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00028D44 File Offset: 0x00026F44
		public AssignmentExpression()
		{
		}

		// Token: 0x0400027E RID: 638
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Left>k__BackingField;

		// Token: 0x0400027F RID: 639
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Right>k__BackingField;

		// Token: 0x04000280 RID: 640
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.AssignmentOperator <AssignmentOperator>k__BackingField;
	}
}
