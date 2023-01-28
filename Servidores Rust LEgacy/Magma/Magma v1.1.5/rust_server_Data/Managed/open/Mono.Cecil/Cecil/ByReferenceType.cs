using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000AF RID: 175
	public sealed class ByReferenceType : global::Mono.Cecil.TypeSpecification
	{
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00013464 File Offset: 0x00011664
		public override string Name
		{
			get
			{
				return base.Name + "&";
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x00013476 File Offset: 0x00011676
		public override string FullName
		{
			get
			{
				return base.FullName + "&";
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x00013488 File Offset: 0x00011688
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x0001348B File Offset: 0x0001168B
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

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x00013492 File Offset: 0x00011692
		public override bool IsByReference
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00013495 File Offset: 0x00011695
		public ByReferenceType(global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			this.etype = global::Mono.Cecil.Metadata.ElementType.ByRef;
		}
	}
}
