using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000B1 RID: 177
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class MissingTokenException : global::Antlr.Runtime.MismatchedTokenException
	{
		// Token: 0x0600081E RID: 2078 RVA: 0x0003070C File Offset: 0x0002E90C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException()
		{
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00030714 File Offset: 0x0002E914
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException(string message) : base(message)
		{
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00030720 File Offset: 0x0002E920
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0003072C File Offset: 0x0002E92C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException(int expecting, global::Antlr.Runtime.IIntStream input, object inserted) : this(expecting, input, inserted, null)
		{
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x00030738 File Offset: 0x0002E938
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException(int expecting, global::Antlr.Runtime.IIntStream input, object inserted, global::System.Collections.Generic.IList<string> tokenNames) : base(expecting, input, tokenNames)
		{
			this._inserted = inserted;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0003074C File Offset: 0x0002E94C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException(string message, int expecting, global::Antlr.Runtime.IIntStream input, object inserted, global::System.Collections.Generic.IList<string> tokenNames) : base(message, expecting, input, tokenNames)
		{
			this._inserted = inserted;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00030764 File Offset: 0x0002E964
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MissingTokenException(string message, int expecting, global::Antlr.Runtime.IIntStream input, object inserted, global::System.Collections.Generic.IList<string> tokenNames, global::System.Exception innerException) : base(message, expecting, input, tokenNames, innerException)
		{
			this._inserted = inserted;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0003077C File Offset: 0x0002E97C
		protected MissingTokenException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x00030788 File Offset: 0x0002E988
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int MissingType
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return base.Expecting;
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00030790 File Offset: 0x0002E990
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (this._inserted != null && base.Token != null)
			{
				return string.Concat(new object[]
				{
					"MissingTokenException(inserted ",
					this._inserted,
					" at ",
					base.Token.Text,
					")"
				});
			}
			if (base.Token != null)
			{
				return "MissingTokenException(at " + base.Token.Text + ")";
			}
			return "MissingTokenException";
		}

		// Token: 0x040003A2 RID: 930
		private readonly object _inserted;
	}
}
