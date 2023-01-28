using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000767 RID: 1895
public class ServerQuitResponder : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003F0F RID: 16143 RVA: 0x000E0F38 File Offset: 0x000DF138
	public ServerQuitResponder()
	{
	}

	// Token: 0x06003F10 RID: 16144 RVA: 0x000E0F40 File Offset: 0x000DF140
	private void Awake()
	{
		global::ServerQuitResponder.singleton = this;
	}

	// Token: 0x06003F11 RID: 16145 RVA: 0x000E0F48 File Offset: 0x000DF148
	private void OnApplicationQuit()
	{
		this.didSaveQuit = true;
		string text = global::ServerQuitResponder.GenerateMapSave();
		if (!string.IsNullOrEmpty(text))
		{
			global::UnityEngine.Debug.Log("Saved " + text);
		}
	}

	// Token: 0x06003F12 RID: 16146 RVA: 0x000E0F80 File Offset: 0x000DF180
	private void OnDestroy()
	{
		if (global::ServerQuitResponder.singleton == this)
		{
			global::ServerQuitResponder.singleton = null;
		}
		if (!this.didSaveQuit)
		{
			global::UnityEngine.Debug.LogError("THE SERVER QUIT RESPONDER WAS DESTROYED BEFORE APPLICATION QUIT! SERVER SAVE WILL NOT BE SAVED!", this);
		}
	}

	// Token: 0x06003F13 RID: 16147 RVA: 0x000E0FBC File Offset: 0x000DF1BC
	[global::System.Diagnostics.Conditional("ALLOW_SQR")]
	public static void WillChangeLevels()
	{
		if (global::ServerQuitResponder.singleton && !global::ServerQuitResponder.singleton.didSaveQuit)
		{
			global::ServerQuitResponder.singleton.OnApplicationQuit();
		}
	}

	// Token: 0x06003F14 RID: 16148 RVA: 0x000E0FF4 File Offset: 0x000DF1F4
	private static string GenerateMapSave()
	{
		return null;
	}

	// Token: 0x04002075 RID: 8309
	private static global::ServerQuitResponder singleton;

	// Token: 0x04002076 RID: 8310
	[global::System.NonSerialized]
	private bool didSaveQuit;
}
