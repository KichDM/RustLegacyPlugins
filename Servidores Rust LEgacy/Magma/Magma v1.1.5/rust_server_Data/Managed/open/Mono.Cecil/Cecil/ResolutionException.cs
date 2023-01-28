using System;

namespace Mono.Cecil
{
	// Token: 0x020000C5 RID: 197
	public class ResolutionException : global::System.Exception
	{
		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x000158F8 File Offset: 0x00013AF8
		public global::Mono.Cecil.MemberReference Member
		{
			get
			{
				return this.member;
			}
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00015900 File Offset: 0x00013B00
		public ResolutionException(global::Mono.Cecil.MemberReference member) : base("Failed to resolve " + member.FullName)
		{
			this.member = member;
		}

		// Token: 0x040005D9 RID: 1497
		private readonly global::Mono.Cecil.MemberReference member;
	}
}
