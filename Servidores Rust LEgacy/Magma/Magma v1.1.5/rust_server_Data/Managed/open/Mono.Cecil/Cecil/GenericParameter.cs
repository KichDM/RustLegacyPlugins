using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200000D RID: 13
	public sealed class GenericParameter : global::Mono.Cecil.TypeReference, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002669 File Offset: 0x00000869
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002671 File Offset: 0x00000871
		public global::Mono.Cecil.GenericParameterAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.GenericParameterAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000267A File Offset: 0x0000087A
		public int Position
		{
			get
			{
				if (this.owner == null)
				{
					return -1;
				}
				return this.owner.GenericParameters.IndexOf(this);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002697 File Offset: 0x00000897
		public global::Mono.Cecil.IGenericParameterProvider Owner
		{
			get
			{
				return this.owner;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600006C RID: 108 RVA: 0x000026A8 File Offset: 0x000008A8
		public bool HasConstraints
		{
			get
			{
				if (this.constraints != null)
				{
					return this.constraints.Count > 0;
				}
				if (base.HasImage)
				{
					return this.Module.Read<global::Mono.Cecil.GenericParameter, bool>(this, (global::Mono.Cecil.GenericParameter generic_parameter, global::Mono.Cecil.MetadataReader reader) => reader.HasGenericConstraints(generic_parameter));
				}
				return false;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002708 File Offset: 0x00000908
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> Constraints
		{
			get
			{
				if (this.constraints != null)
				{
					return this.constraints;
				}
				if (base.HasImage)
				{
					return this.constraints = this.Module.Read<global::Mono.Cecil.GenericParameter, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>>(this, (global::Mono.Cecil.GenericParameter generic_parameter, global::Mono.Cecil.MetadataReader reader) => reader.ReadGenericConstraints(generic_parameter));
				}
				return this.constraints = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>();
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000276D File Offset: 0x0000096D
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this.Module);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002794 File Offset: 0x00000994
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this.Module));
				}
				return result;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000027C0 File Offset: 0x000009C0
		public override global::Mono.Cecil.IMetadataScope Scope
		{
			get
			{
				if (this.owner.GenericParameterType == global::Mono.Cecil.GenericParameterType.Method)
				{
					return ((global::Mono.Cecil.MethodReference)this.owner).DeclaringType.Scope;
				}
				return ((global::Mono.Cecil.TypeReference)this.owner).Scope;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000027F6 File Offset: 0x000009F6
		public override global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				return ((global::Mono.Cecil.MemberReference)this.owner).Module;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002808 File Offset: 0x00000A08
		public override string Name
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Name))
				{
					return base.Name;
				}
				return base.Name = ((this.owner.GenericParameterType == global::Mono.Cecil.GenericParameterType.Type) ? "!" : "!!") + this.Position;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000073 RID: 115 RVA: 0x0000285B File Offset: 0x00000A5B
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002862 File Offset: 0x00000A62
		public override string Namespace
		{
			get
			{
				return string.Empty;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002869 File Offset: 0x00000A69
		public override string FullName
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00002871 File Offset: 0x00000A71
		public override bool IsGenericParameter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002874 File Offset: 0x00000A74
		internal override bool ContainsGenericParameter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002877 File Offset: 0x00000A77
		public override global::Mono.Cecil.MetadataType MetadataType
		{
			get
			{
				return (global::Mono.Cecil.MetadataType)this.etype;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000287F File Offset: 0x00000A7F
		// (set) Token: 0x0600007A RID: 122 RVA: 0x0000288E File Offset: 0x00000A8E
		public bool IsNonVariant
		{
			get
			{
				return this.attributes.GetMaskedAttributes(3, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(3, 0U, value);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000028A4 File Offset: 0x00000AA4
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000028B3 File Offset: 0x00000AB3
		public bool IsCovariant
		{
			get
			{
				return this.attributes.GetMaskedAttributes(3, 1U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(3, 1U, value);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000028C9 File Offset: 0x00000AC9
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000028D8 File Offset: 0x00000AD8
		public bool IsContravariant
		{
			get
			{
				return this.attributes.GetMaskedAttributes(3, 2U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(3, 2U, value);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000028EE File Offset: 0x00000AEE
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000028FC File Offset: 0x00000AFC
		public bool HasReferenceTypeConstraint
		{
			get
			{
				return this.attributes.GetAttributes(4);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(4, value);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002911 File Offset: 0x00000B11
		// (set) Token: 0x06000082 RID: 130 RVA: 0x0000291F File Offset: 0x00000B1F
		public bool HasNotNullableValueTypeConstraint
		{
			get
			{
				return this.attributes.GetAttributes(8);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(8, value);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002934 File Offset: 0x00000B34
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00002943 File Offset: 0x00000B43
		public bool HasDefaultConstructorConstraint
		{
			get
			{
				return this.attributes.GetAttributes(0x10);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x10, value);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002959 File Offset: 0x00000B59
		public GenericParameter(global::Mono.Cecil.IGenericParameterProvider owner) : this(string.Empty, owner)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002967 File Offset: 0x00000B67
		public GenericParameter(string name, global::Mono.Cecil.IGenericParameterProvider owner) : base(string.Empty, name)
		{
			if (owner == null)
			{
				throw new global::System.ArgumentNullException();
			}
			this.owner = owner;
			this.etype = ((owner.GenericParameterType == global::Mono.Cecil.GenericParameterType.Type) ? global::Mono.Cecil.Metadata.ElementType.Var : global::Mono.Cecil.Metadata.ElementType.MVar);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002999 File Offset: 0x00000B99
		public override global::Mono.Cecil.TypeDefinition Resolve()
		{
			return null;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000269F File Offset: 0x0000089F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasConstraints>b__0(global::Mono.Cecil.GenericParameter generic_parameter, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasGenericConstraints(generic_parameter);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000026FF File Offset: 0x000008FF
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> <get_Constraints>b__2(global::Mono.Cecil.GenericParameter generic_parameter, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadGenericConstraints(generic_parameter);
		}

		// Token: 0x04000012 RID: 18
		private readonly global::Mono.Cecil.IGenericParameterProvider owner;

		// Token: 0x04000013 RID: 19
		private ushort attributes;

		// Token: 0x04000014 RID: 20
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> constraints;

		// Token: 0x04000015 RID: 21
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x04000016 RID: 22
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.GenericParameter, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x04000017 RID: 23
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.GenericParameter, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>> CS$<>9__CachedAnonymousMethodDelegate3;
	}
}
