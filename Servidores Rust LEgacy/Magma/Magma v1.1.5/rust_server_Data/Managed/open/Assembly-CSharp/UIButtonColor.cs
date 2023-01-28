using System;
using UnityEngine;

// Token: 0x020008AE RID: 2222
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CCA RID: 19658 RVA: 0x0012362C File Offset: 0x0012182C
	public UIButtonColor()
	{
	}

	// Token: 0x17000E54 RID: 3668
	// (get) Token: 0x06004CCB RID: 19659 RVA: 0x0012366C File Offset: 0x0012186C
	// (set) Token: 0x06004CCC RID: 19660 RVA: 0x00123674 File Offset: 0x00121874
	public global::UnityEngine.Color defaultColor
	{
		get
		{
			return this.mColor;
		}
		set
		{
			this.mColor = value;
		}
	}

	// Token: 0x06004CCD RID: 19661 RVA: 0x00123680 File Offset: 0x00121880
	private void Start()
	{
		this.mStarted = true;
		if (!this.mInitDone)
		{
			this.Init();
		}
	}

	// Token: 0x06004CCE RID: 19662 RVA: 0x0012369C File Offset: 0x0012189C
	protected virtual void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004CCF RID: 19663 RVA: 0x001236C8 File Offset: 0x001218C8
	private void OnDisable()
	{
		if (this.tweenTarget != null)
		{
			global::TweenColor component = this.tweenTarget.GetComponent<global::TweenColor>();
			if (component != null)
			{
				component.color = this.mColor;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06004CD0 RID: 19664 RVA: 0x00123714 File Offset: 0x00121914
	protected void Init()
	{
		this.mInitDone = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
		global::UIWidget component = this.tweenTarget.GetComponent<global::UIWidget>();
		if (component != null)
		{
			this.mColor = component.color;
		}
		else
		{
			global::UnityEngine.Renderer renderer = this.tweenTarget.renderer;
			if (renderer != null)
			{
				this.mColor = renderer.material.color;
			}
			else
			{
				global::UnityEngine.Light light = this.tweenTarget.light;
				if (light != null)
				{
					this.mColor = light.color;
				}
				else
				{
					global::UnityEngine.Debug.LogWarning(global::NGUITools.GetHierarchy(base.gameObject) + " has nothing for UIButtonColor to color", this);
					base.enabled = false;
				}
			}
		}
	}

	// Token: 0x06004CD1 RID: 19665 RVA: 0x001237E8 File Offset: 0x001219E8
	protected virtual void OnPress(bool isPressed)
	{
		if (!this.mInitDone)
		{
			this.Init();
		}
		if (base.enabled)
		{
			global::TweenColor.Begin(this.tweenTarget, this.duration, (!isPressed) ? ((!global::UICamera.IsHighlighted(base.gameObject)) ? this.mColor : this.hover) : this.pressed);
		}
	}

	// Token: 0x06004CD2 RID: 19666 RVA: 0x00123858 File Offset: 0x00121A58
	protected virtual void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mInitDone)
			{
				this.Init();
			}
			global::TweenColor.Begin(this.tweenTarget, this.duration, (!isOver) ? this.mColor : this.hover);
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x04002998 RID: 10648
	public global::UnityEngine.GameObject tweenTarget;

	// Token: 0x04002999 RID: 10649
	public global::UnityEngine.Color hover = new global::UnityEngine.Color(0.6f, 1f, 0.2f, 1f);

	// Token: 0x0400299A RID: 10650
	public global::UnityEngine.Color pressed = global::UnityEngine.Color.grey;

	// Token: 0x0400299B RID: 10651
	public float duration = 0.2f;

	// Token: 0x0400299C RID: 10652
	protected global::UnityEngine.Color mColor;

	// Token: 0x0400299D RID: 10653
	protected bool mInitDone;

	// Token: 0x0400299E RID: 10654
	protected bool mStarted;

	// Token: 0x0400299F RID: 10655
	protected bool mHighlighted;
}
