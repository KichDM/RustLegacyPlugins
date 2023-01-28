using System;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000034 RID: 52
	public interface IGlobal
	{
		// Token: 0x0600028A RID: 650
		bool HasOption(global::Jint.Options options);

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600028B RID: 651
		global::Jint.Native.JsArrayConstructor ArrayClass { get; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600028C RID: 652
		global::Jint.Native.JsBooleanConstructor BooleanClass { get; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600028D RID: 653
		global::Jint.Native.JsDateConstructor DateClass { get; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600028E RID: 654
		global::Jint.Native.JsErrorConstructor ErrorClass { get; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600028F RID: 655
		global::Jint.Native.JsErrorConstructor EvalErrorClass { get; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000290 RID: 656
		global::Jint.Native.JsFunctionConstructor FunctionClass { get; }

		// Token: 0x06000291 RID: 657
		global::Jint.Native.JsInstance IsNaN(global::Jint.Native.JsInstance[] arguments);

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000292 RID: 658
		global::Jint.Native.JsMathConstructor MathClass { get; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000293 RID: 659
		global::Jint.Native.JsNumberConstructor NumberClass { get; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000294 RID: 660
		global::Jint.Native.JsObjectConstructor ObjectClass { get; }

		// Token: 0x06000295 RID: 661
		global::Jint.Native.JsInstance ParseFloat(global::Jint.Native.JsInstance[] arguments);

		// Token: 0x06000296 RID: 662
		global::Jint.Native.JsInstance ParseInt(global::Jint.Native.JsInstance[] arguments);

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000297 RID: 663
		global::Jint.Native.JsErrorConstructor RangeErrorClass { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000298 RID: 664
		global::Jint.Native.JsErrorConstructor ReferenceErrorClass { get; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000299 RID: 665
		global::Jint.Native.JsRegExpConstructor RegExpClass { get; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600029A RID: 666
		global::Jint.Native.JsStringConstructor StringClass { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600029B RID: 667
		global::Jint.Native.JsErrorConstructor SyntaxErrorClass { get; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600029C RID: 668
		global::Jint.Native.JsErrorConstructor TypeErrorClass { get; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600029D RID: 669
		global::Jint.Native.JsErrorConstructor URIErrorClass { get; }

		// Token: 0x0600029E RID: 670
		global::Jint.Native.JsObject Wrap(object value);

		// Token: 0x0600029F RID: 671
		global::Jint.Native.JsObject WrapClr(object value);

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060002A0 RID: 672
		global::Jint.Native.JsInstance NaN { get; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060002A1 RID: 673
		global::Jint.Expressions.IJintVisitor Visitor { get; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060002A2 RID: 674
		global::Jint.Marshaller Marshaller { get; }
	}
}
