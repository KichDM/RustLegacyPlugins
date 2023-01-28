using System;

namespace Mono.Cecil
{
	// Token: 0x02000062 RID: 98
	public sealed class ModuleParameters
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000A851 File Offset: 0x00008A51
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000A859 File Offset: 0x00008A59
		public global::Mono.Cecil.ModuleKind Kind
		{
			get
			{
				return this.kind;
			}
			set
			{
				this.kind = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0000A862 File Offset: 0x00008A62
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0000A86A File Offset: 0x00008A6A
		public global::Mono.Cecil.TargetRuntime Runtime
		{
			get
			{
				return this.runtime;
			}
			set
			{
				this.runtime = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000A873 File Offset: 0x00008A73
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000A87B File Offset: 0x00008A7B
		public global::Mono.Cecil.TargetArchitecture Architecture
		{
			get
			{
				return this.architecture;
			}
			set
			{
				this.architecture = value;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000A884 File Offset: 0x00008A84
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000A88C File Offset: 0x00008A8C
		public global::Mono.Cecil.IAssemblyResolver AssemblyResolver
		{
			get
			{
				return this.assembly_resolver;
			}
			set
			{
				this.assembly_resolver = value;
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000A895 File Offset: 0x00008A95
		public ModuleParameters()
		{
			this.kind = global::Mono.Cecil.ModuleKind.Dll;
			this.runtime = global::Mono.Cecil.ModuleParameters.GetCurrentRuntime();
			this.architecture = global::Mono.Cecil.TargetArchitecture.I386;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000A8B6 File Offset: 0x00008AB6
		private static global::Mono.Cecil.TargetRuntime GetCurrentRuntime()
		{
			return typeof(object).Assembly.ImageRuntimeVersion.ParseRuntime();
		}

		// Token: 0x040002B7 RID: 695
		private global::Mono.Cecil.ModuleKind kind;

		// Token: 0x040002B8 RID: 696
		private global::Mono.Cecil.TargetRuntime runtime;

		// Token: 0x040002B9 RID: 697
		private global::Mono.Cecil.TargetArchitecture architecture;

		// Token: 0x040002BA RID: 698
		private global::Mono.Cecil.IAssemblyResolver assembly_resolver;
	}
}
