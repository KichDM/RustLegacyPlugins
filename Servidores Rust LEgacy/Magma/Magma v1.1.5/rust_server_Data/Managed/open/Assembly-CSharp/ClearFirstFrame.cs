using System;
using UnityEngine;

// Token: 0x02000576 RID: 1398
[global::UnityEngine.ExecuteInEditMode]
public class ClearFirstFrame : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002F11 RID: 12049 RVA: 0x000B3C0C File Offset: 0x000B1E0C
	public ClearFirstFrame()
	{
	}

	// Token: 0x06002F12 RID: 12050 RVA: 0x000B3C14 File Offset: 0x000B1E14
	protected void Update()
	{
		if (base.camera.clearFlags != 3)
		{
			this.Disable();
		}
	}

	// Token: 0x06002F13 RID: 12051 RVA: 0x000B3C30 File Offset: 0x000B1E30
	protected void OnPreRender()
	{
		global::UnityEngine.GL.Clear(true, true, global::UnityEngine.Color.black);
		this.Disable();
	}

	// Token: 0x06002F14 RID: 12052 RVA: 0x000B3C44 File Offset: 0x000B1E44
	private void Disable()
	{
		base.enabled = false;
	}
}
