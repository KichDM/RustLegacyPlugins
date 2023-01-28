using System;

namespace Mono.Cecil
{
	// Token: 0x02000089 RID: 137
	public sealed class AssemblyLinkedResource : global::Mono.Cecil.Resource
	{
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000E613 File Offset: 0x0000C813
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000E61B File Offset: 0x0000C81B
		public global::Mono.Cecil.AssemblyNameReference Assembly
		{
			get
			{
				return this.reference;
			}
			set
			{
				this.reference = value;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0000E624 File Offset: 0x0000C824
		public override global::Mono.Cecil.ResourceType ResourceType
		{
			get
			{
				return global::Mono.Cecil.ResourceType.AssemblyLinked;
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0000E627 File Offset: 0x0000C827
		public AssemblyLinkedResource(string name, global::Mono.Cecil.ManifestResourceAttributes flags) : base(name, flags)
		{
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000E631 File Offset: 0x0000C831
		public AssemblyLinkedResource(string name, global::Mono.Cecil.ManifestResourceAttributes flags, global::Mono.Cecil.AssemblyNameReference reference) : base(name, flags)
		{
			this.reference = reference;
		}

		// Token: 0x040003A4 RID: 932
		private global::Mono.Cecil.AssemblyNameReference reference;
	}
}
