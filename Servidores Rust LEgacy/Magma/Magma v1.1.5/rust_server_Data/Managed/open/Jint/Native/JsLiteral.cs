using System;

namespace Jint.Native
{
	// Token: 0x02000015 RID: 21
	public abstract class JsLiteral : global::Jint.Native.JsObject, global::Jint.Native.ILiteral
	{
		// Token: 0x0600009D RID: 157 RVA: 0x000053F8 File Offset: 0x000035F8
		public JsLiteral()
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00005400 File Offset: 0x00003600
		public JsLiteral(object value, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = value;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00005410 File Offset: 0x00003610
		public JsLiteral(global::Jint.Native.JsObject prototype) : base(prototype)
		{
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000541C File Offset: 0x0000361C
		public override void DefineOwnProperty(global::Jint.Native.Descriptor currentDescriptor)
		{
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005420 File Offset: 0x00003620
		public override void DefineOwnProperty(string key, global::Jint.Native.JsInstance value)
		{
		}
	}
}
