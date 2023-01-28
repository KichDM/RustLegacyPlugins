using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x0200007E RID: 126
	[global::System.Serializable]
	public class Indexer : global::Jint.Expressions.Expression, global::Jint.Expressions.IAssignable
	{
		// Token: 0x060005CF RID: 1487 RVA: 0x00029070 File Offset: 0x00027270
		public Indexer()
		{
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00029078 File Offset: 0x00027278
		public Indexer(global::Jint.Expressions.Expression index)
		{
			this.Index = index;
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x00029088 File Offset: 0x00027288
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x00029090 File Offset: 0x00027290
		public global::Jint.Expressions.Expression Index
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Index>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Index>k__BackingField = value;
			}
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0002909C File Offset: 0x0002729C
		public override string ToString()
		{
			return "[" + this.Index.ToString() + "]" + base.ToString();
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x000290D0 File Offset: 0x000272D0
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x040002A5 RID: 677
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Index>k__BackingField;
	}
}
