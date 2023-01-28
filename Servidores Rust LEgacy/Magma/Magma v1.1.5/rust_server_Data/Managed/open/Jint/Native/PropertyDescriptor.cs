using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x0200003A RID: 58
	[global::System.Serializable]
	public class PropertyDescriptor : global::Jint.Native.Descriptor
	{
		// Token: 0x060002BA RID: 698 RVA: 0x0001BED4 File Offset: 0x0001A0D4
		public PropertyDescriptor(global::Jint.Native.IGlobal global, global::Jint.Native.JsDictionaryObject owner, string name) : base(owner, name)
		{
			this.global = global;
			base.Enumerable = false;
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		// (set) Token: 0x060002BC RID: 700 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		public global::Jint.Native.JsFunction GetFunction
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<GetFunction>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<GetFunction>k__BackingField = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002BD RID: 701 RVA: 0x0001BF00 File Offset: 0x0001A100
		// (set) Token: 0x060002BE RID: 702 RVA: 0x0001BF08 File Offset: 0x0001A108
		public global::Jint.Native.JsFunction SetFunction
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<SetFunction>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<SetFunction>k__BackingField = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0001BF14 File Offset: 0x0001A114
		public override bool isReference
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0001BF18 File Offset: 0x0001A118
		public override global::Jint.Native.Descriptor Clone()
		{
			return new global::Jint.Native.PropertyDescriptor(this.global, base.Owner, base.Name)
			{
				Enumerable = base.Enumerable,
				Configurable = base.Configurable,
				Writable = base.Writable,
				GetFunction = this.GetFunction,
				SetFunction = this.SetFunction
			};
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0001BF80 File Offset: 0x0001A180
		public override global::Jint.Native.JsInstance Get(global::Jint.Native.JsDictionaryObject that)
		{
			this.global.Visitor.ExecuteFunction(this.GetFunction, that, global::Jint.Native.JsInstance.EMPTY);
			return this.global.Visitor.Returned;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0001BFC0 File Offset: 0x0001A1C0
		public override void Set(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance value)
		{
			if (this.SetFunction == null)
			{
				throw new global::Jint.Native.JsException(this.global.TypeErrorClass.New());
			}
			this.global.Visitor.ExecuteFunction(this.SetFunction, that, new global::Jint.Native.JsInstance[]
			{
				value
			});
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0001C01C File Offset: 0x0001A21C
		internal override global::Jint.Native.DescriptorType DescriptorType
		{
			get
			{
				return global::Jint.Native.DescriptorType.Accessor;
			}
		}

		// Token: 0x040001EA RID: 490
		private global::Jint.Native.IGlobal global;

		// Token: 0x040001EB RID: 491
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsFunction <GetFunction>k__BackingField;

		// Token: 0x040001EC RID: 492
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsFunction <SetFunction>k__BackingField;
	}
}
