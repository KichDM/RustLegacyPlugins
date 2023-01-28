using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;
using Rust;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x02000778 RID: 1912
[global::NGCAutoAddScript]
[global::UnityEngine.AddComponentMenu("")]
public abstract class BasicDoor : global::Facepunch.NetBehaviour, global::IServerSaveable, global::IActivatable, global::IActivatableToggle, global::IContextRequestable, global::IContextRequestableMenu, global::IContextRequestableQuick, global::IContextRequestableStatus, global::IContextRequestableText, global::IContextRequestableSoleAccess, global::IContextRequestablePointText, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06003F7E RID: 16254 RVA: 0x000E27F8 File Offset: 0x000E09F8
	protected BasicDoor()
	{
	}

	// Token: 0x06003F7F RID: 16255 RVA: 0x000E2838 File Offset: 0x000E0A38
	global::ActivationResult global::IActivatableToggle.ActTrigger(global::Character instigator, global::ActivationToggleState toggleTarget, ulong timestamp)
	{
		return this.ActTrigger(instigator, toggleTarget, timestamp);
	}

	// Token: 0x06003F80 RID: 16256 RVA: 0x000E2844 File Offset: 0x000E0A44
	global::ActivationToggleState global::IActivatableToggle.ActGetToggleState()
	{
		return this.ActGetToggleState();
	}

	// Token: 0x06003F81 RID: 16257 RVA: 0x000E284C File Offset: 0x000E0A4C
	global::ActivationResult global::IActivatable.ActTrigger(global::Character instigator, ulong timestamp)
	{
		return this.ActTrigger(instigator, (!this.on) ? global::ActivationToggleState.On : global::ActivationToggleState.Off, timestamp);
	}

	// Token: 0x06003F82 RID: 16258 RVA: 0x000E2868 File Offset: 0x000E0A68
	global::ContextExecution global::IContextRequestable.ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return this.ContextQuery(controllable, timestamp);
	}

	// Token: 0x06003F83 RID: 16259 RVA: 0x000E2874 File Offset: 0x000E0A74
	global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> global::IContextRequestableMenu.ContextQueryMenu(global::Controllable controllable, ulong timestamp)
	{
		return this.ContextQueryMenu(controllable, timestamp);
	}

	// Token: 0x06003F84 RID: 16260 RVA: 0x000E2880 File Offset: 0x000E0A80
	global::ContextResponse global::IContextRequestableMenu.ContextRespondMenu(global::Controllable controllable, global::ContextActionPrototype action, ulong timestamp)
	{
		return this.ContextRespondMenu(controllable, action, timestamp);
	}

	// Token: 0x06003F85 RID: 16261 RVA: 0x000E288C File Offset: 0x000E0A8C
	global::ContextResponse global::IContextRequestableQuick.ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		return this.ContextRespond_OpenCloseToggle(controllable, timestamp);
	}

	// Token: 0x17000BE6 RID: 3046
	// (get) Token: 0x06003F86 RID: 16262 RVA: 0x000E2898 File Offset: 0x000E0A98
	// (set) Token: 0x06003F87 RID: 16263 RVA: 0x000E28A8 File Offset: 0x000E0AA8
	public bool startsOpened
	{
		get
		{
			return (this.startConfig & global::BasicDoor.RunFlags.OpenedForward) == global::BasicDoor.RunFlags.OpenedForward;
		}
		protected set
		{
			if (value)
			{
				this.startConfig |= global::BasicDoor.RunFlags.OpenedForward;
			}
			else
			{
				this.startConfig &= (global::BasicDoor.RunFlags)(-2);
			}
		}
	}

	// Token: 0x17000BE7 RID: 3047
	// (get) Token: 0x06003F88 RID: 16264 RVA: 0x000E28E0 File Offset: 0x000E0AE0
	// (set) Token: 0x06003F89 RID: 16265 RVA: 0x000E28F0 File Offset: 0x000E0AF0
	public bool defaultReversed
	{
		get
		{
			return (this.startConfig & (global::BasicDoor.RunFlags)0x12) == global::BasicDoor.RunFlags.ClosedReverse;
		}
		protected set
		{
			if (value)
			{
				this.startConfig |= global::BasicDoor.RunFlags.ClosedReverse;
			}
			else
			{
				this.startConfig &= (global::BasicDoor.RunFlags)(-3);
			}
		}
	}

	// Token: 0x17000BE8 RID: 3048
	// (get) Token: 0x06003F8A RID: 16266 RVA: 0x000E2928 File Offset: 0x000E0B28
	// (set) Token: 0x06003F8B RID: 16267 RVA: 0x000E2938 File Offset: 0x000E0B38
	public bool reverseOpenDisabled
	{
		get
		{
			return (this.startConfig & global::BasicDoor.RunFlags.ClosedNoReverse) == global::BasicDoor.RunFlags.ClosedNoReverse;
		}
		protected set
		{
			if (value)
			{
				this.startConfig |= global::BasicDoor.RunFlags.ClosedNoReverse;
			}
			else
			{
				this.startConfig &= (global::BasicDoor.RunFlags)(-0x11);
			}
		}
	}

	// Token: 0x17000BE9 RID: 3049
	// (get) Token: 0x06003F8C RID: 16268 RVA: 0x000E2964 File Offset: 0x000E0B64
	// (set) Token: 0x06003F8D RID: 16269 RVA: 0x000E2970 File Offset: 0x000E0B70
	public bool canOpenReverse
	{
		get
		{
			return !this.reverseOpenDisabled;
		}
		protected set
		{
			this.reverseOpenDisabled = !value;
		}
	}

	// Token: 0x17000BEA RID: 3050
	// (get) Token: 0x06003F8E RID: 16270 RVA: 0x000E297C File Offset: 0x000E0B7C
	// (set) Token: 0x06003F8F RID: 16271 RVA: 0x000E298C File Offset: 0x000E0B8C
	public bool fixedUpdate
	{
		get
		{
			return (this.startConfig & global::BasicDoor.RunFlags.FixedUpdateClosedForward) == global::BasicDoor.RunFlags.FixedUpdateClosedForward;
		}
		protected set
		{
			if (value)
			{
				this.startConfig |= global::BasicDoor.RunFlags.FixedUpdateClosedForward;
			}
			else
			{
				this.startConfig &= (global::BasicDoor.RunFlags)(-9);
			}
		}
	}

	// Token: 0x17000BEB RID: 3051
	// (get) Token: 0x06003F90 RID: 16272 RVA: 0x000E29C4 File Offset: 0x000E0BC4
	// (set) Token: 0x06003F91 RID: 16273 RVA: 0x000E29D4 File Offset: 0x000E0BD4
	public bool pointText
	{
		get
		{
			return (this.startConfig & global::BasicDoor.RunFlags.ClosedForwardWithPointText) == global::BasicDoor.RunFlags.ClosedForwardWithPointText;
		}
		protected set
		{
			if (value)
			{
				this.startConfig |= global::BasicDoor.RunFlags.ClosedForwardWithPointText;
			}
			else
			{
				this.startConfig &= (global::BasicDoor.RunFlags)(-5);
			}
		}
	}

	// Token: 0x17000BEC RID: 3052
	// (get) Token: 0x06003F92 RID: 16274 RVA: 0x000E2A0C File Offset: 0x000E0C0C
	// (set) Token: 0x06003F93 RID: 16275 RVA: 0x000E2A1C File Offset: 0x000E0C1C
	public bool waitsTarget
	{
		get
		{
			return (this.startConfig & global::BasicDoor.RunFlags.ClosedForwardWaits) == global::BasicDoor.RunFlags.ClosedForwardWaits;
		}
		protected set
		{
			if (value)
			{
				this.startConfig |= global::BasicDoor.RunFlags.ClosedForwardWaits;
			}
			else
			{
				this.startConfig &= (global::BasicDoor.RunFlags)(-0x21);
			}
		}
	}

	// Token: 0x06003F94 RID: 16276 RVA: 0x000E2A48 File Offset: 0x000E0C48
	protected global::ActivationToggleState ActGetToggleState()
	{
		return (!this.on) ? global::ActivationToggleState.Off : global::ActivationToggleState.On;
	}

	// Token: 0x06003F95 RID: 16277 RVA: 0x000E2A5C File Offset: 0x000E0C5C
	protected global::ActivationResult ActTrigger(global::Character instigator, global::ActivationToggleState toggleTarget, ulong timestamp)
	{
		if (toggleTarget != global::ActivationToggleState.On)
		{
			if (toggleTarget != global::ActivationToggleState.Off)
			{
				return global::ActivationResult.Fail_BadToggle;
			}
			if (!this.on)
			{
				return global::ActivationResult.Fail_Redundant;
			}
			this.ToggleStateServer(timestamp, instigator);
			return (!this.on) ? global::ActivationResult.Success : global::ActivationResult.Fail_Busy;
		}
		else
		{
			if (this.on)
			{
				return global::ActivationResult.Fail_Redundant;
			}
			this.ToggleStateServer(timestamp, instigator);
			return (!this.on) ? global::ActivationResult.Fail_Busy : global::ActivationResult.Success;
		}
	}

	// Token: 0x17000BED RID: 3053
	// (get) Token: 0x06003F96 RID: 16278 RVA: 0x000E2AD4 File Offset: 0x000E0CD4
	protected static ulong time
	{
		get
		{
			return global::NetCull.timeInMillis;
		}
	}

	// Token: 0x17000BEE RID: 3054
	// (get) Token: 0x06003F97 RID: 16279 RVA: 0x000E2ADC File Offset: 0x000E0CDC
	protected double elapsed
	{
		get
		{
			if (this.timeStampChanged != null)
			{
				return (global::BasicDoor.time - this.timeStampChanged.Value) / 1000.0;
			}
			return double.PositiveInfinity;
		}
	}

	// Token: 0x06003F98 RID: 16280 RVA: 0x000E2B18 File Offset: 0x000E0D18
	private void CaptureOriginals()
	{
		if (!this.capturedOriginals)
		{
			this.originalLocalRotation = base.transform.localRotation;
			this.originalLocalPosition = base.transform.localPosition;
			this.originalLocalScale = base.transform.localScale;
			this.capturedOriginals = true;
		}
	}

	// Token: 0x06003F99 RID: 16281 RVA: 0x000E2B6C File Offset: 0x000E0D6C
	protected void StartOpeningOrClosing(sbyte open, ulong timestamp)
	{
		bool flag = this.openingInReverse;
		global::BasicDoor.State state;
		long num2;
		if ((int)open != 0)
		{
			if (this.state == global::BasicDoor.State.Closed)
			{
				flag = (this.canOpenReverse && (int)open == 2);
			}
			state = global::BasicDoor.State.Opened;
			if (state == this.state || state == this.state + 1)
			{
				return;
			}
			double elapsed = this.elapsed;
			double num = ((double)this.durationClose > 0.0) ? ((elapsed < (double)this.durationClose) ? (1.0 - elapsed / (double)this.durationClose) : 0.0) : 0.0;
			num2 = (long)(num * (double)this.durationOpen * 1000.0);
		}
		else
		{
			state = global::BasicDoor.State.Closed;
			if (state == this.state || state == this.state + 1)
			{
				return;
			}
			double elapsed2 = this.elapsed;
			double num3 = ((double)this.durationOpen > 0.0) ? ((elapsed2 < (double)this.durationOpen) ? (elapsed2 / (double)this.durationOpen) : 1.0) : 1.0;
			num2 = (long)((1.0 - num3) * (double)this.durationClose * 1000.0);
		}
		if (num2 > (long)timestamp)
		{
			this.timeStampChanged = null;
		}
		else
		{
			this.timeStampChanged = new ulong?(timestamp - (ulong)num2);
		}
		base.enabled = true;
		this.openingInReverse = flag;
		this.target = state;
	}

	// Token: 0x06003F9A RID: 16282 RVA: 0x000E2D0C File Offset: 0x000E0F0C
	protected void DoDoorFraction(double fractionOpen)
	{
		if (this.openingInReverse)
		{
			this.OnDoorFraction(-fractionOpen);
		}
		else
		{
			this.OnDoorFraction(fractionOpen);
		}
	}

	// Token: 0x06003F9B RID: 16283
	protected abstract void OnDoorFraction(double fractionOpen);

	// Token: 0x06003F9C RID: 16284 RVA: 0x000E2D30 File Offset: 0x000E0F30
	private void DoorUpdate()
	{
		double elapsed = this.elapsed;
		if (elapsed <= 0.0)
		{
			return;
		}
		bool flag = this.state != this.target;
		switch (this.target)
		{
		case global::BasicDoor.State.Opened:
			if (elapsed >= (double)this.durationOpen)
			{
				base.enabled = false;
				this.state = global::BasicDoor.State.Opened;
				this.DoDoorFraction(1.0);
				if (flag)
				{
					this.OnDoorEndOpen();
				}
			}
			else
			{
				if (this.state == global::BasicDoor.State.Closed)
				{
					this.OnDoorStartOpen();
				}
				this.state = global::BasicDoor.State.Opening;
				this.DoDoorFraction(elapsed / (double)this.durationOpen);
			}
			break;
		case global::BasicDoor.State.Closed:
			if (elapsed >= (double)this.durationClose)
			{
				base.enabled = false;
				this.state = global::BasicDoor.State.Closed;
				this.DoDoorFraction(0.0);
				if (flag)
				{
					this.OnDoorEndClose();
				}
			}
			else
			{
				if (this.state == global::BasicDoor.State.Opened)
				{
					this.OnDoorStartClose();
				}
				this.state = global::BasicDoor.State.Closing;
				this.DoDoorFraction(1.0 - elapsed / (double)this.durationClose);
			}
			break;
		}
	}

	// Token: 0x06003F9D RID: 16285 RVA: 0x000E2E60 File Offset: 0x000E1060
	protected void LateUpdate()
	{
		if (!this.fixedUpdate)
		{
			this.DoorUpdate();
		}
	}

	// Token: 0x06003F9E RID: 16286 RVA: 0x000E2E74 File Offset: 0x000E1074
	protected void FixedUpdate()
	{
		if (this.fixedUpdate)
		{
			this.DoorUpdate();
		}
	}

	// Token: 0x06003F9F RID: 16287 RVA: 0x000E2E88 File Offset: 0x000E1088
	protected global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick | global::ContextExecution.Menu;
	}

	// Token: 0x06003FA0 RID: 16288 RVA: 0x000E2E8C File Offset: 0x000E108C
	protected global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> ContextQueryMenu(global::Controllable controllable, ulong timestamp)
	{
		global::NetUser user = controllable.netUser;
		if (object.ReferenceEquals(user, null))
		{
			yield break;
		}
		global::DeployableObject deployable = base.GetComponent<global::DeployableObject>();
		global::DeployableObject isDeployable = deployable;
		bool isOwner = isDeployable && deployable.ownerID == user.userID;
		bool containsDoorLock = this.containsDoorLock;
		bool doorLockIsLocked = containsDoorLock && this.IsDoorLockActive();
		bool doorLockIsUnlockedForUser = containsDoorLock && (this.IsUserUnlocked(user.userID) || isOwner);
		bool canOpenOrClose = !containsDoorLock || isOwner || doorLockIsUnlockedForUser || !doorLockIsLocked;
		bool canAlterLockActiveState = containsDoorLock && isOwner;
		if (canOpenOrClose)
		{
			yield return (!this.on) ? global::BasicDoor.DoorActions.Open : global::BasicDoor.DoorActions.Close;
		}
		if (!doorLockIsUnlockedForUser)
		{
			yield return global::BasicDoor.DoorActions.EnterCode;
		}
		if (canAlterLockActiveState)
		{
			yield return (!doorLockIsLocked) ? global::BasicDoor.DoorActions.Lock : global::BasicDoor.DoorActions.Unlock;
		}
		if (isOwner && containsDoorLock)
		{
			yield return global::BasicDoor.DoorActions.ChangeLock;
		}
		yield break;
	}

	// Token: 0x06003FA1 RID: 16289 RVA: 0x000E2EC0 File Offset: 0x000E10C0
	protected global::ContextResponse ContextRespondMenu(global::Controllable controllable, global::ContextActionPrototype action, ulong timestamp)
	{
		bool flag;
		if ((flag = (action == global::BasicDoor.DoorActions.Open)) || action == global::BasicDoor.DoorActions.Close)
		{
			if (flag != this.on)
			{
				return this.ContextRespond_OpenCloseToggle(controllable, timestamp);
			}
			return global::ContextResponse.FailBreak;
		}
		else
		{
			if (action == global::BasicDoor.DoorActions.Lock || action == global::BasicDoor.DoorActions.Unlock)
			{
				bool flag2 = action == global::BasicDoor.DoorActions.Lock;
				this.SetDoorLockActive(flag2);
				global::Rust.Notice.Popup(controllable.networkView.owner, (!flag2) ? "" : "", "Door is now " + ((!flag2) ? "unlocked" : "locked."), 4f);
				return global::ContextResponse.DoneBreak;
			}
			if (action == global::BasicDoor.DoorActions.ChangeLock)
			{
				global::ConsoleNetworker.SendClientCommand(controllable.networkView.owner, "lockentry.show true");
			}
			else
			{
				if (action != global::BasicDoor.DoorActions.EnterCode)
				{
					return global::ContextResponse.FailBreak;
				}
				global::ConsoleNetworker.SendClientCommand(controllable.networkView.owner, "lockentry.show false");
			}
			return global::ContextResponse.DoneBreak;
		}
	}

	// Token: 0x06003FA2 RID: 16290 RVA: 0x000E2FBC File Offset: 0x000E11BC
	protected global::ContextResponse ContextRespond_OpenCloseToggle(global::Controllable controllable, ulong timestamp)
	{
		ulong? num = this.lastToggleTimeStamp;
		ulong? num2 = (num == null) ? null : new ulong?(timestamp - num.Value);
		if (num2 != null && num2.Value <= this.minimumTimeBetweenOpenClose && this.lastToggleTimeStamp != 0UL)
		{
			return global::ContextResponse.FailBreak;
		}
		if (this.ToggleStateServer(timestamp, controllable))
		{
			this.lastToggleTimeStamp = new ulong?(timestamp);
			return global::ContextResponse.DoneBreak;
		}
		return global::ContextResponse.FailBreak;
	}

	// Token: 0x17000BEF RID: 3055
	// (get) Token: 0x06003FA3 RID: 16291 RVA: 0x000E3060 File Offset: 0x000E1260
	public bool containsDoorLock
	{
		get
		{
			return base.GetComponent<global::LockableObject>() != null;
		}
	}

	// Token: 0x06003FA4 RID: 16292 RVA: 0x000E3070 File Offset: 0x000E1270
	public bool IsUserUnlocked(ulong userID)
	{
		return base.GetComponent<global::LockableObject>().HasAccess(userID);
	}

	// Token: 0x06003FA5 RID: 16293 RVA: 0x000E3080 File Offset: 0x000E1280
	public bool IsDoorLockActive()
	{
		return base.GetComponent<global::LockableObject>().IsLockActive();
	}

	// Token: 0x06003FA6 RID: 16294 RVA: 0x000E3090 File Offset: 0x000E1290
	public void SetDoorLockActive(bool locked)
	{
		base.GetComponent<global::LockableObject>().SetLockActive(locked);
	}

	// Token: 0x06003FA7 RID: 16295 RVA: 0x000E30A0 File Offset: 0x000E12A0
	private void PlaySound(global::UnityEngine.AudioClip clip)
	{
	}

	// Token: 0x06003FA8 RID: 16296 RVA: 0x000E30A4 File Offset: 0x000E12A4
	protected void OnDoorStartOpen()
	{
		this.PlaySound(this.openSound);
	}

	// Token: 0x06003FA9 RID: 16297 RVA: 0x000E30B4 File Offset: 0x000E12B4
	protected void OnDoorEndOpen()
	{
		this.PlaySound(this.openedSound);
		this.DisableObstacle();
	}

	// Token: 0x06003FAA RID: 16298 RVA: 0x000E30C8 File Offset: 0x000E12C8
	protected virtual void OnDoorStartClose()
	{
		this.PlaySound(this.closeSound);
	}

	// Token: 0x06003FAB RID: 16299 RVA: 0x000E30D8 File Offset: 0x000E12D8
	protected virtual void OnDoorEndClose()
	{
		this.PlaySound(this.closedSound);
		this.EnableObstacle();
	}

	// Token: 0x17000BF0 RID: 3056
	// (get) Token: 0x06003FAC RID: 16300 RVA: 0x000E30EC File Offset: 0x000E12EC
	private bool on
	{
		get
		{
			return this.target == global::BasicDoor.State.Opened || this.target == global::BasicDoor.State.Opening;
		}
	}

	// Token: 0x06003FAD RID: 16301 RVA: 0x000E3108 File Offset: 0x000E1308
	private global::BasicDoor.Side CalculateOpenWay()
	{
		return (!this.openingInReverse && this.canOpenReverse) ? global::BasicDoor.Side.Reverse : global::BasicDoor.Side.Forward;
	}

	// Token: 0x06003FAE RID: 16302 RVA: 0x000E3128 File Offset: 0x000E1328
	private global::BasicDoor.Side CalculateOpenWay(global::UnityEngine.Vector3 worldPoint)
	{
		global::BasicDoor.IdealSide idealSide;
		if (!this.canOpenReverse || (int)(idealSide = this.IdealSideForPoint(worldPoint)) == 1)
		{
			return global::BasicDoor.Side.Forward;
		}
		if ((int)idealSide == 0)
		{
			return (!this.openingInReverse) ? global::BasicDoor.Side.Reverse : global::BasicDoor.Side.Forward;
		}
		return global::BasicDoor.Side.Reverse;
	}

	// Token: 0x06003FAF RID: 16303 RVA: 0x000E3170 File Offset: 0x000E1370
	private global::BasicDoor.Side CalculateOpenWay(global::UnityEngine.Vector3? worldPoint)
	{
		return (worldPoint == null) ? this.CalculateOpenWay() : this.CalculateOpenWay(worldPoint.Value);
	}

	// Token: 0x06003FB0 RID: 16304
	protected abstract global::BasicDoor.IdealSide IdealSideForPoint(global::UnityEngine.Vector3 worldPoint);

	// Token: 0x06003FB1 RID: 16305 RVA: 0x000E31A4 File Offset: 0x000E13A4
	private bool ToggleStateServer(global::UnityEngine.Vector3? openerPoint, ulong timestamp, bool? fallbackReverse = null)
	{
		if (this.serverLastTimeStamp == null || timestamp > this.serverLastTimeStamp.Value)
		{
			if (this.waitsTarget && (this.state == global::BasicDoor.State.Opening || this.state == global::BasicDoor.State.Closing))
			{
				return false;
			}
			this.serverLastTimeStamp = new ulong?(timestamp);
			global::BasicDoor.State state = this.target;
			bool flag = this.openingInReverse;
			if (this.target == global::BasicDoor.State.Closed)
			{
				if (openerPoint != null || fallbackReverse == null)
				{
					if (this.CalculateOpenWay(openerPoint) == global::BasicDoor.Side.Forward)
					{
						this.StartOpeningOrClosing(1, timestamp);
					}
					else
					{
						this.StartOpeningOrClosing(2, timestamp);
					}
				}
				else
				{
					this.StartOpeningOrClosing((!((fallbackReverse == null) ? this.defaultReversed : fallbackReverse.Value)) ? 1 : 2, timestamp);
				}
			}
			else
			{
				this.StartOpeningOrClosing(0, timestamp);
			}
			if (state != this.target || flag != this.openingInReverse)
			{
				this.InvalidateState(timestamp);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06003FB2 RID: 16306 RVA: 0x000E32BC File Offset: 0x000E14BC
	private bool ToggleStateServer(ulong timestamp, global::Character instigator)
	{
		if (instigator)
		{
			return this.ToggleStateServer(new global::UnityEngine.Vector3?(instigator.eyesOrigin), timestamp, null);
		}
		return this.ToggleStateServer(null, timestamp, null);
	}

	// Token: 0x06003FB3 RID: 16307 RVA: 0x000E330C File Offset: 0x000E150C
	private bool ToggleStateServer(ulong timestamp, global::Controllable controllable)
	{
		if (!controllable)
		{
			return this.ToggleStateServer(null, timestamp, null);
		}
		global::Character component = controllable.GetComponent<global::Character>();
		global::DeployableObject component2 = base.GetComponent<global::DeployableObject>();
		global::LockableObject component3 = base.GetComponent<global::LockableObject>();
		if ((!component2 || !component2.BelongsTo(controllable)) && component3 && component3.IsLockActive() && !component3.HasAccess(controllable))
		{
			global::Rust.Notice.Popup(component.playerClient.netPlayer, "", "The door is locked!", 4f);
			return false;
		}
		global::DeployableObject component4 = base.GetComponent<global::DeployableObject>();
		if (component4)
		{
			component4.Touched();
		}
		if (component)
		{
			return this.ToggleStateServer(new global::UnityEngine.Vector3?(component.eyesOrigin), timestamp, null);
		}
		return this.ToggleStateServer(new global::UnityEngine.Vector3?(controllable.transform.position), timestamp, null);
	}

	// Token: 0x17000BF1 RID: 3057
	// (get) Token: 0x06003FB4 RID: 16308 RVA: 0x000E3410 File Offset: 0x000E1610
	private sbyte defaultStateValue
	{
		get
		{
			if (!this.startsOpened)
			{
				return 0;
			}
			if (this.defaultReversed)
			{
				return 2;
			}
			return 1;
		}
	}

	// Token: 0x17000BF2 RID: 3058
	// (get) Token: 0x06003FB5 RID: 16309 RVA: 0x000E3430 File Offset: 0x000E1630
	private sbyte targetStateValue
	{
		get
		{
			if (this.target != global::BasicDoor.State.Opened)
			{
				return 0;
			}
			if (this.openingInReverse)
			{
				return 2;
			}
			return 1;
		}
	}

	// Token: 0x06003FB6 RID: 16310 RVA: 0x000E3450 File Offset: 0x000E1650
	private void InvalidateState(ulong timestamp)
	{
		sbyte targetStateValue = this.targetStateValue;
		global::uLink.RPCMode rpcMode;
		if (this.isStaticDoor)
		{
			rpcMode = 1;
		}
		else
		{
			global::NetCull.RemoveRPCsByName(global::NetEntityID.Get(this), "DOo");
			rpcMode = 5;
		}
		global::NetCull.RPC<sbyte, ulong>(this, "DOo", rpcMode, targetStateValue, timestamp);
	}

	// Token: 0x06003FB7 RID: 16311 RVA: 0x000E3498 File Offset: 0x000E1698
	private void InitializeObstacle()
	{
		global::UnityEngine.NavMeshObstacle component = base.GetComponent<global::UnityEngine.NavMeshObstacle>();
		if (component)
		{
			this.hasObstacle = true;
			this.obstacle = component;
			this.obstacle.enabled = false;
		}
	}

	// Token: 0x06003FB8 RID: 16312 RVA: 0x000E34D4 File Offset: 0x000E16D4
	private void OnObstacleEnabled(bool enable)
	{
		if (this.hasObstacle)
		{
			this.obstacle.enabled = enable;
		}
	}

	// Token: 0x06003FB9 RID: 16313 RVA: 0x000E34F0 File Offset: 0x000E16F0
	protected void EnableObstacle()
	{
		if (this.hasObstacle)
		{
			bool? flag = this.obstacleState;
			if (flag == null || !flag.Value)
			{
				this.OnObstacleEnabled(true);
				this.obstacleState = new bool?(true);
			}
		}
	}

	// Token: 0x06003FBA RID: 16314 RVA: 0x000E3540 File Offset: 0x000E1740
	protected void DisableObstacle()
	{
		if (this.hasObstacle)
		{
			bool? flag = this.obstacleState;
			if (flag == null || flag.Value)
			{
				this.OnObstacleEnabled(false);
				this.obstacleState = new bool?(false);
			}
		}
	}

	// Token: 0x06003FBB RID: 16315 RVA: 0x000E3590 File Offset: 0x000E1790
	[global::UnityEngine.RPC]
	protected void DOo(sbyte open, ulong timestamp)
	{
	}

	// Token: 0x06003FBC RID: 16316 RVA: 0x000E3594 File Offset: 0x000E1794
	[global::UnityEngine.RPC]
	protected void DOc(sbyte open)
	{
	}

	// Token: 0x06003FBD RID: 16317 RVA: 0x000E3598 File Offset: 0x000E1798
	protected void Awake()
	{
		this.CaptureOriginals();
		this.openingInReverse = this.defaultReversed;
		this.InitializeObstacle();
		if (this.startsOpened)
		{
			this.target = (this.state = global::BasicDoor.State.Opened);
			this.DoDoorFraction(1.0);
			this.DisableObstacle();
		}
		else
		{
			this.target = (this.state = global::BasicDoor.State.Closed);
			this.DoDoorFraction(0.0);
			this.EnableObstacle();
		}
		base.enabled = false;
		global::Facepunch.NetworkView networkView;
		if ((networkView = base.networkView) && networkView.viewID.isManual)
		{
			this.isStaticDoor = true;
			this.addedListener = true;
			global::GameEvent.PlayerConnected += this.PlayerConnected;
		}
	}

	// Token: 0x06003FBE RID: 16318 RVA: 0x000E3664 File Offset: 0x000E1864
	protected void OnDestroy()
	{
		if (this.addedListener)
		{
			global::GameEvent.PlayerConnected -= this.PlayerConnected;
		}
	}

	// Token: 0x06003FBF RID: 16319 RVA: 0x000E3684 File Offset: 0x000E1884
	protected void PlayerConnected(global::PlayerClient player)
	{
		if (!this.isStaticDoor)
		{
			return;
		}
		base.networkView.RPC<sbyte>("DOc", player.netPlayer, this.targetStateValue);
	}

	// Token: 0x06003FC0 RID: 16320 RVA: 0x000E36BC File Offset: 0x000E18BC
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder> recycler = global::RustProto.objectDoor.Recycler())
		{
			global::RustProto.objectDoor.Builder builder = recycler.OpenBuilder();
			switch (this.target)
			{
			case global::BasicDoor.State.Opening:
			case global::BasicDoor.State.Closed:
				builder.SetState(0);
				break;
			case global::BasicDoor.State.Opened:
			case global::BasicDoor.State.Closing:
				builder.SetState((!this.openingInReverse) ? 1 : 2);
				break;
			default:
				builder.SetState((!this.startsOpened) ? 0 : ((!this.defaultReversed || !this.canOpenReverse) ? 1 : 2));
				break;
			}
			saveobj.SetDoor(builder);
		}
	}

	// Token: 0x06003FC1 RID: 16321 RVA: 0x000E3798 File Offset: 0x000E1998
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (!saveobj.HasDoor)
		{
			return;
		}
		global::BasicDoor.State state = this.target;
		bool flag = this.openingInReverse;
		ulong timestamp = 0UL;
		this.StartOpeningOrClosing((sbyte)saveobj.Door.State, timestamp);
		if (state != this.target || flag != this.openingInReverse)
		{
			this.InvalidateState(timestamp);
		}
	}

	// Token: 0x040020B7 RID: 8375
	private const global::BasicDoor.RunFlags kRF_StartOpen_Mask = global::BasicDoor.RunFlags.OpenedForward;

	// Token: 0x040020B8 RID: 8376
	private const global::BasicDoor.RunFlags kRF_StartOpen_Value = global::BasicDoor.RunFlags.OpenedForward;

	// Token: 0x040020B9 RID: 8377
	private const global::BasicDoor.RunFlags kRF_DefaultReverse_Mask = (global::BasicDoor.RunFlags)0x12;

	// Token: 0x040020BA RID: 8378
	private const global::BasicDoor.RunFlags kRF_DefaultReverse_Value = global::BasicDoor.RunFlags.ClosedReverse;

	// Token: 0x040020BB RID: 8379
	private const global::BasicDoor.RunFlags kRF_DisableReverse_Mask = global::BasicDoor.RunFlags.ClosedNoReverse;

	// Token: 0x040020BC RID: 8380
	private const global::BasicDoor.RunFlags kRF_DisableReverse_Value = global::BasicDoor.RunFlags.ClosedNoReverse;

	// Token: 0x040020BD RID: 8381
	private const global::BasicDoor.RunFlags kRF_FixedUpdate_Mask = global::BasicDoor.RunFlags.FixedUpdateClosedForward;

	// Token: 0x040020BE RID: 8382
	private const global::BasicDoor.RunFlags kRF_FixedUpdate_Value = global::BasicDoor.RunFlags.FixedUpdateClosedForward;

	// Token: 0x040020BF RID: 8383
	private const global::BasicDoor.RunFlags kRF_PointText_Mask = global::BasicDoor.RunFlags.ClosedForwardWithPointText;

	// Token: 0x040020C0 RID: 8384
	private const global::BasicDoor.RunFlags kRF_PointText_Value = global::BasicDoor.RunFlags.ClosedForwardWithPointText;

	// Token: 0x040020C1 RID: 8385
	private const global::BasicDoor.RunFlags kRF_WaitsTarget_Mask = global::BasicDoor.RunFlags.ClosedForwardWaits;

	// Token: 0x040020C2 RID: 8386
	private const global::BasicDoor.RunFlags kRF_WaitsTarget_Value = global::BasicDoor.RunFlags.ClosedForwardWaits;

	// Token: 0x040020C3 RID: 8387
	private const sbyte kOpenForward = 1;

	// Token: 0x040020C4 RID: 8388
	private const sbyte kOpenBackward = 2;

	// Token: 0x040020C5 RID: 8389
	private const sbyte kClose = 0;

	// Token: 0x040020C6 RID: 8390
	private const string kRPCName_SetOpenOrClosed = "DOo";

	// Token: 0x040020C7 RID: 8391
	private const string kRPCName_ConnectSetup = "DOc";

	// Token: 0x040020C8 RID: 8392
	[global::UnityEngine.SerializeField]
	private global::BasicDoor.RunFlags startConfig;

	// Token: 0x040020C9 RID: 8393
	[global::System.NonSerialized]
	protected global::UnityEngine.Vector3 originalLocalPosition;

	// Token: 0x040020CA RID: 8394
	[global::System.NonSerialized]
	protected global::UnityEngine.Quaternion originalLocalRotation;

	// Token: 0x040020CB RID: 8395
	[global::System.NonSerialized]
	protected global::UnityEngine.Vector3 originalLocalScale;

	// Token: 0x040020CC RID: 8396
	[global::System.NonSerialized]
	private ulong? timeStampChanged;

	// Token: 0x040020CD RID: 8397
	[global::UnityEngine.SerializeField]
	protected float durationClose = 1f;

	// Token: 0x040020CE RID: 8398
	[global::UnityEngine.SerializeField]
	protected float durationOpen = 1f;

	// Token: 0x040020CF RID: 8399
	[global::System.NonSerialized]
	private bool capturedOriginals;

	// Token: 0x040020D0 RID: 8400
	[global::UnityEngine.SerializeField]
	protected string textOpen = "Open";

	// Token: 0x040020D1 RID: 8401
	[global::UnityEngine.SerializeField]
	protected string textClose = "Close";

	// Token: 0x040020D2 RID: 8402
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 pointTextPointOpened;

	// Token: 0x040020D3 RID: 8403
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 pointTextPointClosed;

	// Token: 0x040020D4 RID: 8404
	[global::System.NonSerialized]
	private ulong? lastToggleTimeStamp;

	// Token: 0x040020D5 RID: 8405
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.AudioClip openSound;

	// Token: 0x040020D6 RID: 8406
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.AudioClip openedSound;

	// Token: 0x040020D7 RID: 8407
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.AudioClip closeSound;

	// Token: 0x040020D8 RID: 8408
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.AudioClip closedSound;

	// Token: 0x040020D9 RID: 8409
	[global::UnityEngine.SerializeField]
	protected float minimumTimeBetweenOpenClose = 1f;

	// Token: 0x040020DA RID: 8410
	[global::System.NonSerialized]
	private ulong? serverLastTimeStamp;

	// Token: 0x040020DB RID: 8411
	[global::System.NonSerialized]
	private global::BasicDoor.State state;

	// Token: 0x040020DC RID: 8412
	[global::System.NonSerialized]
	private global::BasicDoor.State target;

	// Token: 0x040020DD RID: 8413
	[global::System.NonSerialized]
	private global::UnityEngine.NavMeshObstacle obstacle;

	// Token: 0x040020DE RID: 8414
	[global::System.NonSerialized]
	private bool? obstacleState;

	// Token: 0x040020DF RID: 8415
	[global::System.NonSerialized]
	private bool hasObstacle;

	// Token: 0x040020E0 RID: 8416
	[global::System.NonSerialized]
	private bool addedListener;

	// Token: 0x040020E1 RID: 8417
	[global::System.NonSerialized]
	private bool openingInReverse;

	// Token: 0x040020E2 RID: 8418
	[global::System.NonSerialized]
	private bool isStaticDoor;

	// Token: 0x02000779 RID: 1913
	private enum RunFlags
	{
		// Token: 0x040020E4 RID: 8420
		ClosedForward,
		// Token: 0x040020E5 RID: 8421
		OpenedForward,
		// Token: 0x040020E6 RID: 8422
		ClosedReverse,
		// Token: 0x040020E7 RID: 8423
		OpenedReverse,
		// Token: 0x040020E8 RID: 8424
		ClosedForwardWithPointText,
		// Token: 0x040020E9 RID: 8425
		OpenedForwardWithPointText,
		// Token: 0x040020EA RID: 8426
		ClosedReverseWithPointText,
		// Token: 0x040020EB RID: 8427
		OpenedReverseWithPointText,
		// Token: 0x040020EC RID: 8428
		FixedUpdateClosedForward,
		// Token: 0x040020ED RID: 8429
		FixedUpdateOpenedForward,
		// Token: 0x040020EE RID: 8430
		FixedUpdateClosedReverse,
		// Token: 0x040020EF RID: 8431
		FixedUpdateOpenedReverse,
		// Token: 0x040020F0 RID: 8432
		FixedUpdateClosedForwardWithPointText,
		// Token: 0x040020F1 RID: 8433
		FixedUpdateOpenedForwardWithPointText,
		// Token: 0x040020F2 RID: 8434
		FixedUpdateClosedReverseWithPointText,
		// Token: 0x040020F3 RID: 8435
		FixedUpdateOpenedReverseWithPointText,
		// Token: 0x040020F4 RID: 8436
		ClosedNoReverse,
		// Token: 0x040020F5 RID: 8437
		OpenedNoReverse,
		// Token: 0x040020F6 RID: 8438
		ClosedNoReverseWithPointText = 0x14,
		// Token: 0x040020F7 RID: 8439
		OpenedNoReverseWithPointText,
		// Token: 0x040020F8 RID: 8440
		FixedUpdateClosedNoReverse = 0x18,
		// Token: 0x040020F9 RID: 8441
		FixedUpdateOpenedNoReverse,
		// Token: 0x040020FA RID: 8442
		FixedUpdateClosedNoReverseWithPointText = 0x1C,
		// Token: 0x040020FB RID: 8443
		FixedUpdateOpenedNoReverseWithPointText,
		// Token: 0x040020FC RID: 8444
		ClosedForwardWaits = 0x20,
		// Token: 0x040020FD RID: 8445
		OpenedForwardWaits,
		// Token: 0x040020FE RID: 8446
		ClosedReverseWaits,
		// Token: 0x040020FF RID: 8447
		OpenedReverseWaits,
		// Token: 0x04002100 RID: 8448
		ClosedForwardWaitsWithPointText,
		// Token: 0x04002101 RID: 8449
		OpenedForwardWaitsWithPointText,
		// Token: 0x04002102 RID: 8450
		ClosedReverseWaitsWithPointText,
		// Token: 0x04002103 RID: 8451
		OpenedReverseWaitsWithPointText,
		// Token: 0x04002104 RID: 8452
		FixedUpdateClosedForwardWaits,
		// Token: 0x04002105 RID: 8453
		FixedUpdateOpenedForwardWaits,
		// Token: 0x04002106 RID: 8454
		FixedUpdateClosedReverseWaits,
		// Token: 0x04002107 RID: 8455
		FixedUpdateOpenedReverseWaits,
		// Token: 0x04002108 RID: 8456
		FixedUpdateClosedForwardWaitsWithPointText,
		// Token: 0x04002109 RID: 8457
		FixedUpdateOpenedForwardWaitsWithPointText,
		// Token: 0x0400210A RID: 8458
		FixedUpdateClosedReverseWaitsWithPointText,
		// Token: 0x0400210B RID: 8459
		FixedUpdateOpenedReverseWaitsWithPointText,
		// Token: 0x0400210C RID: 8460
		ClosedNoReverseWaits,
		// Token: 0x0400210D RID: 8461
		OpenedNoReverseWaits,
		// Token: 0x0400210E RID: 8462
		ClosedNoReverseWithPointTextWaits = 0x34,
		// Token: 0x0400210F RID: 8463
		OpenedNoReverseWithPointTextWaits,
		// Token: 0x04002110 RID: 8464
		FixedUpdateClosedNoReverseWaits = 0x38,
		// Token: 0x04002111 RID: 8465
		FixedUpdateOpenedNoReverseWaits,
		// Token: 0x04002112 RID: 8466
		FixedUpdateClosedNoReverseWaitsWithPointText = 0x3C,
		// Token: 0x04002113 RID: 8467
		FixedUpdateOpenedNoReverseWaitsWithPointText
	}

	// Token: 0x0200077A RID: 1914
	protected class DoorActions
	{
		// Token: 0x06003FC2 RID: 16322 RVA: 0x000E37F8 File Offset: 0x000E19F8
		public DoorActions()
		{
		}

		// Token: 0x06003FC3 RID: 16323 RVA: 0x000E3800 File Offset: 0x000E1A00
		// Note: this type is marked as 'beforefieldinit'.
		static DoorActions()
		{
		}

		// Token: 0x04002114 RID: 8468
		public static readonly global::ContextActionPrototype Open = new global::ContextActionPrototype
		{
			text = "Open Door",
			name = 1
		};

		// Token: 0x04002115 RID: 8469
		public static readonly global::ContextActionPrototype Close = new global::ContextActionPrototype
		{
			text = "Close Door",
			name = 2
		};

		// Token: 0x04002116 RID: 8470
		public static readonly global::ContextActionPrototype ChangeLock = new global::ContextActionPrototype
		{
			text = "Change Lock",
			name = 3
		};

		// Token: 0x04002117 RID: 8471
		public static readonly global::ContextActionPrototype Unlock = new global::ContextActionPrototype
		{
			text = "Unlock",
			name = 4
		};

		// Token: 0x04002118 RID: 8472
		public static readonly global::ContextActionPrototype Lock = new global::ContextActionPrototype
		{
			text = "Lock",
			name = 5
		};

		// Token: 0x04002119 RID: 8473
		public static readonly global::ContextActionPrototype EnterCode = new global::ContextActionPrototype
		{
			text = "Enter Code",
			name = 6
		};
	}

	// Token: 0x0200077B RID: 1915
	private enum State : byte
	{
		// Token: 0x0400211B RID: 8475
		Opening,
		// Token: 0x0400211C RID: 8476
		Opened,
		// Token: 0x0400211D RID: 8477
		Closing,
		// Token: 0x0400211E RID: 8478
		Closed
	}

	// Token: 0x0200077C RID: 1916
	private enum Side : byte
	{
		// Token: 0x04002120 RID: 8480
		Forward,
		// Token: 0x04002121 RID: 8481
		Reverse
	}

	// Token: 0x0200077D RID: 1917
	protected enum IdealSide : sbyte
	{
		// Token: 0x04002123 RID: 8483
		Unknown,
		// Token: 0x04002124 RID: 8484
		Reverse = -1,
		// Token: 0x04002125 RID: 8485
		Forward = 1
	}

	// Token: 0x0200077E RID: 1918
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <ContextQueryMenu>c__Iterator50 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>, global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>
	{
		// Token: 0x06003FC4 RID: 16324 RVA: 0x000E38C4 File Offset: 0x000E1AC4
		public <ContextQueryMenu>c__Iterator50()
		{
		}

		// Token: 0x17000BF3 RID: 3059
		// (get) Token: 0x06003FC5 RID: 16325 RVA: 0x000E38CC File Offset: 0x000E1ACC
		global::ContextActionPrototype global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BF4 RID: 3060
		// (get) Token: 0x06003FC6 RID: 16326 RVA: 0x000E38D4 File Offset: 0x000E1AD4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003FC7 RID: 16327 RVA: 0x000E38DC File Offset: 0x000E1ADC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<ContextActionPrototype>.GetEnumerator();
		}

		// Token: 0x06003FC8 RID: 16328 RVA: 0x000E38E4 File Offset: 0x000E1AE4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype> global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::BasicDoor.<ContextQueryMenu>c__Iterator50 <ContextQueryMenu>c__Iterator = new global::BasicDoor.<ContextQueryMenu>c__Iterator50();
			<ContextQueryMenu>c__Iterator.<>f__this = this;
			<ContextQueryMenu>c__Iterator.controllable = controllable;
			return <ContextQueryMenu>c__Iterator;
		}

		// Token: 0x06003FC9 RID: 16329 RVA: 0x000E3924 File Offset: 0x000E1B24
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				user = controllable.netUser;
				if (object.ReferenceEquals(user, null))
				{
					return false;
				}
				deployable = base.GetComponent<global::DeployableObject>();
				isDeployable = deployable;
				isOwner = (isDeployable && deployable.ownerID == user.userID);
				containsDoorLock = base.containsDoorLock;
				doorLockIsLocked = (containsDoorLock && base.IsDoorLockActive());
				doorLockIsUnlockedForUser = (containsDoorLock && (base.IsUserUnlocked(user.userID) || isOwner));
				canOpenOrClose = (!containsDoorLock || isOwner || doorLockIsUnlockedForUser || !doorLockIsLocked);
				canAlterLockActiveState = (containsDoorLock && isOwner);
				if (canOpenOrClose)
				{
					this.$current = ((!base.on) ? global::BasicDoor.DoorActions.Open : global::BasicDoor.DoorActions.Close);
					this.$PC = 1;
					return true;
				}
				break;
			case 1U:
				break;
			case 2U:
				goto IL_1B8;
			case 3U:
				goto IL_1EF;
			case 4U:
				goto IL_21C;
			default:
				return false;
			}
			if (!doorLockIsUnlockedForUser)
			{
				this.$current = global::BasicDoor.DoorActions.EnterCode;
				this.$PC = 2;
				return true;
			}
			IL_1B8:
			if (canAlterLockActiveState)
			{
				this.$current = ((!doorLockIsLocked) ? global::BasicDoor.DoorActions.Lock : global::BasicDoor.DoorActions.Unlock);
				this.$PC = 3;
				return true;
			}
			IL_1EF:
			if (isOwner && containsDoorLock)
			{
				this.$current = global::BasicDoor.DoorActions.ChangeLock;
				this.$PC = 4;
				return true;
			}
			IL_21C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003FCA RID: 16330 RVA: 0x000E3B5C File Offset: 0x000E1D5C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003FCB RID: 16331 RVA: 0x000E3B68 File Offset: 0x000E1D68
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002126 RID: 8486
		internal global::Controllable controllable;

		// Token: 0x04002127 RID: 8487
		internal global::NetUser <user>__0;

		// Token: 0x04002128 RID: 8488
		internal global::DeployableObject <deployable>__1;

		// Token: 0x04002129 RID: 8489
		internal global::DeployableObject <isDeployable>__2;

		// Token: 0x0400212A RID: 8490
		internal bool <isOwner>__3;

		// Token: 0x0400212B RID: 8491
		internal bool <containsDoorLock>__4;

		// Token: 0x0400212C RID: 8492
		internal bool <doorLockIsLocked>__5;

		// Token: 0x0400212D RID: 8493
		internal bool <doorLockIsUnlockedForUser>__6;

		// Token: 0x0400212E RID: 8494
		internal bool <canOpenOrClose>__7;

		// Token: 0x0400212F RID: 8495
		internal bool <canAlterLockActiveState>__8;

		// Token: 0x04002130 RID: 8496
		internal int $PC;

		// Token: 0x04002131 RID: 8497
		internal global::ContextActionPrototype $current;

		// Token: 0x04002132 RID: 8498
		internal global::Controllable <$>controllable;

		// Token: 0x04002133 RID: 8499
		internal global::BasicDoor <>f__this;
	}
}
