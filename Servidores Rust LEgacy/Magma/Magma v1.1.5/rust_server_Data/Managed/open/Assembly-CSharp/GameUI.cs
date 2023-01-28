using System;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class GameUI : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C4D RID: 11341 RVA: 0x000A71FC File Offset: 0x000A53FC
	public GameUI()
	{
	}

	// Token: 0x06002C4E RID: 11342 RVA: 0x000A7204 File Offset: 0x000A5404
	private void Awake()
	{
		global::UnityEngine.Object.DontDestroyOnLoad(this);
		global::UnityEngine.Debug.Log("GameUI Loaded");
	}
}
