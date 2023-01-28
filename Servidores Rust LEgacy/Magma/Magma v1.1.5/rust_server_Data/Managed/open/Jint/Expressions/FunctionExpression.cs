using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000065 RID: 101
	[global::System.Serializable]
	public class FunctionExpression : global::Jint.Expressions.Expression, global::Jint.Expressions.IFunctionDeclaration
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x00027CD4 File Offset: 0x00025ED4
		// (set) Token: 0x06000521 RID: 1313 RVA: 0x00027CDC File Offset: 0x00025EDC
		public global::System.Collections.Generic.List<string> Parameters
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

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x00027CE8 File Offset: 0x00025EE8
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x00027CF0 File Offset: 0x00025EF0
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

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00027CFC File Offset: 0x00025EFC
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x00027D04 File Offset: 0x00025F04
		public string Name
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Name>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Name>k__BackingField = value;
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00027D10 File Offset: 0x00025F10
		public FunctionExpression()
		{
			this.Parameters = new global::System.Collections.Generic.List<string>();
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00027D24 File Offset: 0x00025F24
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0400024B RID: 587
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<string> <Parameters>k__BackingField;

		// Token: 0x0400024C RID: 588
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;

		// Token: 0x0400024D RID: 589
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Name>k__BackingField;
	}
}
