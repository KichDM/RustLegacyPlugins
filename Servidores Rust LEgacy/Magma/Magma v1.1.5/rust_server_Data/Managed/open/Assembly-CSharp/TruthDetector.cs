using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class TruthDetector
{
	// Token: 0x060025F1 RID: 9713 RVA: 0x00091658 File Offset: 0x0008F858
	public TruthDetector()
	{
		this.snapshots = new global::TruthDetector.SnapshotBuffer(new global::TruthDetector.Snapshot[0x10]);
	}

	// Token: 0x060025F2 RID: 9714 RVA: 0x0009168C File Offset: 0x0008F88C
	public void Init(global::NetUser nu)
	{
		this.netUser = nu;
	}

	// Token: 0x060025F3 RID: 9715 RVA: 0x00091698 File Offset: 0x0008F898
	public global::TruthDetector.ActionTaken NoteMoved(ref global::UnityEngine.Vector3 pos, global::Angle2 ang, double time)
	{
		if (this.prevSnap.time > 0.0)
		{
			if (this.ignoreSeconds > 0.0)
			{
				if (time > this.prevSnap.time)
				{
					this.ignoreSeconds -= time - this.prevSnap.time;
				}
			}
			else
			{
				if (this.Test_MovementSpeed(this.prevSnap.pos, pos, time - this.prevSnap.time))
				{
					return global::TruthDetector.ActionTaken.None;
				}
				if (this.Test_MovementTrace(this.prevSnap.pos, ref pos))
				{
					return global::TruthDetector.ActionTaken.Moved;
				}
			}
		}
		this.prevSnap.pos = pos;
		this.prevSnap.time = time;
		this.Record();
		if (this.violation > 0)
		{
			this.violation--;
			if (global::truth.punish && this.violation > global::truth.threshold)
			{
				this.LogPunishment("kicked for violation " + this.violation);
				this.netUser.Kick(global::NetError.Facepunch_Kick_Violation, true);
				return global::TruthDetector.ActionTaken.Kicked;
			}
		}
		return global::TruthDetector.ActionTaken.None;
	}

	// Token: 0x060025F4 RID: 9716 RVA: 0x000917D0 File Offset: 0x0008F9D0
	public void NoteTeleported(global::UnityEngine.Vector3 pos, double graceSeconds = 0.0)
	{
		this.Reset();
		this.prevSnap.pos = pos;
		if (graceSeconds > 0.0)
		{
			if (this.ignoreSeconds < 0.0)
			{
				this.ignoreSeconds = graceSeconds;
			}
			else
			{
				this.ignoreSeconds += graceSeconds;
			}
		}
	}

	// Token: 0x060025F5 RID: 9717 RVA: 0x0009182C File Offset: 0x0008FA2C
	public bool Test_MovementSpeed(global::UnityEngine.Vector3 oldpos, global::UnityEngine.Vector3 newpos, double deltaTime)
	{
		if (deltaTime <= 0.0)
		{
			return false;
		}
		global::UnityEngine.Vector3 vector = newpos - oldpos;
		double num = (double)vector.magnitude;
		double num2 = num / deltaTime;
		double num3 = 20.0;
		if ((double)vector.y < 0.0)
		{
			num3 = 100.0;
		}
		if (num2 > num3)
		{
			this.violation += (int)num2;
		}
		return false;
	}

	// Token: 0x060025F6 RID: 9718 RVA: 0x000918A0 File Offset: 0x0008FAA0
	public bool Test_MovementTrace(global::UnityEngine.Vector3 oldpos, ref global::UnityEngine.Vector3 newpos)
	{
		if (this.ignoreSeconds > 0.0)
		{
			return false;
		}
		global::UnityEngine.Vector3 vector = newpos - oldpos;
		global::UnityEngine.Ray ray;
		ray..ctor(oldpos + new global::UnityEngine.Vector3(0f, 0.5f, 0f), vector.normalized);
		global::UnityEngine.RaycastHit raycastHit;
		if (!global::UnityEngine.Physics.Raycast(ray, ref raycastHit, vector.magnitude, 0x20180403))
		{
			return false;
		}
		this.violation += 0x64;
		if (!global::truth.punish)
		{
			return false;
		}
		if (this.netUser.playerClient == null)
		{
			return false;
		}
		if (this.netUser.playerClient.controllable == null)
		{
			return false;
		}
		if (this.netUser.playerClient.controllable.idMain == null)
		{
			return false;
		}
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (!serverManagement)
		{
			return false;
		}
		global::UnityEngine.Vector3 vector2 = oldpos;
		if (!global::TruthDetector.Moved(ref vector2, ref newpos) && this.snapshots.length > 0)
		{
			do
			{
				vector2 = this.snapshots.array[this.snapshots.end].pos;
			}
			while (!global::TruthDetector.Moved(ref vector2, ref newpos) && this.Rollback());
			this.prevSnap = this.snapshots.array[this.snapshots.end];
		}
		newpos = vector2;
		return true;
	}

	// Token: 0x060025F7 RID: 9719 RVA: 0x00091A28 File Offset: 0x0008FC28
	public void LogPunishment(string str)
	{
		str = string.Concat(new string[]
		{
			"[",
			this.violation.ToString(),
			"]",
			this.netUser.ToString(),
			" ",
			str
		});
		global::UnityEngine.Debug.Log("[T]" + str);
	}

	// Token: 0x060025F8 RID: 9720 RVA: 0x00091A8C File Offset: 0x0008FC8C
	protected static bool Moved(ref global::UnityEngine.Vector3 a, ref global::UnityEngine.Vector3 b)
	{
		float num = a.x - b.x;
		float num2 = a.y - b.y;
		float num3 = a.z - b.z;
		return num * num + num2 * num2 + num3 * num3 >= 0.25f;
	}

	// Token: 0x060025F9 RID: 9721 RVA: 0x00091AD8 File Offset: 0x0008FCD8
	protected bool Rollback()
	{
		if (this.snapshots.length > 1)
		{
			this.snapshots.length = this.snapshots.length - 1;
			if ((this.snapshots.end = this.snapshots.end - 1) < 0)
			{
				this.snapshots.end = 0xF;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060025FA RID: 9722 RVA: 0x00091B38 File Offset: 0x0008FD38
	protected void Reset()
	{
		this.snapshots.length = 0;
		this.prevSnap.time = 0.0;
	}

	// Token: 0x060025FB RID: 9723 RVA: 0x00091B68 File Offset: 0x0008FD68
	protected void Record()
	{
		if (this.snapshots.length == 0)
		{
			this.snapshots.end = 0;
			this.snapshots.length = 1;
		}
		else
		{
			if (this.snapshots.length < 0x10)
			{
				if (this.prevSnap.pos == this.snapshots.array[this.snapshots.end].pos)
				{
					return;
				}
				this.snapshots.length = this.snapshots.length + 1;
			}
			else if (!global::TruthDetector.Moved(ref this.prevSnap.pos, ref this.snapshots.array[this.snapshots.end].pos))
			{
				return;
			}
			if ((this.snapshots.end = this.snapshots.end + 1) == 0x10)
			{
				this.snapshots.end = 0;
			}
		}
		this.snapshots.array[this.snapshots.end] = this.prevSnap;
	}

	// Token: 0x0400134B RID: 4939
	protected const int snapshotSize = 0x10;

	// Token: 0x0400134C RID: 4940
	protected const float kMinMovement = 0.5f;

	// Token: 0x0400134D RID: 4941
	protected int violation;

	// Token: 0x0400134E RID: 4942
	protected global::TruthDetector.Snapshot prevSnap = default(global::TruthDetector.Snapshot);

	// Token: 0x0400134F RID: 4943
	protected global::NetUser netUser;

	// Token: 0x04001350 RID: 4944
	protected double ignoreSeconds;

	// Token: 0x04001351 RID: 4945
	protected global::UnityEngine.Vector3 jumpOrigin;

	// Token: 0x04001352 RID: 4946
	protected global::TruthDetector.SnapshotBuffer snapshots;

	// Token: 0x02000445 RID: 1093
	protected struct Snapshot
	{
		// Token: 0x04001353 RID: 4947
		public global::UnityEngine.Vector3 pos;

		// Token: 0x04001354 RID: 4948
		public double time;
	}

	// Token: 0x02000446 RID: 1094
	public enum ActionTaken
	{
		// Token: 0x04001356 RID: 4950
		None,
		// Token: 0x04001357 RID: 4951
		Kicked,
		// Token: 0x04001358 RID: 4952
		Moved
	}

	// Token: 0x02000447 RID: 1095
	protected struct SnapshotBuffer
	{
		// Token: 0x060025FC RID: 9724 RVA: 0x00091C88 File Offset: 0x0008FE88
		public SnapshotBuffer(global::TruthDetector.Snapshot[] array)
		{
			this.array = array;
			this.length = 0;
			this.end = 0;
		}

		// Token: 0x04001359 RID: 4953
		public readonly global::TruthDetector.Snapshot[] array;

		// Token: 0x0400135A RID: 4954
		public int length;

		// Token: 0x0400135B RID: 4955
		public int end;
	}
}
