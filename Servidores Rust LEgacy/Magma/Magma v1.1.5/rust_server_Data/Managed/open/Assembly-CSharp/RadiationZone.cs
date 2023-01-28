using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000061 RID: 97
public class RadiationZone : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060002BD RID: 701 RVA: 0x0000DCEC File Offset: 0x0000BEEC
	public RadiationZone()
	{
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0000DD14 File Offset: 0x0000BF14
	private void Start()
	{
		this.UpdateCollider();
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0000DD1C File Offset: 0x0000BF1C
	public global::Character GetFromCollider(global::UnityEngine.Collider other)
	{
		global::IDBase idbase = global::IDBase.Get(other);
		if (!idbase)
		{
			return null;
		}
		return idbase.idMain as global::Character;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0000DD48 File Offset: 0x0000BF48
	private void OnTriggerEnter(global::UnityEngine.Collider other)
	{
		global::Character fromCollider = this.GetFromCollider(other);
		if (!fromCollider)
		{
			return;
		}
		global::Radiation local = fromCollider.GetLocal<global::Radiation>();
		if (local)
		{
			local.AddRadiationZone(this);
		}
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x0000DD84 File Offset: 0x0000BF84
	public float GetExposureForPos(global::UnityEngine.Vector3 pos)
	{
		if (this.strongerAtCenter)
		{
			return this.exposurePerMin * (1f - global::UnityEngine.Mathf.Clamp01(global::UnityEngine.Vector3.Distance(pos, base.transform.position) / this.radius));
		}
		return this.exposurePerMin;
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
	private void OnTriggerExit(global::UnityEngine.Collider other)
	{
		global::Character fromCollider = this.GetFromCollider(other);
		if (!fromCollider)
		{
			return;
		}
		global::Radiation local = fromCollider.GetLocal<global::Radiation>();
		if (!local)
		{
			return;
		}
		local.RemoveRadiationZone(this);
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0000DE0C File Offset: 0x0000C00C
	internal bool CanAddToRadiation(global::Radiation radiation)
	{
		bool result;
		if (!this.shuttingDown)
		{
			global::System.Collections.Generic.HashSet<global::Radiation> hashSet;
			if ((hashSet = this.radiating) == null)
			{
				hashSet = (this.radiating = new global::System.Collections.Generic.HashSet<global::Radiation>());
			}
			result = hashSet.Add(radiation);
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0000DE48 File Offset: 0x0000C048
	internal bool RemoveFromRadiation(global::Radiation radiation)
	{
		return this.shuttingDown || (this.radiating != null && this.radiating.Remove(radiation));
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0000DE80 File Offset: 0x0000C080
	[global::UnityEngine.ContextMenu("Update Collider")]
	public void UpdateCollider()
	{
		base.GetComponent<global::UnityEngine.SphereCollider>().radius = this.radius;
		base.collider.isTrigger = true;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0000DEAC File Offset: 0x0000C0AC
	private void OnDestroy()
	{
		this.shuttingDown = true;
		if (this.radiating != null)
		{
			foreach (global::Radiation radiation in this.radiating)
			{
				if (radiation)
				{
					radiation.RemoveRadiationZone(this);
				}
			}
			this.radiating = null;
		}
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x0000DF38 File Offset: 0x0000C138
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.3f, 0.5f, 0.3f, 0.25f);
		global::UnityEngine.Gizmos.DrawSphere(base.transform.position, this.radius);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0000DFA4 File Offset: 0x0000C1A4
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.3f, 0.5f, 0.3f, 0.4f);
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.radius);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x040001E0 RID: 480
	public float radius = 10f;

	// Token: 0x040001E1 RID: 481
	public float exposurePerMin = 50f;

	// Token: 0x040001E2 RID: 482
	public bool strongerAtCenter = true;

	// Token: 0x040001E3 RID: 483
	[global::System.NonSerialized]
	private global::System.Collections.Generic.HashSet<global::Radiation> radiating;

	// Token: 0x040001E4 RID: 484
	[global::System.NonSerialized]
	private bool shuttingDown;
}
