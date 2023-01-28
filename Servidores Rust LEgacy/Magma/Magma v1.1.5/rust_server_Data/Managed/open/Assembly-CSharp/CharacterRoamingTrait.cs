using System;
using UnityEngine;

// Token: 0x0200013B RID: 315
public class CharacterRoamingTrait : global::CharacterTrait
{
	// Token: 0x060007C8 RID: 1992 RVA: 0x000214FC File Offset: 0x0001F6FC
	public CharacterRoamingTrait()
	{
	}

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x060007C9 RID: 1993 RVA: 0x000215A8 File Offset: 0x0001F7A8
	public float maxRoamDistance
	{
		get
		{
			return (!this._allowed) ? 0f : this._maxRoamDistance;
		}
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x060007CA RID: 1994 RVA: 0x000215C8 File Offset: 0x0001F7C8
	public float minRoamDistance
	{
		get
		{
			return (!this._allowed) ? 0f : this._minRoamDistance;
		}
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x060007CB RID: 1995 RVA: 0x000215E8 File Offset: 0x0001F7E8
	public float randomRoamDistance
	{
		get
		{
			return (!this._allowed) ? 0f : ((this._minRoamDistance != this._maxRoamDistance) ? (this._minRoamDistance + (this._maxRoamDistance - this._minRoamDistance) * global::UnityEngine.Random.value) : this._minRoamDistance);
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x060007CC RID: 1996 RVA: 0x00021640 File Offset: 0x0001F840
	public float maxFleeDistance
	{
		get
		{
			return (!this._allowed) ? 0f : this._maxFleeDistance;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x060007CD RID: 1997 RVA: 0x00021660 File Offset: 0x0001F860
	public float minFleeDistance
	{
		get
		{
			return (!this._allowed) ? 0f : this._minFleeDistance;
		}
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x060007CE RID: 1998 RVA: 0x00021680 File Offset: 0x0001F880
	public float randomFleeDistance
	{
		get
		{
			return (!this._allowed) ? 0f : ((this._minFleeDistance != this._maxFleeDistance) ? (this._minFleeDistance + (this._maxFleeDistance - this._minFleeDistance) * global::UnityEngine.Random.value) : this._minFleeDistance);
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x060007CF RID: 1999 RVA: 0x000216D8 File Offset: 0x0001F8D8
	public float minRoamAngle
	{
		get
		{
			return (!this._allowed) ? 0f : this._minRoamAngle;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x060007D0 RID: 2000 RVA: 0x000216F8 File Offset: 0x0001F8F8
	public float maxRoamAngle
	{
		get
		{
			return (!this._allowed) ? 0f : this._maxRoamAngle;
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x060007D1 RID: 2001 RVA: 0x00021718 File Offset: 0x0001F918
	public float randomRoamAngle
	{
		get
		{
			return (!this._allowed) ? 0f : ((this._maxRoamAngle != this._minRoamAngle) ? (this._minRoamAngle + (this._maxRoamAngle - this._minRoamAngle) * global::UnityEngine.Random.value) : this._minRoamAngle);
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x060007D2 RID: 2002 RVA: 0x00021770 File Offset: 0x0001F970
	public int minIdleMilliseconds
	{
		get
		{
			return this._minIdleMilliseconds;
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x060007D3 RID: 2003 RVA: 0x00021778 File Offset: 0x0001F978
	public int maxIdleMilliseconds
	{
		get
		{
			return this._maxIdleMilliseconds;
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x060007D4 RID: 2004 RVA: 0x00021780 File Offset: 0x0001F980
	public int randomIdleMilliseconds
	{
		get
		{
			return (this._minIdleMilliseconds != this._maxIdleMilliseconds) ? ((this._minIdleMilliseconds >= this._maxIdleMilliseconds) ? global::UnityEngine.Random.Range(this._maxIdleMilliseconds, this._minIdleMilliseconds + 1) : global::UnityEngine.Random.Range(this._minIdleMilliseconds, this._maxIdleMilliseconds + 1)) : this._minIdleMilliseconds;
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x060007D5 RID: 2005 RVA: 0x000217E8 File Offset: 0x0001F9E8
	public int retryFromFailureMilliseconds
	{
		get
		{
			return this._retryFromFailureMilliseconds;
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000217F0 File Offset: 0x0001F9F0
	public float minIdleSeconds
	{
		get
		{
			return (float)((double)this._minIdleMilliseconds / 1000.0);
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x060007D7 RID: 2007 RVA: 0x00021804 File Offset: 0x0001FA04
	public float maxIdleSeconds
	{
		get
		{
			return (float)((double)this._maxIdleMilliseconds / 1000.0);
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00021818 File Offset: 0x0001FA18
	public float randomIdleSeconds
	{
		get
		{
			return (float)((double)this.randomIdleMilliseconds / 1000.0);
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x060007D9 RID: 2009 RVA: 0x0002182C File Offset: 0x0001FA2C
	public float retryFromFailureSeconds
	{
		get
		{
			return (float)((double)this._retryFromFailureMilliseconds / 1000.0);
		}
	}

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x060007DA RID: 2010 RVA: 0x00021840 File Offset: 0x0001FA40
	public float roamRadius
	{
		get
		{
			return this._roamRadius;
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x060007DB RID: 2011 RVA: 0x00021848 File Offset: 0x0001FA48
	public bool allowed
	{
		get
		{
			return this._allowed;
		}
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x060007DC RID: 2012 RVA: 0x00021850 File Offset: 0x0001FA50
	public global::UnityEngine.Vector3 randomRoamVector
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.y = 0f;
			if (this._allowed)
			{
				float randomRoamDistance = this.randomRoamDistance;
				float num = this.randomRoamAngle * 0.017453292f;
				result.x = global::UnityEngine.Mathf.Sin(num) * randomRoamDistance;
				result.z = global::UnityEngine.Mathf.Cos(num) * randomRoamDistance;
			}
			else
			{
				result.x = 0f;
				result.z = 0f;
			}
			return result;
		}
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x060007DD RID: 2013 RVA: 0x000218C4 File Offset: 0x0001FAC4
	public global::UnityEngine.Vector3 randomFleeVector
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.y = 0f;
			if (this._allowed)
			{
				float randomFleeDistance = this.randomFleeDistance;
				float num = this.randomRoamAngle * 0.017453292f;
				result.x = global::UnityEngine.Mathf.Sin(num) * randomFleeDistance;
				result.z = global::UnityEngine.Mathf.Cos(num) * randomFleeDistance;
			}
			else
			{
				result.x = 0f;
				result.z = 0f;
			}
			return result;
		}
	}

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x060007DE RID: 2014 RVA: 0x00021938 File Offset: 0x0001FB38
	public global::UnityEngine.Vector3 randomRoamNormal
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.y = 0f;
			if (this._allowed)
			{
				float num = this.randomRoamAngle * 0.017453292f;
				result.x = global::UnityEngine.Mathf.Sin(num);
				result.z = global::UnityEngine.Mathf.Cos(num);
			}
			else
			{
				result.x = 0f;
				result.z = 0f;
			}
			return result;
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x060007DF RID: 2015 RVA: 0x000219A4 File Offset: 0x0001FBA4
	public float fleeSpeed
	{
		get
		{
			return this._fleeSpeed;
		}
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x060007E0 RID: 2016 RVA: 0x000219AC File Offset: 0x0001FBAC
	public float runSpeed
	{
		get
		{
			return this._runSpeed;
		}
	}

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x060007E1 RID: 2017 RVA: 0x000219B4 File Offset: 0x0001FBB4
	public float walkSpeed
	{
		get
		{
			return this._walkSpeed;
		}
	}

	// Token: 0x0400061E RID: 1566
	[global::UnityEngine.SerializeField]
	private float _maxRoamDistance = 20f;

	// Token: 0x0400061F RID: 1567
	[global::UnityEngine.SerializeField]
	private float _minRoamDistance = 10f;

	// Token: 0x04000620 RID: 1568
	[global::UnityEngine.SerializeField]
	private float _minRoamAngle = -180f;

	// Token: 0x04000621 RID: 1569
	[global::UnityEngine.SerializeField]
	private float _maxRoamAngle = 180f;

	// Token: 0x04000622 RID: 1570
	[global::UnityEngine.SerializeField]
	private float _maxFleeDistance = 40f;

	// Token: 0x04000623 RID: 1571
	[global::UnityEngine.SerializeField]
	private float _minFleeDistance = 21f;

	// Token: 0x04000624 RID: 1572
	[global::UnityEngine.SerializeField]
	private float _roamRadius = 80f;

	// Token: 0x04000625 RID: 1573
	[global::UnityEngine.SerializeField]
	private bool _allowed = true;

	// Token: 0x04000626 RID: 1574
	[global::UnityEngine.SerializeField]
	private int _minIdleMilliseconds = 0x7D0;

	// Token: 0x04000627 RID: 1575
	[global::UnityEngine.SerializeField]
	private int _maxIdleMilliseconds = 0x1F40;

	// Token: 0x04000628 RID: 1576
	[global::UnityEngine.SerializeField]
	private int _retryFromFailureMilliseconds = 0x320;

	// Token: 0x04000629 RID: 1577
	[global::UnityEngine.SerializeField]
	private float _fleeSpeed = 9f;

	// Token: 0x0400062A RID: 1578
	[global::UnityEngine.SerializeField]
	private float _runSpeed = 6f;

	// Token: 0x0400062B RID: 1579
	[global::UnityEngine.SerializeField]
	private float _walkSpeed = 1.8f;
}
