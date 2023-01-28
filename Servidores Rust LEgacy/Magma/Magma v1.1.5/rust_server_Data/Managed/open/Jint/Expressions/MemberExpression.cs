using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000066 RID: 102
	[global::System.Serializable]
	public class MemberExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x00027D30 File Offset: 0x00025F30
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x00027D38 File Offset: 0x00025F38
		public global::Jint.Expressions.Expression Member
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Member>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Member>k__BackingField = value;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00027D44 File Offset: 0x00025F44
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x00027D4C File Offset: 0x00025F4C
		public global::Jint.Expressions.Expression Previous
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Previous>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Previous>k__BackingField = value;
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00027D58 File Offset: 0x00025F58
		public MemberExpression(global::Jint.Expressions.Expression member, global::Jint.Expressions.Expression previous)
		{
			this.Member = member;
			this.Previous = previous;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00027D70 File Offset: 0x00025F70
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0400024E RID: 590
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Member>k__BackingField;

		// Token: 0x0400024F RID: 591
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Previous>k__BackingField;
	}
}
