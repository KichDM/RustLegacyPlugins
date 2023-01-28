using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008E3 RID: 2275
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Localization")]
public class Localization : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004DEF RID: 19951 RVA: 0x0012AE48 File Offset: 0x00129048
	public Localization()
	{
	}

	// Token: 0x17000E78 RID: 3704
	// (get) Token: 0x06004DF0 RID: 19952 RVA: 0x0012AE5C File Offset: 0x0012905C
	public static global::Localization instance
	{
		get
		{
			if (global::Localization.mInst == null)
			{
				global::Localization.mInst = (global::UnityEngine.Object.FindObjectOfType(typeof(global::Localization)) as global::Localization);
				if (global::Localization.mInst == null)
				{
					global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("_Localization");
					global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
					global::Localization.mInst = gameObject.AddComponent<global::Localization>();
				}
			}
			return global::Localization.mInst;
		}
	}

	// Token: 0x17000E79 RID: 3705
	// (get) Token: 0x06004DF1 RID: 19953 RVA: 0x0012AEC4 File Offset: 0x001290C4
	// (set) Token: 0x06004DF2 RID: 19954 RVA: 0x0012AF50 File Offset: 0x00129150
	public string currentLanguage
	{
		get
		{
			if (string.IsNullOrEmpty(this.mLanguage))
			{
				this.currentLanguage = global::UnityEngine.PlayerPrefs.GetString("Language");
				if (string.IsNullOrEmpty(this.mLanguage))
				{
					this.currentLanguage = this.startingLanguage;
					if (string.IsNullOrEmpty(this.mLanguage) && this.languages != null && this.languages.Length > 0)
					{
						this.currentLanguage = this.languages[0].name;
					}
				}
			}
			return this.mLanguage;
		}
		set
		{
			if (this.mLanguage != value)
			{
				this.startingLanguage = value;
				if (!string.IsNullOrEmpty(value))
				{
					if (this.languages != null)
					{
						int i = 0;
						int num = this.languages.Length;
						while (i < num)
						{
							global::UnityEngine.TextAsset textAsset = this.languages[i];
							if (textAsset != null && textAsset.name == value)
							{
								this.Load(textAsset);
								return;
							}
							i++;
						}
					}
					global::UnityEngine.TextAsset textAsset2 = global::UnityEngine.Resources.Load(value, typeof(global::UnityEngine.TextAsset)) as global::UnityEngine.TextAsset;
					if (textAsset2 != null)
					{
						this.Load(textAsset2);
						return;
					}
				}
				this.mDictionary.Clear();
				global::UnityEngine.PlayerPrefs.DeleteKey("Language");
			}
		}
	}

	// Token: 0x06004DF3 RID: 19955 RVA: 0x0012B014 File Offset: 0x00129214
	private void Awake()
	{
		if (global::Localization.mInst == null)
		{
			global::Localization.mInst = this;
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06004DF4 RID: 19956 RVA: 0x0012B048 File Offset: 0x00129248
	private void Start()
	{
		if (!string.IsNullOrEmpty(this.startingLanguage))
		{
			this.currentLanguage = this.startingLanguage;
		}
	}

	// Token: 0x06004DF5 RID: 19957 RVA: 0x0012B068 File Offset: 0x00129268
	private void OnEnable()
	{
		if (global::Localization.mInst == null)
		{
			global::Localization.mInst = this;
		}
	}

	// Token: 0x06004DF6 RID: 19958 RVA: 0x0012B080 File Offset: 0x00129280
	private void OnDestroy()
	{
		if (global::Localization.mInst == this)
		{
			global::Localization.mInst = null;
		}
	}

	// Token: 0x06004DF7 RID: 19959 RVA: 0x0012B098 File Offset: 0x00129298
	private void Load(global::UnityEngine.TextAsset asset)
	{
		this.mLanguage = asset.name;
		global::UnityEngine.PlayerPrefs.SetString("Language", this.mLanguage);
		global::ByteReader byteReader = new global::ByteReader(asset);
		this.mDictionary = byteReader.ReadDictionary();
		global::UIRoot.Broadcast("OnLocalize", this);
	}

	// Token: 0x06004DF8 RID: 19960 RVA: 0x0012B0E0 File Offset: 0x001292E0
	public string Get(string key)
	{
		string text;
		return (!this.mDictionary.TryGetValue(key, out text)) ? key : text;
	}

	// Token: 0x04002B00 RID: 11008
	private static global::Localization mInst;

	// Token: 0x04002B01 RID: 11009
	public string startingLanguage;

	// Token: 0x04002B02 RID: 11010
	public global::UnityEngine.TextAsset[] languages;

	// Token: 0x04002B03 RID: 11011
	private global::System.Collections.Generic.Dictionary<string, string> mDictionary = new global::System.Collections.Generic.Dictionary<string, string>();

	// Token: 0x04002B04 RID: 11012
	private string mLanguage;
}
