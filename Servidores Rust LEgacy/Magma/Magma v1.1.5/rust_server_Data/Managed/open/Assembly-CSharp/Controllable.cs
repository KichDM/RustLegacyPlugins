using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000148 RID: 328
public sealed class Controllable : global::IDLocalCharacter
{
	// Token: 0x06000889 RID: 2185 RVA: 0x000242B4 File Offset: 0x000224B4
	public Controllable()
	{
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x000242BC File Offset: 0x000224BC
	// Note: this type is marked as 'beforefieldinit'.
	static Controllable()
	{
	}

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x0600088B RID: 2187 RVA: 0x00024314 File Offset: 0x00022514
	// (remove) Token: 0x0600088C RID: 2188 RVA: 0x0002432C File Offset: 0x0002252C
	public static event global::Controllable.DestroyInContextQuery onDestroyInContextQuery
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			global::Controllable.onDestroyInContextQuery = (global::Controllable.DestroyInContextQuery)global::System.Delegate.Combine(global::Controllable.onDestroyInContextQuery, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			global::Controllable.onDestroyInContextQuery = (global::Controllable.DestroyInContextQuery)global::System.Delegate.Remove(global::Controllable.onDestroyInContextQuery, value);
		}
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x00024344 File Offset: 0x00022544
	private void ON_CHAIN_RENEW()
	{
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x00024348 File Offset: 0x00022548
	private void ON_CHAIN_SUBSCRIBE()
	{
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0002434C File Offset: 0x0002254C
	private void ON_CHAIN_ERASE(int cmd)
	{
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x00024350 File Offset: 0x00022550
	private void ON_CHAIN_ABOLISHED()
	{
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x00024354 File Offset: 0x00022554
	private static int CAP_THIS(int cmd, int RT, global::Controllable.ControlFlags F)
	{
		cmd &= -0x7801;
		if ((F & global::Controllable.ControlFlags.Strong) == (global::Controllable.ControlFlags)0)
		{
			cmd |= 0;
		}
		else if ((cmd & 0x20) == 0x20)
		{
			cmd |= 0x1001;
		}
		else
		{
			cmd |= 0x1000;
		}
		if ((F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) == global::Controllable.ControlFlags.Owned)
		{
			cmd |= 0;
		}
		else if ((F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player))
		{
			cmd |= 0x2000;
		}
		if ((F & global::Controllable.ControlFlags.Local) == global::Controllable.ControlFlags.Local)
		{
			cmd |= 0x4000;
		}
		else
		{
			cmd |= 0;
		}
		if ((F & global::Controllable.ControlFlags.Root) == global::Controllable.ControlFlags.Root)
		{
			cmd |= 0x800;
		}
		else
		{
			cmd |= 0;
		}
		if ((RT & 0xC00) != 0 || (cmd & 0x1020) == 0x1020)
		{
			cmd |= 1;
		}
		return cmd;
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x00024420 File Offset: 0x00022620
	private static int CAP_ENTER(int cmd, int RT, global::Controllable.ControlFlags F)
	{
		cmd = global::Controllable.CAP_THIS(cmd, RT, F);
		if ((RT & 0x40) == 0x40)
		{
			cmd |= ((cmd & -0x401) | 0x400);
		}
		else
		{
			cmd |= ((cmd & -0x401) | 0);
		}
		return cmd;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0002445C File Offset: 0x0002265C
	private static int CAP_PROMOTE(int cmd, int RT, global::Controllable.ControlFlags F)
	{
		cmd = global::Controllable.CAP_THIS(cmd, RT, F);
		if ((RT & 0x80) == 0x80)
		{
			cmd |= ((cmd & -0x401) | 0x400);
		}
		else
		{
			cmd |= ((cmd & -0x401) | 0);
		}
		return cmd;
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x000244A8 File Offset: 0x000226A8
	private static int CAP_DEMOTE(int cmd, int RT, global::Controllable.ControlFlags F)
	{
		cmd = global::Controllable.CAP_THIS(cmd, RT, F);
		if ((RT & 0x100) == 0x100)
		{
			cmd = ((cmd & -0x401) | 0x400);
		}
		else
		{
			cmd = ((cmd & -0x401) | 0);
		}
		return cmd;
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000244E8 File Offset: 0x000226E8
	private static int CAP_EXIT(int cmd, int RT, global::Controllable.ControlFlags F)
	{
		if ((RT & 0x200) == 0x200)
		{
			cmd |= ((cmd & -0x401) | 0x400);
		}
		else
		{
			cmd |= ((cmd & -0x401) | 0);
		}
		return cmd;
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x00024520 File Offset: 0x00022720
	private static void DO_ENTER(int cmd, global::Controllable citr)
	{
		if ((citr.RT & 8) == 8)
		{
			return;
		}
		citr.RT |= 8;
		citr.ControlEnter(cmd);
		citr.RT = ((citr.RT & -0xC) | 0x41);
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x00024564 File Offset: 0x00022764
	private static void DO_PROMOTE(int cmd, global::Controllable citr)
	{
		if ((citr.RT & 0x10) == 0x10)
		{
			return;
		}
		citr.RT |= 0x10;
		citr.ControlEngauge(cmd);
		citr.RT = ((citr.RT & -0x14) | 0x83);
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000245B0 File Offset: 0x000227B0
	private static void DO_DEMOTE(int cmd, global::Controllable citr)
	{
		if ((citr.RT & 0x10) == 0x10)
		{
			return;
		}
		citr.RT |= 0x10;
		citr.ControlCease(cmd);
		citr.RT = ((citr.RT & -0x14) | 0x101);
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x000245FC File Offset: 0x000227FC
	private static void DO_EXIT(int cmd, global::Controllable citr)
	{
		if ((citr.RT & 8) == 8)
		{
			return;
		}
		citr.RT |= 8;
		citr.ControlExit(cmd);
		citr.RT = ((citr.RT & -0xC) | 0x200);
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x00024638 File Offset: 0x00022838
	private void RN(int n, ref global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x0600089B RID: 2203 RVA: 0x0002463C File Offset: 0x0002283C
	public new global::Controller controller
	{
		get
		{
			return this._controller;
		}
	}

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x0600089C RID: 2204 RVA: 0x00024644 File Offset: 0x00022844
	public new global::Controller controlledController
	{
		get
		{
			return ((this.F & global::Controllable.ControlFlags.Owned) != global::Controllable.ControlFlags.Owned) ? null : this._controller;
		}
	}

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x0600089D RID: 2205 RVA: 0x00024660 File Offset: 0x00022860
	public new global::Controller playerControlledController
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) ? null : this._controller;
		}
	}

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x0600089E RID: 2206 RVA: 0x0002467C File Offset: 0x0002287C
	public new global::Controller aiControlledController
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) != global::Controllable.ControlFlags.Owned) ? null : this._controller;
		}
	}

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x0600089F RID: 2207 RVA: 0x00024698 File Offset: 0x00022898
	public new global::Controller localPlayerControlledController
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) ? null : this._controller;
		}
	}

	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x060008A0 RID: 2208 RVA: 0x000246B4 File Offset: 0x000228B4
	public new global::Controller localAIControlledController
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local)) ? null : this._controller;
		}
	}

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x060008A1 RID: 2209 RVA: 0x000246D0 File Offset: 0x000228D0
	public new global::Controller remotePlayerControlledController
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) ? null : this._controller;
		}
	}

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x060008A2 RID: 2210 RVA: 0x000246EC File Offset: 0x000228EC
	public new global::Controller remoteAIControlledController
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != global::Controllable.ControlFlags.Owned) ? null : this._controller;
		}
	}

	// Token: 0x170001EC RID: 492
	// (get) Token: 0x060008A3 RID: 2211 RVA: 0x00024708 File Offset: 0x00022908
	public new global::Controllable controllable
	{
		get
		{
			return this;
		}
	}

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x060008A4 RID: 2212 RVA: 0x0002470C File Offset: 0x0002290C
	public new global::Controllable controlledControllable
	{
		get
		{
			return ((this.F & global::Controllable.ControlFlags.Owned) != global::Controllable.ControlFlags.Owned) ? null : this;
		}
	}

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x060008A5 RID: 2213 RVA: 0x00024724 File Offset: 0x00022924
	public new global::Controllable playerControlledControllable
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) ? null : this;
		}
	}

	// Token: 0x170001EF RID: 495
	// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0002473C File Offset: 0x0002293C
	public new global::Controllable aiControlledControllable
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) != global::Controllable.ControlFlags.Owned) ? null : this;
		}
	}

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00024754 File Offset: 0x00022954
	public new global::Controllable localPlayerControlledControllable
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) ? null : this;
		}
	}

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x060008A8 RID: 2216 RVA: 0x0002476C File Offset: 0x0002296C
	public new global::Controllable localAIControlledControllable
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local)) ? null : this;
		}
	}

	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x060008A9 RID: 2217 RVA: 0x00024784 File Offset: 0x00022984
	public new global::Controllable remotePlayerControlledControllable
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) ? null : this;
		}
	}

	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x060008AA RID: 2218 RVA: 0x0002479C File Offset: 0x0002299C
	public new global::Controllable remoteAIControlledControllable
	{
		get
		{
			return ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) != global::Controllable.ControlFlags.Owned) ? null : this;
		}
	}

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x060008AB RID: 2219 RVA: 0x000247B4 File Offset: 0x000229B4
	public new global::PlayerClient playerClient
	{
		get
		{
			return this._playerClient;
		}
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060008AC RID: 2220 RVA: 0x000247BC File Offset: 0x000229BC
	public global::uLink.NetworkPlayer netPlayer
	{
		get
		{
			return (!this._playerClient) ? global::uLink.NetworkPlayer.unassigned : this._playerClient.netPlayer;
		}
	}

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x060008AD RID: 2221 RVA: 0x000247E4 File Offset: 0x000229E4
	public new bool controlled
	{
		get
		{
			return (this.F & global::Controllable.ControlFlags.Owned) == global::Controllable.ControlFlags.Owned;
		}
	}

	// Token: 0x170001F7 RID: 503
	// (get) Token: 0x060008AE RID: 2222 RVA: 0x000247F4 File Offset: 0x000229F4
	public new bool playerControlled
	{
		get
		{
			return (this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player);
		}
	}

	// Token: 0x170001F8 RID: 504
	// (get) Token: 0x060008AF RID: 2223 RVA: 0x00024804 File Offset: 0x00022A04
	public new bool aiControlled
	{
		get
		{
			return (this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) == global::Controllable.ControlFlags.Owned;
		}
	}

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00024814 File Offset: 0x00022A14
	public new bool localPlayerControlled
	{
		get
		{
			return (this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player);
		}
	}

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x060008B1 RID: 2225 RVA: 0x00024824 File Offset: 0x00022A24
	public new bool remotePlayerControlled
	{
		get
		{
			return (this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player);
		}
	}

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00024834 File Offset: 0x00022A34
	public new bool localAIControlled
	{
		get
		{
			return (this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local);
		}
	}

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x060008B3 RID: 2227 RVA: 0x00024844 File Offset: 0x00022A44
	public new bool remoteAIControlled
	{
		get
		{
			return (this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)) == global::Controllable.ControlFlags.Owned;
		}
	}

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00024854 File Offset: 0x00022A54
	public new bool localControlled
	{
		get
		{
			return (this.F & global::Controllable.ControlFlags.Local) == global::Controllable.ControlFlags.Local;
		}
	}

	// Token: 0x170001FE RID: 510
	// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00024864 File Offset: 0x00022A64
	public new bool remoteControlled
	{
		get
		{
			return (this.F & global::Controllable.ControlFlags.Local) == (global::Controllable.ControlFlags)0;
		}
	}

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00024874 File Offset: 0x00022A74
	public bool core
	{
		get
		{
			return (this.F & global::Controllable.ControlFlags.Root) == global::Controllable.ControlFlags.Root;
		}
	}

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x060008B7 RID: 2231 RVA: 0x00024884 File Offset: 0x00022A84
	public bool vessel
	{
		get
		{
			return (this.F & global::Controllable.ControlFlags.Root) == (global::Controllable.ControlFlags)0;
		}
	}

	// Token: 0x17000201 RID: 513
	// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00024894 File Offset: 0x00022A94
	public new string npcName
	{
		get
		{
			return (!this.@class) ? null : this.@class.npcName;
		}
	}

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x060008B9 RID: 2233 RVA: 0x000248B8 File Offset: 0x00022AB8
	public new bool controlOverridden
	{
		get
		{
			return this.ch.vl && this.ch.ln > 0;
		}
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x000248DC File Offset: 0x00022ADC
	public new bool ControlOverriddenBy(global::Controllable controllable)
	{
		return this.ch.vl && this.ch.ln > 0 && controllable && controllable.ch.vl && this.ch.ln > controllable.ch.ln && this.ch.bt == controllable.ch.bt;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x00024960 File Offset: 0x00022B60
	public new bool ControlOverriddenBy(global::Controller controller)
	{
		global::Controllable controllable;
		return this.ch.vl && this.ch.ln > 0 && controller && (controllable = controller.controllable) && controllable.ch.vl && this.ch.ln > controllable.ch.ln && this.ch.bt == controllable.ch.bt;
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x000249F4 File Offset: 0x00022BF4
	public new bool ControlOverriddenBy(global::Character character)
	{
		global::Controllable controllable;
		return this.ch.vl && this.ch.ln > 0 && character && (controllable = character.controllable) && controllable.ch.vl && this.ch.ln > controllable.ch.ln && this.ch.bt == controllable.ch.bt;
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x00024A88 File Offset: 0x00022C88
	public new bool ControlOverriddenBy(global::IDMain main)
	{
		return this.ch.vl && this.ch.ln != 0 && main is global::Character && this.ControlOverriddenBy((global::Character)main);
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x00024AC4 File Offset: 0x00022CC4
	public new bool ControlOverriddenBy(global::IDBase idBase)
	{
		return this.ch.vl && this.ch.ln != 0 && idBase && this.ControlOverriddenBy(idBase.idMain);
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x00024B00 File Offset: 0x00022D00
	public new bool ControlOverriddenBy(global::IDLocalCharacter idLocal)
	{
		return this.ch.vl && this.ch.ln != 0 && idLocal && this.ControlOverriddenBy(idLocal.idMain);
	}

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00024B3C File Offset: 0x00022D3C
	public new bool overridingControl
	{
		get
		{
			return this.ch.vl && this.ch.nm > 0;
		}
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x00024B60 File Offset: 0x00022D60
	public new bool OverridingControlOf(global::Controllable controllable)
	{
		return this.ch.vl && this.ch.nm > 0 && controllable && controllable.ch.vl && this.ch.nm > controllable.ch.nm && this.ch.bt == controllable.ch.bt;
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x00024BE4 File Offset: 0x00022DE4
	public new bool OverridingControlOf(global::Controller controller)
	{
		global::Controllable controllable;
		return this.ch.vl && this.ch.nm > 0 && controller && (controllable = controller.controllable) && controllable.ch.vl && this.ch.nm > controllable.ch.nm && this.ch.bt == controllable.ch.bt;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x00024C78 File Offset: 0x00022E78
	public new bool OverridingControlOf(global::Character character)
	{
		global::Controllable controllable;
		return this.ch.vl && this.ch.nm > 0 && character && (controllable = character.controllable) && controllable.ch.vl && this.ch.nm > controllable.ch.nm && this.ch.bt == controllable.ch.bt;
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x00024D0C File Offset: 0x00022F0C
	public new bool OverridingControlOf(global::IDMain main)
	{
		return this.ch.vl && this.ch.nm != 0 && main is global::Character && this.OverridingControlOf((global::Character)main);
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x00024D48 File Offset: 0x00022F48
	public new bool OverridingControlOf(global::IDBase idBase)
	{
		return this.ch.vl && this.ch.nm != 0 && idBase && this.OverridingControlOf(idBase.idMain);
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x00024D84 File Offset: 0x00022F84
	public new bool OverridingControlOf(global::IDLocalCharacter idLocal)
	{
		return this.ch.vl && this.ch.nm != 0 && idLocal && this.OverridingControlOf(idLocal.idMain);
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x060008C7 RID: 2247 RVA: 0x00024DC0 File Offset: 0x00022FC0
	public new bool assignedControl
	{
		get
		{
			return this.ch.vl;
		}
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x00024DD0 File Offset: 0x00022FD0
	public new bool AssignedControlOf(global::Controllable controllable)
	{
		return this.ch.vl && this == controllable;
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x00024DEC File Offset: 0x00022FEC
	public new bool AssignedControlOf(global::Controller controller)
	{
		return this.ch.vl && this._controller == controller && this._controller;
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x00024E20 File Offset: 0x00023020
	public new bool AssignedControlOf(global::IDMain character)
	{
		return this.ch.vl && this.idMain == character;
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x00024E44 File Offset: 0x00023044
	public new bool AssignedControlOf(global::IDBase idBase)
	{
		return this.ch.vl && idBase && this.idMain == idBase.idMain;
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00024E78 File Offset: 0x00023078
	public new global::RelativeControl RelativeControlTo(global::Controllable controllable)
	{
		if (!this.ch.vl || !controllable || !controllable.ch.vl || controllable.ch.bt != this.ch.bt)
		{
			return global::RelativeControl.Incompatible;
		}
		if (this.ch.ln > controllable.ch.ln)
		{
			return global::RelativeControl.OverriddenBy;
		}
		if (this.ch.ln < controllable.ch.ln)
		{
			return global::RelativeControl.IsOverriding;
		}
		return global::RelativeControl.Assigned;
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x00024F10 File Offset: 0x00023110
	public new global::RelativeControl RelativeControlTo(global::Controller controller)
	{
		global::Controllable controllable;
		if (!this.ch.vl || !controller || !(controllable = controller.controllable) || controllable.ch.vl || controllable.ch.bt != this.ch.bt)
		{
			return global::RelativeControl.Incompatible;
		}
		if (this.ch.ln > controllable.ch.ln)
		{
			return global::RelativeControl.OverriddenBy;
		}
		if (this.ch.ln < controllable.ch.ln)
		{
			return global::RelativeControl.IsOverriding;
		}
		return global::RelativeControl.Assigned;
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00024FB8 File Offset: 0x000231B8
	public new global::RelativeControl RelativeControlTo(global::Character character)
	{
		if (!character)
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlTo(character.controllable);
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x00024FD4 File Offset: 0x000231D4
	public new global::RelativeControl RelativeControlTo(global::IDMain idMain)
	{
		if (!(idMain is global::Character))
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlTo((global::Character)idMain);
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x00024FF0 File Offset: 0x000231F0
	public new global::RelativeControl RelativeControlTo(global::IDLocalCharacter idLocal)
	{
		if (!idLocal)
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlTo(idLocal.idMain.controllable);
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x0002501C File Offset: 0x0002321C
	public new global::RelativeControl RelativeControlTo(global::IDBase idBase)
	{
		if (!idBase)
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlTo(idBase.idMain as global::Character);
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x0002503C File Offset: 0x0002323C
	public new global::RelativeControl RelativeControlFrom(global::Controllable controllable)
	{
		if (!this.ch.vl || !controllable || !controllable.ch.vl || controllable.ch.bt != this.ch.bt)
		{
			return global::RelativeControl.Incompatible;
		}
		if (this.ch.ln > controllable.ch.ln)
		{
			return global::RelativeControl.IsOverriding;
		}
		if (this.ch.ln < controllable.ch.ln)
		{
			return global::RelativeControl.OverriddenBy;
		}
		return global::RelativeControl.Assigned;
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x000250D4 File Offset: 0x000232D4
	public new global::RelativeControl RelativeControlFrom(global::Controller controller)
	{
		global::Controllable controllable;
		if (!this.ch.vl || !controller || !(controllable = controller.controllable) || controllable.ch.vl || controllable.ch.bt != this.ch.bt)
		{
			return global::RelativeControl.Incompatible;
		}
		if (this.ch.ln > controllable.ch.ln)
		{
			return global::RelativeControl.IsOverriding;
		}
		if (this.ch.ln < controllable.ch.ln)
		{
			return global::RelativeControl.OverriddenBy;
		}
		return global::RelativeControl.Assigned;
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x0002517C File Offset: 0x0002337C
	public new global::RelativeControl RelativeControlFrom(global::Character character)
	{
		if (!character)
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlFrom(character.controllable);
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x00025198 File Offset: 0x00023398
	public new global::RelativeControl RelativeControlFrom(global::IDMain idMain)
	{
		if (!(idMain is global::Character))
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlFrom((global::Character)idMain);
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x000251B4 File Offset: 0x000233B4
	public new global::RelativeControl RelativeControlFrom(global::IDLocalCharacter idLocal)
	{
		if (!idLocal)
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlFrom(idLocal.idMain.controllable);
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x000251E0 File Offset: 0x000233E0
	public new global::RelativeControl RelativeControlFrom(global::IDBase idBase)
	{
		if (!idBase)
		{
			return global::RelativeControl.Incompatible;
		}
		return this.RelativeControlFrom(idBase.idMain as global::Character);
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x00025200 File Offset: 0x00023400
	internal void PrepareInstantiate(global::Facepunch.NetworkView view, ref global::uLink.NetworkMessageInfo info)
	{
		this.__controllerCreateMessageInfo = info;
		this.__networkViewForControllable = view;
		if (this.classFlagsRootControllable || this.classFlagsStandaloneVessel)
		{
			this.__controllerDriverViewID = global::uLink.NetworkViewID.unassigned;
			if (this.classFlagsStandaloneVessel)
			{
				return;
			}
		}
		else if (this.classFlagsDependantVessel || this.classFlagsFreeVessel)
		{
			global::PlayerClient playerClient;
			if (global::PlayerClient.Find(view.owner, out playerClient))
			{
				this.__controllerDriverViewID = playerClient.topControllable.networkViewID;
			}
			else
			{
				this.__controllerDriverViewID = global::uLink.NetworkViewID.unassigned;
			}
			if (this.classFlagsFreeVessel)
			{
				return;
			}
			if (this.__controllerDriverViewID == global::uLink.NetworkViewID.unassigned)
			{
				global::UnityEngine.Debug.LogError("NOT RIGHT");
				return;
			}
		}
		this.FreshInitializeController();
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000252CC File Offset: 0x000234CC
	internal void FreshInitializeController()
	{
		if (this.__controllerDriverViewID == global::uLink.NetworkViewID.unassigned)
		{
			if ((this.F & global::Controllable.ControlFlags.Initialized) == global::Controllable.ControlFlags.Initialized)
			{
				throw new global::System.InvalidOperationException("Was already intialized.");
			}
			global::Controllable.Chain.ROOT(this);
			this.F = global::Controllable.ControlFlags.Root;
			this.InitializeController_OnFoundOverriding(null);
		}
		else
		{
			global::Facepunch.NetworkView driverView = global::Facepunch.NetworkView.Find(this.__controllerDriverViewID);
			this.F |= (global::Controllable.ControlFlags)0;
			this.InitializeController_OnFoundOverriding(driverView);
		}
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x00025344 File Offset: 0x00023544
	public void ClientExit()
	{
		if (!this.ch.vl)
		{
			return;
		}
		if (this.ch.vl && this.ch.bt == this.ch.it)
		{
			global::UnityEngine.Debug.LogWarning("You cannot exit the root controllable", this);
			return;
		}
		if (!this.localControlled)
		{
			throw new global::System.InvalidOperationException("Cannot exit other owned controllables");
		}
		global::Controllable.Disconnect(this);
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x000253BC File Offset: 0x000235BC
	public void ForceExit()
	{
		if (!this.ch.vl)
		{
			return;
		}
		if (this.ch.vl && this.ch.bt == this.ch.it)
		{
			global::UnityEngine.Debug.LogWarning("You cannot exit the root controllable", this);
			return;
		}
		global::Controllable.Disconnect(this);
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x0002541C File Offset: 0x0002361C
	private bool EnsureControllee(global::uLink.NetworkPlayer player)
	{
		if (!this.controlled)
		{
			return false;
		}
		if (player.isClient)
		{
			if (!this.playerControlled || (this.playerClient && this.playerClient.netPlayer != player))
			{
				global::UnityEngine.Debug.LogWarning("player was not the controllee of this player controlled controlable", this);
				return false;
			}
		}
		else if (this.playerControlled)
		{
			global::UnityEngine.Debug.LogWarning("this player controlled controlable is not server owned", this);
			return false;
		}
		return true;
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x000254A0 File Offset: 0x000236A0
	private global::Facepunch.NetworkView SV_ClearBufferedState()
	{
		global::Facepunch.NetworkView networkView = base.networkView;
		return (!this.SV_ClearBufferedState(networkView)) ? null : networkView;
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x000254C8 File Offset: 0x000236C8
	private bool SV_ClearBufferedState(global::Facepunch.NetworkView view)
	{
		if (!view || view.viewID == global::uLink.NetworkViewID.unassigned)
		{
			return false;
		}
		int num = this.RT & 0x3C00;
		if (num == 0)
		{
			return true;
		}
		if (num == 0x1000)
		{
			global::NetCull.RemoveRPCsByName(view, "Controllable:ID1");
			this.RT &= -0x1001;
			return true;
		}
		if (num == 0x2000)
		{
			global::NetCull.RemoveRPCsByName(view, "Controllable:OC1");
			this.RT &= -0x2001;
			return true;
		}
		if (num != 0x3000)
		{
			return false;
		}
		global::NetCull.RemoveRPCsByName(view, "Controllable:OC2");
		this.RT &= -0x3001;
		return true;
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00025590 File Offset: 0x00023790
	private void InitializeController_OnFoundOverriding(global::Facepunch.NetworkView driverView)
	{
		if ((this.F & global::Controllable.ControlFlags.Root) == (global::Controllable.ControlFlags)0)
		{
			global::Character character = driverView.idMain as global::Character;
			global::Controllable controllable = character.controllable;
			this.F = ((this.F & (global::Controllable.ControlFlags.Root | global::Controllable.ControlFlags.Strong)) | (controllable.F & (global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player)));
			this._playerClient = controllable.playerClient;
			controllable.ch.Add(this);
		}
		else
		{
			this.F |= ((!this.__networkViewForControllable.isMine) ? ((global::Controllable.ControlFlags)0) : global::Controllable.ControlFlags.Local);
			this.F |= ((!global::PlayerClient.Find(this.__networkViewForControllable.owner, out this._playerClient)) ? global::Controllable.ControlFlags.Owned : (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player));
		}
		this.F |= global::Controllable.ControlFlags.Owned;
		string controllerClassName = this.controllerClassName;
		if (string.IsNullOrEmpty(controllerClassName))
		{
			global::Controllable.ControlFlags f = this.F;
			this.F = (global::Controllable.ControlFlags)0;
			throw new global::System.ArgumentOutOfRangeException("@class", f, "The ControllerClass did not support given flags");
		}
		global::Controller controller = null;
		try
		{
			controller = base.AddAddon<global::Controller>(controllerClassName);
			if (!controller)
			{
				throw new global::System.ArgumentOutOfRangeException("className", controllerClassName, "classname as not a Controller!");
			}
			this._controller = controller;
			global::Controller controller2 = this._controller;
			try
			{
				try
				{
					this._controller.ControllerSetup(this, this.__networkViewForControllable, ref this.__controllerCreateMessageInfo);
				}
				catch
				{
					this._controller = controller2;
					throw;
				}
			}
			catch
			{
				throw;
			}
			this.F |= global::Controllable.ControlFlags.Initialized;
		}
		catch
		{
			if (controller)
			{
				global::UnityEngine.Object.Destroy(controller);
			}
			this.ch.Delete();
			throw;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x060008E0 RID: 2272 RVA: 0x00025784 File Offset: 0x00023984
	public bool forwardsPlayerClientInput
	{
		get
		{
			return this._controller && this._controller.forwardsPlayerClientInput;
		}
	}

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x060008E1 RID: 2273 RVA: 0x000257A4 File Offset: 0x000239A4
	public bool doesNotSave
	{
		get
		{
			return !this._controller || this._controller.doesNotSave;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x060008E2 RID: 2274 RVA: 0x000257C4 File Offset: 0x000239C4
	public new global::Controllable masterControllable
	{
		get
		{
			return (!this.ch.vl) ? null : this.ch.tp;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x060008E3 RID: 2275 RVA: 0x000257E8 File Offset: 0x000239E8
	public new global::Controllable rootControllable
	{
		get
		{
			return (!this.ch.vl) ? null : this.ch.bt;
		}
	}

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0002580C File Offset: 0x00023A0C
	public new global::Controllable nextControllable
	{
		get
		{
			return (!this.ch.vl || !this.ch.up.vl) ? null : this.ch.up.it;
		}
	}

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x060008E5 RID: 2277 RVA: 0x0002584C File Offset: 0x00023A4C
	public new global::Controllable previousControllable
	{
		get
		{
			return (!this.ch.vl || !this.ch.dn.vl) ? null : this.ch.dn.it;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0002588C File Offset: 0x00023A8C
	public new global::Controller masterController
	{
		get
		{
			return (!this.ch.vl) ? null : this.ch.tp._controller;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x060008E7 RID: 2279 RVA: 0x000258C0 File Offset: 0x00023AC0
	public new global::Controller rootController
	{
		get
		{
			return (!this.ch.vl) ? null : this.ch.bt._controller;
		}
	}

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x060008E8 RID: 2280 RVA: 0x000258F4 File Offset: 0x00023AF4
	public new global::Controller nextController
	{
		get
		{
			return (!this.ch.vl || !this.ch.up.vl) ? null : this.ch.up.it._controller;
		}
	}

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x060008E9 RID: 2281 RVA: 0x00025944 File Offset: 0x00023B44
	public new global::Controller previousController
	{
		get
		{
			return (!this.ch.vl || !this.ch.dn.vl) ? null : this.ch.dn.it._controller;
		}
	}

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x060008EA RID: 2282 RVA: 0x00025994 File Offset: 0x00023B94
	public new global::Character masterCharacter
	{
		get
		{
			return (!this.ch.vl) ? null : this.ch.tp.idMain;
		}
	}

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x060008EB RID: 2283 RVA: 0x000259C8 File Offset: 0x00023BC8
	public new global::Character rootCharacter
	{
		get
		{
			return (!this.ch.vl) ? null : this.ch.bt.idMain;
		}
	}

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x060008EC RID: 2284 RVA: 0x000259FC File Offset: 0x00023BFC
	public new global::Character nextCharacter
	{
		get
		{
			return (!this.ch.vl || !this.ch.up.vl) ? null : this.ch.up.it.idMain;
		}
	}

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x060008ED RID: 2285 RVA: 0x00025A4C File Offset: 0x00023C4C
	public new global::Character previousCharacter
	{
		get
		{
			return (!this.ch.vl || !this.ch.dn.vl) ? null : this.ch.dn.it.idMain;
		}
	}

	// Token: 0x17000213 RID: 531
	// (get) Token: 0x060008EE RID: 2286 RVA: 0x00025A9C File Offset: 0x00023C9C
	public new int controlDepth
	{
		get
		{
			return this.ch.id;
		}
	}

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x060008EF RID: 2287 RVA: 0x00025AAC File Offset: 0x00023CAC
	public new int controlCount
	{
		get
		{
			return this.ch.su;
		}
	}

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00025ABC File Offset: 0x00023CBC
	internal bool classAssigned
	{
		get
		{
			return this.@class;
		}
	}

	// Token: 0x17000216 RID: 534
	// (get) Token: 0x060008F1 RID: 2289 RVA: 0x00025ACC File Offset: 0x00023CCC
	internal bool classFlagsRootControllable
	{
		get
		{
			return this.@class && this.@class.root;
		}
	}

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00025AEC File Offset: 0x00023CEC
	internal bool classFlagsVessel
	{
		get
		{
			return this.@class && this.@class.vessel;
		}
	}

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00025B0C File Offset: 0x00023D0C
	internal bool classFlagsStandaloneVessel
	{
		get
		{
			return this.@class && this.@class.vesselStandalone;
		}
	}

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00025B2C File Offset: 0x00023D2C
	internal bool classFlagsDependantVessel
	{
		get
		{
			return this.@class && this.@class.vesselDependant;
		}
	}

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x060008F5 RID: 2293 RVA: 0x00025B4C File Offset: 0x00023D4C
	internal bool classFlagsFreeVessel
	{
		get
		{
			return this.@class && this.@class.vesselFree;
		}
	}

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00025B6C File Offset: 0x00023D6C
	internal bool classFlagsStaticGroup
	{
		get
		{
			return this.@class && this.@class.staticGroup;
		}
	}

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00025B8C File Offset: 0x00023D8C
	internal bool classFlagsPlayerSupport
	{
		get
		{
			return this.@class && this.@class.DefinesClass(true);
		}
	}

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00025BB0 File Offset: 0x00023DB0
	internal bool classFlagsAISupport
	{
		get
		{
			return this.@class && this.@class.DefinesClass(false);
		}
	}

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x060008F9 RID: 2297 RVA: 0x00025BD4 File Offset: 0x00023DD4
	public new string controllerClassName
	{
		get
		{
			return (!this.@class) ? null : this.@class.GetClassName((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player), (this.F & global::Controllable.ControlFlags.Local) == global::Controllable.ControlFlags.Local);
		}
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00025C10 File Offset: 0x00023E10
	[global::System.Diagnostics.Conditional("LOG_CONTROL_CHANGE")]
	private static void LogState(bool guard, string state, global::Controllable controllable)
	{
		global::UnityEngine.Debug.Log(string.Format("{2}{0}::{1}", controllable.GetType().Name, state, (!guard) ? "-" : "+"), controllable);
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00025C50 File Offset: 0x00023E50
	[global::System.Diagnostics.Conditional("LOG_CONTROL_CHANGE")]
	private static void GuardState(string state, global::Controllable self)
	{
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00025C54 File Offset: 0x00023E54
	[global::System.Diagnostics.Conditional("LOG_CONTROL_CHANGE")]
	private static void UnguardState(string state, global::Controllable self)
	{
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x00025C58 File Offset: 0x00023E58
	private void ControlEnter(int cmd)
	{
		try
		{
			this._controller.ControlEnter(cmd);
		}
		finally
		{
			if ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root))
			{
				try
				{
					this._playerClient.OnRootControllableEntered(this);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex, this);
				}
				if ((this.F & global::Controllable.ControlFlags.Local) == global::Controllable.ControlFlags.Local)
				{
					global::Controllable.localPlayerControllableCount++;
					global::Controllable.LocalOnly.rootLocalPlayerControllables.Add(this);
				}
			}
		}
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x00025D00 File Offset: 0x00023F00
	private void ControlExit(int cmd)
	{
		try
		{
			this._controller.ControlExit(cmd);
		}
		finally
		{
			try
			{
				if ((this.F & (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root)) == (global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root))
				{
					if (this._playerClient)
					{
						try
						{
							this._playerClient.OnRootControllableExited(this);
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogError(ex, this);
						}
					}
					if ((this.F & global::Controllable.ControlFlags.Local) == global::Controllable.ControlFlags.Local)
					{
						global::Controllable.localPlayerControllableCount--;
						global::Controllable.LocalOnly.rootLocalPlayerControllables.Remove(this);
					}
				}
			}
			finally
			{
				try
				{
					this.Net_Shutdown_Exit();
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogError(ex2, this);
				}
			}
		}
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x00025E08 File Offset: 0x00024008
	private void Net_Shutdown_Exit()
	{
		global::Facepunch.NetworkView networkView = base.networkView;
		int num = this.RT & 0x3C00;
		if (num == 0x2000 || num == 0x3000)
		{
			if (this.SV_ClearBufferedState(networkView))
			{
				this.RT |= 0x1000;
				networkView.RPC("Controllable:CLR", 1, new object[0]);
				this.SharedPostCLR();
				networkView.RPC("Controllable:ID1", 6, new object[0]);
			}
		}
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x00025E94 File Offset: 0x00024094
	private void ControlEngauge(int cmd)
	{
		this._controller.ControlEngauge(cmd);
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x00025EA4 File Offset: 0x000240A4
	private void ControlCease(int cmd)
	{
		this._controller.ControlCease(cmd);
	}

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000902 RID: 2306 RVA: 0x00025EB4 File Offset: 0x000240B4
	public new global::RPOSLimitFlags rposLimitFlags
	{
		get
		{
			return (!this._controller) ? ((global::RPOSLimitFlags)-1) : this._controller.rposLimitFlags;
		}
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x00025ED8 File Offset: 0x000240D8
	[global::System.Obsolete("Used only by PlayerClient")]
	internal void SetRootPlayer(global::PlayerClient rootPlayer)
	{
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x00025EDC File Offset: 0x000240DC
	private bool SetIdle(bool idle)
	{
		global::IDLocalCharacterIdleControl idleControl = base.idMain.idleControl;
		if (idleControl)
		{
			try
			{
				return idleControl.SetIdle(idle);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(ex, idleControl);
				return true;
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x00025F48 File Offset: 0x00024148
	public void EnterVessel(global::Controllable vessel)
	{
		global::Controllable.OverrideControl(this, vessel);
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x00025F54 File Offset: 0x00024154
	internal void OnWillDestroy()
	{
		if ((this.RT & 0xC20) == 0)
		{
			this.RT |= 0x400;
			this.DoDestroy();
		}
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x00025F80 File Offset: 0x00024180
	private static void OverrideControl(global::Controllable baseControllable, global::Controllable overridingControllable)
	{
		if (!baseControllable.ch.vl)
		{
			throw new global::System.ArgumentException("Not assigned", "baseControllable");
		}
		if (overridingControllable.ch.vl)
		{
			throw new global::System.ArgumentException("Already assigned", "overridingControllable");
		}
		if (baseControllable.ch.up.vl)
		{
			throw new global::System.ArgumentException("Already overridden", "baseControllable");
		}
		global::Facepunch.NetworkView networkView = overridingControllable.SV_ClearBufferedState();
		if (!networkView)
		{
			throw new global::System.ArgumentException("Missing", "overridingControllable.networkView");
		}
		global::Controllable bt = baseControllable.ch.bt;
		global::uLink.NetworkViewID networkViewID = bt.networkViewID;
		global::uLink.NetworkViewID networkViewID2 = baseControllable.networkViewID;
		bt._sentRootControlCount = baseControllable.ch.id + 2;
		bt.networkView.RPC(global::Controllable.kClientSideRootNumberRPCName[bt._sentRootControlCount], 5, new object[0]);
		if (networkViewID == networkViewID2)
		{
			overridingControllable.RT |= 0x2000;
			networkView.RPC<global::uLink.NetworkViewID>("Controllable:OC1", 6, networkViewID);
		}
		else
		{
			overridingControllable.RT |= 0x3000;
			networkView.RPC("Controllable:OC2", 6, new object[]
			{
				networkViewID,
				networkViewID2
			});
		}
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000260CC File Offset: 0x000242CC
	private static void Disconnect(global::Controllable disconnect)
	{
		global::Facepunch.NetworkView networkView = disconnect.networkView;
		if (networkView)
		{
			int num = disconnect.RT & 0x3C00;
			if (num == 0x2000 || num == 0x3000)
			{
				if (disconnect.SV_ClearBufferedState(networkView))
				{
					disconnect.RT |= 0x1000;
					networkView.RPC("Controllable:CLR", 2, new object[0]);
					networkView.RPC("Controllable:ID1", 6, new object[0]);
				}
			}
		}
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x0002615C File Offset: 0x0002435C
	[global::System.Obsolete("RPC call only. Do not call through script", false)]
	[global::UnityEngine.RPC]
	private void CLD(global::uLink.NetworkMessageInfo info)
	{
		global::Controllable.Disconnect(this);
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x00026164 File Offset: 0x00024364
	[global::System.Obsolete("RPC call only. Do not call through script", false)]
	[global::UnityEngine.RPC]
	private void CLR(global::uLink.NetworkMessageInfo info)
	{
		global::Controllable bt = this.ch.bt;
		global::Facepunch.NetworkView networkView = bt.networkView;
		if (networkView && networkView.viewID != global::uLink.NetworkViewID.unassigned)
		{
			global::NetCull.RemoveRPCsByName(networkView, "Controllable:RFH");
			while (bt._sentRootControlCount > this.ch.id)
			{
				global::NetCull.RemoveRPCsByName(networkView, global::Controllable.kClientSideRootNumberRPCName[bt._sentRootControlCount--]);
			}
		}
		this.ch.Delete();
		if (bt && (bt.RT & 0xC00) == 0 && networkView && networkView.viewID != global::uLink.NetworkViewID.unassigned)
		{
			networkView.RPC<byte>("Controllable:RFH", 5, (byte)bt._sentRootControlCount);
		}
		this.SharedPostCLR();
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x00026248 File Offset: 0x00024448
	private void SharedPostCLR()
	{
		if (this._controller)
		{
			global::UnityEngine.Object.Destroy(this._controller);
		}
		this.F &= (global::Controllable.ControlFlags.Root | global::Controllable.ControlFlags.Strong);
		this.RT = 0;
		this._playerClient = null;
		this._controller = null;
		this.SetIdle(true);
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x0002629C File Offset: 0x0002449C
	[global::System.Obsolete("RPC call only. Do not call through script", false)]
	[global::UnityEngine.RPC]
	private void ID1()
	{
		this.SetIdle(true);
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x000262A8 File Offset: 0x000244A8
	[global::UnityEngine.RPC]
	private void OC2(global::uLink.NetworkViewID rootViewID, global::uLink.NetworkViewID parentViewID, global::uLink.NetworkMessageInfo info)
	{
		this.OverrideControlOfHandleRPC(rootViewID, parentViewID, ref info);
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x000262B4 File Offset: 0x000244B4
	[global::UnityEngine.RPC]
	private void OC1(global::uLink.NetworkViewID rootViewID, global::uLink.NetworkMessageInfo info)
	{
		this.OverrideControlOfHandleRPC(rootViewID, rootViewID, ref info);
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x000262C0 File Offset: 0x000244C0
	private void OverrideControlOfHandleRPC(global::uLink.NetworkViewID rootViewID, global::uLink.NetworkViewID parentViewID, ref global::uLink.NetworkMessageInfo info)
	{
		this.OCO_FOUND(parentViewID, ref info);
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x000262CC File Offset: 0x000244CC
	[global::UnityEngine.RPC]
	private void RN0(global::uLink.NetworkMessageInfo info)
	{
		this.RN(0, ref info);
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x000262D8 File Offset: 0x000244D8
	[global::UnityEngine.RPC]
	private void RN1(global::uLink.NetworkMessageInfo info)
	{
		this.RN(1, ref info);
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x000262E4 File Offset: 0x000244E4
	[global::UnityEngine.RPC]
	private void RN2(global::uLink.NetworkMessageInfo info)
	{
		this.RN(2, ref info);
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x000262F0 File Offset: 0x000244F0
	[global::UnityEngine.RPC]
	private void RN3(global::uLink.NetworkMessageInfo info)
	{
		this.RN(3, ref info);
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x000262FC File Offset: 0x000244FC
	[global::UnityEngine.RPC]
	private void RN4(global::uLink.NetworkMessageInfo info)
	{
		this.RN(4, ref info);
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x00026308 File Offset: 0x00024508
	[global::UnityEngine.RPC]
	private void RN5(global::uLink.NetworkMessageInfo info)
	{
		this.RN(5, ref info);
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x00026314 File Offset: 0x00024514
	[global::UnityEngine.RPC]
	private void RN6(global::uLink.NetworkMessageInfo info)
	{
		this.RN(6, ref info);
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x00026320 File Offset: 0x00024520
	[global::UnityEngine.RPC]
	private void RN7(global::uLink.NetworkMessageInfo info)
	{
		this.RN(7, ref info);
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x0002632C File Offset: 0x0002452C
	[global::UnityEngine.RPC]
	private void RFH(byte top)
	{
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x00026330 File Offset: 0x00024530
	internal void OnInstantiated()
	{
		if ((this.F & global::Controllable.ControlFlags.Root) == global::Controllable.ControlFlags.Root)
		{
			this.ch.RefreshEngauge();
		}
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x0002634C File Offset: 0x0002454C
	private void OCO_FOUND(global::uLink.NetworkViewID viewID, ref global::uLink.NetworkMessageInfo info)
	{
		this.SetIdle(false);
		this.__networkViewForControllable = base.networkView;
		this.__controllerDriverViewID = viewID;
		this.__controllerCreateMessageInfo = info;
		this.FreshInitializeController();
		this.ch.RefreshEngauge();
		global::Facepunch.NetworkView networkView = this.ch.bt.networkView;
		if (networkView && networkView.viewID != global::uLink.NetworkViewID.unassigned)
		{
			global::NetCull.RemoveRPCsByName(networkView, "Controllable:RFH");
			networkView.RPC<byte>("Controllable:RFH", 5, (byte)this.ch.su);
		}
	}

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x0600091B RID: 2331 RVA: 0x000263E4 File Offset: 0x000245E4
	public static bool localPlayerControllableExists
	{
		get
		{
			return global::Controllable.localPlayerControllableCount > 0;
		}
	}

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x0600091C RID: 2332 RVA: 0x000263F0 File Offset: 0x000245F0
	public static global::Controllable localPlayerControllable
	{
		get
		{
			int num = global::Controllable.localPlayerControllableCount;
			if (num == 0)
			{
				return null;
			}
			if (num != 1)
			{
				return global::Controllable.LocalOnly.rootLocalPlayerControllables[global::Controllable.localPlayerControllableCount - 1];
			}
			return global::Controllable.LocalOnly.rootLocalPlayerControllables[0];
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x00026434 File Offset: 0x00024634
	private void OnDestroy()
	{
		if (this.isInContextQuery)
		{
			try
			{
				if (global::Controllable.onDestroyInContextQuery != null)
				{
					global::Controllable.onDestroyInContextQuery(this);
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(ex, this);
			}
			finally
			{
				this.isInContextQuery = false;
			}
		}
		this.RT |= 0x800;
		if ((this.RT & 0x420) == 0)
		{
			this.DoDestroy();
		}
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x000264D8 File Offset: 0x000246D8
	private void DoDestroy()
	{
		try
		{
			this.RT |= 0x20;
			if ((this.RT & 3) != 0)
			{
				this.ch.Delete();
			}
		}
		finally
		{
			this.RT &= -0x21;
		}
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00026540 File Offset: 0x00024740
	internal bool MergeClasses(ref global::ControllerClass.Merge merge)
	{
		return this.@class && merge.Add(this.controllable.@class);
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x00026574 File Offset: 0x00024774
	internal static bool MergeClasses(global::IDMain character, ref global::ControllerClass.Merge merge)
	{
		global::Controllable component;
		return character && (component = character.GetComponent<global::Controllable>()) && component.MergeClasses(ref merge);
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x000265A8 File Offset: 0x000247A8
	internal static global::Controllable SpawnPlayerRoot(string prefabName, ref global::UnityEngine.Vector3 position, ref global::UnityEngine.Quaternion rotation, global::NetUser user, object[] args, bool anyArgs)
	{
		if (object.ReferenceEquals(user, null))
		{
			throw new global::System.ArgumentNullException("user");
		}
		if (user.disposed)
		{
			throw new global::System.ObjectDisposedException("user");
		}
		global::uLink.NetworkPlayer networkPlayer = user.networkPlayer;
		if (networkPlayer.isServer)
		{
			throw new global::System.ArgumentException("user was the server", "user");
		}
		if (!networkPlayer.isConnected)
		{
			throw new global::System.ArgumentException("user is no longer connected", "user");
		}
		global::ControllablePrefab.EnsurePrefabIsPlayerRootCompatible(prefabName);
		global::UnityEngine.GameObject gameObject;
		if (anyArgs)
		{
			gameObject = global::NetCull.InstantiatePlayerRootWithArgs(networkPlayer, prefabName, position, rotation, args);
		}
		else
		{
			gameObject = global::NetCull.InstantiatePlayerRoot(networkPlayer, prefabName, position, rotation);
		}
		return ((global::Character)gameObject.GetComponent<global::NetInstance>().idMain).controllable;
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x00026674 File Offset: 0x00024874
	internal static global::Controllable SpawnAIRoot(string prefabName, ref global::UnityEngine.Vector3 position, ref global::UnityEngine.Quaternion rotation, object[] args, bool anyArgs)
	{
		bool flag;
		global::ControllablePrefab.EnsurePrefabIsAIRootCompatible(prefabName, out flag);
		global::UnityEngine.GameObject gameObject;
		if (flag)
		{
			if (anyArgs)
			{
				gameObject = global::NetCull.InstantiateStaticWithArgs(prefabName, position, rotation, args);
			}
			else
			{
				gameObject = global::NetCull.InstantiateStatic(prefabName, position, rotation);
			}
		}
		else if (anyArgs)
		{
			gameObject = global::NetCull.InstantiateDynamicWithArgs(prefabName, position, rotation, args);
		}
		else
		{
			gameObject = global::NetCull.InstantiateDynamic(prefabName, position, rotation);
		}
		return ((global::Character)gameObject.GetComponent<global::NetInstance>().idMain).controllable;
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x00026710 File Offset: 0x00024910
	internal static global::Controllable SpawnVessel(string prefabName, ref global::UnityEngine.Vector3 position, ref global::UnityEngine.Quaternion rotation, global::Controllable enter, object[] args, bool anyArgs)
	{
		global::ControllablePrefab.VesselInfo vesselInfo;
		global::uLink.NetworkViewID networkViewID;
		global::uLink.NetworkPlayer owner;
		bool flag;
		global::NetworkCullInfo group;
		bool flag2;
		if (enter)
		{
			global::ControllablePrefab.EnsurePrefabIsVessel(prefabName, enter, out vesselInfo);
			networkViewID = enter.networkViewID;
			global::PlayerClient playerClient;
			if (vesselInfo.canBind && (playerClient = enter.playerClient))
			{
				owner = playerClient.netPlayer;
				if (!owner.isConnected)
				{
					throw new global::System.ArgumentException("the controllable was made for a player which is now disconnected", "enter");
				}
				flag = vesselInfo.canBind;
			}
			else
			{
				owner = global::uLink.NetworkPlayer.server;
				flag = false;
			}
			if (vesselInfo.mustBind && networkViewID == global::uLink.NetworkViewID.unassigned)
			{
				throw new global::NonBindlessVesselControllableException(prefabName);
			}
			if (vesselInfo.canBind)
			{
				flag2 = (group = enter.idMain.GetComponent<global::NetworkCullInfo>());
			}
			else
			{
				flag2 = false;
				group = null;
			}
		}
		else
		{
			flag = false;
			global::ControllablePrefab.EnsurePrefabIsVessel(prefabName, out vesselInfo);
			if (vesselInfo.mustBind)
			{
				throw new global::NonBindlessVesselControllableException(prefabName);
			}
			networkViewID = global::uLink.NetworkViewID.unassigned;
			owner = global::uLink.NetworkPlayer.unassigned;
			flag2 = false;
			group = null;
		}
		bool staticGroup = vesselInfo.staticGroup;
		global::UnityEngine.GameObject gameObject = (!flag) ? ((!staticGroup) ? ((!flag2) ? ((!anyArgs) ? global::NetCull.InstantiateDynamic(prefabName, position, rotation) : global::NetCull.InstantiateDynamicWithArgs(prefabName, position, rotation, args)) : ((!anyArgs) ? global::NetCull.InstantiatePiggyBack(group, prefabName, position, rotation) : global::NetCull.InstantiatePiggyBackWithArgs(group, prefabName, position, rotation, args))) : ((!anyArgs) ? global::NetCull.InstantiateStatic(prefabName, position, rotation) : global::NetCull.InstantiateStaticWithArgs(prefabName, position, rotation, args))) : ((!staticGroup) ? ((!flag2) ? ((!anyArgs) ? global::NetCull.InstantiateDynamic(owner, prefabName, position, rotation) : global::NetCull.InstantiateDynamicWithArgs(owner, prefabName, position, rotation, args)) : ((!anyArgs) ? global::NetCull.InstantiatePiggyBack(owner, group, prefabName, position, rotation) : global::NetCull.InstantiatePiggyBackWithArgs(owner, group, prefabName, position, rotation, args))) : ((!anyArgs) ? global::NetCull.InstantiateStatic(owner, prefabName, position, rotation) : global::NetCull.InstantiateStaticWithArgs(owner, prefabName, position, rotation, args)));
		global::Character character = (global::Character)gameObject.GetComponent<global::NetInstance>().idMain;
		global::Controllable controllable = character.controllable;
		if ((controllable.F & global::Controllable.ControlFlags.Initialized) == (global::Controllable.ControlFlags)0 && (controllable.RT & 0x3000) == 0)
		{
			if (networkViewID == global::uLink.NetworkViewID.unassigned)
			{
				character.controllable.RT |= 0x1000;
				character.networkView.RPC("Controllable:ID1", 6, new object[0]);
			}
			else
			{
				global::Controllable.OverrideControl(enter, character.controllable);
			}
		}
		return character.controllable;
	}

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06000924 RID: 2340 RVA: 0x00026A28 File Offset: 0x00024C28
	public static global::System.Collections.Generic.IEnumerable<global::Controllable> PlayerRootControllables
	{
		get
		{
			foreach (global::PlayerClient pc in global::PlayerClient.All)
			{
				global::Controllable controllable = pc.rootControllable;
				if (controllable)
				{
					yield return controllable;
				}
			}
			yield break;
		}
	}

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06000925 RID: 2341 RVA: 0x00026A44 File Offset: 0x00024C44
	public static global::System.Collections.Generic.IEnumerable<global::Controllable> PlayerCurrentControllables
	{
		get
		{
			foreach (global::PlayerClient pc in global::PlayerClient.All)
			{
				global::Controllable controllable = pc.controllable;
				if (controllable)
				{
					yield return controllable;
				}
			}
			yield break;
		}
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x00026A60 File Offset: 0x00024C60
	public static global::System.Collections.Generic.IEnumerable<global::Controllable> RootControllers(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients)
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.rootControllable;
			if (controllable)
			{
				yield return controllable;
			}
		}
		yield break;
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x00026A8C File Offset: 0x00024C8C
	public static global::System.Collections.Generic.IEnumerable<global::Controllable> CurrentControllers(global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients)
	{
		foreach (global::PlayerClient pc in playerClients)
		{
			global::Controllable controllable = pc.controllable;
			if (controllable)
			{
				yield return controllable;
			}
		}
		yield break;
	}

	// Token: 0x0400065F RID: 1631
	private const int RT_ENTERED = 1;

	// Token: 0x04000660 RID: 1632
	private const int RT_PROMOTED = 3;

	// Token: 0x04000661 RID: 1633
	private const int RT_ENTER_LOCK = 8;

	// Token: 0x04000662 RID: 1634
	private const int RT_PROMO_LOCK = 0x10;

	// Token: 0x04000663 RID: 1635
	private const int RT_DESTROY_LOCK = 0x20;

	// Token: 0x04000664 RID: 1636
	private const int RT_ENTERED_ONCE = 0x40;

	// Token: 0x04000665 RID: 1637
	private const int RT_PROMOTED_ONCE = 0x80;

	// Token: 0x04000666 RID: 1638
	private const int RT_DEMOTED_ONCE = 0x100;

	// Token: 0x04000667 RID: 1639
	private const int RT_EXITED_ONCE = 0x200;

	// Token: 0x04000668 RID: 1640
	private const int RT_WILL_DESTROY = 0x400;

	// Token: 0x04000669 RID: 1641
	private const int RT_IS_DESTROYED = 0x800;

	// Token: 0x0400066A RID: 1642
	private const int RT_RPC_CONTROL_0 = 0x1000;

	// Token: 0x0400066B RID: 1643
	private const int RT_RPC_CONTROL_1 = 0x2000;

	// Token: 0x0400066C RID: 1644
	private const int RT_RPC_CONTROL_2 = 0x3000;

	// Token: 0x0400066D RID: 1645
	private const int RT_STATE = 3;

	// Token: 0x0400066E RID: 1646
	private const int RT_ONCE = 0x3C0;

	// Token: 0x0400066F RID: 1647
	private const int RT_DESTROY_STATE = 0xC00;

	// Token: 0x04000670 RID: 1648
	private const int RT_RPC_CONTROL = 0x3000;

	// Token: 0x04000671 RID: 1649
	private const global::Controllable.ControlFlags PERSISTANT_FLAGS = global::Controllable.ControlFlags.Root | global::Controllable.ControlFlags.Strong;

	// Token: 0x04000672 RID: 1650
	private const global::Controllable.ControlFlags MUTABLE_FLAGS = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Initialized;

	// Token: 0x04000673 RID: 1651
	private const global::Controllable.ControlFlags TRANSFERED_FLAGS = global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player;

	// Token: 0x04000674 RID: 1652
	private const global::Controllable.ControlFlags CONTROLLER_NPC = (global::Controllable.ControlFlags)0;

	// Token: 0x04000675 RID: 1653
	private const global::Controllable.ControlFlags CONTROLLER_CLIENT = global::Controllable.ControlFlags.Player;

	// Token: 0x04000676 RID: 1654
	private const global::Controllable.ControlFlags NETWORK_MINE = global::Controllable.ControlFlags.Local;

	// Token: 0x04000677 RID: 1655
	private const global::Controllable.ControlFlags NETWORK_PROXY = (global::Controllable.ControlFlags)0;

	// Token: 0x04000678 RID: 1656
	private const global::Controllable.ControlFlags ACTIVE_OCCUPIED = global::Controllable.ControlFlags.Owned;

	// Token: 0x04000679 RID: 1657
	private const global::Controllable.ControlFlags ACTIVE_VACANT = (global::Controllable.ControlFlags)0;

	// Token: 0x0400067A RID: 1658
	private const global::Controllable.ControlFlags TREE_TRUNK = global::Controllable.ControlFlags.Root;

	// Token: 0x0400067B RID: 1659
	private const global::Controllable.ControlFlags TREE_BRANCH = (global::Controllable.ControlFlags)0;

	// Token: 0x0400067C RID: 1660
	private const global::Controllable.ControlFlags SETUP_INITIALIZED = global::Controllable.ControlFlags.Initialized;

	// Token: 0x0400067D RID: 1661
	private const global::Controllable.ControlFlags SETUP_UNINITIALIZED = (global::Controllable.ControlFlags)0;

	// Token: 0x0400067E RID: 1662
	private const global::Controllable.ControlFlags BINDING_STRONG = global::Controllable.ControlFlags.Strong;

	// Token: 0x0400067F RID: 1663
	private const global::Controllable.ControlFlags BINDING_WEAK = (global::Controllable.ControlFlags)0;

	// Token: 0x04000680 RID: 1664
	private const global::Controllable.ControlFlags CONTROLLER_MASK = global::Controllable.ControlFlags.Player;

	// Token: 0x04000681 RID: 1665
	private const global::Controllable.ControlFlags NETWORK_MASK = global::Controllable.ControlFlags.Local;

	// Token: 0x04000682 RID: 1666
	private const global::Controllable.ControlFlags ACTIVE_MASK = global::Controllable.ControlFlags.Owned;

	// Token: 0x04000683 RID: 1667
	private const global::Controllable.ControlFlags TREE_MASK = global::Controllable.ControlFlags.Root;

	// Token: 0x04000684 RID: 1668
	private const global::Controllable.ControlFlags SETUP_MASK = global::Controllable.ControlFlags.Initialized;

	// Token: 0x04000685 RID: 1669
	private const global::Controllable.ControlFlags BINDING_MASK = global::Controllable.ControlFlags.Strong;

	// Token: 0x04000686 RID: 1670
	private const global::Controllable.ControlFlags MASK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root | global::Controllable.ControlFlags.Initialized | global::Controllable.ControlFlags.Strong;

	// Token: 0x04000687 RID: 1671
	private const global::Controllable.ControlFlags OWNER_MASK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player;

	// Token: 0x04000688 RID: 1672
	private const global::Controllable.ControlFlags OWNER_NPC = global::Controllable.ControlFlags.Owned;

	// Token: 0x04000689 RID: 1673
	private const global::Controllable.ControlFlags OWNER_CLIENT = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player;

	// Token: 0x0400068A RID: 1674
	private const global::Controllable.ControlFlags OWNER_NET_MASK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player;

	// Token: 0x0400068B RID: 1675
	private const global::Controllable.ControlFlags OWNER_NET_NPC_MINE = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local;

	// Token: 0x0400068C RID: 1676
	private const global::Controllable.ControlFlags OWNER_NET_NPC_PROXY = global::Controllable.ControlFlags.Owned;

	// Token: 0x0400068D RID: 1677
	private const global::Controllable.ControlFlags OWNER_NET_CLIENT_MINE = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player;

	// Token: 0x0400068E RID: 1678
	private const global::Controllable.ControlFlags OWNER_NET_CLIENT_PROXY = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player;

	// Token: 0x0400068F RID: 1679
	private const global::Controllable.ControlFlags OWNER_NET_TREE_MASK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root;

	// Token: 0x04000690 RID: 1680
	private const global::Controllable.ControlFlags OWNER_NET_TREE_NPC_MINE_TRUNK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Root;

	// Token: 0x04000691 RID: 1681
	private const global::Controllable.ControlFlags OWNER_NET_TREE_NPC_PROXY_TRUNK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Root;

	// Token: 0x04000692 RID: 1682
	private const global::Controllable.ControlFlags OWNER_NET_TREE_CLIENT_MINE_TRUNK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root;

	// Token: 0x04000693 RID: 1683
	private const global::Controllable.ControlFlags OWNER_NET_TREE_CLIENT_PROXY_TRUNK = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player | global::Controllable.ControlFlags.Root;

	// Token: 0x04000694 RID: 1684
	private const global::Controllable.ControlFlags OWNER_NET_TREE_NPC_MINE_BRANCH = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local;

	// Token: 0x04000695 RID: 1685
	private const global::Controllable.ControlFlags OWNER_NET_TREE_NPC_PROXY_BRANCH = global::Controllable.ControlFlags.Owned;

	// Token: 0x04000696 RID: 1686
	private const global::Controllable.ControlFlags OWNER_NET_TREE_CLIENT_MINE_BRANCH = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Local | global::Controllable.ControlFlags.Player;

	// Token: 0x04000697 RID: 1687
	private const global::Controllable.ControlFlags OWNER_NET_TREE_CLIENT_PROXY_BRANCH = global::Controllable.ControlFlags.Owned | global::Controllable.ControlFlags.Player;

	// Token: 0x04000698 RID: 1688
	private const string kControllableRPCPrefix = "Controllable:";

	// Token: 0x04000699 RID: 1689
	private const string kClientDeleteRPCName = "Controllable:CLD";

	// Token: 0x0400069A RID: 1690
	private const string kClearFromChainRPCName = "Controllable:CLR";

	// Token: 0x0400069B RID: 1691
	private const string kIdleOnRPCName = "Controllable:ID1";

	// Token: 0x0400069C RID: 1692
	private const string kOverrideControlOfRPCName1 = "Controllable:OC1";

	// Token: 0x0400069D RID: 1693
	private const string kOverrideControlOfRPCName2 = "Controllable:OC2";

	// Token: 0x0400069E RID: 1694
	private const string kClientRefreshRPCName = "Controllable:RFH";

	// Token: 0x0400069F RID: 1695
	private const global::uLink.RPCMode kClientDeleteRPCMode = 0;

	// Token: 0x040006A0 RID: 1696
	private const global::uLink.RPCMode kClearFromChainRPCMode = 2;

	// Token: 0x040006A1 RID: 1697
	private const global::uLink.RPCMode kClearFromChainRPCMode_POST = 1;

	// Token: 0x040006A2 RID: 1698
	private const global::uLink.RPCMode kOverrideControlOfRPCMode = 6;

	// Token: 0x040006A3 RID: 1699
	private const global::uLink.RPCMode kIdleOnRPCMode = 6;

	// Token: 0x040006A4 RID: 1700
	private const global::uLink.RPCMode kClientSideRootNumberRPCMode = 5;

	// Token: 0x040006A5 RID: 1701
	private const global::uLink.RPCMode kClientRefreshRPCMode = 5;

	// Token: 0x040006A6 RID: 1702
	private const string kRPCCall = "RPC call only. Do not call through script";

	// Token: 0x040006A7 RID: 1703
	private const bool kRPCCallError = false;

	// Token: 0x040006A8 RID: 1704
	[global::UnityEngine.SerializeField]
	private global::ControllerClass @class;

	// Token: 0x040006A9 RID: 1705
	[global::System.NonSerialized]
	private global::PlayerClient _playerClient;

	// Token: 0x040006AA RID: 1706
	[global::System.NonSerialized]
	private global::Controller _controller;

	// Token: 0x040006AB RID: 1707
	[global::System.NonSerialized]
	private global::Controllable.ControlFlags F;

	// Token: 0x040006AC RID: 1708
	[global::System.NonSerialized]
	private global::Controllable.Chain ch;

	// Token: 0x040006AD RID: 1709
	[global::System.NonSerialized]
	private int RT;

	// Token: 0x040006AE RID: 1710
	[global::System.NonSerialized]
	private global::uLink.NetworkViewID __controllerDriverViewID;

	// Token: 0x040006AF RID: 1711
	[global::System.NonSerialized]
	private global::uLink.NetworkMessageInfo __controllerCreateMessageInfo;

	// Token: 0x040006B0 RID: 1712
	[global::System.NonSerialized]
	private global::uLink.NetworkView __networkViewForControllable;

	// Token: 0x040006B1 RID: 1713
	[global::System.NonSerialized]
	private bool lateFinding;

	// Token: 0x040006B2 RID: 1714
	[global::System.NonSerialized]
	private int _sentRootControlCount;

	// Token: 0x040006B3 RID: 1715
	[global::System.NonSerialized]
	public bool isInContextQuery;

	// Token: 0x040006B4 RID: 1716
	private static int localPlayerControllableCount;

	// Token: 0x040006B5 RID: 1717
	private static readonly string[] kClientSideRootNumberRPCName = new string[]
	{
		"Controllable:RN0",
		"Controllable:RN1",
		"Controllable:RN2",
		"Controllable:RN3",
		"Controllable:RN4",
		"Controllable:RN5",
		"Controllable:RN6",
		"Controllable:RN7"
	};

	// Token: 0x040006B6 RID: 1718
	private static global::Controllable.DestroyInContextQuery onDestroyInContextQuery;

	// Token: 0x02000149 RID: 329
	private struct Chain
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x00026AB8 File Offset: 0x00024CB8
		public int id
		{
			get
			{
				return (!this.vl) ? -1 : ((int)this.nm);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x00026AD4 File Offset: 0x00024CD4
		public int su
		{
			get
			{
				return (!this.vl) ? -1 : ((int)(1 + this.nm + this.ln));
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00026B04 File Offset: 0x00024D04
		public static void ROOT(global::Controllable root)
		{
			root.ch.tp = root;
			root.ch.bt = root;
			root.ch.it = root;
			root.ch.vl = true;
			root.ch.dn.vl = (root.ch.up.vl = false);
			root.ch.dn.it = (root.ch.up.it = null);
			root.ch.nm = (root.ch.ln = 0);
			root.ch.iv = true;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00026BB4 File Offset: 0x00024DB4
		private bool Add(ref global::Controllable.Chain nw, global::Controllable ct)
		{
			if (!this.vl || nw.vl)
			{
				return false;
			}
			nw.it = ct;
			nw.it.ON_CHAIN_RENEW();
			this.tp.ch.up.vl = true;
			this.tp.ch.up.it = nw.it;
			nw.dn.vl = true;
			nw.dn.it = this.tp;
			nw.nm = this.tp.ch.nm;
			nw.nm += 1;
			nw.ln = 0;
			nw.up.vl = false;
			nw.up.it = null;
			nw.tp = nw.it;
			nw.bt = this.tp.ch.bt;
			nw.vl = true;
			global::Controllable.Link link = nw.dn;
			nw.iv = true;
			do
			{
				link.it.ch.tp = nw.tp;
				global::Controllable controllable = link.it;
				controllable.ch.ln = controllable.ch.ln + 1;
				link.it.ch.iv = true;
				link = link.it.ch.dn;
			}
			while (link.vl);
			nw.it.ON_CHAIN_SUBSCRIBE();
			return true;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00026D24 File Offset: 0x00024F24
		public bool Add(global::Controllable vessel)
		{
			return vessel && this.Add(ref vessel.ch, vessel);
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00026D44 File Offset: 0x00024F44
		public bool RefreshEngauge()
		{
			if (!this.vl)
			{
				return false;
			}
			if (this.tp.ch.iv)
			{
				int num;
				if (this.bt.ch.up.vl)
				{
					global::Controllable controllable = this.bt;
					num = 0x80;
					for (;;)
					{
						controllable.ch.iv = false;
						switch (controllable.RT & 3)
						{
						case 0:
							global::Controllable.DO_ENTER(global::Controllable.CAP_ENTER(num, controllable.RT, controllable.F), controllable);
							break;
						case 3:
							global::Controllable.DO_DEMOTE(global::Controllable.CAP_DEMOTE(num, controllable.RT, controllable.F), controllable);
							break;
						}
						num |= 0x300;
						if (!controllable.ch.up.vl)
						{
							break;
						}
						controllable = controllable.ch.up.it;
					}
				}
				else
				{
					num = 0;
				}
				this.tp.ch.iv = false;
				switch (this.tp.RT & 3)
				{
				case 0:
					global::Controllable.DO_ENTER(global::Controllable.CAP_ENTER(num & -0x81, this.tp.RT, this.tp.F), this.tp);
					global::Controllable.DO_PROMOTE(global::Controllable.CAP_PROMOTE(num & -0x81, this.tp.RT, this.tp.F), this.tp);
					break;
				case 1:
					global::Controllable.DO_PROMOTE(global::Controllable.CAP_PROMOTE(num & -0x81, this.tp.RT, this.tp.F), this.tp);
					break;
				}
			}
			return true;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00026F20 File Offset: 0x00025120
		public bool RefreshEnter()
		{
			if (!this.vl)
			{
				return false;
			}
			if (this.tp.ch.iv)
			{
				int num;
				if (this.bt.ch.up.vl)
				{
					global::Controllable controllable = this.bt;
					num = 0x80;
					for (;;)
					{
						switch (controllable.RT & 3)
						{
						case 0:
							global::Controllable.DO_ENTER(global::Controllable.CAP_ENTER(num, controllable.RT, controllable.F), controllable);
							break;
						case 3:
							global::Controllable.DO_DEMOTE(global::Controllable.CAP_DEMOTE(num, controllable.RT, controllable.F), controllable);
							break;
						}
						num |= 0x300;
						if (!controllable.ch.up.vl)
						{
							break;
						}
						controllable = controllable.ch.up.it;
					}
				}
				else
				{
					num = 0;
				}
				switch (this.tp.RT & 3)
				{
				case 0:
					global::Controllable.DO_ENTER(global::Controllable.CAP_ENTER(num, this.tp.RT, this.tp.F), this.tp);
					break;
				}
			}
			return true;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00027080 File Offset: 0x00025280
		public override string ToString()
		{
			if (!this.vl)
			{
				return "invalid";
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			global::Controllable controllable = this.bt;
			while (controllable)
			{
				if (controllable == this.it)
				{
					stringBuilder.Append("-->");
				}
				else
				{
					stringBuilder.Append("   ");
				}
				stringBuilder.AppendLine(controllable.name);
				controllable = ((!controllable.ch.up.vl) ? null : controllable.ch.up.it);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00027128 File Offset: 0x00025328
		public void Delete()
		{
			if (!this.vl)
			{
				return;
			}
			int num = global::Controllable.CAP_THIS(0x10, this.it.RT, this.it.F);
			if (this.up.vl)
			{
				int num2 = (int)this.ln;
				int num3 = (num & 0x91) << 1;
				if (!this.dn.vl)
				{
					num3 |= (num & 0x91) << 2;
				}
				for (;;)
				{
					global::Controllable controllable = this.tp.ch.dn.it;
					global::Controllable controllable2 = this.tp;
					int cmd;
					switch (controllable2.RT & 3)
					{
					case 1:
						global::Controllable.DO_EXIT(cmd = global::Controllable.CAP_EXIT(num3, controllable2.RT, controllable2.F), controllable2);
						break;
					case 2:
						goto IL_10A;
					case 3:
						cmd = global::Controllable.CAP_EXIT(num3, controllable2.RT, controllable2.F);
						global::Controllable.DO_DEMOTE(global::Controllable.CAP_DEMOTE(cmd, controllable2.RT, controllable2.F), controllable2);
						global::Controllable.DO_EXIT(cmd, controllable2);
						break;
					default:
						goto IL_10A;
					}
					IL_124:
					controllable2.ON_CHAIN_ERASE(cmd);
					controllable2.ch = default(global::Controllable.Chain);
					controllable2.ON_CHAIN_ABOLISHED();
					this.tp = controllable;
					this.tp.ch.up = default(global::Controllable.Link);
					this.tp.ch.ln = this.tp.ch.ln - 1;
					this.tp.ch.tp = this.tp;
					global::Controllable.Link link = this.tp.ch.dn;
					byte b = this.tp.ch.ln;
					while (link.vl)
					{
						global::Controllable controllable3 = link.it;
						link = controllable3.ch.dn;
						controllable3.ch.tp = this.tp;
						b = (controllable3.ch.ln = b - 1);
					}
					if (--num2 <= 0)
					{
						break;
					}
					continue;
					IL_10A:
					cmd = global::Controllable.CAP_THIS(num3, controllable2.RT, controllable2.F);
					goto IL_124;
				}
			}
			switch (this.it.RT & 3)
			{
			case 1:
				global::Controllable.DO_EXIT(global::Controllable.CAP_EXIT(num, this.it.RT, this.it.F), this.it);
				break;
			case 3:
				global::Controllable.DO_DEMOTE(global::Controllable.CAP_DEMOTE(num, this.it.RT, this.it.F), this.it);
				global::Controllable.DO_EXIT(global::Controllable.CAP_EXIT(num, this.it.RT, this.it.F), this.it);
				break;
			}
			global::Controllable controllable4 = this.it;
			controllable4.ON_CHAIN_ERASE(num);
			global::Controllable.Link link2 = this.dn;
			controllable4.ch = (this = default(global::Controllable.Chain));
			if (link2.vl)
			{
				global::Controllable controllable5 = link2.it;
				controllable5.ch.up = default(global::Controllable.Link);
				int num4 = 0;
				do
				{
					global::Controllable controllable6 = link2.it;
					link2 = controllable6.ch.dn;
					controllable6.ch.iv = true;
					controllable6.ch.tp = controllable5;
					controllable6.ch.ln = (byte)num4++;
				}
				while (link2.vl);
			}
			controllable4.ON_CHAIN_ABOLISHED();
		}

		// Token: 0x040006B7 RID: 1719
		public global::Controllable it;

		// Token: 0x040006B8 RID: 1720
		public global::Controllable bt;

		// Token: 0x040006B9 RID: 1721
		public global::Controllable tp;

		// Token: 0x040006BA RID: 1722
		public global::Controllable.Link dn;

		// Token: 0x040006BB RID: 1723
		public global::Controllable.Link up;

		// Token: 0x040006BC RID: 1724
		public byte nm;

		// Token: 0x040006BD RID: 1725
		public byte ln;

		// Token: 0x040006BE RID: 1726
		public bool vl;

		// Token: 0x040006BF RID: 1727
		public bool iv;
	}

	// Token: 0x0200014A RID: 330
	[global::System.Flags]
	private enum ControlFlags
	{
		// Token: 0x040006C1 RID: 1729
		Owned = 1,
		// Token: 0x040006C2 RID: 1730
		Local = 2,
		// Token: 0x040006C3 RID: 1731
		Player = 4,
		// Token: 0x040006C4 RID: 1732
		Root = 8,
		// Token: 0x040006C5 RID: 1733
		Initialized = 0x10,
		// Token: 0x040006C6 RID: 1734
		Strong = 0x20
	}

	// Token: 0x0200014B RID: 331
	private struct Link
	{
		// Token: 0x040006C7 RID: 1735
		public global::Controllable it;

		// Token: 0x040006C8 RID: 1736
		public bool vl;
	}

	// Token: 0x0200014C RID: 332
	private static class LocalOnly
	{
		// Token: 0x06000931 RID: 2353 RVA: 0x000274BC File Offset: 0x000256BC
		// Note: this type is marked as 'beforefieldinit'.
		static LocalOnly()
		{
		}

		// Token: 0x040006C9 RID: 1737
		public static readonly global::System.Collections.Generic.List<global::Controllable> rootLocalPlayerControllables = new global::System.Collections.Generic.List<global::Controllable>();
	}

	// Token: 0x0200014D RID: 333
	// (Invoke) Token: 0x06000933 RID: 2355
	public delegate void DestroyInContextQuery(global::Controllable controllable);

	// Token: 0x0200014E RID: 334
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator25 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controllable>, global::System.Collections.Generic.IEnumerator<global::Controllable>
	{
		// Token: 0x06000936 RID: 2358 RVA: 0x000274C8 File Offset: 0x000256C8
		public <>c__Iterator25()
		{
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x000274D0 File Offset: 0x000256D0
		global::Controllable global::System.Collections.Generic.IEnumerator<global::Controllable>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x000274D8 File Offset: 0x000256D8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x000274E0 File Offset: 0x000256E0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controllable>.GetEnumerator();
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x000274E8 File Offset: 0x000256E8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controllable> global::System.Collections.Generic.IEnumerable<global::Controllable>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::Controllable.<>c__Iterator25();
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00027504 File Offset: 0x00025704
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
						this.$current = controllable;
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

		// Token: 0x0600093C RID: 2364 RVA: 0x000275F8 File Offset: 0x000257F8
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

		// Token: 0x0600093D RID: 2365 RVA: 0x00027658 File Offset: 0x00025858
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040006CA RID: 1738
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_209>__0;

		// Token: 0x040006CB RID: 1739
		internal global::PlayerClient <pc>__1;

		// Token: 0x040006CC RID: 1740
		internal global::Controllable <controllable>__2;

		// Token: 0x040006CD RID: 1741
		internal int $PC;

		// Token: 0x040006CE RID: 1742
		internal global::Controllable $current;
	}

	// Token: 0x0200014F RID: 335
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator26 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controllable>, global::System.Collections.Generic.IEnumerator<global::Controllable>
	{
		// Token: 0x0600093E RID: 2366 RVA: 0x00027660 File Offset: 0x00025860
		public <>c__Iterator26()
		{
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00027668 File Offset: 0x00025868
		global::Controllable global::System.Collections.Generic.IEnumerator<global::Controllable>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00027670 File Offset: 0x00025870
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00027678 File Offset: 0x00025878
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controllable>.GetEnumerator();
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00027680 File Offset: 0x00025880
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controllable> global::System.Collections.Generic.IEnumerable<global::Controllable>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::Controllable.<>c__Iterator26();
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0002769C File Offset: 0x0002589C
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
						this.$current = controllable;
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

		// Token: 0x06000944 RID: 2372 RVA: 0x00027790 File Offset: 0x00025990
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

		// Token: 0x06000945 RID: 2373 RVA: 0x000277F0 File Offset: 0x000259F0
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040006CF RID: 1743
		internal global::System.Collections.Generic.List<global::PlayerClient>.Enumerator <$s_210>__0;

		// Token: 0x040006D0 RID: 1744
		internal global::PlayerClient <pc>__1;

		// Token: 0x040006D1 RID: 1745
		internal global::Controllable <controllable>__2;

		// Token: 0x040006D2 RID: 1746
		internal int $PC;

		// Token: 0x040006D3 RID: 1747
		internal global::Controllable $current;
	}

	// Token: 0x02000150 RID: 336
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RootControllers>c__Iterator27 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controllable>, global::System.Collections.Generic.IEnumerator<global::Controllable>
	{
		// Token: 0x06000946 RID: 2374 RVA: 0x000277F8 File Offset: 0x000259F8
		public <RootControllers>c__Iterator27()
		{
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x00027800 File Offset: 0x00025A00
		global::Controllable global::System.Collections.Generic.IEnumerator<global::Controllable>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x00027808 File Offset: 0x00025A08
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00027810 File Offset: 0x00025A10
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controllable>.GetEnumerator();
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00027818 File Offset: 0x00025A18
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controllable> global::System.Collections.Generic.IEnumerable<global::Controllable>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Controllable.<RootControllers>c__Iterator27 <RootControllers>c__Iterator = new global::Controllable.<RootControllers>c__Iterator27();
			<RootControllers>c__Iterator.playerClients = playerClients;
			return <RootControllers>c__Iterator;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0002784C File Offset: 0x00025A4C
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
						this.$current = controllable;
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

		// Token: 0x0600094C RID: 2380 RVA: 0x00027944 File Offset: 0x00025B44
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

		// Token: 0x0600094D RID: 2381 RVA: 0x000279A8 File Offset: 0x00025BA8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040006D4 RID: 1748
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x040006D5 RID: 1749
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_211>__0;

		// Token: 0x040006D6 RID: 1750
		internal global::PlayerClient <pc>__1;

		// Token: 0x040006D7 RID: 1751
		internal global::Controllable <controllable>__2;

		// Token: 0x040006D8 RID: 1752
		internal int $PC;

		// Token: 0x040006D9 RID: 1753
		internal global::Controllable $current;

		// Token: 0x040006DA RID: 1754
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}

	// Token: 0x02000151 RID: 337
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CurrentControllers>c__Iterator28 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Controllable>, global::System.Collections.Generic.IEnumerator<global::Controllable>
	{
		// Token: 0x0600094E RID: 2382 RVA: 0x000279B0 File Offset: 0x00025BB0
		public <CurrentControllers>c__Iterator28()
		{
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x000279B8 File Offset: 0x00025BB8
		global::Controllable global::System.Collections.Generic.IEnumerator<global::Controllable>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x000279C0 File Offset: 0x00025BC0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x000279C8 File Offset: 0x00025BC8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Controllable>.GetEnumerator();
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x000279D0 File Offset: 0x00025BD0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Controllable> global::System.Collections.Generic.IEnumerable<global::Controllable>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Controllable.<CurrentControllers>c__Iterator28 <CurrentControllers>c__Iterator = new global::Controllable.<CurrentControllers>c__Iterator28();
			<CurrentControllers>c__Iterator.playerClients = playerClients;
			return <CurrentControllers>c__Iterator;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00027A04 File Offset: 0x00025C04
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
						this.$current = controllable;
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

		// Token: 0x06000954 RID: 2388 RVA: 0x00027AFC File Offset: 0x00025CFC
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

		// Token: 0x06000955 RID: 2389 RVA: 0x00027B60 File Offset: 0x00025D60
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040006DB RID: 1755
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> playerClients;

		// Token: 0x040006DC RID: 1756
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_212>__0;

		// Token: 0x040006DD RID: 1757
		internal global::PlayerClient <pc>__1;

		// Token: 0x040006DE RID: 1758
		internal global::Controllable <controllable>__2;

		// Token: 0x040006DF RID: 1759
		internal int $PC;

		// Token: 0x040006E0 RID: 1760
		internal global::Controllable $current;

		// Token: 0x040006E1 RID: 1761
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>playerClients;
	}
}
