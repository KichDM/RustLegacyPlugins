using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000BA RID: 186
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public static class Tokens<T> where T : global::Antlr.Runtime.IToken, new()
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x00030CE0 File Offset: 0x0002EEE0
		// Note: this type is marked as 'beforefieldinit'.
		static Tokens()
		{
			T endOfFile = (default(T) == null) ? global::System.Activator.CreateInstance<T>() : default(T);
			endOfFile.Type = -1;
			global::Antlr.Runtime.Tokens<T>.EndOfFile = endOfFile;
			T invalid = (default(T) == null) ? global::System.Activator.CreateInstance<T>() : default(T);
			invalid.Type = 0;
			global::Antlr.Runtime.Tokens<T>.Invalid = invalid;
			T skip = (default(T) == null) ? global::System.Activator.CreateInstance<T>() : default(T);
			skip.Type = 0;
			global::Antlr.Runtime.Tokens<T>.Skip = skip;
		}

		// Token: 0x040003C3 RID: 963
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static readonly T EndOfFile;

		// Token: 0x040003C4 RID: 964
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static readonly T Invalid;

		// Token: 0x040003C5 RID: 965
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static readonly T Skip;
	}
}
