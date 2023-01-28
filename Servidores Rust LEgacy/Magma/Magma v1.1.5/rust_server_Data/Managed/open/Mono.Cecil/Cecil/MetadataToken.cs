using System;

namespace Mono.Cecil
{
	// Token: 0x0200000F RID: 15
	public struct MetadataToken
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000299C File Offset: 0x00000B9C
		public uint RID
		{
			get
			{
				return this.token & 0xFFFFFFU;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000029AA File Offset: 0x00000BAA
		public global::Mono.Cecil.TokenType TokenType
		{
			get
			{
				return (global::Mono.Cecil.TokenType)(this.token & 0xFF000000U);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000029B8 File Offset: 0x00000BB8
		public MetadataToken(uint token)
		{
			this.token = token;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000029C1 File Offset: 0x00000BC1
		public MetadataToken(global::Mono.Cecil.TokenType type)
		{
			this = new global::Mono.Cecil.MetadataToken(type, 0);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000029CB File Offset: 0x00000BCB
		public MetadataToken(global::Mono.Cecil.TokenType type, uint rid)
		{
			this.token = (uint)(type | (global::Mono.Cecil.TokenType)rid);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000029D6 File Offset: 0x00000BD6
		public MetadataToken(global::Mono.Cecil.TokenType type, int rid)
		{
			this.token = (uint)(type | (global::Mono.Cecil.TokenType)rid);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000029E1 File Offset: 0x00000BE1
		public int ToInt32()
		{
			return (int)this.token;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000029E9 File Offset: 0x00000BE9
		public uint ToUInt32()
		{
			return this.token;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000029F1 File Offset: 0x00000BF1
		public override int GetHashCode()
		{
			return (int)this.token;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000029FC File Offset: 0x00000BFC
		public override bool Equals(object obj)
		{
			return obj is global::Mono.Cecil.MetadataToken && ((global::Mono.Cecil.MetadataToken)obj).token == this.token;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002A29 File Offset: 0x00000C29
		public static bool operator ==(global::Mono.Cecil.MetadataToken one, global::Mono.Cecil.MetadataToken other)
		{
			return one.token == other.token;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002A3B File Offset: 0x00000C3B
		public static bool operator !=(global::Mono.Cecil.MetadataToken one, global::Mono.Cecil.MetadataToken other)
		{
			return one.token != other.token;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002A50 File Offset: 0x00000C50
		public override string ToString()
		{
			return string.Format("[{0}:0x{1}]", this.TokenType, this.RID.ToString("x4"));
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002A85 File Offset: 0x00000C85
		// Note: this type is marked as 'beforefieldinit'.
		static MetadataToken()
		{
		}

		// Token: 0x0400001C RID: 28
		private readonly uint token;

		// Token: 0x0400001D RID: 29
		public static readonly global::Mono.Cecil.MetadataToken Zero = new global::Mono.Cecil.MetadataToken(0U);
	}
}
