using System;
using UnityEngine;

// Token: 0x020008BA RID: 2234
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Checkbox Controlled Component")]
public class UICheckboxControlledComponent : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D14 RID: 19732 RVA: 0x00124DD0 File Offset: 0x00122FD0
	public UICheckboxControlledComponent()
	{
	}

	// Token: 0x06004D15 RID: 19733 RVA: 0x00124DD8 File Offset: 0x00122FD8
	private void OnActivate(bool isActive)
	{
		if (base.enabled && this.target != null)
		{
			this.target.enabled = ((!this.inverse) ? isActive : (!isActive));
		}
	}

	// Token: 0x040029FA RID: 10746
	public global::UnityEngine.MonoBehaviour target;

	// Token: 0x040029FB RID: 10747
	public bool inverse;
}
