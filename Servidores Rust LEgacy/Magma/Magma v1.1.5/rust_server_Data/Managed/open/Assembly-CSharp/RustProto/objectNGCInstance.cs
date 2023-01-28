using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x0200024B RID: 587
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectNGCInstance : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder>
	{
		// Token: 0x06001270 RID: 4720 RVA: 0x00042A14 File Offset: 0x00040C14
		private objectNGCInstance()
		{
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x00042A30 File Offset: 0x00040C30
		static objectNGCInstance()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00042A88 File Offset: 0x00040C88
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder>.Manufacture();
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06001273 RID: 4723 RVA: 0x00042A90 File Offset: 0x00040C90
		public static global::RustProto.objectNGCInstance DefaultInstance
		{
			get
			{
				return global::RustProto.objectNGCInstance.defaultInstance;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06001274 RID: 4724 RVA: 0x00042A98 File Offset: 0x00040C98
		public override global::RustProto.objectNGCInstance DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectNGCInstance.DefaultInstance;
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06001275 RID: 4725 RVA: 0x00042AA0 File Offset: 0x00040CA0
		protected override global::RustProto.objectNGCInstance ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06001276 RID: 4726 RVA: 0x00042AA4 File Offset: 0x00040CA4
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__Descriptor;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06001277 RID: 4727 RVA: 0x00042AAC File Offset: 0x00040CAC
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__FieldAccessorTable;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001278 RID: 4728 RVA: 0x00042AB4 File Offset: 0x00040CB4
		public bool HasID
		{
			get
			{
				return this.hasID;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001279 RID: 4729 RVA: 0x00042ABC File Offset: 0x00040CBC
		public int ID
		{
			get
			{
				return this.iD_;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x0600127A RID: 4730 RVA: 0x00042AC4 File Offset: 0x00040CC4
		public bool HasData
		{
			get
			{
				return this.hasData;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600127B RID: 4731 RVA: 0x00042ACC File Offset: 0x00040CCC
		public global::Google.ProtocolBuffers.ByteString Data
		{
			get
			{
				return this.data_;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600127C RID: 4732 RVA: 0x00042AD4 File Offset: 0x00040CD4
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00042AD8 File Offset: 0x00040CD8
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectNGCInstanceFieldNames = global::RustProto.objectNGCInstance._objectNGCInstanceFieldNames;
			if (this.hasID)
			{
				output.WriteInt32(1, objectNGCInstanceFieldNames[0], this.ID);
			}
			if (this.hasData)
			{
				output.WriteBytes(2, objectNGCInstanceFieldNames[1], this.Data);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600127E RID: 4734 RVA: 0x00042B34 File Offset: 0x00040D34
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
				if (this.hasData)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeBytesSize(2, this.Data);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x00042BA0 File Offset: 0x00040DA0
		public static global::RustProto.objectNGCInstance ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x00042BB4 File Offset: 0x00040DB4
		public static global::RustProto.objectNGCInstance ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x00042BC8 File Offset: 0x00040DC8
		public static global::RustProto.objectNGCInstance ParseFrom(byte[] data)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x00042BDC File Offset: 0x00040DDC
		public static global::RustProto.objectNGCInstance ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x00042BF0 File Offset: 0x00040DF0
		public static global::RustProto.objectNGCInstance ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x00042C04 File Offset: 0x00040E04
		public static global::RustProto.objectNGCInstance ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x00042C18 File Offset: 0x00040E18
		public static global::RustProto.objectNGCInstance ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x00042C2C File Offset: 0x00040E2C
		public static global::RustProto.objectNGCInstance ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x00042C40 File Offset: 0x00040E40
		public static global::RustProto.objectNGCInstance ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x00042C54 File Offset: 0x00040E54
		public static global::RustProto.objectNGCInstance ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNGCInstance.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x00042C68 File Offset: 0x00040E68
		private global::RustProto.objectNGCInstance MakeReadOnly()
		{
			return this;
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x00042C6C File Offset: 0x00040E6C
		public static global::RustProto.objectNGCInstance.Builder CreateBuilder()
		{
			return new global::RustProto.objectNGCInstance.Builder();
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x00042C74 File Offset: 0x00040E74
		public override global::RustProto.objectNGCInstance.Builder ToBuilder()
		{
			return global::RustProto.objectNGCInstance.CreateBuilder(this);
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x00042C7C File Offset: 0x00040E7C
		public override global::RustProto.objectNGCInstance.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectNGCInstance.Builder();
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x00042C84 File Offset: 0x00040E84
		public static global::RustProto.objectNGCInstance.Builder CreateBuilder(global::RustProto.objectNGCInstance prototype)
		{
			return new global::RustProto.objectNGCInstance.Builder(prototype);
		}

		// Token: 0x04000A89 RID: 2697
		public const int IDFieldNumber = 1;

		// Token: 0x04000A8A RID: 2698
		public const int DataFieldNumber = 2;

		// Token: 0x04000A8B RID: 2699
		private static readonly global::RustProto.objectNGCInstance defaultInstance = new global::RustProto.objectNGCInstance().MakeReadOnly();

		// Token: 0x04000A8C RID: 2700
		private static readonly string[] _objectNGCInstanceFieldNames = new string[]
		{
			"ID",
			"data"
		};

		// Token: 0x04000A8D RID: 2701
		private static readonly uint[] _objectNGCInstanceFieldTags = new uint[]
		{
			8U,
			0x12U
		};

		// Token: 0x04000A8E RID: 2702
		private bool hasID;

		// Token: 0x04000A8F RID: 2703
		private int iD_;

		// Token: 0x04000A90 RID: 2704
		private bool hasData;

		// Token: 0x04000A91 RID: 2705
		private global::Google.ProtocolBuffers.ByteString data_ = global::Google.ProtocolBuffers.ByteString.Empty;

		// Token: 0x04000A92 RID: 2706
		private int memoizedSerializedSize = -1;

		// Token: 0x0200024C RID: 588
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder>
		{
			// Token: 0x0600128E RID: 4750 RVA: 0x00042C8C File Offset: 0x00040E8C
			public Builder()
			{
				this.result = global::RustProto.objectNGCInstance.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600128F RID: 4751 RVA: 0x00042CA8 File Offset: 0x00040EA8
			internal Builder(global::RustProto.objectNGCInstance cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170004D8 RID: 1240
			// (get) Token: 0x06001290 RID: 4752 RVA: 0x00042CC0 File Offset: 0x00040EC0
			protected override global::RustProto.objectNGCInstance.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001291 RID: 4753 RVA: 0x00042CC4 File Offset: 0x00040EC4
			private global::RustProto.objectNGCInstance PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectNGCInstance other = this.result;
					this.result = new global::RustProto.objectNGCInstance();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170004D9 RID: 1241
			// (get) Token: 0x06001292 RID: 4754 RVA: 0x00042D04 File Offset: 0x00040F04
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170004DA RID: 1242
			// (get) Token: 0x06001293 RID: 4755 RVA: 0x00042D14 File Offset: 0x00040F14
			protected override global::RustProto.objectNGCInstance MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001294 RID: 4756 RVA: 0x00042D1C File Offset: 0x00040F1C
			public override global::RustProto.objectNGCInstance.Builder Clear()
			{
				this.result = global::RustProto.objectNGCInstance.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001295 RID: 4757 RVA: 0x00042D34 File Offset: 0x00040F34
			public override global::RustProto.objectNGCInstance.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectNGCInstance.Builder(this.result);
				}
				return new global::RustProto.objectNGCInstance.Builder().MergeFrom(this.result);
			}

			// Token: 0x170004DB RID: 1243
			// (get) Token: 0x06001296 RID: 4758 RVA: 0x00042D60 File Offset: 0x00040F60
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectNGCInstance.Descriptor;
				}
			}

			// Token: 0x170004DC RID: 1244
			// (get) Token: 0x06001297 RID: 4759 RVA: 0x00042D68 File Offset: 0x00040F68
			public override global::RustProto.objectNGCInstance DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectNGCInstance.DefaultInstance;
				}
			}

			// Token: 0x06001298 RID: 4760 RVA: 0x00042D70 File Offset: 0x00040F70
			public override global::RustProto.objectNGCInstance BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001299 RID: 4761 RVA: 0x00042DA4 File Offset: 0x00040FA4
			public override global::RustProto.objectNGCInstance.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectNGCInstance)
				{
					return this.MergeFrom((global::RustProto.objectNGCInstance)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x0600129A RID: 4762 RVA: 0x00042DC8 File Offset: 0x00040FC8
			public override global::RustProto.objectNGCInstance.Builder MergeFrom(global::RustProto.objectNGCInstance other)
			{
				if (other == global::RustProto.objectNGCInstance.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasID)
				{
					this.ID = other.ID;
				}
				if (other.HasData)
				{
					this.Data = other.Data;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600129B RID: 4763 RVA: 0x00042E28 File Offset: 0x00041028
			public override global::RustProto.objectNGCInstance.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x0600129C RID: 4764 RVA: 0x00042E38 File Offset: 0x00041038
			public override global::RustProto.objectNGCInstance.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectNGCInstance._objectNGCInstanceFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectNGCInstance._objectNGCInstanceFieldTags[num2];
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
							this.result.hasData = input.ReadBytes(ref this.result.data_);
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

			// Token: 0x170004DD RID: 1245
			// (get) Token: 0x0600129D RID: 4765 RVA: 0x00042F74 File Offset: 0x00041174
			public bool HasID
			{
				get
				{
					return this.result.hasID;
				}
			}

			// Token: 0x170004DE RID: 1246
			// (get) Token: 0x0600129E RID: 4766 RVA: 0x00042F84 File Offset: 0x00041184
			// (set) Token: 0x0600129F RID: 4767 RVA: 0x00042F94 File Offset: 0x00041194
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

			// Token: 0x060012A0 RID: 4768 RVA: 0x00042FA0 File Offset: 0x000411A0
			public global::RustProto.objectNGCInstance.Builder SetID(int value)
			{
				this.PrepareBuilder();
				this.result.hasID = true;
				this.result.iD_ = value;
				return this;
			}

			// Token: 0x060012A1 RID: 4769 RVA: 0x00042FD0 File Offset: 0x000411D0
			public global::RustProto.objectNGCInstance.Builder ClearID()
			{
				this.PrepareBuilder();
				this.result.hasID = false;
				this.result.iD_ = 0;
				return this;
			}

			// Token: 0x170004DF RID: 1247
			// (get) Token: 0x060012A2 RID: 4770 RVA: 0x00043000 File Offset: 0x00041200
			public bool HasData
			{
				get
				{
					return this.result.hasData;
				}
			}

			// Token: 0x170004E0 RID: 1248
			// (get) Token: 0x060012A3 RID: 4771 RVA: 0x00043010 File Offset: 0x00041210
			// (set) Token: 0x060012A4 RID: 4772 RVA: 0x00043020 File Offset: 0x00041220
			public global::Google.ProtocolBuffers.ByteString Data
			{
				get
				{
					return this.result.Data;
				}
				set
				{
					this.SetData(value);
				}
			}

			// Token: 0x060012A5 RID: 4773 RVA: 0x0004302C File Offset: 0x0004122C
			public global::RustProto.objectNGCInstance.Builder SetData(global::Google.ProtocolBuffers.ByteString value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasData = true;
				this.result.data_ = value;
				return this;
			}

			// Token: 0x060012A6 RID: 4774 RVA: 0x0004305C File Offset: 0x0004125C
			public global::RustProto.objectNGCInstance.Builder ClearData()
			{
				this.PrepareBuilder();
				this.result.hasData = false;
				this.result.data_ = global::Google.ProtocolBuffers.ByteString.Empty;
				return this;
			}

			// Token: 0x04000A93 RID: 2707
			private bool resultIsReadOnly;

			// Token: 0x04000A94 RID: 2708
			private global::RustProto.objectNGCInstance result;
		}
	}
}
