using System;
using UnityEngine;

// Token: 0x02000752 RID: 1874
public static class LocalPrefs
{
	// Token: 0x17000BD5 RID: 3029
	// (get) Token: 0x06003EB6 RID: 16054 RVA: 0x000DF918 File Offset: 0x000DDB18
	public static global::LocalPrefs.CameraModes CameraMode
	{
		get
		{
			return global::LocalPrefs.h.cameraModes;
		}
	}

	// Token: 0x02000753 RID: 1875
	public static class FootCameraMode
	{
		// Token: 0x17000BD6 RID: 3030
		// (get) Token: 0x06003EB7 RID: 16055 RVA: 0x000DF920 File Offset: 0x000DDB20
		// (set) Token: 0x06003EB8 RID: 16056 RVA: 0x000DF92C File Offset: 0x000DDB2C
		public static global::FootCameraMode Current
		{
			get
			{
				return (global::FootCameraMode)global::LocalPrefs.g.GetValue(ref global::LocalPrefs.g.s.footCameraMode);
			}
			set
			{
				global::LocalPrefs.g.SetValue(ref global::LocalPrefs.g.s.footCameraMode, new int?((int)value));
			}
		}

		// Token: 0x06003EB9 RID: 16057 RVA: 0x000DF940 File Offset: 0x000DDB40
		public static void Reset()
		{
			global::LocalPrefs.g.s.footCameraMode.Reset();
		}
	}

	// Token: 0x02000754 RID: 1876
	public static class MountedWeaponCameraMode
	{
		// Token: 0x17000BD7 RID: 3031
		// (get) Token: 0x06003EBA RID: 16058 RVA: 0x000DF94C File Offset: 0x000DDB4C
		// (set) Token: 0x06003EBB RID: 16059 RVA: 0x000DF958 File Offset: 0x000DDB58
		public static global::MountedWeaponCameraMode Current
		{
			get
			{
				return (global::MountedWeaponCameraMode)global::LocalPrefs.g.GetValue(ref global::LocalPrefs.g.s.mountedWeaponCameraMode);
			}
			set
			{
				global::LocalPrefs.g.SetValue(ref global::LocalPrefs.g.s.mountedWeaponCameraMode, new int?((int)value));
			}
		}

		// Token: 0x06003EBC RID: 16060 RVA: 0x000DF96C File Offset: 0x000DDB6C
		public static void Reset()
		{
			global::LocalPrefs.g.s.mountedWeaponCameraMode.Reset();
		}
	}

	// Token: 0x02000755 RID: 1877
	public static class CarCameraMode
	{
		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x06003EBD RID: 16061 RVA: 0x000DF978 File Offset: 0x000DDB78
		// (set) Token: 0x06003EBE RID: 16062 RVA: 0x000DF984 File Offset: 0x000DDB84
		public static global::CarCameraMode Current
		{
			get
			{
				return (global::CarCameraMode)global::LocalPrefs.g.GetValue(ref global::LocalPrefs.g.s.carCameraMode);
			}
			set
			{
				global::LocalPrefs.g.SetValue(ref global::LocalPrefs.g.s.carCameraMode, new int?((int)value));
			}
		}

		// Token: 0x06003EBF RID: 16063 RVA: 0x000DF998 File Offset: 0x000DDB98
		public static void Reset()
		{
			global::LocalPrefs.g.s.carCameraMode.Reset();
		}
	}

	// Token: 0x02000756 RID: 1878
	public static class JetCameraMode
	{
		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x06003EC0 RID: 16064 RVA: 0x000DF9A4 File Offset: 0x000DDBA4
		// (set) Token: 0x06003EC1 RID: 16065 RVA: 0x000DF9B0 File Offset: 0x000DDBB0
		public static global::JetCameraMode Current
		{
			get
			{
				return (global::JetCameraMode)global::LocalPrefs.g.GetValue(ref global::LocalPrefs.g.s.jetCameraMode);
			}
			set
			{
				global::LocalPrefs.g.SetValue(ref global::LocalPrefs.g.s.jetCameraMode, new int?((int)value));
			}
		}

		// Token: 0x06003EC2 RID: 16066 RVA: 0x000DF9C4 File Offset: 0x000DDBC4
		public static void Reset()
		{
			global::LocalPrefs.g.s.jetCameraMode.Reset();
		}
	}

