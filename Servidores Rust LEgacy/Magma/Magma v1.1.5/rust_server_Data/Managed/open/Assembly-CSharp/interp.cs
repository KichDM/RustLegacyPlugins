using System;
using UnityEngine;

// Token: 0x02000343 RID: 835
public class interp : global::ConsoleSystem
{
	// Token: 0x06001C28 RID: 7208 RVA: 0x00070D70 File Offset: 0x0006EF70
	public interp()
	{
	}

	// Token: 0x170007BF RID: 1983
	// (get) Token: 0x06001C29 RID: 7209 RVA: 0x00070D78 File Offset: 0x0006EF78
	// (set) Token: 0x06001C2A RID: 7210 RVA: 0x00070D80 File Offset: 0x0006EF80
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("This value determins how much time to append to interp delay ( on clients ) based on server.sendrate", "")]
	public static float ratio
	{
		get
		{
			return global::Interpolation.clientInterpRatio;
		}
		set
		{
			if (!float.IsInfinity(value) && !float.IsNaN(value))
			{
				global::Interpolation.clientInterpRatio = global::UnityEngine.Mathf.Max(0f, value);
			}
		}
	}

	// Token: 0x170007C0 RID: 1984
	// (get) Token: 0x06001C2B RID: 7211 RVA: 0x00070DB4 File Offset: 0x0006EFB4
	// (set) Token: 0x06001C2C RID: 7212 RVA: 0x00070DBC File Offset: 0x0006EFBC
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("This value adds a fixed amount of delay ( in milliseconds ) to interp delay ( on clients ).", "")]
	public static int delayms
	{
		get
		{
			return global::Interpolation.clientInterpDelay;
		}
		set
		{
			if (value < 0)
			{
				global::Interpolation.clientInterpDelay = 0;
			}
			else
			{
				global::Interpolation.clientInterpDelay = value;
			}
		}
	}
}
