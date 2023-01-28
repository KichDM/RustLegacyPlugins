using System;

namespace Mono.Cecil
{
	// Token: 0x0200000B RID: 11
	internal interface IGenericContext
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000042 RID: 66
		bool IsDefinition { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000043 RID: 67
		global::Mono.Cecil.IGenericParameterProvider Type { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000044 RID: 68
		global::Mono.Cecil.IGenericParameterProvider Method { get; }
	}
}
