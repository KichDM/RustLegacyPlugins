using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Antlr.Runtime.Tree;

namespace Antlr.Runtime
{
	// Token: 0x020000A0 RID: 160
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RecognitionException : global::System.Exception
	{
		// Token: 0x06000757 RID: 1879 RVA: 0x0002E6C0 File Offset: 0x0002C8C0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognitionException() : this("A recognition error occurred.", null, null)
		{
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0002E6D0 File Offset: 0x0002C8D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognitionException(global::Antlr.Runtime.IIntStream input) : this("A recognition error occurred.", input, null)
		{
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0002E6E0 File Offset: 0x0002C8E0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognitionException(string message) : this(message, null, null)
		{
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0002E6EC File Offset: 0x0002C8EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognitionException(string message, global::Antlr.Runtime.IIntStream input) : this(message, input, null)
		{
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0002E6F8 File Offset: 0x0002C8F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognitionException(string message, global::System.Exception innerException) : this(message, null, innerException)
		{
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0002E704 File Offset: 0x0002C904
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RecognitionException(string message, global::Antlr.Runtime.IIntStream input, global::System.Exception innerException) : base(message, innerException)
		{
			this._input = input;
			if (input != null)
			{
				this._index = input.Index;
				if (input is global::Antlr.Runtime.ITokenStream)
				{
					this._token = ((global::Antlr.Runtime.ITokenStream)input).LT(1);
					this._line = this._token.Line;
					this._charPositionInLine = this._token.CharPositionInLine;
				}
				global::Antlr.Runtime.Tree.ITreeNodeStream treeNodeStream = input as global::Antlr.Runtime.Tree.ITreeNodeStream;
				if (treeNodeStream != null)
				{
					this.ExtractInformationFromTreeNodeStream(treeNodeStream);
					return;
				}
				global::Antlr.Runtime.ICharStream charStream = input as global::Antlr.Runtime.ICharStream;
				if (charStream != null)
				{
					this._c = input.LA(1);
					this._line = ((global::Antlr.Runtime.ICharStream)input).Line;
					this._charPositionInLine = ((global::Antlr.Runtime.ICharStream)input).CharPositionInLine;
					return;
				}
				this._c = input.LA(1);
			}
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0002E7D4 File Offset: 0x0002C9D4
		protected RecognitionException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._index = info.GetInt32("Index");
			this._c = info.GetInt32("C");
			this._line = info.GetInt32("Line");
			this._charPositionInLine = info.GetInt32("CharPositionInLine");
			this._approximateLineInfo = info.GetBoolean("ApproximateLineInfo");
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x0002E854 File Offset: 0x0002CA54
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int UnexpectedType
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				if (this._input is global::Antlr.Runtime.ITokenStream)
				{
					return this._token.Type;
				}
				global::Antlr.Runtime.Tree.ITreeNodeStream treeNodeStream = this._input as global::Antlr.Runtime.Tree.ITreeNodeStream;
				if (treeNodeStream != null)
				{
					global::Antlr.Runtime.Tree.ITreeAdaptor treeAdaptor = treeNodeStream.TreeAdaptor;
					return treeAdaptor.GetType(this._node);
				}
				return this._c;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x0002E8B0 File Offset: 0x0002CAB0
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x0002E8B8 File Offset: 0x0002CAB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool ApproximateLineInfo
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._approximateLineInfo;
			}
			protected set
			{
				this._approximateLineInfo = value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0002E8C4 File Offset: 0x0002CAC4
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x0002E8CC File Offset: 0x0002CACC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IIntStream Input
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._input;
			}
			protected set
			{
				this._input = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0002E8D8 File Offset: 0x0002CAD8
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x0002E8E0 File Offset: 0x0002CAE0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.IToken Token
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._token;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._token = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x0002E8EC File Offset: 0x0002CAEC
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x0002E8F4 File Offset: 0x0002CAF4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Node
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._node;
			}
			protected set
			{
				this._node = value;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x0002E900 File Offset: 0x0002CB00
		// (set) Token: 0x06000768 RID: 1896 RVA: 0x0002E908 File Offset: 0x0002CB08
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Character
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._c;
			}
			protected set
			{
				this._c = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0002E914 File Offset: 0x0002CB14
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x0002E91C File Offset: 0x0002CB1C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Index
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._index;
			}
			protected set
			{
				this._index = value;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0002E928 File Offset: 0x0002CB28
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x0002E930 File Offset: 0x0002CB30
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Line
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._line;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._line = value;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0002E93C File Offset: 0x0002CB3C
		// (set) Token: 0x0600076E RID: 1902 RVA: 0x0002E944 File Offset: 0x0002CB44
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int CharPositionInLine
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._charPositionInLine;
			}
			[global::System.Runtime.InteropServices.ComVisible(false)]
			set
			{
				this._charPositionInLine = value;
			}
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0002E950 File Offset: 0x0002CB50
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("Index", this._index);
			info.AddValue("C", this._c);
			info.AddValue("Line", this._line);
			info.AddValue("CharPositionInLine", this._charPositionInLine);
			info.AddValue("ApproximateLineInfo", this._approximateLineInfo);
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0002E9D0 File Offset: 0x0002CBD0
		protected virtual void ExtractInformationFromTreeNodeStream(global::Antlr.Runtime.Tree.ITreeNodeStream input)
		{
			this._node = input.LT(1);
			global::Antlr.Runtime.ITokenStreamInformation tokenStreamInformation = input as global::Antlr.Runtime.ITokenStreamInformation;
			if (tokenStreamInformation != null)
			{
				global::Antlr.Runtime.IToken lastToken = tokenStreamInformation.LastToken;
				global::Antlr.Runtime.IToken lastRealToken = tokenStreamInformation.LastRealToken;
				if (lastRealToken != null)
				{
					this._token = lastRealToken;
					this._line = lastRealToken.Line;
					this._charPositionInLine = lastRealToken.CharPositionInLine;
					this._approximateLineInfo = lastRealToken.Equals(lastToken);
					return;
				}
			}
			else
			{
				global::Antlr.Runtime.Tree.ITreeAdaptor treeAdaptor = input.TreeAdaptor;
				global::Antlr.Runtime.IToken token = treeAdaptor.GetToken(this._node);
				if (token != null)
				{
					this._token = token;
					if (token.Line <= 0)
					{
						int num = -1;
						object t = input.LT(num);
						while (t != null)
						{
							global::Antlr.Runtime.IToken token2 = treeAdaptor.GetToken(t);
							if (token2 != null && token2.Line > 0)
							{
								this._line = token2.Line;
								this._charPositionInLine = token2.CharPositionInLine;
								this._approximateLineInfo = true;
								return;
							}
							num--;
							try
							{
								t = input.LT(num);
							}
							catch (global::System.ArgumentException)
							{
								t = null;
							}
						}
						return;
					}
					this._line = token.Line;
					this._charPositionInLine = token.CharPositionInLine;
					return;
				}
				else if (this._node is global::Antlr.Runtime.Tree.ITree)
				{
					this._line = ((global::Antlr.Runtime.Tree.ITree)this._node).Line;
					this._charPositionInLine = ((global::Antlr.Runtime.Tree.ITree)this._node).CharPositionInLine;
					if (this._node is global::Antlr.Runtime.Tree.CommonTree)
					{
						this._token = ((global::Antlr.Runtime.Tree.CommonTree)this._node).Token;
						return;
					}
				}
				else
				{
					int type = treeAdaptor.GetType(this._node);
					string text = treeAdaptor.GetText(this._node);
					this._token = new global::Antlr.Runtime.CommonToken(type, text);
				}
			}
		}

		// Token: 0x0400037E RID: 894
		private global::Antlr.Runtime.IIntStream _input;

		// Token: 0x0400037F RID: 895
		private int _index;

		// Token: 0x04000380 RID: 896
		private global::Antlr.Runtime.IToken _token;

		// Token: 0x04000381 RID: 897
		private object _node;

		// Token: 0x04000382 RID: 898
		private int _c;

		// Token: 0x04000383 RID: 899
		private int _line;

		// Token: 0x04000384 RID: 900
		private int _charPositionInLine;

		// Token: 0x04000385 RID: 901
		private bool _approximateLineInfo;
	}
}
