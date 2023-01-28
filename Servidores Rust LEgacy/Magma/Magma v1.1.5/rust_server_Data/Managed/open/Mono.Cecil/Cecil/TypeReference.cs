using System;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200000C RID: 12
	public class TypeReference : global::Mono.Cecil.MemberReference, global::Mono.Cecil.IGenericParameterProvider, global::Mono.Cecil.IMetadataTokenProvider, global::Mono.Cecil.IGenericContext
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000238A File Offset: 0x0000058A
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002392 File Offset: 0x00000592
		public override string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
				this.fullname = null;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000023A2 File Offset: 0x000005A2
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000023AA File Offset: 0x000005AA
		public virtual string Namespace
		{
			get
			{
				return this.@namespace;
			}
			set
			{
				this.@namespace = value;
				this.fullname = null;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000023BA File Offset: 0x000005BA
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000023C2 File Offset: 0x000005C2
		public virtual bool IsValueType
		{
			get
			{
				return this.value_type;
			}
			set
			{
				this.value_type = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000023CC File Offset: 0x000005CC
		public override global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				if (this.module != null)
				{
					return this.module;
				}
				global::Mono.Cecil.TypeReference declaringType = this.DeclaringType;
				if (declaringType != null)
				{
					return declaringType.Module;
				}
				return null;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000023FA File Offset: 0x000005FA
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Type
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000023FD File Offset: 0x000005FD
		global::Mono.Cecil.IGenericParameterProvider global::Mono.Cecil.IGenericContext.Method
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002400 File Offset: 0x00000600
		global::Mono.Cecil.GenericParameterType global::Mono.Cecil.IGenericParameterProvider.GenericParameterType
		{
			get
			{
				return global::Mono.Cecil.GenericParameterType.Type;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002403 File Offset: 0x00000603
		public virtual bool HasGenericParameters
		{
			get
			{
				return !this.generic_parameters.IsNullOrEmpty<global::Mono.Cecil.GenericParameter>();
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002414 File Offset: 0x00000614
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

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002440 File Offset: 0x00000640
		public virtual global::Mono.Cecil.IMetadataScope Scope
		{
			get
			{
				global::Mono.Cecil.TypeReference declaringType = this.DeclaringType;
				if (declaringType != null)
				{
					return declaringType.Scope;
				}
				return this.scope;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002464 File Offset: 0x00000664
		public bool IsNested
		{
			get
			{
				return this.DeclaringType != null;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002472 File Offset: 0x00000672
		// (set) Token: 0x06000054 RID: 84 RVA: 0x0000247A File Offset: 0x0000067A
		public override global::Mono.Cecil.TypeReference DeclaringType
		{
			get
			{
				return base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
				this.fullname = null;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000055 RID: 85 RVA: 0x0000248C File Offset: 0x0000068C
		public override string FullName
		{
			get
			{
				if (this.fullname != null)
				{
					return this.fullname;
				}
				if (this.IsNested)
				{
					return this.fullname = this.DeclaringType.FullName + "/" + this.Name;
				}
				if (string.IsNullOrEmpty(this.@namespace))
				{
					return this.fullname = this.Name;
				}
				return this.fullname = this.@namespace + "." + this.Name;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002511 File Offset: 0x00000711
		public virtual bool IsByReference
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002514 File Offset: 0x00000714
		public virtual bool IsPointer
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002517 File Offset: 0x00000717
		public virtual bool IsSentinel
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000251A File Offset: 0x0000071A
		public virtual bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000251D File Offset: 0x0000071D
		public virtual bool IsGenericParameter
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002520 File Offset: 0x00000720
		public virtual bool IsGenericInstance
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002523 File Offset: 0x00000723
		public virtual bool IsRequiredModifier
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002526 File Offset: 0x00000726
		public virtual bool IsOptionalModifier
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002529 File Offset: 0x00000729
		public virtual bool IsPinned
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000252C File Offset: 0x0000072C
		public virtual bool IsFunctionPointer
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002530 File Offset: 0x00000730
		public bool IsPrimitive
		{
			get
			{
				switch (this.etype)
				{
				case global::Mono.Cecil.Metadata.ElementType.Boolean:
				case global::Mono.Cecil.Metadata.ElementType.Char:
				case global::Mono.Cecil.Metadata.ElementType.I1:
				case global::Mono.Cecil.Metadata.ElementType.U1:
				case global::Mono.Cecil.Metadata.ElementType.I2:
				case global::Mono.Cecil.Metadata.ElementType.U2:
				case global::Mono.Cecil.Metadata.ElementType.I4:
				case global::Mono.Cecil.Metadata.ElementType.U4:
				case global::Mono.Cecil.Metadata.ElementType.I8:
				case global::Mono.Cecil.Metadata.ElementType.U8:
				case global::Mono.Cecil.Metadata.ElementType.R4:
				case global::Mono.Cecil.Metadata.ElementType.R8:
				case global::Mono.Cecil.Metadata.ElementType.I:
				case global::Mono.Cecil.Metadata.ElementType.U:
					return true;
				}
				return false;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000025B4 File Offset: 0x000007B4
		public virtual global::Mono.Cecil.MetadataType MetadataType
		{
			get
			{
				global::Mono.Cecil.Metadata.ElementType elementType = this.etype;
				if (elementType != global::Mono.Cecil.Metadata.ElementType.None)
				{
					return (global::Mono.Cecil.MetadataType)this.etype;
				}
				if (!this.IsValueType)
				{
					return global::Mono.Cecil.MetadataType.Class;
				}
				return global::Mono.Cecil.MetadataType.ValueType;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000025E0 File Offset: 0x000007E0
		protected TypeReference(string @namespace, string name) : base(name)
		{
			this.@namespace = (@namespace ?? string.Empty);
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeRef, 0);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000260A File Offset: 0x0000080A
		public TypeReference(string @namespace, string name, global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.IMetadataScope scope) : this(@namespace, name)
		{
			this.module = module;
			this.scope = scope;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002623 File Offset: 0x00000823
		public TypeReference(string @namespace, string name, global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.IMetadataScope scope, bool valueType) : this(@namespace, name, module, scope)
		{
			this.value_type = valueType;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002638 File Offset: 0x00000838
		public virtual global::Mono.Cecil.TypeReference GetElementType()
		{
			return this;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000263C File Offset: 0x0000083C
		public virtual global::Mono.Cecil.TypeDefinition Resolve()
		{
			global::Mono.Cecil.ModuleDefinition moduleDefinition = this.Module;
			if (moduleDefinition == null)
			{
				throw new global::System.NotSupportedException();
			}
			return moduleDefinition.Resolve(this);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002660 File Offset: 0x00000860
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitTypeReference(this);
		}

		// Token: 0x0400000B RID: 11
		private string @namespace;

		// Token: 0x0400000C RID: 12
		private bool value_type;

		// Token: 0x0400000D RID: 13
		internal global::Mono.Cecil.IMetadataScope scope;

		// Token: 0x0400000E RID: 14
		internal global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x0400000F RID: 15
		internal global::Mono.Cecil.Metadata.ElementType etype;

		// Token: 0x04000010 RID: 16
		private string fullname;

		// Token: 0x04000011 RID: 17
		protected global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> generic_parameters;
	}
}
