using System;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;

namespace Mono.Cecil.PE
{
	// Token: 0x02000075 RID: 117
	internal sealed class Image
	{
		// Token: 0x0600050F RID: 1295 RVA: 0x0000C40D File Offset: 0x0000A60D
		public Image()
		{
			this.counter = new global::System.Func<global::Mono.Cecil.Metadata.Table, int>(this.GetTableLength);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0000C434 File Offset: 0x0000A634
		public bool HasTable(global::Mono.Cecil.Metadata.Table table)
		{
			return this.GetTableLength(table) > 0;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0000C440 File Offset: 0x0000A640
		public int GetTableLength(global::Mono.Cecil.Metadata.Table table)
		{
			return (int)this.TableHeap[table].Length;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000C453 File Offset: 0x0000A653
		public int GetTableIndexSize(global::Mono.Cecil.Metadata.Table table)
		{
			if (this.GetTableLength(table) >= 0x10000)
			{
				return 4;
			}
			return 2;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0000C468 File Offset: 0x0000A668
		public int GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex coded_index)
		{
			int num = this.coded_index_sizes[(int)coded_index];
			if (num != 0)
			{
				return num;
			}
			return this.coded_index_sizes[(int)coded_index] = coded_index.GetSize(this.counter);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0000C49C File Offset: 0x0000A69C
		public uint ResolveVirtualAddress(uint rva)
		{
			global::Mono.Cecil.PE.Section sectionAtVirtualAddress = this.GetSectionAtVirtualAddress(rva);
			if (sectionAtVirtualAddress == null)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			return this.ResolveVirtualAddressInSection(rva, sectionAtVirtualAddress);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0000C4C2 File Offset: 0x0000A6C2
		public uint ResolveVirtualAddressInSection(uint rva, global::Mono.Cecil.PE.Section section)
		{
			return rva + section.PointerToRawData - section.VirtualAddress;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000C4D4 File Offset: 0x0000A6D4
		public global::Mono.Cecil.PE.Section GetSection(string name)
		{
			foreach (global::Mono.Cecil.PE.Section section in this.Sections)
			{
				if (section.Name == name)
				{
					return section;
				}
			}
			return null;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0000C50C File Offset: 0x0000A70C
		public global::Mono.Cecil.PE.Section GetSectionAtVirtualAddress(uint rva)
		{
			foreach (global::Mono.Cecil.PE.Section section in this.Sections)
			{
				if (rva >= section.VirtualAddress && rva < section.VirtualAddress + section.SizeOfRawData)
				{
					return section;
				}
			}
			return null;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0000C550 File Offset: 0x0000A750
		public global::Mono.Cecil.Cil.ImageDebugDirectory GetDebugHeader(out byte[] header)
		{
			global::Mono.Cecil.PE.Section sectionAtVirtualAddress = this.GetSectionAtVirtualAddress(this.Debug.VirtualAddress);
			global::Mono.Cecil.PE.ByteBuffer byteBuffer = new global::Mono.Cecil.PE.ByteBuffer(sectionAtVirtualAddress.Data);
			byteBuffer.position = (int)(this.Debug.VirtualAddress - sectionAtVirtualAddress.VirtualAddress);
			global::Mono.Cecil.Cil.ImageDebugDirectory result = new global::Mono.Cecil.Cil.ImageDebugDirectory
			{
				Characteristics = byteBuffer.ReadInt32(),
				TimeDateStamp = byteBuffer.ReadInt32(),
				MajorVersion = byteBuffer.ReadInt16(),
				MinorVersion = byteBuffer.ReadInt16(),
				Type = byteBuffer.ReadInt32(),
				SizeOfData = byteBuffer.ReadInt32(),
				AddressOfRawData = byteBuffer.ReadInt32(),
				PointerToRawData = byteBuffer.ReadInt32()
			};
			byteBuffer.position = (int)((long)result.PointerToRawData - (long)((ulong)sectionAtVirtualAddress.PointerToRawData));
			header = new byte[result.SizeOfData];
			global::System.Buffer.BlockCopy(byteBuffer.buffer, byteBuffer.position, header, 0, header.Length);
			return result;
		}

		// Token: 0x040002F9 RID: 761
		public global::Mono.Cecil.ModuleKind Kind;

		// Token: 0x040002FA RID: 762
		public global::Mono.Cecil.TargetRuntime Runtime;

		// Token: 0x040002FB RID: 763
		public global::Mono.Cecil.TargetArchitecture Architecture;

		// Token: 0x040002FC RID: 764
		public string FileName;

		// Token: 0x040002FD RID: 765
		public global::Mono.Cecil.PE.Section[] Sections;

		// Token: 0x040002FE RID: 766
		public global::Mono.Cecil.PE.Section MetadataSection;

		// Token: 0x040002FF RID: 767
		public uint EntryPointToken;

		// Token: 0x04000300 RID: 768
		public global::Mono.Cecil.ModuleAttributes Attributes;

		// Token: 0x04000301 RID: 769
		public global::Mono.Cecil.PE.DataDirectory Debug;

		// Token: 0x04000302 RID: 770
		public global::Mono.Cecil.PE.DataDirectory Resources;

		// Token: 0x04000303 RID: 771
		public global::Mono.Cecil.Metadata.StringHeap StringHeap;

		// Token: 0x04000304 RID: 772
		public global::Mono.Cecil.Metadata.BlobHeap BlobHeap;

		// Token: 0x04000305 RID: 773
		public global::Mono.Cecil.Metadata.UserStringHeap UserStringHeap;

		// Token: 0x04000306 RID: 774
		public global::Mono.Cecil.Metadata.GuidHeap GuidHeap;

		// Token: 0x04000307 RID: 775
		public global::Mono.Cecil.Metadata.TableHeap TableHeap;

		// Token: 0x04000308 RID: 776
		private readonly int[] coded_index_sizes = new int[0xD];

		// Token: 0x04000309 RID: 777
		private readonly global::System.Func<global::Mono.Cecil.Metadata.Table, int> counter;
	}
}
