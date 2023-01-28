using System;
using System.Text;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200004D RID: 77
	public sealed class GenericInstanceMethod : global::Mono.Cecil.MethodSpecification, global::Mono.Cecil.IGenericInstance, global::Mono.Cecil.IMetadataTokenProvider, global::Mono.Cecil.IGenericContext
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00009978 File Offset: 0x00007B78
		public bool HasGenericArguments
		{
			get
			{
				return !this.arguments.IsNullOrEmpty<global::Mono.Cecil.TypeReference>();
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00009988 File Offset: 0x00007B88
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> GenericArguments
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> result;
				if ((result = this.arguments) == null)
				{
					result = (this.arguments = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>());
				}
				return result;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000387 RID: 903 RVA: 0x000099AD File Offset: 0x00007BAD
		public override bool IsGenericInstance
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000388 RID: 904 RVA: 0x000099B0 File Offset: 0x00007BB0
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Method
		{
			get
			{
				return base.ElementMethod;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000389 RID: 905 RVA: 0x000099B8 File Offset: 0x00007BB8
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Type
		{
			get
			{
				return base.ElementMethod.DeclaringType;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600038A RID: 906 RVA: 0x000099C5 File Offset: 0x00007BC5
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.ContainsGenericParameter() || base.ContainsGenericParameter;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600038B RID: 907 RVA: 0x000099D8 File Offset: 0x00007BD8
		public override string FullName
		{
			get
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				global::Mono.Cecil.MethodReference elementMethod = base.ElementMethod;
				stringBuilder.Append(elementMethod.ReturnType.FullName).Append(" ").Append(elementMethod.DeclaringType.FullName).Append("::").Append(elementMethod.Name);
				this.GenericInstanceFullName(stringBuilder);
				this.MethodSignatureFullName(stringBuilder);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00009A47 File Offset: 0x00007C47
		public GenericInstanceMethod(global::Mono.Cecil.MethodReference method) : base(method)
		{
		}

		// Token: 0x0400023F RID: 575
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> arguments;
	}
}
