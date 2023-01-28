using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x020000B4 RID: 180
	public sealed class VariableDefinition : global::Mono.Cecil.Cil.VariableReference
	{
		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x0001376C File Offset: 0x0001196C
		public bool IsPinned
		{
			get
			{
				return this.variable_type.IsPinned;
			}
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00013779 File Offset: 0x00011979
		public VariableDefinition(global::Mono.Cecil.TypeReference variableType) : base(variableType)
		{
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00013782 File Offset: 0x00011982
		public VariableDefinition(string name, global::Mono.Cecil.TypeReference variableType) : base(name, variableType)
		{
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001378C File Offset: 0x0001198C
		public override global::Mono.Cecil.Cil.VariableDefinition Resolve()
		{
			return this;
		}
	}
}
