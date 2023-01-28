using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000B2 RID: 178
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class NoViableAltException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x06000828 RID: 2088 RVA: 0x00030820 File Offset: 0x0002EA20
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException()
		{
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00030828 File Offset: 0x0002EA28
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException(string grammarDecisionDescription)
		{
			this._grammarDecisionDescription = grammarDecisionDescription;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00030838 File Offset: 0x0002EA38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException(string message, string grammarDecisionDescription) : base(message)
		{
			this._grammarDecisionDescription = grammarDecisionDescription;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00030848 File Offset: 0x0002EA48
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException(string message, string grammarDecisionDescription, global::System.Exception innerException) : base(message, innerException)
		{
			this._grammarDecisionDescription = grammarDecisionDescription;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0003085C File Offset: 0x0002EA5C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException(string grammarDecisionDescription, int decisionNumber, int stateNumber, global::Antlr.Runtime.IIntStream input) : base(input)
		{
			this._grammarDecisionDescription = grammarDecisionDescription;
			this._decisionNumber = decisionNumber;
			this._stateNumber = stateNumber;
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0003087C File Offset: 0x0002EA7C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException(string message, string grammarDecisionDescription, int decisionNumber, int stateNumber, global::Antlr.Runtime.IIntStream input) : base(message, input)
		{
			this._grammarDecisionDescription = grammarDecisionDescription;
			this._decisionNumber = decisionNumber;
			this._stateNumber = stateNumber;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x000308A0 File Offset: 0x0002EAA0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public NoViableAltException(string message, string grammarDecisionDescription, int decisionNumber, int stateNumber, global::Antlr.Runtime.IIntStream input, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._grammarDecisionDescription = grammarDecisionDescription;
			this._decisionNumber = decisionNumber;
			this._stateNumber = stateNumber;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x000308C4 File Offset: 0x0002EAC4
		protected NoViableAltException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._grammarDecisionDescription = info.GetString("GrammarDecisionDescription");
			this._decisionNumber = info.GetInt32("DecisionNumber");
			this._stateNumber = info.GetInt32("StateNumber");
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x00030924 File Offset: 0x0002EB24
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int DecisionNumber
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._decisionNumber;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0003092C File Offset: 0x0002EB2C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string GrammarDecisionDescription
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._grammarDecisionDescription;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x00030934 File Offset: 0x0002EB34
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int StateNumber
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._stateNumber;
			}
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0003093C File Offset: 0x0002EB3C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("GrammarDecisionDescription", this._grammarDecisionDescription);
			info.AddValue("DecisionNumber", this._decisionNumber);
			info.AddValue("StateNumber", this._stateNumber);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0003099C File Offset: 0x0002EB9C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (base.Input is global::Antlr.Runtime.ICharStream)
			{
				return string.Concat(new object[]
				{
					"NoViableAltException('",
					(char)this.UnexpectedType,
					"'@[",
					this.GrammarDecisionDescription,
					"])"
				});
			}
			return string.Concat(new object[]
			{
				"NoViableAltException(",
				this.UnexpectedType,
				"@[",
				this.GrammarDecisionDescription,
				"])"
			});
		}

		// Token: 0x040003A3 RID: 931
		private readonly string _grammarDecisionDescription;

		// Token: 0x040003A4 RID: 932
		private readonly int _decisionNumber;

		// Token: 0x040003A5 RID: 933
		private readonly int _stateNumber;
	}
}
