using System;
using Facepunch;
using UnityEngine;

// Token: 0x0200053A RID: 1338
public class RPOSInventoryCell : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D67 RID: 11623 RVA: 0x000AC72C File Offset: 0x000AA92C
	public RPOSInventoryCell()
	{
	}

	// Token: 0x06002D68 RID: 11624 RVA: 0x000AC740 File Offset: 0x000AA940
	// Note: this type is marked as 'beforefieldinit'.
	static RPOSInventoryCell()
	{
	}

	// Token: 0x170009C1 RID: 2497
	// (get) Token: 0x06002D69 RID: 11625 RVA: 0x000AC744 File Offset: 0x000AA944
	public global::IInventoryItem slotItem
	{
		get
		{
			global::IInventoryItem result;
			if (this._displayInventory && this._displayInventory.GetItem((int)this._mySlot, out result))
			{
				return result;
			}
			return null;
		}
	}

	// Token: 0x06002D6A RID: 11626 RVA: 0x000AC77C File Offset: 0x000AA97C
	private void Start()
	{
		if (!global::RPOSInventoryCell._myMaterial)
		{
			global::Facepunch.Bundling.Load<global::UnityEngine.Material>("content/item/mat/ItemIconShader", out global::RPOSInventoryCell._myMaterial);
		}
		this._icon.enabled = false;
		if (this.modSprites.Length > 0)
		{
			this.mod_empty = this.modSprites[0].atlas.GetSprite("slot_empty");
			this.mod_full = this.modSprites[0].atlas.GetSprite("slot_full");
		}
	}

	// Token: 0x06002D6B RID: 11627 RVA: 0x000AC7FC File Offset: 0x000AA9FC
	private void Update()
	{
		if (this._displayInventory)
		{
			if (global::RPOS.Item_IsClickedCell(this))
			{
				this.MakeEmpty();
			}
			else
			{
				global::IInventoryItem inventoryItem;
				this._displayInventory.GetItem((int)this._mySlot, out inventoryItem);
				if (this._displayInventory.MarkSlotClean((int)this._mySlot) || !object.ReferenceEquals(this._myDisplayItem, inventoryItem))
				{
					this.SetItem(inventoryItem);
				}
			}
			if (!global::RPOS.IsOpen && this._darkener)
			{
				if (this.backupColor == global::UnityEngine.Color.cyan)
				{
					this.backupColor = this._darkener.color;
				}
				if (this._myDisplayItem != null && this._displayInventory._activeItem == this._myDisplayItem)
				{
					this._darkener.color = global::UnityEngine.Color.grey;
				}
				else
				{
					this._darkener.color = this.backupColor;
				}
			}
		}
	}

	// Token: 0x06002D6C RID: 11628 RVA: 0x000AC8F8 File Offset: 0x000AAAF8
	public void SetItemLocked(bool locked)
	{
		this._locked = locked;
		if (this._locked)
		{
			this._icon.color = new global::UnityEngine.Color(0.5f, 0.5f, 0.5f, 0.5f);
		}
		else
		{
			this._icon.color = global::UnityEngine.Color.white;
		}
	}

	// Token: 0x06002D6D RID: 11629 RVA: 0x000AC950 File Offset: 0x000AAB50
	public bool IsItemLocked()
	{
		return this._locked;
	}

	// Token: 0x06002D6E RID: 11630 RVA: 0x000AC958 File Offset: 0x000AAB58
	private void MakeEmpty()
	{
		this._myDisplayItem = null;
		this._icon.enabled = false;
		this._stackLabel.text = string.Empty;
		this._usesLabel.text = string.Empty;
		if (this._amountBackground)
		{
			this._amountBackground.enabled = false;
		}
		if (this.modSprites.Length > 0)
		{
			for (int i = 0; i < this.modSprites.Length; i++)
			{
				this.modSprites[i].enabled = false;
			}
		}
	}

	// Token: 0x06002D6F RID: 11631 RVA: 0x000AC9EC File Offset: 0x000AABEC
	private void SetItem(global::IInventoryItem item)
	{
		if (item == null)
		{
			this.MakeEmpty();
			return;
		}
		this._myDisplayItem = item;
		if (item.datablock.IsSplittable())
		{
			this._stackLabel.color = global::UnityEngine.Color.white;
			if (item.uses > 1)
			{
				this._stackLabel.text = "x" + item.uses.ToString();
			}
			else
			{
				this._stackLabel.text = string.Empty;
			}
		}
		else
		{
			this._stackLabel.color = global::UnityEngine.Color.yellow;
			this._stackLabel.text = ((item.datablock._maxUses <= item.datablock.GetMinUsesForDisplay()) ? string.Empty : item.uses.ToString());
		}
		if (this._amountBackground)
		{
			if (this._stackLabel.text == string.Empty)
			{
				this._amountBackground.enabled = false;
			}
			else
			{
				global::UnityEngine.Vector2 vector = this._stackLabel.font.CalculatePrintedSize(this._stackLabel.text, true, global::UIFont.SymbolStyle.None);
				this._amountBackground.enabled = true;
				this._amountBackground.transform.localScale = new global::UnityEngine.Vector3(vector.x * this._stackLabel.transform.localScale.x + 12f, 16f, 1f);
			}
		}
		if (global::ItemDataBlock.LoadIconOrUnknown<global::UnityEngine.Texture>(item.datablock.icon, ref item.datablock.iconTex))
		{
			global::UnityEngine.Material material = global::TextureMaterial.GetMaterial(global::RPOSInventoryCell._myMaterial, item.datablock.iconTex);
			this._icon.material = (global::UIMaterial)material;
			this._icon.enabled = true;
		}
		global::IHeldItem heldItem;
		int num = ((heldItem = (item as global::IHeldItem)) != null) ? heldItem.totalModSlots : 0;
		int num2 = (num != 0) ? heldItem.usedModSlots : 0;
		for (int i = 0; i < this.modSprites.Length; i++)
		{
			if (i < num)
			{
				this.modSprites[i].enabled = true;
				this.modSprites[i].sprite = ((i >= num2) ? this.mod_empty : this.mod_full);
				this.modSprites[i].spriteName = this.modSprites[i].sprite.name;
			}
			else
			{
				this.modSprites[i].enabled = false;
			}
		}
		if (item.IsBroken())
		{
			this._icon.color = global::UnityEngine.Color.red;
		}
		else if (item.condition / item.maxcondition <= 0.4f)
		{
			this._icon.color = global::UnityEngine.Color.yellow;
		}
		else
		{
			this._icon.color = global::UnityEngine.Color.white;
		}
	}

	// Token: 0x06002D70 RID: 11632 RVA: 0x000ACCE0 File Offset: 0x000AAEE0
	private void OnClick()
	{
	}

	// Token: 0x06002D71 RID: 11633 RVA: 0x000ACCE4 File Offset: 0x000AAEE4
	private void OnPress(bool start)
	{
		if (start)
		{
			this.startedNoItem = (this.slotItem == null || this.IsItemLocked());
			if (this.startedNoItem)
			{
				global::UICamera.Cursor.CurrentButton.ClickNotification = global::UICamera.ClickNotification.None;
				global::UICamera.Cursor.DropNotification = (global::DropNotificationFlags)0;
			}
		}
	}

	// Token: 0x06002D72 RID: 11634 RVA: 0x000ACD38 File Offset: 0x000AAF38
	private void OnDragState(bool start)
	{
		if (start)
		{
			if (!this.dragging && !this.startedNoItem)
			{
				global::UICamera.Cursor.DropNotification = (global::DropNotificationFlags.DragLand | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.RegularHover | global::DropNotificationFlags.DragLandOutside);
				this.lastLanding = null;
				this.dragging = true;
				global::RPOS.Item_CellDragBegin(this);
				global::UICamera.Cursor.CurrentButton.ClickNotification = global::UICamera.ClickNotification.BasedOnDelta;
			}
		}
		else if (this.dragging)
		{
			this.dragging = false;
			if (this.lastLanding)
			{
				this.dragging = false;
				global::RPOS.Item_CellDragEnd(this, this.lastLanding);
				global::UICamera.Cursor.Buttons.LeftValue.ClickNotification = global::UICamera.ClickNotification.None;
			}
			else
			{
				global::RPOS.Item_CellReset();
			}
		}
	}

	// Token: 0x06002D73 RID: 11635 RVA: 0x000ACDF0 File Offset: 0x000AAFF0
	private void OnLand(global::UnityEngine.GameObject landing)
	{
		this.lastLanding = landing.GetComponent<global::RPOSInventoryCell>();
	}

	// Token: 0x06002D74 RID: 11636 RVA: 0x000ACE00 File Offset: 0x000AB000
	private void OnTooltip(bool show)
	{
		global::IInventoryItem inventoryItem;
		if (show && this._myDisplayItem != null)
		{
			global::IInventoryItem myDisplayItem = this._myDisplayItem;
			inventoryItem = myDisplayItem;
		}
		else
		{
			inventoryItem = null;
		}
		global::IInventoryItem item = inventoryItem;
		global::ItemDataBlock itemdb = (!show || this._myDisplayItem == null) ? null : this._myDisplayItem.datablock;
		global::ItemToolTip.SetToolTip(itemdb, item);
	}

	// Token: 0x06002D75 RID: 11637 RVA: 0x000ACE58 File Offset: 0x000AB058
	private void OnLandOutside()
	{
		if (this._displayInventory.gameObject == global::RPOS.ObservedPlayer.gameObject)
		{
			global::RPOS.TossItem(this._mySlot);
		}
	}

	// Token: 0x06002D76 RID: 11638 RVA: 0x000ACE90 File Offset: 0x000AB090
	private void OnAltLand(global::UnityEngine.GameObject landing)
	{
		global::RPOSInventoryCell component = landing.GetComponent<global::RPOSInventoryCell>();
		if (!component)
		{
			return;
		}
		global::RPOS.ItemCellAltClicked(component);
	}

	// Token: 0x06002D77 RID: 11639 RVA: 0x000ACEB8 File Offset: 0x000AB0B8
	private void OnAltClick()
	{
		if (this.slotItem != null)
		{
			global::RPOS.GetRightClickMenu().SetItem(this.slotItem);
		}
	}

	// Token: 0x04001763 RID: 5987
	public global::UISprite _amountBackground;

	// Token: 0x04001764 RID: 5988
	public global::UILabel _stackLabel;

	// Token: 0x04001765 RID: 5989
	public global::UILabel _usesLabel;

	// Token: 0x04001766 RID: 5990
	public global::UILabel _numberLabel;

	// Token: 0x04001767 RID: 5991
	public global::UITexture _icon;

	// Token: 0x04001768 RID: 5992
	public global::UISlicedSprite _background;

	// Token: 0x04001769 RID: 5993
	public global::UISprite _darkener;

	// Token: 0x0400176A RID: 5994
	private global::UnityEngine.Color backupColor = global::UnityEngine.Color.cyan;

	// Token: 0x0400176B RID: 5995
	public global::Inventory _displayInventory;

	// Token: 0x0400176C RID: 5996
	public byte _mySlot;

	// Token: 0x0400176D RID: 5997
	public global::IInventoryItem _myDisplayItem;

	// Token: 0x0400176E RID: 5998
	public static global::UnityEngine.Material _myMaterial;

	// Token: 0x0400176F RID: 5999
	private bool _locked;

	// Token: 0x04001770 RID: 6000
	public global::UISprite[] modSprites;

	// Token: 0x04001771 RID: 6001
	private global::UIAtlas.Sprite mod_empty;

	// Token: 0x04001772 RID: 6002
	private global::UIAtlas.Sprite mod_full;

	// Token: 0x04001773 RID: 6003
	private bool dragging;

	// Token: 0x04001774 RID: 6004
	private global::RPOSInventoryCell lastLanding;

	// Token: 0x04001775 RID: 6005
	private bool startedNoItem;
}