	// Token: 0x02000757 RID: 1879
	public static class HeliCameraMode
	{
		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x06003EC3 RID: 16067 RVA: 0x000DF9D0 File Offset: 0x000DDBD0
		// (set) Token: 0x06003EC4 RID: 16068 RVA: 0x000DF9DC File Offset: 0x000DDBDC
		public static global::HeliCameraMode Current
		{
			get
			{
				return (global::HeliCameraMode)global::LocalPrefs.g.GetValue(ref global::LocalPrefs.g.s.heliCameraMode);
			}
			set
			{
				global::LocalPrefs.g.SetValue(ref global::LocalPrefs.g.s.heliCameraMode, new int?((int)value));
			}
		}

		// Token: 0x06003EC5 RID: 16069 RVA: 0x000DF9F0 File Offset: 0x000DDBF0
		public static void Reset()
		{
			global::LocalPrefs.g.s.heliCameraMode.Reset();
		}
	}

	// Token: 0x02000758 RID: 1880
	public static class BoatCameraMode
	{
		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x06003EC6 RID: 16070 RVA: 0x000DF9FC File Offset: 0x000DDBFC
		// (set) Token: 0x06003EC7 RID: 16071 RVA: 0x000DFA08 File Offset: 0x000DDC08
		public static global::BoatCameraMode Current
		{
			get
			{
				return (global::BoatCameraMode)global::LocalPrefs.g.GetValue(ref global::LocalPrefs.g.s.boatCameraMode);
			}
			set
			{
				global::LocalPrefs.g.SetValue(ref global::LocalPrefs.g.s.boatCameraMode, new int?((int)value));
			}
		}

		// Token: 0x06003EC8 RID: 16072 RVA: 0x000DFA1C File Offset: 0x000DDC1C
		public static void Reset()
		{
			global::LocalPrefs.g.s.boatCameraMode.Reset();
		}
	}

	// Token: 0x02000759 RID: 1881
	public class CameraModes
	{
		// Token: 0x06003EC9 RID: 16073 RVA: 0x000DFA28 File Offset: 0x000DDC28
		public CameraModes()
		{
		}

		// Token: 0x17000BDC RID: 3036
		public global::SharedCameraMode this[global::KindOfCamera kind]
		{
			get
			{
				switch (kind)
				{
				case global::KindOfCamera.Foot:
					return (global::SharedCameraMode)global::LocalPrefs.FootCameraMode.Current;
				case global::KindOfCamera.MountedWeapon:
					return (global::SharedCameraMode)global::LocalPrefs.MountedWeaponCameraMode.Current;
				case global::KindOfCamera.Car:
					return (global::SharedCameraMode)global::LocalPrefs.CarCameraMode.Current;
				case global::KindOfCamera.Boat:
					return (global::SharedCameraMode)global::LocalPrefs.BoatCameraMode.Current;
				case global::KindOfCamera.Jet:
					return (global::SharedCameraMode)global::LocalPrefs.JetCameraMode.Current;
				case global::KindOfCamera.Heli:
					return (global::SharedCameraMode)global::LocalPrefs.HeliCameraMode.Current;
				}
				return global::SharedCameraMode.Undefined;
			}
			set
			{
				switch (kind)
				{
				case global::KindOfCamera.Foot:
					global::LocalPrefs.FootCameraMode.Current = (global::FootCameraMode)value;
					break;
				case global::KindOfCamera.MountedWeapon:
					global::LocalPrefs.MountedWeaponCameraMode.Current = (global::MountedWeaponCameraMode)value;
					break;
				case global::KindOfCamera.Car:
					global::LocalPrefs.CarCameraMode.Current = (global::CarCameraMode)value;
					break;
				case global::KindOfCamera.Boat:
					global::LocalPrefs.BoatCameraMode.Current = (global::BoatCameraMode)value;
					break;
				case global::KindOfCamera.Jet:
					global::LocalPrefs.JetCameraMode.Current = (global::JetCameraMode)value;
					break;
				case global::KindOfCamera.Heli:
					global::LocalPrefs.HeliCameraMode.Current = (global::HeliCameraMode)value;
					break;
				}
			}
		}
	}

	// Token: 0x0200075A RID: 1882
	private static class h
	{
		// Token: 0x06003ECC RID: 16076 RVA: 0x000DFB04 File Offset: 0x000DDD04
		// Note: this type is marked as 'beforefieldinit'.
		static h()
		{
		}

