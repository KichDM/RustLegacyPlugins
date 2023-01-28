using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200003B RID: 59
	public sealed class Scope : global::Mono.Cecil.Cil.IVariableDefinitionProvider
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000917A File Offset: 0x0000737A
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00009182 File Offset: 0x00007382
		public global::Mono.Cecil.Cil.Instruction Start
		{
			get
			{
				return this.start;
			}
			set
			{
				this.start = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0000918B File Offset: 0x0000738B
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00009193 File Offset: 0x00007393
		public global::Mono.Cecil.Cil.Instruction End
		{
			get
			{
				return this.end;
			}
			set
			{
				this.end = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000919C File Offset: 0x0000739C
		public bool HasScopes
		{
			get
			{
				return !this.scopes.IsNullOrEmpty<global::Mono.Cecil.Cil.Scope>();
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600032A RID: 810 RVA: 0x000091AC File Offset: 0x000073AC
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Scope> Scopes
		{
			get
			{
				if (this.scopes == null)
				{
					this.scopes = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Scope>();
				}
				return this.scopes;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600032B RID: 811 RVA: 0x000091C7 File Offset: 0x000073C7
		public bool HasVariables
		{
			get
			{
				return !this.variables.IsNullOrEmpty<global::Mono.Cecil.Cil.VariableDefinition>();
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600032C RID: 812 RVA: 0x000091D7 File Offset: 0x000073D7
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> Variables
		{
			get
			{
				if (this.variables == null)
				{
					this.variables = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition>();
				}
				return this.variables;
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000091F2 File Offset: 0x000073F2
		public Scope()
		{
		}

		// Token: 0x04000210 RID: 528
		private global::Mono.Cecil.Cil.Instruction start;

		// Token: 0x04000211 RID: 529
		private global::Mono.Cecil.Cil.Instruction end;

		// Token: 0x04000212 RID: 530
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Scope> scopes;

		// Token: 0x04000213 RID: 531
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables;
	}
}
