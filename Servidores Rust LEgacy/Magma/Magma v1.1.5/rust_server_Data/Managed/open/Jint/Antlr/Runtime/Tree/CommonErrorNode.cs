using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C4 RID: 196
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class CommonErrorNode : global::Antlr.Runtime.Tree.CommonTree
	{
		// Token: 0x06000951 RID: 2385 RVA: 0x00033370 File Offset: 0x00031570
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonErrorNode(global::Antlr.Runtime.ITokenStream input, global::Antlr.Runtime.IToken start, global::Antlr.Runtime.IToken stop, global::Antlr.Runtime.RecognitionException e)
		{
			if (stop == null || (stop.TokenIndex < start.TokenIndex && stop.Type != -1))
			{
				stop = start;
			}
			this.input = input;
			this.start = start;
			this.stop = stop;
			this.trappedException = e;
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x000333CC File Offset: 0x000315CC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override bool IsNil
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return false;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x000333D0 File Offset: 0x000315D0
		// (set) Token: 0x06000954 RID: 2388 RVA: 0x0003347C File Offset: 0x0003167C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string Text
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				string result;
				if (this.start != null)
				{
					int tokenIndex = this.start.TokenIndex;
					int num = this.stop.TokenIndex;
					if (this.stop.Type == -1)
					{
						num = ((global::Antlr.Runtime.ITokenStream)this.input).Count;
					}
					result = ((global::Antlr.Runtime.ITokenStream)this.input).ToString(tokenIndex, num);
				}
				else if (this.start is global::Antlr.Runtime.Tree.ITree)
				{
					result = ((global::Antlr.Runtime.Tree.ITreeNodeStream)this.input).ToString(this.start, this.stop);
				}
				else
				{
					result = "<unknown>";
				}
				return result;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x00033480 File Offset: 0x00031680
		// (set) Token: 0x06000956 RID: 2390 RVA: 0x00033484 File Offset: 0x00031684
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

		// Token: 0x06000957 RID: 2391 RVA: 0x00033488 File Offset: 0x00031688
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			if (this.trappedException is global::Antlr.Runtime.MissingTokenException)
			{
				return "<missing type: " + ((global::Antlr.Runtime.MissingTokenException)this.trappedException).MissingType + ">";
			}
			if (this.trappedException is global::Antlr.Runtime.UnwantedTokenException)
			{
				return string.Concat(new object[]
				{
					"<extraneous: ",
					((global::Antlr.Runtime.UnwantedTokenException)this.trappedException).UnexpectedToken,
					", resync=",
					this.Text,
					">"
				});
			}
			if (this.trappedException is global::Antlr.Runtime.MismatchedTokenException)
			{
				return string.Concat(new object[]
				{
					"<mismatched token: ",
					this.trappedException.Token,
					", resync=",
					this.Text,
					">"
				});
			}
			if (this.trappedException is global::Antlr.Runtime.NoViableAltException)
			{
				return string.Concat(new object[]
				{
					"<unexpected: ",
					this.trappedException.Token,
					", resync=",
					this.Text,
					">"
				});
			}
			return "<error: " + this.Text + ">";
		}

		// Token: 0x040003E3 RID: 995
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IIntStream input;

		// Token: 0x040003E4 RID: 996
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IToken start;

		// Token: 0x040003E5 RID: 997
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IToken stop;

		// Token: 0x040003E6 RID: 998
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.RecognitionException trappedException;
	}
}
