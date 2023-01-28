using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000245 RID: 581
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class SavedObject : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder>
	{
		// Token: 0x0600112F RID: 4399 RVA: 0x0003F31C File Offset: 0x0003D51C
		private SavedObject()
		{
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x0003F338 File Offset: 0x0003D538
		static SavedObject()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x0003F404 File Offset: 0x0003D604
		public static global::RustProto.Helpers.Recycler<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder>.Manufacture();
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x0003F40C File Offset: 0x0003D60C
		public static global::RustProto.SavedObject DefaultInstance
		{
			get
			{
				return global::RustProto.SavedObject.defaultInstance;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06001133 RID: 4403 RVA: 0x0003F414 File Offset: 0x0003D614
		public override global::RustProto.SavedObject DefaultInstanceForType
		{
			get
			{
				return global::RustProto.SavedObject.DefaultInstance;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x0003F41C File Offset: 0x0003D61C
		protected override global::RustProto.SavedObject ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06001135 RID: 4405 RVA: 0x0003F420 File Offset: 0x0003D620
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_SavedObject__Descriptor;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06001136 RID: 4406 RVA: 0x0003F428 File Offset: 0x0003D628
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_SavedObject__FieldAccessorTable;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06001137 RID: 4407 RVA: 0x0003F430 File Offset: 0x0003D630
		public bool HasId
		{
			get
			{
				return this.hasId;
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06001138 RID: 4408 RVA: 0x0003F438 File Offset: 0x0003D638
		public int Id
		{
			get
			{
				return this.id_;
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06001139 RID: 4409 RVA: 0x0003F440 File Offset: 0x0003D640
		public bool HasDoor
		{
			get
			{
				return this.hasDoor;
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x0600113A RID: 4410 RVA: 0x0003F448 File Offset: 0x0003D648
		public global::RustProto.objectDoor Door
		{
			get
			{
				return this.door_ ?? global::RustProto.objectDoor.DefaultInstance;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x0600113B RID: 4411 RVA: 0x0003F45C File Offset: 0x0003D65C
		public global::System.Collections.Generic.IList<global::RustProto.Item> InventoryList
		{
			get
			{
				return this.inventory_;
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x0003F464 File Offset: 0x0003D664
		public int InventoryCount
		{
			get
			{
				return this.inventory_.Count;
			}
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0003F474 File Offset: 0x0003D674
		public global::RustProto.Item GetInventory(int index)
		{
			return this.inventory_[index];
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x0600113E RID: 4414 RVA: 0x0003F484 File Offset: 0x0003D684
		public bool HasDeployable
		{
			get
			{
				return this.hasDeployable;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600113F RID: 4415 RVA: 0x0003F48C File Offset: 0x0003D68C
		public global::RustProto.objectDeployable Deployable
		{
			get
			{
				return this.deployable_ ?? global::RustProto.objectDeployable.DefaultInstance;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06001140 RID: 4416 RVA: 0x0003F4A0 File Offset: 0x0003D6A0
		public bool HasStructMaster
		{
			get
			{
				return this.hasStructMaster;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06001141 RID: 4417 RVA: 0x0003F4A8 File Offset: 0x0003D6A8
		public global::RustProto.objectStructMaster StructMaster
		{
			get
			{
				return this.structMaster_ ?? global::RustProto.objectStructMaster.DefaultInstance;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06001142 RID: 4418 RVA: 0x0003F4BC File Offset: 0x0003D6BC
		public bool HasStructComponent
		{
			get
			{
				return this.hasStructComponent;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06001143 RID: 4419 RVA: 0x0003F4C4 File Offset: 0x0003D6C4
		public global::RustProto.objectStructComponent StructComponent
		{
			get
			{
				return this.structComponent_ ?? global::RustProto.objectStructComponent.DefaultInstance;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06001144 RID: 4420 RVA: 0x0003F4D8 File Offset: 0x0003D6D8
		public bool HasFireBarrel
		{
			get
			{
				return this.hasFireBarrel;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06001145 RID: 4421 RVA: 0x0003F4E0 File Offset: 0x0003D6E0
		public global::RustProto.objectFireBarrel FireBarrel
		{
			get
			{
				return this.fireBarrel_ ?? global::RustProto.objectFireBarrel.DefaultInstance;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06001146 RID: 4422 RVA: 0x0003F4F4 File Offset: 0x0003D6F4
		public bool HasNetInstance
		{
			get
			{
				return this.hasNetInstance;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06001147 RID: 4423 RVA: 0x0003F4FC File Offset: 0x0003D6FC
		public global::RustProto.objectNetInstance NetInstance
		{
			get
			{
				return this.netInstance_ ?? global::RustProto.objectNetInstance.DefaultInstance;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06001148 RID: 4424 RVA: 0x0003F510 File Offset: 0x0003D710
		public bool HasCoords
		{
			get
			{
				return this.hasCoords;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06001149 RID: 4425 RVA: 0x0003F518 File Offset: 0x0003D718
		public global::RustProto.objectCoords Coords
		{
			get
			{
				return this.coords_ ?? global::RustProto.objectCoords.DefaultInstance;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x0600114A RID: 4426 RVA: 0x0003F52C File Offset: 0x0003D72C
		public bool HasNgcInstance
		{
			get
			{
				return this.hasNgcInstance;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x0003F534 File Offset: 0x0003D734
		public global::RustProto.objectNGCInstance NgcInstance
		{
			get
			{
				return this.ngcInstance_ ?? global::RustProto.objectNGCInstance.DefaultInstance;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x0600114C RID: 4428 RVA: 0x0003F548 File Offset: 0x0003D748
		public bool HasCarriableTrans
		{
			get
			{
				return this.hasCarriableTrans;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x0003F550 File Offset: 0x0003D750
		public global::RustProto.objectICarriableTrans CarriableTrans
		{
			get
			{
				return this.carriableTrans_ ?? global::RustProto.objectICarriableTrans.DefaultInstance;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x0600114E RID: 4430 RVA: 0x0003F564 File Offset: 0x0003D764
		public bool HasTakeDamage
		{
			get
			{
				return this.hasTakeDamage;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x0003F56C File Offset: 0x0003D76C
		public global::RustProto.objectTakeDamage TakeDamage
		{
			get
			{
				return this.takeDamage_ ?? global::RustProto.objectTakeDamage.DefaultInstance;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06001150 RID: 4432 RVA: 0x0003F580 File Offset: 0x0003D780
		public bool HasSortOrder
		{
			get
			{
				return this.hasSortOrder;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06001151 RID: 4433 RVA: 0x0003F588 File Offset: 0x0003D788
		public int SortOrder
		{
			get
			{
				return this.sortOrder_;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06001152 RID: 4434 RVA: 0x0003F590 File Offset: 0x0003D790
		public bool HasSleepingAvatar
		{
			get
			{
				return this.hasSleepingAvatar;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06001153 RID: 4435 RVA: 0x0003F598 File Offset: 0x0003D798
		public global::RustProto.objectSleepingAvatar SleepingAvatar
		{
			get
			{
				return this.sleepingAvatar_ ?? global::RustProto.objectSleepingAvatar.DefaultInstance;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06001154 RID: 4436 RVA: 0x0003F5AC File Offset: 0x0003D7AC
		public bool HasLockable
		{
			get
			{
				return this.hasLockable;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06001155 RID: 4437 RVA: 0x0003F5B4 File Offset: 0x0003D7B4
		public global::RustProto.objectLockable Lockable
		{
			get
			{
				return this.lockable_ ?? global::RustProto.objectLockable.DefaultInstance;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x0003F5C8 File Offset: 0x0003D7C8
		public override bool IsInitialized
		{
			get
			{
				foreach (global::RustProto.Item item in this.InventoryList)
				{
					if (!item.IsInitialized)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x0003F63C File Offset: 0x0003D83C
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] savedObjectFieldNames = global::RustProto.SavedObject._savedObjectFieldNames;
			if (this.hasId)
			{
				output.WriteInt32(1, savedObjectFieldNames[5], this.Id);
			}
			if (this.hasDoor)
			{
				output.WriteMessage(2, savedObjectFieldNames[3], this.Door);
			}
			if (this.inventory_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.Item>(3, savedObjectFieldNames[6], this.inventory_);
			}
			if (this.hasDeployable)
			{
				output.WriteMessage(4, savedObjectFieldNames[2], this.Deployable);
			}
			if (this.hasStructMaster)
			{
				output.WriteMessage(5, savedObjectFieldNames[0xD], this.StructMaster);
			}
			if (this.hasStructComponent)
			{
				output.WriteMessage(6, savedObjectFieldNames[0xC], this.StructComponent);
			}
			if (this.hasFireBarrel)
			{
				output.WriteMessage(7, savedObjectFieldNames[4], this.FireBarrel);
			}
			if (this.hasNetInstance)
			{
				output.WriteMessage(8, savedObjectFieldNames[8], this.NetInstance);
			}
			if (this.hasCoords)
			{
				output.WriteMessage(9, savedObjectFieldNames[1], this.Coords);
			}
			if (this.hasNgcInstance)
			{
				output.WriteMessage(0xA, savedObjectFieldNames[9], this.NgcInstance);
			}
			if (this.hasCarriableTrans)
			{
				output.WriteMessage(0xB, savedObjectFieldNames[0], this.CarriableTrans);
			}
			if (this.hasTakeDamage)
			{
				output.WriteMessage(0xC, savedObjectFieldNames[0xE], this.TakeDamage);
			}
			if (this.hasSortOrder)
			{
				output.WriteInt32(0xD, savedObjectFieldNames[0xB], this.SortOrder);
			}
			if (this.hasSleepingAvatar)
			{
				output.WriteMessage(0xE, savedObjectFieldNames[0xA], this.SleepingAvatar);
			}
			if (this.hasLockable)
			{
				output.WriteMessage(0xF, savedObjectFieldNames[7], this.Lockable);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x0003F80C File Offset: 0x0003DA0C
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
				if (this.hasDoor)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(2, this.Door);
				}
				foreach (global::RustProto.Item item in this.InventoryList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(3, item);
				}
				if (this.hasDeployable)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(4, this.Deployable);
				}
				if (this.hasStructMaster)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(5, this.StructMaster);
				}
				if (this.hasStructComponent)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(6, this.StructComponent);
				}
				if (this.hasFireBarrel)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(7, this.FireBarrel);
				}
				if (this.hasNetInstance)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(8, this.NetInstance);
				}
				if (this.hasCoords)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(9, this.Coords);
				}
				if (this.hasNgcInstance)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(0xA, this.NgcInstance);
				}
				if (this.hasCarriableTrans)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(0xB, this.CarriableTrans);
				}
				if (this.hasTakeDamage)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(0xC, this.TakeDamage);
				}
				if (this.hasSortOrder)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(0xD, this.SortOrder);
				}
				if (this.hasSleepingAvatar)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(0xE, this.SleepingAvatar);
				}
				if (this.hasLockable)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(0xF, this.Lockable);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x0003FA10 File Offset: 0x0003DC10
		public static global::RustProto.SavedObject ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0003FA24 File Offset: 0x0003DC24
		public static global::RustProto.SavedObject ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0003FA38 File Offset: 0x0003DC38
		public static global::RustProto.SavedObject ParseFrom(byte[] data)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x0003FA4C File Offset: 0x0003DC4C
		public static global::RustProto.SavedObject ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x0003FA60 File Offset: 0x0003DC60
		public static global::RustProto.SavedObject ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0003FA74 File Offset: 0x0003DC74
		public static global::RustProto.SavedObject ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x0003FA88 File Offset: 0x0003DC88
		public static global::RustProto.SavedObject ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x0003FA9C File Offset: 0x0003DC9C
		public static global::RustProto.SavedObject ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0003FAB0 File Offset: 0x0003DCB0
		public static global::RustProto.SavedObject ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x0003FAC4 File Offset: 0x0003DCC4
		public static global::RustProto.SavedObject ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.SavedObject.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x0003FAD8 File Offset: 0x0003DCD8
		private global::RustProto.SavedObject MakeReadOnly()
		{
			this.inventory_.MakeReadOnly();
			return this;
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0003FAE8 File Offset: 0x0003DCE8
		public static global::RustProto.SavedObject.Builder CreateBuilder()
		{
			return new global::RustProto.SavedObject.Builder();
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x0003FAF0 File Offset: 0x0003DCF0
		public override global::RustProto.SavedObject.Builder ToBuilder()
		{
			return global::RustProto.SavedObject.CreateBuilder(this);
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x0003FAF8 File Offset: 0x0003DCF8
		public override global::RustProto.SavedObject.Builder CreateBuilderForType()
		{
			return new global::RustProto.SavedObject.Builder();
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x0003FB00 File Offset: 0x0003DD00
		public static global::RustProto.SavedObject.Builder CreateBuilder(global::RustProto.SavedObject prototype)
		{
			return new global::RustProto.SavedObject.Builder(prototype);
		}

		// Token: 0x04000A33 RID: 2611
		public const int IdFieldNumber = 1;

		// Token: 0x04000A34 RID: 2612
		public const int DoorFieldNumber = 2;

		// Token: 0x04000A35 RID: 2613
		public const int InventoryFieldNumber = 3;

		// Token: 0x04000A36 RID: 2614
		public const int DeployableFieldNumber = 4;

		// Token: 0x04000A37 RID: 2615
		public const int StructMasterFieldNumber = 5;

		// Token: 0x04000A38 RID: 2616
		public const int StructComponentFieldNumber = 6;

		// Token: 0x04000A39 RID: 2617
		public const int FireBarrelFieldNumber = 7;

		// Token: 0x04000A3A RID: 2618
		public const int NetInstanceFieldNumber = 8;

		// Token: 0x04000A3B RID: 2619
		public const int CoordsFieldNumber = 9;

		// Token: 0x04000A3C RID: 2620
		public const int NgcInstanceFieldNumber = 0xA;

		// Token: 0x04000A3D RID: 2621
		public const int CarriableTransFieldNumber = 0xB;

		// Token: 0x04000A3E RID: 2622
		public const int TakeDamageFieldNumber = 0xC;

		// Token: 0x04000A3F RID: 2623
		public const int SortOrderFieldNumber = 0xD;

		// Token: 0x04000A40 RID: 2624
		public const int SleepingAvatarFieldNumber = 0xE;

		// Token: 0x04000A41 RID: 2625
		public const int LockableFieldNumber = 0xF;

		// Token: 0x04000A42 RID: 2626
		private static readonly global::RustProto.SavedObject defaultInstance = new global::RustProto.SavedObject().MakeReadOnly();

		// Token: 0x04000A43 RID: 2627
		private static readonly string[] _savedObjectFieldNames = new string[]
		{
			"carriableTrans",
			"coords",
			"deployable",
			"door",
			"fireBarrel",
			"id",
			"inventory",
			"lockable",
			"netInstance",
			"ngcInstance",
			"sleepingAvatar",
			"sortOrder",
			"structComponent",
			"structMaster",
			"takeDamage"
		};

		// Token: 0x04000A44 RID: 2628
		private static readonly uint[] _savedObjectFieldTags = new uint[]
		{
			0x5AU,
			0x4AU,
			0x22U,
			0x12U,
			0x3AU,
			8U,
			0x1AU,
			0x7AU,
			0x42U,
			0x52U,
			0x72U,
			0x68U,
			0x32U,
			0x2AU,
			0x62U
		};

		// Token: 0x04000A45 RID: 2629
		private bool hasId;

		// Token: 0x04000A46 RID: 2630
		private int id_;

		// Token: 0x04000A47 RID: 2631
		private bool hasDoor;

		// Token: 0x04000A48 RID: 2632
		private global::RustProto.objectDoor door_;

		// Token: 0x04000A49 RID: 2633
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item> inventory_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.Item>();

		// Token: 0x04000A4A RID: 2634
		private bool hasDeployable;

		// Token: 0x04000A4B RID: 2635
		private global::RustProto.objectDeployable deployable_;

		// Token: 0x04000A4C RID: 2636
		private bool hasStructMaster;

		// Token: 0x04000A4D RID: 2637
		private global::RustProto.objectStructMaster structMaster_;

		// Token: 0x04000A4E RID: 2638
		private bool hasStructComponent;

		// Token: 0x04000A4F RID: 2639
		private global::RustProto.objectStructComponent structComponent_;

		// Token: 0x04000A50 RID: 2640
		private bool hasFireBarrel;

		// Token: 0x04000A51 RID: 2641
		private global::RustProto.objectFireBarrel fireBarrel_;

		// Token: 0x04000A52 RID: 2642
		private bool hasNetInstance;

		// Token: 0x04000A53 RID: 2643
		private global::RustProto.objectNetInstance netInstance_;

		// Token: 0x04000A54 RID: 2644
		private bool hasCoords;

		// Token: 0x04000A55 RID: 2645
		private global::RustProto.objectCoords coords_;

		// Token: 0x04000A56 RID: 2646
		private bool hasNgcInstance;

		// Token: 0x04000A57 RID: 2647
		private global::RustProto.objectNGCInstance ngcInstance_;

		// Token: 0x04000A58 RID: 2648
		private bool hasCarriableTrans;

		// Token: 0x04000A59 RID: 2649
		private global::RustProto.objectICarriableTrans carriableTrans_;

		// Token: 0x04000A5A RID: 2650
		private bool hasTakeDamage;

		// Token: 0x04000A5B RID: 2651
		private global::RustProto.objectTakeDamage takeDamage_;

		// Token: 0x04000A5C RID: 2652
		private bool hasSortOrder;

		// Token: 0x04000A5D RID: 2653
		private int sortOrder_;

		// Token: 0x04000A5E RID: 2654
		private bool hasSleepingAvatar;

		// Token: 0x04000A5F RID: 2655
		private global::RustProto.objectSleepingAvatar sleepingAvatar_;

		// Token: 0x04000A60 RID: 2656
		private bool hasLockable;

		// Token: 0x04000A61 RID: 2657
		private global::RustProto.objectLockable lockable_;

		// Token: 0x04000A62 RID: 2658
		private int memoizedSerializedSize = -1;

		// Token: 0x02000246 RID: 582
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder>
		{
			// Token: 0x06001168 RID: 4456 RVA: 0x0003FB08 File Offset: 0x0003DD08
			public Builder()
			{
				this.result = global::RustProto.SavedObject.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001169 RID: 4457 RVA: 0x0003FB24 File Offset: 0x0003DD24
			internal Builder(global::RustProto.SavedObject cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000472 RID: 1138
			// (get) Token: 0x0600116A RID: 4458 RVA: 0x0003FB3C File Offset: 0x0003DD3C
			protected override global::RustProto.SavedObject.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x0600116B RID: 4459 RVA: 0x0003FB40 File Offset: 0x0003DD40
			private global::RustProto.SavedObject PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.SavedObject other = this.result;
					this.result = new global::RustProto.SavedObject();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000473 RID: 1139
			// (get) Token: 0x0600116C RID: 4460 RVA: 0x0003FB80 File Offset: 0x0003DD80
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000474 RID: 1140
			// (get) Token: 0x0600116D RID: 4461 RVA: 0x0003FB90 File Offset: 0x0003DD90
			protected override global::RustProto.SavedObject MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x0600116E RID: 4462 RVA: 0x0003FB98 File Offset: 0x0003DD98
			public override global::RustProto.SavedObject.Builder Clear()
			{
				this.result = global::RustProto.SavedObject.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x0600116F RID: 4463 RVA: 0x0003FBB0 File Offset: 0x0003DDB0
			public override global::RustProto.SavedObject.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.SavedObject.Builder(this.result);
				}
				return new global::RustProto.SavedObject.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000475 RID: 1141
			// (get) Token: 0x06001170 RID: 4464 RVA: 0x0003FBDC File Offset: 0x0003DDDC
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.SavedObject.Descriptor;
				}
			}

			// Token: 0x17000476 RID: 1142
			// (get) Token: 0x06001171 RID: 4465 RVA: 0x0003FBE4 File Offset: 0x0003DDE4
			public override global::RustProto.SavedObject DefaultInstanceForType
			{
				get
				{
					return global::RustProto.SavedObject.DefaultInstance;
				}
			}

			// Token: 0x06001172 RID: 4466 RVA: 0x0003FBEC File Offset: 0x0003DDEC
			public override global::RustProto.SavedObject BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001173 RID: 4467 RVA: 0x0003FC20 File Offset: 0x0003DE20
			public override global::RustProto.SavedObject.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.SavedObject)
				{
					return this.MergeFrom((global::RustProto.SavedObject)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001174 RID: 4468 RVA: 0x0003FC44 File Offset: 0x0003DE44
			public override global::RustProto.SavedObject.Builder MergeFrom(global::RustProto.SavedObject other)
			{
				if (other == global::RustProto.SavedObject.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasId)
				{
					this.Id = other.Id;
				}
				if (other.HasDoor)
				{
					this.MergeDoor(other.Door);
				}
				if (other.inventory_.Count != 0)
				{
					this.result.inventory_.Add(other.inventory_);
				}
				if (other.HasDeployable)
				{
					this.MergeDeployable(other.Deployable);
				}
				if (other.HasStructMaster)
				{
					this.MergeStructMaster(other.StructMaster);
				}
				if (other.HasStructComponent)
				{
					this.MergeStructComponent(other.StructComponent);
				}
				if (other.HasFireBarrel)
				{
					this.MergeFireBarrel(other.FireBarrel);
				}
				if (other.HasNetInstance)
				{
					this.MergeNetInstance(other.NetInstance);
				}
				if (other.HasCoords)
				{
					this.MergeCoords(other.Coords);
				}
				if (other.HasNgcInstance)
				{
					this.MergeNgcInstance(other.NgcInstance);
				}
				if (other.HasCarriableTrans)
				{
					this.MergeCarriableTrans(other.CarriableTrans);
				}
				if (other.HasTakeDamage)
				{
					this.MergeTakeDamage(other.TakeDamage);
				}
				if (other.HasSortOrder)
				{
					this.SortOrder = other.SortOrder;
				}
				if (other.HasSleepingAvatar)
				{
					this.MergeSleepingAvatar(other.SleepingAvatar);
				}
				if (other.HasLockable)
				{
					this.MergeLockable(other.Lockable);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001175 RID: 4469 RVA: 0x0003FDE8 File Offset: 0x0003DFE8
			public override global::RustProto.SavedObject.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001176 RID: 4470 RVA: 0x0003FDF8 File Offset: 0x0003DFF8
			public override global::RustProto.SavedObject.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.SavedObject._savedObjectFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.SavedObject._savedObjectFieldTags[num2];
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
													if (num3 != 0x4AU)
													{
														if (num3 != 0x52U)
														{
															if (num3 != 0x5AU)
															{
																if (num3 != 0x62U)
																{
																	if (num3 != 0x68U)
																	{
																		if (num3 != 0x72U)
																		{
																			if (num3 != 0x7AU)
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
																				global::RustProto.objectLockable.Builder builder2 = global::RustProto.objectLockable.CreateBuilder();
																				if (this.result.hasLockable)
																				{
																					builder2.MergeFrom(this.Lockable);
																				}
																				input.ReadMessage(builder2, extensionRegistry);
																				this.Lockable = builder2.BuildPartial();
																			}
																		}
																		else
																		{
																			global::RustProto.objectSleepingAvatar.Builder builder3 = global::RustProto.objectSleepingAvatar.CreateBuilder();
																			if (this.result.hasSleepingAvatar)
																			{
																				builder3.MergeFrom(this.SleepingAvatar);
																			}
																			input.ReadMessage(builder3, extensionRegistry);
																			this.SleepingAvatar = builder3.BuildPartial();
																		}
																	}
																	else
																	{
																		this.result.hasSortOrder = input.ReadInt32(ref this.result.sortOrder_);
																	}
																}
																else
																{
																	global::RustProto.objectTakeDamage.Builder builder4 = global::RustProto.objectTakeDamage.CreateBuilder();
																	if (this.result.hasTakeDamage)
																	{
																		builder4.MergeFrom(this.TakeDamage);
																	}
																	input.ReadMessage(builder4, extensionRegistry);
																	this.TakeDamage = builder4.BuildPartial();
																}
															}
															else
															{
																global::RustProto.objectICarriableTrans.Builder builder5 = global::RustProto.objectICarriableTrans.CreateBuilder();
																if (this.result.hasCarriableTrans)
																{
																	builder5.MergeFrom(this.CarriableTrans);
																}
																input.ReadMessage(builder5, extensionRegistry);
																this.CarriableTrans = builder5.BuildPartial();
															}
														}
														else
														{
															global::RustProto.objectNGCInstance.Builder builder6 = global::RustProto.objectNGCInstance.CreateBuilder();
															if (this.result.hasNgcInstance)
															{
																builder6.MergeFrom(this.NgcInstance);
															}
															input.ReadMessage(builder6, extensionRegistry);
															this.NgcInstance = builder6.BuildPartial();
														}
													}
													else
													{
														global::RustProto.objectCoords.Builder builder7 = global::RustProto.objectCoords.CreateBuilder();
														if (this.result.hasCoords)
														{
															builder7.MergeFrom(this.Coords);
														}
														input.ReadMessage(builder7, extensionRegistry);
														this.Coords = builder7.BuildPartial();
													}
												}
												else
												{
													global::RustProto.objectNetInstance.Builder builder8 = global::RustProto.objectNetInstance.CreateBuilder();
													if (this.result.hasNetInstance)
													{
														builder8.MergeFrom(this.NetInstance);
													}
													input.ReadMessage(builder8, extensionRegistry);
													this.NetInstance = builder8.BuildPartial();
												}
											}
											else
											{
												global::RustProto.objectFireBarrel.Builder builder9 = global::RustProto.objectFireBarrel.CreateBuilder();
												if (this.result.hasFireBarrel)
												{
													builder9.MergeFrom(this.FireBarrel);
												}
												input.ReadMessage(builder9, extensionRegistry);
												this.FireBarrel = builder9.BuildPartial();
											}
										}
										else
										{
											global::RustProto.objectStructComponent.Builder builder10 = global::RustProto.objectStructComponent.CreateBuilder();
											if (this.result.hasStructComponent)
											{
												builder10.MergeFrom(this.StructComponent);
											}
											input.ReadMessage(builder10, extensionRegistry);
											this.StructComponent = builder10.BuildPartial();
										}
									}
									else
									{
										global::RustProto.objectStructMaster.Builder builder11 = global::RustProto.objectStructMaster.CreateBuilder();
										if (this.result.hasStructMaster)
										{
											builder11.MergeFrom(this.StructMaster);
										}
										input.ReadMessage(builder11, extensionRegistry);
										this.StructMaster = builder11.BuildPartial();
									}
								}
								else
								{
									global::RustProto.objectDeployable.Builder builder12 = global::RustProto.objectDeployable.CreateBuilder();
									if (this.result.hasDeployable)
									{
										builder12.MergeFrom(this.Deployable);
									}
									input.ReadMessage(builder12, extensionRegistry);
									this.Deployable = builder12.BuildPartial();
								}
							}
							else
							{
								input.ReadMessageArray<global::RustProto.Item>(num, text, this.result.inventory_, global::RustProto.Item.DefaultInstance, extensionRegistry);
							}
						}
						else
						{
							global::RustProto.objectDoor.Builder builder13 = global::RustProto.objectDoor.CreateBuilder();
							if (this.result.hasDoor)
							{
								builder13.MergeFrom(this.Door);
							}
							input.ReadMessage(builder13, extensionRegistry);
							this.Door = builder13.BuildPartial();
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

			// Token: 0x17000477 RID: 1143
			// (get) Token: 0x06001177 RID: 4471 RVA: 0x000402C8 File Offset: 0x0003E4C8
			public bool HasId
			{
				get
				{
					return this.result.hasId;
				}
			}

			// Token: 0x17000478 RID: 1144
			// (get) Token: 0x06001178 RID: 4472 RVA: 0x000402D8 File Offset: 0x0003E4D8
			// (set) Token: 0x06001179 RID: 4473 RVA: 0x000402E8 File Offset: 0x0003E4E8
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

			// Token: 0x0600117A RID: 4474 RVA: 0x000402F4 File Offset: 0x0003E4F4
			public global::RustProto.SavedObject.Builder SetId(int value)
			{
				this.PrepareBuilder();
				this.result.hasId = true;
				this.result.id_ = value;
				return this;
			}

			// Token: 0x0600117B RID: 4475 RVA: 0x00040324 File Offset: 0x0003E524
			public global::RustProto.SavedObject.Builder ClearId()
			{
				this.PrepareBuilder();
				this.result.hasId = false;
				this.result.id_ = 0;
				return this;
			}

			// Token: 0x17000479 RID: 1145
			// (get) Token: 0x0600117C RID: 4476 RVA: 0x00040354 File Offset: 0x0003E554
			public bool HasDoor
			{
				get
				{
					return this.result.hasDoor;
				}
			}

			// Token: 0x1700047A RID: 1146
			// (get) Token: 0x0600117D RID: 4477 RVA: 0x00040364 File Offset: 0x0003E564
			// (set) Token: 0x0600117E RID: 4478 RVA: 0x00040374 File Offset: 0x0003E574
			public global::RustProto.objectDoor Door
			{
				get
				{
					return this.result.Door;
				}
				set
				{
					this.SetDoor(value);
				}
			}

			// Token: 0x0600117F RID: 4479 RVA: 0x00040380 File Offset: 0x0003E580
			public global::RustProto.SavedObject.Builder SetDoor(global::RustProto.objectDoor value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasDoor = true;
				this.result.door_ = value;
				return this;
			}

			// Token: 0x06001180 RID: 4480 RVA: 0x000403B0 File Offset: 0x0003E5B0
			public global::RustProto.SavedObject.Builder SetDoor(global::RustProto.objectDoor.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasDoor = true;
				this.result.door_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001181 RID: 4481 RVA: 0x000403F0 File Offset: 0x0003E5F0
			public global::RustProto.SavedObject.Builder MergeDoor(global::RustProto.objectDoor value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasDoor && this.result.door_ != global::RustProto.objectDoor.DefaultInstance)
				{
					this.result.door_ = global::RustProto.objectDoor.CreateBuilder(this.result.door_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.door_ = value;
				}
				this.result.hasDoor = true;
				return this;
			}

			// Token: 0x06001182 RID: 4482 RVA: 0x00040478 File Offset: 0x0003E678
			public global::RustProto.SavedObject.Builder ClearDoor()
			{
				this.PrepareBuilder();
				this.result.hasDoor = false;
				this.result.door_ = null;
				return this;
			}

			// Token: 0x1700047B RID: 1147
			// (get) Token: 0x06001183 RID: 4483 RVA: 0x000404A8 File Offset: 0x0003E6A8
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.Item> InventoryList
			{
				get
				{
					return this.PrepareBuilder().inventory_;
				}
			}

			// Token: 0x1700047C RID: 1148
			// (get) Token: 0x06001184 RID: 4484 RVA: 0x000404B8 File Offset: 0x0003E6B8
			public int InventoryCount
			{
				get
				{
					return this.result.InventoryCount;
				}
			}

			// Token: 0x06001185 RID: 4485 RVA: 0x000404C8 File Offset: 0x0003E6C8
			public global::RustProto.Item GetInventory(int index)
			{
				return this.result.GetInventory(index);
			}

			// Token: 0x06001186 RID: 4486 RVA: 0x000404D8 File Offset: 0x0003E6D8
			public global::RustProto.SavedObject.Builder SetInventory(int index, global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.inventory_[index] = value;
				return this;
			}

			// Token: 0x06001187 RID: 4487 RVA: 0x00040500 File Offset: 0x0003E700
			public global::RustProto.SavedObject.Builder SetInventory(int index, global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.inventory_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06001188 RID: 4488 RVA: 0x00040538 File Offset: 0x0003E738
			public global::RustProto.SavedObject.Builder AddInventory(global::RustProto.Item value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.inventory_.Add(value);
				return this;
			}

			// Token: 0x06001189 RID: 4489 RVA: 0x0004056C File Offset: 0x0003E76C
			public global::RustProto.SavedObject.Builder AddInventory(global::RustProto.Item.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.inventory_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x0600118A RID: 4490 RVA: 0x00040598 File Offset: 0x0003E798
			public global::RustProto.SavedObject.Builder AddRangeInventory(global::System.Collections.Generic.IEnumerable<global::RustProto.Item> values)
			{
				this.PrepareBuilder();
				this.result.inventory_.Add(values);
				return this;
			}

			// Token: 0x0600118B RID: 4491 RVA: 0x000405B4 File Offset: 0x0003E7B4
			public global::RustProto.SavedObject.Builder ClearInventory()
			{
				this.PrepareBuilder();
				this.result.inventory_.Clear();
				return this;
			}

			// Token: 0x1700047D RID: 1149
			// (get) Token: 0x0600118C RID: 4492 RVA: 0x000405D0 File Offset: 0x0003E7D0
			public bool HasDeployable
			{
				get
				{
					return this.result.hasDeployable;
				}
			}

			// Token: 0x1700047E RID: 1150
			// (get) Token: 0x0600118D RID: 4493 RVA: 0x000405E0 File Offset: 0x0003E7E0
			// (set) Token: 0x0600118E RID: 4494 RVA: 0x000405F0 File Offset: 0x0003E7F0
			public global::RustProto.objectDeployable Deployable
			{
				get
				{
					return this.result.Deployable;
				}
				set
				{
					this.SetDeployable(value);
				}
			}

			// Token: 0x0600118F RID: 4495 RVA: 0x000405FC File Offset: 0x0003E7FC
			public global::RustProto.SavedObject.Builder SetDeployable(global::RustProto.objectDeployable value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasDeployable = true;
				this.result.deployable_ = value;
				return this;
			}

			// Token: 0x06001190 RID: 4496 RVA: 0x0004062C File Offset: 0x0003E82C
			public global::RustProto.SavedObject.Builder SetDeployable(global::RustProto.objectDeployable.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasDeployable = true;
				this.result.deployable_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001191 RID: 4497 RVA: 0x0004066C File Offset: 0x0003E86C
			public global::RustProto.SavedObject.Builder MergeDeployable(global::RustProto.objectDeployable value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasDeployable && this.result.deployable_ != global::RustProto.objectDeployable.DefaultInstance)
				{
					this.result.deployable_ = global::RustProto.objectDeployable.CreateBuilder(this.result.deployable_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.deployable_ = value;
				}
				this.result.hasDeployable = true;
				return this;
			}

			// Token: 0x06001192 RID: 4498 RVA: 0x000406F4 File Offset: 0x0003E8F4
			public global::RustProto.SavedObject.Builder ClearDeployable()
			{
				this.PrepareBuilder();
				this.result.hasDeployable = false;
				this.result.deployable_ = null;
				return this;
			}

			// Token: 0x1700047F RID: 1151
			// (get) Token: 0x06001193 RID: 4499 RVA: 0x00040724 File Offset: 0x0003E924
			public bool HasStructMaster
			{
				get
				{
					return this.result.hasStructMaster;
				}
			}

			// Token: 0x17000480 RID: 1152
			// (get) Token: 0x06001194 RID: 4500 RVA: 0x00040734 File Offset: 0x0003E934
			// (set) Token: 0x06001195 RID: 4501 RVA: 0x00040744 File Offset: 0x0003E944
			public global::RustProto.objectStructMaster StructMaster
			{
				get
				{
					return this.result.StructMaster;
				}
				set
				{
					this.SetStructMaster(value);
				}
			}

			// Token: 0x06001196 RID: 4502 RVA: 0x00040750 File Offset: 0x0003E950
			public global::RustProto.SavedObject.Builder SetStructMaster(global::RustProto.objectStructMaster value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasStructMaster = true;
				this.result.structMaster_ = value;
				return this;
			}

			// Token: 0x06001197 RID: 4503 RVA: 0x00040780 File Offset: 0x0003E980
			public global::RustProto.SavedObject.Builder SetStructMaster(global::RustProto.objectStructMaster.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasStructMaster = true;
				this.result.structMaster_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001198 RID: 4504 RVA: 0x000407C0 File Offset: 0x0003E9C0
			public global::RustProto.SavedObject.Builder MergeStructMaster(global::RustProto.objectStructMaster value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasStructMaster && this.result.structMaster_ != global::RustProto.objectStructMaster.DefaultInstance)
				{
					this.result.structMaster_ = global::RustProto.objectStructMaster.CreateBuilder(this.result.structMaster_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.structMaster_ = value;
				}
				this.result.hasStructMaster = true;
				return this;
			}

			// Token: 0x06001199 RID: 4505 RVA: 0x00040848 File Offset: 0x0003EA48
			public global::RustProto.SavedObject.Builder ClearStructMaster()
			{
				this.PrepareBuilder();
				this.result.hasStructMaster = false;
				this.result.structMaster_ = null;
				return this;
			}

			// Token: 0x17000481 RID: 1153
			// (get) Token: 0x0600119A RID: 4506 RVA: 0x00040878 File Offset: 0x0003EA78
			public bool HasStructComponent
			{
				get
				{
					return this.result.hasStructComponent;
				}
			}

			// Token: 0x17000482 RID: 1154
			// (get) Token: 0x0600119B RID: 4507 RVA: 0x00040888 File Offset: 0x0003EA88
			// (set) Token: 0x0600119C RID: 4508 RVA: 0x00040898 File Offset: 0x0003EA98
			public global::RustProto.objectStructComponent StructComponent
			{
				get
				{
					return this.result.StructComponent;
				}
				set
				{
					this.SetStructComponent(value);
				}
			}

			// Token: 0x0600119D RID: 4509 RVA: 0x000408A4 File Offset: 0x0003EAA4
			public global::RustProto.SavedObject.Builder SetStructComponent(global::RustProto.objectStructComponent value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasStructComponent = true;
				this.result.structComponent_ = value;
				return this;
			}

			// Token: 0x0600119E RID: 4510 RVA: 0x000408D4 File Offset: 0x0003EAD4
			public global::RustProto.SavedObject.Builder SetStructComponent(global::RustProto.objectStructComponent.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasStructComponent = true;
				this.result.structComponent_ = builderForValue.Build();
				return this;
			}

			// Token: 0x0600119F RID: 4511 RVA: 0x00040914 File Offset: 0x0003EB14
			public global::RustProto.SavedObject.Builder MergeStructComponent(global::RustProto.objectStructComponent value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasStructComponent && this.result.structComponent_ != global::RustProto.objectStructComponent.DefaultInstance)
				{
					this.result.structComponent_ = global::RustProto.objectStructComponent.CreateBuilder(this.result.structComponent_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.structComponent_ = value;
				}
				this.result.hasStructComponent = true;
				return this;
			}

			// Token: 0x060011A0 RID: 4512 RVA: 0x0004099C File Offset: 0x0003EB9C
			public global::RustProto.SavedObject.Builder ClearStructComponent()
			{
				this.PrepareBuilder();
				this.result.hasStructComponent = false;
				this.result.structComponent_ = null;
				return this;
			}

			// Token: 0x17000483 RID: 1155
			// (get) Token: 0x060011A1 RID: 4513 RVA: 0x000409CC File Offset: 0x0003EBCC
			public bool HasFireBarrel
			{
				get
				{
					return this.result.hasFireBarrel;
				}
			}

			// Token: 0x17000484 RID: 1156
			// (get) Token: 0x060011A2 RID: 4514 RVA: 0x000409DC File Offset: 0x0003EBDC
			// (set) Token: 0x060011A3 RID: 4515 RVA: 0x000409EC File Offset: 0x0003EBEC
			public global::RustProto.objectFireBarrel FireBarrel
			{
				get
				{
					return this.result.FireBarrel;
				}
				set
				{
					this.SetFireBarrel(value);
				}
			}

			// Token: 0x060011A4 RID: 4516 RVA: 0x000409F8 File Offset: 0x0003EBF8
			public global::RustProto.SavedObject.Builder SetFireBarrel(global::RustProto.objectFireBarrel value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasFireBarrel = true;
				this.result.fireBarrel_ = value;
				return this;
			}

			// Token: 0x060011A5 RID: 4517 RVA: 0x00040A28 File Offset: 0x0003EC28
			public global::RustProto.SavedObject.Builder SetFireBarrel(global::RustProto.objectFireBarrel.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasFireBarrel = true;
				this.result.fireBarrel_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011A6 RID: 4518 RVA: 0x00040A68 File Offset: 0x0003EC68
			public global::RustProto.SavedObject.Builder MergeFireBarrel(global::RustProto.objectFireBarrel value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasFireBarrel && this.result.fireBarrel_ != global::RustProto.objectFireBarrel.DefaultInstance)
				{
					this.result.fireBarrel_ = global::RustProto.objectFireBarrel.CreateBuilder(this.result.fireBarrel_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.fireBarrel_ = value;
				}
				this.result.hasFireBarrel = true;
				return this;
			}

			// Token: 0x060011A7 RID: 4519 RVA: 0x00040AF0 File Offset: 0x0003ECF0
			public global::RustProto.SavedObject.Builder ClearFireBarrel()
			{
				this.PrepareBuilder();
				this.result.hasFireBarrel = false;
				this.result.fireBarrel_ = null;
				return this;
			}

			// Token: 0x17000485 RID: 1157
			// (get) Token: 0x060011A8 RID: 4520 RVA: 0x00040B20 File Offset: 0x0003ED20
			public bool HasNetInstance
			{
				get
				{
					return this.result.hasNetInstance;
				}
			}

			// Token: 0x17000486 RID: 1158
			// (get) Token: 0x060011A9 RID: 4521 RVA: 0x00040B30 File Offset: 0x0003ED30
			// (set) Token: 0x060011AA RID: 4522 RVA: 0x00040B40 File Offset: 0x0003ED40
			public global::RustProto.objectNetInstance NetInstance
			{
				get
				{
					return this.result.NetInstance;
				}
				set
				{
					this.SetNetInstance(value);
				}
			}

			// Token: 0x060011AB RID: 4523 RVA: 0x00040B4C File Offset: 0x0003ED4C
			public global::RustProto.SavedObject.Builder SetNetInstance(global::RustProto.objectNetInstance value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasNetInstance = true;
				this.result.netInstance_ = value;
				return this;
			}

			// Token: 0x060011AC RID: 4524 RVA: 0x00040B7C File Offset: 0x0003ED7C
			public global::RustProto.SavedObject.Builder SetNetInstance(global::RustProto.objectNetInstance.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasNetInstance = true;
				this.result.netInstance_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011AD RID: 4525 RVA: 0x00040BBC File Offset: 0x0003EDBC
			public global::RustProto.SavedObject.Builder MergeNetInstance(global::RustProto.objectNetInstance value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasNetInstance && this.result.netInstance_ != global::RustProto.objectNetInstance.DefaultInstance)
				{
					this.result.netInstance_ = global::RustProto.objectNetInstance.CreateBuilder(this.result.netInstance_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.netInstance_ = value;
				}
				this.result.hasNetInstance = true;
				return this;
			}

			// Token: 0x060011AE RID: 4526 RVA: 0x00040C44 File Offset: 0x0003EE44
			public global::RustProto.SavedObject.Builder ClearNetInstance()
			{
				this.PrepareBuilder();
				this.result.hasNetInstance = false;
				this.result.netInstance_ = null;
				return this;
			}

			// Token: 0x17000487 RID: 1159
			// (get) Token: 0x060011AF RID: 4527 RVA: 0x00040C74 File Offset: 0x0003EE74
			public bool HasCoords
			{
				get
				{
					return this.result.hasCoords;
				}
			}

			// Token: 0x17000488 RID: 1160
			// (get) Token: 0x060011B0 RID: 4528 RVA: 0x00040C84 File Offset: 0x0003EE84
			// (set) Token: 0x060011B1 RID: 4529 RVA: 0x00040C94 File Offset: 0x0003EE94
			public global::RustProto.objectCoords Coords
			{
				get
				{
					return this.result.Coords;
				}
				set
				{
					this.SetCoords(value);
				}
			}

			// Token: 0x060011B2 RID: 4530 RVA: 0x00040CA0 File Offset: 0x0003EEA0
			public global::RustProto.SavedObject.Builder SetCoords(global::RustProto.objectCoords value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasCoords = true;
				this.result.coords_ = value;
				return this;
			}

			// Token: 0x060011B3 RID: 4531 RVA: 0x00040CD0 File Offset: 0x0003EED0
			public global::RustProto.SavedObject.Builder SetCoords(global::RustProto.objectCoords.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasCoords = true;
				this.result.coords_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011B4 RID: 4532 RVA: 0x00040D10 File Offset: 0x0003EF10
			public global::RustProto.SavedObject.Builder MergeCoords(global::RustProto.objectCoords value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasCoords && this.result.coords_ != global::RustProto.objectCoords.DefaultInstance)
				{
					this.result.coords_ = global::RustProto.objectCoords.CreateBuilder(this.result.coords_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.coords_ = value;
				}
				this.result.hasCoords = true;
				return this;
			}

			// Token: 0x060011B5 RID: 4533 RVA: 0x00040D98 File Offset: 0x0003EF98
			public global::RustProto.SavedObject.Builder ClearCoords()
			{
				this.PrepareBuilder();
				this.result.hasCoords = false;
				this.result.coords_ = null;
				return this;
			}

			// Token: 0x17000489 RID: 1161
			// (get) Token: 0x060011B6 RID: 4534 RVA: 0x00040DC8 File Offset: 0x0003EFC8
			public bool HasNgcInstance
			{
				get
				{
					return this.result.hasNgcInstance;
				}
			}

			// Token: 0x1700048A RID: 1162
			// (get) Token: 0x060011B7 RID: 4535 RVA: 0x00040DD8 File Offset: 0x0003EFD8
			// (set) Token: 0x060011B8 RID: 4536 RVA: 0x00040DE8 File Offset: 0x0003EFE8
			public global::RustProto.objectNGCInstance NgcInstance
			{
				get
				{
					return this.result.NgcInstance;
				}
				set
				{
					this.SetNgcInstance(value);
				}
			}

			// Token: 0x060011B9 RID: 4537 RVA: 0x00040DF4 File Offset: 0x0003EFF4
			public global::RustProto.SavedObject.Builder SetNgcInstance(global::RustProto.objectNGCInstance value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasNgcInstance = true;
				this.result.ngcInstance_ = value;
				return this;
			}

			// Token: 0x060011BA RID: 4538 RVA: 0x00040E24 File Offset: 0x0003F024
			public global::RustProto.SavedObject.Builder SetNgcInstance(global::RustProto.objectNGCInstance.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasNgcInstance = true;
				this.result.ngcInstance_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011BB RID: 4539 RVA: 0x00040E64 File Offset: 0x0003F064
			public global::RustProto.SavedObject.Builder MergeNgcInstance(global::RustProto.objectNGCInstance value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasNgcInstance && this.result.ngcInstance_ != global::RustProto.objectNGCInstance.DefaultInstance)
				{
					this.result.ngcInstance_ = global::RustProto.objectNGCInstance.CreateBuilder(this.result.ngcInstance_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.ngcInstance_ = value;
				}
				this.result.hasNgcInstance = true;
				return this;
			}

			// Token: 0x060011BC RID: 4540 RVA: 0x00040EEC File Offset: 0x0003F0EC
			public global::RustProto.SavedObject.Builder ClearNgcInstance()
			{
				this.PrepareBuilder();
				this.result.hasNgcInstance = false;
				this.result.ngcInstance_ = null;
				return this;
			}

			// Token: 0x1700048B RID: 1163
			// (get) Token: 0x060011BD RID: 4541 RVA: 0x00040F1C File Offset: 0x0003F11C
			public bool HasCarriableTrans
			{
				get
				{
					return this.result.hasCarriableTrans;
				}
			}

			// Token: 0x1700048C RID: 1164
			// (get) Token: 0x060011BE RID: 4542 RVA: 0x00040F2C File Offset: 0x0003F12C
			// (set) Token: 0x060011BF RID: 4543 RVA: 0x00040F3C File Offset: 0x0003F13C
			public global::RustProto.objectICarriableTrans CarriableTrans
			{
				get
				{
					return this.result.CarriableTrans;
				}
				set
				{
					this.SetCarriableTrans(value);
				}
			}

			// Token: 0x060011C0 RID: 4544 RVA: 0x00040F48 File Offset: 0x0003F148
			public global::RustProto.SavedObject.Builder SetCarriableTrans(global::RustProto.objectICarriableTrans value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasCarriableTrans = true;
				this.result.carriableTrans_ = value;
				return this;
			}

			// Token: 0x060011C1 RID: 4545 RVA: 0x00040F78 File Offset: 0x0003F178
			public global::RustProto.SavedObject.Builder SetCarriableTrans(global::RustProto.objectICarriableTrans.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasCarriableTrans = true;
				this.result.carriableTrans_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011C2 RID: 4546 RVA: 0x00040FB8 File Offset: 0x0003F1B8
			public global::RustProto.SavedObject.Builder MergeCarriableTrans(global::RustProto.objectICarriableTrans value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasCarriableTrans && this.result.carriableTrans_ != global::RustProto.objectICarriableTrans.DefaultInstance)
				{
					this.result.carriableTrans_ = global::RustProto.objectICarriableTrans.CreateBuilder(this.result.carriableTrans_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.carriableTrans_ = value;
				}
				this.result.hasCarriableTrans = true;
				return this;
			}

			// Token: 0x060011C3 RID: 4547 RVA: 0x00041040 File Offset: 0x0003F240
			public global::RustProto.SavedObject.Builder ClearCarriableTrans()
			{
				this.PrepareBuilder();
				this.result.hasCarriableTrans = false;
				this.result.carriableTrans_ = null;
				return this;
			}

			// Token: 0x1700048D RID: 1165
			// (get) Token: 0x060011C4 RID: 4548 RVA: 0x00041070 File Offset: 0x0003F270
			public bool HasTakeDamage
			{
				get
				{
					return this.result.hasTakeDamage;
				}
			}

			// Token: 0x1700048E RID: 1166
			// (get) Token: 0x060011C5 RID: 4549 RVA: 0x00041080 File Offset: 0x0003F280
			// (set) Token: 0x060011C6 RID: 4550 RVA: 0x00041090 File Offset: 0x0003F290
			public global::RustProto.objectTakeDamage TakeDamage
			{
				get
				{
					return this.result.TakeDamage;
				}
				set
				{
					this.SetTakeDamage(value);
				}
			}

			// Token: 0x060011C7 RID: 4551 RVA: 0x0004109C File Offset: 0x0003F29C
			public global::RustProto.SavedObject.Builder SetTakeDamage(global::RustProto.objectTakeDamage value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasTakeDamage = true;
				this.result.takeDamage_ = value;
				return this;
			}

			// Token: 0x060011C8 RID: 4552 RVA: 0x000410CC File Offset: 0x0003F2CC
			public global::RustProto.SavedObject.Builder SetTakeDamage(global::RustProto.objectTakeDamage.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasTakeDamage = true;
				this.result.takeDamage_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011C9 RID: 4553 RVA: 0x0004110C File Offset: 0x0003F30C
			public global::RustProto.SavedObject.Builder MergeTakeDamage(global::RustProto.objectTakeDamage value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasTakeDamage && this.result.takeDamage_ != global::RustProto.objectTakeDamage.DefaultInstance)
				{
					this.result.takeDamage_ = global::RustProto.objectTakeDamage.CreateBuilder(this.result.takeDamage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.takeDamage_ = value;
				}
				this.result.hasTakeDamage = true;
				return this;
			}

			// Token: 0x060011CA RID: 4554 RVA: 0x00041194 File Offset: 0x0003F394
			public global::RustProto.SavedObject.Builder ClearTakeDamage()
			{
				this.PrepareBuilder();
				this.result.hasTakeDamage = false;
				this.result.takeDamage_ = null;
				return this;
			}

			// Token: 0x1700048F RID: 1167
			// (get) Token: 0x060011CB RID: 4555 RVA: 0x000411C4 File Offset: 0x0003F3C4
			public bool HasSortOrder
			{
				get
				{
					return this.result.hasSortOrder;
				}
			}

			// Token: 0x17000490 RID: 1168
			// (get) Token: 0x060011CC RID: 4556 RVA: 0x000411D4 File Offset: 0x0003F3D4
			// (set) Token: 0x060011CD RID: 4557 RVA: 0x000411E4 File Offset: 0x0003F3E4
			public int SortOrder
			{
				get
				{
					return this.result.SortOrder;
				}
				set
				{
					this.SetSortOrder(value);
				}
			}

			// Token: 0x060011CE RID: 4558 RVA: 0x000411F0 File Offset: 0x0003F3F0
			public global::RustProto.SavedObject.Builder SetSortOrder(int value)
			{
				this.PrepareBuilder();
				this.result.hasSortOrder = true;
				this.result.sortOrder_ = value;
				return this;
			}

			// Token: 0x060011CF RID: 4559 RVA: 0x00041220 File Offset: 0x0003F420
			public global::RustProto.SavedObject.Builder ClearSortOrder()
			{
				this.PrepareBuilder();
				this.result.hasSortOrder = false;
				this.result.sortOrder_ = 0;
				return this;
			}

			// Token: 0x17000491 RID: 1169
			// (get) Token: 0x060011D0 RID: 4560 RVA: 0x00041250 File Offset: 0x0003F450
			public bool HasSleepingAvatar
			{
				get
				{
					return this.result.hasSleepingAvatar;
				}
			}

			// Token: 0x17000492 RID: 1170
			// (get) Token: 0x060011D1 RID: 4561 RVA: 0x00041260 File Offset: 0x0003F460
			// (set) Token: 0x060011D2 RID: 4562 RVA: 0x00041270 File Offset: 0x0003F470
			public global::RustProto.objectSleepingAvatar SleepingAvatar
			{
				get
				{
					return this.result.SleepingAvatar;
				}
				set
				{
					this.SetSleepingAvatar(value);
				}
			}

			// Token: 0x060011D3 RID: 4563 RVA: 0x0004127C File Offset: 0x0003F47C
			public global::RustProto.SavedObject.Builder SetSleepingAvatar(global::RustProto.objectSleepingAvatar value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasSleepingAvatar = true;
				this.result.sleepingAvatar_ = value;
				return this;
			}

			// Token: 0x060011D4 RID: 4564 RVA: 0x000412AC File Offset: 0x0003F4AC
			public global::RustProto.SavedObject.Builder SetSleepingAvatar(global::RustProto.objectSleepingAvatar.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasSleepingAvatar = true;
				this.result.sleepingAvatar_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011D5 RID: 4565 RVA: 0x000412EC File Offset: 0x0003F4EC
			public global::RustProto.SavedObject.Builder MergeSleepingAvatar(global::RustProto.objectSleepingAvatar value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasSleepingAvatar && this.result.sleepingAvatar_ != global::RustProto.objectSleepingAvatar.DefaultInstance)
				{
					this.result.sleepingAvatar_ = global::RustProto.objectSleepingAvatar.CreateBuilder(this.result.sleepingAvatar_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.sleepingAvatar_ = value;
				}
				this.result.hasSleepingAvatar = true;
				return this;
			}

			// Token: 0x060011D6 RID: 4566 RVA: 0x00041374 File Offset: 0x0003F574
			public global::RustProto.SavedObject.Builder ClearSleepingAvatar()
			{
				this.PrepareBuilder();
				this.result.hasSleepingAvatar = false;
				this.result.sleepingAvatar_ = null;
				return this;
			}

			// Token: 0x17000493 RID: 1171
			// (get) Token: 0x060011D7 RID: 4567 RVA: 0x000413A4 File Offset: 0x0003F5A4
			public bool HasLockable
			{
				get
				{
					return this.result.hasLockable;
				}
			}

			// Token: 0x17000494 RID: 1172
			// (get) Token: 0x060011D8 RID: 4568 RVA: 0x000413B4 File Offset: 0x0003F5B4
			// (set) Token: 0x060011D9 RID: 4569 RVA: 0x000413C4 File Offset: 0x0003F5C4
			public global::RustProto.objectLockable Lockable
			{
				get
				{
					return this.result.Lockable;
				}
				set
				{
					this.SetLockable(value);
				}
			}

			// Token: 0x060011DA RID: 4570 RVA: 0x000413D0 File Offset: 0x0003F5D0
			public global::RustProto.SavedObject.Builder SetLockable(global::RustProto.objectLockable value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasLockable = true;
				this.result.lockable_ = value;
				return this;
			}

			// Token: 0x060011DB RID: 4571 RVA: 0x00041400 File Offset: 0x0003F600
			public global::RustProto.SavedObject.Builder SetLockable(global::RustProto.objectLockable.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasLockable = true;
				this.result.lockable_ = builderForValue.Build();
				return this;
			}

			// Token: 0x060011DC RID: 4572 RVA: 0x00041440 File Offset: 0x0003F640
			public global::RustProto.SavedObject.Builder MergeLockable(global::RustProto.objectLockable value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasLockable && this.result.lockable_ != global::RustProto.objectLockable.DefaultInstance)
				{
					this.result.lockable_ = global::RustProto.objectLockable.CreateBuilder(this.result.lockable_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.lockable_ = value;
				}
				this.result.hasLockable = true;
				return this;
			}

			// Token: 0x060011DD RID: 4573 RVA: 0x000414C8 File Offset: 0x0003F6C8
			public global::RustProto.SavedObject.Builder ClearLockable()
			{
				this.PrepareBuilder();
				this.result.hasLockable = false;
				this.result.lockable_ = null;
				return this;
			}

			// Token: 0x04000A63 RID: 2659
			private bool resultIsReadOnly;

			// Token: 0x04000A64 RID: 2660
			private global::RustProto.SavedObject result;
		}
	}
}
