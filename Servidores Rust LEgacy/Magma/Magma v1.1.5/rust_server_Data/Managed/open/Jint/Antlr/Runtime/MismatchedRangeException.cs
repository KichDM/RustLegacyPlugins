using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000AE RID: 174
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class MismatchedRangeException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x060007FD RID: 2045 RVA: 0x00030228 File Offset: 0x0002E428
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedRangeException()
		{
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00030230 File Offset: 0x0002E430
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedRangeException(string message) : base(message)
		{
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0003023C File Offset: 0x0002E43C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedRangeException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00030248 File Offset: 0x0002E448
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedRangeException(int a, int b, global::Antlr.Runtime.IIntStream input) : base(input)
		{
			this._a = a;
			this._b = b;
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00030260 File Offset: 0x0002E460
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedRangeException(string message, int a, int b, global::Antlr.Runtime.IIntStream input) : base(message, input)
		{
			this._a = a;
			this._b = b;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0003027C File Offset: 0x0002E47C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedRangeException(string message, int a, int b, global::Antlr.Runtime.IIntStream input, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._a = a;
			this._b = b;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00030298 File Offset: 0x0002E498
		protected MismatchedRangeException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._a = info.GetInt32("A");
			this._b = info.GetInt32("B");
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x000302D8 File Offset: 0x0002E4D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int A
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._a;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x000302E0 File Offset: 0x0002E4E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int B
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._b;
			}
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x000302E8 File Offset: 0x0002E4E8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("A", this._a);
			info.AddValue("B", this._b);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00030328 File Offset: 0x0002E528
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"MismatchedRangeException(",
				this.UnexpectedType,
				" not in [",
				this.A,
				",",
				this.B,
				"])"
			});
		}

		// Token: 0x0400039D RID: 925
		private readonly int _a;

		// Token: 0x0400039E RID: 926
		private readonly int _b;
	}
}
