using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000CD RID: 205
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RewriteEmptyStreamException : global::Antlr.Runtime.Tree.RewriteCardinalityException
	{
		// Token: 0x06000998 RID: 2456 RVA: 0x00033EE4 File Offset: 0x000320E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEmptyStreamException()
		{
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00033EEC File Offset: 0x000320EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEmptyStreamException(string elementDescription) : base(elementDescription)
		{
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00033EF8 File Offset: 0x000320F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEmptyStreamException(string elementDescription, global::System.Exception innerException) : base(elementDescription, innerException)
		{
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00033F04 File Offset: 0x00032104
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEmptyStreamException(string message, string elementDescription) : base(message, elementDescription)
		{
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00033F10 File Offset: 0x00032110
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEmptyStreamException(string message, string elementDescription, global::System.Exception innerException) : base(message, elementDescription, innerException)
		{
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x00033F1C File Offset: 0x0003211C
		protected RewriteEmptyStreamException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}
}