		// Token: 0x04002056 RID: 8278
		public static readonly global::LocalPrefs.CameraModes cameraModes = new global::LocalPrefs.CameraModes();
	}

	// Token: 0x0200075B RID: 1883
	private static class g
	{
		// Token: 0x06003ECD RID: 16077 RVA: 0x000DFB10 File Offset: 0x000DDD10
		private static bool NeedSetValue<T>(ref global::LocalPrefs.g.KeyDefault<T> k, bool isNull)
		{
			if (isNull)
			{
				if (k.set || k.Init())
				{
					k.Reset();
				}
				return false;
			}
			k.Init();
			return true;
		}

		// Token: 0x06003ECE RID: 16078 RVA: 0x000DFB4C File Offset: 0x000DDD4C
		private static bool NeedSetValue<T>(ref global::LocalPrefs.g.KeyDefault<T> k, T? value) where T : struct
		{
			if (global::LocalPrefs.g.NeedSetValue<T>(ref k, value == null))
			{
				k.value = value.Value;
				return true;
			}
			return false;
		}

		// Token: 0x06003ECF RID: 16079 RVA: 0x000DFB74 File Offset: 0x000DDD74
		private static bool NeedSetValue<T>(ref global::LocalPrefs.g.KeyDefault<T> k, T value) where T : class
		{
			if (global::LocalPrefs.g.NeedSetValue<T>(ref k, value == null))
			{
				k.value = value;
				return true;
			}
			return false;
		}

		// Token: 0x06003ED0 RID: 16080 RVA: 0x000DFB94 File Offset: 0x000DDD94
		public static int GetValue(ref global::LocalPrefs.g.KeyDefault<int> k)
		{
			if (k.Init())
			{
				k.value = global::UnityEngine.PlayerPrefs.GetInt(k.key);
			}
			return k.value;
		}

		// Token: 0x06003ED1 RID: 16081 RVA: 0x000DFBC4 File Offset: 0x000DDDC4
		public static float GetValue(ref global::LocalPrefs.g.KeyDefault<float> k)
		{
			if (k.Init())
			{
				k.value = global::UnityEngine.PlayerPrefs.GetFloat(k.key);
			}
			return k.value;
		}

		// Token: 0x06003ED2 RID: 16082 RVA: 0x000DFBF4 File Offset: 0x000DDDF4
		public static string GetValue(ref global::LocalPrefs.g.KeyDefault<string> k)
		{
			if (k.Init())
			{
				k.value = global::UnityEngine.PlayerPrefs.GetString(k.key);
			}
			return k.value;
		}

		// Token: 0x06003ED3 RID: 16083 RVA: 0x000DFC24 File Offset: 0x000DDE24
		public static bool GetValue(ref global::LocalPrefs.g.KeyDefault<bool> k)
		{
			if (k.Init())
			{
				k.value = (global::UnityEngine.PlayerPrefs.GetInt(k.key) != 0);
			}
			return k.value;
		}

		// Token: 0x06003ED4 RID: 16084 RVA: 0x000DFC5C File Offset: 0x000DDE5C
		public static void SetValue(ref global::LocalPrefs.g.KeyDefault<int> k, int? value)
		{
			if ((global::LocalPrefs.g.NeedSetValue<int>(ref k, value) && !k.set) || k.value != value.Value)
			{
				global::UnityEngine.PlayerPrefs.SetInt(k.key, value.Value);
			}
		}

		// Token: 0x06003ED5 RID: 16085 RVA: 0x000DFC9C File Offset: 0x000DDE9C
		public static void SetValue(ref global::LocalPrefs.g.KeyDefault<float> k, float? value)
		{
			if ((global::LocalPrefs.g.NeedSetValue<float>(ref k, value) && !k.set) || k.value != value.Value)
			{
				global::UnityEngine.PlayerPrefs.SetFloat(k.key, value.Value);
			}
		}

		// Token: 0x06003ED6 RID: 16086 RVA: 0x000DFCDC File Offset: 0x000DDEDC
		public static void SetValue(ref global::LocalPrefs.g.KeyDefault<string> k, string value)
		{
			if ((global::LocalPrefs.g.NeedSetValue<string>(ref k, value) && !k.set) || k.value != value)
			{
				global::UnityEngine.PlayerPrefs.SetString(k.key, value);
			}
		}

