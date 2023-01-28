using System;
using System.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000C1 RID: 193
	public class DefaultAssemblyResolver : global::Mono.Cecil.BaseAssemblyResolver
	{
		// Token: 0x060007C5 RID: 1989 RVA: 0x000153F6 File Offset: 0x000135F6
		public DefaultAssemblyResolver()
		{
			this.cache = new global::System.Collections.Generic.Dictionary<string, global::Mono.Cecil.AssemblyDefinition>();
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0001540C File Offset: 0x0001360C
		public override global::Mono.Cecil.AssemblyDefinition Resolve(global::Mono.Cecil.AssemblyNameReference name)
		{
			if (name == null)
			{
				throw new global::System.ArgumentNullException("name");
			}
			global::Mono.Cecil.AssemblyDefinition assemblyDefinition;
			if (this.cache.TryGetValue(name.FullName, out assemblyDefinition))
			{
				return assemblyDefinition;
			}
			assemblyDefinition = base.Resolve(name);
			this.cache[name.FullName] = assemblyDefinition;
			return assemblyDefinition;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0001545C File Offset: 0x0001365C
		protected void RegisterAssembly(global::Mono.Cecil.AssemblyDefinition assembly)
		{
			if (assembly == null)
			{
				throw new global::System.ArgumentNullException("assembly");
			}
			string fullName = assembly.Name.FullName;
			if (this.cache.ContainsKey(fullName))
			{
				return;
			}
			this.cache[fullName] = assembly;
		}

		// Token: 0x040005D1 RID: 1489
		private readonly global::System.Collections.Generic.IDictionary<string, global::Mono.Cecil.AssemblyDefinition> cache;
	}
}
