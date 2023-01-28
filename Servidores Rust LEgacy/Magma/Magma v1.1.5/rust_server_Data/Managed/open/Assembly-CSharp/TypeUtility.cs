using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Token: 0x02000225 RID: 549
public static class TypeUtility
{
	// Token: 0x06000EDB RID: 3803 RVA: 0x00039374 File Offset: 0x00037574
	// Note: this type is marked as 'beforefieldinit'.
	static TypeUtility()
	{
	}

	// Token: 0x06000EDC RID: 3804 RVA: 0x0003939C File Offset: 0x0003759C
	private static bool ContainsAQN(string text)
	{
		int num = text.IndexOf(", ");
		if (num != -1)
		{
			for (int i = 0; i < global::TypeUtility.hintsAQN.Length; i++)
			{
				if (text.IndexOf(global::TypeUtility.hintsAQN[i], num) != -1)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x000393EC File Offset: 0x000375EC
	private static bool Parse(string text, bool ignoreCase, out global::System.Type type)
	{
		type = global::System.Type.GetType(text, false, ignoreCase);
		return !object.ReferenceEquals(type, null);
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x00039408 File Offset: 0x00037608
	private static bool Parse(string text, out global::System.Type type)
	{
		if (global::TypeUtility.Parse(text, false, out type))
		{
			return true;
		}
		if (global::TypeUtility.ContainsAQN(text))
		{
			string text2 = global::TypeUtility.g.StrippedName(text);
			return global::TypeUtility.Parse(text2, false, out type) || global::TypeUtility.Parse(text, true, out type) || global::TypeUtility.Parse(text2, true, out type);
		}
		return global::TypeUtility.Parse(text, true, out type);
	}

	// Token: 0x06000EDF RID: 3807 RVA: 0x00039464 File Offset: 0x00037664
	private static bool Parse(global::System.Type requiredBase, string text, bool ignoreCase, out global::System.Type type)
	{
		if (global::TypeUtility.Parse(text, ignoreCase, out type))
		{
			if (requiredBase.IsAssignableFrom(type))
			{
				return true;
			}
			type = null;
		}
		return false;
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x00039494 File Offset: 0x00037694
	private static bool Parse(global::System.Type requiredType, string text, out global::System.Type type)
	{
		if (global::TypeUtility.Parse(requiredType, text, false, out type))
		{
			return true;
		}
		if (global::TypeUtility.ContainsAQN(text))
		{
			string text2 = global::TypeUtility.g.StrippedName(text);
			return global::TypeUtility.Parse(requiredType, text2, false, out type) || global::TypeUtility.Parse(requiredType, text, true, out type) || global::TypeUtility.Parse(requiredType, text2, true, out type);
		}
		return global::TypeUtility.Parse(requiredType, text, true, out type);
	}

	// Token: 0x06000EE1 RID: 3809 RVA: 0x000394F8 File Offset: 0x000376F8
	public static global::System.Type Parse(string text)
	{
		if (object.ReferenceEquals(text, null))
		{
			throw new global::System.ArgumentNullException("text");
		}
		if (text.Length == 0)
		{
			throw new global::System.ArgumentException("text.Length==0", "text");
		}
		global::System.Type result;
		if (!global::TypeUtility.Parse(text, out result))
		{
			throw new global::System.ArgumentException("could not get type", text);
		}
		return result;
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x00039554 File Offset: 0x00037754
	public static global::System.Type Parse<TRequiredBaseClass>(string text) where TRequiredBaseClass : class
	{
		if (object.ReferenceEquals(text, null))
		{
			throw new global::System.ArgumentNullException("text");
		}
		if (text.Length == 0)
		{
			throw new global::System.ArgumentException("text.Length==0", "text");
		}
		global::System.Type result;
		if (!global::TypeUtility.Parse(typeof(TRequiredBaseClass), text, out result))
		{
			throw new global::System.ArgumentException("could not get type that would match base class " + typeof(TRequiredBaseClass), text);
		}
		return result;
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x000395C8 File Offset: 0x000377C8
	public static bool TryParse(string text, out global::System.Type type)
	{
		if (string.IsNullOrEmpty(text))
		{
			type = null;
			return false;
		}
		return global::TypeUtility.Parse(text, out type);
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x000395E4 File Offset: 0x000377E4
	public static bool TryParse<TRequiredBaseClass>(string text, out global::System.Type type) where TRequiredBaseClass : class
	{
		if (string.IsNullOrEmpty(text))
		{
			type = null;
			return false;
		}
		return global::TypeUtility.Parse(typeof(TRequiredBaseClass), text, out type);
	}

	// Token: 0x06000EE5 RID: 3813 RVA: 0x00039608 File Offset: 0x00037808
	public static string VersionlessName(this global::System.Type type)
	{
		if (object.ReferenceEquals(type, null))
		{
			return null;
		}
		return global::TypeUtility.g.StrippedName(type);
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x00039620 File Offset: 0x00037820
	public static string VersionlessName<T>()
	{
		return typeof(T).VersionlessName();
	}

	// Token: 0x04000966 RID: 2406
	private static bool ginit;

	// Token: 0x04000967 RID: 2407
	private static readonly string[] hintsAQN = new string[]
	{
		", Version=",
		", Culture=",
		", PublicKeyToken="
	};

	// Token: 0x02000226 RID: 550
	private static class g
	{
		// Token: 0x06000EE7 RID: 3815 RVA: 0x00039634 File Offset: 0x00037834
		static g()
		{
			global::TypeUtility.ginit = true;
			global::TypeUtility.g.strippedNames = new global::System.Collections.Generic.Dictionary<global::System.Type, string>();
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x00039648 File Offset: 0x00037848
		public static string StrippedName(global::System.Type type)
		{
			string result;
			if (!global::TypeUtility.g.strippedNames.TryGetValue(type, out result))
			{
				result = (global::TypeUtility.g.strippedNames[type] = global::TypeUtility.g.expression.replace(type.AssemblyQualifiedName));
			}
			return result;
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00039680 File Offset: 0x00037880
		public static string StrippedName(string assemblyQualifiedName)
		{
			return global::TypeUtility.g.expression.replace(assemblyQualifiedName);
		}

		// Token: 0x04000968 RID: 2408
		private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, string> strippedNames;

		// Token: 0x02000227 RID: 551
		private static class expression
		{
			// Token: 0x06000EEA RID: 3818 RVA: 0x00039688 File Offset: 0x00037888
			static expression()
			{
			}

			// Token: 0x06000EEB RID: 3819 RVA: 0x000396C8 File Offset: 0x000378C8
			public static string replace(string assemblyQualifiedName)
			{
				return global::TypeUtility.g.expression.version.Replace(assemblyQualifiedName, string.Empty);
			}

			// Token: 0x04000969 RID: 2409
			private const global::System.Text.RegularExpressions.RegexOptions kRegexOptions = global::System.Text.RegularExpressions.RegexOptions.Compiled;

			// Token: 0x0400096A RID: 2410
			public static readonly global::System.Text.RegularExpressions.Regex version = new global::System.Text.RegularExpressions.Regex(", Version=\\d+.\\d+.\\d+.\\d+", global::System.Text.RegularExpressions.RegexOptions.Compiled);

			// Token: 0x0400096B RID: 2411
			public static readonly global::System.Text.RegularExpressions.Regex culture = new global::System.Text.RegularExpressions.Regex(", Culture=\\w+", global::System.Text.RegularExpressions.RegexOptions.Compiled);

			// Token: 0x0400096C RID: 2412
			public static readonly global::System.Text.RegularExpressions.Regex publicKeyToken = new global::System.Text.RegularExpressions.Regex(", PublicKeyToken=\\w+", global::System.Text.RegularExpressions.RegexOptions.Compiled);
		}
	}
}
