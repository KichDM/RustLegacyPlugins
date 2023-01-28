using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Facepunch.Utility;
using RustPP;

namespace Magma
{
	// Token: 0x0200002D RID: 45
	public class Data
	{
		// Token: 0x060001DB RID: 475 RVA: 0x000071F0 File Offset: 0x000053F0
		public static global::Magma.Data GetData()
		{
			if (global::Magma.Data.data == null)
			{
				global::Magma.Data.data = new global::Magma.Data();
			}
			return global::Magma.Data.data;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00007208 File Offset: 0x00005408
		public void Init()
		{
			this.Load();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00007210 File Offset: 0x00005410
		public void Load()
		{
			global::Magma.Data.inifiles.Clear();
			foreach (string path in global::System.IO.Directory.GetDirectories(global::Magma.Data.PATH))
			{
				string text = "";
				foreach (string text2 in global::System.IO.Directory.GetFiles(path))
				{
					if (global::System.IO.Path.GetFileName(text2).Contains(".cfg") && global::System.IO.Path.GetFileName(text2).Contains(global::System.IO.Path.GetFileName(path)))
					{
						text = text2;
					}
				}
				if (!(text == ""))
				{
					string text3 = global::System.IO.Path.GetFileName(text).Replace(".cfg", "").ToLower();
					global::Magma.Data.inifiles.Add(text3, new global::IniParser(text));
					if (text3 == "rust++")
					{
						global::RustPP.Core.config = (global::IniParser)global::Magma.Data.inifiles["rust++"];
					}
					global::System.Console.WriteLine("Loaded Config: " + text3);
				}
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000730F File Offset: 0x0000550F
		public global::IniParser GetRPPConfig()
		{
			if (global::Magma.Data.inifiles.ContainsKey("rust++"))
			{
				return (global::IniParser)global::Magma.Data.inifiles["rust++"];
			}
			return null;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00007338 File Offset: 0x00005538
		public string GetConfigValue(string config, string section, string key)
		{
			global::IniParser iniParser = (global::IniParser)global::Magma.Data.inifiles[config.ToLower()];
			if (iniParser == null)
			{
				return "Config does not exist";
			}
			return iniParser.GetSetting(section, key);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000736C File Offset: 0x0000556C
		public void OverrideConfig(string config, string section, string key, string value)
		{
			global::IniParser iniParser = (global::IniParser)global::Magma.Data.inifiles[config.ToLower()];
			if (iniParser != null)
			{
				iniParser.SetSetting(section, key, value);
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000739C File Offset: 0x0000559C
		[global::System.Obsolete("Replaced with DataStore.Add", false)]
		public void AddTableValue(string tablename, object key, object val)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)global::Magma.DataStore.GetInstance().datastore[tablename];
			if (hashtable == null)
			{
				hashtable = new global::System.Collections.Hashtable();
				global::Magma.DataStore.GetInstance().datastore.Add(tablename, hashtable);
			}
			if (hashtable.ContainsKey(key))
			{
				hashtable[key] = val;
				return;
			}
			hashtable.Add(key, val);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000073F4 File Offset: 0x000055F4
		[global::System.Obsolete("Replaced with DataStore.Get", false)]
		public object GetTableValue(string tablename, object key)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)global::Magma.DataStore.GetInstance().datastore[tablename];
			if (hashtable == null)
			{
				return null;
			}
			return hashtable[key];
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00007423 File Offset: 0x00005623
		public int ToInt(string num)
		{
			return int.Parse(num);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000742B File Offset: 0x0000562B
		public string Substring(string str, int from, int to)
		{
			return str.Substring(from, to);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00007435 File Offset: 0x00005635
		public int StrLen(string str)
		{
			return str.Length;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000743D File Offset: 0x0000563D
		public string ToLower(string str)
		{
			return str.ToLower();
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00007445 File Offset: 0x00005645
		public string ToUpper(string str)
		{
			return str.ToUpper();
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000744D File Offset: 0x0000564D
		public string[] SplitQuoteStrings(string str)
		{
			return global::Facepunch.Utility.String.SplitQuotesStrings(str);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00007461 File Offset: 0x00005661
		public Data()
		{
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00007455 File Offset: 0x00005655
		// Note: this type is marked as 'beforefieldinit'.
		static Data()
		{
		}

		// Token: 0x0400006C RID: 108
		public static string PATH;

		// Token: 0x0400006D RID: 109
		public static global::System.Collections.Hashtable inifiles = new global::System.Collections.Hashtable();

		// Token: 0x0400006E RID: 110
		private static global::Magma.Data data;

		// Token: 0x0400006F RID: 111
		public global::System.Collections.Generic.List<string> chat_history = new global::System.Collections.Generic.List<string>();

		// Token: 0x04000070 RID: 112
		public global::System.Collections.Generic.List<string> chat_history_username = new global::System.Collections.Generic.List<string>();

		// Token: 0x04000071 RID: 113
		public global::System.Collections.Hashtable magma_shared_data = new global::System.Collections.Hashtable();
	}
}
