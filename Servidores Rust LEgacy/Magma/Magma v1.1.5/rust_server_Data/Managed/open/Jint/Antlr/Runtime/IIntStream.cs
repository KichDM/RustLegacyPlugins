using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x0200008C RID: 140
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface IIntStream
	{
		// Token: 0x06000620 RID: 1568
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Consume();

		// Token: 0x06000621 RID: 1569
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int LA(int i);

		// Token: 0x06000622 RID: 1570
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Mark();

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000623 RID: 1571
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Index { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x06000624 RID: 1572
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Rewind(int marker);

		// Token: 0x06000625 RID: 1573
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Rewind();

		// Token: 0x06000626 RID: 1574
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Release(int marker);

		// Token: 0x06000627 RID: 1575
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void Seek(int index);

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000628 RID: 1576
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Count { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000629 RID: 1577
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string SourceName { [global::System.Runtime.InteropServices.ComVisible(false)] get; }
	}
}
