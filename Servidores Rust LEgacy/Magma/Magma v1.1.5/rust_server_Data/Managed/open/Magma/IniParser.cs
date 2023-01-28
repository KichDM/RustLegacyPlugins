using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000061 RID: 97
public class IniParser
{
	// Token: 0x060002B8 RID: 696 RVA: 0x0000DD34 File Offset: 0x0000BF34
	public IniParser(string iniPath)
	{
		global::System.IO.TextReader textReader = null;
		string text = null;
		this.iniFilePath = iniPath;
		this.Name = global::System.IO.Path.GetFileNameWithoutExtension(iniPath);
		if (global::System.IO.File.Exists(iniPath))
		{
			try
			{
				try
				{
					textReader = new global::System.IO.StreamReader(iniPath);
					for (string text2 = textReader.ReadLine(); text2 != null; text2 = textReader.ReadLine())
					{
						text2 = text2.Trim();
						if (text2 != "")
						{
							if (text2.StartsWith("[") && text2.EndsWith("]"))
							{
								text = text2.Substring(1, text2.Length - 2);
							}
							else
							{
								string[] array = text2.Split(new char[]
								{
									'='
								}, 2);
								string value = null;
								if (text == null)
								{
									text = "ROOT";
								}
								global::IniParser.SectionPair sectionPair;
								sectionPair.Section = text;
								sectionPair.Key = array[0];
								if (array.Length > 1)
								{
									value = array[1];
								}
								this.keyPairs.Add(sectionPair, value);
								this.tmpList.Add(sectionPair);
							}
						}
					}
				}
				catch (global::System.Exception ex)
				{
					throw ex;
				}
				return;
			}
			finally
			{
				if (textReader != null)
				{
					textReader.Close();
				}
			}
		}
		throw new global::System.IO.FileNotFoundException("Unable to locate " + iniPath);
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x0000DE88 File Offset: 0x0000C088
	public bool isCommandOn(string cmdName)
	{
		string setting = this.GetSetting("Commands", cmdName);
		return setting == null || setting == "true";
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0000DEB4 File Offset: 0x0000C0B4
	public int Count()
	{
		global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
		foreach (global::IniParser.SectionPair sectionPair in this.tmpList)
		{
			if (!list.Contains(sectionPair.Section))
			{
				list.Add(sectionPair.Section);
			}
		}
		return list.Count;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0000DF28 File Offset: 0x0000C128
	public string GetSetting(string sectionName, string settingName)
	{
		global::IniParser.SectionPair sectionPair;
		sectionPair.Section = sectionName;
		sectionPair.Key = settingName;
		return (string)this.keyPairs[sectionPair];
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0000DF5C File Offset: 0x0000C15C
	public string[] EnumSection(string sectionName)
	{
		global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
		foreach (global::IniParser.SectionPair sectionPair in this.tmpList)
		{
			if (sectionPair.Section == sectionName)
			{
				list.Add(sectionPair.Key);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0000DFD0 File Offset: 0x0000C1D0
	public void AddSetting(string sectionName, string settingName, string settingValue)
	{
		global::IniParser.SectionPair sectionPair;
		sectionPair.Section = sectionName;
		sectionPair.Key = settingName;
		if (this.keyPairs.ContainsKey(sectionPair))
		{
			this.keyPairs.Remove(sectionPair);
		}
		if (this.tmpList.Contains(sectionPair))
		{
			this.tmpList.Remove(sectionPair);
		}
		this.keyPairs.Add(sectionPair, settingValue);
		this.tmpList.Add(sectionPair);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0000E04A File Offset: 0x0000C24A
	public void AddSetting(string sectionName, string settingName)
	{
		this.AddSetting(sectionName, settingName, null);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0000E058 File Offset: 0x0000C258
	public void DeleteSetting(string sectionName, string settingName)
	{
		global::IniParser.SectionPair sectionPair;
		sectionPair.Section = sectionName;
		sectionPair.Key = settingName;
		if (this.keyPairs.ContainsKey(sectionPair))
		{
			this.keyPairs.Remove(sectionPair);
			this.tmpList.Remove(sectionPair);
		}
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0000E0A8 File Offset: 0x0000C2A8
	public void SetSetting(string sectionName, string settingName, string value)
	{
		global::IniParser.SectionPair sectionPair;
		sectionPair.Section = sectionName;
		sectionPair.Key = settingName;
		if (this.keyPairs.ContainsKey(sectionPair))
		{
			this.keyPairs[sectionPair] = value;
		}
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x0000E0EC File Offset: 0x0000C2EC
	public void SaveSettings(string newFilePath)
	{
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		string text = "";
		foreach (global::IniParser.SectionPair sectionPair in this.tmpList)
		{
			if (!arrayList.Contains(sectionPair.Section))
			{
				arrayList.Add(sectionPair.Section);
			}
		}
		foreach (object obj in arrayList)
		{
			string text2 = (string)obj;
			text = text + "[" + text2 + "]\r\n";
			foreach (global::IniParser.SectionPair sectionPair2 in this.tmpList)
			{
				if (sectionPair2.Section == text2)
				{
					string text3 = (string)this.keyPairs[sectionPair2];
					if (text3 != null)
					{
						text3 = "=" + text3;
					}
					text = text + sectionPair2.Key + text3 + "\r\n";
				}
			}
			text += "\r\n";
		}
		try
		{
			global::System.IO.TextWriter textWriter = new global::System.IO.StreamWriter(newFilePath);
			textWriter.Write(text);
			textWriter.Close();
		}
		catch (global::System.Exception ex)
		{
			throw ex;
		}
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0000E284 File Offset: 0x0000C484
	public void Save()
	{
		this.SaveSettings(this.iniFilePath);
	}

	// Token: 0x04000099 RID: 153
	private global::System.Collections.Hashtable keyPairs = new global::System.Collections.Hashtable();

	// Token: 0x0400009A RID: 154
	private global::System.Collections.Generic.List<global::IniParser.SectionPair> tmpList = new global::System.Collections.Generic.List<global::IniParser.SectionPair>();

	// Token: 0x0400009B RID: 155
	private string iniFilePath;

	// Token: 0x0400009C RID: 156
	public string Name;

	// Token: 0x02000062 RID: 98
	private struct SectionPair
	{
		// Token: 0x0400009D RID: 157
		public string Section;

		// Token: 0x0400009E RID: 158
		public string Key;
	}
}
