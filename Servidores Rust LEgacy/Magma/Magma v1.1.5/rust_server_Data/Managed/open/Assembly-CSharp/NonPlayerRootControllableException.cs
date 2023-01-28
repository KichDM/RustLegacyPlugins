using System;
using System.Runtime.Serialization;

// Token: 0x02000155 RID: 341
[global::System.Serializable]
public class NonPlayerRootControllableException : global::InstantiateControllableException
{
	// Token: 0x0600095E RID: 2398 RVA: 0x00027BC0 File Offset: 0x00025DC0
	public NonPlayerRootControllableException()
	{
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x00027BC8 File Offset: 0x00025DC8
	public NonPlayerRootControllableException(string message) : base(message)
	{
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x00027BD4 File Offset: 0x00025DD4
	public NonPlayerRootControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x00027BE0 File Offset: 0x00025DE0
	protected NonPlayerRootControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
