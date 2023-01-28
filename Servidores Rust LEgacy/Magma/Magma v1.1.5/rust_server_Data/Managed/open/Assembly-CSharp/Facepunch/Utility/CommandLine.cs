using System;
using System.Collections.Generic;

namespace Facepunch.Utility
{
	// Token: 0x020001CA RID: 458
	public static class CommandLine
	{
		// Token: 0x06000D44 RID: 3396 RVA: 0x00034194 File Offset: 0x00032394
		// Note: this type is marked as 'beforefieldinit'.
		static CommandLine()
		{
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x000341B0 File Offset: 0x000323B0
		public static void Force(string val)
		{
			global::Facepunch.Utility.CommandLine.commandline = val;
			global::Facepunch.Utility.CommandLine.initialized = false;
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x000341C0 File Offset: 0x000323C0
		private static void Initalize()
		{
			if (global::Facepunch.Utility.CommandLine.initialized)
			{
				return;
			}
			global::Facepunch.Utility.CommandLine.initialized = true;
			if (global::Facepunch.Utility.CommandLine.commandline == string.Empty)
			{
				string[] commandLineArgs = global::System.Environment.GetCommandLineArgs();
				foreach (string str in commandLineArgs)
				{
					global::Facepunch.Utility.CommandLine.commandline = global::Facepunch.Utility.CommandLine.commandline + "\"" + str + "\" ";
				}
			}
			if (global::Facepunch.Utility.CommandLine.commandline == string.Empty)
			{
				return;
			}
			string text = string.Empty;
			string[] array2 = global::Facepunch.Utility.String.SplitQuotesStrings(global::Facepunch.Utility.CommandLine.commandline);
			foreach (string text2 in array2)
			{
				if (text2.Length != 0)
				{
					if (text2[0] == '-' || text2[0] == '+')
					{
						if (text != string.Empty && !global::Facepunch.Utility.CommandLine.switches.ContainsKey(text))
						{
							global::Facepunch.Utility.CommandLine.switches.Add(text, string.Empty);
						}
						text = text2;
					}
					else if (text != string.Empty)
					{
						if (!global::Facepunch.Utility.CommandLine.switches.ContainsKey(text))
						{
							global::Facepunch.Utility.CommandLine.switches.Add(text, text2);
						}
						text = string.Empty;
					}
				}
			}
			if (text != string.Empty && !global::Facepunch.Utility.CommandLine.switches.ContainsKey(text))
			{
				global::Facepunch.Utility.CommandLine.switches.Add(text, string.Empty);
			}
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x00034350 File Offset: 0x00032550
		public static bool HasSwitch(string strName)
		{
			return global::Facepunch.Utility.CommandLine.switches.ContainsKey(strName);
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x00034360 File Offset: 0x00032560
		public static string GetSwitch(string strName, string strDefault)
		{
			global::Facepunch.Utility.CommandLine.Initalize();
			string empty = string.Empty;
			if (!global::Facepunch.Utility.CommandLine.switches.TryGetValue(strName, out empty))
			{
				return strDefault;
			}
			return empty;
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x00034390 File Offset: 0x00032590
		public static int GetSwitchInt(string strName, int iDefault)
		{
			global::Facepunch.Utility.CommandLine.Initalize();
			string empty = string.Empty;
			if (!global::Facepunch.Utility.CommandLine.switches.TryGetValue(strName, out empty))
			{
				return iDefault;
			}
			int result = iDefault;
			if (!int.TryParse(empty, out result))
			{
				return iDefault;
			}
			return result;
		}

		// Token: 0x04000888 RID: 2184
		private static bool initialized = false;

		// Token: 0x04000889 RID: 2185
		private static string commandline = string.Empty;

		// Token: 0x0400088A RID: 2186
		private static global::System.Collections.Generic.Dictionary<string, string> switches = new global::System.Collections.Generic.Dictionary<string, string>();
	}
}
