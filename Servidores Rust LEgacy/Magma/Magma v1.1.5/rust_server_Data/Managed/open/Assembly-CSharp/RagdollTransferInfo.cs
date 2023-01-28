using System;
using System.Text;
using UnityEngine;

// Token: 0x020000AF RID: 175
public struct RagdollTransferInfo
{
	// Token: 0x06000375 RID: 885 RVA: 0x000108CC File Offset: 0x0000EACC
	public RagdollTransferInfo(string headBoneName)
	{
		this.headBoneName = headBoneName;
		this.headBone = null;
		this.providedHeadBone = false;
		this.providedHeadBoneName = (headBoneName != null);
	}

	// Token: 0x06000376 RID: 886 RVA: 0x000108FC File Offset: 0x0000EAFC
	public RagdollTransferInfo(global::UnityEngine.Transform transform)
	{
		this.providedHeadBone = transform;
		this.providedHeadBoneName = false;
		this.headBoneName = null;
		this.headBone = transform;
	}

	// Token: 0x06000377 RID: 887 RVA: 0x00010920 File Offset: 0x0000EB20
	private static void FindNameRecurse(global::UnityEngine.Transform child, global::System.Text.StringBuilder sb)
	{
		global::UnityEngine.Transform parent = child.parent;
		if (parent)
		{
			global::RagdollTransferInfo.FindNameRecurse(parent, sb);
			if (sb.Length > 0)
			{
				sb.Append('/');
			}
			else
			{
				sb.Append(child.name);
			}
		}
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00010970 File Offset: 0x0000EB70
	public bool FindHead(global::UnityEngine.Transform root, out global::UnityEngine.Transform headBone)
	{
		if (this.providedHeadBoneName)
		{
			global::UnityEngine.Transform transform;
			headBone = (transform = root.Find(this.headBoneName));
			return transform;
		}
		if (this.providedHeadBone && this.headBone)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			global::RagdollTransferInfo.FindNameRecurse(this.headBone, stringBuilder);
			global::UnityEngine.Transform transform;
			headBone = (transform = root.Find(stringBuilder.ToString()));
			return transform;
		}
		headBone = root;
		return false;
	}

	// Token: 0x06000379 RID: 889 RVA: 0x000109E8 File Offset: 0x0000EBE8
	public static implicit operator global::RagdollTransferInfo(string headBoneName)
	{
		return new global::RagdollTransferInfo(headBoneName);
	}

	// Token: 0x0600037A RID: 890 RVA: 0x000109F0 File Offset: 0x0000EBF0
	public static implicit operator global::RagdollTransferInfo(global::UnityEngine.Transform transform)
	{
		return new global::RagdollTransferInfo(transform);
	}

	// Token: 0x0400030C RID: 780
	public readonly string headBoneName;

	// Token: 0x0400030D RID: 781
	public readonly global::UnityEngine.Transform headBone;

	// Token: 0x0400030E RID: 782
	public readonly bool providedHeadBone;

	// Token: 0x0400030F RID: 783
	public readonly bool providedHeadBoneName;
}
