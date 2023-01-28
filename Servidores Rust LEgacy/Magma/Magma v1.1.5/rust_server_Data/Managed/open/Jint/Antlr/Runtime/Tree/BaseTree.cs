using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000BD RID: 189
	[global::System.Diagnostics.DebuggerTypeProxy(typeof(global::Antlr.Runtime.Tree.AntlrRuntime_BaseTreeDebugView))]
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public abstract class BaseTree : global::Antlr.Runtime.Tree.ITree
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x00031938 File Offset: 0x0002FB38
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BaseTree()
		{
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00031940 File Offset: 0x0002FB40
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BaseTree(global::Antlr.Runtime.Tree.ITree node)
		{
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x00031948 File Offset: 0x0002FB48
		// (set) Token: 0x06000896 RID: 2198 RVA: 0x00031950 File Offset: 0x0002FB50
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.Tree.ITree> Children
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._children;
			}
			private set
			{
				this._children = value;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x0003195C File Offset: 0x0002FB5C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int ChildCount
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.Children == null)
				{
					return 0;
				}
				return this.Children.Count;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x00031978 File Offset: 0x0002FB78
		// (set) Token: 0x06000899 RID: 2201 RVA: 0x0003197C File Offset: 0x0002FB7C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITree Parent
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return null;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x00031980 File Offset: 0x0002FB80
		// (set) Token: 0x0600089B RID: 2203 RVA: 0x00031984 File Offset: 0x0002FB84
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int ChildIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return 0;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x00031988 File Offset: 0x0002FB88
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool IsNil
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return false;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600089D RID: 2205
		// (set) Token: 0x0600089E RID: 2206
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract int TokenStartIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600089F RID: 2207
		// (set) Token: 0x060008A0 RID: 2208
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract int TokenStopIndex { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060008A1 RID: 2209
		// (set) Token: 0x060008A2 RID: 2210
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract int Type { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060008A3 RID: 2211
		// (set) Token: 0x060008A4 RID: 2212
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract string Text { [global::System.Runtime.InteropServices.ComVisible(false)] get; [global::System.Runtime.InteropServices.ComVisible(false)] set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0003198C File Offset: 0x0002FB8C
		// (set) Token: 0x060008A6 RID: 2214 RVA: 0x00031994 File Offset: 0x0002FB94
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Line
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.<Line>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.<Line>k__BackingField = value;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x000319A0 File Offset: 0x0002FBA0
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x000319A8 File Offset: 0x0002FBA8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int CharPositionInLine
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.<CharPositionInLine>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.<CharPositionInLine>k__BackingField = value;
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x000319B4 File Offset: 0x0002FBB4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITree GetChild(int i)
		{
			if (i < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (this.Children == null || i >= this.Children.Count)
			{
				return null;
			}
			return this.Children[i];
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x000319FC File Offset: 0x0002FBFC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITree GetFirstChildWithType(int type)
		{
			foreach (global::Antlr.Runtime.Tree.ITree tree in this.Children)
			{
				if (tree.Type == type)
				{
					return tree;
				}
			}
			return null;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00031A64 File Offset: 0x0002FC64
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void AddChild(global::Antlr.Runtime.Tree.ITree t)
		{
			if (t == null)
			{
				return;
			}
			if (t.IsNil)
			{
				global::Antlr.Runtime.Tree.BaseTree baseTree = t as global::Antlr.Runtime.Tree.BaseTree;
				if (baseTree != null && this.Children != null && this.Children == baseTree.Children)
				{
					throw new global::System.Exception("attempt to add child list to itself");
				}
				if (t.ChildCount > 0)
				{
					if (this.Children != null || baseTree == null)
					{
						if (this.Children == null)
						{
							this.Children = this.CreateChildrenList();
						}
						int childCount = t.ChildCount;
						for (int i = 0; i < childCount; i++)
						{
							global::Antlr.Runtime.Tree.ITree child = t.GetChild(i);
							this.Children.Add(child);
							child.Parent = this;
							child.ChildIndex = this.Children.Count - 1;
						}
						return;
					}
					this.Children = baseTree.Children;
					this.FreshenParentAndChildIndexes();
					return;
				}
			}
			else
			{
				if (this.Children == null)
				{
					this.Children = this.CreateChildrenList();
				}
				this.Children.Add(t);
				t.Parent = this;
				t.ChildIndex = this.Children.Count - 1;
			}
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00031B84 File Offset: 0x0002FD84
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void AddChildren(global::System.Collections.Generic.IEnumerable<global::Antlr.Runtime.Tree.ITree> kids)
		{
			if (kids == null)
			{
				throw new global::System.ArgumentNullException("kids");
			}
			foreach (global::Antlr.Runtime.Tree.ITree t in kids)
			{
				this.AddChild(t);
			}
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00031BE8 File Offset: 0x0002FDE8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetChild(int i, global::Antlr.Runtime.Tree.ITree t)
		{
			if (i < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("i");
			}
			if (t == null)
			{
				return;
			}
			if (t.IsNil)
			{
				throw new global::System.ArgumentException("Can't set single child to a list");
			}
			if (this.Children == null)
			{
				this.Children = this.CreateChildrenList();
			}
			this.Children[i] = t;
			t.Parent = this;
			t.ChildIndex = i;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00031C5C File Offset: 0x0002FE5C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object DeleteChild(int i)
		{
			if (i < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("i");
			}
			if (i >= this.ChildCount)
			{
				throw new global::System.ArgumentException();
			}
			if (this.Children == null)
			{
				return null;
			}
			global::Antlr.Runtime.Tree.ITree result = this.Children[i];
			this.Children.RemoveAt(i);
			this.FreshenParentAndChildIndexes(i);
			return result;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00031CC0 File Offset: 0x0002FEC0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void ReplaceChildren(int startChildIndex, int stopChildIndex, object t)
		{
			if (startChildIndex < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (stopChildIndex < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (t == null)
			{
				throw new global::System.ArgumentNullException("t");
			}
			if (stopChildIndex < startChildIndex)
			{
				throw new global::System.ArgumentException();
			}
			if (this.Children == null)
			{
				throw new global::System.ArgumentException("indexes invalid; no children in list");
			}
			int num = stopChildIndex - startChildIndex + 1;
			global::Antlr.Runtime.Tree.ITree tree = (global::Antlr.Runtime.Tree.ITree)t;
			global::System.Collections.Generic.IList<global::Antlr.Runtime.Tree.ITree> list;
			if (tree.IsNil)
			{
				global::Antlr.Runtime.Tree.BaseTree baseTree = tree as global::Antlr.Runtime.Tree.BaseTree;
				if (baseTree != null && baseTree.Children != null)
				{
					list = baseTree.Children;
				}
				else
				{
					list = this.CreateChildrenList();
					int childCount = tree.ChildCount;
					for (int i = 0; i < childCount; i++)
					{
						list.Add(tree.GetChild(i));
					}
				}
			}
			else
			{
				list = new global::System.Collections.Generic.List<global::Antlr.Runtime.Tree.ITree>(1);
				list.Add(tree);
			}
			int count = list.Count;
			int count2 = list.Count;
			int num2 = num - count;
			if (num2 == 0)
			{
				int num3 = 0;
				for (int j = startChildIndex; j <= stopChildIndex; j++)
				{
					global::Antlr.Runtime.Tree.ITree tree2 = list[num3];
					this.Children[j] = tree2;
					tree2.Parent = this;
					tree2.ChildIndex = j;
					num3++;
				}
				return;
			}
			if (num2 > 0)
			{
				for (int k = 0; k < count2; k++)
				{
					this.Children[startChildIndex + k] = list[k];
				}
				int num4 = startChildIndex + count2;
				for (int l = num4; l <= stopChildIndex; l++)
				{
					this.Children.RemoveAt(num4);
				}
				this.FreshenParentAndChildIndexes(startChildIndex);
				return;
			}
			for (int m = 0; m < num; m++)
			{
				this.Children[startChildIndex + m] = list[m];
			}
			for (int n = num; n < count; n++)
			{
				this.Children.Insert(startChildIndex + n, list[n]);
			}
			this.FreshenParentAndChildIndexes(startChildIndex);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00031EC4 File Offset: 0x000300C4
		protected virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.Tree.ITree> CreateChildrenList()
		{
			return new global::System.Collections.Generic.List<global::Antlr.Runtime.Tree.ITree>();
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x00031ECC File Offset: 0x000300CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void FreshenParentAndChildIndexes()
		{
			this.FreshenParentAndChildIndexes(0);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00031ED8 File Offset: 0x000300D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void FreshenParentAndChildIndexes(int offset)
		{
			int childCount = this.ChildCount;
			for (int i = offset; i < childCount; i++)
			{
				global::Antlr.Runtime.Tree.ITree child = this.GetChild(i);
				child.ChildIndex = i;
				child.Parent = this;
			}
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00031F18 File Offset: 0x00030118
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SanityCheckParentAndChildIndexes()
		{
			this.SanityCheckParentAndChildIndexes(null, -1);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00031F24 File Offset: 0x00030124
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SanityCheckParentAndChildIndexes(global::Antlr.Runtime.Tree.ITree parent, int i)
		{
			if (parent != this.Parent)
			{
				throw new global::System.InvalidOperationException(string.Concat(new object[]
				{
					"parents don't match; expected ",
					parent,
					" found ",
					this.Parent
				}));
			}
			if (i != this.ChildIndex)
			{
				throw new global::System.InvalidOperationException(string.Concat(new object[]
				{
					"child indexes don't match; expected ",
					i,
					" found ",
					this.ChildIndex
				}));
			}
			int childCount = this.ChildCount;
			for (int j = 0; j < childCount; j++)
			{
				global::Antlr.Runtime.Tree.BaseTree baseTree = (global::Antlr.Runtime.Tree.BaseTree)this.GetChild(j);
				baseTree.SanityCheckParentAndChildIndexes(this, j);
			}
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00031FE4 File Offset: 0x000301E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool HasAncestor(int ttype)
		{
			return this.GetAncestor(ttype) != null;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00031FF4 File Offset: 0x000301F4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.Tree.ITree GetAncestor(int ttype)
		{
			for (global::Antlr.Runtime.Tree.ITree parent = ((global::Antlr.Runtime.Tree.ITree)this).Parent; parent != null; parent = parent.Parent)
			{
				if (parent.Type == ttype)
				{
					return parent;
				}
			}
			return null;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0003202C File Offset: 0x0003022C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.Tree.ITree> GetAncestors()
		{
			if (this.Parent == null)
			{
				return null;
			}
			global::System.Collections.Generic.List<global::Antlr.Runtime.Tree.ITree> list = new global::System.Collections.Generic.List<global::Antlr.Runtime.Tree.ITree>();
			for (global::Antlr.Runtime.Tree.ITree parent = ((global::Antlr.Runtime.Tree.ITree)this).Parent; parent != null; parent = parent.Parent)
			{
				list.Insert(0, parent);
			}
			return list;
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00032074 File Offset: 0x00030274
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToStringTree()
		{
			if (this.Children == null || this.Children.Count == 0)
			{
				return this.ToString();
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			if (!this.IsNil)
			{
				stringBuilder.Append("(");
				stringBuilder.Append(this.ToString());
				stringBuilder.Append(' ');
			}
			int num = 0;
			while (this.Children != null && num < this.Children.Count)
			{
				global::Antlr.Runtime.Tree.ITree tree = this.Children[num];
				if (num > 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(tree.ToStringTree());
				num++;
			}
			if (!this.IsNil)
			{
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060008B9 RID: 2233
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract override string ToString();

		// Token: 0x060008BA RID: 2234
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract global::Antlr.Runtime.Tree.ITree DupNode();

		// Token: 0x040003CB RID: 971
		private global::System.Collections.Generic.IList<global::Antlr.Runtime.Tree.ITree> _children;

		// Token: 0x040003CC RID: 972
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <Line>k__BackingField;

		// Token: 0x040003CD RID: 973
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <CharPositionInLine>k__BackingField;
	}
}
