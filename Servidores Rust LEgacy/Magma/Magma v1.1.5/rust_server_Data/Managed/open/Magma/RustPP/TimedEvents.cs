using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using Magma;
using UnityEngine;

namespace RustPP
{
	// Token: 0x02000060 RID: 96
	public class TimedEvents
	{
		// Token: 0x060002AE RID: 686 RVA: 0x0000D99B File Offset: 0x0000BB9B
		static TimedEvents()
		{
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000D9B4 File Offset: 0x0000BBB4
		public static void startEvents()
		{
			if (!global::RustPP.TimedEvents.init)
			{
				global::RustPP.TimedEvents.init = true;
				if (global::RustPP.Core.config.GetSetting("Settings", "decay") == "false")
				{
					global::decay.decaytickrate = float.MaxValue;
					global::decay.deploy_maxhealth_sec = 0f;
				}
				if (global::RustPP.Core.config.GetSetting("Settings", "pvp") == "true")
				{
					global::server.pvp = true;
				}
				else
				{
					global::server.pvp = false;
				}
				if (global::RustPP.Core.config.GetSetting("Settings", "instant_craft") == "true")
				{
					global::crafting.instant = true;
				}
				else
				{
					global::crafting.instant = false;
				}
				if (global::RustPP.Core.config.GetSetting("Settings", "sleepers") == "true")
				{
					global::sleepers.on = true;
				}
				else
				{
					global::sleepers.on = false;
				}
				if (global::RustPP.Core.config.GetSetting("Settings", "enforce_truth") == "true")
				{
					global::truth.punish = true;
				}
				else
				{
					global::truth.punish = false;
				}
				if (global::RustPP.Core.config.GetSetting("Settings", "voice_proximity") == "false")
				{
					global::voice.distance = 2.1474836E+09f;
				}
				if (global::RustPP.Core.config.GetSetting("Settings", "notice_enabled") == "true")
				{
					global::System.Timers.Timer timer = new global::System.Timers.Timer();
					timer.Interval = (double)int.Parse(global::RustPP.Core.config.GetSetting("Settings", "notice_interval"));
					timer.AutoReset = true;
					timer.Elapsed += delegate(object x, global::System.Timers.ElapsedEventArgs y)
					{
						global::RustPP.TimedEvents.advertise_begin();
					};
					timer.Start();
				}
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000DB60 File Offset: 0x0000BD60
		private static void airdrop_begin()
		{
			int num = int.Parse(global::RustPP.Core.config.GetSetting("Settings", "amount_of_airdrops"));
			for (int i = 0; i < num; i++)
			{
				global::SupplyDropZone.CallAirDrop();
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000DBA0 File Offset: 0x0000BDA0
		public static void shutdown()
		{
			global::RustPP.TimedEvents.time = int.Parse(global::RustPP.Core.config.GetSetting("Settings", "shutdown_countdown"));
			global::System.Timers.Timer timer = new global::System.Timers.Timer();
			timer.Interval = 10000.0;
			timer.AutoReset = true;
			timer.Elapsed += delegate(object x, global::System.Timers.ElapsedEventArgs y)
			{
				global::RustPP.TimedEvents.shutdown_tick();
			};
			timer.Start();
			global::RustPP.TimedEvents.shutdown_tick();
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000DC18 File Offset: 0x0000BE18
		public static void shutdown_tick()
		{
			if (global::RustPP.TimedEvents.time == 0)
			{
				global::Magma.Util.sayAll("Server Shutdown NOW!");
				try
				{
					global::AvatarSaveProc.SaveAll();
					global::ServerSaveManager.AutoSave();
					global::RustPP.Helper.CreateSaves();
				}
				catch (global::System.Exception)
				{
				}
				global::System.Diagnostics.Process.GetCurrentProcess().Kill();
			}
			else
			{
				global::Magma.Util.sayAll("Server Shutting down in " + global::RustPP.TimedEvents.time + " seconds");
			}
			global::RustPP.TimedEvents.time -= 0xA;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000DC94 File Offset: 0x0000BE94
		private static void advertise_begin()
		{
			for (int i = 0; i < int.Parse(global::RustPP.Core.config.GetSetting("Settings", "notice_messages_amount")); i++)
			{
				global::Magma.Util.sayAll(global::RustPP.Core.config.GetSetting("Settings", "notice" + (i + 1)));
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		public static void savealldata()
		{
			try
			{
				global::AvatarSaveProc.SaveAll();
				global::ServerSaveManager.AutoSave();
				global::RustPP.Helper.CreateSaves();
			}
			catch (global::System.Exception)
			{
				global::UnityEngine.Debug.Log("Error while auto-saving !");
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000DD2C File Offset: 0x0000BF2C
		public TimedEvents()
		{
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000D9AA File Offset: 0x0000BBAA
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <startEvents>b__0(object x, global::System.Timers.ElapsedEventArgs y)
		{
			global::RustPP.TimedEvents.advertise_begin();
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000DB98 File Offset: 0x0000BD98
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <shutdown>b__2(object x, global::System.Timers.ElapsedEventArgs y)
		{
			global::RustPP.TimedEvents.shutdown_tick();
		}

		// Token: 0x04000095 RID: 149
		public static bool init = false;

		// Token: 0x04000096 RID: 150
		public static int time = 0x3C;

		// Token: 0x04000097 RID: 151
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Timers.ElapsedEventHandler CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x04000098 RID: 152
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Timers.ElapsedEventHandler CS$<>9__CachedAnonymousMethodDelegate3;
	}
}
