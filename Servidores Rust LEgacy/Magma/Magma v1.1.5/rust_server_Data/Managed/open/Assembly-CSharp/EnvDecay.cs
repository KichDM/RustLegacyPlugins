using System;
using Facepunch.Collections;
using Facepunch.MeshBatch;
using Magma;
using Rust;
using UnityEngine;

// Token: 0x020005B0 RID: 1456
public class EnvDecay : global::IDLocal
{
	// Token: 0x06002FF0 RID: 12272 RVA: 0x000B6984 File Offset: 0x000B4B84
	public EnvDecay()
	{
	}

	// Token: 0x06002FF1 RID: 12273 RVA: 0x000B6998 File Offset: 0x000B4B98
	public void Awake()
	{
		this.StartDecay();
		this.lastDecayThink += global::UnityEngine.Random.Range(global::decay.decaytickrate * 0.2f, global::decay.decaytickrate * 2f);
		this._takeDamage = base.GetComponent<global::TakeDamage>();
		this._deployable = base.GetComponent<global::DeployableObject>();
		global::EnvDecay.Callbacks.EnsureInstalled();
	}

	// Token: 0x06002FF2 RID: 12274 RVA: 0x000B69F0 File Offset: 0x000B4BF0
	protected void StartDecay()
	{
		global::EnvDecay.Schedule.StartThinking(this);
	}

	// Token: 0x06002FF3 RID: 12275 RVA: 0x000B69FC File Offset: 0x000B4BFC
	protected void StopDecay()
	{
		global::EnvDecay.Schedule.StopThinking(this);
	}

	// Token: 0x06002FF4 RID: 12276 RVA: 0x000B6A08 File Offset: 0x000B4C08
	public void DecayTouch()
	{
		global::EnvDecay.Schedule.RestartThinking(this, true);
	}

	// Token: 0x06002FF5 RID: 12277 RVA: 0x000B6A14 File Offset: 0x000B4C14
	private void OnDestroy()
	{
		this.StopDecay();
	}

	// Token: 0x06002FF6 RID: 12278 RVA: 0x000B6A1C File Offset: 0x000B4C1C
	protected global::EnvDecay.ThinkResult DecayThink()
	{
		if (!this._takeDamage)
		{
			return global::EnvDecay.ThinkResult.Done;
		}
		if (this._deployable && this._deployable.GetCarrier())
		{
			return global::EnvDecay.ThinkResult.AgainLater;
		}
		float num = global::UnityEngine.Time.time - this.lastDecayThink;
		if (num < global::decay.decaytickrate)
		{
			return global::EnvDecay.ThinkResult.TooEarly;
		}
		if (this.CanApplyDecayDamage())
		{
			float num2 = global::UnityEngine.Mathf.Clamp(global::UnityEngine.Time.time - this.lastDecayThink, 0f, global::decay.decaytickrate);
			float num3 = num2 / global::decay.deploy_maxhealth_sec * this._takeDamage.maxHealth * this.decayMultiplier;
			num3 = global::Magma.Hooks.EntityDecay(this._deployable, num3);
			if (global::TakeDamage.HurtSelf(this, num3, null) == global::LifeStatus.WasKilled)
			{
				return global::EnvDecay.ThinkResult.Done;
			}
		}
		return global::EnvDecay.ThinkResult.AgainLater;
	}

