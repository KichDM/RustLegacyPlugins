using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x0200009C RID: 156
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class CommonTokenStream : global::Antlr.Runtime.BufferedTokenStream
	{
		// Token: 0x0600071B RID: 1819 RVA: 0x0002DDA0 File Offset: 0x0002BFA0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTokenStream()
		{
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0002DDA8 File Offset: 0x0002BFA8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTokenStream(global::Antlr.Runtime.ITokenSource tokenSource) : this(tokenSource, 0)
		{
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0002DDB4 File Offset: 0x0002BFB4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public CommonTokenStream(global::Antlr.Runtime.ITokenSource tokenSource, int channel) : base(tokenSource)
		{
			this._channel = channel;
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x0002DDC4 File Offset: 0x0002BFC4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Channel
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._channel;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x0002DDCC File Offset: 0x0002BFCC
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x0002DDD4 File Offset: 0x0002BFD4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.ITokenSource TokenSource
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return base.TokenSource;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				base.TokenSource = value;
				this._channel = 0;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0002DDE4 File Offset: 0x0002BFE4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void Consume()
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			this._p++;
			this._p = this.SkipOffTokenChannels(this._p);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0002DE18 File Offset: 0x0002C018
		protected override global::Antlr.Runtime.IToken LB(int k)
		{
			if (k == 0 || this._p - k < 0)
			{
				return null;
			}
			int num = this._p;
			for (int i = 1; i <= k; i++)
			{
				num = this.SkipOffTokenChannelsReverse(num - 1);
			}
			if (num < 0)
			{
				return null;
			}
			return this._tokens[num];
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0002DE74 File Offset: 0x0002C074
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override global::Antlr.Runtime.IToken LT(int k)
		{
			if (this._p == -1)
			{
				this.Setup();
			}
			if (k == 0)
			{
				return null;
			}
			if (k < 0)
			{
				return this.LB(-k);
			}
			int num = this._p;
			for (int i = 1; i < k; i++)
			{
				num = this.SkipOffTokenChannels(num + 1);
			}
			if (num > this.Range)
			{
				this.Range = num;
			}
			return this._tokens[num];
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0002DEF0 File Offset: 0x0002C0F0
		protected virtual int SkipOffTokenChannels(int i)
		{
			this.Sync(i);
			while (this._tokens[i].Channel != this._channel)
			{
				i++;
				this.Sync(i);
			}
			return i;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0002DF24 File Offset: 0x0002C124
		protected virtual int SkipOffTokenChannelsReverse(int i)
		{
			while (i >= 0 && this._tokens[i].Channel != this._channel)
			{
				i--;
			}
			return i;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0002DF54 File Offset: 0x0002C154
		protected override void Setup()
		{
			this._p = 0;
			this._p = this.SkipOffTokenChannels(this._p);
		}

		// Token: 0x04000372 RID: 882
		private int _channel;
	}
}
