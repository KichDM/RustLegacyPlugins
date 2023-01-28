using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007CD RID: 1997
public class ViewModel : global::IDRemote, global::Socket.Source, global::Socket.Mapped, global::Socket.Provider
{
	// Token: 0x0600421B RID: 16923 RVA: 0x000F0358 File Offset: 0x000EE558
	public ViewModel()
	{
		this.socketNames = global::ViewModel.defaultSocketNames;
		base..ctor();
	}

	// Token: 0x0600421C RID: 16924 RVA: 0x000F0498 File Offset: 0x000EE698
	// Note: this type is marked as 'beforefieldinit'.
	static ViewModel()
	{
	}

	// Token: 0x0600421D RID: 16925 RVA: 0x000F04D8 File Offset: 0x000EE6D8
	bool global::Socket.Source.GetSocket(string name, out global::Socket socket)
	{
		switch (name)
		{
		case "muzzle":
			socket = this.muzzle;
			return true;
		case "sight":
			socket = this.sight;
			return true;
		case "optics":
			socket = this.optics;
			return true;
		case "pivot1":
			socket = this.pivot;
			return true;
		case "pivot2":
			socket = this.pivot2;
			return true;
		case "bowPivot":
			socket = this.bowPivot;
			return true;
		}
		socket = null;
		return false;
	}

	// Token: 0x0600421E RID: 16926 RVA: 0x000F05C4 File Offset: 0x000EE7C4
	bool global::Socket.Source.ReplaceSocket(string name, global::Socket socket)
	{
		global::Socket.CameraSpace cameraSpace = (global::Socket.CameraSpace)socket;
		switch (name)
		{
		case "muzzle":
			this.muzzle = cameraSpace;
			return true;
		case "sight":
			this.sight = cameraSpace;
			return true;
		case "optics":
			this.optics = cameraSpace;
			return true;
		case "pivot1":
			this.pivot = cameraSpace;
			return true;
		case "pivot2":
			this.pivot2 = cameraSpace;
			return true;
		case "bowPivot":
			this.bowPivot = cameraSpace;
			return true;
		}
		return false;
	}

	// Token: 0x17000C1E RID: 3102
	// (get) Token: 0x0600421F RID: 16927 RVA: 0x000F06AC File Offset: 0x000EE8AC
	global::System.Collections.Generic.IEnumerable<string> global::Socket.Source.SocketNames
	{
		get
		{
			return this.socketNames;
		}
	}

	// Token: 0x17000C1F RID: 3103
	// (get) Token: 0x06004220 RID: 16928 RVA: 0x000F06B4 File Offset: 0x000EE8B4
	int global::Socket.Source.SocketsVersion
	{
		get
		{
			return this.socketVersion;
		}
	}

	// Token: 0x06004221 RID: 16929 RVA: 0x000F06BC File Offset: 0x000EE8BC
	global::Socket.CameraConversion global::Socket.Source.CameraSpaceSetup()
	{
		return global::Socket.CameraConversion.None;
	}

	// Token: 0x06004222 RID: 16930 RVA: 0x000F06C4 File Offset: 0x000EE8C4
	global::System.Type global::Socket.Source.ProxyScriptType(string name)
	{
		return typeof(global::SocketProxy);
	}

	// Token: 0x17000C20 RID: 3104
	// (get) Token: 0x06004223 RID: 16931 RVA: 0x000F06D0 File Offset: 0x000EE8D0
	public global::Socket.Map socketMap
	{
		get
		{
			return this._socketMap.Get<global::ViewModel>(this);
		}
	}

	// Token: 0x06004224 RID: 16932 RVA: 0x000F06E0 File Offset: 0x000EE8E0
	protected void DeleteSocketMap()
	{
		this._socketMap.DeleteBy<global::ViewModel>(this);
	}

