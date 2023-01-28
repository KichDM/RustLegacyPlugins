using System;
using UnityEngine;

// Token: 0x020009A1 RID: 2465
public class TOD_Weather : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005324 RID: 21284 RVA: 0x0015CBD0 File Offset: 0x0015ADD0
	public TOD_Weather()
	{
	}

	// Token: 0x06005325 RID: 21285 RVA: 0x0015CBE4 File Offset: 0x0015ADE4
	protected void Start()
	{
		this.sky = base.GetComponent<global::TOD_Sky>();
		this.cloudBrightness = (this.cloudBrightnessDefault = this.sky.Clouds.Brightness);
		this.cloudDensity = (this.cloudDensityDefault = this.sky.Clouds.Density);
		this.atmosphereFog = (this.atmosphereFogDefault = this.sky.Atmosphere.Fogginess);
		this.cloudSharpness = this.sky.Clouds.Sharpness;
	}

	// Token: 0x06005326 RID: 21286 RVA: 0x0015CC70 File Offset: 0x0015AE70
	protected void Update()
	{
		if (this.Clouds == global::TOD_Weather.CloudType.Custom && this.Weather == global::TOD_Weather.WeatherType.Custom)
		{
			return;
		}
		switch (this.Clouds)
		{
		case global::TOD_Weather.CloudType.Custom:
			this.cloudDensity = this.sky.Clouds.Density;
			this.cloudSharpness = this.sky.Clouds.Sharpness;
			break;
		case global::TOD_Weather.CloudType.None:
			this.cloudDensity = 0f;
			this.cloudSharpness = 1f;
			break;
		case global::TOD_Weather.CloudType.Few:
			this.cloudDensity = this.cloudDensityDefault;
			this.cloudSharpness = 6f;
			break;
		case global::TOD_Weather.CloudType.Scattered:
			this.cloudDensity = this.cloudDensityDefault;
			this.cloudSharpness = 3f;
			break;
		case global::TOD_Weather.CloudType.Broken:
			this.cloudDensity = this.cloudDensityDefault;
			this.cloudSharpness = 1f;
			break;
		case global::TOD_Weather.CloudType.Overcast:
			this.cloudDensity = this.cloudDensityDefault;
			this.cloudSharpness = 0.1f;
			break;
		}
		switch (this.Weather)
		{
		case global::TOD_Weather.WeatherType.Custom:
			this.cloudBrightness = this.sky.Clouds.Brightness;
			this.atmosphereFog = this.sky.Atmosphere.Fogginess;
			break;
		case global::TOD_Weather.WeatherType.Clear:
			this.cloudBrightness = this.cloudBrightnessDefault;
			this.atmosphereFog = this.atmosphereFogDefault;
			break;
		case global::TOD_Weather.WeatherType.Storm:
			this.cloudBrightness = 0.3f;
			this.atmosphereFog = 1f;
			break;
		case global::TOD_Weather.WeatherType.Dust:
			this.cloudBrightness = this.cloudBrightnessDefault;
			this.atmosphereFog = 0.5f;
			break;
		case global::TOD_Weather.WeatherType.Fog:
			this.cloudBrightness = this.cloudBrightnessDefault;
			this.atmosphereFog = 1f;
			break;
		}
		float num = global::UnityEngine.Time.deltaTime / this.FadeTime;
		this.sky.Clouds.Brightness = global::UnityEngine.Mathf.Lerp(this.sky.Clouds.Brightness, this.cloudBrightness, num);
		this.sky.Clouds.Density = global::UnityEngine.Mathf.Lerp(this.sky.Clouds.Density, this.cloudDensity, num);
		this.sky.Clouds.Sharpness = global::UnityEngine.Mathf.Lerp(this.sky.Clouds.Sharpness, this.cloudSharpness, num);
		this.sky.Atmosphere.Fogginess = global::UnityEngine.Mathf.Lerp(this.sky.Atmosphere.Fogginess, this.atmosphereFog, num);
	}

	// Token: 0x04003077 RID: 12407
	public float FadeTime = 10f;

	// Token: 0x04003078 RID: 12408
	public global::TOD_Weather.CloudType Clouds;

	// Token: 0x04003079 RID: 12409
	public global::TOD_Weather.WeatherType Weather;

	// Token: 0x0400307A RID: 12410
	private float cloudBrightnessDefault;

	// Token: 0x0400307B RID: 12411
	private float cloudDensityDefault;

	// Token: 0x0400307C RID: 12412
	private float atmosphereFogDefault;

	// Token: 0x0400307D RID: 12413
	private float cloudBrightness;

	// Token: 0x0400307E RID: 12414
	private float cloudDensity;

	// Token: 0x0400307F RID: 12415
	private float atmosphereFog;

	// Token: 0x04003080 RID: 12416
	private float cloudSharpness;

	// Token: 0x04003081 RID: 12417
	private global::TOD_Sky sky;

	// Token: 0x020009A2 RID: 2466
	public enum CloudType
	{
		// Token: 0x04003083 RID: 12419
		Custom,
		// Token: 0x04003084 RID: 12420
		None,
		// Token: 0x04003085 RID: 12421
		Few,
		// Token: 0x04003086 RID: 12422
		Scattered,
		// Token: 0x04003087 RID: 12423
		Broken,
		// Token: 0x04003088 RID: 12424
		Overcast
	}

	// Token: 0x020009A3 RID: 2467
	public enum WeatherType
	{
		// Token: 0x0400308A RID: 12426
		Custom,
		// Token: 0x0400308B RID: 12427
		Clear,
		// Token: 0x0400308C RID: 12428
		Storm,
		// Token: 0x0400308D RID: 12429
		Dust,
		// Token: 0x0400308E RID: 12430
		Fog
	}
}
