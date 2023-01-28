using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x02000011 RID: 17
	public sealed class PinnedType : global::Mono.Cecil.TypeSpecification
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00002B2C File Offset: 0x00000D2C
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00002B2F File Offset: 0x00000D2F
		public override bool IsValueType
		{
			get
			{
				return false;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsPinned
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002B39 File Offset: 0x00000D39
		public PinnedType(global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			this.etype = global::Mono.Cecil.Metadata.ElementType.Pinned;
		}
	}
}
