using System;
using System.IO;
using UnityEngine;

// Token: 0x02000012 RID: 18
public sealed class AuthorCreationProject : global::UnityEngine.ScriptableObject
{
	// Token: 0x06000069 RID: 105 RVA: 0x0000346C File Offset: 0x0000166C
	public AuthorCreationProject()
	{
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600006A RID: 106 RVA: 0x00003474 File Offset: 0x00001674
	public string scene
	{
		get
		{
			return this._scene;
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600006B RID: 107 RVA: 0x0000347C File Offset: 0x0000167C
	public string folder
	{
		get
		{
			return this._folder;
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600006C RID: 108 RVA: 0x00003484 File Offset: 0x00001684
	public string script
	{
		get
		{
			return this._script;
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x0600006D RID: 109 RVA: 0x0000348C File Offset: 0x0000168C
	public string project
	{
		get
		{
			return this._project;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x0600006E RID: 110 RVA: 0x00003494 File Offset: 0x00001694
	public string authorName
	{
		get
		{
			return this._authorName;
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x0000349C File Offset: 0x0000169C
	public global::System.IO.Stream GetStream(bool write, string filepath)
	{
		return null;
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000070 RID: 112 RVA: 0x000034A0 File Offset: 0x000016A0
	public static global::AuthorCreationProject current
	{
		get
		{
			return null;
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000071 RID: 113 RVA: 0x000034A4 File Offset: 0x000016A4
	public string scenePath
	{
		get
		{
			return string.Empty;
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000072 RID: 114 RVA: 0x000034AC File Offset: 0x000016AC
	public string folderPath
	{
		get
		{
			return string.Empty;
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000073 RID: 115 RVA: 0x000034B4 File Offset: 0x000016B4
	public string scriptPath
	{
		get
		{
			return string.Empty;
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000074 RID: 116 RVA: 0x000034BC File Offset: 0x000016BC
	public string singletonName
	{
		get
		{
			return string.Empty;
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x06000075 RID: 117 RVA: 0x000034C4 File Offset: 0x000016C4
	public global::UnityEngine.Object monoScript
	{
		get
		{
			return null;
		}
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000076 RID: 118 RVA: 0x000034C8 File Offset: 0x000016C8
	public global::System.Type authorCreationType
	{
		get
		{
			return null;
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000077 RID: 119 RVA: 0x000034CC File Offset: 0x000016CC
	public bool isCurrent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000078 RID: 120 RVA: 0x000034D0 File Offset: 0x000016D0
	public global::UnityEngine.GameObject FindAuthorCreationGameObjectInScene()
	{
		return null;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x000034D4 File Offset: 0x000016D4
	public global::AuthorCreation FindAuthorCreationInScene()
	{
		return null;
	}

	// Token: 0x04000041 RID: 65
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string _scene;

	// Token: 0x04000042 RID: 66
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string _folder;

	// Token: 0x04000043 RID: 67
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string _script;

	// Token: 0x04000044 RID: 68
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string _project;

	// Token: 0x04000045 RID: 69
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string _authorName;
}
