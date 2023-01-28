using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000BF RID: 191
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public abstract class BaseTreeAdaptor : global::Antlr.Runtime.Tree.ITreeAdaptor
	{
		// Token: 0x060008DE RID: 2270 RVA: 0x00032148 File Offset: 0x00030348
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Nil()
		{
			return this.Create(null);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00032154 File Offset: 0x00030354
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object ErrorNode(global::Antlr.Runtime.ITokenStream input, global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop, global::Antlr.Runtime.RecognitionException e)
		{
			return new global::Antlr.Runtime.Tree.CommonErrorNode(input, start, stop, e);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00032174 File Offset: 0x00030374
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool IsNil(object tree)
		{
			return ((global::Antlr.Runtime.Tree.ITree)tree).IsNil;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00032184 File Offset: 0x00030384
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DupNode(int type, object treeNode)
		{
			object obj = this.DupNode(treeNode);
			this.SetType(obj, type);
			return obj;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000321A8 File Offset: 0x000303A8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DupNode(object treeNode, string text)
		{
			object obj = this.DupNode(treeNode);
			this.SetText(obj, text);
			return obj;
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x000321CC File Offset: 0x000303CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DupNode(int type, object treeNode, string text)
		{
			object obj = this.DupNode(treeNode);
			this.SetType(obj, type);
			this.SetText(obj, text);
			return obj;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x000321F8 File Offset: 0x000303F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DupTree(object tree)
		{
			return this.DupTree(tree, null);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00032204 File Offset: 0x00030404
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DupTree(object t, object parent)
		{
			if (t == null)
			{
				return null;
			}
			object obj = this.DupNode(t);
			this.SetChildIndex(obj, this.GetChildIndex(t));
			this.SetParent(obj, parent);
			int childCount = this.GetChildCount(t);
			for (int i = 0; i < childCount; i++)
			{
				object child = this.GetChild(t, i);
				object child2 = this.DupTree(child, t);
				this.AddChild(obj, child2);
			}
			return obj;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00032270 File Offset: 0x00030470
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void AddChild(object t, object child)
		{
			if (t != null && child != null)
			{
				((global::Antlr.Runtime.Tree.ITree)t).AddChild((global::Antlr.Runtime.Tree.ITree)child);
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00032290 File Offset: 0x00030490
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object BecomeRoot(object newRoot, object oldRoot)
		{
			global::Antlr.Runtime.Tree.ITree tree = (global::Antlr.Runtime.Tree.ITree)newRoot;
			global::Antlr.Runtime.Tree.ITree t = (global::Antlr.Runtime.Tree.ITree)oldRoot;
			if (oldRoot == null)
			{
				return newRoot;
			}
			if (tree.IsNil)
			{
				int childCount = tree.ChildCount;
				if (childCount == 1)
				{
					tree = tree.GetChild(0);
				}
				else if (childCount > 1)
				{
					throw new global::System.Exception("more than one node as root (TODO: make exception hierarchy)");
				}
			}
			tree.AddChild(t);
			return tree;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x000322F8 File Offset: 0x000304F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object RulePostProcessing(object root)
		{
			global::Antlr.Runtime.Tree.ITree tree = (global::Antlr.Runtime.Tree.ITree)root;
			if (tree != null && tree.IsNil)
			{
				if (tree.ChildCount == 0)
				{
					tree = null;
				}
				else if (tree.ChildCount == 1)
				{
					tree = tree.GetChild(0);
					tree.Parent = null;
					tree.ChildIndex = -1;
				}
			}
			return tree;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00032358 File Offset: 0x00030558
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object BecomeRoot(global::Antlr.Runtime.IToken newRoot, object oldRoot)
		{
			return this.BecomeRoot(this.Create(newRoot), oldRoot);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00032368 File Offset: 0x00030568
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Create(int tokenType, global::Antlr.Runtime.IToken fromToken)
		{
			fromToken = this.CreateToken(fromToken);
			fromToken.Type = tokenType;
			return this.Create(fromToken);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00032394 File Offset: 0x00030594
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Create(int tokenType, global::Antlr.Runtime.IToken fromToken, string text)
		{
			if (fromToken == null)
			{
				return this.Create(tokenType, text);
			}
			fromToken = this.CreateToken(fromToken);
			fromToken.Type = tokenType;
			fromToken.Text = text;
			return this.Create(fromToken);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x000323D4 File Offset: 0x000305D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Create(global::Antlr.Runtime.IToken fromToken, string text)
		{
			if (fromToken == null)
			{
				throw new global::System.ArgumentNullException("fromToken");
			}
			fromToken = this.CreateToken(fromToken);
			fromToken.Text = text;
			return this.Create(fromToken);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00032410 File Offset: 0x00030610
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Create(int tokenType, string text)
		{
			global::Antlr.Runtime.IToken payload = this.CreateToken(tokenType, text);
			return this.Create(payload);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00032434 File Offset: 0x00030634
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetType(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return 0;
			}
			return tree.Type;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0003245C File Offset: 0x0003065C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetType(object t, int type)
		{
			throw new global::System.NotSupportedException("don't know enough about Tree node");
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00032468 File Offset: 0x00030668
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string GetText(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return null;
			}
			return tree.Text;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00032490 File Offset: 0x00030690
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetText(object t, string text)
		{
			throw new global::System.NotSupportedException("don't know enough about Tree node");
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0003249C File Offset: 0x0003069C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object GetChild(object t, int i)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return null;
			}
			return tree.GetChild(i);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x000324C4 File Offset: 0x000306C4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetChild(object t, int i, object child)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return;
			}
			global::Antlr.Runtime.Tree.ITree tree2 = this.GetTree(child);
			tree.SetChild(i, tree2);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000324F4 File Offset: 0x000306F4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DeleteChild(object t, int i)
		{
			return ((global::Antlr.Runtime.Tree.ITree)t).DeleteChild(i);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00032504 File Offset: 0x00030704
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetChildCount(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return 0;
			}
			return tree.ChildCount;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0003252C File Offset: 0x0003072C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetUniqueID(object node)
		{
			if (this.treeToUniqueIDMap == null)
			{
				this.treeToUniqueIDMap = new global::System.Collections.Generic.Dictionary<object, int>();
			}
			int num;
			if (this.treeToUniqueIDMap.TryGetValue(node, out num))
			{
				return num;
			}
			num = this.uniqueNodeID;
			this.treeToUniqueIDMap[node] = num;
			this.uniqueNodeID++;
			return num;
		}

		// Token: 0x060008F7 RID: 2295
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract global::Antlr.Runtime.IToken CreateToken(int tokenType, string text);

		// Token: 0x060008F8 RID: 2296
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract global::Antlr.Runtime.IToken CreateToken(global::Antlr.Runtime.IToken fromToken);

		// Token: 0x060008F9 RID: 2297
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract object Create(global::Antlr.Runtime.IToken payload);

		// Token: 0x060008FA RID: 2298 RVA: 0x0003258C File Offset: 0x0003078C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DupNode(object treeNode)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(treeNode);
			if (tree == null)
			{
				return null;
			}
			return tree.DupNode();
		}

		// Token: 0x060008FB RID: 2299
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract global::Antlr.Runtime.IToken GetToken(object t);

		// Token: 0x060008FC RID: 2300 RVA: 0x000325B4 File Offset: 0x000307B4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetTokenBoundaries(object t, global::Antlr.Runtime.IToken startToken, global::Antlr.Runtime.IToken stopToken)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return;
			}
			int tokenStartIndex = 0;
			int tokenStopIndex = 0;
			if (startToken != null)
			{
				tokenStartIndex = startToken.TokenIndex;
			}
			if (stopToken != null)
			{
				tokenStopIndex = stopToken.TokenIndex;
			}
			tree.TokenStartIndex = tokenStartIndex;
			tree.TokenStopIndex = tokenStopIndex;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00032600 File Offset: 0x00030800
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetTokenStartIndex(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return -1;
			}
			return tree.TokenStartIndex;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00032628 File Offset: 0x00030828
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetTokenStopIndex(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return -1;
			}
			return tree.TokenStopIndex;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00032650 File Offset: 0x00030850
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object GetParent(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return null;
			}
			return tree.Parent;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00032678 File Offset: 0x00030878
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetParent(object t, object parent)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return;
			}
			global::Antlr.Runtime.Tree.ITree tree2 = this.GetTree(parent);
			tree.Parent = tree2;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x000326A8 File Offset: 0x000308A8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetChildIndex(object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return 0;
			}
			return tree.ChildIndex;
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000326D0 File Offset: 0x000308D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetChildIndex(object t, int index)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(t);
			if (tree == null)
			{
				return;
			}
			tree.ChildIndex = index;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x000326F8 File Offset: 0x000308F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t)
		{
			global::Antlr.Runtime.Tree.ITree tree = this.GetTree(parent);
			if (tree == null)
			{
				return;
			}
			tree.ReplaceChildren(startChildIndex, stopChildIndex, t);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00032724 File Offset: 0x00030924
		protected virtual global::Antlr.Runtime.Tree.ITree GetTree(object t)
		{
			if (t == null)
			{
				return null;
			}
			global::Antlr.Runtime.Tree.ITree tree = t as global::Antlr.Runtime.Tree.ITree;
			if (tree == null)
			{
				throw new global::System.NotSupportedException();
			}
			return tree;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00032754 File Offset: 0x00030954
		protected BaseTreeAdaptor()
		{
		}

		// Token: 0x040003CE RID: 974
		protected global::System.Collections.Generic.IDictionary<object, int> treeToUniqueIDMap;

		// Token: 0x040003CF RID: 975
		protected int uniqueNodeID = 1;
	}
}
