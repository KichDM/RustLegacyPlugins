using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200031C RID: 796
public sealed class PlayerPusher : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001AE1 RID: 6881 RVA: 0x0006A1E4 File Offset: 0x000683E4
	public PlayerPusher()
	{
	}

	// Token: 0x17000775 RID: 1909
	// (get) Token: 0x06001AE2 RID: 6882 RVA: 0x0006A1EC File Offset: 0x000683EC
	public global::UnityEngine.Rigidbody rigidbody
	{
		get
		{
			if (!this._gotRigidbody)
			{
				this._rigidbody = base.rigidbody;
				this._gotRigidbody = true;
			}
			return this._rigidbody;
		}
	}

	// Token: 0x06001AE3 RID: 6883 RVA: 0x0006A220 File Offset: 0x00068420
	private static bool GetCCMotor(global::UnityEngine.Collision collision, out global::CCMotor ccmotor)
	{
		global::UnityEngine.GameObject gameObject = collision.gameObject;
		if (gameObject.layer == 0x10)
		{
			ccmotor = gameObject.GetComponent<global::CCMotor>();
			return ccmotor;
		}
		ccmotor = null;
		return false;
	}

	// Token: 0x06001AE4 RID: 6884 RVA: 0x0006A258 File Offset: 0x00068458
	private bool AddMotor(global::CCMotor motor)
	{
		if (this.activeMotors == null)
		{
			this.activeMotors = new global::System.Collections.Generic.HashSet<global::CCMotor>();
			this.activeMotors.Add(motor);
			return true;
		}
		if (!this.activeMotors.Add(motor))
		{
			global::UnityEngine.Debug.LogWarning("Already added motor?", this);
			return false;
		}
		return true;
	}

	// Token: 0x06001AE5 RID: 6885 RVA: 0x0006A2AC File Offset: 0x000684AC
	private bool RemoveMotor(global::CCMotor motor)
	{
		if (this.activeMotors == null || !this.activeMotors.Remove(motor))
		{
			return false;
		}
		if (this.activeMotors.Count == 0)
		{
			this.activeMotors = null;
		}
		return true;
	}

	// Token: 0x06001AE6 RID: 6886 RVA: 0x0006A2F0 File Offset: 0x000684F0
	private bool ContainsMotor(global::CCMotor motor)
	{
		return this.activeMotors != null && this.activeMotors.Contains(motor);
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x0006A30C File Offset: 0x0006850C
	private void OnCollisionEnter(global::UnityEngine.Collision collision)
	{
		global::CCMotor ccmotor;
		if (global::PlayerPusher.GetCCMotor(collision, out ccmotor) && this.AddMotor(ccmotor))
		{
			try
			{
				ccmotor.OnPushEnter(this.rigidbody, base.collider, collision);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x0006A374 File Offset: 0x00068574
	private void OnCollisionStay(global::UnityEngine.Collision collision)
	{
		global::CCMotor ccmotor;
		if (global::PlayerPusher.GetCCMotor(collision, out ccmotor) && this.ContainsMotor(ccmotor))
		{
			try
			{
				ccmotor.OnPushStay(this.rigidbody, base.collider, collision);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x0006A3DC File Offset: 0x000685DC
	private void OnCollisionExit(global::UnityEngine.Collision collision)
	{
		global::CCMotor ccmotor;
		if (global::PlayerPusher.GetCCMotor(collision, out ccmotor) && this.RemoveMotor(ccmotor))
		{
			try
			{
				ccmotor.OnPushExit(this.rigidbody, base.collider, collision);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}
	}

	// Token: 0x04000FA2 RID: 4002
	[global::System.NonSerialized]
	private global::UnityEngine.Rigidbody _rigidbody;

	// Token: 0x04000FA3 RID: 4003
	[global::System.NonSerialized]
	private bool _gotRigidbody;

	// Token: 0x04000FA4 RID: 4004
	[global::System.NonSerialized]
	private global::System.Collections.Generic.HashSet<global::CCMotor> activeMotors;
}
