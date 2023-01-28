using System;

namespace Mono.Cecil
{
	// Token: 0x020000A2 RID: 162
	public struct CustomAttributeArgument
	{
		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x00010605 File Offset: 0x0000E805
		public global::Mono.Cecil.TypeReference Type
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x0001060D File Offset: 0x0000E80D
		public object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00010615 File Offset: 0x0000E815
		public CustomAttributeArgument(global::Mono.Cecil.TypeReference type, object value)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			this.type = type;
			this.value = value;
		}

		// Token: 0x04000519 RID: 1305
		private readonly global::Mono.Cecil.TypeReference type;

		// Token: 0x0400051A RID: 1306
		private readonly object value;
	}
}
