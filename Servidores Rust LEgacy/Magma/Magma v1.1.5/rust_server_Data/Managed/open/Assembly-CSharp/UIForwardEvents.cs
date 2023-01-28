using System;
using UnityEngine;

// Token: 0x020008C5 RID: 2245
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Forward Events")]
public class UIForwardEvents : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D59 RID: 19801 RVA: 0x00127080 File Offset: 0x00125280
	public UIForwardEvents()
	{
	}

	// Token: 0x06004D5A RID: 19802 RVA: 0x00127088 File Offset: 0x00125288
	private void OnHover(bool isOver)
	{
		if (this.onHover && this.target != null)
		{
			this.target.SendMessage("OnHover", isOver, 1);
		}
	}

	// Token: 0x06004D5B RID: 19803 RVA: 0x001270C0 File Offset: 0x001252C0
	private void OnPress(bool pressed)
	{
		if (this.onPress && this.target != null)
		{
			this.target.SendMessage("OnPress", pressed, 1);
		}
	}

	// Token: 0x06004D5C RID: 19804 RVA: 0x001270F8 File Offset: 0x001252F8
	private void OnClick()
	{
		if (this.onClick && this.target != null)
		{
			this.target.SendMessage("OnClick", 1);
		}
	}

	// Token: 0x06004D5D RID: 19805 RVA: 0x00127128 File Offset: 0x00125328
	private void OnDoubleClick()
	{
		if (this.onDoubleClick && this.target != null)
		{
			this.target.SendMessage("OnDoubleClick", 1);
		}
	}

	// Token: 0x06004D5E RID: 19806 RVA: 0x00127158 File Offset: 0x00125358
	private void OnSelect(bool selected)
	{
		if (this.onSelect && this.target != null)
		{
			this.target.SendMessage("OnSelect", selected, 1);
		}
	}

	// Token: 0x06004D5F RID: 19807 RVA: 0x00127190 File Offset: 0x00125390
	private void OnDrag(global::UnityEngine.Vector2 delta)
	{
		if (this.onDrag && this.target != null)
		{
			this.target.SendMessage("OnDrag", delta, 1);
		}
	}

	// Token: 0x06004D60 RID: 19808 RVA: 0x001271C8 File Offset: 0x001253C8
	private void OnDrop(global::UnityEngine.GameObject go)
	{
		if (this.onDrop && this.target != null)
		{
			this.target.SendMessage("OnDrop", go, 1);
		}
	}

	// Token: 0x06004D61 RID: 19809 RVA: 0x00127204 File Offset: 0x00125404
	private void OnInput(string text)
	{
		if (this.onInput && this.target != null)
		{
			this.target.SendMessage("OnInput", text, 1);
		}
	}

	// Token: 0x06004D62 RID: 19810 RVA: 0x00127240 File Offset: 0x00125440
	private void OnSubmit()
	{
		if (this.onSubmit && this.target != null)
		{
			this.target.SendMessage("OnSubmit", 1);
		}
	}

	// Token: 0x04002A48 RID: 10824
	public global::UnityEngine.GameObject target;

	// Token: 0x04002A49 RID: 10825
	public bool onHover;

	// Token: 0x04002A4A RID: 10826
	public bool onPress;

	// Token: 0x04002A4B RID: 10827
	public bool onClick;

	// Token: 0x04002A4C RID: 10828
	public bool onDoubleClick;

	// Token: 0x04002A4D RID: 10829
	public bool onSelect;

	// Token: 0x04002A4E RID: 10830
	public bool onDrag;

	// Token: 0x04002A4F RID: 10831
	public bool onDrop;

	// Token: 0x04002A50 RID: 10832
	public bool onInput;

	// Token: 0x04002A51 RID: 10833
	public bool onSubmit;
}
