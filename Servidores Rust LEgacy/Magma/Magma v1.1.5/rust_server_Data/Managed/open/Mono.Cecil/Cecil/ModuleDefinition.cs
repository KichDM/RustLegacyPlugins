using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200002E RID: 46
	public sealed class ModuleDefinition : global::Mono.Cecil.ModuleReference, global::Mono.Cecil.IReflectionVisitable, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x0600024A RID: 586 RVA: 0x00007500 File Offset: 0x00005700
		public void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitModuleDefinition(this);
			visitor.VisitTypeDefinitionCollection(this.Types);
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00007515 File Offset: 0x00005715
		public bool IsMain
		{
			get
			{
				return this.kind != global::Mono.Cecil.ModuleKind.NetModule;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00007523 File Offset: 0x00005723
		// (set) Token: 0x0600024D RID: 589 RVA: 0x0000752B File Offset: 0x0000572B
		public global::Mono.Cecil.ModuleKind Kind
		{
			get
			{
				return this.kind;
			}
			set
			{
				this.kind = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600024E RID: 590 RVA: 0x00007534 File Offset: 0x00005734
		// (set) Token: 0x0600024F RID: 591 RVA: 0x0000753C File Offset: 0x0000573C
		public global::Mono.Cecil.TargetRuntime Runtime
		{
			get
			{
				return this.runtime;
			}
			set
			{
				this.runtime = value;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00007545 File Offset: 0x00005745
		// (set) Token: 0x06000251 RID: 593 RVA: 0x0000754D File Offset: 0x0000574D
		public global::Mono.Cecil.TargetArchitecture Architecture
		{
			get
			{
				return this.architecture;
			}
			set
			{
				this.architecture = value;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00007556 File Offset: 0x00005756
		// (set) Token: 0x06000253 RID: 595 RVA: 0x0000755E File Offset: 0x0000575E
		public global::Mono.Cecil.ModuleAttributes Attributes
		{
			get
			{
				return this.attributes;
			}
			set
			{
				this.attributes = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00007567 File Offset: 0x00005767
		public string FullyQualifiedName
		{
			get
			{
				return this.fq_name;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0000756F File Offset: 0x0000576F
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00007577 File Offset: 0x00005777
		public global::System.Guid Mvid
		{
			get
			{
				return this.mvid;
			}
			set
			{
				this.mvid = value;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00007580 File Offset: 0x00005780
		internal bool HasImage
		{
			get
			{
				return this.Image != null;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0000758E File Offset: 0x0000578E
		public bool HasSymbols
		{
			get
			{
				return this.SymbolReader != null;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000759C File Offset: 0x0000579C
		public override global::Mono.Cecil.MetadataScopeType MetadataScopeType
		{
			get
			{
				return global::Mono.Cecil.MetadataScopeType.ModuleDefinition;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000759F File Offset: 0x0000579F
		public global::Mono.Cecil.AssemblyDefinition Assembly
		{
			get
			{
				return this.assembly;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600025B RID: 603 RVA: 0x000075A8 File Offset: 0x000057A8
		internal global::Mono.Cecil.MetadataImporter MetadataImporter
		{
			get
			{
				global::Mono.Cecil.MetadataImporter result;
				if ((result = this.importer) == null)
				{
					result = (this.importer = new global::Mono.Cecil.MetadataImporter(this));
				}
				return result;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000075CE File Offset: 0x000057CE
		public global::Mono.Cecil.IAssemblyResolver AssemblyResolver
		{
			get
			{
				return this.assembly_resolver;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600025D RID: 605 RVA: 0x000075D8 File Offset: 0x000057D8
		public global::Mono.Cecil.TypeSystem TypeSystem
		{
			get
			{
				global::Mono.Cecil.TypeSystem result;
				if ((result = this.type_system) == null)
				{
					result = (this.type_system = global::Mono.Cecil.TypeSystem.CreateTypeSystem(this));
				}
				return result;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600025E RID: 606 RVA: 0x000075FE File Offset: 0x000057FE
		public bool HasAssemblyReferences
		{
			get
			{
				if (this.references != null)
				{
					return this.references.Count > 0;
				}
				return this.HasImage && this.Image.HasTable(global::Mono.Cecil.Metadata.Table.AssemblyRef);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00007638 File Offset: 0x00005838
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> AssemblyReferences
		{
			get
			{
				if (this.references != null)
				{
					return this.references;
				}
				if (this.HasImage)
				{
					return this.references = this.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference>>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadAssemblyReferences());
				}
				return this.references = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference>();
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000260 RID: 608 RVA: 0x00007698 File Offset: 0x00005898
		public bool HasModuleReferences
		{
			get
			{
				if (this.modules != null)
				{
					return this.modules.Count > 0;
				}
				return this.HasImage && this.Image.HasTable(global::Mono.Cecil.Metadata.Table.ModuleRef);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000261 RID: 609 RVA: 0x000076D0 File Offset: 0x000058D0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference> ModuleReferences
		{
			get
			{
				if (this.modules != null)
				{
					return this.modules;
				}
				if (this.HasImage)
				{
					return this.modules = this.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference>>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadModuleReferences());
				}
				return this.modules = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference>();
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00007738 File Offset: 0x00005938
		public bool HasResources
		{
			get
			{
				if (this.resources != null)
				{
					return this.resources.Count > 0;
				}
				if (!this.HasImage)
				{
					return false;
				}
				if (!this.Image.HasTable(global::Mono.Cecil.Metadata.Table.ManifestResource))
				{
					return this.Read<global::Mono.Cecil.ModuleDefinition, bool>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.HasFileResource());
				}
				return true;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000263 RID: 611 RVA: 0x000077A4 File Offset: 0x000059A4
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource> Resources
		{
			get
			{
				if (this.resources != null)
				{
					return this.resources;
				}
				if (this.HasImage)
				{
					return this.resources = this.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource>>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadResources());
				}
				return this.resources = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource>();
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00007804 File Offset: 0x00005A04
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00007824 File Offset: 0x00005A24
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this));
				}
				return result;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000784B File Offset: 0x00005A4B
		public bool HasTypes
		{
			get
			{
				if (this.types != null)
				{
					return this.types.Count > 0;
				}
				return this.HasImage && this.Image.HasTable(global::Mono.Cecil.Metadata.Table.TypeDef);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00007884 File Offset: 0x00005A84
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> Types
		{
			get
			{
				if (this.types != null)
				{
					return this.types;
				}
				if (this.HasImage)
				{
					return this.types = this.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.TypeDefinitionCollection>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadTypes());
				}
				return this.types = new global::Mono.Cecil.TypeDefinitionCollection(this);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000268 RID: 616 RVA: 0x000078E5 File Offset: 0x00005AE5
		public bool HasExportedTypes
		{
			get
			{
				if (this.exported_types != null)
				{
					return this.exported_types.Count > 0;
				}
				return this.HasImage && this.Image.HasTable(global::Mono.Cecil.Metadata.Table.ExportedType);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00007920 File Offset: 0x00005B20
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> ExportedTypes
		{
			get
			{
				if (this.exported_types != null)
				{
					return this.exported_types;
				}
				if (this.HasImage)
				{
					return this.exported_types = this.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType>>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadExportedTypes());
				}
				return this.exported_types = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType>();
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00007988 File Offset: 0x00005B88
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000079E4 File Offset: 0x00005BE4
		public global::Mono.Cecil.MethodDefinition EntryPoint
		{
			get
			{
				if (this.entry_point != null)
				{
					return this.entry_point;
				}
				if (this.HasImage)
				{
					return this.entry_point = this.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MethodDefinition>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadEntryPoint());
				}
				return this.entry_point = null;
			}
			set
			{
				this.entry_point = value;
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000079ED File Offset: 0x00005BED
		internal ModuleDefinition()
		{
			this.MetadataSystem = new global::Mono.Cecil.MetadataSystem();
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Module, 1);
			this.assembly_resolver = global::Mono.Cecil.GlobalAssemblyResolver.Instance;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00007A18 File Offset: 0x00005C18
		internal ModuleDefinition(global::Mono.Cecil.PE.Image image) : this()
		{
			this.Image = image;
			this.kind = image.Kind;
			this.runtime = image.Runtime;
			this.architecture = image.Architecture;
			this.attributes = image.Attributes;
			this.fq_name = image.FileName;
			this.reader = new global::Mono.Cecil.MetadataReader(this);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00007A7A File Offset: 0x00005C7A
		public bool HasTypeReference(string fullName)
		{
			return this.HasTypeReference(string.Empty, fullName);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00007A88 File Offset: 0x00005C88
		public bool HasTypeReference(string scope, string fullName)
		{
			global::Mono.Cecil.ModuleDefinition.CheckFullName(fullName);
			return this.HasImage && this.GetTypeReference(scope, fullName) != null;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007AA8 File Offset: 0x00005CA8
		public bool TryGetTypeReference(string fullName, out global::Mono.Cecil.TypeReference type)
		{
			return this.TryGetTypeReference(string.Empty, fullName, out type);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00007AB8 File Offset: 0x00005CB8
		public bool TryGetTypeReference(string scope, string fullName, out global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.ModuleDefinition.CheckFullName(fullName);
			if (!this.HasImage)
			{
				type = null;
				return false;
			}
			global::Mono.Cecil.TypeReference typeReference;
			type = (typeReference = this.GetTypeReference(scope, fullName));
			return typeReference != null;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00007B01 File Offset: 0x00005D01
		private global::Mono.Cecil.TypeReference GetTypeReference(string scope, string fullname)
		{
			return this.Read<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.TypeReference>(new global::Mono.Cecil.Metadata.Row<string, string>(scope, fullname), (global::Mono.Cecil.Metadata.Row<string, string> row, global::Mono.Cecil.MetadataReader reader) => reader.GetTypeReference(row.Col1, row.Col2));
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00007B35 File Offset: 0x00005D35
		public global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeReference> GetTypeReferences()
		{
			if (!this.HasImage)
			{
				return global::Mono.Empty<global::Mono.Cecil.TypeReference>.Array;
			}
			return this.Read<global::Mono.Cecil.ModuleDefinition, global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeReference>>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.GetTypeReferences());
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00007B71 File Offset: 0x00005D71
		public global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.MemberReference> GetMemberReferences()
		{
			if (!this.HasImage)
			{
				return global::Mono.Empty<global::Mono.Cecil.MemberReference>.Array;
			}
			return this.Read<global::Mono.Cecil.ModuleDefinition, global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.MemberReference>>(this, (global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.GetMemberReferences());
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00007BA8 File Offset: 0x00005DA8
		public global::Mono.Cecil.TypeDefinition GetType(string fullName)
		{
			global::Mono.Cecil.ModuleDefinition.CheckFullName(fullName);
			int num = fullName.IndexOf('/');
			if (num > 0)
			{
				return this.GetNestedType(fullName);
			}
			return ((global::Mono.Cecil.TypeDefinitionCollection)this.Types).GetType(fullName);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00007BE1 File Offset: 0x00005DE1
		public global::Mono.Cecil.TypeDefinition GetType(string @namespace, string name)
		{
			global::Mono.Cecil.Mixin.CheckName(name);
			return ((global::Mono.Cecil.TypeDefinitionCollection)this.Types).GetType(@namespace ?? string.Empty, name);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00007C04 File Offset: 0x00005E04
		public global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeDefinition> GetTypes()
		{
			return global::Mono.Cecil.ModuleDefinition.GetTypes(this.Types);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00007E34 File Offset: 0x00006034
		private static global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeDefinition> GetTypes(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> types)
		{
			for (int i = 0; i < types.Count; i++)
			{
				global::Mono.Cecil.TypeDefinition type = types[i];
				yield return type;
				if (type.HasNestedTypes)
				{
					foreach (global::Mono.Cecil.TypeDefinition nested in global::Mono.Cecil.ModuleDefinition.GetTypes(type.NestedTypes))
					{
						yield return nested;
					}
				}
			}
			yield break;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00007E51 File Offset: 0x00006051
		private static void CheckFullName(string fullName)
		{
			if (fullName == null)
			{
				throw new global::System.ArgumentNullException("fullName");
			}
			if (fullName.Length == 0)
			{
				throw new global::System.ArgumentException();
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00007E70 File Offset: 0x00006070
		private global::Mono.Cecil.TypeDefinition GetNestedType(string fullname)
		{
			string[] array = fullname.Split(new char[]
			{
				'/'
			});
			global::Mono.Cecil.TypeDefinition typeDefinition = this.GetType(array[0]);
			if (typeDefinition == null)
			{
				return null;
			}
			for (int i = 1; i < array.Length; i++)
			{
				global::Mono.Cecil.TypeDefinition nestedType = typeDefinition.GetNestedType(array[i]);
				if (nestedType == null)
				{
					return null;
				}
				typeDefinition = nestedType;
			}
			return typeDefinition;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00007EC3 File Offset: 0x000060C3
		internal global::Mono.Cecil.FieldDefinition Resolve(global::Mono.Cecil.FieldReference field)
		{
			return global::Mono.Cecil.MetadataResolver.Resolve(this.AssemblyResolver, field);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00007ED1 File Offset: 0x000060D1
		internal global::Mono.Cecil.MethodDefinition Resolve(global::Mono.Cecil.MethodReference method)
		{
			return global::Mono.Cecil.MetadataResolver.Resolve(this.AssemblyResolver, method);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00007EDF File Offset: 0x000060DF
		internal global::Mono.Cecil.TypeDefinition Resolve(global::Mono.Cecil.TypeReference type)
		{
			return global::Mono.Cecil.MetadataResolver.Resolve(this.AssemblyResolver, type);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00007EED File Offset: 0x000060ED
		private static void CheckType(object type)
		{
			if (type == null)
			{
				throw new global::System.ArgumentNullException("type");
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00007EFD File Offset: 0x000060FD
		private static void CheckField(object field)
		{
			if (field == null)
			{
				throw new global::System.ArgumentNullException("field");
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00007F0D File Offset: 0x0000610D
		private static void CheckMethod(object method)
		{
			if (method == null)
			{
				throw new global::System.ArgumentNullException("method");
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00007F1D File Offset: 0x0000611D
		private static void CheckContext(global::Mono.Cecil.IGenericParameterProvider context, global::Mono.Cecil.ModuleDefinition module)
		{
			if (context == null)
			{
				return;
			}
			if (context.Module != module)
			{
				throw new global::System.ArgumentException();
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00007F32 File Offset: 0x00006132
		public global::Mono.Cecil.TypeReference Import(global::System.Type type)
		{
			global::Mono.Cecil.ModuleDefinition.CheckType(type);
			return this.MetadataImporter.ImportType(type, null, global::Mono.Cecil.ImportGenericKind.Definition);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00007F48 File Offset: 0x00006148
		public global::Mono.Cecil.TypeReference Import(global::System.Type type, global::Mono.Cecil.TypeReference context)
		{
			return this.Import(type, context);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00007F52 File Offset: 0x00006152
		public global::Mono.Cecil.TypeReference Import(global::System.Type type, global::Mono.Cecil.MethodReference context)
		{
			return this.Import(type, context);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00007F5C File Offset: 0x0000615C
		private global::Mono.Cecil.TypeReference Import(global::System.Type type, global::Mono.Cecil.IGenericParameterProvider context)
		{
			global::Mono.Cecil.ModuleDefinition.CheckType(type);
			global::Mono.Cecil.ModuleDefinition.CheckContext(context, this);
			return this.MetadataImporter.ImportType(type, (global::Mono.Cecil.IGenericContext)context, (context != null) ? global::Mono.Cecil.ImportGenericKind.Open : global::Mono.Cecil.ImportGenericKind.Definition);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00007F84 File Offset: 0x00006184
		public global::Mono.Cecil.FieldReference Import(global::System.Reflection.FieldInfo field)
		{
			global::Mono.Cecil.ModuleDefinition.CheckField(field);
			return this.MetadataImporter.ImportField(field, null);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00007F99 File Offset: 0x00006199
		public global::Mono.Cecil.FieldReference Import(global::System.Reflection.FieldInfo field, global::Mono.Cecil.TypeReference context)
		{
			return this.Import(field, context);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00007FA3 File Offset: 0x000061A3
		public global::Mono.Cecil.FieldReference Import(global::System.Reflection.FieldInfo field, global::Mono.Cecil.MethodReference context)
		{
			return this.Import(field, context);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007FAD File Offset: 0x000061AD
		private global::Mono.Cecil.FieldReference Import(global::System.Reflection.FieldInfo field, global::Mono.Cecil.IGenericParameterProvider context)
		{
			global::Mono.Cecil.ModuleDefinition.CheckField(field);
			global::Mono.Cecil.ModuleDefinition.CheckContext(context, this);
			return this.MetadataImporter.ImportField(field, (global::Mono.Cecil.IGenericContext)context);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00007FCE File Offset: 0x000061CE
		public global::Mono.Cecil.MethodReference Import(global::System.Reflection.MethodBase method)
		{
			global::Mono.Cecil.ModuleDefinition.CheckMethod(method);
			return this.MetadataImporter.ImportMethod(method, null, global::Mono.Cecil.ImportGenericKind.Definition);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007FE4 File Offset: 0x000061E4
		public global::Mono.Cecil.MethodReference Import(global::System.Reflection.MethodBase method, global::Mono.Cecil.TypeReference context)
		{
			return this.Import(method, context);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00007FEE File Offset: 0x000061EE
		public global::Mono.Cecil.MethodReference Import(global::System.Reflection.MethodBase method, global::Mono.Cecil.MethodReference context)
		{
			return this.Import(method, context);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00007FF8 File Offset: 0x000061F8
		private global::Mono.Cecil.MethodReference Import(global::System.Reflection.MethodBase method, global::Mono.Cecil.IGenericParameterProvider context)
		{
			global::Mono.Cecil.ModuleDefinition.CheckMethod(method);
			global::Mono.Cecil.ModuleDefinition.CheckContext(context, this);
			return this.MetadataImporter.ImportMethod(method, (global::Mono.Cecil.IGenericContext)context, (context != null) ? global::Mono.Cecil.ImportGenericKind.Open : global::Mono.Cecil.ImportGenericKind.Definition);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00008020 File Offset: 0x00006220
		public global::Mono.Cecil.TypeReference Import(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.ModuleDefinition.CheckType(type);
			if (type.Module == this)
			{
				return type;
			}
			return this.MetadataImporter.ImportType(type, null);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00008040 File Offset: 0x00006240
		public global::Mono.Cecil.TypeReference Import(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.TypeReference context)
		{
			return this.Import(type, context);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000804A File Offset: 0x0000624A
		public global::Mono.Cecil.TypeReference Import(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.MethodReference context)
		{
			return this.Import(type, context);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00008054 File Offset: 0x00006254
		private global::Mono.Cecil.TypeReference Import(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.IGenericParameterProvider context)
		{
			global::Mono.Cecil.ModuleDefinition.CheckType(type);
			if (type.Module == this)
			{
				return type;
			}
			global::Mono.Cecil.ModuleDefinition.CheckContext(context, this);
			return this.MetadataImporter.ImportType(type, (global::Mono.Cecil.IGenericContext)context);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00008080 File Offset: 0x00006280
		public global::Mono.Cecil.FieldReference Import(global::Mono.Cecil.FieldReference field)
		{
			global::Mono.Cecil.ModuleDefinition.CheckField(field);
			if (field.Module == this)
			{
				return field;
			}
			return this.MetadataImporter.ImportField(field, null);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000080A0 File Offset: 0x000062A0
		public global::Mono.Cecil.FieldReference Import(global::Mono.Cecil.FieldReference field, global::Mono.Cecil.TypeReference context)
		{
			return this.Import(field, context);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x000080AA File Offset: 0x000062AA
		public global::Mono.Cecil.FieldReference Import(global::Mono.Cecil.FieldReference field, global::Mono.Cecil.MethodReference context)
		{
			return this.Import(field, context);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000080B4 File Offset: 0x000062B4
		private global::Mono.Cecil.FieldReference Import(global::Mono.Cecil.FieldReference field, global::Mono.Cecil.IGenericParameterProvider context)
		{
			global::Mono.Cecil.ModuleDefinition.CheckField(field);
			if (field.Module == this)
			{
				return field;
			}
			global::Mono.Cecil.ModuleDefinition.CheckContext(context, this);
			return this.MetadataImporter.ImportField(field, (global::Mono.Cecil.IGenericContext)context);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000080E0 File Offset: 0x000062E0
		public global::Mono.Cecil.MethodReference Import(global::Mono.Cecil.MethodReference method)
		{
			global::Mono.Cecil.ModuleDefinition.CheckMethod(method);
			if (method.Module == this)
			{
				return method;
			}
			return this.MetadataImporter.ImportMethod(method, null);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00008100 File Offset: 0x00006300
		public global::Mono.Cecil.MethodReference Import(global::Mono.Cecil.MethodReference method, global::Mono.Cecil.TypeReference context)
		{
			return this.Import(method, context);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000810A File Offset: 0x0000630A
		public global::Mono.Cecil.MethodReference Import(global::Mono.Cecil.MethodReference method, global::Mono.Cecil.MethodReference context)
		{
			return this.Import(method, context);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00008114 File Offset: 0x00006314
		private global::Mono.Cecil.MethodReference Import(global::Mono.Cecil.MethodReference method, global::Mono.Cecil.IGenericParameterProvider context)
		{
			global::Mono.Cecil.ModuleDefinition.CheckMethod(method);
			if (method.Module == this)
			{
				return method;
			}
			global::Mono.Cecil.ModuleDefinition.CheckContext(context, this);
			return this.MetadataImporter.ImportMethod(method, (global::Mono.Cecil.IGenericContext)context);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00008140 File Offset: 0x00006340
		public global::Mono.Cecil.IMetadataTokenProvider LookupToken(int token)
		{
			return this.LookupToken(new global::Mono.Cecil.MetadataToken((uint)token));
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00008157 File Offset: 0x00006357
		public global::Mono.Cecil.IMetadataTokenProvider LookupToken(global::Mono.Cecil.MetadataToken token)
		{
			return this.Read<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.IMetadataTokenProvider>(token, (global::Mono.Cecil.MetadataToken t, global::Mono.Cecil.MetadataReader reader) => reader.LookupToken(t));
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00008180 File Offset: 0x00006380
		internal TRet Read<TItem, TRet>(TItem item, global::System.Func<TItem, global::Mono.Cecil.MetadataReader, TRet> read)
		{
			int position = this.reader.position;
			global::Mono.Cecil.IGenericContext context = this.reader.context;
			TRet result = read(item, this.reader);
			this.reader.position = position;
			this.reader.context = context;
			return result;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000081CC File Offset: 0x000063CC
		private void ProcessDebugHeader()
		{
			if (this.Image == null || this.Image.Debug.IsZero)
			{
				return;
			}
			byte[] header;
			global::Mono.Cecil.Cil.ImageDebugDirectory debugHeader = this.Image.GetDebugHeader(out header);
			if (!this.SymbolReader.ProcessDebugHeader(debugHeader, header))
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00008218 File Offset: 0x00006418
		public static global::Mono.Cecil.ModuleDefinition CreateModule(string name, global::Mono.Cecil.ModuleKind kind)
		{
			return global::Mono.Cecil.ModuleDefinition.CreateModule(name, new global::Mono.Cecil.ModuleParameters
			{
				Kind = kind
			});
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000823C File Offset: 0x0000643C
		public static global::Mono.Cecil.ModuleDefinition CreateModule(string name, global::Mono.Cecil.ModuleParameters parameters)
		{
			global::Mono.Cecil.Mixin.CheckName(name);
			global::Mono.Cecil.Mixin.CheckParameters(parameters);
			global::Mono.Cecil.ModuleDefinition moduleDefinition = new global::Mono.Cecil.ModuleDefinition
			{
				Name = name,
				kind = parameters.Kind,
				runtime = parameters.Runtime,
				architecture = parameters.Architecture,
				mvid = global::System.Guid.NewGuid(),
				Attributes = global::Mono.Cecil.ModuleAttributes.ILOnly
			};
			if (parameters.AssemblyResolver != null)
			{
				moduleDefinition.assembly_resolver = parameters.AssemblyResolver;
			}
			if (parameters.Kind != global::Mono.Cecil.ModuleKind.NetModule)
			{
				global::Mono.Cecil.AssemblyDefinition assemblyDefinition = new global::Mono.Cecil.AssemblyDefinition();
				moduleDefinition.assembly = assemblyDefinition;
				moduleDefinition.assembly.Name = new global::Mono.Cecil.AssemblyNameDefinition(name, new global::System.Version(0, 0));
				assemblyDefinition.main_module = moduleDefinition;
			}
			moduleDefinition.Types.Add(new global::Mono.Cecil.TypeDefinition(string.Empty, "<Module>", global::Mono.Cecil.TypeAttributes.NotPublic));
			return moduleDefinition;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00008300 File Offset: 0x00006500
		public void ReadSymbols()
		{
			if (string.IsNullOrEmpty(this.fq_name))
			{
				throw new global::System.InvalidOperationException();
			}
			global::Mono.Cecil.Cil.ISymbolReaderProvider platformReaderProvider = global::Mono.Cecil.Cil.SymbolProvider.GetPlatformReaderProvider();
			this.SymbolReader = platformReaderProvider.GetSymbolReader(this, this.fq_name);
			this.ProcessDebugHeader();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000833F File Offset: 0x0000653F
		public void ReadSymbols(global::Mono.Cecil.Cil.ISymbolReader reader)
		{
			if (reader == null)
			{
				throw new global::System.ArgumentNullException("reader");
			}
			this.SymbolReader = reader;
			this.ProcessDebugHeader();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000835C File Offset: 0x0000655C
		public static global::Mono.Cecil.ModuleDefinition ReadModule(string fileName)
		{
			return global::Mono.Cecil.ModuleDefinition.ReadModule(fileName, new global::Mono.Cecil.ReaderParameters(global::Mono.Cecil.ReadingMode.Deferred));
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000836A File Offset: 0x0000656A
		public static global::Mono.Cecil.ModuleDefinition ReadModule(global::System.IO.Stream stream)
		{
			return global::Mono.Cecil.ModuleDefinition.ReadModule(stream, new global::Mono.Cecil.ReaderParameters(global::Mono.Cecil.ReadingMode.Deferred));
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00008378 File Offset: 0x00006578
		public static global::Mono.Cecil.ModuleDefinition ReadModule(string fileName, global::Mono.Cecil.ReaderParameters parameters)
		{
			global::Mono.Cecil.ModuleDefinition result;
			using (global::System.IO.Stream fileStream = global::Mono.Cecil.ModuleDefinition.GetFileStream(fileName, global::System.IO.FileMode.Open, global::System.IO.FileAccess.Read, global::System.IO.FileShare.Read))
			{
				result = global::Mono.Cecil.ModuleDefinition.ReadModule(fileStream, parameters);
			}
			return result;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x000083B4 File Offset: 0x000065B4
		private static void CheckStream(object stream)
		{
			if (stream == null)
			{
				throw new global::System.ArgumentNullException("stream");
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000083C4 File Offset: 0x000065C4
		public static global::Mono.Cecil.ModuleDefinition ReadModule(global::System.IO.Stream stream, global::Mono.Cecil.ReaderParameters parameters)
		{
			global::Mono.Cecil.ModuleDefinition.CheckStream(stream);
			if (!stream.CanRead || !stream.CanSeek)
			{
				throw new global::System.ArgumentException();
			}
			global::Mono.Cecil.Mixin.CheckParameters(parameters);
			return global::Mono.Cecil.ModuleReader.CreateModuleFrom(global::Mono.Cecil.PE.ImageReader.ReadImageFrom(stream), parameters);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000083F4 File Offset: 0x000065F4
		private static global::System.IO.Stream GetFileStream(string fileName, global::System.IO.FileMode mode, global::System.IO.FileAccess access, global::System.IO.FileShare share)
		{
			if (fileName == null)
			{
				throw new global::System.ArgumentNullException("fileName");
			}
			if (fileName.Length == 0)
			{
				throw new global::System.ArgumentException();
			}
			return new global::System.IO.FileStream(fileName, mode, access, share);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000841B File Offset: 0x0000661B
		public void Write(string fileName)
		{
			this.Write(fileName, new global::Mono.Cecil.WriterParameters());
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00008429 File Offset: 0x00006629
		public void Write(global::System.IO.Stream stream)
		{
			this.Write(stream, new global::Mono.Cecil.WriterParameters());
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00008438 File Offset: 0x00006638
		public void Write(string fileName, global::Mono.Cecil.WriterParameters parameters)
		{
			using (global::System.IO.Stream fileStream = global::Mono.Cecil.ModuleDefinition.GetFileStream(fileName, global::System.IO.FileMode.Create, global::System.IO.FileAccess.ReadWrite, global::System.IO.FileShare.None))
			{
				this.Write(fileStream, parameters);
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00008474 File Offset: 0x00006674
		public void Write(global::System.IO.Stream stream, global::Mono.Cecil.WriterParameters parameters)
		{
			global::Mono.Cecil.ModuleDefinition.CheckStream(stream);
			if (!stream.CanWrite || !stream.CanSeek)
			{
				throw new global::System.ArgumentException();
			}
			global::Mono.Cecil.Mixin.CheckParameters(parameters);
			global::Mono.Cecil.ModuleWriter.WriteModuleTo(this, stream, parameters);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000762E File Offset: 0x0000582E
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> <get_AssemblyReferences>b__0(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadAssemblyReferences();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000076C8 File Offset: 0x000058C8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference> <get_ModuleReferences>b__2(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadModuleReferences();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00007730 File Offset: 0x00005930
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasResources>b__4(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasFileResource();
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000779B File Offset: 0x0000599B
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource> <get_Resources>b__6(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadResources();
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000787A File Offset: 0x00005A7A
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.TypeDefinitionCollection <get_Types>b__8(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadTypes();
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00007915 File Offset: 0x00005B15
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> <get_ExportedTypes>b__a(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadExportedTypes();
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00007980 File Offset: 0x00005B80
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.MethodDefinition <get_EntryPoint>b__c(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadEntryPoint();
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00007AEB File Offset: 0x00005CEB
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.TypeReference <GetTypeReference>b__e(global::Mono.Cecil.Metadata.Row<string, string> row, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.GetTypeReference(row.Col1, row.Col2);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00007B2D File Offset: 0x00005D2D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeReference> <GetTypeReferences>b__10(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.GetTypeReferences();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00007B69 File Offset: 0x00005D69
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.MemberReference> <GetMemberReferences>b__12(global::Mono.Cecil.ModuleDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.GetMemberReferences();
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000814E File Offset: 0x0000634E
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.IMetadataTokenProvider <LookupToken>b__1c(global::Mono.Cecil.MetadataToken t, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.LookupToken(t);
		}

		// Token: 0x040001A8 RID: 424
		internal global::Mono.Cecil.PE.Image Image;

		// Token: 0x040001A9 RID: 425
		internal global::Mono.Cecil.MetadataSystem MetadataSystem;

		// Token: 0x040001AA RID: 426
		internal global::Mono.Cecil.ReadingMode ReadingMode;

		// Token: 0x040001AB RID: 427
		internal global::Mono.Cecil.Cil.ISymbolReaderProvider SymbolReaderProvider;

		// Token: 0x040001AC RID: 428
		internal global::Mono.Cecil.Cil.ISymbolReader SymbolReader;

		// Token: 0x040001AD RID: 429
		internal global::Mono.Cecil.IAssemblyResolver assembly_resolver;

		// Token: 0x040001AE RID: 430
		internal global::Mono.Cecil.TypeSystem type_system;

		// Token: 0x040001AF RID: 431
		private readonly global::Mono.Cecil.MetadataReader reader;

		// Token: 0x040001B0 RID: 432
		private readonly string fq_name;

		// Token: 0x040001B1 RID: 433
		internal global::Mono.Cecil.ModuleKind kind;

		// Token: 0x040001B2 RID: 434
		private global::Mono.Cecil.TargetRuntime runtime;

		// Token: 0x040001B3 RID: 435
		private global::Mono.Cecil.TargetArchitecture architecture;

		// Token: 0x040001B4 RID: 436
		private global::Mono.Cecil.ModuleAttributes attributes;

		// Token: 0x040001B5 RID: 437
		private global::System.Guid mvid;

		// Token: 0x040001B6 RID: 438
		internal global::Mono.Cecil.AssemblyDefinition assembly;

		// Token: 0x040001B7 RID: 439
		private global::Mono.Cecil.MethodDefinition entry_point;

		// Token: 0x040001B8 RID: 440
		private global::Mono.Cecil.MetadataImporter importer;

		// Token: 0x040001B9 RID: 441
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x040001BA RID: 442
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> references;

		// Token: 0x040001BB RID: 443
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference> modules;

		// Token: 0x040001BC RID: 444
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource> resources;

		// Token: 0x040001BD RID: 445
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> exported_types;

		// Token: 0x040001BE RID: 446
		private global::Mono.Cecil.TypeDefinitionCollection types;

		// Token: 0x040001BF RID: 447
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference>> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x040001C0 RID: 448
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference>> CS$<>9__CachedAnonymousMethodDelegate3;

		// Token: 0x040001C1 RID: 449
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate5;

		// Token: 0x040001C2 RID: 450
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource>> CS$<>9__CachedAnonymousMethodDelegate7;

		// Token: 0x040001C3 RID: 451
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.TypeDefinitionCollection> CS$<>9__CachedAnonymousMethodDelegate9;

		// Token: 0x040001C4 RID: 452
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType>> CS$<>9__CachedAnonymousMethodDelegateb;

		// Token: 0x040001C5 RID: 453
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.MethodDefinition> CS$<>9__CachedAnonymousMethodDelegated;

		// Token: 0x040001C6 RID: 454
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.TypeReference> CS$<>9__CachedAnonymousMethodDelegatef;

		// Token: 0x040001C7 RID: 455
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeReference>> CS$<>9__CachedAnonymousMethodDelegate11;

		// Token: 0x040001C8 RID: 456
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.MetadataReader, global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.MemberReference>> CS$<>9__CachedAnonymousMethodDelegate13;

		// Token: 0x040001C9 RID: 457
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.IMetadataTokenProvider> CS$<>9__CachedAnonymousMethodDelegate1d;

		// Token: 0x020000F9 RID: 249
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetTypes>d__14 : global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeDefinition>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<global::Mono.Cecil.TypeDefinition>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x060009C6 RID: 2502 RVA: 0x00007C14 File Offset: 0x00005E14
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::Mono.Cecil.TypeDefinition> global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeDefinition>.GetEnumerator()
			{
				global::Mono.Cecil.ModuleDefinition.<GetTypes>d__14 <GetTypes>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetTypes>d__ = this;
				}
				else
				{
					<GetTypes>d__ = new global::Mono.Cecil.ModuleDefinition.<GetTypes>d__14(0);
				}
				<GetTypes>d__.types = types;
				return <GetTypes>d__;
			}

			// Token: 0x060009C7 RID: 2503 RVA: 0x00007C5C File Offset: 0x00005E5C
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<Mono.Cecil.TypeDefinition>.GetEnumerator();
			}

			// Token: 0x060009C8 RID: 2504 RVA: 0x00007C64 File Offset: 0x00005E64
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						i = 0;
						goto IL_EE;
					case 1:
						this.<>1__state = -1;
						if (!type.HasNestedTypes)
						{
							goto IL_E0;
						}
						enumerator = global::Mono.Cecil.ModuleDefinition.GetTypes(type.NestedTypes).GetEnumerator();
						this.<>1__state = 2;
						break;
					case 2:
						goto IL_104;
					case 3:
						this.<>1__state = 2;
						break;
					default:
						goto IL_104;
					}
					if (enumerator.MoveNext())
					{
						nested = enumerator.Current;
						this.<>2__current = nested;
						this.<>1__state = 3;
						return true;
					}
					this.<>m__Finally19();
					IL_E0:
					i++;
					IL_EE:
					if (i < types.Count)
					{
						type = types[i];
						this.<>2__current = type;
						this.<>1__state = 1;
						return true;
					}
					IL_104:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002BE RID: 702
			// (get) Token: 0x060009C9 RID: 2505 RVA: 0x00007DA0 File Offset: 0x00005FA0
			global::Mono.Cecil.TypeDefinition global::System.Collections.Generic.IEnumerator<global::Mono.Cecil.TypeDefinition>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x060009CA RID: 2506 RVA: 0x00007DA8 File Offset: 0x00005FA8
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x060009CB RID: 2507 RVA: 0x00007DB0 File Offset: 0x00005FB0
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 2:
				case 3:
					try
					{
					}
					finally
					{
						this.<>m__Finally19();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002BF RID: 703
			// (get) Token: 0x060009CC RID: 2508 RVA: 0x00007DF0 File Offset: 0x00005FF0
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x060009CD RID: 2509 RVA: 0x00007DF8 File Offset: 0x00005FF8
			[global::System.Diagnostics.DebuggerHidden]
			public <GetTypes>d__14(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x060009CE RID: 2510 RVA: 0x00007E17 File Offset: 0x00006017
			private void <>m__Finally19()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x0400061C RID: 1564
			private global::Mono.Cecil.TypeDefinition <>2__current;

			// Token: 0x0400061D RID: 1565
			private int <>1__state;

			// Token: 0x0400061E RID: 1566
			private int <>l__initialThreadId;

			// Token: 0x0400061F RID: 1567
			public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> types;

			// Token: 0x04000620 RID: 1568
			public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> <>3__types;

			// Token: 0x04000621 RID: 1569
			public int <i>5__15;

			// Token: 0x04000622 RID: 1570
			public global::Mono.Cecil.TypeDefinition <type>5__16;

			// Token: 0x04000623 RID: 1571
			public global::Mono.Cecil.TypeDefinition <nested>5__17;

			// Token: 0x04000624 RID: 1572
			public global::System.Collections.Generic.IEnumerator<global::Mono.Cecil.TypeDefinition> <>7__wrap18;
		}
	}
}
