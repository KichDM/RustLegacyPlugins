using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C1 RID: 193
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITreeNodeStream : global::Antlr.Runtime.IIntStream
	{
		// Token: 0x170001B3 RID: 435
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object this[int i]
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get;
		}

		// Token: 0x06000909 RID: 2313
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object LT(int k);

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600090A RID: 2314
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object TreeSource { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600090B RID: 2315
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.ITokenStream TokenStream { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600090C RID: 2316
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.Tree.ITreeAdaptor TreeAdaptor { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600090D RID: 2317
		// (set) Token: 0x0600090E RID: 2318
		[global::System.Runtime.InteropServices.ComVisible(false)]
		bool UniqueNavigationNodes { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x0600090F RID: 2319
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string ToString(object start, object stop);

		// Token: 0x06000910 RID: 2320
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t);
	}
}
