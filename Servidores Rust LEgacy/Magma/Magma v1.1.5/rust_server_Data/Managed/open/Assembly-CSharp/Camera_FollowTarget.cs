using System;
using UnityEngine;

// Token: 0x02000743 RID: 1859
public class Camera_FollowTarget : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003EA8 RID: 16040 RVA: 0x000DF288 File Offset: 0x000DD488
	public Camera_FollowTarget()
	{
	}

	// Token: 0x06003EA9 RID: 16041 RVA: 0x000DF2A8 File Offset: 0x000DD4A8
	private void Start()
	{
		this.quatCameraAngles = global::UnityEngine.Quaternion.identity;
	}

	// Token: 0x06003EAA RID: 16042 RVA: 0x000DF2B8 File Offset: 0x000DD4B8
	private void Update()
	{
		if (!this.bDropCamera)
		{
			this.UpdateCameraPosition();
		}
		else
		{
			base.transform.position = this.vecLastCameraPosition;
		}
		base.transform.rotation = global::UnityEngine.Quaternion.LookRotation(this.goTarget.transform.position + global::UnityEngine.Vector3.up - base.transform.position);
	}

	// Token: 0x06003EAB RID: 16043 RVA: 0x000DF328 File Offset: 0x000DD528
	private void UpdateCameraPosition()
	{
		global::UnityEngine.Vector3 vector = this.goTarget.transform.TransformDirection(global::UnityEngine.Vector3.forward);
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.AngleAxis(this.flCameraYawOffset, global::UnityEngine.Vector3.up);
		base.transform.position = this.goTarget.transform.position + global::UnityEngine.Vector3.up + quaternion * vector * this.flDistanceFromPlayer;
		this.vecLastCameraPosition = base.transform.position;
	}

	// Token: 0x0400200F RID: 8207
	public global::UnityEngine.GameObject goTarget;

	// Token: 0x04002010 RID: 8208
	public float flDistanceFromPlayer = 4f;

	// Token: 0x04002011 RID: 8209
	public float flCameraYawOffset = 45f;

	// Token: 0x04002012 RID: 8210
	private global::UnityEngine.Quaternion quatCameraAngles;

	// Token: 0x04002013 RID: 8211
	public bool bDropCamera;

	// Token: 0x04002014 RID: 8212
	private global::UnityEngine.Vector3 vecLastCameraPosition;
}
