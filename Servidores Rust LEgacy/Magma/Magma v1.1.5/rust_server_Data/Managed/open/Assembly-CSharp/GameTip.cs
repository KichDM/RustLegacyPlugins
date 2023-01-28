using System;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class GameTip : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C41 RID: 11329 RVA: 0x000A6BE0 File Offset: 0x000A4DE0
	public GameTip()
	{
	}

	// Token: 0x06002C42 RID: 11330 RVA: 0x000A6C50 File Offset: 0x000A4E50
	public bool TestLineOfSight(float fDistance)
	{
		global::UnityEngine.Vector3 vector = base.transform.position + this.testOffset - global::UnityEngine.Camera.main.transform.position;
		vector.Normalize();
		global::UnityEngine.Ray ray;
		ray..ctor(global::UnityEngine.Camera.main.transform.position, vector);
		global::UnityEngine.RaycastHit raycastHit;
		return global::UnityEngine.Physics.Raycast(ray, ref raycastHit, fDistance) && raycastHit.distance <= fDistance - 0.5f && (!this.TargetCollider || !(raycastHit.collider == this.TargetCollider)) && !base.transform.IsChildOf(raycastHit.collider.gameObject.transform) && !raycastHit.collider.gameObject.transform.IsChildOf(base.transform);
	}

	// Token: 0x06002C43 RID: 11331 RVA: 0x000A6D3C File Offset: 0x000A4F3C
	public void OnWillRenderObject()
	{
		if (global::UnityEngine.Camera.main != global::UnityEngine.Camera.current)
		{
			return;
		}
		float num = global::UnityEngine.Vector3.Distance(base.transform.position, global::UnityEngine.Camera.main.transform.position);
		if (num > this.maxDistance)
		{
			return;
		}
		if (this.lineOfSight && this.TestLineOfSight(num))
		{
			return;
		}
		float num2 = num / this.maxDistance;
		float alpha = 1f - num2;
		float fscale = 2f / (num * (2f * global::UnityEngine.Mathf.Tan(global::UnityEngine.Camera.main.fieldOfView / 2f * 0.017453292f)));
		global::GameTooltipManager.Singleton.UpdateTip(base.gameObject, this.text, base.transform.position + this.positionOffset, this.textColor, alpha, fscale);
	}

	// Token: 0x0400168F RID: 5775
	public string text = "Tooltip Text";

	// Token: 0x04001690 RID: 5776
	public bool lineOfSight = true;

	// Token: 0x04001691 RID: 5777
	public global::UnityEngine.Vector3 testOffset = new global::UnityEngine.Vector3(0f, 0f, 0f);

	// Token: 0x04001692 RID: 5778
	public global::UnityEngine.Vector3 positionOffset = new global::UnityEngine.Vector3(0f, 0f, 0f);

	// Token: 0x04001693 RID: 5779
	public global::UnityEngine.Color textColor = global::UnityEngine.Color.white;

	// Token: 0x04001694 RID: 5780
	public float maxDistance = 16f;

	// Token: 0x04001695 RID: 5781
	public global::UnityEngine.Collider TargetCollider;
}
