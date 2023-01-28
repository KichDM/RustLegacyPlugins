using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000037 RID: 55
	[global::System.Serializable]
	public class JsComparer : global::System.Collections.Generic.IComparer<global::Jint.Native.JsInstance>
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x0001BB60 File Offset: 0x00019D60
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0001BB68 File Offset: 0x00019D68
		public global::Jint.Expressions.IJintVisitor Visitor
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Visitor>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Visitor>k__BackingField = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0001BB74 File Offset: 0x00019D74
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0001BB7C File Offset: 0x00019D7C
		public global::Jint.Native.JsFunction Function
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Function>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Function>k__BackingField = value;
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0001BB88 File Offset: 0x00019D88
		public JsComparer(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsFunction function)
		{
			this.Visitor = visitor;
			this.Function = function;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0001BBA0 File Offset: 0x00019DA0
		public int Compare(global::Jint.Native.JsInstance x, global::Jint.Native.JsInstance y)
		{
			this.Visitor.Result = this.Function;
			new global::Jint.Expressions.MethodCall(new global::System.Collections.Generic.List<global::Jint.Expressions.Expression>
			{
				new global::Jint.Expressions.ValueExpression(x, global::System.TypeCode.Object),
				new global::Jint.Expressions.ValueExpression(y, global::System.TypeCode.Object)
			}).Accept((global::Jint.Expressions.IStatementVisitor)this.Visitor);
			return global::System.Math.Sign(this.Visitor.Result.ToNumber());
		}

		// Token: 0x040001E6 RID: 486
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.IJintVisitor <Visitor>k__BackingField;

		// Token: 0x040001E7 RID: 487
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsFunction <Function>k__BackingField;
	}
}
