using System;
using System.IO;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;

namespace Mono.Cecil.PE
{
	// Token: 0x020000A6 RID: 166
	internal sealed class ImageWriter : global::Mono.Cecil.PE.BinaryStreamWriter
	{
		// Token: 0x060006BF RID: 1727 RVA: 0x00010B68 File Offset: 0x0000ED68
		private ImageWriter(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataBuilder metadata, global::System.IO.Stream stream) : base(stream)
		{
			this.module = module;
			this.metadata = metadata;
			this.GetDebugHeader();
			this.GetWin32Resources();
			this.text_map = this.BuildTextMap();
			this.sections = 2;
			this.pe64 = (module.Architecture != global::Mono.Cecil.TargetArchitecture.I386);
			this.time_stamp = (uint)global::System.DateTime.UtcNow.Subtract(new global::System.DateTime(0x7B2, 1, 1)).TotalSeconds;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00010BE4 File Offset: 0x0000EDE4
		private void GetDebugHeader()
		{
			global::Mono.Cecil.Cil.ISymbolWriter symbol_writer = this.metadata.symbol_writer;
			if (symbol_writer == null)
			{
				return;
			}
			if (!symbol_writer.GetDebugHeader(out this.debug_directory, out this.debug_data))
			{
				this.debug_data = global::Mono.Empty<byte>.Array;
			}
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00010C20 File Offset: 0x0000EE20
		private void GetWin32Resources()
		{
			global::Mono.Cecil.PE.Section imageResourceSection = this.GetImageResourceSection();
			if (imageResourceSection == null)
			{
				return;
			}
			byte[] array = new byte[imageResourceSection.Data.Length];
			global::System.Buffer.BlockCopy(imageResourceSection.Data, 0, array, 0, imageResourceSection.Data.Length);
			this.win32_resources = new global::Mono.Cecil.PE.ByteBuffer(array);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00010C68 File Offset: 0x0000EE68
		private global::Mono.Cecil.PE.Section GetImageResourceSection()
		{
			if (!this.module.HasImage)
			{
				return null;
			}
			return this.module.Image.GetSection(".rsrc");
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00010C90 File Offset: 0x0000EE90
		public static global::Mono.Cecil.PE.ImageWriter CreateWriter(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataBuilder metadata, global::System.IO.Stream stream)
		{
			global::Mono.Cecil.PE.ImageWriter imageWriter = new global::Mono.Cecil.PE.ImageWriter(module, metadata, stream);
			imageWriter.BuildSections();
			return imageWriter;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00010CB0 File Offset: 0x0000EEB0
		private void BuildSections()
		{
			bool flag = this.win32_resources != null;
			if (flag)
			{
				this.sections += 1;
			}
			this.text = this.CreateSection(".text", this.text_map.GetLength(), null);
			global::Mono.Cecil.PE.Section previous = this.text;
			if (flag)
			{
				this.rsrc = this.CreateSection(".rsrc", (uint)this.win32_resources.length, previous);
				this.PatchWin32Resources(this.win32_resources);
				previous = this.rsrc;
			}
			this.reloc = this.CreateSection(".reloc", 0xCU, previous);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00010D48 File Offset: 0x0000EF48
		private global::Mono.Cecil.PE.Section CreateSection(string name, uint size, global::Mono.Cecil.PE.Section previous)
		{
			return new global::Mono.Cecil.PE.Section
			{
				Name = name,
				VirtualAddress = ((previous != null) ? (previous.VirtualAddress + global::Mono.Cecil.PE.ImageWriter.Align(previous.VirtualSize, 0x2000U)) : 0x2000U),
				VirtualSize = size,
				PointerToRawData = ((previous != null) ? (previous.PointerToRawData + previous.SizeOfRawData) : global::Mono.Cecil.PE.ImageWriter.Align(this.GetHeaderSize(), 0x200U)),
				SizeOfRawData = global::Mono.Cecil.PE.ImageWriter.Align(size, 0x200U)
			};
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00010DCA File Offset: 0x0000EFCA
		private static uint Align(uint value, uint align)
		{
			align -= 1U;
			return value + align & ~align;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00010E58 File Offset: 0x0000F058
		private void WriteDOSHeader()
		{
			this.Write(new byte[]
			{
				0x4D,
				0x5A,
				0x90,
				0,
				3,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				byte.MaxValue,
				byte.MaxValue,
				0,
				0,
				0xB8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0x40,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0x80,
				0,
				0,
				0,
				0xE,
				0x1F,
				0xBA,
				0xE,
				0,
				0xB4,
				9,
				0xCD,
				0x21,
				0xB8,
				1,
				0x4C,
				0xCD,
				0x21,
				0x54,
				0x68,
				0x69,
				0x73,
				0x20,
				0x70,
				0x72,
				0x6F,
				0x67,
				0x72,
				0x61,
				0x6D,
				0x20,
				0x63,
				0x61,
				0x6E,
				0x6E,
				0x6F,
				0x74,
				0x20,
				0x62,
				0x65,
				0x20,
				0x72,
				0x75,
				0x6E,
				0x20,
				0x69,
				0x6E,
				0x20,
				0x44,
				0x4F,
				0x53,
				0x20,
				0x6D,
				0x6F,
				0x64,
				0x65,
				0x2E,
				0xD,
				0xD,
				0xA,
				0x24,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			});
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00010E78 File Offset: 0x0000F078
		private void WritePEFileHeader()
		{
			base.WriteUInt32(0x4550U);
			base.WriteUInt16(this.GetMachine());
			base.WriteUInt16(this.sections);
			base.WriteUInt32(this.time_stamp);
			base.WriteUInt32(0U);
			base.WriteUInt32(0U);
			base.WriteUInt16((!this.pe64) ? 0xE0 : 0xF0);
			ushort num = (ushort)(2 | ((!this.pe64) ? 0x100 : 0x20));
			if (this.module.Kind == global::Mono.Cecil.ModuleKind.Dll || this.module.Kind == global::Mono.Cecil.ModuleKind.NetModule)
			{
				num |= 0x2000;
			}
			base.WriteUInt16(num);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00010F20 File Offset: 0x0000F120
		private ushort GetMachine()
		{
			switch (this.module.Architecture)
			{
			case global::Mono.Cecil.TargetArchitecture.I386:
				return 0x14C;
			case global::Mono.Cecil.TargetArchitecture.AMD64:
				return 0x8664;
			case global::Mono.Cecil.TargetArchitecture.IA64:
				return 0x200;
			default:
				throw new global::System.NotSupportedException();
			}
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00010F64 File Offset: 0x0000F164
		private void WriteOptionalHeaders()
		{
			base.WriteUInt16((!this.pe64) ? 0x10B : 0x20B);
			base.WriteByte(8);
			base.WriteByte(0);
			base.WriteUInt32(this.text.SizeOfRawData);
			base.WriteUInt32(this.reloc.SizeOfRawData + ((this.rsrc != null) ? this.rsrc.SizeOfRawData : 0U));
			base.WriteUInt32(0U);
			uint num = this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.StartupStub);
			if (this.module.Architecture == global::Mono.Cecil.TargetArchitecture.IA64)
			{
				num += 0x20U;
			}
			base.WriteUInt32(num);
			base.WriteUInt32(0x2000U);
			if (!this.pe64)
			{
				base.WriteUInt32(0U);
				base.WriteUInt32(0x400000U);
			}
			else
			{
				base.WriteUInt64(0x400000UL);
			}
			base.WriteUInt32(0x2000U);
			base.WriteUInt32(0x200U);
			base.WriteUInt16(4);
			base.WriteUInt16(0);
			base.WriteUInt16(0);
			base.WriteUInt16(0);
			base.WriteUInt16(4);
			base.WriteUInt16(0);
			base.WriteUInt32(0U);
			base.WriteUInt32(this.reloc.VirtualAddress + global::Mono.Cecil.PE.ImageWriter.Align(this.reloc.VirtualSize, 0x2000U));
			base.WriteUInt32(this.text.PointerToRawData);
			base.WriteUInt32(0U);
			base.WriteUInt16(this.GetSubSystem());
			base.WriteUInt16(0x8540);
			if (!this.pe64)
			{
				base.WriteUInt32(0x100000U);
				base.WriteUInt32(0x1000U);
				base.WriteUInt32(0x100000U);
				base.WriteUInt32(0x1000U);
			}
			else
			{
				base.WriteUInt64(0x100000UL);
				base.WriteUInt64(0x1000UL);
				base.WriteUInt64(0x100000UL);
				base.WriteUInt64(0x1000UL);
			}
			base.WriteUInt32(0U);
			base.WriteUInt32(0x10U);
			this.WriteZeroDataDirectory();
			base.WriteDataDirectory(this.text_map.GetDataDirectory(global::Mono.Cecil.PE.TextSegment.ImportDirectory));
			if (this.rsrc != null)
			{
				base.WriteUInt32(this.rsrc.VirtualAddress);
				base.WriteUInt32(this.rsrc.VirtualSize);
			}
			else
			{
				this.WriteZeroDataDirectory();
			}
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			base.WriteUInt32(this.reloc.VirtualAddress);
			base.WriteUInt32(this.reloc.VirtualSize);
			if (this.text_map.GetLength(global::Mono.Cecil.PE.TextSegment.DebugDirectory) > 0)
			{
				base.WriteUInt32(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.DebugDirectory));
				base.WriteUInt32(0x1CU);
			}
			else
			{
				this.WriteZeroDataDirectory();
			}
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			base.WriteDataDirectory(this.text_map.GetDataDirectory(global::Mono.Cecil.PE.TextSegment.ImportAddressTable));
			this.WriteZeroDataDirectory();
			base.WriteDataDirectory(this.text_map.GetDataDirectory(global::Mono.Cecil.PE.TextSegment.CLIHeader));
			this.WriteZeroDataDirectory();
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00011241 File Offset: 0x0000F441
		private void WriteZeroDataDirectory()
		{
			base.WriteUInt32(0U);
			base.WriteUInt32(0U);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00011254 File Offset: 0x0000F454
		private ushort GetSubSystem()
		{
			switch (this.module.Kind)
			{
			case global::Mono.Cecil.ModuleKind.Dll:
			case global::Mono.Cecil.ModuleKind.Console:
			case global::Mono.Cecil.ModuleKind.NetModule:
				return 3;
			case global::Mono.Cecil.ModuleKind.Windows:
				return 2;
			default:
				throw new global::System.ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001128E File Offset: 0x0000F48E
		private void WriteSectionHeaders()
		{
			this.WriteSection(this.text, 0x60000020U);
			if (this.rsrc != null)
			{
				this.WriteSection(this.rsrc, 0x40000040U);
			}
			this.WriteSection(this.reloc, 0x42000040U);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x000112CC File Offset: 0x0000F4CC
		private void WriteSection(global::Mono.Cecil.PE.Section section, uint characteristics)
		{
			byte[] array = new byte[8];
			string name = section.Name;
			for (int i = 0; i < name.Length; i++)
			{
				array[i] = (byte)name[i];
			}
			base.WriteBytes(array);
			base.WriteUInt32(section.VirtualSize);
			base.WriteUInt32(section.VirtualAddress);
			base.WriteUInt32(section.SizeOfRawData);
			base.WriteUInt32(section.PointerToRawData);
			base.WriteUInt32(0U);
			base.WriteUInt32(0U);
			base.WriteUInt16(0);
			base.WriteUInt16(0);
			base.WriteUInt32(characteristics);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001135D File Offset: 0x0000F55D
		private void MoveTo(uint pointer)
		{
			this.BaseStream.Seek((long)((ulong)pointer), global::System.IO.SeekOrigin.Begin);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001136E File Offset: 0x0000F56E
		private void MoveToRVA(global::Mono.Cecil.PE.Section section, uint rva)
		{
			this.BaseStream.Seek((long)((ulong)(section.PointerToRawData + rva - section.VirtualAddress)), global::System.IO.SeekOrigin.Begin);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0001138D File Offset: 0x0000F58D
		private void MoveToRVA(global::Mono.Cecil.PE.TextSegment segment)
		{
			this.MoveToRVA(this.text, this.text_map.GetRVA(segment));
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000113A7 File Offset: 0x0000F5A7
		private void WriteRVA(uint rva)
		{
			if (!this.pe64)
			{
				base.WriteUInt32(rva);
				return;
			}
			base.WriteUInt64((ulong)rva);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000113C4 File Offset: 0x0000F5C4
		private void WriteText()
		{
			this.MoveTo(this.text.PointerToRawData);
			this.WriteRVA(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportHintNameTable));
			this.WriteRVA(0U);
			base.WriteUInt32(0x48U);
			base.WriteUInt16(2);
			base.WriteUInt16((this.module.Runtime <= global::Mono.Cecil.TargetRuntime.Net_1_1) ? 0 : 5);
			base.WriteUInt32(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.MetadataHeader));
			base.WriteUInt32(this.GetMetadataLength());
			base.WriteUInt32((uint)this.module.Attributes);
			base.WriteUInt32(this.metadata.entry_point.ToUInt32());
			base.WriteDataDirectory(this.text_map.GetDataDirectory(global::Mono.Cecil.PE.TextSegment.Resources));
			base.WriteDataDirectory(this.text_map.GetDataDirectory(global::Mono.Cecil.PE.TextSegment.StrongNameSignature));
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			this.WriteZeroDataDirectory();
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.Code);
			base.WriteBuffer(this.metadata.code);
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.Resources);
			base.WriteBuffer(this.metadata.resources);
			if (this.metadata.data.length > 0)
			{
				this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.Data);
				base.WriteBuffer(this.metadata.data);
			}
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.MetadataHeader);
			this.WriteMetadataHeader();
			this.WriteMetadata();
			if (this.text_map.GetLength(global::Mono.Cecil.PE.TextSegment.DebugDirectory) > 0)
			{
				this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.DebugDirectory);
				this.WriteDebugDirectory();
			}
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.ImportDirectory);
			this.WriteImportDirectory();
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.StartupStub);
			this.WriteStartupStub();
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0001154D File Offset: 0x0000F74D
		private uint GetMetadataLength()
		{
			return this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.DebugDirectory) - this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.MetadataHeader);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001156C File Offset: 0x0000F76C
		private void WriteMetadataHeader()
		{
			base.WriteUInt32(0x424A5342U);
			base.WriteUInt16(1);
			base.WriteUInt16(1);
			base.WriteUInt32(0U);
			byte[] zeroTerminatedString = global::Mono.Cecil.PE.ImageWriter.GetZeroTerminatedString(this.GetVersion());
			base.WriteUInt32((uint)zeroTerminatedString.Length);
			base.WriteBytes(zeroTerminatedString);
			base.WriteUInt16(0);
			base.WriteUInt16(this.GetStreamCount());
			uint num = this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.TableHeap) - this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.MetadataHeader);
			this.WriteStreamHeader(ref num, global::Mono.Cecil.PE.TextSegment.TableHeap, "#~");
			this.WriteStreamHeader(ref num, global::Mono.Cecil.PE.TextSegment.StringHeap, "#Strings");
			this.WriteStreamHeader(ref num, global::Mono.Cecil.PE.TextSegment.UserStringHeap, "#US");
			this.WriteStreamHeader(ref num, global::Mono.Cecil.PE.TextSegment.GuidHeap, "#GUID");
			this.WriteStreamHeader(ref num, global::Mono.Cecil.PE.TextSegment.BlobHeap, "#Blob");
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0001162C File Offset: 0x0000F82C
		private string GetVersion()
		{
			switch (this.module.Runtime)
			{
			case global::Mono.Cecil.TargetRuntime.Net_1_0:
				return "v1.0.3705";
			case global::Mono.Cecil.TargetRuntime.Net_1_1:
				return "v1.1.4322";
			case global::Mono.Cecil.TargetRuntime.Net_2_0:
				return "v2.0.50727";
			}
			return "v4.0.30319";
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00011674 File Offset: 0x0000F874
		private ushort GetStreamCount()
		{
			return (ushort)(2 + (this.metadata.user_string_heap.IsEmpty ? 0 : 1) + 1 + (this.metadata.blob_heap.IsEmpty ? 0 : 1));
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x000116A8 File Offset: 0x0000F8A8
		private void WriteStreamHeader(ref uint offset, global::Mono.Cecil.PE.TextSegment heap, string name)
		{
			uint length = (uint)this.text_map.GetLength(heap);
			if (length == 0U)
			{
				return;
			}
			base.WriteUInt32(offset);
			base.WriteUInt32(length);
			base.WriteBytes(global::Mono.Cecil.PE.ImageWriter.GetZeroTerminatedString(name));
			offset += length;
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x000116E7 File Offset: 0x0000F8E7
		private static byte[] GetZeroTerminatedString(string @string)
		{
			return global::Mono.Cecil.PE.ImageWriter.GetString(@string, @string.Length + 1 + 3 & -4);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x000116FC File Offset: 0x0000F8FC
		private static byte[] GetSimpleString(string @string)
		{
			return global::Mono.Cecil.PE.ImageWriter.GetString(@string, @string.Length);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001170C File Offset: 0x0000F90C
		private static byte[] GetString(string @string, int length)
		{
			byte[] array = new byte[length];
			for (int i = 0; i < @string.Length; i++)
			{
				array[i] = (byte)@string[i];
			}
			return array;
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00011740 File Offset: 0x0000F940
		private void WriteMetadata()
		{
			this.WriteHeap(global::Mono.Cecil.PE.TextSegment.TableHeap, this.metadata.table_heap);
			this.WriteHeap(global::Mono.Cecil.PE.TextSegment.StringHeap, this.metadata.string_heap);
			this.WriteHeap(global::Mono.Cecil.PE.TextSegment.UserStringHeap, this.metadata.user_string_heap);
			this.WriteGuidHeap();
			this.WriteHeap(global::Mono.Cecil.PE.TextSegment.BlobHeap, this.metadata.blob_heap);
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0001179D File Offset: 0x0000F99D
		private void WriteHeap(global::Mono.Cecil.PE.TextSegment heap, global::Mono.Cecil.Metadata.HeapBuffer buffer)
		{
			if (buffer.IsEmpty)
			{
				return;
			}
			this.MoveToRVA(heap);
			base.WriteBuffer(buffer);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x000117B8 File Offset: 0x0000F9B8
		private void WriteGuidHeap()
		{
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.GuidHeap);
			base.WriteBytes(this.module.Mvid.ToByteArray());
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x000117E8 File Offset: 0x0000F9E8
		private void WriteDebugDirectory()
		{
			base.WriteInt32(this.debug_directory.Characteristics);
			base.WriteUInt32(this.time_stamp);
			base.WriteInt16(this.debug_directory.MajorVersion);
			base.WriteInt16(this.debug_directory.MinorVersion);
			base.WriteInt32(this.debug_directory.Type);
			base.WriteInt32(this.debug_directory.SizeOfData);
			base.WriteInt32(this.debug_directory.AddressOfRawData);
			base.WriteInt32((int)this.BaseStream.Position + 4);
			base.WriteBytes(this.debug_data);
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00011888 File Offset: 0x0000FA88
		private void WriteImportDirectory()
		{
			base.WriteUInt32(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportDirectory) + 0x28U);
			base.WriteUInt32(0U);
			base.WriteUInt32(0U);
			base.WriteUInt32(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportHintNameTable) + 0xEU);
			base.WriteUInt32(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportAddressTable));
			base.Advance(0x14);
			base.WriteUInt32(this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportHintNameTable));
			this.MoveToRVA(global::Mono.Cecil.PE.TextSegment.ImportHintNameTable);
			base.WriteUInt16(0);
			base.WriteBytes(this.GetRuntimeMain());
			base.WriteByte(0);
			base.WriteBytes(global::Mono.Cecil.PE.ImageWriter.GetSimpleString("mscoree.dll"));
			base.WriteUInt16(0);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00011935 File Offset: 0x0000FB35
		private byte[] GetRuntimeMain()
		{
			if (this.module.Kind != global::Mono.Cecil.ModuleKind.Dll && this.module.Kind != global::Mono.Cecil.ModuleKind.NetModule)
			{
				return global::Mono.Cecil.PE.ImageWriter.GetSimpleString("_CorExeMain");
			}
			return global::Mono.Cecil.PE.ImageWriter.GetSimpleString("_CorDllMain");
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00011988 File Offset: 0x0000FB88
		private void WriteStartupStub()
		{
			switch (this.module.Architecture)
			{
			case global::Mono.Cecil.TargetArchitecture.I386:
				base.WriteUInt16(0x25FF);
				base.WriteUInt32(0x400000U + this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportAddressTable));
				return;
			case global::Mono.Cecil.TargetArchitecture.AMD64:
				base.WriteUInt16(0xA148);
				base.WriteUInt32(0x400000U + this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.ImportAddressTable));
				base.WriteUInt16(0xE0FF);
				return;
			case global::Mono.Cecil.TargetArchitecture.IA64:
				base.WriteBytes(new byte[]
				{
					0xB,
					0x48,
					0,
					2,
					0x18,
					0x10,
					0xA0,
					0x40,
					0x24,
					0x30,
					0x28,
					0,
					0,
					0,
					4,
					0,
					0x10,
					8,
					0,
					0x12,
					0x18,
					0x10,
					0x60,
					0x50,
					4,
					0x80,
					3,
					0,
					0x60,
					0,
					0x80,
					0
				});
				base.WriteUInt32(0x400000U + this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.StartupStub));
				base.WriteUInt32(0x402000U);
				return;
			default:
				return;
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00011A43 File Offset: 0x0000FC43
		private void WriteRsrc()
		{
			this.MoveTo(this.rsrc.PointerToRawData);
			base.WriteBuffer(this.win32_resources);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00011A64 File Offset: 0x0000FC64
		private void WriteReloc()
		{
			this.MoveTo(this.reloc.PointerToRawData);
			uint num = this.text_map.GetRVA(global::Mono.Cecil.PE.TextSegment.StartupStub);
			num += ((this.module.Architecture == global::Mono.Cecil.TargetArchitecture.IA64) ? 0x20U : 2U);
			uint num2 = num & 0xFFFFF000U;
			base.WriteUInt32(num2);
			base.WriteUInt32(0xCU);
			switch (this.module.Architecture)
			{
			case global::Mono.Cecil.TargetArchitecture.I386:
				base.WriteUInt32(0x3000U + num - num2);
				break;
			case global::Mono.Cecil.TargetArchitecture.AMD64:
				base.WriteUInt32(0xA000U + num - num2);
				break;
			case global::Mono.Cecil.TargetArchitecture.IA64:
				base.WriteUInt16((ushort)(0xA000U + num - num2));
				base.WriteUInt16((ushort)(0xA000U + num - num2 + 8U));
				break;
			}
			base.WriteBytes(new byte[0x200U - this.reloc.VirtualSize]);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00011B3E File Offset: 0x0000FD3E
		public void WriteImage()
		{
			this.WriteDOSHeader();
			this.WritePEFileHeader();
			this.WriteOptionalHeaders();
			this.WriteSectionHeaders();
			this.WriteText();
			if (this.rsrc != null)
			{
				this.WriteRsrc();
			}
			this.WriteReloc();
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00011B74 File Offset: 0x0000FD74
		private global::Mono.Cecil.PE.TextMap BuildTextMap()
		{
			global::Mono.Cecil.PE.TextMap textMap = this.metadata.text_map;
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.Code, this.metadata.code.length, (!this.pe64) ? 4 : 0x10);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.Resources, this.metadata.resources.length, 8);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.Data, this.metadata.data.length, 4);
			if (this.metadata.data.length > 0)
			{
				this.metadata.table_heap.FixupData(textMap.GetRVA(global::Mono.Cecil.PE.TextSegment.Data));
			}
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.StrongNameSignature, this.GetStrongNameLength(), 4);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.MetadataHeader, this.GetMetadataHeaderLength());
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.TableHeap, this.metadata.table_heap.length, 4);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.StringHeap, this.metadata.string_heap.length, 4);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.UserStringHeap, this.metadata.user_string_heap.IsEmpty ? 0 : this.metadata.user_string_heap.length, 4);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.GuidHeap, 0x10);
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.BlobHeap, this.metadata.blob_heap.IsEmpty ? 0 : this.metadata.blob_heap.length, 4);
			int length = 0;
			if (!this.debug_data.IsNullOrEmpty<byte>())
			{
				this.debug_directory.AddressOfRawData = (int)(textMap.GetNextRVA(global::Mono.Cecil.PE.TextSegment.BlobHeap) + 0x1CU);
				length = this.debug_data.Length + 0x1C;
			}
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.DebugDirectory, length, 4);
			uint nextRVA = textMap.GetNextRVA(global::Mono.Cecil.PE.TextSegment.DebugDirectory);
			uint num = nextRVA + ((!this.pe64) ? 0x30U : 0x34U);
			num = (num + 0xFU & 0xFFFFFFF0U);
			uint num2 = num - nextRVA + 0x1BU;
			uint num3 = nextRVA + num2;
			num3 = ((this.module.Architecture == global::Mono.Cecil.TargetArchitecture.IA64) ? (num3 + 0xFU & 0xFFFFFFF0U) : (2U + (num3 + 3U & 0xFFFFFFFCU)));
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.ImportDirectory, new global::Mono.Cecil.Range(nextRVA, num2));
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.ImportHintNameTable, new global::Mono.Cecil.Range(num, 0U));
			textMap.AddMap(global::Mono.Cecil.PE.TextSegment.StartupStub, new global::Mono.Cecil.Range(num3, this.GetStartupStubLength()));
			return textMap;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00011D80 File Offset: 0x0000FF80
		private uint GetStartupStubLength()
		{
			switch (this.module.Architecture)
			{
			case global::Mono.Cecil.TargetArchitecture.I386:
				return 6U;
			case global::Mono.Cecil.TargetArchitecture.AMD64:
				return 0xCU;
			case global::Mono.Cecil.TargetArchitecture.IA64:
				return 0x30U;
			default:
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00011DBA File Offset: 0x0000FFBA
		private int GetMetadataHeaderLength()
		{
			return 0x48 + (this.metadata.user_string_heap.IsEmpty ? 0 : 0xC) + 0x10 + (this.metadata.blob_heap.IsEmpty ? 0 : 0x10);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00011DF4 File Offset: 0x0000FFF4
		private int GetStrongNameLength()
		{
			if ((this.module.Attributes & global::Mono.Cecil.ModuleAttributes.StrongNameSigned) == (global::Mono.Cecil.ModuleAttributes)0)
			{
				return 0;
			}
			if (this.module.Assembly == null)
			{
				throw new global::System.InvalidOperationException();
			}
			byte[] publicKey = this.module.Assembly.Name.PublicKey;
			if (publicKey != null)
			{
				int num = publicKey.Length;
				if (num > 0x20)
				{
					return num - 0x20;
				}
			}
			return 0x80;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00011E51 File Offset: 0x00010051
		public global::Mono.Cecil.PE.DataDirectory GetStrongNameSignatureDirectory()
		{
			return this.text_map.GetDataDirectory(global::Mono.Cecil.PE.TextSegment.StrongNameSignature);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00011E5F File Offset: 0x0001005F
		public uint GetHeaderSize()
		{
			return (uint)(0x178 + this.sections * 0x28);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00011E70 File Offset: 0x00010070
		private void PatchWin32Resources(global::Mono.Cecil.PE.ByteBuffer resources)
		{
			this.PatchResourceDirectoryTable(resources);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00011E7C File Offset: 0x0001007C
		private void PatchResourceDirectoryTable(global::Mono.Cecil.PE.ByteBuffer resources)
		{
			resources.Advance(0xC);
			int num = (int)(resources.ReadUInt16() + resources.ReadUInt16());
			for (int i = 0; i < num; i++)
			{
				this.PatchResourceDirectoryEntry(resources);
			}
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00011EB4 File Offset: 0x000100B4
		private void PatchResourceDirectoryEntry(global::Mono.Cecil.PE.ByteBuffer resources)
		{
			resources.Advance(4);
			uint num = resources.ReadUInt32();
			int position = resources.position;
			resources.position = (int)(num & 0x7FFFFFFFU);
			if ((num & 0x80000000U) != 0U)
			{
				this.PatchResourceDirectoryTable(resources);
			}
			else
			{
				this.PatchResourceDataEntry(resources);
			}
			resources.position = position;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00011F04 File Offset: 0x00010104
		private void PatchResourceDataEntry(global::Mono.Cecil.PE.ByteBuffer resources)
		{
			global::Mono.Cecil.PE.Section imageResourceSection = this.GetImageResourceSection();
			uint num = resources.ReadUInt32();
			resources.position -= 4;
			resources.WriteUInt32(num - imageResourceSection.VirtualAddress + this.rsrc.VirtualAddress);
		}

		// Token: 0x04000525 RID: 1317
		private const uint pe_header_size = 0x178U;

		// Token: 0x04000526 RID: 1318
		private const uint section_header_size = 0x28U;

		// Token: 0x04000527 RID: 1319
		private const uint file_alignment = 0x200U;

		// Token: 0x04000528 RID: 1320
		private const uint section_alignment = 0x2000U;

		// Token: 0x04000529 RID: 1321
		private const ulong image_base = 0x400000UL;

		// Token: 0x0400052A RID: 1322
		internal const uint text_rva = 0x2000U;

		// Token: 0x0400052B RID: 1323
		private readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x0400052C RID: 1324
		private readonly global::Mono.Cecil.MetadataBuilder metadata;

		// Token: 0x0400052D RID: 1325
		private readonly global::Mono.Cecil.PE.TextMap text_map;

		// Token: 0x0400052E RID: 1326
		private global::Mono.Cecil.Cil.ImageDebugDirectory debug_directory;

		// Token: 0x0400052F RID: 1327
		private byte[] debug_data;

		// Token: 0x04000530 RID: 1328
		private global::Mono.Cecil.PE.ByteBuffer win32_resources;

		// Token: 0x04000531 RID: 1329
		private readonly bool pe64;

		// Token: 0x04000532 RID: 1330
		private readonly uint time_stamp;

		// Token: 0x04000533 RID: 1331
		internal global::Mono.Cecil.PE.Section text;

		// Token: 0x04000534 RID: 1332
		internal global::Mono.Cecil.PE.Section rsrc;

		// Token: 0x04000535 RID: 1333
		internal global::Mono.Cecil.PE.Section reloc;

		// Token: 0x04000536 RID: 1334
		private ushort sections;
	}
}
