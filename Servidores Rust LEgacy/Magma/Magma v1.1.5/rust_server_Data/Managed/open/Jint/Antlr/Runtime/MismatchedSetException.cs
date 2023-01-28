using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000AC RID: 172
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class MismatchedSetException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x060007EB RID: 2027 RVA: 0x0003006C File Offset: 0x0002E26C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedSetException()
		{
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00030074 File Offset: 0x0002E274
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedSetException(string message) : base(message)
		{
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00030080 File Offset: 0x0002E280
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedSetException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0003008C File Offset: 0x0002E28C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedSetException(global::Antlr.Runtime.BitSet expecting, global::Antlr.Runtime.IIntStream input) : base(input)
		{
			this._expecting = expecting;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0003009C File Offset: 0x0002E29C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedSetException(string message, global::Antlr.Runtime.BitSet expecting, global::Antlr.Runtime.IIntStream input) : base(message, input)
		{
			this._expecting = expecting;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000300B0 File Offset: 0x0002E2B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedSetException(string message, global::Antlr.Runtime.BitSet expecting, global::Antlr.Runtime.IIntStream input, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._expecting = expecting;
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x000300C4 File Offset: 0x0002E2C4
		protected MismatchedSetException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._expecting = (global::Antlr.Runtime.BitSet)info.GetValue("Expecting", typeof(global::Antlr.Runtime.BitSet));
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x00030100 File Offset: 0x0002E300
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.BitSet Expecting
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._expecting;
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00030108 File Offset: 0x0002E308
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("Expecting", this._expecting);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00030134 File Offset: 0x0002E334
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"MismatchedSetException(",
				this.UnexpectedType,
				"!=",
				this.Expecting,
				")"
			});
		}

		// Token: 0x0400039C RID: 924
		private readonly global::Antlr.Runtime.BitSet _expecting;
	}
}
