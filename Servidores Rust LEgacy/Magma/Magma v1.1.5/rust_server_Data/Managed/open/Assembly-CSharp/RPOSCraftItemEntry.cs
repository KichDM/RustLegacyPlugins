using System;
using UnityEngine;

// Token: 0x02000534 RID: 1332
public class RPOSCraftItemEntry : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D34 RID: 11572 RVA: 0x000AB7A0 File Offset: 0x000A99A0
	public RPOSCraftItemEntry()
	{
	}

	// Token: 0x06002D35 RID: 11573 RVA: 0x000AB7A8 File Offset: 0x000A99A8
	public void SetSelected(bool selected)
	{
		global::UnityEngine.Color color = (!selected) ? global::UnityEngine.Color.white : global::UnityEngine.Color.yellow;
		base.GetComponentInChildren<global::UILabel>().color = color;
	}

	// Token: 0x06002D36 RID: 11574 RVA: 0x000AB7D8 File Offset: 0x000A99D8
	public void Update()
	{
		if (!global::RPOS.IsOpen)
		{
			return;
		}
		if (this.blueprint && this.blueprint == this.craftWindow.selectedItem)
		{
			this.SetSelected(true);
		}
		else
		{
			this.SetSelected(false);
		}
	}

	// Token: 0x06002D37 RID: 11575 RVA: 0x000AB830 File Offset: 0x000A9A30
	public void OnTooltip(bool show)
	{
		global::ItemToolTip.SetToolTip((!show || !(this.actualItemDataBlock != null)) ? null : this.actualItemDataBlock, null);
	}

	// Token: 0x0400173A RID: 5946
	public global::ItemDataBlock actualItemDataBlock;

	// Token: 0x0400173B RID: 5947
	public global::BlueprintDataBlock blueprint;

	// Token: 0x0400173C RID: 5948
	public global::RPOSCraftWindow craftWindow;
}
