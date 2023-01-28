using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000CC RID: 204
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RewriteEarlyExitException : global::Antlr.Runtime.Tree.RewriteCardinalityException
	{
		// Token: 0x06000992 RID: 2450 RVA: 0x00033EA0 File Offset: 0x000320A0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEarlyExitException()
		{
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00033EA8 File Offset: 0x000320A8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEarlyExitException(string elementDescription) : base(elementDescription)
		{
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00033EB4 File Offset: 0x000320B4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEarlyExitException(string elementDescription, global::System.Exception innerException) : base(elementDescription, innerException)
		{
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00033EC0 File Offset: 0x000320C0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEarlyExitException(string message, string elementDescription) : base(message, elementDescription)
		{
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00033ECC File Offset: 0x000320CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteEarlyExitException(string message, string elementDescription, global::System.Exception innerException) : base(message, elementDescription, innerException)
		{
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00033ED8 File Offset: 0x000320D8
		protected RewriteEarlyExitException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}
}
