using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000044 RID: 68
	public sealed class MethodBody : global::Mono.Cecil.Cil.IVariableDefinitionProvider
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0000943F File Offset: 0x0000763F
		public global::Mono.Cecil.MethodDefinition Method
		{
			get
			{
				return this.method;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00009447 File Offset: 0x00007647
		// (set) Token: 0x0600034E RID: 846 RVA: 0x0000944F File Offset: 0x0000764F
		public int MaxStackSize
		{
			get
			{
				return this.max_stack_size;
			}
			set
			{
				this.max_stack_size = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00009458 File Offset: 0x00007658
		// (set) Token: 0x06000350 RID: 848 RVA: 0x00009460 File Offset: 0x00007660
		public int CodeSize
		{
			get
			{
				return this.code_size;
			}
			set
			{
				this.code_size = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00009469 File Offset: 0x00007669
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00009471 File Offset: 0x00007671
		public bool InitLocals
		{
			get
			{
				return this.init_locals;
			}
			set
			{
				this.init_locals = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000947A File Offset: 0x0000767A
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00009482 File Offset: 0x00007682
		public global::Mono.Cecil.MetadataToken LocalVarToken
		{
			get
			{
				return this.local_var_token;
			}
			set
			{
				this.local_var_token = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000948C File Offset: 0x0000768C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> Instructions
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> result;
				if ((result = this.instructions) == null)
				{
					result = (this.instructions = new global::Mono.Cecil.Cil.InstructionCollection());
				}
				return result;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000356 RID: 854 RVA: 0x000094B1 File Offset: 0x000076B1
		public bool HasExceptionHandlers
		{
			get
			{
				return !this.exceptions.IsNullOrEmpty<global::Mono.Cecil.Cil.ExceptionHandler>();
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000357 RID: 855 RVA: 0x000094C4 File Offset: 0x000076C4
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> ExceptionHandlers
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> result;
				if ((result = this.exceptions) == null)
				{
					result = (this.exceptions = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler>());
				}
				return result;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000358 RID: 856 RVA: 0x000094E9 File Offset: 0x000076E9
		public bool HasVariables
		{
			get
			{
				return !this.variables.IsNullOrEmpty<global::Mono.Cecil.Cil.VariableDefinition>();
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000359 RID: 857 RVA: 0x000094FC File Offset: 0x000076FC
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> Variables
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> result;
				if ((result = this.variables) == null)
				{
					result = (this.variables = new global::Mono.Cecil.Cil.VariableDefinitionCollection());
				}
				return result;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00009521 File Offset: 0x00007721
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00009529 File Offset: 0x00007729
		public global::Mono.Cecil.Cil.Scope Scope
		{
			get
			{
				return this.scope;
			}
			set
			{
				this.scope = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00009534 File Offset: 0x00007734
		public global::Mono.Cecil.ParameterDefinition ThisParameter
		{
			get
			{
				if (this.method == null || this.method.DeclaringType == null)
				{
					throw new global::System.NotSupportedException();
				}
				global::Mono.Cecil.ParameterDefinition result;
				if ((result = this.this_parameter) == null)
				{
					result = (this.this_parameter = new global::Mono.Cecil.ParameterDefinition("0", global::Mono.Cecil.ParameterAttributes.None, this.method.DeclaringType));
				}
				return result;
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00009585 File Offset: 0x00007785
		public MethodBody(global::Mono.Cecil.MethodDefinition method)
		{
			this.method = method;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00009594 File Offset: 0x00007794
		public global::Mono.Cecil.Cil.ILProcessor GetILProcessor()
		{
			return new global::Mono.Cecil.Cil.ILProcessor(this);
		}

		// Token: 0x0400021F RID: 543
		internal readonly global::Mono.Cecil.MethodDefinition method;

		// Token: 0x04000220 RID: 544
		internal global::Mono.Cecil.ParameterDefinition this_parameter;

		// Token: 0x04000221 RID: 545
		internal int max_stack_size;

		// Token: 0x04000222 RID: 546
		internal int code_size;

		// Token: 0x04000223 RID: 547
		internal bool init_locals;

		// Token: 0x04000224 RID: 548
		internal global::Mono.Cecil.MetadataToken local_var_token;

		// Token: 0x04000225 RID: 549
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions;

		// Token: 0x04000226 RID: 550
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> exceptions;

		// Token: 0x04000227 RID: 551
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables;

		// Token: 0x04000228 RID: 552
		private global::Mono.Cecil.Cil.Scope scope;
	}
}
