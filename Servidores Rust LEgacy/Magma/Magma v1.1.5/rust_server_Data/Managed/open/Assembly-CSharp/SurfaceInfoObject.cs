using System;
using Facepunch;
using UnityEngine;

// Token: 0x020005D0 RID: 1488
public class SurfaceInfoObject : global::UnityEngine.ScriptableObject
{
	// Token: 0x0600309D RID: 12445 RVA: 0x000B8F28 File Offset: 0x000B7128
	public SurfaceInfoObject()
	{
	}

	// Token: 0x0600309E RID: 12446 RVA: 0x000B8F30 File Offset: 0x000B7130
	public global::UnityEngine.GameObject GetImpactEffect(global::SurfaceInfoObject.ImpactType type)
	{
		if (type == global::SurfaceInfoObject.ImpactType.Bullet)
		{
			return this.bulletEffects[global::UnityEngine.Random.Range(0, this.bulletEffects.Length)];
		}
		if (type == global::SurfaceInfoObject.ImpactType.Melee)
		{
			return this.meleeEffects[global::UnityEngine.Random.Range(0, this.meleeEffects.Length)];
		}
		return null;
	}

	// Token: 0x0600309F RID: 12447 RVA: 0x000B8F78 File Offset: 0x000B7178
	public global::UnityEngine.AudioClip GetFootstepBiped(global::UnityEngine.AudioClip last)
	{
		int num = global::UnityEngine.Random.Range(0, this.bipedFootsteps.Length);
		global::UnityEngine.AudioClip audioClip = this.bipedFootsteps[num];
		if (last && audioClip == last)
		{
			if (num < this.bipedFootsteps.Length - 1)
			{
				num++;
			}
			else if (num >= 1)
			{
				num--;
			}
			audioClip = this.bipedFootsteps[num];
		}
		return this.bipedFootsteps[num];
	}

	// Token: 0x060030A0 RID: 12448 RVA: 0x000B8FFC File Offset: 0x000B71FC
	public global::UnityEngine.AudioClip GetFootstepBiped()
	{
		return this.bipedFootsteps[global::UnityEngine.Random.Range(0, this.bipedFootsteps.Length)];
	}

	// Token: 0x060030A1 RID: 12449 RVA: 0x000B901C File Offset: 0x000B721C
	public global::UnityEngine.AudioClip GetFootstepAnimal()
	{
		return this.animalFootsteps[global::UnityEngine.Random.Range(0, this.animalFootsteps.Length)];
	}

	// Token: 0x060030A2 RID: 12450 RVA: 0x000B903C File Offset: 0x000B723C
	public static global::SurfaceInfoObject GetDefault()
	{
		if (global::SurfaceInfoObject._default == null)
		{
			global::Facepunch.Bundling.Load<global::SurfaceInfoObject>("rust/effects/impact/default", out global::SurfaceInfoObject._default);
			if (global::SurfaceInfoObject._default == null)
			{
				global::UnityEngine.Debug.Log("COULD NOT GET DEFAULT!");
			}
		}
		return global::SurfaceInfoObject._default;
	}

	// Token: 0x04001A44 RID: 6724
	public static global::SurfaceInfoObject _default;

	// Token: 0x04001A45 RID: 6725
	public global::UnityEngine.GameObject[] bulletEffects;

	// Token: 0x04001A46 RID: 6726
	public global::UnityEngine.GameObject[] meleeEffects;

	// Token: 0x04001A47 RID: 6727
	public global::AudioClipArray bipedFootsteps;

	// Token: 0x04001A48 RID: 6728
	public global::AudioClipArray animalFootsteps;

	// Token: 0x020005D1 RID: 1489
	public enum ImpactType
	{
		// Token: 0x04001A4A RID: 6730
		Melee,
		// Token: 0x04001A4B RID: 6731
		Bullet
	}
}
