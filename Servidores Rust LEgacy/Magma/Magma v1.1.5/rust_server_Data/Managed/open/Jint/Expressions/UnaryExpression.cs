using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x02000082 RID: 130
	[global::System.Serializable]
	public class UnaryExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x060005EA RID: 1514 RVA: 0x0002923C File Offset: 0x0002743C
		public UnaryExpression(global::Jint.Expressions.UnaryExpressionType type, global::Jint.Expressions.Expression expression)
		{
			this.type = type;
			this.expression = expression;
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x00029254 File Offset: 0x00027454
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x0002925C File Offset: 0x0002745C
		public global::Jint.Expressions.Expression Expression
		{
			get
			{
				return this.expression;
			}
			set
			{
				this.expression = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x00029268 File Offset: 0x00027468
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x00029270 File Offset: 0x00027470
		public global::Jint.Expressions.UnaryExpressionType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0002927C File Offset: 0x0002747C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002AD RID: 685
		private global::Jint.Expressions.Expression expression;

		// Token: 0x040002AE RID: 686
		private global::Jint.Expressions.UnaryExpressionType type;
	}
}
