using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000041 RID: 65
	[global::System.Serializable]
	public class ArrayDeclaration : global::Jint.Expressions.Expression
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0001F604 File Offset: 0x0001D804
		// (set) Token: 0x0600034B RID: 843 RVA: 0x0001F60C File Offset: 0x0001D80C
		public global::System.Collections.Generic.List<global::Jint.Expressions.Statement> Parameters
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Parameters>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Parameters>k__BackingField = value;
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001F618 File Offset: 0x0001D818
		public ArrayDeclaration()
		{
			this.Parameters = new global::System.Collections.Generic.List<global::Jint.Expressions.Statement>();
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0001F62C File Offset: 0x0001D82C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000206 RID: 518
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.Statement> <Parameters>k__BackingField;
	}
}
