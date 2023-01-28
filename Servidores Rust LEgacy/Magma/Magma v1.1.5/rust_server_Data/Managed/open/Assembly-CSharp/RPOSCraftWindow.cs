using System;
using UnityEngine;

// Token: 0x02000535 RID: 1333
public class RPOSCraftWindow : global::RPOSWindowScrollable
{
	// Token: 0x06002D38 RID: 11576 RVA: 0x000AB85C File Offset: 0x000A9A5C
	public RPOSCraftWindow()
	{
	}

	// Token: 0x06002D39 RID: 11577 RVA: 0x000AB878 File Offset: 0x000A9A78
	public new void Awake()
	{
		this.ShowCraftingOptions(false);
		global::UIEventListener uieventListener = global::UIEventListener.Get(this.craftButton.gameObject);
		global::UIEventListener uieventListener2 = uieventListener;
		uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.CraftButtonClicked));
		global::UIEventListener uieventListener3 = global::UIEventListener.Get(this.plusButton.gameObject);
		global::UIEventListener uieventListener4 = uieventListener3;
		uieventListener4.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener4.onClick, new global::UIEventListener.VoidDelegate(this.PlusButtonClicked));
		global::UIEventListener uieventListener5 = global::UIEventListener.Get(this.minusButton.gameObject);
		global::UIEventListener uieventListener6 = uieventListener5;
		uieventListener6.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener6.onClick, new global::UIEventListener.VoidDelegate(this.MinusButtonClicked));
		this.amountInput.text = "1";
	}

	// Token: 0x06002D3A RID: 11578 RVA: 0x000AB938 File Offset: 0x000A9B38
	public char ValidateAmountInput(string text, char ch)
	{
		global::UnityEngine.Debug.Log("validating input");
		if (text.Length == 0 && ch == '0')
		{
			return '\0';
		}
		if (ch >= '0' && ch <= '9')
		{
			return ch;
		}
		return '\0';
	}

	// Token: 0x06002D3B RID: 11579 RVA: 0x000AB978 File Offset: 0x000A9B78
	public void ItemHovered(global::UnityEngine.GameObject go, bool what)
	{
	}

	// Token: 0x170009BE RID: 2494
	// (get) Token: 0x06002D3C RID: 11580 RVA: 0x000AB97C File Offset: 0x000A9B7C
	private static int amountModifier
	{
		get
		{
			try
			{
				global::UnityEngine.Event current = global::UnityEngine.Event.current;
				if (current.control)
				{
					return 0x7FFF;
				}
				if (current.shift)
				{
					return 0xA;
				}
			}
			catch
			{
			}
			return 1;
		}
	}

	// Token: 0x06002D3D RID: 11581 RVA: 0x000AB9E4 File Offset: 0x000A9BE4
	public void MinusButtonClicked(global::UnityEngine.GameObject go)
	{
		this.PlusMinusClick(-global::RPOSCraftWindow.amountModifier);
	}

	// Token: 0x06002D3E RID: 11582 RVA: 0x000AB9F4 File Offset: 0x000A9BF4
	public void PlusButtonClicked(global::UnityEngine.GameObject go)
	{
		this.PlusMinusClick(global::RPOSCraftWindow.amountModifier);
	}

	// Token: 0x06002D3F RID: 11583 RVA: 0x000ABA04 File Offset: 0x000A9C04
	public void SetRequestedAmount(int amount)
	{
		if (!this.selectedItem)
		{
			this.desiredAmount = amount;
		}
		else
		{
			int num = this.selectedItem.MaxAmount(global::RPOS.ObservedPlayer.GetComponent<global::Inventory>());
			this.desiredAmount = global::UnityEngine.Mathf.Clamp(amount, 1, (num > 0) ? num : 1);
		}
		this.amountInput.text = this.desiredAmount.ToString();
	}

	// Token: 0x06002D40 RID: 11584 RVA: 0x000ABA74 File Offset: 0x000A9C74
	public void PlusMinusClick(int amount)
	{
		if (amount == 0)
		{
			return;
		}
		global::CraftingInventory component = global::RPOS.ObservedPlayer.GetComponent<global::CraftingInventory>();
		if (component == null)
		{
			return;
		}
		if (component.isCrafting)
		{
			return;
		}
		this.SetRequestedAmount(this.desiredAmount + amount);
		this.UpdateIngredients();
	}

	// Token: 0x06002D41 RID: 11585 RVA: 0x000ABAC0 File Offset: 0x000A9CC0
	public void ShowCraftingOptions(bool show)
	{
		this.plusButton.gameObject.SetActive(show);
		this.minusButton.gameObject.SetActive(show);
		this.amountInput.gameObject.SetActive(show);
		this.amountInputBackground.gameObject.SetActive(show);
		this.craftProgressBar.gameObject.SetActive(show);
		this.craftButton.gameObject.SetActive(show);
		this.requirementLabel.gameObject.SetActive(show);
	}

	// Token: 0x06002D42 RID: 11586 RVA: 0x000ABB44 File Offset: 0x000A9D44
	public void LocalInventoryModified()
	{
		this.bpLister.UpdateItems();
		this.UpdateIngredients();
	}

	// Token: 0x06002D43 RID: 11587 RVA: 0x000ABB58 File Offset: 0x000A9D58
	protected override void OnWindowShow()
	{
		this.bpLister.UpdateItems();
		this.SetRequestedAmount(1);
		base.OnWindowShow();
	}

	// Token: 0x06002D44 RID: 11588 RVA: 0x000ABB74 File Offset: 0x000A9D74
	protected override void OnWindowHide()
	{
		base.OnWindowHide();
	}

	// Token: 0x06002D45 RID: 11589 RVA: 0x000ABB7C File Offset: 0x000A9D7C
	public void Update()
	{
		if (global::RPOS.ObservedPlayer == null)
		{
			return;
		}
		global::CraftingInventory component = global::RPOS.ObservedPlayer.GetComponent<global::CraftingInventory>();
		if (component == null)
		{
			return;
		}
		bool isCrafting = component.isCrafting;
		if (isCrafting)
		{
			component.CraftThink();
		}
		if (!isCrafting && this.wasCrafting)
		{
			this.UpdateIngredients();
		}
		else if (!this.wasCrafting && isCrafting)
		{
			this.craftSound.Play();
		}
		if (this.craftButton.gameObject.activeSelf)
		{
			this.craftButton.GetComponentInChildren<global::UILabel>().text = ((!component.isCrafting) ? "Craft" : "Cancel");
		}
		if (this.craftProgressBar && this.craftProgressBar.gameObject && this.craftProgressBar.gameObject.activeSelf)
		{
			global::UISlider uislider = this.craftProgressBar;
			float? craftingCompletePercent = component.craftingCompletePercent;
			uislider.sliderValue = ((craftingCompletePercent == null) ? 0f : craftingCompletePercent.Value);
			float? craftingSecondsRemaining = component.craftingSecondsRemaining;
			float num = (craftingSecondsRemaining == null) ? 0f : craftingSecondsRemaining.Value;
			if (num != this._lastTimeStringValue)
			{
				this._lastTimeStringString = num.ToString("0.0");
				this._lastTimeStringValue = num;
			}
			this.progressLabel.text = this._lastTimeStringString;
			global::UnityEngine.Color color = global::UnityEngine.Color.white;
			float craftingSpeedPerSec = component.craftingSpeedPerSec;
			if (craftingSpeedPerSec > 1f)
			{
				color = global::UnityEngine.Color.green;
			}
			else if (craftingSpeedPerSec < 1f)
			{
				color = global::UnityEngine.Color.yellow;
			}
			else if (craftingSpeedPerSec < 0.5f)
			{
				color = global::UnityEngine.Color.red;
			}
			this.progressLabel.color = color;
		}
		if (this.selectedItem != null)
		{
			this.UpdateWorkbenchRequirements();
		}
		if (this.progressLabel)
		{
			this.progressLabel.enabled = isCrafting;
		}
		this.wasCrafting = component.isCrafting;
	}

	// Token: 0x06002D46 RID: 11590 RVA: 0x000ABD9C File Offset: 0x000A9F9C
	public void CraftButtonClicked(global::UnityEngine.GameObject go)
	{
		if (this.selectedItem == null)
		{
			return;
		}
		global::UnityEngine.Debug.Log("Crafting clicked");
		global::CraftingInventory component = global::RPOS.ObservedPlayer.GetComponent<global::CraftingInventory>();
		if (component == null)
		{
			global::UnityEngine.Debug.Log("No local player inventory.. weird");
			return;
		}
	}

	// Token: 0x06002D47 RID: 11591 RVA: 0x000ABDE8 File Offset: 0x000A9FE8
	public bool AtWorkbench()
	{
		global::CraftingInventory component = global::RPOS.ObservedPlayer.GetComponent<global::CraftingInventory>();
		return component.AtWorkBench();
	}

	// Token: 0x06002D48 RID: 11592 RVA: 0x000ABE08 File Offset: 0x000AA008
	public void UpdateWorkbenchRequirements()
	{
		if (this.selectedItem != null && this.selectedItem.RequireWorkbench)
		{
			this.requirementLabel.color = ((!this.AtWorkbench()) ? global::UnityEngine.Color.red : global::UnityEngine.Color.green);
			this.requirementLabel.text = "REQUIRES WORKBENCH";
		}
		else
		{
			this.requirementLabel.text = string.Empty;
		}
	}

	// Token: 0x06002D49 RID: 11593 RVA: 0x000ABE80 File Offset: 0x000AA080
	public void SetSelectedItem(global::BlueprintDataBlock newSel)
	{
		if (this.selectedItem)
		{
		}
		this.selectedItem = newSel;
		this.SetRequestedAmount(1);
		if (this.selectedItem)
		{
		}
		this.ShowCraftingOptions(this.selectedItem != null);
		this.UpdateWorkbenchRequirements();
	}

	// Token: 0x06002D4A RID: 11594 RVA: 0x000ABED4 File Offset: 0x000AA0D4
	public int RequestedAmount()
	{
		return this.desiredAmount;
	}

	// Token: 0x06002D4B RID: 11595 RVA: 0x000ABEDC File Offset: 0x000AA0DC
	public void UpdateIngredients()
	{
		if (this.selectedItem)
		{
			foreach (object obj in this.ingredientAnchor.transform)
			{
				global::UnityEngine.Object.Destroy((obj as global::UnityEngine.Transform).gameObject);
			}
			int num = this.RequestedAmount();
			int num2 = 0;
			foreach (global::BlueprintDataBlock.IngredientEntry ingredientEntry in this.selectedItem.ingredients)
			{
				int haveAmount = 0;
				global::PlayerClient.GetLocalPlayer().controllable.GetComponent<global::CraftingInventory>().FindItem(ingredientEntry.Ingredient, out haveAmount);
				int needAmount = ingredientEntry.amount * num;
				global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(this.ingredientAnchor, this.ingredientPlaquePrefab);
				gameObject.GetComponent<global::RPOS_Craft_IngredientPlaque>().Bind(ingredientEntry, needAmount, haveAmount);
				gameObject.transform.SetLocalPositionY((float)num2);
				num2 -= 0xC;
			}
		}
	}

	// Token: 0x06002D4C RID: 11596 RVA: 0x000AC004 File Offset: 0x000AA204
	public void ItemClicked(global::UnityEngine.GameObject go)
	{
		if (global::RPOS.ObservedPlayer.GetComponent<global::CraftingInventory>().isCrafting)
		{
			return;
		}
		global::RPOSCraftItemEntry component = go.GetComponent<global::RPOSCraftItemEntry>();
		if (component == null)
		{
			return;
		}
		global::BlueprintDataBlock blueprint = component.blueprint;
		if (!blueprint)
		{
			global::UnityEngine.Debug.Log("no bp by that name");
			return;
		}
		if (blueprint != this.selectedItem)
		{
			this.SetSelectedItem(component.blueprint);
			this.UpdateIngredients();
		}
	}

	// Token: 0x0400173D RID: 5949
	public global::UnityEngine.GameObject ingredientAnchor;

	// Token: 0x0400173E RID: 5950
	public global::UnityEngine.GameObject ingredientPlaquePrefab;

	// Token: 0x0400173F RID: 5951
	public global::BlueprintDataBlock selectedItem;

	// Token: 0x04001740 RID: 5952
	public global::UIButton craftButton;

	// Token: 0x04001741 RID: 5953
	public global::RPOS_Craft_BlueprintList bpLister;

	// Token: 0x04001742 RID: 5954
	public global::UISlider craftProgressBar;

	// Token: 0x04001743 RID: 5955
	public global::UILabel amountInput;

	// Token: 0x04001744 RID: 5956
	public global::UISprite amountInputBackground;

	// Token: 0x04001745 RID: 5957
	public global::UIButton plusButton;

	// Token: 0x04001746 RID: 5958
	public global::UIButton minusButton;

	// Token: 0x04001747 RID: 5959
	public global::UILabel progressLabel;

	// Token: 0x04001748 RID: 5960
	public global::UILabel requirementLabel;

	// Token: 0x04001749 RID: 5961
	public int desiredAmount = 1;

	// Token: 0x0400174A RID: 5962
	private bool wasCrafting;

	// Token: 0x0400174B RID: 5963
	public global::UnityEngine.AudioClip craftSound;

	// Token: 0x0400174C RID: 5964
	[global::System.NonSerialized]
	private float _lastTimeStringValue = float.PositiveInfinity;

	// Token: 0x0400174D RID: 5965
	[global::System.NonSerialized]
	private string _lastTimeStringString;
}
