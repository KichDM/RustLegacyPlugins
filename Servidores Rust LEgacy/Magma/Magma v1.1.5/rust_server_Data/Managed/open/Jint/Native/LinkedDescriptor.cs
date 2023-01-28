using System;

namespace Jint.Native
{
	// Token: 0x02000020 RID: 32
	internal class LinkedDescriptor : global::Jint.Native.Descriptor
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00007524 File Offset: 0x00005724
		public LinkedDescriptor(global::Jint.Native.JsDictionaryObject owner, string name, global::Jint.Native.Descriptor source, global::Jint.Native.JsDictionaryObject that) : base(owner, name)
		{
			if (source.isReference)
			{
				global::Jint.Native.LinkedDescriptor linkedDescriptor = source as global::Jint.Native.LinkedDescriptor;
				this.d = linkedDescriptor.d;
				this.m_that = linkedDescriptor.m_that;
			}
			else
			{
				this.d = source;
			}
			base.Enumerable = true;
			base.Writable = true;
			base.Configurable = true;
			this.m_that = that;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00007590 File Offset: 0x00005790
		public global::Jint.Native.JsDictionaryObject targetObject
		{
			get
			{
				return this.m_that;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00007598 File Offset: 0x00005798
		public override bool isReference
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000114 RID: 276 RVA: 0x0000759C File Offset: 0x0000579C
		// (set) Token: 0x06000115 RID: 277 RVA: 0x000075AC File Offset: 0x000057AC
		public override bool isDeleted
		{
			get
			{
				return this.d.isDeleted;
			}
			protected set
			{
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000075B0 File Offset: 0x000057B0
		public override global::Jint.Native.Descriptor Clone()
		{
			return new global::Jint.Native.LinkedDescriptor(base.Owner, base.Name, this, this.targetObject)
			{
				Writable = base.Writable,
				Configurable = base.Configurable,
				Enumerable = base.Enumerable
			};
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007600 File Offset: 0x00005800
		public override global::Jint.Native.JsInstance Get(global::Jint.Native.JsDictionaryObject that)
		{
			return this.d.Get(that);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007610 File Offset: 0x00005810
		public override void Set(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance value)
		{
			this.d.Set(that, value);
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00007620 File Offset: 0x00005820
		internal override global::Jint.Native.DescriptorType DescriptorType
		{
			get
			{
				return global::Jint.Native.DescriptorType.Value;
			}
		}

		// Token: 0x04000065 RID: 101
		private global::Jint.Native.Descriptor d;

		// Token: 0x04000066 RID: 102
		private global::Jint.Native.JsDictionaryObject m_that;
	}
}