	// Token: 0x06002FF7 RID: 12279 RVA: 0x000B6AE4 File Offset: 0x000B4CE4
	private bool CanApplyDecayDamage()
	{
		global::UnityEngine.Ray ray;
		ray..ctor(base.transform.position + new global::UnityEngine.Vector3(0f, 0.25f, 0f), global::UnityEngine.Vector3.up);
		global::UnityEngine.RaycastHit raycastHit;
		bool flag;
		global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
		if (global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray, ref raycastHit, 10f, ref flag, ref meshBatchInstance))
		{
			global::IDMain idmain = (!flag) ? global::IDBase.GetMain(raycastHit.collider) : meshBatchInstance.idMain;
			if (idmain && idmain != this.idMain)
			{
				global::DeployableObject component = idmain.GetComponent<global::DeployableObject>();
				if (idmain.GetComponent<global::StructureComponent>() || (component && component.decayProtector))
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06002FF8 RID: 12280 RVA: 0x000B6BB4 File Offset: 0x000B4DB4
	public static void RefreshRadialDecay(global::UnityEngine.Vector3 pos, float radius)
	{
		global::UnityEngine.Collider[] array = global::Facepunch.MeshBatch.MeshBatchPhysics.OverlapSphere(pos, radius, -1);
		foreach (global::UnityEngine.Collider collider in array)
		{
			global::IDBase idbase = global::IDBase.Get(collider);
			if (idbase)
			{
				global::EnvDecay component = idbase.idMain.GetComponent<global::EnvDecay>();
				if (component)
				{
					component.DecayTouch();
				}
			}
		}
	}

	// Token: 0x06002FF9 RID: 12281 RVA: 0x000B6C20 File Offset: 0x000B4E20
	public void SetDecayEnabled(bool on)
	{
		if (on)
		{
			this.StartDecay();
		}
		else
		{
			this.StopDecay();
		}
	}

	// Token: 0x040019B7 RID: 6583
	public float decayMultiplier = 1f;

	// Token: 0x040019B8 RID: 6584
	public bool ambientDecay;

	// Token: 0x040019B9 RID: 6585
	protected float lastDecayThink;

	// Token: 0x040019BA RID: 6586
	protected global::TakeDamage _takeDamage;

	// Token: 0x040019BB RID: 6587
	protected global::DeployableObject _deployable;

	// Token: 0x040019BC RID: 6588
	[global::System.NonSerialized]
	private global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.Entry regkey;

	// Token: 0x020005B1 RID: 1457
	private static class Callbacks
	{
		// Token: 0x06002FFA RID: 12282 RVA: 0x000B6C3C File Offset: 0x000B4E3C
		static Callbacks()
		{
			global::NetCull.Callbacks.beforeEveryUpdate += global::EnvDecay.Callbacks.RunDecayThink;
		}

		// Token: 0x06002FFB RID: 12283 RVA: 0x000B6C50 File Offset: 0x000B4E50
		private static void RunDecayThink()
		{
			try
			{
				global::EnvDecay.Schedule.Think(global::decay.maxperframe);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
		}

		// Token: 0x06002FFC RID: 12284 RVA: 0x000B6C94 File Offset: 0x000B4E94
		public static void EnsureInstalled()
		{
		}
	}

	// Token: 0x020005B2 RID: 1458
	private sealed class Schedule : global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>
	{
		// Token: 0x06002FFD RID: 12285 RVA: 0x000B6C98 File Offset: 0x000B4E98
		public Schedule()
		{
		}

		// Token: 0x06002FFE RID: 12286 RVA: 0x000B6CA0 File Offset: 0x000B4EA0
		public static bool StartThinking(global::EnvDecay decay)
		{
			if (!global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.enqueue(decay, ref decay.regkey))
			{
				return false;
			}
			global::EnvDecay.Schedule.OnDecayStart(decay, false);
			return true;
		}

		// Token: 0x06002FFF RID: 12287 RVA: 0x000B6CC0 File Offset: 0x000B4EC0
		public static bool StopThinking(global::EnvDecay decay)
		{
			return global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.dequeue(decay, ref decay.regkey);
		}

		// Token: 0x06003000 RID: 12288 RVA: 0x000B6CD0 File Offset: 0x000B4ED0
		public static bool RestartThinking(global::EnvDecay decay, bool startDecayIfNotAlreadyDecaying = false)
		{
			if (!global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.requeue(decay, ref decay.regkey, startDecayIfNotAlreadyDecaying))
			{
				return false;
			}
			global::EnvDecay.Schedule.OnDecayStart(decay, false);
			return true;
		}

		// Token: 0x06003001 RID: 12289 RVA: 0x000B6CF0 File Offset: 0x000B4EF0
		public static void Think(int maxCount = 1)
		{
			if (global::Rust.Globals.isLoading)
			{
				return;
			}
			try
			{
				global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.iterator iterator = new global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.iterator(maxCount);
				int num = 0;
				global::EnvDecay envDecay;
				bool flag = iterator.Start(out envDecay);
				while (flag)
				{
					flag = ((!envDecay || !iterator.Validate(ref envDecay.regkey)) ? iterator.MissingNext(out envDecay) : global::EnvDecay.Schedule.ThinkInstance(ref iterator, ref envDecay, ref envDecay.regkey, ref num));
				}
			}
			finally
			{
			}
		}

		// Token: 0x06003002 RID: 12290 RVA: 0x000B6D8C File Offset: 0x000B4F8C
		private static void OnDecayStart(global::EnvDecay decay, bool fromSchedule = false)
		{
			decay.lastDecayThink = global::UnityEngine.Time.time;
		}

		// Token: 0x06003003 RID: 12291 RVA: 0x000B6D9C File Offset: 0x000B4F9C
		private static bool ThinkInstance(ref global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.iterator iter, ref global::EnvDecay decay, ref global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.Entry key, ref int numLater)
		{
			global::EnvDecay.ThinkResult thinkResult;
			try
			{
				thinkResult = decay.DecayThink();
			}
			catch (global::System.Exception ex)
			{
				thinkResult = global::EnvDecay.ThinkResult.Done;
				global::UnityEngine.Debug.LogException(ex, decay);
			}
			global::EnvDecay.ThinkResult thinkResult2 = thinkResult;
			global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.act cmd;
			if (thinkResult2 != global::EnvDecay.ThinkResult.TooEarly)
			{
				if (thinkResult2 != global::EnvDecay.ThinkResult.AgainLater)
				{
					cmd = global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.act.delist;
				}
				else
				{
					global::EnvDecay.Schedule.OnDecayStart(decay, true);
					cmd = global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.act.back;
					numLater++;
				}
			}
			else
			{
				cmd = global::Facepunch.Collections.StaticQueue<global::EnvDecay.Schedule, global::EnvDecay>.act.none;
			}
			return iter.Next(ref key, cmd, out decay) && numLater < global::decay.maxtestperframe;
		}
	}

	// Token: 0x020005B3 RID: 1459
	protected enum ThinkResult
	{
		// Token: 0x040019BE RID: 6590
		TooEarly,
		// Token: 0x040019BF RID: 6591
		AgainLater,
		// Token: 0x040019C0 RID: 6592
		Done
	}
}
