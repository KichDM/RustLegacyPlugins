using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000045 RID: 69
	internal class VariableDefinitionCollection : global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition>
	{
		// Token: 0x0600035F RID: 863 RVA: 0x0000959C File Offset: 0x0000779C
		internal VariableDefinitionCollection()
		{
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000095A4 File Offset: 0x000077A4
		internal VariableDefinitionCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000361 RID: 865 RVA: 0x000095AD File Offset: 0x000077AD
		protected override void OnAdd(global::Mono.Cecil.Cil.VariableDefinition item, int index)
		{
			item.index = index;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000095B8 File Offset: 0x000077B8
		protected override void OnInsert(global::Mono.Cecil.Cil.VariableDefinition item, int index)
		{
			item.index = index;
			for (int i = index; i < this.size; i++)
			{
				this.items[i].index = i + 1;
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000095ED File Offset: 0x000077ED
		protected override void OnSet(global::Mono.Cecil.Cil.VariableDefinition item, int index)
		{
			item.index = index;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x000095F8 File Offset: 0x000077F8
		protected override void OnRemove(global::Mono.Cecil.Cil.VariableDefinition item, int index)
		{
			item.index = -1;
			for (int i = index + 1; i < this.size; i++)
			{
				this.items[i].index = i - 1;
			}
		}
	}
}
