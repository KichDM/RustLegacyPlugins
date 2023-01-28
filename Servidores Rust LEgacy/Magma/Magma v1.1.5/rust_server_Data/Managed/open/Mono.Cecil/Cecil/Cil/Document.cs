using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x020000BA RID: 186
	public sealed class Document
	{
		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x000137F3 File Offset: 0x000119F3
		// (set) Token: 0x06000763 RID: 1891 RVA: 0x000137FB File Offset: 0x000119FB
		public string Url
		{
			get
			{
				return this.url;
			}
			set
			{
				this.url = value;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x00013804 File Offset: 0x00011A04
		// (set) Token: 0x06000765 RID: 1893 RVA: 0x0001380C File Offset: 0x00011A0C
		public global::Mono.Cecil.Cil.DocumentType Type
		{
			get
			{
				return (global::Mono.Cecil.Cil.DocumentType)this.type;
			}
			set
			{
				this.type = (byte)value;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00013816 File Offset: 0x00011A16
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x0001381E File Offset: 0x00011A1E
		public global::Mono.Cecil.Cil.DocumentHashAlgorithm HashAlgorithm
		{
			get
			{
				return (global::Mono.Cecil.Cil.DocumentHashAlgorithm)this.hash_algorithm;
			}
			set
			{
				this.hash_algorithm = (byte)value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x00013828 File Offset: 0x00011A28
		// (set) Token: 0x06000769 RID: 1897 RVA: 0x00013830 File Offset: 0x00011A30
		public global::Mono.Cecil.Cil.DocumentLanguage Language
		{
			get
			{
				return (global::Mono.Cecil.Cil.DocumentLanguage)this.language;
			}
			set
			{
				this.language = (byte)value;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0001383A File Offset: 0x00011A3A
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x00013842 File Offset: 0x00011A42
		public global::Mono.Cecil.Cil.DocumentLanguageVendor LanguageVendor
		{
			get
			{
				return (global::Mono.Cecil.Cil.DocumentLanguageVendor)this.language_vendor;
			}
			set
			{
				this.language_vendor = (byte)value;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0001384C File Offset: 0x00011A4C
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x00013854 File Offset: 0x00011A54
		public byte[] Hash
		{
			get
			{
				return this.hash;
			}
			set
			{
				this.hash = value;
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0001385D File Offset: 0x00011A5D
		public Document(string url)
		{
			this.url = url;
			this.hash = global::Mono.Empty<byte>.Array;
		}

		// Token: 0x040005AB RID: 1451
		private string url;

		// Token: 0x040005AC RID: 1452
		private byte type;

		// Token: 0x040005AD RID: 1453
		private byte hash_algorithm;

		// Token: 0x040005AE RID: 1454
		private byte language;

		// Token: 0x040005AF RID: 1455
		private byte language_vendor;

		// Token: 0x040005B0 RID: 1456
		private byte[] hash;
	}
}
