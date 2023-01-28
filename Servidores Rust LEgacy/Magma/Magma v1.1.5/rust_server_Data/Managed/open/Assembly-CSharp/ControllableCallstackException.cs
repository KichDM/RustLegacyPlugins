using System;
using System.Runtime.Serialization;

// Token: 0x02000153 RID: 339
[global::System.Serializable]
public class ControllableCallstackException : global::System.InvalidOperationException
{
	// Token: 0x06000956 RID: 2390 RVA: 0x00027B68 File Offset: 0x00025D68
	public ControllableCallstackException()
	{
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x00027B70 File Offset: 0x00025D70
	public ControllableCallstackException(string message) : base(message)
	{
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x00027B7C File Offset: 0x00025D7C
	public ControllableCallstackException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x00027B88 File Offset: 0x00025D88
	protected ControllableCallstackException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
