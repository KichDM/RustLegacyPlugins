using System;
using Jint.Native;

namespace Jint.Expressions
{
	// Token: 0x0200003F RID: 63
	public interface IJintVisitor
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060002F1 RID: 753
		bool DebugMode { get; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060002F2 RID: 754
		// (set) Token: 0x060002F3 RID: 755
		global::Jint.Native.JsInstance Result { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060002F4 RID: 756
		global::Jint.Native.JsDictionaryObject CallTarget { get; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060002F5 RID: 757
		global::Jint.Native.IGlobal Global { get; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060002F6 RID: 758
		global::Jint.Native.JsInstance Returned { get; }

		// Token: 0x060002F7 RID: 759
		global::Jint.Native.JsInstance Return(global::Jint.Native.JsInstance result);

		// Token: 0x060002F8 RID: 760
		void ExecuteFunction(global::Jint.Native.JsFunction function, global::Jint.Native.JsDictionaryObject _this, global::Jint.Native.JsInstance[] _parameters);
	}
}
