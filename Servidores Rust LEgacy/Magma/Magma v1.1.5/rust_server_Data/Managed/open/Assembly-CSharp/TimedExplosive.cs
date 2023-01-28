using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200079E RID: 1950
public class TimedExplosive : global::IDLocal
{
	// Token: 0x060040D8 RID: 16600 RVA: 0x000E8E1C File Offset: 0x000E701C
	public TimedExplosive()
	{
	}

	// Token: 0x060040D9 RID: 16601 RVA: 0x000E8E48 File Offset: 0x000E7048
	private void Awake()
	{
		this.testView = base.GetComponent<global::NGCView>();
		base.Invoke("Explode", this.fuseLength);
	}

	// Token: 0x060040DA RID: 16602 RVA: 0x000E8E68 File Offset: 0x000E7068
	public void Explode()
	{
		base.collider.enabled = false;
		this.testView.RPC("ClientExplode", 1);
		global::IDMain idmain = null;
		bool flag = false;
		global::DeployableObject component = base.GetComponent<global::DeployableObject>();
		global::TransCarrier transCarrier;
		if (component)
		{
			if (transCarrier = component.GetCarrier())
			{
				flag = (idmain = global::IDBase.GetMain(transCarrier));
			}
		}
		else
		{
			transCarrier = null;
		}
		global::UnityEngine.Vector3 vector = base.collider.bounds.center;
		if (vector == global::UnityEngine.Vector3.zero)
		{
			vector = base.transform.TransformPoint(new global::UnityEngine.Vector3(0f, 0f, 0.1f));
		}
		global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::IDBase, float>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::IDBase, float>>();
		foreach (global::ExplosionHelper.Surface surface in global::ExplosionHelper.OverlapExplosionUnique(vector, this.explosionRadius, 0x10360401, -1, null))
		{
			if (!flag || !(surface.idMain == idmain))
			{
				float num = (1f - global::UnityEngine.Mathf.Clamp01(surface.work.distanceToCenter / this.explosionRadius)) * this.damage;
				if (surface.blocked)
				{
					num *= 0.1f;
				}
				list.Add(new global::System.Collections.Generic.KeyValuePair<global::IDBase, float>(surface.idBase, num));
			}
		}
		if (flag && idmain)
		{
			list.Add(new global::System.Collections.Generic.KeyValuePair<global::IDBase, float>(transCarrier, this.damage));
		}
		foreach (global::System.Collections.Generic.KeyValuePair<global::IDBase, float> keyValuePair in list)
		{
			global::TakeDamage.Hurt(this, keyValuePair.Key, new global::DamageTypeList(0f, 0f, 0f, keyValuePair.Value, 0f, 0f), null);
		}
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x060040DB RID: 16603 RVA: 0x000E9088 File Offset: 0x000E7288
	[global::UnityEngine.RPC]
	public void ClientExplode()
	{
		global::UnityEngine.Object.Instantiate(this.explosionEffect, base.transform.position, base.transform.rotation);
		base.CancelInvoke();
	}

	// Token: 0x060040DC RID: 16604 RVA: 0x000E90C0 File Offset: 0x000E72C0
	public void TickSound()
	{
		this.tickSound.Play(base.transform.position, 1f, 3f, 20f);
	}

	// Token: 0x060040DD RID: 16605 RVA: 0x000E90F4 File Offset: 0x000E72F4
	public void OnDestroy()
	{
	}

	// Token: 0x040021D6 RID: 8662
	public float fuseLength = 5f;

	// Token: 0x040021D7 RID: 8663
	public float explosionRadius = 4f;

	// Token: 0x040021D8 RID: 8664
	public float damage = 100f;

	// Token: 0x040021D9 RID: 8665
	public global::UnityEngine.GameObject explosionEffect;

	// Token: 0x040021DA RID: 8666
	public global::UnityEngine.AudioClip tickSound;

	// Token: 0x040021DB RID: 8667
	private global::NGCView testView;
}
