using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000732 RID: 1842
public abstract class LightStyle : global::UnityEngine.ScriptableObject
{
	// Token: 0x06003E25 RID: 15909 RVA: 0x000DB75C File Offset: 0x000D995C
	protected LightStyle()
	{
	}

	// Token: 0x06003E26 RID: 15910 RVA: 0x000DB764 File Offset: 0x000D9964
	// Note: this type is marked as 'beforefieldinit'.
	static LightStyle()
	{
	}

	// Token: 0x17000BCA RID: 3018
	// (get) Token: 0x06003E27 RID: 15911 RVA: 0x000DB768 File Offset: 0x000D9968
	public static double time
	{
		get
		{
			if (global::NetCull.isRunning)
			{
				return global::NetCull.time;
			}
			return (double)global::UnityEngine.Time.time;
		}
	}

	// Token: 0x06003E28 RID: 15912
	protected abstract global::LightStyle.Simulation ConstructSimulation(global::LightStylist stylist);

	// Token: 0x06003E29 RID: 15913
	protected abstract bool DeconstructSimulation(global::LightStyle.Simulation simulation);

	// Token: 0x06003E2A RID: 15914 RVA: 0x000DB780 File Offset: 0x000D9980
	public global::LightStyle.Simulation CreateSimulation(global::LightStylist stylist)
	{
		return this.CreateSimulation(global::LightStyle.time, stylist);
	}

	// Token: 0x06003E2B RID: 15915 RVA: 0x000DB790 File Offset: 0x000D9990
	public global::LightStyle.Simulation CreateSimulation(double startTime, global::LightStylist stylist)
	{
		global::LightStyle.Simulation simulation = this.ConstructSimulation(stylist);
		if (simulation != null)
		{
			simulation.ResetTime(startTime);
		}
		return simulation;
	}

	// Token: 0x06003E2C RID: 15916 RVA: 0x000DB7B4 File Offset: 0x000D99B4
	private static global::LightStyle MissingLightStyle(string name)
	{
		return global::LightStyleDefault.Singleton;
	}

	// Token: 0x06003E2D RID: 15917 RVA: 0x000DB7BC File Offset: 0x000D99BC
	public static implicit operator global::LightStyle(string name)
	{
		if (!global::LightStyle.madeLoadedByString)
		{
			global::LightStyle lightStyle = (global::LightStyle)global::UnityEngine.Resources.Load(name, typeof(global::LightStyle));
			if (lightStyle)
			{
				global::LightStyle.loadedByString = new global::System.Collections.Generic.Dictionary<string, global::System.WeakReference>(global::System.StringComparer.InvariantCultureIgnoreCase);
				global::LightStyle.loadedByString[name] = new global::System.WeakReference(lightStyle);
			}
			else
			{
				lightStyle = global::LightStyle.MissingLightStyle(name);
			}
			return lightStyle;
		}
		global::System.WeakReference weakReference;
		if (!global::LightStyle.loadedByString.TryGetValue(name, out weakReference))
		{
			global::LightStyle lightStyle2 = (global::LightStyle)global::UnityEngine.Resources.Load(name, typeof(global::LightStyle));
			if (lightStyle2)
			{
				weakReference = new global::System.WeakReference(lightStyle2);
				global::LightStyle.loadedByString[name] = weakReference;
			}
			else
			{
				lightStyle2 = global::LightStyle.MissingLightStyle(name);
			}
			return lightStyle2;
		}
		object target = weakReference.Target;
		if (weakReference.IsAlive && (global::UnityEngine.Object)target)
		{
			return (global::LightStyle)target;
		}
		global::LightStyle lightStyle3 = (global::LightStyle)global::UnityEngine.Resources.Load(name, typeof(global::LightStyle));
		if (lightStyle3)
		{
			weakReference.Target = lightStyle3;
		}
		else
		{
			lightStyle3 = global::LightStyle.MissingLightStyle(name);
		}
		return lightStyle3;
	}

	// Token: 0x06003E2E RID: 15918 RVA: 0x000DB8DC File Offset: 0x000D9ADC
	public static implicit operator string(global::LightStyle lightStyle)
	{
		return (!lightStyle) ? null : lightStyle.name;
	}

	// Token: 0x04001FBA RID: 8122
	private static global::System.Collections.Generic.Dictionary<string, global::System.WeakReference> loadedByString;

