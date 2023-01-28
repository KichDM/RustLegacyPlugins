using System;
using UnityEngine;

// Token: 0x02000606 RID: 1542
public class Orbit : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003158 RID: 12632 RVA: 0x000BCF1C File Offset: 0x000BB11C
	public Orbit()
	{
	}

	// Token: 0x06003159 RID: 12633 RVA: 0x000BCF24 File Offset: 0x000BB124
	private void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.matrix = base.transform.localToWorldMatrix;
		global::UnityEngine.Gizmos.DrawLine(this.orbitPosition, global::UnityEngine.Vector3.zero);
		global::UnityEngine.Gizmos.DrawSphere(this.orbitPosition, 0.01f);
	}

	// Token: 0x0600315A RID: 12634 RVA: 0x000BCF64 File Offset: 0x000BB164
	private void Update()
	{
		float deltaTime = global::UnityEngine.Time.deltaTime;
		if (deltaTime != 0f)
		{
			global::UnityEngine.Vector3 vector;
			vector.x = this.orbitEulerSpeed.x * deltaTime;
			vector.y = this.orbitEulerSpeed.y * deltaTime;
			vector.z = this.orbitEulerSpeed.z * deltaTime;
			if (vector.x != 0f || vector.y != 0f || vector.z != 0f)
			{
				global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(vector);
				global::UnityEngine.Quaternion quaternion2 = base.transform.localRotation * quaternion;
				if (this.orbitCenter)
				{
					base.transform.localPosition = quaternion2 * this.orbitPosition;
				}
				else
				{
					base.transform.localPosition = quaternion2 * -this.orbitPosition + this.orbitPosition;
				}
				base.transform.localRotation = quaternion2;
			}
		}
	}

	// Token: 0x04001B7C RID: 7036
	public global::UnityEngine.Vector3 orbitPosition;

	// Token: 0x04001B7D RID: 7037
	public global::UnityEngine.Vector3 orbitEulerSpeed;

	// Token: 0x04001B7E RID: 7038
	public bool orbitCenter;
}
