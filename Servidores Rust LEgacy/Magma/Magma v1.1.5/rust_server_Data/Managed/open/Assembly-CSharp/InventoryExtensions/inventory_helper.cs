using System;
using uLink;

namespace InventoryExtensions
{
	// Token: 0x020006F9 RID: 1785
	public static class inventory_helper
	{
		// Token: 0x06003CF2 RID: 15602 RVA: 0x000D68FC File Offset: 0x000D4AFC
		public static int ReadInvInt(this global::uLink.BitStream stream)
		{
			return (int)stream.ReadByte();
		}

		// Token: 0x06003CF3 RID: 15603 RVA: 0x000D6904 File Offset: 0x000D4B04
		public static void WriteInvInt(this global::uLink.BitStream stream, int i)
		{
			stream.WriteByte((byte)i);
		}

		// Token: 0x06003CF4 RID: 15604 RVA: 0x000D6910 File Offset: 0x000D4B10
		public static void WriteInvInt(this global::uLink.BitStream stream, byte i)
		{
			stream.WriteByte(i);
		}
	}
}
