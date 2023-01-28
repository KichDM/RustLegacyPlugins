using System;
using UnityEngine;

// Token: 0x02000796 RID: 1942
public class SecurityCamScreen : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600409B RID: 16539 RVA: 0x000E72CC File Offset: 0x000E54CC
	public SecurityCamScreen()
	{
	}

	// Token: 0x0600409C RID: 16540 RVA: 0x000E72DC File Offset: 0x000E54DC
	private void Awake()
	{
		global::UnityEngine.Object.Destroy(this.RenderCamera);
	}

	// Token: 0x0600409D RID: 16541 RVA: 0x000E72EC File Offset: 0x000E54EC
	private void UpdateCam()
	{
	}

	// Token: 0x040021AB RID: 8619
	public global::UnityEngine.Camera RenderCamera;

	// Token: 0x040021AC RID: 8620
	public float renderInterval;

	// Token: 0x040021AD RID: 8621
	private bool firstInit = true;
}
