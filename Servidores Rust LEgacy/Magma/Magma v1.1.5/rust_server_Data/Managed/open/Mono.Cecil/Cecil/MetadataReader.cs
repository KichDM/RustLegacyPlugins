using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000F4 RID: 244
	internal sealed class MetadataReader : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0001A170 File Offset: 0x00018370
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x0001A178 File Offset: 0x00018378
		private uint Position
		{
			get
			{
				return (uint)this.position;
			}
			set
			{
				this.position = (int)value;
			}
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0001A184 File Offset: 0x00018384
		public MetadataReader(global::Mono.Cecil.ModuleDefinition module) : base(module.Image.MetadataSection.Data)
		{
			this.image = module.Image;
			this.module = module;
			this.metadata = module.MetadataSystem;
			this.code = new global::Mono.Cecil.Cil.CodeReader(this.image.MetadataSection, this);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0001A1DD File Offset: 0x000183DD
		private int GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex index)
		{
			return this.image.GetCodedIndexSize(index);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0001A1EB File Offset: 0x000183EB
		private uint ReadByIndexSize(int size)
		{
			if (size == 4)
			{
				return base.ReadUInt32();
			}
			return (uint)base.ReadUInt16();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0001A200 File Offset: 0x00018400
		private byte[] ReadBlob()
		{
			global::Mono.Cecil.Metadata.BlobHeap blobHeap = this.image.BlobHeap;
			if (blobHeap == null)
			{
				this.position += 2;
				return global::Mono.Empty<byte>.Array;
			}
			return blobHeap.Read(this.ReadBlobIndex());
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0001A23C File Offset: 0x0001843C
		private byte[] ReadBlob(uint signature)
		{
			global::Mono.Cecil.Metadata.BlobHeap blobHeap = this.image.BlobHeap;
			if (blobHeap == null)
			{
				return global::Mono.Empty<byte>.Array;
			}
			return blobHeap.Read(signature);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0001A268 File Offset: 0x00018468
		private uint ReadBlobIndex()
		{
			global::Mono.Cecil.Metadata.BlobHeap blobHeap = this.image.BlobHeap;
			return this.ReadByIndexSize((blobHeap != null) ? blobHeap.IndexSize : 2);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0001A293 File Offset: 0x00018493
		private string ReadString()
		{
			return this.image.StringHeap.Read(this.ReadByIndexSize(this.image.StringHeap.IndexSize));
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0001A2BB File Offset: 0x000184BB
		private uint ReadStringIndex()
		{
			return this.ReadByIndexSize(this.image.StringHeap.IndexSize);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0001A2D3 File Offset: 0x000184D3
		private uint ReadTableIndex(global::Mono.Cecil.Metadata.Table table)
		{
			return this.ReadByIndexSize(this.image.GetTableIndexSize(table));
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0001A2E7 File Offset: 0x000184E7
		private global::Mono.Cecil.MetadataToken ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex index)
		{
			return index.GetMetadataToken(this.ReadByIndexSize(this.GetCodedIndexSize(index)));
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0001A2FC File Offset: 0x000184FC
		private int MoveTo(global::Mono.Cecil.Metadata.Table table)
		{
			global::Mono.Cecil.Metadata.TableInformation tableInformation = this.image.TableHeap[table];
			if (tableInformation.Length != 0U)
			{
				this.Position = tableInformation.Offset;
			}
			return (int)tableInformation.Length;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0001A338 File Offset: 0x00018538
		private bool MoveTo(global::Mono.Cecil.Metadata.Table table, uint row)
		{
			global::Mono.Cecil.Metadata.TableInformation tableInformation = this.image.TableHeap[table];
			uint length = tableInformation.Length;
			if (length == 0U || row > length)
			{
				return false;
			}
			this.Position = tableInformation.Offset + tableInformation.RowSize * (row - 1U);
			return true;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0001A384 File Offset: 0x00018584
		public global::Mono.Cecil.AssemblyNameDefinition ReadAssemblyNameDefinition()
		{
			if (this.MoveTo(global::Mono.Cecil.Metadata.Table.Assembly) == 0)
			{
				return null;
			}
			global::Mono.Cecil.AssemblyNameDefinition assemblyNameDefinition = new global::Mono.Cecil.AssemblyNameDefinition();
			assemblyNameDefinition.HashAlgorithm = (global::Mono.Cecil.AssemblyHashAlgorithm)base.ReadUInt32();
			this.PopulateVersionAndFlags(assemblyNameDefinition);
			assemblyNameDefinition.PublicKey = this.ReadBlob();
			this.PopulateNameAndCulture(assemblyNameDefinition);
			return assemblyNameDefinition;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0001A3CC File Offset: 0x000185CC
		public global::Mono.Cecil.ModuleDefinition Populate(global::Mono.Cecil.ModuleDefinition module)
		{
			if (this.MoveTo(global::Mono.Cecil.Metadata.Table.Module) == 0)
			{
				return module;
			}
			base.Advance(2);
			module.Name = this.ReadString();
			module.Mvid = this.image.GuidHeap.Read(this.ReadByIndexSize(this.image.GuidHeap.IndexSize));
			return module;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0001A424 File Offset: 0x00018624
		private void InitializeAssemblyReferences()
		{
			if (this.metadata.AssemblyReferences != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.AssemblyRef);
			global::Mono.Cecil.AssemblyNameReference[] array = this.metadata.AssemblyReferences = new global::Mono.Cecil.AssemblyNameReference[num];
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)num))
			{
				global::Mono.Cecil.AssemblyNameReference assemblyNameReference = new global::Mono.Cecil.AssemblyNameReference();
				assemblyNameReference.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.AssemblyRef, num2 + 1U);
				this.PopulateVersionAndFlags(assemblyNameReference);
				byte[] array2 = this.ReadBlob();
				if (assemblyNameReference.HasPublicKey)
				{
					assemblyNameReference.PublicKey = array2;
				}
				else
				{
					assemblyNameReference.PublicKeyToken = array2;
				}
				this.PopulateNameAndCulture(assemblyNameReference);
				assemblyNameReference.Hash = this.ReadBlob();
				array[(int)((global::System.UIntPtr)num2)] = assemblyNameReference;
				num2 += 1U;
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0001A4C7 File Offset: 0x000186C7
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> ReadAssemblyReferences()
		{
			this.InitializeAssemblyReferences();
			return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference>(this.metadata.AssemblyReferences);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0001A4E0 File Offset: 0x000186E0
		public global::Mono.Cecil.MethodDefinition ReadEntryPoint()
		{
			if (this.module.Kind != global::Mono.Cecil.ModuleKind.Console && this.module.Kind != global::Mono.Cecil.ModuleKind.Windows)
			{
				return null;
			}
			global::Mono.Cecil.MetadataToken metadataToken = new global::Mono.Cecil.MetadataToken(this.module.Image.EntryPointToken);
			return this.GetMethodDefinition(metadataToken.RID);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0001A530 File Offset: 0x00018730
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> ReadModules()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition>(1);
			collection.Add(this.module);
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.File);
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				global::Mono.Cecil.FileAttributes fileAttributes = (global::Mono.Cecil.FileAttributes)base.ReadUInt32();
				string name = this.ReadString();
				this.ReadBlobIndex();
				if (fileAttributes == global::Mono.Cecil.FileAttributes.ContainsMetaData)
				{
					global::Mono.Cecil.ReaderParameters parameters = new global::Mono.Cecil.ReaderParameters
					{
						ReadingMode = this.module.ReadingMode,
						SymbolReaderProvider = this.module.SymbolReaderProvider
					};
					collection.Add(global::Mono.Cecil.ModuleDefinition.ReadModule(this.GetModuleFileName(name), parameters));
				}
				num2 += 1U;
			}
			return collection;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0001A5C8 File Offset: 0x000187C8
		private string GetModuleFileName(string name)
		{
			if (this.module.FullyQualifiedName == null)
			{
				throw new global::System.NotSupportedException();
			}
			string directoryName = global::System.IO.Path.GetDirectoryName(this.module.FullyQualifiedName);
			return global::System.IO.Path.Combine(directoryName, name);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0001A600 File Offset: 0x00018800
		private void InitializeModuleReferences()
		{
			if (this.metadata.ModuleReferences != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.ModuleRef);
			global::Mono.Cecil.ModuleReference[] array = this.metadata.ModuleReferences = new global::Mono.Cecil.ModuleReference[num];
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)num))
			{
				global::Mono.Cecil.ModuleReference moduleReference = new global::Mono.Cecil.ModuleReference(this.ReadString());
				moduleReference.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.ModuleRef, num2 + 1U);
				array[(int)((global::System.UIntPtr)num2)] = moduleReference;
				num2 += 1U;
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0001A66D File Offset: 0x0001886D
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference> ReadModuleReferences()
		{
			this.InitializeModuleReferences();
			return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference>(this.metadata.ModuleReferences);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0001A688 File Offset: 0x00018888
		public bool HasFileResource()
		{
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.File);
			if (num == 0)
			{
				return false;
			}
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				if (this.ReadFileRecord(num2).Col1 == global::Mono.Cecil.FileAttributes.ContainsNoMetaData)
				{
					return true;
				}
				num2 += 1U;
			}
			return false;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0001A6C4 File Offset: 0x000188C4
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource> ReadResources()
		{
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.ManifestResource);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Resource>(num);
			for (int i = 1; i <= num; i++)
			{
				uint offset = base.ReadUInt32();
				global::Mono.Cecil.ManifestResourceAttributes manifestResourceAttributes = (global::Mono.Cecil.ManifestResourceAttributes)base.ReadUInt32();
				string name = this.ReadString();
				global::Mono.Cecil.MetadataToken scope = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.Implementation);
				global::Mono.Cecil.Resource item;
				if (scope.RID == 0U)
				{
					item = new global::Mono.Cecil.EmbeddedResource(name, manifestResourceAttributes, offset, this);
				}
				else if (scope.TokenType == global::Mono.Cecil.TokenType.AssemblyRef)
				{
					item = new global::Mono.Cecil.AssemblyLinkedResource(name, manifestResourceAttributes)
					{
						Assembly = (global::Mono.Cecil.AssemblyNameReference)this.GetTypeReferenceScope(scope)
					};
				}
				else
				{
					if (scope.TokenType != global::Mono.Cecil.TokenType.File)
					{
						throw new global::System.NotSupportedException();
					}
					global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, string, uint> row = this.ReadFileRecord(scope.RID);
					item = new global::Mono.Cecil.LinkedResource(name, manifestResourceAttributes)
					{
						File = row.Col2,
						hash = this.ReadBlob(row.Col3)
					};
				}
				collection.Add(item);
			}
			return collection;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x0001A7C4 File Offset: 0x000189C4
		private global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, string, uint> ReadFileRecord(uint rid)
		{
			int position = this.position;
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.File, rid))
			{
				throw new global::System.ArgumentException();
			}
			global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, string, uint> result = new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, string, uint>((global::Mono.Cecil.FileAttributes)base.ReadUInt32(), this.ReadString(), this.ReadBlobIndex());
			this.position = position;
			return result;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0001A80C File Offset: 0x00018A0C
		public global::System.IO.MemoryStream GetManagedResourceStream(uint offset)
		{
			uint virtualAddress = this.image.Resources.VirtualAddress;
			global::Mono.Cecil.PE.Section sectionAtVirtualAddress = this.image.GetSectionAtVirtualAddress(virtualAddress);
			uint num = virtualAddress - sectionAtVirtualAddress.VirtualAddress + offset;
			byte[] data = sectionAtVirtualAddress.Data;
			int count = (int)data[(int)((global::System.UIntPtr)num)] | (int)data[(int)((global::System.UIntPtr)(num + 1U))] << 8 | (int)data[(int)((global::System.UIntPtr)(num + 2U))] << 0x10 | (int)data[(int)((global::System.UIntPtr)(num + 3U))] << 0x18;
			return new global::System.IO.MemoryStream(data, (int)(num + 4U), count);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0001A877 File Offset: 0x00018A77
		private void PopulateVersionAndFlags(global::Mono.Cecil.AssemblyNameReference name)
		{
			name.Version = new global::System.Version((int)base.ReadUInt16(), (int)base.ReadUInt16(), (int)base.ReadUInt16(), (int)base.ReadUInt16());
			name.Attributes = (global::Mono.Cecil.AssemblyAttributes)base.ReadUInt32();
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0001A8A8 File Offset: 0x00018AA8
		private void PopulateNameAndCulture(global::Mono.Cecil.AssemblyNameReference name)
		{
			name.Name = this.ReadString();
			name.Culture = this.ReadString();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0001A8C4 File Offset: 0x00018AC4
		public global::Mono.Cecil.TypeDefinitionCollection ReadTypes()
		{
			this.InitializeTypeDefinitions();
			global::Mono.Cecil.TypeDefinition[] types = this.metadata.Types;
			int capacity = types.Length - this.metadata.NestedTypes.Count;
			global::Mono.Cecil.TypeDefinitionCollection typeDefinitionCollection = new global::Mono.Cecil.TypeDefinitionCollection(this.module, capacity);
			foreach (global::Mono.Cecil.TypeDefinition typeDefinition in types)
			{
				if (!global::Mono.Cecil.MetadataReader.IsNested(typeDefinition.Attributes))
				{
					typeDefinitionCollection.Add(typeDefinition);
				}
			}
			if (this.image.HasTable(global::Mono.Cecil.Metadata.Table.MethodPtr) || this.image.HasTable(global::Mono.Cecil.Metadata.Table.FieldPtr))
			{
				this.CompleteTypes();
			}
			return typeDefinitionCollection;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0001A954 File Offset: 0x00018B54
		private void CompleteTypes()
		{
			foreach (global::Mono.Cecil.TypeDefinition typeDefinition in this.metadata.Types)
			{
				global::Mono.Cecil.MetadataReader.InitializeCollection(typeDefinition.Fields);
				global::Mono.Cecil.MetadataReader.InitializeCollection(typeDefinition.Methods);
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0001A998 File Offset: 0x00018B98
		private void InitializeTypeDefinitions()
		{
			if (this.metadata.Types != null)
			{
				return;
			}
			this.InitializeNestedTypes();
			this.InitializeFields();
			this.InitializeMethods();
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.TypeDef);
			global::Mono.Cecil.TypeDefinition[] array = this.metadata.Types = new global::Mono.Cecil.TypeDefinition[num];
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)num))
			{
				if (array[(int)((global::System.UIntPtr)num2)] == null)
				{
					array[(int)((global::System.UIntPtr)num2)] = this.ReadType(num2 + 1U);
				}
				num2 += 1U;
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0001AA04 File Offset: 0x00018C04
		private static bool IsNested(global::Mono.Cecil.TypeAttributes attributes)
		{
			switch (attributes & global::Mono.Cecil.TypeAttributes.VisibilityMask)
			{
			case global::Mono.Cecil.TypeAttributes.NestedPublic:
			case global::Mono.Cecil.TypeAttributes.NestedPrivate:
			case global::Mono.Cecil.TypeAttributes.NestedFamily:
			case global::Mono.Cecil.TypeAttributes.NestedAssembly:
			case global::Mono.Cecil.TypeAttributes.NestedFamANDAssem:
			case global::Mono.Cecil.TypeAttributes.VisibilityMask:
				return true;
			default:
				return false;
			}
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0001AA3C File Offset: 0x00018C3C
		public bool HasNestedTypes(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeNestedTypes();
			uint[] array;
			return this.metadata.TryGetNestedTypeMapping(type, out array) && array.Length > 0;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0001AA68 File Offset: 0x00018C68
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> ReadNestedTypes(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeNestedTypes();
			uint[] array;
			if (!this.metadata.TryGetNestedTypeMapping(type, out array))
			{
				return new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.TypeDefinition>(type);
			}
			global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.TypeDefinition> memberDefinitionCollection = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.TypeDefinition>(type, array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				memberDefinitionCollection.Add(this.GetTypeDefinition(array[i]));
			}
			this.metadata.RemoveNestedTypeMapping(type);
			return memberDefinitionCollection;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0001AAC8 File Offset: 0x00018CC8
		private void InitializeNestedTypes()
		{
			if (this.metadata.NestedTypes != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.NestedClass);
			this.metadata.NestedTypes = new global::System.Collections.Generic.Dictionary<uint, uint[]>(num);
			this.metadata.ReverseNestedTypes = new global::System.Collections.Generic.Dictionary<uint, uint>(num);
			if (num == 0)
			{
				return;
			}
			for (int i = 1; i <= num; i++)
			{
				uint nested = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				uint declaring = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				this.AddNestedMapping(declaring, nested);
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0001AB36 File Offset: 0x00018D36
		private void AddNestedMapping(uint declaring, uint nested)
		{
			this.metadata.SetNestedTypeMapping(declaring, global::Mono.Cecil.MetadataReader.AddMapping<uint, uint>(this.metadata.NestedTypes, declaring, nested));
			this.metadata.SetReverseNestedTypeMapping(nested, declaring);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0001AB64 File Offset: 0x00018D64
		private static TValue[] AddMapping<TKey, TValue>(global::System.Collections.Generic.Dictionary<TKey, TValue[]> cache, TKey key, TValue value)
		{
			TValue[] array;
			if (!cache.TryGetValue(key, out array))
			{
				array = new TValue[]
				{
					value
				};
				return array;
			}
			TValue[] array2 = new TValue[array.Length + 1];
			global::System.Array.Copy(array, array2, array.Length);
			array2[array.Length] = value;
			return array2;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0001ABB0 File Offset: 0x00018DB0
		private global::Mono.Cecil.TypeDefinition ReadType(uint rid)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.TypeDef, rid))
			{
				return null;
			}
			global::Mono.Cecil.TypeAttributes attributes = (global::Mono.Cecil.TypeAttributes)base.ReadUInt32();
			string name = this.ReadString();
			string @namespace = this.ReadString();
			global::Mono.Cecil.TypeDefinition typeDefinition = new global::Mono.Cecil.TypeDefinition(@namespace, name, attributes);
			typeDefinition.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeDef, rid);
			typeDefinition.scope = this.module;
			typeDefinition.module = this.module;
			this.metadata.AddTypeDefinition(typeDefinition);
			this.context = typeDefinition;
			typeDefinition.BaseType = this.GetTypeDefOrRef(this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef));
			typeDefinition.fields_range = this.ReadFieldsRange(rid);
			typeDefinition.methods_range = this.ReadMethodsRange(rid);
			if (global::Mono.Cecil.MetadataReader.IsNested(attributes))
			{
				typeDefinition.DeclaringType = this.GetNestedTypeDeclaringType(typeDefinition);
			}
			return typeDefinition;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001AC68 File Offset: 0x00018E68
		private global::Mono.Cecil.TypeDefinition GetNestedTypeDeclaringType(global::Mono.Cecil.TypeDefinition type)
		{
			uint rid;
			if (!this.metadata.TryGetReverseNestedTypeMapping(type, out rid))
			{
				return null;
			}
			this.metadata.RemoveReverseNestedTypeMapping(type);
			return this.GetTypeDefinition(rid);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0001AC9A File Offset: 0x00018E9A
		private global::Mono.Cecil.Range ReadFieldsRange(uint type_index)
		{
			return this.ReadListRange(type_index, global::Mono.Cecil.Metadata.Table.TypeDef, global::Mono.Cecil.Metadata.Table.Field);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0001ACA5 File Offset: 0x00018EA5
		private global::Mono.Cecil.Range ReadMethodsRange(uint type_index)
		{
			return this.ReadListRange(type_index, global::Mono.Cecil.Metadata.Table.TypeDef, global::Mono.Cecil.Metadata.Table.Method);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0001ACB0 File Offset: 0x00018EB0
		private global::Mono.Cecil.Range ReadListRange(uint current_index, global::Mono.Cecil.Metadata.Table current, global::Mono.Cecil.Metadata.Table target)
		{
			global::Mono.Cecil.Range result = default(global::Mono.Cecil.Range);
			result.Start = this.ReadTableIndex(target);
			global::Mono.Cecil.Metadata.TableInformation tableInformation = this.image.TableHeap[current];
			uint num;
			if (current_index == tableInformation.Length)
			{
				num = this.image.TableHeap[target].Length + 1U;
			}
			else
			{
				uint position = this.Position;
				this.Position += (uint)((ulong)tableInformation.RowSize - (ulong)((long)this.image.GetTableIndexSize(target)));
				num = this.ReadTableIndex(target);
				this.Position = position;
			}
			result.Length = num - result.Start;
			return result;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0001AD58 File Offset: 0x00018F58
		public global::Mono.Cecil.Metadata.Row<short, int> ReadTypeLayout(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeTypeLayouts();
			uint rid = type.token.RID;
			global::Mono.Cecil.Metadata.Row<ushort, uint> row;
			if (!this.metadata.ClassLayouts.TryGetValue(rid, out row))
			{
				return new global::Mono.Cecil.Metadata.Row<short, int>(-1, -1);
			}
			type.PackingSize = (short)row.Col1;
			type.ClassSize = (int)row.Col2;
			this.metadata.ClassLayouts.Remove(rid);
			return new global::Mono.Cecil.Metadata.Row<short, int>((short)row.Col1, (int)row.Col2);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001ADD8 File Offset: 0x00018FD8
		private void InitializeTypeLayouts()
		{
			if (this.metadata.ClassLayouts != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.ClassLayout);
			global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<ushort, uint>> dictionary = this.metadata.ClassLayouts = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<ushort, uint>>(num);
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)num))
			{
				ushort col = base.ReadUInt16();
				uint col2 = base.ReadUInt32();
				uint key = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				dictionary.Add(key, new global::Mono.Cecil.Metadata.Row<ushort, uint>(col, col2));
				num2 += 1U;
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0001AE49 File Offset: 0x00019049
		public global::Mono.Cecil.TypeReference GetTypeDefOrRef(global::Mono.Cecil.MetadataToken token)
		{
			return (global::Mono.Cecil.TypeReference)this.LookupToken(token);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0001AE58 File Offset: 0x00019058
		public global::Mono.Cecil.TypeDefinition GetTypeDefinition(uint rid)
		{
			this.InitializeTypeDefinitions();
			global::Mono.Cecil.TypeDefinition typeDefinition = this.metadata.GetTypeDefinition(rid);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
			return this.ReadTypeDefinition(rid);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0001AE84 File Offset: 0x00019084
		private global::Mono.Cecil.TypeDefinition ReadTypeDefinition(uint rid)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.TypeDef, rid))
			{
				return null;
			}
			return this.ReadType(rid);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0001AE99 File Offset: 0x00019099
		private void InitializeTypeReferences()
		{
			if (this.metadata.TypeReferences != null)
			{
				return;
			}
			this.metadata.TypeReferences = new global::Mono.Cecil.TypeReference[this.image.GetTableLength(global::Mono.Cecil.Metadata.Table.TypeRef)];
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0001AEC8 File Offset: 0x000190C8
		public global::Mono.Cecil.TypeReference GetTypeReference(string scope, string full_name)
		{
			this.InitializeTypeReferences();
			int num = this.metadata.TypeReferences.Length;
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				global::Mono.Cecil.TypeReference typeReference = this.GetTypeReference(num2);
				if (!(typeReference.FullName != full_name))
				{
					if (string.IsNullOrEmpty(scope))
					{
						return typeReference;
					}
					if (typeReference.Scope.Name == scope)
					{
						return typeReference;
					}
				}
				num2 += 1U;
			}
			return null;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0001AF30 File Offset: 0x00019130
		private global::Mono.Cecil.TypeReference GetTypeReference(uint rid)
		{
			this.InitializeTypeReferences();
			global::Mono.Cecil.TypeReference typeReference = this.metadata.GetTypeReference(rid);
			if (typeReference != null)
			{
				return typeReference;
			}
			return this.ReadTypeReference(rid);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001AF5C File Offset: 0x0001915C
		private global::Mono.Cecil.TypeReference ReadTypeReference(uint rid)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.TypeRef, rid))
			{
				return null;
			}
			global::Mono.Cecil.TypeReference typeReference = null;
			global::Mono.Cecil.MetadataToken metadataToken = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope);
			string name = this.ReadString();
			string @namespace = this.ReadString();
			global::Mono.Cecil.TypeReference typeReference2 = new global::Mono.Cecil.TypeReference(@namespace, name, this.module, null);
			typeReference2.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeRef, rid);
			this.metadata.AddTypeReference(typeReference2);
			global::Mono.Cecil.IMetadataScope scope;
			if (metadataToken.TokenType == global::Mono.Cecil.TokenType.TypeRef)
			{
				typeReference = this.GetTypeDefOrRef(metadataToken);
				scope = ((typeReference != null) ? typeReference.Scope : this.module);
			}
			else
			{
				scope = this.GetTypeReferenceScope(metadataToken);
			}
			typeReference2.scope = scope;
			typeReference2.DeclaringType = typeReference;
			global::Mono.Cecil.MetadataSystem.TryProcessPrimitiveType(typeReference2);
			return typeReference2;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001B00C File Offset: 0x0001920C
		private global::Mono.Cecil.IMetadataScope GetTypeReferenceScope(global::Mono.Cecil.MetadataToken scope)
		{
			global::Mono.Cecil.TokenType tokenType = scope.TokenType;
			if (tokenType == global::Mono.Cecil.TokenType.Module)
			{
				return this.module;
			}
			if (tokenType == global::Mono.Cecil.TokenType.ModuleRef)
			{
				this.InitializeModuleReferences();
				return this.metadata.ModuleReferences[(int)(scope.RID - 1U)];
			}
			if (tokenType == global::Mono.Cecil.TokenType.AssemblyRef)
			{
				this.InitializeAssemblyReferences();
				return this.metadata.AssemblyReferences[(int)(scope.RID - 1U)];
			}
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0001B07C File Offset: 0x0001927C
		public global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.TypeReference> GetTypeReferences()
		{
			this.InitializeTypeReferences();
			int tableLength = this.image.GetTableLength(global::Mono.Cecil.Metadata.Table.TypeRef);
			global::Mono.Cecil.TypeReference[] array = new global::Mono.Cecil.TypeReference[tableLength];
			uint num = 1U;
			while ((ulong)num <= (ulong)((long)tableLength))
			{
				array[(int)((global::System.UIntPtr)(num - 1U))] = this.GetTypeReference(num);
				num += 1U;
			}
			return array;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001B0C0 File Offset: 0x000192C0
		private global::Mono.Cecil.TypeReference GetTypeSpecification(uint rid)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.TypeSpec, rid))
			{
				return null;
			}
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(this.ReadBlobIndex());
			global::Mono.Cecil.TypeReference typeReference = signatureReader.ReadTypeSignature();
			if (typeReference.token.RID == 0U)
			{
				typeReference.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.TypeSpec, rid);
			}
			return typeReference;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0001B10D File Offset: 0x0001930D
		private global::Mono.Cecil.SignatureReader ReadSignature(uint signature)
		{
			return new global::Mono.Cecil.SignatureReader(signature, this);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0001B118 File Offset: 0x00019318
		public bool HasInterfaces(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeInterfaces();
			global::Mono.Cecil.MetadataToken[] array;
			return this.metadata.TryGetInterfaceMapping(type, out array);
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0001B13C File Offset: 0x0001933C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> ReadInterfaces(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeInterfaces();
			global::Mono.Cecil.MetadataToken[] array;
			if (!this.metadata.TryGetInterfaceMapping(type, out array))
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>();
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>(array.Length);
			this.context = type;
			for (int i = 0; i < array.Length; i++)
			{
				collection.Add(this.GetTypeDefOrRef(array[i]));
			}
			this.metadata.RemoveInterfaceMapping(type);
			return collection;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0001B1A8 File Offset: 0x000193A8
		private void InitializeInterfaces()
		{
			if (this.metadata.Interfaces != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.InterfaceImpl);
			this.metadata.Interfaces = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken[]>(num);
			for (int i = 0; i < num; i++)
			{
				uint type = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				global::Mono.Cecil.MetadataToken @interface = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
				this.AddInterfaceMapping(type, @interface);
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0001B201 File Offset: 0x00019401
		private void AddInterfaceMapping(uint type, global::Mono.Cecil.MetadataToken @interface)
		{
			this.metadata.SetInterfaceMapping(type, global::Mono.Cecil.MetadataReader.AddMapping<uint, global::Mono.Cecil.MetadataToken>(this.metadata.Interfaces, type, @interface));
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0001B224 File Offset: 0x00019424
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> ReadFields(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Cecil.Range fields_range = type.fields_range;
			if (fields_range.Length == 0U)
			{
				return new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.FieldDefinition>(type);
			}
			global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.FieldDefinition> memberDefinitionCollection = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.FieldDefinition>(type, (int)fields_range.Length);
			this.context = type;
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.FieldPtr, fields_range.Start))
			{
				if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.Field, fields_range.Start))
				{
					return memberDefinitionCollection;
				}
				for (uint num = 0U; num < fields_range.Length; num += 1U)
				{
					this.ReadField(fields_range.Start + num, memberDefinitionCollection);
				}
			}
			else
			{
				this.ReadPointers<global::Mono.Cecil.FieldDefinition>(global::Mono.Cecil.Metadata.Table.FieldPtr, global::Mono.Cecil.Metadata.Table.Field, fields_range, memberDefinitionCollection, new global::System.Action<uint, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition>>(this.ReadField));
			}
			return memberDefinitionCollection;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0001B2BC File Offset: 0x000194BC
		private void ReadField(uint field_rid, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields)
		{
			global::Mono.Cecil.FieldAttributes attributes = (global::Mono.Cecil.FieldAttributes)base.ReadUInt16();
			string name = this.ReadString();
			uint signature = this.ReadBlobIndex();
			global::Mono.Cecil.FieldDefinition fieldDefinition = new global::Mono.Cecil.FieldDefinition(name, attributes, this.ReadFieldType(signature));
			fieldDefinition.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Field, field_rid);
			this.metadata.AddFieldDefinition(fieldDefinition);
			if (global::Mono.Cecil.MetadataReader.IsDeleted(fieldDefinition))
			{
				return;
			}
			fields.Add(fieldDefinition);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0001B31A File Offset: 0x0001951A
		private void InitializeFields()
		{
			if (this.metadata.Fields != null)
			{
				return;
			}
			this.metadata.Fields = new global::Mono.Cecil.FieldDefinition[this.image.GetTableLength(global::Mono.Cecil.Metadata.Table.Field)];
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0001B348 File Offset: 0x00019548
		private global::Mono.Cecil.TypeReference ReadFieldType(uint signature)
		{
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			if (signatureReader.ReadByte() != 6)
			{
				throw new global::System.NotSupportedException();
			}
			return signatureReader.ReadTypeSignature();
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0001B374 File Offset: 0x00019574
		public int ReadFieldRVA(global::Mono.Cecil.FieldDefinition field)
		{
			this.InitializeFieldRVAs();
			uint rid = field.token.RID;
			uint num;
			if (!this.metadata.FieldRVAs.TryGetValue(rid, out num))
			{
				return 0;
			}
			int fieldTypeSize = global::Mono.Cecil.MetadataReader.GetFieldTypeSize(field.FieldType);
			if (fieldTypeSize == 0 || num == 0U)
			{
				return 0;
			}
			this.metadata.FieldRVAs.Remove(rid);
			field.InitialValue = this.GetFieldInitializeValue(fieldTypeSize, num);
			return (int)num;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0001B3E0 File Offset: 0x000195E0
		private byte[] GetFieldInitializeValue(int size, uint rva)
		{
			global::Mono.Cecil.PE.Section sectionAtVirtualAddress = this.image.GetSectionAtVirtualAddress(rva);
			if (sectionAtVirtualAddress == null)
			{
				return global::Mono.Empty<byte>.Array;
			}
			byte[] array = new byte[size];
			global::System.Buffer.BlockCopy(sectionAtVirtualAddress.Data, (int)(rva - sectionAtVirtualAddress.VirtualAddress), array, 0, size);
			return array;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0001B424 File Offset: 0x00019624
		private static int GetFieldTypeSize(global::Mono.Cecil.TypeReference type)
		{
			int result = 0;
			switch (type.etype)
			{
			case global::Mono.Cecil.Metadata.ElementType.Boolean:
			case global::Mono.Cecil.Metadata.ElementType.I1:
			case global::Mono.Cecil.Metadata.ElementType.U1:
				return 1;
			case global::Mono.Cecil.Metadata.ElementType.Char:
			case global::Mono.Cecil.Metadata.ElementType.I2:
			case global::Mono.Cecil.Metadata.ElementType.U2:
				return 2;
			case global::Mono.Cecil.Metadata.ElementType.I4:
			case global::Mono.Cecil.Metadata.ElementType.U4:
			case global::Mono.Cecil.Metadata.ElementType.R4:
				return 4;
			case global::Mono.Cecil.Metadata.ElementType.I8:
			case global::Mono.Cecil.Metadata.ElementType.U8:
			case global::Mono.Cecil.Metadata.ElementType.R8:
				return 8;
			case global::Mono.Cecil.Metadata.ElementType.Ptr:
			case global::Mono.Cecil.Metadata.ElementType.FnPtr:
				return global::System.IntPtr.Size;
			case global::Mono.Cecil.Metadata.ElementType.CModReqD:
			case global::Mono.Cecil.Metadata.ElementType.CModOpt:
				return global::Mono.Cecil.MetadataReader.GetFieldTypeSize(((global::Mono.Cecil.IModifierType)type).ElementType);
			}
			global::Mono.Cecil.TypeDefinition typeDefinition = type.CheckedResolve();
			if (typeDefinition.HasLayoutInfo)
			{
				result = typeDefinition.ClassSize;
			}
			return result;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0001B500 File Offset: 0x00019700
		private void InitializeFieldRVAs()
		{
			if (this.metadata.FieldRVAs != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.FieldRVA);
			global::System.Collections.Generic.Dictionary<uint, uint> dictionary = this.metadata.FieldRVAs = new global::System.Collections.Generic.Dictionary<uint, uint>(num);
			for (int i = 0; i < num; i++)
			{
				uint value = base.ReadUInt32();
				uint key = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.Field);
				dictionary.Add(key, value);
			}
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0001B560 File Offset: 0x00019760
		public int ReadFieldLayout(global::Mono.Cecil.FieldDefinition field)
		{
			this.InitializeFieldLayouts();
			uint rid = field.token.RID;
			uint result;
			if (!this.metadata.FieldLayouts.TryGetValue(rid, out result))
			{
				return -1;
			}
			this.metadata.FieldLayouts.Remove(rid);
			return (int)result;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0001B5AC File Offset: 0x000197AC
		private void InitializeFieldLayouts()
		{
			if (this.metadata.FieldLayouts != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.FieldLayout);
			global::System.Collections.Generic.Dictionary<uint, uint> dictionary = this.metadata.FieldLayouts = new global::System.Collections.Generic.Dictionary<uint, uint>(num);
			for (int i = 0; i < num; i++)
			{
				uint value = base.ReadUInt32();
				uint key = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.Field);
				dictionary.Add(key, value);
			}
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0001B60C File Offset: 0x0001980C
		public bool HasEvents(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeEvents();
			global::Mono.Cecil.Range range;
			return this.metadata.TryGetEventsRange(type, out range) && range.Length > 0U;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0001B63C File Offset: 0x0001983C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> ReadEvents(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeEvents();
			global::Mono.Cecil.Range range;
			if (!this.metadata.TryGetEventsRange(type, out range))
			{
				return new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.EventDefinition>(type);
			}
			global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.EventDefinition> memberDefinitionCollection = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.EventDefinition>(type, (int)range.Length);
			this.metadata.RemoveEventsRange(type);
			if (range.Length == 0U)
			{
				return memberDefinitionCollection;
			}
			this.context = type;
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.EventPtr, range.Start))
			{
				if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.Event, range.Start))
				{
					return memberDefinitionCollection;
				}
				for (uint num = 0U; num < range.Length; num += 1U)
				{
					this.ReadEvent(range.Start + num, memberDefinitionCollection);
				}
			}
			else
			{
				this.ReadPointers<global::Mono.Cecil.EventDefinition>(global::Mono.Cecil.Metadata.Table.EventPtr, global::Mono.Cecil.Metadata.Table.Event, range, memberDefinitionCollection, new global::System.Action<uint, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition>>(this.ReadEvent));
			}
			return memberDefinitionCollection;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0001B6F4 File Offset: 0x000198F4
		private void ReadEvent(uint event_rid, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> events)
		{
			global::Mono.Cecil.EventAttributes attributes = (global::Mono.Cecil.EventAttributes)base.ReadUInt16();
			string name = this.ReadString();
			global::Mono.Cecil.TypeReference typeDefOrRef = this.GetTypeDefOrRef(this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef));
			global::Mono.Cecil.EventDefinition eventDefinition = new global::Mono.Cecil.EventDefinition(name, attributes, typeDefOrRef);
			eventDefinition.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Event, event_rid);
			if (global::Mono.Cecil.MetadataReader.IsDeleted(eventDefinition))
			{
				return;
			}
			events.Add(eventDefinition);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0001B748 File Offset: 0x00019948
		private void InitializeEvents()
		{
			if (this.metadata.Events != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.EventMap);
			this.metadata.Events = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Range>(num);
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				uint type_rid = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				global::Mono.Cecil.Range range = this.ReadEventsRange(num2);
				this.metadata.AddEventsRange(type_rid, range);
				num2 += 1U;
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0001B7A8 File Offset: 0x000199A8
		private global::Mono.Cecil.Range ReadEventsRange(uint rid)
		{
			return this.ReadListRange(rid, global::Mono.Cecil.Metadata.Table.EventMap, global::Mono.Cecil.Metadata.Table.Event);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0001B7B8 File Offset: 0x000199B8
		public bool HasProperties(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeProperties();
			global::Mono.Cecil.Range range;
			return this.metadata.TryGetPropertiesRange(type, out range) && range.Length > 0U;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0001B7E8 File Offset: 0x000199E8
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> ReadProperties(global::Mono.Cecil.TypeDefinition type)
		{
			this.InitializeProperties();
			global::Mono.Cecil.Range range;
			if (!this.metadata.TryGetPropertiesRange(type, out range))
			{
				return new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.PropertyDefinition>(type);
			}
			this.metadata.RemovePropertiesRange(type);
			global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.PropertyDefinition> memberDefinitionCollection = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.PropertyDefinition>(type, (int)range.Length);
			if (range.Length == 0U)
			{
				return memberDefinitionCollection;
			}
			this.context = type;
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.PropertyPtr, range.Start))
			{
				if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.Property, range.Start))
				{
					return memberDefinitionCollection;
				}
				for (uint num = 0U; num < range.Length; num += 1U)
				{
					this.ReadProperty(range.Start + num, memberDefinitionCollection);
				}
			}
			else
			{
				this.ReadPointers<global::Mono.Cecil.PropertyDefinition>(global::Mono.Cecil.Metadata.Table.PropertyPtr, global::Mono.Cecil.Metadata.Table.Property, range, memberDefinitionCollection, new global::System.Action<uint, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition>>(this.ReadProperty));
			}
			return memberDefinitionCollection;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0001B8A0 File Offset: 0x00019AA0
		private void ReadProperty(uint property_rid, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> properties)
		{
			global::Mono.Cecil.PropertyAttributes attributes = (global::Mono.Cecil.PropertyAttributes)base.ReadUInt16();
			string name = this.ReadString();
			uint signature = this.ReadBlobIndex();
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			byte b = signatureReader.ReadByte();
			if ((b & 8) == 0)
			{
				throw new global::System.NotSupportedException();
			}
			bool hasThis = (b & 0x20) != 0;
			signatureReader.ReadCompressedUInt32();
			global::Mono.Cecil.PropertyDefinition propertyDefinition = new global::Mono.Cecil.PropertyDefinition(name, attributes, signatureReader.ReadTypeSignature());
			propertyDefinition.HasThis = hasThis;
			propertyDefinition.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Property, property_rid);
			if (global::Mono.Cecil.MetadataReader.IsDeleted(propertyDefinition))
			{
				return;
			}
			properties.Add(propertyDefinition);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0001B930 File Offset: 0x00019B30
		private void InitializeProperties()
		{
			if (this.metadata.Properties != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.PropertyMap);
			this.metadata.Properties = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Range>(num);
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				uint type_rid = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				global::Mono.Cecil.Range range = this.ReadPropertiesRange(num2);
				this.metadata.AddPropertiesRange(type_rid, range);
				num2 += 1U;
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0001B990 File Offset: 0x00019B90
		private global::Mono.Cecil.Range ReadPropertiesRange(uint rid)
		{
			return this.ReadListRange(rid, global::Mono.Cecil.Metadata.Table.PropertyMap, global::Mono.Cecil.Metadata.Table.Property);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0001B9A0 File Offset: 0x00019BA0
		private global::Mono.Cecil.MethodSemanticsAttributes ReadMethodSemantics(global::Mono.Cecil.MethodDefinition method)
		{
			this.InitializeMethodSemantics();
			global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, global::Mono.Cecil.MetadataToken> row;
			if (!this.metadata.Semantics.TryGetValue(method.token.RID, out row))
			{
				return global::Mono.Cecil.MethodSemanticsAttributes.None;
			}
			global::Mono.Cecil.TypeDefinition declaringType = method.DeclaringType;
			global::Mono.Cecil.MethodSemanticsAttributes col = row.Col1;
			if (col <= global::Mono.Cecil.MethodSemanticsAttributes.AddOn)
			{
				switch (col)
				{
				case global::Mono.Cecil.MethodSemanticsAttributes.Setter:
					global::Mono.Cecil.MetadataReader.GetProperty(declaringType, row.Col2).set_method = method;
					goto IL_174;
				case global::Mono.Cecil.MethodSemanticsAttributes.Getter:
					global::Mono.Cecil.MetadataReader.GetProperty(declaringType, row.Col2).get_method = method;
					goto IL_174;
				case global::Mono.Cecil.MethodSemanticsAttributes.Setter | global::Mono.Cecil.MethodSemanticsAttributes.Getter:
					break;
				case global::Mono.Cecil.MethodSemanticsAttributes.Other:
				{
					global::Mono.Cecil.TokenType tokenType = row.Col2.TokenType;
					if (tokenType == global::Mono.Cecil.TokenType.Event)
					{
						global::Mono.Cecil.EventDefinition @event = global::Mono.Cecil.MetadataReader.GetEvent(declaringType, row.Col2);
						if (@event.other_methods == null)
						{
							@event.other_methods = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>();
						}
						@event.other_methods.Add(method);
						goto IL_174;
					}
					if (tokenType != global::Mono.Cecil.TokenType.Property)
					{
						throw new global::System.NotSupportedException();
					}
					global::Mono.Cecil.PropertyDefinition property = global::Mono.Cecil.MetadataReader.GetProperty(declaringType, row.Col2);
					if (property.other_methods == null)
					{
						property.other_methods = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>();
					}
					property.other_methods.Add(method);
					goto IL_174;
				}
				default:
					if (col == global::Mono.Cecil.MethodSemanticsAttributes.AddOn)
					{
						global::Mono.Cecil.MetadataReader.GetEvent(declaringType, row.Col2).add_method = method;
						goto IL_174;
					}
					break;
				}
			}
			else
			{
				if (col == global::Mono.Cecil.MethodSemanticsAttributes.RemoveOn)
				{
					global::Mono.Cecil.MetadataReader.GetEvent(declaringType, row.Col2).remove_method = method;
					goto IL_174;
				}
				if (col == global::Mono.Cecil.MethodSemanticsAttributes.Fire)
				{
					global::Mono.Cecil.MetadataReader.GetEvent(declaringType, row.Col2).invoke_method = method;
					goto IL_174;
				}
			}
			throw new global::System.NotSupportedException();
			IL_174:
			this.metadata.Semantics.Remove(method.token.RID);
			return row.Col1;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001BB44 File Offset: 0x00019D44
		private static global::Mono.Cecil.EventDefinition GetEvent(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataToken token)
		{
			if (token.TokenType != global::Mono.Cecil.TokenType.Event)
			{
				throw new global::System.ArgumentException();
			}
			return global::Mono.Cecil.MetadataReader.GetMember<global::Mono.Cecil.EventDefinition>(type.Events, token);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001BB66 File Offset: 0x00019D66
		private static global::Mono.Cecil.PropertyDefinition GetProperty(global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MetadataToken token)
		{
			if (token.TokenType != global::Mono.Cecil.TokenType.Property)
			{
				throw new global::System.ArgumentException();
			}
			return global::Mono.Cecil.MetadataReader.GetMember<global::Mono.Cecil.PropertyDefinition>(type.Properties, token);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001BB88 File Offset: 0x00019D88
		private static TMember GetMember<TMember>(global::Mono.Collections.Generic.Collection<TMember> members, global::Mono.Cecil.MetadataToken token) where TMember : global::Mono.Cecil.IMemberDefinition
		{
			for (int i = 0; i < members.Count; i++)
			{
				TMember result = members[i];
				if (result.MetadataToken == token)
				{
					return result;
				}
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001BBCC File Offset: 0x00019DCC
		private void InitializeMethodSemantics()
		{
			if (this.metadata.Semantics != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.MethodSemantics);
			global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, global::Mono.Cecil.MetadataToken>> dictionary = this.metadata.Semantics = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, global::Mono.Cecil.MetadataToken>>(0);
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)num))
			{
				global::Mono.Cecil.MethodSemanticsAttributes col = (global::Mono.Cecil.MethodSemanticsAttributes)base.ReadUInt16();
				uint key = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.Method);
				global::Mono.Cecil.MetadataToken col2 = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasSemantics);
				dictionary[key] = new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, global::Mono.Cecil.MetadataToken>(col, col2);
				num2 += 1U;
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001BC3E File Offset: 0x00019E3E
		public global::Mono.Cecil.PropertyDefinition ReadMethods(global::Mono.Cecil.PropertyDefinition property)
		{
			this.ReadAllSemantics(property.DeclaringType);
			return property;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0001BC4D File Offset: 0x00019E4D
		public global::Mono.Cecil.EventDefinition ReadMethods(global::Mono.Cecil.EventDefinition @event)
		{
			this.ReadAllSemantics(@event.DeclaringType);
			return @event;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001BC5C File Offset: 0x00019E5C
		public global::Mono.Cecil.MethodSemanticsAttributes ReadAllSemantics(global::Mono.Cecil.MethodDefinition method)
		{
			this.ReadAllSemantics(method.DeclaringType);
			return method.SemanticsAttributes;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0001BC70 File Offset: 0x00019E70
		private void ReadAllSemantics(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods = type.Methods;
			for (int i = 0; i < methods.Count; i++)
			{
				global::Mono.Cecil.MethodDefinition methodDefinition = methods[i];
				if (methodDefinition.sem_attrs == null)
				{
					methodDefinition.sem_attrs = new global::Mono.Cecil.MethodSemanticsAttributes?(this.ReadMethodSemantics(methodDefinition));
				}
			}
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0001BCBC File Offset: 0x00019EBC
		private global::Mono.Cecil.Range ReadParametersRange(uint method_rid)
		{
			return this.ReadListRange(method_rid, global::Mono.Cecil.Metadata.Table.Method, global::Mono.Cecil.Metadata.Table.Param);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0001BCC8 File Offset: 0x00019EC8
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> ReadMethods(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Cecil.Range methods_range = type.methods_range;
			if (methods_range.Length == 0U)
			{
				return new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.MethodDefinition>(type);
			}
			global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.MethodDefinition> memberDefinitionCollection = new global::Mono.Cecil.MemberDefinitionCollection<global::Mono.Cecil.MethodDefinition>(type, (int)methods_range.Length);
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.MethodPtr, methods_range.Start))
			{
				if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.Method, methods_range.Start))
				{
					return memberDefinitionCollection;
				}
				for (uint num = 0U; num < methods_range.Length; num += 1U)
				{
					this.ReadMethod(methods_range.Start + num, memberDefinitionCollection);
				}
			}
			else
			{
				this.ReadPointers<global::Mono.Cecil.MethodDefinition>(global::Mono.Cecil.Metadata.Table.MethodPtr, global::Mono.Cecil.Metadata.Table.Method, methods_range, memberDefinitionCollection, new global::System.Action<uint, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>>(this.ReadMethod));
			}
			return memberDefinitionCollection;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0001BD58 File Offset: 0x00019F58
		private void ReadPointers<TMember>(global::Mono.Cecil.Metadata.Table ptr, global::Mono.Cecil.Metadata.Table table, global::Mono.Cecil.Range range, global::Mono.Collections.Generic.Collection<TMember> members, global::System.Action<uint, global::Mono.Collections.Generic.Collection<TMember>> reader) where TMember : global::Mono.Cecil.IMemberDefinition
		{
			for (uint num = 0U; num < range.Length; num += 1U)
			{
				this.MoveTo(ptr, range.Start + num);
				uint num2 = this.ReadTableIndex(table);
				this.MoveTo(table, num2);
				reader(num2, members);
			}
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0001BDA3 File Offset: 0x00019FA3
		private static bool IsDeleted(global::Mono.Cecil.IMemberDefinition member)
		{
			return member.IsSpecialName && member.Name == "_Deleted";
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0001BDBF File Offset: 0x00019FBF
		private void InitializeMethods()
		{
			if (this.metadata.Methods != null)
			{
				return;
			}
			this.metadata.Methods = new global::Mono.Cecil.MethodDefinition[this.image.GetTableLength(global::Mono.Cecil.Metadata.Table.Method)];
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0001BDEC File Offset: 0x00019FEC
		private void ReadMethod(uint method_rid, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods)
		{
			global::Mono.Cecil.MethodDefinition methodDefinition = new global::Mono.Cecil.MethodDefinition();
			methodDefinition.rva = base.ReadUInt32();
			methodDefinition.ImplAttributes = (global::Mono.Cecil.MethodImplAttributes)base.ReadUInt16();
			methodDefinition.Attributes = (global::Mono.Cecil.MethodAttributes)base.ReadUInt16();
			methodDefinition.Name = this.ReadString();
			methodDefinition.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Method, method_rid);
			if (global::Mono.Cecil.MetadataReader.IsDeleted(methodDefinition))
			{
				return;
			}
			methods.Add(methodDefinition);
			uint signature = this.ReadBlobIndex();
			global::Mono.Cecil.Range param_range = this.ReadParametersRange(method_rid);
			this.context = methodDefinition;
			this.ReadMethodSignature(signature, methodDefinition);
			this.metadata.AddMethodDefinition(methodDefinition);
			if (param_range.Length == 0U)
			{
				return;
			}
			int position = this.position;
			this.ReadParameters(methodDefinition, param_range);
			this.position = position;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0001BE9C File Offset: 0x0001A09C
		private void ReadParameters(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.Range param_range)
		{
			if (this.MoveTo(global::Mono.Cecil.Metadata.Table.ParamPtr, param_range.Start))
			{
				this.ReadParameterPointers(method, param_range);
				return;
			}
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.Param, param_range.Start))
			{
				return;
			}
			for (uint num = 0U; num < param_range.Length; num += 1U)
			{
				this.ReadParameter(param_range.Start + num, method);
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0001BEF8 File Offset: 0x0001A0F8
		private void ReadParameterPointers(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.Range range)
		{
			for (uint num = 0U; num < range.Length; num += 1U)
			{
				this.MoveTo(global::Mono.Cecil.Metadata.Table.ParamPtr, range.Start + num);
				uint num2 = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.Param);
				this.MoveTo(global::Mono.Cecil.Metadata.Table.Param, num2);
				this.ReadParameter(num2, method);
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001BF44 File Offset: 0x0001A144
		private void ReadParameter(uint param_rid, global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Cecil.ParameterAttributes attributes = (global::Mono.Cecil.ParameterAttributes)base.ReadUInt16();
			ushort num = base.ReadUInt16();
			string name = this.ReadString();
			global::Mono.Cecil.ParameterDefinition parameterDefinition = (num == 0) ? method.MethodReturnType.Parameter : method.Parameters[(int)(num - 1)];
			parameterDefinition.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Param, param_rid);
			parameterDefinition.Name = name;
			parameterDefinition.Attributes = attributes;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0001BFA4 File Offset: 0x0001A1A4
		private void ReadMethodSignature(uint signature, global::Mono.Cecil.IMethodSignature method)
		{
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			signatureReader.ReadMethodSignature(method);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0001BFC0 File Offset: 0x0001A1C0
		public global::Mono.Cecil.PInvokeInfo ReadPInvokeInfo(global::Mono.Cecil.MethodDefinition method)
		{
			this.InitializePInvokes();
			uint rid = method.token.RID;
			global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint> row;
			if (!this.metadata.PInvokes.TryGetValue(rid, out row))
			{
				return null;
			}
			this.metadata.PInvokes.Remove(rid);
			return new global::Mono.Cecil.PInvokeInfo(row.Col1, this.image.StringHeap.Read(row.Col2), this.module.ModuleReferences[(int)(row.Col3 - 1U)]);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0001C044 File Offset: 0x0001A244
		private void InitializePInvokes()
		{
			if (this.metadata.PInvokes != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.ImplMap);
			global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint>> dictionary = this.metadata.PInvokes = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint>>(num);
			for (int i = 1; i <= num; i++)
			{
				global::Mono.Cecil.PInvokeAttributes col = (global::Mono.Cecil.PInvokeAttributes)base.ReadUInt16();
				global::Mono.Cecil.MetadataToken metadataToken = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded);
				uint col2 = this.ReadStringIndex();
				uint col3 = this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.File);
				if (metadataToken.TokenType == global::Mono.Cecil.TokenType.Method)
				{
					dictionary.Add(metadataToken.RID, new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint>(col, col2, col3));
				}
			}
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0001C0D4 File Offset: 0x0001A2D4
		public bool HasGenericParameters(global::Mono.Cecil.IGenericParameterProvider provider)
		{
			this.InitializeGenericParameters();
			global::Mono.Cecil.Range range;
			return this.metadata.TryGetGenericParameterRange(provider, out range) && range.Length > 0U;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0001C104 File Offset: 0x0001A304
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> ReadGenericParameters(global::Mono.Cecil.IGenericParameterProvider provider)
		{
			this.InitializeGenericParameters();
			global::Mono.Cecil.Range range;
			if (!this.metadata.TryGetGenericParameterRange(provider, out range) || !this.MoveTo(global::Mono.Cecil.Metadata.Table.GenericParam, range.Start))
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>();
			}
			this.metadata.RemoveGenericParameterRange(provider);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>((int)range.Length);
			for (uint num = 0U; num < range.Length; num += 1U)
			{
				base.ReadUInt16();
				global::Mono.Cecil.GenericParameterAttributes attributes = (global::Mono.Cecil.GenericParameterAttributes)base.ReadUInt16();
				this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef);
				string name = this.ReadString();
				collection.Add(new global::Mono.Cecil.GenericParameter(name, provider)
				{
					token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.GenericParam, range.Start + num),
					Attributes = attributes
				});
			}
			return collection;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0001C1E5 File Offset: 0x0001A3E5
		private void InitializeGenericParameters()
		{
			if (this.metadata.GenericParameters != null)
			{
				return;
			}
			this.metadata.GenericParameters = this.InitializeRanges(global::Mono.Cecil.Metadata.Table.GenericParam, delegate
			{
				base.Advance(4);
				global::Mono.Cecil.MetadataToken result = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef);
				this.ReadStringIndex();
				return result;
			});
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0001C214 File Offset: 0x0001A414
		private global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Range> InitializeRanges(global::Mono.Cecil.Metadata.Table table, global::System.Func<global::Mono.Cecil.MetadataToken> get_next)
		{
			int num = this.MoveTo(table);
			global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Range> dictionary = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Range>(num);
			if (num == 0)
			{
				return dictionary;
			}
			global::Mono.Cecil.MetadataToken metadataToken = global::Mono.Cecil.MetadataToken.Zero;
			global::Mono.Cecil.Range value = new global::Mono.Cecil.Range(1U, 0U);
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				global::Mono.Cecil.MetadataToken metadataToken2 = get_next();
				if (num2 == 1U)
				{
					metadataToken = metadataToken2;
					value.Length += 1U;
				}
				else if (metadataToken2 != metadataToken)
				{
					if (metadataToken.RID != 0U)
					{
						dictionary.Add(metadataToken, value);
					}
					value = new global::Mono.Cecil.Range(num2, 1U);
					metadataToken = metadataToken2;
				}
				else
				{
					value.Length += 1U;
				}
				num2 += 1U;
			}
			if (metadataToken != global::Mono.Cecil.MetadataToken.Zero && !dictionary.ContainsKey(metadataToken))
			{
				dictionary.Add(metadataToken, value);
			}
			return dictionary;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001C2D0 File Offset: 0x0001A4D0
		public bool HasGenericConstraints(global::Mono.Cecil.GenericParameter generic_parameter)
		{
			this.InitializeGenericConstraints();
			global::Mono.Cecil.MetadataToken[] array;
			return this.metadata.TryGetGenericConstraintMapping(generic_parameter, out array) && array.Length > 0;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0001C2FC File Offset: 0x0001A4FC
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> ReadGenericConstraints(global::Mono.Cecil.GenericParameter generic_parameter)
		{
			this.InitializeGenericConstraints();
			global::Mono.Cecil.MetadataToken[] array;
			if (!this.metadata.TryGetGenericConstraintMapping(generic_parameter, out array))
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>();
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference>(array.Length);
			this.context = (global::Mono.Cecil.IGenericContext)generic_parameter.Owner;
			for (int i = 0; i < array.Length; i++)
			{
				collection.Add(this.GetTypeDefOrRef(array[i]));
			}
			this.metadata.RemoveGenericConstraintMapping(generic_parameter);
			return collection;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001C374 File Offset: 0x0001A574
		private void InitializeGenericConstraints()
		{
			if (this.metadata.GenericConstraints != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.GenericParamConstraint);
			this.metadata.GenericConstraints = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken[]>(num);
			for (int i = 1; i <= num; i++)
			{
				this.AddGenericConstraintMapping(this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.GenericParam), this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef));
			}
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001C3CA File Offset: 0x0001A5CA
		private void AddGenericConstraintMapping(uint generic_parameter, global::Mono.Cecil.MetadataToken constraint)
		{
			this.metadata.SetGenericConstraintMapping(generic_parameter, global::Mono.Cecil.MetadataReader.AddMapping<uint, global::Mono.Cecil.MetadataToken>(this.metadata.GenericConstraints, generic_parameter, constraint));
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0001C3EC File Offset: 0x0001A5EC
		public bool HasOverrides(global::Mono.Cecil.MethodDefinition method)
		{
			this.InitializeOverrides();
			global::Mono.Cecil.MetadataToken[] array;
			return this.metadata.TryGetOverrideMapping(method, out array) && array.Length > 0;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0001C418 File Offset: 0x0001A618
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> ReadOverrides(global::Mono.Cecil.MethodDefinition method)
		{
			this.InitializeOverrides();
			global::Mono.Cecil.MetadataToken[] array;
			if (!this.metadata.TryGetOverrideMapping(method, out array))
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference>();
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference>(array.Length);
			this.context = method;
			for (int i = 0; i < array.Length; i++)
			{
				collection.Add((global::Mono.Cecil.MethodReference)this.LookupToken(array[i]));
			}
			this.metadata.RemoveOverrideMapping(method);
			return collection;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0001C48C File Offset: 0x0001A68C
		private void InitializeOverrides()
		{
			if (this.metadata.Overrides != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.MethodImpl);
			this.metadata.Overrides = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken[]>(num);
			for (int i = 1; i <= num; i++)
			{
				this.ReadTableIndex(global::Mono.Cecil.Metadata.Table.TypeDef);
				global::Mono.Cecil.MetadataToken metadataToken = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef);
				if (metadataToken.TokenType != global::Mono.Cecil.TokenType.Method)
				{
					throw new global::System.NotSupportedException();
				}
				global::Mono.Cecil.MetadataToken @override = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef);
				this.AddOverrideMapping(metadataToken.RID, @override);
			}
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0001C507 File Offset: 0x0001A707
		private void AddOverrideMapping(uint method_rid, global::Mono.Cecil.MetadataToken @override)
		{
			this.metadata.SetOverrideMapping(method_rid, global::Mono.Cecil.MetadataReader.AddMapping<uint, global::Mono.Cecil.MetadataToken>(this.metadata.Overrides, method_rid, @override));
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0001C527 File Offset: 0x0001A727
		public global::Mono.Cecil.Cil.MethodBody ReadMethodBody(global::Mono.Cecil.MethodDefinition method)
		{
			return this.code.ReadMethodBody(method);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0001C538 File Offset: 0x0001A738
		public global::Mono.Cecil.CallSite ReadCallSite(global::Mono.Cecil.MetadataToken token)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.StandAloneSig, token.RID))
			{
				return null;
			}
			uint signature = this.ReadBlobIndex();
			global::Mono.Cecil.CallSite callSite = new global::Mono.Cecil.CallSite();
			this.ReadMethodSignature(signature, callSite);
			callSite.MetadataToken = token;
			return callSite;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0001C578 File Offset: 0x0001A778
		public global::Mono.Cecil.Cil.VariableDefinitionCollection ReadVariables(global::Mono.Cecil.MetadataToken local_var_token)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.StandAloneSig, local_var_token.RID))
			{
				return null;
			}
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(this.ReadBlobIndex());
			if (signatureReader.ReadByte() != 7)
			{
				throw new global::System.NotSupportedException();
			}
			uint num = signatureReader.ReadCompressedUInt32();
			if (num == 0U)
			{
				return null;
			}
			global::Mono.Cecil.Cil.VariableDefinitionCollection variableDefinitionCollection = new global::Mono.Cecil.Cil.VariableDefinitionCollection((int)num);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				variableDefinitionCollection.Add(new global::Mono.Cecil.Cil.VariableDefinition(signatureReader.ReadTypeSignature()));
				num2++;
			}
			return variableDefinitionCollection;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0001C5E8 File Offset: 0x0001A7E8
		public global::Mono.Cecil.IMetadataTokenProvider LookupToken(global::Mono.Cecil.MetadataToken token)
		{
			uint rid = token.RID;
			if (rid == 0U)
			{
				return null;
			}
			int position = this.position;
			global::Mono.Cecil.IGenericContext genericContext = this.context;
			global::Mono.Cecil.TokenType tokenType = token.TokenType;
			global::Mono.Cecil.IMetadataTokenProvider result;
			if (tokenType <= global::Mono.Cecil.TokenType.Field)
			{
				if (tokenType == global::Mono.Cecil.TokenType.TypeRef)
				{
					result = this.GetTypeReference(rid);
					goto IL_C3;
				}
				if (tokenType == global::Mono.Cecil.TokenType.TypeDef)
				{
					result = this.GetTypeDefinition(rid);
					goto IL_C3;
				}
				if (tokenType == global::Mono.Cecil.TokenType.Field)
				{
					result = this.GetFieldDefinition(rid);
					goto IL_C3;
				}
			}
			else if (tokenType <= global::Mono.Cecil.TokenType.MemberRef)
			{
				if (tokenType == global::Mono.Cecil.TokenType.Method)
				{
					result = this.GetMethodDefinition(rid);
					goto IL_C3;
				}
				if (tokenType == global::Mono.Cecil.TokenType.MemberRef)
				{
					result = this.GetMemberReference(rid);
					goto IL_C3;
				}
			}
			else
			{
				if (tokenType == global::Mono.Cecil.TokenType.TypeSpec)
				{
					result = this.GetTypeSpecification(rid);
					goto IL_C3;
				}
				if (tokenType == global::Mono.Cecil.TokenType.MethodSpec)
				{
					result = this.GetMethodSpecification(rid);
					goto IL_C3;
				}
			}
			return null;
			IL_C3:
			this.position = position;
			this.context = genericContext;
			return result;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0001C6C8 File Offset: 0x0001A8C8
		public global::Mono.Cecil.FieldDefinition GetFieldDefinition(uint rid)
		{
			this.InitializeTypeDefinitions();
			global::Mono.Cecil.FieldDefinition fieldDefinition = this.metadata.GetFieldDefinition(rid);
			if (fieldDefinition != null)
			{
				return fieldDefinition;
			}
			return this.LookupField(rid);
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0001C6F4 File Offset: 0x0001A8F4
		private global::Mono.Cecil.FieldDefinition LookupField(uint rid)
		{
			global::Mono.Cecil.TypeDefinition fieldDeclaringType = this.metadata.GetFieldDeclaringType(rid);
			if (fieldDeclaringType == null)
			{
				return null;
			}
			global::Mono.Cecil.MetadataReader.InitializeCollection(fieldDeclaringType.Fields);
			return this.metadata.GetFieldDefinition(rid);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0001C72C File Offset: 0x0001A92C
		public global::Mono.Cecil.MethodDefinition GetMethodDefinition(uint rid)
		{
			this.InitializeTypeDefinitions();
			global::Mono.Cecil.MethodDefinition methodDefinition = this.metadata.GetMethodDefinition(rid);
			if (methodDefinition != null)
			{
				return methodDefinition;
			}
			return this.LookupMethod(rid);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0001C758 File Offset: 0x0001A958
		private global::Mono.Cecil.MethodDefinition LookupMethod(uint rid)
		{
			global::Mono.Cecil.TypeDefinition methodDeclaringType = this.metadata.GetMethodDeclaringType(rid);
			if (methodDeclaringType == null)
			{
				return null;
			}
			global::Mono.Cecil.MetadataReader.InitializeCollection(methodDeclaringType.Methods);
			return this.metadata.GetMethodDefinition(rid);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0001C790 File Offset: 0x0001A990
		private global::Mono.Cecil.MethodSpecification GetMethodSpecification(uint rid)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.MethodSpec, rid))
			{
				return null;
			}
			global::Mono.Cecil.MethodReference method = (global::Mono.Cecil.MethodReference)this.LookupToken(this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef));
			uint signature = this.ReadBlobIndex();
			global::Mono.Cecil.MethodSpecification methodSpecification = this.ReadMethodSpecSignature(signature, method);
			methodSpecification.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MethodSpec, rid);
			return methodSpecification;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0001C7E0 File Offset: 0x0001A9E0
		private global::Mono.Cecil.MethodSpecification ReadMethodSpecSignature(uint signature, global::Mono.Cecil.MethodReference method)
		{
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			byte b = signatureReader.ReadByte();
			if (b != 0xA)
			{
				throw new global::System.NotSupportedException();
			}
			global::Mono.Cecil.GenericInstanceMethod genericInstanceMethod = new global::Mono.Cecil.GenericInstanceMethod(method);
			signatureReader.ReadGenericInstanceSignature(method, genericInstanceMethod);
			return genericInstanceMethod;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0001C818 File Offset: 0x0001AA18
		private global::Mono.Cecil.MemberReference GetMemberReference(uint rid)
		{
			this.InitializeMemberReferences();
			global::Mono.Cecil.MemberReference memberReference = this.metadata.GetMemberReference(rid);
			if (memberReference != null)
			{
				return memberReference;
			}
			memberReference = this.ReadMemberReference(rid);
			if (memberReference != null && !memberReference.ContainsGenericParameter)
			{
				this.metadata.AddMemberReference(memberReference);
			}
			return memberReference;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0001C860 File Offset: 0x0001AA60
		private global::Mono.Cecil.MemberReference ReadMemberReference(uint rid)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.MemberRef, rid))
			{
				return null;
			}
			global::Mono.Cecil.MetadataToken metadataToken = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent);
			string name = this.ReadString();
			uint signature = this.ReadBlobIndex();
			global::Mono.Cecil.TokenType tokenType = metadataToken.TokenType;
			global::Mono.Cecil.MemberReference memberReference;
			if (tokenType <= global::Mono.Cecil.TokenType.TypeDef)
			{
				if (tokenType != global::Mono.Cecil.TokenType.TypeRef && tokenType != global::Mono.Cecil.TokenType.TypeDef)
				{
					goto IL_73;
				}
			}
			else
			{
				if (tokenType == global::Mono.Cecil.TokenType.Method)
				{
					memberReference = this.ReadMethodMemberReference(metadataToken, name, signature);
					goto IL_79;
				}
				if (tokenType != global::Mono.Cecil.TokenType.TypeSpec)
				{
					goto IL_73;
				}
			}
			memberReference = this.ReadTypeMemberReference(metadataToken, name, signature);
			goto IL_79;
			IL_73:
			throw new global::System.NotSupportedException();
			IL_79:
			memberReference.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.MemberRef, rid);
			return memberReference;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0001C8F8 File Offset: 0x0001AAF8
		private global::Mono.Cecil.MemberReference ReadTypeMemberReference(global::Mono.Cecil.MetadataToken type, string name, uint signature)
		{
			global::Mono.Cecil.TypeReference typeDefOrRef = this.GetTypeDefOrRef(type);
			this.context = typeDefOrRef;
			global::Mono.Cecil.MemberReference memberReference = this.ReadMemberReferenceSignature(signature, typeDefOrRef);
			memberReference.Name = name;
			return memberReference;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0001C928 File Offset: 0x0001AB28
		private global::Mono.Cecil.MemberReference ReadMemberReferenceSignature(uint signature, global::Mono.Cecil.TypeReference declaring_type)
		{
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			if (signatureReader.buffer[signatureReader.position] == 6)
			{
				signatureReader.position++;
				return new global::Mono.Cecil.FieldReference
				{
					DeclaringType = declaring_type,
					FieldType = signatureReader.ReadTypeSignature()
				};
			}
			global::Mono.Cecil.MethodReference methodReference = new global::Mono.Cecil.MethodReference();
			methodReference.DeclaringType = declaring_type;
			signatureReader.ReadMethodSignature(methodReference);
			return methodReference;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001C98C File Offset: 0x0001AB8C
		private global::Mono.Cecil.MemberReference ReadMethodMemberReference(global::Mono.Cecil.MetadataToken token, string name, uint signature)
		{
			global::Mono.Cecil.MethodDefinition methodDefinition = this.GetMethodDefinition(token.RID);
			this.context = methodDefinition;
			global::Mono.Cecil.MemberReference memberReference = this.ReadMemberReferenceSignature(signature, methodDefinition.DeclaringType);
			memberReference.Name = name;
			return memberReference;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0001C9C4 File Offset: 0x0001ABC4
		private void InitializeMemberReferences()
		{
			if (this.metadata.MemberReferences != null)
			{
				return;
			}
			this.metadata.MemberReferences = new global::Mono.Cecil.MemberReference[this.image.GetTableLength(global::Mono.Cecil.Metadata.Table.MemberRef)];
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0001C9F4 File Offset: 0x0001ABF4
		public global::System.Collections.Generic.IEnumerable<global::Mono.Cecil.MemberReference> GetMemberReferences()
		{
			this.InitializeMemberReferences();
			int tableLength = this.image.GetTableLength(global::Mono.Cecil.Metadata.Table.MemberRef);
			global::Mono.Cecil.TypeSystem typeSystem = this.module.TypeSystem;
			global::Mono.Cecil.MethodReference methodReference = new global::Mono.Cecil.MethodReference(string.Empty, typeSystem.Void);
			methodReference.DeclaringType = new global::Mono.Cecil.TypeReference(string.Empty, string.Empty, this.module, typeSystem.Corlib);
			global::Mono.Cecil.MemberReference[] array = new global::Mono.Cecil.MemberReference[tableLength];
			uint num = 1U;
			while ((ulong)num <= (ulong)((long)tableLength))
			{
				this.context = methodReference;
				array[(int)((global::System.UIntPtr)(num - 1U))] = this.GetMemberReference(num);
				num += 1U;
			}
			return array;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0001CA84 File Offset: 0x0001AC84
		private void InitializeConstants()
		{
			if (this.metadata.Constants != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.Constant);
			global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint>> dictionary = this.metadata.Constants = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint>>(num);
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)num))
			{
				global::Mono.Cecil.Metadata.ElementType col = (global::Mono.Cecil.Metadata.ElementType)base.ReadUInt16();
				global::Mono.Cecil.MetadataToken key = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasConstant);
				uint col2 = this.ReadBlobIndex();
				dictionary.Add(key, new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint>(col, col2));
				num2 += 1U;
			}
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0001CAF8 File Offset: 0x0001ACF8
		public object ReadConstant(global::Mono.Cecil.IConstantProvider owner)
		{
			this.InitializeConstants();
			global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint> row;
			if (!this.metadata.Constants.TryGetValue(owner.MetadataToken, out row))
			{
				return global::Mono.Cecil.Mixin.NoValue;
			}
			this.metadata.Constants.Remove(owner.MetadataToken);
			global::Mono.Cecil.Metadata.ElementType col = row.Col1;
			if (col == global::Mono.Cecil.Metadata.ElementType.String)
			{
				return global::Mono.Cecil.MetadataReader.ReadConstantString(this.ReadBlob(row.Col2));
			}
			if (col == global::Mono.Cecil.Metadata.ElementType.Class || col == global::Mono.Cecil.Metadata.ElementType.Object)
			{
				return null;
			}
			return this.ReadConstantPrimitive(row.Col1, row.Col2);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0001CB84 File Offset: 0x0001AD84
		private static string ReadConstantString(byte[] blob)
		{
			int num = blob.Length;
			if ((num & 1) == 1)
			{
				num--;
			}
			return global::System.Text.Encoding.Unicode.GetString(blob, 0, num);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0001CBAC File Offset: 0x0001ADAC
		private object ReadConstantPrimitive(global::Mono.Cecil.Metadata.ElementType type, uint signature)
		{
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			return signatureReader.ReadConstantSignature(type);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0001CBEE File Offset: 0x0001ADEE
		private void InitializeCustomAttributes()
		{
			if (this.metadata.CustomAttributes != null)
			{
				return;
			}
			this.metadata.CustomAttributes = this.InitializeRanges(global::Mono.Cecil.Metadata.Table.CustomAttribute, delegate
			{
				global::Mono.Cecil.MetadataToken result = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute);
				this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType);
				this.ReadBlobIndex();
				return result;
			});
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0001CC20 File Offset: 0x0001AE20
		public bool HasCustomAttributes(global::Mono.Cecil.ICustomAttributeProvider owner)
		{
			this.InitializeCustomAttributes();
			global::Mono.Cecil.Range range;
			return this.metadata.TryGetCustomAttributeRange(owner, out range) && range.Length > 0U;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0001CC50 File Offset: 0x0001AE50
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> ReadCustomAttributes(global::Mono.Cecil.ICustomAttributeProvider owner)
		{
			this.InitializeCustomAttributes();
			global::Mono.Cecil.Range range;
			if (!this.metadata.TryGetCustomAttributeRange(owner, out range) || !this.MoveTo(global::Mono.Cecil.Metadata.Table.CustomAttribute, range.Start))
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute>();
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute>((int)range.Length);
			int num = 0;
			while ((long)num < (long)((ulong)range.Length))
			{
				this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute);
				global::Mono.Cecil.MethodReference constructor = (global::Mono.Cecil.MethodReference)this.LookupToken(this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType));
				uint signature = this.ReadBlobIndex();
				collection.Add(new global::Mono.Cecil.CustomAttribute(signature, constructor));
				num++;
			}
			this.metadata.RemoveCustomAttributeRange(owner);
			return collection;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0001CCEA File Offset: 0x0001AEEA
		public byte[] ReadCustomAttributeBlob(uint signature)
		{
			return this.ReadBlob(signature);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0001CCF4 File Offset: 0x0001AEF4
		public void ReadCustomAttributeSignature(global::Mono.Cecil.CustomAttribute attribute)
		{
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(attribute.signature);
			if (signatureReader.ReadUInt16() != 1)
			{
				throw new global::System.InvalidOperationException();
			}
			global::Mono.Cecil.MethodReference constructor = attribute.Constructor;
			if (constructor.HasParameters)
			{
				signatureReader.ReadCustomAttributeConstructorArguments(attribute, constructor.Parameters);
			}
			if (!signatureReader.CanReadMore())
			{
				return;
			}
			ushort num = signatureReader.ReadUInt16();
			if (num == 0)
			{
				return;
			}
			signatureReader.ReadCustomAttributeNamedArguments(num, ref attribute.fields, ref attribute.properties);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0001CD60 File Offset: 0x0001AF60
		private void InitializeMarshalInfos()
		{
			if (this.metadata.FieldMarshals != null)
			{
				return;
			}
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.FieldMarshal);
			global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, uint> dictionary = this.metadata.FieldMarshals = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, uint>(num);
			for (int i = 0; i < num; i++)
			{
				global::Mono.Cecil.MetadataToken key = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal);
				uint value = this.ReadBlobIndex();
				if (key.RID != 0U)
				{
					dictionary.Add(key, value);
				}
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0001CDC9 File Offset: 0x0001AFC9
		public bool HasMarshalInfo(global::Mono.Cecil.IMarshalInfoProvider owner)
		{
			this.InitializeMarshalInfos();
			return this.metadata.FieldMarshals.ContainsKey(owner.MetadataToken);
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0001CDE8 File Offset: 0x0001AFE8
		public global::Mono.Cecil.MarshalInfo ReadMarshalInfo(global::Mono.Cecil.IMarshalInfoProvider owner)
		{
			this.InitializeMarshalInfos();
			uint signature;
			if (!this.metadata.FieldMarshals.TryGetValue(owner.MetadataToken, out signature))
			{
				return null;
			}
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			this.metadata.FieldMarshals.Remove(owner.MetadataToken);
			return signatureReader.ReadMarshalInfo();
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0001CE60 File Offset: 0x0001B060
		private void InitializeSecurityDeclarations()
		{
			if (this.metadata.SecurityDeclarations != null)
			{
				return;
			}
			this.metadata.SecurityDeclarations = this.InitializeRanges(global::Mono.Cecil.Metadata.Table.DeclSecurity, delegate
			{
				base.ReadUInt16();
				global::Mono.Cecil.MetadataToken result = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity);
				this.ReadBlobIndex();
				return result;
			});
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0001CE90 File Offset: 0x0001B090
		public bool HasSecurityDeclarations(global::Mono.Cecil.ISecurityDeclarationProvider owner)
		{
			this.InitializeSecurityDeclarations();
			global::Mono.Cecil.Range range;
			return this.metadata.TryGetSecurityDeclarationRange(owner, out range) && range.Length > 0U;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0001CEC0 File Offset: 0x0001B0C0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> ReadSecurityDeclarations(global::Mono.Cecil.ISecurityDeclarationProvider owner)
		{
			this.InitializeSecurityDeclarations();
			global::Mono.Cecil.Range range;
			if (!this.metadata.TryGetSecurityDeclarationRange(owner, out range) || !this.MoveTo(global::Mono.Cecil.Metadata.Table.DeclSecurity, range.Start))
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration>();
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration>((int)range.Length);
			int num = 0;
			while ((long)num < (long)((ulong)range.Length))
			{
				global::Mono.Cecil.SecurityAction action = (global::Mono.Cecil.SecurityAction)base.ReadUInt16();
				this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity);
				uint signature = this.ReadBlobIndex();
				collection.Add(new global::Mono.Cecil.SecurityDeclaration(action, signature, this.module));
				num++;
			}
			this.metadata.RemoveSecurityDeclarationRange(owner);
			return collection;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0001CF53 File Offset: 0x0001B153
		public byte[] ReadSecurityDeclarationBlob(uint signature)
		{
			return this.ReadBlob(signature);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0001CF5C File Offset: 0x0001B15C
		public void ReadSecurityDeclarationSignature(global::Mono.Cecil.SecurityDeclaration declaration)
		{
			uint signature = declaration.signature;
			global::Mono.Cecil.SignatureReader signatureReader = this.ReadSignature(signature);
			if (signatureReader.buffer[signatureReader.position] != 0x2E)
			{
				this.ReadXmlSecurityDeclaration(signature, declaration);
				return;
			}
			signatureReader.position++;
			uint num = signatureReader.ReadCompressedUInt32();
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute>((int)num);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				collection.Add(signatureReader.ReadSecurityAttribute());
				num2++;
			}
			declaration.security_attributes = collection;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0001CFD4 File Offset: 0x0001B1D4
		private void ReadXmlSecurityDeclaration(uint signature, global::Mono.Cecil.SecurityDeclaration declaration)
		{
			byte[] array = this.ReadBlob(signature);
			declaration.security_attributes = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute>(1)
			{
				new global::Mono.Cecil.SecurityAttribute(this.module.TypeSystem.LookupType("System.Security.Permissions", "PermissionSetAttribute"))
				{
					properties = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument>(1),
					properties = 
					{
						new global::Mono.Cecil.CustomAttributeNamedArgument("XML", new global::Mono.Cecil.CustomAttributeArgument(this.module.TypeSystem.String, global::System.Text.Encoding.Unicode.GetString(array, 0, array.Length)))
					}
				}
			};
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0001D064 File Offset: 0x0001B264
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> ReadExportedTypes()
		{
			int num = this.MoveTo(global::Mono.Cecil.Metadata.Table.ExportedType);
			if (num == 0)
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType>();
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType>(num);
			for (int i = 1; i <= num; i++)
			{
				global::Mono.Cecil.TypeAttributes attributes = (global::Mono.Cecil.TypeAttributes)base.ReadUInt32();
				uint identifier = base.ReadUInt32();
				string name = this.ReadString();
				string @namespace = this.ReadString();
				global::Mono.Cecil.MetadataToken token = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.Implementation);
				global::Mono.Cecil.ExportedType declaringType = null;
				global::Mono.Cecil.IMetadataScope scope = null;
				global::Mono.Cecil.TokenType tokenType = token.TokenType;
				if (tokenType != global::Mono.Cecil.TokenType.AssemblyRef && tokenType != global::Mono.Cecil.TokenType.File)
				{
					if (tokenType == global::Mono.Cecil.TokenType.ExportedType)
					{
						declaringType = collection[(int)(token.RID - 1U)];
					}
				}
				else
				{
					scope = this.GetExportedTypeScope(token);
				}
				global::Mono.Cecil.ExportedType exportedType = new global::Mono.Cecil.ExportedType(@namespace, name, this.module, scope)
				{
					Attributes = attributes,
					Identifier = (int)identifier,
					DeclaringType = declaringType
				};
				exportedType.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.ExportedType, i);
				collection.Add(exportedType);
			}
			return collection;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0001D15C File Offset: 0x0001B35C
		private global::Mono.Cecil.IMetadataScope GetExportedTypeScope(global::Mono.Cecil.MetadataToken token)
		{
			int position = this.position;
			global::Mono.Cecil.TokenType tokenType = token.TokenType;
			global::Mono.Cecil.IMetadataScope result;
			if (tokenType != global::Mono.Cecil.TokenType.AssemblyRef)
			{
				if (tokenType != global::Mono.Cecil.TokenType.File)
				{
					throw new global::System.NotSupportedException();
				}
				this.InitializeModuleReferences();
				result = this.GetModuleReferenceFromFile(token);
			}
			else
			{
				this.InitializeAssemblyReferences();
				result = this.metadata.AssemblyReferences[(int)(token.RID - 1U)];
			}
			this.position = position;
			return result;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0001D1C8 File Offset: 0x0001B3C8
		private global::Mono.Cecil.ModuleReference GetModuleReferenceFromFile(global::Mono.Cecil.MetadataToken token)
		{
			if (!this.MoveTo(global::Mono.Cecil.Metadata.Table.File, token.RID))
			{
				return null;
			}
			base.ReadUInt32();
			string text = this.ReadString();
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleReference> moduleReferences = this.module.ModuleReferences;
			global::Mono.Cecil.ModuleReference moduleReference;
			for (int i = 0; i < moduleReferences.Count; i++)
			{
				moduleReference = moduleReferences[i];
				if (moduleReference.Name == text)
				{
					return moduleReference;
				}
			}
			moduleReference = new global::Mono.Cecil.ModuleReference(text);
			moduleReferences.Add(moduleReference);
			return moduleReference;
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0001D23A File Offset: 0x0001B43A
		private static void InitializeCollection(object o)
		{
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0001C1C0 File Offset: 0x0001A3C0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.MetadataToken <InitializeGenericParameters>b__3()
		{
			base.Advance(4);
			global::Mono.Cecil.MetadataToken result = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef);
			this.ReadStringIndex();
			return result;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0001CBC8 File Offset: 0x0001ADC8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.MetadataToken <InitializeCustomAttributes>b__4()
		{
			global::Mono.Cecil.MetadataToken result = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute);
			this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType);
			this.ReadBlobIndex();
			return result;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0001CE3C File Offset: 0x0001B03C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.MetadataToken <InitializeSecurityDeclarations>b__5()
		{
			base.ReadUInt16();
			global::Mono.Cecil.MetadataToken result = this.ReadMetadataToken(global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity);
			this.ReadBlobIndex();
			return result;
		}

		// Token: 0x0400060D RID: 1549
		internal readonly global::Mono.Cecil.PE.Image image;

		// Token: 0x0400060E RID: 1550
		internal readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x0400060F RID: 1551
		internal readonly global::Mono.Cecil.MetadataSystem metadata;

		// Token: 0x04000610 RID: 1552
		internal global::Mono.Cecil.IGenericContext context;

		// Token: 0x04000611 RID: 1553
		internal global::Mono.Cecil.Cil.CodeReader code;
	}
}
