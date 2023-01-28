using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000560 RID: 1376
[global::InterfaceDriverComponent(typeof(global::IActivatable), "_implementation", "implementation", SearchRoute = global::InterfaceSearchRoute.GameObject, UnityType = typeof(global::Facepunch.MonoBehaviour), AlwaysSaveDisabled = true)]
public sealed class Activatable : global::UnityEngine.MonoBehaviour, global::IComponentInterfaceDriver<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>
{
	// Token: 0x06002ECB RID: 11979 RVA: 0x000B2724 File Offset: 0x000B0924
	public Activatable()
	{
	}

	// Token: 0x170009EE RID: 2542
	// (get) Token: 0x06002ECC RID: 11980 RVA: 0x000B272C File Offset: 0x000B092C
	public global::Facepunch.MonoBehaviour implementor
	{
		get
		{
			if (!this._awoke)
			{
				try
				{
					this.Refresh();
				}
				finally
				{
					this._awoke = true;
				}
			}
			return this.implementation;
		}
	}

	// Token: 0x170009EF RID: 2543
	// (get) Token: 0x06002ECD RID: 11981 RVA: 0x000B277C File Offset: 0x000B097C
	public global::IActivatable @interface
	{
		get
		{
			if (!this._awoke)
			{
				try
				{
					this.Refresh();
				}
				finally
				{
					this._awoke = true;
				}
			}
			return this.act;
		}
	}

	// Token: 0x170009F0 RID: 2544
	// (get) Token: 0x06002ECE RID: 11982 RVA: 0x000B27CC File Offset: 0x000B09CC
	public bool exists
	{
		get
		{
			return this._implemented && (this._implemented = this.implementation);
		}
	}

	// Token: 0x170009F1 RID: 2545
	// (get) Token: 0x06002ECF RID: 11983 RVA: 0x000B27FC File Offset: 0x000B09FC
	public global::Activatable driver
	{
		get
		{
			return this;
		}
	}

	// Token: 0x170009F2 RID: 2546
	// (get) Token: 0x06002ED0 RID: 11984 RVA: 0x000B2800 File Offset: 0x000B0A00
	public global::ActivationToggleState toggleState
	{
		get
		{
			return (!this.canToggle || !this.implementation) ? global::ActivationToggleState.Unspecified : this.actToggle.ActGetToggleState();
		}
	}

	// Token: 0x170009F3 RID: 2547
	// (get) Token: 0x06002ED1 RID: 11985 RVA: 0x000B283C File Offset: 0x000B0A3C
	public bool isToggle
	{
		get
		{
			return this.canToggle;
		}
	}

	// Token: 0x06002ED2 RID: 11986 RVA: 0x000B2844 File Offset: 0x000B0A44
	private void Refresh()
	{
		this.implementation = this._implementation;
		this._implementation = null;
		this.act = (this.implementation as global::IActivatable);
		this.canAct = (this.act != null);
		if (this.canAct)
		{
			this.actToggle = (this.implementation as global::IActivatableToggle);
			this.canToggle = (this.actToggle != null);
			global::IActivatableFill activatableFill = this.implementation as global::IActivatableFill;
			if (activatableFill != null)
			{
				activatableFill.ActivatableChanged(this, true);
			}
			global::IActivatableInfo activatableInfo = this.implementation as global::IActivatableInfo;
			if (activatableInfo != null)
			{
				activatableInfo.ActInfo(out this.info);
			}
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("implementation is null or does not implement IActivatable", this);
		}
	}

	// Token: 0x06002ED3 RID: 11987 RVA: 0x000B2900 File Offset: 0x000B0B00
	private void Awake()
	{
		if (!this._awoke)
		{
			try
			{
				this.Refresh();
			}
			finally
			{
				this._awoke = true;
			}
		}
	}

	// Token: 0x06002ED4 RID: 11988 RVA: 0x000B2948 File Offset: 0x000B0B48
	private void OnDestroy()
	{
		if (this.implementation)
		{
			global::IActivatableFill activatableFill = this.implementation as global::IActivatableFill;
			if (activatableFill != null)
			{
				activatableFill.ActivatableChanged(this, false);
			}
		}
		this.implementation = null;
		this.canAct = false;
		this.canToggle = false;
		this.act = null;
		this.actToggle = null;
		this.info = default(global::ActivatableInfo);
	}

	// Token: 0x06002ED5 RID: 11989 RVA: 0x000B29B4 File Offset: 0x000B0BB4
	public global::ActivationResult Activate(ulong timestamp)
	{
		return this.Activate(null, timestamp);
	}

	// Token: 0x06002ED6 RID: 11990 RVA: 0x000B29C0 File Offset: 0x000B0BC0
	public global::ActivationResult Activate(global::Character instigator, ulong timestamp)
	{
		if (!this.info.alwaysToggleActTrigger || !this.canToggle)
		{
			return this.Act(instigator, timestamp);
		}
		global::ActivationToggleState toggleState = this.toggleState;
		global::ActivationToggleState activationToggleState = toggleState;
		if (activationToggleState == global::ActivationToggleState.On)
		{
			return this.Act(instigator, global::ActivationToggleState.Off, timestamp);
		}
		if (activationToggleState != global::ActivationToggleState.Off)
		{
			return global::ActivationResult.Fail_BadToggle;
		}
		return this.Act(instigator, global::ActivationToggleState.On, timestamp);
	}

	// Token: 0x06002ED7 RID: 11991 RVA: 0x000B2A24 File Offset: 0x000B0C24
	public global::ActivationResult Activate()
	{
		return this.Activate(null, global::NetCull.timeInMillis);
	}

