using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000AD RID: 173
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class MismatchedNotSetException : global::Antlr.Runtime.MismatchedSetException
	{
		// Token: 0x060007F5 RID: 2037 RVA: 0x00030184 File Offset: 0x0002E384
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedNotSetException()
		{
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0003018C File Offset: 0x0002E38C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedNotSetException(string message) : base(message)
		{
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00030198 File Offset: 0x0002E398
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedNotSetException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x000301A4 File Offset: 0x0002E3A4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedNotSetException(global::Antlr.Runtime.BitSet expecting, global::Antlr.Runtime.IIntStream input) : base(expecting, input)
		{
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x000301B0 File Offset: 0x0002E3B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedNotSetException(string message, global::Antlr.Runtime.BitSet expecting, global::Antlr.Runtime.IIntStream input) : base(message, expecting, input)
		{
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x000301BC File Offset: 0x0002E3BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedNotSetException(string message, global::Antlr.Runtime.BitSet expecting, global::Antlr.Runtime.IIntStream input, global::System.Exception innerException) : base(message, expecting, input, innerException)
		{
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x000301CC File Offset: 0x0002E3CC
		protected MismatchedNotSetException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x000301D8 File Offset: 0x0002E3D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"MismatchedNotSetException(",
				this.UnexpectedType,
				"!=",
				base.Expecting,
				")"
			});
		}
	}
}
