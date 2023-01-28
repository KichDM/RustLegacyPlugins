using System;
using UnityEngine;

// Token: 0x020008AC RID: 2220
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Language Selection")]
[global::UnityEngine.RequireComponent(typeof(global::UIPopupList))]
public class LanguageSelection : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CBF RID: 19647 RVA: 0x00123428 File Offset: 0x00121628
	public LanguageSelection()
	{
	}

	// Token: 0x06004CC0 RID: 19648 RVA: 0x00123430 File Offset: 0x00121630
	private void Start()
	{
		this.mList = base.GetComponent<global::UIPopupList>();
		this.UpdateList();
		this.mList.eventReceiver = base.gameObject;
		this.mList.functionName = "OnLanguageSelection";
	}

	// Token: 0x06004CC1 RID: 19649 RVA: 0x00123468 File Offset: 0x00121668
	private void UpdateList()
	{
		if (global::Localization.instance != null && global::Localization.instance.languages != null)
		{
			this.mList.items.Clear();
			int i = 0;
			int num = global::Localization.instance.languages.Length;
			while (i < num)
			{
				global::UnityEngine.TextAsset textAsset = global::Localization.instance.languages[i];
				if (textAsset != null)
				{
					this.mList.items.Add(textAsset.name);
				}
				i++;
			}
			this.mList.selection = global::Localization.instance.currentLanguage;
		}
	}

	// Token: 0x06004CC2 RID: 19650 RVA: 0x00123508 File Offset: 0x00121708
	private void OnLanguageSelection(string language)
	{
		if (global::Localization.instance != null)
		{
			global::Localization.instance.currentLanguage = language;
		}
	}

	// Token: 0x04002996 RID: 10646
	private global::UIPopupList mList;
}
