using System;
using UnityEngine;

// Token: 0x020008AD RID: 2221
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : global::UIButtonColor
{
	// Token: 0x06004CC3 RID: 19651 RVA: 0x00123528 File Offset: 0x00121728
	public UIButton()
	{
	}

	// Token: 0x06004CC4 RID: 19652 RVA: 0x0012353C File Offset: 0x0012173C
	protected override void OnEnable()
	{
		if (this.isEnabled)
		{
			base.OnEnable();
		}
		else
		{
			this.UpdateColor(false, true);
		}
	}

	// Token: 0x06004CC5 RID: 19653 RVA: 0x0012355C File Offset: 0x0012175C
	protected override void OnHover(bool isOver)
	{
		if (this.isEnabled)
		{
			base.OnHover(isOver);
		}
	}

	// Token: 0x06004CC6 RID: 19654 RVA: 0x00123570 File Offset: 0x00121770
	protected override void OnPress(bool isPressed)
	{
		if (this.isEnabled)
		{
			base.OnPress(isPressed);
		}
	}

	// Token: 0x17000E53 RID: 3667
	// (get) Token: 0x06004CC7 RID: 19655 RVA: 0x00123584 File Offset: 0x00121784
	// (set) Token: 0x06004CC8 RID: 19656 RVA: 0x0012358C File Offset: 0x0012178C
	public bool isEnabled
	{
		get
		{
			return global::NGUITools.GetAllowClick(this);
		}
		set
		{
			bool flag;
			bool allowClick = global::NGUITools.GetAllowClick(this, out flag);
			if (!flag)
			{
				return;
			}
			if (allowClick != value)
			{
				global::NGUITools.SetAllowClick(this, value);
				this.UpdateColor(value, false);
			}
		}
	}

	// Token: 0x06004CC9 RID: 19657 RVA: 0x001235C0 File Offset: 0x001217C0
	public void UpdateColor(bool shouldBeEnabled, bool immediate)
	{
		if (this.tweenTarget)
		{
			if (!this.mInitDone)
			{
				base.Init();
			}
			global::UnityEngine.Color color = (!shouldBeEnabled) ? this.disabledColor : base.defaultColor;
			global::TweenColor tweenColor = global::TweenColor.Begin(this.tweenTarget, 0.15f, color);
			if (immediate)
			{
				tweenColor.color = color;
				tweenColor.enabled = false;
			}
		}
	}

	// Token: 0x04002997 RID: 10647
	public global::UnityEngine.Color disabledColor = global::UnityEngine.Color.grey;
}
