using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000081 RID: 129
	[global::System.Serializable]
	public class TryStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x000291EC File Offset: 0x000273EC
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x000291F4 File Offset: 0x000273F4
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

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00029200 File Offset: 0x00027400
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x00029208 File Offset: 0x00027408
		public global::Jint.Expressions.FinallyClause Finally
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Finally>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Finally>k__BackingField = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00029214 File Offset: 0x00027414
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x0002921C File Offset: 0x0002741C
		public global::Jint.Expressions.CatchClause Catch
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Catch>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Catch>k__BackingField = value;
			}
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00029228 File Offset: 0x00027428
		public TryStatement()
		{
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00029230 File Offset: 0x00027430
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002AA RID: 682
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;

		// Token: 0x040002AB RID: 683
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.FinallyClause <Finally>k__BackingField;

		// Token: 0x040002AC RID: 684
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.CatchClause <Catch>k__BackingField;
	}
}
