using System;
using System.Runtime.CompilerServices;
using Jint.Debugger;

namespace Jint.Expressions
{
	// Token: 0x0200002D RID: 45
	[global::System.Serializable]
	public abstract class Statement
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0001B850 File Offset: 0x00019A50
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0001B858 File Offset: 0x00019A58
		public string Label
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Label>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Label>k__BackingField = value;
			}
		}

		// Token: 0x06000267 RID: 615
		public abstract void Accept(global::Jint.Expressions.IStatementVisitor visitor);

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0001B864 File Offset: 0x00019A64
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0001B86C File Offset: 0x00019A6C
		public global::Jint.Debugger.SourceCodeDescriptor Source
		{
			get
			{
				return this.source;
			}
			set
			{
				this.source = value;
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0001B878 File Offset: 0x00019A78
		public Statement()
		{
			this.Label = string.Empty;
		}

		// Token: 0x040001D4 RID: 468
		protected global::Jint.Debugger.SourceCodeDescriptor source;

		// Token: 0x040001D5 RID: 469
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Label>k__BackingField;
	}
}
