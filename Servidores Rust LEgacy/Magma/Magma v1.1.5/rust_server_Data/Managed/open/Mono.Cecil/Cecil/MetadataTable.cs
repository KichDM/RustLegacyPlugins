using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000C8 RID: 200
	internal abstract class MetadataTable
	{
		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000813 RID: 2067
		public abstract int Length { get; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x00015FF4 File Offset: 0x000141F4
		public bool IsLarge
		{
			get
			{
				return this.Length > 0xFFFF;
			}
		}

		// Token: 0x06000815 RID: 2069
		public abstract void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer);

		// Token: 0x06000816 RID: 2070
		public abstract void Sort();

		// Token: 0x06000817 RID: 2071 RVA: 0x00016003 File Offset: 0x00014203
		protected MetadataTable()
		{
		}
	}
}
