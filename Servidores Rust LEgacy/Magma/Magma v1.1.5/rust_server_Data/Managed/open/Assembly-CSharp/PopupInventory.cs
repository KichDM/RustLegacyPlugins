using System;
using UnityEngine;

// Token: 0x0200051B RID: 1307
public class PopupInventory : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C70 RID: 11376 RVA: 0x000A7BF4 File Offset: 0x000A5DF4
	public PopupInventory()
	{
	}

	// Token: 0x06002C71 RID: 11377 RVA: 0x000A7BFC File Offset: 0x000A5DFC
	// Note: this type is marked as 'beforefieldinit'.
	static PopupInventory()
	{
	}

	// Token: 0x06002C72 RID: 11378 RVA: 0x000A7C00 File Offset: 0x000A5E00
	public void Setup(float fSeconds, string strText)
	{
		global::UnityEngine.Vector2 size = base.transform.parent.GetComponent<global::dfPanel>().Size;
		global::dfPanel component = base.GetComponent<global::dfPanel>();
		global::UnityEngine.Vector2 vector = this.labelText.Font.MeasureText(strText, this.labelText.FontSize, this.labelText.FontStyle);
		this.labelText.Width = vector.x + 16f;
		component.Width = this.labelText.RelativePosition.x + this.labelText.Width + 8f;
		global::UnityEngine.Vector2 vector2 = default(global::UnityEngine.Vector2);
		vector2.x = size.x + global::UnityEngine.Random.Range(-16f, 16f);
		vector2.y = size.y * 0.7f + global::UnityEngine.Random.Range(-16f, 16f);
		vector2.y += ((float)global::PopupInventory.iYPos / 6f - 0.5f) * size.y * 0.2f;
		component.RelativePosition = vector2;
		global::PopupInventory.iYPos++;
		if (global::PopupInventory.iYPos > 5)
		{
			global::PopupInventory.iYPos = 0;
		}
		global::UnityEngine.Vector3 endValue = this.tweenOut.EndValue;
		endValue.y = global::UnityEngine.Random.Range(-100f, 100f);
		this.tweenOut.EndValue = endValue;
		component.BringToFront();
		this.labelText.Text = strText;
		base.Invoke("PlayOut", fSeconds);
	}

	// Token: 0x06002C73 RID: 11379 RVA: 0x000A7D88 File Offset: 0x000A5F88
	public void PlayOut()
	{
		this.tweenOut.Play();
		global::UnityEngine.Object.Destroy(base.gameObject, this.tweenOut.Length);
	}

	// Token: 0x040016B2 RID: 5810
	public global::dfRichTextLabel labelText;

	// Token: 0x040016B3 RID: 5811
	public global::dfTweenVector3 tweenOut;

	// Token: 0x040016B4 RID: 5812
	private static int iYPos;
}
