using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
[global::System.Serializable]
public class ControllerClassesConfigurations
{
	// Token: 0x06000A34 RID: 2612 RVA: 0x00029D94 File Offset: 0x00027F94
	public ControllerClassesConfigurations()
	{
	}

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000A35 RID: 2613 RVA: 0x00029D9C File Offset: 0x00027F9C
	internal string unassignedClassName
	{
		get
		{
			string text = this.sv_unassigned;
			string text2 = this.cl_unassigned;
			return (!string.IsNullOrEmpty(text)) ? text : ((!string.IsNullOrEmpty(text2)) ? text2 : null);
		}
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x00029DDC File Offset: 0x00027FDC
	internal string GetClassName(bool player, bool local)
	{
		if (player)
		{
			if (local)
			{
				return (!string.IsNullOrEmpty(this.localPlayer)) ? this.localPlayer : null;
			}
			return (!string.IsNullOrEmpty(this.remotePlayer)) ? this.remotePlayer : null;
		}
		else
		{
			if (local)
			{
				return (!string.IsNullOrEmpty(this.localAI)) ? this.localAI : null;
			}
			return (!string.IsNullOrEmpty(this.remoteAI)) ? this.remoteAI : null;
		}
	}

	// Token: 0x0400076B RID: 1899
	[global::UnityEngine.SerializeField]
	public string localPlayer;

	// Token: 0x0400076C RID: 1900
	[global::UnityEngine.SerializeField]
	public string remotePlayer;

	// Token: 0x0400076D RID: 1901
	[global::UnityEngine.SerializeField]
	public string localAI;

	// Token: 0x0400076E RID: 1902
	[global::UnityEngine.SerializeField]
	public string remoteAI;

	// Token: 0x0400076F RID: 1903
	[global::UnityEngine.SerializeField]
	public string cl_unassigned;

	// Token: 0x04000770 RID: 1904
	[global::UnityEngine.SerializeField]
	public string sv_unassigned;
}
