using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000259 RID: 601
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectStructComponent : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder>
	{
		// Token: 0x0600140B RID: 5131 RVA: 0x00045C0C File Offset: 0x00043E0C
		private objectStructComponent()
		{
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x00045C1C File Offset: 0x00043E1C
		static objectStructComponent()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x00045C80 File Offset: 0x00043E80
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder>.Manufacture();
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x0600140E RID: 5134 RVA: 0x00045C88 File Offset: 0x00043E88
		public static global::RustProto.objectStructComponent DefaultInstance
		{
			get
			{
				return global::RustProto.objectStructComponent.defaultInstance;
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x0600140F RID: 5135 RVA: 0x00045C90 File Offset: 0x00043E90
		public override global::RustProto.objectStructComponent DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectStructComponent.DefaultInstance;
			}
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001410 RID: 5136 RVA: 0x00045C98 File Offset: 0x00043E98
		protected override global::RustProto.objectStructComponent ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06001411 RID: 5137 RVA: 0x00045C9C File Offset: 0x00043E9C
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__Descriptor;
			}
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06001412 RID: 5138 RVA: 0x00045CA4 File Offset: 0x00043EA4
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__FieldAccessorTable;
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06001413 RID: 5139 RVA: 0x00045CAC File Offset: 0x00043EAC
		public bool HasID
		{
			get
			{
				return this.hasID;
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x00045CB4 File Offset: 0x00043EB4
		public int ID
		{
			get
			{
				return this.iD_;
			}
		}

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06001415 RID: 5141 RVA: 0x00045CBC File Offset: 0x00043EBC
		public bool HasMasterID
		{
			get
			{
				return this.hasMasterID;
			}
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x00045CC4 File Offset: 0x00043EC4
		public int MasterID
		{
			get
			{
				return this.masterID_;
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06001417 RID: 5143 RVA: 0x00045CCC File Offset: 0x00043ECC
		public bool HasMasterViewID
		{
			get
			{
				return this.hasMasterViewID;
			}
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x00045CD4 File Offset: 0x00043ED4
		public int MasterViewID
		{
			get
			{
				return this.masterViewID_;
			}
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06001419 RID: 5145 RVA: 0x00045CDC File Offset: 0x00043EDC
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x00045CE0 File Offset: 0x00043EE0
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectStructComponentFieldNames = global::RustProto.objectStructComponent._objectStructComponentFieldNames;
			if (this.hasID)
			{
				output.WriteInt32(1, objectStructComponentFieldNames[0], this.ID);
			}
			if (this.hasMasterID)
			{
				output.WriteInt32(2, objectStructComponentFieldNames[1], this.MasterID);
			}
			if (this.hasMasterViewID)
			{
				output.WriteInt32(3, objectStructComponentFieldNames[2], this.MasterViewID);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x0600141B RID: 5147 RVA: 0x00045D58 File Offset: 0x00043F58
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
				if (this.hasMasterID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(2, this.MasterID);
				}
				if (this.hasMasterViewID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(3, this.MasterViewID);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x00045DDC File Offset: 0x00043FDC
		public static global::RustProto.objectStructComponent ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x00045DF0 File Offset: 0x00043FF0
		public static global::RustProto.objectStructComponent ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x00045E04 File Offset: 0x00044004
		public static global::RustProto.objectStructComponent ParseFrom(byte[] data)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x00045E18 File Offset: 0x00044018
		public static global::RustProto.objectStructComponent ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x00045E2C File Offset: 0x0004402C
		public static global::RustProto.objectStructComponent ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x00045E40 File Offset: 0x00044040
		public static global::RustProto.objectStructComponent ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x00045E54 File Offset: 0x00044054
		public static global::RustProto.objectStructComponent ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x00045E68 File Offset: 0x00044068
		public static global::RustProto.objectStructComponent ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x00045E7C File Offset: 0x0004407C
		public static global::RustProto.objectStructComponent ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x00045E90 File Offset: 0x00044090
		public static global::RustProto.objectStructComponent ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectStructComponent.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x00045EA4 File Offset: 0x000440A4
		private global::RustProto.objectStructComponent MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x00045EA8 File Offset: 0x000440A8
		public static global::RustProto.objectStructComponent.Builder CreateBuilder()
		{
			return new global::RustProto.objectStructComponent.Builder();
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x00045EB0 File Offset: 0x000440B0
		public override global::RustProto.objectStructComponent.Builder ToBuilder()
		{
			return global::RustProto.objectStructComponent.CreateBuilder(this);
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x00045EB8 File Offset: 0x000440B8
		public override global::RustProto.objectStructComponent.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectStructComponent.Builder();
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x00045EC0 File Offset: 0x000440C0
		public static global::RustProto.objectStructComponent.Builder CreateBuilder(global::RustProto.objectStructComponent prototype)
		{
			return new global::RustProto.objectStructComponent.Builder(prototype);
		}

		// Token: 0x04000AE5 RID: 2789
		public const int IDFieldNumber = 1;

		// Token: 0x04000AE6 RID: 2790
		public const int MasterIDFieldNumber = 2;

		// Token: 0x04000AE7 RID: 2791
		public const int MasterViewIDFieldNumber = 3;

		// Token: 0x04000AE8 RID: 2792
		private static readonly global::RustProto.objectStructComponent defaultInstance = new global::RustProto.objectStructComponent().MakeReadOnly();

		// Token: 0x04000AE9 RID: 2793
		private static readonly string[] _objectStructComponentFieldNames = new string[]
		{
			"ID",
			"MasterID",
			"MasterViewID"
		};

		// Token: 0x04000AEA RID: 2794
		private static readonly uint[] _objectStructComponentFieldTags = new uint[]
		{
			8U,
			0x10U,
			0x18U
		};

		// Token: 0x04000AEB RID: 2795
		private bool hasID;

		// Token: 0x04000AEC RID: 2796
		private int iD_;

		// Token: 0x04000AED RID: 2797
		private bool hasMasterID;

		// Token: 0x04000AEE RID: 2798
		private int masterID_;

		// Token: 0x04000AEF RID: 2799
		private bool hasMasterViewID;

		// Token: 0x04000AF0 RID: 2800
		private int masterViewID_;

		// Token: 0x04000AF1 RID: 2801
		private int memoizedSerializedSize = -1;

		// Token: 0x0200025A RID: 602
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder>
		{
			// Token: 0x0600142B RID: 5163 RVA: 0x00045EC8 File Offset: 0x000440C8
			public Builder()
			{
				this.result = global::RustProto.objectStructComponent.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600142C RID: 5164 RVA: 0x00045EE4 File Offset: 0x000440E4
			internal Builder(global::RustProto.objectStructComponent cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000572 RID: 1394
			// (get) Token: 0x0600142D RID: 5165 RVA: 0x00045EFC File Offset: 0x000440FC
			protected override global::RustProto.objectStructComponent.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x0600142E RID: 5166 RVA: 0x00045F00 File Offset: 0x00044100
			private global::RustProto.objectStructComponent PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectStructComponent other = this.result;
					this.result = new global::RustProto.objectStructComponent();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000573 RID: 1395
			// (get) Token: 0x0600142F RID: 5167 RVA: 0x00045F40 File Offset: 0x00044140
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000574 RID: 1396
			// (get) Token: 0x06001430 RID: 5168 RVA: 0x00045F50 File Offset: 0x00044150
			protected override global::RustProto.objectStructComponent MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001431 RID: 5169 RVA: 0x00045F58 File Offset: 0x00044158
			public override global::RustProto.objectStructComponent.Builder Clear()
			{
				this.result = global::RustProto.objectStructComponent.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001432 RID: 5170 RVA: 0x00045F70 File Offset: 0x00044170
			public override global::RustProto.objectStructComponent.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectStructComponent.Builder(this.result);
				}
				return new global::RustProto.objectStructComponent.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000575 RID: 1397
			// (get) Token: 0x06001433 RID: 5171 RVA: 0x00045F9C File Offset: 0x0004419C
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectStructComponent.Descriptor;
				}
			}

			// Token: 0x17000576 RID: 1398
			// (get) Token: 0x06001434 RID: 5172 RVA: 0x00045FA4 File Offset: 0x000441A4
			public override global::RustProto.objectStructComponent DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectStructComponent.DefaultInstance;
				}
			}

			// Token: 0x06001435 RID: 5173 RVA: 0x00045FAC File Offset: 0x000441AC
			public override global::RustProto.objectStructComponent BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001436 RID: 5174 RVA: 0x00045FE0 File Offset: 0x000441E0
			public override global::RustProto.objectStructComponent.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectStructComponent)
				{
					return this.MergeFrom((global::RustProto.objectStructComponent)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001437 RID: 5175 RVA: 0x00046004 File Offset: 0x00044204
			public override global::RustProto.objectStructComponent.Builder MergeFrom(global::RustProto.objectStructComponent other)
			{
				if (other == global::RustProto.objectStructComponent.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasID)
				{
					this.ID = other.ID;
				}
				if (other.HasMasterID)
				{
					this.MasterID = other.MasterID;
				}
				if (other.HasMasterViewID)
				{
					this.MasterViewID = other.MasterViewID;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001438 RID: 5176 RVA: 0x00046078 File Offset: 0x00044278
			public override global::RustProto.objectStructComponent.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001439 RID: 5177 RVA: 0x00046088 File Offset: 0x00044288
			public override global::RustProto.objectStructComponent.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectStructComponent._objectStructComponentFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectStructComponent._objectStructComponentFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8U)
					{
						if (num3 != 0x10U)
						{
							if (num3 != 0x18U)
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
								this.result.hasMasterViewID = input.ReadInt32(ref this.result.masterViewID_);
							}
						}
						else
						{
							this.result.hasMasterID = input.ReadInt32(ref this.result.masterID_);
						}
					}
					else
					{
						this.result.hasID = input.ReadInt32(ref this.result.iD_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x17000577 RID: 1399
			// (get) Token: 0x0600143A RID: 5178 RVA: 0x000461F0 File Offset: 0x000443F0
			public bool HasID
			{
				get
				{
					return this.result.hasID;
				}
			}

			// Token: 0x17000578 RID: 1400
			// (get) Token: 0x0600143B RID: 5179 RVA: 0x00046200 File Offset: 0x00044400
			// (set) Token: 0x0600143C RID: 5180 RVA: 0x00046210 File Offset: 0x00044410
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

			// Token: 0x0600143D RID: 5181 RVA: 0x0004621C File Offset: 0x0004441C
			public global::RustProto.objectStructComponent.Builder SetID(int value)
			{
				this.PrepareBuilder();
				this.result.hasID = true;
				this.result.iD_ = value;
				return this;
			}

			// Token: 0x0600143E RID: 5182 RVA: 0x0004624C File Offset: 0x0004444C
			public global::RustProto.objectStructComponent.Builder ClearID()
			{
				this.PrepareBuilder();
				this.result.hasID = false;
				this.result.iD_ = 0;
				return this;
			}

			// Token: 0x17000579 RID: 1401
			// (get) Token: 0x0600143F RID: 5183 RVA: 0x0004627C File Offset: 0x0004447C
			public bool HasMasterID
			{
				get
				{
					return this.result.hasMasterID;
				}
			}

			// Token: 0x1700057A RID: 1402
			// (get) Token: 0x06001440 RID: 5184 RVA: 0x0004628C File Offset: 0x0004448C
			// (set) Token: 0x06001441 RID: 5185 RVA: 0x0004629C File Offset: 0x0004449C
			public int MasterID
			{
				get
				{
					return this.result.MasterID;
				}
				set
				{
					this.SetMasterID(value);
				}
			}

			// Token: 0x06001442 RID: 5186 RVA: 0x000462A8 File Offset: 0x000444A8
			public global::RustProto.objectStructComponent.Builder SetMasterID(int value)
			{
				this.PrepareBuilder();
				this.result.hasMasterID = true;
				this.result.masterID_ = value;
				return this;
			}

			// Token: 0x06001443 RID: 5187 RVA: 0x000462D8 File Offset: 0x000444D8
			public global::RustProto.objectStructComponent.Builder ClearMasterID()
			{
				this.PrepareBuilder();
				this.result.hasMasterID = false;
				this.result.masterID_ = 0;
				return this;
			}

			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x06001444 RID: 5188 RVA: 0x00046308 File Offset: 0x00044508
			public bool HasMasterViewID
			{
				get
				{
					return this.result.hasMasterViewID;
				}
			}

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x06001445 RID: 5189 RVA: 0x00046318 File Offset: 0x00044518
			// (set) Token: 0x06001446 RID: 5190 RVA: 0x00046328 File Offset: 0x00044528
			public int MasterViewID
			{
				get
				{
					return this.result.MasterViewID;
				}
				set
				{
					this.SetMasterViewID(value);
				}
			}

			// Token: 0x06001447 RID: 5191 RVA: 0x00046334 File Offset: 0x00044534
			public global::RustProto.objectStructComponent.Builder SetMasterViewID(int value)
			{
				this.PrepareBuilder();
				this.result.hasMasterViewID = true;
				this.result.masterViewID_ = value;
				return this;
			}

			// Token: 0x06001448 RID: 5192 RVA: 0x00046364 File Offset: 0x00044564
			public global::RustProto.objectStructComponent.Builder ClearMasterViewID()
			{
				this.PrepareBuilder();
				this.result.hasMasterViewID = false;
				this.result.masterViewID_ = 0;
				return this;
			}

			// Token: 0x04000AF2 RID: 2802
			private bool resultIsReadOnly;

			// Token: 0x04000AF3 RID: 2803
			private global::RustProto.objectStructComponent result;
		}
	}
}
