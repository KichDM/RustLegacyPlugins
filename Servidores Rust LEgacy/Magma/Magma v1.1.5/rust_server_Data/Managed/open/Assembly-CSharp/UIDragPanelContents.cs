using System;
using UnityEngine;

// Token: 0x020008BF RID: 2239
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Drag Panel Contents")]
[global::UnityEngine.ExecuteInEditMode]
public class UIDragPanelContents : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D24 RID: 19748 RVA: 0x00125794 File Offset: 0x00123994
	public UIDragPanelContents()
	{
	}

	// Token: 0x06004D25 RID: 19749 RVA: 0x0012579C File Offset: 0x0012399C
	private void Awake()
	{
		if (this.panel != null)
		{
			if (this.draggablePanel == null)
			{
				this.draggablePanel = this.panel.GetComponent<global::UIDraggablePanel>();
				if (this.draggablePanel == null)
				{
					this.draggablePanel = this.panel.gameObject.AddComponent<global::UIDraggablePanel>();
				}
			}
			this.panel = null;
		}
	}

	// Token: 0x06004D26 RID: 19750 RVA: 0x0012580C File Offset: 0x00123A0C
	private void Start()
	{
		if (this.draggablePanel == null)
		{
			this.draggablePanel = global::NGUITools.FindInParents<global::UIDraggablePanel>(base.gameObject);
		}
	}

	// Token: 0x06004D27 RID: 19751 RVA: 0x0012583C File Offset: 0x00123A3C
	private void OnPress(bool pressed)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.draggablePanel != null)
		{
			this.draggablePanel.Press(pressed);
		}
	}

	// Token: 0x06004D28 RID: 19752 RVA: 0x00125884 File Offset: 0x00123A84
	private void OnDrag(global::UnityEngine.Vector2 delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.draggablePanel != null)
		{
			this.draggablePanel.Drag(delta);
		}
	}

	// Token: 0x06004D29 RID: 19753 RVA: 0x001258CC File Offset: 0x00123ACC
	private void OnScroll(float delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.draggablePanel != null)
		{
			this.draggablePanel.Scroll(delta);
		}
	}

	// Token: 0x04002A13 RID: 10771
	public global::UIDraggablePanel draggablePanel;

	// Token: 0x04002A14 RID: 10772
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIPanel panel;
}
