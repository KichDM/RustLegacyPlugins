using System;
using System.Reflection;

// Token: 0x020001B0 RID: 432
public class ConVar
{
	// Token: 0x06000CA2 RID: 3234 RVA: 0x00030340 File Offset: 0x0002E540
	public ConVar()
	{
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x00030348 File Offset: 0x0002E548
	public static string GetString(string strName, string strDefault)
	{
		global::ConsoleSystem.Arg arg = new global::ConsoleSystem.Arg(strName);
		if (arg.Invalid)
		{
			return strDefault;
		}
		global::System.Type[] array = global::ConsoleSystem.FindTypes(arg.Class);
		if (array.Length == 0)
		{
			return strDefault;
		}
		foreach (global::System.Type type in array)
		{
			global::System.Reflection.FieldInfo field = type.GetField(arg.Function);
			if (field != null && field.IsStatic)
			{
				return field.GetValue(null).ToString();
			}
			global::System.Reflection.PropertyInfo property = type.GetProperty(arg.Function);
			if (property != null && property.GetGetMethod().IsStatic)
			{
				return property.GetValue(null, null).ToString();
			}
		}
		return strDefault;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x00030404 File Offset: 0x0002E604
	public static float GetFloat(string strName, float strDefault)
	{
		string @string = global::ConVar.GetString(strName, string.Empty);
		if (@string.Length == 0)
		{
			return strDefault;
		}
		float result = strDefault;
		if (float.TryParse(@string, out result))
		{
			return result;
		}
		return strDefault;
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x0003043C File Offset: 0x0002E63C
	public static int GetInt(string strName, float strDefault)
	{
		return (int)global::ConVar.GetFloat(strName, strDefault);
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x00030448 File Offset: 0x0002E648
	public static bool GetBool(string strName, bool strDefault)
	{
		string @string = global::ConVar.GetString(strName, (!strDefault) ? bool.FalseString : bool.TrueString);
		bool result;
		try
		{
			result = bool.Parse(@string);
		}
		catch
		{
			result = (global::ConVar.GetInt(strName, (float)((!strDefault) ? 0 : 1)) != 0);
		}
		return result;
	}
}
