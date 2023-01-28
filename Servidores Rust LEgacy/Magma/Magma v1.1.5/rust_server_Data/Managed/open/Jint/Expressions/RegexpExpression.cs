using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200005A RID: 90
	[global::System.Serializable]
	public class RegexpExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x000259C8 File Offset: 0x00023BC8
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x000259D0 File Offset: 0x00023BD0
		public string Regexp
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Regexp>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Regexp>k__BackingField = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x000259DC File Offset: 0x00023BDC
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x000259E4 File Offset: 0x00023BE4
		public string Options
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Options>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Options>k__BackingField = value;
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000259F0 File Offset: 0x00023BF0
		public RegexpExpression(string regexp)
		{
			this.Regexp = regexp;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00025A00 File Offset: 0x00023C00
		public RegexpExpression(string regexp, string options) : this(regexp)
		{
			this.Options = options;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00025A10 File Offset: 0x00023C10
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000221 RID: 545
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Regexp>k__BackingField;

		// Token: 0x04000222 RID: 546
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Options>k__BackingField;
	}
}
