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
	// Token: 0x02000261 RID: 609
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Quaternion : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder>
	{
		// Token: 0x060014FE RID: 5374 RVA: 0x000479C0 File Offset: 0x00045BC0
		private Quaternion()
		{
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x000479D0 File Offset: 0x00045BD0
		static Quaternion()
		{
			object.ReferenceEquals(global::RustProto.Common.Descriptor, null);
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x00047A3C File Offset: 0x00045C3C
		public static global::RustProto.Helpers.Recycler<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder>.Manufacture();
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06001501 RID: 5377 RVA: 0x00047A44 File Offset: 0x00045C44
		public static global::RustProto.Quaternion DefaultInstance
		{
			get
			{
				return global::RustProto.Quaternion.defaultInstance;
			}
		}

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06001502 RID: 5378 RVA: 0x00047A4C File Offset: 0x00045C4C
		public override global::RustProto.Quaternion DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Quaternion.DefaultInstance;
			}
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06001503 RID: 5379 RVA: 0x00047A54 File Offset: 0x00045C54
		protected override global::RustProto.Quaternion ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06001504 RID: 5380 RVA: 0x00047A58 File Offset: 0x00045C58
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Common.internal__static_RustProto_Quaternion__Descriptor;
			}
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06001505 RID: 5381 RVA: 0x00047A60 File Offset: 0x00045C60
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Common.internal__static_RustProto_Quaternion__FieldAccessorTable;
			}
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06001506 RID: 5382 RVA: 0x00047A68 File Offset: 0x00045C68
		public bool HasX
		{
			get
			{
				return this.hasX;
			}
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06001507 RID: 5383 RVA: 0x00047A70 File Offset: 0x00045C70
		public float X
		{
			get
			{
				return this.x_;
			}
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001508 RID: 5384 RVA: 0x00047A78 File Offset: 0x00045C78
		public bool HasY
		{
			get
			{
				return this.hasY;
			}
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001509 RID: 5385 RVA: 0x00047A80 File Offset: 0x00045C80
		public float Y
		{
			get
			{
				return this.y_;
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x0600150A RID: 5386 RVA: 0x00047A88 File Offset: 0x00045C88
		public bool HasZ
		{
			get
			{
				return this.hasZ;
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x00047A90 File Offset: 0x00045C90
		public float Z
		{
			get
			{
				return this.z_;
			}
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x0600150C RID: 5388 RVA: 0x00047A98 File Offset: 0x00045C98
		public bool HasW
		{
			get
			{
				return this.hasW;
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x00047AA0 File Offset: 0x00045CA0
		public float W
		{
			get
			{
				return this.w_;
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x0600150E RID: 5390 RVA: 0x00047AA8 File Offset: 0x00045CA8
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x00047AAC File Offset: 0x00045CAC
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] quaternionFieldNames = global::RustProto.Quaternion._quaternionFieldNames;
			if (this.hasX)
			{
				output.WriteFloat(1, quaternionFieldNames[1], this.X);
			}
			if (this.hasY)
			{
				output.WriteFloat(2, quaternionFieldNames[2], this.Y);
			}
			if (this.hasZ)
			{
				output.WriteFloat(3, quaternionFieldNames[3], this.Z);
			}
			if (this.hasW)
			{
				output.WriteFloat(4, quaternionFieldNames[0], this.W);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06001510 RID: 5392 RVA: 0x00047B40 File Offset: 0x00045D40
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
				if (this.hasW)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(4, this.W);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x00047BE0 File Offset: 0x00045DE0
		public static global::RustProto.Quaternion ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x00047BF4 File Offset: 0x00045DF4
		public static global::RustProto.Quaternion ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x00047C08 File Offset: 0x00045E08
		public static global::RustProto.Quaternion ParseFrom(byte[] data)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x00047C1C File Offset: 0x00045E1C
		public static global::RustProto.Quaternion ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x00047C30 File Offset: 0x00045E30
		public static global::RustProto.Quaternion ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x00047C44 File Offset: 0x00045E44
		public static global::RustProto.Quaternion ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x00047C58 File Offset: 0x00045E58
		public static global::RustProto.Quaternion ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x00047C6C File Offset: 0x00045E6C
		public static global::RustProto.Quaternion ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x00047C80 File Offset: 0x00045E80
		public static global::RustProto.Quaternion ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x00047C94 File Offset: 0x00045E94
		public static global::RustProto.Quaternion ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Quaternion.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x00047CA8 File Offset: 0x00045EA8
		private global::RustProto.Quaternion MakeReadOnly()
		{
			return this;
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x00047CAC File Offset: 0x00045EAC
		public static global::RustProto.Quaternion.Builder CreateBuilder()
		{
			return new global::RustProto.Quaternion.Builder();
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x00047CB4 File Offset: 0x00045EB4
		public override global::RustProto.Quaternion.Builder ToBuilder()
		{
			return global::RustProto.Quaternion.CreateBuilder(this);
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x00047CBC File Offset: 0x00045EBC
		public override global::RustProto.Quaternion.Builder CreateBuilderForType()
		{
			return new global::RustProto.Quaternion.Builder();
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x00047CC4 File Offset: 0x00045EC4
		public static global::RustProto.Quaternion.Builder CreateBuilder(global::RustProto.Quaternion prototype)
		{
			return new global::RustProto.Quaternion.Builder(prototype);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00047CCC File Offset: 0x00045ECC
		public static implicit operator global::RustProto.Quaternion(global::UnityEngine.Quaternion v)
		{
			global::RustProto.Quaternion result;
			using (global::RustProto.Helpers.Recycler<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder> recycler = global::RustProto.Quaternion.Recycler())
			{
				global::RustProto.Quaternion.Builder builder = recycler.OpenBuilder();
				builder.SetX(v.x);
				builder.SetY(v.y);
				builder.SetZ(v.z);
				builder.SetW(v.w);
				result = builder.Build();
			}
			return result;
		}

		// Token: 0x04000B1E RID: 2846
		public const int XFieldNumber = 1;

		// Token: 0x04000B1F RID: 2847
		public const int YFieldNumber = 2;

		// Token: 0x04000B20 RID: 2848
		public const int ZFieldNumber = 3;

		// Token: 0x04000B21 RID: 2849
		public const int WFieldNumber = 4;

		// Token: 0x04000B22 RID: 2850
		private static readonly global::RustProto.Quaternion defaultInstance = new global::RustProto.Quaternion().MakeReadOnly();

		// Token: 0x04000B23 RID: 2851
		private static readonly string[] _quaternionFieldNames = new string[]
		{
			"w",
			"x",
			"y",
			"z"
		};

		// Token: 0x04000B24 RID: 2852
		private static readonly uint[] _quaternionFieldTags = new uint[]
		{
			0x25U,
			0xDU,
			0x15U,
			0x1DU
		};

		// Token: 0x04000B25 RID: 2853
		private bool hasX;

		// Token: 0x04000B26 RID: 2854
		private float x_;

		// Token: 0x04000B27 RID: 2855
		private bool hasY;

		// Token: 0x04000B28 RID: 2856
		private float y_;

		// Token: 0x04000B29 RID: 2857
		private bool hasZ;

		// Token: 0x04000B2A RID: 2858
		private float z_;

		// Token: 0x04000B2B RID: 2859
		private bool hasW;

		// Token: 0x04000B2C RID: 2860
		private float w_;

		// Token: 0x04000B2D RID: 2861
		private int memoizedSerializedSize = -1;

		// Token: 0x02000262 RID: 610
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder>
		{
			// Token: 0x06001521 RID: 5409 RVA: 0x00047D5C File Offset: 0x00045F5C
			public Builder()
			{
				this.result = global::RustProto.Quaternion.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001522 RID: 5410 RVA: 0x00047D78 File Offset: 0x00045F78
			internal Builder(global::RustProto.Quaternion cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001523 RID: 5411 RVA: 0x00047D90 File Offset: 0x00045F90
			public void Set(global::UnityEngine.Quaternion value)
			{
				this.SetX(value.x);
				this.SetY(value.y);
				this.SetZ(value.z);
				this.SetW(value.w);
			}

			// Token: 0x170005D0 RID: 1488
			// (get) Token: 0x06001524 RID: 5412 RVA: 0x00047DD8 File Offset: 0x00045FD8
			protected override global::RustProto.Quaternion.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001525 RID: 5413 RVA: 0x00047DDC File Offset: 0x00045FDC
			private global::RustProto.Quaternion PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Quaternion other = this.result;
					this.result = new global::RustProto.Quaternion();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170005D1 RID: 1489
			// (get) Token: 0x06001526 RID: 5414 RVA: 0x00047E1C File Offset: 0x0004601C
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170005D2 RID: 1490
			// (get) Token: 0x06001527 RID: 5415 RVA: 0x00047E2C File Offset: 0x0004602C
			protected override global::RustProto.Quaternion MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001528 RID: 5416 RVA: 0x00047E34 File Offset: 0x00046034
			public override global::RustProto.Quaternion.Builder Clear()
			{
				this.result = global::RustProto.Quaternion.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001529 RID: 5417 RVA: 0x00047E4C File Offset: 0x0004604C
			public override global::RustProto.Quaternion.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Quaternion.Builder(this.result);
				}
				return new global::RustProto.Quaternion.Builder().MergeFrom(this.result);
			}

			// Token: 0x170005D3 RID: 1491
			// (get) Token: 0x0600152A RID: 5418 RVA: 0x00047E78 File Offset: 0x00046078
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Quaternion.Descriptor;
				}
			}

			// Token: 0x170005D4 RID: 1492
			// (get) Token: 0x0600152B RID: 5419 RVA: 0x00047E80 File Offset: 0x00046080
			public override global::RustProto.Quaternion DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Quaternion.DefaultInstance;
				}
			}

			// Token: 0x0600152C RID: 5420 RVA: 0x00047E88 File Offset: 0x00046088
			public override global::RustProto.Quaternion BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x0600152D RID: 5421 RVA: 0x00047EBC File Offset: 0x000460BC
			public override global::RustProto.Quaternion.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Quaternion)
				{
					return this.MergeFrom((global::RustProto.Quaternion)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x0600152E RID: 5422 RVA: 0x00047EE0 File Offset: 0x000460E0
			public override global::RustProto.Quaternion.Builder MergeFrom(global::RustProto.Quaternion other)
			{
				if (other == global::RustProto.Quaternion.DefaultInstance)
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
				if (other.HasW)
				{
					this.W = other.W;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600152F RID: 5423 RVA: 0x00047F6C File Offset: 0x0004616C
			public override global::RustProto.Quaternion.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001530 RID: 5424 RVA: 0x00047F7C File Offset: 0x0004617C
			public override global::RustProto.Quaternion.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Quaternion._quaternionFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Quaternion._quaternionFieldTags[num2];
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
									this.result.hasW = input.ReadFloat(ref this.result.w_);
								}
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

			// Token: 0x170005D5 RID: 1493
			// (get) Token: 0x06001531 RID: 5425 RVA: 0x00048110 File Offset: 0x00046310
			public bool HasX
			{
				get
				{
					return this.result.hasX;
				}
			}

			// Token: 0x170005D6 RID: 1494
			// (get) Token: 0x06001532 RID: 5426 RVA: 0x00048120 File Offset: 0x00046320
			// (set) Token: 0x06001533 RID: 5427 RVA: 0x00048130 File Offset: 0x00046330
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

			// Token: 0x06001534 RID: 5428 RVA: 0x0004813C File Offset: 0x0004633C
			public global::RustProto.Quaternion.Builder SetX(float value)
			{
				this.PrepareBuilder();
				this.result.hasX = true;
				this.result.x_ = value;
				return this;
			}

			// Token: 0x06001535 RID: 5429 RVA: 0x0004816C File Offset: 0x0004636C
			public global::RustProto.Quaternion.Builder ClearX()
			{
				this.PrepareBuilder();
				this.result.hasX = false;
				this.result.x_ = 0f;
				return this;
			}

			// Token: 0x170005D7 RID: 1495
			// (get) Token: 0x06001536 RID: 5430 RVA: 0x000481A0 File Offset: 0x000463A0
			public bool HasY
			{
				get
				{
					return this.result.hasY;
				}
			}

			// Token: 0x170005D8 RID: 1496
			// (get) Token: 0x06001537 RID: 5431 RVA: 0x000481B0 File Offset: 0x000463B0
			// (set) Token: 0x06001538 RID: 5432 RVA: 0x000481C0 File Offset: 0x000463C0
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

			// Token: 0x06001539 RID: 5433 RVA: 0x000481CC File Offset: 0x000463CC
			public global::RustProto.Quaternion.Builder SetY(float value)
			{
				this.PrepareBuilder();
				this.result.hasY = true;
				this.result.y_ = value;
				return this;
			}

			// Token: 0x0600153A RID: 5434 RVA: 0x000481FC File Offset: 0x000463FC
			public global::RustProto.Quaternion.Builder ClearY()
			{
				this.PrepareBuilder();
				this.result.hasY = false;
				this.result.y_ = 0f;
				return this;
			}

			// Token: 0x170005D9 RID: 1497
			// (get) Token: 0x0600153B RID: 5435 RVA: 0x00048230 File Offset: 0x00046430
			public bool HasZ
			{
				get
				{
					return this.result.hasZ;
				}
			}

			// Token: 0x170005DA RID: 1498
			// (get) Token: 0x0600153C RID: 5436 RVA: 0x00048240 File Offset: 0x00046440
			// (set) Token: 0x0600153D RID: 5437 RVA: 0x00048250 File Offset: 0x00046450
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

			// Token: 0x0600153E RID: 5438 RVA: 0x0004825C File Offset: 0x0004645C
			public global::RustProto.Quaternion.Builder SetZ(float value)
			{
				this.PrepareBuilder();
				this.result.hasZ = true;
				this.result.z_ = value;
				return this;
			}

			// Token: 0x0600153F RID: 5439 RVA: 0x0004828C File Offset: 0x0004648C
			public global::RustProto.Quaternion.Builder ClearZ()
			{
				this.PrepareBuilder();
				this.result.hasZ = false;
				this.result.z_ = 0f;
				return this;
			}

			// Token: 0x170005DB RID: 1499
			// (get) Token: 0x06001540 RID: 5440 RVA: 0x000482C0 File Offset: 0x000464C0
			public bool HasW
			{
				get
				{
					return this.result.hasW;
				}
			}

			// Token: 0x170005DC RID: 1500
			// (get) Token: 0x06001541 RID: 5441 RVA: 0x000482D0 File Offset: 0x000464D0
			// (set) Token: 0x06001542 RID: 5442 RVA: 0x000482E0 File Offset: 0x000464E0
			public float W
			{
				get
				{
					return this.result.W;
				}
				set
				{
					this.SetW(value);
				}
			}

			// Token: 0x06001543 RID: 5443 RVA: 0x000482EC File Offset: 0x000464EC
			public global::RustProto.Quaternion.Builder SetW(float value)
			{
				this.PrepareBuilder();
				this.result.hasW = true;
				this.result.w_ = value;
				return this;
			}

			// Token: 0x06001544 RID: 5444 RVA: 0x0004831C File Offset: 0x0004651C
			public global::RustProto.Quaternion.Builder ClearW()
			{
				this.PrepareBuilder();
				this.result.hasW = false;
				this.result.w_ = 0f;
				return this;
			}

			// Token: 0x04000B2E RID: 2862
			private bool resultIsReadOnly;

			// Token: 0x04000B2F RID: 2863
			private global::RustProto.Quaternion result;
		}
	}
}
