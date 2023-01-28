using System;
using System.Collections.Generic;
using RustProto;
using UnityEngine;

// Token: 0x02000793 RID: 1939
public class PasswordLockableObject : global::LockableObject
{
	// Token: 0x0600407E RID: 16510 RVA: 0x000E6C50 File Offset: 0x000E4E50
	public PasswordLockableObject()
	{
	}

	// Token: 0x0600407F RID: 16511 RVA: 0x000E6C64 File Offset: 0x000E4E64
	public void Awake()
	{
		this._validUsers = new global::System.Collections.Generic.HashSet<ulong>();
	}

	// Token: 0x06004080 RID: 16512 RVA: 0x000E6C74 File Offset: 0x000E4E74
	public override bool HasAccess(ulong userid)
	{
		return this._validUsers.Contains(userid);
	}

	// Token: 0x06004081 RID: 16513 RVA: 0x000E6C8C File Offset: 0x000E4E8C
	public void SetPassword(string newpassword)
	{
		this.password = newpassword;
		this._validUsers = new global::System.Collections.Generic.HashSet<ulong>();
	}

	// Token: 0x06004082 RID: 16514 RVA: 0x000E6CA0 File Offset: 0x000E4EA0
	public bool ChangePassword(string oldpassword, string newpassword)
	{
		if (this.CheckPassword(oldpassword))
		{
			this.SetPassword(newpassword);
			return true;
		}
		return false;
	}

	// Token: 0x06004083 RID: 16515 RVA: 0x000E6CB8 File Offset: 0x000E4EB8
	public bool CanCheckPasswordYet()
	{
		return global::UnityEngine.Time.time - this.lastFailTime > 5f;
	}

	// Token: 0x06004084 RID: 16516 RVA: 0x000E6CD0 File Offset: 0x000E4ED0
	public void MarkFail()
	{
		this.lastFailTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06004085 RID: 16517 RVA: 0x000E6CE0 File Offset: 0x000E4EE0
	public bool CheckPassword(string checkpassword)
	{
		return this.password != string.Empty && checkpassword == this.password;
	}

	// Token: 0x06004086 RID: 16518 RVA: 0x000E6D0C File Offset: 0x000E4F0C
	public void AddUser(ulong userid)
	{
		if (this._validUsers.Contains(userid))
		{
			return;
		}
		this._validUsers.Add(userid);
	}

	// Token: 0x06004087 RID: 16519 RVA: 0x000E6D30 File Offset: 0x000E4F30
	public void RemoveUser(ulong userid)
	{
		if (!this._validUsers.Contains(userid))
		{
			return;
		}
		this._validUsers.Remove(userid);
	}

	// Token: 0x06004088 RID: 16520 RVA: 0x000E6D54 File Offset: 0x000E4F54
	public override void ReadLockable(global::RustProto.objectLockable lockable)
	{
		base.ReadLockable(lockable);
		this.password = ((!lockable.HasPassword) ? string.Empty : lockable.Password);
		this._validUsers = new global::System.Collections.Generic.HashSet<ulong>(lockable.UsersList);
	}

	// Token: 0x06004089 RID: 16521 RVA: 0x000E6D9C File Offset: 0x000E4F9C
	public override void WriteLockable(global::RustProto.objectLockable.Builder builder)
	{
		base.WriteLockable(builder);
		if (this.password != null && this.password != string.Empty)
		{
			builder.SetPassword(this.password);
		}
		if (this._validUsers != null)
		{
			builder.AddRangeUsers(this._validUsers);
		}
	}

	// Token: 0x0400219E RID: 8606
	[global::System.NonSerialized]
	private global::System.Collections.Generic.HashSet<ulong> _validUsers;

	// Token: 0x0400219F RID: 8607
	[global::System.NonSerialized]
	private string password;

	// Token: 0x040021A0 RID: 8608
	[global::System.NonSerialized]
	private float lastFailTime = -100f;
}
