using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uLink;
using UnityEngine;

// Token: 0x020000AC RID: 172
public sealed class ClientVitalsSync : global::IDLocalCharacterAddon, global::IInterpTimedEventReceiver
{
	// Token: 0x0600035B RID: 859 RVA: 0x000101B8 File Offset: 0x0000E3B8
	public ClientVitalsSync() : this(global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake | global::IDLocalCharacterAddon.AddonFlags.PrerequisitCheck)
	{
	}

	// Token: 0x0600035C RID: 860 RVA: 0x000101C4 File Offset: 0x0000E3C4
	protected ClientVitalsSync(global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags)
	{
	}

	// Token: 0x0600035D RID: 861 RVA: 0x000101D0 File Offset: 0x0000E3D0
	void global::IInterpTimedEventReceiver.OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::ClientVitalsSync.<>f__switch$map2 == null)
			{
				global::ClientVitalsSync.<>f__switch$map2 = new global::System.Collections.Generic.Dictionary<string, int>(1)
				{
					{
						"DMG",
						0
					}
				};
			}
			int num;
			if (global::ClientVitalsSync.<>f__switch$map2.TryGetValue(tag, out num))
			{
				if (num == 0)
				{
					this.ClientHealthChange(global::InterpTimedEvent.Argument<float>(0), global::InterpTimedEvent.Argument<global::UnityEngine.GameObject>(1));
					return;
				}
			}
		}
		global::InterpTimedEvent.MarkUnhandled();
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0001024C File Offset: 0x0000E44C
	protected override bool CheckPrerequesits()
	{
		this.humanBodyTakeDamage = (base.takeDamage as global::HumanBodyTakeDamage);
		return this.humanBodyTakeDamage && base.networkViewOwner.isClient;
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0001028C File Offset: 0x0000E48C
	protected override void OnAddonPostAwake()
	{
		if (this.humanBodyTakeDamage)
		{
			this.lastKnownNetworkedHealth = new float?(this.humanBodyTakeDamage.health);
			this.SendClientItsHealth();
			this.BleedingLevelChanged(this.humanBodyTakeDamage._bleedingLevel);
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000360 RID: 864 RVA: 0x000102CC File Offset: 0x0000E4CC
	public bool bleeding
	{
		get
		{
			return this.humanBodyTakeDamage && this.humanBodyTakeDamage.IsBleeding();
		}
	}

	// Token: 0x06000361 RID: 865 RVA: 0x000102EC File Offset: 0x0000E4EC
	[global::UnityEngine.RPC]
	public void Local_HealthChange(float amount, global::uLink.NetworkViewID attackerID, global::uLink.NetworkMessageInfo info)
	{
		global::uLink.NetworkView networkView;
		global::UnityEngine.GameObject gameObject;
		if (attackerID != global::uLink.NetworkViewID.unassigned && (networkView = global::uLink.NetworkView.Find(attackerID)))
		{
			gameObject = networkView.gameObject;
		}
		else
		{
			gameObject = null;
		}
		global::InterpTimedEvent.Queue(this, "DMG", ref info, new object[]
		{
			amount,
			gameObject
		});
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0001034C File Offset: 0x0000E54C
	[global::UnityEngine.RPC]
	public void Local_BleedChange(float amount)
	{
		if (this.humanBodyTakeDamage)
		{
			this.humanBodyTakeDamage._bleedingLevel = amount;
		}
		if (base.localControlled)
		{
			global::RPOS.SetPlaqueActive("PlaqueBleeding", this.humanBodyTakeDamage._bleedingLevel > 0f);
		}
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0001039C File Offset: 0x0000E59C
	public void ClientHealthChange(float amount, global::UnityEngine.GameObject attacker)
	{
		float health = base.health;
		base.AdjustClientSideHealth(amount);
		float num = global::UnityEngine.Mathf.Abs(amount - health);
		bool flag = amount < health;
		float healthFraction = base.healthFraction;
		global::RPOS.HealthUpdate(amount);
	}

	// Token: 0x06000364 RID: 868 RVA: 0x000103D8 File Offset: 0x0000E5D8
	public void ServerFrame()
	{
		if (this.humanBodyTakeDamage)
		{
			this.humanBodyTakeDamage.ServerFrame();
		}
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000103F8 File Offset: 0x0000E5F8
	public void SendClientItsHealth()
	{
		this.SendClientItsHealth(global::uLink.NetworkViewID.unassigned);
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00010408 File Offset: 0x0000E608
	public void SendClientItsHealth(global::uLink.NetworkViewID attacker)
	{
		float? num = this.lastKnownNetworkedHealth;
		float health = base.health;
		if (global::NetCheck.PlayerValid(base.networkView.owner))
		{
			base.networkView.RPC("Local_HealthChange", base.networkView.owner, new object[]
			{
				health,
				attacker
			});
		}
		float valueOrDefault = num.GetValueOrDefault();
		float? num2 = this.lastKnownNetworkedHealth;
		if (valueOrDefault != num2.GetValueOrDefault() || (num != null ^ num2 != null) || health != base.health)
		{
			global::UnityEngine.Debug.LogError("Something messed up", this);
		}
		else
		{
			this.lastKnownNetworkedHealth = new float?(health);
		}
	}

	// Token: 0x06000367 RID: 871 RVA: 0x000104C4 File Offset: 0x0000E6C4
	public void BleedingLevelChanged(float amount)
	{
		base.networkView.RPC<float>("Local_BleedChange", base.networkView.owner, amount);
	}

	// Token: 0x06000368 RID: 872 RVA: 0x000104F0 File Offset: 0x0000E6F0
	public void OnHurt(global::DamageEvent damage)
	{
		float num = global::UnityEngine.Mathf.Max(0f, base.health);
		if (this.lastKnownNetworkedHealth == null || (num == 0f && this.lastKnownNetworkedHealth.Value != 0f) || global::UnityEngine.Mathf.RoundToInt(this.lastKnownNetworkedHealth.Value) - global::UnityEngine.Mathf.RoundToInt(num) != 0)
		{
			this.SendClientItsHealth(damage.attacker.networkViewID);
		}
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0001056C File Offset: 0x0000E76C
	protected void OnRepair()
	{
		this.SendClientItsHealth();
	}

	// Token: 0x04000305 RID: 773
	private const global::IDLocalCharacterAddon.AddonFlags ClientVitalsSyncAddonFlags = global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake | global::IDLocalCharacterAddon.AddonFlags.PrerequisitCheck;

	// Token: 0x04000306 RID: 774
	[global::System.NonSerialized]
	private global::HumanBodyTakeDamage humanBodyTakeDamage;

	// Token: 0x04000307 RID: 775
	[global::System.NonSerialized]
	private float? lastKnownNetworkedHealth;

	// Token: 0x04000308 RID: 776
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map2;
}
