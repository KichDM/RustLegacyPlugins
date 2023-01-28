using System;
using Facepunch.Procedural;
using Magma;
using UnityEngine;

// Token: 0x02000557 RID: 1367
public class HostileWildlifeAI : global::BasicWildLifeAI
{
	// Token: 0x06002E97 RID: 11927 RVA: 0x000B16FC File Offset: 0x000AF8FC
	public HostileWildlifeAI()
	{
	}

	// Token: 0x06002E98 RID: 11928 RVA: 0x000B1728 File Offset: 0x000AF928
	public void GoScentBlind(float dur)
	{
		this.nextScentListenTime = global::UnityEngine.Time.time + dur;
	}

	// Token: 0x06002E99 RID: 11929 RVA: 0x000B1738 File Offset: 0x000AF938
	public bool IsScentBlind()
	{
		return global::UnityEngine.Time.time < this.nextScentListenTime;
	}

	// Token: 0x06002E9A RID: 11930 RVA: 0x000B1748 File Offset: 0x000AF948
	protected override bool SimAIState(ulong millis)
	{
		if (this.warnClock.IntegrateTime_Reached(millis))
		{
			this._myChar.AudibleMessage(10f, "HearDanger", base.transform.position);
			this.warnClock.ResetRandomDurationSeconds(4.0, 5.0);
		}
		bool flag = false;
		int state = this._state;
		if (state != 9)
		{
			if (state == 0xA)
			{
				this.StateSim_Attack(millis);
				flag = true;
			}
		}
		else
		{
			this.StateSim_Chase(millis);
			flag = true;
		}
		if (flag)
		{
			return flag;
		}
		return base.SimAIState(millis);
	}

	// Token: 0x06002E9B RID: 11931 RVA: 0x000B17F8 File Offset: 0x000AF9F8
	protected new void Awake()
	{
		base.Awake();
		this._myChar = base.GetComponent<global::Character>();
	}

	// Token: 0x06002E9C RID: 11932 RVA: 0x000B180C File Offset: 0x000AFA0C
	protected void EnterState_Chase()
	{
		this._state = 9;
		this.targetReachClock.ResetRandomDurationSeconds(50.0, 60.0);
	}

	// Token: 0x06002E9D RID: 11933 RVA: 0x000B1840 File Offset: 0x000AFA40
	protected internal override void HitSomething()
	{
		this.LoseTarget();
		global::Angle2 angle = global::Angle2.LookDirection(-this._myTransform.forward);
		angle.pitch = 0f;
		angle.yaw += global::UnityEngine.Random.Range(-30f, 30f);
		this._wildMove.SetMoveDirection(angle.forward, this.runSpeed);
		this.ExitCurrentState();
		base.EnterState_Roam();
	}

	// Token: 0x06002E9E RID: 11934 RVA: 0x000B18B8 File Offset: 0x000AFAB8
	protected void ExitState_Chase()
	{
	}

	// Token: 0x06002E9F RID: 11935 RVA: 0x000B18BC File Offset: 0x000AFABC
	protected void StateSim_Chase(ulong millis)
	{
		if (!this._targetTD)
		{
			this.LoseTarget();
			return;
		}
		float num = this.TargetRange();
		if (num > this.loseTargetRange)
		{
			this.LoseTarget();
			return;
		}
		global::UnityEngine.Vector3 vector = this._targetTD.transform.position - base.transform.position;
		vector.y = 0f;
		if (num <= this.attackRange)
		{
			this._wildMove.SetLookDirection(vector.normalized);
			this.ExitCurrentState();
			this.EnterState_Attack();
			return;
		}
		if (this._wildMove.IsStuck())
		{
			if (!this.wasStuck)
			{
				this.wasStuck = true;
				this.stuckClock.ResetRandomDurationSeconds(1.0, 2.0);
			}
			else if (this.stuckClock.IntegrateTime_Reached(millis))
			{
				global::UnityEngine.Vector3 position = this._targetTD.transform.position;
				this.LoseTarget();
				this.ExitCurrentState();
				base.EnterState_Flee(position, 0x2710UL);
				return;
			}
		}
		else
		{
			this.wasStuck = false;
		}
		if (this.chaseSoundClock.IntegrateTime_Reached(millis))
		{
			global::BasicWildLifeAI.AISound toPlay = global::BasicWildLifeAI.AISound.Chase;
			if (num < 5f)
			{
				toPlay = global::BasicWildLifeAI.AISound.ChaseClose;
			}
			base.NetworkSound(toPlay);
			this.chaseSoundClock.ResetRandomDurationSeconds(1.5, 2.5);
		}
		this._wildMove.SetMoveTarget(this._targetTD.gameObject, this.runSpeed);
		if (this.targetReachClock.IntegrateTime_Reached(millis))
		{
			this.LoseTarget();
			this.ExitCurrentState();
			base.EnterState_Idle();
		}
	}

