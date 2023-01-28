using System;

namespace Mono.Cecil
{
	// Token: 0x02000017 RID: 23
	public interface IModifierType
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600010C RID: 268
		global::Mono.Cecil.TypeReference ModifierType { get; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600010D RID: 269
		global::Mono.Cecil.TypeReference ElementType { get; }
	}
}
