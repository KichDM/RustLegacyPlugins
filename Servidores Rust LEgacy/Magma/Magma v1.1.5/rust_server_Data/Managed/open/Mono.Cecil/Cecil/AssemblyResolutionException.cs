using System;
using System.IO;

namespace Mono.Cecil
{
	// Token: 0x02000072 RID: 114
	public class AssemblyResolutionException : global::System.IO.FileNotFoundException
	{
		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0000BC0D File Offset: 0x00009E0D
		public global::Mono.Cecil.AssemblyNameReference AssemblyReference
		{
			get
			{
				return this.reference;
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000BC15 File Offset: 0x00009E15
		public AssemblyResolutionException(global::Mono.Cecil.AssemblyNameReference reference) : base(string.Format("Failed to resolve assembly: '{0}'", reference))
		{
			this.reference = reference;
		}

		// Token: 0x040002F4 RID: 756
		private readonly global::Mono.Cecil.AssemblyNameReference reference;
	}
}
