using System;
using System.Collections.Generic;

namespace Magma
{
	// Token: 0x0200000D RID: 13
	public class ItemsBlocks : global::System.Collections.Generic.List<global::ItemDataBlock>
	{
		// Token: 0x0600007C RID: 124 RVA: 0x000032B8 File Offset: 0x000014B8
		public ItemsBlocks(global::System.Collections.Generic.List<global::ItemDataBlock> items)
		{
			foreach (global::ItemDataBlock item in items)
			{
				base.Add(item);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000330C File Offset: 0x0000150C
		public global::ItemDataBlock Find(string str)
		{
			foreach (global::ItemDataBlock itemDataBlock in this)
			{
				if (itemDataBlock.name.ToLower() == str.ToLower())
				{
					return itemDataBlock;
				}
			}
			return null;
		}
	}
}
