using System;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000073 RID: 115
	[global::System.Serializable]
	public class FinallyClause
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00028DB4 File Offset: 0x00026FB4
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x00028DBC File Offset: 0x00026FBC
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

		// Token: 0x06000591 RID: 1425 RVA: 0x00028DC8 File Offset: 0x00026FC8
		public FinallyClause(global::Jint.Expressions.Statement statement)
		{
			this.Statement = statement;
		}

		// Token: 0x04000290 RID: 656
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
