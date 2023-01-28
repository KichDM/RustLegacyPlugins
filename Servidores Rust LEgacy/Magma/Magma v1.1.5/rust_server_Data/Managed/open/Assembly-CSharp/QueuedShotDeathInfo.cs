using System;
using uLink;
using UnityEngine;

// Token: 0x02000201 RID: 513
public struct QueuedShotDeathInfo
{
	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06000E34 RID: 3636 RVA: 0x0003660C File Offset: 0x0003480C
	public bool exists
	{
		get
		{
			return this.queued && this.transform;
		}
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x00036628 File Offset: 0x00034828
	public void Set(global::Character character, ref global::UnityEngine.Vector3 localPoint, ref global::Angle2 localNormal, byte bodyPart, ref global::uLink.NetworkMessageInfo info)
	{
		this.Set(character.hitBoxSystem, ref localPoint, ref localNormal, bodyPart, ref info);
	}

	// Token: 0x06000E36 RID: 3638 RVA: 0x00036648 File Offset: 0x00034848
	public void Set(global::IDMain idMain, ref global::UnityEngine.Vector3 localPoint, ref global::Angle2 localNormal, byte bodyPart, ref global::uLink.NetworkMessageInfo info)
	{
		if (idMain is global::Character)
		{
			this.Set((global::Character)idMain, ref localPoint, ref localNormal, bodyPart, ref info);
		}
		else
		{
			this.Set(idMain.GetRemote<global::HitBoxSystem>(), ref localPoint, ref localNormal, bodyPart, ref info);
		}
	}

	// Token: 0x06000E37 RID: 3639 RVA: 0x0003668C File Offset: 0x0003488C
	public void LinkRagdoll(global::UnityEngine.Transform thisRoot, global::UnityEngine.GameObject ragdoll)
	{
		if (this.exists)
		{
			global::UnityEngine.Transform transform;
			if (global::RagdollHelper.RecursiveLinkTransformsByName(ragdoll.transform, thisRoot, this.transform, out transform))
			{
				global::UnityEngine.Transform transform2 = transform;
				global::UnityEngine.Rigidbody rigidbody = transform2.rigidbody;
				if (rigidbody)
				{
					global::UnityEngine.Vector3 vector = transform2.TransformPoint(this.localPoint);
					global::UnityEngine.Vector3 vector2 = transform2.TransformDirection(this.localNormal);
					rigidbody.AddForceAtPosition(vector2 * 1000f, vector);
				}
			}
		}
		else
		{
			global::RagdollHelper.RecursiveLinkTransformsByName(ragdoll.transform, thisRoot);
		}
	}

	// Token: 0x06000E38 RID: 3640 RVA: 0x00036710 File Offset: 0x00034910
	public void Set(global::HitBoxSystem hitBoxSystem, ref global::UnityEngine.Vector3 localPoint, ref global::Angle2 localNormal, byte bodyPart, ref global::uLink.NetworkMessageInfo info)
	{
		this.queued = true;
		this.localPoint = localPoint;
		this.localNormal = localNormal.forward;
		this.bodyPart = bodyPart;
		if (this.bodyPart != null)
		{
			global::IDRemoteBodyPart idremoteBodyPart;
			if (hitBoxSystem.bodyParts.TryGetValue(this.bodyPart, ref idremoteBodyPart))
			{
				this.transform = idremoteBodyPart.transform;
			}
			else
			{
				this.transform = null;
			}
		}
		else
		{
			this.transform = null;
		}
	}

	// Token: 0x040008C5 RID: 2245
	public bool queued;

	// Token: 0x040008C6 RID: 2246
	public global::UnityEngine.Vector3 localPoint;

	// Token: 0x040008C7 RID: 2247
	public global::UnityEngine.Vector3 localNormal;

	// Token: 0x040008C8 RID: 2248
	public global::BodyPart bodyPart;

	// Token: 0x040008C9 RID: 2249
	public global::UnityEngine.Transform transform;
}
