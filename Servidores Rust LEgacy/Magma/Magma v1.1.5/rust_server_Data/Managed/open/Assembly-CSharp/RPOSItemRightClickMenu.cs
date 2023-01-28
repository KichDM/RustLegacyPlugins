using System;
using UnityEngine;

// Token: 0x0200053B RID: 1339
public class RPOSItemRightClickMenu : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D78 RID: 11640 RVA: 0x000ACED8 File Offset: 0x000AB0D8
	public RPOSItemRightClickMenu()
	{
	}

	// Token: 0x06002D79 RID: 11641 RVA: 0x000ACEE0 File Offset: 0x000AB0E0
	// Note: this type is marked as 'beforefieldinit'.
	static RPOSItemRightClickMenu()
	{
	}

	// Token: 0x06002D7A RID: 11642 RVA: 0x000ACEF0 File Offset: 0x000AB0F0
	public void Awake()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.planeTest = new global::UnityEngine.Plane(this.uiCamera.transform.forward * 1f, new global::UnityEngine.Vector3(0f, 0f, 2f));
		base.GetComponent<global::UIPanel>().enabled = false;
	}

	// Token: 0x06002D7B RID: 11643 RVA: 0x000ACF6C File Offset: 0x000AB16C
	public void AddRightClickEntry(string entry)
	{
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(base.gameObject, this._buttonPrefab);
		gameObject.GetComponentInChildren<global::UILabel>().text = entry;
		global::UIEventListener uieventListener = global::UIEventListener.Get(gameObject);
		global::UIEventListener uieventListener2 = uieventListener;
		uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.EntryClicked));
		gameObject.name = entry;
		global::UnityEngine.Vector3 localPosition = gameObject.transform.localPosition;
		localPosition.y = this.lastHeight;
		gameObject.transform.localPosition = localPosition;
		this.lastHeight -= gameObject.GetComponentInChildren<global::UISlicedSprite>().transform.localScale.y;
	}

	// Token: 0x06002D7C RID: 11644 RVA: 0x000AD014 File Offset: 0x000AB214
	public virtual void SetItem(global::IInventoryItem item)
	{
		this.ClearChildren();
		this._observedItem = item;
		int num = item.datablock.RetreiveMenuOptions(item, global::RPOSItemRightClickMenu.menuItemBuffer, 0);
		for (int i = 0; i < num; i++)
		{
			this.AddRightClickEntry(global::RPOSItemRightClickMenu.menuItemBuffer[i].ToString());
		}
		global::UICamera.PopupPanel(base.GetComponent<global::UIPanel>());
	}

	// Token: 0x06002D7D RID: 11645 RVA: 0x000AD078 File Offset: 0x000AB278
	private void PopupStart()
	{
		this.RepositionAtCursor();
		base.GetComponent<global::UIPanel>().enabled = true;
	}

	// Token: 0x06002D7E RID: 11646 RVA: 0x000AD08C File Offset: 0x000AB28C
	private void PopupEnd()
	{
		base.GetComponent<global::UIPanel>().enabled = false;
	}

	// Token: 0x06002D7F RID: 11647 RVA: 0x000AD09C File Offset: 0x000AB29C
	public void ClearChildren()
	{
		global::UIButton[] componentsInChildren = base.GetComponentsInChildren<global::UIButton>();
		foreach (global::UIButton uibutton in componentsInChildren)
		{
			global::UnityEngine.Object.Destroy(uibutton.gameObject);
		}
		this.lastHeight = 0f;
	}

	// Token: 0x06002D80 RID: 11648 RVA: 0x000AD0E0 File Offset: 0x000AB2E0
	public void EntryClicked(global::UnityEngine.GameObject go)
	{
		try
		{
			if (this._observedItem != null)
			{
				global::InventoryItem.MenuItem? menuItem;
				try
				{
					menuItem = new global::InventoryItem.MenuItem?((global::InventoryItem.MenuItem)((byte)global::System.Enum.Parse(typeof(global::InventoryItem.MenuItem), go.name, true)));
				}
				catch (global::System.Exception ex)
				{
					menuItem = null;
					global::UnityEngine.Debug.LogException(ex);
				}
				if (menuItem != null)
				{
					this._observedItem.OnMenuOption(menuItem.Value);
				}
			}
		}
		catch (global::System.Exception ex2)
		{
			global::UnityEngine.Debug.LogException(ex2);
		}
		finally
		{
			global::UICamera.UnPopupPanel(base.GetComponent<global::UIPanel>());
		}
	}

	// Token: 0x06002D81 RID: 11649 RVA: 0x000AD1C0 File Offset: 0x000AB3C0
	public void RepositionAtCursor()
	{
		global::UnityEngine.Vector3 vector = global::UICamera.lastMousePosition;
		global::UnityEngine.Ray ray = this.uiCamera.ScreenPointToRay(vector);
		float num = 0f;
		if (this.planeTest.Raycast(ray, ref num))
		{
			base.transform.position = ray.GetPoint(num);
			global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(base.transform);
			float num2 = base.transform.localPosition.x + aabbox.size.x - (float)global::UnityEngine.Screen.width;
			if (num2 > 0f)
			{
				base.transform.SetLocalPositionX(base.transform.localPosition.x - num2);
			}
			float num3 = base.transform.localPosition.y + aabbox.size.y - (float)global::UnityEngine.Screen.height;
			if (num3 > 0f)
			{
				base.transform.SetLocalPositionY(base.transform.localPosition.y - num3);
			}
			base.transform.localPosition = new global::UnityEngine.Vector3(base.transform.localPosition.x, base.transform.localPosition.y, -180f);
		}
	}

	// Token: 0x04001776 RID: 6006
	private global::IInventoryItem _observedItem;

	// Token: 0x04001777 RID: 6007
	public global::UnityEngine.GameObject _buttonPrefab;

	// Token: 0x04001778 RID: 6008
	public global::UnityEngine.Camera uiCamera;

	// Token: 0x04001779 RID: 6009
	private global::UnityEngine.Plane planeTest;

	// Token: 0x0400177A RID: 6010
	public float lastHeight;

	// Token: 0x0400177B RID: 6011
	private static readonly global::InventoryItem.MenuItem[] menuItemBuffer = new global::InventoryItem.MenuItem[0x1E];
}
