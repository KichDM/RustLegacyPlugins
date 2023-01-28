using System;
using System.Runtime.Serialization;

// Token: 0x02000159 RID: 345
[global::System.Serializable]
public class NonVesselControllableException : global::InstantiateControllableException
{
	// Token: 0x0600096E RID: 2414 RVA: 0x00027C70 File Offset: 0x00025E70
	public NonVesselControllableException()
	{
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x00027C78 File Offset: 0x00025E78
	public NonVesselControllableException(string message) : base(message)
	{
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x00027C84 File Offset: 0x00025E84
	public NonVesselControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x00027C90 File Offset: 0x00025E90
	protected NonVesselControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
