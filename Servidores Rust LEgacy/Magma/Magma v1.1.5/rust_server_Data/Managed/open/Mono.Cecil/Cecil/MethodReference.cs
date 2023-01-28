using System;
using System.Text;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200001B RID: 27
	public class MethodReference : global::Mono.Cecil.MemberReference, global::Mono.Cecil.IMethodSignature, global::Mono.Cecil.IGenericParameterProvider, global::Mono.Cecil.IMetadataTokenProvider, global::Mono.Cecil.IGenericContext
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00004392 File Offset: 0x00002592
		// (set) Token: 0x0600012E RID: 302 RVA: 0x0000439A File Offset: 0x0000259A
		public virtual bool HasThis
		{
			get
			{
				return this.has_this;
			}
			set
			{
				this.has_this = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600012F RID: 303 RVA: 0x000043A3 File Offset: 0x000025A3
		// (set) Token: 0x06000130 RID: 304 RVA: 0x000043AB File Offset: 0x000025AB
		public virtual bool ExplicitThis
		{
			get
			{
				return this.explicit_this;
			}
			set
			{
				this.explicit_this = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000131 RID: 305 RVA: 0x000043B4 File Offset: 0x000025B4
		// (set) Token: 0x06000132 RID: 306 RVA: 0x000043BC File Offset: 0x000025BC
		public virtual global::Mono.Cecil.MethodCallingConvention CallingConvention
		{
			get
			{
				return this.calling_convention;
			}
			set
			{
				this.calling_convention = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000133 RID: 307 RVA: 0x000043C5 File Offset: 0x000025C5
		public virtual bool HasParameters
		{
			get
			{
				return !this.parameters.IsNullOrEmpty<global::Mono.Cecil.ParameterDefinition>();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000134 RID: 308 RVA: 0x000043D5 File Offset: 0x000025D5
		public virtual global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters
		{
			get
			{
				if (this.parameters == null)
				{
					this.parameters = new global::Mono.Cecil.ParameterDefinitionCollection(this);
				}
				return this.parameters;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000043F4 File Offset: 0x000025F4
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Type
		{
			get
			{
				global::Mono.Cecil.TypeReference declaringType = this.DeclaringType;
				global::Mono.Cecil.GenericInstanceType genericInstanceType = declaringType as global::Mono.Cecil.GenericInstanceType;
				if (genericInstanceType != null)
				{
					return genericInstanceType.ElementType;
				}
				return declaringType;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000136 RID: 310 RVA: 0x0000441A File Offset: 0x0000261A
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Method
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000137 RID: 311 RVA: 0x0000441D File Offset: 0x0000261D
		global::Mono.Cecil.GenericParameterType global::Mono.Cecil.IGenericParameterProvider.GenericParameterType
		{
			get
			{
				return global::Mono.Cecil.GenericParameterType.Method;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00004420 File Offset: 0x00002620
		public virtual bool HasGenericParameters
		{
			get
			{
				return !this.generic_parameters.IsNullOrEmpty<global::Mono.Cecil.GenericParameter>();
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004430 File Offset: 0x00002630
		public virtual global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> GenericParameters
		{
			get
			{
				if (this.generic_parameters != null)
				{
					return this.generic_parameters;
				}
				return this.generic_parameters = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>();
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600013A RID: 314 RVA: 0x0000445C File Offset: 0x0000265C
		// (set) Token: 0x0600013B RID: 315 RVA: 0x0000447C File Offset: 0x0000267C
		public global::Mono.Cecil.TypeReference ReturnType
		{
			get
			{
				global::Mono.Cecil.MethodReturnType methodReturnType = this.MethodReturnType;
				if (methodReturnType == null)
				{
					return null;
				}
				return methodReturnType.ReturnType;
			}
			set
			{
				global::Mono.Cecil.MethodReturnType methodReturnType = this.MethodReturnType;
				if (methodReturnType != null)
				{
					methodReturnType.ReturnType = value;
				}
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600013C RID: 316 RVA: 0x0000449A File Offset: 0x0000269A
		// (set) Token: 0x0600013D RID: 317 RVA: 0x000044A2 File Offset: 0x000026A2
		public virtual global::Mono.Cecil.MethodReturnType MethodReturnType
		{
			get
			{
				return this.return_type;
			}
			set
			{
				this.return_type = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600013E RID: 318 RVA: 0x000044AC File Offset: 0x000026AC
		public override string FullName
		{
			get
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append(this.ReturnType.FullName).Append(" ").Append(base.MemberFullName());
				this.MethodSignatureFullName(stringBuilder);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600013F RID: 319 RVA: 0x000044F3 File Offset: 0x000026F3
		public virtual bool IsGenericInstance
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000140 RID: 320 RVA: 0x000044F8 File Offset: 0x000026F8
		internal override bool ContainsGenericParameter
		{
			get
			{
				if (this.ReturnType.ContainsGenericParameter || base.ContainsGenericParameter)
				{
					return true;
				}
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> collection = this.Parameters;
				for (int i = 0; i < collection.Count; i++)
				{
					if (collection[i].ParameterType.ContainsGenericParameter)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000454A File Offset: 0x0000274A
		internal MethodReference()
		{
			this.return_type = new global::Mono.Cecil.MethodReturnType(this);
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MemberRef);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000456E File Offset: 0x0000276E
		public MethodReference(string name, global::Mono.Cecil.TypeReference returnType) : base(name)
		{
			if (returnType == null)
			{
				throw new global::System.ArgumentNullException("returnType");
			}
			this.return_type = new global::Mono.Cecil.MethodReturnType(this);
			this.return_type.ReturnType = returnType;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MemberRef);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000045AD File Offset: 0x000027AD
		public MethodReference(string name, global::Mono.Cecil.TypeReference returnType, global::Mono.Cecil.TypeReference declaringType) : this(name, returnType)
		{
			if (declaringType == null)
			{
				throw new global::System.ArgumentNullException("declaringType");
			}
			this.DeclaringType = declaringType;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000045CC File Offset: 0x000027CC
		public virtual global::Mono.Cecil.MethodReference GetElementMethod()
		{
			return this;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000045D0 File Offset: 0x000027D0
		public virtual global::Mono.Cecil.MethodDefinition Resolve()
		{
			global::Mono.Cecil.ModuleDefinition module = this.Module;
			if (module == null)
			{
				throw new global::System.NotSupportedException();
			}
			return module.Resolve(this);
		}

		// Token: 0x0400005C RID: 92
		internal global::Mono.Cecil.ParameterDefinitionCollection parameters;

		// Token: 0x0400005D RID: 93
		private global::Mono.Cecil.MethodReturnType return_type;

		// Token: 0x0400005E RID: 94
		private bool has_this;

		// Token: 0x0400005F RID: 95
		private bool explicit_this;

		// Token: 0x04000060 RID: 96
		private global::Mono.Cecil.MethodCallingConvention calling_convention;

		// Token: 0x04000061 RID: 97
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> generic_parameters;
	}
}
