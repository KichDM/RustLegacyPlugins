using System;
using UnityEngine;

// Token: 0x020009AD RID: 2477
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Renderer))]
public class RenderAtWeather : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005341 RID: 21313 RVA: 0x0015D520 File Offset: 0x0015B720
	public RenderAtWeather()
	{
	}

	// Token: 0x06005342 RID: 21314 RVA: 0x0015D528 File Offset: 0x0015B728
	protected void OnEnable()
	{
		if (!this.sky)
		{
			global::UnityEngine.Debug.LogError("Sky instance reference not set. Disabling script.");
			base.enabled = false;
		}
		this.rendererComponent = base.renderer;
	}

	// Token: 0x06005343 RID: 21315 RVA: 0x0015D558 File Offset: 0x0015B758
	protected void Update()
	{
		this.rendererComponent.enabled = (this.sky.Components.Weather.Weather == this.type);
	}

	// Token: 0x040030B4 RID: 12468
	public global::TOD_Sky sky;

	// Token: 0x040030B5 RID: 12469
	public global::TOD_Weather.WeatherType type;

	// Token: 0x040030B6 RID: 12470
	private global::UnityEngine.Renderer rendererComponent;
}
