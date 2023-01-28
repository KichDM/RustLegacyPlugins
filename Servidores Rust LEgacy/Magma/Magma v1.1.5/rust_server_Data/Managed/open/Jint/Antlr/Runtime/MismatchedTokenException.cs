using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000AF RID: 175
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class MismatchedTokenException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x06000808 RID: 2056 RVA: 0x00030390 File Offset: 0x0002E590
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException()
		{
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00030398 File Offset: 0x0002E598
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException(string message) : base(message)
		{
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x000303A4 File Offset: 0x0002E5A4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x000303B0 File Offset: 0x0002E5B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException(int expecting, global::Antlr.Runtime.IIntStream input) : this(expecting, input, null)
		{
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x000303BC File Offset: 0x0002E5BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException(int expecting, global::Antlr.Runtime.IIntStream input, global::System.Collections.Generic.IList<string> tokenNames) : base(input)
		{
			this._expecting = expecting;
			if (tokenNames != null)
			{
				this._tokenNames = tokenNames.ToList<string>().AsReadOnly();
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x000303E4 File Offset: 0x0002E5E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException(string message, int expecting, global::Antlr.Runtime.IIntStream input, global::System.Collections.Generic.IList<string> tokenNames) : base(message, input)
		{
			this._expecting = expecting;
			if (tokenNames != null)
			{
				this._tokenNames = tokenNames.ToList<string>().AsReadOnly();
			}
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00030410 File Offset: 0x0002E610
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTokenException(string message, int expecting, global::Antlr.Runtime.IIntStream input, global::System.Collections.Generic.IList<string> tokenNames, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._expecting = expecting;
			if (tokenNames != null)
			{
				this._tokenNames = tokenNames.ToList<string>().AsReadOnly();
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0003043C File Offset: 0x0002E63C
		protected MismatchedTokenException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._expecting = info.GetInt32("Expecting");
			this._tokenNames = new global::System.Collections.ObjectModel.ReadOnlyCollection<string>((string[])info.GetValue("TokenNames", typeof(string[])));
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0003049C File Offset: 0x0002E69C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Expecting
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._expecting;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x000304A4 File Offset: 0x0002E6A4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::System.Collections.ObjectModel.ReadOnlyCollection<string> TokenNames
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._tokenNames;
			}
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x000304AC File Offset: 0x0002E6AC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("Expecting", this._expecting);
			info.AddValue("TokenNames", (this._tokenNames != null) ? this._tokenNames.ToArray<string>() : null);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00030510 File Offset: 0x0002E710
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			int unexpectedType = this.UnexpectedType;
			string text = (this.TokenNames != null && unexpectedType >= 0 && unexpectedType < this.TokenNames.Count) ? this.TokenNames[unexpectedType] : unexpectedType.ToString();
			string text2 = (this.TokenNames != null && this.Expecting >= 0 && this.Expecting < this.TokenNames.Count) ? this.TokenNames[this.Expecting] : this.Expecting.ToString();
			return string.Concat(new string[]
			{
				"MismatchedTokenException(",
				text,
				"!=",
				text2,
				")"
			});
		}

		// Token: 0x0400039F RID: 927
		private readonly int _expecting;

		// Token: 0x040003A0 RID: 928
		private readonly global::System.Collections.ObjectModel.ReadOnlyCollection<string> _tokenNames;
	}
}
