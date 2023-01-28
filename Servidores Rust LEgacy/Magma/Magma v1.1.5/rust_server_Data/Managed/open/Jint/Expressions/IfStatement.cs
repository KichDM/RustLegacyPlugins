using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200007A RID: 122
	[global::System.Serializable]
	public class IfStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00028F78 File Offset: 0x00027178
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00028F80 File Offset: 0x00027180
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x00028F8C File Offset: 0x0002718C
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x00028F94 File Offset: 0x00027194
		public global::Jint.Expressions.Statement Then
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Then>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Then>k__BackingField = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x00028FA0 File Offset: 0x000271A0
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x00028FA8 File Offset: 0x000271A8
		public global::Jint.Expressions.Statement Else
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Else>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Else>k__BackingField = value;
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00028FB4 File Offset: 0x000271B4
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00028FC0 File Offset: 0x000271C0
		public IfStatement()
		{
		}

		// Token: 0x0400029E RID: 670
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;

		// Token: 0x0400029F RID: 671
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Then>k__BackingField;

		// Token: 0x040002A0 RID: 672
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Else>k__BackingField;
	}
}
