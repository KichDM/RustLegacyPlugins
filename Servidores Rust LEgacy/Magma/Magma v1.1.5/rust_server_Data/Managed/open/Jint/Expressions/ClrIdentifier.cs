using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000043 RID: 67
	[global::System.Serializable]
	public class ClrIdentifier : global::Jint.Expressions.Expression
	{
		// Token: 0x06000352 RID: 850 RVA: 0x0001F66C File Offset: 0x0001D86C
		public ClrIdentifier(string text)
		{
			this.Text = text;
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0001F67C File Offset: 0x0001D87C
		// (set) Token: 0x06000354 RID: 852 RVA: 0x0001F684 File Offset: 0x0001D884
		public string Text
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Text>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Text>k__BackingField = value;
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0001F690 File Offset: 0x0001D890
		public override string ToString()
		{
			return this.Text;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0001F698 File Offset: 0x0001D898
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000208 RID: 520
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Text>k__BackingField;
	}
}
