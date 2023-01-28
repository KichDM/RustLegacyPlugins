using System;

namespace Mono.Cecil
{
	// Token: 0x02000064 RID: 100
	public class MarshalInfo
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000A91D File Offset: 0x00008B1D
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x0000A925 File Offset: 0x00008B25
		public global::Mono.Cecil.NativeType NativeType
		{
			get
			{
				return this.native;
			}
			set
			{
				this.native = value;
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000A92E File Offset: 0x00008B2E
		public MarshalInfo(global::Mono.Cecil.NativeType native)
		{
			this.native = native;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000A93D File Offset: 0x00008B3D
		public virtual void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitMarshalSpec(this);
		}

		// Token: 0x040002BF RID: 703
		internal global::Mono.Cecil.NativeType native;
	}
}
