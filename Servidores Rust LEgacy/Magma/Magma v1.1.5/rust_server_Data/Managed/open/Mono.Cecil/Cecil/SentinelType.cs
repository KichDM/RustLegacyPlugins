using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x02000025 RID: 37
	public sealed class SentinelType : global::Mono.Cecil.TypeSpecification
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x000066B0 File Offset: 0x000048B0
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x000066B3 File Offset: 0x000048B3
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

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x000066BA File Offset: 0x000048BA
		public override bool IsSentinel
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000066BD File Offset: 0x000048BD
		public SentinelType(global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			this.etype = global::Mono.Cecil.Metadata.ElementType.Sentinel;
		}
	}
}
