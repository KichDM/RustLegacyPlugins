using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x0200008D RID: 141
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ICharStream : global::Antlr.Runtime.IIntStream
	{
		// Token: 0x0600062A RID: 1578
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string Substring(int start, int length);

		// Token: 0x0600062B RID: 1579
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int LT(int i);

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600062C RID: 1580
		// (set) Token: 0x0600062D RID: 1581
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Line { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600062E RID: 1582
		// (set) Token: 0x0600062F RID: 1583
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int CharPositionInLine { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }
	}
}
