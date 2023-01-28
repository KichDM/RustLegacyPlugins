using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200007D RID: 125
	[global::System.Serializable]
	public class SwitchStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x00029014 File Offset: 0x00027214
		// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0002901C File Offset: 0x0002721C
		public global::Jint.Expressions.Statement Expression
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

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x00029028 File Offset: 0x00027228
		// (set) Token: 0x060005CA RID: 1482 RVA: 0x00029030 File Offset: 0x00027230
		public global::System.Collections.Generic.List<global::Jint.Expressions.CaseClause> CaseClauses
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<CaseClauses>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<CaseClauses>k__BackingField = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0002903C File Offset: 0x0002723C
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x00029044 File Offset: 0x00027244
		public global::Jint.Expressions.Statement DefaultStatements
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<DefaultStatements>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<DefaultStatements>k__BackingField = value;
			}
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00029050 File Offset: 0x00027250
		public SwitchStatement()
		{
			this.CaseClauses = new global::System.Collections.Generic.List<global::Jint.Expressions.CaseClause>();
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00029064 File Offset: 0x00027264
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002A2 RID: 674
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Expression>k__BackingField;

		// Token: 0x040002A3 RID: 675
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.CaseClause> <CaseClauses>k__BackingField;

		// Token: 0x040002A4 RID: 676
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <DefaultStatements>k__BackingField;
	}
}
