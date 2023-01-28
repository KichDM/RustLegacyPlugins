using System;
using UnityEngine;

// Token: 0x020008B0 RID: 2224
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Message")]
public class UIButtonMessage : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CD7 RID: 19671 RVA: 0x00123B78 File Offset: 0x00121D78
	public UIButtonMessage()
	{
	}

	// Token: 0x06004CD8 RID: 19672 RVA: 0x00123B80 File Offset: 0x00121D80
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06004CD9 RID: 19673 RVA: 0x00123B8C File Offset: 0x00121D8C
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(global::UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06004CDA RID: 19674 RVA: 0x00123BB8 File Offset: 0x00121DB8
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if ((isOver && this.trigger == global::UIButtonMessage.Trigger.OnMouseOver) || (!isOver && this.trigger == global::UIButtonMessage.Trigger.OnMouseOut))
			{
				this.Send();
			}
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x06004CDB RID: 19675 RVA: 0x00123C04 File Offset: 0x00121E04
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == global::UIButtonMessage.Trigger.OnPress) || (!isPressed && this.trigger == global::UIButtonMessage.Trigger.OnRelease)))
		{
			this.Send();
		}
	}

	// Token: 0x06004CDC RID: 19676 RVA: 0x00123C3C File Offset: 0x00121E3C
	private void OnClick()
	{
		if (base.enabled && this.trigger == global::UIButtonMessage.Trigger.OnClick)
		{
			this.Send();
		}
	}

	// Token: 0x06004CDD RID: 19677 RVA: 0x00123C5C File Offset: 0x00121E5C
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == global::UIButtonMessage.Trigger.OnDoubleClick)
		{
			this.Send();
		}
	}

	// Token: 0x06004CDE RID: 19678 RVA: 0x00123C7C File Offset: 0x00121E7C
	private void Send()
	{
		if (string.IsNullOrEmpty(this.functionName))
		{
			return;
		}
		if (this.target == null)
		{
			this.target = base.gameObject;
		}
		if (this.includeChildren)
		{
			global::UnityEngine.Transform[] componentsInChildren = this.target.GetComponentsInChildren<global::UnityEngine.Transform>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				global::UnityEngine.Transform transform = componentsInChildren[i];
				transform.gameObject.SendMessage(this.functionName, base.gameObject, 1);
				i++;
			}
		}
		else
		{
			this.target.SendMessage(this.functionName, base.gameObject, 1);
		}
	}

	// Token: 0x040029A6 RID: 10662
	public global::UnityEngine.GameObject target;

	// Token: 0x040029A7 RID: 10663
	public string functionName;

	// Token: 0x040029A8 RID: 10664
	public global::UIButtonMessage.Trigger trigger;

	// Token: 0x040029A9 RID: 10665
	public bool includeChildren;

	// Token: 0x040029AA RID: 10666
	private bool mStarted;

	// Token: 0x040029AB RID: 10667
	private bool mHighlighted;

	// Token: 0x020008B1 RID: 2225
	public enum Trigger
	{
		// Token: 0x040029AD RID: 10669
		OnClick,
		// Token: 0x040029AE RID: 10670
		OnMouseOver,
		// Token: 0x040029AF RID: 10671
		OnMouseOut,
		// Token: 0x040029B0 RID: 10672
		OnPress,
		// Token: 0x040029B1 RID: 10673
		OnRelease,
		// Token: 0x040029B2 RID: 10674
		OnDoubleClick
	}
}
