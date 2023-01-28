using System;
using UnityEngine;

// Token: 0x0200098F RID: 2447
[global::System.Serializable]
public class TOD_CycleParameters
{
	// Token: 0x060052CC RID: 21196 RVA: 0x00159328 File Offset: 0x00157528
	public TOD_CycleParameters()
	{
	}

	// Token: 0x17000F7C RID: 3964
	// (get) Token: 0x060052CD RID: 21197 RVA: 0x00159360 File Offset: 0x00157560
	// (set) Token: 0x060052CE RID: 21198 RVA: 0x001593B8 File Offset: 0x001575B8
	public global::System.DateTime DateTime
	{
		get
		{
			this.CheckRange();
			int num = (int)this.Hour;
			float num2 = (this.Hour - (float)num) * 60f;
			int num3 = (int)num2;
			float num4 = (num2 - (float)num3) * 60f;
			int second = (int)num4;
			return new global::System.DateTime(this.Year, this.Month, this.Day, num, num3, second);
		}
		set
		{
			this.Year = value.Year;
			this.Month = value.Month;
			this.Day = value.Day;
			this.Hour = (float)value.Hour + (float)value.Minute / 60f + (float)value.Second / 3600f;
		}
	}

	// Token: 0x17000F7D RID: 3965
	// (get) Token: 0x060052CF RID: 21199 RVA: 0x00159418 File Offset: 0x00157618
	// (set) Token: 0x060052D0 RID: 21200 RVA: 0x00159434 File Offset: 0x00157634
	public long Ticks
	{
		get
		{
			return this.DateTime.Ticks;
		}
		set
		{
			this.DateTime = new global::System.DateTime(value);
		}
	}

	// Token: 0x060052D1 RID: 21201 RVA: 0x00159444 File Offset: 0x00157644
	public void CheckRange()
	{
		this.Year = global::UnityEngine.Mathf.Clamp(this.Year, 1, 0x270F);
		this.Month = global::UnityEngine.Mathf.Clamp(this.Month, 1, 0xC);
		this.Day = global::UnityEngine.Mathf.Clamp(this.Day, 1, global::System.DateTime.DaysInMonth(this.Year, this.Month));
		this.Hour = global::UnityEngine.Mathf.Repeat(this.Hour, 24f);
		this.Longitude = global::UnityEngine.Mathf.Clamp(this.Longitude, -180f, 180f);
		this.Latitude = global::UnityEngine.Mathf.Clamp(this.Latitude, -90f, 90f);
		this.MoonPhase = global::UnityEngine.Mathf.Clamp(this.MoonPhase, -1f, 1f);
	}

	// Token: 0x04002FE1 RID: 12257
	public float Hour = 12f;

	// Token: 0x04002FE2 RID: 12258
	public int Day = 1;

	// Token: 0x04002FE3 RID: 12259
	public int Month = 3;

	// Token: 0x04002FE4 RID: 12260
	public int Year = 0x7D0;

	// Token: 0x04002FE5 RID: 12261
	public float MoonPhase;

	// Token: 0x04002FE6 RID: 12262
	public float Latitude;

	// Token: 0x04002FE7 RID: 12263
	public float Longitude;

	// Token: 0x04002FE8 RID: 12264
	public float UTC;
}
