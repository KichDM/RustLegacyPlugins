using System;
using UnityEngine;

// Token: 0x0200012B RID: 299
public class CharacterCCMotorTrait : global::CharacterTrait
{
	// Token: 0x06000757 RID: 1879 RVA: 0x00020344 File Offset: 0x0001E544
	public CharacterCCMotorTrait()
	{
	}

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x06000758 RID: 1880 RVA: 0x00020378 File Offset: 0x0001E578
	public global::CCTotemPole prefab
	{
		get
		{
			return this._prefab;
		}
	}

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x06000759 RID: 1881 RVA: 0x00020380 File Offset: 0x0001E580
	public global::CCMotorSettings settings
	{
		get
		{
			return this._settings;
		}
	}

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x0600075A RID: 1882 RVA: 0x00020388 File Offset: 0x0001E588
	public bool canControl
	{
		get
		{
			return this._canControl;
		}
	}

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x0600075B RID: 1883 RVA: 0x00020390 File Offset: 0x0001E590
	public bool sendFallMessage
	{
		get
		{
			return this._sendFallMessage;
		}
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x0600075C RID: 1884 RVA: 0x00020398 File Offset: 0x0001E598
	public bool sendLandMessage
	{
		get
		{
			return this._sendLandMessage;
		}
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x0600075D RID: 1885 RVA: 0x000203A0 File Offset: 0x0001E5A0
	public bool sendJumpMessage
	{
		get
		{
			return this._sendJumpMessage;
		}
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x0600075E RID: 1886 RVA: 0x000203A8 File Offset: 0x0001E5A8
	public bool sendExternalVelocityMessage
	{
		get
		{
			return this._sendExternalVelocityMessage;
		}
	}

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x0600075F RID: 1887 RVA: 0x000203B0 File Offset: 0x0001E5B0
	public bool sendJumpFailureMessage
	{
		get
		{
			return this._sendJumpFailureMessage;
		}
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x06000760 RID: 1888 RVA: 0x000203B8 File Offset: 0x0001E5B8
	public global::CCMotor.StepMode stepMode
	{
		get
		{
			return this._stepMode;
		}
	}

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x06000761 RID: 1889 RVA: 0x000203C0 File Offset: 0x0001E5C0
	public float minTimeBetweenJumps
	{
		get
		{
			return this._minTimeBetweenJumps;
		}
	}

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x06000762 RID: 1890 RVA: 0x000203C8 File Offset: 0x0001E5C8
	public bool enableColliderOnInit
	{
		get
		{
			return this._enableColliderOnInit;
		}
	}

	// Token: 0x040005D9 RID: 1497
	[global::UnityEngine.SerializeField]
	private global::CCMotorSettings _settings;

	// Token: 0x040005DA RID: 1498
	[global::UnityEngine.SerializeField]
	private global::CCTotemPole _prefab;

	// Token: 0x040005DB RID: 1499
	[global::UnityEngine.SerializeField]
	private bool _canControl = true;

	// Token: 0x040005DC RID: 1500
	[global::UnityEngine.SerializeField]
	private bool _sendFallMessage;

	// Token: 0x040005DD RID: 1501
	[global::UnityEngine.SerializeField]
	private bool _sendLandMessage;

	// Token: 0x040005DE RID: 1502
	[global::UnityEngine.SerializeField]
	private bool _sendJumpMessage;

	// Token: 0x040005DF RID: 1503
	[global::UnityEngine.SerializeField]
	private bool _sendExternalVelocityMessage;

	// Token: 0x040005E0 RID: 1504
	[global::UnityEngine.SerializeField]
	private bool _sendJumpFailureMessage;

	// Token: 0x040005E1 RID: 1505
	[global::UnityEngine.SerializeField]
	private bool _enableColliderOnInit = true;

	// Token: 0x040005E2 RID: 1506
	[global::UnityEngine.SerializeField]
	private float _minTimeBetweenJumps = 1f;

	// Token: 0x040005E3 RID: 1507
	[global::UnityEngine.SerializeField]
	private global::CCMotor.StepMode _stepMode = global::CCMotor.StepMode.Elsewhere;
}
