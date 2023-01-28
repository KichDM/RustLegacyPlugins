using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime
{
	// Token: 0x0200008F RID: 143
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class ANTLRFileStream : global::Antlr.Runtime.ANTLRStringStream
	{
		// Token: 0x06000647 RID: 1607 RVA: 0x0002BA74 File Offset: 0x00029C74
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRFileStream(string fileName) : this(fileName, null)
		{
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0002BA80 File Offset: 0x00029C80
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRFileStream(string fileName, global::System.Text.Encoding encoding)
		{
			this.fileName = fileName;
			this.Load(fileName, encoding);
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0002BA98 File Offset: 0x00029C98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Load(string fileName, global::System.Text.Encoding encoding)
		{
			if (fileName == null)
			{
				return;
			}
			string text;
			if (encoding == null)
			{
				text = global::System.IO.File.ReadAllText(fileName);
			}
			else
			{
				text = global::System.IO.File.ReadAllText(fileName, encoding);
			}
			this.data = text.ToCharArray();
			this.n = this.data.Length;
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0002BAE4 File Offset: 0x00029CE4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string SourceName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.fileName;
			}
		}

		// Token: 0x0400034B RID: 843
		protected string fileName;
	}
}
