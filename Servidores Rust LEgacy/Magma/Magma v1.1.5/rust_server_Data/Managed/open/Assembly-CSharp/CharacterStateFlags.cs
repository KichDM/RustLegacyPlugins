using System;

// Token: 0x0200013D RID: 317
public struct CharacterStateFlags : global::System.IFormattable, global::System.IEquatable<global::CharacterStateFlags>
{
	// Token: 0x060007E9 RID: 2025 RVA: 0x000219F4 File Offset: 0x0001FBF4
	public CharacterStateFlags(bool crouching, bool sprinting, bool aiming, bool attacking, bool airborne, bool slipping, bool moving, bool lostFocus, bool lamp, bool laser)
	{
		ushort num = 0;
		if (crouching)
		{
			num |= 1;
		}
		if (sprinting)
		{
			num |= 2;
		}
		if (aiming)
		{
			num |= 4;
		}
		if (attacking)
		{
			num |= 8;
		}
		if (airborne)
		{
			num |= 0x10;
		}
		if (slipping)
		{
			num |= 0x20;
		}
		if (moving)
		{
			num |= 0x40;
		}
		if (lostFocus)
		{
			num |= 0x80;
		}
		if (lamp)
		{
			num |= 0x800;
		}
		if (laser)
		{
			num |= 0x1000;
		}
		this.flags = num;
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x060007EA RID: 2026 RVA: 0x00021A90 File Offset: 0x0001FC90
	// (set) Token: 0x060007EB RID: 2027 RVA: 0x00021AA0 File Offset: 0x0001FCA0
	public bool crouch
	{
		get
		{
			return (this.flags & 1) == 1;
		}
		set
		{
			if (value)
			{
				this.flags |= 1;
			}
			else
			{
				this.flags &= 0xFFFE;
			}
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x060007EC RID: 2028 RVA: 0x00021AD0 File Offset: 0x0001FCD0
	// (set) Token: 0x060007ED RID: 2029 RVA: 0x00021AE0 File Offset: 0x0001FCE0
	public bool sprint
	{
		get
		{
			return (this.flags & 2) == 2;
		}
		set
		{
			if (value)
			{
				this.flags |= 2;
			}
			else
			{
				this.flags &= 0xFFFD;
			}
		}
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x060007EE RID: 2030 RVA: 0x00021B10 File Offset: 0x0001FD10
	// (set) Token: 0x060007EF RID: 2031 RVA: 0x00021B28 File Offset: 0x0001FD28
	public bool crouchBlocked
	{
		get
		{
			return (this.flags & 0x400) == 0x400;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x400;
			}
			else
			{
				this.flags &= 0xFBFF;
			}
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x060007F0 RID: 2032 RVA: 0x00021B5C File Offset: 0x0001FD5C
	// (set) Token: 0x060007F1 RID: 2033 RVA: 0x00021B6C File Offset: 0x0001FD6C
	public bool aim
	{
		get
		{
			return (this.flags & 4) == 4;
		}
		set
		{
			if (value)
			{
				this.flags |= 4;
			}
			else
			{
				this.flags &= 0xFFFB;
			}
		}
	}

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x060007F2 RID: 2034 RVA: 0x00021B9C File Offset: 0x0001FD9C
	// (set) Token: 0x060007F3 RID: 2035 RVA: 0x00021BAC File Offset: 0x0001FDAC
	public bool attack
	{
		get
		{
			return (this.flags & 8) == 8;
		}
		set
		{
			if (value)
			{
				this.flags |= 8;
			}
			else
			{
				this.flags &= 0xFFF7;
			}
		}
	}

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x060007F4 RID: 2036 RVA: 0x00021BDC File Offset: 0x0001FDDC
	// (set) Token: 0x060007F5 RID: 2037 RVA: 0x00021BF0 File Offset: 0x0001FDF0
	public bool attack2
	{
		get
		{
			return (this.flags & 8) == 0x100;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x100;
			}
			else
			{
				this.flags &= 0xFEFF;
			}
		}
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x060007F6 RID: 2038 RVA: 0x00021C24 File Offset: 0x0001FE24
	// (set) Token: 0x060007F7 RID: 2039 RVA: 0x00021C38 File Offset: 0x0001FE38
	public bool grounded
	{
		get
		{
			return (this.flags & 0x10) != 0x10;
		}
		set
		{
			if (value)
			{
				this.flags &= 0xFFEF;
			}
			else
			{
				this.flags |= 0x10;
			}
		}
	}

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x060007F8 RID: 2040 RVA: 0x00021C74 File Offset: 0x0001FE74
	// (set) Token: 0x060007F9 RID: 2041 RVA: 0x00021C8C File Offset: 0x0001FE8C
	public bool bleeding
	{
		get
		{
			return (this.flags & 0x200) != 0x200;
		}
		set
		{
			if (value)
			{
				this.flags &= 0xFDFF;
			}
			else
			{
				this.flags |= 0x200;
			}
		}
	}

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x060007FA RID: 2042 RVA: 0x00021CC0 File Offset: 0x0001FEC0
	// (set) Token: 0x060007FB RID: 2043 RVA: 0x00021CD0 File Offset: 0x0001FED0
	public bool airborne
	{
		get
		{
			return (this.flags & 0x10) == 0x10;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x10;
			}
			else
			{
				this.flags &= 0xFFEF;
			}
		}
	}

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x060007FC RID: 2044 RVA: 0x00021D0C File Offset: 0x0001FF0C
	// (set) Token: 0x060007FD RID: 2045 RVA: 0x00021D1C File Offset: 0x0001FF1C
	public bool slipping
	{
		get
		{
			return (this.flags & 0x20) == 0x20;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x20;
			}
			else
			{
				this.flags &= 0xFFDF;
			}
		}
	}

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x060007FE RID: 2046 RVA: 0x00021D58 File Offset: 0x0001FF58
	// (set) Token: 0x060007FF RID: 2047 RVA: 0x00021D68 File Offset: 0x0001FF68
	public bool movement
	{
		get
		{
			return (this.flags & 0x40) == 0x40;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x40;
			}
			else
			{
				this.flags &= 0xFFBF;
			}
		}
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06000800 RID: 2048 RVA: 0x00021DA4 File Offset: 0x0001FFA4
	// (set) Token: 0x06000801 RID: 2049 RVA: 0x00021DBC File Offset: 0x0001FFBC
	public bool lostFocus
	{
		get
		{
			return (this.flags & 0x80) == 0x80;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x80;
			}
			else
			{
				this.flags &= 0xFF7F;
			}
		}
	}

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06000802 RID: 2050 RVA: 0x00021DF0 File Offset: 0x0001FFF0
	// (set) Token: 0x06000803 RID: 2051 RVA: 0x00021E08 File Offset: 0x00020008
	public bool focus
	{
		get
		{
			return (this.flags & 0x80) != 0x80;
		}
		set
		{
			if (value)
			{
				this.flags &= 0xFF7F;
			}
			else
			{
				this.flags |= 0x80;
			}
		}
	}

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06000804 RID: 2052 RVA: 0x00021E3C File Offset: 0x0002003C
	// (set) Token: 0x06000805 RID: 2053 RVA: 0x00021E54 File Offset: 0x00020054
	public bool lamp
	{
		get
		{
			return (this.flags & 0x800) == 0x800;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x800;
			}
			else
			{
				this.flags &= 0xF7FF;
			}
		}
	}

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x06000806 RID: 2054 RVA: 0x00021E88 File Offset: 0x00020088
	// (set) Token: 0x06000807 RID: 2055 RVA: 0x00021EA0 File Offset: 0x000200A0
	public bool laser
	{
		get
		{
			return (this.flags & 0x1000) == 0x1000;
		}
		set
		{
			if (value)
			{
				this.flags |= 0x1000;
			}
			else
			{
				this.flags &= 0xEFFF;
			}
		}
	}

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x06000808 RID: 2056 RVA: 0x00021ED4 File Offset: 0x000200D4
	// (set) Token: 0x06000809 RID: 2057 RVA: 0x00021EF8 File Offset: 0x000200F8
	public global::CharacterStateFlags off
	{
		get
		{
			global::CharacterStateFlags result;
			result.flags = (~this.flags & ushort.MaxValue);
			return result;
		}
		set
		{
			this.flags = (~value.flags & ushort.MaxValue);
		}
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x00021F10 File Offset: 0x00020110
	public override bool Equals(object obj)
	{
		return obj is global::CharacterStateFlags && ((global::CharacterStateFlags)obj).flags == this.flags;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x00021F44 File Offset: 0x00020144
	public bool Equals(global::CharacterStateFlags other)
	{
		return this.flags == other.flags;
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x00021F58 File Offset: 0x00020158
	public override int GetHashCode()
	{
		return this.flags.GetHashCode();
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00021F68 File Offset: 0x00020168
	public override string ToString()
	{
		return this.flags.ToString();
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x00021F78 File Offset: 0x00020178
	public string ToString(string format, global::System.IFormatProvider formatProvider)
	{
		return this.flags.ToString(format, formatProvider);
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x00021F88 File Offset: 0x00020188
	public string ToString(string format)
	{
		return this.flags.ToString(format, null);
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00021F98 File Offset: 0x00020198
	public static global::CharacterStateFlags operator &(global::CharacterStateFlags lhs, global::CharacterStateFlags rhs)
	{
		lhs.flags &= rhs.flags;
		return lhs;
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00021FB4 File Offset: 0x000201B4
	public static global::CharacterStateFlags operator |(global::CharacterStateFlags lhs, global::CharacterStateFlags rhs)
	{
		lhs.flags |= rhs.flags;
		return lhs;
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x00021FD0 File Offset: 0x000201D0
	public static global::CharacterStateFlags operator ^(global::CharacterStateFlags lhs, global::CharacterStateFlags rhs)
	{
		lhs.flags ^= rhs.flags;
		return lhs;
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x00021FEC File Offset: 0x000201EC
	public static global::CharacterStateFlags operator &(global::CharacterStateFlags lhs, ushort rhs)
	{
		lhs.flags &= rhs;
		return lhs;
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x00022000 File Offset: 0x00020200
	public static global::CharacterStateFlags operator ^(global::CharacterStateFlags lhs, ushort rhs)
	{
		lhs.flags |= rhs;
		return lhs;
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x00022014 File Offset: 0x00020214
	public static global::CharacterStateFlags operator |(global::CharacterStateFlags lhs, ushort rhs)
	{
		lhs.flags ^= rhs;
		return lhs;
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x00022028 File Offset: 0x00020228
	public static global::CharacterStateFlags operator &(global::CharacterStateFlags lhs, int rhs)
	{
		lhs.flags &= (ushort)(rhs & 0xFFFF);
		return lhs;
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x00022044 File Offset: 0x00020244
	public static global::CharacterStateFlags operator ^(global::CharacterStateFlags lhs, int rhs)
	{
		lhs.flags |= (ushort)(rhs & 0xFFFF);
		return lhs;
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x00022060 File Offset: 0x00020260
	public static global::CharacterStateFlags operator |(global::CharacterStateFlags lhs, int rhs)
	{
		lhs.flags ^= (ushort)(rhs & 0xFFFF);
		return lhs;
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0002207C File Offset: 0x0002027C
	public static global::CharacterStateFlags operator &(global::CharacterStateFlags lhs, long rhs)
	{
		lhs.flags &= (ushort)(rhs & 0xFFFFL);
		return lhs;
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x00022098 File Offset: 0x00020298
	public static global::CharacterStateFlags operator ^(global::CharacterStateFlags lhs, long rhs)
	{
		lhs.flags |= (ushort)(rhs & 0xFFFFL);
		return lhs;
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x000220B4 File Offset: 0x000202B4
	public static global::CharacterStateFlags operator |(global::CharacterStateFlags lhs, long rhs)
	{
		lhs.flags ^= (ushort)(rhs & 0xFFFFL);
		return lhs;
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x000220D0 File Offset: 0x000202D0
	public static global::CharacterStateFlags operator &(global::CharacterStateFlags lhs, uint rhs)
	{
		lhs.flags &= (ushort)(rhs & 0xFFFFU);
		return lhs;
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000220EC File Offset: 0x000202EC
	public static global::CharacterStateFlags operator ^(global::CharacterStateFlags lhs, uint rhs)
	{
		lhs.flags |= (ushort)(rhs & 0xFFFFU);
		return lhs;
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x00022108 File Offset: 0x00020308
	public static global::CharacterStateFlags operator |(global::CharacterStateFlags lhs, uint rhs)
	{
		lhs.flags ^= (ushort)(rhs & 0xFFFFU);
		return lhs;
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x00022124 File Offset: 0x00020324
	public static global::CharacterStateFlags operator &(global::CharacterStateFlags lhs, ulong rhs)
	{
		lhs.flags &= (ushort)(rhs & 0xFFFFUL);
		return lhs;
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x00022140 File Offset: 0x00020340
	public static global::CharacterStateFlags operator ^(global::CharacterStateFlags lhs, ulong rhs)
	{
		lhs.flags |= (ushort)(rhs & 0xFFFFUL);
		return lhs;
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x0002215C File Offset: 0x0002035C
	public static global::CharacterStateFlags operator |(global::CharacterStateFlags lhs, ulong rhs)
	{
		lhs.flags ^= (ushort)(rhs & 0xFFFFUL);
		return lhs;
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x00022178 File Offset: 0x00020378
	public static int operator &(int lhs, global::CharacterStateFlags rhs)
	{
		return lhs & (int)rhs.flags;
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x00022184 File Offset: 0x00020384
	public static int operator |(int lhs, global::CharacterStateFlags rhs)
	{
		return lhs | (int)rhs.flags;
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x00022190 File Offset: 0x00020390
	public static int operator ^(int lhs, global::CharacterStateFlags rhs)
	{
		return lhs ^ (int)rhs.flags;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0002219C File Offset: 0x0002039C
	public static uint operator &(uint lhs, global::CharacterStateFlags rhs)
	{
		return lhs & (uint)rhs.flags;
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x000221A8 File Offset: 0x000203A8
	public static uint operator |(uint lhs, global::CharacterStateFlags rhs)
	{
		return lhs | (uint)rhs.flags;
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x000221B4 File Offset: 0x000203B4
	public static uint operator ^(uint lhs, global::CharacterStateFlags rhs)
	{
		return lhs ^ (uint)rhs.flags;
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x000221C0 File Offset: 0x000203C0
	public static long operator &(long lhs, global::CharacterStateFlags rhs)
	{
		return lhs & (long)rhs.flags;
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x000221CC File Offset: 0x000203CC
	public static long operator |(long lhs, global::CharacterStateFlags rhs)
	{
		return lhs | (long)rhs.flags;
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x000221D8 File Offset: 0x000203D8
	public static long operator ^(long lhs, global::CharacterStateFlags rhs)
	{
		return lhs ^ (long)rhs.flags;
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x000221E4 File Offset: 0x000203E4
	public static ulong operator &(ulong lhs, global::CharacterStateFlags rhs)
	{
		return lhs & (ulong)rhs.flags;
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x000221F0 File Offset: 0x000203F0
	public static ulong operator |(ulong lhs, global::CharacterStateFlags rhs)
	{
		return lhs | (ulong)rhs.flags;
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x000221FC File Offset: 0x000203FC
	public static ulong operator ^(ulong lhs, global::CharacterStateFlags rhs)
	{
		return lhs ^ (ulong)rhs.flags;
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x00022208 File Offset: 0x00020408
	public static int operator &(byte lhs, global::CharacterStateFlags rhs)
	{
		return (int)((ushort)lhs & rhs.flags);
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x00022214 File Offset: 0x00020414
	public static int operator |(byte lhs, global::CharacterStateFlags rhs)
	{
		return (int)((ushort)lhs | rhs.flags);
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x00022220 File Offset: 0x00020420
	public static int operator ^(byte lhs, global::CharacterStateFlags rhs)
	{
		return (int)((ushort)lhs ^ rhs.flags);
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x0002222C File Offset: 0x0002042C
	public static int operator &(sbyte lhs, global::CharacterStateFlags rhs)
	{
		return (int)lhs & (int)rhs.flags;
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x00022238 File Offset: 0x00020438
	public static int operator |(sbyte lhs, global::CharacterStateFlags rhs)
	{
		return (int)lhs | (int)rhs.flags;
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x00022244 File Offset: 0x00020444
	public static int operator ^(sbyte lhs, global::CharacterStateFlags rhs)
	{
		return (int)lhs ^ (int)rhs.flags;
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x00022250 File Offset: 0x00020450
	public static int operator &(short lhs, global::CharacterStateFlags rhs)
	{
		return (int)(lhs & (short)rhs.flags);
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0002225C File Offset: 0x0002045C
	public static int operator |(short lhs, global::CharacterStateFlags rhs)
	{
		return (int)(lhs | (short)rhs.flags);
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x00022268 File Offset: 0x00020468
	public static int operator ^(short lhs, global::CharacterStateFlags rhs)
	{
		return (int)(lhs ^ (short)rhs.flags);
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x00022274 File Offset: 0x00020474
	public static int operator &(ushort lhs, global::CharacterStateFlags rhs)
	{
		return (int)(lhs & rhs.flags);
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00022280 File Offset: 0x00020480
	public static int operator |(ushort lhs, global::CharacterStateFlags rhs)
	{
		return (int)(lhs | rhs.flags);
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x0002228C File Offset: 0x0002048C
	public static int operator ^(ushort lhs, global::CharacterStateFlags rhs)
	{
		return (int)(lhs ^ rhs.flags);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x00022298 File Offset: 0x00020498
	public static bool operator ==(global::CharacterStateFlags lhs, global::CharacterStateFlags rhs)
	{
		return lhs.flags == rhs.flags;
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x000222AC File Offset: 0x000204AC
	public static bool operator ==(global::CharacterStateFlags lhs, byte rhs)
	{
		return lhs.flags == (ushort)rhs;
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x000222B8 File Offset: 0x000204B8
	public static bool operator ==(global::CharacterStateFlags lhs, sbyte rhs)
	{
		return (int)lhs.flags == (int)rhs;
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x000222C8 File Offset: 0x000204C8
	public static bool operator ==(global::CharacterStateFlags lhs, short rhs)
	{
		return lhs.flags == (ushort)rhs;
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x000222D4 File Offset: 0x000204D4
	public static bool operator ==(global::CharacterStateFlags lhs, ushort rhs)
	{
		return lhs.flags == rhs;
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x000222E0 File Offset: 0x000204E0
	public static bool operator ==(global::CharacterStateFlags lhs, int rhs)
	{
		return (int)lhs.flags == rhs;
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x000222EC File Offset: 0x000204EC
	public static bool operator ==(global::CharacterStateFlags lhs, uint rhs)
	{
		return (uint)lhs.flags == rhs;
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x000222F8 File Offset: 0x000204F8
	public static bool operator ==(global::CharacterStateFlags lhs, long rhs)
	{
		return (long)lhs.flags == rhs;
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x00022308 File Offset: 0x00020508
	public static bool operator ==(global::CharacterStateFlags lhs, ulong rhs)
	{
		return (ulong)lhs.flags == rhs;
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x00022318 File Offset: 0x00020518
	public static bool operator ==(global::CharacterStateFlags lhs, bool rhs)
	{
		return lhs.flags != 0 == rhs;
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x0002232C File Offset: 0x0002052C
	public static bool operator !=(global::CharacterStateFlags lhs, global::CharacterStateFlags rhs)
	{
		return lhs.flags != rhs.flags;
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x00022344 File Offset: 0x00020544
	public static bool operator !=(global::CharacterStateFlags lhs, byte rhs)
	{
		return lhs.flags != (ushort)rhs;
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00022354 File Offset: 0x00020554
	public static bool operator !=(global::CharacterStateFlags lhs, sbyte rhs)
	{
		return (int)lhs.flags != (int)rhs;
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x00022364 File Offset: 0x00020564
	public static bool operator !=(global::CharacterStateFlags lhs, short rhs)
	{
		return lhs.flags != (ushort)rhs;
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x00022374 File Offset: 0x00020574
	public static bool operator !=(global::CharacterStateFlags lhs, ushort rhs)
	{
		return lhs.flags != rhs;
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00022384 File Offset: 0x00020584
	public static bool operator !=(global::CharacterStateFlags lhs, int rhs)
	{
		return (int)lhs.flags != rhs;
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x00022394 File Offset: 0x00020594
	public static bool operator !=(global::CharacterStateFlags lhs, uint rhs)
	{
		return (uint)lhs.flags != rhs;
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x000223A4 File Offset: 0x000205A4
	public static bool operator !=(global::CharacterStateFlags lhs, long rhs)
	{
		return (long)lhs.flags != rhs;
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x000223B4 File Offset: 0x000205B4
	public static bool operator !=(global::CharacterStateFlags lhs, ulong rhs)
	{
		return (ulong)lhs.flags != rhs;
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000223C4 File Offset: 0x000205C4
	public static bool operator !=(global::CharacterStateFlags lhs, bool rhs)
	{
		return lhs.flags == 0 == rhs;
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x000223D4 File Offset: 0x000205D4
	public static global::CharacterStateFlags operator >>(global::CharacterStateFlags lhs, int shift)
	{
		lhs.flags = (ushort)(lhs.flags >> shift);
		return lhs;
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x000223EC File Offset: 0x000205EC
	public static global::CharacterStateFlags operator <<(global::CharacterStateFlags lhs, int shift)
	{
		lhs.flags = (ushort)(lhs.flags >> shift);
		return lhs;
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x00022404 File Offset: 0x00020604
	public static global::CharacterStateFlags operator ~(global::CharacterStateFlags lhs)
	{
		lhs.flags = (~lhs.flags & ushort.MaxValue);
		return lhs;
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x00022420 File Offset: 0x00020620
	public static bool operator true(global::CharacterStateFlags lhs)
	{
		return lhs.flags != 0;
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00022430 File Offset: 0x00020630
	public static bool operator false(global::CharacterStateFlags lhs)
	{
		return lhs.flags == 0;
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x0002243C File Offset: 0x0002063C
	public static explicit operator bool(global::CharacterStateFlags lhs)
	{
		return lhs.flags != 0;
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x0002244C File Offset: 0x0002064C
	public static bool operator !(global::CharacterStateFlags lhs)
	{
		return lhs.flags == 0;
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x00022458 File Offset: 0x00020658
	public static implicit operator ushort(global::CharacterStateFlags lhs)
	{
		return lhs.flags;
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x00022464 File Offset: 0x00020664
	public static implicit operator global::CharacterStateFlags(ushort lhs)
	{
		global::CharacterStateFlags result;
		result.flags = lhs;
		return result;
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x0002247C File Offset: 0x0002067C
	public static implicit operator global::CharacterStateFlags(int lhs)
	{
		global::CharacterStateFlags result;
		result.flags = (ushort)(lhs & 0xFFFF);
		return result;
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x0002249C File Offset: 0x0002069C
	public static implicit operator global::CharacterStateFlags(long lhs)
	{
		global::CharacterStateFlags result;
		result.flags = (ushort)(lhs & 0xFFFFL);
		return result;
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x000224BC File Offset: 0x000206BC
	public static implicit operator global::CharacterStateFlags(uint lhs)
	{
		global::CharacterStateFlags result;
		result.flags = (ushort)(lhs & 0xFFFFU);
		return result;
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x000224DC File Offset: 0x000206DC
	public static implicit operator global::CharacterStateFlags(ulong lhs)
	{
		global::CharacterStateFlags result;
		result.flags = (ushort)(lhs & 0xFFFFUL);
		return result;
	}

	// Token: 0x04000632 RID: 1586
	public const ushort kCrouch = 1;

	// Token: 0x04000633 RID: 1587
	public const ushort kSprint = 2;

	// Token: 0x04000634 RID: 1588
	public const ushort kAim = 4;

	// Token: 0x04000635 RID: 1589
	public const ushort kAttack = 8;

	// Token: 0x04000636 RID: 1590
	public const ushort kAirborne = 0x10;

	// Token: 0x04000637 RID: 1591
	public const ushort kSlipping = 0x20;

	// Token: 0x04000638 RID: 1592
	public const ushort kMovement = 0x40;

	// Token: 0x04000639 RID: 1593
	public const ushort kLostFocus = 0x80;

	// Token: 0x0400063A RID: 1594
	public const ushort kAttack2 = 0x100;

	// Token: 0x0400063B RID: 1595
	public const ushort kBleeding = 0x200;

	// Token: 0x0400063C RID: 1596
	public const ushort kCrouchBlocked = 0x400;

	// Token: 0x0400063D RID: 1597
	public const ushort kLamp = 0x800;

	// Token: 0x0400063E RID: 1598
	public const ushort kLaser = 0x1000;

	// Token: 0x0400063F RID: 1599
	public const ushort kNone = 0;

	// Token: 0x04000640 RID: 1600
	public const ushort kMask = 0x1FFF;

	// Token: 0x04000641 RID: 1601
	private const ushort kAllMask = 0xFFFF;

	// Token: 0x04000642 RID: 1602
	private const ushort kNotCrouch = 0xFFFE;

	// Token: 0x04000643 RID: 1603
	private const ushort kNotSprint = 0xFFFD;

	// Token: 0x04000644 RID: 1604
	private const ushort kNotAim = 0xFFFB;

	// Token: 0x04000645 RID: 1605
	private const ushort kNotAttack = 0xFFF7;

	// Token: 0x04000646 RID: 1606
	private const ushort kNotAirborne = 0xFFEF;

	// Token: 0x04000647 RID: 1607
	private const ushort kNotSlipping = 0xFFDF;

	// Token: 0x04000648 RID: 1608
	private const ushort kNotMovement = 0xFFBF;

	// Token: 0x04000649 RID: 1609
	private const ushort kNotLostFocus = 0xFF7F;

	// Token: 0x0400064A RID: 1610
	private const ushort kNotAttack2 = 0xFEFF;

	// Token: 0x0400064B RID: 1611
	private const ushort kNotBleeding = 0xFDFF;

	// Token: 0x0400064C RID: 1612
	private const ushort kNotCrouchBlocked = 0xFBFF;

	// Token: 0x0400064D RID: 1613
	private const ushort kNotLamp = 0xF7FF;

	// Token: 0x0400064E RID: 1614
	private const ushort kNotLaser = 0xEFFF;

	// Token: 0x0400064F RID: 1615
	public ushort flags;
}
