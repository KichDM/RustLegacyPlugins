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
	// Token: 0x02000241 RID: 577
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class ItemMod : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder>
	{
		// Token: 0x060010C8 RID: 4296 RVA: 0x0003E744 File Offset: 0x0003C944
		private ItemMod()
		{
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0003E760 File Offset: 0x0003C960
		static ItemMod()
		{
			object.ReferenceEquals(global::RustProto.Proto.ItemMod.Descriptor, null);
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0003E7B8 File Offset: 0x0003C9B8
		public static global::RustProto.Helpers.Recycler<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder>.Manufacture();
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060010CB RID: 4299 RVA: 0x0003E7C0 File Offset: 0x0003C9C0
		public static global::RustProto.ItemMod DefaultInstance
		{
			get
			{
				return global::RustProto.ItemMod.defaultInstance;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x0003E7C8 File Offset: 0x0003C9C8
		public override global::RustProto.ItemMod DefaultInstanceForType
		{
			get
			{
				return global::RustProto.ItemMod.DefaultInstance;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060010CD RID: 4301 RVA: 0x0003E7D0 File Offset: 0x0003C9D0
		protected override global::RustProto.ItemMod ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060010CE RID: 4302 RVA: 0x0003E7D4 File Offset: 0x0003C9D4
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__Descriptor;
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x060010CF RID: 4303 RVA: 0x0003E7DC File Offset: 0x0003C9DC
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__FieldAccessorTable;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x0003E7E4 File Offset: 0x0003C9E4
		public bool HasId
		{
			get
			{
				return this.hasId;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0003E7EC File Offset: 0x0003C9EC
		public int Id
		{
			get
			{
				return this.id_;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x0003E7F4 File Offset: 0x0003C9F4
		public bool HasName
		{
			get
			{
				return this.hasName;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x060010D3 RID: 4307 RVA: 0x0003E7FC File Offset: 0x0003C9FC
		public string Name
		{
			get
			{
				return this.name_;
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x060010D4 RID: 4308 RVA: 0x0003E804 File Offset: 0x0003CA04
		public override bool IsInitialized
		{
			get
			{
				return this.hasId;
			}
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0003E814 File Offset: 0x0003CA14
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] itemModFieldNames = global::RustProto.ItemMod._itemModFieldNames;
			if (this.hasId)
			{
				output.WriteInt32(1, itemModFieldNames[0], this.Id);
			}
			if (this.hasName)
			{
				output.WriteString(2, itemModFieldNames[1], this.Name);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x060010D6 RID: 4310 RVA: 0x0003E870 File Offset: 0x0003CA70
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
				if (this.hasName)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(2, this.Name);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0003E8DC File Offset: 0x0003CADC
		public static global::RustProto.ItemMod ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0003E8F0 File Offset: 0x0003CAF0
		public static global::RustProto.ItemMod ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0003E904 File Offset: 0x0003CB04
		public static global::RustProto.ItemMod ParseFrom(byte[] data)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0003E918 File Offset: 0x0003CB18
		public static global::RustProto.ItemMod ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0003E92C File Offset: 0x0003CB2C
		public static global::RustProto.ItemMod ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0003E940 File Offset: 0x0003CB40
		public static global::RustProto.ItemMod ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0003E954 File Offset: 0x0003CB54
		public static global::RustProto.ItemMod ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0003E968 File Offset: 0x0003CB68
		public static global::RustProto.ItemMod ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0003E97C File Offset: 0x0003CB7C
		public static global::RustProto.ItemMod ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0003E990 File Offset: 0x0003CB90
		public static global::RustProto.ItemMod ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.ItemMod.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0003E9A4 File Offset: 0x0003CBA4
		private global::RustProto.ItemMod MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0003E9A8 File Offset: 0x0003CBA8
		public static global::RustProto.ItemMod.Builder CreateBuilder()
		{
			return new global::RustProto.ItemMod.Builder();
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0003E9B0 File Offset: 0x0003CBB0
		public override global::RustProto.ItemMod.Builder ToBuilder()
		{
			return global::RustProto.ItemMod.CreateBuilder(this);
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0003E9B8 File Offset: 0x0003CBB8
		public override global::RustProto.ItemMod.Builder CreateBuilderForType()
		{
			return new global::RustProto.ItemMod.Builder();
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0003E9C0 File Offset: 0x0003CBC0
		public static global::RustProto.ItemMod.Builder CreateBuilder(global::RustProto.ItemMod prototype)
		{
			return new global::RustProto.ItemMod.Builder(prototype);
		}

		// Token: 0x04000A1E RID: 2590
		public const int IdFieldNumber = 1;

		// Token: 0x04000A1F RID: 2591
		public const int NameFieldNumber = 2;

		// Token: 0x04000A20 RID: 2592
		private static readonly global::RustProto.ItemMod defaultInstance = new global::RustProto.ItemMod().MakeReadOnly();

		// Token: 0x04000A21 RID: 2593
		private static readonly string[] _itemModFieldNames = new string[]
		{
			"id",
			"name"
		};

		// Token: 0x04000A22 RID: 2594
		private static readonly uint[] _itemModFieldTags = new uint[]
		{
			8U,
			0x12U
		};

		// Token: 0x04000A23 RID: 2595
		private bool hasId;

		// Token: 0x04000A24 RID: 2596
		private int id_;

		// Token: 0x04000A25 RID: 2597
		private bool hasName;

		// Token: 0x04000A26 RID: 2598
		private string name_ = string.Empty;

		// Token: 0x04000A27 RID: 2599
		private int memoizedSerializedSize = -1;

		// Token: 0x02000242 RID: 578
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder>
		{
			// Token: 0x060010E6 RID: 4326 RVA: 0x0003E9C8 File Offset: 0x0003CBC8
			public Builder()
			{
				this.result = global::RustProto.ItemMod.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060010E7 RID: 4327 RVA: 0x0003E9E4 File Offset: 0x0003CBE4
			internal Builder(global::RustProto.ItemMod cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000434 RID: 1076
			// (get) Token: 0x060010E8 RID: 4328 RVA: 0x0003E9FC File Offset: 0x0003CBFC
			protected override global::RustProto.ItemMod.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060010E9 RID: 4329 RVA: 0x0003EA00 File Offset: 0x0003CC00
			private global::RustProto.ItemMod PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.ItemMod other = this.result;
					this.result = new global::RustProto.ItemMod();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000435 RID: 1077
			// (get) Token: 0x060010EA RID: 4330 RVA: 0x0003EA40 File Offset: 0x0003CC40
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000436 RID: 1078
			// (get) Token: 0x060010EB RID: 4331 RVA: 0x0003EA50 File Offset: 0x0003CC50
			protected override global::RustProto.ItemMod MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060010EC RID: 4332 RVA: 0x0003EA58 File Offset: 0x0003CC58
			public override global::RustProto.ItemMod.Builder Clear()
			{
				this.result = global::RustProto.ItemMod.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060010ED RID: 4333 RVA: 0x0003EA70 File Offset: 0x0003CC70
			public override global::RustProto.ItemMod.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.ItemMod.Builder(this.result);
				}
				return new global::RustProto.ItemMod.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000437 RID: 1079
			// (get) Token: 0x060010EE RID: 4334 RVA: 0x0003EA9C File Offset: 0x0003CC9C
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.ItemMod.Descriptor;
				}
			}

			// Token: 0x17000438 RID: 1080
			// (get) Token: 0x060010EF RID: 4335 RVA: 0x0003EAA4 File Offset: 0x0003CCA4
			public override global::RustProto.ItemMod DefaultInstanceForType
			{
				get
				{
					return global::RustProto.ItemMod.DefaultInstance;
				}
			}

			// Token: 0x060010F0 RID: 4336 RVA: 0x0003EAAC File Offset: 0x0003CCAC
			public override global::RustProto.ItemMod BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060010F1 RID: 4337 RVA: 0x0003EAE0 File Offset: 0x0003CCE0
			public override global::RustProto.ItemMod.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.ItemMod)
				{
					return this.MergeFrom((global::RustProto.ItemMod)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060010F2 RID: 4338 RVA: 0x0003EB04 File Offset: 0x0003CD04
			public override global::RustProto.ItemMod.Builder MergeFrom(global::RustProto.ItemMod other)
			{
				if (other == global::RustProto.ItemMod.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasId)
				{
					this.Id = other.Id;
				}
				if (other.HasName)
				{
					this.Name = other.Name;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060010F3 RID: 4339 RVA: 0x0003EB64 File Offset: 0x0003CD64
			public override global::RustProto.ItemMod.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060010F4 RID: 4340 RVA: 0x0003EB74 File Offset: 0x0003CD74
			public override global::RustProto.ItemMod.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.ItemMod._itemModFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.ItemMod._itemModFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8U)
					{
						if (num3 != 0x12U)
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
							this.result.hasName = input.ReadString(ref this.result.name_);
						}
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

			// Token: 0x17000439 RID: 1081
			// (get) Token: 0x060010F5 RID: 4341 RVA: 0x0003ECB0 File Offset: 0x0003CEB0
			public bool HasId
			{
				get
				{
					return this.result.hasId;
				}
			}

			// Token: 0x1700043A RID: 1082
			// (get) Token: 0x060010F6 RID: 4342 RVA: 0x0003ECC0 File Offset: 0x0003CEC0
			// (set) Token: 0x060010F7 RID: 4343 RVA: 0x0003ECD0 File Offset: 0x0003CED0
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

			// Token: 0x060010F8 RID: 4344 RVA: 0x0003ECDC File Offset: 0x0003CEDC
			public global::RustProto.ItemMod.Builder SetId(int value)
			{
				this.PrepareBuilder();
				this.result.hasId = true;
				this.result.id_ = value;
				return this;
			}

			// Token: 0x060010F9 RID: 4345 RVA: 0x0003ED0C File Offset: 0x0003CF0C
			public global::RustProto.ItemMod.Builder ClearId()
			{
				this.PrepareBuilder();
				this.result.hasId = false;
				this.result.id_ = 0;
				return this;
			}

			// Token: 0x1700043B RID: 1083
			// (get) Token: 0x060010FA RID: 4346 RVA: 0x0003ED3C File Offset: 0x0003CF3C
			public bool HasName
			{
				get
				{
					return this.result.hasName;
				}
			}

			// Token: 0x1700043C RID: 1084
			// (get) Token: 0x060010FB RID: 4347 RVA: 0x0003ED4C File Offset: 0x0003CF4C
			// (set) Token: 0x060010FC RID: 4348 RVA: 0x0003ED5C File Offset: 0x0003CF5C
			public string Name
			{
				get
				{
					return this.result.Name;
				}
				set
				{
					this.SetName(value);
				}
			}

			// Token: 0x060010FD RID: 4349 RVA: 0x0003ED68 File Offset: 0x0003CF68
			public global::RustProto.ItemMod.Builder SetName(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasName = true;
				this.result.name_ = value;
				return this;
			}

			// Token: 0x060010FE RID: 4350 RVA: 0x0003ED98 File Offset: 0x0003CF98
			public global::RustProto.ItemMod.Builder ClearName()
			{
				this.PrepareBuilder();
				this.result.hasName = false;
				this.result.name_ = string.Empty;
				return this;
			}

			// Token: 0x04000A28 RID: 2600
			private bool resultIsReadOnly;

			// Token: 0x04000A29 RID: 2601
			private global::RustProto.ItemMod result;
		}
	}
}
