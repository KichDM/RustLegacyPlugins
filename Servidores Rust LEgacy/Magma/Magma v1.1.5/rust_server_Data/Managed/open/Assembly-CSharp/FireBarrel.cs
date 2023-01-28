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

// Token: 0x02000781 RID: 1921
[global::NGCAutoAddScript]
public class FireBarrel : global::LootableObject, global::IServerSaveable, global::IActivatable, global::IActivatableToggle, global::IContextRequestable, global::IContextRequestableMenu, global::IContextRequestableQuick, global::IContextRequestableText, global::IContextRequestablePointText, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06003FD5 RID: 16341 RVA: 0x000E404C File Offset: 0x000E224C
	public FireBarrel()
	{
	}

	// Token: 0x06003FD6 RID: 16342 RVA: 0x000E4074 File Offset: 0x000E2274
	// Note: this type is marked as 'beforefieldinit'.
	static FireBarrel()
	{
	}

	// Token: 0x06003FD7 RID: 16343 RVA: 0x000E40A4 File Offset: 0x000E22A4
	global::ContextExecution global::IContextRequestable.ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick | global::ContextExecution.Menu;
	}

	// Token: 0x06003FD8 RID: 16344 RVA: 0x000E40A8 File Offset: 0x000E22A8
	global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> global::IContextRequestableMenu.ContextQueryMenu(global::Controllable controllable, ulong timestamp)
	{
		return this.ContextQueryMenu_FireBarrel(controllable, timestamp);
	}

	// Token: 0x06003FD9 RID: 16345 RVA: 0x000E40B4 File Offset: 0x000E22B4
	global::ContextResponse global::IContextRequestableQuick.ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		return this.ContextRespondQuick_FireBarrel(controllable, timestamp);
	}

	// Token: 0x06003FDA RID: 16346 RVA: 0x000E40C0 File Offset: 0x000E22C0
	global::ContextResponse global::IContextRequestableMenu.ContextRespondMenu(global::Controllable controllable, global::ContextActionPrototype action, ulong timestamp)
	{
		return this.ContextRespondMenu_FireBarrel(controllable, (global::FireBarrel.FireBarrelPrototype)action, timestamp);
	}

	// Token: 0x06003FDB RID: 16347 RVA: 0x000E40D0 File Offset: 0x000E22D0
	protected virtual float GetCookDuration()
	{
		return 60f;
	}

	// Token: 0x06003FDC RID: 16348 RVA: 0x000E40D8 File Offset: 0x000E22D8
	public void DecayTouch()
	{
		if (this._deployable)
		{
			this._deployable.DecayTouch();
		}
	}

	// Token: 0x06003FDD RID: 16349 RVA: 0x000E40F8 File Offset: 0x000E22F8
	public new void Awake()
	{
		base.Awake();
		this._lightPosInitial = this.fireLight.transform.localPosition;
		this._lightPosCurrent = this._lightPosInitial;
		this._lightPosTarget = this._lightPosCurrent;
		this._lightIntensityInitial = this.fireLight.intensity;
		this._deployable = base.GetComponent<global::DeployableObject>();
		foreach (global::UnityEngine.ParticleSystem particleSystem in this.emitters)
		{
			global::UnityEngine.Object.Destroy(particleSystem.gameObject);
		}
		global::UnityEngine.Object.Destroy(this.fireLight.gameObject);
		global::Facepunch.NetworkView networkView = base.networkView;
		if (networkView && networkView.viewID.isManual)
		{
			this.InitializeState();
		}
	}

	// Token: 0x06003FDE RID: 16350 RVA: 0x000E41BC File Offset: 0x000E23BC
	protected virtual void InitializeState()
	{
		this.SetOn(false);
		this.TrySetOn(this.startOn);
	}

	// Token: 0x06003FDF RID: 16351 RVA: 0x000E41D4 File Offset: 0x000E23D4
	protected override void InitializeServerState(global::uLink.NetworkMessageInfo info, bool ngc, global::UnityEngine.MonoBehaviour networkView)
	{
		base.InitializeServerState(info, ngc, networkView);
		this.InitializeState();
	}

	// Token: 0x06003FE0 RID: 16352 RVA: 0x000E41E8 File Offset: 0x000E23E8
	public void SetOn(bool on)
	{
		this.isOn = on;
		if (on)
		{
			if (this._deployable)
			{
				this._deployable.SetDecayEnabled(false);
			}
			float cookDuration = this.GetCookDuration();
			base.InvokeRepeating("ConsumeFuel", global::UnityEngine.Random.Range(cookDuration * 0.5f, cookDuration), cookDuration);
			global::EnvDecay.RefreshRadialDecay(base.transform.position, global::FireBarrel.decayResetRange);
		}
		else
		{
			base.CancelInvoke("ConsumeFuel");
			if (this._deployable)
			{
				this._deployable.SetDecayEnabled(true);
			}
		}
		this.DecayTouch();
		if (this._heatZone)
		{
			this._heatZone.SetOn(on);
		}
		this.UpdateNetState();
	}

	// Token: 0x06003FE1 RID: 16353 RVA: 0x000E42A8 File Offset: 0x000E24A8
	private void TurnOn()
	{
		this.fireLight.enabled = true;
		this.NewFlickerTarget();
	}

	// Token: 0x06003FE2 RID: 16354 RVA: 0x000E42BC File Offset: 0x000E24BC
	private void TurnOff()
	{
		if (this.fireLight)
		{
			this.fireLight.enabled = false;
			this.fireLight.intensity = 0f;
		}
	}

	// Token: 0x06003FE3 RID: 16355 RVA: 0x000E42F8 File Offset: 0x000E24F8
	private void PlayerUse(global::Controllable looter)
	{
		this.TrySetOn(!this.isOn);
	}

	// Token: 0x06003FE4 RID: 16356 RVA: 0x000E430C File Offset: 0x000E250C
	private void UpdateNetState()
	{
		global::NetEntityID entID = global::NetEntityID.Get(this);
		global::NetCull.RemoveRPCsByName(entID, "ReceiveNetState");
		global::NetCull.RPC<bool>(entID, "ReceiveNetState", 5, this.isOn);
	}

	// Token: 0x06003FE5 RID: 16357 RVA: 0x000E4340 File Offset: 0x000E2540
	[global::UnityEngine.RPC]
	protected void ReceiveNetState(bool on)
	{
	}

	// Token: 0x06003FE6 RID: 16358 RVA: 0x000E4344 File Offset: 0x000E2544
	private void NewFlickerTarget()
	{
		this._lightFlickerTarget = this._lightIntensityInitial * global::UnityEngine.Random.Range(0.75f, 1.25f);
	}

	// Token: 0x06003FE7 RID: 16359 RVA: 0x000E4364 File Offset: 0x000E2564
	public virtual bool HasFuel()
	{
		return this.FindFuel() != null;
	}

	// Token: 0x06003FE8 RID: 16360 RVA: 0x000E4374 File Offset: 0x000E2574
	public global::IFlammableItem FindFuel()
	{
		foreach (global::IFlammableItem flammableItem in this._inventory.FindItems<global::IFlammableItem>())
		{
			if (flammableItem.flammable)
			{
				return flammableItem;
			}
		}
		return null;
	}

	// Token: 0x06003FE9 RID: 16361 RVA: 0x000E43EC File Offset: 0x000E25EC
	public void InvItemAdded()
	{
		this.DecayTouch();
	}

	// Token: 0x06003FEA RID: 16362 RVA: 0x000E43F4 File Offset: 0x000E25F4
	public void InvItemRemoved()
	{
		this.DecayTouch();
		base.CancelInvoke("FuelRemoveCheck");
		base.Invoke("FuelRemoveCheck", 0.25f);
	}

	// Token: 0x06003FEB RID: 16363 RVA: 0x000E4418 File Offset: 0x000E2618
	public virtual void ConsumeFuel()
	{
		global::IFlammableItem flammableItem = this.FindFuel();
		if (flammableItem == null)
		{
			this.SetOn(false);
		}
		else
		{
			int num = 1;
			bool flag;
			if (flammableItem.Consume(ref num))
			{
				flag = true;
				flammableItem.inventory.RemoveItem(flammableItem.slot);
			}
			else
			{
				flag = false;
			}
			this._inventory.AddItem(ref global::FireBarrel.DefaultItems.byProduct, 7, 3);
			global::EnvDecay.RefreshRadialDecay(base.transform.position, global::FireBarrel.decayResetRange);
			for (int i = 3; i < 6; i++)
			{
				if (!this._inventory.IsSlotFree(i))
				{
					global::IInventoryItem inventoryItem;
					if (this._inventory.GetItem(i, out inventoryItem))
					{
						if (inventoryItem is global::ICookableItem)
						{
							global::ICookableItem cookableItem = inventoryItem as global::ICookableItem;
							int num2;
							global::ItemDataBlock itemDataBlock;
							int num3;
							int num4;
							int num5;
							if (cookableItem != null && cookableItem.GetCookableInfo(out num2, out itemDataBlock, out num3, out num4, out num5) && (num3 <= 0 || itemDataBlock) && cookableItem.uses >= num2 && this.myTemp >= num4)
							{
								if (cookableItem.Consume(ref num2))
								{
									this._inventory.RemoveItem(cookableItem.slot);
								}
								if (num3 > 0)
								{
									this._inventory.AddItem(itemDataBlock, i - 3, num3);
								}
							}
						}
					}
				}
			}
			bool flag2 = false;
			for (int j = 0; j < 3; j++)
			{
				if (!this._inventory.IsSlotFree(j))
				{
					global::IInventoryItem inventoryItem2;
					this._inventory.GetItem(j, out inventoryItem2);
					if (inventoryItem2.uses == inventoryItem2.datablock._maxUses)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (!flag2 && this._inventory.IsSlotOccupied(7))
			{
				global::IInventoryItem inventoryItem3;
				this._inventory.GetItem(7, out inventoryItem3);
				if (inventoryItem3.uses == inventoryItem3.datablock._maxUses)
				{
					flag2 = true;
				}
			}
			if ((flag && !this.HasFuel()) || flag2)
			{
				this.SetOn(false);
			}
			this.DecayTouch();
		}
	}

	// Token: 0x06003FEC RID: 16364 RVA: 0x000E4650 File Offset: 0x000E2850
	public void FuelRemoveCheck()
	{
		if (!this.HasFuel())
		{
			this.SetOn(false);
		}
	}

	// Token: 0x06003FED RID: 16365 RVA: 0x000E4664 File Offset: 0x000E2864
	protected global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> ContextQueryMenu_FireBarrel(global::Controllable controllable, ulong timestamp)
	{
		if (this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned)
		{
			if (this.isOn)
			{
				yield return global::FireBarrel.optionExtinguish;
			}
			else if (this.HasFuel())
			{
				yield return global::FireBarrel.optionIgnite;
			}
			yield return global::FireBarrel.optionOpen;
		}
		yield break;
	}

	// Token: 0x06003FEE RID: 16366 RVA: 0x000E4688 File Offset: 0x000E2888
	protected global::ContextResponse ContextRespondQuick_FireBarrel(global::Controllable controllable, ulong timestamp)
	{
		if (this.isOn)
		{
			return this.ContextRespond_SetFireBarrelOn(controllable, timestamp, false);
		}
		if (this.HasFuel())
		{
			return this.ContextRespond_SetFireBarrelOn(controllable, timestamp, true);
		}
		return this.ContextRespond_OpenLoot(controllable, timestamp);
	}

	// Token: 0x06003FEF RID: 16367 RVA: 0x000E46C8 File Offset: 0x000E28C8
	public virtual void TrySetOn(bool on)
	{
		if (on && !this.HasFuel())
		{
			on = false;
		}
		this.SetOn(on);
	}

	// Token: 0x06003FF0 RID: 16368 RVA: 0x000E46E8 File Offset: 0x000E28E8
	protected override global::ContextResponse ContextRespond_OpenLoot(global::Controllable controllable, ulong timestamp)
	{
		global::ContextResponse contextResponse = base.ContextRespond_OpenLoot(controllable, timestamp);
		global::ContextResponse contextResponse2 = contextResponse;
		if (contextResponse2 == global::ContextResponse.DoneBreak || contextResponse2 == global::ContextResponse.DoneContinue)
		{
			this.DecayTouch();
		}
		return contextResponse;
	}

	// Token: 0x06003FF1 RID: 16369 RVA: 0x000E4720 File Offset: 0x000E2920
	protected global::ContextResponse ContextRespond_SetFireBarrelOn(global::Controllable controllable, ulong timestamp, bool turnOn)
	{
		if (this.isOn == turnOn)
		{
			return global::ContextResponse.DoneBreak;
		}
		if (this.isOn && !this.HasFuel())
		{
			global::Rust.Notice.Popup(controllable.netPlayer, "", "No fuel (add wood first)", 4f);
			return global::ContextResponse.FailBreak;
		}
		this.TrySetOn(!this.isOn);
		if (this.isOn != turnOn)
		{
			return global::ContextResponse.DoneBreak;
		}
		return global::ContextResponse.FailBreak;
	}

	// Token: 0x06003FF2 RID: 16370 RVA: 0x000E478C File Offset: 0x000E298C
	protected global::ContextResponse ContextRespondMenu_FireBarrel(global::Controllable controllable, global::FireBarrel.FireBarrelPrototype action, ulong timestamp)
	{
		bool flag = action == global::FireBarrel.optionIgnite;
		if (flag || action == global::FireBarrel.optionExtinguish)
		{
			return this.ContextRespond_SetFireBarrelOn(controllable, timestamp, flag);
		}
		if (action == global::FireBarrel.optionOpen)
		{
			return this.ContextRespond_OpenLoot(controllable, timestamp);
		}
		return global::ContextResponse.FailBreak;
	}

	// Token: 0x06003FF3 RID: 16371 RVA: 0x000E47D4 File Offset: 0x000E29D4
	public override string ContextText(global::Controllable localControllable)
	{
		if (this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned)
		{
			return "Use";
		}
		if (this.occupierText == null)
		{
			global::PlayerClient playerClient;
			if (!global::PlayerClient.Find(this._currentlyUsingPlayer, out playerClient))
			{
				this.occupierText = "Occupied";
			}
			else
			{
				this.occupierText = string.Format("Occupied by {0}", playerClient.userName);
			}
		}
		return this.occupierText;
	}

	// Token: 0x06003FF4 RID: 16372 RVA: 0x000E4848 File Offset: 0x000E2A48
	public override bool ContextTextPoint(out global::UnityEngine.Vector3 worldPoint)
	{
		global::ContextRequestable.PointUtil.SpriteOrOrigin(this, out worldPoint);
		return true;
	}

	// Token: 0x06003FF5 RID: 16373 RVA: 0x000E4854 File Offset: 0x000E2A54
	public global::ActivationResult ActTrigger(global::Character instigator, global::ActivationToggleState toggleTarget, ulong timestamp)
	{
		if (toggleTarget != global::ActivationToggleState.On)
		{
			if (toggleTarget != global::ActivationToggleState.Off)
			{
				return global::ActivationResult.Fail_BadToggle;
			}
			if (!this.isOn)
			{
				return global::ActivationResult.Fail_Redundant;
			}
			this.PlayerUse(null);
			return (!this.isOn) ? global::ActivationResult.Success : global::ActivationResult.Fail_Busy;
		}
		else
		{
			if (this.isOn)
			{
				return global::ActivationResult.Fail_Redundant;
			}
			this.PlayerUse(null);
			return (!this.isOn) ? global::ActivationResult.Fail_Busy : global::ActivationResult.Success;
		}
	}

	// Token: 0x06003FF6 RID: 16374 RVA: 0x000E48C8 File Offset: 0x000E2AC8
	public global::ActivationToggleState ActGetToggleState()
	{
		return (!this.isOn) ? global::ActivationToggleState.Off : global::ActivationToggleState.On;
	}

	// Token: 0x06003FF7 RID: 16375 RVA: 0x000E48DC File Offset: 0x000E2ADC
	public global::ActivationResult ActTrigger(global::Character instigator, ulong timestamp)
	{
		return this.ActTrigger(instigator, (!this.isOn) ? global::ActivationToggleState.On : global::ActivationToggleState.Off, timestamp);
	}

	// Token: 0x06003FF8 RID: 16376 RVA: 0x000E48F8 File Offset: 0x000E2AF8
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder> recycler = global::RustProto.objectFireBarrel.Recycler())
		{
			global::RustProto.objectFireBarrel.Builder builder = recycler.OpenBuilder();
			builder.SetOnFire(this.isOn);
			saveobj.SetFireBarrel(builder);
		}
	}

	// Token: 0x06003FF9 RID: 16377 RVA: 0x000E4958 File Offset: 0x000E2B58
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (!saveobj.HasFireBarrel)
		{
			return;
		}
		this.SetOn(saveobj.FireBarrel.OnFire);
	}

	// Token: 0x0400213F RID: 8511
	public global::UnityEngine.Light fireLight;

	// Token: 0x04002140 RID: 8512
	public global::UnityEngine.ParticleSystem[] emitters;

	// Token: 0x04002141 RID: 8513
	public bool isOn;

	// Token: 0x04002142 RID: 8514
	public bool startOn;

	// Token: 0x04002143 RID: 8515
	private global::UnityEngine.Vector3 _lightPosInitial;

	// Token: 0x04002144 RID: 8516
	private global::UnityEngine.Vector3 _lightPosCurrent;

	// Token: 0x04002145 RID: 8517
	private global::UnityEngine.Vector3 _lightPosTarget;

	// Token: 0x04002146 RID: 8518
	private float _lightFlickerTarget = 1f;

	// Token: 0x04002147 RID: 8519
	private float _lightIntensityInitial = 1f;

	// Token: 0x04002148 RID: 8520
	public global::HeatZone _heatZone;

	// Token: 0x04002149 RID: 8521
	public static float decayResetRange = 5f;

	// Token: 0x0400214A RID: 8522
	private global::DeployableObject _deployable;

	// Token: 0x0400214B RID: 8523
	public int myTemp = 1;

	// Token: 0x0400214C RID: 8524
	private static readonly global::FireBarrel.FireBarrelPrototype optionIgnite = new global::FireBarrel.FireBarrelPrototype(global::FireBarrel.FireBarrelAction.Ignite);

	// Token: 0x0400214D RID: 8525
	private static readonly global::FireBarrel.FireBarrelPrototype optionExtinguish = new global::FireBarrel.FireBarrelPrototype(global::FireBarrel.FireBarrelAction.Extinguish);

	// Token: 0x0400214E RID: 8526
	private static readonly global::FireBarrel.FireBarrelPrototype optionOpen = new global::FireBarrel.FireBarrelPrototype(global::FireBarrel.FireBarrelAction.Open);

	// Token: 0x02000782 RID: 1922
	public static class DefaultItems
	{
		// Token: 0x06003FFA RID: 16378 RVA: 0x000E4984 File Offset: 0x000E2B84
		// Note: this type is marked as 'beforefieldinit'.
		static DefaultItems()
		{
		}

		// Token: 0x0400214F RID: 8527
		public static global::Datablock.Ident fuel = "Wood";

		// Token: 0x04002150 RID: 8528
		public static global::Datablock.Ident byProduct = "Charcoal";
	}

	// Token: 0x02000783 RID: 1923
	protected enum FireBarrelAction
	{
		// Token: 0x04002152 RID: 8530
		Ignite,
		// Token: 0x04002153 RID: 8531
		Extinguish,
		// Token: 0x04002154 RID: 8532
		Open
	}

	// Token: 0x02000784 RID: 1924
	protected class FireBarrelPrototype : global::ContextActionPrototype
	{
		// Token: 0x06003FFB RID: 16379 RVA: 0x000E49A4 File Offset: 0x000E2BA4
		public FireBarrelPrototype(global::FireBarrel.FireBarrelAction action)
		{
			this.name = (int)action;
			this.text = action.ToString();
			this.action = action;
		}

		// Token: 0x04002155 RID: 8533
		public global::FireBarrel.FireBarrelAction action;
	}

	// Token: 0x02000785 RID: 1925
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <ContextQueryMenu_FireBarrel>c__IteratorB : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>, global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>
	{
		// Token: 0x06003FFC RID: 16380 RVA: 0x000E49CC File Offset: 0x000E2BCC
		public <ContextQueryMenu_FireBarrel>c__IteratorB()
		{
		}

		// Token: 0x17000BF5 RID: 3061
		// (get) Token: 0x06003FFD RID: 16381 RVA: 0x000E49D4 File Offset: 0x000E2BD4
		global::ContextActionPrototype global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BF6 RID: 3062
		// (get) Token: 0x06003FFE RID: 16382 RVA: 0x000E49DC File Offset: 0x000E2BDC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003FFF RID: 16383 RVA: 0x000E49E4 File Offset: 0x000E2BE4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<ContextActionPrototype>.GetEnumerator();
		}

		// Token: 0x06004000 RID: 16384 RVA: 0x000E49EC File Offset: 0x000E2BEC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype> global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::FireBarrel.<ContextQueryMenu_FireBarrel>c__IteratorB <ContextQueryMenu_FireBarrel>c__IteratorB = new global::FireBarrel.<ContextQueryMenu_FireBarrel>c__IteratorB();
			<ContextQueryMenu_FireBarrel>c__IteratorB.<>f__this = this;
			return <ContextQueryMenu_FireBarrel>c__IteratorB;
		}

		// Token: 0x06004001 RID: 16385 RVA: 0x000E4A20 File Offset: 0x000E2C20
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (!(this._currentlyUsingPlayer == global::uLink.NetworkPlayer.unassigned))
				{
					goto IL_AD;
				}
				if (this.isOn)
				{
					this.$current = global::FireBarrel.optionExtinguish;
					this.$PC = 1;
					return true;
				}
				if (this.HasFuel())
				{
					this.$current = global::FireBarrel.optionIgnite;
					this.$PC = 2;
					return true;
				}
				break;
			case 1U:
				break;
			case 2U:
				break;
			case 3U:
				goto IL_AD;
			default:
				return false;
			}
			this.$current = global::FireBarrel.optionOpen;
			this.$PC = 3;
			return true;
			IL_AD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x06004002 RID: 16386 RVA: 0x000E4AE8 File Offset: 0x000E2CE8
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004003 RID: 16387 RVA: 0x000E4AF4 File Offset: 0x000E2CF4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002156 RID: 8534
		internal int $PC;

		// Token: 0x04002157 RID: 8535
		internal global::ContextActionPrototype $current;

		// Token: 0x04002158 RID: 8536
		internal global::FireBarrel <>f__this;
	}
}
