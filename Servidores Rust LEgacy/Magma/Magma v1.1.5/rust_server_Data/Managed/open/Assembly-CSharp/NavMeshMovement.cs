using System;
using UnityEngine;

// Token: 0x02000558 RID: 1368
public class NavMeshMovement : global::BaseAIMovement
{
	// Token: 0x06002EAC RID: 11948 RVA: 0x000B1E28 File Offset: 0x000B0028
	public NavMeshMovement()
	{
	}

	// Token: 0x06002EAD RID: 11949 RVA: 0x000B1E3C File Offset: 0x000B003C
	public void Awake()
	{
		base.GetComponent<global::Character>().GetTrait<global::CharacterNavAgentTrait>().CopyTo(this._agent = base.gameObject.AddComponent<global::UnityEngine.NavMeshAgent>());
		this.movementTransform = base.transform;
	}

	// Token: 0x06002EAE RID: 11950 RVA: 0x000B1E7C File Offset: 0x000B007C
	public override void SetMoveDirection(global::UnityEngine.Vector3 worldDir, float speed)
	{
		this.SetAgentAiming(true);
		this._agent.SetDestination(this.movementTransform.position + worldDir * 30f);
		this._agent.speed = speed;
	}

	// Token: 0x06002EAF RID: 11951 RVA: 0x000B1EC4 File Offset: 0x000B00C4
	public override void Stop()
	{
		if (!this._agent.enabled)
		{
			global::TakeDamage.KillSelf(base.GetComponent<global::IDBase>(), null);
			return;
		}
		this._agent.Stop();
		this.SetAgentAiming(false);
		this.desiredSpeed = 0f;
	}

	// Token: 0x06002EB0 RID: 11952 RVA: 0x000B1F0C File Offset: 0x000B010C
	public override bool IsStuck()
	{
		global::UnityEngine.Vector3 vector = base.transform.InverseTransformDirection(this._agent.velocity);
		return this._agent.hasPath && this._agent.speed > 0.5f && vector.z < this._agent.speed * 0.25f;
	}

	// Token: 0x06002EB1 RID: 11953 RVA: 0x000B1F74 File Offset: 0x000B0174
	public override void SetLookDirection(global::UnityEngine.Vector3 worldDir)
	{
		this._agent.SetDestination(base.transform.position);
		this._agent.Stop();
		this.SetAgentAiming(false);
		if (worldDir == global::UnityEngine.Vector3.zero)
		{
			return;
		}
		this.movementTransform.rotation = global::UnityEngine.Quaternion.LookRotation(worldDir);
	}

	// Token: 0x06002EB2 RID: 11954 RVA: 0x000B1FCC File Offset: 0x000B01CC
	public override void SetMovePosition(global::UnityEngine.Vector3 worldPos, float speed)
	{
		this.SetAgentAiming(true);
		this._agent.SetDestination(worldPos);
		this._agent.speed = speed;
	}

	// Token: 0x06002EB3 RID: 11955 RVA: 0x000B1FFC File Offset: 0x000B01FC
	public override void SetMoveTarget(global::UnityEngine.GameObject target, float speed)
	{
		this.SetAgentAiming(true);
		global::UnityEngine.Vector3 vector = target.transform.position - base.transform.position;
		this._agent.SetDestination(target.transform.position + vector.normalized * 0.5f);
		this._agent.speed = speed;
	}

	// Token: 0x06002EB4 RID: 11956 RVA: 0x000B2068 File Offset: 0x000B0268
	public override void ProcessNetworkUpdate(ref global::UnityEngine.Vector3 origin, ref global::UnityEngine.Quaternion rotation)
	{
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		global::TransformHelpers.GetGroundInfo(origin + new global::UnityEngine.Vector3(0f, 0.25f, 0f), 10f, out vector, out vector2);
		global::UnityEngine.Vector3 vector3 = rotation * global::UnityEngine.Vector3.up;
		float num = global::UnityEngine.Vector3.Angle(vector3, vector2);
		if (num > 20f)
		{
			vector2 = global::UnityEngine.Vector3.Slerp(vector3, vector2, 20f / num);
		}
		origin = vector;
		rotation = global::TransformHelpers.LookRotationForcedUp(rotation, vector2);
	}

	// Token: 0x06002EB5 RID: 11957 RVA: 0x000B20F0 File Offset: 0x000B02F0
	protected void OnKilled(global::DamageEvent damage)
	{
		this._agent.Stop(true);
		this._agent.enabled = false;
	}

	// Token: 0x06002EB6 RID: 11958 RVA: 0x000B210C File Offset: 0x000B030C
	public virtual void SetAgentAiming(bool enabled)
	{
		this._agent.updateRotation = enabled;
	}

	// Token: 0x0400184D RID: 6221
	public global::UnityEngine.NavMeshAgent _agent;

	// Token: 0x0400184E RID: 6222
	public global::UnityEngine.Transform movementTransform;

	// Token: 0x0400184F RID: 6223
	public float targetLookRotation;

	// Token: 0x04001850 RID: 6224
	private global::UnityEngine.Vector3 lastStuckPos = global::UnityEngine.Vector3.zero;
}
