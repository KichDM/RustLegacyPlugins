using System;
using System.Runtime.Serialization;

// Token: 0x02000156 RID: 342
[global::System.Serializable]
public class NonAIRootControllableException : global::InstantiateControllableException
{
	// Token: 0x06000962 RID: 2402 RVA: 0x00027BEC File Offset: 0x00025DEC
	public NonAIRootControllableException()
	{
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x00027BF4 File Offset: 0x00025DF4
	public NonAIRootControllableException(string message) : base(message)
	{
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00027C00 File Offset: 0x00025E00
	public NonAIRootControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x00027C0C File Offset: 0x00025E0C
	protected NonAIRootControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