	// Token: 0x06002EA0 RID: 11936 RVA: 0x000B1A68 File Offset: 0x000AFC68
	protected override void OnHurt(global::DamageEvent damage)
	{
		global::Magma.Hooks.NPCHurt(ref damage);
		if (this.HasTarget())
		{
			return;
		}
		if (damage.attacker.character != null)
		{
			this.SetAttackTarget(damage.attacker.character.gameObject.GetComponent<global::TakeDamage>());
			this.ExitCurrentState();
			this.EnterState_Chase();
		}
	}

	// Token: 0x06002EA1 RID: 11937 RVA: 0x000B1AC8 File Offset: 0x000AFCC8
	protected new void OnKilled(global::DamageEvent damage)
	{
		global::Magma.Hooks.NPCKilled(ref damage);
		if (!string.IsNullOrEmpty(this.dropOnDeathString))
		{
			float num = global::UnityEngine.Random.value * 3.1415927f * 2f;
			global::UnityEngine.Vector3 vector;
			vector.x = global::UnityEngine.Mathf.Cos(num);
			vector.z = global::UnityEngine.Mathf.Sin(num);
			vector.y = 0f;
			global::UnityEngine.Vector3 position;
			global::UnityEngine.Vector3 up;
			global::TransformHelpers.GetGroundInfo(base.transform.position + vector * 1.5f, out position, out up);
			global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateStatic(this.dropOnDeathString, position, global::TransformHelpers.LookRotationForcedUp(base.transform.rotation, up));
			if (gameObject.GetComponent<global::Inventory>().noOccupiedSlots)
			{
				global::NetCull.Destroy(gameObject);
			}
		}
		base.OnKilled(damage);
	}

	// Token: 0x06002EA2 RID: 11938 RVA: 0x000B1B88 File Offset: 0x000AFD88
	protected void EnterState_Attack()
	{
		this._state = 0xA;
	}

	// Token: 0x06002EA3 RID: 11939 RVA: 0x000B1B94 File Offset: 0x000AFD94
	protected void ExitState_Attack()
	{
	}

	// Token: 0x06002EA4 RID: 11940 RVA: 0x000B1B98 File Offset: 0x000AFD98
	public float TargetRange()
	{
		return global::UnityEngine.Vector3.Distance(base.transform.position, this._targetTD.transform.position);
	}

	// Token: 0x06002EA5 RID: 11941 RVA: 0x000B1BC8 File Offset: 0x000AFDC8
	protected void StateSim_Attack(ulong millis)
	{
		if (!this.HasTarget())
		{
			this.LoseTarget();
			return;
		}
		float num = this.TargetRange();
		global::UnityEngine.Vector3 vector = this._targetTD.transform.position - base.transform.position;
		vector.y = 0f;
		this._wildMove.SetLookDirection(vector.normalized);
		if (this.nextAttackClock.IntegrateTime_Reached(millis))
		{
			this.nextAttackClock.ResetDurationSeconds((double)this.attackRate);
			this.attackStrikeClock.ResetDurationSeconds(0.25);
			base.NetworkSound(global::BasicWildLifeAI.AISound.Attack);
			base.networkView.RPC("CL_Attack", 9, new object[0]);
		}
		if (this.attackStrikeClock.IntegrateTime_Reached(millis))
		{
			global::DamageEvent damageEvent;
			global::TakeDamage.Hurt(base.GetComponent<global::IDMain>(), this._targetTD.idMain, new global::DamageTypeList(0f, 0f, global::UnityEngine.Random.Range(this.attackDamageMin, this.attackDamageMax), 0f, 0f, 0f), out damageEvent, null);
			this.attackStrikeClock.ResetDurationSeconds((double)(this.attackRate * 2f));
		}
		if (num > this.attackRangeMax)
		{
			this.ExitCurrentState();
			this.EnterState_Chase();
			return;
		}
	}

	// Token: 0x06002EA6 RID: 11942 RVA: 0x000B1D18 File Offset: 0x000AFF18
	public bool HasTarget()
	{
		return this._targetTD && this._targetTD.alive;
	}

