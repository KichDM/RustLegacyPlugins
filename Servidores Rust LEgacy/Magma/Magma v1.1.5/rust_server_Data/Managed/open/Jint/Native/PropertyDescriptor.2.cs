using System;

namespace Jint.Native
{
	// Token: 0x0200003B RID: 59
	[global::System.Serializable]
	public class PropertyDescriptor<T> : global::Jint.Native.PropertyDescriptor where T : global::Jint.Native.JsInstance
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x0001C020 File Offset: 0x0001A220
		public PropertyDescriptor(global::Jint.Native.IGlobal global, global::Jint.Native.JsDictionaryObject owner, string name, global::System.Func<T, global::Jint.Native.JsInstance> get) : base(global, owner, name)
		{
			base.GetFunction = global.FunctionClass.New<T>(get);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0001C050 File Offset: 0x0001A250
		public PropertyDescriptor(global::Jint.Native.IGlobal global, global::Jint.Native.JsDictionaryObject owner, string name, global::System.Func<T, global::Jint.Native.JsInstance> get, global::System.Func<T, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> set) : this(global, owner, name, get)
		{
			base.SetFunction = global.FunctionClass.New<T>(set);
		}
	}
}
