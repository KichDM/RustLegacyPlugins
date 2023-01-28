using System;

namespace Jint.Native
{
	// Token: 0x02000013 RID: 19
	public interface INativeIndexer
	{
		// Token: 0x0600009B RID: 155
		global::Jint.Native.JsInstance get(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance index);

		// Token: 0x0600009C RID: 156
		void set(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance index, global::Jint.Native.JsInstance value);
	}
}
