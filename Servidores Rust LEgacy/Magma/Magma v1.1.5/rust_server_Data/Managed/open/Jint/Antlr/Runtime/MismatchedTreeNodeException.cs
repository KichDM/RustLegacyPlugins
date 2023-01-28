using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Antlr.Runtime.Tree;

namespace Antlr.Runtime
{
	// Token: 0x020000B0 RID: 176
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class MismatchedTreeNodeException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x00030600 File Offset: 0x0002E800
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTreeNodeException()
		{
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00030608 File Offset: 0x0002E808
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTreeNodeException(string message) : base(message)
		{
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00030614 File Offset: 0x0002E814
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTreeNodeException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00030620 File Offset: 0x0002E820
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTreeNodeException(int expecting, global::Antlr.Runtime.Tree.ITreeNodeStream input) : base(input)
		{
			this._expecting = expecting;
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00030630 File Offset: 0x0002E830
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTreeNodeException(string message, int expecting, global::Antlr.Runtime.Tree.ITreeNodeStream input) : base(message, input)
		{
			this._expecting = expecting;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00030644 File Offset: 0x0002E844
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public MismatchedTreeNodeException(string message, int expecting, global::Antlr.Runtime.Tree.ITreeNodeStream input, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._expecting = expecting;
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00030658 File Offset: 0x0002E858
		protected MismatchedTreeNodeException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._expecting = info.GetInt32("Expecting");
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x00030684 File Offset: 0x0002E884
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Expecting
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._expecting;
			}
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0003068C File Offset: 0x0002E88C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("Expecting", this._expecting);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x000306B8 File Offset: 0x0002E8B8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"MismatchedTreeNodeException(",
				this.UnexpectedType,
				"!=",
				this.Expecting,
				")"
			});
		}

		// Token: 0x040003A1 RID: 929
		private readonly int _expecting;
	}
}
