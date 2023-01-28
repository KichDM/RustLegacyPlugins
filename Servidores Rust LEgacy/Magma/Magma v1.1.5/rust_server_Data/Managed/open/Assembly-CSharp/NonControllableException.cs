using System;
using System.Runtime.Serialization;

// Token: 0x02000158 RID: 344
[global::System.Serializable]
public class NonControllableException : global::InstantiateControllableException
{
	// Token: 0x0600096A RID: 2410 RVA: 0x00027C44 File Offset: 0x00025E44
	public NonControllableException()
	{
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x00027C4C File Offset: 0x00025E4C
	public NonControllableException(string message) : base(message)
	{
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x00027C58 File Offset: 0x00025E58
	public NonControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x00027C64 File Offset: 0x00025E64
	protected NonControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
