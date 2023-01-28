using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x0200007F RID: 127
	[global::System.Serializable]
	public class TernaryExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x060005D5 RID: 1493 RVA: 0x000290DC File Offset: 0x000272DC
		public TernaryExpression(global::Jint.Expressions.Expression leftExpression, global::Jint.Expressions.Expression middleExpression, global::Jint.Expressions.Expression rightExpression)
		{
			this.leftExpression = leftExpression;
			this.middleExpression = middleExpression;
			this.rightExpression = rightExpression;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x000290FC File Offset: 0x000272FC
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x00029104 File Offset: 0x00027304
		public global::Jint.Expressions.Expression LeftExpression
		{
			get
			{
				return this.leftExpression;
			}
			set
			{
				this.leftExpression = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00029110 File Offset: 0x00027310
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x00029118 File Offset: 0x00027318
		public global::Jint.Expressions.Expression MiddleExpression
		{
			get
			{
				return this.middleExpression;
			}
			set
			{
				this.middleExpression = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00029124 File Offset: 0x00027324
		// (set) Token: 0x060005DB RID: 1499 RVA: 0x0002912C File Offset: 0x0002732C
		public global::Jint.Expressions.Expression RightExpression
		{
			get
			{
				return this.rightExpression;
			}
			set
			{
				this.rightExpression = value;
			}
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00029138 File Offset: 0x00027338
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x00029144 File Offset: 0x00027344
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				this.leftExpression.ToString(),
				" (",
				this.middleExpression.ToString(),
				", ",
				this.rightExpression.ToString(),
				")"
			});
		}

		// Token: 0x040002A6 RID: 678
		private global::Jint.Expressions.Expression leftExpression;

		// Token: 0x040002A7 RID: 679
		private global::Jint.Expressions.Expression middleExpression;

		// Token: 0x040002A8 RID: 680
		private global::Jint.Expressions.Expression rightExpression;
	}
}
