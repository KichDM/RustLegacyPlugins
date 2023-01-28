using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;
using UnityEngine;

namespace RustProto
{
	// Token: 0x0200025F RID: 607
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Vector : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Vector, global::RustProto.Vector.Builder>
	{
		// Token: 0x060014BE RID: 5310 RVA: 0x00047170 File Offset: 0x00045370
		private Vector()
		{
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x00047180 File Offset: 0x00045380
		static Vector()
		{
			object.ReferenceEquals(global::RustProto.Common.Descriptor, null);
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x000471E8 File Offset: 0x000453E8
		public static global::RustProto.Helpers.Recycler<global::RustProto.Vector, global::RustProto.Vector.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.Vector, global::RustProto.Vector.Builder>.Manufacture();
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x060014C1 RID: 5313 RVA: 0x000471F0 File Offset: 0x000453F0
		public static global::RustProto.Vector DefaultInstance
		{
			get
			{
				return global::RustProto.Vector.defaultInstance;
			}
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x060014C2 RID: 5314 RVA: 0x000471F8 File Offset: 0x000453F8
		public override global::RustProto.Vector DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Vector.DefaultInstance;
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x060014C3 RID: 5315 RVA: 0x00047200 File Offset: 0x00045400
		protected override global::RustProto.Vector ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x060014C4 RID: 5316 RVA: 0x00047204 File Offset: 0x00045404
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Common.internal__static_RustProto_Vector__Descriptor;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x060014C5 RID: 5317 RVA: 0x0004720C File Offset: 0x0004540C
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vector, global::RustProto.Vector.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Common.internal__static_RustProto_Vector__FieldAccessorTable;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x060014C6 RID: 5318 RVA: 0x00047214 File Offset: 0x00045414
		public bool HasX
		{
			get
			{
				return this.hasX;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x060014C7 RID: 5319 RVA: 0x0004721C File Offset: 0x0004541C
		public float X
		{
			get
			{
				return this.x_;
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x00047224 File Offset: 0x00045424
		public bool HasY
		{
			get
			{
				return this.hasY;
			}
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x060014C9 RID: 5321 RVA: 0x0004722C File Offset: 0x0004542C
		public float Y
		{
			get
			{
				return this.y_;
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x060014CA RID: 5322 RVA: 0x00047234 File Offset: 0x00045434
		public bool HasZ
		{
			get
			{
				return this.hasZ;
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x060014CB RID: 5323 RVA: 0x0004723C File Offset: 0x0004543C
		public float Z
		{
			get
			{
				return this.z_;
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x060014CC RID: 5324 RVA: 0x00047244 File Offset: 0x00045444
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x00047248 File Offset: 0x00045448
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] vectorFieldNames = global::RustProto.Vector._vectorFieldNames;
			if (this.hasX)
			{
				output.WriteFloat(1, vectorFieldNames[0], this.X);
			}
			if (this.hasY)
			{
				output.WriteFloat(2, vectorFieldNames[1], this.Y);
			}
			if (this.hasZ)
			{
				output.WriteFloat(3, vectorFieldNames[2], this.Z);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x060014CE RID: 5326 RVA: 0x000472C0 File Offset: 0x000454C0
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
				if (this.hasX)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(1, this.X);
				}
				if (this.hasY)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(2, this.Y);
				}
				if (this.hasZ)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(3, this.Z);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x00047344 File Offset: 0x00045544
		public static global::RustProto.Vector ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x00047358 File Offset: 0x00045558
		public static global::RustProto.Vector ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0004736C File Offset: 0x0004556C
		public static global::RustProto.Vector ParseFrom(byte[] data)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x00047380 File Offset: 0x00045580
		public static global::RustProto.Vector ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x00047394 File Offset: 0x00045594
		public static global::RustProto.Vector ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x000473A8 File Offset: 0x000455A8
		public static global::RustProto.Vector ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x000473BC File Offset: 0x000455BC
		public static global::RustProto.Vector ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Vector.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x000473D0 File Offset: 0x000455D0
		public static global::RustProto.Vector ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vector.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x000473E4 File Offset: 0x000455E4
		public static global::RustProto.Vector ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x000473F8 File Offset: 0x000455F8
		public static global::RustProto.Vector ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Vector.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0004740C File Offset: 0x0004560C
		private global::RustProto.Vector MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00047410 File Offset: 0x00045610
		public static global::RustProto.Vector.Builder CreateBuilder()
		{
			return new global::RustProto.Vector.Builder();
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x00047418 File Offset: 0x00045618
		public override global::RustProto.Vector.Builder ToBuilder()
		{
			return global::RustProto.Vector.CreateBuilder(this);
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00047420 File Offset: 0x00045620
		public override global::RustProto.Vector.Builder CreateBuilderForType()
		{
			return new global::RustProto.Vector.Builder();
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00047428 File Offset: 0x00045628
		public static global::RustProto.Vector.Builder CreateBuilder(global::RustProto.Vector prototype)
		{
			return new global::RustProto.Vector.Builder(prototype);
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x00047430 File Offset: 0x00045630
		public static implicit operator global::RustProto.Vector(global::UnityEngine.Vector3 v)
		{
			global::RustProto.Vector result;
			using (global::RustProto.Helpers.Recycler<global::RustProto.Vector, global::RustProto.Vector.Builder> recycler = global::RustProto.Vector.Recycler())
			{
				global::RustProto.Vector.Builder builder = recycler.OpenBuilder();
				builder.SetX(v.x);
				builder.SetY(v.y);
				builder.SetZ(v.z);
				result = builder.Build();
			}
			return result;
		}

		// Token: 0x04000B0F RID: 2831
		public const int XFieldNumber = 1;

		// Token: 0x04000B10 RID: 2832
		public const int YFieldNumber = 2;

		// Token: 0x04000B11 RID: 2833
		public const int ZFieldNumber = 3;

		// Token: 0x04000B12 RID: 2834
		private static readonly global::RustProto.Vector defaultInstance = new global::RustProto.Vector().MakeReadOnly();

		// Token: 0x04000B13 RID: 2835
		private static readonly string[] _vectorFieldNames = new string[]
		{
			"x",
			"y",
			"z"
		};

		// Token: 0x04000B14 RID: 2836
		private static readonly uint[] _vectorFieldTags = new uint[]
		{
			0xDU,
			0x15U,
			0x1DU
		};

		// Token: 0x04000B15 RID: 2837
		private bool hasX;

		// Token: 0x04000B16 RID: 2838
		private float x_;

		// Token: 0x04000B17 RID: 2839
		private bool hasY;

		// Token: 0x04000B18 RID: 2840
		private float y_;

		// Token: 0x04000B19 RID: 2841
		private bool hasZ;

		// Token: 0x04000B1A RID: 2842
		private float z_;

		// Token: 0x04000B1B RID: 2843
		private int memoizedSerializedSize = -1;

		// Token: 0x02000260 RID: 608
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Vector, global::RustProto.Vector.Builder>
		{
			// Token: 0x060014DF RID: 5343 RVA: 0x000474B0 File Offset: 0x000456B0
			public Builder()
			{
				this.result = global::RustProto.Vector.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060014E0 RID: 5344 RVA: 0x000474CC File Offset: 0x000456CC
			internal Builder(global::RustProto.Vector cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060014E1 RID: 5345 RVA: 0x000474E4 File Offset: 0x000456E4
			public void Set(global::UnityEngine.Vector3 value)
			{
				this.SetX(value.x);
				this.SetY(value.y);
				this.SetZ(value.z);
			}

			// Token: 0x170005B6 RID: 1462
			// (get) Token: 0x060014E2 RID: 5346 RVA: 0x0004751C File Offset: 0x0004571C
			protected override global::RustProto.Vector.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060014E3 RID: 5347 RVA: 0x00047520 File Offset: 0x00045720
			private global::RustProto.Vector PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Vector other = this.result;
					this.result = new global::RustProto.Vector();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170005B7 RID: 1463
			// (get) Token: 0x060014E4 RID: 5348 RVA: 0x00047560 File Offset: 0x00045760
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170005B8 RID: 1464
			// (get) Token: 0x060014E5 RID: 5349 RVA: 0x00047570 File Offset: 0x00045770
			protected override global::RustProto.Vector MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060014E6 RID: 5350 RVA: 0x00047578 File Offset: 0x00045778
			public override global::RustProto.Vector.Builder Clear()
			{
				this.result = global::RustProto.Vector.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060014E7 RID: 5351 RVA: 0x00047590 File Offset: 0x00045790
			public override global::RustProto.Vector.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Vector.Builder(this.result);
				}
				return new global::RustProto.Vector.Builder().MergeFrom(this.result);
			}

			// Token: 0x170005B9 RID: 1465
			// (get) Token: 0x060014E8 RID: 5352 RVA: 0x000475BC File Offset: 0x000457BC
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Vector.Descriptor;
				}
			}

			// Token: 0x170005BA RID: 1466
			// (get) Token: 0x060014E9 RID: 5353 RVA: 0x000475C4 File Offset: 0x000457C4
			public override global::RustProto.Vector DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Vector.DefaultInstance;
				}
			}

			// Token: 0x060014EA RID: 5354 RVA: 0x000475CC File Offset: 0x000457CC
			public override global::RustProto.Vector BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060014EB RID: 5355 RVA: 0x00047600 File Offset: 0x00045800
			public override global::RustProto.Vector.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Vector)
				{
					return this.MergeFrom((global::RustProto.Vector)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060014EC RID: 5356 RVA: 0x00047624 File Offset: 0x00045824
			public override global::RustProto.Vector.Builder MergeFrom(global::RustProto.Vector other)
			{
				if (other == global::RustProto.Vector.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasX)
				{
					this.X = other.X;
				}
				if (other.HasY)
				{
					this.Y = other.Y;
				}
				if (other.HasZ)
				{
					this.Z = other.Z;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060014ED RID: 5357 RVA: 0x00047698 File Offset: 0x00045898
			public override global::RustProto.Vector.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060014EE RID: 5358 RVA: 0x000476A8 File Offset: 0x000458A8
			public override global::RustProto.Vector.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Vector._vectorFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Vector._vectorFieldTags[num2];
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
								this.result.hasZ = input.ReadFloat(ref this.result.z_);
							}
						}
						else
						{
							this.result.hasY = input.ReadFloat(ref this.result.y_);
						}
					}
					else
					{
						this.result.hasX = input.ReadFloat(ref this.result.x_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170005BB RID: 1467
			// (get) Token: 0x060014EF RID: 5359 RVA: 0x00047810 File Offset: 0x00045A10
			public bool HasX
			{
				get
				{
					return this.result.hasX;
				}
			}

			// Token: 0x170005BC RID: 1468
			// (get) Token: 0x060014F0 RID: 5360 RVA: 0x00047820 File Offset: 0x00045A20
			// (set) Token: 0x060014F1 RID: 5361 RVA: 0x00047830 File Offset: 0x00045A30
			public float X
			{
				get
				{
					return this.result.X;
				}
				set
				{
					this.SetX(value);
				}
			}

			// Token: 0x060014F2 RID: 5362 RVA: 0x0004783C File Offset: 0x00045A3C
			public global::RustProto.Vector.Builder SetX(float value)
			{
				this.PrepareBuilder();
				this.result.hasX = true;
				this.result.x_ = value;
				return this;
			}

			// Token: 0x060014F3 RID: 5363 RVA: 0x0004786C File Offset: 0x00045A6C
			public global::RustProto.Vector.Builder ClearX()
			{
				this.PrepareBuilder();
				this.result.hasX = false;
				this.result.x_ = 0f;
				return this;
			}

			// Token: 0x170005BD RID: 1469
			// (get) Token: 0x060014F4 RID: 5364 RVA: 0x000478A0 File Offset: 0x00045AA0
			public bool HasY
			{
				get
				{
					return this.result.hasY;
				}
			}

			// Token: 0x170005BE RID: 1470
			// (get) Token: 0x060014F5 RID: 5365 RVA: 0x000478B0 File Offset: 0x00045AB0
			// (set) Token: 0x060014F6 RID: 5366 RVA: 0x000478C0 File Offset: 0x00045AC0
			public float Y
			{
				get
				{
					return this.result.Y;
				}
				set
				{
					this.SetY(value);
				}
			}

			// Token: 0x060014F7 RID: 5367 RVA: 0x000478CC File Offset: 0x00045ACC
			public global::RustProto.Vector.Builder SetY(float value)
			{
				this.PrepareBuilder();
				this.result.hasY = true;
				this.result.y_ = value;
				return this;
			}

			// Token: 0x060014F8 RID: 5368 RVA: 0x000478FC File Offset: 0x00045AFC
			public global::RustProto.Vector.Builder ClearY()
			{
				this.PrepareBuilder();
				this.result.hasY = false;
				this.result.y_ = 0f;
				return this;
			}

			// Token: 0x170005BF RID: 1471
			// (get) Token: 0x060014F9 RID: 5369 RVA: 0x00047930 File Offset: 0x00045B30
			public bool HasZ
			{
				get
				{
					return this.result.hasZ;
				}
			}

			// Token: 0x170005C0 RID: 1472
			// (get) Token: 0x060014FA RID: 5370 RVA: 0x00047940 File Offset: 0x00045B40
			// (set) Token: 0x060014FB RID: 5371 RVA: 0x00047950 File Offset: 0x00045B50
			public float Z
			{
				get
				{
					return this.result.Z;
				}
				set
				{
					this.SetZ(value);
				}
			}

			// Token: 0x060014FC RID: 5372 RVA: 0x0004795C File Offset: 0x00045B5C
			public global::RustProto.Vector.Builder SetZ(float value)
			{
				this.PrepareBuilder();
				this.result.hasZ = true;
				this.result.z_ = value;
				return this;
			}

			// Token: 0x060014FD RID: 5373 RVA: 0x0004798C File Offset: 0x00045B8C
			public global::RustProto.Vector.Builder ClearZ()
			{
				this.PrepareBuilder();
				this.result.hasZ = false;
				this.result.z_ = 0f;
				return this;
			}

			// Token: 0x04000B1C RID: 2844
			private bool resultIsReadOnly;

			// Token: 0x04000B1D RID: 2845
			private global::RustProto.Vector result;
		}
	}
}
