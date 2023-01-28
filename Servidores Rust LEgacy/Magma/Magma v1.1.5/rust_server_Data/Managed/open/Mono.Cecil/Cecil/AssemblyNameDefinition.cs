using System;

namespace Mono.Cecil
{
	// Token: 0x020000C3 RID: 195
	public sealed class AssemblyNameDefinition : global::Mono.Cecil.AssemblyNameReference
	{
		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x00015619 File Offset: 0x00013819
		public override byte[] Hash
		{
			get
			{
				return global::Mono.Empty<byte>.Array;
			}
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00015620 File Offset: 0x00013820
		internal AssemblyNameDefinition()
		{
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Assembly, 1);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x00015639 File Offset: 0x00013839
		public AssemblyNameDefinition(string name, global::System.Version version) : base(name, version)
		{
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Assembly, 1);
		}
	}
}
