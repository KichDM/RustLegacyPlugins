using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C3 RID: 195
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class CommonTree : global::Antlr.Runtime.Tree.BaseTree
	{
		// Token: 0x06000938 RID: 2360 RVA: 0x00032FCC File Offset: 0x000311CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTree()
		{
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00032FEC File Offset: 0x000311EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTree(global::Antlr.Runtime.Tree.CommonTree node) : base(node)
		{
			if (node == null)
			{
				throw new global::System.ArgumentNullException("node");
			}
			this.token = node.token;
			this.startIndex = node.startIndex;
			this.stopIndex = node.stopIndex;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00033050 File Offset: 0x00031250
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTree(global::Antlr.Runtime.IToken t)
		{
			this.token = t;
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x00033074 File Offset: 0x00031274
		// (set) Token: 0x0600093C RID: 2364 RVA: 0x000330CC File Offset: 0x000312CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int CharPositionInLine
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.token != null && this.token.CharPositionInLine != -1)
				{
					return this.token.CharPositionInLine;
				}
				if (this.ChildCount > 0)
				{
					return this.Children[0].CharPositionInLine;
				}
				return 0;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				base.CharPositionInLine = value;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x000330D8 File Offset: 0x000312D8
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x000330E0 File Offset: 0x000312E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int ChildIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.childIndex;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.childIndex = value;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x000330EC File Offset: 0x000312EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override bool IsNil
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.token == null;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x000330F8 File Offset: 0x000312F8
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x00033150 File Offset: 0x00031350
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int Line
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.token != null && this.token.Line != 0)
				{
					return this.token.Line;
				}
				if (this.ChildCount > 0)
				{
					return this.Children[0].Line;
				}
				return 0;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				base.Line = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0003315C File Offset: 0x0003135C
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00033164 File Offset: 0x00031364
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.Tree.ITree Parent
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.parent;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.parent = (global::Antlr.Runtime.Tree.CommonTree)value;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00033174 File Offset: 0x00031374
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00033190 File Offset: 0x00031390
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string Text
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.token == null)
				{
					return null;
				}
				return this.token.Text;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x00033194 File Offset: 0x00031394
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x0003319C File Offset: 0x0003139C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::Antlr.Runtime.IToken Token
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.token;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.token = value;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x000331A8 File Offset: 0x000313A8
		// (set) Token: 0x06000949 RID: 2377 RVA: 0x000331D4 File Offset: 0x000313D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int TokenStartIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.startIndex == -1 && this.token != null)
				{
					return this.token.TokenIndex;
				}
				return this.startIndex;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.startIndex = value;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x000331E0 File Offset: 0x000313E0
		// (set) Token: 0x0600094B RID: 2379 RVA: 0x0003320C File Offset: 0x0003140C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int TokenStopIndex
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.stopIndex == -1 && this.token != null)
				{
					return this.token.TokenIndex;
				}
				return this.stopIndex;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this.stopIndex = value;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x00033218 File Offset: 0x00031418
		// (set) Token: 0x0600094D RID: 2381 RVA: 0x00033234 File Offset: 0x00031434
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int Type
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this.token == null)
				{
					return 0;
				}
				return this.token.Type;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00033238 File Offset: 0x00031438
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.Tree.ITree DupNode()
		{
			return new global::Antlr.Runtime.Tree.CommonTree(this);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00033240 File Offset: 0x00031440
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void SetUnknownTokenBoundaries()
		{
			if (this.Children == null)
			{
				if (this.startIndex < 0 || this.stopIndex < 0)
				{
					this.startIndex = (this.stopIndex = this.token.TokenIndex);
				}
				return;
			}
			for (int i = 0; i < this.Children.Count; i++)
			{
				((global::Antlr.Runtime.Tree.CommonTree)this.Children[i]).SetUnknownTokenBoundaries();
			}
			if (this.startIndex >= 0 && this.stopIndex >= 0)
			{
				return;
			}
			if (this.Children.Count > 0)
			{
				global::Antlr.Runtime.Tree.CommonTree commonTree = (global::Antlr.Runtime.Tree.CommonTree)this.Children[0];
				global::Antlr.Runtime.Tree.CommonTree commonTree2 = (global::Antlr.Runtime.Tree.CommonTree)this.Children[this.Children.Count - 1];
				this.startIndex = commonTree.TokenStartIndex;
				this.stopIndex = commonTree2.TokenStopIndex;
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00033330 File Offset: 0x00031530
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (this.IsNil)
			{
				return "nil";
			}
			if (this.Type == 0)
			{
				return "<errornode>";
			}
			if (this.token == null)
			{
				return string.Empty;
			}
			return this.token.Text;
		}

		// Token: 0x040003DE RID: 990
		[global::System.CLSCompliant(false)]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IToken token;

		// Token: 0x040003DF RID: 991
		protected int startIndex = -1;

		// Token: 0x040003E0 RID: 992
		protected int stopIndex = -1;

		// Token: 0x040003E1 RID: 993
		private global::Antlr.Runtime.Tree.CommonTree parent;

		// Token: 0x040003E2 RID: 994
		private int childIndex = -1;
	}
}
