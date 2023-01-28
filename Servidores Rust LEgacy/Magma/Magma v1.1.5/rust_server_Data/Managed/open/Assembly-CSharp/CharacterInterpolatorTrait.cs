using System;
using UnityEngine;

// Token: 0x02000133 RID: 307
public class CharacterInterpolatorTrait : global::CharacterTrait
{
	// Token: 0x0600079E RID: 1950 RVA: 0x000210FC File Offset: 0x0001F2FC
	public CharacterInterpolatorTrait()
	{
	}

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x0600079F RID: 1951 RVA: 0x00021118 File Offset: 0x0001F318
	public string interpolatorComponentTypeName
	{
		get
		{
			return this._interpolatorComponentTypeName;
		}
	}

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00021120 File Offset: 0x0001F320
	public int bufferCapacity
	{
		get
		{
			return this._bufferCapacity;
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00021128 File Offset: 0x0001F328
	public bool allowExtrapolation
	{
		get
		{
			return this._allowExtrapolation;
		}
	}

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00021130 File Offset: 0x0001F330
	public float allowableTimeSpan
	{
		get
		{
			return this._allowableTimeSpan;
		}
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00021138 File Offset: 0x0001F338
	public virtual global::Interpolator AddInterpolator(global::IDMain main)
	{
		if (string.IsNullOrEmpty(this._interpolatorComponentTypeName))
		{
			return null;
		}
		global::UnityEngine.Component component = main.gameObject.AddComponent(this._interpolatorComponentTypeName);
		global::Interpolator interpolator = component as global::Interpolator;
		if (interpolator)
		{
			interpolator.idMain = main;
			return interpolator;
		}
		global::UnityEngine.Debug.LogError(this._interpolatorComponentTypeName + " is not a interpolator");
		global::UnityEngine.Object.Destroy(component);
		return null;
	}

	// Token: 0x04000603 RID: 1539
	[global::UnityEngine.SerializeField]
	private string _interpolatorComponentTypeName;

	// Token: 0x04000604 RID: 1540
	[global::UnityEngine.SerializeField]
	private int _bufferCapacity = -1;

	// Token: 0x04000605 RID: 1541
	[global::UnityEngine.SerializeField]
	private bool _allowExtrapolation;

	// Token: 0x04000606 RID: 1542
	[global::UnityEngine.SerializeField]
	private float _allowableTimeSpan = 0.1f;
}
