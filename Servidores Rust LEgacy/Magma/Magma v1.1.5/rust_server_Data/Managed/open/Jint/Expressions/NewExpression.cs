using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000067 RID: 103
	[global::System.Serializable]
	public class NewExpression : global::Jint.Expressions.Expression, global::Jint.Expressions.IGenericExpression
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x00027D7C File Offset: 0x00025F7C
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00027D84 File Offset: 0x00025F84
		public global::System.Collections.Generic.List<global::Jint.Expressions.Expression> Arguments
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Arguments>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Arguments>k__BackingField = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x00027D90 File Offset: 0x00025F90
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x00027D98 File Offset: 0x00025F98
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

		// Token: 0x06000532 RID: 1330 RVA: 0x00027DA4 File Offset: 0x00025FA4
		public NewExpression(global::Jint.Expressions.Expression expression)
		{
			this.Expression = expression;
			this.Arguments = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
			this.Generics = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00027DD8 File Offset: 0x00025FD8
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00027DE4 File Offset: 0x00025FE4
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x00027DEC File Offset: 0x00025FEC
		public global::System.Collections.Generic.List<global::Jint.Expressions.Expression> Generics
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Generics>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Generics>k__BackingField = value;
			}
		}

		// Token: 0x04000250 RID: 592
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.Expression> <Arguments>k__BackingField;

		// Token: 0x04000251 RID: 593
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;

		// Token: 0x04000252 RID: 594
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.Expression> <Generics>k__BackingField;
	}
}
