using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200000B RID: 11
public abstract class AuthorCreation : global::AuthorShared
{
	// Token: 0x0600001E RID: 30 RVA: 0x000021FC File Offset: 0x000003FC
	protected AuthorCreation(global::System.Type outputType) : this()
	{
		this.outputType = outputType;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000220C File Offset: 0x0000040C
	private AuthorCreation()
	{
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00002248 File Offset: 0x00000448
	// Note: this type is marked as 'beforefieldinit'.
	static AuthorCreation()
	{
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000021 RID: 33 RVA: 0x0000226C File Offset: 0x0000046C
	public int settingsHeight
	{
		get
		{
			return this.creationSeperatorHeight;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000022 RID: 34 RVA: 0x00002274 File Offset: 0x00000474
	public int palletWidth
	{
		get
		{
			return this.palletPanelWidth;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000023 RID: 35 RVA: 0x0000227C File Offset: 0x0000047C
	public int rightPanelWidth
	{
		get
		{
			return this.sideBarWidth;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000024 RID: 36 RVA: 0x00002284 File Offset: 0x00000484
	public int palletContentHeight
	{
		get
		{
			return this.palletLabelHeight;
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000025 RID: 37 RVA: 0x0000228C File Offset: 0x0000048C
	protected global::UnityEngine.Object output
	{
		get
		{
			return this._output;
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002294 File Offset: 0x00000494
	protected virtual global::System.Collections.Generic.IEnumerable<global::AuthorPalletObject> EnumeratePalletObjects()
	{
		return global::AuthorCreation.NoPalletObjects;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000229C File Offset: 0x0000049C
	protected global::System.Collections.Generic.IEnumerable<global::AuthorPeice> EnumeratePeices()
	{
		global::System.Collections.Generic.IEnumerable<global::AuthorPeice> result;
		if (this.allPeices == null || this.allPeices.Count == 0)
		{
			global::System.Collections.Generic.IEnumerable<global::AuthorPeice> noPeices = global::AuthorCreation.NoPeices;
			result = noPeices;
		}
		else
		{
			result = new global::System.Collections.Generic.List<global::AuthorPeice>(this.allPeices);
		}
		return result;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000022DC File Offset: 0x000004DC
	protected global::System.Collections.Generic.IEnumerable<global::AuthorPeice> EnumerateSelectedPeices()
	{
		global::System.Collections.Generic.IEnumerable<global::AuthorPeice> result;
		if (this.selected == null || this.selected.Count == 0)
		{
			global::System.Collections.Generic.IEnumerable<global::AuthorPeice> noPeices = global::AuthorCreation.NoPeices;
			result = noPeices;
		}
		else
		{
			result = new global::System.Collections.Generic.List<global::AuthorPeice>(this.selected);
		}
		return result;
	}

	// Token: 0x06000029 RID: 41 RVA: 0x0000231C File Offset: 0x0000051C
	internal global::System.Collections.Generic.IEnumerable<global::AuthorPeice> EnumeratePeices(bool selectedOnly)
	{
		global::System.Collections.Generic.IEnumerable<global::AuthorPeice> result;
		if (selectedOnly)
		{
			global::System.Collections.Generic.IEnumerable<global::AuthorPeice> enumerable = this.EnumerateSelectedPeices();
			result = enumerable;
		}
		else
		{
			result = this.EnumeratePeices();
		}
		return result;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002344 File Offset: 0x00000544
	protected virtual bool RegisterPeice(global::AuthorPeice peice)
	{
		if (this.allPeices == null)
		{
			this.allPeices = new global::System.Collections.Generic.List<global::AuthorPeice>();
			this.allPeices.Add(peice);
		}
		else
		{
			if (this.allPeices.Contains(peice))
			{
				return false;
			}
			this.allPeices.Add(peice);
		}
		peice.Registered(this);
		return true;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000023A4 File Offset: 0x000005A4
	private bool RegisterPeice(global::AuthorPeice peice, string id)
	{
		peice.peiceID = id;
		return this.RegisterPeice(peice);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000023B4 File Offset: 0x000005B4
	public bool SetSelection(global::UnityEngine.Object[] objects)
	{
		global::System.Collections.Generic.List<global::AuthorPeice> list = null;
		foreach (global::UnityEngine.Object @object in objects)
		{
			if (@object is global::AuthorPeice && @object)
			{
				if (list == null)
				{
					list = new global::System.Collections.Generic.List<global::AuthorPeice>();
					list.Add((global::AuthorPeice)@object);
				}
				else if (!list.Contains((global::AuthorPeice)@object))
				{
					list.Add((global::AuthorPeice)@object);
				}
			}
		}
		bool flag = false;
		try
		{
			if (list == null)
			{
				if (this.selected != null)
				{
					flag = (this.selected.Count > 0);
					this.selected.Clear();
				}
			}
			else
			{
				if (this.allPeices != null)
				{
					list.Sort((global::AuthorPeice x, global::AuthorPeice y) => this.allPeices.IndexOf(x).CompareTo(this.allPeices.IndexOf(y)));
				}
				if (this.selected == null || this.selected.Count != list.Count)
				{
					flag = true;
				}
				else
				{
					using (global::System.Collections.Generic.List<global::AuthorPeice>.Enumerator enumerator = this.selected.GetEnumerator())
					{
						using (global::System.Collections.Generic.List<global::AuthorPeice>.Enumerator enumerator2 = list.GetEnumerator())
						{
							while (enumerator.MoveNext() && enumerator2.MoveNext())
							{
								if (enumerator.Current != enumerator2.Current)
								{
									flag = true;
									break;
								}
							}
						}
					}
				}
			}
		}
		finally
		{
			if (flag)
			{
				if (this.selected != null)
				{
					this.selected.Clear();
					if (list != null)
					{
						this.selected.AddRange(list);
					}
				}
				else if (list != null)
				{
					this.selected = list;
				}
				this.OnSelectionChange();
			}
		}
		return flag;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000025C0 File Offset: 0x000007C0
	public bool GUICreationSettings()
	{
		return this.OnGUICreationSettings();
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000025C8 File Offset: 0x000007C8
	protected virtual bool OnGUICreationSettings()
	{
		return false;
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000025CC File Offset: 0x000007CC
	public global::System.Collections.Generic.IEnumerable<global::AuthorPeice> GUIPeiceInspector()
	{
		if (this.selected == null || this.selected.Count == 0)
		{
			return global::AuthorCreation.NoPeices;
		}
		return this.DoGUIPeiceInspector(this.selected);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x000025FC File Offset: 0x000007FC
	public global::System.Collections.Generic.IEnumerable<global::AuthorShared.PeiceCommand> GUIPeiceList()
	{
		if (this.allPeices == null || this.allPeices.Count == 0)
		{
			return global::AuthorCreation.NoCommand;
		}
		return this.DoGUIPeiceList(this.allPeices);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x0000262C File Offset: 0x0000082C
	private global::System.Collections.Generic.IEnumerable<global::AuthorPeice> DoGUIPeiceInspector(global::System.Collections.Generic.List<global::AuthorPeice> peices)
	{
		foreach (global::AuthorPeice peice in peices)
		{
			global::AuthorShared.BeginVertical(global::AuthorShared.Styles.gradientOutline, new global::UnityEngine.GUILayoutOption[0]);
			bool b = peice.PeiceInspectorGUI();
			global::AuthorShared.EndVertical();
			if (b)
			{
				yield return peice;
			}
		}
		yield break;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002658 File Offset: 0x00000858
	private global::System.Collections.Generic.IEnumerable<global::AuthorShared.PeiceCommand> DoGUIPeiceList(global::System.Collections.Generic.List<global::AuthorPeice> peices)
	{
		foreach (global::AuthorPeice peice in peices)
		{
			global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]);
			global::AuthorShared.PeiceAction action = peice.PeiceListGUI();
			global::AuthorShared.EndVertical();
			if (action != global::AuthorShared.PeiceAction.None)
			{
				yield return new global::AuthorShared.PeiceCommand
				{
					peice = peice,
					action = action
				};
			}
		}
		yield break;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002684 File Offset: 0x00000884
	public virtual global::System.Collections.Generic.IEnumerable<global::AuthorPeice> DoSceneView()
	{
		if (this.selected != null)
		{
			global::UnityEngine.Matrix4x4 mat = global::AuthorShared.Scene.matrix;
			global::UnityEngine.Color color = global::AuthorShared.Scene.color;
			bool lighting = global::AuthorShared.Scene.lighting;
			foreach (global::AuthorPeice peice in this.selected)
			{
				if (peice)
				{
					bool change;
					try
					{
						change = peice.OnSceneView();
					}
					finally
					{
						global::AuthorShared.Scene.matrix = mat;
						global::AuthorShared.Scene.color = color;
						global::AuthorShared.Scene.lighting = lighting;
					}
					if (change)
					{
						yield return peice;
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000026A8 File Offset: 0x000008A8
	protected virtual void OnSelectionChange()
	{
	}

	// Token: 0x06000035 RID: 53 RVA: 0x000026AC File Offset: 0x000008AC
	public bool GUIPalletObjects(params global::UnityEngine.GUILayoutOption[] options)
	{
		return this.GUIPalletObjects(global::UnityEngine.GUI.skin.button, options);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x000026C0 File Offset: 0x000008C0
	public bool GUIPalletObjects(global::UnityEngine.GUIStyle buttonStyle, params global::UnityEngine.GUILayoutOption[] options)
	{
		bool enabled = global::UnityEngine.GUI.enabled;
		bool result = false;
		foreach (global::AuthorPalletObject authorPalletObject in this.EnumeratePalletObjects())
		{
			if (authorPalletObject.guiContent == null)
			{
				authorPalletObject.guiContent = new global::UnityEngine.GUIContent(authorPalletObject.ToString());
			}
			global::UnityEngine.GUI.enabled = (enabled && authorPalletObject.Validate(this));
			global::AuthorPeice authorPeice;
			if (global::UnityEngine.GUILayout.Button(authorPalletObject.guiContent, buttonStyle, options) && authorPalletObject.Create(this, out authorPeice))
			{
				if (!this.RegisterPeice(authorPeice))
				{
					global::UnityEngine.Object.DestroyImmediate(authorPeice.gameObject);
				}
				else
				{
					result = true;
				}
			}
		}
		global::UnityEngine.GUI.enabled = enabled;
		return result;
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0000279C File Offset: 0x0000099C
	public TPeice CreatePeice<TPeice>(string id, params global::System.Type[] additionalComponents) where TPeice : global::AuthorPeice
	{
		global::System.Type[] array = new global::System.Type[additionalComponents.Length + 1];
		global::System.Array.Copy(additionalComponents, 0, array, 1, additionalComponents.Length);
		array[0] = typeof(TPeice);
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(id, array);
		TPeice tpeice = gameObject.GetComponent<TPeice>();
		if (!tpeice || !this.RegisterPeice(tpeice, id))
		{
			global::UnityEngine.Object.DestroyImmediate(gameObject);
			tpeice = (TPeice)((object)null);
		}
		return tpeice;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x0000280C File Offset: 0x00000A0C
	public bool Contains(string peiceID)
	{
		if (this.allPeices != null)
		{
			foreach (global::AuthorPeice authorPeice in this.allPeices)
			{
				if (authorPeice && authorPeice.peiceID == peiceID)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0000289C File Offset: 0x00000A9C
	public bool Contains(global::AuthorPeice comp)
	{
		if (this.allPeices != null)
		{
			foreach (global::AuthorPeice authorPeice in this.allPeices)
			{
				if (authorPeice && authorPeice == comp)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002928 File Offset: 0x00000B28
	protected virtual bool DefaultApply()
	{
		return false;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x0000292C File Offset: 0x00000B2C
	protected virtual void OnWillUnregisterPeice(global::AuthorPeice peice)
	{
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002930 File Offset: 0x00000B30
	protected virtual void OnUnregisteredPeice(global::AuthorPeice peice)
	{
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002934 File Offset: 0x00000B34
	internal void UnregisterPeice(global::AuthorPeice peice)
	{
		if (this.allPeices != null)
		{
			int num = this.allPeices.IndexOf(peice);
			if (num != -1)
			{
				this.OnWillUnregisterPeice(peice);
				this.allPeices.Remove(peice);
				if (this.selected != null)
				{
					this.selected.Remove(peice);
				}
				this.OnUnregisteredPeice(peice);
				if (!global::UnityEngine.Application.isPlaying)
				{
					global::AuthorShared.SetDirty(this);
				}
			}
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x000029A4 File Offset: 0x00000BA4
	public virtual void ExecuteCommand(global::AuthorShared.PeiceCommand cmd)
	{
		global::UnityEngine.Debug.Log(cmd.action, cmd.peice);
		switch (cmd.action)
		{
		case global::AuthorShared.PeiceAction.AddToSelection:
		{
			global::UnityEngine.Object selectReference = cmd.peice.selectReference;
			global::UnityEngine.Object[] allSelectedObjects = global::AuthorShared.GetAllSelectedObjects();
			global::System.Array.Resize<global::UnityEngine.Object>(ref allSelectedObjects, allSelectedObjects.Length + 1);
			allSelectedObjects[allSelectedObjects.Length - 1] = selectReference;
			global::AuthorShared.SetAllSelectedObjects(allSelectedObjects);
			break;
		}
		case global::AuthorShared.PeiceAction.RemoveFromSelection:
		{
			global::UnityEngine.Object selectReference2 = cmd.peice.selectReference;
			global::UnityEngine.Object[] allSelectedObjects2 = global::AuthorShared.GetAllSelectedObjects();
			int num = 0;
			for (int i = 0; i < allSelectedObjects2.Length; i++)
			{
				if (allSelectedObjects2[i] != selectReference2 && allSelectedObjects2[i] != cmd.peice)
				{
					allSelectedObjects2[num++] = allSelectedObjects2[i];
				}
			}
			if (num < allSelectedObjects2.Length)
			{
				global::System.Array.Resize<global::UnityEngine.Object>(ref allSelectedObjects2, num);
				global::AuthorShared.SetAllSelectedObjects(allSelectedObjects2);
			}
			break;
		}
		case global::AuthorShared.PeiceAction.SelectSolo:
			global::AuthorShared.SetAllSelectedObjects(new global::UnityEngine.Object[]
			{
				cmd.peice.selectReference
			});
			break;
		case global::AuthorShared.PeiceAction.Delete:
		{
			bool? flag = global::AuthorShared.Ask(string.Concat(new object[]
			{
				"You want to delete ",
				cmd.peice.peiceID,
				"? (",
				cmd.peice,
				")"
			}));
			if (flag != null && flag.Value)
			{
				cmd.peice.Delete();
			}
			break;
		}
		case global::AuthorShared.PeiceAction.Dirty:
			global::AuthorShared.SetDirty(cmd.peice);
			break;
		case global::AuthorShared.PeiceAction.Ping:
			global::AuthorShared.PingObject(cmd.peice);
			break;
		}
	}

	// Token: 0x0600003F RID: 63
	protected abstract void SaveSettings(global::JSONStream stream);

	// Token: 0x06000040 RID: 64
	protected abstract void LoadSettings(global::JSONStream stream);

	// Token: 0x06000041 RID: 65 RVA: 0x00002B5C File Offset: 0x00000D5C
	protected global::System.IO.Stream GetStream(bool write, string filepath, out global::AuthorCreationProject proj)
	{
		proj = global::AuthorCreationProject.current;
		if (!proj)
		{
			throw new global::System.InvalidOperationException("Theres no project loaded");
		}
		if (proj.FindAuthorCreationInScene() != this)
		{
			throw new global::System.InvalidOperationException("The current project is not for this creation");
		}
		return proj.GetStream(write, filepath);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00002BB0 File Offset: 0x00000DB0
	protected bool SaveSettings()
	{
		global::AuthorCreationProject authorCreationProject;
		global::System.IO.Stream stream = this.GetStream(true, "dat.asc", out authorCreationProject);
		if (stream != null)
		{
			try
			{
				using (global::JSONStream jsonstream = global::JSONStream.CreateWriter(stream))
				{
					jsonstream.WriteObjectStart();
					jsonstream.WriteObjectStart("project");
					jsonstream.WriteText("guid", global::AuthorShared.PathToGUID(global::AuthorShared.GetAssetPath(authorCreationProject)));
					jsonstream.WriteText("name", authorCreationProject.project);
					jsonstream.WriteText("author", authorCreationProject.authorName);
					jsonstream.WriteText("scene", authorCreationProject.scene);
					jsonstream.WriteText("folder", authorCreationProject.folder);
					jsonstream.WriteObjectEnd();
					jsonstream.WriteProperty("settings");
					this.SaveSettings(jsonstream);
					jsonstream.WriteObjectEnd();
				}
				return true;
			}
			finally
			{
				stream.Dispose();
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002CC0 File Offset: 0x00000EC0
	protected bool LoadSettings()
	{
		global::AuthorCreationProject authorCreationProject;
		global::System.IO.Stream stream = this.GetStream(true, "dat.asc", out authorCreationProject);
		if (stream != null)
		{
			try
			{
				using (global::JSONStream jsonstream = global::JSONStream.CreateWriter(stream))
				{
					while (jsonstream.Read())
					{
						global::JSONToken token = jsonstream.token;
						if (token == 1)
						{
							string text;
							while (jsonstream.ReadNextProperty(ref text))
							{
								string text2 = text;
								if (text2 != null)
								{
									if (global::AuthorCreation.<>f__switch$map0 == null)
									{
										global::AuthorCreation.<>f__switch$map0 = new global::System.Collections.Generic.Dictionary<string, int>(2)
										{
											{
												"project",
												0
											},
											{
												"settings",
												1
											}
										};
									}
									int num;
									if (global::AuthorCreation.<>f__switch$map0.TryGetValue(text2, out num))
									{
										if (num != 0)
										{
											if (num == 1)
											{
												this.LoadSettings(jsonstream);
											}
										}
										else
										{
											jsonstream.ReadSkip();
										}
									}
								}
							}
						}
					}
				}
				return true;
			}
			finally
			{
				stream.Dispose();
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002E00 File Offset: 0x00001000
	public virtual string RootBonePath(global::AuthorPeice callingPeice, global::UnityEngine.Transform bone)
	{
		return global::AuthorShared.CalculatePath(bone, bone.root);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002E10 File Offset: 0x00001010
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <SetSelection>m__0(global::AuthorPeice x, global::AuthorPeice y)
	{
		return this.allPeices.IndexOf(x).CompareTo(this.allPeices.IndexOf(y));
	}

	// Token: 0x0400001B RID: 27
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Object _output;

	// Token: 0x0400001C RID: 28
	[global::System.NonSerialized]
	public readonly global::System.Type outputType;

	// Token: 0x0400001D RID: 29
	protected int creationSeperatorHeight = 0x12C;

	// Token: 0x0400001E RID: 30
	protected int sideBarWidth = 0xC8;

	// Token: 0x0400001F RID: 31
	protected int palletLabelHeight = 0x30;

	// Token: 0x04000020 RID: 32
	protected int palletPanelWidth = 0x60;

	// Token: 0x04000021 RID: 33
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::AuthorPeice> allPeices;

	// Token: 0x04000022 RID: 34
	[global::System.NonSerialized]
	private global::System.Collections.Generic.List<global::AuthorPeice> selected;

	// Token: 0x04000023 RID: 35
	protected static readonly global::AuthorPalletObject[] NoPalletObjects = new global::AuthorPalletObject[0];

	// Token: 0x04000024 RID: 36
	protected static readonly global::AuthorPeice[] NoPeices = new global::AuthorPeice[0];

	// Token: 0x04000025 RID: 37
	private static readonly global::AuthorShared.PeiceCommand[] NoCommand = new global::AuthorShared.PeiceCommand[0];

	// Token: 0x04000026 RID: 38
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map0;

	// Token: 0x0200000C RID: 12
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoGUIPeiceInspector>c__Iterator3 : global::System.IDisposable, global::System.Collections.Generic.IEnumerable<global::AuthorPeice>, global::System.Collections.Generic.IEnumerator<global::AuthorPeice>, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00002E40 File Offset: 0x00001040
		public <DoGUIPeiceInspector>c__Iterator3()
		{
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002E48 File Offset: 0x00001048
		global::AuthorPeice global::System.Collections.Generic.IEnumerator<global::AuthorPeice>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002E50 File Offset: 0x00001050
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002E58 File Offset: 0x00001058
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<AuthorPeice>.GetEnumerator();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002E60 File Offset: 0x00001060
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::AuthorPeice> global::System.Collections.Generic.IEnumerable<global::AuthorPeice>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::AuthorCreation.<DoGUIPeiceInspector>c__Iterator3 <DoGUIPeiceInspector>c__Iterator = new global::AuthorCreation.<DoGUIPeiceInspector>c__Iterator3();
			<DoGUIPeiceInspector>c__Iterator.peices = peices;
			return <DoGUIPeiceInspector>c__Iterator;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002E94 File Offset: 0x00001094
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = peices.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					peice = enumerator.Current;
					global::AuthorShared.BeginVertical(global::AuthorShared.Styles.gradientOutline, new global::UnityEngine.GUILayoutOption[0]);
					b = peice.PeiceInspectorGUI();
					global::AuthorShared.EndVertical();
					if (b)
					{
						this.$current = peice;
						this.$PC = 1;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002F98 File Offset: 0x00001198
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002FF8 File Offset: 0x000011F8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000027 RID: 39
		internal global::System.Collections.Generic.List<global::AuthorPeice> peices;

		// Token: 0x04000028 RID: 40
		internal global::System.Collections.Generic.List<global::AuthorPeice>.Enumerator <$s_20>__0;

		// Token: 0x04000029 RID: 41
		internal global::AuthorPeice <peice>__1;

		// Token: 0x0400002A RID: 42
		internal bool <b>__2;

		// Token: 0x0400002B RID: 43
		internal int $PC;

		// Token: 0x0400002C RID: 44
		internal global::AuthorPeice $current;

		// Token: 0x0400002D RID: 45
		internal global::System.Collections.Generic.List<global::AuthorPeice> <$>peices;
	}

	// Token: 0x0200000D RID: 13
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoGUIPeiceList>c__Iterator4 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::AuthorShared.PeiceCommand>, global::System.Collections.Generic.IEnumerator<global::AuthorShared.PeiceCommand>
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00003000 File Offset: 0x00001200
		public <DoGUIPeiceList>c__Iterator4()
		{
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003008 File Offset: 0x00001208
		global::AuthorShared.PeiceCommand global::System.Collections.Generic.IEnumerator<global::AuthorShared.PeiceCommand>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00003010 File Offset: 0x00001210
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003020 File Offset: 0x00001220
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<AuthorShared.PeiceCommand>.GetEnumerator();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003028 File Offset: 0x00001228
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::AuthorShared.PeiceCommand> global::System.Collections.Generic.IEnumerable<global::AuthorShared.PeiceCommand>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::AuthorCreation.<DoGUIPeiceList>c__Iterator4 <DoGUIPeiceList>c__Iterator = new global::AuthorCreation.<DoGUIPeiceList>c__Iterator4();
			<DoGUIPeiceList>c__Iterator.peices = peices;
			return <DoGUIPeiceList>c__Iterator;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000305C File Offset: 0x0000125C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = peices.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					peice = enumerator.Current;
					global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]);
					action = peice.PeiceListGUI();
					global::AuthorShared.EndVertical();
					if (action != global::AuthorShared.PeiceAction.None)
					{
						this.$current = new global::AuthorShared.PeiceCommand
						{
							peice = peice,
							action = action
						};
						this.$PC = 1;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003178 File Offset: 0x00001378
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000031D8 File Offset: 0x000013D8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400002E RID: 46
		internal global::System.Collections.Generic.List<global::AuthorPeice> peices;

		// Token: 0x0400002F RID: 47
		internal global::System.Collections.Generic.List<global::AuthorPeice>.Enumerator <$s_21>__0;

		// Token: 0x04000030 RID: 48
		internal global::AuthorPeice <peice>__1;

		// Token: 0x04000031 RID: 49
		internal global::AuthorShared.PeiceAction <action>__2;

		// Token: 0x04000032 RID: 50
		internal int $PC;

		// Token: 0x04000033 RID: 51
		internal global::AuthorShared.PeiceCommand $current;

		// Token: 0x04000034 RID: 52
		internal global::System.Collections.Generic.List<global::AuthorPeice> <$>peices;
	}

	// Token: 0x0200000E RID: 14
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoSceneView>c__Iterator5 : global::System.IDisposable, global::System.Collections.Generic.IEnumerable<global::AuthorPeice>, global::System.Collections.Generic.IEnumerator<global::AuthorPeice>, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable
	{
		// Token: 0x06000056 RID: 86 RVA: 0x000031E0 File Offset: 0x000013E0
		public <DoSceneView>c__Iterator5()
		{
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000031E8 File Offset: 0x000013E8
		global::AuthorPeice global::System.Collections.Generic.IEnumerator<global::AuthorPeice>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000031F0 File Offset: 0x000013F0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000031F8 File Offset: 0x000013F8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<AuthorPeice>.GetEnumerator();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003200 File Offset: 0x00001400
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::AuthorPeice> global::System.Collections.Generic.IEnumerable<global::AuthorPeice>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::AuthorCreation.<DoSceneView>c__Iterator5 <DoSceneView>c__Iterator = new global::AuthorCreation.<DoSceneView>c__Iterator5();
			<DoSceneView>c__Iterator.<>f__this = this;
			return <DoSceneView>c__Iterator;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003234 File Offset: 0x00001434
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				if (this.selected == null)
				{
					goto IL_126;
				}
				mat = global::AuthorShared.Scene.matrix;
				color = global::AuthorShared.Scene.color;
				lighting = global::AuthorShared.Scene.lighting;
				enumerator = this.selected.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					peice = enumerator.Current;
					if (peice)
					{
						try
						{
							change = peice.OnSceneView();
						}
						finally
						{
							global::AuthorShared.Scene.matrix = mat;
							global::AuthorShared.Scene.color = color;
							global::AuthorShared.Scene.lighting = lighting;
						}
						if (change)
						{
							this.$current = peice;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			IL_126:
			this.$PC = -1;
			return false;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000033A8 File Offset: 0x000015A8
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003408 File Offset: 0x00001608
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000035 RID: 53
		internal global::UnityEngine.Matrix4x4 <mat>__0;

		// Token: 0x04000036 RID: 54
		internal global::UnityEngine.Color <color>__1;

		// Token: 0x04000037 RID: 55
		internal bool <lighting>__2;

		// Token: 0x04000038 RID: 56
		internal global::System.Collections.Generic.List<global::AuthorPeice>.Enumerator <$s_22>__3;

		// Token: 0x04000039 RID: 57
		internal global::AuthorPeice <peice>__4;

		// Token: 0x0400003A RID: 58
		internal bool <change>__5;

		// Token: 0x0400003B RID: 59
		internal int $PC;

		// Token: 0x0400003C RID: 60
		internal global::AuthorPeice $current;

		// Token: 0x0400003D RID: 61
		internal global::AuthorCreation <>f__this;
	}
}
