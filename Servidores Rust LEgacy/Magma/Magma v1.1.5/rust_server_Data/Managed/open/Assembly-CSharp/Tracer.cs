using System;
using UnityEngine;

// Token: 0x020005D4 RID: 1492
public class Tracer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060030B0 RID: 12464 RVA: 0x000B93D4 File Offset: 0x000B75D4
	public Tracer()
	{
	}

	// Token: 0x060030B1 RID: 12465 RVA: 0x000B9414 File Offset: 0x000B7614
	private void Awake()
	{
		this.startTime = global::UnityEngine.Time.time;
		float num = global::UnityEngine.Random.Range(0.75f, 1f);
		this.startScale = new global::UnityEngine.Vector3(base.transform.localScale.x * num, base.transform.localScale.y * num, base.transform.localScale.z * global::UnityEngine.Random.Range(0.5f, 1f));
		base.transform.localScale = new global::UnityEngine.Vector3(0f, 0f, this.startScale.z);
	}

	// Token: 0x060030B2 RID: 12466 RVA: 0x000B94BC File Offset: 0x000B76BC
	public void Init(global::UnityEngine.Component component, int layerMask, float range, bool allowBlood)
	{
		this.layerMask = layerMask;
		this.colliderToHit = ((!(component is global::UnityEngine.Collider)) ? null : ((global::UnityEngine.Collider)component));
		this.thereIsACollider = base.collider;
		this.maxRange = range;
		this.allowBlood = allowBlood;
	}

	// Token: 0x060030B3 RID: 12467 RVA: 0x000B9510 File Offset: 0x000B7710
	private void Start()
	{
		this.lastUpdateTime = global::UnityEngine.Time.time;
	}

	// Token: 0x060030B4 RID: 12468 RVA: 0x000B9520 File Offset: 0x000B7720
	private void Update()
	{
		float num = global::UnityEngine.Time.time - this.lastUpdateTime;
		this.lastUpdateTime = global::UnityEngine.Time.time;
		if (this.distance > this.fadeDistStart)
		{
			base.transform.localScale = global::UnityEngine.Vector3.Lerp(base.transform.localScale, this.startScale, global::UnityEngine.Mathf.Clamp((this.distance - this.fadeDistStart) / this.fadeDistLength, 0f, 1f));
		}
		global::UnityEngine.RaycastHit raycastHit = default(global::UnityEngine.RaycastHit);
		global::RaycastHit2 invalid = global::RaycastHit2.invalid;
		global::UnityEngine.Ray ray;
		ray..ctor(base.transform.position, base.transform.forward);
		float num2 = this.speedPerSec * num;
		bool flag = !this.thereIsACollider || !this.colliderToHit || !this.colliderToHit.enabled;
		if ((!flag) ? this.colliderToHit.Raycast(ray, ref raycastHit, num2) : global::Physics2.Raycast2(ray, ref invalid, this.speedPerSec * num, this.layerMask))
		{
			float num3 = global::UnityEngine.Vector3.Distance(global::UnityEngine.Camera.main.transform.position, base.transform.position);
			if (num3 > 75f)
			{
				global::UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			global::UnityEngine.Vector3 normal;
			global::UnityEngine.Vector3 point;
			global::UnityEngine.GameObject gameObject;
			global::UnityEngine.Rigidbody rigidbody;
			if (flag)
			{
				normal = invalid.normal;
				point = invalid.point;
				gameObject = invalid.gameObject;
				rigidbody = invalid.rigidbody;
			}
			else
			{
				normal = raycastHit.normal;
				point = raycastHit.point;
				gameObject = raycastHit.collider.gameObject;
				rigidbody = raycastHit.rigidbody;
			}
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.LookRotation(normal);
			int layer = gameObject.layer;
			global::UnityEngine.GameObject gameObject2 = this.impactPrefab;
			bool flag2 = true;
			if (rigidbody && !rigidbody.isKinematic && !rigidbody.CompareTag("Door"))
			{
				rigidbody.AddForceAtPosition(global::UnityEngine.Vector3.up * 200f, point);
				rigidbody.AddForceAtPosition(ray.direction * 1000f, point);
			}
			global::SurfaceInfo.DoImpact(gameObject, global::SurfaceInfoObject.ImpactType.Bullet, point + normal * 0.01f, quaternion);
			if (layer == 0x11 || layer == 0x12 || layer == 0x1B || layer == 0x15)
			{
				flag2 = false;
			}
			global::UnityEngine.Object.Destroy(base.gameObject);
			if (flag2)
			{
				this.impactSounds[global::UnityEngine.Random.Range(0, this.impactSounds.Length)].Play(point, 1f, 2f, 15f, 0xB4);
				global::UnityEngine.GameObject gameObject3 = global::UnityEngine.Object.Instantiate(this.decalPrefab, point + normal * global::UnityEngine.Random.Range(0.01f, 0.03f), quaternion * global::UnityEngine.Quaternion.Euler(0f, 0f, (float)global::UnityEngine.Random.Range(-0x1E, 0x1E))) as global::UnityEngine.GameObject;
				if (gameObject)
				{
					gameObject3.transform.parent = gameObject.transform;
				}
				global::UnityEngine.Object.Destroy(gameObject3, 15f);
			}
		}
		else
		{
			base.transform.position += base.transform.forward * this.speedPerSec * num;
			this.distance += this.speedPerSec * num;
		}
		if (this.distance > this.maxRange)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001A55 RID: 6741
	public float speedPerSec;

	// Token: 0x04001A56 RID: 6742
	public float lastUpdateTime;

	// Token: 0x04001A57 RID: 6743
	public global::UnityEngine.GameObject impactPrefab;

	// Token: 0x04001A58 RID: 6744
	public global::UnityEngine.GameObject fleshImpactPrefab;

	// Token: 0x04001A59 RID: 6745
	public global::UnityEngine.GameObject decalPrefab;

	// Token: 0x04001A5A RID: 6746
	public global::UnityEngine.GameObject bloodDecalPrefab;

	// Token: 0x04001A5B RID: 6747
	public global::UnityEngine.GameObject myMesh;

	// Token: 0x04001A5C RID: 6748
	public global::UnityEngine.Vector3 startScale;

	// Token: 0x04001A5D RID: 6749
	public float distance;

	// Token: 0x04001A5E RID: 6750
	public float startTime;

	// Token: 0x04001A5F RID: 6751
	public float fadeDistStart = 0.15f;

	// Token: 0x04001A60 RID: 6752
	public float fadeDistLength = 0.25f;

	// Token: 0x04001A61 RID: 6753
	public global::UnityEngine.AudioClip[] impactSounds;

	// Token: 0x04001A62 RID: 6754
	public global::UnityEngine.AudioClip[] bodyImpactSounds;

	// Token: 0x04001A63 RID: 6755
	private global::UnityEngine.Collider colliderToHit;

	// Token: 0x04001A64 RID: 6756
	private bool thereIsACollider;

	// Token: 0x04001A65 RID: 6757
	private bool thereIsABodyPart;

	// Token: 0x04001A66 RID: 6758
	private bool allowBlood;

	// Token: 0x04001A67 RID: 6759
	private int layerMask = 0x183E1411;

	// Token: 0x04001A68 RID: 6760
	private float maxRange = 800f;
}
