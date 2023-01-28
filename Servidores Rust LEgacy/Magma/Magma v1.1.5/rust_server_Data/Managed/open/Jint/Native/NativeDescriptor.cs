using System;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x0200001A RID: 26
	public class NativeDescriptor : global::Jint.Native.Descriptor
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x00005C50 File Offset: 0x00003E50
		public NativeDescriptor(global::Jint.Native.JsDictionaryObject owner, string name, global::Jint.Marshal.JsGetter getter) : base(owner, name)
		{
			this.getter = getter;
			base.Writable = false;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00005C68 File Offset: 0x00003E68
		public NativeDescriptor(global::Jint.Native.JsDictionaryObject owner, string name, global::Jint.Marshal.JsGetter getter, global::Jint.Marshal.JsSetter setter) : base(owner, name)
		{
			this.getter = getter;
			this.setter = setter;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00005C84 File Offset: 0x00003E84
		public NativeDescriptor(global::Jint.Native.JsDictionaryObject owner, global::Jint.Native.NativeDescriptor src) : base(owner, src.Name)
		{
			this.getter = src.getter;
			this.setter = src.setter;
			base.Writable = src.Writable;
			base.Configurable = src.Configurable;
			base.Enumerable = src.Enumerable;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00005CE0 File Offset: 0x00003EE0
		public override bool isReference
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005CE4 File Offset: 0x00003EE4
		public override global::Jint.Native.Descriptor Clone()
		{
			return new global::Jint.Native.NativeDescriptor(base.Owner, this);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00005CF4 File Offset: 0x00003EF4
		public override global::Jint.Native.JsInstance Get(global::Jint.Native.JsDictionaryObject that)
		{
			if (this.getter == null)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			return this.getter(that);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005D14 File Offset: 0x00003F14
		public override void Set(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance value)
		{
			if (this.setter != null)
			{
				this.setter(that, value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00005D30 File Offset: 0x00003F30
		internal override global::Jint.Native.DescriptorType DescriptorType
		{
			get
			{
				return global::Jint.Native.DescriptorType.Clr;
			}
		}

		// Token: 0x0400004E RID: 78
		private global::Jint.Marshal.JsGetter getter;

		// Token: 0x0400004F RID: 79
		private global::Jint.Marshal.JsSetter setter;
	}
}
