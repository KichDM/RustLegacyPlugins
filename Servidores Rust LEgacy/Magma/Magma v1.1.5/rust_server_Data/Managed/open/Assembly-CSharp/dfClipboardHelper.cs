using System;
using System.Reflection;
using UnityEngine;

// Token: 0x02000838 RID: 2104
public class dfClipboardHelper
{
	// Token: 0x0600483C RID: 18492 RVA: 0x0010CCE0 File Offset: 0x0010AEE0
	public dfClipboardHelper()
	{
	}

	// Token: 0x0600483D RID: 18493 RVA: 0x0010CCE8 File Offset: 0x0010AEE8
	// Note: this type is marked as 'beforefieldinit'.
	static dfClipboardHelper()
	{
	}

	// Token: 0x0600483E RID: 18494 RVA: 0x0010CCEC File Offset: 0x0010AEEC
	private static global::System.Reflection.PropertyInfo GetSystemCopyBufferProperty()
	{
		if (global::dfClipboardHelper.m_systemCopyBufferProperty == null)
		{
			global::System.Type typeFromHandle = typeof(global::UnityEngine.GUIUtility);
			global::dfClipboardHelper.m_systemCopyBufferProperty = typeFromHandle.GetProperty("systemCopyBuffer", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic);
			if (global::dfClipboardHelper.m_systemCopyBufferProperty == null)
			{
				throw new global::System.Exception("Can'time access internal member 'GUIUtility.systemCopyBuffer' it may have been removed / renamed");
			}
		}
		return global::dfClipboardHelper.m_systemCopyBufferProperty;
	}

	// Token: 0x17000D8C RID: 3468
	// (get) Token: 0x0600483F RID: 18495 RVA: 0x0010CD3C File Offset: 0x0010AF3C
	// (set) Token: 0x06004840 RID: 18496 RVA: 0x0010CD98 File Offset: 0x0010AF98
	public static string clipBoard
	{
		get
		{
			string result;
			try
			{
				global::System.Reflection.PropertyInfo systemCopyBufferProperty = global::dfClipboardHelper.GetSystemCopyBufferProperty();
				result = (string)systemCopyBufferProperty.GetValue(null, null);
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}
		set
		{
			try
			{
				global::System.Reflection.PropertyInfo systemCopyBufferProperty = global::dfClipboardHelper.GetSystemCopyBufferProperty();
				systemCopyBufferProperty.SetValue(null, value, null);
			}
			catch
			{
			}
		}
	}

	// Token: 0x040026C1 RID: 9921
	private static global::System.Reflection.PropertyInfo m_systemCopyBufferProperty;
}
