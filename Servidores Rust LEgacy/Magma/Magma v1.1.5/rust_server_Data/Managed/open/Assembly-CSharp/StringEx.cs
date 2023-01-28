using System;
using System.Threading;

// Token: 0x02000614 RID: 1556
public static class StringEx
{
	// Token: 0x06003188 RID: 12680 RVA: 0x000BDF3C File Offset: 0x000BC13C
	// Note: this type is marked as 'beforefieldinit'.
	static StringEx()
	{
	}

	// Token: 0x06003189 RID: 12681 RVA: 0x000BDF58 File Offset: 0x000BC158
	private static global::StringEx.L S(string s, int l, out char[] buffer)
	{
		if (s == null || l <= 0)
		{
			buffer = null;
			return default(global::StringEx.L);
		}
		global::StringEx.L result = new global::StringEx.L(l <= 0x400);
		if (result.locked)
		{
			int sourceIndex = 0;
			char[] destination;
			buffer = (destination = global::StringEx.cb);
			s.CopyTo(sourceIndex, destination, 0, l);
		}
		else
		{
			buffer = s.ToCharArray();
		}
		return result;
	}

	// Token: 0x0600318A RID: 12682 RVA: 0x000BDFC0 File Offset: 0x000BC1C0
	private static global::StringEx.L S(string s, int l, int minSafeSize, out char[] buffer)
	{
		if (s == null || l <= 0)
		{
			buffer = null;
			return default(global::StringEx.L);
		}
		global::StringEx.L result = new global::StringEx.L(minSafeSize <= 0x400);
		if (result.locked)
		{
			int sourceIndex = 0;
			char[] destination;
			buffer = (destination = global::StringEx.cb);
			s.CopyTo(sourceIndex, destination, 0, l);
		}
		else
		{
			buffer = s.ToCharArray();
		}
		return result;
	}

	// Token: 0x0600318B RID: 12683 RVA: 0x000BE028 File Offset: 0x000BC228
	private static string c2s(char[] c, int l)
	{
		return (l != 0) ? new string(c, 0, l) : string.Empty;
	}

	// Token: 0x0600318C RID: 12684 RVA: 0x000BE044 File Offset: 0x000BC244
	private static string c2s(int l, char[] c)
	{
		return (l != 0) ? new string(c, 0, l) : string.Empty;
	}

	// Token: 0x0600318D RID: 12685 RVA: 0x000BE060 File Offset: 0x000BC260
	public static string RemoveWhiteSpaces(this string s)
	{
		int num = (s != null) ? s.Length : 0;
		for (int i = 0; i < num; i++)
		{
			if (char.IsWhiteSpace(s[i]))
			{
				if (i == num - 1)
				{
					return s.Remove(num - 1);
				}
				char[] array;
				using (global::StringEx.L l = global::StringEx.S(s, num, out array))
				{
					if (!l.V)
					{
						return s;
					}
					int l2 = i;
					while (++i < num)
					{
						if (!char.IsWhiteSpace(array[i]))
						{
							array[l2++] = array[i];
						}
					}
					return global::StringEx.c2s(array, l2);
				}
			}
		}
		return s;
	}

	// Token: 0x0600318E RID: 12686 RVA: 0x000BE140 File Offset: 0x000BC340
	public static string ToLowerEx(this string s)
	{
		int num = (s != null) ? s.Length : 0;
		for (int i = 0; i < num; i++)
		{
			if (char.IsUpper(s, i))
			{
				char[] array;
				using (global::StringEx.L l = global::StringEx.S(s, num, out array))
				{
					if (!l.V)
					{
						return s;
					}
					do
					{
						array[i] = char.ToLowerInvariant(array[i]);
					}
					while (++i < num);
					return global::StringEx.c2s(array, num);
				}
			}
		}
		return s;
	}

	// Token: 0x0600318F RID: 12687 RVA: 0x000BE1F4 File Offset: 0x000BC3F4
	public static string ToUpperEx(this string s)
	{
		int num = (s != null) ? s.Length : 0;
		for (int i = 0; i < num; i++)
		{
			if (char.IsLower(s, i))
			{
				char[] array;
				using (global::StringEx.L l = global::StringEx.S(s, num, out array))
				{
					if (!l.V)
					{
						return s;
					}
					do
					{
						array[i] = char.ToUpperInvariant(array[i]);
					}
					while (++i < num);
					return global::StringEx.c2s(array, num);
				}
			}
		}
		return s;
	}

