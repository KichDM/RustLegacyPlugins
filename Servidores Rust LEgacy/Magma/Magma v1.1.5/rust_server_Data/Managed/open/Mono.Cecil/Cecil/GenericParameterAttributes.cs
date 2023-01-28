using System;

namespace Mono.Cecil
{
	// Token: 0x0200009E RID: 158
	[global::System.Flags]
	public enum GenericParameterAttributes : ushort
	{
		// Token: 0x040004F9 RID: 1273
		VarianceMask = 3,
		// Token: 0x040004FA RID: 1274
		NonVariant = 0,
		// Token: 0x040004FB RID: 1275
		Covariant = 1,
		// Token: 0x040004FC RID: 1276
		Contravariant = 2,
		// Token: 0x040004FD RID: 1277
		SpecialConstraintMask = 0x1C,
		// Token: 0x040004FE RID: 1278
		ReferenceTypeConstraint = 4,
		// Token: 0x040004FF RID: 1279
		NotNullableValueTypeConstraint = 8,
		// Token: 0x04000500 RID: 1280
		DefaultConstructorConstraint = 0x10
	}
}