	// Token: 0x17000C21 RID: 3105
	// (get) Token: 0x06004225 RID: 16933 RVA: 0x000F06F0 File Offset: 0x000EE8F0
	public global::Character idMain
	{
		get
		{
			return (global::Character)base.idMain;
		}
	}

	// Token: 0x17000C22 RID: 3106
	// (get) Token: 0x06004226 RID: 16934 RVA: 0x000F0700 File Offset: 0x000EE900
	public bool drawCrosshair
	{
		get
		{
			return this.showCrosshairZoom || this.showCrosshairNotZoomed;
		}
	}

	// Token: 0x040022EE RID: 8942
	public const int kCap_PerspectiveNear = 1;

	// Token: 0x040022EF RID: 8943
	public const int kCap_PerspectiveFar = 2;

	// Token: 0x040022F0 RID: 8944
	public const int kCap_PerspectiveFOV = 4;

	// Token: 0x040022F1 RID: 8945
	public const int kCap_PerspectiveAspect = 8;

	// Token: 0x040022F2 RID: 8946
	protected const int kIdleChannel_Idle = 0;

	// Token: 0x040022F3 RID: 8947
	protected const int kIdleChannel_IdleMovement = 1;

	// Token: 0x040022F4 RID: 8948
	protected const int kIdleChannel_Crouch = 2;

	// Token: 0x040022F5 RID: 8949
	protected const int kIdleChannel_CrouchMovement = 3;

	// Token: 0x040022F6 RID: 8950
	protected const int kIdleChannel_Bow = 4;

	// Token: 0x040022F7 RID: 8951
	protected const int kIdleChannel_BowMovement = 5;

	// Token: 0x040022F8 RID: 8952
	protected const int kIdleChannel_Fall = 6;

	// Token: 0x040022F9 RID: 8953
	protected const int kIdleChannel_Slip = 7;

	// Token: 0x040022FA RID: 8954
	protected const int kIdleChannel_Zoom = 8;

	// Token: 0x040022FB RID: 8955
	protected const int kIdleChannelCount = 9;

	// Token: 0x040022FC RID: 8956
	protected const string kIdleChannel_Idle_Name = "idle";

	// Token: 0x040022FD RID: 8957
	protected const string kIdleChannel_IdleMovement_Name = "move";

	// Token: 0x040022FE RID: 8958
	protected const string kIdleChannel_Bow_Name = "bowi";

	// Token: 0x040022FF RID: 8959
	protected const string kIdleChannel_BowMovement_Name = "bowm";

	// Token: 0x04002300 RID: 8960
	protected const string kIdleChannel_Crouch_Name = "dcki";

	// Token: 0x04002301 RID: 8961
	protected const string kIdleChannel_CrouchMovement_Name = "dckm";

	// Token: 0x04002302 RID: 8962
	protected const string kIdleChannel_Fall_Name = "fall";

	// Token: 0x04002303 RID: 8963
	protected const string kIdleChannel_Slip_Name = "slip";

	// Token: 0x04002304 RID: 8964
	protected const string kIdleChannel_Zoom_Name = "zoom";

	// Token: 0x04002305 RID: 8965
	[global::UnityEngine.SerializeField]
	public global::Socket.CameraSpace pivot;

	// Token: 0x04002306 RID: 8966
	[global::UnityEngine.SerializeField]
	public global::Socket.CameraSpace pivot2;

	// Token: 0x04002307 RID: 8967
	[global::UnityEngine.SerializeField]
	public global::Socket.CameraSpace muzzle;

	// Token: 0x04002308 RID: 8968
	[global::UnityEngine.SerializeField]
	public global::Socket.CameraSpace sight;

	// Token: 0x04002309 RID: 8969
	[global::UnityEngine.SerializeField]
	public global::Socket.CameraSpace optics;

	// Token: 0x0400230A RID: 8970
	[global::UnityEngine.SerializeField]
	public global::Socket.CameraSpace bowPivot;