	// Token: 0x06003190 RID: 12688 RVA: 0x000BE2A8 File Offset: 0x000BC4A8
	public static string MakeNice(this string s)
	{
		int length;
		if (s != null && (length = s.Length) > 1)
		{
			int num = -1;
			while (++num < length)
			{
				if (char.IsLetterOrDigit(s, num))
				{
					if (num == length - 1)
					{
						return s.Substring(length - 1, 1);
					}
					bool flag = char.IsDigit(s, num);
					bool flag2 = true;
					bool flag3 = true;
					int num2 = 0;
					char[] array;
					using (global::StringEx.L l = global::StringEx.S(s, length - num, (length - (num + 1)) * 2, out array))
					{
						if (!l.V)
						{
							return s;
						}
						if (!flag)
						{
							array[num2++] = char.ToUpper(s[num]);
						}
						else
						{
							array[num2++] = s[num];
						}
						while (++num < length)
						{
							if (flag != char.IsNumber(s, num))
							{
								flag = !flag;
								if (!flag3)
								{
									array[num2++] = ' ';
								}
								else
								{
									flag3 = false;
								}
								array[num2++] = ((!flag) ? char.ToUpperInvariant(s[num]) : s[num]);
								flag2 = true;
							}
							else if (flag)
							{
								array[num2++] = s[num];
							}
							else if (char.IsUpper(s, num))
							{
								if (!flag2)
								{
									if (!flag3)
									{
										array[num2++] = ' ';
									}
									else
									{
										flag3 = false;
									}
									flag2 = true;
								}
								array[num2++] = s[num];
							}
							else if (char.IsLower(s, num))
							{
								array[num2++] = s[num];
								flag2 = false;
							}
							else if (!flag3)
							{
								array[num2++] = ' ';
								flag3 = true;
							}
						}
						return global::StringEx.c2s(array, (!flag3) ? num2 : (num2 - 1));
					}
					continue;
				}
			}
			return string.Empty;
		}
		return s;
	}

	// Token: 0x06003191 RID: 12689 RVA: 0x000BE4C4 File Offset: 0x000BC6C4
	[global::System.Obsolete("You gotta specify at least one char", true)]
	public static string RemoveChars(this string s)
	{
		return s;
	}

	// Token: 0x06003192 RID: 12690 RVA: 0x000BE4C8 File Offset: 0x000BC6C8
	public static string RemoveChars(this string s, params char[] rem)
	{
		int num = rem.Length;
		if (num == 0)
		{
			return s;
		}
		int num2 = (s != null) ? s.Length : 0;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				if (s[i] == rem[j])
				{
					if (i == num2 - 1)
					{
						return s.Remove(num2 - 1);
					}
					char[] array;
					using (global::StringEx.L l = global::StringEx.S(s, num2, out array))
					{
						if (!l.V)
						{
							return s;
						}
						int l2 = i;
						while (++i < num2)
						{
							for (j = 0; j < num; j++)
							{
								if (rem[j] == array[i])
								{
								}
							}
							array[l2++] = array[i];
						}
						return global::StringEx.c2s(array, l2);
					}
				}
			}
		}
		return s;
	}

	// Token: 0x06003193 RID: 12691 RVA: 0x000BE5E0 File Offset: 0x000BC7E0
	public static string RemoveChars(this string s, char rem)
	{
		int num = (s != null) ? s.Length : 0;
		for (int i = 0; i < num; i++)
		{
			if (s[i] == rem)
			{
				if (i == num - 1)
				{
					return s.Remove(num - 1);
				}
				char[] array;
				using (global::StringEx.L l = global::StringEx.S(s, num, out array))
				{
					if (!l.V)
					{
						return s;
					}
					int l2 = i;
					while (++i < num)
					{
						if (array[i] != rem)
						{
							array[l2++] = array[i];
						}
					}
					return global::StringEx.c2s(array, l2);
				}
			}
		}
		return s;
	}

	// Token: 0x04001BBD RID: 7101
	private const int maxLockSize = 0x400;

	// Token: 0x04001BBE RID: 7102
	private static uint lockCount;

	// Token: 0x04001BBF RID: 7103
	private static readonly char[] cb = new char[0x400];

	// Token: 0x04001BC0 RID: 7104
	private static readonly object cbLock = new object();

	// Token: 0x02000615 RID: 1557
	private struct L : global::System.IDisposable
	{
		// Token: 0x06003194 RID: 12692 RVA: 0x000BE6C0 File Offset: 0x000BC8C0
		public L(bool locked)
		{
			this._locked = (locked && global::System.Threading.Monitor.TryEnter(global::StringEx.cbLock));
			this._valid = true;
		}

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06003195 RID: 12693 RVA: 0x000BE6F0 File Offset: 0x000BC8F0
		public bool locked
		{
			get
			{
				return this._locked;
			}
		}

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06003196 RID: 12694 RVA: 0x000BE6F8 File Offset: 0x000BC8F8
		public bool V
		{
			get
			{
				return this._valid;
			}
		}

		// Token: 0x06003197 RID: 12695 RVA: 0x000BE700 File Offset: 0x000BC900
		public void Dispose()
		{
			if (this._locked)
			{
				global::System.Threading.Monitor.Exit(global::StringEx.cbLock);
				this._locked = false;
			}
		}

		// Token: 0x04001BC1 RID: 7105
		private bool _locked;

		// Token: 0x04001BC2 RID: 7106
		private bool _valid;
	}
}
