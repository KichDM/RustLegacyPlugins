using System;
using UnityEngine;

// Token: 0x0200051F RID: 1311
public class VoiceChatIcon : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C7D RID: 11389 RVA: 0x000A8090 File Offset: 0x000A6290
	public VoiceChatIcon()
	{
	}

	// Token: 0x06002C7E RID: 11390 RVA: 0x000A8098 File Offset: 0x000A6298
	private void OnEnable()
	{
		this.label = base.GetComponent<global::dfLabel>();
	}

	// Token: 0x06002C7F RID: 11391 RVA: 0x000A80A8 File Offset: 0x000A62A8
	private void Update()
	{
		if (this.label == null)
		{
			return;
		}
		float num = 0f;
		if (global::GameInput.GetButton("Voice").IsDown())
		{
			num = global::USpeaker.CurrentVolume;
		}
		this.label.Opacity = global::UnityEngine.Mathf.Clamp(num * 20f, 0f, 1f);
	}

	// Token: 0x040016B9 RID: 5817
	private global::dfLabel label;
}
