using System;
using UnityEngine;

// Token: 0x02000520 RID: 1312
public class ItemToolTip : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C80 RID: 11392 RVA: 0x000A8108 File Offset: 0x000A6308
	public ItemToolTip()
	{
	}

	// Token: 0x06002C81 RID: 11393 RVA: 0x000A8110 File Offset: 0x000A6310
	public static global::ItemToolTip Get()
	{
		return global::ItemToolTip._globalToolTip;
	}

	// Token: 0x06002C82 RID: 11394 RVA: 0x000A8118 File Offset: 0x000A6318
	private void Awake()
	{
		global::ItemToolTip._globalToolTip = this;
		if (this.uiCamera == null)
		{
			this.uiCamera = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.planeTest = new global::UnityEngine.Plane(this.uiCamera.transform.forward * 1f, new global::UnityEngine.Vector3(0f, 0f, 2f));
	}

	// Token: 0x06002C83 RID: 11395 RVA: 0x000A818C File Offset: 0x000A638C
	private void Update()
	{
	}

	// Token: 0x06002C84 RID: 11396 RVA: 0x000A8190 File Offset: 0x000A6390
	public void RepositionAtCursor()
	{
		global::UnityEngine.Vector3 vector = global::UICamera.lastMousePosition;
		global::UnityEngine.Ray ray = this.uiCamera.ScreenPointToRay(vector);
		float num = 0f;
		if (this.planeTest.Raycast(ray, ref num))
		{
			base.transform.position = ray.GetPoint(num);
			base.transform.localPosition = new global::UnityEngine.Vector3(base.transform.localPosition.x, base.transform.localPosition.y, -180f);
			global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(base.transform);
			float num2 = base.transform.localPosition.x + aabbox.size.x - (float)global::UnityEngine.Screen.width;
			if (num2 > 0f)
			{
				base.transform.SetLocalPositionX(base.transform.localPosition.x - num2);
			}
			float num3 = global::UnityEngine.Mathf.Abs(base.transform.localPosition.y - aabbox.size.y) - (float)global::UnityEngine.Screen.height;
			if (num3 > 0f)
			{
				base.transform.SetLocalPositionY(base.transform.localPosition.y + num3);
			}
		}
	}

	// Token: 0x06002C85 RID: 11397 RVA: 0x000A82E8 File Offset: 0x000A64E8
	public static void SetToolTip(global::ItemDataBlock itemdb, global::IInventoryItem item = null)
	{
		global::ItemToolTip.Get().Internal_SetToolTip(itemdb, item);
		global::ItemToolTip.Get().RepositionAtCursor();
	}

	// Token: 0x06002C86 RID: 11398 RVA: 0x000A8300 File Offset: 0x000A6500
	public void Internal_SetToolTip(global::ItemDataBlock itemdb, global::IInventoryItem item)
	{
		this.ClearContents();
		if (itemdb == null)
		{
			this.SetVisible(false);
			return;
		}
		this.RepositionAtCursor();
		itemdb.PopulateInfoWindow(this, item);
		this._background.transform.localScale = new global::UnityEngine.Vector3(250f, this.GetContentHeight() + global::UnityEngine.Mathf.Abs(this.addParent.transform.localPosition.y * 2f), 1f);
		this.SetVisible(true);
	}

	// Token: 0x06002C87 RID: 11399 RVA: 0x000A8388 File Offset: 0x000A6588
	public void ClearContents()
	{
		foreach (object obj in this.addParent.transform)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			global::UnityEngine.Object.Destroy(transform.gameObject);
		}
	}

	// Token: 0x06002C88 RID: 11400 RVA: 0x000A8400 File Offset: 0x000A6600
	public void SetVisible(bool vis)
	{
		base.GetComponent<global::UIPanel>().enabled = vis;
	}

	// Token: 0x06002C89 RID: 11401 RVA: 0x000A8410 File Offset: 0x000A6610
	public global::UnityEngine.GameObject AddItemTitle(global::ItemDataBlock itemdb, global::IInventoryItem itemInstance = null, float aboveSpace = 0f)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.itemTitlePrefab);
		gameObject.GetComponentInChildren<global::UILabel>().text = ((itemInstance == null) ? itemdb.name : itemInstance.toolTip);
		global::UITexture componentInChildren = gameObject.GetComponentInChildren<global::UITexture>();
		componentInChildren.material = componentInChildren.material.Clone();
		componentInChildren.material.Set("_MainTex", itemdb.GetIconTexture());
		componentInChildren.color = ((itemInstance == null || !itemInstance.IsBroken()) ? global::UnityEngine.Color.white : global::UnityEngine.Color.red);
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002C8A RID: 11402 RVA: 0x000A84BC File Offset: 0x000A66BC
	public global::UnityEngine.GameObject AddSectionTitle(string text, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.sectionTitlePrefab);
		gameObject.GetComponentInChildren<global::UILabel>().text = text;
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002C8B RID: 11403 RVA: 0x000A8500 File Offset: 0x000A6700
	public global::UnityEngine.GameObject AddItemDescription(global::ItemDataBlock item, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.itemDescriptionPrefab);
		gameObject.transform.FindChild("DescText").GetComponent<global::UILabel>().text = item.GetItemDescription();
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return null;
	}

	// Token: 0x06002C8C RID: 11404 RVA: 0x000A8558 File Offset: 0x000A6758
	public global::UnityEngine.GameObject AddBasicLabel(string text, float aboveSpace)
	{
		return this.AddBasicLabel(text, aboveSpace, global::UnityEngine.Color.white);
	}

	// Token: 0x06002C8D RID: 11405 RVA: 0x000A8568 File Offset: 0x000A6768
	public global::UnityEngine.GameObject AddBasicLabel(string text, float aboveSpace, global::UnityEngine.Color col)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.basicLabelPrefab);
		global::UILabel componentInChildren = gameObject.GetComponentInChildren<global::UILabel>();
		componentInChildren.text = text;
		componentInChildren.color = col;
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002C8E RID: 11406 RVA: 0x000A85B4 File Offset: 0x000A67B4
	public global::UnityEngine.GameObject AddConditionInfo(global::IInventoryItem item)
	{
		if (item != null && item.datablock.DoesLoseCondition())
		{
			global::UnityEngine.Color col = global::UnityEngine.Color.green;
			if (item.condition <= 0.6f)
			{
				col = global::UnityEngine.Color.yellow;
			}
			else if (item.IsBroken())
			{
				col = global::UnityEngine.Color.red;
			}
			float num = 100f * item.condition;
			float num2 = 100f * item.maxcondition;
			return this.AddBasicLabel("Condition : " + num.ToString("0") + "/" + num2.ToString("0"), 15f, col);
		}
		return null;
	}

	// Token: 0x06002C8F RID: 11407 RVA: 0x000A865C File Offset: 0x000A685C
	public global::UnityEngine.GameObject AddProgressStat(string text, float currentAmount, float maxAmount, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.progressStatPrefab);
		global::UISlider componentInChildren = gameObject.GetComponentInChildren<global::UISlider>();
		global::UILabel component = global::FindChildHelper.FindChildByName("ProgressStatTitle", gameObject.gameObject).GetComponent<global::UILabel>();
		global::UILabel component2 = global::FindChildHelper.FindChildByName("ProgressAmountLabel", gameObject.gameObject).GetComponent<global::UILabel>();
		component.text = text;
		component2.text = ((currentAmount >= 1f) ? currentAmount.ToString("N0") : currentAmount.ToString("N2"));
		componentInChildren.sliderValue = currentAmount / maxAmount;
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002C90 RID: 11408 RVA: 0x000A8708 File Offset: 0x000A6908
	public float GetContentHeight()
	{
		return global::NGUIMath.CalculateRelativeWidgetBounds(this.addParent.transform, this.addParent.transform).size.y;
	}

	// Token: 0x06002C91 RID: 11409 RVA: 0x000A8740 File Offset: 0x000A6940
	public void FinishPopulating()
	{
	}

	// Token: 0x040016BA RID: 5818
	public global::UISlicedSprite _background;

	// Token: 0x040016BB RID: 5819
	public static global::ItemToolTip _globalToolTip;

	// Token: 0x040016BC RID: 5820
	public global::UnityEngine.GameObject addParent;

	// Token: 0x040016BD RID: 5821
	public global::UnityEngine.GameObject itemTitlePrefab;

	// Token: 0x040016BE RID: 5822
	public global::UnityEngine.GameObject sectionTitlePrefab;

	// Token: 0x040016BF RID: 5823
	public global::UnityEngine.GameObject itemDescriptionPrefab;

	// Token: 0x040016C0 RID: 5824
	public global::UnityEngine.GameObject basicLabelPrefab;

	// Token: 0x040016C1 RID: 5825
	public global::UnityEngine.GameObject progressStatPrefab;

	// Token: 0x040016C2 RID: 5826
	public global::UnityEngine.Camera uiCamera;

	// Token: 0x040016C3 RID: 5827
	private global::UnityEngine.Plane planeTest;
}
