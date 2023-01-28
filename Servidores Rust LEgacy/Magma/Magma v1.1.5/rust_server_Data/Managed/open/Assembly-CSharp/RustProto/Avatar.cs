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
	// Token: 0x0200023B RID: 571
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Avatar : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Avatar, global::RustProto.Avatar.Builder>
	{
		// Token: 0x06000F76 RID: 3958 RVA: 0x0003B1DC File Offset: 0x000393DC
		private Avatar()
		{
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0003B218 File Offset: 0x00039418
		static Avatar()
		{
			object.ReferenceEquals(global::RustProto.Proto.Avatar.Descriptor, null);
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0003B2A4 File Offset: 0x000394A4
		public static global::RustProto.Helpers.Recycler<global::RustProto.Avatar, global::RustProto.Avatar.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.Avatar, global::RustProto.Avatar.Builder>.Manufacture();
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x0003B2AC File Offset: 0x000394AC
		public static global::RustProto.Avatar DefaultInstance
		{
			get
			{
				return global::RustProto.Avatar.defaultInstance;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000F7A RID: 3962 RVA: 0x0003B2B4 File Offset: 0x000394B4
		public override global::RustProto.Avatar DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Avatar.DefaultInstance;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000F7B RID: 3963 RVA: 0x0003B2BC File Offset: 0x000394BC
		protected override global::RustProto.Avatar ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000F7C RID: 3964 RVA: 0x0003B2C0 File Offset: 0x000394C0
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__Descriptor;
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000F7D RID: 3965 RVA: 0x0003B2C8 File Offset: 0x000394C8
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Avatar, global::RustProto.Avatar.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__FieldAccessorTable;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000F7E RID: 3966 RVA: 0x0003B2D0 File Offset: 0x000394D0
		public bool HasPos
		{
			get
			{
				return this.hasPos;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000F7F RID: 3967 RVA: 0x0003B2D8 File Offset: 0x000394D8
		public global::RustProto.Vector Pos
		{
			get
			{
				return this.pos_ ?? global::RustProto.Vector.DefaultInstance;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x0003B2EC File Offset: 0x000394EC
		public bool HasAng
		{
			get
			{
				return this.hasAng;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x0003B2F4 File Offset: 0x000394F4
		public global::RustProto.Quaternion Ang
		{
			get
			{
				return this.ang_ ?? global::RustProto.Quaternion.DefaultInstance;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0003B308 File Offset: 0x00039508
		public bool HasVitals
		{
			get
			{
				return this.hasVitals;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0003B310 File Offset: 0x00039510
		public global::RustProto.Vitals Vitals
		{
			get
			{
				return this.vitals_ ?? global::RustProto.Vitals.DefaultInstance;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0003B324 File Offset: 0x00039524
		public global::System.Collections.Generic.IList<global::RustProto.Blueprint> BlueprintsList
		{
			get
			{
				return this.blueprints_;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x0003B32C File Offset: 0x0003952C
		public int BlueprintsCount
		{
			get
			{
				return this.blueprints_.Count;
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x0003B33C File Offset: 0x0003953C
		public global::RustProto.Blueprint GetBlueprints(int index)
		{
			return this.blueprints_[index];
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0003B34C File Offset: 0x0003954C
		public global::System.Collections.Generic.IList<global::RustProto.Item> InventoryList
		{
			get
			{
				return this.inventory_;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x0003B354 File Offset: 0x00039554
		public int InventoryCount
		{
			get
			{
				return this.inventory_.Count;
			}
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x0003B364 File Offset: 0x00039564
		public global::RustProto.Item GetInventory(int index)
		{
			return this.inventory_[index];
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0003B374 File Offset: 0x00039574
		public global::System.Collections.Generic.IList<global::RustProto.Item> WearableList
		{
			get
			{
				return this.wearable_;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000F8B RID: 3979 RVA: 0x0003B37C File Offset: 0x0003957C
		public int WearableCount
		{
			get
			{
				return this.wearable_.Count;
			}
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x0003B38C File Offset: 0x0003958C
		public global::RustProto.Item GetWearable(int index)
		{
			return this.wearable_[index];
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000F8D RID: 3981 RVA: 0x0003B39C File Offset: 0x0003959C
		public global::System.Collections.Generic.IList<global::RustProto.Item> BeltList
		{
			get
			{
				return this.belt_;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x0003B3A4 File Offset: 0x000395A4
		public int BeltCount
		{
			get
			{
				return this.belt_.Count;
			}
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x0003B3B4 File Offset: 0x000395B4
		public global::RustProto.Item GetBelt(int index)
		{
			return this.belt_[index];
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x0003B3C4 File Offset: 0x000395C4
		public bool HasAwayEvent
		{
			get
			{
				return this.hasAwayEvent;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0003B3CC File Offset: 0x000395CC
		public global::RustProto.AwayEvent AwayEvent
		{
			get
			{
				return this.awayEvent_ ?? global::RustProto.AwayEvent.DefaultInstance;
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x0003B3E0 File Offset: 0x000395E0
		public override bool IsInitialized
		{
			get
			{
				foreach (global::RustProto.Blueprint blueprint in this.BlueprintsList)
				{
					if (!blueprint.IsInitialized)
					{
						return false;
					}
				}
				foreach (global::RustProto.Item item in this.InventoryList)
				{
					if (!item.IsInitialized)
					{
						return false;
					}
				}
				foreach (global::RustProto.Item item2 in this.WearableList)
				{
					if (!item2.IsInitialized)
					{
						return false;
					}
				}
				foreach (global::RustProto.Item item3 in this.BeltList)
				{
					if (!item3.IsInitialized)
					{
						return false;
					}
				}
				return !this.HasAwayEvent || this.AwayEvent.IsInitialized;
			}
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x0003B598 File Offset: 0x00039798
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] avatarFieldNames = global::RustProto.Avatar._avatarFieldNames;
			if (this.hasPos)
			{
				output.WriteMessage(1, avatarFieldNames[5], this.Pos);
			}
			if (this.hasAng)
			{
				output.WriteMessage(2, avatarFieldNames[0], this.Ang);
			}
			if (this.hasVitals)
			{
				output.WriteMessage(3, avatarFieldNames[6], this.Vitals);
			}
			if (this.blueprints_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.Blueprint>(4, avatarFieldNames[3], this.blueprints_);
			}
			if (this.inventory_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.Item>(5, avatarFieldNames[4], this.inventory_);
			}
			if (this.wearable_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.Item>(6, avatarFieldNames[7], this.wearable_);
			}
			if (this.belt_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.Item>(7, avatarFieldNames[2], this.belt_);
			}
			if (this.hasAwayEvent)
			{
				output.WriteMessage(8, avatarFieldNames[1], this.AwayEvent);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000F94 RID: 3988 RVA: 0x0003B6B0 File Offset: 0x000398B0
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
				if (this.hasPos)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(1, this.Pos);
				}
				if (this.hasAng)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(2, this.Ang);
				}
				if (this.hasVitals)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(3, this.Vitals);
				}
				foreach (global::RustProto.Blueprint blueprint in this.BlueprintsList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(4, blueprint);
				}
				foreach (global::RustProto.Item item in this.InventoryList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(5, item);
				}
				foreach (global::RustProto.Item item2 in this.WearableList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(6, item2);
				}
				foreach (global::RustProto.Item item3 in this.BeltList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(7, item3);
				}
				if (this.hasAwayEvent)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(8, this.AwayEvent);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x0003B8B8 File Offset: 0x00039AB8
		public static global::RustProto.Avatar ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0003B8CC File Offset: 0x00039ACC
		public static global::RustProto.Avatar ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x0003B8E0 File Offset: 0x00039AE0
		public static global::RustProto.Avatar ParseFrom(byte[] data)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x0003B8F4 File Offset: 0x00039AF4
		public static global::RustProto.Avatar ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0003B908 File Offset: 0x00039B08
		public static global::RustProto.Avatar ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0003B91C File Offset: 0x00039B1C
		public static global::RustProto.Avatar ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0003B930 File Offset: 0x00039B30
		public static global::RustProto.Avatar ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0003B944 File Offset: 0x00039B44
		public static global::RustProto.Avatar ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0003B958 File Offset: 0x00039B58
		public static global::RustProto.Avatar ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0003B96C File Offset: 0x00039B6C
		public static global::RustProto.Avatar ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Avatar.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x0003B980 File Offset: 0x00039B80
		private global::RustProto.Avatar MakeReadOnly()
		{
			this.blueprints_.MakeReadOnly();
			this.inventory_.MakeReadOnly();
			this.wearable_.MakeReadOnly();
			this.belt_.MakeReadOnly();
			return this;
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x0003B9BC File Offset: 0x00039BBC
		public static global::RustProto.Avatar.Builder CreateBuilder()
		{
			return new global::RustProto.Avatar.Builder();
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x0003B9C4 File Offset: 0x00039BC4
		public override global::RustProto.Avatar.Builder ToBuilder()
		{
			return global::RustProto.Avatar.CreateBuilder(this);
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0003B9CC File Offset: 0x00039BCC
		public override global::RustProto.Avatar.Builder CreateBuilderForType()
		{
			return new global::RustProto.Avatar.Builder();
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0003B9D4 File Offset: 0x00039BD4
		public static global::RustProto.Avatar.Builder CreateBuilder(global::RustProto.Avatar prototype)
		{
			return new global::RustProto.Avatar.Builder(prototype);
		}

		// Token: 0x040009C3 RID: 2499
		public const int PosFieldNumber = 1;

		// Token: 0x040009C4 RID: 2500
		public const int AngFieldNumber = 2;

		// Token: 0x040009C5 RID: 2501
		public const int VitalsFieldNumber = 3;

		// Token: 0x040009C6 RID: 2502
		public const int BlueprintsFieldNumber = 4;

		// Token: 0x040009C7 RID: 2503
		public const int InventoryFieldNumber = 5;

		// Token: 0x040009C8 RID: 2504
		public const int WearableFieldNumber = 6;

		// Token: 0x040009C9 RID: 2505
		public const int BeltFieldNumber = 7;

		// Token: 0x040009CA RID: 2506
		public const int AwayEventFieldNumber = 8;

		// Token: 0x040009CB RID: 2507
		private static readonly global::RustProto.Avatar defaultInstance = new global::RustProto.Avatar().MakeReadOnly();

		// Token: 0x040009CC RID: 2508
		private static readonly string[] _avatarFieldNames = new string[]
		{
			"ang",
			"awayEvent",
			"belt",
			"blueprints",
			"inventory",
			"pos",
			"vitals",
			"wearable"
		};

		// Token: 0x040009CD RID: 2509
		private static readonly uint[] _avatarFieldTags = new uint[]
		{
			0x12U,
			0x42U,
			0x3AU,
			0x22U,
			0x2AU,
			0xAU,
			0x1AU,
			0x32U
		};

		// Token: 0x040009CE RID: 2510
		private bool hasPos;

		// Token: 0x040009CF RID: 2511
		private global::RustProto.Vector pos_;

		// Token: 0x040009D0 RID: 2512
		private bool hasAng;

		// Token: 0x040009D1 RID: 2513
		private global::RustProto.Quaternion ang_;

		// Token: 0x040009D2 RID: 2514
		private bool hasVitals;

		// Token: 0x040009D3 RID: 2515
		private global::RustProto.Vitals vitals_;

		// Token: 0x040009D4 RID: 2516
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Blueprint> blueprints_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Blueprint>();

		// Token: 0x040009D5 RID: 2517
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item> inventory_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item>();

		// Token: 0x040009D6 RID: 2518
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item> wearable_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item>();

		// Token: 0x040009D7 RID: 2519
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item> belt_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item>();

		// Token: 0x040009D8 RID: 2520
		private bool hasAwayEvent;

		// Token: 0x040009D9 RID: 2521
		private global::RustProto.AwayEvent awayEvent_;

		// Token: 0x040009DA RID: 2522
		private int memoizedSerializedSize = -1;

		// Token: 0x0200023C RID: 572
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Avatar, global::RustProto.Avatar.Builder>
		{
			// Token: 0x06000FA4 RID: 4004 RVA: 0x0003B9DC File Offset: 0x00039BDC
			public Builder()
			{
				this.result = global::RustProto.Avatar.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06000FA5 RID: 4005 RVA: 0x0003B9F8 File Offset: 0x00039BF8
			internal Builder(global::RustProto.Avatar cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170003B4 RID: 948
			// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0003BA10 File Offset: 0x00039C10
			protected override global::RustProto.Avatar.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06000FA7 RID: 4007 RVA: 0x0003BA14 File Offset: 0x00039C14
			private global::RustProto.Avatar PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Avatar other = this.result;
					this.result = new global::RustProto.Avatar();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170003B5 RID: 949
			// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x0003BA54 File Offset: 0x00039C54
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170003B6 RID: 950
			// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x0003BA64 File Offset: 0x00039C64
			protected override global::RustProto.Avatar MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06000FAA RID: 4010 RVA: 0x0003BA6C File Offset: 0x00039C6C
			public override global::RustProto.Avatar.Builder Clear()
			{
				this.result = global::RustProto.Avatar.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06000FAB RID: 4011 RVA: 0x0003BA84 File Offset: 0x00039C84
			public override global::RustProto.Avatar.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Avatar.Builder(this.result);
				}
				return new global::RustProto.Avatar.Builder().MergeFrom(this.result);
			}

			// Token: 0x170003B7 RID: 951
			// (get) Token: 0x06000FAC RID: 4012 RVA: 0x0003BAB0 File Offset: 0x00039CB0
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Avatar.Descriptor;
				}
			}

			// Token: 0x170003B8 RID: 952
			// (get) Token: 0x06000FAD RID: 4013 RVA: 0x0003BAB8 File Offset: 0x00039CB8
			public override global::RustProto.Avatar DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Avatar.DefaultInstance;
				}
			}

			// Token: 0x06000FAE RID: 4014 RVA: 0x0003BAC0 File Offset: 0x00039CC0
			public override global::RustProto.Avatar BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06000FAF RID: 4015 RVA: 0x0003BAF4 File Offset: 0x00039CF4
			public override global::RustProto.Avatar.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Avatar)
				{
					return this.MergeFrom((global::RustProto.Avatar)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06000FB0 RID: 4016 RVA: 0x0003BB18 File Offset: 0x00039D18
			public override global::RustProto.Avatar.Builder MergeFrom(global::RustProto.Avatar other)
			{
				if (other == global::RustProto.Avatar.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasPos)
				{
					this.MergePos(other.Pos);
				}
				if (other.HasAng)
				{
					this.MergeAng(other.Ang);
				}
				if (other.HasVitals)
				{
					this.MergeVitals(other.Vitals);
				}
				if (other.blueprints_.Count != 0)
				{
					this.result.blueprints_.Add(other.blueprints_);
				}
				if (other.inventory_.Count != 0)
				{
					this.result.inventory_.Add(other.inventory_);
				}
				if (other.wearable_.Count != 0)
				{
					this.result.wearable_.Add(other.wearable_);
				}
				if (other.belt_.Count != 0)
				{
					this.result.belt_.Add(other.belt_);
				}
				if (other.HasAwayEvent)
				{
					this.MergeAwayEvent(other.AwayEvent);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06000FB1 RID: 4017 RVA: 0x0003BC40 File Offset: 0x00039E40
			public override global::RustProto.Avatar.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06000FB2 RID: 4018 RVA: 0x0003BC50 File Offset: 0x00039E50
			public override global::RustProto.Avatar.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Avatar._avatarFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Avatar._avatarFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 0xAU)
					{
						if (num3 != 0x12U)
						{
							if (num3 != 0x1AU)
							{
								if (num3 != 0x22U)
								{
									if (num3 != 0x2AU)
									{
										if (num3 != 0x32U)
										{
											if (num3 != 0x3AU)
											{
												if (num3 != 0x42U)
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
													global::RustProto.AwayEvent.Builder builder2 = global::RustProto.AwayEvent.CreateBuilder();
													if (this.result.hasAwayEvent)
													{
														builder2.MergeFrom(this.AwayEvent);
													}
													input.ReadMessage(builder2, extensionRegistry);
													this.AwayEvent = builder2.BuildPartial();
												}
											}
											else
											{
												input.ReadMessageArray<global::RustProto.Item>(num, text, this.result.belt_, global::RustProto.Item.DefaultInstance, extensionRegistry);
											}
										}
										else
										{
											input.ReadMessageArray<global::RustProto.Item>(num, text, this.result.wearable_, global::RustProto.Item.DefaultInstance, extensionRegistry);
										}
									}
									else
									{
										input.ReadMessageArray<global::RustProto.Item>(num, text, this.result.inventory_, global::RustProto.Item.DefaultInstance, extensionRegistry);
									}
								}
								else
								{
									input.ReadMessageArray<global::RustProto.Blueprint>(num, text, this.result.blueprints_, global::RustProto.Blueprint.DefaultInstance, extensionRegistry);
								}
							}
							else
							{
								global::RustProto.Vitals.Builder builder3 = global::RustProto.Vitals.CreateBuilder();
								if (this.result.hasVitals)
								{
									builder3.MergeFrom(this.Vitals);
								}
								input.ReadMessage(builder3, extensionRegistry);
								this.Vitals = builder3.BuildPartial();
							}
						}
						else
						{
							global::RustProto.Quaternion.Builder builder4 = global::RustProto.Quaternion.CreateBuilder();
							if (this.result.hasAng)
							{
								builder4.MergeFrom(this.Ang);
							}
							input.ReadMessage(builder4, extensionRegistry);
							this.Ang = builder4.BuildPartial();
						}
					}
					else
					{
						global::RustProto.Vector.Builder builder5 = global::RustProto.Vector.CreateBuilder();
						if (this.result.hasPos)
						{
							builder5.MergeFrom(this.Pos);
						}
						input.ReadMessage(builder5, extensionRegistry);
						this.Pos = builder5.BuildPartial();
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170003B9 RID: 953
			// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x0003BEFC File Offset: 0x0003A0FC
			public bool HasPos
			{
				get
				{
					return this.result.hasPos;
				}
			}

			// Token: 0x170003BA RID: 954
			// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0003BF0C File Offset: 0x0003A10C
			// (set) Token: 0x06000FB5 RID: 4021 RVA: 0x0003BF1C File Offset: 0x0003A11C
			public global::RustProto.Vector Pos
			{
				get
				{
					return this.result.Pos;
				}
				set
				{
					this.SetPos(value);
				}
			}

			// Token: 0x06000FB6 RID: 4022 RVA: 0x0003BF28 File Offset: 0x0003A128
			public global::RustProto.Avatar.Builder SetPos(global::RustProto.Vector value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPos = true;
				this.result.pos_ = value;
				return this;
			}

			// Token: 0x06000FB7 RID: 4023 RVA: 0x0003BF58 File Offset: 0x0003A158
			public global::RustProto.Avatar.Builder SetPos(global::RustProto.Vector.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasPos = true;
				this.result.pos_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FB8 RID: 4024 RVA: 0x0003BF98 File Offset: 0x0003A198
			public global::RustProto.Avatar.Builder MergePos(global::RustProto.Vector value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasPos && this.result.pos_ != global::RustProto.Vector.DefaultInstance)
				{
					this.result.pos_ = global::RustProto.Vector.CreateBuilder(this.result.pos_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.pos_ = value;
				}
				this.result.hasPos = true;
				return this;
			}

			// Token: 0x06000FB9 RID: 4025 RVA: 0x0003C020 File Offset: 0x0003A220
			public global::RustProto.Avatar.Builder ClearPos()
			{
				this.PrepareBuilder();
				this.result.hasPos = false;
				this.result.pos_ = null;
				return this;
			}

			// Token: 0x170003BB RID: 955
			// (get) Token: 0x06000FBA RID: 4026 RVA: 0x0003C050 File Offset: 0x0003A250
			public bool HasAng
			{
				get
				{
					return this.result.hasAng;
				}
			}

			// Token: 0x170003BC RID: 956
			// (get) Token: 0x06000FBB RID: 4027 RVA: 0x0003C060 File Offset: 0x0003A260
			// (set) Token: 0x06000FBC RID: 4028 RVA: 0x0003C070 File Offset: 0x0003A270
			public global::RustProto.Quaternion Ang
			{
				get
				{
					return this.result.Ang;
				}
				set
				{
					this.SetAng(value);
				}
			}

			// Token: 0x06000FBD RID: 4029 RVA: 0x0003C07C File Offset: 0x0003A27C
			public global::RustProto.Avatar.Builder SetAng(global::RustProto.Quaternion value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasAng = true;
				this.result.ang_ = value;
				return this;
			}

			// Token: 0x06000FBE RID: 4030 RVA: 0x0003C0AC File Offset: 0x0003A2AC
			public global::RustProto.Avatar.Builder SetAng(global::RustProto.Quaternion.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasAng = true;
				this.result.ang_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FBF RID: 4031 RVA: 0x0003C0EC File Offset: 0x0003A2EC
			public global::RustProto.Avatar.Builder MergeAng(global::RustProto.Quaternion value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasAng && this.result.ang_ != global::RustProto.Quaternion.DefaultInstance)
				{
					this.result.ang_ = global::RustProto.Quaternion.CreateBuilder(this.result.ang_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.ang_ = value;
				}
				this.result.hasAng = true;
				return this;
			}

			// Token: 0x06000FC0 RID: 4032 RVA: 0x0003C174 File Offset: 0x0003A374
			public global::RustProto.Avatar.Builder ClearAng()
			{
				this.PrepareBuilder();
				this.result.hasAng = false;
				this.result.ang_ = null;
				return this;
			}

			// Token: 0x170003BD RID: 957
			// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x0003C1A4 File Offset: 0x0003A3A4
			public bool HasVitals
			{
				get
				{
					return this.result.hasVitals;
				}
			}

			// Token: 0x170003BE RID: 958
			// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x0003C1B4 File Offset: 0x0003A3B4
			// (set) Token: 0x06000FC3 RID: 4035 RVA: 0x0003C1C4 File Offset: 0x0003A3C4
			public global::RustProto.Vitals Vitals
			{
				get
				{
					return this.result.Vitals;
				}
				set
				{
					this.SetVitals(value);
				}
			}

			// Token: 0x06000FC4 RID: 4036 RVA: 0x0003C1D0 File Offset: 0x0003A3D0
			public global::RustProto.Avatar.Builder SetVitals(global::RustProto.Vitals value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasVitals = true;
				this.result.vitals_ = value;
				return this;
			}

			// Token: 0x06000FC5 RID: 4037 RVA: 0x0003C200 File Offset: 0x0003A400
			public global::RustProto.Avatar.Builder SetVitals(global::RustProto.Vitals.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasVitals = true;
				this.result.vitals_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FC6 RID: 4038 RVA: 0x0003C240 File Offset: 0x0003A440
			public global::RustProto.Avatar.Builder MergeVitals(global::RustProto.Vitals value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasVitals && this.result.vitals_ != global::RustProto.Vitals.DefaultInstance)
				{
					this.result.vitals_ = global::RustProto.Vitals.CreateBuilder(this.result.vitals_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.vitals_ = value;
				}
				this.result.hasVitals = true;
				return this;
			}

			// Token: 0x06000FC7 RID: 4039 RVA: 0x0003C2C8 File Offset: 0x0003A4C8
			public global::RustProto.Avatar.Builder ClearVitals()
			{
				this.PrepareBuilder();
				this.result.hasVitals = false;
				this.result.vitals_ = null;
				return this;
			}

			// Token: 0x170003BF RID: 959
			// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x0003C2F8 File Offset: 0x0003A4F8
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.Blueprint> BlueprintsList
			{
				get
				{
					return this.PrepareBuilder().blueprints_;
				}
			}

			// Token: 0x170003C0 RID: 960
			// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0003C308 File Offset: 0x0003A508
			public int BlueprintsCount
			{
				get
				{
					return this.result.BlueprintsCount;
				}
			}

			// Token: 0x06000FCA RID: 4042 RVA: 0x0003C318 File Offset: 0x0003A518
			public global::RustProto.Blueprint GetBlueprints(int index)
			{
				return this.result.GetBlueprints(index);
			}

			// Token: 0x06000FCB RID: 4043 RVA: 0x0003C328 File Offset: 0x0003A528
			public global::RustProto.Avatar.Builder SetBlueprints(int index, global::RustProto.Blueprint value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.blueprints_[index] = value;
				return this;
			}

			// Token: 0x06000FCC RID: 4044 RVA: 0x0003C350 File Offset: 0x0003A550
			public global::RustProto.Avatar.Builder SetBlueprints(int index, global::RustProto.Blueprint.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.blueprints_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FCD RID: 4045 RVA: 0x0003C388 File Offset: 0x0003A588
			public global::RustProto.Avatar.Builder AddBlueprints(global::RustProto.Blueprint value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.blueprints_.Add(value);
				return this;
			}

			// Token: 0x06000FCE RID: 4046 RVA: 0x0003C3BC File Offset: 0x0003A5BC
			public global::RustProto.Avatar.Builder AddBlueprints(global::RustProto.Blueprint.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.blueprints_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x06000FCF RID: 4047 RVA: 0x0003C3E8 File Offset: 0x0003A5E8
			public global::RustProto.Avatar.Builder AddRangeBlueprints(global::System.Collections.Generic.IEnumerable<global::RustProto.Blueprint> values)
			{
				this.PrepareBuilder();
				this.result.blueprints_.Add(values);
				return this;
			}

			// Token: 0x06000FD0 RID: 4048 RVA: 0x0003C404 File Offset: 0x0003A604
			public global::RustProto.Avatar.Builder ClearBlueprints()
			{
				this.PrepareBuilder();
				this.result.blueprints_.Clear();
				return this;
			}

			// Token: 0x170003C1 RID: 961
			// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x0003C420 File Offset: 0x0003A620
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.Item> InventoryList
			{
				get
				{
					return this.PrepareBuilder().inventory_;
				}
			}

			// Token: 0x170003C2 RID: 962
			// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x0003C430 File Offset: 0x0003A630
			public int InventoryCount
			{
				get
				{
					return this.result.InventoryCount;
				}
			}

			// Token: 0x06000FD3 RID: 4051 RVA: 0x0003C440 File Offset: 0x0003A640
			public global::RustProto.Item GetInventory(int index)
			{
				return this.result.GetInventory(index);
			}

			// Token: 0x06000FD4 RID: 4052 RVA: 0x0003C450 File Offset: 0x0003A650
			public global::RustProto.Avatar.Builder SetInventory(int index, global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.inventory_[index] = value;
				return this;
			}

			// Token: 0x06000FD5 RID: 4053 RVA: 0x0003C478 File Offset: 0x0003A678
			public global::RustProto.Avatar.Builder SetInventory(int index, global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.inventory_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FD6 RID: 4054 RVA: 0x0003C4B0 File Offset: 0x0003A6B0
			public global::RustProto.Avatar.Builder AddInventory(global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.inventory_.Add(value);
				return this;
			}

			// Token: 0x06000FD7 RID: 4055 RVA: 0x0003C4E4 File Offset: 0x0003A6E4
			public global::RustProto.Avatar.Builder AddInventory(global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.inventory_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x06000FD8 RID: 4056 RVA: 0x0003C510 File Offset: 0x0003A710
			public global::RustProto.Avatar.Builder AddRangeInventory(global::System.Collections.Generic.IEnumerable<global::RustProto.Item> values)
			{
				this.PrepareBuilder();
				this.result.inventory_.Add(values);
				return this;
			}

			// Token: 0x06000FD9 RID: 4057 RVA: 0x0003C52C File Offset: 0x0003A72C
			public global::RustProto.Avatar.Builder ClearInventory()
			{
				this.PrepareBuilder();
				this.result.inventory_.Clear();
				return this;
			}

			// Token: 0x170003C3 RID: 963
			// (get) Token: 0x06000FDA RID: 4058 RVA: 0x0003C548 File Offset: 0x0003A748
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.Item> WearableList
			{
				get
				{
					return this.PrepareBuilder().wearable_;
				}
			}

			// Token: 0x170003C4 RID: 964
			// (get) Token: 0x06000FDB RID: 4059 RVA: 0x0003C558 File Offset: 0x0003A758
			public int WearableCount
			{
				get
				{
					return this.result.WearableCount;
				}
			}

			// Token: 0x06000FDC RID: 4060 RVA: 0x0003C568 File Offset: 0x0003A768
			public global::RustProto.Item GetWearable(int index)
			{
				return this.result.GetWearable(index);
			}

			// Token: 0x06000FDD RID: 4061 RVA: 0x0003C578 File Offset: 0x0003A778
			public global::RustProto.Avatar.Builder SetWearable(int index, global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.wearable_[index] = value;
				return this;
			}

			// Token: 0x06000FDE RID: 4062 RVA: 0x0003C5A0 File Offset: 0x0003A7A0
			public global::RustProto.Avatar.Builder SetWearable(int index, global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.wearable_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FDF RID: 4063 RVA: 0x0003C5D8 File Offset: 0x0003A7D8
			public global::RustProto.Avatar.Builder AddWearable(global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.wearable_.Add(value);
				return this;
			}

			// Token: 0x06000FE0 RID: 4064 RVA: 0x0003C60C File Offset: 0x0003A80C
			public global::RustProto.Avatar.Builder AddWearable(global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.wearable_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x06000FE1 RID: 4065 RVA: 0x0003C638 File Offset: 0x0003A838
			public global::RustProto.Avatar.Builder AddRangeWearable(global::System.Collections.Generic.IEnumerable<global::RustProto.Item> values)
			{
				this.PrepareBuilder();
				this.result.wearable_.Add(values);
				return this;
			}

			// Token: 0x06000FE2 RID: 4066 RVA: 0x0003C654 File Offset: 0x0003A854
			public global::RustProto.Avatar.Builder ClearWearable()
			{
				this.PrepareBuilder();
				this.result.wearable_.Clear();
				return this;
			}

			// Token: 0x170003C5 RID: 965
			// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x0003C670 File Offset: 0x0003A870
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.Item> BeltList
			{
				get
				{
					return this.PrepareBuilder().belt_;
				}
			}

			// Token: 0x170003C6 RID: 966
			// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x0003C680 File Offset: 0x0003A880
			public int BeltCount
			{
				get
				{
					return this.result.BeltCount;
				}
			}

			// Token: 0x06000FE5 RID: 4069 RVA: 0x0003C690 File Offset: 0x0003A890
			public global::RustProto.Item GetBelt(int index)
			{
				return this.result.GetBelt(index);
			}

			// Token: 0x06000FE6 RID: 4070 RVA: 0x0003C6A0 File Offset: 0x0003A8A0
			public global::RustProto.Avatar.Builder SetBelt(int index, global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.belt_[index] = value;
				return this;
			}

			// Token: 0x06000FE7 RID: 4071 RVA: 0x0003C6C8 File Offset: 0x0003A8C8
			public global::RustProto.Avatar.Builder SetBelt(int index, global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.belt_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FE8 RID: 4072 RVA: 0x0003C700 File Offset: 0x0003A900
			public global::RustProto.Avatar.Builder AddBelt(global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.belt_.Add(value);
				return this;
			}

			// Token: 0x06000FE9 RID: 4073 RVA: 0x0003C734 File Offset: 0x0003A934
			public global::RustProto.Avatar.Builder AddBelt(global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.belt_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x06000FEA RID: 4074 RVA: 0x0003C760 File Offset: 0x0003A960
			public global::RustProto.Avatar.Builder AddRangeBelt(global::System.Collections.Generic.IEnumerable<global::RustProto.Item> values)
			{
				this.PrepareBuilder();
				this.result.belt_.Add(values);
				return this;
			}

			// Token: 0x06000FEB RID: 4075 RVA: 0x0003C77C File Offset: 0x0003A97C
			public global::RustProto.Avatar.Builder ClearBelt()
			{
				this.PrepareBuilder();
				this.result.belt_.Clear();
				return this;
			}

			// Token: 0x170003C7 RID: 967
			// (get) Token: 0x06000FEC RID: 4076 RVA: 0x0003C798 File Offset: 0x0003A998
			public bool HasAwayEvent
			{
				get
				{
					return this.result.hasAwayEvent;
				}
			}

			// Token: 0x170003C8 RID: 968
			// (get) Token: 0x06000FED RID: 4077 RVA: 0x0003C7A8 File Offset: 0x0003A9A8
			// (set) Token: 0x06000FEE RID: 4078 RVA: 0x0003C7B8 File Offset: 0x0003A9B8
			public global::RustProto.AwayEvent AwayEvent
			{
				get
				{
					return this.result.AwayEvent;
				}
				set
				{
					this.SetAwayEvent(value);
				}
			}

			// Token: 0x06000FEF RID: 4079 RVA: 0x0003C7C4 File Offset: 0x0003A9C4
			public global::RustProto.Avatar.Builder SetAwayEvent(global::RustProto.AwayEvent value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasAwayEvent = true;
				this.result.awayEvent_ = value;
				return this;
			}

			// Token: 0x06000FF0 RID: 4080 RVA: 0x0003C7F4 File Offset: 0x0003A9F4
			public global::RustProto.Avatar.Builder SetAwayEvent(global::RustProto.AwayEvent.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasAwayEvent = true;
				this.result.awayEvent_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06000FF1 RID: 4081 RVA: 0x0003C834 File Offset: 0x0003AA34
			public global::RustProto.Avatar.Builder MergeAwayEvent(global::RustProto.AwayEvent value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasAwayEvent && this.result.awayEvent_ != global::RustProto.AwayEvent.DefaultInstance)
				{
					this.result.awayEvent_ = global::RustProto.AwayEvent.CreateBuilder(this.result.awayEvent_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.awayEvent_ = value;
				}
				this.result.hasAwayEvent = true;
				return this;
			}

			// Token: 0x06000FF2 RID: 4082 RVA: 0x0003C8BC File Offset: 0x0003AABC
			public global::RustProto.Avatar.Builder ClearAwayEvent()
			{
				this.PrepareBuilder();
				this.result.hasAwayEvent = false;
				this.result.awayEvent_ = null;
				return this;
			}

			// Token: 0x040009DB RID: 2523
			private bool resultIsReadOnly;

			// Token: 0x040009DC RID: 2524
			private global::RustProto.Avatar result;
		}
	}
}
