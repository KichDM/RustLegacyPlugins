using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000060 RID: 96
public class Radiation : global::IDLocalCharacter
{
	// Token: 0x060002B7 RID: 695 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
	public Radiation()
	{
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
	public void AddRadiationZone(global::RadiationZone zone)
	{
		if (zone.CanAddToRadiation(this))
		{
			global::System.Collections.Generic.List<global::RadiationZone> list;
			if ((list = this.radiationZones) == null)
			{
				list = (this.radiationZones = new global::System.Collections.Generic.List<global::RadiationZone>());
			}
			list.Add(zone);
		}
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x0000DB34 File Offset: 0x0000BD34
	public void RemoveRadiationZone(global::RadiationZone zone)
	{
		if (this.radiationZones != null && this.radiationZones.Remove(zone))
		{
			zone.RemoveFromRadiation(this);
		}
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0000DB68 File Offset: 0x0000BD68
	public float CalculateExposure(bool countArmor)
	{
		if (this.radiationZones == null || this.radiationZones.Count == 0)
		{
			return 0f;
		}
		global::UnityEngine.Vector3 origin = base.origin;
		float num = 0f;
		foreach (global::RadiationZone radiationZone in this.radiationZones)
		{
			num += radiationZone.GetExposureForPos(origin);
		}
		if (countArmor)
		{
			global::HumanBodyTakeDamage humanBodyTakeDamage = base.takeDamage as global::HumanBodyTakeDamage;
			if (humanBodyTakeDamage)
			{
				float armorValue = humanBodyTakeDamage.GetArmorValue(4);
				if (armorValue > 0f)
				{
					num *= 1f - global::UnityEngine.Mathf.Clamp(armorValue / 200f, 0f, 1f);
				}
			}
		}
		return num;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0000DC58 File Offset: 0x0000BE58
	public float GetRadExposureScalar(float exposure)
	{
		return global::UnityEngine.Mathf.Clamp01(exposure / 1000f);
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0000DC68 File Offset: 0x0000BE68
	private void OnDestroy()
	{
		if (this.radiationZones != null)
		{
			foreach (global::RadiationZone radiationZone in this.radiationZones)
			{
				if (radiationZone)
				{
					radiationZone.RemoveFromRadiation(this);
				}
			}
			this.radiationZones = null;
		}
	}

	// Token: 0x040001DF RID: 479
	[global::System.NonSerialized]
	private global::System.Collections.Generic.List<global::RadiationZone> radiationZones;
}
