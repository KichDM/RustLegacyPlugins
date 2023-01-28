using System;
using UnityEngine;

// Token: 0x02000955 RID: 2389
[global::UnityEngine.AddComponentMenu("NGUI/UI/Input (Saved)")]
public class UIInputSaved : global::UIInput
{
	// Token: 0x06005133 RID: 20787 RVA: 0x00140FB8 File Offset: 0x0013F1B8
	public UIInputSaved()
	{
	}

	// Token: 0x06005134 RID: 20788 RVA: 0x00140FC0 File Offset: 0x0013F1C0
	private void Start()
	{
		base.Init();
		if (!string.IsNullOrEmpty(this.playerPrefsField) && global::UnityEngine.PlayerPrefs.HasKey(this.playerPrefsField))
		{
			base.text = global::UnityEngine.PlayerPrefs.GetString(this.playerPrefsField);
		}
	}

	// Token: 0x06005135 RID: 20789 RVA: 0x00140FFC File Offset: 0x0013F1FC
	private void OnApplicationQuit()
	{
		if (!string.IsNullOrEmpty(this.playerPrefsField))
		{
			global::UnityEngine.PlayerPrefs.SetString(this.playerPrefsField, base.text);
		}
	}

	// Token: 0x04002DEA RID: 11754
	public string playerPrefsField;
}
