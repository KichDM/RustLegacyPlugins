using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Facepunch;
using Facepunch.Utility;
using Magma;
using Rust.Steam;
using uLink;
using UnityEngine;

// Token: 0x02000764 RID: 1892
[global::UnityEngine.RequireComponent(typeof(global::uLinkNetworkView))]
public class ServerInit : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003EFE RID: 16126 RVA: 0x000E0A2C File Offset: 0x000DEC2C
	public ServerInit()
	{
	}

	// Token: 0x06003EFF RID: 16127 RVA: 0x000E0A34 File Offset: 0x000DEC34
	private void Awake()
	{
		global::UnityEngine.Debug.Log("rust.");
		global::server.maxplayers = global::Facepunch.Utility.CommandLine.GetSwitchInt("-maxplayers", 0x100);
		global::server.map = global::Facepunch.Utility.CommandLine.GetSwitch("-map", "rust_island_2013");
		global::server.port = global::Facepunch.Utility.CommandLine.GetSwitchInt("-port", 0x6D6F);
		global::server.hostname = global::Facepunch.Utility.CommandLine.GetSwitch("-hostname", "Untitled Rust Server");
		global::server.lan = global::Facepunch.Utility.CommandLine.HasSwitch("-lan");
		global::server.datadir = global::Facepunch.Utility.CommandLine.GetSwitch("-datadir", "serverdata/");
		global::server.steamgroup = global::Facepunch.Utility.CommandLine.GetSwitch("-steamgroup", "0");
		if (global::Facepunch.Utility.CommandLine.HasSwitch("-ip"))
		{
			global::server.ip = global::Facepunch.Utility.CommandLine.GetSwitch("-ip", global::server.ip);
		}
		if (global::server.datadir[global::server.datadir.Length - 1] != '/')
		{
			global::server.datadir += '/';
		}
		global::UnityEngine.Debug.Log(" Server DataDir\n  " + global::System.IO.Path.GetFullPath(global::server.datadir));
		if (!global::System.IO.Directory.Exists(global::server.datadir))
		{
			global::UnityEngine.Debug.Log("Data Dir doesn't exist, creating \"" + global::server.datadir + "\"");
			global::System.IO.Directory.CreateDirectory(global::server.datadir);
			global::System.IO.Directory.CreateDirectory(global::server.datadir + "cfg");
			global::System.IO.Directory.CreateDirectory(global::server.datadir + "logs");
		}
		global::server.timesrc = 1;
		if (global::Facepunch.Utility.CommandLine.HasSwitch("-cfg"))
		{
			string @switch = global::Facepunch.Utility.CommandLine.GetSwitch("-cfg", string.Empty);
			if (global::System.IO.File.Exists(@switch))
			{
				string text = global::System.IO.File.ReadAllText(@switch);
				if (!string.IsNullOrEmpty(text))
				{
					global::UnityEngine.Debug.Log("Running " + @switch);
					global::ConsoleSystem.RunFile(text);
				}
			}
		}
		if (global::Facepunch.Utility.CommandLine.GetSwitch("-official", "no") == "jgue7gopbo")
		{
			global::UnityEngine.Debug.Log(" This is an official server.");
			global::Rust.Steam.Server.SetOfficial();
		}
		global::BanList.Load();
		global::ConsoleSystem.Run("config.load", false);
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		global::uLink.NetworkConfig config = global::NetCull.config;
		global::Magma.Bootstrap.AttachBootstrap();
		config.batchSendAtEndOfFrame = false;
		global::ServerRuntime.TargetFrameRate = global::server.framerate;
		global::NetCull.config.timeoutDelay = (float)global::server.clienttimeout;
		global::RCon.Setup();
		base.StartCoroutine("StartServerProc");
	}

	// Token: 0x06003F00 RID: 16128 RVA: 0x000E0C7C File Offset: 0x000DEE7C
	private global::System.Collections.IEnumerator StartServerProc()
	{
		global::RustLoader loader = (global::RustLoader)global::UnityEngine.Object.Instantiate(this.loaderPrefab);
		loader.ServerInit();
		while (loader)
		{
			yield return null;
		}
		global::NetCull.sendRate = global::server.sendrate;
		global::uLink.Network.licenseKey = "62BH-3PQC-CS7E-DCF5";
		global::NetCull.InitializeServer(global::server.maxplayers, global::server.port);
		global::NetCull.maxConnections = global::server.maxplayers;
		global::UnityEngine.Debug.Log(" FrameRate: " + global::server.framerate);
		global::UnityEngine.Debug.Log(" SendRate: " + global::server.sendrate);
		global::UnityEngine.Debug.Log(" Timeout: " + global::server.clienttimeout);
		global::UnityEngine.Debug.Log(" Players: " + global::server.maxplayers);
		global::UnityEngine.Debug.Log(" Port: " + global::server.port);
		global::UnityEngine.Debug.Log(" PVP: " + global::server.pvp);
		yield break;
	}

	// Token: 0x06003F01 RID: 16129 RVA: 0x000E0C98 File Offset: 0x000DEE98
	private void uLink_OnServerInitialized()
	{
		global::UnityEngine.GameObject prefab;
		if (!global::Facepunch.Bundling.Load<global::UnityEngine.GameObject>("content/network/ServerManagement", out prefab))
		{
			global::UnityEngine.Debug.LogError("Did not load server management!");
			return;
		}
		global::NetCull.InstantiateClassic(prefab, global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.identity, 0);
		global::NetCull.isMessageQueueRunning = false;
		global::ServerQuitResponder.WillChangeLevels();
		base.StartCoroutine("LoadLevel", global::server.map);
		global::Rust.Steam.Server.Init();
	}

	// Token: 0x06003F02 RID: 16130 RVA: 0x000E0CF4 File Offset: 0x000DEEF4
	private global::System.Collections.IEnumerator LoadLevel(string levelName)
	{
		yield return global::RustLevel.Load(levelName);
		global::UnityEngine.Debug.Log("Server Initialized");
		global::UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x0400206B RID: 8299
	public global::RustLoader loaderPrefab;

	// Token: 0x02000765 RID: 1893
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <StartServerProc>c__Iterator4E : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06003F03 RID: 16131 RVA: 0x000E0D20 File Offset: 0x000DEF20
		public <StartServerProc>c__Iterator4E()
		{
		}

		// Token: 0x17000BDD RID: 3037
		// (get) Token: 0x06003F04 RID: 16132 RVA: 0x000E0D28 File Offset: 0x000DEF28
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x06003F05 RID: 16133 RVA: 0x000E0D30 File Offset: 0x000DEF30
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003F06 RID: 16134 RVA: 0x000E0D38 File Offset: 0x000DEF38
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				loader = (global::RustLoader)global::UnityEngine.Object.Instantiate(this.loaderPrefab);
				loader.ServerInit();
				break;
			case 1U:
				break;
			default:
				return false;
			}
			if (loader)
			{
				this.$current = null;
				this.$PC = 1;
				return true;
			}
			global::NetCull.sendRate = global::server.sendrate;
			global::uLink.Network.licenseKey = "62BH-3PQC-CS7E-DCF5";
			global::NetCull.InitializeServer(global::server.maxplayers, global::server.port);
			global::NetCull.maxConnections = global::server.maxplayers;
			global::UnityEngine.Debug.Log(" FrameRate: " + global::server.framerate);
			global::UnityEngine.Debug.Log(" SendRate: " + global::server.sendrate);
			global::UnityEngine.Debug.Log(" Timeout: " + global::server.clienttimeout);
			global::UnityEngine.Debug.Log(" Players: " + global::server.maxplayers);
			global::UnityEngine.Debug.Log(" Port: " + global::server.port);
			global::UnityEngine.Debug.Log(" PVP: " + global::server.pvp);
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003F07 RID: 16135 RVA: 0x000E0E84 File Offset: 0x000DF084
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003F08 RID: 16136 RVA: 0x000E0E90 File Offset: 0x000DF090
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400206C RID: 8300
		internal global::RustLoader <loader>__0;

		// Token: 0x0400206D RID: 8301
		internal int $PC;

		// Token: 0x0400206E RID: 8302
		internal object $current;

		// Token: 0x0400206F RID: 8303
		internal global::ServerInit <>f__this;
	}

	// Token: 0x02000766 RID: 1894
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <LoadLevel>c__Iterator4F : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06003F09 RID: 16137 RVA: 0x000E0E98 File Offset: 0x000DF098
		public <LoadLevel>c__Iterator4F()
		{
		}

		// Token: 0x17000BDF RID: 3039
		// (get) Token: 0x06003F0A RID: 16138 RVA: 0x000E0EA0 File Offset: 0x000DF0A0
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x06003F0B RID: 16139 RVA: 0x000E0EA8 File Offset: 0x000DF0A8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003F0C RID: 16140 RVA: 0x000E0EB0 File Offset: 0x000DF0B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = global::RustLevel.Load(levelName);
				this.$PC = 1;
				return true;
			case 1U:
				global::UnityEngine.Debug.Log("Server Initialized");
				global::UnityEngine.Object.Destroy(base.gameObject);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06003F0D RID: 16141 RVA: 0x000E0F24 File Offset: 0x000DF124
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003F0E RID: 16142 RVA: 0x000E0F30 File Offset: 0x000DF130
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002070 RID: 8304
		internal string levelName;

		// Token: 0x04002071 RID: 8305
		internal int $PC;

		// Token: 0x04002072 RID: 8306
		internal object $current;

		// Token: 0x04002073 RID: 8307
		internal string <$>levelName;

		// Token: 0x04002074 RID: 8308
		internal global::ServerInit <>f__this;
	}
}
