using System;

namespace Mono.Cecil
{
	// Token: 0x020000BF RID: 191
	public sealed class LinkedResource : global::Mono.Cecil.Resource
	{
		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x000153AA File Offset: 0x000135AA
		// (set) Token: 0x060007BE RID: 1982 RVA: 0x000153B2 File Offset: 0x000135B2
		public byte[] Hash
		{
			get
			{
				return this.hash;
			}
			set
			{
				this.hash = value;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x000153BB File Offset: 0x000135BB
		// (set) Token: 0x060007C0 RID: 1984 RVA: 0x000153C3 File Offset: 0x000135C3
		public string File
		{
			get
			{
				return this.file;
			}
			set
			{
				this.file = value;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x000153CC File Offset: 0x000135CC
		public override global::Mono.Cecil.ResourceType ResourceType
		{
			get
			{
				return global::Mono.Cecil.ResourceType.Linked;
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x000153CF File Offset: 0x000135CF
		public LinkedResource(string name, global::Mono.Cecil.ManifestResourceAttributes flags) : base(name, flags)
		{
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x000153D9 File Offset: 0x000135D9
		public LinkedResource(string name, global::Mono.Cecil.ManifestResourceAttributes flags, string file) : base(name, flags)
		{
			this.file = file;
		}

		// Token: 0x040005CE RID: 1486
		internal byte[] hash;

		// Token: 0x040005CF RID: 1487
		private string file;
	}
}
