using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x02000090 RID: 144
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class ANTLRReaderStream : global::Antlr.Runtime.ANTLRStringStream
	{
		// Token: 0x0600064B RID: 1611 RVA: 0x0002BAEC File Offset: 0x00029CEC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRReaderStream(global::System.IO.TextReader r) : this(r, 0x400, 0x400)
		{
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0002BB00 File Offset: 0x00029D00
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRReaderStream(global::System.IO.TextReader r, int size) : this(r, size, 0x400)
		{
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0002BB10 File Offset: 0x00029D10
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ANTLRReaderStream(global::System.IO.TextReader r, int size, int readChunkSize)
		{
			this.Load(r, size, readChunkSize);
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0002BB24 File Offset: 0x00029D24
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Load(global::System.IO.TextReader r, int size, int readChunkSize)
		{
			if (r == null)
			{
				return;
			}
			if (size <= 0)
			{
				size = 0x400;
			}
			if (readChunkSize <= 0)
			{
				readChunkSize = 0x400;
			}
			try
			{
				this.data = r.ReadToEnd().ToCharArray();
				this.n = this.data.Length;
			}
			finally
			{
				r.Close();
			}
		}

		// Token: 0x0400034C RID: 844
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int ReadBufferSize = 0x400;

		// Token: 0x0400034D RID: 845
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int InitialBufferSize = 0x400;
	}
}
