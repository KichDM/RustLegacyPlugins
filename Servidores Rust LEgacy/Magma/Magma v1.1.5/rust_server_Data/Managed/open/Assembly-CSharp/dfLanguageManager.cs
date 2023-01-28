using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200081D RID: 2077
public class dfLanguageManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600460A RID: 17930 RVA: 0x0010125C File Offset: 0x000FF45C
	public dfLanguageManager()
	{
	}

	// Token: 0x17000D0E RID: 3342
	// (get) Token: 0x0600460B RID: 17931 RVA: 0x00101270 File Offset: 0x000FF470
	public global::dfLanguageCode CurrentLanguage
	{
		get
		{
			return this.currentLanguage;
		}
	}

	// Token: 0x17000D0F RID: 3343
	// (get) Token: 0x0600460C RID: 17932 RVA: 0x00101278 File Offset: 0x000FF478
	// (set) Token: 0x0600460D RID: 17933 RVA: 0x00101280 File Offset: 0x000FF480
	public global::UnityEngine.TextAsset DataFile
	{
		get
		{
			return this.dataFile;
		}
		set
		{
			if (value != this.dataFile)
			{
				this.dataFile = value;
				this.LoadLanguage(this.currentLanguage);
			}
		}
	}

	// Token: 0x0600460E RID: 17934 RVA: 0x001012B4 File Offset: 0x000FF4B4
	public void Start()
	{
		global::dfLanguageCode language = this.currentLanguage;
		if (this.currentLanguage == global::dfLanguageCode.None)
		{
			language = this.SystemLanguageToLanguageCode(global::UnityEngine.Application.systemLanguage);
		}
		this.LoadLanguage(language);
	}

	// Token: 0x0600460F RID: 17935 RVA: 0x001012E8 File Offset: 0x000FF4E8
	public void LoadLanguage(global::dfLanguageCode language)
	{
		this.currentLanguage = language;
		this.strings.Clear();
		if (this.dataFile != null)
		{
			this.parseDataFile();
		}
		global::dfControl[] componentsInChildren = base.GetComponentsInChildren<global::dfControl>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Localize();
		}
	}

	// Token: 0x06004610 RID: 17936 RVA: 0x00101344 File Offset: 0x000FF544
	public string GetValue(string key)
	{
		string empty = string.Empty;
		if (this.strings.TryGetValue(key, out empty))
		{
			return empty;
		}
		return key;
	}

	// Token: 0x06004611 RID: 17937 RVA: 0x00101370 File Offset: 0x000FF570
	private void parseDataFile()
	{
		string text = this.dataFile.text.Replace("\r\n", "\n").Trim();
		global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
		int i = this.parseLine(text, list, 0);
		int num = list.IndexOf(this.currentLanguage.ToString());
		if (num < 0)
		{
			return;
		}
		global::System.Collections.Generic.List<string> list2 = new global::System.Collections.Generic.List<string>();
		while (i < text.Length)
		{
			i = this.parseLine(text, list2, i);
			if (list2.Count != 0)
			{
				string key = list2[0];
				string value = (num >= list2.Count) ? string.Empty : list2[num];
				this.strings[key] = value;
			}
		}
	}

	// Token: 0x06004612 RID: 17938 RVA: 0x0010143C File Offset: 0x000FF63C
	private int parseLine(string data, global::System.Collections.Generic.List<string> values, int index)
	{
		values.Clear();
		bool flag = false;
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(0x100);
		while (index < data.Length)
		{
			char c = data[index];
			if (c == '"')
			{
				if (!flag)
				{
					flag = true;
				}
				else if (index + 1 < data.Length && data[index + 1] == c)
				{
					index++;
					stringBuilder.Append(c);
				}
				else
				{
					flag = false;
				}
			}
			else if (c == ',')
			{
				if (flag)
				{
					stringBuilder.Append(c);
				}
				else
				{
					values.Add(stringBuilder.ToString());
					stringBuilder.Length = 0;
				}
			}
			else if (c == '\n')
			{
				if (!flag)
				{
					index++;
					break;
				}
				stringBuilder.Append(c);
			}
			else
			{
				stringBuilder.Append(c);
			}
			index++;
		}
		if (stringBuilder.Length > 0)
		{
			values.Add(stringBuilder.ToString());
		}
		return index;
	}

	// Token: 0x06004613 RID: 17939 RVA: 0x00101544 File Offset: 0x000FF744
	private global::dfLanguageCode SystemLanguageToLanguageCode(global::UnityEngine.SystemLanguage language)
	{
		switch (language)
		{
		case 0:
			return global::dfLanguageCode.AF;
		case 1:
			return global::dfLanguageCode.AR;
		case 2:
			return global::dfLanguageCode.EU;
		case 3:
			return global::dfLanguageCode.BE;
		case 4:
			return global::dfLanguageCode.BG;
		case 5:
			return global::dfLanguageCode.CA;
		case 6:
			return global::dfLanguageCode.ZH;
		case 7:
			return global::dfLanguageCode.CS;
		case 8:
			return global::dfLanguageCode.DA;
		case 9:
			return global::dfLanguageCode.NL;
		case 0xA:
			return global::dfLanguageCode.EN;
		case 0xB:
			return global::dfLanguageCode.ES;
		case 0xC:
			return global::dfLanguageCode.FO;
		case 0xD:
			return global::dfLanguageCode.FI;
		case 0xE:
			return global::dfLanguageCode.FR;
		case 0xF:
			return global::dfLanguageCode.DE;
		case 0x10:
			return global::dfLanguageCode.EL;
		case 0x11:
			return global::dfLanguageCode.HE;
		case 0x12:
			return global::dfLanguageCode.HU;
		case 0x13:
			return global::dfLanguageCode.IS;
		case 0x14:
			return global::dfLanguageCode.ID;
		case 0x15:
			return global::dfLanguageCode.IT;
		case 0x16:
			return global::dfLanguageCode.JA;
		case 0x17:
			return global::dfLanguageCode.KO;
		case 0x18:
			return global::dfLanguageCode.LV;
		case 0x19:
			return global::dfLanguageCode.LT;
		case 0x1A:
			return global::dfLanguageCode.NO;
		case 0x1B:
			return global::dfLanguageCode.PL;
		case 0x1C:
			return global::dfLanguageCode.PT;
		case 0x1D:
			return global::dfLanguageCode.RO;
		case 0x1E:
			return global::dfLanguageCode.RU;
		case 0x1F:
			return global::dfLanguageCode.SH;
		case 0x20:
			return global::dfLanguageCode.SK;
		case 0x21:
			return global::dfLanguageCode.SL;
		case 0x22:
			return global::dfLanguageCode.ES;
		case 0x23:
			return global::dfLanguageCode.SV;
		case 0x24:
			return global::dfLanguageCode.TH;
		case 0x25:
			return global::dfLanguageCode.TR;
		case 0x26:
			return global::dfLanguageCode.UK;
		case 0x27:
			return global::dfLanguageCode.VI;
		case 0x28:
			return global::dfLanguageCode.EN;
		default:
			throw new global::System.ArgumentException("Unknown system language: " + language);
		}
	}

	// Token: 0x040025F3 RID: 9715
	[global::UnityEngine.SerializeField]
	private global::dfLanguageCode currentLanguage;

	// Token: 0x040025F4 RID: 9716
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.TextAsset dataFile;

	// Token: 0x040025F5 RID: 9717
	private global::System.Collections.Generic.Dictionary<string, string> strings = new global::System.Collections.Generic.Dictionary<string, string>();
}
