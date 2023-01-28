using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000DD RID: 221
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class UnwantedTokenException : global::Antlr.Runtime.MismatchedTokenException
	{
		// Token: 0x06000A19 RID: 2585 RVA: 0x00035898 File Offset: 0x00033A98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException()
		{
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x000358A0 File Offset: 0x00033AA0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException(string message) : base(message)
		{
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x000358AC File Offset: 0x00033AAC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x000358B8 File Offset: 0x00033AB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException(int expecting, global::Antlr.Runtime.IIntStream input) : base(expecting, input)
		{
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x000358C4 File Offset: 0x00033AC4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException(int expecting, global::Antlr.Runtime.IIntStream input, global::System.Collections.Generic.IList<string> tokenNames) : base(expecting, input, tokenNames)
		{
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000358D0 File Offset: 0x00033AD0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException(string message, int expecting, global::Antlr.Runtime.IIntStream input, global::System.Collections.Generic.IList<string> tokenNames) : base(message, expecting, input, tokenNames)
		{
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000358E0 File Offset: 0x00033AE0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public UnwantedTokenException(string message, int expecting, global::Antlr.Runtime.IIntStream input, global::System.Collections.Generic.IList<string> tokenNames, global::System.Exception innerException) : base(message, expecting, input, tokenNames, innerException)
		{
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000358F0 File Offset: 0x00033AF0
		protected UnwantedTokenException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x000358FC File Offset: 0x00033AFC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken UnexpectedToken
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return base.Token;
			}
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00035904 File Offset: 0x00033B04
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			string str = (base.TokenNames != null && base.Expecting >= 0 && base.Expecting < base.TokenNames.Count) ? base.TokenNames[base.Expecting] : base.Expecting.ToString();
			string text = ", expected " + str;
			if (base.Expecting == 0)
			{
				text = "";
			}
			if (base.Token == null)
			{
				return "UnwantedTokenException(found=" + text + ")";
			}
			return "UnwantedTokenException(found=" + base.Token.Text + text + ")";
		}
	}
}
