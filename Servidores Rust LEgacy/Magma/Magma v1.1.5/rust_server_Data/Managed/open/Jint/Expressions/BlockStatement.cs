using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200006C RID: 108
	[global::System.Serializable]
	public class BlockStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x00028C8C File Offset: 0x00026E8C
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x00028C94 File Offset: 0x00026E94
		public global::System.Collections.Generic.LinkedList<global::Jint.Expressions.Statement> Statements
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

		// Token: 0x06000577 RID: 1399 RVA: 0x00028CA0 File Offset: 0x00026EA0
		public BlockStatement()
		{
			this.Statements = new global::System.Collections.Generic.LinkedList<global::Jint.Expressions.Statement>();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00028CB4 File Offset: 0x00026EB4
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0400027B RID: 635
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.LinkedList<global::Jint.Expressions.Statement> <Statements>k__BackingField;
	}
}