	// Token: 0x04001FBB RID: 8123
	private static bool madeLoadedByString;

	// Token: 0x02000733 RID: 1843
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit)]
	public struct Mod
	{
		// Token: 0x06003E2F RID: 15919 RVA: 0x000DB8F8 File Offset: 0x000D9AF8
		public bool AnyOf(global::LightStyle.Mod.Mask mask)
		{
			return (this.mask & mask) != (global::LightStyle.Mod.Mask)0;
		}

		// Token: 0x06003E30 RID: 15920 RVA: 0x000DB908 File Offset: 0x000D9B08
		public bool AllOf(global::LightStyle.Mod.Mask mask)
		{
			return (this.mask & mask) == mask;
		}

		// Token: 0x06003E31 RID: 15921 RVA: 0x000DB918 File Offset: 0x000D9B18
		public bool Contains(global::LightStyle.Mod.Element element)
		{
			return this.AllOf(global::LightStyle.Mod.ElementToMask(element));
		}

		// Token: 0x06003E32 RID: 15922 RVA: 0x000DB928 File Offset: 0x000D9B28
		public void SetModify(global::LightStyle.Mod.Element element)
		{
			this.mask |= global::LightStyle.Mod.ElementToMask(element);
		}

		// Token: 0x06003E33 RID: 15923 RVA: 0x000DB940 File Offset: 0x000D9B40
		public void SetModify(global::LightStyle.Mod.Element element, float assignValue)
		{
			this.SetFaceValue(element, assignValue);
			this.mask |= global::LightStyle.Mod.ElementToMask(element);
		}

		// Token: 0x06003E34 RID: 15924 RVA: 0x000DB960 File Offset: 0x000D9B60
		public void ClearModify(global::LightStyle.Mod.Element element)
		{
			this.mask &= global::LightStyle.Mod.ElementToMaskNot(element);
		}

		// Token: 0x06003E35 RID: 15925 RVA: 0x000DB978 File Offset: 0x000D9B78
		public void ToggleModify(global::LightStyle.Mod.Element element)
		{
			this.mask ^= global::LightStyle.Mod.ElementToMask(element);
		}

		// Token: 0x06003E36 RID: 15926 RVA: 0x000DB990 File Offset: 0x000D9B90
		public float GetFaceValue(global::LightStyle.Mod.Element element)
		{
			switch (element)
			{
			case global::LightStyle.Mod.Element.Red:
				return this.r;
			case global::LightStyle.Mod.Element.Green:
				return this.g;
			case global::LightStyle.Mod.Element.Blue:
				return this.b;
			case global::LightStyle.Mod.Element.Alpha:
				return this.a;
			case global::LightStyle.Mod.Element.Intensity:
				return this.intensity;
			case global::LightStyle.Mod.Element.Range:
				return this.range;
			case global::LightStyle.Mod.Element.SpotAngle:
				return this.spotAngle;
			default:
				throw new global::System.ArgumentOutOfRangeException("element");
			}
		}

		// Token: 0x06003E37 RID: 15927 RVA: 0x000DBA04 File Offset: 0x000D9C04
		public void SetFaceValue(global::LightStyle.Mod.Element element, float value)
		{
			switch (element)
			{
			case global::LightStyle.Mod.Element.Red:
				this.r = value;
				break;
			case global::LightStyle.Mod.Element.Green:
				this.g = value;
				break;
			case global::LightStyle.Mod.Element.Blue:
				this.b = value;
				break;
			case global::LightStyle.Mod.Element.Alpha:
				this.a = value;
				break;
			case global::LightStyle.Mod.Element.Intensity:
				this.intensity = value;
				break;
			case global::LightStyle.Mod.Element.Range:
				this.range = value;
				break;
			case global::LightStyle.Mod.Element.SpotAngle:
				this.spotAngle = value;
				break;
			default:
				throw new global::System.ArgumentOutOfRangeException("element");
			}
		}

		// Token: 0x17000BCB RID: 3019
		public float? this[global::LightStyle.Mod.Element element]
		{
			get
			{
				if (this.Contains(element))
				{
					return new float?(this.GetFaceValue(element));
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					this.SetFaceValue(element, value.Value);
					this.SetModify(element);
				}
				else
				{
					this.ClearModify(element);
				}
			}
		}

		// Token: 0x06003E3A RID: 15930 RVA: 0x000DBB08 File Offset: 0x000D9D08
		public static global::LightStyle.Mod.Mask ElementToMask(global::LightStyle.Mod.Element element)
		{
			return (global::LightStyle.Mod.Mask)(1 << (int)element & 0x7F);
		}

		// Token: 0x06003E3B RID: 15931 RVA: 0x000DBB14 File Offset: 0x000D9D14
		public static global::LightStyle.Mod.Mask ElementToMaskNot(global::LightStyle.Mod.Element element)
		{
			return (global::LightStyle.Mod.Mask)(~(1 << (int)element) & 0x7F);
		}

		// Token: 0x06003E3C RID: 15932 RVA: 0x000DBB20 File Offset: 0x000D9D20
		public void ApplyTo(global::UnityEngine.Light light)
		{
			switch (light.type)
			{
			case 0:
				this.ApplyTo(light, global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle);
				break;
			case 1:
				this.ApplyTo(light, global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity);
				break;
			case 2:
				this.ApplyTo(light, global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range);
				break;
			}
		}

		// Token: 0x06003E3D RID: 15933 RVA: 0x000DBB78 File Offset: 0x000D9D78
		public void ApplyTo(global::UnityEngine.Light light, global::LightStyle.Mod.Mask applyMask)
		{
			global::LightStyle.Mod.Mask mask = this.mask & applyMask;
			if ((mask & (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha)) != (global::LightStyle.Mod.Mask)0)
			{
				if ((mask & (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha)) == (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha))
				{
					light.color = this.color;
				}
				else
				{
					global::UnityEngine.Color color = light.color;
					if ((mask & global::LightStyle.Mod.Mask.Red) == global::LightStyle.Mod.Mask.Red)
					{
						color.r = this.r;
					}
					if ((mask & global::LightStyle.Mod.Mask.Green) == global::LightStyle.Mod.Mask.Green)
					{
						color.g = this.g;
					}
					if ((mask & global::LightStyle.Mod.Mask.Blue) == global::LightStyle.Mod.Mask.Blue)
					{
						color.b = this.b;
					}
					if ((mask & global::LightStyle.Mod.Mask.Alpha) == global::LightStyle.Mod.Mask.Alpha)
					{
						color.a = this.a;
					}
					light.color = color;
				}
			}
			if ((mask & global::LightStyle.Mod.Mask.Intensity) == global::LightStyle.Mod.Mask.Intensity)
			{
				light.intensity = this.intensity;
			}
			if ((mask & global::LightStyle.Mod.Mask.Range) == global::LightStyle.Mod.Mask.Range)
			{
				light.range = this.range;
			}
			if ((mask & global::LightStyle.Mod.Mask.SpotAngle) == global::LightStyle.Mod.Mask.SpotAngle)
			{
				light.spotAngle = this.spotAngle;
			}
		}

		// Token: 0x06003E3E RID: 15934 RVA: 0x000DBC60 File Offset: 0x000D9E60
		public static global::LightStyle.Mod Lerp(global::LightStyle.Mod a, global::LightStyle.Mod b, float t, global::LightStyle.Mod.Mask mask)
		{
			b.mask &= mask;
			if (b.mask == (global::LightStyle.Mod.Mask)0)
			{
				return a;
			}
			a.mask &= mask;
			if (a.mask == (global::LightStyle.Mod.Mask)0)
			{
				return b;
			}
			global::LightStyle.Mod.Mask mask2 = a.mask & b.mask;
			if (mask2 != (global::LightStyle.Mod.Mask)0)
			{
				float num = 1f - t;
				if (mask != (global::LightStyle.Mod.Mask)0)
				{
					for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
					{
						if ((mask2 & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
						{
							float faceValue = a.GetFaceValue(element);
							float faceValue2 = b.GetFaceValue(element);
							float value = faceValue * num + faceValue2 * t;
							a.SetFaceValue(element, value);
						}
					}
				}
			}
			if (mask2 != a.mask)
			{
				a |= b;
			}
			return a;
		}

		// Token: 0x06003E3F RID: 15935 RVA: 0x000DBD30 File Offset: 0x000D9F30
		public static global::LightStyle.Mod operator +(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			global::LightStyle.Mod result = a;
			global::LightStyle.Mod.Mask mask = a.mask & b.mask;
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					result.SetFaceValue(element, a.GetFaceValue(element) + b.GetFaceValue(element));
				}
			}
			return result;
		}

		// Token: 0x06003E40 RID: 15936 RVA: 0x000DBD90 File Offset: 0x000D9F90
		public static global::LightStyle.Mod operator -(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			global::LightStyle.Mod.Mask mask = a.mask & b.mask;
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, a.GetFaceValue(element) - b.GetFaceValue(element));
				}
			}
			return a;
		}

		// Token: 0x06003E41 RID: 15937 RVA: 0x000DBDEC File Offset: 0x000D9FEC
		public static global::LightStyle.Mod operator *(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			global::LightStyle.Mod.Mask mask = a.mask & b.mask;
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, a.GetFaceValue(element) * b.GetFaceValue(element));
				}
			}
			return a;
		}

		// Token: 0x06003E42 RID: 15938 RVA: 0x000DBE48 File Offset: 0x000DA048
		public static global::LightStyle.Mod operator /(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			global::LightStyle.Mod.Mask mask = a.mask & b.mask;
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, a.GetFaceValue(element) / b.GetFaceValue(element));
				}
			}
			return a;
		}

		// Token: 0x06003E43 RID: 15939 RVA: 0x000DBEA4 File Offset: 0x000DA0A4
		public static global::LightStyle.Mod operator |(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) != global::LightStyle.Mod.ElementToMask(element) && (b.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetModify(element, b.GetFaceValue(element));
				}
			}
			return a;
		}

		// Token: 0x06003E44 RID: 15940 RVA: 0x000DBF08 File Offset: 0x000DA108
		public static global::LightStyle.Mod operator &(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element) && (b.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, b.GetFaceValue(element));
				}
			}
			return a;
		}

		// Token: 0x06003E45 RID: 15941 RVA: 0x000DBF6C File Offset: 0x000DA16C
		public static global::LightStyle.Mod operator ^(global::LightStyle.Mod a, global::LightStyle.Mod b)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					if ((b.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
					{
						a.SetFaceValue(element, b.GetFaceValue(element));
					}
				}
				else if ((b.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetModify(element, b.GetFaceValue(element));
				}
			}
			return a;
		}

		// Token: 0x06003E46 RID: 15942 RVA: 0x000DC008 File Offset: 0x000DA208
		public static global::LightStyle.Mod operator |(global::LightStyle.Mod a, global::LightStyle.Mod.Mask b)
		{
			a.mask |= b;
			return a;
		}

		// Token: 0x06003E47 RID: 15943 RVA: 0x000DC01C File Offset: 0x000DA21C
		public static global::LightStyle.Mod operator &(global::LightStyle.Mod a, global::LightStyle.Mod.Mask b)
		{
			a.mask &= b;
			return a;
		}

		// Token: 0x06003E48 RID: 15944 RVA: 0x000DC030 File Offset: 0x000DA230
		public static global::LightStyle.Mod operator ^(global::LightStyle.Mod a, global::LightStyle.Mod.Mask b)
		{
			a.mask ^= b;
			return a;
		}

		// Token: 0x06003E49 RID: 15945 RVA: 0x000DC044 File Offset: 0x000DA244
		public static global::LightStyle.Mod operator +(global::LightStyle.Mod a, global::LightStyle.Mod.Element b)
		{
			a.mask |= global::LightStyle.Mod.ElementToMask(b);
			return a;
		}

		// Token: 0x06003E4A RID: 15946 RVA: 0x000DC05C File Offset: 0x000DA25C
		public static global::LightStyle.Mod operator -(global::LightStyle.Mod a, global::LightStyle.Mod.Element b)
		{
			a.mask &= global::LightStyle.Mod.ElementToMaskNot(b);
			return a;
		}

		// Token: 0x06003E4B RID: 15947 RVA: 0x000DC074 File Offset: 0x000DA274
		public static float?operator |(global::LightStyle.Mod a, global::LightStyle.Mod.Element b)
		{
			return a[b];
		}

		// Token: 0x06003E4C RID: 15948 RVA: 0x000DC080 File Offset: 0x000DA280
		public static bool operator &(global::LightStyle.Mod a, global::LightStyle.Mod.Element b)
		{
			return a.Contains(b);
		}

		// Token: 0x06003E4D RID: 15949 RVA: 0x000DC08C File Offset: 0x000DA28C
		public static float operator ^(global::LightStyle.Mod a, global::LightStyle.Mod.Element b)
		{
			return a.GetFaceValue(b);
		}

		// Token: 0x06003E4E RID: 15950 RVA: 0x000DC098 File Offset: 0x000DA298
		public static global::LightStyle.Mod operator +(global::LightStyle.Mod a, float b)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, a.GetFaceValue(element) + b);
				}
			}
			return a;
		}

		// Token: 0x06003E4F RID: 15951 RVA: 0x000DC0E4 File Offset: 0x000DA2E4
		public static global::LightStyle.Mod operator -(global::LightStyle.Mod a, float b)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, a.GetFaceValue(element) - b);
				}
			}
			return a;
		}

		// Token: 0x06003E50 RID: 15952 RVA: 0x000DC130 File Offset: 0x000DA330
		public static global::LightStyle.Mod operator *(global::LightStyle.Mod a, float b)
		{
			global::LightStyle.Mod result = a;
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					result.SetFaceValue(element, a.GetFaceValue(element) * b);
				}
			}
			return result;
		}

		// Token: 0x06003E51 RID: 15953 RVA: 0x000DC180 File Offset: 0x000DA380
		public static global::LightStyle.Mod operator /(global::LightStyle.Mod a, float b)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(element)) == global::LightStyle.Mod.ElementToMask(element))
				{
					a.SetFaceValue(element, a.GetFaceValue(element) / b);
				}
			}
			return a;
		}

		// Token: 0x06003E52 RID: 15954 RVA: 0x000DC1CC File Offset: 0x000DA3CC
		public static global::LightStyle.Mod operator +(global::LightStyle.Mod a, global::UnityEngine.Color b)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					a.SetFaceValue(global::LightStyle.Mod.Element.Red + i, a.GetFaceValue(global::LightStyle.Mod.Element.Red + i) + b[i]);
				}
			}
			return a;
		}

		// Token: 0x06003E53 RID: 15955 RVA: 0x000DC228 File Offset: 0x000DA428
		public static global::LightStyle.Mod operator -(global::LightStyle.Mod a, global::UnityEngine.Color b)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					a.SetFaceValue(global::LightStyle.Mod.Element.Red + i, a.GetFaceValue(global::LightStyle.Mod.Element.Red + i) - b[i]);
				}
			}
			return a;
		}

		// Token: 0x06003E54 RID: 15956 RVA: 0x000DC284 File Offset: 0x000DA484
		public static global::LightStyle.Mod operator *(global::LightStyle.Mod a, global::UnityEngine.Color b)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					a.SetFaceValue(global::LightStyle.Mod.Element.Red + i, a.GetFaceValue(global::LightStyle.Mod.Element.Red + i) * b[i]);
				}
			}
			return a;
		}

		// Token: 0x06003E55 RID: 15957 RVA: 0x000DC2E0 File Offset: 0x000DA4E0
		public static global::LightStyle.Mod operator /(global::LightStyle.Mod a, global::UnityEngine.Color b)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					a.SetFaceValue(global::LightStyle.Mod.Element.Red + i, a.GetFaceValue(global::LightStyle.Mod.Element.Red + i) / b[i]);
				}
			}
			return a;
		}

		// Token: 0x06003E56 RID: 15958 RVA: 0x000DC33C File Offset: 0x000DA53C
		public static global::UnityEngine.Color operator +(global::UnityEngine.Color b, global::LightStyle.Mod a)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					ref global::UnityEngine.Color ptr = ref b;
					int num2;
					int num = num2 = i;
					float num3 = ptr[num2];
					b[num] = num3 + a.GetFaceValue(global::LightStyle.Mod.Element.Red + i);
				}
			}
			return b;
		}

		// Token: 0x06003E57 RID: 15959 RVA: 0x000DC39C File Offset: 0x000DA59C
		public static global::UnityEngine.Color operator -(global::UnityEngine.Color b, global::LightStyle.Mod a)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					ref global::UnityEngine.Color ptr = ref b;
					int num2;
					int num = num2 = i;
					float num3 = ptr[num2];
					b[num] = num3 - a.GetFaceValue(global::LightStyle.Mod.Element.Red + i);
				}
			}
			return b;
		}

		// Token: 0x06003E58 RID: 15960 RVA: 0x000DC3FC File Offset: 0x000DA5FC
		public static global::UnityEngine.Color operator *(global::UnityEngine.Color b, global::LightStyle.Mod a)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					ref global::UnityEngine.Color ptr = ref b;
					int num2;
					int num = num2 = i;
					float num3 = ptr[num2];
					b[num] = num3 * a.GetFaceValue(global::LightStyle.Mod.Element.Red + i);
				}
			}
			return b;
		}

		// Token: 0x06003E59 RID: 15961 RVA: 0x000DC45C File Offset: 0x000DA65C
		public static global::UnityEngine.Color operator /(global::UnityEngine.Color b, global::LightStyle.Mod a)
		{
			for (int i = 0; i < 4; i++)
			{
				if ((a.mask & global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i)) == global::LightStyle.Mod.ElementToMask(global::LightStyle.Mod.Element.Red + i))
				{
					ref global::UnityEngine.Color ptr = ref b;
					int num2;
					int num = num2 = i;
					float num3 = ptr[num2];
					b[num] = num3 / a.GetFaceValue(global::LightStyle.Mod.Element.Red + i);
				}
			}
			return b;
		}

		// Token: 0x06003E5A RID: 15962 RVA: 0x000DC4BC File Offset: 0x000DA6BC
		public static global::LightStyle.Mod operator ~(global::LightStyle.Mod a)
		{
			a.mask = (~a.mask & (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle));
			return a;
		}

		// Token: 0x06003E5B RID: 15963 RVA: 0x000DC4D4 File Offset: 0x000DA6D4
		public static global::LightStyle.Mod operator -(global::LightStyle.Mod a)
		{
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				a.SetFaceValue(element, -a.GetFaceValue(element));
			}
			return a;
		}

		// Token: 0x06003E5C RID: 15964 RVA: 0x000DC508 File Offset: 0x000DA708
		public static bool operator true(global::LightStyle.Mod a)
		{
			return (a.mask & (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle)) != (global::LightStyle.Mod.Mask)0;
		}

		// Token: 0x06003E5D RID: 15965 RVA: 0x000DC51C File Offset: 0x000DA71C
		public static bool operator false(global::LightStyle.Mod b)
		{
			return (b.mask & (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle)) == (global::LightStyle.Mod.Mask)0;
		}

		// Token: 0x06003E5E RID: 15966 RVA: 0x000DC52C File Offset: 0x000DA72C
		public static explicit operator global::LightStyle.Mod(global::UnityEngine.Light light)
		{
			global::LightStyle.Mod result = default(global::LightStyle.Mod);
			if (light)
			{
				result.color = light.color;
				result.intensity = light.intensity;
				result.range = light.range;
				result.spotAngle = light.spotAngle;
				switch (light.type)
				{
				case 0:
					result.mask = (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle);
					break;
				case 1:
					result.mask = (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity);
					break;
				case 2:
					result.mask = (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range);
					break;
				}
			}
			return result;
		}

		// Token: 0x06003E5F RID: 15967 RVA: 0x000DC5CC File Offset: 0x000DA7CC
		public static explicit operator global::LightStyle.Mod(global::UnityEngine.Color color)
		{
			return new global::LightStyle.Mod
			{
				color = color,
				mask = (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha)
			};
		}

		// Token: 0x06003E60 RID: 15968 RVA: 0x000DC5F8 File Offset: 0x000DA7F8
		public static explicit operator global::LightStyle.Mod(float intensity)
		{
			return new global::LightStyle.Mod
			{
				intensity = intensity,
				mask = global::LightStyle.Mod.Mask.Intensity
			};
		}

		// Token: 0x04001FBC RID: 8124
		public const global::LightStyle.Mod.Element kElementFirst = global::LightStyle.Mod.Element.Red;

		// Token: 0x04001FBD RID: 8125
		public const global::LightStyle.Mod.Element kElementLast = global::LightStyle.Mod.Element.SpotAngle;

		// Token: 0x04001FBE RID: 8126
		public const global::LightStyle.Mod.Element kElementBegin = global::LightStyle.Mod.Element.Red;

		// Token: 0x04001FBF RID: 8127
		public const global::LightStyle.Mod.Element kElementEnd = (global::LightStyle.Mod.Element)7;

		// Token: 0x04001FC0 RID: 8128
		public const global::LightStyle.Mod.Element kElementEnumeratorBegin = (global::LightStyle.Mod.Element)(-1);

		// Token: 0x04001FC1 RID: 8129
		public const global::LightStyle.Mod.Mask kMaskNone = (global::LightStyle.Mod.Mask)0;

		// Token: 0x04001FC2 RID: 8130
		public const global::LightStyle.Mod.Mask kMaskRGB = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue;

		// Token: 0x04001FC3 RID: 8131
		public const global::LightStyle.Mod.Mask kMaskRGBA = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha;

		// Token: 0x04001FC4 RID: 8132
		public const global::LightStyle.Mod.Mask kMaskDirectionalLight = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity;

		// Token: 0x04001FC5 RID: 8133
		public const global::LightStyle.Mod.Mask kMaskPointLight = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range;

		// Token: 0x04001FC6 RID: 8134
		public const global::LightStyle.Mod.Mask kMaskSpotLight = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle;

		// Token: 0x04001FC7 RID: 8135
		public const global::LightStyle.Mod.Mask kMaskAll = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle;

		// Token: 0x04001FC8 RID: 8136
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::UnityEngine.Color color;

		// Token: 0x04001FC9 RID: 8137
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public float r;

		// Token: 0x04001FCA RID: 8138
		[global::System.Runtime.InteropServices.FieldOffset(4)]
		public float g;

		// Token: 0x04001FCB RID: 8139
		[global::System.Runtime.InteropServices.FieldOffset(8)]
		public float b;

		// Token: 0x04001FCC RID: 8140
		[global::System.Runtime.InteropServices.FieldOffset(0xC)]
		public float a;

		// Token: 0x04001FCD RID: 8141
		[global::System.Runtime.InteropServices.FieldOffset(0x10)]
		public float intensity;

		// Token: 0x04001FCE RID: 8142
		[global::System.Runtime.InteropServices.FieldOffset(0x14)]
		public float range;

		// Token: 0x04001FCF RID: 8143
		[global::System.Runtime.InteropServices.FieldOffset(0x18)]
		public float spotAngle;

		// Token: 0x04001FD0 RID: 8144
		[global::System.Runtime.InteropServices.FieldOffset(0x1C)]
		public global::LightStyle.Mod.Mask mask;

		// Token: 0x02000734 RID: 1844
		public enum Element
		{
			// Token: 0x04001FD2 RID: 8146
			Red,
			// Token: 0x04001FD3 RID: 8147
			Green,
			// Token: 0x04001FD4 RID: 8148
			Blue,
			// Token: 0x04001FD5 RID: 8149
			Alpha,
			// Token: 0x04001FD6 RID: 8150
			Intensity,
			// Token: 0x04001FD7 RID: 8151
			Range,
			// Token: 0x04001FD8 RID: 8152
			SpotAngle
		}

		// Token: 0x02000735 RID: 1845
		[global::System.Flags]
		public enum Mask
		{
			// Token: 0x04001FDA RID: 8154
			Red = 1,
			// Token: 0x04001FDB RID: 8155
			Green = 2,
			// Token: 0x04001FDC RID: 8156
			Blue = 4,
			// Token: 0x04001FDD RID: 8157
			Alpha = 8,
			// Token: 0x04001FDE RID: 8158
			Intensity = 0x10,
			// Token: 0x04001FDF RID: 8159
			Range = 0x20,
			// Token: 0x04001FE0 RID: 8160
			SpotAngle = 0x40
		}
	}

	// Token: 0x02000736 RID: 1846
	public abstract class Simulation : global::System.IDisposable
	{
		// Token: 0x06003E61 RID: 15969 RVA: 0x000DC624 File Offset: 0x000DA824
		protected Simulation(global::LightStyle creator)
		{
			this.creator = creator;
		}

		// Token: 0x17000BCC RID: 3020
		// (get) Token: 0x06003E62 RID: 15970 RVA: 0x000DC654 File Offset: 0x000DA854
		public bool alive
		{
			get
			{
				return !this.destroyed;
			}
		}

		// Token: 0x17000BCD RID: 3021
		// (get) Token: 0x06003E63 RID: 15971 RVA: 0x000DC660 File Offset: 0x000DA860
		public bool disposed
		{
			get
			{
				return this.destroyed;
			}
		}

		// Token: 0x06003E64 RID: 15972 RVA: 0x000DC668 File Offset: 0x000DA868
		public void ResetTime(double time)
		{
			if (this.startTime != time)
			{
				this.startTime = time;
				this.OnTimeReset();
			}
		}

		// Token: 0x06003E65 RID: 15973
		protected abstract void Simulate(double currentTime);

		// Token: 0x06003E66 RID: 15974 RVA: 0x000DC684 File Offset: 0x000DA884
		protected virtual void OnTimeReset()
		{
		}

		// Token: 0x06003E67 RID: 15975 RVA: 0x000DC688 File Offset: 0x000DA888
		private void UpdateBinding()
		{
			double time = global::LightStyle.time;
			if (time >= this.nextBindTime)
			{
				this.Simulate(time);
				this.lastSimulateTime = time;
			}
		}

		// Token: 0x06003E68 RID: 15976 RVA: 0x000DC6B8 File Offset: 0x000DA8B8
		public void BindToLight(global::UnityEngine.Light light)
		{
			if (this.destroyed)
			{
				return;
			}
			this.UpdateBinding();
			this.mod.ApplyTo(light);
		}

		// Token: 0x06003E69 RID: 15977 RVA: 0x000DC6D8 File Offset: 0x000DA8D8
		public global::LightStyle.Mod BindMod(global::LightStyle.Mod.Mask mask)
		{
			if (!this.destroyed)
			{
				this.UpdateBinding();
			}
			global::LightStyle.Mod result = this.mod;
			result.mask &= mask;
			return result;
		}

		// Token: 0x06003E6A RID: 15978 RVA: 0x000DC710 File Offset: 0x000DA910
		public void BindToLight(global::UnityEngine.Light light, global::LightStyle.Mod.Mask mask)
		{
			if (mask == (global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle))
			{
				this.BindToLight(light);
			}
			else
			{
				if (this.destroyed)
				{
					return;
				}
				this.UpdateBinding();
				if ((this.mod.mask & mask) != this.mod.mask)
				{
					global::LightStyle.Mod mod = this.mod;
					mod.mask &= mask;
					mod.ApplyTo(light);
				}
				else
				{
					this.mod.ApplyTo(light);
				}
			}
		}

		// Token: 0x06003E6B RID: 15979 RVA: 0x000DC790 File Offset: 0x000DA990
		public void Dispose()
		{
			if (this.isDisposing || this.destroyed)
			{
				return;
			}
			this.isDisposing = true;
			bool flag = true;
			try
			{
				flag = this.creator.DeconstructSimulation(this);
			}
			finally
			{
				this.isDisposing = false;
				this.destroyed = flag;
			}
		}

		// Token: 0x04001FE1 RID: 8161
		protected global::LightStyle creator;

		// Token: 0x04001FE2 RID: 8162
		protected global::LightStyle.Mod mod;

		// Token: 0x04001FE3 RID: 8163
		protected double startTime;

		// Token: 0x04001FE4 RID: 8164
		protected double nextBindTime = double.NegativeInfinity;

		// Token: 0x04001FE5 RID: 8165
		protected double lastSimulateTime = double.NegativeInfinity;

		// Token: 0x04001FE6 RID: 8166
		private bool isDisposing;

		// Token: 0x04001FE7 RID: 8167
		private bool destroyed;
	}

	// Token: 0x02000737 RID: 1847
	public abstract class Simulation<Style> : global::LightStyle.Simulation where Style : global::LightStyle
	{
		// Token: 0x06003E6C RID: 15980 RVA: 0x000DC7FC File Offset: 0x000DA9FC
		protected Simulation(Style creator) : base(creator)
		{
		}

		// Token: 0x17000BCE RID: 3022
		// (get) Token: 0x06003E6D RID: 15981 RVA: 0x000DC80C File Offset: 0x000DAA0C
		// (set) Token: 0x06003E6E RID: 15982 RVA: 0x000DC81C File Offset: 0x000DAA1C
		protected new Style creator
		{
			get
			{
				return (Style)((object)this.creator);
			}
			set
			{
				this.creator = value;
			}
		}
	}
}
