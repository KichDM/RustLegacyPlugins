using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x02000078 RID: 120
	public sealed class ReflectionException : global::Mono.Cecil.Metadata.MetadataFormatException
	{
		// Token: 0x06000520 RID: 1312 RVA: 0x0000C6EF File Offset: 0x0000A8EF
		internal ReflectionException()
		{
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000C6F7 File Offset: 0x0000A8F7
		internal ReflectionException(string message) : base(message)
		{
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0000C700 File Offset: 0x0000A900
		internal ReflectionException(string message, params string[] parameters) : base(string.Format(message, parameters))
		{
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0000C70F File Offset: 0x0000A90F
		internal ReflectionException(string message, global::System.Exception inner) : base(message, inner)
		{
		}
	}
}
