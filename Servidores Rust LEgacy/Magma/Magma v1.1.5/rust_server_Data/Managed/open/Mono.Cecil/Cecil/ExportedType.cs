using System;

namespace Mono.Cecil
{
	// Token: 0x0200006B RID: 107
	public class ExportedType : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000AFB7 File Offset: 0x000091B7
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x0000AFBF File Offset: 0x000091BF
		public string Namespace
		{
			get
			{
				return this.@namespace;
			}
			set
			{
				this.@namespace = value;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000AFC8 File Offset: 0x000091C8
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x0000AFD0 File Offset: 0x000091D0
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000AFD9 File Offset: 0x000091D9
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x0000AFE1 File Offset: 0x000091E1
		public global::Mono.Cecil.TypeAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.TypeAttributes)this.attributes;
			}
			set
			{
				this.attributes = (uint)value;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000AFEA File Offset: 0x000091EA
		public global::Mono.Cecil.IMetadataScope Scope
		{
			get
			{
				if (this.declaring_type != null)
				{
					return this.declaring_type.Scope;
				}
				return this.scope;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0000B006 File Offset: 0x00009206
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x0000B00E File Offset: 0x0000920E
		public global::Mono.Cecil.ExportedType DeclaringType
		{
			get
			{
				return this.declaring_type;
			}
			set
			{
				this.declaring_type = value;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0000B017 File Offset: 0x00009217
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x0000B01F File Offset: 0x0000921F
		public global::Mono.Cecil.MetadataToken MetadataToken
		{
			get
			{
				return this.token;
			}
			set
			{
				this.token = value;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0000B028 File Offset: 0x00009228
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x0000B030 File Offset: 0x00009230
		public int Identifier
		{
			get
			{
				return this.identifier;
			}
			set
			{
				this.identifier = value;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x0000B039 File Offset: 0x00009239
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x0000B048 File Offset: 0x00009248
		public bool IsNotPublic
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 0U, value);
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x0000B05E File Offset: 0x0000925E
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x0000B06D File Offset: 0x0000926D
		public bool IsPublic
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 1U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 1U, value);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0000B083 File Offset: 0x00009283
		// (set) Token: 0x06000493 RID: 1171 RVA: 0x0000B092 File Offset: 0x00009292
		public bool IsNestedPublic
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 2U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 2U, value);
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0000B0A8 File Offset: 0x000092A8
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x0000B0B7 File Offset: 0x000092B7
		public bool IsNestedPrivate
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 3U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 3U, value);
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000B0CD File Offset: 0x000092CD
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x0000B0DC File Offset: 0x000092DC
		public bool IsNestedFamily
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 4U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 4U, value);
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000B0F2 File Offset: 0x000092F2
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x0000B101 File Offset: 0x00009301
		public bool IsNestedAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 5U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 5U, value);
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000B117 File Offset: 0x00009317
		// (set) Token: 0x0600049B RID: 1179 RVA: 0x0000B126 File Offset: 0x00009326
		public bool IsNestedFamilyAndAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 6U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 6U, value);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0000B13C File Offset: 0x0000933C
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x0000B14B File Offset: 0x0000934B
		public bool IsNestedFamilyOrAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7U, 7U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7U, 7U, value);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000B161 File Offset: 0x00009361
		// (set) Token: 0x0600049F RID: 1183 RVA: 0x0000B171 File Offset: 0x00009371
		public bool IsAutoLayout
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x18U, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x18U, 0U, value);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000B188 File Offset: 0x00009388
		// (set) Token: 0x060004A1 RID: 1185 RVA: 0x0000B198 File Offset: 0x00009398
		public bool IsSequentialLayout
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x18U, 8U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x18U, 8U, value);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000B1AF File Offset: 0x000093AF
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0000B1C0 File Offset: 0x000093C0
		public bool IsExplicitLayout
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x18U, 0x10U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x18U, 0x10U, value);
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000B1D8 File Offset: 0x000093D8
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000B1E8 File Offset: 0x000093E8
		public bool IsClass
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x20U, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x20U, 0U, value);
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000B1FF File Offset: 0x000093FF
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0000B210 File Offset: 0x00009410
		public bool IsInterface
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x20U, 0x20U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x20U, 0x20U, value);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000B228 File Offset: 0x00009428
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x0000B23A File Offset: 0x0000943A
		public bool IsAbstract
		{
			get
			{
				return this.attributes.GetAttributes(0x80U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x80U, value);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000B253 File Offset: 0x00009453
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x0000B265 File Offset: 0x00009465
		public bool IsSealed
		{
			get
			{
				return this.attributes.GetAttributes(0x100U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x100U, value);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000B27E File Offset: 0x0000947E
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x0000B290 File Offset: 0x00009490
		public bool IsSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x400U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x400U, value);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000B2A9 File Offset: 0x000094A9
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x0000B2BB File Offset: 0x000094BB
		public bool IsImport
		{
			get
			{
				return this.attributes.GetAttributes(0x1000U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x1000U, value);
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000B2D4 File Offset: 0x000094D4
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x0000B2E6 File Offset: 0x000094E6
		public bool IsSerializable
		{
			get
			{
				return this.attributes.GetAttributes(0x2000U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x2000U, value);
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0000B2FF File Offset: 0x000094FF
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x0000B312 File Offset: 0x00009512
		public bool IsAnsiClass
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x30000U, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x30000U, 0U, value);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x0000B32C File Offset: 0x0000952C
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x0000B343 File Offset: 0x00009543
		public bool IsUnicodeClass
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x30000U, 0x10000U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x30000U, 0x10000U, value);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000B361 File Offset: 0x00009561
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0000B378 File Offset: 0x00009578
		public bool IsAutoClass
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x30000U, 0x20000U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x30000U, 0x20000U, value);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000B396 File Offset: 0x00009596
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0000B3A8 File Offset: 0x000095A8
		public bool IsBeforeFieldInit
		{
			get
			{
				return this.attributes.GetAttributes(0x100000U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x100000U, value);
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x0000B3C1 File Offset: 0x000095C1
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x0000B3D3 File Offset: 0x000095D3
		public bool IsRuntimeSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x800U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x800U, value);
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000B3EC File Offset: 0x000095EC
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x0000B3FE File Offset: 0x000095FE
		public bool HasSecurity
		{
			get
			{
				return this.attributes.GetAttributes(0x40000U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x40000U, value);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000B417 File Offset: 0x00009617
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x0000B429 File Offset: 0x00009629
		public bool IsForwarder
		{
			get
			{
				return this.attributes.GetAttributes(0x200000U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x200000U, value);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000B444 File Offset: 0x00009644
		public string FullName
		{
			get
			{
				if (this.declaring_type != null)
				{
					return this.declaring_type.FullName + "/" + this.name;
				}
				if (string.IsNullOrEmpty(this.@namespace))
				{
					return this.name;
				}
				return this.@namespace + "." + this.name;
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000B49F File Offset: 0x0000969F
		public ExportedType(string @namespace, string name, global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.IMetadataScope scope)
		{
			this.@namespace = @namespace;
			this.name = name;
			this.scope = scope;
			this.module = module;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000B4C4 File Offset: 0x000096C4
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000B4CC File Offset: 0x000096CC
		public global::Mono.Cecil.TypeDefinition Resolve()
		{
			return this.module.Resolve(this.CreateReference());
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000B4E0 File Offset: 0x000096E0
		internal global::Mono.Cecil.TypeReference CreateReference()
		{
			return new global::Mono.Cecil.TypeReference(this.@namespace, this.name, this.module, this.scope)
			{
				DeclaringType = ((this.declaring_type != null) ? this.declaring_type.CreateReference() : null)
			};
		}

		// Token: 0x040002D5 RID: 725
		private string @namespace;

		// Token: 0x040002D6 RID: 726
		private string name;

		// Token: 0x040002D7 RID: 727
		private uint attributes;

		// Token: 0x040002D8 RID: 728
		private global::Mono.Cecil.IMetadataScope scope;

		// Token: 0x040002D9 RID: 729
		private global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x040002DA RID: 730
		private int identifier;

		// Token: 0x040002DB RID: 731
		private global::Mono.Cecil.ExportedType declaring_type;

		// Token: 0x040002DC RID: 732
		internal global::Mono.Cecil.MetadataToken token;
	}
}