		// Token: 0x06003ED7 RID: 16087 RVA: 0x000DFD20 File Offset: 0x000DDF20
		public static void SetValue(ref global::LocalPrefs.g.KeyDefault<bool> k, bool? value)
		{
			if ((global::LocalPrefs.g.NeedSetValue<bool>(ref k, value) && !k.set) || k.value != value.Value)
			{
				global::UnityEngine.PlayerPrefs.SetInt(k.key, (!value.Value) ? 0 : 1);
			}
		}

		// Token: 0x06003ED8 RID: 16088 RVA: 0x000DFD74 File Offset: 0x000DDF74
		private static global::LocalPrefs.g.KeyDefault<T> New<T>(string key, T @default)
		{
			return new global::LocalPrefs.g.KeyDefault<T>(key, @default);
		}

		// Token: 0x06003ED9 RID: 16089 RVA: 0x000DFD80 File Offset: 0x000DDF80
		private static global::LocalPrefs.g.KeyDefault<int> New(string key, global::System.Enum @default)
		{
			return new global::LocalPrefs.g.KeyDefault<int>(key, global::System.Convert.ToInt32(@default));
		}

		// Token: 0x0200075C RID: 1884
		public struct KeyDefault<T>
		{
			// Token: 0x06003EDA RID: 16090 RVA: 0x000DFD90 File Offset: 0x000DDF90
			public KeyDefault(string key, T value)
			{
				this.key = key;
				this.@default = value;
				this.value = this.@default;
				this.uninit = false;
				this.set = false;
			}

			// Token: 0x06003EDB RID: 16091 RVA: 0x000DFDC8 File Offset: 0x000DDFC8
			public bool Init()
			{
				if (!this.uninit)
				{
					return false;
				}
				this.set = global::UnityEngine.PlayerPrefs.HasKey(this.key);
				this.uninit = false;
				if (this.set)
				{
					return true;
				}
				this.value = this.@default;
				return false;
			}

			// Token: 0x06003EDC RID: 16092 RVA: 0x000DFE14 File Offset: 0x000DE014
			public void Reset()
			{
				if (this.set || this.Init())
				{
					global::UnityEngine.PlayerPrefs.DeleteKey(this.key);
					this.set = false;
					this.value = this.@default;
				}
			}

			// Token: 0x04002057 RID: 8279
			public readonly string key;

			// Token: 0x04002058 RID: 8280
			public readonly T @default;

			// Token: 0x04002059 RID: 8281
			public T value;

			// Token: 0x0400205A RID: 8282
			public bool uninit;

			// Token: 0x0400205B RID: 8283
			public bool set;
		}

		// Token: 0x0200075D RID: 1885
		public static class s
		{
			// Token: 0x06003EDD RID: 16093 RVA: 0x000DFE58 File Offset: 0x000DE058
			// Note: this type is marked as 'beforefieldinit'.
			static s()
			{
			}

			// Token: 0x0400205C RID: 8284
			public static global::LocalPrefs.g.KeyDefault<int> footCameraMode = global::LocalPrefs.g.New<int>("foot_cam", 1);

			// Token: 0x0400205D RID: 8285
			public static global::LocalPrefs.g.KeyDefault<int> mountedWeaponCameraMode = global::LocalPrefs.g.New<int>("mwep_cam", 1);

			// Token: 0x0400205E RID: 8286
			public static global::LocalPrefs.g.KeyDefault<int> carCameraMode = global::LocalPrefs.g.New<int>("car_cam", 2);

			// Token: 0x0400205F RID: 8287
			public static global::LocalPrefs.g.KeyDefault<int> passengerCameraMode = global::LocalPrefs.g.New<int>("pass_cam", 1);

			// Token: 0x04002060 RID: 8288
			public static global::LocalPrefs.g.KeyDefault<int> jetCameraMode = global::LocalPrefs.g.New<int>("jet_cam", 2);

			// Token: 0x04002061 RID: 8289
			public static global::LocalPrefs.g.KeyDefault<int> heliCameraMode = global::LocalPrefs.g.New<int>("heli_cam", 2);

			// Token: 0x04002062 RID: 8290
			public static global::LocalPrefs.g.KeyDefault<int> boatCameraMode = global::LocalPrefs.g.New<int>("boat_cam", 2);
		}
	}
}
