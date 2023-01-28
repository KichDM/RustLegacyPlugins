using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C0 RID: 192
	internal sealed class AntlrRuntime_BaseTreeDebugView
	{
		// Token: 0x06000906 RID: 2310 RVA: 0x00032764 File Offset: 0x00030964
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public AntlrRuntime_BaseTreeDebugView(global::Antlr.Runtime.Tree.BaseTree tree)
		{
			this._tree = tree;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x00032774 File Offset: 0x00030974
		[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.RootHidden)]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.Tree.ITree[] Children
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this._tree == null || this._tree.Children == null)
				{
					return null;
				}
				global::Antlr.Runtime.Tree.ITree[] array = new global::Antlr.Runtime.Tree.ITree[this._tree.Children.Count];
				this._tree.Children.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x040003D0 RID: 976
		private readonly global::Antlr.Runtime.Tree.BaseTree _tree;
	}
}
