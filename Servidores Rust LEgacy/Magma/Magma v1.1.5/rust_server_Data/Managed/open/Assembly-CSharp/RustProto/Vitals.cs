using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x0200023D RID: 573
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Vitals : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Vitals, global::RustProto.Vitals.Builder>
	{
		// Token: 0x06000FF3 RID: 4083 RVA: 0x0003C8EC File Offset: 0x0003AAEC
		private Vitals()
		{
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x0003C928 File Offset: 0x0003AB28
		static Vitals()
		{
			object.ReferenceEquals(global::RustProto.Proto.Vitals.Descriptor, null);
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x0003C9C4 File Offset: 0x0003ABC4
		public static global::RustProto.Helpers.Recycler<global::RustProto.Vitals, global::RustProto.Vitals.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.Vitals, global::RustProto.Vitals.Builder>.Manufacture();
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x0003C9CC File Offset: 0x0003ABCC
		public static global::RustProto.Vitals DefaultInstance
		{
			get
			{
				return global::RustProto.Vitals.defaultInstance;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x0003C9D4 File Offset: 0x0003ABD4
		public override global::RustProto.Vitals DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Vitals.DefaultInstance;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x0003C9DC File Offset: 0x0003ABDC
		protected override global::RustProto.Vitals ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x0003C9E0 File Offset: 0x0003ABE0
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__Descriptor;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x0003C9E8 File Offset: 0x0003ABE8
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vitals, global::RustProto.Vitals.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__FieldAccessorTable;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000FFB RID: 4091 RVA: 0x0003C9F0 File Offset: 0x0003ABF0
		public bool HasHealth
		{
			get
			{
				return this.hasHealth;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000FFC RID: 4092 RVA: 0x0003C9F8 File Offset: 0x0003ABF8
		public float Health
		{
			get
			{
				return this.health_;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x0003CA00 File Offset: 0x0003AC00
		public bool HasHydration
		{
			get
			{
				return this.hasHydration;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000FFE RID: 4094 RVA: 0x0003CA08 File Offset: 0x0003AC08
		public float Hydration
		{
			get
			{
				return this.hydration_;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x0003CA10 File Offset: 0x0003AC10
		public bool HasCalories
		{
			get
			{
				return this.hasCalories;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x0003CA18 File Offset: 0x0003AC18
		public float Calories
		{
			get
			{
				return this.calories_;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x0003CA20 File Offset: 0x0003AC20
		public bool HasRadiation
		{
			get
			{
				return this.hasRadiation;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06001002 RID: 4098 RVA: 0x0003CA28 File Offset: 0x0003AC28
		public float Radiation
		{
			get
			{
				return this.radiation_;
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x0003CA30 File Offset: 0x0003AC30
		public bool HasRadiationAnti
		{
			get
			{
				return this.hasRadiationAnti;
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06001004 RID: 4100 RVA: 0x0003CA38 File Offset: 0x0003AC38
		public float RadiationAnti
		{
			get
			{
				return this.radiationAnti_;
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x0003CA40 File Offset: 0x0003AC40
		public bool HasBleedSpeed
		{
			get
			{
				return this.hasBleedSpeed;
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06001006 RID: 4102 RVA: 0x0003CA48 File Offset: 0x0003AC48
		public float BleedSpeed
		{
			get
			{
				return this.bleedSpeed_;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x0003CA50 File Offset: 0x0003AC50
		public bool HasBleedMax
		{
			get
			{
				return this.hasBleedMax;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06001008 RID: 4104 RVA: 0x0003CA58 File Offset: 0x0003AC58
		public float BleedMax
		{
			get
			{
				return this.bleedMax_;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x0003CA60 File Offset: 0x0003AC60
		public bool HasHealSpeed
		{
			get
			{
				return this.hasHealSpeed;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x0003CA68 File Offset: 0x0003AC68
		public float HealSpeed
		{
			get
			{
				return this.healSpeed_;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x0600100B RID: 4107 RVA: 0x0003CA70 File Offset: 0x0003AC70
		public bool HasHealMax
		{
			get
			{
				return this.hasHealMax;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x0600100C RID: 4108 RVA: 0x0003CA78 File Offset: 0x0003AC78
		public float HealMax
		{
			get
			{
				return this.healMax_;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x0600100D RID: 4109 RVA: 0x0003CA80 File Offset: 0x0003AC80
		public bool HasTemperature
		{
			get
			{
				return this.hasTemperature;
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x0600100E RID: 4110 RVA: 0x0003CA88 File Offset: 0x0003AC88
		public float Temperature
		{
			get
			{
				return this.temperature_;
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x0600100F RID: 4111 RVA: 0x0003CA90 File Offset: 0x0003AC90
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0003CA94 File Offset: 0x0003AC94
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] vitalsFieldNames = global::RustProto.Vitals._vitalsFieldNames;
			if (this.hasHealth)
			{
				output.WriteFloat(1, vitalsFieldNames[5], this.Health);
			}
			if (this.hasHydration)
			{
				output.WriteFloat(2, vitalsFieldNames[6], this.Hydration);
			}
			if (this.hasCalories)
			{
				output.WriteFloat(3, vitalsFieldNames[2], this.Calories);
			}
			if (this.hasRadiation)
			{
				output.WriteFloat(4, vitalsFieldNames[7], this.Radiation);
			}
			if (this.hasRadiationAnti)
			{
				output.WriteFloat(5, vitalsFieldNames[8], this.RadiationAnti);
			}
			if (this.hasBleedSpeed)
			{
				output.WriteFloat(6, vitalsFieldNames[1], this.BleedSpeed);
			}
			if (this.hasBleedMax)
			{
				output.WriteFloat(7, vitalsFieldNames[0], this.BleedMax);
			}
			if (this.hasHealSpeed)
			{
				output.WriteFloat(8, vitalsFieldNames[4], this.HealSpeed);
			}
			if (this.hasHealMax)
			{
				output.WriteFloat(9, vitalsFieldNames[3], this.HealMax);
			}
			if (this.hasTemperature)
			{
				output.WriteFloat(0xA, vitalsFieldNames[9], this.Temperature);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06001011 RID: 4113 RVA: 0x0003CBCC File Offset: 0x0003ADCC
		public override int SerializedSize
		{
			get
			{
				int num = this.memoizedSerializedSize;
				if (num != -1)
				{
					return num;
				}
				num = 0;
				if (this.hasHealth)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(1, this.Health);
				}
				if (this.hasHydration)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(2, this.Hydration);
				}
				if (this.hasCalories)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(3, this.Calories);
				}
				if (this.hasRadiation)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(4, this.Radiation);
				}
				if (this.hasRadiationAnti)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(5, this.RadiationAnti);
				}
				if (this.hasBleedSpeed)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(6, this.BleedSpeed);
				}
				if (this.hasBleedMax)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(7, this.BleedMax);
				}
				if (this.hasHealSpeed)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(8, this.HealSpeed);
				}
				if (this.hasHealMax)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(9, this.HealMax);
				}
				if (this.hasTemperature)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(0xA, this.Temperature);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x0003CD08 File Offset: 0x0003AF08
		public static global::RustProto.Vitals ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0003CD1C File Offset: 0x0003AF1C
		public static global::RustProto.Vitals ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0003CD30 File Offset: 0x0003AF30
		public static global::RustProto.Vitals ParseFrom(byte[] data)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x0003CD44 File Offset: 0x0003AF44
		public static global::RustProto.Vitals ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0003CD58 File Offset: 0x0003AF58
		public static global::RustProto.Vitals ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x0003CD6C File Offset: 0x0003AF6C
		public static global::RustProto.Vitals ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0003CD80 File Offset: 0x0003AF80
		public static global::RustProto.Vitals ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x0003CD94 File Offset: 0x0003AF94
		public static global::RustProto.Vitals ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x0003CDA8 File Offset: 0x0003AFA8
		public static global::RustProto.Vitals ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0003CDBC File Offset: 0x0003AFBC
		public static global::RustProto.Vitals ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vitals.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x0003CDD0 File Offset: 0x0003AFD0
		private global::RustProto.Vitals MakeReadOnly()
		{
			return this;
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0003CDD4 File Offset: 0x0003AFD4
		public static global::RustProto.Vitals.Builder CreateBuilder()
		{
			return new global::RustProto.Vitals.Builder();
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0003CDDC File Offset: 0x0003AFDC
		public override global::RustProto.Vitals.Builder ToBuilder()
		{
			return global::RustProto.Vitals.CreateBuilder(this);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0003CDE4 File Offset: 0x0003AFE4
		public override global::RustProto.Vitals.Builder CreateBuilderForType()
		{
			return new global::RustProto.Vitals.Builder();
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0003CDEC File Offset: 0x0003AFEC
		public static global::RustProto.Vitals.Builder CreateBuilder(global::RustProto.Vitals prototype)
		{
			return new global::RustProto.Vitals.Builder(prototype);
		}

		// Token: 0x040009DD RID: 2525
		public const int HealthFieldNumber = 1;

		// Token: 0x040009DE RID: 2526
		public const int HydrationFieldNumber = 2;

		// Token: 0x040009DF RID: 2527
		public const int CaloriesFieldNumber = 3;

		// Token: 0x040009E0 RID: 2528
		public const int RadiationFieldNumber = 4;

		// Token: 0x040009E1 RID: 2529
		public const int RadiationAntiFieldNumber = 5;

		// Token: 0x040009E2 RID: 2530
		public const int BleedSpeedFieldNumber = 6;

		// Token: 0x040009E3 RID: 2531
		public const int BleedMaxFieldNumber = 7;

		// Token: 0x040009E4 RID: 2532
		public const int HealSpeedFieldNumber = 8;

		// Token: 0x040009E5 RID: 2533
		public const int HealMaxFieldNumber = 9;

		// Token: 0x040009E6 RID: 2534
		public const int TemperatureFieldNumber = 0xA;

		// Token: 0x040009E7 RID: 2535
		private static readonly global::RustProto.Vitals defaultInstance = new global::RustProto.Vitals().MakeReadOnly();

		// Token: 0x040009E8 RID: 2536
		private static readonly string[] _vitalsFieldNames = new string[]
		{
			"bleed_max",
			"bleed_speed",
			"calories",
			"heal_max",
			"heal_speed",
			"health",
			"hydration",
			"radiation",
			"radiation_anti",
			"temperature"
		};

		// Token: 0x040009E9 RID: 2537
		private static readonly uint[] _vitalsFieldTags = new uint[]
		{
			0x3DU,
			0x35U,
			0x1DU,
			0x4DU,
			0x45U,
			0xDU,
			0x15U,
			0x25U,
			0x2DU,
			0x55U
		};

		// Token: 0x040009EA RID: 2538
		private bool hasHealth;

		// Token: 0x040009EB RID: 2539
		private float health_ = 100f;

		// Token: 0x040009EC RID: 2540
		private bool hasHydration;

		// Token: 0x040009ED RID: 2541
		private float hydration_ = 30f;

		// Token: 0x040009EE RID: 2542
		private bool hasCalories;

		// Token: 0x040009EF RID: 2543
		private float calories_ = 1000f;

		// Token: 0x040009F0 RID: 2544
		private bool hasRadiation;

		// Token: 0x040009F1 RID: 2545
		private float radiation_;

		// Token: 0x040009F2 RID: 2546
		private bool hasRadiationAnti;

		// Token: 0x040009F3 RID: 2547
		private float radiationAnti_;

		// Token: 0x040009F4 RID: 2548
		private bool hasBleedSpeed;

		// Token: 0x040009F5 RID: 2549
		private float bleedSpeed_;

		// Token: 0x040009F6 RID: 2550
		private bool hasBleedMax;

		// Token: 0x040009F7 RID: 2551
		private float bleedMax_;

		// Token: 0x040009F8 RID: 2552
		private bool hasHealSpeed;

		// Token: 0x040009F9 RID: 2553
		private float healSpeed_;

		// Token: 0x040009FA RID: 2554
		private bool hasHealMax;

		// Token: 0x040009FB RID: 2555
		private float healMax_;

		// Token: 0x040009FC RID: 2556
		private bool hasTemperature;

		// Token: 0x040009FD RID: 2557
		private float temperature_;

		// Token: 0x040009FE RID: 2558
		private int memoizedSerializedSize = -1;

		// Token: 0x0200023E RID: 574
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Vitals, global::RustProto.Vitals.Builder>
		{
			// Token: 0x06001021 RID: 4129 RVA: 0x0003CDF4 File Offset: 0x0003AFF4
			public Builder()
			{
				this.result = global::RustProto.Vitals.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001022 RID: 4130 RVA: 0x0003CE10 File Offset: 0x0003B010
			internal Builder(global::RustProto.Vitals cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170003E4 RID: 996
			// (get) Token: 0x06001023 RID: 4131 RVA: 0x0003CE28 File Offset: 0x0003B028
			protected override global::RustProto.Vitals.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001024 RID: 4132 RVA: 0x0003CE2C File Offset: 0x0003B02C
			private global::RustProto.Vitals PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Vitals other = this.result;
					this.result = new global::RustProto.Vitals();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170003E5 RID: 997
			// (get) Token: 0x06001025 RID: 4133 RVA: 0x0003CE6C File Offset: 0x0003B06C
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170003E6 RID: 998
			// (get) Token: 0x06001026 RID: 4134 RVA: 0x0003CE7C File Offset: 0x0003B07C
			protected override global::RustProto.Vitals MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001027 RID: 4135 RVA: 0x0003CE84 File Offset: 0x0003B084
			public override global::RustProto.Vitals.Builder Clear()
			{
				this.result = global::RustProto.Vitals.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001028 RID: 4136 RVA: 0x0003CE9C File Offset: 0x0003B09C
			public override global::RustProto.Vitals.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Vitals.Builder(this.result);
				}
				return new global::RustProto.Vitals.Builder().MergeFrom(this.result);
			}

			// Token: 0x170003E7 RID: 999
			// (get) Token: 0x06001029 RID: 4137 RVA: 0x0003CEC8 File Offset: 0x0003B0C8
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Vitals.Descriptor;
				}
			}

			// Token: 0x170003E8 RID: 1000
			// (get) Token: 0x0600102A RID: 4138 RVA: 0x0003CED0 File Offset: 0x0003B0D0
			public override global::RustProto.Vitals DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Vitals.DefaultInstance;
				}
			}

			// Token: 0x0600102B RID: 4139 RVA: 0x0003CED8 File Offset: 0x0003B0D8
			public override global::RustProto.Vitals BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x0600102C RID: 4140 RVA: 0x0003CF0C File Offset: 0x0003B10C
			public override global::RustProto.Vitals.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Vitals)
				{
					return this.MergeFrom((global::RustProto.Vitals)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x0600102D RID: 4141 RVA: 0x0003CF30 File Offset: 0x0003B130
			public override global::RustProto.Vitals.Builder MergeFrom(global::RustProto.Vitals other)
			{
				if (other == global::RustProto.Vitals.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasHealth)
				{
					this.Health = other.Health;
				}
				if (other.HasHydration)
				{
					this.Hydration = other.Hydration;
				}
				if (other.HasCalories)
				{
					this.Calories = other.Calories;
				}
				if (other.HasRadiation)
				{
					this.Radiation = other.Radiation;
				}
				if (other.HasRadiationAnti)
				{
					this.RadiationAnti = other.RadiationAnti;
				}
				if (other.HasBleedSpeed)
				{
					this.BleedSpeed = other.BleedSpeed;
				}
				if (other.HasBleedMax)
				{
					this.BleedMax = other.BleedMax;
				}
				if (other.HasHealSpeed)
				{
					this.HealSpeed = other.HealSpeed;
				}
				if (other.HasHealMax)
				{
					this.HealMax = other.HealMax;
				}
				if (other.HasTemperature)
				{
					this.Temperature = other.Temperature;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600102E RID: 4142 RVA: 0x0003D048 File Offset: 0x0003B248
			public override global::RustProto.Vitals.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x0600102F RID: 4143 RVA: 0x0003D058 File Offset: 0x0003B258
			public override global::RustProto.Vitals.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Vitals._vitalsFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Vitals._vitalsFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 0xDU)
					{
						if (num3 != 0x15U)
						{
							if (num3 != 0x1DU)
							{
								if (num3 != 0x25U)
								{
									if (num3 != 0x2DU)
									{
										if (num3 != 0x35U)
										{
											if (num3 != 0x3DU)
											{
												if (num3 != 0x45U)
												{
													if (num3 != 0x4DU)
													{
														if (num3 != 0x55U)
														{
															if (global::Google.ProtocolBuffers.WireFormat.IsEndGroupTag(num))
															{
																if (builder != null)
																{
																	this.UnknownFields = builder.Build();
																}
																return this;
															}
															if (builder == null)
															{
																builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
															}
															this.ParseUnknownField(input, builder, extensionRegistry, num, text);
														}
														else
														{
															this.result.hasTemperature = input.ReadFloat(ref this.result.temperature_);
														}
													}
													else
													{
														this.result.hasHealMax = input.ReadFloat(ref this.result.healMax_);
													}
												}
												else
												{
													this.result.hasHealSpeed = input.ReadFloat(ref this.result.healSpeed_);
												}
											}
											else
											{
												this.result.hasBleedMax = input.ReadFloat(ref this.result.bleedMax_);
											}
										}
										else
										{
											this.result.hasBleedSpeed = input.ReadFloat(ref this.result.bleedSpeed_);
										}
									}
									else
									{
										this.result.hasRadiationAnti = input.ReadFloat(ref this.result.radiationAnti_);
									}
								}
								else
								{
									this.result.hasRadiation = input.ReadFloat(ref this.result.radiation_);
								}
							}
							else
							{
								this.result.hasCalories = input.ReadFloat(ref this.result.calories_);
							}
						}
						else
						{
							this.result.hasHydration = input.ReadFloat(ref this.result.hydration_);
						}
					}
					else
					{
						this.result.hasHealth = input.ReadFloat(ref this.result.health_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170003E9 RID: 1001
			// (get) Token: 0x06001030 RID: 4144 RVA: 0x0003D2E8 File Offset: 0x0003B4E8
			public bool HasHealth
			{
				get
				{
					return this.result.hasHealth;
				}
			}

			// Token: 0x170003EA RID: 1002
			// (get) Token: 0x06001031 RID: 4145 RVA: 0x0003D2F8 File Offset: 0x0003B4F8
			// (set) Token: 0x06001032 RID: 4146 RVA: 0x0003D308 File Offset: 0x0003B508
			public float Health
			{
				get
				{
					return this.result.Health;
				}
				set
				{
					this.SetHealth(value);
				}
			}

			// Token: 0x06001033 RID: 4147 RVA: 0x0003D314 File Offset: 0x0003B514
			public global::RustProto.Vitals.Builder SetHealth(float value)
			{
				this.PrepareBuilder();
				this.result.hasHealth = true;
				this.result.health_ = value;
				return this;
			}

			// Token: 0x06001034 RID: 4148 RVA: 0x0003D344 File Offset: 0x0003B544
			public global::RustProto.Vitals.Builder ClearHealth()
			{
				this.PrepareBuilder();
				this.result.hasHealth = false;
				this.result.health_ = 100f;
				return this;
			}

			// Token: 0x170003EB RID: 1003
			// (get) Token: 0x06001035 RID: 4149 RVA: 0x0003D378 File Offset: 0x0003B578
			public bool HasHydration
			{
				get
				{
					return this.result.hasHydration;
				}
			}

			// Token: 0x170003EC RID: 1004
			// (get) Token: 0x06001036 RID: 4150 RVA: 0x0003D388 File Offset: 0x0003B588
			// (set) Token: 0x06001037 RID: 4151 RVA: 0x0003D398 File Offset: 0x0003B598
			public float Hydration
			{
				get
				{
					return this.result.Hydration;
				}
				set
				{
					this.SetHydration(value);
				}
			}

			// Token: 0x06001038 RID: 4152 RVA: 0x0003D3A4 File Offset: 0x0003B5A4
			public global::RustProto.Vitals.Builder SetHydration(float value)
			{
				this.PrepareBuilder();
				this.result.hasHydration = true;
				this.result.hydration_ = value;
				return this;
			}

			// Token: 0x06001039 RID: 4153 RVA: 0x0003D3D4 File Offset: 0x0003B5D4
			public global::RustProto.Vitals.Builder ClearHydration()
			{
				this.PrepareBuilder();
				this.result.hasHydration = false;
				this.result.hydration_ = 30f;
				return this;
			}

			// Token: 0x170003ED RID: 1005
			// (get) Token: 0x0600103A RID: 4154 RVA: 0x0003D408 File Offset: 0x0003B608
			public bool HasCalories
			{
				get
				{
					return this.result.hasCalories;
				}
			}

			// Token: 0x170003EE RID: 1006
			// (get) Token: 0x0600103B RID: 4155 RVA: 0x0003D418 File Offset: 0x0003B618
			// (set) Token: 0x0600103C RID: 4156 RVA: 0x0003D428 File Offset: 0x0003B628
			public float Calories
			{
				get
				{
					return this.result.Calories;
				}
				set
				{
					this.SetCalories(value);
				}
			}

			// Token: 0x0600103D RID: 4157 RVA: 0x0003D434 File Offset: 0x0003B634
			public global::RustProto.Vitals.Builder SetCalories(float value)
			{
				this.PrepareBuilder();
				this.result.hasCalories = true;
				this.result.calories_ = value;
				return this;
			}

			// Token: 0x0600103E RID: 4158 RVA: 0x0003D464 File Offset: 0x0003B664
			public global::RustProto.Vitals.Builder ClearCalories()
			{
				this.PrepareBuilder();
				this.result.hasCalories = false;
				this.result.calories_ = 1000f;
				return this;
			}

			// Token: 0x170003EF RID: 1007
			// (get) Token: 0x0600103F RID: 4159 RVA: 0x0003D498 File Offset: 0x0003B698
			public bool HasRadiation
			{
				get
				{
					return this.result.hasRadiation;
				}
			}

			// Token: 0x170003F0 RID: 1008
			// (get) Token: 0x06001040 RID: 4160 RVA: 0x0003D4A8 File Offset: 0x0003B6A8
			// (set) Token: 0x06001041 RID: 4161 RVA: 0x0003D4B8 File Offset: 0x0003B6B8
			public float Radiation
			{
				get
				{
					return this.result.Radiation;
				}
				set
				{
					this.SetRadiation(value);
				}
			}

			// Token: 0x06001042 RID: 4162 RVA: 0x0003D4C4 File Offset: 0x0003B6C4
			public global::RustProto.Vitals.Builder SetRadiation(float value)
			{
				this.PrepareBuilder();
				this.result.hasRadiation = true;
				this.result.radiation_ = value;
				return this;
			}

			// Token: 0x06001043 RID: 4163 RVA: 0x0003D4F4 File Offset: 0x0003B6F4
			public global::RustProto.Vitals.Builder ClearRadiation()
			{
				this.PrepareBuilder();
				this.result.hasRadiation = false;
				this.result.radiation_ = 0f;
				return this;
			}

			// Token: 0x170003F1 RID: 1009
			// (get) Token: 0x06001044 RID: 4164 RVA: 0x0003D528 File Offset: 0x0003B728
			public bool HasRadiationAnti
			{
				get
				{
					return this.result.hasRadiationAnti;
				}
			}

			// Token: 0x170003F2 RID: 1010
			// (get) Token: 0x06001045 RID: 4165 RVA: 0x0003D538 File Offset: 0x0003B738
			// (set) Token: 0x06001046 RID: 4166 RVA: 0x0003D548 File Offset: 0x0003B748
			public float RadiationAnti
			{
				get
				{
					return this.result.RadiationAnti;
				}
				set
				{
					this.SetRadiationAnti(value);
				}
			}

			// Token: 0x06001047 RID: 4167 RVA: 0x0003D554 File Offset: 0x0003B754
			public global::RustProto.Vitals.Builder SetRadiationAnti(float value)
			{
				this.PrepareBuilder();
				this.result.hasRadiationAnti = true;
				this.result.radiationAnti_ = value;
				return this;
			}

			// Token: 0x06001048 RID: 4168 RVA: 0x0003D584 File Offset: 0x0003B784
			public global::RustProto.Vitals.Builder ClearRadiationAnti()
			{
				this.PrepareBuilder();
				this.result.hasRadiationAnti = false;
				this.result.radiationAnti_ = 0f;
				return this;
			}

			// Token: 0x170003F3 RID: 1011
			// (get) Token: 0x06001049 RID: 4169 RVA: 0x0003D5B8 File Offset: 0x0003B7B8
			public bool HasBleedSpeed
			{
				get
				{
					return this.result.hasBleedSpeed;
				}
			}

			// Token: 0x170003F4 RID: 1012
			// (get) Token: 0x0600104A RID: 4170 RVA: 0x0003D5C8 File Offset: 0x0003B7C8
			// (set) Token: 0x0600104B RID: 4171 RVA: 0x0003D5D8 File Offset: 0x0003B7D8
			public float BleedSpeed
			{
				get
				{
					return this.result.BleedSpeed;
				}
				set
				{
					this.SetBleedSpeed(value);
				}
			}

			// Token: 0x0600104C RID: 4172 RVA: 0x0003D5E4 File Offset: 0x0003B7E4
			public global::RustProto.Vitals.Builder SetBleedSpeed(float value)
			{
				this.PrepareBuilder();
				this.result.hasBleedSpeed = true;
				this.result.bleedSpeed_ = value;
				return this;
			}

			// Token: 0x0600104D RID: 4173 RVA: 0x0003D614 File Offset: 0x0003B814
			public global::RustProto.Vitals.Builder ClearBleedSpeed()
			{
				this.PrepareBuilder();
				this.result.hasBleedSpeed = false;
				this.result.bleedSpeed_ = 0f;
				return this;
			}

			// Token: 0x170003F5 RID: 1013
			// (get) Token: 0x0600104E RID: 4174 RVA: 0x0003D648 File Offset: 0x0003B848
			public bool HasBleedMax
			{
				get
				{
					return this.result.hasBleedMax;
				}
			}

			// Token: 0x170003F6 RID: 1014
			// (get) Token: 0x0600104F RID: 4175 RVA: 0x0003D658 File Offset: 0x0003B858
			// (set) Token: 0x06001050 RID: 4176 RVA: 0x0003D668 File Offset: 0x0003B868
			public float BleedMax
			{
				get
				{
					return this.result.BleedMax;
				}
				set
				{
					this.SetBleedMax(value);
				}
			}

			// Token: 0x06001051 RID: 4177 RVA: 0x0003D674 File Offset: 0x0003B874
			public global::RustProto.Vitals.Builder SetBleedMax(float value)
			{
				this.PrepareBuilder();
				this.result.hasBleedMax = true;
				this.result.bleedMax_ = value;
				return this;
			}

			// Token: 0x06001052 RID: 4178 RVA: 0x0003D6A4 File Offset: 0x0003B8A4
			public global::RustProto.Vitals.Builder ClearBleedMax()
			{
				this.PrepareBuilder();
				this.result.hasBleedMax = false;
				this.result.bleedMax_ = 0f;
				return this;
			}

			// Token: 0x170003F7 RID: 1015
			// (get) Token: 0x06001053 RID: 4179 RVA: 0x0003D6D8 File Offset: 0x0003B8D8
			public bool HasHealSpeed
			{
				get
				{
					return this.result.hasHealSpeed;
				}
			}

			// Token: 0x170003F8 RID: 1016
			// (get) Token: 0x06001054 RID: 4180 RVA: 0x0003D6E8 File Offset: 0x0003B8E8
			// (set) Token: 0x06001055 RID: 4181 RVA: 0x0003D6F8 File Offset: 0x0003B8F8
			public float HealSpeed
			{
				get
				{
					return this.result.HealSpeed;
				}
				set
				{
					this.SetHealSpeed(value);
				}
			}

			// Token: 0x06001056 RID: 4182 RVA: 0x0003D704 File Offset: 0x0003B904
			public global::RustProto.Vitals.Builder SetHealSpeed(float value)
			{
				this.PrepareBuilder();
				this.result.hasHealSpeed = true;
				this.result.healSpeed_ = value;
				return this;
			}

			// Token: 0x06001057 RID: 4183 RVA: 0x0003D734 File Offset: 0x0003B934
			public global::RustProto.Vitals.Builder ClearHealSpeed()
			{
				this.PrepareBuilder();
				this.result.hasHealSpeed = false;
				this.result.healSpeed_ = 0f;
				return this;
			}

			// Token: 0x170003F9 RID: 1017
			// (get) Token: 0x06001058 RID: 4184 RVA: 0x0003D768 File Offset: 0x0003B968
			public bool HasHealMax
			{
				get
				{
					return this.result.hasHealMax;
				}
			}

			// Token: 0x170003FA RID: 1018
			// (get) Token: 0x06001059 RID: 4185 RVA: 0x0003D778 File Offset: 0x0003B978
			// (set) Token: 0x0600105A RID: 4186 RVA: 0x0003D788 File Offset: 0x0003B988
			public float HealMax
			{
				get
				{
					return this.result.HealMax;
				}
				set
				{
					this.SetHealMax(value);
				}
			}

			// Token: 0x0600105B RID: 4187 RVA: 0x0003D794 File Offset: 0x0003B994
			public global::RustProto.Vitals.Builder SetHealMax(float value)
			{
				this.PrepareBuilder();
				this.result.hasHealMax = true;
				this.result.healMax_ = value;
				return this;
			}

			// Token: 0x0600105C RID: 4188 RVA: 0x0003D7C4 File Offset: 0x0003B9C4
			public global::RustProto.Vitals.Builder ClearHealMax()
			{
				this.PrepareBuilder();
				this.result.hasHealMax = false;
				this.result.healMax_ = 0f;
				return this;
			}

			// Token: 0x170003FB RID: 1019
			// (get) Token: 0x0600105D RID: 4189 RVA: 0x0003D7F8 File Offset: 0x0003B9F8
			public bool HasTemperature
			{
				get
				{
					return this.result.hasTemperature;
				}
			}

			// Token: 0x170003FC RID: 1020
			// (get) Token: 0x0600105E RID: 4190 RVA: 0x0003D808 File Offset: 0x0003BA08
			// (set) Token: 0x0600105F RID: 4191 RVA: 0x0003D818 File Offset: 0x0003BA18
			public float Temperature
			{
				get
				{
					return this.result.Temperature;
				}
				set
				{
					this.SetTemperature(value);
				}
			}

			// Token: 0x06001060 RID: 4192 RVA: 0x0003D824 File Offset: 0x0003BA24
			public global::RustProto.Vitals.Builder SetTemperature(float value)
			{
				this.PrepareBuilder();
				this.result.hasTemperature = true;
				this.result.temperature_ = value;
				return this;
			}

			// Token: 0x06001061 RID: 4193 RVA: 0x0003D854 File Offset: 0x0003BA54
			public global::RustProto.Vitals.Builder ClearTemperature()
			{
				this.PrepareBuilder();
				this.result.hasTemperature = false;
				this.result.temperature_ = 0f;
				return this;
			}

			// Token: 0x040009FF RID: 2559
			private bool resultIsReadOnly;

			// Token: 0x04000A00 RID: 2560
			private global::RustProto.Vitals result;
		}
	}
}
