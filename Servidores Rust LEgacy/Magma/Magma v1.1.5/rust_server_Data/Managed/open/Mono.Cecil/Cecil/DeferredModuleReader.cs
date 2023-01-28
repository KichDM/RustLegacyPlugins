using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.PE;

namespace Mono.Cecil
{
	// Token: 0x020000F3 RID: 243
	internal sealed class DeferredModuleReader : global::Mono.Cecil.ModuleReader
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x0001A13C File Offset: 0x0001833C
		public DeferredModuleReader(global::Mono.Cecil.PE.Image image) : base(image, global::Mono.Cecil.ReadingMode.Deferred)
		{
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0001A150 File Offset: 0x00018350
		protected override void ReadModule()
		{
			this.module.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.ModuleDefinition>(this.module, delegate(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataReader reader)
			{
				base.ReadModuleManifest(reader);
				return module;
			});
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0001A146 File Offset: 0x00018346
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.ModuleDefinition <ReadModule>b__0(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataReader reader)
		{
			base.ReadModuleManifest(reader);
			return module;
		}
	}
}