	// Token: 0x06002ED8 RID: 11992 RVA: 0x000B2A34 File Offset: 0x000B0C34
	private global::ActivationResult Act(global::Character instigator, ulong timestamp)
	{
		return (!this.canAct) ? global::ActivationResult.Error_Implementation : ((!this.implementation) ? global::ActivationResult.Error_Destroyed : this.act.ActTrigger(instigator, timestamp));
	}

	// Token: 0x06002ED9 RID: 11993 RVA: 0x000B2A78 File Offset: 0x000B0C78
	private global::ActivationResult Act(global::Character instigator, global::ActivationToggleState state, ulong timestamp)
	{
		return (!this.canToggle) ? global::ActivationResult.Error_Implementation : ((!this.implementation) ? global::ActivationResult.Error_Destroyed : this.actToggle.ActTrigger(instigator, state, timestamp));
	}

	// Token: 0x06002EDA RID: 11994 RVA: 0x000B2AB0 File Offset: 0x000B0CB0
	public global::ActivationResult Activate(bool on, global::Character instigator, ulong timestamp)
	{
		if (!this.canToggle)
		{
			global::UnityEngine.Debug.LogWarning("Activate with on parameter was used on a non Togglable Activatable - rerouting to IActivatable", this.implementation);
			return this.Activate(instigator, timestamp);
		}
		if (this.info.requiresInstigator && !instigator)
		{
			return global::ActivationResult.Fail_RequiresInstigator;
		}
		return this.Act(instigator, (!on) ? global::ActivationToggleState.Off : global::ActivationToggleState.On, timestamp);
	}

	// Token: 0x06002EDB RID: 11995 RVA: 0x000B2B14 File Offset: 0x000B0D14
	public global::ActivationResult Activate(bool on, global::Character instigator)
	{
		return this.Activate(on, instigator, global::NetCull.timeInMillis);
	}

	// Token: 0x06002EDC RID: 11996 RVA: 0x000B2B24 File Offset: 0x000B0D24
	public global::ActivationResult Activate(bool on, ulong timestamp)
	{
		return this.Activate(on, null, timestamp);
	}

	// Token: 0x06002EDD RID: 11997 RVA: 0x000B2B30 File Offset: 0x000B0D30
	public global::ActivationResult Activate(bool on)
	{
		return this.Activate(on, null, global::NetCull.timeInMillis);
	}

	// Token: 0x06002EDE RID: 11998 RVA: 0x000B2B40 File Offset: 0x000B0D40
	private global::ActivationResult ActRoute(bool? on, global::Character character, ulong timestamp)
	{
		if (on != null)
		{
			return this.Activate(on.Value, character, timestamp);
		}
		return this.Activate(character, timestamp);
	}

	// Token: 0x06002EDF RID: 11999 RVA: 0x000B2B74 File Offset: 0x000B0D74
	private global::ActivationResult ActRoute(bool? on, global::Controllable controllable, ulong timestamp)
	{
		return this.ActRoute(on, (!controllable) ? null : controllable.GetComponent<global::Character>(), timestamp);
	}

	// Token: 0x06002EE0 RID: 12000 RVA: 0x000B2BA0 File Offset: 0x000B0DA0
	private global::ActivationResult ActRoute(bool? on, global::PlayerClient sender, ulong timestamp)
	{
		return this.ActRoute(on, (!sender || !sender.controllable) ? null : sender.controllable, timestamp);
	}

	// Token: 0x06002EE1 RID: 12001 RVA: 0x000B2BDC File Offset: 0x000B0DDC
	private global::ActivationResult ActRoute(bool? on, global::uLink.NetworkPlayer sender, ulong timestamp)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		global::PlayerClient sender2;
		if (serverManagement)
		{
			serverManagement.GetPlayerClient(sender, out sender2);
		}
		else
		{
			sender2 = null;
		}
		return this.ActRoute(on, sender2, timestamp);
	}

	// Token: 0x06002EE2 RID: 12002 RVA: 0x000B2C14 File Offset: 0x000B0E14
	public global::ActivationResult Activate(ref global::uLink.NetworkMessageInfo info)
	{
		return this.ActRoute(null, info.sender, info.timestampInMillis);
	}

	// Token: 0x06002EE3 RID: 12003 RVA: 0x000B2C40 File Offset: 0x000B0E40
	public global::ActivationResult Activate(bool on, ref global::uLink.NetworkMessageInfo info)
	{
		return this.ActRoute(new bool?(on), info.sender, info.timestampInMillis);
	}

	// Token: 0x06002EE4 RID: 12004 RVA: 0x000B2C5C File Offset: 0x000B0E5C
	private void Reset()
	{
		if (!this.canAct)
		{
			foreach (global::Facepunch.MonoBehaviour monoBehaviour in base.GetComponents<global::Facepunch.MonoBehaviour>())
			{
				if (monoBehaviour != this && monoBehaviour is global::IActivatable)
				{
					this._implementation = monoBehaviour;
					break;
				}
			}
		}
	}

	// Token: 0x04001867 RID: 6247
	[global::UnityEngine.SerializeField]
	private global::Facepunch.MonoBehaviour _implementation;

	// Token: 0x04001868 RID: 6248
	private global::Facepunch.MonoBehaviour implementation;

	// Token: 0x04001869 RID: 6249
	private global::IActivatable act;

	// Token: 0x0400186A RID: 6250
	private bool canAct;

	// Token: 0x0400186B RID: 6251
	private global::IActivatableToggle actToggle;

	// Token: 0x0400186C RID: 6252
	private bool canToggle;

	// Token: 0x0400186D RID: 6253
	private global::ActivatableInfo info;

	// Token: 0x0400186E RID: 6254
	[global::System.NonSerialized]
	private bool _implemented;

	// Token: 0x0400186F RID: 6255
	[global::System.NonSerialized]
	private bool _awoke;
}
