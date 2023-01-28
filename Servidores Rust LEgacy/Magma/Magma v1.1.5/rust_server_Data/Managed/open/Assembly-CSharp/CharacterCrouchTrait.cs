using System;
using UnityEngine;

// Token: 0x0200012C RID: 300
public class CharacterCrouchTrait : global::CharacterTrait
{
	// Token: 0x06000763 RID: 1891 RVA: 0x000203D0 File Offset: 0x0001E5D0
	public CharacterCrouchTrait()
	{
	}

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x06000764 RID: 1892 RVA: 0x00020454 File Offset: 0x0001E654
	public global::UnityEngine.AnimationCurve crouchCurve
	{
		get
		{
			return this._crouchCurve;
		}
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x06000765 RID: 1893 RVA: 0x0002045C File Offset: 0x0001E65C
	public float crouchToSpeedFraction
	{
		get
		{
			return this._crouchToSpeedFraction;
		}
	}

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x06000766 RID: 1894 RVA: 0x00020464 File Offset: 0x0001E664
	private float crouchSpeedBase
	{
		get
		{
			global::UnityEngine.Keyframe keyframe = this._crouchCurve[0];
			global::UnityEngine.Keyframe keyframe2 = this._crouchCurve[this._crouchCurve.length - 1];
			float num = keyframe2.value - keyframe.value;
			float num2 = keyframe2.time - keyframe.time;
			return num / num2;
		}
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x06000767 RID: 1895 RVA: 0x000204BC File Offset: 0x0001E6BC
	public float crouchOutSpeed
	{
		get
		{
			return global::UnityEngine.Mathf.Abs(this.crouchSpeedBase);
		}
	}

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x06000768 RID: 1896 RVA: 0x000204CC File Offset: 0x0001E6CC
	public float crouchInSpeed
	{
		get
		{
			return -global::UnityEngine.Mathf.Abs(this.crouchSpeedBase * this._crouchToSpeedFraction);
		}
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x000204E4 File Offset: 0x0001E6E4
	public bool IsCrouching(float minHeight, float maxHeight, float currentHeight)
	{
		return global::UnityEngine.Mathf.InverseLerp(minHeight, maxHeight, currentHeight) <= this._maxCrouchFraction;
	}

	// Token: 0x040005E4 RID: 1508
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _crouchCurve = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
	{
		new global::UnityEngine.Keyframe(0f, 0f, 0f, 0f),
		new global::UnityEngine.Keyframe(0.55f, -0.55f, 0f, 0f)
	});

	// Token: 0x040005E5 RID: 1509
	[global::UnityEngine.SerializeField]
	private float _crouchToSpeedFraction = 1.3f;

	// Token: 0x040005E6 RID: 1510
	[global::UnityEngine.SerializeField]
	private float _maxCrouchFraction = 0.9f;
}
