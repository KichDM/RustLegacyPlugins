using System;
using UnityEngine;

// Token: 0x02000537 RID: 1335
public class RPOSInfoWindow : global::RPOSWindowScrollable
{
	// Token: 0x06002D4F RID: 11599 RVA: 0x000AC094 File Offset: 0x000AA294
	public RPOSInfoWindow()
	{
		this.neverAutoShow = true;
	}

	// Token: 0x06002D50 RID: 11600 RVA: 0x000AC0A4 File Offset: 0x000AA2A4
	public global::UnityEngine.GameObject AddItemTitle(global::ItemDataBlock item)
	{
		return this.AddItemTitle(item, 0f);
	}

	// Token: 0x06002D51 RID: 11601 RVA: 0x000AC0B4 File Offset: 0x000AA2B4
	public global::UnityEngine.GameObject AddItemTitle(global::ItemDataBlock item, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.itemTitlePrefab);
		gameObject.GetComponentInChildren<global::UILabel>().text = item.name;
		global::UITexture componentInChildren = gameObject.GetComponentInChildren<global::UITexture>();
		componentInChildren.material = componentInChildren.material.Clone();
		componentInChildren.material.Set("_MainTex", item.GetIconTexture());
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002D52 RID: 11602 RVA: 0x000AC12C File Offset: 0x000AA32C
	public global::UnityEngine.GameObject AddSectionTitle(string text, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.sectionTitlePrefab);
		gameObject.GetComponentInChildren<global::UILabel>().text = text;
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002D53 RID: 11603 RVA: 0x000AC170 File Offset: 0x000AA370
	public global::UnityEngine.GameObject AddItemDescription(global::ItemDataBlock item, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.itemDescriptionPrefab);
		gameObject.transform.FindChild("DescText").GetComponent<global::UILabel>().text = item.GetItemDescription();
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return null;
	}

	// Token: 0x06002D54 RID: 11604 RVA: 0x000AC1C8 File Offset: 0x000AA3C8
	public global::UnityEngine.GameObject AddBasicLabel(string text, float aboveSpace)
	{
		float contentHeight = this.GetContentHeight();
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.addParent, this.basicLabelPrefab);
		gameObject.GetComponentInChildren<global::UILabel>().text = text;
		gameObject.transform.SetLocalPositionY(-(contentHeight + aboveSpace));
		return gameObject;
	}

	// Token: 0x06002D55 RID: 11605 RVA: 0x000AC20C File Offset: 0x000AA40C
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

	// Token: 0x06002D56 RID: 11606 RVA: 0x000AC2B8 File Offset: 0x000AA4B8
	public float GetContentHeight()
	{
		return global::NGUIMath.CalculateRelativeWidgetBounds(this.addParent.transform, this.addParent.transform).size.y;
	}

	// Token: 0x06002D57 RID: 11607 RVA: 0x000AC2F0 File Offset: 0x000AA4F0
	public void FinishPopulating()
	{
		base.ResetScrolling();
		base.showWithRPOS = this.autoShowWithRPOS;
		base.showWithoutRPOS = this.autoShowWithoutRPOS;
	}

	// Token: 0x06002D58 RID: 11608 RVA: 0x000AC310 File Offset: 0x000AA510
	private void SetVisible(bool enable)
	{
		global::UnityEngine.Debug.Log("Info RPOS opened");
		base.mainPanel.enabled = enable;
		global::UIPanel[] componentsInChildren = base.GetComponentsInChildren<global::UIPanel>();
		foreach (global::UIPanel uipanel in componentsInChildren)
		{
			uipanel.enabled = enable;
		}
	}

	// Token: 0x06002D59 RID: 11609 RVA: 0x000AC35C File Offset: 0x000AA55C
	protected override void OnWindowShow()
	{
		base.OnWindowShow();
		this.SetVisible(true);
	}

	// Token: 0x06002D5A RID: 11610 RVA: 0x000AC36C File Offset: 0x000AA56C
	protected override void OnWindowHide()
	{
		base.OnWindowHide();
		this.SetVisible(false);
	}

	// Token: 0x0400174F RID: 5967
	public global::UnityEngine.GameObject addParent;

	// Token: 0x04001750 RID: 5968
	public global::UnityEngine.GameObject itemTitlePrefab;

	// Token: 0x04001751 RID: 5969
	public global::UnityEngine.GameObject sectionTitlePrefab;

	// Token: 0x04001752 RID: 5970
	public global::UnityEngine.GameObject itemDescriptionPrefab;

	// Token: 0x04001753 RID: 5971
	public global::UnityEngine.GameObject basicLabelPrefab;

	// Token: 0x04001754 RID: 5972
	public global::UnityEngine.GameObject progressStatPrefab;
}
