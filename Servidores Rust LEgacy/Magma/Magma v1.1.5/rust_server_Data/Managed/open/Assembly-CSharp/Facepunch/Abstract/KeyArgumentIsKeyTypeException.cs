using System;
using System.Runtime.Serialization;

namespace Facepunch.Abstract
{
	// Token: 0x02000213 RID: 531
	[global::System.Serializable]
	internal class KeyArgumentIsKeyTypeException : global::System.ArgumentOutOfRangeException
	{
		// Token: 0x06000E6F RID: 3695 RVA: 0x00037820 File Offset: 0x00035A20
		public KeyArgumentIsKeyTypeException()
		{
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x00037828 File Offset: 0x00035A28
		public KeyArgumentIsKeyTypeException(string parameterName) : base(parameterName)
		{
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00037834 File Offset: 0x00035A34
		public KeyArgumentIsKeyTypeException(string parameterName, string message) : base(parameterName, message)
		{
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x00037840 File Offset: 0x00035A40
		public KeyArgumentIsKeyTypeException(string message, global::System.Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x0003784C File Offset: 0x00035A4C
		protected KeyArgumentIsKeyTypeException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}
}
