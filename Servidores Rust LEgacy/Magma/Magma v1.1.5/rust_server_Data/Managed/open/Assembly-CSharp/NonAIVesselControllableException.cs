using System;
using System.Runtime.Serialization;

// Token: 0x0200015A RID: 346
[global::System.Serializable]
public class NonAIVesselControllableException : global::InstantiateControllableException
{
	// Token: 0x06000972 RID: 2418 RVA: 0x00027C9C File Offset: 0x00025E9C
	public NonAIVesselControllableException()
	{
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x00027CA4 File Offset: 0x00025EA4
	public NonAIVesselControllableException(string message) : base(message)
	{
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x00027CB0 File Offset: 0x00025EB0
	public NonAIVesselControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x00027CBC File Offset: 0x00025EBC
	protected NonAIVesselControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
