using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D7 RID: 215
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreePatternParser
	{
		// Token: 0x060009DE RID: 2526 RVA: 0x00034C1C File Offset: 0x00032E1C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreePatternParser(global::Antlr.Runtime.Tree.TreePatternLexer tokenizer, global::Antlr.Runtime.Tree.TreeWizard wizard, global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			this.tokenizer = tokenizer;
			this.wizard = wizard;
			this.adaptor = adaptor;
			this.ttype = tokenizer.NextToken();
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00034C48 File Offset: 0x00032E48
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Pattern()
		{
			if (this.ttype == 1)
			{
				return this.ParseTree();
			}
			if (this.ttype != 3)
			{
				return null;
			}
			object result = this.ParseNode();
			if (this.ttype == -1)
			{
				return result;
			}
			return null;
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00034C90 File Offset: 0x00032E90
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object ParseTree()
		{
			if (this.ttype != 1)
			{
				throw new global::System.InvalidOperationException("No beginning.");
			}
			this.ttype = this.tokenizer.NextToken();
			object obj = this.ParseNode();
			if (obj == null)
			{
				return null;
			}
			while (this.ttype == 1 || this.ttype == 3 || this.ttype == 5 || this.ttype == 7)
			{
				if (this.ttype == 1)
				{
					object child = this.ParseTree();
					this.adaptor.AddChild(obj, child);
				}
				else
				{
					object obj2 = this.ParseNode();
					if (obj2 == null)
					{
						return null;
					}
					this.adaptor.AddChild(obj, obj2);
				}
			}
			if (this.ttype != 2)
			{
				throw new global::System.InvalidOperationException("No end.");
			}
			this.ttype = this.tokenizer.NextToken();
			return obj;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00034D68 File Offset: 0x00032F68
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object ParseNode()
		{
			string text = null;
			if (this.ttype == 5)
			{
				this.ttype = this.tokenizer.NextToken();
				if (this.ttype != 3)
				{
					return null;
				}
				text = this.tokenizer.sval.ToString();
				this.ttype = this.tokenizer.NextToken();
				if (this.ttype != 6)
				{
					return null;
				}
				this.ttype = this.tokenizer.NextToken();
			}
			if (this.ttype == 7)
			{
				this.ttype = this.tokenizer.NextToken();
				global::Antlr.Runtime.IToken payload = new global::Antlr.Runtime.CommonToken(0, ".");
				global::Antlr.Runtime.Tree.TreeWizard.TreePattern treePattern = new global::Antlr.Runtime.Tree.TreeWizard.WildcardTreePattern(payload);
				if (text != null)
				{
					treePattern.label = text;
				}
				return treePattern;
			}
			if (this.ttype != 3)
			{
				return null;
			}
			string text2 = this.tokenizer.sval.ToString();
			this.ttype = this.tokenizer.NextToken();
			if (text2.Equals("nil"))
			{
				return this.adaptor.Nil();
			}
			string text3 = text2;
			string text4 = null;
			if (this.ttype == 4)
			{
				text4 = this.tokenizer.sval.ToString();
				text3 = text4;
				this.ttype = this.tokenizer.NextToken();
			}
			int tokenType = this.wizard.GetTokenType(text2);
			if (tokenType == 0)
			{
				return null;
			}
			object obj = this.adaptor.Create(tokenType, text3);
			if (text != null && obj.GetType() == typeof(global::Antlr.Runtime.Tree.TreeWizard.TreePattern))
			{
				((global::Antlr.Runtime.Tree.TreeWizard.TreePattern)obj).label = text;
			}
			if (text4 != null && obj.GetType() == typeof(global::Antlr.Runtime.Tree.TreeWizard.TreePattern))
			{
				((global::Antlr.Runtime.Tree.TreeWizard.TreePattern)obj).hasTextArg = true;
			}
			return obj;
		}

		// Token: 0x04000421 RID: 1057
		protected global::Antlr.Runtime.Tree.TreePatternLexer tokenizer;

		// Token: 0x04000422 RID: 1058
		protected int ttype;

		// Token: 0x04000423 RID: 1059
		protected global::Antlr.Runtime.Tree.TreeWizard wizard;

		// Token: 0x04000424 RID: 1060
		protected global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;
	}
}
