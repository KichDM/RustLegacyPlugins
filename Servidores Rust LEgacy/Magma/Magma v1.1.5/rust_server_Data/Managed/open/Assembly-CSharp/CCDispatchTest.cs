using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public class CCDispatchTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060019BD RID: 6589 RVA: 0x000639BC File Offset: 0x00061BBC
	public CCDispatchTest()
	{
	}

	// Token: 0x060019BE RID: 6590 RVA: 0x00063A14 File Offset: 0x00061C14
	private void Awake()
	{
		this.currentHeight = this.crouchHeight;
		this.totemPole.OnBindPosition += this.BindPositions;
	}

	// Token: 0x060019BF RID: 6591 RVA: 0x00063A3C File Offset: 0x00061C3C
	private void OnDestroy()
	{
		if (this.totemPole)
		{
			this.totemPole.OnBindPosition -= this.BindPositions;
		}
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x00063A68 File Offset: 0x00061C68
	private void BindPositions(ref global::CCTotem.PositionPlacement placement, object Tag)
	{
		base.transform.position = placement.bottom;
		this.fpsCam.transform.position = placement.top - new global::UnityEngine.Vector3(0f, 0.25f, 0f);
	}

	// Token: 0x060019C1 RID: 6593 RVA: 0x00063AB8 File Offset: 0x00061CB8
	private void Update()
	{
		float deltaTime = global::UnityEngine.Time.deltaTime;
		global::UnityEngine.Vector3 motion;
		motion..ctor(global::UnityEngine.Input.GetAxis("Horizontal") * this.horizonalScalar, -this.downwardSpeed, global::UnityEngine.Input.GetAxis("Vertical") * this.horizonalScalar);
		float num = motion.x * motion.x + motion.z * motion.z;
		float num2;
		if (num > this.horizonalScalar * this.horizonalScalar)
		{
			num2 = this.horizonalScalar / global::UnityEngine.Mathf.Sqrt(num) * deltaTime;
		}
		else
		{
			num2 = deltaTime;
		}
		motion.x *= num2;
		motion.z *= num2;
		motion.y *= deltaTime;
		float num3 = (!global::UnityEngine.Input.GetButton("Crouch")) ? this.standingHeight : this.crouchHeight;
		this.currentHeight = global::UnityEngine.Mathf.SmoothDamp(this.currentHeight, num3, ref this.crouchVelocity, this.crouchSmoothing, this.crouchMaxSpeed, deltaTime);
		this.totemPole.Move(motion, this.currentHeight);
	}

	// Token: 0x04000E91 RID: 3729
	[global::UnityEngine.SerializeField]
	private global::CCTotemPole totemPole;

	// Token: 0x04000E92 RID: 3730
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Camera fpsCam;

	// Token: 0x04000E93 RID: 3731
	public float crouchHeight = 1.3f;

	// Token: 0x04000E94 RID: 3732
	public float standingHeight = 2f;

	// Token: 0x04000E95 RID: 3733
	public float crouchSmoothing = 0.02f;

	// Token: 0x04000E96 RID: 3734
	public float crouchMaxSpeed = 5f;

	// Token: 0x04000E97 RID: 3735
	public float horizonalScalar = 4f;

	// Token: 0x04000E98 RID: 3736
	public float downwardSpeed = 10f;

	// Token: 0x04000E99 RID: 3737
	[global::System.NonSerialized]
	private float crouchVelocity;

	// Token: 0x04000E9A RID: 3738
	[global::System.NonSerialized]
	private float currentHeight;
}
