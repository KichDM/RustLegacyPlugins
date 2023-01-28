using System;
using UnityEngine;

// Token: 0x020008B6 RID: 2230
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Button Sound")]
public class UIButtonSound : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004CFE RID: 19710 RVA: 0x001245D4 File Offset: 0x001227D4
	public UIButtonSound()
	{
	}

	// Token: 0x06004CFF RID: 19711 RVA: 0x001245F4 File Offset: 0x001227F4
	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && this.trigger == global::UIButtonSound.Trigger.OnMouseOver) || (!isOver && this.trigger == global::UIButtonSound.Trigger.OnMouseOut)))
		{
			global::NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06004D00 RID: 19712 RVA: 0x00124648 File Offset: 0x00122848
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == global::UIButtonSound.Trigger.OnPress) || (!isPressed && this.trigger == global::UIButtonSound.Trigger.OnRelease)))
		{
			global::NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06004D01 RID: 19713 RVA: 0x0012469C File Offset: 0x0012289C
	private void OnClick()
	{
		if (base.enabled && this.trigger == global::UIButtonSound.Trigger.OnClick)
		{
			global::NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x040029D7 RID: 10711
	public global::UnityEngine.AudioClip audioClip;

	// Token: 0x040029D8 RID: 10712
	public global::UIButtonSound.Trigger trigger;

	// Token: 0x040029D9 RID: 10713
	public float volume = 1f;

	// Token: 0x040029DA RID: 10714
	public float pitch = 1f;

	// Token: 0x020008B7 RID: 2231
	public enum Trigger
	{
		// Token: 0x040029DC RID: 10716
		OnClick,
		// Token: 0x040029DD RID: 10717
		OnMouseOver,
		// Token: 0x040029DE RID: 10718
		OnMouseOut,
		// Token: 0x040029DF RID: 10719
		OnPress,
		// Token: 0x040029E0 RID: 10720
		OnRelease
	}
}
