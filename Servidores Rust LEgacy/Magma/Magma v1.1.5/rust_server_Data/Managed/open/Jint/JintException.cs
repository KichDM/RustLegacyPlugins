using System;

namespace Jint
{
	// Token: 0x02000048 RID: 72
	[global::System.Serializable]
	public class JintException : global::System.Exception
	{
		// Token: 0x06000362 RID: 866 RVA: 0x0001F6F4 File Offset: 0x0001D8F4
		public JintException()
		{
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		public JintException(string message) : base(message)
		{
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0001F708 File Offset: 0x0001D908
		public JintException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}
	}
}
