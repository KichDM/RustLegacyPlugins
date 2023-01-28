using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000068 RID: 104
	[global::System.Serializable]
	public class MethodCall : global::Jint.Expressions.Expression, global::Jint.Expressions.IGenericExpression
	{
		// Token: 0x06000536 RID: 1334 RVA: 0x00027DF8 File Offset: 0x00025FF8
		public MethodCall()
		{
			this.Arguments = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
			this.Generics = new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>();
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00027E18 File Offset: 0x00026018
		public MethodCall(global::System.Collections.Generic.List<global::Jint.Expressions.Expression> arguments) : this()
		{
			this.Arguments.AddRange(arguments);
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x00027E2C File Offset: 0x0002602C
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x00027E34 File Offset: 0x00026034
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x00027E40 File Offset: 0x00026040
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x00027E48 File Offset: 0x00026048
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

		// Token: 0x0600053C RID: 1340 RVA: 0x00027E54 File Offset: 0x00026054
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000253 RID: 595
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.Expression> <Arguments>k__BackingField;

		// Token: 0x04000254 RID: 596
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Expressions.Expression> <Generics>k__BackingField;
	}
}
