using System;
using System.Collections.Generic;
using Magma;
using POSIX;
using Rust;
using Rust.Steam;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000760 RID: 1888
public class RustServerManagement : global::ServerManagement
{
	// Token: 0x06003EE2 RID: 16098 RVA: 0x000DFFA4 File Offset: 0x000DE1A4
	public RustServerManagement()
	{
	}

	// Token: 0x06003EE3 RID: 16099 RVA: 0x000DFFB8 File Offset: 0x000DE1B8
	public new static global::RustServerManagement Get()
	{
		return (global::RustServerManagement)global::ServerManagement.Get();
	}

	// Token: 0x06003EE4 RID: 16100 RVA: 0x000DFFC4 File Offset: 0x000DE1C4
	protected override void OnServerWillDestroy(ref global::ServerManagement.PreServerDestroyArgs obj)
	{
		global::StructureComponent structureComponent;
		if (obj.Main<global::StructureComponent>(out structureComponent))
		{
			structureComponent.OnWillBeDestroyedOnServer();
		}
		global::TransCarrier transCarrier;
		if (obj.Local<global::TransCarrier>(out transCarrier))
		{
			transCarrier.DropObjects(true);
		}
		global::UnityEngine.Object.Destroy(obj.Local<global::TransCarrier>());
	}

	// Token: 0x06003EE5 RID: 16101 RVA: 0x000E0004 File Offset: 0x000DE204
	public override void AddPlayerSpawn(global::UnityEngine.GameObject spawn)
	{
		global::DeployableObject component = spawn.GetComponent<global::DeployableObject>();
		this.playerSpawns.Add(component);
	}

	// Token: 0x06003EE6 RID: 16102 RVA: 0x000E0024 File Offset: 0x000DE224
	public override void RemovePlayerSpawn(global::UnityEngine.GameObject spawn)
	{
		global::DeployableObject component = spawn.GetComponent<global::DeployableObject>();
		this.playerSpawns.Remove(component);
	}

	// Token: 0x06003EE7 RID: 16103 RVA: 0x000E0048 File Offset: 0x000DE248
	public override void GetCampSpawnForPlayer(global::PlayerClient playerFor, out global::UnityEngine.Vector3 spawnPos, out global::UnityEngine.Quaternion spawnRot)
	{
		global::NetUser netUser = global::NetUser.Find(playerFor.netPlayer);
		if (netUser != null)
		{
			for (int i = this.playerSpawns.Count - 1; i >= 0; i--)
			{
				global::DeployableObject deployableObject = this.playerSpawns[i];
				if (deployableObject.ownerID == netUser.user.Userid)
				{
					global::DeployedRespawn component = deployableObject.GetComponent<global::DeployedRespawn>();
					if (!component || component.IsValidToSpawn())
					{
						spawnPos = component.GetSpawnPos() + new global::UnityEngine.Vector3(0f, 0.25f, 0f);
						spawnRot = component.GetSpawnRot();
						if (component)
						{
							component.MarkSpawnedOn();
						}
						return;
					}
				}
			}
		}
		global::SpawnManager.GetRandomSpawn(out spawnPos, out spawnRot);
	}

	// Token: 0x06003EE8 RID: 16104 RVA: 0x000E0114 File Offset: 0x000DE314
	private bool GetHumanAvatarSaveRestore(global::Character forCharacter, out global::AvatarSaveRestore avatar)
	{
		global::Controller controller = forCharacter.controller;
		if (controller is global::HumanController)
		{
			avatar = controller.GetComponent<global::AvatarSaveRestore>();
			return avatar;
		}
		avatar = null;
		return false;
	}

	// Token: 0x06003EE9 RID: 16105 RVA: 0x000E0148 File Offset: 0x000DE348
	protected override void LoadAvatar(global::Character forCharacter)
	{
		global::AvatarSaveRestore avatarSaveRestore;
		if (this.GetHumanAvatarSaveRestore(forCharacter, out avatarSaveRestore))
		{
			avatarSaveRestore.LoadAvatar();
		}
	}

	// Token: 0x06003EEA RID: 16106 RVA: 0x000E016C File Offset: 0x000DE36C
	protected override void ClearAvatar(global::Character forCharacter)
	{
		global::AvatarSaveRestore avatarSaveRestore;
		if (this.GetHumanAvatarSaveRestore(forCharacter, out avatarSaveRestore))
		{
			avatarSaveRestore.ClearAvatar();
		}
	}

	// Token: 0x06003EEB RID: 16107 RVA: 0x000E0190 File Offset: 0x000DE390
	protected override void SaveAvatar(global::Character forCharacter)
	{
		global::AvatarSaveRestore avatarSaveRestore;
		if (this.GetHumanAvatarSaveRestore(forCharacter, out avatarSaveRestore))
		{
			avatarSaveRestore.SaveAvatar();
		}
	}

