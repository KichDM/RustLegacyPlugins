using System;

namespace Mono.Cecil
{
	// Token: 0x02000067 RID: 103
	public sealed class SafeArrayMarshalInfo : global::Mono.Cecil.MarshalInfo
	{
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000A9FF File Offset: 0x00008BFF
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x0000AA07 File Offset: 0x00008C07
		public global::Mono.Cecil.VariantType ElementType
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

		// Token: 0x0600043E RID: 1086 RVA: 0x0000AA10 File Offset: 0x00008C10
		public SafeArrayMarshalInfo() : base(global::Mono.Cecil.NativeType.SafeArray)
		{
			this.element_type = global::Mono.Cecil.VariantType.None;
		}

		// Token: 0x040002C8 RID: 712
		internal global::Mono.Cecil.VariantType element_type;
	}
}
