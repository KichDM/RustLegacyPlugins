using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x0200060E RID: 1550
public static class ServerHelper
{
	// Token: 0x0600316B RID: 12651 RVA: 0x000BD804 File Offset: 0x000BBA04
	[global::System.Diagnostics.Conditional("SERVER")]
	public static void SetupForServer(global::UnityEngine.GameObject obj)
	{
		foreach (global::UnityEngine.Renderer renderer in obj.GetComponentsInChildren<global::UnityEngine.Renderer>())
		{
			renderer.enabled = false;
		}
		foreach (global::UnityEngine.AudioSource audioSource in obj.GetComponentsInChildren<global::UnityEngine.AudioSource>())
		{
			global::UnityEngine.Object.Destroy(audioSource);
		}
		foreach (global::UnityEngine.ParticleSystem particleSystem in obj.GetComponentsInChildren<global::UnityEngine.ParticleSystem>())
		{
			global::UnityEngine.Object.Destroy(particleSystem);
		}
		foreach (global::UnityEngine.Animation animation in obj.GetComponentsInChildren<global::UnityEngine.Animation>())
		{
			global::UnityEngine.Object.Destroy(animation);
		}
	}
}
