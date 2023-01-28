using System;
using UnityEngine;

// Token: 0x02000550 RID: 1360
public class BaseAIMovement : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002E57 RID: 11863 RVA: 0x000B076C File Offset: 0x000AE96C
	public BaseAIMovement()
	{
	}

	// Token: 0x06002E58 RID: 11864 RVA: 0x000B0798 File Offset: 0x000AE998
	public virtual bool IsStuck()
	{
		return false;
	}

	// Token: 0x06002E59 RID: 11865 RVA: 0x000B079C File Offset: 0x000AE99C
	public virtual void SetMoveDirection(global::UnityEngine.Vector3 worldDir, float speed)
	{
	}

	// Token: 0x06002E5A RID: 11866 RVA: 0x000B07A0 File Offset: 0x000AE9A0
	public virtual void SetLookDirection(global::UnityEngine.Vector3 worldDir)
	{
	}

	// Token: 0x06002E5B RID: 11867 RVA: 0x000B07A4 File Offset: 0x000AE9A4
	public virtual void SetMovePosition(global::UnityEngine.Vector3 worldPos, float speed)
	{
	}

	// Token: 0x06002E5C RID: 11868 RVA: 0x000B07A8 File Offset: 0x000AE9A8
	public virtual void SetMoveTarget(global::UnityEngine.GameObject target, float speed)
	{
	}

	// Token: 0x06002E5D RID: 11869 RVA: 0x000B07AC File Offset: 0x000AE9AC
	public virtual void Stop()
	{
	}

	// Token: 0x06002E5E RID: 11870 RVA: 0x000B07B0 File Offset: 0x000AE9B0
	public virtual void ProcessNetworkUpdate(ref global::UnityEngine.Vector3 origin, ref global::UnityEngine.Quaternion rotation)
	{
		origin = origin;
		rotation = rotation;
	}

	// Token: 0x06002E5F RID: 11871 RVA: 0x000B07CC File Offset: 0x000AE9CC
	public virtual void DoMove(global::BasicWildLifeAI ai, ulong simMillis)
	{
	}

	// Token: 0x06002E60 RID: 11872 RVA: 0x000B07D0 File Offset: 0x000AE9D0
	public virtual void InitializeMovement(global::BasicWildLifeAI ai)
	{
	}

	// Token: 0x06002E61 RID: 11873 RVA: 0x000B07D4 File Offset: 0x000AE9D4
	public virtual float GetActualMovementSpeed()
	{
		return 0f;
	}

	// Token: 0x040017EF RID: 6127
	protected float desiredSpeed;

	// Token: 0x040017F0 RID: 6128
	protected float collisionRadius = 0.3f;

	// Token: 0x040017F1 RID: 6129
	public float lookDegreeSpeed = 80f;

	// Token: 0x040017F2 RID: 6130
	public float maxSlope = 45f;
}
