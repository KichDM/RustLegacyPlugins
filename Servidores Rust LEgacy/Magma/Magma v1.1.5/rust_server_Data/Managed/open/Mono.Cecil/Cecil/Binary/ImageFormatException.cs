using System;

namespace Mono.Cecil.Binary
{
	// Token: 0x02000037 RID: 55
	public class ImageFormatException : global::System.Exception
	{
		// Token: 0x06000316 RID: 790 RVA: 0x000090C1 File Offset: 0x000072C1
		internal ImageFormatException()
		{
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000090C9 File Offset: 0x000072C9
		internal ImageFormatException(string message) : base(message)
		{
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000090D2 File Offset: 0x000072D2
		internal ImageFormatException(string message, params string[] parameters) : base(string.Format(message, parameters))
		{
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000090E1 File Offset: 0x000072E1
		internal ImageFormatException(string message, global::System.Exception inner) : base(message, inner)
		{
		}
	}
}
