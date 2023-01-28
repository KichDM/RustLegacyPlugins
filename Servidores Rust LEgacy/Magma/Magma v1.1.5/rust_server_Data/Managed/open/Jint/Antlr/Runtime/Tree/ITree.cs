using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000BC RID: 188
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITree
	{
		// Token: 0x06000879 RID: 2169
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.Tree.ITree GetChild(int i);

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600087A RID: 2170
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int ChildCount { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600087B RID: 2171
		// (set) Token: 0x0600087C RID: 2172
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.Tree.ITree Parent { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x0600087D RID: 2173
		[global::System.Runtime.InteropServices.ComVisible(false)]
		bool HasAncestor(int ttype);

		// Token: 0x0600087E RID: 2174
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.Tree.ITree GetAncestor(int ttype);

		// Token: 0x0600087F RID: 2175
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::System.Collections.Generic.IList<global::Antlr.Runtime.Tree.ITree> GetAncestors();

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000880 RID: 2176
		// (set) Token: 0x06000881 RID: 2177
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int ChildIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x06000882 RID: 2178
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void FreshenParentAndChildIndexes();

		// Token: 0x06000883 RID: 2179
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void AddChild(global::Antlr.Runtime.Tree.ITree t);

		// Token: 0x06000884 RID: 2180
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetChild(int i, global::Antlr.Runtime.Tree.ITree t);

		// Token: 0x06000885 RID: 2181
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DeleteChild(int i);

		// Token: 0x06000886 RID: 2182
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ReplaceChildren(int startChildIndex, int stopChildIndex, object t);

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000887 RID: 2183
		[global::System.Runtime.InteropServices.ComVisible(false)]
		bool IsNil { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000888 RID: 2184
		// (set) Token: 0x06000889 RID: 2185
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int TokenStartIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600088A RID: 2186
		// (set) Token: 0x0600088B RID: 2187
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int TokenStopIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x0600088C RID: 2188
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.Tree.ITree DupNode();

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600088D RID: 2189
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Type { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600088E RID: 2190
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string Text { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600088F RID: 2191
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int Line { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000890 RID: 2192
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int CharPositionInLine { [global::System.Runtime.InteropServices.ComVisible(false)] get; }

		// Token: 0x06000891 RID: 2193
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string ToStringTree();

		// Token: 0x06000892 RID: 2194
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string ToString();
	}
}
