using System;
using UnityEngine;

// Token: 0x02000569 RID: 1385
public class Angle2EncDecTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EEB RID: 12011 RVA: 0x000B2D04 File Offset: 0x000B0F04
	public Angle2EncDecTest()
	{
	}

	// Token: 0x06002EEC RID: 12012 RVA: 0x000B2D18 File Offset: 0x000B0F18
	private void Update()
	{
		float num = global::UnityEngine.Time.deltaTime * this.rate;
		if (num != 0f)
		{
			this.a.x = this.a.x + num;
			while (this.a.x > 360f)
			{
				this.a.x = this.a.x - 360f;
			}
			while (this.a.x < 0f)
			{
				this.a.x = this.a.x + 360f;
			}
			this.dec = null;
		}
	}

	// Token: 0x06002EED RID: 12013 RVA: 0x000B2DC4 File Offset: 0x000B0FC4
	private void OnGUI()
	{
		if (this.dec == null)
		{
			this.dec = new global::Angle2?(this.a.decoded);
			this.contents[this.contentIndex++].text = string.Concat(new object[]
			{
				"Enc:\t",
				this.a.x,
				"\tDec:\t",
				this.dec.Value.x,
				"\tRED:\t",
				this.dec.Value.decoded.x
			});
			this.contentIndex %= this.contents.Length;
		}
		foreach (global::UnityEngine.GUIContent guicontent in this.contents)
		{
			global::UnityEngine.GUILayout.Label(guicontent, new global::UnityEngine.GUILayoutOption[0]);
		}
	}

	// Token: 0x04001885 RID: 6277
	public float rate = 360f;

	// Token: 0x04001886 RID: 6278
	public global::UnityEngine.GUIContent[] contents;

	// Token: 0x04001887 RID: 6279
	private int contentIndex;

	// Token: 0x04001888 RID: 6280
	private global::Angle2 a;

	// Token: 0x04001889 RID: 6281
	private global::Angle2? dec;
}
