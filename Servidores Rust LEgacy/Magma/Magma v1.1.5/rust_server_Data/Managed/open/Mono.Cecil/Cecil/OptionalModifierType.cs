using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x02000018 RID: 24
	public sealed class OptionalModifierType : global::Mono.Cecil.TypeSpecification, global::Mono.Cecil.IModifierType
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00004270 File Offset: 0x00002470
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00004278 File Offset: 0x00002478
		public global::Mono.Cecil.TypeReference ModifierType
		{
			get
			{
				return this.modifier_type;
			}
			set
			{
				this.modifier_type = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00004281 File Offset: 0x00002481
		public override string Name
		{
			get
			{
				return base.Name + this.Suffix;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004294 File Offset: 0x00002494
		public override string FullName
		{
			get
			{
				return base.FullName + this.Suffix;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000042A7 File Offset: 0x000024A7
		private string Suffix
		{
			get
			{
				return " modopt(" + this.modifier_type + ")";
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000113 RID: 275 RVA: 0x000042BE File Offset: 0x000024BE
		// (set) Token: 0x06000114 RID: 276 RVA: 0x000042C1 File Offset: 0x000024C1
		public override bool IsValueType
		{
			get
			{
				return false;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000042C8 File Offset: 0x000024C8
		public override bool IsOptionalModifier
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000116 RID: 278 RVA: 0x000042CB File Offset: 0x000024CB
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.modifier_type.ContainsGenericParameter || base.ContainsGenericParameter;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000042E2 File Offset: 0x000024E2
		public OptionalModifierType(global::Mono.Cecil.TypeReference modifierType, global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckModifier(modifierType, type);
			this.modifier_type = modifierType;
			this.etype = global::Mono.Cecil.Metadata.ElementType.CModOpt;
		}

		// Token: 0x0400005A RID: 90
		private global::Mono.Cecil.TypeReference modifier_type;
	}
}
