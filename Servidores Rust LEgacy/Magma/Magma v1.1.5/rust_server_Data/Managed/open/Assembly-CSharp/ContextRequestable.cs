using System;
using UnityEngine;

// Token: 0x02000588 RID: 1416
public static class ContextRequestable
{
	// Token: 0x06002F6B RID: 12139 RVA: 0x000B4E10 File Offset: 0x000B3010
	public static bool UseableForwardFromContext(global::IContextRequestable requestable, global::Controllable controllable, global::Useable useable)
	{
		global::UnityEngine.MonoBehaviour monoBehaviour = requestable as global::UnityEngine.MonoBehaviour;
		if (!useable)
		{
			useable = monoBehaviour.GetComponent<global::Useable>();
		}
		global::Character idMain = controllable.idMain;
		return idMain && useable && useable.EnterFromContext(idMain).Succeeded();
	}

	// Token: 0x06002F6C RID: 12140 RVA: 0x000B4E68 File Offset: 0x000B3068
	private static bool UseableForwardFromContext(global::IContextRequestable requestable, global::Controllable controllable)
	{
		return global::ContextRequestable.UseableForwardFromContext(requestable, controllable, null);
	}

	// Token: 0x06002F6D RID: 12141 RVA: 0x000B4E74 File Offset: 0x000B3074
	public static global::ContextResponse UseableForwardFromContextRespond(global::IContextRequestable requestable, global::Controllable controllable, global::Useable useable)
	{
		return (!global::ContextRequestable.UseableForwardFromContext(requestable, controllable, useable)) ? global::ContextResponse.FailBreak : global::ContextResponse.DoneBreak;
	}

	// Token: 0x06002F6E RID: 12142 RVA: 0x000B4E8C File Offset: 0x000B308C
	public static global::ContextResponse UseableForwardFromContextRespond(global::IContextRequestable requestable, global::Controllable controllable)
	{
		return (!global::ContextRequestable.UseableForwardFromContext(requestable, controllable, null)) ? global::ContextResponse.FailBreak : global::ContextResponse.DoneBreak;
	}

	// Token: 0x0400193D RID: 6461
	public const global::ContextExecution AllExecutionFlags = global::ContextExecution.Quick | global::ContextExecution.Menu;

	// Token: 0x02000589 RID: 1417
	public static class PointUtil
	{
		// Token: 0x06002F6F RID: 12143 RVA: 0x000B4EA4 File Offset: 0x000B30A4
		public static bool SpriteOrOrigin(global::UnityEngine.Component component, out global::UnityEngine.Vector3 worldPoint)
		{
			global::ContextSprite contextSprite;
			if (global::ContextSprite.FindSprite(component, out contextSprite))
			{
				worldPoint = contextSprite.transform.position;
				return true;
			}
			worldPoint = component.transform.position;
			return false;
		}
	}
}
