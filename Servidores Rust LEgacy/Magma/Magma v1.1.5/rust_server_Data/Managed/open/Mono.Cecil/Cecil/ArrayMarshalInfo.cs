using System;

namespace Mono.Cecil
{
	// Token: 0x02000065 RID: 101
	public sealed class ArrayMarshalInfo : global::Mono.Cecil.MarshalInfo
	{
		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000A946 File Offset: 0x00008B46
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x0000A94E File Offset: 0x00008B4E
		public global::Mono.Cecil.NativeType ElementType
		{
			get
			{
				return this.element_type;
			}
			set
			{
				this.element_type = value;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000A957 File Offset: 0x00008B57
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000A95F File Offset: 0x00008B5F
		public int SizeParameterIndex
		{
			get
			{
				return this.size_parameter_index;
			}
			set
			{
				this.size_parameter_index = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x0000A968 File Offset: 0x00008B68
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x0000A970 File Offset: 0x00008B70
		public int Size
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000A979 File Offset: 0x00008B79
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x0000A981 File Offset: 0x00008B81
		public int SizeParameterMultiplier
		{
			get
			{
				return this.size_parameter_multiplier;
			}
			set
			{
				this.size_parameter_multiplier = value;
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0000A98A File Offset: 0x00008B8A
		public ArrayMarshalInfo() : base(global::Mono.Cecil.NativeType.Array)
		{
			this.element_type = global::Mono.Cecil.NativeType.None;
			this.size_parameter_index = -1;
			this.size = -1;
			this.size_parameter_multiplier = -1;
		}

		// Token: 0x040002C0 RID: 704
		internal global::Mono.Cecil.NativeType element_type;

		// Token: 0x040002C1 RID: 705
		internal int size_parameter_index;

		// Token: 0x040002C2 RID: 706
		internal int size;

		// Token: 0x040002C3 RID: 707
		internal int size_parameter_multiplier;
	}
}
