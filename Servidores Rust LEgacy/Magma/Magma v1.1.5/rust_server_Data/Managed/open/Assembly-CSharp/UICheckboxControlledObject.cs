using System;
using UnityEngine;

// Token: 0x020008BB RID: 2235
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Checkbox Controlled Object")]
public class UICheckboxControlledObject : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D16 RID: 19734 RVA: 0x00124E24 File Offset: 0x00123024
	public UICheckboxControlledObject()
	{
	}

	// Token: 0x06004D17 RID: 19735 RVA: 0x00124E2C File Offset: 0x0012302C
	private void OnActivate(bool isActive)
	{
		if (this.target != null)
		{
			global::NGUITools.SetActive(this.target, (!this.inverse) ? isActive : (!isActive));
		}
	}

	// Token: 0x040029FC RID: 10748
	public global::UnityEngine.GameObject target;

	// Token: 0x040029FD RID: 10749
	public bool inverse;
}
