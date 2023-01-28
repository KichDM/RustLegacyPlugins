using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x02000019 RID: 25
	public sealed class RequiredModifierType : global::Mono.Cecil.TypeSpecification, global::Mono.Cecil.IModifierType
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00004301 File Offset: 0x00002501
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00004309 File Offset: 0x00002509
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

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00004312 File Offset: 0x00002512
		public override string Name
		{
			get
			{
				return base.Name + this.Suffix;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00004325 File Offset: 0x00002525
		public override string FullName
		{
			get
			{
				return base.FullName + this.Suffix;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00004338 File Offset: 0x00002538
		private string Suffix
		{
			get
			{
				return " modreq(" + this.modifier_type + ")";
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600011D RID: 285 RVA: 0x0000434F File Offset: 0x0000254F
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00004352 File Offset: 0x00002552
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

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00004359 File Offset: 0x00002559
		public override bool IsRequiredModifier
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0000435C File Offset: 0x0000255C
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.modifier_type.ContainsGenericParameter || base.ContainsGenericParameter;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004373 File Offset: 0x00002573
		public RequiredModifierType(global::Mono.Cecil.TypeReference modifierType, global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckModifier(modifierType, type);
			this.modifier_type = modifierType;
			this.etype = global::Mono.Cecil.Metadata.ElementType.CModReqD;
		}

		// Token: 0x0400005B RID: 91
		private global::Mono.Cecil.TypeReference modifier_type;
	}
}
