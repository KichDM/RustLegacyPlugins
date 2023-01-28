using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x0200025B RID: 603
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectStructMaster : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder>
	{
		// Token: 0x06001449 RID: 5193 RVA: 0x00046394 File Offset: 0x00044594
		private objectStructMaster()
		{
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x000463A4 File Offset: 0x000445A4
		static objectStructMaster()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x00046410 File Offset: 0x00044610
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder>.Manufacture();
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x00046418 File Offset: 0x00044618
		public static global::RustProto.objectStructMaster DefaultInstance
		{
			get
			{
				return global::RustProto.objectStructMaster.defaultInstance;
			}
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x0600144D RID: 5197 RVA: 0x00046420 File Offset: 0x00044620
		public override global::RustProto.objectStructMaster DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectStructMaster.DefaultInstance;
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x0600144E RID: 5198 RVA: 0x00046428 File Offset: 0x00044628
		protected override global::RustProto.objectStructMaster ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x0004642C File Offset: 0x0004462C
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__Descriptor;
			}
		}

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06001450 RID: 5200 RVA: 0x00046434 File Offset: 0x00044634
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__FieldAccessorTable;
			}
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06001451 RID: 5201 RVA: 0x0004643C File Offset: 0x0004463C
		public bool HasID
		{
			get
			{
				return this.hasID;
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06001452 RID: 5202 RVA: 0x00046444 File Offset: 0x00044644
		public int ID
		{
			get
			{
				return this.iD_;
			}
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06001453 RID: 5203 RVA: 0x0004644C File Offset: 0x0004464C
		public bool HasDecayDelay
		{
			get
			{
				return this.hasDecayDelay;
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x00046454 File Offset: 0x00044654
		public float DecayDelay
		{
			get
			{
				return this.decayDelay_;
			}
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x0004645C File Offset: 0x0004465C
		public bool HasCreatorID
		{
			get
			{
				return this.hasCreatorID;
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x00046464 File Offset: 0x00044664
		[global::System.CLSCompliant(false)]
		public ulong CreatorID
		{
			get
			{
				return this.creatorID_;
			}
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x0004646C File Offset: 0x0004466C
		public bool HasOwnerID
		{
			get
			{
				return this.hasOwnerID;
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x00046474 File Offset: 0x00044674
		[global::System.CLSCompliant(false)]
		public ulong OwnerID
		{
			get
			{
				return this.ownerID_;
			}
		}

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x0004647C File Offset: 0x0004467C
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x00046480 File Offset: 0x00044680
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectStructMasterFieldNames = global::RustProto.objectStructMaster._objectStructMasterFieldNames;
			if (this.hasID)
			{
				output.WriteInt32(1, objectStructMasterFieldNames[2], this.ID);
			}
			if (this.hasDecayDelay)
			{
				output.WriteFloat(2, objectStructMasterFieldNames[1], this.DecayDelay);
			}
			if (this.hasCreatorID)
			{
				output.WriteUInt64(3, objectStructMasterFieldNames[0], this.CreatorID);
			}
			if (this.hasOwnerID)
			{
				output.WriteUInt64(4, objectStructMasterFieldNames[3], this.OwnerID);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x00046514 File Offset: 0x00044714
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
				if (this.hasID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(1, this.ID);
				}
				if (this.hasDecayDelay)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(2, this.DecayDelay);
				}
				if (this.hasCreatorID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64Size(3, this.CreatorID);
				}
				if (this.hasOwnerID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64Size(4, this.OwnerID);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x000465B4 File Offset: 0x000447B4
		public static global::RustProto.objectStructMaster ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x000465C8 File Offset: 0x000447C8
		public static global::RustProto.objectStructMaster ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x000465DC File Offset: 0x000447DC
		public static global::RustProto.objectStructMaster ParseFrom(byte[] data)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x000465F0 File Offset: 0x000447F0
		public static global::RustProto.objectStructMaster ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x00046604 File Offset: 0x00044804
		public static global::RustProto.objectStructMaster ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x00046618 File Offset: 0x00044818
		public static global::RustProto.objectStructMaster ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x0004662C File Offset: 0x0004482C
		public static global::RustProto.objectStructMaster ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x00046640 File Offset: 0x00044840
		public static global::RustProto.objectStructMaster ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x00046654 File Offset: 0x00044854
		public static global::RustProto.objectStructMaster ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x00046668 File Offset: 0x00044868
		public static global::RustProto.objectStructMaster ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructMaster.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0004667C File Offset: 0x0004487C
		private global::RustProto.objectStructMaster MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x00046680 File Offset: 0x00044880
		public static global::RustProto.objectStructMaster.Builder CreateBuilder()
		{
			return new global::RustProto.objectStructMaster.Builder();
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x00046688 File Offset: 0x00044888
		public override global::RustProto.objectStructMaster.Builder ToBuilder()
		{
			return global::RustProto.objectStructMaster.CreateBuilder(this);
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x00046690 File Offset: 0x00044890
		public override global::RustProto.objectStructMaster.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectStructMaster.Builder();
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x00046698 File Offset: 0x00044898
		public static global::RustProto.objectStructMaster.Builder CreateBuilder(global::RustProto.objectStructMaster prototype)
		{
			return new global::RustProto.objectStructMaster.Builder(prototype);
		}

		// Token: 0x04000AF4 RID: 2804
		public const int IDFieldNumber = 1;

		// Token: 0x04000AF5 RID: 2805
		public const int DecayDelayFieldNumber = 2;

		// Token: 0x04000AF6 RID: 2806
		public const int CreatorIDFieldNumber = 3;

		// Token: 0x04000AF7 RID: 2807
		public const int OwnerIDFieldNumber = 4;

		// Token: 0x04000AF8 RID: 2808
		private static readonly global::RustProto.objectStructMaster defaultInstance = new global::RustProto.objectStructMaster().MakeReadOnly();

		// Token: 0x04000AF9 RID: 2809
		private static readonly string[] _objectStructMasterFieldNames = new string[]
		{
			"CreatorID",
			"DecayDelay",
			"ID",
			"OwnerID"
		};

		// Token: 0x04000AFA RID: 2810
		private static readonly uint[] _objectStructMasterFieldTags = new uint[]
		{
			0x18U,
			0x15U,
			8U,
			0x20U
		};

		// Token: 0x04000AFB RID: 2811
		private bool hasID;

		// Token: 0x04000AFC RID: 2812
		private int iD_;

		// Token: 0x04000AFD RID: 2813
		private bool hasDecayDelay;

		// Token: 0x04000AFE RID: 2814
		private float decayDelay_;

		// Token: 0x04000AFF RID: 2815
		private bool hasCreatorID;

		// Token: 0x04000B00 RID: 2816
		private ulong creatorID_;

		// Token: 0x04000B01 RID: 2817
		private bool hasOwnerID;

		// Token: 0x04000B02 RID: 2818
		private ulong ownerID_;

		// Token: 0x04000B03 RID: 2819
		private int memoizedSerializedSize = -1;

		// Token: 0x0200025C RID: 604
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder>
		{
			// Token: 0x0600146B RID: 5227 RVA: 0x000466A0 File Offset: 0x000448A0
			public Builder()
			{
				this.result = global::RustProto.objectStructMaster.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600146C RID: 5228 RVA: 0x000466BC File Offset: 0x000448BC
			internal Builder(global::RustProto.objectStructMaster cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x0600146D RID: 5229 RVA: 0x000466D4 File Offset: 0x000448D4
			protected override global::RustProto.objectStructMaster.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x0600146E RID: 5230 RVA: 0x000466D8 File Offset: 0x000448D8
			private global::RustProto.objectStructMaster PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectStructMaster other = this.result;
					this.result = new global::RustProto.objectStructMaster();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x0600146F RID: 5231 RVA: 0x00046718 File Offset: 0x00044918
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06001470 RID: 5232 RVA: 0x00046728 File Offset: 0x00044928
			protected override global::RustProto.objectStructMaster MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001471 RID: 5233 RVA: 0x00046730 File Offset: 0x00044930
			public override global::RustProto.objectStructMaster.Builder Clear()
			{
				this.result = global::RustProto.objectStructMaster.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001472 RID: 5234 RVA: 0x00046748 File Offset: 0x00044948
			public override global::RustProto.objectStructMaster.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectStructMaster.Builder(this.result);
				}
				return new global::RustProto.objectStructMaster.Builder().MergeFrom(this.result);
			}

			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06001473 RID: 5235 RVA: 0x00046774 File Offset: 0x00044974
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectStructMaster.Descriptor;
				}
			}

			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06001474 RID: 5236 RVA: 0x0004677C File Offset: 0x0004497C
			public override global::RustProto.objectStructMaster DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectStructMaster.DefaultInstance;
				}
			}

			// Token: 0x06001475 RID: 5237 RVA: 0x00046784 File Offset: 0x00044984
			public override global::RustProto.objectStructMaster BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001476 RID: 5238 RVA: 0x000467B8 File Offset: 0x000449B8
			public override global::RustProto.objectStructMaster.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectStructMaster)
				{
					return this.MergeFrom((global::RustProto.objectStructMaster)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001477 RID: 5239 RVA: 0x000467DC File Offset: 0x000449DC
			public override global::RustProto.objectStructMaster.Builder MergeFrom(global::RustProto.objectStructMaster other)
			{
				if (other == global::RustProto.objectStructMaster.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasID)
				{
					this.ID = other.ID;
				}
				if (other.HasDecayDelay)
				{
					this.DecayDelay = other.DecayDelay;
				}
				if (other.HasCreatorID)
				{
					this.CreatorID = other.CreatorID;
				}
				if (other.HasOwnerID)
				{
					this.OwnerID = other.OwnerID;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001478 RID: 5240 RVA: 0x00046868 File Offset: 0x00044A68
			public override global::RustProto.objectStructMaster.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001479 RID: 5241 RVA: 0x00046878 File Offset: 0x00044A78
			public override global::RustProto.objectStructMaster.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectStructMaster._objectStructMasterFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectStructMaster._objectStructMasterFieldTags[num2];
					}
					uint num3 = num;
					switch (num3)
					{
					case 0x15U:
						this.result.hasDecayDelay = input.ReadFloat(ref this.result.decayDelay_);
						break;
					default:
						if (num3 == 0U)
						{
							throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
						}
						if (num3 != 8U)
						{
							if (num3 != 0x20U)
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
								this.result.hasOwnerID = input.ReadUInt64(ref this.result.ownerID_);
							}
						}
						else
						{
							this.result.hasID = input.ReadInt32(ref this.result.iD_);
						}
						break;
					case 0x18U:
						this.result.hasCreatorID = input.ReadUInt64(ref this.result.creatorID_);
						break;
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x0600147A RID: 5242 RVA: 0x00046A10 File Offset: 0x00044C10
			public bool HasID
			{
				get
				{
					return this.result.hasID;
				}
			}

			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x0600147B RID: 5243 RVA: 0x00046A20 File Offset: 0x00044C20
			// (set) Token: 0x0600147C RID: 5244 RVA: 0x00046A30 File Offset: 0x00044C30
			public int ID
			{
				get
				{
					return this.result.ID;
				}
				set
				{
					this.SetID(value);
				}
			}

			// Token: 0x0600147D RID: 5245 RVA: 0x00046A3C File Offset: 0x00044C3C
			public global::RustProto.objectStructMaster.Builder SetID(int value)
			{
				this.PrepareBuilder();
				this.result.hasID = true;
				this.result.iD_ = value;
				return this;
			}

			// Token: 0x0600147E RID: 5246 RVA: 0x00046A6C File Offset: 0x00044C6C
			public global::RustProto.objectStructMaster.Builder ClearID()
			{
				this.PrepareBuilder();
				this.result.hasID = false;
				this.result.iD_ = 0;
				return this;
			}

			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x0600147F RID: 5247 RVA: 0x00046A9C File Offset: 0x00044C9C
			public bool HasDecayDelay
			{
				get
				{
					return this.result.hasDecayDelay;
				}
			}

			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06001480 RID: 5248 RVA: 0x00046AAC File Offset: 0x00044CAC
			// (set) Token: 0x06001481 RID: 5249 RVA: 0x00046ABC File Offset: 0x00044CBC
			public float DecayDelay
			{
				get
				{
					return this.result.DecayDelay;
				}
				set
				{
					this.SetDecayDelay(value);
				}
			}

			// Token: 0x06001482 RID: 5250 RVA: 0x00046AC8 File Offset: 0x00044CC8
			public global::RustProto.objectStructMaster.Builder SetDecayDelay(float value)
			{
				this.PrepareBuilder();
				this.result.hasDecayDelay = true;
				this.result.decayDelay_ = value;
				return this;
			}

			// Token: 0x06001483 RID: 5251 RVA: 0x00046AF8 File Offset: 0x00044CF8
			public global::RustProto.objectStructMaster.Builder ClearDecayDelay()
			{
				this.PrepareBuilder();
				this.result.hasDecayDelay = false;
				this.result.decayDelay_ = 0f;
				return this;
			}

			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06001484 RID: 5252 RVA: 0x00046B2C File Offset: 0x00044D2C
			public bool HasCreatorID
			{
				get
				{
					return this.result.hasCreatorID;
				}
			}

			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06001485 RID: 5253 RVA: 0x00046B3C File Offset: 0x00044D3C
			// (set) Token: 0x06001486 RID: 5254 RVA: 0x00046B4C File Offset: 0x00044D4C
			[global::System.CLSCompliant(false)]
			public ulong CreatorID
			{
				get
				{
					return this.result.CreatorID;
				}
				set
				{
					this.SetCreatorID(value);
				}
			}

			// Token: 0x06001487 RID: 5255 RVA: 0x00046B58 File Offset: 0x00044D58
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectStructMaster.Builder SetCreatorID(ulong value)
			{
				this.PrepareBuilder();
				this.result.hasCreatorID = true;
				this.result.creatorID_ = value;
				return this;
			}

			// Token: 0x06001488 RID: 5256 RVA: 0x00046B88 File Offset: 0x00044D88
			public global::RustProto.objectStructMaster.Builder ClearCreatorID()
			{
				this.PrepareBuilder();
				this.result.hasCreatorID = false;
				this.result.creatorID_ = 0UL;
				return this;
			}

			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06001489 RID: 5257 RVA: 0x00046BAC File Offset: 0x00044DAC
			public bool HasOwnerID
			{
				get
				{
					return this.result.hasOwnerID;
				}
			}

			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600148A RID: 5258 RVA: 0x00046BBC File Offset: 0x00044DBC
			// (set) Token: 0x0600148B RID: 5259 RVA: 0x00046BCC File Offset: 0x00044DCC
			[global::System.CLSCompliant(false)]
			public ulong OwnerID
			{
				get
				{
					return this.result.OwnerID;
				}
				set
				{
					this.SetOwnerID(value);
				}
			}

			// Token: 0x0600148C RID: 5260 RVA: 0x00046BD8 File Offset: 0x00044DD8
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectStructMaster.Builder SetOwnerID(ulong value)
			{
				this.PrepareBuilder();
				this.result.hasOwnerID = true;
				this.result.ownerID_ = value;
				return this;
			}

			// Token: 0x0600148D RID: 5261 RVA: 0x00046C08 File Offset: 0x00044E08
			public global::RustProto.objectStructMaster.Builder ClearOwnerID()
			{
				this.PrepareBuilder();
				this.result.hasOwnerID = false;
				this.result.ownerID_ = 0UL;
				return this;
			}

			// Token: 0x04000B04 RID: 2820
			private bool resultIsReadOnly;

			// Token: 0x04000B05 RID: 2821
			private global::RustProto.objectStructMaster result;
		}
	}
}
