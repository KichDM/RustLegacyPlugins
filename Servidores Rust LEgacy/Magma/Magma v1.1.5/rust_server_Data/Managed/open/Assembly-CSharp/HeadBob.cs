using System;
using UnityEngine;

// Token: 0x020005E5 RID: 1509
public sealed class HeadBob : global::UnityEngine.MonoBehaviour, global::ICameraFX
{
	// Token: 0x060030EE RID: 12526 RVA: 0x000BA57C File Offset: 0x000B877C
	public HeadBob()
	{
	}

	// Token: 0x060030EF RID: 12527 RVA: 0x000BA5EC File Offset: 0x000B87EC
	// Note: this type is marked as 'beforefieldinit'.
	static HeadBob()
	{
	}

	// Token: 0x17000A3D RID: 2621
	// (get) Token: 0x060030F0 RID: 12528 RVA: 0x000BA624 File Offset: 0x000B8824
	public float globalScalar
	{
		get
		{
			return this._globalScalar;
		}
	}

	// Token: 0x17000A3E RID: 2622
	// (get) Token: 0x060030F1 RID: 12529 RVA: 0x000BA62C File Offset: 0x000B882C
	public float globalPositionScalar
	{
		get
		{
			return this._globalPositionScalar;
		}
	}

	// Token: 0x17000A3F RID: 2623
	// (get) Token: 0x060030F2 RID: 12530 RVA: 0x000BA634 File Offset: 0x000B8834
	public float globalRotationScalar
	{
		get
		{
			return this._globalRotationScalar;
		}
	}

	// Token: 0x17000A40 RID: 2624
	// (get) Token: 0x060030F3 RID: 12531 RVA: 0x000BA63C File Offset: 0x000B883C
	public double positionScalar
	{
		get
		{
			return global::HeadBob.bob_scale * global::HeadBob.bob_scale_linear * (double)this._globalScalar * (double)this._globalPositionScalar * (double)this._viewModelPositionScalar * (double)this._aimPositionScalar;
		}
	}

	// Token: 0x17000A41 RID: 2625
	// (get) Token: 0x060030F4 RID: 12532 RVA: 0x000BA66C File Offset: 0x000B886C
	public double rotationScalar
	{
		get
		{
			return global::HeadBob.bob_scale * global::HeadBob.bob_scale_angular * (double)this._globalScalar * (double)this._globalRotationScalar * (double)this._viewModelRotationScalar * (double)this._aimRotationScalar;
		}
	}

	// Token: 0x17000A42 RID: 2626
	// (get) Token: 0x060030F5 RID: 12533 RVA: 0x000BA69C File Offset: 0x000B889C
	// (set) Token: 0x060030F6 RID: 12534 RVA: 0x000BA6A4 File Offset: 0x000B88A4
	public float viewModelPositionScalar
	{
		get
		{
			return this._viewModelPositionScalar;
		}
		set
		{
			this._viewModelPositionScalar = value;
		}
	}

	// Token: 0x17000A43 RID: 2627
	// (get) Token: 0x060030F7 RID: 12535 RVA: 0x000BA6B0 File Offset: 0x000B88B0
	// (set) Token: 0x060030F8 RID: 12536 RVA: 0x000BA6B8 File Offset: 0x000B88B8
	public float viewModelRotationScalar
	{
		get
		{
			return this._viewModelRotationScalar;
		}
		set
		{
			this._viewModelRotationScalar = value;
		}
	}

	// Token: 0x17000A44 RID: 2628
	// (get) Token: 0x060030F9 RID: 12537 RVA: 0x000BA6C4 File Offset: 0x000B88C4
	// (set) Token: 0x060030FA RID: 12538 RVA: 0x000BA6CC File Offset: 0x000B88CC
	public float aimPositionScalar
	{
		get
		{
			return this._aimPositionScalar;
		}
		set
		{
			this._aimPositionScalar = value;
		}
	}

	// Token: 0x17000A45 RID: 2629
	// (get) Token: 0x060030FB RID: 12539 RVA: 0x000BA6D8 File Offset: 0x000B88D8
	// (set) Token: 0x060030FC RID: 12540 RVA: 0x000BA6E0 File Offset: 0x000B88E0
	public float aimRotationScalar
	{
		get
		{
			return this._aimRotationScalar;
		}
		set
		{
			this._aimRotationScalar = value;
		}
	}

	// Token: 0x04001AC2 RID: 6850
	public global::BobConfiguration cfg;

	// Token: 0x04001AC3 RID: 6851
	[global::UnityEngine.SerializeField]
	private global::CCMotor _motor;

	// Token: 0x04001AC4 RID: 6852
	[global::UnityEngine.SerializeField]
	private global::CameraMount _mount;

	// Token: 0x04001AC5 RID: 6853
	[global::UnityEngine.SerializeField]
	private float _globalScalar = 1f;

	// Token: 0x04001AC6 RID: 6854
	[global::UnityEngine.SerializeField]
	private float _globalPositionScalar = 1f;

	// Token: 0x04001AC7 RID: 6855
	[global::UnityEngine.SerializeField]
	private float _globalRotationScalar = 1f;

	// Token: 0x04001AC8 RID: 6856
	private static double bob_scale = 1.0;

	// Token: 0x04001AC9 RID: 6857
	private static double bob_scale_linear = 1.0;

	// Token: 0x04001ACA RID: 6858
	private static double bob_scale_angular = 1.0;

	// Token: 0x04001ACB RID: 6859
	private float _viewModelPositionScalar = 1f;

	// Token: 0x04001ACC RID: 6860
	private float _viewModelRotationScalar = 1f;

	// Token: 0x04001ACD RID: 6861
	private float _aimPositionScalar = 1f;

	// Token: 0x04001ACE RID: 6862
	private float _aimRotationScalar = 1f;

	// Token: 0x04001ACF RID: 6863
	public bool simStep = true;

	// Token: 0x04001AD0 RID: 6864
	public bool allowOnEnable = true;

	// Token: 0x04001AD1 RID: 6865
	public bool forceForbidOnDisable;

	// Token: 0x04001AD2 RID: 6866
	public bool allowAntiOutputs;
}
