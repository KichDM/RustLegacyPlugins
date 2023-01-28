using System;

// Token: 0x02000839 RID: 2105
public static class dfStringExtensions
{
	// Token: 0x06004841 RID: 18497 RVA: 0x0010CDDC File Offset: 0x0010AFDC
	public static string MakeRelativePath(this string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return string.Empty;
		}
		return path.Substring(path.IndexOf("Assets/", global::System.StringComparison.InvariantCultureIgnoreCase));
	}

	// Token: 0x06004842 RID: 18498 RVA: 0x0010CE04 File Offset: 0x0010B004
	public static bool Contains(this string value, string pattern, bool caseInsensitive)
	{
		if (caseInsensitive)
		{
			return value.IndexOf(pattern, global::System.StringComparison.InvariantCultureIgnoreCase) != -1;
		}
		return value.IndexOf(pattern) != -1;
	}
}
