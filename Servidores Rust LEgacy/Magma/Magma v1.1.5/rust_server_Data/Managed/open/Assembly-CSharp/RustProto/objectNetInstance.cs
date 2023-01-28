using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000249 RID: 585
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectNetInstance : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder>
	{
		// Token: 0x0600122B RID: 4651 RVA: 0x00042170 File Offset: 0x00040370
		private objectNetInstance()
		{
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x00042180 File Offset: 0x00040380
		static objectNetInstance()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x000421EC File Offset: 0x000403EC
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder>.Manufacture();
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x0600122E RID: 4654 RVA: 0x000421F4 File Offset: 0x000403F4
		public static global::RustProto.objectNetInstance DefaultInstance
		{
			get
			{
				return global::RustProto.objectNetInstance.defaultInstance;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x000421FC File Offset: 0x000403FC
		public override global::RustProto.objectNetInstance DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectNetInstance.DefaultInstance;
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06001230 RID: 4656 RVA: 0x00042204 File Offset: 0x00040404
		protected override global::RustProto.objectNetInstance ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x00042208 File Offset: 0x00040408
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__Descriptor;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06001232 RID: 4658 RVA: 0x00042210 File Offset: 0x00040410
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__FieldAccessorTable;
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x00042218 File Offset: 0x00040418
		public bool HasServerPrefab
		{
			get
			{
				return this.hasServerPrefab;
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06001234 RID: 4660 RVA: 0x00042220 File Offset: 0x00040420
		public int ServerPrefab
		{
			get
			{
				return this.serverPrefab_;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00042228 File Offset: 0x00040428
		public bool HasOwnerPrefab
		{
			get
			{
				return this.hasOwnerPrefab;
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06001236 RID: 4662 RVA: 0x00042230 File Offset: 0x00040430
		public int OwnerPrefab
		{
			get
			{
				return this.ownerPrefab_;
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x00042238 File Offset: 0x00040438
		public bool HasProxyPrefab
		{
			get
			{
				return this.hasProxyPrefab;
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06001238 RID: 4664 RVA: 0x00042240 File Offset: 0x00040440
		public int ProxyPrefab
		{
			get
			{
				return this.proxyPrefab_;
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x00042248 File Offset: 0x00040448
		public bool HasGroupID
		{
			get
			{
				return this.hasGroupID;
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x0600123A RID: 4666 RVA: 0x00042250 File Offset: 0x00040450
		public int GroupID
		{
			get
			{
				return this.groupID_;
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x00042258 File Offset: 0x00040458
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x0004225C File Offset: 0x0004045C
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectNetInstanceFieldNames = global::RustProto.objectNetInstance._objectNetInstanceFieldNames;
			if (this.hasServerPrefab)
			{
				output.WriteInt32(1, objectNetInstanceFieldNames[3], this.ServerPrefab);
			}
			if (this.hasOwnerPrefab)
			{
				output.WriteInt32(2, objectNetInstanceFieldNames[1], this.OwnerPrefab);
			}
			if (this.hasProxyPrefab)
			{
				output.WriteInt32(3, objectNetInstanceFieldNames[2], this.ProxyPrefab);
			}
			if (this.hasGroupID)
			{
				output.WriteInt32(4, objectNetInstanceFieldNames[0], this.GroupID);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x0600123D RID: 4669 RVA: 0x000422F0 File Offset: 0x000404F0
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
				if (this.hasServerPrefab)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(1, this.ServerPrefab);
				}
				if (this.hasOwnerPrefab)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(2, this.OwnerPrefab);
				}
				if (this.hasProxyPrefab)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(3, this.ProxyPrefab);
				}
				if (this.hasGroupID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(4, this.GroupID);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00042390 File Offset: 0x00040590
		public static global::RustProto.objectNetInstance ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x000423A4 File Offset: 0x000405A4
		public static global::RustProto.objectNetInstance ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x000423B8 File Offset: 0x000405B8
		public static global::RustProto.objectNetInstance ParseFrom(byte[] data)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x000423CC File Offset: 0x000405CC
		public static global::RustProto.objectNetInstance ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x000423E0 File Offset: 0x000405E0
		public static global::RustProto.objectNetInstance ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x000423F4 File Offset: 0x000405F4
		public static global::RustProto.objectNetInstance ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x00042408 File Offset: 0x00040608
		public static global::RustProto.objectNetInstance ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x0004241C File Offset: 0x0004061C
		public static global::RustProto.objectNetInstance ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x00042430 File Offset: 0x00040630
		public static global::RustProto.objectNetInstance ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x00042444 File Offset: 0x00040644
		public static global::RustProto.objectNetInstance ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectNetInstance.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x00042458 File Offset: 0x00040658
		private global::RustProto.objectNetInstance MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x0004245C File Offset: 0x0004065C
		public static global::RustProto.objectNetInstance.Builder CreateBuilder()
		{
			return new global::RustProto.objectNetInstance.Builder();
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x00042464 File Offset: 0x00040664
		public override global::RustProto.objectNetInstance.Builder ToBuilder()
		{
			return global::RustProto.objectNetInstance.CreateBuilder(this);
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x0004246C File Offset: 0x0004066C
		public override global::RustProto.objectNetInstance.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectNetInstance.Builder();
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x00042474 File Offset: 0x00040674
		public static global::RustProto.objectNetInstance.Builder CreateBuilder(global::RustProto.objectNetInstance prototype)
		{
			return new global::RustProto.objectNetInstance.Builder(prototype);
		}

		// Token: 0x04000A77 RID: 2679
		public const int ServerPrefabFieldNumber = 1;

		// Token: 0x04000A78 RID: 2680
		public const int OwnerPrefabFieldNumber = 2;

		// Token: 0x04000A79 RID: 2681
		public const int ProxyPrefabFieldNumber = 3;

		// Token: 0x04000A7A RID: 2682
		public const int GroupIDFieldNumber = 4;

		// Token: 0x04000A7B RID: 2683
		private static readonly global::RustProto.objectNetInstance defaultInstance = new global::RustProto.objectNetInstance().MakeReadOnly();

		// Token: 0x04000A7C RID: 2684
		private static readonly string[] _objectNetInstanceFieldNames = new string[]
		{
			"groupID",
			"ownerPrefab",
			"proxyPrefab",
			"serverPrefab"
		};

		// Token: 0x04000A7D RID: 2685
		private static readonly uint[] _objectNetInstanceFieldTags = new uint[]
		{
			0x20U,
			0x10U,
			0x18U,
			8U
		};

		// Token: 0x04000A7E RID: 2686
		private bool hasServerPrefab;

		// Token: 0x04000A7F RID: 2687
		private int serverPrefab_;

		// Token: 0x04000A80 RID: 2688
		private bool hasOwnerPrefab;

		// Token: 0x04000A81 RID: 2689
		private int ownerPrefab_;

		// Token: 0x04000A82 RID: 2690
		private bool hasProxyPrefab;

		// Token: 0x04000A83 RID: 2691
		private int proxyPrefab_;

		// Token: 0x04000A84 RID: 2692
		private bool hasGroupID;

		// Token: 0x04000A85 RID: 2693
		private int groupID_;

		// Token: 0x04000A86 RID: 2694
		private int memoizedSerializedSize = -1;

		// Token: 0x0200024A RID: 586
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder>
		{
			// Token: 0x0600124D RID: 4685 RVA: 0x0004247C File Offset: 0x0004067C
			public Builder()
			{
				this.result = global::RustProto.objectNetInstance.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600124E RID: 4686 RVA: 0x00042498 File Offset: 0x00040698
			internal Builder(global::RustProto.objectNetInstance cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170004C0 RID: 1216
			// (get) Token: 0x0600124F RID: 4687 RVA: 0x000424B0 File Offset: 0x000406B0
			protected override global::RustProto.objectNetInstance.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001250 RID: 4688 RVA: 0x000424B4 File Offset: 0x000406B4
			private global::RustProto.objectNetInstance PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectNetInstance other = this.result;
					this.result = new global::RustProto.objectNetInstance();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170004C1 RID: 1217
			// (get) Token: 0x06001251 RID: 4689 RVA: 0x000424F4 File Offset: 0x000406F4
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170004C2 RID: 1218
			// (get) Token: 0x06001252 RID: 4690 RVA: 0x00042504 File Offset: 0x00040704
			protected override global::RustProto.objectNetInstance MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001253 RID: 4691 RVA: 0x0004250C File Offset: 0x0004070C
			public override global::RustProto.objectNetInstance.Builder Clear()
			{
				this.result = global::RustProto.objectNetInstance.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001254 RID: 4692 RVA: 0x00042524 File Offset: 0x00040724
			public override global::RustProto.objectNetInstance.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectNetInstance.Builder(this.result);
				}
				return new global::RustProto.objectNetInstance.Builder().MergeFrom(this.result);
			}

			// Token: 0x170004C3 RID: 1219
			// (get) Token: 0x06001255 RID: 4693 RVA: 0x00042550 File Offset: 0x00040750
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectNetInstance.Descriptor;
				}
			}

			// Token: 0x170004C4 RID: 1220
			// (get) Token: 0x06001256 RID: 4694 RVA: 0x00042558 File Offset: 0x00040758
			public override global::RustProto.objectNetInstance DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectNetInstance.DefaultInstance;
				}
			}

			// Token: 0x06001257 RID: 4695 RVA: 0x00042560 File Offset: 0x00040760
			public override global::RustProto.objectNetInstance BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001258 RID: 4696 RVA: 0x00042594 File Offset: 0x00040794
			public override global::RustProto.objectNetInstance.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectNetInstance)
				{
					return this.MergeFrom((global::RustProto.objectNetInstance)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001259 RID: 4697 RVA: 0x000425B8 File Offset: 0x000407B8
			public override global::RustProto.objectNetInstance.Builder MergeFrom(global::RustProto.objectNetInstance other)
			{
				if (other == global::RustProto.objectNetInstance.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasServerPrefab)
				{
					this.ServerPrefab = other.ServerPrefab;
				}
				if (other.HasOwnerPrefab)
				{
					this.OwnerPrefab = other.OwnerPrefab;
				}
				if (other.HasProxyPrefab)
				{
					this.ProxyPrefab = other.ProxyPrefab;
				}
				if (other.HasGroupID)
				{
					this.GroupID = other.GroupID;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600125A RID: 4698 RVA: 0x00042644 File Offset: 0x00040844
			public override global::RustProto.objectNetInstance.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x0600125B RID: 4699 RVA: 0x00042654 File Offset: 0x00040854
			public override global::RustProto.objectNetInstance.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectNetInstance._objectNetInstanceFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectNetInstance._objectNetInstanceFieldTags[num2];
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
									this.result.hasGroupID = input.ReadInt32(ref this.result.groupID_);
								}
							}
							else
							{
								this.result.hasProxyPrefab = input.ReadInt32(ref this.result.proxyPrefab_);
							}
						}
						else
						{
							this.result.hasOwnerPrefab = input.ReadInt32(ref this.result.ownerPrefab_);
						}
					}
					else
					{
						this.result.hasServerPrefab = input.ReadInt32(ref this.result.serverPrefab_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170004C5 RID: 1221
			// (get) Token: 0x0600125C RID: 4700 RVA: 0x000427E4 File Offset: 0x000409E4
			public bool HasServerPrefab
			{
				get
				{
					return this.result.hasServerPrefab;
				}
			}

			// Token: 0x170004C6 RID: 1222
			// (get) Token: 0x0600125D RID: 4701 RVA: 0x000427F4 File Offset: 0x000409F4
			// (set) Token: 0x0600125E RID: 4702 RVA: 0x00042804 File Offset: 0x00040A04
			public int ServerPrefab
			{
				get
				{
					return this.result.ServerPrefab;
				}
				set
				{
					this.SetServerPrefab(value);
				}
			}

			// Token: 0x0600125F RID: 4703 RVA: 0x00042810 File Offset: 0x00040A10
			public global::RustProto.objectNetInstance.Builder SetServerPrefab(int value)
			{
				this.PrepareBuilder();
				this.result.hasServerPrefab = true;
				this.result.serverPrefab_ = value;
				return this;
			}

			// Token: 0x06001260 RID: 4704 RVA: 0x00042840 File Offset: 0x00040A40
			public global::RustProto.objectNetInstance.Builder ClearServerPrefab()
			{
				this.PrepareBuilder();
				this.result.hasServerPrefab = false;
				this.result.serverPrefab_ = 0;
				return this;
			}

			// Token: 0x170004C7 RID: 1223
			// (get) Token: 0x06001261 RID: 4705 RVA: 0x00042870 File Offset: 0x00040A70
			public bool HasOwnerPrefab
			{
				get
				{
					return this.result.hasOwnerPrefab;
				}
			}

			// Token: 0x170004C8 RID: 1224
			// (get) Token: 0x06001262 RID: 4706 RVA: 0x00042880 File Offset: 0x00040A80
			// (set) Token: 0x06001263 RID: 4707 RVA: 0x00042890 File Offset: 0x00040A90
			public int OwnerPrefab
			{
				get
				{
					return this.result.OwnerPrefab;
				}
				set
				{
					this.SetOwnerPrefab(value);
				}
			}

			// Token: 0x06001264 RID: 4708 RVA: 0x0004289C File Offset: 0x00040A9C
			public global::RustProto.objectNetInstance.Builder SetOwnerPrefab(int value)
			{
				this.PrepareBuilder();
				this.result.hasOwnerPrefab = true;
				this.result.ownerPrefab_ = value;
				return this;
			}

			// Token: 0x06001265 RID: 4709 RVA: 0x000428CC File Offset: 0x00040ACC
			public global::RustProto.objectNetInstance.Builder ClearOwnerPrefab()
			{
				this.PrepareBuilder();
				this.result.hasOwnerPrefab = false;
				this.result.ownerPrefab_ = 0;
				return this;
			}

			// Token: 0x170004C9 RID: 1225
			// (get) Token: 0x06001266 RID: 4710 RVA: 0x000428FC File Offset: 0x00040AFC
			public bool HasProxyPrefab
			{
				get
				{
					return this.result.hasProxyPrefab;
				}
			}

			// Token: 0x170004CA RID: 1226
			// (get) Token: 0x06001267 RID: 4711 RVA: 0x0004290C File Offset: 0x00040B0C
			// (set) Token: 0x06001268 RID: 4712 RVA: 0x0004291C File Offset: 0x00040B1C
			public int ProxyPrefab
			{
				get
				{
					return this.result.ProxyPrefab;
				}
				set
				{
					this.SetProxyPrefab(value);
				}
			}

			// Token: 0x06001269 RID: 4713 RVA: 0x00042928 File Offset: 0x00040B28
			public global::RustProto.objectNetInstance.Builder SetProxyPrefab(int value)
			{
				this.PrepareBuilder();
				this.result.hasProxyPrefab = true;
				this.result.proxyPrefab_ = value;
				return this;
			}

			// Token: 0x0600126A RID: 4714 RVA: 0x00042958 File Offset: 0x00040B58
			public global::RustProto.objectNetInstance.Builder ClearProxyPrefab()
			{
				this.PrepareBuilder();
				this.result.hasProxyPrefab = false;
				this.result.proxyPrefab_ = 0;
				return this;
			}

			// Token: 0x170004CB RID: 1227
			// (get) Token: 0x0600126B RID: 4715 RVA: 0x00042988 File Offset: 0x00040B88
			public bool HasGroupID
			{
				get
				{
					return this.result.hasGroupID;
				}
			}

			// Token: 0x170004CC RID: 1228
			// (get) Token: 0x0600126C RID: 4716 RVA: 0x00042998 File Offset: 0x00040B98
			// (set) Token: 0x0600126D RID: 4717 RVA: 0x000429A8 File Offset: 0x00040BA8
			public int GroupID
			{
				get
				{
					return this.result.GroupID;
				}
				set
				{
					this.SetGroupID(value);
				}
			}

			// Token: 0x0600126E RID: 4718 RVA: 0x000429B4 File Offset: 0x00040BB4
			public global::RustProto.objectNetInstance.Builder SetGroupID(int value)
			{
				this.PrepareBuilder();
				this.result.hasGroupID = true;
				this.result.groupID_ = value;
				return this;
			}

			// Token: 0x0600126F RID: 4719 RVA: 0x000429E4 File Offset: 0x00040BE4
			public global::RustProto.objectNetInstance.Builder ClearGroupID()
			{
				this.PrepareBuilder();
				this.result.hasGroupID = false;
				this.result.groupID_ = 0;
				return this;
			}

			// Token: 0x04000A87 RID: 2695
			private bool resultIsReadOnly;

			// Token: 0x04000A88 RID: 2696
			private global::RustProto.objectNetInstance result;
		}
	}
}
