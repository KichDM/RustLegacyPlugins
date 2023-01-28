using System;
using UnityEngine;

// Token: 0x020005D7 RID: 1495
public class FootstepEmitter : global::IDLocalCharacter
{
	// Token: 0x060030B9 RID: 12473 RVA: 0x000B98E0 File Offset: 0x000B7AE0
	public FootstepEmitter()
	{
	}

	// Token: 0x060030BA RID: 12474 RVA: 0x000B98E8 File Offset: 0x000B7AE8
	private void Start()
	{
		this.lastFootstepPos = base.origin;
		this.trait = base.GetTrait<global::CharacterFootstepTrait>();
		base.enabled = false;
	}

	// Token: 0x060030BB RID: 12475 RVA: 0x000B990C File Offset: 0x000B7B0C
	private global::UnityEngine.Collider GetBelowObj()
	{
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(new global::UnityEngine.Ray(base.transform.position + new global::UnityEngine.Vector3(0f, 0.25f, 0f), global::UnityEngine.Vector3.down), ref raycastHit, 1f))
		{
			return raycastHit.collider;
		}
		return null;
	}

	// Token: 0x060030BC RID: 12476 RVA: 0x000B9964 File Offset: 0x000B7B64
	private void Update()
	{
		if (this.terraincheck)
		{
			int textureIndex = global::TerrainTextureHelper.GetTextureIndex(base.origin);
		}
		bool timeLimited;
		if (!base.stateFlags.grounded || ((timeLimited = this.trait.timeLimited) && this.nextAllowTime > global::UnityEngine.Time.time) || (base.masterControllable && base.masterControllable.idMain != base.idMain))
		{
			return;
		}
		bool crouch = base.stateFlags.crouch;
		global::UnityEngine.Vector3 origin = base.origin;
		this.movedAmount += global::UnityEngine.Vector3.Distance(this.lastFootstepPos, origin);
		this.lastFootstepPos = origin;
		if (this.movedAmount >= this.trait.sqrStrideDist)
		{
			this.movedAmount = 0f;
			global::UnityEngine.AudioClip audioClip = null;
			if (global::footsteps.quality >= 2 || (global::footsteps.quality == 1 && base.character.localControlled))
			{
				global::UnityEngine.Collider belowObj = this.GetBelowObj();
				if (belowObj)
				{
					global::SurfaceInfoObject surfaceInfoFor = global::SurfaceInfo.GetSurfaceInfoFor(belowObj, origin);
					if (surfaceInfoFor)
					{
						audioClip = ((!this.trait.animal) ? surfaceInfoFor.GetFootstepBiped(this.lastPlayed) : surfaceInfoFor.GetFootstepAnimal());
						this.lastPlayed = audioClip;
					}
				}
			}
			if (!audioClip)
			{
				audioClip = this.trait.defaultFootsteps[global::UnityEngine.Random.Range(0, this.trait.defaultFootsteps.Length)];
				if (!audioClip)
				{
					return;
				}
			}
			float minAudioDist = this.trait.minAudioDist;
			float maxAudioDist = this.trait.maxAudioDist;
			if (crouch)
			{
				audioClip.Play(origin, 0.2f, global::UnityEngine.Random.Range(0.95f, 1.05f), minAudioDist * 0.333f, maxAudioDist * 0.333f, 0x1E);
			}
			else
			{
				audioClip.Play(origin, 0.65f, global::UnityEngine.Random.Range(0.95f, 1.05f), minAudioDist, maxAudioDist, 0x1E);
			}
			if (timeLimited)
			{
				this.nextAllowTime = global::UnityEngine.Time.time + this.trait.minInterval;
			}
		}
	}

	// Token: 0x04001A6B RID: 6763
	[global::System.NonSerialized]
	private global::CharacterFootstepTrait trait;

	// Token: 0x04001A6C RID: 6764
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 lastFootstepPos;

	// Token: 0x04001A6D RID: 6765
	[global::System.NonSerialized]
	private float nextAllowTime;

	// Token: 0x04001A6E RID: 6766
	[global::System.NonSerialized]
	private float movedAmount;

	// Token: 0x04001A6F RID: 6767
	public bool terraincheck;

	// Token: 0x04001A70 RID: 6768
	private global::UnityEngine.AudioClip lastPlayed;
}
