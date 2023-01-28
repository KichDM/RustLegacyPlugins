using System;

namespace Mono.Cecil
{
	// Token: 0x020000C0 RID: 192
	public static class GlobalAssemblyResolver
	{
		// Token: 0x060007C4 RID: 1988 RVA: 0x000153EA File Offset: 0x000135EA
		// Note: this type is marked as 'beforefieldinit'.
		static GlobalAssemblyResolver()
		{
		}

		// Token: 0x040005D0 RID: 1488
		public static readonly global::Mono.Cecil.IAssemblyResolver Instance = new global::Mono.Cecil.DefaultAssemblyResolver();
	}
}
