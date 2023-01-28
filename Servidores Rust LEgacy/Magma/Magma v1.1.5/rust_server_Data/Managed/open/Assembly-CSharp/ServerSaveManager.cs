using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Facepunch.Clocks.Counters;
using Facepunch.MeshBatch;
using Google.ProtocolBuffers.Serialization;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x020000DD RID: 221
[global::UnityEngine.AddComponentMenu("")]
public class ServerSaveManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600044E RID: 1102 RVA: 0x00014550 File Offset: 0x00012750
	public ServerSaveManager()
	{
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x00014560 File Offset: 0x00012760
	private global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command> LoadProccess(global::RustProto.WorldSave save)
	{
		global::Facepunch.MeshBatch.MeshBatchPhysics.ForceImmediatePhysicalBoundsPrecaching = true;
		global::Facepunch.MeshBatch.MeshBatchPhysics.PauseNewProcessing = true;
		global::ServerSaveManager._loadBinding = new global::SaveLoadBinding();
		global::ServerSaveManager._loading = true;
		global::ServerSaveManager.Loading.Log((save.SceneObjectCount + save.InstanceObjectCount).ToString() + " Total Object(s)");
		foreach (global::RustProto.SavedObject SceneSavedObject in global::ServerSaveManager.Loading.ToSortedArray(save.SceneObjectList))
		{
			try
			{
				this.CreateSceneObjectFromSave(SceneSavedObject);
			}
			catch (global::System.Exception ex)
			{
				global::System.Exception e = ex;
				global::ServerSaveManager.Loading.LogException(e);
			}
			yield return global::ServerSaveManager.Loading.Result.LoadedObject;
		}
		foreach (global::RustProto.SavedObject InstanceSavedObject in global::ServerSaveManager.Loading.ToSortedArray(save.InstanceObjectList))
		{
			try
			{
				this.CreateInstanceObjectFromSave(InstanceSavedObject);
			}
			catch (global::System.Exception ex2)
			{
				global::System.Exception e2 = ex2;
				global::ServerSaveManager.Loading.LogException(e2);
			}
			yield return global::ServerSaveManager.Loading.Result.LoadedObject;
		}
		yield return global::ServerSaveManager.Loading.Result.AllObjectsLoaded;
		global::ServerSaveManager.Loading.Log("Binding References");
		global::ServerSaveManager._loadBinding.FinalizeBinding();
		global::ServerSaveManager.Loading.Log("Initializing Objects");
		try
		{
			this.FirePostLoad();
		}
		catch (global::System.Exception ex3)
		{
			global::System.Exception e3 = ex3;
			global::ServerSaveManager.Loading.LogException(e3);
		}
		global::ServerSaveManager.Loading.Log("Baking Physics ( this takes time )");
		global::Facepunch.MeshBatch.MeshBatchPhysics.PauseNewProcessing = false;
		for (int i = 0; i < 8; i++)
		{
			yield return global::ServerSaveManager.Loading.Result.Yield;
		}
		while (global::Facepunch.MeshBatch.MeshBatchPhysics.AnyTargetsPaused || global::Facepunch.MeshBatch.MeshBatchPhysics.AnyTargetsAwaitingApplication || global::Facepunch.MeshBatch.MeshBatchPhysics.AnyTargetsApplyingJobs)
		{
			yield return global::ServerSaveManager.Loading.Result.Yield;
		}
		while (global::Facepunch.MeshBatch.MeshBatchPhysics.AnyPhysicalTargetsPendingIntegration)
		{
			yield return global::ServerSaveManager.Loading.Result.Yield;
		}
		global::Facepunch.MeshBatch.MeshBatchPhysics.ForceImmediatePhysicalBoundsPrecaching = false;
		global::Facepunch.MeshBatch.MeshBatchPhysics.PauseNewProcessing = false;
		global::ServerSaveManager._loadBinding = null;
		global::ServerSaveManager._loading = false;
		global::ServerSaveManager._loadedOnce = true;
		yield break;
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0001458C File Offset: 0x0001278C
	private global::UnityEngine.Coroutine CreateLoadCoroutine(global::RustProto.WorldSave save)
	{
		return base.StartCoroutine(global::ServerSaveManager.Loading.CreateLoadRoutine<global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>>(this.LoadProccess(save)));
	}

	// Token: 0x17000093 RID: 147
	// (get) Token: 0x06000451 RID: 1105 RVA: 0x000145A0 File Offset: 0x000127A0
	public static global::ServerSaveManager.Target CurrentTarget
	{
		get
		{
			return global::ServerSaveManager.currentTarget;
		}
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x06000452 RID: 1106 RVA: 0x000145A8 File Offset: 0x000127A8
	public static global::ServerSaveManager.State? CurrentState
	{
		get
		{
			return global::ServerSaveManager.currentState;
		}
	}

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x06000453 RID: 1107 RVA: 0x000145B0 File Offset: 0x000127B0
	public static global::SaveLoadBinding LoadBinding
	{
		get
		{
			return global::ServerSaveManager._loadBinding;
		}
	}

	// Token: 0x17000096 RID: 150
	// (get) Token: 0x06000454 RID: 1108 RVA: 0x000145B8 File Offset: 0x000127B8
	public static bool IsLoading
	{
		get
		{
			return global::ServerSaveManager._loading;
		}
	}

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x06000455 RID: 1109 RVA: 0x000145C0 File Offset: 0x000127C0
	private global::System.Collections.Generic.Dictionary<int, global::ServerSave> dictionary
	{
		get
		{
			if (!this.madeDict)
			{
				if (this.keys == null)
				{
					this.dict = new global::System.Collections.Generic.Dictionary<int, global::ServerSave>();
				}
				else
				{
					this.dict = new global::System.Collections.Generic.Dictionary<int, global::ServerSave>(this.keys.Length);
					for (int i = 0; i < this.keys.Length; i++)
					{
						if (this.values[i])
						{
							this.dict.Add(this.keys[i], this.values[i]);
						}
					}
				}
				this.madeDict = true;
			}
			return this.dict;
		}
	}

	// Token: 0x17000098 RID: 152
	// (get) Token: 0x06000456 RID: 1110 RVA: 0x00014660 File Offset: 0x00012860
	private global::System.Collections.Generic.HashSet<global::ServerSave> hashSet
	{
		get
		{
			if (!this.madeHashSet)
			{
				this.allSaves = new global::System.Collections.Generic.HashSet<global::ServerSave>(this.dictionary.Values);
				this.madeHashSet = true;
			}
			return this.allSaves;
		}
	}

	// Token: 0x17000099 RID: 153
	public global::ServerSave this[int name]
	{
		get
		{
			global::ServerSave result;
			this.dictionary.TryGetValue(name, out result);
			return result;
		}
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x000146BC File Offset: 0x000128BC
	private void ConsolidateThis()
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			global::UnityEngine.Debug.LogError("DO NOT CONSOLIDATE WHILE PLAYING!", this);
			return;
		}
		bool flag = false;
		global::System.Collections.Generic.List<int> list = new global::System.Collections.Generic.List<int>();
		global::System.Collections.Generic.List<global::ServerSave> list2 = new global::System.Collections.Generic.List<global::ServerSave>();
		global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.List<global::ServerSave>> dictionary = null;
		global::System.Collections.Generic.HashSet<global::ServerSave> hashSet = new global::System.Collections.Generic.HashSet<global::ServerSave>();
		global::System.Collections.Generic.HashSet<int> hashSet2 = new global::System.Collections.Generic.HashSet<int>();
		if (this.keys != null)
		{
			for (int i = 0; i < this.keys.Length; i++)
			{
				if (!this.values[i])
				{
					list.Add(i);
				}
				else if (!hashSet.Add(this.values[i]))
				{
					global::UnityEngine.Debug.LogError("Entered more than once, removing indices greater than first index", this.values[i]);
				}
				else if (!hashSet2.Add(this.keys[i]))
				{
					if (dictionary == null)
					{
						dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.List<global::ServerSave>>();
					}
					global::System.Collections.Generic.List<global::ServerSave> list3;
					if (!dictionary.TryGetValue(this.keys[i], out list3))
					{
						list3 = new global::System.Collections.Generic.List<global::ServerSave>();
						for (int j = i - 1; j >= 0; j--)
						{
							if (this.keys[j] == this.keys[i])
							{
								list3.Add(this.values[i]);
							}
						}
						dictionary.Add(this.keys[i], list3);
					}
					list3.Add(this.values[i]);
				}
			}
		}
		if (dictionary != null)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			stringBuilder.AppendLine("There are overlaps!");
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.List<global::ServerSave>> keyValuePair in dictionary)
			{
				stringBuilder.Append(keyValuePair.Key);
				foreach (global::ServerSave serverSave in keyValuePair.Value)
				{
					stringBuilder.Append(" " + serverSave.name);
				}
				stringBuilder.AppendLine();
			}
			global::UnityEngine.Debug.LogError(stringBuilder.ToString(), this);
		}
		int count = list.Count;
		int num;
		int num2;
		if (count > 0)
		{
			flag = true;
			num = 0;
			num2 = -1;
			for (int k = 0; k < count; k++)
			{
				int num3 = list[k];
				while (++num2 != num3)
				{
					this.keys[num] = this.keys[num2];
					this.values[num] = this.values[num2];
					num++;
				}
			}
		}
		else
		{
			num = ((this.keys != null) ? this.keys.Length : 0);
		}
		foreach (global::ServerSave serverSave2 in global::UnityEngine.Object.FindObjectsOfType(typeof(global::ServerSave)))
		{
			if (serverSave2 && !hashSet.Contains(serverSave2))
			{
				list2.Add(serverSave2);
			}
		}
		global::System.Array.Resize<int>(ref this.keys, num + list2.Count);
		global::System.Array.Resize<global::ServerSave>(ref this.values, num + list2.Count);
		flag |= (list2.Count > 0);
		num2 = 0;
		for (int m = num; m < this.keys.Length; m++)
		{
			if (this.nextID == 0x7FFFFFFF)
			{
				this.nextID = int.MinValue;
			}
			else if (this.nextID == -2)
			{
				global::UnityEngine.Debug.LogError("omg, we filled a int.", this);
			}
			this.keys[m] = this.nextID++;
			this.values[m] = list2[num2++];
		}
		this.madeDict = false;
		this.madeHashSet = false;
		if (flag)
		{
		}
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x00014ACC File Offset: 0x00012CCC
	private static global::ServerSaveManager Get(bool doNotCreate = false)
	{
		global::ServerSaveManager[] array = (global::ServerSaveManager[])global::UnityEngine.Object.FindObjectsOfType(typeof(global::ServerSaveManager));
		if (array.Length > 0)
		{
			return array[0];
		}
		if (doNotCreate)
		{
			return null;
		}
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("SaveMrg", new global::System.Type[]
		{
			typeof(global::ServerSaveManager)
		});
		return gameObject.GetComponent<global::ServerSaveManager>();
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x00014B2C File Offset: 0x00012D2C
	public static void Consolidate()
	{
		global::ServerSaveManager.Get(false).ConsolidateThis();
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x00014B3C File Offset: 0x00012D3C
	protected void Start()
	{
		base.StartCoroutine("AutoSaveRoutine");
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x00014B4C File Offset: 0x00012D4C
	public static bool AutoSave()
	{
		if (global::ServerSaveManager._loading)
		{
			return false;
		}
		global::ServerSaveManager.Save(global::ServerSaveManager.autoSavePath);
		return true;
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00014B68 File Offset: 0x00012D68
	private global::System.Collections.IEnumerator AutoSaveRoutine()
	{
		for (;;)
		{
			yield return new global::UnityEngine.WaitForSeconds((float)global::save.autosavetime);
			while (global::ServerSaveManager._loading)
			{
				yield return new global::UnityEngine.WaitForSeconds(1f);
			}
			global::ServerSaveManager.Save(global::ServerSaveManager.autoSavePath);
			yield return global::Resources.UnloadUnusedAssets();
		}
		yield break;
	}

	// Token: 0x1700009A RID: 154
	// (get) Token: 0x0600045E RID: 1118 RVA: 0x00014B7C File Offset: 0x00012D7C
	public static string autoSavePath
	{
		get
		{
			return global::server.datadir + global::server.map + ".sav";
		}
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x00014B94 File Offset: 0x00012D94
	private static string DateTimeFileString(global::System.DateTime When)
	{
		return string.Concat(new string[]
		{
			When.Year.ToString("0000"),
			When.DayOfYear.ToString("000"),
			When.Hour.ToString("00"),
			When.Minute.ToString("00"),
			When.Second.ToString("00")
		});
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x00014C20 File Offset: 0x00012E20
	public static void Save(string path)
	{
		global::Facepunch.Clocks.Counters.SystemTimestamp restart = global::Facepunch.Clocks.Counters.SystemTimestamp.Restart;
		if (path == string.Empty)
		{
			path = "savedgame.sav";
		}
		if (!path.EndsWith(".sav"))
		{
			path += ".sav";
		}
		if (global::ServerSaveManager._loading)
		{
			global::UnityEngine.Debug.LogError("Currently loading, aborting save to " + path);
			return;
		}
		global::UnityEngine.Debug.Log("Saving to '" + path + "'");
		if (!global::ServerSaveManager._loadedOnce)
		{
			if (global::System.IO.File.Exists(path))
			{
				string text = string.Concat(new string[]
				{
					path,
					".",
					global::ServerSaveManager.DateTimeFileString(global::System.IO.File.GetLastWriteTime(path)),
					".",
					global::ServerSaveManager.DateTimeFileString(global::System.DateTime.Now),
					".bak"
				});
				global::System.IO.File.Copy(path, text);
				global::UnityEngine.Debug.LogError("A save file exists at target path, but it was never loaded!\n\tbacked up:" + global::System.IO.Path.GetFullPath(text));
			}
			global::ServerSaveManager._loadedOnce = true;
		}
		global::Facepunch.Clocks.Counters.SystemTimestamp restart2;
		global::Facepunch.Clocks.Counters.SystemTimestamp restart3;
		global::RustProto.WorldSave worldSave;
		using (global::RustProto.Helpers.Recycler<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder> recycler = global::RustProto.WorldSave.Recycler())
		{
			global::RustProto.WorldSave.Builder builder = recycler.OpenBuilder();
			restart2 = global::Facepunch.Clocks.Counters.SystemTimestamp.Restart;
			global::ServerSaveManager.Get(false).DoSave(ref builder);
			restart2.Stop();
			restart3 = global::Facepunch.Clocks.Counters.SystemTimestamp.Restart;
			worldSave = builder.Build();
			restart3.Stop();
		}
		int num = worldSave.SceneObjectCount + worldSave.InstanceObjectCount;
		if (global::save.friendly)
		{
			using (global::System.IO.FileStream fileStream = global::System.IO.File.Open(path + ".json", global::System.IO.FileMode.Create, global::System.IO.FileAccess.Write))
			{
				global::Google.ProtocolBuffers.Serialization.JsonFormatWriter jsonFormatWriter = global::Google.ProtocolBuffers.Serialization.JsonFormatWriter.CreateInstance(fileStream);
				jsonFormatWriter.Formatted();
				jsonFormatWriter.WriteMessage(worldSave);
			}
		}
		global::Facepunch.Clocks.Counters.SystemTimestamp restart4;
		global::Facepunch.Clocks.Counters.SystemTimestamp systemTimestamp = restart4 = global::Facepunch.Clocks.Counters.SystemTimestamp.Restart;
		using (global::System.IO.FileStream fileStream2 = global::System.IO.File.Open(path + ".new", global::System.IO.FileMode.Create, global::System.IO.FileAccess.Write))
		{
			worldSave.WriteTo(fileStream2);
			fileStream2.Flush();
		}
		systemTimestamp.Stop();
		if (global::System.IO.File.Exists(path + ".old.5"))
		{
			global::System.IO.File.Delete(path + ".old.5");
		}
		for (int i = 4; i >= 0; i--)
		{
			if (global::System.IO.File.Exists(path + ".old." + i))
			{
				global::System.IO.File.Move(path + ".old." + i, path + ".old." + (i + 1));
			}
		}
		if (global::System.IO.File.Exists(path))
		{
			global::System.IO.File.Move(path, path + ".old.0");
		}
		if (global::System.IO.File.Exists(path + ".new"))
		{
			global::System.IO.File.Move(path + ".new", path);
		}
		restart4.Stop();
		restart.Stop();
		if (global::save.profile)
		{
			object[] args = new object[]
			{
				num,
				restart2.ElapsedSeconds,
				restart2.ElapsedSeconds / restart.ElapsedSeconds,
				restart3.ElapsedSeconds,
				restart3.ElapsedSeconds / restart.ElapsedSeconds,
				systemTimestamp.ElapsedSeconds,
				systemTimestamp.ElapsedSeconds / restart.ElapsedSeconds,
				restart4.ElapsedSeconds,
				restart4.ElapsedSeconds / restart.ElapsedSeconds,
				restart.ElapsedSeconds,
				restart.ElapsedSeconds / restart.ElapsedSeconds
			};
			global::UnityEngine.Debug.Log(string.Format(" Saved {0} Object(s) [times below are in elapsed seconds]\r\n  Logic:\t{1,-16:0.000000}\t{2,7:0.00%}\r\n  Build:\t{3,-16:0.000000}\t{4,7:0.00%}\r\n  Stream:\t{5,-16:0.000000}\t{6,7:0.00%}\r\n  All IO:\t{7,-16:0.000000}\t{8,7:0.00%}\r\n  Total:\t{9,-16:0.000000}\t{10,7:0.00%}", args));
		}
		else
		{
			global::ConsoleSystem.Print(string.Concat(new object[]
			{
				" Saved ",
				num,
				" Object(s). Took ",
				restart.ElapsedSeconds,
				" seconds."
			}), false);
		}
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x00015060 File Offset: 0x00013260
	public static void Initialize()
	{
		global::ServerSaveManager.Get(false);
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0001506C File Offset: 0x0001326C
	public static string Load(string path, out global::UnityEngine.YieldInstruction process)
	{
		process = null;
		if (global::ServerSaveManager._loading)
		{
			global::UnityEngine.Debug.LogError("Was already loading!");
			return "Cannot load while in loading process";
		}
		if (!global::System.IO.File.Exists(path))
		{
			return "Save file not found";
		}
		global::System.IO.FileStream fileStream;
		try
		{
			fileStream = global::System.IO.File.Open(path, global::System.IO.FileMode.Open, global::System.IO.FileAccess.Read);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
			return "Couldn't open save file";
		}
		string result;
		try
		{
			global::RustProto.WorldSave worldSave;
			using (global::RustProto.Helpers.Recycler<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder> recycler = global::RustProto.WorldSave.Recycler())
			{
				global::RustProto.WorldSave.Builder builder = recycler.OpenBuilder();
				global::RustProto.WorldSave.Builder builder2 = builder.MergeFrom(fileStream);
				if (builder2 == null)
				{
					return "Couldn't read save file!";
				}
				worldSave = builder2.Build();
			}
			if (worldSave == null)
			{
				result = "Save file is invalid!";
			}
			else
			{
				global::UnityEngine.Debug.Log("Loading save file\n " + global::System.IO.Path.GetFullPath(path));
				process = global::ServerSaveManager.Get(false).CreateLoadCoroutine(worldSave);
				result = string.Empty;
			}
		}
		catch (global::System.Exception ex2)
		{
			global::UnityEngine.Debug.LogException(ex2);
			result = ex2.Message;
		}
		finally
		{
			fileStream.Dispose();
		}
		return result;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x000151E4 File Offset: 0x000133E4
	[global::System.Obsolete("Since we have to allow frames between instantiates to disable colliders, load is not immediate. You can wait on the coroutine using the other overload (but it will load over time if you choose not to)")]
	public static string Load(string path)
	{
		global::UnityEngine.YieldInstruction yieldInstruction;
		return global::ServerSaveManager.Load(path, out yieldInstruction);
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x000151FC File Offset: 0x000133FC
	public static int LookupIDNoMod(global::ServerSave save)
	{
		if (!save)
		{
			return -1;
		}
		global::ServerSaveManager serverSaveManager = global::ServerSaveManager.Get(true);
		if (serverSaveManager.values == null)
		{
			return -1;
		}
		for (int i = 0; i < serverSaveManager.values.Length; i++)
		{
			if (serverSaveManager.values[i] == save)
			{
				return serverSaveManager.keys[i];
			}
		}
		return -1;
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x00015260 File Offset: 0x00013460
	public static bool NetRegister(global::ServerSave target, ref global::uLink.NetworkMessageInfo info)
	{
		return global::ServerSaveManager.Instances.Register(target);
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00015268 File Offset: 0x00013468
	public static bool NGCRegister(global::ServerSave target)
	{
		return global::ServerSaveManager.Instances.Register(target);
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00015270 File Offset: 0x00013470
	public static bool NGCUnregister(global::ServerSave target)
	{
		return global::ServerSaveManager.Instances.Unregister(target);
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00015278 File Offset: 0x00013478
	public static bool NetUnregister(global::ServerSave target)
	{
		return global::ServerSaveManager.Instances.Unregister(target);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00015280 File Offset: 0x00013480
	private void DoSave(ref global::RustProto.WorldSave.Builder save)
	{
		this.SaveScene(ref save);
		this.SaveInstances(ref save);
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x00015290 File Offset: 0x00013490
	private void SaveScene(ref global::RustProto.WorldSave.Builder save)
	{
		if (this.keys == null)
		{
			return;
		}
		using (global::RustProto.Helpers.Recycler<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder> recycler = global::RustProto.SavedObject.Recycler())
		{
			global::RustProto.SavedObject.Builder builder = recycler.OpenBuilder();
			for (int i = 0; i < this.keys.Length; i++)
			{
				int id = this.keys[i];
				global::ServerSave serverSave = this.values[i];
				if (serverSave)
				{
					builder.Clear();
					builder.SetId(id);
					serverSave.SaveServerSaveables(ref builder);
					save.AddSceneObject(builder);
				}
			}
		}
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x00015344 File Offset: 0x00013544
	private void SaveInstances(ref global::RustProto.WorldSave.Builder save)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder> recycler = global::RustProto.SavedObject.Recycler())
		{
			global::RustProto.SavedObject.Builder builder = recycler.OpenBuilder();
			int minValue = int.MinValue;
			foreach (global::ServerSave serverSave in global::ServerSaveManager.Instances.All)
			{
				builder.Clear();
				bool flag;
				if ((flag = ((int)serverSave.REGED == 1)) || (int)serverSave.REGED == 2)
				{
					int sortOrder = minValue++;
					if (flag)
					{
						serverSave.SaveInstance_NetworkView(ref builder, sortOrder);
					}
					else
					{
						serverSave.SaveInstance_NGC(ref builder, sortOrder);
					}
				}
				save.AddInstanceObject(builder);
			}
		}
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00015438 File Offset: 0x00013638
	private void CreateInstanceObjectFromSave(global::RustProto.SavedObject saveObj)
	{
		if (!saveObj.HasCoords)
		{
			global::UnityEngine.Debug.LogWarning("Missing Coords");
			return;
		}
		if (!saveObj.HasId)
		{
			global::UnityEngine.Debug.LogWarning("Missing Id");
		}
		global::RustProto.Vector vector = (!saveObj.Coords.HasOldPos) ? saveObj.Coords.Pos : saveObj.Coords.OldPos;
		global::RustProto.Quaternion quaternion = (!saveObj.Coords.HasOldRot) ? saveObj.Coords.Rot : saveObj.Coords.OldRot;
		global::UnityEngine.Vector3 vPos;
		vPos.x = vector.X;
		vPos.y = vector.Y;
		vPos.z = vector.Z;
		global::UnityEngine.Quaternion vAng;
		vAng.x = quaternion.X;
		vAng.y = quaternion.Y;
		vAng.z = quaternion.Z;
		vAng.w = quaternion.W;
		int id = saveObj.Id;
		global::NetEntityID currentID;
		global::NetEntityID.Kind kind;
		if (saveObj.HasNetInstance)
		{
			if (saveObj.HasNgcInstance)
			{
				global::UnityEngine.Debug.LogWarning("Some how a saveobj had both Net and NGC");
			}
			kind = global::NetEntityID.Of(global::ServerSave.CreateNetInstance(ref saveObj, vPos, vAng), out currentID);
		}
		else
		{
			if (!saveObj.HasNgcInstance)
			{
				global::UnityEngine.Debug.LogWarning("a saveobj did not have either a Net or NGC");
				return;
			}
			kind = global::NetEntityID.Of(global::ServerSave.CreateNGCInstance(ref saveObj, vPos, vAng), out currentID);
		}
		if ((int)kind == 1 || (int)kind == -1)
		{
			global::ServerSaveManager._loadBinding.Bind(id, currentID);
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("unhandled NetEntityID.Kind in loading " + kind);
		}
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x000155CC File Offset: 0x000137CC
	private void CreateSceneObjectFromSave(global::RustProto.SavedObject save)
	{
		if (!this.dictionary.ContainsKey(save.Id))
		{
			global::UnityEngine.Debug.LogWarning("CreateSceneObjectFromSave: Couldn't find key " + save.Id);
			return;
		}
		global::ServerSave serverSave = this.dictionary[save.Id];
		if (!serverSave)
		{
			return;
		}
		serverSave.LoadServerSavables(ref save);
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x00015630 File Offset: 0x00013830
	private void FirePostLoad()
	{
		foreach (global::UnityEngine.Object @object in global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.MonoBehaviour)))
		{
			if (@object)
			{
				if (@object is global::IServerSaveNotify)
				{
					(@object as global::IServerSaveNotify).PostLoad();
				}
			}
		}
	}

	// Token: 0x04000400 RID: 1024
	private const int version = 2;

	// Token: 0x04000401 RID: 1025
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int nextID = 1;

	// Token: 0x04000402 RID: 1026
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int[] keys;

	// Token: 0x04000403 RID: 1027
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::ServerSave[] values;

	// Token: 0x04000404 RID: 1028
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Dictionary<int, global::ServerSave> dict;

	// Token: 0x04000405 RID: 1029
	[global::System.NonSerialized]
	private global::System.Collections.Generic.HashSet<global::ServerSave> allSaves;

	// Token: 0x04000406 RID: 1030
	[global::System.NonSerialized]
	private bool madeDict;

	// Token: 0x04000407 RID: 1031
	[global::System.NonSerialized]
	private bool madeHashSet;

	// Token: 0x04000408 RID: 1032
	private static global::ServerSaveManager.Target currentTarget;

	// Token: 0x04000409 RID: 1033
	private static bool _loading;

	// Token: 0x0400040A RID: 1034
	private static bool _loadedOnce;

	// Token: 0x0400040B RID: 1035
	private static global::SaveLoadBinding _loadBinding;

	// Token: 0x0400040C RID: 1036
	private static global::ServerSaveManager.State? currentState;

	// Token: 0x020000DE RID: 222
	protected static class Loading
	{
		// Token: 0x0600046F RID: 1135 RVA: 0x00015690 File Offset: 0x00013890
		public static global::RustProto.SavedObject[] ToSortedArray(global::System.Collections.Generic.ICollection<global::RustProto.SavedObject> Collection)
		{
			global::RustProto.SavedObject[] array = new global::RustProto.SavedObject[Collection.Count];
			Collection.CopyTo(array, 0);
			global::System.Array.Sort<global::RustProto.SavedObject>(array, new global::ServerSaveManager.Loading.SavedObjectSorter());
			return array;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000156C0 File Offset: 0x000138C0
		public static global::System.Collections.IEnumerator CreateLoadRoutine<T>(T LoadProccess) where T : global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>
		{
			return default(global::ServerSaveManager.Loading.Routine).Run<T>(LoadProccess);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x000156E0 File Offset: 0x000138E0
		public static void Log(object message)
		{
			global::ConsoleSystem.Print("  - " + message, false);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x000156F4 File Offset: 0x000138F4
		public static void LogException(global::System.Exception e)
		{
			global::UnityEngine.Debug.LogException(e, global::ServerSaveManager.Get(false));
		}

		// Token: 0x0400040D RID: 1037
		public const int MaxNumLoadObjectsPerFrame = 0x2710;

		// Token: 0x0400040E RID: 1038
		public const int FramesToWaitForMeshBatchDequeue = 8;

		// Token: 0x020000DF RID: 223
		public enum Result
		{
			// Token: 0x04000410 RID: 1040
			Yield = 1,
			// Token: 0x04000411 RID: 1041
			LoadedObject,
			// Token: 0x04000412 RID: 1042
			AllObjectsLoaded,
			// Token: 0x04000413 RID: 1043
			NextFrame = 1
		}

		// Token: 0x020000E0 RID: 224
		public struct Command
		{
			// Token: 0x06000473 RID: 1139 RVA: 0x00015704 File Offset: 0x00013904
			private Command(object value, global::ServerSaveManager.Loading.Result result)
			{
				this.value = value;
				this.result = result;
			}

			// Token: 0x06000474 RID: 1140 RVA: 0x00015714 File Offset: 0x00013914
			public static implicit operator global::ServerSaveManager.Loading.Command(global::ServerSaveManager.Loading.Result result)
			{
				return new global::ServerSaveManager.Loading.Command(null, result);
			}

			// Token: 0x06000475 RID: 1141 RVA: 0x00015720 File Offset: 0x00013920
			public static implicit operator global::ServerSaveManager.Loading.Command(global::UnityEngine.YieldInstruction yieldInstruction)
			{
				return new global::ServerSaveManager.Loading.Command(yieldInstruction, global::ServerSaveManager.Loading.Result.Yield);
			}

			// Token: 0x04000414 RID: 1044
			public readonly object value;

			// Token: 0x04000415 RID: 1045
			public readonly global::ServerSaveManager.Loading.Result result;
		}

		// Token: 0x020000E1 RID: 225
		private struct Routine
		{
			// Token: 0x06000476 RID: 1142 RVA: 0x0001572C File Offset: 0x0001392C
			public global::System.Collections.IEnumerator Run<T>(T Proc) where T : global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>
			{
				global::Facepunch.Clocks.Counters.SystemTimestamp Timer = global::Facepunch.Clocks.Counters.SystemTimestamp.Restart;
				int Frame = global::UnityEngine.Time.frameCount;
				@this = default(global::ServerSaveManager.Loading.Routine);
				while (!this.Complete)
				{
					while (this.Continue<T>(ref Proc))
					{
						switch (this.Command.result)
						{
						case global::ServerSaveManager.Loading.Result.LoadedObject:
							this.NumFrameObjects++;
							continue;
						case global::ServerSaveManager.Loading.Result.AllObjectsLoaded:
							this.WaitOnce |= (this.NumFrameObjects > 0);
							continue;
						}
						yield return this.YieldObject();
					}
					if (this.NumFrameObjects != 0)
					{
						yield return new global::UnityEngine.WaitForFixedUpdate();
						yield return new global::UnityEngine.WaitForEndOfFrame();
						yield return null;
					}
					this.OnFrameEnd();
				}
				try
				{
					Proc.Dispose();
				}
				catch (global::System.Exception ex)
				{
					global::System.Exception e = ex;
					global::UnityEngine.Debug.LogException(e);
				}
				Timer.Stop();
				global::ServerSaveManager.Loading.Log(string.Concat(new object[]
				{
					"Completed [ ",
					global::UnityEngine.Time.frameCount - Frame,
					" frame(s), time elapsed: ",
					Timer.Elapsed,
					" ]"
				}));
				yield break;
			}

			// Token: 0x06000477 RID: 1143 RVA: 0x0001575C File Offset: 0x0001395C
			private bool Continue<T>(ref T Proc) where T : global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>
			{
				bool flag = !this.WaitOnce && this.NumFrameObjects < 0x2710;
				this.Command = ((flag && !(this.Complete = !(flag = Proc.MoveNext()))) ? ((global::ServerSaveManager.Loading.Command)Proc.Current) : default(global::ServerSaveManager.Loading.Command));
				return flag;
			}

			// Token: 0x06000478 RID: 1144 RVA: 0x000157D0 File Offset: 0x000139D0
			private void OnFrameEnd()
			{
				bool complete = this.Complete;
				this = default(global::ServerSaveManager.Loading.Routine);
				this.Complete = complete;
			}

			// Token: 0x06000479 RID: 1145 RVA: 0x000157FC File Offset: 0x000139FC
			private object YieldObject()
			{
				object value = this.Command.value;
				this.Command = default(global::ServerSaveManager.Loading.Command);
				return value;
			}

			// Token: 0x04000416 RID: 1046
			private bool Complete;

			// Token: 0x04000417 RID: 1047
			private bool WaitOnce;

			// Token: 0x04000418 RID: 1048
			private int NumFrameObjects;

			// Token: 0x04000419 RID: 1049
			private global::ServerSaveManager.Loading.Command Command;

			// Token: 0x020000E2 RID: 226
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <Run>c__Iterator1A<T> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object> where T : global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>
			{
				// Token: 0x0600047A RID: 1146 RVA: 0x00015828 File Offset: 0x00013A28
				public <Run>c__Iterator1A()
				{
				}

				// Token: 0x1700009B RID: 155
				// (get) Token: 0x0600047B RID: 1147 RVA: 0x00015830 File Offset: 0x00013A30
				object global::System.Collections.Generic.IEnumerator<object>.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x1700009C RID: 156
				// (get) Token: 0x0600047C RID: 1148 RVA: 0x00015838 File Offset: 0x00013A38
				object global::System.Collections.IEnumerator.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x0600047D RID: 1149 RVA: 0x00015840 File Offset: 0x00013A40
				public bool MoveNext()
				{
					uint num = (uint)this.$PC;
					this.$PC = -1;
					switch (num)
					{
					case 0U:
						Timer = global::Facepunch.Clocks.Counters.SystemTimestamp.Restart;
						Frame = global::UnityEngine.Time.frameCount;
						@this = default(global::ServerSaveManager.Loading.Routine);
						goto IL_15C;
					case 1U:
						break;
					case 2U:
						this.$current = new global::UnityEngine.WaitForEndOfFrame();
						this.$PC = 3;
						return true;
					case 3U:
						this.$current = null;
						this.$PC = 4;
						return true;
					case 4U:
						IL_151:
						base.OnFrameEnd();
						goto IL_15C;
					default:
						return false;
					}
					IL_E5:
					while (base.Continue<T>(ref Proc))
					{
						switch (this.Command.result)
						{
						case global::ServerSaveManager.Loading.Result.LoadedObject:
							this.NumFrameObjects++;
							continue;
						case global::ServerSaveManager.Loading.Result.AllObjectsLoaded:
							this.WaitOnce |= (this.NumFrameObjects > 0);
							continue;
						}
						this.$current = base.YieldObject();
						this.$PC = 1;
						return true;
					}
					if (this.NumFrameObjects == 0)
					{
						goto IL_151;
					}
					this.$current = new global::UnityEngine.WaitForFixedUpdate();
					this.$PC = 2;
					return true;
					IL_15C:
					if (!this.Complete)
					{
						goto IL_E5;
					}
					try
					{
						Proc.Dispose();
					}
					catch (global::System.Exception ex)
					{
						e = ex;
						global::UnityEngine.Debug.LogException(e);
					}
					Timer.Stop();
					global::ServerSaveManager.Loading.Log(string.Concat(new object[]
					{
						"Completed [ ",
						global::UnityEngine.Time.frameCount - Frame,
						" frame(s), time elapsed: ",
						Timer.Elapsed,
						" ]"
					}));
					this.$PC = -1;
					return false;
				}

				// Token: 0x0600047E RID: 1150 RVA: 0x00015A6C File Offset: 0x00013C6C
				[global::System.Diagnostics.DebuggerHidden]
				public void Dispose()
				{
					this.$PC = -1;
				}

				// Token: 0x0600047F RID: 1151 RVA: 0x00015A78 File Offset: 0x00013C78
				[global::System.Diagnostics.DebuggerHidden]
				public void Reset()
				{
					throw new global::System.NotSupportedException();
				}

				// Token: 0x0400041A RID: 1050
				internal global::Facepunch.Clocks.Counters.SystemTimestamp <Timer>__0;

				// Token: 0x0400041B RID: 1051
				internal int <Frame>__1;

				// Token: 0x0400041C RID: 1052
				internal T Proc;

				// Token: 0x0400041D RID: 1053
				internal global::System.Exception <e>__2;

				// Token: 0x0400041E RID: 1054
				internal int $PC;

				// Token: 0x0400041F RID: 1055
				internal object $current;

				// Token: 0x04000420 RID: 1056
				internal T <$>Proc;

				// Token: 0x04000421 RID: 1057
				internal global::ServerSaveManager.Loading.Routine <>f__this;
			}
		}

		// Token: 0x020000E3 RID: 227
		private sealed class SavedObjectSorter : global::System.Collections.Generic.Comparer<global::RustProto.SavedObject>, global::System.Collections.Generic.IComparer<global::RustProto.SavedObject>
		{
			// Token: 0x06000480 RID: 1152 RVA: 0x00015A80 File Offset: 0x00013C80
			public SavedObjectSorter()
			{
			}

			// Token: 0x06000481 RID: 1153 RVA: 0x00015A88 File Offset: 0x00013C88
			static SavedObjectSorter()
			{
			}

			// Token: 0x06000482 RID: 1154 RVA: 0x00015AB4 File Offset: 0x00013CB4
			public override int Compare(global::RustProto.SavedObject a, global::RustProto.SavedObject b)
			{
				return (!a.HasSortOrder) ? ((!b.HasSortOrder) ? 0 : global::ServerSaveManager.Loading.SavedObjectSorter.C01) : ((!b.HasSortOrder) ? global::ServerSaveManager.Loading.SavedObjectSorter.C10 : a.SortOrder.CompareTo(b.SortOrder));
			}

			// Token: 0x04000422 RID: 1058
			private const int C00 = 0;

			// Token: 0x04000423 RID: 1059
			private static readonly int C10 = 1.CompareTo(0);

			// Token: 0x04000424 RID: 1060
			private static readonly int C01 = 0.CompareTo(1);
		}
	}

	// Token: 0x020000E4 RID: 228
	public enum Target
	{
		// Token: 0x04000426 RID: 1062
		None,
		// Token: 0x04000427 RID: 1063
		Scene,
		// Token: 0x04000428 RID: 1064
		Net,
		// Token: 0x04000429 RID: 1065
		NGC
	}

	// Token: 0x020000E5 RID: 229
	public struct State
	{
		// Token: 0x0400042A RID: 1066
		public global::ServerSaveManager.Target target;

		// Token: 0x0400042B RID: 1067
		public global::UnityEngine.Vector3? spawnPosition;

		// Token: 0x0400042C RID: 1068
		public global::UnityEngine.Vector3? savePosition;

		// Token: 0x0400042D RID: 1069
		public global::UnityEngine.Quaternion? spawnRotation;

		// Token: 0x0400042E RID: 1070
		public global::UnityEngine.Quaternion? saveRotation;

		// Token: 0x0400042F RID: 1071
		public int? groupNumber;

		// Token: 0x04000430 RID: 1072
		public string prefabName;

		// Token: 0x04000431 RID: 1073
		public global::UnityEngine.GameObject gameObject;
	}

	// Token: 0x020000E6 RID: 230
	private static class Instances
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x00015B10 File Offset: 0x00013D10
		// Note: this type is marked as 'beforefieldinit'.
		static Instances()
		{
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00015B28 File Offset: 0x00013D28
		public static bool Register(global::ServerSave target)
		{
			if (global::ServerSaveManager.Instances.registers.Add(target))
			{
				global::ServerSaveManager.Instances.ordered.Add(target);
				return true;
			}
			return false;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00015B48 File Offset: 0x00013D48
		public static bool Unregister(global::ServerSave target)
		{
			if (global::ServerSaveManager.Instances.registers.Remove(target))
			{
				global::ServerSaveManager.Instances.ordered.Remove(target);
				return true;
			}
			return false;
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00015B6C File Offset: 0x00013D6C
		public static global::System.Collections.Generic.List<global::ServerSave> All
		{
			get
			{
				return global::ServerSaveManager.Instances.ordered;
			}
		}

		// Token: 0x04000432 RID: 1074
		private static readonly global::System.Collections.Generic.HashSet<global::ServerSave> registers = new global::System.Collections.Generic.HashSet<global::ServerSave>();

		// Token: 0x04000433 RID: 1075
		private static readonly global::System.Collections.Generic.List<global::ServerSave> ordered = new global::System.Collections.Generic.List<global::ServerSave>();
	}

	// Token: 0x020000E7 RID: 231
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <LoadProccess>c__Iterator18 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>
	{
		// Token: 0x06000487 RID: 1159 RVA: 0x00015B74 File Offset: 0x00013D74
		public <LoadProccess>c__Iterator18()
		{
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x00015B7C File Offset: 0x00013D7C
		global::ServerSaveManager.Loading.Command global::System.Collections.Generic.IEnumerator<global::ServerSaveManager.Loading.Command>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00015B84 File Offset: 0x00013D84
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00015B94 File Offset: 0x00013D94
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				global::Facepunch.MeshBatch.MeshBatchPhysics.ForceImmediatePhysicalBoundsPrecaching = true;
				global::Facepunch.MeshBatch.MeshBatchPhysics.PauseNewProcessing = true;
				global::ServerSaveManager._loadBinding = new global::SaveLoadBinding();
				global::ServerSaveManager._loading = true;
				global::ServerSaveManager.Loading.Log((save.SceneObjectCount + save.InstanceObjectCount).ToString() + " Total Object(s)");
				array = global::ServerSaveManager.Loading.ToSortedArray(save.SceneObjectList);
				j = 0;
				break;
			case 1U:
				j++;
				break;
			case 2U:
				k++;
				goto IL_1A4;
			case 3U:
				global::ServerSaveManager.Loading.Log("Binding References");
				global::ServerSaveManager._loadBinding.FinalizeBinding();
				global::ServerSaveManager.Loading.Log("Initializing Objects");
				try
				{
					base.FirePostLoad();
				}
				catch (global::System.Exception ex)
				{
					e3 = ex;
					global::ServerSaveManager.Loading.LogException(e3);
				}
				global::ServerSaveManager.Loading.Log("Baking Physics ( this takes time )");
				global::Facepunch.MeshBatch.MeshBatchPhysics.PauseNewProcessing = false;
				i = 0;
				goto IL_259;
			case 4U:
				i++;
				goto IL_259;
			case 5U:
				IL_282:
				if (!global::Facepunch.MeshBatch.MeshBatchPhysics.AnyTargetsPaused && !global::Facepunch.MeshBatch.MeshBatchPhysics.AnyTargetsAwaitingApplication && !global::Facepunch.MeshBatch.MeshBatchPhysics.AnyTargetsApplyingJobs)
				{
					goto IL_2BD;
				}
				this.$current = global::ServerSaveManager.Loading.Result.Yield;
				this.$PC = 5;
				return true;
			case 6U:
				goto IL_2BD;
			default:
				return false;
			}
			if (j < array.Length)
			{
				SceneSavedObject = array[j];
				try
				{
					base.CreateSceneObjectFromSave(SceneSavedObject);
				}
				catch (global::System.Exception ex2)
				{
					e = ex2;
					global::ServerSaveManager.Loading.LogException(e);
				}
				this.$current = global::ServerSaveManager.Loading.Result.LoadedObject;
				this.$PC = 1;
				return true;
			}
			array2 = global::ServerSaveManager.Loading.ToSortedArray(save.InstanceObjectList);
			k = 0;
			IL_1A4:
			if (k >= array2.Length)
			{
				this.$current = global::ServerSaveManager.Loading.Result.AllObjectsLoaded;
				this.$PC = 3;
				return true;
			}
			InstanceSavedObject = array2[k];
			try
			{
				base.CreateInstanceObjectFromSave(InstanceSavedObject);
			}
			catch (global::System.Exception ex3)
			{
				e2 = ex3;
				global::ServerSaveManager.Loading.LogException(e2);
			}
			this.$current = global::ServerSaveManager.Loading.Result.LoadedObject;
			this.$PC = 2;
			return true;
			IL_259:
			if (i >= 8)
			{
				goto IL_282;
			}
			this.$current = global::ServerSaveManager.Loading.Result.Yield;
			this.$PC = 4;
			return true;
			IL_2BD:
			if (global::Facepunch.MeshBatch.MeshBatchPhysics.AnyPhysicalTargetsPendingIntegration)
			{
				this.$current = global::ServerSaveManager.Loading.Result.Yield;
				this.$PC = 6;
				return true;
			}
			global::Facepunch.MeshBatch.MeshBatchPhysics.ForceImmediatePhysicalBoundsPrecaching = false;
			global::Facepunch.MeshBatch.MeshBatchPhysics.PauseNewProcessing = false;
			global::ServerSaveManager._loadBinding = null;
			global::ServerSaveManager._loading = false;
			global::ServerSaveManager._loadedOnce = true;
			this.$PC = -1;
			return false;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00015EE0 File Offset: 0x000140E0
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00015EEC File Offset: 0x000140EC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000434 RID: 1076
		internal global::RustProto.WorldSave save;

		// Token: 0x04000435 RID: 1077
		internal global::RustProto.SavedObject[] <$s_145>__0;

		// Token: 0x04000436 RID: 1078
		internal int <$s_146>__1;

		// Token: 0x04000437 RID: 1079
		internal global::RustProto.SavedObject <SceneSavedObject>__2;

		// Token: 0x04000438 RID: 1080
		internal global::System.Exception <e>__3;

		// Token: 0x04000439 RID: 1081
		internal global::RustProto.SavedObject[] <$s_147>__4;

		// Token: 0x0400043A RID: 1082
		internal int <$s_148>__5;

		// Token: 0x0400043B RID: 1083
		internal global::RustProto.SavedObject <InstanceSavedObject>__6;

		// Token: 0x0400043C RID: 1084
		internal global::System.Exception <e>__7;

		// Token: 0x0400043D RID: 1085
		internal global::System.Exception <e>__8;

		// Token: 0x0400043E RID: 1086
		internal int <i>__9;

		// Token: 0x0400043F RID: 1087
		internal int $PC;

		// Token: 0x04000440 RID: 1088
		internal global::ServerSaveManager.Loading.Command $current;

		// Token: 0x04000441 RID: 1089
		internal global::RustProto.WorldSave <$>save;

		// Token: 0x04000442 RID: 1090
		internal global::ServerSaveManager <>f__this;
	}

	// Token: 0x020000E8 RID: 232
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <AutoSaveRoutine>c__Iterator19 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x0600048D RID: 1165 RVA: 0x00015EF4 File Offset: 0x000140F4
		public <AutoSaveRoutine>c__Iterator19()
		{
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x00015EFC File Offset: 0x000140FC
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00015F04 File Offset: 0x00014104
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00015F0C File Offset: 0x0001410C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				break;
			case 1U:
				goto IL_67;
			case 2U:
				goto IL_67;
			case 3U:
				break;
			default:
				return false;
			}
			this.$current = new global::UnityEngine.WaitForSeconds((float)global::save.autosavetime);
			this.$PC = 1;
			return true;
			IL_67:
			if (!global::ServerSaveManager._loading)
			{
				global::ServerSaveManager.Save(global::ServerSaveManager.autoSavePath);
				this.$current = global::Resources.UnloadUnusedAssets();
				this.$PC = 3;
			}
			else
			{
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00015FBC File Offset: 0x000141BC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00015FC8 File Offset: 0x000141C8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000443 RID: 1091
		internal int $PC;

		// Token: 0x04000444 RID: 1092
		internal object $current;
	}
}
