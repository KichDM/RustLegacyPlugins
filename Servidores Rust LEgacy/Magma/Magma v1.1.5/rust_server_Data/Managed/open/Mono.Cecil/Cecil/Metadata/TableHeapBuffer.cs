using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000097 RID: 151
	internal sealed class TableHeapBuffer : global::Mono.Cecil.Metadata.HeapBuffer
	{
		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x0000FE59 File Offset: 0x0000E059
		public override bool IsEmpty
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0000FE5C File Offset: 0x0000E05C
		public TableHeapBuffer(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataBuilder metadata) : base(0x18)
		{
			this.module = module;
			this.metadata = metadata;
			this.counter = new global::System.Func<global::Mono.Cecil.Metadata.Table, int>(this.GetTableLength);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0000FEAC File Offset: 0x0000E0AC
		private int GetTableLength(global::Mono.Cecil.Metadata.Table table)
		{
			global::Mono.Cecil.MetadataTable metadataTable = this.tables[(int)table];
			if (metadataTable == null)
			{
				return 0;
			}
			return metadataTable.Length;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0000FED0 File Offset: 0x0000E0D0
		public TTable GetTable<TTable>(global::Mono.Cecil.Metadata.Table table) where TTable : global::Mono.Cecil.MetadataTable, new()
		{
			TTable ttable = (TTable)((object)this.tables[(int)table]);
			if (ttable != null)
			{
				return ttable;
			}
			ttable = global::System.Activator.CreateInstance<TTable>();
			this.tables[(int)table] = ttable;
			return ttable;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0000FF0A File Offset: 0x0000E10A
		public void WriteBySize(uint value, int size)
		{
			if (size == 4)
			{
				base.WriteUInt32(value);
				return;
			}
			base.WriteUInt16((ushort)value);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0000FF20 File Offset: 0x0000E120
		public void WriteBySize(uint value, bool large)
		{
			if (large)
			{
				base.WriteUInt32(value);
				return;
			}
			base.WriteUInt16((ushort)value);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0000FF35 File Offset: 0x0000E135
		public void WriteString(uint @string)
		{
			this.WriteBySize(@string, this.large_string);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0000FF44 File Offset: 0x0000E144
		public void WriteBlob(uint blob)
		{
			this.WriteBySize(blob, this.large_blob);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0000FF54 File Offset: 0x0000E154
		public void WriteRID(uint rid, global::Mono.Cecil.Metadata.Table table)
		{
			global::Mono.Cecil.MetadataTable metadataTable = this.tables[(int)table];
			this.WriteBySize(rid, metadataTable != null && metadataTable.IsLarge);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0000FF80 File Offset: 0x0000E180
		private int GetCodedIndexSize(global::Mono.Cecil.Metadata.CodedIndex coded_index)
		{
			int num = this.coded_index_sizes[(int)coded_index];
			if (num != 0)
			{
				return num;
			}
			return this.coded_index_sizes[(int)coded_index] = coded_index.GetSize(this.counter);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0000FFB4 File Offset: 0x0000E1B4
		public void WriteCodedRID(uint rid, global::Mono.Cecil.Metadata.CodedIndex coded_index)
		{
			this.WriteBySize(rid, this.GetCodedIndexSize(coded_index));
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
		public void WriteTableHeap()
		{
			base.WriteUInt32(0U);
			base.WriteByte(this.GetTableHeapVersion());
			base.WriteByte(0);
			base.WriteByte(this.GetHeapSizes());
			base.WriteByte(0xA);
			base.WriteUInt64(this.GetValid());
			base.WriteUInt64(0x16003301FA00UL);
			this.WriteRowCount();
			this.WriteTables();
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00010028 File Offset: 0x0000E228
		private void WriteRowCount()
		{
			for (int i = 0; i < this.tables.Length; i++)
			{
				global::Mono.Cecil.MetadataTable metadataTable = this.tables[i];
				if (metadataTable != null && metadataTable.Length != 0)
				{
					base.WriteUInt32((uint)metadataTable.Length);
				}
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00010068 File Offset: 0x0000E268
		private void WriteTables()
		{
			for (int i = 0; i < this.tables.Length; i++)
			{
				global::Mono.Cecil.MetadataTable metadataTable = this.tables[i];
				if (metadataTable != null && metadataTable.Length != 0)
				{
					metadataTable.Write(this);
				}
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x000100A4 File Offset: 0x0000E2A4
		private ulong GetValid()
		{
			ulong num = 0UL;
			for (int i = 0; i < this.tables.Length; i++)
			{
				global::Mono.Cecil.MetadataTable metadataTable = this.tables[i];
				if (metadataTable != null && metadataTable.Length != 0)
				{
					metadataTable.Sort();
					num |= 1UL << i;
				}
			}
			return num;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000100EC File Offset: 0x0000E2EC
		private byte GetHeapSizes()
		{
			byte b = 0;
			if (this.metadata.string_heap.IsLarge)
			{
				this.large_string = true;
				b |= 1;
			}
			if (this.metadata.blob_heap.IsLarge)
			{
				this.large_blob = true;
				b |= 4;
			}
			return b;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00010138 File Offset: 0x0000E338
		private byte GetTableHeapVersion()
		{
			switch (this.module.Runtime)
			{
			case global::Mono.Cecil.TargetRuntime.Net_1_0:
			case global::Mono.Cecil.TargetRuntime.Net_1_1:
				return 1;
			default:
				return 2;
			}
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00010164 File Offset: 0x0000E364
		public void FixupData(uint data_rva)
		{
			global::Mono.Cecil.FieldRVATable table = this.GetTable<global::Mono.Cecil.FieldRVATable>(global::Mono.Cecil.Metadata.Table.FieldRVA);
			if (table.length == 0)
			{
				return;
			}
			int num = this.GetTable<global::Mono.Cecil.FieldTable>(global::Mono.Cecil.Metadata.Table.Field).IsLarge ? 4 : 2;
			int position = this.position;
			this.position = table.position;
			for (int i = 0; i < table.length; i++)
			{
				uint num2 = base.ReadUInt32();
				this.position -= 4;
				base.WriteUInt32(num2 + data_rva);
				this.position += num;
			}
			this.position = position;
		}

		// Token: 0x040004CF RID: 1231
		private readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x040004D0 RID: 1232
		private readonly global::Mono.Cecil.MetadataBuilder metadata;

		// Token: 0x040004D1 RID: 1233
		internal global::Mono.Cecil.MetadataTable[] tables = new global::Mono.Cecil.MetadataTable[0x2D];

		// Token: 0x040004D2 RID: 1234
		private bool large_string;

		// Token: 0x040004D3 RID: 1235
		private bool large_blob;

		// Token: 0x040004D4 RID: 1236
		private readonly int[] coded_index_sizes = new int[0xD];

		// Token: 0x040004D5 RID: 1237
		private readonly global::System.Func<global::Mono.Cecil.Metadata.Table, int> counter;
	}
}
