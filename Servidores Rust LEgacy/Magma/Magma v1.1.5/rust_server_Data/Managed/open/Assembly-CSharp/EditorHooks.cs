using System;
using System.Diagnostics;
using EditorHooksPrivate;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public static class EditorHooks
{
	// Token: 0x06002826 RID: 10278 RVA: 0x00099A08 File Offset: 0x00097C08
	static EditorHooks()
	{
		global::System.Type type = global::System.Type.GetType("EditorHooksEditor, Assembly-CSharp-Editor");
		try
		{
			if (type != null)
			{
				type.TypeInitializer.Invoke(null, null);
			}
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
		}
	}

	// Token: 0x06002827 RID: 10279 RVA: 0x00099A64 File Offset: 0x00097C64
	[global::System.Diagnostics.Conditional("UNITY_EDITOR")]
	public static void SetDirty(this global::UnityEngine.Object obj)
	{
		if (global::EditorHooksPrivate.Hooks._SetDirty != null)
		{
			global::EditorHooksPrivate.Hooks._SetDirty(obj);
		}
	}
}
