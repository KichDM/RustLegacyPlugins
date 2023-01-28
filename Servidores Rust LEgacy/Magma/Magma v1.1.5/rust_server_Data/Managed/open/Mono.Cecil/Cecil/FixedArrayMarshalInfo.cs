using System;

namespace Mono.Cecil
{
	// Token: 0x02000068 RID: 104
	public sealed class FixedArrayMarshalInfo : global::Mono.Cecil.MarshalInfo
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000AA21 File Offset: 0x00008C21
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000AA29 File Offset: 0x00008C29
		public global::Mono.Cecil.NativeType ElementType
		{
			get
			{
				return this.element_type;
			}
			set
			{
				this.element_type = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000AA32 File Offset: 0x00008C32
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000AA3A File Offset: 0x00008C3A
		public int Size
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000AA43 File Offset: 0x00008C43
		public FixedArrayMarshalInfo() : base(global::Mono.Cecil.NativeType.FixedArray)
		{
			this.element_type = global::Mono.Cecil.NativeType.None;
		}

		// Token: 0x040002C9 RID: 713
		internal global::Mono.Cecil.NativeType element_type;

		// Token: 0x040002CA RID: 714
		internal int size;
	}
}
