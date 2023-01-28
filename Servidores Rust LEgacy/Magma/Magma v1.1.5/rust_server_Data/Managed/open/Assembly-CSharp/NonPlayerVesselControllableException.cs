using System;
using System.Runtime.Serialization;

// Token: 0x0200015B RID: 347
[global::System.Serializable]
public class NonPlayerVesselControllableException : global::InstantiateControllableException
{
	// Token: 0x06000976 RID: 2422 RVA: 0x00027CC8 File Offset: 0x00025EC8
	public NonPlayerVesselControllableException()
	{
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x00027CD0 File Offset: 0x00025ED0
	public NonPlayerVesselControllableException(string message) : base(message)
	{
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x00027CDC File Offset: 0x00025EDC
	public NonPlayerVesselControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x00027CE8 File Offset: 0x00025EE8
	protected NonPlayerVesselControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
