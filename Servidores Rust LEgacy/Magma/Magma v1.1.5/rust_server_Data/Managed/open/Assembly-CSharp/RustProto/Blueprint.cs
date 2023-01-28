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
	// Token: 0x02000243 RID: 579
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Blueprint : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder>
	{
		// Token: 0x060010FF RID: 4351 RVA: 0x0003EDCC File Offset: 0x0003CFCC
		private Blueprint()
		{
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x0003EDDC File Offset: 0x0003CFDC
		static Blueprint()
		{
			object.ReferenceEquals(global::RustProto.Proto.Blueprint.Descriptor, null);
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x0003EE1C File Offset: 0x0003D01C
		public static global::RustProto.Helpers.Recycler<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder>.Manufacture();
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06001102 RID: 4354 RVA: 0x0003EE24 File Offset: 0x0003D024
		public static global::RustProto.Blueprint DefaultInstance
		{
			get
			{
				return global::RustProto.Blueprint.defaultInstance;
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06001103 RID: 4355 RVA: 0x0003EE2C File Offset: 0x0003D02C
		public override global::RustProto.Blueprint DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Blueprint.DefaultInstance;
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06001104 RID: 4356 RVA: 0x0003EE34 File Offset: 0x0003D034
		protected override global::RustProto.Blueprint ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06001105 RID: 4357 RVA: 0x0003EE38 File Offset: 0x0003D038
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__Descriptor;
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06001106 RID: 4358 RVA: 0x0003EE40 File Offset: 0x0003D040
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__FieldAccessorTable;
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x0003EE48 File Offset: 0x0003D048
		public bool HasId
		{
			get
			{
				return this.hasId;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06001108 RID: 4360 RVA: 0x0003EE50 File Offset: 0x0003D050
		public int Id
		{
			get
			{
				return this.id_;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06001109 RID: 4361 RVA: 0x0003EE58 File Offset: 0x0003D058
		public override bool IsInitialized
		{
			get
			{
				return this.hasId;
			}
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0003EE68 File Offset: 0x0003D068
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] blueprintFieldNames = global::RustProto.Blueprint._blueprintFieldNames;
			if (this.hasId)
			{
				output.WriteInt32(1, blueprintFieldNames[0], this.Id);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x0600110B RID: 4363 RVA: 0x0003EEAC File Offset: 0x0003D0AC
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
				if (this.hasId)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(1, this.Id);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0003EEFC File Offset: 0x0003D0FC
		public static global::RustProto.Blueprint ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x0003EF10 File Offset: 0x0003D110
		public static global::RustProto.Blueprint ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0003EF24 File Offset: 0x0003D124
		public static global::RustProto.Blueprint ParseFrom(byte[] data)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0003EF38 File Offset: 0x0003D138
		public static global::RustProto.Blueprint ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0003EF4C File Offset: 0x0003D14C
		public static global::RustProto.Blueprint ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0003EF60 File Offset: 0x0003D160
		public static global::RustProto.Blueprint ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0003EF74 File Offset: 0x0003D174
		public static global::RustProto.Blueprint ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0003EF88 File Offset: 0x0003D188
		public static global::RustProto.Blueprint ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0003EF9C File Offset: 0x0003D19C
		public static global::RustProto.Blueprint ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x0003EFB0 File Offset: 0x0003D1B0
		public static global::RustProto.Blueprint ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Blueprint.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0003EFC4 File Offset: 0x0003D1C4
		private global::RustProto.Blueprint MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0003EFC8 File Offset: 0x0003D1C8
		public static global::RustProto.Blueprint.Builder CreateBuilder()
		{
			return new global::RustProto.Blueprint.Builder();
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0003EFD0 File Offset: 0x0003D1D0
		public override global::RustProto.Blueprint.Builder ToBuilder()
		{
			return global::RustProto.Blueprint.CreateBuilder(this);
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0003EFD8 File Offset: 0x0003D1D8
		public override global::RustProto.Blueprint.Builder CreateBuilderForType()
		{
			return new global::RustProto.Blueprint.Builder();
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0003EFE0 File Offset: 0x0003D1E0
		public static global::RustProto.Blueprint.Builder CreateBuilder(global::RustProto.Blueprint prototype)
		{
			return new global::RustProto.Blueprint.Builder(prototype);
		}

		// Token: 0x04000A2A RID: 2602
		public const int IdFieldNumber = 1;

		// Token: 0x04000A2B RID: 2603
		private static readonly global::RustProto.Blueprint defaultInstance = new global::RustProto.Blueprint().MakeReadOnly();

		// Token: 0x04000A2C RID: 2604
		private static readonly string[] _blueprintFieldNames = new string[]
		{
			"id"
		};

		// Token: 0x04000A2D RID: 2605
		private static readonly uint[] _blueprintFieldTags = new uint[]
		{
			8U
		};

		// Token: 0x04000A2E RID: 2606
		private bool hasId;

		// Token: 0x04000A2F RID: 2607
		private int id_;

		// Token: 0x04000A30 RID: 2608
		private int memoizedSerializedSize = -1;

		// Token: 0x02000244 RID: 580
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder>
		{
			// Token: 0x0600111B RID: 4379 RVA: 0x0003EFE8 File Offset: 0x0003D1E8
			public Builder()
			{
				this.result = global::RustProto.Blueprint.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600111C RID: 4380 RVA: 0x0003F004 File Offset: 0x0003D204
			internal Builder(global::RustProto.Blueprint cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000446 RID: 1094
			// (get) Token: 0x0600111D RID: 4381 RVA: 0x0003F01C File Offset: 0x0003D21C
			protected override global::RustProto.Blueprint.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x0600111E RID: 4382 RVA: 0x0003F020 File Offset: 0x0003D220
			private global::RustProto.Blueprint PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Blueprint other = this.result;
					this.result = new global::RustProto.Blueprint();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000447 RID: 1095
			// (get) Token: 0x0600111F RID: 4383 RVA: 0x0003F060 File Offset: 0x0003D260
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000448 RID: 1096
			// (get) Token: 0x06001120 RID: 4384 RVA: 0x0003F070 File Offset: 0x0003D270
			protected override global::RustProto.Blueprint MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001121 RID: 4385 RVA: 0x0003F078 File Offset: 0x0003D278
			public override global::RustProto.Blueprint.Builder Clear()
			{
				this.result = global::RustProto.Blueprint.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001122 RID: 4386 RVA: 0x0003F090 File Offset: 0x0003D290
			public override global::RustProto.Blueprint.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Blueprint.Builder(this.result);
				}
				return new global::RustProto.Blueprint.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000449 RID: 1097
			// (get) Token: 0x06001123 RID: 4387 RVA: 0x0003F0BC File Offset: 0x0003D2BC
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Blueprint.Descriptor;
				}
			}

			// Token: 0x1700044A RID: 1098
			// (get) Token: 0x06001124 RID: 4388 RVA: 0x0003F0C4 File Offset: 0x0003D2C4
			public override global::RustProto.Blueprint DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Blueprint.DefaultInstance;
				}
			}

			// Token: 0x06001125 RID: 4389 RVA: 0x0003F0CC File Offset: 0x0003D2CC
			public override global::RustProto.Blueprint BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001126 RID: 4390 RVA: 0x0003F100 File Offset: 0x0003D300
			public override global::RustProto.Blueprint.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Blueprint)
				{
					return this.MergeFrom((global::RustProto.Blueprint)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001127 RID: 4391 RVA: 0x0003F124 File Offset: 0x0003D324
			public override global::RustProto.Blueprint.Builder MergeFrom(global::RustProto.Blueprint other)
			{
				if (other == global::RustProto.Blueprint.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasId)
				{
					this.Id = other.Id;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001128 RID: 4392 RVA: 0x0003F16C File Offset: 0x0003D36C
			public override global::RustProto.Blueprint.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001129 RID: 4393 RVA: 0x0003F17C File Offset: 0x0003D37C
			public override global::RustProto.Blueprint.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Blueprint._blueprintFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Blueprint._blueprintFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8U)
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
						this.result.hasId = input.ReadInt32(ref this.result.id_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x1700044B RID: 1099
			// (get) Token: 0x0600112A RID: 4394 RVA: 0x0003F290 File Offset: 0x0003D490
			public bool HasId
			{
				get
				{
					return this.result.hasId;
				}
			}

			// Token: 0x1700044C RID: 1100
			// (get) Token: 0x0600112B RID: 4395 RVA: 0x0003F2A0 File Offset: 0x0003D4A0
			// (set) Token: 0x0600112C RID: 4396 RVA: 0x0003F2B0 File Offset: 0x0003D4B0
			public int Id
			{
				get
				{
					return this.result.Id;
				}
				set
				{
					this.SetId(value);
				}
			}

			// Token: 0x0600112D RID: 4397 RVA: 0x0003F2BC File Offset: 0x0003D4BC
			public global::RustProto.Blueprint.Builder SetId(int value)
			{
				this.PrepareBuilder();
				this.result.hasId = true;
				this.result.id_ = value;
				return this;
			}

			// Token: 0x0600112E RID: 4398 RVA: 0x0003F2EC File Offset: 0x0003D4EC
			public global::RustProto.Blueprint.Builder ClearId()
			{
				this.PrepareBuilder();
				this.result.hasId = false;
				this.result.id_ = 0;
				return this;
			}

			// Token: 0x04000A31 RID: 2609
			private bool resultIsReadOnly;

			// Token: 0x04000A32 RID: 2610
			private global::RustProto.Blueprint result;
		}
	}
}
