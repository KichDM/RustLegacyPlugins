using System;
using Facepunch;
using UnityEngine;

// Token: 0x02000583 RID: 1411
public sealed class ContextActivator : global::Facepunch.MonoBehaviour, global::IContextRequestable, global::IContextRequestableQuick, global::IContextRequestableStatus, global::IContextRequestableText, global::IContextRequestablePointText, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002F65 RID: 12133 RVA: 0x000B4D0C File Offset: 0x000B2F0C
	public ContextActivator()
	{
	}

	// Token: 0x06002F66 RID: 12134 RVA: 0x000B4D14 File Offset: 0x000B2F14
	global::ContextExecution global::IContextRequestable.ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick | global::ContextExecution.Menu;
	}

	// Token: 0x06002F67 RID: 12135 RVA: 0x000B4D18 File Offset: 0x000B2F18
	global::ContextResponse global::IContextRequestableQuick.ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		global::Character component = controllable.GetComponent<global::Character>();
		if (this.ApplyActivatable(this.mainAction, component, timestamp, false) == global::ActivationResult.Success)
		{
			if (this.extraActions != null)
			{
				foreach (global::Activatable activatable in this.extraActions)
				{
					this.ApplyActivatable(activatable, component, timestamp, true);
				}
			}
			return global::ContextResponse.DoneBreak;
		}
		return global::ContextResponse.DoneBreak;
	}

	// Token: 0x17000A12 RID: 2578
	// (get) Token: 0x06002F68 RID: 12136 RVA: 0x000B4D80 File Offset: 0x000B2F80
	private global::ActivationToggleState toggleState
	{
		get
		{
			if (!this.mainAction)
			{
				return global::ActivationToggleState.Unspecified;
			}
			return this.mainAction.toggleState;
		}
	}

	// Token: 0x06002F69 RID: 12137 RVA: 0x000B4DA0 File Offset: 0x000B2FA0
	private global::ActivationResult ApplyActivatable(global::Activatable activatable, global::Character instigator, ulong timestamp, bool extra)
	{
		global::ActivationResult result;
		if (activatable)
		{
			global::ContextActivator.ActivationMode activationMode = this.activationMode;
			if (activationMode != global::ContextActivator.ActivationMode.TurnOn)
			{
				if (activationMode != global::ContextActivator.ActivationMode.TurnOff)
				{
					result = activatable.Activate(instigator, timestamp);
				}
				else
				{
					result = activatable.Activate(false, instigator, timestamp);
				}
			}
			else
			{
				result = activatable.Activate(true, instigator, timestamp);
			}
		}
		else
		{
			result = global::ActivationResult.Error_Destroyed;
		}
		return result;
	}

	// Token: 0x0400191C RID: 6428
	[global::UnityEngine.SerializeField]
	private global::Activatable mainAction;

	// Token: 0x0400191D RID: 6429
	[global::UnityEngine.SerializeField]
	private global::ContextActivator.ActivationMode activationMode;

	// Token: 0x0400191E RID: 6430
	[global::UnityEngine.SerializeField]
	private global::Activatable[] extraActions;

	// Token: 0x0400191F RID: 6431
	[global::UnityEngine.SerializeField]
	private string defaultText;

	// Token: 0x04001920 RID: 6432
	[global::UnityEngine.SerializeField]
	private string onText;

	// Token: 0x04001921 RID: 6433
	[global::UnityEngine.SerializeField]
	private string offText;

	// Token: 0x04001922 RID: 6434
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 defaultTextPoint;

	// Token: 0x04001923 RID: 6435
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 onTextPoint;

	// Token: 0x04001924 RID: 6436
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 offTextPoint;

	// Token: 0x04001925 RID: 6437
	[global::UnityEngine.SerializeField]
	private bool useTextPoint;

	// Token: 0x04001926 RID: 6438
	[global::UnityEngine.SerializeField]
	private bool useSpriteTextPoint;

	// Token: 0x04001927 RID: 6439
	[global::UnityEngine.SerializeField]
	private global::ContextActivator.SpriteQuickMode defaultSprite;

	// Token: 0x04001928 RID: 6440
	[global::UnityEngine.SerializeField]
	private global::ContextActivator.SpriteQuickMode onSprite;

	// Token: 0x04001929 RID: 6441
	[global::UnityEngine.SerializeField]
	private global::ContextActivator.SpriteQuickMode offSprite;

	// Token: 0x0400192A RID: 6442
	[global::UnityEngine.SerializeField]
	private bool isSwitch;

	// Token: 0x0400192B RID: 6443
	private bool isToggle;

	// Token: 0x02000584 RID: 1412
	private enum SpriteQuickMode
	{
		// Token: 0x0400192D RID: 6445
		Default,
		// Token: 0x0400192E RID: 6446
		Faded,
		// Token: 0x0400192F RID: 6447
		AlwaysVisible,
		// Token: 0x04001930 RID: 6448
		NeverVisisble
	}

	// Token: 0x02000585 RID: 1413
	private enum ActivationMode
	{
		// Token: 0x04001932 RID: 6450
		ActivateOrToggle,
		// Token: 0x04001933 RID: 6451
		TurnOn,
		// Token: 0x04001934 RID: 6452
		TurnOff
	}
}
