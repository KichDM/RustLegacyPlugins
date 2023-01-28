using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000077 RID: 119
	[global::System.Serializable]
	public class ForEachInStatement : global::Jint.Expressions.Statement, global::Jint.Expressions.IForStatement
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x00028E68 File Offset: 0x00027068
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x00028E70 File Offset: 0x00027070
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

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00028E7C File Offset: 0x0002707C
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x00028E84 File Offset: 0x00027084
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

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00028E90 File Offset: 0x00027090
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x00028E98 File Offset: 0x00027098
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

		// Token: 0x060005A4 RID: 1444 RVA: 0x00028EA4 File Offset: 0x000270A4
		public ForEachInStatement()
		{
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00028EAC File Offset: 0x000270AC
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000294 RID: 660
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <InitialisationStatement>k__BackingField;

		// Token: 0x04000295 RID: 661
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;

		// Token: 0x04000296 RID: 662
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
