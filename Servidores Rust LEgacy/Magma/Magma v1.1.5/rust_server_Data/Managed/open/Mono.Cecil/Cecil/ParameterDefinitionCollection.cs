using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200006F RID: 111
	internal sealed class ParameterDefinitionCollection : global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition>
	{
		// Token: 0x060004E7 RID: 1255 RVA: 0x0000BB29 File Offset: 0x00009D29
		internal ParameterDefinitionCollection(global::Mono.Cecil.IMethodSignature method)
		{
			this.method = method;
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000BB38 File Offset: 0x00009D38
		internal ParameterDefinitionCollection(global::Mono.Cecil.IMethodSignature method, int capacity) : base(capacity)
		{
			this.method = method;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000BB48 File Offset: 0x00009D48
		protected override void OnAdd(global::Mono.Cecil.ParameterDefinition item, int index)
		{
			item.method = this.method;
			item.index = index;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000BB60 File Offset: 0x00009D60
		protected override void OnInsert(global::Mono.Cecil.ParameterDefinition item, int index)
		{
			item.method = this.method;
			item.index = index;
			for (int i = index; i < this.size; i++)
			{
				this.items[i].index = i + 1;
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000BBA1 File Offset: 0x00009DA1
		protected override void OnSet(global::Mono.Cecil.ParameterDefinition item, int index)
		{
			item.method = this.method;
			item.index = index;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0000BBB8 File Offset: 0x00009DB8
		protected override void OnRemove(global::Mono.Cecil.ParameterDefinition item, int index)
		{
			item.method = null;
			item.index = -1;
			for (int i = index + 1; i < this.size; i++)
			{
				this.items[i].index = i - 1;
			}
		}

		// Token: 0x040002F2 RID: 754
		private readonly global::Mono.Cecil.IMethodSignature method;
	}
}
