using System;

namespace Mono.Cecil
{
	// Token: 0x02000010 RID: 16
	public abstract class TypeSpecification : global::Mono.Cecil.TypeReference
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002A92 File Offset: 0x00000C92
		public global::Mono.Cecil.TypeReference ElementType
		{
			get
			{
				return this.element_type;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002A9A File Offset: 0x00000C9A
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00002AA7 File Offset: 0x00000CA7
		public override string Name
		{
			get
			{
				return this.element_type.Name;
			}
			set
			{
				throw new global::System.NotSupportedException();
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002AAE File Offset: 0x00000CAE
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00002ABB File Offset: 0x00000CBB
		public override string Namespace
		{
			get
			{
				return this.element_type.Namespace;
			}
			set
			{
				throw new global::System.NotSupportedException();
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002AC2 File Offset: 0x00000CC2
		public override global::Mono.Cecil.IMetadataScope Scope
		{
			get
			{
				return this.element_type.Scope;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00002ACF File Offset: 0x00000CCF
		public override global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				return this.element_type.Module;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002ADC File Offset: 0x00000CDC
		public override string FullName
		{
			get
			{
				return this.element_type.FullName;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00002AE9 File Offset: 0x00000CE9
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.element_type.ContainsGenericParameter;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00002AF6 File Offset: 0x00000CF6
		public override global::Mono.Cecil.MetadataType MetadataType
		{
			get
			{
				return (global::Mono.Cecil.MetadataType)this.etype;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002AFE File Offset: 0x00000CFE
		internal TypeSpecification(global::Mono.Cecil.TypeReference type) : base(null, null)
		{
			this.element_type = type;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeSpec);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002B1F File Offset: 0x00000D1F
		public override global::Mono.Cecil.TypeReference GetElementType()
		{
			return this.element_type.GetElementType();
		}

		// Token: 0x0400001E RID: 30
		private readonly global::Mono.Cecil.TypeReference element_type;
	}
}
