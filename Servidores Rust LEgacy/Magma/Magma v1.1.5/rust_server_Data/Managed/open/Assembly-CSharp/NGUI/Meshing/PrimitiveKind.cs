using System;

namespace NGUI.Meshing
{
	// Token: 0x020008FC RID: 2300
	public enum PrimitiveKind : byte
	{
		// Token: 0x04002B74 RID: 11124
		Triangle,
		// Token: 0x04002B75 RID: 11125
		Quad,
		// Token: 0x04002B76 RID: 11126
		Grid1x1 = 1,
		// Token: 0x04002B77 RID: 11127
		Grid2x1,
		// Token: 0x04002B78 RID: 11128
		Grid1x2,
		// Token: 0x04002B79 RID: 11129
		Grid2x2,
		// Token: 0x04002B7A RID: 11130
		Grid1x3,
		// Token: 0x04002B7B RID: 11131
		Grid3x1,
		// Token: 0x04002B7C RID: 11132
		Grid3x2,
		// Token: 0x04002B7D RID: 11133
		Grid2x3,
		// Token: 0x04002B7E RID: 11134
		Grid3x3,
		// Token: 0x04002B7F RID: 11135
		Hole3x3,
		// Token: 0x04002B80 RID: 11136
		Invalid = 0xFF
	}
}
