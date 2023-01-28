using System;
using System.Collections.Generic;
using System.IO;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000EE RID: 238
	internal sealed class MetadataBuilder
	{
		// Token: 0x06000872 RID: 2162 RVA: 0x00017084 File Offset: 0x00015284
		public MetadataBuilder(global::Mono.Cecil.ModuleDefinition module, string fq_name, global::Mono.Cecil.Cil.ISymbolWriterProvider symbol_writer_provider, global::Mono.Cecil.Cil.ISymbolWriter symbol_writer)
		{
			this.module = module;
			this.text_map = this.CreateTextMap();
			this.fq_name = fq_name;
			this.symbol_writer_provider = symbol_writer_provider;
			this.symbol_writer = symbol_writer;
			this.write_symbols = (symbol_writer != null);
			this.code = new global::Mono.Cecil.Cil.CodeWriter(this);
			this.data = new global::Mono.Cecil.Metadata.DataBuffer();
			this.resources = new global::Mono.Cecil.Metadata.ResourceBuffer();
			this.string_heap = new global::Mono.Cecil.Metadata.StringHeapBuffer();
			this.user_string_heap = new global::Mono.Cecil.Metadata.UserStringHeapBuffer();
			this.blob_heap = new global::Mono.Cecil.Metadata.BlobHeapBuffer();
			this.table_heap = new global::Mono.Cecil.Metadata.TableHeapBuffer(module, this);
			this.type_ref_table = this.GetTable<global::Mono.Cecil.TypeRefTable>(global::Mono.Cecil.Metadata.Table.TypeRef);
			this.type_def_table = this.GetTable<global::Mono.Cecil.TypeDefTable>(global::Mono.Cecil.Metadata.Table.TypeDef);
			this.field_table = this.GetTable<global::Mono.Cecil.FieldTable>(global::Mono.Cecil.Metadata.Table.Field);
			this.method_table = this.GetTable<global::Mono.Cecil.MethodTable>(global::Mono.Cecil.Metadata.Table.Method);
			this.param_table = this.GetTable<global::Mono.Cecil.ParamTable>(global::Mono.Cecil.Metadata.Table.Param);
			this.iface_impl_table = this.GetTable<global::Mono.Cecil.InterfaceImplTable>(global::Mono.Cecil.Metadata.Table.InterfaceImpl);
			this.member_ref_table = this.GetTable<global::Mono.Cecil.MemberRefTable>(global::Mono.Cecil.Metadata.Table.MemberRef);
			this.constant_table = this.GetTable<global::Mono.Cecil.ConstantTable>(global::Mono.Cecil.Metadata.Table.Constant);
			this.custom_attribute_table = this.GetTable<global::Mono.Cecil.CustomAttributeTable>(global::Mono.Cecil.Metadata.Table.CustomAttribute);
			this.declsec_table = this.GetTable<global::Mono.Cecil.DeclSecurityTable>(global::Mono.Cecil.Metadata.Table.DeclSecurity);
			this.standalone_sig_table = this.GetTable<global::Mono.Cecil.StandAloneSigTable>(global::Mono.Cecil.Metadata.Table.StandAloneSig);
			this.event_map_table = this.GetTable<global::Mono.Cecil.EventMapTable>(global::Mono.Cecil.Metadata.Table.EventMap);
			this.event_table = this.GetTable<global::Mono.Cecil.EventTable>(global::Mono.Cecil.Metadata.Table.Event);
			this.property_map_table = this.GetTable<global::Mono.Cecil.PropertyMapTable>(global::Mono.Cecil.Metadata.Table.PropertyMap);
			this.property_table = this.GetTable<global::Mono.Cecil.PropertyTable>(global::Mono.Cecil.Metadata.Table.Property);
			this.typespec_table = this.GetTable<global::Mono.Cecil.TypeSpecTable>(global::Mono.Cecil.Metadata.Table.TypeSpec);
			this.method_spec_table = this.GetTable<global::Mono.Cecil.MethodSpecTable>(global::Mono.Cecil.Metadata.Table.MethodSpec);
			global::Mono.Cecil.Metadata.RowEqualityComparer comparer = new global::Mono.Cecil.Metadata.RowEqualityComparer();
			this.type_ref_map = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<uint, uint, uint>, global::Mono.Cecil.MetadataToken>(comparer);
			this.type_spec_map = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken>();
			this.member_ref_map = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<uint, uint, uint>, global::Mono.Cecil.MetadataToken>(comparer);
			this.method_spec_map = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<uint, uint>, global::Mono.Cecil.MetadataToken>(comparer);
			this.generic_parameters = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>();
			if (this.write_symbols)
			{
				this.method_def_map = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.MetadataToken>();
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00017284 File Offset: 0x00015484
		private global::Mono.Cecil.PE.TextMap CreateTextMap()
		{
			global::Mono.Cecil.PE.TextMap textMap = new global::Mono.Cecil.PE.TextMap();
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.ImportAddressTable, (this.module.Architecture == global::Mono.Cecil.TargetArchitecture.I386) ? 8 : 0x10);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.CLIHeader, 0x48, 8);
			return textMap;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x000172BB File Offset: 0x000154BB
		private TTable GetTable<TTable>(global::Mono.Cecil.Metadata.Table table) where TTable : global::Mono.Cecil.MetadataTable, new()
		{
			return this.table_heap.GetTable<TTable>(table);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000172C9 File Offset: 0x000154C9
		private uint GetStringIndex(string @string)
		{
			if (string.IsNullOrEmpty(@string))
			{
				return 0U;
			}
			return this.string_heap.GetStringIndex(@string);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x000172E1 File Offset: 0x000154E1
		private uint GetBlobIndex(global::Mono.Cecil.PE.ByteBuffer blob)
		{
			if (blob.length == 0)
			{
				return 0U;
			}
			return this.blob_heap.GetBlobIndex(blob);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000172F9 File Offset: 0x000154F9
		private uint GetBlobIndex(byte[] blob)
		{
			if (blob.IsNullOrEmpty<byte>())
			{
				return 0U;
			}
			return this.GetBlobIndex(new global::Mono.Cecil.PE.ByteBuffer(blob));
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00017311 File Offset: 0x00015511
		public void BuildMetadata()
		{
			this.BuildModule();
			this.table_heap.WriteTableHeap();
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00017324 File Offset: 0x00015524
		private void BuildModule()
		{
			global::Mono.Cecil.ModuleTable table = this.GetTable<global::Mono.Cecil.ModuleTable>(global::Mono.Cecil.Metadata.Table.Module);
			table.row = this.GetStringIndex(this.module.Name);
			global::Mono.Cecil.AssemblyDefinition assembly = this.module.Assembly;
			if (assembly != null)
			{
				this.BuildAssembly();
			}
			if (this.module.HasAssemblyReferences)
			{
				this.AddAssemblyReferences();
			}
			if (this.module.HasModuleReferences)
			{
				this.AddModuleReferences();
			}
			if (this.module.HasResources)
			{
				this.AddResources();
			}
			if (this.module.HasExportedTypes)
			{
				this.AddExportedTypes();
			}
			this.BuildTypes();
			if (assembly != null)
			{
				if (assembly.HasCustomAttributes)
				{
					this.AddCustomAttributes(assembly);
				}
				if (assembly.HasSecurityDeclarations)
				{
					this.AddSecurityDeclarations(assembly);
				}
			}
			if (this.module.HasCustomAttributes)
			{
				this.AddCustomAttributes(this.module);
			}
			if (this.module.EntryPoint != null)
			{
				this.entry_point = this.LookupToken(this.module.EntryPoint);
			}
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00017418 File Offset: 0x00015618
		private void BuildAssembly()
		{
			global::Mono.Cecil.AssemblyDefinition assembly = this.module.Assembly;
			global::Mono.Cecil.AssemblyNameDefinition name = assembly.Name;
			global::Mono.Cecil.AssemblyTable table = this.GetTable<global::Mono.Cecil.AssemblyTable>(global::Mono.Cecil.Metadata.Table.Assembly);
			table.row = new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.AssemblyHashAlgorithm, ushort, ushort, ushort, ushort, global::Mono.Cecil.AssemblyAttributes, uint, uint, uint>(name.HashAlgorithm, (ushort)name.Version.Major, (ushort)name.Version.Minor, (ushort)name.Version.Build, (ushort)name.Version.Revision, name.Attributes, this.GetBlobIndex(name.PublicKey), this.GetStringIndex(name.Name), this.GetStringIndex(name.Culture));
			if (assembly.Modules.Count > 1)
			{
				this.BuildModules();
			}
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000174C0 File Offset: 0x000156C0
		private void BuildModules()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> modules = this.module.Assembly.Modules;
			global::Mono.Cecil.FileTable table = this.GetTable<global::Mono.Cecil.FileTable>(global::Mono.Cecil.Metadata.Table.File);
			for (int i = 0; i < modules.Count; i++)
			{
				global::Mono.Cecil.ModuleDefinition moduleDefinition = modules[i];
				if (!moduleDefinition.IsMain)
				{
					global::Mono.Cecil.WriterParameters parameters = new global::Mono.Cecil.WriterParameters
					{
						SymbolWriterProvider = this.symbol_writer_provider
					};
					string moduleFileName = this.GetModuleFileName(moduleDefinition.Name);
					moduleDefinition.Write(moduleFileName, parameters);
					byte[] blob = global::Mono.Cecil.CryptoService.ComputeHash(moduleFileName);
					table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, uint, uint>(global::Mono.Cecil.FileAttributes.ContainsMetaData, this.GetStringIndex(moduleDefinition.Name), this.GetBlobIndex(blob)));
				}
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00017564 File Offset: 0x00015764
		private string GetModuleFileName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new global::System.NotSupportedException();
			}
			string directoryName = global::System.IO.Path.GetDirectoryName(this.fq_name);
			return global::System.IO.Path.Combine(directoryName, name);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00017594 File Offset: 0x00015794
		private void AddAssemblyReferences()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> assemblyReferences = this.module.AssemblyReferences;
			global::Mono.Cecil.AssemblyRefTable table = this.GetTable<global::Mono.Cecil.AssemblyRefTable>(global::Mono.Cecil.Metadata.Table.AssemblyRef);
			for (int i = 0; i < assemblyReferences.Count; i++)
			{
				global::Mono.Cecil.AssemblyNameReference assemblyNameReference = assemblyReferences[i];
				byte[] blob = assemblyNameReference.PublicKey.IsNullOrEmpty<byte>() ? assemblyNameReference.PublicKeyToken : assemblyNameReference.PublicKey;
				global::System.Version version = assemblyNameReference.Version;
				int rid = table.AddRow(new global::Mono.Cecil.Metadata.Row<ushort, ushort, ushort, ushort, global::Mono.Cecil.AssemblyAttributes, uint, uint, uint, uint>((ushort)version.Major, (ushort)version.Minor, (ushort)version.Build, (ushort)version.Revision, assemblyNameReference.Attributes, this.GetBlobIndex(blob), this.GetStringIndex(assemblyNameReference.Name), this.GetStringIndex(assemblyNameReference.Culture), this.GetBlobIndex(assemblyNameReference.Hash)));
				assemblyNameReference.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.AssemblyRef, rid);
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0001766C File Offset: 0x0001586C
		private void AddModuleReferences()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference> moduleReferences = this.module.ModuleReferences;
			global::Mono.Cecil.ModuleRefTable table = this.GetTable<global::Mono.Cecil.ModuleRefTable>(global::Mono.Cecil.Metadata.Table.ModuleRef);
			for (int i = 0; i < moduleReferences.Count; i++)
			{
				global::Mono.Cecil.ModuleReference moduleReference = moduleReferences[i];
				moduleReference.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.ModuleRef, table.AddRow(this.GetStringIndex(moduleReference.Name)));
			}
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x000176CC File Offset: 0x000158CC
		private void AddResources()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource> collection = this.module.Resources;
			global::Mono.Cecil.ManifestResourceTable table = this.GetTable<global::Mono.Cecil.ManifestResourceTable>(global::Mono.Cecil.Metadata.Table.ManifestResource);
			for (int i = 0; i < collection.Count; i++)
			{
				global::Mono.Cecil.Resource resource = collection[i];
				global::Mono.Cecil.Metadata.Row<uint, global::Mono.Cecil.ManifestResourceAttributes, uint, uint> row = new global::Mono.Cecil.Metadata.Row<uint, global::Mono.Cecil.ManifestResourceAttributes, uint, uint>(0U, resource.Attributes, this.GetStringIndex(resource.Name), 0U);
				switch (resource.ResourceType)
				{
				case global::Mono.Cecil.ResourceType.Embedded:
					row.Col1 = this.AddEmbeddedResource((global::Mono.Cecil.EmbeddedResource)resource);
					break;
				case global::Mono.Cecil.ResourceType.Linked:
					row.Col4 = global::Mono.Cecil.Metadata.CodedIndex.Implementation.CompressMetadataToken(new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.File, this.AddLinkedResource((global::Mono.Cecil.LinkedResource)resource)));
					break;
				case global::Mono.Cecil.ResourceType.AssemblyLinked:
					row.Col4 = global::Mono.Cecil.Metadata.CodedIndex.Implementation.CompressMetadataToken(((global::Mono.Cecil.AssemblyLinkedResource)resource).Assembly.MetadataToken);
					break;
				default:
					throw new global::System.NotSupportedException();
				}
				table.AddRow(row);
			}
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000177B0 File Offset: 0x000159B0
		private uint AddLinkedResource(global::Mono.Cecil.LinkedResource resource)
		{
			global::Mono.Cecil.FileTable table = this.GetTable<global::Mono.Cecil.FileTable>(global::Mono.Cecil.Metadata.Table.File);
			byte[] blob = resource.Hash.IsNullOrEmpty<byte>() ? global::Mono.Cecil.CryptoService.ComputeHash(resource.File) : resource.Hash;
			return (uint)table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, uint, uint>(global::Mono.Cecil.FileAttributes.ContainsNoMetaData, this.GetStringIndex(resource.File), this.GetBlobIndex(blob)));
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00017806 File Offset: 0x00015A06
		private uint AddEmbeddedResource(global::Mono.Cecil.EmbeddedResource resource)
		{
			return this.resources.AddResource(resource.Data);
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0001781C File Offset: 0x00015A1C
		private void AddExportedTypes()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> exportedTypes = this.module.ExportedTypes;
			global::Mono.Cecil.ExportedTypeTable table = this.GetTable<global::Mono.Cecil.ExportedTypeTable>(global::Mono.Cecil.Metadata.Table.ExportedType);
			for (int i = 0; i < exportedTypes.Count; i++)
			{
				global::Mono.Cecil.ExportedType exportedType = exportedTypes[i];
				int rid = table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.TypeAttributes, uint, uint, uint, uint>(exportedType.Attributes, (uint)exportedType.Identifier, this.GetStringIndex(exportedType.Name), this.GetStringIndex(exportedType.Namespace), global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.GetExportedTypeScope(exportedType), global::Mono.Cecil.Metadata.CodedIndex.Implementation)));
				exportedType.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.ExportedType, rid);
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x000178A8 File Offset: 0x00015AA8
		private global::Mono.Cecil.MetadataToken GetExportedTypeScope(global::Mono.Cecil.ExportedType exported_type)
		{
			if (exported_type.DeclaringType != null)
			{
				return exported_type.DeclaringType.MetadataToken;
			}
			global::Mono.Cecil.IMetadataScope scope = exported_type.Scope;
			global::Mono.Cecil.TokenType tokenType = scope.MetadataToken.TokenType;
			if (tokenType != global::Mono.Cecil.TokenType.ModuleRef)
			{
				if (tokenType == global::Mono.Cecil.TokenType.AssemblyRef)
				{
					return scope.MetadataToken;
				}
			}
			else
			{
				global::Mono.Cecil.FileTable table = this.GetTable<global::Mono.Cecil.FileTable>(global::Mono.Cecil.Metadata.Table.File);
				for (int i = 0; i < table.length; i++)
				{
					if (table.rows[i].Col2 == this.GetStringIndex(scope.Name))
					{
						return new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.File, i + 1);
					}
				}
			}
			throw new global::System.NotSupportedException();
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00017945 File Offset: 0x00015B45
		private void BuildTypes()
		{
			if (!this.module.HasTypes)
			{
				return;
			}
			this.AttachTokens();
			this.AddTypeDefs();
			this.AddGenericParameters();
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00017968 File Offset: 0x00015B68
		private void AttachTokens()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> types = this.module.Types;
			for (int i = 0; i < types.Count; i++)
			{
				this.AttachTypeDefToken(types[i]);
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x000179A0 File Offset: 0x00015BA0
		private void AttachTypeDefToken(global::Mono.Cecil.TypeDefinition type)
		{
			type.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeDef, this.type_rid++);
			type.fields_range.Start = this.field_rid;
			type.methods_range.Start = this.method_rid;
			if (type.HasFields)
			{
				this.AttachFieldsDefToken(type);
			}
			if (type.HasMethods)
			{
				this.AttachMethodsDefToken(type);
			}
			if (type.HasNestedTypes)
			{
				this.AttachNestedTypesDefToken(type);
			}
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00017A20 File Offset: 0x00015C20
		private void AttachNestedTypesDefToken(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> nestedTypes = type.NestedTypes;
			for (int i = 0; i < nestedTypes.Count; i++)
			{
				this.AttachTypeDefToken(nestedTypes[i]);
			}
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00017A54 File Offset: 0x00015C54
		private void AttachFieldsDefToken(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields = type.Fields;
			type.fields_range.Length = (uint)fields.Count;
			for (int i = 0; i < fields.Count; i++)
			{
				fields[i].token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Field, this.field_rid++);
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00017AB4 File Offset: 0x00015CB4
		private void AttachMethodsDefToken(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods = type.Methods;
			type.methods_range.Length = (uint)methods.Count;
			for (int i = 0; i < methods.Count; i++)
			{
				global::Mono.Cecil.MethodDefinition methodDefinition = methods[i];
				global::Mono.Cecil.MetadataToken metadataToken = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Method, this.method_rid++);
				if (this.write_symbols && methodDefinition.token != global::Mono.Cecil.MetadataToken.Zero)
				{
					this.method_def_map.Add(metadataToken, methodDefinition.token);
				}
				methodDefinition.token = metadataToken;
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00017B44 File Offset: 0x00015D44
		public bool TryGetOriginalMethodToken(global::Mono.Cecil.MetadataToken new_token, out global::Mono.Cecil.MetadataToken original)
		{
			return this.method_def_map.TryGetValue(new_token, out original);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00017B53 File Offset: 0x00015D53
		private global::Mono.Cecil.MetadataToken GetTypeToken(global::Mono.Cecil.TypeReference type)
		{
			if (type == null)
			{
				return global::Mono.Cecil.MetadataToken.Zero;
			}
			if (type.IsDefinition)
			{
				return type.token;
			}
			if (type.IsTypeSpecification())
			{
				return this.GetTypeSpecToken(type);
			}
			return this.GetTypeRefToken(type);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00017B84 File Offset: 0x00015D84
		private global::Mono.Cecil.MetadataToken GetTypeSpecToken(global::Mono.Cecil.TypeReference type)
		{
			uint blobIndex = this.GetBlobIndex(this.GetTypeSpecSignature(type));
			global::Mono.Cecil.MetadataToken result;
			if (this.type_spec_map.TryGetValue(blobIndex, out result))
			{
				return result;
			}
			return this.AddTypeSpecification(type, blobIndex);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00017BBC File Offset: 0x00015DBC
		private global::Mono.Cecil.MetadataToken AddTypeSpecification(global::Mono.Cecil.TypeReference type, uint row)
		{
			type.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeSpec, this.typespec_table.AddRow(row));
			global::Mono.Cecil.MetadataToken token = type.token;
			this.type_spec_map.Add(row, token);
			return token;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00017BFC File Offset: 0x00015DFC
		private global::Mono.Cecil.MetadataToken GetTypeRefToken(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.Metadata.Row<uint, uint, uint> row = this.CreateTypeRefRow(type);
			global::Mono.Cecil.MetadataToken result;
			if (this.type_ref_map.TryGetValue(row, out result))
			{
				return result;
			}
			return this.AddTypeReference(type, row);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00017C2C File Offset: 0x00015E2C
		private global::Mono.Cecil.Metadata.Row<uint, uint, uint> CreateTypeRefRow(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.MetadataToken token = type.IsNested ? this.GetTypeRefToken(type.DeclaringType) : type.Scope.MetadataToken;
			return new global::Mono.Cecil.Metadata.Row<uint, uint, uint>(global::Mono.Cecil.MetadataBuilder.MakeCodedRID(token, global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope), this.GetStringIndex(type.Name), this.GetStringIndex(type.Namespace));
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00017C80 File Offset: 0x00015E80
		private static uint MakeCodedRID(global::Mono.Cecil.IMetadataTokenProvider provider, global::Mono.Cecil.Metadata.CodedIndex index)
		{
			return global::Mono.Cecil.MetadataBuilder.MakeCodedRID(provider.MetadataToken, index);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00017C8E File Offset: 0x00015E8E
		private static uint MakeCodedRID(global::Mono.Cecil.MetadataToken token, global::Mono.Cecil.Metadata.CodedIndex index)
		{
			return index.CompressMetadataToken(token);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00017C98 File Offset: 0x00015E98
		private global::Mono.Cecil.MetadataToken AddTypeReference(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.Metadata.Row<uint, uint, uint> row)
		{
			type.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeRef, this.type_ref_table.AddRow(row));
			global::Mono.Cecil.MetadataToken token = type.token;
			this.type_ref_map.Add(row, token);
			return token;
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00017CD8 File Offset: 0x00015ED8
		private void AddTypeDefs()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> types = this.module.Types;
			for (int i = 0; i < types.Count; i++)
			{
				this.AddType(types[i]);
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00017D10 File Offset: 0x00015F10
		private void AddType(global::Mono.Cecil.TypeDefinition type)
		{
			this.type_def_table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.TypeAttributes, uint, uint, uint, uint, uint>(type.Attributes, this.GetStringIndex(type.Name), this.GetStringIndex(type.Namespace), global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.GetTypeToken(type.BaseType), global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef), type.fields_range.Start, type.methods_range.Start));
			if (type.HasGenericParameters)
			{
				this.AddGenericParameters(type);
			}
			if (type.HasInterfaces)
			{
				this.AddInterfaces(type);
			}
			if (type.HasLayoutInfo)
			{
				this.AddLayoutInfo(type);
			}
			if (type.HasFields)
			{
				this.AddFields(type);
			}
			if (type.HasMethods)
			{
				this.AddMethods(type);
			}
			if (type.HasProperties)
			{
				this.AddProperties(type);
			}
			if (type.HasEvents)
			{
				this.AddEvents(type);
			}
			if (type.HasCustomAttributes)
			{
				this.AddCustomAttributes(type);
			}
			if (type.HasSecurityDeclarations)
			{
				this.AddSecurityDeclarations(type);
			}
			if (type.HasNestedTypes)
			{
				this.AddNestedTypes(type);
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00017E0C File Offset: 0x0001600C
		private void AddGenericParameters(global::Mono.Cecil.IGenericParameterProvider owner)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genericParameters = owner.GenericParameters;
			for (int i = 0; i < genericParameters.Count; i++)
			{
				this.generic_parameters.Add(genericParameters[i]);
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00017E44 File Offset: 0x00016044
		private void AddGenericParameters()
		{
			global::Mono.Cecil.GenericParameter[] items = this.generic_parameters.items;
			int size = this.generic_parameters.size;
			global::System.Array.Sort<global::Mono.Cecil.GenericParameter>(items, 0, size, new global::Mono.Cecil.MetadataBuilder.GenericParameterComparer());
			global::Mono.Cecil.GenericParamTable table = this.GetTable<global::Mono.Cecil.GenericParamTable>(global::Mono.Cecil.Metadata.Table.GenericParam);
			global::Mono.Cecil.GenericParamConstraintTable table2 = this.GetTable<global::Mono.Cecil.GenericParamConstraintTable>(global::Mono.Cecil.Metadata.Table.GenericParamConstraint);
			for (int i = 0; i < size; i++)
			{
				global::Mono.Cecil.GenericParameter genericParameter = items[i];
				int rid = table.AddRow(new global::Mono.Cecil.Metadata.Row<ushort, global::Mono.Cecil.GenericParameterAttributes, uint, uint>((ushort)genericParameter.Position, genericParameter.Attributes, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(genericParameter.Owner, global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef), this.GetStringIndex(genericParameter.Name)));
				genericParameter.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.GenericParam, rid);
				if (genericParameter.HasConstraints)
				{
					this.AddConstraints(genericParameter, table2);
				}
				if (genericParameter.HasCustomAttributes)
				{
					this.AddCustomAttributes(genericParameter);
				}
			}
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00017F0C File Offset: 0x0001610C
		private void AddConstraints(global::Mono.Cecil.GenericParameter generic_parameter, global::Mono.Cecil.GenericParamConstraintTable table)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> constraints = generic_parameter.Constraints;
			uint rid = generic_parameter.token.RID;
			for (int i = 0; i < constraints.Count; i++)
			{
				table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(rid, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.GetTypeToken(constraints[i]), global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef)));
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00017F60 File Offset: 0x00016160
		private void AddInterfaces(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> interfaces = type.Interfaces;
			uint rid = type.token.RID;
			for (int i = 0; i < interfaces.Count; i++)
			{
				this.iface_impl_table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(rid, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.GetTypeToken(interfaces[i]), global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef)));
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00017FB8 File Offset: 0x000161B8
		private void AddLayoutInfo(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Cecil.ClassLayoutTable table = this.GetTable<global::Mono.Cecil.ClassLayoutTable>(global::Mono.Cecil.Metadata.Table.ClassLayout);
			table.AddRow(new global::Mono.Cecil.Metadata.Row<ushort, uint, uint>((ushort)type.PackingSize, (uint)type.ClassSize, type.token.RID));
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00017FF4 File Offset: 0x000161F4
		private void AddNestedTypes(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> nestedTypes = type.NestedTypes;
			global::Mono.Cecil.NestedClassTable table = this.GetTable<global::Mono.Cecil.NestedClassTable>(global::Mono.Cecil.Metadata.Table.NestedClass);
			for (int i = 0; i < nestedTypes.Count; i++)
			{
				global::Mono.Cecil.TypeDefinition typeDefinition = nestedTypes[i];
				this.AddType(typeDefinition);
				table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(typeDefinition.token.RID, type.token.RID));
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00018054 File Offset: 0x00016254
		private void AddFields(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields = type.Fields;
			for (int i = 0; i < fields.Count; i++)
			{
				this.AddField(fields[i]);
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00018088 File Offset: 0x00016288
		private void AddField(global::Mono.Cecil.FieldDefinition field)
		{
			this.field_table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FieldAttributes, uint, uint>(field.Attributes, this.GetStringIndex(field.Name), this.GetBlobIndex(this.GetFieldSignature(field))));
			if (!field.InitialValue.IsNullOrEmpty<byte>())
			{
				this.AddFieldRVA(field);
			}
			if (field.HasLayoutInfo)
			{
				this.AddFieldLayout(field);
			}
			if (field.HasCustomAttributes)
			{
				this.AddCustomAttributes(field);
			}
			if (field.HasConstant)
			{
				this.AddConstant(field, field.FieldType);
			}
			if (field.HasMarshalInfo)
			{
				this.AddMarshalInfo(field);
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0001811C File Offset: 0x0001631C
		private void AddFieldRVA(global::Mono.Cecil.FieldDefinition field)
		{
			global::Mono.Cecil.FieldRVATable table = this.GetTable<global::Mono.Cecil.FieldRVATable>(global::Mono.Cecil.Metadata.Table.FieldRVA);
			table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(this.data.AddData(field.InitialValue), field.token.RID));
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0001815C File Offset: 0x0001635C
		private void AddFieldLayout(global::Mono.Cecil.FieldDefinition field)
		{
			global::Mono.Cecil.FieldLayoutTable table = this.GetTable<global::Mono.Cecil.FieldLayoutTable>(global::Mono.Cecil.Metadata.Table.FieldLayout);
			table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>((uint)field.Offset, field.token.RID));
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00018190 File Offset: 0x00016390
		private void AddMethods(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods = type.Methods;
			for (int i = 0; i < methods.Count; i++)
			{
				this.AddMethod(methods[i]);
			}
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x000181C4 File Offset: 0x000163C4
		private void AddMethod(global::Mono.Cecil.MethodDefinition method)
		{
			this.method_table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, global::Mono.Cecil.MethodImplAttributes, global::Mono.Cecil.MethodAttributes, uint, uint, uint>(method.HasBody ? this.code.WriteMethodBody(method) : 0U, method.ImplAttributes, method.Attributes, this.GetStringIndex(method.Name), this.GetBlobIndex(this.GetMethodSignature(method)), this.param_rid));
			this.AddParameters(method);
			if (method.HasGenericParameters)
			{
				this.AddGenericParameters(method);
			}
			if (method.IsPInvokeImpl)
			{
				this.AddPInvokeInfo(method);
			}
			if (method.HasCustomAttributes)
			{
				this.AddCustomAttributes(method);
			}
			if (method.HasSecurityDeclarations)
			{
				this.AddSecurityDeclarations(method);
			}
			if (method.HasOverrides)
			{
				this.AddOverrides(method);
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00018278 File Offset: 0x00016478
		private void AddParameters(global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Cecil.ParameterDefinition parameter = method.MethodReturnType.parameter;
			if (parameter != null && global::Mono.Cecil.MetadataBuilder.RequiresParameterRow(parameter))
			{
				this.AddParameter(0, parameter, this.param_table);
			}
			if (!method.HasParameters)
			{
				return;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = method.Parameters;
			for (int i = 0; i < parameters.Count; i++)
			{
				global::Mono.Cecil.ParameterDefinition parameter2 = parameters[i];
				if (global::Mono.Cecil.MetadataBuilder.RequiresParameterRow(parameter2))
				{
					this.AddParameter((ushort)(i + 1), parameter2, this.param_table);
				}
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000182EC File Offset: 0x000164EC
		private void AddPInvokeInfo(global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Cecil.PInvokeInfo pinvokeInfo = method.PInvokeInfo;
			if (pinvokeInfo == null)
			{
				throw new global::System.ArgumentException();
			}
			global::Mono.Cecil.ImplMapTable table = this.GetTable<global::Mono.Cecil.ImplMapTable>(global::Mono.Cecil.Metadata.Table.ImplMap);
			table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint, uint>(pinvokeInfo.Attributes, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(method, global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded), this.GetStringIndex(pinvokeInfo.EntryPoint), pinvokeInfo.Module.MetadataToken.RID));
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0001834C File Offset: 0x0001654C
		private void AddOverrides(global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> overrides = method.Overrides;
			global::Mono.Cecil.MethodImplTable table = this.GetTable<global::Mono.Cecil.MethodImplTable>(global::Mono.Cecil.Metadata.Table.MethodImpl);
			for (int i = 0; i < overrides.Count; i++)
			{
				table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint, uint>(method.DeclaringType.token.RID, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(method, global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef), global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.LookupToken(overrides[i]), global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef)));
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x000183B0 File Offset: 0x000165B0
		private static bool RequiresParameterRow(global::Mono.Cecil.ParameterDefinition parameter)
		{
			return !string.IsNullOrEmpty(parameter.Name) || parameter.Attributes != global::Mono.Cecil.ParameterAttributes.None || parameter.HasMarshalInfo || parameter.HasConstant || parameter.HasCustomAttributes;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x000183E0 File Offset: 0x000165E0
		private void AddParameter(ushort sequence, global::Mono.Cecil.ParameterDefinition parameter, global::Mono.Cecil.ParamTable table)
		{
			table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.ParameterAttributes, ushort, uint>(parameter.Attributes, sequence, this.GetStringIndex(parameter.Name)));
			parameter.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Param, this.param_rid++);
			if (parameter.HasCustomAttributes)
			{
				this.AddCustomAttributes(parameter);
			}
			if (parameter.HasConstant)
			{
				this.AddConstant(parameter, parameter.ParameterType);
			}
			if (parameter.HasMarshalInfo)
			{
				this.AddMarshalInfo(parameter);
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00018460 File Offset: 0x00016660
		private void AddMarshalInfo(global::Mono.Cecil.IMarshalInfoProvider owner)
		{
			global::Mono.Cecil.FieldMarshalTable table = this.GetTable<global::Mono.Cecil.FieldMarshalTable>(global::Mono.Cecil.Metadata.Table.FieldMarshal);
			table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(global::Mono.Cecil.MetadataBuilder.MakeCodedRID(owner, global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal), this.GetBlobIndex(this.GetMarshalInfoSignature(owner))));
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00018498 File Offset: 0x00016698
		private void AddProperties(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> properties = type.Properties;
			this.property_map_table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(type.token.RID, this.property_rid));
			for (int i = 0; i < properties.Count; i++)
			{
				this.AddProperty(properties[i]);
			}
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000184EC File Offset: 0x000166EC
		private void AddProperty(global::Mono.Cecil.PropertyDefinition property)
		{
			this.property_table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PropertyAttributes, uint, uint>(property.Attributes, this.GetStringIndex(property.Name), this.GetBlobIndex(this.GetPropertySignature(property))));
			property.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Property, this.property_rid++);
			global::Mono.Cecil.MethodDefinition methodDefinition = property.GetMethod;
			if (methodDefinition != null)
			{
				this.AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes.Getter, property, methodDefinition);
			}
			methodDefinition = property.SetMethod;
			if (methodDefinition != null)
			{
				this.AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes.Setter, property, methodDefinition);
			}
			if (property.HasOtherMethods)
			{
				this.AddOtherSemantic(property, property.OtherMethods);
			}
			if (property.HasCustomAttributes)
			{
				this.AddCustomAttributes(property);
			}
			if (property.HasConstant)
			{
				this.AddConstant(property, property.PropertyType);
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x000185AC File Offset: 0x000167AC
		private void AddOtherSemantic(global::Mono.Cecil.IMetadataTokenProvider owner, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> others)
		{
			for (int i = 0; i < others.Count; i++)
			{
				this.AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes.Other, owner, others[i]);
			}
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x000185DC File Offset: 0x000167DC
		private void AddEvents(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> events = type.Events;
			this.event_map_table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint>(type.token.RID, this.event_rid));
			for (int i = 0; i < events.Count; i++)
			{
				this.AddEvent(events[i]);
			}
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00018630 File Offset: 0x00016830
		private void AddEvent(global::Mono.Cecil.EventDefinition @event)
		{
			this.event_table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.EventAttributes, uint, uint>(@event.Attributes, this.GetStringIndex(@event.Name), global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.GetTypeToken(@event.EventType), global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef)));
			@event.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Event, this.event_rid++);
			global::Mono.Cecil.MethodDefinition methodDefinition = @event.AddMethod;
			if (methodDefinition != null)
			{
				this.AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes.AddOn, @event, methodDefinition);
			}
			methodDefinition = @event.InvokeMethod;
			if (methodDefinition != null)
			{
				this.AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes.Fire, @event, methodDefinition);
			}
			methodDefinition = @event.RemoveMethod;
			if (methodDefinition != null)
			{
				this.AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes.RemoveOn, @event, methodDefinition);
			}
			if (@event.HasOtherMethods)
			{
				this.AddOtherSemantic(@event, @event.OtherMethods);
			}
			if (@event.HasCustomAttributes)
			{
				this.AddCustomAttributes(@event);
			}
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x000186F4 File Offset: 0x000168F4
		private void AddSemantic(global::Mono.Cecil.MethodSemanticsAttributes semantics, global::Mono.Cecil.IMetadataTokenProvider provider, global::Mono.Cecil.MethodDefinition method)
		{
			method.SemanticsAttributes = semantics;
			global::Mono.Cecil.MethodSemanticsTable table = this.GetTable<global::Mono.Cecil.MethodSemanticsTable>(global::Mono.Cecil.Metadata.Table.MethodSemantics);
			table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, uint, uint>(semantics, method.token.RID, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(provider, global::Mono.Cecil.Metadata.CodedIndex.HasSemantics)));
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00018730 File Offset: 0x00016930
		private void AddConstant(global::Mono.Cecil.IConstantProvider owner, global::Mono.Cecil.TypeReference type)
		{
			object constant = owner.Constant;
			global::Mono.Cecil.Metadata.ElementType constantType = global::Mono.Cecil.MetadataBuilder.GetConstantType(type, constant);
			this.constant_table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint, uint>(constantType, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(owner.MetadataToken, global::Mono.Cecil.Metadata.CodedIndex.HasConstant), this.GetBlobIndex(this.GetConstantSignature(constantType, constant))));
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00018778 File Offset: 0x00016978
		private static global::Mono.Cecil.Metadata.ElementType GetConstantType(global::Mono.Cecil.TypeReference constant_type, object constant)
		{
			if (constant == null)
			{
				return global::Mono.Cecil.Metadata.ElementType.Class;
			}
			global::Mono.Cecil.Metadata.ElementType etype = constant_type.etype;
			global::Mono.Cecil.Metadata.ElementType elementType = etype;
			switch (elementType)
			{
			case global::Mono.Cecil.Metadata.ElementType.None:
			{
				global::Mono.Cecil.TypeDefinition typeDefinition = constant_type.CheckedResolve();
				if (typeDefinition.IsEnum)
				{
					return global::Mono.Cecil.MetadataBuilder.GetConstantType(typeDefinition.GetEnumUnderlyingType(), constant);
				}
				return global::Mono.Cecil.Metadata.ElementType.Class;
			}
			case global::Mono.Cecil.Metadata.ElementType.Void:
			case global::Mono.Cecil.Metadata.ElementType.Ptr:
			case global::Mono.Cecil.Metadata.ElementType.ValueType:
			case global::Mono.Cecil.Metadata.ElementType.Class:
			case global::Mono.Cecil.Metadata.ElementType.TypedByRef:
			case (global::Mono.Cecil.Metadata.ElementType)0x17:
			case (global::Mono.Cecil.Metadata.ElementType)0x1A:
			case global::Mono.Cecil.Metadata.ElementType.FnPtr:
				return etype;
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
				return global::Mono.Cecil.MetadataBuilder.GetConstantType(constant.GetType());
			case global::Mono.Cecil.Metadata.ElementType.String:
				return global::Mono.Cecil.Metadata.ElementType.String;
			case global::Mono.Cecil.Metadata.ElementType.ByRef:
			case global::Mono.Cecil.Metadata.ElementType.GenericInst:
			case global::Mono.Cecil.Metadata.ElementType.CModReqD:
			case global::Mono.Cecil.Metadata.ElementType.CModOpt:
				break;
			case global::Mono.Cecil.Metadata.ElementType.Var:
			case global::Mono.Cecil.Metadata.ElementType.Array:
			case global::Mono.Cecil.Metadata.ElementType.SzArray:
			case global::Mono.Cecil.Metadata.ElementType.MVar:
				return global::Mono.Cecil.Metadata.ElementType.Class;
			case global::Mono.Cecil.Metadata.ElementType.Object:
				return global::Mono.Cecil.MetadataBuilder.GetConstantType(constant.GetType());
			default:
				if (elementType != global::Mono.Cecil.Metadata.ElementType.Sentinel)
				{
					return etype;
				}
				break;
			}
			return global::Mono.Cecil.MetadataBuilder.GetConstantType(((global::Mono.Cecil.TypeSpecification)constant_type).ElementType, constant);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00018878 File Offset: 0x00016A78
		private static global::Mono.Cecil.Metadata.ElementType GetConstantType(global::System.Type type)
		{
			switch (global::System.Type.GetTypeCode(type))
			{
			case global::System.TypeCode.Boolean:
				return global::Mono.Cecil.Metadata.ElementType.Boolean;
			case global::System.TypeCode.Char:
				return global::Mono.Cecil.Metadata.ElementType.Char;
			case global::System.TypeCode.SByte:
				return global::Mono.Cecil.Metadata.ElementType.I1;
			case global::System.TypeCode.Byte:
				return global::Mono.Cecil.Metadata.ElementType.U1;
			case global::System.TypeCode.Int16:
				return global::Mono.Cecil.Metadata.ElementType.I2;
			case global::System.TypeCode.UInt16:
				return global::Mono.Cecil.Metadata.ElementType.U2;
			case global::System.TypeCode.Int32:
				return global::Mono.Cecil.Metadata.ElementType.I4;
			case global::System.TypeCode.UInt32:
				return global::Mono.Cecil.Metadata.ElementType.U4;
			case global::System.TypeCode.Int64:
				return global::Mono.Cecil.Metadata.ElementType.I8;
			case global::System.TypeCode.UInt64:
				return global::Mono.Cecil.Metadata.ElementType.U8;
			case global::System.TypeCode.Single:
				return global::Mono.Cecil.Metadata.ElementType.R4;
			case global::System.TypeCode.Double:
				return global::Mono.Cecil.Metadata.ElementType.R8;
			case global::System.TypeCode.String:
				return global::Mono.Cecil.Metadata.ElementType.String;
			}
			throw new global::System.NotSupportedException(type.FullName);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00018904 File Offset: 0x00016B04
		private void AddCustomAttributes(global::Mono.Cecil.ICustomAttributeProvider owner)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> customAttributes = owner.CustomAttributes;
			for (int i = 0; i < customAttributes.Count; i++)
			{
				global::Mono.Cecil.CustomAttribute customAttribute = customAttributes[i];
				this.custom_attribute_table.AddRow(new global::Mono.Cecil.Metadata.Row<uint, uint, uint>(global::Mono.Cecil.MetadataBuilder.MakeCodedRID(owner, global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute), global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.LookupToken(customAttribute.Constructor), global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType), this.GetBlobIndex(this.GetCustomAttributeSignature(customAttribute))));
			}
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0001896C File Offset: 0x00016B6C
		private void AddSecurityDeclarations(global::Mono.Cecil.ISecurityDeclarationProvider owner)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> securityDeclarations = owner.SecurityDeclarations;
			for (int i = 0; i < securityDeclarations.Count; i++)
			{
				global::Mono.Cecil.SecurityDeclaration securityDeclaration = securityDeclarations[i];
				this.declsec_table.AddRow(new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.SecurityAction, uint, uint>(securityDeclaration.Action, global::Mono.Cecil.MetadataBuilder.MakeCodedRID(owner, global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity), this.GetBlobIndex(this.GetSecurityDeclarationSignature(securityDeclaration))));
			}
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x000189C4 File Offset: 0x00016BC4
		private global::Mono.Cecil.MetadataToken GetMemberRefToken(global::Mono.Cecil.MemberReference member)
		{
			global::Mono.Cecil.Metadata.Row<uint, uint, uint> row = this.CreateMemberRefRow(member);
			global::Mono.Cecil.MetadataToken result;
			if (this.member_ref_map.TryGetValue(row, out result))
			{
				return result;
			}
			this.AddMemberReference(member, row);
			return member.token;
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x000189F9 File Offset: 0x00016BF9
		private global::Mono.Cecil.Metadata.Row<uint, uint, uint> CreateMemberRefRow(global::Mono.Cecil.MemberReference member)
		{
			return new global::Mono.Cecil.Metadata.Row<uint, uint, uint>(global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.GetTypeToken(member.DeclaringType), global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent), this.GetStringIndex(member.Name), this.GetBlobIndex(this.GetMemberRefSignature(member)));
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00018A2B File Offset: 0x00016C2B
		private void AddMemberReference(global::Mono.Cecil.MemberReference member, global::Mono.Cecil.Metadata.Row<uint, uint, uint> row)
		{
			member.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MemberRef, this.member_ref_table.AddRow(row));
			this.member_ref_map.Add(row, member.token);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00018A5C File Offset: 0x00016C5C
		private global::Mono.Cecil.MetadataToken GetMethodSpecToken(global::Mono.Cecil.MethodSpecification method_spec)
		{
			global::Mono.Cecil.Metadata.Row<uint, uint> row = this.CreateMethodSpecRow(method_spec);
			global::Mono.Cecil.MetadataToken result;
			if (this.method_spec_map.TryGetValue(row, out result))
			{
				return result;
			}
			this.AddMethodSpecification(method_spec, row);
			return method_spec.token;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00018A91 File Offset: 0x00016C91
		private void AddMethodSpecification(global::Mono.Cecil.MethodSpecification method_spec, global::Mono.Cecil.Metadata.Row<uint, uint> row)
		{
			method_spec.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MethodSpec, this.method_spec_table.AddRow(row));
			this.method_spec_map.Add(row, method_spec.token);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00018AC1 File Offset: 0x00016CC1
		private global::Mono.Cecil.Metadata.Row<uint, uint> CreateMethodSpecRow(global::Mono.Cecil.MethodSpecification method_spec)
		{
			return new global::Mono.Cecil.Metadata.Row<uint, uint>(global::Mono.Cecil.MetadataBuilder.MakeCodedRID(this.LookupToken(method_spec.ElementMethod), global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef), this.GetBlobIndex(this.GetMethodSpecSignature(method_spec)));
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00018AE7 File Offset: 0x00016CE7
		private global::Mono.Cecil.SignatureWriter CreateSignatureWriter()
		{
			return new global::Mono.Cecil.SignatureWriter(this);
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00018AF0 File Offset: 0x00016CF0
		private global::Mono.Cecil.SignatureWriter GetMethodSpecSignature(global::Mono.Cecil.MethodSpecification method_spec)
		{
			if (!method_spec.IsGenericInstance)
			{
				throw new global::System.NotSupportedException();
			}
			global::Mono.Cecil.GenericInstanceMethod instance = (global::Mono.Cecil.GenericInstanceMethod)method_spec;
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			signatureWriter.WriteByte(0xA);
			signatureWriter.WriteGenericInstanceSignature(instance);
			return signatureWriter;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00018B29 File Offset: 0x00016D29
		public uint AddStandAloneSignature(uint signature)
		{
			return (uint)this.standalone_sig_table.AddRow(signature);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00018B37 File Offset: 0x00016D37
		public uint GetLocalVariableBlobIndex(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables)
		{
			return this.GetBlobIndex(this.GetVariablesSignature(variables));
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00018B46 File Offset: 0x00016D46
		public uint GetCallSiteBlobIndex(global::Mono.Cecil.CallSite call_site)
		{
			return this.GetBlobIndex(this.GetMethodSignature(call_site));
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00018B58 File Offset: 0x00016D58
		private global::Mono.Cecil.SignatureWriter GetVariablesSignature(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			signatureWriter.WriteByte(7);
			signatureWriter.WriteCompressedUInt32((uint)variables.Count);
			for (int i = 0; i < variables.Count; i++)
			{
				signatureWriter.WriteTypeSignature(variables[i].VariableType);
			}
			return signatureWriter;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00018BA4 File Offset: 0x00016DA4
		private global::Mono.Cecil.SignatureWriter GetFieldSignature(global::Mono.Cecil.FieldReference field)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			signatureWriter.WriteByte(6);
			signatureWriter.WriteTypeSignature(field.FieldType);
			return signatureWriter;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00018BCC File Offset: 0x00016DCC
		private global::Mono.Cecil.SignatureWriter GetMethodSignature(global::Mono.Cecil.IMethodSignature method)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			signatureWriter.WriteMethodSignature(method);
			return signatureWriter;
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00018BE8 File Offset: 0x00016DE8
		private global::Mono.Cecil.SignatureWriter GetMemberRefSignature(global::Mono.Cecil.MemberReference member)
		{
			global::Mono.Cecil.FieldReference fieldReference = member as global::Mono.Cecil.FieldReference;
			if (fieldReference != null)
			{
				return this.GetFieldSignature(fieldReference);
			}
			global::Mono.Cecil.MethodReference methodReference = member as global::Mono.Cecil.MethodReference;
			if (methodReference != null)
			{
				return this.GetMethodSignature(methodReference);
			}
			throw new global::System.NotSupportedException();
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00018C20 File Offset: 0x00016E20
		private global::Mono.Cecil.SignatureWriter GetPropertySignature(global::Mono.Cecil.PropertyDefinition property)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			byte b = 8;
			if (property.HasThis)
			{
				b |= 0x20;
			}
			uint num = 0U;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> collection = null;
			if (property.HasParameters)
			{
				collection = property.Parameters;
				num = (uint)collection.Count;
			}
			signatureWriter.WriteByte(b);
			signatureWriter.WriteCompressedUInt32(num);
			signatureWriter.WriteTypeSignature(property.PropertyType);
			if (num == 0U)
			{
				return signatureWriter;
			}
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				signatureWriter.WriteTypeSignature(collection[num2].ParameterType);
				num2++;
			}
			return signatureWriter;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00018CA4 File Offset: 0x00016EA4
		private global::Mono.Cecil.SignatureWriter GetTypeSpecSignature(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			signatureWriter.WriteTypeSignature(type);
			return signatureWriter;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00018CC0 File Offset: 0x00016EC0
		private global::Mono.Cecil.SignatureWriter GetConstantSignature(global::Mono.Cecil.Metadata.ElementType type, object value)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			switch (type)
			{
			case global::Mono.Cecil.Metadata.ElementType.String:
				signatureWriter.WriteConstantString((string)value);
				return signatureWriter;
			case global::Mono.Cecil.Metadata.ElementType.Ptr:
			case global::Mono.Cecil.Metadata.ElementType.ByRef:
			case global::Mono.Cecil.Metadata.ElementType.ValueType:
				goto IL_5C;
			case global::Mono.Cecil.Metadata.ElementType.Class:
			case global::Mono.Cecil.Metadata.ElementType.Var:
			case global::Mono.Cecil.Metadata.ElementType.Array:
				break;
			default:
				switch (type)
				{
				case global::Mono.Cecil.Metadata.ElementType.Object:
				case global::Mono.Cecil.Metadata.ElementType.SzArray:
				case global::Mono.Cecil.Metadata.ElementType.MVar:
					break;
				default:
					goto IL_5C;
				}
				break;
			}
			signatureWriter.WriteInt32(0);
			return signatureWriter;
			IL_5C:
			signatureWriter.WriteConstantPrimitive(value);
			return signatureWriter;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00018D34 File Offset: 0x00016F34
		private global::Mono.Cecil.SignatureWriter GetCustomAttributeSignature(global::Mono.Cecil.CustomAttribute attribute)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			if (!attribute.resolved)
			{
				signatureWriter.WriteBytes(attribute.GetBlob());
				return signatureWriter;
			}
			signatureWriter.WriteUInt16(1);
			signatureWriter.WriteCustomAttributeConstructorArguments(attribute);
			signatureWriter.WriteCustomAttributeNamedArguments(attribute);
			return signatureWriter;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00018D74 File Offset: 0x00016F74
		private global::Mono.Cecil.SignatureWriter GetSecurityDeclarationSignature(global::Mono.Cecil.SecurityDeclaration declaration)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			if (!declaration.resolved)
			{
				signatureWriter.WriteBytes(declaration.GetBlob());
			}
			else if (this.module.Runtime < global::Mono.Cecil.TargetRuntime.Net_2_0)
			{
				signatureWriter.WriteXmlSecurityDeclaration(declaration);
			}
			else
			{
				signatureWriter.WriteSecurityDeclaration(declaration);
			}
			return signatureWriter;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00018DC0 File Offset: 0x00016FC0
		private global::Mono.Cecil.SignatureWriter GetMarshalInfoSignature(global::Mono.Cecil.IMarshalInfoProvider owner)
		{
			global::Mono.Cecil.SignatureWriter signatureWriter = this.CreateSignatureWriter();
			signatureWriter.WriteMarshalInfo(owner.MarshalInfo);
			return signatureWriter;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00018DE1 File Offset: 0x00016FE1
		private static global::System.Exception CreateForeignMemberException(global::Mono.Cecil.MemberReference member)
		{
			return new global::System.ArgumentException(string.Format("Member '{0}' is declared in another module and needs to be imported", member));
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00018DF4 File Offset: 0x00016FF4
		public global::Mono.Cecil.MetadataToken LookupToken(global::Mono.Cecil.IMetadataTokenProvider provider)
		{
			if (provider == null)
			{
				throw new global::System.ArgumentNullException();
			}
			global::Mono.Cecil.MemberReference memberReference = provider as global::Mono.Cecil.MemberReference;
			if (memberReference == null || memberReference.Module != this.module)
			{
				throw global::Mono.Cecil.MetadataBuilder.CreateForeignMemberException(memberReference);
			}
			global::Mono.Cecil.MetadataToken metadataToken = provider.MetadataToken;
			global::Mono.Cecil.TokenType tokenType = metadataToken.TokenType;
			if (tokenType <= global::Mono.Cecil.TokenType.MemberRef)
			{
				if (tokenType <= global::Mono.Cecil.TokenType.TypeDef)
				{
					if (tokenType == global::Mono.Cecil.TokenType.TypeRef)
					{
						goto IL_A9;
					}
					if (tokenType != global::Mono.Cecil.TokenType.TypeDef)
					{
						goto IL_CB;
					}
				}
				else if (tokenType != global::Mono.Cecil.TokenType.Field && tokenType != global::Mono.Cecil.TokenType.Method)
				{
					if (tokenType != global::Mono.Cecil.TokenType.MemberRef)
					{
						goto IL_CB;
					}
					return this.GetMemberRefToken(memberReference);
				}
			}
			else if (tokenType <= global::Mono.Cecil.TokenType.Property)
			{
				if (tokenType != global::Mono.Cecil.TokenType.Event && tokenType != global::Mono.Cecil.TokenType.Property)
				{
					goto IL_CB;
				}
			}
			else
			{
				if (tokenType == global::Mono.Cecil.TokenType.TypeSpec || tokenType == global::Mono.Cecil.TokenType.GenericParam)
				{
					goto IL_A9;
				}
				if (tokenType != global::Mono.Cecil.TokenType.MethodSpec)
				{
					goto IL_CB;
				}
				return this.GetMethodSpecToken((global::Mono.Cecil.MethodSpecification)provider);
			}
			return metadataToken;
			IL_A9:
			return this.GetTypeToken((global::Mono.Cecil.TypeReference)provider);
			IL_CB:
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005DF RID: 1503
		internal readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x040005E0 RID: 1504
		internal readonly global::Mono.Cecil.Cil.ISymbolWriterProvider symbol_writer_provider;

		// Token: 0x040005E1 RID: 1505
		internal readonly global::Mono.Cecil.Cil.ISymbolWriter symbol_writer;

		// Token: 0x040005E2 RID: 1506
		internal readonly global::Mono.Cecil.PE.TextMap text_map;

		// Token: 0x040005E3 RID: 1507
		internal readonly string fq_name;

		// Token: 0x040005E4 RID: 1508
		private readonly global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<uint, uint, uint>, global::Mono.Cecil.MetadataToken> type_ref_map;

		// Token: 0x040005E5 RID: 1509
		private readonly global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken> type_spec_map;

		// Token: 0x040005E6 RID: 1510
		private readonly global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<uint, uint, uint>, global::Mono.Cecil.MetadataToken> member_ref_map;

		// Token: 0x040005E7 RID: 1511
		private readonly global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Metadata.Row<uint, uint>, global::Mono.Cecil.MetadataToken> method_spec_map;

		// Token: 0x040005E8 RID: 1512
		private readonly global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> generic_parameters;

		// Token: 0x040005E9 RID: 1513
		private readonly global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.MetadataToken> method_def_map;

		// Token: 0x040005EA RID: 1514
		internal readonly global::Mono.Cecil.Cil.CodeWriter code;

		// Token: 0x040005EB RID: 1515
		internal readonly global::Mono.Cecil.Metadata.DataBuffer data;

		// Token: 0x040005EC RID: 1516
		internal readonly global::Mono.Cecil.Metadata.ResourceBuffer resources;

		// Token: 0x040005ED RID: 1517
		internal readonly global::Mono.Cecil.Metadata.StringHeapBuffer string_heap;

		// Token: 0x040005EE RID: 1518
		internal readonly global::Mono.Cecil.Metadata.UserStringHeapBuffer user_string_heap;

		// Token: 0x040005EF RID: 1519
		internal readonly global::Mono.Cecil.Metadata.BlobHeapBuffer blob_heap;

		// Token: 0x040005F0 RID: 1520
		internal readonly global::Mono.Cecil.Metadata.TableHeapBuffer table_heap;

		// Token: 0x040005F1 RID: 1521
		internal global::Mono.Cecil.MetadataToken entry_point;

		// Token: 0x040005F2 RID: 1522
		private uint type_rid = 1U;

		// Token: 0x040005F3 RID: 1523
		private uint field_rid = 1U;

		// Token: 0x040005F4 RID: 1524
		private uint method_rid = 1U;

		// Token: 0x040005F5 RID: 1525
		private uint param_rid = 1U;

		// Token: 0x040005F6 RID: 1526
		private uint property_rid = 1U;

		// Token: 0x040005F7 RID: 1527
		private uint event_rid = 1U;

		// Token: 0x040005F8 RID: 1528
		private readonly global::Mono.Cecil.TypeRefTable type_ref_table;

		// Token: 0x040005F9 RID: 1529
		private readonly global::Mono.Cecil.TypeDefTable type_def_table;

		// Token: 0x040005FA RID: 1530
		private readonly global::Mono.Cecil.FieldTable field_table;

		// Token: 0x040005FB RID: 1531
		private readonly global::Mono.Cecil.MethodTable method_table;

		// Token: 0x040005FC RID: 1532
		private readonly global::Mono.Cecil.ParamTable param_table;

		// Token: 0x040005FD RID: 1533
		private readonly global::Mono.Cecil.InterfaceImplTable iface_impl_table;

		// Token: 0x040005FE RID: 1534
		private readonly global::Mono.Cecil.MemberRefTable member_ref_table;

		// Token: 0x040005FF RID: 1535
		private readonly global::Mono.Cecil.ConstantTable constant_table;

		// Token: 0x04000600 RID: 1536
		private readonly global::Mono.Cecil.CustomAttributeTable custom_attribute_table;

		// Token: 0x04000601 RID: 1537
		private readonly global::Mono.Cecil.DeclSecurityTable declsec_table;

		// Token: 0x04000602 RID: 1538
		private readonly global::Mono.Cecil.StandAloneSigTable standalone_sig_table;

		// Token: 0x04000603 RID: 1539
		private readonly global::Mono.Cecil.EventMapTable event_map_table;

		// Token: 0x04000604 RID: 1540
		private readonly global::Mono.Cecil.EventTable event_table;

		// Token: 0x04000605 RID: 1541
		private readonly global::Mono.Cecil.PropertyMapTable property_map_table;

		// Token: 0x04000606 RID: 1542
		private readonly global::Mono.Cecil.PropertyTable property_table;

		// Token: 0x04000607 RID: 1543
		private readonly global::Mono.Cecil.TypeSpecTable typespec_table;

		// Token: 0x04000608 RID: 1544
		private readonly global::Mono.Cecil.MethodSpecTable method_spec_table;

		// Token: 0x04000609 RID: 1545
		internal readonly bool write_symbols;

		// Token: 0x020000EF RID: 239
		private sealed class GenericParameterComparer : global::System.Collections.Generic.IComparer<global::Mono.Cecil.GenericParameter>
		{
			// Token: 0x060008C9 RID: 2249 RVA: 0x00018ED4 File Offset: 0x000170D4
			public int Compare(global::Mono.Cecil.GenericParameter a, global::Mono.Cecil.GenericParameter b)
			{
				uint num = global::Mono.Cecil.MetadataBuilder.MakeCodedRID(a.Owner, global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef);
				uint num2 = global::Mono.Cecil.MetadataBuilder.MakeCodedRID(b.Owner, global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef);
				if (num == num2)
				{
					int position = a.Position;
					int position2 = b.Position;
					if (position == position2)
					{
						return 0;
					}
					if (position <= position2)
					{
						return -1;
					}
					return 1;
				}
				else
				{
					if (num <= num2)
					{
						return -1;
					}
					return 1;
				}
			}

			// Token: 0x060008CA RID: 2250 RVA: 0x00018F24 File Offset: 0x00017124
			public GenericParameterComparer()
			{
			}
		}
	}
}
