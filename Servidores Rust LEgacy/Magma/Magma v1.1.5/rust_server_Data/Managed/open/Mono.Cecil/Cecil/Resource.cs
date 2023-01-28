using System;

namespace Mono.Cecil
{
	// Token: 0x0200005F RID: 95
	public abstract class Resource
	{
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000A762 File Offset: 0x00008962
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x0000A76A File Offset: 0x0000896A
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000A773 File Offset: 0x00008973
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000A77B File Offset: 0x0000897B
		public global::Mono.Cecil.ManifestResourceAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.ManifestResourceAttributes)this.attributes;
			}
			set
			{
				this.attributes = (uint)value;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000401 RID: 1025
		public abstract global::Mono.Cecil.ResourceType ResourceType { get; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x0000A784 File Offset: 0x00008984
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x0000A793 File Offset: 0x00008993
		public bool IsPublic
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 1U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 1U, value);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000A7A9 File Offset: 0x000089A9
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x0000A7B8 File Offset: 0x000089B8
		public bool IsPrivate
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 2U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 2U, value);
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000A7CE File Offset: 0x000089CE
		internal Resource(string name, global::Mono.Cecil.ManifestResourceAttributes attributes)
		{
			this.name = name;
			this.attributes = (uint)attributes;
		}

		// Token: 0x040002AD RID: 685
		private string name;

		// Token: 0x040002AE RID: 686
		private uint attributes;
	}
}
