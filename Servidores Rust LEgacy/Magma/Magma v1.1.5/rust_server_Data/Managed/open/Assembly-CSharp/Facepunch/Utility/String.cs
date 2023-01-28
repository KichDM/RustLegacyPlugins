using System;
using System.Text.RegularExpressions;

namespace Facepunch.Utility
{
	// Token: 0x020001CB RID: 459
	public static class String
	{
		// Token: 0x06000D4A RID: 3402 RVA: 0x000343D0 File Offset: 0x000325D0
		public static string[] SplitQuotesStrings(string input)
		{
			input = input.Replace("\\\"", "&qute;");
			global::System.Text.RegularExpressions.Regex regex = new global::System.Text.RegularExpressions.Regex("\"([^\"]+)\"|'([^']+)'|\\S+", global::System.Text.RegularExpressions.RegexOptions.Compiled);
			global::System.Text.RegularExpressions.MatchCollection matchCollection = regex.Matches(input);
			string[] array = new string[matchCollection.Count];
			for (int i = 0; i < matchCollection.Count; i++)
			{
				array[i] = matchCollection[i].Groups[0].Value.Trim(new char[]
				{
					' ',
					'"'
				});
				array[i] = array[i].Replace("&qute;", "\"");
			}
			return array;
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0003446C File Offset: 0x0003266C
		public static string QuoteSafe(string str)
		{
			str = str.Replace("\"", "\\\"");
			str = str.TrimEnd(new char[]
			{
				'\\'
			});
			return "\"" + str + "\"";
		}
	}
}
