using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000027 RID: 39
	public abstract class MethodSpecification : global::Mono.Cecil.MethodReference
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000066D4 File Offset: 0x000048D4
		public global::Mono.Cecil.MethodReference ElementMethod
		{
			get
			{
				return this.method;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000066DC File Offset: 0x000048DC
		// (set) Token: 0x060001BC RID: 444 RVA: 0x000066E9 File Offset: 0x000048E9
		public override string Name
		{
			get
			{
				return this.method.Name;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001BD RID: 445 RVA: 0x000066F0 File Offset: 0x000048F0
		// (set) Token: 0x060001BE RID: 446 RVA: 0x000066FD File Offset: 0x000048FD
		public override global::Mono.Cecil.MethodCallingConvention CallingConvention
		{
			get
			{
				return this.method.CallingConvention;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00006704 File Offset: 0x00004904
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00006711 File Offset: 0x00004911
		public override bool HasThis
		{
			get
			{
				return this.method.HasThis;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00006718 File Offset: 0x00004918
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00006725 File Offset: 0x00004925
		public override bool ExplicitThis
		{
			get
			{
				return this.method.ExplicitThis;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000672C File Offset: 0x0000492C
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00006739 File Offset: 0x00004939
		public override global::Mono.Cecil.MethodReturnType MethodReturnType
		{
			get
			{
				return this.method.MethodReturnType;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00006740 File Offset: 0x00004940
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000674D File Offset: 0x0000494D
		public override global::Mono.Cecil.TypeReference DeclaringType
		{
			get
			{
				return this.method.DeclaringType;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00006754 File Offset: 0x00004954
		public override global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				return this.method.Module;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00006761 File Offset: 0x00004961
		public override bool HasParameters
		{
			get
			{
				return this.method.HasParameters;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000676E File Offset: 0x0000496E
		public override global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters
		{
			get
			{
				return this.method.Parameters;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060001CA RID: 458 RVA: 0x0000677B File Offset: 0x0000497B
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.method.ContainsGenericParameter;
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00006788 File Offset: 0x00004988
		internal MethodSpecification(global::Mono.Cecil.MethodReference method)
		{
			if (method == null)
			{
				throw new global::System.ArgumentNullException("method");
			}
			this.method = method;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MethodSpec);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000067B5 File Offset: 0x000049B5
		public sealed override global::Mono.Cecil.MethodReference GetElementMethod()
		{
			return this.method.GetElementMethod();
		}

		// Token: 0x04000184 RID: 388
		private readonly global::Mono.Cecil.MethodReference method;
	}
}
