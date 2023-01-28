using System;
using Mono.Cecil.Binary;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000077 RID: 119
	public class MetadataFormatException : global::Mono.Cecil.Binary.ImageFormatException
	{
		// Token: 0x0600051C RID: 1308 RVA: 0x0000C6C5 File Offset: 0x0000A8C5
		internal MetadataFormatException()
		{
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000C6CD File Offset: 0x0000A8CD
		internal MetadataFormatException(string message) : base(message)
		{
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0000C6D6 File Offset: 0x0000A8D6
		internal MetadataFormatException(string message, params string[] parameters) : base(string.Format(message, parameters))
		{
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0000C6E5 File Offset: 0x0000A8E5
		internal MetadataFormatException(string message, global::System.Exception inner) : base(message, inner)
		{
		}
	}
}
