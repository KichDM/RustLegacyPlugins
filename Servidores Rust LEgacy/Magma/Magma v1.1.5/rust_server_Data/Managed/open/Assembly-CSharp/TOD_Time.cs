using System;
using UnityEngine;

// Token: 0x020009A0 RID: 2464
public class TOD_Time : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005321 RID: 21281 RVA: 0x0015C9CC File Offset: 0x0015ABCC
	public TOD_Time()
	{
	}

	// Token: 0x06005322 RID: 21282 RVA: 0x0015C9F0 File Offset: 0x0015ABF0
	protected void Start()
	{
		this.sky = base.GetComponent<global::TOD_Sky>();
	}

	// Token: 0x06005323 RID: 21283 RVA: 0x0015CA00 File Offset: 0x0015AC00
	protected void Update()
	{
		float num = this.DayLengthInMinutes * 60f;
		float num2 = num / 24f;
		float num3 = global::UnityEngine.Time.deltaTime / num2;
		float num4 = global::UnityEngine.Time.deltaTime / (30f * num) * 2f;
		this.sky.Cycle.Hour += num3;
		if (this.ProgressMoonPhase)
		{
			this.sky.Cycle.MoonPhase += num4;
			if (this.sky.Cycle.MoonPhase < -1f)
			{
				this.sky.Cycle.MoonPhase += 2f;
			}
			else if (this.sky.Cycle.MoonPhase > 1f)
			{
				this.sky.Cycle.MoonPhase -= 2f;
			}
		}
		if (this.sky.Cycle.Hour >= 24f)
		{
			this.sky.Cycle.Hour = 0f;
			if (this.ProgressDate)
			{
				int num5 = global::System.DateTime.DaysInMonth(this.sky.Cycle.Year, this.sky.Cycle.Month);
				if (++this.sky.Cycle.Day > num5)
				{
					this.sky.Cycle.Day = 1;
					if (++this.sky.Cycle.Month > 0xC)
					{
						this.sky.Cycle.Month = 1;
						this.sky.Cycle.Year++;
					}
				}
			}
		}
	}

	// Token: 0x04003073 RID: 12403
	public float DayLengthInMinutes = 30f;

	// Token: 0x04003074 RID: 12404
	public bool ProgressDate = true;

	// Token: 0x04003075 RID: 12405
	public bool ProgressMoonPhase = true;

	// Token: 0x04003076 RID: 12406
	private global::TOD_Sky sky;
}
