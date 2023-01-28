using System;
using UnityEngine;

// Token: 0x0200053D RID: 1341
public class RPOSPlaqueManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D8B RID: 11659 RVA: 0x000AD474 File Offset: 0x000AB674
	public RPOSPlaqueManager()
	{
	}

	// Token: 0x06002D8C RID: 11660 RVA: 0x000AD47C File Offset: 0x000AB67C
	public void Awake()
	{
		foreach (object obj in base.transform)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			transform.gameObject.SetActive(false);
		}
	}

	// Token: 0x06002D8D RID: 11661 RVA: 0x000AD4F0 File Offset: 0x000AB6F0
	public void SetPlaqueActive(string plaqueName, bool on)
	{
		global::UnityEngine.GameObject gameObject = null;
		foreach (object obj in base.transform)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == plaqueName)
			{
				gameObject = transform.gameObject;
			}
		}
		if (gameObject && gameObject.activeSelf != on)
		{
			gameObject.SetActive(on);
			float num = 21f;
			foreach (object obj2 in base.transform)
			{
				global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)obj2;
				if (transform2.gameObject.activeSelf)
				{
					transform2.SetLocalPositionY(num);
					num += 28f;
				}
			}
		}
	}

	// Token: 0x0400177F RID: 6015
	public global::UnityEngine.GameObject coldPlaque;

	// Token: 0x04001780 RID: 6016
	public global::UnityEngine.GameObject bleedingPlaque;
}
