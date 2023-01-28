using System;
using System.Diagnostics;

namespace Jint.Expressions
{
	// Token: 0x02000046 RID: 70
	[global::System.Serializable]
	public class PropertyExpression : global::Jint.Expressions.Identifier, global::Jint.Expressions.IAssignable
	{
		// Token: 0x0600035C RID: 860 RVA: 0x0001F6DC File Offset: 0x0001D8DC
		public PropertyExpression(string text) : base(text)
		{
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0001F6E8 File Offset: 0x0001D8E8
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
