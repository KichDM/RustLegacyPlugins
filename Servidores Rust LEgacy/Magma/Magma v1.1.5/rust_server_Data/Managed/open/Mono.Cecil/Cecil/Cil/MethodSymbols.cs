using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200003D RID: 61
	public sealed class MethodSymbols
	{
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000920A File Offset: 0x0000740A
		public bool HasVariables
		{
			get
			{
				return !this.variables.IsNullOrEmpty<global::Mono.Cecil.Cil.VariableDefinition>();
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000921A File Offset: 0x0000741A
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

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00009235 File Offset: 0x00007435
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.InstructionSymbol> Instructions
		{
			get
			{
				if (this.instructions == null)
				{
					this.instructions = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.InstructionSymbol>();
				}
				return this.instructions;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00009250 File Offset: 0x00007450
		public int CodeSize
		{
			get
			{
				return this.code_size;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00009258 File Offset: 0x00007458
		public string MethodName
		{
			get
			{
				return this.method_name;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00009260 File Offset: 0x00007460
		public global::Mono.Cecil.MetadataToken MethodToken
		{
			get
			{
				return this.method_token;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00009268 File Offset: 0x00007468
		public global::Mono.Cecil.MetadataToken LocalVarToken
		{
			get
			{
				return this.local_var_token;
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00009270 File Offset: 0x00007470
		internal MethodSymbols(string methodName)
		{
			this.method_name = methodName;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000927F File Offset: 0x0000747F
		public MethodSymbols(global::Mono.Cecil.MetadataToken methodToken)
		{
			this.method_token = methodToken;
		}

		// Token: 0x04000216 RID: 534
		internal int code_size;

		// Token: 0x04000217 RID: 535
		internal string method_name;

		// Token: 0x04000218 RID: 536
		internal global::Mono.Cecil.MetadataToken method_token;

		// Token: 0x04000219 RID: 537
		internal global::Mono.Cecil.MetadataToken local_var_token;

		// Token: 0x0400021A RID: 538
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables;

		// Token: 0x0400021B RID: 539
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.InstructionSymbol> instructions;
	}
}
