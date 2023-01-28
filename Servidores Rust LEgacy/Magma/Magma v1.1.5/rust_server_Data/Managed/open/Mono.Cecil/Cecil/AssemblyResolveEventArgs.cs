using System;

namespace Mono.Cecil
{
	// Token: 0x02000071 RID: 113
	public sealed class AssemblyResolveEventArgs : global::System.EventArgs
	{
		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000BBF6 File Offset: 0x00009DF6
		public global::Mono.Cecil.AssemblyNameReference AssemblyReference
		{
			get
			{
				return this.reference;
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000BBFE File Offset: 0x00009DFE
		public AssemblyResolveEventArgs(global::Mono.Cecil.AssemblyNameReference reference)
		{
			this.reference = reference;
		}

		// Token: 0x040002F3 RID: 755
		private readonly global::Mono.Cecil.AssemblyNameReference reference;
	}
}
