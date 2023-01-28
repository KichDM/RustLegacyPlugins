using System;
using UnityEngine;

// Token: 0x020008F7 RID: 2295
[global::UnityEngine.AddComponentMenu("")]
public class UIGlobal : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004EA7 RID: 20135 RVA: 0x0012E8C4 File Offset: 0x0012CAC4
	public UIGlobal()
	{
	}

	// Token: 0x06004EA8 RID: 20136 RVA: 0x0012E8CC File Offset: 0x0012CACC
	public static void EnsureGlobal()
	{
		if (global::UnityEngine.Application.isPlaying && !global::UIGlobal.g)
		{
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("__UIGlobal", new global::System.Type[]
			{
				typeof(global::UIGlobal)
			});
			global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
			global::UIGlobal.g = gameObject.GetComponent<global::UIGlobal>();
		}
	}

	// Token: 0x06004EA9 RID: 20137 RVA: 0x0012E924 File Offset: 0x0012CB24
	private void LateUpdate()
	{
		global::UIWidget.GlobalUpdate();
		global::UIPanel.GlobalUpdate();
	}

	// Token: 0x04002B54 RID: 11092
	private static global::UIGlobal g;
}
