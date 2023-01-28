using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000085 RID: 133
	[global::System.Serializable]
	public class VariableDeclarationStatement : global::Jint.Expressions.Statement
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x000292E4 File Offset: 0x000274E4
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x000292EC File Offset: 0x000274EC
		public bool Global
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Global>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Global>k__BackingField = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x000292F8 File Offset: 0x000274F8
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x00029300 File Offset: 0x00027500
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

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0002930C File Offset: 0x0002750C
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x00029314 File Offset: 0x00027514
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

		// Token: 0x060005FD RID: 1533 RVA: 0x00029320 File Offset: 0x00027520
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0002932C File Offset: 0x0002752C
		public VariableDeclarationStatement()
		{
		}

		// Token: 0x040002BF RID: 703
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <Global>k__BackingField;

		// Token: 0x040002C0 RID: 704
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Identifier>k__BackingField;

		// Token: 0x040002C1 RID: 705
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;
	}
}
