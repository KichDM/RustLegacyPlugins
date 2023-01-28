using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x0200023F RID: 575
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Item : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Item, global::RustProto.Item.Builder>
	{
		// Token: 0x06001062 RID: 4194 RVA: 0x0003D888 File Offset: 0x0003BA88
		private Item()
		{
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0003D8B0 File Offset: 0x0003BAB0
		static Item()
		{
			object.ReferenceEquals(global::RustProto.Proto.Item.Descriptor, null);
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x0003D93C File Offset: 0x0003BB3C
		public static global::RustProto.Helpers.Recycler<global::RustProto.Item, global::RustProto.Item.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.Item, global::RustProto.Item.Builder>.Manufacture();
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06001065 RID: 4197 RVA: 0x0003D944 File Offset: 0x0003BB44
		public static global::RustProto.Item DefaultInstance
		{
			get
			{
				return global::RustProto.Item.defaultInstance;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06001066 RID: 4198 RVA: 0x0003D94C File Offset: 0x0003BB4C
		public override global::RustProto.Item DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Item.DefaultInstance;
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06001067 RID: 4199 RVA: 0x0003D954 File Offset: 0x0003BB54
		protected override global::RustProto.Item ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06001068 RID: 4200 RVA: 0x0003D958 File Offset: 0x0003BB58
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Item.internal__static_RustProto_Item__Descriptor;
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06001069 RID: 4201 RVA: 0x0003D960 File Offset: 0x0003BB60
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Item, global::RustProto.Item.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Item.internal__static_RustProto_Item__FieldAccessorTable;
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x0600106A RID: 4202 RVA: 0x0003D968 File Offset: 0x0003BB68
		public bool HasId
		{
			get
			{
				return this.hasId;
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x0600106B RID: 4203 RVA: 0x0003D970 File Offset: 0x0003BB70
		public int Id
		{
			get
			{
				return this.id_;
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x0600106C RID: 4204 RVA: 0x0003D978 File Offset: 0x0003BB78
		public bool HasName
		{
			get
			{
				return this.hasName;
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x0600106D RID: 4205 RVA: 0x0003D980 File Offset: 0x0003BB80
		public string Name
		{
			get
			{
				return this.name_;
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x0600106E RID: 4206 RVA: 0x0003D988 File Offset: 0x0003BB88
		public bool HasSlot
		{
			get
			{
				return this.hasSlot;
			}
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x0003D990 File Offset: 0x0003BB90
		public int Slot
		{
			get
			{
				return this.slot_;
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06001070 RID: 4208 RVA: 0x0003D998 File Offset: 0x0003BB98
		public bool HasCount
		{
			get
			{
				return this.hasCount;
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06001071 RID: 4209 RVA: 0x0003D9A0 File Offset: 0x0003BBA0
		public int Count
		{
			get
			{
				return this.count_;
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06001072 RID: 4210 RVA: 0x0003D9A8 File Offset: 0x0003BBA8
		public bool HasSubslots
		{
			get
			{
				return this.hasSubslots;
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06001073 RID: 4211 RVA: 0x0003D9B0 File Offset: 0x0003BBB0
		public int Subslots
		{
			get
			{
				return this.subslots_;
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06001074 RID: 4212 RVA: 0x0003D9B8 File Offset: 0x0003BBB8
		public bool HasCondition
		{
			get
			{
				return this.hasCondition;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06001075 RID: 4213 RVA: 0x0003D9C0 File Offset: 0x0003BBC0
		public float Condition
		{
			get
			{
				return this.condition_;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06001076 RID: 4214 RVA: 0x0003D9C8 File Offset: 0x0003BBC8
		public bool HasMaxcondition
		{
			get
			{
				return this.hasMaxcondition;
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06001077 RID: 4215 RVA: 0x0003D9D0 File Offset: 0x0003BBD0
		public float Maxcondition
		{
			get
			{
				return this.maxcondition_;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06001078 RID: 4216 RVA: 0x0003D9D8 File Offset: 0x0003BBD8
		public global::System.Collections.Generic.IList<global::RustProto.Item> SubitemList
		{
			get
			{
				return this.subitem_;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06001079 RID: 4217 RVA: 0x0003D9E0 File Offset: 0x0003BBE0
		public int SubitemCount
		{
			get
			{
				return this.subitem_.Count;
			}
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x0003D9F0 File Offset: 0x0003BBF0
		public global::RustProto.Item GetSubitem(int index)
		{
			return this.subitem_[index];
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x0600107B RID: 4219 RVA: 0x0003DA00 File Offset: 0x0003BC00
		public override bool IsInitialized
		{
			get
			{
				if (!this.hasId)
				{
					return false;
				}
				foreach (global::RustProto.Item item in this.SubitemList)
				{
					if (!item.IsInitialized)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x0003DA80 File Offset: 0x0003BC80
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] itemFieldNames = global::RustProto.Item._itemFieldNames;
			if (this.hasId)
			{
				output.WriteInt32(1, itemFieldNames[2], this.Id);
			}
			if (this.hasName)
			{
				output.WriteString(2, itemFieldNames[4], this.Name);
			}
			if (this.hasSlot)
			{
				output.WriteInt32(3, itemFieldNames[5], this.Slot);
			}
			if (this.hasCount)
			{
				output.WriteInt32(4, itemFieldNames[1], this.Count);
			}
			if (this.subitem_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.Item>(5, itemFieldNames[6], this.subitem_);
			}
			if (this.hasSubslots)
			{
				output.WriteInt32(6, itemFieldNames[7], this.Subslots);
			}
			if (this.hasCondition)
			{
				output.WriteFloat(7, itemFieldNames[0], this.Condition);
			}
			if (this.hasMaxcondition)
			{
				output.WriteFloat(8, itemFieldNames[3], this.Maxcondition);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x0600107D RID: 4221 RVA: 0x0003DB84 File Offset: 0x0003BD84
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
				if (this.hasSlot)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(3, this.Slot);
				}
				if (this.hasCount)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(4, this.Count);
				}
				if (this.hasSubslots)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(6, this.Subslots);
				}
				if (this.hasCondition)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(7, this.Condition);
				}
				if (this.hasMaxcondition)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(8, this.Maxcondition);
				}
				foreach (global::RustProto.Item item in this.SubitemList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(5, item);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x0003DCC8 File Offset: 0x0003BEC8
		public static global::RustProto.Item ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x0003DCDC File Offset: 0x0003BEDC
		public static global::RustProto.Item ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x0003DCF0 File Offset: 0x0003BEF0
		public static global::RustProto.Item ParseFrom(byte[] data)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x0003DD04 File Offset: 0x0003BF04
		public static global::RustProto.Item ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x0003DD18 File Offset: 0x0003BF18
		public static global::RustProto.Item ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x0003DD2C File Offset: 0x0003BF2C
		public static global::RustProto.Item ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x0003DD40 File Offset: 0x0003BF40
		public static global::RustProto.Item ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Item.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x0003DD54 File Offset: 0x0003BF54
		public static global::RustProto.Item ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Item.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x0003DD68 File Offset: 0x0003BF68
		public static global::RustProto.Item ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0003DD7C File Offset: 0x0003BF7C
		public static global::RustProto.Item ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Item.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x0003DD90 File Offset: 0x0003BF90
		private global::RustProto.Item MakeReadOnly()
		{
			this.subitem_.MakeReadOnly();
			return this;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x0003DDA0 File Offset: 0x0003BFA0
		public static global::RustProto.Item.Builder CreateBuilder()
		{
			return new global::RustProto.Item.Builder();
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x0003DDA8 File Offset: 0x0003BFA8
		public override global::RustProto.Item.Builder ToBuilder()
		{
			return global::RustProto.Item.CreateBuilder(this);
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x0003DDB0 File Offset: 0x0003BFB0
		public override global::RustProto.Item.Builder CreateBuilderForType()
		{
			return new global::RustProto.Item.Builder();
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x0003DDB8 File Offset: 0x0003BFB8
		public static global::RustProto.Item.Builder CreateBuilder(global::RustProto.Item prototype)
		{
			return new global::RustProto.Item.Builder(prototype);
		}

		// Token: 0x04000A01 RID: 2561
		public const int IdFieldNumber = 1;

		// Token: 0x04000A02 RID: 2562
		public const int NameFieldNumber = 2;

		// Token: 0x04000A03 RID: 2563
		public const int SlotFieldNumber = 3;

		// Token: 0x04000A04 RID: 2564
		public const int CountFieldNumber = 4;

		// Token: 0x04000A05 RID: 2565
		public const int SubslotsFieldNumber = 6;

		// Token: 0x04000A06 RID: 2566
		public const int ConditionFieldNumber = 7;

		// Token: 0x04000A07 RID: 2567
		public const int MaxconditionFieldNumber = 8;

		// Token: 0x04000A08 RID: 2568
		public const int SubitemFieldNumber = 5;

		// Token: 0x04000A09 RID: 2569
		private static readonly global::RustProto.Item defaultInstance = new global::RustProto.Item().MakeReadOnly();

		// Token: 0x04000A0A RID: 2570
		private static readonly string[] _itemFieldNames = new string[]
		{
			"condition",
			"count",
			"id",
			"maxcondition",
			"name",
			"slot",
			"subitem",
			"subslots"
		};

		// Token: 0x04000A0B RID: 2571
		private static readonly uint[] _itemFieldTags = new uint[]
		{
			0x3DU,
			0x20U,
			8U,
			0x45U,
			0x12U,
			0x18U,
			0x2AU,
			0x30U
		};

		// Token: 0x04000A0C RID: 2572
		private bool hasId;

		// Token: 0x04000A0D RID: 2573
		private int id_;

		// Token: 0x04000A0E RID: 2574
		private bool hasName;

		// Token: 0x04000A0F RID: 2575
		private string name_ = string.Empty;

		// Token: 0x04000A10 RID: 2576
		private bool hasSlot;

		// Token: 0x04000A11 RID: 2577
		private int slot_;

		// Token: 0x04000A12 RID: 2578
		private bool hasCount;

		// Token: 0x04000A13 RID: 2579
		private int count_;

		// Token: 0x04000A14 RID: 2580
		private bool hasSubslots;

		// Token: 0x04000A15 RID: 2581
		private int subslots_;

		// Token: 0x04000A16 RID: 2582
		private bool hasCondition;

		// Token: 0x04000A17 RID: 2583
		private float condition_;

		// Token: 0x04000A18 RID: 2584
		private bool hasMaxcondition;

		// Token: 0x04000A19 RID: 2585
		private float maxcondition_;

		// Token: 0x04000A1A RID: 2586
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item> subitem_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item>();

		// Token: 0x04000A1B RID: 2587
		private int memoizedSerializedSize = -1;

		// Token: 0x02000240 RID: 576
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Item, global::RustProto.Item.Builder>
		{
			// Token: 0x0600108D RID: 4237 RVA: 0x0003DDC0 File Offset: 0x0003BFC0
			public Builder()
			{
				this.result = global::RustProto.Item.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600108E RID: 4238 RVA: 0x0003DDDC File Offset: 0x0003BFDC
			internal Builder(global::RustProto.Item cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000414 RID: 1044
			// (get) Token: 0x0600108F RID: 4239 RVA: 0x0003DDF4 File Offset: 0x0003BFF4
			protected override global::RustProto.Item.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001090 RID: 4240 RVA: 0x0003DDF8 File Offset: 0x0003BFF8
			private global::RustProto.Item PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Item other = this.result;
					this.result = new global::RustProto.Item();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000415 RID: 1045
			// (get) Token: 0x06001091 RID: 4241 RVA: 0x0003DE38 File Offset: 0x0003C038
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000416 RID: 1046
			// (get) Token: 0x06001092 RID: 4242 RVA: 0x0003DE48 File Offset: 0x0003C048
			protected override global::RustProto.Item MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001093 RID: 4243 RVA: 0x0003DE50 File Offset: 0x0003C050
			public override global::RustProto.Item.Builder Clear()
			{
				this.result = global::RustProto.Item.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001094 RID: 4244 RVA: 0x0003DE68 File Offset: 0x0003C068
			public override global::RustProto.Item.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Item.Builder(this.result);
				}
				return new global::RustProto.Item.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000417 RID: 1047
			// (get) Token: 0x06001095 RID: 4245 RVA: 0x0003DE94 File Offset: 0x0003C094
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Item.Descriptor;
				}
			}

			// Token: 0x17000418 RID: 1048
			// (get) Token: 0x06001096 RID: 4246 RVA: 0x0003DE9C File Offset: 0x0003C09C
			public override global::RustProto.Item DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Item.DefaultInstance;
				}
			}

			// Token: 0x06001097 RID: 4247 RVA: 0x0003DEA4 File Offset: 0x0003C0A4
			public override global::RustProto.Item BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001098 RID: 4248 RVA: 0x0003DED8 File Offset: 0x0003C0D8
			public override global::RustProto.Item.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Item)
				{
					return this.MergeFrom((global::RustProto.Item)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001099 RID: 4249 RVA: 0x0003DEFC File Offset: 0x0003C0FC
			public override global::RustProto.Item.Builder MergeFrom(global::RustProto.Item other)
			{
				if (other == global::RustProto.Item.DefaultInstance)
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
				if (other.HasSlot)
				{
					this.Slot = other.Slot;
				}
				if (other.HasCount)
				{
					this.Count = other.Count;
				}
				if (other.HasSubslots)
				{
					this.Subslots = other.Subslots;
				}
				if (other.HasCondition)
				{
					this.Condition = other.Condition;
				}
				if (other.HasMaxcondition)
				{
					this.Maxcondition = other.Maxcondition;
				}
				if (other.subitem_.Count != 0)
				{
					this.result.subitem_.Add(other.subitem_);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600109A RID: 4250 RVA: 0x0003DFF4 File Offset: 0x0003C1F4
			public override global::RustProto.Item.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x0600109B RID: 4251 RVA: 0x0003E004 File Offset: 0x0003C204
			public override global::RustProto.Item.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Item._itemFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Item._itemFieldTags[num2];
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
							if (num3 != 0x18U)
							{
								if (num3 != 0x20U)
								{
									if (num3 != 0x2AU)
									{
										if (num3 != 0x30U)
										{
											if (num3 != 0x3DU)
											{
												if (num3 != 0x45U)
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
													this.result.hasMaxcondition = input.ReadFloat(ref this.result.maxcondition_);
												}
											}
											else
											{
												this.result.hasCondition = input.ReadFloat(ref this.result.condition_);
											}
										}
										else
										{
											this.result.hasSubslots = input.ReadInt32(ref this.result.subslots_);
										}
									}
									else
									{
										input.ReadMessageArray<global::RustProto.Item>(num, text, this.result.subitem_, global::RustProto.Item.DefaultInstance, extensionRegistry);
									}
								}
								else
								{
									this.result.hasCount = input.ReadInt32(ref this.result.count_);
								}
							}
							else
							{
								this.result.hasSlot = input.ReadInt32(ref this.result.slot_);
							}
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

			// Token: 0x17000419 RID: 1049
			// (get) Token: 0x0600109C RID: 4252 RVA: 0x0003E23C File Offset: 0x0003C43C
			public bool HasId
			{
				get
				{
					return this.result.hasId;
				}
			}

			// Token: 0x1700041A RID: 1050
			// (get) Token: 0x0600109D RID: 4253 RVA: 0x0003E24C File Offset: 0x0003C44C
			// (set) Token: 0x0600109E RID: 4254 RVA: 0x0003E25C File Offset: 0x0003C45C
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

			// Token: 0x0600109F RID: 4255 RVA: 0x0003E268 File Offset: 0x0003C468
			public global::RustProto.Item.Builder SetId(int value)
			{
				this.PrepareBuilder();
				this.result.hasId = true;
				this.result.id_ = value;
				return this;
			}

			// Token: 0x060010A0 RID: 4256 RVA: 0x0003E298 File Offset: 0x0003C498
			public global::RustProto.Item.Builder ClearId()
			{
				this.PrepareBuilder();
				this.result.hasId = false;
				this.result.id_ = 0;
				return this;
			}

			// Token: 0x1700041B RID: 1051
			// (get) Token: 0x060010A1 RID: 4257 RVA: 0x0003E2C8 File Offset: 0x0003C4C8
			public bool HasName
			{
				get
				{
					return this.result.hasName;
				}
			}

			// Token: 0x1700041C RID: 1052
			// (get) Token: 0x060010A2 RID: 4258 RVA: 0x0003E2D8 File Offset: 0x0003C4D8
			// (set) Token: 0x060010A3 RID: 4259 RVA: 0x0003E2E8 File Offset: 0x0003C4E8
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

			// Token: 0x060010A4 RID: 4260 RVA: 0x0003E2F4 File Offset: 0x0003C4F4
			public global::RustProto.Item.Builder SetName(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasName = true;
				this.result.name_ = value;
				return this;
			}

			// Token: 0x060010A5 RID: 4261 RVA: 0x0003E324 File Offset: 0x0003C524
			public global::RustProto.Item.Builder ClearName()
			{
				this.PrepareBuilder();
				this.result.hasName = false;
				this.result.name_ = string.Empty;
				return this;
			}

			// Token: 0x1700041D RID: 1053
			// (get) Token: 0x060010A6 RID: 4262 RVA: 0x0003E358 File Offset: 0x0003C558
			public bool HasSlot
			{
				get
				{
					return this.result.hasSlot;
				}
			}

			// Token: 0x1700041E RID: 1054
			// (get) Token: 0x060010A7 RID: 4263 RVA: 0x0003E368 File Offset: 0x0003C568
			// (set) Token: 0x060010A8 RID: 4264 RVA: 0x0003E378 File Offset: 0x0003C578
			public int Slot
			{
				get
				{
					return this.result.Slot;
				}
				set
				{
					this.SetSlot(value);
				}
			}

			// Token: 0x060010A9 RID: 4265 RVA: 0x0003E384 File Offset: 0x0003C584
			public global::RustProto.Item.Builder SetSlot(int value)
			{
				this.PrepareBuilder();
				this.result.hasSlot = true;
				this.result.slot_ = value;
				return this;
			}

			// Token: 0x060010AA RID: 4266 RVA: 0x0003E3B4 File Offset: 0x0003C5B4
			public global::RustProto.Item.Builder ClearSlot()
			{
				this.PrepareBuilder();
				this.result.hasSlot = false;
				this.result.slot_ = 0;
				return this;
			}

			// Token: 0x1700041F RID: 1055
			// (get) Token: 0x060010AB RID: 4267 RVA: 0x0003E3E4 File Offset: 0x0003C5E4
			public bool HasCount
			{
				get
				{
					return this.result.hasCount;
				}
			}

			// Token: 0x17000420 RID: 1056
			// (get) Token: 0x060010AC RID: 4268 RVA: 0x0003E3F4 File Offset: 0x0003C5F4
			// (set) Token: 0x060010AD RID: 4269 RVA: 0x0003E404 File Offset: 0x0003C604
			public int Count
			{
				get
				{
					return this.result.Count;
				}
				set
				{
					this.SetCount(value);
				}
			}

			// Token: 0x060010AE RID: 4270 RVA: 0x0003E410 File Offset: 0x0003C610
			public global::RustProto.Item.Builder SetCount(int value)
			{
				this.PrepareBuilder();
				this.result.hasCount = true;
				this.result.count_ = value;
				return this;
			}

			// Token: 0x060010AF RID: 4271 RVA: 0x0003E440 File Offset: 0x0003C640
			public global::RustProto.Item.Builder ClearCount()
			{
				this.PrepareBuilder();
				this.result.hasCount = false;
				this.result.count_ = 0;
				return this;
			}

			// Token: 0x17000421 RID: 1057
			// (get) Token: 0x060010B0 RID: 4272 RVA: 0x0003E470 File Offset: 0x0003C670
			public bool HasSubslots
			{
				get
				{
					return this.result.hasSubslots;
				}
			}

			// Token: 0x17000422 RID: 1058
			// (get) Token: 0x060010B1 RID: 4273 RVA: 0x0003E480 File Offset: 0x0003C680
			// (set) Token: 0x060010B2 RID: 4274 RVA: 0x0003E490 File Offset: 0x0003C690
			public int Subslots
			{
				get
				{
					return this.result.Subslots;
				}
				set
				{
					this.SetSubslots(value);
				}
			}

			// Token: 0x060010B3 RID: 4275 RVA: 0x0003E49C File Offset: 0x0003C69C
			public global::RustProto.Item.Builder SetSubslots(int value)
			{
				this.PrepareBuilder();
				this.result.hasSubslots = true;
				this.result.subslots_ = value;
				return this;
			}

			// Token: 0x060010B4 RID: 4276 RVA: 0x0003E4CC File Offset: 0x0003C6CC
			public global::RustProto.Item.Builder ClearSubslots()
			{
				this.PrepareBuilder();
				this.result.hasSubslots = false;
				this.result.subslots_ = 0;
				return this;
			}

			// Token: 0x17000423 RID: 1059
			// (get) Token: 0x060010B5 RID: 4277 RVA: 0x0003E4FC File Offset: 0x0003C6FC
			public bool HasCondition
			{
				get
				{
					return this.result.hasCondition;
				}
			}

			// Token: 0x17000424 RID: 1060
			// (get) Token: 0x060010B6 RID: 4278 RVA: 0x0003E50C File Offset: 0x0003C70C
			// (set) Token: 0x060010B7 RID: 4279 RVA: 0x0003E51C File Offset: 0x0003C71C
			public float Condition
			{
				get
				{
					return this.result.Condition;
				}
				set
				{
					this.SetCondition(value);
				}
			}

			// Token: 0x060010B8 RID: 4280 RVA: 0x0003E528 File Offset: 0x0003C728
			public global::RustProto.Item.Builder SetCondition(float value)
			{
				this.PrepareBuilder();
				this.result.hasCondition = true;
				this.result.condition_ = value;
				return this;
			}

			// Token: 0x060010B9 RID: 4281 RVA: 0x0003E558 File Offset: 0x0003C758
			public global::RustProto.Item.Builder ClearCondition()
			{
				this.PrepareBuilder();
				this.result.hasCondition = false;
				this.result.condition_ = 0f;
				return this;
			}

			// Token: 0x17000425 RID: 1061
			// (get) Token: 0x060010BA RID: 4282 RVA: 0x0003E58C File Offset: 0x0003C78C
			public bool HasMaxcondition
			{
				get
				{
					return this.result.hasMaxcondition;
				}
			}

			// Token: 0x17000426 RID: 1062
			// (get) Token: 0x060010BB RID: 4283 RVA: 0x0003E59C File Offset: 0x0003C79C
			// (set) Token: 0x060010BC RID: 4284 RVA: 0x0003E5AC File Offset: 0x0003C7AC
			public float Maxcondition
			{
				get
				{
					return this.result.Maxcondition;
				}
				set
				{
					this.SetMaxcondition(value);
				}
			}

			// Token: 0x060010BD RID: 4285 RVA: 0x0003E5B8 File Offset: 0x0003C7B8
			public global::RustProto.Item.Builder SetMaxcondition(float value)
			{
				this.PrepareBuilder();
				this.result.hasMaxcondition = true;
				this.result.maxcondition_ = value;
				return this;
			}

			// Token: 0x060010BE RID: 4286 RVA: 0x0003E5E8 File Offset: 0x0003C7E8
			public global::RustProto.Item.Builder ClearMaxcondition()
			{
				this.PrepareBuilder();
				this.result.hasMaxcondition = false;
				this.result.maxcondition_ = 0f;
				return this;
			}

			// Token: 0x17000427 RID: 1063
			// (get) Token: 0x060010BF RID: 4287 RVA: 0x0003E61C File Offset: 0x0003C81C
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.Item> SubitemList
			{
				get
				{
					return this.PrepareBuilder().subitem_;
				}
			}

			// Token: 0x17000428 RID: 1064
			// (get) Token: 0x060010C0 RID: 4288 RVA: 0x0003E62C File Offset: 0x0003C82C
			public int SubitemCount
			{
				get
				{
					return this.result.SubitemCount;
				}
			}

			// Token: 0x060010C1 RID: 4289 RVA: 0x0003E63C File Offset: 0x0003C83C
			public global::RustProto.Item GetSubitem(int index)
			{
				return this.result.GetSubitem(index);
			}

			// Token: 0x060010C2 RID: 4290 RVA: 0x0003E64C File Offset: 0x0003C84C
			public global::RustProto.Item.Builder SetSubitem(int index, global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.subitem_[index] = value;
				return this;
			}

			// Token: 0x060010C3 RID: 4291 RVA: 0x0003E674 File Offset: 0x0003C874
			public global::RustProto.Item.Builder SetSubitem(int index, global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.subitem_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x060010C4 RID: 4292 RVA: 0x0003E6AC File Offset: 0x0003C8AC
			public global::RustProto.Item.Builder AddSubitem(global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.subitem_.Add(value);
				return this;
			}

			// Token: 0x060010C5 RID: 4293 RVA: 0x0003E6E0 File Offset: 0x0003C8E0
			public global::RustProto.Item.Builder AddSubitem(global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.subitem_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x060010C6 RID: 4294 RVA: 0x0003E70C File Offset: 0x0003C90C
			public global::RustProto.Item.Builder AddRangeSubitem(global::System.Collections.Generic.IEnumerable<global::RustProto.Item> values)
			{
				this.PrepareBuilder();
				this.result.subitem_.Add(values);
				return this;
			}

			// Token: 0x060010C7 RID: 4295 RVA: 0x0003E728 File Offset: 0x0003C928
			public global::RustProto.Item.Builder ClearSubitem()
			{
				this.PrepareBuilder();
				this.result.subitem_.Clear();
				return this;
			}

			// Token: 0x04000A1C RID: 2588
			private bool resultIsReadOnly;

			// Token: 0x04000A1D RID: 2589
			private global::RustProto.Item result;
		}
	}
}
