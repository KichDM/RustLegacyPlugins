using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class AuthorPeice : global::AuthorShared
{
	// Token: 0x0600007A RID: 122 RVA: 0x000034D8 File Offset: 0x000016D8
	public AuthorPeice()
	{
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x0600007B RID: 123 RVA: 0x000034E0 File Offset: 0x000016E0
	public global::AuthorCreation creation
	{
		get
		{
			return this._creation;
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x0600007C RID: 124 RVA: 0x000034E8 File Offset: 0x000016E8
	// (set) Token: 0x0600007D RID: 125 RVA: 0x000034F0 File Offset: 0x000016F0
	public string peiceID
	{
		get
		{
			return this._peiceID;
		}
		set
		{
			this._peiceID = (value ?? string.Empty);
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00003508 File Offset: 0x00001708
	public void Registered(global::AuthorCreation creation)
	{
		this._creation = creation;
		this._peiceID = (this._peiceID ?? string.Empty);
		this.OnRegistered();
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00003530 File Offset: 0x00001730
	protected virtual void OnRegistered()
	{
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00003534 File Offset: 0x00001734
	public virtual bool PeiceInspectorGUI()
	{
		global::AuthorShared.BeginHorizontal(global::AuthorShared.Styles.gradientInlineFill, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.GUILayout.Space(48f);
		if (global::UnityEngine.GUILayout.Button(global::AuthorShared.ObjectContent<global::UnityEngine.Transform>(base.transform, typeof(global::UnityEngine.Transform)).image, new global::UnityEngine.GUILayoutOption[]
		{
			global::UnityEngine.GUILayout.ExpandWidth(false),
			global::UnityEngine.GUILayout.ExpandHeight(false)
		}))
		{
			global::AuthorShared.PingObject(this);
		}
		global::UnityEngine.GUILayout.Space(10f);
		global::UnityEngine.GUILayout.Label(this.peiceID, global::AuthorShared.Styles.boldLabel, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.GUILayout.FlexibleSpace();
		global::AuthorShared.EndHorizontal();
		return false;
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000081 RID: 129 RVA: 0x000035CC File Offset: 0x000017CC
	public global::UnityEngine.Object selectReference
	{
		get
		{
			return base.gameObject;
		}
	}

	// Token: 0x06000082 RID: 130 RVA: 0x000035D4 File Offset: 0x000017D4
	protected static bool ActionButton(global::AuthorShared.Content content, ref global::AuthorShared.PeiceAction act, bool isSelected, global::AuthorShared.PeiceAction onAction, global::AuthorShared.PeiceAction offAction, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		if (global::AuthorShared.Toggle(content, isSelected, style, options) != isSelected)
		{
			act = ((!isSelected) ? onAction : offAction);
			return true;
		}
		return false;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00003608 File Offset: 0x00001808
	protected static bool ActionButton(global::AuthorShared.Content content, ref global::AuthorShared.PeiceAction act, bool isSelected, global::AuthorShared.PeiceAction action, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		if (global::AuthorShared.Toggle(content, isSelected, style, options) != isSelected)
		{
			act = action;
			return true;
		}
		return false;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00003624 File Offset: 0x00001824
	public virtual global::AuthorShared.PeiceAction PeiceListGUI()
	{
		bool isSelected = global::AuthorShared.SelectionContains(this.selectReference) || global::AuthorShared.SelectionContains(this);
		global::AuthorShared.PeiceAction result = global::AuthorShared.PeiceAction.None;
		global::AuthorShared.BeginHorizontal(new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorPeice.ActionButton(this.peiceID, ref result, isSelected, global::AuthorShared.PeiceAction.AddToSelection, global::AuthorShared.PeiceAction.RemoveFromSelection, global::AuthorShared.Styles.peiceButtonLeft, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorPeice.ActionButton(global::AuthorShared.Icon.solo, ref result, isSelected, global::AuthorShared.PeiceAction.SelectSolo, global::AuthorShared.Styles.peiceButtonMid, new global::UnityEngine.GUILayoutOption[]
		{
			global::UnityEngine.GUILayout.ExpandWidth(false)
		});
		global::UnityEngine.Color contentColor = global::UnityEngine.GUI.contentColor;
		global::UnityEngine.GUI.contentColor = global::UnityEngine.Color.red;
		global::AuthorPeice.ActionButton(global::AuthorShared.Icon.delete, ref result, isSelected, global::AuthorShared.PeiceAction.Delete, global::AuthorShared.Styles.peiceButtonRight, new global::UnityEngine.GUILayoutOption[]
		{
			global::UnityEngine.GUILayout.ExpandWidth(false)
		});
		global::UnityEngine.GUI.contentColor = contentColor;
		global::AuthorShared.EndHorizontal();
		return result;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x000036E8 File Offset: 0x000018E8
	public virtual void OnListClicked()
	{
		if (global::AuthorShared.SelectionContains(this.selectReference) || global::AuthorShared.SelectionContains(this))
		{
		}
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00003718 File Offset: 0x00001918
	public virtual bool OnSceneView()
	{
		return false;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000371C File Offset: 0x0000191C
	protected virtual void OnWillUnRegister()
	{
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00003720 File Offset: 0x00001920
	protected virtual void OnDidUnRegister()
	{
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00003724 File Offset: 0x00001924
	public void Delete()
	{
		if (!this.destroyed)
		{
			try
			{
				this.OnPeiceDestroy();
			}
			finally
			{
				this.destroyed = true;
				global::UnityEngine.Object.DestroyImmediate(this);
			}
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00003774 File Offset: 0x00001974
	protected virtual void OnPeiceDestroy()
	{
		if (this._creation)
		{
			this.OnWillUnRegister();
			this._creation.UnregisterPeice(this);
			this.OnDidUnRegister();
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x000037AC File Offset: 0x000019AC
	public virtual void SaveJsonProperties(global::JSONStream stream)
	{
	}

	// Token: 0x0600008C RID: 140 RVA: 0x000037B0 File Offset: 0x000019B0
	protected string FromRootBonePath(global::UnityEngine.Transform transform)
	{
		if (this.creation)
		{
			return this.creation.RootBonePath(this, transform);
		}
		return string.Empty;
	}

	// Token: 0x04000046 RID: 70
	[global::UnityEngine.SerializeField]
	private global::AuthorCreation _creation;

	// Token: 0x04000047 RID: 71
	[global::UnityEngine.SerializeField]
	private string _peiceID;

	// Token: 0x04000048 RID: 72
	private bool destroyed;
}
