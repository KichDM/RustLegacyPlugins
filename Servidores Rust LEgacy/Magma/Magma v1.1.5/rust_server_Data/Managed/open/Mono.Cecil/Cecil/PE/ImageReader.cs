using System;
using System.IO;
using Mono.Cecil.Metadata;

namespace Mono.Cecil.PE
{
	// Token: 0x020000A8 RID: 168
	internal sealed class ImageReader : global::Mono.Cecil.PE.BinaryStreamReader
	{
		// Token: 0x060006F3 RID: 1779 RVA: 0x00011F74 File Offset: 0x00010174
		public ImageReader(global::System.IO.Stream stream) : base(stream)
		{
			this.image = new global::Mono.Cecil.PE.Image();
			this.image.FileName = stream.GetFullyQualifiedName();
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00011F99 File Offset: 0x00010199
		private void MoveTo(global::Mono.Cecil.PE.DataDirectory directory)
		{
			this.BaseStream.Position = (long)((ulong)this.image.ResolveVirtualAddress(directory.VirtualAddress));
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00011FB9 File Offset: 0x000101B9
		private void MoveTo(uint position)
		{
			this.BaseStream.Position = (long)((ulong)position);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00011FC8 File Offset: 0x000101C8
		private void ReadImage()
		{
			if (this.BaseStream.Length < 0x80L)
			{
				throw new global::System.BadImageFormatException();
			}
			if (this.ReadUInt16() != 0x5A4D)
			{
				throw new global::System.BadImageFormatException();
			}
			base.Advance(0x3A);
			this.MoveTo(this.ReadUInt32());
			if (this.ReadUInt32() != 0x4550U)
			{
				throw new global::System.BadImageFormatException();
			}
			this.image.Architecture = this.ReadArchitecture();
			ushort count = this.ReadUInt16();
			base.Advance(0xE);
			ushort characteristics = this.ReadUInt16();
			ushort subsystem;
			this.ReadOptionalHeaders(out subsystem);
			this.ReadSections(count);
			this.ReadCLIHeader();
			this.ReadMetadata();
			this.image.Kind = global::Mono.Cecil.PE.ImageReader.GetModuleKind(characteristics, subsystem);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0001207C File Offset: 0x0001027C
		private global::Mono.Cecil.TargetArchitecture ReadArchitecture()
		{
			ushort num = this.ReadUInt16();
			ushort num2 = num;
			if (num2 == 0x14C)
			{
				return global::Mono.Cecil.TargetArchitecture.I386;
			}
			if (num2 == 0x200)
			{
				return global::Mono.Cecil.TargetArchitecture.IA64;
			}
			if (num2 != 0x8664)
			{
				throw new global::System.NotSupportedException();
			}
			return global::Mono.Cecil.TargetArchitecture.AMD64;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x000120B7 File Offset: 0x000102B7
		private static global::Mono.Cecil.ModuleKind GetModuleKind(ushort characteristics, ushort subsystem)
		{
			if ((characteristics & 0x2000) != 0)
			{
				return global::Mono.Cecil.ModuleKind.Dll;
			}
			if (subsystem == 2 || subsystem == 9)
			{
				return global::Mono.Cecil.ModuleKind.Windows;
			}
			return global::Mono.Cecil.ModuleKind.Console;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x000120D0 File Offset: 0x000102D0
		private void ReadOptionalHeaders(out ushort subsystem)
		{
			bool flag = this.ReadUInt16() == 0x20B;
			base.Advance(0x42);
			subsystem = this.ReadUInt16();
			base.Advance(flag ? 0x5A : 0x4A);
			this.image.Debug = base.ReadDataDirectory();
			base.Advance(0x38);
			this.cli = base.ReadDataDirectory();
			if (this.cli.IsZero)
			{
				throw new global::System.BadImageFormatException();
			}
			base.Advance(8);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0001214C File Offset: 0x0001034C
		private string ReadAlignedString(int length)
		{
			int i = 0;
			char[] array = new char[length];
			while (i < length)
			{
				byte b = this.ReadByte();
				if (b == 0)
				{
					break;
				}
				array[i++] = (char)b;
			}
			base.Advance(-1 + (i + 4 & -4) - i);
			return new string(array, 0, i);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00012194 File Offset: 0x00010394
		private string ReadZeroTerminatedString(int length)
		{
			int i = 0;
			char[] array = new char[length];
			byte[] array2 = this.ReadBytes(length);
			while (i < length)
			{
				byte b = array2[i];
				if (b == 0)
				{
					break;
				}
				array[i++] = (char)b;
			}
			return new string(array, 0, i);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x000121D0 File Offset: 0x000103D0
		private void ReadSections(ushort count)
		{
			global::Mono.Cecil.PE.Section[] array = new global::Mono.Cecil.PE.Section[(int)count];
			for (int i = 0; i < (int)count; i++)
			{
				global::Mono.Cecil.PE.Section section = new global::Mono.Cecil.PE.Section();
				section.Name = this.ReadZeroTerminatedString(8);
				base.Advance(4);
				section.VirtualAddress = this.ReadUInt32();
				section.SizeOfRawData = this.ReadUInt32();
				section.PointerToRawData = this.ReadUInt32();
				base.Advance(0x10);
				array[i] = section;
				if (!(section.Name == ".reloc"))
				{
					this.ReadSectionData(section);
				}
			}
			this.image.Sections = array;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00012260 File Offset: 0x00010460
		private void ReadSectionData(global::Mono.Cecil.PE.Section section)
		{
			long position = this.BaseStream.Position;
			this.MoveTo(section.PointerToRawData);
			int sizeOfRawData = (int)section.SizeOfRawData;
			byte[] array = new byte[sizeOfRawData];
			int num = 0;
			int num2;
			while ((num2 = this.Read(array, num, sizeOfRawData - num)) > 0)
			{
				num += num2;
			}
			section.Data = array;
			this.BaseStream.Position = position;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000122C0 File Offset: 0x000104C0
		private void ReadCLIHeader()
		{
			this.MoveTo(this.cli);
			base.Advance(8);
			this.metadata = base.ReadDataDirectory();
			this.image.Attributes = (global::Mono.Cecil.ModuleAttributes)this.ReadUInt32();
			this.image.EntryPointToken = this.ReadUInt32();
			this.image.Resources = base.ReadDataDirectory();
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00012320 File Offset: 0x00010520
		private void ReadMetadata()
		{
			this.MoveTo(this.metadata);
			if (this.ReadUInt32() != 0x424A5342U)
			{
				throw new global::System.BadImageFormatException();
			}
			base.Advance(8);
			string self = this.ReadZeroTerminatedString(this.ReadInt32());
			this.image.Runtime = self.ParseRuntime();
			base.Advance(2);
			ushort num = this.ReadUInt16();
			global::Mono.Cecil.PE.Section sectionAtVirtualAddress = this.image.GetSectionAtVirtualAddress(this.metadata.VirtualAddress);
			if (sectionAtVirtualAddress == null)
			{
				throw new global::System.BadImageFormatException();
			}
			this.image.MetadataSection = sectionAtVirtualAddress;
			for (int i = 0; i < (int)num; i++)
			{
				this.ReadMetadataStream(sectionAtVirtualAddress);
			}
			if (this.image.TableHeap != null)
			{
				this.ReadTableHeap();
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000123D4 File Offset: 0x000105D4
		private void ReadMetadataStream(global::Mono.Cecil.PE.Section section)
		{
			uint start = this.metadata.VirtualAddress - section.VirtualAddress + this.ReadUInt32();
			uint size = this.ReadUInt32();
			string text = this.ReadAlignedString(0x10);
			string a;
			if ((a = text) != null)
			{
				if (a == "#~" || a == "#-")
				{
					this.image.TableHeap = new global::Mono.Cecil.Metadata.TableHeap(section, start, size);
					return;
				}
				if (a == "#Strings")
				{
					this.image.StringHeap = new global::Mono.Cecil.Metadata.StringHeap(section, start, size);
					return;
				}
				if (a == "#Blob")
				{
					this.image.BlobHeap = new global::Mono.Cecil.Metadata.BlobHeap(section, start, size);
					return;
				}
				if (a == "#GUID")
				{
					this.image.GuidHeap = new global::Mono.Cecil.Metadata.GuidHeap(section, start, size);
					return;
				}
				if (!(a == "#US"))
				{
					return;
				}
				this.image.UserStringHeap = new global::Mono.Cecil.Metadata.UserStringHeap(section, start, size);
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000124C8 File Offset: 0x000106C8
		private void ReadTableHeap()
		{
			global::Mono.Cecil.Metadata.TableHeap tableHeap = this.image.TableHeap;
			uint pointerToRawData = tableHeap.Section.PointerToRawData;
			this.MoveTo(tableHeap.Offset + pointerToRawData);
			base.Advance(6);
			byte sizes = this.ReadByte();
			base.Advance(1);
			tableHeap.Valid = this.ReadInt64();
			tableHeap.Sorted = this.ReadInt64();
			for (int i = 0; i < 0x2D; i++)
			{
				if (tableHeap.HasTable((global::Mono.Cecil.Metadata.Table)i))
				{
					tableHeap.Tables[i].Length = this.ReadUInt32();
				}
			}
			global::Mono.Cecil.PE.ImageReader.SetIndexSize(this.image.StringHeap, (uint)sizes, 1);
			global::Mono.Cecil.PE.ImageReader.SetIndexSize(this.image.GuidHeap, (uint)sizes, 2);
			global::Mono.Cecil.PE.ImageReader.SetIndexSize(this.image.BlobHeap, (uint)sizes, 4);
			this.ComputeTableInformations();
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00012592 File Offset: 0x00010792
		private static void SetIndexSize(global::Mono.Cecil.Metadata.Heap heap, uint sizes, byte flag)
		{
			if (heap == null)
			{
				return;
			}
			heap.IndexSize = (((sizes & (uint)flag) > 0U) ? 4 : 2);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000125A8 File Offset: 0x000107A8
		private int GetTableIndexSize(global::Mono.Cecil.Metadata.Table table)
		{
			return this.image.GetTableIndexSize(table);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x000125B6 File Offset: 0x000107B6
		private int GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex index)
		{
			return this.image.GetCodedIndexSize(index);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x000125C4 File Offset: 0x000107C4
		private void ComputeTableInformations()
		{
			uint num = (uint)this.BaseStream.Position - this.image.MetadataSection.PointerToRawData;
			int indexSize = this.image.StringHeap.IndexSize;
			int num2 = (this.image.BlobHeap != null) ? this.image.BlobHeap.IndexSize : 2;
			global::Mono.Cecil.Metadata.TableHeap tableHeap = this.image.TableHeap;
			global::Mono.Cecil.Metadata.TableInformation[] tables = tableHeap.Tables;
			for (int i = 0; i < 0x2D; i++)
			{
				global::Mono.Cecil.Metadata.Table table = (global::Mono.Cecil.Metadata.Table)i;
				if (tableHeap.HasTable(table))
				{
					int num3;
					switch (table)
					{
					case global::Mono.Cecil.Metadata.Table.Module:
						num3 = 2 + indexSize + this.image.GuidHeap.IndexSize * 3;
						break;
					case global::Mono.Cecil.Metadata.Table.TypeRef:
						num3 = this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope) + indexSize * 2;
						break;
					case global::Mono.Cecil.Metadata.Table.TypeDef:
						num3 = 4 + indexSize * 2 + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef) + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Field) + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Method);
						break;
					case global::Mono.Cecil.Metadata.Table.FieldPtr:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Field);
						break;
					case global::Mono.Cecil.Metadata.Table.Field:
						num3 = 2 + indexSize + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.MethodPtr:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Method);
						break;
					case global::Mono.Cecil.Metadata.Table.Method:
						num3 = 8 + indexSize + num2 + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Param);
						break;
					case global::Mono.Cecil.Metadata.Table.ParamPtr:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Param);
						break;
					case global::Mono.Cecil.Metadata.Table.Param:
						num3 = 4 + indexSize;
						break;
					case global::Mono.Cecil.Metadata.Table.InterfaceImpl:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef) + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
						break;
					case global::Mono.Cecil.Metadata.Table.MemberRef:
						num3 = this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent) + indexSize + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.Constant:
						num3 = 2 + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.HasConstant) + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.CustomAttribute:
						num3 = this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute) + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType) + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.FieldMarshal:
						num3 = this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal) + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.DeclSecurity:
						num3 = 2 + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity) + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.ClassLayout:
						num3 = 6 + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef);
						break;
					case global::Mono.Cecil.Metadata.Table.FieldLayout:
						num3 = 4 + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Field);
						break;
					case global::Mono.Cecil.Metadata.Table.StandAloneSig:
						num3 = num2;
						break;
					case global::Mono.Cecil.Metadata.Table.EventMap:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef) + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Event);
						break;
					case global::Mono.Cecil.Metadata.Table.EventPtr:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Event);
						break;
					case global::Mono.Cecil.Metadata.Table.Event:
						num3 = 2 + indexSize + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
						break;
					case global::Mono.Cecil.Metadata.Table.PropertyMap:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef) + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Property);
						break;
					case global::Mono.Cecil.Metadata.Table.PropertyPtr:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Property);
						break;
					case global::Mono.Cecil.Metadata.Table.Property:
						num3 = 2 + indexSize + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.MethodSemantics:
						num3 = 2 + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Method) + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.HasSemantics);
						break;
					case global::Mono.Cecil.Metadata.Table.MethodImpl:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef) + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef) + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef);
						break;
					case global::Mono.Cecil.Metadata.Table.ModuleRef:
						num3 = indexSize;
						break;
					case global::Mono.Cecil.Metadata.Table.TypeSpec:
						num3 = num2;
						break;
					case global::Mono.Cecil.Metadata.Table.ImplMap:
						num3 = 2 + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded) + indexSize + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.ModuleRef);
						break;
					case global::Mono.Cecil.Metadata.Table.FieldRVA:
						num3 = 4 + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.Field);
						break;
					case global::Mono.Cecil.Metadata.Table.EncLog:
					case global::Mono.Cecil.Metadata.Table.EncMap:
						num3 = 4;
						break;
					case global::Mono.Cecil.Metadata.Table.Assembly:
						num3 = 0x10 + num2 + indexSize * 2;
						break;
					case global::Mono.Cecil.Metadata.Table.AssemblyProcessor:
						num3 = 4;
						break;
					case global::Mono.Cecil.Metadata.Table.AssemblyOS:
						num3 = 0xC;
						break;
					case global::Mono.Cecil.Metadata.Table.AssemblyRef:
						num3 = 0xC + num2 * 2 + indexSize * 2;
						break;
					case global::Mono.Cecil.Metadata.Table.AssemblyRefProcessor:
						num3 = 4 + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.AssemblyRef);
						break;
					case global::Mono.Cecil.Metadata.Table.AssemblyRefOS:
						num3 = 0xC + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.AssemblyRef);
						break;
					case global::Mono.Cecil.Metadata.Table.File:
						num3 = 4 + indexSize + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.ExportedType:
						num3 = 8 + indexSize * 2 + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.Implementation);
						break;
					case global::Mono.Cecil.Metadata.Table.ManifestResource:
						num3 = 8 + indexSize + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.Implementation);
						break;
					case global::Mono.Cecil.Metadata.Table.NestedClass:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef) + this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.TypeDef);
						break;
					case global::Mono.Cecil.Metadata.Table.GenericParam:
						num3 = 4 + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef) + indexSize;
						break;
					case global::Mono.Cecil.Metadata.Table.MethodSpec:
						num3 = this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef) + num2;
						break;
					case global::Mono.Cecil.Metadata.Table.GenericParamConstraint:
						num3 = this.GetTableIndexSize(global::Mono.Cecil.Metadata.Table.GenericParam) + this.GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
						break;
					default:
						throw new global::System.NotSupportedException();
					}
					tables[i].RowSize = (uint)num3;
					tables[i].Offset = num;
					num += (uint)(num3 * (int)tables[i].Length);
				}
			}
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00012A44 File Offset: 0x00010C44
		public static global::Mono.Cecil.PE.Image ReadImageFrom(global::System.IO.Stream stream)
		{
			global::Mono.Cecil.PE.Image result;
			try
			{
				global::Mono.Cecil.PE.ImageReader imageReader = new global::Mono.Cecil.PE.ImageReader(stream);
				imageReader.ReadImage();
				result = imageReader.image;
			}
			catch (global::System.IO.EndOfStreamException inner)
			{
				throw new global::System.BadImageFormatException(stream.GetFullyQualifiedName(), inner);
			}
			return result;
		}

		// Token: 0x04000537 RID: 1335
		private readonly global::Mono.Cecil.PE.Image image;

		// Token: 0x04000538 RID: 1336
		private global::Mono.Cecil.PE.DataDirectory cli;

		// Token: 0x04000539 RID: 1337
		private global::Mono.Cecil.PE.DataDirectory metadata;
	}
}
