using System;
using System.Runtime.Serialization;

// Token: 0x0200041E RID: 1054
[global::System.Serializable]
public class NetMainPrefabNameException : global::System.ArgumentOutOfRangeException
{
	// Token: 0x060024A3 RID: 9379 RVA: 0x0008B8DC File Offset: 0x00089ADC
	public NetMainPrefabNameException()
	{
	}

	// Token: 0x060024A4 RID: 9380 RVA: 0x0008B8E4 File Offset: 0x00089AE4
	public NetMainPrefabNameException(string parameter) : base(parameter)
	{
	}

	// Token: 0x060024A5 RID: 9381 RVA: 0x0008B8F0 File Offset: 0x00089AF0
	public NetMainPrefabNameException(string parameter, string message) : base(parameter, message)
	{
	}

	// Token: 0x060024A6 RID: 9382 RVA: 0x0008B8FC File Offset: 0x00089AFC
	public NetMainPrefabNameException(string parameter, string value, string message) : base(parameter, value, message)
	{
	}

	// Token: 0x060024A7 RID: 9383 RVA: 0x0008B908 File Offset: 0x00089B08
	public NetMainPrefabNameException(string message, global::System.Exception inner) : base(message, inner)
	{
	}

	// Token: 0x060024A8 RID: 9384 RVA: 0x0008B914 File Offset: 0x00089B14
	protected NetMainPrefabNameException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
	{
	}
}
