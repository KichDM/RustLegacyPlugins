using System;
using UnityEngine;

// Token: 0x02000920 RID: 2336
[global::UnityEngine.AddComponentMenu("NGUI/UI/Anchor (Bordered)")]
[global::UnityEngine.ExecuteInEditMode]
public class UIBorderedAnchor : global::UIAnchor
{
	// Token: 0x06004FC4 RID: 20420 RVA: 0x00136524 File Offset: 0x00134724
	public UIBorderedAnchor()
	{
	}

	// Token: 0x06004FC5 RID: 20421 RVA: 0x0013652C File Offset: 0x0013472C
	protected new void Update()
	{
		if (this.uiCamera)
		{
			global::UnityEngine.Vector3 vector = global::UIAnchor.WorldOrigin(this.uiCamera, this.side, this.screenPixelBorder, this.depthOffset, this.relativeOffset.x, this.relativeOffset.y, this.halfPixelOffset);
			base.SetPosition(ref vector);
		}
	}

	// Token: 0x04002C3F RID: 11327
	public global::UnityEngine.RectOffset screenPixelBorder;
}
