using System;

namespace Jint.Native
{
	// Token: 0x02000021 RID: 33
	internal class NativeGenericType : global::Jint.Native.JsObject
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00007624 File Offset: 0x00005824
		public NativeGenericType(global::System.Type reflectedType, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			if (reflectedType == null)
			{
				throw new global::System.ArgumentNullException("reflectedType");
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00007640 File Offset: 0x00005840
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00007648 File Offset: 0x00005848
		public override object Value
		{
			get
			{
				return this.m_reflectedType;
			}
			set
			{
				this.m_reflectedType = (global::System.Type)value;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00007658 File Offset: 0x00005858
		private global::Jint.Native.JsConstructor MakeType(global::System.Type[] args, global::Jint.Native.IGlobal global)
		{
			return global.Marshaller.MarshalType(this.m_reflectedType.MakeGenericType(args));
		}

		// Token: 0x04000067 RID: 103
		private global::System.Type m_reflectedType;
	}
}
