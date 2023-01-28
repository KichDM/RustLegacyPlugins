using System;
using NGUI.MessageUtil;
using UnityEngine;

// Token: 0x02000923 RID: 2339
public static class DropNotification
{
	// Token: 0x06004FC6 RID: 20422 RVA: 0x0013658C File Offset: 0x0013478C
	public static void StopDragging(global::UnityEngine.GameObject item)
	{
		if (global::DropNotification.inDrag == global::DragEventKind.None)
		{
			global::UnityEngine.Debug.LogError("StopDragging can only be called from within Drop or Land messages");
		}
		else if (item != global::DropNotification.scanItem)
		{
			global::UnityEngine.Debug.LogWarning("StopDragging was called with a invalid value, should have been the thing being dragged");
		}
		else
		{
			global::DropNotification.stopDrag = true;
		}
	}

	// Token: 0x06004FC7 RID: 20423 RVA: 0x001365D8 File Offset: 0x001347D8
	private static bool Message(global::UnityEngine.GameObject target, global::UnityEngine.GameObject parameter, string messageName, global::UnityEngine.GameObject scan, global::DragEventKind kind, ref bool drop)
	{
		if (target)
		{
			global::UnityEngine.GameObject gameObject = global::DropNotification.scanItem;
			bool flag = global::DropNotification.stopDrag;
			global::DragEventKind dragEventKind = global::DropNotification.inDrag;
			try
			{
				global::DropNotification.scanItem = scan;
				global::DropNotification.stopDrag = drop;
				global::DropNotification.inDrag = kind;
				target.NGUIMessage(messageName, parameter);
				drop = global::DropNotification.stopDrag;
				return true;
			}
			finally
			{
				global::DropNotification.scanItem = gameObject;
				global::DropNotification.stopDrag = flag;
				global::DropNotification.inDrag = dragEventKind;
			}
			return false;
		}
		return false;
	}

	// Token: 0x06004FC8 RID: 20424 RVA: 0x00136668 File Offset: 0x00134868
	private static bool Message(global::UnityEngine.GameObject target, string messageName, global::UnityEngine.GameObject scan, global::DragEventKind kind, ref bool drop)
	{
		if (target)
		{
			global::UnityEngine.GameObject gameObject = global::DropNotification.scanItem;
			bool flag = global::DropNotification.stopDrag;
			global::DragEventKind dragEventKind = global::DropNotification.inDrag;
			try
			{
				global::DropNotification.scanItem = scan;
				global::DropNotification.stopDrag = drop;
				global::DropNotification.inDrag = kind;
				target.NGUIMessage(messageName);
				drop = global::DropNotification.stopDrag;
				return true;
			}
			finally
			{
				global::DropNotification.scanItem = gameObject;
				global::DropNotification.stopDrag = flag;
				global::DropNotification.inDrag = dragEventKind;
			}
			return false;
		}
		return false;
	}

	// Token: 0x06004FC9 RID: 20425 RVA: 0x001366F4 File Offset: 0x001348F4
	internal static bool DropMessage(ref global::DropNotificationFlags flags, global::DragEventKind kind, global::UnityEngine.GameObject Pressed, global::UnityEngine.GameObject Released)
	{
		bool result;
		bool flag;
		global::DropNotificationFlags dropNotificationFlags;
		global::DropNotificationFlags dropNotificationFlags2;
		global::DropNotificationFlags dropNotificationFlags3;
		string messageName;
		string messageName2;
		switch (kind)
		{
		case global::DragEventKind.Drag:
			result = true;
			if (Released)
			{
				flag = true;
				dropNotificationFlags = global::DropNotificationFlags.DragDrop;
				dropNotificationFlags2 = global::DropNotificationFlags.DragLand;
				dropNotificationFlags3 = global::DropNotificationFlags.DragReverse;
				messageName = "OnDrop";
				messageName2 = "OnLand";
			}
			else
			{
				flag = false;
				dropNotificationFlags = (global::DropNotificationFlags)-0x80000000;
				dropNotificationFlags3 = global::DropNotificationFlags.DragLandOutside;
				dropNotificationFlags2 = global::DropNotificationFlags.DragLandOutside;
				messageName = "----";
				messageName2 = "OnLandOutside";
			}
			break;
		case global::DragEventKind.Alt:
			flag = true;
			result = false;
			dropNotificationFlags = global::DropNotificationFlags.AltDrop;
			dropNotificationFlags2 = global::DropNotificationFlags.AltLand;
			dropNotificationFlags3 = global::DropNotificationFlags.AltReverse;
			messageName = "OnAltDrop";
			messageName2 = "OnAltLand";
			break;
		case global::DragEventKind.Mid:
			flag = true;
			result = false;
			dropNotificationFlags = global::DropNotificationFlags.MidDrop;
			dropNotificationFlags2 = global::DropNotificationFlags.MidLand;
			dropNotificationFlags3 = global::DropNotificationFlags.MidReverse;
			messageName = "OnMidDrop";
			messageName2 = "OnMidLand";
			break;
		default:
			throw new global::System.ArgumentOutOfRangeException();
		}
		if ((flags & dropNotificationFlags3) == dropNotificationFlags3)
		{
			if ((flags & dropNotificationFlags2) == dropNotificationFlags2)
			{
				if (flag)
				{
					global::DropNotification.Message(Pressed, Released, messageName2, Pressed, kind, ref result);
				}
				else
				{
					global::DropNotification.Message(Pressed, messageName2, Pressed, kind, ref result);
				}
			}
			if ((flags & dropNotificationFlags) == dropNotificationFlags)
			{
				if (flag)
				{
					global::DropNotification.Message(Released, Pressed, messageName, Pressed, kind, ref result);
				}
				else
				{
					global::DropNotification.Message(Released, messageName, Pressed, kind, ref result);
				}
			}
		}
		else
		{
			if ((flags & dropNotificationFlags) == dropNotificationFlags)
			{
				if (flag)
				{
					global::DropNotification.Message(Released, Pressed, messageName, Pressed, kind, ref result);
				}
				else
				{
					global::DropNotification.Message(Released, messageName, Pressed, kind, ref result);
				}
			}
			if ((flags & dropNotificationFlags2) == dropNotificationFlags2)
			{
				if (flag)
				{
					global::DropNotification.Message(Pressed, Released, messageName2, Pressed, kind, ref result);
				}
				else
				{
					global::DropNotification.Message(Pressed, messageName2, Pressed, kind, ref result);
				}
			}
		}
		return result;
	}

