using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime
{
	// Token: 0x02000091 RID: 145
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class ANTLRInputStream : global::Antlr.Runtime.ANTLRReaderStream
	{
		// Token: 0x0600064F RID: 1615 RVA: 0x0002BB90 File Offset: 0x00029D90
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRInputStream(global::System.IO.Stream input) : this(input, null)
		{
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0002BB9C File Offset: 0x00029D9C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRInputStream(global::System.IO.Stream input, int size) : this(input, size, null)
		{
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0002BBA8 File Offset: 0x00029DA8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRInputStream(global::System.IO.Stream input, global::System.Text.Encoding encoding) : this(input, 0x400, encoding)
		{
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0002BBB8 File Offset: 0x00029DB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRInputStream(global::System.IO.Stream input, int size, global::System.Text.Encoding encoding) : this(input, size, 0x400, encoding)
		{
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0002BBC8 File Offset: 0x00029DC8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRInputStream(global::System.IO.Stream input, int size, int readBufferSize, global::System.Text.Encoding encoding) : base(global::Antlr.Runtime.ANTLRInputStream.GetStreamReader(input, encoding), size, readBufferSize)
		{
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0002BBDC File Offset: 0x00029DDC
		private static global::System.IO.StreamReader GetStreamReader(global::System.IO.Stream input, global::System.Text.Encoding encoding)
		{
			if (encoding != null)
			{
				return new global::System.IO.StreamReader(input, encoding);
			}
			return new global::System.IO.StreamReader(input);
		}
	}
}
