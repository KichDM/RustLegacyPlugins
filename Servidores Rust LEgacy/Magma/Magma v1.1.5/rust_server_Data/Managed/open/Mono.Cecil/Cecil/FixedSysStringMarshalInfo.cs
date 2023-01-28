using System;

namespace Mono.Cecil
{
	// Token: 0x02000069 RID: 105
	public sealed class FixedSysStringMarshalInfo : global::Mono.Cecil.MarshalInfo
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x0000AA55 File Offset: 0x00008C55
		// (set) Token: 0x06000445 RID: 1093 RVA: 0x0000AA5D File Offset: 0x00008C5D
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

		// Token: 0x06000446 RID: 1094 RVA: 0x0000AA66 File Offset: 0x00008C66
		public FixedSysStringMarshalInfo() : base(global::Mono.Cecil.NativeType.FixedSysString)
		{
			this.size = -1;
		}

		// Token: 0x040002CB RID: 715
		internal int size;
	}
}
