using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200002B RID: 43
	public sealed class TypeDefinition : global::Mono.Cecil.TypeReference, global::Mono.Cecil.IMemberDefinition, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.ISecurityDeclarationProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x000067CC File Offset: 0x000049CC
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> FilterMethods(global::System.Func<global::Mono.Cecil.MethodDefinition, bool> filter)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>();
			foreach (global::Mono.Cecil.MethodDefinition methodDefinition in this.Methods)
			{
				if (filter(methodDefinition))
				{
					collection.Add(methodDefinition);
				}
			}
			return collection;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00006838 File Offset: 0x00004A38
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> Constructors
		{
			get
			{
				return this.FilterMethods((global::Mono.Cecil.MethodDefinition m) => m.IsConstructor);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00006868 File Offset: 0x00004A68
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> StrictMethods
		{
			get
			{
				return this.FilterMethods((global::Mono.Cecil.MethodDefinition m) => !m.IsConstructor);
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00006890 File Offset: 0x00004A90
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitTypeDefinition(this);
			visitor.VisitGenericParameterCollection(this.GenericParameters);
			visitor.VisitInterfaceCollection(this.Interfaces);
			visitor.VisitConstructorCollection(this.Constructors);
			visitor.VisitMethodDefinitionCollection(this.StrictMethods);
			visitor.VisitFieldDefinitionCollection(this.Fields);
			visitor.VisitPropertyDefinitionCollection(this.Properties);
			visitor.VisitEventDefinitionCollection(this.Events);
			visitor.VisitNestedTypeCollection(this.NestedTypes);
			visitor.VisitCustomAttributeCollection(this.CustomAttributes);
			visitor.VisitSecurityDeclarationCollection(this.SecurityDeclarations);
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000691C File Offset: 0x00004B1C
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00006924 File Offset: 0x00004B24
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

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000692D File Offset: 0x00004B2D
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00006935 File Offset: 0x00004B35
		public global::Mono.Cecil.TypeReference BaseType
		{
			get
			{
				return this.base_type;
			}
			set
			{
				this.base_type = value;
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00006948 File Offset: 0x00004B48
		private void ResolveLayout()
		{
			if (this.packing_size != -2 || this.class_size != -2)
			{
				return;
			}
			if (!this.HasImage)
			{
				this.packing_size = -1;
				this.class_size = -1;
				return;
			}
			global::Mono.Cecil.Metadata.Row<short, int> row = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.Metadata.Row<short, int>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadTypeLayout(type));
			this.packing_size = row.Col1;
			this.class_size = row.Col2;
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x000069C5 File Offset: 0x00004BC5
		public bool HasLayoutInfo
		{
			get
			{
				if (this.packing_size >= 0 || this.class_size >= 0)
				{
					return true;
				}
				this.ResolveLayout();
				return this.packing_size >= 0 || this.class_size >= 0;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x000069F8 File Offset: 0x00004BF8
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00006A21 File Offset: 0x00004C21
		public short PackingSize
		{
			get
			{
				if (this.packing_size >= 0)
				{
					return this.packing_size;
				}
				this.ResolveLayout();
				if (this.packing_size < 0)
				{
					return -1;
				}
				return this.packing_size;
			}
			set
			{
				this.packing_size = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00006A2A File Offset: 0x00004C2A
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00006A53 File Offset: 0x00004C53
		public int ClassSize
		{
			get
			{
				if (this.class_size >= 0)
				{
					return this.class_size;
				}
				this.ResolveLayout();
				if (this.class_size < 0)
				{
					return -1;
				}
				return this.class_size;
			}
			set
			{
				this.class_size = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00006A68 File Offset: 0x00004C68
		public bool HasInterfaces
		{
			get
			{
				if (this.interfaces != null)
				{
					return this.interfaces.Count > 0;
				}
				if (this.HasImage)
				{
					return this.Module.Read<global::Mono.Cecil.TypeDefinition, bool>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.HasInterfaces(type));
				}
				return false;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00006AC8 File Offset: 0x00004CC8
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> Interfaces
		{
			get
			{
				if (this.interfaces != null)
				{
					return this.interfaces;
				}
				if (this.HasImage)
				{
					return this.interfaces = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadInterfaces(type));
				}
				return this.interfaces = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>();
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00006B38 File Offset: 0x00004D38
		public bool HasNestedTypes
		{
			get
			{
				if (this.nested_types != null)
				{
					return this.nested_types.Count > 0;
				}
				if (this.HasImage)
				{
					return this.Module.Read<global::Mono.Cecil.TypeDefinition, bool>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.HasNestedTypes(type));
				}
				return false;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00006B98 File Offset: 0x00004D98
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> NestedTypes
		{
			get
			{
				if (this.nested_types != null)
				{
					return this.nested_types;
				}
				if (this.HasImage)
				{
					return this.nested_types = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadNestedTypes(type));
				}
				return this.nested_types = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.TypeDefinition>(this);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00006BFE File Offset: 0x00004DFE
		internal new bool HasImage
		{
			get
			{
				return this.Module != null && this.Module.HasImage;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00006C15 File Offset: 0x00004E15
		public bool HasMethods
		{
			get
			{
				if (this.methods != null)
				{
					return this.methods.Count > 0;
				}
				return this.HasImage && this.methods_range.Length > 0U;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00006C50 File Offset: 0x00004E50
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> Methods
		{
			get
			{
				if (this.methods != null)
				{
					return this.methods;
				}
				if (this.HasImage)
				{
					return this.methods = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadMethods(type));
				}
				return this.methods = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.MethodDefinition>(this);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00006CB6 File Offset: 0x00004EB6
		public bool HasFields
		{
			get
			{
				if (this.fields != null)
				{
					return this.fields.Count > 0;
				}
				return this.HasImage && this.fields_range.Length > 0U;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00006CF0 File Offset: 0x00004EF0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> Fields
		{
			get
			{
				if (this.fields != null)
				{
					return this.fields;
				}
				if (this.HasImage)
				{
					return this.fields = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadFields(type));
				}
				return this.fields = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.FieldDefinition>(this);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00006D60 File Offset: 0x00004F60
		public bool HasEvents
		{
			get
			{
				if (this.events != null)
				{
					return this.events.Count > 0;
				}
				if (this.HasImage)
				{
					return this.Module.Read<global::Mono.Cecil.TypeDefinition, bool>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.HasEvents(type));
				}
				return false;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00006DC0 File Offset: 0x00004FC0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> Events
		{
			get
			{
				if (this.events != null)
				{
					return this.events;
				}
				if (this.HasImage)
				{
					return this.events = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadEvents(type));
				}
				return this.events = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.EventDefinition>(this);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00006E30 File Offset: 0x00005030
		public bool HasProperties
		{
			get
			{
				if (this.properties != null)
				{
					return this.properties.Count > 0;
				}
				if (this.HasImage)
				{
					return this.Module.Read<global::Mono.Cecil.TypeDefinition, bool>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.HasProperties(type));
				}
				return false;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00006E90 File Offset: 0x00005090
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> Properties
		{
			get
			{
				if (this.properties != null)
				{
					return this.properties;
				}
				if (this.HasImage)
				{
					return this.properties = this.Module.Read<global::Mono.Cecil.TypeDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition>>(this, (global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader) => reader.ReadProperties(type));
				}
				return this.properties = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.PropertyDefinition>(this);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00006EF6 File Offset: 0x000050F6
		public bool HasSecurityDeclarations
		{
			get
			{
				if (this.security_declarations != null)
				{
					return this.security_declarations.Count > 0;
				}
				return this.GetHasSecurityDeclarations(this.Module);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00006F1C File Offset: 0x0000511C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> SecurityDeclarations
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> result;
				if ((result = this.security_declarations) == null)
				{
					result = (this.security_declarations = this.GetSecurityDeclarations(this.Module));
				}
				return result;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00006F48 File Offset: 0x00005148
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

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00006F70 File Offset: 0x00005170
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00006F9C File Offset: 0x0000519C
		public override bool HasGenericParameters
		{
			get
			{
				if (this.generic_parameters != null)
				{
					return this.generic_parameters.Count > 0;
				}
				return this.GetHasGenericParameters(this.Module);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00006FC4 File Offset: 0x000051C4
		public override global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> GenericParameters
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> result;
				if ((result = this.generic_parameters) == null)
				{
					result = (this.generic_parameters = this.GetGenericParameters(this.Module));
				}
				return result;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00006FF0 File Offset: 0x000051F0
		// (set) Token: 0x060001FB RID: 507 RVA: 0x00006FFF File Offset: 0x000051FF
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

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00007015 File Offset: 0x00005215
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00007024 File Offset: 0x00005224
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

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001FE RID: 510 RVA: 0x0000703A File Offset: 0x0000523A
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00007049 File Offset: 0x00005249
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

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000705F File Offset: 0x0000525F
		// (set) Token: 0x06000201 RID: 513 RVA: 0x0000706E File Offset: 0x0000526E
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

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00007084 File Offset: 0x00005284
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00007093 File Offset: 0x00005293
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

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000204 RID: 516 RVA: 0x000070A9 File Offset: 0x000052A9
		// (set) Token: 0x06000205 RID: 517 RVA: 0x000070B8 File Offset: 0x000052B8
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

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000206 RID: 518 RVA: 0x000070CE File Offset: 0x000052CE
		// (set) Token: 0x06000207 RID: 519 RVA: 0x000070DD File Offset: 0x000052DD
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000208 RID: 520 RVA: 0x000070F3 File Offset: 0x000052F3
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00007102 File Offset: 0x00005302
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

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00007118 File Offset: 0x00005318
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00007128 File Offset: 0x00005328
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

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0000713F File Offset: 0x0000533F
		// (set) Token: 0x0600020D RID: 525 RVA: 0x0000714F File Offset: 0x0000534F
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

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00007166 File Offset: 0x00005366
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00007177 File Offset: 0x00005377
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

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0000718F File Offset: 0x0000538F
		// (set) Token: 0x06000211 RID: 529 RVA: 0x0000719F File Offset: 0x0000539F
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

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000071B6 File Offset: 0x000053B6
		// (set) Token: 0x06000213 RID: 531 RVA: 0x000071C7 File Offset: 0x000053C7
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

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000214 RID: 532 RVA: 0x000071DF File Offset: 0x000053DF
		// (set) Token: 0x06000215 RID: 533 RVA: 0x000071F1 File Offset: 0x000053F1
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

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000216 RID: 534 RVA: 0x0000720A File Offset: 0x0000540A
		// (set) Token: 0x06000217 RID: 535 RVA: 0x0000721C File Offset: 0x0000541C
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00007235 File Offset: 0x00005435
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00007247 File Offset: 0x00005447
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

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00007260 File Offset: 0x00005460
		// (set) Token: 0x0600021B RID: 539 RVA: 0x00007272 File Offset: 0x00005472
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

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600021C RID: 540 RVA: 0x0000728B File Offset: 0x0000548B
		// (set) Token: 0x0600021D RID: 541 RVA: 0x0000729D File Offset: 0x0000549D
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

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600021E RID: 542 RVA: 0x000072B6 File Offset: 0x000054B6
		// (set) Token: 0x0600021F RID: 543 RVA: 0x000072C9 File Offset: 0x000054C9
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000220 RID: 544 RVA: 0x000072E3 File Offset: 0x000054E3
		// (set) Token: 0x06000221 RID: 545 RVA: 0x000072FA File Offset: 0x000054FA
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

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000222 RID: 546 RVA: 0x00007318 File Offset: 0x00005518
		// (set) Token: 0x06000223 RID: 547 RVA: 0x0000732F File Offset: 0x0000552F
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

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000224 RID: 548 RVA: 0x0000734D File Offset: 0x0000554D
		// (set) Token: 0x06000225 RID: 549 RVA: 0x0000735F File Offset: 0x0000555F
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

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00007378 File Offset: 0x00005578
		// (set) Token: 0x06000227 RID: 551 RVA: 0x0000738A File Offset: 0x0000558A
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

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000228 RID: 552 RVA: 0x000073A3 File Offset: 0x000055A3
		// (set) Token: 0x06000229 RID: 553 RVA: 0x000073B5 File Offset: 0x000055B5
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

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600022A RID: 554 RVA: 0x000073CE File Offset: 0x000055CE
		public bool IsEnum
		{
			get
			{
				return this.base_type != null && this.base_type.IsTypeOf("System", "Enum");
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600022B RID: 555 RVA: 0x000073F0 File Offset: 0x000055F0
		public override bool IsValueType
		{
			get
			{
				return this.base_type != null && (this.base_type.IsTypeOf("System", "Enum") || (this.base_type.IsTypeOf("System", "ValueType") && !this.IsTypeOf("System", "Enum")));
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000744C File Offset: 0x0000564C
		public override bool IsDefinition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600022D RID: 557 RVA: 0x0000744F File Offset: 0x0000564F
		// (set) Token: 0x0600022E RID: 558 RVA: 0x0000745C File Offset: 0x0000565C
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

		// Token: 0x0600022F RID: 559 RVA: 0x00007465 File Offset: 0x00005665
		public TypeDefinition(string @namespace, string name, global::Mono.Cecil.TypeAttributes attributes) : base(@namespace, name)
		{
			this.attributes = (uint)attributes;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeDef);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00007496 File Offset: 0x00005696
		public TypeDefinition(string @namespace, string name, global::Mono.Cecil.TypeAttributes attributes, global::Mono.Cecil.TypeReference baseType) : this(@namespace, name, attributes)
		{
			this.BaseType = baseType;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000074A9 File Offset: 0x000056A9
		public override global::Mono.Cecil.TypeDefinition Resolve()
		{
			return this;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00006830 File Offset: 0x00004A30
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_Constructors>b__0(global::Mono.Cecil.MethodDefinition m)
		{
			return m.IsConstructor;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000685D File Offset: 0x00004A5D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_StrictMethods>b__2(global::Mono.Cecil.MethodDefinition m)
		{
			return !m.IsConstructor;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000693E File Offset: 0x00004B3E
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.Metadata.Row<short, int> <ResolveLayout>b__4(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadTypeLayout(type);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00006A5C File Offset: 0x00004C5C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasInterfaces>b__6(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasInterfaces(type);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00006ABF File Offset: 0x00004CBF
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> <get_Interfaces>b__8(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadInterfaces(type);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00006B2D File Offset: 0x00004D2D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasNestedTypes>b__a(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasNestedTypes(type);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00006B8F File Offset: 0x00004D8F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> <get_NestedTypes>b__c(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadNestedTypes(type);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00006C46 File Offset: 0x00004E46
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> <get_Methods>b__e(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadMethods(type);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00006CE7 File Offset: 0x00004EE7
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> <get_Fields>b__10(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadFields(type);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006D56 File Offset: 0x00004F56
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasEvents>b__12(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasEvents(type);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00006DB7 File Offset: 0x00004FB7
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> <get_Events>b__14(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadEvents(type);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00006E26 File Offset: 0x00005026
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasProperties>b__16(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasProperties(type);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00006E87 File Offset: 0x00005087
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> <get_Properties>b__18(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadProperties(type);
		}

		// Token: 0x0400018B RID: 395
		private uint attributes;

		// Token: 0x0400018C RID: 396
		private global::Mono.Cecil.TypeReference base_type;

		// Token: 0x0400018D RID: 397
		internal global::Mono.Cecil.Range fields_range;

		// Token: 0x0400018E RID: 398
		internal global::Mono.Cecil.Range methods_range;

		// Token: 0x0400018F RID: 399
		private short packing_size = -2;

		// Token: 0x04000190 RID: 400
		private int class_size = -2;

		// Token: 0x04000191 RID: 401
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> interfaces;

		// Token: 0x04000192 RID: 402
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> nested_types;

		// Token: 0x04000193 RID: 403
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods;

		// Token: 0x04000194 RID: 404
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields;

		// Token: 0x04000195 RID: 405
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> events;

		// Token: 0x04000196 RID: 406
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> properties;

		// Token: 0x04000197 RID: 407
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x04000198 RID: 408
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> security_declarations;

		// Token: 0x04000199 RID: 409
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, bool> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x0400019A RID: 410
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, bool> CS$<>9__CachedAnonymousMethodDelegate3;

		// Token: 0x0400019B RID: 411
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.Metadata.Row<short, int>> CS$<>9__CachedAnonymousMethodDelegate5;

		// Token: 0x0400019C RID: 412
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate7;

		// Token: 0x0400019D RID: 413
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>> CS$<>9__CachedAnonymousMethodDelegate9;

		// Token: 0x0400019E RID: 414
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegateb;

		// Token: 0x0400019F RID: 415
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition>> CS$<>9__CachedAnonymousMethodDelegated;

		// Token: 0x040001A0 RID: 416
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>> CS$<>9__CachedAnonymousMethodDelegatef;

		// Token: 0x040001A1 RID: 417
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition>> CS$<>9__CachedAnonymousMethodDelegate11;

		// Token: 0x040001A2 RID: 418
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate13;

		// Token: 0x040001A3 RID: 419
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition>> CS$<>9__CachedAnonymousMethodDelegate15;

		// Token: 0x040001A4 RID: 420
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate17;

		// Token: 0x040001A5 RID: 421
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.TypeDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition>> CS$<>9__CachedAnonymousMethodDelegate19;
	}
}
