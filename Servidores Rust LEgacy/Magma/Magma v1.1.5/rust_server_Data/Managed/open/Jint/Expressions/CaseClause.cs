using System;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200006D RID: 109
	[global::System.Serializable]
	public class CaseClause
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00028CC0 File Offset: 0x00026EC0
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x00028CC8 File Offset: 0x00026EC8
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

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00028CD4 File Offset: 0x00026ED4
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x00028CDC File Offset: 0x00026EDC
		public global::Jint.Expressions.BlockStatement Statements
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Statements>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<Statements>k__BackingField = value;
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00028CE8 File Offset: 0x00026EE8
		public CaseClause()
		{
			this.Statements = new global::Jint.Expressions.BlockStatement();
		}

		// Token: 0x0400027C RID: 636
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;

		// Token: 0x0400027D RID: 637
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.BlockStatement <Statements>k__BackingField;
	}
}
