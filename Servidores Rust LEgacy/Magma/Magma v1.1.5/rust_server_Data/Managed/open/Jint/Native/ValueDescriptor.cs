using System;

namespace Jint.Native
{
	// Token: 0x0200003C RID: 60
	[global::System.Serializable]
	public class ValueDescriptor : global::Jint.Native.Descriptor
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x0001C080 File Offset: 0x0001A280
		public ValueDescriptor(global::Jint.Native.JsDictionaryObject owner, string name) : base(owner, name)
		{
			base.Enumerable = true;
			base.Writable = true;
			base.Configurable = true;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0001C0B0 File Offset: 0x0001A2B0
		public ValueDescriptor(global::Jint.Native.JsDictionaryObject owner, string name, global::Jint.Native.JsInstance value) : this(owner, name)
		{
			this.Set(null, value);
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0001C0C4 File Offset: 0x0001A2C4
		public override bool isReference
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001C0C8 File Offset: 0x0001A2C8
		public override global::Jint.Native.Descriptor Clone()
		{
			return new global::Jint.Native.ValueDescriptor(base.Owner, base.Name, this.value)
			{
				Enumerable = base.Enumerable,
				Configurable = base.Configurable,
				Writable = base.Writable
			};
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0001C118 File Offset: 0x0001A318
		public override global::Jint.Native.JsInstance Get(global::Jint.Native.JsDictionaryObject that)
		{
			return this.value ?? global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001C12C File Offset: 0x0001A32C
		public override void Set(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance value)
		{
			if (!base.Writable)
			{
				throw new global::Jint.JintException("This property is not writable");
			}
			this.value = value;
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0001C14C File Offset: 0x0001A34C
		internal override global::Jint.Native.DescriptorType DescriptorType
		{
			get
			{
				return global::Jint.Native.DescriptorType.Value;
			}
		}

		// Token: 0x040001ED RID: 493
		private global::Jint.Native.JsInstance value;
	}
}
