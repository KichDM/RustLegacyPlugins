using System;
using UnityEngine;

// Token: 0x020009AB RID: 2475
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Renderer))]
public class RenderAtDay : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600533B RID: 21307 RVA: 0x0015D480 File Offset: 0x0015B680
	public RenderAtDay()
	{
	}

	// Token: 0x0600533C RID: 21308 RVA: 0x0015D488 File Offset: 0x0015B688
	protected void OnEnable()
	{
		if (!this.sky)
		{
			global::UnityEngine.Debug.LogError("Sky instance reference not set. Disabling script.");
			base.enabled = false;
		}
		this.rendererComponent = base.renderer;
	}

	// Token: 0x0600533D RID: 21309 RVA: 0x0015D4B8 File Offset: 0x0015B6B8
	protected void Update()
	{
		this.rendererComponent.enabled = this.sky.IsDay;
	}

	// Token: 0x040030B0 RID: 12464
	public global::TOD_Sky sky;

	// Token: 0x040030B1 RID: 12465
	private global::UnityEngine.Renderer rendererComponent;
}
