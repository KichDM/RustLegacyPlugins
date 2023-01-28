using System;
using UnityEngine;

// Token: 0x020009AC RID: 2476
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Renderer))]
public class RenderAtNight : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600533E RID: 21310 RVA: 0x0015D4D0 File Offset: 0x0015B6D0
	public RenderAtNight()
	{
	}

	// Token: 0x0600533F RID: 21311 RVA: 0x0015D4D8 File Offset: 0x0015B6D8
	protected void OnEnable()
	{
		if (!this.sky)
		{
			global::UnityEngine.Debug.LogError("Sky instance reference not set. Disabling script.");
			base.enabled = false;
		}
		this.rendererComponent = base.renderer;
	}

	// Token: 0x06005340 RID: 21312 RVA: 0x0015D508 File Offset: 0x0015B708
	protected void Update()
	{
		this.rendererComponent.enabled = this.sky.IsNight;
	}

	// Token: 0x040030B2 RID: 12466
	public global::TOD_Sky sky;

	// Token: 0x040030B3 RID: 12467
	private global::UnityEngine.Renderer rendererComponent;
}
