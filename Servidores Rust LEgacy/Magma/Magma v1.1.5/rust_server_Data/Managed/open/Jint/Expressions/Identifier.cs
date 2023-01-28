using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000045 RID: 69
	[global::System.Serializable]
	public class Identifier : global::Jint.Expressions.Expression, global::Jint.Expressions.IAssignable
	{
		// Token: 0x06000357 RID: 855 RVA: 0x0001F6A4 File Offset: 0x0001D8A4
		public Identifier(string text)
		{
			this.Text = text;
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0001F6B4 File Offset: 0x0001D8B4
		// (set) Token: 0x06000359 RID: 857 RVA: 0x0001F6BC File Offset: 0x0001D8BC
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

		// Token: 0x0600035A RID: 858 RVA: 0x0001F6C8 File Offset: 0x0001D8C8
		public override string ToString()
		{
			return this.Text;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0001F6D0 File Offset: 0x0001D8D0
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x04000209 RID: 521
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Text>k__BackingField;
	}
}