	// Token: 0x06003EEC RID: 16108 RVA: 0x000E01B4 File Offset: 0x000DE3B4
	protected override void ShutdownAvatar(global::Character character)
	{
		global::AvatarSaveRestore avatarSaveRestore;
		if (this.GetHumanAvatarSaveRestore(character, out avatarSaveRestore))
		{
			try
			{
				if (global::SleepingAvatar.Open(character))
				{
					avatarSaveRestore.SetAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType.SLUMBER);
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, character);
			}
			avatarSaveRestore.ShutdownAvatar(true);
		}
	}

	// Token: 0x06003EED RID: 16109 RVA: 0x000E0218 File Offset: 0x000DE418
	public override void UpdateConnectingUserAvatar(global::NetUser user, ref global::RustProto.Avatar avatar)
	{
		base.UpdateConnectingUserAvatar(user, ref avatar);
		global::SleepingAvatar.TransientData transientData = global::SleepingAvatar.Close(user);
		if (transientData.exists)
		{
			try
			{
				if (avatar.HasAwayEvent)
				{
					global::RustServerManagement.AwayFormatters.Issue(user, avatar.AwayEvent);
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
			transientData.AdjustIncomingAvatar(ref avatar);
		}
	}

	// Token: 0x06003EEE RID: 16110 RVA: 0x000E0290 File Offset: 0x000DE490
	public bool TeleportPlayerToPlayer(global::uLink.NetworkPlayer move, global::uLink.NetworkPlayer to)
	{
		global::UnityEngine.Vector3 worldPoint;
		return global::ServerManagement.GetOrigin(to, true, out worldPoint) && this.TeleportPlayerToWorld(move, worldPoint);
	}

	// Token: 0x06003EEF RID: 16111 RVA: 0x000E02B8 File Offset: 0x000DE4B8
	public bool TeleportPlayerToWorld(global::uLink.NetworkPlayer move, global::UnityEngine.Vector3 worldPoint)
	{
		global::NetUser netUser = global::NetUser.Find(move);
		if (netUser != null)
		{
			netUser.truthDetector.NoteTeleported(worldPoint, 2.0);
		}
		global::PlayerClient playerClient;
		if (base.GetPlayerClient(move, out playerClient) && playerClient.controllable)
		{
			base.networkView.RPC<global::UnityEngine.Vector3>("UnstickMove", move, worldPoint);
			return true;
		}
		return false;
	}

	// Token: 0x06003EF0 RID: 16112 RVA: 0x000E031C File Offset: 0x000DE51C
	public void KickAllPlayers()
	{
		global::uLink.NetworkPlayer[] connections = global::NetCull.connections;
		int num = 0x1F4;
		do
		{
			for (int i = 0; i < connections.Length; i++)
			{
				if (!connections[i].isServer)
				{
					global::NetUser netUser = global::NetUser.Find(connections[i]);
					if (netUser != null)
					{
						netUser.Kick(global::NetError.Facepunch_Kick_ServerRestarting, true);
					}
					else
					{
						global::NetCull.CloseConnection(connections[i], true);
					}
				}
			}
		}
		while ((connections = global::NetCull.connections).Length > 1 || --num == 0);
	}

	// Token: 0x06003EF1 RID: 16113 RVA: 0x000E03B0 File Offset: 0x000DE5B0
	public override void OnUserConnected(global::NetUser User)
	{
		if (global::Magma.Hooks.PlayerConnect(User))
		{
			base.OnUserConnected(User);
			this.UpdateModdedStatus();
		}
	}

	// Token: 0x06003EF2 RID: 16114 RVA: 0x000E03CC File Offset: 0x000DE5CC
	protected void uLink_OnServerUninitialized()
	{
		global::Rust.Steam.Server.Shutdown();
	}

	// Token: 0x06003EF3 RID: 16115 RVA: 0x000E03D4 File Offset: 0x000DE5D4
	public override void TeleportPlayer(global::uLink.NetworkPlayer move, global::UnityEngine.Vector3 worldPoint)
	{
		global::NetUser netUser = global::NetUser.Find(move);
		if (netUser != null)
		{
			netUser.truthDetector.NoteTeleported(worldPoint, 2.0);
		}
		base.networkView.RPC<global::UnityEngine.Vector3>("UnstickMove", move, worldPoint);
	}

	// Token: 0x06003EF4 RID: 16116 RVA: 0x000E0418 File Offset: 0x000DE618
	public void UpdateModdedStatus()
	{
		if (!false && global::server.pvp && global::sleepers.on && !global::crafting.instant && global::crafting.timescale == 1f && global::falldamage.enabled)
		{
			return;
		}
		global::Rust.Steam.Server.SetModded();
	}

	// Token: 0x04002064 RID: 8292
	[global::System.NonSerialized]
	public global::System.Collections.Generic.List<global::DeployableObject> playerSpawns = new global::System.Collections.Generic.List<global::DeployableObject>();

	// Token: 0x02000761 RID: 1889
	private static class AwayFormatters
	{
		// Token: 0x06003EF5 RID: 16117 RVA: 0x000E04A0 File Offset: 0x000DE6A0
		// Note: this type is marked as 'beforefieldinit'.
		static AwayFormatters()
		{
		}

		// Token: 0x06003EF6 RID: 16118 RVA: 0x000E0588 File Offset: 0x000DE788
		public static void Issue(global::NetUser user, global::RustProto.AwayEvent awayEvent)
		{
			if (!object.ReferenceEquals(awayEvent, null))
			{
				global::System.TimeSpan timeSpan = global::POSIX.Time.ElapsedSince(awayEvent.Timestamp);
				global::RustProto.AwayEvent.Types.AwayEventType type = awayEvent.Type;
				if (type != global::RustProto.AwayEvent.Types.AwayEventType.SLUMBER)
				{
					if (type == global::RustProto.AwayEvent.Types.AwayEventType.DIED)
					{
						if (awayEvent.HasInstigator)
						{
							if (awayEvent.Instigator == user.user.Userid)
							{
								global::RustServerManagement.AwayFormatters.Expired.Issue(user, awayEvent);
							}
							else
							{
								global::RustServerManagement.AwayFormatters.Murdered.Issue(user, awayEvent);
							}
						}
						else
						{
							global::RustServerManagement.AwayFormatters.Died.Issue(user, awayEvent);
						}
					}
				}
				else
				{
					global::RustServerManagement.AwayFormatters.RegainConsciousness.Issue(user, awayEvent);
				}
			}
		}

		// Token: 0x04002065 RID: 8293
		public static readonly global::RustServerManagement.AwayFormatters.State RegainConsciousness = new global::RustServerManagement.AwayFormatters.State(global::TimeStringFormatter.Rounding.Floor, new global::TimeStringFormatter[]
		{
			global::TimeStringFormatter.Define("You've woken up from", global::TimeStringFormatter.Quantity.Qualifier, " of unconsciousness.", "You've woken up from being unconscious.")
		});

		// Token: 0x04002066 RID: 8294
		public static readonly global::RustServerManagement.AwayFormatters.State Died = new global::RustServerManagement.AwayFormatters.State(global::TimeStringFormatter.Rounding.Floor, new global::TimeStringFormatter[]
		{
			global::TimeStringFormatter.Define("You died", global::TimeStringFormatter.Ago.Qualifier, " while you were unconscious.", "You died while unconscious.")
		});

		// Token: 0x04002067 RID: 8295
		public static readonly global::RustServerManagement.AwayFormatters.State Murdered = new global::RustServerManagement.AwayFormatters.State(global::TimeStringFormatter.Rounding.Floor, new global::TimeStringFormatter[]
		{
			global::TimeStringFormatter.Define("You were murdered", global::TimeStringFormatter.Ago.Qualifier, " while you were unconscious.", "You were murdered while unconscious.")
		});

		// Token: 0x04002068 RID: 8296
		public static readonly global::RustServerManagement.AwayFormatters.State Expired = new global::RustServerManagement.AwayFormatters.State(global::TimeStringFormatter.Rounding.Floor, new global::TimeStringFormatter[]
		{
			global::TimeStringFormatter.Define("You were murdered", global::TimeStringFormatter.Ago.Qualifier, " while you were unconscious.", "You were murdered while unconscious.")
		});

		// Token: 0x02000762 RID: 1890
		public struct State
		{
			// Token: 0x06003EF7 RID: 16119 RVA: 0x000E063C File Offset: 0x000DE83C
			public State(global::TimeStringFormatter.Rounding Rounding, params global::TimeStringFormatter[] Formatters)
			{
				if (Formatters.Length == 0)
				{
					throw new global::System.ArgumentOutOfRangeException();
				}
				this.Rounding = Rounding;
				this.Formatters = Formatters;
			}

			// Token: 0x06003EF8 RID: 16120 RVA: 0x000E065C File Offset: 0x000DE85C
			public string GetFormatter(global::System.TimeSpan timeSpan)
			{
				int num = 0;
				if (this.Formatters.Length != 1)
				{
					num = global::UnityEngine.Random.Range(0, this.Formatters.Length);
				}
				return this.Formatters[num].GetFormattingString(timeSpan);
			}

			// Token: 0x06003EF9 RID: 16121 RVA: 0x000E069C File Offset: 0x000DE89C
			public void Issue(global::NetUser target, global::RustProto.AwayEvent awayEvent)
			{
				this.Issue(target, awayEvent, null);
			}

			// Token: 0x06003EFA RID: 16122 RVA: 0x000E06A8 File Offset: 0x000DE8A8
			public void Issue(global::NetUser target, global::RustProto.AwayEvent awayEvent, string messageOverride)
			{
				global::Rust.Notice.Popup(target.networkPlayer, "", messageOverride ?? this.GetFormatter(global::POSIX.Time.ElapsedSince(awayEvent.Timestamp)), 15f);
			}

			// Token: 0x04002069 RID: 8297
			public readonly global::TimeStringFormatter.Rounding Rounding;

			// Token: 0x0400206A RID: 8298
			public readonly global::TimeStringFormatter[] Formatters;
		}
	}
}
