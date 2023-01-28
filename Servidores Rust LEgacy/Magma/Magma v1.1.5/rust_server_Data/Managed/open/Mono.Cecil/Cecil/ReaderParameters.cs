using System;
using System.IO;
using Mono.Cecil.Cil;

namespace Mono.Cecil
{
	// Token: 0x02000061 RID: 97
	public sealed class ReaderParameters
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0000A7E4 File Offset: 0x000089E4
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x0000A7EC File Offset: 0x000089EC
		public global::Mono.Cecil.ReadingMode ReadingMode
		{
			get
			{
				return this.reading_mode;
			}
			set
			{
				this.reading_mode = value;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0000A7F5 File Offset: 0x000089F5
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x0000A7FD File Offset: 0x000089FD
		public global::Mono.Cecil.IAssemblyResolver AssemblyResolver
		{
			get
			{
				return this.assembly_resolver;
			}
			set
			{
				this.assembly_resolver = value;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0000A806 File Offset: 0x00008A06
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x0000A80E File Offset: 0x00008A0E
		public global::System.IO.Stream SymbolStream
		{
			get
			{
				return this.symbol_stream;
			}
			set
			{
				this.symbol_stream = value;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000A817 File Offset: 0x00008A17
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x0000A81F File Offset: 0x00008A1F
		public global::Mono.Cecil.Cil.ISymbolReaderProvider SymbolReaderProvider
		{
			get
			{
				return this.symbol_reader_provider;
			}
			set
			{
				this.symbol_reader_provider = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x0000A828 File Offset: 0x00008A28
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x0000A830 File Offset: 0x00008A30
		public bool ReadSymbols
		{
			get
			{
				return this.read_symbols;
			}
			set
			{
				this.read_symbols = value;
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000A839 File Offset: 0x00008A39
		public ReaderParameters() : this(global::Mono.Cecil.ReadingMode.Deferred)
		{
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000A842 File Offset: 0x00008A42
		public ReaderParameters(global::Mono.Cecil.ReadingMode readingMode)
		{
			this.reading_mode = readingMode;
		}

		// Token: 0x040002B2 RID: 690
		private global::Mono.Cecil.ReadingMode reading_mode;

		// Token: 0x040002B3 RID: 691
		private global::Mono.Cecil.IAssemblyResolver assembly_resolver;

		// Token: 0x040002B4 RID: 692
		private global::System.IO.Stream symbol_stream;

		// Token: 0x040002B5 RID: 693
		private global::Mono.Cecil.Cil.ISymbolReaderProvider symbol_reader_provider;

		// Token: 0x040002B6 RID: 694
		private bool read_symbols;
	}
}
