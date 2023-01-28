using System;

// Token: 0x02000337 RID: 823
public struct DeployedObjectInfo
{
	// Token: 0x1700079A RID: 1946
	// (get) Token: 0x06001BCA RID: 7114 RVA: 0x0006F718 File Offset: 0x0006D918
	public global::PlayerClient playerClient
	{
		get
		{
			if (!this.valid)
			{
				return null;
			}
			global::PlayerClient result;
			global::PlayerClient.FindByUserID(this.userID, out result);
			return result;
		}
	}

	// Token: 0x1700079B RID: 1947
	// (get) Token: 0x06001BCB RID: 7115 RVA: 0x0006F744 File Offset: 0x0006D944
	public global::Controllable playerControllable
	{
		get
		{
			if (!this.valid)
			{
				return null;
			}
			global::PlayerClient playerClient = this.playerClient;
			if (playerClient)
			{
				return playerClient.controllable;
			}
			return null;
		}
	}

	// Token: 0x1700079C RID: 1948
	// (get) Token: 0x06001BCC RID: 7116 RVA: 0x0006F778 File Offset: 0x0006D978
	public global::Character playerCharacter
	{
		get
		{
			if (!this.valid)
			{
				return null;
			}
			global::Controllable playerControllable = this.playerControllable;
			if (playerControllable)
			{
				return playerControllable.idMain;
			}
			return null;
		}
	}

	// Token: 0x04001040 RID: 4160
	public bool valid;

	// Token: 0x04001041 RID: 4161
	public ulong userID;
}
