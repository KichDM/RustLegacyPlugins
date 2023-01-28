using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x0200006A RID: 106
	[global::System.Serializable]
	public class BinaryExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x0600056C RID: 1388 RVA: 0x00028BA4 File Offset: 0x00026DA4
		public BinaryExpression(global::Jint.Expressions.BinaryExpressionType type, global::Jint.Expressions.Expression leftExpression, global::Jint.Expressions.Expression rightExpression)
		{
			this.type = type;
			this.leftExpression = leftExpression;
			this.rightExpression = rightExpression;
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x00028BC4 File Offset: 0x00026DC4
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x00028BCC File Offset: 0x00026DCC
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x00028BD8 File Offset: 0x00026DD8
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x00028BE0 File Offset: 0x00026DE0
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

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x00028BEC File Offset: 0x00026DEC
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x00028BF4 File Offset: 0x00026DF4
		public global::Jint.Expressions.BinaryExpressionType Type
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

		// Token: 0x06000573 RID: 1395 RVA: 0x00028C00 File Offset: 0x00026E00
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00028C0C File Offset: 0x00026E0C
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				this.Type.ToString(),
				" (",
				this.leftExpression.ToString(),
				", ",
				this.rightExpression.ToString(),
				")"
			});
		}

		// Token: 0x0400025E RID: 606
		private global::Jint.Expressions.Expression leftExpression;

		// Token: 0x0400025F RID: 607
		private global::Jint.Expressions.Expression rightExpression;

		// Token: 0x04000260 RID: 608
		private global::Jint.Expressions.BinaryExpressionType type;
	}
}
