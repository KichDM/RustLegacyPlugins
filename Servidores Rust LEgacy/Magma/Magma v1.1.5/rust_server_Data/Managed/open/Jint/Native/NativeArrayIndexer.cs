using System;

namespace Jint.Native
{
	// Token: 0x02000016 RID: 22
	internal class NativeArrayIndexer<T> : global::Jint.Native.INativeIndexer
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x00005424 File Offset: 0x00003624
		public NativeArrayIndexer(global::Jint.Marshaller marshaller)
		{
			if (marshaller == null)
			{
				throw new global::System.ArgumentNullException("marshaller");
			}
			this.m_marshller = marshaller;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00005444 File Offset: 0x00003644
		public global::Jint.Native.JsInstance get(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance index)
		{
			return this.m_marshller.MarshalClrValue<T>(this.m_marshller.MarshalJsValue<T[]>(that)[this.m_marshller.MarshalJsValue<int>(index)]);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005470 File Offset: 0x00003670
		public void set(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance index, global::Jint.Native.JsInstance value)
		{
			this.m_marshller.MarshalJsValue<T[]>(that)[this.m_marshller.MarshalJsValue<int>(index)] = this.m_marshller.MarshalJsValue<T>(value);
		}

		// Token: 0x0400003D RID: 61
		private global::Jint.Marshaller m_marshller;
	}
}
