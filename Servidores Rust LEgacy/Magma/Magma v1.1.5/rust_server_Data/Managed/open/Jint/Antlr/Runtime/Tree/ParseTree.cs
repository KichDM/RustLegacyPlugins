using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000CA RID: 202
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class ParseTree : global::Antlr.Runtime.Tree.BaseTree
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x00033C64 File Offset: 0x00031E64
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public ParseTree(object label)
		{
			this.payload = label;
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00033C74 File Offset: 0x00031E74
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00033C7C File Offset: 0x00031E7C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string Text
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.ToString();
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00033C80 File Offset: 0x00031E80
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x00033C84 File Offset: 0x00031E84
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int TokenStartIndex
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

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00033C88 File Offset: 0x00031E88
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00033C8C File Offset: 0x00031E8C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int TokenStopIndex
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

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x00033C90 File Offset: 0x00031E90
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x00033C94 File Offset: 0x00031E94
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int Type
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

		// Token: 0x06000986 RID: 2438 RVA: 0x00033C98 File Offset: 0x00031E98
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.Tree.ITree DupNode()
		{
			return null;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00033C9C File Offset: 0x00031E9C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (!(this.payload is global::Antlr.Runtime.IToken))
			{
				return this.payload.ToString();
			}
			global::Antlr.Runtime.IToken token = (global::Antlr.Runtime.IToken)this.payload;
			if (token.Type == -1)
			{
				return "<EOF>";
			}
			return token.Text;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00033CF0 File Offset: 0x00031EF0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToStringWithHiddenTokens()
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			if (this.hiddenTokens != null)
			{
				for (int i = 0; i < this.hiddenTokens.Count; i++)
				{
					global::Antlr.Runtime.IToken token = this.hiddenTokens[i];
					stringBuilder.Append(token.Text);
				}
			}
			string text = this.ToString();
			if (!text.Equals("<EOF>"))
			{
				stringBuilder.Append(text);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00033D6C File Offset: 0x00031F6C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToInputString()
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			this.ToStringLeaves(stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00033D90 File Offset: 0x00031F90
		protected virtual void ToStringLeaves(global::System.Text.StringBuilder buf)
		{
			if (this.payload is global::Antlr.Runtime.IToken)
			{
				buf.Append(this.ToStringWithHiddenTokens());
				return;
			}
			int num = 0;
			while (this.Children != null && num < this.Children.Count)
			{
				global::Antlr.Runtime.Tree.ParseTree parseTree = (global::Antlr.Runtime.Tree.ParseTree)this.Children[num];
				parseTree.ToStringLeaves(buf);
				num++;
			}
		}

		// Token: 0x040003F8 RID: 1016
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object payload;

		// Token: 0x040003F9 RID: 1017
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::System.Collections.Generic.List<global::Antlr.Runtime.IToken> hiddenTokens;
	}
}
