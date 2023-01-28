using System;

namespace Mono.Cecil
{
	// Token: 0x02000028 RID: 40
	public interface IMemberDefinition : global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060001CD RID: 461
		// (set) Token: 0x060001CE RID: 462
		string Name { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060001CF RID: 463
		string FullName { get; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060001D0 RID: 464
		// (set) Token: 0x060001D1 RID: 465
		bool IsSpecialName { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060001D2 RID: 466
		// (set) Token: 0x060001D3 RID: 467
		bool IsRuntimeSpecialName { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060001D4 RID: 468
		// (set) Token: 0x060001D5 RID: 469
		global::Mono.Cecil.TypeDefinition DeclaringType { get; set; }
	}
}
