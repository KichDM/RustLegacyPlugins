using System;

namespace Mono.Cecil
{
	// Token: 0x02000023 RID: 35
	public class FieldReference : global::Mono.Cecil.MemberReference
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000549C File Offset: 0x0000369C
		// (set) Token: 0x060001AE RID: 430 RVA: 0x000054A4 File Offset: 0x000036A4
		public global::Mono.Cecil.TypeReference FieldType
		{
			get
			{
				return this.field_type;
			}
			set
			{
				this.field_type = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001AF RID: 431 RVA: 0x000054AD File Offset: 0x000036AD
		public override string FullName
		{
			get
			{
				return this.field_type.FullName + " " + base.MemberFullName();
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000054CA File Offset: 0x000036CA
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.field_type.ContainsGenericParameter || base.ContainsGenericParameter;
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000054E1 File Offset: 0x000036E1
		internal FieldReference()
		{
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MemberRef);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000054F9 File Offset: 0x000036F9
		public FieldReference(string name, global::Mono.Cecil.TypeReference fieldType) : base(name)
		{
			if (fieldType == null)
			{
				throw new global::System.ArgumentNullException("fieldType");
			}
			this.field_type = fieldType;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MemberRef);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00005527 File Offset: 0x00003727
		public FieldReference(string name, global::Mono.Cecil.TypeReference fieldType, global::Mono.Cecil.TypeReference declaringType) : this(name, fieldType)
		{
			if (declaringType == null)
			{
				throw new global::System.ArgumentNullException("declaringType");
			}
			this.DeclaringType = declaringType;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00005548 File Offset: 0x00003748
		public virtual global::Mono.Cecil.FieldDefinition Resolve()
		{
			global::Mono.Cecil.ModuleDefinition module = this.Module;
			if (module == null)
			{
				throw new global::System.NotSupportedException();
			}
			return module.Resolve(this);
		}

		// Token: 0x040000A0 RID: 160
		private global::Mono.Cecil.TypeReference field_type;
	}
}
