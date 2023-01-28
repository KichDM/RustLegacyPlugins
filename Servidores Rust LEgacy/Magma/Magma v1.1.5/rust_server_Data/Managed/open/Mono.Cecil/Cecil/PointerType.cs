using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x02000016 RID: 22
	public sealed class PointerType : global::Mono.Cecil.TypeSpecification
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00004228 File Offset: 0x00002428
		public override string Name
		{
			get
			{
				return base.Name + "*";
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000423A File Offset: 0x0000243A
		public override string FullName
		{
			get
			{
				return base.FullName + "*";
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000424C File Offset: 0x0000244C
		// (set) Token: 0x06000109 RID: 265 RVA: 0x0000424F File Offset: 0x0000244F
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

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00004256 File Offset: 0x00002456
		public override bool IsPointer
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00004259 File Offset: 0x00002459
		public PointerType(global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			this.etype = global::Mono.Cecil.Metadata.ElementType.Ptr;
		}
	}
}
