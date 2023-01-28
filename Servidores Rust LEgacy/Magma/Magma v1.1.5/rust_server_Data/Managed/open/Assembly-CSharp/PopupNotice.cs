using System;
using UnityEngine;

// Token: 0x0200051C RID: 1308
public class PopupNotice : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C74 RID: 11380 RVA: 0x000A7DB8 File Offset: 0x000A5FB8
	public PopupNotice()
	{
	}

	// Token: 0x06002C75 RID: 11381 RVA: 0x000A7DC0 File Offset: 0x000A5FC0
	public void Setup(float fSeconds, string strIcon, string strText)
	{
		global::UnityEngine.Vector2 size = base.transform.parent.GetComponent<global::dfPanel>().Size;
		global::dfPanel component = base.GetComponent<global::dfPanel>();
		global::UnityEngine.Vector2 vector = this.labelText.Font.MeasureText(strText, this.labelText.FontSize, this.labelText.FontStyle);
		this.labelText.Width = vector.x + 16f;
		component.Width = this.labelText.RelativePosition.x + this.labelText.Width + 8f;
		global::UnityEngine.Vector2 vector2 = default(global::UnityEngine.Vector2);
		vector2.x = (size.x - component.Width) / 2f + global::UnityEngine.Random.Range(-32f, 32f);
		vector2.y = component.Height * -1f + global::UnityEngine.Random.Range(-32f, 32f);
		component.RelativePosition = vector2;
		this.labelIcon.Text = strIcon;
		this.labelText.Text = strText;
		component.BringToFront();
		base.Invoke("PlayOut", fSeconds);
	}

	// Token: 0x06002C76 RID: 11382 RVA: 0x000A7EE4 File Offset: 0x000A60E4
	public void PlayOut()
	{
		this.tweenOut.Play();
		global::UnityEngine.Object.Destroy(base.gameObject, this.tweenOut.Length);
	}

	// Token: 0x040016B5 RID: 5813
	public global::dfRichTextLabel labelIcon;

	// Token: 0x040016B6 RID: 5814
	public global::dfRichTextLabel labelText;

	// Token: 0x040016B7 RID: 5815
	public global::dfTweenVector3 tweenOut;
}
