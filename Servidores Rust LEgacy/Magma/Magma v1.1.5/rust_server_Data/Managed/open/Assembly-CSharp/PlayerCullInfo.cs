using System;
using System.Collections.Generic;

// Token: 0x02000334 RID: 820
internal class PlayerCullInfo
{
	// Token: 0x06001BC0 RID: 7104 RVA: 0x0006F3E8 File Offset: 0x0006D5E8
	public PlayerCullInfo()
	{
		this.groups = new global::System.Collections.Generic.HashSet<ushort>();
		this.owned = new global::System.Collections.Generic.HashSet<global::NetworkCullInfo>();
	}

	// Token: 0x06001BC1 RID: 7105 RVA: 0x0006F408 File Offset: 0x0006D608
	// Note: this type is marked as 'beforefieldinit'.
	static PlayerCullInfo()
	{
	}

	// Token: 0x06001BC2 RID: 7106 RVA: 0x0006F414 File Offset: 0x0006D614
	public bool DequeueUnion(global::NetUser player)
	{
		bool flag = false;
		foreach (ushort num in this.queuedGroups)
		{
			if (this.groups.Add(num))
			{
				bool flag2;
				try
				{
					flag2 = global::CullGrid.AddPlayerToCell(player, num);
				}
				catch
				{
					this.groups.Remove(num);
					throw;
				}
				if (!flag2)
				{
					this.groups.Remove(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		return flag && this.queuedGroups.SetEquals(this.groups);
	}

	// Token: 0x06001BC3 RID: 7107 RVA: 0x0006F4F4 File Offset: 0x0006D6F4
	public bool DequeueExcept(global::NetUser player)
	{
		bool flag = false;
		foreach (ushort item in this.groups)
		{
			if (!this.queuedGroups.Contains(item))
			{
				global::PlayerCullInfo.tempRemoveList.Add(item);
				flag = true;
			}
		}
		if (flag)
		{
			foreach (ushort num in global::PlayerCullInfo.tempRemoveList)
			{
				if (global::CullGrid.RemovePlayerFromCell(player, num))
				{
					this.groups.Remove(num);
				}
			}
			global::PlayerCullInfo.tempRemoveList.Clear();
			return this.queuedGroups.SetEquals(this.groups);
		}
		return false;
	}

	// Token: 0x04001038 RID: 4152
	public readonly global::System.Collections.Generic.HashSet<ushort> groups;

	// Token: 0x04001039 RID: 4153
	public readonly global::System.Collections.Generic.HashSet<global::NetworkCullInfo> owned;

	// Token: 0x0400103A RID: 4154
	public global::System.Collections.Generic.HashSet<ushort> queuedGroups;

	// Token: 0x0400103B RID: 4155
	public global::NetworkCullInfo rootInfo;

	// Token: 0x0400103C RID: 4156
	private static global::System.Collections.Generic.List<ushort> tempRemoveList = new global::System.Collections.Generic.List<ushort>();
}
