using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Facepunch.Progress;
using Rust;
using Rust.Steam;
using Rust.Utility;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public static class RustLevel
{
	// Token: 0x06002C0B RID: 11275 RVA: 0x000A5C0C File Offset: 0x000A3E0C
	public static global::UnityEngine.Coroutine Load(string levelName, out global::UnityEngine.GameObject loader)
	{
		global::Rust.Globals.currentLevel = levelName;
		loader = new global::UnityEngine.GameObject("Loading Level:" + levelName, new global::System.Type[]
		{
			typeof(global::UnityEngine.MonoBehaviour)
		});
		global::UnityEngine.Object.DontDestroyOnLoad(loader);
		global::UnityEngine.MonoBehaviour component = loader.GetComponent<global::UnityEngine.MonoBehaviour>();
		return component.StartCoroutine(global::RustLevel.LoadRoutine(component, levelName));
	}

	// Token: 0x06002C0C RID: 11276 RVA: 0x000A5C60 File Offset: 0x000A3E60
	public static global::UnityEngine.Coroutine Load(string levelName)
	{
		global::UnityEngine.GameObject gameObject;
		return global::RustLevel.Load(levelName, out gameObject);
	}

	// Token: 0x06002C0D RID: 11277 RVA: 0x000A5C78 File Offset: 0x000A3E78
	private static global::System.Collections.IEnumerator LoadRoutine(global::UnityEngine.MonoBehaviour script, string levelName)
	{
		global::Rust.Utility.FreezeMonitor.Off();
		global::ServerRuntime.PushLoadingPhase();
		global::Rust.Globals.isLoading = true;
		global::UnityEngine.Application.backgroundLoadingPriority = 0;
		global::LoadingScreen.Update("loading " + levelName);
		global::NetCull.isMessageQueueRunning = false;
		global::UnityEngine.Application.LoadLevel(levelName);
		bool LoadedTrees;
		if (global::UnityEngine.Application.CanStreamedLevelBeLoaded(levelName + "-TREES"))
		{
			global::LoadingScreen.Update("loading trees");
			global::UnityEngine.AsyncOperation async = global::UnityEngine.Application.LoadLevelAdditiveAsync(levelName + "-TREES");
			global::LoadingScreen.Operations.Add(async);
			yield return async;
			global::LoadingScreen.Operations.Clear();
			LoadedTrees = true;
		}
		else
		{
			LoadedTrees = false;
		}
		global::UnityEngine.Debug.Log("Loaded \"" + levelName + ((!LoadedTrees) ? "\"." : "\" (and tree level)."));
		yield return new global::UnityEngine.WaitForEndOfFrame();
		yield return new global::UnityEngine.WaitForEndOfFrame();
		yield return new global::UnityEngine.WaitForEndOfFrame();
		global::CullGrid.RegisterGroups();
		global::RustLevel.BroadcastGlobalMessage("OnServerLoad");
		global::ServerSaveManager.Initialize();
		global::UnityEngine.Application.LoadLevelAdditive("LevelShared");
		yield return new global::UnityEngine.WaitForEndOfFrame();
		yield return new global::UnityEngine.WaitForEndOfFrame();
		global::UnityEngine.YieldInstruction worldSaveRestoreRoutine;
		string message = global::ServerSaveManager.Load(global::ServerSaveManager.autoSavePath, out worldSaveRestoreRoutine);
		if (!string.IsNullOrEmpty(message))
		{
			global::UnityEngine.Debug.Log(message);
		}
		yield return worldSaveRestoreRoutine;
		global::Rust.Steam.Server.OnPlayerCountChanged();
		global::NetCull.isMessageQueueRunning = true;
		yield return new global::UnityEngine.WaitForEndOfFrame();
		global::LoadingScreen.Update("growing trees");
		yield return new global::UnityEngine.WaitForEndOfFrame();
		global::LoadingScreen.Operations.AddMultiple<global::Facepunch.Progress.IProgress>(global::ThrottledTask.AllWorkingTasksProgress);
		while (global::ThrottledTask.Operational)
		{
			yield return new global::UnityEngine.WaitForSeconds(0.1f);
		}
		global::LoadingScreen.Operations.Clear();
		global::Rust.Utility.FreezeMonitor.On();
		global::ServerRuntime.PopLoadingPhase();
		global::Rust.Globals.isLoading = false;
		global::UnityEngine.Object.Destroy(script.gameObject);
		yield break;
	}

	// Token: 0x06002C0E RID: 11278 RVA: 0x000A5CA8 File Offset: 0x000A3EA8
	private static global::UnityEngine.Coroutine WaitForCondition(global::UnityEngine.MonoBehaviour script, global::System.Func<bool> condition, string requestLabel)
	{
		return script.StartCoroutine(global::RustLevel.WaitForCondition(condition, requestLabel));
	}

	// Token: 0x06002C0F RID: 11279 RVA: 0x000A5CB8 File Offset: 0x000A3EB8
	private static global::System.Collections.IEnumerator WaitForCondition(global::System.Func<bool> condition, string requestLabel)
	{
		if (!condition())
		{
			ulong counter = 0UL;
			do
			{
				if ((counter += 1UL) % 0x32UL == 0UL)
				{
					global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
					{
						"condition still not met:",
						requestLabel,
						" ( ",
						counter,
						" frames later )"
					}));
				}
				yield return new global::UnityEngine.WaitForEndOfFrame();
			}
			while (!condition());
			if ((counter += 1UL) > 0x32UL)
			{
				global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
				{
					"Took ",
					counter,
					" additional frame(s) for condition ",
					requestLabel
				}));
			}
		}
		yield break;
	}

	// Token: 0x06002C10 RID: 11280 RVA: 0x000A5CE8 File Offset: 0x000A3EE8
	private static global::System.Collections.Generic.List<global::UnityEngine.GameObject> CollectRootGameObjects()
	{
		global::System.Collections.Generic.HashSet<global::UnityEngine.Transform> hashSet = new global::System.Collections.Generic.HashSet<global::UnityEngine.Transform>();
		global::System.Collections.Generic.List<global::UnityEngine.GameObject> list = new global::System.Collections.Generic.List<global::UnityEngine.GameObject>();
		foreach (global::UnityEngine.Object @object in global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.Transform)))
		{
			if (@object)
			{
				global::UnityEngine.Transform root = ((global::UnityEngine.Transform)@object).root;
				if (hashSet.Add(root))
				{
					list.Add(root.gameObject);
				}
			}
		}
		return list;
	}

	// Token: 0x06002C11 RID: 11281 RVA: 0x000A5D68 File Offset: 0x000A3F68
	private static void BroadcastGlobalMessage(string messageName)
	{
		foreach (global::UnityEngine.GameObject gameObject in global::RustLevel.CollectRootGameObjects())
		{
			if (gameObject)
			{
				gameObject.BroadcastMessage(messageName, 1);
			}
		}
	}

	// Token: 0x02000503 RID: 1283
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <LoadRoutine>c__Iterator3C : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06002C12 RID: 11282 RVA: 0x000A5DDC File Offset: 0x000A3FDC
		public <LoadRoutine>c__Iterator3C()
		{
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x06002C13 RID: 11283 RVA: 0x000A5DE4 File Offset: 0x000A3FE4
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x06002C14 RID: 11284 RVA: 0x000A5DEC File Offset: 0x000A3FEC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002C15 RID: 11285 RVA: 0x000A5DF4 File Offset: 0x000A3FF4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				global::Rust.Utility.FreezeMonitor.Off();
				global::ServerRuntime.PushLoadingPhase();
				global::Rust.Globals.isLoading = true;
				global::UnityEngine.Application.backgroundLoadingPriority = 0;
				global::LoadingScreen.Update("loading " + levelName);
				global::NetCull.isMessageQueueRunning = false;
				global::UnityEngine.Application.LoadLevel(levelName);
				if (global::UnityEngine.Application.CanStreamedLevelBeLoaded(levelName + "-TREES"))
				{
					global::LoadingScreen.Update("loading trees");
					async = global::UnityEngine.Application.LoadLevelAdditiveAsync(levelName + "-TREES");
					global::LoadingScreen.Operations.Add(async);
					this.$current = async;
					this.$PC = 1;
					return true;
				}
				LoadedTrees = false;
				break;
			case 1U:
				global::LoadingScreen.Operations.Clear();
				LoadedTrees = true;
				break;
			case 2U:
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 3;
				return true;
			case 3U:
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 4;
				return true;
			case 4U:
				global::CullGrid.RegisterGroups();
				global::RustLevel.BroadcastGlobalMessage("OnServerLoad");
				global::ServerSaveManager.Initialize();
				global::UnityEngine.Application.LoadLevelAdditive("LevelShared");
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 5;
				return true;
			case 5U:
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 6;
				return true;
			case 6U:
				message = global::ServerSaveManager.Load(global::ServerSaveManager.autoSavePath, out worldSaveRestoreRoutine);
				if (!string.IsNullOrEmpty(message))
				{
					global::UnityEngine.Debug.Log(message);
				}
				this.$current = worldSaveRestoreRoutine;
				this.$PC = 7;
				return true;
			case 7U:
				global::Rust.Steam.Server.OnPlayerCountChanged();
				global::NetCull.isMessageQueueRunning = true;
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 8;
				return true;
			case 8U:
				global::LoadingScreen.Update("growing trees");
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 9;
				return true;
			case 9U:
				global::LoadingScreen.Operations.AddMultiple<global::Facepunch.Progress.IProgress>(global::ThrottledTask.AllWorkingTasksProgress);
				goto IL_283;
			case 0xAU:
				goto IL_283;
			default:
				return false;
			}
			global::UnityEngine.Debug.Log("Loaded \"" + levelName + ((!LoadedTrees) ? "\"." : "\" (and tree level)."));
			this.$current = new global::UnityEngine.WaitForEndOfFrame();
			this.$PC = 2;
			return true;
			IL_283:
			if (global::ThrottledTask.Operational)
			{
				this.$current = new global::UnityEngine.WaitForSeconds(0.1f);
				this.$PC = 0xA;
				return true;
			}
			global::LoadingScreen.Operations.Clear();
			global::Rust.Utility.FreezeMonitor.On();
			global::ServerRuntime.PopLoadingPhase();
			global::Rust.Globals.isLoading = false;
			global::UnityEngine.Object.Destroy(script.gameObject);
			this.$PC = -1;
			return false;
		}

		// Token: 0x06002C16 RID: 11286 RVA: 0x000A60C4 File Offset: 0x000A42C4
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002C17 RID: 11287 RVA: 0x000A60D0 File Offset: 0x000A42D0
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400165A RID: 5722
		internal string levelName;

		// Token: 0x0400165B RID: 5723
		internal global::UnityEngine.AsyncOperation <async>__0;

		// Token: 0x0400165C RID: 5724
		internal bool <LoadedTrees>__1;

		// Token: 0x0400165D RID: 5725
		internal global::UnityEngine.YieldInstruction <worldSaveRestoreRoutine>__2;

		// Token: 0x0400165E RID: 5726
		internal string <message>__3;

		// Token: 0x0400165F RID: 5727
		internal global::UnityEngine.MonoBehaviour script;

		// Token: 0x04001660 RID: 5728
		internal int $PC;

		// Token: 0x04001661 RID: 5729
		internal object $current;

		// Token: 0x04001662 RID: 5730
		internal string <$>levelName;

		// Token: 0x04001663 RID: 5731
		internal global::UnityEngine.MonoBehaviour <$>script;
	}

	// Token: 0x02000504 RID: 1284
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <WaitForCondition>c__Iterator3D : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06002C18 RID: 11288 RVA: 0x000A60D8 File Offset: 0x000A42D8
		public <WaitForCondition>c__Iterator3D()
		{
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x06002C19 RID: 11289 RVA: 0x000A60E0 File Offset: 0x000A42E0
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x06002C1A RID: 11290 RVA: 0x000A60E8 File Offset: 0x000A42E8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002C1B RID: 11291 RVA: 0x000A60F0 File Offset: 0x000A42F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (condition())
				{
					goto IL_10B;
				}
				counter = 0UL;
				break;
			case 1U:
				if (condition())
				{
					if ((counter += 1UL) > 0x32UL)
					{
						global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
						{
							"Took ",
							counter,
							" additional frame(s) for condition ",
							requestLabel
						}));
						goto IL_10B;
					}
					goto IL_10B;
				}
				break;
			default:
				return false;
			}
			if ((counter += 1UL) % 0x32UL == 0UL)
			{
				global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
				{
					"condition still not met:",
					requestLabel,
					" ( ",
					counter,
					" frames later )"
				}));
			}
			this.$current = new global::UnityEngine.WaitForEndOfFrame();
			this.$PC = 1;
			return true;
			IL_10B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x06002C1C RID: 11292 RVA: 0x000A6214 File Offset: 0x000A4414
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x000A6220 File Offset: 0x000A4420
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001664 RID: 5732
		internal global::System.Func<bool> condition;

		// Token: 0x04001665 RID: 5733
		internal ulong <counter>__0;

		// Token: 0x04001666 RID: 5734
		internal string requestLabel;

		// Token: 0x04001667 RID: 5735
		internal int $PC;

		// Token: 0x04001668 RID: 5736
		internal object $current;

		// Token: 0x04001669 RID: 5737
		internal global::System.Func<bool> <$>condition;

		// Token: 0x0400166A RID: 5738
		internal string <$>requestLabel;
	}
}
