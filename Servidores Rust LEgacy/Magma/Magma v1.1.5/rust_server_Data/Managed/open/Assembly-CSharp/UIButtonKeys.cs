using System;
using UnityEngine;

// Token: 0x020008AF RID: 2223
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Keys")]
public class UIButtonKeys : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CD3 RID: 19667 RVA: 0x001238B4 File Offset: 0x00121AB4
	public UIButtonKeys()
	{
	}

	// Token: 0x06004CD4 RID: 19668 RVA: 0x001238BC File Offset: 0x00121ABC
	private void Start()
	{
		if (this.startsSelected && (global::UICamera.selectedObject == null || !global::UICamera.selectedObject.activeInHierarchy))
		{
			global::UICamera.selectedObject = base.gameObject;
		}
	}

	// Token: 0x06004CD5 RID: 19669 RVA: 0x00123900 File Offset: 0x00121B00
	private void OnKey(global::UnityEngine.KeyCode key)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			switch (key)
			{
			case 0x111:
				if (this.selectOnUp != null)
				{
					global::UICamera.selectedObject = this.selectOnUp.gameObject;
				}
				break;
			case 0x112:
				if (this.selectOnDown != null)
				{
					global::UICamera.selectedObject = this.selectOnDown.gameObject;
				}
				break;
			case 0x113:
				if (this.selectOnRight != null)
				{
					global::UICamera.selectedObject = this.selectOnRight.gameObject;
				}
				break;
			case 0x114:
				if (this.selectOnLeft != null)
				{
					global::UICamera.selectedObject = this.selectOnLeft.gameObject;
				}
				break;
			default:
				if (key == 9)
				{
					if (global::UnityEngine.Input.GetKey(0x130) || global::UnityEngine.Input.GetKey(0x12F))
					{
						if (this.selectOnLeft != null)
						{
							global::UICamera.selectedObject = this.selectOnLeft.gameObject;
						}
						else if (this.selectOnUp != null)
						{
							global::UICamera.selectedObject = this.selectOnUp.gameObject;
						}
						else if (this.selectOnDown != null)
						{
							global::UICamera.selectedObject = this.selectOnDown.gameObject;
						}
						else if (this.selectOnRight != null)
						{
							global::UICamera.selectedObject = this.selectOnRight.gameObject;
						}
					}
					else if (this.selectOnRight != null)
					{
						global::UICamera.selectedObject = this.selectOnRight.gameObject;
					}
					else if (this.selectOnDown != null)
					{
						global::UICamera.selectedObject = this.selectOnDown.gameObject;
					}
					else if (this.selectOnUp != null)
					{
						global::UICamera.selectedObject = this.selectOnUp.gameObject;
					}
					else if (this.selectOnRight != null)
					{
						global::UICamera.selectedObject = this.selectOnRight.gameObject;
					}
				}
				break;
			}
		}
	}

	// Token: 0x06004CD6 RID: 19670 RVA: 0x00123B3C File Offset: 0x00121D3C
	private void OnClick()
	{
		if (base.enabled && this.selectOnClick != null)
		{
			global::UICamera.selectedObject = this.selectOnClick.gameObject;
		}
	}

	// Token: 0x040029A0 RID: 10656
	public bool startsSelected;

	// Token: 0x040029A1 RID: 10657
	public global::UIButtonKeys selectOnClick;

	// Token: 0x040029A2 RID: 10658
	public global::UIButtonKeys selectOnUp;

	// Token: 0x040029A3 RID: 10659
	public global::UIButtonKeys selectOnDown;

	// Token: 0x040029A4 RID: 10660
	public global::UIButtonKeys selectOnLeft;

	// Token: 0x040029A5 RID: 10661
	public global::UIButtonKeys selectOnRight;
}
