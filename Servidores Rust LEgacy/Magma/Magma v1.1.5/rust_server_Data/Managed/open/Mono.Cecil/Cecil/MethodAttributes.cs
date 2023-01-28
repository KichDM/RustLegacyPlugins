using System;

namespace Mono.Cecil
{
	// Token: 0x0200001C RID: 28
	[global::System.Flags]
	public enum MethodAttributes : ushort
	{
		// Token: 0x04000063 RID: 99
		MemberAccessMask = 7,
		// Token: 0x04000064 RID: 100
		CompilerControlled = 0,
		// Token: 0x04000065 RID: 101
		Private = 1,
		// Token: 0x04000066 RID: 102
		FamANDAssem = 2,
		// Token: 0x04000067 RID: 103
		Assembly = 3,
		// Token: 0x04000068 RID: 104
		Family = 4,
		// Token: 0x04000069 RID: 105
		FamORAssem = 5,
		// Token: 0x0400006A RID: 106
		Public = 6,
		// Token: 0x0400006B RID: 107
		Static = 0x10,
		// Token: 0x0400006C RID: 108
		Final = 0x20,
		// Token: 0x0400006D RID: 109
		Virtual = 0x40,
		// Token: 0x0400006E RID: 110
		HideBySig = 0x80,
		// Token: 0x0400006F RID: 111
		VtableLayoutMask = 0x100,
		// Token: 0x04000070 RID: 112
		ReuseSlot = 0,
		// Token: 0x04000071 RID: 113
		NewSlot = 0x100,
		// Token: 0x04000072 RID: 114
		CheckAccessOnOverride = 0x200,
		// Token: 0x04000073 RID: 115
		Abstract = 0x400,
		// Token: 0x04000074 RID: 116
		SpecialName = 0x800,
		// Token: 0x04000075 RID: 117
		PInvokeImpl = 0x2000,
		// Token: 0x04000076 RID: 118
		UnmanagedExport = 8,
		// Token: 0x04000077 RID: 119
		RTSpecialName = 0x1000,
		// Token: 0x04000078 RID: 120
		HasSecurity = 0x4000,
		// Token: 0x04000079 RID: 121
		RequireSecObject = 0x8000
	}
}
