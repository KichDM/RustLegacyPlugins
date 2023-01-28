using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000D6 RID: 214
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreePatternLexer
	{
		// Token: 0x060009DB RID: 2523 RVA: 0x00034970 File Offset: 0x00032B70
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreePatternLexer(string pattern)
		{
			this.pattern = pattern;
			this.n = pattern.Length;
			this.Consume();
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x000349A4 File Offset: 0x00032BA4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int NextToken()
		{
			this.sval.Length = 0;
			while (this.c != -1)
			{
				if (this.c == 0x20 || this.c == 0xA || this.c == 0xD || this.c == 9)
				{
					this.Consume();
				}
				else
				{
					if ((this.c >= 0x61 && this.c <= 0x7A) || (this.c >= 0x41 && this.c <= 0x5A) || this.c == 0x5F)
					{
						this.sval.Append((char)this.c);
						this.Consume();
						while ((this.c >= 0x61 && this.c <= 0x7A) || (this.c >= 0x41 && this.c <= 0x5A) || (this.c >= 0x30 && this.c <= 0x39) || this.c == 0x5F)
						{
							this.sval.Append((char)this.c);
							this.Consume();
						}
						return 3;
					}
					if (this.c == 0x28)
					{
						this.Consume();
						return 1;
					}
					if (this.c == 0x29)
					{
						this.Consume();
						return 2;
					}
					if (this.c == 0x25)
					{
						this.Consume();
						return 5;
					}
					if (this.c == 0x3A)
					{
						this.Consume();
						return 6;
					}
					if (this.c == 0x2E)
					{
						this.Consume();
						return 7;
					}
					if (this.c == 0x5B)
					{
						this.Consume();
						while (this.c != 0x5D)
						{
							if (this.c == 0x5C)
							{
								this.Consume();
								if (this.c != 0x5D)
								{
									this.sval.Append('\\');
								}
								this.sval.Append((char)this.c);
							}
							else
							{
								this.sval.Append((char)this.c);
							}
							this.Consume();
						}
						this.Consume();
						return 4;
					}
					this.Consume();
					this.error = true;
					return -1;
				}
			}
			return -1;
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x00034BDC File Offset: 0x00032DDC
		protected virtual void Consume()
		{
			this.p++;
			if (this.p >= this.n)
			{
				this.c = -1;
				return;
			}
			this.c = (int)this.pattern[this.p];
		}

		// Token: 0x04000414 RID: 1044
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Begin = 1;

		// Token: 0x04000415 RID: 1045
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int End = 2;

		// Token: 0x04000416 RID: 1046
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Id = 3;

		// Token: 0x04000417 RID: 1047
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Arg = 4;

		// Token: 0x04000418 RID: 1048
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Percent = 5;

		// Token: 0x04000419 RID: 1049
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Colon = 6;

		// Token: 0x0400041A RID: 1050
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int Dot = 7;

		// Token: 0x0400041B RID: 1051
		protected string pattern;

		// Token: 0x0400041C RID: 1052
		protected int p = -1;

		// Token: 0x0400041D RID: 1053
		protected int c;

		// Token: 0x0400041E RID: 1054
		protected int n;

		// Token: 0x0400041F RID: 1055
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::System.Text.StringBuilder sval = new global::System.Text.StringBuilder();

		// Token: 0x04000420 RID: 1056
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool error;
	}
}
