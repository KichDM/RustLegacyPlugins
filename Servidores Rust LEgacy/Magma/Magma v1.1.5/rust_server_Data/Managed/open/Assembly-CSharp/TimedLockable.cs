using System;
using UnityEngine;

// Token: 0x0200079F RID: 1951
public class TimedLockable : global::LockableObject
{
	// Token: 0x060040DE RID: 16606 RVA: 0x000E90F8 File Offset: 0x000E72F8
	public TimedLockable()
	{
	}

	// Token: 0x060040DF RID: 16607 RVA: 0x000E9100 File Offset: 0x000E7300
	public override bool IsPickable()
	{
		return true;
	}

	// Token: 0x060040E0 RID: 16608 RVA: 0x000E9104 File Offset: 0x000E7304
	public override bool PickAttempt(float skill)
	{
		this.Unlock();
		return true;
	}

	// Token: 0x060040E1 RID: 16609 RVA: 0x000E9110 File Offset: 0x000E7310
	public void Awake()
	{
		base.SetLockActive(false);
	}

	// Token: 0x060040E2 RID: 16610 RVA: 0x000E911C File Offset: 0x000E731C
	public void LockFor(float duration)
	{
		this.lockActive = true;
		this.lockTime = global::UnityEngine.Time.time;
		base.Invoke("Unlock", duration);
	}

	// Token: 0x060040E3 RID: 16611 RVA: 0x000E913C File Offset: 0x000E733C
	public void SetOwner(ulong userid)
	{
		this.ownerID = userid;
	}

	// Token: 0x060040E4 RID: 16612 RVA: 0x000E9148 File Offset: 0x000E7348
	private void Unlock()
	{
		this.lockActive = false;
	}

	// Token: 0x060040E5 RID: 16613 RVA: 0x000E9154 File Offset: 0x000E7354
	public override bool HasAccess(ulong userid)
	{
		return !this.lockActive || userid == this.ownerID;
	}

	// Token: 0x060040E6 RID: 16614 RVA: 0x000E9170 File Offset: 0x000E7370
	public override string GetLockedStringForPopup(global::Controllable controllable)
	{
		if (this.lockActive)
		{
			return "Locked for a while...";
		}
		return "Unlocked! (This is an error)";
	}

	// Token: 0x040021DC RID: 8668
	private ulong ownerID;

	// Token: 0x040021DD RID: 8669
	private float lockTime;
}
