using System;
using UnityEngine;

// Token: 0x02000549 RID: 1353
public class RPOS_Craft_IngredientPlaque : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002E2A RID: 11818 RVA: 0x000AF98C File Offset: 0x000ADB8C
	public RPOS_Craft_IngredientPlaque()
	{
	}

	// Token: 0x06002E2B RID: 11819 RVA: 0x000AF994 File Offset: 0x000ADB94
	public void Bind(global::BlueprintDataBlock.IngredientEntry ingredient, int needAmount, int haveAmount)
	{
		global::ItemDataBlock ingredient2 = ingredient.Ingredient;
		global::UnityEngine.Color color;
		if (needAmount <= haveAmount)
		{
			this.checkIcon.enabled = true;
			this.xIcon.enabled = false;
			color = global::UnityEngine.Color.green;
		}
		else
		{
			this.checkIcon.enabled = false;
			this.xIcon.enabled = true;
			color = global::UnityEngine.Color.red;
		}
		global::UIWidget uiwidget = this.need;
		global::UnityEngine.Color color2 = color;
		this.have.color = color2;
		uiwidget.color = color2;
		this.itemName.text = ingredient2.name;
		this.need.text = needAmount.ToString("N0");
		this.have.text = haveAmount.ToString("N0");
	}

	// Token: 0x040017DB RID: 6107
	[global::PrefetchChildComponent(NameMask = "ItemName")]
	public global::UILabel itemName;

	// Token: 0x040017DC RID: 6108
	[global::PrefetchChildComponent(NameMask = "NeedLabel")]
	public global::UILabel need;

	// Token: 0x040017DD RID: 6109
	[global::PrefetchChildComponent(NameMask = "HaveLabel")]
	public global::UILabel have;

	// Token: 0x040017DE RID: 6110
	[global::PrefetchChildComponent(NameMask = "checkmark")]
	public global::UISprite checkIcon;

	// Token: 0x040017DF RID: 6111
	[global::PrefetchChildComponent(NameMask = "xmark")]
	public global::UISprite xIcon;
}
