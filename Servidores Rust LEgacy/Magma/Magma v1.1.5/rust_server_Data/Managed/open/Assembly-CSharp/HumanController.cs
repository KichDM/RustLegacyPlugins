using System;
using Facepunch.Cursor;
using Magma;
using uLink;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class HumanController : global::Controller, global::RagdollTransferInfoProvider
{
	// Token: 0x06000394 RID: 916 RVA: 0x00010FD8 File Offset: 0x0000F1D8
	public HumanController() : this((global::Controller.ControllerFlags)0x20C1)
	{
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00010FE8 File Offset: 0x0000F1E8
	protected HumanController(global::Controller.ControllerFlags controllerFlags) : base(controllerFlags)
	{
	}

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000396 RID: 918 RVA: 0x00011038 File Offset: 0x0000F238
	global::RagdollTransferInfo global::RagdollTransferInfoProvider.RagdollTransferInfo
	{
		get
		{
			return "RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1";
		}
	}

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06000397 RID: 919 RVA: 0x00011044 File Offset: 0x0000F244
	public bool bleeding
	{
		get
		{
			return (!this.clientVitalsSync) ? base.stateFlags.bleeding : this.clientVitalsSync.bleeding;
		}
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x06000398 RID: 920 RVA: 0x00011080 File Offset: 0x0000F280
	protected global::HumanControlConfiguration controlConfig
	{
		get
		{
			if (!this._didControlConfigTest)
			{
				this._controlConfig = base.GetTrait<global::HumanControlConfiguration>();
				this._didControlConfigTest = true;
			}
			return this._controlConfig;
		}
	}

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x06000399 RID: 921 RVA: 0x000110B4 File Offset: 0x0000F2B4
	private global::UnityEngine.Transform headBone
	{
		get
		{
			if (!this._headBone)
			{
				this._headBone = base.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1");
				if (!this._headBone)
				{
					this._headBone = base.transform.FindChild("RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1");
					if (!this._headBone)
					{
						global::Character idMain = base.idMain;
						if (idMain && idMain.eyesTransformReadOnly)
						{
							this._headBone = idMain.eyesTransformReadOnly;
						}
						else
						{
							this._headBone = base.transform;
						}
					}
				}
			}
			return this._headBone;
		}
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x0600039A RID: 922 RVA: 0x00011164 File Offset: 0x0000F364
	public global::InventoryHolder inventoryHolder
	{
		get
		{
			global::Inventory inventory = this.inventory;
			return (!inventory) ? null : inventory.inventoryHolder;
		}
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x0600039B RID: 923 RVA: 0x00011190 File Offset: 0x0000F390
	public global::Inventory inventory
	{
		get
		{
			if (!this.__inventory.cached)
			{
				this.__inventory = base.GetLocal<global::Inventory>();
			}
			return this.__inventory.value;
		}
	}

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x0600039C RID: 924 RVA: 0x000111CC File Offset: 0x0000F3CC
	private global::PlayerInventory _inventory
	{
		get
		{
			return this.inventory as global::PlayerInventory;
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x000111DC File Offset: 0x0000F3DC
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.instantiatedPlayerClient = base.playerClient;
		if (this.instantiatedPlayerClient)
		{
			base.name = string.Format("{0}{1}", this.instantiatedPlayerClient.name, info.networkView.localPrefab);
		}
		try
		{
			this.deathTransfer = base.AddAddon<global::DeathTransfer>();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex, this);
		}
		if (base.networkView.isMine)
		{
			global::UnityEngine.Object.Destroy(base.GetComponent<global::ApplyCrouch>());
		}
		else
		{
			global::VisNode visNode = base.visNode;
			if (visNode)
			{
				visNode.enabled = true;
				visNode.head = base.eyesTransformReadOnly;
			}
			global::ServerHelper.SetupForServer(base.gameObject);
			if (global::dmg.godadmins)
			{
				global::NetUser netUser = global::NetUser.Find(base.networkView.owner);
				if (netUser != null && netUser.CanAdmin())
				{
					base.GetComponent<global::TakeDamage>().SetGodMode(true);
				}
			}
			global::UnityEngine.Object.Destroy(base.GetComponent<global::LocalDamageDisplay>());
			base.gameObject.layer = 0x1A;
			base.gameObject.AddComponent<global::UnityEngine.SphereCollider>();
			global::UnityEngine.Rigidbody rigidbody = base.gameObject.AddComponent<global::UnityEngine.Rigidbody>();
			rigidbody.isKinematic = true;
		}
		this.lastServerFrameTime = global::UnityEngine.Time.time;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00011330 File Offset: 0x0000F530
	private void SetLocalOnlyComponentsEnabled(bool enable)
	{
		global::CCMotor component = base.GetComponent<global::CCMotor>();
		if (component)
		{
			component.enabled = enable;
			global::UnityEngine.CharacterController characterController = base.collider as global::UnityEngine.CharacterController;
			if (characterController)
			{
				characterController.enabled = enable;
			}
		}
		global::LocalDamageDisplay component2 = base.GetComponent<global::LocalDamageDisplay>();
		if (component2)
		{
			component2.enabled = enable;
		}
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00011390 File Offset: 0x0000F590
	protected override void OnControlEnter()
	{
		base.OnControlEnter();
		if (!base.networkViewIsMine)
		{
			this.clientVitalsSync = base.AddAddon<global::ClientVitalsSync>();
		}
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x000113B0 File Offset: 0x0000F5B0
	protected override void OnControlEngauge()
	{
		base.OnControlEngauge();
		if (base.localControlled)
		{
			if (this.onceEngaged)
			{
				if (this.proxyTest)
				{
					this.proxyTest.treatAsProxy = false;
				}
			}
			else
			{
				this.proxyTest = base.GetComponent<global::PlayerProxyTest>();
				this.onceEngaged = true;
			}
			base.enabled = true;
		}
		else
		{
			this.clockTest = global::NetClockTester.Reset;
		}
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00011424 File Offset: 0x0000F624
	protected override void OnControlCease()
	{
		base.enabled = false;
		if (base.localControlled)
		{
			if (this.proxyTest)
			{
				this.proxyTest.treatAsProxy = true;
			}
			if (this._inventory)
			{
				this._inventory.DeactivateItem();
			}
		}
		base.OnControlCease();
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00011480 File Offset: 0x0000F680
	protected override void OnControlExit()
	{
		base.RemoveAddon<global::ClientVitalsSync>(ref this.clientVitalsSync);
		this._inventory.RemoveNetListener(base.networkView.owner);
		base.OnControlExit();
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x000114B8 File Offset: 0x0000F6B8
	[global::UnityEngine.RPC]
	private void GetClientMove(global::UnityEngine.Vector3 origin, int encoded, ushort stateFlags, global::uLink.NetworkMessageInfo info)
	{
		if (info.sender != base.networkView.owner)
		{
			return;
		}
		global::NetClockTester.ValidityFlags validityFlags = global::NetClockTester.TestValidity(ref this.clockTest, ref info, global::NetCull.sendInterval, global::NetClockTester.ValidityFlags.Valid | global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.OverTimed | global::NetClockTester.ValidityFlags.AheadOfServerTime);
		bool flag;
		if ((validityFlags & ~global::NetClockTester.ValidityFlags.Valid) != (global::NetClockTester.ValidityFlags)0)
		{
			flag = false;
		}
		else
		{
			flag = false;
			if (this.clockTest.Results.Valid >= 0x3E8U)
			{
				this.clockTest.Results = default(global::NetClockTester.Validity);
			}
		}
		int num = (int)(stateFlags & 0x6000);
		if (num != 0)
		{
			if (num != 0x2000)
			{
				if (num == 0x4000)
				{
					bool flag2 = flag;
					bool? flag3 = this.thatsRightPatWeDontNeedComments;
					flag = (flag2 | (flag3 != null && flag3.Value));
					this.thatsRightPatWeDontNeedComments = new bool?(true);
				}
			}
			else
			{
				bool flag4 = flag;
				bool? flag5 = this.thatsRightPatWeDontNeedComments;
				flag = (flag4 | (flag5 != null && !flag5.Value));
				this.thatsRightPatWeDontNeedComments = new bool?(false);
			}
		}
		else
		{
			flag |= (this.thatsRightPatWeDontNeedComments != null);
			this.thatsRightPatWeDontNeedComments = new bool?((base.playerClient.userName.GetHashCode() & 1) == 1);
		}
		stateFlags = (ushort)((int)stateFlags & -0x6001);
		if (!global::NetCull.isServerRunning || info.timestamp <= this.serverLastTimestamp)
		{
			return;
		}
		global::Character idMain = base.idMain;
		double num2 = info.timestamp - this.serverLastTimestamp;
		bool flag6 = num2 < global::NetCull.sendInterval * 0.8999999761581421;
		bool flag7 = info.timestamp > global::NetCull.time + 3.0;
		if (flag6 || flag7)
		{
			this.badPacketCount++;
		}
		if (this.badPacketCount > 0xA)
		{
		}
		this.serverLastTimestamp = info.timestamp;
		global::Angle2 angle = default(global::Angle2);
		angle.encoded = encoded;
		if (base.dead)
		{
			return;
		}
		try
		{
			global::NetCull.VerifyRPC(ref info, false);
		}
		catch (global::NetCull.RPCVerificationSenderException)
		{
			return;
		}
		catch (global::NetCull.RPCVerificationDropException)
		{
			if (!this.clientMoveDropped)
			{
				this.clientMoveDropped = true;
				base.networkView.RPC("ReadClientMove", info.sender, new object[]
				{
					base.origin,
					base.eyesAngles.encoded,
					base.stateFlags,
					(float)(global::NetCull.time - info.timestamp)
				});
			}
			return;
		}
		if (this.clientMoveDropped)
		{
			this.clientMoveDropped = false;
		}
		global::uLink.RPCMode rpcmode = 9;
		global::TruthDetector.ActionTaken actionTaken = idMain.netUser.truthDetector.NoteMoved(ref origin, angle, info.timestamp);
		if (actionTaken == global::TruthDetector.ActionTaken.Kicked)
		{
			return;
		}
		if (actionTaken == global::TruthDetector.ActionTaken.Moved)
		{
			rpcmode = 1;
		}
		idMain.origin = origin;
		idMain.eyesAngles = angle;
		idMain.stateFlags.flags = stateFlags;
		if (base.networkView.viewID != global::uLink.NetworkViewID.unassigned)
		{
			base.networkView.RPC("ReadClientMove", rpcmode, new object[]
			{
				origin,
				angle.encoded,
				stateFlags,
				(float)(global::NetCull.time - info.timestamp)
			});
		}
		this.ServerFrame();
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00011880 File Offset: 0x0000FA80
	[global::UnityEngine.RPC]
	private void ReadClientMove(global::UnityEngine.Vector3 origin, int encoded, ushort stateFlags, float timeAfterServerReceived, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00011884 File Offset: 0x0000FA84
	private void UpdateStateNew(global::UnityEngine.Vector3 origin, global::Angle2 eyesAngles, ushort stateFlags, double timestamp)
	{
		global::Character idMain = base.idMain;
		if (this.firstState)
		{
			this.firstState = false;
			idMain.origin = origin;
			idMain.eyesAngles = eyesAngles;
			idMain.stateFlags.flags = stateFlags;
			return;
		}
		if (base.networkView.isMine)
		{
			idMain.origin = origin;
			idMain.eyesAngles = eyesAngles;
			idMain.stateFlags.flags = stateFlags;
			global::CCMotor ccmotor = base.ccmotor;
			if (ccmotor)
			{
				ccmotor.Teleport(origin);
			}
		}
		else
		{
			global::CharacterInterpolatorBase interpolator = base.interpolator;
			if (interpolator)
			{
				global::IStateInterpolator<global::CharacterStateInterpolatorData> stateInterpolator = interpolator as global::IStateInterpolator<global::CharacterStateInterpolatorData>;
				if (stateInterpolator != null)
				{
					global::CharacterStateInterpolatorData characterStateInterpolatorData;
					characterStateInterpolatorData.origin = origin;
					characterStateInterpolatorData.state.flags = stateFlags;
					characterStateInterpolatorData.eyesAngles = eyesAngles;
					stateInterpolator.SetGoals(ref characterStateInterpolatorData, ref timestamp);
				}
				else
				{
					idMain.stateFlags.flags = stateFlags;
					interpolator.SetGoals(origin, eyesAngles.quat, timestamp);
				}
			}
		}
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00011974 File Offset: 0x0000FB74
	public void ServerFrame()
	{
		global::PlayerClient playerClient = base.playerClient;
		if (playerClient)
		{
			playerClient.hasLastKnownPosition = true;
			playerClient.lastKnownPosition = base.idMain.eyesOrigin;
		}
		float num = global::UnityEngine.Time.time - this.lastServerFrameTime;
		this.lastServerFrameTime = global::UnityEngine.Time.time;
		global::InventoryHolder inventoryHolder = this.inventoryHolder;
		if (inventoryHolder)
		{
			inventoryHolder.ServerFrame();
		}
		if (this.clientVitalsSync)
		{
			this.clientVitalsSync.ServerFrame();
		}
		this._inventory.CraftThink();
		global::Character component = base.GetComponent<global::Character>();
		global::Metabolism component2 = base.GetComponent<global::Metabolism>();
		float hearRadius;
		if (component.stateFlags.movement)
		{
			if (component.stateFlags.crouch)
			{
				component2.SetTargetActivityLevel(0.15f);
				hearRadius = 5f;
			}
			else if (component.stateFlags.sprint)
			{
				component2.SetTargetActivityLevel(0.9f);
				base.AudibleMessage(10f, "HearFootstep", base.transform.position);
				hearRadius = 30f;
			}
			else
			{
				component2.SetTargetActivityLevel(0.4f);
				base.AudibleMessage(5f, "HearFootstep", base.transform.position);
				hearRadius = 20f;
			}
		}
		else
		{
			component2.SetTargetActivityLevel(0f);
			hearRadius = 10f;
		}
		base.AudibleMessage(hearRadius, "Scent", base.idMain.takeDamage);
		global::Radiation local = base.GetLocal<global::Radiation>();
		if (local)
		{
			this.radExposurePerMinute = local.CalculateExposure(true);
			component2.AddRads(this.radExposurePerMinute * (num / 60f));
		}
		if (base.alive && global::WaterLine.Height != 0f && base.transform.position.y <= global::WaterLine.Height)
		{
			global::TakeDamage.Hurt(base.idMain, base.idMain, base.health * 2f, null);
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00011B90 File Offset: 0x0000FD90
	protected void OnEnable()
	{
		this.SetLocalOnlyComponentsEnabled(true);
		global::Facepunch.Cursor.LockCursorManager.IsLocked(true);
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00011BA0 File Offset: 0x0000FDA0
	protected void OnDisable()
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			global::Character idMain = base.idMain;
			if (idMain)
			{
				global::Character character = idMain;
				character.stateFlags.flags = (character.stateFlags.flags & 0x1EB0);
			}
			this.SetLocalOnlyComponentsEnabled(false);
		}
		this.sprinting = false;
		this.exitingSprint = true;
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00011BF8 File Offset: 0x0000FDF8
	private void OnKilled(global::DamageEvent damage)
	{
		global::Vis.Mask traitMask = base.traitMask;
		traitMask[global::Vis.Life.Alive] = false;
		traitMask[global::Vis.Life.Dead] = true;
		base.traitMask = traitMask;
		if (this.deathTransfer)
		{
			this.deathTransfer.NetworkKill(ref damage);
		}
		if (global::Magma.Hooks.PlayerKilled(ref damage))
		{
			global::Inventory inventory;
			global::DropHelper.DropInventoryContents(this.inventory, out inventory);
			if (inventory && global::player.backpackLockTime > 0f)
			{
				global::TimedLockable timedLockable = inventory.gameObject.AddComponent<global::TimedLockable>();
				timedLockable.SetOwner(base.netUser.userID);
				timedLockable.LockFor(global::player.backpackLockTime);
			}
		}
		base.GetComponent<global::AvatarSaveRestore>().ClearAvatar();
		global::IDLocalCharacter.DestroyCharacter(base.idMain);
	}

	// Token: 0x04000316 RID: 790
	private const string kHeadPath = "RustPlayer_Pelvis/RustPlayer_Spine/RustPlayer_Spine1/RustPlayer_Spine2/RustPlayer_Spine4/RustPlayer_Neck1/RustPlayer_Head1";

	// Token: 0x04000317 RID: 791
	private const long clearOnDisableCharacterStateFlags = 0x14FL;

	// Token: 0x04000318 RID: 792
	private const ushort doNotClearOnDisableCharacterStateFlags = 0x1EB0;

	// Token: 0x04000319 RID: 793
	protected const global::Controller.ControllerFlags kControllerFlags = (global::Controller.ControllerFlags)0x20C1;

	// Token: 0x0400031A RID: 794
	private const bool stepMotorHere = true;

	// Token: 0x0400031B RID: 795
	private global::UnityEngine.Vector3 lastFrameVelocity;

	// Token: 0x0400031C RID: 796
	private global::UnityEngine.Vector3 midairStartPos;

	// Token: 0x0400031D RID: 797
	[global::System.NonSerialized]
	private global::CacheRef<global::Inventory> __inventory;

	// Token: 0x0400031E RID: 798
	[global::System.NonSerialized]
	private global::ClientVitalsSync clientVitalsSync;

	// Token: 0x0400031F RID: 799
	[global::System.NonSerialized]
	private global::DeathTransfer deathTransfer;

	// Token: 0x04000320 RID: 800
	[global::System.NonSerialized]
	private double serverLastTimestamp;

	// Token: 0x04000321 RID: 801
	[global::System.NonSerialized]
	protected int badPacketCount;

	// Token: 0x04000322 RID: 802
	[global::System.NonSerialized]
	private bool firstState = true;

	// Token: 0x04000323 RID: 803
	[global::System.NonSerialized]
	private float lastServerFrameTime;

	// Token: 0x04000324 RID: 804
	[global::System.NonSerialized]
	private global::HumanControlConfiguration _controlConfig;

	// Token: 0x04000325 RID: 805
	[global::System.NonSerialized]
	private bool _didControlConfigTest;

	// Token: 0x04000326 RID: 806
	[global::System.NonSerialized]
	private bool? thatsRightPatWeDontNeedComments;

	// Token: 0x04000327 RID: 807
	[global::System.NonSerialized]
	private int timescaleOffCount;

	// Token: 0x04000328 RID: 808
	[global::System.NonSerialized]
	private bool timescaleBanned;

	// Token: 0x04000329 RID: 809
	[global::System.NonSerialized]
	private bool clientMoveDropped;

	// Token: 0x0400032A RID: 810
	[global::System.NonSerialized]
	private float sprintInMulTime = 1f;

	// Token: 0x0400032B RID: 811
	[global::System.NonSerialized]
	private float crouchInMulTime = 1f;

	// Token: 0x0400032C RID: 812
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 server_last_pos = global::UnityEngine.Vector3.zero;

	// Token: 0x0400032D RID: 813
	[global::System.NonSerialized]
	private bool server_was_grounded = true;

	// Token: 0x0400032E RID: 814
	[global::System.NonSerialized]
	private float server_next_fall_damage_time;

	// Token: 0x0400032F RID: 815
	[global::System.NonSerialized]
	private float magnitudeAir;

	// Token: 0x04000330 RID: 816
	[global::System.NonSerialized]
	private bool wasInAir;

	// Token: 0x04000331 RID: 817
	[global::System.NonSerialized]
	private bool onceEngaged;

	// Token: 0x04000332 RID: 818
	[global::System.NonSerialized]
	private float landingSpeedPenaltyTime = float.MaxValue;

	// Token: 0x04000333 RID: 819
	[global::System.NonSerialized]
	private global::NetClockTester clockTest;

	// Token: 0x04000334 RID: 820
	[global::System.NonSerialized]
	private global::UnityEngine.Transform _headBone;

	// Token: 0x04000335 RID: 821
	[global::System.NonSerialized]
	private float radExposurePerMinute;

	// Token: 0x04000336 RID: 822
	[global::System.NonSerialized]
	private bool sprinting;

	// Token: 0x04000337 RID: 823
	[global::System.NonSerialized]
	private bool exitingSprint;

	// Token: 0x04000338 RID: 824
	[global::System.NonSerialized]
	private bool crouching;

	// Token: 0x04000339 RID: 825
	[global::System.NonSerialized]
	private bool exitingCrouch;

	// Token: 0x0400033A RID: 826
	[global::System.NonSerialized]
	private bool wasSprinting;

	// Token: 0x0400033B RID: 827
	[global::System.NonSerialized]
	private float sprintTime;

	// Token: 0x0400033C RID: 828
	[global::System.NonSerialized]
	private float crouchTime;

	// Token: 0x0400033D RID: 829
	[global::System.NonSerialized]
	private global::PlayerProxyTest proxyTest;

	// Token: 0x0400033E RID: 830
	[global::System.NonSerialized]
	private global::PlayerClient instantiatedPlayerClient;

	// Token: 0x020000B5 RID: 181
	public struct InputSample
	{
		// Token: 0x060003AA RID: 938 RVA: 0x00011CB4 File Offset: 0x0000FEB4
		// Note: this type is marked as 'beforefieldinit'.
		static InputSample()
		{
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00011CD4 File Offset: 0x0000FED4
		public bool is_sprinting
		{
			get
			{
				return this.sprint && !this.aim && this.walk != 0f;
			}
		}

		// Token: 0x0400033F RID: 831
		public const string kButtonAim = "Aim";

		// Token: 0x04000340 RID: 832
		public const string kRawYaw = "Mouse X";

		// Token: 0x04000341 RID: 833
		public const string kRawPitch = "Mouse Y";

		// Token: 0x04000342 RID: 834
		public const string kYaw = "Yaw";

		// Token: 0x04000343 RID: 835
		public const string kPitch = "Pitch";

		// Token: 0x04000344 RID: 836
		public const string kButtonUse = "WorldUse";

		// Token: 0x04000345 RID: 837
		public static float MovementScale = 1f;

		// Token: 0x04000346 RID: 838
		public float walk;

		// Token: 0x04000347 RID: 839
		public float strafe;

		// Token: 0x04000348 RID: 840
		public float yaw;

		// Token: 0x04000349 RID: 841
		public float pitch;

		// Token: 0x0400034A RID: 842
		public bool jump;

		// Token: 0x0400034B RID: 843
		public bool crouch;

		// Token: 0x0400034C RID: 844
		public bool sprint;

		// Token: 0x0400034D RID: 845
		public bool aim;

		// Token: 0x0400034E RID: 846
		public bool attack;

		// Token: 0x0400034F RID: 847
		public bool attack2;

		// Token: 0x04000350 RID: 848
		public bool reload;

		// Token: 0x04000351 RID: 849
		public bool inventory;

		// Token: 0x04000352 RID: 850
		public bool lamp;

		// Token: 0x04000353 RID: 851
		public bool laser;

		// Token: 0x04000354 RID: 852
		public bool info__crouchBlocked;

		// Token: 0x04000355 RID: 853
		private static float yawSensitivityJoy = 30f;

		// Token: 0x04000356 RID: 854
		private static float pitchSensitivityJoy = 30f;

		// Token: 0x020000B6 RID: 182
		private static class saved
		{
			// Token: 0x060003AC RID: 940 RVA: 0x00011D00 File Offset: 0x0000FF00
			static saved()
			{
			}

			// Token: 0x060003AD RID: 941 RVA: 0x00011D3C File Offset: 0x0000FF3C
			public static bool GetLamp(bool pressed)
			{
				if (pressed)
				{
					global::HumanController.InputSample.saved.lamp = !global::HumanController.InputSample.saved.lamp;
					global::UnityEngine.PlayerPrefs.SetInt("LAMP", (!global::HumanController.InputSample.saved.lamp) ? 0 : 1);
				}
				return global::HumanController.InputSample.saved.lamp;
			}

			// Token: 0x060003AE RID: 942 RVA: 0x00011D74 File Offset: 0x0000FF74
			public static bool GetLaser(bool pressed)
			{
				if (pressed)
				{
					global::HumanController.InputSample.saved.laser = !global::HumanController.InputSample.saved.laser;
					global::UnityEngine.PlayerPrefs.SetInt("LASER", (!global::HumanController.InputSample.saved.laser) ? 0 : 1);
				}
				return global::HumanController.InputSample.saved.laser;
			}

			// Token: 0x04000357 RID: 855
			public static bool lamp = global::UnityEngine.PlayerPrefs.GetInt("LAMP", 1) != 0;

			// Token: 0x04000358 RID: 856
			public static bool laser = global::UnityEngine.PlayerPrefs.GetInt("LASER", 1) != 0;
		}
	}
}
