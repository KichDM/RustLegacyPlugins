using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008E4 RID: 2276
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Debug")]
public class NGUIDebug : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004DF9 RID: 19961 RVA: 0x0012B108 File Offset: 0x00129308
	public NGUIDebug()
	{
	}

	// Token: 0x06004DFA RID: 19962 RVA: 0x0012B110 File Offset: 0x00129310
	// Note: this type is marked as 'beforefieldinit'.
	static NGUIDebug()
	{
	}

	// Token: 0x06004DFB RID: 19963 RVA: 0x0012B124 File Offset: 0x00129324
	public static void Log(string text)
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			if (global::NGUIDebug.mLines.Count > 0x14)
			{
				global::NGUIDebug.mLines.RemoveAt(0);
			}
			global::NGUIDebug.mLines.Add(text);
			if (global::NGUIDebug.mInstance == null)
			{
				global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("_NGUI Debug");
				global::NGUIDebug.mInstance = gameObject.AddComponent<global::NGUIDebug>();
				global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
		}
		else
		{
			global::UnityEngine.Debug.Log(text);
		}
	}

	// Token: 0x06004DFC RID: 19964 RVA: 0x0012B19C File Offset: 0x0012939C
	public static void DrawBounds(global::UnityEngine.Bounds b)
	{
		global::UnityEngine.Vector3 center = b.center;
		global::UnityEngine.Vector3 vector = b.center - b.extents;
		global::UnityEngine.Vector3 vector2 = b.center + b.extents;
		global::UnityEngine.Debug.DrawLine(new global::UnityEngine.Vector3(vector.x, vector.y, center.z), new global::UnityEngine.Vector3(vector2.x, vector.y, center.z), global::UnityEngine.Color.red);
		global::UnityEngine.Debug.DrawLine(new global::UnityEngine.Vector3(vector.x, vector.y, center.z), new global::UnityEngine.Vector3(vector.x, vector2.y, center.z), global::UnityEngine.Color.red);
		global::UnityEngine.Debug.DrawLine(new global::UnityEngine.Vector3(vector2.x, vector.y, center.z), new global::UnityEngine.Vector3(vector2.x, vector2.y, center.z), global::UnityEngine.Color.red);
		global::UnityEngine.Debug.DrawLine(new global::UnityEngine.Vector3(vector.x, vector2.y, center.z), new global::UnityEngine.Vector3(vector2.x, vector2.y, center.z), global::UnityEngine.Color.red);
	}

	// Token: 0x06004DFD RID: 19965 RVA: 0x0012B2D4 File Offset: 0x001294D4
	private void OnGUI()
	{
		int i = 0;
		int count = global::NGUIDebug.mLines.Count;
		while (i < count)
		{
			global::UnityEngine.GUILayout.Label(global::NGUIDebug.mLines[i], new global::UnityEngine.GUILayoutOption[0]);
			i++;
		}
	}

	// Token: 0x04002B05 RID: 11013
	private static global::System.Collections.Generic.List<string> mLines = new global::System.Collections.Generic.List<string>();

	// Token: 0x04002B06 RID: 11014
	private static global::NGUIDebug mInstance = null;
}
