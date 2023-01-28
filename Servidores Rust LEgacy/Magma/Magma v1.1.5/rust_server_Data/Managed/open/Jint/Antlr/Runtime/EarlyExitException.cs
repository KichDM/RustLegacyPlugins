using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000A1 RID: 161
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class EarlyExitException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x06000771 RID: 1905 RVA: 0x0002EB98 File Offset: 0x0002CD98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public EarlyExitException()
		{
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0002EBA0 File Offset: 0x0002CDA0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public EarlyExitException(string message) : base(message)
		{
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0002EBAC File Offset: 0x0002CDAC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public EarlyExitException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0002EBB8 File Offset: 0x0002CDB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public EarlyExitException(int decisionNumber, global::Antlr.Runtime.IIntStream input) : base(input)
		{
			this._decisionNumber = decisionNumber;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0002EBC8 File Offset: 0x0002CDC8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public EarlyExitException(string message, int decisionNumber, global::Antlr.Runtime.IIntStream input) : base(message, input)
		{
			this._decisionNumber = decisionNumber;
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0002EBDC File Offset: 0x0002CDDC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public EarlyExitException(string message, int decisionNumber, global::Antlr.Runtime.IIntStream input, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._decisionNumber = decisionNumber;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0002EBF0 File Offset: 0x0002CDF0
		protected EarlyExitException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._decisionNumber = info.GetInt32("DecisionNumber");
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0002EC1C File Offset: 0x0002CE1C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int DecisionNumber
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._decisionNumber;
			}
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0002EC24 File Offset: 0x0002CE24
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("DecisionNumber", this.DecisionNumber);
		}

		// Token: 0x04000386 RID: 902
		private readonly int _decisionNumber;
	}
}
