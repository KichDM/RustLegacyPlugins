using System;
using UnityEngine;

// Token: 0x020008C8 RID: 2248
[global::UnityEngine.AddComponentMenu("NGUI/UI/Image Button")]
[global::UnityEngine.ExecuteInEditMode]
public class UIImageButton : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D68 RID: 19816 RVA: 0x00127514 File Offset: 0x00125714
	public UIImageButton()
	{
	}

	// Token: 0x06004D69 RID: 19817 RVA: 0x0012751C File Offset: 0x0012571C
	private void Start()
	{
		if (this.target == null)
		{
			this.target = base.GetComponentInChildren<global::UISprite>();
		}
	}

	// Token: 0x06004D6A RID: 19818 RVA: 0x0012753C File Offset: 0x0012573C
	private void OnHover(bool isOver)
	{
		if (base.enabled && this.target != null)
		{
			this.target.spriteName = ((!isOver) ? this.normalSprite : this.hoverSprite);
			this.target.MakePixelPerfect();
		}
	}

	// Token: 0x06004D6B RID: 19819 RVA: 0x00127594 File Offset: 0x00125794
	private void OnPress(bool pressed)
	{
		if (base.enabled && this.target != null)
		{
			this.target.spriteName = ((!pressed) ? this.normalSprite : this.pressedSprite);
			this.target.MakePixelPerfect();
		}
	}

	// Token: 0x04002A5D RID: 10845
	public global::UISprite target;

	// Token: 0x04002A5E RID: 10846
	public string normalSprite;

	// Token: 0x04002A5F RID: 10847
	public string hoverSprite;

	// Token: 0x04002A60 RID: 10848
	public string pressedSprite;
}
