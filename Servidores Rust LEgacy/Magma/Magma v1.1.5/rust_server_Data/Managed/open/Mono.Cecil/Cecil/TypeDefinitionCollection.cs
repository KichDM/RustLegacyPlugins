using System;
using System.Collections.Generic;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000048 RID: 72
	internal sealed class TypeDefinitionCollection : global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition>
	{
		// Token: 0x0600036C RID: 876 RVA: 0x00009760 File Offset: 0x00007960
		internal TypeDefinitionCollection(global::Mono.Cecil.ModuleDefinition container)
		{
			this.container = container;
			this.name_cache = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.TypeDefinition>(new global::Mono.Cecil.Metadata.RowEqualityComparer());
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000977F File Offset: 0x0000797F
		internal TypeDefinitionCollection(global::Mono.Cecil.ModuleDefinition container, int capacity) : base(capacity)
		{
			this.container = container;
			this.name_cache = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.TypeDefinition>(capacity, new global::Mono.Cecil.Metadata.RowEqualityComparer());
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000097A0 File Offset: 0x000079A0
		protected override void OnAdd(global::Mono.Cecil.TypeDefinition item, int index)
		{
			this.Attach(item);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000097A9 File Offset: 0x000079A9
		protected override void OnSet(global::Mono.Cecil.TypeDefinition item, int index)
		{
			this.Attach(item);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000097B2 File Offset: 0x000079B2
		protected override void OnInsert(global::Mono.Cecil.TypeDefinition item, int index)
		{
			this.Attach(item);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x000097BB File Offset: 0x000079BB
		protected override void OnRemove(global::Mono.Cecil.TypeDefinition item, int index)
		{
			this.Detach(item);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000097C4 File Offset: 0x000079C4
		protected override void OnClear()
		{
			foreach (global::Mono.Cecil.TypeDefinition type in this)
			{
				this.Detach(type);
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00009814 File Offset: 0x00007A14
		private void Attach(global::Mono.Cecil.TypeDefinition type)
		{
			if (type.Module != null && type.Module != this.container)
			{
				throw new global::System.ArgumentException("Type already attached");
			}
			type.module = this.container;
			type.scope = this.container;
			this.name_cache[new global::Mono.Cecil.Metadata.Row<string, string>(type.Namespace, type.Name)] = type;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00009877 File Offset: 0x00007A77
		private void Detach(global::Mono.Cecil.TypeDefinition type)
		{
			type.module = null;
			type.scope = null;
			this.name_cache.Remove(new global::Mono.Cecil.Metadata.Row<string, string>(type.Namespace, type.Name));
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000098A4 File Offset: 0x00007AA4
		public global::Mono.Cecil.TypeDefinition GetType(string fullname)
		{
			string @namespace;
			string name;
			global::Mono.Cecil.TypeParser.SplitFullName(fullname, out @namespace, out name);
			return this.GetType(@namespace, name);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000098C4 File Offset: 0x00007AC4
		public global::Mono.Cecil.TypeDefinition GetType(string @namespace, string name)
		{
			global::Mono.Cecil.TypeDefinition result;
			if (this.name_cache.TryGetValue(new global::Mono.Cecil.Metadata.Row<string, string>(@namespace, name), out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0400022A RID: 554
		private readonly global::Mono.Cecil.ModuleDefinition container;

		// Token: 0x0400022B RID: 555
		private readonly global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.TypeDefinition> name_cache;
	}
}
