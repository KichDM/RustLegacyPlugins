using System;
using MoPhoGames.USpeak.Interface;
using UnityEngine;

// Token: 0x020000D2 RID: 210
[global::UnityEngine.AddComponentMenu("USpeak/Default Talk Controller")]
public class DefaultTalkController : global::UnityEngine.MonoBehaviour, global::MoPhoGames.USpeak.Interface.IUSpeakTalkController
{
	// Token: 0x06000416 RID: 1046 RVA: 0x000137D8 File Offset: 0x000119D8
	public DefaultTalkController()
	{
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x000137E0 File Offset: 0x000119E0
	public void OnInspectorGUI()
	{
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x000137E4 File Offset: 0x000119E4
	public bool ShouldSend()
	{
		if (this.ToggleMode == 0)
		{
			this.val = global::UnityEngine.Input.GetKey(this.TriggerKey);
		}
		else if (global::UnityEngine.Input.GetKeyDown(this.TriggerKey))
		{
			this.val = !this.val;
		}
		return this.val;
	}

	// Token: 0x040003E0 RID: 992
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	public global::UnityEngine.KeyCode TriggerKey;

	// Token: 0x040003E1 RID: 993
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	public int ToggleMode;

	// Token: 0x040003E2 RID: 994
	private bool val;
}
