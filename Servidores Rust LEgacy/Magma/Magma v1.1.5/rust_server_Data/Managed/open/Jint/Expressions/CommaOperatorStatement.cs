using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000042 RID: 66
	[global::System.Serializable]
	public class CommaOperatorStatement : global::Jint.Expressions.Expression
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600034E RID: 846 RVA: 0x0001F638 File Offset: 0x0001D838
		// (set) Token: 0x0600034F RID: 847 RVA: 0x0001F640 File Offset: 0x0001D840
		public global::System.Collections.Generic.List<global::Jint.Expressions.Statement> Statements
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Statements>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Statements>k__BackingField = value;
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0001F64C File Offset: 0x0001D84C
		public CommaOperatorStatement()
		{
			this.Statements = new global::System.Collections.Generic.List<global::Jint.Expressions.Statement>();
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0001F660 File Offset: 0x0001D860
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000207 RID: 519
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.Statement> <Statements>k__BackingField;

		// Token: 0x02000149 RID: 329
		private class StatementInfo
		{
			// Token: 0x170002A2 RID: 674
			// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x0003BBFC File Offset: 0x00039DFC
			// (set) Token: 0x06000BDA RID: 3034 RVA: 0x0003BC04 File Offset: 0x00039E04
			public int index
			{
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				get
				{
					return this.<index>k__BackingField;
				}
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				private set
				{
					this.<index>k__BackingField = value;
				}
			}

			// Token: 0x170002A3 RID: 675
			// (get) Token: 0x06000BDB RID: 3035 RVA: 0x0003BC10 File Offset: 0x00039E10
			// (set) Token: 0x06000BDC RID: 3036 RVA: 0x0003BC18 File Offset: 0x00039E18
			public global::Jint.Expressions.Statement statement
			{
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				get
				{
					return this.<statement>k__BackingField;
				}
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				private set
				{
					this.<statement>k__BackingField = value;
				}
			}

			// Token: 0x06000BDD RID: 3037 RVA: 0x0003BC24 File Offset: 0x00039E24
			public StatementInfo(int i, global::Jint.Expressions.Statement s)
			{
				this.index = i;
				this.statement = s;
			}

			// Token: 0x040006AF RID: 1711
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private int <index>k__BackingField;

			// Token: 0x040006B0 RID: 1712
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private global::Jint.Expressions.Statement <statement>k__BackingField;
		}
	}
}
