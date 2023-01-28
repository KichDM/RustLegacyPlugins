using System;
using System.Runtime.CompilerServices;
using Facepunch;
using UnityEngine;

// Token: 0x02000228 RID: 552
[global::InterfaceDriverComponent(typeof(global::IUseable), "_implementation", "implementation", SearchRoute = global::InterfaceSearchRoute.GameObject, UnityType = typeof(global::Facepunch.MonoBehaviour), AlwaysSaveDisabled = true)]
public sealed class Useable : global::UnityEngine.MonoBehaviour, global::IComponentInterfaceDriver<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>
{
	// Token: 0x06000EEC RID: 3820 RVA: 0x000396DC File Offset: 0x000378DC
	public Useable()
	{
	}

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06000EED RID: 3821 RVA: 0x000396E4 File Offset: 0x000378E4
	// (remove) Token: 0x06000EEE RID: 3822 RVA: 0x00039700 File Offset: 0x00037900
	public event global::Useable.UseExitCallback onUseExited
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.onUseExited = (global::Useable.UseExitCallback)global::System.Delegate.Combine(this.onUseExited, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.onUseExited = (global::Useable.UseExitCallback)global::System.Delegate.Remove(this.onUseExited, value);
		}
	}

	// Token: 0x17000382 RID: 898
	// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0003971C File Offset: 0x0003791C
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

	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x0003976C File Offset: 0x0003796C
	public global::IUseable @interface
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
			return this.use;
		}
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x000397BC File Offset: 0x000379BC
	public bool exists
	{
		get
		{
			return this._implemented && (this._implemented = this.implementation);
		}
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x000397EC File Offset: 0x000379EC
	public global::Useable driver
	{
		get
		{
			return this;
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x000397F0 File Offset: 0x000379F0
	public global::Character user
	{
		get
		{
			return this._user;
		}
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x000397F8 File Offset: 0x000379F8
	public bool occupied
	{
		get
		{
			return this._user;
		}
	}

	// Token: 0x06000EF5 RID: 3829 RVA: 0x00039808 File Offset: 0x00037A08
	private void OnEnable()
	{
		if (!this.canUpdate)
		{
			global::UnityEngine.Debug.LogError("Something is trying to enable useable without a implementation using IUseableUpdated");
			base.enabled = false;
		}
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x00039828 File Offset: 0x00037A28
	private void Refresh()
	{
		this.implementation = this._implementation;
		this._implementation = null;
		this.use = (this.implementation as global::IUseable);
		this.canUse = (this.use != null);
		if (this.canUse)
		{
			this.onDeathCallback = new global::CharacterDeathSignal(this.KilledCallback);
			this.useUpdate = (this.implementation as global::IUseableUpdated);
			this.canUpdate = (this.useUpdate != null);
			if (this.canUpdate)
			{
				try
				{
					this.updateFlags = this.useUpdate.UseUpdateFlags;
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"implementation ",
						this.implementation,
						" threw following exception while checking its UseUpdateFlags property. It will use UpdateFlags.None.\r\n",
						ex
					}), this.implementation);
					this.updateFlags = global::UseUpdateFlags.None;
				}
				this.wantDeclines = ((this.useDecline = (this.implementation as global::IUseableNotifyDecline)) != null);
				this.canCheck = ((this.useCheck = (this.implementation as global::IUseableChecked)) != null);
				base.enabled = ((this.updateFlags & global::UseUpdateFlags.UpdateWithoutUser) == global::UseUpdateFlags.UpdateWithoutUser);
			}
			else
			{
				this.updateFlags = global::UseUpdateFlags.None;
				base.enabled = false;
			}
			global::IUseableAwake useableAwake = this.implementation as global::IUseableAwake;
			if (useableAwake != null)
			{
				useableAwake.OnUseableAwake(this);
			}
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("implementation is null or does not implement IUseable", this);
		}
	}

	// Token: 0x06000EF7 RID: 3831 RVA: 0x000399B8 File Offset: 0x00037BB8
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

	// Token: 0x06000EF8 RID: 3832 RVA: 0x00039A00 File Offset: 0x00037C00
	private void RunUpdate()
	{
		global::Useable.FunctionCallState functionCallState = this.callState;
		try
		{
			this.callState = global::Useable.FunctionCallState.OnUseUpdate;
			this.useUpdate.OnUseUpdate(this);
		}
		catch (global::System.Exception arg)
		{
			global::UnityEngine.Debug.LogError("Inside OnUseUpdate\r\n" + arg, this.implementation);
		}
		finally
		{
			this.callState = functionCallState;
		}
	}

	// Token: 0x06000EF9 RID: 3833 RVA: 0x00039A84 File Offset: 0x00037C84
	private void Update()
	{
		if (!this._user)
		{
			if ((this.updateFlags & global::UseUpdateFlags.UpdateWithoutUser) == global::UseUpdateFlags.UpdateWithoutUser)
			{
				if (this.implementation)
				{
					this.RunUpdate();
				}
				else
				{
					base.enabled = false;
				}
			}
			else
			{
				global::UnityEngine.Debug.LogWarning("Most likely the user was destroyed without being set up properly!", this);
				base.enabled = false;
			}
		}
		else if (this.implementation)
		{
			this.RunUpdate();
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000EFA RID: 3834 RVA: 0x00039B14 File Offset: 0x00037D14
	private static void EnsureServer()
	{
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x00039B18 File Offset: 0x00037D18
	public global::UseResponse EnterFromElsewhere(global::Character attempt)
	{
		return this.Enter(attempt, global::UseEnterRequest.Elsewhere);
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x00039B24 File Offset: 0x00037D24
	public global::UseResponse EnterFromContext(global::Character attempt)
	{
		return this.Enter(attempt, global::UseEnterRequest.Context);
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x00039B30 File Offset: 0x00037D30
	private global::UseResponse Enter(global::Character attempt, global::UseEnterRequest request)
	{
		if (!this.canUse)
		{
			return global::UseResponse.Fail_NotIUseable;
		}
		global::Useable.EnsureServer();
		if ((int)this.callState != 0)
		{
			global::UnityEngine.Debug.LogWarning("Some how Enter got called from a call stack originating with " + this.callState + " fix your script to not do this.", this);
			return global::UseResponse.Fail_InvalidOperation;
		}
		if (global::Useable.hasException)
		{
			global::Useable.ClearException(false);
		}
		if (!attempt)
		{
			return global::UseResponse.Fail_NullOrMissingUser;
		}
		if (attempt.signaledDeath)
		{
			return global::UseResponse.Fail_UserDead;
		}
		if (!this._user)
		{
			if (this.implementation)
			{
				try
				{
					this.callState = global::Useable.FunctionCallState.Enter;
					global::UseResponse useResponse;
					if (this.canCheck)
					{
						try
						{
							useResponse = (global::UseResponse)this.useCheck.CanUse(attempt, request);
						}
						catch (global::System.Exception ex)
						{
							global::Useable.lastException = ex;
							return global::UseResponse.Fail_CheckException;
						}
						if ((int)useResponse != 1)
						{
							if (useResponse.Succeeded())
							{
								global::UnityEngine.Debug.LogError("A IUseableChecked return a invalid value that should have cause success [" + useResponse + "], but it was not UseCheck.Success! fix your script.", this.implementation);
								return global::UseResponse.Fail_Checked_BadResult;
							}
							if (this.wantDeclines)
							{
								try
								{
									this.useDecline.OnUseDeclined(attempt, useResponse, request);
								}
								catch (global::System.Exception ex2)
								{
									global::UnityEngine.Debug.LogError(string.Concat(new object[]
									{
										"Caught exception in OnUseDeclined \r\n (response was ",
										useResponse,
										")",
										ex2
									}), this.implementation);
								}
							}
							return useResponse;
						}
					}
					else
					{
						useResponse = global::UseResponse.Pass_Unchecked;
					}
					try
					{
						this._user = attempt;
						this.use.OnUseEnter(this);
					}
					catch (global::System.Exception arg)
					{
						this._user = null;
						global::UnityEngine.Debug.LogError("Exception thrown during Useable.Enter. Object not set as used!\r\n" + arg, attempt);
						global::Useable.lastException = arg;
						return global::UseResponse.Fail_EnterException;
					}
					if (useResponse.Succeeded())
					{
						this.LatchUse();
					}
					return useResponse;
				}
				finally
				{
					this.callState = global::Useable.FunctionCallState.None;
				}
				return global::UseResponse.Fail_Destroyed;
			}
			return global::UseResponse.Fail_Destroyed;
		}
		if (this._user == attempt)
		{
			if (this.wantDeclines && this.implementation)
			{
				try
				{
					this.useDecline.OnUseDeclined(attempt, global::UseResponse.Fail_Redundant, request);
				}
				catch (global::System.Exception arg2)
				{
					global::UnityEngine.Debug.LogError("Caught exception in OnUseDeclined \r\n (response was Fail_Redundant)" + arg2, this.implementation);
				}
			}
			return global::UseResponse.Fail_Redundant;
		}
		if (this.wantDeclines && this.implementation)
		{
			try
			{
				this.useDecline.OnUseDeclined(attempt, global::UseResponse.Fail_Vacancy, request);
			}
			catch (global::System.Exception arg3)
			{
				global::UnityEngine.Debug.LogError("Caught exception in OnUseDeclined \r\n (response was Fail_Vacancy)" + arg3, this.implementation);
			}
		}
		return global::UseResponse.Fail_Vacancy;
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x00039E5C File Offset: 0x0003805C
	public bool Exit(global::Character attempt)
	{
		global::Useable.EnsureServer();
		if ((int)this.callState != 0)
		{
			global::UnityEngine.Debug.LogWarning("Some how Exit got called from a call stack originating with " + this.callState + " fix your script to not do this.", this);
			return false;
		}
		if (attempt == this._user && attempt)
		{
			try
			{
				if (this.implementation)
				{
					try
					{
						this.callState = global::Useable.FunctionCallState.Exit;
						this.use.OnUseExit(this, global::UseExitReason.Manual);
					}
					finally
					{
						this.InvokeUseExitCallback();
						this.callState = global::Useable.FunctionCallState.None;
					}
				}
				return true;
			}
			finally
			{
				this._user = null;
				this.UnlatchUse();
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000EFF RID: 3839 RVA: 0x00039F40 File Offset: 0x00038140
	private void InvokeUseExitCallback()
	{
		if (this.onUseExited != null)
		{
			this.onUseExited(this, (int)this.callState == 3);
		}
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x00039F64 File Offset: 0x00038164
	public bool Eject()
	{
		global::Useable.EnsureServer();
		global::UseExitReason reason;
		if ((int)this.callState != 0)
		{
			if ((int)this.callState != 4)
			{
				global::UnityEngine.Debug.LogWarning("Some how Eject got called from a call stack originating with " + this.callState + " fix your script to not do this.", this);
				return false;
			}
			reason = global::UseExitReason.Manual;
		}
		else
		{
			reason = ((!this.inDestroy) ? ((!this.inKillCallback) ? global::UseExitReason.Forced : global::UseExitReason.Killed) : global::UseExitReason.Destroy);
		}
		if (this._user)
		{
			try
			{
				if (this.implementation)
				{
					try
					{
						this.callState = global::Useable.FunctionCallState.Eject;
						this.use.OnUseExit(this, reason);
					}
					finally
					{
						try
						{
							this.InvokeUseExitCallback();
						}
						finally
						{
							this.callState = global::Useable.FunctionCallState.None;
						}
					}
				}
				else
				{
					global::UnityEngine.Debug.LogError("The IUseable has been destroyed with a user on it. IUseable should ALWAYS call UseableUtility.OnDestroy within the script's OnDestroy message first thing! " + base.gameObject, this);
				}
				return true;
			}
			finally
			{
				this.UnlatchUse();
				this._user = null;
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x0003A0B4 File Offset: 0x000382B4
	private void KilledCallback(global::Character user, global::CharacterDeathSignalReason reason)
	{
		if (!user)
		{
			global::UnityEngine.Debug.LogError("Somehow KilledCallback got a null", this);
		}
		if (user != this._user)
		{
			global::UnityEngine.Debug.LogError("Some callback invoked kill callback on the Useable but it was not being used by it", user);
		}
		else
		{
			try
			{
				this.inKillCallback = true;
				if (!this.Eject())
				{
					global::UnityEngine.Debug.LogWarning("Failure to eject??", this);
				}
			}
			catch (global::System.Exception arg)
			{
				global::UnityEngine.Debug.LogError("Exception in Eject while inside a killed callback\r\n" + arg, user);
			}
			finally
			{
				this.inKillCallback = false;
			}
		}
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x0003A170 File Offset: 0x00038370
	private void OnDestroy()
	{
		this.inDestroy = true;
		if (this._user)
		{
			this.Eject();
		}
		this.canCheck = false;
		this.canUpdate = false;
		this.canUse = false;
		this.wantDeclines = false;
		this.use = null;
		this.useUpdate = null;
		this.useCheck = null;
		this.useDecline = null;
	}

	// Token: 0x06000F03 RID: 3843 RVA: 0x0003A1D4 File Offset: 0x000383D4
	private void LatchUse()
	{
		this._user.signal_death += this.onDeathCallback;
		base.enabled = ((this.updateFlags & global::UseUpdateFlags.UpdateWithUser) == global::UseUpdateFlags.UpdateWithUser);
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x0003A204 File Offset: 0x00038404
	private void UnlatchUse()
	{
		try
		{
			if (this._user)
			{
				this._user.signal_death -= this.onDeathCallback;
			}
		}
		catch (global::System.Exception arg)
		{
			global::UnityEngine.Debug.LogError("Exception caught during unlatch\r\n" + arg, this);
		}
		finally
		{
			this._user = null;
		}
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x0003A28C File Offset: 0x0003848C
	public static bool GetLastException<E>(out E exception, bool doNotClear) where E : global::System.Exception
	{
		if (global::Useable.hasException && global::Useable.lastException is E)
		{
			exception = (E)((object)global::Useable.lastException);
			if (!doNotClear)
			{
				global::Useable.ClearException(true);
			}
			return true;
		}
		exception = (E)((object)null);
		return false;
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x0003A2E0 File Offset: 0x000384E0
	public static bool GetLastException<E>(out E exception) where E : global::System.Exception
	{
		return global::Useable.GetLastException<E>(out exception, false);
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x0003A2EC File Offset: 0x000384EC
	public static bool GetLastException(out global::System.Exception exception, bool doNotClear)
	{
		if (global::Useable.hasException)
		{
			exception = global::Useable.lastException;
			if (!doNotClear)
			{
				global::Useable.ClearException(true);
			}
			return true;
		}
		exception = null;
		return true;
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x0003A314 File Offset: 0x00038514
	public static bool GetLastException(out global::System.Exception exception)
	{
		return global::Useable.GetLastException(out exception, false);
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x0003A320 File Offset: 0x00038520
	private static void ClearException(bool got)
	{
		if (!got)
		{
			global::UnityEngine.Debug.LogWarning("Nothing got previous now clearing exception \r\n" + global::Useable.lastException);
		}
		global::Useable.lastException = null;
		global::Useable.hasException = false;
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x0003A354 File Offset: 0x00038554
	private void Reset()
	{
		foreach (global::Facepunch.MonoBehaviour monoBehaviour in base.GetComponents<global::Facepunch.MonoBehaviour>())
		{
			if (monoBehaviour is global::IUseable)
			{
				this._implementation = monoBehaviour;
			}
		}
	}

	// Token: 0x0400096D RID: 2413
	[global::UnityEngine.SerializeField]
	private global::Facepunch.MonoBehaviour _implementation;

	// Token: 0x0400096E RID: 2414
	[global::System.NonSerialized]
	private global::Facepunch.MonoBehaviour implementation;

	// Token: 0x0400096F RID: 2415
	[global::System.NonSerialized]
	private global::IUseable use;

	// Token: 0x04000970 RID: 2416
	[global::System.NonSerialized]
	private global::IUseableChecked useCheck;

	// Token: 0x04000971 RID: 2417
	[global::System.NonSerialized]
	private global::IUseableNotifyDecline useDecline;

	// Token: 0x04000972 RID: 2418
	[global::System.NonSerialized]
	private global::IUseableUpdated useUpdate;

	// Token: 0x04000973 RID: 2419
	[global::System.NonSerialized]
	private bool canUse;

	// Token: 0x04000974 RID: 2420
	[global::System.NonSerialized]
	private bool canCheck;

	// Token: 0x04000975 RID: 2421
	[global::System.NonSerialized]
	private bool wantDeclines;

	// Token: 0x04000976 RID: 2422
	[global::System.NonSerialized]
	private bool canUpdate;

	// Token: 0x04000977 RID: 2423
	[global::System.NonSerialized]
	private bool inKillCallback;

	// Token: 0x04000978 RID: 2424
	[global::System.NonSerialized]
	private bool inDestroy;

	// Token: 0x04000979 RID: 2425
	[global::System.NonSerialized]
	private bool _implemented;

	// Token: 0x0400097A RID: 2426
	[global::System.NonSerialized]
	private bool _awoke;

	// Token: 0x0400097B RID: 2427
	[global::System.NonSerialized]
	private global::UseUpdateFlags updateFlags;

	// Token: 0x0400097C RID: 2428
	[global::System.NonSerialized]
	private global::Character _user;

	// Token: 0x0400097D RID: 2429
	[global::System.NonSerialized]
	private global::CharacterDeathSignal onDeathCallback;

	// Token: 0x0400097E RID: 2430
	[global::System.NonSerialized]
	private global::Useable.FunctionCallState callState;

	// Token: 0x0400097F RID: 2431
	private static bool hasException;

	// Token: 0x04000980 RID: 2432
	private static global::System.Exception lastException;

	// Token: 0x04000981 RID: 2433
	private global::Useable.UseExitCallback onUseExited;

	// Token: 0x02000229 RID: 553
	private enum FunctionCallState : sbyte
	{
		// Token: 0x04000983 RID: 2435
		None,
		// Token: 0x04000984 RID: 2436
		Enter,
		// Token: 0x04000985 RID: 2437
		Exit,
		// Token: 0x04000986 RID: 2438
		Eject,
		// Token: 0x04000987 RID: 2439
		OnUseUpdate
	}

	// Token: 0x0200022A RID: 554
	// (Invoke) Token: 0x06000F0C RID: 3852
	public delegate void UseExitCallback(global::Useable useable, bool wasEjected);
}
