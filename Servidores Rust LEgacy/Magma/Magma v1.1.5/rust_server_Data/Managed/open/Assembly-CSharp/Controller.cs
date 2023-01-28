using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using uLink;
using UnityEngine;

// Token: 0x0200015E RID: 350
public abstract class Controller : global::IDLocalCharacterAddon
{
	// Token: 0x06000990 RID: 2448 RVA: 0x00028358 File Offset: 0x00026558
	protected Controller(global::Controller.ControllerFlags controllerFlags) : this(controllerFlags, (global::IDLocalCharacterAddon.AddonFlags)0)
	{
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x00028364 File Offset: 0x00026564
	protected Controller(global::Controller.ControllerFlags controllerFlags, global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags)
	{
		this.controllerFlags = controllerFlags;
	}

	// Token: 0x17000238 RID: 568
	// (get) Token: 0x06000992 RID: 2450 RVA: 0x00028374 File Offset: 0x00026574
	public new bool controlled
	{
		get
		{
			return this._controllable.controlled;
		}
	}

	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000993 RID: 2451 RVA: 0x00028384 File Offset: 0x00026584
	public new bool playerControlled
	{
		get
		{
			return this._controllable.playerControlled;
		}
	}

	// Token: 0x1700023A RID: 570
	// (get) Token: 0x06000994 RID: 2452 RVA: 0x00028394 File Offset: 0x00026594
	public new bool aiControlled
	{
		get
		{
			return this._controllable.aiControlled;
		}
	}

	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06000995 RID: 2453 RVA: 0x000283A4 File Offset: 0x000265A4
	public new bool localPlayerControlled
	{
		get
		{
			return this._controllable.localPlayerControlled;
		}
	}

	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06000996 RID: 2454 RVA: 0x000283B4 File Offset: 0x000265B4
	public new bool remotePlayerControlled
	{
		get
		{
			return this._controllable.remotePlayerControlled;
		}
	}

	// Token: 0x1700023D RID: 573
	// (get) Token: 0x06000997 RID: 2455 RVA: 0x000283C4 File Offset: 0x000265C4
	public new bool localAIControlled
	{
		get
		{
			return this._controllable.localAIControlled;
		}
	}

	// Token: 0x1700023E RID: 574
	// (get) Token: 0x06000998 RID: 2456 RVA: 0x000283D4 File Offset: 0x000265D4
	public new bool remoteAIControlled
	{
		get
		{
			return this._controllable.remoteAIControlled;
		}
	}

	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06000999 RID: 2457 RVA: 0x000283E4 File Offset: 0x000265E4
	public new bool localControlled
	{
		get
		{
			return this._controllable.localControlled;
		}
	}

	// Token: 0x17000240 RID: 576
	// (get) Token: 0x0600099A RID: 2458 RVA: 0x000283F4 File Offset: 0x000265F4
	public new bool remoteControlled
	{
		get
		{
			return this._controllable.remoteControlled;
		}
	}

	// Token: 0x17000241 RID: 577
	// (get) Token: 0x0600099B RID: 2459 RVA: 0x00028404 File Offset: 0x00026604
	public new global::PlayerClient playerClient
	{
		get
		{
			return this._controllable.playerClient;
		}
	}

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x0600099C RID: 2460 RVA: 0x00028414 File Offset: 0x00026614
	public new global::Controller controller
	{
		get
		{
			return this;
		}
	}

	// Token: 0x17000243 RID: 579
	// (get) Token: 0x0600099D RID: 2461 RVA: 0x00028418 File Offset: 0x00026618
	public new global::Controller controlledController
	{
		get
		{
			return (!this._controllable.controlled) ? null : this;
		}
	}

	// Token: 0x17000244 RID: 580
	// (get) Token: 0x0600099E RID: 2462 RVA: 0x00028434 File Offset: 0x00026634
	public new global::Controller localPlayerControlledController
	{
		get
		{
			return this._controllable.localPlayerControlledController;
		}
	}

	// Token: 0x17000245 RID: 581
	// (get) Token: 0x0600099F RID: 2463 RVA: 0x00028444 File Offset: 0x00026644
	public new global::Controller remotePlayerControlledController
	{
		get
		{
			return this._controllable.remotePlayerControlledController;
		}
	}

	// Token: 0x17000246 RID: 582
	// (get) Token: 0x060009A0 RID: 2464 RVA: 0x00028454 File Offset: 0x00026654
	public new global::Controller localAIControlledController
	{
		get
		{
			return this._controllable.localAIControlledController;
		}
	}

	// Token: 0x17000247 RID: 583
	// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00028464 File Offset: 0x00026664
	public new global::Controller remoteAIControlledController
	{
		get
		{
			return this._controllable.remoteAIControlledController;
		}
	}

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x060009A2 RID: 2466 RVA: 0x00028474 File Offset: 0x00026674
	public new global::Controllable controllable
	{
		get
		{
			return this._controllable;
		}
	}

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x060009A3 RID: 2467 RVA: 0x0002847C File Offset: 0x0002667C
	public new global::Controllable controlledControllable
	{
		get
		{
			return (!this._controllable.controlled) ? null : this._controllable;
		}
	}

	// Token: 0x1700024A RID: 586
	// (get) Token: 0x060009A4 RID: 2468 RVA: 0x0002849C File Offset: 0x0002669C
	public new global::Controllable localPlayerControlledControllable
	{
		get
		{
			return this._controllable.localPlayerControlledControllable;
		}
	}

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000284AC File Offset: 0x000266AC
	public new global::Controllable remotePlayerControlledControllable
	{
		get
		{
			return this._controllable.remotePlayerControlledControllable;
		}
	}

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x060009A6 RID: 2470 RVA: 0x000284BC File Offset: 0x000266BC
	public new global::Controllable localAIControlledControllable
	{
		get
		{
			return this._controllable.localAIControlledControllable;
		}
	}

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x060009A7 RID: 2471 RVA: 0x000284CC File Offset: 0x000266CC
	public new global::Controllable remoteAIControlledControllable
	{
		get
		{
			return this._controllable.remoteAIControlledControllable;
		}
	}

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x060009A8 RID: 2472 RVA: 0x000284DC File Offset: 0x000266DC
	public new bool controlOverridden
	{
		get
		{
			return this._controllable.controlOverridden;
		}
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x000284EC File Offset: 0x000266EC
	public new bool ControlOverriddenBy(global::Controllable controllable)
	{
		return this._controllable.ControlOverriddenBy(controllable);
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x000284FC File Offset: 0x000266FC
	public new bool ControlOverriddenBy(global::Controller controller)
	{
		return this._controllable.ControlOverriddenBy(controller);
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x0002850C File Offset: 0x0002670C
	public new bool ControlOverriddenBy(global::Character character)
	{
		return this._controllable.ControlOverriddenBy(character);
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x0002851C File Offset: 0x0002671C
	public new bool ControlOverriddenBy(global::IDMain main)
	{
		return this._controllable.ControlOverriddenBy(main);
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x0002852C File Offset: 0x0002672C
	public new bool ControlOverriddenBy(global::IDBase idBase)
	{
		return this._controllable.ControlOverriddenBy(idBase);
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x0002853C File Offset: 0x0002673C
	public new bool ControlOverriddenBy(global::IDLocalCharacter idLocal)
	{
		return this._controllable.ControlOverriddenBy(idLocal);
	}

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x060009AF RID: 2479 RVA: 0x0002854C File Offset: 0x0002674C
	public new bool overridingControl
	{
		get
		{
			return this._controllable.overridingControl;
		}
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x0002855C File Offset: 0x0002675C
	public new bool OverridingControlOf(global::Controllable controllable)
	{
		return this._controllable.OverridingControlOf(controllable);
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x0002856C File Offset: 0x0002676C
	public new bool OverridingControlOf(global::Controller controller)
	{
		return this._controllable.OverridingControlOf(controller);
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x0002857C File Offset: 0x0002677C
	public new bool OverridingControlOf(global::Character character)
	{
		return this._controllable.OverridingControlOf(character);
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x0002858C File Offset: 0x0002678C
	public new bool OverridingControlOf(global::IDMain main)
	{
		return this._controllable.OverridingControlOf(main);
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x0002859C File Offset: 0x0002679C
	public new bool OverridingControlOf(global::IDBase idBase)
	{
		return this._controllable.OverridingControlOf(idBase);
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x000285AC File Offset: 0x000267AC
	public new bool OverridingControlOf(global::IDLocalCharacter idLocal)
	{
		return this._controllable.OverridingControlOf(idLocal);
	}

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x060009B6 RID: 2486 RVA: 0x000285BC File Offset: 0x000267BC
	public new bool assignedControl
	{
		get
		{
			return this._controllable.assignedControl;
		}
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x000285CC File Offset: 0x000267CC
	public new bool AssignedControlOf(global::Controllable controllable)
	{
		return this._controllable.AssignedControlOf(controllable);
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x000285DC File Offset: 0x000267DC
	public new bool AssignedControlOf(global::Controller controller)
	{
		return this._controllable.AssignedControlOf(controller);
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x000285EC File Offset: 0x000267EC
	public new bool AssignedControlOf(global::IDMain character)
	{
		return this._controllable.AssignedControlOf(character);
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x000285FC File Offset: 0x000267FC
	public new bool AssignedControlOf(global::IDBase idBase)
	{
		return this._controllable.AssignedControlOf(idBase);
	}

	// Token: 0x060009BB RID: 2491 RVA: 0x0002860C File Offset: 0x0002680C
	public new global::RelativeControl RelativeControlTo(global::Controllable controllable)
	{
		return this._controllable.RelativeControlTo(controllable);
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x0002861C File Offset: 0x0002681C
	public new global::RelativeControl RelativeControlTo(global::Controller controller)
	{
		return this._controllable.RelativeControlTo(controller);
	}

	// Token: 0x060009BD RID: 2493 RVA: 0x0002862C File Offset: 0x0002682C
	public new global::RelativeControl RelativeControlTo(global::Character character)
	{
		return this._controllable.RelativeControlTo(character);
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x0002863C File Offset: 0x0002683C
	public new global::RelativeControl RelativeControlTo(global::IDMain main)
	{
		return this._controllable.RelativeControlTo(main);
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x0002864C File Offset: 0x0002684C
	public new global::RelativeControl RelativeControlTo(global::IDLocalCharacter idLocal)
	{
		return this._controllable.RelativeControlTo(idLocal);
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x0002865C File Offset: 0x0002685C
	public new global::RelativeControl RelativeControlTo(global::IDBase idBase)
	{
		return this._controllable.RelativeControlTo(idBase);
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x0002866C File Offset: 0x0002686C
	public new global::RelativeControl RelativeControlFrom(global::Controllable controllable)
	{
		return this._controllable.RelativeControlFrom(controllable);
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x0002867C File Offset: 0x0002687C
	public new global::RelativeControl RelativeControlFrom(global::Controller controller)
	{
		return this._controllable.RelativeControlFrom(controller);
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x0002868C File Offset: 0x0002688C
	public new global::RelativeControl RelativeControlFrom(global::Character character)
	{
		return this._controllable.RelativeControlFrom(character);
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x0002869C File Offset: 0x0002689C
	public new global::RelativeControl RelativeControlFrom(global::IDMain main)
	{
		return this._controllable.RelativeControlFrom(main);
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x000286AC File Offset: 0x000268AC
	public new global::RelativeControl RelativeControlFrom(global::IDLocalCharacter idLocal)
	{
		return this._controllable.RelativeControlFrom(idLocal);
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x000286BC File Offset: 0x000268BC
	public new global::RelativeControl RelativeControlFrom(global::IDBase idBase)
	{
		return this._controllable.RelativeControlFrom(idBase);
	}

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x060009C7 RID: 2503 RVA: 0x000286CC File Offset: 0x000268CC
	public new global::Controllable masterControllable
	{
		get
		{
			return this._controllable.masterControllable;
		}
	}

	// Token: 0x17000252 RID: 594
	// (get) Token: 0x060009C8 RID: 2504 RVA: 0x000286DC File Offset: 0x000268DC
	public new global::Controllable rootControllable
	{
		get
		{
			return this._controllable.rootControllable;
		}
	}

	// Token: 0x17000253 RID: 595
	// (get) Token: 0x060009C9 RID: 2505 RVA: 0x000286EC File Offset: 0x000268EC
	public new global::Controllable nextControllable
	{
		get
		{
			return this._controllable.nextControllable;
		}
	}

	// Token: 0x17000254 RID: 596
	// (get) Token: 0x060009CA RID: 2506 RVA: 0x000286FC File Offset: 0x000268FC
	public new global::Controllable previousControllable
	{
		get
		{
			return this._controllable.previousControllable;
		}
	}

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x060009CB RID: 2507 RVA: 0x0002870C File Offset: 0x0002690C
	public new global::Character previousCharacter
	{
		get
		{
			return this._controllable.previousCharacter;
		}
	}

	// Token: 0x17000256 RID: 598
	// (get) Token: 0x060009CC RID: 2508 RVA: 0x0002871C File Offset: 0x0002691C
	public new global::Character rootCharacter
	{
		get
		{
			return this._controllable.rootCharacter;
		}
	}

	// Token: 0x17000257 RID: 599
	// (get) Token: 0x060009CD RID: 2509 RVA: 0x0002872C File Offset: 0x0002692C
	public new global::Character nextCharacter
	{
		get
		{
			return this._controllable.nextCharacter;
		}
	}

	// Token: 0x17000258 RID: 600
	// (get) Token: 0x060009CE RID: 2510 RVA: 0x0002873C File Offset: 0x0002693C
	public new global::Character masterCharacter
	{
		get
		{
			return this._controllable.masterCharacter;
		}
	}

	// Token: 0x17000259 RID: 601
	// (get) Token: 0x060009CF RID: 2511 RVA: 0x0002874C File Offset: 0x0002694C
	public new global::Controller masterController
	{
		get
		{
			return this._controllable.masterController;
		}
	}

	// Token: 0x1700025A RID: 602
	// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0002875C File Offset: 0x0002695C
	public new global::Controller rootController
	{
		get
		{
			return this._controllable.rootController;
		}
	}

	// Token: 0x1700025B RID: 603
	// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0002876C File Offset: 0x0002696C
	public new global::Controller nextController
	{
		get
		{
			return this._controllable.nextController;
		}
	}

	// Token: 0x1700025C RID: 604
	// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0002877C File Offset: 0x0002697C
	public new global::Controller previousController
	{
		get
		{
			return this._controllable.previousController;
		}
	}

	// Token: 0x1700025D RID: 605
	// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0002878C File Offset: 0x0002698C
	public new int controlDepth
	{
		get
		{
			return this._controllable.controlDepth;
		}
	}

	// Token: 0x1700025E RID: 606
	// (get) Token: 0x060009D4 RID: 2516 RVA: 0x0002879C File Offset: 0x0002699C
	public new int controlCount
	{
		get
		{
			return this._controllable.controlCount;
		}
	}

	// Token: 0x1700025F RID: 607
	// (get) Token: 0x060009D5 RID: 2517 RVA: 0x000287AC File Offset: 0x000269AC
	public new string controllerClassName
	{
		get
		{
			return this._controllable.controllerClassName;
		}
	}

	// Token: 0x17000260 RID: 608
	// (get) Token: 0x060009D6 RID: 2518 RVA: 0x000287BC File Offset: 0x000269BC
	public new string npcName
	{
		get
		{
			return this._controllable.npcName;
		}
	}

	// Token: 0x17000261 RID: 609
	// (get) Token: 0x060009D7 RID: 2519 RVA: 0x000287CC File Offset: 0x000269CC
	// (set) Token: 0x060009D8 RID: 2520 RVA: 0x000287D4 File Offset: 0x000269D4
	public new global::RPOSLimitFlags rposLimitFlags
	{
		get
		{
			return this._rposLimitFlags;
		}
		protected internal set
		{
			this._rposLimitFlags = value;
		}
	}

	// Token: 0x17000262 RID: 610
	// (get) Token: 0x060009D9 RID: 2521 RVA: 0x000287E0 File Offset: 0x000269E0
	// (set) Token: 0x060009DA RID: 2522 RVA: 0x000287E8 File Offset: 0x000269E8
	public bool forwardsPlayerClientInput
	{
		get
		{
			return this._forwardsPlayerClientInput;
		}
		protected set
		{
			this._forwardsPlayerClientInput = value;
		}
	}

	// Token: 0x17000263 RID: 611
	// (get) Token: 0x060009DB RID: 2523 RVA: 0x000287F4 File Offset: 0x000269F4
	// (set) Token: 0x060009DC RID: 2524 RVA: 0x000287FC File Offset: 0x000269FC
	public bool doesNotSave
	{
		get
		{
			return this._doesNotSave;
		}
		protected set
		{
			this._doesNotSave = value;
		}
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x00028808 File Offset: 0x00026A08
	protected virtual void OnControllerSetup(global::uLink.NetworkView networkView, ref global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x0002880C File Offset: 0x00026A0C
	internal void ControllerSetup(global::Controllable controllable, global::uLink.NetworkView view, ref global::uLink.NetworkMessageInfo info)
	{
		if (this.wasSetup)
		{
			throw new global::System.InvalidOperationException("Already was setup");
		}
		this.wasSetup = true;
		global::Controller.ControllerFlags controllerFlags = this.controllerFlags & global::Controller.ControllerFlags.DontMessWithEnabled;
		bool flag;
		if (controllerFlags != global::Controller.ControllerFlags.AlwaysSavedAsDisabled)
		{
			if (controllerFlags != global::Controller.ControllerFlags.AlwaysSavedAsEnabled)
			{
				flag = (controllerFlags == global::Controller.ControllerFlags.DontMessWithEnabled);
			}
			else
			{
				flag = false;
				if (!base.enabled)
				{
					base.enabled = true;
					global::UnityEngine.Debug.LogError("this was not saved as disabled", this);
				}
			}
		}
		else
		{
			flag = false;
			if (base.enabled)
			{
				base.enabled = false;
				global::UnityEngine.Debug.LogError("this was not saved as enabled", this);
			}
		}
		this._controllable = controllable;
		if (this.playerControlled)
		{
			if (this.localPlayerControlled)
			{
				if ((this.controllerFlags & global::Controller.ControllerFlags.IncompatibleAsLocalPlayer) == global::Controller.ControllerFlags.IncompatibleAsLocalPlayer)
				{
					throw new global::System.NotSupportedException();
				}
			}
			else if ((this.controllerFlags & global::Controller.ControllerFlags.IncompatibleAsRemotePlayer) == global::Controller.ControllerFlags.IncompatibleAsRemotePlayer)
			{
				throw new global::System.NotSupportedException();
			}
		}
		else if (this.localAIControlled)
		{
			if ((this.controllerFlags & global::Controller.ControllerFlags.IncompatibleAsLocalAI) == global::Controller.ControllerFlags.IncompatibleAsLocalAI)
			{
				throw new global::System.NotSupportedException();
			}
		}
		else if ((this.controllerFlags & global::Controller.ControllerFlags.IncompatibleAsRemoteAI) == global::Controller.ControllerFlags.IncompatibleAsRemoteAI)
		{
			throw new global::System.NotSupportedException();
		}
		this.OnControllerSetup(view, ref info);
		if (!flag)
		{
			global::Controller.ControllerFlags controllerFlags2;
			global::Controller.ControllerFlags controllerFlags3;
			if (this.playerControlled)
			{
				if (this.localPlayerControlled)
				{
					controllerFlags2 = global::Controller.ControllerFlags.EnableWhenLocalPlayer;
					controllerFlags3 = global::Controller.ControllerFlags.DisableWhenLocalPlayer;
				}
				else
				{
					controllerFlags2 = global::Controller.ControllerFlags.EnableWhenRemotePlayer;
					controllerFlags3 = global::Controller.ControllerFlags.DisableWhenRemotePlayer;
				}
			}
			else if (this.localAIControlled)
			{
				controllerFlags2 = global::Controller.ControllerFlags.EnableWhenLocalAI;
				controllerFlags3 = global::Controller.ControllerFlags.DisableWhenLocalAI;
			}
			else
			{
				controllerFlags2 = global::Controller.ControllerFlags.EnableWhenRemoteAI;
				controllerFlags3 = global::Controller.ControllerFlags.DisableWhenRemoteAI;
			}
			if ((this.controllerFlags & controllerFlags2) == controllerFlags2)
			{
				if ((this.controllerFlags & controllerFlags3) == controllerFlags3)
				{
					base.enabled = !base.enabled;
				}
				else
				{
					base.enabled = true;
				}
			}
			else if ((this.controllerFlags & controllerFlags3) == controllerFlags3)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x00028A0C File Offset: 0x00026C0C
	protected virtual void OnControlEnter()
	{
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x00028A10 File Offset: 0x00026C10
	protected virtual void OnControlEngauge()
	{
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x00028A14 File Offset: 0x00026C14
	protected virtual void OnControlCease()
	{
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x00028A18 File Offset: 0x00026C18
	protected virtual void OnControlExit()
	{
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x00028A1C File Offset: 0x00026C1C
	[global::System.Obsolete("Used only by Controllable")]
	internal void ControlEnter(int cmd)
	{
		global::Controller.Commandment commandment = this.commandment;
		this.commandment = new global::Controller.Commandment((cmd & 0x7FFF) | 0x8000);
		try
		{
			this.OnControlEnter();
		}
		finally
		{
			this.commandment = commandment;
		}
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x00028A78 File Offset: 0x00026C78
	[global::System.Obsolete("Used only by Controllable")]
	internal void ControlExit(int cmd)
	{
		global::Controller.Commandment commandment = this.commandment;
		this.commandment = new global::Controller.Commandment((cmd & 0x7FFF) | 0x20000);
		try
		{
			this.OnControlExit();
		}
		finally
		{
			this.commandment = commandment;
		}
	}

	// Token: 0x060009E5 RID: 2533 RVA: 0x00028AD4 File Offset: 0x00026CD4
	[global::System.Obsolete("Used only by Controllable")]
	internal void ControlEngauge(int cmd)
	{
		global::Controller.Commandment commandment = this.commandment;
		this.commandment = new global::Controller.Commandment((cmd & 0x7FFF) | 0x10000);
		try
		{
			this.OnControlEngauge();
		}
		finally
		{
			this.commandment = commandment;
		}
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x00028B30 File Offset: 0x00026D30
	[global::System.Obsolete("Used only by Controllable")]
	internal void ControlCease(int cmd)
	{
		global::Controller.Commandment commandment = this.commandment;
		this.commandment = new global::Controller.Commandment((cmd & 0x7FFF) | 0x18000);
		try
		{
			this.OnControlCease();
		}
		finally
		{
			this.commandment = commandment;
		}
	}

	// Token: 0x17000264 RID: 612
	// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00028B8C File Offset: 0x00026D8C
	public static global::System.Collections.Generic.IEnumerable<global::Controller> PlayerRootControllers
	{
		get
		{
			foreach (global::PlayerClient pc in global::PlayerClient.All)
			{
				global::Controllable controllable = pc.rootControllable;
				if (controllable)
				{
					global::Controller controller = controllable.controller;
					if (controller)
					{
						yield return controllable.controller;
					}
				}
			}
			yield break;
		}
	}

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x060009E8 RID: 2536 RVA: 0x00028BA8 File Offset: 0x00026DA8
	public static global::System.Collections.Generic.IEnumerable<global::Controller> PlayerCurrentControllers
	{
		get
		{
			foreach (global::PlayerClient pc in global::PlayerClient.All)
			{
				global::Controllable controllable = pc.controllable;
				if (controllable)
				{
					global::Controller controller = controllable.controller;
					if (controller)
					{
						yield return controllable.controller;
					}
				}
			}
			yield break;
		}
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x00028BC4 File Offset: 0x00026DC4
	public static global::System.Collections.Generic.IEnumerable<global::Controller> RootControllers(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients)
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.rootControllable;
			if (controllable)
			{
				global::Controller controller = controllable.controller;
				if (controller)
				{
					yield return controller;
				}
			}
		}
		yield break;
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x00028BF0 File Offset: 0x00026DF0
	public static global::System.Collections.Generic.IEnumerable<global::Controller> CurrentControllers(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients)
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.controllable;
			if (controllable)
			{
				global::Controller controller = controllable.controller;
				if (controller)
				{
					yield return controller;
				}
			}
		}
		yield break;
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x00028C1C File Offset: 0x00026E1C
	public static global::System.Collections.Generic.IEnumerable<TController> RootControllers<TController>(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients) where TController : global::Controller
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.rootControllable;
			if (controllable)
			{
				TController controller = controllable.controller as TController;
				if (controller)
				{
					yield return controller;
				}
			}
		}
		yield break;
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x00028C48 File Offset: 0x00026E48
	public static global::System.Collections.Generic.IEnumerable<TController> CurrentControllers<TController>(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients) where TController : global::Controller
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.controllable;
			if (controllable)
			{
				TController controller = controllable.controller as TController;
				if (controller)
				{
					yield return controller;
				}
			}
		}
		yield break;
	}

	// Token: 0x040006F5 RID: 1781
	[global::System.NonSerialized]
	private global::Controllable _controllable;

	// Token: 0x040006F6 RID: 1782
	[global::System.NonSerialized]
	private readonly global::Controller.ControllerFlags controllerFlags;

	// Token: 0x040006F7 RID: 1783
	[global::System.NonSerialized]
	private global::RPOSLimitFlags _rposLimitFlags;

	// Token: 0x040006F8 RID: 1784
	[global::System.NonSerialized]
	private bool wasSetup;

	// Token: 0x040006F9 RID: 1785
	[global::System.NonSerialized]
	private bool _forwardsPlayerClientInput;

	// Token: 0x040006FA RID: 1786
	[global::System.NonSerialized]
	private bool _doesNotSave;

	// Token: 0x040006FB RID: 1787
	[global::System.NonSerialized]
	protected global::Controller.Commandment commandment;

	// Token: 0x0200015F RID: 351
	protected enum ControllerFlags
	{
		// Token: 0x040006FD RID: 1789
		EnableWhenLocalPlayer = 1,
		// Token: 0x040006FE RID: 1790
		EnableWhenLocalAI,
		// Token: 0x040006FF RID: 1791
		EnableWhenRemotePlayer = 4,
		// Token: 0x04000700 RID: 1792
		EnableWhenRemoteAI = 8,
		// Token: 0x04000701 RID: 1793
		DisableWhenLocalPlayer = 0x10,
		// Token: 0x04000702 RID: 1794
		DisableWhenLocalAI = 0x20,
		// Token: 0x04000703 RID: 1795
		DisableWhenRemotePlayer = 0x40,
		// Token: 0x04000704 RID: 1796
		DisableWhenRemoteAI = 0x80,
		// Token: 0x04000705 RID: 1797
		ToggleEnableWhenLocalPlayer = 0x11,
		// Token: 0x04000706 RID: 1798
		ToggleEnableLocalAI = 0x22,
		// Token: 0x04000707 RID: 1799
		ToggleEnableRemotePlayer = 0x44,
		// Token: 0x04000708 RID: 1800
		ToggleEnableRemoteAI = 0x88,
		// Token: 0x04000709 RID: 1801
		AlwaysSavedAsDisabled = 0x100,
		// Token: 0x0400070A RID: 1802
		AlwaysSavedAsEnabled = 0x200,
		// Token: 0x0400070B RID: 1803
		DontMessWithEnabled = 0x300,
		// Token: 0x0400070C RID: 1804
		IncompatibleAsRemoteAI = 0x400,
		// Token: 0x0400070D RID: 1805
		IncompatibleAsRemotePlayer = 0x800,
		// Token: 0x0400070E RID: 1806
		IncompatibleAsLocalPlayer = 0x1000,
		// Token: 0x0400070F RID: 1807
		IncompatibleAsLocalAI = 0x2000
	}

	// Token: 0x02000160 RID: 352
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Sequential, Size = 4)]
	protected internal struct Commandment
	{
		// Token: 0x060009ED RID: 2541 RVA: 0x00028C74 File Offset: 0x00026E74
		internal Commandment(int f)
		{
			this.f = (f & 0x3FFFF);
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x060009EE RID: 2542 RVA: 0x00028C84 File Offset: 0x00026E84
		public bool thisDestroying
		{
			get
			{
				return (this.f & 1) == 1;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x00028C94 File Offset: 0x00026E94
		public bool baseDestroying
		{
			get
			{
				return (this.f & 2) == 2;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x00028CA4 File Offset: 0x00026EA4
		public bool rootDestroying
		{
			get
			{
				return (this.f & 4) == 4;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x00028CB4 File Offset: 0x00026EB4
		public bool baseExit
		{
			get
			{
				return (this.f & 0x20) == 0x20;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x00028CC4 File Offset: 0x00026EC4
		public bool thisExit
		{
			get
			{
				return (this.f & 0x10) == 0x10;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x00028CD4 File Offset: 0x00026ED4
		public bool rootExit
		{
			get
			{
				return (this.f & 0x40) == 0x40;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x00028CE4 File Offset: 0x00026EE4
		public bool networkValid
		{
			get
			{
				return (this.f & 8) == 0;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x00028CF4 File Offset: 0x00026EF4
		public bool networkInvalid
		{
			get
			{
				return (this.f & 8) == 8;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x00028D04 File Offset: 0x00026F04
		public bool overrideThis
		{
			get
			{
				return (this.f & 0x80) == 0x80;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x00028D1C File Offset: 0x00026F1C
		public bool overrideBase
		{
			get
			{
				return (this.f & 0x100) == 0x100;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x00028D34 File Offset: 0x00026F34
		public bool overrideRoot
		{
			get
			{
				return (this.f & 0x200) == 0x200;
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x00028D4C File Offset: 0x00026F4C
		public bool ownerServer
		{
			get
			{
				return (this.f & 0x2000) == 0;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x00028D60 File Offset: 0x00026F60
		public bool ownerClient
		{
			get
			{
				return (this.f & 0x2000) == 0x2000;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x00028D78 File Offset: 0x00026F78
		public bool runningLocally
		{
			get
			{
				return (this.f & 0x4000) == 0x4000;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x00028D90 File Offset: 0x00026F90
		public bool runningRemotely
		{
			get
			{
				return (this.f & 0x4000) == 0;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x00028DA4 File Offset: 0x00026FA4
		public bool callFirst
		{
			get
			{
				return (this.f & 0x400) == 0;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x00028DB8 File Offset: 0x00026FB8
		public bool callAgain
		{
			get
			{
				return (this.f & 0x400) == 0x400;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00028DD0 File Offset: 0x00026FD0
		public bool bindWeak
		{
			get
			{
				return (this.f & 0x1000) == 0;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00028DE4 File Offset: 0x00026FE4
		public bool bindStrong
		{
			get
			{
				return (this.f & 0x1000) == 0x1000;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00028DFC File Offset: 0x00026FFC
		public bool kindRoot
		{
			get
			{
				return (this.f & 0x800) == 0x800;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00028E14 File Offset: 0x00027014
		public bool kindVessel
		{
			get
			{
				return (this.f & 0x800) == 0;
			}
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00028E28 File Offset: 0x00027028
		public override string ToString()
		{
			if ((this.f & 0x38000) != 0)
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				int num = this.f & 0x70;
				switch (num)
				{
				case 0x10:
					stringBuilder.Append("exit[THIS]");
					break;
				default:
					if (num != 0x20)
					{
						if (num != 0x24)
						{
							if (num != 0x40)
							{
								if (num == 0x70)
								{
									stringBuilder.Append("exit[ALL]");
								}
							}
							else
							{
								stringBuilder.Append("exit[ROOT]");
							}
						}
						else
						{
							stringBuilder.Append("exit[BASE,ROOT]");
						}
					}
					else
					{
						stringBuilder.Append("exit[BASE]");
					}
					break;
				case 0x12:
					stringBuilder.Append("exit[THIS,BASE]");
					break;
				case 0x14:
					stringBuilder.Append("exit[THIS,ROOT]");
					break;
				}
				num = (this.f & 0x380);
				switch (num)
				{
				case 0x80:
					stringBuilder.Append("override[THIS]");
					break;
				default:
					if (num != 0x100)
					{
						if (num != 0x104)
						{
							if (num != 0x200)
							{
								if (num == 0x380)
								{
									stringBuilder.Append("override[ALL]");
								}
							}
							else
							{
								stringBuilder.Append("override[ROOT]");
							}
						}
						else
						{
							stringBuilder.Append("override[BASE,ROOT]");
						}
					}
					else
					{
						stringBuilder.Append("override[BASE]");
					}
					break;
				case 0x82:
					stringBuilder.Append("override[THIS,BASE]");
					break;
				case 0x84:
					stringBuilder.Append("override[THIS,ROOT]");
					break;
				}
				num = (this.f & 0x800);
				if (num != 0)
				{
					if (num == 0x800)
					{
						stringBuilder.Append("kind[ROOT]");
					}
				}
				else
				{
					stringBuilder.Append("kind[VESL]");
				}
				num = (this.f & 0x1000);
				if (num != 0)
				{
					if (num == 0x1000)
					{
						stringBuilder.Append("bind[STRONG]");
					}
				}
				else
				{
					stringBuilder.Append("bind[WEAK]");
				}
				num = (this.f & 0x2000);
				if (num != 0)
				{
					if (num == 0x2000)
					{
						stringBuilder.Append("client[");
					}
				}
				else
				{
					stringBuilder.Append("server[");
				}
				num = (this.f & 0x4000);
				if (num != 0)
				{
					if (num == 0x4000)
					{
						stringBuilder.Append("LOCAL]");
					}
				}
				else
				{
					stringBuilder.Append("RMOTE]");
				}
				num = (this.f & 8);
				if (num != 0)
				{
					if (num == 8)
					{
						stringBuilder.Append("net[NOO]");
					}
				}
				else
				{
					stringBuilder.Append("net[YES]");
				}
				switch (this.f & 7)
				{
				case 1:
					stringBuilder.Append("destroy[THIS]");
					break;
				case 2:
					stringBuilder.Append("destroy[BASE]");
					break;
				case 3:
					stringBuilder.Append("destroy[THIS,BASE]");
					break;
				case 4:
					stringBuilder.Append("destroy[ROOT]");
					break;
				case 5:
					stringBuilder.Append("destroy[THIS,ROOT]");
					break;
				case 6:
					stringBuilder.Append("destroy[BASE,ROOT]");
					break;
				case 7:
					stringBuilder.Append("destroy[ALL]");
					break;
				}
				num = (this.f & 0x38000);
				if (num != 0x8000)
				{
					if (num != 0x10000)
					{
						if (num != 0x18000)
						{
							if (num == 0x20000)
							{
								stringBuilder.Append("->EXIT");
							}
						}
						else
						{
							stringBuilder.Append("->DEMO");
						}
					}
					else
					{
						stringBuilder.Append("->PRMO");
					}
				}
				else
				{
					stringBuilder.Append("->ENTR");
				}
				if ((this.f & 0x400) == 0)
				{
					stringBuilder.Append("(first)");
				}
				return stringBuilder.ToString();
			}
			return "INVALID";
		}

		// Token: 0x04000710 RID: 1808
		private const int B = 1;

		// Token: 0x04000711 RID: 1809
		internal const int THIS_TO_BASE = 1;

		// Token: 0x04000712 RID: 1810
		internal const int THIS_TO_ROOT = 2;

		// Token: 0x04000713 RID: 1811
		internal const int ALL = 0x7FFF;

		// Token: 0x04000714 RID: 1812
		internal const int ALL_THIS = 0x91;

		// Token: 0x04000715 RID: 1813
		internal const int ALL_BASE = 0x122;

		// Token: 0x04000716 RID: 1814
		internal const int ALL_ROOT = 0x244;

		// Token: 0x04000717 RID: 1815
		private readonly int f;

		// Token: 0x02000161 RID: 353
		internal static class DESTROY
		{
			// Token: 0x04000718 RID: 1816
			public const int THIS = 1;

			// Token: 0x04000719 RID: 1817
			public const int BASE = 2;

			// Token: 0x0400071A RID: 1818
			public const int ROOT = 4;

			// Token: 0x0400071B RID: 1819
			public const int NONE = 0;

			// Token: 0x0400071C RID: 1820
			public const int ALL = 7;
		}

		// Token: 0x02000162 RID: 354
		internal static class NETWORK
		{
			// Token: 0x0400071D RID: 1821
			public const int VALID = 0;

			// Token: 0x0400071E RID: 1822
			public const int INVALID = 8;

			// Token: 0x0400071F RID: 1823
			public const int ALL = 8;
		}

		// Token: 0x02000163 RID: 355
		internal static class EXIT
		{
			// Token: 0x04000720 RID: 1824
			public const int THIS = 0x10;

			// Token: 0x04000721 RID: 1825
			public const int BASE = 0x20;

			// Token: 0x04000722 RID: 1826
			public const int ROOT = 0x40;

			// Token: 0x04000723 RID: 1827
			public const int NONE = 0;

			// Token: 0x04000724 RID: 1828
			public const int ALL = 0x70;
		}

		// Token: 0x02000164 RID: 356
		internal static class OVERRIDE
		{
			// Token: 0x04000725 RID: 1829
			public const int THIS = 0x80;

			// Token: 0x04000726 RID: 1830
			public const int BASE = 0x100;

			// Token: 0x04000727 RID: 1831
			public const int ROOT = 0x200;

			// Token: 0x04000728 RID: 1832
			public const int NONE = 0;

			// Token: 0x04000729 RID: 1833
			public const int ALL = 0x380;
		}

		// Token: 0x02000165 RID: 357
		internal static class ONCE
		{
			// Token: 0x0400072A RID: 1834
			public const int TRUE = 0x400;

			// Token: 0x0400072B RID: 1835
			public const int FALSE = 0;

			// Token: 0x0400072C RID: 1836
			public const int ALL = 0x400;
		}

		// Token: 0x02000166 RID: 358
		internal static class KIND
		{
			// Token: 0x0400072D RID: 1837
			public const int ROOT = 0x800;

			// Token: 0x0400072E RID: 1838
			public const int VESSEL = 0;

			// Token: 0x0400072F RID: 1839
			public const int ALL = 0x800;
		}

		// Token: 0x02000167 RID: 359
		internal static class BINDING
		{
			// Token: 0x04000730 RID: 1840
			public const int STRONG = 0x1000;

			// Token: 0x04000731 RID: 1841
			public const int WEAK = 0;

			// Token: 0x04000732 RID: 1842
			public const int ALL = 0x1000;
		}

		// Token: 0x02000168 RID: 360
		internal static class OWNER
		{
			// Token: 0x04000733 RID: 1843
			public const int CLIENT = 0x2000;

			// Token: 0x04000734 RID: 1844
			public const int SERVER = 0;

			// Token: 0x04000735 RID: 1845
			public const int ALL = 0x2000;
		}

		// Token: 0x02000169 RID: 361
		internal static class PLACE
		{
			// Token: 0x04000736 RID: 1846
			public const int HERE = 0x4000;

			// Token: 0x04000737 RID: 1847
			public const int ELSEWHERE = 0;

			// Token: 0x04000738 RID: 1848
			public const int ALL = 0x4000;
		}

		// Token: 0x0200016A RID: 362
		internal static class EVENT
		{
			// Token: 0x04000739 RID: 1849
			public const int NONE = 0;

			// Token: 0x0400073A RID: 1850
			public const int ENTER = 0x8000;

			// Token: 0x0400073B RID: 1851
			public const int ENGAUGE = 0x10000;

			// Token: 0x0400073C RID: 1852
			public const int CEASE = 0x18000;

			// Token: 0x0400073D RID: 1853
			public const int EXIT = 0x20000;

			// Token: 0x0400073E RID: 1854
			public const int ALL = 0x38000;
		}
	}

	// Token: 0x0200016B RID: 363
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator10 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controller>, global::System.Collections.Generic.IEnumerator<global::Controller>
	{
		// Token: 0x06000A04 RID: 2564 RVA: 0x0002928C File Offset: 0x0002748C
		public <>c__Iterator10()
		{
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x00029294 File Offset: 0x00027494
		global::Controller global::System.Collections.Generic.IEnumerator<global::Controller>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x0002929C File Offset: 0x0002749C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000292A4 File Offset: 0x000274A4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controller>.GetEnumerator();
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x000292AC File Offset: 0x000274AC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controller> global::System.Collections.Generic.IEnumerable<global::Controller>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::Controller.<>c__Iterator10();
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x000292C8 File Offset: 0x000274C8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = global::PlayerClient.All.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					controllable = pc.rootControllable;
					if (controllable)
					{
						controller = controllable.controller;
						if (controller)
						{
							this.$current = controllable.controller;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x000293E0 File Offset: 0x000275E0
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00029440 File Offset: 0x00027640
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400073F RID: 1855
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_117>__0;

		// Token: 0x04000740 RID: 1856
		internal global::PlayerClient <pc>__1;

		// Token: 0x04000741 RID: 1857
		internal global::Controllable <controllable>__2;

		// Token: 0x04000742 RID: 1858
		internal global::Controller <controller>__3;

		// Token: 0x04000743 RID: 1859
		internal int $PC;

		// Token: 0x04000744 RID: 1860
		internal global::Controller $current;
	}

	// Token: 0x0200016C RID: 364
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator11 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controller>, global::System.Collections.Generic.IEnumerator<global::Controller>
	{
		// Token: 0x06000A0C RID: 2572 RVA: 0x00029448 File Offset: 0x00027648
		public <>c__Iterator11()
		{
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00029450 File Offset: 0x00027650
		global::Controller global::System.Collections.Generic.IEnumerator<global::Controller>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000A0E RID: 2574 RVA: 0x00029458 File Offset: 0x00027658
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00029460 File Offset: 0x00027660
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controller>.GetEnumerator();
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00029468 File Offset: 0x00027668
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controller> global::System.Collections.Generic.IEnumerable<global::Controller>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::Controller.<>c__Iterator11();
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00029484 File Offset: 0x00027684
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = global::PlayerClient.All.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					controllable = pc.controllable;
					if (controllable)
					{
						controller = controllable.controller;
						if (controller)
						{
							this.$current = controllable.controller;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0002959C File Offset: 0x0002779C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x000295FC File Offset: 0x000277FC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000745 RID: 1861
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_118>__0;

		// Token: 0x04000746 RID: 1862
		internal global::PlayerClient <pc>__1;

		// Token: 0x04000747 RID: 1863
		internal global::Controllable <controllable>__2;

		// Token: 0x04000748 RID: 1864
		internal global::Controller <controller>__3;

		// Token: 0x04000749 RID: 1865
		internal int $PC;

		// Token: 0x0400074A RID: 1866
		internal global::Controller $current;
	}

	// Token: 0x0200016D RID: 365
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RootControllers>c__Iterator12 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controller>, global::System.Collections.Generic.IEnumerator<global::Controller>
	{
		// Token: 0x06000A14 RID: 2580 RVA: 0x00029604 File Offset: 0x00027804
		public <RootControllers>c__Iterator12()
		{
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x0002960C File Offset: 0x0002780C
		global::Controller global::System.Collections.Generic.IEnumerator<global::Controller>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x00029614 File Offset: 0x00027814
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0002961C File Offset: 0x0002781C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controller>.GetEnumerator();
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00029624 File Offset: 0x00027824
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controller> global::System.Collections.Generic.IEnumerable<global::Controller>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Controller.<RootControllers>c__Iterator12 <RootControllers>c__Iterator = new global::Controller.<RootControllers>c__Iterator12();
			<RootControllers>c__Iterator.playerClients = playerClients;
			return <RootControllers>c__Iterator;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00029658 File Offset: 0x00027858
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = playerClients.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					controllable = pc.rootControllable;
					if (controllable)
					{
						controller = controllable.controller;
						if (controller)
						{
							this.$current = controller;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00029770 File Offset: 0x00027970
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x000297D4 File Offset: 0x000279D4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400074B RID: 1867
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x0400074C RID: 1868
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_119>__0;

		// Token: 0x0400074D RID: 1869
		internal global::PlayerClient <pc>__1;

		// Token: 0x0400074E RID: 1870
		internal global::Controllable <controllable>__2;

		// Token: 0x0400074F RID: 1871
		internal global::Controller <controller>__3;

		// Token: 0x04000750 RID: 1872
		internal int $PC;

		// Token: 0x04000751 RID: 1873
		internal global::Controller $current;

		// Token: 0x04000752 RID: 1874
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x0200016E RID: 366
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CurrentControllers>c__Iterator13 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controller>, global::System.Collections.Generic.IEnumerator<global::Controller>
	{
		// Token: 0x06000A1C RID: 2588 RVA: 0x000297DC File Offset: 0x000279DC
		public <CurrentControllers>c__Iterator13()
		{
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x000297E4 File Offset: 0x000279E4
		global::Controller global::System.Collections.Generic.IEnumerator<global::Controller>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x000297EC File Offset: 0x000279EC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000297F4 File Offset: 0x000279F4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controller>.GetEnumerator();
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000297FC File Offset: 0x000279FC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controller> global::System.Collections.Generic.IEnumerable<global::Controller>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Controller.<CurrentControllers>c__Iterator13 <CurrentControllers>c__Iterator = new global::Controller.<CurrentControllers>c__Iterator13();
			<CurrentControllers>c__Iterator.playerClients = playerClients;
			return <CurrentControllers>c__Iterator;
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00029830 File Offset: 0x00027A30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = playerClients.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					controllable = pc.controllable;
					if (controllable)
					{
						controller = controllable.controller;
						if (controller)
						{
							this.$current = controller;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00029948 File Offset: 0x00027B48
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x000299AC File Offset: 0x00027BAC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000753 RID: 1875
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x04000754 RID: 1876
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_120>__0;

		// Token: 0x04000755 RID: 1877
		internal global::PlayerClient <pc>__1;

		// Token: 0x04000756 RID: 1878
		internal global::Controllable <controllable>__2;

		// Token: 0x04000757 RID: 1879
		internal global::Controller <controller>__3;

		// Token: 0x04000758 RID: 1880
		internal int $PC;

		// Token: 0x04000759 RID: 1881
		internal global::Controller $current;

		// Token: 0x0400075A RID: 1882
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x0200016F RID: 367
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RootControllers>c__Iterator14<TController> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0> where TController : global::Controller
	{
		// Token: 0x06000A24 RID: 2596 RVA: 0x000299B4 File Offset: 0x00027BB4
		public <RootControllers>c__Iterator14()
		{
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x000299BC File Offset: 0x00027BBC
		TController global::System.Collections.Generic.IEnumerator<!0>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x000299C4 File Offset: 0x00027BC4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x000299D4 File Offset: 0x00027BD4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<TController>.GetEnumerator();
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x000299DC File Offset: 0x00027BDC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<TController> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Controller.<RootControllers>c__Iterator14<TController> <RootControllers>c__Iterator = new global::Controller.<RootControllers>c__Iterator14<TController>();
			<RootControllers>c__Iterator.playerClients = playerClients;
			return <RootControllers>c__Iterator;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00029A10 File Offset: 0x00027C10
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = playerClients.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					controllable = pc.rootControllable;
					if (controllable)
					{
						controller = (controllable.controller as TController);
						if (controller)
						{
							this.$current = controller;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00029B38 File Offset: 0x00027D38
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00029B9C File Offset: 0x00027D9C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400075B RID: 1883
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x0400075C RID: 1884
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_121>__0;

		// Token: 0x0400075D RID: 1885
		internal global::PlayerClient <pc>__1;

		// Token: 0x0400075E RID: 1886
		internal global::Controllable <controllable>__2;

		// Token: 0x0400075F RID: 1887
		internal TController <controller>__3;

		// Token: 0x04000760 RID: 1888
		internal int $PC;

		// Token: 0x04000761 RID: 1889
		internal TController $current;

		// Token: 0x04000762 RID: 1890
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x02000170 RID: 368
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CurrentControllers>c__Iterator15<TController> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0> where TController : global::Controller
	{
		// Token: 0x06000A2C RID: 2604 RVA: 0x00029BA4 File Offset: 0x00027DA4
		public <CurrentControllers>c__Iterator15()
		{
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x00029BAC File Offset: 0x00027DAC
		TController global::System.Collections.Generic.IEnumerator<!0>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x00029BB4 File Offset: 0x00027DB4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00029BC4 File Offset: 0x00027DC4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<TController>.GetEnumerator();
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00029BCC File Offset: 0x00027DCC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<TController> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Controller.<CurrentControllers>c__Iterator15<TController> <CurrentControllers>c__Iterator = new global::Controller.<CurrentControllers>c__Iterator15<TController>();
			<CurrentControllers>c__Iterator.playerClients = playerClients;
			return <CurrentControllers>c__Iterator;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00029C00 File Offset: 0x00027E00
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = playerClients.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					controllable = pc.controllable;
					if (controllable)
					{
						controller = (controllable.controller as TController);
						if (controller)
						{
							this.$current = controller;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00029D28 File Offset: 0x00027F28
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00029D8C File Offset: 0x00027F8C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000763 RID: 1891
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x04000764 RID: 1892
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_122>__0;

		// Token: 0x04000765 RID: 1893
		internal global::PlayerClient <pc>__1;

		// Token: 0x04000766 RID: 1894
		internal global::Controllable <controllable>__2;

		// Token: 0x04000767 RID: 1895
		internal TController <controller>__3;

		// Token: 0x04000768 RID: 1896
		internal int $PC;

		// Token: 0x04000769 RID: 1897
		internal TController $current;

		// Token: 0x0400076A RID: 1898
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}
}
