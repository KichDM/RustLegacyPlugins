using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using uLink;
using UnityEngine;

// Token: 0x0200011C RID: 284
public class Character : global::IDMain
{
	// Token: 0x06000631 RID: 1585 RVA: 0x0001CB14 File Offset: 0x0001AD14
	public Character() : this(1)
	{
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0001CB20 File Offset: 0x0001AD20
	protected Character(global::IDFlags flags) : base(flags)
	{
	}

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06000633 RID: 1587 RVA: 0x0001CB58 File Offset: 0x0001AD58
	// (remove) Token: 0x06000634 RID: 1588 RVA: 0x0001CB8C File Offset: 0x0001AD8C
	public event global::CharacterDeathSignal signal_death
	{
		add
		{
			if (this._signaledDeath)
			{
				value(this, global::CharacterDeathSignalReason.WasDead);
			}
			else
			{
				this.signals_death = (global::CharacterDeathSignal)global::System.Delegate.Combine(this.signals_death, value);
			}
		}
		remove
		{
			if (!this._signaledDeath)
			{
				this.signals_death = (global::CharacterDeathSignal)global::System.Delegate.Remove(this.signals_death, value);
			}
		}
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06000635 RID: 1589 RVA: 0x0001CBBC File Offset: 0x0001ADBC
	// (remove) Token: 0x06000636 RID: 1590 RVA: 0x0001CBEC File Offset: 0x0001ADEC
	public event global::CharacterStateSignal signal_state
	{
		add
		{
			if (!this._signaledDeath)
			{
				this.signals_state = (global::CharacterStateSignal)global::System.Delegate.Combine(this.signals_state, value);
			}
		}
		remove
		{
			if (!this._signaledDeath)
			{
				this.signals_state = (global::CharacterStateSignal)global::System.Delegate.Remove(this.signals_state, value);
			}
		}
	}

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x06000637 RID: 1591 RVA: 0x0001CC1C File Offset: 0x0001AE1C
	[global::System.Obsolete("this is the character")]
	public global::Character character
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0001CC20 File Offset: 0x0001AE20
	protected void Awake()
	{
		if (!this._originSetup)
		{
			this.OriginSetup();
		}
		if (!this._eyesSetup)
		{
			this.EyesSetup();
		}
	}

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x06000639 RID: 1593 RVA: 0x0001CC50 File Offset: 0x0001AE50
	public global::HitBoxSystem hitBoxSystem
	{
		get
		{
			if (!this.didHitBoxSystemTest)
			{
				global::Character.SeekIDRemoteComponentInChildren<global::Character, global::HitBoxSystem>(this, ref this._hitBoxSystem);
				this.didHitBoxSystemTest = true;
			}
			return this._hitBoxSystem;
		}
	}

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x0600063A RID: 1594 RVA: 0x0001CC78 File Offset: 0x0001AE78
	public global::RecoilSimulation recoilSimulation
	{
		get
		{
			if (!this.didRecoilSimulationTest)
			{
				global::Character.SeekIDLocalComponentInChildren<global::Character, global::RecoilSimulation>(this, ref this._recoilSimulation);
				this.didRecoilSimulationTest = true;
			}
			return this._recoilSimulation;
		}
	}

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x0600063B RID: 1595 RVA: 0x0001CCA0 File Offset: 0x0001AEA0
	public global::NetUser netUser
	{
		get
		{
			global::NetUser result;
			global::NetUser.Find(this.playerClient, out result);
			return result;
		}
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0001CCBC File Offset: 0x0001AEBC
	public bool GetNetUser(out global::NetUser netUser)
	{
		return global::NetUser.Find(this.playerClient, out netUser);
	}

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x0600063D RID: 1597 RVA: 0x0001CCCC File Offset: 0x0001AECC
	public bool controlled
	{
		get
		{
			return this.controllable && this._controllable.controlled;
		}
	}

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x0600063E RID: 1598 RVA: 0x0001CCEC File Offset: 0x0001AEEC
	public bool playerControlled
	{
		get
		{
			return this.controllable && this._controllable.playerControlled;
		}
	}

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x0600063F RID: 1599 RVA: 0x0001CD0C File Offset: 0x0001AF0C
	public bool aiControlled
	{
		get
		{
			return this.controllable && this._controllable.aiControlled;
		}
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001CD2C File Offset: 0x0001AF2C
	public bool localPlayerControlled
	{
		get
		{
			return this.controllable && this._controllable.localPlayerControlled;
		}
	}

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x06000641 RID: 1601 RVA: 0x0001CD4C File Offset: 0x0001AF4C
	public bool remotePlayerControlled
	{
		get
		{
			return this.controllable && this._controllable.remotePlayerControlled;
		}
	}

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x06000642 RID: 1602 RVA: 0x0001CD6C File Offset: 0x0001AF6C
	public bool localAIControlled
	{
		get
		{
			return this.controllable && this._controllable.localAIControlled;
		}
	}

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x06000643 RID: 1603 RVA: 0x0001CD8C File Offset: 0x0001AF8C
	public bool remoteAIControlled
	{
		get
		{
			return this.controllable && this._controllable.remoteAIControlled;
		}
	}

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x06000644 RID: 1604 RVA: 0x0001CDAC File Offset: 0x0001AFAC
	public bool localControlled
	{
		get
		{
			return this.controllable && this._controllable.localControlled;
		}
	}

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x06000645 RID: 1605 RVA: 0x0001CDCC File Offset: 0x0001AFCC
	public bool remoteControlled
	{
		get
		{
			return this.controllable && this._controllable.remoteControlled;
		}
	}

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x06000646 RID: 1606 RVA: 0x0001CDEC File Offset: 0x0001AFEC
	public bool core
	{
		get
		{
			return this.controllable && this._controllable.core;
		}
	}

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x06000647 RID: 1607 RVA: 0x0001CE0C File Offset: 0x0001B00C
	public bool vessel
	{
		get
		{
			return this.controllable && this._controllable.vessel;
		}
	}

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x06000648 RID: 1608 RVA: 0x0001CE2C File Offset: 0x0001B02C
	public global::Controllable controllable
	{
		get
		{
			if (!this.didControllableTest)
			{
				global::Character.SeekComponentInChildren<global::Character, global::Controllable>(this, ref this._controllable);
				this.didControllableTest = true;
			}
			return this._controllable;
		}
	}

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x06000649 RID: 1609 RVA: 0x0001CE54 File Offset: 0x0001B054
	public global::Controllable controlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.controlled) ? null : this._controllable;
		}
	}

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x0600064A RID: 1610 RVA: 0x0001CE90 File Offset: 0x0001B090
	public global::Controllable playerControlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.playerControlled) ? null : this._controllable;
		}
	}

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x0600064B RID: 1611 RVA: 0x0001CECC File Offset: 0x0001B0CC
	public global::Controllable aiControlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.aiControlled) ? null : this._controllable;
		}
	}

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x0600064C RID: 1612 RVA: 0x0001CF08 File Offset: 0x0001B108
	public global::Controllable localPlayerControlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.localPlayerControlled) ? null : this._controllable;
		}
	}

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x0600064D RID: 1613 RVA: 0x0001CF44 File Offset: 0x0001B144
	public global::Controllable localAIControlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.localAIControlled) ? null : this._controllable;
		}
	}

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x0600064E RID: 1614 RVA: 0x0001CF80 File Offset: 0x0001B180
	public global::Controllable remotePlayerControlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.remotePlayerControlled) ? null : this._controllable;
		}
	}

	// Token: 0x17000110 RID: 272
	// (get) Token: 0x0600064F RID: 1615 RVA: 0x0001CFBC File Offset: 0x0001B1BC
	public global::Controllable remoteAIControlledControllable
	{
		get
		{
			return (!this.controllable || !this._controllable.remoteAIControlled) ? null : this._controllable;
		}
	}

	// Token: 0x17000111 RID: 273
	// (get) Token: 0x06000650 RID: 1616 RVA: 0x0001CFF8 File Offset: 0x0001B1F8
	public global::PlayerClient playerClient
	{
		get
		{
			return (!this._controllable) ? null : this._controllable.playerClient;
		}
	}

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x06000651 RID: 1617 RVA: 0x0001D01C File Offset: 0x0001B21C
	public string npcName
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.npcName;
		}
	}

	// Token: 0x17000113 RID: 275
	// (get) Token: 0x06000652 RID: 1618 RVA: 0x0001D040 File Offset: 0x0001B240
	public bool controlOverridden
	{
		get
		{
			return this.controllable && this._controllable.controlOverridden;
		}
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0001D060 File Offset: 0x0001B260
	public bool ControlOverriddenBy(global::Controllable controllable)
	{
		return this.controllable && this._controllable.ControlOverriddenBy(controllable);
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0001D084 File Offset: 0x0001B284
	public bool ControlOverriddenBy(global::Controller controller)
	{
		return this.controllable && this._controllable.ControlOverriddenBy(controller);
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0001D0A8 File Offset: 0x0001B2A8
	public bool ControlOverriddenBy(global::Character character)
	{
		return this.controllable && this._controllable.ControlOverriddenBy(character);
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0001D0CC File Offset: 0x0001B2CC
	public bool ControlOverriddenBy(global::IDMain main)
	{
		return this.controllable && this._controllable.ControlOverriddenBy(main);
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0001D0F0 File Offset: 0x0001B2F0
	public bool ControlOverriddenBy(global::IDBase idBase)
	{
		return this.controllable && this._controllable.ControlOverriddenBy(idBase);
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0001D114 File Offset: 0x0001B314
	public bool ControlOverriddenBy(global::IDLocalCharacter idLocal)
	{
		return this.controllable && this._controllable.ControlOverriddenBy(idLocal);
	}

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x06000659 RID: 1625 RVA: 0x0001D138 File Offset: 0x0001B338
	public bool overridingControl
	{
		get
		{
			return this.controllable && this._controllable.overridingControl;
		}
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x0001D158 File Offset: 0x0001B358
	public bool OverridingControlOf(global::Controllable controllable)
	{
		return this.controllable && this._controllable.OverridingControlOf(controllable);
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x0001D17C File Offset: 0x0001B37C
	public bool OverridingControlOf(global::Controller controller)
	{
		return this.controllable && this._controllable.OverridingControlOf(controller);
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0001D1A0 File Offset: 0x0001B3A0
	public bool OverridingControlOf(global::Character character)
	{
		return this.controllable && this._controllable.OverridingControlOf(character);
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x0001D1C4 File Offset: 0x0001B3C4
	public bool OverridingControlOf(global::IDMain main)
	{
		return this.controllable && this._controllable.OverridingControlOf(main);
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0001D1E8 File Offset: 0x0001B3E8
	public bool OverridingControlOf(global::IDBase idBase)
	{
		return this.controllable && this._controllable.OverridingControlOf(idBase);
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x0001D20C File Offset: 0x0001B40C
	public bool OverridingControlOf(global::IDLocalCharacter idLocal)
	{
		return this.controllable && this._controllable.OverridingControlOf(idLocal);
	}

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x06000660 RID: 1632 RVA: 0x0001D230 File Offset: 0x0001B430
	public bool assignedControl
	{
		get
		{
			return this.controllable && this._controllable.assignedControl;
		}
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x0001D250 File Offset: 0x0001B450
	public bool AssignedControlOf(global::Controllable controllable)
	{
		return this.controllable && this._controllable.AssignedControlOf(controllable);
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0001D274 File Offset: 0x0001B474
	public bool AssignedControlOf(global::Controller controller)
	{
		return this.controllable && this._controllable.AssignedControlOf(controller);
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x0001D298 File Offset: 0x0001B498
	public bool AssignedControlOf(global::IDMain character)
	{
		return this.controllable && this._controllable.AssignedControlOf(character);
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0001D2BC File Offset: 0x0001B4BC
	public bool AssignedControlOf(global::IDBase idBase)
	{
		return this.controllable && this._controllable.AssignedControlOf(idBase);
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x0001D2E0 File Offset: 0x0001B4E0
	public global::RelativeControl RelativeControlTo(global::Controllable controllable)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlTo(controllable);
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x0001D310 File Offset: 0x0001B510
	public global::RelativeControl RelativeControlTo(global::Controller controller)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlTo(controller);
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x0001D340 File Offset: 0x0001B540
	public global::RelativeControl RelativeControlTo(global::Character character)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlTo(character);
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x0001D370 File Offset: 0x0001B570
	public global::RelativeControl RelativeControlTo(global::IDMain main)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlTo(main);
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x0001D3A0 File Offset: 0x0001B5A0
	public global::RelativeControl RelativeControlTo(global::IDLocalCharacter idLocal)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlTo(idLocal);
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
	public global::RelativeControl RelativeControlTo(global::IDBase idBase)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlTo(idBase);
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x0001D400 File Offset: 0x0001B600
	public global::RelativeControl RelativeControlFrom(global::Controllable controllable)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlFrom(controllable);
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x0001D430 File Offset: 0x0001B630
	public global::RelativeControl RelativeControlFrom(global::Controller controller)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlFrom(controller);
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x0001D460 File Offset: 0x0001B660
	public global::RelativeControl RelativeControlFrom(global::Character character)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlFrom(character);
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x0001D490 File Offset: 0x0001B690
	public global::RelativeControl RelativeControlFrom(global::IDMain main)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlFrom(main);
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x0001D4C0 File Offset: 0x0001B6C0
	public global::RelativeControl RelativeControlFrom(global::IDLocalCharacter idLocal)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlFrom(idLocal);
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x0001D4F0 File Offset: 0x0001B6F0
	public global::RelativeControl RelativeControlFrom(global::IDBase idBase)
	{
		return (!this.controllable) ? global::RelativeControl.Incompatible : this._controllable.RelativeControlFrom(idBase);
	}

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x06000671 RID: 1649 RVA: 0x0001D520 File Offset: 0x0001B720
	public global::Controllable masterControllable
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.masterControllable;
		}
	}

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x06000672 RID: 1650 RVA: 0x0001D544 File Offset: 0x0001B744
	public global::Controllable rootControllable
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.rootControllable;
		}
	}

	// Token: 0x17000118 RID: 280
	// (get) Token: 0x06000673 RID: 1651 RVA: 0x0001D568 File Offset: 0x0001B768
	public global::Controllable nextControllable
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.nextControllable;
		}
	}

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x06000674 RID: 1652 RVA: 0x0001D58C File Offset: 0x0001B78C
	public global::Controllable previousControllable
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.previousControllable;
		}
	}

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x06000675 RID: 1653 RVA: 0x0001D5B0 File Offset: 0x0001B7B0
	public global::Character masterCharacter
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.masterCharacter;
		}
	}

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x06000676 RID: 1654 RVA: 0x0001D5D4 File Offset: 0x0001B7D4
	public global::Character rootCharacter
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.rootCharacter;
		}
	}

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x06000677 RID: 1655 RVA: 0x0001D5F8 File Offset: 0x0001B7F8
	public global::Character nextCharacter
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.nextCharacter;
		}
	}

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x06000678 RID: 1656 RVA: 0x0001D61C File Offset: 0x0001B81C
	public global::Character previousCharacter
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.previousCharacter;
		}
	}

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x06000679 RID: 1657 RVA: 0x0001D640 File Offset: 0x0001B840
	public int controlDepth
	{
		get
		{
			return (!this.controllable) ? -1 : this._controllable.controlDepth;
		}
	}

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x0600067A RID: 1658 RVA: 0x0001D664 File Offset: 0x0001B864
	public int controlCount
	{
		get
		{
			return (!this.controllable) ? 0 : this._controllable.controlCount;
		}
	}

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x0600067B RID: 1659 RVA: 0x0001D688 File Offset: 0x0001B888
	public string controllerClassName
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.controllerClassName;
		}
	}

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x0600067C RID: 1660 RVA: 0x0001D6AC File Offset: 0x0001B8AC
	public global::Controller controller
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.controller;
		}
	}

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x0600067D RID: 1661 RVA: 0x0001D6D0 File Offset: 0x0001B8D0
	public global::Controller controlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.controlledController;
		}
	}

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x0600067E RID: 1662 RVA: 0x0001D6F4 File Offset: 0x0001B8F4
	public global::Controller playerControlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.playerControlledController;
		}
	}

	// Token: 0x17000124 RID: 292
	// (get) Token: 0x0600067F RID: 1663 RVA: 0x0001D718 File Offset: 0x0001B918
	public global::Controller aiControlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.aiControlledController;
		}
	}

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x06000680 RID: 1664 RVA: 0x0001D73C File Offset: 0x0001B93C
	public global::Controller localPlayerControlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.localPlayerControlledController;
		}
	}

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x06000681 RID: 1665 RVA: 0x0001D760 File Offset: 0x0001B960
	public global::Controller localAIControlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.localAIControlledController;
		}
	}

	// Token: 0x17000127 RID: 295
	// (get) Token: 0x06000682 RID: 1666 RVA: 0x0001D784 File Offset: 0x0001B984
	public global::Controller remotePlayerControlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.remotePlayerControlledController;
		}
	}

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x06000683 RID: 1667 RVA: 0x0001D7A8 File Offset: 0x0001B9A8
	public global::Controller remoteAIControlledController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.remoteAIControlledController;
		}
	}

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x06000684 RID: 1668 RVA: 0x0001D7CC File Offset: 0x0001B9CC
	public global::Controller masterController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.masterController;
		}
	}

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x06000685 RID: 1669 RVA: 0x0001D7F0 File Offset: 0x0001B9F0
	public global::Controller rootController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.rootController;
		}
	}

	// Token: 0x1700012B RID: 299
	// (get) Token: 0x06000686 RID: 1670 RVA: 0x0001D814 File Offset: 0x0001BA14
	public global::Controller nextController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.nextController;
		}
	}

	// Token: 0x1700012C RID: 300
	// (get) Token: 0x06000687 RID: 1671 RVA: 0x0001D838 File Offset: 0x0001BA38
	public global::Controller previousController
	{
		get
		{
			return (!this.controllable) ? null : this._controllable.previousController;
		}
	}

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x06000688 RID: 1672 RVA: 0x0001D85C File Offset: 0x0001BA5C
	public global::TakeDamage takeDamage
	{
		get
		{
			if (!this.didTakeDamageTest)
			{
				global::Character.SeekIDLocalComponentInChildren<global::Character, global::TakeDamage>(this, ref this._takeDamage);
				this.didTakeDamageTest = true;
			}
			return this._takeDamage;
		}
	}

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06000689 RID: 1673 RVA: 0x0001D884 File Offset: 0x0001BA84
	public float health
	{
		get
		{
			return (!this.takeDamage) ? float.PositiveInfinity : this._takeDamage.health;
		}
	}

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x0600068A RID: 1674 RVA: 0x0001D8AC File Offset: 0x0001BAAC
	public float healthFraction
	{
		get
		{
			return (!this.takeDamage) ? 1f : this._takeDamage.healthFraction;
		}
	}

	// Token: 0x17000130 RID: 304
	// (get) Token: 0x0600068B RID: 1675 RVA: 0x0001D8D4 File Offset: 0x0001BAD4
	public bool alive
	{
		get
		{
			return !this.takeDamage || this._takeDamage.alive;
		}
	}

	// Token: 0x17000131 RID: 305
	// (get) Token: 0x0600068C RID: 1676 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
	public bool dead
	{
		get
		{
			return this.takeDamage && this._takeDamage.dead;
		}
	}

	// Token: 0x17000132 RID: 306
	// (get) Token: 0x0600068D RID: 1677 RVA: 0x0001D91C File Offset: 0x0001BB1C
	public float healthLoss
	{
		get
		{
			return (!this.takeDamage) ? 0f : this._takeDamage.healthLoss;
		}
	}

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x0600068E RID: 1678 RVA: 0x0001D944 File Offset: 0x0001BB44
	public float healthLossFraction
	{
		get
		{
			return (!this.takeDamage) ? 0f : this._takeDamage.healthLossFraction;
		}
	}

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x0600068F RID: 1679 RVA: 0x0001D96C File Offset: 0x0001BB6C
	public float maxHealth
	{
		get
		{
			return (!this.takeDamage) ? float.PositiveInfinity : this._takeDamage.maxHealth;
		}
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x0001D994 File Offset: 0x0001BB94
	public void AdjustClientSideHealth(float newHealthValue)
	{
	}

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x06000691 RID: 1681 RVA: 0x0001D998 File Offset: 0x0001BB98
	public float maxPitch
	{
		get
		{
			return this._maxPitch;
		}
	}

	// Token: 0x17000136 RID: 310
	// (get) Token: 0x06000692 RID: 1682 RVA: 0x0001D9A0 File Offset: 0x0001BBA0
	public float minPitch
	{
		get
		{
			return this._minPitch;
		}
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x0001D9A8 File Offset: 0x0001BBA8
	public float ClampPitch(float v)
	{
		return (v >= this._minPitch) ? ((v <= this._maxPitch) ? v : this._maxPitch) : this._minPitch;
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x0001D9DC File Offset: 0x0001BBDC
	public void ClampPitch(ref float v)
	{
		if (v < this._minPitch)
		{
			v = this._minPitch;
		}
		else if (v > this._maxPitch)
		{
			v = this._maxPitch;
		}
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x0001DA10 File Offset: 0x0001BC10
	public global::Angle2 ClampPitch(global::Angle2 v)
	{
		this.ClampPitch(ref v.pitch);
		return v;
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x0001DA20 File Offset: 0x0001BC20
	public void ClampPitch(ref global::Angle2 v)
	{
		this.ClampPitch(ref v.pitch);
	}

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x06000697 RID: 1687 RVA: 0x0001DA30 File Offset: 0x0001BC30
	public global::Crouchable crouchable
	{
		get
		{
			if (!this.didCrouchableTest)
			{
				global::Character.SeekIDLocalComponentInChildren<global::Character, global::Crouchable>(this, ref this._crouchable);
				this.didCrouchableTest = true;
			}
			return this._crouchable;
		}
	}

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x06000698 RID: 1688 RVA: 0x0001DA58 File Offset: 0x0001BC58
	public bool crouched
	{
		get
		{
			return this.crouchable && this.crouchable.crouched;
		}
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x0001DA84 File Offset: 0x0001BC84
	protected static bool SeekIDRemoteComponentInChildren<M, T>(M main, ref T component) where M : global::IDMain where T : global::IDRemote
	{
		if (component)
		{
			if (component.idMain == main)
			{
				return true;
			}
			if (!component.idMain)
			{
				return true;
			}
		}
		component = main.GetComponentInChildren<T>();
		if (component)
		{
			if (component.idMain == main)
			{
				return true;
			}
			if (!component.idMain)
			{
				return true;
			}
			T[] componentsInChildren = main.GetComponentsInChildren<T>();
			if (componentsInChildren.Length <= 1)
			{
				component = (T)((object)null);
				return false;
			}
			foreach (T t in componentsInChildren)
			{
				if (t.idMain == main)
				{
					component = t;
					return true;
				}
			}
			component = (T)((object)null);
		}
		return false;
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x0001DBB0 File Offset: 0x0001BDB0
	protected static bool SeekIDLocalComponentInChildren<M, T>(M main, ref T component) where M : global::IDMain where T : global::IDLocal
	{
		if (component)
		{
			if (component.idMain == main)
			{
				return true;
			}
			if (!component.idMain)
			{
				return true;
			}
		}
		component = main.GetComponent<T>();
		if (component)
		{
			if (component.idMain == main)
			{
				return true;
			}
			if (!component.idMain)
			{
				return true;
			}
			T[] components = main.GetComponents<T>();
			if (components.Length <= 1)
			{
				component = (T)((object)null);
				return false;
			}
			foreach (T t in components)
			{
				if (t.idMain == main)
				{
					component = t;
					return true;
				}
			}
			component = (T)((object)null);
		}
		return false;
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x0001DCEC File Offset: 0x0001BEEC
	protected static bool SeekComponentInChildren<M, T>(M main, ref T component) where M : global::IDMain where T : global::UnityEngine.Component
	{
		if (!component)
		{
			component = main.GetComponent<T>();
			return component;
		}
		return true;
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x0600069C RID: 1692 RVA: 0x0001DD34 File Offset: 0x0001BF34
	public global::UnityEngine.Vector3 initialEyesOffset
	{
		get
		{
			return this._initialEyesOffset;
		}
	}

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x0600069D RID: 1693 RVA: 0x0001DD3C File Offset: 0x0001BF3C
	public float initialEyesOffsetX
	{
		get
		{
			return this._initialEyesOffset.x;
		}
	}

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x0600069E RID: 1694 RVA: 0x0001DD4C File Offset: 0x0001BF4C
	public float initialEyesOffsetY
	{
		get
		{
			return this._initialEyesOffset.y;
		}
	}

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x0600069F RID: 1695 RVA: 0x0001DD5C File Offset: 0x0001BF5C
	public float initialEyesOffsetZ
	{
		get
		{
			return this._initialEyesOffset.z;
		}
	}

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0001DD6C File Offset: 0x0001BF6C
	// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0001DD8C File Offset: 0x0001BF8C
	public float eyesPitch
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return this._eyesAngles.pitch;
		}
		set
		{
			if (this.lockLook)
			{
				return;
			}
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			if (this._eyesAngles.pitch != value)
			{
				this._eyesAngles.pitch = value;
				this.InvalidateEyesAngles();
			}
		}
	}

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0001DDDC File Offset: 0x0001BFDC
	// (set) Token: 0x060006A3 RID: 1699 RVA: 0x0001DDFC File Offset: 0x0001BFFC
	public float eyesYaw
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return this._eyesAngles.yaw;
		}
		set
		{
			if (this.lockLook)
			{
				return;
			}
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			if (this._eyesAngles.yaw != value)
			{
				this._eyesAngles.yaw = value;
				this.InvalidateEyesAngles();
			}
		}
	}

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x060006A4 RID: 1700 RVA: 0x0001DE4C File Offset: 0x0001C04C
	// (set) Token: 0x060006A5 RID: 1701 RVA: 0x0001DE68 File Offset: 0x0001C068
	public global::Angle2 eyesAngles
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return this._eyesAngles;
		}
		set
		{
			if (this.lockLook)
			{
				return;
			}
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			if (this._eyesAngles.x != value.x || this._eyesAngles.y != value.y)
			{
				this._eyesAngles = value;
				this.InvalidateEyesAngles();
			}
		}
	}

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x060006A6 RID: 1702 RVA: 0x0001DED0 File Offset: 0x0001C0D0
	public global::UnityEngine.Vector3 eyesOrigin
	{
		get
		{
			return this._eyesTransform.position;
		}
	}

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0001DEE0 File Offset: 0x0001C0E0
	public global::UnityEngine.Vector3 eyesOriginAtInitialOffset
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return base.transform.TransformPoint(this._initialEyesOffset);
		}
	}

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x060006A8 RID: 1704 RVA: 0x0001DF10 File Offset: 0x0001C110
	// (set) Token: 0x060006A9 RID: 1705 RVA: 0x0001DF2C File Offset: 0x0001C12C
	public global::UnityEngine.Vector3 eyesOffset
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return this._eyesOffset;
		}
		set
		{
			if (this.lockLook)
			{
				return;
			}
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			if (this._eyesOffset != value)
			{
				this._eyesOffset = value;
				this.InvalidateEyesOffset();
			}
		}
	}

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x060006AA RID: 1706 RVA: 0x0001DF6C File Offset: 0x0001C16C
	public global::UnityEngine.Ray eyesRay
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return new global::UnityEngine.Ray(this._eyesTransform.position, this._eyesTransform.forward);
		}
	}

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x060006AB RID: 1707 RVA: 0x0001DFA8 File Offset: 0x0001C1A8
	// (set) Token: 0x060006AC RID: 1708 RVA: 0x0001DFC8 File Offset: 0x0001C1C8
	public global::UnityEngine.Quaternion eyesRotation
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return this._eyesAngles.quat;
		}
		set
		{
			this.rotation = value;
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(0f, this._eyesAngles.yaw, 0f);
			global::UnityEngine.Vector3 vector = value * global::UnityEngine.Quaternion.Inverse(quaternion) * global::UnityEngine.Vector3.forward;
			vector.Normalize();
			if (vector.y < 0f)
			{
				this.eyesPitch = -global::UnityEngine.Vector3.Angle(vector, global::UnityEngine.Vector3.forward);
			}
			else
			{
				this.eyesPitch = global::UnityEngine.Vector3.Angle(vector, global::UnityEngine.Vector3.forward);
			}
		}
	}

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x060006AD RID: 1709 RVA: 0x0001E050 File Offset: 0x0001C250
	public global::UnityEngine.Transform eyesTransformReadOnly
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return this._eyesTransform;
		}
	}

	// Token: 0x17000146 RID: 326
	// (get) Token: 0x060006AE RID: 1710 RVA: 0x0001E06C File Offset: 0x0001C26C
	// (set) Token: 0x060006AF RID: 1711 RVA: 0x0001E07C File Offset: 0x0001C27C
	public global::UnityEngine.Vector3 origin
	{
		get
		{
			return base.transform.localPosition;
		}
		set
		{
			if (this.lockMovement)
			{
				return;
			}
			base.transform.localPosition = value;
		}
	}

	// Token: 0x17000147 RID: 327
	// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0001E098 File Offset: 0x0001C298
	public global::UnityEngine.Vector3 forward
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return global::UnityEngine.Quaternion.Euler(0f, this._eyesAngles.yaw, 0f) * global::UnityEngine.Vector3.forward;
		}
	}

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x060006B1 RID: 1713 RVA: 0x0001E0D0 File Offset: 0x0001C2D0
	public global::UnityEngine.Vector3 right
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return global::UnityEngine.Quaternion.Euler(0f, this._eyesAngles.yaw, 0f) * global::UnityEngine.Vector3.right;
		}
	}

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0001E108 File Offset: 0x0001C308
	public global::UnityEngine.Vector3 up
	{
		get
		{
			return global::UnityEngine.Vector3.up;
		}
	}

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x060006B3 RID: 1715 RVA: 0x0001E110 File Offset: 0x0001C310
	// (set) Token: 0x060006B4 RID: 1716 RVA: 0x0001E140 File Offset: 0x0001C340
	public global::UnityEngine.Quaternion rotation
	{
		get
		{
			if (!this._eyesSetup)
			{
				this.EyesSetup();
			}
			return global::UnityEngine.Quaternion.Euler(0f, this._eyesAngles.yaw, 0f);
		}
		set
		{
			global::UnityEngine.Vector3 vector = value * global::UnityEngine.Vector3.forward;
			global::UnityEngine.Vector2 vector2;
			vector2.x = vector.x;
			vector2.y = vector.z;
			if (global::UnityEngine.Mathf.Approximately(vector2.x, 0f) && global::UnityEngine.Mathf.Approximately(vector2.y, 0f))
			{
				vector = value * global::UnityEngine.Vector3.right;
				vector2.x = -vector.z;
				vector2.y = vector.x;
				if (global::UnityEngine.Mathf.Approximately(vector2.x, 0f) && global::UnityEngine.Mathf.Approximately(vector2.y, 0f))
				{
					return;
				}
			}
			this.eyesYaw = global::UnityEngine.Mathf.Atan2(-vector2.x, vector2.y) * -57.29578f;
		}
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0001E218 File Offset: 0x0001C418
	private void EyesSetup()
	{
		if (!this._originSetup)
		{
			this.OriginSetup();
		}
		if (this._eyesTransform == null || this._eyesTransform.parent != base.transform)
		{
			global::UnityEngine.Debug.LogError("eyes Transform is null or it is not a direct child of our transform.", this);
			return;
		}
		this._initialEyesOffset = (this._eyesOffset = this._eyesTransform.localPosition);
		this._eyesAngles.x = -this._eyesTransform.localEulerAngles.x;
		this._eyesAngles.y = base.transform.localEulerAngles.y;
		this._eyesTransform.localEulerAngles = this._eyesAngles.pitchEulerAngles;
		this._eyesSetup = true;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0001E2E4 File Offset: 0x0001C4E4
	protected void InvalidateEyesAngles()
	{
		base.transform.localEulerAngles = this._eyesAngles.yawEulerAngles;
		this._eyesTransform.localEulerAngles = this._eyesAngles.pitchEulerAngles;
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x0001E320 File Offset: 0x0001C520
	protected virtual void AlterEyesLocalOrigin(ref global::UnityEngine.Vector3 localPosition)
	{
		if (this.crouchable)
		{
			this._crouchable.ApplyCrouch(ref localPosition);
		}
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x0001E340 File Offset: 0x0001C540
	protected internal void InvalidateEyesOffset()
	{
		global::UnityEngine.Vector3 eyesOffset = this._eyesOffset;
		this.AlterEyesLocalOrigin(ref eyesOffset);
		this._eyesTransform.localPosition = eyesOffset;
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x0001E368 File Offset: 0x0001C568
	private void OriginSetup()
	{
		this._originSetup = true;
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x0001E374 File Offset: 0x0001C574
	public void ApplyAdditiveEyeAngles(global::Angle2 angles)
	{
		float num = this._eyesAngles.pitch + angles.pitch;
		this.ClampPitch(ref num);
		if (angles.yaw != 0f)
		{
			this._eyesAngles.yaw = global::UnityEngine.Mathf.DeltaAngle(0f, this._eyesAngles.yaw + angles.yaw);
			this._eyesAngles.pitch = num;
			this.InvalidateEyesAngles();
		}
		else if (num != angles.pitch)
		{
			this._eyesAngles.pitch = num;
			this.InvalidateEyesAngles();
		}
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x0001E40C File Offset: 0x0001C60C
	protected virtual void DoDestroy()
	{
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0001E410 File Offset: 0x0001C610
	private void OnDestroy()
	{
		try
		{
			this.DoDestroy();
		}
		finally
		{
			if (!this._signaledDeath)
			{
				try
				{
					this.signal_death_now(global::CharacterDeathSignalReason.Destroyed);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex);
				}
			}
			if (this.signals_state != null)
			{
				this.signals_state = null;
			}
			base.OnDestroy();
		}
	}

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x060006BD RID: 1725 RVA: 0x0001E498 File Offset: 0x0001C698
	public bool signaledDeath
	{
		get
		{
			return this._signaledDeath;
		}
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0001E4A0 File Offset: 0x0001C6A0
	private void signal_death_now(global::CharacterDeathSignalReason reason)
	{
		if (!this._signaledDeath)
		{
			this._signaledDeath = true;
			this.signals_state = null;
			global::CharacterDeathSignal characterDeathSignal = this.signals_death;
			this.signals_death = null;
			if (characterDeathSignal != null)
			{
				characterDeathSignal(this, reason);
			}
		}
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x0001E4E4 File Offset: 0x0001C6E4
	public void Signal_ServerCharacterDeath()
	{
		this.signal_death_now(global::CharacterDeathSignalReason.Died);
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x0001E4F0 File Offset: 0x0001C6F0
	public void Signal_ServerCharacterDeathReset()
	{
		this._signaledDeath = false;
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x0001E4FC File Offset: 0x0001C6FC
	public void Signal_State_FlagsChanged(bool asFirst)
	{
		if (this.signals_state != null)
		{
			try
			{
				this.signals_state(this, asFirst);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(ex, this);
			}
		}
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x0001E550 File Offset: 0x0001C750
	private void LoadTraitMap()
	{
		this._traitMapLoaded = global::TraitMap<global::CharacterTrait, global::CharacterTraitMap>.ByName(this._traitMapName, out this._traitMap);
		this._attemptedTraitMapLoad = true;
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x0001E570 File Offset: 0x0001C770
	protected void LoadTraitMapNonNetworked()
	{
		if (!this._traitMapLoaded)
		{
			this.LoadTraitMap();
		}
	}

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x060006C4 RID: 1732 RVA: 0x0001E584 File Offset: 0x0001C784
	private global::CharacterTraitMap traitMap
	{
		get
		{
			if (!this._attemptedTraitMapLoad)
			{
				this.LoadTraitMap();
			}
			return this._traitMap;
		}
	}

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0001E5A0 File Offset: 0x0001C7A0
	private bool traitMapLoaded
	{
		get
		{
			if (!this._attemptedTraitMapLoad)
			{
				this.LoadTraitMap();
			}
			return this._traitMapLoaded;
		}
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x0001E5BC File Offset: 0x0001C7BC
	public global::CharacterTrait GetTrait(global::System.Type characterTraitType)
	{
		return (!this.traitMapLoaded) ? null : this._traitMap.GetTrait(characterTraitType);
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x0001E5DC File Offset: 0x0001C7DC
	public TCharacterTrait GetTrait<TCharacterTrait>() where TCharacterTrait : global::CharacterTrait
	{
		return (!this.traitMapLoaded) ? ((TCharacterTrait)((object)null)) : this._traitMap.GetTrait<TCharacterTrait>();
	}

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x060006C8 RID: 1736 RVA: 0x0001E600 File Offset: 0x0001C800
	public global::IDLocalCharacterIdleControl idleControl
	{
		get
		{
			if (!this.didIdleControlTest)
			{
				global::Character.SeekIDLocalComponentInChildren<global::Character, global::IDLocalCharacterIdleControl>(this, ref this._idleControl);
				this.didIdleControlTest = true;
			}
			return this._idleControl;
		}
	}

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0001E628 File Offset: 0x0001C828
	public bool? idle
	{
		get
		{
			if (this.idleControl)
			{
				return new bool?(this._idleControl);
			}
			return null;
		}
	}

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x060006CA RID: 1738 RVA: 0x0001E660 File Offset: 0x0001C860
	public global::VisNode visNode
	{
		get
		{
			if (!this.didVisNodeTest)
			{
				global::Character.SeekIDLocalComponentInChildren<global::Character, global::VisNode>(this, ref this._visNode);
				this.didVisNodeTest = true;
			}
			return this._visNode;
		}
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0001E688 File Offset: 0x0001C888
	public bool CanSee(global::VisNode other)
	{
		return this.visNode && this._visNode.CanSee(other);
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x0001E6AC File Offset: 0x0001C8AC
	public bool CanSee(global::Character other)
	{
		return this.visNode && other && other.visNode && this._visNode.CanSee(other._visNode);
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x0001E6F8 File Offset: 0x0001C8F8
	public bool CanSee(global::IDMain other)
	{
		if (other is global::Character)
		{
			return this.CanSee((global::Character)other);
		}
		return other && this.CanSee(other.GetLocal<global::VisNode>());
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0001E738 File Offset: 0x0001C938
	public bool CanSeeUnobstructed(global::VisNode other)
	{
		return this.visNode && this._visNode.CanSeeUnobstructed(other);
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0001E75C File Offset: 0x0001C95C
	public bool CanSeeUnobstructed(global::Character other)
	{
		return this.visNode && other && other.visNode && this._visNode.CanSeeUnobstructed(other._visNode);
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x0001E7A8 File Offset: 0x0001C9A8
	public bool CanSeeUnobstructed(global::IDMain other)
	{
		if (other is global::Character)
		{
			return this.CanSeeUnobstructed((global::Character)other);
		}
		return other && this.CanSeeUnobstructed(other.GetLocal<global::VisNode>());
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0001E7E8 File Offset: 0x0001C9E8
	public bool CanSee(global::VisNode other, bool unobstructed)
	{
		return (!unobstructed) ? this.CanSee(other) : this.CanSeeUnobstructed(other);
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0001E804 File Offset: 0x0001CA04
	public bool CanSee(global::Character other, bool unobstructed)
	{
		return (!unobstructed) ? this.CanSee(other) : this.CanSeeUnobstructed(other);
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0001E820 File Offset: 0x0001CA20
	public bool CanSee(global::IDMain other, bool unobstructed)
	{
		return (!unobstructed) ? this.CanSee(other) : this.CanSeeUnobstructed(other);
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0001E83C File Offset: 0x0001CA3C
	public bool AudibleMessage(global::UnityEngine.Vector3 point, float hearRadius, string message, object arg)
	{
		return global::VisNode.AudibleMessage(this._visNode, point, hearRadius, message, arg);
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0001E850 File Offset: 0x0001CA50
	public bool AudibleMessage(global::UnityEngine.Vector3 point, float hearRadius, string message)
	{
		return global::VisNode.AudibleMessage(this.visNode, point, hearRadius, message);
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0001E860 File Offset: 0x0001CA60
	public bool AudibleMessage(float hearRadius, string message, object arg)
	{
		return global::VisNode.AudibleMessage(this.visNode, hearRadius, message, arg);
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x0001E870 File Offset: 0x0001CA70
	public bool AudibleMessage(float hearRadius, string message)
	{
		return global::VisNode.AudibleMessage(this.visNode, hearRadius, message);
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0001E880 File Offset: 0x0001CA80
	public bool GestureMessage(string message)
	{
		return global::VisNode.GestureMessage(this.visNode, message, null);
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0001E890 File Offset: 0x0001CA90
	public bool GestureMessage(string message, object arg)
	{
		return global::VisNode.GestureMessage(this.visNode, message, arg);
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x0001E8A0 File Offset: 0x0001CAA0
	public bool AttentionMessage(string message)
	{
		return global::VisNode.AttentionMessage(this.visNode, message, null);
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x0001E8B0 File Offset: 0x0001CAB0
	public bool AttentionMessage(string message, object arg)
	{
		return global::VisNode.AttentionMessage(this.visNode, message, arg);
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0001E8C0 File Offset: 0x0001CAC0
	public bool ContactMessage(string message)
	{
		return global::VisNode.ContactMessage(this.visNode, message, null);
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x0001E8D0 File Offset: 0x0001CAD0
	public bool ContactMessage(string message, object arg)
	{
		return global::VisNode.ContactMessage(this.visNode, message, arg);
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x0001E8E0 File Offset: 0x0001CAE0
	public bool StealthMessage(string message)
	{
		return global::VisNode.StealthMessage(this.visNode, message, null);
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x0001E8F0 File Offset: 0x0001CAF0
	public bool StealthMessage(string message, object arg)
	{
		return global::VisNode.StealthMessage(this.visNode, message, arg);
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x0001E900 File Offset: 0x0001CB00
	public bool PreyMessage(string message)
	{
		return global::VisNode.PreyMessage(this.visNode, message, null);
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x0001E910 File Offset: 0x0001CB10
	public bool PreyMessage(string message, object arg)
	{
		return global::VisNode.PreyMessage(this.visNode, message, arg);
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x0001E920 File Offset: 0x0001CB20
	public bool ObliviousMessage(string message)
	{
		return global::VisNode.ObliviousMessage(this.visNode, message, null);
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x0001E930 File Offset: 0x0001CB30
	public bool ObliviousMessage(string message, object arg)
	{
		return global::VisNode.ObliviousMessage(this.visNode, message, arg);
	}

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0001E940 File Offset: 0x0001CB40
	// (set) Token: 0x060006E5 RID: 1765 RVA: 0x0001E974 File Offset: 0x0001CB74
	public global::Vis.Mask viewMask
	{
		get
		{
			if (this.visNode)
			{
				return this._visNode.viewMask;
			}
			return default(global::Vis.Mask);
		}
		set
		{
			if (this.visNode)
			{
				this._visNode.viewMask = value;
			}
			else if (value.data != 0)
			{
				global::UnityEngine.Debug.Log("no visnode", this);
			}
		}
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x060006E6 RID: 1766 RVA: 0x0001E9BC File Offset: 0x0001CBBC
	// (set) Token: 0x060006E7 RID: 1767 RVA: 0x0001E9F0 File Offset: 0x0001CBF0
	public global::Vis.Mask traitMask
	{
		get
		{
			if (this.visNode)
			{
				return this._visNode.traitMask;
			}
			return default(global::Vis.Mask);
		}
		set
		{
			if (this.visNode)
			{
				this._visNode.traitMask = value;
			}
			else if (value.data != 0)
			{
				global::UnityEngine.Debug.Log("no visnode", this);
			}
		}
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x060006E8 RID: 1768 RVA: 0x0001EA38 File Offset: 0x0001CC38
	// (set) Token: 0x060006E9 RID: 1769 RVA: 0x0001EA58 File Offset: 0x0001CC58
	public bool blind
	{
		get
		{
			return !this.visNode || this._visNode.blind;
		}
		set
		{
			if (this.visNode)
			{
				this._visNode.blind = value;
			}
			else if (!value)
			{
				global::UnityEngine.Debug.LogError("no visnode", this);
			}
		}
	}

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x060006EA RID: 1770 RVA: 0x0001EA98 File Offset: 0x0001CC98
	// (set) Token: 0x060006EB RID: 1771 RVA: 0x0001EAB8 File Offset: 0x0001CCB8
	public bool deaf
	{
		get
		{
			return !this.visNode || this._visNode.deaf;
		}
		set
		{
			if (this.visNode)
			{
				this._visNode.deaf = value;
			}
			else if (!value)
			{
				global::UnityEngine.Debug.LogError("no visnode", this);
			}
		}
	}

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x060006EC RID: 1772 RVA: 0x0001EAF8 File Offset: 0x0001CCF8
	// (set) Token: 0x060006ED RID: 1773 RVA: 0x0001EB18 File Offset: 0x0001CD18
	public bool mute
	{
		get
		{
			return !this.visNode || this._visNode.mute;
		}
		set
		{
			if (this.visNode)
			{
				this._visNode.mute = value;
			}
			else if (!value)
			{
				global::UnityEngine.Debug.LogError("no visnode", this);
			}
		}
	}

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x060006EE RID: 1774 RVA: 0x0001EB58 File Offset: 0x0001CD58
	public global::UnityEngine.NavMeshAgent agent
	{
		get
		{
			return this._agent;
		}
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x0001EB60 File Offset: 0x0001CD60
	public bool CreateNavMeshAgent()
	{
		if (this._agent)
		{
			return true;
		}
		global::CharacterNavAgentTrait trait = this.GetTrait<global::CharacterNavAgentTrait>();
		if (!trait)
		{
			return false;
		}
		this._agent = base.GetComponent<global::UnityEngine.NavMeshAgent>();
		if (!this._agent)
		{
			this._agent = base.gameObject.AddComponent<global::UnityEngine.NavMeshAgent>();
		}
		trait.CopyTo(this._agent);
		return true;
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x0001EBD0 File Offset: 0x0001CDD0
	public void DestroyNavMeshAgent()
	{
		global::UnityEngine.Object.Destroy(this._agent);
		this._agent = null;
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0001EBE4 File Offset: 0x0001CDE4
	public global::CharacterInterpolatorBase interpolator
	{
		get
		{
			return this._interpolator;
		}
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x0001EBEC File Offset: 0x0001CDEC
	public bool CreateInterpolator()
	{
		if (this._interpolator)
		{
			return true;
		}
		global::CharacterInterpolatorTrait trait = this.GetTrait<global::CharacterInterpolatorTrait>();
		if (!trait)
		{
			return false;
		}
		this._interpolator = this.AddAddon<global::CharacterInterpolatorBase>(trait.interpolatorComponentTypeName);
		return this._interpolator;
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x0001EC3C File Offset: 0x0001CE3C
	public void DestroyInterpolator()
	{
		this.RemoveAddon<global::CharacterInterpolatorBase>(ref this._interpolator);
	}

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0001EC4C File Offset: 0x0001CE4C
	public global::CCMotor ccmotor
	{
		get
		{
			return this._ccmotor;
		}
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0001EC54 File Offset: 0x0001CE54
	public bool CreateCCMotor()
	{
		if (this._ccmotor)
		{
			return true;
		}
		global::CharacterCCMotorTrait trait = this.GetTrait<global::CharacterCCMotorTrait>();
		global::CCTotemPole cctotemPole = (global::CCTotemPole)global::UnityEngine.Object.Instantiate(trait.prefab, this.origin, global::UnityEngine.Quaternion.identity);
		this._ccmotor = cctotemPole.GetComponent<global::CCMotor>();
		if (!this._ccmotor)
		{
			this._ccmotor = cctotemPole.gameObject.AddComponent<global::CCMotor>();
			if (!this._ccmotor)
			{
				return false;
			}
		}
		this._ccmotor.InitializeSetup(this, cctotemPole, trait);
		return this._ccmotor;
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0001ECF0 File Offset: 0x0001CEF0
	public void DestroyCCMotor()
	{
	}

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x060006F7 RID: 1783 RVA: 0x0001ECF4 File Offset: 0x0001CEF4
	public global::IDLocalCharacterAddon overlay
	{
		get
		{
			return this._overlay;
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0001ECFC File Offset: 0x0001CEFC
	public bool CreateOverlay()
	{
		if (this._overlay)
		{
			return true;
		}
		global::CharacterOverlayTrait trait = this.GetTrait<global::CharacterOverlayTrait>();
		if (!trait || string.IsNullOrEmpty(trait.overlayComponentName))
		{
			return false;
		}
		this._overlay = this.AddAddon(trait.overlayComponentName);
		return this._overlay;
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0001ED5C File Offset: 0x0001CF5C
	public void DestroyOverlay()
	{
		this.RemoveAddon<global::IDLocalCharacterAddon>(ref this._overlay);
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x0001ED6C File Offset: 0x0001CF6C
	public T AddAddon<T>() where T : global::IDLocalCharacterAddon, new()
	{
		if (!global::Character.AddonRegistry<T>.valid)
		{
			throw new global::System.ArgumentOutOfRangeException("T");
		}
		T t = base.GetLocal<T>();
		if (!t)
		{
			t = base.gameObject.AddComponent<T>();
		}
		return (!this.InitAddon(t)) ? ((T)((object)null)) : t;
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x0001EDD0 File Offset: 0x0001CFD0
	public TBase AddAddon<TBase, T>() where TBase : global::IDLocalCharacterAddon where T : TBase, new()
	{
		return (TBase)((object)this.AddAddon<T>());
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0001EDE4 File Offset: 0x0001CFE4
	public global::IDLocalCharacterAddon AddAddon(global::System.Type addonType)
	{
		if (!global::Character.AddonRegistry.Validate(addonType))
		{
			throw new global::System.ArgumentOutOfRangeException("addonType", global::System.Convert.ToString(addonType));
		}
		global::IDLocalCharacterAddon idlocalCharacterAddon = (global::IDLocalCharacterAddon)base.GetComponent(addonType);
		if (!idlocalCharacterAddon)
		{
			idlocalCharacterAddon = (global::IDLocalCharacterAddon)base.gameObject.AddComponent(addonType);
		}
		return (!this.InitAddon(idlocalCharacterAddon)) ? null : idlocalCharacterAddon;
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0001EE4C File Offset: 0x0001D04C
	public TBase AddAddon<TBase>(global::System.Type addonType) where TBase : global::IDLocalCharacterAddon
	{
		if (!typeof(TBase).IsAssignableFrom(addonType))
		{
			throw new global::System.ArgumentOutOfRangeException("addonType", global::System.Convert.ToString(addonType));
		}
		if (!global::Character.AddonRegistry.Validate(addonType))
		{
			throw new global::System.ArgumentOutOfRangeException("addonType", global::System.Convert.ToString(addonType));
		}
		TBase tbase = base.GetComponent<TBase>();
		if (!tbase)
		{
			tbase = (TBase)((object)base.gameObject.AddComponent(addonType));
		}
		else if (!addonType.IsAssignableFrom(tbase.GetType()))
		{
			throw new global::System.InvalidOperationException("The existing TBase component was not assignable to addonType");
		}
		return (!this.InitAddon(tbase)) ? ((TBase)((object)null)) : tbase;
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0001EF0C File Offset: 0x0001D10C
	public global::IDLocalCharacterAddon AddAddon(global::System.Type addonType, global::System.Type minimumType)
	{
		if (!minimumType.IsAssignableFrom(addonType))
		{
			throw new global::System.ArgumentOutOfRangeException("minimumType", global::System.Convert.ToString(addonType));
		}
		return this.AddAddon(addonType);
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0001EF40 File Offset: 0x0001D140
	public global::IDLocalCharacterAddon AddAddon(string addonTypeName)
	{
		if (!global::Character.AddonStringRegistry.Validate(addonTypeName))
		{
			throw new global::System.ArgumentOutOfRangeException("addonTypeName", addonTypeName);
		}
		global::IDLocalCharacterAddon idlocalCharacterAddon = (global::IDLocalCharacterAddon)base.GetComponent(addonTypeName);
		if (!idlocalCharacterAddon)
		{
			idlocalCharacterAddon = (global::IDLocalCharacterAddon)base.gameObject.AddComponent(addonTypeName);
		}
		return (!this.InitAddon(idlocalCharacterAddon)) ? null : idlocalCharacterAddon;
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0001EFA4 File Offset: 0x0001D1A4
	public global::IDLocalCharacterAddon AddAddon(string addonTypeName, global::System.Type minimumType)
	{
		if (!global::Character.AddonStringRegistry.Validate(addonTypeName, minimumType))
		{
			throw new global::System.ArgumentOutOfRangeException("addonTypeName", addonTypeName);
		}
		global::IDLocalCharacterAddon idlocalCharacterAddon = (global::IDLocalCharacterAddon)base.GetComponent(addonTypeName);
		if (!idlocalCharacterAddon)
		{
			idlocalCharacterAddon = (global::IDLocalCharacterAddon)base.gameObject.AddComponent(addonTypeName);
		}
		return (!this.InitAddon(idlocalCharacterAddon)) ? null : idlocalCharacterAddon;
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0001F008 File Offset: 0x0001D208
	public TBase AddAddon<TBase>(string addonTypeName) where TBase : global::IDLocalCharacterAddon
	{
		global::System.Type type;
		if (!global::Character.AddonStringRegistry.Validate<TBase>(addonTypeName, out type))
		{
			throw new global::System.ArgumentOutOfRangeException("TBase", addonTypeName);
		}
		TBase tbase = base.GetLocal<TBase>();
		if (!tbase)
		{
			tbase = (TBase)((object)base.gameObject.AddComponent(addonTypeName));
		}
		else if (!type.IsAssignableFrom(tbase.GetType()))
		{
			throw new global::System.InvalidOperationException("The existing TBase component was not assignable to addonType");
		}
		return (!this.InitAddon(tbase)) ? ((TBase)((object)null)) : tbase;
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0001F09C File Offset: 0x0001D29C
	public void RemoveAddon(global::IDLocalCharacterAddon addon)
	{
		if (addon)
		{
			addon.RemoveAddon();
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0001F0B0 File Offset: 0x0001D2B0
	public void RemoveAddon<T>(ref T addon) where T : global::IDLocalCharacterAddon
	{
		this.RemoveAddon(addon);
		addon = (T)((object)null);
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x0001F0D0 File Offset: 0x0001D2D0
	private bool InitAddon(global::IDLocalCharacterAddon addon)
	{
		byte b = addon.InitializeAddon(this);
		if ((b & 8) == 8)
		{
			return false;
		}
		if ((b & 2) == 2)
		{
			addon.PostInitializeAddon();
		}
		return true;
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0001F100 File Offset: 0x0001D300
	public static global::Character SummonCharacter(global::uLink.NetworkPlayer player, string prefabName, global::UnityEngine.Vector3 origin, global::Angle2OrQuaternion eyesAngles)
	{
		return global::Character.SummonCharacter(ref player, prefabName, ref origin, ref eyesAngles.quat, false, null);
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x0001F118 File Offset: 0x0001D318
	public static global::Character SummonCharacterWithArgs(global::uLink.NetworkPlayer player, string prefabName, global::UnityEngine.Vector3 origin, global::Angle2OrQuaternion eyesAngles, params object[] args)
	{
		return global::Character.SummonCharacter(ref player, prefabName, ref origin, ref eyesAngles.quat, true, args);
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x0001F130 File Offset: 0x0001D330
	[global::System.Obsolete("Using a instantiate function without providing at least one argument is illegal", true)]
	public static global::Character SummonCharacterWithArgs(global::uLink.NetworkPlayer player, string prefabName, global::UnityEngine.Vector3 origin, global::Angle2OrQuaternion eyesAngles)
	{
		throw new global::System.NotSupportedException("Using a instantiate function without providing at least one argument is illegal");
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x0001F13C File Offset: 0x0001D33C
	public static global::Character SummonCharacterWithArgs<TArg>(global::uLink.NetworkPlayer player, string prefabName, global::UnityEngine.Vector3 origin, global::Angle2OrQuaternion eyesAngles, TArg singleArg)
	{
		return global::Character.SummonCharacter(ref player, prefabName, ref origin, ref eyesAngles.quat, true, new object[]
		{
			singleArg
		});
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x0001F16C File Offset: 0x0001D36C
	private static global::Character SummonCharacterNonControllable(ref global::uLink.NetworkPlayer player, string prefabName, ref global::UnityEngine.Vector3 origin, ref global::UnityEngine.Quaternion eyesAngles, bool useArgs, object[] args)
	{
		global::UnityEngine.GameObject gameObject;
		if (player.isClient)
		{
			if (useArgs)
			{
				gameObject = global::NetCull.InstantiateDynamicWithArgs(player, prefabName, origin, eyesAngles, args);
			}
			else
			{
				gameObject = global::NetCull.InstantiateDynamic(player, prefabName, origin, eyesAngles);
			}
		}
		else if (useArgs)
		{
			gameObject = global::NetCull.InstantiateDynamicWithArgs(prefabName, origin, eyesAngles, args);
		}
		else
		{
			gameObject = global::NetCull.InstantiateDynamic(prefabName, origin, eyesAngles);
		}
		return gameObject.GetComponent<global::Character>();
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0001F204 File Offset: 0x0001D404
	internal static global::Character SummonCharacter(ref global::uLink.NetworkPlayer player, string prefabName, ref global::UnityEngine.Vector3 origin, ref global::UnityEngine.Quaternion eyesAngles, bool useArgs, object[] args)
	{
		global::Controllable controllable;
		if (player != global::uLink.NetworkPlayer.unassigned)
		{
			if (player.isServer)
			{
				try
				{
					controllable = global::Controllable.SpawnAIRoot(prefabName, ref origin, ref eyesAngles, args, useArgs);
				}
				catch (global::NonControllableException ex)
				{
					global::UnityEngine.Debug.LogWarning(ex);
					return global::Character.SummonCharacterNonControllable(ref player, prefabName, ref origin, ref eyesAngles, useArgs, args);
				}
			}
			else
			{
				global::NetUser netUser = global::NetUser.Find(player);
				if (object.ReferenceEquals(netUser, null))
				{
					throw new global::System.ArgumentOutOfRangeException("player", netUser, "no user for given player");
				}
				if (!netUser.connected)
				{
					throw new global::System.ArgumentOutOfRangeException("player", netUser, "the user for given player was not connected");
				}
				if (netUser.disposed)
				{
					throw new global::System.ArgumentOutOfRangeException("player", netUser, "the user for given player was disposed");
				}
				try
				{
					controllable = global::Controllable.SpawnPlayerRoot(prefabName, ref origin, ref eyesAngles, netUser, args, useArgs);
				}
				catch (global::NonControllableException ex2)
				{
					global::UnityEngine.Debug.LogWarning(ex2);
					return global::Character.SummonCharacterNonControllable(ref player, prefabName, ref origin, ref eyesAngles, useArgs, args);
				}
				catch (global::NonPlayerRootControllableException)
				{
					global::PlayerClient playerClient = netUser.playerClient;
					if (!playerClient)
					{
						throw;
					}
					global::Controllable controllable2 = playerClient.controllable;
					if (!controllable2)
					{
						throw;
					}
					try
					{
						controllable = global::Controllable.SpawnVessel(prefabName, ref origin, ref eyesAngles, controllable2, args, useArgs);
					}
					catch (global::NonVesselControllableException ex3)
					{
						global::UnityEngine.Debug.LogWarning(ex3);
						return global::Character.SummonCharacterNonControllable(ref player, prefabName, ref origin, ref eyesAngles, useArgs, args);
					}
				}
			}
		}
		else
		{
			try
			{
				controllable = global::Controllable.SpawnVessel(prefabName, ref origin, ref eyesAngles, null, args, useArgs);
			}
			catch (global::NonControllableException ex4)
			{
				global::UnityEngine.Debug.LogWarning(ex4);
				return global::Character.SummonCharacterNonControllable(ref player, prefabName, ref origin, ref eyesAngles, useArgs, args);
			}
			catch (global::NonVesselControllableException ex5)
			{
				global::UnityEngine.Debug.LogWarning(ex5);
				return global::Character.SummonCharacterNonControllable(ref player, prefabName, ref origin, ref eyesAngles, useArgs, args);
			}
		}
		if (!controllable)
		{
			throw new global::UnityEngine.MissingReferenceException("couldn't create controllable");
		}
		return controllable.idMain;
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0001F474 File Offset: 0x0001D674
	public static void DestroyCharacter(global::Character character)
	{
		global::NetCull.Destroy(character.gameObject);
	}

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x0600070C RID: 1804 RVA: 0x0001F484 File Offset: 0x0001D684
	public static global::System.Collections.Generic.IEnumerable<global::Character> PlayerRootCharacters
	{
		get
		{
			foreach (global::PlayerClient pc in global::PlayerClient.All)
			{
				global::Controllable controllable = pc.rootControllable;
				if (controllable)
				{
					yield return controllable.idMain;
				}
			}
			yield break;
		}
	}

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001F4A0 File Offset: 0x0001D6A0
	public static global::System.Collections.Generic.IEnumerable<global::Character> PlayerCurrentCharacters
	{
		get
		{
			foreach (global::PlayerClient pc in global::PlayerClient.All)
			{
				global::Controllable controllable = pc.controllable;
				if (controllable)
				{
					yield return controllable.idMain;
				}
			}
			yield break;
		}
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0001F4BC File Offset: 0x0001D6BC
	public static global::System.Collections.Generic.IEnumerable<global::Character> RootCharacters(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients)
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.rootControllable;
			if (controllable)
			{
				yield return controllable.idMain;
			}
		}
		yield break;
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0001F4E8 File Offset: 0x0001D6E8
	public static global::System.Collections.Generic.IEnumerable<global::Character> CurrentCharacters(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients)
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.controllable;
			if (controllable)
			{
				yield return controllable.idMain;
			}
		}
		yield break;
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0001F514 File Offset: 0x0001D714
	public static global::System.Collections.Generic.IEnumerable<TCharacter> RootCharacters<TCharacter>(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients) where TCharacter : global::Character
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.rootControllable;
			if (controllable)
			{
				TCharacter character = controllable.idMain as TCharacter;
				if (character)
				{
					yield return character;
				}
			}
		}
		yield break;
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0001F540 File Offset: 0x0001D740
	public static global::System.Collections.Generic.IEnumerable<TCharacter> CurrentCharacters<TCharacter>(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients) where TCharacter : global::Character
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.controllable;
			if (controllable)
			{
				TCharacter character = controllable.idMain as TCharacter;
				if (character)
				{
					yield return character;
				}
			}
		}
		yield break;
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0001F56C File Offset: 0x0001D76C
	public static bool FindByUser(ulong userID, out global::Character character)
	{
		global::NetUser netUser;
		global::PlayerClient playerClient;
		global::Controllable controllable;
		if (global::NetUser.Find(userID, out netUser) && (playerClient = netUser.playerClient) && (controllable = playerClient.controllable))
		{
			character = controllable.idMain;
			return character;
		}
		character = null;
		return false;
	}

	// Token: 0x04000583 RID: 1411
	[global::PrefetchChildComponent(NameMask = "*Eyes")]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Transform _eyesTransform;

	// Token: 0x04000584 RID: 1412
	private global::Angle2 _eyesAngles;

	// Token: 0x04000585 RID: 1413
	private global::UnityEngine.Vector3 _eyesOffset;

	// Token: 0x04000586 RID: 1414
	private global::UnityEngine.Vector3 _initialEyesOffset;

	// Token: 0x04000587 RID: 1415
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::Controllable _controllable;

	// Token: 0x04000588 RID: 1416
	[global::PrefetchChildComponent]
	[global::UnityEngine.SerializeField]
	private global::HitBoxSystem _hitBoxSystem;

	// Token: 0x04000589 RID: 1417
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::TakeDamage _takeDamage;

	// Token: 0x0400058A RID: 1418
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::RecoilSimulation _recoilSimulation;

	// Token: 0x0400058B RID: 1419
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::VisNode _visNode;

	// Token: 0x0400058C RID: 1420
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::Crouchable _crouchable;

	// Token: 0x0400058D RID: 1421
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::IDLocalCharacterIdleControl _idleControl;

	// Token: 0x0400058E RID: 1422
	[global::System.NonSerialized]
	private global::IDLocalCharacterAddon _overlay;

	// Token: 0x0400058F RID: 1423
	[global::System.NonSerialized]
	private global::CCMotor _ccmotor;

	// Token: 0x04000590 RID: 1424
	[global::System.NonSerialized]
	private global::UnityEngine.NavMeshAgent _agent;

	// Token: 0x04000591 RID: 1425
	[global::System.NonSerialized]
	private global::CharacterInterpolatorBase _interpolator;

	// Token: 0x04000592 RID: 1426
	[global::UnityEngine.SerializeField]
	private string _traitMapName = "Default";

	// Token: 0x04000593 RID: 1427
	[global::System.NonSerialized]
	private bool _attemptedTraitMapLoad;

	// Token: 0x04000594 RID: 1428
	[global::System.NonSerialized]
	private bool _traitMapLoaded;

	// Token: 0x04000595 RID: 1429
	[global::System.NonSerialized]
	private global::CharacterTraitMap _traitMap;

	// Token: 0x04000596 RID: 1430
	[global::System.NonSerialized]
	private bool _signaledDeath;

	// Token: 0x04000597 RID: 1431
	[global::System.NonSerialized]
	public bool lockMovement;

	// Token: 0x04000598 RID: 1432
	[global::System.NonSerialized]
	public bool lockLook;

	// Token: 0x04000599 RID: 1433
	[global::System.NonSerialized]
	private bool _eyesSetup;

	// Token: 0x0400059A RID: 1434
	[global::System.NonSerialized]
	private bool _originSetup;

	// Token: 0x0400059B RID: 1435
	[global::System.NonSerialized]
	private bool didHitBoxSystemTest;

	// Token: 0x0400059C RID: 1436
	[global::System.NonSerialized]
	private bool didTakeDamageTest;

	// Token: 0x0400059D RID: 1437
	[global::System.NonSerialized]
	private bool didControllableTest;

	// Token: 0x0400059E RID: 1438
	[global::System.NonSerialized]
	private bool didRecoilSimulationTest;

	// Token: 0x0400059F RID: 1439
	[global::System.NonSerialized]
	private bool didVisNodeTest;

	// Token: 0x040005A0 RID: 1440
	[global::System.NonSerialized]
	private bool didCrouchableTest;

	// Token: 0x040005A1 RID: 1441
	[global::System.NonSerialized]
	private bool didIdleControlTest;

	// Token: 0x040005A2 RID: 1442
	[global::UnityEngine.SerializeField]
	private float _maxPitch = 89.9f;

	// Token: 0x040005A3 RID: 1443
	[global::UnityEngine.SerializeField]
	private float _minPitch = -89.9f;

	// Token: 0x040005A4 RID: 1444
	[global::System.NonSerialized]
	private global::CharacterDeathSignal signals_death;

	// Token: 0x040005A5 RID: 1445
	[global::System.NonSerialized]
	private global::CharacterStateSignal signals_state;

	// Token: 0x040005A6 RID: 1446
	[global::System.NonSerialized]
	public global::CharacterStateFlags stateFlags;

	// Token: 0x0200011D RID: 285
	private static class AddonRegistry<T> where T : global::IDLocalCharacterAddon, new()
	{
		// Token: 0x06000713 RID: 1811 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
		static AddonRegistry()
		{
		}

		// Token: 0x040005A7 RID: 1447
		public static readonly bool valid = global::Character.AddonRegistry.Validate(typeof(T));
	}

	// Token: 0x0200011E RID: 286
	private static class AddonRegistry
	{
		// Token: 0x06000714 RID: 1812 RVA: 0x0001F5D8 File Offset: 0x0001D7D8
		// Note: this type is marked as 'beforefieldinit'.
		static AddonRegistry()
		{
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0001F5E4 File Offset: 0x0001D7E4
		public static bool Validate(global::System.Type type)
		{
			if (type == null)
			{
				return false;
			}
			bool flag;
			if (!global::Character.AddonRegistry.validatedCache.TryGetValue(type, out flag))
			{
				if (!typeof(global::IDLocalCharacterAddon).IsAssignableFrom(type))
				{
					global::UnityEngine.Debug.LogError(string.Format("Type {0} is not a valid IDLocalCharacterAddon type", type));
				}
				else if (type.IsAbstract)
				{
					global::UnityEngine.Debug.LogError(string.Format("Type {0} is abstract, thus not a valid IDLocalCharacterAddon type", type));
				}
				else if (global::System.Attribute.IsDefined(type, typeof(global::UnityEngine.RequireComponent), false))
				{
					global::UnityEngine.Debug.LogWarning(string.Format("Type {0} uses the RequireComponent attribute which could be dangerous with addons", type));
					flag = true;
				}
				else
				{
					flag = true;
				}
				global::Character.AddonRegistry.validatedCache[type] = flag;
			}
			return flag;
		}

		// Token: 0x040005A8 RID: 1448
		private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, bool> validatedCache = new global::System.Collections.Generic.Dictionary<global::System.Type, bool>();
	}

	// Token: 0x0200011F RID: 287
	private static class AddonStringRegistry
	{
		// Token: 0x06000716 RID: 1814 RVA: 0x0001F694 File Offset: 0x0001D894
		// Note: this type is marked as 'beforefieldinit'.
		static AddonStringRegistry()
		{
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001F6BC File Offset: 0x0001D8BC
		private static bool Validate(string typeName, out global::System.Type type)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				type = null;
				return false;
			}
			global::Character.AddonStringRegistry.TypePair typePair;
			if (!global::Character.AddonStringRegistry.validatedCache.TryGetValue(typeName, out typePair))
			{
				bool flag = global::TypeUtility.TryParse(typeName, out type) && global::Character.AddonRegistry.Validate(type);
				if (!flag)
				{
					foreach (string str in global::Character.AddonStringRegistry.assemblyStrings)
					{
						if (global::TypeUtility.TryParse(typeName + str, out type) && global::Character.AddonRegistry.Validate(type))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						type = null;
						global::UnityEngine.Debug.LogError(string.Format("Couldnt associate string \"{0}\" with any valid addon type", typeName));
					}
				}
				global::Character.AddonStringRegistry.validatedCache[typeName] = new global::Character.AddonStringRegistry.TypePair(type, flag);
				return flag;
			}
			type = typePair.type;
			return typePair.valid;
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0001F790 File Offset: 0x0001D990
		public static bool Validate(string typeName)
		{
			global::System.Type type;
			return global::Character.AddonStringRegistry.Validate(typeName, out type);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0001F7A8 File Offset: 0x0001D9A8
		public static bool Validate<TBase>(string typeName)
		{
			global::System.Type c;
			return global::Character.AddonStringRegistry.Validate(typeName, out c) && typeof(TBase).IsAssignableFrom(c);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		public static bool Validate<TBase>(string typeName, out global::System.Type type)
		{
			return global::Character.AddonStringRegistry.Validate(typeName, out type) && typeof(TBase).IsAssignableFrom(type);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0001F808 File Offset: 0x0001DA08
		public static bool Validate(string typeName, global::System.Type minimumType)
		{
			global::System.Type c;
			return global::Character.AddonStringRegistry.Validate(typeName, out c) && minimumType.IsAssignableFrom(c);
		}

		// Token: 0x040005A9 RID: 1449
		private static readonly global::System.Collections.Generic.Dictionary<string, global::Character.AddonStringRegistry.TypePair> validatedCache = new global::System.Collections.Generic.Dictionary<string, global::Character.AddonStringRegistry.TypePair>();

		// Token: 0x040005AA RID: 1450
		private static readonly string[] assemblyStrings = new string[]
		{
			", Assembly-CSharp-firstpass",
			", Assembly-CSharp"
		};

		// Token: 0x02000120 RID: 288
		private struct TypePair
		{
			// Token: 0x0600071C RID: 1820 RVA: 0x0001F82C File Offset: 0x0001DA2C
			public TypePair(global::System.Type type, bool valid)
			{
				this.type = type;
				this.valid = valid;
			}

			// Token: 0x040005AB RID: 1451
			public readonly global::System.Type type;

			// Token: 0x040005AC RID: 1452
			public readonly bool valid;
		}
	}

	// Token: 0x02000121 RID: 289
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator1F : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Character>, global::System.Collections.Generic.IEnumerator<global::Character>
	{
		// Token: 0x0600071D RID: 1821 RVA: 0x0001F83C File Offset: 0x0001DA3C
		public <>c__Iterator1F()
		{
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x0001F844 File Offset: 0x0001DA44
		global::Character global::System.Collections.Generic.IEnumerator<global::Character>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x0001F84C File Offset: 0x0001DA4C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0001F854 File Offset: 0x0001DA54
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Character>.GetEnumerator();
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001F85C File Offset: 0x0001DA5C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Character> global::System.Collections.Generic.IEnumerable<global::Character>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::Character.<>c__Iterator1F();
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0001F878 File Offset: 0x0001DA78
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
						this.$current = controllable.idMain;
						this.$PC = 1;
						flag = true;
						return true;
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

		// Token: 0x06000723 RID: 1827 RVA: 0x0001F970 File Offset: 0x0001DB70
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

		// Token: 0x06000724 RID: 1828 RVA: 0x0001F9D0 File Offset: 0x0001DBD0
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005AD RID: 1453
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_192>__0;

		// Token: 0x040005AE RID: 1454
		internal global::PlayerClient <pc>__1;

		// Token: 0x040005AF RID: 1455
		internal global::Controllable <controllable>__2;

		// Token: 0x040005B0 RID: 1456
		internal int $PC;

		// Token: 0x040005B1 RID: 1457
		internal global::Character $current;
	}

	// Token: 0x02000122 RID: 290
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator20 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Character>, global::System.Collections.Generic.IEnumerator<global::Character>
	{
		// Token: 0x06000725 RID: 1829 RVA: 0x0001F9D8 File Offset: 0x0001DBD8
		public <>c__Iterator20()
		{
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x0001F9E0 File Offset: 0x0001DBE0
		global::Character global::System.Collections.Generic.IEnumerator<global::Character>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x0001F9E8 File Offset: 0x0001DBE8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0001F9F0 File Offset: 0x0001DBF0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Character>.GetEnumerator();
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0001F9F8 File Offset: 0x0001DBF8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Character> global::System.Collections.Generic.IEnumerable<global::Character>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::Character.<>c__Iterator20();
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0001FA14 File Offset: 0x0001DC14
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
						this.$current = controllable.idMain;
						this.$PC = 1;
						flag = true;
						return true;
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

		// Token: 0x0600072B RID: 1835 RVA: 0x0001FB0C File Offset: 0x0001DD0C
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

		// Token: 0x0600072C RID: 1836 RVA: 0x0001FB6C File Offset: 0x0001DD6C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005B2 RID: 1458
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_193>__0;

		// Token: 0x040005B3 RID: 1459
		internal global::PlayerClient <pc>__1;

		// Token: 0x040005B4 RID: 1460
		internal global::Controllable <controllable>__2;

		// Token: 0x040005B5 RID: 1461
		internal int $PC;

		// Token: 0x040005B6 RID: 1462
		internal global::Character $current;
	}

	// Token: 0x02000123 RID: 291
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RootCharacters>c__Iterator21 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Character>, global::System.Collections.Generic.IEnumerator<global::Character>
	{
		// Token: 0x0600072D RID: 1837 RVA: 0x0001FB74 File Offset: 0x0001DD74
		public <RootCharacters>c__Iterator21()
		{
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x0001FB7C File Offset: 0x0001DD7C
		global::Character global::System.Collections.Generic.IEnumerator<global::Character>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001FB84 File Offset: 0x0001DD84
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0001FB8C File Offset: 0x0001DD8C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Character>.GetEnumerator();
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001FB94 File Offset: 0x0001DD94
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Character> global::System.Collections.Generic.IEnumerable<global::Character>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Character.<RootCharacters>c__Iterator21 <RootCharacters>c__Iterator = new global::Character.<RootCharacters>c__Iterator21();
			<RootCharacters>c__Iterator.playerClients = playerClients;
			return <RootCharacters>c__Iterator;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0001FBC8 File Offset: 0x0001DDC8
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
						this.$current = controllable.idMain;
						this.$PC = 1;
						flag = true;
						return true;
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

		// Token: 0x06000733 RID: 1843 RVA: 0x0001FCC4 File Offset: 0x0001DEC4
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

		// Token: 0x06000734 RID: 1844 RVA: 0x0001FD28 File Offset: 0x0001DF28
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005B7 RID: 1463
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x040005B8 RID: 1464
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_198>__0;

		// Token: 0x040005B9 RID: 1465
		internal global::PlayerClient <pc>__1;

		// Token: 0x040005BA RID: 1466
		internal global::Controllable <controllable>__2;

		// Token: 0x040005BB RID: 1467
		internal int $PC;

		// Token: 0x040005BC RID: 1468
		internal global::Character $current;

		// Token: 0x040005BD RID: 1469
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x02000124 RID: 292
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CurrentCharacters>c__Iterator22 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Character>, global::System.Collections.Generic.IEnumerator<global::Character>
	{
		// Token: 0x06000735 RID: 1845 RVA: 0x0001FD30 File Offset: 0x0001DF30
		public <CurrentCharacters>c__Iterator22()
		{
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0001FD38 File Offset: 0x0001DF38
		global::Character global::System.Collections.Generic.IEnumerator<global::Character>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x0001FD40 File Offset: 0x0001DF40
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0001FD48 File Offset: 0x0001DF48
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Character>.GetEnumerator();
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0001FD50 File Offset: 0x0001DF50
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Character> global::System.Collections.Generic.IEnumerable<global::Character>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Character.<CurrentCharacters>c__Iterator22 <CurrentCharacters>c__Iterator = new global::Character.<CurrentCharacters>c__Iterator22();
			<CurrentCharacters>c__Iterator.playerClients = playerClients;
			return <CurrentCharacters>c__Iterator;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0001FD84 File Offset: 0x0001DF84
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
						this.$current = controllable.idMain;
						this.$PC = 1;
						flag = true;
						return true;
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

		// Token: 0x0600073B RID: 1851 RVA: 0x0001FE80 File Offset: 0x0001E080
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

		// Token: 0x0600073C RID: 1852 RVA: 0x0001FEE4 File Offset: 0x0001E0E4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005BE RID: 1470
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x040005BF RID: 1471
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_199>__0;

		// Token: 0x040005C0 RID: 1472
		internal global::PlayerClient <pc>__1;

		// Token: 0x040005C1 RID: 1473
		internal global::Controllable <controllable>__2;

		// Token: 0x040005C2 RID: 1474
		internal int $PC;

		// Token: 0x040005C3 RID: 1475
		internal global::Character $current;

		// Token: 0x040005C4 RID: 1476
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x02000125 RID: 293
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RootCharacters>c__Iterator23<TCharacter> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0> where TCharacter : global::Character
	{
		// Token: 0x0600073D RID: 1853 RVA: 0x0001FEEC File Offset: 0x0001E0EC
		public <RootCharacters>c__Iterator23()
		{
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0001FEF4 File Offset: 0x0001E0F4
		TCharacter global::System.Collections.Generic.IEnumerator<!0>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001FF0C File Offset: 0x0001E10C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<TCharacter>.GetEnumerator();
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001FF14 File Offset: 0x0001E114
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<TCharacter> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Character.<RootCharacters>c__Iterator23<TCharacter> <RootCharacters>c__Iterator = new global::Character.<RootCharacters>c__Iterator23<TCharacter>();
			<RootCharacters>c__Iterator.playerClients = playerClients;
			return <RootCharacters>c__Iterator;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0001FF48 File Offset: 0x0001E148
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
						character = (controllable.idMain as TCharacter);
						if (character)
						{
							this.$current = character;
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

		// Token: 0x06000743 RID: 1859 RVA: 0x00020070 File Offset: 0x0001E270
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

		// Token: 0x06000744 RID: 1860 RVA: 0x000200D4 File Offset: 0x0001E2D4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005C5 RID: 1477
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x040005C6 RID: 1478
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_200>__0;

		// Token: 0x040005C7 RID: 1479
		internal global::PlayerClient <pc>__1;

		// Token: 0x040005C8 RID: 1480
		internal global::Controllable <controllable>__2;

		// Token: 0x040005C9 RID: 1481
		internal TCharacter <character>__3;

		// Token: 0x040005CA RID: 1482
		internal int $PC;

		// Token: 0x040005CB RID: 1483
		internal TCharacter $current;

		// Token: 0x040005CC RID: 1484
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x02000126 RID: 294
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CurrentCharacters>c__Iterator24<TCharacter> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0> where TCharacter : global::Character
	{
		// Token: 0x06000745 RID: 1861 RVA: 0x000200DC File Offset: 0x0001E2DC
		public <CurrentCharacters>c__Iterator24()
		{
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x000200E4 File Offset: 0x0001E2E4
		TCharacter global::System.Collections.Generic.IEnumerator<!0>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x000200EC File Offset: 0x0001E2EC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000200FC File Offset: 0x0001E2FC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<TCharacter>.GetEnumerator();
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00020104 File Offset: 0x0001E304
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<TCharacter> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Character.<CurrentCharacters>c__Iterator24<TCharacter> <CurrentCharacters>c__Iterator = new global::Character.<CurrentCharacters>c__Iterator24<TCharacter>();
			<CurrentCharacters>c__Iterator.playerClients = playerClients;
			return <CurrentCharacters>c__Iterator;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00020138 File Offset: 0x0001E338
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
						character = (controllable.idMain as TCharacter);
						if (character)
						{
							this.$current = character;
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

		// Token: 0x0600074B RID: 1867 RVA: 0x00020260 File Offset: 0x0001E460
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

		// Token: 0x0600074C RID: 1868 RVA: 0x000202C4 File Offset: 0x0001E4C4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040005CD RID: 1485
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x040005CE RID: 1486
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_201>__0;

		// Token: 0x040005CF RID: 1487
		internal global::PlayerClient <pc>__1;

		// Token: 0x040005D0 RID: 1488
		internal global::Controllable <controllable>__2;

		// Token: 0x040005D1 RID: 1489
		internal TCharacter <character>__3;

		// Token: 0x040005D2 RID: 1490
		internal int $PC;

		// Token: 0x040005D3 RID: 1491
		internal TCharacter $current;

		// Token: 0x040005D4 RID: 1492
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}
}
