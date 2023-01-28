using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000079 RID: 121
	[global::System.Serializable]
	public class FunctionDeclarationStatement : global::Jint.Expressions.Statement, global::Jint.Expressions.IFunctionDeclaration
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00028F1C File Offset: 0x0002711C
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x00028F24 File Offset: 0x00027124
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

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00028F30 File Offset: 0x00027130
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00028F38 File Offset: 0x00027138
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

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00028F44 File Offset: 0x00027144
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00028F4C File Offset: 0x0002714C
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

		// Token: 0x060005B6 RID: 1462 RVA: 0x00028F58 File Offset: 0x00027158
		public FunctionDeclarationStatement()
		{
			this.Parameters = new global::System.Collections.Generic.List<string>();
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00028F6C File Offset: 0x0002716C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0400029B RID: 667
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Name>k__BackingField;

		// Token: 0x0400029C RID: 668
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<string> <Parameters>k__BackingField;

		// Token: 0x0400029D RID: 669
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;
	}
}