	// Token: 0x0400230B RID: 8971
	protected static readonly string[] defaultSocketNames = new string[]
	{
		"muzzle",
		"sight",
		"optics",
		"pivot1",
		"pivot2",
		"bowPivot"
	};

	// Token: 0x0400230C RID: 8972
	[global::System.NonSerialized]
	protected global::System.Collections.Generic.IEnumerable<string> socketNames;

	// Token: 0x0400230D RID: 8973
	[global::System.NonSerialized]
	protected int socketVersion;

	// Token: 0x0400230E RID: 8974
	[global::System.NonSerialized]
	private global::Socket.Map.Member _socketMap;

	// Token: 0x0400230F RID: 8975
	private global::UnityEngine.Vector3 originalRootOffset;

	// Token: 0x04002310 RID: 8976
	private global::UnityEngine.Quaternion originalRootRotation;

	// Token: 0x04002311 RID: 8977
	private bool flipped;

	// Token: 0x04002312 RID: 8978
	private global::System.Collections.Generic.Dictionary<global::Socket, global::UnityEngine.Transform> proxies;

	// Token: 0x04002313 RID: 8979
	private bool madeProxyDict;

	// Token: 0x04002314 RID: 8980
	public int caps;

	// Token: 0x04002315 RID: 8981
	public float perspectiveNearOverride = 0.1f;

	// Token: 0x04002316 RID: 8982
	public float perspectiveFarOverride = 25f;

	// Token: 0x04002317 RID: 8983
	public float perspectiveFOVOverride = 60f;

	// Token: 0x04002318 RID: 8984
	public float perspectiveAspectOverride = 1f;

	// Token: 0x04002319 RID: 8985
	public float lazyAngle = 5f;

	// Token: 0x0400231A RID: 8986
	public float zoomFieldOfView = 40f;

	// Token: 0x0400231B RID: 8987
	public global::UnityEngine.AnimationCurve zoomCurve;

	// Token: 0x0400231C RID: 8988
	public global::UnityEngine.Vector3 zoomOffset;

	// Token: 0x0400231D RID: 8989
	public global::UnityEngine.Vector3 zoomRotate;

	// Token: 0x0400231E RID: 8990
	public global::UnityEngine.Vector3 offset;

	// Token: 0x0400231F RID: 8991
	public global::UnityEngine.Vector3 rotate;

	// Token: 0x04002320 RID: 8992
	public global::UnityEngine.Transform root;

	// Token: 0x04002321 RID: 8993
	public global::UnityEngine.Animation animation;

	// Token: 0x04002322 RID: 8994
	public global::UnityEngine.Texture crosshairTexture;

	// Token: 0x04002323 RID: 8995
	public global::UnityEngine.Texture dotTexture;

	// Token: 0x04002324 RID: 8996
	public float zoomInDuration = 0.5f;

	// Token: 0x04002325 RID: 8997
	public float zoomOutDuration = 0.4f;

	// Token: 0x04002326 RID: 8998
	public bool showCrosshairZoom;

	// Token: 0x04002327 RID: 8999
	public bool showCrosshairNotZoomed = true;

	// Token: 0x04002328 RID: 9000
	public global::UnityEngine.Color crosshairColor = global::UnityEngine.Color.white;

	// Token: 0x04002329 RID: 9001
	public global::UnityEngine.Color crosshairOutline = global::UnityEngine.Color.black;

	// Token: 0x0400232A RID: 9002
	public global::UnityEngine.LayerMask aimMask;

	// Token: 0x0400232B RID: 9003
	public global::UnityEngine.AnimationCurve headBobOffsetScale;

	// Token: 0x0400232C RID: 9004
	public global::UnityEngine.AnimationCurve headBobRotationScale;

	// Token: 0x0400232D RID: 9005
	public bool barrelAiming = true;

	// Token: 0x0400232E RID: 9006
	public bool barrelWhileZoom;

	// Token: 0x0400232F RID: 9007
	public bool barrelWhileBowing;

