using System;
using UnityEngine;

// Token: 0x020008CD RID: 2253
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Saved Option")]
public class UISavedOption : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D82 RID: 19842 RVA: 0x00128580 File Offset: 0x00126780
	public UISavedOption()
	{
	}

	// Token: 0x17000E63 RID: 3683
	// (get) Token: 0x06004D83 RID: 19843 RVA: 0x00128588 File Offset: 0x00126788
	private string key
	{
		get
		{
			return (!string.IsNullOrEmpty(this.keyName)) ? this.keyName : ("NGUI State: " + base.name);
		}
	}

	// Token: 0x06004D84 RID: 19844 RVA: 0x001285B8 File Offset: 0x001267B8
	private void OnEnable()
	{
		string @string = global::UnityEngine.PlayerPrefs.GetString(this.key);
		if (!string.IsNullOrEmpty(@string))
		{
			global::UICheckbox component = base.GetComponent<global::UICheckbox>();
			if (component != null)
			{
				component.isChecked = (@string == "true");
			}
			else
			{
				global::UICheckbox[] componentsInChildren = base.GetComponentsInChildren<global::UICheckbox>();
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					global::UICheckbox uicheckbox = componentsInChildren[i];
					global::UIEventListener uieventListener = global::UIEventListener.Get(uicheckbox.gameObject);
					uieventListener.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Remove(uieventListener.onClick, new global::UIEventListener.VoidDelegate(this.Save));
					uicheckbox.isChecked = (uicheckbox.name == @string);
					global::UnityEngine.Debug.Log(@string);
					global::UIEventListener uieventListener2 = global::UIEventListener.Get(uicheckbox.gameObject);
					uieventListener2.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener2.onClick, new global::UIEventListener.VoidDelegate(this.Save));
					i++;
				}
			}
		}
	}

	// Token: 0x06004D85 RID: 19845 RVA: 0x001286A0 File Offset: 0x001268A0
	private void OnDisable()
	{
		this.Save(null);
	}

	// Token: 0x06004D86 RID: 19846 RVA: 0x001286AC File Offset: 0x001268AC
	private void Save(global::UnityEngine.GameObject go)
	{
		global::UICheckbox component = base.GetComponent<global::UICheckbox>();
		if (component != null)
		{
			global::UnityEngine.PlayerPrefs.SetString(this.key, (!component.isChecked) ? "false" : "true");
		}
		else
		{
			global::UICheckbox[] componentsInChildren = base.GetComponentsInChildren<global::UICheckbox>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				global::UICheckbox uicheckbox = componentsInChildren[i];
				if (uicheckbox.isChecked)
				{
					global::UnityEngine.PlayerPrefs.SetString(this.key, uicheckbox.name);
					break;
				}
				i++;
			}
		}
	}

	// Token: 0x04002A87 RID: 10887
	public string keyName;
}
