using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000DB RID: 219
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeWizard
	{
		// Token: 0x060009F9 RID: 2553 RVA: 0x000352BC File Offset: 0x000334BC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeWizard(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			this.adaptor = adaptor;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x000352CC File Offset: 0x000334CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeWizard(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, global::System.Collections.Generic.IDictionary<string, int> tokenNameToTypeMap)
		{
			this.adaptor = adaptor;
			this.tokenNameToTypeMap = tokenNameToTypeMap;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x000352E4 File Offset: 0x000334E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeWizard(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string[] tokenNames)
		{
			this.adaptor = adaptor;
			this.tokenNameToTypeMap = this.ComputeTokenTypes(tokenNames);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00035300 File Offset: 0x00033500
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeWizard(string[] tokenNames) : this(new global::Antlr.Runtime.Tree.CommonTreeAdaptor(), tokenNames)
		{
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00035310 File Offset: 0x00033510
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.Generic.IDictionary<string, int> ComputeTokenTypes(string[] tokenNames)
		{
			global::System.Collections.Generic.IDictionary<string, int> dictionary = new global::System.Collections.Generic.Dictionary<string, int>();
			if (tokenNames == null)
			{
				return dictionary;
			}
			for (int i = 4; i < tokenNames.Length; i++)
			{
				string key = tokenNames[i];
				dictionary[key] = i;
			}
			return dictionary;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00035354 File Offset: 0x00033554
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetTokenType(string tokenName)
		{
			if (this.tokenNameToTypeMap == null)
			{
				return 0;
			}
			int result;
			if (this.tokenNameToTypeMap.TryGetValue(tokenName, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00035388 File Offset: 0x00033588
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::System.Collections.Generic.IDictionary<int, global::System.Collections.IList> Index(object t)
		{
			global::System.Collections.Generic.IDictionary<int, global::System.Collections.IList> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.IList>();
			this.IndexCore(t, dictionary);
			return dictionary;
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000353A8 File Offset: 0x000335A8
		protected virtual void IndexCore(object t, global::System.Collections.Generic.IDictionary<int, global::System.Collections.IList> m)
		{
			if (t == null)
			{
				return;
			}
			int type = this.adaptor.GetType(t);
			global::System.Collections.IList list;
			if (!m.TryGetValue(type, out list) || list == null)
			{
				list = new global::System.Collections.Generic.List<object>();
				m[type] = list;
			}
			list.Add(t);
			int childCount = this.adaptor.GetChildCount(t);
			for (int i = 0; i < childCount; i++)
			{
				object child = this.adaptor.GetChild(t, i);
				this.IndexCore(child, m);
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0003542C File Offset: 0x0003362C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.IList Find(object t, int ttype)
		{
			global::System.Collections.IList list = new global::System.Collections.Generic.List<object>();
			this.Visit(t, ttype, new global::Antlr.Runtime.Tree.TreeWizard.FindTreeWizardVisitor(list));
			return list;
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00035454 File Offset: 0x00033654
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual global::System.Collections.IList Find(object t, string pattern)
		{
			global::System.Collections.IList list = new global::System.Collections.Generic.List<object>();
			global::Antlr.Runtime.Tree.TreePatternLexer tokenizer = new global::Antlr.Runtime.Tree.TreePatternLexer(pattern);
			global::Antlr.Runtime.Tree.TreePatternParser treePatternParser = new global::Antlr.Runtime.Tree.TreePatternParser(tokenizer, this, new global::Antlr.Runtime.Tree.TreeWizard.TreePatternTreeAdaptor());
			global::Antlr.Runtime.Tree.TreeWizard.TreePattern treePattern = (global::Antlr.Runtime.Tree.TreeWizard.TreePattern)treePatternParser.Pattern();
			if (treePattern == null || treePattern.IsNil || treePattern.GetType() == typeof(global::Antlr.Runtime.Tree.TreeWizard.WildcardTreePattern))
			{
				return null;
			}
			int type = treePattern.Type;
			this.Visit(t, type, new global::Antlr.Runtime.Tree.TreeWizard.FindTreeWizardContextVisitor(this, treePattern, list));
			return list;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x000354D0 File Offset: 0x000336D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object FindFirst(object t, int ttype)
		{
			return null;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x000354D4 File Offset: 0x000336D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object FindFirst(object t, string pattern)
		{
			return null;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000354D8 File Offset: 0x000336D8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Visit(object t, int ttype, global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor visitor)
		{
			this.VisitCore(t, null, 0, ttype, visitor);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x000354E8 File Offset: 0x000336E8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Visit(object t, int ttype, global::System.Action<object> action)
		{
			this.Visit(t, ttype, new global::Antlr.Runtime.Tree.TreeWizard.ActionVisitor(action));
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000354F8 File Offset: 0x000336F8
		protected virtual void VisitCore(object t, object parent, int childIndex, int ttype, global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor visitor)
		{
			if (t == null)
			{
				return;
			}
			if (this.adaptor.GetType(t) == ttype)
			{
				visitor.Visit(t, parent, childIndex, null);
			}
			int childCount = this.adaptor.GetChildCount(t);
			for (int i = 0; i < childCount; i++)
			{
				object child = this.adaptor.GetChild(t, i);
				this.VisitCore(child, t, i, ttype, visitor);
			}
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00035568 File Offset: 0x00033768
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Visit(object t, string pattern, global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor visitor)
		{
			global::Antlr.Runtime.Tree.TreePatternLexer tokenizer = new global::Antlr.Runtime.Tree.TreePatternLexer(pattern);
			global::Antlr.Runtime.Tree.TreePatternParser treePatternParser = new global::Antlr.Runtime.Tree.TreePatternParser(tokenizer, this, new global::Antlr.Runtime.Tree.TreeWizard.TreePatternTreeAdaptor());
			global::Antlr.Runtime.Tree.TreeWizard.TreePattern treePattern = (global::Antlr.Runtime.Tree.TreeWizard.TreePattern)treePatternParser.Pattern();
			if (treePattern == null || treePattern.IsNil || treePattern.GetType() == typeof(global::Antlr.Runtime.Tree.TreeWizard.WildcardTreePattern))
			{
				return;
			}
			global::System.Collections.Generic.IDictionary<string, object> labels = new global::System.Collections.Generic.Dictionary<string, object>();
			int type = treePattern.Type;
			this.Visit(t, type, new global::Antlr.Runtime.Tree.TreeWizard.VisitTreeWizardContextVisitor(this, visitor, labels, treePattern));
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x000355E0 File Offset: 0x000337E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool Parse(object t, string pattern, global::System.Collections.Generic.IDictionary<string, object> labels)
		{
			global::Antlr.Runtime.Tree.TreePatternLexer tokenizer = new global::Antlr.Runtime.Tree.TreePatternLexer(pattern);
			global::Antlr.Runtime.Tree.TreePatternParser treePatternParser = new global::Antlr.Runtime.Tree.TreePatternParser(tokenizer, this, new global::Antlr.Runtime.Tree.TreeWizard.TreePatternTreeAdaptor());
			global::Antlr.Runtime.Tree.TreeWizard.TreePattern tpattern = (global::Antlr.Runtime.Tree.TreeWizard.TreePattern)treePatternParser.Pattern();
			return this.ParseCore(t, tpattern, labels);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0003561C File Offset: 0x0003381C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool Parse(object t, string pattern)
		{
			return this.Parse(t, pattern, null);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00035628 File Offset: 0x00033828
		protected virtual bool ParseCore(object t1, global::Antlr.Runtime.Tree.TreeWizard.TreePattern tpattern, global::System.Collections.Generic.IDictionary<string, object> labels)
		{
			if (t1 == null || tpattern == null)
			{
				return false;
			}
			if (tpattern.GetType() != typeof(global::Antlr.Runtime.Tree.TreeWizard.WildcardTreePattern))
			{
				if (this.adaptor.GetType(t1) != tpattern.Type)
				{
					return false;
				}
				if (tpattern.hasTextArg && !this.adaptor.GetText(t1).Equals(tpattern.Text))
				{
					return false;
				}
			}
			if (tpattern.label != null && labels != null)
			{
				labels[tpattern.label] = t1;
			}
			int childCount = this.adaptor.GetChildCount(t1);
			int childCount2 = tpattern.ChildCount;
			if (childCount != childCount2)
			{
				return false;
			}
			for (int i = 0; i < childCount; i++)
			{
				object child = this.adaptor.GetChild(t1, i);
				global::Antlr.Runtime.Tree.TreeWizard.TreePattern tpattern2 = (global::Antlr.Runtime.Tree.TreeWizard.TreePattern)tpattern.GetChild(i);
				if (!this.ParseCore(child, tpattern2, labels))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00035718 File Offset: 0x00033918
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object Create(string pattern)
		{
			global::Antlr.Runtime.Tree.TreePatternLexer tokenizer = new global::Antlr.Runtime.Tree.TreePatternLexer(pattern);
			global::Antlr.Runtime.Tree.TreePatternParser treePatternParser = new global::Antlr.Runtime.Tree.TreePatternParser(tokenizer, this, this.adaptor);
			return treePatternParser.Pattern();
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00035748 File Offset: 0x00033948
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static bool Equals(object t1, object t2, global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			return global::Antlr.Runtime.Tree.TreeWizard.EqualsCore(t1, t2, adaptor);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00035754 File Offset: 0x00033954
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool Equals(object t1, object t2)
		{
			return global::Antlr.Runtime.Tree.TreeWizard.EqualsCore(t1, t2, this.adaptor);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00035764 File Offset: 0x00033964
		protected static bool EqualsCore(object t1, object t2, global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			if (t1 == null || t2 == null)
			{
				return false;
			}
			if (adaptor.GetType(t1) != adaptor.GetType(t2))
			{
				return false;
			}
			if (!adaptor.GetText(t1).Equals(adaptor.GetText(t2)))
			{
				return false;
			}
			int childCount = adaptor.GetChildCount(t1);
			int childCount2 = adaptor.GetChildCount(t2);
			if (childCount != childCount2)
			{
				return false;
			}
			for (int i = 0; i < childCount; i++)
			{
				object child = adaptor.GetChild(t1, i);
				object child2 = adaptor.GetChild(t2, i);
				if (!global::Antlr.Runtime.Tree.TreeWizard.EqualsCore(child, child2, adaptor))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400042C RID: 1068
		protected global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;

		// Token: 0x0400042D RID: 1069
		protected global::System.Collections.Generic.IDictionary<string, int> tokenNameToTypeMap;

		// Token: 0x0200015F RID: 351
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public interface IContextVisitor
		{
			// Token: 0x06000C30 RID: 3120
			[global::System.Runtime.InteropServices.ComVisible(false)]
			void Visit(object t, object parent, int childIndex, global::System.Collections.Generic.IDictionary<string, object> labels);
		}

		// Token: 0x02000160 RID: 352
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public abstract class Visitor : global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor
		{
			// Token: 0x06000C31 RID: 3121 RVA: 0x0003D2BC File Offset: 0x0003B4BC
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public virtual void Visit(object t, object parent, int childIndex, global::System.Collections.Generic.IDictionary<string, object> labels)
			{
				this.Visit(t);
			}

			// Token: 0x06000C32 RID: 3122
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public abstract void Visit(object t);

			// Token: 0x06000C33 RID: 3123 RVA: 0x0003D2C8 File Offset: 0x0003B4C8
			protected Visitor()
			{
			}
		}

		// Token: 0x02000161 RID: 353
		private class ActionVisitor : global::Antlr.Runtime.Tree.TreeWizard.Visitor
		{
			// Token: 0x06000C34 RID: 3124 RVA: 0x0003D2D0 File Offset: 0x0003B4D0
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public ActionVisitor(global::System.Action<object> action)
			{
				this._action = action;
			}

			// Token: 0x06000C35 RID: 3125 RVA: 0x0003D2E0 File Offset: 0x0003B4E0
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override void Visit(object t)
			{
				this._action(t);
			}

			// Token: 0x04000709 RID: 1801
			private global::System.Action<object> _action;
		}

		// Token: 0x02000162 RID: 354
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public class TreePattern : global::Antlr.Runtime.Tree.CommonTree
		{
			// Token: 0x06000C36 RID: 3126 RVA: 0x0003D2F0 File Offset: 0x0003B4F0
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public TreePattern(global::Antlr.Runtime.IToken payload) : base(payload)
			{
			}

			// Token: 0x06000C37 RID: 3127 RVA: 0x0003D2FC File Offset: 0x0003B4FC
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override string ToString()
			{
				if (this.label != null)
				{
					return "%" + this.label + ":";
				}
				return base.ToString();
			}

			// Token: 0x0400070A RID: 1802
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string label;

			// Token: 0x0400070B RID: 1803
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public bool hasTextArg;
		}

		// Token: 0x02000163 RID: 355
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public class WildcardTreePattern : global::Antlr.Runtime.Tree.TreeWizard.TreePattern
		{
			// Token: 0x06000C38 RID: 3128 RVA: 0x0003D328 File Offset: 0x0003B528
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public WildcardTreePattern(global::Antlr.Runtime.IToken payload) : base(payload)
			{
			}
		}

		// Token: 0x02000164 RID: 356
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public class TreePatternTreeAdaptor : global::Antlr.Runtime.Tree.CommonTreeAdaptor
		{
			// Token: 0x06000C39 RID: 3129 RVA: 0x0003D334 File Offset: 0x0003B534
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override object Create(global::Antlr.Runtime.IToken payload)
			{
				return new global::Antlr.Runtime.Tree.TreeWizard.TreePattern(payload);
			}

			// Token: 0x06000C3A RID: 3130 RVA: 0x0003D33C File Offset: 0x0003B53C
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public TreePatternTreeAdaptor()
			{
			}
		}

		// Token: 0x02000165 RID: 357
		private class FindTreeWizardVisitor : global::Antlr.Runtime.Tree.TreeWizard.Visitor
		{
			// Token: 0x06000C3B RID: 3131 RVA: 0x0003D344 File Offset: 0x0003B544
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public FindTreeWizardVisitor(global::System.Collections.IList nodes)
			{
				this._nodes = nodes;
			}

			// Token: 0x06000C3C RID: 3132 RVA: 0x0003D354 File Offset: 0x0003B554
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override void Visit(object t)
			{
				this._nodes.Add(t);
			}

			// Token: 0x0400070C RID: 1804
			private global::System.Collections.IList _nodes;
		}

		// Token: 0x02000166 RID: 358
		private class FindTreeWizardContextVisitor : global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor
		{
			// Token: 0x06000C3D RID: 3133 RVA: 0x0003D364 File Offset: 0x0003B564
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public FindTreeWizardContextVisitor(global::Antlr.Runtime.Tree.TreeWizard outer, global::Antlr.Runtime.Tree.TreeWizard.TreePattern tpattern, global::System.Collections.IList subtrees)
			{
				this._outer = outer;
				this._tpattern = tpattern;
				this._subtrees = subtrees;
			}

			// Token: 0x06000C3E RID: 3134 RVA: 0x0003D384 File Offset: 0x0003B584
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public void Visit(object t, object parent, int childIndex, global::System.Collections.Generic.IDictionary<string, object> labels)
			{
				if (this._outer.ParseCore(t, this._tpattern, null))
				{
					this._subtrees.Add(t);
				}
			}

			// Token: 0x0400070D RID: 1805
			private global::Antlr.Runtime.Tree.TreeWizard _outer;

			// Token: 0x0400070E RID: 1806
			private global::Antlr.Runtime.Tree.TreeWizard.TreePattern _tpattern;

			// Token: 0x0400070F RID: 1807
			private global::System.Collections.IList _subtrees;
		}

		// Token: 0x02000167 RID: 359
		private class VisitTreeWizardContextVisitor : global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor
		{
			// Token: 0x06000C3F RID: 3135 RVA: 0x0003D3AC File Offset: 0x0003B5AC
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public VisitTreeWizardContextVisitor(global::Antlr.Runtime.Tree.TreeWizard outer, global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor visitor, global::System.Collections.Generic.IDictionary<string, object> labels, global::Antlr.Runtime.Tree.TreeWizard.TreePattern tpattern)
			{
				this._outer = outer;
				this._visitor = visitor;
				this._labels = labels;
				this._tpattern = tpattern;
			}

			// Token: 0x06000C40 RID: 3136 RVA: 0x0003D3D4 File Offset: 0x0003B5D4
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public void Visit(object t, object parent, int childIndex, global::System.Collections.Generic.IDictionary<string, object> unusedlabels)
			{
				this._labels.Clear();
				if (this._outer.ParseCore(t, this._tpattern, this._labels))
				{
					this._visitor.Visit(t, parent, childIndex, this._labels);
				}
			}

			// Token: 0x04000710 RID: 1808
			private global::Antlr.Runtime.Tree.TreeWizard _outer;

			// Token: 0x04000711 RID: 1809
			private global::Antlr.Runtime.Tree.TreeWizard.IContextVisitor _visitor;

			// Token: 0x04000712 RID: 1810
			private global::System.Collections.Generic.IDictionary<string, object> _labels;

			// Token: 0x04000713 RID: 1811
			private global::Antlr.Runtime.Tree.TreeWizard.TreePattern _tpattern;
		}
	}
}
