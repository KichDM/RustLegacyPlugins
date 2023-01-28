using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x0200001C RID: 28
	[global::System.Serializable]
	public abstract class JsConstructor : global::Jint.Native.JsFunction
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000065F0 File Offset: 0x000047F0
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000065F8 File Offset: 0x000047F8
		public global::Jint.Native.IGlobal Global
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Global>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Global>k__BackingField = value;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00006604 File Offset: 0x00004804
		public JsConstructor(global::Jint.Native.IGlobal global) : base(global)
		{
			this.Global = global;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00006614 File Offset: 0x00004814
		protected JsConstructor(global::Jint.Native.IGlobal global, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.Global = global;
		}

		// Token: 0x060000EB RID: 235
		public abstract void InitPrototype(global::Jint.Native.IGlobal global);

		// Token: 0x060000EC RID: 236 RVA: 0x00006624 File Offset: 0x00004824
		public virtual global::Jint.Native.JsInstance Wrap<T>(T value)
		{
			return new global::Jint.Native.JsObject(value, base.PrototypeProperty);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00006638 File Offset: 0x00004838
		public override string GetBody()
		{
			return "[native ctor]";
		}

		// Token: 0x04000057 RID: 87
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.IGlobal <Global>k__BackingField;
	}
}
