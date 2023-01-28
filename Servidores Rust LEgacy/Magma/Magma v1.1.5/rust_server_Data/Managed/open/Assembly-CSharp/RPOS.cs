using System;
using System.Collections.Generic;
using Facepunch.Cursor;
using UnityEngine;

// Token: 0x0200052E RID: 1326
public class RPOS : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002CB0 RID: 11440 RVA: 0x000A8D8C File Offset: 0x000A6F8C
	public RPOS()
	{
	}

	// Token: 0x170009A8 RID: 2472
	// (get) Token: 0x06002CB1 RID: 11441 RVA: 0x000A8D94 File Offset: 0x000A6F94
	private bool forceHideUseHoverText
	{
		get
		{
			return this.forceHideUseHoverTextCaseContextMenu || this.RPOSOn || this.forceHideUseHoverTextCaseLimitFlags;
		}
	}

	// Token: 0x06002CB2 RID: 11442 RVA: 0x000A8DB8 File Offset: 0x000A6FB8
	public static global::RPOSWindow GetWindowByName(string name)
	{
		if (!global::RPOS.g_RPOS)
		{
			return null;
		}
		foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
		{
			if (rposwindow && rposwindow.title == name)
			{
				global::RPOSWindow.EnsureAwake(rposwindow);
				return rposwindow;
			}
		}
		global::UnityEngine.Debug.Log("GetWindowByName returning null");
		return null;
	}

	// Token: 0x06002CB3 RID: 11443 RVA: 0x000A8E60 File Offset: 0x000A7060
	public static TRPOSWindow GetWindowByName<TRPOSWindow>(string name) where TRPOSWindow : global::RPOSWindow
	{
		if (!global::RPOS.g_RPOS)
		{
			return (TRPOSWindow)((object)null);
		}
		foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
		{
			if (rposwindow && rposwindow is TRPOSWindow && rposwindow.title == name)
			{
				global::RPOSWindow.EnsureAwake(rposwindow);
				return (TRPOSWindow)((object)rposwindow);
			}
		}
		return (TRPOSWindow)((object)null);
	}

	// Token: 0x06002CB4 RID: 11444 RVA: 0x000A8F18 File Offset: 0x000A7118
	public static global::System.Collections.Generic.IEnumerable<global::RPOSWindow> GetBumperWindowList()
	{
		global::RPOS rpos = global::RPOS.g_RPOS;
		if (!rpos)
		{
			global::UnityEngine.Object[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::RPOS));
			if (array.Length <= 0)
			{
				return new global::RPOSWindow[0];
			}
			rpos = (global::RPOS)array[0];
		}
		return rpos.windowList;
	}

	// Token: 0x06002CB5 RID: 11445 RVA: 0x000A8F6C File Offset: 0x000A716C
	public static bool BringToFront(global::RPOSWindow window)
	{
		window.EnsureAwake<global::RPOSWindow>();
		global::RPOS.g_windows.front = window;
		return global::RPOS.g_windows.lastPropertySetSuccess;
	}

	// Token: 0x06002CB6 RID: 11446 RVA: 0x000A8F80 File Offset: 0x000A7180
	public static bool MoveUp(global::RPOSWindow window)
	{
		return global::RPOS.g_windows.MoveUp(window.EnsureAwake<global::RPOSWindow>());
	}

	// Token: 0x06002CB7 RID: 11447 RVA: 0x000A8F90 File Offset: 0x000A7190
	public static bool SendToBack(global::RPOSWindow window)
	{
		window.EnsureAwake<global::RPOSWindow>();
		global::RPOS.g_windows.back = window;
		return global::RPOS.g_windows.lastPropertySetSuccess;
	}

	// Token: 0x06002CB8 RID: 11448 RVA: 0x000A8FA4 File Offset: 0x000A71A4
	public static bool MoveDown(global::RPOSWindow window)
	{
		return global::RPOS.g_windows.MoveDown(window.EnsureAwake<global::RPOSWindow>());
	}

	// Token: 0x06002CB9 RID: 11449 RVA: 0x000A8FB4 File Offset: 0x000A71B4
	public static void CloseWindowByName(string name)
	{
		using (global::TempList<global::RPOSWindow> allWindows = global::RPOS.AllWindows)
		{
			foreach (global::RPOSWindow rposwindow in allWindows)
			{
				if (rposwindow && rposwindow.title == name)
				{
					rposwindow.ExternalClose();
				}
			}
		}
	}

	// Token: 0x06002CBA RID: 11450 RVA: 0x000A9060 File Offset: 0x000A7260
	private static void InitWindow(global::RPOSWindow window)
	{
		if (window)
		{
			window.RPOSReady();
			window.CheckDisplay();
		}
	}

	// Token: 0x06002CBB RID: 11451 RVA: 0x000A907C File Offset: 0x000A727C
	internal static void RegisterWindow(global::RPOSWindow window)
	{
		if (window.zzz__index == -1)
		{
			window.zzz__index = global::RPOS.g_windows.allWindows.Count;
			global::RPOS.g_windows.allWindows.Add(window);
			if (global::RPOS.g_RPOS && !global::RPOS.g_RPOS.awaking)
			{
				global::RPOS.InitWindow(window);
			}
			global::RPOS.g_windows.orderChanged = true;
		}
	}

	// Token: 0x06002CBC RID: 11452 RVA: 0x000A90DC File Offset: 0x000A72DC
	internal static void UnregisterWindow(global::RPOSWindow window)
	{
		while (window.zzz__index > -1)
		{
			bool flag;
			try
			{
				flag = (global::RPOS.g_windows.allWindows[window.zzz__index] == window);
			}
			catch (global::System.IndexOutOfRangeException)
			{
				flag = false;
			}
			if (flag)
			{
				global::RPOS.g_windows.allWindows.RemoveAt(window.zzz__index);
				int i = window.zzz__index;
				int count = global::RPOS.g_windows.allWindows.Count;
				while (i < count)
				{
					global::RPOS.g_windows.allWindows[i].zzz__index = i;
					i++;
				}
				global::RPOS.g_windows.orderChanged = true;
				break;
			}
			int num = global::RPOS.g_windows.allWindows.IndexOf(window);
			global::UnityEngine.Debug.LogWarning(string.Format("Some how list maintanance failed, stored index was {0} but index of returned {1}", window.zzz__index, num), window);
			window.zzz__index = num;
		}
	}

	// Token: 0x170009A9 RID: 2473
	// (get) Token: 0x06002CBD RID: 11453 RVA: 0x000A91C0 File Offset: 0x000A73C0
	public static bool IsOpen
	{
		get
		{
			return global::RPOS.g_RPOS && global::RPOS.g_RPOS.RPOSOn && !global::RPOS.g_RPOS.awaking;
		}
	}

	// Token: 0x170009AA RID: 2474
	// (get) Token: 0x06002CBE RID: 11454 RVA: 0x000A91FC File Offset: 0x000A73FC
	public static bool IsClosed
	{
		get
		{
			return !global::RPOS.IsOpen;
		}
	}

	// Token: 0x170009AB RID: 2475
	// (get) Token: 0x06002CBF RID: 11455 RVA: 0x000A9208 File Offset: 0x000A7408
	public static global::TempList<global::RPOSWindow> AllWindows
	{
		get
		{
			return global::TempList<global::RPOSWindow>.New(global::RPOS.g_windows.allWindows);
		}
	}

	// Token: 0x170009AC RID: 2476
	// (get) Token: 0x06002CC0 RID: 11456 RVA: 0x000A9214 File Offset: 0x000A7414
	public static global::TempList<global::RPOSWindow> AllOpenWindows
	{
		get
		{
			global::TempList<global::RPOSWindow> tempList = global::TempList<global::RPOSWindow>.New();
			foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
			{
				if (rposwindow && rposwindow.open)
				{
					tempList.Add(rposwindow);
				}
			}
			return tempList;
		}
	}

	// Token: 0x170009AD RID: 2477
	// (get) Token: 0x06002CC1 RID: 11457 RVA: 0x000A9298 File Offset: 0x000A7498
	public static global::TempList<global::RPOSWindow> AllClosedWindows
	{
		get
		{
			global::TempList<global::RPOSWindow> tempList = global::TempList<global::RPOSWindow>.New();
			foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
			{
				if (rposwindow && rposwindow.closed)
				{
					tempList.Add(rposwindow);
				}
			}
			return tempList;
		}
	}

	// Token: 0x170009AE RID: 2478
	// (get) Token: 0x06002CC2 RID: 11458 RVA: 0x000A931C File Offset: 0x000A751C
	public static global::TempList<global::RPOSWindow> AllShowingWindows
	{
		get
		{
			global::TempList<global::RPOSWindow> tempList = global::TempList<global::RPOSWindow>.New();
			foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
			{
				if (rposwindow && rposwindow.showing)
				{
					tempList.Add(rposwindow);
				}
			}
			return tempList;
		}
	}

	// Token: 0x170009AF RID: 2479
	// (get) Token: 0x06002CC3 RID: 11459 RVA: 0x000A93A0 File Offset: 0x000A75A0
	public static global::TempList<global::RPOSWindow> AllHidingWindows
	{
		get
		{
			global::TempList<global::RPOSWindow> tempList = global::TempList<global::RPOSWindow>.New();
			foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
			{
				if (rposwindow && !rposwindow.showing)
				{
					tempList.Add(rposwindow);
				}
			}
			return tempList;
		}
	}

	// Token: 0x170009B0 RID: 2480
	// (get) Token: 0x06002CC4 RID: 11460 RVA: 0x000A9424 File Offset: 0x000A7624
	public static int WindowCount
	{
		get
		{
			return global::RPOS.g_windows.allWindows.Count;
		}
	}

	// Token: 0x06002CC5 RID: 11461 RVA: 0x000A9430 File Offset: 0x000A7630
	internal static bool GetWindowAbove(global::RPOSWindow window, out global::RPOSWindow fill)
	{
		if (!window)
		{
			throw new global::System.ArgumentNullException("window");
		}
		int order = window.order;
		if (order + 1 == global::RPOS.WindowCount)
		{
			fill = null;
			return false;
		}
		fill = global::RPOS.g_windows.allWindows[order + 1];
		return true;
	}

	// Token: 0x06002CC6 RID: 11462 RVA: 0x000A947C File Offset: 0x000A767C
	internal static global::RPOSWindow GetWindowAbove(global::RPOSWindow window)
	{
		global::RPOSWindow rposwindow;
		return (!global::RPOS.GetWindowAbove(window, out rposwindow)) ? null : rposwindow;
	}

	// Token: 0x06002CC7 RID: 11463 RVA: 0x000A94A0 File Offset: 0x000A76A0
	internal static bool GetWindowBelow(global::RPOSWindow window, out global::RPOSWindow fill)
	{
		if (!window)
		{
			throw new global::System.ArgumentNullException("window");
		}
		int order = window.order;
		if (order == 0)
		{
			fill = null;
			return false;
		}
		fill = global::RPOS.g_windows.allWindows[order - 1];
		return true;
	}

	// Token: 0x06002CC8 RID: 11464 RVA: 0x000A94E8 File Offset: 0x000A76E8
	internal static global::RPOSWindow GetWindowBelow(global::RPOSWindow window)
	{
		global::RPOSWindow rposwindow;
		return (!global::RPOS.GetWindowAbove(window, out rposwindow)) ? null : rposwindow;
	}

	// Token: 0x06002CC9 RID: 11465 RVA: 0x000A950C File Offset: 0x000A770C
	private void Awake()
	{
		this.actionPanel.enabled = false;
		global::RPOS.g_RPOS = this;
		try
		{
			this.awaking = true;
			this._bumper.Populate();
			this.unlocker = global::Facepunch.Cursor.LockCursorManager.CreateCursorUnlockNode(false, 0x40, "RPOS UNLOCKER");
			this.SetRPOSModeNoChecks(false);
			global::UIEventListener uieventListener = global::UIEventListener.Get(this._closeButton);
			global::UIEventListener uieventListener2 = uieventListener;
			uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.OnCloseButtonClicked));
			global::UIEventListener uieventListener3 = global::UIEventListener.Get(this._optionsButton);
			global::UIEventListener uieventListener4 = uieventListener3;
			uieventListener4.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener4.onClick, new global::UIEventListener.VoidDelegate(this.OnOptionsButtonClicked));
			global::TweenColor component = this.fadeSprite.GetComponent<global::TweenColor>();
			component.eventReceiver = base.gameObject;
			component.callWhenFinished = "FadeFinished";
		}
		finally
		{
			this.awaking = false;
		}
		using (global::TempList<global::RPOSWindow> tempList = global::TempList<global::RPOSWindow>.New(global::RPOS.g_windows.allWindows))
		{
			foreach (global::RPOSWindow window in tempList)
			{
				global::RPOS.InitWindow(window);
			}
		}
	}

	// Token: 0x06002CCA RID: 11466 RVA: 0x000A9688 File Offset: 0x000A7888
	private void OnDestroy()
	{
		if (this.unlocker != null)
		{
			this.unlocker.Dispose();
			this.unlocker = null;
		}
	}

	// Token: 0x06002CCB RID: 11467 RVA: 0x000A96A8 File Offset: 0x000A78A8
	public void OnCloseButtonClicked(global::UnityEngine.GameObject go)
	{
		this.SetRPOSMode(false);
	}

	// Token: 0x06002CCC RID: 11468 RVA: 0x000A96B4 File Offset: 0x000A78B4
	public void OnOptionsButtonClicked(global::UnityEngine.GameObject go)
	{
		global::RPOS.OpenOptions();
	}

	// Token: 0x06002CCD RID: 11469 RVA: 0x000A96BC File Offset: 0x000A78BC
	[global::System.Obsolete("Use var player = RPOS.ObservedPlayer", true)]
	public global::Controllable GetObservedPlayer()
	{
		return this.observedPlayer;
	}

	// Token: 0x06002CCE RID: 11470 RVA: 0x000A96C4 File Offset: 0x000A78C4
	public static void SetPlaqueActive(string plaqueName, bool on)
	{
		global::RPOS.g_RPOS._plaqueManager.SetPlaqueActive(plaqueName, on);
	}

	// Token: 0x06002CCF RID: 11471 RVA: 0x000A96D8 File Offset: 0x000A78D8
	public static global::RPOSItemRightClickMenu GetRightClickMenu()
	{
		return global::RPOS.g_RPOS.rightClickMenu;
	}

	// Token: 0x06002CD0 RID: 11472 RVA: 0x000A96E4 File Offset: 0x000A78E4
	[global::System.Obsolete("Use RPOS.ObservedPlayer = player")]
	public void SetObservedPlayer(global::Controllable player)
	{
		this.observedPlayer = player;
		global::RPOSWindow windowByName = global::RPOS.GetWindowByName("Inventory");
		if (windowByName)
		{
			global::RPOSInvCellManager componentInChildren = windowByName.GetComponentInChildren<global::RPOSInvCellManager>();
			componentInChildren.SetInventory(player.GetComponent<global::Inventory>(), false);
		}
		global::PlayerInventory component = player.GetComponent<global::PlayerInventory>();
		this._belt.CellIndexStart = 0x1E;
		this._belt.SetInventory(component, false);
		global::RPOSWindow windowByName2 = global::RPOS.GetWindowByName("Armor");
		global::RPOSInvCellManager componentInChildren2 = windowByName2.GetComponentInChildren<global::RPOSInvCellManager>();
		componentInChildren2.CellIndexStart = 0x24;
		componentInChildren2.SetInventory(component, false);
		this.SetRPOSMode(false);
		global::RPOS.InjuryUpdate();
	}

	// Token: 0x06002CD1 RID: 11473 RVA: 0x000A9774 File Offset: 0x000A7974
	private void OnContextMenuVisible(bool visible)
	{
	}

	// Token: 0x06002CD2 RID: 11474 RVA: 0x000A9778 File Offset: 0x000A7978
	[global::System.Obsolete("Use RPOS.Toggle()")]
	public void DoToggle()
	{
		this.SetRPOSMode(!this.RPOSOn);
	}

	// Token: 0x06002CD3 RID: 11475 RVA: 0x000A978C File Offset: 0x000A798C
	[global::System.Obsolete("Use RPOS.Hide()")]
	public void DoHide()
	{
		if (this.RPOSOn)
		{
			this.DoToggle();
		}
	}

	// Token: 0x06002CD4 RID: 11476 RVA: 0x000A97A0 File Offset: 0x000A79A0
	[global::System.Obsolete("Use RPOS.Show()")]
	public void DoShow()
	{
		if (!this.RPOSOn)
		{
			this.DoToggle();
		}
	}

	// Token: 0x06002CD5 RID: 11477 RVA: 0x000A97B4 File Offset: 0x000A79B4
	public static void ChangeRPOSMode(bool enable)
	{
		global::RPOS.g_RPOS.SetRPOSMode(enable);
	}

	// Token: 0x06002CD6 RID: 11478 RVA: 0x000A97C4 File Offset: 0x000A79C4
	private void SetRPOSMode(bool enable)
	{
		if (enable != this.RPOSOn)
		{
			if (this.forceOff && enable)
			{
				return;
			}
			this.SetRPOSModeNoChecks(enable);
		}
	}

	// Token: 0x06002CD7 RID: 11479 RVA: 0x000A97EC File Offset: 0x000A79EC
	private void SetRPOSModeNoChecks(bool enable)
	{
	}

	// Token: 0x06002CD8 RID: 11480 RVA: 0x000A97F0 File Offset: 0x000A79F0
	[global::System.Obsolete("Use RPOS.Item_CellReset()")]
	public void ItemCellReset()
	{
		if (this._clickedItemCell)
		{
			global::GUIHeldItem.Get().ClearHeldItem(this._clickedItemCell);
			this._clickedItemCell._displayInventory.MarkSlotDirty((int)this._clickedItemCell._mySlot);
		}
		else
		{
			global::GUIHeldItem.Get().ClearHeldItem();
		}
		this._clickedItemCell = null;
	}

	// Token: 0x06002CD9 RID: 11481 RVA: 0x000A9850 File Offset: 0x000A7A50
	[global::System.Obsolete("Use RPOS.Item_CellDragBegin()")]
	public void ItemCellDragBegin(global::RPOSInventoryCell cell)
	{
		this.ItemCellReset();
		this.ItemCellClicked(cell);
	}

	// Token: 0x06002CDA RID: 11482 RVA: 0x000A9860 File Offset: 0x000A7A60
	[global::System.Obsolete("Use RPOS.Item_CellDragEnd()")]
	public void ItemCellDragEnd(global::RPOSInventoryCell begin, global::RPOSInventoryCell end)
	{
		if (end)
		{
			global::GUIHeldItem.Get().ClearHeldItem(end);
		}
		this.ItemCellReset();
		if (begin != end && end && begin)
		{
			this._clickedItemCell = begin;
			this.ItemCellClicked(end);
		}
	}

	// Token: 0x06002CDB RID: 11483 RVA: 0x000A98BC File Offset: 0x000A7ABC
	[global::System.Obsolete("Use RPOS.Item_CellDrop()")]
	public void ItemCellDrop(global::RPOSInventoryCell cell)
	{
		if (this._clickedItemCell != null)
		{
			this.ItemCellClicked(cell);
		}
	}

	// Token: 0x06002CDC RID: 11484 RVA: 0x000A98D8 File Offset: 0x000A7AD8
	public static void TossItem(byte slot)
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.DoTossItem(slot);
		}
	}

	// Token: 0x06002CDD RID: 11485 RVA: 0x000A98F4 File Offset: 0x000A7AF4
	private void DoTossItem(byte slot)
	{
	}

	// Token: 0x06002CDE RID: 11486 RVA: 0x000A98F8 File Offset: 0x000A7AF8
	public static void ItemCellAltClicked(global::RPOSInventoryCell cell)
	{
	}

	// Token: 0x06002CDF RID: 11487 RVA: 0x000A98FC File Offset: 0x000A7AFC
	[global::System.Obsolete("Use RPOS.Item_CellClicked()")]
	public void ItemCellClicked(global::RPOSInventoryCell cell)
	{
		bool flag = false;
		global::Inventory inventory = null;
		global::IInventoryItem inventoryItem = null;
		global::IInventoryItem inventoryItem2 = null;
		if (this._clickedItemCell != null)
		{
			inventory = this._clickedItemCell._displayInventory;
			byte mySlot = this._clickedItemCell._mySlot;
			inventory.GetItem((int)mySlot, out inventoryItem);
		}
		global::Inventory displayInventory = cell._displayInventory;
		byte mySlot2 = cell._mySlot;
		displayInventory.GetItem((int)mySlot2, out inventoryItem2);
		if (inventoryItem == null && inventoryItem2 == null)
		{
			global::UnityEngine.Debug.Log("wtf");
		}
		if (inventoryItem == null && inventoryItem2 != null)
		{
			this._clickedItemCell = cell;
			inventoryItem = cell._myDisplayItem;
			flag = true;
		}
		else if (inventoryItem != null && inventoryItem2 != null)
		{
			bool shift = global::UnityEngine.Event.current.shift;
			global::NetEntityID netEntityID = global::NetEntityID.Get(inventory);
			global::NetEntityID netEntityID2 = global::NetEntityID.Get(displayInventory);
			inventoryItem = null;
			this._clickedItemCell = null;
		}
		else if (inventoryItem != null && inventoryItem2 == null)
		{
			global::NetEntityID netEntityID3 = global::NetEntityID.Get(displayInventory);
			this._clickedItemCell = null;
			inventoryItem = null;
			flag = true;
		}
		if (inventoryItem != global::GUIHeldItem.CurrentItem())
		{
			if (inventoryItem != null)
			{
				if (!flag || !global::GUIHeldItem.Get().SetHeldItem(cell))
				{
					global::GUIHeldItem.Get().SetHeldItem(inventoryItem);
				}
			}
			else if (flag && cell)
			{
				global::GUIHeldItem.Get().ClearHeldItem(cell);
			}
			else
			{
				global::GUIHeldItem.Get().ClearHeldItem();
			}
		}
	}

	// Token: 0x06002CE0 RID: 11488 RVA: 0x000A9A74 File Offset: 0x000A7C74
	public static void Item_CellReset()
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.ItemCellReset();
		}
	}

	// Token: 0x06002CE1 RID: 11489 RVA: 0x000A9A90 File Offset: 0x000A7C90
	public static void Item_CellDrop(global::RPOSInventoryCell cell)
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.ItemCellDrop(cell);
		}
	}

	// Token: 0x06002CE2 RID: 11490 RVA: 0x000A9AAC File Offset: 0x000A7CAC
	public static void Item_CellDragEnd(global::RPOSInventoryCell begin, global::RPOSInventoryCell end)
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.ItemCellDragEnd(begin, end);
		}
	}

	// Token: 0x06002CE3 RID: 11491 RVA: 0x000A9ACC File Offset: 0x000A7CCC
	public static void Item_CellDragBegin(global::RPOSInventoryCell begin)
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.ItemCellDragBegin(begin);
		}
	}

	// Token: 0x06002CE4 RID: 11492 RVA: 0x000A9AE8 File Offset: 0x000A7CE8
	public static bool Item_IsClickedCell(global::RPOSInventoryCell cell)
	{
		return global::RPOS.g_RPOS && global::RPOS.g_RPOS._clickedItemCell && global::RPOS.g_RPOS._clickedItemCell == cell;
	}

	// Token: 0x170009B1 RID: 2481
	// (get) Token: 0x06002CE5 RID: 11493 RVA: 0x000A9B2C File Offset: 0x000A7D2C
	// (set) Token: 0x06002CE6 RID: 11494 RVA: 0x000A9B50 File Offset: 0x000A7D50
	public static global::Controllable ObservedPlayer
	{
		get
		{
			return (!global::RPOS.g_RPOS) ? null : global::RPOS.g_RPOS.observedPlayer;
		}
		set
		{
			if (global::RPOS.g_RPOS)
			{
				global::RPOS.g_RPOS.SetObservedPlayer(value);
			}
		}
	}

	// Token: 0x06002CE7 RID: 11495 RVA: 0x000A9B6C File Offset: 0x000A7D6C
	public static bool GetObservedPlayerComponent<TComponent>(out TComponent component) where TComponent : global::UnityEngine.Component
	{
		if (global::RPOS.g_RPOS)
		{
			global::Controllable controllable = global::RPOS.g_RPOS.observedPlayer;
			if (controllable)
			{
				component = controllable.GetComponent<TComponent>();
				return component;
			}
		}
		component = (TComponent)((object)null);
		return false;
	}

	// Token: 0x06002CE8 RID: 11496 RVA: 0x000A9BC8 File Offset: 0x000A7DC8
	public static bool IsObservedPlayer(global::Controllable controllable)
	{
		return global::RPOS.g_RPOS && controllable && global::RPOS.g_RPOS.observedPlayer == controllable;
	}

	// Token: 0x06002CE9 RID: 11497 RVA: 0x000A9BF8 File Offset: 0x000A7DF8
	public static void HealthUpdate(float value)
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.UpdateHealth(value);
		}
	}

	// Token: 0x06002CEA RID: 11498 RVA: 0x000A9C14 File Offset: 0x000A7E14
	public static void Toggle()
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.DoToggle();
		}
	}

	// Token: 0x06002CEB RID: 11499 RVA: 0x000A9C30 File Offset: 0x000A7E30
	public static void Hide()
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.DoHide();
		}
	}

	// Token: 0x06002CEC RID: 11500 RVA: 0x000A9C4C File Offset: 0x000A7E4C
	public static void SetEquipmentDirty()
	{
		if (global::RPOS.g_RPOS)
		{
			global::RPOS.g_RPOS.EquipmentDirty();
		}
	}

	// Token: 0x170009B2 RID: 2482
	// (get) Token: 0x06002CED RID: 11501 RVA: 0x000A9C68 File Offset: 0x000A7E68
	public static bool Exists
	{
		get
		{
			return global::RPOS.g_RPOS;
		}
	}

	// Token: 0x06002CEE RID: 11502 RVA: 0x000A9C74 File Offset: 0x000A7E74
	public static void OpenInfoWindow(global::ItemDataBlock itemdb)
	{
	}

	// Token: 0x06002CEF RID: 11503 RVA: 0x000A9C78 File Offset: 0x000A7E78
	public static bool FocusListedWindow(string name)
	{
		if (!global::RPOS.g_RPOS)
		{
			return false;
		}
		if (global::RPOS.g_RPOS.forceHideInventory)
		{
			return false;
		}
		bool result = false;
		foreach (global::RPOSWindow rposwindow in global::RPOS.g_RPOS.windowList)
		{
			if (rposwindow && rposwindow.title == name)
			{
				if (!global::RPOS.g_RPOS.RPOSOn)
				{
					global::RPOS.g_RPOS.SetRPOSMode(true);
					if (!global::RPOS.g_RPOS.RPOSOn)
					{
						return false;
					}
				}
				rposwindow.zzz___INTERNAL_FOCUS();
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06002CF0 RID: 11504 RVA: 0x000A9D58 File Offset: 0x000A7F58
	public static bool FocusInventory()
	{
		return global::RPOS.FocusListedWindow("Inventory");
	}

	// Token: 0x06002CF1 RID: 11505 RVA: 0x000A9D64 File Offset: 0x000A7F64
	public static bool FocusArmor()
	{
		return global::RPOS.FocusListedWindow("Armor");
	}

	// Token: 0x06002CF2 RID: 11506 RVA: 0x000A9D70 File Offset: 0x000A7F70
	public static void OpenLootWindow(global::LootableObject lootObj)
	{
	}

	// Token: 0x06002CF3 RID: 11507 RVA: 0x000A9D74 File Offset: 0x000A7F74
	public static void OpenWorkbenchWindow(global::WorkBench workbenchObj)
	{
		if (global::RPOS.g_RPOS)
		{
			global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(global::RPOS.g_RPOS.windowAnchor, global::RPOS.g_RPOS.WorkbenchPanelPrefab);
			gameObject.GetComponent<global::RPOSWorkbenchWindow>().SetWorkbench(workbenchObj);
			global::RPOS.BringToFront(gameObject.GetComponent<global::RPOSWindow>());
			global::RPOS.g_RPOS.SetRPOSMode(true);
		}
	}

	// Token: 0x06002CF4 RID: 11508 RVA: 0x000A9DD0 File Offset: 0x000A7FD0
	public static void CloseWorkbenchWindow()
	{
		global::RPOS.CloseWindowByName("Workbench");
	}

	// Token: 0x06002CF5 RID: 11509 RVA: 0x000A9DDC File Offset: 0x000A7FDC
	public static void CloseLootWindow()
	{
		foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
		{
			if (rposwindow && rposwindow is global::RPOSLootWindow)
			{
				((global::RPOSLootWindow)rposwindow).LootClosed();
				break;
			}
		}
	}

	// Token: 0x06002CF6 RID: 11510 RVA: 0x000A9E60 File Offset: 0x000A8060
	[global::System.Obsolete("Use RPOS.SetEquipmentDirty()")]
	public void EquipmentDirty()
	{
		global::RPOSArmorWindow windowByName = global::RPOS.GetWindowByName<global::RPOSArmorWindow>("Armor");
		windowByName.ForceUpdate();
	}

	// Token: 0x06002CF7 RID: 11511 RVA: 0x000A9E80 File Offset: 0x000A8080
	[global::System.Obsolete("Use RPOS.HealthUpdate(amount)")]
	public void UpdateHealth(float amount)
	{
		this.healthLabel.text = amount.ToString("N0");
		this._healthProgress.sliderValue = global::UnityEngine.Mathf.Clamp01(amount / 100f);
		global::UIFilledSprite component = this._healthProgress.foreground.GetComponent<global::UIFilledSprite>();
		if (amount > 75f)
		{
			component.color = global::UnityEngine.Color.green;
		}
		else if (amount > 40f)
		{
			component.color = global::UnityEngine.Color.yellow;
		}
		else
		{
			component.color = global::UnityEngine.Color.red;
		}
	}

	// Token: 0x06002CF8 RID: 11512 RVA: 0x000A9F10 File Offset: 0x000A8110
	public static void SetCurrentFade(global::UnityEngine.Color col)
	{
		global::RPOS.g_RPOS.fadeSprite.color = col;
		global::TweenColor component = global::RPOS.g_RPOS.fadeSprite.GetComponent<global::TweenColor>();
		component.from = col;
		component.to = col;
		component.isFullscreen = true;
		global::RPOS.g_RPOS.fadeSprite.enabled = true;
	}

	// Token: 0x06002CF9 RID: 11513 RVA: 0x000A9F64 File Offset: 0x000A8164
	public static void DoFadeNow(float duration, global::UnityEngine.Color col)
	{
		global::RPOS.g_RPOS.DoFade(duration, col);
	}

	// Token: 0x06002CFA RID: 11514 RVA: 0x000A9F74 File Offset: 0x000A8174
	public static void DoFade(float delay, float duration, global::UnityEngine.Color col)
	{
		if (delay <= 0f)
		{
			global::RPOS.DoFadeNow(duration, col);
		}
		else
		{
			global::RPOS.g_RPOS.nextFadeColor = col;
			global::RPOS.g_RPOS.nextFadeDuration = duration;
			global::RPOS.g_RPOS.Invoke("Internal_DoFade", delay);
		}
	}

	// Token: 0x06002CFB RID: 11515 RVA: 0x000A9FB4 File Offset: 0x000A81B4
	public void Internal_DoFade()
	{
		this.DoFade(this.nextFadeDuration, this.nextFadeColor);
	}

	// Token: 0x06002CFC RID: 11516 RVA: 0x000A9FC8 File Offset: 0x000A81C8
	public void DoFade(float duration, global::UnityEngine.Color col)
	{
		this.fadeSprite.enabled = true;
		global::TweenColor.Begin(this.fadeSprite.gameObject, duration, col);
	}

	// Token: 0x06002CFD RID: 11517 RVA: 0x000A9FEC File Offset: 0x000A81EC
	public static void ClearFade()
	{
		global::RPOS.g_RPOS.fadeSprite.enabled = false;
		global::RPOS.g_RPOS.CancelInvoke("DoFade");
	}

	// Token: 0x06002CFE RID: 11518 RVA: 0x000AA010 File Offset: 0x000A8210
	public void FadeFinished()
	{
		if (this.fadeSprite.color.a == 0f)
		{
			this.fadeSprite.enabled = false;
		}
	}

	// Token: 0x06002CFF RID: 11519 RVA: 0x000AA048 File Offset: 0x000A8248
	private void Update()
	{
	}

	// Token: 0x06002D00 RID: 11520 RVA: 0x000AA04C File Offset: 0x000A824C
	private void LimitInventory(bool limit)
	{
		this.forceHideInventory = limit;
		using (global::TempList<global::RPOSWindow> allWindows = global::RPOS.AllWindows)
		{
			bool bumpersEnabled = !limit;
			foreach (global::RPOSWindow rposwindow in allWindows)
			{
				if (rposwindow && rposwindow.isInventoryRelated)
				{
					rposwindow.bumpersEnabled = bumpersEnabled;
				}
			}
			foreach (global::RPOSWindow rposwindow2 in allWindows)
			{
				if (rposwindow2)
				{
					rposwindow2.inventoryHide = limit;
				}
			}
		}
		if (this._belt)
		{
			global::UIPanel component = this._belt.GetComponent<global::UIPanel>();
			component.enabled = !limit;
		}
	}

	// Token: 0x06002D01 RID: 11521 RVA: 0x000AA188 File Offset: 0x000A8388
	public static void MetabolismUpdate()
	{
		global::RPOS.g_RPOS.DoMetabolismUpdate();
	}

	// Token: 0x06002D02 RID: 11522 RVA: 0x000AA194 File Offset: 0x000A8394
	public static void InjuryUpdate()
	{
		global::RPOS.g_RPOS.DoInjuryUpdate();
	}

	// Token: 0x06002D03 RID: 11523 RVA: 0x000AA1A0 File Offset: 0x000A83A0
	private void DoInjuryUpdate()
	{
		global::FallDamage component = global::RPOS.ObservedPlayer.GetComponent<global::FallDamage>();
		this._plaqueManager.SetPlaqueActive("PlaqueInjury", component.GetLegInjury() > 0f);
	}

	// Token: 0x06002D04 RID: 11524 RVA: 0x000AA1D8 File Offset: 0x000A83D8
	private void ClearInjury()
	{
		this._plaqueManager.SetPlaqueActive("PlaqueInjury", false);
	}

	// Token: 0x06002D05 RID: 11525 RVA: 0x000AA1EC File Offset: 0x000A83EC
	private void DoMetabolismUpdate()
	{
		global::Metabolism component = global::RPOS.ObservedPlayer.GetComponent<global::Metabolism>();
		this.calorieLabel.text = component.GetCalorieLevel().ToString("N0");
		this.radLabel.text = component.GetRadLevel().ToString("N0");
		this._foodProgress.sliderValue = global::UnityEngine.Mathf.Clamp01(component.GetCalorieLevel() / 3000f);
		this._plaqueManager.SetPlaqueActive("PlaqueHunger", component.GetCalorieLevel() < 500f);
		this._plaqueManager.SetPlaqueActive("PlaqueCold", component.IsCold());
		this._plaqueManager.SetPlaqueActive("PlaqueWarm", component.IsWarm());
		this._plaqueManager.SetPlaqueActive("PlaqueRadiation", component.HasRadiationPoisoning());
		this._plaqueManager.SetPlaqueActive("PlaquePoison", component.IsPoisoned());
		if (component.GetCalorieLevel() < 500f)
		{
			this.calorieLabel.color = global::UnityEngine.Color.red;
		}
		else
		{
			this.calorieLabel.color = global::UnityEngine.Color.white;
		}
	}

	// Token: 0x06002D06 RID: 11526 RVA: 0x000AA308 File Offset: 0x000A8508
	public static void SetActionProgress(bool show, string label, float progress)
	{
		if (show)
		{
			if (!string.IsNullOrEmpty(label))
			{
				global::RPOS.g_RPOS.actionLabel.text = label;
				global::RPOS.g_RPOS.actionLabel.enabled = true;
			}
			else
			{
				global::RPOS.g_RPOS.actionLabel.enabled = false;
			}
			global::RPOS.g_RPOS.actionProgress.sliderValue = progress;
			global::RPOS.g_RPOS.actionPanel.enabled = true;
		}
		else
		{
			global::RPOS.g_RPOS.actionPanel.enabled = false;
		}
	}

	// Token: 0x06002D07 RID: 11527 RVA: 0x000AA390 File Offset: 0x000A8590
	public static int GetIndex2D(int x, int y, int width)
	{
		return x + y * width;
	}

	// Token: 0x06002D08 RID: 11528 RVA: 0x000AA398 File Offset: 0x000A8598
	[global::System.Obsolete("Avoid using this", true)]
	public static global::RPOS Get()
	{
		return global::RPOS.g_RPOS;
	}

	// Token: 0x170009B3 RID: 2483
	// (get) Token: 0x06002D09 RID: 11529 RVA: 0x000AA3A0 File Offset: 0x000A85A0
	public static bool hideSprites
	{
		get
		{
			return global::RPOS.g_RPOS && (global::RPOS.g_RPOS.RPOSOn || global::RPOS.g_RPOS.forceHideSprites);
		}
	}

	// Token: 0x06002D0A RID: 11530 RVA: 0x000AA3DC File Offset: 0x000A85DC
	public static void OpenOptions()
	{
	}

	// Token: 0x06002D0B RID: 11531 RVA: 0x000AA3E0 File Offset: 0x000A85E0
	public static void CloseOptions()
	{
	}

	// Token: 0x06002D0C RID: 11532 RVA: 0x000AA3E4 File Offset: 0x000A85E4
	public static void ToggleOptions()
	{
	}

	// Token: 0x06002D0D RID: 11533 RVA: 0x000AA3E8 File Offset: 0x000A85E8
	public static void LocalInventoryModified()
	{
		global::RPOSWindow windowByName = global::RPOS.GetWindowByName("Crafting");
		global::RPOSCraftWindow component = windowByName.GetComponent<global::RPOSCraftWindow>();
		component.LocalInventoryModified();
		global::RPOS.SetPlaqueActive("PlaqueCrafting", global::RPOS.g_RPOS.observedPlayer.GetComponent<global::CraftingInventory>().isCrafting);
	}

	// Token: 0x040016ED RID: 5869
	public const global::RPOSLimitFlags kNoControllableLimitFlags = global::RPOSLimitFlags.KeepOff | global::RPOSLimitFlags.HideInventory | global::RPOSLimitFlags.HideContext | global::RPOSLimitFlags.HideSprites;

	// Token: 0x040016EE RID: 5870
	[global::UnityEngine.SerializeField]
	private global::UILabel _useHoverLabel;

	// Token: 0x040016EF RID: 5871
	[global::UnityEngine.SerializeField]
	private global::UIPanel _useHoverPanel;

	// Token: 0x040016F0 RID: 5872
	private global::Controllable lastUseHoverControllable;

	// Token: 0x040016F1 RID: 5873
	private global::IContextRequestableText lastUseHoverText;

	// Token: 0x040016F2 RID: 5874
	private global::IContextRequestableUpdatingText lastUseHoverUpdatingText;

	// Token: 0x040016F3 RID: 5875
	private global::IContextRequestablePointText lastUseHoverPointText;

	// Token: 0x040016F4 RID: 5876
	private global::UnityEngine.Vector3 pointUseHoverOrigin;

	// Token: 0x040016F5 RID: 5877
	private global::UnityEngine.Plane pointUseHoverPlane;

	// Token: 0x040016F6 RID: 5878
	private global::AABBox useHoverLabelBounds;

	// Token: 0x040016F7 RID: 5879
	private string useHoverText;

	// Token: 0x040016F8 RID: 5880
	private bool forceHideUseHoverTextCaseContextMenu;

	// Token: 0x040016F9 RID: 5881
	private bool forceHideUseHoverTextCaseLimitFlags;

	// Token: 0x040016FA RID: 5882
	private bool queuedUseHoverText;

	// Token: 0x040016FB RID: 5883
	private bool useHoverTextUpdatable;

	// Token: 0x040016FC RID: 5884
	private bool useHoverTextPoint;

	// Token: 0x040016FD RID: 5885
	private bool useHoverTextPanelVisible;

	// Token: 0x040016FE RID: 5886
	private global::UnityEngine.Vector3? useHoverTextScreenPoint;

	// Token: 0x040016FF RID: 5887
	public static global::RPOS g_RPOS;

	// Token: 0x04001700 RID: 5888
	public global::System.Collections.Generic.List<global::RPOSWindow> windowList;

	// Token: 0x04001701 RID: 5889
	public global::RPOSBumper _bumper;

	// Token: 0x04001702 RID: 5890
	public global::UnityEngine.GameObject _closeButton;

	// Token: 0x04001703 RID: 5891
	public global::UnityEngine.GameObject _optionsButton;

	// Token: 0x04001704 RID: 5892
	public global::RPOSInvCellManager _belt;

	// Token: 0x04001705 RID: 5893
	[global::System.NonSerialized]
	public global::RPOSInventoryCell _clickedItemCell;

	// Token: 0x04001706 RID: 5894
	private bool RPOSOn;

	// Token: 0x04001707 RID: 5895
	private bool forceOff;

	// Token: 0x04001708 RID: 5896
	private bool forceHideSprites;

	// Token: 0x04001709 RID: 5897
	private bool forceHideInventory;

	// Token: 0x0400170A RID: 5898
	private global::Controllable observedPlayer;

	// Token: 0x0400170B RID: 5899
	private global::Facepunch.Cursor.UnlockCursorNode unlocker;

	// Token: 0x0400170C RID: 5900
	public global::UnityEngine.GameObject windowAnchor;

	// Token: 0x0400170D RID: 5901
	public global::UnityEngine.GameObject bottomCenterAnchor;

	// Token: 0x0400170E RID: 5902
	public global::UnityEngine.GameObject LootPanelPrefab;

	// Token: 0x0400170F RID: 5903
	public global::UnityEngine.GameObject WorkbenchPanelPrefab;

	// Token: 0x04001710 RID: 5904
	public global::UnityEngine.GameObject InfoPanelPrefab;

	// Token: 0x04001711 RID: 5905
	public global::UISlider _healthProgress;

	// Token: 0x04001712 RID: 5906
	public global::UISlider _foodProgress;

	// Token: 0x04001713 RID: 5907
	public global::UILabel healthLabel;

	// Token: 0x04001714 RID: 5908
	public global::UISprite fadeSprite;

	// Token: 0x04001715 RID: 5909
	public global::UILabel calorieLabel;

	// Token: 0x04001716 RID: 5910
	public global::UILabel radLabel;

	// Token: 0x04001717 RID: 5911
	public global::UISprite radSprite;

	// Token: 0x04001718 RID: 5912
	public global::UIPanel actionPanel;

	// Token: 0x04001719 RID: 5913
	public global::UILabel actionLabel;

	// Token: 0x0400171A RID: 5914
	public global::UISlider actionProgress;

	// Token: 0x0400171B RID: 5915
	public global::RPOSItemRightClickMenu rightClickMenu;

	// Token: 0x0400171C RID: 5916
	public global::RPOSPlaqueManager _plaqueManager;

	// Token: 0x0400171D RID: 5917
	public global::UIPanel[] keepTop;

	// Token: 0x0400171E RID: 5918
	public global::UIPanel[] keepBottom;

	// Token: 0x0400171F RID: 5919
	[global::UnityEngine.HideInInspector]
	public global::UnityEngine.Color nextFadeColor;

	// Token: 0x04001720 RID: 5920
	[global::UnityEngine.HideInInspector]
	public float nextFadeDuration;

	// Token: 0x04001721 RID: 5921
	private bool awaking;

	// Token: 0x04001722 RID: 5922
	private bool rposModeLock;

	// Token: 0x04001723 RID: 5923
	private global::RPOSLimitFlags currentLimitFlags;

	// Token: 0x04001724 RID: 5924
	private int lastScreenWidth;

	// Token: 0x04001725 RID: 5925
	private int lastScreenHeight;

	// Token: 0x0200052F RID: 1327
	private static class g_windows
	{
		// Token: 0x06002D0E RID: 11534 RVA: 0x000AA42C File Offset: 0x000A862C
		// Note: this type is marked as 'beforefieldinit'.
		static g_windows()
		{
		}

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06002D0F RID: 11535 RVA: 0x000AA444 File Offset: 0x000A8644
		// (set) Token: 0x06002D10 RID: 11536 RVA: 0x000AA478 File Offset: 0x000A8678
		public static global::RPOSWindow front
		{
			get
			{
				int count = global::RPOS.g_windows.allWindows.Count;
				return (count != 0) ? global::RPOS.g_windows.allWindows[count - 1] : null;
			}
			set
			{
				global::RPOS.g_windows.lastPropertySetSuccess = false;
				if (!value)
				{
					throw new global::System.ArgumentNullException();
				}
				if (value.zzz__index == -1)
				{
					throw new global::System.InvalidOperationException("The window was not awake");
				}
				int count = global::RPOS.g_windows.allWindows.Count;
				if (count == 0)
				{
					throw new global::System.InvalidOperationException("There definitely should have been a window in the list unless you passed a prefab here or didnt ensure awake.");
				}
				if (count == 1 || global::RPOS.g_windows.allWindows[count - 1] == value)
				{
					return;
				}
				for (int i = value.zzz__index; i < count - 1; i++)
				{
					global::RPOSWindow rposwindow = global::RPOS.g_windows.allWindows[i + 1];
					global::RPOS.g_windows.allWindows[i] = rposwindow;
					rposwindow.zzz__index = i;
				}
				global::RPOS.g_windows.allWindows[count - 1] = value;
				value.zzz__index = count - 1;
				global::RPOS.g_windows.orderChanged = true;
				global::RPOS.g_windows.lastPropertySetSuccess = true;
			}
		}

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06002D11 RID: 11537 RVA: 0x000AA54C File Offset: 0x000A874C
		// (set) Token: 0x06002D12 RID: 11538 RVA: 0x000AA57C File Offset: 0x000A877C
		public static global::RPOSWindow back
		{
			get
			{
				return (global::RPOS.g_windows.allWindows.Count != 0) ? global::RPOS.g_windows.allWindows[0] : null;
			}
			set
			{
				global::RPOS.g_windows.lastPropertySetSuccess = false;
				if (!value)
				{
					throw new global::System.ArgumentNullException();
				}
				if (value.zzz__index == -1)
				{
					throw new global::System.InvalidOperationException("The window was not awake");
				}
				int count = global::RPOS.g_windows.allWindows.Count;
				if (count == 0)
				{
					throw new global::System.InvalidOperationException("There definitely should have been a window in the list unless you passed a prefab here or didnt ensure awake.");
				}
				if (count == 1 || global::RPOS.g_windows.allWindows[0] == value)
				{
					return;
				}
				for (int i = value.zzz__index; i > 0; i--)
				{
					global::RPOSWindow rposwindow = global::RPOS.g_windows.allWindows[i - 1];
					global::RPOS.g_windows.allWindows[i] = rposwindow;
					rposwindow.zzz__index = i;
				}
				global::RPOS.g_windows.allWindows[0] = value;
				value.zzz__index = 0;
				global::RPOS.g_windows.orderChanged = true;
				global::RPOS.g_windows.lastPropertySetSuccess = true;
			}
		}

		// Token: 0x06002D13 RID: 11539 RVA: 0x000AA648 File Offset: 0x000A8848
		public static bool MoveUp(global::RPOSWindow window)
		{
			if (!window)
			{
				throw new global::System.ArgumentNullException();
			}
			if (window.zzz__index == -1)
			{
				throw new global::System.InvalidOperationException("The window was not awake");
			}
			int count = global::RPOS.g_windows.allWindows.Count;
			if (count == 0)
			{
				throw new global::System.InvalidOperationException("There definitely should have been a window in the list unless you passed a prefab here or didnt ensure awake.");
			}
			if (count == 1 || global::RPOS.g_windows.allWindows[count - 1] == window)
			{
				return false;
			}
			global::RPOS.g_windows.allWindows.Reverse(window.zzz__index, 2);
			global::RPOS.g_windows.allWindows[window.zzz__index].zzz__index = window.zzz__index;
			window.zzz__index++;
			global::RPOS.g_windows.orderChanged = true;
			return true;
		}

		// Token: 0x06002D14 RID: 11540 RVA: 0x000AA6FC File Offset: 0x000A88FC
		public static bool MoveDown(global::RPOSWindow window)
		{
			if (!window)
			{
				throw new global::System.ArgumentNullException();
			}
			if (window.zzz__index == -1)
			{
				throw new global::System.InvalidOperationException("The window was not awake");
			}
			int count = global::RPOS.g_windows.allWindows.Count;
			if (count == 0)
			{
				throw new global::System.InvalidOperationException("There definitely should have been a window in the list unless you passed a prefab here or didnt ensure awake.");
			}
			if (count == 1 || global::RPOS.g_windows.allWindows[0] == window)
			{
				return false;
			}
			global::RPOS.g_windows.allWindows.Reverse(window.zzz__index - 1, 2);
			global::RPOS.g_windows.allWindows[window.zzz__index].zzz__index = window.zzz__index;
			window.zzz__index--;
			global::RPOS.g_windows.orderChanged = true;
			return true;
		}

		// Token: 0x06002D15 RID: 11541 RVA: 0x000AA7B0 File Offset: 0x000A89B0
		private static void ProcessTransform(global::UnityEngine.Transform transform, ref float z)
		{
			global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(transform);
			global::UnityEngine.Vector3 localPosition = transform.localPosition;
			localPosition.z = -(z + aabbox.max.z);
			z += aabbox.size.z;
			transform.localPosition = localPosition;
		}

		// Token: 0x06002D16 RID: 11542 RVA: 0x000AA800 File Offset: 0x000A8A00
		private static void ProcessTransform(ref global::UnityEngine.Matrix4x4 toRoot, global::RPOSWindow window, ref float z, out global::UnityEngine.Bounds bounds)
		{
			global::RPOS.g_windows.ProcessTransform(window.transform, ref z);
			global::UnityEngine.Vector4 windowDimensions = window.windowDimensions;
			global::UnityEngine.Matrix4x4 localToWorldMatrix = window.transform.localToWorldMatrix;
			bounds..ctor(toRoot.MultiplyPoint3x4(localToWorldMatrix.MultiplyPoint3x4(new global::UnityEngine.Vector3(windowDimensions.x, windowDimensions.y, 0f))), global::UnityEngine.Vector3.zero);
			bounds.Encapsulate(toRoot.MultiplyPoint3x4(localToWorldMatrix.MultiplyPoint3x4(new global::UnityEngine.Vector3(windowDimensions.x, windowDimensions.y + windowDimensions.w, 0f))));
			bounds.Encapsulate(toRoot.MultiplyPoint3x4(localToWorldMatrix.MultiplyPoint3x4(new global::UnityEngine.Vector3(windowDimensions.x + windowDimensions.z, windowDimensions.y, 0f))));
			bounds.Encapsulate(toRoot.MultiplyPoint3x4(localToWorldMatrix.MultiplyPoint3x4(new global::UnityEngine.Vector3(windowDimensions.x + windowDimensions.z, windowDimensions.y + windowDimensions.w, 0f))));
		}

		// Token: 0x06002D17 RID: 11543 RVA: 0x000AA900 File Offset: 0x000A8B00
		public static void ProcessDepth(global::UnityEngine.Transform uiRoot)
		{
			global::RPOS.g_windows.orderChanged = false;
			global::RPOS.g_windows.lastZ = 0f;
			global::UIPanel[] array = (!global::RPOS.g_RPOS) ? null : global::RPOS.g_RPOS.keepBottom;
			if (array != null)
			{
				for (int i = array.Length - 1; i >= 0; i--)
				{
					if (array[i])
					{
						global::RPOS.g_windows.ProcessTransform(array[i].transform, ref global::RPOS.g_windows.lastZ);
					}
				}
			}
			global::RPOS.g_windows.WindowRect[] array2 = new global::RPOS.g_windows.WindowRect[global::RPOS.g_windows.allWindows.Count];
			global::RPOS.g_windows.WindowRect a = default(global::RPOS.g_windows.WindowRect);
			global::UnityEngine.Matrix4x4 worldToLocalMatrix = uiRoot.worldToLocalMatrix;
			int num = 0;
			foreach (global::RPOSWindow rposwindow in global::RPOS.g_windows.allWindows)
			{
				if (rposwindow)
				{
					global::UnityEngine.Bounds bounds;
					global::RPOS.g_windows.ProcessTransform(ref worldToLocalMatrix, rposwindow, ref global::RPOS.g_windows.lastZ, out bounds);
					global::RPOS.g_windows.WindowRect windowRect = new global::RPOS.g_windows.WindowRect(bounds);
					if (a.empty)
					{
						a = windowRect;
					}
					else
					{
						a = new global::RPOS.g_windows.WindowRect(a, windowRect);
					}
					array2[num++] = windowRect;
				}
				else
				{
					array2[num++] = default(global::RPOS.g_windows.WindowRect);
				}
			}
			array = ((!global::RPOS.g_RPOS) ? null : global::RPOS.g_RPOS.keepTop);
			if (array != null)
			{
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j])
					{
						global::RPOS.g_windows.ProcessTransform(array[j].transform, ref global::RPOS.g_windows.lastZ);
					}
				}
			}
		}

		// Token: 0x04001726 RID: 5926
		public static global::System.Collections.Generic.List<global::RPOSWindow> allWindows = new global::System.Collections.Generic.List<global::RPOSWindow>();

		// Token: 0x04001727 RID: 5927
		public static bool orderChanged = false;

		// Token: 0x04001728 RID: 5928
		public static bool lastPropertySetSuccess = false;

		// Token: 0x04001729 RID: 5929
		public static float lastZ;

		// Token: 0x02000530 RID: 1328
		private struct WindowRect
		{
			// Token: 0x06002D18 RID: 11544 RVA: 0x000AAACC File Offset: 0x000A8CCC
			public WindowRect(global::RPOS.g_windows.WindowRect a, global::RPOS.g_windows.WindowRect b)
			{
				if (a.x < b.x)
				{
					this.x = a.x;
					int num = b.x + (int)b.width - a.x;
					if (num < (int)a.width)
					{
						this.width = a.width;
					}
					else
					{
						this.width = (ushort)num;
					}
				}
				else
				{
					this.x = b.x;
					int num = a.x + (int)a.width - b.x;
					if (num < (int)b.width)
					{
						this.width = b.width;
					}
					else
					{
						this.width = (ushort)num;
					}
				}
				if (a.y < b.y)
				{
					this.y = a.y;
					int num = b.y + (int)b.height - a.y;
					if (num < (int)a.height)
					{
						this.height = a.height;
					}
					else
					{
						this.height = (ushort)num;
					}
				}
				else
				{
					this.y = b.y;
					int num = a.y + (int)a.height - b.y;
					if (num < (int)b.height)
					{
						this.height = b.height;
					}
					else
					{
						this.height = (ushort)num;
					}
				}
			}

			// Token: 0x06002D19 RID: 11545 RVA: 0x000AAC3C File Offset: 0x000A8E3C
			public WindowRect(int x, int y, int width, int height)
			{
				if (width < 0)
				{
					this.x = x + width;
					this.width = (ushort)(-(ushort)width);
				}
				else
				{
					this.x = x;
					this.width = (ushort)width;
				}
				if (height < 0)
				{
					this.y = y + height;
					this.height = (ushort)(-(ushort)height);
				}
				else
				{
					this.y = y;
					this.height = (ushort)height;
				}
			}

			// Token: 0x06002D1A RID: 11546 RVA: 0x000AACA8 File Offset: 0x000A8EA8
			public WindowRect(int x, int y, ushort width, ushort height)
			{
				this.x = x;
				this.y = y;
				this.width = width;
				this.height = height;
			}

			// Token: 0x06002D1B RID: 11547 RVA: 0x000AACC8 File Offset: 0x000A8EC8
			public WindowRect(global::UnityEngine.Bounds bounds)
			{
				global::UnityEngine.Vector2 vector = bounds.center;
				global::UnityEngine.Vector2 vector2 = bounds.extents;
				if (vector2.x < 0f)
				{
					this.x = global::UnityEngine.Mathf.FloorToInt(vector.x + vector2.x);
					this.width = (ushort)global::UnityEngine.Mathf.CeilToInt(vector.x - vector2.x - (float)this.x);
				}
				else
				{
					this.x = global::UnityEngine.Mathf.FloorToInt(vector.x - vector2.x);
					this.width = (ushort)global::UnityEngine.Mathf.CeilToInt(vector.x + vector2.x - (float)this.x);
				}
				if (vector2.y < 0f)
				{
					this.y = global::UnityEngine.Mathf.FloorToInt(vector.y + vector2.y);
					this.height = (ushort)global::UnityEngine.Mathf.CeilToInt(vector.y - vector2.y - (float)this.y);
				}
				else
				{
					this.y = global::UnityEngine.Mathf.FloorToInt(vector.y - vector2.y);
					this.height = (ushort)global::UnityEngine.Mathf.CeilToInt(vector.y + vector2.y - (float)this.y);
				}
			}

			// Token: 0x170009B6 RID: 2486
			// (get) Token: 0x06002D1C RID: 11548 RVA: 0x000AAE10 File Offset: 0x000A9010
			public bool empty
			{
				get
				{
					return this.width == 0 || this.height == 0;
				}
			}

			// Token: 0x170009B7 RID: 2487
			// (get) Token: 0x06002D1D RID: 11549 RVA: 0x000AAE2C File Offset: 0x000A902C
			public int left
			{
				get
				{
					return this.x;
				}
			}

			// Token: 0x170009B8 RID: 2488
			// (get) Token: 0x06002D1E RID: 11550 RVA: 0x000AAE34 File Offset: 0x000A9034
			public int right
			{
				get
				{
					return this.x + (int)this.width;
				}
			}

			// Token: 0x170009B9 RID: 2489
			// (get) Token: 0x06002D1F RID: 11551 RVA: 0x000AAE44 File Offset: 0x000A9044
			public int top
			{
				get
				{
					return this.y;
				}
			}

			// Token: 0x170009BA RID: 2490
			// (get) Token: 0x06002D20 RID: 11552 RVA: 0x000AAE4C File Offset: 0x000A904C
			public int bottom
			{
				get
				{
					return this.y + (int)this.height;
				}
			}

			// Token: 0x170009BB RID: 2491
			// (get) Token: 0x06002D21 RID: 11553 RVA: 0x000AAE5C File Offset: 0x000A905C
			public int center
			{
				get
				{
					return this.x + (int)(this.width / 2);
				}
			}

			// Token: 0x170009BC RID: 2492
			// (get) Token: 0x06002D22 RID: 11554 RVA: 0x000AAE70 File Offset: 0x000A9070
			public int middle
			{
				get
				{
					return this.y + (int)(this.height / 2);
				}
			}

			// Token: 0x06002D23 RID: 11555 RVA: 0x000AAE84 File Offset: 0x000A9084
			public bool Contains(global::RPOS.g_windows.WindowRect other)
			{
				return ((this.x >= other.x) ? (this.x == other.x && other.width < this.width) : (other.x + (int)other.width - this.x <= (int)this.width)) && ((this.y >= other.y) ? (this.y == other.y && other.height < this.height) : (other.y + (int)other.height - this.y <= (int)this.height));
			}

			// Token: 0x06002D24 RID: 11556 RVA: 0x000AAF54 File Offset: 0x000A9154
			public bool ContainsOrEquals(global::RPOS.g_windows.WindowRect other)
			{
				return ((other.x != this.x) ? (this.x < other.x && other.x + (int)other.width - this.x <= (int)this.width) : (other.width <= this.width)) && ((other.y != this.y) ? (this.y < other.y && other.y + (int)other.height - this.y <= (int)this.height) : (other.height <= this.height));
			}

			// Token: 0x06002D25 RID: 11557 RVA: 0x000AB028 File Offset: 0x000A9228
			public bool Equals(global::RPOS.g_windows.WindowRect other)
			{
				return this.width == other.width && this.x == other.x && this.y == other.y && this.height == other.height;
			}

			// Token: 0x06002D26 RID: 11558 RVA: 0x000AB080 File Offset: 0x000A9280
			public bool Overlaps(global::RPOS.g_windows.WindowRect other)
			{
				return ((other.x >= this.x) ? (this.x - other.x + (int)this.width > 0) : (other.x + (int)other.width > this.x)) && ((other.y >= this.y) ? (this.y - other.y + (int)this.height > 0) : (other.y + (int)other.height > this.y));
			}

			// Token: 0x06002D27 RID: 11559 RVA: 0x000AB124 File Offset: 0x000A9324
			public bool OverlapsOrTouches(global::RPOS.g_windows.WindowRect other)
			{
				return (other.x == this.x || ((other.x >= this.x) ? (this.x - other.x + (int)this.width >= 0) : (other.x + (int)other.width >= this.x))) && (other.y == this.y || ((other.y >= this.y) ? (this.y - other.y + (int)this.height >= 0) : (other.y + (int)other.height >= this.y)));
			}

			// Token: 0x06002D28 RID: 11560 RVA: 0x000AB1F8 File Offset: 0x000A93F8
			public bool OverlapsOrOutside(global::RPOS.g_windows.WindowRect other)
			{
				return other.x < this.x || other.y < this.y || this.x - other.x + (int)other.width > (int)this.width || this.y - other.y + (int)this.height > (int)this.height;
			}

			// Token: 0x06002D29 RID: 11561 RVA: 0x000AB26C File Offset: 0x000A946C
			public bool OverlapsTouchesOrOutside(global::RPOS.g_windows.WindowRect other)
			{
				return other.x <= this.x || other.y <= this.y || this.x - other.x + (int)other.width >= (int)this.width || this.y - other.y + (int)this.height >= (int)this.height;
			}

			// Token: 0x06002D2A RID: 11562 RVA: 0x000AB2E4 File Offset: 0x000A94E4
			public override string ToString()
			{
				return string.Format("{{x:{0},y:{1},width:{2},height:{3}}}", new object[]
				{
					this.x,
					this.y,
					this.width,
					this.height
				});
			}

			// Token: 0x0400172A RID: 5930
			public int x;

			// Token: 0x0400172B RID: 5931
			public int y;

			// Token: 0x0400172C RID: 5932
			public ushort width;

			// Token: 0x0400172D RID: 5933
			public ushort height;
		}
	}
}
