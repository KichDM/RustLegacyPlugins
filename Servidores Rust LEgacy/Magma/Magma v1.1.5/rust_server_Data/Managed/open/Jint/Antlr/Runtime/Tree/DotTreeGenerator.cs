using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C7 RID: 199
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class DotTreeGenerator
	{
		// Token: 0x06000970 RID: 2416 RVA: 0x000338DC File Offset: 0x00031ADC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToDot(object tree, global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			foreach (string value in this.HeaderLines)
			{
				stringBuilder.AppendLine(value);
			}
			this.nodeNumber = 0;
			global::System.Collections.Generic.IEnumerable<string> enumerable = this.DefineNodes(tree, adaptor);
			this.nodeNumber = 0;
			global::System.Collections.Generic.IEnumerable<string> enumerable2 = this.DefineEdges(tree, adaptor);
			foreach (string value2 in enumerable)
			{
				stringBuilder.AppendLine(value2);
			}
			stringBuilder.AppendLine();
			foreach (string value3 in enumerable2)
			{
				stringBuilder.AppendLine(value3);
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000339F0 File Offset: 0x00031BF0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToDot(global::Antlr.Runtime.Tree.ITree tree)
		{
			return this.ToDot(tree, new global::Antlr.Runtime.Tree.CommonTreeAdaptor());
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00033A00 File Offset: 0x00031C00
		protected virtual global::System.Collections.Generic.IEnumerable<string> DefineNodes(object tree, global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			if (tree != null)
			{
				int i = adaptor.GetChildCount(tree);
				if (i != 0)
				{
					yield return this.GetNodeText(adaptor, tree);
					for (int j = 0; j < i; j++)
					{
						object child = adaptor.GetChild(tree, j);
						yield return this.GetNodeText(adaptor, child);
						foreach (string t in this.DefineNodes(child, adaptor))
						{
							yield return t;
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00033A30 File Offset: 0x00031C30
		protected virtual global::System.Collections.Generic.IEnumerable<string> DefineEdges(object tree, global::Antlr.Runtime.Tree.ITreeAdaptor adaptor)
		{
			if (tree != null)
			{
				int i = adaptor.GetChildCount(tree);
				if (i != 0)
				{
					string parentName = "n" + this.GetNodeNumber(tree);
					string parentText = adaptor.GetText(tree);
					for (int j = 0; j < i; j++)
					{
						object child = adaptor.GetChild(tree, j);
						string childText = adaptor.GetText(child);
						string childName = "n" + this.GetNodeNumber(child);
						yield return string.Format("  {0} -> {1} // \"{2}\" -> \"{3}\"", new object[]
						{
							parentName,
							childName,
							this.FixString(parentText),
							this.FixString(childText)
						});
						foreach (string t in this.DefineEdges(child, adaptor))
						{
							yield return t;
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00033A60 File Offset: 0x00031C60
		protected virtual string GetNodeText(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, object t)
		{
			string text = adaptor.GetText(t);
			string arg = "n" + this.GetNodeNumber(t);
			return string.Format("  {0} [label=\"{1}\"];", arg, this.FixString(text));
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00033AA4 File Offset: 0x00031CA4
		protected virtual int GetNodeNumber(object t)
		{
			int result;
			if (this.nodeToNumberMap.TryGetValue(t, out result))
			{
				return result;
			}
			this.nodeToNumberMap[t] = this.nodeNumber;
			this.nodeNumber++;
			return this.nodeNumber - 1;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00033AF4 File Offset: 0x00031CF4
		protected virtual string FixString(string text)
		{
			if (text != null)
			{
				text = global::System.Text.RegularExpressions.Regex.Replace(text, "\"", "\\\\\"");
				text = global::System.Text.RegularExpressions.Regex.Replace(text, "\\t", "    ");
				text = global::System.Text.RegularExpressions.Regex.Replace(text, "\\n", "\\\\n");
				text = global::System.Text.RegularExpressions.Regex.Replace(text, "\\r", "\\\\r");
				if (text.Length > 0x14)
				{
					text = text.Substring(0, 8) + "..." + text.Substring(text.Length - 8);
				}
			}
			return text;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00033B84 File Offset: 0x00031D84
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public DotTreeGenerator()
		{
		}

		// Token: 0x040003F0 RID: 1008
		private const string Footer = "}";

		// Token: 0x040003F1 RID: 1009
		private const string NodeFormat = "  {0} [label=\"{1}\"];";

		// Token: 0x040003F2 RID: 1010
		private const string EdgeFormat = "  {0} -> {1} // \"{2}\" -> \"{3}\"";

		// Token: 0x040003F3 RID: 1011
		private readonly string[] HeaderLines = new string[]
		{
			"digraph {",
			"",
			"\tordering=out;",
			"\tranksep=.4;",
			"\tbgcolor=\"lightgrey\"; node [shape=box, fixedsize=false, fontsize=12, fontname=\"Helvetica-bold\", fontcolor=\"blue\"",
			"\t\twidth=.25, height=.25, color=\"black\", fillcolor=\"white\", style=\"filled, solid, bold\"];",
			"\tedge [arrowsize=.5, color=\"black\", style=\"bold\"]",
			""
		};

		// Token: 0x040003F4 RID: 1012
		private global::System.Collections.Generic.Dictionary<object, int> nodeToNumberMap = new global::System.Collections.Generic.Dictionary<object, int>();

		// Token: 0x040003F5 RID: 1013
		private int nodeNumber;

		// Token: 0x0200015D RID: 349
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <DefineNodes>d__0 : global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<string>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000C1E RID: 3102 RVA: 0x0003CCB4 File Offset: 0x0003AEB4
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
			{
				global::Antlr.Runtime.Tree.DotTreeGenerator.<DefineNodes>d__0 <DefineNodes>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<DefineNodes>d__ = this;
				}
				else
				{
					<DefineNodes>d__ = new global::Antlr.Runtime.Tree.DotTreeGenerator.<DefineNodes>d__0(0);
					<DefineNodes>d__.<>4__this = this;
				}
				<DefineNodes>d__.tree = tree;
				<DefineNodes>d__.adaptor = adaptor;
				return <DefineNodes>d__;
			}

			// Token: 0x06000C1F RID: 3103 RVA: 0x0003CD24 File Offset: 0x0003AF24
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator();
			}

			// Token: 0x06000C20 RID: 3104 RVA: 0x0003CD2C File Offset: 0x0003AF2C
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						if (tree == null)
						{
							goto IL_179;
						}
						i = adaptor.GetChildCount(tree);
						if (i != 0)
						{
							this.<>2__current = this.GetNodeText(adaptor, tree);
							this.<>1__state = 1;
							return true;
						}
						goto IL_179;
					case 1:
						this.<>1__state = -1;
						j = 0;
						goto IL_168;
					case 2:
						this.<>1__state = -1;
						enumerator = this.DefineNodes(child, adaptor).GetEnumerator();
						this.<>1__state = 3;
						break;
					case 3:
						goto IL_179;
					case 4:
						this.<>1__state = 3;
						break;
					default:
						goto IL_179;
					}
					if (enumerator.MoveNext())
					{
						t = enumerator.Current;
						this.<>2__current = t;
						this.<>1__state = 4;
						return true;
					}
					this.<>m__Finally6();
					j++;
					IL_168:
					if (j < i)
					{
						child = adaptor.GetChild(tree, j);
						this.<>2__current = this.GetNodeText(adaptor, child);
						this.<>1__state = 2;
						return true;
					}
					IL_179:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002AD RID: 685
			// (get) Token: 0x06000C21 RID: 3105 RVA: 0x0003CEE0 File Offset: 0x0003B0E0
			string global::System.Collections.Generic.IEnumerator<string>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C22 RID: 3106 RVA: 0x0003CEE8 File Offset: 0x0003B0E8
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000C23 RID: 3107 RVA: 0x0003CEF0 File Offset: 0x0003B0F0
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 3:
				case 4:
					try
					{
					}
					finally
					{
						this.<>m__Finally6();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002AE RID: 686
			// (get) Token: 0x06000C24 RID: 3108 RVA: 0x0003CF34 File Offset: 0x0003B134
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C25 RID: 3109 RVA: 0x0003CF3C File Offset: 0x0003B13C
			[global::System.Diagnostics.DebuggerHidden]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public <DefineNodes>d__0(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000C26 RID: 3110 RVA: 0x0003CF5C File Offset: 0x0003B15C
			private void <>m__Finally6()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x040006EB RID: 1771
			private string <>2__current;

			// Token: 0x040006EC RID: 1772
			private int <>1__state;

			// Token: 0x040006ED RID: 1773
			private int <>l__initialThreadId;

			// Token: 0x040006EE RID: 1774
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::Antlr.Runtime.Tree.DotTreeGenerator <>4__this;

			// Token: 0x040006EF RID: 1775
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object tree;

			// Token: 0x040006F0 RID: 1776
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object <>3__tree;

			// Token: 0x040006F1 RID: 1777
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;

			// Token: 0x040006F2 RID: 1778
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::Antlr.Runtime.Tree.ITreeAdaptor <>3__adaptor;

			// Token: 0x040006F3 RID: 1779
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int <n>5__1;

			// Token: 0x040006F4 RID: 1780
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int <i>5__2;

			// Token: 0x040006F5 RID: 1781
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object <child>5__3;

			// Token: 0x040006F6 RID: 1782
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string <t>5__4;

			// Token: 0x040006F7 RID: 1783
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrap5;
		}

		// Token: 0x0200015E RID: 350
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <DefineEdges>d__9 : global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<string>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000C27 RID: 3111 RVA: 0x0003CF7C File Offset: 0x0003B17C
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
			{
				global::Antlr.Runtime.Tree.DotTreeGenerator.<DefineEdges>d__9 <DefineEdges>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<DefineEdges>d__ = this;
				}
				else
				{
					<DefineEdges>d__ = new global::Antlr.Runtime.Tree.DotTreeGenerator.<DefineEdges>d__9(0);
					<DefineEdges>d__.<>4__this = this;
				}
				<DefineEdges>d__.tree = tree;
				<DefineEdges>d__.adaptor = adaptor;
				return <DefineEdges>d__;
			}

			// Token: 0x06000C28 RID: 3112 RVA: 0x0003CFEC File Offset: 0x0003B1EC
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator();
			}

			// Token: 0x06000C29 RID: 3113 RVA: 0x0003CFF4 File Offset: 0x0003B1F4
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						if (tree == null)
						{
							goto IL_1F2;
						}
						i = adaptor.GetChildCount(tree);
						if (i != 0)
						{
							parentName = "n" + this.GetNodeNumber(tree);
							parentText = adaptor.GetText(tree);
							j = 0;
							goto IL_1E1;
						}
						goto IL_1F2;
					case 1:
						this.<>1__state = -1;
						enumerator = this.DefineEdges(child, adaptor).GetEnumerator();
						this.<>1__state = 2;
						break;
					case 2:
						goto IL_1F2;
					case 3:
						this.<>1__state = 2;
						break;
					default:
						goto IL_1F2;
					}
					if (enumerator.MoveNext())
					{
						t = enumerator.Current;
						this.<>2__current = t;
						this.<>1__state = 3;
						return true;
					}
					this.<>m__Finally13();
					j++;
					IL_1E1:
					if (j < i)
					{
						child = adaptor.GetChild(tree, j);
						childText = adaptor.GetText(child);
						childName = "n" + this.GetNodeNumber(child);
						this.<>2__current = string.Format("  {0} -> {1} // \"{2}\" -> \"{3}\"", new object[]
						{
							parentName,
							childName,
							this.FixString(parentText),
							this.FixString(childText)
						});
						this.<>1__state = 1;
						return true;
					}
					IL_1F2:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002AF RID: 687
			// (get) Token: 0x06000C2A RID: 3114 RVA: 0x0003D220 File Offset: 0x0003B420
			string global::System.Collections.Generic.IEnumerator<string>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C2B RID: 3115 RVA: 0x0003D228 File Offset: 0x0003B428
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000C2C RID: 3116 RVA: 0x0003D230 File Offset: 0x0003B430
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 2:
				case 3:
					try
					{
					}
					finally
					{
						this.<>m__Finally13();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002B0 RID: 688
			// (get) Token: 0x06000C2D RID: 3117 RVA: 0x0003D274 File Offset: 0x0003B474
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C2E RID: 3118 RVA: 0x0003D27C File Offset: 0x0003B47C
			[global::System.Diagnostics.DebuggerHidden]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public <DefineEdges>d__9(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000C2F RID: 3119 RVA: 0x0003D29C File Offset: 0x0003B49C
			private void <>m__Finally13()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x040006F8 RID: 1784
			private string <>2__current;

			// Token: 0x040006F9 RID: 1785
			private int <>1__state;

			// Token: 0x040006FA RID: 1786
			private int <>l__initialThreadId;

			// Token: 0x040006FB RID: 1787
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::Antlr.Runtime.Tree.DotTreeGenerator <>4__this;

			// Token: 0x040006FC RID: 1788
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object tree;

			// Token: 0x040006FD RID: 1789
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object <>3__tree;

			// Token: 0x040006FE RID: 1790
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;

			// Token: 0x040006FF RID: 1791
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::Antlr.Runtime.Tree.ITreeAdaptor <>3__adaptor;

			// Token: 0x04000700 RID: 1792
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int <n>5__a;

			// Token: 0x04000701 RID: 1793
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string <parentName>5__b;

			// Token: 0x04000702 RID: 1794
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string <parentText>5__c;

			// Token: 0x04000703 RID: 1795
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int <i>5__d;

			// Token: 0x04000704 RID: 1796
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object <child>5__e;

			// Token: 0x04000705 RID: 1797
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string <childText>5__f;

			// Token: 0x04000706 RID: 1798
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string <childName>5__10;

			// Token: 0x04000707 RID: 1799
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public string <t>5__11;

			// Token: 0x04000708 RID: 1800
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrap12;
		}
	}
}
