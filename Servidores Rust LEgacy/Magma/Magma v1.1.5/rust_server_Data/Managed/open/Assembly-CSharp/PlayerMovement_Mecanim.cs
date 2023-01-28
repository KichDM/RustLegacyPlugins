using System;
using UnityEngine;

// Token: 0x02000744 RID: 1860
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.CharacterController))]
public class PlayerMovement_Mecanim : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003EAC RID: 16044 RVA: 0x000DF3AC File Offset: 0x000DD5AC
	public PlayerMovement_Mecanim()
	{
	}

	// Token: 0x06003EAD RID: 16045 RVA: 0x000DF418 File Offset: 0x000DD618
	private void Start()
	{
		this.playerController = base.GetComponent<global::UnityEngine.CharacterController>();
		this.playerAnimController = base.GetComponent<global::UnityEngine.Animator>();
	}

	// Token: 0x06003EAE RID: 16046 RVA: 0x000DF434 File Offset: 0x000DD634
	private void Update()
	{
		this.SetUpperBodyAimState();
		if (global::UnityEngine.Input.GetKey(0x63))
		{
			this.bCrouching = true;
		}
		else
		{
			this.bCrouching = false;
		}
		this.playerAnimController.SetBool("Crouching", this.bCrouching);
		if (global::UnityEngine.Input.GetKey(0x130) && global::UnityEngine.Mathf.Abs(global::UnityEngine.Input.GetAxis("Horizontal")) < 0.1f && !this.bCrouching && global::UnityEngine.Input.GetAxis("Vertical") > 0.1f)
		{
			this.bSprinting = true;
		}
		else
		{
			this.bSprinting = false;
		}
		if (global::UnityEngine.Input.GetKey(0x20) && this.playerController.isGrounded && !this.bCrouching)
		{
			this.bIsInAir = true;
			this.playerAnimController.SetTrigger("Jump");
			this.playerController.Move(global::UnityEngine.Vector3.up * 1.5f);
		}
		if (this.bIsInAir)
		{
			this.CheckLanding();
		}
		if (global::UnityEngine.Input.GetKeyDown(0x143) && this.flCanAttackAgainTime <= global::UnityEngine.Time.time)
		{
			this.flCanAttackAgainTime = global::UnityEngine.Time.time + this.flAttackTimers[this.iUpperBodyAimState];
			this.playerAnimController.SetTrigger("Attack");
		}
		this.playerAnimController.SetFloat("Move_ForwardBack", global::UnityEngine.Input.GetAxis("Vertical"));
		this.playerAnimController.SetFloat("Move_Strafe", global::UnityEngine.Input.GetAxis("Horizontal"));
		this.flPlayerAimPitch += global::UnityEngine.Input.GetAxis("Mouse Y") * this.flRotateSpeed;
		this.flPlayerAimPitch = global::UnityEngine.Mathf.Clamp(this.flPlayerAimPitch, -55f, 55f);
		this.playerAnimController.SetFloat("Aim_Vertical", this.flPlayerAimPitch);
		if (this.bSprinting)
		{
			this.flUpperBodyAimLayerWeight = global::UnityEngine.Mathf.Lerp(this.flUpperBodyAimLayerWeight, 0f, global::UnityEngine.Time.deltaTime * 6f);
			this.playerAnimController.SetBool("Sprinting", true);
		}
		else
		{
			if (this.iUpperBodyAimState == 0)
			{
				this.flUpperBodyAimLayerWeight = global::UnityEngine.Mathf.Lerp(this.flUpperBodyAimLayerWeight, 0f, global::UnityEngine.Time.deltaTime * 6f);
			}
			else
			{
				this.flUpperBodyAimLayerWeight = global::UnityEngine.Mathf.Lerp(this.flUpperBodyAimLayerWeight, 1f, global::UnityEngine.Time.deltaTime * 6f);
			}
			this.playerAnimController.SetBool("Sprinting", false);
		}
		this.playerAnimController.SetLayerWeight(1, this.flUpperBodyAimLayerWeight);
		global::UnityEngine.Vector3 vector = base.transform.TransformDirection(global::UnityEngine.Vector3.forward);
		vector *= global::UnityEngine.Input.GetAxis("Vertical");
		global::UnityEngine.Vector3 vector2 = base.transform.TransformDirection(global::UnityEngine.Vector3.right);
		vector2 *= global::UnityEngine.Input.GetAxis("Horizontal");
		if (this.bSprinting)
		{
			this.playerController.SimpleMove(vector * this.flSprintSpeed);
		}
		else if (this.bCrouching)
		{
			this.playerController.SimpleMove(vector * this.flCrouchWalkSpeed + vector2 * this.flCrouchWalkSpeed * 0.85f);
		}
		else
		{
			this.playerController.SimpleMove(vector * this.flWalkSpeed + vector2 * this.flWalkSpeed * 0.75f);
		}
	}

	// Token: 0x06003EAF RID: 16047 RVA: 0x000DF7A4 File Offset: 0x000DD9A4
	private void CheckLanding()
	{
		if (this.playerController.isGrounded)
		{
			this.bIsInAir = false;
			this.playerAnimController.SetTrigger("Land");
		}
	}

	// Token: 0x06003EB0 RID: 16048 RVA: 0x000DF7D0 File Offset: 0x000DD9D0
	private void SetUpperBodyAimState()
	{
		if (global::UnityEngine.Input.GetKeyDown(0x31))
		{
			this.iUpperBodyAimState = 1;
		}
		else if (global::UnityEngine.Input.GetKeyDown(0x32))
		{
			this.iUpperBodyAimState = 2;
		}
		else if (global::UnityEngine.Input.GetKeyDown(0x33))
		{
			this.iUpperBodyAimState = 3;
		}
		else if (global::UnityEngine.Input.GetKeyDown(0x34))
		{
			this.iUpperBodyAimState = 4;
		}
		else if (global::UnityEngine.Input.GetKeyDown(0x35))
		{
			this.iUpperBodyAimState = 5;
		}
		else if (global::UnityEngine.Input.GetKeyDown(0x30))
		{
			this.iUpperBodyAimState = 0;
		}
		this.playerAnimController.SetInteger("UpperBodyAimState", this.iUpperBodyAimState);
	}

	// Token: 0x04002015 RID: 8213
	public float flSprintSpeed = 6.2f;

	// Token: 0x04002016 RID: 8214
	public float flWalkSpeed = 2.55f;

	// Token: 0x04002017 RID: 8215
	public float flCrouchWalkSpeed = 1.54f;

	// Token: 0x04002018 RID: 8216
	public float flRotateSpeed = 9f;

	// Token: 0x04002019 RID: 8217
	public int iUpperBodyAimState;

	// Token: 0x0400201A RID: 8218
	private float flPlayerAimPitch;

	// Token: 0x0400201B RID: 8219
	private float flUpperBodyAimLayerWeight = 1f;

	// Token: 0x0400201C RID: 8220
	private float[] flAttackTimers = new float[]
	{
		0f,
		1f,
		0.1f,
		0.1f,
		1f,
		1f
	};

	// Token: 0x0400201D RID: 8221
	private float flCanAttackAgainTime = -1f;

	// Token: 0x0400201E RID: 8222
	private bool bIsInAir;

	// Token: 0x0400201F RID: 8223
	private bool bCrouching;

	// Token: 0x04002020 RID: 8224
	private bool bSprinting;

	// Token: 0x04002021 RID: 8225
	private global::UnityEngine.CharacterController playerController;

	// Token: 0x04002022 RID: 8226
	private global::UnityEngine.Animator playerAnimController;
}
