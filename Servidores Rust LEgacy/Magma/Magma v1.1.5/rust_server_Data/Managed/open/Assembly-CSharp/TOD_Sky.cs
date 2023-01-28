using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000999 RID: 2457
[global::UnityEngine.ExecuteInEditMode]
public class TOD_Sky : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060052EC RID: 21228 RVA: 0x00159FEC File Offset: 0x001581EC
	public TOD_Sky()
	{
	}

	// Token: 0x060052ED RID: 21229 RVA: 0x0015A004 File Offset: 0x00158204
	internal global::UnityEngine.Vector3 OrbitalToUnity(float radius, float theta, float phi)
	{
		float num = global::UnityEngine.Mathf.Sin(theta);
		float num2 = global::UnityEngine.Mathf.Cos(theta);
		float num3 = global::UnityEngine.Mathf.Sin(phi);
		float num4 = global::UnityEngine.Mathf.Cos(phi);
		global::UnityEngine.Vector3 result;
		result.z = radius * num * num4;
		result.y = radius * num2;
		result.x = radius * num * num3;
		return result;
	}

	// Token: 0x060052EE RID: 21230 RVA: 0x0015A054 File Offset: 0x00158254
	internal global::UnityEngine.Vector3 OrbitalToLocal(float theta, float phi)
	{
		float num = global::UnityEngine.Mathf.Sin(theta);
		float y = global::UnityEngine.Mathf.Cos(theta);
		float num2 = global::UnityEngine.Mathf.Sin(phi);
		float num3 = global::UnityEngine.Mathf.Cos(phi);
		global::UnityEngine.Vector3 result;
		result.z = num * num3;
		result.y = y;
		result.x = num * num2;
		return result;
	}

	// Token: 0x060052EF RID: 21231 RVA: 0x0015A09C File Offset: 0x0015829C
	internal global::UnityEngine.Color SampleAtmosphere(global::UnityEngine.Vector3 direction, bool clampAlpha = true)
	{
		direction = this.Components.DomeTransform.InverseTransformDirection(direction);
		float horizonOffset = this.World.HorizonOffset;
		float p = this.Atmosphere.Contrast * 0.45454544f;
		float haziness = this.Atmosphere.Haziness;
		float fogginess = this.Atmosphere.Fogginess;
		global::UnityEngine.Color sunColor = this.SunColor;
		global::UnityEngine.Color moonColor = this.MoonColor;
		global::UnityEngine.Color moonHaloColor = this.MoonHaloColor;
		global::UnityEngine.Color cloudColor = this.CloudColor;
		global::UnityEngine.Color additiveColor = this.AdditiveColor;
		global::UnityEngine.Vector3 vector = this.Components.DomeTransform.InverseTransformDirection(this.SunDirection);
		global::UnityEngine.Vector3 vector2 = this.Components.DomeTransform.InverseTransformDirection(this.MoonDirection);
		global::UnityEngine.Vector3 vector3 = this.opticalDepth;
		global::UnityEngine.Vector3 vector4 = this.oneOverBeta;
		global::UnityEngine.Vector3 vector5 = this.betaRayleigh;
		global::UnityEngine.Vector3 vector6 = this.betaRayleighTheta;
		global::UnityEngine.Vector3 vector7 = this.betaMie;
		global::UnityEngine.Vector3 vector8 = this.betaMieTheta;
		global::UnityEngine.Vector3 vector9 = this.betaMiePhase;
		global::UnityEngine.Vector3 vector10 = this.betaNight;
		global::UnityEngine.Color color = global::UnityEngine.Color.black;
		float num = global::UnityEngine.Mathf.Max(0f, global::UnityEngine.Vector3.Dot(-direction, vector));
		float num2 = global::UnityEngine.Mathf.Clamp(direction.y + horizonOffset, 0.001f, 1f);
		float num3 = global::UnityEngine.Mathf.Pow(num2, haziness);
		float num4 = (1f - num3) * 190000f;
		float num5 = num4 + num3 * (vector3.x - num4);
		float num6 = num4 + num3 * (vector3.y - num4);
		float num7 = 1f + num * num;
		global::UnityEngine.Vector3 vector11 = vector5 * num5 + vector7 * num6;
		global::UnityEngine.Vector3 vector12 = vector6 + vector8 / global::UnityEngine.Mathf.Pow(vector9.x - vector9.y * num, 1.5f);
		float r = sunColor.r;
		float g = sunColor.g;
		float b = sunColor.b;
		float r2 = moonColor.r;
		float g2 = moonColor.g;
		float b2 = moonColor.b;
		float num8 = global::UnityEngine.Mathf.Exp(-vector11.x);
		float num9 = global::UnityEngine.Mathf.Exp(-vector11.y);
		float num10 = global::UnityEngine.Mathf.Exp(-vector11.z);
		float num11 = num7 * vector12.x * vector4.x;
		float num12 = num7 * vector12.y * vector4.y;
		float num13 = num7 * vector12.z * vector4.z;
		float x = vector10.x;
		float y = vector10.y;
		float z = vector10.z;
		color.r = (1f - num8) * (r * num11 + r2 * x);
		color.g = (1f - num9) * (g * num12 + g2 * y);
		color.b = (1f - num10) * (b * num13 + b2 * z);
		color.a = 10f * this.Max3(color.r, color.g, color.b);
		color += moonHaloColor * global::UnityEngine.Mathf.Pow(global::UnityEngine.Mathf.Max(0f, global::UnityEngine.Vector3.Dot(vector2, -direction)), 10f);
		color += additiveColor;
		color.r = global::UnityEngine.Mathf.Lerp(color.r, cloudColor.r, fogginess);
		color.g = global::UnityEngine.Mathf.Lerp(color.g, cloudColor.g, fogginess);
		color.b = global::UnityEngine.Mathf.Lerp(color.b, cloudColor.b, fogginess);
		color.a += fogginess;
		if (clampAlpha)
		{
			color.a = global::UnityEngine.Mathf.Clamp01(color.a);
		}
		color = this.PowRGBA(color, p);
		return color;
	}

	// Token: 0x060052F0 RID: 21232 RVA: 0x0015A45C File Offset: 0x0015865C
	private void SetupScattering()
	{
		float num = 0.001f + this.Atmosphere.RayleighMultiplier * this.Atmosphere.ScatteringColor.r;
		float num2 = 0.001f + this.Atmosphere.RayleighMultiplier * this.Atmosphere.ScatteringColor.g;
		float num3 = 0.001f + this.Atmosphere.RayleighMultiplier * this.Atmosphere.ScatteringColor.b;
		this.betaRayleigh.x = 5.8E-06f * num;
		this.betaRayleigh.y = 1.35E-05f * num2;
		this.betaRayleigh.z = 3.31E-05f * num3;
		this.betaRayleighTheta.x = 0.000116f * num * 0.059683103f;
		this.betaRayleighTheta.y = 0.00027f * num2 * 0.059683103f;
		this.betaRayleighTheta.z = 0.00066200003f * num3 * 0.059683103f;
		this.opticalDepth.x = 8000f * global::UnityEngine.Mathf.Exp(-this.World.ViewerHeight * 50000f / 8000f);
		float num4 = 0.001f + this.Atmosphere.MieMultiplier * this.Atmosphere.ScatteringColor.r;
		float num5 = 0.001f + this.Atmosphere.MieMultiplier * this.Atmosphere.ScatteringColor.g;
		float num6 = 0.001f + this.Atmosphere.MieMultiplier * this.Atmosphere.ScatteringColor.b;
		float directionality = this.Atmosphere.Directionality;
		float num7 = 0.23873241f * (1f - directionality * directionality) / (2f + directionality * directionality);
		this.betaMie.x = 2E-06f * num4;
		this.betaMie.y = 2E-06f * num5;
		this.betaMie.z = 2E-06f * num6;
		this.betaMieTheta.x = 4E-05f * num4 * num7;
		this.betaMieTheta.y = 4E-05f * num5 * num7;
		this.betaMieTheta.z = 4E-05f * num6 * num7;
		this.betaMiePhase.x = 1f + directionality * directionality;
		this.betaMiePhase.y = 2f * directionality;
		this.opticalDepth.y = 1200f * global::UnityEngine.Mathf.Exp(-this.World.ViewerHeight * 50000f / 1200f);
		this.oneOverBeta = this.Inverse(this.betaMie + this.betaRayleigh);
		this.betaNight = global::UnityEngine.Vector3.Scale(this.betaRayleighTheta + this.betaMieTheta / global::UnityEngine.Mathf.Pow(this.betaMiePhase.x, 1.5f), this.oneOverBeta);
	}

	// Token: 0x060052F1 RID: 21233 RVA: 0x0015A74C File Offset: 0x0015894C
	private void SetupSunAndMoon()
	{
		float num = 0.017453292f * this.Cycle.Latitude;
		float num2 = global::UnityEngine.Mathf.Sin(num);
		float num3 = global::UnityEngine.Mathf.Cos(num);
		float longitude = this.Cycle.Longitude;
		float num4 = (float)(0x16F * this.Cycle.Year - 7 * (this.Cycle.Year + (this.Cycle.Month + 9) / 0xC) / 4 + 0x113 * this.Cycle.Month / 9 + this.Cycle.Day - 0xB25A2);
		float num5 = this.Cycle.Hour - this.Cycle.UTC;
		float num6 = 23.4393f - 3.563E-07f * num4;
		float num7 = 0.017453292f * num6;
		float num8 = global::UnityEngine.Mathf.Sin(num7);
		float num9 = global::UnityEngine.Mathf.Cos(num7);
		float num10 = 282.9404f + 4.70935E-05f * num4;
		float num11 = 0.016709f - 1.151E-09f * num4;
		float num12 = 356.047f + 0.98560023f * num4;
		float num13 = 0.017453292f * num12;
		float num14 = global::UnityEngine.Mathf.Sin(num13);
		float num15 = global::UnityEngine.Mathf.Cos(num13);
		float num16 = num12 + num11 * 57.29578f * num14 * (1f + num11 * num15);
		float num17 = 0.017453292f * num16;
		float num18 = global::UnityEngine.Mathf.Sin(num17);
		float num19 = global::UnityEngine.Mathf.Cos(num17);
		float num20 = num19 - num11;
		float num21 = num18 * global::UnityEngine.Mathf.Sqrt(1f - num11 * num11);
		float num22 = 57.29578f * global::UnityEngine.Mathf.Atan2(num21, num20);
		float num23 = global::UnityEngine.Mathf.Sqrt(num20 * num20 + num21 * num21);
		float num24 = num22 + num10;
		float num25 = 0.017453292f * num24;
		float num26 = global::UnityEngine.Mathf.Sin(num25);
		float num27 = global::UnityEngine.Mathf.Cos(num25);
		float num28 = num23 * num27;
		float num29 = num23 * num26;
		float num30 = num28;
		float num31 = num29 * num9;
		float num32 = num29 * num8;
		float num33 = global::UnityEngine.Mathf.Atan2(num31, num30);
		float num34 = 57.29578f * num33;
		float num35 = global::UnityEngine.Mathf.Atan2(num32, global::UnityEngine.Mathf.Sqrt(num30 * num30 + num31 * num31));
		float num36 = global::UnityEngine.Mathf.Sin(num35);
		float num37 = global::UnityEngine.Mathf.Cos(num35);
		float num38 = num22 + num10 + 180f;
		float num39 = num38 + num5 * 15f;
		float num40 = num39 + longitude;
		float num41 = num40 - num34;
		float num42 = 0.017453292f * num41;
		float num43 = global::UnityEngine.Mathf.Sin(num42);
		float num44 = global::UnityEngine.Mathf.Cos(num42);
		float num45 = num44 * num37;
		float num46 = num43 * num37;
		float num47 = num36;
		float num48 = num45 * num2 - num47 * num3;
		float num49 = num46;
		float num50 = num45 * num3 + num47 * num2;
		float num51 = global::UnityEngine.Mathf.Atan2(num49, num48) + 3.1415927f;
		float num52 = global::UnityEngine.Mathf.Atan2(num50, global::UnityEngine.Mathf.Sqrt(num48 * num48 + num49 * num49));
		float num53 = 1.5707964f - num52;
		float phi = num51;
		global::UnityEngine.Vector3 localPosition = this.OrbitalToLocal(num53, phi);
		this.Components.SunTransform.localPosition = localPosition;
		this.Components.SunTransform.LookAt(this.Components.DomeTransform.position, this.Components.SunTransform.up);
		if (this.Components.CameraTransform != null)
		{
			global::UnityEngine.Vector3 eulerAngles = this.Components.CameraTransform.rotation.eulerAngles;
			global::UnityEngine.Vector3 localEulerAngles = this.Components.SunTransform.localEulerAngles;
			localEulerAngles.z = 2f * global::UnityEngine.Time.time + global::UnityEngine.Mathf.Abs(eulerAngles.x) + global::UnityEngine.Mathf.Abs(eulerAngles.y) + global::UnityEngine.Mathf.Abs(eulerAngles.z);
			this.Components.SunTransform.localEulerAngles = localEulerAngles;
		}
		global::UnityEngine.Vector3 localPosition2 = this.OrbitalToLocal(num53 + 3.1415927f, phi);
		this.Components.MoonTransform.localPosition = localPosition2;
		this.Components.MoonTransform.LookAt(this.Components.DomeTransform.position, this.Components.MoonTransform.up);
		float num54 = 4f * global::UnityEngine.Mathf.Tan(0.008726646f * this.Day.SunMeshSize);
		float num55 = 2f * num54;
		global::UnityEngine.Vector3 localScale;
		localScale..ctor(num55, num55, num55);
		this.Components.SunTransform.localScale = localScale;
		float num56 = 2f * global::UnityEngine.Mathf.Tan(0.008726646f * this.Night.MoonMeshSize);
		float num57 = 2f * num56;
		global::UnityEngine.Vector3 localScale2;
		localScale2..ctor(num57, num57, num57);
		this.Components.MoonTransform.localScale = localScale2;
		this.SunZenith = 57.29578f * num53;
		this.MoonZenith = global::UnityEngine.Mathf.PingPong(this.SunZenith + 180f, 180f);
		bool enabled = this.Components.SunTransform.localPosition.y > -0.5f;
		bool enabled2 = this.Components.MoonTransform.localPosition.y > -0.1f;
		bool enabled3 = this.SampleAtmosphere(global::UnityEngine.Vector3.up, false).a < 1.1f;
		bool enabled4 = this.Clouds.Density > 0f;
		this.Components.SunRenderer.enabled = enabled;
		this.Components.MoonRenderer.enabled = enabled2;
		this.Components.SpaceRenderer.enabled = enabled3;
		this.Components.CloudRenderer.enabled = enabled4;
		this.SetupLightSource(num53, phi);
	}

	// Token: 0x060052F2 RID: 21234 RVA: 0x0015ACC4 File Offset: 0x00158EC4
	private void SetupLightSource(float theta, float phi)
	{
		float num = global::UnityEngine.Mathf.Cos(global::UnityEngine.Mathf.Pow(theta / 6.2831855f, 2f - this.Light.Falloff) * 2f * 3.1415927f);
		float num2 = global::UnityEngine.Mathf.Sqrt(501264f * num * num + 1416f + 1f) - 708f * num;
		float num3 = this.Day.SunLightColor.r;
		float num4 = this.Day.SunLightColor.g;
		float num5 = this.Day.SunLightColor.b;
		float num6 = this.Components.LightSource.intensity / global::UnityEngine.Mathf.Max(this.Day.SunLightIntensity, this.Night.MoonLightIntensity);
		num3 *= global::UnityEngine.Mathf.Exp(-0.008735f * global::UnityEngine.Mathf.Pow(0.68f, -4.08f * num2));
		num4 *= global::UnityEngine.Mathf.Exp(-0.008735f * global::UnityEngine.Mathf.Pow(0.55f, -4.08f * num2));
		num5 *= global::UnityEngine.Mathf.Exp(-0.008735f * global::UnityEngine.Mathf.Pow(0.44f, -4.08f * num2));
		this.LerpValue = global::UnityEngine.Mathf.Clamp01(1.1f * this.Max3(num3, num4, num5));
		float r = this.Night.MoonLightColor.r;
		float g = this.Night.MoonLightColor.g;
		float b = this.Night.MoonLightColor.b;
		float num7 = this.Day.SunLightColor.r * global::UnityEngine.Mathf.Lerp(1f, num3, this.Light.Coloring);
		float num8 = this.Day.SunLightColor.g * global::UnityEngine.Mathf.Lerp(1f, num4, this.Light.Coloring);
		float num9 = this.Day.SunLightColor.b * global::UnityEngine.Mathf.Lerp(1f, num5, this.Light.Coloring);
		float num10 = this.Day.SunShaftColor.r * global::UnityEngine.Mathf.Lerp(1f, num3, this.Light.ShaftColoring);
		float num11 = this.Day.SunShaftColor.g * global::UnityEngine.Mathf.Lerp(1f, num4, this.Light.ShaftColoring);
		float num12 = this.Day.SunShaftColor.b * global::UnityEngine.Mathf.Lerp(1f, num5, this.Light.ShaftColoring);
		global::UnityEngine.Color color;
		color..ctor(r, g, b, num6);
		global::UnityEngine.Color color2;
		color2..ctor(num7, num8, num9, num6);
		global::UnityEngine.Color color3 = global::UnityEngine.Color.Lerp(color, color2, this.Max3(color2.r, color2.g, color2.b));
		this.SunShaftColor = new global::UnityEngine.Color(num10, num11, num12, num6);
		float num13 = global::UnityEngine.Mathf.Lerp(this.Night.AmbientIntensity, this.Day.AmbientIntensity, this.LerpValue);
		this.AmbientColor = new global::UnityEngine.Color(color3.r * num13, color3.g * num13, color3.b * num13, 1f);
		this.SunColor = this.Atmosphere.Brightness * this.Day.SkyMultiplier * global::UnityEngine.Mathf.Lerp(1f, 0.1f, global::UnityEngine.Mathf.Sqrt(this.SunZenith / 90f) - 0.25f) * global::UnityEngine.Color.Lerp(this.Day.SunLightColor * this.LerpValue, new global::UnityEngine.Color(num3, num4, num5, num6), this.Light.SkyColoring);
		this.SunColor = new global::UnityEngine.Color(this.SunColor.r, this.SunColor.g, this.SunColor.b, this.LerpValue);
		this.MoonColor = (1f - this.LerpValue) * 0.5f * this.Atmosphere.Brightness * this.Night.SkyMultiplier * this.Night.MoonLightColor;
		this.MoonColor = new global::UnityEngine.Color(this.MoonColor.r, this.MoonColor.g, this.MoonColor.b, 1f - this.LerpValue);
		global::UnityEngine.Color moonHaloColor = (1f - this.LerpValue) * (1f - global::UnityEngine.Mathf.Abs(this.Cycle.MoonPhase)) * this.Atmosphere.Brightness * this.Night.MoonHaloColor;
		moonHaloColor.r *= moonHaloColor.a;
		moonHaloColor.g *= moonHaloColor.a;
		moonHaloColor.b *= moonHaloColor.a;
		moonHaloColor.a = this.Max3(moonHaloColor.r, moonHaloColor.g, moonHaloColor.b);
		this.MoonHaloColor = moonHaloColor;
		global::UnityEngine.Color color4 = global::UnityEngine.Color.Lerp(this.MoonColor, this.SunColor, this.LerpValue);
		float num14 = global::UnityEngine.Mathf.Lerp(this.Night.CloudMultiplier, this.Day.CloudMultiplier, this.LerpValue);
		float num15 = (color4.r + color4.g + color4.b) / 3f;
		this.CloudColor = num14 * 1.25f * this.Clouds.Brightness * global::UnityEngine.Color.Lerp(new global::UnityEngine.Color(num15, num15, num15), color4, this.Light.CloudColoring);
		this.CloudColor = new global::UnityEngine.Color(this.CloudColor.r, this.CloudColor.g, this.CloudColor.b, num14);
		global::UnityEngine.Color additiveColor = global::UnityEngine.Color.Lerp(this.Night.AdditiveColor, this.Day.AdditiveColor, this.LerpValue);
		additiveColor.r *= additiveColor.a;
		additiveColor.g *= additiveColor.a;
		additiveColor.b *= additiveColor.a;
		additiveColor.a = this.Max3(additiveColor.r, additiveColor.g, additiveColor.b);
		this.AdditiveColor = additiveColor;
		float intensity;
		float shadowStrength;
		global::UnityEngine.Vector3 localPosition;
		if (this.LerpValue > 0.2f)
		{
			float num16 = (this.LerpValue - 0.2f) / 0.8f;
			intensity = global::UnityEngine.Mathf.Lerp(0f, this.Day.SunLightIntensity, num16);
			shadowStrength = this.Day.ShadowStrength;
			localPosition = this.OrbitalToLocal(global::UnityEngine.Mathf.Min(theta, 1.5707964f), phi);
			this.Components.LightSource.color = color2;
		}
		else
		{
			float num17 = (0.2f - this.LerpValue) / 0.2f;
			float num18 = 1f - global::UnityEngine.Mathf.Abs(this.Cycle.MoonPhase);
			intensity = global::UnityEngine.Mathf.Lerp(0f, this.Night.MoonLightIntensity * num18, num17);
			shadowStrength = this.Night.ShadowStrength;
			localPosition = this.OrbitalToLocal(global::UnityEngine.Mathf.Max(theta + 3.1415927f, 4.712389f), phi);
			this.Components.LightSource.color = color;
		}
		global::UnityEngine.LightShadows shadows = (this.Components.LightSource.shadowStrength != 0f) ? 2 : 0;
		this.Components.LightSource.intensity = intensity;
		this.Components.LightSource.shadowStrength = shadowStrength;
		this.Components.LightTransform.localPosition = localPosition;
		this.Components.LightTransform.LookAt(this.Components.DomeTransform.position);
		this.Components.LightSource.shadows = shadows;
	}

	// Token: 0x060052F3 RID: 21235 RVA: 0x0015B4A8 File Offset: 0x001596A8
	private global::UnityEngine.Color SampleFogColor()
	{
		global::UnityEngine.Vector3 vector = (!(this.Components.CameraTransform != null)) ? global::UnityEngine.Vector3.forward : this.Components.CameraTransform.forward;
		global::UnityEngine.Vector3 direction = global::UnityEngine.Vector3.Lerp(new global::UnityEngine.Vector3(vector.x, 0f, vector.z), global::UnityEngine.Vector3.up, this.World.FogColorBias);
		global::UnityEngine.Color color = this.SampleAtmosphere(direction, true);
		return new global::UnityEngine.Color(color.a * color.r, color.a * color.g, color.a * color.b, 1f);
	}

	// Token: 0x060052F4 RID: 21236 RVA: 0x0015B554 File Offset: 0x00159754
	private global::UnityEngine.Color PowRGB(global::UnityEngine.Color c, float p)
	{
		return new global::UnityEngine.Color(global::UnityEngine.Mathf.Pow(c.r, p), global::UnityEngine.Mathf.Pow(c.g, p), global::UnityEngine.Mathf.Pow(c.b, p), c.a);
	}

	// Token: 0x060052F5 RID: 21237 RVA: 0x0015B58C File Offset: 0x0015978C
	private global::UnityEngine.Color PowRGBA(global::UnityEngine.Color c, float p)
	{
		return new global::UnityEngine.Color(global::UnityEngine.Mathf.Pow(c.r, p), global::UnityEngine.Mathf.Pow(c.g, p), global::UnityEngine.Mathf.Pow(c.b, p), global::UnityEngine.Mathf.Pow(c.a, p));
	}

	// Token: 0x060052F6 RID: 21238 RVA: 0x0015B5D4 File Offset: 0x001597D4
	private float Max3(float a, float b, float c)
	{
		return (a < b || a < c) ? ((b < c) ? c : b) : a;
	}

	// Token: 0x060052F7 RID: 21239 RVA: 0x0015B604 File Offset: 0x00159804
	private global::UnityEngine.Vector3 Inverse(global::UnityEngine.Vector3 v)
	{
		return new global::UnityEngine.Vector3(1f / v.x, 1f / v.y, 1f / v.z);
	}

	// Token: 0x060052F8 RID: 21240 RVA: 0x0015B640 File Offset: 0x00159840
	private void SetupQualitySettings()
	{
		global::TOD_Resources resources = this.Components.Resources;
		global::UnityEngine.Material material = null;
		global::UnityEngine.Material material2 = null;
		switch (this.CloudQuality)
		{
		case global::TOD_Sky.CloudQualityType.Fastest:
			material = resources.CloudMaterialFastest;
			material2 = resources.ShadowMaterialFastest;
			break;
		case global::TOD_Sky.CloudQualityType.Density:
			material = resources.CloudMaterialDensity;
			material2 = resources.ShadowMaterialDensity;
			break;
		case global::TOD_Sky.CloudQualityType.Bumped:
			material = resources.CloudMaterialBumped;
			material2 = resources.ShadowMaterialBumped;
			break;
		default:
			global::UnityEngine.Debug.LogError("Unknown cloud quality.");
			break;
		}
		global::UnityEngine.Mesh mesh = null;
		global::UnityEngine.Mesh mesh2 = null;
		global::UnityEngine.Mesh mesh3 = null;
		global::UnityEngine.Mesh mesh4 = null;
		global::UnityEngine.Mesh mesh5 = null;
		global::UnityEngine.Mesh mesh6 = null;
		switch (this.MeshQuality)
		{
		case global::TOD_Sky.MeshQualityType.Low:
			mesh = resources.IcosphereLow;
			mesh2 = resources.IcosphereLow;
			mesh3 = resources.IcosphereLow;
			mesh4 = resources.HalfIcosphereLow;
			mesh5 = resources.Quad;
			mesh6 = resources.SphereLow;
			break;
		case global::TOD_Sky.MeshQualityType.Medium:
			mesh = resources.IcosphereMedium;
			mesh2 = resources.IcosphereMedium;
			mesh3 = resources.IcosphereLow;
			mesh4 = resources.HalfIcosphereMedium;
			mesh5 = resources.Quad;
			mesh6 = resources.SphereMedium;
			break;
		case global::TOD_Sky.MeshQualityType.High:
			mesh = resources.IcosphereHigh;
			mesh2 = resources.IcosphereHigh;
			mesh3 = resources.IcosphereLow;
			mesh4 = resources.HalfIcosphereHigh;
			mesh5 = resources.Quad;
			mesh6 = resources.SphereHigh;
			break;
		default:
			global::UnityEngine.Debug.LogError("Unknown mesh quality.");
			break;
		}
		if (!this.Components.SpaceShader || this.Components.SpaceShader.name != resources.SpaceMaterial.name)
		{
			global::TOD_Components components = this.Components;
			global::UnityEngine.Material material3 = resources.SpaceMaterial;
			this.Components.SpaceRenderer.sharedMaterial = material3;
			components.SpaceShader = material3;
		}
		if (!this.Components.AtmosphereShader || this.Components.AtmosphereShader.name != resources.AtmosphereMaterial.name)
		{
			global::TOD_Components components2 = this.Components;
			global::UnityEngine.Material material3 = resources.AtmosphereMaterial;
			this.Components.AtmosphereRenderer.sharedMaterial = material3;
			components2.AtmosphereShader = material3;
		}
		if (!this.Components.ClearShader || this.Components.ClearShader.name != resources.ClearMaterial.name)
		{
			global::TOD_Components components3 = this.Components;
			global::UnityEngine.Material material3 = resources.ClearMaterial;
			this.Components.ClearRenderer.sharedMaterial = material3;
			components3.ClearShader = material3;
		}
		if (!this.Components.CloudShader || this.Components.CloudShader.name != material.name)
		{
			global::TOD_Components components4 = this.Components;
			global::UnityEngine.Material material3 = material;
			this.Components.CloudRenderer.sharedMaterial = material3;
			components4.CloudShader = material3;
		}
		if (!this.Components.ShadowShader || this.Components.ShadowShader.name != material2.name)
		{
			global::TOD_Components components5 = this.Components;
			global::UnityEngine.Material material3 = material2;
			this.Components.ShadowProjector.material = material3;
			components5.ShadowShader = material3;
		}
		if (!this.Components.SunShader || this.Components.SunShader.name != resources.SunMaterial.name)
		{
			global::TOD_Components components6 = this.Components;
			global::UnityEngine.Material material3 = resources.SunMaterial;
			this.Components.SunRenderer.sharedMaterial = material3;
			components6.SunShader = material3;
		}
		if (!this.Components.MoonShader || this.Components.MoonShader.name != resources.MoonMaterial.name)
		{
			global::TOD_Components components7 = this.Components;
			global::UnityEngine.Material material3 = resources.MoonMaterial;
			this.Components.MoonRenderer.sharedMaterial = material3;
			components7.MoonShader = material3;
		}
		if (this.Components.SpaceMeshFilter.sharedMesh != mesh)
		{
			this.Components.SpaceMeshFilter.mesh = mesh;
		}
		if (this.Components.AtmosphereMeshFilter.sharedMesh != mesh2)
		{
			this.Components.AtmosphereMeshFilter.mesh = mesh2;
		}
		if (this.Components.ClearMeshFilter.sharedMesh != mesh3)
		{
			this.Components.ClearMeshFilter.mesh = mesh3;
		}
		if (this.Components.CloudMeshFilter.sharedMesh != mesh4)
		{
			this.Components.CloudMeshFilter.mesh = mesh4;
		}
		if (this.Components.SunMeshFilter.sharedMesh != mesh5)
		{
			this.Components.SunMeshFilter.mesh = mesh5;
		}
		if (this.Components.MoonMeshFilter.sharedMesh != mesh6)
		{
			this.Components.MoonMeshFilter.mesh = mesh6;
		}
	}

	// Token: 0x060052F9 RID: 21241 RVA: 0x0015BB48 File Offset: 0x00159D48
	protected void OnEnable()
	{
		this.Components = base.GetComponent<global::TOD_Components>();
		if (!this.Components)
		{
			global::UnityEngine.Debug.LogError("TOD_Components not found. Disabling script.");
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060052FA RID: 21242 RVA: 0x0015BB84 File Offset: 0x00159D84
	protected void Update()
	{
		if (this.Components.SunShafts != null && this.Components.SunShafts.enabled)
		{
			if (!this.Components.ClearRenderer.enabled)
			{
				this.Components.ClearRenderer.enabled = true;
			}
		}
		else if (this.Components.ClearRenderer.enabled)
		{
			this.Components.ClearRenderer.enabled = false;
		}
		this.Cycle.CheckRange();
		this.SetupQualitySettings();
		this.SetupSunAndMoon();
		this.SetupScattering();
		if (this.World.SetFogColor)
		{
			global::UnityEngine.Color fogColor = this.SampleFogColor();
			global::UnityEngine.RenderSettings.fogColor = fogColor;
		}
		if (this.World.SetAmbientLight)
		{
			global::UnityEngine.RenderSettings.ambientLight = this.AmbientColor;
		}
		global::UnityEngine.Vector4 vector = this.Components.Animation.CloudUV + this.Components.Animation.OffsetUV;
		global::UnityEngine.Shader.SetGlobalFloat("TOD_Gamma", this.Gamma);
		global::UnityEngine.Shader.SetGlobalFloat("TOD_OneOverGamma", this.OneOverGamma);
		global::UnityEngine.Shader.SetGlobalColor("TOD_LightColor", this.LightColor);
		global::UnityEngine.Shader.SetGlobalColor("TOD_CloudColor", this.CloudColor);
		global::UnityEngine.Shader.SetGlobalColor("TOD_AmbientColor", this.AmbientColor);
		global::UnityEngine.Shader.SetGlobalColor("TOD_SunColor", this.SunColor);
		global::UnityEngine.Shader.SetGlobalColor("TOD_MoonColor", this.MoonColor);
		global::UnityEngine.Shader.SetGlobalColor("TOD_AdditiveColor", this.AdditiveColor);
		global::UnityEngine.Shader.SetGlobalColor("TOD_MoonHaloColor", this.MoonHaloColor);
		global::UnityEngine.Shader.SetGlobalVector("TOD_SunDirection", this.SunDirection);
		global::UnityEngine.Shader.SetGlobalVector("TOD_MoonDirection", this.MoonDirection);
		global::UnityEngine.Shader.SetGlobalVector("TOD_LightDirection", this.LightDirection);
		global::UnityEngine.Shader.SetGlobalVector("TOD_LocalSunDirection", this.Components.DomeTransform.InverseTransformDirection(this.SunDirection));
		global::UnityEngine.Shader.SetGlobalVector("TOD_LocalMoonDirection", this.Components.DomeTransform.InverseTransformDirection(this.MoonDirection));
		global::UnityEngine.Shader.SetGlobalVector("TOD_LocalLightDirection", this.Components.DomeTransform.InverseTransformDirection(this.LightDirection));
		if (this.Components.AtmosphereShader != null)
		{
			this.Components.AtmosphereShader.SetFloat("_Contrast", this.Atmosphere.Contrast * this.OneOverGamma);
			this.Components.AtmosphereShader.SetFloat("_Haziness", this.Atmosphere.Haziness);
			this.Components.AtmosphereShader.SetFloat("_Fogginess", this.Atmosphere.Fogginess);
			this.Components.AtmosphereShader.SetFloat("_Horizon", this.World.HorizonOffset);
			this.Components.AtmosphereShader.SetVector("_OpticalDepth", this.opticalDepth);
			this.Components.AtmosphereShader.SetVector("_OneOverBeta", this.oneOverBeta);
			this.Components.AtmosphereShader.SetVector("_BetaRayleigh", this.betaRayleigh);
			this.Components.AtmosphereShader.SetVector("_BetaRayleighTheta", this.betaRayleighTheta);
			this.Components.AtmosphereShader.SetVector("_BetaMie", this.betaMie);
			this.Components.AtmosphereShader.SetVector("_BetaMieTheta", this.betaMieTheta);
			this.Components.AtmosphereShader.SetVector("_BetaMiePhase", this.betaMiePhase);
			this.Components.AtmosphereShader.SetVector("_BetaNight", this.betaNight);
		}
		if (this.Components.CloudShader != null)
		{
			float num = (1f - this.Atmosphere.Fogginess) * this.LerpValue;
			float num2 = (1f - this.Atmosphere.Fogginess) * 0.6f * (1f - global::UnityEngine.Mathf.Abs(this.Cycle.MoonPhase));
			this.Components.CloudShader.SetFloat("_SunGlow", num);
			this.Components.CloudShader.SetFloat("_MoonGlow", num2);
			this.Components.CloudShader.SetFloat("_CloudDensity", this.Clouds.Density);
			this.Components.CloudShader.SetFloat("_CloudSharpness", this.Clouds.Sharpness);
			this.Components.CloudShader.SetVector("_CloudScale1", this.Clouds.Scale1);
			this.Components.CloudShader.SetVector("_CloudScale2", this.Clouds.Scale2);
			this.Components.CloudShader.SetVector("_CloudUV", vector);
		}
		if (this.Components.SpaceShader != null)
		{
			global::UnityEngine.Vector2 mainTextureScale;
			mainTextureScale..ctor(this.Stars.Tiling, this.Stars.Tiling);
			this.Components.SpaceShader.mainTextureScale = mainTextureScale;
			this.Components.SpaceShader.SetFloat("_Subtract", 1f - global::UnityEngine.Mathf.Pow(this.Stars.Density, 0.1f));
		}
		if (this.Components.SunShader != null)
		{
			this.Components.SunShader.SetColor("_Color", this.Day.SunMeshColor * this.LerpValue * (1f - this.Atmosphere.Fogginess));
		}
		if (this.Components.MoonShader != null)
		{
			this.Components.MoonShader.SetColor("_Color", this.Night.MoonMeshColor);
			this.Components.MoonShader.SetFloat("_Phase", this.Cycle.MoonPhase);
		}
		if (this.Components.ShadowShader != null)
		{
			float num3 = this.Clouds.ShadowStrength * global::UnityEngine.Mathf.Clamp01(1f - this.LightZenith / 90f);
			this.Components.ShadowShader.SetFloat("_Alpha", num3);
			this.Components.ShadowShader.SetFloat("_CloudDensity", this.Clouds.Density);
			this.Components.ShadowShader.SetFloat("_CloudSharpness", this.Clouds.Sharpness);
			this.Components.ShadowShader.SetVector("_CloudScale1", this.Clouds.Scale1);
			this.Components.ShadowShader.SetVector("_CloudScale2", this.Clouds.Scale2);
			this.Components.ShadowShader.SetVector("_CloudUV", vector);
		}
		if (this.Components.ShadowProjector != null)
		{
			bool enabled = this.Clouds.ShadowStrength != 0f && this.Components.ShadowShader != null;
			float farClipPlane = this.Radius * 2f;
			float radius = this.Radius;
			this.Components.ShadowProjector.enabled = enabled;
			this.Components.ShadowProjector.farClipPlane = farClipPlane;
			this.Components.ShadowProjector.orthographicSize = radius;
		}
	}

	// Token: 0x17000F7E RID: 3966
	// (get) Token: 0x060052FB RID: 21243 RVA: 0x0015C330 File Offset: 0x0015A530
	// (set) Token: 0x060052FC RID: 21244 RVA: 0x0015C338 File Offset: 0x0015A538
	internal global::TOD_Components Components
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Components>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Components>k__BackingField = value;
		}
	}

	// Token: 0x17000F7F RID: 3967
	// (get) Token: 0x060052FD RID: 21245 RVA: 0x0015C344 File Offset: 0x0015A544
	internal bool IsDay
	{
		get
		{
			return this.LerpValue > 0f;
		}
	}

	// Token: 0x17000F80 RID: 3968
	// (get) Token: 0x060052FE RID: 21246 RVA: 0x0015C354 File Offset: 0x0015A554
	internal bool IsNight
	{
		get
		{
			return this.LerpValue == 0f;
		}
	}

	// Token: 0x17000F81 RID: 3969
	// (get) Token: 0x060052FF RID: 21247 RVA: 0x0015C364 File Offset: 0x0015A564
	internal float Radius
	{
		get
		{
			return this.Components.DomeTransform.localScale.x;
		}
	}

	// Token: 0x17000F82 RID: 3970
	// (get) Token: 0x06005300 RID: 21248 RVA: 0x0015C38C File Offset: 0x0015A58C
	internal float Gamma
	{
		get
		{
			return ((this.UnityColorSpace != global::TOD_Sky.ColorSpaceDetection.Auto || global::UnityEngine.QualitySettings.activeColorSpace != 1) && this.UnityColorSpace != global::TOD_Sky.ColorSpaceDetection.Linear) ? 2.2f : 1f;
		}
	}

	// Token: 0x17000F83 RID: 3971
	// (get) Token: 0x06005301 RID: 21249 RVA: 0x0015C3C0 File Offset: 0x0015A5C0
	internal float OneOverGamma
	{
		get
		{
			return ((this.UnityColorSpace != global::TOD_Sky.ColorSpaceDetection.Auto || global::UnityEngine.QualitySettings.activeColorSpace != 1) && this.UnityColorSpace != global::TOD_Sky.ColorSpaceDetection.Linear) ? 0.45454544f : 1f;
		}
	}

	// Token: 0x17000F84 RID: 3972
	// (get) Token: 0x06005302 RID: 21250 RVA: 0x0015C3F4 File Offset: 0x0015A5F4
	// (set) Token: 0x06005303 RID: 21251 RVA: 0x0015C3FC File Offset: 0x0015A5FC
	internal float LerpValue
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<LerpValue>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<LerpValue>k__BackingField = value;
		}
	}

	// Token: 0x17000F85 RID: 3973
	// (get) Token: 0x06005304 RID: 21252 RVA: 0x0015C408 File Offset: 0x0015A608
	// (set) Token: 0x06005305 RID: 21253 RVA: 0x0015C410 File Offset: 0x0015A610
	internal float SunZenith
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<SunZenith>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<SunZenith>k__BackingField = value;
		}
	}

	// Token: 0x17000F86 RID: 3974
	// (get) Token: 0x06005306 RID: 21254 RVA: 0x0015C41C File Offset: 0x0015A61C
	// (set) Token: 0x06005307 RID: 21255 RVA: 0x0015C424 File Offset: 0x0015A624
	internal float MoonZenith
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<MoonZenith>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<MoonZenith>k__BackingField = value;
		}
	}

	// Token: 0x17000F87 RID: 3975
	// (get) Token: 0x06005308 RID: 21256 RVA: 0x0015C430 File Offset: 0x0015A630
	internal float LightZenith
	{
		get
		{
			return global::UnityEngine.Mathf.Min(this.SunZenith, this.MoonZenith);
		}
	}

	// Token: 0x17000F88 RID: 3976
	// (get) Token: 0x06005309 RID: 21257 RVA: 0x0015C444 File Offset: 0x0015A644
	internal float LightIntensity
	{
		get
		{
			return this.Components.LightSource.intensity;
		}
	}

	// Token: 0x17000F89 RID: 3977
	// (get) Token: 0x0600530A RID: 21258 RVA: 0x0015C458 File Offset: 0x0015A658
	internal global::UnityEngine.Vector3 MoonDirection
	{
		get
		{
			return this.Components.MoonTransform.forward;
		}
	}

	// Token: 0x17000F8A RID: 3978
	// (get) Token: 0x0600530B RID: 21259 RVA: 0x0015C46C File Offset: 0x0015A66C
	internal global::UnityEngine.Vector3 SunDirection
	{
		get
		{
			return this.Components.SunTransform.forward;
		}
	}

	// Token: 0x17000F8B RID: 3979
	// (get) Token: 0x0600530C RID: 21260 RVA: 0x0015C480 File Offset: 0x0015A680
	internal global::UnityEngine.Vector3 LightDirection
	{
		get
		{
			return global::UnityEngine.Vector3.Lerp(this.MoonDirection, this.SunDirection, this.LerpValue * this.LerpValue);
		}
	}

	// Token: 0x17000F8C RID: 3980
	// (get) Token: 0x0600530D RID: 21261 RVA: 0x0015C4AC File Offset: 0x0015A6AC
	internal global::UnityEngine.Color LightColor
	{
		get
		{
			return this.Components.LightSource.color;
		}
	}

	// Token: 0x17000F8D RID: 3981
	// (get) Token: 0x0600530E RID: 21262 RVA: 0x0015C4C0 File Offset: 0x0015A6C0
	// (set) Token: 0x0600530F RID: 21263 RVA: 0x0015C4C8 File Offset: 0x0015A6C8
	internal global::UnityEngine.Color SunShaftColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<SunShaftColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<SunShaftColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F8E RID: 3982
	// (get) Token: 0x06005310 RID: 21264 RVA: 0x0015C4D4 File Offset: 0x0015A6D4
	// (set) Token: 0x06005311 RID: 21265 RVA: 0x0015C4DC File Offset: 0x0015A6DC
	internal global::UnityEngine.Color SunColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<SunColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<SunColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F8F RID: 3983
	// (get) Token: 0x06005312 RID: 21266 RVA: 0x0015C4E8 File Offset: 0x0015A6E8
	// (set) Token: 0x06005313 RID: 21267 RVA: 0x0015C4F0 File Offset: 0x0015A6F0
	internal global::UnityEngine.Color MoonColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<MoonColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<MoonColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F90 RID: 3984
	// (get) Token: 0x06005314 RID: 21268 RVA: 0x0015C4FC File Offset: 0x0015A6FC
	// (set) Token: 0x06005315 RID: 21269 RVA: 0x0015C504 File Offset: 0x0015A704
	internal global::UnityEngine.Color MoonHaloColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<MoonHaloColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<MoonHaloColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F91 RID: 3985
	// (get) Token: 0x06005316 RID: 21270 RVA: 0x0015C510 File Offset: 0x0015A710
	// (set) Token: 0x06005317 RID: 21271 RVA: 0x0015C518 File Offset: 0x0015A718
	internal global::UnityEngine.Color CloudColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<CloudColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<CloudColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F92 RID: 3986
	// (get) Token: 0x06005318 RID: 21272 RVA: 0x0015C524 File Offset: 0x0015A724
	// (set) Token: 0x06005319 RID: 21273 RVA: 0x0015C52C File Offset: 0x0015A72C
	internal global::UnityEngine.Color AdditiveColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<AdditiveColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<AdditiveColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F93 RID: 3987
	// (get) Token: 0x0600531A RID: 21274 RVA: 0x0015C538 File Offset: 0x0015A738
	// (set) Token: 0x0600531B RID: 21275 RVA: 0x0015C540 File Offset: 0x0015A740
	internal global::UnityEngine.Color AmbientColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<AmbientColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<AmbientColor>k__BackingField = value;
		}
	}

	// Token: 0x17000F94 RID: 3988
	// (get) Token: 0x0600531C RID: 21276 RVA: 0x0015C54C File Offset: 0x0015A74C
	internal global::UnityEngine.Color FogColor
	{
		get
		{
			return (!this.World.SetFogColor) ? this.SampleFogColor() : global::UnityEngine.RenderSettings.fogColor;
		}
	}

	// Token: 0x0400302D RID: 12333
	private const float pi = 3.1415927f;

	// Token: 0x0400302E RID: 12334
	private const float pi2 = 9.869605f;

	// Token: 0x0400302F RID: 12335
	private const float pi3 = 31.006279f;

	// Token: 0x04003030 RID: 12336
	private const float pi4 = 97.4091f;

	// Token: 0x04003031 RID: 12337
	private global::UnityEngine.Vector2 opticalDepth;

	// Token: 0x04003032 RID: 12338
	private global::UnityEngine.Vector3 oneOverBeta;

	// Token: 0x04003033 RID: 12339
	private global::UnityEngine.Vector3 betaRayleigh;

	// Token: 0x04003034 RID: 12340
	private global::UnityEngine.Vector3 betaRayleighTheta;

	// Token: 0x04003035 RID: 12341
	private global::UnityEngine.Vector3 betaMie;

	// Token: 0x04003036 RID: 12342
	private global::UnityEngine.Vector3 betaMieTheta;

	// Token: 0x04003037 RID: 12343
	private global::UnityEngine.Vector2 betaMiePhase;

	// Token: 0x04003038 RID: 12344
	private global::UnityEngine.Vector3 betaNight;

	// Token: 0x04003039 RID: 12345
	public global::TOD_Sky.ColorSpaceDetection UnityColorSpace;

	// Token: 0x0400303A RID: 12346
	public global::TOD_Sky.CloudQualityType CloudQuality = global::TOD_Sky.CloudQualityType.Bumped;

	// Token: 0x0400303B RID: 12347
	public global::TOD_Sky.MeshQualityType MeshQuality = global::TOD_Sky.MeshQualityType.High;

	// Token: 0x0400303C RID: 12348
	public global::TOD_CycleParameters Cycle;

	// Token: 0x0400303D RID: 12349
	public global::TOD_AtmosphereParameters Atmosphere;

	// Token: 0x0400303E RID: 12350
	public global::TOD_DayParameters Day;

	// Token: 0x0400303F RID: 12351
	public global::TOD_NightParameters Night;

	// Token: 0x04003040 RID: 12352
	public global::TOD_LightParameters Light;

	// Token: 0x04003041 RID: 12353
	public global::TOD_StarParameters Stars;

	// Token: 0x04003042 RID: 12354
	public global::TOD_CloudParameters Clouds;

	// Token: 0x04003043 RID: 12355
	public global::TOD_WorldParameters World;

	// Token: 0x04003044 RID: 12356
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::TOD_Components <Components>k__BackingField;

	// Token: 0x04003045 RID: 12357
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <LerpValue>k__BackingField;

	// Token: 0x04003046 RID: 12358
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <SunZenith>k__BackingField;

	// Token: 0x04003047 RID: 12359
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <MoonZenith>k__BackingField;

	// Token: 0x04003048 RID: 12360
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <SunShaftColor>k__BackingField;

	// Token: 0x04003049 RID: 12361
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <SunColor>k__BackingField;

	// Token: 0x0400304A RID: 12362
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <MoonColor>k__BackingField;

	// Token: 0x0400304B RID: 12363
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <MoonHaloColor>k__BackingField;

	// Token: 0x0400304C RID: 12364
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <CloudColor>k__BackingField;

	// Token: 0x0400304D RID: 12365
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <AdditiveColor>k__BackingField;

	// Token: 0x0400304E RID: 12366
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color <AmbientColor>k__BackingField;

	// Token: 0x0200099A RID: 2458
	public enum ColorSpaceDetection
	{
		// Token: 0x04003050 RID: 12368
		Auto,
		// Token: 0x04003051 RID: 12369
		Linear,
		// Token: 0x04003052 RID: 12370
		Gamma
	}

	// Token: 0x0200099B RID: 2459
	public enum CloudQualityType
	{
		// Token: 0x04003054 RID: 12372
		Fastest,
		// Token: 0x04003055 RID: 12373
		Density,
		// Token: 0x04003056 RID: 12374
		Bumped
	}

	// Token: 0x0200099C RID: 2460
	public enum MeshQualityType
	{
		// Token: 0x04003058 RID: 12376
		Low,
		// Token: 0x04003059 RID: 12377
		Medium,
		// Token: 0x0400305A RID: 12378
		High
	}
}
