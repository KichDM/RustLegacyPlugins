using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x02000084 RID: 132
	[global::System.Serializable]
	public class ValueExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x00029288 File Offset: 0x00027488
		public ValueExpression(object value, global::System.TypeCode typeCode)
		{
			this.value = value;
			this.typeCode = typeCode;
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x000292A0 File Offset: 0x000274A0
		// (set) Token: 0x060005F2 RID: 1522 RVA: 0x000292A8 File Offset: 0x000274A8
		public object Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x000292B4 File Offset: 0x000274B4
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x000292BC File Offset: 0x000274BC
		public global::System.TypeCode TypeCode
		{
			get
			{
				return this.typeCode;
			}
			set
			{
				this.typeCode = value;
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000292C8 File Offset: 0x000274C8
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000292D4 File Offset: 0x000274D4
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x040002BD RID: 701
		private object value;

		// Token: 0x040002BE RID: 702
		private global::System.TypeCode typeCode;
	}
}
