using System;
using System.Text;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000051 RID: 81
	public sealed class GenericInstanceType : global::Mono.Cecil.TypeSpecification, global::Mono.Cecil.IGenericInstance, global::Mono.Cecil.IMetadataTokenProvider, global::Mono.Cecil.IGenericContext
	{
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00009C8B File Offset: 0x00007E8B
		public bool HasGenericArguments
		{
			get
			{
				return !this.arguments.IsNullOrEmpty<global::Mono.Cecil.TypeReference>();
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00009C9C File Offset: 0x00007E9C
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

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00009CC1 File Offset: 0x00007EC1
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00009CCE File Offset: 0x00007ECE
		public override global::Mono.Cecil.TypeReference DeclaringType
		{
			get
			{
				return base.ElementType.DeclaringType;
			}
			set
			{
				throw new global::System.NotSupportedException();
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00009CD8 File Offset: 0x00007ED8
		public override string FullName
		{
			get
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append(base.FullName);
				this.GenericInstanceFullName(stringBuilder);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00009D05 File Offset: 0x00007F05
		public override bool IsGenericInstance
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00009D08 File Offset: 0x00007F08
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.ContainsGenericParameter() || base.ContainsGenericParameter;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00009D1A File Offset: 0x00007F1A
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Type
		{
			get
			{
				return base.ElementType;
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00009D22 File Offset: 0x00007F22
		public GenericInstanceType(global::Mono.Cecil.TypeReference type) : base(type)
		{
			base.IsValueType = type.IsValueType;
			this.etype = global::Mono.Cecil.Metadata.ElementType.GenericInst;
		}

		// Token: 0x04000257 RID: 599
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> arguments;
	}
}
