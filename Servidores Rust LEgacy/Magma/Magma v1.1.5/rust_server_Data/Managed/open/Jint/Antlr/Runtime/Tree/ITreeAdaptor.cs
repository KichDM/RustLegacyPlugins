using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000BE RID: 190
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITreeAdaptor
	{
		// Token: 0x060008BB RID: 2235
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Create(global::Antlr.Runtime.IToken payload);

		// Token: 0x060008BC RID: 2236
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Create(int tokenType, global::Antlr.Runtime.IToken fromToken);

		// Token: 0x060008BD RID: 2237
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Create(int tokenType, global::Antlr.Runtime.IToken fromToken, string text);

		// Token: 0x060008BE RID: 2238
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Create(global::Antlr.Runtime.IToken fromToken, string text);

		// Token: 0x060008BF RID: 2239
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Create(int tokenType, string text);

		// Token: 0x060008C0 RID: 2240
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DupNode(object treeNode);

		// Token: 0x060008C1 RID: 2241
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DupNode(int type, object treeNode);

		// Token: 0x060008C2 RID: 2242
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DupNode(object treeNode, string text);

		// Token: 0x060008C3 RID: 2243
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DupNode(int type, object treeNode, string text);

		// Token: 0x060008C4 RID: 2244
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DupTree(object tree);

		// Token: 0x060008C5 RID: 2245
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Nil();

		// Token: 0x060008C6 RID: 2246
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object ErrorNode(global::Antlr.Runtime.ITokenStream input, global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop, global::Antlr.Runtime.RecognitionException e);

		// Token: 0x060008C7 RID: 2247
		[global::System.Runtime.InteropServices.ComVisible(false)]
		bool IsNil(object tree);

		// Token: 0x060008C8 RID: 2248
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void AddChild(object t, object child);

		// Token: 0x060008C9 RID: 2249
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object BecomeRoot(object newRoot, object oldRoot);

		// Token: 0x060008CA RID: 2250
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object RulePostProcessing(object root);

		// Token: 0x060008CB RID: 2251
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int GetUniqueID(object node);

		// Token: 0x060008CC RID: 2252
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object BecomeRoot(global::Antlr.Runtime.IToken newRoot, object oldRoot);

		// Token: 0x060008CD RID: 2253
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int GetType(object t);

		// Token: 0x060008CE RID: 2254
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetType(object t, int type);

		// Token: 0x060008CF RID: 2255
		[global::System.Runtime.InteropServices.ComVisible(false)]
		string GetText(object t);

		// Token: 0x060008D0 RID: 2256
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetText(object t, string text);

		// Token: 0x060008D1 RID: 2257
		[global::System.Runtime.InteropServices.ComVisible(false)]
		global::Antlr.Runtime.IToken GetToken(object t);

		// Token: 0x060008D2 RID: 2258
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetTokenBoundaries(object t, global::Antlr.Runtime.IToken startToken, global::Antlr.Runtime.IToken stopToken);

		// Token: 0x060008D3 RID: 2259
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int GetTokenStartIndex(object t);

		// Token: 0x060008D4 RID: 2260
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int GetTokenStopIndex(object t);

		// Token: 0x060008D5 RID: 2261
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object GetChild(object t, int i);

		// Token: 0x060008D6 RID: 2262
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetChild(object t, int i, object child);

		// Token: 0x060008D7 RID: 2263
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object DeleteChild(object t, int i);

		// Token: 0x060008D8 RID: 2264
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int GetChildCount(object t);

		// Token: 0x060008D9 RID: 2265
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object GetParent(object t);

		// Token: 0x060008DA RID: 2266
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetParent(object t, object parent);

		// Token: 0x060008DB RID: 2267
		[global::System.Runtime.InteropServices.ComVisible(false)]
		int GetChildIndex(object t);

		// Token: 0x060008DC RID: 2268
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void SetChildIndex(object t, int index);

		// Token: 0x060008DD RID: 2269
		[global::System.Runtime.InteropServices.ComVisible(false)]
		void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t);
	}
}
