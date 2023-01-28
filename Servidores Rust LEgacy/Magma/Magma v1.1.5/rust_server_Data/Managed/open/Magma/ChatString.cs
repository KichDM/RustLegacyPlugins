using System;

namespace Magma
{
	// Token: 0x02000002 RID: 2
	public class ChatString
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ChatString(string str)
		{
			this.origText = str;
			this.NewText = str;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002073 File Offset: 0x00000273
		public override string ToString()
		{
			return this.origText;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000207B File Offset: 0x0000027B
		public bool Contains(string str)
		{
			return this.origText.Contains(str);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002089 File Offset: 0x00000289
		public string Replace(string find, string replacement)
		{
			return this.origText.Replace(find, replacement);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002098 File Offset: 0x00000298
		public string Substring(int start, int length)
		{
			return this.origText.Substring(start, length);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020A7 File Offset: 0x000002A7
		public static implicit operator global::Magma.ChatString(string str)
		{
			return new global::Magma.ChatString(str);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020AF File Offset: 0x000002AF
		public static implicit operator string(global::Magma.ChatString cs)
		{
			return cs.origText;
		}

		// Token: 0x04000001 RID: 1
		public string NewText;

		// Token: 0x04000002 RID: 2
		private string origText;
	}
}