	// Token: 0x04002C54 RID: 11348
	public const global::DropNotificationFlags DragDrop = global::DropNotificationFlags.DragDrop;

	// Token: 0x04002C55 RID: 11349
	public const global::DropNotificationFlags DragLand = global::DropNotificationFlags.DragLand;

	// Token: 0x04002C56 RID: 11350
	public const global::DropNotificationFlags kDragReverseBit = global::DropNotificationFlags.DragReverse;

	// Token: 0x04002C57 RID: 11351
	public const global::DropNotificationFlags AltDrop = global::DropNotificationFlags.AltDrop;

	// Token: 0x04002C58 RID: 11352
	public const global::DropNotificationFlags AltLand = global::DropNotificationFlags.AltLand;

	// Token: 0x04002C59 RID: 11353
	public const global::DropNotificationFlags kAltReverseBit = global::DropNotificationFlags.AltReverse;

	// Token: 0x04002C5A RID: 11354
	public const global::DropNotificationFlags MidDrop = global::DropNotificationFlags.MidDrop;

	// Token: 0x04002C5B RID: 11355
	public const global::DropNotificationFlags MidLand = global::DropNotificationFlags.MidLand;

	// Token: 0x04002C5C RID: 11356
	public const global::DropNotificationFlags kMidReverseBit = global::DropNotificationFlags.MidReverse;

	// Token: 0x04002C5D RID: 11357
	public const global::DropNotificationFlags DragLandOutside = global::DropNotificationFlags.DragLandOutside;

	// Token: 0x04002C5E RID: 11358
	private const global::DropNotificationFlags kInvalidNeverSet = (global::DropNotificationFlags)-0x80000000;

	// Token: 0x04002C5F RID: 11359
	public const global::DropNotificationFlags DragDropThenLand = global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand;

	// Token: 0x04002C60 RID: 11360
	public const global::DropNotificationFlags DragLandThenDrop = global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand | global::DropNotificationFlags.DragReverse;

	// Token: 0x04002C61 RID: 11361
	public const global::DropNotificationFlags AltDropThenLand = global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand;

	// Token: 0x04002C62 RID: 11362
	public const global::DropNotificationFlags AltLandThenDrop = global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.AltReverse;

	// Token: 0x04002C63 RID: 11363
	public const global::DropNotificationFlags MidDropThenLand = global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand;

	// Token: 0x04002C64 RID: 11364
	public const global::DropNotificationFlags MidLandThenDrop = global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand | global::DropNotificationFlags.MidReverse;

	// Token: 0x04002C65 RID: 11365
	public const global::DropNotificationFlags kDefault = global::DropNotificationFlags.DragDrop;

	// Token: 0x04002C66 RID: 11366
	public const global::DropNotificationFlags kMask_Drag = global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand | global::DropNotificationFlags.DragReverse;

	// Token: 0x04002C67 RID: 11367
	public const global::DropNotificationFlags kMask_Alt = global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.AltReverse;

	// Token: 0x04002C68 RID: 11368
	public const global::DropNotificationFlags kMask_Mid = global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand | global::DropNotificationFlags.MidReverse;

	// Token: 0x04002C69 RID: 11369
	public const global::DropNotificationFlags kMask_Active = global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand | global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand;

	// Token: 0x04002C6A RID: 11370
	public const global::DropNotificationFlags Disable = (global::DropNotificationFlags)0;

	// Token: 0x04002C6B RID: 11371
	private static global::UnityEngine.GameObject scanItem;

	// Token: 0x04002C6C RID: 11372
	private static bool stopDrag;

	// Token: 0x04002C6D RID: 11373
	private static global::DragEventKind inDrag;
}
