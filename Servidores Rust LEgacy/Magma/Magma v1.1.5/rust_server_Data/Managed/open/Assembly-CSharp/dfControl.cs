using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x020007DC RID: 2012
[global::System.Serializable]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public abstract class dfControl : global::UnityEngine.MonoBehaviour, global::System.IComparable<global::dfControl>
{
	// Token: 0x060042B3 RID: 17075 RVA: 0x000F2C74 File Offset: 0x000F0E74
	protected dfControl()
	{
	}

	// Token: 0x060042B4 RID: 17076 RVA: 0x000F2D70 File Offset: 0x000F0F70
	// Note: this type is marked as 'beforefieldinit'.
	static dfControl()
	{
	}

	// Token: 0x14000022 RID: 34
	// (add) Token: 0x060042B5 RID: 17077 RVA: 0x000F2D74 File Offset: 0x000F0F74
	// (remove) Token: 0x060042B6 RID: 17078 RVA: 0x000F2D90 File Offset: 0x000F0F90
	[global::UnityEngine.HideInInspector]
	public event global::ChildControlEventHandler ControlAdded
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ControlAdded = (global::ChildControlEventHandler)global::System.Delegate.Combine(this.ControlAdded, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ControlAdded = (global::ChildControlEventHandler)global::System.Delegate.Remove(this.ControlAdded, value);
		}
	}

	// Token: 0x14000023 RID: 35
	// (add) Token: 0x060042B7 RID: 17079 RVA: 0x000F2DAC File Offset: 0x000F0FAC
	// (remove) Token: 0x060042B8 RID: 17080 RVA: 0x000F2DC8 File Offset: 0x000F0FC8
	[global::UnityEngine.HideInInspector]
	public event global::ChildControlEventHandler ControlRemoved
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ControlRemoved = (global::ChildControlEventHandler)global::System.Delegate.Combine(this.ControlRemoved, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ControlRemoved = (global::ChildControlEventHandler)global::System.Delegate.Remove(this.ControlRemoved, value);
		}
	}

	// Token: 0x14000024 RID: 36
	// (add) Token: 0x060042B9 RID: 17081 RVA: 0x000F2DE4 File Offset: 0x000F0FE4
	// (remove) Token: 0x060042BA RID: 17082 RVA: 0x000F2E00 File Offset: 0x000F1000
	public event global::FocusEventHandler GotFocus
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.GotFocus = (global::FocusEventHandler)global::System.Delegate.Combine(this.GotFocus, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.GotFocus = (global::FocusEventHandler)global::System.Delegate.Remove(this.GotFocus, value);
		}
	}

	// Token: 0x14000025 RID: 37
	// (add) Token: 0x060042BB RID: 17083 RVA: 0x000F2E1C File Offset: 0x000F101C
	// (remove) Token: 0x060042BC RID: 17084 RVA: 0x000F2E38 File Offset: 0x000F1038
	public event global::FocusEventHandler EnterFocus
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.EnterFocus = (global::FocusEventHandler)global::System.Delegate.Combine(this.EnterFocus, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.EnterFocus = (global::FocusEventHandler)global::System.Delegate.Remove(this.EnterFocus, value);
		}
	}

	// Token: 0x14000026 RID: 38
	// (add) Token: 0x060042BD RID: 17085 RVA: 0x000F2E54 File Offset: 0x000F1054
	// (remove) Token: 0x060042BE RID: 17086 RVA: 0x000F2E70 File Offset: 0x000F1070
	public event global::FocusEventHandler LostFocus
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.LostFocus = (global::FocusEventHandler)global::System.Delegate.Combine(this.LostFocus, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.LostFocus = (global::FocusEventHandler)global::System.Delegate.Remove(this.LostFocus, value);
		}
	}

	// Token: 0x14000027 RID: 39
	// (add) Token: 0x060042BF RID: 17087 RVA: 0x000F2E8C File Offset: 0x000F108C
	// (remove) Token: 0x060042C0 RID: 17088 RVA: 0x000F2EA8 File Offset: 0x000F10A8
	public event global::FocusEventHandler LeaveFocus
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.LeaveFocus = (global::FocusEventHandler)global::System.Delegate.Combine(this.LeaveFocus, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.LeaveFocus = (global::FocusEventHandler)global::System.Delegate.Remove(this.LeaveFocus, value);
		}
	}

	// Token: 0x14000028 RID: 40
	// (add) Token: 0x060042C1 RID: 17089 RVA: 0x000F2EC4 File Offset: 0x000F10C4
	// (remove) Token: 0x060042C2 RID: 17090 RVA: 0x000F2EE0 File Offset: 0x000F10E0
	public event global::PropertyChangedEventHandler<int> TabIndexChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TabIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Combine(this.TabIndexChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TabIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Remove(this.TabIndexChanged, value);
		}
	}

	// Token: 0x14000029 RID: 41
	// (add) Token: 0x060042C3 RID: 17091 RVA: 0x000F2EFC File Offset: 0x000F10FC
	// (remove) Token: 0x060042C4 RID: 17092 RVA: 0x000F2F18 File Offset: 0x000F1118
	public event global::PropertyChangedEventHandler<global::UnityEngine.Vector2> PositionChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.PositionChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Combine(this.PositionChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.PositionChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Remove(this.PositionChanged, value);
		}
	}

	// Token: 0x1400002A RID: 42
	// (add) Token: 0x060042C5 RID: 17093 RVA: 0x000F2F34 File Offset: 0x000F1134
	// (remove) Token: 0x060042C6 RID: 17094 RVA: 0x000F2F50 File Offset: 0x000F1150
	public event global::PropertyChangedEventHandler<global::UnityEngine.Vector2> SizeChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.SizeChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Combine(this.SizeChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.SizeChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Remove(this.SizeChanged, value);
		}
	}

	// Token: 0x1400002B RID: 43
	// (add) Token: 0x060042C7 RID: 17095 RVA: 0x000F2F6C File Offset: 0x000F116C
	// (remove) Token: 0x060042C8 RID: 17096 RVA: 0x000F2F88 File Offset: 0x000F1188
	[global::UnityEngine.HideInInspector]
	public event global::PropertyChangedEventHandler<global::UnityEngine.Color32> ColorChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ColorChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Color32>)global::System.Delegate.Combine(this.ColorChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ColorChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Color32>)global::System.Delegate.Remove(this.ColorChanged, value);
		}
	}

	// Token: 0x1400002C RID: 44
	// (add) Token: 0x060042C9 RID: 17097 RVA: 0x000F2FA4 File Offset: 0x000F11A4
	// (remove) Token: 0x060042CA RID: 17098 RVA: 0x000F2FC0 File Offset: 0x000F11C0
	public event global::PropertyChangedEventHandler<bool> IsVisibleChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.IsVisibleChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Combine(this.IsVisibleChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.IsVisibleChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Remove(this.IsVisibleChanged, value);
		}
	}

	// Token: 0x1400002D RID: 45
	// (add) Token: 0x060042CB RID: 17099 RVA: 0x000F2FDC File Offset: 0x000F11DC
	// (remove) Token: 0x060042CC RID: 17100 RVA: 0x000F2FF8 File Offset: 0x000F11F8
	public event global::PropertyChangedEventHandler<bool> IsEnabledChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.IsEnabledChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Combine(this.IsEnabledChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.IsEnabledChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Remove(this.IsEnabledChanged, value);
		}
	}

	// Token: 0x1400002E RID: 46
	// (add) Token: 0x060042CD RID: 17101 RVA: 0x000F3014 File Offset: 0x000F1214
	// (remove) Token: 0x060042CE RID: 17102 RVA: 0x000F3030 File Offset: 0x000F1230
	[global::UnityEngine.HideInInspector]
	public event global::PropertyChangedEventHandler<float> OpacityChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.OpacityChanged = (global::PropertyChangedEventHandler<float>)global::System.Delegate.Combine(this.OpacityChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.OpacityChanged = (global::PropertyChangedEventHandler<float>)global::System.Delegate.Remove(this.OpacityChanged, value);
		}
	}

	// Token: 0x1400002F RID: 47
	// (add) Token: 0x060042CF RID: 17103 RVA: 0x000F304C File Offset: 0x000F124C
	// (remove) Token: 0x060042D0 RID: 17104 RVA: 0x000F3068 File Offset: 0x000F1268
	[global::UnityEngine.HideInInspector]
	public event global::PropertyChangedEventHandler<global::dfAnchorStyle> AnchorChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnchorChanged = (global::PropertyChangedEventHandler<global::dfAnchorStyle>)global::System.Delegate.Combine(this.AnchorChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnchorChanged = (global::PropertyChangedEventHandler<global::dfAnchorStyle>)global::System.Delegate.Remove(this.AnchorChanged, value);
		}
	}

	// Token: 0x14000030 RID: 48
	// (add) Token: 0x060042D1 RID: 17105 RVA: 0x000F3084 File Offset: 0x000F1284
	// (remove) Token: 0x060042D2 RID: 17106 RVA: 0x000F30A0 File Offset: 0x000F12A0
	[global::UnityEngine.HideInInspector]
	public event global::PropertyChangedEventHandler<global::dfPivotPoint> PivotChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.PivotChanged = (global::PropertyChangedEventHandler<global::dfPivotPoint>)global::System.Delegate.Combine(this.PivotChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.PivotChanged = (global::PropertyChangedEventHandler<global::dfPivotPoint>)global::System.Delegate.Remove(this.PivotChanged, value);
		}
	}

	// Token: 0x14000031 RID: 49
	// (add) Token: 0x060042D3 RID: 17107 RVA: 0x000F30BC File Offset: 0x000F12BC
	// (remove) Token: 0x060042D4 RID: 17108 RVA: 0x000F30D8 File Offset: 0x000F12D8
	[global::UnityEngine.HideInInspector]
	public event global::PropertyChangedEventHandler<int> ZOrderChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ZOrderChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Combine(this.ZOrderChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ZOrderChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Remove(this.ZOrderChanged, value);
		}
	}

	// Token: 0x14000032 RID: 50
	// (add) Token: 0x060042D5 RID: 17109 RVA: 0x000F30F4 File Offset: 0x000F12F4
	// (remove) Token: 0x060042D6 RID: 17110 RVA: 0x000F3110 File Offset: 0x000F1310
	public event global::DragEventHandler DragStart
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DragStart = (global::DragEventHandler)global::System.Delegate.Combine(this.DragStart, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DragStart = (global::DragEventHandler)global::System.Delegate.Remove(this.DragStart, value);
		}
	}

	// Token: 0x14000033 RID: 51
	// (add) Token: 0x060042D7 RID: 17111 RVA: 0x000F312C File Offset: 0x000F132C
	// (remove) Token: 0x060042D8 RID: 17112 RVA: 0x000F3148 File Offset: 0x000F1348
	public event global::DragEventHandler DragEnd
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DragEnd = (global::DragEventHandler)global::System.Delegate.Combine(this.DragEnd, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DragEnd = (global::DragEventHandler)global::System.Delegate.Remove(this.DragEnd, value);
		}
	}

	// Token: 0x14000034 RID: 52
	// (add) Token: 0x060042D9 RID: 17113 RVA: 0x000F3164 File Offset: 0x000F1364
	// (remove) Token: 0x060042DA RID: 17114 RVA: 0x000F3180 File Offset: 0x000F1380
	public event global::DragEventHandler DragDrop
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DragDrop = (global::DragEventHandler)global::System.Delegate.Combine(this.DragDrop, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DragDrop = (global::DragEventHandler)global::System.Delegate.Remove(this.DragDrop, value);
		}
	}

	// Token: 0x14000035 RID: 53
	// (add) Token: 0x060042DB RID: 17115 RVA: 0x000F319C File Offset: 0x000F139C
	// (remove) Token: 0x060042DC RID: 17116 RVA: 0x000F31B8 File Offset: 0x000F13B8
	public event global::DragEventHandler DragEnter
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DragEnter = (global::DragEventHandler)global::System.Delegate.Combine(this.DragEnter, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DragEnter = (global::DragEventHandler)global::System.Delegate.Remove(this.DragEnter, value);
		}
	}

	// Token: 0x14000036 RID: 54
	// (add) Token: 0x060042DD RID: 17117 RVA: 0x000F31D4 File Offset: 0x000F13D4
	// (remove) Token: 0x060042DE RID: 17118 RVA: 0x000F31F0 File Offset: 0x000F13F0
	public event global::DragEventHandler DragLeave
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DragLeave = (global::DragEventHandler)global::System.Delegate.Combine(this.DragLeave, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DragLeave = (global::DragEventHandler)global::System.Delegate.Remove(this.DragLeave, value);
		}
	}

	// Token: 0x14000037 RID: 55
	// (add) Token: 0x060042DF RID: 17119 RVA: 0x000F320C File Offset: 0x000F140C
	// (remove) Token: 0x060042E0 RID: 17120 RVA: 0x000F3228 File Offset: 0x000F1428
	public event global::DragEventHandler DragOver
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DragOver = (global::DragEventHandler)global::System.Delegate.Combine(this.DragOver, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DragOver = (global::DragEventHandler)global::System.Delegate.Remove(this.DragOver, value);
		}
	}

	// Token: 0x14000038 RID: 56
	// (add) Token: 0x060042E1 RID: 17121 RVA: 0x000F3244 File Offset: 0x000F1444
	// (remove) Token: 0x060042E2 RID: 17122 RVA: 0x000F3260 File Offset: 0x000F1460
	public event global::KeyPressHandler KeyPress
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.KeyPress = (global::KeyPressHandler)global::System.Delegate.Combine(this.KeyPress, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.KeyPress = (global::KeyPressHandler)global::System.Delegate.Remove(this.KeyPress, value);
		}
	}

	// Token: 0x14000039 RID: 57
	// (add) Token: 0x060042E3 RID: 17123 RVA: 0x000F327C File Offset: 0x000F147C
	// (remove) Token: 0x060042E4 RID: 17124 RVA: 0x000F3298 File Offset: 0x000F1498
	public event global::KeyPressHandler KeyDown
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.KeyDown = (global::KeyPressHandler)global::System.Delegate.Combine(this.KeyDown, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.KeyDown = (global::KeyPressHandler)global::System.Delegate.Remove(this.KeyDown, value);
		}
	}

	// Token: 0x1400003A RID: 58
	// (add) Token: 0x060042E5 RID: 17125 RVA: 0x000F32B4 File Offset: 0x000F14B4
	// (remove) Token: 0x060042E6 RID: 17126 RVA: 0x000F32D0 File Offset: 0x000F14D0
	public event global::KeyPressHandler KeyUp
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.KeyUp = (global::KeyPressHandler)global::System.Delegate.Combine(this.KeyUp, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.KeyUp = (global::KeyPressHandler)global::System.Delegate.Remove(this.KeyUp, value);
		}
	}

	// Token: 0x1400003B RID: 59
	// (add) Token: 0x060042E7 RID: 17127 RVA: 0x000F32EC File Offset: 0x000F14EC
	// (remove) Token: 0x060042E8 RID: 17128 RVA: 0x000F3308 File Offset: 0x000F1508
	public event global::ControlMultiTouchEventHandler MultiTouch
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MultiTouch = (global::ControlMultiTouchEventHandler)global::System.Delegate.Combine(this.MultiTouch, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MultiTouch = (global::ControlMultiTouchEventHandler)global::System.Delegate.Remove(this.MultiTouch, value);
		}
	}

	// Token: 0x1400003C RID: 60
	// (add) Token: 0x060042E9 RID: 17129 RVA: 0x000F3324 File Offset: 0x000F1524
	// (remove) Token: 0x060042EA RID: 17130 RVA: 0x000F3340 File Offset: 0x000F1540
	public event global::MouseEventHandler MouseEnter
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseEnter = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseEnter, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseEnter = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseEnter, value);
		}
	}

	// Token: 0x1400003D RID: 61
	// (add) Token: 0x060042EB RID: 17131 RVA: 0x000F335C File Offset: 0x000F155C
	// (remove) Token: 0x060042EC RID: 17132 RVA: 0x000F3378 File Offset: 0x000F1578
	public event global::MouseEventHandler MouseMove
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseMove = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseMove, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseMove = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseMove, value);
		}
	}

	// Token: 0x1400003E RID: 62
	// (add) Token: 0x060042ED RID: 17133 RVA: 0x000F3394 File Offset: 0x000F1594
	// (remove) Token: 0x060042EE RID: 17134 RVA: 0x000F33B0 File Offset: 0x000F15B0
	public event global::MouseEventHandler MouseHover
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseHover = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseHover, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseHover = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseHover, value);
		}
	}

	// Token: 0x1400003F RID: 63
	// (add) Token: 0x060042EF RID: 17135 RVA: 0x000F33CC File Offset: 0x000F15CC
	// (remove) Token: 0x060042F0 RID: 17136 RVA: 0x000F33E8 File Offset: 0x000F15E8
	public event global::MouseEventHandler MouseLeave
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseLeave = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseLeave, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseLeave = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseLeave, value);
		}
	}

	// Token: 0x14000040 RID: 64
	// (add) Token: 0x060042F1 RID: 17137 RVA: 0x000F3404 File Offset: 0x000F1604
	// (remove) Token: 0x060042F2 RID: 17138 RVA: 0x000F3420 File Offset: 0x000F1620
	public event global::MouseEventHandler MouseDown
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseDown = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseDown, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseDown = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseDown, value);
		}
	}

	// Token: 0x14000041 RID: 65
	// (add) Token: 0x060042F3 RID: 17139 RVA: 0x000F343C File Offset: 0x000F163C
	// (remove) Token: 0x060042F4 RID: 17140 RVA: 0x000F3458 File Offset: 0x000F1658
	public event global::MouseEventHandler MouseUp
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseUp = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseUp, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseUp = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseUp, value);
		}
	}

	// Token: 0x14000042 RID: 66
	// (add) Token: 0x060042F5 RID: 17141 RVA: 0x000F3474 File Offset: 0x000F1674
	// (remove) Token: 0x060042F6 RID: 17142 RVA: 0x000F3490 File Offset: 0x000F1690
	public event global::MouseEventHandler MouseWheel
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.MouseWheel = (global::MouseEventHandler)global::System.Delegate.Combine(this.MouseWheel, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.MouseWheel = (global::MouseEventHandler)global::System.Delegate.Remove(this.MouseWheel, value);
		}
	}

	// Token: 0x14000043 RID: 67
	// (add) Token: 0x060042F7 RID: 17143 RVA: 0x000F34AC File Offset: 0x000F16AC
	// (remove) Token: 0x060042F8 RID: 17144 RVA: 0x000F34C8 File Offset: 0x000F16C8
	public event global::MouseEventHandler Click
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.Click = (global::MouseEventHandler)global::System.Delegate.Combine(this.Click, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.Click = (global::MouseEventHandler)global::System.Delegate.Remove(this.Click, value);
		}
	}

	// Token: 0x14000044 RID: 68
	// (add) Token: 0x060042F9 RID: 17145 RVA: 0x000F34E4 File Offset: 0x000F16E4
	// (remove) Token: 0x060042FA RID: 17146 RVA: 0x000F3500 File Offset: 0x000F1700
	public event global::MouseEventHandler DoubleClick
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DoubleClick = (global::MouseEventHandler)global::System.Delegate.Combine(this.DoubleClick, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DoubleClick = (global::MouseEventHandler)global::System.Delegate.Remove(this.DoubleClick, value);
		}
	}

	// Token: 0x17000C4C RID: 3148
	// (get) Token: 0x060042FB RID: 17147 RVA: 0x000F351C File Offset: 0x000F171C
	public global::dfGUIManager GUIManager
	{
		get
		{
			return this.GetManager();
		}
	}

	// Token: 0x17000C4D RID: 3149
	// (get) Token: 0x060042FC RID: 17148 RVA: 0x000F3524 File Offset: 0x000F1724
	// (set) Token: 0x060042FD RID: 17149 RVA: 0x000F3598 File Offset: 0x000F1798
	public bool IsEnabled
	{
		get
		{
			return base.enabled && (!(base.gameObject != null) || base.gameObject.activeSelf) && ((!(this.parent != null)) ? this.isEnabled : (this.isEnabled && this.parent.IsEnabled));
		}
		set
		{
			if (value != this.isEnabled)
			{
				this.isEnabled = value;
				this.OnIsEnabledChanged();
			}
		}
	}

	// Token: 0x17000C4E RID: 3150
	// (get) Token: 0x060042FE RID: 17150 RVA: 0x000F35B4 File Offset: 0x000F17B4
	// (set) Token: 0x060042FF RID: 17151 RVA: 0x000F35EC File Offset: 0x000F17EC
	[global::UnityEngine.SerializeField]
	public bool IsVisible
	{
		get
		{
			return (!(this.parent == null)) ? (this.isVisible && this.parent.IsVisible) : this.isVisible;
		}
		set
		{
			if (value != this.isVisible)
			{
				if (global::UnityEngine.Application.isPlaying && !this.IsInteractive)
				{
					base.collider.enabled = false;
				}
				else
				{
					base.collider.enabled = value;
				}
				this.isVisible = value;
				this.OnIsVisibleChanged();
			}
		}
	}

	// Token: 0x17000C4F RID: 3151
	// (get) Token: 0x06004300 RID: 17152 RVA: 0x000F3644 File Offset: 0x000F1844
	// (set) Token: 0x06004301 RID: 17153 RVA: 0x000F364C File Offset: 0x000F184C
	public virtual bool IsInteractive
	{
		get
		{
			return this.isInteractive;
		}
		set
		{
			if (this.HasFocus && !value)
			{
				global::dfGUIManager.SetFocus(null);
			}
			this.isInteractive = value;
		}
	}

	// Token: 0x17000C50 RID: 3152
	// (get) Token: 0x06004302 RID: 17154 RVA: 0x000F366C File Offset: 0x000F186C
	// (set) Token: 0x06004303 RID: 17155 RVA: 0x000F3674 File Offset: 0x000F1874
	[global::UnityEngine.SerializeField]
	public string Tooltip
	{
		get
		{
			return this.tooltip;
		}
		set
		{
			if (value != this.tooltip)
			{
				this.tooltip = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C51 RID: 3153
	// (get) Token: 0x06004304 RID: 17156 RVA: 0x000F3694 File Offset: 0x000F1894
	// (set) Token: 0x06004305 RID: 17157 RVA: 0x000F36A8 File Offset: 0x000F18A8
	[global::UnityEngine.SerializeField]
	public global::dfAnchorStyle Anchor
	{
		get
		{
			this.ensureLayoutExists();
			return this.layout.AnchorStyle;
		}
		set
		{
			this.ensureLayoutExists();
			if (value != this.layout.AnchorStyle)
			{
				this.layout.AnchorStyle = value;
				this.Invalidate();
				this.OnAnchorChanged();
			}
		}
	}

	// Token: 0x17000C52 RID: 3154
	// (get) Token: 0x06004306 RID: 17158 RVA: 0x000F36E4 File Offset: 0x000F18E4
	// (set) Token: 0x06004307 RID: 17159 RVA: 0x000F36F8 File Offset: 0x000F18F8
	public float Opacity
	{
		get
		{
			return (float)this.color.a / 255f;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0f, global::UnityEngine.Mathf.Min(1f, value));
			float num = (float)this.color.a / 255f;
			if (value != num)
			{
				this.color.a = (byte)(value * 255f);
				this.OnOpacityChanged();
			}
		}
	}

	// Token: 0x17000C53 RID: 3155
	// (get) Token: 0x06004308 RID: 17160 RVA: 0x000F3750 File Offset: 0x000F1950
	// (set) Token: 0x06004309 RID: 17161 RVA: 0x000F3758 File Offset: 0x000F1958
	public global::UnityEngine.Color32 Color
	{
		get
		{
			return this.color;
		}
		set
		{
			if (!this.color.Equals(value))
			{
				this.color = value;
				this.OnColorChanged();
			}
		}
	}

	// Token: 0x17000C54 RID: 3156
	// (get) Token: 0x0600430A RID: 17162 RVA: 0x000F3790 File Offset: 0x000F1990
	// (set) Token: 0x0600430B RID: 17163 RVA: 0x000F3798 File Offset: 0x000F1998
	public global::UnityEngine.Color32 DisabledColor
	{
		get
		{
			return this.disabledColor;
		}
		set
		{
			if (!value.Equals(this.disabledColor))
			{
				this.disabledColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C55 RID: 3157
	// (get) Token: 0x0600430C RID: 17164 RVA: 0x000F37D0 File Offset: 0x000F19D0
	// (set) Token: 0x0600430D RID: 17165 RVA: 0x000F37D8 File Offset: 0x000F19D8
	public global::dfPivotPoint Pivot
	{
		get
		{
			return this.pivot;
		}
		set
		{
			if (value != this.pivot)
			{
				global::UnityEngine.Vector3 position = this.Position;
				this.pivot = value;
				global::UnityEngine.Vector3 vector = this.Position - position;
				this.SuspendLayout();
				this.Position = position;
				for (int i = 0; i < this.controls.Count; i++)
				{
					this.controls[i].Position += vector;
				}
				this.ResumeLayout();
				this.OnPivotChanged();
			}
		}
	}

	// Token: 0x17000C56 RID: 3158
	// (get) Token: 0x0600430E RID: 17166 RVA: 0x000F3860 File Offset: 0x000F1A60
	// (set) Token: 0x0600430F RID: 17167 RVA: 0x000F3868 File Offset: 0x000F1A68
	public global::UnityEngine.Vector3 RelativePosition
	{
		get
		{
			return this.getRelativePosition();
		}
		set
		{
			this.setRelativePosition(value);
		}
	}

	// Token: 0x17000C57 RID: 3159
	// (get) Token: 0x06004310 RID: 17168 RVA: 0x000F3874 File Offset: 0x000F1A74
	// (set) Token: 0x06004311 RID: 17169 RVA: 0x000F38B0 File Offset: 0x000F1AB0
	public global::UnityEngine.Vector3 Position
	{
		get
		{
			global::UnityEngine.Vector3 vector = base.transform.localPosition / this.PixelsToUnits();
			return vector + this.pivot.TransformToUpperLeft(this.Size);
		}
		set
		{
			this.setPositionInternal(value);
		}
	}

	// Token: 0x17000C58 RID: 3160
	// (get) Token: 0x06004312 RID: 17170 RVA: 0x000F38BC File Offset: 0x000F1ABC
	// (set) Token: 0x06004313 RID: 17171 RVA: 0x000F38C4 File Offset: 0x000F1AC4
	public global::UnityEngine.Vector2 Size
	{
		get
		{
			return this.size;
		}
		set
		{
			value = global::UnityEngine.Vector2.Max(this.CalculateMinimumSize(), value);
			value.x = ((this.maxSize.x <= 0f) ? value.x : global::UnityEngine.Mathf.Min(value.x, this.maxSize.x));
			value.y = ((this.maxSize.y <= 0f) ? value.y : global::UnityEngine.Mathf.Min(value.y, this.maxSize.y));
			if ((value - this.size).sqrMagnitude <= 1E-45f)
			{
				return;
			}
			this.size = value;
			this.OnSizeChanged();
		}
	}

	// Token: 0x17000C59 RID: 3161
	// (get) Token: 0x06004314 RID: 17172 RVA: 0x000F398C File Offset: 0x000F1B8C
	// (set) Token: 0x06004315 RID: 17173 RVA: 0x000F399C File Offset: 0x000F1B9C
	public float Width
	{
		get
		{
			return this.size.x;
		}
		set
		{
			this.Size = new global::UnityEngine.Vector2(value, this.size.y);
		}
	}

	// Token: 0x17000C5A RID: 3162
	// (get) Token: 0x06004316 RID: 17174 RVA: 0x000F39B8 File Offset: 0x000F1BB8
	// (set) Token: 0x06004317 RID: 17175 RVA: 0x000F39C8 File Offset: 0x000F1BC8
	public float Height
	{
		get
		{
			return this.size.y;
		}
		set
		{
			this.Size = new global::UnityEngine.Vector2(this.size.x, value);
		}
	}

	// Token: 0x17000C5B RID: 3163
	// (get) Token: 0x06004318 RID: 17176 RVA: 0x000F39E4 File Offset: 0x000F1BE4
	// (set) Token: 0x06004319 RID: 17177 RVA: 0x000F39EC File Offset: 0x000F1BEC
	public global::UnityEngine.Vector2 MinimumSize
	{
		get
		{
			return this.minSize;
		}
		set
		{
			value = global::UnityEngine.Vector2.Max(global::UnityEngine.Vector2.zero, value.RoundToInt());
			if (value != this.minSize)
			{
				this.minSize = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C5C RID: 3164
	// (get) Token: 0x0600431A RID: 17178 RVA: 0x000F3A2C File Offset: 0x000F1C2C
	// (set) Token: 0x0600431B RID: 17179 RVA: 0x000F3A34 File Offset: 0x000F1C34
	public global::UnityEngine.Vector2 MaximumSize
	{
		get
		{
			return this.maxSize;
		}
		set
		{
			value = global::UnityEngine.Vector2.Max(global::UnityEngine.Vector2.zero, value.RoundToInt());
			if (value != this.maxSize)
			{
				this.maxSize = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C5D RID: 3165
	// (get) Token: 0x0600431C RID: 17180 RVA: 0x000F3A74 File Offset: 0x000F1C74
	// (set) Token: 0x0600431D RID: 17181 RVA: 0x000F3A7C File Offset: 0x000F1C7C
	[global::UnityEngine.HideInInspector]
	public int ZOrder
	{
		get
		{
			return this.zindex;
		}
		set
		{
			if (value != this.zindex)
			{
				this.zindex = global::UnityEngine.Mathf.Max(-1, value);
				this.Invalidate();
				if (this.parent != null)
				{
					this.parent.SetControlIndex(this, value);
				}
				this.OnZOrderChanged();
			}
		}
	}

	// Token: 0x17000C5E RID: 3166
	// (get) Token: 0x0600431E RID: 17182 RVA: 0x000F3ACC File Offset: 0x000F1CCC
	// (set) Token: 0x0600431F RID: 17183 RVA: 0x000F3AD4 File Offset: 0x000F1CD4
	[global::UnityEngine.HideInInspector]
	public int TabIndex
	{
		get
		{
			return this.tabIndex;
		}
		set
		{
			if (value != this.tabIndex)
			{
				this.tabIndex = global::UnityEngine.Mathf.Max(-1, value);
				this.OnTabIndexChanged();
			}
		}
	}

	// Token: 0x17000C5F RID: 3167
	// (get) Token: 0x06004320 RID: 17184 RVA: 0x000F3AF8 File Offset: 0x000F1CF8
	public global::System.Collections.Generic.IList<global::dfControl> Controls
	{
		get
		{
			return this.controls;
		}
	}

	// Token: 0x17000C60 RID: 3168
	// (get) Token: 0x06004321 RID: 17185 RVA: 0x000F3B00 File Offset: 0x000F1D00
	public global::dfControl Parent
	{
		get
		{
			return this.parent;
		}
	}

	// Token: 0x17000C61 RID: 3169
	// (get) Token: 0x06004322 RID: 17186 RVA: 0x000F3B08 File Offset: 0x000F1D08
	// (set) Token: 0x06004323 RID: 17187 RVA: 0x000F3B10 File Offset: 0x000F1D10
	public bool ClipChildren
	{
		get
		{
			return this.clipChildren;
		}
		set
		{
			if (value != this.clipChildren)
			{
				this.clipChildren = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C62 RID: 3170
	// (get) Token: 0x06004324 RID: 17188 RVA: 0x000F3B2C File Offset: 0x000F1D2C
	protected bool IsLayoutSuspended
	{
		get
		{
			return this.performingLayout || (this.layout != null && this.layout.IsLayoutSuspended);
		}
	}

	// Token: 0x17000C63 RID: 3171
	// (get) Token: 0x06004325 RID: 17189 RVA: 0x000F3B58 File Offset: 0x000F1D58
	protected bool IsPerformingLayout
	{
		get
		{
			return this.performingLayout || (this.layout != null && this.layout.IsPerformingLayout);
		}
	}

	// Token: 0x17000C64 RID: 3172
	// (get) Token: 0x06004326 RID: 17190 RVA: 0x000F3B88 File Offset: 0x000F1D88
	// (set) Token: 0x06004327 RID: 17191 RVA: 0x000F3B90 File Offset: 0x000F1D90
	public object Tag
	{
		get
		{
			return this.tag;
		}
		set
		{
			this.tag = value;
		}
	}

	// Token: 0x17000C65 RID: 3173
	// (get) Token: 0x06004328 RID: 17192 RVA: 0x000F3B9C File Offset: 0x000F1D9C
	internal uint Version
	{
		get
		{
			return this.version;
		}
	}

	// Token: 0x17000C66 RID: 3174
	// (get) Token: 0x06004329 RID: 17193 RVA: 0x000F3BA4 File Offset: 0x000F1DA4
	// (set) Token: 0x0600432A RID: 17194 RVA: 0x000F3BAC File Offset: 0x000F1DAC
	public bool IsLocalized
	{
		get
		{
			return this.isLocalized;
		}
		set
		{
			this.isLocalized = value;
			if (value)
			{
				this.Localize();
			}
		}
	}

	// Token: 0x17000C67 RID: 3175
	// (get) Token: 0x0600432B RID: 17195 RVA: 0x000F3BC4 File Offset: 0x000F1DC4
	// (set) Token: 0x0600432C RID: 17196 RVA: 0x000F3BCC File Offset: 0x000F1DCC
	public global::UnityEngine.Vector2 HotZoneScale
	{
		get
		{
			return this.hotZoneScale;
		}
		set
		{
			this.hotZoneScale = global::UnityEngine.Vector2.Max(value, global::UnityEngine.Vector2.zero);
			this.Invalidate();
		}
	}

	// Token: 0x17000C68 RID: 3176
	// (get) Token: 0x0600432D RID: 17197 RVA: 0x000F3BE8 File Offset: 0x000F1DE8
	// (set) Token: 0x0600432E RID: 17198 RVA: 0x000F3C00 File Offset: 0x000F1E00
	public virtual bool CanFocus
	{
		get
		{
			return this.canFocus && this.IsInteractive;
		}
		set
		{
			this.canFocus = value;
		}
	}

	// Token: 0x17000C69 RID: 3177
	// (get) Token: 0x0600432F RID: 17199 RVA: 0x000F3C0C File Offset: 0x000F1E0C
	public virtual bool ContainsFocus
	{
		get
		{
			return global::dfGUIManager.ContainsFocus(this);
		}
	}

	// Token: 0x17000C6A RID: 3178
	// (get) Token: 0x06004330 RID: 17200 RVA: 0x000F3C14 File Offset: 0x000F1E14
	public virtual bool HasFocus
	{
		get
		{
			return global::dfGUIManager.HasFocus(this);
		}
	}

	// Token: 0x17000C6B RID: 3179
	// (get) Token: 0x06004331 RID: 17201 RVA: 0x000F3C1C File Offset: 0x000F1E1C
	public bool ContainsMouse
	{
		get
		{
			return this.isMouseHovering;
		}
	}

	// Token: 0x06004332 RID: 17202 RVA: 0x000F3C24 File Offset: 0x000F1E24
	internal void setRenderOrder(ref int order)
	{
		this.renderOrder = ++order;
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].setRenderOrder(ref order);
		}
	}

	// Token: 0x17000C6C RID: 3180
	// (get) Token: 0x06004333 RID: 17203 RVA: 0x000F3C70 File Offset: 0x000F1E70
	[global::UnityEngine.HideInInspector]
	public int RenderOrder
	{
		get
		{
			return this.renderOrder;
		}
	}

	// Token: 0x06004334 RID: 17204 RVA: 0x000F3C78 File Offset: 0x000F1E78
	internal virtual void OnDragStart(global::dfDragEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDragStart", new object[]
			{
				args
			});
			if (!args.Used && this.DragStart != null)
			{
				this.DragStart(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDragStart(args);
		}
	}

	// Token: 0x06004335 RID: 17205 RVA: 0x000F3CE8 File Offset: 0x000F1EE8
	internal virtual void OnDragEnd(global::dfDragEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDragEnd", new object[]
			{
				args
			});
			if (!args.Used && this.DragEnd != null)
			{
				this.DragEnd(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDragEnd(args);
		}
	}

	// Token: 0x06004336 RID: 17206 RVA: 0x000F3D58 File Offset: 0x000F1F58
	internal virtual void OnDragDrop(global::dfDragEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDragDrop", new object[]
			{
				args
			});
			if (!args.Used && this.DragDrop != null)
			{
				this.DragDrop(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDragDrop(args);
		}
	}

	// Token: 0x06004337 RID: 17207 RVA: 0x000F3DC8 File Offset: 0x000F1FC8
	internal virtual void OnDragEnter(global::dfDragEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDragEnter", new object[]
			{
				args
			});
			if (!args.Used && this.DragEnter != null)
			{
				this.DragEnter(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDragEnter(args);
		}
	}

	// Token: 0x06004338 RID: 17208 RVA: 0x000F3E38 File Offset: 0x000F2038
	internal virtual void OnDragLeave(global::dfDragEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDragLeave", new object[]
			{
				args
			});
			if (!args.Used && this.DragLeave != null)
			{
				this.DragLeave(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDragLeave(args);
		}
	}

	// Token: 0x06004339 RID: 17209 RVA: 0x000F3EA8 File Offset: 0x000F20A8
	internal virtual void OnDragOver(global::dfDragEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDragOver", new object[]
			{
				args
			});
			if (!args.Used && this.DragOver != null)
			{
				this.DragOver(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDragOver(args);
		}
	}

	// Token: 0x0600433A RID: 17210 RVA: 0x000F3F18 File Offset: 0x000F2118
	protected internal virtual void OnMultiTouch(global::dfTouchEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnMultiTouch", new object[]
			{
				args
			});
			if (this.MultiTouch != null)
			{
				this.MultiTouch(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMultiTouch(args);
		}
	}

	// Token: 0x0600433B RID: 17211 RVA: 0x000F3F7C File Offset: 0x000F217C
	protected internal virtual void OnMouseEnter(global::dfMouseEventArgs args)
	{
		this.isMouseHovering = true;
		if (!args.Used)
		{
			this.Signal("OnMouseEnter", new object[]
			{
				args
			});
			if (this.MouseEnter != null)
			{
				this.MouseEnter(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseEnter(args);
		}
	}

	// Token: 0x0600433C RID: 17212 RVA: 0x000F3FE8 File Offset: 0x000F21E8
	protected internal virtual void OnMouseLeave(global::dfMouseEventArgs args)
	{
		this.isMouseHovering = false;
		if (!args.Used)
		{
			this.Signal("OnMouseLeave", new object[]
			{
				args
			});
			if (this.MouseLeave != null)
			{
				this.MouseLeave(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseLeave(args);
		}
	}

	// Token: 0x0600433D RID: 17213 RVA: 0x000F4054 File Offset: 0x000F2254
	protected internal virtual void OnMouseMove(global::dfMouseEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnMouseMove", new object[]
			{
				args
			});
			if (this.MouseMove != null)
			{
				this.MouseMove(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseMove(args);
		}
	}

	// Token: 0x0600433E RID: 17214 RVA: 0x000F40B8 File Offset: 0x000F22B8
	protected internal virtual void OnMouseHover(global::dfMouseEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnMouseHover", new object[]
			{
				args
			});
			if (this.MouseHover != null)
			{
				this.MouseHover(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseHover(args);
		}
	}

	// Token: 0x0600433F RID: 17215 RVA: 0x000F411C File Offset: 0x000F231C
	protected internal virtual void OnMouseWheel(global::dfMouseEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnMouseWheel", new object[]
			{
				args
			});
			if (this.MouseWheel != null)
			{
				this.MouseWheel(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseWheel(args);
		}
	}

	// Token: 0x06004340 RID: 17216 RVA: 0x000F4180 File Offset: 0x000F2380
	protected internal virtual void OnMouseDown(global::dfMouseEventArgs args)
	{
		bool flag = this.Opacity > 0.01f && this.IsVisible && this.IsEnabled && this.CanFocus && !this.ContainsFocus;
		if (flag)
		{
			this.Focus();
		}
		if (!args.Used)
		{
			this.Signal("OnMouseDown", new object[]
			{
				args
			});
			if (this.MouseDown != null)
			{
				this.MouseDown(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseDown(args);
		}
	}

	// Token: 0x06004341 RID: 17217 RVA: 0x000F4230 File Offset: 0x000F2430
	protected internal virtual void OnMouseUp(global::dfMouseEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnMouseUp", new object[]
			{
				args
			});
			if (this.MouseUp != null)
			{
				this.MouseUp(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnMouseUp(args);
		}
	}

	// Token: 0x06004342 RID: 17218 RVA: 0x000F4294 File Offset: 0x000F2494
	protected internal virtual void OnClick(global::dfMouseEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnClick", new object[]
			{
				args
			});
			if (this.Click != null)
			{
				this.Click(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnClick(args);
		}
	}

	// Token: 0x06004343 RID: 17219 RVA: 0x000F42F8 File Offset: 0x000F24F8
	protected internal virtual void OnDoubleClick(global::dfMouseEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnDoubleClick", new object[]
			{
				args
			});
			if (this.DoubleClick != null)
			{
				this.DoubleClick(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnDoubleClick(args);
		}
	}

	// Token: 0x06004344 RID: 17220 RVA: 0x000F435C File Offset: 0x000F255C
	protected internal virtual void OnKeyPress(global::dfKeyEventArgs args)
	{
		if (this.IsInteractive && !args.Used)
		{
			this.Signal("OnKeyPress", new object[]
			{
				args
			});
			if (this.KeyPress != null)
			{
				this.KeyPress(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnKeyPress(args);
		}
	}

	// Token: 0x06004345 RID: 17221 RVA: 0x000F43CC File Offset: 0x000F25CC
	protected internal virtual void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (this.IsInteractive && !args.Used)
		{
			if (args.KeyCode == 9)
			{
				this.OnTabKeyPressed(args);
			}
			if (!args.Used)
			{
				this.Signal("OnKeyDown", new object[]
				{
					args
				});
				if (this.KeyDown != null)
				{
					this.KeyDown(this, args);
				}
			}
		}
		if (this.parent != null)
		{
			this.parent.OnKeyDown(args);
		}
	}

	// Token: 0x06004346 RID: 17222 RVA: 0x000F445C File Offset: 0x000F265C
	protected virtual void OnTabKeyPressed(global::dfKeyEventArgs args)
	{
		global::System.Collections.Generic.List<global::dfControl> list = (from c in this.GetManager().GetComponentsInChildren<global::dfControl>()
		where c != this && c.TabIndex >= 0 && c.IsInteractive && c.CanFocus && c.IsVisible
		select c).ToList<global::dfControl>();
		if (list.Count == 0)
		{
			return;
		}
		list.Sort(delegate(global::dfControl lhs, global::dfControl rhs)
		{
			if (lhs.TabIndex == rhs.TabIndex)
			{
				return lhs.RenderOrder.CompareTo(rhs.RenderOrder);
			}
			return lhs.TabIndex.CompareTo(rhs.TabIndex);
		});
		if (!args.Shift)
		{
			for (int i = 0; i < list.Count; i++)
			{
				global::dfControl dfControl = list[i];
				if (dfControl.TabIndex >= this.TabIndex)
				{
					list[i].Focus();
					args.Use();
					return;
				}
			}
			list[0].Focus();
			args.Use();
			return;
		}
		for (int j = list.Count - 1; j >= 0; j--)
		{
			global::dfControl dfControl2 = list[j];
			if (dfControl2.TabIndex <= this.TabIndex)
			{
				list[j].Focus();
				args.Use();
				return;
			}
		}
		list[list.Count - 1].Focus();
		args.Use();
	}

	// Token: 0x06004347 RID: 17223 RVA: 0x000F457C File Offset: 0x000F277C
	protected internal virtual void OnKeyUp(global::dfKeyEventArgs args)
	{
		if (this.IsInteractive)
		{
			this.Signal("OnKeyUp", new object[]
			{
				args
			});
			if (this.KeyUp != null)
			{
				this.KeyUp(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnKeyUp(args);
		}
	}

	// Token: 0x06004348 RID: 17224 RVA: 0x000F45E0 File Offset: 0x000F27E0
	protected internal virtual void OnEnterFocus(global::dfFocusEventArgs args)
	{
		this.Signal("OnEnterFocus", new object[]
		{
			args
		});
		if (this.EnterFocus != null)
		{
			this.EnterFocus(this, args);
		}
	}

	// Token: 0x06004349 RID: 17225 RVA: 0x000F461C File Offset: 0x000F281C
	protected internal virtual void OnLeaveFocus(global::dfFocusEventArgs args)
	{
		this.Signal("OnLeaveFocus", new object[]
		{
			args
		});
		if (this.LeaveFocus != null)
		{
			this.LeaveFocus(this, args);
		}
	}

	// Token: 0x0600434A RID: 17226 RVA: 0x000F4658 File Offset: 0x000F2858
	protected internal virtual void OnGotFocus(global::dfFocusEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnGotFocus", new object[]
			{
				args
			});
			if (this.GotFocus != null)
			{
				this.GotFocus(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnGotFocus(args);
		}
	}

	// Token: 0x0600434B RID: 17227 RVA: 0x000F46BC File Offset: 0x000F28BC
	protected internal virtual void OnLostFocus(global::dfFocusEventArgs args)
	{
		if (!args.Used)
		{
			this.Signal("OnLostFocus", new object[]
			{
				args
			});
			if (this.LostFocus != null)
			{
				this.LostFocus(this, args);
			}
		}
		if (this.parent != null)
		{
			this.parent.OnLostFocus(args);
		}
	}

	// Token: 0x0600434C RID: 17228 RVA: 0x000F4720 File Offset: 0x000F2920
	[global::UnityEngine.HideInInspector]
	protected internal void RaiseEvent(string eventName, params object[] args)
	{
		global::System.Reflection.FieldInfo fieldInfo = (from f in base.GetType().GetAllFields()
		where f.Name == eventName
		select f).FirstOrDefault<global::System.Reflection.FieldInfo>();
		if (fieldInfo != null)
		{
			object value = fieldInfo.GetValue(this);
			if (value != null)
			{
				((global::System.Delegate)value).DynamicInvoke(args);
			}
		}
	}

	// Token: 0x0600434D RID: 17229 RVA: 0x000F4780 File Offset: 0x000F2980
	protected internal bool Signal(string eventName, params object[] args)
	{
		return this.Signal(base.gameObject, eventName, args);
	}

	// Token: 0x0600434E RID: 17230 RVA: 0x000F4790 File Offset: 0x000F2990
	protected internal bool SignalHierarchy(string eventName, params object[] args)
	{
		bool flag = false;
		global::UnityEngine.Transform transform = base.transform;
		while (!flag && transform != null)
		{
			flag = this.Signal(transform.gameObject, eventName, args);
			transform = transform.parent;
		}
		return flag;
	}

	// Token: 0x0600434F RID: 17231 RVA: 0x000F47D4 File Offset: 0x000F29D4
	[global::UnityEngine.HideInInspector]
	protected internal bool Signal(global::UnityEngine.GameObject target, string eventName, params object[] args)
	{
		global::UnityEngine.Component[] components = target.GetComponents(typeof(global::UnityEngine.MonoBehaviour));
		if (components == null || (target == base.gameObject && components.Length == 1))
		{
			return false;
		}
		if (args.Length == 0 || !object.ReferenceEquals(args[0], this))
		{
			object[] array = new object[args.Length + 1];
			global::System.Array.Copy(args, 0, array, 1, args.Length);
			array[0] = this;
			args = array;
		}
		global::System.Type[] array2 = new global::System.Type[args.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			if (args[i] == null)
			{
				array2[i] = typeof(object);
			}
			else
			{
				array2[i] = args[i].GetType();
			}
		}
		bool result = false;
		foreach (global::UnityEngine.Component component in components)
		{
			if (!(component == null) && component.GetType() != null)
			{
				if (!(component is global::UnityEngine.MonoBehaviour) || ((global::UnityEngine.MonoBehaviour)component).enabled)
				{
					if (!(component == this))
					{
						global::System.Reflection.MethodInfo method = component.GetType().GetMethod(eventName, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic, null, array2, null);
						if (method != null)
						{
							global::System.Collections.IEnumerator enumerator = method.Invoke(component, args) as global::System.Collections.IEnumerator;
							if (enumerator != null)
							{
								((global::UnityEngine.MonoBehaviour)component).StartCoroutine(enumerator);
							}
							result = true;
						}
						else if (args.Length != 0)
						{
							global::System.Reflection.MethodInfo method2 = component.GetType().GetMethod(eventName, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic, null, global::System.Type.EmptyTypes, null);
							if (method2 != null)
							{
								global::System.Collections.IEnumerator enumerator = method2.Invoke(component, null) as global::System.Collections.IEnumerator;
								if (enumerator != null)
								{
									((global::UnityEngine.MonoBehaviour)component).StartCoroutine(enumerator);
								}
								result = true;
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06004350 RID: 17232 RVA: 0x000F49A4 File Offset: 0x000F2BA4
	internal bool GetIsVisibleRaw()
	{
		return this.isVisible;
	}

	// Token: 0x06004351 RID: 17233 RVA: 0x000F49AC File Offset: 0x000F2BAC
	public void Localize()
	{
		if (!this.IsLocalized)
		{
			return;
		}
		if (this.languageManager == null)
		{
			this.languageManager = this.GetManager().GetComponent<global::dfLanguageManager>();
			if (this.languageManager == null)
			{
				return;
			}
		}
		this.OnLocalize();
	}

	// Token: 0x06004352 RID: 17234 RVA: 0x000F4A00 File Offset: 0x000F2C00
	public void DoClick()
	{
		global::UnityEngine.Camera camera = this.GetCamera();
		global::UnityEngine.Vector3 vector = camera.WorldToScreenPoint(this.GetCenter());
		global::UnityEngine.Ray ray = camera.ScreenPointToRay(vector);
		this.OnClick(new global::dfMouseEventArgs(this, global::dfMouseButtons.Left, 1, ray, vector, 0f));
	}

	// Token: 0x06004353 RID: 17235 RVA: 0x000F4A44 File Offset: 0x000F2C44
	[global::UnityEngine.HideInInspector]
	protected internal void RemoveEventHandlers(string EventName)
	{
		global::System.Reflection.FieldInfo fieldInfo = (from f in base.GetType().GetAllFields()
		where typeof(global::System.Delegate).IsAssignableFrom(f.FieldType) && f.Name == EventName
		select f).FirstOrDefault<global::System.Reflection.FieldInfo>();
		if (fieldInfo != null)
		{
			fieldInfo.SetValue(this, null);
		}
	}

	// Token: 0x06004354 RID: 17236 RVA: 0x000F4A90 File Offset: 0x000F2C90
	[global::UnityEngine.HideInInspector]
	internal void RemoveAllEventHandlers()
	{
		global::System.Reflection.FieldInfo[] array = (from f in base.GetType().GetAllFields()
		where typeof(global::System.Delegate).IsAssignableFrom(f.FieldType)
		select f).ToArray<global::System.Reflection.FieldInfo>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetValue(this, null);
		}
	}

	// Token: 0x06004355 RID: 17237 RVA: 0x000F4AF0 File Offset: 0x000F2CF0
	public void Show()
	{
		this.IsVisible = true;
	}

	// Token: 0x06004356 RID: 17238 RVA: 0x000F4AFC File Offset: 0x000F2CFC
	public void Hide()
	{
		this.IsVisible = false;
	}

	// Token: 0x06004357 RID: 17239 RVA: 0x000F4B08 File Offset: 0x000F2D08
	public void Enable()
	{
		this.IsEnabled = true;
	}

	// Token: 0x06004358 RID: 17240 RVA: 0x000F4B14 File Offset: 0x000F2D14
	public void Disable()
	{
		this.IsEnabled = false;
	}

	// Token: 0x06004359 RID: 17241 RVA: 0x000F4B20 File Offset: 0x000F2D20
	public bool GetHitPosition(global::UnityEngine.Ray ray, out global::UnityEngine.Vector2 position)
	{
		position = global::UnityEngine.Vector2.one * float.MinValue;
		global::UnityEngine.Plane plane;
		plane..ctor(base.transform.TransformDirection(global::UnityEngine.Vector3.back), base.transform.position);
		float num = 0f;
		if (!plane.Raycast(ray, ref num))
		{
			return false;
		}
		global::UnityEngine.Vector3 vector = ray.origin + ray.direction * num;
		global::UnityEngine.Plane[] array = (!this.ClipChildren) ? null : this.GetClippingPlanes();
		if (array != null && array.Length > 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].GetSide(vector))
				{
					return false;
				}
			}
		}
		global::UnityEngine.Vector3[] corners = this.GetCorners();
		global::UnityEngine.Vector3 vector2 = corners[0];
		global::UnityEngine.Vector3 vector3 = corners[1];
		global::UnityEngine.Vector3 vector4 = corners[2];
		global::UnityEngine.Vector3 vector5 = global::dfControl.closestPointOnLine(vector2, vector3, vector, true);
		float num2 = (vector5 - vector2).magnitude / (vector3 - vector2).magnitude;
		float num3 = this.size.x * num2;
		vector5 = global::dfControl.closestPointOnLine(vector2, vector4, vector, true);
		num2 = (vector5 - vector2).magnitude / (vector4 - vector2).magnitude;
		float num4 = this.size.y * num2;
		position..ctor(num3, num4);
		return true;
	}

	// Token: 0x0600435A RID: 17242 RVA: 0x000F4CB4 File Offset: 0x000F2EB4
	public T Find<T>(string Name) where T : global::dfControl
	{
		if (base.name == Name && this is T)
		{
			return (T)((object)this);
		}
		this.updateControlHierarchy(true);
		for (int i = 0; i < this.controls.Count; i++)
		{
			T t = this.controls[i] as T;
			if (t != null && t.name == Name)
			{
				return t;
			}
		}
		for (int j = 0; j < this.controls.Count; j++)
		{
			T t2 = this.controls[j].Find<T>(Name);
			if (t2 != null)
			{
				return t2;
			}
		}
		return (T)((object)null);
	}

	// Token: 0x0600435B RID: 17243 RVA: 0x000F4D94 File Offset: 0x000F2F94
	public global::dfControl Find(string Name)
	{
		if (base.name == Name)
		{
			return this;
		}
		this.updateControlHierarchy(true);
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfControl dfControl = this.controls[i];
			if (dfControl.name == Name)
			{
				return dfControl;
			}
		}
		for (int j = 0; j < this.controls.Count; j++)
		{
			global::dfControl dfControl2 = this.controls[j].Find(Name);
			if (dfControl2 != null)
			{
				return dfControl2;
			}
		}
		return null;
	}

	// Token: 0x0600435C RID: 17244 RVA: 0x000F4E38 File Offset: 0x000F3038
	public void Focus()
	{
		if (!this.CanFocus || this.HasFocus || !this.IsEnabled || !this.IsVisible)
		{
			return;
		}
		global::dfGUIManager.SetFocus(this);
		this.Invalidate();
	}

	// Token: 0x0600435D RID: 17245 RVA: 0x000F4E80 File Offset: 0x000F3080
	public void Unfocus()
	{
		if (this.ContainsFocus)
		{
			global::dfGUIManager.SetFocus(null);
		}
	}

	// Token: 0x0600435E RID: 17246 RVA: 0x000F4E94 File Offset: 0x000F3094
	public global::dfControl GetRootContainer()
	{
		global::dfControl dfControl = this;
		while (dfControl.Parent != null)
		{
			dfControl = dfControl.Parent;
		}
		return dfControl;
	}

	// Token: 0x0600435F RID: 17247 RVA: 0x000F4EC4 File Offset: 0x000F30C4
	public virtual void BringToFront()
	{
		if (this.parent == null)
		{
			this.GetManager().BringToFront(this);
		}
		else
		{
			this.parent.SetControlIndex(this, this.parent.controls.Count - 1);
		}
		this.Invalidate();
	}

	// Token: 0x06004360 RID: 17248 RVA: 0x000F4F18 File Offset: 0x000F3118
	public virtual void SendToBack()
	{
		if (this.parent == null)
		{
			this.GetManager().SendToBack(this);
		}
		else
		{
			this.parent.SetControlIndex(this, 0);
		}
		this.Invalidate();
	}

	// Token: 0x06004361 RID: 17249 RVA: 0x000F4F5C File Offset: 0x000F315C
	internal global::dfRenderData Render()
	{
		if (this.rendering)
		{
			return this.renderData;
		}
		global::dfRenderData result;
		try
		{
			this.rendering = true;
			bool flag = this.isVisible;
			bool flag2 = base.enabled && base.gameObject.activeSelf;
			if (!flag || !flag2)
			{
				result = null;
			}
			else
			{
				if (this.renderData == null)
				{
					this.renderData = global::dfRenderData.Obtain();
					this.isControlInvalidated = true;
				}
				if (this.isControlInvalidated)
				{
					this.renderData.Clear();
					this.OnRebuildRenderData();
					this.updateCollider();
				}
				this.renderData.Transform = base.transform.localToWorldMatrix;
				result = this.renderData;
			}
		}
		finally
		{
			this.rendering = false;
			this.isControlInvalidated = false;
		}
		return result;
	}

	// Token: 0x06004362 RID: 17250 RVA: 0x000F5048 File Offset: 0x000F3248
	public virtual void Invalidate()
	{
		this.updateVersion();
		this.isControlInvalidated = true;
		global::dfGUIManager dfGUIManager = this.GetManager();
		if (dfGUIManager != null)
		{
			dfGUIManager.Invalidate();
		}
	}

	// Token: 0x06004363 RID: 17251 RVA: 0x000F507C File Offset: 0x000F327C
	[global::UnityEngine.HideInInspector]
	public virtual void ResetLayout(bool recursive = false, bool force = false)
	{
		bool flag = this.IsPerformingLayout || this.IsLayoutSuspended;
		if (!force && flag)
		{
			return;
		}
		this.ensureLayoutExists();
		this.layout.Attach(this);
		this.layout.Reset(force);
		if (recursive)
		{
			for (int i = 0; i < this.Controls.Count; i++)
			{
				this.controls[i].ResetLayout(false, false);
			}
		}
	}

	// Token: 0x06004364 RID: 17252 RVA: 0x000F5100 File Offset: 0x000F3300
	[global::UnityEngine.HideInInspector]
	public virtual void PerformLayout()
	{
		if (this.isDisposing || this.performingLayout)
		{
			return;
		}
		try
		{
			this.performingLayout = true;
			this.ensureLayoutExists();
			this.layout.PerformLayout();
			this.Invalidate();
		}
		finally
		{
			this.performingLayout = false;
		}
	}

	// Token: 0x06004365 RID: 17253 RVA: 0x000F516C File Offset: 0x000F336C
	[global::UnityEngine.HideInInspector]
	public virtual void SuspendLayout()
	{
		this.ensureLayoutExists();
		this.layout.SuspendLayout();
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].SuspendLayout();
		}
	}

	// Token: 0x06004366 RID: 17254 RVA: 0x000F51B8 File Offset: 0x000F33B8
	[global::UnityEngine.HideInInspector]
	public virtual void ResumeLayout()
	{
		this.ensureLayoutExists();
		this.layout.ResumeLayout();
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].ResumeLayout();
		}
	}

	// Token: 0x06004367 RID: 17255 RVA: 0x000F5204 File Offset: 0x000F3404
	public virtual global::UnityEngine.Vector2 CalculateMinimumSize()
	{
		return this.MinimumSize;
	}

	// Token: 0x06004368 RID: 17256 RVA: 0x000F520C File Offset: 0x000F340C
	[global::UnityEngine.HideInInspector]
	public void MakePixelPerfect(bool recursive = true)
	{
		this.size = this.size.RoundToInt();
		float num = this.PixelsToUnits();
		base.transform.position = (base.transform.position / num).RoundToInt() * num;
		this.cachedPosition = base.transform.localPosition;
		int num2 = 0;
		while (num2 < this.controls.Count && recursive)
		{
			this.controls[num2].MakePixelPerfect(true);
			num2++;
		}
		this.Invalidate();
	}

	// Token: 0x06004369 RID: 17257 RVA: 0x000F52A4 File Offset: 0x000F34A4
	public global::UnityEngine.Bounds GetBounds()
	{
		global::UnityEngine.Vector3[] corners = this.GetCorners();
		global::UnityEngine.Vector3 vector = corners[0] + (corners[3] - corners[0]) * 0.5f;
		global::UnityEngine.Vector3 vector2 = vector;
		global::UnityEngine.Vector3 vector3 = vector;
		for (int i = 0; i < corners.Length; i++)
		{
			vector2 = global::UnityEngine.Vector3.Min(vector2, corners[i]);
			vector3 = global::UnityEngine.Vector3.Max(vector3, corners[i]);
		}
		return new global::UnityEngine.Bounds(vector, vector3 - vector2);
	}

	// Token: 0x0600436A RID: 17258 RVA: 0x000F5344 File Offset: 0x000F3544
	public global::UnityEngine.Vector3 GetCenter()
	{
		return base.transform.position + this.Pivot.TransformToCenter(this.Size) * this.PixelsToUnits();
	}

	// Token: 0x0600436B RID: 17259 RVA: 0x000F5380 File Offset: 0x000F3580
	public global::UnityEngine.Vector3[] GetCorners()
	{
		float num = this.PixelsToUnits();
		global::UnityEngine.Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(this.size);
		global::UnityEngine.Vector3 vector2 = vector + new global::UnityEngine.Vector3(this.size.x, 0f);
		global::UnityEngine.Vector3 vector3 = vector + new global::UnityEngine.Vector3(0f, -this.size.y);
		global::UnityEngine.Vector3 vector4 = vector2 + new global::UnityEngine.Vector3(0f, -this.size.y);
		this.cachedCorners[0] = localToWorldMatrix.MultiplyPoint(vector * num);
		this.cachedCorners[1] = localToWorldMatrix.MultiplyPoint(vector2 * num);
		this.cachedCorners[2] = localToWorldMatrix.MultiplyPoint(vector3 * num);
		this.cachedCorners[3] = localToWorldMatrix.MultiplyPoint(vector4 * num);
		return this.cachedCorners;
	}

	// Token: 0x0600436C RID: 17260 RVA: 0x000F5490 File Offset: 0x000F3690
	public global::UnityEngine.Camera GetCamera()
	{
		global::dfGUIManager dfGUIManager = this.GetManager();
		if (dfGUIManager == null)
		{
			global::UnityEngine.Debug.LogError("The Manager hosting this control could not be determined");
			return null;
		}
		return dfGUIManager.RenderCamera;
	}

	// Token: 0x0600436D RID: 17261 RVA: 0x000F54C4 File Offset: 0x000F36C4
	public global::UnityEngine.Rect GetScreenRect()
	{
		global::UnityEngine.Camera camera = this.GetCamera();
		global::UnityEngine.Vector3[] corners = this.GetCorners();
		global::UnityEngine.Vector3 vector = camera.WorldToScreenPoint(corners[0]);
		global::UnityEngine.Vector3 vector2 = camera.WorldToScreenPoint(corners[3]);
		return new global::UnityEngine.Rect(vector.x, (float)global::UnityEngine.Screen.height - vector.y, vector2.x - vector.x, vector.y - vector2.y);
	}

	// Token: 0x0600436E RID: 17262 RVA: 0x000F5540 File Offset: 0x000F3740
	public global::dfGUIManager GetManager()
	{
		if (this.manager != null || !base.gameObject.activeInHierarchy)
		{
			return this.manager;
		}
		if (this.parent != null && this.parent.manager != null)
		{
			return this.manager = this.parent.manager;
		}
		global::UnityEngine.GameObject gameObject = base.gameObject;
		while (gameObject != null)
		{
			global::dfGUIManager component = gameObject.GetComponent<global::dfGUIManager>();
			if (component != null)
			{
				return this.manager = component;
			}
			if (gameObject.transform.parent == null)
			{
				break;
			}
			gameObject = gameObject.transform.parent.gameObject;
		}
		global::dfGUIManager dfGUIManager = global::UnityEngine.Object.FindObjectsOfType(typeof(global::dfGUIManager)).FirstOrDefault<global::UnityEngine.Object>() as global::dfGUIManager;
		if (dfGUIManager != null)
		{
			return this.manager = dfGUIManager;
		}
		return null;
	}

	// Token: 0x0600436F RID: 17263 RVA: 0x000F5648 File Offset: 0x000F3848
	protected internal float PixelsToUnits()
	{
		if (this.cachedPixelSize > 1E-45f)
		{
			return this.cachedPixelSize;
		}
		global::dfGUIManager dfGUIManager = this.GetManager();
		if (dfGUIManager == null)
		{
			return 0.0026f;
		}
		return this.cachedPixelSize = dfGUIManager.PixelsToUnits();
	}

	// Token: 0x06004370 RID: 17264 RVA: 0x000F5694 File Offset: 0x000F3894
	protected internal virtual global::UnityEngine.Plane[] GetClippingPlanes()
	{
		global::UnityEngine.Vector3[] corners = this.GetCorners();
		global::UnityEngine.Vector3 vector = base.transform.TransformDirection(global::UnityEngine.Vector3.right);
		global::UnityEngine.Vector3 vector2 = base.transform.TransformDirection(global::UnityEngine.Vector3.left);
		global::UnityEngine.Vector3 vector3 = base.transform.TransformDirection(global::UnityEngine.Vector3.up);
		global::UnityEngine.Vector3 vector4 = base.transform.TransformDirection(global::UnityEngine.Vector3.down);
		this.cachedClippingPlanes[0] = new global::UnityEngine.Plane(vector, corners[0]);
		this.cachedClippingPlanes[1] = new global::UnityEngine.Plane(vector2, corners[1]);
		this.cachedClippingPlanes[2] = new global::UnityEngine.Plane(vector3, corners[2]);
		this.cachedClippingPlanes[3] = new global::UnityEngine.Plane(vector4, corners[0]);
		return this.cachedClippingPlanes;
	}

	// Token: 0x06004371 RID: 17265 RVA: 0x000F5780 File Offset: 0x000F3980
	public bool Contains(global::dfControl child)
	{
		return child != null && child.transform.IsChildOf(base.transform);
	}

	// Token: 0x06004372 RID: 17266 RVA: 0x000F57B0 File Offset: 0x000F39B0
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnLocalize()
	{
	}

	// Token: 0x06004373 RID: 17267 RVA: 0x000F57B4 File Offset: 0x000F39B4
	[global::UnityEngine.HideInInspector]
	protected internal string getLocalizedValue(string key)
	{
		if (!this.IsLocalized || !global::UnityEngine.Application.isPlaying)
		{
			return key;
		}
		if (this.languageManager == null)
		{
			if (this.languageManagerChecked)
			{
				return key;
			}
			this.languageManagerChecked = true;
			this.languageManager = this.GetManager().GetComponent<global::dfLanguageManager>();
			if (this.languageManager == null)
			{
				return key;
			}
		}
		return this.languageManager.GetValue(key);
	}

	// Token: 0x06004374 RID: 17268 RVA: 0x000F5830 File Offset: 0x000F3A30
	[global::UnityEngine.HideInInspector]
	protected internal virtual void updateCollider()
	{
		if (global::UnityEngine.Application.isPlaying && !this.isInteractive)
		{
			return;
		}
		global::UnityEngine.BoxCollider boxCollider = base.collider as global::UnityEngine.BoxCollider;
		if (boxCollider == null)
		{
			boxCollider = base.gameObject.AddComponent<global::UnityEngine.BoxCollider>();
		}
		float num = this.PixelsToUnits();
		global::UnityEngine.Vector2 vector = this.size * num;
		global::UnityEngine.Vector3 center = this.pivot.TransformToCenter(vector);
		boxCollider.size = new global::UnityEngine.Vector3(vector.x * this.hotZoneScale.x, vector.y * this.hotZoneScale.y, 0.001f);
		boxCollider.center = center;
		if (global::UnityEngine.Application.isPlaying && !this.IsInteractive)
		{
			boxCollider.enabled = false;
		}
		else
		{
			boxCollider.enabled = (base.enabled && this.IsVisible);
		}
	}

	// Token: 0x06004375 RID: 17269 RVA: 0x000F5910 File Offset: 0x000F3B10
	[global::UnityEngine.HideInInspector]
	protected virtual void OnRebuildRenderData()
	{
	}

	// Token: 0x06004376 RID: 17270 RVA: 0x000F5914 File Offset: 0x000F3B14
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnControlAdded(global::dfControl child)
	{
		this.Invalidate();
		if (this.ControlAdded != null)
		{
			this.ControlAdded(this, child);
		}
		this.Signal("OnControlAdded", new object[]
		{
			this,
			child
		});
	}

	// Token: 0x06004377 RID: 17271 RVA: 0x000F595C File Offset: 0x000F3B5C
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnControlRemoved(global::dfControl child)
	{
		this.Invalidate();
		if (this.ControlRemoved != null)
		{
			this.ControlRemoved(this, child);
		}
		this.Signal("OnControlRemoved", new object[]
		{
			this,
			child
		});
	}

	// Token: 0x06004378 RID: 17272 RVA: 0x000F59A4 File Offset: 0x000F3BA4
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnPositionChanged()
	{
		base.transform.hasChanged = false;
		if (this.renderData != null)
		{
			this.updateVersion();
			this.GetManager().Invalidate();
		}
		else
		{
			this.Invalidate();
		}
		this.ResetLayout(false, false);
		if (this.PositionChanged != null)
		{
			this.PositionChanged(this, this.Position);
		}
	}

	// Token: 0x06004379 RID: 17273 RVA: 0x000F5A10 File Offset: 0x000F3C10
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnSizeChanged()
	{
		this.updateCollider();
		this.Invalidate();
		this.ResetLayout(false, false);
		if (this.Anchor.IsAnyFlagSet(global::dfAnchorStyle.CenterHorizontal | global::dfAnchorStyle.CenterVertical))
		{
			this.PerformLayout();
		}
		if (this.SizeChanged != null)
		{
			this.SizeChanged(this, this.Size);
		}
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].PerformLayout();
		}
	}

	// Token: 0x0600437A RID: 17274 RVA: 0x000F5A98 File Offset: 0x000F3C98
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnPivotChanged()
	{
		this.Invalidate();
		if (this.Anchor.IsAnyFlagSet(global::dfAnchorStyle.CenterHorizontal | global::dfAnchorStyle.CenterVertical))
		{
			this.ResetLayout(false, false);
			this.PerformLayout();
		}
		if (this.PivotChanged != null)
		{
			this.PivotChanged(this, this.pivot);
		}
	}

	// Token: 0x0600437B RID: 17275 RVA: 0x000F5AEC File Offset: 0x000F3CEC
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnAnchorChanged()
	{
		global::dfAnchorStyle anchorStyle = this.layout.AnchorStyle;
		this.Invalidate();
		this.ResetLayout(false, false);
		if (anchorStyle.IsAnyFlagSet(global::dfAnchorStyle.CenterHorizontal | global::dfAnchorStyle.CenterVertical))
		{
			this.PerformLayout();
		}
		if (this.AnchorChanged != null)
		{
			this.AnchorChanged(this, anchorStyle);
		}
	}

	// Token: 0x0600437C RID: 17276 RVA: 0x000F5B44 File Offset: 0x000F3D44
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnOpacityChanged()
	{
		this.Invalidate();
		if (this.OpacityChanged != null)
		{
			this.OpacityChanged(this, this.Opacity);
		}
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].OnOpacityChanged();
		}
	}

	// Token: 0x0600437D RID: 17277 RVA: 0x000F5BA4 File Offset: 0x000F3DA4
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnColorChanged()
	{
		this.Invalidate();
		if (this.ColorChanged != null)
		{
			this.ColorChanged(this, this.Color);
		}
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].OnColorChanged();
		}
	}

	// Token: 0x0600437E RID: 17278 RVA: 0x000F5C04 File Offset: 0x000F3E04
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnZOrderChanged()
	{
		this.Invalidate();
		if (this.ZOrderChanged != null)
		{
			this.ZOrderChanged(this, this.zindex);
		}
	}

	// Token: 0x0600437F RID: 17279 RVA: 0x000F5C2C File Offset: 0x000F3E2C
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnTabIndexChanged()
	{
		this.Invalidate();
		if (this.TabIndexChanged != null)
		{
			this.TabIndexChanged(this, this.tabIndex);
		}
	}

	// Token: 0x06004380 RID: 17280 RVA: 0x000F5C54 File Offset: 0x000F3E54
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnIsVisibleChanged()
	{
		if (this.HasFocus && !this.IsVisible)
		{
			global::dfGUIManager.SetFocus(null);
		}
		this.Invalidate();
		this.Signal("OnIsVisibleChanged", new object[]
		{
			this,
			this.IsVisible
		});
		if (this.IsVisibleChanged != null)
		{
			this.IsVisibleChanged(this, this.isVisible);
		}
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].OnIsVisibleChanged();
		}
	}

	// Token: 0x06004381 RID: 17281 RVA: 0x000F5CF4 File Offset: 0x000F3EF4
	[global::UnityEngine.HideInInspector]
	protected internal virtual void OnIsEnabledChanged()
	{
		if (global::dfGUIManager.ContainsFocus(this) && !this.IsEnabled)
		{
			global::dfGUIManager.SetFocus(null);
		}
		this.Invalidate();
		this.Signal("OnIsEnabledChanged", new object[]
		{
			this,
			this.IsEnabled
		});
		if (this.IsEnabledChanged != null)
		{
			this.IsEnabledChanged(this, this.isEnabled);
		}
		for (int i = 0; i < this.controls.Count; i++)
		{
			this.controls[i].OnIsEnabledChanged();
		}
	}

	// Token: 0x06004382 RID: 17282 RVA: 0x000F5D94 File Offset: 0x000F3F94
	protected internal float CalculateOpacity()
	{
		if (this.parent == null)
		{
			return this.Opacity;
		}
		return this.Opacity * this.parent.CalculateOpacity();
	}

	// Token: 0x06004383 RID: 17283 RVA: 0x000F5DCC File Offset: 0x000F3FCC
	protected internal global::UnityEngine.Color32 ApplyOpacity(global::UnityEngine.Color32 color)
	{
		float num = this.CalculateOpacity();
		color.a = (byte)(num * 255f);
		return color;
	}

	// Token: 0x06004384 RID: 17284 RVA: 0x000F5DF0 File Offset: 0x000F3FF0
	protected internal global::UnityEngine.Vector2 GetHitPosition(global::dfMouseEventArgs args)
	{
		global::UnityEngine.Vector2 result;
		this.GetHitPosition(args.Ray, out result);
		return result;
	}

	// Token: 0x06004385 RID: 17285 RVA: 0x000F5E10 File Offset: 0x000F4010
	protected internal global::UnityEngine.Vector3 getScaledDirection(global::UnityEngine.Vector3 direction)
	{
		global::UnityEngine.Vector3 localScale = this.GetManager().transform.localScale;
		direction = base.transform.TransformDirection(direction);
		return global::UnityEngine.Vector3.Scale(direction, localScale);
	}

	// Token: 0x06004386 RID: 17286 RVA: 0x000F5E44 File Offset: 0x000F4044
	protected internal global::UnityEngine.Vector3 transformOffset(global::UnityEngine.Vector3 offset)
	{
		global::UnityEngine.Vector3 vector = offset.x * this.getScaledDirection(global::UnityEngine.Vector3.right);
		global::UnityEngine.Vector3 vector2 = offset.y * this.getScaledDirection(global::UnityEngine.Vector3.down);
		return (vector + vector2) * this.PixelsToUnits();
	}

	// Token: 0x06004387 RID: 17287 RVA: 0x000F5E94 File Offset: 0x000F4094
	protected internal virtual void OnResolutionChanged(global::UnityEngine.Vector2 previousResolution, global::UnityEngine.Vector2 currentResolution)
	{
		this.Invalidate();
		this.updateControlHierarchy(false);
		this.cachedPixelSize = 0f;
		global::UnityEngine.Vector3 vector = base.transform.localPosition / (2f / previousResolution.y);
		global::UnityEngine.Vector3 localPosition = vector * (2f / currentResolution.y);
		base.transform.localPosition = localPosition;
		this.cachedPosition = localPosition;
		this.layout.Attach(this);
		this.updateCollider();
		this.Signal("OnResolutionChanged", new object[]
		{
			this,
			previousResolution,
			currentResolution
		});
	}

	// Token: 0x06004388 RID: 17288 RVA: 0x000F5F38 File Offset: 0x000F4138
	[global::UnityEngine.HideInInspector]
	public virtual void Awake()
	{
		if (base.transform.parent != null)
		{
			global::dfControl component = base.transform.parent.GetComponent<global::dfControl>();
			if (component != null)
			{
				this.parent = component;
				component.AddControl(this);
			}
			if (this.controls == null)
			{
				this.updateControlHierarchy(false);
			}
			if (!global::UnityEngine.Application.isPlaying)
			{
				this.PerformLayout();
			}
		}
	}

	// Token: 0x06004389 RID: 17289 RVA: 0x000F5FA8 File Offset: 0x000F41A8
	[global::UnityEngine.HideInInspector]
	public virtual void Start()
	{
	}

	// Token: 0x0600438A RID: 17290 RVA: 0x000F5FAC File Offset: 0x000F41AC
	[global::UnityEngine.HideInInspector]
	public virtual void OnEnable()
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			base.collider.enabled = this.IsInteractive;
		}
		this.initializeControl();
		if (this.controls == null || this.controls.Count == 0)
		{
			this.updateControlHierarchy(false);
		}
		if (global::UnityEngine.Application.isPlaying && this.IsLocalized)
		{
			this.Localize();
		}
		this.OnIsEnabledChanged();
	}

	// Token: 0x0600438B RID: 17291 RVA: 0x000F6020 File Offset: 0x000F4220
	[global::UnityEngine.HideInInspector]
	public virtual void OnApplicationQuit()
	{
		this.RemoveAllEventHandlers();
	}

	// Token: 0x0600438C RID: 17292 RVA: 0x000F6028 File Offset: 0x000F4228
	[global::UnityEngine.HideInInspector]
	public virtual void OnDisable()
	{
		try
		{
			this.Invalidate();
			if (this.renderData != null)
			{
				this.renderData.Release();
				this.renderData = null;
			}
			if (global::dfGUIManager.HasFocus(this))
			{
				global::dfGUIManager.SetFocus(null);
			}
			this.OnIsEnabledChanged();
		}
		catch
		{
		}
	}

	// Token: 0x0600438D RID: 17293 RVA: 0x000F6098 File Offset: 0x000F4298
	[global::UnityEngine.HideInInspector]
	public virtual void OnDestroy()
	{
		this.isDisposing = true;
		if (global::UnityEngine.Application.isPlaying)
		{
			this.RemoveAllEventHandlers();
		}
		if (this.layout != null)
		{
			this.layout.Dispose();
		}
		if (this.parent != null && this.parent.controls != null && !this.parent.isDisposing && this.parent.controls.Remove(this))
		{
			this.parent.cachedChildCount--;
			this.parent.OnControlRemoved(this);
		}
		for (int i = 0; i < this.controls.Count; i++)
		{
			if (this.controls[i].layout != null)
			{
				this.controls[i].layout.Dispose();
				this.controls[i].layout = null;
			}
			this.controls[i].parent = null;
		}
		this.controls.Release();
		if (this.manager != null)
		{
			this.manager.Invalidate();
		}
		if (this.renderData != null)
		{
			this.renderData.Release();
		}
		this.layout = null;
		this.manager = null;
		this.parent = null;
		this.cachedClippingPlanes = null;
		this.cachedCorners = null;
		this.renderData = null;
		this.controls = null;
	}

	// Token: 0x0600438E RID: 17294 RVA: 0x000F6214 File Offset: 0x000F4414
	[global::UnityEngine.HideInInspector]
	public virtual void LateUpdate()
	{
		if (this.layout != null && this.layout.HasPendingLayoutRequest)
		{
			this.layout.PerformLayout();
		}
	}

	// Token: 0x0600438F RID: 17295 RVA: 0x000F6248 File Offset: 0x000F4448
	[global::UnityEngine.HideInInspector]
	public virtual void Update()
	{
		global::UnityEngine.Transform transform = base.transform;
		this.updateControlHierarchy(false);
		if (transform.hasChanged)
		{
			if (global::UnityEngine.Application.isPlaying)
			{
				if (this.cachedScale != transform.localScale)
				{
					this.cachedScale = transform.localScale;
					this.Invalidate();
				}
			}
			if ((this.cachedPosition - transform.localPosition).sqrMagnitude > 1E-45f)
			{
				this.cachedPosition = transform.localPosition;
				this.OnPositionChanged();
			}
			if (this.cachedRotation != transform.localRotation)
			{
				this.cachedRotation = transform.localRotation;
				this.Invalidate();
			}
			transform.hasChanged = false;
		}
	}

	// Token: 0x06004390 RID: 17296 RVA: 0x000F630C File Offset: 0x000F450C
	protected internal void SetControlIndex(global::dfControl child, int zindex)
	{
		global::dfControl dfControl = this.controls.FirstOrDefault((global::dfControl c) => c.zindex == zindex && c != child);
		if (dfControl != null)
		{
			dfControl.zindex = this.controls.IndexOf(child);
		}
		child.zindex = zindex;
		this.RebuildControlOrder();
	}

	// Token: 0x06004391 RID: 17297 RVA: 0x000F6380 File Offset: 0x000F4580
	public T AddControl<T>() where T : global::dfControl
	{
		return (T)((object)this.AddControl(typeof(T)));
	}

	// Token: 0x06004392 RID: 17298 RVA: 0x000F6398 File Offset: 0x000F4598
	public global::dfControl AddControl(global::System.Type ControlType)
	{
		if (!typeof(global::dfControl).IsAssignableFrom(ControlType))
		{
			throw new global::System.InvalidCastException();
		}
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(ControlType.Name);
		gameObject.transform.parent = base.transform;
		gameObject.layer = base.gameObject.layer;
		global::UnityEngine.Vector2 vector = this.Size * this.PixelsToUnits() * 0.5f;
		gameObject.transform.localPosition = new global::UnityEngine.Vector3(vector.x, vector.y, 0f);
		global::dfControl dfControl = gameObject.AddComponent(ControlType) as global::dfControl;
		dfControl.parent = this;
		dfControl.zindex = -1;
		this.AddControl(dfControl);
		return dfControl;
	}

	// Token: 0x06004393 RID: 17299 RVA: 0x000F6450 File Offset: 0x000F4650
	public void AddControl(global::dfControl child)
	{
		if (child.transform == null)
		{
			throw new global::System.NullReferenceException("The child control does not have a Transform");
		}
		if (!this.controls.Contains(child))
		{
			this.controls.Add(child);
			child.parent = this;
			child.transform.parent = base.transform;
		}
		if (child.zindex == -1)
		{
			child.zindex = this.getMaxZOrder() + 1;
		}
		this.controls.Sort();
		this.OnControlAdded(child);
		child.Invalidate();
		this.Invalidate();
	}

	// Token: 0x06004394 RID: 17300 RVA: 0x000F64E8 File Offset: 0x000F46E8
	private int getMaxZOrder()
	{
		int num = -1;
		for (int i = 0; i < this.controls.Count; i++)
		{
			num = global::UnityEngine.Mathf.Max(this.controls[i].zindex, num);
		}
		return num;
	}

	// Token: 0x06004395 RID: 17301 RVA: 0x000F652C File Offset: 0x000F472C
	public void RemoveControl(global::dfControl child)
	{
		if (this.isDisposing)
		{
			return;
		}
		if (child.Parent == this)
		{
			child.parent = null;
		}
		if (this.controls.Remove(child))
		{
			this.OnControlRemoved(child);
			child.Invalidate();
			this.Invalidate();
		}
	}

	// Token: 0x06004396 RID: 17302 RVA: 0x000F6584 File Offset: 0x000F4784
	[global::UnityEngine.HideInInspector]
	public void RebuildControlOrder()
	{
		bool flag = false;
		this.controls.Sort();
		for (int i = 0; i < this.controls.Count; i++)
		{
			if (this.controls[i].ZOrder != i)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		this.controls.Sort();
		for (int j = 0; j < this.controls.Count; j++)
		{
			this.controls[j].zindex = j;
		}
	}

	// Token: 0x06004397 RID: 17303 RVA: 0x000F6618 File Offset: 0x000F4818
	internal void updateControlHierarchy(bool force = false)
	{
		int childCount = base.transform.childCount;
		if (!force && childCount == this.cachedChildCount)
		{
			return;
		}
		this.cachedChildCount = childCount;
		global::dfList<global::dfControl> childControls = this.getChildControls();
		for (int i = 0; i < childControls.Count; i++)
		{
			global::dfControl dfControl = childControls[i];
			if (!this.controls.Contains(dfControl))
			{
				dfControl.parent = this;
				if (!global::UnityEngine.Application.isPlaying)
				{
					dfControl.ResetLayout(false, false);
				}
				this.OnControlAdded(dfControl);
				dfControl.updateControlHierarchy(false);
			}
		}
		for (int j = 0; j < this.controls.Count; j++)
		{
			global::dfControl dfControl2 = this.controls[j];
			if (dfControl2 == null || !childControls.Contains(dfControl2))
			{
				this.OnControlRemoved(dfControl2);
				if (dfControl2 != null && dfControl2.parent == this)
				{
					dfControl2.parent = null;
				}
			}
		}
		this.controls.Release();
		this.controls = childControls;
		this.RebuildControlOrder();
	}

	// Token: 0x06004398 RID: 17304 RVA: 0x000F6740 File Offset: 0x000F4940
	private global::dfList<global::dfControl> getChildControls()
	{
		int childCount = base.transform.childCount;
		global::dfList<global::dfControl> dfList = global::dfList<global::dfControl>.Obtain();
		dfList.EnsureCapacity(childCount);
		for (int i = 0; i < childCount; i++)
		{
			global::UnityEngine.Transform child = base.transform.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				global::dfControl component = child.GetComponent<global::dfControl>();
				if (component != null)
				{
					dfList.Add(component);
				}
			}
		}
		return dfList;
	}

	// Token: 0x06004399 RID: 17305 RVA: 0x000F67B8 File Offset: 0x000F49B8
	private void ensureLayoutExists()
	{
		if (this.layout == null)
		{
			this.layout = new global::dfControl.AnchorLayout(global::dfAnchorStyle.Top | global::dfAnchorStyle.Left, this);
		}
		else
		{
			this.layout.Attach(this);
		}
		int num = 0;
		while (this.Controls != null && num < this.Controls.Count)
		{
			if (this.controls[num] != null)
			{
				this.controls[num].ensureLayoutExists();
			}
			num++;
		}
	}

	// Token: 0x0600439A RID: 17306 RVA: 0x000F6840 File Offset: 0x000F4A40
	protected internal void updateVersion()
	{
		this.version = (global::dfControl.versionCounter += 1U);
	}

	// Token: 0x0600439B RID: 17307 RVA: 0x000F6858 File Offset: 0x000F4A58
	private void setPositionInternal(global::UnityEngine.Vector3 value)
	{
		value += this.pivot.UpperLeftToTransform(this.Size);
		value *= this.PixelsToUnits();
		if ((value - this.cachedPosition).sqrMagnitude <= 1E-45f)
		{
			return;
		}
		global::UnityEngine.Vector3 localPosition = value;
		base.transform.localPosition = localPosition;
		this.cachedPosition = localPosition;
		this.OnPositionChanged();
	}

	// Token: 0x0600439C RID: 17308 RVA: 0x000F68C8 File Offset: 0x000F4AC8
	private void initializeControl()
	{
		if (this.renderOrder == -1)
		{
			this.renderOrder = this.ZOrder;
		}
		if (base.transform.parent != null)
		{
			global::dfControl component = base.transform.parent.GetComponent<global::dfControl>();
			if (component != null)
			{
				component.AddControl(this);
			}
		}
		this.ensureLayoutExists();
		this.Invalidate();
		base.collider.isTrigger = false;
		if (global::UnityEngine.Application.isPlaying && base.rigidbody == null)
		{
			global::UnityEngine.Rigidbody rigidbody = base.gameObject.AddComponent<global::UnityEngine.Rigidbody>();
			rigidbody.hideFlags = 0xF;
			rigidbody.isKinematic = true;
			rigidbody.detectCollisions = false;
		}
		this.updateCollider();
	}

	// Token: 0x0600439D RID: 17309 RVA: 0x000F6984 File Offset: 0x000F4B84
	private global::UnityEngine.Vector3 getRelativePosition()
	{
		if (base.transform.parent == null)
		{
			return global::UnityEngine.Vector3.zero;
		}
		if (this.parent != null)
		{
			float num = this.PixelsToUnits();
			global::UnityEngine.Vector3 position = base.transform.parent.position;
			global::UnityEngine.Vector3 position2 = base.transform.position;
			global::UnityEngine.Transform transform = base.transform.parent;
			global::UnityEngine.Vector3 vector = transform.InverseTransformPoint(position / num);
			vector += this.parent.pivot.TransformToUpperLeft(this.parent.size);
			global::UnityEngine.Vector3 vector2 = transform.InverseTransformPoint(position2 / num);
			vector2 += this.pivot.TransformToUpperLeft(this.size);
			global::UnityEngine.Vector3 vector3 = vector2 - vector;
			return vector3.Scale(1f, -1f, 1f);
		}
		global::dfGUIManager dfGUIManager = this.GetManager();
		if (dfGUIManager == null)
		{
			global::UnityEngine.Debug.LogError("Cannot get position: View not found");
			return global::UnityEngine.Vector3.zero;
		}
		float num2 = this.PixelsToUnits();
		global::UnityEngine.Vector3 vector4 = base.transform.position + this.pivot.TransformToUpperLeft(this.size) * num2;
		global::UnityEngine.Plane[] clippingPlanes = dfGUIManager.GetClippingPlanes();
		float num3 = clippingPlanes[0].GetDistanceToPoint(vector4) / num2;
		float num4 = clippingPlanes[3].GetDistanceToPoint(vector4) / num2;
		return new global::UnityEngine.Vector3(num3, num4).RoundToInt();
	}

	// Token: 0x0600439E RID: 17310 RVA: 0x000F6B08 File Offset: 0x000F4D08
	private void setRelativePosition(global::UnityEngine.Vector3 value)
	{
		if (base.transform.parent == null)
		{
			global::UnityEngine.Debug.LogError("Cannot set relative position without a parent Transform.");
			return;
		}
		if ((value - this.getRelativePosition()).sqrMagnitude <= 1E-45f)
		{
			return;
		}
		if (this.parent != null)
		{
			global::UnityEngine.Vector3 vector = value.Scale(1f, -1f, 1f) + this.pivot.UpperLeftToTransform(this.size) - this.parent.pivot.UpperLeftToTransform(this.parent.size);
			vector *= this.PixelsToUnits();
			if ((vector - base.transform.localPosition).sqrMagnitude >= 1E-45f)
			{
				base.transform.localPosition = vector;
				this.cachedPosition = vector;
				this.OnPositionChanged();
			}
			return;
		}
		global::dfGUIManager dfGUIManager = this.GetManager();
		if (dfGUIManager == null)
		{
			global::UnityEngine.Debug.LogError("Cannot get position: View not found");
			return;
		}
		global::UnityEngine.Vector3[] corners = dfGUIManager.GetCorners();
		global::UnityEngine.Vector3 vector2 = corners[0];
		float num = this.PixelsToUnits();
		value = value.Scale(1f, -1f, 1f) * num;
		global::UnityEngine.Vector3 vector3 = this.pivot.UpperLeftToTransform(this.Size) * num;
		global::UnityEngine.Vector3 vector4 = vector2 + dfGUIManager.transform.TransformDirection(value) + vector3;
		if ((vector4 - this.cachedPosition).sqrMagnitude > 1E-45f)
		{
			base.transform.position = vector4;
			this.cachedPosition = base.transform.localPosition;
			this.OnPositionChanged();
		}
	}

	// Token: 0x0600439F RID: 17311 RVA: 0x000F6CD0 File Offset: 0x000F4ED0
	private static float distanceFromLine(global::UnityEngine.Vector3 start, global::UnityEngine.Vector3 end, global::UnityEngine.Vector3 test)
	{
		global::UnityEngine.Vector3 vector = start - end;
		global::UnityEngine.Vector3 vector2 = test - end;
		float num = global::UnityEngine.Vector3.Dot(vector2, vector);
		if (num <= 0f)
		{
			return global::UnityEngine.Vector3.Distance(test, end);
		}
		float num2 = global::UnityEngine.Vector3.Dot(vector, vector);
		if (num2 <= num)
		{
			return global::UnityEngine.Vector3.Distance(test, start);
		}
		float num3 = num / num2;
		global::UnityEngine.Vector3 vector3 = end + num3 * vector;
		return global::UnityEngine.Vector3.Distance(test, vector3);
	}

	// Token: 0x060043A0 RID: 17312 RVA: 0x000F6D3C File Offset: 0x000F4F3C
	private static global::UnityEngine.Vector3 closestPointOnLine(global::UnityEngine.Vector3 start, global::UnityEngine.Vector3 end, global::UnityEngine.Vector3 test, bool clamp)
	{
		global::UnityEngine.Vector3 vector = test - start;
		global::UnityEngine.Vector3 vector2 = (end - start).normalized;
		float magnitude = (end - start).magnitude;
		float num = global::UnityEngine.Vector3.Dot(vector2, vector);
		if (clamp)
		{
			if (num < 0f)
			{
				return start;
			}
			if (num > magnitude)
			{
				return end;
			}
		}
		vector2 *= num;
		return start + vector2;
	}

	// Token: 0x060043A1 RID: 17313 RVA: 0x000F6DA8 File Offset: 0x000F4FA8
	public int CompareTo(global::dfControl other)
	{
		if (this.ZOrder >= 0)
		{
			return this.ZOrder.CompareTo(other.ZOrder);
		}
		if (other.ZOrder < 0)
		{
			return 0;
		}
		return 1;
	}

	// Token: 0x060043A2 RID: 17314 RVA: 0x000F6DE8 File Offset: 0x000F4FE8
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <OnTabKeyPressed>m__16(global::dfControl c)
	{
		return c != this && c.TabIndex >= 0 && c.IsInteractive && c.CanFocus && c.IsVisible;
	}

	// Token: 0x060043A3 RID: 17315 RVA: 0x000F6E2C File Offset: 0x000F502C
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static int <OnTabKeyPressed>m__17(global::dfControl lhs, global::dfControl rhs)
	{
		if (lhs.TabIndex == rhs.TabIndex)
		{
			return lhs.RenderOrder.CompareTo(rhs.RenderOrder);
		}
		return lhs.TabIndex.CompareTo(rhs.TabIndex);
	}

	// Token: 0x060043A4 RID: 17316 RVA: 0x000F6E74 File Offset: 0x000F5074
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <RemoveAllEventHandlers>m__1A(global::System.Reflection.FieldInfo f)
	{
		return typeof(global::System.Delegate).IsAssignableFrom(f.FieldType);
	}

	// Token: 0x040023A3 RID: 9123
	private const float MINIMUM_OPACITY = 0.0125f;

	// Token: 0x040023A4 RID: 9124
	private static uint versionCounter;

	// Token: 0x040023A5 RID: 9125
	[global::UnityEngine.SerializeField]
	protected bool isEnabled = true;

	// Token: 0x040023A6 RID: 9126
	[global::UnityEngine.SerializeField]
	protected bool isVisible = true;

	// Token: 0x040023A7 RID: 9127
	[global::UnityEngine.SerializeField]
	protected bool isInteractive = true;

	// Token: 0x040023A8 RID: 9128
	[global::UnityEngine.SerializeField]
	protected string tooltip;

	// Token: 0x040023A9 RID: 9129
	[global::UnityEngine.SerializeField]
	protected global::dfPivotPoint pivot;

	// Token: 0x040023AA RID: 9130
	[global::UnityEngine.SerializeField]
	protected int zindex = -1;

	// Token: 0x040023AB RID: 9131
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 color = new global::UnityEngine.Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x040023AC RID: 9132
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 disabledColor = new global::UnityEngine.Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x040023AD RID: 9133
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 size = global::UnityEngine.Vector2.zero;

	// Token: 0x040023AE RID: 9134
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 minSize = global::UnityEngine.Vector2.zero;

	// Token: 0x040023AF RID: 9135
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 maxSize = global::UnityEngine.Vector2.zero;

	// Token: 0x040023B0 RID: 9136
	[global::UnityEngine.SerializeField]
	protected bool clipChildren;

	// Token: 0x040023B1 RID: 9137
	[global::UnityEngine.SerializeField]
	protected int tabIndex = -1;

	// Token: 0x040023B2 RID: 9138
	[global::UnityEngine.SerializeField]
	protected bool canFocus;

	// Token: 0x040023B3 RID: 9139
	[global::UnityEngine.SerializeField]
	protected global::dfControl.AnchorLayout layout;

	// Token: 0x040023B4 RID: 9140
	[global::UnityEngine.SerializeField]
	protected int renderOrder = -1;

	// Token: 0x040023B5 RID: 9141
	[global::UnityEngine.SerializeField]
	protected bool isLocalized;

	// Token: 0x040023B6 RID: 9142
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 hotZoneScale = global::UnityEngine.Vector2.one;

	// Token: 0x040023B7 RID: 9143
	protected bool isControlInvalidated = true;

	// Token: 0x040023B8 RID: 9144
	protected global::dfControl parent;

	// Token: 0x040023B9 RID: 9145
	protected global::dfList<global::dfControl> controls = global::dfList<global::dfControl>.Obtain();

	// Token: 0x040023BA RID: 9146
	protected global::dfGUIManager manager;

	// Token: 0x040023BB RID: 9147
	protected global::dfLanguageManager languageManager;

	// Token: 0x040023BC RID: 9148
	protected bool languageManagerChecked;

	// Token: 0x040023BD RID: 9149
	protected int cachedChildCount;

	// Token: 0x040023BE RID: 9150
	protected global::UnityEngine.Vector3 cachedPosition = global::UnityEngine.Vector3.one * float.MinValue;

	// Token: 0x040023BF RID: 9151
	protected global::UnityEngine.Quaternion cachedRotation = global::UnityEngine.Quaternion.identity;

	// Token: 0x040023C0 RID: 9152
	protected global::UnityEngine.Vector3 cachedScale = global::UnityEngine.Vector3.one;

	// Token: 0x040023C1 RID: 9153
	protected float cachedPixelSize;

	// Token: 0x040023C2 RID: 9154
	protected global::dfRenderData renderData;

	// Token: 0x040023C3 RID: 9155
	protected bool isMouseHovering;

	// Token: 0x040023C4 RID: 9156
	private object tag;

	// Token: 0x040023C5 RID: 9157
	protected bool isDisposing;

	// Token: 0x040023C6 RID: 9158
	private bool performingLayout;

	// Token: 0x040023C7 RID: 9159
	private global::UnityEngine.Vector3[] cachedCorners = new global::UnityEngine.Vector3[4];

	// Token: 0x040023C8 RID: 9160
	private global::UnityEngine.Plane[] cachedClippingPlanes = new global::UnityEngine.Plane[4];

	// Token: 0x040023C9 RID: 9161
	private uint version;

	// Token: 0x040023CA RID: 9162
	private bool rendering;

	// Token: 0x040023CB RID: 9163
	private global::ChildControlEventHandler ControlAdded;

	// Token: 0x040023CC RID: 9164
	private global::ChildControlEventHandler ControlRemoved;

	// Token: 0x040023CD RID: 9165
	private global::FocusEventHandler GotFocus;

	// Token: 0x040023CE RID: 9166
	private global::FocusEventHandler EnterFocus;

	// Token: 0x040023CF RID: 9167
	private global::FocusEventHandler LostFocus;

	// Token: 0x040023D0 RID: 9168
	private global::FocusEventHandler LeaveFocus;

	// Token: 0x040023D1 RID: 9169
	private global::PropertyChangedEventHandler<int> TabIndexChanged;

	// Token: 0x040023D2 RID: 9170
	private global::PropertyChangedEventHandler<global::UnityEngine.Vector2> PositionChanged;

	// Token: 0x040023D3 RID: 9171
	private global::PropertyChangedEventHandler<global::UnityEngine.Vector2> SizeChanged;

	// Token: 0x040023D4 RID: 9172
	private global::PropertyChangedEventHandler<global::UnityEngine.Color32> ColorChanged;

	// Token: 0x040023D5 RID: 9173
	private global::PropertyChangedEventHandler<bool> IsVisibleChanged;

	// Token: 0x040023D6 RID: 9174
	private global::PropertyChangedEventHandler<bool> IsEnabledChanged;

	// Token: 0x040023D7 RID: 9175
	private global::PropertyChangedEventHandler<float> OpacityChanged;

	// Token: 0x040023D8 RID: 9176
	private global::PropertyChangedEventHandler<global::dfAnchorStyle> AnchorChanged;

	// Token: 0x040023D9 RID: 9177
	private global::PropertyChangedEventHandler<global::dfPivotPoint> PivotChanged;

	// Token: 0x040023DA RID: 9178
	private global::PropertyChangedEventHandler<int> ZOrderChanged;

	// Token: 0x040023DB RID: 9179
	private global::DragEventHandler DragStart;

	// Token: 0x040023DC RID: 9180
	private global::DragEventHandler DragEnd;

	// Token: 0x040023DD RID: 9181
	private global::DragEventHandler DragDrop;

	// Token: 0x040023DE RID: 9182
	private global::DragEventHandler DragEnter;

	// Token: 0x040023DF RID: 9183
	private global::DragEventHandler DragLeave;

	// Token: 0x040023E0 RID: 9184
	private global::DragEventHandler DragOver;

	// Token: 0x040023E1 RID: 9185
	private global::KeyPressHandler KeyPress;

	// Token: 0x040023E2 RID: 9186
	private global::KeyPressHandler KeyDown;

	// Token: 0x040023E3 RID: 9187
	private global::KeyPressHandler KeyUp;

	// Token: 0x040023E4 RID: 9188
	private global::ControlMultiTouchEventHandler MultiTouch;

	// Token: 0x040023E5 RID: 9189
	private global::MouseEventHandler MouseEnter;

	// Token: 0x040023E6 RID: 9190
	private global::MouseEventHandler MouseMove;

	// Token: 0x040023E7 RID: 9191
	private global::MouseEventHandler MouseHover;

	// Token: 0x040023E8 RID: 9192
	private global::MouseEventHandler MouseLeave;

	// Token: 0x040023E9 RID: 9193
	private global::MouseEventHandler MouseDown;

	// Token: 0x040023EA RID: 9194
	private global::MouseEventHandler MouseUp;

	// Token: 0x040023EB RID: 9195
	private global::MouseEventHandler MouseWheel;

	// Token: 0x040023EC RID: 9196
	private global::MouseEventHandler Click;

	// Token: 0x040023ED RID: 9197
	private global::MouseEventHandler DoubleClick;

	// Token: 0x040023EE RID: 9198
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Comparison<global::dfControl> <>f__am$cache4A;

	// Token: 0x040023EF RID: 9199
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::System.Reflection.FieldInfo, bool> <>f__am$cache4B;

	// Token: 0x020007DD RID: 2013
	[global::System.Serializable]
	protected class AnchorLayout
	{
		// Token: 0x060043A5 RID: 17317 RVA: 0x000F6E8C File Offset: 0x000F508C
		internal AnchorLayout(global::dfAnchorStyle anchorStyle)
		{
			this.anchorStyle = anchorStyle;
		}

		// Token: 0x060043A6 RID: 17318 RVA: 0x000F6E9C File Offset: 0x000F509C
		internal AnchorLayout(global::dfAnchorStyle anchorStyle, global::dfControl owner) : this(anchorStyle)
		{
			this.Attach(owner);
			this.Reset(false);
		}

		// Token: 0x17000C6D RID: 3181
		// (get) Token: 0x060043A7 RID: 17319 RVA: 0x000F6EB4 File Offset: 0x000F50B4
		// (set) Token: 0x060043A8 RID: 17320 RVA: 0x000F6EBC File Offset: 0x000F50BC
		internal global::dfAnchorStyle AnchorStyle
		{
			get
			{
				return this.anchorStyle;
			}
			set
			{
				if (value != this.anchorStyle)
				{
					this.anchorStyle = value;
					this.Reset(false);
				}
			}
		}

		// Token: 0x17000C6E RID: 3182
		// (get) Token: 0x060043A9 RID: 17321 RVA: 0x000F6ED8 File Offset: 0x000F50D8
		internal bool IsPerformingLayout
		{
			get
			{
				return this.performingLayout;
			}
		}

		// Token: 0x17000C6F RID: 3183
		// (get) Token: 0x060043AA RID: 17322 RVA: 0x000F6EE0 File Offset: 0x000F50E0
		internal bool IsLayoutSuspended
		{
			get
			{
				return this.suspendLayoutCounter > 0;
			}
		}

		// Token: 0x17000C70 RID: 3184
		// (get) Token: 0x060043AB RID: 17323 RVA: 0x000F6EEC File Offset: 0x000F50EC
		internal bool HasPendingLayoutRequest
		{
			get
			{
				return this.pendingLayoutRequest;
			}
		}

		// Token: 0x060043AC RID: 17324 RVA: 0x000F6EF4 File Offset: 0x000F50F4
		internal void Dispose()
		{
			if (!this.disposed)
			{
				this.disposed = true;
				this.owner = null;
			}
		}

		// Token: 0x060043AD RID: 17325 RVA: 0x000F6F10 File Offset: 0x000F5110
		internal void SuspendLayout()
		{
			this.suspendLayoutCounter++;
		}

		// Token: 0x060043AE RID: 17326 RVA: 0x000F6F20 File Offset: 0x000F5120
		internal void ResumeLayout()
		{
			bool flag = this.suspendLayoutCounter > 0;
			this.suspendLayoutCounter = global::UnityEngine.Mathf.Max(0, this.suspendLayoutCounter - 1);
			if (flag && this.suspendLayoutCounter == 0 && this.pendingLayoutRequest)
			{
				this.PerformLayout();
			}
		}

		// Token: 0x060043AF RID: 17327 RVA: 0x000F6F70 File Offset: 0x000F5170
		internal void PerformLayout()
		{
			if (this.disposed)
			{
				return;
			}
			if (this.suspendLayoutCounter > 0)
			{
				this.pendingLayoutRequest = true;
			}
			else
			{
				this.performLayoutInternal();
			}
		}

		// Token: 0x060043B0 RID: 17328 RVA: 0x000F6FA8 File Offset: 0x000F51A8
		internal void Attach(global::dfControl ownerControl)
		{
			this.owner = ownerControl;
		}

		// Token: 0x060043B1 RID: 17329 RVA: 0x000F6FB4 File Offset: 0x000F51B4
		internal void Reset(bool force = false)
		{
			if (this.owner == null || this.owner.transform.parent == null)
			{
				return;
			}
			bool flag = (!force && (this.IsPerformingLayout || this.IsLayoutSuspended)) || this.owner == null || !this.owner.gameObject.activeSelf;
			if (flag)
			{
				return;
			}
			if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Proportional))
			{
				this.resetLayoutProportional();
			}
			else
			{
				this.resetLayoutAbsolute();
			}
		}

		// Token: 0x060043B2 RID: 17330 RVA: 0x000F7068 File Offset: 0x000F5268
		private void resetLayoutProportional()
		{
			global::UnityEngine.Vector3 relativePosition = this.owner.RelativePosition;
			global::UnityEngine.Vector2 size = this.owner.Size;
			global::UnityEngine.Vector2 parentSize = this.getParentSize();
			float x = relativePosition.x;
			float y = relativePosition.y;
			float num = x + size.x;
			float num2 = y + size.y;
			if (this.margins == null)
			{
				this.margins = new global::dfAnchorMargins();
			}
			this.margins.left = x / parentSize.x;
			this.margins.right = num / parentSize.x;
			this.margins.top = y / parentSize.y;
			this.margins.bottom = num2 / parentSize.y;
		}

		// Token: 0x060043B3 RID: 17331 RVA: 0x000F7128 File Offset: 0x000F5328
		private void resetLayoutAbsolute()
		{
			global::UnityEngine.Vector3 relativePosition = this.owner.RelativePosition;
			global::UnityEngine.Vector2 size = this.owner.Size;
			global::UnityEngine.Vector2 parentSize = this.getParentSize();
			float x = relativePosition.x;
			float y = relativePosition.y;
			float right = parentSize.x - size.x - x;
			float bottom = parentSize.y - size.y - y;
			if (this.margins == null)
			{
				this.margins = new global::dfAnchorMargins();
			}
			this.margins.left = x;
			this.margins.right = right;
			this.margins.top = y;
			this.margins.bottom = bottom;
		}

		// Token: 0x060043B4 RID: 17332 RVA: 0x000F71D8 File Offset: 0x000F53D8
		protected void performLayoutInternal()
		{
			bool flag = this.margins == null || this.IsPerformingLayout || this.IsLayoutSuspended || this.owner == null || !this.owner.gameObject.activeSelf;
			if (flag)
			{
				return;
			}
			try
			{
				this.performingLayout = true;
				this.pendingLayoutRequest = false;
				global::UnityEngine.Vector2 parentSize = this.getParentSize();
				global::UnityEngine.Vector2 size = this.owner.Size;
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Proportional))
				{
					this.performLayoutProportional(parentSize, size);
				}
				else
				{
					this.performLayoutAbsolute(parentSize, size);
				}
			}
			finally
			{
				this.performingLayout = false;
			}
		}

		// Token: 0x060043B5 RID: 17333 RVA: 0x000F72AC File Offset: 0x000F54AC
		private string getPath(global::dfControl owner)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(0x400);
			while (owner != null)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Insert(0, '/');
				}
				stringBuilder.Insert(0, owner.name);
				owner = owner.Parent;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060043B6 RID: 17334 RVA: 0x000F7308 File Offset: 0x000F5508
		private void performLayoutProportional(global::UnityEngine.Vector2 parentSize, global::UnityEngine.Vector2 controlSize)
		{
			float x = this.margins.left * parentSize.x;
			float num = this.margins.right * parentSize.x;
			float y = this.margins.top * parentSize.y;
			float num2 = this.margins.bottom * parentSize.y;
			global::UnityEngine.Vector3 relativePosition = this.owner.RelativePosition;
			global::UnityEngine.Vector2 size = controlSize;
			if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Left))
			{
				relativePosition.x = x;
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Right))
				{
					size.x = (this.margins.right - this.margins.left) * parentSize.x;
				}
			}
			else if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Right))
			{
				relativePosition.x = num - controlSize.x;
			}
			else if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.CenterHorizontal))
			{
				relativePosition.x = (parentSize.x - controlSize.x) * 0.5f;
			}
			if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Top))
			{
				relativePosition.y = y;
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Bottom))
				{
					size.y = (this.margins.bottom - this.margins.top) * parentSize.y;
				}
			}
			else if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Bottom))
			{
				relativePosition.y = num2 - controlSize.y;
			}
			else if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.CenterVertical))
			{
				relativePosition.y = (parentSize.y - controlSize.y) * 0.5f;
			}
			this.owner.Size = size;
			this.owner.RelativePosition = relativePosition;
			if (this.owner.GetManager().PixelPerfectMode)
			{
				this.owner.MakePixelPerfect(false);
			}
		}

		// Token: 0x060043B7 RID: 17335 RVA: 0x000F7508 File Offset: 0x000F5708
		private void performLayoutAbsolute(global::UnityEngine.Vector2 parentSize, global::UnityEngine.Vector2 controlSize)
		{
			float num = this.margins.left;
			float num2 = this.margins.top;
			float num3 = num + controlSize.x;
			float num4 = num2 + controlSize.y;
			if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.CenterHorizontal))
			{
				num = (float)global::UnityEngine.Mathf.RoundToInt((parentSize.x - controlSize.x) * 0.5f);
				num3 = (float)global::UnityEngine.Mathf.RoundToInt(num + controlSize.x);
			}
			else
			{
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Left))
				{
					num = this.margins.left;
					num3 = num + controlSize.x;
				}
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Right))
				{
					num3 = parentSize.x - this.margins.right;
					if (!this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Left))
					{
						num = num3 - controlSize.x;
					}
				}
			}
			if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.CenterVertical))
			{
				num2 = (float)global::UnityEngine.Mathf.RoundToInt((parentSize.y - controlSize.y) * 0.5f);
				num4 = (float)global::UnityEngine.Mathf.RoundToInt(num2 + controlSize.y);
			}
			else
			{
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Top))
				{
					num2 = this.margins.top;
					num4 = num2 + controlSize.y;
				}
				if (this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Bottom))
				{
					num4 = parentSize.y - this.margins.bottom;
					if (!this.anchorStyle.IsFlagSet(global::dfAnchorStyle.Top))
					{
						num2 = num4 - controlSize.y;
					}
				}
			}
			global::UnityEngine.Vector2 size;
			size..ctor(global::UnityEngine.Mathf.Max(0f, num3 - num), global::UnityEngine.Mathf.Max(0f, num4 - num2));
			this.owner.Size = size;
			this.owner.RelativePosition = new global::UnityEngine.Vector3(num, num2);
		}

		// Token: 0x060043B8 RID: 17336 RVA: 0x000F76D8 File Offset: 0x000F58D8
		private global::UnityEngine.Vector2 getParentSize()
		{
			global::dfControl component = this.owner.transform.parent.GetComponent<global::dfControl>();
			if (component != null)
			{
				return component.Size;
			}
			global::dfGUIManager manager = this.owner.GetManager();
			return manager.GetScreenSize();
		}

		// Token: 0x060043B9 RID: 17337 RVA: 0x000F7724 File Offset: 0x000F5924
		public override string ToString()
		{
			if (this.owner == null)
			{
				return "NO OWNER FOR ANCHOR";
			}
			global::dfControl parent = this.owner.parent;
			return string.Format("{0}.{1} - {2}", (!(parent != null)) ? "SCREEN" : parent.name, this.owner.name, this.margins);
		}

		// Token: 0x040023F0 RID: 9200
		[global::UnityEngine.SerializeField]
		protected global::dfAnchorStyle anchorStyle;

		// Token: 0x040023F1 RID: 9201
		[global::UnityEngine.SerializeField]
		protected global::dfAnchorMargins margins;

		// Token: 0x040023F2 RID: 9202
		[global::UnityEngine.SerializeField]
		protected global::dfControl owner;

		// Token: 0x040023F3 RID: 9203
		private int suspendLayoutCounter;

		// Token: 0x040023F4 RID: 9204
		private bool performingLayout;

		// Token: 0x040023F5 RID: 9205
		private bool disposed;

		// Token: 0x040023F6 RID: 9206
		private bool pendingLayoutRequest;
	}

	// Token: 0x020007DE RID: 2014
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RaiseEvent>c__AnonStorey64
	{
		// Token: 0x060043BA RID: 17338 RVA: 0x000F778C File Offset: 0x000F598C
		public <RaiseEvent>c__AnonStorey64()
		{
		}

		// Token: 0x060043BB RID: 17339 RVA: 0x000F7794 File Offset: 0x000F5994
		internal bool <>m__18(global::System.Reflection.FieldInfo f)
		{
			return f.Name == this.eventName;
		}

		// Token: 0x040023F7 RID: 9207
		internal string eventName;
	}

	// Token: 0x020007DF RID: 2015
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RemoveEventHandlers>c__AnonStorey65
	{
		// Token: 0x060043BC RID: 17340 RVA: 0x000F77A8 File Offset: 0x000F59A8
		public <RemoveEventHandlers>c__AnonStorey65()
		{
		}

		// Token: 0x060043BD RID: 17341 RVA: 0x000F77B0 File Offset: 0x000F59B0
		internal bool <>m__19(global::System.Reflection.FieldInfo f)
		{
			return typeof(global::System.Delegate).IsAssignableFrom(f.FieldType) && f.Name == this.EventName;
		}

		// Token: 0x040023F8 RID: 9208
		internal string EventName;
	}

	// Token: 0x020007E0 RID: 2016
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <SetControlIndex>c__AnonStorey66
	{
		// Token: 0x060043BE RID: 17342 RVA: 0x000F77EC File Offset: 0x000F59EC
		public <SetControlIndex>c__AnonStorey66()
		{
		}

		// Token: 0x060043BF RID: 17343 RVA: 0x000F77F4 File Offset: 0x000F59F4
		internal bool <>m__1B(global::dfControl c)
		{
			return c.zindex == this.zindex && c != this.child;
		}

		// Token: 0x040023F9 RID: 9209
		internal int zindex;

		// Token: 0x040023FA RID: 9210
		internal global::dfControl child;
	}
}
