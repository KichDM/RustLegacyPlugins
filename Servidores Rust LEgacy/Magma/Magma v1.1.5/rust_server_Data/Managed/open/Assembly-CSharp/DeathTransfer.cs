using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x020000AE RID: 174
public sealed class DeathTransfer : global::IDLocalCharacterAddon, global::IInterpTimedEventReceiver
{
	// Token: 0x0600036C RID: 876 RVA: 0x0001058C File Offset: 0x0000E78C
	public DeathTransfer() : this((global::IDLocalCharacterAddon.AddonFlags)0)
	{
	}

	// Token: 0x0600036D RID: 877 RVA: 0x00010598 File Offset: 0x0000E798
	protected DeathTransfer(global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags)
	{
	}

	// Token: 0x0600036E RID: 878 RVA: 0x000105A4 File Offset: 0x0000E7A4
	void global::IInterpTimedEventReceiver.OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::DeathTransfer.<>f__switch$map3 == null)
			{
				global::DeathTransfer.<>f__switch$map3 = new global::System.Collections.Generic.Dictionary<string, int>(2)
				{
					{
						"ClientLocalDeath",
						0
					},
					{
						"RAG",
						1
					}
				};
			}
			int num;
			if (global::DeathTransfer.<>f__switch$map3.TryGetValue(tag, out num))
			{
				if (num == 0)
				{
					return;
				}
				if (num == 1)
				{
					return;
				}
			}
		}
		global::InterpTimedEvent.MarkUnhandled();
	}

	// Token: 0x0600036F RID: 879 RVA: 0x00010624 File Offset: 0x0000E824
	[global::UnityEngine.RPC]
	protected void Client_OnKilled(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06000370 RID: 880 RVA: 0x00010628 File Offset: 0x0000E828
	[global::UnityEngine.RPC]
	protected void Client_OnKilledBy(global::uLink.NetworkViewID attackerViewID, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0001062C File Offset: 0x0000E82C
	[global::UnityEngine.RPC]
	protected void Client_OnKilledShot(global::UnityEngine.Vector3 point, global::Angle2 normal, byte bodyPart, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06000372 RID: 882 RVA: 0x00010630 File Offset: 0x0000E830
	[global::UnityEngine.RPC]
	protected void Client_OnKilledShotBy(global::uLink.NetworkViewID attackerViewID, global::UnityEngine.Vector3 point, global::Angle2 normal, byte bodyPart, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06000373 RID: 883 RVA: 0x00010634 File Offset: 0x0000E834
	public void SetDeathReason(ref global::DamageEvent damage)
	{
		if (!base.playerClient)
		{
			return;
		}
		if (!global::NetCheck.PlayerValid(base.playerClient.netPlayer))
		{
			return;
		}
		global::IDMain idMain = damage.attacker.idMain;
		if (idMain)
		{
			idMain = idMain.idMain;
		}
		if (idMain is global::Character)
		{
			global::Character character = idMain as global::Character;
			global::Controller playerControlledController = character.playerControlledController;
			if (playerControlledController)
			{
				if (playerControlledController.playerClient == base.playerClient)
				{
					global::DeathScreen.SetReason(base.playerClient.netPlayer, "You killed yourself. You silly sod.");
					return;
				}
				global::WeaponImpact weaponImpact = damage.extraData as global::WeaponImpact;
				if (weaponImpact != null)
				{
					global::DeathScreen.SetReason(base.playerClient.netPlayer, string.Concat(new string[]
					{
						playerControlledController.playerClient.userName,
						" killed you using a ",
						weaponImpact.dataBlock.name,
						" with a hit to your ",
						global::BodyParts.GetNiceName(damage.bodyPart)
					}));
					return;
				}
				global::DeathScreen.SetReason(base.playerClient.netPlayer, playerControlledController.playerClient.userName + " killed you with a hit to your " + global::BodyParts.GetNiceName(damage.bodyPart));
				return;
			}
		}
		global::DeathScreen.SetReason(base.playerClient.netPlayer, "TODO: Handle this death condition " + idMain.ToString());
	}

	// Token: 0x06000374 RID: 884 RVA: 0x00010790 File Offset: 0x0000E990
	public void NetworkKill(ref global::DamageEvent damage)
	{
		global::NetEntityID netEntityID;
		if ((int)global::NetEntityID.Of(this, out netEntityID) == 0)
		{
			return;
		}
		this.SetDeathReason(ref damage);
		global::IDMain idMain = damage.attacker.idMain;
		if (idMain)
		{
			idMain = idMain.idMain;
		}
		global::uLink.NetworkViewID networkViewID = global::uLink.NetworkViewID.unassigned;
		bool flag = idMain is global::Character;
		bool flag2;
		if (flag)
		{
			global::Facepunch.NetworkView networkView = ((global::Character)idMain).networkView;
			if (networkView)
			{
				networkViewID = networkView.viewID;
				flag2 = (networkViewID != global::uLink.NetworkViewID.unassigned);
			}
			else
			{
				flag2 = false;
			}
		}
		else
		{
			flag2 = false;
		}
		if (damage.extraData is global::BulletWeaponImpact)
		{
			global::BulletWeaponImpact bulletWeaponImpact = (global::BulletWeaponImpact)damage.extraData;
			if (flag2)
			{
				global::NetCull.RPC<global::uLink.NetworkViewID, global::UnityEngine.Vector3, global::Angle2, byte>(this, "Client_OnKilledShotBy", 1, networkViewID, bulletWeaponImpact.localPoint, (global::Angle2)bulletWeaponImpact.localDirection, damage.bodyPart);
			}
			else
			{
				global::NetCull.RPC<global::UnityEngine.Vector3, global::Angle2, byte>(this, "Client_OnKilledShot", 1, bulletWeaponImpact.localPoint, (global::Angle2)bulletWeaponImpact.localDirection, damage.bodyPart);
			}
		}
		else if (flag2)
		{
			global::NetCull.RPC<global::uLink.NetworkViewID>(this, "Client_OnKilledBy", 1, networkViewID);
		}
		else
		{
			global::NetCull.RPC(this, "Client_OnKilled", 1);
		}
	}

	// Token: 0x0400030A RID: 778
	private const global::IDLocalCharacterAddon.AddonFlags DeathTransferAddonFlags = (global::IDLocalCharacterAddon.AddonFlags)0;

	// Token: 0x0400030B RID: 779
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map3;
}
