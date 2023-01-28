using System;
using uLink;
using UnityEngine;

// Token: 0x02000556 RID: 1366
public class ChickenAI : global::BasicWildLifeAI
{
	// Token: 0x06002E94 RID: 11924 RVA: 0x000B16A8 File Offset: 0x000AF8A8
	public ChickenAI()
	{
	}

	// Token: 0x06002E95 RID: 11925 RVA: 0x000B16B0 File Offset: 0x000AF8B0
	protected new void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		int id = info.networkView.viewID.id;
		this.SetGender((id & 0xE) >> 1 <= 2, (id & 1) == 1);
		base.uLink_OnNetworkInstantiate(info);
	}

	// Token: 0x06002E96 RID: 11926 RVA: 0x000B16F0 File Offset: 0x000AF8F0
	protected void SetGender(bool male, bool alt)
	{
		this.isMale = male;
	}

	// Token: 0x0400182E RID: 6190
	protected bool isMale;

	// Token: 0x0400182F RID: 6191
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Material roosterMat;

	// Token: 0x04001830 RID: 6192
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Material ChickenMatA;

	// Token: 0x04001831 RID: 6193
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Material ChickenMatB;

	// Token: 0x04001832 RID: 6194
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Renderer chickenRenderer;
}
