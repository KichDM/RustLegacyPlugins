using System;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000070 RID: 112
	[global::System.Serializable]
	public class CatchClause
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x00028D4C File Offset: 0x00026F4C
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x00028D54 File Offset: 0x00026F54
		public string Identifier
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Identifier>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Identifier>k__BackingField = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00028D60 File Offset: 0x00026F60
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x00028D68 File Offset: 0x00026F68
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

		// Token: 0x0600058A RID: 1418 RVA: 0x00028D74 File Offset: 0x00026F74
		public CatchClause(string identifier, global::Jint.Expressions.Statement statement)
		{
			this.Identifier = identifier;
			this.Statement = statement;
		}

		// Token: 0x0400028E RID: 654
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Identifier>k__BackingField;

		// Token: 0x0400028F RID: 655
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
