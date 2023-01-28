using System;
using UnityEngine;

// Token: 0x02000958 RID: 2392
[global::UnityEngine.AddComponentMenu("NGUI/UI/Localize")]
[global::UnityEngine.RequireComponent(typeof(global::UIWidget))]
public class UILocalize : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600517B RID: 20859 RVA: 0x00142840 File Offset: 0x00140A40
	public UILocalize()
	{
	}

	// Token: 0x0600517C RID: 20860 RVA: 0x00142848 File Offset: 0x00140A48
	private void OnLocalize(global::Localization loc)
	{
		if (this.mLanguage != loc.currentLanguage)
		{
			global::UIWidget component = base.GetComponent<global::UIWidget>();
			global::UILabel uilabel = component as global::UILabel;
			global::UISprite uisprite = component as global::UISprite;
			if (string.IsNullOrEmpty(this.mLanguage) && string.IsNullOrEmpty(this.key) && uilabel != null)
			{
				this.key = uilabel.text;
			}
			string text = (!string.IsNullOrEmpty(this.key)) ? loc.Get(this.key) : loc.Get(component.name);
			if (uilabel != null)
			{
				uilabel.text = text;
			}
			else if (uisprite != null)
			{
				uisprite.spriteName = text;
				uisprite.MakePixelPerfect();
			}
			this.mLanguage = loc.currentLanguage;
		}
	}

	// Token: 0x0600517D RID: 20861 RVA: 0x00142924 File Offset: 0x00140B24
	private void OnEnable()
	{
		if (this.mStarted && global::Localization.instance != null)
		{
			this.OnLocalize(global::Localization.instance);
		}
	}

	// Token: 0x0600517E RID: 20862 RVA: 0x00142958 File Offset: 0x00140B58
	private void Start()
	{
		this.mStarted = true;
		if (global::Localization.instance != null)
		{
			this.OnLocalize(global::Localization.instance);
		}
	}

	// Token: 0x04002E12 RID: 11794
	public string key;

	// Token: 0x04002E13 RID: 11795
	private string mLanguage;

	// Token: 0x04002E14 RID: 11796
	private bool mStarted;
}
