using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000B6 RID: 182
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class RecognizerSharedState
	{
		// Token: 0x06000848 RID: 2120 RVA: 0x00030BA0 File Offset: 0x0002EDA0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognizerSharedState()
		{
			this.following = new global::Antlr.Runtime.BitSet[0x64];
			this._fsp = -1;
			this.lastErrorIndex = -1;
			this.tokenStartCharIndex = -1;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00030BCC File Offset: 0x0002EDCC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognizerSharedState(global::Antlr.Runtime.RecognizerSharedState state)
		{
			if (state == null)
			{
				throw new global::System.ArgumentNullException("state");
			}
			this.following = (global::Antlr.Runtime.BitSet[])state.following.Clone();
			this._fsp = state._fsp;
			this.errorRecovery = state.errorRecovery;
			this.lastErrorIndex = state.lastErrorIndex;
			this.failed = state.failed;
			this.syntaxErrors = state.syntaxErrors;
			this.backtracking = state.backtracking;
			if (state.ruleMemo != null)
			{
				this.ruleMemo = (global::System.Collections.Generic.IDictionary<int, int>[])state.ruleMemo.Clone();
			}
			this.token = state.token;
			this.tokenStartCharIndex = state.tokenStartCharIndex;
			this.tokenStartCharPositionInLine = state.tokenStartCharPositionInLine;
			this.channel = state.channel;
			this.type = state.type;
			this.text = state.text;
		}

		// Token: 0x040003A9 RID: 937
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.BitSet[] following;

		// Token: 0x040003AA RID: 938
		[global::System.CLSCompliant(false)]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int _fsp;

		// Token: 0x040003AB RID: 939
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool errorRecovery;

		// Token: 0x040003AC RID: 940
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int lastErrorIndex;

		// Token: 0x040003AD RID: 941
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool failed;

		// Token: 0x040003AE RID: 942
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int syntaxErrors;

		// Token: 0x040003AF RID: 943
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int backtracking;

		// Token: 0x040003B0 RID: 944
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::System.Collections.Generic.IDictionary<int, int>[] ruleMemo;

		// Token: 0x040003B1 RID: 945
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IToken token;

		// Token: 0x040003B2 RID: 946
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int tokenStartCharIndex;

		// Token: 0x040003B3 RID: 947
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int tokenStartLine;

		// Token: 0x040003B4 RID: 948
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int tokenStartCharPositionInLine;

		// Token: 0x040003B5 RID: 949
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int channel;

		// Token: 0x040003B6 RID: 950
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int type;

		// Token: 0x040003B7 RID: 951
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string text;
	}
}
