using System;
using System.IO;

namespace Mono.Cecil
{
	// Token: 0x020000A1 RID: 161
	public sealed class EmbeddedResource : global::Mono.Cecil.Resource
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x00010548 File Offset: 0x0000E748
		// (set) Token: 0x06000691 RID: 1681 RVA: 0x000105A0 File Offset: 0x0000E7A0
		public byte[] Data
		{
			get
			{
				if (this.deferredloading)
				{
					if (this.offset == null)
					{
						throw new global::System.InvalidOperationException();
					}
					this.data = this.reader.GetManagedResourceStream(this.offset.Value).ToArray();
					this.deferredloading = false;
				}
				return this.data;
			}
			set
			{
				this.deferredloading = false;
				this.data = value;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x000105B0 File Offset: 0x0000E7B0
		public override global::Mono.Cecil.ResourceType ResourceType
		{
			get
			{
				return global::Mono.Cecil.ResourceType.Embedded;
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x000105B3 File Offset: 0x0000E7B3
		public EmbeddedResource(string name, global::Mono.Cecil.ManifestResourceAttributes attributes, byte[] data) : base(name, attributes)
		{
			this.Data = data;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x000105CB File Offset: 0x0000E7CB
		internal EmbeddedResource(string name, global::Mono.Cecil.ManifestResourceAttributes attributes, uint offset, global::Mono.Cecil.MetadataReader reader) : base(name, attributes)
		{
			this.offset = new uint?(offset);
			this.reader = reader;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x000105F0 File Offset: 0x0000E7F0
		public global::System.IO.Stream GetResourceStream()
		{
			return new global::System.IO.MemoryStream(this.Data);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x000105FD File Offset: 0x0000E7FD
		[global::System.Obsolete("GetResourceData method is now deprecated, please use Data property instead")]
		public byte[] GetResourceData()
		{
			return this.Data;
		}

		// Token: 0x04000515 RID: 1301
		private readonly global::Mono.Cecil.MetadataReader reader;

		// Token: 0x04000516 RID: 1302
		private uint? offset;

		// Token: 0x04000517 RID: 1303
		private byte[] data;

		// Token: 0x04000518 RID: 1304
		private bool deferredloading = true;
	}
}
