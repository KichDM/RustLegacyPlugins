using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch.Utility;
using Magma.Events;
using Rust;
using RustPP;
using RustPP.Commands;
using uLink;
using UnityEngine;

namespace Magma
{
	// Token: 0x02000016 RID: 22
	internal class Hooks
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000D8 RID: 216 RVA: 0x00004528 File Offset: 0x00002728
		// (remove) Token: 0x060000D9 RID: 217 RVA: 0x0000455C File Offset: 0x0000275C
		public static event global::Magma.Hooks.PluginInitHandlerDelegate OnPluginInit
		{
			add
			{
				global::Magma.Hooks.PluginInitHandlerDelegate pluginInitHandlerDelegate = global::Magma.Hooks.OnPluginInit;
				global::Magma.Hooks.PluginInitHandlerDelegate pluginInitHandlerDelegate2;
				do
				{
					pluginInitHandlerDelegate2 = pluginInitHandlerDelegate;
					global::Magma.Hooks.PluginInitHandlerDelegate value2 = (global::Magma.Hooks.PluginInitHandlerDelegate)global::System.Delegate.Combine(pluginInitHandlerDelegate2, value);
					pluginInitHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PluginInitHandlerDelegate>(ref global::Magma.Hooks.OnPluginInit, value2, pluginInitHandlerDelegate2);
				}
				while (pluginInitHandlerDelegate != pluginInitHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.PluginInitHandlerDelegate pluginInitHandlerDelegate = global::Magma.Hooks.OnPluginInit;
				global::Magma.Hooks.PluginInitHandlerDelegate pluginInitHandlerDelegate2;
				do
				{
					pluginInitHandlerDelegate2 = pluginInitHandlerDelegate;
					global::Magma.Hooks.PluginInitHandlerDelegate value2 = (global::Magma.Hooks.PluginInitHandlerDelegate)global::System.Delegate.Remove(pluginInitHandlerDelegate2, value);
					pluginInitHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PluginInitHandlerDelegate>(ref global::Magma.Hooks.OnPluginInit, value2, pluginInitHandlerDelegate2);
				}
				while (pluginInitHandlerDelegate != pluginInitHandlerDelegate2);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000DA RID: 218 RVA: 0x00004590 File Offset: 0x00002790
		// (remove) Token: 0x060000DB RID: 219 RVA: 0x000045C4 File Offset: 0x000027C4
		public static event global::Magma.Hooks.ChatHandlerDelegate OnChat
		{
			add
			{
				global::Magma.Hooks.ChatHandlerDelegate chatHandlerDelegate = global::Magma.Hooks.OnChat;
				global::Magma.Hooks.ChatHandlerDelegate chatHandlerDelegate2;
				do
				{
					chatHandlerDelegate2 = chatHandlerDelegate;
					global::Magma.Hooks.ChatHandlerDelegate value2 = (global::Magma.Hooks.ChatHandlerDelegate)global::System.Delegate.Combine(chatHandlerDelegate2, value);
					chatHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ChatHandlerDelegate>(ref global::Magma.Hooks.OnChat, value2, chatHandlerDelegate2);
				}
				while (chatHandlerDelegate != chatHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.ChatHandlerDelegate chatHandlerDelegate = global::Magma.Hooks.OnChat;
				global::Magma.Hooks.ChatHandlerDelegate chatHandlerDelegate2;
				do
				{
					chatHandlerDelegate2 = chatHandlerDelegate;
					global::Magma.Hooks.ChatHandlerDelegate value2 = (global::Magma.Hooks.ChatHandlerDelegate)global::System.Delegate.Remove(chatHandlerDelegate2, value);
					chatHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ChatHandlerDelegate>(ref global::Magma.Hooks.OnChat, value2, chatHandlerDelegate2);
				}
				while (chatHandlerDelegate != chatHandlerDelegate2);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000DC RID: 220 RVA: 0x000045F8 File Offset: 0x000027F8
		// (remove) Token: 0x060000DD RID: 221 RVA: 0x0000462C File Offset: 0x0000282C
		public static event global::Magma.Hooks.CommandHandlerDelegate OnCommand
		{
			add
			{
				global::Magma.Hooks.CommandHandlerDelegate commandHandlerDelegate = global::Magma.Hooks.OnCommand;
				global::Magma.Hooks.CommandHandlerDelegate commandHandlerDelegate2;
				do
				{
					commandHandlerDelegate2 = commandHandlerDelegate;
					global::Magma.Hooks.CommandHandlerDelegate value2 = (global::Magma.Hooks.CommandHandlerDelegate)global::System.Delegate.Combine(commandHandlerDelegate2, value);
					commandHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.CommandHandlerDelegate>(ref global::Magma.Hooks.OnCommand, value2, commandHandlerDelegate2);
				}
				while (commandHandlerDelegate != commandHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.CommandHandlerDelegate commandHandlerDelegate = global::Magma.Hooks.OnCommand;
				global::Magma.Hooks.CommandHandlerDelegate commandHandlerDelegate2;
				do
				{
					commandHandlerDelegate2 = commandHandlerDelegate;
					global::Magma.Hooks.CommandHandlerDelegate value2 = (global::Magma.Hooks.CommandHandlerDelegate)global::System.Delegate.Remove(commandHandlerDelegate2, value);
					commandHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.CommandHandlerDelegate>(ref global::Magma.Hooks.OnCommand, value2, commandHandlerDelegate2);
				}
				while (commandHandlerDelegate != commandHandlerDelegate2);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060000DE RID: 222 RVA: 0x00004660 File Offset: 0x00002860
		// (remove) Token: 0x060000DF RID: 223 RVA: 0x00004694 File Offset: 0x00002894
		public static event global::Magma.Hooks.ConnectionHandlerDelegate OnPlayerConnected
		{
			add
			{
				global::Magma.Hooks.ConnectionHandlerDelegate connectionHandlerDelegate = global::Magma.Hooks.OnPlayerConnected;
				global::Magma.Hooks.ConnectionHandlerDelegate connectionHandlerDelegate2;
				do
				{
					connectionHandlerDelegate2 = connectionHandlerDelegate;
					global::Magma.Hooks.ConnectionHandlerDelegate value2 = (global::Magma.Hooks.ConnectionHandlerDelegate)global::System.Delegate.Combine(connectionHandlerDelegate2, value);
					connectionHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ConnectionHandlerDelegate>(ref global::Magma.Hooks.OnPlayerConnected, value2, connectionHandlerDelegate2);
				}
				while (connectionHandlerDelegate != connectionHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.ConnectionHandlerDelegate connectionHandlerDelegate = global::Magma.Hooks.OnPlayerConnected;
				global::Magma.Hooks.ConnectionHandlerDelegate connectionHandlerDelegate2;
				do
				{
					connectionHandlerDelegate2 = connectionHandlerDelegate;
					global::Magma.Hooks.ConnectionHandlerDelegate value2 = (global::Magma.Hooks.ConnectionHandlerDelegate)global::System.Delegate.Remove(connectionHandlerDelegate2, value);
					connectionHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ConnectionHandlerDelegate>(ref global::Magma.Hooks.OnPlayerConnected, value2, connectionHandlerDelegate2);
				}
				while (connectionHandlerDelegate != connectionHandlerDelegate2);
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000E0 RID: 224 RVA: 0x000046C8 File Offset: 0x000028C8
		// (remove) Token: 0x060000E1 RID: 225 RVA: 0x000046FC File Offset: 0x000028FC
		public static event global::Magma.Hooks.DisconnectionHandlerDelegate OnPlayerDisconnected
		{
			add
			{
				global::Magma.Hooks.DisconnectionHandlerDelegate disconnectionHandlerDelegate = global::Magma.Hooks.OnPlayerDisconnected;
				global::Magma.Hooks.DisconnectionHandlerDelegate disconnectionHandlerDelegate2;
				do
				{
					disconnectionHandlerDelegate2 = disconnectionHandlerDelegate;
					global::Magma.Hooks.DisconnectionHandlerDelegate value2 = (global::Magma.Hooks.DisconnectionHandlerDelegate)global::System.Delegate.Combine(disconnectionHandlerDelegate2, value);
					disconnectionHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.DisconnectionHandlerDelegate>(ref global::Magma.Hooks.OnPlayerDisconnected, value2, disconnectionHandlerDelegate2);
				}
				while (disconnectionHandlerDelegate != disconnectionHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.DisconnectionHandlerDelegate disconnectionHandlerDelegate = global::Magma.Hooks.OnPlayerDisconnected;
				global::Magma.Hooks.DisconnectionHandlerDelegate disconnectionHandlerDelegate2;
				do
				{
					disconnectionHandlerDelegate2 = disconnectionHandlerDelegate;
					global::Magma.Hooks.DisconnectionHandlerDelegate value2 = (global::Magma.Hooks.DisconnectionHandlerDelegate)global::System.Delegate.Remove(disconnectionHandlerDelegate2, value);
					disconnectionHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.DisconnectionHandlerDelegate>(ref global::Magma.Hooks.OnPlayerDisconnected, value2, disconnectionHandlerDelegate2);
				}
				while (disconnectionHandlerDelegate != disconnectionHandlerDelegate2);
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000E2 RID: 226 RVA: 0x00004730 File Offset: 0x00002930
		// (remove) Token: 0x060000E3 RID: 227 RVA: 0x00004764 File Offset: 0x00002964
		public static event global::Magma.Hooks.KillHandlerDelegate OnPlayerKilled
		{
			add
			{
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate = global::Magma.Hooks.OnPlayerKilled;
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate2;
				do
				{
					killHandlerDelegate2 = killHandlerDelegate;
					global::Magma.Hooks.KillHandlerDelegate value2 = (global::Magma.Hooks.KillHandlerDelegate)global::System.Delegate.Combine(killHandlerDelegate2, value);
					killHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.KillHandlerDelegate>(ref global::Magma.Hooks.OnPlayerKilled, value2, killHandlerDelegate2);
				}
				while (killHandlerDelegate != killHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate = global::Magma.Hooks.OnPlayerKilled;
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate2;
				do
				{
					killHandlerDelegate2 = killHandlerDelegate;
					global::Magma.Hooks.KillHandlerDelegate value2 = (global::Magma.Hooks.KillHandlerDelegate)global::System.Delegate.Remove(killHandlerDelegate2, value);
					killHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.KillHandlerDelegate>(ref global::Magma.Hooks.OnPlayerKilled, value2, killHandlerDelegate2);
				}
				while (killHandlerDelegate != killHandlerDelegate2);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000E4 RID: 228 RVA: 0x00004798 File Offset: 0x00002998
		// (remove) Token: 0x060000E5 RID: 229 RVA: 0x000047CC File Offset: 0x000029CC
		public static event global::Magma.Hooks.KillHandlerDelegate OnNPCKilled
		{
			add
			{
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate = global::Magma.Hooks.OnNPCKilled;
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate2;
				do
				{
					killHandlerDelegate2 = killHandlerDelegate;
					global::Magma.Hooks.KillHandlerDelegate value2 = (global::Magma.Hooks.KillHandlerDelegate)global::System.Delegate.Combine(killHandlerDelegate2, value);
					killHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.KillHandlerDelegate>(ref global::Magma.Hooks.OnNPCKilled, value2, killHandlerDelegate2);
				}
				while (killHandlerDelegate != killHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate = global::Magma.Hooks.OnNPCKilled;
				global::Magma.Hooks.KillHandlerDelegate killHandlerDelegate2;
				do
				{
					killHandlerDelegate2 = killHandlerDelegate;
					global::Magma.Hooks.KillHandlerDelegate value2 = (global::Magma.Hooks.KillHandlerDelegate)global::System.Delegate.Remove(killHandlerDelegate2, value);
					killHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.KillHandlerDelegate>(ref global::Magma.Hooks.OnNPCKilled, value2, killHandlerDelegate2);
				}
				while (killHandlerDelegate != killHandlerDelegate2);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000E6 RID: 230 RVA: 0x00004800 File Offset: 0x00002A00
		// (remove) Token: 0x060000E7 RID: 231 RVA: 0x00004834 File Offset: 0x00002A34
		public static event global::Magma.Hooks.HurtHandlerDelegate OnPlayerHurt
		{
			add
			{
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate = global::Magma.Hooks.OnPlayerHurt;
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate2;
				do
				{
					hurtHandlerDelegate2 = hurtHandlerDelegate;
					global::Magma.Hooks.HurtHandlerDelegate value2 = (global::Magma.Hooks.HurtHandlerDelegate)global::System.Delegate.Combine(hurtHandlerDelegate2, value);
					hurtHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.HurtHandlerDelegate>(ref global::Magma.Hooks.OnPlayerHurt, value2, hurtHandlerDelegate2);
				}
				while (hurtHandlerDelegate != hurtHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate = global::Magma.Hooks.OnPlayerHurt;
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate2;
				do
				{
					hurtHandlerDelegate2 = hurtHandlerDelegate;
					global::Magma.Hooks.HurtHandlerDelegate value2 = (global::Magma.Hooks.HurtHandlerDelegate)global::System.Delegate.Remove(hurtHandlerDelegate2, value);
					hurtHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.HurtHandlerDelegate>(ref global::Magma.Hooks.OnPlayerHurt, value2, hurtHandlerDelegate2);
				}
				while (hurtHandlerDelegate != hurtHandlerDelegate2);
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000E8 RID: 232 RVA: 0x00004868 File Offset: 0x00002A68
		// (remove) Token: 0x060000E9 RID: 233 RVA: 0x0000489C File Offset: 0x00002A9C
		public static event global::Magma.Hooks.HurtHandlerDelegate OnNPCHurt
		{
			add
			{
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate = global::Magma.Hooks.OnNPCHurt;
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate2;
				do
				{
					hurtHandlerDelegate2 = hurtHandlerDelegate;
					global::Magma.Hooks.HurtHandlerDelegate value2 = (global::Magma.Hooks.HurtHandlerDelegate)global::System.Delegate.Combine(hurtHandlerDelegate2, value);
					hurtHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.HurtHandlerDelegate>(ref global::Magma.Hooks.OnNPCHurt, value2, hurtHandlerDelegate2);
				}
				while (hurtHandlerDelegate != hurtHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate = global::Magma.Hooks.OnNPCHurt;
				global::Magma.Hooks.HurtHandlerDelegate hurtHandlerDelegate2;
				do
				{
					hurtHandlerDelegate2 = hurtHandlerDelegate;
					global::Magma.Hooks.HurtHandlerDelegate value2 = (global::Magma.Hooks.HurtHandlerDelegate)global::System.Delegate.Remove(hurtHandlerDelegate2, value);
					hurtHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.HurtHandlerDelegate>(ref global::Magma.Hooks.OnNPCHurt, value2, hurtHandlerDelegate2);
				}
				while (hurtHandlerDelegate != hurtHandlerDelegate2);
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000EA RID: 234 RVA: 0x000048D0 File Offset: 0x00002AD0
		// (remove) Token: 0x060000EB RID: 235 RVA: 0x00004904 File Offset: 0x00002B04
		public static event global::Magma.Hooks.PlayerSpawnHandlerDelegate OnPlayerSpawning
		{
			add
			{
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate = global::Magma.Hooks.OnPlayerSpawning;
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate2;
				do
				{
					playerSpawnHandlerDelegate2 = playerSpawnHandlerDelegate;
					global::Magma.Hooks.PlayerSpawnHandlerDelegate value2 = (global::Magma.Hooks.PlayerSpawnHandlerDelegate)global::System.Delegate.Combine(playerSpawnHandlerDelegate2, value);
					playerSpawnHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PlayerSpawnHandlerDelegate>(ref global::Magma.Hooks.OnPlayerSpawning, value2, playerSpawnHandlerDelegate2);
				}
				while (playerSpawnHandlerDelegate != playerSpawnHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate = global::Magma.Hooks.OnPlayerSpawning;
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate2;
				do
				{
					playerSpawnHandlerDelegate2 = playerSpawnHandlerDelegate;
					global::Magma.Hooks.PlayerSpawnHandlerDelegate value2 = (global::Magma.Hooks.PlayerSpawnHandlerDelegate)global::System.Delegate.Remove(playerSpawnHandlerDelegate2, value);
					playerSpawnHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PlayerSpawnHandlerDelegate>(ref global::Magma.Hooks.OnPlayerSpawning, value2, playerSpawnHandlerDelegate2);
				}
				while (playerSpawnHandlerDelegate != playerSpawnHandlerDelegate2);
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000EC RID: 236 RVA: 0x00004938 File Offset: 0x00002B38
		// (remove) Token: 0x060000ED RID: 237 RVA: 0x0000496C File Offset: 0x00002B6C
		public static event global::Magma.Hooks.PlayerSpawnHandlerDelegate OnPlayerSpawned
		{
			add
			{
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate = global::Magma.Hooks.OnPlayerSpawned;
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate2;
				do
				{
					playerSpawnHandlerDelegate2 = playerSpawnHandlerDelegate;
					global::Magma.Hooks.PlayerSpawnHandlerDelegate value2 = (global::Magma.Hooks.PlayerSpawnHandlerDelegate)global::System.Delegate.Combine(playerSpawnHandlerDelegate2, value);
					playerSpawnHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PlayerSpawnHandlerDelegate>(ref global::Magma.Hooks.OnPlayerSpawned, value2, playerSpawnHandlerDelegate2);
				}
				while (playerSpawnHandlerDelegate != playerSpawnHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate = global::Magma.Hooks.OnPlayerSpawned;
				global::Magma.Hooks.PlayerSpawnHandlerDelegate playerSpawnHandlerDelegate2;
				do
				{
					playerSpawnHandlerDelegate2 = playerSpawnHandlerDelegate;
					global::Magma.Hooks.PlayerSpawnHandlerDelegate value2 = (global::Magma.Hooks.PlayerSpawnHandlerDelegate)global::System.Delegate.Remove(playerSpawnHandlerDelegate2, value);
					playerSpawnHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PlayerSpawnHandlerDelegate>(ref global::Magma.Hooks.OnPlayerSpawned, value2, playerSpawnHandlerDelegate2);
				}
				while (playerSpawnHandlerDelegate != playerSpawnHandlerDelegate2);
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000EE RID: 238 RVA: 0x000049A0 File Offset: 0x00002BA0
		// (remove) Token: 0x060000EF RID: 239 RVA: 0x000049D4 File Offset: 0x00002BD4
		public static event global::Magma.Hooks.PlayerGatheringHandlerDelegate OnPlayerGathering
		{
			add
			{
				global::Magma.Hooks.PlayerGatheringHandlerDelegate playerGatheringHandlerDelegate = global::Magma.Hooks.OnPlayerGathering;
				global::Magma.Hooks.PlayerGatheringHandlerDelegate playerGatheringHandlerDelegate2;
				do
				{
					playerGatheringHandlerDelegate2 = playerGatheringHandlerDelegate;
					global::Magma.Hooks.PlayerGatheringHandlerDelegate value2 = (global::Magma.Hooks.PlayerGatheringHandlerDelegate)global::System.Delegate.Combine(playerGatheringHandlerDelegate2, value);
					playerGatheringHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PlayerGatheringHandlerDelegate>(ref global::Magma.Hooks.OnPlayerGathering, value2, playerGatheringHandlerDelegate2);
				}
				while (playerGatheringHandlerDelegate != playerGatheringHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.PlayerGatheringHandlerDelegate playerGatheringHandlerDelegate = global::Magma.Hooks.OnPlayerGathering;
				global::Magma.Hooks.PlayerGatheringHandlerDelegate playerGatheringHandlerDelegate2;
				do
				{
					playerGatheringHandlerDelegate2 = playerGatheringHandlerDelegate;
					global::Magma.Hooks.PlayerGatheringHandlerDelegate value2 = (global::Magma.Hooks.PlayerGatheringHandlerDelegate)global::System.Delegate.Remove(playerGatheringHandlerDelegate2, value);
					playerGatheringHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.PlayerGatheringHandlerDelegate>(ref global::Magma.Hooks.OnPlayerGathering, value2, playerGatheringHandlerDelegate2);
				}
				while (playerGatheringHandlerDelegate != playerGatheringHandlerDelegate2);
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000F0 RID: 240 RVA: 0x00004A08 File Offset: 0x00002C08
		// (remove) Token: 0x060000F1 RID: 241 RVA: 0x00004A3C File Offset: 0x00002C3C
		public static event global::Magma.Hooks.EntityHurtDelegate OnEntityHurt
		{
			add
			{
				global::Magma.Hooks.EntityHurtDelegate entityHurtDelegate = global::Magma.Hooks.OnEntityHurt;
				global::Magma.Hooks.EntityHurtDelegate entityHurtDelegate2;
				do
				{
					entityHurtDelegate2 = entityHurtDelegate;
					global::Magma.Hooks.EntityHurtDelegate value2 = (global::Magma.Hooks.EntityHurtDelegate)global::System.Delegate.Combine(entityHurtDelegate2, value);
					entityHurtDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.EntityHurtDelegate>(ref global::Magma.Hooks.OnEntityHurt, value2, entityHurtDelegate2);
				}
				while (entityHurtDelegate != entityHurtDelegate2);
			}
			remove
			{
				global::Magma.Hooks.EntityHurtDelegate entityHurtDelegate = global::Magma.Hooks.OnEntityHurt;
				global::Magma.Hooks.EntityHurtDelegate entityHurtDelegate2;
				do
				{
					entityHurtDelegate2 = entityHurtDelegate;
					global::Magma.Hooks.EntityHurtDelegate value2 = (global::Magma.Hooks.EntityHurtDelegate)global::System.Delegate.Remove(entityHurtDelegate2, value);
					entityHurtDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.EntityHurtDelegate>(ref global::Magma.Hooks.OnEntityHurt, value2, entityHurtDelegate2);
				}
				while (entityHurtDelegate != entityHurtDelegate2);
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000F2 RID: 242 RVA: 0x00004A70 File Offset: 0x00002C70
		// (remove) Token: 0x060000F3 RID: 243 RVA: 0x00004AA4 File Offset: 0x00002CA4
		public static event global::Magma.Hooks.EntityDecayDelegate OnEntityDecay
		{
			add
			{
				global::Magma.Hooks.EntityDecayDelegate entityDecayDelegate = global::Magma.Hooks.OnEntityDecay;
				global::Magma.Hooks.EntityDecayDelegate entityDecayDelegate2;
				do
				{
					entityDecayDelegate2 = entityDecayDelegate;
					global::Magma.Hooks.EntityDecayDelegate value2 = (global::Magma.Hooks.EntityDecayDelegate)global::System.Delegate.Combine(entityDecayDelegate2, value);
					entityDecayDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.EntityDecayDelegate>(ref global::Magma.Hooks.OnEntityDecay, value2, entityDecayDelegate2);
				}
				while (entityDecayDelegate != entityDecayDelegate2);
			}
			remove
			{
				global::Magma.Hooks.EntityDecayDelegate entityDecayDelegate = global::Magma.Hooks.OnEntityDecay;
				global::Magma.Hooks.EntityDecayDelegate entityDecayDelegate2;
				do
				{
					entityDecayDelegate2 = entityDecayDelegate;
					global::Magma.Hooks.EntityDecayDelegate value2 = (global::Magma.Hooks.EntityDecayDelegate)global::System.Delegate.Remove(entityDecayDelegate2, value);
					entityDecayDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.EntityDecayDelegate>(ref global::Magma.Hooks.OnEntityDecay, value2, entityDecayDelegate2);
				}
				while (entityDecayDelegate != entityDecayDelegate2);
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060000F4 RID: 244 RVA: 0x00004AD8 File Offset: 0x00002CD8
		// (remove) Token: 0x060000F5 RID: 245 RVA: 0x00004B0C File Offset: 0x00002D0C
		public static event global::Magma.Hooks.EntityDeployedDelegate OnEntityDeployed
		{
			add
			{
				global::Magma.Hooks.EntityDeployedDelegate entityDeployedDelegate = global::Magma.Hooks.OnEntityDeployed;
				global::Magma.Hooks.EntityDeployedDelegate entityDeployedDelegate2;
				do
				{
					entityDeployedDelegate2 = entityDeployedDelegate;
					global::Magma.Hooks.EntityDeployedDelegate value2 = (global::Magma.Hooks.EntityDeployedDelegate)global::System.Delegate.Combine(entityDeployedDelegate2, value);
					entityDeployedDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.EntityDeployedDelegate>(ref global::Magma.Hooks.OnEntityDeployed, value2, entityDeployedDelegate2);
				}
				while (entityDeployedDelegate != entityDeployedDelegate2);
			}
			remove
			{
				global::Magma.Hooks.EntityDeployedDelegate entityDeployedDelegate = global::Magma.Hooks.OnEntityDeployed;
				global::Magma.Hooks.EntityDeployedDelegate entityDeployedDelegate2;
				do
				{
					entityDeployedDelegate2 = entityDeployedDelegate;
					global::Magma.Hooks.EntityDeployedDelegate value2 = (global::Magma.Hooks.EntityDeployedDelegate)global::System.Delegate.Remove(entityDeployedDelegate2, value);
					entityDeployedDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.EntityDeployedDelegate>(ref global::Magma.Hooks.OnEntityDeployed, value2, entityDeployedDelegate2);
				}
				while (entityDeployedDelegate != entityDeployedDelegate2);
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060000F6 RID: 246 RVA: 0x00004B40 File Offset: 0x00002D40
		// (remove) Token: 0x060000F7 RID: 247 RVA: 0x00004B74 File Offset: 0x00002D74
		public static event global::Magma.Hooks.ConsoleHandlerDelegate OnConsoleReceived
		{
			add
			{
				global::Magma.Hooks.ConsoleHandlerDelegate consoleHandlerDelegate = global::Magma.Hooks.OnConsoleReceived;
				global::Magma.Hooks.ConsoleHandlerDelegate consoleHandlerDelegate2;
				do
				{
					consoleHandlerDelegate2 = consoleHandlerDelegate;
					global::Magma.Hooks.ConsoleHandlerDelegate value2 = (global::Magma.Hooks.ConsoleHandlerDelegate)global::System.Delegate.Combine(consoleHandlerDelegate2, value);
					consoleHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ConsoleHandlerDelegate>(ref global::Magma.Hooks.OnConsoleReceived, value2, consoleHandlerDelegate2);
				}
				while (consoleHandlerDelegate != consoleHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.ConsoleHandlerDelegate consoleHandlerDelegate = global::Magma.Hooks.OnConsoleReceived;
				global::Magma.Hooks.ConsoleHandlerDelegate consoleHandlerDelegate2;
				do
				{
					consoleHandlerDelegate2 = consoleHandlerDelegate;
					global::Magma.Hooks.ConsoleHandlerDelegate value2 = (global::Magma.Hooks.ConsoleHandlerDelegate)global::System.Delegate.Remove(consoleHandlerDelegate2, value);
					consoleHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ConsoleHandlerDelegate>(ref global::Magma.Hooks.OnConsoleReceived, value2, consoleHandlerDelegate2);
				}
				while (consoleHandlerDelegate != consoleHandlerDelegate2);
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060000F8 RID: 248 RVA: 0x00004BA8 File Offset: 0x00002DA8
		// (remove) Token: 0x060000F9 RID: 249 RVA: 0x00004BDC File Offset: 0x00002DDC
		public static event global::Magma.Hooks.LootTablesLoaded OnTablesLoaded
		{
			add
			{
				global::Magma.Hooks.LootTablesLoaded lootTablesLoaded = global::Magma.Hooks.OnTablesLoaded;
				global::Magma.Hooks.LootTablesLoaded lootTablesLoaded2;
				do
				{
					lootTablesLoaded2 = lootTablesLoaded;
					global::Magma.Hooks.LootTablesLoaded value2 = (global::Magma.Hooks.LootTablesLoaded)global::System.Delegate.Combine(lootTablesLoaded2, value);
					lootTablesLoaded = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.LootTablesLoaded>(ref global::Magma.Hooks.OnTablesLoaded, value2, lootTablesLoaded2);
				}
				while (lootTablesLoaded != lootTablesLoaded2);
			}
			remove
			{
				global::Magma.Hooks.LootTablesLoaded lootTablesLoaded = global::Magma.Hooks.OnTablesLoaded;
				global::Magma.Hooks.LootTablesLoaded lootTablesLoaded2;
				do
				{
					lootTablesLoaded2 = lootTablesLoaded;
					global::Magma.Hooks.LootTablesLoaded value2 = (global::Magma.Hooks.LootTablesLoaded)global::System.Delegate.Remove(lootTablesLoaded2, value);
					lootTablesLoaded = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.LootTablesLoaded>(ref global::Magma.Hooks.OnTablesLoaded, value2, lootTablesLoaded2);
				}
				while (lootTablesLoaded != lootTablesLoaded2);
			}
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060000FA RID: 250 RVA: 0x00004C10 File Offset: 0x00002E10
		// (remove) Token: 0x060000FB RID: 251 RVA: 0x00004C44 File Offset: 0x00002E44
		public static event global::Magma.Hooks.ItemsDatablocksLoaded OnItemsLoaded
		{
			add
			{
				global::Magma.Hooks.ItemsDatablocksLoaded itemsDatablocksLoaded = global::Magma.Hooks.OnItemsLoaded;
				global::Magma.Hooks.ItemsDatablocksLoaded itemsDatablocksLoaded2;
				do
				{
					itemsDatablocksLoaded2 = itemsDatablocksLoaded;
					global::Magma.Hooks.ItemsDatablocksLoaded value2 = (global::Magma.Hooks.ItemsDatablocksLoaded)global::System.Delegate.Combine(itemsDatablocksLoaded2, value);
					itemsDatablocksLoaded = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ItemsDatablocksLoaded>(ref global::Magma.Hooks.OnItemsLoaded, value2, itemsDatablocksLoaded2);
				}
				while (itemsDatablocksLoaded != itemsDatablocksLoaded2);
			}
			remove
			{
				global::Magma.Hooks.ItemsDatablocksLoaded itemsDatablocksLoaded = global::Magma.Hooks.OnItemsLoaded;
				global::Magma.Hooks.ItemsDatablocksLoaded itemsDatablocksLoaded2;
				do
				{
					itemsDatablocksLoaded2 = itemsDatablocksLoaded;
					global::Magma.Hooks.ItemsDatablocksLoaded value2 = (global::Magma.Hooks.ItemsDatablocksLoaded)global::System.Delegate.Remove(itemsDatablocksLoaded2, value);
					itemsDatablocksLoaded = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ItemsDatablocksLoaded>(ref global::Magma.Hooks.OnItemsLoaded, value2, itemsDatablocksLoaded2);
				}
				while (itemsDatablocksLoaded != itemsDatablocksLoaded2);
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060000FC RID: 252 RVA: 0x00004C78 File Offset: 0x00002E78
		// (remove) Token: 0x060000FD RID: 253 RVA: 0x00004CAC File Offset: 0x00002EAC
		public static event global::Magma.Hooks.BlueprintUseHandlerDelagate OnBlueprintUse
		{
			add
			{
				global::Magma.Hooks.BlueprintUseHandlerDelagate blueprintUseHandlerDelagate = global::Magma.Hooks.OnBlueprintUse;
				global::Magma.Hooks.BlueprintUseHandlerDelagate blueprintUseHandlerDelagate2;
				do
				{
					blueprintUseHandlerDelagate2 = blueprintUseHandlerDelagate;
					global::Magma.Hooks.BlueprintUseHandlerDelagate value2 = (global::Magma.Hooks.BlueprintUseHandlerDelagate)global::System.Delegate.Combine(blueprintUseHandlerDelagate2, value);
					blueprintUseHandlerDelagate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.BlueprintUseHandlerDelagate>(ref global::Magma.Hooks.OnBlueprintUse, value2, blueprintUseHandlerDelagate2);
				}
				while (blueprintUseHandlerDelagate != blueprintUseHandlerDelagate2);
			}
			remove
			{
				global::Magma.Hooks.BlueprintUseHandlerDelagate blueprintUseHandlerDelagate = global::Magma.Hooks.OnBlueprintUse;
				global::Magma.Hooks.BlueprintUseHandlerDelagate blueprintUseHandlerDelagate2;
				do
				{
					blueprintUseHandlerDelagate2 = blueprintUseHandlerDelagate;
					global::Magma.Hooks.BlueprintUseHandlerDelagate value2 = (global::Magma.Hooks.BlueprintUseHandlerDelagate)global::System.Delegate.Remove(blueprintUseHandlerDelagate2, value);
					blueprintUseHandlerDelagate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.BlueprintUseHandlerDelagate>(ref global::Magma.Hooks.OnBlueprintUse, value2, blueprintUseHandlerDelagate2);
				}
				while (blueprintUseHandlerDelagate != blueprintUseHandlerDelagate2);
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060000FE RID: 254 RVA: 0x00004CE0 File Offset: 0x00002EE0
		// (remove) Token: 0x060000FF RID: 255 RVA: 0x00004D14 File Offset: 0x00002F14
		public static event global::Magma.Hooks.DoorOpenHandlerDelegate OnDoorUse
		{
			add
			{
				global::Magma.Hooks.DoorOpenHandlerDelegate doorOpenHandlerDelegate = global::Magma.Hooks.OnDoorUse;
				global::Magma.Hooks.DoorOpenHandlerDelegate doorOpenHandlerDelegate2;
				do
				{
					doorOpenHandlerDelegate2 = doorOpenHandlerDelegate;
					global::Magma.Hooks.DoorOpenHandlerDelegate value2 = (global::Magma.Hooks.DoorOpenHandlerDelegate)global::System.Delegate.Combine(doorOpenHandlerDelegate2, value);
					doorOpenHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.DoorOpenHandlerDelegate>(ref global::Magma.Hooks.OnDoorUse, value2, doorOpenHandlerDelegate2);
				}
				while (doorOpenHandlerDelegate != doorOpenHandlerDelegate2);
			}
			remove
			{
				global::Magma.Hooks.DoorOpenHandlerDelegate doorOpenHandlerDelegate = global::Magma.Hooks.OnDoorUse;
				global::Magma.Hooks.DoorOpenHandlerDelegate doorOpenHandlerDelegate2;
				do
				{
					doorOpenHandlerDelegate2 = doorOpenHandlerDelegate;
					global::Magma.Hooks.DoorOpenHandlerDelegate value2 = (global::Magma.Hooks.DoorOpenHandlerDelegate)global::System.Delegate.Remove(doorOpenHandlerDelegate2, value);
					doorOpenHandlerDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.DoorOpenHandlerDelegate>(ref global::Magma.Hooks.OnDoorUse, value2, doorOpenHandlerDelegate2);
				}
				while (doorOpenHandlerDelegate != doorOpenHandlerDelegate2);
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000100 RID: 256 RVA: 0x00004D48 File Offset: 0x00002F48
		// (remove) Token: 0x06000101 RID: 257 RVA: 0x00004D7C File Offset: 0x00002F7C
		public static event global::Magma.Hooks.ServerInitDelegate OnServerInit
		{
			add
			{
				global::Magma.Hooks.ServerInitDelegate serverInitDelegate = global::Magma.Hooks.OnServerInit;
				global::Magma.Hooks.ServerInitDelegate serverInitDelegate2;
				do
				{
					serverInitDelegate2 = serverInitDelegate;
					global::Magma.Hooks.ServerInitDelegate value2 = (global::Magma.Hooks.ServerInitDelegate)global::System.Delegate.Combine(serverInitDelegate2, value);
					serverInitDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ServerInitDelegate>(ref global::Magma.Hooks.OnServerInit, value2, serverInitDelegate2);
				}
				while (serverInitDelegate != serverInitDelegate2);
			}
			remove
			{
				global::Magma.Hooks.ServerInitDelegate serverInitDelegate = global::Magma.Hooks.OnServerInit;
				global::Magma.Hooks.ServerInitDelegate serverInitDelegate2;
				do
				{
					serverInitDelegate2 = serverInitDelegate;
					global::Magma.Hooks.ServerInitDelegate value2 = (global::Magma.Hooks.ServerInitDelegate)global::System.Delegate.Remove(serverInitDelegate2, value);
					serverInitDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ServerInitDelegate>(ref global::Magma.Hooks.OnServerInit, value2, serverInitDelegate2);
				}
				while (serverInitDelegate != serverInitDelegate2);
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000102 RID: 258 RVA: 0x00004DB0 File Offset: 0x00002FB0
		// (remove) Token: 0x06000103 RID: 259 RVA: 0x00004DE4 File Offset: 0x00002FE4
		public static event global::Magma.Hooks.ServerShutdownDelegate OnServerShutdown
		{
			add
			{
				global::Magma.Hooks.ServerShutdownDelegate serverShutdownDelegate = global::Magma.Hooks.OnServerShutdown;
				global::Magma.Hooks.ServerShutdownDelegate serverShutdownDelegate2;
				do
				{
					serverShutdownDelegate2 = serverShutdownDelegate;
					global::Magma.Hooks.ServerShutdownDelegate value2 = (global::Magma.Hooks.ServerShutdownDelegate)global::System.Delegate.Combine(serverShutdownDelegate2, value);
					serverShutdownDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ServerShutdownDelegate>(ref global::Magma.Hooks.OnServerShutdown, value2, serverShutdownDelegate2);
				}
				while (serverShutdownDelegate != serverShutdownDelegate2);
			}
			remove
			{
				global::Magma.Hooks.ServerShutdownDelegate serverShutdownDelegate = global::Magma.Hooks.OnServerShutdown;
				global::Magma.Hooks.ServerShutdownDelegate serverShutdownDelegate2;
				do
				{
					serverShutdownDelegate2 = serverShutdownDelegate;
					global::Magma.Hooks.ServerShutdownDelegate value2 = (global::Magma.Hooks.ServerShutdownDelegate)global::System.Delegate.Remove(serverShutdownDelegate2, value);
					serverShutdownDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Hooks.ServerShutdownDelegate>(ref global::Magma.Hooks.OnServerShutdown, value2, serverShutdownDelegate2);
				}
				while (serverShutdownDelegate != serverShutdownDelegate2);
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004E44 File Offset: 0x00003044
		public static void ResetHooks()
		{
			global::Magma.Hooks.OnPluginInit = delegate()
			{
			};
			global::Magma.Hooks.OnChat = delegate(global::Magma.Player param0, ref global::Magma.ChatString param1)
			{
			};
			global::Magma.Hooks.OnCommand = delegate(global::Magma.Player param0, string param1, string[] param2)
			{
			};
			global::Magma.Hooks.OnPlayerConnected = delegate(global::Magma.Player param0)
			{
			};
			global::Magma.Hooks.OnPlayerDisconnected = delegate(global::Magma.Player param0)
			{
			};
			global::Magma.Hooks.OnNPCKilled = delegate(global::Magma.Events.DeathEvent param0)
			{
			};
			global::Magma.Hooks.OnNPCHurt = delegate(global::Magma.Events.HurtEvent param0)
			{
			};
			global::Magma.Hooks.OnPlayerKilled = delegate(global::Magma.Events.DeathEvent param0)
			{
			};
			global::Magma.Hooks.OnPlayerHurt = delegate(global::Magma.Events.HurtEvent param0)
			{
			};
			global::Magma.Hooks.OnPlayerSpawned = delegate(global::Magma.Player param0, global::Magma.Events.SpawnEvent param1)
			{
			};
			global::Magma.Hooks.OnPlayerSpawning = delegate(global::Magma.Player param0, global::Magma.Events.SpawnEvent param1)
			{
			};
			global::Magma.Hooks.OnPlayerGathering = delegate(global::Magma.Player param0, global::Magma.Events.GatherEvent param1)
			{
			};
			global::Magma.Hooks.OnEntityHurt = delegate(global::Magma.Events.HurtEvent param0)
			{
			};
			global::Magma.Hooks.OnEntityDecay = delegate(global::Magma.Events.DecayEvent param0)
			{
			};
			global::Magma.Hooks.OnEntityDeployed = delegate(global::Magma.Player param0, global::Magma.Entity param1)
			{
			};
			global::Magma.Hooks.OnConsoleReceived = delegate(ref global::ConsoleSystem.Arg param0, bool param1)
			{
			};
			global::Magma.Hooks.OnBlueprintUse = delegate(global::Magma.Player param0, global::Magma.Events.BPUseEvent param1)
			{
			};
			global::Magma.Hooks.OnDoorUse = delegate(global::Magma.Player param0, global::Magma.Events.DoorEvent param1)
			{
			};
			global::Magma.Hooks.OnTablesLoaded = delegate(global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> param0)
			{
			};
			global::Magma.Hooks.OnItemsLoaded = delegate(global::Magma.ItemsBlocks param0)
			{
			};
			global::Magma.Hooks.OnServerInit = delegate()
			{
			};
			global::Magma.Hooks.OnServerShutdown = delegate()
			{
			};
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				player.FixInventoryRef();
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005188 File Offset: 0x00003388
		public static void PluginInit()
		{
			if (global::Magma.Hooks.OnPluginInit != null)
			{
				global::Magma.Hooks.OnPluginInit();
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000519B File Offset: 0x0000339B
		public static void ServerStarted()
		{
			global::Magma.DataStore.GetInstance().Load();
			if (global::Magma.Hooks.OnServerInit != null)
			{
				global::Magma.Hooks.OnServerInit();
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000051B8 File Offset: 0x000033B8
		public static void ServerShutdown()
		{
			if (global::RustPP.Core.IsEnabled())
			{
				global::RustPP.Helper.CreateSaves();
			}
			if (global::Magma.Hooks.OnServerShutdown != null)
			{
				global::Magma.Hooks.OnServerShutdown();
			}
			global::Magma.DataStore.GetInstance().Save();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000051E4 File Offset: 0x000033E4
		public static global::ItemDataBlock[] ItemsLoaded(global::System.Collections.Generic.List<global::ItemDataBlock> items, global::System.Collections.Generic.Dictionary<string, int> stringDB, global::System.Collections.Generic.Dictionary<int, int> idDB)
		{
			global::Magma.ItemsBlocks itemsBlocks = new global::Magma.ItemsBlocks(items);
			if (global::Magma.Hooks.OnItemsLoaded != null)
			{
				global::Magma.Hooks.OnItemsLoaded(itemsBlocks);
			}
			int num = 0;
			foreach (global::ItemDataBlock itemDataBlock in itemsBlocks)
			{
				stringDB.Add(itemDataBlock.name, num);
				idDB.Add(itemDataBlock.uniqueID, num);
				num++;
			}
			global::Magma.Server.GetServer().Items = itemsBlocks;
			return itemsBlocks.ToArray();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005278 File Offset: 0x00003478
		public static global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> TablesLoaded(global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> lists)
		{
			if (global::Magma.Hooks.OnTablesLoaded != null)
			{
				global::Magma.Hooks.OnTablesLoaded(lists);
			}
			return lists;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005290 File Offset: 0x00003490
		public static void ChatReceived(ref global::ConsoleSystem.Arg arg)
		{
			if (!global::chat.enabled)
			{
				return;
			}
			string text = global::Facepunch.Utility.String.QuoteSafe(arg.argUser.user.Displayname);
			string text2 = global::Facepunch.Utility.String.QuoteSafe(arg.GetString(0, "text"));
			global::RustPP.Commands.TeleportToCommand teleportToCommand = global::RustPP.Commands.ChatCommand.GetCommand("tpto") as global::RustPP.Commands.TeleportToCommand;
			if (teleportToCommand.GetTPWaitList().Contains(arg.argUser.userID))
			{
				int choice;
				bool flag = int.TryParse(arg.GetString(0, "text").Trim(), out choice);
				if (flag)
				{
					teleportToCommand.PartialNameTP(ref arg, choice);
					return;
				}
				global::Magma.Util.sayUser(arg.argUser.networkPlayer, "Invalid Choice !");
				teleportToCommand.GetTPWaitList().Remove(arg.argUser.userID);
				return;
			}
			else if (global::RustPP.Core.banWaitList.Contains(arg.argUser.userID))
			{
				int id;
				bool flag2 = int.TryParse(arg.GetString(0, "text").Trim(), out id);
				if (flag2)
				{
					global::RustPP.Commands.BanCommand banCommand = global::RustPP.Commands.ChatCommand.GetCommand("ban") as global::RustPP.Commands.BanCommand;
					banCommand.PartialNameBan(ref arg, id);
					return;
				}
				global::Magma.Util.sayUser(arg.argUser.networkPlayer, "Invalid Choice !");
				global::RustPP.Core.banWaitList.Remove(arg.argUser.userID);
				return;
			}
			else
			{
				if (!global::RustPP.Core.kickWaitList.Contains(arg.argUser.userID))
				{
					if (text2 != null && text2.Length > 1 && text2.Substring(1, 1).Equals("/"))
					{
						global::Magma.Hooks.handleCommand(ref arg);
						if (global::RustPP.Core.IsEnabled())
						{
							global::RustPP.Core.handleCommand(ref arg);
							return;
						}
					}
					else
					{
						global::Magma.ChatString chatString = new global::Magma.ChatString(text2);
						if (global::Magma.Hooks.OnChat != null)
						{
							global::Magma.Hooks.OnChat(global::Magma.Player.FindByPlayerClient(arg.argUser.playerClient), ref chatString);
						}
						text2 = global::Facepunch.Utility.String.QuoteSafe(chatString.NewText.Substring(1, chatString.NewText.Length - 2));
						if (text2 != "")
						{
							if (global::RustPP.Core.IsEnabled() && global::RustPP.Core.muteList.Contains(arg.argUser.userID))
							{
								global::Magma.Util.sayUser(arg.argUser.networkPlayer, "You are muted.");
								return;
							}
							global::Magma.Data.GetData().chat_history.Add(text2);
							global::Magma.Data.GetData().chat_history_username.Add(text);
							global::UnityEngine.Debug.Log("[CHAT] " + text + ":" + text2);
							global::ConsoleNetworker.Broadcast("chat.add " + text + " " + text2);
						}
					}
					return;
				}
				int id2;
				bool flag3 = int.TryParse(arg.GetString(0, "text").Trim(), out id2);
				if (flag3)
				{
					global::RustPP.Commands.KickCommand kickCommand = global::RustPP.Commands.ChatCommand.GetCommand("kick") as global::RustPP.Commands.KickCommand;
					kickCommand.PartialNameKick(ref arg, id2);
					return;
				}
				global::Magma.Util.sayUser(arg.argUser.networkPlayer, "Invalid Choice !");
				global::RustPP.Core.kickWaitList.Remove(arg.argUser.userID);
				return;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005584 File Offset: 0x00003784
		public static bool ConsoleReceived(ref global::ConsoleSystem.Arg a)
		{
			if (a.argUser == null && a.Class == "magmaweb" && a.Function == "handshake")
			{
				a.ReplyWith("All Good !");
				return true;
			}
			bool flag = a.argUser == null;
			if (global::Magma.Hooks.OnConsoleReceived != null)
			{
				global::Magma.Hooks.OnConsoleReceived(ref a, flag);
			}
			if (a.Class == "magma" && a.Function.ToLower() == "reload")
			{
				if (a.argUser != null && a.argUser.admin)
				{
					global::Magma.PluginEngine.GetPluginEngine().ReloadPlugins(global::Magma.Player.FindByPlayerClient(a.argUser.playerClient));
					a.ReplyWith("Magma : Reloaded !");
				}
				else if (flag)
				{
					global::Magma.PluginEngine.GetPluginEngine().ReloadPlugins(null);
					a.ReplyWith("Magma : Reloaded !");
				}
			}
			if (a.Reply == null || a.Reply == "")
			{
				a.ReplyWith(string.Concat(new string[]
				{
					"Magma : ",
					a.Class,
					".",
					a.Function,
					" was executed !"
				}));
			}
			return true;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000056D0 File Offset: 0x000038D0
		public static void PlayerHurt(ref global::DamageEvent e)
		{
			global::Magma.Events.HurtEvent hurtEvent = new global::Magma.Events.HurtEvent(ref e);
			if (!(hurtEvent.Attacker is global::Magma.NPC) && !(hurtEvent.Victim is global::Magma.NPC))
			{
				global::Magma.Player player = hurtEvent.Attacker as global::Magma.Player;
				global::Magma.Player player2 = hurtEvent.Victim as global::Magma.Player;
				global::Magma.Zone3D zone3D = global::Magma.Zone3D.GlobalContains(player);
				if (zone3D != null && !zone3D.PVP)
				{
					player.Message("You are in a PVP restricted area.");
					hurtEvent.DamageAmount = 0f;
					e = hurtEvent.DamageEvent;
					return;
				}
				zone3D = global::Magma.Zone3D.GlobalContains(player2);
				if (zone3D != null && !zone3D.PVP)
				{
					player.Message(player2.Name + " is in a PVP restricted area.");
					hurtEvent.DamageAmount = 0f;
					e = hurtEvent.DamageEvent;
					return;
				}
			}
			if (global::RustPP.Core.IsEnabled() && global::RustPP.Hooks.IsFriend(ref e))
			{
				hurtEvent.DamageAmount = 0f;
			}
			if (global::Magma.Hooks.OnPlayerHurt != null)
			{
				global::Magma.Hooks.OnPlayerHurt(hurtEvent);
			}
			e = hurtEvent.DamageEvent;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000057CC File Offset: 0x000039CC
		public static bool PlayerKilled(ref global::DamageEvent de)
		{
			bool result;
			try
			{
				global::Magma.Events.DeathEvent deathEvent = new global::Magma.Events.DeathEvent(ref de);
				if (global::RustPP.Core.IsEnabled() && !(deathEvent.Attacker is global::Magma.NPC))
				{
					deathEvent.DropItems = !global::RustPP.Hooks.KeepItem();
					global::Magma.Player player = deathEvent.Attacker as global::Magma.Player;
					global::Magma.Player player2 = deathEvent.Victim as global::Magma.Player;
					if (player.Name != player2.Name && global::Magma.Server.GetServer().FindPlayer(player.Name) != null)
					{
						global::RustPP.Hooks.broadcastDeath(player2.Name, player.Name, deathEvent.WeaponName);
					}
				}
				if (global::Magma.Hooks.OnPlayerKilled != null)
				{
					global::Magma.Hooks.OnPlayerKilled(deathEvent);
				}
				result = deathEvent.DropItems;
			}
			catch (global::System.Exception ex)
			{
				global::System.Console.WriteLine(ex.ToString());
				result = true;
			}
			return result;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005898 File Offset: 0x00003A98
		public static bool PlayerConnect(global::NetUser user)
		{
			global::Magma.Player player = new global::Magma.Player(user.playerClient);
			global::Magma.Server.GetServer().Players.Add(player);
			bool result = user.connected;
			if (global::RustPP.Core.IsEnabled())
			{
				result = global::RustPP.Hooks.loginNotice(user);
			}
			if (global::Magma.Hooks.OnPlayerConnected != null)
			{
				global::Magma.Hooks.OnPlayerConnected(player);
			}
			player.Message("This server is powered by Magma v." + global::Magma.Bootstrap.Version + " !");
			return result;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005904 File Offset: 0x00003B04
		public static void PlayerDisconnect(global::NetUser user)
		{
			global::Magma.Player player = global::Magma.Player.FindByPlayerClient(user.playerClient);
			if (player != null)
			{
				global::Magma.Server.GetServer().Players.Remove(player);
			}
			if (global::RustPP.Core.IsEnabled())
			{
				global::RustPP.Hooks.logoffNotice(user);
			}
			if (global::Magma.Hooks.OnPlayerDisconnected != null)
			{
				global::Magma.Hooks.OnPlayerDisconnected(player);
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005950 File Offset: 0x00003B50
		public static global::UnityEngine.Vector3 PlayerSpawning(global::PlayerClient pc, global::UnityEngine.Vector3 pos, bool camp)
		{
			global::Magma.Player player = global::Magma.Player.FindByPlayerClient(pc);
			global::Magma.Events.SpawnEvent spawnEvent = new global::Magma.Events.SpawnEvent(pos, camp);
			if (global::Magma.Hooks.OnPlayerSpawning != null && player != null)
			{
				global::Magma.Hooks.OnPlayerSpawning(player, spawnEvent);
			}
			return new global::UnityEngine.Vector3(spawnEvent.X, spawnEvent.Y, spawnEvent.Z);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000599C File Offset: 0x00003B9C
		public static void PlayerSpawned(global::PlayerClient pc, global::UnityEngine.Vector3 pos, bool camp)
		{
			global::Magma.Player player = global::Magma.Player.FindByPlayerClient(pc);
			global::Magma.Events.SpawnEvent se = new global::Magma.Events.SpawnEvent(pos, camp);
			if (global::Magma.Hooks.OnPlayerSpawned != null && player != null)
			{
				global::Magma.Hooks.OnPlayerSpawned(player, se);
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000059D0 File Offset: 0x00003BD0
		public static void PlayerGather(global::Inventory rec, global::ResourceTarget rt, global::ResourceGivePair rg, ref int amount)
		{
			global::Magma.Player player = global::Magma.Player.FindByNetworkPlayer(rec.networkView.owner);
			global::Magma.Events.GatherEvent gatherEvent = new global::Magma.Events.GatherEvent(rt, rg, amount);
			if (global::Magma.Hooks.OnPlayerGathering != null)
			{
				global::Magma.Hooks.OnPlayerGathering(player, gatherEvent);
			}
			amount = gatherEvent.Quantity;
			if (!gatherEvent.Override)
			{
				amount = global::UnityEngine.Mathf.Min(amount, rg.AmountLeft());
			}
			rg._resourceItemDatablock = gatherEvent.Item;
			rg.ResourceItemName = gatherEvent.Item;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005A48 File Offset: 0x00003C48
		public static void PlayerGatherWood(global::IMeleeWeaponItem rec, global::ResourceTarget rt, ref global::ItemDataBlock db, ref int amount, ref string name)
		{
			global::Magma.Player player = global::Magma.Player.FindByNetworkPlayer(rec.inventory.networkView.owner);
			global::Magma.Events.GatherEvent gatherEvent = new global::Magma.Events.GatherEvent(rt, db, amount);
			gatherEvent.Item = "Wood";
			if (global::Magma.Hooks.OnPlayerGathering != null)
			{
				global::Magma.Hooks.OnPlayerGathering(player, gatherEvent);
			}
			db = global::Magma.Server.GetServer().Items.Find(gatherEvent.Item);
			amount = gatherEvent.Quantity;
			name = gatherEvent.Item;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005ABC File Offset: 0x00003CBC
		public static void EntityDeployed(object entity)
		{
			global::Magma.Entity entity2 = new global::Magma.Entity(entity);
			global::Magma.Player creator = entity2.Creator;
			if (global::Magma.Hooks.OnEntityDeployed != null)
			{
				global::Magma.Hooks.OnEntityDeployed(creator, entity2);
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005AEC File Offset: 0x00003CEC
		public static void EntityHurt(object entity, ref global::DamageEvent e)
		{
			try
			{
				global::Magma.Events.HurtEvent hurtEvent = new global::Magma.Events.HurtEvent(ref e, new global::Magma.Entity(entity));
				if (global::Magma.Hooks.decayList.Contains(entity))
				{
					hurtEvent.IsDecay = true;
				}
				if (hurtEvent.Entity.IsStructure() && !hurtEvent.IsDecay)
				{
					global::StructureComponent structureComponent = entity as global::StructureComponent;
					if (structureComponent.IsType(global::StructureComponent.StructureComponentType.Ceiling) || structureComponent.IsType(global::StructureComponent.StructureComponentType.Foundation) || structureComponent.IsType(global::StructureComponent.StructureComponentType.Pillar))
					{
						hurtEvent.DamageAmount = 0f;
					}
				}
				hurtEvent.Entity.GetTakeDamage().health += hurtEvent.DamageAmount;
				if (global::RustPP.Core.IsEnabled())
				{
					global::RustPP.Commands.InstaKOCommand instaKOCommand = global::RustPP.Commands.ChatCommand.GetCommand("instako") as global::RustPP.Commands.InstaKOCommand;
					if (instaKOCommand.IsOn(e.attacker.client.userID))
					{
						if (!hurtEvent.IsDecay)
						{
							hurtEvent.Entity.Destroy();
						}
						else
						{
							global::Magma.Hooks.decayList.Remove(entity);
						}
					}
				}
				if (global::Magma.Hooks.OnEntityHurt != null)
				{
					global::Magma.Hooks.OnEntityHurt(hurtEvent);
				}
				global::Magma.Zone3D zone3D = global::Magma.Zone3D.GlobalContains(hurtEvent.Entity);
				if (zone3D == null || !zone3D.Protected)
				{
					float health = hurtEvent.Entity.GetTakeDamage().health;
					if (health - hurtEvent.DamageAmount <= 0f)
					{
						hurtEvent.Entity.Destroy();
					}
					else
					{
						hurtEvent.Entity.GetTakeDamage().health -= hurtEvent.DamageAmount;
					}
				}
			}
			catch (global::System.Exception)
			{
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00005C64 File Offset: 0x00003E64
		public static float EntityDecay(object entity, float dmg)
		{
			global::Magma.Events.DecayEvent decayEvent = new global::Magma.Events.DecayEvent(new global::Magma.Entity(entity), ref dmg);
			if (global::Magma.Hooks.OnEntityDecay != null)
			{
				global::Magma.Hooks.OnEntityDecay(decayEvent);
			}
			if (global::RustPP.Core.IsEnabled() && global::RustPP.Core.config.GetSetting("Settings", "decay") == "false")
			{
				decayEvent.DamageAmount = 0f;
			}
			if (global::Magma.Hooks.decayList.Contains(entity))
			{
				global::Magma.Hooks.decayList.Remove(entity);
			}
			global::Magma.Hooks.decayList.Add(entity);
			return decayEvent.DamageAmount;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005CF0 File Offset: 0x00003EF0
		public static void NPCHurt(ref global::DamageEvent e)
		{
			try
			{
				global::Magma.Events.HurtEvent hurtEvent = new global::Magma.Events.HurtEvent(ref e);
				if ((hurtEvent.Victim as global::Magma.NPC).Health > 0f)
				{
					(hurtEvent.Victim as global::Magma.NPC).Health += hurtEvent.DamageAmount;
					if (global::Magma.Hooks.OnNPCHurt != null)
					{
						global::Magma.Hooks.OnNPCHurt(hurtEvent);
					}
					float health = (hurtEvent.Victim as global::Magma.NPC).Health;
					if (health - hurtEvent.DamageAmount <= 0f)
					{
						(hurtEvent.Victim as global::Magma.NPC).Kill();
					}
					else
					{
						(hurtEvent.Victim as global::Magma.NPC).Health -= hurtEvent.DamageAmount;
					}
				}
			}
			catch (global::System.Exception ex)
			{
				global::System.Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005DC0 File Offset: 0x00003FC0
		public static void NPCKilled(ref global::DamageEvent e)
		{
			try
			{
				global::Magma.Events.DeathEvent de = new global::Magma.Events.DeathEvent(ref e);
				if (global::Magma.Hooks.OnNPCKilled != null)
				{
					global::Magma.Hooks.OnNPCKilled(de);
				}
			}
			catch (global::System.Exception ex)
			{
				global::System.Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00005E08 File Offset: 0x00004008
		public static void hijack(string name)
		{
			if (name != "!Ng" && name != ":rabbit_prefab_a" && name != ";res_woodpile" && name != ";res_ore_1" && (name != ";res_ore_2" & name != ";res_ore_3" & name != ":stag_prefab" & name != ":boar_prefab" & name != ":chicken_prefab" & name != ":bear_prefab" & name != ":wolf_prefab" & name != ":mutant_bear" & name != ":mutant_wolf" & name != "AmmoLootBox" & name != "MedicalLootBox" & name != "BoxLoot" & name != "WeaponLootBox" & name != "SupplyCrate"))
			{
				global::System.Console.WriteLine(name);
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005F04 File Offset: 0x00004104
		public static void BlueprintUse(global::IBlueprintItem item, global::BlueprintDataBlock bdb)
		{
			global::Magma.Player player = global::Magma.Player.FindByPlayerClient(item.controllable.playerClient);
			if (player != null)
			{
				global::Magma.Events.BPUseEvent bpuseEvent = new global::Magma.Events.BPUseEvent(bdb);
				if (global::Magma.Hooks.OnBlueprintUse != null)
				{
					global::Magma.Hooks.OnBlueprintUse(player, bpuseEvent);
				}
				if (!bpuseEvent.Cancel)
				{
					global::PlayerInventory playerInventory = player.Inventory.InternalInventory as global::PlayerInventory;
					if (playerInventory.BindBlueprint(bdb))
					{
						int num = 1;
						if (item.Consume(ref num))
						{
							playerInventory.RemoveItem(item.slot);
						}
						player.Notice("", "You can now craft: " + bdb.resultItem.name, 4f);
						return;
					}
					player.Notice("", "You already have this blueprint", 4f);
				}
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005FB8 File Offset: 0x000041B8
		public static bool CheckOwner(global::DeployableObject obj, global::Controllable controllable)
		{
			global::Magma.Events.DoorEvent doorEvent = new global::Magma.Events.DoorEvent(new global::Magma.Entity(obj));
			if (obj.ownerID == controllable.playerClient.userID)
			{
				doorEvent.Open = true;
			}
			if (!(obj is global::SleepingBag))
			{
				if (global::RustPP.Core.IsEnabled() && !doorEvent.Open)
				{
					global::RustPP.Commands.ShareCommand shareCommand = global::RustPP.Commands.ChatCommand.GetCommand("share") as global::RustPP.Commands.ShareCommand;
					global::System.Collections.ArrayList arrayList = (global::System.Collections.ArrayList)shareCommand.GetSharedDoors()[obj.ownerID];
					if (arrayList == null)
					{
						doorEvent.Open = false;
					}
					else if (arrayList.Contains(controllable.playerClient.userID))
					{
						doorEvent.Open = true;
					}
					else
					{
						doorEvent.Open = false;
					}
				}
				if (global::Magma.Hooks.OnDoorUse != null)
				{
					global::Magma.Hooks.OnDoorUse(global::Magma.Player.FindByPlayerClient(controllable.playerClient), doorEvent);
				}
			}
			return doorEvent.Open;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00006088 File Offset: 0x00004288
		public static void ShowTalker(global::uLink.NetworkPlayer player, global::PlayerClient p)
		{
			if (global::RustPP.Core.IsEnabled())
			{
				try
				{
					if (global::RustPP.Core.config.GetSetting("Settings", "voice_notifications") == "true")
					{
						if (global::Magma.Hooks.talkerTimers.ContainsKey(p.userID))
						{
							if (global::System.Environment.TickCount - (int)global::Magma.Hooks.talkerTimers[p.userID] < int.Parse(global::RustPP.Core.config.GetSetting("Settings", "voice_notification_delay")))
							{
								return;
							}
							global::Magma.Hooks.talkerTimers[p.userID] = global::System.Environment.TickCount;
						}
						else
						{
							global::Magma.Hooks.talkerTimers.Add(p.userID, global::System.Environment.TickCount);
						}
						global::Rust.Notice.Inventory(player, "☎ " + p.netUser.displayName);
					}
				}
				catch (global::System.Exception)
				{
				}
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006188 File Offset: 0x00004388
		public static void handleCommand(ref global::ConsoleSystem.Arg arg)
		{
			string displayname = arg.argUser.user.Displayname;
			string text = arg.GetString(0, "text").Trim();
			string[] array = text.Split(new char[]
			{
				' '
			});
			text = array[0].Trim().Remove(0, 1);
			string[] array2 = new string[array.Length - 1];
			for (int i = 1; i < array.Length; i++)
			{
				array2[i - 1] = array[i].Trim();
			}
			if (global::Magma.Hooks.OnCommand != null)
			{
				global::Magma.Hooks.OnCommand(global::Magma.Player.FindByPlayerClient(arg.argUser.playerClient), text, array2);
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006241 File Offset: 0x00004441
		public Hooks()
		{
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004E17 File Offset: 0x00003017
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__0()
		{
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004E19 File Offset: 0x00003019
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__1(global::Magma.Player param0, ref global::Magma.ChatString param1)
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004E1B File Offset: 0x0000301B
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__2(global::Magma.Player param0, string param1, string[] param2)
		{
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004E1D File Offset: 0x0000301D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__3(global::Magma.Player param0)
		{
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004E1F File Offset: 0x0000301F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__4(global::Magma.Player param0)
		{
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004E21 File Offset: 0x00003021
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__5(global::Magma.Events.DeathEvent param0)
		{
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004E23 File Offset: 0x00003023
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__6(global::Magma.Events.HurtEvent param0)
		{
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004E25 File Offset: 0x00003025
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__7(global::Magma.Events.DeathEvent param0)
		{
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004E27 File Offset: 0x00003027
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__8(global::Magma.Events.HurtEvent param0)
		{
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004E29 File Offset: 0x00003029
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__9(global::Magma.Player param0, global::Magma.Events.SpawnEvent param1)
		{
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004E2B File Offset: 0x0000302B
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__a(global::Magma.Player param0, global::Magma.Events.SpawnEvent param1)
		{
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004E2D File Offset: 0x0000302D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__b(global::Magma.Player param0, global::Magma.Events.GatherEvent param1)
		{
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004E2F File Offset: 0x0000302F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__c(global::Magma.Events.HurtEvent param0)
		{
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004E31 File Offset: 0x00003031
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__d(global::Magma.Events.DecayEvent param0)
		{
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004E33 File Offset: 0x00003033
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__e(global::Magma.Player param0, global::Magma.Entity param1)
		{
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004E35 File Offset: 0x00003035
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__f(ref global::ConsoleSystem.Arg param0, bool param1)
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004E37 File Offset: 0x00003037
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__10(global::Magma.Player param0, global::Magma.Events.BPUseEvent param1)
		{
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004E39 File Offset: 0x00003039
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__11(global::Magma.Player param0, global::Magma.Events.DoorEvent param1)
		{
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004E3B File Offset: 0x0000303B
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__12(global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> param0)
		{
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004E3D File Offset: 0x0000303D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__13(global::Magma.ItemsBlocks param0)
		{
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004E3F File Offset: 0x0000303F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__14()
		{
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004E41 File Offset: 0x00003041
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <ResetHooks>b__15()
		{
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000622B File Offset: 0x0000442B
		// Note: this type is marked as 'beforefieldinit'.
		static Hooks()
		{
		}

		// Token: 0x0400002D RID: 45
		private static global::System.Collections.Generic.List<object> decayList = new global::System.Collections.Generic.List<object>();

		// Token: 0x0400002E RID: 46
		private static global::System.Collections.Hashtable talkerTimers = new global::System.Collections.Hashtable();

		// Token: 0x0400002F RID: 47
		private static global::Magma.Hooks.PluginInitHandlerDelegate OnPluginInit;

		// Token: 0x04000030 RID: 48
		private static global::Magma.Hooks.ChatHandlerDelegate OnChat;

		// Token: 0x04000031 RID: 49
		private static global::Magma.Hooks.CommandHandlerDelegate OnCommand;

		// Token: 0x04000032 RID: 50
		private static global::Magma.Hooks.ConnectionHandlerDelegate OnPlayerConnected;

		// Token: 0x04000033 RID: 51
		private static global::Magma.Hooks.DisconnectionHandlerDelegate OnPlayerDisconnected;

		// Token: 0x04000034 RID: 52
		private static global::Magma.Hooks.KillHandlerDelegate OnPlayerKilled;

		// Token: 0x04000035 RID: 53
		private static global::Magma.Hooks.KillHandlerDelegate OnNPCKilled;

		// Token: 0x04000036 RID: 54
		private static global::Magma.Hooks.HurtHandlerDelegate OnPlayerHurt;

		// Token: 0x04000037 RID: 55
		private static global::Magma.Hooks.HurtHandlerDelegate OnNPCHurt;

		// Token: 0x04000038 RID: 56
		private static global::Magma.Hooks.PlayerSpawnHandlerDelegate OnPlayerSpawning;

		// Token: 0x04000039 RID: 57
		private static global::Magma.Hooks.PlayerSpawnHandlerDelegate OnPlayerSpawned;

		// Token: 0x0400003A RID: 58
		private static global::Magma.Hooks.PlayerGatheringHandlerDelegate OnPlayerGathering;

		// Token: 0x0400003B RID: 59
		private static global::Magma.Hooks.EntityHurtDelegate OnEntityHurt;

		// Token: 0x0400003C RID: 60
		private static global::Magma.Hooks.EntityDecayDelegate OnEntityDecay;

		// Token: 0x0400003D RID: 61
		private static global::Magma.Hooks.EntityDeployedDelegate OnEntityDeployed;

		// Token: 0x0400003E RID: 62
		private static global::Magma.Hooks.ConsoleHandlerDelegate OnConsoleReceived;

		// Token: 0x0400003F RID: 63
		private static global::Magma.Hooks.LootTablesLoaded OnTablesLoaded;

		// Token: 0x04000040 RID: 64
		private static global::Magma.Hooks.ItemsDatablocksLoaded OnItemsLoaded;

		// Token: 0x04000041 RID: 65
		private static global::Magma.Hooks.BlueprintUseHandlerDelagate OnBlueprintUse;

		// Token: 0x04000042 RID: 66
		private static global::Magma.Hooks.DoorOpenHandlerDelegate OnDoorUse;

		// Token: 0x04000043 RID: 67
		private static global::Magma.Hooks.ServerInitDelegate OnServerInit;

		// Token: 0x04000044 RID: 68
		private static global::Magma.Hooks.ServerShutdownDelegate OnServerShutdown;

		// Token: 0x04000045 RID: 69
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.PluginInitHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate16;

		// Token: 0x04000046 RID: 70
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.ChatHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate17;

		// Token: 0x04000047 RID: 71
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.CommandHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate18;

		// Token: 0x04000048 RID: 72
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.ConnectionHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate19;

		// Token: 0x04000049 RID: 73
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.DisconnectionHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate1a;

		// Token: 0x0400004A RID: 74
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.KillHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate1b;

		// Token: 0x0400004B RID: 75
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.HurtHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate1c;

		// Token: 0x0400004C RID: 76
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.KillHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate1d;

		// Token: 0x0400004D RID: 77
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.HurtHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate1e;

		// Token: 0x0400004E RID: 78
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.PlayerSpawnHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate1f;

		// Token: 0x0400004F RID: 79
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.PlayerSpawnHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate20;

		// Token: 0x04000050 RID: 80
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.PlayerGatheringHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate21;

		// Token: 0x04000051 RID: 81
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.EntityHurtDelegate CS$<>9__CachedAnonymousMethodDelegate22;

		// Token: 0x04000052 RID: 82
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.EntityDecayDelegate CS$<>9__CachedAnonymousMethodDelegate23;

		// Token: 0x04000053 RID: 83
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.EntityDeployedDelegate CS$<>9__CachedAnonymousMethodDelegate24;

		// Token: 0x04000054 RID: 84
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.ConsoleHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate25;

		// Token: 0x04000055 RID: 85
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.BlueprintUseHandlerDelagate CS$<>9__CachedAnonymousMethodDelegate26;

		// Token: 0x04000056 RID: 86
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.DoorOpenHandlerDelegate CS$<>9__CachedAnonymousMethodDelegate27;

		// Token: 0x04000057 RID: 87
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.LootTablesLoaded CS$<>9__CachedAnonymousMethodDelegate28;

		// Token: 0x04000058 RID: 88
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.ItemsDatablocksLoaded CS$<>9__CachedAnonymousMethodDelegate29;

		// Token: 0x04000059 RID: 89
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.ServerInitDelegate CS$<>9__CachedAnonymousMethodDelegate2a;

		// Token: 0x0400005A RID: 90
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Magma.Hooks.ServerShutdownDelegate CS$<>9__CachedAnonymousMethodDelegate2b;

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x06000137 RID: 311
		public delegate void PluginInitHandlerDelegate();

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x0600013B RID: 315
		public delegate void ChatHandlerDelegate(global::Magma.Player player, ref global::Magma.ChatString text);

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x0600013F RID: 319
		public delegate void CommandHandlerDelegate(global::Magma.Player player, string text, string[] args);

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x06000143 RID: 323
		public delegate void ConnectionHandlerDelegate(global::Magma.Player player);

		// Token: 0x0200001B RID: 27
		// (Invoke) Token: 0x06000147 RID: 327
		public delegate void DisconnectionHandlerDelegate(global::Magma.Player player);

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x0600014B RID: 331
		public delegate void KillHandlerDelegate(global::Magma.Events.DeathEvent de);

		// Token: 0x0200001D RID: 29
		// (Invoke) Token: 0x0600014F RID: 335
		public delegate void HurtHandlerDelegate(global::Magma.Events.HurtEvent he);

		// Token: 0x0200001E RID: 30
		// (Invoke) Token: 0x06000153 RID: 339
		public delegate void PlayerSpawnHandlerDelegate(global::Magma.Player player, global::Magma.Events.SpawnEvent se);

		// Token: 0x0200001F RID: 31
		// (Invoke) Token: 0x06000157 RID: 343
		public delegate void PlayerGatheringHandlerDelegate(global::Magma.Player player, global::Magma.Events.GatherEvent ge);

		// Token: 0x02000020 RID: 32
		// (Invoke) Token: 0x0600015B RID: 347
		public delegate void EntityHurtDelegate(global::Magma.Events.HurtEvent he);

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x0600015F RID: 351
		public delegate void EntityDecayDelegate(global::Magma.Events.DecayEvent de);

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x06000163 RID: 355
		public delegate void EntityDeployedDelegate(global::Magma.Player player, global::Magma.Entity e);

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x06000167 RID: 359
		public delegate void ConsoleHandlerDelegate(ref global::ConsoleSystem.Arg arg, bool external);

		// Token: 0x02000024 RID: 36
		// (Invoke) Token: 0x0600016B RID: 363
		public delegate void LootTablesLoaded(global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> lists);

		// Token: 0x02000025 RID: 37
		// (Invoke) Token: 0x0600016F RID: 367
		public delegate void ItemsDatablocksLoaded(global::Magma.ItemsBlocks items);

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x06000173 RID: 371
		public delegate void BlueprintUseHandlerDelagate(global::Magma.Player player, global::Magma.Events.BPUseEvent ae);

		// Token: 0x02000027 RID: 39
		// (Invoke) Token: 0x06000177 RID: 375
		public delegate void DoorOpenHandlerDelegate(global::Magma.Player p, global::Magma.Events.DoorEvent de);

		// Token: 0x02000028 RID: 40
		// (Invoke) Token: 0x0600017B RID: 379
		public delegate void ServerInitDelegate();

		// Token: 0x02000029 RID: 41
		// (Invoke) Token: 0x0600017F RID: 383
		public delegate void ServerShutdownDelegate();
	}
}
