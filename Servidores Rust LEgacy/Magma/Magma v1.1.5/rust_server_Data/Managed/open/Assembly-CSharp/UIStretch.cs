using System;
using UnityEngine;

// Token: 0x02000965 RID: 2405
[global::UnityEngine.AddComponentMenu("NGUI/UI/Stretch")]
[global::UnityEngine.ExecuteInEditMode]
public class UIStretch : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005219 RID: 21017 RVA: 0x001501E0 File Offset: 0x0014E3E0
	public UIStretch()
	{
	}

	// Token: 0x0600521A RID: 21018 RVA: 0x001501F4 File Offset: 0x0014E3F4
	private void OnEnable()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.mRoot = global::NGUITools.FindInParents<global::UIRoot>(base.gameObject);
	}

	// Token: 0x0600521B RID: 21019 RVA: 0x0015023C File Offset: 0x0014E43C
	private void Update()
	{
		if (this.uiCamera != null && this.style != global::UIStretch.Style.None)
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			global::UnityEngine.Rect pixelRect = this.uiCamera.pixelRect;
			float num = pixelRect.width;
			float num2 = pixelRect.height;
			if (this.mRoot != null && !this.mRoot.automatic && num2 > 1f)
			{
				float num3 = (float)this.mRoot.manualHeight / num2;
				num *= num3;
				num2 *= num3;
			}
			global::UnityEngine.Vector3 localScale = this.mTrans.localScale;
			if (this.style == global::UIStretch.Style.BasedOnHeight)
			{
				localScale.x = this.relativeSize.x * num2;
				localScale.y = this.relativeSize.y * num2;
			}
			else
			{
				if (this.style == global::UIStretch.Style.Both || this.style == global::UIStretch.Style.Horizontal)
				{
					localScale.x = this.relativeSize.x * num;
				}
				if (this.style == global::UIStretch.Style.Both || this.style == global::UIStretch.Style.Vertical)
				{
					localScale.y = this.relativeSize.y * num2;
				}
			}
			if (this.mTrans.localScale != localScale)
			{
				this.mTrans.localScale = localScale;
			}
		}
	}

	// Token: 0x04002E6D RID: 11885
	public global::UnityEngine.Camera uiCamera;

	// Token: 0x04002E6E RID: 11886
	public global::UIStretch.Style style;

	// Token: 0x04002E6F RID: 11887
	public global::UnityEngine.Vector2 relativeSize = global::UnityEngine.Vector2.one;

	// Token: 0x04002E70 RID: 11888
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002E71 RID: 11889
	private global::UIRoot mRoot;

	// Token: 0x02000966 RID: 2406
	public enum Style
	{
		// Token: 0x04002E73 RID: 11891
		None,
		// Token: 0x04002E74 RID: 11892
		Horizontal,
		// Token: 0x04002E75 RID: 11893
		Vertical,
		// Token: 0x04002E76 RID: 11894
		Both,
		// Token: 0x04002E77 RID: 11895
		BasedOnHeight
	}
}
