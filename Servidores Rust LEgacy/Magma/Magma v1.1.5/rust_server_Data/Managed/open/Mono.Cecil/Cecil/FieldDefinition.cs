using System;
using System.Runtime.CompilerServices;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200006A RID: 106
	public sealed class FieldDefinition : global::Mono.Cecil.FieldReference, global::Mono.Cecil.IMemberDefinition, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IConstantProvider, global::Mono.Cecil.IMarshalInfoProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x06000447 RID: 1095 RVA: 0x0000AA80 File Offset: 0x00008C80
		private void ResolveLayout()
		{
			if (this.offset != -2)
			{
				return;
			}
			if (!base.HasImage)
			{
				this.offset = -1;
				return;
			}
			this.offset = this.Module.Read<global::Mono.Cecil.FieldDefinition, int>(this, (global::Mono.Cecil.FieldDefinition field, global::Mono.Cecil.MetadataReader reader) => reader.ReadFieldLayout(field));
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000AAD7 File Offset: 0x00008CD7
		public bool HasLayoutInfo
		{
			get
			{
				if (this.offset >= 0)
				{
					return true;
				}
				this.ResolveLayout();
				return this.offset >= 0;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000AAF6 File Offset: 0x00008CF6
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x0000AB1F File Offset: 0x00008D1F
		public int Offset
		{
			get
			{
				if (this.offset >= 0)
				{
					return this.offset;
				}
				this.ResolveLayout();
				if (this.offset < 0)
				{
					return -1;
				}
				return this.offset;
			}
			set
			{
				this.offset = value;
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000AB34 File Offset: 0x00008D34
		private void ResolveRVA()
		{
			if (this.rva != -2)
			{
				return;
			}
			if (!base.HasImage)
			{
				return;
			}
			this.rva = this.Module.Read<global::Mono.Cecil.FieldDefinition, int>(this, (global::Mono.Cecil.FieldDefinition field, global::Mono.Cecil.MetadataReader reader) => reader.ReadFieldRVA(field));
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x0000AB84 File Offset: 0x00008D84
		public int RVA
		{
			get
			{
				if (this.rva > 0)
				{
					return this.rva;
				}
				this.ResolveRVA();
				if (this.rva <= 0)
				{
					return 0;
				}
				return this.rva;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000ABAD File Offset: 0x00008DAD
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000ABDD File Offset: 0x00008DDD
		public byte[] InitialValue
		{
			get
			{
				if (this.initial_value != null)
				{
					return this.initial_value;
				}
				this.ResolveRVA();
				if (this.initial_value == null)
				{
					this.initial_value = global::Mono.Empty<byte>.Array;
				}
				return this.initial_value;
			}
			set
			{
				this.initial_value = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000ABE6 File Offset: 0x00008DE6
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000ABEE File Offset: 0x00008DEE
		public global::Mono.Cecil.FieldAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.FieldAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000ABF7 File Offset: 0x00008DF7
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000AC0F File Offset: 0x00008E0F
		public bool HasConstant
		{
			get
			{
				this.ResolveConstant();
				return this.constant != global::Mono.Cecil.Mixin.NoValue;
			}
			set
			{
				if (!value)
				{
					this.constant = global::Mono.Cecil.Mixin.NoValue;
				}
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000AC1F File Offset: 0x00008E1F
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0000AC31 File Offset: 0x00008E31
		public object Constant
		{
			get
			{
				if (!this.HasConstant)
				{
					return null;
				}
				return this.constant;
			}
			set
			{
				this.constant = value;
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000AC3A File Offset: 0x00008E3A
		private void ResolveConstant()
		{
			if (this.constant != global::Mono.Cecil.Mixin.NotResolved)
			{
				return;
			}
			this.ResolveConstant(ref this.constant, this.Module);
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x0000AC5C File Offset: 0x00008E5C
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

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0000AC84 File Offset: 0x00008E84
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

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		public bool HasMarshalInfo
		{
			get
			{
				return this.marshal_info != null || this.GetHasMarshalInfo(this.Module);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000ACC8 File Offset: 0x00008EC8
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000ACF4 File Offset: 0x00008EF4
		public global::Mono.Cecil.MarshalInfo MarshalInfo
		{
			get
			{
				global::Mono.Cecil.MarshalInfo result;
				if ((result = this.marshal_info) == null)
				{
					result = (this.marshal_info = this.GetMarshalInfo(this.Module));
				}
				return result;
			}
			set
			{
				this.marshal_info = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000ACFD File Offset: 0x00008EFD
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x0000AD0C File Offset: 0x00008F0C
		public bool IsCompilerControlled
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 0U, value);
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000AD22 File Offset: 0x00008F22
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x0000AD31 File Offset: 0x00008F31
		public bool IsPrivate
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 1U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 1U, value);
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000AD47 File Offset: 0x00008F47
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x0000AD56 File Offset: 0x00008F56
		public bool IsFamilyAndAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 2U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 2U, value);
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000AD6C File Offset: 0x00008F6C
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x0000AD7B File Offset: 0x00008F7B
		public bool IsAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 3U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 3U, value);
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x0000AD91 File Offset: 0x00008F91
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x0000ADA0 File Offset: 0x00008FA0
		public bool IsFamily
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 4U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 4U, value);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0000ADB6 File Offset: 0x00008FB6
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0000ADC5 File Offset: 0x00008FC5
		public bool IsFamilyOrAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 5U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 5U, value);
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x0000ADDB File Offset: 0x00008FDB
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x0000ADEA File Offset: 0x00008FEA
		public bool IsPublic
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 6U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 6U, value);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0000AE00 File Offset: 0x00009000
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x0000AE0F File Offset: 0x0000900F
		public bool IsStatic
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

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000AE25 File Offset: 0x00009025
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x0000AE34 File Offset: 0x00009034
		public bool IsInitOnly
		{
			get
			{
				return this.attributes.GetAttributes(0x20);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x20, value);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x0000AE4A File Offset: 0x0000904A
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x0000AE59 File Offset: 0x00009059
		public bool IsLiteral
		{
			get
			{
				return this.attributes.GetAttributes(0x40);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x40, value);
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x0000AE6F File Offset: 0x0000906F
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x0000AE81 File Offset: 0x00009081
		public bool IsNotSerialized
		{
			get
			{
				return this.attributes.GetAttributes(0x80);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x80, value);
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x0000AE9A File Offset: 0x0000909A
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x0000AEAC File Offset: 0x000090AC
		public bool IsSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x200);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x200, value);
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x0000AEC5 File Offset: 0x000090C5
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x0000AED7 File Offset: 0x000090D7
		public bool IsPInvokeImpl
		{
			get
			{
				return this.attributes.GetAttributes(0x2000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x2000, value);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0000AEF0 File Offset: 0x000090F0
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x0000AF02 File Offset: 0x00009102
		public bool IsRuntimeSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x400);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x400, value);
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x0000AF1B File Offset: 0x0000911B
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x0000AF2D File Offset: 0x0000912D
		public bool HasDefault
		{
			get
			{
				return this.attributes.GetAttributes(0x8000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x8000, value);
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x0000AF46 File Offset: 0x00009146
		public override bool IsDefinition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000AF49 File Offset: 0x00009149
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x0000AF56 File Offset: 0x00009156
		public new global::Mono.Cecil.TypeDefinition DeclaringType
		{
			get
			{
				return (global::Mono.Cecil.TypeDefinition)base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000AF5F File Offset: 0x0000915F
		public FieldDefinition(string name, global::Mono.Cecil.FieldAttributes attributes, global::Mono.Cecil.TypeReference fieldType) : base(name, fieldType)
		{
			this.attributes = (ushort)attributes;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000AF8B File Offset: 0x0000918B
		public override global::Mono.Cecil.FieldDefinition Resolve()
		{
			return this;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000AF8E File Offset: 0x0000918E
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitFieldDefinition(this);
			if (this.MarshalInfo != null)
			{
				this.MarshalInfo.Accept(visitor);
			}
			visitor.VisitCustomAttributeCollection(this.CustomAttributes);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000AA77 File Offset: 0x00008C77
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static int <ResolveLayout>b__0(global::Mono.Cecil.FieldDefinition field, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadFieldLayout(field);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000AB28 File Offset: 0x00008D28
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static int <ResolveRVA>b__2(global::Mono.Cecil.FieldDefinition field, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadFieldRVA(field);
		}

		// Token: 0x040002CC RID: 716
		private ushort attributes;

		// Token: 0x040002CD RID: 717
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x040002CE RID: 718
		private int offset = -2;

		// Token: 0x040002CF RID: 719
		internal int rva = -2;

		// Token: 0x040002D0 RID: 720
		private byte[] initial_value;

		// Token: 0x040002D1 RID: 721
		private object constant = global::Mono.Cecil.Mixin.NotResolved;

		// Token: 0x040002D2 RID: 722
		private global::Mono.Cecil.MarshalInfo marshal_info;

		// Token: 0x040002D3 RID: 723
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.FieldDefinition, global::Mono.Cecil.MetadataReader, int> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x040002D4 RID: 724
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.FieldDefinition, global::Mono.Cecil.MetadataReader, int> CS$<>9__CachedAnonymousMethodDelegate3;
	}
}
