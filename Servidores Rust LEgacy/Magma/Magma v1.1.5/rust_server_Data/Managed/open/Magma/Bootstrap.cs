using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Timers;
using Facepunch;
using Rust.Steam;
using RustPP;
using UnityEngine;

namespace Magma
{
	// Token: 0x02000065 RID: 101
	public class Bootstrap : global::Facepunch.MonoBehaviour
	{
		// Token: 0x06000312 RID: 786 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
		static Bootstrap()
		{
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000F2B4 File Offset: 0x0000D4B4
		public static void AttachBootstrap()
		{
			try
			{
				global::Magma.Bootstrap bootstrap = new global::Magma.Bootstrap();
				global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(bootstrap.GetType().FullName);
				gameObject.AddComponent(bootstrap.GetType());
				global::UnityEngine.Debug.Log("Loaded: Magma");
			}
			catch (global::System.Exception)
			{
				global::UnityEngine.Debug.Log("Error while loading Magma !");
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000F310 File Offset: 0x0000D510
		public void Awake()
		{
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000F324 File Offset: 0x0000D524
		public void Start()
		{
			if (global::System.IO.File.Exists(global::Magma.Util.GetServerFolder() + "\\MagmaDirectory.cfg"))
			{
				global::IniParser iniParser = new global::IniParser(global::Magma.Util.GetServerFolder() + "\\MagmaDirectory.cfg");
				global::Magma.Data.PATH = iniParser.GetSetting("Settings", "Directory");
			}
			else
			{
				global::Magma.Data.PATH = global::Magma.Util.GetRootFolder() + "\\save\\Magma\\";
			}
			global::Rust.Steam.Server.SetModded();
			global::Rust.Steam.Server.Official = false;
			global::Magma.PluginEngine.GetPluginEngine();
			global::RustPP.Core.config = global::Magma.Data.GetData().GetRPPConfig();
			if (global::RustPP.Core.config != null && global::RustPP.Core.IsEnabled())
			{
				global::System.Timers.Timer timer = new global::System.Timers.Timer();
				timer.Interval = 30000.0;
				timer.AutoReset = false;
				timer.Elapsed += delegate(object x, global::System.Timers.ElapsedEventArgs y)
				{
					global::RustPP.TimedEvents.startEvents();
				};
				global::RustPP.TimedEvents.startEvents();
				timer.Start();
			}
			global::Magma.Hooks.ServerStarted();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000F404 File Offset: 0x0000D604
		public Bootstrap()
		{
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000F31D File Offset: 0x0000D51D
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <Start>b__0(object x, global::System.Timers.ElapsedEventArgs y)
		{
			global::RustPP.TimedEvents.startEvents();
		}

		// Token: 0x040000A5 RID: 165
		public static string Version = "1.1.5";

		// Token: 0x040000A6 RID: 166
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Timers.ElapsedEventHandler CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
