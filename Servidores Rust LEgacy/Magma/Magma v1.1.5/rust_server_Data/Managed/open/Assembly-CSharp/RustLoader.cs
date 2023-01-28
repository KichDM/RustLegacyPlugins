using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;
using Facepunch.Load;
using Facepunch.Load.Downloaders;
using Facepunch.Traits;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class RustLoader : global::Facepunch.MonoBehaviour, global::IRustLoaderTasks
{
	// Token: 0x06000230 RID: 560 RVA: 0x0000C008 File Offset: 0x0000A208
	public RustLoader()
	{
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x06000231 RID: 561 RVA: 0x0000C01C File Offset: 0x0000A21C
	bool global::IRustLoaderTasks.Active
	{
		get
		{
			return this.loader != null;
		}
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x06000232 RID: 562 RVA: 0x0000C02C File Offset: 0x0000A22C
	global::Facepunch.Load.IDownloadTask global::IRustLoaderTasks.Overall
	{
		get
		{
			return this.loader;
		}
	}

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x06000233 RID: 563 RVA: 0x0000C034 File Offset: 0x0000A234
	global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask> global::IRustLoaderTasks.Groups
	{
		get
		{
			if (this.loader == null)
			{
				yield break;
			}
			foreach (global::Facepunch.Load.Group group in this.loader.Groups)
			{
				yield return group;
			}
			yield break;
		}
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x06000234 RID: 564 RVA: 0x0000C058 File Offset: 0x0000A258
	global::Facepunch.Load.IDownloadTask global::IRustLoaderTasks.ActiveGroup
	{
		get
		{
			if (this.loader == null)
			{
				return null;
			}
			return this.loader.CurrentGroup;
		}
	}

	// Token: 0x17000064 RID: 100
	// (get) Token: 0x06000235 RID: 565 RVA: 0x0000C074 File Offset: 0x0000A274
	global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask> global::IRustLoaderTasks.ActiveJobs
	{
		get
		{
			if (this.loader == null)
			{
				yield break;
			}
			global::Facepunch.Load.Group currentGroup = this.loader.CurrentGroup;
			if (currentGroup == null)
			{
				yield break;
			}
			foreach (global::Facepunch.Load.Job task in currentGroup.Jobs)
			{
				yield return task;
			}
			yield break;
		}
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x06000236 RID: 566 RVA: 0x0000C098 File Offset: 0x0000A298
	global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask> global::IRustLoaderTasks.Jobs
	{
		get
		{
			if (this.loader == null)
			{
				yield break;
			}
			foreach (global::Facepunch.Load.Job task in this.loader.Jobs)
			{
				yield return task;
			}
			yield break;
		}
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0000C0BC File Offset: 0x0000A2BC
	public void ServerInit()
	{
		global::UnityEngine.Object.Destroy(base.GetComponent<global::RustLoaderInstantiateOnComplete>());
	}

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x06000238 RID: 568 RVA: 0x0000C0CC File Offset: 0x0000A2CC
	public global::IRustLoaderTasks Tasks
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
	public void SetPreloadedManifest(string text, string path, string error)
	{
		if (this.loader != null)
		{
			throw new global::System.InvalidOperationException("The loader has already begun. Its too late!");
		}
		this.preloadedJsonLoaderText = text;
		this.preloadedJsonLoaderRoot = (path ?? string.Empty);
		this.preloadedJsonLoader = true;
		this.preloadedJsonLoaderError = error;
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0000C11C File Offset: 0x0000A31C
	public void AddMessageReceiver(global::UnityEngine.GameObject newReceiver)
	{
		if (!newReceiver)
		{
			return;
		}
		if (this.messageReceivers == null)
		{
			this.messageReceivers = new global::UnityEngine.GameObject[]
			{
				newReceiver
			};
		}
		else if (global::System.Array.IndexOf<global::UnityEngine.GameObject>(this.messageReceivers, newReceiver) == -1)
		{
			global::System.Array.Resize<global::UnityEngine.GameObject>(ref this.messageReceivers, this.messageReceivers.Length + 1);
			this.messageReceivers[this.messageReceivers.Length - 1] = newReceiver;
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0000C190 File Offset: 0x0000A390
	private void DispatchLoadMessage(string message, object value)
	{
		if (this.messageReceivers != null)
		{
			foreach (global::UnityEngine.GameObject gameObject in this.messageReceivers)
			{
				if (gameObject)
				{
					gameObject.SendMessage(message, value, 1);
				}
			}
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0000C1DC File Offset: 0x0000A3DC
	private void Callback_OnBundleLoaded(global::UnityEngine.AssetBundle bundle, global::Facepunch.Load.Item item)
	{
		this.DispatchLoadMessage("OnRustBundleLoaded", this);
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0000C1EC File Offset: 0x0000A3EC
	private void Callback_OnBundleGroupLoaded(global::UnityEngine.AssetBundle[] bundles, global::Facepunch.Load.Item[] items)
	{
		this.DispatchLoadMessage("OnRustBundleGroupLoaded", this);
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0000C1FC File Offset: 0x0000A3FC
	private void Callback_OnBundleAllLoaded(global::UnityEngine.AssetBundle[] bundles, global::Facepunch.Load.Item[] items)
	{
		this.DispatchLoadMessage("OnRustBundleCompleteLoaded", this);
	}

	// Token: 0x0600023F RID: 575 RVA: 0x0000C20C File Offset: 0x0000A40C
	private global::System.Collections.IEnumerator Start()
	{
		this.DispatchLoadMessage("OnRustBundleFetching", this);
		string loaderText;
		string bundleDirectory;
		string loaderError;
		if (this.preloadedJsonLoader)
		{
			loaderText = this.preloadedJsonLoaderText;
			bundleDirectory = (this.preloadedJsonLoaderRoot ?? string.Empty);
			loaderError = this.preloadedJsonLoaderError;
			this.preloadedJsonLoaderText = null;
			this.preloadedJsonLoaderRoot = null;
			this.preloadedJsonLoaderError = null;
		}
		else
		{
			bundleDirectory = this.releaseBundleLoaderFilePath.Remove(this.releaseBundleLoaderFilePath.LastIndexOfAny(new char[]
			{
				'\\',
				'/'
			}) + 1);
			try
			{
				loaderText = global::System.IO.File.ReadAllText(this.releaseBundleLoaderFilePath);
				loaderError = string.Empty;
			}
			catch (global::System.Exception ex)
			{
				global::System.Exception e = ex;
				loaderText = string.Empty;
				loaderError = e.ToString();
				if (string.IsNullOrEmpty(loaderError))
				{
					loaderError = "Failed";
				}
			}
		}
		if (!string.IsNullOrEmpty(loaderError))
		{
			global::UnityEngine.Debug.LogError(loaderError);
			yield break;
		}
		this.loader = global::Facepunch.Load.Loader.CreateFromText(loaderText, bundleDirectory, new global::Facepunch.Load.Downloaders.FileDispatch());
		global::Facepunch.Bundling.BindToLoader(this.loader);
		global::Facepunch.Bundling.OnceLoaded += global::RustLoader.OnResourcesLoaded;
		this.DispatchLoadMessage("OnRustBundlePreLoad", this);
		this.loader.StartLoading();
		this.DispatchLoadMessage("OnRustBundleLoadStart", this);
		yield return base.StartCoroutine(this.loader.WaitEnumerator);
		this.DispatchLoadMessage("OnRustBundleLoadComplete", this);
		try
		{
			this.loader.Dispose();
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception e2 = ex2;
			global::UnityEngine.Debug.LogException(e2);
		}
		finally
		{
			this.loader = null;
		}
		yield return global::UnityEngine.Resources.UnloadUnusedAssets();
		base.BroadcastMessage("OnRustLoadedFirst", 1);
		this.DispatchLoadMessage("OnRustLoaded", this);
		this.DispatchLoadMessage("OnRustReady", this);
		if (this.destroyGameObjectOnceLoaded)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			global::UnityEngine.Object.Destroy(this);
		}
		yield break;
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0000C228 File Offset: 0x0000A428
	private static void OnResourcesLoaded()
	{
		foreach (global::BaseTraitMap baseTraitMap in global::Facepunch.Bundling.LoadAll<global::BaseTraitMap>())
		{
			if (baseTraitMap)
			{
				try
				{
					global::Facepunch.Traits.Binder.BindMap(baseTraitMap);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex, baseTraitMap);
				}
			}
		}
		global::DatablockDictionary.Initialize();
		foreach (global::NetMainPrefab netMainPrefab in global::Facepunch.Bundling.LoadAll<global::NetMainPrefab>())
		{
			try
			{
				netMainPrefab.Register(true);
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2, netMainPrefab);
			}
		}
		foreach (global::uLinkNetworkView uLinkNetworkView in global::Facepunch.Bundling.LoadAll<global::uLinkNetworkView>())
		{
			try
			{
				global::NetCull.RegisterNetAutoPrefab(uLinkNetworkView);
			}
			catch (global::System.Exception ex3)
			{
				global::UnityEngine.Debug.LogException(ex3, uLinkNetworkView);
			}
		}
		global::NGC.Register(global::NGCConfiguration.Load());
	}

	// Token: 0x0400016D RID: 365
	[global::UnityEngine.SerializeField]
	public string releaseBundleLoaderFilePath = "bundles/manifest.txt";

	// Token: 0x0400016E RID: 366
	[global::UnityEngine.SerializeField]
	public global::UnityEngine.GameObject[] messageReceivers;

	// Token: 0x0400016F RID: 367
	[global::System.NonSerialized]
	private global::Facepunch.Load.Loader loader;

	// Token: 0x04000170 RID: 368
	public bool destroyGameObjectOnceLoaded;

	// Token: 0x04000171 RID: 369
	[global::System.NonSerialized]
	private string preloadedJsonLoaderText;

	// Token: 0x04000172 RID: 370
	[global::System.NonSerialized]
	private string preloadedJsonLoaderRoot;

	// Token: 0x04000173 RID: 371
	[global::System.NonSerialized]
	private bool preloadedJsonLoader;

	// Token: 0x04000174 RID: 372
	[global::System.NonSerialized]
	private string preloadedJsonLoaderError;

	// Token: 0x0200003D RID: 61
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator7 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask>, global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask>
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0000C360 File Offset: 0x0000A560
		public <>c__Iterator7()
		{
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0000C368 File Offset: 0x0000A568
		global::Facepunch.Load.IDownloadTask global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0000C370 File Offset: 0x0000A570
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000C378 File Offset: 0x0000A578
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Facepunch.Load.IDownloadTask>.GetEnumerator();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000C380 File Offset: 0x0000A580
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask> global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::RustLoader.<>c__Iterator7 <>c__Iterator = new global::RustLoader.<>c__Iterator7();
			<>c__Iterator.<>f__this = this;
			return <>c__Iterator;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000C3B4 File Offset: 0x0000A5B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (this.loader == null)
				{
					return false;
				}
				groups = this.loader.Groups;
				i = 0;
				break;
			case 1U:
				i++;
				break;
			default:
				return false;
			}
			if (i < groups.Length)
			{
				group = groups[i];
				this.$current = group;
				this.$PC = 1;
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000C474 File Offset: 0x0000A674
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000C480 File Offset: 0x0000A680
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000175 RID: 373
		internal global::Facepunch.Load.Group[] <$s_68>__0;

		// Token: 0x04000176 RID: 374
		internal int <$s_69>__1;

		// Token: 0x04000177 RID: 375
		internal global::Facepunch.Load.Group <group>__2;

		// Token: 0x04000178 RID: 376
		internal int $PC;

		// Token: 0x04000179 RID: 377
		internal global::Facepunch.Load.IDownloadTask $current;

		// Token: 0x0400017A RID: 378
		internal global::RustLoader <>f__this;
	}

	// Token: 0x0200003E RID: 62
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator8 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask>, global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask>
	{
		// Token: 0x06000249 RID: 585 RVA: 0x0000C488 File Offset: 0x0000A688
		public <>c__Iterator8()
		{
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0000C490 File Offset: 0x0000A690
		global::Facepunch.Load.IDownloadTask global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000C498 File Offset: 0x0000A698
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000C4A0 File Offset: 0x0000A6A0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Facepunch.Load.IDownloadTask>.GetEnumerator();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000C4A8 File Offset: 0x0000A6A8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask> global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::RustLoader.<>c__Iterator8 <>c__Iterator = new global::RustLoader.<>c__Iterator8();
			<>c__Iterator.<>f__this = this;
			return <>c__Iterator;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000C4DC File Offset: 0x0000A6DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (this.loader == null)
				{
					return false;
				}
				currentGroup = this.loader.CurrentGroup;
				if (currentGroup == null)
				{
					return false;
				}
				jobs = currentGroup.Jobs;
				i = 0;
				break;
			case 1U:
				i++;
				break;
			default:
				return false;
			}
			if (i < jobs.Length)
			{
				task = jobs[i];
				this.$current = task;
				this.$PC = 1;
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000C5BC File Offset: 0x0000A7BC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400017B RID: 379
		internal global::Facepunch.Load.Group <currentGroup>__0;

		// Token: 0x0400017C RID: 380
		internal global::Facepunch.Load.Job[] <$s_66>__1;

		// Token: 0x0400017D RID: 381
		internal int <$s_67>__2;

		// Token: 0x0400017E RID: 382
		internal global::Facepunch.Load.Job <task>__3;

		// Token: 0x0400017F RID: 383
		internal int $PC;

		// Token: 0x04000180 RID: 384
		internal global::Facepunch.Load.IDownloadTask $current;

		// Token: 0x04000181 RID: 385
		internal global::RustLoader <>f__this;
	}

	// Token: 0x0200003F RID: 63
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator9 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask>, global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask>
	{
		// Token: 0x06000251 RID: 593 RVA: 0x0000C5D0 File Offset: 0x0000A7D0
		public <>c__Iterator9()
		{
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0000C5D8 File Offset: 0x0000A7D8
		global::Facepunch.Load.IDownloadTask global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000C5E0 File Offset: 0x0000A7E0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000C5E8 File Offset: 0x0000A7E8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Facepunch.Load.IDownloadTask>.GetEnumerator();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000C5F0 File Offset: 0x0000A7F0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Facepunch.Load.IDownloadTask> global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::RustLoader.<>c__Iterator9 <>c__Iterator = new global::RustLoader.<>c__Iterator9();
			<>c__Iterator.<>f__this = this;
			return <>c__Iterator;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000C624 File Offset: 0x0000A824
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (this.loader == null)
				{
					return false;
				}
				jobs = this.loader.Jobs;
				i = 0;
				break;
			case 1U:
				i++;
				break;
			default:
				return false;
			}
			if (i < jobs.Length)
			{
				task = jobs[i];
				this.$current = task;
				this.$PC = 1;
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000C6E4 File Offset: 0x0000A8E4
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000C6F0 File Offset: 0x0000A8F0
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000182 RID: 386
		internal global::Facepunch.Load.Job[] <$s_64>__0;

		// Token: 0x04000183 RID: 387
		internal int <$s_65>__1;

		// Token: 0x04000184 RID: 388
		internal global::Facepunch.Load.Job <task>__2;

		// Token: 0x04000185 RID: 389
		internal int $PC;

		// Token: 0x04000186 RID: 390
		internal global::Facepunch.Load.IDownloadTask $current;

		// Token: 0x04000187 RID: 391
		internal global::RustLoader <>f__this;
	}

	// Token: 0x02000040 RID: 64
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Start>c__IteratorA : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000C6F8 File Offset: 0x0000A8F8
		public <Start>c__IteratorA()
		{
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000C700 File Offset: 0x0000A900
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000C708 File Offset: 0x0000A908
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000C710 File Offset: 0x0000A910
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				base.DispatchLoadMessage("OnRustBundleFetching", this);
				if (this.preloadedJsonLoader)
				{
					loaderText = this.preloadedJsonLoaderText;
					bundleDirectory = (this.preloadedJsonLoaderRoot ?? string.Empty);
					loaderError = this.preloadedJsonLoaderError;
					this.preloadedJsonLoaderText = null;
					this.preloadedJsonLoaderRoot = null;
					this.preloadedJsonLoaderError = null;
				}
				else
				{
					bundleDirectory = this.releaseBundleLoaderFilePath.Remove(this.releaseBundleLoaderFilePath.LastIndexOfAny(new char[]
					{
						'\\',
						'/'
					}) + 1);
					try
					{
						loaderText = global::System.IO.File.ReadAllText(this.releaseBundleLoaderFilePath);
						loaderError = string.Empty;
					}
					catch (global::System.Exception ex)
					{
						e = ex;
						loaderText = string.Empty;
						loaderError = e.ToString();
						if (string.IsNullOrEmpty(loaderError))
						{
							loaderError = "Failed";
						}
					}
				}
				if (string.IsNullOrEmpty(loaderError))
				{
					this.loader = global::Facepunch.Load.Loader.CreateFromText(loaderText, bundleDirectory, new global::Facepunch.Load.Downloaders.FileDispatch());
					global::Facepunch.Bundling.BindToLoader(this.loader);
					global::Facepunch.Bundling.OnceLoaded += global::RustLoader.OnResourcesLoaded;
					base.DispatchLoadMessage("OnRustBundlePreLoad", this);
					this.loader.StartLoading();
					base.DispatchLoadMessage("OnRustBundleLoadStart", this);
					this.$current = base.StartCoroutine(this.loader.WaitEnumerator);
					this.$PC = 1;
					return true;
				}
				global::UnityEngine.Debug.LogError(loaderError);
				break;
			case 1U:
				base.DispatchLoadMessage("OnRustBundleLoadComplete", this);
				try
				{
					this.loader.Dispose();
				}
				catch (global::System.Exception ex2)
				{
					e2 = ex2;
					global::UnityEngine.Debug.LogException(e2);
				}
				finally
				{
					this.loader = null;
				}
				this.$current = global::UnityEngine.Resources.UnloadUnusedAssets();
				this.$PC = 2;
				return true;
			case 2U:
				base.BroadcastMessage("OnRustLoadedFirst", 1);
				base.DispatchLoadMessage("OnRustLoaded", this);
				base.DispatchLoadMessage("OnRustReady", this);
				if (this.destroyGameObjectOnceLoaded)
				{
					global::UnityEngine.Object.Destroy(base.gameObject);
				}
				else
				{
					global::UnityEngine.Object.Destroy(this);
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000CA6C File Offset: 0x0000AC6C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000CA78 File Offset: 0x0000AC78
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000188 RID: 392
		internal string <loaderText>__0;

		// Token: 0x04000189 RID: 393
		internal string <bundleDirectory>__1;

		// Token: 0x0400018A RID: 394
		internal string <loaderError>__2;

		// Token: 0x0400018B RID: 395
		internal global::System.Exception <e>__3;

		// Token: 0x0400018C RID: 396
		internal global::System.Exception <e>__4;

		// Token: 0x0400018D RID: 397
		internal int $PC;

		// Token: 0x0400018E RID: 398
		internal object $current;

		// Token: 0x0400018F RID: 399
		internal global::RustLoader <>f__this;
	}
}
