using System;
using UnityEngine;

// Token: 0x020009B0 RID: 2480
public class CreateCraterOnImpact : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600534E RID: 21326 RVA: 0x0015DC84 File Offset: 0x0015BE84
	public CreateCraterOnImpact()
	{
	}

	// Token: 0x0600534F RID: 21327 RVA: 0x0015DCB0 File Offset: 0x0015BEB0
	private void OnCollisionEnter(global::UnityEngine.Collision collision)
	{
		if (this.Explosion)
		{
			global::UnityEngine.Object.Instantiate(this.Explosion, collision.contacts[0].point, global::UnityEngine.Quaternion.identity);
		}
		global::CraterMaker component = collision.gameObject.GetComponent<global::CraterMaker>();
		if (component)
		{
			component.Create(collision.contacts[0].point, this.Radius, this.Depth, this.Noise);
		}
		global::UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x040030D9 RID: 12505
	public float Radius = 15f;

	// Token: 0x040030DA RID: 12506
	public float Depth = 10f;

	// Token: 0x040030DB RID: 12507
	public float Noise = 0.5f;

	// Token: 0x040030DC RID: 12508
	public global::UnityEngine.GameObject Explosion;
}
