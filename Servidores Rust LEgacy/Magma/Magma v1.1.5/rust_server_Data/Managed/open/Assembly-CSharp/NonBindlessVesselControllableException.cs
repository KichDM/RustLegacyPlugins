using System;
using System.Runtime.Serialization;

// Token: 0x02000157 RID: 343
[global::System.Serializable]
public class NonBindlessVesselControllableException : global::InstantiateControllableException
{
	// Token: 0x06000966 RID: 2406 RVA: 0x00027C18 File Offset: 0x00025E18
	public NonBindlessVesselControllableException()
	{
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00027C20 File Offset: 0x00025E20
	public NonBindlessVesselControllableException(string message) : base(message)
	{
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x00027C2C File Offset: 0x00025E2C
	public NonBindlessVesselControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x00027C38 File Offset: 0x00025E38
	protected NonBindlessVesselControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
