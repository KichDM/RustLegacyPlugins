using System;
using System.IO;
using System.Reflection;
using Mono.Cecil.Cil;

namespace Mono.Cecil
{
	// Token: 0x02000063 RID: 99
	public sealed class WriterParameters
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000A8D1 File Offset: 0x00008AD1
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x0000A8D9 File Offset: 0x00008AD9
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000A8E2 File Offset: 0x00008AE2
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x0000A8EA File Offset: 0x00008AEA
		public global::Mono.Cecil.Cil.ISymbolWriterProvider SymbolWriterProvider
		{
			get
			{
				return this.symbol_writer_provider;
			}
			set
			{
				this.symbol_writer_provider = value;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000A8F3 File Offset: 0x00008AF3
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x0000A8FB File Offset: 0x00008AFB
		public bool WriteSymbols
		{
			get
			{
				return this.write_symbols;
			}
			set
			{
				this.write_symbols = value;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000A904 File Offset: 0x00008B04
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x0000A90C File Offset: 0x00008B0C
		public global::System.Reflection.StrongNameKeyPair StrongNameKeyPair
		{
			get
			{
				return this.key_pair;
			}
			set
			{
				this.key_pair = value;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000A915 File Offset: 0x00008B15
		public WriterParameters()
		{
		}

		// Token: 0x040002BB RID: 699
		private global::System.IO.Stream symbol_stream;

		// Token: 0x040002BC RID: 700
		private global::Mono.Cecil.Cil.ISymbolWriterProvider symbol_writer_provider;

		// Token: 0x040002BD RID: 701
		private bool write_symbols;

		// Token: 0x040002BE RID: 702
		private global::System.Reflection.StrongNameKeyPair key_pair;
	}
}
