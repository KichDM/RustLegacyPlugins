using System;

namespace Mono.Cecil
{
	// Token: 0x020000A3 RID: 163
	public struct CustomAttributeNamedArgument
	{
		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x0001062B File Offset: 0x0000E82B
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x00010633 File Offset: 0x0000E833
		public global::Mono.Cecil.CustomAttributeArgument Argument
		{
			get
			{
				return this.argument;
			}
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0001063B File Offset: 0x0000E83B
		public CustomAttributeNamedArgument(string name, global::Mono.Cecil.CustomAttributeArgument argument)
		{
			global::Mono.Cecil.Mixin.CheckName(name);
			this.name = name;
			this.argument = argument;
		}

		// Token: 0x0400051B RID: 1307
		private readonly string name;

		// Token: 0x0400051C RID: 1308
		private readonly global::Mono.Cecil.CustomAttributeArgument argument;
	}
}