	// Token: 0x06002EA7 RID: 11943 RVA: 0x000B1D38 File Offset: 0x000AFF38
	public virtual void SetAttackTarget(global::TakeDamage damage)
	{
		this._targetTD = damage;
	}

	// Token: 0x06002EA8 RID: 11944 RVA: 0x000B1D44 File Offset: 0x000AFF44
	public virtual void LoseTarget()
	{
		this.GoScentBlind(10f);
		this._targetTD = null;
		this.ExitCurrentState();
		base.EnterState_Idle();
	}

	// Token: 0x06002EA9 RID: 11945 RVA: 0x000B1D68 File Offset: 0x000AFF68
	protected void Scent(global::TakeDamage damage)
	{
		if (this.IsScentBlind())
		{
			return;
		}
		if (this._state == 2 || this._state == 7 || this.HasTarget())
		{
			return;
		}
		this.ExitCurrentState();
		this.SetAttackTarget(damage);
		this.EnterState_Chase();
	}

	// Token: 0x06002EAA RID: 11946 RVA: 0x000B1DBC File Offset: 0x000AFFBC
	protected new virtual bool ExitCurrentState()
	{
		int state = this._state;
		bool flag;
		if (state != 9)
		{
			if (state != 0xA)
			{
				flag = false;
			}
			else
			{
				this.ExitState_Attack();
				flag = true;
			}
		}
		else
		{
			this.ExitState_Chase();
			flag = true;
		}
		if (flag)
		{
			this._lastState = this._state;
			return flag;
		}
		return base.ExitCurrentState();
	}

	// Token: 0x06002EAB RID: 11947 RVA: 0x000B1E24 File Offset: 0x000B0024
	public override void HearFootstep(global::UnityEngine.Vector3 origin)
	{
	}

	// Token: 0x04001833 RID: 6195
	protected const int kHostileWildlifeState_Default = 8;

	// Token: 0x04001834 RID: 6196
	protected const int kHostileWildlifeState_Chase = 9;

	// Token: 0x04001835 RID: 6197
	protected const int kHostileWildlifeState_Attack = 0xA;

	// Token: 0x04001836 RID: 6198
	protected const int kHostileWildlifeState_LAST = 0xA;

	// Token: 0x04001837 RID: 6199
	protected global::TakeDamage _targetTD;

	// Token: 0x04001838 RID: 6200
	public float loseTargetRange = 100f;

	// Token: 0x04001839 RID: 6201
	public float attackRange = 1f;

	// Token: 0x0400183A RID: 6202
	public float attackRangeMax = 3f;

	// Token: 0x0400183B RID: 6203
	public float attackRate;

	// Token: 0x0400183C RID: 6204
	public float attackDamageMin;

	// Token: 0x0400183D RID: 6205
	public float attackDamageMax;

	// Token: 0x0400183E RID: 6206
	public string lastMoveAnim;

	// Token: 0x0400183F RID: 6207
	[global::UnityEngine.SerializeField]
	protected global::AudioClipArray attackSounds;

	// Token: 0x04001840 RID: 6208
	[global::UnityEngine.SerializeField]
	protected global::AudioClipArray chaseSoundsClose;

	// Token: 0x04001841 RID: 6209
	[global::UnityEngine.SerializeField]
	protected global::AudioClipArray chaseSoundsFar;

	// Token: 0x04001842 RID: 6210
	protected global::Facepunch.Procedural.MillisClock nextTargetClock;

	// Token: 0x04001843 RID: 6211
	protected global::Facepunch.Procedural.MillisClock nextAttackClock;

	// Token: 0x04001844 RID: 6212
	protected global::Facepunch.Procedural.MillisClock attackStrikeClock;

	// Token: 0x04001845 RID: 6213
	protected global::Facepunch.Procedural.MillisClock chaseSoundClock;

	// Token: 0x04001846 RID: 6214
	protected global::Facepunch.Procedural.MillisClock targetReachClock;

	// Token: 0x04001847 RID: 6215
	protected global::Facepunch.Procedural.MillisClock stuckClock;

	// Token: 0x04001848 RID: 6216
	protected global::Facepunch.Procedural.MillisClock warnClock;

	// Token: 0x04001849 RID: 6217
	protected bool wasStuck;

	// Token: 0x0400184A RID: 6218
	public float nextScentListenTime;

	// Token: 0x0400184B RID: 6219
	public string dropOnDeathString;

	// Token: 0x0400184C RID: 6220
	public global::Character _myChar;
}
