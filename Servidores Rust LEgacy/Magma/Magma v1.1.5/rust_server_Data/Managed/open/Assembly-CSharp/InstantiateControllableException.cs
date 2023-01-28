using System;
using System.Runtime.Serialization;

// Token: 0x02000154 RID: 340
[global::System.Serializable]
public abstract class InstantiateControllableException : global::System.ArgumentException
{
	// Token: 0x0600095A RID: 2394 RVA: 0x00027B94 File Offset: 0x00025D94
	public InstantiateControllableException()
	{
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x00027B9C File Offset: 0x00025D9C
	public InstantiateControllableException(string message) : base(message)
	{
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x00027BA8 File Offset: 0x00025DA8
	public InstantiateControllableException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x00027BB4 File Offset: 0x00025DB4
	protected InstantiateControllableException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
