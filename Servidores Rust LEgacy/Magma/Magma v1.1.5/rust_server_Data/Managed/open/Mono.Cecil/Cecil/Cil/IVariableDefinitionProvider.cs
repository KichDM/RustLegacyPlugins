using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200003A RID: 58
	public interface IVariableDefinitionProvider
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000323 RID: 803
		bool HasVariables { get; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000324 RID: 804
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> Variables { get; }
	}
}
