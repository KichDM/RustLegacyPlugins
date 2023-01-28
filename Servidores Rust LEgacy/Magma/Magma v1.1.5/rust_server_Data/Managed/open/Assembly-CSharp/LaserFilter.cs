using System;
using UnityEngine;

// Token: 0x0200072A RID: 1834
public sealed class LaserFilter : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003E07 RID: 15879 RVA: 0x000D93F4 File Offset: 0x000D75F4
	public LaserFilter()
	{
	}

	// Token: 0x17000BC9 RID: 3017
	// (get) Token: 0x06003E08 RID: 15880 RVA: 0x000D93FC File Offset: 0x000D75FC
	public global::UnityEngine.Camera camera
	{
		get
		{
			if (!this._gotCam)
			{
				this._gotCam = true;
				this._camera = base.camera;
			}
			return this._camera;
		}
	}

	// Token: 0x06003E09 RID: 15881 RVA: 0x000D9430 File Offset: 0x000D7630
	private void OnPreCull()
	{
		if (base.enabled)
		{
			global::LaserGraphics.RenderLasersOnCamera(this.camera);
		}
	}

	// Token: 0x04001F80 RID: 8064
	[global::System.NonSerialized]
	private bool _gotCam;

	// Token: 0x04001F81 RID: 8065
	[global::System.NonSerialized]
	private global::UnityEngine.Camera _camera;
}
