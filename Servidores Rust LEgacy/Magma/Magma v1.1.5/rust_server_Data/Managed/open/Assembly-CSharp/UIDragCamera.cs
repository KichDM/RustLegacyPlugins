using System;
using UnityEngine;

// Token: 0x020008BC RID: 2236
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Drag Camera")]
[global::UnityEngine.ExecuteInEditMode]
public class UIDragCamera : global::IgnoreTimeScale
{
	// Token: 0x06004D18 RID: 19736 RVA: 0x00124E60 File Offset: 0x00123060
	public UIDragCamera()
	{
	}

	// Token: 0x06004D19 RID: 19737 RVA: 0x00124E68 File Offset: 0x00123068
	private void Awake()
	{
		if (this.target != null)
		{
			if (this.draggableCamera == null)
			{
				this.draggableCamera = this.target.GetComponent<global::UIDraggableCamera>();
				if (this.draggableCamera == null)
				{
					this.draggableCamera = this.target.gameObject.AddComponent<global::UIDraggableCamera>();
				}
			}
			this.target = null;
		}
		else if (this.draggableCamera == null)
		{
			this.draggableCamera = global::NGUITools.FindInParents<global::UIDraggableCamera>(base.gameObject);
		}
	}

	// Token: 0x06004D1A RID: 19738 RVA: 0x00124F00 File Offset: 0x00123100
	private void OnPress(bool isPressed)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.draggableCamera != null)
		{
			this.draggableCamera.Press(isPressed);
		}
	}

	// Token: 0x06004D1B RID: 19739 RVA: 0x00124F48 File Offset: 0x00123148
	private void OnDrag(global::UnityEngine.Vector2 delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.draggableCamera != null)
		{
			this.draggableCamera.Drag(delta);
		}
	}

	// Token: 0x06004D1C RID: 19740 RVA: 0x00124F90 File Offset: 0x00123190
	private void OnScroll(float delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.draggableCamera != null)
		{
			this.draggableCamera.Scroll(delta);
		}
	}

	// Token: 0x040029FE RID: 10750
	public global::UIDraggableCamera draggableCamera;

	// Token: 0x040029FF RID: 10751
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Component target;
}
