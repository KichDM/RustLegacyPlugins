using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A8 RID: 168
[global::UnityEngine.AddComponentMenu("")]
public sealed class AvatarSaveProc : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600033D RID: 829 RVA: 0x0000F8D4 File Offset: 0x0000DAD4
	public AvatarSaveProc()
	{
	}

	// Token: 0x0600033E RID: 830 RVA: 0x0000F8DC File Offset: 0x0000DADC
	public static void Manage(global::AvatarSaveRestore avatarSaveRestore)
	{
		if (avatarSaveRestore && !avatarSaveRestore.__managed_by_save_proc)
		{
			if (global::AvatarSaveProc.g.singleton.current != avatarSaveRestore)
			{
				global::AvatarSaveProc.g.singleton.queue.Enqueue(avatarSaveRestore);
			}
			avatarSaveRestore.__managed_by_save_proc = true;
		}
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0000F92C File Offset: 0x0000DB2C
	public static void UnManage(global::AvatarSaveRestore avatarSaveRestore)
	{
		if (avatarSaveRestore && avatarSaveRestore.__managed_by_save_proc)
		{
			if (global::AvatarSaveProc.g.singleton.current != avatarSaveRestore)
			{
				int i = 0;
				int count = global::AvatarSaveProc.g.singleton.queue.Count;
				while (i < count)
				{
					global::AvatarSaveRestore avatarSaveRestore2 = global::AvatarSaveProc.g.singleton.queue.Dequeue();
					if (avatarSaveRestore2 == avatarSaveRestore)
					{
						while (++i < count)
						{
							global::AvatarSaveProc.g.singleton.queue.Enqueue(global::AvatarSaveProc.g.singleton.queue.Dequeue());
						}
						break;
					}
					global::AvatarSaveProc.g.singleton.queue.Enqueue(avatarSaveRestore2);
					i++;
				}
			}
			avatarSaveRestore.__managed_by_save_proc = false;
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0000F9EC File Offset: 0x0000DBEC
	public static void MoveBack(global::AvatarSaveRestore avatarSaveRestore)
	{
		if (avatarSaveRestore && avatarSaveRestore.__managed_by_save_proc)
		{
			if (global::AvatarSaveProc.g.singleton.current == avatarSaveRestore)
			{
				return;
			}
			int i = 0;
			int count = global::AvatarSaveProc.g.singleton.queue.Count;
			while (i < count)
			{
				global::AvatarSaveRestore avatarSaveRestore2 = global::AvatarSaveProc.g.singleton.queue.Dequeue();
				if (avatarSaveRestore2 == avatarSaveRestore)
				{
					while (++i < count)
					{
						global::AvatarSaveProc.g.singleton.queue.Enqueue(global::AvatarSaveProc.g.singleton.queue.Dequeue());
					}
					global::AvatarSaveProc.g.singleton.queue.Enqueue(avatarSaveRestore);
					break;
				}
				global::AvatarSaveProc.g.singleton.queue.Enqueue(avatarSaveRestore2);
				i++;
			}
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0000FAB8 File Offset: 0x0000DCB8
	public static int Save(int count)
	{
		if (global::AvatarSaveProc.g.singleton.saving)
		{
			return -1;
		}
		global::AvatarSaveProc.g.singleton.saving = true;
		int result;
		try
		{
			int count2 = global::AvatarSaveProc.g.singleton.queue.Count;
			if (count > count2)
			{
				count = count2;
			}
			int num = 0;
			while (count-- > 0)
			{
				try
				{
					global::AvatarSaveProc.g.singleton.current = global::AvatarSaveProc.g.singleton.queue.Dequeue();
					global::AvatarSaveProc.g.singleton.current.SaveAvatar();
					num++;
				}
				finally
				{
					global::AvatarSaveRestore avatarSaveRestore = global::AvatarSaveProc.g.singleton.current;
					global::AvatarSaveProc.g.singleton.current = null;
					if (avatarSaveRestore && avatarSaveRestore.__managed_by_save_proc)
					{
						global::AvatarSaveProc.g.singleton.queue.Enqueue(avatarSaveRestore);
					}
				}
			}
			result = num;
		}
		finally
		{
			global::AvatarSaveProc.g.singleton.saving = false;
		}
		return result;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0000FBCC File Offset: 0x0000DDCC
	public static int SaveAll()
	{
		return global::AvatarSaveProc.Save(global::AvatarSaveProc.g.singleton.queue.Count);
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0000FBE4 File Offset: 0x0000DDE4
	private void Update()
	{
		ulong localTimeInMillis = global::NetCull.localTimeInMillis;
		int count;
		if (localTimeInMillis < this.lastSaveProcTime)
		{
			count = 2;
			this.lastSaveProcTime = localTimeInMillis;
		}
		else
		{
			ulong num = localTimeInMillis - this.lastSaveProcTime;
			if (num < 0x6D6UL)
			{
				return;
			}
			this.lastSaveProcTime = localTimeInMillis;
			count = 2;
		}
		global::AvatarSaveProc.Save(count);
	}

	// Token: 0x040002F6 RID: 758
	private const ulong SaveIntervalMillis = 0x6D6UL;

	// Token: 0x040002F7 RID: 759
	private const int SaveCountPerInterval = 2;

	// Token: 0x040002F8 RID: 760
	[global::System.NonSerialized]
	private ulong lastSaveProcTime;

	// Token: 0x040002F9 RID: 761
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Queue<global::AvatarSaveRestore> queue;

	// Token: 0x040002FA RID: 762
	[global::System.NonSerialized]
	private global::AvatarSaveRestore current;

	// Token: 0x040002FB RID: 763
	[global::System.NonSerialized]
	private bool saving;

	// Token: 0x020000A9 RID: 169
	private static class g
	{
		// Token: 0x06000344 RID: 836 RVA: 0x0000FC38 File Offset: 0x0000DE38
		static g()
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.GameObject.Find("__AVATAR_SAVE_PROC_");
			if (!gameObject)
			{
				gameObject = new global::UnityEngine.GameObject("__AVATAR_SAVE_PROC_", new global::System.Type[]
				{
					typeof(global::AvatarSaveProc)
				})
				{
					hideFlags = 0xD
				};
			}
			global::AvatarSaveProc.g.singleton = gameObject.GetComponent<global::AvatarSaveProc>();
			if (!global::AvatarSaveProc.g.singleton)
			{
				global::AvatarSaveProc.g.singleton = gameObject.AddComponent<global::AvatarSaveProc>();
			}
			global::AvatarSaveProc.g.singleton.queue = new global::System.Collections.Generic.Queue<global::AvatarSaveRestore>();
		}

		// Token: 0x040002FC RID: 764
		private const string gameObjectName = "__AVATAR_SAVE_PROC_";

		// Token: 0x040002FD RID: 765
		public static global::AvatarSaveProc singleton;
	}
}
