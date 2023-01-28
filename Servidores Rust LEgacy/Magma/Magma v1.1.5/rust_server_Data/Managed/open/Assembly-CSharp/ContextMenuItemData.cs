using System;
using System.Text;

// Token: 0x0200059A RID: 1434
internal struct ContextMenuItemData
{
	// Token: 0x06002F7F RID: 12159 RVA: 0x000B5238 File Offset: 0x000B3438
	public ContextMenuItemData(int name, int utf8_length, byte[] utf8_text)
	{
		this.name = name;
		this.utf8_length = utf8_length;
		this.utf8_text = utf8_text;
	}

	// Token: 0x06002F80 RID: 12160 RVA: 0x000B5250 File Offset: 0x000B3450
	public ContextMenuItemData(global::ContextActionPrototype prototype)
	{
		this.name = prototype.name;
		string text = prototype.text;
		if (string.IsNullOrEmpty(text))
		{
			this.utf8_length = 0;
			this.utf8_text = null;
		}
		else
		{
			this.utf8_text = global::System.Text.Encoding.UTF8.GetBytes(text);
			this.utf8_length = this.utf8_text.Length;
		}
	}

	// Token: 0x0400195A RID: 6490
	public readonly int name;

	// Token: 0x0400195B RID: 6491
	public readonly int utf8_length;

	// Token: 0x0400195C RID: 6492
	public readonly byte[] utf8_text;
}