	// Token: 0x04002330 RID: 9008
	public global::UnityEngine.Vector3 barrelPivot;

	// Token: 0x04002331 RID: 9009
	public global::UnityEngine.Vector2 barrelRotation;

	// Token: 0x04002332 RID: 9010
	public float barrelLimit;

	// Token: 0x04002333 RID: 9011
	public float noHitPlane = 20f;

	// Token: 0x04002334 RID: 9012
	public float barrelAngleSmoothDamp = 0.01f;

	// Token: 0x04002335 RID: 9013
	public float barrelAngleMaxSpeed = float.PositiveInfinity;

	// Token: 0x04002336 RID: 9014
	public float barrelLimitOffsetFactor = 1f;

	// Token: 0x04002337 RID: 9015
	public float barrelLimitPivotFactor;

	// Token: 0x04002338 RID: 9016
	public bool bowAllowed;

	// Token: 0x04002339 RID: 9017
	public global::UnityEngine.Vector3 bowOffsetPoint;

	// Token: 0x0400233A RID: 9018
	public global::UnityEngine.Vector3 bowOffsetAngles;

	// Token: 0x0400233B RID: 9019
	public global::UnityEngine.AnimationCurve bowCurve = global::UnityEngine.AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x0400233C RID: 9020
	public bool bowCurveIs01Fraction;

	// Token: 0x0400233D RID: 9021
	public float bowEnterDuration = 1f;

	// Token: 0x0400233E RID: 9022
	public float bowExitDuration = 1f;

	// Token: 0x0400233F RID: 9023
	private float bowTime;

	// Token: 0x04002340 RID: 9024
	public global::UnityEngine.AnimationCurve zoomPunch;

	// Token: 0x04002341 RID: 9025
	public float punchScalar = 1f;

	// Token: 0x04002342 RID: 9026
	private float punchTime = -2000f;

	// Token: 0x04002343 RID: 9027
	private float zoomPunchValue;

	// Token: 0x04002344 RID: 9028
	public string fireAnimName = "fire_1";

	// Token: 0x04002345 RID: 9029
	public string deployAnimName = "deploy";

	// Token: 0x04002346 RID: 9030
	public string reloadAnimName = "reload";

	// Token: 0x04002347 RID: 9031
	public float fireAnimScaleSpeed = 1f;

	// Token: 0x04002348 RID: 9032
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ResidualField idleFrame;

	// Token: 0x04002349 RID: 9033
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField idleChannel;

	// Token: 0x0400234A RID: 9034
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField movementIdleChannel;

	// Token: 0x0400234B RID: 9035
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField bowChannel;

	// Token: 0x0400234C RID: 9036
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField bowMovementChannel;

	// Token: 0x0400234D RID: 9037
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField crouchChannel;

	// Token: 0x0400234E RID: 9038
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField crouchMovementChannel;

	// Token: 0x0400234F RID: 9039
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField fallChannel;

	// Token: 0x04002350 RID: 9040
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField slipChannel;

	// Token: 0x04002351 RID: 9041
	[global::UnityEngine.SerializeField]
	protected global::AnimationBlender.ChannelField zoomChannel;

	// Token: 0x04002352 RID: 9042
	[global::System.NonSerialized]
	protected global::AnimationBlender.Mixer idleMixer;

	// Token: 0x04002353 RID: 9043
	[global::System.NonSerialized]
	public global::ItemRepresentation itemRep;

	// Token: 0x04002354 RID: 9044
	[global::System.NonSerialized]
	public global::IHeldItem item;

	// Token: 0x04002355 RID: 9045
	[global::System.NonSerialized]
	private global::Angle2 lastLook;

	// Token: 0x04002356 RID: 9046
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.SkinnedMeshRenderer[] builtinRenderers;

	// Token: 0x04002357 RID: 9047
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$mapC;

	// Token: 0x04002358 RID: 9048
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$mapD;
}
